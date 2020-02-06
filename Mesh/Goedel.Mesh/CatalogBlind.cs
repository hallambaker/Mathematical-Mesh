using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {


    /// <summary>
    /// Dummy catalog class that binds to a persistence store as a collection of
    /// opaque entries. Entries are not decrypted, only the ciphertext values are
    /// available.
    /// </summary>
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
                readContainer: false, decrypt: false, create: false) => PersistenceStore?.FastReadContainer();


        /// <summary>
        /// Return the envelope with unique identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of entry to return.</param>
        /// <returns>The envelope.</returns>
        public DareEnvelope Get(string key) {

            var entry = GetEntry(key);
            var envelope = entry.FrameIndex.GetEnvelope(Container);
            return envelope;
            }

        /// <summary>
        /// Apply the transactions specified in <paramref name="updates"/> to the catalog
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to apply the transactions to.</param>
        /// <param name="updates">The updates to apply</param>
        /// <returns>True if the transactions were accepted, otherwise false.</returns>
        public override bool Transact(Catalog catalog, List<CatalogUpdate> updates) {
            Console.WriteLine("  Blind transaction!");

            return base.Transact(catalog, updates);

            }

        /// <summary>
        /// Return a string describing the catalog entries.
        /// </summary>
        /// <returns>The string describing the catalog entries.</returns>
        public string Report() {

            var builder = new StringBuilder();


            return builder.ToString();
            }


        }

    }
