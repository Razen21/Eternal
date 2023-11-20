using System.Buffers;
using System.Security.Cryptography;

namespace Eternal.Cryptography.Ciphers
{
    internal static class AesCipher
    {

        private static readonly Lazy<Aes> LazyAesInstance = new Lazy<Aes>(() =>
        {
            var cipher = Aes.Create();
            cipher.KeySize = 256;
            return cipher;
        });

        internal static void Transform(Span<byte> input, uint iv)
        {
            // Initial block size is smaller to account for packet header. (4 bytes)
            var blockSize = 0x5B0;
            var remaining = input.Length;
            var position = 0;

            const int bufferLength = sizeof(int) * 4;

            var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
            var extractedIv = BitConverter.GetBytes(iv);

            using var encryptor = LazyAesInstance.Value.CreateEncryptor();

            while (remaining > 0)
            {
                for (var i = 0; i < bufferLength; ++i)
                    buffer[i] = extractedIv[i % 4];

                var length = Math.Min(remaining, blockSize);

                for (var i = position; i < position + length; ++i)
                {
                    var sub = i - position;

                    if (sub % bufferLength == 0)
                        encryptor.TransformBlock(buffer, 0, bufferLength, buffer, 0);

                    input[i] ^= buffer[sub % bufferLength];
                }

                position += length;
                remaining -= length;
                blockSize = 0x5B4;
            }

            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
