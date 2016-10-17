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

    


    public class JSONAWriter : JSONWriter {
        
        
        public override string ToString() {
            return Output.GetUTF8;
            }


        public JSONAWriter() {
            this.Output = new StreamBuffer ();
            }

        public JSONAWriter(StreamBuffer Output) {
            this.Output = Output;
            }

        public JSONAWriter(bool Wrap) {
            this.Output = new StreamBuffer ();
            }

        public override void WriteToken(string Tag, int IndentIn) {
            NewLine ();
            Output.Write("\"");
            Output.Write(Tag);
            Output.Write("\": ");
            }

        public override void WriteInteger32(int Data) {
            Output.Write(Data.ToString());
            }
        public override void WriteInteger64(long Data) {
            Output.Write(Data.ToString());
            }
        public override void WriteFloat32(float Data) {
            Output.Write(Data.ToString());
            }
        public override void WriteFloat64(double Data) {
            Output.Write(Data.ToString());
            }
        public override void WriteBoolean(bool Data) {
            if (Data) {
                Output.Write("true");
                }
            else {
                Output.Write("false");
                }
            }
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
        public override void WriteBinary(byte[] Data) {
            Output.Write("\"");
            Output.Write(BaseConvert.ToBase64urlString(Data));
            Output.Write("\"");
            }
        public override void WriteDateTime(DateTime Data) {
            Output.Write("\"");
            Output.Write(Data);
            Output.Write("\"");
            }

        // Mark the start, middle and end of array elements
        public override void WriteArrayStart() {
            Output.Write("[");
            Indent ++;
            }
        public override void WriteArraySeparator(ref bool first) {
            if (!first) {
                Output.Write(",");
                NewLine ();
                }
            first = false;
            }
        public override void WriteArrayEnd() {
            Output.Write("]");
            Indent --;
            }

        // Mark the start, middle and end of object elements
        public override void WriteObjectStart() {
            Output.Write("{");
            Indent ++;
            }
        public override void WriteObjectSeparator(ref bool first) {
            if (!first) {
                Output.Write(",");
                }
            first = false;
            }
        public override void WriteObjectEnd() {
            Output.Write("}");
            Indent --;
            }
        }
    }
