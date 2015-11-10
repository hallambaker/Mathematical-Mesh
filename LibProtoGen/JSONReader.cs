using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Debug;

namespace Goedel.Protocol {

    public partial class JSONReader : Reader {

        protected enum CharType {

            Quote=0,
            LeftBrace=1, 
            RightBrace=2,
            LeftSquare=3, 
            RightSquare=4,
            Solidus=5,
            Zero=6,
            Digit=7,
            Period=8,
            Colon=9,
            Comma=10,
            Minus=11, 
            Plus=12,
            Ee=13,
            u=14,
            Escaped=15,
            Hex=16,
            Lower=17,
            WS=18,
            EOR=19,
            Other=20,
            }

        protected CharType GetCharType(char c) {
            if (c == '\"') return CharType.Quote;
            if (c == '{') return CharType.LeftBrace;
            if (c == '}') return CharType.RightBrace;
            if (c == '[') return CharType.LeftSquare;
            if (c == ']') return CharType.RightSquare;
            if (c == '0') return CharType.Zero;
            if ((c >= '0') & (c <= '9')) return CharType.Digit;
            if (c == '.') return CharType.Period;
            if (c == ':') return CharType.Colon;
            if (c == ',') return CharType.Comma;
            if (c == '-') return CharType.Minus;
            if (c == '\\') return CharType.Solidus;
            if (c == '+') return CharType.Plus;            
            if ((c == 'e') | (c == 'E')) return CharType.Ee;
            if (c == 'u') return CharType.u;
            if  ((c == '/') | (c == 't') | (c == 'r') | (c == 'n') | (c == 'f') | (c == 'b'))  return CharType.Escaped;
            if ((c >= 'a') & (c <= 'f')) return CharType.Hex;
            if ((c >= 'A') & (c <= 'F')) return CharType.Hex;
            if ((c >= 'a') & (c <= 'z')) return CharType.Lower;  
            if ((c == ' ') | (c == '\t') | (c == '\r') | (c == '\n') | (c == '\f') | (c == '\b')) return CharType.WS;
            if (c == 0x1e) return CharType.EOR;
            return CharType.Other;
            }






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

        protected enum Action {
            Ignore,
            Add,
            AddHex,
            Escape,
            LastHex,
            Complete,
            AddComplete
            }

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

        public enum Token {
            Invalid,
            StartObject,    // Tested
            EndObject,      // Tested
            StartArray,     // Tested
            EndArray,       // Tested
            Colon,          // Tested
            Comma,          // Tested
            String,         // Tested
            Number,         // Tested
            Litteral,       // Should never be returned
            True,           // Tested
            False,          // Tested
            Null,           // Tested
            EndRecord,      //
            Binary,         // For internal use
            Empty
            }


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

        protected int HexCharToInt(char c) {
            if ((c>='0') & (c<='9')) return ((int)c - (int)'0');
            if ((c>='a') & (c<='f')) return (10 + (int)c - (int)'a');
            if ((c>='A') & (c<='F')) return (10 + (int)c - (int)'A');   
            return -1;
            }

        protected bool Lookahead = false;
        protected string TokenString = null;
        protected Token  TokenType = Token.Invalid;

        public bool EOR = false;

        public virtual void GetToken () {
            EOR = false;
            if (!Lookahead) {
                TokenString = Lexer (out TokenType);
                }
            Lookahead = false;
            //Trace.WriteLine("Got {0} \"{1}\"", TokenType, TokenString);
            }

        public virtual void UnGetToken() {
            Lookahead = true;
            //Trace.WriteLine("Unget");
            }


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

        public JSONReader () {
            }

        public JSONReader(FileStream InputIn) {
            SetReader(InputIn);
            }
        public JSONReader(TextReader InputIn) {
            SetReader (InputIn);
            }
        public JSONReader (string BufferIn) {
            SetReader (BufferIn);
            }

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
        public override void EndObject() {
            GetToken ();
            if (TokenType != Token.EndObject) {
                throw new Exception ("Expected }");
                }
            }
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

        public override int ReadInteger32() {
            GetToken ();
            if (TokenType != Token.Number) {
                throw new Exception ("Expected Number");
                }

            return Convert.ToInt32 (TokenString);
            }

        public override long ReadInteger64() {
            GetToken ();
            if (TokenType != Token.Number) {
                throw new Exception ("Expected Number");
                }

            return Convert.ToInt64 (TokenString);
            }

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

        public override byte[] ReadBinary() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected BASE64 encoded binary");
                }
            return BaseConvert.FromBase64urlString (TokenString);
            }

        public override string ReadString() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected \"String\"");
                }
            return TokenString;
            }

       public override DateTime ReadDateTime() {
            GetToken ();
            if (TokenType != Token.String) {
                throw new Exception ("Expected \"DateTime\"");
                }
            return new DateTime ();
            }

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
        }


    }
   