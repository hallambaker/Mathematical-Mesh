using Goedel.Utilities;
using Goedel.Cryptography;


namespace Goedel.Cryptography.Nist;

/// <summary>
/// Private key backing class, holds the expanded private key values.
/// </summary>
public class DilithiumPrivate {
    DilithiumNist Dilithium { get; }

    ///<summary>The seed key. Note that this may not be available if the
    ///private keyt was reconstructed from the expanded FIPS 204 private key.</summary> 
    public byte[] Seed { get; init; }

    ///<summary>The encoded Public Key value</summary> 
    public byte[]PublicKey { get; init; }

    ///<summary>The encoded Secret Key value</summary> 
    public byte[]SecretKey { get; init; }

    internal BitArray K { get; }
    internal BitArray TR { get; }


    internal int[][] S1Hat { get; }
    internal int[][] S2Hat { get; }
    internal int[][] T0Hat { get; }
    internal int[][][] AHat { get; }

    private DilithiumPrivate(byte[] sk, DilithiumNist dilithium) {
        Dilithium = dilithium;

        (var rho, K, TR, var s1, var s2, var t0) = Dilithium.SkDecode(sk);
        S1Hat = s1.Select(Dilithium.NTT).ToArray();
        S2Hat = s2.Select(Dilithium.NTT).ToArray();
        T0Hat = t0.Select(Dilithium.NTT).ToArray();
        AHat = Dilithium.ExpandA(rho);

        }



    /// <summary>
    /// Factory method returning an instance generated from the seed
    /// <paramref name="seed"/> with strength <paramref name="parameterSet"/>.
    /// </summary>
    /// <param name="seed">The 32 byte seed.</param>
    /// <param name="parameterSet">The parameter set</param>
    /// <returns>The private key.</returns>
    public static DilithiumPrivate FromSeed(byte[] seed, DilithiumParameterSet parameterSet) {

        var dilithium = DilithiumNist.GetDilithiumNist(parameterSet);
        var (publicKey, secretKey) = dilithium.GenerateKey(seed);

        return new DilithiumPrivate(secretKey, dilithium) {
            Seed = seed,
            PublicKey = publicKey,
            SecretKey = secretKey
            };
        }

    /// <summary>
    /// Factory method returning an instance generated from the secret key value
    /// <paramref name="sk"/>.
    /// </summary>
    /// <param name="sk">The expanded secret key./param>
    /// <returns>The private key.</returns>
    public static DilithiumPrivate FromSecretKey(byte[] sk) => 
                new DilithiumPrivate(sk, DilithiumNist.GetByPrivateKeyLength (sk.Length));



    /// <summary>
    /// Signs a message with this secret key
    /// </summary>
    /// <param name="message">Arbitrary set of bits.</param>
    /// <param name="context">Optional context string of 255 bytes or fewer.</param>
    /// <param name="rnd">The deterministic seed value.</param>
    /// <returns>Signature</returns>
    public byte[] SignPure(
                byte[] message,
                byte[] context,
                byte[] rnd = null) => SignInternal(
                    DilithiumNist.CreateManifestPrefixPure(message, context), message, rnd: rnd);

    /// <summary>
    /// Signs a message with this secret key
    /// </summary>
    /// <param name="digest">The digest value.</param>
    /// <param name="oid">An OID specifying the digest algorithm.</param>
    /// <param name="context">Optional context string of 255 bytes or fewer.</param>
    /// <param name="rnd">The deterministic seed value.</param>
    /// <returns>Signature</returns>
    public byte[] SignHashed(
                byte[] digest,
                byte[] oid,
                byte[] context,
                byte[] rnd = null) => SignInternal(
                    DilithiumNist.CreateManifestPrefixHashed(digest, oid, context), digest, rnd: rnd);

    /// <summary>
    /// Signs a message with this secret key
    /// </summary>
    /// <param name="message">Arbitrary set of bits.</param>
    /// <param name="prefix">Prefix inserted ahead of the message to specify
    /// the manifest data.</param>
    /// <param name="rnd">The deterministic seed value.</param>
    /// <returns>Signature</returns>
    public byte[] SignInternal(
                byte[] message,
                byte[]? prefix = null,
                byte[] rnd = null) => Dilithium.SignInternal(this, message, prefix, rnd: rnd);


    }
