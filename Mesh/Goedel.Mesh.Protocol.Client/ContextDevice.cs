using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// Class that represents a device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextDevice {

        public virtual IMeshMachine Machine { get;  }

        public virtual ProfileDevice ProfileDevice { get;}
        public DareMessage ProfileDeviceSigned => ProfileDevice.ProfileDeviceSigned;

        public ContextDevice(IMeshMachine machine = null, string AccountID = null, string ProfileID = null) {
            }
        public KeyCollection KeyCollection => Machine.KeyCollection;

        ContextDevice(IMeshMachine machine, ProfileDevice profileDevice) {
            Machine = machine;
            ProfileDevice = profileDevice;
            }

        public static ContextDevice Generate(
                IMeshMachine machine = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            machine = machine ?? MeshMachine.Default;
            var KeyCollection = machine.KeyCollection;

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmAuthenticate = algorithmAuthenticate.DefaultMeta(CryptoAlgorithmID.Ed448);

            // Create the key set. 
            // Hack: hard coded to RSA for ease of debugging
            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Device, KeyCollection, keyUses:KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);
            var keyAuthenticate = KeyPair.Factory(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);

            // Generate the profile
            var Profile = Mesh.ProfileDevice.Generate(keySign, keyEncrypt, keyAuthenticate);

            // Register the profile locally
            machine.Register(Profile);

            return new ContextDevice(machine, Profile);

            }

        public ContextMaster GenerateMaster(
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);

            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Encrypt);


            var Profile = Mesh.ProfileMaster.Generate(ProfileDevice, keySign, keyEncrypt);


            // Register the profile locally
            Machine.Register(Profile);
            return new ContextMaster(this, Profile);



            }

        public ProfileMaster Recover(DareMessage escrow, KeyShare[] shares) {

            var secret = new Secret(shares);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC) {
                Salt = escrow.Header.Salt
                };
            var Decrypted = cryptoStack.DecodeBody(escrow.Body);

            var escrowedKeySet = EscrowedKeySet.FromJSON(Decrypted.JSONReader(), true);

            var masterSignatureKey = escrowedKeySet.MasterSignatureKey.GetKeyPair(KeyStorage.Exportable);
            var profileMaster = ProfileMaster.Generate(ProfileDevice, masterSignatureKey,
                null);

            return profileMaster;
            }


        public string Connect(string account) => throw new NYI();

        public bool Complete(string account) => throw new NYI();

        }



    }
