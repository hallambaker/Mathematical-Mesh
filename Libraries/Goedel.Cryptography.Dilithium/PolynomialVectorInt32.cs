using Goedel.Utilities;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// Vector operations on polynomials and coefficients for use in Dilithium. Could be
/// adapted to other applications if required.
/// </summary>
public class PolynomialVectorInt32 : Disposable {


    #region // Fields and Properties

    ///<summary>The polynomial vector</summary> 
    public PolynomialInt32[] Polynomials { get; }

    ///<summary>The Dilithium parameter set.</summary> 
    IDilithium Parameters { get; }

    ///<summary>Convenience accessor for the vector length K</summary> 
    int K => Parameters.K;

    ///<summary>Convenience accessor for the polynomial degree N (always 256)</summary> 
    int L => Parameters.L;

    #endregion
    #region // Disposing
    bool Wipe { get; } = true;
    protected override void Disposing() {
        if (!Wipe) {
            return;
            }
        for (var p = 0; p < Parameters.L; p++) {
            Polynomials[p].Dispose();
            }
        }
    #endregion
    #region // Constructors and factory methods
    public PolynomialVectorInt32(IDilithium parameters, bool wipe = true) {
        Wipe = wipe;
        Parameters = parameters;
        Polynomials = new PolynomialInt32[parameters.L];
        for (var p = 0; p < parameters.L; p++) {
            Polynomials[p] = new PolynomialInt32(parameters, wipe);
            }
        }

    #endregion
    #region // Basic vector operations - Add, Sub, SubFrom, Copy, ShiftLeft
    public void Add(PolynomialVectorInt32 value) {
        for (var p = 0; p < L; p++) {
            Polynomials[p].Add(value.Polynomials[p]);
            }
        }

    public void Sub(PolynomialVectorInt32 value) {
        for (var p = 0; p < L; p++) {
            Polynomials[p].Sub(value.Polynomials[p]);
            }
        }
    public void SubFrom(PolynomialVectorInt32 value) {
        for (var p = 0; p < L; p++) {
            Polynomials[p].SubFrom(value.Polynomials[p]);
            }
        }
    #endregion
    #region // Inplace operations on Polynomials - Caddq, Reduce32, Freeze, ShiftLeft
    public void Caddq() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].Caddq();
            }
        }

    public void Reduce() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].Reduce32();
            }
        }
    public void Freeze() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].Freeze();
            }
        }

    public void ShiftLeft() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].ShiftLeft();
            }
        }
    #endregion
    #region // Make a copy of the vector
    public PolynomialVectorInt32 Copy() {
        var result = new PolynomialVectorInt32(Parameters, Wipe);
        for (var p = 0; p < Parameters.L; p++) {
            for (var c = 0; c < Parameters.K; c++) {
                result.Polynomials[p].Coefficients[c] = Polynomials[p].Coefficients[c];
                }
            }

        return result;
        }

    #endregion
    #region // Uniform expansions from a nonced seed - UniformETA, UniformGamma1, Reduce, Freeze

    public void UniformEta(byte[] seed, int nonce) {
        for (var p = 0; p < L; p++) {
            Polynomials[p].UniformEta(seed, nonce++);
            }
        }

    public void UniformGamma1(byte[] seed, int nonce) {
        for (var p = 0; p < L; p++) {
            Polynomials[p].UniformGamma1(seed, nonce++);
            }
        }



    #endregion
    #region // Vector transformations - NTT, InvNTT2Mont

    public void NTT() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].NTT();
            }
        }
    public void InvNTT2Mont() {
        for (var p = 0; p < L; p++) {
            Polynomials[p].InvNTT2Mont();
            }
        }

    #endregion
    #region // Montgomery operations - PointwiseAccMontgomery
    public void PointwiseAccMontgomery(PolynomialVectorInt32 v, PolynomialInt32 a) {
        Polynomials[0].PointwiseMontgomery(v.Polynomials[0], a);
        var t = new PolynomialInt32(Parameters);
        for (var i = 1; i < L; i++) {
            Polynomials[0].PointwiseMontgomery(v.Polynomials[0], t);
            a.Add(t);
            }
        }

    //public PolynomialVectorInt32 PointwisePolyMontgomery(PolynomialInt32 a) {
    //    var result = new PolynomialVectorInt32(Parameters);
    //    PointwisePolyMontgomery(a, result);
    //    return result;
    //    }

    public void PointwisePolyMontgomery(PolynomialInt32 a, PolynomialVectorInt32 result) {
        for (var p = 0; p < L; p++) {
            result.Polynomials[p].PointwiseMontgomery(Polynomials[p], result.Polynomials[p]);
            }

        }

    #endregion
    #region // Operations on vectors - Chknorm, Power2Round, Decompose

    /// <summary>
    /// Check infinity norm of polynomials in vector of length L.
    /// Assumes input polyvecl to be reduced by Reduce().
    /// </summary>
    /// <param name="bound">norm bound</param>
    /// <returns>Returns false if norm of all polynomials is strictly smaller than B <= (Q-1)/8
    /// and true otherwise.</returns>
    public bool Chknorm(int bound) {
        for (var p = 0; p < L; p++) {
            if (!Polynomials[p].Chknorm(bound)) {
                return true;
                }
            }

        return false;
        }
    public PolynomialVectorInt32 Power2Round() {
        var result = new PolynomialVectorInt32(Parameters);

        for (var p = 0; p < L; p++) {
            Polynomials[p].Power2Round(result.Polynomials[p]);
            }

        return result;
        }


    public PolynomialVectorInt32 Decompose() {
        var result = new PolynomialVectorInt32(Parameters);

        for (var p = 0; p < L; p++) {
            Polynomials[p].Decompose(result.Polynomials[p]);
            }

        return result;
        }

    #endregion
    #region // Making and using hint vectors
    /// <summary>
    /// Compute hint vector and store in this instance.
    /// </summary>
    /// <param name="w0">low part of input vector</param>
    /// <param name="w1">high part of input vector</param>
    /// <returns>number of 1 bits.</returns>
    public int MakeHint(PolynomialVectorInt32 w0, PolynomialVectorInt32 w1) {
        var s = 0;

        for (var p = 0; p < L; p++) {
            s += Polynomials[p].MakeHint(w0.Polynomials[p], w1.Polynomials[p]);
            }

        return s;
        }

    /// <summary>
    /// Use hint vector to correct the high bits of input vector.
    /// </summary>
    /// <param name="hint">Hint vector</param>
    public void UseHint(PolynomialVectorInt32 hint) {

        for (var p = 0; p < L; p++) {
            Polynomials[p].UseHint(hint.Polynomials[p]);
            }
        }

    #endregion
    #region // Packaging

    public byte[] PackW1() {
        var buffer = new byte[K * Parameters.POLYW1_PACKEDBYTES];
        var offset = 0;
        PackW1(buffer, ref offset);
        return buffer;
        }


    public void PackW1(byte[] buffer, ref int offset) {

        for (var p = 0; p < L; p++) {
            Polynomials[p].PackW1(buffer, ref offset);
            }
        }

    #endregion
  
    #region // Diagnostic hash
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
    #endregion

    }
