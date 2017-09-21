using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;

namespace Goedel.Confirm.Server {
    /// <summary>
    /// The service provider class, exposes the persistent state.
    /// </summary>
    public class ConfirmLocalServiceProvider : ConfirmServiceProvider {

        /// <summary>The confirmation persistence store.</summary>
        public ConfirmStore ConfirmStore { get; }

        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="Store">The persistence store filename.</param>
        public ConfirmLocalServiceProvider (string Domain, string Store="Confirm.jlog") {
            ConfirmStore = new ConfirmStore(Domain, Store);
            }
        }



    }

