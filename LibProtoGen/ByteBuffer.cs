//Sample license text.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Goedel.Protocol {
    public class StreamBuffer {

        public int              Index = 0;
        public int              Length = 0;
        
        public int              Space {
            get { return (Current.Length - Index); }}
        
        List <byte []>   BufferList = new List<byte[]>();
        byte [] Current;

        public int              Allocate ;

        public StreamBuffer() : this (1024) {
            }

        public StreamBuffer(int Allocate) {
            this.Allocate = Allocate;
            Current = new byte [Allocate];
            }

        public StreamBuffer(Stream Stream) : this (Stream, 1024) {
            }

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
        
        // Send a fixed sized buffer to a Stream and close it.
        public static void Write(Stream Stream, byte[] Buffer) {
            Stream.Write (Buffer, 0, Buffer.Length);
            Stream.Close ();
            }

        // Send this buffer to a Stream and close it.
        public void Write(Stream Stream) {
            foreach (byte[] Buffer in BufferList) {
                Stream.Write(Buffer, 0, Buffer.Length);
                }
            Stream.Write(Current, 0, Index);
            Stream.Close();
            }


        public void Write (byte b) {
            Current[Index] = b;
            Advance (1);
            }

        public void Write (byte [] buffer) {
            Write (buffer, 0, buffer.Length);
            }

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
        char WriteCache;
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
                    WriteCache = c;
                    }
                }
            else {
                throw new Exception ("Not Implemented");
                }

            }

        public void WriteLine() {
            Write ('\n');
            }

        public void Write(string s) {
            foreach (char c in s) Write (c);
            }

        // Write out the Date Time as a string in RFC3339 Format:
        public void Write(DateTime Data) {
            Write (Data.ToString ("yyyy-MM-dd'T'HH:mm:ssZ"));
            }

        public void Advance (int Count) {
            Index += Count;
            Length += Count;
            if (Index >= Current.Length) {
                BufferList.Add (Current);
                Current = new byte [Allocate];
                Index = 0;
                }
            }

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

        public string GetUTF8 {
            get {
                UTF8Encoding Encoder = new UTF8Encoding ();

                return Encoder.GetString (GetBytes);
                }
            }

        int ReadIndex = 0;
        int ReadBuffer = 0;
        bool Cached = false;
        char CachedChar = ' ';

        public void Reset() {
            ReadIndex = 0;
            ReadBuffer = 0;
            Cached = false;
            }

        public bool EndOfBuffer {
                get {return (ReadBuffer >= BufferList.Count) & (ReadIndex >= Current.Length); }}

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

        public char ReadChar () {
            char Result = NextChar ();
            ReadBuffer = NextBuffer;
            ReadIndex = NextIndex;
            return Result;
            }

        public byte NextByte () {
            if (ReadBuffer >= BufferList.Count) {
                return Current [ReadIndex];
                }
            else {
                return BufferList[ReadBuffer][Index];
                }
            }


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
        }
    }
