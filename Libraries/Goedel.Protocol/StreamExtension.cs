#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;
using System.IO;

using Goedel.Utilities;

namespace Goedel.Protocol;

/// <summary>
/// Extension methods for streams to output common data types.
/// </summary>
public static class StreamExtension {

    /// <summary>
    /// Convert the contents of a memory stream buffer containing UTF8 data to a string.
    /// </summary>
    /// <param name="Stream">The memory stream object</param>
    /// <returns>The output data.</returns>
    public static string GetUTF8(this MemoryStream Stream) => Stream.ToArray().ToUTF8();

    /// <summary>
    /// Convert the contents of a memory stream buffer containing UTF8 data to a string.
    /// </summary>
    /// <param name="Stream">The memory stream object</param>
    /// <returns>The output data.</returns>
    public static string GetUTF8(this Stream Stream) {
        var Memory = new MemoryStream();
        Stream.CopyTo(Memory);
        return Memory.ToArray().ToUTF8();
        }


    /// <summary>
    /// Write a single byte to the output stream
    /// </summary>
    /// <param name="Output">The stream to write the output to</param>
    /// <param name="b">The data to write</param>
    public static void Write(this Stream Output, byte b) {
        var buffer = new byte[] { b };
        Output.Write(buffer, 0, 1);
        }

    ///// <summary>Write buffer to to the output stream</summary>
    ///// <param name="Output">The stream to write the output to</param>
    ///// <param name="buffer">Data to write</param>
    //public static void Write(this Stream Output, byte[] buffer) => Output.Write(buffer, 0, buffer.Length);

    /// <summary>Write buffer to to the output stream</summary>
    /// <param name="Output">The stream to write the output to</param>
    /// <param name="buffer">Data to write</param>
    /// <param name="Start">Index of first byte to write</param>
    /// <param name="Count">Number of bytes to write.</param>
    public static void Write(this Stream Output, byte[] buffer, int Start, int Count) => Output.Write(buffer, Start, Count);


    /// <summary>
    /// Write character
    /// </summary>
    /// <param name="Output">The stream to write the output to</param>
    /// <param name="c">Character to write</param>
    public static void Write(this Stream Output, char c) {
        if (c < 0x80) {
            Output.Write((byte)c);
            return;
            }
        if (c < 0x0800) {
            Output.Write((byte)(0xC0 | (c >> 6)));
            Output.Write((byte)(0x80 | (c & 0x3f)));
            return;
            }
        if ((c < 0xD800) | (c > 0xDFFF)) {

            Output.Write((byte)(0xE0 | (c >> 12)));
            Output.Write((byte)(0x80 | ((c >> 6) & 0x3f)));
            Output.Write((byte)(0x80 | (c & 0x3f)));

            return;
            }
        if ((c > 0xDC00) & (c <= 0xDFFF)) {
            throw new InvalidInput("Invalid character sequence");
            }
        else {
            throw new InvalidInput("Not Implemented");

            //WriteCached = true;
            //WriteCache = c;
            }

        //if (!WriteCached) {

        //    }
        //else {
        //    throw new Exception("Not Implemented");
        //    }

        }

    /// <summary>Write newline</summary>
    /// <param name="Output">The stream to write the output to</param>
    public static void WriteLine(this Stream Output) => Output.Write('\n');

    /// <summary>Write string</summary>
    /// <param name="Output">The stream to write the output to</param>
    /// <param name="s">Data to write</param>
    public static void Write(this Stream Output, string s) => Output.Write(s.ToUTF8());//foreach (char c in s) {//    Output.Write(c);//    }

    /// <summary>Write out the Date Time as a string in RFC3339 Format</summary>
    /// <param name="Output">The stream to write the output to</param>
    /// <param name="Data">Data to write</param>
    public static void Write(this Stream Output, DateTime Data) => Output.Write(Data.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
    }
