using System.Net.Sockets;

using Goedel.Discovery;

namespace Goedel.Protocol.Presentation {

#pragma warning disable CS1591
#pragma warning disable CS1572
#pragma warning disable CS1573


    public enum TransportType {

        ///<summary>HTTP/Fred binding.</summary> 
        Http = 0b001,

        ///<summary>UDP/Fred binding.</summary> 
        Udp = 0b010,


        ///<summary>All supported provider types.</summary> 
        All = Http | Udp

        }


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
             string Instance = null,
             int Port = 15099) : Endpoint(Protocol, Instance) {
        #region // Properties
        #endregion
        #region // Methods 

        public string Account(string username) => $"{username}@{Domain}";

        public static string Specializer(string instance) => ""; //instance == null ? "" : $"{instance}/";

        //public string GetUri() => GetUri(, Port, Protocol, Instance);


        public string GetUriPrefix() => GetUriBase("+", Port, Protocol, Instance);

        public static string GetUri(string domain, int port, string protocol, string instance) =>
            GetUriBase("voodoo", port, protocol, instance);

        static string GetUriBase(string domain, int port, string protocol, string instance) =>
            $"http://{domain}:{port}/.well-known/{protocol}/{Specializer(instance)}";




        // used for testing.
        public string GetServiceUri() => WebServiceEndpoint.GetEndpoint(Domain, Protocol, null, Instance);

        #endregion
        }


    public record UdpEndpoint(
             string Protocol,
             string Instance = null,
             int Port = 0,
             AddressFamily AddressFamily = AddressFamily.InterNetwork) : Endpoint(Protocol, Instance) {
        #region // Methods 

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

        #endregion
        }



    }
