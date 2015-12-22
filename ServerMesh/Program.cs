//Sample license text.
using System;
using Goedel.Mesh;
using Goedel.Protocol;

namespace MeshServerShell {
    public partial class MeshServerShell {

        // To run, it is necessary to first set permissions (as root)
        // netsh http add urlacl url=http://+:80/.well-known user=VOODOO\Phillip

        //netsh http>add urlacl url="http://prismproof.org:80/.well-known/MeshService/" user=VOODOO\Phillip

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
