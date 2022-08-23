using Goedel.Cryptography.Algorithms;

namespace Goedel.Cryptography.PQC;

public class PolynomialInt32 {
    const int stream128BlockBytes = 168;
    const int stream256BlockBytes = 136;

    public int[] Coefficients = new int[Dilithium.N];

    public void UniformEta(byte[] seed, int x, int eta) {
        using var shake = new SHAKE128Kyber();

        var nblocks = eta switch {
            2 => (136 + stream128BlockBytes -1) / stream128BlockBytes,
            4 => (227 + stream128BlockBytes - 1) / stream128BlockBytes,
            _ => throw new Exception()
            };
        var buf = new byte[nblocks* stream128BlockBytes];

        shake.AbsorbD(seed, x);
        shake.Squeeze(buf, nblocks);

        var ctr = RejectETA(buf, 0);
        while (ctr < Dilithium.N) {
            shake.Squeeze(buf, 1);
            ctr = RejectETA(buf, ctr);
            }
        }

    public int RejectETA(byte[] buf, int ctr) {

        var pos = 0;
        while (ctr < Dilithium.N & pos < buf.Length) {
            var t = (uint) buf[pos++];
            t |= (uint)(buf[pos++] << 8);
            t |= (uint)(buf[pos++] << 16);
            t &= 0x7FFFFF;

            if (t < Dilithium.Q) {
                Coefficients[ctr++] = (int)t;
                }
            }
        return ctr;
        }



    public void UniformGamma1(byte[] seed, int x, int gamma) {

        var nblocks = gamma switch {
            (1 << 17) => (576 + stream256BlockBytes - 1) / stream256BlockBytes,
            (1 << 19) => (640 + stream256BlockBytes - 1) / stream256BlockBytes,
            _ => throw new Exception()
            };


        using var shake = new SHAKE128Kyber();
        shake.AbsorbD(seed, x);

        var buf = new byte[nblocks * stream256BlockBytes];
        shake.Squeeze(buf, nblocks);

        ZUnpack(buf, gamma);
        }

    public void NTT() {
        }

    public void InvnttTomont() {
        }

    public PolynomialInt32 PointwiseMontgomery(PolynomialInt32 b) {
        throw new Exception();
        }



    public static PolynomialInt32 Challenge(byte[] seed) => new PolynomialInt32();




    public void ZUnpack(byte[] buf, int gamma) {
        if (gamma == (1 << 19)) {
            for (var i = 0; i < Dilithium.N / 2; i++) {
                var t0 = (uint)(gamma - Coefficients[2 * i + 0]);
                var t1 = (uint)(gamma - Coefficients[2 * i + 1]);

                buf[5 * i + 0] = (byte)t0;
                buf[5 * i + 1] = (byte)(t0 >> 8);
                buf[5 * i + 2] = (byte)(t0 >> 16);
                buf[5 * i + 2] |= (byte)(t1 << 4);
                buf[5 * i + 3] = (byte)(t1 >> 4);
                buf[5 * i + 4] = (byte)(t1 >> 12);
                }
            }
        else {

            for (var i = 0; i < Dilithium.N / 4; i++) {
                var t0 = (uint)(gamma - Coefficients[2 * i + 0]);
                var t1 = (uint)(gamma - Coefficients[2 * i + 1]);
                var t2 = (uint)(gamma - Coefficients[2 * i + 2]);
                var t3 = (uint)(gamma - Coefficients[2 * i + 3]);

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