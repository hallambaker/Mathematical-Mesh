//Sample license text.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goedel.Protocol {
    //
    //  JSON Writer code
    //




    public class JSONCWriter : JSONBWriter {

        Dictionary<string, int> TagDictionary;

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




        public JSONCWriter(StreamBuffer Output) :
                this (Output, new Dictionary<string,int>()) {
            }

        public JSONCWriter() :
            this(new StreamBuffer(), new Dictionary<string, int>()) {
            }

        public JSONCWriter(Dictionary<string, int> TagDictionary) :
            this(new StreamBuffer(), TagDictionary) {
            }

        public JSONCWriter(bool Wrap) {
            this.Output = new StreamBuffer ();
            }

        public JSONCWriter(StreamBuffer Output, 
                    Dictionary<string, int> TagDictionary) {
            this.Output = Output;
            this.TagDictionary = TagDictionary;
            }


        public override void WriteToken(string Tag, int IndentIn) {
            WriteString(Tag);
            }

        public override void WriteString(string Data) {
            int Index;

            if (TagDictionary.TryGetValue(Data, out Index)) {
                WriteTag(JSONBCD.TagCode, Index);
                }
            else {
                WriteTag(JSONBCD.StringTerm, Data.Length);
                Output.Write(Data);
                }
            }

        }
    }
