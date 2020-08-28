using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Text;

namespace Goedel.Mesh {

    /// <summary>
    /// Interface providing access to the capabilities and publications catalog of an open transaction.
    /// </summary>
    public interface ITransactContextAccount {
        ///<summary>Returns the network catalog for the account</summary>
        CatalogPublication GetCatalogPublication();

        ///<summary>Returns the network catalog for the account</summary>
        CatalogCapability GetCatalogCapability();

        /// <summary>
        /// Append a request to append <paramref name="catalogedEntry"/> to the catalog
        /// <paramref name="catalog"/> to the transaction.
        /// </summary>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        /// <typeparam name="TEntry">The entry type.</typeparam>
        void CatalogUpdate<TEntry>(
                Catalog<TEntry> catalog,
                TEntry catalogedEntry) where TEntry : CatalogedEntry;

        /// <summary>
        /// Append a request to delete <paramref name="catalogedEntry"/> from the catalog
        /// <paramref name="catalog"/> to the transaction.
        /// </summary>
        /// <param name="catalog">The catalog to be updated</param>
        /// <param name="catalogedEntry">The entry to add as an update.</param>
        /// <typeparam name="TEntry">The entry type.</typeparam>
        void CatalogDelete<TEntry>(
                Catalog<TEntry> catalog,
                TEntry catalogedEntry) where TEntry : CatalogedEntry;
        }

    public partial class ActivationAccount {

        // Properties providing access to account-wide keys.

        ///<summary>The account profile signature key.</summary>
        public KeyPair PrivateProfileSignature { get; set; }

        ///<summary>The account administrator signature key bound to an administrator device.</summary>
        public KeyPair PrivateAdministratorSignature { get; private set; }

        ///<summary>The account encryption key under which inbound messages are encrypted.</summary>
        public KeyPair PrivateAccountEncryption { get; private set; }

        ///<summary>The account authentication key used to authenticate under the account.</summary>
        public KeyPair PrivateAccountAuthentication { get; private set; }

        ///<summary>The account signature key under which outbound messages are signed.</summary>
        public KeyPair PrivateAccountSignature { get; private set; }


        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationAccount> EnvelopedActivationAccount =>
            envelopedProfileUser ?? new Enveloped<ActivationAccount>(DareEnvelope).
                    CacheValue(out envelopedProfileUser);
        Enveloped<ActivationAccount> envelopedProfileUser;


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationAccount() {
            }

        /// <summary>
        /// Constructor returning an activation account for the seed <paramref name="secretSeed"/>.
        /// This constructor is used for generation of the initial account keys.
        /// </summary>
        /// <param name="keyCollection">The key collection to use.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        public ActivationAccount(
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed) {
            PrivateProfileSignature = secretSeed.BasePrivate(
                MeshKeyType.UserSign, keyCollection, KeySecurity.Exportable);
            PrivateAccountEncryption = secretSeed.BasePrivate(
                MeshKeyType.UserEncrypt, keyCollection, KeySecurity.Exportable);
            PrivateAccountAuthentication = secretSeed.BasePrivate(
                MeshKeyType.UserAuthenticate, keyCollection, KeySecurity.Exportable);
            PrivateAccountSignature = secretSeed.BasePrivate(
                MeshKeyType.UserSign, keyCollection, KeySecurity.Exportable);
            }


        ///// <summary>
        ///// Constructor returning an activation account for the devive
        ///// <paramref name="profileDevice"/> with the roles <paramref name="roles"/>.
        ///// </summary>
        ///// <param name="keyCollection">The key collection to use.</param>
        ///// <param name="profileDevice">The profile of the device being activated.</param>
        ///// <param name="roles">Roles to be granted.</param>
        //private ActivationAccount(
        //            IKeyCollection keyCollection,
        //            ProfileDevice profileDevice, 
        //            List<string> roles) : base(
        //                profileDevice, UdfAlgorithmIdentifier.MeshActivationUser) {
        //    ProfileDevice = profileDevice;


        //    //if (secretSeed != null) {
        //    //    // Generate the private keys
        //    //    PrivateAccountOfflineSignature = secretSeed.BasePrivate(
        //    //        MeshKeyType.UserSign, keyCollection, KeySecurity.Exportable);
        //    //    PrivateAccountEncryption = secretSeed.BasePrivate(
        //    //        MeshKeyType.UserEncrypt, keyCollection, KeySecurity.Exportable);
        //    //    PrivateAccountAuthentication = secretSeed.BasePrivate(
        //    //        MeshKeyType.UserAuthenticate, keyCollection, KeySecurity.Exportable);
        //    //    PrivateAccountOnlineSignature = keyPairOnlineSignature;
        //    //    }
        //    //else {
        //    //    // Attempt to pull private keys from storage
        //    //    Activate();
        //    //    }

        //    //if (keyPairOnlineSignature != null) {
        //    //    AccountOnlineSignature = AddCapability(keyPairOnlineSignature, profileDevice);

        //    //    }


        //    var access = new List<Right>();

        //    if (roles == null) {
        //        }
        //    else {
        //        foreach (var role in roles) {
        //            var rights = Rights.GetRights(role, out var subresource);
        //            access.Concat(rights);
        //            }
        //        }

        //    foreach (var right in access) {
        //        Grant(profileDevice, right);
        //        }

        //    }


        /// <summary>
        /// Add the device specified by <paramref name="profileDevice"/> to the account granting 
        /// the set of privileged specified in <paramref name="roles"/>.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to add.</param>
        /// <param name="profileUser">User profile to which the device is added.</param>
        /// <param name="roles">The initial roles to be assigned to the device. These will be expanded
        /// to a rights list.</param>
        /// <returns>The catalog entry.</returns>
        public CatalogedDevice MakeCatalogedDevice(
                        ProfileDevice profileDevice,
                        ProfileUser profileUser,
                        //KeyPair keyPairOnlineSignature = null, // hack. 
                        List<string> roles = null) {

            var activationUser = new ActivationDevice(profileDevice);
            var activationAccount = MakeActivationAccount(profileDevice, roles);

            var catalogedDevice = CreateCataloguedDevice(
                    profileUser, profileDevice, activationUser, activationAccount);



            return catalogedDevice;
            }

        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>
        /// and activation <paramref name="activationDevice"/>.
        /// </summary>
        /// <param name="profileUser">The mesh profile.</param>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <param name="activationDevice">The device key overlay.</param>
        /// <param name="activationAccount">The account key overlay.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        CatalogedDevice CreateCataloguedDevice(
                    ProfileUser profileUser,
                    ProfileDevice profileDevice,
                    ActivationDevice activationDevice,
                    ActivationAccount activationAccount) {

            //PrivateAccountOnlineSignature.AssertNotNull(NotAdministrator.Throw);


            profileUser.AssertNotNull(Internal.Throw);
            profileUser.DareEnvelope.AssertNotNull(Internal.Throw);
            profileDevice.AssertNotNull(Internal.Throw);
            profileDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            activationDevice.AssertNotNull(Internal.Throw);
            activationDevice.Package(PrivateAdministratorSignature);
            activationDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            activationAccount.AssertNotNull(Internal.Throw);
            activationAccount.Package(PrivateAdministratorSignature);
            activationAccount.DareEnvelope.AssertNotNull(Internal.Throw);


            var connectionDevice = activationDevice.ConnectionUser;
            connectionDevice.AssertNotNull(Internal.Throw);
            connectionDevice.Envelope(PrivateAdministratorSignature);
            connectionDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            // Wrap the connectionDevice and activationDevice in envelopes

            var catalogEntryDevice = new CatalogedDevice() {
                UDF = activationDevice.UDF,
                EnvelopedProfileUser = profileUser.EnvelopedProfileUser,
                EnvelopedProfileDevice = profileDevice.EnvelopedProfileDevice,
                EnvelopedConnectionUser = connectionDevice.EnvelopedConnectionUser,
                EnvelopedActivationDevice = activationDevice.EnvelopedActivationDevice,
                EnvelopedActivationAccount = activationAccount.EnvelopedActivationAccount,
                DeviceUDF = profileDevice.UDF
                };

            return catalogEntryDevice;
            }


        ActivationAccount MakeActivationAccount(
                ProfileDevice profileDevice,
                List<string> roles = null,
                ITransactContextAccount transactContextAccount=null
                ) {

            var activationAccount = new ActivationAccount {
                ProfileDevice = profileDevice
                };

            // Compile the accumulated set of rights.
            var rights = new List<Right>();
            if (roles == null) {
                }
            else {
                foreach (var role in roles) {
                    var rightsRole = Rights.GetRights(role, out var subresource);
                    rights.Concat(rightsRole);
                    }
                }

            // Grant each right
            foreach (var right in rights) {
                Grant(activationAccount, right);
                }


            return activationAccount;

            }







        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.KeyEncryption"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindEncryption(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.KeyEncryption.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }

        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.OfflineSignature"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindSignature(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.OfflineSignature.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }

        /// <summary>
        /// Create a key pair bound to the private key <paramref name="profileDevice.KeyAuthentication"/>
        /// The public parameters of the returned key represent the combined parameters, the 
        /// private parameters represent the offset from the device key.
        /// </summary>
        /// <param name="profileDevice">Profile providing the base key.</param>
        /// <param name="keyCollection">Key collection in which the resulting key is to be stored.</param>
        /// <returns>The bound key pair.</returns>
        public static KeyPair DeviceBindAuthentication(
                    ProfileDevice profileDevice,
                    IKeyCollection keyCollection) {
            return KeyPair.FactorySignature(profileDevice.KeyAuthentication.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);
            }




        /// <summary>
        /// Generate a capability for the key <paramref name="keyPair"/>.
        /// add the service portion to the capabilities catalog.
        /// </summary>
        /// <param name="keyPair">Keypair from which the capability is to be derrived.</param>
        /// <param name="profileDevice">The device to which the capability is to be added.</param>
        /// <returns>The key data for the added capability.</returns>
        public KeyData AddCapability(CryptoKey keyPair, ProfileDevice profileDevice) {
            "**** MUST add keys to devices as shared capabilities".TaskFunctionality();

            //var catalogCapability = GetCatalogCapability();

            return new KeyData(keyPair, true);
            }


        void Grant(ActivationAccount activationAccount, Right right) {

            switch (right.Resource) {
                case Resource.ProfileRoot: {
                    GrantProfileRoot(activationAccount, right);
                    break;
                    }
                case Resource.ProfileAdmin: {
                    GrantProfileAdmin(activationAccount, right);
                    break;
                    }
                case Resource.Store: {
                    GrantStore(activationAccount, right);
                    break;
                    }
                case Resource.Account: {
                    GrantAccount(activationAccount, right);
                    break;
                    }
                }

            }

        /// <summary>
        /// Grant super administrator access.
        /// </summary>
        /// <param name="activationAccount">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantProfileRoot(ActivationAccount activationAccount, Right right) {
            right.Future();
            activationAccount.ProfileSignature = AddCapability(
                        PrivateProfileSignature, activationAccount.ProfileDevice);
            }

        /// <summary>
        /// Grant device administrator access.
        /// </summary>
        /// <param name="activationAccount">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantProfileAdmin(
                            ActivationAccount activationAccount,
                            Right right) {
            right.Future();
            var keyPairOnlineSignature = DeviceBindSignature(activationAccount.ProfileDevice, KeyCollection);
            activationAccount.AdministratorSignature = AddCapability(
                        keyPairOnlineSignature, activationAccount.ProfileDevice);
            }


        /// <summary>
        /// Grant access to global account.
        /// </summary>
        /// <param name="activationAccount">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantAccount(ActivationAccount activationAccount, Right right) {
            if (right.Decrypt) {
                activationAccount.AccountEncryption = AddCapability(
                            PrivateAccountEncryption, activationAccount.ProfileDevice);
                }
            if (right.Authenticate) {
                activationAccount.AccountAuthentication = AddCapability(
                            PrivateAccountAuthentication, activationAccount.ProfileDevice);
                }
            if (right.Sign) {
                activationAccount.AccountSignature = AddCapability(
                            PrivateAccountSignature, activationAccount.ProfileDevice);
                }

            }

        /// <summary>
        /// Grant access to the store X.
        /// </summary>
        /// <param name="activationAccount">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantStore(ActivationAccount activationAccount, Right right) {
            right.Future();
            activationAccount.Future();


            // which store do we need?


            // pull the decryption key


            // grant the decryption key.

            }




        /// <summary>
        /// Activate the keys bound to this activation record.
        /// </summary>

        public void Activate(IKeyCollection keyCollection) {

            // Need to work out how to add these into the relevant key collections.


            PrivateProfileSignature = ProfileSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAdministratorSignature = AdministratorSignature?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountEncryption = AccountEncryption?.GetKeyPair(KeySecurity.Exportable);
            PrivateAccountAuthentication = AccountAuthentication?.GetKeyPair(KeySecurity.Exportable);

            if (PrivateAccountEncryption != null) {
                keyCollection.Add(PrivateAccountEncryption);
                }
            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The key collection 
        /// <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The Key collection.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Activation Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;


            }
        }

    }
