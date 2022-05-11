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


using System.Xml.Linq;

namespace Goedel.Protocol;

/// <summary>
/// JSON Writer for JSON-B, a superset of JSON encoding with codes that permit
/// efficient encoding of binary data and strings and encoding of floating point
/// values without loss of precision.
/// </summary>
public class JsonBWriter : JsonWriter {




    /// <summary>
    /// Create a new writer instance with the output <paramref name="Output"/>. 
    /// If <paramref name="Output"/> is null, a memory stream is created and
    /// used as the output.
    /// </summary>
    /// <param name="Output">Output buffer</param> 
    public JsonBWriter(Stream Output = null) => this.Output = Output ?? new MemoryStream();


    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// </summary>
    /// <param name="Code">Base code.</param>
    /// <param name="Length">Length of data to follow.</param>
    public void WriteTag(byte Code, long Length) => WriteTag(Output, Code, Length);


    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// to <paramref name="Output"/>.
    /// </summary>
    /// <param name="Output">The output stream to write to.</param>
    /// <param name="Code">Base code.</param>
    /// <param name="Length">Length of data to follow.</param>
    public static void WriteTag(Stream Output, byte Code, long Length) {
        if (Length < 0x100) {
            Output.Write((byte)(Code + JSONBCD.Length8));
            Output.Write((byte)(Length & 0xff));
            }
        else if (Length < 0x10000) {
            Output.Write((byte)(Code + JSONBCD.Length16));
            Output.Write((byte)((Length >> 8) & 0xff));
            Output.Write((byte)(Length & 0xff));
            }
        else if (Length < 0x100000000) {
            Output.Write((byte)(Code + JSONBCD.Length32));
            Output.Write((byte)((Length >> 24) & 0xff));
            Output.Write((byte)((Length >> 16) & 0xff));
            Output.Write((byte)((Length >> 8) & 0xff));
            Output.Write((byte)(Length & 0xff));
            }
        else {
            Output.Write((byte)(Code + JSONBCD.Length64));
            Output.Write((byte)((Length >> 56) & 0xff));
            Output.Write((byte)((Length >> 48) & 0xff));
            Output.Write((byte)((Length >> 40) & 0xff));
            Output.Write((byte)((Length >> 32) & 0xff));
            Output.Write((byte)((Length >> 24) & 0xff));
            Output.Write((byte)((Length >> 16) & 0xff));
            Output.Write((byte)((Length >> 8) & 0xff));
            Output.Write((byte)(Length & 0xff));
            }
        }

    /// <summary>Write integer.</summary>
    /// <param name="data">Value to write</param>
    protected void WriteInteger(long? data) {
        if (data is null) {
            Output.Write((byte)JSONBCD.Null);
            }
        else {
            var ddata = (long)data;
            if (data >= 0) {
                WriteTag(JSONBCD.PositiveInteger, ddata );
                }
            else {
                WriteTag(JSONBCD.NegativeInteger, -ddata);
                }
            }
        }

    /// <summary>
    /// Write Tag to the stream
    /// </summary>
    /// <param name="Tag">Tag text.</param>
    /// <param name="IndentIn">Current indent level.</param>
    public override void WriteToken(string Tag, int IndentIn) {
        WriteTag(JSONBCD.TagString, Tag.Length);
        Output.Write(Tag);
        }

    /// <summary>Write 32 bit integer.</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteInteger32(int? Data) => WriteInteger(Data);

    /// <summary>Write 64 bit integer.</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteInteger64(long? Data) => WriteInteger(Data);

    /// <summary>Write float32</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteFloat32(float Data) => Output.Write(Data.ToString());

    /// <summary>Write float64</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteFloat64(double Data) => Output.Write(Data.ToString());

    /// <summary>Write boolean.</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteBoolean(bool? Data) {
        if (Data == true) {
            Output.Write(JSONBCD.True);
            }
        else if (Data == false) {
            Output.Write(JSONBCD.False);
            }
        else {
            Output.Write(JSONBCD.Null);
            }
        }
    /// <summary>Write string without escaping.</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteString(string Data) {
        WriteTag(JSONBCD.StringTerm, Data.Length);
        Output.Write(Data);
        }


    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="buffer">Value to write</param>
    /// <param name="Stream">The output stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param> 
    public static void WriteBinary(Stream Stream, byte[] buffer, int offset = 0, int count = -1) {
        var Length = count < 0 ? buffer.Length : count;
        WriteTag(Stream, JSONBCD.DataTerm, Length);
        Stream.Write(buffer, offset, Length);
        }

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="buffer">Value to write</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param> 

    public override void WriteBinary(byte[] buffer, int offset = 0, int count = -1) {
        var Length = count < 0 ? buffer.Length : count;
        WriteTag(JSONBCD.DataTerm, Length);
        Output.Write(buffer);
        }

    long PartLength = 0;
    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="Length">The length of the chunk to be written.</param>
    /// <param name="Terminal">If true, this is the last chunk in a sequence.</param>
    public override void WriteBinaryBegin(long Length, bool Terminal = true) {
        WriteTag(Terminal ? JSONBCD.DataTerm : JSONBCD.DataChunk, Length);
        PartLength = Length;
        }

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="Data">Value to write</param>
    /// <param name="First">The index position of the first byte in the input data to process</param>
    /// <param name="Length">The number of bytes to process</param>
    public override void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1) {
        Length = Length < 0 ? Data.Length : Length;

        PartLength -= Length;
        Assert.AssertTrue(PartLength >= 0, BadPartLength.Throw);
        Output.Write(Data, (int)First, (int)Length);
        }


    /// <summary>Mark start of array element</summary>
    public override void WriteArrayStart() => Output.Write("[");

    /// <summary>Mark middle of array element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The value is set false on each call</param>
    public override void WriteArraySeparator(ref bool first) {
        }


    /// <summary>Mark end of array element</summary>
    public override void WriteArrayEnd() => Output.Write("]");

    /// <summary>Mark start of object element</summary>
    // Mark the start, middle and end of object elements
    public override void WriteObjectStart() => Output.Write("{");

    /// <summary>Mark middle of object element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The value is set false on each call</param>
    public override void WriteObjectSeparator(ref bool first) {
        }

    /// <summary>Mark end of object element</summary>
    public override void WriteObjectEnd() => Output.Write("}");
    }
