using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogedMember : IEnumerator<CatalogedMember> {
        IEnumerator<ContainerStoreEntry> baseEnumerator;

        public CatalogedMember Current => baseEnumerator.Current.JsonObject as CatalogedMember;
        object IEnumerator.Current => Current;
        public void Dispose() => baseEnumerator.Dispose();
        public bool MoveNext() => baseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogedMember(ContainerPersistenceStore container) =>
            baseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogedMember : IEnumerable<CatalogedMember> {
        CatalogMember catalog;

        public AsCatalogedMember(CatalogMember catalog) => this.catalog = catalog;

        public IEnumerator<CatalogedMember> GetEnumerator() =>
                    new EnumeratorCatalogedMember(catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogMember : Catalog {
        public const string Label = "mmm_Member";

        public CatalogedMember Self;



        public override string ContainerDefault => Label;

        public AsCatalogedMember AsCatalogEntryContact => new AsCatalogedMember(this);


        public CatalogedMember LocateByID(string Key) => Locate(Key) as CatalogedMember;


        public CatalogMember(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        public void Add(DareEnvelope contact, bool self = false) {

            "Implement the add group member function".TaskFunctionality();

            var entry = new CatalogedMember(contact) {
                };
            New(entry);
            }

        public void Add(Contact contact, bool self = false) => Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);

        public CatalogedMember Add(string memberID) => throw new NYI();

        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedMember {


        public override string _PrimaryKey => UDF;

        public CatalogedMember() { }

        public CatalogedMember(DareEnvelope contact) : this() { }
        //=> EnvelopedContact = contact;

        }

    public partial class CatalogedGroup {

        public CatalogedGroup() {
            }


        public CatalogedGroup(ProfileGroup profileGroup) => Profile = profileGroup;

        }

    }
