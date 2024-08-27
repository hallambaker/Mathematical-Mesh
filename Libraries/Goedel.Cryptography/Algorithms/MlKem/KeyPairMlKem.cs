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



using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// ML-KEM keypair implemented according to FIPS 203 https://csrc.nist.gov/pubs/fips/203/final
/// </summary>
public class KeyPairMlKem : KeyPair, IOpaqueBinaryKey {

    #region //Properties

    ///<summary>The public key value.</summary>
    public MlKemPublic PublicKey { get; set; }
    ///<summary>The private key value</summary>
    public MlKemPrivate PrivateKey { get; set; }

    ///<inheritdoc/>
    public int[] OID => PublicKey.KeySize switch {
        44 => Constants.OID__id_alg_ml_kem_512,
        65 => Constants.OID__id_alg_ml_kem_768,
        87 => Constants.OID__id_alg_ml_kem_1024,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public string JsonAlgorithmId => PublicKey.KeySize switch {
        512 => JoseConstants.MLKEM512,
        768 => JoseConstants.MLKEM768,
        1024 => JoseConstants.MLKEM1024,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public byte[] GetPublicBinary() => PublicKey.PublicKey;

    ///<inheritdoc/>
    public byte[] GetPrivateBinary() => PrivateKey.PrivateKey;

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
    public KeyPairMlKem(
            byte[] publicKey,
            byte[]? privateKey,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) :
                        this(new MlKemPublic(publicKey),
                        privateKey is null ? null : new MlKemPrivate(privateKey),
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
    public KeyPairMlKem(
            MlKemPublic publicKey,
            MlKemPrivate? privateKey = null,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) : base(keySecurity) {

        PublicKey = publicKey;
        PrivateKey = privateKey;
        PrivateKeyInfo = new (this);
        PublicKeyInfo = new (this);

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

        MlKem mlKem = cryptoAlgorithmID switch {
            CryptoAlgorithmId.MLKEM512 => MlKem.MLKEM512,
            CryptoAlgorithmId.MLKEM768 => MlKem.MLKEM768,
            CryptoAlgorithmId.MLKEM1024 => MlKem.MLKEM1024,
            _ => null
            };

        mlKem ??= keySize switch {
            0 => MlKem.MLKEM1024,
            512 => MlKem.MLKEM512,
            768 => MlKem.MLKEM768,
            1024 => MlKem.MLKEM1024,
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
                var binaryData = KeySeed(MlKem.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(MlKem.MLKEM512, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLKEM768: {
                var binaryData = KeySeed(MlKem.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(MlKem.MLKEM512, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLKEM1024: {
                var binaryData = KeySeed(MlKem.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(MlKem.MLKEM512, binaryData, keySecurity, keyUses);
                }
            };
        throw new NoProviderSpecified();
        }


    static KeyPairMlKem Generate(
                MlKem mlKem,
                byte[]? seed=null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {
        seed = seed ?? Platform.GetRandomBytes(MlKem.SymBytes);
        var (publicKey, privateKey) = mlKem.KeyPair(seed);
        return new KeyPairMlKem (publicKey, privateKey, keySecurity, keyUses);
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairMlKem(PublicKey, keyUses: KeyUses) {
        Locator = Locator
        };

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {

        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = PrivateKeyInfo ?? new PrivateKeyInfo(this) { };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());

        }

    ///<inheritdoc/>
    public override byte[] Decrypt(byte[] encryptedKey, KeyPair ephemeral = null, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, KeyAgreementResult partial = null, byte[] salt = null) {
        return PrivateKey.Decrypt(encryptedKey);
        }


    ///<inheritdoc/>
    public override void Encrypt(byte[] key, out byte[] exchange, out KeyPair ephemeral, byte[] salt = null) {
        var (ciphertext, sharedSecret) = PublicKey.Encrypt();

        ephemeral = null;
        exchange = ciphertext;
        }



    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override byte[] SignHash(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) =>
        throw new OperationNotSupported();


    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override bool VerifyHash(
                byte[] digest, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) =>
        throw new OperationNotSupported();
    }



