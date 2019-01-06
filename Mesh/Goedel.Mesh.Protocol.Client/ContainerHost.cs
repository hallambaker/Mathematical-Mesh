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

namespace Goedel.Mesh.Protocol.Client {



    public class ContainerHost : ContainerPersistenceStore {
        /// <summary>
        /// Index of items by Account name
        /// </summary>
        Dictionary<string, ContainerStoreEntry> DictionaryByAccount = new Dictionary<string, ContainerStoreEntry>();

        /// <summary>
        /// Index of items by Device UDF
        /// </summary>
        Dictionary<string, ContainerStoreEntry> DictionaryByUDF = new Dictionary<string, ContainerStoreEntry>();

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
        public ContainerHost(string fileName, string type = null,
                    string comment = null, bool readOnly = false,
                    FileStatus fileStatus = FileStatus.OpenOrCreate,
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

        /// <summary>
        /// Commit an Update transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitUpdate(ContainerStoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            //if (ObjectIndex.ContainsKey(containerStoreEntry.UniqueID)) {
            //    ObjectIndex.Remove(containerStoreEntry.UniqueID);
            //    }
            //ObjectIndex.Add(containerStoreEntry.UniqueID, containerStoreEntry);

            switch (containerStoreEntry.JsonObject) {
                case ProfileMesh profileMesh: {
                    DictionaryByAccount.ReplaceSafe(profileMesh.Account, containerStoreEntry);
                    DictionaryByUDF.ReplaceSafe(profileMesh.ProfileDevice.UDF, containerStoreEntry);
                    return;
                    }
                case ProfileDevice profileDevice: {
                    DictionaryByUDF.ReplaceSafe(profileDevice.UDF, containerStoreEntry);
                    return;
                    }
                case ProfileMaster profileMaster: {
                    DictionaryByUDF.ReplaceSafe(profileMaster.UDF, containerStoreEntry);
                    return;
                    }
                default: {
                    throw new NYI();
                    }
                }
            // Task: support for multiple MeshAccounts per device, default, etc.

            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitDelete(ContainerStoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            //Assert.True(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), NYI.Throw);
            //ObjectIndex.Remove(containerStoreEntry.UniqueID);
            //DeletedObjects.Add(containerStoreEntry.UniqueID, containerStoreEntry);


            }

        /// <summary>
        /// Get the profile matching the specified parameters.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="deviceUDF"></param>
        /// <returns></returns>
        public virtual ProfileMesh GetConnection(
                    string accountName = null,
                    string deviceUDF = null) {
            if (accountName != null) {
                DictionaryByAccount.TryGetValue(accountName, out var containerStoreEntry);
                return containerStoreEntry?.JsonObject as ProfileMesh;
                }
            if (deviceUDF != null) {
                DictionaryByUDF.TryGetValue(deviceUDF, out var containerStoreEntry);
                return containerStoreEntry?.JsonObject as ProfileMesh;
                }

            return null;

            }

        }
    }
