//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;

namespace Goedel {

    /// <summary>
    /// Exception that is never thrown. Useful for 'commenting out' a
    /// try/throw block during testing.
    /// </summary>
    public abstract class NullException : System.Exception {
        }

    /// <summary>
    /// Placeholder exception class.
    /// </summary>
    public class Throw : System.Exception {
        /// <summary>
        /// The private message data.
        /// </summary>
        protected string _Message;

        /// <summary>
        /// The message data.
        /// </summary>
        public override string Message { get { return _Message; } }

        /// <summary>
        /// Create an exception with the specified message.
        /// </summary>
        /// <param name="Message"></param>
        public Throw(string Message) {
            _Message = Message;
            }

        /// <summary>
        /// Throw an exception if the specified test is not met.
        /// </summary>
        /// <param name="Test">Must be true or exception is thrown.</param>
        /// <param name="Report">Message to report.</param>
        public static void If(bool Test, string Report) {
            if (Test) throw new Throw (Report);
            }

        /// <summary>
        /// Throw an exception if the specified test is met.
        /// </summary>
        /// <param name="Test">Must be false or exception is thrown.</param>
        /// <param name="Report">Message to report.</param>
        public static void IfNot(bool Test, string Report) {
            if (!Test) throw new Throw (Report);
            }

        /// <summary>
        /// Throw an exception.
        /// </summary>
        /// <param name="Report">Message to report.</param>
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
