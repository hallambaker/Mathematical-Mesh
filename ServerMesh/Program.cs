//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using Goedel.Mesh;
using Goedel.Protocol;

namespace MeshServerShell {
    public partial class MeshServerShell {

        // To run, it is necessary to first set permissions (as root)
        // netsh http add urlacl url=http://+:80/.well-known user=VOODOO\Phillip

        // netsh http add urlacl url="http://prismproof.org:80/.well-known/MeshService/" user=VOODOO\Phillip

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
