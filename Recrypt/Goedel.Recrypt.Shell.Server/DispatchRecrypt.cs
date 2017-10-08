//   Copyright © 2017 by Comodo Group Inc.
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
using Goedel.Protocol;

using Goedel.Recrypt;
using Goedel.Recrypt.Server;

using System.Diagnostics;
namespace Goedel.Recrypt.Shell.Server {
    public partial class RecryptShell {

        // To run, it is necessary to first set permission (as root)
        // netsh http add urlacl url="http://example.com:80/.well-known/recrypt/" user=VOODOO\Phillip
        // NB: Having redundant permissions seems to cause issues, instead of granting both
        //     sets of privileges, Windows grants neither.

        /// <summary>
        /// Start the recrypt server
        /// </summary>
        /// <param name="Options"></param>
        public override void Start (Start Options) {

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));


            // Create the provider object.
            var RecryptServiceProvider = new RecryptLocalServiceProvider(
                        Options.ServiceAddress.Value,
                        Options.Store.Value);


            // Create the server, add the provider, create service port.
            var Server = new JPCServer();
            var HostReg = Server.Add(RecryptServiceProvider);

            // Create the interface dispatcher for the provider.
            var Interface = new RecryptServiceLocal(RecryptServiceProvider, (JPCSession)null);
            var InterfaceReg = HostReg.Add(Interface);

            // Register the network port.
            if (Options.HostAddress.Value != null) {
                InterfaceReg.AddService(Options.HostAddress.Value);
                }
            if (Options.Fallback.Value) {
                var Fallback = "recrypt." + Options.ServiceAddress.Value;
                InterfaceReg.AddService(Fallback);
                }

            // Run until abort in async or multithread mode.
            if (Options.Multithread.Value) {
                Server.StartAsync();         
                }
            else {
                Server.RunBlocking(); 
                }
            }

        }
    }
