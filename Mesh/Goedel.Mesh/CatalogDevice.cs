using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryDevice : IEnumerator<CatalogedDevice> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedDevice Current => BaseEnumerator.Current.JsonObject as CatalogedDevice;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryDevice(ContainerPersistenceStore container) => BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryDevice : IEnumerable<CatalogedDevice> {
        CatalogDevice Catalog;

        public AsCatalogEntryDevice(CatalogDevice catalog) => Catalog = catalog;

        public IEnumerator<CatalogedDevice> GetEnumerator() =>
                    new EnumeratorCatalogEntryDevice(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogDevice : Catalog {
        public const string Label = "mmm_Device";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;
        ///<summary>Enumerate the catalog as CatalogEntryDevice instances.</summary>
        public AsCatalogEntryDevice AsCatalogEntryDevice => new AsCatalogEntryDevice(this);


        /// <summary>
        /// Constructor for a catalog named <paramref name="containerName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="containerName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
        public CatalogDevice(string directory, string containerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, containerName?? Label, cryptoParameters, keyCollection) {
            }


        public CatalogedDevice Get(string key) => Locate(key) as CatalogedDevice;

        }

    public partial class CatalogedDevice{
        /// <summary>
        /// The primary key used to catalog the entry. This is the UDF of the authentication key.
        /// </summary>
        public override string _PrimaryKey => UDF;

        /// <summary>
        /// The device connection assertion. This is set by either a new assertion being generated
        /// for a newly added device or by decoding the SignedDeviceConnection entry after 
        /// deserialization.
        /// </summary>
        public ConnectionDevice AssertionDeviceConnection => assertionDeviceConnection ??
            ConnectionDevice.Decode(EnvelopedDeviceConnection).CacheValue(out assertionDeviceConnection);
        ConnectionDevice assertionDeviceConnection = null;


        public ProfileDevice ProfileDevice => profileDevice ??
                ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;



        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogedDevice() {
            }



        public virtual void Activate(List<Permission> permission, Activation activation) {
            }


        public virtual void ActivateAdmin(Assertion assertion) {

            }


        public virtual void ActivateAccount(ProfileAccount assertionAccount, List<Permission> permission) {

            }

        public virtual void ActivateSSH(Assertion assertion) {

            }

        public virtual void ActivateMail(Assertion assertion) {

            }

        public virtual void ActivateGroup(Assertion assertion) {

            }


        }


    }
