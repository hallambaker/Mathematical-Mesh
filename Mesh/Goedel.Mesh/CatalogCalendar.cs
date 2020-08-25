using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh {


    #region // The data classes CatalogCalendar, CatalogedTask

    /// <summary>
    /// Calendar catalog. Describes the tasks in a Mesh account.
    /// </summary>
    public class CatalogCalendar : Catalog<CatalogedTask> {
        #region // Properties
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Calendar";

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
            new CatalogCalendar(directory, storeId, cryptoParameters, keyCollection, decrypt, create);


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
        public CatalogCalendar(
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
        }

    // NYI should all be DareMessages to allow them to be signed.


    public partial class CatalogedTask {
        #region // Properties
        /// <summary>
        /// The primary key used to catalog the entry. 
        /// </summary>
        public override string _PrimaryKey => Key;
        #endregion
        #region // Factory methods and constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CatalogedTask() => Key = UDF.Nonce();

        #endregion

        }
    #endregion

    }
