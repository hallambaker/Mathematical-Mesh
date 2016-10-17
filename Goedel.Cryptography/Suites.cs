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
using Goedel.Cryptography;

namespace Goedel.Cryptography {

    /// <summary>
    /// Describe a suite of crypto algorithms.
    /// </summary>
    public class CryptoSuite {

        /// <summary>
        /// JOSE algorithm identifier.
        /// </summary>
        public string JOSE {
            get { return _JOSE; }
            set { _JOSE = value; }
            }
        string _JOSE;

        /// <summary>
        /// Digest algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID DigestAlgorithm {
            get { return _DigestAlgorithm; }
            set { _DigestAlgorithm = value; }
            }
        CryptoAlgorithmID _DigestAlgorithm;

        /// <summary>
        /// Authentication (MAC) algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID Authentication {
            get { return _Authentication; }
            set { _Authentication = value; }
            }
        CryptoAlgorithmID _Authentication;
        
        /// <summary>
        /// Encryption algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID Encryption {
            get { return _Encryption; }
            set { _Encryption = value; }
            }
        CryptoAlgorithmID _Encryption;

        /// <summary>
        /// Signature algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID Signature {
            get { return _Signature; }
            set { _Signature = value; }
            }
        CryptoAlgorithmID _Signature;        
        
        /// <summary>
        /// Exchange algorithm identifier.
        /// </summary>
        public CryptoAlgorithmID Exchange {
            get { return _Exchange; }
            set { _Exchange = value; }
            }
        CryptoAlgorithmID _Exchange;

        /// <summary>
        /// Construct a suite description with the specified algorithms.
        /// </summary>
        /// <param name="JOSE">JOSE name.</param>
        /// <param name="DigestAlgorithm">Digest algorithm to use.</param>
        /// <param name="Authentication">Bulk authentication algorithm (MAC).</param>
        /// <param name="Encryption">Bulk encryption algorithm.</param>
        /// <param name="Signature">Signature algorithm.</param>
        /// <param name="Exchange">Public Key agreement algorithm.</param>
        public CryptoSuite(
                string JOSE,
                CryptoAlgorithmID DigestAlgorithm,
                CryptoAlgorithmID Authentication,
                CryptoAlgorithmID Encryption,
                CryptoAlgorithmID Signature,
                CryptoAlgorithmID Exchange
                ) {
            _JOSE = JOSE;
            _Authentication = Authentication;
            _Encryption = Encryption;
            _Signature = Signature;
            _Exchange = Exchange;
            }
        }
    
    /// <summary>
    /// Catalog of CryptoSuite objects indexed by JSON algorithm identifier.
    /// </summary>
    public class CryptoSuites {
        Dictionary<string, CryptoSuite> ByName = new Dictionary<string,CryptoSuite> ();

        static CryptoSuites _Default;
        
        /// <summary>
        /// Default catalog of suites.
        /// </summary>
        public static CryptoSuites Default {
            get { if (_Default == null) _Default = new CryptoSuites(); return _Default; }
            }

        /// <summary>
        /// Construct a catalog of suites 
        /// </summary>
        public CryptoSuites()
            : this(CryptoCatalog.Default, true) {
            }


        /// <summary>
        /// Construct a catalog of suites using algorithms from the specified 
        /// catalog and optionally registering algorithms specified in RFC 7518
        /// </summary>
        /// <param name="CryptoCatalog">Catalog of cryptographic algorithms to use.</param>
        /// <param name="Defaults">If tru, prefills catalog with defined algorithms.</param>
        public CryptoSuites(CryptoCatalog CryptoCatalog, bool Defaults) {

            if (Defaults) {

                //+--------------+-------------------------------+--------------------+
                //| "alg" Param  | Digital Signature or MAC      | Implementation     | Here?
                //| Value        | Algorithm                     | Requirements       |
                //+--------------+-------------------------------+--------------------+
                //| HS256        | HMAC using SHA-256            | Required           | Yes
                //| HS384        | HMAC using SHA-384            | Optional           | 
                //| HS512        | HMAC using SHA-512            | Optional           | Yes
                //| RS256        | RSASSA-PKCS1-v1_5 using       | Recommended        | Yes
                //|              | SHA-256                       |                    |
                //| RS384        | RSASSA-PKCS1-v1_5 using       | Optional           | 
                //|              | SHA-384                       |                    |
                //| RS512        | RSASSA-PKCS1-v1_5 using       | Optional           | Yes
                //|              | SHA-512                       |                    |
                //| ES256        | ECDSA using P-256 and SHA-256 | Recommended+       | Yes
                //| ES384        | ECDSA using P-384 and SHA-384 | Optional           |
                //| ES512        | ECDSA using P-521 and SHA-512 | Optional           | Yes
                //| PS256        | RSASSA-PSS using SHA-256 and  | Optional           |
                //|              | MGF1 with SHA-256             |                    |
                //| PS384        | RSASSA-PSS using SHA-384 and  | Optional           |
                //|              | MGF1 with SHA-384             |                    |
                //| PS512        | RSASSA-PSS using SHA-512 and  | Optional           |
                //|              | MGF1 with SHA-512             |                    |
                //| none         | No digital signature or MAC   | Optional           |
                //|              | performed                     |                    |
                //+--------------+-------------------------------+--------------------+

                // Authentication algorithms
                Add(new CryptoSuite("HS256",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.HMAC_SHA_2_256, 
                    CryptoAlgorithmID.NULL, 
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL));
                Add(new CryptoSuite("HS512",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.HMAC_SHA_2_512, 
                    CryptoAlgorithmID.NULL, 
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL));

                // Signature suites
                Add(new CryptoSuite("RS256",
                    CryptoAlgorithmID.SHA_2_256,
                    CryptoAlgorithmID.NULL, 
                    CryptoAlgorithmID.NULL, 
                    CryptoAlgorithmID.RSASign2048,
                    CryptoAlgorithmID.NULL));
                Add(new CryptoSuite("RS512",
                    CryptoAlgorithmID.SHA_2_512,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.RSASign2048,
                    CryptoAlgorithmID.NULL));

                // Signature suites
                Add(new CryptoSuite("EC256",
                    CryptoAlgorithmID.SHA_2_256,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.ECDSA_P256,
                    CryptoAlgorithmID.NULL));
                Add(new CryptoSuite("EC512",
                    CryptoAlgorithmID.SHA_2_512,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.ECDSA_P521,
                    CryptoAlgorithmID.NULL));

                // Exchange algorithms

                //+--------------------+--------------------+--------+----------------+
                //| "alg" Param Value  | Key Management     | More   | Implementation |
                //|                    | Algorithm          | Header | Requirements   |
                //|                    |                    | Params |                |
                //+--------------------+--------------------+--------+----------------+
                //| RSA1_5             | RSAES-PKCS1-v1_5   | (none) | Recommended-   | Yes
                //| RSA-OAEP           | RSAES OAEP using   | (none) | Recommended+   | Yes
                //|                    | default parameters |        |                |
                //| RSA-OAEP-256       | RSAES OAEP using   | (none) | Optional       |
                //|                    | SHA-256 and MGF1   |        |                |
                //|                    | with SHA-256       |        |                |
                //| A128KW             | AES Key Wrap with  | (none) | Recommended    |
                //|                    | default initial    |        |                |
                //|                    | value using        |        |                |
                //|                    | 128-bit key        |        |                |
                //| A192KW             | AES Key Wrap with  | (none) | Optional       |
                //|                    | default initial    |        |                |
                //|                    | value using        |        |                |
                //|                    | 192-bit key        |        |                |
                //| A256KW             | AES Key Wrap with  | (none) | Recommended    |
                //|                    | default initial    |        |                |
                //|                    | value using        |        |                |
                //|                    | 256-bit key        |        |                |
                //| dir                | Direct use of a    | (none) | Recommended    |
                //|                    | shared symmetric   |        |                |
                //|                    | key as the CEK     |        |                |
                //| ECDH-ES            | Elliptic Curve     | "epk", | Recommended+   |
                //|                    | Diffie-Hellman     | "apu", |                |
                //|                    | Ephemeral Static   | "apv"  |                |
                //|                    | key agreement      |        |                |
                //|                    | using Concat KDF   |        |                |
                //| ECDH-ES+A128KW     | ECDH-ES using      | "epk", | Recommended    |
                //|                    | Concat KDF and CEK | "apu", |                |
                //|                    | wrapped with       | "apv"  |                |
                //|                    | "A128KW"           |        |                |
                //| ECDH-ES+A192KW     | ECDH-ES using      | "epk", | Optional       |
                //|                    | Concat KDF and CEK | "apu", |                |
                //|                    | wrapped with       | "apv"  |                |
                //|                    | "A192KW"           |        |                |
                //| ECDH-ES+A256KW     | ECDH-ES using      | "epk", | Recommended    |
                //|                    | Concat KDF and CEK | "apu", |                |
                //|                    | wrapped with       | "apv"  |                |
                //|                    | "A256KW"           |        |                |
                //| A128GCMKW          | Key wrapping with  | "iv",  | Optional       |
                //|                    | AES GCM using      | "tag"  |                |
                //|                    | 128-bit key        |        |                |
                //| A192GCMKW          | Key wrapping with  | "iv",  | Optional       |
                //|                    | AES GCM using      | "tag"  |                |
                //|                    | 192-bit key        |        |                |
                //| A256GCMKW          | Key wrapping with  | "iv",  | Optional       |
                //|                    | AES GCM using      | "tag"  |                |
                //|                    | 256-bit key        |        |                |
                //| PBES2-HS256+A128KW | PBES2 with HMAC    | "p2s", | Optional       |
                //|                    | SHA-256 and        | "p2c"  |                |
                //|                    | "A128KW" wrapping  |        |                |
                //| PBES2-HS384+A192KW | PBES2 with HMAC    | "p2s", | Optional       |
                //|                    | SHA-384 and        | "p2c"  |                |
                //|                    | "A192KW" wrapping  |        |                |
                //| PBES2-HS512+A256KW | PBES2 with HMAC    | "p2s", | Optional       |
                //|                    | SHA-512 and        | "p2c"  |                |
                //|                    | "A256KW" wrapping  |        |                |
                //+--------------------+--------------------+--------+----------------+

                Add(new CryptoSuite("RSA1_5",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.RSAExch2048,
                    CryptoAlgorithmID.NULL));

                Add(new CryptoSuite("RSA-OAEP",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.RSAExch2048,
                    CryptoAlgorithmID.NULL));



                //+---------------+----------------------------------+----------------+
                //| "enc" Param   | Content Encryption Algorithm     | Implementation |
                //| Value         |                                  | Requirements   |
                //+---------------+----------------------------------+----------------+
                //| A128CBC-HS256 | AES_128_CBC_HMAC_SHA_256         | Required       |
                //|               | authenticated encryption         |                |
                //|               | algorithm, as defined in Section |                |
                //|               | 5.2.3                            |                |
                //| A192CBC-HS384 | AES_192_CBC_HMAC_SHA_384         | Optional       |
                //|               | authenticated encryption         |                |
                //|               | algorithm, as defined in Section |                |
                //|               | 5.2.4                            |                |
                //| A256CBC-HS512 | AES_256_CBC_HMAC_SHA_512         | Required       |
                //|               | authenticated encryption         |                |
                //|               | algorithm, as defined in Section |                |
                //|               | 5.2.5                            |                |
                //| A128GCM       | AES GCM using 128-bit key        | Recommended    |
                //| A192GCM       | AES GCM using 192-bit key        | Optional       |
                //| A256GCM       | AES GCM using 256-bit key        | Recommended    |
                //+---------------+----------------------------------+----------------+

                Add(new CryptoSuite("A128CBC-HS256",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.HMAC_SHA_2_256,
                    CryptoAlgorithmID.AES128CBC,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL));
                Add(new CryptoSuite("A256CBC-HS512",
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.HMAC_SHA_2_512,
                    CryptoAlgorithmID.AES256CBC,
                    CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID.NULL));

                }
            }

        /// <summary>
        /// Get Suite by JSON name.
        /// </summary>
        /// <param name="Name">JSON alg property.</param>
        /// <returns>Suite of algorithm identifiers if found, otherwise null.</returns>
        public CryptoSuite Get (string Name) {
            CryptoSuite Result;
            ByName.TryGetValue (Name, out Result);
            return Result;
            }

        /// <summary>
        /// Add a suite with the specified parameters to the catalog.
        /// </summary>
        /// <param name="Suite"></param>
        public void Add (CryptoSuite Suite) {
        ByName.Add(Suite.JOSE, Suite);
            }

        }



    }
