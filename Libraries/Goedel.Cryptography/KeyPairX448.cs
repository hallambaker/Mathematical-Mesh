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
/// KeyPair binding for X448 signature and exchange.
/// </summary>
public class KeyPairX448 : KeyPairECDH {

    #region //Properties
    ///<inheritdoc/>
    public virtual CurveX448Public PublicKey { get; }

    ///<inheritdoc/>
    public virtual CurveX448Private PrivateKey { get; }

    ///<inheritdoc/>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

    ///<inheritdoc/>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

    ///<inheritdoc/>
    public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

    ///<inheritdoc/>
    public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = KeyUses.Any;


    ///<inheritdoc/>
    public override bool PublicOnly => PrivateKey == null;

    /// <summary>
    /// The byte encoding of the public key
    /// </summary>
    public override byte[] PublicData => PublicKey.Encoding;


    #endregion

    readonly byte[] encodedPrivateKey = null;

    /// <summary>
    /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
    /// format. 
    /// </summary>
    /// <param name="key">The key data as specified in RFC8032.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairX448(
                byte[] key,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {

        CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.X448);
        this.KeySecurity = keyType;
        KeyUses = keyUses;
        if (keyType == KeySecurity.Public) {
            PublicKey = new CurveX448Public(key);
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            }
        else {
            encodedPrivateKey = key;
            var exportable = keyType.IsExportable();
            PrivateKey = new CurveX448Private(key, exportable);
            PublicKey = PrivateKey.Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            if (exportable) {
                PKIXPrivateKeyECDH = new PKIXPrivateKeyX448(key, PKIXPublicKeyECDH);
                }
            }
        PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
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
    public KeyPairX448(byte[] ikm, byte[] salt,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) :
                this(KeyDeriveHKDF.Derive(ikm, salt, null, 448, CryptoAlgorithmId.HMAC_SHA_2_512), keyType, keyUses, cryptoAlgorithmID) {
        }

    /// <summary>
    /// Construct a KeyPairX448 instance for a secret scalar. This is used to create
    /// private keys using cogeneration.
    /// </summary>
    /// <param name="privateKey">The secret scalar value.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairX448(
                CurveX448Private privateKey = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
        CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.X448);
        PrivateKey = privateKey;
        PublicKey = privateKey.Public;
        PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
        KeySecurity = keySecurity;
        KeyUses = keyUses;
        if (keySecurity.IsExportable()) {
            PKIXPrivateKeyECDH = new PKIXPrivateKeyX448(privateKey.Secret, PKIXPublicKeyECDH) {
                IsRecryption = privateKey.IsRecryption
                };
            }
        }



    /// <summary>
    /// Generate a new private key.
    /// </summary>
    /// <param name="keyType">The key storage class.</param>
    /// <param name="keyUses">The permitted key uses</param>
    /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
    /// <returns>The created key pair.</returns>
    public static KeyPairX448 Generate(
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) =>
        new(Platform.GetRandomBits(448), keyType, keyUses, cryptoAlgorithmID);


    /// <summary>
    /// Construct class from a public key value
    /// </summary>
    /// <param name="publicKey">The public key value</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    public KeyPairX448(IKeyAdvancedPublic publicKey,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default,
                KeyUses keyUses = KeyUses.Any) {
        CryptoAlgorithmId = cryptoAlgorithmID == CryptoAlgorithmId.Default ?
            CryptoAlgorithmId.X448 : cryptoAlgorithmID;
        PublicKey = publicKey as CurveX448Public;
        PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
        KeyUses = keyUses;
        }




    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any) =>
        new KeyPairX448((CurveX448Private)PrivateKey, keySecurity, keyUses);

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey,
                KeyUses keyUses = KeyUses.Any) =>
        new KeyPairX448((CurveX448Public)PublicKey, keyUses: keyUses);

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() => new KeyPairX448(PublicKey, keyUses: KeyUses);

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        Assert.AssertTrue(PersistPending, CryptographicException.Throw);
        var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyX448() { Data = encodedPrivateKey };
        keyCollection.Persist(KeyIdentifier, pkix, KeySecurity.IsExportable());
        }

    #region // Operations
    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to a private key
    /// </summary>
    /// <param name="Public">Public key parameters</param>
    /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
    /// <returns>The key agreement value ZZ</returns>
    public ResultECDH Agreement(KeyPairX448 Public, CurveX448Result Carry = null) {
        Assert.AssertTrue(KeyUses.HasFlag(KeyUses.Encrypt), CryptographicOperationNotSupported.Throw);

        CurveX448 Agreement;
        if (Carry == null) {
            Agreement = PrivateKey.Agreement(Public.PublicKey);
            }
        else {
            Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.AgreementX448);
            }
        return new CurveX448Result() { AgreementX448 = Agreement };
        }

    ///<inheritdoc/>
    public override void Encrypt(byte[] Key,
        out byte[] exchange,
        out KeyPair ephemeral,
        byte[] salt = null) => PublicKey.Agreement().Encrypt(Key, out exchange, out ephemeral, salt);

    ///<inheritdoc/>
    public override byte[] Decrypt(byte[] encryptedKey,
        KeyPair ephemeral = null,
        CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
        KeyAgreementResult partial = null, byte[] salt = null) {

        var keyPairX448 = ephemeral as KeyPairX448;
        Assert.AssertNotNull(keyPairX448, KeyTypeMismatch.Throw);

        var Agreementx = Agreement(keyPairX448, partial as CurveX448Result);
        return Agreementx.Decrypt(encryptedKey, ephemeral, partial, salt);
        }

    ///<inheritdoc/>
    public override byte[] SignHash(byte[] data,
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
            byte[] context = null) => throw new InvalidOperation();

    ///<inheritdoc/>
    public override bool VerifyHash(
        byte[] data,
        byte[] signature,
        CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            byte[] Context = null) => throw new InvalidOperation();
    #endregion
    }
