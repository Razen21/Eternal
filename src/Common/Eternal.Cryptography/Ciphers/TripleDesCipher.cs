using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eternal.Cryptography.Ciphers
{
    internal static class TripleDesCipher
    {
        private static readonly Lazy<TripleDES> LazyTripleDesInstance = new Lazy<TripleDES>(() =>
        {
            var cipher = TripleDES.Create();

            cipher.GenerateIV();
            cipher.Mode = CipherMode.ECB;
            cipher.BlockSize = 64;
            cipher.Padding = PaddingMode.None;
            cipher.FeedbackSize = 64;
        });


        internal static string Decrypt(byte[] input, byte[] key)
        {
            LazyTripleDesInstance.Value.Key = key;

            using var memoryStream = new MemoryStream(input);
            using var decryptor = LazyTripleDesInstance.Value.CreateDecryptor();
            using var cryptoSteam = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoSteam);

            return streamReader.ReadToEnd();
        }
    }
}
