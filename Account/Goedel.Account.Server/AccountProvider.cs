using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Account;
using Goedel.Protocol;

namespace Goedel.Account.Server {
    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class AccountLocalServiceProvider : AccountServiceProvider {
        public AccountStore AccountStore;
        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="MeshStore">The mesh persistence store filename.</param>
        /// <param name="PortalStore">The portal persistence store fielname.</param>
        public AccountLocalServiceProvider (string Domain, string Store = "Account.jlog") {
            AccountStore = new AccountStore(Domain, Store);
            }




        }
    }
