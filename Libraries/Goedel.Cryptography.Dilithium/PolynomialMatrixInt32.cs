namespace Goedel.Cryptography.PQC;

public class PolynomialMatrixInt32 {

    public PolynomialVectorInt32[] Vectors;

    int K { get; }
    int L { get; }

    public PolynomialMatrixInt32(int l, int k) {
        K = k;
        L = l;

        Vectors = new PolynomialVectorInt32[L];
        for (var i= 0; i<l; i++) {
            Vectors[i] = new PolynomialVectorInt32(K);
            }
        }

    public static PolynomialMatrixInt32 MatrixExpand(byte[] rho, Dilithium dilithium) {

        var l = dilithium.L;
        var k = dilithium.K;

        var result = new PolynomialMatrixInt32(l, k);
        for (var i = 0; i < l; ++i) {
            for (var j = 0; j < k; ++j) {
                result.Vectors[i].Polynomials[j].UniformEta(rho, (i << 8) + j, dilithium.ETA);
                }
            }
        return result;

        }


    public string GetHash(string tag) {
        var d0 = Vectors.Length;
        var d1 = Vectors[0].Polynomials.Length;
        var d2 = Vectors[0].Polynomials[0].Coefficients.Length;

        int size = d0 * d1 * d2 * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var i = 0; i < d0; i++) {
            for (var j = 0; j < d1; j++) {
                for (var k = 0; k < d2; k++) {
                    var data = Vectors[i].Polynomials[j].Coefficients[k];
                    buffer[offset++] = (byte)(data & 0xff);
                    buffer[offset++] = (byte)(data >> 8);
                    buffer[offset++] = (byte)(data >> 16);
                    buffer[offset++] = (byte)(data >> 24);
                    }
                }
            }
        var v = Test.GetBufferFingerprint(buffer);

        if (tag != null) {
            Console.WriteLine(tag);
            Console.WriteLine(v);
            }

        return v;


        }
    }
