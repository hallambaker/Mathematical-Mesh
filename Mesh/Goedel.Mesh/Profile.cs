using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {


    public partial class Assertion {

        ///<summary>The UDF profile constant used for key derrivation</summary>
        public virtual string UDFKeyDerrivation => throw new NYI();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Assertion() {
            }


        /// <summary>
        /// Combine the public key value <paramref name="baseKey"/> with a key derrived from
        /// <paramref name="secret"/> using the UDF salt value specified by <see
        /// cref="UDFKeyDerrivation"/> and <paramref name="saltSuffix"/>.
        /// </summary>
        /// <param name="keyCollection">The key collection to register the 
        /// generated public key to.</param>
        /// <param name="baseKey">The base key parameters.</param>
        /// <param name="secret">The UDF used to derrive the key.</param>
        /// <param name="saltSuffix">The salt suffix specifying the particular key
        /// type.</param>
        /// <returns>The aggregate public key parameters.</returns>
        public KeyPairAdvanced Combine (
                KeyCollection keyCollection,
                PublicKey baseKey,
                string secret,
                string saltSuffix)  {
            throw new NYI();

            }

        /// <summary>
        /// Derrive a key pair contribution to an aggregate key pair.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist 
        /// the generated keys. This should be null for an activation key.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="saltSuffix">The salt suffix specifying the particular key
        /// type.</param>
        /// <returns>The derrived key pair.</returns>
        public KeyPair Derive (
                KeyCollection keyCollection,
                PrivateKeyUDF secretSeed,
                string saltSuffix) {

            var keyUses = KeyUses.Sign;
            var cryptoAlgorithmID = CryptoAlgorithmID.NULL;
            switch (saltSuffix) {
                case Constants.UDFMeshKeySufixEncrypt: {
                    keyUses = KeyUses.Encrypt;
                    cryptoAlgorithmID = secretSeed.AlgorithmEncryptID;
                    break;
                    }
                case Constants.UDFMeshKeySufixSign: {
                    keyUses = KeyUses.Sign;
                    cryptoAlgorithmID = secretSeed.AlgorithmSignID;
                    break;
                    }
                case Constants.UDFMeshKeySufixAuthenticate: {
                    keyUses = KeyUses.KeyAgreement;
                    cryptoAlgorithmID = secretSeed.AlgorithmAuthenticateID;
                    break;
                    }
                }

            return Cryptography.UDF.DeriveKey(secretSeed.PrivateValue, keyCollection,
               KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix);
            }



        }

    public partial class Profile {

        ///<summary>The primary key value.</summary>
        public override string _PrimaryKey => UDF;

        ///<summary>The UDF of the profile, that is the UDF of the offline signature.</summary>
        public string UDF => KeyOfflineSignature.UDF;

        ///<summary>The full UDF binary key value.</summary>
        public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);


        /// <summary>
        /// Verify the profile to check that it is correctly signed and consistent.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate() => Verify(DareEnvelope);

        /// <summary>
        /// Verify that the assertion contained in <paramref name="envelopedAssertion"/>
        /// has a valid signature under this profile.
        /// </summary>
        /// <param name="envelopedAssertion">Envelope containing the assertion 
        /// to be verified.</param>
        /// <returns>True if there is a valid signature under this profile, otherwise false.</returns>
        public bool Verify(DareEnvelope envelopedAssertion) {
            "Need to implement pathmath".TaskValidate();
            return false;
            }

        }

    public partial class Activation {

        ///<summary>The <see cref="ProfileDevice"/> that this activation activates.</summary>
        public ProfileDevice ProfileDevice;

        ///<summary>The aggregate signature key</summary>
        public KeyPairAdvanced KeySignature;


        ///<summary>The connection value.</summary>
        public virtual Connection Connection => throw new NYI();

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Activation() {
            }


        /// <summary>
        /// Constructor creating a new <see cref="Activation"/> for a profile of type
        /// <paramref name="profile"/>. The property <see cref="ActivationKey"/> is
        /// calculated from the values <paramref name="udfAlgorithmIdentifier"/> and 
        /// <paramref name="salt"/>. If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The <see cref="KeySignature"/> public key value is calculated for the specified 
        /// parameters and registered in the KeyCollection <paramref name="keyCollection"/>.
        /// Other key pair properties should be populated by the caller.
        /// </summary>
        /// <param name="profile">The base profile that the activation activates.</param>
        /// <param name="keyCollection">The key collection to register the 
        /// <see cref="KeySignature"/> public key to.</param>
        /// <param name="udfAlgorithmIdentifier">The UDF key derivation specifier.</param>
        /// <param name="salt">The salt suffix used to derrive the key.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        protected Activation(
                Profile profile,
                KeyCollection keyCollection,
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                string salt,
                byte[] masterSecret = null,
                int bits = 256) {
            masterSecret ??= Platform.GetRandomBits(bits);
            ActivationKey = Cryptography.UDF.DerivedKey(
                    udfAlgorithmIdentifier, data: masterSecret);

            KeySignature = Combine(keyCollection, profile.KeyOfflineSignature,
                ActivationKey, Constants.UDFMeshKeySufixSign);


            }

        /// <summary>
        ///  Get a private key by combining the device and activation keys. The activation
        ///  key is generated from <see cref="ActivationKey"/>.
        /// </summary>
        /// <param name="keyCollection"></param>
        /// <param name="deviceKey"></param>
        /// <param name="saltSuffix"></param>
        /// <returns></returns>
        public static KeyPairAdvanced GetPrivate(
                KeyCollection keyCollection, PublicKey deviceKey, string saltSuffix) =>
                    throw new NYI();


        /// <summary>
        /// Get the encryption private key.
        /// </summary>
        /// <param name="keyCollection">The key collection to register the 
        /// aggregate public key to.</param>
        /// <param name="profileDevice">The base device profile.</param>
        /// <returns>The signature private key.</returns>
        public KeyPairAdvanced GetkeyEncryptionPrivate(KeyCollection keyCollection, ProfileDevice profileDevice) =>
            GetPrivate(keyCollection, profileDevice.KeyEncryption, Constants.UDFMeshKeySufixEncrypt);

        /// <summary>
        /// Get the signature private key.
        /// </summary>
        /// <param name="keyCollection">The key collection to register the 
        /// aggregate public key to.</param>
        /// <param name="profileDevice">The base device profile.</param>
        /// <returns>The signature private key.</returns>
        public KeyPairAdvanced GetkeySignaturePrivate(KeyCollection keyCollection, ProfileDevice profileDevice) =>
            GetPrivate(keyCollection, profileDevice.KeyOfflineSignature, Constants.UDFMeshKeySufixSign);

        /// <summary>
        /// Get the authentication private key.
        /// </summary>
        /// <param name="keyCollection">The key collection to register the 
        /// aggregate public key to.</param>
        /// <param name="profileDevice">The base device profile.</param>
        /// <returns>The signature private key.</returns>
        public KeyPairAdvanced GetkeyAuthenticationPrivate(KeyCollection keyCollection, ProfileDevice profileDevice) =>
            GetPrivate(keyCollection, profileDevice.KeyAuthentication, Constants.UDFMeshKeySufixAuthenticate);



        /// <summary>
        /// Encrypt this activation under the ProfileDevice encryption key.
        /// </summary>
        /// <returns>The actrivation profile encrypted under the encryption key of
        /// the corresponding <see cref="ProfileDevice"/>.</returns>
        public DareEnvelope Package(KeyPair SignatureKey) {

            EnvelopedConnection = Connection.Sign(SignatureKey);
            DareEnvelope = DareEnvelope.Encode(GetBytes(true), 
                signingKey: SignatureKey, encryptionKey: ProfileDevice.KeyEncryption.KeyPair);

            return DareEnvelope;
            }

        }
    }
