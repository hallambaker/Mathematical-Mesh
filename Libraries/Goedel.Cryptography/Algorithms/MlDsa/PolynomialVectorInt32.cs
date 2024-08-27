using Goedel.Utilities;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// Operations on vectors of polynomials expressed as a list of coefficients for use in Dilithium. 
/// Could be adapted to other applications if required.
/// </summary>
public class PolynomialVectorInt32 : Disposable {
    #region // Fields and Properties

    ///<summary>The polynomial vector</summary> 
    public PolynomialInt32[] Polynomials { get; }

    ///<summary>The Dilithium parameter set.</summary> 
    MLDSA Parameters { get; }

    ///<summary>Convenience accessor for the vector length K</summary> 
    int K => Parameters.K;

    ///<summary>Convenience accessor for the polynomial degree N (always 256)</summary> 
    int Length { get; }

    #endregion

    #region // Disposing
    bool Wipe { get; } = true;

    ///<inheritdoc/>
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

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">The Dilithium parameter set.</param>
    /// <param name="wipe">If set true, erase coefficients before releasing.</param>
    /// <param name="lengthK">If true, vector is of length <paramref name="parameters.K"/>, 
    /// otherwise vector is of length <paramref name="parameters.L"/></param>
    public PolynomialVectorInt32(MLDSA parameters, bool wipe = true, bool lengthK = false) {
        Wipe = wipe;
        Parameters = parameters;

        Length = lengthK ? Parameters.K : Parameters.L;

        Polynomials = new PolynomialInt32[Length];
        for (var p = 0; p < Length; p++) {
            Polynomials[p] = new PolynomialInt32(parameters, wipe);
            }
        }

    #endregion

    #region // Basic vector operations - Add, Sub, SubFrom, Copy, ShiftLeft

    /// <summary>
    /// For each polynomial, for all coefficients, add corresponding coefficient of 
    /// <paramref name="value"/> in place.
    /// </summary>
    /// <param name="value">The vector to add.</param>
    public void Add(PolynomialVectorInt32 value) {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].Add(value.Polynomials[p]);
            }
        }

    /// <summary>
    /// For each polynomial, for all coefficients, subtract corresponding coefficient of 
    /// <paramref name="value"/> in place.
    /// </summary>
    /// <param name="value">The vector to add.</param>
    public void Sub(PolynomialVectorInt32 value) {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].Sub(value.Polynomials[p]);
            }
        }
    //public void SubFrom(PolynomialVectorInt32 value) {
    //    for (var p = 0; p < Length; p++) {
    //        Polynomials[p].SubFrom(value.Polynomials[p]);
    //        }
    //    }
    #endregion
    #region // Inplace operations on Polynomials - Caddq, Reduce32, Freeze, ShiftLeft

    /// <summary>
    /// For each polynomial, for all coefficients, in place, add Q if coefficient is negative
    /// </summary>
    public void Caddq() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].Caddq();
            }
        }

    /// <summary>
    /// For each polynomial, for all coefficients, in place,  reduction to
    /// in [-6283009,6283007].
    /// </summary>
    public void Reduce() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].Reduce32();
            }
        }

    /// <summary>
    /// For each polynomial, for all coefficients, in place, reduction to
    /// standard representatives.
    /// </summary>
    public void Freeze() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].Freeze();
            }
        }

    /// <summary>
    /// For each polynomial, for all coefficients, in place, multiply 
    /// coefficient by 2^D without modular reduction. Assumes
    /// input coefficients to be less than 2^{31-D} in absolute value.
    /// </summary>
    public void ShiftLeft() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].ShiftLeft();
            }
        }
    #endregion
    #region // Make a copy of the vector

    /// <summary>
    /// Make a copy of the vector and return as a new instance.
    /// </summary>
    /// <returns>The copied vector.</returns>
    public PolynomialVectorInt32 Copy() {
        var result = new PolynomialVectorInt32(Parameters, Wipe, Length==Parameters.K);
        for (var p = 0; p < Length; p++) {
            for (var c = 0; c < MLDSA.N; c++) {
                result.Polynomials[p].Coefficients[c] = Polynomials[p].Coefficients[c];
                }
            }

        return result;
        }

    #endregion
    #region // Uniform expansions from a nonced seed - UniformETA, UniformGamma1, Reduce, Freeze

    /// <summary>
    /// Compute uniformly distributed Eta values from <paramref name="seed"/>, 
    /// <paramref name="nonce"/> across.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    /// <param name="nonce">The nonce value.</param>
    public void UniformEta(byte[] seed, int nonce) {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].UniformEta(seed, nonce++);
            }
        }

    /// <summary>
    /// Compute uniformly distributed Gamma1 values from <paramref name="seed"/>, 
    /// <paramref name="nonce"/> across.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    /// <param name="nonce">The nonce value.</param>
    public void ExpandMask(byte[] seed, int nonce) {

        for (var p = 0; p < Length; p++) {
            Polynomials[p].ExpandMask(seed, nonce + p);
            }

        // Dilithium version and Fips204 pre
        //for (var p = 0; p < Length; p++) {
        //    Polynomials[p].UniformGamma1(seed, (Length * nonce) + p);
        //    }
        }



    #endregion
    #region // Vector transformations - NTT, InvNTT2Mont
    /// <summary>
    /// Forward NTT, in-place. No modular reduction is performed after
    ///  additions or subtractions. Output vector is in bitreversed order.
    /// </summary>
    public void NTT() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].NTT();
            }
        }

    /// <summary>
    /// Inverse NTT, in-place with implicit Montgomery tranformation.
    /// </summary>
    public void InvNTT2Mont() {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].InvNTT2Mont();
            }
        }

    #endregion
    #region // Montgomery operations - PointwiseAccMontgomery

    /// <summary>
    /// Perform PointwiseMontgomery against each member of <paramref name="v"/>
    /// in turn and return the accumulated result in place.
    /// </summary>
    /// <param name="a">Polynomial</param>
    /// <param name="v">Vector</param>
    public void PointwiseAccMontgomery(PolynomialVectorInt32 v, PolynomialInt32 a) {
        a.PointwiseMontgomery(Polynomials[0], v.Polynomials[0]);
        var t = new PolynomialInt32(Parameters);
        for (var i = 1; i < Length; i++) {
            t.PointwiseMontgomery(Polynomials[i],v.Polynomials[i]);
            a.Add(t);
            }
        }

    /// <summary>
    /// Perform pointwise montgomery operation and return the result in place.
    /// </summary>
    /// <param name="a">Polynomial</param>
    /// <param name="v">Vector</param>
    public void PointwisePolyMontgomery(PolynomialInt32 a, PolynomialVectorInt32 v) {
        for (var p = 0; p < Length; p++) {
            Polynomials[p].PointwiseMontgomery(a, v.Polynomials[p]);
            }
        }

    #endregion
    #region // Operations on vectors - Chknorm, Power2Round, Decompose

    /// <summary>
    /// Check infinity norm of polynomials in vector of length L.
    /// Assumes input polyvecl to be reduced by Reduce().
    /// </summary>
    /// <param name="bound">norm bound</param>
    /// <returns>Returns false if norm of all polynomials is strictly smaller than B &lt;= (Q-1)/8
    /// and true otherwise.</returns>
    public bool Chknorm(int bound) {
        for (var p = 0; p < Length; p++) {
            if (Polynomials[p].Chknorm(bound)) {
                return true;
                }
            }

        return false;
        }

    /// <summary>
    /// Perform <see cref="PolynomialInt32.Power2Round"/> operation on each polynomial 
    /// in the vector and return a1 in place and a0 in a new vector.
    /// </summary>
    /// <returns>Vector containing a0 values.</returns>
    public PolynomialVectorInt32 Power2Round() {
        var result = new PolynomialVectorInt32(Parameters, Wipe, Length == Parameters.K);

        for (var p = 0; p < Length; p++) {
            Polynomials[p].Power2Round(result.Polynomials[p]);
            }

        return result;
        }

    /// <summary>
    /// Perform <see cref="PolynomialInt32.Decompose"/> operation on each polynomial 
    /// in the vector and return a1 in place and a0 in a new vector.
    /// </summary>
    /// <returns>Vector containing a0 values.</returns>
    public PolynomialVectorInt32 Decompose() {
        var result = Parameters.GetVectorK(Wipe);

        for (var p = 0; p < Length; p++) {
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

        for (var p = 0; p < Length; p++) {
            s += Polynomials[p].MakeHint(w0.Polynomials[p], w1.Polynomials[p]);
            }

        return s;
        }

    /// <summary>
    /// Use hint vector to correct the high bits of input vector.
    /// </summary>
    /// <param name="hint">Hint vector</param>
    public void UseHint(PolynomialVectorInt32 hint) {

        for (var p = 0; p < Length; p++) {
            Polynomials[p].UseHint(hint.Polynomials[p]);
            }
        }

    #endregion
    #region // Packaging

    /// <summary>
    /// Pack coefficients as Z data and return buffer containing
    /// the result.
    /// </summary>
    /// <returns>The packed data.</returns>
    public byte[] PackW1() {
        var buffer = new byte[K * Parameters.PolyW1PackedBytes];
        var offset = 0;
        PackW1(buffer, ref offset);
        return buffer;
        }

    /// <summary>
    /// Pack vector coefficients to <paramref name="buffer"/> as W1 data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to write vector to.</param>
    /// <param name="offset">Index of first byte to write on entry and index of
    /// next byte to write to on exit.</param>
    public void PackW1(byte[] buffer, ref int offset) {

        for (var p = 0; p < Length; p++) {
            Polynomials[p].PackW1(buffer, ref offset);
            }
        }

    #endregion

    #region // Diagnostic hash

    /// <summary>
    /// Return a SHAKE128 fingerprint of the matrix coefficients. If <paramref name="tag"/>
    /// is not null, writes the tag and fingerprint to the console.
    /// </summary>
    /// <param name="tag">Optional tag for identifying console output.</param>
    /// <param name="output">Output to write the result to if <paramref name="tag"/> is
    /// not null.</param>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash(string? tag = null,
                    TextWriter output = null) {
        output ??= Console.Out;
        int size = Length * MLDSA.N * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var p = 0; p < Length; p++) {
            for (var c = 0; c < MLDSA.N; c++) {
                var data = Polynomials[p].Coefficients[c];
                buffer[offset++] = (byte)(data & 0xff);
                buffer[offset++] = (byte)(data >> 8);
                buffer[offset++] = (byte)(data >> 16);
                buffer[offset++] = (byte)(data >> 24);
                }
            }
        var v = buffer.GetBufferFingerprint();

        if (tag != null) {
            output.WriteLine(tag);
            output.WriteLine(v);
            }

        return v;
        } 
    #endregion
    }
