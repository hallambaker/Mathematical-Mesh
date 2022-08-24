namespace Goedel.Cryptography.PQC;

public class PolynomialVectorInt32 {
    public PolynomialInt32[] Polynomials;
    IPolynomial Parameters { get; }

    public PolynomialVectorInt32(IPolynomial parameters) {
        Parameters = parameters;
        Polynomials = new PolynomialInt32[parameters.L];
        for (var p = 0; p < parameters.L; p++) {
            Polynomials[p] = new PolynomialInt32(parameters);
            }
        }

    public string GetHash(string tag) {

        int size = Parameters.L * Parameters.N * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var p = 0; p < Parameters.L; p++) {
            for (var c = 0; c < Parameters.N; c++) {
                var data = Polynomials[p].Coefficients[c];
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
