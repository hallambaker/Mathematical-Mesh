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
        
        /// <summary>The persistence store.</summary>
        public AccountStore AccountStore;

        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="Store">The  persistence store filename.</param>
        public AccountLocalServiceProvider(string Domain, string Store = "Account.jlog") => AccountStore = new AccountStore(Domain, Store);




        }
    }
