using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {


    public partial class HostCatalogItem {

        ///<summary>Dummy property used to force initialization.</summary>
        public static object Initialize => null;

        static HostCatalogItem() => AddDictionary(ref _TagDictionary);
        }

    public partial class CatalogedMachine {

        ///<summary>The unique identifier.</summary>
        public override string _PrimaryKey => ID;


        }


    public partial class CatalogedStandard {



        //public DareEnvelope EncodedProfileDevice => CatalogedDevice.EnvelopedProfileDevice;


        }

    public partial class CatalogedAdmin {



        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogedAdmin() {
            }

        ///// <summary>
        ///// Generate a new Admin Entry
        ///// </summary>
        ///// <param name="profileDevice"></param>
        ///// <param name="algorithmSign"></param>
        ///// <param name="algorithmEncrypt"></param>
        ///// <returns></returns>
        //public static CatalogedAdmin Generate(
        //        IMeshMachine meshMachine,
        //        CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
        //        CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

        //    var profileMaster = ProfileMesh.Generate(meshMachine, algorithmSign, algorithmEncrypt);


        //    return Generate(meshMachine, profileMaster);
        //    }

        //public static CatalogedAdmin Generate(
        //        IMeshMachine meshMachine,
        //        ProfileMesh profileMaster) => new CatalogedAdmin() {

        //            };


        }


    public partial class CatalogedPending {

        /// <summary>
        /// Cached convenience accessor returning the decoded <see cref="MessageConnectionResponse"/>.
        /// </summary>
        public AcknowledgeConnection MessageConnectionResponse => messageConnectionResponse ??
            AcknowledgeConnection.Decode(EnvelopedMessageConnectionResponse).
                CacheValue(out messageConnectionResponse);
        AcknowledgeConnection messageConnectionResponse;



        }

    }