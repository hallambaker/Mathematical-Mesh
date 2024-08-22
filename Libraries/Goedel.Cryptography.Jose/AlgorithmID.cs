#region // Copyright - MIT License
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

using System.Xml.Serialization;

namespace Goedel.Cryptography.Jose;

/// <summary>
/// Constants and related methods for identifying cryptographic algorithms and suites.
/// </summary>
public static class AlgorithmID {

    /// <summary>
    /// Lookup  identifier by Jose name or commonly used alias
    /// </summary>
    public static readonly Dictionary<string, CryptoAlgorithmId> UpperToID =
        new() {
                { JoseConstants.AES, CryptoAlgorithmId.AES256 },
                { JoseConstants.AES128, CryptoAlgorithmId.AES128 },
                { JoseConstants.AES256, CryptoAlgorithmId.AES256 },

                { JoseConstants.SHA2, CryptoAlgorithmId.SHA_2_512 },
                { JoseConstants.SHA2_512, CryptoAlgorithmId.SHA_2_512 },
                { JoseConstants.SHA2_256, CryptoAlgorithmId.SHA_2_256 },

            //{"SHA128",  CryptoAlgorithmID.SHA_2_512T128 },
                { JoseConstants.SHA3, CryptoAlgorithmId.SHA_3_512 },
                { JoseConstants.SHA3_256, CryptoAlgorithmId.SHA_3_256 },
                { JoseConstants.SHA3_512, CryptoAlgorithmId.SHA_3_256 },

                { JoseConstants.X448, CryptoAlgorithmId.X448 },
                { JoseConstants.X25519, CryptoAlgorithmId.X25519 },
                { JoseConstants.Ed448.ToUpper(), CryptoAlgorithmId.Ed448 },
                { JoseConstants.Ed25519.ToUpper(), CryptoAlgorithmId.Ed25519 },

                { JoseConstants.MLKEM512, CryptoAlgorithmId.MLKEM512 },
                { JoseConstants.MLKEM768, CryptoAlgorithmId.MLKEM768 },
                { JoseConstants.MLKEM1024, CryptoAlgorithmId.MLKEM1024 },

                { JoseConstants.MLDSA44, CryptoAlgorithmId.MLDSA44 },
                { JoseConstants.MLDSA65, CryptoAlgorithmId.MLDSA65 },
                { JoseConstants.MLDSA87, CryptoAlgorithmId.MLDSA87 },

            //{"", CryptoAlgorithmID }
            };


    /// <summary>
    /// Lookup identifier by Jose name.
    /// </summary>
    public static readonly Dictionary<string, CryptoAlgorithmId> StringToID =
        new() {
            //SHA-256	alg (Private)
                { JoseConstants.SHA2_256, CryptoAlgorithmId.SHA_2_256 },
            //SHA-512	alg (Private)
                { JoseConstants.SHA2_512, CryptoAlgorithmId.SHA_2_512 },

            //HS256   HMAC using SHA-256	alg Required[IESG]  [RFC7518, Section 3.2]
                { "HS256", CryptoAlgorithmId.HMAC_SHA_2_256 },
            //HS512   HMAC using SHA-512	alg Optional[IESG]  [RFC7518, Section 3.2]
                { "HS512", CryptoAlgorithmId.HMAC_SHA_2_512 },

            //RS256   RSASSA-PKCS1-v1_5 using SHA-256	alg Recommended[IESG]  [RFC7518, Section 3.3]
                { "RS256", CryptoAlgorithmId.RSASign | CryptoAlgorithmId.SHA_2_256 },
            //RS512   RSASSA-PKCS1-v1_5 using SHA-512	alg Optional[IESG]  [RFC7518, Section 3.3]
                { "RS512", CryptoAlgorithmId.RSASign | CryptoAlgorithmId.SHA_2_512 },

            //RSA-OAEP RSAES OAEP using default parameters alg Recommended+	[IESG]
                { "RSA-OAEP", CryptoAlgorithmId.RSAExch },
            //RSA1_5  RSAES-PKCS1-v1_5 alg Recommended-	[IESG]
                { "RSA1_5", CryptoAlgorithmId.RSAExch_P15 },

            //RSA-OAEP-256	RSAES OAEP using SHA-256 and MGF1 with SHA-256	alg Optional[IESG]  [RFC7518, Section 4.3]
                { "RSA-OAEP-256", CryptoAlgorithmId.RSAExch | CryptoAlgorithmId.SHA_2_256 },
            //RSA-OAEP-256	RSAES OAEP using SHA-256 and MGF1 with SHA-256	alg Optional[IESG]  [RFC7518, Section 4.3]
                { "RSA-OAEP-512", CryptoAlgorithmId.RSAExch | CryptoAlgorithmId.SHA_2_512 },



            //dir Direct use of a shared symmetric key alg Recommended[IESG] [RFC7518, Section 4.5]
                { "dir", CryptoAlgorithmId.Direct },

            //A128KW  AES Key Wrap using 128-bit key  alg Recommended[IESG]  [RFC7518, Section 4.4]
                { "A128KW", CryptoAlgorithmId.KW3394_AES128 },

            //A256KW  AES Key Wrap using 256-bit key  alg Recommended[IESG]  [RFC7518, Section 4.4]
                { "A256KW", CryptoAlgorithmId.KW3394_AES256 },

            //A128GCMKW   Key wrapping with AES GCM using 128-bit key alg Optional[IESG]  [RFC7518, Section 4.7]
                { "A128GCMKW", CryptoAlgorithmId.AES128_GCM_KW },

            //A256GCMKW   Key wrapping with AES GCM using 256-bit key alg Optional[IESG]  [RFC7518, Section 4.7]
                { "A256GCMKW", CryptoAlgorithmId.AES256_GCM_KW },

            //A128CBC-HS256 AES_128_CBC_HMAC_SHA_256 authenticated encryption algorithm enc Required[IESG][RFC7518, Section 5.2.3] n/a
                { "A128CBC-HS256", CryptoAlgorithmId.AES128HMAC },
            //A256CBC-HS512 AES_256_CBC_HMAC_SHA_512 authenticated encryption algorithm enc Required[IESG][RFC7518, Section 5.2.5] n/a
                { "A256CBC-HS512", CryptoAlgorithmId.AES256HMAC },

            //A128GCM AES GCM using 128-bit key   enc Recommended[IESG]  [RFC7518, Section 5.3]
                { "A128GCM", CryptoAlgorithmId.AES128GCM },
            //A256GCM AES GCM using 256-bit key   enc Recommended[IESG]  [RFC7518, Section 5.3]
                { "A256GCM", CryptoAlgorithmId.AES256GCM },

            //EdDSA   EdDSA signature algorithms alg Optional[IESG]
            //  [RFC - ietf - jose - cfrg - curves - 06, Section 3.1][RFC - irtf - cfrg - eddsa - 08]
                { "EdDSA", CryptoAlgorithmId.EdDSA },



            ////RSA-OAEP-512	RSA-OAEP using SHA-512 and MGF1 with SHA-512	alg 
            ////Optional[W3C_Web_Cryptography_Working_Group]    [https://www.w3.org/TR/WebCryptoAPI]	n/a
            //{ "RSA-OAEP-512", CryptoAlgorithmID.RSAExch2048},

            //A128CBC AES CBC using 128 bit key   JWK Prohibited[W3C_Web_Cryptography_Working_Group]
            //[https://www.w3.org/TR/WebCryptoAPI]	[draft-irtf-cfrg-webcrypto-algorithms]
                { "A128CBC", CryptoAlgorithmId.AES128CBC },
            //A256CBC AES CBC using 256 bit key   JWK Prohibited[W3C_Web_Cryptography_Working_Group]    
            //[https://www.w3.org/TR/WebCryptoAPI]	[draft-irtf-cfrg-webcrypto-algorithms]
                { "A256CBC", CryptoAlgorithmId.AES256CBC },

            // Additional algorithms

            // Diffie Hellman using HKDF Key derrivation and RFC3394 Key Wrap
                { "DH", CryptoAlgorithmId.DH },
                { "ECDH", CryptoAlgorithmId.ECDH },

            // Special

            //none    No digital signature or MAC performed   alg Optional[IESG]  [RFC7518, Section 3.6]
                { "none", CryptoAlgorithmId.NULL }


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
    public static readonly Dictionary<CryptoAlgorithmId, string> IdToString =
        new();

    // This is called as a one time initializer
    static AlgorithmID() {
        foreach (var Entry in UpperToID) {
            IdToString.AddSafe(Entry.Value, Entry.Key);
            }
        foreach (var Entry in StringToID) {
            IdToString.AddSafe(Entry.Value, Entry.Key);
            UpperToID.AddSafe(Entry.Key.ToUpper(), Entry.Value);
            }
        }

    /// <summary>
    /// Convert a case sensitive JOSE name to an identifier.
    /// </summary>
    /// <param name="JoseID">Jose Name</param>
    /// <returns>Identifier</returns>
    public static CryptoAlgorithmId FromJoseID(this string JoseID) {
        if (JoseID == null) {
            return CryptoAlgorithmId.NULL;
            }

        var Found = StringToID.TryGetValue(JoseID, out CryptoAlgorithmId result);
        return Found ? result : CryptoAlgorithmId.NULL;
        }

    /// <summary>
    /// Convert a case sensitive JOSE name to an identifier.
    /// </summary>
    /// <param name="joseID">Jose Name</param>
    /// <param name="force">Force use of encryption if not specified.</param>
    /// <returns>Identifier</returns>
    public static CryptoAlgorithmId FromJoseIDEncryption(this string joseID, bool force = false) =>
        joseID switch {
            null => force ? CryptoID.DefaultEncryptionId : CryptoAlgorithmId.NULL,
            "" => force ? CryptoID.DefaultEncryptionId : CryptoAlgorithmId.NULL,
            "none" => force ? CryptoID.DefaultEncryptionId : CryptoAlgorithmId.NULL,
            "default" => CryptoID.DefaultEncryptionId,
            _ => FromJoseID(joseID)
            };

    /// <summary>
    /// Convert a case sensitive JOSE name to an identifier.
    /// </summary>
    /// <param name="joseID">Jose Name</param>
    /// <param name="force">Force use of digest if not specified.</param>
    /// <returns>Identifier</returns>
    public static CryptoAlgorithmId FromJoseIDDigest(this string joseID, bool force = false) =>
        joseID switch {
            null => force ? CryptoID.DefaultDigestId : CryptoAlgorithmId.NULL,
            "" => force ? CryptoID.DefaultDigestId : CryptoAlgorithmId.NULL,
            "none" => force ? CryptoID.DefaultDigestId : CryptoAlgorithmId.NULL,
            "default" => CryptoID.DefaultDigestId,
            _ => FromJoseID(joseID)
            };


    /// <summary>
    /// Convert a case insensitive algorithm name to an identifier.
    /// </summary>
    /// <param name="uncasedID">Jose Name</param>
    /// <param name="defaultID">Optional deafult algorithm to be returned if 
    /// <paramref name="uncasedID"/> is null.</param>
    /// <returns>Identifier</returns>
    public static CryptoAlgorithmId ToCryptoAlgorithmID(this string uncasedID,
                CryptoAlgorithmId defaultID = CryptoAlgorithmId.NULL) {
        if (uncasedID == null) {
            return defaultID;
            }

        var Found = UpperToID.TryGetValue(uncasedID.ToUpper(), out CryptoAlgorithmId result);
        return Found ? result : CryptoAlgorithmId.Unknown;
        }


    /// <summary>
    /// Convert an identifier to a Jose name
    /// </summary>
    /// <param name="ID">Identifier</param>
    /// <returns>Jose Name</returns>
    public static string ToJoseID(this CryptoAlgorithmId ID) {
        var Found = IdToString.TryGetValue(ID, out var Result);
        return Found ? Result : null;
        }

    /// <summary>
    /// Convert a JOSE Key uses string to a KeyUses enumeration.
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static KeyUses GetUses(this string tag) => tag switch {
        "enc" => KeyUses.Encrypt,
        "sig" => KeyUses.Sign,
        _ => KeyUses.Any,
        };

    }
