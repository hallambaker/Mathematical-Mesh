using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.FSR {

    /// <summary>
    /// Wrapper class for stream or textreader which provides the get character
    /// and unget character methods needed for the lexical analyzer. For convenience,
    /// </summary>
    public class LexReader : IDisposable {
        Stream Stream = null;
        TextReader TextReader = null;
        bool Pending = false;

        /// <summary>
        /// File path of input document, used for generating error messages.
        /// </summary>
        public string FilePath = null;

        /// <summary>If true, stream has been read to end of file.</summary>
        public bool EOF = false;
        /// <summary>Last character read (as integer)</summary>
        public int LastInt;
        /// <summary>Last character read.</summary>
        public char LastChar => LastInt > 0 ? (char)LastInt : '.'; 

        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        protected LexReader() {
            }

        // Public constructors
        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        /// <param name="Stream">Input data</param>
        public LexReader(Stream Stream) {
            Init(Stream);
            }

        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        /// <param name="TextReader">Input data</param>
        public LexReader(TextReader TextReader) {
            Init(TextReader);
            }

        /// <summary>
        /// Initialize the reader
        /// </summary>
        /// <param name="Stream">Input data</param>
        protected void Init(Stream Stream) {
            this.Stream = Stream;
            Init(new StreamReader(Stream));
            }

        /// <summary>
        /// Initialize the reader
        /// </summary>
        /// <param name="TextReader">Input data</param>
        protected void Init(TextReader TextReader) {
            this.TextReader = TextReader;
            }

        /// <summary>
        /// Free resources.
        /// </summary>
        public virtual void Dispose() {
            if (Stream != null) { Stream.Dispose(); }
            if (TextReader != null) { TextReader.Dispose(); }
            }

        /// <summary>
        /// Get the next character from the lexical stream ignoring CR characters.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public virtual bool Get() {
            if (Pending & !EOF) {
                Pending = false;
                return true;
                }
            LastInt = TextReader.Read();
            if (LastInt < 0) {
                EOF = true;
                return false;
                }
            else if (LastInt == '\r') {
                LastInt = TextReader.Read();
                }

            return true;
            }

        /// <summary>
        /// Get the next character from the lexical stream.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public virtual bool GetBinary() {
            if (Pending & !EOF) {
                Pending = false;
                return true;
                }
            LastInt = TextReader.Read();
            if (LastInt < 0) {
                EOF = true;
                return false;
                }

            return true;
            }

        /// <summary>
        /// Unget the last character read. Only one character is buffered, multiple calls to 
        /// unget without calling get() have no effect.
        /// </summary>
        public virtual void UnGet() {
            Pending = true;
            }

        }

    /// <summary>
    /// Lexical reader reading from string input.
    /// </summary>
    public class LexStringReader : LexReader {

        /// <summary>
        /// Set the data value and reset the read index.
        /// </summary>
        public string String {
            set {
                Data = value;
                Count = 0;
                }
            }

        string Data;
        int Count;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Data">The string to be read.</param>
        public LexStringReader(string Data) {
            String = Data;
            }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public override void Dispose() {
            }

        /// <summary>
        /// Get the next character from the lexical stream ignoring CR characters.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public override bool Get() {
            if (Count < Data.Length) {
                LastInt = (int)Data[Count];
                Count++;
                return true;
                }
            else {
                EOF = true;
                return false;
                }
            }

        /// <summary>
        /// Unget the last character read. Only one character is buffered, multiple calls to 
        /// unget without calling get() have no effect.
        /// </summary>
        public override void UnGet() {
            if (Count > 0) {
                Count--;
                }
            }
        }

    }
