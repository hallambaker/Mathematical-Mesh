using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.FSR;

namespace Goedel.Command {

    /// <summary>
    /// Split a command line into parts.
    /// </summary>
    public partial class CommandSplitLex {

        /// <summary>
        /// Split a commandline into entries.
        /// </summary>
        /// <param name="Text">The command line to split.</param>
        /// <returns>The command line split into entries.</returns>
        public static string[] Split (string Text) {
            var CommandSplitLex = new CommandSplitLex();
            CommandSplitLex.GetToken(Text);
            return CommandSplitLex.Value.ToArray();
            }

        LexStringReader LexStringReader;

        /// <summary>
        /// Construct a parser to read from a string to be specified in GetToken (data)
        /// </summary>
        public CommandSplitLex () {
            LexStringReader = new LexStringReader(null);
            Reader = LexStringReader;
            }

        /// <summary>
        /// Parse the specified string. Note, this is only valid if no LexReader
        /// was specified in the constructor.
        /// </summary>
        /// <param name="Data">The string to parse.</param>
        /// <returns>The token value.</returns>
        public Token GetToken (string Data) {
            LexStringReader.String = Data;
            Reset();
            return GetToken();
            }


        /// <summary>
        /// Return the resulting string value
        /// </summary>
        public List<string> Value {
            get {
                if (Pending) {
                    AddParam();
                    Pending = false;
                    }
                return Arguments;
                }
            }

        // Private variables
        bool Pending = false; // if true, there is an incomplete value to be added.
        int EscapeCount = 0;
        List<string> Arguments = new List<string>();
        StringBuilder BuildValue = new StringBuilder();

        /// <summary>
        /// Reset the value buffers to start a new parse.
        /// </summary>
        public override void Reset () {
            Arguments.Clear();
            BuildValue.Clear();
            Pending = false;
            EscapeCount = 0;
            }

        /// <summary>
        /// Reset the value buffers to start a new parse.
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddParam(int c) => AddParam();

        void AddParam () {
            // Add any pending escape characters
            for (var i = 0; i < EscapeCount; i++) {
                BuildValue.Append('\\');
                }
            // Add the parameter to the build string
            var Text = BuildValue.ToString();
            if (Pending) {
                Arguments.Add(Text);
                }
            // Reset all buffers
            EscapeCount = 0;
            BuildValue.Clear();
            }

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void Ignore (int c) {
            }


        /// <summary>
        /// Start a quoted parameter, this can be null
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void BeginValue(int c) => Pending = true;

        /// <summary>
        /// Add a character to the value buffer
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddValue (int c) {
            EscapeCount = 0;
            Pending = true;
            BuildValue.Append((char)c);
            }

        /// <summary>
        /// Add a character to the value buffer
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddEscape (int c) {
            Pending = true;
            EscapeCount++;
            }

        /// <summary>
        /// Add a sequence of escape characters to the value buffer. If the final character is not
        /// a double quote, the escape characters are simply added. Otherwise, each pair of escape
        /// characters results in a single escape character and a double quote is added if the number
        /// of escape characters is odd.
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddEscapedValue (int c) {

            if (c == '\"') {
                while (EscapeCount > 1) {
                    EscapeCount -= 2;
                    BuildValue.Append('\\');
                    }
                if (EscapeCount == 1) {
                    BuildValue.Append('\"');
                    }
                }
            else {
                for (var i = 0; i < EscapeCount; i++) {
                    BuildValue.Append('\\');
                    }
                BuildValue.Append((char)c);
                }
            EscapeCount = 0;

            }

        }
    }
