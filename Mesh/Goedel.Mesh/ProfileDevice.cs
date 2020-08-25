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

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileDevice> EnvelopedProfileDevice =>
            envelopedProfileDevice ?? new Enveloped<ProfileDevice>(Enveloped).
                    CacheValue(out envelopedProfileDevice);
        Enveloped<ProfileDevice> envelopedProfileDevice;



        ///<summary>The secret seed value used to derrive the private keys.</summary>
        PrivateKeyUDF SecretSeed { get; }


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileDevice() {
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        /// <paramref name="keyCollection"/>.</param>
        public ProfileDevice(
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                    PrivateKeyUDF secretSeed = null,
                    int bits = 256) {

            SecretSeed = secretSeed ?? new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileDevice, null, null,
                algorithmEncrypt, algorithmSign, algorithmAuthenticate,
                bits: bits);

            var meshKeyType = MeshKeyType.DeviceProfile;
            var keySign = SecretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign);
            var keyEncrypt = SecretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt);
            var keyAuthenticate = SecretSeed.BasePrivate(meshKeyType | MeshKeyType.Authenticate);

            OfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyEncryption = new KeyData(keyEncrypt.KeyPairPublic());
            KeyAuthentication = new KeyData(keyAuthenticate.KeyPairPublic());


            Sign(keySign);
            }

        /// <summary>
        /// Persist the secret seed used to generate a profile to the local machine as a non-exportable
        /// secret.
        /// </summary>
        /// <param name="keyCollection"></param>
        public void PersistSeed(IKeyCollection keyCollection = null) {
            SecretSeed.AssertNotNull(NoDeviceSecret.Throw);
            keyCollection.Persist(OfflineSignature.UDF, SecretSeed, false);
            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        /// <remarks>This is one of the few convenience decoders that cannot be replaced because
        /// ProfileDevice is frequently passed as a Publication.</remarks>
        public static new ProfileDevice Decode(DareEnvelope envelope,
                    IKeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileDevice;
                

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Profile Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeyOfflineSignature: {OfflineSignature.UDF} ");

            if (OnlineSignature != null) {
                foreach (var online in OnlineSignature) {
                    builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
                    }
                }
            builder.AppendIndent(indent, $"KeyEncryption:       {KeyEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {KeyAuthentication.UDF} ");

            }
        }

    }
