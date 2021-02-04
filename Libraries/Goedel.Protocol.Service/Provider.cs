using System;
using System.Threading;
using System.Collections.Generic;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {
    
    /// <summary>
    /// Service provider class.
    /// </summary>
    public class Provider : Disposable {

        public JpcInterface JpcInterface { get; }

        ///<summary>The HTTP endpoints.</summary> 
        public List<HttpEndpoint> HTTPEndpoints { get; } = new List<HttpEndpoint>();

        ///<summary>The UDP endpoints</summary> 
        public List<UdpEndpoint> UdpEndpoints { get; } = new List<UdpEndpoint>();

        /// <summary>
        /// Constructor, returns an instance servicing the endpoints <paramref name="endpoints"/>
        /// </summary>
        /// <param name="endpoints">The endpoints to be serviced.</param>
        public Provider(List<Endpoint> endpoints, JpcInterface jpcProvider) {
            JpcInterface = jpcProvider;

            foreach (var endpoint in endpoints) {
                switch (endpoint) {
                    case HttpEndpoint httpEndpoint: {
                        HTTPEndpoints.Add(httpEndpoint);
                        break;
                        }
                    case UdpEndpoint udpEndpoint: {
                        UdpEndpoints.Add(udpEndpoint);
                        break;
                        }
                    }
                }
            }

        }


    //public class MonitorProvider : Provider {
    //    public Monitor Monitor { get; set; }
    //    public MonitorProvider(List<Endpoint> endpoints, JPCProvider jpcProvider) {
    //        }

    //    }


    }
