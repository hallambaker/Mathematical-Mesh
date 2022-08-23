namespace Goedel.Cryptography.PQC;

public class PolynomialVectorInt32 {
    public PolynomialInt32[] Polynomials;
    int K { get; }

    public PolynomialVectorInt32(int k) {
        K = k;

        Polynomials = new PolynomialInt32[k];
        for (var i = 0; i < k; i++) {
            Polynomials[i] = new PolynomialInt32();
            }
        }

    public string GetHash(string tag) {
        var d1 = Polynomials.Length;
        var d2 = Polynomials[0].Coefficients.Length;

        int size = d1*d2 * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var j = 0; j < d1; j++) {
            for (var k = 0; k < d2; k++) {
                var data = Polynomials[j].Coefficients[k];
                buffer[offset++] = (byte)(data & 0xff);
                buffer[offset++] = (byte)(data >> 8);
                buffer[offset++] = (byte)(data >> 16);
                buffer[offset++] = (byte)(data >> 24);
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
