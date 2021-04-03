﻿//  Copyright © 2020 Threshold Secrets llc
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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Protocol;

using System.Collections.Generic;
using System.Text;

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
        }

    public partial class ActivationAccount {
        // Properties providing access to account-wide keys.

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
            envelopedProfileUser ?? new Enveloped<ActivationAccount>(DareEnvelope).
                    CacheValue(out envelopedProfileUser);
        Enveloped<ActivationAccount> envelopedProfileUser;

        ///<summary>Dictionary mapping store names to encryption keys.</summary> 
        public Dictionary<string, KeyPair> DictionaryStoreEncryptionKey =
            new Dictionary<string, KeyPair>();

        PrivateKeyUDF secretSeed;


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

            ProfileSignatureKey = ProfileSignature?.GetKeyPair(KeySecurity.Exportable);
            AdministratorSignatureKey = AdministratorSignature?.GetKeyPair(KeySecurity.Exportable);
            AccountEncryptionKey = AccountEncryption?.GetKeyPair(KeySecurity.Exportable);
            AccountAuthenticationKey = AccountAuthentication?.GetKeyPair(KeySecurity.Exportable);
            AccountSignatureKey = AccountSignature?.GetKeyPair(KeySecurity.Exportable);

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


            var connectionDevice = activationDevice.ConnectionUser;
            connectionDevice.AssertNotNull(Internal.Throw);
            connectionDevice.Envelope(AdministratorSignatureKey, objectEncoding: 
                        ObjectEncoding.JSON_B);
            connectionDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            var connectionAccount = new ConnectionAccount() {
                Account = profileUser?.AccountAddress,
                Subject = connectionDevice.Subject,
                Authority = connectionDevice.Authority,
                Authentication = connectionDevice.Authentication
                };

            connectionAccount.Strip();
            connectionAccount.Envelope(AdministratorSignatureKey, objectEncoding:
                        ObjectEncoding.JSON_B);
            connectionAccount.DareEnvelope.Strip();

            // Wrap the connectionDevice and activationDevice in envelopes

            var catalogEntryDevice = new CatalogedDevice() {
                //Udf = activationAccount.ProfileSignature.Udf,
                EnvelopedProfileUser = profileUser.EnvelopedProfileAccount,
                EnvelopedProfileDevice = profileDevice.EnvelopedProfileDevice,
                EnvelopedConnectionDevice = connectionDevice.EnvelopedConnectionDevice,
                EnvelopedConnectionAccount = connectionAccount.EnvelopedConnectionAccount,
                EnvelopedActivationDevice = activationDevice.EnvelopedActivationDevice,
                EnvelopedActivationAccount = activationAccount.EnvelopedActivationAccount,
                DeviceUdf = profileDevice.Udf
                };

            return catalogEntryDevice;
            
            }

        #endregion

        /// <summary>
        /// Create and return a new catalog entry for <paramref name="profileGroup"/> with
        /// the activation data <paramref name="activationAccount"/>.
        /// </summary>
        /// <param name="profileGroup">The group profile.</param>
        /// <param name="activationAccount">The activation data.</param>
        /// <param name="capability">Optional capabilities to add.</param>
        /// <returns>The created group.</returns>
        public CatalogedGroup MakeCatalogedGroup(
                        ProfileGroup profileGroup,
                        ActivationAccount activationAccount,
                        CryptoKey capability
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
                List<string> roles = null,
                ITransactContextAccount transactContextAccount=null
                ) {

            var newActivation = new ActivationAccount {
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
                Grant(newActivation, right);
                }


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
        public static KeyData AddCapability(CryptoKey keyPair, ProfileDevice profileDevice) {
            "**** MUST add keys to devices as shared capabilities".TaskFunctionality();

            //var catalogCapability = GetCatalogCapability();

            return new KeyData(keyPair, true);
            }


        void Grant(ActivationAccount newActivation, Right right) {

            switch (right.Resource) {
                case Resource.ProfileRoot: {
                    GrantProfileRoot(newActivation, right);
                    break;
                    }
                case Resource.ProfileAdmin: {
                    GrantProfileAdmin(newActivation, right);
                    break;
                    }
                case Resource.Store: {
                    GrantStore(newActivation, right);
                    break;
                    }
                case Resource.Account: {
                    GrantAccount(newActivation, right);
                    break;
                    }
                }

            }

        /// <summary>
        /// Grant super administrator access.
        /// </summary>
        /// <param name="newActivation">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantProfileRoot(ActivationAccount newActivation, Right right) {
            right.Future();
            newActivation.ProfileSignature = AddCapability(
                        ProfileSignatureKey, newActivation.ProfileDevice);
            }

        /// <summary>
        /// Grant device administrator access.
        /// </summary>
        /// <param name="newActivation">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantProfileAdmin(
                            ActivationAccount newActivation,
                            Right right) {
            right.Future();
            var keyPairOnlineSignature = DeviceBindSignature(newActivation.ProfileDevice, KeyCollection);
            newActivation.AdministratorSignature = AddCapability(
                        keyPairOnlineSignature, newActivation.ProfileDevice);
            }


        /// <summary>
        /// Grant access to global account.
        /// </summary>
        /// <param name="newActivation">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantAccount(ActivationAccount newActivation, Right right) {
            if (right.Decrypt) {
                newActivation.AccountEncryption = AddCapability(
                            AccountEncryptionKey, newActivation.ProfileDevice);
                }
            if (right.Authenticate) {
                newActivation.AccountAuthentication = AddCapability(
                            AccountAuthenticationKey, newActivation.ProfileDevice);
                }
            if (right.Sign) {
                newActivation.AccountSignature = AddCapability(
                            AccountSignatureKey, newActivation.ProfileDevice);
                }

            }

        /// <summary>
        /// Grant access to the store X.
        /// </summary>
        /// <param name="newActivation">Device to which the access right is granted.</param>
        /// <param name="right">The right granted.</param>
        void GrantStore(ActivationAccount newActivation, Right right) {
            //Screen.WriteLine($"Grant right {right.Name}/{right.Resource}");


            // This is failing because we do not populate DictionaryStoreEncryptionKey
            // except when initially creating the entry.

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


            var activationEntry = new ActivationEntry() {
                Resource = right.Name,
                Key = new KeyData(keyPair, true)
                };

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

                DictionaryStoreEncryptionKey.Add(containerName, encryptionKey);
                }
            else if (GetEntry (containerName, out var entry)){
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
