using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh {


    /// <summary>
    /// Bookmark catalog. Describes the bookmarks in the user's Mesh account.
    /// </summary>
    public class CatalogBookmark : Catalog<CatalogedBookmark> {
        
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Bookmark";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

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

        public CatalogBookmark(
                    string directory, 
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                        cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }


        }


    public partial class CatalogedBookmark {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => Path;

        }


    }
