﻿using System;
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


    public partial class ProfileEntry {

        public override string _PrimaryKey => PrimaryKey; 

        }


    public class CatalogHost {
        IMeshMachine MeshMachine;
        ContainerHost ContainerHost;

        public ProfileMesh DefaultProfileMesh => ContainerHost?.DefaultProfileMesh;
        public ProfileDevice DefaultProfileDevice => ContainerHost?.DefaultProfileDevice;
        public ProfileMaster DefaultProfileMaster => ContainerHost?.DefaultProfileMaster;

        static CatalogHost() {
            JSONObject.AddDictionary(CatalogItem._TagDictionary);
            JSONObject.AddDictionary(MeshItem._TagDictionary);
            }

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


        public virtual void Register(DareMessage profileSigned) {
            var profile = JSONObject.FromJSON(profileSigned.Body.JSONReader(), true);

            var entry = new ProfileEntry() {
                Profile = profileSigned,
                PrimaryKey = profile._PrimaryKey
                };

            

            ContainerHost.Update(entry);

            }

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

            if (accountID != null) {
                throw new NYI();
                }
            else  if (accountUDF != null) {
                throw new NYI();
                }
            else if (deviceID != null) {
                throw new NYI();
                }
            else if (deviceUDF != null) {
                throw new NYI();
                }
            else if (ContainerHost.DefaultProfileDevice != null) {
                return new ContextDevice(MeshMachine, ContainerHost.DefaultProfileMesh, ContainerHost.DefaultProfileDevice);
                }
            return null;
            }


        public KeyCollection GetKeyCollection() => 
            new KeyCollectionClient(this, MeshMachine.KeyCollection);

        public virtual JpcSession GetJpcSession() => throw new NYI();



        public ProfileMesh GetProfileMeshByAccount(string account) => 
                    ContainerHost.GetProfileMeshByAccount(account);


        public ProfileDevice GetProfileDeviceByAccount(string account) =>
                    ContainerHost.GetProfileDeviceByAccount(account);

        public List<Profile> GetProfiles() => ContainerHost.GetProfiles();
        public List<AccountDescription> GetAccountDescriptions () => ContainerHost.GetAccountDescription();
        }
    }
