using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {

    /// <summary>
    /// Factory method returning a store of this type
    /// </summary>
    /// <param name="directory">The directory in which the store is kept/is to be created.</param>
    /// <param name="name">The name of the store (defaults to the store name)</param>
    /// <returns>The created store</returns>
    public delegate Store StoreFactoryDelegate(
                    string Directory,
                    string name,
                    CryptoParameters cryptoParameters,
                    KeyCollection keyCollection);

    public class Store : Disposable {
        ///<summary>The default name for the container</summary>
        public virtual string ContainerDefault => throw new NYI();

        ///<summary>The container</summary>
        public virtual Container Container { get; }

        ///<summary>The frame count (returns -1 if no container has been created)</summary>
        public long FrameCount => Container == null ? -1 : Container.FrameCount;


        //protected override void Disposing() => Container?.Dispose();

        ///<summary>The cryptographic parameters</summary>
        protected CryptoParameters CryptoParameters;

        ///<summary>The key collection used for decryption</summary>
        protected KeyCollection KeyCollection;

        ///<summary>The container identifier. Must be unique within a given account.</summary>
        public string ContainerName;

        ///<summary>The disposal routing</summary>
        protected override void Disposing() => Container?.Dispose();

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="containerName"></param>
        /// <param name="cryptoParameters"></param>
        /// <param name="keyCollection"></param>
        /// <param name="decrypt"></param>
        /// <param name="create"></param>
        public Store(string directory, string containerName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) {

            ContainerName = containerName ?? ContainerDefault;
            var fileName = FileName(directory, ContainerName);

            Container = Container.Open(
                fileName,
                FileStatus.ConcurrentLocked,
                keyCollection ?? cryptoParameters?.KeyCollection,
                cryptoParameters,
                ContainerType.MerkleTree,
                "application/mmm-catalog",
                decrypt: decrypt,
                create: create
                );

            KeyCollection = keyCollection;
            CryptoParameters = cryptoParameters;




            }

        public static void Append(string directory, List<DareEnvelope> envelopes, string containerName = null) {
            envelopes.AssertNotNull();
            if (envelopes.Count == 0) {
                return;
                }

            var fileName = FileName(directory, containerName);

            if (envelopes[0].Header.ContainerInfo.Index == 0) {
                using (var container = Container.MakeNewContainer(fileName, envelopes)) {
                    //container.Append(envelopes);
                    }
                }
            else {
                // here open the existing container.
                using (var container = Container.OpenExisting(fileName, FileStatus.ConcurrentLocked, decrypt: false)) {
                    container.Append(envelopes);
                    }
                }

            }


        public static string FileName(string directory, string containerName = null) => Path.Combine(directory, Path.ChangeExtension(containerName, ".dcat"));


        public static Store Factory(
                    string Directory,
                    string name,
                    CryptoParameters cryptoParameters,
                    KeyCollection keyCollection) =>
            new Store(Directory, name, cryptoParameters, keyCollection);


        public void AppendDirect(DareEnvelope message) => Container.Append(message);


        public ContainerEnumeratorRaw Select(int minIndex, bool reverse = false) =>
            Container.Select(minIndex, reverse);




        }



    }
