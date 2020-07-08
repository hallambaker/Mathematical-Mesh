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
    public class CatalogCapability : Catalog {

        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Capability";


        //public CatalogedMember Self { get; set; }


        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedMember instances.</summary>
        public AsCatalogedCapability AsCatalogedMember => new AsCatalogedCapability(this);


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


        //public CatalogedMember LocateByID(string Key) => Locate(Key) as CatalogedMember;


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
        public CatalogCapability(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

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
            var catalogedCapability = new CatalogedCapability(capability);
            New(catalogedCapability, encryptionKey);
            }

        /// <summary>
        /// Callback called before adding a new entry to the catalog. Overriden to update the values
        /// in the dictionaries serving key discovery.
        /// </summary>
        /// <param name="catalogedEntry">The entry being added.</param>
        protected override void NewEntry(CatalogedEntry catalogedEntry) => UpdateLocal(catalogedEntry);


        /// <summary>
        /// Callback called before updating an entry in the catalog. Overriden to update the values
        /// in the dictionaries serving key discovery.
        /// </summary>
        /// <param name="catalogedEntry">The entry being updated.</param>
        protected override void UpdateEntry(CatalogedEntry catalogedEntry) => UpdateLocal(catalogedEntry);

        void UpdateLocal(CatalogedEntry catalogedEntry) {
            var catalogedCapability = catalogedEntry as CatalogedCapability;
            switch (catalogedCapability.Capability) {
                case CapabilityDecrypt capabilityDecryption: {
                    DictionaryDecryptByKeyId.Add(capabilityDecryption.SubjectId,
                        capabilityDecryption);
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



        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedCapability {

        /// <summary>
        /// The primary key used to catalog the entry, this is the identifier of the key.
        /// </summary>
        public override string _PrimaryKey => Capability._PrimaryKey;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public CatalogedCapability() { }


        /// <summary>
        /// Create a cataloged capability for <paramref name="capability"/>.
        /// </summary>
        public CatalogedCapability(CryptographicCapability capability) => Capability = capability;

        }



    #endregion
    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedMember"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogedCapability : IEnumerator<CatalogedCapability> {
        IEnumerator<StoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedCapability Current => baseEnumerator.Current.JsonObject as CatalogedCapability;
        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => baseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns><see langword="true"/> if there was a next item to return, otherwise,
        /// <see langword="false"/>.</returns>
        public bool MoveNext() => baseEnumerator.MoveNext();

        /// <summary>
        /// Restart the enumeration.
        /// </summary>
        public void Reset() => throw new NotImplementedException();

        /// <summary>
        /// Construct enumerator from <see cref="PersistenceStore"/>,
        /// <paramref name="persistenceStore"/>.
        /// </summary>
        /// <param name="persistenceStore">The persistence store to enumerate.</param>
        public EnumeratorCatalogedCapability(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
    /// </summary>
    public class AsCatalogedCapability : IEnumerable<CatalogedCapability> {
        CatalogCapability catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogMember"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogedCapability(CatalogCapability catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedCapability> GetEnumerator() =>
                    new EnumeratorCatalogedCapability(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion


    }
