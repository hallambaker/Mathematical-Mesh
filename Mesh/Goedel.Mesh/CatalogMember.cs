using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogMember, CatalogedMember
    /// <summary>
    /// Device catalog. Describes the members of a Mesh Group.
    /// </summary>
    public class CatalogMember : Catalog<CatalogedMember> {

        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Member";

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
        public CatalogMember(
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

    public partial class CatalogedMember {

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => ContactAddress;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public CatalogedMember() { }

        }



    #endregion



    }
