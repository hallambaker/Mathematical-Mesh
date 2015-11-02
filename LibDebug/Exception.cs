using System;
using System.Collections.Generic;

namespace Goedel {

    public class NullException : System.Exception {
        }

    public class Throw : System.Exception {
        protected string _Message;

        public override string Message { get { return _Message; } }

        public Throw(string Message) {
            _Message = Message;
            }

        public static void If(bool Test, string Report) {
            if (Test) throw new Throw (Report);
            }

        public static void IfNot(bool Test, string Report) {
            if (!Test) throw new Throw (Report);
            }

        public static void Always(string Report) {
            throw new Throw (Report);
            }

        }

    /// <summary>
    /// The required cryptographic key cannot be found.
    /// </summary>
    public partial class KeyNotFoundException : System.Exception {
        /// <summary>
        /// The report message
        /// </summary>
        public override string Message { get { return "Key not found"; } }

        /// <summary>
        /// Throw the exception if the condition is true
        /// </summary>
        /// <param name="Test">Condition to test.</param>
        public static void If(bool Test) {
            if (Test) {
                throw new KeyNotFoundException();
                }
            }

        /// <summary>
        /// Throw the exception if the condition is false
        /// </summary>
        /// <param name="Test">Condition to test.</param>
        public static void IfNot(bool Test) {
            if (!Test) {
                throw new KeyNotFoundException();
                }
            }
        }

    }
