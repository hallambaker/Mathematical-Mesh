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
            var MeshServiceProvider = new PublicMeshServiceProvider(Options.Address.Value, 
                Options.MeshStore.Value, Options.PortalStore.Value);


            // Create the server, add the provider, create service port.
            var Server = new JPCServer();
            var HostReg = Server.Add(MeshServiceProvider);

            // Create the interface dispatcher for the provider.
            var Interface = new MeshServiceSession(MeshServiceProvider, null);
            var InterfaceReg = HostReg.Add (Interface);

            // Register the network port.
            var PortReg = InterfaceReg.AddService(Options.Address.Value);

            // Run until abort
            Server.RunBlocking();
            }

        }
    }
