using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {


    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    public delegate Store StoreFactoryDelegate(
                    string directory,
                    string storeId,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true);

    /// <summary>
    /// Base class for managing Mesh stores (catalogs, spools).
    /// </summary>
    /// 
    public class Store : Disposable {
        ///<summary>The default name for the container</summary>
        public virtual string ContainerDefault => throw new NYI();

        ///<summary>The container</summary>
        public virtual Container Container { get; }

        ///<summary>The frame count (returns -1 if no container has been created)</summary>
        public long FrameCount => Container == null ? -1 : Container.FrameCount;


        //protected override void Disposing() => Container?.Dispose();

        ///<summary>The cryptographic parameters</summary>
        protected CryptoParameters CryptoParameters { get; set; }

        ///<summary>The key collection used for decryption</summary>
        public IKeyCollection KeyCollection { get; set; }

        ///<summary>The container identifier. Must be unique within a given account.</summary>
        public string ContainerName { get; set; }

        ///<summary>The disposal routing</summary>
        protected override void Disposing() => Container?.Dispose();


        /// <summary>
        /// Factory delegate
        /// </summary>
        /// <param name="directory">Directory of store file on local machine.</param>
        /// <param name="storeId">Store identifier.</param>
        /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
        /// <param name="keyCollection">Key collection to be used to resolve keys</param>
        /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
        /// <param name="create">If true, create a new file if none exists.</param>
        public static Store Factory(
                    string directory, 
                    string storeId,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) =>
            new Store(directory, storeId, cryptoParameters, keyCollection);


        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="directory">Directory of store file on local machine.</param>
        /// <param name="storeId">Store identifier.</param>
        /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
        /// <param name="keyCollection">Key collection to be used to resolve keys</param>
        /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
        /// <param name="create">If true, create a new file if none exists.</param>
        public Store(string directory, 
                    string storeId = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) {

            ContainerName = storeId ?? ContainerDefault;
            var fileName = FileName(directory, ContainerName);



            Container = Container.Open(
                fileName,
                FileStatus.ConcurrentLocked,
                keyCollection ?? cryptoParameters?.KeyLocate,
                cryptoParameters,
                ContainerType.MerkleTree,
                "application/mmm-catalog",
                decrypt: decrypt,
                create: create
                );

            KeyCollection = keyCollection;
            CryptoParameters = cryptoParameters;
            }


        /// <summary>
        /// Return the status of the spool.
        /// </summary>
        /// <param name="directory">The directory in which the spool is stored.</param>
        /// <param name="storeName">The store name.</param>
        /// <returns></returns>
        public static ContainerStatus Status(string directory, string storeName) {
            using var store = new Store(directory, storeName);
            return new ContainerStatus() {
                Index = (int)store.Container.FrameCount,
                Container = storeName
                };
            }

        /// <summary>
        /// Append the list of envelopes <paramref name="envelopes"/> to the
        /// container <paramref name="containerName"/> in <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">Directory in which the containers are kept.</param>
        /// <param name="envelopes">The envelopes to add.</param>
        /// <param name="containerName">The name of the container.</param>
        /// <param name="keyLocate">The key location context.</param>
        public static void Append(string directory, 
                IKeyLocate keyLocate, List<DareEnvelope> envelopes, string containerName = null) {
            envelopes.AssertNotNull(Internal.Throw);
            if (envelopes.Count == 0) {
                return;
                }

            var fileName = FileName(directory, containerName);

            if (envelopes[0].Header.ContainerInfo.Index == 0) {
                using var container = Container.MakeNewContainer(fileName, keyLocate, envelopes);
                }
            else {
                // here open the existing container.
                using var container = Container.OpenExisting(fileName, FileStatus.ConcurrentLocked, decrypt: false);
                container.Append(envelopes);
                }

            }

        /// <summary>
        /// Compute the filename for the container <paramref name="containerName"/> 
        /// in <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">Directory in which the containers are kept.</param>
        /// <param name="containerName">The name of the container.</param>
        /// <returns></returns>
        public static string FileName(string directory, string containerName = null) => Path.Combine(directory, Path.ChangeExtension(containerName, ".dcat"));


        //public static Store Factory(
        //            string Directory,
        //            string name,
        //            CryptoParameters cryptoParameters,
        //            KeyCollection keyCollection) =>
        //    new Store(Directory, name, cryptoParameters, keyCollection);

        /// <summary>
        /// Append the envelopes <paramref name="envelope"/> to the
        /// store.
        /// </summary>
        public void AppendDirect(DareEnvelope envelope) => Container.Append(envelope);


        /// <summary>
        /// Returns an enumerator for traversing the store. If <paramref name="reverse"/>
        /// is true, the enumeration begins at the end of the container and envelopes
        /// with index values greater or equal to <paramref name="minIndex"/> are returned.
        /// Otherwise the first envelope returned is the one at index value <paramref name="minIndex"/>
        /// and the enumeration continues to the end.
        /// </summary>
        /// <param name="minIndex">The lowest index value to return.</param>
        /// <param name="reverse">If true, begin enumeration at the end of the container and
        /// work backwards. Otherwise begin at <paramref name="minIndex"/> and move
        /// forwards.</param>
        /// <returns></returns>
        public ContainerEnumeratorRaw Select(int minIndex, bool reverse = false) =>
            Container.Select(minIndex, reverse);




        }



    }
