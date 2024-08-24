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

//OID sigAlgs 	nistalgorithm	3
//OID kems 		nistalgorithm	4

//OID id_alg_ml_kem_512		kems 1
//OID id_alg-ml-kem-768		kems 2
//OID id_alg-ml-kem-1024		kems 3
//OID id_ml_dsa_44			sigAlgs 17
//OID id_ml_dsa_65			sigAlgs 18
//OID id_ml_dsa_87			sigAlgs 19

using Goedel.Cryptography.Jose;

using System.Security.Cryptography.X509Certificates;

namespace Goedel.Cryptography.PQC;


/// <summary>
/// ML-DSA keypair implemented according to FIPS 204 https://csrc.nist.gov/pubs/fips/204/ipd
/// </summary>
public class KeyPairMlDsa : KeyPair, IOpaqueBinaryKey {

    #region //Properties

    ///<summary>The public key value.</summary>
    public DilithiumPublic PublicKey { get; set; }
    ///<summary>The private key value</summary>
    public DilithiumPrivate PrivateKey { get; set; }

    ///<inheritdoc/>
    public int[] OID => PublicKey.Mode switch {
        DilithiumMode.Mode2 => Constants.OID__id_ml_dsa_44,
        DilithiumMode.Mode3 => Constants.OID__id_ml_dsa_65,
        DilithiumMode.Mode5 => Constants.OID__id_ml_dsa_87,
        _ => throw new InternalCryptographicException()
        };

    ///<inheritdoc/>
    public string JsonAlgorithmId => PublicKey.Mode switch {
        DilithiumMode.Mode2 => JoseConstants.MLDSA44,
        DilithiumMode.Mode3 => JoseConstants.MLDSA65,
        DilithiumMode.Mode5 => JoseConstants.MLDSA87,
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
    public KeyPairMlDsa(
            byte[] publicKey,
            byte[]? privateKey,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) : 
                        this (new DilithiumPublic(publicKey),
                        privateKey is null ? null : new DilithiumPrivate(privateKey), 
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
    public KeyPairMlDsa (
                DilithiumPublic publicKey, 
                DilithiumPrivate privateKey = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) : base(keySecurity) {
        PublicKey = publicKey;
        PrivateKey = privateKey;
        PrivateKeyInfo = new(this);
        PublicKeyInfo = new(this);
        KeyUses = keyUses;
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

        DilithiumMode mode = cryptoAlgorithmID switch {
            CryptoAlgorithmId.MLDSA44 => DilithiumMode.Mode2,
            CryptoAlgorithmId.MLDSA65 => DilithiumMode.Mode3,
            CryptoAlgorithmId.MLDSA87 => DilithiumMode.Mode5,
            _ => DilithiumMode.Unknown
            };

        mode =(mode != DilithiumMode.Unknown) ? mode : keySize switch {
                0 => DilithiumMode.Mode5,
                44 => DilithiumMode.Mode2,
                65 => DilithiumMode.Mode3,
                87 => DilithiumMode.Mode5,
                _ => DilithiumMode.Unknown
                };

        (mode == DilithiumMode.Unknown).AssertFalse(KeySizeNotSupported.Throw);

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
                var binaryData = KeySeed(Kyber.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(DilithiumMode.Mode2, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLDSA65: {
                var binaryData = KeySeed(Kyber.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(DilithiumMode.Mode3, binaryData, keySecurity, keyUses);
                }
            case CryptoAlgorithmId.MLDSA87: {
                var binaryData = KeySeed(Kyber.SymBytes * 8, ikm, keySpecifier, keyName);
                return Generate(DilithiumMode.Mode5, binaryData, keySecurity, keyUses);

                }
            };
        throw new NoProviderSpecified();

        }


    static KeyPairMlDsa Generate(
                DilithiumMode mode,
                byte[]? seed = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) {

        seed = seed ?? Platform.GetRandomBytes(Kyber.SymBytes);
        var (publicKey, privateKey) = MLDSA.GenerateKeypair(mode, seed);
        return new KeyPairMlDsa(publicKey, privateKey, keySecurity, keyUses);
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairMlDsa(PublicKey, keyUses: KeyUses) {
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
        throw new OperationNotSupported();
        }


    ///<inheritdoc/>
    public override void Encrypt(byte[] key, out byte[] exchange, out KeyPair ephemeral, byte[] salt = null) {

        throw new OperationNotSupported();
        }

    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override byte[] SignHash(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {

        var sig = PrivateKey.Sign(data);
        return sig;
        }
    

    ///<inheritdoc/>
    ///<exception cref="OperationNotSupported">ML-KEM does not support signature operations.</exception>
    public override bool VerifyHash(
                byte[] digest, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {

        var result = PublicKey.Verify(signature, digest);

        return result;
        }
    }



