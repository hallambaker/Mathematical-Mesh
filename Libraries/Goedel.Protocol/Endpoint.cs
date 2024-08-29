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
using Goedel.Discovery;

using System.Net.Sockets;

namespace Goedel.Protocol;

//#pragma warning disable CS1591
//#pragma warning disable CS1573


/// <summary>
/// Transport types
/// </summary>
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
/// <param name="Instance">Optional instance tag to allow multiple instances to be run 
/// for testing etc.</param>
/// <param name="JpcInterface">The service provider.</param>
public record Endpoint(
         string? Protocol,
         string? Instance = null,
         JpcInterface JpcInterface = null) {




    }

/// <summary>
/// A HTTP Endpoint
/// </summary>
/// <param name="Domain">The DNS address specified in the original HTTP URI</param>
/// <param name="Protocol">The protocol serviced.</param>
/// <param name="Instance">The protocol instance.</param>
/// <param name="Port">The port number.</param>
/// <param name="JpcInterface">The service provider.</param>
public record HttpEndpoint(
         string? Domain,
         string Protocol,
         int Port,
         string? Instance = null,
         JpcInterface JpcInterface = null) : Endpoint(Protocol, Instance, JpcInterface) {
    #region // Properties
    #endregion
    #region // Methods 



    /// <summary>
    /// Return the specializer path element, if used.
    /// </summary>
    /// <param name="instance">The instance values.</param>
    /// <returns>The specializer path.</returns>
    public static string Specializer(string instance) => instance == null ? "" : $"{instance}/";

    //public string GetUri() => GetUri(, Port, Protocol, Instance);



    /// <summary>
    /// Return the URI for the endpoint.
    /// </summary>
    /// <param name="domain">The DNS address specified in the original HTTP URI</param>
    /// <param name="protocol">The protocol serviced.</param>
    /// <param name="instance">The protocol instance.</param>
    /// <param name="port">The port number.</param>
    /// <returns>the URI for the endpoint.</returns>
    public static string GetUri(string domain, int port, string protocol, string instance) =>
        GetUriBase(domain, port, protocol, instance);

    /// <summary>
    /// Return the URI base for the specified parameters
    /// </summary>
    /// <param name="domain">The DNS address specified in the original HTTP URI</param>
    /// <param name="protocol">The protocol serviced.</param>
    /// <param name="instance">The protocol instance.</param>
    /// <param name="port">The port number.</param>>
    /// <returns>the URI base</returns>
    static string GetUriBase(string domain, int port, string protocol, string instance) =>
        $"http://{domain}:{port}/.well-known/{protocol}/{Specializer(instance)}";


    /// <summary>
    /// Return the URI prefix for the endpoint.
    /// </summary>
    /// <returns>the URI prefix for the endpoint.</returns>
    public string GetUriPrefix() => GetUriBase("+", Port, Protocol, Instance);

    /// <summary>
    /// Return the service URI for the endpoint.
    /// </summary>
    /// <returns>The service URI.</returns>
    public string GetServiceUri() => WebServiceEndpoint.GetEndpoint(Domain, Protocol, null, Instance);

    #endregion
    }

/// <summary>
/// A UDP endpoint.
/// </summary>
/// <param name="Protocol">The protocol serviced.</param>
/// <param name="Instance">The protocol instance.</param>
/// <param name="Port">The port number.</param>
/// <param name="AddressFamily">The address family.</param>
/// <param name="JpcInterface">The service provider.</param>
public record UdpEndpoint(
         string? Protocol,
         string? Instance = null,
         int Port = 0,
         AddressFamily AddressFamily = AddressFamily.InterNetwork,
         JpcInterface JpcInterface = null) : Endpoint(Protocol, Instance, JpcInterface) {
    #region // Methods 

    /// <summary>
    /// Return a ned UDP client bound to the endpoint as a promiscuous listener.
    /// </summary>
    /// <returns>The port created.</returns>
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
