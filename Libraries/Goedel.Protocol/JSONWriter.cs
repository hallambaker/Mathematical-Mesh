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
/// Factory delegate returning a JSONWriter
/// </summary>
/// <returns></returns>
public delegate JsonWriter JSONWriterFactoryDelegate();

/// <summary>
/// Base class for writers that format a JSON data object. This is usually
/// but not necessarily in JSON encoding. In a project that was required to
/// support XML and ASN.1 encodings, these could be implemented as
/// JSONWriter subclasses.
/// </summary>
public class JsonWriter : Writer {

    /// <summary>The conversion format to be used for Base64 Binary encoding.</summary>
    public static ConversionFormat ConversionFormat { get; set; } = ConversionFormat.Draft;

    /// <summary>The current indent level</summary>
    protected int Indent = 0;

    /// <summary>Write newline character</summary>
    protected virtual void NewLine() {
        Output.WriteLine();
        for (int i = 0; i < Indent; i++) {
            Output.Write("  ");
            }
        }


    /// <summary>
    /// Return the contents of the writer as a string.
    /// </summary>
    /// <returns>Current buffered contents as string</returns>
    public override string ToString() => Output.GetUTF8();


    /// <summary>
    /// Return the contents of the writer as a string.
    /// </summary>
    /// <returns>Current buffered contents as string</returns>
    public string GetUTF8 => (Output as MemoryStream)?.ToArray().ToUTF8();

    /// <summary>
    /// Create a new writer instance with the output <paramref name="output"/>. 
    /// If <paramref name="output"/> is null, a memory stream is created and
    /// used as the output.
    /// </summary>
    /// <param name="output">Output buffer</param> 
    public JsonWriter(Stream output = null) => Output = output ?? new MemoryStream();


    /// <summary>
    /// Create a new JSON Writer.
    /// </summary>
    public static JsonWriter JSONWriterFactory() => new();


    private int outputCol = 0;

    /// <summary>
    /// Write Tag to the stream
    /// </summary>
    /// <param name="tag">Tag text.</param>
    /// <param name="indentIn">Current indent level.</param>
    public override void WriteToken(string tag, int indentIn) {
        NewLine();
        Output.Write("\"");
        Output.Write(tag);
        Output.Write("\": ");

        outputCol = indentIn + 4 + tag.Length;
        }

    /// <summary>Write 32 bit integer.</summary>
    /// <param name="data">Value to write</param>
    public override void WriteInteger32(int data) => Output.Write(data.ToString());

    /// <summary>Write 64 bit integer</summary>
    /// <param name="data">Value to write</param>
    public override void WriteInteger64(long data) => Output.Write(data.ToString());

    /// <summary>Write float32</summary>
    /// <param name="data">Value to write</param>
    public override void WriteFloat32(float data) => Output.Write(data.ToString());

    /// <summary>Write float64</summary>
    /// <param name="data">Value to write</param>
    public override void WriteFloat64(double data) => Output.Write(data.ToString());

    /// <summary>Write boolean.</summary>
    /// <param name="data">Value to write</param>
    public override void WriteBoolean(bool data) {
        if (data) {
            Output.Write("true");
            }
        else {
            Output.Write("false");
            }
        }

    /// <summary>Write string.</summary>
    /// <param name="data">Value to write</param>
    public override void WriteString(string data) {
        Output.Write("\"");
        foreach (char c in data) {
            if (c == '\"') {
                Output.Write("\\\"");
                }
            else if (c == '\\') {
                Output.Write("\\\\");
                }
            else if (c >= 32) {
                Output.Write(c);
                }
            else if (c == '\b') {
                Output.Write("\\b");
                }
            else if (c == '\f') {
                Output.Write("\\f");
                }
            else if (c == '\n') {
                Output.Write("\\n");
                }
            else if (c == '\r') {
                Output.Write("\\r");
                }
            else {
                Int16 ic = (Int16)c;
                Output.Write(String.Format("\\u{0:X4}", ic));
                // convert to decimal
                }
            }
        Output.Write("\"");
        }



    /// <summary>Write binary data as Base64Url encoded string.</summary>
    /// <param name="buffer">Value to write</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param> 
    public override void WriteBinary(byte[] buffer, int offset = 0, int count = -1) {
        var Length = count < 0 ? buffer.Length : count;
        Output.Write("\"");
        Output.Write(BaseConvert.ToStringBase64url(buffer, offset, Length, ConversionFormat,
            outputCol: outputCol, outputMax: 63));
        Output.Write("\"");
        }

    /// <summary>Begin partial write of binary data. 
    /// This is not yet implemented for standard streams.</summary>
    public virtual void WriteBinaryBegin(long length, bool terminal = true) => throw new NYI();

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="data">Value to write</param>
    /// <param name="first">The index position of the first byte in the input data to process</param>
    /// <param name="length">The number of bytes to process</param>
    public virtual void WriteBinaryPart(byte[] data, long first = 0, long length = -1) => throw new NYI();


    /// <summary>Write Date-Time value in RFC3339 format.</summary>
    /// <param name="data">Value to write</param>
    public override void WriteDateTime(DateTime? data) {
        if (data != null) {
            Output.Write("\"");
            Output.Write((DateTime)data);
            Output.Write("\"");
            }
        else {
            Output.Write("null");
            }
        }

    /// <summary>Mark start of array element</summary>
    public override void WriteArrayStart() {
        Output.Write("[");
        Indent++;
        }

    /// <summary>Mark middle of array element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The value is set false on each call</param>
    public override void WriteArraySeparator(ref bool first) {
        if (!first) {
            Output.Write(",");
            NewLine();
            }
        first = false;
        }

    /// <summary>Mark end of array element</summary>
    public override void WriteArrayEnd() {
        Output.Write("]");
        Indent--;
        }

    /// <summary>Mark start of object element</summary>
    public override void WriteObjectStart() {
        Output.Write("{");
        Indent++;
        }

    /// <summary>Mark middle of object element</summary>
    /// <param name="first">If true, this is the first element. 
    /// The value is set false on each call</param>
    public override void WriteObjectSeparator(ref bool first) {
        if (!first) {
            Output.Write(",");
            }
        first = false;
        }

    /// <summary>Mark end of object element</summary>
    public override void WriteObjectEnd() {
        Output.Write("}");
        Indent--;
        }
    }
