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
using Goedel.Recrypt;

namespace Goedel.Recrypt.Client {

    /// <summary>
    /// Abstract interface to a service that supports the Recrypt API calls.
    /// Mostly for useful in test code where the ability to switch between a
    /// direct and indirect portal connection is desirable. 
    /// </summary>
    public abstract class RecryptPortal {

        /// <summary>
        /// Return a RecryptService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual RecryptService GetService(string Portal) {
            return GetService(Portal, null);
            }

        /// <summary>
        /// Return a RecryptService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract RecryptService GetService(string Portal, string Account);

        private static RecryptPortal _Default;
        /// <summary>
        /// Specify the default portal. If not overriden, the default default is to
        /// make a remote connection.
        /// </summary>
        public static RecryptPortal Default {
            get {
                if (_Default == null) {
                    _Default = new MeshPortalRemote();
                    }
                return _Default;
                }

            set {
                _Default = value;
                }
            }

        /// <summary>
        /// May be set to the default RecryptService by a calling application.
        /// </summary>
        public RecryptService MeshServiceClient;

        }





    /// <summary>
    /// Connection to network service using HTTP client.
    /// </summary>
    public class MeshPortalRemote : RecryptPortal {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MeshPortalRemote () {

            }


        /// <summary>
        /// Return a RecryptService object for the named portal service.
        /// </summary>
        public override RecryptService GetService(string Service, string Account) {
            var URI = JPCProvider.WellKnownToURI(Service, RecryptService.WellKnown,
                        RecryptService.Discovery, false, true);

            var Session = new WebRemoteSession(URI, Service, Account);
            MeshServiceClient = new RecryptServiceClient(Session);
            return MeshServiceClient;
            }
        }

    }
