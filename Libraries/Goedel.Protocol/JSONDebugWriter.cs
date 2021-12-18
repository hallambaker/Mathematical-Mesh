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
/// JSON Writer that presents data in a forat suitable for use in
/// documentation. All data is wrapped to fit a 72 character line.
/// Large data items are replaced with ellipsis, etc.
/// </summary>
public class JSONDebugWriter : JsonWriter {

    /// <summary>Threshold for redacting binary data blocks.</summary>
    static public int Threshold { get; set; } = 260;


    /// <summary>
    /// Create a new JSON Writer.
    /// </summary>
    public JSONDebugWriter() => this.Output = new MemoryStream();

    /// <summary>
    /// Create a new JSON Writer using the specified output buffer. If the buffer has
    /// an output stream defined, text will be written to the stream.
    /// </summary>
    /// <param name="Output">The output stream.</param>
    public JSONDebugWriter(MemoryStream Output) => this.Output = Output;


    int OutputCol = 0;


    /// <summary>Write newline character</summary>
    protected override void NewLine() {
        Output.WriteLine();
        OutputCol = 0;
        for (int i = 0; i < Indent; i++) {
            OutputCol += 2;
            Output.Write("  ");
            }
        }

    /// <summary>
    /// Write Tag to the stream
    /// </summary>
    /// <param name="Tag">Tag text.</param>
    /// <param name="IndentIn">Current indent level.</param>
    public override void WriteToken(string Tag, int IndentIn) {
        NewLine();
        var String = $"\"{Tag}\":";

        if (Tag == "ContentMetaData") {
            }

        Output.Write(String);
        OutputCol += String.Length;
        }

    /// <summary>Write string.</summary>
    /// <param name="Data">Value to write</param>
    public override void WriteString(string Data) {
        Output.Write("\"");
        foreach (char c in Data) {
            string conv = null;

            if (c == '\"') {
                conv = "\\\"";
                }
            else if (c == '\\') {
                conv = "\\\\";
                }
            else if (c >= 32 & c < 127) {
                conv = c.ToString();
                }
            else if (c == '\b') {
                conv = "\\b";
                }
            else if (c == '\f') {
                conv = "\\f";
                }
            else if (c == '\n') {
                conv = "\\n";
                }
            else if (c == '\r') {
                conv = "\\r";
                }
            else {
                Int16 ic = (Int16)c;
                conv = String.Format("\\u{0:X4}", ic);
                }

            if (conv.Length + OutputCol > 66) {
                Output.Write("\n");
                OutputCol = 0;
                }

            Output.Write(conv);
            OutputCol += conv.Length;
            }
        Output.Write("\"");
        }


    /// <summary>Write binary data as Base64Url encoded string.</summary>
    /// <param name="Data">Value to write</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="Data"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param> 
    public override void WriteBinary(byte[] Data, int offset = 0, int count = -1) {
        var Length = count < 0 ? Data.Length : count;

        Output.Write("\"");
        Output.Write(BaseConvert.ToStringBase64url(
                Data, offset, Length, format: ConversionFormat.Draft,
                outputCol: OutputCol + 2, outputMax: 66));

        Output.Write("\"");
        }

    /// <summary>
    /// Convert a JSONObject to redacted form.
    /// </summary>
    /// <param name="JSONObject">The object to convert</param>
    /// <param name="Tagged">If true, the object is wrapped with its type tag.</param>
    /// <returns>The input as a redacted JSON encoded string.</returns>
    public static string Write(JsonObject JSONObject, bool Tagged = true) {

        if (JSONObject == null) {
            return "$$$$ Empty $$$$";
            }

        var Buffer = new MemoryStream();
        var JSONWriter = new JSONDebugWriter(Buffer);
        JSONObject.Serialize(JSONWriter, Tagged);
        return Buffer.ToArray().ToUTF8();
        }

    /// <summary>Mark end of array element</summary>
    public override void WriteArrayEnd() {
        NewLine();
        Output.Write("]");
        Indent--;
        }

    }
