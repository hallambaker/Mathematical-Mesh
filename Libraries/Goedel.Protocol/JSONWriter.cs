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
using System.IO;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Protocol {
  

    /// <summary>
    /// Base class for writers that format a JSON data object. This is usually
    /// but not necessarily in JSON encoding. In a project that was required to
    /// support XML and ASN.1 encodings, these could be implemented as
    /// JSONWriter subclasses.
    /// </summary>
    public class JSONWriter : Writer {
        
        /// <summary>The current indent level</summary>
        protected int Indent = 0;

        /// <summary>Write newline character</summary>
        protected void NewLine() {
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
        public string GetUTF8  => (Output as MemoryStream)?.ToArray().ToUTF8() ;

        /// <summary>
        /// Create a new JSON Writer.
        /// </summary>
        public JSONWriter() => Output = new MemoryStream();

        /// <summary>
        /// Create a new JSON Writer using the specified output buffer. If the buffer has
        /// an output stream defined, text will be written to the stream.
        /// </summary>
        /// <param name="Output">The output stream.</param>
        public JSONWriter(Stream Output) => this.Output = Output;


        /// <summary>
        /// Write Tag to the stream
        /// </summary>
        /// <param name="Tag">Tag text.</param>
        /// <param name="IndentIn">Current indent level.</param>
        public override void WriteToken(string Tag, int IndentIn) {
            NewLine ();
            Output.Write("\"");
            Output.Write(Tag);
            Output.Write("\": ");
            }

        /// <summary>Write 32 bit integer.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteInteger32(int Data) => Output.Write(Data.ToString());

        /// <summary>Write 64 bit integer</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteInteger64(long Data) => Output.Write(Data.ToString());

        /// <summary>Write float32</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteFloat32(float Data) => Output.Write(Data.ToString());

        /// <summary>Write float64</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteFloat64(double Data) => Output.Write(Data.ToString());

        /// <summary>Write boolean.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteBoolean(bool Data) {
            if (Data) {
                Output.Write("true");
                }
            else {
                Output.Write("false");
                }
            }

        /// <summary>Write string.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteString(string Data) {
            Output.Write("\"");
            foreach (char c in Data) {
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
        /// <param name="Data">Value to write</param>
        public override void WriteBinary(byte[] Data) {
            Output.Write("\"");
            Output.Write(BaseConvert.ToStringBase64url(Data));
            Output.Write("\"");
            }

        /// <summary>Begin partial write of binary data. 
        /// This is not yet implemented for standard streams.</summary>
        public virtual void WriteBinaryBegin(long Length, bool Terminal = true) => throw new NYI();

        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="Data">Value to write</param>
        /// <param name="First">The index position of the first byte in the input data to process</param>
        /// <param name="Length">The number of bytes to process</param>
        public virtual void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1) => throw new NYI();


        /// <summary>Write Date-Time value in RFC3339 format.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteDateTime(DateTime? Data) {
            if (Data != null) {
                Output.Write("\"");
                Output.Write((DateTime)Data);
                Output.Write("\"");
                }
            else {
                Output.Write("null");
                }
            }

        /// <summary>Mark start of array element</summary>
        public override void WriteArrayStart() {
            Output.Write("[");
            Indent ++;
            }

        /// <summary>Mark middle of array element</summary>
        /// <param name="first">If true, this is the first element. 
        /// The value is set false on each call</param>
        public override void WriteArraySeparator(ref bool first) {
            if (!first) {
                Output.Write(",");
                NewLine ();
                }
            first = false;
            }

        /// <summary>Mark end of array element</summary>
        public override void WriteArrayEnd() {
            Output.Write("]");
            Indent --;
            }

        /// <summary>Mark start of object element</summary>
        public override void WriteObjectStart() {
            Output.Write("{");
            Indent ++;
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
            Indent --;
            }
        }
    }
