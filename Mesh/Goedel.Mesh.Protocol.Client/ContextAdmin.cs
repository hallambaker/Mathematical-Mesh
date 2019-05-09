using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {
    public class ContextAdmin {

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
        public ContextAdmin(IMeshMachineClient meshMachine, string local = null) :
                this (meshMachine, meshMachine.GetAdmin(local)) {
            
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminEntry"></param>
        public ContextAdmin (
                IMeshMachineClient meshMachine,
                AdminEntry adminEntry
                ) {
            Assert.AssertNotNull(AdminEntry, NYI.Throw);

            MeshMachine = meshMachine;
            AdminEntry = adminEntry;
            ProfileMaster = ProfileMaster.Decode(adminEntry.EncodedProfileMaster);
            ProfileDevice = ProfileDevice.Decode(adminEntry.EncodedProfileDevice);
            
            // Join the composite keys to recover the signature key so we can perform admin functions
            KeyAdministratorSignature = adminEntry.SignatureKey.GetPrivate(MeshMachine);
            }


        public static ContextAdmin Generate(
                IMeshMachineClient meshMachine,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            // Create the master profile
            var profileMaster = ProfileMaster.Generate(meshMachine);
            profileDevice = profileDevice ?? ProfileDevice.Generate(meshMachine);

            var adminEntry = new AdminEntry() {
                };

            var contextAdmin = new ContextAdmin(meshMachine, adminEntry);
            contextAdmin.AddAdministrator(profileDevice);
            contextAdmin.Sign();

            return contextAdmin;
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

            return new AdminEntry() {
                ID = keyOverlaySignature.KeyPair.UDF,
                EncodedProfileDevice = profileDevice.DareMessage,
                EncodedProfileMaster = ProfileMaster.DareMessage,
                SignatureKey = keyOverlaySignature
                };

            }
        public DareMessage Sign() {
            KeyMasterSignature = KeyMasterSignature ??
                    MeshMachine.KeyCollection.LocatePrivate(ProfileMaster.UDF);
            return ProfileMaster.Sign(KeyMasterSignature);
            }




        /// <summary>
        /// Add the account <paramref name="accountEntry"/> to the master profile
        /// </summary>
        /// <param name="accountEntry">Description of the account to add</param>
        public void Add(AccountEntry accountEntry) {

            }

        /// <summary>
        /// Sign the specified device connection
        /// </summary>
        /// <param name="assertionDeviceConnection"></param>
        public void Sign(MeshItem meshItem) => 
            DareMessage.Encode(meshItem.GetBytes(true), signingKey: KeyAdministratorSignature);




        }
    }
