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



using System.Net;

namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// DNS configuration generator class
/// </summary>
public partial class DnsConfiguration {
    #region // Properties
    #endregion

    #region // Destructor
    #endregion

    #region // Constructors
    #endregion

    #region // Implement Interface: Ixxx
    #endregion

    #region // Methods 

    /// <summary>
    /// Generate a BIND configuration file for the service config.
    /// </summary>
    /// <param name="Configuration"></param>
    /// <param name="output"></param>
    /// <param name="hostname">The host name.</param>
    public static void BindConfig(Configuration Configuration,
                string output, string hostname) {
        using var outputWriter = output.OpenTextWriterNew();
        var dnsConfiguration = new DnsConfiguration() {
            _Output = outputWriter
            };
        dnsConfiguration.BindConfig(Configuration);
        }

    /// <summary>
    /// Returns the port component of the IP address <paramref name="address"/>
    /// </summary>
    /// <param name="address">The IP address to return the port component from.</param>
    /// <returns>The port component</returns>
    public static string GetPort(string address) {

        if (IPEndPoint.TryParse(address, out var endpoint)) {
            return endpoint.Port.ToString();
            }
        return null;
        }

    /// <summary>
    /// Returns the address component of the IP address <paramref name="address"/>
    /// </summary>
    /// <param name="address">The IP address to return the address component from.</param>
    /// <returns>The address component</returns>
    public static string GetAddress(string address) {

        if (IPEndPoint.TryParse(address, out var endpoint)) {
            return endpoint.Address.ToString();
            }
        return null;
        }

    /// <summary>
    /// Returns the address component of the IP address  <paramref name="address"/> 
    /// prefixed by A for IPV4 addresses and AAAA for IPv6 addresses
    /// </summary>
    /// <param name="address">The IP address to return the port component from.</param>
    /// <returns>The port component</returns>
    public static string GetAQuadA(string address) {
        if (IPEndPoint.TryParse(address, out var endpoint)) {
            switch (endpoint.Address.AddressFamily) {
                case System.Net.Sockets.AddressFamily.InterNetworkV6: {
                        return $"AAAA {endpoint.Address}";
                        }
                case System.Net.Sockets.AddressFamily.InterNetwork: {
                        return $"A {endpoint.Address}";
                        }
                }

            return endpoint.Address.ToString();
            }
        return null;

        }


    #endregion
    }
