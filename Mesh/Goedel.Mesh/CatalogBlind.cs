using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {



    public class CatalogBlind : Catalog {


        ///<summary>The catalog label</summary>
        public override string ContainerDefault => throw new NYI();


        /// <summary>
        /// Constructor for a catalog named <paramref name="containerName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="containerName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
        public CatalogBlind(
                    string directory,
                    string containerName,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, containerName, cryptoParameters, keyCollection,
                readContainer: false, decrypt: false, create: false) => ContainerPersistence?.FastReadContainer();


        public DareEnvelope Get(string key) => GetEntry(key).FrameIndex.GetEnvelope(Container);


        public override bool Transact(Catalog catalog, List<CatalogUpdate> updates) {
            Console.WriteLine("  Blind transaction!");

            return base.Transact(catalog, updates);

            }


        public string Report() {

            var builder = new StringBuilder();


            return builder.ToString();
            }


        }

    }
