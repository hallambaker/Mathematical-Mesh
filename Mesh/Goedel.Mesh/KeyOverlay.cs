using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh {

    public partial class KeyComposite {

        public string UDF => KeyPair.UDF;
        public KeyPairAdvanced KeyPair => keyPair ?? (Public.KeyPair as KeyPairAdvanced).CacheValue (out keyPair);
        KeyPairAdvanced keyPair = null;

        public KeyComposite() {

            }

        public KeyComposite(PublicKey baseKey, string service) :
                    this(baseKey.KeyPair as KeyPairAdvanced, service) {
            }

        public KeyComposite(KeyPairAdvanced baseKey, string service=null) {
            Public = Cryptography.Jose.Key.GetPublic(baseKey);
            if (service == null) {
                Part = Cryptography.Jose.Key.GetPrivate(baseKey);

                }
            else {
                throw new NYI(); // ToDo: implement service for split keys
                }
            }

        public KeyPairAdvanced GetPrivate(IMeshMachine meshMachine) =>
                meshMachine.KeyCollection.LocatePrivate(UDF) as KeyPairAdvanced;


        }


    public partial class KeyOverlay {

        public KeyPairAdvanced KeyPair;


        public KeyOverlay() {

            }


        public KeyOverlay(IMeshMachine meshMachine, PublicKey baseKey) : 
                    this(meshMachine, baseKey.KeyPair as KeyPairAdvanced ) {
            }
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
            GetPrivate(meshMachine.KeyCollection.LocatePrivate(BaseUDF) as KeyPairAdvanced);


        public KeyPairAdvanced GetPrivate(KeyPairAdvanced keypairBase) {
            var keypairOverlay = Overlay.GetKeyPair(keySecurity: KeySecurity.Exportable) as KeyPairAdvanced;
            var combined = keypairOverlay.Combine(keypairBase);
            Assert.AssertTrue(combined.UDF == UDF);
            return combined;
            }

        }
    }
