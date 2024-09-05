namespace Goedel.Cryptography.PQC;

/// <summary>
/// Operations on matrix of polynomials expressed as a list of coefficients 
/// for use in Kyber. Could be adapted to other applications if required.
/// </summary>
public struct PolynomialMatrixInt16 {

    #region // Properties and fields
    ///<summary>The coeficients vectors.</summary> 
    public PolynomialVectorInt16[] PolynomialVector;

    ///<summary></summary> 
    public const int GEN_MATRIX_BYTES = 12 * MlKem.N / 8 * (1 << 12) / MlKem.Q + SHA3.HashRateShake128;

    ///<summary></summary> 
    public const int GEN_MATRIX_NBLOCKS = GEN_MATRIX_BYTES / SHA3.HashRateShake128;
    #endregion

    #region // Disposing
    //bool Wipe { get; } = true;
    //protected override void Disposing() {
    //    if (!Wipe) {
    //        return;
    //        }
    //    //for (var v = 0; v < Parameters.K; v++) {
    //    //    Vectors[v].Dispose();
    //    //    }
    //    }
    #endregion

    /// <summary>
    /// Constructor, create a Kyber matrix of size 
    /// <paramref name="k"/>.<paramref name="k"/>.<see cref="MlKem.N"/>.
    /// </summary>
    /// <param name="k">The number of polynomials and coefficient vectors per polynomial.</param>
    public PolynomialMatrixInt16(int k) {
        PolynomialVector = new PolynomialVectorInt16[k];
        for (var i = 0; i < k; i++) {
            PolynomialVector[i] = new PolynomialVectorInt16(k);
            for (var j = 0; j < k; j++) {
                PolynomialVector[i].Vector[j] = new PolynomialInt16();
                }
            }
        }


    /// <summary>
    /// Generate a new matrix from the seed value <paramref name="seed"/>.
    /// </summary>
    /// <param name="kyberK">The number of polynomial vectors..</param>
    /// <param name="seed">The seed value.</param>
    /// <param name="transposed">If true, transpose the matrix when absorbing the seed.</param>
    /// <returns>A matrix of short integers [K,K,N] initialized according to
    /// the seed <paramref name="seed"/></returns>
    public static PolynomialMatrixInt16 MatrixExpandFromSeed(int kyberK, byte[] seed, bool transposed = false) {
        var a = new PolynomialMatrixInt16(kyberK);
        ulong[] state;

        var buf = new byte[GEN_MATRIX_BYTES + 2];
        uint ctr;

        using var shake = new SHAKEExtended();

        for (var i = 0; i < kyberK; i++) {
            for (var j = 0; j < kyberK; j++) {
                if (transposed) {
                    state = shake.Absorb(seed, i, j);
                    }
                else {
                    state = shake.Absorb(seed, j, i);
                    }

                var buflen = GEN_MATRIX_NBLOCKS * SHA3.HashRateShake128;

                //DumpVector(state);
                shake.Squeeze(buf, GEN_MATRIX_NBLOCKS);

                //Test.DumpBufferHex(buf, buflen);

                ctr = a.PolynomialVector[i].Vector[j].RejUniform(buf, buflen);

                //Console.WriteLine($"{ctr}");
                //ctr -= 20; // NASTY HACK HERE


                while (ctr < MlKem.N) {
                    var off = buflen % 3;

                    for (var k = 0; k < off; k++) {
                        buf[k] = buf[buflen - off + k];
                        }
                    shake.Squeeze(buf, 1, off);
                    buflen = off + SHA3.HashRateShake128;

                    ctr = a.PolynomialVector[i].Vector[j].RejUniform(buf, buflen, ctr);
                    }
                }
            }



        return a;
        }



    #region // Diagnostics
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
        var d0 = PolynomialVector.GetLength(0);
        var d1 = d0;
        var d2 = MlKem.N;

        int size = d0 * d1 * d2 * 2;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var i = 0; i < d0; i++) {
            for (var j = 0; j < d1; j++) {
                for (var k = 0; k < d2; k++) {
                    buffer[offset++] = (byte)(PolynomialVector[i].Vector[j].Coefficients[k] & 0xff);
                    buffer[offset++] = (byte)(PolynomialVector[i].Vector[j].Coefficients[k] >> 8);
                    }
                }
            }

        var hash = buffer.GetBufferFingerprint();

        if (tag != null) {
            output.WriteLine(tag);
            output.WriteLine(hash);
            }

        return hash;
        }

    #endregion



    }

