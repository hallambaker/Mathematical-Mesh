using System;
using System.Collections.Generic;
using System.Net;
using System.Text;



namespace Goedel.DNS {
    class TextBuffer {
        public string Buffer;
        int pointer;
        bool _EOF;
        public bool EOF { get { return _EOF; } }

        public TextBuffer(string Buffer) {
            this.Buffer = Buffer;
            pointer = 0;
            _EOF = false;
            }

        public bool Get(out char c) {
            if (pointer < Buffer.Length) {
                c = Buffer[pointer++];
                return true;
                }
            c = (char)0;
            _EOF = true;
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

    public enum TokenType {
        EOF         = 0x1,
        EOL         = 0x2,
        Directive   = 0x4,
        ALabel      = 0x8,
        DLabel      = 0x10,
        Number      = 0x20,
        Left        = 0x40,
        Right       = 0x80,
        At          = 0x100,
        String      = 0x200,
        Literal     = 0x400,
        Unknown     = 0x8000000         // Anything else
        }

    public enum CharType {
        White = 1,
        Digit = 2,      //0-9
        Lower = 3,
        Upper = 4,
        Dot = 5,
        Under = 6,
        Dash = 7,
        Quote = 8,
        Dollar = 9,
        Semi = 10,
        Left = 11,
        Right = 12,
        Return = 13,
        At = 14,
        Backslash = 15,
        Hash = 16,
        Unknown = 0
        }



    public class Parse {
        TextBuffer TextBuffer;
        bool LastEOL = false;

        public Parse(string Buffer) {
            TextBuffer = new TextBuffer (Buffer);
            }
        // codes for Next State
        // -1 End of current production (token is valid)
        // -2 Invalid token

        static int [,] NextState = {
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

        static int [,] Action = {
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

        static TokenType [] FinalToken = {
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


        private static CharType Type (char c) {
            if (c==' ' | c=='\t' | c=='\r') return CharType.White;
            if (c>='0' & c<='9') return CharType.Digit;
            if (c>='A' & c<='Z') return CharType.Lower;
            if (c>='a' & c<='z') return CharType.Upper;
            if (c=='.') return CharType.Dot;
            if (c=='_') return CharType.Under;
            if (c=='-') return CharType.Dash;
            if (c=='\n') return CharType.Return;
            if (c=='"') return CharType.Quote;
            if (c=='$') return CharType.Dollar;
            if (c==';') return CharType.Semi;
            if (c=='(') return CharType.Left;
            if (c==')') return CharType.Right;
            if (c=='\\') return CharType.Backslash;
            return CharType.Unknown;
            }

        public string Token(TokenType TokenType) {
            TokenType GotTokenType;
            string result = Token (out GotTokenType);

            if ((GotTokenType & TokenType )== GotTokenType) {
                return result;
                }
            
            return null;
            }


        bool BlockMode = false;


        // Get next token after eliminating EOL tokens inside parenthesis blocks ( foo )
        // and parenthesis block markers
        public string Token(out TokenType TokenType) {
            
            while (true) {
                string result = RawToken (out TokenType);
                if (TokenType == TokenType.EOF) return result;

                if (TokenType == TokenType.Left) {
                    if (BlockMode) throw new Exception ("Syntax Start Block Mode in Block Mode");
                    BlockMode = true;
                    }
                else if (TokenType == TokenType.Right) {
                    if (!BlockMode) throw new Exception ("Syntax End Block Mode not in Block Mode");
                    BlockMode = false;
                    }
                else if ((TokenType == TokenType.EOL) & BlockMode) {
                    }
                else {
                    return result;
                    }
                }
            }


        // Get next raw token (including parenthesis tokens)
        public string RawToken(out TokenType TokenType) {
            int state = 0;
            char c;
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

            while (TextBuffer.Get(out c)) {

                CharType CharType = Type(c);
                int next_state = NextState[state, (int)CharType];

                Console.WriteLine("State {0} char {1}", state, c);

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
                state = next_state;
                
                }

            TokenType = FinalToken[state];
            return result;
            }

        public DNSRecord DNSRecord() {
            TokenType TokenType;
            
            string Tag = Token (out TokenType);

            if (TokenType == TokenType.ALabel) {
                return Goedel.DNS.DNSRecord.Parse(Tag, this);
                }
            else {
                return null;
                }

            }



        public IPAddress IPv4 () {
            return null;
            }
        public IPAddress IPv6 () {
            return null;
            }
        public Domain Domain ( ) {
            string token = Token (TokenType.ALabel | TokenType.DLabel);
            return new Domain (token);
            }
        public string Mail ( ) {
            return null;
            }
        public ulong NodeID ( ) {
            return 0;
            }
        public byte Byte ( ) {
            return 0;
            }
        public ushort Int16 ( ) {
            string result = Token (TokenType.Number);

            return Convert.ToUInt16 (result);
            }
        public uint Int32 ( ) {            
            string result = Token (TokenType.Number);

            return Convert.ToUInt16 (result);
            }
        public uint Time32 ( ) {return 0;
            }
        // Same as for Time32 (resolution is still seconds, just a longer interval)
        public ulong Time48 ( ) {return 0;
            }

        public string String ( ) {
            return null;
            }
        public string OptionalString ( ) {return null;
            }
        public string StringX ( ) {return null;
            }
        public List<string> Strings() {
            List<string> ListString = new List<string> ();
            while (true) {
                TokenType TokenType;
                string token = Token(out TokenType);
                if (TokenType == TokenType.EOL) {
                    return ListString;
                    }
                if (TokenType != TokenType.String) throw new Exception ("Syntax error expected string or EOL");
                ListString.Add (token);
                }
            }
        public byte[] Binary () {return null;
            }
        public byte[] Binary8 () {return null;
            }
        public byte[] Binary16 () {return null;
            }
        public byte[] LBinary () {return null;
            }
        public byte[] Hex () {return null;
            }
        public byte[] Hex8 () {return null;
            }
        public byte[] Hex16 () {return null;
            }

        }
    }
