using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goedel.Protocol {
    //
    //  JSON Writer code
    //

    


    public class JSONWriter : Writer {
        
        //private TextWriter Output;
        
        //private bool Buffered = false;


        //private StreamBuffer Output;


        private int Indent = 0;

        private void NewLine() {
            Output.WriteLine();
            for (int i = 0; i < Indent; i++) {
                Output.Write("  ");
                }
            }

        public override string ToString() {
            return Output.GetUTF8;
            }

        public string GetUTF8 { 
            get { return Output.GetUTF8; }}

        public JSONWriter() {
            this.Output = new StreamBuffer ();
            }

        public JSONWriter(StreamBuffer Output) {
            this.Output = Output;
            }

        public JSONWriter(bool Wrap) {
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
