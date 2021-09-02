﻿#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using System.Collections.Generic;
using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh {

    /// <summary>
    /// Interface providing access to the capabilities and publications catalog of an open transaction.
    /// </summary>
    public interface ITransactContextAccount {
        ///<summary>Returns the network catalog for the account</summary>
        CatalogPublication GetCatalogPublication();

        ///<summary>Returns the network catalog for the account</summary>
        CatalogAccess GetCatalogAccess();

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

        string AccountId { get; }

        ProfileService ProfileService { get; }

        ConnectionDevice ConnectionDevice { get; }

        }

    public partial class ActivationAccount {
        // Properties providing access to account-wide keys.


        public string AccountDeviceId => AccountAuthenticationKey.KeyIdentifier;



        ///<summary>The account profile signature key.</summary>
        public KeyPair ProfileSignatureKey { get; set; }

        ///<summary>The account administrator signature key bound to an administrator device.</summary>
        public KeyPair AdministratorSignatureKey { get; private set; }

        ///<summary>The account administrator signature key bound to an administrator device.</summary>
        public KeyPair AdministratorEncryptionKey { get; private set; }

        ///<summary>The account encryption key under which inbound messages are encrypted.</summary>
        public KeyPair AccountEncryptionKey { get; private set; }

        ///<summary>The account authentication key used to authenticate under the account.</summary>
        public KeyPair AccountAuthenticationKey { get; private set; }

        ///<summary>The account signature key under which outbound messages are signed.</summary>
        public KeyPair AccountSignatureKey { get; private set; }

        ///<summary>The service profile</summary> 
        public ProfileService ProfileService;

        ///<summary>The account signature key under which outbound messages are signed.</summary>
        public KeyPair ServiceEncryptionKey { get; private set; }

        ///<summary>The enveloped object</summary> 
        public Enveloped<ActivationAccount> EnvelopedActivationAccount =>
            envelopedActivationAccount ?? new Enveloped<ActivationAccount>(DareEnvelope).
                    CacheValue(out envelopedActivationAccount);
        Enveloped<ActivationAccount> envelopedActivationAccount;

        ///<summary>Dictionary mapping store names to encryption keys.</summary> 
        public Dictionary<string, KeyPair> DictionaryStoreEncryptionKey =
            new();

        PrivateKeyUDF secretSeed;


        public ActivationDevice ActivationDevice;


        ///<summary>The default status of the device connection</summary> 
        public bool DefaultActive { get; set; }  = false;

        public ConnectionDevice ConnectionDevice { get; set; }


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
                    PrivateKeyUDF secretSeed) => ActivateFromSeed(keyCollection, secretSeed);

        void ActivateFromSeed(
                    IKeyCollection keyCollection,
                    PrivateKeyUDF secretSeed) {
            this.secretSeed = secretSeed;
            ProfileSignatureKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.Profile,
                keyCollection, KeySecurity.Exportable);
            AdministratorSignatureKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.AdminSign,
                keyCollection, KeySecurity.Exportable);
            AdministratorEncryptionKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.AdminEncrypt,
                keyCollection, KeySecurity.Exportable);
            AccountEncryptionKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.Encrypt,
                keyCollection, KeySecurity.Exportable);
            AccountAuthenticationKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.Authenticate,
                keyCollection, KeySecurity.Exportable);
            AccountSignatureKey = secretSeed.GenerateContributionKeyPair(
                MeshKeyType.Complete, MeshActor.Account, MeshKeyOperation.Sign,
                keyCollection, KeySecurity.Exportable);
            }


        /// <summary>
        /// Activate the keys bound to this activation record.
        /// </summary>

        public void Activate(IKeyCollection keyCollection) {

            if (ActivationKey != null) {
                var secretSeed = new PrivateKeyUDF(ActivationKey);
                ActivateFromSeed(keyCollection, secretSeed);
                return;
                }

            ProfileSignatureKey = ProfileSignature?.GetKeyPair(
                    KeySecurity.Exportable, keyCollection);
            AdministratorSignatureKey = AdministratorSignature?.GetKeyPair
                    (KeySecurity.Exportable, keyCollection);
            AccountEncryptionKey = AccountEncryption?.GetKeyPair(
                    KeySecurity.Exportable, keyCollection);
            AccountAuthenticationKey = AccountAuthentication?.GetKeyPair(
                    KeySecurity.Exportable, keyCollection);
            AccountSignatureKey = AccountSignature?.GetKeyPair(
                    KeySecurity.Exportable, keyCollection);

            if (AccountEncryptionKey != null) {
                keyCollection.Add(AccountEncryptionKey);
                }

            if (Entries != null) {
                foreach (var entry in Entries) {
                    var key = entry.Key.GetKeyPair();
                    keyCollection.Add(key);

                    //DictionaryStoreEncryptionKey.Add(entry.Resource, key);
                    }
                }

            }



        /// <summary>
        /// Bind this activation to the service <paramref name="profileService"/>
        /// </summary>
        /// <param name="profileService">Description of the service to bind to.</param>
        public void BindService(ProfileService profileService) {
            ProfileService = profileService;
            ServiceEncryptionKey = ProfileService.ServiceEncryption.GetKeyPair();
            }


        #region // MakeCatalogedDevice
        // This method is attached to the activation record because the CatalogedDevice or
        // CatalogedGroup is required to create an context.

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
                        List<string> roles = null,
                        ITransactContextAccount transactContextAccount = null,
                        ActivationDevice activationDevice = null,
                        List<ApplicationEntry> applicationEntries = null) {



            activationDevice ??= new ActivationDevice(profileDevice);
            var activationAccount = MakeActivationAccount(profileDevice, activationDevice, roles, transactContextAccount);

            var catalogedDevice = CreateCataloguedDevice(
                    profileUser, profileDevice, activationDevice, activationAccount,
                    AdministratorSignatureKey, transactContextAccount);

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
        /// <param name="signature">The signature key to use to sign the entry.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        public CatalogedDevice CreateCataloguedDevice(
                    ProfileUser profileUser,
                    ProfileDevice profileDevice,
                    ActivationDevice activationDevice,
                    ActivationAccount activationAccount,
                    KeyPair signature,
                    ITransactContextAccount transactContextAccount = null,
                    List<ApplicationEntry> applicationEntries = null) {

            //PrivateAccountOnlineSignature.AssertNotNull(NotAdministrator.Throw);

            profileUser?.DareEnvelope.AssertNotNull(Internal.Throw);
            profileDevice?.DareEnvelope.AssertNotNull(Internal.Throw);

            // encrypt the activationAccount under the base encryption key.
            activationDevice.AssertNotNull(Internal.Throw);
            activationDevice.Envelope(AdministratorSignatureKey, profileDevice.Encryption.CryptoKey);
            activationDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            // encrypt the activationAccount under the device encryption key.
            activationAccount.AssertNotNull(Internal.Throw);
            activationAccount.Envelope(AdministratorSignatureKey, activationDevice.DeviceEncryption);
            activationAccount.DareEnvelope.AssertNotNull(Internal.Throw);


            var connectionService = activationDevice.ConnectionService;
            var connectionDevice = activationAccount.ConnectionDevice;

            connectionService.Active = activationAccount.DefaultActive;
            connectionService.AssertNotNull(Internal.Throw);
            connectionService.Envelope(signature, objectEncoding:
                        ObjectEncoding.JSON_B);
            connectionService.DareEnvelope.AssertNotNull(Internal.Throw);

            if (connectionDevice != null) {
                connectionDevice.Active = activationAccount.DefaultActive;
                connectionDevice.AssertNotNull(Internal.Throw);
                connectionDevice.Envelope(signature, objectEncoding:
                            ObjectEncoding.JSON_B);
                connectionDevice.DareEnvelope.AssertNotNull(Internal.Throw);
                }

            var connectionAccount = new ConnectionAddress() {
                Account = profileUser?.AccountAddress,
                Subject = connectionService.Subject,
                Authority = connectionService.Authority,
                Authentication = connectionService.Authentication
                };

            connectionAccount.Strip();
            connectionAccount.Envelope(AdministratorSignatureKey, objectEncoding:
                        ObjectEncoding.JSON_B);
            connectionAccount.DareEnvelope.Strip();

            var accessCapability = new CatalogedAccess() {
                Capability = new AccessCapability() {
                    Id = connectionService.AuthenticationPublic.KeyIdentifier,
                    Active = true
                    }
                };

            if (transactContextAccount != null) {
                var catalogAccess = transactContextAccount.GetCatalogAccess();
                transactContextAccount.CatalogUpdate(catalogAccess, accessCapability);
                }

            var catalogEntryDevice = new CatalogedDevice() {
                //Udf = activationAccount.ProfileSignature.Udf,
                EnvelopedProfileUser = profileUser.EnvelopedProfileAccount,
                EnvelopedProfileDevice = profileDevice.EnvelopedProfileDevice,
                EnvelopedConnectionService = connectionService?.EnvelopedConnectionService,
                EnvelopedConnectionDevice = connectionDevice?.EnvelopedConnectionDevice,
                EnvelopedConnectionAddress = connectionAccount?.EnvelopedConnectionAddress,
                EnvelopedActivationDevice = activationDevice?.EnvelopedActivationDevice,
                EnvelopedActivationAccount = activationAccount?.EnvelopedActivationAccount,
                ApplicationEntries = applicationEntries,
                DeviceUdf = profileDevice.Udf
                };

            return catalogEntryDevice;

            }

        static bool GetRight(List<string> rights, string match) {

            foreach (var right in rights) {
                if (right.ToLower() == match) {
                    return true;
                    }
                }

            return false;
            }


        #endregion

        /// <summary>
        /// Create and return a new catalog entry for <paramref name="profileGroup"/> with
        /// the activation data <paramref name="activationAccount"/>.
        /// </summary>
        /// <param name="profileGroup">The group profile.</param>
        /// <param name="activationAccount">The activation data.</param>
        /// <param name="capability">Optional capabilities to add.</param>
        /// <param name="connectionAddress">Connection binding profile to an address.</param>
        /// <returns>The created group.</returns>
        public CatalogedGroup MakeCatalogedGroup(
                        ProfileGroup profileGroup,
                        ActivationAccount activationAccount,
                        CryptoKey capability,
                        ConnectionAddress connectionAddress
                        ) {

            profileGroup?.DareEnvelope.AssertNotNull(Internal.Throw);

            // encrypt the activationAccount under the device encryption key.
            activationAccount.AssertNotNull(Internal.Throw);
            activationAccount.Envelope(AdministratorSignatureKey, capability);
            activationAccount.DareEnvelope.AssertNotNull(Internal.Throw);

            var catalogedGroup = new CatalogedGroup() {
                Key = profileGroup.AccountAddress,
                EnvelopedProfileGroup = profileGroup.EnvelopedProfileAccount,
                EnvelopedActivationAccount = activationAccount.EnvelopedActivationAccount,
                EnvelopedConnectionAddress = connectionAddress.EnvelopedConnectionAddress
                };

            return catalogedGroup;

            }

        /// <summary>
        /// Create an activation record for the device <paramref name="profileDevice"/> 
        /// with assigned roles <paramref name="roles"/> using the
        /// transaction context <paramref name="transactContextAccount"/> to make
        /// changes to the catalogs.
        /// </summary>
        /// <param name="profileDevice">The device to add the roles to.</param>
        /// <param name="roles">The roles to add</param>
        /// <param name="transactContextAccount">Transaction context for making the update.</param>
        /// <returns>The created activation record.</returns>
        public ActivationAccount MakeActivationAccount(
                ProfileDevice profileDevice,
                ActivationDevice activationDevice,
                List<string> roles = null,
                ITransactContextAccount transactContextAccount = null
                ) {


            var newActivation = new ActivationAccount {
                ProfileDevice = profileDevice,
                ActivationDevice = activationDevice
                };

            // Compile the accumulated set of rights.
            var rights = new List<Right>();
            if (roles == null) {
                }
            else {
                foreach (var role in roles) {
                    var rightsRole = Rights.GetRights(role, out var _);
                    rights.Concat(rightsRole);
                    }
                }

            // Grant each right
            foreach (var right in rights) {
                Grant(newActivation, right, activationDevice.DeviceAuthentication.KeyIdentifier, 
                            transactContextAccount);
                }

            // Create the (unsigned) ConnectionUser
            newActivation.ConnectionDevice = new ConnectionDevice() {
                Encryption = new KeyData(activationDevice.DeviceEncryption),
                Signature = new KeyData(activationDevice.DeviceSignature),
                Authentication = new KeyData(activationDevice.DeviceAuthentication),
                Roles = roles
                };


            return newActivation;

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
                    IKeyCollection keyCollection) => KeyPair.FactorySignature(profileDevice.ProfileSignature.CryptoKey.CryptoAlgorithmId,
                            KeySecurity.ExportableStored, keyCollection);


        /// <summary>
        /// Generate a capability for the key <paramref name="keyPair"/>.
        /// add the service portion to the capabilities catalog.
        /// </summary>
        /// <param name="keyPair">Keypair from which the capability is to be derrived.</param>
        /// <param name="profileDevice">The device to which the capability is to be added.</param>
        /// <returns>The key data for the added capability.</returns>
        public  KeyData AddCapability(
                    CryptoKey keyPair, 
                    ProfileDevice profileDevice, 
                    Degree degree,
                    ITransactContextAccount transactContextAccount) {
            //"**** MUST add keys to devices as shared capabilities".TaskFunctionality();

            //var catalogCapability = GetCatalogCapability();

            if (degree == Degree.Direct) {
                return new KeyData(keyPair, true);
                }
            //var activationEntry = transactContextAccount.GetCatalogAccess().MakeActivation(
            //    right, keyPair as KeyPairAdvanced, transactContextAccount);

            throw new NYI();
            }


        void Grant(ActivationAccount newActivation, Right right,
                string keyIdentifier, ITransactContextAccount transactContextAccount = null) {
            var catalog = transactContextAccount.GetCatalogAccess();


            switch (right.Resource) {
                case Resource.ProfileRoot: {

                    newActivation.ProfileSignature = catalog.MakeKeyData(right,
                        ProfileSignatureKey as KeyPairAdvanced, keyIdentifier, transactContextAccount);

                    break;
                    }
                case Resource.ProfileAdmin: {
                    newActivation.ProfileSignature = catalog.MakeKeyData(right,
                        AdministratorSignatureKey as KeyPairAdvanced, keyIdentifier, transactContextAccount);
                    newActivation.DefaultActive = true;
                    break;
                    }
                case Resource.Store: {
                    GrantStore(newActivation, right, keyIdentifier, transactContextAccount);
                    break;
                    }
                case Resource.Account: {
                    if (right.Decrypt) {
                        newActivation.AccountEncryption = catalog.MakeKeyData(right,
                                AccountEncryptionKey as KeyPairAdvanced, keyIdentifier, transactContextAccount);
                        }
                    if (right.Authenticate) {
                        newActivation.AccountAuthentication = catalog.MakeKeyData(right,
                                AccountAuthenticationKey as KeyPairAdvanced, keyIdentifier, transactContextAccount);
                        }
                    if (right.Sign) {
                        newActivation.AccountSignature = catalog.MakeKeyData(right,
                                AccountSignatureKey as KeyPairAdvanced, keyIdentifier, transactContextAccount);
                        }
                    break;
                    }
                }

            }


        /// <summary>
        /// Grant access to the store X.
        /// </summary>
        /// <param name="newActivation">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        /// <param name="transactContextAccount">The transaction context.</param>
        void GrantStore(ActivationAccount newActivation, Right right, string keyIdentifier, ITransactContextAccount transactContextAccount = null) {

            // which store do we need?
            if (DictionaryStoreEncryptionKey.TryGetValue(right.Name, out var keyPair)) {

                }
            else if (GetEntry(right.Name, out var entry)) {
                keyPair = entry.Key.GetKeyPair(KeySecurity.Exportable);

                }

            else {
                return;
                }


            //keyPair.AssertNotNull(NotAdministrator.Throw);

            var activationEntry = transactContextAccount.GetCatalogAccess().MakeActivation(
                right, keyPair as KeyPairAdvanced, keyIdentifier,transactContextAccount);


            newActivation.Entries ??= new List<ActivationEntry>();
            newActivation.Entries.Add(activationEntry);
            }

        bool GetEntry(string name, out ActivationEntry activationEntry) {
            if (Entries != null) {
                foreach (var entry in Entries) {

                    if (entry.Resource == name) {
                        activationEntry = entry;
                        return true;
                        }

                    }
                }
            activationEntry = null;
            return false;
            }



        /// <summary>
        /// Initialize the store <paramref name="storeName"/> by derriving the corresponding
        /// encryption key.
        /// </summary>
        /// <param name="storeName">The store to initialize.</param>
        /// <returns>Cryptographic parameters for the store.</returns>
        public DarePolicy InitializeStore(string storeName) {
            var encryptionKey = secretSeed.GenerateContributionKeyPair(MeshKeyType.Complete,
                MeshActor.Account, MeshKeyOperation.Encrypt, keySecurity: KeySecurity.Exportable);

            DictionaryStoreEncryptionKey.Add(storeName, encryptionKey);

            // here we have to build the policy for the store. This will be to encrypt under the store key

            var policy = new DarePolicy(KeyCollection, recipient: encryptionKey);
            return policy;
            }

        /// <summary>
        /// Return the cryptographic parameters for the store <paramref name="containerName"/>.
        /// </summary>
        /// <param name="containerName">The store to return parameters for.</param>
        /// <returns>Cryptographic parameters for the store.</returns>
        public DarePolicy GetDarePolicy(string containerName) {
            if (DictionaryStoreEncryptionKey.TryGetValue(containerName, out var encryptionKey)) {
                encryptionKey = KeyPair.FactoryExchange(CryptoAlgorithmId.Default,
                        KeySecurity.Exportable, KeyCollection);

                // should add this to the activated capabilities here!

                //DictionaryStoreEncryptionKey.Add(containerName, encryptionKey);
                }
            else if (GetEntry(containerName, out var entry)) {
                encryptionKey = entry.Key.GetKeyPair(KeySecurity.Exportable);

                DictionaryStoreEncryptionKey.Add(entry.Resource, encryptionKey);


                }
            var policy = new DarePolicy(KeyCollection, recipient: encryptionKey);
            return policy;
            //return new CryptoParameters(KeyCollection, recipient: encryptionKey);


            //throw new NYI();
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

            }
        }

    }
