using System;
using System.Threading;
using System.Net.Sockets;
using Goedel.Protocol;
using Goedel.Discovery;
using Goedel.Utilities;
using Goedel.Cryptography;

namespace Goedel.Protocol.Service {

#pragma warning disable CS1591
#pragma warning disable CS1572
#pragma warning disable CS1573

    /// <summary>
    /// Record describing a listener endpoint.
    /// </summary>
    /// <param name="Protocol">Directory to store persistence data.</param>
    public record Endpoint(
             string Protocol,
             string Instance = null) {




        }

    public record HttpEndpoint(
             string Domain,
             string Protocol,
             string Instance = null) : Endpoint (Protocol, Instance) {

        public string Account(string username) => $"{username}@{Domain}";

        public static string Specializer(string instance) => instance == null ? "" : $"{instance}/";

        public string GetUri() => GetUri("+", Protocol, Instance);  

        public static string GetUri(string domain, string protocol, string instance) =>
            $"http://{domain}:15099/.well-known/{protocol}/{Specializer(instance)}";

        // used for testing.
        public string GetServiceUri() => WebServiceEndpoint.GetEndpoint(Domain, Protocol, null, Instance);
            
            
            //$"http://voodoo.hallambaker.com:15099/.well-known/{Protocol}{specializer}/";
        }


    public record UdpEndpoint (
             string Protocol,
             string Instance = null,
             int Port = 0,
             AddressFamily AddressFamily= AddressFamily.InterNetwork) : Endpoint (Protocol, Instance) {


        public UdpClient GetClient() {
            if (Port > 0) {
                return new UdpClient(Port, AddressFamily);
                }

            try {
                // attempt to allocate a randomly allocated port
                var port = Goedel.Cryptography.Platform.GetRandomPort();
                var udpClient = new UdpClient(port, AddressFamily);
                return udpClient;
                }
            catch {
                // port was already allocated, take a default port off the system.
                return new UdpClient(AddressFamily);
                }



            }


        }



    }
