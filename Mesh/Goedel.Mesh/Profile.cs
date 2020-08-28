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
        /// Derrive a key pair contribution to an aggregate key pair.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist 
        /// the generated keys. This should be null for an activation key.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="saltSuffix">The salt suffix specifying the particular key
        /// type.</param>
        /// <returns>The derrived key pair.</returns>
        public KeyPair Derive (
                IKeyCollection keyCollection,
                PrivateKeyUDF secretSeed,
                string saltSuffix) {

            var keyUses = KeyUses.Sign;
            var cryptoAlgorithmID = CryptoAlgorithmId.NULL;
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

                default:
                    break;
                }

            return Cryptography.UDF.DeriveKey(secretSeed.PrivateValue, keyCollection,
               KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix);
            }



        }

    public partial class Profile {

        ///<summary>The primary key value.</summary>
        public override string _PrimaryKey => UDF;

        ///<summary>The UDF of the profile, that is the UDF of the offline signature.</summary>
        public string UDF => OfflineSignature.UDF;

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
            envelopedAssertion.Future();
            "Need to implement pathmath".TaskValidate();
            return false;
            }

        /// <summary>
        /// Return a UDF private key seed. This may be used to derrive multiple private key pairs.
        /// </summary>
        /// <param name="meshMachine">The mesh cryptographic storage.</param>
        /// <returns>The private key data if found, otherwise null.</returns>
        public PrivateKeyUDF GetPrivateKeyUDF(IMeshMachine meshMachine) =>
            meshMachine.KeyCollection.LocatePrivateKey(UDF) as PrivateKeyUDF;


        }

    public partial class Activation {

        ///<summary>The <see cref="ProfileDevice"/> that this activation activates.</summary>
        public ProfileDevice ProfileDevice { get; set; }

        ///<summary>The aggregate signature key</summary>
        protected KeyPairAdvanced KeySignature { get; set; }

        ///<summary>The UDF identifier</summary>
        public string UDF => KeySignature.KeyIdentifier;

        ///<summary>The connection value.</summary>
        public virtual Connection Connection => throw new NYI();

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Activation() {
            }

        /// <summary>
        /// The Mech Key Type.
        /// </summary>
        protected MeshKeyType MeshKeyType;

        /// <summary>
        /// Constructor creating a new <see cref="Activation"/> for a profile of type
        /// <paramref name="profile"/>. The property <see cref="ActivationKey"/> is
        /// calculated from the values <paramref name="udfAlgorithmIdentifier"/>. 
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The <see cref="KeySignature"/> public key value is calculated for the specified 
        /// parameters. Other key pair properties should be populated by the caller.
        /// </summary>
        /// <param name="profile">The base profile that the activation activates.</param>
        /// <param name="udfAlgorithmIdentifier">The UDF key derivation specifier.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if 
        /// <paramref name="masterSecret"/> is null.</param>
        protected Activation(
                Profile profile,
                UdfAlgorithmIdentifier udfAlgorithmIdentifier,
                byte[] masterSecret = null,
                int bits = 256) {
            MeshKeyType = udfAlgorithmIdentifier.GetMeshKeyType();
            ActivationKey = Cryptography.UDF.DerivedKey(udfAlgorithmIdentifier, data: masterSecret, bits);

            KeySignature = profile.OfflineSignature.ActivatePublic(ActivationKey,
               MeshKeyType | MeshKeyType.RootSign);
            }


        /// <summary>
        /// Encrypt this activation under the ProfileDevice encryption key.
        /// </summary>
        /// <returns>The actrivation profile encrypted under the encryption key of
        /// the corresponding <see cref="ProfileDevice"/>.</returns>
        public DareEnvelope Package(CryptoKey SignatureKey) => 
                Envelope(SignatureKey, ProfileDevice.KeyEncryption.CryptoKey);

        }
    }
