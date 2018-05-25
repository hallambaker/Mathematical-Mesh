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



    /// <summary>
    /// JSON Writer for JSON-C, which extends the JSON-B format to add support 
    /// for compression.
    /// </summary>
    public class JSONCWriter : JSONBWriter {

        Dictionary<string, int> TagDictionary;



        /// <summary>
        /// Create a new JSON Writer using the specified output buffer. If the buffer has
        /// an output stream defined, text will be written to the stream.
        /// </summary>
        /// <param name="Output">Output buffer</param>
        /// <param name="TagDictionary">Tag dictionary to ues for compression</param>
        public JSONCWriter(MemoryStream Output = null, 
                    Dictionary<string, int> TagDictionary = null) {
            this.Output = Output  ?? new MemoryStream();
            this.TagDictionary = TagDictionary ?? new Dictionary<string, int>();
            }

        /// <summary>
        /// Write Tag to the stream
        /// </summary>
        /// <param name="Tag">Tag text.</param>
        /// <param name="IndentIn">Current indent level.</param>
        public override void WriteToken(string Tag, int IndentIn) {
            WriteString(Tag);
            }

        /// <summary>Write string.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteString(string Data) {

            if (TagDictionary.TryGetValue(Data, out var Index)) {
                WriteTag(JSONBCD.TagCode, Index);
                }
            else {
                WriteTag(JSONBCD.StringTerm, Data.Length);
                Output.Write(Data);
                }
            }

        }
    }
