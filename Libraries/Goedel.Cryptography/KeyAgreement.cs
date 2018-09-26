using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {

    /// <summary>
    /// Key handle for an implementation level public key.
    /// </summary>
    public interface IKeyAdvancedPublic {

        /// <summary>
        /// Combine two public keys to obtain a new public key.
        /// </summary>
        /// <param name="Contribution">The public key contribution.</param>
        /// <returns>The new public key.</returns>
        IKeyAdvancedPublic Combine(IKeyAdvancedPublic Contribution);

        }

    /// <summary>
    /// Key handle for an implementation level private key.
    /// </summary>
    public interface IKeyAdvancedPrivate {

        /// <summary>
        /// Make a recryption keyset by splitting the private key.
        /// </summary>
        /// <param name="Shares">Number of shares to create</param>
        /// <returns>Array shares.</returns>
        IKeyAdvancedPrivate[] MakeRecryptionKeySet(int Shares);

        /// <summary>
        /// Combine two private keys to obtain a new public key.
        /// </summary>
        /// <param name="Contribution">The private key contribution.</param>
        /// <returns>The new public key.</returns>
        IKeyAdvancedPrivate Combine(IKeyAdvancedPrivate Contribution);
        }


    /// <summary>
    /// Base class for public key pairs that support the additional properties
    /// required for advanced operations such as distributed key generation and
    /// proxy re-encryption.
    /// </summary>
    public abstract class KeyPairAdvanced : KeyPair {

        ///<summary>The internal public key parameters.</summary>
        public abstract IKeyAdvancedPublic IKeyAdvancedPublic { get; }


        ///<summary>The external public key parameters.</summary>
        public abstract IKeyAdvancedPrivate IKeyAdvancedPrivate { get; }

        /// <summary>
        /// Factory method to construct a KeyPair for the private key <paramref name="PrivateKey"/>
        /// with security binding <paramref name="KeySecurity"/>.
        /// </summary>
        /// <param name="PrivateKey">The private key to construct parameters for.</param>
        /// <param name="KeySecurity">The key security.</param>
        /// <returns>The KeyPair that was constructed</returns>
        public abstract KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey, KeySecurity KeySecurity);

        /// <summary>
        /// Factory method to construct a KeyPair for the public key <paramref name="PublicKey"/>.
        /// </summary>
        /// <param name="PublicKey">The private key to construct parameters for.</param>
        /// <returns>The KeyPair that was constructed</returns>
        public abstract KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey);



        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>The key pair found</returns>
        public static KeyPair FindLocalAdvanced(string UDF) => Platform.FindInKeyStore(UDF, CryptoAlgorithmID.DH);

        /// <summary>
        /// Erase the key from the local machine
        /// </summary>
        public override void EraseFromDevice() => Platform.EraseFromKeyStore(UDF);

        #region // Encryption and Decryption methods

        
        ///// <summary>
        ///// Perform a key exchange to decrypt a bulk or wrapped key under this one.
        ///// </summary>
        ///// <param name="EncryptedKey">The encrypted session key</param>
        ///// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        ///// <param name="AlgorithmID">The algorithm to use.</param>
        ///// <param name="Partial">Partial key agreement value (for recryption)</param>
        ///// <param name="Salt">Optional salt value for use in key derivation. If specified
        ///// must match the salt used to encrypt.</param>
        ///// <returns>The decoded data instance</returns>
        //public abstract byte[] Decrypt(
        //            byte[] EncryptedKey,
        //            KeyPair Ephemeral,
        //            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
        //            KeyAgreementResult Partial = null,
        //            byte[] Salt = null);

        #endregion

        /// <summary>
        /// Split the private key into a number of recryption keys.
        /// <para>
        /// Since the
        /// typical use case for recryption requires both parts of the generated machine
        /// to be used on a machine that is not the machine on which they are created, the
        /// key security level is always to permit export.</para>
        /// </summary>
        /// <param name="Shares">The number of keys to create.</param>
        /// <returns>The created keys</returns>
        public virtual KeyPair[] GenerateRecryptionSet(int Shares) {
            var Private = IKeyAdvancedPrivate.MakeRecryptionKeySet(Shares);

            var Result = new KeyPair[Shares];
            for (var i = 0; i < Shares; i++) {
                Result[i] = KeyPair(Private[i], KeySecurity: KeySecurity.Exportable);
                }

            return Result;
            }

        /// <summary>
        /// Split the private key into a recryption pair. This is a convenience function
        /// to support the most common use case in an implementation.
        /// <para>
        /// Since the
        /// typical use case for recryption requires both parts of the generated machine
        /// to be used on a machine that is not the machine on which they are created, the
        /// key security level is always to permit export.</para>
        /// </summary>
        /// <param name="Recryption">The private key for use by the recryption provider.</param>
        /// <param name="Completion">The private key to be used to complete the decryption
        /// operation.</param>
        public virtual void GenerateRecryptionPair(out KeyPair Recryption, out KeyPair Completion) {
            var Keys = GenerateRecryptionSet(2);
            Recryption = Keys[0];
            Completion = Keys[1];
            }


        /// <summary>
        /// Combine the public parameters with another public key to create the composite public key pair
        /// </summary>
        /// <param name="Contribution">The public key parameters to combine</param>
        /// <returns>The generated public key pair.</returns>
        public KeyPairAdvanced CombinePublic(KeyPairAdvanced Contribution) {
            var PublicKey = IKeyAdvancedPublic.Combine(Contribution.IKeyAdvancedPublic);
            return KeyPair(PublicKey);
            }

        /// <summary>
        /// Combine the private parameters with another private key to create the composite private key pair
        /// </summary>
        /// <param name="Contribution"></param>
        /// <param name="KeySecurity"></param>
        /// <returns></returns>
        public KeyPairAdvanced Combine(KeyPairAdvanced Contribution, KeySecurity KeySecurity) {
            var PrivateKey = IKeyAdvancedPrivate.Combine(Contribution.IKeyAdvancedPrivate);
            return KeyPair(PrivateKey, KeySecurity);
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
                _KeyDerive = _KeyDerive ?? new KeyDeriveHKDF(IKM, _Salt);
                return _KeyDerive;
                }
            set => _KeyDerive = value;
            }


        /// <summary>The key agreement result as a byte array</summary>
        public abstract byte[] IKM { get; }


        /// <summary>Public key generated by ephemeral key generation.</summary>
        public virtual IKeyAdvancedPublic EphemeralPublicValue { get; set;  }

        /// <summary>The public key portion of the ephemeral key</summary>
        public abstract KeyPair EphemeralKeyPair { get; }

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        public virtual void Encrypt(byte[] Key,
            out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null) {

            // Console.Write($"PRK Encrypt is {IKM.ToStringBase16()}");

            var EncryptionKey = KeyDerive.Derive(Salt, Length: 256);
            // Console.Write($"EncryptionKey Encrypt is {EncryptionKey.ToStringBase16()}");

            Exchange = Platform.KeyWrapRFC3394.Wrap(EncryptionKey, Key);
            Ephemeral = EphemeralKeyPair;
            }

        /// <summary>
        /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session key</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="Partial">Partial key agreement value (for recryption)</param>
        /// <param name="Salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>
        /// <returns>The decoded data instance</returns>
        public virtual byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral,
                    KeyAgreementResult Partial = null,
                    byte[] Salt = null) {


            var EncryptionKey = KeyDerive.Derive(Salt, Length: 256);
            var KeySize = (EncryptedKey.Length * 8) - 64;

            return Platform.KeyWrapRFC3394.Unwrap(EncryptionKey, EncryptedKey);

            }

        }

    /// <summary>
    /// Base clase for elliptic curve key agreement results (may be eliminated at a future date).
    /// </summary>
    public abstract class ResultECDH : KeyAgreementResult {


        }

    }
