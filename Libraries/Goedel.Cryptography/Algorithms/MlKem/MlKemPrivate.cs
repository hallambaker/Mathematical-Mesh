namespace Goedel.Cryptography.PQC;

/// <summary>
/// Kyber private key.
/// </summary>
public class MlKemPrivate : MlKemPublic {

    ///<summary>Size of 512 bit private key in bytes.</summary> 
    public const int PrivateKeyBytes512 = PublicKeyBytes512 + PolyVectorBytes512 + 2 * MlKem.SymBytes;
    ///<summary>Size of 512 bit private key in bytes.</summary> 
    public const int PrivateKeyBytes768 = PublicKeyBytes768 + PolyVectorBytes768 + 2 * MlKem.SymBytes;
    ///<summary>Size of 512 bit private key in bytes.</summary> 
    public const int PrivateKeyBytes1024 = PublicKeyBytes1024 + PolyVectorBytes1024 + 2 * MlKem.SymBytes;

    ///<summary>Size of 512 bit public key in bytes.</summary> 
    public const int PublicKeyOffset512 = PolyVectorBytes512;
    ///<summary>Size of 512 bit public key in bytes.</summary> 
    public const int PublicKeyOffset768 = PolyVectorBytes768;
    ///<summary>Size of 512 bit public key in bytes.</summary> 
    public const int PublicKeyOffset1024 = PolyVectorBytes1024;

    int EncryptFailOffset => PrivateKeyBytes - SymBytes;

    readonly static int[] PublicKeyLength =
        new int[] { PublicKeyBytes512, PublicKeyBytes768, PublicKeyBytes1024 };
    readonly static int[] PublicKeyOffset =
        new int[] { PublicKeyOffset512, PublicKeyOffset768, PublicKeyOffset1024 };

    public byte[] PrivateKey { get; }

    ///<summary>The Public key polynomial vector.</summary> 
    PolynomialVectorInt16 Skpv { get; }


    /// <summary>
    /// Constructor, initialize a private key from the keyblob <paramref name="privateKey"/>.
    /// The Kyber strength parameter is specified implicitly by the key size.
    /// </summary>
    /// <param name="privateKey">The private key.</param>
    public MlKemPrivate(byte[] privateKey) : this(privateKey, GetStrength(privateKey.Length)) {
        }

    MlKemPrivate(byte[] privateKey, int strength) :
                base(privateKey, strength, PublicKeyLength[strength], PublicKeyOffset[strength]) {
        PrivateKey = privateKey;


        Skpv = new PolynomialVectorInt16(K, PrivateKey, 0);
        }

    static int GetStrength(int length) => length switch {
        PrivateKeyBytes512 => 0,
        PrivateKeyBytes768 => 1,
        PrivateKeyBytes1024 => 2,
        _ => throw new ArgumentOutOfRangeException()
        };

    //static byte[] GetPublic(byte[] privateKey, int strength) =>
    //    privateKey.Extract(PublicKeyOffset[strength], PublicKeyLength[strength]);



    /// <summary>
    /// Decrypt the ciphertext <paramref name="ciphertext"/> and return the plaintext.
    /// </summary>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <returns>The plaintext.</returns>
    public byte[] Decrypt(byte[] ciphertext) {

        var hashSeed = IndCpaDecrypt(ciphertext);
        //Test.DumpBufferHex(hashSeed, "Hashseed = 050A-4873-");


        // Multitarget countermeasure for coins + contributory KEM
        var (buf, kr) = GetBufKr(hashSeed);

        //Test.DumpBufferHex(buf, "buf  = 050A-4873- - -55E6-E7BF");
        //Test.DumpBufferHex(kr, "kr = 652B-9090-");

        // call indcpa here
        var cmp = IndCpaEncrypt(buf, kr);


        var fail = Verify(ciphertext, cmp);


        // This step is no longer performed in ML-KEM
        if (!Fips203) {
            /* overwrite coins in kr with H(c) */
            var overwrite = SHA3Managed.Process256(ciphertext);
            Array.Copy(overwrite, 0, kr, MlKem.SymBytes, overwrite.Length);
            }

        // Overwrite pre-k with z on re-encryption failure
        if (fail) {
            Array.Copy(PrivateKey, EncryptFailOffset, kr, 0, MlKem.SymBytes);
            }

        // hash concatenation of pre-k and H(c) to k
        var ss = SHAKE256.Process(kr);

        return ss;
        }

    /// <summary>
    /// Decrypt the ciphertext <paramref name="ciphertext"/> and return the plaintext.
    /// </summary>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <returns>The plaintext.</returns>
    public byte[] IndCpaDecrypt(byte[] ciphertext) {

        var (bp, v) = UnPackCiphertext(ciphertext);

        //bp.GetHash("Initial bp = EEBA-4E0B");
        //v.GetHash("Initial v = 18D8-F841");

        bp.NTT();

        var mp = Skpv.PointwiseAccMontgomery(bp);

        mp.PolyInvNTT();

        mp.SubNeg(v);
        mp.Reduce();

        //mp.GetHash("Final mp = 0831-9D6B-");

        return mp.ToMessageBytes();

        }


    /// <summary>
    /// Verify that <paramref name="first"/> matches <paramref name="second"/>
    /// exactly in constant time.
    /// </summary>
    /// <param name="first">The first input.</param>
    /// <param name="second">The second input.</param>
    /// <returns>True if <paramref name="first"/> exactly matches <paramref name="second"/>,
    /// otherwise false.</returns>
    public bool Verify(byte[] first, byte[] second) {

        byte b = 0;
        for (var i = 0; i < first.Length; i++) {
            b |= (byte)(first[i] ^ second[i]);
            }

        byte x = (byte)((b * -1) >> 31);


        return b == 0;

        }


    }