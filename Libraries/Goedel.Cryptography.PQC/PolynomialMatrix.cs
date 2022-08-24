namespace Goedel.Cryptography.PQC;

public struct PolynomialMatrix {
    ///<summary>The coeficients vectors.</summary> 
    public PolynomialVector[] PolynomialVector;

    ///<summary></summary> 
    public const int GEN_MATRIX_BYTES = 12 * Kyber.N / 8 * (1 << 12) / Kyber.Q + SHA3.HashRateShake128;

    ///<summary></summary> 
    public const int GEN_MATRIX_NBLOCKS = GEN_MATRIX_BYTES / SHA3.HashRateShake128;

    /// <summary>
    /// Constructor, create a Kyber matrix of size 
    /// <paramref name="k"/>.<paramref name="k"/>.<see cref="Kyber.N"/>.
    /// </summary>
    /// <param name="k">The number of polynomials and coefficient vectors per polynomial.</param>
    /// <param name="n">The coefficient vector length.</param>
    public PolynomialMatrix(int k) {
        PolynomialVector = new PolynomialVector[k];
        for (var i = 0; i < k; i++) {
            PolynomialVector[i] = new PolynomialVector(k);
            for (var j = 0; j < k; j++) {
                PolynomialVector[i].Vector[j] = new Polynomial();
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
    public static PolynomialMatrix GenerateMatrix(int kyberK, byte[] seed, bool transposed = false) {
        var a = new PolynomialMatrix(kyberK);
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


                while (ctr < Kyber.N) {
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



    /// <summary>
    /// Return a SHAKE128 fingerprint of the matrix coefficients.
    /// </summary>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash() {

        var d0 = PolynomialVector.GetLength(0);
        var d1 = d0;
        var d2 = Kyber.N;

        int size = d0 * d1 *d2 * 2;
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

        return Test.GetBufferFingerprint(buffer);
        }




    }

