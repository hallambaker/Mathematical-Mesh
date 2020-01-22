using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Algorithms;

using System.Collections.Generic;
using System.Numerics;

namespace Goedel.Cryptography {

    /// <summary>
    /// Key handle for an implementation level public key.
    /// </summary>
    public interface IKeyAdvancedPublic {

        /// <summary>
        /// Combine two public keys to obtain a new public key.
        /// </summary>
        /// <param name="contribution">The public key contribution.</param>
        /// <returns>The new public key.</returns>
        IKeyAdvancedPublic Combine(IKeyAdvancedPublic contribution);


        ///<summary>The byte encoding of the key.</summary>
        byte[] Encoding { get; }

        }

    /// <summary>
    /// Key handle for an implementation level private key.
    /// </summary>
    public interface IKeyAdvancedPrivate {

        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        IKeyAdvancedPrivate[] MakeRecryptionKeySet(int shares);


        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        IKeyAdvancedPrivate CompleteRecryptionKeySet(IEnumerable<KeyPair> shares);

        /// <summary>
        /// Combine two private keys to obtain a new public key.
        /// </summary>
        /// <param name="contribution">The private key contribution.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The new public key.</returns>
        IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate contribution,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any);

        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        KeyAgreementResult Agreement(KeyPair keyPair);

        /// <summary>
        /// The private key value;
        /// </summary>
        BigInteger Private { get; }
        }


    /// <summary>
    /// Base class for public key pairs that support the additional properties
    /// required for advanced operations such as distributed key generation and
    /// proxy re-encryption.
    /// </summary>
    public abstract class KeyPairAdvanced : KeyPair {

        ///<summary>The internal public key parameters.</summary>
        public abstract IKeyAdvancedPublic IKeyAdvancedPublic { get; }


        ///<summary>The implementation private key value (if exportable)</summary>
        public abstract IKeyAdvancedPrivate IKeyAdvancedPrivate { get; }

        /// <summary>
        /// Factory method to construct a KeyPair for the private key <paramref name="privateKey"/>.
        /// The created key pair will have the same security model as the key from which the
        /// method is invoked.
        /// </summary>
        /// <param name="privateKey">The private key to construct parameters for.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The KeyPair that was constructed</returns>
        public abstract KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any);

        /// <summary>
        /// Factory method to construct a KeyPair for the public key <paramref name="publicKey"/>.
        /// </summary>
        /// <param name="publicKey">The private key to construct parameters for.</param>
        /// <returns>The KeyPair that was constructed</returns>
        public abstract KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey);

        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="udf">Fingerprint of key</param>
        /// <returns>The key pair found</returns>
        public static KeyPair FindLocalAdvanced(string udf) => Platform.FindInKeyStore(udf, CryptoAlgorithmID.DH);

        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public KeyAgreementResult Agreement(KeyPair keyPair) => IKeyAdvancedPrivate.Agreement(keyPair);

        /// <summary>
        /// Calculate and return the partial private key such that its value plus the value of 
        /// <paramref name="partialKey"/> equals the value of this key.
        /// </summary>
        /// <param name="partialKey">The existing key part.</param>
        /// <returns>The computed key</returns>
        public virtual KeyPairAdvanced GenerateRecryptionKey(KeyPair partialKey) =>
            GenerateRecryptionKey(new List<KeyPair> { partialKey });

        /// <summary>
        /// Calculate and return the partial private key such that its value plus the value of 
        /// the sum of <paramref name="partialKeys"/> equals the value of this key.
        /// </summary>
        /// <param name="partialKeys">The existing key parts.</param>
        /// <returns>The computed key</returns>
        public virtual KeyPairAdvanced GenerateRecryptionKey(IEnumerable<KeyPair> partialKeys) {
            var Private = IKeyAdvancedPrivate.CompleteRecryptionKeySet(partialKeys);
            return KeyPair(Private);
            }

        /// <summary>
        /// Combine the public parameters with another public key to create the composite public key pair
        /// </summary>
        /// <param name="contribution">The public key parameters to combine</param>
        /// <returns>The generated public key pair.</returns>
        public KeyPairAdvanced CombinePublic(KeyPairAdvanced contribution) {
            var PublicKey = IKeyAdvancedPublic.Combine(contribution.IKeyAdvancedPublic);
            return KeyPair(PublicKey);
            }

        /// <summary>
        /// Combine the private parameters with another private key to create the composite private key pair
        /// </summary>
        /// <param name="contribution"></param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns></returns>
        public KeyPairAdvanced Combine(KeyPairAdvanced contribution,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any) {
            var PrivateKey = IKeyAdvancedPrivate.Combine(contribution.IKeyAdvancedPrivate, keySecurity, keyUses);
            return KeyPair(PrivateKey, keySecurity, keyUses);
            }

        
        


        }





    /// <summary>Base class for representation of a key agreement result.</summary>
    public abstract partial class KeyAgreementResult : IPKIXAgreement {
        /// <summary>
        /// Return the DER encoding of this structure
        /// </summary>
        /// <returns>The DER encoded value.</returns>
        public abstract byte[] DER();


        /// <summary>The OID value for the key agreement result structure. Currently
        /// unused.</summary>
        public virtual int[] OID => null;


        byte[] _Salt;
        KeyDerive _KeyDerive = null;

        /// <summary>Salt to use in HKDF key derivation. If set will set the 
        /// Key derivation function to HKDF with the specified salt.</summary>
        public virtual byte[] Salt {
            get => _Salt;
            set {
                _Salt = value;
                _KeyDerive = new KeyDeriveHKDF(IKM, _Salt);
                }
            }

        /// <summary>Key derivation function. May be overridden, defaults to KDF.</summary>
        public virtual KeyDerive KeyDerive {
            get {
                _KeyDerive ??= new KeyDeriveHKDF(IKM, _Salt);
                return _KeyDerive;
                }
            set => _KeyDerive = value;
            }


        /// <summary>The key agreement result as a byte array</summary>
        public abstract byte[] IKM { get; }


        /// <summary>Public key generated by ephemeral key generation.</summary>
        public virtual IKeyAdvancedPublic EphemeralPublicValue { get; set; }

        /// <summary>The public key portion of the ephemeral key</summary>
        public abstract KeyPair EphemeralKeyPair { get; }

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        public virtual void Encrypt(byte[] key,
            out byte[] exchange, out KeyPair ephemeral, byte[] salt = null) {

            // Console.Write($"PRK Encrypt is {IKM.ToStringBase16()}");

            var EncryptionKey = KeyDerive.Derive(salt, Length: 256);
            // Console.Write($"EncryptionKey Encrypt is {EncryptionKey.ToStringBase16()}");

            exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, key);
            ephemeral = EphemeralKeyPair;
            }

        /// <summary>
        /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session key</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="partial">Partial key agreement value (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>
        /// <returns>The decoded data instance</returns>
        public virtual byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral,
                    KeyAgreementResult partial = null,
                    byte[] salt = null) {


            var EncryptionKey = KeyDerive.Derive(salt, Length: 256);
            var KeySize = (encryptedKey.Length * 8) - 64;

            return Platform.KeyWrapRFC3394.Unwrap(EncryptionKey, encryptedKey);

            }

        }

    /// <summary>
    /// Base clase for elliptic curve key agreement results (may be eliminated at a future date).
    /// </summary>
    public abstract class ResultECDH : KeyAgreementResult {

        ///<summary>The key agreement value, a point on the curve.</summary>
        public abstract Curve Agreement { get; }
        }

    }
