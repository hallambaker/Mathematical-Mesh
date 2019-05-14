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


        IMeshMachineClient MeshMachine { get; }
        KeyCollection KeyCollection => MeshMachine.KeyCollection;
        AccountEntry AccountEntry;
        AssertionAccount AssertionAccount;
        CryptoParameters ContainerCryptoParameters;

        CatalogEntryDevice CatalogEntryDevice => AccountEntry.CatalogEntryDevice;
        public AssertionDeviceConnection AssertionDeviceConnection;
        AssertionDevicePrivate AssertionDevicePrivate;


        public string AccountId;

        public string Local => AccountEntry.Local;


        KeyPair KeySignature;
        KeyPair KeyEncryption;
        KeyPair KeyAuthentication;
        ContextAdmin ContextAdmin;

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
            ContainerCryptoParameters = new CryptoParameters(Recipient: AssertionAccount.AccountEncryptionKey.KeyPair);

            // Recover the account keys from their composites.
            KeySignature = AssertionDevicePrivate.KeySignature.GetPrivate(MeshMachine);
            KeyEncryption = AssertionDevicePrivate.KeyEncryption.GetPrivate(MeshMachine);
            KeyAuthentication = AssertionDevicePrivate.KeyAuthentication.GetPrivate(MeshMachine);

            }


        ContextAccount(ContextAdmin contextAdmin, AssertionAccount assertionAccount) {
            MeshMachine = contextAdmin.MeshMachine;
            ContextAdmin = contextAdmin;
            AssertionAccount = assertionAccount;
            }






        public static ContextAccount CreateAccount(
                ContextAdmin contextAdmin,
                string localName ,
                IMeshMachineClient meshMachine=null,
                
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            meshMachine = meshMachine ?? contextAdmin.MeshMachine;
            profileDevice = profileDevice ?? contextAdmin.ProfileDevice ??
                ProfileDevice.Generate(meshMachine, algorithmSign, algorithmEncrypt, algorithmAuthenticate);


            // Create the AssertionAccount here
            var assertionAccount = contextAdmin.CreateAccount(localName);

            // Generate a ContextAccount for the AssertionAccount
            var contextAccount = new ContextAccount(contextAdmin, assertionAccount);

            // Add profileDevice to the Account
            contextAccount.Add(profileDevice);


            return contextAccount;
            }


        public AccountEntry Add(ProfileDevice profileDevice) {
            var catalogEntryDevice = new CatalogEntryDevice(MeshMachine, profileDevice);

            var accountEntry = new AccountEntry() {
                ID = catalogEntryDevice.UDF,
                EncodedProfileDevice = profileDevice.DareMessage,
                Directory = MeshMachine.DirectoryMesh,
                CatalogEntryDevice = catalogEntryDevice,
                EncodedAssertionAccount = AssertionAccount.DareMessage
                };

            ContextAdmin.Add(accountEntry);

            return accountEntry;
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


        public void Process(MeshMessage meshMessage, bool accept=true, bool respond=true){
            }


        public void ContactRequest(string serviceID) {
            }

        public void ConfirmationRequest(string serviceID, string messageText) {
            }


        #region // Convenience accessors for catalogs and stores

        ///<summary>Dictionary used to cache stores to avoid need to re-open them repeatedly.</summary>
        Dictionary<string, Store> DictionaryStores = new Dictionary<string, Store>();

        ///<summary>Returns the device catalog for the account</summary>
        public CatalogDevice GetCatalogDevice() => GetStore(CatalogDevice.Label) as CatalogDevice;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogContact GetCatalogContact() => GetStore(CatalogContact.Label) as CatalogContact;

        ///<summary>Returns the c redential catalog for the account</summary>
        public CatalogCredential GetCatalogCredential() => GetStore(CatalogCredential.Label) as CatalogCredential;

        ///<summary>Returns the bookmark catalog for the account</summary>
        public CatalogBookmark GetCatalogBookmark() => GetStore(CatalogBookmark.Label) as CatalogBookmark;

        ///<summary>Returns the calendar catalog for the account</summary>
        public CatalogCalendar GetCatalogCalendar() => GetStore(CatalogCalendar.Label) as CatalogCalendar;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogNetwork GetCatalogNetwork() => GetStore(CatalogNetwork.Label) as CatalogNetwork;

        ///<summary>Returns the application catalog for the account</summary>
        public CatalogApplication GetCatalogApplication() => GetStore(CatalogApplication.Label) as CatalogApplication;

        ///<summary>Returns the inbound spool for the account</summary>
        public Spool GetSpoolInbound() => spoolInbound ?? (GetStore(Spool.SpoolInbound) as Spool).CacheValue(out spoolInbound);
        Spool spoolInbound;


        ///<summary>Returns the outbound spool catalog for the account</summary>
        public Spool GetSpoolOutbound() => GetStore(Spool.SpoolOutbound) as Spool;

        /// <summary>
        /// Return the latest unprocessed MessageConnectionRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConnectionRequest</returns>
        public MeshMessage GetPendingMessageConnectionRequest() =>
            GetPendingMessage(MessageConnectionRequest.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageContactRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageContactRequest</returns>
        public MeshMessage GetPendingMessageContactRequest() =>
            GetPendingMessage(MessageContactRequest.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageConfirmationRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConfirmationRequest</returns>
        public MeshMessage GetPendingMessageConfirmationRequest() =>
            GetPendingMessage(MessageConfirmationRequest.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageConfirmationResponse that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConfirmationResponse</returns>
        public MeshMessage GetPendingMessageConfirmationResponse() =>
            GetPendingMessage(MessageConfirmationResponse.__Tag);

        /// <summary>
        /// Search the inbound spool and 
        /// </summary>
        /// <param name="spoolInbound"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public MeshMessage GetPendingMessage(string tag) {
            var completed = new Dictionary<string, MeshMessage>();

            foreach (var message in spoolInbound.Select(1, true)) {
                var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());
                if (!completed.ContainsKey(meshMessage.MessageID)) {
                    if (meshMessage._Tag == tag) {
                        return meshMessage;
                        }
                    switch (meshMessage) {
                        case MeshMessageComplete meshMessageComplete: {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageID, meshMessageComplete);
                                // Hack: This should make actual use of the relationship
                                //   (Accept, Reject, Read)
                                }
                            break;
                            }
                        }
                    }
                }
            return null;
            }

        #endregion


        public Store GetStore(string name) {

            if (DictionaryStores.TryGetValue(name, out var store)) {
                return store;
                }
            //Console.WriteLine($"Open store {name} on {MeshMachine.DirectoryMesh} {devicecount}");

            store = MakeStore(name);
            DictionaryStores.Add(name, store);

            return store;
            }

        Store MakeStore(string name) {
            switch (name) {
                case Spool.SpoolInbound: return new Spool(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case Spool.SpoolOutbound: return new Spool(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case Spool.SpoolArchive: return new Spool(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);

                case CatalogCredential.Label: return new CatalogCredential(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogDevice.Label: return new CatalogDevice(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogContact.Label: return new CatalogContact(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogCalendar.Label: return new CatalogCalendar(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogBookmark.Label: return new CatalogBookmark(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogNetwork.Label: return new CatalogNetwork(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                case CatalogApplication.Label: return new CatalogApplication(MeshMachine.DirectoryMesh, name, ContainerCryptoParameters, KeyCollection);
                }

            throw new NYI();
            }

        }
    }
