using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {



    public partial class ContextMeshAdmin : ContextMesh {


        ///<summary>The host catalog entry as a CatalogedAdmin entry.</summary>
        public CatalogedAdmin CatalogedAdmin => CatalogedMachine as CatalogedAdmin;


        ///<summary>The master keys for administration.</summary>
        KeyPair keyAdministratorSignature;

        //CryptoParameters ContainerCryptoParameters => new CryptoParameters();

        KeyCollection KeyCollection => MeshMachine.KeyCollection;

        /// <summary>
        /// Constructor, returns an administration context instance for the catalog entry 
        /// <paramref name="catalogedAdmin"/> on machine <paramref name="meshMachine"/>.
        /// </summary>
        /// <param name="catalogedAdmin"></param>
        public ContextMeshAdmin(
                MeshHost meshHost,
                CatalogedAdmin catalogedAdmin) : base(meshHost, catalogedAdmin) {
            CatalogedMachine = catalogedAdmin;

            // Join the composite keys to recover the signature key so we can perform admin functions
            keyAdministratorSignature = catalogedAdmin.SignatureKey.GetPrivate(MeshMachine);
            }

        /// <summary>
        /// Create a new personal mesh and return an administration context for it.
        /// </summary>
        /// <param name="meshHost">The mesh host context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        /// <param name="masterSecret">Specifies a seed from which to generate the ProfileMesh</param>
        /// <param name="deviceSecret">Specifies a seed from which to generate the ProfileDevice</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="meshHost"/>.</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextMeshAdmin CreateMesh(
                MeshHost meshHost,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                byte[] masterSecret = null,
                byte[] deviceSecret = null,
                bool? persist = null) {

            // Create the master profile.
            var secretSeedMaster = new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileMaster, algorithmEncrypt, algorithmSign,
                algorithmAuthenticate, masterSecret);

            persist ??= masterSecret == null;
            var profileMesh = new ProfileMesh(meshHost.KeyCollection, secretSeedMaster, persist==true);

            var secretSeedDevice = new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileDevice, algorithmEncrypt, algorithmSign,
                algorithmAuthenticate, deviceSecret);
            profileDevice ??= new ProfileDevice(meshHost.KeyCollection, secretSeedDevice, true);

            return CreateMesh(meshHost, profileMesh, profileDevice);
            }

        /// <summary>
        /// Create a new personal mesh.
        /// </summary>
        /// <param name="meshHost">The machine context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="profileMaster">The mesh profile.</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextMeshAdmin CreateMesh(
            MeshHost meshHost,
            ProfileMesh profileMaster,
            ProfileDevice profileDevice) {

            Console.WriteLine($"Created new mesh  {profileMaster.UDF} device {profileDevice.UDF}");

            // Add this device to the profile as an administrator device by adding the necessary activation.
            var activationDevice = new ActivationDevice(profileDevice, meshHost.KeyCollection);
            var adminEntry = AddAdministrator(meshHost.MeshMachine, profileMaster, profileDevice, activationDevice);

            // Create an administration context
            var result = new ContextMeshAdmin(meshHost, adminEntry);


            // Use the administration context to create a connection for this device and add to the record
            var catalogedDevice = result.CreateCataloguedDevice(profileDevice, activationDevice);
            result.UpdateDevice(catalogedDevice);

            // Now save the results to host.dcat (the only catalog we have at this point) and return the admin context.
            meshHost.Register(adminEntry);
            return result;
            }





        #region // Add devices
        /// <summary>
        /// Create an administrator catalog entry for the device <paramref name="profileDevice"/> to
        /// the master profile in the context <paramref name="meshMachine"/>.
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

            profileMaster.KeysOnlineSignature ??=                         new List<PublicKey>();

            profileMaster.KeysOnlineSignature.Add(new PublicKey(keyOverlaySignature.KeyPair));

            var keyMasterSignature =
                    meshMachine.KeyCollection.LocatePrivateKeyPair(profileMaster.UDF);
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
            var activationDevice = new ActivationDevice(profileDevice, KeyCollection);
            var result = CreateCataloguedDevice(profileDevice, activationDevice);

            return result;
            }

        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>
        /// and activation <paramref name="activationDevice"/>.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <param name="activationDevice">The device key overlay.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        CatalogedDevice CreateCataloguedDevice(
                    ProfileDevice profileDevice, 
                    ActivationDevice activationDevice) {

            var connectionDevice = activationDevice.ConnectionDevice;

            // Wrap the connectionDevice and activationDevice in envelopes
            Sign(connectionDevice);
            activationDevice.Encode();

            var catalogEntryDevice = new Mesh.CatalogedDevice() {
                UDF = activationDevice.KeySignature.UDF,
                EnvelopedProfileMesh = ProfileMesh.DareEnvelope,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedConnectionDevice = connectionDevice.DareEnvelope,
                EnvelopedActivationDevice = activationDevice.DareEnvelope,
                DeviceUDF = profileDevice.UDF
                };

            return catalogEntryDevice;
            }


        /// <summary>
        /// Accept device connection request.
        /// </summary>
        /// <param name="request"></param>
        public void Accept(AcknowledgeConnection request) {
            var device = CreateCataloguedDevice(request.MessageConnectionRequest.ProfileDevice);
            }

        #endregion


        #region // Add Account
        /// <summary>
        /// Create an account without attaching it to a service (yet).
        /// </summary>
        /// <param name="localName">Local (friendly) name for the account.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm to use.</param>
        /// <returns>The created account context.</returns>
        public ContextAccount CreateAccount(

                    string localName,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {


            var profileAccount = ProfileAccount.Generate(MeshMachine, ProfileMesh,
                        algorithmSign, algorithmEncrypt);

            var accountEntry = profileAccount.ConnectDevice(MeshMachine, CatalogedDevice, null);
            UpdateDevice(CatalogedDevice);

            var contextAccount = MeshHost.AddAccount(this, accountEntry);

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
        /// <param name="threshold">Number of shares required to recreate the quorum</param>
        /// <returns>The encrypted escrow entry and the key shares.</returns>
        public KeyShareSymmetric[] Escrow(int shares, int threshold) {
            // pull the master key
            var mastersecret = KeyCollection.LocatePrivateKey(ProfileMesh.KeyOfflineSignature.UDF);
            // convert to byte array;
            var mastersecretBytes = (mastersecret as PrivateKeyUDF).PrivateValue.FromBase32();
            Console.WriteLine(mastersecretBytes.ToStringBase16FormatHex());
            // split (n, t) ways
            var secret = new SharedSecret(mastersecretBytes);
            var keyShares = secret.Split(shares, threshold);
            return keyShares;
            }


        /// <summary>
        /// Recover a Mesh Profile from the recovery key value.
        /// </summary>
        /// <param name="meshHost">The machine context that the mesh is going to be created on.</param>
        /// <param name="secretBytes">The recovered UDF key derrivation seed. This may have leading
        /// zeros.</param>
        /// <param name="profileDevice">The device profile to bind to.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        /// <returns>An administration context instance for the recovered profile.</returns>
        public static ContextMeshAdmin RecoverMesh(
                MeshHost meshHost,
                byte[] secretBytes,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default
                ) {

            // trim the shared secret value to remove leading zeros,
            // the key type, etc.

            int start;
            for (start = 0; (start < secretBytes.Length) && secretBytes[start] == 0; start++) {
                }
            (secretBytes[start++] == (byte)UDFTypeIdentifier.DerivedKey).AssertTrue();
            var algorithm = secretBytes[start++]* 0x100 + secretBytes[start++];
            (algorithm == (int)UdfAlgorithmIdentifier.MeshProfileMaster).AssertTrue();

            var length = secretBytes.Length - start;
            var masterSecret = new byte[length];
            Buffer.BlockCopy(secretBytes, start, masterSecret, 0, length);
            Console.WriteLine(masterSecret.ToStringBase16FormatHex());
            return meshHost.CreateMesh("main", algorithmSign, algorithmEncrypt, algorithmAuthenticate,
                masterSecret);
            }

        #endregion

        }
    }
