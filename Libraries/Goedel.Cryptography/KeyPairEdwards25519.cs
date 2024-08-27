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
/// Ed25519 public / private keypair.
/// </summary>
public class KeyPairEd25519 : KeyPairEdwards {

    #region //Properties
    ///<summary>The implementation public key value</summary>
    public CurveEdwards25519Public PublicKey { get; set; }

    ///<summary>The implementation private key value (if exportable)</summary>
    public CurveEdwards25519Private PrivateKey { get; set; }

    ///<summary>The implementation public key value</summary>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

    ///<summary>The implementation private key value (if exportable)</summary>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

    ///<summary>The private key parameters represented in PKIX form</summary>
    public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

    ///<summary>The public key parameters represented in PKIX form</summary>
    public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

    /// <summary>The supported key uses (e.g. signing, encryption)</summary>
    public override KeyUses KeyUses { get; } = KeyUses.Any;

    ///<summary>If true, the key only has access to public key values.</summary>
    public override bool PublicOnly => PrivateKey == null;

    /// <summary>
    /// The byte encoding of the public key
    /// </summary>
    public override byte[] PublicData => PublicKey.Encoding;



    #endregion


    //readonly KeySecurity KeyType = KeySecurity.Public;
    readonly byte[] EncodedPrivateKey = null;


    /// <summary>
    /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
    /// format. 
    /// </summary>
    /// <param name="key">The key data as specified in RFC8032.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairEd25519(
                byte[] key,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {

        CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
        KeySecurity = keyType;
        KeyUses = keyUses;
        if (keyType == KeySecurity.Public) {
            PublicKey = new CurveEdwards25519Public(key);
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
            KeySecurity = KeySecurity.Public;
            }
        else {
            EncodedPrivateKey = key;
            var exportable = keyType.IsExportable();
            PrivateKey = new CurveEdwards25519Private(key, exportable);
            PublicKey = PrivateKey.Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
            if (exportable) {
                PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519(key, PKIXPublicKeyECDH);
                }
            }

        }


    /// <summary>
    /// Construct a key via parameters presented to KDF-HMAC-SHA-2-512. 
    /// <para>The values <paramref name="ikm"/> and <paramref name="salt"/> are used to
    /// generate the key data value as specified by RFC8032.</para>
    /// </summary>
    /// <param name="ikm">The initial keying material.</param>
    /// <param name="salt">Salt value.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairEd25519(byte[] ikm, byte[] salt,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) :
                this(KeyDeriveHKDF.Derive(ikm, salt, null, 256, CryptoAlgorithmId.HMAC_SHA_2_512), keyType, keyUses, cryptoAlgorithmID) {
        }

    /// <summary>
    /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
    /// private keys using cogeneration.
    /// </summary>
    /// <param name="privateKey">The secret scalar value.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairEd25519(
                CurveEdwards25519Private privateKey = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
        CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
        PrivateKey = privateKey ?? new CurveEdwards25519Private();
        PublicKey = PrivateKey.Public;
        PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
        KeySecurity = keySecurity;
        KeyUses = keyUses;
        if (keySecurity.IsExportable()) {
            PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519(privateKey.Secret, PKIXPublicKeyECDH) {
                IsRecryption = privateKey.IsRecryption
                };
            }

        }

    /// <summary>
    /// Construct class from a public key value
    /// </summary>
    /// <param name="publicKey">The public key value</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    public KeyPairEd25519(IKeyAdvancedPublic publicKey,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default,
                KeyUses keyUses = KeyUses.Any) {

        CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
        this.PublicKey = publicKey as CurveEdwards25519Public;
        PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(this.PublicKey.Encoding);
        KeyUses = keyUses;
        }

    /// <summary>
    /// Generate a new private key.
    /// </summary>
    /// <param name="keyType">The key storage class.</param>
    /// <param name="keyUses">The permitted key uses</param>
    /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
    /// <returns>The created key pair.</returns>
    public static KeyPairEd25519 Generate(
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) =>
        new(Platform.GetRandomBits(256), keyType, keyUses, cryptoAlgorithmID);

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) =>
        new KeyPairEd25519((CurveEdwards25519Private)privateKey, keySecurity, keyUses);

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey,
                KeyUses keyUses = KeyUses.Any) =>
        new KeyPairEd25519((CurveEdwards25519Public)publicKey, keyUses: keyUses);


    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairEd25519(PublicKey, keyUses: KeyUses) {
        Locator = Locator
        };


    ///<inheritdoc/>
    public override void Persist(
            KeyCollection keyCollection) {
        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyEd25519(EncodedPrivateKey, PKIXPublicKeyECDH) { };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());
        }


    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to a private key
    /// </summary>
    /// <param name="publicKey">Public key parameters</param>
    /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
    /// <returns>The key agreement value ZZ</returns>
    public CurveEdwards25519Result Agreement(KeyPairEd25519 publicKey, CurveEdwards25519Result Carry = null) {
        CurveEdwards25519 Agreement;
        if (Carry == null) {
            Agreement = PrivateKey.Agreement(publicKey.PublicKey);
            }
        else {
            Agreement = PrivateKey.Agreement(publicKey.PublicKey, Carry.AgreementEd25519);
            }
        return new CurveEdwards25519Result() { AgreementEd25519 = Agreement };
        }

    ///<inheritdoc/>
    public override void Encrypt(byte[] key,
            out byte[] exchange,
            out KeyPair ephemeral,
            byte[] salt = null) => PublicKey.Agreement().Encrypt(key, out exchange, out ephemeral, salt);


    ///<inheritdoc/>
    public override byte[] Decrypt(byte[] encryptedKey,
            KeyPair ephemeral = null,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            KeyAgreementResult partial = null,
            byte[] salt = null) {

        var KeyPairEd25519 = ephemeral as KeyPairEd25519;
        Assert.AssertNotNull(KeyPairEd25519, KeyTypeMismatch.Throw);

        var Agreementx = Agreement(KeyPairEd25519, partial as CurveEdwards25519Result);

        //Console.WriteLine($"Key {Agreementx.IKM.ToStringBase16FormatHex()}");

        return Agreementx.Decrypt(encryptedKey, ephemeral, partial, salt);
        }

    ///<inheritdoc/>
    public override byte[] Sign(byte[] data, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        return base.Sign(data, algorithmID, context);
        }

    ///<inheritdoc/>
    public override bool Verify(byte[] data, byte[] signature, CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null) {
        return base.Verify(data, signature, algorithmID, context);
        }

    ///<inheritdoc/>
    public override byte[] SignHash(
            byte[] data,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) {

        algorithmID = algorithmID == CryptoAlgorithmId.Default ? CryptoAlgorithmId : algorithmID;
        if (algorithmID == CryptoAlgorithmId.Ed25519ph) {
            using var sha512 = SHA512.Create();
            data = sha512.ComputeHash(data);
            }

        var dom2 = CurveEdwards25519.Dom2(algorithmID, context);

        //Console.WriteLine($"Data = {data.ToStringBase16FormatHex()}");
        //Console.WriteLine($"Dom2 = {dom2?.ToStringBase16FormatHex()}");

        return PrivateKey.Sign(data, dom2);
        }

    ///<inheritdoc/>
    public override ThresholdSignatureEdwards SignHashThreshold(byte[] data,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) => new ThresholdSignatureEdwards25519(PrivateKey);


    ///<inheritdoc/>
    public override bool VerifyHash(
            byte[] data,
            byte[] signature,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) {
        algorithmID = algorithmID == CryptoAlgorithmId.Default ? CryptoAlgorithmId : algorithmID;
        if (algorithmID == CryptoAlgorithmId.Ed25519ph) {
            using var sha512 = SHA512.Create();

            data = sha512.ComputeHash(data);
            }

        var dom2 = CurveEdwards25519.Dom2(algorithmID, context);
        return PublicKey.Verify(data, signature, dom2);
        }
    }
