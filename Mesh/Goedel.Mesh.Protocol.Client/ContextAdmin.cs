using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {

    public class ContextMesh : Disposable {
        ///<summary>The context as an administration context.</summary>
        ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;


        public ContextAccountService ConnectService(
                string accountName = null,
                string PIN = null) {

            throw new NYI();
            }
        }


    public class ContextMeshAdmin : ContextMesh {

        AdminEntry AdminEntry;

        ///<summary>The master profile</summary>
        public ProfileMaster ProfileMaster { get; }

        ///<summary>The device profile to which the signature key is bound</summary>
        public ProfileDevice ProfileDevice { get; }

        public string Local => AdminEntry.Local;

        public IMeshMachineClient MeshMachine { get; }


        KeyPair KeyMasterSignature;
        KeyPair KeyAdministratorSignature;

        /// <summary>
        /// Construct a ContextAdmin from the AdminEntry stored on the specified meshMachine
        /// </summary>
        /// <param name="meshMachine"></param>
        /// <param name="local"></param>
        public ContextMeshAdmin(IMeshMachineClient meshMachine, string local = null) :
                this (meshMachine, meshMachine.GetAdmin(local)) {
            
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminEntry"></param>
        public ContextMeshAdmin (
                IMeshMachineClient meshMachine,
                AdminEntry adminEntry,
                ProfileMaster profileMaster=null
                ) {
            Assert.AssertNotNull(adminEntry, NYI.Throw);

            MeshMachine = meshMachine;
            AdminEntry = adminEntry;
            //ProfileMaster = profileMaster ?? ProfileMaster.Decode(adminEntry.EncodedProfileMaster);
            //ProfileDevice = ProfileDevice.Decode(adminEntry.EncodedProfileDevice);
            
            // Join the composite keys to recover the signature key so we can perform admin functions
            KeyAdministratorSignature = adminEntry.SignatureKey.GetPrivate(MeshMachine);
            }


        public static ContextMeshAdmin CreateMesh(
                IMeshMachineClient meshMachine,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            // Create the master profile.
            var profileMaster = ProfileMaster.Generate(meshMachine);
            profileDevice = profileDevice ?? ProfileDevice.Generate(meshMachine);

            var keyOverlaySignature = new KeyOverlay(meshMachine, profileDevice.KeySignature);

            // Create a dummy AdminEntry that does not include the encoded ProfileMaster because
            // we will invalidate the signature when we add the device as an administration device.
            var adminEntry = new AdminEntry() {
                ID = profileMaster.UDF,
                //EncodedProfileDevice = profileDevice.DareMessage,
                //EncodedProfileMaster = null,
                SignatureKey = keyOverlaySignature
                };


            // Add profileDevice as an administration device.
            var contextAdmin = new ContextMeshAdmin(meshMachine, adminEntry, profileMaster);
            contextAdmin.AddAdministrator(profileDevice);

            return contextAdmin;
            }


        public (DareMessage, KeyShare[]) Escrow(int shares, int quorum, int bits = 128) {

            var secret = new Secret(bits);
            var keyShares = secret.Split(shares, quorum);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC);

            throw new NYI();

            //var MasterSignatureKeyPair = KeyCollection.LocatePrivate(ProfileMaster.KeySignature.UDF);
            //var MasterSignatureKey = Key.FactoryPrivate(MasterSignatureKeyPair);
            //var MasterEscrowKeys = new List<Key>();

            //var EscrowedKeySet = new EscrowedKeySet() {
            //    MasterSignatureKey = MasterSignatureKey,
            //    MasterEscrowKeys = MasterEscrowKeys
            //    };

            //var message = new DareMessage(cryptoStack, EscrowedKeySet.GetJson(true));

            //return (message, keyShares);
            }


        /// <summary>
        /// Add an administrator entry for the device <paramref name="profileDevice"/>
        /// </summary>
        /// <param name="profileDevice">Profile of the device to add.</param>
        /// <returns>The new administrator profile,</returns>
        public AdminEntry AddAdministrator (
                    ProfileDevice profileDevice
                    ) {

            var keyOverlaySignature = new KeyOverlay(MeshMachine, profileDevice.KeySignature);

            ProfileMaster.OnlineSignatureKeys = ProfileMaster.OnlineSignatureKeys ??
                        new List<PublicKey>();

            ProfileMaster.OnlineSignatureKeys.Add(new PublicKey(keyOverlaySignature.KeyPair));
            Sign();

            return new AdminEntry() {
                ID = keyOverlaySignature.KeyPair.UDF,
                //EncodedProfileDevice = profileDevice.DareMessage,
                //EncodedProfileMaster = ProfileMaster.DareMessage,
                SignatureKey = keyOverlaySignature
                };

            }


        //CatalogEntryDevice AddDevice(ProfileDevice profileDevice) {


        //    }




        public DareMessage Sign() {
            KeyMasterSignature = KeyMasterSignature ??
                    MeshMachine.KeyCollection.LocatePrivate(ProfileMaster.UDF);
            return ProfileMaster.Sign(KeyMasterSignature);
            }


        /// <summary>
        /// Add a new account to the user's Mesh
        /// </summary>
        /// <param name="localName">The local name of the account.</param>
        /// <returns>The signed account assertion.</returns>
        public AssertionAccount GenerateAccount(
                string localName,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            var keyEncrypt = MeshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);

            var assertionAccount  = new AssertionAccount() {
                MasterProfile = ProfileMaster.DareMessage,
                AccountEncryptionKey = new PublicKey(keyEncrypt.KeyPairPublic())
                };

            Sign(assertionAccount);

            return assertionAccount;
            }

        public ContextAccount CreateAccount(string localName,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            throw new NYI();
            }
        /// <summary>
        /// Add the account <paramref name="accountEntry"/> to the master profile
        /// </summary>
        /// <param name="accountEntry">Description of the account to add</param>
        public CatalogEntryDevice Add(AccountEntry accountEntry) {

            // Here we add the account to the profile.



            throw new NYI();
            }


        public void Sign(AssertionAccount assertionAccount) => assertionAccount.Sign(KeyAdministratorSignature);


        /// <summary>
        /// Sign the specified device connection
        /// </summary>
        /// <param name="assertionDeviceConnection"></param>
        public DareMessage Sign(MeshItem meshItem) => 
            DareMessage.Encode(meshItem.GetBytes(true), signingKey: KeyAdministratorSignature);




        }
    }
