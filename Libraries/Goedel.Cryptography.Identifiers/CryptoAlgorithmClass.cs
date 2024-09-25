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


using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Goedel.Cryptography;

/// <summary>
/// Extension classes related to key identifiers.
/// </summary>
public static partial class IdentifierExtensions {

    /// <summary>
    /// Return the conventional security component of <paramref name="assurance"/>
    /// </summary>
    /// <param name="assurance">The assurance level to parse.</param>
    /// <returns>The conventional assurance level.</returns>
    public static AssuranceLevel Conventional (this AssuranceLevel assurance) =>
        assurance & AssuranceLevel.ConventionalMask;

    /// <summary>
    /// Return the quantum security component of <paramref name="assurance"/>
    /// </summary>
    /// <param name="assurance">The assurance level to parse.</param>
    /// <returns>The quantum assurance level.</returns>
    public static AssuranceLevel Quantum(this AssuranceLevel assurance) =>
        assurance & AssuranceLevel.QuantumMask;

    /// <summary>
    /// Return the greater of the two assurance levels <paramref name="first"/> and
    /// <paramref name="second"/>.
    /// </summary>
    /// <param name="first">First item.</param>
    /// <param name="second">Second item.</param>
    /// <returns>The greater of the assurance levels.</returns>
    static AssuranceLevel MaxInner(this AssuranceLevel first, AssuranceLevel second) =>
        first > second ? first : second;

    /// <summary>
    /// Return the greater of the two assurance levels <paramref name="first"/> and
    /// <paramref name="second"/> after parsing the conventional and 
    /// quantum levels separately.
    /// </summary>
    /// <param name="first">First item.</param>
    /// <param name="second">Second item.</param>
    /// <returns>The greater of the assurance levels.</returns>

    public static AssuranceLevel Max(this AssuranceLevel first, AssuranceLevel second) =>
        first.Conventional().MaxInner(second.Conventional()) |
        first.Quantum().MaxInner(second.Quantum());


    /// <summary>
    /// Return the assurance level of <paramref name="bits"/> symmetric bits.
    /// </summary>
    /// <param name="bits">The number of symmetric key bits.</param>
    /// <returns>The assurance level.</returns>
    public static AssuranceLevel OfSymmetricKeyBits(this int bits) {
        if (bits < 80) {
            return AssuranceLevel.None;
            }
        if (bits < 128) {
            return AssuranceLevel.CC80;
            }
        if (bits < 160) {
            return AssuranceLevel.PQC1;
            }
        if (bits < 192) {
            return AssuranceLevel.PQC2;
            }
        if (bits < 256) {
            return AssuranceLevel.PQC3;
            }
        return AssuranceLevel.PQC5;
        }


    }


/// <summary>
/// Describes a cryptographic algorithm
/// </summary>
/// <param name="CryptoAlgorithmId">The algorithm identifier.</param>
/// <param name="Jose">Jose identifier.</param>
/// <param name="OID">The algorithm OID</param>
public record AlgorithmEntry(
                CryptoAlgorithmId CryptoAlgorithmId,
                string Jose = null,
                string OID = null) {
    }

/// <summary>
/// Describes a combination of cryptographic algorithms.
/// </summary>
/// <param name="CryptoAlgorithmId">The algorithm identifier of the combination.</param>
/// <param name="Jose">Jose identifier of the combination.</param>
/// <param name="OID">The algorithm OID</param>
public record AlgorithmCombination(
                CryptoAlgorithmId CryptoAlgorithmId,
                string Jose = null,
                string OID = null) : AlgorithmEntry (CryptoAlgorithmId, Jose, OID) {
    }

/// <summary>
/// Describes an algorithmic variant.
/// </summary>
/// <param name="KeySize">The nominal key size in units defined by the algorithm.</param>
/// <param name="AssuranceLevel">The assurance level.</param>
/// <param name="CryptoAlgorithmId">The algorithm identifier.</param>
/// <param name="Jose">Jose identifier.</param>
/// <param name="OID">The algorithm OID</param>
/// <param name="Parameter">Supplemental OID used to identify the curve. </param>
/// <param name="Suites">Suites combining this algorithm with a symmetric algorithm.</param>
public record AlgorithmVariant (
                int KeySize,
                AssuranceLevel AssuranceLevel,
                CryptoAlgorithmId CryptoAlgorithmId = CryptoAlgorithmId.Default,
                string Jose = null,
                string OID = null,
                string Parameter = null,
                AlgorithmCombination[] Suites = null) : AlgorithmEntry(CryptoAlgorithmId, Jose, OID) {
    }

/// <summary>
/// Profile describing a family of cryptographic algorithms with the same capabilities
/// and assurance quality (conventional or quantum).
/// </summary>
/// <param name="CryptoAlgorithmId">The base <see cref="CryptoAlgorithmId"/> for the family.</param>
/// <param name="Class">The functionality supported.</param>
/// <param name="Variants">Description of the variations of the algorithm from lowest to
/// <param name="Jose">Jose identifier.</param>
/// <param name="OID">The algorithm OID</param>
/// highest assurance level.</param>
public record CryptoAlgorithmProfile(
                CryptoAlgorithmId CryptoAlgorithmId,
                CryptoAlgorithmClass Class,
                AlgorithmVariant[] Variants,
                string Jose = null,
                string OID=null) : AlgorithmEntry(CryptoAlgorithmId, Jose, OID) {

    CryptoAlgorithmProfile[]? Cousins=null;

    ///<summary>AES in CBC mode</summary> 
    public static readonly CryptoAlgorithmProfile AesCBC = new(
            CryptoAlgorithmId.SHA_2_256, CryptoAlgorithmClass.Encryption, [
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.AES128CBC),
                    new(192, AssuranceLevel.PQC3, CryptoAlgorithmId.AES192CBC),
                    new(256, AssuranceLevel.PQC5, CryptoAlgorithmId.AES256CBC)
                ]
            );

    ///<summary>AES in GCM mode</summary> 
    public static readonly CryptoAlgorithmProfile AesGCM = new(
            CryptoAlgorithmId.SHA_2_256, CryptoAlgorithmClass.AEAD, [
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.AES128GCM),
                    new(192, AssuranceLevel.PQC3, CryptoAlgorithmId.AES192GCM),
                    new(256, AssuranceLevel.PQC5, CryptoAlgorithmId.AES256GCM)
                ]
            );

    ///<summary>AES in OCD mode</summary> 
    public static readonly CryptoAlgorithmProfile AesOCB = new(
            CryptoAlgorithmId.SHA_2_256, CryptoAlgorithmClass.AEAD, [
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.AES128OCB),
                    new(192, AssuranceLevel.PQC3, CryptoAlgorithmId.AES192OCB),
                    new(256, AssuranceLevel.PQC5, CryptoAlgorithmId.AES256OCB)
                ]
            );

    ///<summary>SHA 2 Digest</summary> 
    public static readonly CryptoAlgorithmProfile Sha2Hash = new(
                CryptoAlgorithmId.SHA_2_256, CryptoAlgorithmClass.Digest, [
                    new(256, AssuranceLevel.PQC1, CryptoAlgorithmId.SHA_2_256),
                    new(384, AssuranceLevel.PQC3, CryptoAlgorithmId.SHA_2_384),
                    new(512, AssuranceLevel.PQC5, CryptoAlgorithmId.SHA_2_512)
                    ]
                );

    ///<summary>SHA 3 Digest</summary> 
    public static readonly CryptoAlgorithmProfile Sha3Hash = new(
                CryptoAlgorithmId.SHA_3_256, CryptoAlgorithmClass.Digest, [
                    new(256, AssuranceLevel.PQC1, CryptoAlgorithmId.SHA_3_256),
                    new(384, AssuranceLevel.PQC3, CryptoAlgorithmId.SHA_3_384),
                    new(512, AssuranceLevel.PQC5, CryptoAlgorithmId.SHA_3_512)
                    ]
                );

    ///<summary>SHA 3 SHAKE function</summary> 
    public static readonly CryptoAlgorithmProfile Shake = new(
                CryptoAlgorithmId.SHAKE_128, CryptoAlgorithmClass.Shake, [
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.SHAKE_128),
                    new(256, AssuranceLevel.PQC5, CryptoAlgorithmId.SHAKE_256)
                ]
            );

    ///<summary>HMAC-SHA2</summary> 
    public static readonly CryptoAlgorithmProfile HmacSha2 = new(
                CryptoAlgorithmId.HMAC_SHA_2_256, CryptoAlgorithmClass.MAC, [
                    new(256, AssuranceLevel.PQC1, CryptoAlgorithmId.HMAC_SHA_2_256),
                    new(512, AssuranceLevel.PQC1, CryptoAlgorithmId.HMAC_SHA_2_512),
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.HMAC_SHA_2_512T128)
                    ]
                );

    ///<summary>HMAC-SHA3</summary> 
    public static readonly CryptoAlgorithmProfile HmacSha3 = new(
            CryptoAlgorithmId.HMAC_SHA_2_256, CryptoAlgorithmClass.MAC, [
                    new(256, AssuranceLevel.PQC1, CryptoAlgorithmId.HMAC_SHA_3_256),
                    new(512, AssuranceLevel.PQC1, CryptoAlgorithmId.HMAC_SHA_3_512)
                ]
            );

    ///<summary>KMAC</summary> 
    public static readonly CryptoAlgorithmProfile KMAC = new(
                CryptoAlgorithmId.KMAC_128, CryptoAlgorithmClass.MAC, [
                    new(128, AssuranceLevel.PQC1, CryptoAlgorithmId.KMAC_128),
                    new(256, AssuranceLevel.PQC1, CryptoAlgorithmId.KMAC_256)
                    ]
                );


    static readonly AlgorithmVariant[] RSAVariants = [                    
                new AlgorithmVariant(2048, AssuranceLevel.CC112, Jose:JoseConstants.RSA2048),
                new AlgorithmVariant(3072, AssuranceLevel.CC128, Jose:JoseConstants.RSA3072),
                new AlgorithmVariant(7680, AssuranceLevel.CC192, Jose:JoseConstants.RSA7680),
                new AlgorithmVariant(15360, AssuranceLevel.CC256, Jose:JoseConstants.RSA15360)
                ];

    ///<summary>RSA signature variants, these are abreviated as the necessary processing is handled 
    ///internally to the implementation and all we require is the assurance levels..</summary> 
    public static readonly CryptoAlgorithmProfile RsaSign = new (
                CryptoAlgorithmId.RSASign, 
                CryptoAlgorithmClass.SignHash | CryptoAlgorithmClass.Encryption, RSAVariants);

    ///<summary>RSA encryption variants, these are abreviated as the necessary processing is handled 
    ///internally to the implementation and all we require is the assurance levels..</summary> 
    public static readonly CryptoAlgorithmProfile RsaExchange = new(
                CryptoAlgorithmId.RSAExch,
                CryptoAlgorithmClass.SignHash | CryptoAlgorithmClass.Encryption, RSAVariants);

    ///<summary>Variants of ECDH key agreement.</summary> 
    public static readonly CryptoAlgorithmProfile ECDH = new(
                 CryptoAlgorithmId.EdDSA, CryptoAlgorithmClass.Encryption, [
                    new AlgorithmVariant(256, AssuranceLevel.CC128, Jose:JoseConstants.P256,
                            OID:"1.2.840.10045.2.1", Parameter:"1.2.840.10045.3.1.7"),
                    new AlgorithmVariant(372, AssuranceLevel.CC192, Jose:JoseConstants.P384,
                            OID:"1.2.840.10045.2.1", Parameter:"1.3.132.0.34"),
                    new AlgorithmVariant(521, AssuranceLevel.CC256, Jose:JoseConstants.P521,
                            OID:"1.2.840.10045.2.1", Parameter:"1.3.132.0.35"),
                    ]);

    ///<summary>Variants of ECDH key agreement.</summary> 
    public static readonly CryptoAlgorithmProfile XDH = new(
                 CryptoAlgorithmId.EdDSA, CryptoAlgorithmClass.Encryption, [
                    new AlgorithmVariant(255, AssuranceLevel.CC128, OID:"1.3.101.110",Jose:JoseConstants.X25519),
                    new AlgorithmVariant(448, AssuranceLevel.CC224, OID:"1.3.101.111",Jose:JoseConstants.X448)
                    ]);

    ///<summary>Variants of ECDSA signature over a manifest or the data itself.</summary> 
    public static readonly CryptoAlgorithmProfile ECDSA= new(
             CryptoAlgorithmId.EdDSA, CryptoAlgorithmClass.SignHash, [
                    new AlgorithmVariant(256, AssuranceLevel.CC128, Jose:JoseConstants.P256, Suites:[
                            new (CryptoAlgorithmId.SHA_2_256, "1,2,840,10045,4,3,2"),
                            new (CryptoAlgorithmId.SHA_3_256, "2.16.840.1.101.4.3.9")]),
                    new AlgorithmVariant(372, AssuranceLevel.CC192, Jose:JoseConstants.P384, Suites:[
                            new (CryptoAlgorithmId.SHA_2_384, "1,2,840,10045,4,3,3"),
                            new (CryptoAlgorithmId.SHA_3_384, "2.16.840.1.101.4.3.9")]),
                    new AlgorithmVariant(521, AssuranceLevel.CC256, Jose:JoseConstants.P521, Suites:[
                            new (CryptoAlgorithmId.SHA_2_512, "1,2,840,10045,4,3,4"),
                            new (CryptoAlgorithmId.SHA_3_512, "2.16.840.1.101.4.3.9")])
                    ]);

    ///<summary>Variants of ECDSA signature over a manifest or the data itself.</summary> 
    public static readonly CryptoAlgorithmProfile EdDSA = new(
             CryptoAlgorithmId.EdDSA, CryptoAlgorithmClass.SignHash, [
                    new AlgorithmVariant(255, AssuranceLevel.CC128, OID:"1 3 101 112", Jose:JoseConstants.Ed25519 ),
                    new AlgorithmVariant(448, AssuranceLevel.CC224, OID:"1 3 101 113",Jose:JoseConstants.Ed448)
                    ]);

    ///<summary>Variants of ML-KEM.</summary> 
    public static readonly CryptoAlgorithmProfile MLKEM = new(
                CryptoAlgorithmId.MLKEM1024, CryptoAlgorithmClass.Encryption, [
                    new AlgorithmVariant(512, AssuranceLevel.PQC1, 
                            CryptoAlgorithmId.MLKEM512, JoseConstants.MLKEM512, "2.16.840.1.101.4.4.1"),
                    new AlgorithmVariant(768, AssuranceLevel.PQC3,
                            CryptoAlgorithmId.MLKEM768, JoseConstants.MLKEM768, "2.16.840.1.101.4.4.2"),
                    new AlgorithmVariant(1024, AssuranceLevel.PQC5,
                            CryptoAlgorithmId.MLKEM1024, JoseConstants.MLKEM1024, "2.16.840.1.101.4.4.3"),
                    ]);

    ///<summary>Variants of ML-DSA over a manifest or the data itself.</summary> 
    public static readonly CryptoAlgorithmProfile MLDSA = new(
                CryptoAlgorithmId.MLDSA87, CryptoAlgorithmClass.SignManifest, [
                    new AlgorithmVariant(44, AssuranceLevel.PQC2,
                            CryptoAlgorithmId.MLDSA44, JoseConstants.MLDSA44, "2.16.840.1.101.4.3.17"),
                    new AlgorithmVariant(68, AssuranceLevel.PQC3,
                            CryptoAlgorithmId.MLDSA65, JoseConstants.MLDSA65, "2.16.840.1.101.4.3.18"),
                    new AlgorithmVariant(87, AssuranceLevel.PQC5,
                            CryptoAlgorithmId.MLDSA87, JoseConstants.MLDSA87, "2.16.840.1.101.4.3.19"),
                    ]);

    ///<summary>Variants of ML-DSA over a specified digest value and digest algorithm.</summary> 
    public static readonly CryptoAlgorithmProfile MLDSAhash = new(
                CryptoAlgorithmId.MLDSA87, CryptoAlgorithmClass.SignHash, [
                    new AlgorithmVariant(44, AssuranceLevel.PQC2,
                            CryptoAlgorithmId.MLDSA44hash, Suites: [
                                new (CryptoAlgorithmId.SHA_2_512, OID: "2.16.840.1.101.4.3.32")]),
                    new AlgorithmVariant(68, AssuranceLevel.PQC3,
                            CryptoAlgorithmId.MLDSA65hash, Suites: [
                                new (CryptoAlgorithmId.SHA_2_512, OID: "2.16.840.1.101.4.3.33")]),
                    new AlgorithmVariant(87, AssuranceLevel.PQC5,
                            CryptoAlgorithmId.MLDSA87hash, Suites: [
                                new (CryptoAlgorithmId.SHA_2_512, OID: "2.16.840.1.101.4.3.34")])
                    ]);

    ///<summary>Catalog of all algorithms collected into groups offering </summary> 
    public static readonly CryptoAlgorithmProfile[][] All = [
                    [Sha2Hash, HmacSha2],
                    [Sha3Hash, Shake, HmacSha3, KMAC],
                    [AesCBC, AesGCM, AesOCB],
                    [RsaSign, RsaExchange],
                    [ECDH, ECDSA],
                    [MLKEM, MLDSA, MLDSAhash]
                    ];

    ///<summary>Lookup algorithm by <see cref="CryptoAlgorithmId"/></summary> 
    public static Dictionary<CryptoAlgorithmId, AlgorithmEntry> AlgorithmIdToEntry { get; } = new();

    ///<summary>Lookup algorithm by JOSE Identifier.</summary> 
    public static Dictionary<string, AlgorithmEntry> JoseIdToEntry { get; } = new();

    ///<summary>Lookup algorithm by OID</summary> 
    public static Dictionary<string, AlgorithmEntry> OidIdToEntry { get; } = new();


    static CryptoAlgorithmProfile() {
        foreach (var group in All) {
            AddGroup(group);
            }
        }

    /// <summary>
    /// Add a group to the catalog.
    /// </summary>
    /// <param name="group">The group to add.</param>
    public static void AddGroup(CryptoAlgorithmProfile[] group) {
        var cousins = new CryptoAlgorithmProfile[group.Length];

        var i = 0;
        foreach (var profile in group) {
            cousins[i] = profile;
            profile.Cousins = cousins;
            AddProfile(profile);
            }
        }

    /// <summary>
    /// Add an algorithm profile to the catalog.
    /// </summary>
    /// <param name="profile">The profile to add.</param>
    public static void AddProfile(CryptoAlgorithmProfile profile) {

        foreach (var entry in profile.Variants) {
            AddVariant(profile, entry);
            }

        }

    /// <summary>
    /// Add a variant to the catalog.
    /// </summary>
    /// <param name="profile">The profile to add to.</param>
    /// <param name="variant">The variant to add.</param>
    public static void AddVariant(CryptoAlgorithmProfile profile, AlgorithmVariant variant) {
        }


    }




/// <summary>
/// Algorithm classes.
/// </summary>
[Flags]
public enum CryptoAlgorithmClass {

    /// <summary>Digest algorithm.</summary>
    Digest = 1,

    /// <summary>Digest algorithm.</summary>
    Shake = 2,

    /// <summary>Message Authentication Code</summary>
    MAC = 4,

    /// <summary>Symmetric Encryption.</summary>
    Encryption = 8,

    /// <summary>Symmetric Encryption.</summary>
    AEAD = 16,

    /// <summary>Asymmetric Encryption.</summary>
    Exchange = 32,

    /// <summary>Digital Signature</summary>
    SignHash = 64,

    /// <summary>Digital Signature</summary>
    SignManifest = 128,

    /// <summary>Unspecified.</summary>
    NULL
    }
