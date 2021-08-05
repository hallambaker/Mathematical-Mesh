#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;
using System.Collections.Generic;
using System.Net;



namespace Goedel.Discovery {
    class TextBuffer {
        public string Buffer;
        int pointer;
        public bool EOF { get; private set; }

        public TextBuffer(string Buffer) {
            this.Buffer = Buffer;
            pointer = 0;
            EOF = false;
            }

        public bool Get(out char c) {
            if (pointer < Buffer.Length) {
                c = Buffer[pointer++];
                return true;
                }
            c = (char)0;
            EOF = true;
            return false;
            }

        public bool Look(out char c) {
            if (pointer < Buffer.Length) {
                c = Buffer[pointer++];
                return true;
                }
            c = (char)0;
            return false;
            }

        public bool UnGet() {
            if (pointer <= 0) {
                return false;
                }
            pointer--;
            return true;
            }
        }

    /// <summary>DNS Token types</summary>
    public enum TokenType {
        /// <summary>End of file</summary>
        EOF = 0x1,
        /// <summary>End of line</summary>
        EOL = 0x2,
        /// <summary>Directive</summary>
        Directive = 0x4,
        /// <summary>ALabel</summary>
        ALabel = 0x8,
        /// <summary>Domain Label</summary>
        DLabel = 0x10,
        /// <summary>Integer</summary>
        Number = 0x20,
        /// <summary>Left parethesis</summary>
        Left = 0x40,
        /// <summary>Right parethesis</summary>
        Right = 0x80,
        /// <summary>Character @</summary>
        At = 0x100,
        /// <summary>String value</summary>
        String = 0x200,
        /// <summary>Literal value</summary>
        Literal = 0x400,
        /// <summary>Unknown value</summary>
        Unknown = 0x8000000         // Anything else
        }

    /// <summary>Character groups</summary>
    public enum CharType {
        /// <summary>Whitespace</summary>
        White = 1,
        /// <summary>Digit</summary>
        Digit = 2,      //0-9
        /// <summary>a-z</summary>
        Lower = 3,
        /// <summary>A-Z</summary>
        Upper = 4,
        /// <summary>.</summary>
        Dot = 5,
        /// <summary>_</summary>
        Under = 6,
        /// <summary>-</summary>
        Dash = 7,
        /// <summary>"</summary>
        Quote = 8,
        /// <summary>$</summary>
        Dollar = 9,
        /// <summary>;</summary>
        Semi = 10,
        /// <summary>(</summary>
        Left = 11,
        /// <summary>)</summary>
        Right = 12,
        /// <summary>End of line</summary>
        Return = 13,
        /// <summary>@</summary>
        At = 14,
        /// <summary>\</summary>
        Backslash = 15,
        /// <summary>#</summary>
        Hash = 16,
        /// <summary>Other</summary>
        Unknown = 0
        }



    /// <summary>Stub DNS parser class. Not currently implemented. 
    /// Could be the basis for a DNS config file parser.</summary>
    public class Parse {
        TextBuffer TextBuffer;
        bool LastEOL = false;

        /// <summary>Construct from specified string.</summary>
        /// <param name="Buffer">Input data to parse.</param>
        public Parse(string Buffer) => TextBuffer = new TextBuffer(Buffer);
        // codes for Next State
        // -1 End of current production (token is valid)
        // -2 Invalid token

        static int[,] NextState = {
            // ?,  WS,  09,  az,  AZ,   .,   _,   -,   ",   $,   ;,   (,   ),  \n    @,   \,   #
            { -2,   0,   6,   7,   7,  -1,   4,   4,  12,   3,   1,   8,   9,  -1,   2,  10,  -2 }, // 0 "   "
            {  1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,  -1,  -2,  -2,  -2 }, // 1 "  ;blah"
            { -2,  -1,  -2,  -2,  -2,  -2,  -2,  -2,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 2 Unused 
            { -2,  -1,  -2,   3,   3,  -2,  -1,  -2,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 3 "$Blah" 
            { -2,  -2,   5,   5,   5,  14,   4,   4,  -2,  -2,  -1,  -1,  -1,  -2,  -2,  -2,  -2 }, // 4 "___"
            { -2,  -1,   5,   5,   5,  14,   5,   5,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 5 "_az9-3.com"
            { -2,  -1,   6,   5,   5,  14,   5,   5,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 6 "0023"
            { -2,  -1,   5,   7,   7,  14,   5,   5,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 7 "AAAA"
            { -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 8 ( 
            { -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 9 )
            { -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -1,  -2,  -2,  11 }, // 10 / 
            { -2,  -1,  -2,  -2,  -2,  -2,  -2,  -2,  -2,  -2,  -1,  -1,  -1,  -1,  -1,  -2,  -2 }, // 11 /# 

            { 12,  12,  12,  12,  12,  12,  12,  12,  13,  12,  12,  12,  12,  -2,  12,  -2,  12 }, // 12 "ww
            { -2,  -1,  -2,  -2,  -2,  14,  -2,  -2,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 13 "ww"
            { -2,  -1,  15,  15,  15,  -2,  15,  15,  16,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 14 "www".
            { -2,  -1,  15,  15,  15,  -2,  15,  15,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }, // 15
            { 16,  16,  16,  16,  16,  16,  16,  16,  17,  16,  16,  16,  16,  -2,  16,  -2,  12 }, // 16                                
            { -2,  -1,  -2,  -2,  -2,  14,  -2,  -2,  -2,  -2,  -1,  -1,  -1,  -1,  -2,  -2,  -2 }  // 17 "ww"                              
            };


        // 0 Do nothing
        // 1 Add to string

        static int[,] Action = {
            // ?,  WS,  09,  az,  AZ,   .,   _,   -,   ",   $,   ;,   (,   ),  \n    @,   \,   #
            {  0,   0,   1,   1,   1,   1,   1,   1,   0,   1,   0,   0,   0,   0,   1,   0,   1 }, // 0 "   "
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 1 "  ;blah"
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 2 Unused 
            {  0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 3 "$Blah" 
            {  0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 4 "___"
            {  0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 5 "_az9-3.com"
            {  0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 6 "0023"
            {  0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 7 "AAAA"
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 8 ( 
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 9 )
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1 }, // 10 / 
            {  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 11 /# 
            {  1,   1,   1,   1,   1,   1,   1,   1,   0,   1,   1,   1,   1,   0,   1,   0,   1 }, // 12 "ww
            {  0,   0,   0,   0,   0,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 13 "ww"
            {  0,   0,   1,   1,   1,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 14 "www".
            {  0,   0,   1,   1,   1,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0 }, // 15
            {  1,   1,   1,   1,   1,   1,   1,   1,   0,   1,   1,   1,   0,   0,   1,   0,   1 }, // 16                                
            {  0,   0,   0,   0,   0,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0 }  // 17 "ww"                              
            };

        static TokenType[] FinalToken = {
                TokenType.EOL,          // 0
                TokenType.EOL,          // 1
                TokenType.At,           // 2
                TokenType.Directive,    // 3
                TokenType.Unknown,      // 4
                TokenType.DLabel,       // 5
                TokenType.Number,       // 6 
                TokenType.ALabel,       // 7 
                TokenType.Left,         // 8 
                TokenType.Right,        // 9 
                TokenType.Unknown,      // 10
                TokenType.Literal,      // 11
                TokenType.Unknown,      // 12
                TokenType.String,       // 13
                TokenType.DLabel,       // 14
                TokenType.DLabel,       // 15
                TokenType.Unknown,      // 16
                TokenType.DLabel,       // 17
                TokenType.Unknown};


        private static CharType Type(char c) {
            if (c == ' ' | c == '\t' | c == '\r') { return CharType.White; }
            if (c >= '0' & c <= '9') { return CharType.Digit; }
            if (c >= 'A' & c <= 'Z') { return CharType.Lower; }
            if (c >= 'a' & c <= 'z') { return CharType.Upper; }
            if (c == '.') { return CharType.Dot; }
            if (c == '_') { return CharType.Under; }
            if (c == '-') { return CharType.Dash; }
            if (c == '\n') { return CharType.Return; }
            if (c == '"') { return CharType.Quote; }
            if (c == '$') { return CharType.Dollar; }
            if (c == ';') { return CharType.Semi; }
            if (c == '(') { return CharType.Left; }
            if (c == ')') { return CharType.Right; }
            if (c == '\\') { return CharType.Backslash; }
            return CharType.Unknown;
            }

        /// <summary>
        /// Get next input token
        /// </summary>
        /// <param name="TokenType">Type of parse token received.</param>
        /// <returns>The token value as a string.</returns>
        public string Token(TokenType TokenType) {
            string result = Token(out var GotTokenType);


            /* Unmerged change from project 'Goedel.Discovery'
            Before:
                        if ((GotTokenType & TokenType )== GotTokenType) {
            After:
                        if ((GotTokenType & TokenType) == GotTokenType) {
            */
            if ((GotTokenType & TokenType) == GotTokenType) {
                return result;

                /* Unmerged change from project 'Goedel.Discovery'
                Before:
                                }

                            return null;
                After:
                                }

                            return null;
                */
                }

            return null;
            }


        bool BlockMode = false;



        /// <summary>
        /// Get next token after eliminating EOL tokens inside parenthesis blocks ( foo )
        /// and parenthesis block markers
        /// </summary>
        /// <param name="TokenType">The token type</param>
        /// <returns>The token received</returns>

        /* Unmerged change from project 'Goedel.Discovery'
        Before:
                public string Token(out TokenType TokenType) {

                    while (true) {
        After:
                public string Token(out TokenType TokenType) {

                    while (true) {
        */
        public string Token(out TokenType TokenType) {

            while (true) {
                string result = RawToken(out TokenType);
                if (TokenType == TokenType.EOF) { return result; }

                if (TokenType == TokenType.Left) {
                    if (BlockMode) { throw new Exception("Syntax Start Block Mode in Block Mode"); }
                    BlockMode = true;
                    }
                else if (TokenType == TokenType.Right) {
                    if (!BlockMode) { throw new Exception("Syntax End Block Mode not in Block Mode"); }
                    BlockMode = false;
                    }
                else if ((TokenType == TokenType.EOL) & BlockMode) {
                    }
                else {
                    return result;
                    }
                }
            }


        /// <summary>
        /// Get next raw token (including parenthesis tokens)
        /// </summary>
        /// <param name="TokenType">The token type</param>
        /// <returns>The token received</returns>
        public string RawToken(out TokenType TokenType) {
            int state = 0;
            string result = "";

            if (TextBuffer.EOF) {
                if (LastEOL) {
                    TokenType = TokenType.EOF;
                    return null;
                    }
                else {
                    LastEOL = true;
                    TokenType = TokenType.EOL;
                    return "\n";
                    }
                }

            while (TextBuffer.Get(out var c)) {

                CharType CharType = Type(c);
                int next_state = NextState[state, (int)CharType];

                //Console.WriteLine("State {0} char {1}", state, c);

                if (next_state == -1) {
                    TokenType = FinalToken[state];
                    return result;
                    }

                if (next_state < 0) {
                    TokenType = TokenType.Unknown;
                    return null;
                    }
                if (Action[state, (int)CharType] == 1) {
                    result += c;
                    }

                /* Unmerged change from project 'Goedel.Discovery'
                Before:
                                state = next_state;

                                }
                After:
                                state = next_state;

                                }
                */
                state = next_state;

                }

            TokenType = FinalToken[state];
            return result;
            }

        /// <summary>
        /// Get the next record
        /// </summary>
        /// <returns>The record received.</returns>
        public DNSRecord DNSRecord() {
            string Tag = Token(out var TokenType);

            if (TokenType == TokenType.ALabel) {
                return Goedel.Discovery.DNSRecord.Parse(Tag, this);
                }
            else {
                return null;
                }

            }


        /// <summary>Get IPv4Address</summary>
        /// <returns>The value returned</returns>
        public static IPAddress IPv4() => null;

        /// <summary>Get IPv6Address</summary>
        /// <returns>The value returned</returns>
        public static IPAddress IPv6() => null;

        /// <summary>Get Domain name</summary>
        /// <returns>The value returned</returns>
        public Domain Domain() {
            string token = Token(TokenType.ALabel | TokenType.DLabel);
            return new Domain(token);
            }

        /// <summary>Get Mail Address</summary>
        /// <returns>The value returned</returns>
        public static string Mail() => null;

        /// <summary>Get Node ID</summary>
        /// <returns>The value returned</returns>
        public static ulong NodeID() => 0;

        /// <summary>Get Byte</summary>
        /// <returns>The value returned</returns>
        public static byte Byte() => 0;

        /// <summary>Get Int16</summary>
        /// <returns>The value returned</returns>
        public ushort Int16() {
            string result = Token(TokenType.Number);

            return Convert.ToUInt16(result);
            }

        /// <summary>Get Int32</summary>
        /// <returns>The value returned</returns>
        public uint Int32() {
            string result = Token(TokenType.Number);

            return Convert.ToUInt16(result);
            }

        /// <summary>Get Time32</summary>
        /// <returns>The value returned</returns>
        public static uint Time32() => 0;
        // Same as for Time32 (resolution is still seconds, just a longer interval)

        /// <summary>Get Time48</summary>
        /// <returns>The value returned</returns>
        public static ulong Time48() => 0;

        /// <summary>Get String</summary>
        /// <returns>The value returned</returns>
        public static string String() => null;

        /// <summary>Get Optional String</summary>
        /// <returns>The value returned</returns>
        public string OptionalString() => String();

        /// <summary>Get String with otherwise specified length</summary>
        /// <returns>The value returned</returns>
        public string StringX() => String();

        /// <summary>Get multiple strings</summary>
        /// <returns>The value returned</returns>
        public List<string> Strings() {
            List<string> ListString = new List<string>();
            while (true) {
                string token = Token(out var TokenType);
                if (TokenType == TokenType.EOL) {
                    return ListString;
                    }
                if (TokenType != TokenType.String) { throw new Exception("Syntax error expected string or EOL"); }
                ListString.Add(token);
                }
            }

        /// <summary>Get Binary data</summary>
        /// <returns>The value returned</returns>
        public static byte[] Binary() => null;

        /// <summary>Get Binary data with 8 bit length value</summary>
        /// <returns>The value returned</returns>
        public byte[] Binary8() => Binary();

        /// <summary>Get Binary data with 16 bit length value</summary>
        /// <returns>The value returned</returns>
        public byte[] Binary16() => Binary();

        /// <summary>Get Binary data with L production</summary>
        /// <returns>The value returned</returns>
        public static byte[] LBinary() => null;

        /// <summary>Get Hex data</summary>
        /// <returns>The value returned</returns>>
        public static byte[] Hex() => null;

        /// <summary>Get Hex data with 8 bit length value</summary>
        /// <returns>The value returned</returns>
        public byte[] Hex8() => Hex();

        /// <summary>Get Hex data with 8 bit length value</summary>
        /// <returns>The value returned</returns>
        public byte[] Hex16() => Hex();

        }
    }
