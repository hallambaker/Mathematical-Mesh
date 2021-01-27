using System;
using System.Threading;
using System.Net.Sockets;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;

namespace Goedel.Protocol.Service {

    public record Endpoint(
             string Protocol,
             int Instance = -1) {




        }

    public record HttpEndpoint(
             string Domain,
             string Protocol,
                int Instance = -1) : Endpoint (Protocol, Instance) {

        public string Account(string username) => $"{username}@{Domain}";

        string specializer = Instance > 0 ? $"/{Instance}" : "";
        public string Uri() =>  $"http://+:15099/.well-known/{Protocol}{specializer}/";
        public string ServiceUri() => $"http://voodoo.hallambaker.com:15099/.well-known/{Protocol}{specializer}/";
        }


    public record UdpEndpoint (
             string Protocol,
             int Instance = -1,
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
