using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Recrypt.Server;
using Goedel.Protocol;
using Goedel.Protocol.Debug;

namespace Goedel.Recrypt.Documentation {

    public class RecryptPortalTraced : RecryptPortalDirect {
        /// <summary>
        /// The set of traces for this service
        /// </summary>
        public TraceDictionary Traces { get; set; }


        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public RecryptPortalTraced (string ServiceName = "prismproof.org") {
            var URI = JPCProvider.WellKnownToURI(ServiceName, RecryptService.WellKnown,
                        RecryptService.Discovery, false, true);

            var ParsedURI = new Uri(URI);
            Traces = new TraceDictionary(ServiceName, ParsedURI.PathAndQuery);
            }

        DebugLocalSession Session;

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override RecryptService GetService (string Service, string Account) {
            Session = new DebugLocalSession(RecryptServiceHost, ServiceName, Account) {
                Traces = Traces
                };

            RecryptServiceClient = new RecryptServiceClient(Session);

            // Create a new dispatch client
            RecryptServiceHost.Service = new RecryptServiceLocal(RecryptServiceHost, Session);

            return RecryptServiceClient;
            }




        /// <summary>
        /// Label the following interactions
        /// </summary>
        /// <param name="Name">The label name to use</param>
        /// <returns>The trace point marker created</returns>
        public TracePoint Label (string Name) {
            return Traces.Label(Name);
            }

        }

    }

