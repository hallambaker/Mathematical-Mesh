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


        ///<summary>The host catalog entry as a CatalogedAdmin entry.</summary>
        public CatalogedAdmin CatalogedAdmin => CatalogedMachine as CatalogedAdmin;


        ///<summary>The master keys for administration.</summary>
        KeyPair keyMasterSignature;
        KeyPair keyAdministratorSignature;

        //CryptoParameters ContainerCryptoParameters => new CryptoParameters();

        KeyCollection KeyCollection => MeshMachine.KeyCollection;

        /// <summary>
        /// Constructor, returns an administration context instance for the catalog entry 
        /// <paramref name="catalogedAdmin"/> on machine <paramref name="meshMachine"/>.
        /// </summary>
        /// <param name="catalogedAdmin"></param>
        public ContextMeshAdmin(
                IMeshMachineClient meshMachine,
                CatalogedAdmin catalogedAdmin) : base(meshMachine, catalogedAdmin) {
            CatalogedMachine = catalogedAdmin;

            // Join the composite keys to recover the signature key so we can perform admin functions
            keyAdministratorSignature = catalogedAdmin.SignatureKey.GetPrivate(MeshMachine);
            }

        /// <summary>
        /// Create a new personal mesh and return an administration context for it.
        /// </summary>
        /// <param name="meshMachine">The machine context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextMeshAdmin CreateMesh(
                IMeshMachineClient meshMachine,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            // Create the master profile.
            var profileMaster = ProfileMesh.Generate(meshMachine);
            profileDevice = profileDevice ?? ProfileDevice.Generate(meshMachine,
                algorithmSign: algorithmSign, algorithmEncrypt: algorithmEncrypt,
                algorithmAuthenticate: algorithmAuthenticate);

            return CreateMesh(meshMachine, profileMaster, profileDevice);
            }

        /// <summary>
        /// Create a new personal mesh.
        /// </summary>
        /// <param name="meshMachine">The machine context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="profileMaster">The mesh profile.</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextMeshAdmin CreateMesh(
            IMeshMachineClient meshMachine,
            ProfileMesh profileMaster,
            ProfileDevice profileDevice) {

            Console.WriteLine($"Created new mesh  {profileMaster.UDF} device {profileDevice.UDF}");

            // Add this device to the profile as an administrator device by adding the necessary activation.
            var assertionDevicePrivate = new ActivationDevice(meshMachine, profileDevice);
            var adminEntry = AddAdministrator(meshMachine, profileMaster, profileDevice, assertionDevicePrivate);

            // Create an administration context
            var result = new ContextMeshAdmin(meshMachine, adminEntry);

            // Use the administration context to create a connection for this device and add to the record
            var catalogedDevice = result.CreateCataloguedDevice(profileDevice, assertionDevicePrivate);
            result.UpdateDevice(catalogedDevice);

            // Now save the results to host.dcat (the only catalog we have at this point) and return the admin context.
            meshMachine.MeshHost.Register(adminEntry);
            return result;
            }





        #region // Add devices
        /// <summary>
        /// Create an administrator catalog entry for the device <paramref name="profileDevice"/> to
        /// the master profile <Add an administrator entry for the device <paramref name="profileDevice"/>
        /// in the context <paramref name="meshMachine"/>.
        /// <para>This is presented as a static method because creation of an administration context
        /// requires a signed AdminEntry to be established before a ContextAdmin can be created for 
        /// the device.</para>
        /// </summary>
        /// <param name="meshMachine">The cryptographic machine context (persistence stores, etc).</param>
        /// <param name="profileMaster">The master profile to add the device to as an administration device.</param>
        /// <param name="profileDevice">The device profile of the administration device to be added
        /// as the initial administrator.</param>
        /// <returns>The catalog entry/</returns>
        static CatalogedAdmin AddAdministrator(
                    IMeshMachine meshMachine,
                    ProfileMesh profileMaster,
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



        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        public CatalogedDevice CreateCataloguedDevice(ProfileDevice profileDevice) {
            var assertionDevicePrivate = new ActivationDevice(MeshMachine, profileDevice);
            var result = CreateCataloguedDevice(profileDevice, assertionDevicePrivate);
            return result;
            }

        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>
        /// and activation <paramref name="assertionDevicePrivate"/>.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <param name="assertionDevicePrivate">The device key overlay.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        CatalogedDevice CreateCataloguedDevice(ProfileDevice profileDevice, ActivationDevice assertionDevicePrivate) {
            assertionDevicePrivate.Encode(profileDevice.KeyEncryption.KeyPair, ProfileMesh.KeyEncryption.KeyPair);

            var assertionDeviceConnection = new ConnectionDevice(assertionDevicePrivate);

            keyMasterSignature = keyMasterSignature ??
                    MeshMachine.KeyCollection.LocatePrivate(ProfileMesh.UDF);
            Sign(assertionDeviceConnection);

            var catalogEntryDevice = new Mesh.CatalogedDevice() {
                UDF = assertionDevicePrivate.KeySignature.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedConnectionDevice = assertionDeviceConnection.DareEnvelope,
                EnvelopedActivationDevice = assertionDevicePrivate.DareEnvelope,
                EnvelopedProfileDevice = profileDevice.DareEnvelope
                };

            return catalogEntryDevice;
            }



        public void Accept(AcknowledgeConnection request) {
            var device = CreateCataloguedDevice(request.MessageConnectionRequest.ProfileDevice);
            }

        #endregion


        #region // Add Account
        /// <summary>
        /// Create an account without attaching it to a service (yet).
        /// </summary>
        /// <param name="localName"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public ContextAccount CreateAccount(
            
                    string localName,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {


            var profileAccount = ProfileAccount.Generate(MeshMachine, ProfileMesh,
                        algorithmSign, algorithmEncrypt);

            var accountEntry = profileAccount.ConnectDevice(MeshMachine, CatalogedDevice, null);
            UpdateDevice(CatalogedDevice);

            var contextAccount = new ContextAccount(this, accountEntry);

            Directory.CreateDirectory(contextAccount.DirectoryAccount);
            contextAccount.AddDevice(CatalogedDevice);



            return contextAccount;
            }

        #endregion


        /// <summary>
        /// Sign the specified assertion under this device's administration key
        /// </summary>
        /// <param name="assertion">The assertion to sign.</param>
        public DareEnvelope Sign(Assertion assertion) => assertion.Sign(keyAdministratorSignature);


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

            var profileMaster = new ProfileMesh(keySign, null, keyEncrypt);


            return CreateMesh(meshMachine, profileMaster, profileDevice);
            }

        #endregion

        }
    }
