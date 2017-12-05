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
using Goedel.Protocol.Exchange;

namespace Goedel.Protocol.Exchange {

    /// <summary>
    /// Abstract interface to a service that supports the KeyExchangePortal API calls.
    /// Mostly for useful in test code where the ability to switch between a
    /// direct and indirect portal connection is desirable. 
    /// </summary>
    public abstract class KeyExchangePortal {

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual KeyExchangeService GetService (string Portal) {
            return GetService(Portal, null);
            }

        /// <summary>
        /// Return a KeyExchangeService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract KeyExchangeService GetService (string Portal, string Account);

        private static KeyExchangePortal _Default;
        /// <summary>
        /// Specify the default portal. If not overriden, the default default is to
        /// make a remote connection.
        /// </summary>
        public static KeyExchangePortal Default {
            get {
                if (_Default == null) {
                    _Default = new KeyExchangePortalRemote();
                    }
                return _Default;
                }

            set {
                _Default = value;
                }
            }

        /// <summary>
        /// May be set to the default KeyExchangeService by a calling application.
        /// </summary>
        public KeyExchangeService KeyExchangeServiceClient;

        }

    /// <summary>
    /// Connection to network service using HTTP client.
    /// </summary>
    public class KeyExchangePortalRemote : KeyExchangePortal {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public KeyExchangePortalRemote () {

            }


        /// <summary>
        /// Return a KeyExchangeService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Domain">The DNS name of the service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override KeyExchangeService GetService (string Domain, string Account) {
            var Session = new WebRemoteSession(Domain, KeyExchangeService.WellKnown, Account);
            KeyExchangeServiceClient = new KeyExchangeServiceClient(Session);
            return KeyExchangeServiceClient;
            }
        }

    }
