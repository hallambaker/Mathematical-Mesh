using System;
using System.Threading;
using System.Collections.Generic;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {
    public class Provider : Disposable {

        public List<HttpEndpoint> HTTPEndpoints { get; } = new List<HttpEndpoint>();

        public List<UdpEndpoint> UdpEndpoints { get; } = new List<UdpEndpoint>();

        public Provider(List<Endpoint> endpoints) {
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
    }
