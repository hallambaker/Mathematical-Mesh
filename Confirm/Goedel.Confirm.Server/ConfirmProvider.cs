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
        public ConfirmStore ConfirmStore { get; }

        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="MeshStore">The mesh persistence store filename.</param>
        /// <param name="PortalStore">The portal persistence store fielname.</param>
        public ConfirmLocalServiceProvider (string Domain, string Store="Confirm.jlog") {
            ConfirmStore = new ConfirmStore(Domain, Store);
            }
        }



    }

