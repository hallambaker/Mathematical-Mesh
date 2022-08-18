using System.Numerics;

namespace Goedel.Cryptography.PQC;


public struct PolynomialVector {


    public int KYBER_POLYVECBYTES => Kyber.PolyBytes * Polynomial.Length;



    ///<summary>The coeficients vectors.</summary> 
    public Polynomial[] Polynomial;

    /// <summary>
    /// Constructor, create a Kyber polynomial of size 
    /// <paramref name="k"/>.<see cref="Kyber.N"/>.
    /// </summary>
    /// <param name="k">The number coefficient vectors.</param>
    public PolynomialVector(int k, bool initialize = true) {
        Polynomial = new Polynomial[k];
        for (var i = 0; i < Polynomial.Length; i++) {
            Polynomial[i] = new Polynomial();
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

    public byte[] Pack(byte[]? seed = null) {
        var length = KYBER_POLYVECBYTES ;
        if (seed != null) {
            length += seed.Length;
            }
        var buffer = new byte[length];

        for (var i = 0; i < Polynomial.Length; i++) {
            Polynomial[i].ToBytes(buffer, i* KYBER_POLYVECBYTES);
            }

        if (seed != null) {
            Array.Copy (seed, 0, buffer, KYBER_POLYVECBYTES, seed.Length);
            }

        return buffer;
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


