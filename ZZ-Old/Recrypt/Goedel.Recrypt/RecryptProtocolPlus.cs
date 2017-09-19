using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Recrypt {

    public partial class RecryptProtocol {

        }


    public partial class RecryptResponse {

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
            var Result = RecryptResponse.FromTagged(Text);

            return Result;
            }
        }

    public partial class RecryptRequest {
        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = RecryptRequest.FromTagged(Text);

            return Result;
            }
        }

    }
