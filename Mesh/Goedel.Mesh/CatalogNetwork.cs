﻿using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    #region // The data classes CatalogNetwork, CatalogedNetwork
    /// <summary>
    /// Device catalog. Describes the network entries in a Mesh account.
    /// </summary>
    public class CatalogNetwork : Catalog<CatalogedNetwork> {
        #region // Properties
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Network";
        
        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        #endregion
        #region // Factory methods and constructors

        /// <summary>
        /// Factory delegate
        /// </summary>
        /// <param name="directory">Directory of store file on local machine.</param>
        /// <param name="storeId">Store identifier.</param>
        /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
        /// <param name="keyCollection">Key collection to be used to resolve keys</param>
        /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
        /// <param name="create">If true, create a new file if none exists.</param>
        public static new Store Factory(
                string directory,
                    string storeId,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) =>
            new CatalogNetwork(directory, storeId, cryptoParameters, keyCollection, decrypt, create);

        /// <summary>
        /// Constructor for a catalog named <paramref name="storeName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
        /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="storeName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>

        public CatalogNetwork(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                        cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        #endregion
        #region // Class methods

        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogedNetwork LocateByService(string key) {
            foreach (var network in AsCatalogedType) {
                if (network.Service == key) {
                    return network;
                    }
                }
            return null;
            }
        #endregion
        }


    public partial class CatalogedNetwork {
        #region // Properties
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => PrimaryKey(Protocol, Service);

        /// <summary>
        /// Compute a primary key from the values <paramref name="protocol"/> and
        /// <paramref name="service"/>
        /// </summary>
        /// <param name="protocol">The protocol name.</param>
        /// <param name="service">The service name</param>
        /// <returns>The computed primary key.</returns>
        public static string PrimaryKey(string protocol, string service) =>
            $"{protocol ?? ""}:{service ?? ""}";

        #endregion
        #region // Override methods
        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var stringBuilder = new StringBuilder();
            if (Protocol != null) {
                stringBuilder.Append("{Protocol}:");
                }
            stringBuilder.Append("{Username}@{Service} = [{Password}]");

            return stringBuilder.ToString();

            }
        #endregion
        }

    #endregion



    }
