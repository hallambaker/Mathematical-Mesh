using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class ProfileService {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileService> EnvelopedProfileService =>
            envelopedProfileService ?? new Enveloped<ProfileService>(DareEnvelope).
                    CacheValue(out envelopedProfileService);
        Enveloped<ProfileService> envelopedProfileService;



        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileService() { }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileService(
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {
            var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);
            var keyAuthenticate = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixAuthenticate);
            var keyEncryption = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixEncrypt);

            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyAuthentication = new KeyData(keyAuthenticate.KeyPairPublic());
            KeyEncryption = new KeyData(keyEncryption.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(OfflineSignature.UDF, secretSeed, false);
                }
            }



        /// <summary>
        /// Constructor create service with the signature key <paramref name="keySign"/>
        /// </summary>
        /// <param name="keySign">The offline signature key.</param>
        /// <param name="keyEncrypt">The service encryption key.</param>
        public ProfileService(KeyPair keySign, KeyPair keyEncrypt) {
            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyEncryption = new KeyData(keyEncrypt.KeyPairPublic());
            }



        /// <summary>
        /// Generate a new <see cref="ProfileService"/>
        /// </summary>
        /// <param name="meshMachine">The mesh machine</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <returns>The service profile.</returns>
        public static ProfileService Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) {



            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();

            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.ExportableStored, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.ExportableStored, keyUses: KeyUses.Encrypt);
            //var keyAuthenticate = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.KeyAgreement);


            var result = new ProfileService(keySign, keyEncrypt);
            result.Envelope(keySign);
            return result;
            }


        /// <summary>
        /// Create a host under this service.
        /// </summary>
        /// <param name="meshMachine">The machine.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <returns>The host profile.</returns>
        public ProfileHost CreateHost(IMeshMachine meshMachine,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) => ProfileHost.Generate(meshMachine, algorithmSign);

        }


    }
