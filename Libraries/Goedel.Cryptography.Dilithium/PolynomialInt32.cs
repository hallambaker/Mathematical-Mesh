using Goedel.Cryptography.Algorithms;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.PQC;

public interface IPolynomial {


    public int N { get; }

    public int Q { get; }


    public int K { get; }
    public int L { get; }
    public int ETA { get; }

    public int TAU { get; }
    public int GAMMA1 { get; }
    }


public class PolynomialInt32 {
    const int stream128BlockBytes = 168;
    const int stream256BlockBytes = 136;

    public int[] Coefficients;
    public int N { get; }
    IPolynomial Parameters;


    delegate int RejectDelegate (byte[] buf, int ctr);

    RejectDelegate RejectUniform;


    public PolynomialInt32(IPolynomial parameters) {
        Parameters = parameters;

        // Fix N so the compiler knows that it cannot change inside a loop.
        N = parameters.N;
        Coefficients = new int[N];

        // Initialize Delegates
        RejectUniform = RejectUniformX;
        }


    public void Uniform(byte[] seed, int x) {
        using var shake = new SHAKEExtended();

        var nblocks = (768 + stream128BlockBytes - 1) / stream128BlockBytes;
        var buf = new byte[nblocks * stream128BlockBytes];

        shake.AbsorbD(seed, x);
        shake.Squeeze(buf, nblocks);

        var ctr = RejectUniform(buf, 0);
        while (ctr < N) {
            shake.Squeeze(buf, 1);
            ctr = RejectUniform(buf, ctr);
            }
        }
    public void UniformEta(byte[] seed, int x) {
        using var shake = new SHAKEExtended();

        var nblocks = Parameters.ETA switch {
            2 => (136 + stream128BlockBytes -1) / stream128BlockBytes,
            4 => (227 + stream128BlockBytes - 1) / stream128BlockBytes,
            _ => throw new Exception()
            };
        var buf = new byte[nblocks* stream128BlockBytes];

        shake.AbsorbD(seed, x);
        shake.Squeeze(buf, nblocks);

        var ctr = RejectETA(buf, 0);
        while (ctr < N) {
            shake.Squeeze(buf, 1);
            ctr = RejectETA(buf, ctr);
            }
        }

    public int RejectUniformX(byte[] buf, int ctr) {

        var pos = 0;
        while (ctr < N & pos < buf.Length) {
            var t = (uint) buf[pos++];
            t |= (uint)(buf[pos++] << 8);
            t |= (uint)(buf[pos++] << 16);
            t &= 0x7FFFFF;

            if (t < Parameters.Q) {
                Coefficients[ctr++] = (int)t;
                }
            }
        return ctr;
        }


    public int RejectETA(byte[] buf, int ctr) {

        var pos = 0;
        while (ctr < N & pos < buf.Length) {
            var t0 = (uint)(buf[pos] & 0xF);
            var t1 = (uint)(buf[pos++] >>4);

            switch (Parameters.ETA) {
                case 2: {
                    if (t0 < 15) {
                        t0 = t0 - (205 * t0 >> 10) * 5;
                        Coefficients[ctr++] = (int) (2 - t0);
                        }
                    if (t1 < 15 & ctr < N) {
                        t1 = t1 - (205 * t1 >> 10) * 5;
                        Coefficients[ctr++] = (int) (2 - t1);
                        }
                    break;
                    }
                case 4: {
                    if (t0 < 9) {
                        Coefficients[ctr++] = (int)(4 - t0);
                        }
                    if (t1 < 9 & ctr < N) {
                        Coefficients[ctr++] = (int)(4 - t1);
                        }
                    break;
                    }
                }


            }
        return ctr;
        }

    public void UniformGamma1(byte[] seed, int x) {

        var nblocks = Parameters.GAMMA1 switch {
            (1 << 17) => (576 + stream256BlockBytes - 1) / stream256BlockBytes,
            (1 << 19) => (640 + stream256BlockBytes - 1) / stream256BlockBytes,
            _ => throw new Exception()
            };


        using var shake = SHAKEExtended.Shake256();
        shake.AbsorbD(seed, x);

        var buf = new byte[nblocks * stream256BlockBytes];
        shake.Squeeze(buf, nblocks);

        ZUnpack(buf);
        }



    readonly int[] Zetas  = new int[] {
                 0,    25847, -2608894,  -518909,   237124,  -777960,  -876248,   466468,
           1826347,  2353451,  -359251, -2091905,  3119733, -2884855,  3111497,  2680103,
           2725464,  1024112, -1079900,  3585928,  -549488, -1119584,  2619752, -2108549,
          -2118186, -3859737, -1399561, -3277672,  1757237,   -19422,  4010497,   280005,
           2706023,    95776,  3077325,  3530437, -1661693, -3592148, -2537516,  3915439,
          -3861115, -3043716,  3574422, -2867647,  3539968,  -300467,  2348700,  -539299,
          -1699267, -1643818,  3505694, -3821735,  3507263, -2140649, -1600420,  3699596,
            811944,   531354,   954230,  3881043,  3900724, -2556880,  2071892, -2797779,
          -3930395, -1528703, -3677745, -3041255, -1452451,  3475950,  2176455, -1585221,
          -1257611,  1939314, -4083598, -1000202, -3190144, -3157330, -3632928,   126922,
           3412210,  -983419,  2147896,  2715295, -2967645, -3693493,  -411027, -2477047,
           -671102, -1228525,   -22981, -1308169,  -381987,  1349076,  1852771, -1430430,
          -3343383,   264944,   508951,  3097992,    44288, -1100098,   904516,  3958618,
          -3724342,    -8578,  1653064, -3249728,  2389356,  -210977,   759969, -1316856,
            189548, -3553272,  3159746, -1851402, -2409325,  -177440,  1315589,  1341330,
           1285669, -1584928,  -812732, -1439742, -3019102, -3881060, -3628969,  3839961,
           2091667,  3407706,  2316500,  3817976, -3342478,  2244091, -2446433, -3562462,
            266997,  2434439, -1235728,  3513181, -3520352, -3759364, -1197226, -3193378,
            900702,  1859098,   909542,   819034,   495491, -1613174,   -43260,  -522500,
           -655327, -3122442,  2031748,  3207046, -3556995,  -525098,  -768622, -3595838,
            342297,   286988, -2437823,  4108315,  3437287, -3342277,  1735879,   203044,
           2842341,  2691481, -2590150,  1265009,  4055324,  1247620,  2486353,  1595974,
          -3767016,  1250494,  2635921, -3548272, -2994039,  1869119,  1903435, -1050970,
          -1333058,  1237275, -3318210, -1430225,  -451100,  1312455,  3306115, -1962642,
          -1279661,  1917081, -2546312, -1374803,  1500165,   777191,  2235880,  3406031,
           -542412, -2831860, -1671176, -1846953, -2584293, -3724270,   594136, -3776993,
          -2013608,  2432395,  2454455,  -164721,  1957272,  3369112,   185531, -1207385,
          -3183426,   162844,  1616392,  3014001,   810149,  1652634, -3694233, -1799107,
          -3038916,  3523897,  3866901,   269760,  2213111,  -975884,  1717735,   472078,
           -426683,  1723600, -1803090,  1910376, -1667432, -1104333,  -260646, -3833893,
          -2939036, -2235985,  -420899, -2286327,   183443,  -976891,  1612842, -3545687,
           -554416,  3919660,   -48306, -1362209,  3937738,  1400424,  -846154,  1976782
        };



    /// <summary>
    /// Forward NTT, in-place. No modular reduction is performed after
    ///  additions or subtractions. Output vector is in bitreversed order.
    /// </summary>
    public void NTT() {
        int zeta;
        int j = 0;

        int k = 0;
        for (var len = 128; len > 0; len >>= 1) {
            for (var start = 0; start < N; start = j + len) {
                zeta = Zetas[++k];
                for (j = start; j < start + len; ++j) {
                    var t = Dilithium.MontgomeryReduce ((long)zeta * Coefficients[j + len]);
                    Coefficients[j + len] = Coefficients[j] - t;
                    Coefficients[j] = Coefficients[j] + t;
                    }
                }
            }
        }
    public void InvnttTomont() {

        const int f = 41978; // mont^2/256

        int zeta;
        int j = 0;


        int k = 256;
        for (var len = 1; len < N; len <<= 1) {
            for (var start = 0; start < N; start = j + len) {
                zeta = -Zetas[--k];
                for (j = start; j < start + len; ++j) {
                    var t = Coefficients[j];
                    Coefficients[j] = t + Coefficients[j + len];
                    Coefficients[j + len] = t - Coefficients[j + len];
                    Coefficients[j + len] = Dilithium.MontgomeryReduce((long)zeta * Coefficients[j + len]);
                    }
                }


            }

        for (j = 0; j < N; ++j) {
            Coefficients[j] = Dilithium.MontgomeryReduce((long)f * Coefficients[j]);
            }

        }
    public void PointwiseMontgomery(PolynomialInt32 a, PolynomialInt32 b) {
        for (var i = 0; i < N; i++) {
            Coefficients[i] = Dilithium.MontgomeryReduce((long)a.Coefficients[i] * (long)b.Coefficients[i]);
            }
        }



    public void Challenge(byte[] seed) {

        var buf = new byte[SHA3.HashRateShake256];

        using var shake = SHAKEExtended.Shake256();
        shake.Absorb(seed);
        shake.Squeeze(buf, 1);

        uint b;

        ulong signs = 0;
        for (var i = 0; i < 8; ++i)
            signs |= (ulong)buf[i] << 8 * i;
        var pos = 8;

        for (var i = 0; i < N; ++i)
            Coefficients[i] = 0;
        for (var i = N - Parameters.TAU; i < N; ++i) {
            do {
                if (pos >= SHA3.HashRateShake256) {
                    shake.Squeeze(buf, 1);
                    pos = 0;
                    }

                b = buf[pos++];
                } while (b > i);

            Coefficients[i] = Coefficients[b];
            Coefficients[b] = 1 - 2 * (int)(signs & 1);
            signs >>= 1;

            }


        }





    public void ZPack(byte[] buf, int gamma) {
        if (Parameters.GAMMA1 == Dilithium.GAMMA_19) {
            for (var i = 0; i < N / 2; i++) {
                var t0 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 0]);
                var t1 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 1]);

                buf[5 * i + 0] = (byte)t0;
                buf[5 * i + 1] = (byte)(t0 >> 8);
                buf[5 * i + 2] = (byte)(t0 >> 16);
                buf[5 * i + 2] |= (byte)(t1 << 4);
                buf[5 * i + 3] = (byte)(t1 >> 4);
                buf[5 * i + 4] = (byte)(t1 >> 12);
                }
            }
        else {

            for (var i = 0; i < N / 4; i++) {
                var t0 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 0]);
                var t1 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 1]);
                var t2 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 2]);
                var t3 = (uint)(Parameters.GAMMA1 - Coefficients[2 * i + 3]);

                buf[9 * i + 0]  = (byte)t0;
                buf[9 * i + 1]  = (byte)(t0 >> 8);
                buf[9 * i + 2]  = (byte)(t0 >> 16);
                buf[9 * i + 2] |= (byte)(t1 << 2);
                buf[9 * i + 3]  = (byte)(t1 >> 6);
                buf[9 * i + 4]  = (byte)(t1 >> 14);
                buf[9 * i + 4] |= (byte)(t2 << 4);
                buf[9 * i + 5]  = (byte)(t2 >> 4);
                buf[9 * i + 6]  = (byte)(t2 >> 12);
                buf[9 * i + 6] |= (byte)(t3 << 6);
                buf[9 * i + 7]  = (byte)(t3 >> 2);
                buf[9 * i + 8]  = (byte)(t3 >> 10);
                }
            }
        }


    public void ZUnpack(byte[] buf) {
        if (Parameters.GAMMA1 == Dilithium.GAMMA_19) {
            for (var i = 0; i < N / 2; i++) {
                uint c0, c1;


                c0 = buf[5 * i + 0];
                c0 |= ((uint)(buf[5 * i + 1]) << 8);
                c0 |= ((uint)(buf[5 * i + 2]) << 16);
                c0 &= 0xFFFFF;

                c1 = (uint) (buf[5 * i + 2] >> 4);
                c1 |= ((uint)(buf[5 * i + 3]) << 4);
                c1 |= ((uint)(buf[5 * i + 4]) << 12);
                
                // BUG: This appears to be a bug in the reference code.
                c1 &= 0xFFFFF;

                Coefficients[2 * i + 0] = (int)(Dilithium.GAMMA_19 - c0);
                Coefficients[2 * i + 1] = (int)(Dilithium.GAMMA_19 - c1);
                }

            }
        else {
            for (var i = 0; i < N / 4; i++) {

                Coefficients[4 * i + 0] = buf[9 * i + 0];


                }
            }

        }




    public string GetHash(string tag) {

        var d2 = Coefficients.Length;

        int size = d2 * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var k = 0; k < d2; k++) {
            var data = Coefficients[k];
            buffer[offset++] = (byte)(data & 0xff);
            buffer[offset++] = (byte)(data >> 8);
            buffer[offset++] = (byte)(data >> 16);
            buffer[offset++] = (byte)(data >> 24);
            }
        var v = Test.GetBufferFingerprint(buffer);

        if (tag != null) {
            Console.WriteLine(tag);
            Console.WriteLine(v);
            }

        return v;
        }

    }