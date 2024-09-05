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


//using Goedel.Cryptography.Jose;

using Goedel.Cryptography.Nist;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// ML-DSA keypair implemented according to FIPS 204 https://csrc.nist.gov/pubs/fips/204/ipd
/// </summary>
public class KeyPairMlDsaNist : KeyPair, IOpaqueBinaryKey {

    #region //Properties

    ///<summary>The public key value.</summary>
    public DilithiumPublic PublicKey { get; set; }
    ///<summary>The private key value</summary>
    public DilithiumPrivate PrivateKey { get; set; }

    ///<inheritdoc/>
    public int[] OID => PublicKey.Dilithium.Parameters.ParameterSet switch {
        DilithiumParameterSet.ML_DSA_44 => Constants.OID__id_ml_dsa_44,
        DilithiumParameterSet.ML_DSA_65 => Constants.OID__id_ml_dsa_65,
        DilithiumParameterSet.ML_DSA_87 => Constants.OID__id_ml_dsa_87,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public string JsonAlgorithmId => PublicKey.Dilithium.Parameters.ParameterSet switch {
        DilithiumParameterSet.ML_DSA_44 => JoseConstants.MLDSA44,
        DilithiumParameterSet.ML_DSA_65 => JoseConstants.MLDSA65,
        DilithiumParameterSet.ML_DSA_87 => JoseConstants.MLDSA87,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public byte[] GetPublicBinary() => PublicKey?.PublicKey;

    ///<inheritdoc/>
    public byte[] GetPrivateBinary() => PrivateKey?.SecretKey;
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
    public KeyPairMlDsaNist(
            byte[]? publicKey,
            byte[]? privateKey,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) : this(
                        publicKey is null ? null : DilithiumPublic.FromPublicKey(publicKey),
                        privateKey is null ? null : DilithiumPrivate.FromSecretKey(privateKey),
                        keySecurity, keyUses) {
        }

    /// <summary>
    /// Constructore returning an instance from the key data
    /// <paramref name="publicKey"/>, <paramref name="privateKey"/> with
    /// security properties <paramref name="keySecurity"/> and uses
    /// <paramref name="keyUses"/>.
    /// </summary>
    /// <param name="publicKey">The public key data.</param>
    /// <param name="privateKey">The private key seed.</param>
    /// <param name="keySecurity">The key security.</param>
    /// <param name="keyUses">The key uses.</param>
    public KeyPairMlDsaNist(
                DilithiumPublic? publicKey,
                DilithiumPrivate? privateKey = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) : base(keySecurity) {
        PublicKey = publicKey;
        PrivateKey = privateKey;
        PrivateKeyInfo = new(this);
        PublicKeyInfo = new(this);
        KeyUses = keyUses;

        CryptoAlgorithmId = PublicKey.Dilithium.Parameters.ParameterSet switch {
            DilithiumParameterSet.ML_DSA_44 => CryptoAlgorithmId.MLKEM512,
            DilithiumParameterSet.ML_DSA_65 => CryptoAlgorithmId.MLKEM768,
            DilithiumParameterSet.ML_DSA_87 => CryptoAlgorithmId.MLKEM1024,
            _ => throw new InternalCryptographicException()
            };
        }





    /// <summary>
    /// Generate a key pair for the specified algorithm and key size.
    /// </summary>
    /// <param name="keySize">The Key size, must be 44, 65 or 87</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The generated key pair</returns>
    public static KeyPair KeyPairFactory(
                int keySize = 0,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.NULL) {

        DilithiumParameterSet mode = cryptoAlgorithmID switch {
            CryptoAlgorithmId.MLDSA44 => DilithiumParameterSet.ML_DSA_44,
            CryptoAlgorithmId.MLDSA65 => DilithiumParameterSet.ML_DSA_65,
            CryptoAlgorithmId.MLDSA87 => DilithiumParameterSet.ML_DSA_87,
            _ => DilithiumParameterSet.None
            };

        mode = (mode != DilithiumParameterSet.None) ? mode : keySize switch {
            0 => DilithiumParameterSet.ML_DSA_87,
            44 => DilithiumParameterSet.ML_DSA_44,
            65 => DilithiumParameterSet.ML_DSA_65,
            87 => DilithiumParameterSet.ML_DSA_87,
            _ => DilithiumParameterSet.None
            };

        (mode == DilithiumParameterSet.None).AssertFalse(KeySizeNotSupported.Throw);

        return Generate(mode, null, keySecurity, keyUses);

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
            case CryptoAlgorithmId.MLDSA44: {
                var binaryData = KeySeed(256, ikm, keySpecifier, keyName);
                return Generate(DilithiumParameterSet.ML_DSA_44, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLDSA65: {
                var binaryData = KeySeed(256, ikm, keySpecifier, keyName);
                return Generate(DilithiumParameterSet.ML_DSA_65, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLDSA87: {
                var binaryData = KeySeed(256, ikm, keySpecifier, keyName);
                return Generate(DilithiumParameterSet.ML_DSA_87, binaryData, keySecurity, keyUses);

                }
            };
        throw new NoProviderSpecified();
        }


    static KeyPairMlDsaNist Generate(
                DilithiumParameterSet mode,
                byte[]? seed = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {

        seed = seed ?? Platform.GetRandomBytes(32);
        var privateKey = DilithiumPrivate.FromSeed(seed, mode);
        var publicKey = DilithiumPublic.FromPublicKey(privateKey.PublicKey);

        return new KeyPairMlDsaNist(publicKey, privateKey, keySecurity, keyUses);
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairMlDsaNist(PublicKey, keyUses: KeyUses) {
        Locator = Locator
        };

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = PrivateKeyInfo ?? new PrivateKeyInfo(this) { };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());

        }

    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-DSA does not support signature operations.</exception>
    public override byte[] Decrypt(byte[] encryptedKey, KeyPair ephemeral = null, byte[] ciphertext = null, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, KeyAgreementResult partial = null, byte[] salt = null) {
        throw new OperationNotSupported();
        }


    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-DSA does not support signature operations.</exception>
    public override void Encrypt(byte[] key, out byte[] exchange, out KeyPair ephemeral, out byte[] ciphertext, byte[] salt = null) {
        throw new OperationNotSupported();
        }

    ///<inheritdoc/>
    public override byte[] Sign(byte[] data, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {

        // have to add in the wrappers for pre hash etc...

        return base.Sign(data, algorithmID, context);
        }

    ///<inheritdoc/>
    public override bool Verify(byte[] data, byte[] signature, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {

        // have to add in the wrappers for pre hash etc...

        return base.Verify(data, signature, algorithmID, context);
        }


    ///<inheritdoc/>
    public override byte[] SignHash(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {


        // have to add in the wrappers for pre hash etc...

        var sig = PrivateKey.SignInternal(data);
        return sig;
        }


    ///<inheritdoc/>
    public override bool VerifyHash(
                byte[] digest, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {

        // have to add in the wrappers for pre hash etc...

        var result = PublicKey.Verify(signature, digest);

        return result;
        }
    }



