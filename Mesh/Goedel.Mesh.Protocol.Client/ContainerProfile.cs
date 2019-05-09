using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Client {

    public class AccountDescription {
        public string Account;
        public AssertionAccount ProfileMesh;
        public ProfileDevice DefaultProfileDevice;
        public Dictionary<string, CatalogEntryDevice> Devices = new Dictionary<string, CatalogEntryDevice>();

        }

    public partial class CatalogItem {
        public static object Initialize => null;

        static CatalogItem() => ContainerPersistenceStore.AddDictionary(_TagDictionary);
        }


    public class ContainerProfile : ContainerPersistenceStore {


        #region // old stuff *****************

        /// <summary>
        /// Index of items by Account name
        /// </summary>
        Dictionary<string, AccountDescription> DictionaryByAccount = new Dictionary<string, AccountDescription>();

        /// <summary>
        /// Index of items by Device UDF
        /// </summary>
        Dictionary<string, MeshItem> DictionaryByUDF = new Dictionary<string, MeshItem>();

        public AssertionAccount DefaultProfileMesh = null;
        public ProfileDevice DefaultProfileDevice = null;
        public ProfileMaster DefaultProfileMaster = null;
        public CatalogEntryDevice DefaultCatalogEntryDevice = null;

        #endregion


        public ProfileDevice DefaultDeviceProfile =>
                    DefaultAccountEntry.ProfileDevice ??
                    DefaultPendingEntry.ProfileDevice ??
                    DefaultAdminEntry.ProfileDevice;

        ///<summary></summary>
        public AdminEntry DefaultAdminEntry { get; private set; }

        ///<summary></summary>
        public AccountEntry DefaultAccountEntry { get; private set; }

        ///<summary></summary>
        public PendingEntry DefaultPendingEntry { get; private set; }


        static ContainerProfile() {
            _ = MeshItem.Initialize;
            _ = CatalogItem.Initialize;
            }

        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="fileName">Log file.</param>
        /// <param name="readOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="type">Type of data to store (the schema name).</param>
        /// <param name="comment">Comment to be written to the log.</param>
        /// <param name="containerType">The Container type.</param>
        /// <param name="dataEncoding">The data encoding.</param>
        /// <param name="fileStatus">The file status in which to open the container.</param>
        /// <param name="keyCollection">The key collection to use to resolve private keys.</param>
        /// <param name="readContainer">If true read the container to initialize the persistence store.</param>
        public ContainerProfile(string fileName, string type = null,
                    string comment = null, bool readOnly = false,
                    FileStatus fileStatus = FileStatus.ConcurrentLocked,
                    ContainerType containerType = ContainerType.Chain,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool readContainer = true) : base(
                        fileName, type, comment, 
                        fileStatus, containerType, dataEncoding, cryptoParameters,
                        keyCollection, readContainer) {
            }



        /// <summary>
        /// Commit a New transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitNew(ContainerStoreEntry containerStoreEntry) =>
            MemoryCommitUpdate(containerStoreEntry);


        protected override void MemoryCommitUpdate(ContainerStoreEntry containerStoreEntry) {
            var catalogItem = containerStoreEntry.JsonObject as CatalogItem;

            switch (catalogItem) {
                case AccountEntry accountEntry: {
                    DefaultAccountEntry = accountEntry.Default ? accountEntry : DefaultAccountEntry ?? accountEntry;
                    break;
                    }
                case AdminEntry adminEntry: {
                    DefaultAdminEntry = adminEntry.Default ? adminEntry : DefaultAdminEntry ?? adminEntry;
                    break;
                    }
                case PendingEntry pendingEntry: {
                    DefaultPendingEntry = pendingEntry.Default ? pendingEntry : DefaultPendingEntry ?? pendingEntry;
                    break;
                    }
                }


            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitDelete(ContainerStoreEntry containerStoreEntry) {

            }

        /// <summary>
        /// These are hacks of course because they only ever return the default profile.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public AdminEntry GetAdmin(string local = null) => DefaultAdminEntry;
        public AccountEntry GetAccount(string local = null) => DefaultAccountEntry;
        public PendingEntry GetPending(string local = null) => DefaultPendingEntry;



        #region // old stuff *************************
        /// <summary>
        /// Search the profile catalog to locate a profile. If <paramref name="accountID"/>
        /// and/or <paramref name="deviceUDF"/> null, the profile most recently marked as being the 
        /// default is returned. Otherwise, a profile matching the selection is returned if found
        /// or null if no profile matches the specification. 
        /// </summary>
        /// <param name="accountID">The account identifier to match</param>
        /// <param name="deviceUDF">The device identifier to match.</param>
        /// <returns></returns>
        public ProfileEntry GetProfile(string accountID = null, string deviceUDF = null) => DefaultAccountEntry;





        //void Commit(ProfileMaster profileMaster, bool makeDefault) {
        //    DefaultProfileMaster = makeDefault ? profileMaster : DefaultProfileMaster ?? profileMaster;
        //    DictionaryByUDF.ReplaceSafe(profileMaster.UDF, profileMaster);
        //    }

        //void Commit(ProfileDevice profileDevice, bool makeDefault) {
        //    DefaultProfileDevice = makeDefault ? profileDevice : DefaultProfileDevice ?? profileDevice;
        //    DictionaryByUDF.ReplaceSafe(profileDevice.UDF, profileDevice);
        //    }

        //void Commit(AssertionAccount profileMesh, bool makeDefault) {
        //    DefaultProfileMesh = makeDefault ? profileMesh : DefaultProfileMesh ?? profileMesh;
        //    DictionaryByUDF.ReplaceSafe(profileMesh.UDF, profileMesh);

        //    var account = profileMesh.Account;
        //    if (DictionaryByAccount.TryGetValue(account, out var accountDescription)) {
        //        accountDescription.ProfileMesh = profileMesh;
        //        }
        //    else {
        //        accountDescription = new AccountDescription() {
        //            Account = account,
        //            ProfileMesh = profileMesh
        //            };
        //        DictionaryByAccount.Add(account, accountDescription);
        //        }
        //    }


        ///// <summary>
        ///// Commit <paramref name="catalogEntryDevice"/> to the memory store and register for 
        ///// each of the accounts it is declared for.
        ///// </summary>
        ///// <param name="catalogEntryDevice"></param>
        ///// <param name="makeDefault"></param>

        //void Commit(CatalogEntryDevice catalogEntryDevice, bool makeDefault) {
        //    DefaultCatalogEntryDevice = makeDefault ? catalogEntryDevice :
        //        DefaultCatalogEntryDevice ?? catalogEntryDevice;
        //    DictionaryByUDF.ReplaceSafe(catalogEntryDevice.UDF, catalogEntryDevice);

        //    if (catalogEntryDevice.Accounts != null) {
        //        foreach (var account in catalogEntryDevice.Accounts) {
        //            if (DictionaryByAccount.TryGetValue(account, out var accountDescription)) {
        //                accountDescription.Devices.AddSafe(catalogEntryDevice.UDF, catalogEntryDevice);
        //                }
        //            else {
        //                accountDescription = new AccountDescription() {
        //                    Account = account,
        //                    };
        //                accountDescription.Devices.Add(catalogEntryDevice.UDF, catalogEntryDevice);
        //                DictionaryByAccount.Add(account, accountDescription);
        //                }
        //            }
        //        }

        //    }



        ///// <summary>
        ///// Commit an Update transaction to memory
        ///// </summary>
        ///// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        //protected override void MemoryCommitUpdate(ContainerStoreEntry containerStoreEntry) {
        //    // Check to make sure the object does not already exist
        //    //if (ObjectIndex.ContainsKey(containerStoreEntry.UniqueID)) {
        //    //    ObjectIndex.Remove(containerStoreEntry.UniqueID);
        //    //    }
        //    //ObjectIndex.Add(containerStoreEntry.UniqueID, containerStoreEntry);

        //    var profileEntry = containerStoreEntry.JsonObject as ProfileEntry;
        //    var profile = MeshItem.Decode(profileEntry.Profile);


        //        //JSONObject.FromJSON(profileEntry.Profile.Body.JSONReader(), true);
            
        //    switch (profile) {
        //        case AssertionAccount profileMesh: {
        //            Commit(profileMesh, profileEntry.Default);
        //            return;
        //            }
        //        case ProfileDevice profileDevice: {
        //            Commit(profileDevice, profileEntry.Default);
        //            return;
        //            }
        //        case ProfileMaster profileMaster: {
        //            Commit(profileMaster, profileEntry.Default);
        //            return;
        //            }
        //        case CatalogEntryDevice catalogEntryDevice: {
        //            Commit(catalogEntryDevice, profileEntry.Default);
        //            return;
        //            }

        //        default: {
        //            throw new NYI();
        //            }
        //        }
        //    // Task: support for multiple MeshAccounts per device, default, etc.

        //    }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        //protected override void MemoryCommitDelete(ContainerStoreEntry containerStoreEntry) {
        //    // Check to make sure the object does not already exist
        //    //Assert.True(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), NYI.Throw);
        //    //ObjectIndex.Remove(containerStoreEntry.UniqueID);
        //    //DeletedObjects.Add(containerStoreEntry.UniqueID, containerStoreEntry);


        //    }

        ///// <summary>
        ///// Get the profile matching the specified parameters.
        ///// </summary>
        ///// <param name="accountName"></param>
        ///// <param name="deviceUDF"></param>
        ///// <returns></returns>
        //public virtual void GetConnection(
        //            out ProfileDevice profileDevice,
        //            out AccountDescription accountDescription,
        //            string accountName = null,
        //            string deviceUDF = null
        //            ) {
        //    if (accountName != null) {
        //        DictionaryByAccount.TryGetValue(accountName, out accountDescription);
        //        profileDevice = accountDescription.DefaultProfileDevice;
        //        return;
        //        }
        //    accountDescription = null;

        //    if (deviceUDF != null) {
        //        DictionaryByUDF.TryGetValue(deviceUDF, out var profile);
        //        profileDevice = profile as ProfileDevice;
        //        }

        //    profileDevice = DefaultProfileDevice;

        //    }

        //public List<Assertion> GetProfiles() {
        //    var result = new List<Assertion>();
        //    foreach (var entry in DictionaryByUDF) {
        //        if (entry.Value as Assertion != null) {
        //            result.Add(entry.Value as Assertion);
        //            }
        //        }
        //    return result;
        //    }

        //public List<AccountDescription> GetAccountDescription() {
        //    var result = new List<AccountDescription>();
        //    foreach (var entry in DictionaryByAccount) {
        //        result.Add(entry.Value);
        //        }
        //    return result;
        //    }

        //public AssertionAccount GetProfileMeshByAccount(string account) {
        //    var found = DictionaryByAccount.TryGetValue(account, out var accountDescription);
        //    return accountDescription.ProfileMesh;

        //    }

        //public ProfileDevice GetProfileDeviceByAccount(string account) {
        //    var found = DictionaryByAccount.TryGetValue(account, out var accountDescription);


        //    foreach (var device in accountDescription.Devices) {
        //        found = DictionaryByUDF.TryGetValue(device.Value.UDF, out var profile);
        //        if (profile is ProfileDevice ProfileDevice) {
        //            return ProfileDevice;
        //            }
        //        }
        //    return null;
        //    }


        #endregion
        }
    }
