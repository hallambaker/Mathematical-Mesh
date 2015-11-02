using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public class WrapWriter : TextWriter {
        TextWriter Output;

        public WrapWriter(TextWriter _Output) {
            Output = _Output;
            }

        //
        // The following declarations override the base class to 
        // pass methods through to the output stream
        //


        static public string Wrap(string input) { 
            StringWriter StringWriter = new StringWriter ();
            WrapWriter WrapWriter = new WrapWriter (StringWriter);
            WrapWriter.Write (input);
            WrapWriter.Close ();
            string result = StringWriter.ToString ();

            return result;
            }


        string Buffer = "";
        string BreakBuffer = "";
        string SpaceBuffer = "";
        string Leading = "";        
        
        public int Line = 1;
        public int Column {
            get { return Leading.Length + Buffer.Length + 
                SpaceBuffer.Length + BreakBuffer.Length;}
            }
        public int Width = 64;


        public string BreakAt = " ,[{(";
        public string MinLeading = "  ";
        public string WrappedLeading = "";


        int state = 0;

        public override Encoding Encoding { get {return  System.Text.Encoding.UTF8;} }
        public override void Close() { 
            Flush ();
            Output.Close(); 
            }

        public override void Flush() {
            if ((Buffer != "") | (BreakBuffer != "" )) {
                EndLine();
                }
            Output.Flush();
            }

        //
        // Redirect all character methods to our new writer
        //
        public override void Write(char[] buffer) {
            foreach (char c in buffer) {
                Write(c);
                }
            }
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
                Minimum = Minimum + WrappedLeading;
                }
            Line++;
            SpaceBuffer = "";
            if (Leading.Length <= MinLeading.Length) {
                Leading = Minimum;
                }
            }

        public int TabStop = 4;

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
                    BreakBuffer = BreakBuffer + c;
                    state = 1;
                    return;
                    }
                }


            if (c == ' ') {
                switch (state) {
                    case 0:
                        Leading = Leading + c;
                        break;
                    case 1:
                        Buffer = Buffer + SpaceBuffer + BreakBuffer;
                        BreakBuffer = c.ToString ();
                        SpaceBuffer = " ";
                        state = 2;
                        break;
                    case 2:
                        SpaceBuffer = SpaceBuffer + " ";
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
                        BreakBuffer = BreakBuffer + c;
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

        public override string ToString() {
            Flush ();
            string result = Output.ToString ();


            return result;
            }
        }
    }
