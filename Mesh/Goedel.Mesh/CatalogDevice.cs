using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryDevice : IEnumerator<CatalogEntryDevice> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryDevice Current => BaseEnumerator.Current.JsonObject as CatalogEntryDevice;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryDevice(ContainerPersistenceStore container) => BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryDevice : IEnumerable<CatalogEntryDevice> {
        CatalogDevice Catalog;

        public AsCatalogEntryDevice(CatalogDevice catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryDevice> GetEnumerator() =>
                    new EnumeratorCatalogEntryDevice(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogDevice : Catalog {
        public const string Label = "CatalogDevice";


        public override string ContainerDefault => Label;
        public AsCatalogEntryDevice AsCatalogEntryDevice => new AsCatalogEntryDevice(this);

        public CatalogEntryCredential LocateBySite(string Key) => Locate(Key) as CatalogEntryCredential;


        public CatalogDevice(string directory, string containerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, containerName?? Label, cryptoParameters, keyCollection) {
            }

        }

    public partial class CatalogEntryDevice{

        public ProfileMeshDevicePublic ProfileMeshDevicePublic => profileMeshDevicePublic ??
            ProfileMeshDevicePublic.Decode(ProfileMeshDevicePublicSigned);
        ProfileMeshDevicePublic profileMeshDevicePublic = null;

        public ProfileMeshDevicePrivate ProfileMeshDevicePrivate => profileMeshDevicePrivate ??
            ProfileMeshDevicePrivate.Decode(ProfileMeshDevicePrivateEncrypted);
        ProfileMeshDevicePrivate profileMeshDevicePrivate = null;


        public override string _PrimaryKey => UDF;
        }



    }
