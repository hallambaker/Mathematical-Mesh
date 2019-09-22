using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Protocol;


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
        public virtual string ContainerDefault => throw new NYI();
        public virtual Container Container { get; }
        //protected override void Disposing() => Container?.Dispose();

        protected CryptoParameters CryptoParameters;
        protected KeyCollection KeyCollection;

        ///<summary>The container identifier. Must be unique within a given account.</summary>
        public string ContainerName;


        public long FrameCount => Container.FrameCount;

        protected override void Disposing() => Container?.Dispose();


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
                using (var container = Container.OpenExisting(fileName, FileStatus.ConcurrentLocked, decrypt:false)) {
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


        public ContainerEnumeratorRaw Select(int minIndex, bool reverse=false) => 
            Container.Select(minIndex, reverse);




        }



    }
