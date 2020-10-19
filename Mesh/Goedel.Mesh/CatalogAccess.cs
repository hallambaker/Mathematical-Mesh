//  Copyright © 2020 Threshold Secrets llc
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {


    #region // The data classes CatalogMember, CatalogedMember
    /// <summary>
    /// Capability catalog. Contains keys used to perform capabilities.
    /// </summary>
    public class CatalogAccess : Catalog<CatalogedAccess> {
        #region // Properties
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = MeshConstants.MMM_Access;

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;


        ///<summary>Dictionary for locating capabilities for use.</summary>
        public Dictionary<string, CapabilityDecrypt> DictionaryDecryptByKeyId =
                new Dictionary<string, CapabilityDecrypt>();

        ///<summary>Dictionary for locating capabilities for use.</summary>
        public Dictionary<string, CapabilitySign> DictionarySignByAccountAddress =
                new Dictionary<string, CapabilitySign>();

        ///<summary>Dictionary for locating capabilities for use.</summary>
        public Dictionary<string, CapabilityKeyGenerate> DictionaryKeyGenerate =
                new Dictionary<string, CapabilityKeyGenerate>();

        ///<summary>Dictionary for locating capabilities for use.</summary>
        public Dictionary<string, CapabilityFairExchange> DictionaryFairExchange =
                new Dictionary<string, CapabilityFairExchange>();

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
        /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
        public static new Store Factory(
                string directory,
                    string storeId,
                    IMeshClient meshClient,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) =>
            new CatalogAccess(directory, storeId, cryptoParameters, keyCollection, meshClient, decrypt:decrypt, create:create);


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
        /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
        public CatalogAccess(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    IMeshClient meshClient = null,
                    bool decrypt = true,
                    bool create = true) :
                    base(directory, storeName ?? Label,
                        cryptoParameters, keyCollection, meshClient: meshClient, decrypt: decrypt, create: create) {

            // Hack: likely to have issues here because the CatalogAccess needs to be readable by the service
            // Should treat this like any other account except that the service is granted access when it
            // connects.


            }
        #endregion
        #region // Class methods
        /// <summary>
        /// Resolve a decryption capability corresponding to the key <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The identifier of the public key to obtain a decryption 
        /// capability against.</param>
        /// <returns>The decryption capability if found, otherwise null.</returns>
        public IKeyDecrypt TryFindKeyDecryption(string keyId) {
            DictionaryDecryptByKeyId.TryGetValue(keyId, out var result);

            return result;
            }

        /// <summary>
        /// Resolve a signing capability for the key <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The identifier of the public key to obtain a signature 
        /// capability for.</param>
        /// <returns>The signing capability if found, otherwise null.</returns>
        public IKeySign TryFindKeySign(string keyId) {
            DictionarySignByAccountAddress.TryGetValue(keyId, out var result);

            return result;
            }

        /// <summary>
        /// Resolve a key share generation capability for the key <paramref name="keyId"/>
        /// </summary>
        /// <param name="keyId">The identifier of the public key to obtain a key share 
        /// generation capability for.</param>
        /// <returns>The key share generation capability if found, otherwise null.</returns>
        public CapabilityKeyGenerate TryFindKeyGenerate(string keyId) {
            DictionaryKeyGenerate.TryGetValue(keyId, out var result);

            return result;
            }


        /// <summary>
        /// Add <paramref name="capability"/> to the catalog, encrypting the data under
        /// <paramref name="encryptionKey"/> if that turns out to be a good idea.
        /// </summary>
        /// <param name="capability">Capability to add.</param>
        /// <param name="encryptionKey">Stub for possible encryption key entry.</param>
        public void Add(
                    CryptographicCapability capability,
                    CryptoKey encryptionKey = null
                    ) {
            var catalogedCapability = new CatalogedAccess(capability);
            New(catalogedCapability, encryptionKey);
            }

        /// <summary>
        /// Callback called before adding a new entry to the catalog. Overriden to update the values
        /// in the dictionaries serving key discovery.
        /// </summary>
        /// <param name="catalogedEntry">The entry being added.</param>
        public override void NewEntry(CatalogedAccess catalogedEntry) => UpdateLocal(catalogedEntry);


        /// <summary>
        /// Callback called before updating an entry in the catalog. Overriden to update the values
        /// in the dictionaries serving key discovery.
        /// </summary>
        /// <param name="catalogedEntry">The entry being updated.</param>
        public override void UpdateEntry(CatalogedAccess catalogedEntry) => UpdateLocal(catalogedEntry);

        void UpdateLocal(CatalogedEntry catalogedEntry) {
            var catalogedCapability = catalogedEntry as CatalogedAccess;
            switch (catalogedCapability.Capability) {
                case CapabilityDecrypt capabilityDecryption: {
                    DictionaryDecryptByKeyId.Add(capabilityDecryption.SubjectId,
                        capabilityDecryption);

                    if (capabilityDecryption is ICapabilityPartial meshClientCapability) {
                        meshClientCapability.CryptographicClient = this.MeshClient;
                        }

                    break;
                    }
                case CapabilitySign capabilityAdministrator: {
                    DictionarySignByAccountAddress.Add(capabilityAdministrator.SubjectAddress,
                        capabilityAdministrator);
                    break;
                    }
                case CapabilityKeyGenerate capabilityKeyGenerate: {
                    DictionaryKeyGenerate.Add(capabilityKeyGenerate.SubjectId,
                        capabilityKeyGenerate);
                    break;
                    }
                case CapabilityFairExchange capabilityFairExchange: {
                    DictionaryFairExchange.Add(capabilityFairExchange.SubjectAddress,
                        capabilityFairExchange);
                    break;
                    }
                }
            }
        #endregion
        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedAccess {
        #region // Properties
        /// <summary>
        /// The primary key used to catalog the entry, this is the identifier of the key.
        /// </summary>
        public override string _PrimaryKey => Capability._PrimaryKey;
        #endregion
        #region // Factory methods and constructors
        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public CatalogedAccess() { }

        /// <summary>
        /// Create a cataloged capability for <paramref name="capability"/>.
        /// </summary>
        public CatalogedAccess(CryptographicCapability capability) => Capability = capability;
        #endregion
        }



    #endregion

    }
