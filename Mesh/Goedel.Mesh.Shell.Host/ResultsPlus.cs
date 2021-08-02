using System.Text;

using Goedel.Protocol.Service;

namespace Goedel.Mesh.Shell.Host {
    public partial class ShellResult {

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/> with 
        /// additional details.
        /// </summary>
        /// <returns>The string value.</returns>
        public virtual string Verbose() => ToString();
        }

    public partial class Result {

        /// <summary>
        /// Default constructor, initialize the value <see cref="Success"/> to <see langword="true"/>.
        /// </summary>
        public Result() => Success = true;

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> instance initialized with the success value and
        /// the expanded error message reason (if relevant).
        /// </summary>
        /// <returns>The <see cref="StringBuilder"/> instance.</returns>
        public virtual StringBuilder StringBuilder() {
            var Builder = new StringBuilder();

            if (!Success) {
                Builder.Append("ERROR");
                if (Reason != null) {
                    Builder.Append(" - ");
                    Builder.Append(Reason);
                    }
                Builder.Append("\n");
                }
            return Builder;

            }

        /// <summary>
        /// Converts the value of this instance to a <see langword="String"/>.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString() {
            var Builder = StringBuilder();

            return Builder.ToString();
            }



        }
    public partial class ResultStartService {
        public RudService RudService { get; set; }
        }
    }
