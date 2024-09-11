#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using Goedel.Cryptography.Nist;

namespace Goedel.Cryptography.PQC;

/// <summary>
/// Kem Ciphertext result.
/// </summary>
/// <param name="Value"></param>
public record AgreementDataBinary(byte[] Value) : IAgreementData {

    }

/// <summary>
/// ML-KEM keypair implemented according to FIPS 203 https://csrc.nist.gov/pubs/fips/203/final
/// </summary>
public class KeyPairMlKemNist : KeyPair, IOpaqueBinaryKey {

    #region //Properties

    ///<summary>The public key value.</summary>
    public KyberPublic PublicKey { get; set; }
    ///<summary>The private key value</summary>
    public KyberPrivate PrivateKey { get; set; }

    ///<inheritdoc/>
    public int[] OID => PublicKey.Kyber.Parameters.ParameterSet switch {
        KyberParameterSet.ML_KEM_512 => Constants.OID__id_alg_ml_kem_512,
        KyberParameterSet.ML_KEM_768 => Constants.OID__id_alg_ml_kem_768,
        KyberParameterSet.ML_KEM_1024 => Constants.OID__id_alg_ml_kem_1024,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public string JsonAlgorithmId => PublicKey.Kyber.Parameters.ParameterSet switch {
        KyberParameterSet.ML_KEM_512 => JoseConstants.MLKEM512,
        KyberParameterSet.ML_KEM_768 => JoseConstants.MLKEM768,
        KyberParameterSet.ML_KEM_1024 => JoseConstants.MLKEM1024,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public byte[] GetPublicBinary() => PublicKey.PublicKey;

    ///<inheritdoc/>
    public byte[] GetPrivateBinary() => PrivateKey.Seed;

    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public PrivateKeyInfo PrivateKeyInfo { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public PublicKeyInfo PublicKeyInfo { get; }

    ///<inheritdoc/>
    public override IPKIXPrivateKey PKIXPrivateKey => PrivateKeyInfo;

    ///<inheritdoc/>
    public override IPKIXPublicKey PKIXPublicKey => PublicKeyInfo;

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = KeyUses.Any;

    ///<inheritdoc/>
    public override SubjectPublicKeyInfo KeyInfoData => PublicKeyInfo.SubjectPublicKeyInfo();

    ///<inheritdoc/>
    public override bool PublicOnly => PrivateKeyInfo is null;

    #endregion


    /// <summary>
    /// Constructore returning an instance from the binary key data
    /// <paramref name="publicKey"/>, <paramref name="privateKey"/> with
    /// security properties <paramref name="keySecurity"/> and uses
    /// <paramref name="keyUses"/>.
    /// </summary>
    /// <param name="publicKey">The public key data.</param>
    /// <param name="privateKey">The private key seed.</param>
    /// <param name="keySecurity">The key security.</param>
    /// <param name="keyUses">The key uses.</param>
    public KeyPairMlKemNist(
            byte[]? publicKey,
            byte[]? privateKey,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) : this(
                        publicKey is null ? null : KyberPublic.FromPublicKey(publicKey),
                        privateKey is null ? null : KyberPrivate.FromSecretKey(privateKey),
                        keySecurity, keyUses) {
        }


    /// <summary>
    /// Constructore returning an instance from the binary key data
    /// <paramref name="publicKey"/>, <paramref name="privateKey"/> with
    /// security properties <paramref name="keySecurity"/> and uses
    /// <paramref name="keyUses"/>.
    /// </summary>
    /// <param name="publicKey">The public key data.</param>
    /// <param name="privateKey">The private key seed.</param>
    /// <param name="keySecurity">The key security.</param>
    /// <param name="keyUses">The key uses.</param>
    public KeyPairMlKemNist(
            KyberPublic publicKey,
            KyberPrivate? privateKey = null,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) : base(keySecurity) {

        PublicKey = publicKey ?? privateKey.KyberPublic;
        PrivateKey = privateKey;
        PrivateKeyInfo = new(this);
        PublicKeyInfo = new(this);
        KeyUses = keyUses;

        CryptoAlgorithmId = PublicKey.Kyber.Parameters.ParameterSet switch {
            KyberParameterSet.ML_KEM_512 => CryptoAlgorithmId.MLKEM512,
            KyberParameterSet.ML_KEM_768 => CryptoAlgorithmId.MLKEM768,
            KyberParameterSet.ML_KEM_1024 => CryptoAlgorithmId.MLKEM1024,
            _ => throw new InternalCryptographicException()
            };
        }


    /// <summary>
    /// Generate a key pair for the specified algorithm and key size.
    /// </summary>
    /// <param name="keySize">The Key size, must be 255 or 448</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The generated key pair</returns>
    public static KeyPair KeyPairFactory(
                int keySize = 0,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.NULL) {

        KyberNist mlKem = cryptoAlgorithmID switch {
            CryptoAlgorithmId.MLKEM512 => KyberNist.Kyber512,
            CryptoAlgorithmId.MLKEM768 => KyberNist.Kyber768,
            CryptoAlgorithmId.MLKEM1024 => KyberNist.Kyber1024,
            _ => null
            };

        mlKem ??= keySize switch {
            0 => KyberNist.Kyber1024,
            512 => KyberNist.Kyber512,
            768 => KyberNist.Kyber768,
            1024 => KyberNist.Kyber1024,
            _ => throw new KeySizeNotSupported()
            };

        return Generate(mlKem, null, keySecurity, keyUses);

        }


    /// <summary>
    /// Factory creating a key pair of the type specified by <paramref name="algorithmID"/>
    /// using the data provided by a UDF identifier. 
    /// </summary>
    /// <param name="algorithmID">The type of key to create.</param>
    /// <param name="keyCollection">The key collection to add the key to.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The allowed key uses.</param>
    /// <param name="ikm">Initial keying material for the key.</param>
    /// <param name="keySpecifier">Key specifier material for the key.</param>
    /// <param name="keyName">Optional key name used to specify generation of multiple keys from 
    /// a single seed.</param>
    /// <param name="keySize">The size of the key in bits.</param>
    /// <returns>the derrived key.</returns>
    public static new KeyPair Factory(
        CryptoAlgorithmId algorithmID,
        KeySecurity keySecurity,
        byte[] ikm,
        byte[] keySpecifier,
        string keyName,
        IKeyLocate keyCollection = null,
        int keySize = 0,
        KeyUses keyUses = KeyUses.Any) {

        switch (algorithmID) {
            case CryptoAlgorithmId.MLKEM512: {
                var binaryData = KeySeed(KyberNist.SeedBytes * 8, ikm, keySpecifier, keyName);
                return Generate(KyberNist.Kyber512, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLKEM768: {
                var binaryData = KeySeed(KyberNist.SeedBytes * 8, ikm, keySpecifier, keyName);
                return Generate(KyberNist.Kyber768, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLKEM1024: {
                var binaryData = KeySeed(KyberNist.SeedBytes * 8, ikm, keySpecifier, keyName);
                return Generate(KyberNist.Kyber1024, binaryData, keySecurity, keyUses);
                }
            };
        throw new NoProviderSpecified();
        }


    static KeyPairMlKemNist Generate(
                KyberNist mlKem,
                byte[]? seed = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {
        seed = seed ?? Platform.GetRandomBytes(KyberNist.SeedBytes);
        var privateKey = KyberPrivate.FromSeed(seed, mlKem);
        return new KeyPairMlKemNist(null, privateKey, keySecurity, keyUses);
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairMlKemNist(PublicKey, keyUses: KeyUses) {
        Locator = Locator
        };

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {

        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = PrivateKeyInfo ?? new PrivateKeyInfo(this) { };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());

        }

    ///<inheritdoc/>
    public override byte[] Decrypt(
                byte[] encryptedKey,
                IAgreementData ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] salt = null) {
        var (sharedKey, implicitRejection) = PrivateKey.Decapsulate(encryptedKey);

        throw new NotImplementedException();
        }


    ///<inheritdoc/>
    public override void Encrypt(
                    byte[] key,
                    out byte[] exchange,
                    out IAgreementData agreementData,
                    byte[] salt = null) {

        var seed = Shake256.HashData(key, 32);
        var (ciphertext,  sharedSecret) = PublicKey.Encapsulate(seed);

        exchange = Platform.KeyWrapRFC3394.Wrap(sharedSecret, key);
        agreementData = new AgreementDataBinary (ciphertext);

        }



    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override byte[] SignDigest(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) =>
        throw new OperationNotSupported();


    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override bool VerifyDigest(
                byte[] digest, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) =>
        throw new OperationNotSupported();
    }



