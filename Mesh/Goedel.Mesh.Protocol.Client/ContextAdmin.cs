using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {



    public partial class ContextMeshAdmin : ContextMesh {

        protected override void Disposing() {
            catalogDevice?.Dispose();
            }


        public CatalogedAdmin AdminConnection => Connection as CatalogedAdmin;


        ///<summary>For an administrative device, the CatalogEntryDevice is taken from the 
        ///device catalog.</summary>
        public override CatalogedDevice CatalogedDevice => catalogEntryDevice ??
            GetCatalogDevice().Get(AdminConnection.ID).CacheValue(out catalogEntryDevice);
        Mesh.CatalogedDevice catalogEntryDevice;


        ///<summary>The master keys for administration.</summary>
        KeyPair KeyMasterSignature;
        KeyPair KeyAdministratorSignature;
        //KeyPair KeyAdministratorEncrypt;

        CryptoParameters ContainerCryptoParameters => new CryptoParameters();

        ///<summary>The device catalog for the Mesh. This contains ALL of the devices connected
        ///to a Mesh even if they do not have an account entry for every account.</summary>
        public CatalogDevice GetCatalogDevice() => catalogDevice ?? new CatalogDevice(
            MeshMachine.DirectoryMesh, ProfileMesh.UDF, ContainerCryptoParameters, KeyCollection).CacheValue(out catalogDevice);
        CatalogDevice catalogDevice;


        KeyCollection KeyCollection => MeshMachine.KeyCollection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminConnection"></param>
        public ContextMeshAdmin(
                IMeshMachineClient meshMachine,
                CatalogedAdmin adminConnection) : base(meshMachine, adminConnection) {

            // Join the composite keys to recover the signature key so we can perform admin functions
            KeyAdministratorSignature = adminConnection.SignatureKey.GetPrivate(MeshMachine);
            //KeyAdministratorEncrypt = KeyCollection.LocatePrivate(ProfileMesh.KeyEncryption.KeyPair.UDF);

            // here find the device connection in the device catalog.
            }


        public static ContextMeshAdmin CreateMesh(
                IMeshMachineClient meshMachine,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            // Create the master profile.
            var profileMaster = ProfilePersonal.Generate(meshMachine);
            profileDevice = profileDevice ?? ProfileDevice.Generate(meshMachine,
                algorithmSign: algorithmSign, algorithmEncrypt: algorithmEncrypt,
                algorithmAuthenticate: algorithmAuthenticate);

            return CreateMesh(meshMachine, profileMaster, profileDevice);
            }





        public static ContextMeshAdmin CreateMesh(
            IMeshMachineClient meshMachine,
            ProfilePersonal profileMaster,
            ProfileDevice profileDevice) {


            Console.WriteLine($"Created new mesh  {profileMaster.UDF} device {profileDevice.UDF}");

            var assertionDevicePrivate = new ActivationDevice(meshMachine, profileDevice);
            var adminEntry = AddAdministrator(meshMachine, profileMaster, profileDevice, assertionDevicePrivate);

            // now create the device catalog and add profileDevice to it.
            var result = new ContextMeshAdmin(meshMachine, adminEntry);
            result.AddDevice(profileDevice, assertionDevicePrivate);

            // Finally register the result in the CatalogHost.
            meshMachine.Register(adminEntry);

            return result;
            }


        #region // Add devices
        /// <summary>
        /// Add an administrator entry for the device <paramref name="profileDevice"/> to
        /// the master profile <Add an administrator entry for the device <paramref name="profileDevice"/>
        /// in the context <paramref name="meshMachine"/>.
        /// <para>This is presented as a static method because creation of an administration context
        /// requires a signed AdminEntry to be established before a ContextAdmin can be created for 
        /// the device.</para>
        /// </summary>
        /// <param name="meshMachine">The cryptographic machine context (persistence stores, etc).</param>
        /// <param name="profileMaster">The master profile to add the device to as an administration device.</param>
        /// <param name="profileDevice">The </param>
        /// <returns></returns>
        static CatalogedAdmin AddAdministrator(
                    IMeshMachine meshMachine,
                    ProfilePersonal profileMaster,
                    ProfileDevice profileDevice,
                    ActivationDevice assertionDevicePrivate
                    ) {
            var keyOverlaySignature = new KeyOverlay(meshMachine, profileDevice.KeyOfflineSignature);

            profileMaster.KeysOnlineSignature = profileMaster.KeysOnlineSignature ??
                        new List<PublicKey>();

            profileMaster.KeysOnlineSignature.Add(new PublicKey(keyOverlaySignature.KeyPair));

            var keyMasterSignature =
                    meshMachine.KeyCollection.LocatePrivate(profileMaster.UDF);
            profileMaster.Sign(keyMasterSignature);

            return new CatalogedAdmin() {
                ID = assertionDevicePrivate.KeySignature.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedProfileMaster = profileMaster.DareEnvelope,
                SignatureKey = keyOverlaySignature
                };
            }

        ///// <summary>
        ///// Add an administrator entry for the device <paramref name="profileDevice"/>
        ///// </summary>
        ///// <param name="profileDevice">Profile of the device to add.</param>
        ///// <returns>The new administrator profile,</returns>
        //public AdminConnection AddAdministrator(
        //            ProfileDevice profileDevice
        //            ) => AddAdministrator(MeshMachine, ProfileMesh, profileDevice);


        public CatalogedDevice AddDevice(ProfileDevice profileDevice) {
            var assertionDevicePrivate = new ActivationDevice(MeshMachine, profileDevice);
            return AddDevice(profileDevice, assertionDevicePrivate);
            }
        CatalogedDevice AddDevice(ProfileDevice profileDevice, ActivationDevice assertionDevicePrivate) {
            assertionDevicePrivate.Encode(profileDevice.KeyEncryption.KeyPair, ProfileMesh.KeyEncryption.KeyPair);

            var assertionDeviceConnection = new ConnectionDevice(assertionDevicePrivate);

            KeyMasterSignature = KeyMasterSignature ??
                    MeshMachine.KeyCollection.LocatePrivate(ProfileMesh.UDF);
            Sign(assertionDeviceConnection);

            var catalogEntryDevice = new Mesh.CatalogedDevice() {
                UDF = assertionDevicePrivate.KeySignature.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedConnectionDevice = assertionDeviceConnection.DareEnvelope,
                EnvelopedActivationDevice = assertionDevicePrivate.DareEnvelope,
                EnvelopedProfileDevice = profileDevice.DareEnvelope
                };

            GetCatalogDevice().New(catalogEntryDevice);


            return catalogEntryDevice;
            }

        #endregion








        #region // Add Account
        /// <summary>
        /// Create an account without attaching it to a service (yet).
        /// </summary>
        /// <param name="localName"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public ContextAccount CreateAccount(string localName,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            // Generate the AssertionAccount
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keyEncrypt = MeshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.ExportableStored, keyUses: KeyUses.Encrypt);

            var assertionAccount = new ProfileAccount() {
                MeshProfileUDF = ProfileMesh.UDF,
                KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic())
                };

            Sign(assertionAccount);

            // At this point we need to read back the device catalog of the Mesh and add the
            // account to each entry. At some point we need to put some sort
            // of filter capability on thism

            ActivationAccount activationAccount = null;


            var catalogChanges = new List<CatalogUpdate>();
            foreach (var device in GetCatalogDevice().AsCatalogEntryDevice) {
                catalogChanges.Add(new CatalogUpdate(CatalogAction.Update, device));
                if (device.DeviceUDF == AdminConnection.DeviceUDF) {
                    
                    activationAccount = AddDevice(assertionAccount, device, keyEncrypt as KeyPairAdvanced);
                    }
                else {
                    AddDevice(assertionAccount, device, keyEncrypt as KeyPairAdvanced);
                    }

                }

            var catalogDevice = GetCatalogDevice();
            catalogDevice.Transact(catalogDevice,catalogChanges);


            // can't do it this way because the catalog entries are being modified inside the loop.
            // need to build a to-do list and then apply the changes.

            var contextAccount = new ContextAccount(this, activationAccount, assertionAccount);
            Directory.CreateDirectory(contextAccount.DirectoryAccount);
            var catalogApplication = contextAccount.GetCatalogApplication();
            catalogApplication.Update(assertionAccount);
            MeshMachine.Register(AdminConnection);

            return contextAccount;

            }

        #endregion

        #region // Add regular device

        public ActivationAccount AddDevice(
                    ProfileAccount  assertionAccount,
                    Mesh.CatalogedDevice catalogEntryDevice, 
                    KeyPairAdvanced keyEncryptionMaster) {
            // Decrypt EncryptedDevicePrivate using the Master profile decryption key

            var encryptedDevicePrivate = catalogEntryDevice.EnvelopedActivationDevice;

            var devicePrivate = ActivationDevice.Decode(
                                MeshMachine, encryptedDevicePrivate);
            var profileDevice = catalogEntryDevice.ProfileDevice;

            var keyEncryption = new KeyComposite(keyEncryptionMaster);
            var keySignature  = new KeyOverlay(MeshMachine, profileDevice.KeyOfflineSignature);
            var keyAuthentication = new KeyOverlay(MeshMachine, profileDevice.KeyAuthentication);

            var assertionAccountConnection = new ConnectionAccount() {
                KeySignature = new PublicKey(keySignature.KeyPair),
                KeyEncryption = new PublicKey(keyEncryption.KeyPair),
                KeyAuthentication = new PublicKey(keyAuthentication.KeyPair)
                };

            Sign(assertionAccountConnection);

            // Create the activation for this device
            var activationAccount = new ActivationAccount() {
                AccountUDF = assertionAccount.UDF,
                EnvelopedAssertionAccountConnection = assertionAccountConnection.DareEnvelope,
                KeyEncryption = keyEncryption,
                KeySignature = keySignature,
                KeyAuthentication = keyAuthentication
                };

            // Add it to the account
            devicePrivate.Activations = devicePrivate.Activations ?? new List<Activation>();
            devicePrivate.Activations.Add(activationAccount);

            catalogEntryDevice.EnvelopedActivationDevice = 
                devicePrivate.Encode(catalogEntryDevice.ProfileDevice.KeyEncryption.KeyPair, 
                        ProfileMesh.KeyEncryption.KeyPair);


            return activationAccount;
            }

        #endregion 

        /// <summary>
        /// Sign the specified assertion under this device's administration key
        /// </summary>
        /// <param name="assertion">The assertion to sign.</param>
        public DareEnvelope Sign(Assertion assertion) => assertion.Sign(KeyAdministratorSignature);


        #region // Escrow and recovery from escrow


        /// <summary>
        /// Create an escrow set for the master key.
        /// </summary>
        /// <param name="shares">Number of shares to create</param>
        /// <param name="quorum">Number of shares required to recreate the quorum</param>
        /// <param name="bits">Key size in bits</param>
        /// <returns>The encrypted escrow entry and the key shares.</returns>
        public (DareEnvelope, KeyShare[]) Escrow(int shares, int quorum, int bits = 128) {

            var secret = new Secret(bits);
            var keyShares = secret.Split(shares, quorum);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC);


            var MasterSignatureKeyPair = KeyCollection.LocatePrivate(ProfileMesh.KeyOfflineSignature.UDF);
            var MasterSignatureKey = Key.FactoryPrivate(MasterSignatureKeyPair);
            var MasterEscrowKeys = new List<Key>();

            var EscrowedKeySet = new EscrowedKeySet() {
                MasterSignatureKey = MasterSignatureKey,
                MasterEscrowKeys = MasterEscrowKeys
                };

            var message = new DareEnvelope(cryptoStack, EscrowedKeySet.GetBytes(true));

            return (message, keyShares);
            }

        public static ContextMeshAdmin RecoverMesh(
                IMeshMachineClient meshMachine,
                Secret secret,
                ProfileDevice profileDevice = null,
                DareEnvelope escrow = null,
                
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default
                ) {


            var escrowedKeySet = EscrowedKeySet.FromJSON(escrow.GetBodyReader(secret), true);
            var keySign = escrowedKeySet.MasterSignatureKey.GetKeyPair(KeySecurity.Device, keyCollection: meshMachine.KeyCollection);
            var keyEncrypt = escrowedKeySet.MasterEncryptionKey.GetKeyPair(KeySecurity.Device, keyCollection: meshMachine.KeyCollection);

            var profileMaster = new ProfilePersonal(keySign, null, keyEncrypt);


            return CreateMesh(meshMachine, profileMaster, profileDevice);
            }

        #endregion

        }
    }
