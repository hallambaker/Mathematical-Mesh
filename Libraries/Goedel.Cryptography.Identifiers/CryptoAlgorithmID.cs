﻿#region // Copyright - MIT License
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


namespace Goedel.Cryptography;

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


    /// <summary>Direct mapping (used for Pure signature)</summary>
    DIRECT = Digest + 0xff,

    /// <summary>SHA1 (Highly deprecated but often necessary)</summary>
    SHA_1_DEPRECATED = Digest + 1,

    /// <summary>SHA2 256 bit</summary>
    SHA_2_256 = Digest + 2,

    /// <summary>SHA2 512 bit</summary>
    SHA_2_384 = Digest + 3,

    /// <summary>SHA2 512 bit</summary>
    SHA_2_512 = Digest + 4,

    /// <summary>SHA2 512 bit</summary>
    SHA_2_512T128 = Digest + 5,

    /// <summary>SHA3 256 bit</summary>
    SHA_3_256 = Digest + 6,

    /// <summary>SHA3 256 bit</summary>
    SHA_3_384 = Digest + 7,
    /// <summary>SHA3 512 bit</summary>
    SHA_3_512 = Digest + 8,

    /// <summary>SHA3 512 bit</summary>
    SHAKE_128 = Digest + 9,

    /// <summary>SHA3 512 bit</summary>
    SHAKE_256 = Digest + 10,





    /// <summary>Flag for CBC mode with PKCS#7 padding</summary>
    ModeCBC = Bulk,

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
    
    /// <summary>Flag for OCB Mode</summary>
    ModeOCB = 7,



    /// <summary>AES 128 bit key</summary>
    AES128 = Encryption,

    /// <summary>AES 256 bit key</summary>
    AES192 = Encryption + 8,

    /// <summary>AES 256 bit key</summary>
    AES256 = Encryption + 16,

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

    /// <summary>AES 128 bit in CBC mode</summary>
    AES128OCB = AES128 + ModeOCB,


    /// <summary>AES 128 bit in CBC mode</summary>
    AES192CBC = AES192 + ModeCBC,

    /// <summary>AES 128 bit in CBC mode</summary>
    AES192GCM = AES192 + ModeGCM,

    /// <summary>AES 128 bit in CBC mode</summary>
    AES192OCB = AES192 + ModeOCB,


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

    /// <summary>AES 128 bit in CBC mode</summary>
    AES256OCB = AES256 + ModeOCB,

    // HMAC Modes

    /// <summary>HMAC SHA 2 with 256 bit key.</summary>
    HMAC_SHA_2_256 = 12,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    HMAC_SHA_2_512 = 13,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    HMAC_SHA_2_512T128 = 14,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    HMAC_SHA_3_256 = 15,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    HMAC_SHA_3_512 = 16,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    CMAC= 17,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    KMAC_128 = 18,

    /// <summary>HMAC SHA 2 with 512 bit key.</summary>
    KMAC_256 = 19,



    /// <summary>Flag for CBC mode</summary>
    Level_Any = Default,

    /// <summary>Flag for Cipher Text Stealing Mode</summary>
    Level_Low = Meta,

    /// <summary>Flag for Galois Counter Mode</summary>
    Level_High = Meta * 2,



    // Public Key Signature


    /// <summary>RSA Signature using PKCS#1.5 padding.</summary>
    RSASign = Signature,

    /// <summary>RSA Signature using PSS padding.</summary>
    RSASign_PSS = Signature + Meta,

    /// <summary>RSA Signature using PKCS#1.5 padding and SHA-2 256 digest</summary>
    RSASign_SHA_2_256 = RSASign | SHA_2_256,

    /// <summary>RSA Signature using PKCS#1.5 padding and SHA-2 512 digest</summary>
    RSASign_SHA_2_512 = RSASign | SHA_2_512,

    /// <summary>RSA Signature using PSS padding and SHA-2 256 digest</summary>
    RSASign_PSS_SHA_2_256 = RSASign_PSS | SHA_2_256,

    /// <summary>RSA Signature using PSS padding and SHA-2 512 digest</summary>
    RSASign_PSS_SHA_2_512 = RSASign_PSS | SHA_2_512,


    /// <summary>Elliptic Curve DSA with curve 25519x pure</summary>
    EdDSA = Signature + Meta * 2 ,

    /// <summary>Elliptic Curve DSA with curve 25519x pure</summary>
    Ed25519 = Signature + Meta * 3,

    ///// <summary>Elliptic Curve DSA with curve 25519x pure</summary>
    //Ed25519pure = Ed25519 + DIRECT,

    /// <summary>Elliptic Curve DSA with curve 25519x prehashed using SHA512</summary>
    Ed25519ph = Signature + Meta * 4,

    /// <summary>Elliptic Curve DSA with curve Ed448</summary>
    Ed448 = Signature + Meta * 5,

    ///// <summary>Elliptic Curve DSA with curve Ed448</summary>
    //Ed448pure = Ed448 + DIRECT,

    /// <summary>Elliptic Curve DSA with curve Ed448</summary>
    Ed448ph = Signature + Meta * 6,

    ///<summary>ML-DSA (Dilithium) 44 PURE</summary> 
    MLDSA44 = Signature + Meta * 7,

    ///<summary>ML-DSA (Dilithium) 44</summary> 
    MLDSA44hash = Signature + Meta * 8,

    ///<summary>ML-DSA (Dilithium) 65</summary> 
    MLDSA65 = Signature + Meta * 9,

    ///<summary>ML-DSA (Dilithium) 65</summary> 
    MLDSA65hash = Signature + Meta * 10,

    ///<summary>ML-DSA (Dilithium) 87</summary> 
    MLDSA87 = Signature + Meta * 11,

    ///<summary>ML-DSA (Dilithium) 87</summary> 
    MLDSA87hash = Signature + Meta * 12,

    ///<summary>NIST Curve P256</summary> 
    P256 = Signature + Meta * 13,

    ///<summary>NIST Curve P256</summary> 
    P384 = Signature + Meta * 14,

    ///<summary>NIST Curve P256</summary> 
    P521 = Signature + Meta * 15,


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

    /// <summary>ML-KEM with 512 bit key</summary>
    MLKEM512 = ECDH + Meta * 13,

    /// <summary>ML-KEM with 768 bit key</summary>
    MLKEM768 = ECDH + Meta * 14,

    /// <summary>ML-KEM with 1024 bit key</summary>
    MLKEM1024 = ECDH + Meta * 15,
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
