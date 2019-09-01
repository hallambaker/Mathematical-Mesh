using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEncode(DareEncode Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Path.ChangeExtension(inputFile, ".dare");
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";


            var keyCollection = KeyCollection(Options);
            var cryptoParameters = GetCryptoParameters(keyCollection, Options);

            var ContentInfo = new ContentInfo() {
                Filename = inputFile,
                ContentType = contentType
                };


            var Length = DareEnvelope.Encode(cryptoParameters, inputFile, outputFile, 
                contentInfo: ContentInfo);

            return new ResultFile() {
                Filename = outputFile,
                TotalBytes = (int)Length
                };

            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>)
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDecode(DareDecode Options) {
            var inputFile = Options.Input.Value;
            var keyCollection = KeyCollection(Options);


            var Length = DareEnvelope.Decode(inputFile, keyCollection: keyCollection);

            return new ResultFile() {
                TotalBytes = (int)Length
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareVerify(DareVerify Options) {
            var inputFile = Options.Input.Value;
            var result = DareEnvelope.Verify(inputFile);

            return new ResultFile() {
                Filename = inputFile,
                Verified = result
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEARL(DareEARL Options) {
            var inputFile = Options.Input.Value;
            throw new NYI();
            //var result = DareEnvelope.Verify(inputFile);

            //return new ResultFile() {
            //    Filename = inputFile,
            //    Verified = result
            //    };
            }

        }
    }
