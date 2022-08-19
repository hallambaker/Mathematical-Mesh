using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Cryptography.PQC;


public  class Kyber {

    ///<summary>The number of vectors.</summary> 
    public  int K {get;}

    ///<summary></summary> 
    public  int ETA1 { get; }

    ///<summary></summary> 
    public virtual int ETA2 => 2;

    ///<summary>Number of bytes in compressed form polynomial.</summary> 
    public  int POLYCOMPRESSEDBYTES { get; }

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
    public const int SharedSecretBytes = 32;


    ///<summary>Number of bytes in the polynomial representation.</summary> 
    public const int PolyBytes = 384;
    ///<summary>Number of bytes in the vector polynomial representation.</summary> 
    public int PolyVecBytes => PolyBytes * K;

    ///<summary>Number of bytes in compressed form polynomial vector.</summary> 
    public int POLYVECCOMPRESSEDBYTES => K * POLYCOMPRESSEDBYTES;

    public int KYBER_INDCPA_PUBLICKEYBYTES => PolyVecBytes + SymBytes;
    public int KYBER_INDCPA_SECRETKEYBYTES => PolyVecBytes;
    public int KYBER_INDCPA_BYTES => POLYVECCOMPRESSEDBYTES + POLYCOMPRESSEDBYTES;


    public int KYBER_PUBLICKEYBYTES => KYBER_INDCPA_PUBLICKEYBYTES;

    public int KYBER_SECRETKEYBYTES => KYBER_INDCPA_SECRETKEYBYTES + 
            KYBER_INDCPA_PUBLICKEYBYTES + 2 * SymBytes;

    public int KYBER_CIPHERTEXTBYTES => KYBER_INDCPA_BYTES;

    //public short[,,] GetMatrix() => new short [K,K,N];


    public Kyber(int keySize) {
        switch (keySize) {
            case 512: {
                K = 2;
                ETA1 = 3;
                POLYCOMPRESSEDBYTES = 128;
                break;
                }
            case 768: {
                K = 3;
                ETA1 = 2;
                POLYCOMPRESSEDBYTES = 128;
                break;
                }
            case 1024: {
                K = 4;
                ETA1 = 2;
                POLYCOMPRESSEDBYTES = 160;
                break;
                }

            default: {
                throw new ArgumentOutOfRangeException(nameof(keySize));
                }
            }


        }



    public void Randomize(byte[] buffer, int index=0, int count=-1) {
        count = count<0 ? buffer.Length-index : count;

        return;
        }


    public byte[] RandomBytes(int length) {
        var result = new byte[length];
        Randomize(result);
        return result;

        }

    /// <summary>
    /// Generates public and private key
    /// for CCA-secure Kyber key encapsulation mechanism.
    /// </summary>
    /// <param name="seed">Optional seed value for deterministic generation
    /// from seed.</param>
    /// <returns>The public key and the private key.</returns>
    public (byte[], byte[]) KeyPair(byte[]? seed = null) {


        var publicKey = new byte[KYBER_PUBLICKEYBYTES];
        var privateKey = new byte[KYBER_SECRETKEYBYTES];


        IndcpaKeypair(publicKey, privateKey, seed);

        //Test.DumpBufferHex(publicKey);



        Array.Copy(publicKey, 0, privateKey, KYBER_INDCPA_SECRETKEYBYTES, 
                KYBER_INDCPA_PUBLICKEYBYTES);

        //Test.DumpBufferHex(privateKey);
        var publicDigest = SHA3Managed.Process256(publicKey);
        Array.Copy(publicDigest,0, privateKey, KYBER_SECRETKEYBYTES-(2* SymBytes), publicDigest.Length);

        FakeRand(privateKey, KYBER_SECRETKEYBYTES - SymBytes, SymBytes);

        //hash_h(sk + KYBER_SECRETKEYBYTES - 2 * KYBER_SYMBYTES, pk, KYBER_PUBLICKEYBYTES);
        ///* Value z for pseudo-random output on reject */
        //randombytes(sk + KYBER_SECRETKEYBYTES - KYBER_SYMBYTES, KYBER_SYMBYTES);

        //Console.WriteLine();
        //Test.DumpBufferHex(privateKey);


        return (publicKey, privateKey);
        }

    /// <summary>
    /// Generates cipher text and shared
    /// secret for given public key.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <param name="sharedSecret"></param>
    /// <returns>The ciphertext and shared secret.</returns>
    public (byte[], byte[]) Encrypt(byte[] publicKey, byte[]? sharedSecret = null) {
        sharedSecret ??= RandomBytes(SharedSecretBytes);
        



        throw new NYI();
        }

    /// <summary>
    /// Generates shared secret for given
    /// cipher text and private key.
    /// </summary>
    /// <param name="publicKey"></param>
    /// <returns></returns>
    public byte[] Decrypt(byte[] publicKey) {

        throw new NYI();
        }



    /// <summary>
    /// Generate a public, private key pair and the resulting vectors into the initial octets 
    /// of <paramref name="publicKey"/> and <paramref name="privateKey"/>.
    /// </summary>
    /// <param name="publicKey">Buffer of <see cref="KYBER_PUBLICKEYBYTES"/> to 
    /// receive the public key.</param>
    /// <param name="privateKey">Buffer of <see cref="KYBER_SECRETKEYBYTES"/> to
    /// receive the private key.</param>
    /// <param name="seed">Optional seed to be used for deterministic key generation.</param>
    public void IndcpaKeypair(byte[] publicKey, byte[]privateKey, byte[]? seed = null) {
        seed ??= RandomBytes(SymBytes);
        var buf = SHA3Managed.Process512(seed);

        Test.DumpBufferFingerprint(buf);

        // Truncate the buffer since we only use the first 128 bits.
        var publicSeed = new byte[SymBytes];
        var noiseSeed = new byte[SymBytes];
        Array.Copy (buf, publicSeed, SymBytes);
        Array.Copy(buf, SymBytes, noiseSeed, 0, SymBytes);

        var matrix = PolynomialMatrix.GenerateMatrix(K, publicSeed);

        Console.WriteLine(matrix.GetHash());

        byte nonce = 0;
        var skpv = new PolynomialVector(K, false);
        var e = new PolynomialVector(K, false);

        for (var i = 0; i < K; i++) {
            skpv.Polynomial[i] = GetNoiseEta1(noiseSeed, nonce++);
            }
        for (var i = 0; i < K; i++) {
            e.Polynomial[i] = GetNoiseEta1(noiseSeed, nonce++);
            }
        skpv.NTT();
        e.NTT();

        var pkpv = new PolynomialVector(K, false);
        for (var i = 0; i < K; i++) {
            pkpv.Polynomial[i] = matrix.PolynomialVector[i].PointwiseAccMontgomery(skpv);
            pkpv.Polynomial[i].PolyToMont();
            }

        pkpv.Add(e);
        pkpv.Reduce();

        skpv.Pack(privateKey);
        pkpv.Pack(publicKey, publicSeed);

        return ;
        }





    #region // Noise ETA 
    /// <summary>
    /// Sample a polynomial deterministically from a seed and a nonce,
    /// with output polynomial close to centered binomial distribution,
    /// with parameter <see cref="ETA1"/>..
    /// </summary>
    /// <param name="seed">Input seed.</param>
    /// <param name="nonce">Input nonce.</param>
    /// <returns>Output polynomial.</returns>
    public Polynomial GetNoiseEta1(byte[] seed, byte nonce) {
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
    public Polynomial GetNoiseEta2(byte[] seed, byte nonce) {
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
    public static byte[] PRF(int length, byte[] seed, byte nonce) {
        var input = new byte[seed.Length + 1];
        Array.Copy(seed, 0, input, 0, seed.Length);
        input[seed.Length] = nonce;

        return SHAKE256.Process(input, length * 8);
        }


    public static byte[] FakeRand(int len) {
        var result = new byte[len];
        FakeRand(result);
        return result;
        }


    public static void FakeRand(byte[] buffer, int offset=0, int len=-1) {
        len = len < 0? buffer.Length-offset : len;

        for (int i = 0; i < len; i++) {
            buffer[offset+i] = (byte)i;
            }

        }
    public Polynomial CbdEta1(byte[] buffer) => ETA1 == 2 ? Polynomial.CBD2(buffer) : Polynomial.CBD3(buffer);


    public Polynomial CbdEta2(byte[] buffer) => Polynomial.CBD2(buffer); 
    #endregion
    #region // Reductions
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

        u = (short)(a * QINV);
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
    #endregion
    }



public class KyberPublic : Kyber {


    public const int PolyVectorBytes512 = 2 * Kyber.PolyBytes;
    public const int PolyVectorBytes768 = 3 * Kyber.PolyBytes;
    public const int PolyVectorBytes1024 = 4 * Kyber.PolyBytes;

    public const int PublicKeyBytes512 = PolyVectorBytes512 + Kyber.SymBytes;
    public const int PublicKeyBytes768 = PolyVectorBytes768 + Kyber.SymBytes;
    public const int PublicKeyBytes1024 = PolyVectorBytes1024 + Kyber.SymBytes;

    byte[] PublicKey { get; }
    byte[] HashPublicKey { get; }


    int K { get; }

    public static int SharedSecretBytes => Kyber.SharedSecretBytes;

    public int PolyVectorBytes => K * Kyber.PolyBytes;

    ///<summary>The Public key polynomial vector.</summary> 
    PolynomialVector Pkpv { get; }


    PolynomialMatrix at { get; }

    ///<summary>The seed value.</summary> 
    byte[] Seed { get; }

    readonly static int[] KeySize =
        new int[] { 512, 768, 1024 };


    /// <summary>
    /// Constructor, initialize a public key from the keyblob <paramref name="publicKey"/>.
    /// The Kyber strength parameter is specified implicitly by the key size.
    /// </summary>
    /// <param name="publicKey">The private key.</param>
    public KyberPublic(byte[] publicKey) : this (publicKey, GetStrength (publicKey.Length)) {
        }

    /// <summary>
    /// Protected constructor in which the key size is specified explicitly by 
    /// <paramref name="strength"/>.
    /// </summary>
    /// <param name="publicKey">An octet sequence that includes the public key bytes
    /// starting at byte <paramref name="offset"/>.</param>
    /// <param name="strength">The strength parameter; 0 => 512, 1 => 768, 2 => 1024.</param>
    /// <param name="offset">Offset at which the public key is located within 
    /// <paramref name="publicKey"/></param>
    protected KyberPublic(byte[] publicKey, int strength, int offset=0) : base (KeySize[strength]) {
        PublicKey = publicKey;
        HashPublicKey = SHA3Managed.Process256(PublicKey);
        K = strength+2;

        Pkpv = new PolynomialVector(K, PublicKey, offset);
        Seed = PublicKey.Extract(PolyVectorBytes, Kyber.SymBytes);

        at = PolynomialMatrix.GenerateMatrix(K, Seed, true);




        }

    static int GetStrength(int length) => length switch {
        PublicKeyBytes512 => 0,
        PublicKeyBytes768 => 1,
        PublicKeyBytes1024 => 2,
        _ => throw new ArgumentOutOfRangeException()
        };



    public (byte[],byte[]) Encrypt(byte[] seed) {
        // SHA3-256 seed to mask the system seed
        var hashSeed = SHA3Managed.Process256(seed);

        // Multitarget countermeasure for coins + contributory KEM
        var (buf, kr) = GetBufKr(hashSeed);


        // coins are in kr+KYBER_SYMBYTES 
        var coins = kr.Extract(Kyber.SymBytes, Kyber.SymBytes);

        // call indcpa here
        var ct = IndCpaEncrypt(buf, coins);

        /* overwrite coins in kr with H(c) */
        var overwrite = SHA3Managed.Process256(ct);
        Array.Copy(overwrite, 0, kr, Kyber.SymBytes, overwrite.Length);

        /* hash concatenation of pre-k and H(c) to k */
        var ss = SHAKE256.Process(kr);

        return (ct, ss);
        }

    /// <summary>
    /// Multitarget countermeasure for coins + contributory KEM
    /// </summary>
    /// <param name="hashSeed">The input</param>
    /// <returns>The values buf and kr</returns>
    protected (byte[], byte[]) GetBufKr(byte[] hashSeed) {
        var buf = new byte[2 * Kyber.SymBytes];
        Array.Copy(hashSeed, 0, buf, 0, hashSeed.Length);
        Array.Copy(HashPublicKey, 0, buf, hashSeed.Length, hashSeed.Length);
        var kr = SHA3Managed.Process512(buf);

        return (buf, kr);
        }


    public byte[] IndCpaEncrypt(byte[] message, byte[] coins) {
        var size = 2 * Kyber.SymBytes;

        // Moved out to key set up.
        //var p1 = new PolynomialVector(K, PublicKey, 0);
        //var seed = PublicKey.Extract(PolyVectorBytes, Kyber.SymBytes);

        var k = Polynomial.FromMessageBytes(message);


        byte nonce = 0;
        var sp = new PolynomialVector(K, false);
        var ep = new PolynomialVector(K, false);

        for (var i = 0; i < K; i++) {
            sp.Polynomial[i] = GetNoiseEta1(coins, nonce++);
            }
        for (var i = 0; i < K; i++) {
            ep.Polynomial[i] = GetNoiseEta2(coins, nonce++);
            }
        var epp = GetNoiseEta2(coins, nonce++);

        sp.NTT();

        // matrix-vector multiplication

        var bp = new PolynomialVector(K, false);
        for (var i = 0; i < K; i++) {
            bp.Polynomial[i] = at.PolynomialVector[i].PointwiseAccMontgomery(sp);
            }

        var v = Pkpv.PointwiseAccMontgomery(sp);

        bp.PolyInvNTT();
        v.PolyInvNTT();

        bp.Add(ep);
        v.Add(epp);
        v.Add(k);
        bp.Reduce();
        v.Reduce();

        return bp.PackCiphertext(v);
        }

    }


public class KyberPrivate : KyberPublic {

    public const int PrivateKeyBytes512 = PublicKeyBytes512 + PolyVectorBytes512 + 2* Kyber.SymBytes;
    public const int PrivateKeyBytes768 = PublicKeyBytes768 + PolyVectorBytes768 + 2 * Kyber.SymBytes;
    public const int PrivateKeyBytes1024 = PublicKeyBytes1024 + PolyVectorBytes1024 + 2 * Kyber.SymBytes;

    public const int PublicKeyOffset512 = PolyVectorBytes512;
    public const int PublicKeyOffset768 = PolyVectorBytes768;
    public const int PublicKeyOffset1024 = PolyVectorBytes1024;

    public int EncryptFailOffset => throw new NYI();

    readonly static int[] PublicKeyLength = 
        new int[] { PublicKeyBytes512, PublicKeyBytes768, PublicKeyBytes1024 };
    readonly static int[] PublicKeyOffset = 
        new int[] { PublicKeyOffset512, PublicKeyOffset768, PublicKeyOffset1024 };

    byte[] PrivateKey {get;}

    ///<summary>The Public key polynomial vector.</summary> 
    PolynomialVector Skpv { get; }


    /// <summary>
    /// Constructor, initialize a private key from the keyblob <paramref name="privateKey"/>.
    /// The Kyber strength parameter is specified implicitly by the key size.
    /// </summary>
    /// <param name="privateKey">The private key.</param>
    public KyberPrivate(byte[] privateKey) : this (privateKey, GetStrength(privateKey.Length)){
        }

    KyberPrivate(byte[] privateKey, int strength) : base(privateKey, strength, PublicKeyOffset[strength]) {
        PrivateKey = privateKey;


        Skpv = new PolynomialVector(K, PrivateKey, 0);
        }

    static int GetStrength(int length) => length switch {
        PrivateKeyBytes512 => 0,
        PrivateKeyBytes768 => 1,
        PrivateKeyBytes1024 => 2,
        _ => throw new ArgumentOutOfRangeException()
        };

    //static byte[] GetPublic(byte[] privateKey, int strength) =>
    //    privateKey.Extract(PublicKeyOffset[strength], PublicKeyLength[strength]);
    



    public byte[] Decrypt(byte[] ciphertext) {

        var hashSeed = IndCpaDecrypt (ciphertext);

        // Multitarget countermeasure for coins + contributory KEM
        var (buf, kr) = GetBufKr(hashSeed);

        // call indcpa here
        var cmp = IndCpaEncrypt(buf, kr);


        var fail = Verify(ciphertext, cmp);

        // overwrite coins in kr with H(c) 
        var overwrite = SHA3Managed.Process256(ciphertext);
        Array.Copy(overwrite, 0, kr, Kyber.SymBytes, overwrite.Length);

        // Overwrite pre-k with z on re-encryption failure
        if (fail) {
            Array.Copy(PrivateKey, EncryptFailOffset, kr, 0, Kyber.SymBytes);
            }

        // hash concatenation of pre-k and H(c) to k
        var ss = SHAKE256.Process(kr);

        return ss;
        }

    public byte[] IndCpaDecrypt(byte[] buffer) {

        var (bp, v) = PolynomialVector.UnPackCiphertext(buffer);

        bp.NTT();

        var mp = Skpv.PointwiseAccMontgomery (bp);

        mp.PolyInvNTT();

        mp.SubNeg(v);
        mp.Reduce();

        mp.ToMessageBytes();

        throw new NYI();
        }

    public bool Verify(byte[] ciphertext, byte[] compare) {
        throw new NYI();
        }


    }