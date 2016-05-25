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

namespace Goedel.Protocol {
    //
    //  JSON Writer code
    //




    public class JSONCWriter : JSONBWriter {

        Dictionary<string, int> TagDictionary;

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
