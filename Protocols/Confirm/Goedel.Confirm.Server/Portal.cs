//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Goedel.Recrypt;
//using Goedel.Protocol;
//using Goedel.Protocol.Framework;

//namespace Goedel.Confirm.Server {


//    /// <summary>
//    /// Abstract interface to a local service provider.
//    /// </summary>
//    public abstract class RecryptLocalPortal : ConfirmPortal {
//        public string ServiceName { get; set; }

//        /// <summary>
//        /// The local PublicMeshServiceHost.
//        /// </summary>
//        public ConfirmLocalServiceProvider HostProvider;
//        }


//    /// <summary>
//    /// Direct connection to service provider via API calls. 
//    /// </summary>
//    public class ConfirmPortalDirect : RecryptLocalPortal {

//        /// <summary>
//        /// Create new portal using the default stores.
//        /// </summary>
//        public ConfirmPortalDirect (string Store=null) {
//            HostProvider = new ConfirmLocalServiceProvider(ServiceName, Store);
//            }


//        /// <summary>
//        /// Return a MeshService object for the named portal service.
//        /// </summary>
//        /// <param name="Account">The account to get.</param>
//        /// <param name="Portal">The portal to get the service from.</param>
//        /// <returns>The service instance</returns> 
//        public override ConfirmService GetService (string Portal, string Account) {
//            var Session = new DirectSession(null);
//            ServiceClient = new ConfirmServiceLocal(HostProvider, Session);
//            return ServiceClient;
//            }

//        }






//    /// <summary>
//    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
//    /// Useful for producing documentation and for testing.
//    /// </summary>
//    public class RecryptPortalLocal : RecryptLocalPortal {

//        /// <summary>
//        /// Create new portal using the default stores.
//        /// </summary>
//        public RecryptPortalLocal (string ServiceName) {
//            this.ServiceName = ServiceName;
//            HostProvider = new ConfirmLocalServiceProvider(ServiceName);
//            }

//        /// <summary>
//        /// Return a MeshService object for the named portal service.
//        /// </summary>
//        /// <param name="Account">The account to get.</param>
//        /// <param name="Service">The service to get the service from.</param> 
//        /// <returns>The service instance</returns>
//        public override ConfirmService GetService (string Service, string Account) {
//            var Session = new LocalRemoteSession(HostProvider, ServiceName, Account);
//            ServiceClient = new ConfirmServiceClient(Session);
//            return ServiceClient;
//            }

//        }
//    }
