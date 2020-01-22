using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;

using System.Text;
namespace Goedel.Mesh {



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
        /// Alternative print routine for formatted output.
        /// </summary>
        /// <param name="builder">A string builder to direct the output to.</param>
        /// <param name="indent">Number of indents to be emitted at the start of each line.</param>
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


    }
