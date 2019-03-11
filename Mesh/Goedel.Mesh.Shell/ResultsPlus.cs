using System.Text;

namespace Goedel.Mesh.Shell {

    public partial class ShellResult {
        public virtual string Verbose() => ToString();
        }

    public partial class Result {

        public Result() => Success = true;

        public Result(string reason) {
            Success = true;
            Reason = reason;
            }


        public virtual StringBuilder StringBuilder() {
            var Builder = new StringBuilder();

            Builder.Append(Success ? "OK" : "ERROR");
            if (Reason != null) {
                Builder.Append(" - ");
                Builder.Append(Reason);
                }
            Builder.Append("\n");
            return Builder;

            }

        public override string ToString() {
            var Builder = StringBuilder();

            return Builder.ToString();
            }

        

        }


    public partial class ResultDeviceCreate {

        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append($"Device Profile UDF={DeviceUDF}\n");
            return Builder.ToString();
            }
        }

    public partial class ResultEntry {
        public override string ToString() => CatalogEntry?.ToString();
        }

    public partial class ResultDump {
        public override string ToString() {
            var builder = StringBuilder();
            foreach (var entry in CatalogEntries) {
                builder.Append(entry.ToString());
                builder.AppendLine();
                }
            return builder.ToString();
            }
        //public override string ToString() => Data;
        }


    public partial class ResultCredential {
        public override string ToString() {
            var Builder = new StringBuilder();
            //Builder.Append(Reason);
            //Builder.Append("/n");
            //if (Entry != null) {
            //    Builder.Append(Entry.GetUTF8());
            //    Builder.Append("/n");
            //    }
            return Builder.ToString();
            }
        }

    public partial class ResultDigest {
        public override string ToString() => Digest;
        }


    public partial class ResultEscrow {
        public override string ToString() {
            var Builder = new StringBuilder();

            foreach (var share in Shares) {
                Builder.AppendLine($"Share: {share}");
                }
            if (Filename != null) {
                Builder.AppendLine($"Written to {Filename}");
                }

            return Builder.ToString();
            }
        }

    public partial class ResultKey{
        public override string ToString() {
            var Builder = new StringBuilder();

            if (Key != null) {
                Builder.AppendLine(Key);
                }
            if (Identifier != null) {
                Builder.AppendLine(Identifier);
                }
            if (Shares != null) {
                foreach (var share in Shares) {
                    Builder.AppendLine(share);
                    }
                }
            return Builder.ToString();
            }
        }


    public partial class ResultRecover {
        public override string ToString() {
            var Builder = new StringBuilder();

            if (SignUDF != null) {
                Builder.AppendLine($"Signature Key: {SignUDF}");
                }
            foreach (var key in EncryptUDF) {
                Builder.AppendLine($"Encryption Key: {key}");
                }


            return Builder.ToString();
            }
        }

    public partial class ResultCommitment {
        public override string ToString() {
            var Builder = new StringBuilder();
            Builder.Append($"UDF={Digest}\n");
            Builder.Append($"Key={Key}");
            return Builder.ToString();
            }
        }
    }
