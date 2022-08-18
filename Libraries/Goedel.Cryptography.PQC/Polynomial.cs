using System;
using System.Collections.Generic;

namespace Goedel.Cryptography.PQC;



public struct Polynomial {

    ///<summary>The Kyber modulus.</summary> 
    public const int q = Kyber.Q;

    /// <summary>
    /// The coefficient vector.
    /// </summary>
    public short[] Coefficients;



    /// <summary>
    /// Constructor, create a Kyber coefficient vector of length <see cref="Kyber.N"/>.
    /// </summary>
    public Polynomial() {
        Coefficients = new short[Kyber.N];
        }




    /// <summary>
    /// Run rejection sampling on uniform random bytes to generate
    /// uniform random integers mod q
    /// </summary>
    /// <param name="buffer">Input buffer.</param>
    /// <param name="buflen">Length of input buffer to sample from.</param>
    /// <param name="ctr">starting index to sample to.</param>
    /// <returns></returns>
    public uint RejUniform(byte[] buffer, int buflen, uint ctr = 0) {

        uint pos = 0;

        short val0, val1;

        while (ctr < Kyber.N && pos + 3 <= buflen) {
            val0 = (short)(((buffer[pos + 0] >> 0) | ((short)buffer[pos + 1] << 8)) & 0xFFF);
            val1 = (short)(((buffer[pos + 1] >> 4) | ((short)buffer[pos + 2] << 4)) & 0xFFF);
            pos += 3;

            if (val0 < Kyber.Q) {
                Coefficients[ctr++] = val0;
                }
            if (ctr < Kyber.N && val1 < Kyber.Q)
                Coefficients[ctr++] = val1;

            }

        return ctr;

        }


    /// <summary>
    /// Given an array of uniformly random bytes, compute
    /// polynomial with coefficients distributed according to
    /// a centered binomial distribution with parameter eta=2.
    /// </summary>
    /// <param name="input">input byte array</param>
    /// <returns>output polynomial</returns>
    public static Polynomial CBD2(byte[] input) {
        (input.Length == (2 * Kyber.N) / 4).AssertTrue(NYI.Throw);
        var result = new Polynomial();

        for (var i = 0; i < Kyber.N/8; i++) {
            var t = input.LittleEndian32(4 * i);
            uint d = (t & 0x55555555);
            d += ((t >> 1) & 0x55555555);

            for (var j = 0; j < 8; j++) {
                var a = (short)((d >> (4 * j + 0)) & 0x3);
                var b = (short)((d >> (4 * j + 2)) & 0x3);
                result.Coefficients[8 * i + j] = (short)(a - b);
                }
            }

        return result;
        }

    /// <summary>
    /// Given an array of uniformly random bytes, compute
    /// polynomial with coefficients distributed according to
    /// a centered binomial distribution with parameter eta=3.
    /// This function is only needed for Kyber-512
    /// </summary>
    /// <param name="input">input byte array</param>
    /// <returns>output polynomial</returns>
    public static Polynomial CBD3(byte[] input) {
        (input.Length == (3 * Kyber.N) / 4).AssertTrue(NYI.Throw);
        var result = new Polynomial();

        for (var i = 0; i < Kyber.N/4; i++) {
            var t = input.LittleEndian24(3 * i);
            var d = (short)(t & 0x00249249);
            d += (short)((t >> 1) & 0x00249249);
            d += (short)((t >> 2) & 0x00249249);

            for (var j = 0; j < 8; j++) {
                var a = (short)((d >> (6 * j + 0)) & 0x7);
                var b = (short)((d >> (6 * j + 3)) & 0x7);
                result.Coefficients[4 * i + j] = (short)(a - b);
                }
            }

        return result;
        }




    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// a polynomial in place.
    /// Inputs assumed to be in normal order, output in bitreversed order
    /// </summary>
    /// <param name="r">The polynomial to transform.</param>
    public  void PolyNTT() {
        NTT();
        Reduce();
        }


    readonly short[] zetas = new short[] {
        2285, 2571, 2970, 1812, 1493, 1422, 287, 202, 3158, 622, 1577, 182, 962,
        2127, 1855, 1468, 573, 2004, 264, 383, 2500, 1458, 1727, 3199, 2648, 1017,
        732, 608, 1787, 411, 3124, 1758, 1223, 652, 2777, 1015, 2036, 1491, 3047,
        1785, 516, 3321, 3009, 2663, 1711, 2167, 126, 1469, 2476, 3239, 3058, 830,
        107, 1908, 3082, 2378, 2931, 961, 1821, 2604, 448, 2264, 677, 2054, 2226,
        430, 555, 843, 2078, 871, 1550, 105, 422, 587, 177, 3094, 3038, 2869, 1574,
        1653, 3083, 778, 1159, 3182, 2552, 1483, 2727, 1119, 1739, 644, 2457, 349,
        418, 329, 3173, 3254, 817, 1097, 603, 610, 1322, 2044, 1864, 384, 2114, 3193,
        1218, 1994, 2455, 220, 2142, 1670, 2144, 1799, 2051, 794, 1819, 2475, 2459,
        478, 3221, 3021, 996, 991, 958, 1869, 1522, 1628
        };

    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// a polynomial in place.
    /// Inputs assumed to be in bitreversed order, output in normal order
    /// </summary>
    /// <param name="r">The polynomial to transform.</param>
    public void PolyInvNTT() => InvNTT();


    private static short Fqmul(short a, short b) => Kyber.MontgomeryReduce(a * b);

    private void NTT() {
        short zeta, t;
        uint k = 1;
        uint j = 0;

        for (uint len = 128; len >= 2; len >>= 1) {
            for (uint start = 0; start < 256; start = j + len) {
                zeta = zetas[k++];
                for (j = start; j < start + len; ++j) {
                    t = Fqmul(zeta, Coefficients[j + len]);
                    Coefficients[j + len] = (short) (Coefficients[j] - t);
                    Coefficients[j] = (short)(Coefficients[j] + t);
                    }
                }
            }
        }

    readonly short[] zetas_inv = {
        1701, 1807, 1460, 2371, 2338, 2333, 308, 108, 2851, 870, 854, 1510, 2535,
        1278, 1530, 1185, 1659, 1187, 3109, 874, 1335, 2111, 136, 1215, 2945, 1465,
        1285, 2007, 2719, 2726, 2232, 2512, 75, 156, 3000, 2911, 2980, 872, 2685,
        1590, 2210, 602, 1846, 777, 147, 2170, 2551, 246, 1676, 1755, 460, 291, 235,
        3152, 2742, 2907, 3224, 1779, 2458, 1251, 2486, 2774, 2899, 1103, 1275, 2652,
        1065, 2881, 725, 1508, 2368, 398, 951, 247, 1421, 3222, 2499, 271, 90, 853,
        1860, 3203, 1162, 1618, 666, 320, 8, 2813, 1544, 282, 1838, 1293, 2314, 552,
        2677, 2106, 1571, 205, 2918, 1542, 2721, 2597, 2312, 681, 130, 1602, 1871,
        829, 2946, 3065, 1325, 2756, 1861, 1474, 1202, 2367, 3147, 1752, 2707, 171,
        3127, 3042, 1907, 1836, 1517, 359, 758, 1441
        };


    private void InvNTT() {
        uint k = 0;
        short t, zeta;
        uint j = 0;

        for (uint len = 2; len <= 128; len <<= 1) {
            for (uint start = 0; start < 256; start = j + len) {
                zeta = zetas_inv[k++];
                for (j = start; j < start + len; ++j) {
                    t = Coefficients[j];
                    Coefficients[j] = Kyber.BarrettReduce((short)(t + Coefficients[j + len]));
                    Coefficients[j + len] = (short)(t - Coefficients[j + len]);
                    Coefficients[j + len] = Fqmul(zeta, Coefficients[j + len]);
                    }
                }
            }

        for (j = 0; j < 256; ++j)
            Coefficients[j] = Fqmul(Coefficients[j], zetas_inv[127]);
        }


    /// <summary>
    /// Applies Barrett reduction to all coefficients of a polynomial.
    /// For details of the Barrett reduction see <see cref="Kyber.BarrettReduce"/>.
    /// </summary>
    public void Reduce() {
        for (var i = 0; i < Kyber.N; i++) {
            Coefficients[i] = Kyber.BarrettReduce(Coefficients[i]);
            }
        }


    /// <summary>
    /// Inplace conversion of all coefficients of a polynomial
    /// from normal domain to Montgomery domain
    /// </summary>
    public void PolyToMont() {
        short f = (short)(((ulong)1 << 32) % Kyber.Q);

        for (var i = 0; i < Kyber.N; i++) {
            Coefficients[i] = Kyber.MontgomeryReduce((short)(Coefficients[i]*f));
            }
        }


    /// <summary>
    /// Applies conditional subtraction of q to each coefficient
    /// of a polynomial. For details of conditional subtraction
    /// of q see <see cref="Kyber.ConditionalSubtract"/>.
    /// </summary>
    public void PolyCSubQ() {
        for (var i = 0; i < Kyber.N; i++) {
            Coefficients[i] = Kyber.ConditionalSubtract(Coefficients[i]);
            }
        }


    /// <summary>
    /// Add the polynomial <paramref name="polynomial"/> to the value in place.
    /// </summary>
    /// <param name="polynomial">The polynomial to add.</param>
    /// <exception cref="NYI"></exception>
    public void Add(Polynomial polynomial) {
        for (var i = 0; i < Kyber.N; i++) {
            Coefficients[i] += polynomial.Coefficients[i];
            }
        }

    /// <summary>
    /// Multiplication of two polynomials in NTT domain storing the product in place.
    /// </summary>
    /// <param name="a">First input polynomial</param>
    /// <param name="b">Second input polynomial</param>
    /// <returns></returns>
    public void PolyBasemulMontgomery(Polynomial a, Polynomial b) {

        for (var i = 0; i < Kyber.N / 4; i++) {
            (Coefficients[4 * i], Coefficients[(4 * i)+1] ) = Basemul(a, b, 4*i, (short) zetas[64+i]);
            (Coefficients[(4 * i)+2], Coefficients[(4 * i) + 3]) = Basemul(a, b, (4*i)+2, (short) -zetas[64+i]);
            }
        }


    /// <summary>
    /// Multiplication of polynomials in Zq[X]/(X^2-zeta)
    /// used for multiplication of elements in Rq in NTT domain
    /// </summary>
    /// <param name="a">First factor.</param>
    /// <param name="b">Second factor.</param>
    /// <param name="i">Index of array to operate at.</param>
    /// <param name="zeta">Integer defining the reduction polynomial</param>
    /// <returns></returns>
    public static (short, short)  Basemul(Polynomial a, Polynomial b, int i, short zeta) {
        var r0 = Fqmul(a.Coefficients[i+1], b.Coefficients[i + 1]);
        r0 = Fqmul(r0, zeta);
        r0 += Fqmul(a.Coefficients[i], b.Coefficients[i]);

        var r1 = Fqmul(a.Coefficients[i ], b.Coefficients[i + 1]);
        r1 += Fqmul(a.Coefficients[i+1], b.Coefficients[i]);

        return (r0, r1);
        }



    public void ToBytes(byte[] output, int offset) {

        throw new NYI();

        }




    /// <summary>
    /// Return a SHAKE128 fingerprint of the polynomial coefficients.
    /// </summary>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash() {

        var d2 = Coefficients.Length;

        int size = d2 * 2;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var k = 0; k < d2; k++) {
            buffer[offset++] = (byte)(Coefficients[k] & 0xff);
            buffer[offset++] = (byte)(Coefficients[k] >> 8);
            }
        return Test.GetBufferFingerprint(buffer);
        }

    }






//public class Kyber512 : Kyber {
//    ///<inheritdoc/>
//    public override int K => 2;
//    ///<inheritdoc/>
//    public override int ETA1 => 3;
//    ///<inheritdoc/>
//    public override int POLYCOMPRESSEDBYTES => 128;



//    }

//public class Kyber768 : Kyber {
//    ///<inheritdoc/>
//    public override int K => 3;
//    ///<inheritdoc/>
//    public override int ETA1 => 2;
//    ///<inheritdoc/>
//    public override int POLYCOMPRESSEDBYTES => 128;
//    }


