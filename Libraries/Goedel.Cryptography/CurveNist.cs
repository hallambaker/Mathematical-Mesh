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


using Goedel.ASN;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Nist;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography;

#region // Private Key
/// <summary>
/// Private key, a scalar strictly less than the curve order.
/// </summary>
public record CurveNistPrivate : IKeyAdvancedPrivate {

    #region // Properties
    ///<summary>The implementation private key value (if exportable)</summary>
    public BigInteger SecretKey { get; set; }

    ///<summary>The public key, a point on the curve.</summary> 
    public CurveNistPublic PublicKey { get; set; }

    ///<summary>Encoding of the secret key.</summary> 
    public byte[] EncodingSecretKey => Encode(SecretKey);

    ///<summary>The curve parameters.</summary> 
    public PrimeCurve Curve { get; set; }
    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor unpacking the key <paramref name="encoding"/> according to the curve
    /// <paramref name="curve"/>.
    /// </summary>
    /// <param name="encoding">The encoded scalar.</param>
    /// <param name="curve">The curve on which the point is located.</param>
    /// <param name="exportable">If true, allow the private key to be exported.</param>
    public CurveNistPrivate(byte[] encoding, PrimeCurve curve, bool exportable) :
                    this(curve, Decode(encoding), exportable) {
        }

    /// <summary>
    /// Constructor unpacking the key <paramref name="privateKey"/> according to the curve
    /// <paramref name="curve"/>.
    /// </summary>
    /// <param name="curve">The curve on which the point is located.</param>
    /// <param name="privateKey">The scalar.</param>
    /// <param name="exportable">If true, allow the private key to be exported.</param>
    public CurveNistPrivate(PrimeCurve curve, BigInteger? privateKey = null, bool exportable = false) {

        SecretKey = privateKey ?? Generate(curve);
        Curve = curve;
        var publicKey = curve.Multiply(curve.BasePointG, SecretKey);
        PublicKey = new CurveNistPublic(publicKey, curve);
        }

    static BigInteger Generate(PrimeCurve curve) {
        var n = Platform.GetRandomBits(curve.MinimumOutputSize);
        var d = 1 + n.ToBigInteger() % (curve.OrderN - 1);

        return d;
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
        var point = Agreement((keyPair as KeyPairECDHNist).PublicKey);

        return new CurveNistResult() {
            AgreementNist = point,
            Curve = Curve,
            EphemeralPublicValue = PublicKey
            };
        }

    /// <summary>
    /// Perform a key agreement operation on the point <paramref name="publicKey"/> using
    /// the secret scalar <see cref="SecretKey"/>.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public EccPoint Agreement(CurveNistPublic publicKey) =>
            Curve.Multiply(publicKey.PublicKey, SecretKey);

    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to a private key
    /// </summary>
    /// <param name="publicKey">Public key parameters</param>
    /// <param name="carry">Recryption carry over value, to be combined with the
    /// result of this key agreement.</param>
    /// <returns>The key agreement value ZZ</returns>
    public EccPoint Agreement(CurveNistPublic publicKey, CurveNistResult carry) {
        var result = Curve.Multiply(publicKey.PublicKey, SecretKey);
        return Curve.Add(result, carry.AgreementNist);
        }


    /// <summary>
    /// Create a new ephemeral private key and use it to perform a key
    /// agreement.
    /// </summary>
    /// <returns>The key agreement parameters, the public key value and the
    /// key agreement.</returns>
    public static CurveNistResult Agreement(EccPoint[] Carry) {
        Assert.AssertTrue(Carry.Length >= 1, InsufficientResults.Throw);

        var curve = Carry[0].Curve;

        var Total = curve.Add (Carry[0], Carry[1]);
        for (var i = 1; i < Carry.Length; i++) {

            Total = curve.Add(Total, Carry[i]);
            }

        return new CurveNistResult() {
            AgreementNist = Total,
            Curve = curve
            };
        }

    ///<inheritdoc/>
    public KeyPairAdvanced GetKeyPair(
                KeySecurity keySecurity = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) =>
        new KeyPairECDHNist(this, keySecurity, keyUses, cryptoAlgorithmID);


    ///<inheritdoc/>
    public IKeyAdvancedPrivate Combine(
                    IKeyAdvancedPrivate contribution, 
                    KeySecurity keySecurity = KeySecurity.Admin, 
                    KeyUses keyUses = KeyUses.Any) =>
                Combine(contribution as CurveNistPrivate, keySecurity, keyUses);

    /// <summary>
    /// Combine the two public keys to create a composite public key.
    /// </summary>
    /// <param name="contribution">The key contribution.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The allowed key uses.</param>
    /// <returns>The composite key</returns>
    public CurveNistPrivate Combine(CurveNistPrivate contribution,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {
        var newPrivate = (SecretKey + contribution.SecretKey) % Curve.FieldSizeQ;
        return new CurveNistPrivate(Curve, newPrivate, keySecurity.IsExportable());
        }

    ///<inheritdoc/>
    public IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> shares) {
        BigInteger accumulator = 0;

        foreach (var share in shares) {
            var key = share as KeyPairECDHNist;
            var privateKey = key.SecretKey;

            accumulator = (accumulator + privateKey.SecretKey).Mod(Curve.FieldSizeQ);
            }

        return new CurveNistPrivate(Curve,
            (Curve.FieldSizeQ + SecretKey - accumulator).Mod(Curve.FieldSizeQ), true) {
            };
        }


    ///<inheritdoc/>
    public IKeyAdvancedPrivate[] MakeThresholdKeySet(int shares) {
        BigInteger accumulator = 0;
        var result = new IKeyAdvancedPrivate[shares];

        for (var i = 1; i < shares; i++) {
            var newPrivate = Platform.GetRandomBigInteger(Curve.FieldSizeQ);
            result[i] = new CurveNistPrivate(Curve, newPrivate, exportable: true);
            accumulator = (accumulator + newPrivate).Mod(Curve.FieldSizeQ);
            }

        //Assert.True(Accumulator > 0 & Accumulator < Private, CryptographicException.Throw);

        result[0] = new CurveNistPrivate(Curve,
            (Curve.FieldSizeQ + SecretKey - accumulator).Mod(Curve.FieldSizeQ));
        return result;
        }
    }


#endregion
#region // Public Key

/// <summary>
/// An ECC public key, a point on one of the NIST curves.
/// </summary>
public record CurveNistPublic : IKeyAdvancedPublic {

    #region // Properties
    ///<summary>The implementation public key value</summary>
    public EccPoint PublicKey { get;  }

    ///<summary>The prime curve</summary> 
    public PrimeCurve Curve { get; }

    ///<inheritdoc/>
    public byte[] EncodingPublicKey => Encode(PublicKey);

    #endregion
    #region // Constructors




    /// <summary>
    /// Constructor, create an instance from the encoded point in <paramref name="encoding"/>
    /// on the curve <paramref name="curve"/>.
    /// </summary>
    /// <param name="encoding">The encoded point.</param>
    /// <param name="curve">The curve.</param>
    public CurveNistPublic(byte[] encoding, PrimeCurve curve) :
            this(Decode(encoding), curve) {
        }

    /// <summary>
    /// Constructor, create an instance from the point  in <paramref name="publicKey"/>
    /// on the curve <paramref name="curve"/>.
    /// </summary>
    /// <param name="publicKey">The encoded point.</param>
    /// <param name="curve">The curve.</param>
    public CurveNistPublic(EccPoint publicKey, PrimeCurve curve) {
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
        var length = encoding.Length / 2;
        (length >= 128).AssertTrue(CryptographicException.Throw);
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

        // These are fized constants so use the constants as switch labels.
        var curve = length switch {
            32 => EccCurveFactory.P256,
            48 => EccCurveFactory.P384,
            66 => EccCurveFactory.P521,
            _ => throw new NYI()
            };

        return new EccPoint(curve, x, y);
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
        var x = point.X.ToByteArrayLittleEndian(point.Curve.ByteEncoding);
        stream.Write(x); // X coordinate of the point
        var y = point.X.ToByteArrayLittleEndian(point.Curve.ByteEncoding);
        stream.Write(y); // Y coordinate of the point.
        return stream.ToArray();
        }

    ///<inheritdoc/>
    public IKeyAdvancedPublic Combine(IKeyAdvancedPublic contribution) {
        throw new NotImplementedException();
        }


    /// <summary>
    /// Create a new ephemeral private key and use it to perform a key
    /// agreement.
    /// </summary>
    /// <returns>The key agreement parameters, the public key value and the
    /// key agreement.</returns>
    public CurveNistResult Agreement() {
        var privateKey = new CurveNistPrivate(Curve);
        var point = privateKey.Agreement(this);

        return new CurveNistResult() {
            AgreementNist = point,
            Curve = Curve,
            EphemeralPublicValue = privateKey.PublicKey
            };
        }


    } 
#endregion
#region // Result on curve

/// <summary>
/// Represent the result of a Diffie Hellman Key exchange.
/// </summary>
public class CurveNistResult : ResultECDH {

    /// <summary>The key agreement result</summary>
    public EccPoint AgreementNist { get; init; }

    public PrimeCurve Curve { get; init; }


    ///<inheritdoc/>
    public override string CurveJose => Curve.JoseId;

    ///<inheritdoc/>
    public override byte[] DER() => CurveNistPublic.Encode(AgreementNist);

    ///<inheritdoc/>
    public override byte[] IKM => DER();

    /// <summary>
    /// The Ephemeral public key
    /// </summary>
    public override IAgreementData EphemeralKeyPair => new KeyPairECDHNist(EphemeralPoint);

    /// <summary>Carry from proxy recryption efforts</summary>
    public CurveEdwards25519 Carry { get; set; }

    /// <summary>Public key generated by ephemeral key generation.</summary>
    public CurveNistPublic EphemeralPoint => EphemeralPublicValue as CurveNistPublic;


    }
#endregion

