using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {
    public partial class MeshResponse {

        /// <summary>
        /// Numeric status return code value
        /// </summary>
        public override int StatusCode {
            get { return Status; }
            set { _Status = value; }
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


        }
    }
