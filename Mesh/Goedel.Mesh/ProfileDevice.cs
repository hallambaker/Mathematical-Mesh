using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Text;
namespace Goedel.Mesh {


    public partial class ProfileDevice {

        ///<summary>The UDF profile constant used for key derrivation 
        ///<see cref="Constants.UDFActivationDevice"/></summary>
        public override string UDFKeyDerrivation => Constants.UDFActivationDevice;

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
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        /// <param name="secret">Specifies a seed from which to generate the ProfileDevice</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileDevice(
                    KeyCollection keyCollection,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                byte[] secret = null,
                bool? persist = null) : this (keyCollection,
                    new PrivateKeyUDF(UdfAlgorithmIdentifier.MeshProfileDevice, 
                        algorithmEncrypt, algorithmSign, algorithmAuthenticate, secret),
                    persist: (persist != null ? persist==true : secret == null)) {}


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

        ///<summary>The UDF profile constant used for key derrivation. This is the
        ///same as the value specified in the corresponding profile.</summary>
        public override string UDFKeyDerrivation => ProfileDevice.UDFKeyDerrivation;

        ///<summary>The connection value.</summary>
        public override Connection Connection => ConnectionDevice;

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
        /// Construct a new <see cref="ActivationDevice"/> instance for the profile
        /// <paramref name="profileDevice"/>. The property <see cref="Activation.ActivationKey"/> is
        /// calculated from the values specified for the activation type.
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The public key value is calculated for  <see cref="KeyEncryption"/> ,
        ///  <see cref="Activation.KeySignature"/>  and  <see cref="KeyAuthentication"/>,
        /// and registered in the KeyCollection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="keyCollection">The key collection to register the 
        /// <see cref="Activation.KeySignature"/> public key to.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationDevice(
                    ProfileDevice profileDevice,
                    KeyCollection keyCollection,
                    byte[] masterSecret = null,
                    int bits = 256) : base (
                        profileDevice, keyCollection, UdfAlgorithmIdentifier.MeshProfileDevice,
                        Constants.UDFActivationDevice, masterSecret, bits) {
            ProfileDevice = profileDevice;

            KeyEncryption = Combine(keyCollection, profileDevice.KeyEncryption,
                ActivationKey, Constants.UDFMeshKeySufixEncrypt);

            KeyAuthentication = Combine(keyCollection, profileDevice.KeyAuthentication,
                ActivationKey, Constants.UDFMeshKeySufixAuthenticate);

            // Create the (unsigned) ConnectionDevice
            ConnectionDevice = new ConnectionDevice() {
                KeyEncryption = new PublicKey(KeyEncryption.KeyPairPublic()),
                KeySignature = new PublicKey(KeySignature.KeyPairPublic()),
                KeyAuthentication = new PublicKey(KeyAuthentication.KeyPairPublic())
                };
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
