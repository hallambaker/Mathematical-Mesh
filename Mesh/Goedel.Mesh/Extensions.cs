#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using System.Collections.Generic;
using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.KeyFile;
using Goedel.Utilities;
using Goedel.IO;

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
        public static CryptoKey LocatePrivate(this IKeyCollection keyCollection, List<KeyData> publicKeys) {

            foreach (var publicKey in publicKeys) {
                if (keyCollection.LocatePrivateKeyPair(publicKey.Udf, out var keyPair)) {
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


        /// <summary>
        /// Convert key pair to specified format
        /// </summary>
        /// <param name="keyData">Keypair to convert</param>
        /// <param name="KeyFileFormat">Format to convert to</param>
        /// <returns>The keyfile data</returns>
        public static void ToKeyFile(
                this KeyData keyData,
                string filename,
                KeyFileFormat KeyFileFormat = KeyFileFormat.Default) {
            var data = keyData.GetKeyPair(KeySecurity.Exportable).ToKeyFile(KeyFileFormat);

            filename.WriteFileNew(data);
            }

        }
    }
