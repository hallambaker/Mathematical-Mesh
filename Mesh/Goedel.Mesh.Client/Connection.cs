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

        ///<summary>The device profile</summary>
        public virtual ProfileDevice ProfileDevice => throw new NYI();

        }


    public partial class CatalogedStandard {

        ///<summary>The device profile (from <see cref="CatalogedDevice"/>)</summary>
        public override ProfileDevice ProfileDevice => CatalogedDevice?.ProfileDevice;


        }

    public partial class CatalogedAdmin {

        ///<summary>The device profile (from <see cref="CatalogedDevice"/>)</summary>
        public override ProfileDevice ProfileDevice => CatalogedDevice?.ProfileDevice;

        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogedAdmin() {
            }

        }


    public partial class CatalogedPending {

        ///<summary>The decoded device profile (from <see cref="EnvelopedProfileDevice"/>)</summary>
        public override ProfileDevice ProfileDevice =>
                    ProfileDevice.Decode(EnvelopedProfileDevice);


        /// <summary>
        /// Cached convenience accessor returning the decoded <see cref="MessageConnectionResponse"/>.
        /// </summary>
        public AcknowledgeConnection MessageConnectionResponse => messageConnectionResponse ??
            AcknowledgeConnection.Decode(EnvelopedMessageConnectionResponse).
                CacheValue(out messageConnectionResponse);
        AcknowledgeConnection messageConnectionResponse;



        }
    public partial class CatalogedPreconfigured {
        ///<summary>The decoded device profile (from <see cref="EnvelopedProfileDevice"/>)</summary>
        public override ProfileDevice ProfileDevice =>
                    ProfileDevice.Decode(EnvelopedProfileDevice);


        //            (var account, var key) = MeshUri.ParseConnectUri(devicePreconfiguration.ConnectUri);
        }
    }