using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {
    public static class Extensions {

        //delegate void ToBuilderDelegate (StringBuilder builder, int indent);


        public static void ToBuilder(this MeshItem meshItem, StringBuilder builder,
                int indent, string nullText) {
            if (meshItem == null) {
                builder.AppendLine(nullText);
                }
            else {
                meshItem.ToBuilder(builder, indent);
                }
            }

        public static ProfileMesh GetProfileMaster(this DareEnvelope dareMessage) {
            var profile = ProfileMesh.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }

        public static ProfileDevice GetProfileDevice(this DareEnvelope dareMessage) {
            var profile = ProfileDevice.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }

        public static KeyPair LocatePrivate(this KeyCollection keyCollection, List<PublicKey> publicKeys) {

            foreach (var publicKey in publicKeys) {
                var keyPair = keyCollection.LocatePrivateKeyPair(publicKey.UDF);
                if (keyPair != null) {
                    return keyPair;
                    }

                }
            return null;

            }


        /// <summary>
        /// Write a formatted version of the DareEnvelope <paramref name="envelope"/> to the
        /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
        /// units of two spaces.
        /// </summary>
        /// <param name="envelope">The envelope to present.</param>
        /// <param name="builder">The string builder.</param>
        /// <param name="indent">The indentation level.</param>
        public static void Report(this DareEnvelope envelope, StringBuilder builder, int indent = 0) {
            if (envelope != null) {

                Report(envelope.Header, builder, indent);
                Report(envelope.Trailer, builder, indent);
                }
            else {
                builder.AppendIndent(indent, $"[No Envelope]");
                }

            }

        /// <summary>
        /// Write a formatted version of the DareHeader <paramref name="header"/> to the
        /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
        /// units of two spaces.
        /// </summary>
        /// <param name="header">The header to present.</param>
        /// <param name="builder">The string builder.</param>
        /// <param name="indent">The indentation level.</param>
        public static void Report(this DareHeader header, StringBuilder builder, int indent = 0) {
            if (header.Recipients != null) {
                foreach (var recipient in header.Recipients) {
                    builder.AppendIndent(indent, $"Encrypted: {recipient.KeyIdentifier}");
                    }
                }
            }

        /// <summary>
        /// Write a formatted version of the DareTrailer <paramref name="trailer"/> to the
        /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
        /// units of two spaces.
        /// </summary>
        /// <param name="trailer">The trailer to present.</param>
        /// <param name="builder">The string builder.</param>
        /// <param name="indent">The indentation level.</param>
        public static void Report(this DareTrailer trailer, StringBuilder builder, int indent = 0) {
            if (trailer?.Signatures != null) {
                foreach (var signature in trailer.Signatures) {
                    builder.AppendIndent(indent, $"Signed by: {signature.KeyIdentifier}");
                    }
                }
            }
        }
    }
