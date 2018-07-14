using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Standard {

    /// <summary>
    /// AES block encryption/decryption transform. This is used in the AES Key wrap and
    /// other routines to wrap the block encryption provided at the platform level.
    /// </summary>
    public class AesBlock : BlockProvider {
        static Aes Provider;
        ICryptoTransform Transform;

        /// <summary>
        /// Return the block size in bits.
        /// </summary>
        public override int BlockSize => Provider.BlockSize;

        static AesBlock() => Provider = new AesManaged() {
            Mode = CipherMode.ECB,
            Padding = PaddingMode.None
            };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Key">Key</param>
        /// <param name="Encrypt">If true, encrypt, otherwise decrypt</param>
        public AesBlock(byte[] Key, bool Encrypt) => Transform = Encrypt ? Provider.CreateEncryptor(Key, null) : Provider.CreateDecryptor(Key, null);

        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="Key">The key to initialize the method</param>
        /// <param name="Encrypt">If true, create an encryptor, if false, create a decryptor.</param>
        /// <returns>The block provider.</returns>
        public static BlockProvider Factory(byte[] Key, bool Encrypt) => new AesBlock(Key, Encrypt);

        /// <summary>
        /// Encrypt or decrypt a single block of data under the specified key
        /// </summary>
        /// <param name="Input">Input byte array</param>
        /// <param name="InputOffset">Read offset in input array.</param>
        /// <param name="Output">Output byte array</param>
        /// <param name="OutputOffset">Write offset in output array.</param>
        public override void Process(byte[] Input, int InputOffset, byte[] Output, int OutputOffset) => Transform.TransformBlock(Input, InputOffset, Transform.InputBlockSize, Output, OutputOffset);


        }
    }
