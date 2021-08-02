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
using System.IO;
using System.Security.Cryptography;

using Goedel.Utilities;

namespace Goedel.Cryptography.Standard {
    /// <summary>
    /// Provider for bulk authentication algorithms (e.g. HMAC-SHA256).
    /// </summary>
    public abstract class CryptoProviderAuthentication :
                Goedel.Cryptography.CryptoProviderAuthentication {
        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClasses AlgorithmClass => CryptoAlgorithmClasses.MAC;

        /// <summary>
        /// Hash algorithm provider.
        /// </summary>
        public KeyedHashAlgorithm KeyedHashAlgorithm { get; set; }


        /// <summary>
        /// Truncation length. If this value is greater than 0, the output size is 
        /// truncated to the nearest integer multiple of 8 bits.
        /// </summary>
        protected int Truncate { get; set; } = 0;


        /// <summary>
        /// Authentication key.
        /// </summary>
        public byte[] Key {
            set {
                var KeyedHash = KeyedHashAlgorithm;
                KeyedHash.Key = value;
                }
            get {
                var KeyedHash = KeyedHashAlgorithm;
                return KeyedHash.Key;
                }
            }

        /// <summary>
        /// Initializes an instance of the hash provider with the specified
        /// implementation.
        /// </summary>
        /// <param name="KeyedHashAlgorithm">The hash algorithm to construct provider for.</param>
        protected CryptoProviderAuthentication(KeyedHashAlgorithm KeyedHashAlgorithm) => this.KeyedHashAlgorithm = KeyedHashAlgorithm;

        /// <summary>Create an encoder for the specified data</summary>
        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="Bulk">The bulk provider to use. If specified, the parameters from
        /// the specified provider will be used. Otherwise a new bulk provider will 
        /// be created and returned as part of the result.</param>
        /// <param name="OutputStream">Output stream</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeEncoder(
                            CryptoProviderBulk Bulk = null,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null
                            ) {

            // Key wrap is not yet implemented.
            if (Bulk != null) { throw new NYI("Key wrap"); }

            var Result = new CryptoDataEncoder(CryptoAlgorithmID, this) {
                OutputStream = OutputStream ?? new MemoryStream()
                };
            BindEncoder(Result);

            return Result;
            }


        /// <summary>
        /// Create an encoder for a bulk algorithm and optional key wrap or exchange.
        /// </summary>

        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="OutputStream">Output stream</param>
        /// <param name="Key">Encryption Key</param>
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeAuthenticator(
                            byte[] Key = null,
                            CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default,
                            Stream OutputStream = null) {
            var Result = new CryptoDataEncoder(CryptoAlgorithmID, this) {
                OutputStream = OutputStream ?? new MemoryStream(),
                Key = Key
                };
            BindEncoder(Result);

            return Result;
            }


        /// <summary>
        /// Create a crypto stream from this provider.
        /// </summary>
        /// <param name="Encoder">The encoder to bind.</param>
        public override void BindEncoder(CryptoDataEncoder Encoder) {
            KeyedHashAlgorithm.Key = Encoder.Key;
            Encoder.InputStream = new CryptoStream(
                    Encoder.OutputStream, KeyedHashAlgorithm, CryptoStreamMode.Write);
            }


        /// <summary>
        /// Processes the specified byte array
        /// </summary>
        /// <param name="Data">The input to process</param>
        /// <param name="Offset">Offset within array</param>
        /// <param name="Count">Number of bytes to process</param>
        /// <param name="Key">The key</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public override byte[] ProcessData(byte[] Data, int Offset,
                                                int Count, byte[] Key = null) {
            if (Key != null) {
                KeyedHashAlgorithm.Key = Key;
                }
            return KeyedHashAlgorithm.ComputeHash(Data, Offset, Count);
            }

        /// <summary>
        /// Complete processing at the end of an encoding or decoding operation
        /// </summary>
        /// <param name="CryptoData">Structure to write result to</param>
        public override void Complete(CryptoData CryptoData) {
            var CryptoStream = CryptoData.InputStream as CryptoStream;
            CryptoStream.FlushFinalBlock();
            CryptoData.Integrity = KeyedHashAlgorithm.Hash.OrTruncated(Truncate);
            CryptoStream.Dispose();
            return;
            }


        }

    /// <summary>
    /// Provider for HMAC SHA-2 256 bits.
    /// </summary>
    public class CryptoProviderHMACSHA2_256 : CryptoProviderAuthentication {
        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.HMAC_SHA_2_256;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;

        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 256);


        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }



        /// <summary>
        /// Default algorithm key and output size.
        /// </summary>
        public override int Size => 256;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId Ignore) => new CryptoProviderHMACSHA2_256();

        /// <summary>
        /// Constructor, algorithm takes no parameters.
        /// </summary>
        public CryptoProviderHMACSHA2_256()
            : base(new HMACSHA256()) {
            }
        }

    /// <summary>
    /// Provider for HMAC SHA-2 512 bits.
    /// </summary>
    public class CryptoProviderHMACSHA2_512 : CryptoProviderAuthentication {

        static CryptoAlgorithmId _CryptoAlgorithmID = CryptoAlgorithmId.HMAC_SHA_2_512;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmId CryptoAlgorithmID => _CryptoAlgorithmID;


        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => _CryptoAlgorithm;


        static CryptoAlgorithm _CryptoAlgorithm = new(
                    _CryptoAlgorithmID, _AlgorithmClass, Factory, 512);


        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog ??= CryptoCatalog.Default;
            return Catalog.Add(_CryptoAlgorithm);
            }
        /// <summary>
        /// Default algorithm key and output size.
        /// </summary>
        public override int Size => 512;


        /// <summary>
        /// Factory method for provider.
        /// </summary>
        /// <param name="KeySize">The key size (ignored)</param>
        /// <param name="Ignore">The cryptographic algorithn (ignored)</param>
        /// <returns></returns>
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmId Ignore) => new CryptoProviderHMACSHA2_512();

        /// <summary>
        /// Constructor, algorithm takes no parameters.
        /// </summary>
        public CryptoProviderHMACSHA2_512()
            : base(new HMACSHA512()) {
            }

        }

    }