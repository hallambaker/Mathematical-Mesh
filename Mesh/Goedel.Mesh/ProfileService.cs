using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {
    public partial class ProfileService {

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
                    KeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {
            var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);
            var keyAuthenticate = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixAuthenticate);

            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuthenticate.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }
            }



        /// <summary>
        /// Constructor create service with the signature key <paramref name="keySign"/>
        /// </summary>
        /// <param name="keySign">The offline signature key.</param>
        public ProfileService(KeyPair keySign) => KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());




        /// <summary>
        /// Generate a new <see cref="ProfileService"/>
        /// </summary>
        /// <param name="meshMachine">The mesh machine</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <returns>The service profile.</returns>
        public static ProfileService Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) {



            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileService(keySign);
            result.Sign(keySign);
            return result;
            }

        /// <summary>
        /// Decode from DareEnvelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded ProfileService.</returns>
        public static new ProfileService Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
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
