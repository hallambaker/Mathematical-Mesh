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
using System.Linq;
using System.Text;

namespace Goedel.ASN1 {

    // ASN.1 Tagging modes
    //
    // We have the following options:
    //
    // Universal / Constructed


    /// <summary>
    /// 
    /// </summary>

    public enum TagMode {
        /// <summary>
        /// 
        /// </summary>
        Universal = 0,
        /// <summary>
        /// 
        /// </summary>
        Constructed = 0x20,    // WTF how can Sets or LISTs not be constructed types?
        /// <summary>
        /// 
        /// </summary>
        Application = 0x40,
        /// <summary>
        /// 
        /// </summary>
        Context = 0x80,
        /// <summary>
        /// 
        /// </summary>
        Private = 0xB0,
        }

    /// <summary>
    /// 
    /// </summary>
    public enum ASNFlags : int {
        /// <summary>
        /// 
        /// </summary>
        Nil = 0x00,
        /// <summary>
        /// 
        /// </summary>
        Implicit = 0x01,
        /// <summary>
        /// 
        /// </summary>
        Explicit = 0x02,
        /// <summary>
        /// 
        /// </summary>
        Optional = 0x04,
        /// <summary>
        /// 
        /// </summary>
        Context = 0x08
        }

    /// <summary>
    /// 
    /// </summary>
    public partial class Buffer {

        // Internal variables
        // Buffer is filled from the end
        private byte []                 Buffered;

        // While we could in theory use Assanine 1 for > 2Gb og data it 
        // would be stupid to do that.
        private int                    Pointer;

        /// <summary>
        /// 
        /// </summary>
        public int                      MaxChunk = 32768;

        // Return the value of the buffer (in a fresh zero based array)
        /// <summary>
        /// 
        /// </summary>
        public byte []                  Data {
            get {
                byte [] Value = new byte [Length];
                Array.Copy (Buffered, Pointer, Value, 0, Length);
                return Value;} }

        // Length is calculated as buffer size - used
        /// <summary>
        /// 
        /// </summary>
        public int                 Length {
            get { return Buffered.Length - Pointer; }}

        // Default buffer size is 1024 bytes
        /// <summary>
        /// 
        /// </summary>
        public Buffer() : this (1024) {
            }

        /// <summary>
        /// 
        /// </summary>
        public Buffer (int Size) {
            Buffered = new byte [Size];
            Pointer = Size;
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tag"></param>
        public void Debug (string Tag) {
            //Console.Write ("{0}:", Tag);
            //for (int i = Pointer; i < Buffered.Length; i++) {
            //    if ((i % 16) == 0) {
            //        Console.WriteLine ();
            //        Console.Write ("   ");
            //        }
            //    Console.Write (" {0:x2}", Buffered[i]);
            //    }
            //Console.WriteLine ();
            }

        // Convenience function, only ever adds the lowest byte.
        void AddByte (int Data) {
            Add ((byte) (Data & 0xff));
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public void Add (byte Data) {
            if (Pointer <= 0) {
                int NewLength = Buffered.Length * 2 < MaxChunk ?
                    Buffered.Length * 2 : Buffered.Length + MaxChunk ;
                byte [] NewBuffer = new byte [NewLength];

                Array.Copy (Buffered, 0, NewBuffer, NewLength-Length, Length);
                }
            Pointer --;
            Buffered [Pointer] = Data;
            }

        // Base 128 encoding used in tag and OID encodings
        // Lower 7 bits contain value, MSB first
        // Upper bit is 1 except on last byte where it is 0
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public void AddBase128(int Data) {
            if (Data < 0x80) {
                AddByte (Data);
                }
            else if (Data < 0x4000) {
                AddByte (Data & 0x7f);
                AddByte ((Data >> 7) | 0x80);
                }
            else if (Data < 0x200000) {
                AddByte (Data & 0x7f);
                AddByte ((Data >> 7) | 0x80);
                AddByte ((Data >> 14) | 0x80);
                }
            else if (Data < 0x10000000) {
                AddByte (Data & 0x7f);
                AddByte ((Data >> 7) | 0x80);
                AddByte ((Data >> 14) | 0x80);
                AddByte ((Data >> 21) | 0x80);
                }
            else {
                AddByte (Data & 0x7f);
                AddByte ((Data >> 7) | 0x80);
                AddByte ((Data >> 14) | 0x80);
                AddByte ((Data >> 21) | 0x80);
                AddByte ((Data >> 28) | 0x80);
                }
            }
        
        
        // Rules for tag encoding
        // 1st byte is tag | Flags for tag <= 30
        // For tags over 30, tag is presented base 128
        // last octet has bit 8 clear
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Mode"></param>
        public void AddTag(int Data, TagMode Mode) {
            if (Data < 31) {
                AddByte (Data | (int) Mode);
                }
            else {
                AddBase128(Data);
                AddByte (0x1f | (int) Mode);
                }
            }

        // Rules for length encoding
        // if Data < 128    1 byte 
        // if Data >= 128   1st byte gives length of length
        //                  2nd gives most significant digit etc.
        // Bytes are added in reverse order.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public void AddLength(int Data) {

            if (Data < 0x80) {
                AddByte (Data);
                }
            else if (Data < 0x100) {
                AddByte (Data);
                Add (0x81);
                }
            else if (Data < 0x10000) {
                AddByte (Data);
                AddByte (Data>>8);
                Add (0x82);
                }
            else if (Data < 0x1000000) {
                AddByte(Data);
                AddByte(Data >> 8);
                AddByte(Data >> 16);
                Add(0x83);
                }
            else {
                AddByte(Data);
                AddByte(Data >> 8);
                AddByte(Data >> 16);
                AddByte(Data >> 24);
                Add(0x84);
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public void AddOID(int [] Data) {
            if (Data.Length < 2) throw new Exception("OID must have at least 2 segments");            
            
            for (int i = Data.Length-1; i >= 2 ; --i) {
                AddBase128 (Data [i]);
                }

            AddByte (Data [0] * 40 + Data [1]);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Encode__Sequence_Start () {
            return Pointer;
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Sequence_End (int Position, int Flags, int Code) {
            AddTagLength (Position, Constants.Sequence, TagMode.Constructed, Flags, Code);
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position"></param>
        public void Encode__Sequence_End (int Position) {
            AddTagLength (Position, Constants.Sequence, TagMode.Constructed, 0, 0);
            }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Encode__Set_Start () {
            return Pointer;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Set_End(int Position, int Flags, int Code) {
            AddTagLength (Position, Constants.Set, TagMode.Constructed, Flags, Code);
            }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Tag"></param>
        /// <param name="TagMode"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void AddTagLength (int Position, int Tag, TagMode TagMode, int Flags, int Code) {
            bool Context = (Flags & (int) ASNFlags.Context) > 0;
            bool Implicit = (Flags & (int) ASNFlags.Implicit) > 0;
            bool Explicit = (Flags & (int) ASNFlags.Explicit) > 0;
            bool Optional = (Flags & (int) ASNFlags.Optional) > 0;

            if (Context) {
                AddLength (Position - Pointer);
                AddTag (Code, TagMode.Context);
                }

            else if (!Implicit & !Explicit) {
                AddLength (Position - Pointer);
                AddTag (Tag, TagMode);
                }

            else if (Implicit) {
                AddLength (Position - Pointer);
                AddTag (Code, TagMode.Application);
                }

            else { // must be explicit
                AddLength (Position - Pointer);
                AddTag (Tag, TagMode);                  // Inner tag-length
                AddLength (Position - Pointer);
                AddTag (Code, TagMode.Context | TagMode.Constructed);     // Outer tag-length
                }

            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="code"></param>
        public void Encode__Any (byte [] Data, int Flags, int code) {
            }


        //
        //  Add Boolean value
        //
        //  True = 0xff  / False = 0x00
        //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="code"></param>
        /// <param name="Default"></param>
        public void Encode__Boolean(bool Data, int Flags, int code, bool Default) {
            if (Data != Default) {
                Encode__Boolean (Data, Flags, code);
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Boolean (bool Data, int Flags, int Code) {
            int Position = Pointer;

            if (Data) {
                AddByte (0xff);
                }
            else {
                AddByte (0x00);
                }
            //AddLength(1);
            //AddTag(Constants.Integer, TagMode.Universal);

            AddTagLength (Position, Constants.Boolean, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="code"></param>
        /// <param name="Default"></param>
        public void Encode__Integer(int Data, int Flags, int code, int Default) {
            if (Data != Default) {
                Encode__Integer (Data, Flags, code);
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Integer(int Data, int Flags, int Code) {
            int Position = Pointer;
            if (Data == Int32.MinValue) {
                return; // should futz here with the optionality flags etc.
                }

            if (Data < 0) {
                throw new Exception("Negative Integers TBD");
                }
            if (Data < 0x80) {
                AddByte(Data);
                //AddLength(1);
                }
            else if (Data < 0x8000) {
                AddByte(Data);
                AddByte(Data >> 8);
                //AddLength(2);
                }
            else if (Data < 0x800000) {
                AddByte(Data);
                AddByte(Data >> 8);
                AddByte(Data >> 16);
                //AddLength(3);
                }
            else {  // since the value passed is a SIGNED integer, it must fit in 4 bytes
                AddByte(Data);
                AddByte(Data >> 8);
                AddByte(Data >> 16);
                AddByte(Data >> 24);
                //AddLength(4);
                }


            //AddTag(Constants.Integer, TagMode.Universal);
            AddTagLength (Position, Constants.Integer, TagMode.Universal, Flags, Code);
            }

        // Only positive big numbers are supported.
        // The Microsoft .NET crypto routines return arrays in which Data[0] is the MSB
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__BigInteger(byte[] Data, int Flags, int Code) {
            int Position = Pointer;
            // Strip off preceding zeros
            int Index = -1;
            for (int i = 0; i < Data.Length; i++) {
                if (Data[i] != 0) {
                    Index = i;
                    break;
                    }
                }

            if (Index == -1) {
                AddByte(0);
                ////AddLength(1);
                }
            else {
                AddBytes( Data, Index, Data.Length-1);
                int Count = Data.Length - Index;
                if (Data[0] >= 0x80) {
                    AddByte(0);
                    Count++;
                    }
                }

            //AddTag(Constants.Integer, TagMode.Universal);
            AddTagLength (Position, Constants.Integer, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        private void AddBytes(byte[] Data, int Start, int End) {
            for (int i = End; i >= Start; i--) {
                AddByte (Data [i]);
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Null(int Flags, int Code) {
            int Position = Pointer;

            //AddLength(0);
            //AddTag(Constants.Null, TagMode.Universal);
            AddTagLength (Position, Constants.Null, TagMode.Universal, Flags, Code);
            }

        // Bits must be byte aligned.

        private bool IsOptional(int Flags) {
            return (( Flags & ((int) ASNFlags.Optional)) > 0);
            }

        private bool NullCheck(bool IsDefault, int Flags, int Code) {
            if (IsDefault) {
                if (!IsOptional(Flags)) {
                    Encode__Null(Flags, Code);
                    }
                }
            return IsDefault;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Bits(byte[] Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            AddBytes(Data, 0, Data.Length - 1);

            AddByte(0);
            //AddLength(Data.Length + 1);
            //AddTag(Constants.BitString, TagMode.Universal);
            AddTagLength (Position, Constants.BitString, TagMode.Universal, Flags, Code);
            }

        // The first byte in a VBits element specifies the number of 
        // unused bits in the last byte.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__VBits(byte[] Data, int Flags, int Code) {
            int Position = Pointer;
            
            if (NullCheck (Data == null, Flags, Code)) return;

            AddBytes(Data, 0, Data.Length - 1);

            //AddLength(Data.Length);
            //AddTag(Constants.BitString, TagMode.Universal);
            AddTagLength (Position, Constants.BitString, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Octets (byte [] Data, int Flags, int Code) {
            int Position = Pointer;
            
            if (NullCheck (Data == null, Flags, Code)) return;

            AddBytes( Data, 0, Data.Length-1);
            //AddLength (Data.Length);
            //AddTag(Constants.OctetString, TagMode.Universal);
            AddTagLength (Position, Constants.OctetString, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Object(Goedel.ASN1.Root Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck(Data == null, Flags, Code)) return;

            Data.Encode(this);

            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__OIDRef (int [] Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            AddOID (Data);
            AddTagLength (Position, Constants.ObjectIdentifier, TagMode.Universal, Flags, Code);
            }


        //public void Encode__Time (string Data, int Flags, int code) {
        //    int Position = Pointer;
        //    }


        //
        //  All times are encoded using X.509v3 rules, i.e.
        //
        //  For dates before 1 Jan 2050 use UTCTime, otherwise Generalized Time
        //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__Time(DateTime Data, int Flags, int Code) {

            if (NullCheck (Data == null, Flags, Code)) return;

            if (Data.Year < 2050) {
                Encode__UTCTime (Data, Flags, Code);
                }
            else {
                Encode__GeneralizedTime (Data, Flags, Code);
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__UTCTime (DateTime Data, int Flags, int Code) {
            int Position = Pointer;

            string Time = Data.ToString ("yyMMddhhmmssZ");
            byte [] ASCII = System.Text.Encoding.ASCII.GetBytes (Time);
            AddBytes( ASCII, 0, ASCII.Length-1);
            //AddLength (ASCII.Length);
            //AddTag (Constants.UTCTime, TagMode.Universal);
            AddTagLength (Position, Constants.UTCTime, TagMode.Universal, Flags, Code);
            }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__GeneralizedTime (DateTime Data, int Flags, int Code) {
            int Position = Pointer;

            string Time = Data.ToString ("yyyyMMddhhmmssZ");
            byte [] ASCII = System.Text.Encoding.ASCII.GetBytes (Time);
            AddBytes( ASCII, 0, ASCII.Length-1);
            //AddLength (ASCII.Length);
            //AddTag (Constants.GeneralizedTime, TagMode.Universal);
            AddTagLength (Position, Constants.GeneralizedTime, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__UTF8String (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            byte [] UTF8 = System.Text.Encoding.UTF8.GetBytes (Data);
            AddBytes( UTF8, 0, UTF8.Length-1);
            //AddLength (UTF8.Length);
            //AddTag(Constants.UTF8String, TagMode.Universal);
            AddTagLength (Position, Constants.UTF8String, TagMode.Universal, Flags, Code);
            }

        private bool IsPrintable(char c) {
            if (c>='A' & c<= 'Z') return true;
            if (c>='a' & c<= 'z') return true;
            if (c>='0' & c<= '9') return true;
            if (c==' ' | c == '\'' | c =='(' | c == ')' | c == '+' |
                c==',' | c == '-' | c =='.' | c == '/' | c == ':'  |
                c == '=' | c == '?') return true;
            return false;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__PrintableString (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            int Length = 0;
            
            for (int i = Data.Length; i > 0; i--) {
                char c = Data [i-1];
                if (IsPrintable(c)) {
                    AddByte(c);
                    Length++;
                    }
                }
            //AddLength (Length);
            //AddTag (Constants.IA5String, TagMode.Universal);
            AddTagLength (Position, Constants.PrintableString, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__IA5String (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            for (int i = Data.Length; i > 0; i--) {
                char c = Data [i-1];
                AddByte (c);
                }
            //AddLength (Data.Length);
            //AddTag (Constants.IA5String, TagMode.Universal);
            AddTagLength (Position, Constants.IA5String, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Flags"></param>
        /// <param name="Code"></param>
        public void Encode__BMPString(string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) return;

            for (int i = Data.Length; i > 0; i--) {
                char c = Data [i-1];
                AddByte (c);
                AddByte (c>>8);
                }
            //AddLength (Data.Length * 2);
            //AddTag (Constants.BMPString, TagMode.Universal);
            AddTagLength (Position, Constants.BMPString, TagMode.Universal, Flags, Code);
            }

        }
    }
