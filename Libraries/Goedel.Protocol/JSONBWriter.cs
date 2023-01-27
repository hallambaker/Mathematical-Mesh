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

namespace Goedel.Protocol;

/// <summary>
/// JSON Writer for JSON-B, a superset of JSON encoding with codes that permit
/// efficient encoding of binary data and strings and encoding of floating point
/// values without loss of precision.
/// </summary>
public class JsonBWriter : JsonWriter {




    /// <summary>
    /// Create a new writer instance with the output <paramref name="output"/>. 
    /// If <paramref name="output"/> is null, a memory stream is created and
    /// used as the output.
    /// </summary>
    /// <param name="output">Output buffer</param> 
    public JsonBWriter(Stream output = null) => this.Output = output ?? new MemoryStream();


    /// <summary>
    /// Write out a Tag-Length values using the shortest possible production
    /// </summary>
    /// <param name="code">Base code.</param>
    /// <param name="length">Length of data to follow.</param>
    public void WriteTag(byte code, long length) => WriteTag(Output, code, length);


    /// <summary>
    /// Write out a Tag-Length values using the shortest possible production
    /// to <paramref name="output"/>.
    /// </summary>
    /// <param name="output">The output stream to write to.</param>
    /// <param name="code">Base code.</param>
    /// <param name="length">Length of data to follow.</param>
    public static void WriteTag(Stream output, byte code, long length) {
        if (length < 0x100) {
            output.Write((byte)(code + JSONBCD.Length8));
            output.Write((byte)(length & 0xff));
            }
        else if (length < 0x10000) {
            output.Write((byte)(code + JSONBCD.Length16));
            output.Write((byte)((length >> 8) & 0xff));
            output.Write((byte)(length & 0xff));
            }
        else if (length < 0x100000000) {
            output.Write((byte)(code + JSONBCD.Length32));
            output.Write((byte)((length >> 24) & 0xff));
            output.Write((byte)((length >> 16) & 0xff));
            output.Write((byte)((length >> 8) & 0xff));
            output.Write((byte)(length & 0xff));
            }
        else {
            output.Write((byte)(code + JSONBCD.Length64));
            output.Write((byte)((length >> 56) & 0xff));
            output.Write((byte)((length >> 48) & 0xff));
            output.Write((byte)((length >> 40) & 0xff));
            output.Write((byte)((length >> 32) & 0xff));
            output.Write((byte)((length >> 24) & 0xff));
            output.Write((byte)((length >> 16) & 0xff));
            output.Write((byte)((length >> 8) & 0xff));
            output.Write((byte)(length & 0xff));
            }
        }

    /// <summary>Write integer.</summary>
    /// <param name="data">Elements to write</param>
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
    /// <param name="tag">Tag text.</param>
    /// <param name="indentIn">Current indent level.</param>
    public override void WriteToken(string tag, int indentIn) {
        WriteTag(JSONBCD.TagString, tag.Length);
        Output.Write(tag);
        }

    /// <summary>Write 32 bit integer.</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteInteger32(int? data) => WriteInteger(data);

    /// <summary>Write 64 bit integer.</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteInteger64(long? data) => WriteInteger(data);

    /// <summary>Write float32</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteFloat32(float? data) => Output.Write(
            data == null ? "null" : data.ToString());

    /// <summary>Write float64</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteFloat64(double? data) => Output.Write(
            data == null ? "null" : data.ToString());

    /// <summary>Write boolean.</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteBoolean(bool? data) {
        if (data == true) {
            Output.Write(JSONBCD.True);
            }
        else if (data == false) {
            Output.Write(JSONBCD.False);
            }
        else {
            Output.Write(JSONBCD.Null);
            }
        }
    /// <summary>Write string without escaping.</summary>
    /// <param name="data">Elements to write</param>
    public override void WriteString(string data) {
        WriteTag(JSONBCD.StringTerm, data.Length);
        Output.Write(data);
        }


    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="buffer">Elements to write</param>
    /// <param name="stream">The output stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param> 
    public static void WriteBinary(Stream stream, byte[] buffer, int offset = 0, int count = -1) {
        var Length = count < 0 ? buffer.Length : count;
        WriteTag(stream, JSONBCD.DataTerm, Length);
        stream.Write(buffer, offset, Length);
        }

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="buffer">Elements to write</param>
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
    /// <param name="length">The length of the chunk to be written.</param>
    /// <param name="terminal">If true, this is the last chunk in a sequence.</param>
    public override void WriteBinaryBegin(long length, bool terminal = true) {
        WriteTag(terminal ? JSONBCD.DataTerm : JSONBCD.DataChunk, length);
        PartLength = length;
        }

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="data">Elements to write</param>
    /// <param name="first">The index position of the first byte in the input data to process</param>
    /// <param name="length">The number of bytes to process</param>
    public override void WriteBinaryPart(byte[] data, long first = 0, long length = -1) {
        length = length < 0 ? data.Length : length;

        PartLength -= length;
        Assert.AssertTrue(PartLength >= 0, BadPartLength.Throw);
        Output.Write(data, (int)first, (int)length);
        }


    /// <summary>Mark start of array element</summary>
    public override void WriteArrayStart() => Output.Write("[");

    /// <summary>Mark middle of array element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The values is set false on each call</param>
    public override void WriteArraySeparator(ref bool first) {
        }


    /// <summary>Mark end of array element</summary>
    public override void WriteArrayEnd() => Output.Write("]");

    /// <summary>Mark start of object element</summary>
    // Mark the start, middle and end of object elements
    public override void WriteObjectStart() => Output.Write("{");

    /// <summary>Mark middle of object element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The values is set false on each call</param>
    public override void WriteObjectSeparator(ref bool first) {
        }

    /// <summary>Mark end of object element</summary>
    public override void WriteObjectEnd() => Output.Write("}");
    }
