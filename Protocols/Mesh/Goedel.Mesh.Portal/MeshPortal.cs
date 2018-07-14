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
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Utilities;

namespace Goedel.Mesh.Portal {

    /// <summary>
    /// Abstract interface to a service that supports the MeshPortal API calls.
    /// Mostly for useful in test code where the ability to switch between a
    /// direct and indirect portal connection is desirable. 
    /// </summary>
    public abstract class MeshPortal {

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Address">Portal account address or domain name</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual MeshService GetService(string Address) {
            Address.SplitAccountIDService(out var Service, out var Account);
            return GetService(Service, Account);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Service">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract MeshService GetService(string Service, string Account);

        private static MeshPortal _Default;
        /// <summary>
        /// Specify the default portal. If not overriden, the default default is to
        /// make a remote connection.
        /// </summary>
        public static MeshPortal Default {
            get {
                if (_Default == null) {
                    _Default = new MeshPortalRemote();
                    }
                return _Default;
                }

            set => _Default = value;
            }

        /// <summary>
        /// May be set to the default MeshService by a calling application.
        /// </summary>
        public MeshService MeshServiceClient;

        }


    /// <summary>
    /// Connection to network service using HTTP client.
    /// </summary>
    public class MeshPortalRemote : MeshPortal {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MeshPortalRemote () {

            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Domain">The DNS name of the service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override MeshService GetService(string Domain, string Account) {
            //var URI = JPCProvider.WellKnownToURI(Service, MeshService.WellKnown, 
            //            MeshService.Discovery, false, true);

            //var Session = new WebRemoteSession(URI, Service, Account);

            var Session = new WebRemoteSession(Domain, MeshService.WellKnown, Account);
            MeshServiceClient = new MeshServiceClient(Session);
            return MeshServiceClient;
            }
        }

    }
