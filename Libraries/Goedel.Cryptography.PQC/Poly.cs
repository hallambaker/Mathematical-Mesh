namespace Goedel.Cryptography.PQC;


public struct Poly {

    ///<summary>The coeficients vectors.</summary> 
    public Coefficients[] Coefficients;

    /// <summary>
    /// Constructor, create a Kyber polynomial of size 
    /// <paramref name="k"/>.<see cref="Kyber.N"/>.
    /// </summary>
    /// <param name="k">The number coefficient vectors.</param>
    public Poly(int k) {
        Coefficients = new Coefficients[k];
        for (var i = 0; i < Coefficients.Length; i++) {
            Coefficients[i] = new Coefficients();
            }
        }




    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static Poly PolyBasemulMontgomery(Poly a, Poly b) {
        throw new NYI();
        }






    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static Poly PolyAdd(Poly a, Poly b) {
        throw new NYI();
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static Poly PolySub(Poly a, Poly b) {
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
    public static Poly Decompress(byte[] input) {
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
    public static Poly FromBytes(byte[] input) {
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
    public static Poly FromMsg(byte[] input) {
        throw new NYI();
        }












    /// <summary>
    /// Return a SHAKE128 fingerprint of the polynomial coefficients.
    /// </summary>
    /// <returns>String containing the base16 representation of the values.</returns>
    public string GetHash() {
        var d1 = Coefficients.GetLength(1);
        var d2 = Coefficients[0].Values.Length;

        int size = d1 * d2 * 2;
        byte[] buffer = new byte[size];

        var offset = 0;
        for (var j = 0; j < d1; j++) {
            for (var k = 0; k < d2; k++) {
                buffer[offset++] = (byte)(Coefficients[j].Values[k] & 0xff);
                buffer[offset++] = (byte)(Coefficients[j].Values[k] >> 8);
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


