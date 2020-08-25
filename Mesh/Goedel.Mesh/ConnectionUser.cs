using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Text;

namespace Goedel.Mesh {
    public partial class ConnectionUser {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ConnectionUser> EnvelopedConnectionUser =>
            envelopedConnectionUser ?? new Enveloped<ConnectionUser>(Enveloped).
                    CacheValue(out envelopedConnectionUser);
        Enveloped<ConnectionUser> envelopedConnectionUser;


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ConnectionUser() {
            }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Connection User");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            //builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");

            //if (KeysOnlineSignature != null) {
            //    foreach (var online in KeysOnlineSignature) {
            //        builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
            //        }
            //    }
            builder.AppendIndent(indent, $"KeyEncryption:       {DeviceEncryption.UDF} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {DeviceAuthentication.UDF} ");

            }
        }

    }
