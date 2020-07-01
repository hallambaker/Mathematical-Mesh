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



        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedCapability {

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => SubjectId;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public CatalogedCapability() { }

        ///// <summary>
        ///// Create a member for the specified contact.
        ///// </summary>
        ///// <param name="contact"></param>
        //public CatalogedMember(DareEnvelope contact) : this() { }
        ////=> EnvelopedContact = contact;

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
