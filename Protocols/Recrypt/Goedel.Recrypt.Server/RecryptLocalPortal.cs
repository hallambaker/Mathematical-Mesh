using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Recrypt;
using Goedel.Protocol;

namespace Goedel.Recrypt.Server {


    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class RecryptLocalPortal : RecryptPortal {

        /// <summary>The service name</summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public RecryptLocalServiceProvider RecryptServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class RecryptPortalDirect : RecryptLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        /// <param name="ServiceName">The canonical service name</param>
        /// <param name="Store">The file to store the account data to</param>
        public RecryptPortalDirect (string ServiceName, string Store = "Recrypt.jlog") {
            RecryptServiceHost = new RecryptLocalServiceProvider(ServiceName, Store);
            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Portal">The portal to get the service from.</param>
        /// <returns>The service instance</returns> 
        public override RecryptService GetService (string Portal, string Account) {
            var Session = new DirectSession(null);
            RecryptServiceClient = new RecryptServiceLocal(RecryptServiceHost, Session);
            return RecryptServiceClient;
            }

        }






    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class RecryptPortalLocal : RecryptLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        /// <param name="ServiceName">The service name</param>
        public RecryptPortalLocal (string ServiceName) {
            this.ServiceName = ServiceName;
            RecryptServiceHost = new RecryptLocalServiceProvider(ServiceName);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override RecryptService GetService (string Service, string Account) {
            var Session = new LocalRemoteSession(RecryptServiceHost, ServiceName, Account);
            RecryptServiceClient = new RecryptServiceClient(Session);
            return RecryptServiceClient;
            }

        }
    }
