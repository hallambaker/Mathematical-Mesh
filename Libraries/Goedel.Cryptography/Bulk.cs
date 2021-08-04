#region // Copyright
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.IO;
using System.Security.Cryptography;

using Goedel.Utilities;

namespace Goedel.Cryptography {


    /// <summary>
    /// Base class for providers of bulk cryptographic algorithms, e.g. encryption,
    /// digest, authentication
    /// </summary>
    public abstract class CryptoProviderBulk : CryptoProvider {


        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Encoder">The encoder to bind.</param>
        public abstract void BindEncoder(CryptoDataEncoder Encoder);



        }

    /// <summary>
    /// Base class for cryptographic digest providers.
    /// </summary>
    public abstract class CryptoProviderDigest : CryptoProviderBulk {

        readonly static byte[] emptyByteArray = new byte[0];

        ///<summary>Return the digest value of a empty byte array. The value is calculated once and cached.</summary>
        public byte[] NullDigest => nullDigest ?? ProcessData(emptyByteArray, emptyByteArray).CacheValue(out nullDigest);
        byte[] nullDigest;

        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual CryptoData Process(byte[] Data, byte[] Key = null) {
            var Integrity = ProcessData(Data, Key);
            return new CryptoDataEncoder(CryptoAlgorithmID, this) {
                Integrity = Integrity
                };
            }


        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public virtual byte[] ProcessData(byte[] Data, byte[] Key = null) => ProcessData(Data, 0, Data.Length, Key);


        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="Offset">Offset within array</param>
        /// <param name="Count">Number of bytes to process</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public abstract byte[] ProcessData(byte[] Data, int Offset,
            int Count, byte[] Key = null);


        /// <summary>The crypto algorithm class.</summary>
        protected static CryptoAlgorithmClasses _AlgorithmClass =
            CryptoAlgorithmClasses.Digest;

        /// <summary>Return the crypto algorithm class.</summary>
        public override CryptoAlgorithmClasses AlgorithmClass => _AlgorithmClass;


        }

    /// <summary>
    /// Base class for cryptographic MAC providers.
    /// </summary>
    public abstract class CryptoProviderAuthentication : CryptoProviderDigest {

        /// <summary>The crypto algorithm class.</summary>
        protected static new CryptoAlgorithmClasses _AlgorithmClass =
            CryptoAlgorithmClasses.MAC;

        /// <summary>Return the crypto algorithm class.</summary>
        public override CryptoAlgorithmClasses AlgorithmClass => _AlgorithmClass;


        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public abstract CryptoDataEncoder MakeAuthenticator(
                            byte[] Key = null,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null);

        }

    /// <summary>
    /// Base class for cryptographic encryption providers.
    /// </summary>
    public abstract class CryptoProviderEncryption : CryptoProviderBulk {
        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Decoder">The decoder to bind.</param>
        public abstract void BindDecoder(CryptoDataDecoder Decoder);

        /// <summary>
        /// The size of the required key in bits
        /// </summary>
        public abstract int KeySize { get; }

        /// <summary>
        /// The size of the required IV in bits. If zero, no IV is required.
        /// </summary>
        public abstract int IVSize { get; }


        /// <summary>
        /// The data block size in bits (1 for a stream cipher)
        /// </summary>
        public abstract int BlockSize { get; }

        /// <summary>
        /// Return the padded output length for a specified input length.
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public abstract long OutputLength(long Input);

        /// <summary>
        /// Creates a new instance of the CryptoStream class to encrypt data under the specified
        /// <paramref name="Key"/> and <paramref name="IV"/>.
        /// </summary>
        /// <param name="Output">The stream on which to perform the cryptographic transformation.</param>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <param name="mode">One of the CryptoStreamMode values.</param>
        /// <returns>The CryptoStream with the specified parameters.</returns>
        public CryptoStream GetEncryptionStream(
                        Stream Output,
                        byte[] Key, byte[] IV,
                        CryptoStreamMode mode) => new(Output,
                            CreateEncryptor(Key, IV), mode);

        /// <summary>
        /// Creates a new instance of the CryptoStream class to encrypt data under the specified
        /// <paramref name="Key"/> and <paramref name="IV"/>.
        /// </summary>
        /// <param name="Output">The stream on which to perform the cryptographic transformation.</param>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <param name="mode">One of the CryptoStreamMode values.</param>
        /// <returns>The CryptoStream with the specified parameters.</returns>
        public CryptoStream GetDecryptionStream(
                        Stream Output,
                        byte[] Key, byte[] IV,
                        CryptoStreamMode mode) => new(Output,
                            CreateDecryptor(Key, IV), mode);


        /// <summary>
        /// Return a block Encryptor for the specified key and IV. This is required for
        /// constructing certain types of streaming encoder on block algorithms.
        /// </summary>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <returns>The transformation object instance.</returns>
        public abstract ICryptoTransform CreateEncryptor(byte[] Key, byte[] IV);


        /// <summary>
        /// Return a block decryptor for the specified key and IV. This is required for
        /// constructing certain types of streaming encoder on block algorithms.
        /// </summary>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <returns>The transformation object instance.</returns>
        public abstract ICryptoTransform CreateDecryptor(byte[] Key, byte[] IV);

        /// <summary>
        /// Encrypts the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="IV">The Initialization Vector</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public abstract byte[] Encrypt(byte[] Data, byte[] Key = null, byte[] IV = null);

        /// <summary>
        /// Decrypts the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="IV">The Initialization Vector</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public abstract byte[] Decrypt(byte[] Data, byte[] Key = null, byte[] IV = null);


        /// <summary>Return the crypto algorithm class.</summary>
        public override CryptoAlgorithmClasses AlgorithmClass => _AlgorithmClass;

        /// <summary>The crypto algorithm class.</summary>
        protected static CryptoAlgorithmClasses _AlgorithmClass =
            CryptoAlgorithmClasses.Encryption;

        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="IV">Initialization vector for symmetric encryption</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public abstract CryptoDataEncoder MakeEncryptor(
                            byte[] Key = null, byte[] IV = null,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null);

        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="IV">Initialization vector for symmetric encryption</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public abstract CryptoDataDecoder MakeDecryptor(
                            byte[] Key, byte[] IV,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null
                            );

        }
    }


