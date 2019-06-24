using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {


    public partial class ConnectionItem {
        public static object Initialize => null;

        static ConnectionItem() => ContainerPersistenceStore.AddDictionary(_TagDictionary);
        }

    public partial class Connection {
        public override string _PrimaryKey => ID;


        }


    public partial class DeviceConnection {

        public DareEnvelope EncodedProfileDevice => CatalogEntryDevice.EnvelopedProfileDevice;


        }

    public partial class AdminConnection {



        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public AdminConnection() {
            }

        /// <summary>
        /// Generate a new Admin Entry
        /// </summary>
        /// <param name="profileDevice"></param>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public static AdminConnection Generate(
                IMeshMachine meshMachine,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            var profileMaster = ProfileMaster.Generate(meshMachine, algorithmSign, algorithmEncrypt);


            return Generate(meshMachine, profileMaster);
            }

        public static AdminConnection Generate(
                IMeshMachine meshMachine,
                ProfileMaster profileMaster ) {
            return new AdminConnection() {

                };

            }


        }


    public partial class PendingConnection {

        public MessageConnectionResponse MessageConnectionResponse => messageConnectionResponse ??
            MessageConnectionResponse.Decode(EnvelopedMessageConnectionResponse).
                CacheValue(out messageConnectionResponse);
        MessageConnectionResponse messageConnectionResponse;



        }

    }