using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh.Client {
    public interface IMeshMachineClient : IMeshMachine {
        ///<summary>Direct access to the Catalog, should remove this</summary>
        CatalogHost CatalogHost { get; }

        /// <summary>
        /// Return an administration profile with local name <paramref name="local"/>.
        /// </summary>
        /// <param name="local">The profile to return.</param>
        /// <returns>The entry for the specified profile.</returns>
        AdminEntry GetAdmin(string local = null);

        /// <summary>
        /// Return an account profile with local name <paramref name="local"/>.
        /// </summary>
        /// <param name="local">The profile to return.</param>
        /// <returns>The entry for the specified profile.</returns>
        AccountEntry GetAccount(string local = null);

        /// <summary>
        /// Return an pending connection request with local name <paramref name="local"/>.
        /// </summary>
        /// <param name="local">The profile to return.</param>
        /// <returns>The entry for the specified profile.</returns>
        PendingEntry GetPending(string local = null);
        }
    }
