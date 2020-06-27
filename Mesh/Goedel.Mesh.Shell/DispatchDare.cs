using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.Utilities;

using System.IO;
using Goedel.Mesh.Client;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEncode(DareEncode options) {
            var inputFile = options.Input.Value;
            var outputFile = Path.ChangeExtension(inputFile, ".dare");
            var contentType = options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";

            var keyLocate = GetKeyCollection (options);
            // we are getting the wrong one here. we want the encryption recipients from the contacts file.



            var cryptoParameters = GetCryptoParameters(keyLocate, options);

            var ContentInfo = new ContentMeta() {
                Filename = inputFile,
                ContentType = contentType
                };


            var Length = DareEnvelope.Encode(cryptoParameters, inputFile, outputFile,
                contentMeta: ContentInfo);

            return new ResultFile() {
                Filename = outputFile,
                TotalBytes = (int)Length
                };

            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>)
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDecode(DareDecode options) {
            var inputFile = options.Input.Value;
            var keyLocate = GetKeyCollection(options);

            var Length = DareEnvelope.Decode(inputFile, keyCollection: keyLocate);

            return new ResultFile() {
                TotalBytes = (int)Length
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareVerify(DareVerify options) {
            var inputFile = options.Input.Value;
            var result = DareEnvelope.Verify(inputFile);

            return new ResultFile() {
                Filename = inputFile,
                Verified = result
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEARL(DareEARL options) {
            var inputFile = options.Input.Value;
            throw new NYI();
            //var result = DareEnvelope.Verify(inputFile);

            //return new ResultFile() {
            //    Filename = inputFile,
            //    Verified = result
            //    };
            }

        }
    }
