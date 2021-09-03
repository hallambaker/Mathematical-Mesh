#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;

namespace Goedel.Utilities {
    /// <summary>
    /// Debug trace class
    /// </summary>
    public partial class Screen {

        /// <summary>
        /// Write debug output to current trace listener.
        /// </summary>
        /// <param name="format">The format string</param>
        /// <param name="arg">Arguments to apply to the format string.</param>
        public static void WriteLine(string format, params object[] arg) =>
            WriteInfo(format, arg);


        /// <summary>
        /// Write debug output to current trace listener.
        /// </summary>
        /// <param name="format">The format string</param>
        /// <param name="arg">Arguments to apply to the format string.</param>
        public static void WriteInfo(string format, params object[] arg) {

            var caller = AssemblyStack.GetCallerMethodName();
            if (caller == "TaskFunctionality") {
                return;
                }
            if (arg == null || arg.Length == 0) {
                Console.WriteLine(format);
                }
            else {
                Console.WriteLine(format, arg);
                }




            }

        /// <summary>
        /// Write a blank line to the output
        /// </summary>
        public static void WriteLine() => Console.WriteLine();


        /// <summary>
        /// Write text to the console;
        /// </summary>
        /// <param name="text">The text to write.</param>
        public static void Write(string text) => Console.Write(text);

        }
    }
