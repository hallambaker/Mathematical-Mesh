//using Goedel.Cryptography;
//using Goedel.Cryptography.Jose;
//using Goedel.Cryptography.Dare;
//using Goedel.Utilities;
//using Goedel.Mesh;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Goedel.Mesh.Client {





//    /// <summary>
//    /// Base context for interacting with a Mesh.
//    /// </summary>
//    public partial class ContextMesh : Disposable {
//        ///<summary>The Machine context.</summary>
//        public IMeshMachineClient MeshMachine => MeshHost?.MeshMachine;

//        ///<summary>The Mesh host</summary>
//        public MeshHost MeshHost { get; }

//        ///<summary>The key collection</summary>
//        public IKeyCollection KeyCollection => MeshHost.KeyCollection;


//        ///<summary>The cataloged device</summary>
//        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

//        ///<summary>The connection device</summary>
//        public ConnectionDevice ConnectionDevice => CatalogedDevice?.ConnectionDevice;

//        ///<summary>The master profile</summary>
//        public ProfileMesh ProfileMesh => CatalogedDevice?.ProfileMesh;

//        ///<summary>The device profile</summary>
//        public ProfileDevice ProfileDevice => CatalogedMachine?.ProfileDevice;

//        ///<summary>The device activation</summary>
//        public ActivationDevice ActivationDevice => CatalogedDevice?.GetActivationDevice(KeyCollection);

//        ///<summary>The Device Entry in the CatalogHost</summary>
//        public CatalogedMachine CatalogedMachine;


//        //public ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;

//        ///<summary>The device key generation seed</summary>
//        protected PrivateKeyUDF DeviceKeySeed;

//        KeyPair deviceDecrypt;

//        KeyPair keySignature;
//        KeyPair keyEncryption;
//        KeyPair keyAuthentication;

//        /// <summary>
//        /// Default constructor.
//        /// </summary>
//        /// <param name="meshHost">The Mesh Host</param>
//        /// <param name="catalogedMachine">The cataloged Mesh record.</param>
//        public ContextMesh(MeshHost meshHost, CatalogedMachine catalogedMachine) {
//            Assert.AssertNotNull(catalogedMachine, NYI.Throw);

//            MeshHost = meshHost;
//            CatalogedMachine = catalogedMachine;

//            // set profile device up here
//            // 



//            DeviceKeySeed = ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
//            deviceDecrypt = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);

//            //Console.WriteLine($"Device Encrypt {deviceDecrypt}");
//            KeyCollection.Add(deviceDecrypt);

//            // register the private decryption key here.

//            if (CatalogedDevice != null) {
//                var activationKey = ActivationDevice.ActivationKey;
//                activationKey.AssertNotNull(Internal.Throw);

//                keySignature = DeviceKeySeed.ActivatePrivate(
//                    activationKey, MeshKeyType.DeviceSign, KeyCollection);
//                keyEncryption = DeviceKeySeed.ActivatePrivate(
//                    activationKey, MeshKeyType.DeviceEncrypt, KeyCollection);
//                keyAuthentication = DeviceKeySeed.ActivatePrivate(
//                    activationKey, MeshKeyType.DeviceAuthenticate, KeyCollection);



//                (keySignature.KeyIdentifier).AssertEqual(ConnectionDevice.KeySignature.UDF,
//                        KeyActivationFailed.Throw);


//                // These are failing because the underlying combination schemes are failing.
//                (keyEncryption.KeyIdentifier).AssertEqual(ConnectionDevice.KeyEncryption.UDF,
//                        KeyActivationFailed.Throw);
//                (keyAuthentication.KeyIdentifier).AssertEqual(ConnectionDevice.KeyAuthentication.UDF,
//                        KeyActivationFailed.Throw);

//                }
//            }

//        /// <summary>
//        /// Derive a <see cref="KeyPair"/> instance of type <paramref name="meshKeyType"/>
//        /// using the activation secret <paramref name="activationKey"/>.
//        /// </summary>
//        /// <param name="activationKey">The activation secret seed used to derrive the 
//        /// activation key.</param>
//        /// <param name="meshKeyType">The type of key to derive</param>
//        /// <returns>The derrived key.</returns>
//        public KeyPair ActivateKey(string activationKey, MeshKeyType meshKeyType) {

//            DeviceKeySeed ??= ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
//            return DeviceKeySeed.ActivatePrivate(
//                    activationKey, meshKeyType, KeyCollection);
//            }


//        // The account activation was not added to activations.

//        /// <summary>
//        /// Return an account context within the context of the Mesh.
//        /// </summary>
//        /// <param name="localName">Local name of the account.</param>
//        /// <param name="accountName">Service name of the account.</param>
//        /// <returns></returns>
//        public ContextAccount GetContextAccount(
//                string localName = null,
//                string accountName = null) {
//            CatalogedDevice.AssertNotNull(ConnectionStillPending.Throw);


//            var account = CatalogedDevice.GetAccount(localName, accountName);
//            return account == null ? null : new ContextAccount(this, account);
//            }

//        /// <summary>
//        /// Update the persisted <see cref="CatalogedMachine"/>.
//        /// </summary>
//        public void UpdateDevice() => MeshHost.Register(CatalogedMachine, this);

//        }


//    }
