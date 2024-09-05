namespace Goedel.Cryptography.PQC;

/// <summary>
/// Operations on vectors of polynomials expressed as a list of coefficients for use in Kyber. 
/// Could be adapted to other applications if required.
/// </summary>
public struct PolynomialVectorInt16 {

    ///<summary>The number of bytes required to store the vector.</summary> 
    public int PolyVectorBytes => MlKem.PolynomialBytes * Vector.Length;

    int K { get; }

    ///<summary>The coeficients vectors.</summary> 
    public PolynomialInt16[] Vector;

    /// <summary>
    /// Constructor, create a Kyber polynomial of size 
    /// <paramref name="k"/>.<see cref="MlKem.N"/>.
    /// </summary>
    /// <param name="k">The number coefficient vectors.</param>
    public PolynomialVectorInt16(int k) {
        K = k;
        Vector = new PolynomialInt16[k];
        }


    /// <summary>
    /// Constructor, create a Kyber vector of length <paramref name="k"/> from 
    /// the data in <paramref name="input"/> beginning at byte <paramref name="offset"/>.
    /// </summary>
    /// <param name="k">Vector length.</param>
    /// <param name="input">Input data.</param>
    /// <param name="offset">First byte to read.</param>
    public PolynomialVectorInt16(int k, byte[] input, int offset = 0) {
        K = k;
        Vector = new PolynomialInt16[k];
        for (var i = 0; i < k; i++) {
            Vector[i] = new PolynomialInt16(input, offset);
            offset += MlKem.PolynomialBytes;
            }

        }


    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// the polynomial vector elements in place.
    /// Inputs assumed to be in normal order, output in bitreversed order
    /// </summary>
    public void NTT() {
        foreach (var p in Vector) {
            p.PolyNTT();
            }
        }

    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// a polynomial in place.
    /// Inputs assumed to be in normal order, output in bitreversed order
    /// </summary>
    public void PolyInvNTT() {
        foreach (var p in Vector) {
            p.PolyInvNTT();
            }
        }


    /// <summary>
    /// Pointwise multiply elements of this vector with <paramref name="vector"/>, accumulate into result
    /// and multiply by 2^-16.
    /// </summary>
    /// <param name="vector">Second input vector.</param>
    /// <returns>The result.</returns>
    public PolynomialInt16 PointwiseAccMontgomery(PolynomialVectorInt16 vector) {
        var r = new PolynomialInt16();
        var t = new PolynomialInt16();

        r.PolyBasemulMontgomery(Vector[0], vector.Vector[0]);
        for (var i = 1; i < Vector.Length; i++) {
            t.PolyBasemulMontgomery(Vector[i], vector.Vector[i]);
            r.Add(t);
            }
        r.Reduce();

        return r;
        }


    /// <summary>
    /// Add the polynomial vector <paramref name="vector"/> to this in place.
    /// </summary>
    /// <param name="vector"></param>
    public void Add(PolynomialVectorInt16 vector) {
        for (var i = 0; i < Vector.Length; i++) {
            Vector[i].Add(vector.Vector[i]);
            }
        }

    /// <summary>
    /// Applies Barrett reduction to each coefficient
    /// of each element of a vector of polynomials.
    /// For details of the Barrett reduction see <see cref="MlKem.BarrettReduce"/>.
    /// </summary>
    public void Reduce() {
        for (var i = 0; i < Vector.Length; i++) {
            Vector[i].Reduce();
            }
        }


    /// <summary>
    /// Serialize the vector to produce the public or private key.
    /// </summary>
    /// <param name="seed">Optional additional seed value to be appended to the output.</param>
    /// <param name="buffer">The buffer to write the result to.</param>
    /// <returns>The packed polynomial vector.</returns>

    public void Pack(byte[] buffer, byte[]? seed = null) {
        var length = PolyVectorBytes;
        if (seed != null) {
            length += seed.Length;
            }


        for (var i = 0; i < Vector.Length; i++) {
            Vector[i].ToBytes(buffer, i * MlKem.PolynomialBytes);
            }

        if (seed != null) {
            Array.Copy(seed, 0, buffer, PolyVectorBytes, seed.Length);
            }

        }


    /// <summary>
    /// Compress vector using 352 bytes per polynomial.
    /// </summary>
    /// <param name="buffer">The buffer to write to.</param>
    /// <param name="offset">The first byte to write.</param>
    public void Compress352(byte[] buffer, int offset = 0) {

        var t = new short[8];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < MlKem.N / 8; j++) {
                for (var k = 0; k < 8; k++) {
                    t[k] = (short)(((((uint)Vector[i].Coefficients[8 * j + k] << 11) + MlKem.Q / 2) / MlKem.Q) & 0x7ff);
                    }
                buffer[offset++] = (byte)(t[0] >> 0);               // 0
                buffer[offset++] = (byte)(t[0] >> 8 | t[1] << 3);  // 1
                buffer[offset++] = (byte)(t[1] >> 5 | t[2] << 6);  // 2
                buffer[offset++] = (byte)(t[2] >> 2);               // 3
                buffer[offset++] = (byte)(t[2] >> 10 | t[3] << 1);  // 4
                buffer[offset++] = (byte)(t[3] >> 7 | t[4] << 4);  // 5
                buffer[offset++] = (byte)(t[4] >> 4 | t[5] << 7);  // 6
                buffer[offset++] = (byte)(t[5] >> 1);               // 7
                buffer[offset++] = (byte)(t[5] >> 9 | t[6] << 2);  // 8
                buffer[offset++] = (byte)(t[6] >> 6 | t[7] << 5);  // 9
                buffer[offset++] = (byte)(t[7] >> 3);               // 10
                }
            }
        }

    /// <summary>
    /// Compress vector using 320 bytes per polynomial.
    /// </summary>
    /// <param name="buffer">The buffer to write to.</param>
    /// <param name="offset">The first byte to write.</param>
    public void Compress320(byte[] buffer, int offset = 0) {

        var t = new short[4];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < MlKem.N / 8; j++) {
                for (var k = 0; k < 8; k++) {
                    t[k] = (short)(((((uint)Vector[i].Coefficients[4 * j + k] << 10) + MlKem.Q / 2) / MlKem.Q) & 0x3ff);
                    }
                buffer[offset++] = (byte)(t[0] >> 0);               // 0
                buffer[offset++] = (byte)(t[0] >> 8 | t[1] << 2);  // 1
                buffer[offset++] = (byte)(t[1] >> 6 | t[2] << 4);  // 2
                buffer[offset++] = (byte)(t[2] >> 4 | t[3] << 6);  // 3
                buffer[offset++] = (byte)(t[3] >> 2);               // 4
                }
            }
        }


    /// <summary>
    /// Deompress vector using 352 bytes per polynomial.
    /// </summary>
    /// <param name="k">The Kyber vector length.</param>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The first byte to read.</param>
    public static PolynomialVectorInt16 Decompress352(int k, byte[] buffer, int offset = 0) {
        var vector = new PolynomialVectorInt16(k);

        var t = new short[8];

        for (var v = 0; v < k; v++) {
            vector.Vector[v] = new();
            for (var j = 0; j < MlKem.N / 8; j++) {

                t[0] = (short)((buffer[offset + 0] >> 0) | (buffer[offset + 1] << 8));
                t[1] = (short)((buffer[offset + 1] >> 3) | (buffer[offset + 2] << 5));
                t[2] = (short)((buffer[offset + 2] >> 6) | (buffer[offset + 3] << 2) | (buffer[offset + 4] << 10));
                t[3] = (short)((buffer[offset + 4] >> 1) | (buffer[offset + 5] << 7));
                t[4] = (short)((buffer[offset + 5] >> 4) | (buffer[offset + 6] << 4));
                t[5] = (short)((buffer[offset + 6] >> 7) | (buffer[offset + 7] << 1) | (buffer[offset + 8] << 9));
                t[6] = (short)((buffer[offset + 8] >> 2) | (buffer[offset + 9] << 6));
                t[7] = (short)((buffer[offset + 9] >> 5) | (buffer[offset + 10] << 3));

                for (var c = 0; c < 8; c++) {
                    vector.Vector[v].Coefficients[8 * j + c] = (short)(((t[c] & 0x7FF) * MlKem.Q + 1024) >> 11);
                    }

                offset += 11;
                }
            }
        return vector;

        }

    /// <summary>
    /// Deompress vector using 320 bytes per polynomial.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The first byte to read.</param>
    /// <param name="k">Kyber vector length.</param>
    public static PolynomialVectorInt16 Decompress320(int k, byte[] buffer, int offset = 0) {

        var vector = new PolynomialVectorInt16(k);

        var t = new short[8];

        for (var v = 0; v < k; v++) {
            for (var j = 0; j < MlKem.N / 4; j++) {

                t[0] = (short)((buffer[offset + 0] >> 0) | (buffer[offset + 1] << 8));
                t[1] = (short)((buffer[offset + 2] >> 2) | (buffer[offset + 2] << 6));
                t[2] = (short)((buffer[offset + 4] >> 4) | (buffer[offset + 3] << 4));
                t[3] = (short)((buffer[offset + 6] >> 6) | (buffer[offset + 4] << 2));

                for (var c = 0; c < 4; c++) {
                    vector.Vector[v].Coefficients[4 * j + c] = (short)(((t[c] & 0x3FF) * MlKem.Q + 512) >> 10);
                    }

                offset += 11;
                }
            }
        return vector;
        }

    // ----------------------------------------------------------------------


    /// <summary>
    /// Pointwise multiply elements of a and b, accumulate into result
    /// and multiply by 2^-16.
    /// </summary>
    /// <param name="a">First input vector.</param>
    /// <param name="b">Second input vector.</param>
    /// <returns>The result.</returns>
    public static PolynomialInt16 PolyBasemulMontgomery(PolynomialVectorInt16 a, PolynomialVectorInt16 b) {

        var r = new PolynomialInt16();
        var t = new PolynomialInt16();

        r.PolyBasemulMontgomery(a.Vector[0], b.Vector[0]);
        for (var i = 1; i < a.Vector.Length; i++) {
            t.PolyBasemulMontgomery(a.Vector[i], b.Vector[i]);
            r.Add(t);
            }
        r.Reduce();

        return r;
        }






    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVectorInt16 PolyAdd(PolynomialVectorInt16 a, PolynomialVectorInt16 b) {
        throw new NYI();
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVectorInt16 PolySub(PolynomialVectorInt16 a, PolynomialVectorInt16 b) {
        throw new NYI();
        }



    /// <summary>
    /// Compression and subsequent serialization of the polynomial
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public byte[] Compress() {
        throw new NYI();
        }

    /// <summary>
    /// De-serialization and subsequent decompression of a byte array returning a polynomial
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVectorInt16 Decompress(byte[] input) {
        throw new NYI();
        }



    /// <summary>
    /// Serialization of the polynomial
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public byte[] ToBytes() {
        throw new NYI();
        }

    /// <summary>
    /// Decompression of a byte array returning a polynomial
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVectorInt16 FromBytes(byte[] input) {
        throw new NYI();
        }



    /// <summary>
    /// Convert polynomial to 32-byte message
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public byte[] ToMsg() {
        throw new NYI();
        }

    /// <summary>
    /// Convert 32-byte message to polynomial
    /// </summary>
    /// <returns>Serialization of the polynomial.</returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVectorInt16 FromMsg(byte[] input) {
        throw new NYI();
        }












    /// <summary>
    /// Return a SHAKE128 fingerprint of the polynomial coefficients.
    /// </summary>
    ///  <param name="tag">Optional tag for identifying console output.</param>
    /// <param name="output">Output to write the result to if <paramref name="tag"/> is
    /// not null.</param>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash(string tag = null,
                    TextWriter output = null) {

        output ??= Console.Out;

        var d1 = Vector.GetLength(0);
        var d2 = Vector[0].Coefficients.Length;

        int size = d1 * d2 * 2;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var j = 0; j < d1; j++) {
            for (var k = 0; k < d2; k++) {
                buffer[offset++] = (byte)(Vector[j].Coefficients[k] & 0xff);
                buffer[offset++] = (byte)(Vector[j].Coefficients[k] >> 8);
                }
            }

        var v = buffer.GetBufferFingerprint();

        if (tag != null) {
            output.WriteLine(tag);
            output.WriteLine(v);
            }

        return v;
        }








    }






//public class Kyber512 : Kyber {
//    ///<inheritdoc/>
//    public override int K => 2;
//    ///<inheritdoc/>
//    public override int ETA1 => 3;
//    ///<inheritdoc/>
//    public override int POLYCOMPRESSEDBYTES => 128;



//    }

//public class Kyber768 : Kyber {
//    ///<inheritdoc/>
//    public override int K => 3;
//    ///<inheritdoc/>
//    public override int ETA1 => 2;
//    ///<inheritdoc/>
//    public override int POLYCOMPRESSEDBYTES => 128;
//    }


