using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Cryptography.PQC;


public abstract class Kyber {

    ///<summary>The number of vectors.</summary> 
    public abstract int K {get;}

    ///<summary></summary> 
    public abstract int ETA1 { get; }

    ///<summary></summary> 
    public virtual int ETA2 => 2;

    ///<summary>Number of bytes in compressed form polynomial.</summary> 
    public abstract int POLYCOMPRESSEDBYTES { get; }

    ///<suwmmary>The vector length.</suwmmary> 
    public const int N = 256;
    ///<summary>The modulus.</summary> 
    public const int Q = 3329;


    ///<summary>The value q^-1 mod 2^16</summary> 
    public const int QINV = 62209;

    ///<summary>The value 2^16 mod q</summary> 
    public const int MONT = 2285;

    ///<summary>Size of hashes and seeds in bytes.</summary> 
    public const int SymBytes = 32;
    ///<summary>Size in bytes of shared key.</summary> 
    public const int SSBytes = 32;

    ///<summary>Number of bytes in the polynomial representation.</summary> 
    public const int PolyBytes = 384;
    ///<summary>Number of bytes in the vector polynomial representation.</summary> 
    public int PolyVecBytes => PolyBytes * K;

    ///<summary>Number of bytes in compressed form polynomial vector.</summary> 
    public int POLYVECCOMPRESSEDBYTES => K * POLYCOMPRESSEDBYTES;



    //public short[,,] GetMatrix() => new short [K,K,N];







    /// <summary>
    /// Sample a polynomial deterministically from a seed and a nonce,
    /// with output polynomial close to centered binomial distribution,
    /// with parameter <see cref="ETA1"/>..
    /// </summary>
    /// <param name="seed">Input seed.</param>
    /// <param name="nonce">Input nonce.</param>
    /// <returns>Output polynomial.</returns>
    public Coefficients GetNoiseEta1(byte[] seed, byte nonce) {
        var length = ETA1 * N / 4;
        var buffer = PRF(length, seed, nonce);

        //Test.DumpBufferFingerprint(buffer);

        return CbdEta1(buffer);
        }

    /// <summary>
    /// Sample a polynomial deterministically from a seed and a nonce,
    /// with output polynomial close to centered binomial distribution,
    /// with parameter <see cref="ETA2"/>.
    /// </summary>
    /// <param name="seed">Input seed.</param>
    /// <param name="nonce">Input nonce.</param>
    /// <returns>Output polynomial.</returns>
    public Coefficients GetNoiseEta2(byte[] seed, byte nonce) {
        var length = ETA2 * N / 4;
        var buffer = PRF(length, seed, nonce);
        return CbdEta2(buffer);
        }


    /// <summary>
    /// Pseudo-random function using SHAKE256, concatenates secret <paramref name="seed"/>
    /// and public input <paramref name="nonce"/>
    /// and then returns a buffer of length <paramref name="length"/>with SHAKE256 output
    /// </summary>
    /// <param name="seed">The secret input.</param>
    /// <param name="nonce">The public nonce.</param>
    public byte[] PRF(int length, byte[] seed, byte nonce) {
        var input = new byte[seed.Length + 1];
        Array.Copy(seed, 0, input, 0, seed.Length);
        input[seed.Length] = nonce;

        return SHAKE256.Process(input, length * 8);
        }



    public Coefficients CbdEta1(byte[] buffer) => ETA1 == 2 ? Coefficients.CBD2(buffer) : Coefficients.CBD3(buffer);


    public Coefficients CbdEta2(byte[] buffer) => Coefficients.CBD2(buffer);


    /// <summary>
    /// Montgomery reduction; given a 32-bit integer <paramref name="a"/>, computes
    /// 16-bit integer congruent to a * R^-1 mod q,
    /// where R=2^16
    /// </summary>
    /// <param name="a">integer to be reduced  {-q2^15,...,q2^15-1}.</param>
    /// <returns>integer in {-q+1,...,q-1} congruent to a * R^-1 modulo q.</returns>
    public static short MontgomeryReduce(int a) {
        int t;
        short u;

        u = (short) (a*QINV);
        t = (int)u * Q;
        t = a - t;
        t >>= 16;

        //Console.WriteLine($"{t}");

        //if (t == 782 | t == 709) {
        //    }

        return (short)t;
        }

    /// <summary>
    /// Barrett reduction; given a 16-bit integer <paramref name="a"/>, computes
    /// 16-bit integer congruent to a mod q in {0,...,q}
    /// </summary>
    /// <param name="a">input integer to be reduced</param>
    /// <returns> integer in {0,...,q} congruent to a modulo q.</returns>
    public static short BarrettReduce(short a) {
        short t;
        short v = ((1 << 26) + Q / 2) / Q;

        t = (short)((v * a) >> 26);
        t *= Q;

        return (short)(a - t);

        }

    /// <summary>
    /// Conditionallly subtract q
    /// </summary>
    /// <param name="a">input integer a</param>
    /// <returns>a - q if a >= q, else a</returns>
    public static short ConditionalSubtract(short a) {
        a -= Q;
        a += (short)((a >> 15) & Q);

        return a;
        }
    }

public class Kyber1024 : Kyber {

    public override int K => 4;
    public override int ETA1 => 2;
    public override int POLYCOMPRESSEDBYTES => 160;


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


