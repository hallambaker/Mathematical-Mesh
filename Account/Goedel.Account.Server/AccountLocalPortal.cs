using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Account;
using Goedel.Protocol;

namespace Goedel.Account.Server {


    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class AccountLocalPortal : AccountPortal {
        public string ServiceName { get; set; }

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public AccountLocalServiceProvider AccountServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class AccountPortalDirect : AccountLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public AccountPortalDirect () {
            AccountServiceHost = new AccountLocalServiceProvider(ServiceName);
            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Portal">The portal to get the service from.</param>
        /// <returns>The service instance</returns> 
        public override AccountService GetService (string Portal, string Account) {
            var Session = new DirectSession(null);
            AccountServiceClient = new AccountServiceLocal(AccountServiceHost, Session);
            return AccountServiceClient;
            }

        }






    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class AccountPortalLocal : AccountLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public AccountPortalLocal (string ServiceName) {
            this.ServiceName = ServiceName;
            AccountServiceHost = new AccountLocalServiceProvider(ServiceName);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override AccountService GetService (string Service, string Account) {
            var Session = new LocalRemoteSession(AccountServiceHost, ServiceName, Account);
            AccountServiceClient = new AccountServiceClient(Session);
            return AccountServiceClient;
            }

        }
    }
