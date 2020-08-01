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
    public class CatalogDevice : Catalog<CatalogedDevice> {
        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Device";

        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

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
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                        cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        /// <summary>
        /// Return a string describing the catalog entries.
        /// </summary>
        /// <returns>The string describing the catalog entries.</returns>
        public string Report() {

            var builder = new StringBuilder();
            foreach (var catalog in AsCatalogedType) {
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


        /// <summary>
        /// The device connection assertion. This is set by either a new assertion being generated
        /// for a newly added device or by decoding the SignedDeviceConnection entry after 
        /// deserialization.
        /// </summary>
        public ConnectionDevice ConnectionDevice => connectionDevice ??
            ConnectionDevice.Decode(EnvelopedConnectionDevice).CacheValue(out connectionDevice);
        ConnectionDevice connectionDevice = null;



        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileMesh"/>
        ///to return the <see cref="ProfileAccount"/> value.</summary>
        public ProfileUser ProfileAccount => profileAccount ??
            ProfileUser.Decode(EnvelopedProfileMesh).CacheValue(out profileAccount);
        ProfileUser profileAccount;


        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileDevice"/>
        ///to return the <see cref="ProfileDevice"/> value.</summary>
        public ProfileDevice ProfileDevice => profileDevice ??
                ProfileDevice.Decode(EnvelopedProfileDevice).CacheValue(out profileDevice);
        ProfileDevice profileDevice;

        ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedActivationDevice"/>
        ///to return the <see cref="ActivationDevice"/> value.</summary>
        public ActivationDevice GetActivationDevice(IKeyCollection keyCollection) =>
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
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {


            builder.AppendIndent(indent, $"ContextDevice");

            indent++;
            builder.AppendIndent(indent, $"Base UDF {DeviceUDF}");
            builder.AppendIndent(indent, $"Mesh UDF {UDF}");
            DareEnvelope.Report(builder);

            ProfileAccount.ToBuilder(builder, indent, "[Profile Mesh Missing]");
            ProfileDevice.ToBuilder(builder, indent, "[Profile Device Missing]");
            ConnectionDevice.ToBuilder(builder, indent, "[Connection Device Missing]");
            GetActivationDevice(keyCollection).ToBuilder(builder, indent, "[Activation Device Missing]");

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
                    account.GetActivationAccount(keyCollection).ToBuilder(builder, indent, "[Profile Device Missing]");
                    }

                }

            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="CatalogedDevice"/>
        /// using keys from <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new CatalogedDevice Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as CatalogedDevice;



        /// <summary>
        /// Match the specified account entry.
        /// </summary>
        /// <param name="localName">Local name to match</param>
        /// <param name="accountName">Service identifier to match</param>
        /// <returns>The account if found, otherwise null.</returns>
        public AccountEntry GetAccount(string localName = null,
                string accountName = null) {
            localName.Future();

            if (Accounts == null || Accounts.Count == 0) {
                return null;
                }
            if (accountName == null) {
                return Accounts[0];
                }

            foreach (var account in Accounts) {
                if (account.ProfileAccount.MatchAccountAddress(accountName) >= 0) {
                    return account;
                    }
                }

            return null;
            }

        /// <summary>
        /// Verify the Catalogued Device information and verify that it is all correctly signed.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate() {

            // Verify the master profile is correctly self signed.
            ProfileAccount.Validate();

            // Verify the device profile is correctly self signed.
            ProfileDevice.Validate();

            // Verify that the connection and activation entries are signed under the master profile
            ProfileAccount.Verify(EnvelopedConnectionDevice);
            ProfileAccount.Verify(EnvelopedActivationDevice);

            // Verify that each connected account is correct.
            foreach (var account in Accounts) {
                account.Validate();
                }

            return true; // this will probably turn into exception return.
            }
        }


    #endregion


    }
