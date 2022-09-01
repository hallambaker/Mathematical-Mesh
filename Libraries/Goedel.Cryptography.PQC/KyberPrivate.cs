namespace Goedel.Cryptography.PQC;

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
    PolynomialVectorInt16 Skpv { get; }


    /// <summary>
    /// Constructor, initialize a private key from the keyblob <paramref name="privateKey"/>.
    /// The Kyber strength parameter is specified implicitly by the key size.
    /// </summary>
    /// <param name="privateKey">The private key.</param>
    public KyberPrivate(byte[] privateKey) : this (privateKey, GetStrength(privateKey.Length)){
        }

    KyberPrivate(byte[] privateKey, int strength) : 
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
    



    public byte[] Decrypt(byte[] ciphertext) {

        var hashSeed = IndCpaDecrypt (ciphertext);
        Test.DumpBufferHex(hashSeed, "Hashseed = 050A-4873-");


        // Multitarget countermeasure for coins + contributory KEM
        var (buf, kr) = GetBufKr(hashSeed);




        Test.DumpBufferHex(buf, "buf  = 050A-4873- - -55E6-E7BF");
        Test.DumpBufferHex(kr, "kr = 652B-9090-");

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

        var (bp, v) = UnPackCiphertext(buffer);

        bp.GetHash("Initial bp = EEBA-4E0B");
        v.GetHash("Initial v = 18D8-F841");

        // H(bp) = EEBA-4E0B-426C-1B7C-F9E4-4A79-8F5E-F9A2-5DE0-1342-0D0E-66A9-B4FE-9AC2-FC95-63AE
        // H(v) =  6187-12EB-082F-1D4D-AC40-1AE6-3AAA-1924-CBB4-A78C-CF59-09D0-EC83-937D-763C-147C

        bp.NTT();

        var mp = Skpv.PointwiseAccMontgomery (bp);

        mp.PolyInvNTT();

        mp.SubNeg(v);
        mp.Reduce();

        mp.GetHash("Final mp = 0831-9D6B-");

        return mp.ToMessageBytes();

        }

    public bool Verify(byte[] ciphertext, byte[] compare) {

        byte b = 0;
        for (var i = 0; i < ciphertext.Length; i++) {
            b |= (byte)(ciphertext[i] ^ compare[i]);
            }

        byte x = (byte)((b * -1) >> 31);


        return b == 0;

        }


    }