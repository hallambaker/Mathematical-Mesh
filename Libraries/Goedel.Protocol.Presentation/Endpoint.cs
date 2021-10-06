#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;
using System.Net.Sockets;

using Goedel.Discovery;

namespace Goedel.Protocol.Presentation {

#pragma warning disable CS1591
#pragma warning disable CS1572
#pragma warning disable CS1573

    [Flags]
    public enum TransportType {

        ///<summary>HTTP/Fred binding.</summary> 
        Http = 0b001,

        ///<summary>UDP/Fred binding.</summary> 
        Udp = 0b010,


        ///<summary>All supported provider types.</summary> 
        All = Http | Udp,

        ///<summary>Direct connection for testing.</summary> 
        Direct = 0b1000000

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

        public static string Specializer(string instance) => instance == null ? "" : $"{instance}/";

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
