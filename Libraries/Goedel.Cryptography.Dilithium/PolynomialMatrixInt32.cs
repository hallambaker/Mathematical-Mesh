using System.Reflection.Metadata;
using System.Security.Cryptography;
using Goedel.Utilities;
namespace Goedel.Cryptography.PQC;

public class PolynomialMatrixInt32 : Disposable {

    #region // Properties and fields
    public PolynomialVectorInt32[] Vectors;

    IDilithium Parameters { get; } 


    int K => Parameters.K;
    int L => Parameters.L;
    #endregion

    #region // Disposing
    bool Wipe { get; } = true;
    protected override void Disposing() {
        if (!Wipe) {
            return;
            }
        for (var v = 0; v < Parameters.K; v++) {
            Vectors[v].Dispose();
            }
        }
    #endregion
    #region // Constructors
    public PolynomialMatrixInt32(IDilithium parameters, bool wipe = true) {
        Wipe = wipe;
        Parameters = parameters;

        Vectors = new PolynomialVectorInt32[parameters.K];
        for (var i = 0; i < parameters.K; i++) {
            Vectors[i] = new PolynomialVectorInt32(parameters, wipe);
            }
        }
    #endregion
    #region // Matrix operations, Expand from seed, Pointwise Montgomery

    public static PolynomialMatrixInt32 MatrixExpandFromSeed(IDilithium parameters, byte[] rho) {

        var result = new PolynomialMatrixInt32(parameters);
        for (var v = 0; v < parameters.K; v++) {
            for (var p = 0; p < parameters.L; p++) {
                result.Vectors[v].Polynomials[p].Uniform(rho, (v << 8) + p);
                }
            }
        return result;
        }



    public PolynomialVectorInt32 MatrixPointwiseMontgomery(PolynomialVectorInt32 a) {
        var result = new PolynomialVectorInt32(Parameters);

        MatrixPointwiseMontgomery(a, result);

        return result;
        }

    public void MatrixPointwiseMontgomery(PolynomialVectorInt32 v, PolynomialVectorInt32 t) {

        // NB: this only operates over the first K elements of t which actually has L entries.
        for (var i = 0; i < Parameters.K; i++) {
            Vectors[i].PointwiseAccMontgomery(v, t.Polynomials[i]);
            }

        }

    #endregion
    #region // Diagnostics
    /// <summary>
    /// Return a SHAKE128 fingerprint of the matrix coefficients. If <paramref name="tag"/>
    /// is not null, writes the tag and fingerprint to the console.
    /// </summary>
    /// <param name="tag">Optional tag for identifying console output.</param>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash(string? tag=null) {
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
    #endregion

    }
