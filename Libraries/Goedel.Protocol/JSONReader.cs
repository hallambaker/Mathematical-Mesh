//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Numerics;
using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// Delegate method for creating structured readers
    /// </summary>
    /// <param name="Data"></param>
    /// <returns></returns>
    public delegate JSONReader JSONReaderFactoryDelegate(byte[] Data);

    /// <summary>
    /// JSON Reader base class. Note that this implementation uses a hand coded
    /// FSR rather than one generated with FSRGen. This should be fixed.
    /// </summary>
    public partial class JSONReader : Reader {

        #region // Tokenizer tables

        /// <summary>
        /// Character type used by the FSM.
        /// </summary>
        protected enum CharType {
            /// <summary></summary>
            Quote = 0,
            /// <summary></summary>
            LeftBrace = 1,
            /// <summary></summary>
            RightBrace = 2,
            /// <summary></summary>
            LeftSquare = 3,
            /// <summary></summary>
            RightSquare = 4,
            /// <summary></summary>
            Solidus = 5,
            /// <summary></summary>
            Zero = 6,
            /// <summary></summary>
            Digit = 7,
            /// <summary></summary>
            Period = 8,
            /// <summary></summary>
            Colon = 9,
            /// <summary></summary>
            Comma = 10,
            /// <summary></summary>
            Minus = 11,
            /// <summary></summary>
            Plus = 12,
            /// <summary></summary>
            Ee = 13,
            /// <summary></summary>
            L_u = 14,
            /// <summary></summary>
            Escaped = 15,
            /// <summary></summary>
            Hex = 16,
            /// <summary></summary>
            Lower = 17,
            /// <summary></summary>
            WS = 18,
            /// <summary></summary>
            EOR = 19,
            /// <summary></summary>
            Other = 20,
            }

        /// <summary>
        /// Convert character to character type.
        /// </summary>
        /// <param name="c">Input character</param>
        /// <returns>Character class</returns>
        protected CharType GetCharType(char c) {
            if (c == '\"') { return CharType.Quote; }
            if (c == '{') { return CharType.LeftBrace; }
            if (c == '}') { return CharType.RightBrace; }
            if (c == '[') { return CharType.LeftSquare; }
            if (c == ']') { return CharType.RightSquare; }
            if (c == '0') { return CharType.Zero; }
            if ((c >= '0') & (c <= '9')) { return CharType.Digit; }
            if (c == '.') { return CharType.Period; }
            if (c == ':') { return CharType.Colon; }
            if (c == ',') { return CharType.Comma; }
            if (c == '-') { return CharType.Minus; }
            if (c == '\\') {return CharType.Solidus; }
            if (c == '+') {return CharType.Plus;      }      
            if ((c == 'e') | (c == 'E')) {return CharType.Ee;}
            if (c == 'u') {return CharType.L_u;}
            if  ((c == '/') | (c == 't') | (c == 'r') | (c == 'n') | (c == 'f') | (c == 'b'))  {return CharType.Escaped;}
            if ((c >= 'a') & (c <= 'f')) {return CharType.Hex;}
            if ((c >= 'A') & (c <= 'F')) {return CharType.Hex;}
            if ((c >= 'a') & (c <= 'z')) {return CharType.Lower;  }
            if ((c == ' ') | (c == '\t') | (c == '\r') | (c == '\n') | (c == '\f') | (c == '\b')) {return CharType.WS;}
            if (c == 0x1e) {return CharType.EOR;}
            return CharType.Other;
            }

        /// <summary>State transition table</summary>
        protected int [,] States  = 
            
            {
                // ",  {,  },  [,  ],  \,  0, 19,  .,  :,  ,,  -,  +, Ee,  u,esc,hex, az, WS, EOR, *   
                { 15,  1,  2,  3,  4, -1,  7,  9, -1, 16,  6,  8, -1,  5,  5,  5,  5,  5,  0, 18, -1}, //  0 Start - eat WS
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 1 StartObject
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  2 EndObject
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  3 StartArray
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  4 EndArray

                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  5,  5,  5,  5,  5, -1, -1, -1}, //  5 Litteral
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  6 Comma
             
                // Number
                { -1, -1, -1, -1, -1, -1, 17, 17, 10, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  7  "0"
                { -1, -1, -1, -1, -1, -1,  7,  9, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  8  "-"           
                { -1, -1, -1, -1, -1, -1,  9,  9, 10, -1, -1, -1, -1, 12, -1, -1, -1, -1, -1, -1, -1}, //  9  "[-]999"           
                { -1, -1, -1, -1, -1, -1, 11, 11, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 10  "[-]999."         
                { -1, -1, -1, -1, -1, -1, 11, 11, -1, -1, -1, -1, -1, 12, -1, -1, -1, -1, -1, -1, -1}, // 11  "[-]999.99"         
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, 13, 13, -1, -1, -1, -1, -1, -1, -1, -1}, // 12  "[-]999[.99]E"           
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 13  "[-]999[.99]E+"
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 14  "[-]999[.99]E[+]99"
            
                // String
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 15   "         
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 16   "a[aaaa]
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 17   "a[aaaa]\
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 18   "a[aaaa]\u
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 19   "a[aaaa]\u0
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 20   "a[aaaa]\u01
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 21   "a[aaaa]\u0123
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 22   "a[aaa]\\
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 23   "a[aaa]\\
                //{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 24   "[aaaa][\\][aaaa]"

                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},  // 25=16 Colon
                { -1, -1, -1, -1, -1, -1, -1, 17, 17, -1, -1, 17, 17, 17, -1, -1, -1, -1, -1, -1, -1},  // 26=17    Invalid number
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}   // 27=18  EOR
            };

        /// <summary>Actions to perform on transitions</summary>
        protected enum Action {
            /// <summary></summary>
            Ignore,
            /// <summary></summary>
            Add,
            /// <summary></summary>
            Complete,
            /// <summary></summary>
            AddComplete,
            /// <summary></summary>
            Incomplete
            }

        /// <summary>Actions to perform on transitions</summary>
        protected Action [] Actions = {
            Action.Ignore,          //  0
            Action.Complete,     //  1
            Action.Complete,     //  2
            Action.Complete,     //  3
            Action.Complete,     //  4
            Action.AddComplete,     //  5
            Action.Complete,     //  6
            Action.AddComplete,     //  7
            Action.Add,             //  8
            Action.AddComplete,     //  9
            Action.Add,             // 10 
            Action.AddComplete,     // 11
            Action.Add,             // 12
            Action.Add,             // 13
            Action.AddComplete,     // 14
            Action.Incomplete,        // 15
            //Action.Add,             // 16
            //Action.Ignore,          // 17
            //Action.Ignore,          // 18
            //Action.AddHex,          // 19
            //Action.AddHex,          // 20
            //Action.AddHex,          // 21
            //Action.LastHex,         // 22
            //Action.Escape,          // 23
            //Action.Complete,        // 24
            Action.AddComplete,     // 25=16
            Action.AddComplete,     // 26=17
            Action.Ignore           // 27=18
            };

        /// <summary>Tokens to return.</summary>
        public enum Token {
            /// <summary>The token is invalid</summary>
            Invalid,
            /// <summary>Start object token '{' </summary>
            StartObject,
            /// <summary>End object token '}' </summary>
            EndObject,
            /// <summary>Start array token '{'</summary>
            StartArray,
            /// <summary>End array token '}'</summary>
            EndArray,
            /// <summary>Colon</summary>
            Colon,
            /// <summary>Comma</summary>
            Comma,
            /// <summary>String (UTF8)</summary>
            String,
            /// <summary>String Tag(UTF8)</summary>
            Tag,

            /// <summary>Number</summary>
            Number,

            /// <summary>An Integer Number</summary>
            Integer,
            /// <summary>A Real32 Number</summary>
            Real32,
            /// <summary>A Real64 Number</summary>
            Real64,

            /// <summary>A string litteral, for internal use.</summary>
            Litteral,
            /// <summary>The string litteral true</summary>
            True,
            /// <summary>The string litteral false</summary>
            False, 
            /// <summary>The string litteral null</summary>
            Null,
            /// <summary>End of record</summary>
            EndRecord,
            /// <summary>Binary data</summary>
            Binary,
            /// <summary>JSON-BCD extended tag, for internal use</summary>
            JSONBCD, 
            /// <summary></summary>
            Empty
            }

        /// <summary>Tokens to be returned if the FSR stops in the specified state.</summary>
        protected Token [] Tokens = {
            Token.Empty,                //  0
            Token.StartObject,          //  1
            Token.EndObject,            //  2
            Token.StartArray,           //  3
            Token.EndArray,             //  4                               
            Token.Litteral,             //  5
            Token.Comma,                //  6
            Token.Number,               //  7         
            Token.Number,               //  8
            Token.Number,               //  9
            Token.Invalid,              // 10                                 
            Token.Number,               // 11
            Token.Number,               // 12
            Token.Number,               // 13          
            Token.Number,               // 14             
            Token.String,               // 15 
            //Token.String,               // 16 
            //Token.String,               // 17 
            //Token.String,               // 18 
            //Token.String,               // 19 
            //Token.String,               // 20
            //Token.String,               // 21
            //Token.String,               // 22
            //Token.String,               // 23
            //Token.String,               // 23
            Token.Colon,                // 24
            Token.Invalid,               // 25
            Token.EndRecord               // 26
                                  };

        #endregion

        /// <summary>If true there is a token in the lookahead buffer.</summary>
        protected bool Lookahead = false;

        /// <summary>The current token string value</summary>
        protected virtual string ResultString { get; set; }

        /// <summary>The current token binary value</summary>
        protected virtual byte[] ResultBinary { get; set; }

        /// <summary>Last Real32/single precision floating point value.</summary>
        public float        ResultFloat;

        /// <summary>Last Real64/double precision floating point value.</summary>
        public double       ResultDouble;

        /// <summary>Last integer value.</summary>
        public long         ResultInt64;

        /// <summary>Last big integer value.</summary>
        public BigInteger   ResultBigInteger;


        /// <summary>The last token type read</summary>
        public Token  TokenType = Token.Invalid;

        /// <summary>If true, have reached the end of the current record.</summary>
        public bool EOF => CharacterInput.EOF;

        /// <summary>If true, emit trace value for debugging.</summary>
        public static bool Trace = false;

        /// <summary>
        /// Delegate method for creating structured readers
        /// </summary>
        public static JSONReaderFactoryDelegate JSONReaderFactory => _JSONReaderFactoryByte ;
        static JSONReader _JSONReaderFactoryByte(byte[] Data)=> new JSONReader(Data);


        StringBuilder StringBuilder = new StringBuilder();

        /// <summary>
        /// The underlying character stream.
        /// </summary>
        protected ICharacterStream CharacterInput;

        /// <summary>
        /// Construct a JSONReader from a TextReader stream.
        /// </summary>
        /// <param name="Input">The stream to be read.</param>
        public JSONReader(TextReader Input) => CharacterInput = new CharacterStreamTextReader(Input);

        /// <summary>
        /// Construct a JSONReader from a string.
        /// </summary>
        /// <param name="Input">The string to be read.</param>
        public JSONReader(string Input) => CharacterInput = new CharacterStreamStringReader(Input);

        /// <summary>
        /// Construct a JSONReader from a byte Stream.
        /// </summary>
        /// <param name="Input">The stream to be read.</param>
        public JSONReader(Stream Input) => CharacterInput = (Input.CanSeek) ?
                new CharacterStreamSeekReader(Input) : new CharacterStreamReader(Input);

        /// <summary>
        /// Construct a JSONReader from a byte array.
        /// </summary>
        /// <param name="Input">The data to be read.</param>
        public JSONReader(byte[] Input) => CharacterInput = new CharacterStreamDataReader(Input);

        /// <summary>
        /// If true, the last token returned was a non-terminal, i.e. chunked production.
        /// </summary>
        public bool Terminal { get; protected set; }  = true;


        /// <summary>Get the next token.</summary>
        public virtual void PeekToken() {
            if (EOF) {
                return;
                }
            if (!Lookahead) {
                TokenType = Lexer();
                Lookahead = true;
                }
            if (Trace) {
                Goedel.IO.Debug.WriteLine("Peek {0} \"{1}\"", TokenType, ResultString);
                }
            }

        /// <summary>
        /// If true, there is additional data to be collected.
        /// </summary>
        protected bool Incomplete=false;

        /// <summary>Get the next token.</summary>
        public virtual void GetToken(bool Binary = false) {
            if (EOF) {
                return;
                }
            PeekToken();
            if (Incomplete) {
                if (Binary) {
                    ResultBinary = CharacterInput.GetBinaryBase64();
                    }
                else {
                    ResultString = CharacterInput.GetStringJSON();
                    }
                Incomplete = false;
                }
            Lookahead = false;

            if (Trace) {
                Goedel.IO.Debug.WriteLine("Got  {0} \"{1}\"", TokenType, ResultString);
                }
            }


        /// <summary>Get the next lexical token.
        /// <para>Note that this reader only performs lexical analysis of
        /// the ASCII oriented parts of the JSON syntax, that is
        /// everything other than strings.</para></summary>
        protected virtual Token Lexer() {
            StringBuilder.Clear();

            bool Going = true;
            bool Complete = false;
            int State = 0;
            Token Token = Token.Invalid;
            Incomplete = false;

            //string In = "";
            while (Going & !EOF) {
                char c =(char) CharacterInput.PeekByte();
                //In = In + c;

                if (State == 0 & c > 127) {
                    return Token.JSONBCD;
                    }

                int Type = (int)GetCharType(c);

                if (EOF) {
                    if (State == 0) {
                        return Token.Empty;
                        }
                    }
                State = States[State, Type];
                if (State < 0) {
                    if (!Complete) {
                        return Token.Invalid;
                        }
                    else if (Token == Token.Litteral) {
                        switch (StringBuilder.ToString()) {
                            case "true":
                                return Token.True;
                            case "false":
                                return Token.False;
                            case "null":
                                return Token.Null;
                            }
                        return Token.Invalid;
                        }
                    ResultString = StringBuilder.ToString();
                    return Token;
                    
                    }
                
                Token = Tokens[State];

                CharacterInput.ReadByte(); // Consume character
                switch (Actions[State]) {
                    case Action.Add: {
                        StringBuilder.Append(c);
                        break;
                        }
                    case Action.AddComplete: {
                        Complete = true;
                        StringBuilder.Append(c);
                        break;
                        }
                    case Action.Complete: {
                        Complete = true;
                        break;
                        }
                    case Action.Incomplete: {
                        Complete = true;
                        Incomplete = true;
                        break;
                        }
                    }
                }
            return Token;
            }




        /// <summary>
        /// Attempt to read an object start from input.
        /// </summary>
        /// <returns>True if there is an object start item, otherwise 
        /// false</returns> 
        public override bool StartObject() {
            GetToken ();
            if ((TokenType == Token.EndRecord) | EOF ){
                return false;
                }

            if (TokenType != Token.StartObject) {
                throw new Exception ("Expected {");
                }

            PeekToken ();
            if (TokenType == Token.EndObject) {
                GetToken();
                return false;
                }

            return true;
            }

        /// <summary>
        /// Attempt to read an object end from input.
        /// </summary>
        public override void EndObject() {
            GetToken();
            if (TokenType != Token.EndObject) {
                throw new Exception("Expected }");
                }
            }


        /// <summary>
        /// Attempt to read an object from input.
        /// </summary>
        /// <returns>True if there is a next object.</returns>
        public override bool NextObject() {
            PeekToken();
            switch (TokenType) {
                case Token.Comma: {
                    GetToken();
                    return true; // another tag to come
                    }
                case Token.EndObject: {
                    GetToken();
                    return false; // end of object reached
                    }
                }
            throw new Exception("Expected , or }");
            }

        /// <summary>
        /// Attempt to read a token from input.
        /// </summary>
        /// <returns>The token read.</returns>
        public override string ReadToken() {
            GetToken ();
            switch (TokenType) {
                case Token.EndObject:
                    return null;
                case Token.Tag:
                    return ResultString;
                case Token.String: {
                    var Result = ResultString;
                    GetToken();
                    if (TokenType != Token.Colon) {
                        throw new Exception("Expected :");
                        }
                    return Result;
                    }
                }
            throw new Exception("Expected \"Tag\"");
            }

        /// <summary>
        /// Attempt to read Integer 32 from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override int ReadInteger32() {
            GetToken ();
            switch (TokenType) {
                case Token.Number:
                    return Convert.ToInt32(ResultString);
                case Token.Integer:
                    return (int)ResultInt64;
                }
            throw new Exception("Expected Number");
            }

        /// <summary>
        /// Attempt to read Integer 64 from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override long ReadInteger64() {
            GetToken();
            switch (TokenType) {
                case Token.Number:
                    return Convert.ToInt64(ResultString);
                case Token.Integer:
                    return ResultInt64;
                }
            throw new Exception("Expected Number");
            }

        /// <summary>
        /// Attempt to read boolean from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override bool ReadBoolean() {
            GetToken ();
            if (TokenType == Token.True) {
                return true;
                }
            if (TokenType == Token.False) {
                return false;
                }
            throw new Exception ("Expected true or false");
            }

        /// <summary>
        /// Attempt to read binary data from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override byte[] ReadBinary() {
            GetToken(true);
            switch (TokenType) {
                case Token.String:
                    return ResultBinary;
                case Token.Binary:
                    return ReadBinaryData();
                }
            throw new Exception("Expected BASE64 encoded binary");
            }

        /// <summary>
        /// Attempt to read a binary object in incremental mode.
        /// </summary>
        /// <param name="Chunk">The data read.</param>
        /// <returns>True if there is more data to be read</returns>
        public override bool ReadBinaryIncremental (out byte[] Chunk) {
            Chunk= ReadBinary();
            return false;
            }


        /// <summary>
        /// Read binary data. This method is not supported on the base JSON reader.
        /// </summary>
        /// <returns>The binary data read.</returns>
        public virtual byte[] ReadBinaryData() => throw new NYI();


        /// <summary>
        /// Attempt to read string from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override string ReadString() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected \"String\"");
                }
            return ResultString;
            }

        /// <summary>
        /// Attempt to read date time from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override DateTime ReadDateTime() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected \"DateTime\"");
                }
            return ResultString.FromRFC3339();
            }

        /// <summary>
        /// Attempt to read start of array from input.
        /// </summary>
        /// <returns>True if there is an array start token, otherwise 
        /// false</returns>
        public override bool StartArray() {
            GetToken ();
            if (TokenType != Token.StartArray) {
                throw new Exception ("Expected [");
                }
            PeekToken();
            if (TokenType == Token.EndArray) {
                GetToken();
                return false;
                }
            return true;
            }

        /// <summary>
        /// Return true if there is a following array item.
        /// </summary>
        /// <returns>True if there is a following array item, otherwise 
        /// false</returns>
        public override bool NextArray() {
            GetToken ();
            if (TokenType == Token.Comma) {
                return true; // another tag to come
                }
            else if (TokenType == Token.EndArray) {
                return false; // end of array reached
                }
            else {
                throw new Exception("Expected , or ]");
                }
            }


        /// <summary>
        /// Attempt to read an object end from input.
        /// </summary>
        public override void EndArray() {
            GetToken();
            if (TokenType != Token.EndArray) {
                throw new Exception("Expected ]");
                }
            }

        /// <summary>
        /// Read a tagged object from this stream.
        /// </summary>
        /// <param name="TagDictionary">Dictionary mapping tags to factory methods</param>
        /// <returns>The deserialized object.</returns>
        public JSONObject ReadTaggedObject (
                    Dictionary<string, JSONFactoryDelegate> TagDictionary) {

            Assert.NotNull(TagDictionary, DictionaryInitialization.Throw);

            JSONObject Out = null;
            StartObject();
            if (EOF) {
                return null;
                }

            var Token = ReadToken();

            Assert.True(TagDictionary.TryGetValue(Token, out var Delegate), UnknownTag.Throw);
            Out = Delegate();
            Out.Deserialize(this);
            EndObject();
            return Out;
            }


        }


    }
   