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

#pragma warning disable CA1707

namespace Goedel.Cryptography {

    // Having realized that all crypto applications invariably end up with nested
    // systems of crypto algorithm marshalling code, here is yet another set of 
    // wrapper classes.

    /// <summary>
    /// <para>
    /// Numeric identifiers for Cryptographic Algorithms and suites. The identifier 
    /// space is divided up into bulk and key exchange identifiers as follows:</para>
    /// <para>0x00000000-0x0000FFFF: Bulk algorithms (digest, encryption, etc)</para>
    /// <para>0x00010000-0x7FFF0000: Asymmetric algorithms and Key Wrap.</para>
    /// </summary>
    public enum CryptoAlgorithmId {
        ///<summary>Unknown/unsupported</summary>
        Unknown = -2,

        ///<summary>Null algorithm</summary>
        NULL = -1,

        ///<summary>Default algorithm</summary>
        Default = 0,


        /// <summary>Multiplier for Bulk algorithms</summary>
        Bulk = 0x1,

        /// <summary>Mask for Bulk Algorithms</summary>
        BulkMask = 0xFFFF,

        /// <summary>Mask for Algorithm Type</summary>
        BulkTagMask = 0xFF00,

        /// <summary>Flag multiplier</summary>
        Digest = Bulk * 0x100,

        /// <summary>Flag multiplier</summary>
        MAC = Bulk * 0x200,

        /// <summary>Flag multiplier</summary>
        Encryption = Bulk * 0x300,

        /// <summary>Flag multiplier</summary>
        MaxDigest = Bulk * 0x1FF,

        /// <summary>Flag multiplier</summary>
        MaxMAC = Bulk * 0x2FF,

        /// <summary>Flag multiplier</summary>
        MaxEncryption = Bulk * 0x8FF,


        /// <summary>Extract the base algorithm version</summary>
        BaseMask = 0x7FF8FFF8,


        /// <summary>Multiplier for key management operations</summary>
        Meta = 0x10000,

        /// <summary>Mask for key management operations</summary>
        MetaMask = 0x7fff0000,

        /// <summary>Mask for Algorithm Type</summary>
        MetaTagMask = 0x7f000000,

        /// <summary>Index for signature operations</summary>
        Signature = Meta * 0x100,

        /// <summary>Index for key exchange operations</summary>
        Exchange = Meta * 0x200,

        /// <summary>Index for key wrap operations</summary>
        Wrap = Meta * 0x300,


        /// <summary>Max index for signature operations</summary>
        MaxSignature = Meta * 0x1FF,

        /// <summary>Max index for key exchange operations</summary>
        MaxExchange = Meta * 0x2FF,

        /// <summary>Max index for key wrap operations</summary>
        MaxWrap = Meta * 0x3FF,



        // Bulk algorithms

        /// <summary>SHA1 (Highly deprecated but often necessary)</summary>
        SHA_1_DEPRECATED = 1,

        /// <summary>SHA2 256 bit</summary>
        SHA_2_256 = Digest + 2,

        /// <summary>SHA2 512 bit</summary>
        SHA_2_512 = Digest + 3,

        /// <summary>SHA2 512 bit</summary>
        SHA_2_512T128 = Digest + 4,

        /// <summary>SHA3 256 bit</summary>
        SHA_3_256 = Digest + 5,

        /// <summary>SHA3 512 bit</summary>
        SHA_3_512 = Digest + 6,

        /// <summary>SHA3 512 bit</summary>
        SHAKE_128 = Digest + 7,

        /// <summary>SHA3 512 bit</summary>
        SHAKE_256 = Digest + 8,



        /// <summary>Flag for CBC mode with PKCS#7 padding</summary>
        ModeCBC = 1,

        /// <summary>Flag for Cipher Text Stealing Mode</summary>
        ModeCTS = 2,

        /// <summary>Flag for Galois Counter Mode</summary>
        ModeGCM = 3,

        /// <summary>Flag for HMAC SHA-2 Mode</summary>
        ModeHMAC = 4,

        /// <summary>Flag for CBC mode with no padding</summary>
        ModeCBCNone = 5,

        /// <summary>Flag for Electronic Code Book Mode</summary>
        ModeECB = 6,


        /// <summary>AES 128 bit key</summary>
        AES128 = Encryption,

        /// <summary>AES 256 bit key</summary>
        AES256 = Encryption + 8,


        /// <summary>AES 128 bit in CBC mode</summary>
        AES128CBC = AES128 + ModeCBC,

        /// <summary>AES 128 bit in GCM Mode</summary>
        AES128GCM = AES128 + ModeGCM,

        /// <summary>AES 128 bit in Cipher Text Stealing (CTS) mode</summary>
        AES128CTS = AES128 + ModeCTS,

        /// <summary>AES 128 bit with HMAC</summary>
        AES128HMAC = AES128 + ModeHMAC,

        /// <summary>AES 128 bit CBC mode with no padding</summary>
        AES128CBCNone = AES128 + ModeCBCNone,

        /// <summary>AES 128 bit ECB mode with zeros padding</summary>
        AES128ECB = AES128 + ModeECB,


        /// <summary>AES 256 bit in CBC mode</summary>
        AES256CBC = AES256 + ModeCBC,

        /// <summary>AES 256 bit in GCM mode</summary>
        AES256GCM = AES256 + ModeGCM,

        /// <summary>AES 256 bit in Cipher Text Stealing (CTS) mode</summary>
        AES256CTS = AES256 + ModeCTS,

        /// <summary>AES 256 Bit with HMAC</summary>
        AES256HMAC = AES256 + ModeHMAC,

        /// <summary>AES 256 bit CBC mode with no padding</summary>
        AES256CBCNone = AES256 + ModeCBCNone,

        /// <summary>AES 128 bit ECB mode with zeros padding</summary>
        AES256ECB = AES256 + ModeECB,


        // HMAC Modes

        /// <summary>HMAC SHA 2 with 256 bit key.</summary>
        HMAC_SHA_2_256 = 12,

        /// <summary>HMAC SHA 2 with 512 bit key.</summary>
        HMAC_SHA_2_512 = 13,

        /// <summary>HMAC SHA 2 with 512 bit key.</summary>
        HMAC_SHA_2_512T128 = 14,

        /// <summary>HMAC SHA 2 with 512 bit key.</summary>
        HMAC_SHA_3_512 = 15,



        /// <summary>Flag for CBC mode</summary>
        Level_Any = 0,

        /// <summary>Flag for Cipher Text Stealing Mode</summary>
        Level_Low = Meta * 1,

        /// <summary>Flag for Galois Counter Mode</summary>
        Level_High = Meta * 2,



        // Public Key Signature


        /// <summary>RSA Signature using PKCS#1.5 padding.</summary>
        RSASign = Signature,


        /// <summary>RSA Signature using PSS padding.</summary>
        RSASign_PSS = Signature + Meta,

        /// <summary>Elliptic Curve DSA with curve 25519x</summary>
        EdDSA = Signature + Meta * 8,

        /// <summary>Elliptic Curve DSA with curve 25519x</summary>
        Ed25519 = EdDSA,
        /// <summary>Elliptic Curve DSA with curve 25519x</summary>
        Ed25519ctx = Ed25519 + 1,
        /// <summary>Elliptic Curve DSA with curve 25519x</summary>
        Ed25519ph = Ed25519 + 2,

        /// <summary>Elliptic Curve DSA with curve Ed448</summary>
        Ed448 = EdDSA + Meta,
        /// <summary>Elliptic Curve DSA with curve Ed448</summary>
        Ed448ph = Ed448 + 1,

        ///<summary>Default signature algorithm for the Mesh</summary>
        MeshDefaultSign = Ed448,
        ///<summary>Default encryption algorithm for the Mesh (will change to X488)</summary>
        MeshDefaultEncrypt = Ed448,

        /// <summary>RSA Signature using PKCS#1.5 padding and SHA-2 256 digest</summary>
        RSASign_SHA_2_256 = RSASign | SHA_2_256,

        /// <summary>RSA Signature using PKCS#1.5 padding and SHA-2 512 digest</summary>
        RSASign_SHA_2_512 = RSASign | SHA_2_512,

        /// <summary>RSA Signature using PSS padding and SHA-2 256 digest</summary>
        RSASign_PSS_SHA_2_256 = RSASign_PSS | SHA_2_256,

        /// <summary>RSA Signature using PSS padding and SHA-2 512 digest</summary>
        RSASign_PSS_SHA_2_512 = RSASign_PSS | SHA_2_512,


        // Public Key Exchange

        /// <summary>RSA Encryption using OAEP padding.</summary>
        RSAExch = Exchange,

        /// <summary>RSA Encryption using PKCS#1.5 padding</summary>
        RSAExch_P15 = Exchange + Meta,

        ///<summary>Diffie Hellman 2048 bit</summary>
        DH = Exchange + Meta * 2,


        /// <summary>Elliptic Curve DH with curve P256</summary>
        ECDH = Exchange + Meta * 8,

        /// <summary>Elliptic Curve DH with curve X25519 (Montgomery)</summary>
        X25519 = ECDH + Meta * 9,

        /// <summary>Elliptic Curve DH with curve X448 (Montgomery)</summary>
        X448 = ECDH + Meta * 10,

        /// <summary>Elliptic Curve DH with curve Ed25519 (Edwards)</summary>
        XEd25519 = ECDH + Meta * 11,

        /// <summary>Elliptic Curve DH with curve Ed448 (Edwards)</summary>
        XEd448 = ECDH + Meta * 12,





        // Key Wrap

        ///<summary>Direct (no wrap)</summary>
        Direct = Wrap + Meta * 1,

        ///<summary>RFC 3394 / NIST with AES and 128 bit key</summary>
        KW3394_AES128 = Wrap + Meta * 2,

        ///<summary>RFC 3394 / NIST with AES and 192 bit key</summary>
        KW3394_AES256 = Wrap + Meta * 3,

        ///<summary>RFC 3394 / NIST with AES and 128 bit key</summary>
        AES128_GCM_KW = Wrap + Meta * 4,

        ///<summary>RFC 3394 / NIST with AES and 192 bit key</summary>
        AES256_GCM_KW = Wrap + Meta * 5,

        }

    ///<summary>Enumeration specifying whether the key is public or private and if private,
    ///the storage model.</summary>
    [Flags]
    public enum KeySecurity {

        ///<summary>Null Flags.</summary>
        Null = 0,

        ///<summary>Flag indicating that the private key has been persisted to the local machine</summary>
        Persisted = 0b0001,

        ///<summary>Flag indicating that the private key may be persisted to the local machine.</summary>
        Persistable = 0b0010,

        ///<summary>Flag indicating that the private key may be stored in an in-memory
        ///structure (e.g. key collection) but not persisted.</summary>
        Session = 0b0100,

        ///<summary>Flag indicating that the private key may be exported.</summary>
        Exportable = 0b01000,


        ///<summary>Private key that cannot be exported or persisted.</summary>
        Ephemeral = Null,

        ///<summary>Private key that is stored on the local machine and cannot be exported.</summary>
        Bound = Persistable,

        ///<summary>Flag indicating that the private key has been store and may be exported.</summary>
        ExportableStored = Persistable | Exportable,

        ///<summary>Key is public only.</summary>
        Public = 0b10000,

        /// <summary>
        /// Key is a Mesh master key and will be stored in a key container marked 
        /// as archivable and user protected. Master keys SHOULD be deleted after 
        /// being escrowed and recovery verified.
        /// </summary>
        Master = ExportableStored,

        /// <summary>
        /// Key is a Mesh administration key and will be  stored in a key container marked as non 
        /// exportable and user protected.
        /// </summary>
        Admin = Bound,

        /// <summary>
        /// Key is Mesh a device key and will be  stored in a key container bound to 
        /// the current machine that cannot be exported or archived.
        /// </summary>
        Device = Bound

        }


    /// <summary>
    /// Combined Key Uses. This is a conjunction of the JOSE and PKIX key uses.
    /// </summary>
    [Flags]
    public enum KeyUses {
        ///<summary>PKIX Sign</summary>
        DigitalSignature = 0x0001,       // EmailSignature | DataSignature | CodeSigning

        ///<summary>Jose Sign (alias for the PKIX bitmask)</summary>
        Sign = DigitalSignature,

        ///<summary>If clear, signatures may be repudiated</summary>
        NonRepudiation = 0x0002,       // Confirmation

        ///<summary>PKIX Encryption</summary>
        KeyEncipherment = 0x0004,       // EmailEncryption | DataEncryption

        ///<summary>Jose Encryption (alias for the PKIX bitmask)</summary>
        Encrypt = KeyAgreement,

        ///<summary>PKIX Flag, should not be used.</summary>
        DataEncipherment = 0x0008,       // Don't Use

        ///<summary>PKIX Key agreement (used for client, server authentication).</summary>
        KeyAgreement = 0x0010,       // ServerAuth | ClientAuth

        ///<summary>PKIX Sign certificates</summary>
        KeyCertSign = 0x0020,       // CA | Root

        /// <summary>
        /// Sign CRLs
        /// </summary>
        CRLSign = 0x0040,       // CRL

        /// <summary>
        /// Don't use
        /// </summary>
        EncipherOnly = 0x0080,       // Don't use

        /// <summary>
        /// Don't Use.
        /// </summary>
        DecipherOnly = 0x0100,        // Don't use

        ///<summary>Jose Sign or Encryption (alias for the PKIX bitmask)</summary>
        Any = Sign | Encrypt
        }

    /// <summary>
    /// Algorithm classes.
    /// </summary>
    [Flags]
    public enum CryptoAlgorithmClasses {

        /// <summary>Unspecified.</summary>
        NULL,

        /// <summary>Digest algorithm.</summary>
        Digest = 1,

        /// <summary>Message Authentication Code</summary>
        MAC = 2,

        /// <summary>Symmetric Encryption.</summary>
        Encryption = 4,

        /// <summary>Digital Signature</summary>
        Signature = 8,

        /// <summary>Asymmetric Encryption.</summary>
        Exchange = 16
        }


    }
