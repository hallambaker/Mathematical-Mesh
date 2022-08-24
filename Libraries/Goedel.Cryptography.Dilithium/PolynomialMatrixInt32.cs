using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Goedel.Cryptography.PQC;

public class PolynomialMatrixInt32 {

    public PolynomialVectorInt32[] Vectors;
    IPolynomial Parameters { get; }

    int K { get; }
    int L { get; }

    public PolynomialMatrixInt32(IPolynomial parameters) {
        Parameters = parameters;

        Vectors = new PolynomialVectorInt32[parameters.K];
        for (var i= 0; i< parameters.K; i++) {
            Vectors[i] = new PolynomialVectorInt32(parameters);
            }
        }

    public static PolynomialMatrixInt32 MatrixExpand(IPolynomial parameters, byte[] rho) {

        var result = new PolynomialMatrixInt32(parameters);
        for (var v = 0; v < parameters.K; v++) {
            for (var p = 0; p < parameters.L; p++) {
                result.Vectors[v].Polynomials[p].Uniform(rho, (v << 8) + p);
                }
            }
        return result;

        }


    public string GetHash(string tag) {
        int size = Parameters.K * Parameters.L * Parameters.N * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var v = 0; v < Parameters.K; v++) {
            for (var p = 0; p < Parameters.L; p++) {
                for (var c = 0; c < Parameters.N; c++) {
                    var data = Vectors[v].Polynomials[p].Coefficients[c];
                    buffer[offset++] = (byte)(data & 0xff);
                    buffer[offset++] = (byte)(data >> 8);
                    buffer[offset++] = (byte)(data >> 16);
                    buffer[offset++] = (byte)(data >> 24);
                    }
                }
            }
        var hash = Test.GetBufferFingerprint(buffer);

        if (tag != null) {
            Console.WriteLine(tag);
            Console.WriteLine(hash);
            }

        return hash;


        }
    }
