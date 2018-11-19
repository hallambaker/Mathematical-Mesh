using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
namespace Goedel.Mesh.Protocol.Client {

    // The client functions associated with the device.
    public partial class ContextDevice {


        ////MeshService MeshService = meshService ??
        ////    Machine.
        //MeshService MeshService => meshService ?? Machine.GetMeshClient(null);
        protected MeshService meshService;
        protected string AccountName;

        public MeshHelloResponse Connect(string service) {
            meshService = Machine.GetMeshClient(service);
            var request = new HelloRequest();
            return meshService.Hello(request);
            }



        public MeshResult Sync() => throw new NYI();

        public MeshResult Add(CatalogEntry catalogEntry) => throw new NYI();

        public MeshResult ContactRequest(string recipient, DareMessage dareMessage) => throw new NYI();

        public MeshResult ConfirmationRequest(string recipient, string Text) => throw new NYI();
        }
    }
