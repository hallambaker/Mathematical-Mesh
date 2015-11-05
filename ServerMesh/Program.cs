using System;
using Goedel.Mesh;
using Goedel.Protocol;

namespace MeshServerShell {
    public partial class MeshServerShell {

        /// <summary>
        /// Start the mesh server
        /// </summary>
        /// <param name="Options"></param>
        public override void Start(Start Options) {

            // Create the provider object.
            var MeshServiceHost = new PublicMeshServiceHost(Options.Address.Value, 
                Options.MeshStore.Value, Options.PortalStore.Value);

            // Create the dispatcher for the provider.
            MeshServiceHost.Service = new MeshServiceSession(MeshServiceHost, null);

            // Create the server, add the provider, create service port.
            var Server = new JPCServer();
            var HostReg = Server.Add(MeshServiceHost);
            var PortReg = HostReg.AddService(Options.Address.Value);

            // Run until abort
            Server.RunBlocking();
            }

        }
    }
