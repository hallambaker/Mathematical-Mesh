using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    public partial class ProfileHost {
        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
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
