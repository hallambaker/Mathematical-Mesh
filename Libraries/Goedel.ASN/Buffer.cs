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


namespace Goedel.ASN;

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
    Universal = 0,
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
    private byte[] buffered;

    // While we could in theory use Assanine 1 for > 2Gb og data it 
    // would be stupid to do that.
    private int pointer;

    /// <summary>
    /// The maximum chunk size for allocating data (defaults to 32,768)
    /// </summary>
    public int MaxChunk = 32768;

    /// <summary>
    /// Return the value of the buffer (in a fresh zero based array)
    /// </summary>
    public byte[] Data {
        get {
            byte[] Value = new byte[Length];
            Array.Copy(buffered, pointer, Value, 0, Length);
            return Value;
            }
        }

    /// <summary>
    /// Length is calculated as buffer size - used
    /// </summary>
    public int Length => buffered.Length - pointer;

    /// <summary>Constructor with default initial buffer size of 1024 bytes</summary>
    public Buffer() : this(1024) {
        }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Size">Initial buffer size in bytes.</param>
    public Buffer(int Size) {
        buffered = new byte[Size];
        pointer = Size;
        }

    /// <summary>
    /// Debug output
    /// </summary>
    /// <param name="Tag">Tag to mark to output</param>
    public void Debug(string Tag) => Tag.Keep();

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

    // Convenience function, only ever adds the lowest byte.
    void AddByte(int data) => Add((byte)(data & 0xff));

    /// <summary>
    /// Add a byte to the stream
    /// </summary>
    /// <param name="data">Data to write.</param>
    public void Add(byte data) {
        if (pointer <= 0) {
            pointer = buffered.Length < MaxChunk ?
                buffered.Length : MaxChunk;
            // NB CANNOT use resize as new values go at the END
            var NewBuffer = new byte[buffered.Length + pointer];
            Array.Copy(buffered, 0, NewBuffer, pointer, buffered.Length);
            buffered = NewBuffer;
            }
        pointer--;
        buffered[pointer] = data;
        }

    // Base 128 encoding used in tag and OID encodings
    // Lower 7 bits contain value, MSB first
    // Upper bit is 1 except on last byte where it is 0

    /// <summary>
    /// Add a base128 encoded length tag to the buffer.
    /// </summary>
    /// <param name="data">Integer to encode</param>
    public void AddBase128(int data) {
        if (data < 0x80) {
            AddByte(data);
            }
        else if (data < 0x4000) {
            AddByte(data & 0x7f);
            AddByte((data >> 7) | 0x80);
            }
        else if (data < 0x200000) {
            AddByte(data & 0x7f);
            AddByte((data >> 7) | 0x80);
            AddByte((data >> 14) | 0x80);
            }
        else if (data < 0x10000000) {
            AddByte(data & 0x7f);
            AddByte((data >> 7) | 0x80);
            AddByte((data >> 14) | 0x80);
            AddByte((data >> 21) | 0x80);
            }
        else {
            AddByte(data & 0x7f);
            AddByte((data >> 7) | 0x80);
            AddByte((data >> 14) | 0x80);
            AddByte((data >> 21) | 0x80);
            AddByte((data >> 28) | 0x80);
            }
        }


    // Rules for tag encoding
    // 1st byte is tag | Flags for tag <= 30
    // For tags over 30, tag is presented base 128
    // last octet has bit 8 clear

    /// <summary>
    /// Add tag to the stream
    /// </summary>
    /// <param name="data">Tag to add</param>
    /// <param name="mode">Tagging mode.</param>
    public void AddTag(int data, TagMode mode) {
        if (data < 31) {
            AddByte(data | (int)mode);
            }
        else {
            AddBase128(data);
            AddByte(0x1f | (int)mode);
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
    /// <param name="data">The length to add</param>
    public void AddLength(int data) {

        if (data < 0x80) {
            AddByte(data);
            }
        else if (data < 0x100) {
            AddByte(data);
            Add(0x81);
            }
        else if (data < 0x10000) {
            AddByte(data);
            AddByte(data >> 8);
            Add(0x82);
            }
        else if (data < 0x1000000) {
            AddByte(data);
            AddByte(data >> 8);
            AddByte(data >> 16);
            Add(0x83);
            }
        else {
            AddByte(data);
            AddByte(data >> 8);
            AddByte(data >> 16);
            AddByte(data >> 24);
            Add(0x84);
            }
        }

    /// <summary>
    /// Add OID to the stream
    /// </summary>
    /// <param name="data">The data to add</param>
    public void AddOID(int[] data) {
        if (data.Length < 2) {
            throw new Exception("OID must have at least 2 segments");
            }

        for (int i = data.Length - 1; i >= 2; --i) {
            AddBase128(data[i]);
            }

        AddByte(data[0] * 40 + data[1]);
        }

    /// <summary>
    /// Start encoding a sequence
    /// </summary>
    /// <returns>Position in the buffer relative to the buffer end (always negative)</returns>
    public int Encode__Sequence_Start() => pointer - buffered.Length;

    /// <summary>
    /// Encode end of a sequence. Note that since everything is written out 
    /// backwards calls to end sequences must preceed the date to begin.
    /// </summary>
    /// <param name="position">Buffer position</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void Encode__Sequence_End(int position, int flags, int code) => AddTagLength(position + buffered.Length, Constants.Sequence, TagMode.Constructed, flags, code);

    /// <summary>
    /// Encode end of a sequence. Note that since everything is written out 
    /// backwards calls to end sequences must preceed the date to begin.
    /// </summary>
    /// <param name="position">Buffer position</param>
    public void Encode__Sequence_End(int position) => AddTagLength(position + buffered.Length, Constants.Sequence, TagMode.Constructed, 0, 0);

    /// <summary>
    /// Start encoding a set
    /// </summary>
    /// <returns>Position in the buffer relative to the buffer end (always negative)</returns>
    public int Encode__Set_Start() => pointer - buffered.Length;

    /// <summary>
    /// Encode end of a set. Note that since everything is written out 
    /// backwards calls to end sequences must preceed the date to begin.
    /// </summary>
    /// <param name="position">Buffer position</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void Encode__Set_End(int position, int flags, int code) => AddTagLength(position + buffered.Length, Constants.Set, TagMode.Constructed, flags, code);

    /// <summary>
    /// Add a tag with length data
    /// </summary>
    /// <param name="position">Current buffer position</param>
    /// <param name="tag">Tag to add</param>
    /// <param name="tagMode">Tagging mode</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void AddTagLength(int position, int tag, TagMode tagMode, int flags, int code) {
        bool context = (flags & (int)ASNFlags.Context) > 0;
        bool implicitFlag = (flags & (int)ASNFlags.Implicit) > 0;
        bool explicitFlag = (flags & (int)ASNFlags.Explicit) > 0;
        //bool Optional = (Flags & (int) ASNFlags.Optional) > 0;

        if (context) {
            AddLength(position - pointer);
            AddTag(code, TagMode.Context);
            }

        else if (!implicitFlag & !explicitFlag) {
            AddLength(position - pointer);
            AddTag(tag, tagMode);
            }

        else if (implicitFlag) {
            AddLength(position - pointer);
            AddTag(code, TagMode.Application);
            }

        else { // must be explicit
            AddLength(position - pointer);
            AddTag(tag, tagMode);                  // Inner tag-length
            AddLength(position - pointer);
            AddTag(code, TagMode.Context | TagMode.Constructed);     // Outer tag-length
            }

        }

    /// <summary>
    /// Encode the data type
    /// </summary>
    /// <param name="data">Data to be encoded</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void Encode__Any(byte[] data, int flags, int code) {
        data.Keep();
        flags.Keep();
        code.Keep();
        }

    //
    //  Add Boolean value
    //
    //  True = 0xff  / False = 0x00
    //

    /// <summary>
    /// Encode a boolean value with default.
    /// </summary>
    /// <param name="data">Value to encode</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    /// <param name="default">The default value</param>
    public void Encode__Boolean(bool data, int flags, int code, bool @default) {
        if (data != @default) {
            Encode__Boolean(data, flags, code);
            }
        }

    /// <summary>
    /// Encode a boolean value.
    /// </summary>
    /// <param name="data">Value to encode</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void Encode__Boolean(bool data, int flags, int code) {
        int Position = pointer;

        if (data) {
            AddByte(0xff);
            }
        else {
            AddByte(0x00);
            }
        //AddLength(1);
        //AddTag(Constants.Integer, TagMode.Universal);

        AddTagLength(Position, Constants.Boolean, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode an integer value with default.
    /// </summary>
    /// <param name="data">Value to encode</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    /// <param name="default">The default value</param>
    public void Encode__Integer(int data, int flags, int code, int @default) {
        if (data != @default) {
            Encode__Integer(data, flags, code);
            }
        }

    /// <summary>
    /// Encode a boolean value.
    /// </summary>
    /// <param name="data">Value to encode</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">Code</param>
    public void Encode__Integer(int data, int flags, int code) {
        int position = pointer;
        if (data == Int32.MinValue) {
            return; // should futz here with the optionality flags etc.
            }

        if (data < 0) {
            throw new Exception("Negative Integers TBD");
            }
        if (data < 0x80) {
            AddByte(data);
            //AddLength(1);
            }
        else if (data < 0x8000) {
            AddByte(data);
            AddByte(data >> 8);
            //AddLength(2);
            }
        else if (data < 0x800000) {
            AddByte(data);
            AddByte(data >> 8);
            AddByte(data >> 16);
            //AddLength(3);
            }
        else {  // since the value passed is a SIGNED integer, it must fit in 4 bytes
            AddByte(data);
            AddByte(data >> 8);
            AddByte(data >> 16);
            AddByte(data >> 24);
            //AddLength(4);
            }


        //AddTag(Constants.Integer, TagMode.Universal);
        AddTagLength(position, Constants.Integer, TagMode.Universal, flags, code);
        }

    // Only positive big numbers are supported.
    // The Microsoft .NET crypto routines return arrays in which Data[0] is the MSB

    /// <summary>
    /// Encode a big integer value.
    /// </summary>
    /// <param name="data">The data to encode in most significant byte order.</param>
    /// <param name="flags">Flags</param>
    /// <param name="code">ASN.1 Code.</param>
    public void Encode__BigInteger(byte[] data, int flags, int code) {
        int Position = pointer;
        // Strip off preceding zeros
        int Index = -1;
        for (int i = 0; i < data.Length; i++) {
            if (data[i] != 0) {
                Index = i;
                break;
                }
            }

        if (Index == -1) {
            AddByte(0);
            ////AddLength(1);
            }
        else {
            AddBytes(data, Index, data.Length - 1);
            //int Count = Data.Length - Index;
            if (data[Index] >= 0x80) {
                AddByte(0);
                //Count++;
                }
            }

        //AddTag(Constants.Integer, TagMode.Universal);
        AddTagLength(Position, Constants.Integer, TagMode.Universal, flags, code);
        }

    private void AddBytes(byte[] data, int start, int end) {
        for (int i = end; i >= start; i--) {
            AddByte(data[i]);
            if (i == 0) {

                }
            }
        }

    /// <summary>
    /// Encode a null value.
    /// </summary>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__Null(int flags, int code) {
        int Position = pointer;

        //AddLength(0);
        //AddTag(Constants.Null, TagMode.Universal);
        AddTagLength(Position, Constants.Null, TagMode.Universal, flags, code);
        }

    // Bits must be byte aligned.


    private bool IsOptional(int flags) => ((flags & ((int)ASNFlags.Optional)) > 0);

    private bool NullCheck(bool isDefault, int Flags, int Code) {
        if (isDefault) {
            if (!IsOptional(Flags)) {
                Encode__Null(Flags, Code);
                }
            }
        return isDefault;
        }

    /// <summary>
    /// Encode a bit field.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__Bits(byte[] data, int flags, int code) {
        int Position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        AddBytes(data, 0, data.Length - 1);

        AddByte(0);
        //AddLength(Data.Length + 1);
        //AddTag(Constants.BitString, TagMode.Universal);
        AddTagLength(Position, Constants.BitString, TagMode.Universal, flags, code);
        }

    // The first byte in a VBits element specifies the number of 
    // unused bits in the last byte.

    /// <summary>
    /// Encode a VBits element. The first byte in a VBits element specifies the number of
    /// unused bits in the last byte.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__VBits(byte[] data, int flags, int code) {
        int Position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        AddBytes(data, 0, data.Length - 1);

        //AddLength(Data.Length);
        //AddTag(Constants.BitString, TagMode.Universal);
        AddTagLength(Position, Constants.BitString, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode a data element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__Octets(byte[] data, int flags, int code) {
        int position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        AddBytes(data, 0, data.Length - 1);
        //AddLength (Data.Length);
        //AddTag(Constants.OctetString, TagMode.Universal);
        AddTagLength(position, Constants.OctetString, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode a data object.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__Object(Goedel.ASN.Root data, int flags, int code) {
        //int Position = Pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        data.Encode(this);

        }

    /// <summary>
    /// Encode an OID element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__OIDRef(int[] data, int flags, int code) {
        int position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        AddOID(data);
        AddTagLength(position, Constants.ObjectIdentifier, TagMode.Universal, flags, code);
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
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>        
    public void Encode__Time(DateTime data, int flags, int code) {

        //if (NullCheck (Data == null, Flags, Code)) return;

        if (data.Year < 2050) {
            Encode__UTCTime(data, flags, code);
            }
        else {
            Encode__GeneralizedTime(data, flags, code);
            }
        }

    /// <summary>
    /// Encode a UTC time element.
    /// </summary>
    /// <param name="Data">Data to encode</param>
    /// <param name="Flags">ASN.1 Flags</param>
    /// <param name="Code">ASN.1 Code</param>
    public void Encode__UTCTime(DateTime Data, int Flags, int Code) {
        int position = pointer;

        string time = Data.ToString("yyMMddhhmmssZ");
        byte[] ascii = System.Text.Encoding.UTF8.GetBytes(time);
        AddBytes(ascii, 0, ascii.Length - 1);
        //AddLength (ASCII.Length);
        //AddTag (Constants.UTCTime, TagMode.Universal);
        AddTagLength(position, Constants.UTCTime, TagMode.Universal, Flags, Code);
        }

    /// <summary>
    /// Encode a generalized time element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__GeneralizedTime(DateTime data, int flags, int code) {
        int position = pointer;

        string time = data.ToString("yyyyMMddhhmmssZ");
        byte[] ascii = System.Text.Encoding.UTF8.GetBytes(time);
        AddBytes(ascii, 0, ascii.Length - 1);
        //AddLength (ASCII.Length);
        //AddTag (Constants.GeneralizedTime, TagMode.Universal);
        AddTagLength(position, Constants.GeneralizedTime, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode a UTF8 string element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__UTF8String(string data, int flags, int code) {
        int Position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        byte[] UTF8 = System.Text.Encoding.UTF8.GetBytes(data);
        AddBytes(UTF8, 0, UTF8.Length - 1);
        //AddLength (UTF8.Length);
        //AddTag(Constants.UTF8String, TagMode.Universal);
        AddTagLength(Position, Constants.UTF8String, TagMode.Universal, flags, code);
        }

    private bool IsPrintable(char c) {
        if (c >= 'A' & c <= 'Z') {
            return true;
            }

        if (c >= 'a' & c <= 'z') {
            return true;
            }

        if (c >= '0' & c <= '9') {
            return true;
            }

        if (c == ' ' | c == '\'' | c == '(' | c == ')' | c == '+' |
            c == ',' | c == '-' | c == '.' | c == '/' | c == ':' |
            c == '=' | c == '?') {
            return true;
            }

        return false;
        }

    /// <summary>
    /// Encode a printable string element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__PrintableString(string data, int flags, int code) {
        int position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        int Length = 0;

        for (int i = data.Length; i > 0; i--) {
            char c = data[i - 1];
            if (IsPrintable(c)) {
                AddByte(c);
                Length++;
                }
            }
        //AddLength (Length);
        //AddTag (Constants.IA5String, TagMode.Universal);
        AddTagLength(position, Constants.PrintableString, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode a IA5String element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__IA5String(string data, int flags, int code) {
        int position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        for (int i = data.Length; i > 0; i--) {
            char c = data[i - 1];
            AddByte(c);
            }
        //AddLength (Data.Length);
        //AddTag (Constants.IA5String, TagMode.Universal);
        AddTagLength(position, Constants.IA5String, TagMode.Universal, flags, code);
        }

    /// <summary>
    /// Encode a BMP string data element.
    /// </summary>
    /// <param name="data">Data to encode</param>
    /// <param name="flags">ASN.1 Flags</param>
    /// <param name="code">ASN.1 Code</param>
    public void Encode__BMPString(string data, int flags, int code) {
        int Position = pointer;

        if (NullCheck(data == null, flags, code)) {
            return;
            }

        for (int i = data.Length; i > 0; i--) {
            char c = data[i - 1];
            AddByte(c);
            AddByte(c >> 8);
            }
        //AddLength (Data.Length * 2);
        //AddTag (Constants.BMPString, TagMode.Universal);
        AddTagLength(Position, Constants.BMPString, TagMode.Universal, flags, code);
        }

    }
