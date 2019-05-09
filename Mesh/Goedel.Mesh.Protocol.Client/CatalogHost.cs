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


        public List<CatalogEntryDevice> GetCatalogEntryDevices() =>
            new List<CatalogEntryDevice> { ContainerProfile.DefaultCatalogEntryDevice };

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




        #region // ***************  old stuff
        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static CatalogHost GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.CatalogHost;

            }



        // *********** Old

        public virtual void Register(DareMessage profileSigned) {
            var profile = JSONObject.FromJSON(profileSigned.Body.JSONReader(), true);

            var entry = new ProfileEntry() {
                //Profile = profileSigned,
                //PrimaryKey = profile._PrimaryKey
                };

            

            ContainerProfile.Update(entry);

            }

        public virtual void Delete(Profile profile) =>
                ContainerProfile.Delete(profile._PrimaryKey);

        public virtual AssertionAccount GetConnection(
                    string accountName = null,
                    string deviceUDF = null) => throw new NYI();

        //ContainerHost.GetConnection(accountName, deviceUDF);

        //  ******


        public ContextDevice GetContextDevice(
                string accountID = null,
                string accountUDF = null,
                string deviceID = null,
                string deviceUDF = null) {

            if (accountID != null) {
                throw new NYI();
                }
            else if (accountUDF != null) {
                throw new NYI();
                }
            else if (deviceID != null) {
                throw new NYI();
                }
            else if (deviceUDF != null) {
                throw new NYI();
                }

            else if (ContainerProfile.DefaultProfileDevice != null) {
                return new ContextDevice(MeshMachine, 
                        ContainerProfile.DefaultProfileMaster, 
                        ContainerProfile.DefaultProfileMesh, 
                        ContainerProfile.DefaultProfileDevice);
                }
            return null;
            }


        public KeyCollection GetKeyCollection() => 
            new KeyCollectionClient(this, MeshMachine.KeyCollection);


        #endregion






        }
    }
