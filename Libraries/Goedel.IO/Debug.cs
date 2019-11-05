using System;
using System.Diagnostics;

namespace Goedel.IO {
    /// <summary>
    /// Class containing static helper methods. This should inherit from the Trace class
    /// but that is sealed.
    /// </summary>
    public class Debug : Initialization {
        static bool Flag = false;

        /// <summary>
        /// Class initialization routine.
        /// </summary>
        /// <param name="TestMode">If true the first time the initialization is
        /// called, initializes parameters in test mode.</param>
        public static void Initialize(bool TestMode = false) =>
            Initialize(ref Flag, Initialization, TestMode);

        /// <summary>
        /// Perform standard initialization
        /// </summary>
        public static void Initialization(bool TestMode = false) {
            Trace.Listeners.Add(new GoedelTraceListener());

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

    /// <summary>
    /// 
    /// </summary>
    public class GoedelTraceListener : TraceListener {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message) => Console.Write(message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message) => Console.WriteLine(message);
        }
    }
