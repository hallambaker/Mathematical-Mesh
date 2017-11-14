using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Confirm;
using Goedel.Protocol;

namespace Goedel.Confirm.Server {


    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class ConfirmLocalPortal : ConfirmPortal {

        /// <summary>The service name.</summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public ConfirmLocalServiceProvider ConfirmServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class ConfirmPortalDirect : ConfirmLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public ConfirmPortalDirect (string ServiceName = null, string Store = "Confirm.jlog") {
            ConfirmServiceHost = new ConfirmLocalServiceProvider(ServiceName, Store);
            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Portal">The portal to get the service from.</param>
        /// <returns>The service instance</returns> 
        public override ConfirmService GetService (string Portal, string Account) {
            var Session = new DirectSession(null);
            ConfirmServiceClient = new ConfirmServiceLocal(ConfirmServiceHost, Session);
            return ConfirmServiceClient;
            }

        }






    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class ConfirmPortalLocal : ConfirmLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        /// <param name="ServiceName">The service name</param>
        public ConfirmPortalLocal (string ServiceName) {
            this.ServiceName = ServiceName;
            ConfirmServiceHost = new ConfirmLocalServiceProvider(ServiceName);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override ConfirmService GetService (string Service, string Account) {
            var Session = new LocalRemoteSession(ConfirmServiceHost, ServiceName, Account);
            ConfirmServiceClient = new ConfirmServiceClient(Session);
            return ConfirmServiceClient;
            }

        }
    }
