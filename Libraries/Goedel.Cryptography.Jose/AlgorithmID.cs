using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Constants and related methods for identifying cryptographic algorithms and suites.
    /// </summary>
    public static class AlgorithmID {

        /// <summary>
        /// Lookup identifier by Jose name.
        /// </summary>
        public static readonly Dictionary<string, CryptoAlgorithmID> StringtoID =
            new Dictionary<string, CryptoAlgorithmID> {
                //SHA-256	alg (Private)
                { "S256", CryptoAlgorithmID.SHA_2_256},
                //SHA-512	alg (Private)
                { "S512", CryptoAlgorithmID.SHA_2_512},

                //HS256   HMAC using SHA-256	alg Required[IESG]  [RFC7518, Section 3.2]
                { "HS256", CryptoAlgorithmID.HMAC_SHA_2_256},
                //HS512   HMAC using SHA-512	alg Optional[IESG]  [RFC7518, Section 3.2]
                { "HS512", CryptoAlgorithmID.HMAC_SHA_2_512},

                //RS256   RSASSA-PKCS1-v1_5 using SHA-256	alg Recommended[IESG]  [RFC7518, Section 3.3]
                { "RS256", CryptoAlgorithmID.RSASign | CryptoAlgorithmID.SHA_2_256},
                //RS512   RSASSA-PKCS1-v1_5 using SHA-512	alg Optional[IESG]  [RFC7518, Section 3.3]
                { "RS512", CryptoAlgorithmID.RSASign | CryptoAlgorithmID.SHA_2_512},

                //RSA-OAEP RSAES OAEP using default parameters alg Recommended+	[IESG]
                { "RSA-OAEP", CryptoAlgorithmID.RSAExch},
                //RSA1_5  RSAES-PKCS1-v1_5 alg Recommended-	[IESG]
                { "RSA1_5", CryptoAlgorithmID.RSAExch_P15},

                //RSA-OAEP-256	RSAES OAEP using SHA-256 and MGF1 with SHA-256	alg Optional[IESG]  [RFC7518, Section 4.3]
                { "RSA-OAEP-256", CryptoAlgorithmID.RSAExch | CryptoAlgorithmID.SHA_2_256},
                //RSA-OAEP-256	RSAES OAEP using SHA-256 and MGF1 with SHA-256	alg Optional[IESG]  [RFC7518, Section 4.3]
                { "RSA-OAEP-512", CryptoAlgorithmID.RSAExch | CryptoAlgorithmID.SHA_2_512},


    
                //dir Direct use of a shared symmetric key alg Recommended[IESG][RFC7518, Section 4.5]
                { "dir", CryptoAlgorithmID.Direct},                            
                
                //A128KW  AES Key Wrap using 128-bit key  alg Recommended[IESG]  [RFC7518, Section 4.4]
                { "A128KW", CryptoAlgorithmID.KW3394_AES128},

                //A256KW  AES Key Wrap using 256-bit key  alg Recommended[IESG]  [RFC7518, Section 4.4]
                { "A256KW", CryptoAlgorithmID.KW3394_AES256},

                //A128GCMKW   Key wrapping with AES GCM using 128-bit key alg Optional[IESG]  [RFC7518, Section 4.7]
                { "A128GCMKW", CryptoAlgorithmID.AES128_GCM_KW},

                //A256GCMKW   Key wrapping with AES GCM using 256-bit key alg Optional[IESG]  [RFC7518, Section 4.7]
                { "A256GCMKW", CryptoAlgorithmID.AES256_GCM_KW},

                //A128CBC-HS256 AES_128_CBC_HMAC_SHA_256 authenticated encryption algorithm enc Required[IESG][RFC7518, Section 5.2.3] n/a
                { "A128CBC-HS256", CryptoAlgorithmID.AES128HMAC},
                //A256CBC-HS512 AES_256_CBC_HMAC_SHA_512 authenticated encryption algorithm enc Required[IESG][RFC7518, Section 5.2.5] n/a
                { "A256CBC-HS512", CryptoAlgorithmID.AES256HMAC},

                //A128GCM AES GCM using 128-bit key   enc Recommended[IESG]  [RFC7518, Section 5.3]
                { "A128GCM", CryptoAlgorithmID.AES128GCM},
                //A256GCM AES GCM using 256-bit key   enc Recommended[IESG]  [RFC7518, Section 5.3]
                { "A256GCM", CryptoAlgorithmID.AES256GCM},

                //EdDSA   EdDSA signature algorithms alg Optional[IESG]
                //  [RFC - ietf - jose - cfrg - curves - 06, Section 3.1][RFC - irtf - cfrg - eddsa - 08]
                { "EdDSA", CryptoAlgorithmID.EdDSA},



                ////RSA-OAEP-512	RSA-OAEP using SHA-512 and MGF1 with SHA-512	alg 
                ////Optional[W3C_Web_Cryptography_Working_Group]    [https://www.w3.org/TR/WebCryptoAPI]	n/a
                //{ "RSA-OAEP-512", CryptoAlgorithmID.RSAExch2048},

                //A128CBC AES CBC using 128 bit key   JWK Prohibited[W3C_Web_Cryptography_Working_Group]
                //[https://www.w3.org/TR/WebCryptoAPI]	[draft-irtf-cfrg-webcrypto-algorithms]
                { "A128CBC", CryptoAlgorithmID.AES128CBC},
                //A256CBC AES CBC using 256 bit key   JWK Prohibited[W3C_Web_Cryptography_Working_Group]    
                //[https://www.w3.org/TR/WebCryptoAPI]	[draft-irtf-cfrg-webcrypto-algorithms]
                { "A256CBC", CryptoAlgorithmID.AES256CBC},

                // Additional algorithms

                // Diffie Hellman using HKDF Key derrivation and RFC3394 Key Wrap
                { "DH", CryptoAlgorithmID.DH},
                { "ECDH", CryptoAlgorithmID.ECDH},

                // Special

                //none    No digital signature or MAC performed   alg Optional[IESG]  [RFC7518, Section 3.6]
                { "none", CryptoAlgorithmID.NULL}


                // Not supported
                //HS384   HMAC using SHA-384	alg Optional[IESG]  [RFC7518, Section 3.2]
                //RS384   RSASSA-PKCS1-v1_5 using SHA-384	alg Optional[IESG]  [RFC7518, Section 3.3]
                //A192KW  AES Key Wrap using 192-bit key  alg Optional[IESG]  [RFC7518, Section 4.4]
                //RSA-OAEP-384	RSA-OAEP using SHA-384 and MGF1 with SHA-384	alg Optional
                //  [W3C_Web_Cryptography_Working_Group]    [https://www.w3.org/TR/WebCryptoAPI]	n/a
                //A192GCM AES GCM using 192-bit key   enc Optional[IESG]  [RFC7518, Section 5.3]
                //A192GCMKW   Key wrapping with AES GCM using 192-bit key alg Optional[IESG]  [RFC7518, Section 4.7]
                //ECDH-ES ECDH-ES using Concat KDF alg Recommended+	[IESG] [RFC7518, Section 4.6]
                //ECDH-ES+A128KW ECDH-ES using Concat KDF and "A128KW" wrapping alg Recommended[IESG][RFC7518, Section 4.6]
                //ECDH-ES+A192KW ECDH-ES using Concat KDF and "A192KW" wrapping alg Optional[IESG][RFC7518, Section 4.6]
                //ECDH-ES+A256KW ECDH-ES using Concat KDF and "A256KW" wrapping alg Recommended[IESG][RFC7518, Section 4.6]
                //PBES2-HS256+A128KW PBES2 with HMAC SHA-256 and "A128KW" wrapping alg Optional[IESG][RFC7518, Section 4.8]
                //PBES2-HS384+A192KW PBES2 with HMAC SHA-384 and "A192KW" wrapping alg Optional[IESG][RFC7518, Section 4.8]
                //PBES2-HS512+A256KW PBES2 with HMAC SHA-512 and "A256KW" wrapping alg Optional[IESG][RFC7518, Section 4.8]
                //A192CBC-HS384 AES_192_CBC_HMAC_SHA_384 authenticated encryption algorithm enc Optional[IESG][RFC7518, Section 5.2.4]
                //A192CBC AES CBC using 192 bit key   JWK Prohibited[W3C_Web_Cryptography_Working_Group]    
                //  [https://www.w3.org/TR/WebCryptoAPI]	[draft-irtf-cfrg-webcrypto-algorithms]
                //ES256   ECDSA using P-256 and SHA-256	alg Recommended+	[IESG] [RFC7518, Section 3.4]
                //ES384   ECDSA using P-384 and SHA-384	alg Optional[IESG]  [RFC7518, Section 3.4]
                //ES512   ECDSA using P-521 and SHA-512	alg Optional[IESG]  [RFC7518, Section 3.4]
                //PS256   RSASSA-PSS using SHA-256 and MGF1 with SHA-256	alg Optional[IESG]  [RFC7518, Section 3.5]
                //PS384   RSASSA-PSS using SHA-384 and MGF1 with SHA-384	alg Optional[IESG]  [RFC7518, Section 3.5]
                //PS512   RSASSA-PSS using SHA-512 and MGF1 with SHA-512	alg Optional[IESG]  [RFC7518, Section 3.5]

            };

        /// <summary>
        /// Lookup Jose Name by identifier.
        /// </summary>
        public static readonly Dictionary<CryptoAlgorithmID, string> IdToString =
            new Dictionary<CryptoAlgorithmID, string>();


        //public static readonly Dictionary<string, CryptoAlgorithmClass> StringtoClass =
        //    new Dictionary<string, CryptoAlgorithmClass> {
        //        };

        //public static readonly Dictionary<CryptoAlgorithmClass, string> ClassToString =
        //    new Dictionary<CryptoAlgorithmClass, string> {
        //        };

        // This is called as a one time initializer
        static AlgorithmID() {

            foreach (var Entry in StringtoID) {
                //Debug.WriteLine(Entry.Value);
                IdToString.Add(Entry.Value, Entry.Key);
                }
            //foreach (var Entry in StringtoClass) {
            //    ClassToString.Add(Entry.Value, Entry.Key);
            //    }
            }

        /// <summary>
        /// Convert a JOSE name to an identifier.
        /// </summary>
        /// <param name="JoseID">Jose Name</param>
        /// <returns>Identifier</returns>
        public static CryptoAlgorithmID FromJoseID (this string JoseID) {
            if (JoseID == null) {
                return CryptoAlgorithmID.NULL;
                }

            var Found = StringtoID.TryGetValue(JoseID, out CryptoAlgorithmID Result);
            return Found ? Result : CryptoAlgorithmID.NULL;
            }


        /// <summary>
        /// Convert an identifier to a Jose name
        /// </summary>
        /// <param name="ID">Identifier</param>
        /// <returns>Jose Name</returns>
        public static string ToJoseID(this CryptoAlgorithmID ID) {
            var Found = IdToString.TryGetValue(ID, out var Result);
            return Found ? Result : null;
            }

        }
    }
