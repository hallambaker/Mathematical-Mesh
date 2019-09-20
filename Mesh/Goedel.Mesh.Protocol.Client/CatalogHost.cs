using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {






    /// <summary>
    /// Managfes the host catalog, i.e. the catalog of Meshes that the device is 
    /// connected to.
    /// </summary>
    public class HostMesh : Disposable {

        #region // fields and properties
        IMeshMachine meshMachine;
        CatalogHost containerProfile;
        
        ///<summary>The Key Collection of the Mesh Machine.</summary>
        public KeyCollection KeyCollection => meshMachine.KeyCollection;
        #endregion
        #region // Boilerplate for disposal etc.
        ///<summary>Disposal routine.</summary>
        protected override void Disposing() => containerProfile.Dispose();
        #endregion
        #region // Constructors and factories

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine">The Mesh Machine.</param>
        /// <param name="containerHost">The host catalog.</param>
        public HostMesh(CatalogHost containerHost, IMeshMachine meshMachine) {
            this.meshMachine = meshMachine;
            containerProfile = containerHost;
            }

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static HostMesh GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.CatalogHost;

            }

        #endregion
        #region // Convenience Methods

        /// <summary>
        /// Convenience routine to return a host description of a mesh connection.
        /// </summary>
        /// <param name="id">The mesh short name or master profile UDF.</param>
        /// <returns>The mesh host description (if found)</returns>
        public CatalogedMachine GetMeshConnection(string id = null) => 
                containerProfile.GetConnection(id);

        /// <summary>
        /// Convenience routine to return a host description of a pending mesh connection request.
        /// </summary>
        /// <param name="id">The mesh short name or master profile UDF.</param>
        /// <returns>The mesh connection request description (if found)</returns>
        public CatalogedPending GetPending(string local = null) => 
                containerProfile.GetPending(local);


        #endregion
        #region // Methods


        /// <summary>
        /// Register <paramref name="catalogItem"/> in the host catalog.
        /// </summary>
        /// <param name="catalogItem">The item to be created.</param>
        /// <param name="create">If true, a new item will be created if it does not
        /// already exist.</param>
        public virtual void Register(HostCatalogItem catalogItem, bool create = true) =>
                containerProfile.Update(catalogItem, create);


        /// <summary>
        /// Delete <paramref name="profile"/> from the host catalog.
        /// </summary>
        /// <param name="profile">The profile to delete</param>
        public virtual void Delete(HostCatalogItem profile) => 
                containerProfile.Delete(profile._PrimaryKey);
        #endregion

        }
    }
