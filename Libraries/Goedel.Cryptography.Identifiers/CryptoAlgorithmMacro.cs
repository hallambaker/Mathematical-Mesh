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


namespace Goedel.Cryptography;


/// <summary>
/// Extension methods to extract algorithm sub types
/// </summary>
public static class CryptoID {

    ///<summary>The default signature algorithm</summary>
    public static CryptoAlgorithmId DefaultSignatureId { get; set; } = CryptoAlgorithmId.Ed448;

    ///<summary>The default public encryption algorithm</summary>
    public static CryptoAlgorithmId DefaultExchangeId { get; set; } = CryptoAlgorithmId.X448;

    ///<summary>The default digest algorithm</summary>
    public static CryptoAlgorithmId DefaultEncryptionId { get; set; } = CryptoAlgorithmId.AES256CBC;

    ///<summary>The default digest algorithm</summary>
    public static CryptoAlgorithmId DefaultDigestId { get; set; } = CryptoAlgorithmId.SHA_2_512;

    ///<summary>The default digest algorithm</summary>
    public static CryptoAlgorithmId DefaultMACId { get; set; } = CryptoAlgorithmId.HMAC_SHA_2_512;


    /// <summary>
    /// Apply the default signature algorithm specified in <see cref="DefaultExchangeId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="CryptoID.DefaultExchangeId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId DefaultExchange(this CryptoAlgorithmId algorithmId) =>
        algorithmId == CryptoAlgorithmId.Default ? DefaultExchangeId : algorithmId;

    /// <summary>
    /// Apply the default signature algorithm specified in <see cref="DefaultSignatureId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="CryptoID.DefaultSignatureId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId DefaultSignature(this CryptoAlgorithmId algorithmId) =>
        algorithmId == CryptoAlgorithmId.Default ? DefaultSignatureId : algorithmId;


    /// <summary>
    /// Apply the default digest algorithm specified in <see cref="DefaultMACId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="DefaultMACId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId DefaultMac(this CryptoAlgorithmId algorithmId) =>
        algorithmId == CryptoAlgorithmId.Default ? DefaultEncryptionId : algorithmId;


    /// <summary>
    /// Apply the default digest algorithm specified in <see cref="DefaultEncryptionId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="DefaultEncryptionId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId DefaultEncryption(this CryptoAlgorithmId algorithmId) =>
        algorithmId == CryptoAlgorithmId.Default ? DefaultEncryptionId : algorithmId;


    /// <summary>
    /// Apply the default digest algorithm specified in <see cref="DefaultDigestId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="DefaultDigestId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId DefaultDigest(this CryptoAlgorithmId algorithmId) =>
        algorithmId == CryptoAlgorithmId.Default ? DefaultDigestId : algorithmId;

    /// <summary>
    /// Apply the default signature algorithm specified in <see cref="CryptoID.DefaultExchangeId"/> 
    /// if required.
    /// </summary>
    /// <param name="algorithmId">The algorithm identifier to be defaulted.</param>
    /// <returns>If <paramref name="algorithmId"/> is <see cref="CryptoAlgorithmId.Default"/>
    /// returns the value <see cref="CryptoID.DefaultExchangeId"/>, 
    /// otherwise returns <paramref name="algorithmId"/>.</returns>
    public static CryptoAlgorithmId ForceExchange(this CryptoAlgorithmId algorithmId) =>
        algorithmId switch {
            CryptoAlgorithmId.NULL => CryptoID.DefaultExchangeId,
            CryptoAlgorithmId.Default => CryptoID.DefaultExchangeId,
            _ => algorithmId
            };

    //algorithmID == CryptoAlgorithmId.Default ? CryptoID.DefaultExchangeId : algorithmID;


    /// <summary>
    /// Return the MAC algorithm from a possibly composite ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The digest algorithm</returns>
    static CryptoAlgorithmId ExtractMAC(this CryptoAlgorithmId id) => (id.Bulk()) switch {
        CryptoAlgorithmId.AES128HMAC => CryptoAlgorithmId.HMAC_SHA_2_256,
        CryptoAlgorithmId.AES256HMAC => CryptoAlgorithmId.HMAC_SHA_2_512,
        _ => id.Bulk(),
        };

    /// <summary>
    /// Return the encryption algorithm from a possibly composite ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The encryption algorithm</returns>
    static CryptoAlgorithmId ExtractEncryption(this CryptoAlgorithmId id) => (id.Bulk()) switch {
        CryptoAlgorithmId.AES128HMAC => CryptoAlgorithmId.AES128CBC,
        CryptoAlgorithmId.AES256HMAC => CryptoAlgorithmId.AES256CBC,
        _ => id.Bulk(),
        };

    internal static object Type(CryptoAlgorithmId bulk, int v) => throw new NotImplementedException();


    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Bulk(this CryptoAlgorithmId id) => id < 0 ? id : id & CryptoAlgorithmId.BulkMask;

    /// <summary>
    /// Get the Meta algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The meta component.</returns>
    public static CryptoAlgorithmId Meta(this CryptoAlgorithmId id) => id < 0 ? id : id & CryptoAlgorithmId.MetaMask;

    /// <summary>
    /// Set algorithm defaults
    /// </summary>
    /// <param name="id">The specified algorithm</param>
    /// <param name="bulkDefault">The default bulk algorithm to apply</param>
    /// <param name="metaDefault">The default meta algorithm to apply</param>
    /// <returns>The defaulted algorithm</returns>
    public static CryptoAlgorithmId Default(
                this CryptoAlgorithmId id,
                CryptoAlgorithmId bulkDefault = CryptoAlgorithmId.Default,
                CryptoAlgorithmId metaDefault = CryptoAlgorithmId.Default) {
        var Meta = id.Meta();
        var Bulk = id.Bulk();
        Meta = Meta == CryptoAlgorithmId.Default ? metaDefault : Meta;
        Bulk = Bulk == CryptoAlgorithmId.Default ? bulkDefault : Bulk;
        return Meta | Bulk;
        }

    /// <summary>
    /// Set algorithm defaults
    /// </summary>
    /// <param name="id">The specified algorithm</param>
    /// <param name="keyUses"></param>
    /// <param name="defaultEncrypt"></param>
    /// <param name="defaultSign"></param>
    /// <param name="defaultAny"></param>
    /// <returns></returns>
    public static CryptoAlgorithmId DefaultMeta(
        this CryptoAlgorithmId id,
        KeyUses keyUses = KeyUses.Any,
        CryptoAlgorithmId defaultEncrypt = CryptoAlgorithmId.Default,
        CryptoAlgorithmId defaultSign = CryptoAlgorithmId.Default,
        CryptoAlgorithmId defaultAny = CryptoAlgorithmId.Default) {

        if (id != CryptoAlgorithmId.Default) {
            return id;
            }

        return keyUses switch {
            KeyUses.Sign => defaultSign,
            KeyUses.Encrypt => defaultEncrypt,
            _ => defaultAny,
            };
        }


    /// <summary>
    /// Set algorithm defaults for key exchange / public algorithm.
    /// </summary>
    /// <param name="id">The specified algorithm</param>
    /// <param name="default">The default to apply</param>
    /// <returns>The defaulted algorithm</returns>
    public static CryptoAlgorithmId DefaultMeta(
                this CryptoAlgorithmId id,
                CryptoAlgorithmId @default = CryptoAlgorithmId.Default) {
        var DefaultedID = id.Meta();
        DefaultedID = DefaultedID == CryptoAlgorithmId.Default ?
            @default.Meta() : DefaultedID;


        var x = CryptoAlgorithmId.X25519.Meta();
        var y = CryptoAlgorithmId.X25519.Meta();

        return DefaultedID;
        }

    /// <summary>
    /// Set algorithm defaults for bulk algorithm
    /// </summary>
    /// <param name="id">The specified algorithm</param>
    /// <param name="default">The default to apply</param>
    /// <returns>The defaulted algorithm</returns>
    public static CryptoAlgorithmId DefaultBulk(
                this CryptoAlgorithmId id,
                CryptoAlgorithmId @default = CryptoAlgorithmId.Default) {
        var DefaultedID = id.Bulk();
        DefaultedID = DefaultedID == CryptoAlgorithmId.Default ?
                @default.Bulk() : DefaultedID;
        return DefaultedID;
        }


    /// <summary>
    /// Get the base part of an algorithm
    /// </summary>
    /// <param name="id">The identifier to process.</param>
    /// <returns>The base part.</returns>
    public static CryptoAlgorithmId Base(this CryptoAlgorithmId id) => id < 0 ? id : id & CryptoAlgorithmId.BaseMask;

    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Digest(this CryptoAlgorithmId id) {
        var Bulk = id.Bulk();
        return Bulk >= (CryptoAlgorithmId.Digest) & (Bulk <= CryptoAlgorithmId.MaxDigest) ?
            Bulk : CryptoAlgorithmId.Default;
        }


    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId MAC(this CryptoAlgorithmId id) {
        var Bulk = id.ExtractMAC();
        return Bulk >= (CryptoAlgorithmId.MAC) & (Bulk <= CryptoAlgorithmId.MaxMAC) ?
            Bulk : CryptoAlgorithmId.Default;
        }


    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Encryption(this CryptoAlgorithmId id) {
        var Bulk = id.ExtractEncryption();
        return Bulk >= (CryptoAlgorithmId.Encryption) & (Bulk <= CryptoAlgorithmId.MaxEncryption) ?
            Bulk : CryptoAlgorithmId.Default;
        }

    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Mode(this CryptoAlgorithmId id) {
        var Encryption = id.Encryption();
        return (Encryption > 0) ? Encryption & ((CryptoAlgorithmId)0x7) : Encryption;
        }


    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Signature(this CryptoAlgorithmId id) {
        var Meta = id.Meta();
        return Meta >= (CryptoAlgorithmId.Signature) & (Meta <= CryptoAlgorithmId.MaxSignature) ?
            Meta : CryptoAlgorithmId.Default;
        }

    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Exchange(this CryptoAlgorithmId id) {
        var Meta = id.Meta();
        return Meta >= (CryptoAlgorithmId.Exchange) & (Meta <= CryptoAlgorithmId.MaxExchange) ?
            Meta : CryptoAlgorithmId.Default;
        }

    /// <summary>
    /// Get the bulk algorithm
    /// </summary>
    /// <param name="id">Composite identifier</param>
    /// <returns>The bulk component.</returns>
    public static CryptoAlgorithmId Wrap(this CryptoAlgorithmId id) {
        var Meta = id.Meta();
        return Meta >= (CryptoAlgorithmId.Wrap) & (Meta <= CryptoAlgorithmId.MaxWrap) ?
            Meta : CryptoAlgorithmId.Default;
        }

    }
