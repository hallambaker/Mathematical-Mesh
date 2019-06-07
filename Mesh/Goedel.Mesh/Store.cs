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
        protected virtual Container Container { get; }
        //protected override void Disposing() => Container?.Dispose();

        protected CryptoParameters CryptoParameters;
        protected KeyCollection KeyCollection;
        string ContainerName;


        public long FrameCount => Container.FrameCount;

        protected override void Disposing() => Container?.Dispose();


        public Store(string directory, string containerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) {

            containerName = containerName ?? ContainerDefault;
            var fileName = Path.Combine(directory, Path.ChangeExtension(containerName, ".dcat"));
            //Console.WriteLine($"Open Store {ContainerName} / {directory}");
            ContainerName = containerName;

            Container = Container.Open(
                fileName,
                FileStatus.ConcurrentLocked,
                keyCollection ?? cryptoParameters?.KeyCollection,
                cryptoParameters,
                ContainerType.MerkleTree,
                "application/mmm-catalog"
                );

            KeyCollection = keyCollection;
            CryptoParameters = cryptoParameters;




            }

        public static Store Factory(
                    string Directory,
                    string name,
                    CryptoParameters cryptoParameters,
                    KeyCollection keyCollection) =>
            new Store(Directory, name, cryptoParameters, keyCollection);


        public void AppendDirect(DareMessage message) => Container.AppendDirect(message);


        public ContainerEnumeratorRaw Select(int minIndex, bool reverse=false) => 
            Container.Select(minIndex, reverse);


        }



    }
