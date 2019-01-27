using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    public interface IMeshMachineClient {
        CatalogHost CatalogHost { get;  }

        }


    public class CatalogHost {
        IMeshMachine MeshMachine;
        ContainerHost ContainerHost;

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public CatalogHost(ContainerHost containerHost, IMeshMachine meshMachine) {
            MeshMachine = meshMachine;
            ContainerHost = containerHost;
            }


        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static CatalogHost GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.CatalogHost;

            }


        public virtual void Register(Profile profile) =>
                ContainerHost.Update(profile);

        public virtual void Delete(Profile profile) =>
                ContainerHost.Delete(profile._PrimaryKey);

        public virtual ProfileMesh GetConnection(
                    string accountName = null,
                    string deviceUDF = null) => ContainerHost.GetConnection(accountName, deviceUDF);


        public ContextDevice GetContextDevice(
                string accountID = null,
                string accountUDF = null,
                string deviceID = null,
                string deviceUDF = null) {
            throw new NYI();
            }

        public ContextAdministrator GetContextAdministrator(
                string accountID = null,
                string accountUDF = null,
                string deviceID = null,
                string deviceUDF = null) {
            throw new NYI();
            }

        public ContextMaster GetContextMaster(
                string accountID = null,
                string accountUDF = null,
                string deviceID = null,
                string deviceUDF = null) {
            throw new NYI();
            }


        public KeyCollection GetKeyCollection() => 
            new KeyCollectionClient(this, MeshMachine.KeyCollection);

        public virtual JpcSession GetJpcSession() => throw new NYI();



        public Profile GetProfileByAccount(string account) => 
                    ContainerHost.GetProfileByAccount(account);

        }
    }
