using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;
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
                KeyOfflineSignature = new PublicKey(keyPublicSign.KeyPairPublic()),
                KeyEncryption = new PublicKey(keyPublicEncrypt.KeyPairPublic()),
                KeyAuthentication = new PublicKey(keyPublicAuthenticate.KeyPairPublic())
                };

            var bytes = ProfileDevice.GetBytes(tag: true);

            ProfileDevice.DareEnvelope = DareEnvelope.Encode(bytes,
                signingKey: keyPublicSign);

            return ProfileDevice;

            }

        /// <summary>
        /// Generate a new profile.
        /// </summary>
        /// <param name="meshMachine">Machine context for persisting keys.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmEncrypt">The encryption algorithm</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm</param>
        /// <returns>The generated, signed profile.</returns>
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

        /// <summary>
        /// Decode an enveloped profile device.
        /// </summary>
        /// <param name="envelope">The enveloped profile.</param>
        /// <returns>The decoded profile.</returns>
        public static new ProfileDevice Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }

        /// <summary>
        /// Formatted print routine.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="indent"></param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

            builder.AppendIndent(indent, $"Profile Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");

            if (KeysOnlineSignature != null) {
                foreach (var online in KeysOnlineSignature) {
                    builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
                    }
                }
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication.UDF} ");

            }



        }


    public partial class ActivationDevice {
        public ProfileDevice ProfileDevice;

        public DareEnvelope Encode(KeyPair encryptDevice, KeyPair encryptAdmin) {

            var cryptoParameters = new CryptoParameters() {
                EncryptionKeys = new List<KeyPair> { encryptDevice, encryptAdmin }
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


            //Console.WriteLine($"Created new device private key");
            //Console.WriteLine($"   Device Sig  {profileDevice.KeyOfflineSignature.UDF} -> {KeySignature.UDF}");
            //Console.WriteLine($"   Device Enc  {profileDevice.KeyEncryption.UDF} -> {KeyEncryption.UDF}");
            //Console.WriteLine($"   Device Auth {profileDevice.KeyAuthentication.UDF} -> {KeyAuthentication.UDF}");
            }

        /// <summary>
        /// Decode the contents of <paramref name="envelope"/> using keys from
        /// <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="envelope">The envelope containing a JSON encoded ActivationDevice instance</param>
        /// <param name="keyCollection">Key collection to collect keys from.</param>
        /// <returns>New instance of the serialized data.</returns>
        public static ActivationDevice Decode(DareEnvelope envelope, KeyCollection keyCollection) {
            if (envelope == null) {
                return null;
                }

            var plaintext = envelope.GetPlaintext(keyCollection);

            Console.WriteLine(plaintext.ToUTF8());
            var result = FromJSON(plaintext.JSONReader(), true);
            result.DareEnvelope = envelope;
            //result.keyCollection = keyCollection;
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


        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {
            builder.AppendIndent(indent, $"Activation Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeySignature:        {KeySignature.UDF} ");
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication.UDF} ");

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
            }


        public static new ConnectionDevice Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }

        public override void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) {

            builder.AppendIndent(indent, $"Connection Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeySignature:        {KeySignature.UDF} ");
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication.UDF} ");

            }


        }


    }
