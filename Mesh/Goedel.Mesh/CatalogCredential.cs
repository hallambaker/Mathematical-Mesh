using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {


    #region // The data classes CatalogCredential, CatalogedCredential
    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>

    public class CatalogCredential : Catalog<CatalogedCredential> {

        ///<summary>The canonical label for the catalog</summary>

        public const string Label = "mmm_Credential";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        /// <summary>
        /// Locate credential matching the specified service name, ignoring the protocol value.
        /// </summary>
        /// <param name="key">The service to be matched.</param>
        /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
        public CatalogedCredential LocateByService(string key) {
            foreach (var credential in AsCatalogedType) {
                if (credential.Service == key) {
                    return credential;
                    }
                }
            return null;
            }
        
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
        public CatalogCredential(
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


    public partial class CatalogedCredential {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => $"{Protocol ?? ""}:{Service ?? ""}";

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var stringBuilder = new StringBuilder();
            if (Protocol != null) {
                stringBuilder.Append($"{Protocol}:");
                }
            stringBuilder.AppendLine($"{Username}@{Service} = [{Password}]");

            return stringBuilder.ToString();

            }

        }
    #endregion


    }
