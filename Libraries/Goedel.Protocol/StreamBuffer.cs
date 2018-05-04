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
using System.Text;
using System.IO;

namespace Goedel.Protocol {

    /// <summary>Stream buffer. Data written to buffer is written to the
    /// stream as it fills.</summary>
    public class StreamBuffer  {

        /// <summary>Current index</summary>
        public int              Index = 0;

        /// <summary>Length of buffered data</summary>
        public int Length = 0;

        /// <summary>Space in the current buffer</summary>
        public int              Space  =>Current.Length - Index; 
        
        List <byte []>   BufferList = new List<byte[]>();
        byte [] Current;

        /// <summary>Allocation unit (bytes)</summary>
        public int              Allocate ;

        /// <summary>Create buffer with default allocation unit (1024 bytes).</summary>
        public StreamBuffer() : this (1024) {
            }

        /// <summary>
        /// Create buffer
        /// </summary>
        /// <param name="Allocate">Allocation unit.</param>
        public StreamBuffer(int Allocate) {
            this.Allocate = Allocate;
            Current = new byte [Allocate];
            }

        /// <summary>
        /// Create buffer
        /// </summary>
        /// <param name="Stream">Output stream</param>
        public StreamBuffer(Stream Stream) : this (Stream, 1024) {
            }

        /// <summary>
        /// Create buffer
        /// </summary>
        /// <param name="Stream">Output stream</param>
        /// <param name="Allocate">Allocation unit.</param>
        public StreamBuffer(Stream Stream, int Allocate) {
            this.Allocate = Allocate;
            Current = new byte [Allocate];
 
            int Count = Stream.Read (Current, 0, Current.Length);
            while (Count > 0) {
                Advance (Count);
                Count = Stream.Read (Current, Index, Current.Length - Index);
                }
            }

        // Write Methods

        /// <summary>Send a fixed sized buffer to a Stream and flush it.</summary>
        /// <param name="Stream">Stream to send buffer to</param>
        /// <param name="Buffer">Data to send</param>
        public static void Write(Stream Stream, byte[] Buffer) {
            Stream.Write (Buffer, 0, Buffer.Length);
            Stream.Flush ();
            }

        /// <summary>Send this buffer to a Stream and flush it.</summary>
        /// <param name="Stream">Output stream</param>
        public void Write(Stream Stream) {
            foreach (byte[] Buffer in BufferList) {
                Stream.Write(Buffer, 0, Buffer.Length);
                }
            Stream.Write(Current, 0, Index);
            Stream.Flush();
            }


        /// <summary>Write byte to buffer</summary>
        /// <param name="b">data to write</param>
        public void Write (byte b) {
            Current[Index] = b;
            Advance (1);
            }

        /// <summary>Write byte to buffer</summary>
        /// <param name="buffer">data to write</param>
        public void Write (byte [] buffer) {
            Write (buffer, 0, buffer.Length);
            }

        /// <summary>Write byte to buffer</summary>
        /// <param name="buffer">Data to write</param>
        /// <param name="Start">Index of first byte to write</param>
        /// <param name="Count">Number of bytes to write.</param>
        public void Write(byte[] buffer, int Start, int Count) {
            if (Count <= Space) {
                Buffer.BlockCopy(buffer, Start, Current, Index, Count);
                Advance(Count);
                }
            else {
                Buffer.BlockCopy(buffer, Start, Current, Index, Space);
                BufferList.Add (Current);
                Count -= Space;
                Start += Space;
                if (Count < Allocate) {
                    Current = new byte [Allocate];
                    Buffer.BlockCopy(buffer, Start, Current, 0, Count);
                    Index = Count;
                    }
                else {
                    byte [] rest = new byte [Count];
                    Buffer.BlockCopy(buffer, Start, rest, 0, Count);
                    BufferList.Add (rest);
                    Current = new byte [Allocate];
                    }
                }
            }

        bool WriteCached = false;

        /// <summary>
        /// Write character
        /// </summary>
        /// <param name="c">Character to write</param>
        public void Write(char c) {
            if (!WriteCached) {
                if (c < 0x80) {
                    Write((byte)c);
                    return;
                    }
                if (c < 0x0800) {
                    Write ((byte) (0xC0 | ( c >> 6)));
                    Write ((byte) (0x80 | ( c & 0x3f)));
                    return;
                    }
                if ((c < 0xD800) | (c > 0xDFFF)) {

                    Write ((byte) (0xE0 | ( c >> 12)));
                    Write ((byte) (0x80 | (( c >> 6) & 0x3f)));
                    Write ((byte) (0x80 | ( c & 0x3f)));

                    return;
                    }
                if ((c > 0xDC00) & (c <= 0xDFFF)) {
                    throw new Exception ("Invalid character sequence");
                    }
                else {
                    WriteCached = true;
                    //WriteCache = c;
                    }
                }
            else {
                throw new Exception ("Not Implemented");
                }

            }

        /// <summary>Write newline</summary>
        public void WriteLine() {
            Write ('\n');
            }

        /// <summary>Write string</summary>
        /// <param name="s">Data to write</param>
        public void Write(string s) {
            foreach (char c in s) {
                Write(c);
                }
            }

        /// <summary>Write out the Date Time as a string in RFC3339 Format</summary>
        /// <param name="Data">Data to write</param>
        public void Write(DateTime Data) {
            Write (Data.ToString ("yyyy-MM-dd'T'HH:mm:ssZ"));
            }

        /// <summary>Move forward the specified number of bytes.</summary>
        /// <param name="Count">Number of butes to advance the input stream</param>
        public void Advance (int Count) {
            Index += Count;
            Length += Count;
            if (Index >= Current.Length) {
                BufferList.Add (Current);
                Current = new byte [Allocate];
                Index = 0;
                }
            }

        /// <summary>Read buffered bytes.</summary>
        public byte[] GetBytes {
            get { 
                byte [] Result = new byte [Length];
                int i = 0;
                foreach (byte [] Chunk in BufferList) {
                    Buffer.BlockCopy (Chunk, 0, Result, i,  Chunk.Length);
                    i+= Chunk.Length;
                    }
                Buffer.BlockCopy (Current, 0, Result, i,  Index);
                return Result;
                }
            }

        /// <summary>Return the buffer as a UTF8 string.</summary>
        public string GetUTF8 {
            get {
                UTF8Encoding Encoder = new UTF8Encoding ();
                var Bytes = GetBytes;
                return Encoder.GetString (Bytes, 0, Bytes.Length);
                }
            }

        int ReadIndex = 0;
        int ReadBuffer = 0;
        bool Cached = false;
        char CachedChar = ' ';

        /// <summary>Reset stream buffer and all cached data.</summary>
        public void Reset() {
            ReadIndex = 0;
            ReadBuffer = 0;
            Cached = false;
            }

        /// <summary>If true, have rad to end of buffer.</summary>
        public bool EndOfBuffer  => (ReadBuffer >= BufferList.Count) & (ReadIndex >= Current.Length);

        //public override bool CanRead => throw new NotImplementedException();

        //public override bool CanSeek => throw new NotImplementedException();

        //public override bool CanWrite => throw new NotImplementedException();

        //public override long Length => throw new NotImplementedException();

        //public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>Read a byte from the buffer.</summary>
        /// <returns>The data value read</returns>
        public byte ReadByte () {
            if (ReadBuffer >= BufferList.Count) {
                return Current [ReadIndex++];
                }
            else {
                byte Result = BufferList[ReadBuffer][ReadIndex++];
                if (ReadIndex >= BufferList[ReadBuffer].Length) {
                    ReadBuffer ++;
                    ReadIndex = 0;
                    }
                return Result;
                }
            }

        int NextIndex;
        int NextBuffer;

        byte ReadNextByte () {
            if (NextBuffer >= BufferList.Count) {
                return Current [NextIndex++];
                }
            else {
                byte Result = BufferList[NextBuffer][NextIndex++];
                if (ReadIndex >= BufferList[NextBuffer].Length) {
                    NextBuffer ++;
                    NextIndex = 0;
                    }
                return Result;
                }
            }

        /// <summary>Read a character from the buffer</summary>
        /// <returns>The data value read</returns>
        public char ReadChar () {
            char Result = NextChar ();
            ReadBuffer = NextBuffer;
            ReadIndex = NextIndex;
            return Result;
            }

        /// <summary>Read a byte from the buffer</summary>
        /// <returns>The data value read</returns>
        public byte NextByte () {
            if (ReadBuffer >= BufferList.Count) {
                return Current [ReadIndex];
                }
            else {
                return BufferList[ReadBuffer][Index];
                }
            }

        /// <summary>Go to the next character</summary>
        /// <returns>The data value read</returns>
        public char NextChar () {
            NextIndex = ReadIndex;
            NextBuffer = ReadBuffer;

            if (Cached) {
                Cached = false;
                return CachedChar;
                }

            ushort Next = ReadNextByte ();

            if (Next < 0x80) {
                return (char) Next;
                }
            if (Next < 0xC0) {
                throw new Exception ("Not UTF-8");
                }
            if (Next < 0xE0) {
                ushort Next2 = ReadNextByte ();

                return (char) (((Next & (ushort) 0x1f) << 6 ) | (Next2 & (ushort) 0x3f));
                }
            if (Next < 0xE0) {
                ushort Next2 = ReadNextByte ();
                ushort Next3 = ReadNextByte ();

                return (char) (((Next & (ushort) 0x0f) << 12 ) | ((Next2 & (ushort) 0x3f) << 6 ) | (Next3 & (ushort) 0x3f));
                }
            if (Next < 0xE0) {
                uint Next2 = ReadNextByte ();
                uint Next3 = ReadNextByte ();
                uint Next4 = ReadNextByte ();

                uint NextChar = (((Next & (uint) 0x07) << 18 ) | ((Next2 & (uint) 0x3f) << 12 ) | 
                        ((Next3 & (uint) 0x3f) << 6 ) | (Next4 & (uint) 0x3f)) - 0x10000;

                uint High = (NextChar >> 10) | 0xD800;
                uint Low = (NextChar & 0x3ff) | 0xDC00;

                CachedChar = (char) Low;
                Cached = true;

                return (char) High;
                }
            throw new Exception ("Not UTF-8");
            }

        //public override void Flush () {
        //    throw new NotImplementedException();
        //    }

        //public override int Read (byte[] buffer, int offset, int count) {
        //    throw new NotImplementedException();
        //    }

        //public override long Seek (long offset, SeekOrigin origin) {
        //    throw new NotImplementedException();
        //    }

        //public override void SetLength (long value) {
        //    throw new NotImplementedException();
        //    }

        //public override void Write (byte[] buffer, int offset, int count) {
        //    throw new NotImplementedException();
        //    }
        }
    }
