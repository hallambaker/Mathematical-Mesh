using System.Text;

namespace Goedel.Mesh.Shell {

    public partial class Result {
        public virtual StringBuilder StringBuilder() {
            var Builder = new StringBuilder();

            Builder.Append(Success ? "OK" : "ERROR");
            if (Reason != null) {
                Builder.Append(" - ");
                Builder.Append(Reason);
                }
            Builder.Append("/n");
            return Builder;

            }

        public override string ToString() {
            var Builder = StringBuilder();

            return Builder.ToString();
            }

        public string Verbose() => "";

        }


    public partial class ResultDeviceCreate {

        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append($"Device Profile UDF={DeviceUDF}/n");
            return Builder.ToString();
            }
        }

    public partial class ResultDump {
        public override string ToString() => Data;
        }


    public partial class ResultCredential {
        public override string ToString() {
            var Builder = StringBuilder();
            Builder.Append(Reason);
            Builder.Append("/n");
            if (Entry != null) {
                Builder.Append(Entry.GetUTF8());
                Builder.Append("/n");
                }
            return Builder.ToString();
            }
        }

    }
