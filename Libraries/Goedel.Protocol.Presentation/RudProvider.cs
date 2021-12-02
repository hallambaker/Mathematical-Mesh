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

namespace Goedel.Protocol.Presentation;





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
    #region // Convenience Methods



    #endregion

    }
