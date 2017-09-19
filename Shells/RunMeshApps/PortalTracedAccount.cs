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
using System.Text;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Protocol.Debug;

namespace Goedel.Account.Server {
    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class AccountPortalTraced : AccountPortalDirect {
        /// <summary>
        /// the set of traces for this service
        /// </summary>
        public TraceDictionary Traces { get; set; }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public AccountPortalTraced (string ServiceName, string MeshStore, string PortalStore) {
            var URI = JPCProvider.WellKnownToURI(ServiceName, AccountService.WellKnown,
                        AccountService.Discovery, false, true);

            var ParsedURI = new Uri(URI);
            Traces = new TraceDictionary(ServiceName, ParsedURI.PathAndQuery);
            }

        DebugLocalSession Session;

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override AccountService GetService (string Service, string Account) {
            Session = new DebugLocalSession(AccountServiceHost, ServiceName, Account) {
                Traces = Traces
                };

            AccountServiceClient = new AccountServiceClient(Session);

            // Create a new dispatch client
            AccountServiceHost.Service = new AccountServiceLocal(AccountServiceHost, Session);

            return AccountServiceClient;
            }



        /// <summary>
        /// Label the following interactions
        /// </summary>
        /// <param name="Name">The label name to use</param>
        /// <param name="Command">Optional command value</param>
        /// <returns>The trace point marker created</returns>
        public TracePoint Label (string Name, string Command = null) => Traces.Label(Name, Command);


        }

 
    }
