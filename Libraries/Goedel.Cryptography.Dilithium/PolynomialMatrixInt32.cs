using System.Reflection.Metadata;
using System.Security.Cryptography;
using Goedel.Utilities;
namespace Goedel.Cryptography.PQC;

/// <summary>
/// Operations on matrix of polynomials expressed as a list of coefficients 
/// for use in Dilithium. Could be adapted to other applications if required.
/// </summary>
public class PolynomialMatrixInt32 : Disposable {

    #region // Properties and fields
    
    ///<summary>The polynomial vectors.</summary> 
    public PolynomialVectorInt32[] Vectors;

    Dilithium Parameters { get; } 

    #endregion

    #region // Disposing
    bool Wipe { get; } = true;

    ///<inheritdoc/>
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

    /// <summary>
    /// Constructor, return matrix according to parameters specified in
    /// <paramref name="parameters"/>. If the parameter <paramref name="wipe"/>
    /// is true, the coefficients will be cleared before memory is released.
    /// </summary>
    /// <param name="parameters">The Dilithium parameters.</param>
    /// <param name="wipe">If true, contents wiped on dispose.</param>
    public PolynomialMatrixInt32(Dilithium parameters, bool wipe = true) {
        Wipe = wipe;
        Parameters = parameters;

        Vectors = new PolynomialVectorInt32[parameters.K];
        for (var i = 0; i < parameters.K; i++) {
            Vectors[i] = parameters.GetVectorL(wipe);
            }
        }
    #endregion
    #region // Matrix operations, Expand from seed, Pointwise Montgomery

    /// <summary>
    /// Create matrix according to parameters <paramref name="parameters"/> and
    /// perform expansion from seed <paramref name="rho"/>
    /// </summary>
    /// <param name="parameters">The dilithium parameters.</param>
    /// <param name="rho">The seed value.</param>
    /// <returns>The matrrix created</returns>
    public static PolynomialMatrixInt32 MatrixExpandFromSeed(Dilithium parameters, byte[] rho) {

        var result = new PolynomialMatrixInt32(parameters);
        for (var v = 0; v < parameters.K; v++) {
            for (var p = 0; p < parameters.L; p++) {
                result.Vectors[v].Polynomials[p].Uniform(rho, (v << 8) + p);
                }
            }
        return result;
        }

    /// <summary>
    /// Perform montgomery operation against the vector
    /// <paramref name="v"/> and return as a new vector.
    /// </summary>
    /// <param name="v">The vector.</param>
    /// <returns>The result vector.</returns>

    public PolynomialVectorInt32 MatrixPointwiseMontgomery(PolynomialVectorInt32 v) {

        // This is an extra long vector of length K
        var result = new PolynomialVectorInt32(Parameters, lengthK: true);

        MatrixPointwiseMontgomery(v, result);

        return result;
        }


    /// <summary>
    /// Perform montgomery operation against the vector
    /// <paramref name="v"/> and return result in <paramref name="t"/> in place.
    /// </summary>
    /// <param name="v">The vector.</param>
    /// <param name="t">The result vector.</param>
    /// <returns>The result vector.</returns>
    public void MatrixPointwiseMontgomery(PolynomialVectorInt32 v, PolynomialVectorInt32 t) {

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
        int size = Parameters.K * Parameters.L * Dilithium.N * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var v = 0; v < Parameters.K; v++) {
            for (var p = 0; p < Parameters.L; p++) {
                for (var c = 0; c < Dilithium.N; c++) {
                    var data = Vectors[v].Polynomials[p].Coefficients[c];
                    buffer[offset++] = (byte)(data & 0xff);
                    buffer[offset++] = (byte)(data >> 8);
                    buffer[offset++] = (byte)(data >> 16);
                    buffer[offset++] = (byte)(data >> 24);
                    }
                }
            }
        var hash = buffer.GetBufferFingerprint();

        if (tag != null) {
            Console.WriteLine(tag);
            Console.WriteLine(hash);
            }

        return hash;
        }
    #endregion

    }
