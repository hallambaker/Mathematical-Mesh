using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    public partial class ProfileHost {
        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileHost() { }

        /// <summary>
        /// Construct a Profile Host instance using the key <paramref name="keySign"/> for signature and
        /// <paramref name="keyAuth"/> for authentication.
        /// </summary>
        /// <param name="keySign">The signature key.</param>
        /// <param name="keyAuth">The authentication key.</param>
        public ProfileHost(KeyPair keySign,
                    KeyPair keyAuth) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuth.KeyPairPublic());
            }

        /// <summary>
        /// Generate a new <see cref="ProfileHost"/> for <paramref name="meshMachine"/> using the 
        /// signature algorithm <paramref name="algorithmSign"/>    
        /// </summary>
        /// <param name="meshMachine">The mesh machine description.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuth">The authentication algorithm.</param>
        /// <returns>The created ProfileHost.</returns>
        public static ProfileHost Generate(
            IMeshMachine meshMachine,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuth = CryptoAlgorithmId.Default) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmAuth = algorithmAuth.DefaultAlgorithmAuthenticate();
            var keyAuth = meshMachine.CreateKeyPair(algorithmAuth, KeySecurity.Device, keyUses: KeyUses.KeyAgreement);
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);

            var result = new ProfileHost(keySign, keyAuth);
            result.Sign(keySign);
            return result;
            }


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ProfileHost"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ProfileHost Decode(DareEnvelope envelope,
                    KeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileHost;

        }
    }
