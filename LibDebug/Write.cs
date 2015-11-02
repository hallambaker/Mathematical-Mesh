using System;


namespace Goedel.Debug {
    public partial class Trace {


        /// <summary>
        /// Flag allowing output to be disabled.
        /// </summary>
        public static bool Disable {
            get { return _Disable; }
            set { _Disable = value; }
            }
        private static bool _Disable = false;


        /// <summary>
        /// Not Yet Implemented method. Cannot be disabled.
        /// </summary>
        /// <param name="Report">Text to display on the console.</param>
        public static void NYI(string Report) {
            Console.WriteLine(Report);
            }


        /// <summary>
        /// Not Yet Implemented method. Cannot be disabled.
        /// </summary>
        /// <param name="Report">Text to display on the console.</param>
        public static void TBS(string Report) {
            WriteLine(Report);
            }


        /// <summary>
        /// Output functions, pipe data to the console right now. In the future, will
        /// pipe to a file as well.
        /// </summary>
        /// <param name="Text"></param>
        public static void WriteLine(string Text) {
            if (Disable) return;
            Console.WriteLine(Text);
            //System.Diagnostics.Trace.WriteLine(Text);
            }

        public static void Write(string Text) {
            if (Disable) return;
            Console.WriteLine(Text);
            //System.Diagnostics.Trace.Write(Text);
            }

        public static void WriteLine() {
            Write("\n");
            }

        public static void WriteLine(string Text, Object Data) {
            if (Disable) return;
            var Message = String.Format(Text, Data);
            WriteLine(Message);
            }

        public static void WriteLine(string Text, params Object[] Data) {
            if (Disable) return;
            var Message = String.Format(Text, Data);
            WriteLine(Message);
            }


        public static void Write(string Text, Object Data) {
            if (Disable) return;
            var Message = String.Format(Text, Data);
            Write(Message);
            }

        public static void Write(string Text, params Object[] Data) {
            if (Disable) return;
            var Message = String.Format(Text, Data);
            Write(Message);
            }

        /// <summary>
        /// Write out a buffer to the console as hex.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Data"></param>
        public static void WriteHex(string Text, byte[] Data) {
            WriteLine(Text);

            string Line = "   ";

            for (int i = 0; i < Data.Length; i++) {
                if (i > 0) {
                    if (i % 16 == 0) {
                        WriteLine(Line);
                        Line = "   ";
                        }
                    else if (i % 8 == 0) {
                        Line = Line + "   ";
                        }
                    }
                Line = Line + string.Format (" {0:x2}", Data[i]);
                }
            WriteLine(Line);
            }

        }

    }

