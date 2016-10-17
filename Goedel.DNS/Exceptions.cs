using System;

namespace Goedel.DNS {
    /// <summary></summary>
    public class TBSException : System.Exception {
        /// <summary></summary>
        public TBSException() {
            }
        /// <summary></summary>
        public TBSException(string message)
            : base(message) {
            }
        }
    }
