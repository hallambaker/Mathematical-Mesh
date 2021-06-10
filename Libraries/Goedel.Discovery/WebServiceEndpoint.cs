using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
namespace Goedel.Discovery {

    /// <summary>
    /// Describes a service endpoint for HTTP and HTTPS transport.
    /// </summary>
    public class WebServiceEndpoint {

        static int port => 15099;

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
    }
