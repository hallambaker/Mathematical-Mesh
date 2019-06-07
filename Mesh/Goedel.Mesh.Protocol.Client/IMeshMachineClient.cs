using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using System.IO;

namespace Goedel.Mesh.Client {
    public interface IMeshMachineClient : IMeshMachine {
        ///<summary>Direct access to the Catalog, should remove this</summary>
        CatalogHost CatalogHost { get; }

        /// <summary>
        /// Return an administration profile with local name <paramref name="local"/>.
        /// </summary>
        /// <param name="local">The profile to return.</param>
        /// <returns>The entry for the specified profile.</returns>
       Connection GetConnection(string local = null);

        /// <summary>
        /// Return an pending connection request with local name <paramref name="local"/>.
        /// </summary>
        /// <param name="local">The profile to return.</param>
        /// <returns>The entry for the specified profile.</returns>
        PendingConnection GetPending(string local = null);

        /// <summary>
        /// Register <paramref name="profileEntry"/> in the persistence store. An error is
        /// reported if the entry does not exist and the <paramref name="create"/> is true.
        /// </summary>
        /// <param name="profileEntry">The entry to add or update.</param>
        /// <param name="create">Report an error if the object identifier does not already exist.</param>
        void Register(Connection profileEntry, bool create=true);

        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="serviceID"/>
        /// using the authentication key <paramref name="keyAuthentication"/> and credential
        /// <paramref name="assertionAccountConnection"/>. 
        /// </summary>
        /// <param name="serviceID">The service identifier to connect to.</param>
        /// <param name="keyAuthentication">The private key to be used for authentication
        /// (encryption).</param>
        /// <param name="assertionAccountConnection">The credential binding the device
        /// to the account.</param>
        /// <param name="profileMaster">The master profile. This is required when requesting
        /// an inbound connection or requesting that a new account be created and optional
        /// otherwise.</param>
        /// <returns></returns>
        MeshService GetMeshClient(
                string serviceID,
            KeyPair keyAuthentication,
            AssertionAccountConnection assertionAccountConnection,
            ProfileMaster profileMaster = null);

        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        ContextMesh GetContextMesh(string localName = null, bool admin = true);


        }
    }
