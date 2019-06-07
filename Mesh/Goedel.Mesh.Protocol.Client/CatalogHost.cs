using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {







    public class CatalogHost : Disposable {
        IMeshMachine MeshMachine;
        PersistConnection ContainerProfile;

        public virtual void Register(ConnectionItem profileEntry, bool create = true) =>
            ContainerProfile.Update(profileEntry, create);
        public virtual void Delete(ConnectionItem profile) =>
                ContainerProfile.Delete(profile._PrimaryKey);

       

        static CatalogHost() {
            _ = ConnectionItem.Initialize;
            _ = MeshItem.Initialize;
            }

        protected override void Disposing() {
            ContainerProfile.Dispose();
            }


        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public CatalogHost(PersistConnection containerHost, IMeshMachine meshMachine) {
            MeshMachine = meshMachine;
            ContainerProfile = containerHost;
            }

        public Connection GetConnection(string local = null) => ContainerProfile.GetConnection(local);
        //public AccountEntry GetAccount(string local = null) => ContainerProfile.GetAccount(local);
        public PendingConnection GetPending(string local = null) => ContainerProfile.GetPending(local);


        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static CatalogHost GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.CatalogHost;

            }
        }
    }
