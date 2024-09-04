
using System.Data.SqlTypes;

namespace Goedel.Cryptography.Nist;

public class KyberPrivate {
    public KyberNist Kyber { get; }

    public KyberPublic KyberPublic { get; }
    


    ///<summary>The seed key. Note that this may not be available if the
    ///private keyt was reconstructed from the expanded FIPS 204 private key.</summary> 
    public byte[] Seed { get; init; }

    ///<summary>The encoded Public Key value</summary> 
    public byte[] PublicKey { get; init; }

    ///<summary>The encoded Secret Key value</summary>
    public byte[] SecretKey { get; init; }

    private KyberPrivate(byte[] sk, KyberNist kyber) {
        Kyber = kyber;
        SecretKey = sk;

        var k384 = 384 * kyber.Parameters.K;
        PublicKey = sk[k384..(2 * k384 + 32)];

        KyberPublic =  KyberPublic.FromPublicKey(PublicKey);
        }

    /// <summary>
    /// Factory method returning an instance generated from the seed
    /// <paramref name="seed"/> with strength <paramref name="parameterSet"/>.
    /// </summary>
    /// <param name="seed">The 64 byte seed.</param>
    /// <param name="parameterSet">The parameter set</param>
    /// <returns>The private key.</returns>
    public static KyberPrivate FromSeed(byte[] seed, KyberParameterSet parameterSet)=>
        FromSeed (seed, KyberNist.GetKyberNist(parameterSet));

    /// <summary>
    /// Factory method returning an instance generated from the seed
    /// <paramref name="seed"/> with strength <paramref name="parameterSet"/>.
    /// </summary>
    /// <param name="seed">The 64 byte seed.</param>
    /// <param name="kyber">The parameter set</param>
    /// <returns>The private key.</returns>
    public static KyberPrivate FromSeed(byte[] seed, KyberNist kyber) {
        //var digest = SHA3_256.HashData(seed);
        var z = seed[..32];
        var d = seed[32..];

        var (_, secretKey) = kyber.GenerateKey(z, d);

        return new KyberPrivate(secretKey, kyber) {
            Seed = seed
            };
        }


    /// <summary>
    /// Factory method returning an instance generated from the seed
    /// <paramref name="z"/> , <paramref name="d"/> with strength <paramref name="parameterSet"/>.
    /// </summary>
    /// <param name="z">A 32 byte seed.</param>
    /// <param name="d">A 32 byte seed.</param>
    /// <param name="parameterSet">The parameter set</param>
    /// <returns>The private key.</returns>
    public static KyberPrivate FromZD(byte[] z, byte[] d, KyberParameterSet parameterSet) {
        var kyber = KyberNist.GetKyberNist(parameterSet);
        var (_, secretKey) = kyber.GenerateKey(z,d);

        return new KyberPrivate(secretKey, kyber);
        }


    /// <summary>
    /// Factory method returning an instance generated from the secret key value
    /// <paramref name="sk"/>.
    /// </summary>
    /// <param name="sk">The expanded secret key./param>
    /// <returns>The private key.</returns>
    public static KyberPrivate FromSecretKey(byte[] dk) {
        var kyber = KyberNist.GetByPrivateKeyLength(dk.Length);
        return new KyberPrivate(dk, kyber);
        }


    /// <summary>
    /// Decapsulate a shared secret
    /// </summary>

    /// <param name="c">Encapsulated shared secret</param>
    /// <returns>Decapsulated shared secret</returns>
    public (byte[] sharedKey, bool implicitRejection) Decapsulate(byte[] c) =>
        Kyber.Decapsulate(this, c);

    }
