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

namespace Goedel.Cryptography;


/// <summary>
/// Interface exposing the public Diffie Hellman parameters in the same form provided
/// by PKIXPublicKeyDH
/// </summary>
public interface IKeyPublicDH {

    /// <summary> ASN.1 member Shared </summary>
    byte[] Shared { get; set; }

    /// <summary> ASN.1 member Public </summary>
    byte[] Public { get; set; }
    }

/// <summary>
/// Interface exposing the private Diffie Hellman parameters in the same form provided
/// by PKIXPrivateKeyDH
/// </summary>
public interface IKeyPrivateDH {

    /// <summary> ASN.1 member Shared </summary>
    byte[] Shared { get; set; }

    /// <summary> ASN.1 member Public </summary>
    byte[] Public { get; set; }

    /// <summary> ASN.1 member Private </summary>
    byte[] Private { get; set; }
    }


/// <summary>
/// Interface exposing the Diffie Hellman result parameters in the same form provided
/// by AgreementDH
/// </summary>
public interface IKeyResultDH {

    /// <summary> ASN.1 member Result </summary>
    byte[] Result { get; set; }
    }


/// <summary>
/// Base class for DH key exchange. Algorithm identifier, factory and conversion methods are
/// defined in this class. To make use of a different cryptographic implementation, implement
/// a new subclass and override the default key factories.
/// </summary>
public abstract class KeyPairBaseDH : KeyPairAdvanced {

    /// <summary>
    /// ASN.1 Object Identifier for the domain parameters (1.3.6.1.4.1.35405.1.22.0).
    /// </summary>
    /// <remarks>
    /// Since this is not standard DH, the OID is in 
    /// PHB's OID space.
    /// </remarks>
    public const string KeyOIDDomain = Constants.OIDS__id_dh_domain;

    /// <summary>
    /// ASN.1 Object Identifier for the public key parameters (1.3.6.1.4.1.35405.1.22.1).
    /// </summary>
    /// <remarks>
    /// Since this is not standard DH, the OID is in 
    /// PHB's OID space.
    /// </remarks>
    public const string KeyOIDPublic = Constants.OIDS__id_dh_public;// "";

    /// <summary>
    /// ASN.1 Object Identifier for the private key parameters (1.3.6.1.4.1.35405.1.22.2).
    /// </summary>
    /// <remarks>
    /// Since this is not standard DH, the OID is in 
    /// PHB's OID space.
    /// </remarks>
    public const string KeyOIDPrivate = Constants.OIDS__id_dh_private;


    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public abstract DHDomain DHDomain { get; }

    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public abstract PKIXPrivateKeyDH PKIXPrivateKeyDH { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public abstract PKIXPublicKeyDH PKIXPublicKeyDH { get; }

    /// <summary>
    /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
    /// platform provider.
    /// </summary>
    public static FactoryDHPublicKeyDelegate KeyPairPublicFactory { get; set; } = KeyPairDH.KeyPairPublicFactory;

    /// <summary>
    /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
    /// platform provider.
    /// </summary>
    public static FactoryDHPrivateKeyDelegate KeyPairPrivateFactory { get; set; } = KeyPairDH.KeyPairPrivateFactory;

    /// <summary>The supported key uses (e.g. signing, encryption)</summary>
    public override KeyUses KeyUses { get; } = KeyUses.Encrypt;

    }



/// <summary>
/// Description of a Diffie Hellman Key Pair. This class exposes methods and properties
/// that allow conversion of the public key (and private key if known) values to various
/// formats.
/// </summary>
public class KeyPairDH : KeyPairBaseDH, IAgreementData {

    ///<inheritdoc/>
    public override AssuranceLevel AssuranceLevel => Assurance(DHDomain.Modulus.Length);

    AssuranceLevel Assurance(int bits) {
        if (bits < 2048) {
            return AssuranceLevel.None;
            }
        if (bits < 3072) {
            return AssuranceLevel.CC112;
            }
        if (bits < 7680) {
            return AssuranceLevel.CC128;
            }
        if (bits < 15360) {
            return AssuranceLevel.CC192;
            }
        return AssuranceLevel.CC256;
        }


    /// <summary>
    /// The internal Public DH parameters
    /// </summary>
    public DiffeHellmanPublic PublicKey { get; set; }

    /// <summary>
    /// The internal Private DH parameters
    /// </summary>
    public DiffeHellmanPrivate PrivateKey { get; set; }

    #region // Properties

    ///<summary>The implementation public key value</summary>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

    ///<summary>The implementation private key value (if exportable)</summary>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

    /// <summary>
    /// The private key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override IPKIXPrivateKey PKIXPrivateKey {
        get {
            Assert.AssertNotNull(PKIXPrivateKeyDH, NotExportable.Throw);
            return PKIXPrivateKeyDH;
            }
        }

    /// <summary>
    /// The private key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyDH;

    /// <summary>The supported key uses (e.g. signing, encryption)</summary>
    public override KeyUses KeyUses { get; } = KeyUses.Encrypt;

    ///<summary>If true, the key only has access to public key values.</summary>
    public override bool PublicOnly => PrivateKey == null;



    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public override DHDomain DHDomain => PublicKey.DHDomain;


    #region // PKIX data formats
    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public override PKIXPrivateKeyDH PKIXPrivateKeyDH { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public override PKIXPublicKeyDH PKIXPublicKeyDH {
        get {
            dhPublicKey ??= new PKIXPublicKeyDH() {
                Domain = DHDomain,
                Public = PublicKey.Public.ToByteArray()
                };
            return dhPublicKey;
            }
        }
    PKIXPublicKeyDH dhPublicKey = null;

    /// <summary>
    /// The public key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override SubjectPublicKeyInfo KeyInfoData => PKIXPublicKeyDH.SubjectPublicKeyInfo();


    ///// <summary>
    ///// The private key data formatted as a PKIX KeyInfo data blob.
    ///// </summary>
    //public override SubjectPublicKeyInfo PrivateKeyInfoData => PKIXPrivateKeyDH.SubjectPublicKeyInfo();


    #endregion


    #region // Constructors

    /// <summary>
    /// Create a new DH keypair.
    /// </summary>
    /// <param name="KeySize">The key size</param>
    /// <param name="keySecurity">The key security model</param>

    public KeyPairDH(int KeySize = 2048, KeySecurity keySecurity = KeySecurity.Public) :
                this(new DiffeHellmanPrivate(KeySize), keySecurity) {
        }

    /// <summary>
    /// Create a new DH keypair.
    /// </summary>
    /// <param name="publicKey">The public key to create a provider for</param>
    /// <param name="keySecurity">The key security model</param>

    public KeyPairDH(DiffeHellmanPublic publicKey, KeySecurity keySecurity = KeySecurity.Public) {
        PrivateKey = publicKey as DiffeHellmanPrivate;
        KeySecurity = keySecurity;

        if (PrivateKey != null) {
            PublicKey = PrivateKey.DiffeHellmanPublic;
            if (keySecurity.IsExportable()) {
                PKIXPrivateKeyDH = new PKIXPrivateKeyDH() {
                    Domain = DHDomain,
                    Private = PrivateKey.SecretKey.ToByteArray(),
                    Public = PrivateKey.Public.ToByteArray(),
                    };
                }
            }
        else {
            PublicKey = publicKey;
            }

        }


    #endregion

    ///<summary>Persist the private key to the specified collection.</summary>
    /// <param name="keyCollection">The key collection that key are to be persisted to </param>
    public override void Persist(KeyCollection keyCollection) {
        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = new PKIXPrivateKeyDH() {
            Domain = DHDomain,
            Private = PrivateKey.SecretKey.ToByteArray(),
            Public = PrivateKey.Public.ToByteArray(),
            };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());
        }


    /// <summary>
    /// Generate a key pair for the specified algorithm and key size.
    /// </summary>
    /// <param name="keySize">The Key size, must be 255 or 448</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="algorithmID">The cryptographic algorithm identifier</param>
    /// <returns>The generated key pair</returns>
    public static KeyPairDH Generate(
                int keySize = 0,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.NULL) =>
        new(keySize, keySecurity);



    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters">The key parameters</param>
    /// <returns>The created key pair</returns>
    public static new KeyPair KeyPairPublicFactory(PKIXPublicKeyDH pkixParameters) {
        var DiffeHellmanPublic = new DiffeHellmanPublic(pkixParameters);

        return new KeyPairDH(DiffeHellmanPublic);
        }

    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters">The key parameters</param>
    /// <param name="keySecurity">The key security model</param>
    /// <returns>The created key pair</returns>
    public static new KeyPair KeyPairPrivateFactory(PKIXPrivateKeyDH pkixParameters,
                KeySecurity keySecurity = KeySecurity.Public) =>
        new KeyPairDH(new DiffeHellmanPrivate(pkixParameters), keySecurity);


    /// <summary>
    /// Factory method to produce a key pair from key parameters.
    /// </summary>
    /// <param name="privateKey">The private key</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <returns>The key pair created.</returns>

    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any)
        => new KeyPairDH((DiffeHellmanPrivate)privateKey,
                keySecurity: keySecurity);

    /// <summary>
    /// Factory method to produce a key pair from implementation public key parameters
    /// </summary>
    /// <param name="publicKey">The public key</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <returns>The key pair created.</returns>
    public override KeyPairAdvanced KeyPair(
                IKeyAdvancedPublic publicKey,
                KeyUses keyUses = KeyUses.Any)
        => new KeyPairDH((DiffeHellmanPublic)publicKey);
    #endregion


    /// <summary>
    /// Returns a new KeyPair instance which only has the public values.
    /// </summary>
    /// <returns>The new keypair that contains only the public values.</returns>
    public override KeyPair KeyPairPublic() {
        var result = new KeyPairDH(new DiffeHellmanPublic(PublicKey));
        Assert.AssertTrue(result.PublicOnly, CryptographicException.Throw);
        return result;
        }



    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to a private key
    /// </summary>
    /// <param name="publicKey">Public key parameters</param>
    /// <param name="carry">Carried result to add in to the agreement (for recryption)</param>
    /// <returns>The key agreement value ZZ</returns>
    ResultDiffieHellman Agreement(KeyPairDH publicKey, ResultDiffieHellman carry = null) {
        BigInteger agreement;
        if (carry == null) {
            agreement = PrivateKey.Agreement(publicKey.PublicKey);
            }
        else {
            agreement = PrivateKey.Agreement(publicKey.PublicKey, carry.Agreement);
            }
        return new ResultDiffieHellman() { Agreement = agreement };
        }

    /// <summary>
    /// Encrypt the specified exchange key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="exchange"></param>
    /// <param name="ephemeral"></param>
    /// <param name="salt"></param>
    /// 
    public override void Encrypt(byte[] key,
            out byte[] exchange,
            out IAgreementData ephemeral,
            byte[] salt = null) => PublicKey.Agreement().Encrypt(
                        key, out exchange, out ephemeral, salt);

    /// <summary>
    /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
    /// </summary>
    /// <param name="EncryptedKey">The encrypted session key</param>
    /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
    /// <param name="AlgorithmID">The algorithm to use.</param>
    /// <param name="Partial">Partial key agreement value (for recryption)</param>
    /// <param name="Salt">Optional salt value for use in key derivation. If specified
    /// must match the salt used to encrypt.</param>
    /// <returns>The decoded data instance</returns>
    /// 
    public override byte[] Decrypt(
                byte[] EncryptedKey,
                IAgreementData Ephemeral,
                CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult Partial = null,
                byte[] Salt = null) {

        var DHPublic = Ephemeral as KeyPairDH;
        Assert.AssertNotNull(DHPublic, KeyTypeMismatch.Throw);

        var Agreementx = Agreement(DHPublic, Partial as ResultDiffieHellman);
        return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
        }


    #region // Unsed methods, we don't do DSA

    /// <summary>
    /// Sign a precomputed digest
    /// </summary>
    /// <param name="Data">The data to sign.</param>
    /// <param name="AlgorithmID">The algorithm to use.</param>
    /// <param name="Context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <returns>The signature data</returns>
    public override byte[] SignDigest(
        byte[] Data,
        CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
        byte[] Context = null) => throw new NotImplementedException();

    /// <summary>
    /// Verify a signature over the purported data digest.
    /// </summary>
    /// <param name="Signature">The signature blob value.</param>
    /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
    /// <param name="Context">Additional data added to the signature scope
    /// for protocol isolation.</param>
    /// <param name="Digest">The digest value to be verified.</param>
    /// <returns>True if the signature is valid, otherwise false.</returns>
    public override bool VerifyDigest(
        byte[] Digest,
        byte[] Signature,
        CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default, byte[] Context = null) => throw new NotImplementedException();


    #endregion

    }
