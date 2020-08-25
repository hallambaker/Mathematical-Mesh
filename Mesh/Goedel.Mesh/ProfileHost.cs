using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {

    public partial class ProfileHost {


        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileHost> EnvelopedProfileHost =>
            envelopedProfileHost ?? new Enveloped<ProfileHost>(Enveloped).
                    CacheValue(out envelopedProfileHost);
        Enveloped<ProfileHost> envelopedProfileHost;


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
            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyAuthentication = new KeyData(keyAuth.KeyPairPublic());
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


        }
    }
