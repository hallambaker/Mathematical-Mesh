using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class ProfileService {
        public string UDF => KeyOfflineSignature.UDF;

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




        public ProfileService(KeyPair keySign) => KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());





        public static ProfileService Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) {



            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileService(keySign);
            result.Sign(keySign);
            return result;
            }

        public static new ProfileService Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }





        public ProfileHost CreateHost(IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) => ProfileHost.Generate(meshMachine, algorithmSign);

        }

    public partial class ProfileHost {

        public string UDF => KeyOfflineSignature.UDF;

        public ProfileHost() { }

        public ProfileHost(KeyPair keySign,
                    KeyPair keyAuth) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuth.KeyPairPublic());
            }

        public static ProfileHost Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            var keyAuth = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.KeyAgreement);
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileHost(keySign, keyAuth);
            result.Sign(keySign);
            return result;
            }

        public static new ProfileHost Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }
    }
