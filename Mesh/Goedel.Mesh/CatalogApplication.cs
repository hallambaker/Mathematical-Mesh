using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogApplication, CatalogedApplication

    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>
    public class CatalogApplication : Catalog<CatalogedApplication> {
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Application";
        
        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;


        /// <summary>
        /// Return the application entry for the site <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of the device to return.</param>
        /// <returns>The <see cref="CatalogedApplication"/> entry.</returns>
        public CatalogedApplication LocateBySite(string key) => Locate(key) as CatalogedApplication;


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

        public CatalogApplication(
                    string directory, 
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true, bool create = true) :
            base(directory, storeName, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }



        /// <summary>
        /// Locate the group <paramref name="groupAddress"/> in the catalog.
        /// </summary>
        /// <param name="groupAddress">The address of the group to locate in account@domain 
        /// format.</param>
        /// <returns>The unique catalog identifier for the group.</returns>
        public CatalogedGroup LocateGroup(string groupAddress) => 
                Locate(CatalogedGroup.GetGroupID(groupAddress)) as CatalogedGroup;


        }

    public partial class CatalogedApplication {

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => Key;

        }

    public partial class CatalogedGroup {

        ///<summary>Return the catalog identifier for the group <paramref name="groupAddress"/>.</summary>
        public static string GetGroupID(string groupAddress) => Constants.PrefixCatalogedGroup + groupAddress;

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => GetGroupID(Key);


        /// <summary>
        /// Default constructor for serialization.
        /// </summary>     
        public CatalogedGroup() {
            }

        /// <summary>
        /// Construct a group entry from <paramref name="profileGroup"/>.
        /// </summary>
        /// <param name="profileGroup">The profile of the group to create an entry for.</param>
        public CatalogedGroup(ProfileGroup profileGroup) => Profile = profileGroup;

        }
    #endregion


    }
