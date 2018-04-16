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
using Goedel.Confirm;
using Goedel.Confirm.Server;
using Goedel.Account.Server;
using Goedel.Recrypt.Server;

using System.Diagnostics;
namespace Goedel.Confirm.Shell.Server {
    public partial class ConfirmShell {

        // To run, it is necessary to first set permission (as root)
        // netsh http add urlacl url="http://example.com:80/.well-known/Confirm/" user=VOODOO\Phillip
        // NB: Having redundant permissions seems to cause issues, instead of granting both
        //     sets of privileges, Windows grants neither.

        /// <summary>
        /// Start the Confirm server
        /// </summary>
        /// <param name="Options"></param>
        public override void Start (Start Options) {

            System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            // Create the server, add the provider, create service port.

            Goedel.Cryptography.Cryptography.Initialize();
            var Server = new JPCServer();


            // Create the provider object.
            var ConfirmServiceProvider = new ConfirmLocalServiceProvider(
                        Options.ServiceAddress.Value);
            var ConfirmHostReg = Server.Add(ConfirmServiceProvider);

            var AccountServiceProvider = new AccountLocalServiceProvider(
                        Options.ServiceAddress.Value);
            var AccountHostReg = Server.Add(AccountServiceProvider);

            var RecryptServiceProvider = new RecryptLocalServiceProvider(
                        Options.ServiceAddress.Value,
                        Options.Store.Value);
            var RecryptHostReg = Server.Add(RecryptServiceProvider);


            // Create the interface dispatcher for the provider.
            var Confirm = new ConfirmServiceLocal(ConfirmServiceProvider, null);
            var ConfirmInterfaceReg = ConfirmHostReg.Add(Confirm);

            // Create the interface dispatcher for the provider.
            var Account = new AccountServiceLocal(AccountServiceProvider, null);
            var AccountInterfaceReg = AccountHostReg.Add(Account);

            // Create the interface dispatcher for the provider.
            var Recrypt = new RecryptServiceLocal(RecryptServiceProvider, null);
            var RecryptInterfaceReg = RecryptHostReg.Add(Recrypt);


            // Register the network port.
            if (Options.HostAddress.Value != null) {
                ConfirmInterfaceReg.AddService(Options.HostAddress.Value);
                AccountInterfaceReg.AddService(Options.HostAddress.Value);
                RecryptInterfaceReg.AddService(Options.HostAddress.Value);
                }
            if (Options.Fallback.Value) {
                var FallbackConfirm = "Confirm." + Options.ServiceAddress.Value;
                ConfirmInterfaceReg.AddService(FallbackConfirm);
                var FallbackAccount = "Account." + Options.ServiceAddress.Value;
                AccountInterfaceReg.AddService(FallbackAccount);
                var FallbackRecrypt = "Recrypt." + Options.ServiceAddress.Value;
                RecryptInterfaceReg.AddService(FallbackRecrypt);
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
