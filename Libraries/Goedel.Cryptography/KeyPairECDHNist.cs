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


using Goedel.ASN;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Nist;

using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Goedel.Cryptography;


/// <summary>
/// NIST P256/P384/P521 Elliptic Curve Key Pair
/// </summary>
public class KeyPairECDHNist : KeyPairECDH, IAgreementData {

    #region //Properties

    ///<inheritdoc/>
    public override AssuranceLevel AssuranceLevel => throw new NotImplementedException();


    ///<summary>The implementation public key value</summary>
    public CurveNistPublic PublicKey { get; set; }

    ///<summary>The implementation private key value (if exportable)</summary>
    public CurveNistPrivate SecretKey { get; set; }

    ///<inheritdoc/>
    public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

    ///<inheritdoc/>
    public override IKeyAdvancedPrivate IKeyAdvancedPrivate => SecretKey;

    ///<inheritdoc/>
    public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

    ///<inheritdoc/>
    public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

    ///<inheritdoc/>
    public override KeyUses KeyUses { get; } = KeyUses.Any;

    ///<inheritdoc/>
    public override bool PublicOnly => SecretKey == null;

    ///<inheritdoc/>
    public override byte[] PublicData => PublicKey.EncodingPublicKey;

    //readonly KeySecurity KeyType = KeySecurity.Public;
    readonly byte[] EncodedPrivateKey = null;


    /*
subjectPublicKeyInfo SubjectPublicKeyInfo SEQUENCE (2 elem)
    algorithm AlgorithmIdentifier SEQUENCE (2 elem)
        algorithm OBJECT IDENTIFIER 1.2.840.10045.2.1 ecPublicKey (ANSI X9.62 public key type)
        parameters ANY OBJECT IDENTIFIER 1.2.840.10045.3.1.7 prime256v1 (ANSI X9.62 named elliptic curve)Offset: 296
            Length: 2+8
            Value: 1.2.840.10045.3.1.7 prime256v1 ANSI X9.62 named elliptic curve
        subjectPublicKey BIT STRING (520 bit) 0000010010100100000001001110101111110101111011111000111111000100101001…

     30 59      SEQUENCE
        30 13       SEQUENCE
            06 07 2A 86 48 CE 3D 02 01  OBJECT IDENTIFIER ecPublicKey 1.2.840.10045.2.1
            06 08 2A 86 48 CE 3D 03 01 07 OBJECT IDENTIFIER prime256v1 1.2.840.10045.3.1.7
        03 42 BIT STRING (520 bit)
            00 04 A4 04  EB F5 EF 8F C4 A5 3A 71
            31 FF 98 A0 EB 81 B6 2E  F5 A5 0C E3 18 20 91 58
            05 F4 A3 5B EA 36 4D A5  A2 93 0D 10 BD B3 E5 63
            16 38 40 35 11 90 1A DD  12 33 0B 77 62 F1 D2 D8
            EE 82 71 E8 B3 6F
     */



    #endregion

    /// <summary>
    /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
    /// format. 
    /// </summary>
    /// <param name="key">The key data as specified in RFC8032.</param>
    /// <param name="keyType">The key type.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairECDHNist(
                byte[] key,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.P521) {

        CryptoAlgorithmId = cryptoAlgorithmID;
        var curve = GetCurve(cryptoAlgorithmID);

        KeySecurity = keyType;
        KeyUses = keyUses;

        if (keyType == KeySecurity.Public) {
            PublicKey = new CurveNistPublic(key, curve);
            PKIXPublicKeyECDH = new PKIXPublicKeyECDH(cryptoAlgorithmID, PublicKey.EncodingPublicKey);
            KeySecurity = KeySecurity.Public;
            }
        else {
            EncodedPrivateKey = key;
            var exportable = keyType.IsExportable();
            SecretKey = new CurveNistPrivate(key, curve, exportable);
            PublicKey = SecretKey.PublicKey;
            PKIXPublicKeyECDH = new PKIXPublicKeyECDH(cryptoAlgorithmID, PublicKey.EncodingPublicKey);
            if (exportable) {
                PKIXPrivateKeyECDH = new PKIXPrivateKeyECDH(cryptoAlgorithmID, key);
                }
            }
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
    /// <param name="curve">The curve parameters.</param>
    public KeyPairECDHNist(
                CurveNistPrivate privateKey = null,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default,
                PrimeCurve? curve =null) {

        var keyCurve = privateKey?.Curve ?? curve ?? GetCurve(cryptoAlgorithmID);
        SecretKey = privateKey ?? new CurveNistPrivate(keyCurve);
        PublicKey = SecretKey.PublicKey;
        PKIXPublicKeyECDH = new PKIXPublicKeyECDH(keyCurve.CryptoAlgorithmId, PublicKey.EncodingPublicKey);
        KeySecurity = keySecurity;
        KeyUses = keyUses;
        if (keySecurity.IsExportable()) {
            PKIXPrivateKeyECDH = new PKIXPrivateKeyECDH(keyCurve.CryptoAlgorithmId, privateKey.EncodingSecretKey) {
                //IsThreshold = privateKey.IsThreshold
                };
            }
        }


    /// <summary>
    /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
    /// private keys using cogeneration.
    /// </summary>
    /// <param name="publicKey">The public key value.</param>
    /// <param name="keySecurity">The key security model.</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
    /// in signature operations.</param>
    public KeyPairECDHNist(
               CurveNistPublic publicKey,
                KeySecurity keySecurity = KeySecurity.Bound,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
        KeySecurity = keySecurity;
        KeyUses = keyUses;
        PublicKey = publicKey;

        var keyCurve = publicKey.Curve;
        PKIXPublicKeyECDH = new PKIXPublicKeyECDH(keyCurve.CryptoAlgorithmId, PublicKey.EncodingPublicKey);

        }


    /// <summary>
    /// Generate a new private key.
    /// </summary>
    /// <param name="keyType">The key storage class.</param>
    /// <param name="keyUses">The permitted key uses</param>
    /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
    /// <param name="keySize">The key size in bits.</param>
    /// <returns>The created key pair.</returns>
    public static KeyPairECDHNist Generate(
                int keySize,
                KeySecurity keyType = KeySecurity.Public,
                KeyUses keyUses = KeyUses.Any,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {

        var (algId, curve) = GetCurve(keySize);

        var exportable = keyType.IsExportable();
        var secretKey = new CurveNistPrivate(curve, null, exportable);

        return new KeyPairECDHNist(secretKey, keyType, keyUses, algId);
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
    /// <param name="keySize">The size of the key in bits (ignored).</param>
    /// <returns>the derrived key.</returns>
    public static KeyPair Factory(
        CryptoAlgorithmId algorithmID,
        KeySecurity keySecurity,
        byte[] ikm,
        byte[] keySpecifier,
        string keyName,
        IKeyLocate keyCollection = null,
        int keySize = 0,
        KeyUses keyUses = KeyUses.Any) {

        var curve = GetCurve(algorithmID) ;
        var binaryData = KeySeed(curve.MinimumOutputSize, ikm, keySpecifier, keyName);
        var d = 1 + binaryData.ToBigInteger() % (curve.OrderN - 1);

        var exportable = keySecurity.IsExportable();
        var secretKey = new CurveNistPrivate(curve, d, exportable);

        return new KeyPairECDHNist(secretKey, keySecurity, keyUses, algorithmID);
        }





    static PrimeCurve GetCurve(CryptoAlgorithmId cryptoAlgorithmID) => cryptoAlgorithmID switch {
        CryptoAlgorithmId.P256 => EccCurveFactory.P256,
        CryptoAlgorithmId.P384 => EccCurveFactory.P384,
        CryptoAlgorithmId.P521 => EccCurveFactory.P521,
        _ => throw new CryptographicException()
        };

    static (CryptoAlgorithmId, PrimeCurve) GetCurve(int keysize) => keysize switch {
        256 => (CryptoAlgorithmId.P256, EccCurveFactory.P256),
        384 => (CryptoAlgorithmId.P384, EccCurveFactory.P384),
        521 => (CryptoAlgorithmId.P521, EccCurveFactory.P521),
        _ => throw new CryptographicException()
        };



    ///<inheritdoc/>
    public override byte[] Decrypt(
                byte[] encryptedKey,
                IAgreementData ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null, byte[] salt = null) {
        var keyPair = ephemeral as KeyPairECDHNist;
        Assert.AssertNotNull(keyPair, KeyTypeMismatch.Throw);

        var agreementx = Agreement(keyPair, partial as CurveNistResult);
        return agreementx.Decrypt(encryptedKey, ephemeral, partial, salt);
        }


    /// <summary>
    /// Perform a Diffie Hellman Key Agreement to a private key
    /// </summary>
    /// <param name="publicKey">Public key parameters</param>
    /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
    /// <returns>The key agreement value ZZ</returns>
    public CurveNistResult Agreement(KeyPairECDHNist publicKey, CurveNistResult Carry = null) {
        EccPoint agreement;
        if (Carry == null) {
            agreement = SecretKey.Agreement(publicKey.PublicKey);
            }
        else {
            agreement = SecretKey.Agreement(publicKey.PublicKey, Carry);
            }

        return new CurveNistResult() {
            AgreementNist = agreement,
            Curve = SecretKey.Curve,
            EphemeralPublicValue = PublicKey
            };
        }



    ///<inheritdoc/>
    public override void Encrypt(
                byte[] key,
                out byte[] exchange,
                out IAgreementData ephemeral,
                byte[] salt = null) => 
                    PublicKey.Agreement().Encrypt(key, out exchange, out ephemeral, salt);

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey, KeySecurity keySecurity = KeySecurity.Admin, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey, KeyUses keyUses = KeyUses.Any) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override KeyPair KeyPairPublic() {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override void Persist(KeyCollection keyCollection) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public override byte[] SignDigest(
                byte[] digest, 
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                byte[] context = null) {
        var (r, s) = SecretKey.SignInner(digest);
        //Console.WriteLine($"R {r}");
        //Console.WriteLine($"S {s}");

        var bytes = SecretKey.EncodeSignature(r, s);
        return bytes;

        }

    ///<inheritdoc/>
    public override bool VerifyDigest(
                byte[] digest, 
                byte[] signature, 
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
                byte[] context = null) {
        var (r, s) = PublicKey.DecodeSignature(signature);
        //Console.WriteLine($"R {r}");
        //Console.WriteLine($"S {s}");

        var result = PublicKey.VerifyInner(r, s, digest);
        return result;

        }
    }
