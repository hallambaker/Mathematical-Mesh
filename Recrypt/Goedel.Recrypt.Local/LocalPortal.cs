using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Protocol;
using Goedel.Recrypt;
using Goedel.Recrypt.Client;
using Goedel.Recrypt.Server;

namespace Goedel.Recrypt.Local
{
    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class RecryptLocalPortal : RecryptPortal {
        /// <summary>
        /// File name for local access to the portal store.
        /// </summary>
        protected string PortalStore = "portal.jlog";

        /// <summary>
        /// The service name (default to mesh.prismproof.org)
        /// </summary>
        protected string ServiceName = "mesh.prismproof.org";

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public PublicRecryptServiceProvider RecryptServiceHost;
        }




    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class RecryptPortalDirect : RecryptLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public RecryptPortalDirect() {
            Init(ServiceName, PortalStore);
            }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public RecryptPortalDirect(string ServiceName, string PortalStore) {
            Init(ServiceName, PortalStore);
            }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public RecryptPortalDirect(string PortalStore) {
            Init(ServiceName, PortalStore);
            }

        /// <summary>
        /// Initialize the portal
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <param name="MeshStore"></param>
        /// <param name="PortalStore"></param>
        protected void Init(string ServiceName, string PortalStore) {
            this.ServiceName = ServiceName;
            this.PortalStore = PortalStore;
            RecryptServiceHost = new PublicRecryptServiceProvider(ServiceName, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>

        public override RecryptService GetService(string Portal, string Account) {
            var Session = new DirectSession(null);
            MeshServiceClient = new PublicRecryptService(RecryptServiceHost, Session);
            return MeshServiceClient;
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
        public RecryptPortalLocal() {
            RecryptServiceHost = new PublicRecryptServiceProvider(ServiceName, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        public override RecryptService GetService(string Service, string Account) {
            var Session = new LocalRemoteSession(RecryptServiceHost, ServiceName, Account);
            MeshServiceClient = new RecryptServiceClient(Session);
            return MeshServiceClient;
            }

        }

    }
