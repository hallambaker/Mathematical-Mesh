using System;
using System.IO;

namespace Goedel.Registry {

    /// <summary>
    /// Preformatted headers to write to scrupt file output.
    /// </summary>
    public class ScriptOutput {
        /// <summary>The text writer to output text to.</summary>
        public TextWriter _Output;

        /// <summary>The current indent prefix.</summary>
		public string _Indent = "";

        /// <summary>
        /// Constructor to write to the specified output.
        /// </summary>
        /// <param name="Output">The output stream</param>
        public ScriptOutput (TextWriter Output) {
            this._Output = Output;
            }

        }

    /// <summary>Token types</summary>
    public enum TokenType {
        /// <summary>A begin token. This is either a start brace or an increase in indent level.</summary>
        BEGIN = 0,
        /// <summary>An end token, this is either a close brace or a return to a previous indent level.</summary>
        END = 1,
        /// <summary>A label token.</summary>
        LABEL = 2,
        /// <summary>A literal token.</summary>
        LITERAL = 3,
        /// <summary>A quoted string</summary>
        STRING = 4,
        /// <summary>An integer</summary>
        INTEGER = 5,
        /// <summary>A floating point number</summary>
        FLOAT = 6,
        /// <summary>An invalid token</summary>
        INVALID = 7,
        /// <summary>A comment</summary>
        COMMENT = 8,
        /// <summary>Null</summary>
        NULL = 9,
        /// <summary>A separator</summary>
        SEPARATOR = 10,
        /// <summary>Block text</summary>
        TEXT = 11
        }

    /// <summary>Exceptions. These need to be fixed up.</summary>
    [Serializable]
    public class GoedelParseException : System.Exception {
        //Position Position;

        /// <summary>General parse error</summary>
        /// <param name="Message">Message for user</param>/// 
        public GoedelParseException (string Message)
            : base(Message) {


            //this.Position = new Position("Unknown");
            }

        /// <summary>General parse error</summary>
        /// <param name="Message">Message for user</param>
        /// <param name="Position">position in the file</param>
        public GoedelParseException (string Message, Position Position) :
            base(Message + " at Line " + Position.Ln + " Col " + Position.Col + " in file " + Position.File) {

            //this.Position = Position;
            }
        }

    /// <summary>Finite state analyzer</summary>
    public class Lexer {

        /// <summary>Character types</summary>
        public enum CharType {
            /// <summary>Whitespace, spaces, tabs</summary>
            WhiteSpace = 0,
            /// <summary>0-9</summary>
            Digit = 1,
            /// <summary>a-z</summary>
            Lower = 2,
            /// <summary>A-Z</summary>
            Upper = 3,
            /// <summary>_</summary>
            Underscore = 4,
            /// <summary>/</summary>
            Slash = 5,
            /// <summary>\</summary>
            BackSlash = 6,

            /// <summary>"</summary>
            DoubleQuote = 7,
            /// <summary>@</summary>
            At = 8,
            /// <summary>{</summary>
            Left = 9,
            /// <summary>}</summary>
            Right = 10,
            /// <summary>.</summary>
            Period = 11,
            /// <summary>,</summary>
            Comma = 12,

            /// <summary>Linefeed</summary>
            Line = 13,
            /// <summary>Carriage Return</summary>
            CR = 14,
            /// <summary>Any other character</summary>
            Other = 15
            }

        static int[,] StateTable = new int[19, 16] {
            //  WS 0-9  a-z  A-Z    _    /    \    "    @    {    }    .    ,    |  CR   -
            //  0,   1,   2,   3,   4,   5,   6,   7,   8,   9,  10,  11,  12,  13, 14. 15
            {   0,   5,   1,   1,   2,   6,  -1,   8,  11,   3,   4,  -1,  16,  17,  -1,  -1 }, // 0
            {  -1,   1,   1,   1,   1,  -1,  -1,  -1,  -1,  -1,  -1,   1,  -1,  -1,  -1,  -1 }, // 1
            {  -1,   1,   1,   1,   2,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }, // 2

            // Braces 
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }, // 3
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }, // 4
            
            // Integers (no support for hex, floats yet
            {  -1,   5,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }, // 5
            
            // Only line mode comments supported 
            {  -1,  -1,  -1,  -1,  -1,   7,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }, // 6
            {   7,   7,   7,   7,   7,   7,   7,   7,   7,   7,   7,   7,   7,  -1,  -1,  -1 }, // 7

            // Ordinary strings with regular escape encoding

            {   8,   8,   8,   8,   8,   8,  10,   9,   8,   8,   8,   8,   8,   8,   8,  8 }, // 8
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 9         
            {  -1,   8,   8,  -1,  -1,  -1,   8,   8,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 10

            // @ literals
            {  -1,  -1,  14,  14,  15,  -1,  -1,  12,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 11
            {  12,  12,  12,  12,  12,  12,  12,  13,  12,  12,  12,  12,  12,  -1,  -1, -1  }, // 12
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  12,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 13
            {  -1,  14,  14,  14,  14,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 14
            {  -1,  14,  14,  14,  15,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1  }, // 15

            // Comma
            {  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1, -1 }, // 16
            
            // Line
            {  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  -1,  18 },  // 18
            {  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  18,  -1,  18 }  // 18
            };

        static TokenType[] TokenTable = {
            TokenType.NULL,             // 0
            TokenType.LABEL,            // 1
            TokenType.INVALID,          // 2
            TokenType.BEGIN,            // 3
            TokenType.END,              // 4
            TokenType.INTEGER,          // 5

            TokenType.INVALID,          // 6
            TokenType.COMMENT,          // 7
            TokenType.INVALID,          // 8
            TokenType.STRING,           // 9
            TokenType.INVALID,          // 10

            TokenType.INVALID,          // 11
            TokenType.INVALID,          // 12
            TokenType.STRING,           // 13
            TokenType.LITERAL,          // 14
            TokenType.INVALID,          // 15
            TokenType.SEPARATOR,        // 16
            TokenType.TEXT,             // 17
            TokenType.TEXT              // 18
            };


        enum ActionType {
            Null,
            Add,
            Escape
            }

        static ActionType[] ActionTable = {
            ActionType.Null,    //  0
            ActionType.Add,     //  1
            ActionType.Add,     //  2
            ActionType.Add,     //  3
            ActionType.Add,     //  4
            ActionType.Add,     //  5
            ActionType.Null,    //  6
            ActionType.Add,     //  7
            ActionType.Escape,  //  8
            ActionType.Null,    //  9
            ActionType.Null,    // 10
            ActionType.Null,    // 11
            ActionType.Add,     // 12
            ActionType.Null,    // 13                        
            ActionType.Add,     // 14                       
            ActionType.Add,     // 15 
            ActionType.Add,      // 16
            ActionType.Null,    //  17
            ActionType.Add      // 18
            };

        static CharType Type (char c) {
            if (c == ' ' | c == '\t') { return CharType.WhiteSpace; }
            if (c >= '0' & c <= '9') { return CharType.Digit; }
            if ((c >= 'A' & c <= 'Z')) { return CharType.Upper; }
            if ((c >= 'a' & c <= 'z')) { return CharType.Lower; }
            if (c == '_') { return CharType.Underscore; }
            if (c == '/') { return CharType.Slash; }
            if (c == '\\') { return CharType.BackSlash; }
            if (c == '\"') { return CharType.DoubleQuote; }
            if (c == '@') { return CharType.At; }
            if (c == '{') { return CharType.Left; }
            if (c == '}') { return CharType.Right; }
            if (c == '.') { return CharType.Period; }
            if (c == ',') { return CharType.Comma; }
            if (c == '|') { return CharType.Line; }
            if (c == '\n') { return CharType.CR; }
            return CharType.Other;
            }

        /// <summary>Position in the file.</summary>
        public Position Position;

        /// <summary>
        /// Create FSR from file.
        /// </summary>
        /// <param name="filename">The file to read.</param>
        public Lexer(string filename) {
            Position = new Position(filename);
            }


        static int TabSize = 4;

        /// <summary>
        /// Process the input to create a parse tree.
        /// </summary>
        /// <param name="Input">Input file.</param>
        /// <param name="Parse">Parse tree.</param>
        public void Process(Stream Input, Parser Parse) {
            using (TextReader Reader = new StreamReader(Input)) {
                Process(Reader, Parse);
                }
            }

        /// <summary>
        /// Process the input to create a parse tree.
        /// </summary>
        /// <param name="Reader">Input reader.</param>
        /// <param name="Parse">Parse tree.</param>
        public void Process(TextReader Reader, Parser Parse) {
            bool indent = true;

            int IndentCount = 0;
            int BraceCount = 0;

            Position.Ln = 0;
            Position.Col = 0;
            Position.Ch = 0;

            string TokenText;

            try {

                Parse.Process(TokenType.BEGIN, Position, "{{");

                for (string line = Reader.ReadLine(); line != null; line = Reader.ReadLine()) {
                    Position.Ln++;
                    //Console.WriteLine("{0:d3} {1}", Position.Ln, line);
                    bool LineStart = true;
                    Position.Col = -1;
                    Position.Ch = 0;
                    int State = 0;
                    TokenText = "";

                    for (int Ch = 0; Ch < line.Length + 1; Ch++) {

                        if (State == 17) {
                            }


                        Position.Ch = Ch;
                        char c = Ch < line.Length ? line[Ch] : '\n';

                        //Position.Col = (c == '\t') ? Position.Col + 1 : ((Position.Col + TabSize)  % TabSize) * TabSize ;
                        //Console.WriteLine("  @ {0}", Position.Col );

                        if (c == '\t') {
                            Position.Col = (((Position.Col + TabSize + 1) / TabSize) * TabSize) - 1;
                            }
                        else {
                            Position.Col++;
                            }

                        //Console.WriteLine("  {0} [{1}] - {2}  @ {3}", Ch, c, State,  Position.Col );

                        if (indent & LineStart) {
                            if ((c == ' ') | (c == '\t') | (c == '\n') | (c == '\r')) {
                                }
                            else {
                                if (Position.Col == IndentCount) {
                                    // Do nothing
                                    }
                                else if ((Position.Col < IndentCount) & ((Position.Col % TabSize) == 0)) {
                                    while (IndentCount > Position.Col) {
                                        IndentCount -= TabSize;
                                        Parse.Process(TokenType.END, Position, "}");
                                        }
                                    }
                                // Should have a check here to see if we are in the middle of 
                                // a block in which case we ignore additional indents completely
                                else if (Position.Col == IndentCount + TabSize) {
                                    Parse.Process(TokenType.BEGIN, Position, "{");
                                    IndentCount = Position.Col;
                                    }
                                else if (Position.Col > IndentCount) {
                                    throw new Exception("Parse Error Indent Too Big");
                                    }
                                else {
                                    throw new Exception("Parse Error Unrecognized Indent");
                                    }

                                Ch--;
                                LineStart = false;
                                }
                            }
                        else {
                            int CharType = (int)Type(c);
                            int NextState = StateTable[State, CharType];

                            if (NextState < 0) {
                                TokenType Token = TokenTable[State];

                                if (Token == TokenType.INVALID) {
                                    throw new Exception("Invalid Token");
                                    }
                                else if (Token != TokenType.NULL) {

                                    // This is the point where the indent handling should actually go.

                                    Parse.Process(Token, Position, TokenText);
                                    }

                                if (State == 3) {
                                    indent = false;
                                    BraceCount++;
                                    }
                                else if (State == 4) {
                                    if (indent) {
                                        throw new Exception("Unmatched Closing Brace");
                                        }
                                    BraceCount--;
                                    if (BraceCount <= 0) {
                                        indent = true;
                                        }
                                    }

                                TokenText = "";
                                State = 0;
                                if (Ch < line.Length - 1) {
                                    Ch--;   // Unget character if we are not EOL
                                    }
                                }
                            else {
                                switch (ActionTable[NextState]) {
                                    case ActionType.Add: {
                                            TokenText = TokenText + c;
                                            break;
                                            }
                                    case ActionType.Escape: {
                                            if (State == 8) {
                                                TokenText = TokenText + c;
                                                }
                                            else if (State == 10) {
                                                switch (c) {
                                                    case 'n':
                                                        TokenText = TokenText + '\n';
                                                        break;
                                                    case 'r':
                                                        TokenText = TokenText + '\r';
                                                        break;
                                                    case 'v':
                                                        TokenText = TokenText + '\v';
                                                        break;
                                                    case 't':
                                                        TokenText = TokenText + '\t';
                                                        break;
                                                    case '\"':
                                                        TokenText = TokenText + '\"';
                                                        break;
                                                    case '\'':
                                                        TokenText = TokenText + '\'';
                                                        break;
                                                    case '\\':
                                                        TokenText = TokenText + '\\';
                                                        break;
                                                    case '0':
                                                        TokenText = TokenText + '\0';
                                                        break;
                                                    default:
                                                        throw new Exception("Unknown Character Escape Sequence");
                                                    }
                                                }
                                            break;
                                            }
                                    }

                                State = NextState;
                                }
                            }
                        }
                    }
                while (IndentCount > 0) {
                    IndentCount -= TabSize;
                    Parse.Process(TokenType.END, Position, null);
                    }
                Parse.Process(TokenType.END, Position, "}}");

                }
            catch (System.Exception Exception) {
                throw new GoedelParseException (Exception.Message, Position);
                }

            }
        }
    }
