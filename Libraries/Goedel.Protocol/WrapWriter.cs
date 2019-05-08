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
using System.IO;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {

    /// <summary>
    /// Variant of the textwriter class that performs pretty print formatting on
    /// the output.
    /// </summary>
    public class WrapWriter : TextWriter {
        TextWriter Output;

        /// <summary>
        /// Construct a new WrapWriter.
        /// </summary>
        /// <param name="Output">Base textwriter stream to write output to.</param>
        public WrapWriter(TextWriter Output) => this.Output = Output;

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
            StringWriter StringWriter = new StringWriter ();
            WrapWriter WrapWriter = new WrapWriter (StringWriter);
            WrapWriter.Write (input);
            WrapWriter.Flush ();
            string result = StringWriter.ToString ();

            return result;
            }


        string Buffer = "";
        string BreakBuffer = "";
        string SpaceBuffer = "";
        string Leading = "";        
        
        /// <summary>
        /// Line count.
        /// </summary>
        public int Line = 1;

        /// <summary>
        /// Column count.
        /// </summary>
        public int Column => Leading.Length + Buffer.Length + SpaceBuffer.Length + BreakBuffer.Length;

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
        /// <param name="Disposing"></param>
        protected override void Dispose(bool Disposing) {
            if (Disposing) {
                Flush();
                }
            }

        /// <summary>
        /// Force write of all characters to the output.
        /// </summary>
        public override void Flush() {
            if ((Buffer != "") | (BreakBuffer != "" )) {
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
            Output.Write (Leading);
            Output.Write (Buffer);
            Output.Write (SpaceBuffer);
            Output.WriteLine (BreakBuffer);
            Line ++;
            Buffer = "";
            BreakBuffer = "";
            SpaceBuffer = "";
            Leading = "";
            state = 0;
            }

        void BreakLine() {
            string Minimum = MinLeading ; 

            Output.Write(Leading);
            if (Buffer != "") {
                Output.WriteLine(Buffer);
                Buffer = "";
                }
            else { // Line has no break point
                Output.WriteLine (BreakBuffer);
                BreakBuffer = "";
                Minimum += WrappedLeading;
                }
            Line++;
            SpaceBuffer = "";
            if (Leading.Length <= MinLeading.Length) {
                Leading = Minimum;
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
                    BreakBuffer += c;
                    state = 1;
                    return;
                    }
                }


            if (c == ' ') {
                switch (state) {
                    case 0:
                        Leading += c;
                        break;
                    case 1:
                        Buffer = Buffer + SpaceBuffer + BreakBuffer;
                        BreakBuffer = c.ToString ();
                        SpaceBuffer = " ";
                        state = 2;
                        break;
                    case 2:
                        SpaceBuffer += " ";
                        break;
                    case 3:
                        // Ignore surplus spaces afer break
                        break;
                    }
                }
            else {
                switch (state) {
                    case 0:
                        BreakBuffer = c.ToString ();
                        state = 1;
                        break;
                    case 1:
                        BreakBuffer += c;
                        break;
                    case 2:
                        BreakBuffer = c.ToString ();
                        state = 1;
                        break;
                    case 3:
                        BreakBuffer = c.ToString ();
                        state = 1;
                        break;
                    }
                }
            }

        /// <summary>
        /// Convert pending data to string.
        /// </summary>
        /// <returns>The string value</returns>
        public override string ToString() {
            Flush ();
            string result = Output.ToString ();
            return result;
            }
        }
    }
