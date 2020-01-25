using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System.Text;
namespace Goedel.Mesh {

    public interface IProcessResult {
        }

    public partial class MeshItem {

        /// <summary>
        /// The DareEnvelope encapsulation of this object instance.
        /// </summary>
        public virtual DareEnvelope DareEnvelope { get; protected set; }


        public static object Initialize => null;

        static MeshItem() => AddDictionary(ref _TagDictionary);


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

        public static MeshItem Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
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
        public virtual void ToBuilder(StringBuilder builder, int indent = 0, IMeshMachine machine = null) =>
            _ = builder.AppendLine($"[{_Tag}]");


        }

    public partial class Assertion {
        public virtual DareEnvelope Encode(KeyPair keyPair) {
            DareEnvelope = DareEnvelope.Encode(GetBytes(tag: true),
                signingKey: keyPair);
            return DareEnvelope;
            }

        public DareEnvelope Sign(KeyPair SignatureKey) {
            DareEnvelope = DareEnvelope.Encode(GetBytes(true), signingKey: SignatureKey);
            return DareEnvelope;
            }

        public static new Assertion Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }

    public partial class Message : IProcessResult {



        /// <summary>
        /// Return the identifier for a response to this message.
        /// </summary>
        /// <returns>The response identifier.</returns>
        public string GetResponseID() => MakeResponseID(MessageID);

        public static string MakeResponseID(string udf) {
            var buffer = udf.FromBase32();
            var length = (buffer.Length).Minimum(128);
            switch ((UDFTypeIdentifier)buffer[0]) {
                case (UDFTypeIdentifier.DigestSHA_3_512): {
                    return UDF.ContentDigestOfUDF(udf, length, CryptoAlgorithmID.SHA_3_512);
                    }
                default: {
                    return UDF.ContentDigestOfUDF(udf, length);
                    }
                }
            }

        }
    }
