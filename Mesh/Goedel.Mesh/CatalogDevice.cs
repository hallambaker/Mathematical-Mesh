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

        }

    public partial class CatalogEntryDevice{
        /// <summary>
        /// The device connection assertion. This is set by either a new assertion being generated
        /// for a newly added device or by decoding the SignedDeviceConnection entry after 
        /// deserialization.
        /// </summary>
        public AssertionDeviceConnection AssertionDeviceConnection => assertionDeviceConnection ??
            AssertionDeviceConnection.Decode(SignedDeviceConnection);
        AssertionDeviceConnection assertionDeviceConnection = null;

        /// <summary>
        /// The device private assertion. This is set by either a new assertion being generated
        /// for a newly added device or by decoding the SignedDeviceConnection entry after 
        /// deserialization.
        /// </summary>
        public AssertionDevicePrivate AssertionDevicePrivate => assertionDevicePrivate ??
            AssertionDevicePrivate.Decode(EncryptedDevicePrivate);
        AssertionDevicePrivate assertionDevicePrivate = null;

        /// <summary>
        /// The primary key used to catalog the entry. This is the UDF of the authentication key.
        /// </summary>
        public override string _PrimaryKey => AuthUDF;



        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogEntryDevice() {
            }


        /// <summary>
        /// Constructor creating a new CatalogEntryDevice with a new AssertionDeviceConnection and
        /// complimentary AssertionDevicePrivate.
        /// </summary>
        /// <param name="profileMaster">The master profile the device is to be connected to.</param>
        /// <param name="profileDevice">The device profile to be connected.</param>
        public CatalogEntryDevice(IMeshMachine meshMachine, ProfileMaster profileMaster, ProfileDevice profileDevice) {
            var deviceSignature = profileDevice.KeySignature.KeyPair as KeyPairAdvanced;
            var deviceEncryption = profileDevice.KeyEncryption.KeyPair as KeyPairAdvanced;
            var deviceAuthentication = profileDevice.KeyAuthentication.KeyPair as KeyPairAdvanced;


            var overlaySignature = new KeyOverlay(meshMachine, deviceSignature);
            var overlayEncryption = new KeyOverlay(meshMachine, deviceEncryption);
            var overlayAuthentication = new KeyOverlay(meshMachine, deviceAuthentication);
           

            assertionDevicePrivate = new AssertionDevicePrivate() {
                ProfileDevice = profileDevice,
                KeySignature = overlaySignature,
                KeyEncryption = overlayEncryption,
                KeyAuthentication = overlayAuthentication
                };

            assertionDeviceConnection = new AssertionDeviceConnection() {
                ProfileMaster = profileMaster,
                KeySignature = new PublicKey (overlaySignature.KeyPair),
                KeyEncryption = new PublicKey (overlayEncryption.KeyPair),
                KeyAuthentication = new PublicKey (overlayAuthentication.KeyPair)
                };

            UDF = overlaySignature.KeyPair.UDF;
            AuthUDF = overlayAuthentication.KeyPair.UDF;
            DeviceUDF = profileDevice.UDF;
            }

        /// <summary>
        /// Create the SignedDeviceConnection and EncryptedDevicePrivate
        /// </summary>
        public virtual DareMessage Encode(KeyPair keyPair) {
            SignedDeviceConnection = AssertionDeviceConnection.Encode(keyPair);
            EncryptedDevicePrivate = AssertionDevicePrivate.Encode(keyPair);
            DareMessage = DareMessage.Encode(GetBytes(tag: true),
                    signingKey: keyPair, contentType: "application/mmm");
            return DareMessage;
            }


        public virtual void Activate(List<Permission> permission, Activation activation) {
            }


        public virtual void ActivateAdmin(Assertion assertion) {

            }


        public virtual void ActivateAccount(AssertionAccount assertionAccount, List<Permission> permission) {

            }

        public virtual void ActivateSSH(Assertion assertion) {

            }

        public virtual void ActivateMail(Assertion assertion) {

            }

        public virtual void ActivateGroup(Assertion assertion) {

            }


        }



    }
