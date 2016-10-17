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
    //
    //  JSON Writer code
    //

    public class JSONDebugWriter : JSONWriter {

        static public int Threshold = 260;

        public JSONDebugWriter() {
            this.Output = new StreamBuffer ();
            }

        public JSONDebugWriter(StreamBuffer Output) {
            this.Output = Output;
            }

        public JSONDebugWriter(bool Wrap) {
            this.Output = new StreamBuffer ();
            }

        public override void WriteBinary(byte[] Data) {
            Output.Write("\"");
            if (Data.Length < Threshold) {
                Output.Write(BaseConvert.ToBase64urlString(Data));
                }
            else {
                Output.Write(BaseConvert.ToBase64urlString(Data,0,96,true));
                Output.Write("\n...");
                int Start = 48 * (Data.Length / 48);
                // If the last line is null, make it a full line.
                Start = (Data.Length % 48) == 0 ? Start - 48 : Start;
                int Length = Data.Length - Start;
                Output.Write(BaseConvert.ToBase64urlString(Data, Start, Length, true));
                }
            Output.Write("\"");
            Output.Write("\n");
            }


        public static string Write(JSONObject JSONObject) {
            var Buffer = new StreamBuffer();
            var JSONWriter = new JSONDebugWriter(Buffer);
            JSONObject.Serialize(JSONWriter, true);
            return JSONWriter.GetUTF8;
            }

        }
    }
