using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Catalog.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        public void FileEncrypt(
                string Input,
                string Output,
                List<string> Recipients=null,
                List<string> Signers=null,
                bool Subdirectories=false) {
            Result Result = null;

            using (var InputStream = Input.OpenFileRead()) {
                using (var OutputStream = Output.OpenFileWrite()) {
                    DAREMessage.Encode(InputStream, OutputStream);
                    }
                }

            Result = new Result() {
                Success = true,
                Reason = "Encoded file"
                };

            ReportResult(Result);
            }

        public void FileDecrypt(
                string Input,
                string Output
                ) {
            Result Result = null;

            using (var InputStream = Input.OpenFileRead()) {
                using (var OutputStream = Output.OpenFileWrite()) {
                    DAREMessage.Decode(InputStream, OutputStream);
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
