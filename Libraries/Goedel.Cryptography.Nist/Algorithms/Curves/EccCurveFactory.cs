namespace Goedel.Cryptography.Nist;

public class EccCurveFactory : IEccCurveFactory {
    public IEccCurve GetCurve(NistCurve curve) {
        switch (curve) {
            case NistCurve.P192:
            return new PrimeCurve(curve, p192P, p192B, new EccPoint(p192Gx, p192Gy), p192N);
            case NistCurve.P224:
            return new PrimeCurve(curve, p224P, p224B, new EccPoint(p224Gx, p224Gy), p224N);
            case NistCurve.P256:
            return new PrimeCurve(curve, p256P, p256B, new EccPoint(p256Gx, p256Gy), p256N);
            case NistCurve.P384:
            return new PrimeCurve(curve, p384P, p384B, new EccPoint(p384Gx, p384Gy), p384N);
            case NistCurve.P521:
            return new PrimeCurve(curve, p521P, p521B, new EccPoint(p521Gx, p521Gy), p521N);

            //case Curve.B163:
            //return new BinaryCurve(curve, b163F, b163A, b163B, new EccPoint(b163Gx, b163Gy), b163N, b163H, preComputedB163);
            //case Curve.B233:
            //return new BinaryCurve(curve, b233F, b233A, b233B, new EccPoint(b233Gx, b233Gy), b233N, b233H, preComputedB233);
            //case Curve.B283:
            //return new BinaryCurve(curve, b283F, b283A, b283B, new EccPoint(b283Gx, b283Gy), b283N, b283H, preComputedB283);
            //case Curve.B409:
            //return new BinaryCurve(curve, b409F, b409A, b409B, new EccPoint(b409Gx, b409Gy), b409N, b409H, preComputedB409);
            //case Curve.B571:
            //return new BinaryCurve(curve, b571F, b571A, b571B, new EccPoint(b571Gx, b571Gy), b571N, b571H, preComputedB571);

            //case Curve.K163:
            //return new BinaryCurve(curve, k163F, k163A, k163B, new EccPoint(k163Gx, k163Gy), k163N, k163H, preComputedK163);
            //case Curve.K233:
            //return new BinaryCurve(curve, k233F, k233A, k233B, new EccPoint(k233Gx, k233Gy), k233N, k233H, preComputedK233);
            //case Curve.K283:
            //return new BinaryCurve(curve, k283F, k283A, k283B, new EccPoint(k283Gx, k283Gy), k283N, k283H, preComputedK283);
            //case Curve.K409:
            //return new BinaryCurve(curve, k409F, k409A, k409B, new EccPoint(k409Gx, k409Gy), k409N, k409H, preComputedK409);
            //case Curve.K571:
            //return new BinaryCurve(curve, k571F, k571A, k571B, new EccPoint(k571Gx, k571Gy), k571N, k571H, preComputedK571);
            }

        throw new ArgumentOutOfRangeException(nameof(curve));
        }

    #region PCurves
    private readonly BigInteger p192P = LoadValue("fffffffffffffffffffffffffffffffeffffffffffffffff");
    private readonly BigInteger p192B = LoadValue("64210519e59c80e70fa7e9ab72243049feb8deecc146b9b1");
    private readonly BigInteger p192Gx = LoadValue("188da80eb03090f67cbf20eb43a18800f4ff0afd82ff1012");
    private readonly BigInteger p192Gy = LoadValue("07192b95ffc8da78631011ed6b24cdd573f977a11e794811");
    private readonly BigInteger p192N = LoadValue("ffffffffffffffffffffffff99def836146bc9b1b4d22831");

    private readonly BigInteger p224P = LoadValue("ffffffffffffffffffffffffffffffff000000000000000000000001");
    private readonly BigInteger p224B = LoadValue("b4050a850c04b3abf54132565044b0b7d7bfd8ba270b39432355ffb4");
    private readonly BigInteger p224Gx = LoadValue("b70e0cbd6bb4bf7f321390b94a03c1d356c21122343280d6115c1d21");
    private readonly BigInteger p224Gy = LoadValue("bd376388b5f723fb4c22dfe6cd4375a05a07476444d5819985007e34");
    private readonly BigInteger p224N = LoadValue("ffffffffffffffffffffffffffff16a2e0b8f03e13dd29455c5c2a3d");

    private readonly BigInteger p256P = LoadValue("ffffffff00000001000000000000000000000000ffffffffffffffffffffffff");
    private readonly BigInteger p256B = LoadValue("5ac635d8aa3a93e7b3ebbd55769886bc651d06b0cc53b0f63bce3c3e27d2604b");
    private readonly BigInteger p256Gx = LoadValue("6b17d1f2e12c4247f8bce6e563a440f277037d812deb33a0f4a13945d898c296");
    private readonly BigInteger p256Gy = LoadValue("4fe342e2fe1a7f9b8ee7eb4a7c0f9e162bce33576b315ececbb6406837bf51f5");
    private readonly BigInteger p256N = LoadValue("ffffffff00000000ffffffffffffffffbce6faada7179e84f3b9cac2fc632551");

    private readonly BigInteger p384P = LoadValue("fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffeffffffff0000000000000000ffffffff");
    private readonly BigInteger p384B = LoadValue("b3312fa7e23ee7e4988e056be3f82d19181d9c6efe8141120314088f5013875ac656398d8a2ed19d2a85c8edd3ec2aef");
    private readonly BigInteger p384Gx = LoadValue("aa87Ca22be8b05378eb1c71ef320ad746e1d3b628ba79b9859f741e082542a385502f25dbf55296c3a545e3872760ab7");
    private readonly BigInteger p384Gy = LoadValue("3617de4a96262c6f5d9e98bf9292dc29f8f41dbd289a147ce9da3113b5f0b8c00a60b1ce1d7e819d7a431d7c90ea0e5f");
    private readonly BigInteger p384N = LoadValue("ffffffffffffffffffffffffffffffffffffffffffffffffc7634d81f4372ddf581a0db248b0a77aecec196accc52973");

    private readonly BigInteger p521P = LoadValue("01ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
    private readonly BigInteger p521B = LoadValue("0051953eb9618e1c9a1f929a21a0b68540eea2da725b99b315f3b8b489918ef109e156193951ec7e937b1652c0bd3bb1bf073573df883d2C34f1ef451fd46b503f00");
    private readonly BigInteger p521Gx = LoadValue("00c6858e06b70404e9cd9e3ecb662395b4429c648139053fb521f828af606b4d3dbaa14b5e77efe75928fe1dc127a2ffa8de3348b3c1856a429bf97e7e31c2e5bd66");
    private readonly BigInteger p521Gy = LoadValue("011839296a789a3bc0045c8a5fb42c7d1bd998f54449579b446817afbd17273e662c97ee72995ef42640c550b9013fad0761353c7086a272c24088be94769fd16650");
    private readonly BigInteger p521N = LoadValue("01fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffa51868783bf2f966b7fcc0148f709a5d03bb5c9b8899c47aebb6fb71e91386409");
    #endregion PCurves


    private static BigInteger LoadValue(string hex) {
        // Prepend a "0" if the string isn't valid hex (even number of characters)
        if (hex.Length % 2 != 0) {
            hex = "0" + hex;
            }

        return new BitString(hex).ToPositiveBigInteger();
        }
    }