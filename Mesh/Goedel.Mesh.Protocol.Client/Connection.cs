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

        static ConnectionItem() => AddDictionary(ref _TagDictionary);
        }

    public partial class CatalogedMachine {
        public override string _PrimaryKey => ID;


        }


    public partial class CatalogedStandard {

        public DareEnvelope EncodedProfileDevice => CatalogedDevice.EnvelopedProfileDevice;


        }

    public partial class CatalogedAdmin {



        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogedAdmin() {
            }

        /// <summary>
        /// Generate a new Admin Entry
        /// </summary>
        /// <param name="profileDevice"></param>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public static CatalogedAdmin Generate(
                IMeshMachine meshMachine,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            var profileMaster = ProfileMesh.Generate(meshMachine, algorithmSign, algorithmEncrypt);


            return Generate(meshMachine, profileMaster);
            }

        public static CatalogedAdmin Generate(
                IMeshMachine meshMachine,
                ProfileMesh profileMaster ) {
            return new CatalogedAdmin() {

                };

            }


        }


    public partial class CatalogedPending {

        public AcknowledgeConnection MessageConnectionResponse => messageConnectionResponse ??
            AcknowledgeConnection.Decode(EnvelopedMessageConnectionResponse).
                CacheValue(out messageConnectionResponse);
        AcknowledgeConnection messageConnectionResponse;



        }

    }