namespace Goedel.Cryptography.PQC;

/// <summary>
/// Base class for Kyber implementations. Specifies parameters and constants
/// used in public and private key classes.
/// </summary>
public class MlKem {

    #region // Properties and fields
    #region // Parameters dependent on Kyber mode.

    ///<summary>The key size, MUST be 512, 768 or 1024.</summary> 
    public int KeySize { get; }

    ///<summary>The number of vectors.</summary> 
    public int K { get; }

    ///<summary></summary> 
    public int ETA1 { get; }
    #endregion
    #region // Kyber constants.

    ///<summary></summary> 
    public virtual int ETA2 => 2;

    ///<summary>Number of bytes in compressed form polynomial.</summary> 
    public int PolyCompressedBytes { get; }

    ///<suwmmary>The vector length.</suwmmary> 
    public const int N = 256;
    ///<summary>The modulus.</summary> 
    public const int Q = 3329;

    ///<summary>The value q^-1 mod 2^16</summary> 
    public const int QINV = 62209;

    #endregion
    #region // Data sizes
    ///<summary>Size of hashes and seeds in bytes.</summary> 
    public const int SymBytes = 32;

    ///<summary>Size in bytes of shared key.</summary> 
    public const int SharedSecretBytes = 32;

    ///<summary>Number of bytes in the polynomial representation.</summary> 
    public const int PolynomialBytes = 384;
    ///<summary>Number of bytes in the vector polynomial representation.</summary> 
    public int PolyVectorBytes => PolynomialBytes * K;

    ///<summary>Number of bytes in compressed form polynomial vector.</summary> 
    public int PolyvectorCompressedBytes { get; }

    ///<summary>Bytes in ind cpa public key.</summary> 
    public int IndCpaPublicKeyBytes => PolyVectorBytes + SymBytes;

    ///<summary>Bytes in ind cpa private key.</summary> 
    public int IndCpaPrivateKeyBytes => PolyVectorBytes;

    ///<summary>Bytes in ciphertext.</summary> 
    public int IndCpaBytes => PolyvectorCompressedBytes + PolyCompressedBytes;

    ///<summary>Bytes in public key.</summary> 
    public int PublicKeyBytes => IndCpaPublicKeyBytes;

    ///<summary>Bytes in private key.</summary> 
    public int PrivateKeyBytes => IndCpaPrivateKeyBytes +
            IndCpaPublicKeyBytes + 2 * SymBytes;

    ///<summary>Bytes in ciphertext.</summary> 
    public int CiphertextBytes => IndCpaBytes;
    #endregion
    #region // Prefab parameter sets

    ///<summary>Parameter set for 512 bit key.</summary> 
    public static MlKem MLKEM512 { get; }

    ///<summary>Parameter set for 768 bit key.</summary> 
    public static MlKem MLKEM768 { get; }

    ///<summary>Parameter set for 1024 bit key.</summary> 
    public static MlKem MLKEM1024 { get; }

    ///<summary>Parameter set for 512 bit key.</summary> 
    public static MlKem Kyber512 { get; }

    ///<summary>Parameter set for 768 bit key.</summary> 
    public static MlKem Kyber768 { get; }

    ///<summary>Parameter set for 1024 bit key.</summary> 
    public static MlKem Kyber1024 { get; }


    public bool Fips203 { get; set; } = true;

    #endregion 
    #endregion
    #region // Constructors

    /// <summary>
    /// Do a one time initialization of the parameter presets on assembly load.
    /// </summary>
    static MlKem() {
        MLKEM512 = new MlKem(512);
        MLKEM768 = new MlKem(768);
        MLKEM1024 = new MlKem(1024);
        }


    /// <summary>
    /// Base constructor, sets parameters according to key size.
    /// </summary>
    /// <param name="keySize">The key size, 512, 768 or 1024 bytes.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public MlKem(int keySize) {
        KeySize = keySize;
        switch (keySize) {
            case 512: {
                K = 2;
                ETA1 = 3;
                PolyCompressedBytes = 128;
                PolyvectorCompressedBytes = K * 320;
                break;
                }
            case 768: {
                K = 3;
                ETA1 = 2;
                PolyCompressedBytes = 128;
                PolyvectorCompressedBytes = K * 320;
                break;
                }
            case 1024: {
                K = 4;
                ETA1 = 2;
                PolyCompressedBytes = 160;
                PolyvectorCompressedBytes = K * 352;
                break;
                }

            default: {
                throw new ArgumentOutOfRangeException(nameof(keySize));
                }
            }


        }

    #endregion
    #region // Packing and unpacking ciphertext
    /// <summary>
    /// Pack ciphertext into a byte array and return the result.
    /// </summary>
    /// <param name="v">The vector parameter.</param>
    /// <param name="p">The polynomial parameter.</param>
    /// <returns>The packed ciphertext.</returns>
    public byte[] PackCiphertext(PolynomialVectorInt16 v, PolynomialInt16 p) {

        var buffer = new byte[IndCpaBytes];
        switch (K) {
            case 4: {
                v.Compress352(buffer);
                p.Compress160(buffer, PolyvectorCompressedBytes);
                break;
                }
            case 2:
            case 3: {
                v.Compress320(buffer);
                p.Compress128(buffer, PolyvectorCompressedBytes);
                break;
                }
            }
        return buffer;
        }


    /// <summary>
    /// Unpack ciphertext in <paramref name="data"/> and return the result.
    /// </summary>
    /// <param name="data">The ciphertext to unpack.</param>
    /// <returns>The vector and polynomial components.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public (PolynomialVectorInt16, PolynomialInt16) UnPackCiphertext(byte[] data) {

        data.Length.AssertEqual(IndCpaBytes, NYI.Throw);

        switch (K) {
            case 4: {
                var v = PolynomialVectorInt16.Decompress352(K, data);
                var p = PolynomialInt16.Decompress352(data, PolyvectorCompressedBytes);
                return (v, p);
                }
            case 2:
            case 3: {
                var v = PolynomialVectorInt16.Decompress320(K, data);
                var p = PolynomialInt16.Decompress320(data, PolyvectorCompressedBytes);
                return (v, p);
                }
            }
        throw new NotImplementedException();
        }



    #endregion
    #region // Key pair generation

    /// <summary>
    /// Generates public and private key
    /// for CCA-secure Kyber key encapsulation mechanism.
    /// </summary>
    /// <param name="seed">Optional seed value for deterministic generation
    /// from seed.</param>
    /// <returns>The public key and the private key.</returns>
    public (byte[], byte[]) KeyPair(byte[]? seed = null) {
        seed ??= Platform.GetRandomBytes(SymBytes);
        var buf = SHA3Managed.Process512(seed);

        var publicSeed = new byte[SymBytes];
        var noiseSeed = new byte[SymBytes];
        Array.Copy(buf, publicSeed, SymBytes);
        Array.Copy(buf, SymBytes, noiseSeed, 0, SymBytes);

        var (publicKey, privateKey) = MlKeyGen(publicSeed, noiseSeed);
        Array.Copy(publicKey, 0, privateKey, IndCpaPrivateKeyBytes,
                IndCpaPublicKeyBytes);

        var publicDigest = SHA3Managed.Process256(publicKey);
        Array.Copy(publicDigest, 0, privateKey, PrivateKeyBytes - (2 * SymBytes), publicDigest.Length);

        if (seed == null) {
            Platform.FillRandom(privateKey, PrivateKeyBytes - SymBytes, SymBytes);
            }
        else {
            var fill = SHAKE256.GetBytes(SymBytes, seed, publicKey);
            Array.Copy(fill, 0, privateKey, PrivateKeyBytes - SymBytes, SymBytes);
            }

        return (publicKey, privateKey);
        }


    public (byte[], byte[]) MlKeyGen(byte[] publicSeed, byte[] noiseSeed) {
        var publicKey = new byte[PublicKeyBytes];
        var privateKey = new byte[PrivateKeyBytes];

        //Test.DumpBufferFingerprint(buf);
        // Truncate the buffer since we only use the first 128 bits.
        var matrix = PolynomialMatrixInt16.MatrixExpandFromSeed(K, publicSeed);

        //Console.WriteLine(matrix.GetHash());

        byte nonce = 0;
        var skpv = new PolynomialVectorInt16(K);
        var e = new PolynomialVectorInt16(K);

        for (var i = 0; i < K; i++) {
            skpv.Vector[i] = GetNoiseEta1(noiseSeed, nonce++);
            }
        for (var i = 0; i < K; i++) {
            e.Vector[i] = GetNoiseEta1(noiseSeed, nonce++);
            }
        skpv.NTT();
        e.NTT();

        var pkpv = new PolynomialVectorInt16(K);
        for (var i = 0; i < K; i++) {
            pkpv.Vector[i] = matrix.PolynomialVector[i].PointwiseAccMontgomery(skpv);
            pkpv.Vector[i].PolyToMont();
            }

        pkpv.Add(e);
        pkpv.Reduce();

        skpv.Pack(privateKey);
        pkpv.Pack(publicKey, publicSeed);

        return (publicKey, privateKey);
        }
    #endregion
    #region // Randomness management

    /// <summary>
    /// Pseudo-random function using SHAKE256, concatenates secret <paramref name="seed"/>
    /// and public input <paramref name="nonce"/>
    /// and then returns a buffer of length <paramref name="length"/>with SHAKE256 output
    /// </summary>
    /// <param name="seed">The secret input.</param>
    /// <param name="nonce">The public nonce.</param>
    /// <param name="length">The number of bytes to return.</param>
    public static byte[] PRF(int length, byte[] seed, byte nonce) {
        var input = new byte[seed.Length + 1];
        Array.Copy(seed, 0, input, 0, seed.Length);
        input[seed.Length] = nonce;

        return SHAKE256.Process(input, length * 8);
        }

    #endregion
    #region // Noise ETA 
    /// <summary>
    /// Sample a polynomial deterministically from a seed and a nonce,
    /// with output polynomial close to centered binomial distribution,
    /// with parameter <see cref="ETA1"/>..
    /// </summary>
    /// <param name="seed">Input seed.</param>
    /// <param name="nonce">Input nonce.</param>
    /// <returns>Output polynomial.</returns>
    public PolynomialInt16 GetNoiseEta1(byte[] seed, byte nonce) {
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
    public PolynomialInt16 GetNoiseEta2(byte[] seed, byte nonce) {
        var length = ETA2 * N / 4;
        var buffer = PRF(length, seed, nonce);
        return PolynomialInt16.CBD2(buffer);
        }

    /// <summary>
    /// Given an array of uniformly random bytes, compute
    /// polynomial with coefficients distributed according to
    /// a centered binomial distribution with parameter eta=1
    /// as specified by Kyber mode.
    /// </summary>
    /// <param name="input">input byte array</param>
    /// <returns>output polynomial</returns>
    public PolynomialInt16 CbdEta1(byte[] input) => ETA1 == 2 ? PolynomialInt16.CBD2(input) : PolynomialInt16.CBD3(input);

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
