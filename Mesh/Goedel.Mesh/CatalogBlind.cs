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
    public class CatalogBlind : Catalog<CatalogedEntry> {

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
                    IKeyCollection keyCollection = null) :
            base(directory, containerName, cryptoParameters, keyCollection,
                        readContainer: false, decrypt: false, create: false) => PersistenceStore?.FastReadContainer();

        }

    }
