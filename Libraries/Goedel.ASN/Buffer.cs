using System;
using System.Collections.Generic;
using System.Text;
using SD=System.Diagnostics;

namespace Goedel.ASN {

    // ASN.1 Tagging modes
    //
    // We have the following options:
    //
    // Universal / Contrusted


    /// <summary>
    /// ASN.1 data tagging modes. 
    /// </summary>
    public enum TagMode {
        /// <summary>Intrinsic type.</summary>
        Universal           = 0,
        /// <summary>Type is constructed which is redundant as SETs and LISTs are
        /// always constructed.</summary>
        Constructed = 0x20,    // WTF how can Sets or LISTs not be constructed types?
        /// <summary></summary>
        Application = 0x40,
        /// <summary></summary>
        Context = 0x80,
        /// <summary></summary>
        Private = 0xB0,
        }

    /// <summary>
    /// ASN.1 flags
    /// </summary>
    public enum ASNFlags : int {
        /// <summary>No flags</summary>
        Nil = 0x00,
        /// <summary>Tagging is implicit by position</summary>
        Implicit = 0x01,
        /// <summary>Tagging is explicit</summary>
        Explicit = 0x02,
        /// <summary>The field is optional and must be tagged with the option code if present</summary>
        Optional = 0x04,
        /// <summary>The field is context dependent.</summary>
        Context = 0x08
        }

    /// <summary>
    /// Buffer class for assembling ASN.1 output data in DER encoding.
    /// </summary>
    public partial class Buffer {

        // Internal variables
        // Buffer is filled from the end
        private byte []                 Buffered;

        // While we could in theory use Assanine 1 for > 2Gb og data it 
        // would be stupid to do that.
        private int                    Pointer;

        /// <summary>
        /// The maximum chunk size for allocating data (defaults to 32,768)
        /// </summary>
        public int                      MaxChunk = 32768;

        /// <summary>
        /// Return the value of the buffer (in a fresh zero based array)
        /// </summary>
        public byte []                  Data {
            get {
                byte [] Value = new byte [Length];
                Array.Copy (Buffered, Pointer, Value, 0, Length);
                return Value;} }

        /// <summary>
        /// Length is calculated as buffer size - used
        /// </summary>
        public int                 Length => Buffered.Length - Pointer; 

        /// <summary>Constructor with default initial buffer size of 1024 bytes</summary>
        public Buffer() : this (1024) {
            }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Size">Initial buffer size in bytes.</param>
        public Buffer (int Size) {
            Buffered = new byte [Size];
            Pointer = Size;
            }

        /// <summary>
        /// Debug output
        /// </summary>
        /// <param name="Tag">Tag to mark to output</param>
        public void Debug(string Tag) {
            //var Builder = new StringBuilder();
            //Builder.Append(Tag);
            //Builder.Append(":");
            //for (int i = Pointer; i < Buffered.Length; i++) {
            //    if ((i % 16) == 0) {
            //        SD.Debug.WriteLine(Builder.ToString());
            //        Builder.Clear();
            //        Builder.Append("   ");
            //        }
            //    Builder.AppendFormat(" {0:x2}", Buffered[i]);
            //    }
            //SD.Debug.WriteLine(Builder.ToString());
            }

        // Convenience function, only ever adds the lowest byte.
        void AddByte(int Data) => Add((byte)(Data & 0xff));

        /// <summary>
        /// Add a byte to the stream
        /// </summary>
        /// <param name="Data">Data to write.</param>
        public void Add (byte Data) {
            if (Pointer <= 0) {
                Pointer = Buffered.Length < MaxChunk ?
                    Buffered.Length : MaxChunk ;
                // NB CANNOT use resize as new values go at the END
                var NewBuffer = new byte[Buffered.Length + Pointer];
                Array.Copy(Buffered, 0, NewBuffer, Pointer, Buffered.Length);
                Buffered = NewBuffer;
                }
            Pointer --;
            Buffered [Pointer] = Data;
            }

        // Base 128 encoding used in tag and OID encodings
        // Lower 7 bits contain value, MSB first
        // Upper bit is 1 except on last byte where it is 0

        /// <summary>
        /// Add a base128 encoded length tag to the buffer.
        /// </summary>
        /// <param name="Data">Integer to encode</param>
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
        /// Add tag to the stream
        /// </summary>
        /// <param name="Data">Tag to add</param>
        /// <param name="Mode">Tagging mode.</param>
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
        /// Add a data length item to the stream
        /// </summary>
        /// <param name="Data">The length to add</param>
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
        /// Add OID to the stream
        /// </summary>
        /// <param name="Data">The data to add</param>
        public void AddOID(int [] Data) {
            if (Data.Length < 2) {
                throw new Exception("OID must have at least 2 segments");
                }
            
            for (int i = Data.Length-1; i >= 2 ; --i) {
                AddBase128 (Data [i]);
                }

            AddByte (Data [0] * 40 + Data [1]);
            }

        /// <summary>
        /// Start encoding a sequence
        /// </summary>
        /// <returns>Position in the buffer relative to the buffer end (always negative)</returns>
        public int Encode__Sequence_Start() => Pointer - Buffered.Length;

        /// <summary>
        /// Encode end of a sequence. Note that since everything is written out 
        /// backwards calls to end sequences must preceed the date to begin.
        /// </summary>
        /// <param name="Position">Buffer position</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">Code</param>
        public void Encode__Sequence_End(int Position, int Flags, int Code) => AddTagLength(Position + Buffered.Length, Constants.Sequence, TagMode.Constructed, Flags, Code);

        /// <summary>
        /// Encode end of a sequence. Note that since everything is written out 
        /// backwards calls to end sequences must preceed the date to begin.
        /// </summary>
        /// <param name="Position">Buffer position</param>
        public void Encode__Sequence_End(int Position) => AddTagLength(Position + Buffered.Length, Constants.Sequence, TagMode.Constructed, 0, 0);

        /// <summary>
        /// Start encoding a set
        /// </summary>
        /// <returns>Position in the buffer relative to the buffer end (always negative)</returns>
        public int Encode__Set_Start() => Pointer - Buffered.Length;

        /// <summary>
        /// Encode end of a set. Note that since everything is written out 
        /// backwards calls to end sequences must preceed the date to begin.
        /// </summary>
        /// <param name="Position">Buffer position</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">Code</param>
        public void Encode__Set_End(int Position, int Flags, int Code) => AddTagLength(Position + Buffered.Length, Constants.Set, TagMode.Constructed, Flags, Code);

        /// <summary>
        /// Add a tag with length data
        /// </summary>
        /// <param name="Position">Current buffer position</param>
        /// <param name="Tag">Tag to add</param>
        /// <param name="TagMode">Tagging mode</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">Code</param>
        public void AddTagLength (int Position, int Tag, TagMode TagMode, int Flags, int Code) {
            bool Context = (Flags & (int) ASNFlags.Context) > 0;
            bool Implicit = (Flags & (int) ASNFlags.Implicit) > 0;
            bool Explicit = (Flags & (int) ASNFlags.Explicit) > 0;
            //bool Optional = (Flags & (int) ASNFlags.Optional) > 0;

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
        /// Encode the data type
        /// </summary>
        /// <param name="Data">Data to be encoded</param>
        /// <param name="Flags">Flags</param>
        /// <param name="code">Code</param>
        public void Encode__Any (byte [] Data, int Flags, int code) {
            }


        //
        //  Add Boolean value
        //
        //  True = 0xff  / False = 0x00
        //

        /// <summary>
        /// Encode a boolean value with default.
        /// </summary>
        /// <param name="Data">Value to encode</param>
        /// <param name="Flags">Flags</param>
        /// <param name="code">Code</param>
        /// <param name="Default">The default value</param>
        public void Encode__Boolean(bool Data, int Flags, int code, bool Default) {
            if (Data != Default) {
                Encode__Boolean (Data, Flags, code);
                }
            }

        /// <summary>
        /// Encode a boolean value.
        /// </summary>
        /// <param name="Data">Value to encode</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">Code</param>
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
        /// Encode an integer value with default.
        /// </summary>
        /// <param name="Data">Value to encode</param>
        /// <param name="Flags">Flags</param>
        /// <param name="code">Code</param>
        /// <param name="Default">The default value</param>
        public void Encode__Integer(int Data, int Flags, int code, int Default) {
            if (Data != Default) {
                Encode__Integer (Data, Flags, code);
                }
            }

        /// <summary>
        /// Encode a boolean value.
        /// </summary>
        /// <param name="Data">Value to encode</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">Code</param>
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
        /// Encode a big integer value.
        /// </summary>
        /// <param name="Data">The data to encode in most significant byte order.</param>
        /// <param name="Flags">Flags</param>
        /// <param name="Code">ASN.1 Code.</param>
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
                //int Count = Data.Length - Index;
                if (Data[Index] >= 0x80) {
                    AddByte(0);
                    //Count++;
                    }
                }

            //AddTag(Constants.Integer, TagMode.Universal);
            AddTagLength (Position, Constants.Integer, TagMode.Universal, Flags, Code);
            }

        private void AddBytes(byte[] Data, int Start, int End) {
            for (int i = End; i >= Start; i--) {
                AddByte (Data [i]);
                if (i == 0) {
                    
                    }
                }
            }

        /// <summary>
        /// Encode a null value.
        /// </summary>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__Null(int Flags, int Code) {
            int Position = Pointer;

            //AddLength(0);
            //AddTag(Constants.Null, TagMode.Universal);
            AddTagLength (Position, Constants.Null, TagMode.Universal, Flags, Code);
            }

        // Bits must be byte aligned.


        private bool IsOptional(int Flags) => ((Flags & ((int)ASNFlags.Optional)) > 0);

        private bool NullCheck(bool IsDefault, int Flags, int Code) {
            if (IsDefault) {
                if (!IsOptional(Flags)) {
                    Encode__Null(Flags, Code);
                    }
                }
            return IsDefault;
            }

        /// <summary>
        /// Encode a bit field.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__Bits(byte[] Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck(Data == null, Flags, Code)) {
                return;
                }

            AddBytes(Data, 0, Data.Length - 1);

            AddByte(0);
            //AddLength(Data.Length + 1);
            //AddTag(Constants.BitString, TagMode.Universal);
            AddTagLength (Position, Constants.BitString, TagMode.Universal, Flags, Code);
            }

        // The first byte in a VBits element specifies the number of 
        // unused bits in the last byte.

        /// <summary>
        /// Encode a VBits element. The first byte in a VBits element specifies the number of
        /// unused bits in the last byte.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__VBits(byte[] Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck(Data == null, Flags, Code)) {
                return;
                }

            AddBytes(Data, 0, Data.Length - 1);

            //AddLength(Data.Length);
            //AddTag(Constants.BitString, TagMode.Universal);
            AddTagLength (Position, Constants.BitString, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// Encode a data element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__Octets (byte [] Data, int Flags, int Code) {
            int Position = Pointer;
            
            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

            AddBytes( Data, 0, Data.Length-1);
            //AddLength (Data.Length);
            //AddTag(Constants.OctetString, TagMode.Universal);
            AddTagLength (Position, Constants.OctetString, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// Encode a data object.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__Object(Goedel.ASN.Root Data, int Flags, int Code) {
            //int Position = Pointer;

            if (NullCheck(Data == null, Flags, Code)) {
                return;
                }

            Data.Encode(this);

            }

        /// <summary>
        /// Encode an OID element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__OIDRef (int [] Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

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
        /// Encode a date-time element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>        
        public void Encode__Time(DateTime Data, int Flags, int Code) {

            //if (NullCheck (Data == null, Flags, Code)) return;

            if (Data.Year < 2050) {
                Encode__UTCTime (Data, Flags, Code);
                }
            else {
                Encode__GeneralizedTime (Data, Flags, Code);
                }
            }

        /// <summary>
        /// Encode a UTC time element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__UTCTime (DateTime Data, int Flags, int Code) {
            int Position = Pointer;

            string Time = Data.ToString ("yyMMddhhmmssZ");
            byte [] ASCII = System.Text.Encoding.UTF8.GetBytes (Time);
            AddBytes( ASCII, 0, ASCII.Length-1);
            //AddLength (ASCII.Length);
            //AddTag (Constants.UTCTime, TagMode.Universal);
            AddTagLength (Position, Constants.UTCTime, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// Encode a generalized time element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__GeneralizedTime (DateTime Data, int Flags, int Code) {
            int Position = Pointer;

            string Time = Data.ToString ("yyyyMMddhhmmssZ");
            byte [] ASCII = System.Text.Encoding.UTF8.GetBytes (Time);
            AddBytes( ASCII, 0, ASCII.Length-1);
            //AddLength (ASCII.Length);
            //AddTag (Constants.GeneralizedTime, TagMode.Universal);
            AddTagLength (Position, Constants.GeneralizedTime, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// Encode a UTF8 string element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__UTF8String (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

            byte [] UTF8 = System.Text.Encoding.UTF8.GetBytes (Data);
            AddBytes( UTF8, 0, UTF8.Length-1);
            //AddLength (UTF8.Length);
            //AddTag(Constants.UTF8String, TagMode.Universal);
            AddTagLength (Position, Constants.UTF8String, TagMode.Universal, Flags, Code);
            }

        private bool IsPrintable(char c) {
            if (c>='A' & c<= 'Z') {
                return true;
                }

            if (c>='a' & c<= 'z') {
                return true;
                }

            if (c>='0' & c<= '9') {
                return true;
                }

            if (c==' ' | c == '\'' | c =='(' | c == ')' | c == '+' |
                c==',' | c == '-' | c =='.' | c == '/' | c == ':'  |
                c == '=' | c == '?') {
                return true;
                }

            return false;
            }

        /// <summary>
        /// Encode a printable string element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__PrintableString (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

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
        /// Encode a IA5String element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__IA5String (string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

            for (int i = Data.Length; i > 0; i--) {
                char c = Data [i-1];
                AddByte (c);
                }
            //AddLength (Data.Length);
            //AddTag (Constants.IA5String, TagMode.Universal);
            AddTagLength (Position, Constants.IA5String, TagMode.Universal, Flags, Code);
            }

        /// <summary>
        /// Encode a BMP string data element.
        /// </summary>
        /// <param name="Data">Data to encode</param>
        /// <param name="Flags">ASN.1 Flags</param>
        /// <param name="Code">ASN.1 Code</param>
        public void Encode__BMPString(string Data, int Flags, int Code) {
            int Position = Pointer;

            if (NullCheck (Data == null, Flags, Code)) {
                return;
                }

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
