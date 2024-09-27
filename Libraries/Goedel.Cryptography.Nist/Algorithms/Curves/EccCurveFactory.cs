namespace Goedel.Cryptography.Nist;

/// <summary>
/// Factory class returning the parameters of a specified curve.
/// </summary>
public static class EccCurveFactory {


    #region PCurves


    /// <summary>
    /// Return a prime curve by the size of the byte encoding of the point.
    /// </summary>
    /// <param name="length">The length of the integer encoding in bytes.</param>
    /// <returns>The curve.</returns>
    /// <exception cref="CryptographicException">The encoding size is not supported.</exception>
    public static PrimeCurve GetCurve (int length) => length switch {
                // These are fized constants so use the constants as switch labels.
                32 => EccCurveFactory.P256,
                48 => EccCurveFactory.P384,
                66 => EccCurveFactory.P521,
                _ => throw new CryptographicException()
                };



    ///<summary>The NIST Curve P256.</summary> 
    public static PrimeCurve P256 => p256 ?? GetP256().CacheValue(out p256);
    static PrimeCurve p256;
    static PrimeCurve GetP256() =>
        new PrimeCurve(NistCurve.P256,
            LoadValue("ffffffff00000001000000000000000000000000ffffffffffffffffffffffff"),
            LoadValue("5ac635d8aa3a93e7b3ebbd55769886bc651d06b0cc53b0f63bce3c3e27d2604b"),
            new EccPoint(null,
                LoadValue("6b17d1f2e12c4247f8bce6e563a440f277037d812deb33a0f4a13945d898c296"),
                LoadValue("4fe342e2fe1a7f9b8ee7eb4a7c0f9e162bce33576b315ececbb6406837bf51f5")),
            LoadValue("ffffffff00000000ffffffffffffffffbce6faada7179e84f3b9cac2fc632551"),
            l: 352) {
            CryptoAlgorithmId = CryptoAlgorithmId.P256,
            JoseId = JoseConstants.P256,
            ByteEncoding=32
            };

    ///<summary>The NIST Curve P384.</summary> 
    public static PrimeCurve P384 => p384 ?? GetP256().CacheValue(out p384);
    static PrimeCurve p384;
    static PrimeCurve GetP384() =>
        new PrimeCurve(NistCurve.P384,
            LoadValue("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffeffffffff0000000000000000ffffffff"),
            LoadValue("b3312fa7e23ee7e4988e056be3f82d19181d9c6efe8141120314088f5013875ac656398d8a2ed19d2a85c8edd3ec2aef"),
            new EccPoint(null,
                LoadValue("aa87Ca22be8b05378eb1c71ef320ad746e1d3b628ba79b9859f741e082542a385502f25dbf55296c3a545e3872760ab7"),
                LoadValue("3617de4a96262c6f5d9e98bf9292dc29f8f41dbd289a147ce9da3113b5f0b8c00a60b1ce1d7e819d7a431d7c90ea0e5f")),
            LoadValue("ffffffffffffffffffffffffffffffffffffffffffffffffc7634d81f4372ddf581a0db248b0a77aecec196accc52973")) {
            CryptoAlgorithmId = CryptoAlgorithmId.P384,
            JoseId = JoseConstants.P384,
            ByteEncoding=48
            };
    ///<summary>The NIST Curve P521.</summary> 
    public static PrimeCurve P521 => p521 ?? GetP256().CacheValue(out p521);
    static PrimeCurve p521;

    static PrimeCurve GetP521() =>
    new PrimeCurve(NistCurve.P521,
            LoadValue("01ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"),
            LoadValue("0051953eb9618e1c9a1f929a21a0b68540eea2da725b99b315f3b8b489918ef109e156193951ec7e937b1652c0bd3bb1bf073573df883d2C34f1ef451fd46b503f00"),
            new EccPoint(null,
                LoadValue("00c6858e06b70404e9cd9e3ecb662395b4429c648139053fb521f828af606b4d3dbaa14b5e77efe75928fe1dc127a2ffa8de3348b3c1856a429bf97e7e31c2e5bd66"),
                LoadValue("011839296a789a3bc0045c8a5fb42c7d1bd998f54449579b446817afbd17273e662c97ee72995ef42640c550b9013fad0761353c7086a272c24088be94769fd16650")),
            LoadValue("01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffa51868783bf2f966b7fcc0148f709a5d03bb5c9b8899c47aebb6fb71e91386409")) {
        CryptoAlgorithmId = CryptoAlgorithmId.P521,
        ByteEncoding = 66
        };

    /// <summary>
    /// Return the curve identified by <paramref name="curve"/>.
    /// </summary>
    /// <param name="curve">The curve identifier.</param>
    /// <returns>The curve.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The curve is not known.</exception>
    public static IEccCurve GetCurve(NistCurve curve) =>
        curve switch {
            NistCurve.P256 => P256,
            NistCurve.P384 => P384,
            NistCurve.P521 => P521,
            _ => throw new ArgumentOutOfRangeException(nameof(curve)) };

    private static BigInteger LoadValue(string hex) {
        // Prepend a "0" if the string isn't valid hex (even number of characters)
        if (hex.Length % 2 != 0) {
            hex = "0" + hex;
            }

        return new BitString(hex).ToPositiveBigInteger();
        }

    #endregion
    }