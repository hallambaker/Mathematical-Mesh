// Eliminate: Using System.Diagnostics instead now.

//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Goedel.Utilities {

//    /// <summary>
//    /// Extension methods class
//    /// </summary>
//    public static class TraceX {

//        // ToDo: Eliminate as superfluous, use the trace service instead.

//        /// <summary>
//        /// Convenience method to do formatted write to the trace output
//        /// </summary>
//        /// <param name="Format">A composite format string </param>
//        /// <param name="Arg">An array of objects to write using format</param>
//        /// <returns>The formatted string</returns>
//        public static string FormatX(this string Format, params object[] Arg) {
//            return String.Format(Format, Arg);

//            }

//        /// <summary>
//        /// Mark code as needing fixing.
//        /// </summary>
//        /// <param name="Report">Comment to report to the trace output.</param>
//        public static void TBS (string Report) {
//            Debug.WriteLine("To be Specified [{0}]".FormatX(Report));
//            }

//        /// <summary>
//        /// Formatted Debug method
//        /// </summary>
//        /// <param name="Format">Format string</param>
//        /// <param name="Arg">Arguments</param>
//        public static void WriteLine(string Format, params object[] Arg) {
//            Debug.WriteLine(String.Format(Format, Arg));
//            }
//        }
//    }
