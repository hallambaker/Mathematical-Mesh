using System;
using System.Diagnostics;
using System.IO;

namespace Goedel.IO {
    /// <summary>
    /// Class containing static helper methods. This should inherit from the Trace class
    /// but that is sealed.
    /// </summary>
    public class Debug {
        static bool Initialized = false;

        /// <summary>
        /// Perform standard initialization
        /// </summary>
        public static void Initialize() {
            if (Initialized) {
                return;
                }
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            var TraceFileStream = "LastTrace.txt".OpenFileWriteShare();
            var TraceWriter = TraceFileStream.OpenTextWriter();
            Trace.Listeners.Add(new TextWriterTraceListener(TraceWriter));
            }

        /// <summary>
        /// Convenience method to do formatted write to the trace output
        /// </summary>
        /// <param name="Format">A composite format string </param>
        /// <param name="Arg">An array of objects to write using format</param>
        public static void WriteLine(string Format, params object[] Arg) {
            var Text = String.Format(Format, Arg);
            Trace.WriteLine(Text);
            }


        /// <summary>
        /// Convenience method to do formatted write to the trace output
        /// </summary>
        /// <param name="Format">A composite format string </param>
        /// <param name="Arg">An array of objects to write using format</param>
        public static void Write(string Format, params object[] Arg) {
            var Text = String.Format(Format, Arg);
            Trace.Write(Text);
            }

        }
    }
