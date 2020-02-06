using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {


    #region // The data classes CatalogDevice, CatalogedDevice
    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>
    public class CatalogDevice : Catalog {
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm/Device";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedDevice instances.</summary>
        public AsCatalogedDevice AsCatalogEntryDevice => new AsCatalogedDevice(this);

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
        public CatalogDevice(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label, 
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        /// <summary>
        /// Return the catalogued device with key <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of the device to return.</param>
        /// <returns>The <see cref="CatalogedDevice"/> entry.</returns>
        public CatalogedDevice Get(string key) => Locate(key) as CatalogedDevice;


        //public override bool Transact(Catalog catalog, List<CatalogUpdate> updates) {
        //    Console.WriteLine("  Device transaction!");

        //    return base.Transact(catalog, updates);

        //    }

        /// <summary>
        /// Return a string describing the catalog entries.
        /// </summary>
        /// <returns>The string describing the catalog entries.</returns>
        public string Report() {

            var builder = new StringBuilder();
            foreach (var catalog in AsCatalogEntryDevice) {
                catalog.ToBuilder(builder, 1);
                }

            return builder.ToString();
            }


        }

    public partial class CatalogedDevice {
        /// <summary>
        /// The primary key used to catalog the entry. This is the UDF of the authentication key.
        /// </summary>
        public override string _PrimaryKey => DeviceUDF;

        KeyCollection keyCollection;


        /// <summary>
        /// The device connection assertion. This is set by either a new assertion being generated
        /// for a newly added device or by decoding the SignedDeviceConnection entry after 
        /// deserialization.
        /// </summary>
        public ConnectionDevice ConnectionDevice => connectionDevice ??
            ConnectionDevice.Decode(EnvelopedConnectionDevice).CacheValue(out connectionDevice);
        ConnectionDevice connectionDevice = null;

        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileMesh"/>
        ///to return the <see cref="ProfileMesh"/> value.</summary>
        public ProfileMesh ProfileMesh => profileMesh ??
            ProfileMesh.Decode(EnvelopedProfileMesh).CacheValue(out profileMesh);
        ProfileMesh profileMesh;

        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileDevice"/>
        ///to return the <see cref="ProfileDevice"/> value.</summary>
        public ProfileDevice ProfileDevice => profileDevice ??
                ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;

        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedActivationDevice"/>
        ///to return the <see cref="ActivationDevice"/> value.</summary>
        public ActivationDevice GetActivationDevice(KeyCollection keyCollection) =>
            activationDevice ?? (keyCollection == null ? null :
                ActivationDevice.Decode(EnvelopedActivationDevice, keyCollection).CacheValue(out activationDevice));
        ActivationDevice activationDevice;

        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public CatalogedDevice() {
            }


        /// <summary>
        /// Convert the cataloged device to a string.
        /// </summary>
        /// <returns>The string describing the cataloged device.</returns>
        public override string ToString() {
            var builder = new StringBuilder();
            ToBuilder(builder, 0);
            return builder.ToString();
            }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

            builder.AppendIndent(indent, $"ContextDevice");

            indent++;
            builder.AppendIndent(indent, $"Base UDF {DeviceUDF}");
            builder.AppendIndent(indent, $"Mesh UDF {UDF}");
            DareEnvelope.Report(builder);

            ProfileMesh.ToBuilder(builder, indent, "[Profile Mesh Missing]");
            ProfileDevice.ToBuilder(builder, indent, "[Profile Device Missing]");
            ConnectionDevice.ToBuilder(builder, indent, "[Connection Device Missing]");
            GetActivationDevice(machine?.KeyCollection).ToBuilder(builder, indent, "[Activation Device Missing]");

            if (Accounts == null) {
                builder.AppendIndent(indent, $"Accounts: None");
                }
            else {
                builder.AppendIndent(indent, $"Accounts: {Accounts.Count}");
                indent++;
                foreach (var account in Accounts) {
                    builder.AppendIndent(indent, $"Account Entry {account.AccountUDF}");

                    account.ProfileAccount.ToBuilder(builder, indent, "[Profile Account Missing]");
                    account.ConnectionAccount.ToBuilder(builder, indent, "[Profile Device Missing]");
                    account.GetActivationAccount(machine?.KeyCollection).ToBuilder(builder, indent, "[Profile Device Missing]");
                    }

                }

            }

        /// <summary>
        /// Decode the envelope <paramref name="envelope"/> using keys from 
        /// <paramref name="keyCollection"/> and return the resulting <see cref="CatalogedDevice"/>.
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Keys to be used to decode <paramref name="envelope"/>.</param>
        /// <returns>The decoded <see cref="CatalogedDevice"/> (if successful).</returns>
        public static CatalogedDevice Decode(DareEnvelope envelope, KeyCollection keyCollection) {
            if (envelope == null) {
                return null;
                }

            var plaintext = envelope.GetPlaintext(keyCollection);

            Console.WriteLine(plaintext.ToUTF8());
            var result = FromJSON(plaintext.JSONReader(), true);
            result.DareEnvelope = envelope;
            result.keyCollection = keyCollection;
            return result;
            }


        /// <summary>
        /// Match the specified account entry.
        /// </summary>
        /// <param name="localName">Local name to match</param>
        /// <param name="accountName">Service identifier to match</param>
        /// <returns>The account if found, otherwise null.</returns>
        public AccountEntry GetAccount(string localName = null,
                string accountName = null) {

            if (Accounts == null || Accounts.Count == 0) {
                return null;
                }


            if (accountName == null) {
                return Accounts[0];

                }

            foreach (var account in Accounts) {
                if (account.ProfileAccount.MatchService(accountName) >= 0) {
                    return account;
                    }
                }

            return null;
            }



        //public virtual void Activate(List<Permission> permission, Activation activation) {
        //    }


        //public virtual void ActivateAdmin(Assertion assertion) {

        //    }


        //public virtual void ActivateAccount(ProfileAccount assertionAccount, List<Permission> permission) {

        //    }

        //public virtual void ActivateSSH(Assertion assertion) {

        //    }

        //public virtual void ActivateMail(Assertion assertion) {

        //    }

        //public virtual void ActivateGroup(Assertion assertion) {

        //    }


        /// <summary>
        /// Verify the Catalogued Device information and verify that it is all correctly signed.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate() {

            // Verify the master profile is correctly self signed.
            ProfileMesh.Validate();

            // Verify the device profile is correctly self signed.
            ProfileDevice.Validate();

            // Verify that the connection and activation entries are signed under the master profile
            ProfileMesh.Verify(EnvelopedConnectionDevice);
            ProfileMesh.Verify(EnvelopedActivationDevice);

            // Verify that each connected account is correct.
            foreach (var account in Accounts) {
                account.Validate();
                }

            return true; // this will probably turn into exception return.
            }


        }


    #endregion

    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryDevice : IEnumerator<CatalogedDevice> {
        IEnumerator<ContainerStoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedDevice Current => baseEnumerator.Current.JsonObject as CatalogedDevice;
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
        public EnumeratorCatalogEntryDevice(PersistenceStore persistenceStore) => baseEnumerator = persistenceStore.GetEnumerator();
        }


    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedDevice"/> over a Catalog
    /// </summary>
    public class AsCatalogedDevice : IEnumerable<CatalogedDevice> {
        CatalogDevice catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogDevice"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogedDevice(CatalogDevice catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedDevice> GetEnumerator() =>
                    new EnumeratorCatalogEntryDevice(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion

    }
