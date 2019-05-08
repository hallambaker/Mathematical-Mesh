using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
namespace Goedel.Mesh {

    public partial class MeshItem {

        /// <summary>
        /// The DareMessage encapsulation of this object instance.
        /// </summary>
        public virtual DareMessage DareMessage { get; protected set; }


        public static object Initialize => null;

        static MeshItem() => ContainerPersistenceStore.AddDictionary(_TagDictionary);


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MeshItem FromJSON(JSONReader JSONReader, bool Tagged = true) {
            if (JSONReader == null) {
                return null;
                }
            if (Tagged) {
                var Out = JSONReader.ReadTaggedObject(_TagDictionary);
                return Out as MeshItem;
                }
            throw new CannotCreateAbstract();
            }

        public static MeshItem Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareMessage = message;
            return result;
            }


        }

    public partial class Assertion {
        public virtual DareMessage Encode (KeyPair keyPair) {
            DareMessage = DareMessage.Encode(GetBytes(tag: true),
                    signingKey: keyPair, contentType: "application/mmm");
            return DareMessage;
            }

        public static new Assertion Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareMessage = message;
            return result;
            }
        }

    public partial class ProfileDevice {

        public override string _PrimaryKey => UDF;


        public string UDF => SignatureKey.UDF;

        public byte[] UDFBytes => SignatureKey.KeyPair.PKIXPublicKey.UDFBytes(512);


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
                SignatureKey = new PublicKey (keyPublicSign.KeyPairPublic()),
                AuthenticationKey = new PublicKey(keyPublicAuthenticate.KeyPairPublic()),
                EncryptionKey = new PublicKey(keyPublicEncrypt.KeyPairPublic())
                };

            var bytes = ProfileDevice.GetBytes(tag:true);

            ProfileDevice.DareMessage = DareMessage.Encode(bytes,
                    signingKey: keyPublicSign, contentType: "application/mmm");

            return ProfileDevice;

            }

        public static ProfileDevice Generate(
                    keyCollection KeyCollection,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                    string description = null) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();
            algorithmAuthenticate = algorithmAuthenticate.DefaultAlgorithmAuthenticate();

            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);
            var keyAuthenticate = KeyPair.Factory(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);

            var profile = Mesh.ProfileDevice.Generate(keySign, keyEncrypt, keyAuthenticate);
            profile.Description = description;

            return profile;
            }

        public static new ProfileDevice Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareMessage = message;
            return result;
            }

        }


    public partial class AssertionDevicePrivate {
        public ProfileDevice ProfileDevice;

        public override DareMessage Encode(KeyPair keyPair) {
            this.DareMessage = DareMessage.Encode(GetBytes(tag: true),
                    signingKey: keyPair, 
                    encryptionKey:ProfileDevice.EncryptionKey.KeyPair, 
                    contentType: "application/mmm");
            return DareMessage;
            }

        public static new AssertionDevicePrivate Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }

    public partial class AssertionDeviceConnection {
        public ProfileMaster ProfileMaster;

        public static new AssertionDeviceConnection Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }


    }
