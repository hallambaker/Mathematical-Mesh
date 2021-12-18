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

namespace Goedel.Discovery;

/// <summary>
/// Describes a service endpoint for HTTP and HTTPS transport.
/// </summary>
public class WebServiceEndpoint {


    /// <summary>
    /// Return a host endpoint to allow a client to access the service <paramref name="srv"/>
    /// at domain <paramref name="domain"/>.
    /// </summary>
    /// <param name="domain">Service name.</param>
    /// <param name="wellKnown">Protocol identifier.</param>
    /// <param name="srv">DNS protocol identifier.</param>
    /// <param name="instance">Optional instance used to identify a sepcific instance
    /// of the service on a host.</param>
    /// <returns>The service endpoint.</returns>
    public static string GetEndpoint(
                string domain,

                string wellKnown,
                string srv = null,
                string instance = null) {

        // do the SRV record lookup here
        domain.Future();
        srv ??= $"_{wellKnown}._tcp";
        srv.Future();

        var host = "voodoo.hallambaker.com";


        // form the HTTP uri
        var specializer = instance == null ? "" : $"/{instance}";

        return $"http://{host}:15099/.well-known/{wellKnown}{specializer}/";
        }



    }
