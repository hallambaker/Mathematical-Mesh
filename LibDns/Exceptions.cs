using System;

namespace Goedel.DNS {
    public class TBSException : System.Exception {
        public TBSException() {
            }
        public TBSException(string message)
            : base(message) {
            }
        }
    }
