﻿using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    /// <summary>
    /// Static extensions class.
    /// </summary>
    public static partial class Extensions {

        //delegate void ToBuilderDelegate (StringBuilder builder, int indent);

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units.
        /// </summary>
        /// <param name="meshItem">The item to present.</param>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="nullText">Text to provide if the item is null.</param>
        public static void ToBuilder(this MeshItem meshItem, StringBuilder builder,
                int indent, string nullText) {
            if (meshItem == null) {
                builder.AppendLine(nullText);
                }
            else {
                meshItem.ToBuilder(builder, indent);
                }
            }

        /// <summary>
        /// Locate a keypair in the set <paramref name="publicKeys"/> that has a private key in 
        /// <paramref name="keyCollection"/>
        /// </summary>
        /// <param name="keyCollection">The key collection to search.</param>
        /// <param name="publicKeys">The list of public keys to match</param>
        /// <returns>The key pair if found, otherwise <see langword="false"/></returns>
        public static CryptoKey LocatePrivate(this KeyCollection keyCollection, List<PublicKey> publicKeys) {

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
