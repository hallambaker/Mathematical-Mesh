////   Copyright © 2015 by Comodo Group Inc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  
////  

//using System;
//using System.Collections.Generic;
//using Goedel.Protocol;
//using Goedel.Protocol.Exchange;

//namespace Goedel.Protocol.Exchange.Server {


//    /// <summary>
//    /// Abstract interface to a local service provider.
//    /// </summary>
//    public abstract class KeyExchangeLocalPortal : KeyExchangePortal {

//        /// <summary>
//        /// The service name (default to keyexchange.prismproof.org)
//        /// </summary>
//        protected string ServiceName = "keyexchange.prismproof.org";

//        /// <summary>
//        /// The local PublicKeyExchange host.
//        /// </summary>
//        public PublicKeyExchangeServiceProvider KeyExchangeServiceHost;
//        }


//    /// <summary>
//    /// Direct connection to service provider via API calls. 
//    /// </summary>
//    public class KeyExchangePortalDirect : KeyExchangeLocalPortal {

//        /// <summary>
//        /// Create new portal using the default stores.
//        /// </summary>
//        public KeyExchangePortalDirect() => Init(ServiceName);

//        /// <summary>
//        /// Create a new portal using the specified stores.
//        /// </summary>
//        /// <param name="ServiceName">DNS service name</param>
//        public KeyExchangePortalDirect(string ServiceName) => Init(ServiceName);


//        /// <summary>
//        /// Initialize the portal
//        /// </summary>
//        /// <param name="ServiceName">DNS service name</param>
//        protected void Init (string ServiceName) {
//            this.ServiceName = ServiceName;
//            KeyExchangeServiceHost = new PublicKeyExchangeServiceProvider(ServiceName);
//            }

//        /// <summary>
//        /// Return a KeyExchangeService object for the named portal service.
//        /// </summary>
//        /// <param name="Account">The account to get.</param>
//        /// <param name="Portal">The portal to get the service from.</param>
//        /// <returns>The service instance</returns> 
//        public override KeyExchangeService GetService (string Portal, string Account) {
//            var Session = new DirectSession(null);
//            KeyExchangeServiceClient = new PublicKeyExchangeService(KeyExchangeServiceHost, Session);

//            return KeyExchangeServiceClient;
//            }

//        }






//    /// <summary>
//    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
//    /// Useful for producing documentation and for testing.
//    /// </summary>
//    public class KeyExchangePortalLocal : KeyExchangeLocalPortal {

//        /// <summary>
//        /// Create new portal using the default stores.
//        /// </summary>
//        public KeyExchangePortalLocal() => KeyExchangeServiceHost = new PublicKeyExchangeServiceProvider(ServiceName);

//        /// <summary>
//        /// Return a KeyExchangeService object for the named portal service.
//        /// </summary>
//        /// <param name="Account">The account to get.</param>
//        /// <param name="Service">The service to get the service from.</param> 
//        /// <returns>The service instance</returns>
//        public override KeyExchangeService GetService (string Service, string Account) {
//            var Session = new LocalRemoteSession(KeyExchangeServiceHost, ServiceName, Account);
//            KeyExchangeServiceClient = new KeyExchangeServiceClient(Session);
//            return KeyExchangeServiceClient;
//            }

//        }

//    }
