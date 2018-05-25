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
using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// Abstract JSON object deserializer
    /// </summary>
    public abstract class Reader {


        ///// <summary>Input stream</summary>
        //protected CharacterStream InputCS;

        ///// <summary>Get next character without advancing stream</summary>
        ///// <returns>The next character in the stream</returns> 
        //protected char LookNext() => InputCS.LookNext();

        ///// <summary>Get next character and advance stream</summary>
        ///// <returns>The character received</returns>
        //protected char GetNext() => InputCS.GetNext();

        ///// <summary>If true, end of file has been reached</summary>
        //protected bool EOF => InputCS.EOF;

        ///// <summary>Set the input reader</summary>
        ///// <param name="InputIn">Input source</param>
        //protected void SetReader(TextReader InputIn) => InputCS = new TextCharacterTextStream(InputIn);

        ///// <summary>Set the input reader</summary>
        ///// <param name="InputIn">Input source</param>
        //protected void SetReader(string InputIn) {
        //    InputCS = new StringCharacterStream(InputIn);
        //    }

        ///// <summary>Default constructor</summary>
        //public Reader() {
        //    }

        ///// <summary>Constructor from string source</summary>
        ///// <param name="BufferIn">Input source</param>
        //public Reader(string BufferIn) => SetReader(BufferIn);

        ///// <summary>Constructor from stream source</summary>
        ///// <param name="InputIn">Input source</param>
        //public Reader(TextReader InputIn) => SetReader(InputIn);

        /// <summary>Get start of object</summary>
        /// <returns>True if start of object found</returns>
        abstract public bool StartObject();
        
        /// <summary>Get end of object</summary>
        abstract public void EndObject();

        /// <summary>Get next object</summary>
        /// <returns>Value read</returns>
        abstract public bool NextObject();

        /// <summary>Read token</summary>
        /// <returns>Value read</returns>
        abstract public string ReadToken();

        /// <summary>Read Integer32</summary>
        /// <returns>Value read</returns>
        abstract public int ReadInteger32();

        /// <summary>Read Integer64</summary>
        /// <returns>Value read</returns>
        abstract public long ReadInteger64();

        /// <summary>Read boolen value</summary>
        /// <returns>Value read</returns>
        abstract public bool ReadBoolean();

        /// <summary>Read binary date</summary>
        /// <returns>Value read</returns>
        abstract public byte[] ReadBinary();

        /// <summary>
        /// Attempt to read a binary object in incremental mode.
        /// </summary>
        /// <param name="Chunk">The data read.</param>
        /// <returns>True if there is more data to be read</returns>
        abstract public bool ReadBinaryIncremental (out byte[] Chunk);

        /// <summary>Read string</summary>
        /// <returns>Value read</returns>
        abstract public string ReadString();

        /// <summary>Read date time item</summary>
        /// <returns>Value read</returns>
        abstract public DateTime ReadDateTime();

        /// <summary>Read</summary>
        /// <returns>If true, is an item to read, otherwise have reached end.</returns>
        abstract public bool StartArray();

        /// <summary>Read next item in array</summary>
        /// <returns>If true, is an item to read, otherwise have reached end.</returns>
        abstract public bool NextArray();
        }

    /// <summary>
    /// Abstract JSON object serializer
    /// </summary>
    public abstract class Writer {

        /// <summary>Output stream</summary>
        protected Stream Output;

        /// <summary>Convert output stream to byte array</summary>
        /// <returns>Output stream as byte array</returns>
        public byte[] GetBytes => Output as MemoryStream == null ? null :
            (Output as MemoryStream).ToArray();


        /// <summary>Write out the start of a token.</summary>
        /// <param name="Tag">Tag to write</param>
        /// <param name="Indent">Indent level to write at</param>
        abstract public void WriteToken(string Tag, int Indent);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteInteger32(int Data);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteInteger64(long Data);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteFloat32(float Data);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteFloat64(double Data);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteBoolean(bool Data);

        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteString(string Data);
 
        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteBinary(byte[] Data);

        readonly static byte[] NullBuffer = new byte[0];
        /// <summary>Write empty binary data sequence</summary>
        public void WriteBinary() => WriteBinary(NullBuffer);


        /// <summary>Write integer value token</summary>
        /// <param name="Data">Value to write</param>
        abstract public void WriteDateTime(DateTime? Data);


        /// <summary>Write array start</summary>
        abstract public void WriteArrayStart();

        /// <summary>Write array separator</summary>
        /// <param name="first">If true, is the first item in array, set to false on exit</param>
        abstract public void WriteArraySeparator(ref bool first);

        /// <summary>Write array end</summary>
        abstract public void WriteArrayEnd();

        /// <summary>Write object start</summary>
        abstract public void WriteObjectStart();

        /// <summary>Write object separator.</summary>
        /// <param name="first">If true, is the first item in array, set to false on exit</param>
        abstract public void WriteObjectSeparator(ref bool first);

        /// <summary>Write object end.</summary>
        abstract public void WriteObjectEnd();
        }
    }
   