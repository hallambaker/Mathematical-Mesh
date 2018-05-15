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
    /// JSON Writer that presents data in a forat suitable for use in
    /// documentation. All data is wrapped to fit a 72 character line.
    /// Large data items are replaced with ellipsis, etc.
    /// </summary>
    public class JSONDebugWriter : JSONWriter {

        /// <summary>Threshold for redacting binary data blocks.</summary>
        static public int Threshold = 260;


        /// <summary>
        /// Create a new JSON Writer.
        /// </summary>
        public JSONDebugWriter() {
            this.Output = new MemoryStream();
            }

        /// <summary>
        /// Create a new JSON Writer using the specified output buffer. If the buffer has
        /// an output stream defined, text will be written to the stream.
        /// </summary>
        /// <param name="Output">The output stream.</param>
        public JSONDebugWriter(MemoryStream Output) {
            this.Output = Output;
            }


        /// <summary>Write binary data as Base64Url encoded string.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteBinary(byte[] Data) {
            Output.Write("\"");
            if (Data.Length < Threshold) {
                Output.Write(BaseConvert.ToStringBase64url(Data, Format: ConversionFormat.Draft));
                }
            else {
                Output.Write(BaseConvert.ToStringBase64url(Data,0,96, Format:ConversionFormat.Draft));
                Output.Write("\n...");
                int Start = 48 * (Data.Length / 48);
                // If the last line is null, make it a full line.
                Start = (Data.Length % 48) == 0 ? Start - 48 : Start;
                int Length = Data.Length - Start;
                Output.Write(BaseConvert.ToStringBase64url(Data, Start, Length, Format: ConversionFormat.Draft));
                }
            Output.Write("\"");
            Output.Write("\n");
            }

        /// <summary>
        /// Convert a JSONObject to redacted form.
        /// </summary>
        /// <param name="JSONObject">The object to convert</param>
        /// <returns>The input as a redacted JSON encoded string.</returns>
        public static string Write(JSONObject JSONObject) {

            if (JSONObject == null) {
                return "$$$$ Empty $$$$";
                }

            var Buffer = new MemoryStream();
            var JSONWriter = new JSONDebugWriter(Buffer);
            JSONObject.Serialize(JSONWriter, true);
            return Buffer.ToArray().ToUTF8();
            }

        }
    }
