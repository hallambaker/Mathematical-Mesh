//  Copyright © 2020 Threshold Secrets llc
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




using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Numerics;
using System.Collections.Generic;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class MeshService {



        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="accountAddress">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public static MeshService GetService(string accountAddress) {
            accountAddress.SplitAccountIDService(out var service, out var account);
            return GetService(service, account);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="account">The account to get.</param>
        /// <param name="domain">The DNS name of the service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public static MeshService GetService(string domain, string account) {
            //var URI = JPCProvider.WellKnownToURI(Service, MeshService.WellKnown, 
            //            MeshService.Discovery, false, true);

            //var Session = new WebRemoteSession(URI, Service, Account);

            var session = new WebRemoteSession(domain, MeshService.WellKnown, account);
            var MeshServiceClient = new MeshServiceClient() {
                JpcSession = session};
            return MeshServiceClient;
            }

        }


    }
