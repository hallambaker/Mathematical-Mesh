

namespace Goedel.Cryptography.PQC;

/// <summary>
/// Operations on polynomials expressed as a list of coefficients for use in Dilithium.
/// Could be adapted to other applications if required.
/// </summary>
public class PolynomialInt32 : Disposable {
    #region // Fields and Properties
    const int stream128BlockBytes = 168;
    const int stream256BlockBytes = 136;

    ///<summary>The polynomial coefficients.</summary> 
    public int[] Coefficients;

    ///<summary>The number of polynomial coefficients.</summary> 
    public int N { get; }
    int Eta => Parameters.Eta;


    static int D => MLDSA.D;
    const int Q = MLDSA.Q;

    MLDSA Parameters { get; }


    //delegate int RejectDelegate (byte[] buf, int ctr);

    //RejectDelegate RejectUniform;


    #region // Zetas, InvZetas
    readonly int[] Zetas = new int[] {
                 0,    25847, -2608894,  -518909,   237124,  -777960,  -876248,   466468,
           1826347,  2353451,  -359251, -2091905,  3119733, -2884855,  3111497,  2680103,
           2725464,  1024112, -1079900,  3585928,  -549488, -1119584,  2619752, -2108549,
          -2118186, -3859737, -1399561, -3277672,  1757237,   -19422,  4010497,   280005,
           2706023,    95776,  3077325,  3530437, -1661693, -3592148, -2537516,  3915439,
          -3861115, -3043716,  3574422, -2867647,  3539968,  -300467,  2348700,  -539299,
          -1699267, -1643818,  3505694, -3821735,  3507263, -2140649, -1600420,  3699596,
            811944,   531354,   954230,  3881043,  3900724, -2556880,  2071892, -2797779,
          -3930395, -1528703, -3677745, -3041255, -1452451,  3475950,  2176455, -1585221,
          -1257611,  1939314, -4083598, -1000202, -3190144, -3157330, -3632928,   126922,
           3412210,  -983419,  2147896,  2715295, -2967645, -3693493,  -411027, -2477047,
           -671102, -1228525,   -22981, -1308169,  -381987,  1349076,  1852771, -1430430,
          -3343383,   264944,   508951,  3097992,    44288, -1100098,   904516,  3958618,
          -3724342,    -8578,  1653064, -3249728,  2389356,  -210977,   759969, -1316856,
            189548, -3553272,  3159746, -1851402, -2409325,  -177440,  1315589,  1341330,
           1285669, -1584928,  -812732, -1439742, -3019102, -3881060, -3628969,  3839961,
           2091667,  3407706,  2316500,  3817976, -3342478,  2244091, -2446433, -3562462,
            266997,  2434439, -1235728,  3513181, -3520352, -3759364, -1197226, -3193378,
            900702,  1859098,   909542,   819034,   495491, -1613174,   -43260,  -522500,
           -655327, -3122442,  2031748,  3207046, -3556995,  -525098,  -768622, -3595838,
            342297,   286988, -2437823,  4108315,  3437287, -3342277,  1735879,   203044,
           2842341,  2691481, -2590150,  1265009,  4055324,  1247620,  2486353,  1595974,
          -3767016,  1250494,  2635921, -3548272, -2994039,  1869119,  1903435, -1050970,
          -1333058,  1237275, -3318210, -1430225,  -451100,  1312455,  3306115, -1962642,
          -1279661,  1917081, -2546312, -1374803,  1500165,   777191,  2235880,  3406031,
           -542412, -2831860, -1671176, -1846953, -2584293, -3724270,   594136, -3776993,
          -2013608,  2432395,  2454455,  -164721,  1957272,  3369112,   185531, -1207385,
          -3183426,   162844,  1616392,  3014001,   810149,  1652634, -3694233, -1799107,
          -3038916,  3523897,  3866901,   269760,  2213111,  -975884,  1717735,   472078,
           -426683,  1723600, -1803090,  1910376, -1667432, -1104333,  -260646, -3833893,
          -2939036, -2235985,  -420899, -2286327,   183443,  -976891,  1612842, -3545687,
           -554416,  3919660,   -48306, -1362209,  3937738,  1400424,  -846154,  1976782
        };

    #endregion



    #endregion

    #region // Disposing
    ///<summary>If true, data is wiped on dispose.</summary> 
    public bool Wipe { get; } = true;

    ///<inheritdoc/>
    protected override void Disposing() {
        if (!Wipe) {
            return;
            }
        for (var v = 0; v < Parameters.K; v++) {
            Array.Clear(Coefficients);
            }
        }

    #endregion
    #region // Constructors and factory methods

    /// <summary>
    /// Constructor, return polynomial according to parameters specified in
    /// <paramref name="parameters"/>. If the parameter <paramref name="wipe"/>
    /// is true, the coefficients will be cleared before memory is released.
    /// </summary>
    /// <param name="parameters">The Dilithium parameters.</param>
    /// <param name="wipe">If true, contents wiped on dispose.</param>
    public PolynomialInt32(MLDSA parameters, bool wipe = true) {
        Wipe = wipe;
        Parameters = parameters;

        // Fix N so the compiler knows that it cannot change inside a loop.
        N = MLDSA.N;
        Coefficients = new int[N];

        }

    #endregion

    #region // Basic vector operations - Add, Sub, SubFrom, Copy, ShiftLeft

    /// <summary>
    /// Add the coefficients of the polynomial <paramref name="p"/> to this.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void Add(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            Coefficients[c] += p.Coefficients[c];
            }
        }

    /// <summary>
    /// Subtract the coefficients of polynomial <paramref name="p"/> and return 
    /// the result in place.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void Sub(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            Coefficients[c] -= p.Coefficients[c];
            }
        }

    /// <summary>
    /// Subtract the coefficients of this from the polynomial <paramref name="p"/>
    /// and return the result in place.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void SubFrom(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            Coefficients[c] = p.Coefficients[c] - Coefficients[c];
            }
        }

    #endregion
    #region // Inplace operations on Polynomials - Caddq, Reduce32, Freeze, ShiftLeft
    /// <summary>
    /// For all coefficients add Q if coefficient is negative
    /// </summary>
    public void Caddq() {
        for (var c = 0; c < N; c++) {
            Coefficients[c] = MLDSA.Caddq(Coefficients[c]);
            }
        }

    /// <summary>
    /// Inplace reduction of all coefficients of polynomial to
    /// in [-6283009,6283007].
    /// </summary>
    public void Reduce32() {
        for (var c = 0; c < N; c++) {
            Coefficients[c] = MLDSA.Reduce32(Coefficients[c]);
            }
        }

    /// <summary>
    /// Inplace reduction of all coefficients of polynomial to
    /// standard representatives.
    /// </summary>
    public void Freeze() {
        for (var c = 0; c < N; c++) {
            Coefficients[c] = MLDSA.Freeze(Coefficients[c]);
            }
        }

    /// <summary>
    /// Multiply polynomial by 2^D without modular reduction. Assumes
    /// input coefficients to be less than 2^{31-D} in absolute value.
    /// </summary>
    public void ShiftLeft() {
        for (var c = 0; c < N; c++) {
            Coefficients[c] <<= MLDSA.D;
            }
        }
    #endregion
    #region // Uniform expansions from a nonced seed - Uniform, UniformEta, UniformGamma1, RejectUniformX, RejectETA

    /// <summary>
    /// Compute uniformly distributed Q values from <paramref name="seed"/>, 
    /// <paramref name="nonce"/> across.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    /// <param name="nonce">The nonce value.</param>
    public void Uniform(byte[] seed, int nonce) {
        using var shake = new SHAKEExtended();

        var nblocks = (768 + stream128BlockBytes - 1) / stream128BlockBytes;
        var buf = new byte[nblocks * stream128BlockBytes];

        shake.AbsorbD(seed, nonce);
        shake.Squeeze(buf, nblocks);

        var ctr = RejectUniform(buf, 0);
        while (ctr < N) {
            shake.Squeeze(buf, 1);
            ctr = RejectUniform(buf, ctr);
            }
        }

    /// <summary>
    /// Compute uniformly distributed Eta values from <paramref name="seed"/>, 
    /// <paramref name="nonce"/> across.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    /// <param name="nonce">The nonce value.</param>
    public void UniformEta(byte[] seed, int nonce) {
        using var shake = new SHAKEExtended();

        var nblocks = Parameters.Eta switch {
            2 => (136 + stream128BlockBytes - 1) / stream128BlockBytes,
            4 => (227 + stream128BlockBytes - 1) / stream128BlockBytes,
            _ => throw new Exception()
            };
        var buf = new byte[nblocks * stream128BlockBytes];

        shake.AbsorbD(seed, nonce);
        shake.Squeeze(buf, nblocks);

        var ctr = RejectETA(buf, 0);
        while (ctr < N) {
            shake.Squeeze(buf, 1);
            ctr = RejectETA(buf, ctr);
            }
        }

    /// <summary>
    /// Compute uniformly distributed Gamma1 values from <paramref name="seed"/>, 
    /// <paramref name="nonce"/> across. This has been replaced in FIPS204 final.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    /// <param name="nonce">The nonce value.</param>
    public void ExpandMask(byte[] seed, int nonce) {

        var nblocks = Parameters.Gamma1 switch {
            (1 << 17) => (576 + stream256BlockBytes - 1) / stream256BlockBytes,
            (1 << 19) => (640 + stream256BlockBytes - 1) / stream256BlockBytes,
            _ => throw new Exception()
            };

        using var shake = SHAKEExtended.Shake256();
        shake.AbsorbD(seed, nonce);

        var buf = new byte[nblocks * stream256BlockBytes];
        shake.Squeeze(buf, nblocks);

        var offset = 0;
        UnpackZ(buf, ref offset);
        }

    /// <summary>
    /// Return a challenge polynomial against <paramref name="seed"/>.
    /// </summary>
    /// <param name="seed">The seed value.</param>
    public void Challenge(byte[] seed) {

        //var buf = new byte[SHA3.HashRateShake256];
        var buf = new byte[1];


        using var shake = SHAKEExtended.Shake256();
        shake.Absorb(seed);
        shake.Squeeze(buf, 1);

        uint b;

        ulong signs = 0;
        for (var i = 0; i < 8; ++i)
            signs |= (ulong)buf[i] << 8 * i;
        var pos = 8;

        for (var i = 0; i < N; ++i) {
            Coefficients[i] = 0;
            }
        for (var i = N - Parameters.Tau; i < N; ++i) {
            do {

                // Dilithium version of this
                //if (pos >= SHA3.HashRateShake256) {
                //    shake.Squeeze(buf, 1);
                //    pos = 0;
                //    }
                //b = buf[pos++];

                shake.Squeeze(buf, 1);
                b = buf[0];
                } while (b > i);

            Coefficients[i] = Coefficients[b];
            Coefficients[b] = 1 - 2 * (int)(signs & 1);
            signs >>= 1;
            }
        }



    /// <summary>
    /// Fill coefficients from <paramref name="buffer"/> starting with coefficient
    /// <paramref name="index"/> rejecting uniformly values outside <see cref="Q"/>.
    /// </summary>
    /// <param name="buffer">The buffer to sample.</param>
    /// <param name="index">The first coefficient index to fill.</param>
    /// <returns>The new index value.</returns>
    public int RejectUniform(byte[] buffer, int index) {

        var pos = 0;
        while (index < N & pos < buffer.Length) {
            var t = (uint)buffer[pos++];
            t |= (uint)(buffer[pos++] << 8);
            t |= (uint)(buffer[pos++] << 16);
            t &= 0x7FFFFF;

            if (t < MLDSA.Q) {
                Coefficients[index++] = (int)t;
                }
            }
        return index;
        }

    /// <summary>
    /// Fill coefficients from <paramref name="buffer"/> starting with coefficient
    /// <paramref name="index"/> rejecting uniformly values outside <see cref="Eta"/>.
    /// </summary>
    /// <param name="buffer">The buffer to sample.</param>
    /// <param name="index">The first coefficient index to fill.</param>
    /// <returns>The new index value.</returns>
    public int RejectETA(byte[] buffer, int index) {

        var pos = 0;
        while (index < N & pos < buffer.Length) {
            var t0 = (uint)(buffer[pos] & 0xF);
            var t1 = (uint)(buffer[pos++] >> 4);

            switch (Parameters.Eta) {
                case 2: {
                    if (t0 < 15) {
                        t0 -= (205 * t0 >> 10) * 5;
                        Coefficients[index++] = (int)(2 - t0);
                        }
                    if (t1 < 15 & index < N) {
                        t1 -= (205 * t1 >> 10) * 5;
                        Coefficients[index++] = (int)(2 - t1);
                        }
                    break;
                    }
                case 4: {
                    if (t0 < 9) {
                        Coefficients[index++] = (int)(4 - t0);
                        }
                    if (t1 < 9 & index < N) {
                        Coefficients[index++] = (int)(4 - t1);
                        }
                    break;
                    }
                }
            }
        return index;
        }


    #endregion
    #region // Vector transformations - NTT, InvNTT2Mont

    /// <summary>
    /// Forward NTT, in-place. No modular reduction is performed after
    ///  additions or subtractions. Output vector is in bitreversed order.
    /// </summary>
    public void NTT() {
        int zeta;
        int j;

        int k = 0;
        for (var len = 128; len > 0; len >>= 1) {
            for (var start = 0; start < N; start = j + len) {
                zeta = Zetas[++k];
                for (j = start; j < start + len; ++j) {
                    var t = MLDSA.MontgomeryReduce((long)zeta * Coefficients[j + len]);
                    Coefficients[j + len] = Coefficients[j] - t;
                    Coefficients[j] = Coefficients[j] + t;



                    //Console.WriteLine($"{len}: {start}: {j} t={t}");
                    }
                }
            }
        }

    /// <summary>
    /// Inverse NTT, in-place with implicit Montgomery tranformation.
    /// </summary>
    public void InvNTT2Mont() {

        const int f = 41978; // mont^2/256

        int zeta;
        int j;

        int k = 256;
        for (var len = 1; len < N; len <<= 1) {
            for (var start = 0; start < N; start = j + len) {
                zeta = -Zetas[--k];
                for (j = start; j < start + len; ++j) {
                    var t = Coefficients[j];
                    Coefficients[j] = t + Coefficients[j + len];
                    Coefficients[j + len] = t - Coefficients[j + len];
                    Coefficients[j + len] = MLDSA.MontgomeryReduce((long)zeta * Coefficients[j + len]);
                    }
                }
            }

        for (j = 0; j < N; ++j) {
            Coefficients[j] = MLDSA.MontgomeryReduce((long)f * Coefficients[j]);
            }

        }

    #endregion
    #region // Montgomery operations - PointwiseAccMontgomery

    /// <summary>
    /// Perform pointwise Montgomery operation on coefficients of
    /// <paramref name="a"/> and <paramref name="b"/> and return result 
    /// in place.
    /// </summary>
    /// <param name="a">First polynomial.</param>
    /// <param name="b">Second polynomial.</param>
    public void PointwiseMontgomery(PolynomialInt32 a, PolynomialInt32 b) {
        for (var i = 0; i < N; i++) {
            Coefficients[i] = MLDSA.MontgomeryReduce((long)a.Coefficients[i] * (long)b.Coefficients[i]);
            }
        }

    #endregion
    #region // Operations on vectors - Chknorm, Power2Round, Decompose


    /// <summary>
    /// Check infinity norm of polynomial against given bound.
    ///  Assumes input coefficients were reduced by reduce32().
    /// </summary>
    /// <param name="bound">norm bound</param>
    /// <returns>Returns False if norm is strictly smaller than B &lt;= (Q-1)/8 and True otherwise.</returns>

    public bool Chknorm(int bound) {
        // It is ok to leak which coefficient violates the bound since
        // the probability for each coefficient is independent of secret
        // data but we must not leak the sign of the centralized representative.

        if (bound > (Q - 1) / 8) {
            return true;
            }
        for (var c = 0; c < N; c++) {
            var t = Coefficients[c] >> 31;
            t = Coefficients[c] - (t & 2 * Coefficients[c]);
            if (t >= bound) {
                return true;
                }
            }

        return false;
        }

    /// <summary>
    /// Subtract the coefficients of this from the polynomial <paramref name="p"/>
    /// and return the result in place.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void Power2Round(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            (p.Coefficients[c], Coefficients[c]) = MLDSA.Power2Round(Coefficients[c]);
            }
        }


    /// <summary>
    /// Subtract the coefficients of this from the polynomial <paramref name="p"/>.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void Decompose(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            (Coefficients[c], p.Coefficients[c]) = Parameters.Decompose(Coefficients[c]);
            }
        }

    #endregion
    #region // Making and using hint vectors


    /// <summary>
    /// Compute hint vector and return in place.
    /// </summary>
    /// <param name="w0">Low part of input vector</param>
    /// <param name="w1">High part of input vector</param>
    /// <returns>Number of high bits</returns>
    public int MakeHint(PolynomialInt32 w0, PolynomialInt32 w1) {
        var s = 0;
        for (var c = 0; c < N; c++) {
            Coefficients[c] = Parameters.MakeHint(w0.Coefficients[c], w1.Coefficients[c]);
            s += Coefficients[c];
            }
        return s;
        }


    /// <summary>
    /// Subtract the coefficients of this from the polynomial <paramref name="p"/>.
    /// </summary>
    /// <param name="p">The vector to add</param>
    public void UseHint(PolynomialInt32 p) {
        for (var c = 0; c < N; c++) {
            Coefficients[c] = Parameters.UseHint(Coefficients[c], p.Coefficients[c]);
            }

        }




    #endregion
    #region // Packaging


    //static void PackBits(int coefficient, int bits, byte[] buffer, ref int offset, ref int bit) {

    //    if (bits - bit >= 8) {
    //        buffer[offset++] |= (byte)(coefficient >> bit);
    //        bit += 8;
    //        }
    //    if (bits - bit >= 8) {
    //        buffer[offset++] = (byte)(coefficient >> bit);
    //        bit += 8;
    //        }
    //    if (bits - bit >= 8) {
    //        buffer[offset++] = (byte)(coefficient >> bit);
    //        bit += 8;
    //        }

    //    if (bits - bit > 0) {
    //        buffer[offset++] = (byte)(coefficient >> bit);
    //        bit = 8 + bit - bits;
    //        }
    //    }


    //public void Pack(int bits, byte[] buffer, ref int offset) {
    //    var bit = 0;
    //    for (var i = 0; i < N; i++) {
    //        PackBits(Coefficients[i], bits, buffer, ref offset, ref bit);

    //        }

    //    }

    #region // Pack Eta
    /// <summary>
    /// Pack coefficients to <paramref name="buffer"/> as Z data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to write vector to.</param>
    /// <param name="offset">Index of first byte to write on entry and index of
    /// next byte to write to on exit.</param>
    public void PackEta(byte[] buffer, ref int offset) {

        if (Eta == 2) {
            for (var i = 0; i < N / 8; i++) {
                var t0 = (byte)(Eta - Coefficients[8 * i + 0]);
                var t1 = (byte)(Eta - Coefficients[8 * i + 1]);
                var t2 = (byte)(Eta - Coefficients[8 * i + 2]);
                var t3 = (byte)(Eta - Coefficients[8 * i + 3]);
                var t4 = (byte)(Eta - Coefficients[8 * i + 4]);
                var t5 = (byte)(Eta - Coefficients[8 * i + 5]);
                var t6 = (byte)(Eta - Coefficients[8 * i + 6]);
                var t7 = (byte)(Eta - Coefficients[8 * i + 7]);

                buffer[offset++] = (byte)((t0 >> 0) | (t1 << 3) | (t2 << 6));
                buffer[offset++] = (byte)((t2 >> 2) | (t3 << 1) | (t4 << 4) | (t5 << 7));
                buffer[offset++] = (byte)((t5 >> 1) | (t6 << 2) | (t7 << 5));
                }
            }
        else {
            for (var i = 0; i < N / 2; i++) {
                var t0 = (byte)(Eta - Coefficients[2 * i + 0]);
                var t1 = (byte)(Eta - Coefficients[2 * i + 1]);

                buffer[offset++] = (byte)(t0 | (t1 << 4));
                }
            }

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <exception cref="NYI"></exception>
    public void UnpackEta(byte[] buffer, ref int offset) {
        if (Parameters.Eta == 2) {
            for (var i = 0; i < N / 8; i++) {
                var b0 = buffer[offset++];
                var b1 = buffer[offset++];
                var b2 = buffer[offset++];

                Coefficients[8 * i + 0] = Eta - ((b0 >> 0) & 7);
                Coefficients[8 * i + 1] = Eta - ((b0 >> 3) & 7);
                Coefficients[8 * i + 2] = Eta - (((b0 >> 6) & 7) | ((b1 << 2) & 7));
                Coefficients[8 * i + 3] = Eta - ((b1 >> 1) & 7);
                Coefficients[8 * i + 4] = Eta - ((b1 >> 4) & 7);
                Coefficients[8 * i + 5] = Eta - (((b1 >> 7) & 7) | ((b2 << 1) & 7));
                Coefficients[8 * i + 6] = Eta - ((b2 >> 2) & 7);
                Coefficients[8 * i + 7] = Eta - ((b2 >> 5) & 7);
                }
            }
        else {
            for (var i = 0; i < N / 2; i++) {
                var b0 = buffer[offset++];
                var b1 = buffer[offset++];

                Coefficients[8 * i + 0] = Eta - (b0 & 0xf);
                Coefficients[8 * i + 0] = Eta - (b1 >> 4);
                }
            }


        }

    #endregion
    #region // Pack T1

    /// <summary>
    /// Pack coefficients to <paramref name="buffer"/> as Z data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to write vector to.</param>
    /// <param name="offset">Index of first byte to write on entry and index of
    /// next byte to write to on exit.</param>
    public void PackT1(byte[] buffer, ref int offset) {
        for (var i = 0; i < N / 4; i++) {
            var t0 = Coefficients[4 * i + 0];
            var t1 = Coefficients[4 * i + 1];
            var t2 = Coefficients[4 * i + 2];
            var t3 = Coefficients[4 * i + 3];

            buffer[offset++] = (byte)(t0 >> 0);
            buffer[offset++] = (byte)((t0 >> 8) | (t1 << 2));
            buffer[offset++] = (byte)((t1 >> 6) | (t2 << 4));
            buffer[offset++] = (byte)((t2 >> 4) | (t3 << 6));
            buffer[offset++] = (byte)(t3 >> 2);
            }
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <exception cref="NYI"></exception>
    public void UnpackT1(byte[] buffer, ref int offset) {
        for (var i = 0; i < N / 4; i++) {
            var b0 = buffer[offset++];
            var b1 = buffer[offset++];
            var b2 = buffer[offset++];
            var b3 = buffer[offset++];
            var b4 = buffer[offset++];

            Coefficients[4 * i + 0] = ((b0 >> 0) | (b1 << 8) & 0x3FF);
            Coefficients[4 * i + 1] = ((b1 >> 2) | (b2 << 6) & 0x3FF);
            Coefficients[4 * i + 2] = ((b2 >> 4) | (b3 << 4) & 0x3FF);
            Coefficients[4 * i + 3] = ((b3 >> 6) | (b4 << 2) & 0x3FF);
            }
        }

    #endregion
    #region // PackT0
    /// <summary>
    /// Pack coefficients to <paramref name="buffer"/> as Z data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to write vector to.</param>
    /// <param name="offset">Index of first byte to write on entry and index of
    /// next byte to write to on exit.</param>
    public void PackT0(byte[] buffer, ref int offset) {

        var d = 1 << (D - 1);
        for (var i = 0; i < N / 8; i++) {
            var t0 = (d - Coefficients[8 * i + 0]);
            var t1 = (d - Coefficients[8 * i + 1]);
            var t2 = (d - Coefficients[8 * i + 2]);
            var t3 = (d - Coefficients[8 * i + 3]);
            var t4 = (d - Coefficients[8 * i + 4]);
            var t5 = (d - Coefficients[8 * i + 5]);
            var t6 = (d - Coefficients[8 * i + 6]);
            var t7 = (d - Coefficients[8 * i + 7]);

            buffer[offset++] = (byte)t0;                           //  0
            buffer[offset++] = (byte)((t0 >> 8) | (t1 << 5));       //  1
            buffer[offset++] = (byte)(t1 >> 3);                    //  2
            buffer[offset++] = (byte)((t1 >> 11) | (t2 << 2));       //  3
            buffer[offset++] = (byte)((t2 >> 6) | (t3 << 7));       //  4
            buffer[offset++] = (byte)(t3 >> 1);                     //  5
            buffer[offset++] = (byte)((t3 >> 9) | (t4 << 4));       //  6
            buffer[offset++] = (byte)(t4 >> 4);                     //  7
            buffer[offset++] = (byte)((t4 >> 12) | (t5 << 1));       //  8
            buffer[offset++] = (byte)((t5 >> 7) | (t6 << 6));       //  9
            buffer[offset++] = (byte)(t6 >> 2);                     // 10
            buffer[offset++] = (byte)((t6 >> 10) | (t7 << 3));       // 11
            buffer[offset++] = (byte)(t7 >> 5);                     // 12
            }
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <exception cref="NYI"></exception>
    public void UnpackT0(byte[] buffer, ref int offset) {
        var d = 1 << (D - 1);

        for (var i = 0; i < N / 8; i++) {
            var b0 = buffer[offset++];
            var b1 = buffer[offset++];
            var b2 = buffer[offset++];
            var b3 = buffer[offset++];
            var b4 = buffer[offset++];
            var b5 = buffer[offset++];
            var b6 = buffer[offset++];
            var b7 = buffer[offset++];
            var b8 = buffer[offset++];
            var b9 = buffer[offset++];
            var b10 = buffer[offset++];
            var b11 = buffer[offset++];
            var b12 = buffer[offset++];

            Coefficients[8 * i + 0] = d - (((b0 >> 0) | (b1 << 8)) & 0x1FFF);
            Coefficients[8 * i + 1] = d - (((b1 >> 5) | (b2 << 3) | (b3 << 11)) & 0x1FFF);
            Coefficients[8 * i + 2] = d - (((b3 >> 2) | (b4 << 6)) & 0x1FFF);
            Coefficients[8 * i + 3] = d - (((b4 >> 7) | (b5 << 1) | (b6 << 9)) & 0x1FFF);
            Coefficients[8 * i + 4] = d - (((b6 >> 4) | (b7 << 4) | (b8 << 12)) & 0x1FFF);
            Coefficients[8 * i + 5] = d - (((b8 >> 1) | (b9 << 7)) & 0x1FFF);
            Coefficients[8 * i + 6] = d - (((b9 >> 6) | (b10 << 2) | (b11 << 10)) & 0x1FFF);
            Coefficients[8 * i + 7] = d - (((b11 >> 3) | (b12 << 5)) & 0x1FFF);
            }

        }

    #endregion
    #region // PackZ

    /// <summary>
    /// Pack coefficients to <paramref name="buffer"/> as Z data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to write vector to.</param>
    /// <param name="offset">Index of first byte to write on entry and index of
    /// next byte to write to on exit.</param>
    public void PackZ(byte[] buffer, ref int offset) {
        if (Parameters.Gamma1 == MLDSA.Gamma1_19) {
            for (var i = 0; i < N / 2; i++) {
                var t0 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 0]);
                var t1 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 1]);

                buffer[offset++] = (byte)t0;
                buffer[offset++] = (byte)(t0 >> 8);
                buffer[offset++] = (byte)((t0 >> 16) | (byte)(t1 << 4));
                buffer[offset++] = (byte)(t1 >> 4);
                buffer[offset++] = (byte)(t1 >> 12);
                }
            }
        else {

            for (var i = 0; i < N / 4; i++) {
                var t0 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 0]);
                var t1 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 1]);
                var t2 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 2]);
                var t3 = (uint)(Parameters.Gamma1 - Coefficients[2 * i + 3]);

                buffer[offset++] = (byte)t0;
                buffer[offset++] = (byte)(t0 >> 8);
                buffer[offset++] = (byte)((t0 >> 16) | (byte)(t1 << 2));
                buffer[offset++] = (byte)(t1 >> 6);
                buffer[offset++] = (byte)((t1 >> 14) | (byte)(t2 << 4));
                buffer[offset++] = (byte)(t2 >> 4);
                buffer[offset++] = (byte)((t2 >> 12) | (byte)(t3 << 6));
                buffer[offset++] = (byte)(t3 >> 2);
                buffer[offset++] = (byte)(t3 >> 10);
                }
            }
        }

    /// <summary>
    /// Unack coefficients to <paramref name="buffer"/> as Z data, starting at 
    /// <paramref name="offset"/> and updating <paramref name="offset"/> to point
    /// to next unwritten byte.
    /// </summary>
    /// <param name="buffer">Buffer to read vector from.</param>
    /// <param name="offset">Index of first byte to read on entry and index of
    /// next byte to read to on exit.</param>
    public void UnpackZ(byte[] buffer, ref int offset) {
        if (Parameters.Gamma1 == MLDSA.Gamma1_19) {
            for (var i = 0; i < N / 2; i++) {
                var b0 = buffer[offset++];
                var b1 = buffer[offset++];
                var b2 = buffer[offset++];
                var b3 = buffer[offset++];
                var b4 = buffer[offset++];


                var c0 = (b0 | (b1 << 8) | (b2 << 16)) & 0xFFFFF;
                var c1 = ((b2 >> 4) | (b3 << 4) | (b4 << 12)) & 0xFFFFF;

                Coefficients[2 * i + 0] = (int)(MLDSA.Gamma1_19 - c0);
                Coefficients[2 * i + 1] = (int)(MLDSA.Gamma1_19 - c1);
                }
            }
        else {
            for (var i = 0; i < N / 4; i++) {
                var b0 = buffer[offset++];
                var b1 = buffer[offset++];
                var b2 = buffer[offset++];
                var b3 = buffer[offset++];
                var b4 = buffer[offset++];
                var b5 = buffer[offset++];
                var b6 = buffer[offset++];
                var b7 = buffer[offset++];
                var b8 = buffer[offset++];

                var c0 = (b0 | (b1 << 8) | (b2 << 16)) & 0x3FFFF;
                var c1 = ((b3 >> 2) | (b3 << 6) | (b4 << 14)) & 0x3FFFF;
                var c2 = ((b4 >> 4) | (b5 << 4) | (b6 << 12)) & 0x3FFFF;
                var c3 = ((b6 >> 6) | (b7 << 2) | (b8 << 10)) & 0x3FFFF;

                Coefficients[2 * i + 0] = (int)(MLDSA.Gamma1_19 - c0);
                Coefficients[2 * i + 1] = (int)(MLDSA.Gamma1_19 - c1);
                Coefficients[2 * i + 2] = (int)(MLDSA.Gamma1_19 - c2);
                Coefficients[2 * i + 3] = (int)(MLDSA.Gamma1_19 - c3);
                }
            }

        }

    #endregion
    #region // Pack W1

    /// <summary>
    /// Bit-pack polynomial w1 with coefficients in [0,15] or [0,43].
    /// Input coefficients are assumed to be standard representatives.
    /// </summary>
    /// <param name="buffer">Output buffer.</param>
    /// <param name="offset">Index of first byte to be written.</param>

    public void PackW1(byte[] buffer, ref int offset) {
        if (Parameters.Gamma2 == MLDSA.Gamma2_88) {
            for (var i = 0; i < N / 4; i++) {
                var t0 = Coefficients[8 * i + 0];
                var t1 = Coefficients[8 * i + 1];
                var t2 = Coefficients[8 * i + 2];
                var t3 = Coefficients[8 * i + 3];

                buffer[offset++] = (byte)((t0) | (t1 << 6));
                buffer[offset++] = (byte)((t1 >> 2) | (t2 << 4));
                buffer[offset++] = (byte)((t2 >> 4) | (t3 << 2));
                }
            }
        else {
            for (var i = 0; i < N / 2; i++) {
                buffer[offset++] = (byte)(Coefficients[2 * i + 0] | (Coefficients[2 * i + 1] << 4));
                }
            }
        }

    #endregion
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
    public string GetHash(
                    string tag,
                    TextWriter output = null) {

        output ??= Console.Out;

        var d2 = Coefficients.Length;

        int size = d2 * 4;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var k = 0; k < d2; k++) {
            var data = Coefficients[k];
            buffer[offset++] = (byte)(data & 0xff);
            buffer[offset++] = (byte)(data >> 8);
            buffer[offset++] = (byte)(data >> 16);
            buffer[offset++] = (byte)(data >> 24);
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