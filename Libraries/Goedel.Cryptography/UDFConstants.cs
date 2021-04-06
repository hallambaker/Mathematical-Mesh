
//  This file was automatically generated at 4/6/2021 7:24:07 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.698
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography {


    ///<summary>UDF type identifier codes</summary>
    public enum UdfTypeIdentifier {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Authenticator HMAC_SHA_2_512</summary>
        Authenticator_HMAC_SHA_2_512 = 0,
        ///<summary>Authenticator HMAC_SHA_3_512</summary>
        Authenticator_HMAC_SHA_3_512 = 1,
        ///<summary>Encryption HKDF_AES_512</summary>
        Encryption_HKDF_AES_512 = 32,
        ///<summary>EncryptionSignature HKDF_AES_512</summary>
        EncryptionSignature_HKDF_AES_512 = 33,
        ///<summary>Digest SHA_3_512</summary>
        Digest_SHA_3_512 = 80,
        ///<summary>Digest SHA_3_512 (20 bits compressed)</summary>
        Digest_SHA_3_512_20 = 81,
        ///<summary>Digest SHA_3_512 (30 bits compressed)</summary>
        Digest_SHA_3_512_30 = 82,
        ///<summary>Digest SHA_3_512 (40 bits compressed)</summary>
        Digest_SHA_3_512_40 = 83,
        ///<summary>Digest SHA_3_512 (50 bits compressed)</summary>
        Digest_SHA_3_512_50 = 84,
        ///<summary>Digest SHA_2_512</summary>
        Digest_SHA_2_512 = 96,
        ///<summary>Digest SHA_2_512 (20 bits compressed)</summary>
        Digest_SHA_2_512_20 = 97,
        ///<summary>Digest SHA_2_512 (30 bits compressed)</summary>
        Digest_SHA_2_512_30 = 98,
        ///<summary>Digest SHA_2_512 (40 bits compressed)</summary>
        Digest_SHA_2_512_40 = 99,
        ///<summary>Digest SHA_2_512 (50 bits compressed)</summary>
        Digest_SHA_2_512_50 = 100,
        ///<summary>Nonce Data</summary>
        Nonce = 104,
        ///<summary>OID distinguished sequence (DER encoded)</summary>
        OID = 112,
        ///<summary>Shamir Secret Share</summary>
        ShamirSecret = 144,
        ///<summary>Secret seed</summary>
        DerivedKey = 200        }

    ///<summary>UDF key derevation algorithm identifier codes</summary>
    public enum UdfAlgorithmIdentifier {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Seed MAY be used to generate keypairs for any algorithm</summary>
        Any = 0,
        ///<summary>X25519 keypair as described in RFC7748</summary>
        X25519 = 1,
        ///<summary>X448 keypair as described in RFC7748</summary>
        X448 = 2,
        ///<summary>Ed25519 keypair as described in RFC8032</summary>
        Ed25519 = 3,
        ///<summary>Ed448 keypair as described in RFC8032</summary>
        Ed448 = 4,
        ///<summary>NIST curve P-256</summary>
        P256 = 5,
        ///<summary>NIST curve P-384</summary>
        P384 = 6,
        ///<summary>NIST curve P-521</summary>
        P521 = 7,
        ///<summary>2048 bit RSA keypair</summary>
        RSA2048 = 8,
        ///<summary>3072 bit RSA keypair</summary>
        RSA3072 = 9,
        ///<summary>4096 bit RSA keypair</summary>
        RSA4096 = 10,
        ///<summary>Mesh device profile</summary>
        MeshProfileDevice = 256,
        ///<summary>Mesh device activation</summary>
        MeshActivationDevice = 257,
        ///<summary>Mesh account account</summary>
        MeshProfileAccount = 258,
        ///<summary>Mesh account activation</summary>
        MeshActivationAccount = 259,
        ///<summary>Mesh service profile</summary>
        MeshProfileService = 260,
        ///<summary>Mesh host activation</summary>
        MeshActivationService = 261        }

    ///<summary>Udf derrived key uses</summary>
    public enum DerivedKeyUdfDerrivedKeyUses {
        ///<summary>Undefined type</summary>
        Unknown = -1,
        ///<summary>Any</summary>
        Any = 0,
        ///<summary>Encryption</summary>
        Encryption = 1,
        ///<summary>Signature</summary>
        Signature = 2,
        ///<summary>Authentication</summary>
        Authentication = 3        }

    ///<summary>UDF type identifier codes</summary>
    public enum DerivedKeyRSATags {
        ///<summary>Undefined type</summary>
        Unknown = -1        }


    ///<summary>
    ///Constants specified in hallambaker-mesh-udf
    ///</summary>
    public static partial class UDFConstants {

        // File: TypeIdentifier



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static UdfTypeIdentifier ToUdfTypeIdentifier (this string text) =>
            text switch {
                _ => UdfTypeIdentifier.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this UdfTypeIdentifier data) =>
            data switch {
                _ => null
                };

        // File: AlgorithmIdentifier



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static UdfAlgorithmIdentifier ToUdfAlgorithmIdentifier (this string text) =>
            text switch {
                _ => UdfAlgorithmIdentifier.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this UdfAlgorithmIdentifier data) =>
            data switch {
                _ => null
                };

        // File: ContentTypeValues

        ///<summary>application/pkix-cert</summary>
        public const string PKIXCert = "PKIXCert";

        ///<summary>application/pkix-crl</summary>
        public const string PKIXCRL = "PKIXCRL";

        ///<summary>application/pkix-keyinfo</summary>
        public const string PKIXKey = "PKIXKey";

        ///<summary>application/pgp-keys</summary>
        public const string OpenPGPKey = "OpenPGPKey";

        ///<summary>application/dns</summary>
        public const string DNS = "DNS";

        ///<summary>application/udf-encryption</summary>
        public const string UDFEncryption = "UDFEncryption";

        ///<summary>application/udf-lock</summary>
        public const string UDFLock = "UDFLock";

        // File: KeyUses



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static DerivedKeyUdfDerrivedKeyUses ToDerivedKeyUdfDerrivedKeyUses (this string text) =>
            text switch {
                _ => DerivedKeyUdfDerrivedKeyUses.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this DerivedKeyUdfDerrivedKeyUses data) =>
            data switch {
                _ => null
                };

        // File: ECDHValuesCFRG

        // File: ECDHValuesNIST

        // File: RSATags



        /// <summary>
        /// Convert the string <paramref name="text"/> to the corresponding enumeration
        /// value.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The enumeration value.</returns>
        public static DerivedKeyRSATags ToDerivedKeyRSATags (this string text) =>
            text switch {
                _ => DerivedKeyRSATags.Unknown
                };

        /// <summary>
        /// Convert the enumerated value <paramref name="data"/> to the corresponding string
        /// value.
        /// </summary>
        /// <param name="data">The enumerated value.</param>
        /// <returns>The text value.</returns>
        public static string ToLabel (this DerivedKeyRSATags data) =>
            data switch {
                _ => null
                };

        // File: RSAValues

        // File: IANAValues

        }
    }
