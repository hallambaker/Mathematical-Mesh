using Goedel.Cryptography.Algorithms;
using System.Reflection.Metadata;

namespace Goedel.Cryptography.PQC;

public interface IPolynomial {


    public int N { get; }

    public int Q { get; }


    public int K { get; }
    public int L { get; }
    public int ETA { get; }


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

    public void NTT() {
        }

    public void InvnttTomont() {
        }

    public PolynomialInt32 PointwiseMontgomery(PolynomialInt32 b) {
        throw new Exception();
        }



    public static PolynomialInt32 Challenge(IPolynomial parameters, byte[] seed) => new PolynomialInt32(parameters);








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