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
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
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

            var meshKeyType = MeshKeyType.DeviceProfile;
            var keySign = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign);
            var keyEncrypt = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt);
            var keyAuthenticate = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Authenticate);

            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            KeyAuthentication = new PublicKey(keyAuthenticate.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }

            Sign(keySign);
            }


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ProfileDevice Decode(DareEnvelope envelope,
                    KeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileDevice;

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, KeyCollection keyCollection = null) {

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
        public ConnectionDevice ConnectionDevice { get; set; }

        /////<summary>The aggregate encryption key</summary>
        //public KeyPairAdvanced KeyEncryption { get; set; }

        /////<summary>The aggregate authentication key</summary>
        //public KeyPairAdvanced KeyAuthentication { get; set; }


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
        /// The public key values are calculated for Encryption, Signature and Authentication
        /// and used to construct the corresponding <see cref="ConnectionDevice"/>
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        /// 
        public ActivationDevice(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base (
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationDevice, masterSecret, bits) {
            ProfileDevice = profileDevice;

            var keyEncryption = profileDevice.KeyEncryption.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Encrypt);
            var keyAuthentication = profileDevice.KeyAuthentication.ActivatePublic(ActivationKey,
                    MeshKeyType | MeshKeyType.Authenticate);

            // Create the (unsigned) ConnectionDevice
            ConnectionDevice = new ConnectionDevice() {
                KeyEncryption = new PublicKey(keyEncryption.KeyPairPublic()),
                KeySignature = new PublicKey(KeySignature.KeyPairPublic()),
                KeyAuthentication = new PublicKey(keyAuthentication.KeyPairPublic())
                };
            }


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ActivationDevice"/>
        /// using keys from <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ActivationDevice Decode(DareEnvelope envelope,
                    KeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ActivationDevice;


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the mesh machine <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">Mesh machine providing cryptographic context.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, KeyCollection keyCollection = null) {
            builder.AppendIndent(indent, $"Activation Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeySignature:        {KeySignature} ");
            }

        }

    public partial class ConnectionDevice {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConnectionDevice() {
            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ConnectionDevice Decode(DareEnvelope envelope,
                    KeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ConnectionDevice;

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, KeyCollection keyCollection = null) {

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
