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

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh {



    //public delegate MeshPortal GetPortalDelegate(string serviceName, string directory = null);



    /// <summary>
    /// Describes a single instance of a named Mesh Service provider. 
    /// <para>
    /// In production use,
    /// a MeshPortalRemote connects to an Internet service with the specified name and all
    /// clients that connect to the same DNS service name will connect to the same 
    /// Internet service regardless of which portal is used.</para>
    /// <para>For test purposes a MeshLocalPortal connects to a local service provider
    /// either calling the dispatch methods directly (MeshPortalDirect) or
    /// using the wire encoding format to allow parameter serialization and deserialization 
    /// to be tested (MeshPortalLocal). In this configuration, calls to different
    /// MeshPortal instances result in dispatch to different Mesh services.</para>
    /// </summary>
    public abstract class MeshPortal {


        //public static GetPortalDelegate GetPortal;

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="serviceID">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract MeshService GetService(string serviceID);


        /// <summary>
        /// May be set to the default MeshService by a calling application.
        /// </summary>
        public MeshService MeshServiceClient { get; set; }

        }



    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class MeshService {



        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="serviceID">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public static MeshService GetService(string serviceID) {
            serviceID.SplitAccountIDService(out var service, out var account);
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

            var Session = new WebRemoteSession(domain, MeshService.WellKnown, account);
            var MeshServiceClient = new MeshServiceClient(Session);
            return MeshServiceClient;
            }
        }


    }
