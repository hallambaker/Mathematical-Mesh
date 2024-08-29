namespace Goedel.Cryptography.PQC;


/// <summary>
/// Dilithium modes.
/// </summary>
public enum MlDsaMode {
    Unknown = -1,
    ///<summary>Mode 2, lowest work factor.</summary> 
    Mode44 = 0,
    ///<summary>Mode 3, improved work factor.</summary> 
    Mode65 = 1,
    ///<summary>Mode 5, highest work factor.</summary> 
    Mode87 = 2
    }

/// <summary>
/// Base class for Dilithium implementations.
/// </summary>
public class MLDSA {

    #region // Field and constants
    #region // Common parameters, fixed for all modes.
    ///<summary>The modulus for vector arithmetic. This is a fixed constant to allow compile
    ///time optimization of the static methods here.</summary> 
    public const int Q = 8380417;

    ///<summary>Inverse of Q</summary> 
    const int qinv = 58728449;

    ///<summary>Degree of the polynomial.</summary> 
    public const int N = 256;

    ///<summary></summary> 
    public int OMEGA { get; }

    ///<summary>Number of bits to left shift output.</summary> 
    public const int D = 13;

    #endregion
    #region // Mode dependent parameters.

    ///<summary>The mode identifier</summary> 
    public MlDsaMode Mode { get; }

    ///<summary>Number of vectors in the matrix.</summary> 
    public int K { get; }

    ///<summary>Number of polynomials per vector.</summary> 
    public int L { get; }

    ///<summary>Eta value.</summary> 
    public int Eta { get; }

    ///<summary>Tau value.</summary> 
    public int Tau { get; }

    ///<summary>Beta value.</summary> 
    public int Beta { get; }

    ///<summary>Gamma1 value.</summary> 
    public int Gamma1 { get; }

    ///<summary>Gamma 2 value.</summary> 
    public int Gamma2 { get; }
    #endregion
    #region // Constants used to set mode dependent parameters.
    ///<summary>The Gamma1 vale 2^17</summary> 
    public const int Gamma1_17 = (1 << 17);
    ///<summary>The Gamma1 vale 2^19</summary> 
    public const int Gamma1_19 = (1 << 19);

    ///<summary>The Gamma2 vale (Q - 1) / 88</summary> 
    public const int Gamma2_88 = (Q - 1) / 88;
    ///<summary>The Gamma2 vale (Q - 1) / 32</summary> 
    public const int Gamma2_32 = (Q - 1) / 32;

    readonly int[] Ks = new int[] { 4, 6, 8 };
    readonly int[] Ls = new int[] { 4, 5, 7 };
    readonly int[] ETAs = new int[] { 2, 4, 2 };
    readonly int[] TAUs = new int[] { 39, 49, 60 };

    readonly int[] BETAs = new int[] { 78, 196, 120 };
    readonly int[] GAMMA1s = new int[] { Gamma1_17, Gamma1_19, Gamma1_19 };
    readonly int[] GAMMA2s = new int[] { Gamma2_88, Gamma2_32, Gamma2_32 };
    readonly int[] OMEGAs = new int[] { 80, 55, 75 };
    #endregion
    #region // Packed data sizes


    ///<summary>Minimum seed byte size.</summary> 
    public const int SeedBytes = 32;

    ///<summary>Message representative size.</summary> 
    public virtual int RhoBytes => 32;

    ///<summary>Message representative size.</summary> 
    public virtual int RhoPrimeBytes => 64;

    ///<summary>Message representative size.</summary> 
    public virtual int PrivateRandomSeed => 32;

    ///<summary>CHR Byte size.</summary> 
    public virtual int TrBytes => 64;


    ///<summary>CHR Byte size.</summary> 
    public int CrhBytes = 48;

    ///<summary>Message representative size.</summary> 
    public virtual int MrsBytes => 64;

    ///<summary>CHR Byte size.</summary> 
    public int PrsBytes => 64;


    ///<summary></summary> 
    public int CommitmentHashBytes => Mode switch {
        MlDsaMode.Mode44 => 128 / 4,
        MlDsaMode.Mode65 => 192 / 4,
        MlDsaMode.Mode87 => 256 / 4,
        _ => throw new CryptographicException()
        };



    ///<summary></summary> 
    public int SigmaBytes { get; }

    ///<summary></summary> 
    public int CSquigleByles { get; }

    ///<summary></summary> 
    public int SignatureSeedBytes { get; } = 0;


    ///<summary>Length of packed Z polynomial in bytes.</summary> 
    public int PolyZPackedBytes => Gamma1 switch {
        Gamma1_17 => 576,
        _ => 640
        };

    ///<summary>Length of packed W1 polynomial in bytes.</summary> 
    public int PolyW1PackedBytes => Gamma2 switch {
        Gamma2_88 => 192,
        _ => 128
        };

    ///<summary>Length of packed Eta polynomial in bytes.</summary> 
    public int PolyEtaPackedBytes => Eta switch {
        2 => 96,
        _ => 128
        };

    ///<summary>Length of packed T1 polynomial in bytes.</summary> 
    const int PolyT1PackedBytes = 320;

    ///<summary>Length of packed T0 polynomial in bytes.</summary> 
    const int PolyT0PackedBytes = 416;

    ///<summary>Length of packed Hint Vector polynomial in bytes.</summary> 
    int PolyVecHPackedBytes => (OMEGA + K);

    ///<summary>Public key length in bytes.</summary> 
    public int PublicKeyBytes => (SeedBytes + K * PolyT1PackedBytes);

    ///<summary>Private key length in bytes.</summary> 
    public int PrivateKeyBytes => (2 * SeedBytes + CrhBytes +
            L * PolyEtaPackedBytes + K * PolyEtaPackedBytes + K * PolyT0PackedBytes);

    ///<summary>Number of bytes in the signature (excluding copied message)</summary> 
    public int SignatureBytes => (SeedBytes + L * PolyZPackedBytes + PolyVecHPackedBytes);

    #endregion
    #region // Template parameter sets.

    ///<summary>Parameter set for Mode 2.</summary> 
    public static MLDSA Mode2 { get; }

    ///<summary>Parameter set for Mode 3.</summary> 
    public static MLDSA Mode3 { get; }

    ///<summary>Parameter set for Mode 5.</summary> 
    public static MLDSA Mode5 { get; }
    #endregion
    #endregion

    #region // Constructors

    /// <summary>
    /// Do a one time initialization of the parameter presets on assembly load.
    /// </summary>
    static MLDSA() {
        Mode2 = new MLDSA(MlDsaMode.Mode44);
        Mode3 = new MLDSA(MlDsaMode.Mode65);
        Mode5 = new MLDSA(MlDsaMode.Mode87);
        }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mode">The Dilithium mode.</param>
    public MLDSA(MlDsaMode mode) {
        Mode = mode;
        }

    #endregion

    /// <summary>
    /// FIPS 204 convenience function H
    /// </summary>
    /// <param name="str">Bytes to digest</param>
    /// <param name="length">Number of bytes</param>
    /// <returns>The SHAK256 digest value</returns> 
    public static byte[] H(byte[] str, int length) => SHAKE256.GetBytes(length * 8, str);


    /// <summary>
    /// FIPS 204 convenience function H
    /// </summary>
    /// <param name="str1">Bytes to digest 1</param>
    /// <param name="str2">Bytes to digest 2</param>
    /// <param name="length">Number of bytes</param>
    /// <returns>The SHAK256 digest value</returns> 
    public static byte[] H(byte[] str1, byte[] str2, int length) =>
                SHAKE256.GetBytes(length * 8, str1, str2);


    /// <summary>
    /// FIPS 204 convenience function H
    /// </summary>
    /// <param name="str1">Bytes to digest 1</param>
    /// <param name="str2">Bytes to digest 2</param>
    /// <param name="str3">Bytes to digest 2</param>
    /// <param name="length">Number of bytes</param>
    /// <returns>The SHAK256 digest value</returns> 
    public static byte[] H(byte[] str1, byte[] str2, byte[] str3, int length) =>
                SHAKE256.GetBytes(length * 8, str1, str2, str3);


    /// <summary>
    /// FIPS 204 convenience function G
    /// </summary>
    /// <param name="str">Bytes to digest</param>
    /// <param name="length">Number of bytes</param>
    /// <returns>The SHAK128 digest value</returns>
    public static byte[] G(byte[] str, int length) => SHAKE256.GetBytes(length * 8, str);


    /// <summary>
    /// FIPS 204 convenience function G
    /// </summary>
    /// <param name="str1">Bytes to digest 1</param>
    /// <param name="str2">Bytes to digest 2</param>
    /// <param name="length">Number of bytes</param>
    /// <returns>The SHAK128 digest value</returns>
    public static byte[] G(byte[] str1, byte[] str2, int length) =>
        SHAKE256.GetBytes(length * 8, str1, str2);



    #region // Generate Key Pair

    /// <summary>
    /// Generate public, private key pair
    /// </summary>
    /// <param name="mode">The dilithium mode to use.</param>
    /// <param name="seed">Optional seed value for deterministic key generation.</param>
    /// <returns>The (public, private) keys.</returns>
    public static (byte[], byte[]) GenerateKeypair(MlDsaMode mode, byte[]? seed = null) => mode switch {
        MlDsaMode.Mode44 => Mode2.GenerateKeypair(seed),
        MlDsaMode.Mode65 => Mode3.GenerateKeypair(seed),
        MlDsaMode.Mode87 => Mode5.GenerateKeypair(seed),
        _ => throw new NYI()
        };

    /// <summary>
    /// Generate public, private key pair
    /// </summary>
    /// <param name="seed">Optional seed value for deterministic key generation.</param>
    /// 
    /// <returns>The (public, private) keys.</returns>
    public (byte[], byte[]) GenerateKeypair(byte[]? seed = null) {

        //GetUnique randomness for rho, rhoprime and key
        seed ??= Platform.GetRandomBytes(SeedBytes);

        //  (𝜌, 𝜌′, 𝐾) ∈ 𝔹32 × 𝔹64 × 𝔹32 ← H(𝜉|| IntegerToBytes(𝑘, 1) || IntegerToBytes(ℓ, 1), 128)
        var seedbuff = H(seed, RhoBytes + RhoPrimeBytes + PrivateRandomSeed);

        var index = 0;
        var rho = seedbuff.ExtractIndexed(ref index, RhoBytes);
        var rhoPrime = seedbuff.ExtractIndexed(ref index, RhoPrimeBytes);
        var key = seedbuff.ExtractIndexed(ref index, PrivateRandomSeed);

        // 𝐀 ← ExpandA(𝜌)
        var mat = PolynomialMatrixInt32.MatrixExpandFromSeed(this, rho);

        //  (𝐬1, 𝐬2) ← ExpandS(𝜌′)
        var s1 = GetVectorL(true);
        s1.UniformEta(rhoPrime, 0);
        var s2 = GetVectorK(true);
        s2.UniformEta(rhoPrime, L);

        //mat.GetHash("Generate Keypair: Matrix  0696-9C1B-30B1");
        //s1.GetHash("Generate Keypair: S1      6871-6921-BD10");
        //s2.GetHash("Generate Keypair: S2      EFAD-D95F-F68C");

        //  𝐭 ← NTT−1(𝐀 ∘̂ NTT(𝐬1)) + 𝐬2
        // Matrix-vector multiplication
        var s1hat = s1.Copy();
        s1hat.NTT();

        //s1hat.GetHash("Generate Keypair: S1hat      ");

        var t1 = mat.MatrixPointwiseMontgomery(s1hat);
        //t1.GetHash("MatrixPointwiseMontgomery      517D-9F33-F9CA");

        t1.Reduce();
        t1.InvNTT2Mont();

        //t1.GetHash("InvNTT2Mont      CE5A-92EF-1DFC");

        // Add error vector s2
        t1.Add(s2);

        // Extract t1 and write public key
        t1.Caddq();

        //  (𝐭1, 𝐭0) ← Power2Round(𝐭)
        var t0 = t1.Power2Round();

        //t0.GetHash("Generate Keypair: T0  D03F-7BE4-914D");
        //t1.GetHash("Generate Keypair: T1  FFA8-A33C-EF64");


        //Test.DumpBufferHex(rho, "rho");

        var pk = PackPublicKey(rho, t1);

        // Compute CRH(rho, t1) and write secret key
        var tr = SHAKE256.GetBytes(TrBytes, pk);
        var sk = PackPrivateKey(rho, tr, key, t0, s1, s2);

        // Ensure all arrays with woroking data are cleared on exit.
        Platform.Wipe(seedbuff, rho, rhoPrime, key);
        Platform.Dispose(mat, t0, s1, s1hat, s2);

        return (pk, sk);
        }

    #endregion
    #region // Create methods for vectors of length K, L.

    /// <summary>
    /// Create returning a <see cref="PolynomialVectorInt32"/> of
    /// length <see cref="L"/>.
    /// </summary>
    /// <param name="wipe">If true, wipe vector parameters on dispose.</param>
    /// <returns>The created vector.</returns>
    public PolynomialVectorInt32 GetVectorL(bool wipe = true)
        => new(this, wipe, false);

    /// <summary>
    /// Create returning a <see cref="PolynomialVectorInt32"/> of
    /// length <see cref="K"/>.
    /// </summary>
    /// <param name="wipe">If true, wipe vector parameters on dispose.</param>
    /// <returns>The created vector.</returns>
    public PolynomialVectorInt32 GetVectorK(bool wipe = true)
        => new(this, wipe, true);

    #endregion
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
    /// For finite field element a with a &lt;= 2^{31} - 2^{22} - 1,
    /// compute r \equiv a (mod Q) such that -6283009 &lt;= r &lt;= 6283007.
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
    /// a mod^+ Q = a1*2^D + a0 with -2^{D-1} &lt; a0 &lt;= 2^{D-1}.
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
    /// that a mod^+ Q = a1*ALPHA + a0 with -ALPHA/2 &lt; a0 &lt;= ALPHA/2 except
    /// if a1 = (Q-1)/ALPHA where we set a1 = 0 and
    /// -ALPHA/2 &lt;= a0 = a mod^+ Q - Q &lt; 0. Assumes a to be standard
    /// representative.
    /// </summary>
    /// <param name="a">input element</param>
    /// <returns>Output elements a0, a1</returns>
    public (int, int) Decompose(int a) {
        var a1 = (a + 127) >> 7;
        if (Gamma2 == Gamma2_32) {
            a1 = (a1 * 1025 + (1 << 21)) >> 22;
            a1 &= 15;
            }
        else {
            a1 = (a1 * 11275 + (1 << 23)) >> 24;
            a1 ^= ((43 - a1) >> 31) & a1;
            }

        var a0 = a - a1 * 2 * Gamma2;
        a0 -= (((Q - 1) / 2 - a0) >> 31) & Q;
        return (a1, a0);
        }

    /// <summary>
    /// Compute hint bit indicating whether the low bits of the
    /// input element overflow into the high bits. Inputs assumed
    /// to be standard representatives.
    /// </summary>
    /// <param name="a0">low bits of input element</param>
    /// <param name="a1">high bits of input element</param>
    /// <returns></returns>
    public int MakeHint(int a0, int a1) {
        if (a0 <= Gamma2 || a0 > Q - Gamma2 || (a0 == Q - Gamma2 && a1 == 0)) {
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

        var (a1, a0) = Decompose(a);
        if (hint == 0) {
            return a1;
            }

        if (Gamma2 == Gamma2_32) {
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
    #region // Pack public, private keys.

    /// <summary>
    /// Pack public key parameters and return the result.
    /// </summary>
    /// <param name="rho">The value rho.</param>
    /// <param name="t1">The value t1.</param>
    /// <returns>The packed public key.</returns>
    public byte[] PackPublicKey(byte[] rho, PolynomialVectorInt32 t1) {

        var result = new byte[PublicKeyBytes];
        var offset = 0;

        rho.Append(result, ref offset);

        for (var i = 0; i < t1.Polynomials.Length; i++) {
            t1.Polynomials[i].PackT1(result, ref offset);
            }

        return result;
        }

    /// <summary>
    /// Pack private key parameters and return the result.
    /// </summary>
    /// <param name="rho">The value rho.</param>
    /// <param name="tr">The value t1.</param>
    /// <param name="key">The value t1.</param>
    /// <param name="t0">The value t1.</param>
    /// <param name="s1">The value t1.</param>
    /// <param name="s2">The value t1.</param>
    /// <returns>The packed private key.</returns>
    public byte[] PackPrivateKey(byte[] rho,
            byte[] tr,
            byte[] key,
            PolynomialVectorInt32 t0,
            PolynomialVectorInt32 s1,
            PolynomialVectorInt32 s2) {

        var result = new byte[PrivateKeyBytes];
        var offset = 0;

        rho.Append(result, ref offset);
        //Test.DumpBufferFingerprint(result, offset, "Private key");

        key.Append(result, ref offset);
        //Test.DumpBufferFingerprint(result, offset, "Private key");

        tr.Append(result, ref offset);
        //Test.DumpBufferFingerprint(result, offset, "Private key");

        for (var i = 0; i < s1.Polynomials.Length; i++) {
            s1.Polynomials[i].PackEta(result, ref offset);
            }
        //Test.DumpBufferFingerprint(result, offset, "Private key s1");

        for (var i = 0; i < s2.Polynomials.Length; i++) {
            s2.Polynomials[i].PackEta(result, ref offset);
            }
        //Test.DumpBufferFingerprint(result, offset, "Private key s2");

        for (var i = 0; i < t0.Polynomials.Length; i++) {
            t0.Polynomials[i].PackT0(result, ref offset);
            }
        //Test.DumpBufferFingerprint(result, offset, "Private key t0");

        return result;
        }

    #endregion

    }


public class Dilithium : MLDSA {

    /*
    D.1 Differences Between Version 3.1 and the Round 3 Version of CRYSTALSDILITHIUM
    The lengths of the variables 𝜌′ (private random seed) and 𝜇 (message representative) in the signing
    algorithm were increased from 384 to 512 bits. The increase in the length of 𝜇 corrects a security flaw
    that appeared in the third-round submission, where a collision attack against SHAKE256 with a 384-bit
    output would make it so that parameters targeting NIST security strength category 5 could only meet
    category 4 [32].
    Additionally, the length of the variable 𝑡𝑟 (the hash of the public key) was reduced from 384 to 256 bits.
    In key generation, the variable 𝜍 was relabeled as 𝜌′ and increased in size from 256 bits to 512 bits

    D.2 Differences Between Version 3.1 of CRYSTALS-DILITHIUM and FIPS 204
    Initial Public Draft
    In order to ensure the properties noted in [14], ML-DSA increases the length of 𝑡𝑟 to 512 bits and increases
    the length of 𝑐 ̃to 384 and 512 bits for the parameter sets ML-DSA-65 and ML-DSA-87, respectively. In
    draft ML-DSA, only the first 256 bits of 𝑐 ̃are used in the generation of 𝑐.
    In Version 3.1 of the CRYSTALS-DILITHIUM submission, the default version of the signing algorithm is
    deterministic with 𝜌′ being generated pseudorandomly from the signer’s private key and the message,
    and an optional version of the signing algorithm has 𝜌′ sampled instead as a 512-bit random string. In
    ML-DSA, 𝜌′ is generated by a “hedged” procedure in which 𝜌′ is pseudorandomly derived from the signer’s
    private key, the message, and a 256-bit string 𝑟𝑛𝑑, which should be generated by an Approved RBG by
    default. The ML-DSA standard also allows for an optional deterministic version in which 𝑟𝑛𝑑 is a 256-bit
    constant string.
    The draft ML-DSA standard also included pseudocode that unintentionally omitted a check for malformed
    input while unpacking the hint [33]. Failure to perform this check results in a signature scheme that is not
    strongly existentially unforgeable [34].

    D.3 Changes From FIPS 204 Initial Public Draf

    In the final version of the ML-DSA standard, the omitted malformed input check was restored to the hint
    unpacking algorithm (Algorithm 21). Additionally, in the final version of ML-DSA, all of the bits of 𝑐 ̃are
    used in the generation of 𝑐 (Algorithm 29), and ExpandMask (Algorithm 34) is modified to take output
    bits from the beginning of the output of H.
    Based on commentsthat were submitted on the draft version, more details were provided for the pre-hash
    version HashML-DSA in Section 5.4. These modifications include domain separation for the cases in which
    the message is signed directly and cases in which a digest of the message is signed. The changes were
    made by explicitly defining external functions for both versions of the signing and verification functions
    that call an internal function corresponding to the signing or verification functions from the draft FIPS.
    Domain separation is included in the input to the internal function (see Algorithms 2, 3, 4, 5, 7, and 8).
    To simplify APIs and for testing purposes, this document also introduced a similar external/internal split
    for key generation (see Algorithms 1 and 6), but this is a purely editorial change, as the external key
    generation algorithm is functionally equivalent to the key-generation algorithm from the draft FIPS.
    Finally, to offer misuse resistance against the possibility that keys for different parameter sets might be
    expanded from the same seed [35], domain separation was added to line 1 of Algorithm 6

     */

    ///<inheritdoc/>
    public override int RhoPrimeBytes => 32;

    ///<inheritdoc/>
    public override int TrBytes => 48;

    public Dilithium(MlDsaMode mode) : base(mode) {
        }
    //MrsBytes = 48;
    //        PrsBytes = 48;
    //        TrBytes = 48;
    //        SigmaBytes = 32;
    //        CSquigleByles = 48;
    }