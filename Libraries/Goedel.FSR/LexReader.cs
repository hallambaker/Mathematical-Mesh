using System;
using System.IO;
using Goedel.Utilities;

namespace Goedel.FSR {

    /// <summary>
    /// Wrapper class for stream or textreader which provides the get character
    /// and unget character methods needed for the lexical analyzer. For convenience,
    /// </summary>
    public class LexReader : Disposable {
        Stream stream = null;
        TextReader textReader = null;
        bool pending = false;

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


        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        public LexReader(string filename) : 
            this(new FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, 
                    System.IO.FileShare.Read)) {
            }

        // Public constructors
        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        /// <param name="Stream">Input data</param>
        public LexReader(Stream Stream) => Init(Stream);

        /// <summary>
        /// Create new lexical analyzer
        /// </summary>
        /// <param name="TextReader">Input data</param>
        public LexReader(TextReader TextReader) => Init(TextReader);

        /// <summary>
        /// Initialize the reader
        /// </summary>
        /// <param name="stream">Input data</param>
        protected void Init(Stream stream) {
            this.stream = stream;
            Init(new StreamReader(stream));
            }

        /// <summary>
        /// Initialize the reader
        /// </summary>
        /// <param name="textReader">Input data</param>
        protected void Init(TextReader textReader) => this.textReader = textReader;

        /// <summary>
        /// Free resources.
        /// </summary>
        protected override void Disposing() {
            stream?.Dispose();
            textReader?.Dispose();
            }

        /// <summary>
        /// Get the next character from the lexical stream ignoring CR characters.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public virtual bool Get() {
            if (pending & !EOF) {
                pending = false;
                return true;
                }
            LastInt = textReader.Read();
            if (LastInt < 0) {
                EOF = true;
                return false;
                }
            else if (LastInt == '\r') {
                LastInt = textReader.Read();
                }

            return true;
            }

        /// <summary>
        /// Get the next character from the lexical stream.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public virtual bool GetBinary() {
            if (pending & !EOF) {
                pending = false;
                return true;
                }
            LastInt = textReader.Read();
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
        public virtual void UnGet() => pending = true;

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
                data = value;
                count = 0;
                }
            }

        string data;
        int count;


        /// <summary>
        /// Free resources.
        /// </summary>
        protected override void Disposing() {
            }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">The string to be read.</param>
        public LexStringReader(string data) => String = data;


        /// <summary>
        /// Get the next character from the lexical stream ignoring CR characters.
        /// </summary>
        /// <returns>true if the action succeeded, false otherwise.</returns>
        public override bool Get() {
            if (count < data.Length) {
                LastInt = data[count];
                count++;
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
            if (count > 0) {
                count--;
                }
            }
        }

    }
