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
        ContainerProfile ContainerProfile;

        public virtual void Register(CatalogItem profileEntry) =>
            ContainerProfile.Update(profileEntry);
        public virtual void Delete(CatalogItem profile) =>
                ContainerProfile.Delete(profile._PrimaryKey);

       

        static CatalogHost() {
            JSONObject.AddDictionary(CatalogItem._TagDictionary);
            JSONObject.AddDictionary(MeshItem._TagDictionary);
            }

        protected override void Disposing() {
            ContainerProfile.Dispose();
            }


        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public CatalogHost(ContainerProfile containerHost, IMeshMachine meshMachine) {
            MeshMachine = meshMachine;
            ContainerProfile = containerHost;
            }

        public AdminEntry GetAdmin(string local = null) => ContainerProfile.GetAdmin(local);
        public AccountEntry GetAccount(string local = null) => ContainerProfile.GetAccount(local);
        public PendingEntry GetPending(string local = null) => ContainerProfile.GetPending(local);


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
