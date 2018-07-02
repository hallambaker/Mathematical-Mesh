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
using System.Text;
using System.IO;

namespace Goedel.Utilities  {

    /// <summary>
    /// Interface to binary stream converter.
    /// </summary>
    public interface IBytesToStream {

        /// <summary>
        /// Write a sequence of bytes to the stream
        /// </summary>
        /// <param name="Data">The data to send</param>
        /// <param name="First">Position of first byte to send.</param>
        /// <param name="Length">Position of last byte to send. If less than zero, read to end.</param>
        void Write (byte[] Data, int First = 0, int Length = -1);

        /// <summary>
        /// Complete sending bytes and reset converter to send more bytes.
        /// </summary>
        void Final ();
        }

    /// <summary>
    /// Interface to binary stream converter.
    /// </summary>
    public interface IStringToStream {

        /// <summary>
        /// Write string to the stream
        /// </summary>
        /// <param name="Data">The data to send</param>
        void Write (string Data);

        /// <summary>
        /// Write character to the stream
        /// </summary>
        /// <param name="Data">The data to send</param>
        void Write (char Data);

        /// <summary>
        /// Complete input and reset converter for next session.
        /// </summary>
        void Final ();
        }




    /// <summary>
    /// Routines to convert binary data to various character representations.
    /// Supported representations include Base16, Base32 and Base64 and common
    /// variations thereof.
    /// </summary>
    public static partial class BaseConvert {

        /// <summary>
        /// Conversion from character streams to bytes is straighforward since there
        /// is no formatting required of the target.
        /// </summary>
        private struct StreamConvertString : IStringToStream {

            MemoryStream Stream;
            public byte[] ToArray;

            byte[] Table;
            int Bits;
            uint Register;
            int Stride;

            public StreamConvertString (byte[] Table, int Stride) {
                this.Table = Table;
                this.Stride = Stride;
                ToArray = null;
                Stream = new MemoryStream();
                Bits = 0;
                Register = 0;
                }


            public void Write (string Data) {
                foreach (var c in Data) {
                    Write(c);
                    }
                }

            public void Write (char c) {
                if ((c < 128) && (Table[c] < 64)) {
                    Register = (Register << Stride) | Table[c];
                    Bits += Stride;
                    if (Bits >= 8) {
                        Bits -= 8;
                        Stream.WriteByte ((Byte)(Register >> Bits));
                        }
                    }
                }

            public void Final () {
                ToArray = Stream.ToArray();
                Stream.SetLength( 0);
                Bits = 0;
                Register = 0;
                }

            public static byte[] Convert (byte[] Table, int Stride, string Data) {

                var Converter = new StreamConvertString(Table, Stride);
                Converter.Write(Data);
                Converter.Final();
                return Converter.ToArray;

                }

            }

        /// <summary>
        /// Base class for byte streamed formatter
        /// </summary>
        private abstract class ByteStreamFormatter : IBytesToStream {
            delegate void FormatCharDelegate (char c);
            FormatCharDelegate FormatChar;

            char[] Table;
            int Offset;
            bool Terminal;
            int a;
            int Bits;
            int Dash;
            ConversionFormat Format;

            int OutputCount = 0;
            int OutputCol = 0;
            int OutputMax;

            //public ByteStreamFormatter (
            //        char[] Table,
            //        int Bits,
            //        bool Newline = false,
            //        bool Terminal = false) {
            //    this.Table = Table;
            //    this.Newline = Newline;
            //    this.Bits = Bits;
            //    this.Terminal = Terminal;
            //    Offset = 0;
            //    a = 0;
            //    }

            public ByteStreamFormatter (
                    char[] Table,
                    int Bits,
                    ConversionFormat Format,
                    int OutputCol = -1,
                    int OutputMax = -1) {
                this.Table = Table;
                this.Bits = Bits;
                this.Format = Format;
                this.OutputMax = OutputMax; 

                Terminal = (Format & ConversionFormat.Terminal) > 0;

                // Set the output method according to the format option selected.
                switch (Format & (ConversionFormat)0xfe) {
                    case ConversionFormat.Draft:  {
                            FormatChar = FormatCharDraft;
                            this.OutputMax = OutputMax > 0 ? OutputMax : 72;
                            this.OutputCol = OutputCol > 0 ? OutputCol : 0;
                            break;
                            }
                    case ConversionFormat.Hex: {
                            FormatChar = FormatCharHex;
                            break;
                            }
                    case ConversionFormat.Dash6: {
                            FormatChar = FormatCharDash;
                            Dash = 6;
                            break;
                            }
                    case ConversionFormat.Dash5: {
                            FormatChar = FormatCharDash;
                            Dash = 5;
                            break;
                            }
                    default: {
                            FormatChar = FormatCharDirect;
                            break;
                            }
                    }

                Offset = 0;
                a = 0;
                }


            public void Write (byte[] Data, int First = 0, int Length = -1) {
                Length = Length < 0 ? Data.Length - First : Length;
                int Last = First + Length;

                for (int i = First; i < Last; i++) {
                    //if (Draft & ((i % 48) == 0)) {
                    //    WriteChar('\n');
                    //    }

                    a = (a << 8) | Data[i];
                    Offset += 8;

                    while (Offset >= Bits) {
                        Offset -= Bits;

                        int n = a >> Offset;
                        FormatChar(Table[n]);
                        a = a & (0xff >> (8 - Offset));
                        }
                    }
                }

            public void Final () {
                if (Offset > 0) {
                    FormatChar(Table[a << (Bits - Offset)]);
                    // No trailing = characters in Base64URL encoding.
                    if (Terminal) {
                        // The trailing characters are not always required by software but are
                        // required by the Base64 specification.
                        if (Offset == 2) {
                            FormatChar('='); // just one partial character
                            FormatChar('=');
                            }
                        else {
                            FormatChar('='); // One full, one partial character
                            }
                        }
                    Offset = 0;
                    a = 0;
                    }
                }



            public void FormatCharDirect (char c) {
                WriteChar(c);
                }

            public void FormatCharDash (char c) {
                if (OutputMax >= 0 & (OutputCount >= OutputMax)) {
                    return; // truncate output after n significant characters
                    }
                if (OutputCount > 0 & OutputCount % Dash == 0) {
                    WriteChar('-');
                    }
                WriteChar(c);
                OutputCount++;
                }

            
            public void FormatCharDraft (char c) {
                OutputCol++;
                if (OutputCol > OutputMax) {
                    WriteChar('\n');
                    WriteChar(' ');
                    WriteChar(' ');
                    OutputCol = 2;
                    }

                WriteChar(c);
                }

            public void FormatCharHex (char c) {
                if ((OutputCount % 32) == 0) {
                    WriteChar('\n');
                    WriteChar(' ');
                    WriteChar(' ');
                    }
                else if ((OutputCount % 8) == 0) {
                    WriteChar(' ');
                    WriteChar(' ');
                    }
                else if ((OutputCount % 2) == 0) {
                    WriteChar(' ');
                    }

                OutputCount++;
                WriteChar(c);
                }

            public abstract void WriteChar (char c);
            }


        /// <summary>
        /// General purpose converter used for every conversion to a stream except for Base32UDF.
        /// </summary>
        private class StreamConvertBits : ByteStreamFormatter {

            Stream Output;

            //public StreamConvertBits (
            //        Stream Output, 
            //        char[] Table, 
            //        int Bits,
            //        bool Newline = false,
            //        bool Terminal = false) : base (Table, Bits, Newline, Terminal) {
            //    this.Output = Output;
            //    }

            public StreamConvertBits (
                    Stream Output,
                    char[] Table,
                    int Bits,
                    ConversionFormat Format,
                    int OutputCol = -1,
                    int OutputMax = -1) : base(Table, Bits, Format, OutputCol, OutputMax) {
                this.Output = Output;
                }

            public override void WriteChar (char c) {
                Output.WriteByte((byte)c);
                }
            }



        /// <summary>
        /// General purpose converter used for every conversion to a string except for Base32UDF.
        /// </summary>
        private class StringBuilderConvertBits : ByteStreamFormatter {

            StringBuilder Output;

            //public StringBuilderConvertBits (
            //        StringBuilder Output,
            //        char[] Table,
            //        int Bits,
            //        bool Newline = false,
            //        bool Terminal = false) : base(Table, Bits, Newline, Terminal) {
            //    this.Output = Output;
            //    }

            public StringBuilderConvertBits (
                    StringBuilder Output,
                    char[] Table,
                    int Bits,
                    ConversionFormat Format,
                    int OutputCol = -1,
                    int OutputMax = -1) : base(Table, Bits, Format, OutputCol, OutputMax) {
                this.Output = Output;
                }

            public static string Convert (
                    char[] Table,
                    int Bits,
                    ConversionFormat Format, byte[] Data = null, int First = 0,
                    int Length = -1,
                    int OutputCol = -1,
                    int OutputMax = -1) {

                var Output = new StringBuilder();
                var Converter = new StringBuilderConvertBits(Output, Table, Bits, Format, OutputCol, OutputMax);
                Converter.Write(Data, First, Length);
                Converter.Final();
                return Output.ToString();
                }

            public static void Append (
                    StringBuilder Output,
                    char[] Table,
                    int Bits,
                    ConversionFormat Format, byte[] Data = null, int First = 0,
                    int Length = -1,
                    int OutputCol = -1,
                    int OutputMax = -1) {

                var Converter = new StringBuilderConvertBits(Output, Table, Bits, Format, OutputCol, OutputMax);
                Converter.Write(Data, First, Length);
                Converter.Final();
                }

            public override void WriteChar (char c) {
                Output.Append(c);
                }
            }
        }
    }
