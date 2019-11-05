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
using System.Text;

namespace Goedel.Utilities {

    /// <summary>
    /// Interface to binary stream converter.
    /// </summary>
    public interface IBytesToStream {

        /// <summary>
        /// Write a sequence of bytes to the stream
        /// </summary>
        /// <param name="data">The data to send</param>
        /// <param name="first">Position of first byte to send.</param>
        /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
        void Write(byte[] data, int first = 0, int length = -1);

        /// <summary>
        /// Complete sending bytes and reset converter to send more bytes.
        /// </summary>
        void Final();
        }

    /// <summary>
    /// Interface to binary stream converter.
    /// </summary>
    public interface IStringToStream {

        /// <summary>
        /// Write string to the stream
        /// </summary>
        /// <param name="data">The data to send</param>
        void Write(string data);

        /// <summary>
        /// Write character to the stream
        /// </summary>
        /// <param name="data">The data to send</param>
        void Write(char data);

        /// <summary>
        /// Complete input and reset converter for next session.
        /// </summary>
        void Final();
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

            MemoryStream stream;
            public byte[] ToArray;

            byte[] table;
            int bits;
            uint register;
            int stride;

            /// <summary>
            /// Constructore using conversion table <paramref name="table"/> with taking 
            /// <paramref name="stride"/> bits per character.
            /// </summary>
            /// <param name="table">The conversion table.</param>
            /// <param name="stride">The number of bits corresponding to each output character.</param>
            public StreamConvertString(byte[] table, int stride) {
                this.table = table;
                this.stride = stride;
                ToArray = null;
                stream = new MemoryStream();
                bits = 0;
                register = 0;
                }

            /// <summary>
            /// Transform the string <paramref name="data"/>.
            /// </summary>
            /// <param name="data">String to be transformed.</param>
            public void Write(string data) {
                foreach (var c in data) {
                    Write(c);
                    }
                }

            /// <summary>
            /// Transform the character <paramref name="c"/>.
            /// </summary>
            /// <param name="c">String to be transformed.</param>
            public void Write(char c) {
                if ((c < 128) && (table[c] < 64)) {
                    register = (register << stride) | table[c];
                    bits += stride;
                    if (bits >= 8) {
                        bits -= 8;
                        stream.WriteByte((Byte)(register >> bits));
                        }
                    }
                }

            /// <summary>
            /// Complete the transformation.
            /// </summary>
            public void Final() {
                ToArray = stream.ToArray();
                stream.SetLength(0);
                bits = 0;
                register = 0;
                }

            /// <summary>
            /// Create a StreamConvertString instance using conversion table <paramref name="table"/> in 
            /// which each character represents <paramref name="stride"/> bits and return the result
            /// of applying it to <paramref name="data"/>.
            /// </summary>
            /// <param name="table">The conversion table.</param>
            /// <param name="stride">The number of bits corresponding to each output character.</param>
            /// <param name="data">String to be transformed.</param>
            /// <returns>The result of the transformation</returns>
            public static byte[] Convert(byte[] table, int stride, string data) {
                if (data == null) {
                    return null;
                    }
                var Converter = new StreamConvertString(table, stride);
                Converter.Write(data);
                Converter.Final();
                return Converter.ToArray;

                }

            }

        /// <summary>
        /// Base class for byte streamed formatter
        /// </summary>
        private abstract class ByteStreamFormatter : IBytesToStream {
            delegate void FormatCharDelegate(char c);
            FormatCharDelegate formatChar;

            char[] table;
            int offset;
            bool terminal;
            int a;
            int bits;
            int dash;

            int outputCount = 0;
            int outputCol = 0;
            int outputMax;

            /// <summary>
            /// Converter from binary to text form.
            /// </summary>
            /// <param name="table">The conversion table.</param>
            /// <param name="bits">The number of bits per character.</param>
            /// <param name="format">The output conversion format to use.</param>
            /// <param name="outputCol">The initial output column</param>
            /// <param name="outputMax">If positive, wrap the output at the column value specified.
            /// Otherwise, do not wrap.</param>
            public ByteStreamFormatter(
                    char[] table,
                    int bits,
                    ConversionFormat format,
                    int outputCol = -1,
                    int outputMax = -1) {
                this.table = table;
                this.bits = bits;
                this.outputMax = outputMax;

                terminal = (format & ConversionFormat.Terminal) > 0;

                // Set the output method according to the format option selected.
                switch (format & (ConversionFormat)0xfe) {
                    case ConversionFormat.Draft: {
                        formatChar = FormatCharDraft;
                        this.outputMax = outputMax > 0 ? outputMax : 72;
                        this.outputCol = outputCol > 0 ? outputCol : 0;
                        break;
                        }
                    case ConversionFormat.Hex: {
                        formatChar = FormatCharHex;
                        break;
                        }
                    case ConversionFormat.Dash4: {
                        formatChar = FormatCharDash;
                        dash = 4;
                        break;
                        }
                    case ConversionFormat.Dash5: {
                        formatChar = FormatCharDash;
                        dash = 5;
                        break;
                        }
                    default: {
                        formatChar = FormatCharDirect;
                        break;
                        }
                    }

                offset = 0;
                a = 0;
                }


            bool NeedOutput => (outputMax < 0) | (outputCount < outputMax);

            /// <summary>
            /// Write the specified data to the converter instance.
            /// </summary>
            /// <param name="data">The data buffer to write.</param>
            /// <param name="first">The first byte to write from in the buffer.</param>
            /// <param name="length">The number of bytes to write from the buffer.</param>
            public void Write(byte[] data, int first = 0, int length = -1) {
                length = length < 0 ? data.Length - first : length;
                int Last = first + length;

                for (int i = first; (i < Last) & NeedOutput; i++) {
                    //if (Draft & ((i % 48) == 0)) {
                    //    WriteChar('\n');
                    //    }

                    a = (a << 8) | data[i];
                    offset += 8;

                    while ((offset >= bits) & NeedOutput) {
                        offset -= bits;

                        int n = a >> offset;
                        formatChar(table[n]);
                        a &= (0xff >> (8 - offset));
                        }
                    }
                }

            /// <summary>
            /// Complete writing from the buffer.
            /// </summary>
            public void Final() {
                if ((offset > 0) & NeedOutput) {
                    formatChar(table[a << (bits - offset)]);
                    // No trailing = characters in Base64URL encoding.
                    if (terminal) {
                        // The trailing characters are not always required by software but are
                        // required by the Base64 specification.
                        if (offset == 2) {
                            formatChar('='); // just one partial character
                            formatChar('=');
                            }
                        else {
                            formatChar('='); // One full, one partial character
                            }
                        }
                    offset = 0;
                    a = 0;
                    }
                }


            /// <summary>
            /// Format output character without format considerations.
            /// </summary>
            /// <param name="c">The character to format.</param>
            public void FormatCharDirect(char c) => WriteChar(c);

            /// <summary>
            /// Format output character with dash format.
            /// </summary>
            /// <param name="c">The character to format.</param>
            public void FormatCharDash(char c) {
                if (outputMax >= 0 & (outputCount >= outputMax)) {
                    return; // truncate output after n significant characters
                    }
                if (outputCount > 0 & outputCount % dash == 0) {
                    WriteChar('-');
                    }
                WriteChar(c);
                outputCount++;
                }

            /// <summary>
            /// Format output character with IETF plaintext draft format.
            /// </summary>
            /// <param name="c">The character to format.</param>
            public void FormatCharDraft(char c) {
                outputCol++;
                if (outputCol > outputMax) {
                    WriteChar('\n');
                    WriteChar(' ');
                    WriteChar(' ');
                    outputCol = 2;
                    }

                WriteChar(c);
                }

            /// <summary>
            /// Format hexadecimal character..
            /// </summary>
            /// <param name="c">The character to format.</param>
            public void FormatCharHex(char c) {
                if ((outputCount % 32) == 0) {
                    WriteChar('\n');
                    WriteChar(' ');
                    WriteChar(' ');
                    }
                else if ((outputCount % 8) == 0) {
                    WriteChar(' ');
                    WriteChar(' ');
                    }
                else if ((outputCount % 2) == 0) {
                    WriteChar(' ');
                    }

                outputCount++;
                WriteChar(c);
                }

            /// <summary>
            /// Write the character to the output stream.
            /// </summary>
            /// <param name="c">The character to write.</param>
            public abstract void WriteChar(char c);
            }


        /// <summary>
        /// General purpose converter used for every conversion to a stream except for Base32UDF.
        /// </summary>
        private class StreamConvertBits : ByteStreamFormatter {

            Stream output;

            /// <summary>
            /// Constructor for stream converter.
            /// </summary>
            /// <param name="output">The output stream.</param>
            /// <param name="table">The conversion table.</param>
            /// <param name="bits">The number of bits per character.</param>
            /// <param name="format">The output conversion format to use.</param>
            /// <param name="outputCol">The initial output column</param>
            /// <param name="outputMax">If positive, wrap the output at the column value specified.
            /// Otherwise, do not wrap.</param>
            public StreamConvertBits(
                    Stream output,
                    char[] table,
                    int bits,
                    ConversionFormat format,
                    int outputCol = -1,
                    int outputMax = -1) : base(table, bits, format, outputCol, outputMax) => this.output = output;

            public override void WriteChar(char c) => output.WriteByte((byte)c);
            }



        /// <summary>
        /// General purpose converter used for every conversion to a string except for Base32UDF.
        /// </summary>
        private class StringBuilderConvertBits : ByteStreamFormatter {

            StringBuilder output;

            /// <summary>
            /// Constructor for converter from binary to string form.
            /// </summary>
            /// <param name="output">The output string builder</param>
            /// <param name="table">The conversion table.</param>
            /// <param name="bits">The number of bits per character.</param>
            /// <param name="format">The output conversion format to use.</param>
            /// <param name="outputCol">The initial output column</param>
            /// <param name="outputMax">If positive, wrap the output at the column value specified.
            /// Otherwise, do not wrap.</param>
            public StringBuilderConvertBits(
                    StringBuilder output,
                    char[] table,
                    int bits,
                    ConversionFormat format,
                    int outputCol = -1,
                    int outputMax = -1) : base(table, bits, format, outputCol, outputMax) => this.output = output;

            /// <summary>
            /// One shot convenience wrapper, creates a converter, uses it to convert <paramref name="data"/>
            /// according to the parameters specified and returns the output. Is almost invariably called
            /// from another wrapper specifying <paramref name="table"/>, <paramref name="bits"/>, etc.
            /// </summary>
            /// <param name="data">The data to convert.</param>
            /// <param name="table">The conversion table.</param>
            /// <param name="bits">The number of bits per character.</param>
            /// <param name="format">The output conversion format to use.</param>
            /// <param name="first">Position of first byte to send.</param>
            /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
            /// <param name="outputCol">The initial output column</param>
            /// <param name="outputMax">If positive, wrap the output at the column value specified.
            /// Otherwise, do not wrap.</param>
            /// <returns></returns>
            public static string Convert(
                    byte[] data,
                    char[] table,
                    int bits,
                    ConversionFormat format,
                    int first = 0,
                    int length = -1,
                    int outputCol = -1,
                    int outputMax = -1) {

                var Output = new StringBuilder();
                var Converter = new StringBuilderConvertBits(Output, table, bits, format, outputCol, outputMax);
                Converter.Write(data, first, length);
                Converter.Final();
                return Output.ToString();
                }

            /// <summary>
            /// One shot convenience wrapper, creates a converter, uses it to convert <paramref name="data"/>
            /// according to the parameters specified appending the result to <paramref name="output"/>. 
            /// Is almost invariably called from another wrapper specifying <paramref name="table"/>, 
            /// <paramref name="bits"/>, etc.
            /// </summary>
            /// <param name="data">The data to convert.</param>
            /// <param name="table">The conversion table.</param>
            /// <param name="bits">The number of bits per character.</param>
            /// <param name="format">The output conversion format to use.</param>
            /// <param name="output"></param>
            /// <param name="first">Position of first byte to send.</param>
            /// <param name="length">Position of last byte to send. If less than zero, read to end.</param>
            /// <param name="outputCol">The initial output column</param>
            /// <param name="outputMax">If positive, wrap the output at the column value specified.
            /// Otherwise, do not wrap.</param>
            public static void Append(
                    byte[] data,
                    char[] table,
                    int bits,
                    ConversionFormat format,
                    StringBuilder output,
                    int first = 0,
                    int length = -1,
                    int outputCol = -1,
                    int outputMax = -1) {

                var Converter = new StringBuilderConvertBits(output, table, bits, format, outputCol, outputMax);
                Converter.Write(data, first, length);
                Converter.Final();
                }

            public override void WriteChar(char c) => output.Append(c);
            }
        }
    }
