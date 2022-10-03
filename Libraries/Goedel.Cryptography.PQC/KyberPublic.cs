namespace Goedel.Cryptography.PQC;

/// <summary>
/// Kyber public key.
/// </summary>
public class KyberPublic : Kyber {

    ///<summary>Length of a polyvector for 512 bit key in bytes.</summary> 
    public const int PolyVectorBytes512 = 2 * Kyber.PolynomialBytes;
    ///<summary>Length of a polyvector for 768 bit key in bytes.</summary> 
    public const int PolyVectorBytes768 = 3 * Kyber.PolynomialBytes;
    ///<summary>Length of a polyvector for 1024 bit key in bytes.</summary> 
    public const int PolyVectorBytes1024 = 4 * Kyber.PolynomialBytes;

    ///<summary>Length of a public key for 512 bit key in bytes.</summary> 
    public const int PublicKeyBytes512 = PolyVectorBytes512 + Kyber.SymBytes;
    ///<summary>Length of a public key for 768 bit key in bytes.</summary>
    public const int PublicKeyBytes768 = PolyVectorBytes768 + Kyber.SymBytes;
    ///<summary>Length of a public key for 1024 bit key in bytes.</summary>
    public const int PublicKeyBytes1024 = PolyVectorBytes1024 + Kyber.SymBytes;

    byte[] PublicKey { get; }
    byte[] HashPublicKey { get; }


    ///<summary>The Public key polynomial vector.</summary> 
    PolynomialVectorInt16 Pkpv { get; }

    PolynomialMatrixInt16 at { get; }

    ///<summary>The seed value.</summary> 
    byte[] Seed { get; }

    readonly static int[] KeySize =
        new int[] { 512, 768, 1024 };

    /// <summary>
    /// Constructor, initialize a public key from the keyblob <paramref name="publicKey"/>.
    /// The Kyber strength parameter is specified implicitly by the key size.
    /// </summary>
    /// <param name="publicKey">The private key.</param>
    public KyberPublic(byte[] publicKey) : this (publicKey, GetStrength (publicKey.Length), publicKey.Length) {
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
    /// <param name="length">The length of the public key data.</param>
    protected KyberPublic(byte[] publicKey, int strength, int length, int offset=0) : 
                base (KeySize[strength]) {
        PublicKey = publicKey.Extract(offset, length); ;


        //Console.WriteLine($"Public key bytes {length}");

        //Test.DumpBufferHex(PublicKey, "Public key bytes");
        HashPublicKey = SHA3Managed.Process256(PublicKey);
        //K = strength+2;


        //Test.DumpBufferFingerprint(PublicKey, "**** Public Key:  A1DC-91E9-");
        Pkpv = new PolynomialVectorInt16(K, publicKey, offset); //failing
        //Pkpv.GetHash("Pkpv: 8C43-E3D2-");

        Seed = PublicKey.Extract(PolyVectorBytes, Kyber.SymBytes);

        at = PolynomialMatrixInt16.MatrixExpandFromSeed(K, Seed, true);




        }

    static int GetStrength(int length) => length switch {
        PublicKeyBytes512 => 0,
        PublicKeyBytes768 => 1,
        PublicKeyBytes1024 => 2,
        _ => throw new ArgumentOutOfRangeException()
        };


    /// <summary>
    /// Perform key agreement.
    /// </summary>
    /// <param name="seed">Optional seed value for deterministic testing.</param>
    /// <returns>The ciphertext and shared secret.</returns>
    public (byte[],byte[]) Encrypt(byte[]? seed=null) {
        seed ??= Platform.GetRandomBytes(SharedSecretBytes);

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

    /// <summary>
    /// Inner encryption primitive.
    /// </summary>
    /// <param name="message">The data to encrypt.</param>
    /// <param name="coins">The coins to be used in the encryption.</param>
    /// <returns>The ciphertext.</returns>
    public byte[] IndCpaEncrypt(byte[] message, byte[] coins) {
        // Moved out to key set up.
        //var p1 = new PolynomialVector(K, PublicKey, 0);
        //var seed = PublicKey.Extract(PolyVectorBytes, Kyber.SymBytes);

        var k = PolynomialInt16.FromMessageBytes(message);

        byte nonce = 0;
        var sp = new PolynomialVectorInt16(K);
        var ep = new PolynomialVectorInt16(K);

        for (var i = 0; i < K; i++) {
            sp.Vector[i] = GetNoiseEta1(coins, nonce++);
            }
        for (var i = 0; i < K; i++) {
            ep.Vector[i] = GetNoiseEta2(coins, nonce++);
            }
        var epp = GetNoiseEta2(coins, nonce++);

        sp.NTT();

        //sp.GetHash("Sp");
        // matrix-vector multiplication

        var bp = new PolynomialVectorInt16(K);
        for (var i = 0; i < K; i++) {
            bp.Vector[i] = at.PolynomialVector[i].PointwiseAccMontgomery(sp);
            }

        var v = Pkpv.PointwiseAccMontgomery(sp);

        bp.PolyInvNTT();
        v.PolyInvNTT();
        bp.Add(ep);

        v.Add(epp);
        v.Add(k);
        bp.Reduce();
        v.Reduce();

        return PackCiphertext(bp, v);
        }

    }
