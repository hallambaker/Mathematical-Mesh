using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh.Protocol;
using Goedel.Mesh.Protocol.Client;

namespace ExampleGenerator {
    public partial class CreateExamples {


        public void NewMesh() => NewStartService();

        void NewStartService() {
            // Create test Mesh
            File.Delete(LogMesh);
            File.Delete(LogPortal);

            //Portal = new MeshPortalTraced(NameService, LogMesh, LogPortal);
            //MeshPortal.Default = Portal;
            //Traces = Portal.Traces;
            //MeshClient = new MeshClient(PortalAccount: AccountID);
            }

        }
    }
