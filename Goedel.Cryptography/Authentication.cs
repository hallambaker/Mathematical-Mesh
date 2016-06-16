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
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.Cryptography {
    /// <summary>
    /// Provider for bulk authentication algorithms (e.g. HMAC-SHA256).
    /// </summary>
    public abstract class CryptoProviderAuthentication : CryptoProviderDigest {
        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClass AlgorithmClass { get { return CryptoAlgorithmClass.MAC; } }


        /// <summary>
        /// Authentication key.
        /// </summary>
        public byte[] Key {
            set {
                var KeyedHash = HashAlgorithm as KeyedHashAlgorithm;
                KeyedHash.Key = value;
                }
            get {
                var KeyedHash = HashAlgorithm as KeyedHashAlgorithm;
                return KeyedHash.Key;
                }
            }

        /// <summary>
        /// Initializes an instance of the hash provider with the specified
        /// implementation.
        /// </summary>
        /// <param name="HashAlgorithm"></param>
        protected CryptoProviderAuthentication(HashAlgorithm HashAlgorithm) {
            this.HashAlgorithm = HashAlgorithm;
            }
        }

    /// <summary>
    /// Provider for HMAC SHA-2 256 bits.
    /// </summary>
    public class CryptoProviderHMACSHA2_256 : CryptoProviderAuthentication {
        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {
                return CryptoAlgorithmID.HMAC_SHA_2_256;
                }
            }
        /// <summary>
        /// .NET Framework name
        /// </summary>
        public override string Name {
            get {
                return "HMACSHA256";
                }
            }
        /// <summary>
        /// JSON Algorithm Name
        /// </summary>
        public override string JSONName {
            get {
                return "HS256";
                }
            }
        /// <summary>
        /// Default algorithm key and output size.
        /// </summary>
        public override int Size {
            get {
                return 256;
                }
            }
        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID Ignore) {
            return new CryptoProviderHMACSHA2_256();
            }

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
        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {
                return CryptoAlgorithmID.HMAC_SHA_2_512;
                }
            }
        /// <summary>
        /// .NET Framework name
        /// </summary>
        public override string Name {
            get {
                return "HMACSHA512";
                }
            }
        /// <summary>
        /// JSON Algorithm Name
        /// </summary>
        public override string JSONName {
            get {
                return "HS512";
                }
            }
        /// <summary>
        /// Default algorithm key and output size.
        /// </summary>
        public override int Size {
            get {
                return 512;
                }
            }
        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID Ignore) {
            return new CryptoProviderHMACSHA2_512();
            }
        /// <summary>
        /// Constructor, algorithm takes no parameters.
        /// </summary>
        public CryptoProviderHMACSHA2_512()
            : base(new HMACSHA512()) {
            }
        }

    }