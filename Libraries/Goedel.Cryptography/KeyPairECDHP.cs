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


using Goedel.Cryptography.Nist;

using System.Text;

namespace Goedel.Cryptography;




/// <summary>
/// Private key, a scalar strictly less than the curve order.
/// </summary>
public record CurveNistPrivate : IKeyAdvancedPrivate {

    #region // Properties
    ///<summary>The implementation private key value (if exportable)</summary>
    public BigInteger Private { get; set; }

    ///<summary>The public key, a point on the curve.</summary> 
    public CurveNistPublic PublicKey { get; set; }

    IEccCurve Curve { get; set; }
    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor unpacking the key <paramref name="encoding"/> according to the curve
    /// <paramref name="curve"/>.
    /// </summary>
    /// <param name="encoding">The encoded scalar.</param>
    /// <param name="curve">The curve on which the point is located.</param>
    /// <param name="exportable">If true, allow the private key to be exported.</param>
    public CurveNistPrivate(byte[] encoding, IEccCurve curve, bool exportable) :
                    this(Decode(encoding), curve, exportable) {
        }

    /// <summary>
    /// Constructor unpacking the key <paramref name="privateKey"/> according to the curve
    /// <paramref name="curve"/>.
    /// </summary>
    /// <param name="privateKey">The scalar.</param>
    /// <param name="curve">The curve on which the point is located.</param>
    /// <param name="exportable">If true, allow the private key to be exported.</param>
    public CurveNistPrivate(BigInteger privateKey, IEccCurve curve, bool exportable) {

        //// Verify that the keysize matches the curve size.
        //var keylen = privateKey.CountBits();

        //(privateKey.CountBits() == curve.KeySize).AssertTrue(CryptographicException.Throw);

        Private = privateKey;
        Curve = curve;
        var publicKey = curve.Multiply(curve.BasePointG, privateKey);
        PublicKey = new CurveNistPublic(publicKey, curve);
        }

    #endregion
    #region // Encode/Decode

    /// <summary>
    /// Decode the encoded scalar <paramref name="encoding"/>.
    /// </summary>
    /// <param name="encoding">The encoded scalar</param>
    /// <returns>The scalar</returns>
    public static BigInteger Decode(byte[] encoding) =>
                encoding.BigIntegerBigEndian();

    /// <summary>
    /// Encode the scalar <paramref name="privateKey"/>.
    /// </summary>
    /// <param name="privateKey">The private key to encode.</param>
    /// <returns>The encoded scalar.</returns>
    public static byte[] Encode(BigInteger privateKey) =>
                privateKey.ToByteArrayBigEndian();
    #endregion

    ///<inheritdoc/>
    public KeyAgreementResult Agreement(KeyPair keyPair) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution, KeySecurity keySecurity = KeySecurity.Admin, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> shares) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public KeyPairAdvanced GetKeyPair(KeySecurity keySecurity = KeySecurity.Public, KeyUses keyUses = KeyUses.Any, CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public ShamirSharePrivate[] MakeThresholdKeySet(int shares, int threshold) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public IKeyAdvancedPrivate[] MakeThresholdKeySet(int shares) {
        throw new NotImplementedException();
        }
    }

/// <summary>
/// An ECC public key, a point on one of the NIST curves.
/// </summary>
public record CurveNistPublic : IKeyAdvancedPublic {

    #region // Properties
    ///<summary>The implementation public key value</summary>
    public EccPoint PublicKey { get; set; }

    IEccCurve Curve { get; set; }

    ///<inheritdoc/>
    public byte[] Encoding => Encode(PublicKey);

    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor, create an instance from the encoded point in <paramref name="encoding"/>
    /// on the curve <paramref name="curve"/>.
    /// </summary>
    /// <param name="encoding">The encoded point.</param>
    /// <param name="curve">The curve.</param>
    public CurveNistPublic(byte[] encoding, IEccCurve curve) :
            this(Decode(encoding), curve) {
        }

    /// <summary>
    /// Constructor, create an instance from the point  in <paramref name="publicKey"/>
    /// on the curve <paramref name="curve"/>.
    /// </summary>
    /// <param name="publicKey">The encoded point.</param>
    /// <param name="curve">The curve.</param>
    public CurveNistPublic(EccPoint publicKey, IEccCurve curve) {
        // check that the point is on the curve and throw an exception if not.
        curve.PointExistsOnCurve(publicKey).AssertTrue(CryptographicException.Throw);

        PublicKey = publicKey;
        Curve = curve;
        }
    #endregion

    /// <summary>
    /// Encode the point encoded in the byte stream <paramref name="encoding"/>
    /// according to the uncompressed encoding 
    /// specified in https://www.secg.org/sec1-v2.pdf 
    /// </summary>
    /// <param name="encoding">The data to decode.</param>
    /// <returns>The decoded point.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static EccPoint Decode(byte[] encoding) {
        var length = encoding.Length/2;
        (length>=128).AssertTrue(CryptographicException.Throw);
        var buf = new byte[length];

        using var stream = new MemoryStream(encoding);
        var flag = stream.ReadByte();
        flag.AssertEqual(4, CryptographicException.Throw);

        var l = stream.Read(buf);
        (l == length).AssertTrue(CryptographicException.Throw);
        var x = buf.BigIntegerBigEndian();

        l = stream.Read(buf);
        (l == length).AssertTrue(CryptographicException.Throw);
        var y = buf.BigIntegerBigEndian();

        return new EccPoint(x, y);
        }

    /// <summary>
    /// Encode the point <paramref name="point"/> the uncompressed encoding 
    /// specified in https://www.secg.org/sec1-v2.pdf 
    /// </summary>
    /// <param name="point">The point to encode.</param>
    /// <returns>The encoded point.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static byte[] Encode(EccPoint point) {
        using var stream = new MemoryStream();
        stream.WriteByte(0x04); //
        var x = point.X.ToByteArrayLittleEndian();
        stream.Write(x); // X coordinate of the point
        var y = point.X.ToByteArrayLittleEndian();
        stream.Write(y); // Y coordinate of the point.
        return stream.ToArray();
        }

    ///<inheritdoc/>
    public IKeyAdvancedPublic Combine(IKeyAdvancedPublic contribution) {
        throw new NotImplementedException();
        }

    }



/// <summary>
/// NIST P256/P384/P521 Elliptic Curve Key Pair
/// </summary>
public class KeyPairECDHP : KeyPairECDH {

    #region //Properties

    ///<inheritdoc/>
    public override AssuranceLevel AssuranceLevel => throw new NotImplementedException();


    ///<summary>The implementation public key value</summary>
    public CurveNistPublic PublicKey { get; set; }

    ///<summary>The implementation private key value (if exportable)</summary>
    public CurveNistPrivate PrivateKey { get; set; }

    ///<inheritdoc/>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

    ///<inheritdoc/>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

    ///<inheritdoc/>
    public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

    ///<inheritdoc/>
    public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = KeyUses.Any;

    ///<inheritdoc/>
    public override bool PublicOnly => PrivateKey == null;

    ///<inheritdoc/>
    public override byte[] PublicData => PublicKey.Encoding;

    //readonly KeySecurity KeyType = KeySecurity.Public;
    readonly byte[] EncodedPrivateKey = null;


    /*
subjectPublicKeyInfo SubjectPublicKeyInfo SEQUENCE (2 elem)
    algorithm AlgorithmIdentifier SEQUENCE (2 elem)
        algorithm OBJECT IDENTIFIER 1.2.840.10045.2.1 ecPublicKey (ANSI X9.62 public key type)
        parameters ANY OBJECT IDENTIFIER 1.2.840.10045.3.1.7 prime256v1 (ANSI X9.62 named elliptic curve)Offset: 296
            Length: 2+8
            Value: 1.2.840.10045.3.1.7 prime256v1 ANSI X9.62 named elliptic curve
        subjectPublicKey BIT STRING (520 bit) 0000010010100100000001001110101111110101111011111000111111000100101001…

     30 59      SEQUENCE
        30 13       SEQUENCE
            06 07 2A 86 48 CE 3D 02 01  OBJECT IDENTIFIER ecPublicKey 1.2.840.10045.2.1
            06 08 2A 86 48 CE 3D 03 01 07 OBJECT IDENTIFIER prime256v1 1.2.840.10045.3.1.7
        03 42 BIT STRING (520 bit)
            00 04 A4 04  EB F5 EF 8F C4 A5 3A 71
            31 FF 98 A0 EB 81 B6 2E  F5 A5 0C E3 18 20 91 58
            05 F4 A3 5B EA 36 4D A5  A2 93 0D 10 BD B3 E5 63
            16 38 40 35 11 90 1A DD  12 33 0B 77 62 F1 D2 D8
            EE 82 71 E8 B3 6F
     */



    #endregion

    /// <summary>
    /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
    /// format. 
    /// </summary>
    /// <param name="key">The key data as specified in RFC8032.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairECDHP(
                byte[] key,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.P521) {
        
        CryptoAlgorithmId = cryptoAlgorithmID;
        var (keySize, curve) = cryptoAlgorithmID switch {
            CryptoAlgorithmId.P256 => (256, EccCurveFactory.P256),
            CryptoAlgorithmId.P384 => (384, EccCurveFactory.P384),
            CryptoAlgorithmId.P521 => (521, EccCurveFactory.P521),
            _ => throw new CryptographicException()
            };

        KeySecurity = keyType;
        KeyUses = keyUses;

        if (keyType == KeySecurity.Public) {
            PublicKey = new CurveNistPublic(key, curve);
            PKIXPublicKeyECDH = new PKIXPublicKeyECDH(cryptoAlgorithmID, PublicKey.Encoding);
            KeySecurity = KeySecurity.Public;
            }
        else {
            EncodedPrivateKey = key;
            var exportable = keyType.IsExportable();
            PrivateKey = new CurveNistPrivate(key, curve, exportable);
            PublicKey = PrivateKey.PublicKey;
            PKIXPublicKeyECDH = new PKIXPublicKeyECDH(cryptoAlgorithmID, PublicKey.Encoding);
            if (exportable) {
                PKIXPrivateKeyECDH = new PKIXPrivateKeyECDH(cryptoAlgorithmID, key);
                }
            }

        }


    ///<inheritdoc/>
    public override byte[] Decrypt(
                byte[] encryptedKey,
                IAgreementData ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null, byte[] salt = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override void Encrypt(
                byte[] key,
                out byte[] exchange,
                out IAgreementData ephemeral,
                byte[] salt = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey, KeySecurity keySecurity = KeySecurity.Admin, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override byte[] SignDigest(byte[] digest, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override bool VerifyDigest(byte[] digest, byte[] signature, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        throw new NotImplementedException();
        }
    }
