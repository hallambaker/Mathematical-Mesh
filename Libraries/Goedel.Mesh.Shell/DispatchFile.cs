using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.IO;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Catalog.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        /// <summary>
        /// Encrypt a file under the specified cryptographic parameters.
        /// </summary>
        /// <param name="CryptoParameters">The cryptographic parameters to
        /// encrypt under.</param>
        /// <param name="Input">The input filename.</param>
        /// <param name="Output">The output filename.</param>
        /// <param name="Subdirectories">Not currently used.</param>
        public void FileEncrypt(
                CryptoParameters CryptoParameters,
            string Input,
            string Output,
            bool Subdirectories = false) {

            Result Result = null;

            using (var InputStream = Input.OpenFileRead()) {
                using (var OutputStream = Output.OpenFileWrite()) {
                    DAREMessage.Encode(CryptoParameters, InputStream, OutputStream);
                    }
                }

            Result = new Result() {
                Success = true,
                Reason = "Encoded file"
                };

            ReportResult(Result);
            }



        /// <summary>
        /// Decrypt a file using the specified key collection
        /// </summary>
        /// <param name="KeyCollection">The key collection for resolving private 
        /// keys.</param>
        /// <param name="Input">The input filename.</param>
        /// <param name="Output">The output filename.</param>
        public void FileDecrypt(
                KeyCollection KeyCollection
,
            string Input,
            string Output) {
            Result Result = null;

            using (var InputStream = Input.OpenFileRead()) {
                using (var OutputStream = Output.OpenFileWrite()) {
                    DAREMessage.Decode(InputStream, OutputStream, KeyCollection);
                    }
                }

            Result = new Result() {
                Success = true,
                Reason = "Decoded File"
                };

            ReportResult(Result);
            }



        }
    }
