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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareEncode(DareEncode Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Path.ChangeExtension(inputFile, ".dare");
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";


            ContextAccount contextAccount = null;
            try {
                contextAccount = GetContextAccount(Options);
                }
            catch  {

                }

            IKeyLocate keyLocate = (IKeyLocate) contextAccount ?? GetKeyCollection(Options);
            // we are getting the wrong one here. we want the encryption recipients from the contacts file.



            var cryptoParameters = GetCryptoParameters(keyLocate, Options);

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
        /// <param name="Options">The command line options.</param>)
        /// <returns>Mesh result instance</returns>
        public override ShellResult DareDecode(DareDecode Options) {
            var inputFile = Options.Input.Value;
            using var contextAccount = GetContextAccount(Options);

            var Length = DareEnvelope.Decode(inputFile, keyCollection: contextAccount);

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
