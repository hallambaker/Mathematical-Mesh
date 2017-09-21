using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;

namespace Goedel.Recrypt.Server {
    /// <summary>
    /// The host class. Receives a stream from the HTTP server caller and 
    /// dispatches the specified server.
    /// </summary>
    public class RecryptLocalServiceProvider : RecryptServiceProvider {

        /// <summary>The recryption service store.</summary>
        public RecryptStore RecryptStore { get; }
        /// <summary>
        /// Initialize a Mesh Service Provider.
        /// </summary>
        /// <param name="Domain">The domain of the service provider.</param>
        /// <param name="Store">The persistence store filename.</param>
        public RecryptLocalServiceProvider (string Domain, string Store="Recrypt.jlog") {
            RecryptStore = new RecryptStore(Domain, Store);
            }
        }

    }

