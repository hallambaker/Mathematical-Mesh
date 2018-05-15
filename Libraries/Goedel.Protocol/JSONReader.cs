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
using System.Diagnostics;
using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// JSON Reader base class. Note that this implementation uses a hand coded
    /// FSR rather than one generated with FSRGen. This should be fixed.
    /// </summary>
    public partial class JSONReader : Reader {

        /// <summary>
        /// Return a JSON reader for the specified string.
        /// </summary>
        /// <param name="Input">The string to be read</param>
        /// <returns>The reader instance.</returns>
        public static JSONReader OfData(string Input) {
            return new JSONBufferedReader(Input);
            }

        /// <summary>
        /// Return a JSON reader for the specified data.
        /// </summary>
        /// <param name="Input">The data to be read</param>
        /// <returns>The reader instance.</returns>
        public static JSONReader OfData(byte[] Input) {
            return new JSONBufferedReader(Input);
            }

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
                { 15,  1,  2,  3,  4, -1,  7,  9, -1, 25,  6,  8, -1,  5,  5,  5,  5,  5,  0, 27, -1}, //  0 Start - eat WS
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 1 StartObject
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  2 EndObject
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  3 StartArray
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  4 EndArray

                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  5,  5,  5,  5,  5, -1, -1, -1}, //  5 Litteral
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  6 Comma
             
                // Number
                { -1, -1, -1, -1, -1, -1, 26, 26, 10, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  7  "0"
                { -1, -1, -1, -1, -1, -1,  7,  9, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, //  8  "-"           
                { -1, -1, -1, -1, -1, -1,  9,  9, 10, -1, -1, -1, -1, 12, -1, -1, -1, -1, -1, -1, -1}, //  9  "[-]999"           
                { -1, -1, -1, -1, -1, -1, 11, 11, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 10  "[-]999."         
                { -1, -1, -1, -1, -1, -1, 11, 11, -1, -1, -1, -1, -1, 12, -1, -1, -1, -1, -1, -1, -1}, // 11  "[-]999.99"         
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, 13, 13, -1, -1, -1, -1, -1, -1, -1, -1}, // 12  "[-]999[.99]E"           
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 13  "[-]999[.99]E+"
                { -1, -1, -1, -1, -1, -1, 14, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 14  "[-]999[.99]E[+]99"
            
                // String
                { 24, 16, 16, 16, 16, 17, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, -1, 16}, // 15   "         
                { 24, 16, 16, 16, 16, 17, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, -1, 16}, // 16   "a[aaaa]
                { 23, -1, -1, -1, -1, 23, -1, -1, -1, -1, -1, -1, -1, -1, 18, 23, -1, -1, -1, -1, -1}, // 17   "a[aaaa]\
                { -1, -1, -1, -1, -1, -1, 19, 19, -1, -1, -1, -1, -1, 19, -1, 19, 19, -1, -1, -1, -1}, // 18   "a[aaaa]\u
                { -1, -1, -1, -1, -1, -1, 19, 20, -1, -1, -1, -1, -1, 20, -1, 20, 20, -1, -1, -1, -1}, // 19   "a[aaaa]\u0
                { -1, -1, -1, -1, -1, -1, 21, 21, -1, -1, -1, -1, -1, 21, -1, 21, 21, -1, -1, -1, -1}, // 20   "a[aaaa]\u01
                { -1, -1, -1, -1, -1, -1, 22, 22, -1, -1, -1, -1, -1, 22, -1, 22, 22, -1, -1, -1, -1}, // 21   "a[aaaa]\u0123
                { 24, 16, 16, 16, 16, 17, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, -1, 16}, // 22   "a[aaa]\\
                { 24, 16, 16, 16, 16, 17, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, -1, 16}, // 23   "a[aaa]\\
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}, // 24   "[aaaa][\\][aaaa]"

                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},  // 25  Colon
                
                { -1, -1, -1, -1, -1, -1, -1, 26, 26, -1, -1, 26, 26, 26, -1, -1, -1, -1, -1, -1, -1},  // 26    Invalid number
                { -1, -1, -1, -1, -1, -1, -1, 26, 26, -1, -1, 26, 26, 26, -1, -1, -1, -1, -1, -1, -1}  // 27  EOR
            };

        /// <summary>Actions to perform on transitions</summary>
        protected enum Action {
            /// <summary></summary>
            Ignore,
            /// <summary></summary>
            Add,
            /// <summary></summary>
            AddHex,
            /// <summary></summary>
            Escape,
            /// <summary></summary>
            LastHex,
            /// <summary></summary>
            Complete,
            /// <summary></summary>
            AddComplete
            }

        /// <summary>Actions to perform on transitions</summary>
        protected Action [] Actions = {
            Action.Ignore,          //  0
            Action.AddComplete,     //  1
            Action.AddComplete,     //  2
            Action.AddComplete,     //  3
            Action.AddComplete,     //  4
            Action.AddComplete,     //  5
            Action.AddComplete,     //  6
            Action.AddComplete,     //  7
            Action.Add,             //  8
            Action.AddComplete,     //  9
            Action.Add,             // 10 
            Action.AddComplete,     // 11
            Action.Add,             // 12
            Action.Add,             // 13
            Action.AddComplete,     // 14
            Action.Ignore,          // 15
            Action.Add,             // 16
            Action.Ignore,          // 17
            Action.Ignore,          // 18
            Action.AddHex,          // 19
            Action.AddHex,          // 20
            Action.AddHex,          // 21
            Action.LastHex,         // 22
            Action.Escape,          // 23
            Action.Complete,        // 24
            Action.AddComplete,     // 25
            Action.AddComplete,     // 26
            Action.Ignore           // 27
            };

        /// <summary>Tokens to return.</summary>
        public enum Token {
            /// <summary></summary>
            Invalid,
            /// <summary></summary>
            StartObject,    // Tested
            /// <summary></summary>
            EndObject,      // Tested
            /// <summary></summary>
            StartArray,     // Tested
            /// <summary></summary>
            EndArray,       // Tested
            /// <summary></summary>
            Colon,          // Tested
            /// <summary></summary>
            Comma,          // Tested
            /// <summary></summary>
            String,         // Tested
            /// <summary></summary>
            Number,         // Tested
            /// <summary></summary>
            Litteral,       // Should never be returned
            /// <summary></summary>
            True,           // Tested
            /// <summary></summary>
            False,          // Tested
            /// <summary></summary>
            Null,           // Tested
            /// <summary></summary>
            EndRecord,      //
            /// <summary></summary>
            Binary,         // For internal use
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
            Token.String,               // 16 
            Token.String,               // 17 
            Token.String,               // 18 
            Token.String,               // 19 
            Token.String,               // 20
            Token.String,               // 21
            Token.String,               // 22
            Token.String,               // 23
            Token.String,               // 23
            Token.Colon,                // 24
            Token.Invalid,               // 25
            Token.EndRecord               // 26
                                  };

        /// <summary>Convert hex character to hex value</summary>
        /// <param name="c">The hex character</param>
        /// <returns>Integer value.</returns>
        protected int HexCharToInt(char c) {
            if ((c >= '0') & (c <= '9')) {
                return ((int)c - (int)'0');
                }
            if ((c >= 'a') & (c <= 'f')) {
                return (10 + (int)c - (int)'a');
                }
            if ((c >= 'A') & (c <= 'F')) {
                return (10 + (int)c - (int)'A');
                }
            return -1;
            }

        /// <summary>If true there is a character in the lookahead buffer.</summary>
        protected bool Lookahead = false;

        /// <summary>The current token string</summary>
        protected string TokenString = null;

        /// <summary>The last token type read</summary>
        protected Token  TokenType = Token.Invalid;

        /// <summary>If true, have reached the end of the current record.</summary>
        public bool EOR = false;

        /// <summary>If true, emit trace value for debugging.</summary>
        public static bool Trace = false;

        /// <summary>Get the next token.</summary>
        public virtual void GetToken () {
            EOR = false;
            if (!Lookahead) {
                TokenString = Lexer (out TokenType);
                }
            Lookahead = false;
            if (Trace) {
                Debug.WriteLine("Got {0} \"{1}\"", TokenType, TokenString);
                }
            }

        /// <summary>Unget a token.</summary>
        public virtual void UnGetToken() {
            Lookahead = true;
            //Trace.WriteLine("Unget");
            }

        /// <summary>Get the next lexical token.</summary>
        string Lexer (out Token Token) {
            string result = "";
            bool Going = true;
            bool Complete = false;
            int Hex = 0;
            int State = 0;
            Token = Token.Invalid;


            //string In = "";
            while (Going & !EOF) {
                char c = LookNext ();
                //In = In + c;
 
                int Type = (int) GetCharType (c);

                if (EOF) {
                    if (State == 0) {
                        Token = Token.Empty;
                        return null;
                        }
                    }
                State = States [State,Type];
                if (State < 0) {
                    if (!Complete) {
                        Token = Token.Invalid;
                        return null;
                        }
                    else if (Token == Token.Litteral) {
                        if (result == "true") {
                            Token = Token.True;
                            }
                        else if (result == "false") {
                            Token = Token.False;
                            }
                        else if (result == "null") {
                            Token = Token.Null;
                            }
                        else {
                            Token = Token.Invalid;
                            }
                        }
                    return result;
                    }
                Token = Tokens [State];

                GetNext(); // Consume character
                switch (Actions[State]) {
                    case Action.Ignore: {
                        break;
                        }
                    case Action.Add: {
                        result = result + c;
                        break;
                        }
                    case Action.AddHex: {
                        Hex = 16*Hex + HexCharToInt (c);
                        break;
                        }
                    case Action.LastHex: {
                        Hex = 16*Hex + HexCharToInt (c);
                        result = result + (char) Hex;
                        break;
                        }
                    case Action.Escape: {
                        char ec;
                        switch (c) {
                            case '\"' : { ec = '\"'; break ; }
                            case '\\' : { ec = '\\'; break ; }
                            case '/' : { ec = '/'; break ; }
                            case 'f' : { ec = '\f'; break ; }
                            case 'b' : { ec = '\b'; break ; }
                            case 'n' : { ec = '\n'; break ; }
                            case 'r' : { ec = '\r'; break ; }
                            case 't' : { ec = '\t'; break ; }
                            default : {ec = (char) 0; break ; }
                            }
                        result = result + ec;
                        break;
                        }
                    case Action.Complete: {
                        Complete = true;
                        break;
                        }
                    case Action.AddComplete: {
                        Complete = true;
                        result = result + c;
                        break;
                        }
                    }
                }

            return result;
            }

        /// <summary>
        /// Construct a JSONReader
        /// </summary>
        public JSONReader () {
            }

        /// <summary>
        /// Construct a JSONReader for the specified input stream
        /// </summary>
        /// <param name="InputIn">The source.</param>
        public JSONReader(TextReader InputIn) {
            SetReader (InputIn);
            }

        /// <summary>
        /// Construct a JSONReader for the specified input string.
        /// </summary>
        /// <param name="BufferIn">The source.</param>
        public JSONReader (string BufferIn) {
            SetReader (BufferIn);
            }

        /// <summary>
        /// Construct a JSONReader for the specified data buffer.
        /// </summary>
        /// <param name="DataIn">The source.</param>
        public JSONReader (byte[] DataIn) : this(System.Text.Encoding.UTF8.GetString(DataIn)) {
            }


        /// <summary>
        /// Attempt to read an object start from input.
        /// </summary>
        /// <returns>True if there is an object start item, otherwise 
        /// false</returns> 
        public override bool StartObject() {
            GetToken ();
            if ((TokenType == Token.EndRecord) | EOF ){
                EOR = true;
                return false;
                }

            if (TokenType != Token.StartObject) {
                throw new Exception ("Expected {");
                }

            GetToken ();
            if (TokenType == Token.EndObject) {
                return false;
                }
            UnGetToken ();
            return true;
            }

        /// <summary>
        /// Attempt to read an object end from input.
        /// </summary>
        public override void EndObject() {
            GetToken ();
            if (TokenType != Token.EndObject) {
                throw new Exception ("Expected }");
                }
            }

        /// <summary>
        /// Attempt to read an object from input.
        /// </summary>
        /// <returns>True if there is a next object.</returns>
        public override bool NextObject() {
            GetToken ();
            if (TokenType == Token.Comma) {
                return true; // another tag to come
                }
            else if (TokenType == Token.EndObject) {
                return false; // end of object reached
                }
            else {
                throw new Exception("Expected , or }");
                }
            }

        /// <summary>
        /// Attempt to read a token from input.
        /// </summary>
        /// <returns>The token read.</returns>
        public override string ReadToken() {
            string result = null;
            GetToken ();
            if  (TokenType == Token.EndObject) {
                return null;
                }
            else if (TokenType != Token.String) {
                throw new Exception ("Expected \"Tag\"");
                }
            result = TokenString;
            GetToken ();
            if (TokenType != Token.Colon) {
                throw new Exception ("Expected :");
                }
            return result;
            }

        /// <summary>
        /// Attempt to read Integer 32 from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override int ReadInteger32() {
            GetToken ();
            if (TokenType != Token.Number) {
                throw new Exception ("Expected Number");
                }

            return Convert.ToInt32 (TokenString);
            }

        /// <summary>
        /// Attempt to read Integer 64 from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override long ReadInteger64() {
            GetToken ();
            if (TokenType != Token.Number) {
                throw new Exception ("Expected Number");
                }

            return Convert.ToInt64 (TokenString);
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
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected BASE64 encoded binary");
                }
            return BaseConvert.FromBase64 (TokenString);
            }

        /// <summary>
        /// Attempt to read string from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override string ReadString() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected \"String\"");
                }
            return TokenString;
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
            return TokenString.FromRFC3339();
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
            GetToken ();
            if (TokenType == Token.EndArray) {
                return false;
                }
            UnGetToken ();
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
        /// Read a tagged object from this stream.
        /// </summary>
        /// <param name="TagDictionary">Dictionary mapping tags to factory methods</param>
        /// <returns>The deserialized object.</returns>
        public JSONObject ReadTaggedObject (
                    Dictionary<string, JSONFactoryDelegate> TagDictionary) {
            JSONObject Out = null;
            StartObject();
            if (EOR) {
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
   