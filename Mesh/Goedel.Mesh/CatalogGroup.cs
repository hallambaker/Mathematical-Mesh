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
    public class CatalogMember : Catalog {

        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm/Member";


        //public CatalogedMember Self { get; set; }


        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedMember instances.</summary>
        public AsCatalogedMember AsCatalogedMember => new AsCatalogedMember(this);


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
        public CatalogMember(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }


        //public void Add(DareEnvelope contact, bool self = false) {

        //    "Implement the add group member function".TaskFunctionality();

        //    var entry = new CatalogedMember(contact) {
        //        };
        //    New(entry);
        //    }

        //public void Add(Contact contact, bool self = false) => Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);

        //public CatalogedMember Add(string memberID) => throw new NYI();

        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedMember {

        /// <summary>
        /// The primary key used to catalog the entry.
        /// </summary>
        public override string _PrimaryKey => UDF;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public CatalogedMember() { }

        ///// <summary>
        ///// Create a member for the specified contact.
        ///// </summary>
        ///// <param name="contact"></param>
        //public CatalogedMember(DareEnvelope contact) : this() { }
        ////=> EnvelopedContact = contact;

        }

    public partial class CatalogedGroup {


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
    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedMember"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogedMember : IEnumerator<CatalogedMember> {
        IEnumerator<StoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedMember Current => baseEnumerator.Current.JsonObject as CatalogedMember;
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
        public EnumeratorCatalogedMember(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
    /// </summary>
    public class AsCatalogedMember : IEnumerable<CatalogedMember> {
        CatalogMember catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogMember"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogedMember(CatalogMember catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedMember> GetEnumerator() =>
                    new EnumeratorCatalogedMember(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion


    }
