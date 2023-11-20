using Eternal.Cryptography.Ciphers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternal.Cryptography
{
    public static class CryptographyOperations
    {
        /// <summary>
        /// Generates a new hash for the initialization vector using the InnoHash algorithm.
        /// </summary>
        /// <param name="iv">The initialization vector to hash.</param>
        /// <returns>The hashed initialization vector.</returns>
        public static uint HashInitializationVector(uint iv) => IGCipher.InnoHash(iv);

        /// <summary>
        /// Transforms the packet data (encrypt / decrypt) using a modified AES-OFB encryption.
        /// </summary>
        /// <param name="input">The packet data to transform.</param>
        /// <param name="iv">The initialization vector.</param>
        public static void TransformPacketData(Span<byte> input, uint iv) => AesCipher.Transform(input, iv);
    }
}
