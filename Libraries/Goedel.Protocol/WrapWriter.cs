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

using System.IO;

namespace Goedel.Protocol {

    /// <summary>
    /// Variant of the textwriter class that performs pretty print formatting on
    /// the output.
    /// </summary>
    public class WrapWriter : TextWriter {
        TextWriter Output { get; set; }

        /// <summary>
        /// Construct a new WrapWriter.
        /// </summary>
        /// <param name="output">Base textwriter stream to write output to.</param>
        public WrapWriter(TextWriter output) => Output = output;

        //
        // The following declarations override the base class to 
        // pass methods through to the output stream
        //

        /// <summary>
        /// Wrap the input string, inserting linebreaks where necessary.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The wrapped output string</returns>
        static public string Wrap(string input) {
            var StringWriter = new StringWriter();
            using var WrapWriter = new WrapWriter(StringWriter);
            WrapWriter.Write(input);
            WrapWriter.Flush();
            string result = StringWriter.ToString();

            return result;
            }


        string buffer = "";
        string breakBuffer = "";
        string spaceBuffer = "";
        string leading = "";

        /// <summary>
        /// Line count.
        /// </summary>
        public int Line = 1;

        /// <summary>
        /// Column count.
        /// </summary>
        public int Column => leading.Length + buffer.Length + spaceBuffer.Length + breakBuffer.Length;

        /// <summary>
        /// Column width.
        /// </summary>
        public int Width = 64;

        /// <summary>
        /// Set of valid break points in addition to white space.
        /// </summary>
        public string BreakAt = " ,[{(";

        /// <summary>
        /// Leading space to be added to every line.
        /// </summary>
        public string MinLeading = "  ";

        /// <summary>
        /// Additional leading space to add on wrapped lines.
        /// </summary>
        public string WrappedLeading = "";


        int state = 0;

        /// <summary>
        /// The output charater encoding.
        /// </summary>
        public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;

        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                Flush();
                }
            }

        /// <summary>
        /// Force write of all characters to the output.
        /// </summary>
        public override void Flush() {
            if ((buffer != "") | (breakBuffer != "")) {
                EndLine();
                }
            Output.Flush();
            }

        //
        // Redirect all character methods to our new writer
        //

        /// <summary>
        /// Write buffer to the output.
        /// </summary>
        /// <param name="buffer">data to write.</param>
        public override void Write(char[] buffer) {
            foreach (char c in buffer) {
                Write(c);
                }
            }

        /// <summary>
        /// Write string to the output.
        /// </summary>
        /// <param name="value">Data to write.</param>
        public override void Write(string value) {
            foreach (char c in value) {
                Write(c);
                }
            }

        //
        // The new writer with intelligent line wrapping capability
        //

        void EndLine() {
            Output.Write(leading);
            Output.Write(buffer);
            Output.Write(spaceBuffer);
            Output.WriteLine(breakBuffer);
            Line++;
            buffer = "";
            breakBuffer = "";
            spaceBuffer = "";
            leading = "";
            state = 0;
            }

        void BreakLine() {
            string Minimum = MinLeading;

            Output.Write(leading);
            if (buffer != "") {
                Output.WriteLine(buffer);
                buffer = "";
                }
            else { // Line has no break point
                Output.WriteLine(breakBuffer);
                breakBuffer = "";
                Minimum += WrappedLeading;
                }
            Line++;
            spaceBuffer = "";
            if (leading.Length <= MinLeading.Length) {
                leading = Minimum;
                }
            }

        /// <summary>
        /// Number of spaces per tab stop.
        /// </summary>
        public int TabStop = 4;

        /// <summary>
        /// Write character to output stream.
        /// </summary>
        /// <param name="c">Character to write</param>
        public override void Write(char c) {
            if (c == '\t') {
                int Spaces = TabStop * ((Column + TabStop - 1) / TabStop) - Column;
                for (int i = 0; i < Spaces; i++) {
                    Write(' ');
                    }
                return;
                }

            if (c == '\n') {
                EndLine();
                return;
                }
            if (c == '\r') {
                return;
                }


            //if ((Buffer.Length > Width) | (BreakBuffer.Length > Width)){ 
            //    Console.WriteLine ("oopsy");
            //    }

            if (Column > Width) {
                BreakLine();
                if (c == ' ') {
                    state = 3;
                    return;
                    }
                else {
                    breakBuffer += c;
                    state = 1;
                    return;
                    }
                }


            if (c == ' ') {
                switch (state) {
                    case 0:
                        leading += c;
                        break;
                    case 1:
                        buffer = buffer + spaceBuffer + breakBuffer;
                        breakBuffer = c.ToString();
                        spaceBuffer = " ";
                        state = 2;
                        break;
                    case 2:
                        spaceBuffer += " ";
                        break;
                    case 3:
                        // Ignore surplus spaces afer break
                        break;
                    default:
                        break;
                    }
                }
            else {
                switch (state) {
                    case 0:
                        breakBuffer = c.ToString();
                        state = 1;
                        break;
                    case 1:
                        breakBuffer += c;
                        break;
                    case 2:
                        breakBuffer = c.ToString();
                        state = 1;
                        break;
                    case 3:
                        breakBuffer = c.ToString();
                        state = 1;
                        break;
                    default:
                        break;
                    }
                }
            }

        /// <summary>
        /// Convert pending data to string.
        /// </summary>
        /// <returns>The string value</returns>
        public override string ToString() {
            Flush();
            string result = Output.ToString();
            return result;
            }
        }
    }
