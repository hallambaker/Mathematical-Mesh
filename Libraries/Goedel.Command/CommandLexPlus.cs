using System.Text;

using Goedel.FSR;



namespace Goedel.Command {

    /// <summary>
    /// Lexical analyzer for command line parsing.
    /// </summary>
    public partial class CommandLex {
        LexStringReader LexStringReader;

        /// <summary>
        /// Construct a parser to read from a string to be specified in GetToken (data)
        /// </summary>
        public CommandLex() {
            LexStringReader = new LexStringReader(null);
            Reader = LexStringReader;
            }

        /// <summary>
        /// Parse the specified string. Note, this is only valid if no LexReader
        /// was specified in the constructor.
        /// </summary>
        /// <param name="Data">The data to parse</param>
        /// <returns>The token value.</returns>
        public Token GetToken(string Data) {
            LexStringReader.String = Data;
            Reset();
            return GetToken();
            }


        /// <summary>
        /// Return the resulting string value
        /// </summary>
        public string Value => BuildValue.ToString();

        /// <summary>
        /// Return the resulting string value
        /// </summary>
        public string Flag => BuildFlag.ToString();

        /// <summary>
        /// If true, flag was negated.
        /// </summary>
        public bool Not { get; set; }

        StringBuilder BuildValue = new();
        StringBuilder BuildFlag = new();

        /// <summary>
        /// Reset the value buffers to start a new parse.
        /// </summary>
        public override void Reset() {
            BuildValue.Clear();
            BuildFlag.Clear();
            }

        /// <summary>
        /// Reset the value buffers to start a new parse.
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void Reset(int c) => Reset();

        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void Ignore(int c) {
            }

        /// <summary>
        /// Add a character to the value buffer
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddValue(int c) => BuildValue.Append((char)c);

        /// <summary>
        /// Add a character to the flag buffer
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddFlag(int c) => BuildFlag.Append((char)c);

        /// <summary>
        /// N of possible NO flag
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddFlagN(int c) => BuildFlag.Append((char)c);

        /// <summary>
        /// O of possible NO flag
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void AddFlagNo(int c) {
            BuildFlag.Clear(); // delete 'no' prefix
            Not = true;
            }
        /// <summary>
        /// Abort parsing, the command cannot be read.
        /// </summary>
        /// <param name="c">The character read</param>
        public virtual void Abort(int c) {
            }



        }
    }
