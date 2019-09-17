using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
namespace Goedel.Mesh {


    public partial class ProfileDevice {

        public override string _PrimaryKey => UDF;


        public string UDF => KeyOfflineSignature.UDF;

        public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileDevice() {
            }

        /// <summary>
        /// Create a new master profile.
        /// </summary>
        /// <param name="AlgorithmSign"></param>
        /// <param name="AlgorithmEncrypt"></param>
        public static ProfileDevice Generate(
                        KeyPair keyPublicSign,
                        KeyPair keyPublicEncrypt,
                        KeyPair keyPublicAuthenticate) {

            var ProfileDevice = new ProfileDevice() {
                KeyOfflineSignature = new PublicKey (keyPublicSign.KeyPairPublic()),
                KeyEncryption = new PublicKey(keyPublicEncrypt.KeyPairPublic()),
                KeyAuthentication = new PublicKey(keyPublicAuthenticate.KeyPairPublic())
                };

            var bytes = ProfileDevice.GetBytes(tag:true);

            ProfileDevice.DareEnvelope = DareEnvelope.Encode(bytes,
                signingKey: keyPublicSign);

            return ProfileDevice;

            }


        public static ProfileDevice Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            algorithmAuthenticate = algorithmAuthenticate.DefaultAlgorithmAuthenticate();
            var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
            var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            var keyAuthenticate = meshMachine.CreateKeyPair(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);
            return Generate(keySign, keyEncrypt, keyAuthenticate);

            }

        public static new ProfileDevice Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }


    public partial class ActivationDevice {
        public ProfileDevice ProfileDevice;

        public  DareEnvelope Encode(KeyPair encryptDevice, KeyPair encryptAdmin) {

            var cryptoParameters = new CryptoParameters() {
                EncryptionKeys = new List<KeyPair> { encryptDevice , encryptAdmin } 
                };

            var contentInfo = new Goedel.Cryptography.Dare.ContentMeta() { ContentType = "application/mmm" };

            this.DareEnvelope = new DareEnvelope(
                cryptoParameters,
                GetBytes(tag: true),
                contentMeta: contentInfo);

            return DareEnvelope;
            }

        public ActivationDevice() { }

        public ActivationDevice(
                    IMeshMachine meshMachine,
                    ProfileDevice profileDevice) {
            ProfileDevice = profileDevice;
            KeySignature = new KeyOverlay(meshMachine, profileDevice.KeyOfflineSignature);
            KeyEncryption = new KeyOverlay(meshMachine, profileDevice.KeyEncryption);
            KeyAuthentication = new KeyOverlay(meshMachine, profileDevice.KeyAuthentication);


            Console.WriteLine($"Created new device private key");
            Console.WriteLine($"   Device Sig  {profileDevice.KeyOfflineSignature.UDF} -> {KeySignature.UDF}");
            Console.WriteLine($"   Device Enc  {profileDevice.KeyEncryption.UDF} -> {KeyEncryption.UDF}");
            Console.WriteLine($"   Device Auth {profileDevice.KeyAuthentication.UDF} -> {KeyAuthentication.UDF}");
            }

        public static new ActivationDevice Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        public static ActivationDevice Decode(IMeshMachine meshMachine, DareEnvelope message) =>
                FromJSON(message.GetBodyReader(), true);

        // is failing here because the device entry is not being written back to the catalog after the update.
        // fix this and then some skyrim.

        public ActivationAccount GetActivation(string accountName = null) {
            foreach (var activation in Activations) {
                switch (activation) {
                    case ActivationAccount activationAccount:
                        return activationAccount;
                    }

                }


            return null;
            }

        }

    public partial class ConnectionDevice {
        public ProfileMesh ProfileMaster;

        public ConnectionDevice() {
            }

        public ConnectionDevice(ActivationDevice assertionDevicePrivate) {

            KeySignature = new PublicKey(assertionDevicePrivate.KeySignature.KeyPair);
            KeyEncryption = new PublicKey(assertionDevicePrivate.KeyEncryption.KeyPair);
            KeyAuthentication = new PublicKey(assertionDevicePrivate.KeyAuthentication.KeyPair);

            Console.WriteLine($"Created new device connection assertion");
            Console.WriteLine($"   Sig  {KeySignature.UDF}");
            Console.WriteLine($"   Enc  {KeyEncryption.UDF}");
            Console.WriteLine($"   Auth {KeyAuthentication.UDF}");
            }

        public static new ConnectionDevice Decode(DareEnvelope message) =>
                FromJSON(message.GetBodyReader(), true);
        }


    }
