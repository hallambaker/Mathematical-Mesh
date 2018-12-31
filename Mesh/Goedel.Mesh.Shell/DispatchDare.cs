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
        public override ShellResult FileEncrypt(FileEncrypt Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Path.ChangeExtension(inputFile, ".dare");
            var contentType = Options.ContentType.Value ?? MimeMapping.GetMimeMapping(inputFile) ?? "";
            var cryptoParameters = new CryptoParameters();

            var Length = DareMessage.Encode(cryptoParameters, inputFile, outputFile, contentType);

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
        public override ShellResult FileDecrypt(FileDecrypt Options) {
            var inputFile = Options.Input.Value;
            var Length = DareMessage.Decode(inputFile);

            return new ResultFile() {
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult FileVerify(FileVerify Options) {
            var inputFile = Options.Input.Value;
            DareMessage.Verify(inputFile);

            return new ResultFile() {
                Filename = inputFile
                };
            }
        }
    }
