using System;
using System.Threading;
using System.Collections.Generic;

using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Presentation {





    /// <summary>
    /// Service provider class.
    /// </summary>
    public class RudProvider : Disposable {
        #region // Properties
        ///<summary>The provider interface.</summary> 
        public JpcInterface JpcInterface { get; }


        // The HTTP and UDP endpoints should be eliminated as a RUD service simply ignores the
        // source of received data.

        ///<summary>The HTTP endpoints.</summary> 
        public List<HttpEndpoint> HTTPEndpoints { get; } = new List<HttpEndpoint>();

        ///<summary>The UDP endpoints</summary> 
        public List<UdpEndpoint> UdpEndpoints { get; } = new List<UdpEndpoint>();
        #endregion
        #region // Constructor
        /// <summary>
        /// Constructor, returns an instance servicing the endpoints <paramref name="endpoints"/>
        /// </summary>
        /// <param name="endpoints">The endpoints to be serviced.</param>
        /// <param name="jpcProvider">The service provider.</param>
        public RudProvider(List<Endpoint> endpoints, JpcInterface jpcProvider) {
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

        /// <summary>
        /// Constructor, returns a provider of the service <paramref name="instance"/> offering
        /// the transports specified by <paramref name="presentationTypes"/> at the domain 
        /// <paramref name="domain"/>.
        /// </summary>
        /// <param name="jpcProvider">The provider instance.</param>
        /// <param name="presentationTypes">The presentations supported.</param>
        /// <param name="domain">The DNS domain.</param>
        /// <param name="instance">The instance specifier</param>
        public RudProvider(
                    JpcInterface jpcProvider, 
                    TransportType presentationTypes,
                    string domain, 
                    string instance = null) {
            JpcInterface = jpcProvider;
            if ((presentationTypes & TransportType.Http) > 0) {
                HTTPEndpoints.Add(new HttpEndpoint(domain, jpcProvider.GetWellKnown, instance));
                }
            if ((presentationTypes & TransportType.Udp) > 0) {
                UdpEndpoints.Add(new UdpEndpoint(domain, instance));
                }
            }

        #endregion

        }



    }
