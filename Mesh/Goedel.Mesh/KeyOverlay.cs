using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Mesh {

    public partial class KeyComposite {

        ///<summary>Convenience accessor for the composite UDF.</summary>
        public string UDF => KeyPair.UDF;

        ///<summary>The composite key pair.</summary>
        public KeyPairAdvanced KeyPair => keyPair ?? (Public.KeyPair as KeyPairAdvanced).CacheValue(out keyPair);
        KeyPairAdvanced keyPair = null;

        /// <summary>
        /// Default constructor for deserialization.
        /// </summary>
        public KeyComposite() {

            }

        /// <summary>
        /// Constructor from base key <paramref name="baseKey"/> with decryption service 
        /// <paramref name="service"/>.
        /// </summary>
        /// <param name="baseKey">The base key.</param>
        /// <param name="service">The decryption service.</param>
        public KeyComposite(PublicKey baseKey, string service) :
                    this(baseKey.KeyPair as KeyPairAdvanced, service) {
            }

        /// <summary>
        /// Constructor from base key <paramref name="baseKey"/> with decryption service 
        /// <paramref name="service"/>.
        /// </summary>
        /// <param name="baseKey">The base key.</param>
        /// <param name="service">The decryption service.</param>
        public KeyComposite(KeyPairAdvanced baseKey, string service = null) {
            Public = Cryptography.Jose.Key.GetPublic(baseKey);
            if (service == null) {
                Part = Cryptography.Jose.Key.GetPrivate(baseKey);

                }
            else {
                throw new NYI(); // ToDo: implement service for split keys
                }
            }

        ///// <summary>
        ///// Return the private key 
        ///// </summary>
        ///// <param name="meshMachine"></param>
        ///// <returns></returns>
        //public KeyPairAdvanced GetPrivate(IMeshMachine meshMachine) =>
        //        meshMachine.KeyCollection.LocatePrivateKeyPair(UDF) as KeyPairAdvanced;


        }


    public partial class KeyOverlay {

        ///<summary>The composite key pair.</summary>
        public KeyPairAdvanced KeyPair { get; set; }

        ///<summary>The composite public key.</summary>
        public PublicKey PublicKey { get; set; }

        /// <summary>
        /// Default constructor for deserialization.
        /// </summary>
        public KeyOverlay() {

            }


        //public KeyOverlay(
        //        KeyCollection keyCollection, 
        //        PublicKey baseKey,
        //        string secret,
        //        string salt1,
        //        string salt)  {
        //    throw new NYI();
        //    }


        /// <summary>
        /// Constructor from <paramref name="baseKey"/> storing partial keys to <paramref name="meshMachine"/>.
        /// </summary>
        /// <param name="meshMachine">The machine.</param>
        /// <param name="baseKey">The base key to overlay.</param>
        public KeyOverlay(IMeshMachine meshMachine, PublicKey baseKey) :
                    this(meshMachine, baseKey.KeyPair as KeyPairAdvanced) {
            }

        /// <summary>
        /// Constructor from <paramref name="baseKey"/> storing partial keys to <paramref name="meshMachine"/>.
        /// </summary>
        /// <param name="meshMachine">The machine.</param>
        /// <param name="baseKey">The base key to overlay.</param>
        public KeyOverlay(IMeshMachine meshMachine, KeyPairAdvanced baseKey) {

            var overlay = meshMachine.CreateKeyPair(
                        baseKey.CryptoAlgorithmID,
                        KeySecurity.Exportable,
                        keyUses: baseKey.KeyUses) as KeyPairAdvanced;

            KeyPair = overlay.CombinePublic(baseKey);

            UDF = KeyPair.UDF;
            BaseUDF = baseKey.UDF;
            Overlay = Cryptography.Jose.Key.GetPrivate(overlay);
            }


        /// <summary>
        /// Return a KeyPair instance that performs the combined key function. Note that the
        /// combined key is only exportable if the base and overlay keys are. Also the 
        /// implementation may be achieved by reconstructing the key or by performing the 
        /// components separately.
        /// </summary>
        /// <param name="meshMachine">The machine on which private keys are to be resolved.</param>
        /// <returns></returns>
        public KeyPairAdvanced GetPrivate(IMeshMachine meshMachine) =>
            GetPrivate(meshMachine.KeyCollection.LocatePrivateKeyPair(BaseUDF) as KeyPairAdvanced);

        /// <summary>
        /// Return the private key.
        /// </summary>
        /// <param name="keypairBase">The base key.</param>
        /// <returns>The composite keypair.</returns>
        public KeyPairAdvanced GetPrivate(KeyPairAdvanced keypairBase) {
            var keypairOverlay = Overlay.GetKeyPair(keySecurity: KeySecurity.Exportable) as KeyPairAdvanced;
            var combined = keypairOverlay.Combine(keypairBase);
            Assert.AssertTrue(combined.UDF == UDF);
            return combined;
            }


        //public KeyPairAdvanced GetPrivate(IMeshMachine meshMachine, string baseUDF) {
        //    var keyContribution = meshMachine.KeyCollection.LocatePrivate(baseUDF);
        //    return 

        //    }
        }
    }
