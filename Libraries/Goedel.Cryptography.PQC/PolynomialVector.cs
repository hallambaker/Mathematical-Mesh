using System;
using System.Numerics;

namespace Goedel.Cryptography.PQC;


public struct PolynomialVector {


    public int KYBER_POLYVECBYTES => Kyber.PolyBytes * Polynomial.Length;

    int K { get; }

    ///<summary>The coeficients vectors.</summary> 
    public Polynomial[] Polynomial;

    /// <summary>
    /// Constructor, create a Kyber polynomial of size 
    /// <paramref name="k"/>.<see cref="Kyber.N"/>.
    /// </summary>
    /// <param name="k">The number coefficient vectors.</param>
    public PolynomialVector(int k) {
        K = k;
        Polynomial = new Polynomial[k];
        }


    public PolynomialVector(int k, byte[] input, int offset = 0) {
        K = k;
        Polynomial = new Polynomial[k];
        for (var i = 0; i < k; i++) {
            Polynomial[i] = new Polynomial(input, offset);
            offset += Kyber.PolyBytes;
            }

        }


    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// the polynomial vector elements in place.
    /// Inputs assumed to be in normal order, output in bitreversed order
    /// </summary>
    /// <param name="r">The polynomial to transform.</param>
    public void NTT() {
        foreach (var p in Polynomial) {
            p.PolyNTT();
            }
        }

    /// <summary>
    /// Computes negacyclic number-theoretic transform (NTT) of
    /// a polynomial in place.
    /// Inputs assumed to be in normal order, output in bitreversed order
    /// </summary>
    /// <param name="r">The polynomial to transform.</param>
    public void PolyInvNTT() {
        throw new NotImplementedException();
        }


    /// <summary>
    /// Pointwise multiply elements of this vector with <paramref name="vector"/>, accumulate into result
    /// and multiply by 2^-16.
    /// </summary>
    /// <param name="vector">Second input vector.</param>
    /// <returns>The result.</returns>
    public Polynomial PointwiseAccMontgomery(PolynomialVector vector) {
        var r = new Polynomial();
        var t = new Polynomial();

        r.PolyBasemulMontgomery(Polynomial[0], vector.Polynomial[0]);
        for (var i = 1; i < Polynomial.Length; i++) {
            t.PolyBasemulMontgomery(Polynomial[i], vector.Polynomial[i]);
            r.Add(t);
            }
        r.Reduce();

        return r;
        }


    /// <summary>
    /// Add the polynomial vector <paramref name="vector"/> to this in place.
    /// </summary>
    /// <param name="vector"></param>
    public void Add(PolynomialVector vector) {
        for (var i = 0; i < Polynomial.Length; i++) {
            Polynomial[i].Add(vector.Polynomial[i]);
            }
        }

    /// <summary>
    /// Applies Barrett reduction to each coefficient
    /// of each element of a vector of polynomials.
    /// For details of the Barrett reduction see <see cref="Kyber.BarrettReduce"/>.
    /// </summary>
    public void Reduce() {
        for (var i = 0; i < Polynomial.Length; i++) {
            Polynomial[i].Reduce();
            }
        }


    /// <summary>
    /// Serialize the vector to produce the public or private key.
    /// </summary>
    /// <param name="seed">Optional additional seed value to be appended to the output.</param>
    /// <returns>The packed polynomial vector.</returns>

    public void Pack(byte[]buffer, byte[]? seed = null) {
        var length = KYBER_POLYVECBYTES ;
        if (seed != null) {
            length += seed.Length;
            }


        for (var i = 0; i < Polynomial.Length; i++) {
            Polynomial[i].ToBytes(buffer, i* Kyber.PolyBytes);
            }

        if (seed != null) {
            Array.Copy (seed, 0, buffer, KYBER_POLYVECBYTES, seed.Length);
            }

        }



    public void Compress352(byte[] buffer, int offset = 0) {

        var t = new short[8];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < Kyber.N/8; j++) {
                for (var k = 0; k < 8; k++) {
                    t[k] = (short)(((((uint)Polynomial[i].Coefficients[8 * j + k] << 11) + Kyber.Q / 2) / Kyber.Q) & 0x7ff);
                    }
                buffer[offset++] = (byte)(t[0] >> 0);               // 0
                buffer[offset++] = (byte)(t[0] >> 8  | t[1] << 3);  // 1
                buffer[offset++] = (byte)(t[1] >> 5  | t[2] << 6);  // 2
                buffer[offset++] = (byte)(t[2] >> 2);               // 3
                buffer[offset++] = (byte)(t[2] >> 10 | t[3] << 1);  // 4
                buffer[offset++] = (byte)(t[3] >> 7  | t[4] << 4);  // 5
                buffer[offset++] = (byte)(t[4] >> 4  | t[5] >> 7);  // 6
                buffer[offset++] = (byte)(t[5] >> 1);               // 7
                buffer[offset++] = (byte)(t[5] >> 9  | t[6] >> 2);  // 8
                buffer[offset++] = (byte)(t[6] >> 6  | t[7] >> 5);  // 9
                buffer[offset++] = (byte)(t[7] >> 3);               // 10
                }
            }
        }

    public void Compress320(byte[] buffer, int offset = 0) {

        var t = new short[4];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < Kyber.N / 8; j++) {
                for (var k = 0; k < 8; k++) {
                    t[k] = (short)(((((uint)Polynomial[i].Coefficients[4 * j + k] << 10) + Kyber.Q / 2) / Kyber.Q) & 0x3ff);
                    }
                buffer[offset++] = (byte)(t[0] >> 0);               // 0
                buffer[offset++] = (byte)(t[0] >> 8  | t[1] << 2);  // 1
                buffer[offset++] = (byte)(t[1] >> 6  | t[2] << 4);  // 2
                buffer[offset++] = (byte)(t[2] >> 4  | t[3] << 6);  // 3
                buffer[offset++] = (byte)(t[3] >> 2);               // 4
                }
            }
        }



    public static PolynomialVector Decompress352(int K, byte[] buffer, int offset = 0) {
        var vector = new PolynomialVector(K);

        var t = new short[8];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < Kyber.N / 8; j++) {

                t[0] = (short)((buffer[offset + 0] >> 0) | (buffer[offset + 1] << 8));
                t[1] = (short)((buffer[offset + 3] >> 3) | (buffer[offset + 2] << 5));
                t[2] = (short)((buffer[offset + 6] >> 6) | (buffer[offset + 3] << 2) | (buffer[offset + 4] << 10));
                t[3] = (short)((buffer[offset + 1] >> 1) | (buffer[offset + 5] << 7));
                t[4] = (short)((buffer[offset + 4] >> 4) | (buffer[offset + 6] << 4));
                t[5] = (short)((buffer[offset + 7] >> 7) | (buffer[offset + 7] << 1) | (buffer[offset + 8] << 9));
                t[6] = (short)((buffer[offset + 2] >> 2) | (buffer[offset + 9] << 6));
                t[7] = (short)((buffer[offset + 5] >> 5) | (buffer[offset +10] << 3));

                for (var k = 0; k < 8; k++) {
                    vector.Polynomial[i].Coefficients[8 * j + k] = (short)(((t[k] & 0x7FF) * Kyber.Q + 1024) >> 11);
                    }
                
                offset += 11;
                }
            }
        return vector;

        }

    public static PolynomialVector Decompress320(int K, byte[] buffer, int offset = 0) {

        var vector = new PolynomialVector(K);

        var t = new short[8];

        for (var i = 0; i < K; i++) {
            for (var j = 0; j < Kyber.N / 4; j++) {

                t[0] = (short)((buffer[offset + 0] >> 0) | (buffer[offset + 1] << 8));
                t[1] = (short)((buffer[offset + 2] >> 2) | (buffer[offset + 2] << 6));
                t[2] = (short)((buffer[offset + 4] >> 4) | (buffer[offset + 3] << 4));
                t[3] = (short)((buffer[offset + 6] >> 6) | (buffer[offset + 4] << 2));

                for (var k = 0; k < 4; k++) {
                    vector.Polynomial[i].Coefficients[4 * j + k] = (short)(((t[k] & 0x3FF) * Kyber.Q + 512) >> 10);
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
    public static Polynomial PolyBasemulMontgomery(PolynomialVector a, PolynomialVector b) {

        var r = new Polynomial();
        var t = new Polynomial();

        r.PolyBasemulMontgomery(a.Polynomial[0], b.Polynomial[0]);
        for (var i = 1; i < a.Polynomial.Length; i++) {
            t.PolyBasemulMontgomery(a.Polynomial[i], b.Polynomial[i]);
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
    public static PolynomialVector PolyAdd(PolynomialVector a, PolynomialVector b) {
        throw new NYI();
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static PolynomialVector PolySub(PolynomialVector a, PolynomialVector b) {
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
    public static PolynomialVector Decompress(byte[] input) {
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
    public static PolynomialVector FromBytes(byte[] input) {
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
    public static PolynomialVector FromMsg(byte[] input) {
        throw new NYI();
        }












    /// <summary>
    /// Return a SHAKE128 fingerprint of the polynomial coefficients.
    /// </summary>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash() {
        var d1 = Polynomial.GetLength(1);
        var d2 = Polynomial[0].Coefficients.Length;

        int size = d1 * d2 * 2;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var j = 0; j < d1; j++) {
            for (var k = 0; k < d2; k++) {
                buffer[offset++] = (byte)(Polynomial[j].Coefficients[k] & 0xff);
                buffer[offset++] = (byte)(Polynomial[j].Coefficients[k] >> 8);
                }
            }

        return Test.GetBufferFingerprint(buffer);
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


