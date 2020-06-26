using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Mesh {


    public partial class ProfileMesh {

        

        //public string UDF => KeyOfflineSignature.UDF;
        //public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);

        //public override string _PrimaryKey => KeyOfflineSignature.UDF;




        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMesh() {
            }


        //public ProfileMesh(
        //            KeyPair keySign, KeyPair keyEscrow, KeyPair keyEncrypt) {
        //    KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
        //    KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());

        //    }


        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
        /// <param name="secretSeed">The secret seed value.</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="keyCollection"/>.</param>
        public ProfileMesh(
                    KeyCollection keyCollection,
                    PrivateKeyUDF secretSeed,
                    bool persist = false) {
            //var keyEncrypt = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixEncrypt);
            //var keySign = Derive(keyCollection, secretSeed, Constants.UDFMeshKeySufixSign);

            var meshKeyType = MeshKeyType.MasterProfile;
            var keySign = secretSeed.BasePrivate( meshKeyType | MeshKeyType.Sign);
            var keyEncrypt = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt);

            KeyOfflineSignature = new KeyData(keySign.KeyPairPublic());
            KeyEncryption = new KeyData(keyEncrypt.KeyPairPublic());

            if (persist) {
                keyCollection.Persist(KeyOfflineSignature.UDF, secretSeed, false);
                }
            }


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="ProfileMesh"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new ProfileMesh Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileMesh;


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, KeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Profile Mesh");
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

            }

        }

    }
