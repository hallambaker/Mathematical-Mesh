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
using System.IO;
using Goedel.Debug;

namespace Goedel.Protocol {


    public partial class JSONReader {

        public static JSONReader OfData (string Input) {
            return new JSONBufferedReader(Input);
            }

        public static JSONReader OfData(byte[] Input) {
            return new JSONBufferedReader(Input);
            }

        public static JSONReader OfFile (string FileName) {
            var FileStream = new FileStream(FileName, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite);
            return new JSONBufferedReader(FileStream);
            }



        

        }


    public class JSONBufferedReader : JSONReader {
        BufferedCharacterStream BufferedInput;

        public JSONBufferedReader(FileStream InputIn) {
            BufferedInput = new FileCharacterTextStream(InputIn);
            Input = BufferedInput;
            }

        public JSONBufferedReader(String InputIn) {
            BufferedInput = new StringCharacterStream(InputIn);
            Input = BufferedInput;
            }

        public JSONBufferedReader(byte[] InputIn) {
            BufferedInput = new DataCharacterTextStream(InputIn);
            Input = BufferedInput;
            }

        /// <summary>
        /// Fast string read. Counts the number of bytes needed to determine the length, allocates 
        /// </summary>
        /// <returns></returns>
        public override string ReadString() {
            GetStringToken();
            if (TokenType != Token.String) {
                throw new Exception("Expected \"String\"");
                }
            return TokenString;
            }


        void GetStringToken() {
            EOR = false;
            if (Lookahead) {
                Lookahead = false;
                return;
                }

            // First pass, get the length
            BufferedInput.Mark();
            var Length = CountString(out TokenType);

            // Second pass, read the bytes
            BufferedInput.Restore();
            TokenString = ReadString(Length, out TokenType);

            }

        long CountString (out Token Token) {

            bool Going = true;
            int State = 0;
            Token = Token.Invalid;

            long Length = 0;

            while (Going & !EOF) {
                char c = LookNext();



                int Type = (int)GetCharType(c);

                if (EOF) {
                    if (State == 0) {
                        Token = Token.Empty;
                        return Length;
                        }
                    }
                State = States[State, Type];
                if (State < 0) {
                    return Length;
                    }
                Token = Tokens[State];

                GetNext(); // Consume character
                switch (Actions[State]) {
                    case Action.Add:
                    case Action.LastHex:
                    case Action.Escape:
                    case Action.AddComplete: {
                        Length++;
                        break;
                        }
                    }
                }

            return Length;
            }

        string ReadString(long Length, out Token Token) {

            bool Going = true;
            int State = 0;
            Token = Token.Invalid;

            long I = 0;
            char[] Buffer = new char[Length];
            int Hex = 0;

            while (Going & !EOF) {
                char c = LookNext();


                int Type = (int)GetCharType(c);

                if (EOF) {
                    if (State == 0) {
                        Token = Token.Empty;
                        return new string (Buffer) ;
                        }
                    }
                State = States[State, Type];
                if (State < 0) {
                    return new string(Buffer);
                    }
                Token = Tokens[State];

                GetNext(); // Consume character
                switch (Actions[State]) {
                    case Action.Add:
                    case Action.AddComplete:
                            {
                            Buffer [I++] = c;
                            break;
                            }
                    case Action.Escape:
                            {
                            char ec;
                            switch (c) {
                                case '\"': { ec = '\"'; break; }
                                case '\\': { ec = '\\'; break; }
                                case '/': { ec = '/'; break; }
                                case 'f': { ec = '\f'; break; }
                                case 'b': { ec = '\b'; break; }
                                case 'n': { ec = '\n'; break; }
                                case 'r': { ec = '\r'; break; }
                                case 't': { ec = '\t'; break; }
                                default: { ec = (char)0; break; }
                                }
                            Buffer[I++] = ec;
                            break;
                            }
                    case Action.AddHex:
                            {
                            Hex = 16 * Hex + HexCharToInt(c);
                            break;
                            }
                    case Action.LastHex:
                            {
                            Hex = 16 * Hex + HexCharToInt(c);
                            Buffer[I++] = (char)Hex;
                            break;
                            }
                    }
                }

            return new string(Buffer);
            }


        byte[] TokenBinary;
        public override byte[] ReadBinary() {
            EOR = false;

            if (Lookahead) {
                if (TokenType != Token.Binary) {
                    throw new Exception("Expected BASE64 encoded binary");
                    }

                Lookahead = false;
                return TokenBinary;
                }


            // First pass, get the length
            BufferedInput.Mark();
            var Length = CountBinary(out TokenType);

            if (TokenType != Token.String) {
                throw new Exception("Expected BASE64 encoded binary");
                }

            // Second pass, read the bytes
            BufferedInput.Restore();
            TokenBinary = ReadBinary(Length, out TokenType);


            //BufferedInput.Restore();
            //GetToken();
            //var TokenBinary2 = BaseConvert.FromBase64urlString(TokenString);

            //if (TokenBinary.Length != TokenBinary2.Length) {
            //    Console.WriteLine("****Error");
            //    }
            //for (var i = 0; i < TokenBinary.Length; i++) {
            //    if (TokenBinary[i] != TokenBinary2[i]) {
            //        Console.WriteLine("****Error");
            //        }
            //    }


            return TokenBinary;
            }



        long CountBinary(out Token Token) {

            bool Going = true;
            int State = 0;
            Token = Token.Invalid;

            long Length = 0;
            int Count = 0;

            

            while (Going & !EOF) {
                char c = LookNext();
                //Trace.WriteLine("Len {1} / Char {0}", c, Length);
                int Type = (int)GetCharType(c);

                if (EOF) {
                    if (State == 0) {
                        Token = Token.Empty;
                        return Length;
                        }
                    }
                State = States[State, Type];
                if (State < 0) {
                    return Length;
                    }
                Token = Tokens[State];

                GetNext(); // Consume character
                switch (Actions[State]) {
                    case Action.Add:
                    case Action.AddComplete: {
                            if (BASE64URLValue [c] < 64) {
                                if ((Count++ % 4) > 0) {
                                    Length++;
                                    }
                                }

                            break;
                            }
                    }
                }

            return Length;
            }


        byte[] ReadBinary(long Length, out Token Token) {

            bool Going = true;
            int State = 0;
            Token = Token.Invalid;

            int Count = 0;
            int Last = 0;


            var Result = new byte[Length];
            long i = 0;

            while (Going & !EOF) {
                char c = LookNext();
                //Trace.WriteLine("## Len {1} / Char {0}", c, i);

                int Type = (int)GetCharType(c);

                if (EOF) {
                    if (State == 0) {
                        Token = Token.Empty;
                        return Result;
                        }
                    }
                State = States[State, Type];
                if (State < 0) {
                    return Result;
                    }
                Token = Tokens[State];

                GetNext(); // Consume character
                switch (Actions[State]) {
                    case Action.Add:
                    case Action.AddComplete:
                            {
                            var v = BASE64URLValue[c];
                            if (v < 64) {
                                if (Count == 0) {
                                    Last = v; // 6 bits over
                                    Count = 1;
                                    }
                                else if (Count == 1) {
                                    Result[i++] = (byte) ((Last << 2) | (v >> 4));
                                    Last = v & 0xf; // 4 bits over
                                    Count = 2;
                                    }
                                else if (Count == 2) {
                                    Result[i++] = (byte)((Last << 4) | (v >> 2));
                                    Last = v & 0x3; // 2 bits over
                                    Count = 3;
                                    }
                                else if (Count == 3) {
                                    Result[i++] = (byte)((Last << 6) | v);
                                    Last = 0; // 0 bits over
                                    Count = 0;
                                    }
                                }
                            break;
                            }
                    }
                }

            return Result;
            }


        //
        // For reverse conversion permit either Base64 (+/) 
        // or Base64Url (-_) encodings of 62 and 63
        // 
        private static byte[] BASE64URLValue = new byte[] {
                    255, 255, 255, 255,  255, 255, 255, 255,   //  0-7
                    255, 255, 255, 255,  255, 255, 255, 255,   //  8-15
                    255, 255, 255, 255,  255, 255, 255, 255,   //  16-23
                    255, 255, 255, 255,  255, 255, 255, 255,   //  24-31
                    255, 255, 255, 255,  255, 255, 255, 255,   //  32-39
                    255, 255, 255,  62,  255,  62, 255,  63,   //  40
                     52,  53,  54,  55,   56,  57,  58,  59,   //  48
                     60,  61, 255, 255,  255, 255, 255, 255,   //  56
                    255,   0,   1,   2,    3,   4,   5,   6,   //  64
                      7,   8,   9,  10,   11,  12,  13,  14,   //  72
                     15,  16,  17,  18,   19,  20,  21,  22,   //  80-87
                     23,  24,  25, 255,  255, 255, 255,  63,   //  88
                    255,  26,  27,  28,   29,  30,  31,  32,   //  96
                     33,  34,  35,  36,   37,  38,  39,  40,   // 104
                     41,  42,  43,  44,   45,  46,  47,  48,   // 112
                     49,  50,  51, 255,  255, 255, 255, 255,   // 120-127
        };


        }
    }
