using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {
    public class ContextAccount {

        ///<summary>The device profile to which the signature key is bound</summary>
        public ProfileDevice ProfileDevice { get; }

        public ContextAdmin GetContextAdmin() =>
            new ContextAdmin(MeshMachine, MeshMachine.GetAdmin());


        #region // Convenience accessors for catalogs and stores
        public CatalogDevice GetCatalogDevice() =>
                (catalogDevice ?? GetStore(CatalogDevice.Label).CacheValue(out catalogDevice)) as CatalogDevice;
        Store catalogDevice = null;

        public CatalogContact GetCatalogContact() =>
                (catalogContact ?? GetStore(CatalogContact.Label).CacheValue(out catalogContact)) as CatalogContact;
        Store catalogContact;

        public CatalogCredential GetCatalogCredential() =>
                (catalogCredential ?? GetStore(CatalogCredential.Label).CacheValue(out catalogCredential)) as CatalogCredential;
        Store catalogCredential = null;

        public CatalogBookmark GetCatalogBookmark() =>
                (catalogBookmark ?? GetStore(CatalogBookmark.Label).CacheValue(out catalogBookmark)) as CatalogBookmark;
        Store catalogBookmark = null;

        public CatalogCalendar GetCatalogCalendar() =>
                (catalogCalendar ?? GetStore(CatalogCalendar.Label).CacheValue(out catalogCalendar)) as CatalogCalendar;
        Store catalogCalendar = null;

        public CatalogNetwork GetCatalogNetwork() =>
                (catalogNetwork ?? GetStore(CatalogNetwork.Label).CacheValue(out catalogNetwork)) as CatalogNetwork;
        Store catalogNetwork = null;

        public CatalogApplication GetCatalogApplication() =>
                (catalogApplication ?? GetStore(CatalogApplication.Label).CacheValue(out catalogApplication)) as CatalogApplication;
        Store catalogApplication;

        public Spool SpoolInbound =>
                (spoolInbound ?? GetStore(Spool.SpoolInbound).CacheValue(out spoolInbound)) as Spool;
        Store spoolInbound;

        public Spool Outbound =>
            (spoolOutbound ?? GetStore(Spool.SpoolOutbound).CacheValue(out spoolOutbound)) as Spool;
        Store spoolOutbound;
        #endregion


        IMeshMachineClient MeshMachine { get; }

        AccountEntry AccountEntry;
        AssertionAccount AssertionAccount;


        CatalogEntryDevice CatalogEntryDevice => AccountEntry.CatalogEntryDevice;
        AssertionDeviceConnection AssertionDeviceConnection;
        AssertionDevicePrivate AssertionDevicePrivate;


        public string Local => AccountEntry.Local;


        KeyPair KeySignature;
        KeyPair KeyEncryption;
        KeyPair KeyAuthentication;


        public ContextAccount(IMeshMachineClient meshMachine, string local = null):
                this (meshMachine, meshMachine.GetAccount(local)) {
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminEntry"></param>
        public ContextAccount(
                IMeshMachineClient meshMachine,
                AccountEntry accountEntry
                ) {
            Assert.AssertNotNull(accountEntry, NYI.Throw);

            MeshMachine = meshMachine;
            AccountEntry = accountEntry;
            ProfileDevice = ProfileDevice.Decode(accountEntry.EncodedProfileDevice);
            AssertionAccount = AssertionAccount.Decode(accountEntry.EncodedAssertionAccount);

            // Recover the account keys from their composites.
            KeySignature = AssertionDevicePrivate.KeySignature.GetPrivate(MeshMachine);
            KeyEncryption = AssertionDevicePrivate.KeyEncryption.GetPrivate(MeshMachine);
            KeyAuthentication = AssertionDevicePrivate.KeyAuthentication.GetPrivate(MeshMachine);

            }


        public static ContextAccount Generate(
                ContextAdmin contextAdmin,
                string localName ,
                IMeshMachineClient meshMachine=null,
                
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            meshMachine = meshMachine ?? contextAdmin.MeshMachine;
            var accountEntry = new AccountEntry();
            contextAdmin.Add(accountEntry);
            return new ContextAccount(meshMachine, accountEntry);
            }





        public void AddService(
                string ServiceID,
                string PIN = null) {
            throw new NYI();
            }


        public string GetPIN() {
            throw new NYI();
            }

        public void  Sync() {
            throw new NYI();
            }



        public Store GetStore(string name) {
            throw new NYI();

            //if (DictionaryStores.TryGetValue(name, out var store)) {
            //    return store;
            //    }
            //Console.WriteLine($"Open store {name} on {MeshMachine.DirectoryMesh} {devicecount}");

            //store = MakeStore(name);
            //DictionaryStores.Add(name, store);

            //return store;
            }
        }
    }
