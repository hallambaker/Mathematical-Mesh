//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using Goedel.Utilities;

using System.IO;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Standard {
    /// <summary>
    /// Provider for bulk encryption algorithms (e.g. AES). Prior to the introduction of
    /// .NET Standard and the unification of the cryptographic processing algorithms, this
    /// class was necessary as a means of enabling the use of different providers. It is
    /// now redundant and will be removed in due course.
    /// </summary>
    public abstract class CryptoProviderEncryption :
                Goedel.Cryptography.CryptoProviderEncryption {

        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClasses AlgorithmClass => CryptoAlgorithmClasses.Encryption;

        /// <summary>
        /// The .NET cryptographic provider (for use by sub classes).
        /// </summary>
        protected SymmetricAlgorithm Provider { get; set; }

        //ICryptoTransform Transform = null;
        //bool Encrypting;

        /// <summary>
        /// The size of the required key
        /// </summary>
        public override int KeySize => Provider.KeySize;

        /// <summary>
        /// The size of the required IV. If zero, no IV is required.
        /// </summary>
        public override int IVSize => Provider.IV.Length * 8;

        ///// <summary>
        ///// If set to true, the initialization vector (if used) will be prepended to the
        ///// beginning of the output byte stream.
        ///// </summary>
        //public bool AppendIV { get; set; } = false;

        ///// <summary>
        ///// If set to true, the authentication code (if created) will be appended to the
        ///// end of the output byte stream.
        ///// 
        ///// Since we don't currently have a GCM mode, this isn't currently used.
        ///// </summary>
        //public bool AppendIntegrity { get; set; } = false;


        /// <summary>
        /// Return the padded output length for a specified input length.
        /// </summary>
        /// <remarks>Only implemented for PKCS#7 padding.</remarks>
        /// <param name="Input">The input length in bytes</param>
        /// <returns>The output length in bytes.</returns>
        public override long OutputLength(long Input) {
            if (Provider.Padding == PaddingMode.PKCS7) {
                var Bytes = Provider.BlockSize / 8;
                var Blocks = (Input / Bytes) + 1;
                var Result = Blocks * Bytes;
                return Result;
                }

            throw new NYI();

            }


        /// <summary>
        /// Return a block Encryptor for the specified key and IV. This is required for
        /// constructing certain types of streaming encoder on block algorithms.
        /// </summary>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <returns>The transformation object instance.</returns>
        public override ICryptoTransform CreateEncryptor(byte[] Key, byte[] IV) => Provider.CreateEncryptor(Key, IV);


        /// <summary>
        /// Return a block decryptor for the specified key and IV. This is required for
        /// constructing certain types of streaming encoder on block algorithms.
        /// </summary>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector. Must be of a legal size for the algorithm</param>
        /// <returns>The transformation object instance.</returns>
        public override ICryptoTransform CreateDecryptor(byte[] Key, byte[] IV) => Provider.CreateDecryptor(Key, IV);


        /// <summary>
        /// Constructor for initializing a delegate class.
        /// </summary>
        /// <param name="SymmetricAlgorithm">Cryptographic provider.</param>
        /// <param name="KeySize">Key size in bits.</param>
        /// <param name="CipherMode">Cipher mode to use</param>
        ///<param name="PaddingMode">Padding mode to use</param>
        protected CryptoProviderEncryption(SymmetricAlgorithm SymmetricAlgorithm,
                int KeySize, CipherMode CipherMode,
                PaddingMode PaddingMode = PaddingMode.PKCS7) {
            this.Provider = SymmetricAlgorithm;
            Provider.KeySize = KeySize;
            Provider.Mode = CipherMode;
            Provider.Padding = PaddingMode;
            }


        /// <summary>Create an encoder for the specified data</summary>
        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="Bulk">The bulk provider to use. If specified, the parameters from
        /// the specified provider will be used. Otherwise a new bulk provider will 
        /// be created and returned as part of the result.</param>
        /// <param name="OutputStream">Output stream</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeEncoder(
                            CryptoProviderBulk Bulk = null,
                            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default,
                            Stream OutputStream = null
                            ) => MakeEncryptor(Provider.Key, Provider.IV,
                Algorithm, OutputStream);

        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="IV">Initialization vector for symmetric encryption</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeEncryptor(
                            byte[] Key = null, byte[] IV = null,
                            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default,
                            Stream OutputStream = null) {
            var Result = new CryptoDataEncoder(CryptoAlgorithmID, this) {
                OutputStream = OutputStream ?? new MemoryStream(),
                IV = IV,
                Key = Key
                };
            BindEncoder(Result);

            return Result;
            }


        /// <summary>
        /// Create a decoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="IV">Initialization vector for symmetric encryption</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataDecoder MakeDecryptor(
                            byte[] Key, byte[] IV,
                            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default,
                            Stream OutputStream = null) {
            var Result = new CryptoDataDecoder(CryptoAlgorithmID, this) {
                OutputStream = OutputStream ?? new MemoryStream(),
                IV = IV,
                Key = Key
                };
            BindDecoder(Result);

            return Result;
            }

        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Encoder">The encoder to bind.</param>
        public override void BindEncoder(CryptoDataEncoder Encoder) {
            var Transform = Provider.CreateEncryptor(Encoder.Key, Encoder.IV);
            Encoder.InputStream = new CryptoStream(
                    Encoder.OutputStream, Transform, CryptoStreamMode.Write);
            }


        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Decoder">The encoder to bind.</param>
        public override void BindDecoder(CryptoDataDecoder Decoder) {
            var Transform = Provider.CreateDecryptor(Decoder.Key, Decoder.IV);
            Decoder.InputStream = new CryptoStream(
                    Decoder.OutputStream, Transform, CryptoStreamMode.Write);
            }

        /// <summary>
        /// Encrypt the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="IV">The Initialization Vector</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public override byte[] Encrypt(byte[] Data,
                        byte[] Key = null, byte[] IV = null) {

            Key = Key ?? Provider.Key;
            IV = IV ?? Provider.IV;

            //Console.WriteLine("Encrypt {0}", Key.Base16());

            var Transform = Provider.CreateEncryptor(Key, IV);
            return Process(Data, Transform);
            }

        /// <summary>
        /// Encrypt the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="IV">The Initialization Vector</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public override byte[] Decrypt(byte[] Data,
                        byte[] Key = null, byte[] IV = null) {
            Key = Key ?? Provider.Key;
            IV = IV ?? Provider.IV;

            //Console.WriteLine("Decrypt {0}", Key.Base16());
            //Console.WriteLine("IV {0}", IV.Base16());
            //Console.WriteLine("CipherText {0}", Data.Base16(50));

            var Transform = Provider.CreateDecryptor(Key, IV);

            byte[] Result;
            using (var Input = new MemoryStream()) {
                using (var CryptoStream = new CryptoStream(Input, Transform, CryptoStreamMode.Write)) {
                    CryptoStream.Write(Data, 0, Data.Length);
                    CryptoStream.Close();
                    }
                Result = Input.ToArray();
                }

            return Result;

            //return Process(Data, Transform);
            }


        byte[] Process(byte[] Data, ICryptoTransform Transform) {
            byte[] Result;
            using (var Output = new MemoryStream()) {
                using (var Input = new CryptoStream(Output, Transform, CryptoStreamMode.Write)) {
                    Input.Write(Data, 0, Data.Length);
                    }
                Result = Output.ToArray();
                }
            return Result;
            }




        /// <summary>
        /// Complete processing at the end of an encoding or decoding operation
        /// </summary>
        /// <param name="CryptoData">Last data.</param>
        public override void Complete(CryptoData CryptoData) {
            (CryptoData.InputStream as CryptoStream).FlushFinalBlock();
            base.Complete(CryptoData);
            }

        }



    /// <summary>
    /// Provider for the SHA-2 256 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderEncryptAES : CryptoProviderEncryption {

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID => (Provider.KeySize == 128) ?
                    CryptoAlgorithmID.AES128CBC : CryptoAlgorithmID.AES256CBC;


        ///// <summary>
        ///// Return a CryptoAlgorithm structure with properties describing this provider.
        ///// </summary>
        //public override CryptoAlgorithm CryptoAlgorithm {
        //    get {
        //        return (Provider.KeySize == 128) ?
        //            CryptoAlgorithm128CBC : CryptoAlgorithm256CBC;
        //        }
        //    }

        /// <summary>Return the block size in bits</summary>
        public override int BlockSize => Provider.BlockSize;



        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog = Catalog ?? CryptoCatalog.Default;
            var Default = Catalog.Add(CryptoAlgorithmID.AES256CBC, 256, _AlgorithmClass, Factory);

            Catalog.Add(CryptoAlgorithmID.AES256, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES128CBC, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES128CTS, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES128CBCNone, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES128ECB, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES256CTS, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES256CBCNone, 256, _AlgorithmClass, Factory);
            Catalog.Add(CryptoAlgorithmID.AES256ECB, 256, _AlgorithmClass, Factory);

            return Default;
            }

        private static CryptoProvider Factory(int KeySize,
                            CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) {
            switch (Bulk) {
                case CryptoAlgorithmID.Default: {
                    return new CryptoProviderEncryptAES(KeySize);
                    }
                case CryptoAlgorithmID.AES128: {
                    return new CryptoProviderEncryptAES(128);
                    }
                case CryptoAlgorithmID.AES128CBC: {
                    return new CryptoProviderEncryptAES(128,
                            CipherMode.CBC, PaddingMode.PKCS7);
                    }
                case CryptoAlgorithmID.AES128CTS: {
                    return new CryptoProviderEncryptAES(128,
                            CipherMode.CTS, PaddingMode.PKCS7);
                    }
                case CryptoAlgorithmID.AES128CBCNone: {
                    return new CryptoProviderEncryptAES(128,
                            CipherMode.CBC, PaddingMode.None);
                    }
                case CryptoAlgorithmID.AES128ECB: {
                    return new CryptoProviderEncryptAES(128,
                            CipherMode.ECB, PaddingMode.None);
                    }
                case CryptoAlgorithmID.AES256: {
                    return new CryptoProviderEncryptAES(256);
                    }
                case CryptoAlgorithmID.AES256CBC: {
                    return new CryptoProviderEncryptAES(256,
                            CipherMode.CBC, PaddingMode.PKCS7);
                    }
                case CryptoAlgorithmID.AES256CTS: {
                    return new CryptoProviderEncryptAES(256,
                            CipherMode.CTS, PaddingMode.PKCS7);
                    }
                case CryptoAlgorithmID.AES256CBCNone: {
                    return new CryptoProviderEncryptAES(256,
                            CipherMode.CBC, PaddingMode.None);
                    }
                case CryptoAlgorithmID.AES256ECB: {
                    return new CryptoProviderEncryptAES(256,
                            CipherMode.ECB, PaddingMode.None);
                    }
                default: {
                    throw new CipherModeNotSupported();
                    }
                }
            }

        /// <summary>
        /// Default algorithm key size.
        /// </summary>
        public override int Size => Provider.KeySize;


        /// <summary>
        /// Create an AES provider with the specified key size and mode.
        /// </summary>
        /// <param name="KeySize">Key Size in bits.</param>
        /// <param name="CipherMode">The cipher mode to use (CBC or CTS).</param>
        /// <param name="PaddingMode">The Padding Mode to use (PKCS or None).</param>
        public CryptoProviderEncryptAES(int KeySize,
                        CipherMode CipherMode = CipherMode.CBC,
                        PaddingMode PaddingMode = PaddingMode.PKCS7)
            : base(new AesManaged(), KeySize, CipherMode, PaddingMode) {
            }




        }
    }