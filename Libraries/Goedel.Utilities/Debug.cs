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
        public static void WriteLine(string format, params object[] arg) {

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
