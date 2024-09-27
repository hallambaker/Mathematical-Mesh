
//namespace Goedel.Cryptography.Nist;

//public static class KeyGenHelper {
//    public static int CalculateEstimatedSecurityStrength(int modulo) {
//        // a = 1/3
//        var a = (double)1 / 3;

//        // b = 2/3
//        var b = (double)2 / 3;

//        // t = l( l(2 ^ c) )
//        var t = BigInteger.Log((BigInteger)BigInteger.Log(BigInteger.Pow(2, modulo)));

//        // # if b < 1, then a^b == e (l(a) * b)
//        // m = e( l(t) * b )
//        var m = System.Math.Exp(System.Math.Log(t) * b);

//        // t = 64 / 9 * l(2 ^ c)
//        t = (double)64 / 9 * BigInteger.Log(BigInteger.Pow(2, modulo));

//        // n = e( l(t) * a )
//        var n = System.Math.Exp(System.Math.Log(t) * a);

//        // o = e( m * n )
//        var o = System.Math.Exp(m * n);

//        // p = l(o) / l(2)
//        return (int)(System.Math.Log(o) / System.Math.Log(2));
//        }

//    public static int GetEstimatedSecurityStrength(int modulo) {
//        /*
//            From: https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-57pt1r5.pdf

//            80        1024
//            112       2048
//            128       3072
//            192       7680
//            256       15360
//         */

//        return modulo switch {
//            >= 1024 and < 2048 => 80,
//            >= 2048 and < 3072 => 112,
//            >= 3072 and < 7680 => 128,
//            >= 7680 and < 15360 => 192,
//            15360 => 256,
//            _ => throw new ArgumentOutOfRangeException(nameof(modulo))
//            };
//        }


//    }

