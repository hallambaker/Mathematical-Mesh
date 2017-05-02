using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Mesh {

    public partial class MeshProtocol {

        }


    public partial class MeshResponse {

        /// <summary>
        /// Numeric status return code value
        /// </summary>
        public override int StatusCode {
            get { return Status; }
            set { Status = value; }
            }

        /// <summary>
        /// Description of the status code (for debugging).
        /// </summary>
        public override string StatusDescriptionCode {
            get {
                return StatusDescription;
                }
            set {
                StatusDescription = value;
                }
            }

        /// <summary>
        /// Set the default status code (success)
        /// </summary>
        protected override void _Initialize() {
            StatusCode = 201;
            StatusDescriptionCode = "Operation completed successfully";
            }

        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = MeshResponse.FromTagged(Text);

            return Result;
            }
        }

    public partial class MeshRequest {
        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = MeshRequest.FromTagged(Text);

            return Result;
            }
        }
    /// <summary>
    ///
    /// Reports the success or failure of a ConnectPending transaction.
    /// </summary>
    public partial class ConnectPendingResponse { 

        /// <summary>
        /// Find connection request matching a request.
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns></returns>
        public ConnectionRequest Match (string UDF) {
            foreach (var Request in Pending) {
                if (Request.Identifier == UDF) { // ToDo: audit use of identifier vs UDF
                    return Request.Data;
                    }
                }
            return null;
            }

        }
    }
