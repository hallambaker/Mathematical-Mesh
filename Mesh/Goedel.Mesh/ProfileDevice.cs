using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;
namespace Goedel.Mesh {


    public partial class ProfileDevice {

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileDevice() {
            }


        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileDevice(
                    KeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist=false) {
            var keyEncrypt = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixEncrypt);
            var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);
            var keyAuthenticate = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixAuthenticate);

            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuthenticate.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }
            }





        ///// <summary>
        ///// Create a new master profile.
        ///// </summary>
        ///// <param name="AlgorithmSign"></param>
        ///// <param name="AlgorithmEncrypt"></param>
        //public static ProfileDevice Generate(
        //                KeyPair keyPublicSign,
        //                KeyPair keyPublicEncrypt,
        //                KeyPair keyPublicAuthenticate) {

        //    var ProfileDevice = new ProfileDevice() {
        //        KeyOfflineSignature = new PublicKey(keyPublicSign.KeyPairPublic()),
        //        KeyEncryption = new PublicKey(keyPublicEncrypt.KeyPairPublic()),
        //        KeyAuthentication = new PublicKey(keyPublicAuthenticate.KeyPairPublic())
        //        };

        //    var bytes = ProfileDevice.GetBytes(tag: true);

        //    ProfileDevice.DareEnvelope = DareEnvelope.Encode(bytes,
        //        signingKey: keyPublicSign);

        //    return ProfileDevice;

        //    }

        ///// <summary>
        ///// Generate a new profile.
        ///// </summary>
        ///// <param name="meshMachine">Machine context for persisting keys.</param>
        ///// <param name="algorithmSign">The signature algorithm</param>
        ///// <param name="algorithmEncrypt">The encryption algorithm</param>
        ///// <param name="algorithmAuthenticate">The authentication algorithm</param>
        ///// <returns>The generated, signed profile.</returns>
        //public static ProfileDevice Generate(
        //            IMeshMachine meshMachine,
        //            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
        //            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
        //            CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
        //    algorithmSign = algorithmSign.DefaultAlgorithmSign();
        //    algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
        //    algorithmAuthenticate = algorithmAuthenticate.DefaultAlgorithmAuthenticate();
            
        //    var keySign = meshMachine.CreateKeyPair(algorithmSign, KeySecurity.Device, keyUses: KeyUses.Sign);
        //    var keyEncrypt = meshMachine.CreateKeyPair(algorithmEncrypt, KeySecurity.Device, keyUses: KeyUses.Encrypt);
        //    var keyAuthenticate = meshMachine.CreateKeyPair(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);

        //    return Generate(keySign, keyEncrypt, keyAuthenticate);
        //    }

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
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
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

        ///<summary>The <see cref="ProfileDevice"/> that this activation activates.</summary>
        public ProfileDevice ProfileDevice;

        ///<summary>The <see cref="ConnectionDevice"/> instance binding the activated device
        ///to a MeshProfile.</summary>
        public ConnectionDevice ConnectionDevice;

        ///<summary>The aggregate encryption key</summary>
        public KeyPairAdvanced KeyEncryption;

        ///<summary>The aggregate authentication key</summary>
        public KeyPairAdvanced KeyAuthentication;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public ActivationDevice() { }


        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDFDevice"/>
        /// seed.
        /// </summary>
        /// <param name="profileDevice">The device profile to activate.</param>
        /// <param name="keyCollection">Key collection to write private key values to
        /// for later use.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        public ActivationDevice(
                    ProfileDevice profileDevice,
                    KeyCollection keyCollection,
                    byte[] masterSecret = null,
                    int bits = 256) : base (
                        profileDevice, keyCollection, UdfAlgorithmIdentifier.MeshProfileDevice,
                        Constants.UDFActivationDevice, masterSecret, bits) {

            KeyEncryption = Combine(keyCollection, profileDevice.KeyEncryption,
                ActivationKey, Constants.UDFActivationDevice, Constants.UDFMeshKeySufixEncrypt);

            KeyAuthentication = Combine(keyCollection, profileDevice.KeyAuthentication,
                ActivationKey, Constants.UDFActivationDevice, Constants.UDFMeshKeySufixAuthenticate);

            // Create the (unsigned) ConnectionDevice
            ConnectionDevice = new ConnectionDevice() {
                KeyEncryption = new PublicKey(KeyEncryption.KeyPairPublic()),
                KeySignature = new PublicKey(KeySignature.KeyPairPublic()),
                KeyAuthentication = new PublicKey(KeyAuthentication.KeyPairPublic())
                };
            }
        



        /// <summary>
        /// Encrypt this activation under the ProfileDevice encryption key.
        /// </summary>
        public DareEnvelope Encode() {

            var cryptoParameters = new CryptoParameters() {
                EncryptionKeys = new List<KeyPair> { ProfileDevice.KeyEncryption.KeyPair }
                };

            var contentInfo = new Goedel.Cryptography.Dare.ContentMeta() { ContentType = "application/mmm" };

            DareEnvelope = new DareEnvelope(
                cryptoParameters,
                GetBytes(tag: true),
                contentMeta: contentInfo);

            return DareEnvelope;
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

        //public static ActivationDevice Decode(IMeshMachine meshMachine, DareEnvelope message) =>
        //        FromJSON(message.GetBodyReader(), true);


        //// is failing here because the device entry is not being written back to the catalog after the update.
        //// fix this and then some skyrim.

        //public ActivationAccount GetActivation(string accountName = null) {
        //    foreach (var activation in Activations) {
        //        switch (activation) {
        //            case ActivationAccount activationAccount:
        //                return activationAccount;
        //            }

        //        }


        //    return null;
        //    }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConnectionDevice() {
            }


        /// <summary>
        /// Decode the DareEnvelope <paramref name="envelope"/> and return the corresponding
        /// <see cref="ConnectionDevice"/> instance.
        /// </summary>
        /// <param name="envelope">The DareEnvelope to decode</param>
        /// <returns>The decoded <see cref="ConnectionDevice"/> instance.</returns>
        public static new ConnectionDevice Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="machine"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="machine">Mesh machine providing cryptographic context.</param>
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
