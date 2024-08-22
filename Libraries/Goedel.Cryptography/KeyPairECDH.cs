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
public interface IKeyPublicECDH {
    /// <summary>The Jose curve identifier.</summary>
    string CurveJose { get; }

    /// <summary> ASN.1 member Data </summary>
    byte[] Data { get; }
    }

/// <summary>
/// Interface exposing the private Diffie Hellman parameters in the same form provided
/// by PKIXPrivateKeyDH
/// </summary>
public interface IKeyPrivateECDH {
    /// <summary>The Jose curve identifier.</summary>
    string CurveJose { get; }

    /// <summary> ASN.1 member Data </summary>
    byte[] Data { get; }

    /// <summary>If true, this is a recryption key.</summary>
    bool IsRecryption { get; }
    }

/// <summary>
/// Interface exposing the Diffie Hellman result parameters in the same form provided
/// by AgreementDH
/// </summary>
public interface IKeyResultECDH {
    /// <summary>The Jose curve identifier.</summary>
    string CurveJose { get; }

    /// <summary> ASN.1 member Data </summary>
    byte[] Data { get; }
    }


/// <summary>
/// DH Key Pair
/// </summary>
public abstract class KeyPairBaseECDH : KeyPairAdvanced {

    /// <summary>
    /// Return private key parameters in PKIX structure
    /// </summary>
    public abstract PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

    /// <summary>
    /// Return public key parameters in PKIX structure
    /// </summary>
    public abstract PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }


    /// <summary>
    /// The private key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override IPKIXPrivateKey PKIXPrivateKey {
        get {
            Assert.AssertNotNull(PKIXPrivateKeyECDH, NotExportable.Throw);
            return PKIXPrivateKeyECDH;
            }
        }

    /// <summary>
    /// The private key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyECDH;



    }


/// <summary>
/// Description of a Diffie Hellman Key Pair. This class exposes methods and properties
/// that allow conversion of the public key (and private key if known) values to various
/// formats.
/// </summary>
public abstract class KeyPairECDH : KeyPairBaseECDH {


    /// <summary>The supported key uses (e.g. signing, encryption)</summary>
    public override KeyUses KeyUses { get; }

    /// <summary>
    /// Create a new ephemeral private key and use it to perform a key
    /// agreement.
    /// </summary>
    /// <returns>The key agreement parameters, the public key value and the
    /// key agreement.</returns>
    public ResultECDH Agreement() => throw new NotImplementedException();

    /// <summary>
    /// The byte encoding of the public key
    /// </summary>
    public virtual byte[] PublicData => throw new NYI();


    // Abstract method implementations to be shared across the curves


    /// <summary>
    /// The public key data formatted as a PKIX KeyInfo data blob.
    /// </summary>
    public override SubjectPublicKeyInfo KeyInfoData => PKIXPublicKeyECDH.SubjectPublicKeyInfo();

    ///// <summary>
    ///// The private key data formatted as a PKIX KeyInfo data blob.
    ///// </summary>
    //public override SubjectPublicKeyInfo PrivateKeyInfoData => PKIXPrivateKeyECDH.SubjectPublicKeyInfo();


    /// <summary>
    /// Create an ECDH private key of type <paramref name="cryptoAlgorithmID"/> 
    /// from a specified scalar value <paramref name="privateScalar"/>. 
    /// </summary>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier of the 
    /// type of key to create.</param>
    /// <param name="privateScalar">The private scalar value.</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The generated key pair</returns>
    public static KeyPairAdvanced KeyPairFactory(
        CryptoAlgorithmId cryptoAlgorithmID,
        BigInteger privateScalar,
        KeySecurity keySecurity = KeySecurity.Bound,
        KeyUses keyUses = KeyUses.Any) {

        switch (cryptoAlgorithmID) {
            case CryptoAlgorithmId.Ed448: {
                    return new KeyPairEd448(new CurveEdwards448Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }

            case CryptoAlgorithmId.Ed25519: {
                    return new KeyPairEd25519(new CurveEdwards25519Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }
            case CryptoAlgorithmId.X448: {
                    return new KeyPairX448(new CurveX448Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }
            case CryptoAlgorithmId.X25519: {
                    return new KeyPairX25519(new CurveX25519Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }
            }

        return null;
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



        KeyPair keyPair = null;

        switch (cryptoAlgorithmID) {
            case CryptoAlgorithmId.Ed448: {
                    keyPair = KeyPairEd448.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
            case CryptoAlgorithmId.Ed25519: {
                    keyPair = KeyPairEd25519.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
            case CryptoAlgorithmId.X448: {
                    keyPair = KeyPairX448.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
            case CryptoAlgorithmId.X25519: {
                    keyPair = KeyPairX25519.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }


            }

        if (keyPair == null) {
            keySize = keySize == 0 ? 448 : keySize;
            switch (keySize) {
                case 448:
                    keyPair = KeyPairEd448.Generate(keySecurity, keyUses, cryptoAlgorithmID); break;
                case 25519:
                    keyPair = KeyPairEd25519.Generate(keySecurity, keyUses, cryptoAlgorithmID); break;
                default:
                    break;
                }
            }
        Assert.AssertNotNull(keyPair, KeySizeNotSupported.Throw);

        return keyPair;
        }

    /// <summary>
    /// Create a KeyPairECDH instance for the algorithm <paramref name="CryptoAlgorithmID"/> 
    /// from the key data <paramref name="key"/>. 
    /// </summary>
    /// <param name="key">The key data in RFC8032 format.</param>
    /// <param name="keyType">The key security model</param>
    /// <param name="CryptoAlgorithmID">The cryptographic algorithm represented by the key.</param>
    /// <returns>The created key pair.</returns>
    public static KeyPairECDH KeyPairFactory(byte[] key, KeySecurity keyType = KeySecurity.Public,
        CryptoAlgorithmId CryptoAlgorithmID = CryptoAlgorithmId.NULL) {
        return CryptoAlgorithmID switch {
            CryptoAlgorithmId.Ed448 or CryptoAlgorithmId.Ed448ph => new KeyPairEd448(key, keyType),
            CryptoAlgorithmId.Ed25519 or CryptoAlgorithmId.Ed25519ph or CryptoAlgorithmId.Ed25519ctx => new KeyPairEd25519(key, keyType),
            CryptoAlgorithmId.X448 => new KeyPairX448(key, keyType),
            CryptoAlgorithmId.X25519 => new KeyPairX25519(key, keyType),
            _ => throw new NYI(),
            };
        }


    }
