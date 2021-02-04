using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
namespace Goedel.Discovery {
    public class WebServiceEndpoint {

        static int Port => 15099;

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
