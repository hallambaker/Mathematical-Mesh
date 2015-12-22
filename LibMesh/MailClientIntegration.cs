//Sample license text.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {

    /// <summary>
    /// Base class for Mail Client integration classes.
    /// </summary>
    public abstract class IntegratorMailClient {

        /// <summary>
        /// The catalog to connect to.
        /// </summary>
        public MailClientCatalog Catalog;

        /// <summary>
        /// Enumerate the accounts supported by the client.
        /// </summary>
        public abstract void EnumerateAccounts();
        }

    }
