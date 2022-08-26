
namespace Goedel.Cryptography.PQC;

public interface IDilithium {

    ///<summary>The modulus for vector arithmetic. This is a fixed constant to allow compile
    ///time optimization of the static methods here.</summary> 
    public const int Q = 8380417;
    const int mont = -4186625;
    const int qinv = 58728449;



    public const int GAMMA_17 = (1 << 17);
    public const int GAMMA_19 = (1 << 19);

    public const int GAMMA_2_88 = (IDilithium.Q - 1) / 88;
    public const int GAMMA_2_32 = (IDilithium.Q - 1) / 32;



    ///<summary>Number of bits to left shift output.</summary> 
    public const int D = 13;


    ///<summary>Number of vectors in the matrix.</summary> 
    public int K { get; }
    
    ///<summary>Number of Polynomials per vector.</summary> 
    public int L { get; }
    
    ///<summary>Number of coefficients per vector</summary> 
    public int N { get; }

    ///<summary>The ETA value</summary> 
    public int ETA { get; }

    ///<summary>The Tau value.</summary> 
    public int TAU { get; }

    ///<summary></summary> 
    public int GAMMA1 { get; }

    ///<summary></summary> 
    public int GAMMA2 { get; }

    ///<summary></summary> 
    public int OMEGA { get; }

    public int POLYZ_PACKEDBYTES => GAMMA1 switch {
        GAMMA_17 => 576,
        _ => 640
        };

    public int POLYW1_PACKEDBYTES => GAMMA2 switch {
        GAMMA_2_88 => 192,
        _ => 128
        };

    public int POLYETA_PACKEDBYTES => ETA switch {
        2 => 96,
        _ => 128
        };



    public int POLYT1_PACKEDBYTES => 320;
    public int POLYT0_PACKEDBYTES => 416;
    public int POLYVECH_PACKEDBYTES => (OMEGA + K);

    #region // Reductions etc. on finite field elements.
    /// <summary>
    /// Montgomery reduction according to <see cref="Q"/>. Changed return
    /// type to int since this appears more consistent with use in the code.
    /// </summary>
    /// <param name="a">The value to reduce.</param>
    /// <returns>The Montgomery reduction.</returns>
    public static int MontgomeryReduce(long a) {
        int t = (int)(a * qinv);
        return (int)(a - ((long)t * Q) >> 32);
        }

    /// <summary>
    /// For finite field element a with a <= 2^{31} - 2^{22} - 1,
    /// compute r \equiv a (mod Q) such that -6283009 <= r <= 6283007.
    /// </summary>
    /// <param name="a">Finite field element a</param>
    /// <returns>Finite field element a</returns>
    public static int Reduce32(int a) {

        var t = (a + (1 << 22)) >> 23;
        t = a - t * Q;

        return t;
        }

    /// <summary>
    /// Add Q if input coefficient is negative.
    /// </summary>
    /// <param name="a">finite field element a</param>
    /// <returns>Finite field element a</returns>
    public static int Caddq(int a) => a + ((a >> 31) & Q);

    /// <summary>
    /// For finite field element a, compute standard
    /// representative r = a mod^+ Q.
    /// </summary>
    /// <param name="a">Finite field element a</param>
    /// <returns>Finite field element a</returns>
    public static int Freeze(int a) => Caddq(Reduce32(a));



    /// <summary>
    /// For finite field element a, compute a0, a1 such that
    /// a mod^+ Q = a1*2^D + a0 with -2^{D-1} < a0 <= 2^{D-1}.
    /// Assumes a to be standard representative.
    /// </summary>
    /// <param name="a">input element</param>
    /// <returns>Output elements a0, a1</returns>

    public static (int, int) Power2Round(int a) {
        var a1 = (a + (1 << (D - 1)) - 1) >> D;
        var a0 = a - (a1 << D);
        return (a0, a1);
        }

    /// <summary>
    /// For finite field element a, compute high and low bits a0, a1 such
    /// that a mod^+ Q = a1*ALPHA + a0 with -ALPHA/2 < a0 <= ALPHA/2 except
    /// if a1 = (Q-1)/ALPHA where we set a1 = 0 and
    /// -ALPHA/2 <= a0 = a mod^+ Q - Q < 0. Assumes a to be standard
    /// representative.
    /// </summary>
    /// <param name="a">input element</param>
    /// <returns>Output elements a0, a1</returns>
    public (int, int) Decompose(int a) {
        var a1 = (a + 127) >> 7;
        if (GAMMA2 == GAMMA_2_32) {
            a1 = (a1 * 1025 + (1 << 21)) >> 22;
            a1 &= 15;
            }
        else {
            a1 = (a1 * 11275 + (1 << 23)) >> 24;
            a1 ^= ((43 - a1) >> 31) & a1;
            }

        var a0 = a - a1 * 2 * GAMMA2;
        a0 -= (((Q - 1) / 2 - a0) >> 31) & Q;
        return (a0, a1);
        }

    /// <summary>
    /// Compute hint bit indicating whether the low bits of the
    /// input element overflow into the high bits. Inputs assumed
    /// to be standard representatives.
    /// </summary>
    /// <param name="a0">low bits of input element</param>
    /// <param name="a">high bits of input element</param>
    /// <returns></returns>
    public int MakeHint(int a0, int a1) {
        if (a0 <= GAMMA2 || a0 > Q - GAMMA2 || (a0 == Q - GAMMA2 && a1 == 0)) {
            return 0;
            }

        return 1;
        }

    /// <summary>
    /// Correct high bits according to hint.
    /// </summary>
    /// <param name="a">input element</param>
    /// <param name="h">The hint bit</param>
    /// <returns>corrected high bits.</returns>
    public int UseHint(int a, int h) {
        var hint = (uint)h;

        var (a0,a1) = Decompose(a);
        if (hint == 0) {
            return a1;
            }

        if (GAMMA2 == GAMMA_2_32) {
            if (a0 > 0) {
                return (a1 + 1) & 15;
                }
            else {
                return (a1 - 1) & 15;
                }
            }
        else {
            if (a0 > 0) {
                return (a1 == 43) ? 0 : a1 + 1;
                }
            else {
                return (a1 == 0) ? 43 : a1 - 1;
                }
            }


        throw new NYI();
        }


    #endregion

    }
