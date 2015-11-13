using System;
using System.Collections.Generic;
using System.IO;
using System.Text;




namespace Goedel.Protocol {

    public abstract class CharacterStream {
        public long Count = 0;
        public abstract bool EOF { get; }

        public abstract char LookNext();
        public abstract char GetNext();

        }

    public abstract class BufferedCharacterStream : CharacterStream {

        public abstract void Mark();

        public abstract void Restore();
        }

    public class StringCharacterStream : BufferedCharacterStream {
        string Source;
        int Position = 0;
        public override bool EOF { get { return Position >= Source.Length; } }

        public StringCharacterStream(string Source) {
            this.Source = Source;
            }

        public override char LookNext() {
            return Source[Position];
            }

        public override char GetNext() {
            //Console.Write(LookNext());

            return Source[Position++];
            }


        int MarkPosition = -1;
        public override void Mark() {
            MarkPosition = Position;
            }

        public override void Restore() {
            if (MarkPosition >= 0) {
                Position = MarkPosition;
                }
            }

        }

    public class TextCharacterTextStream : CharacterStream {
        TextReader Source;
        bool _EOF;
        public override bool EOF { get { return _EOF; } }

        public TextCharacterTextStream(TextReader Source) {
            this.Source = Source;
            _EOF = false;
            }

        public TextCharacterTextStream(FileStream FileStream) {
            this.Source = new StreamReader(FileStream);
            }

        public override char LookNext() {
            var Char = Source.Peek();
            if (Char < 0) {
                _EOF = true;
                return (char)0;
                }
            return (char)Char;
            }

        public override char GetNext() {
            var Char = Source.Read();
            if (Char < 0) {
                _EOF = true;
                return (char)0;
                }
            return (char)Char;
            }

        }



    public class DataCharacterTextStream : FileCharacterTextStream {
        byte[] Source;
        long Position;


        public DataCharacterTextStream(byte[] Source) {
            this.Source = Source;
            Position = 0;
            }

        public override void Mark() {
            MarkPosition = Position;
            MarkBuffer = Buffer;
            }

        public override void Restore() {
            if (MarkPosition >= 0) {
                Position = MarkPosition;
                Buffer = MarkBuffer;
                }
            }

        protected override int ReadChar() {
            if (Position >= Source.Length) {
                _EOF = true;
                return -1;
                }
            var C1 = Source[Position ++];
            return C1;
            }

        }


    // This implmentation accesses the file directly.

    public class FileCharacterTextStream : BufferedCharacterStream {
        FileStream Source;
        protected bool _EOF = false;
        public override bool EOF { get { return _EOF; } }


        protected long MarkPosition = -1;
        protected int MarkBuffer;

        public override void Mark() {
            MarkPosition = Source.Position;
            MarkBuffer = Buffer;
            }

        public override void Restore() {
            if (MarkPosition >= 0) {
                Source.Seek(MarkPosition, SeekOrigin.Begin);
                Buffer = MarkBuffer;
                }
            }


        protected int Buffer = -1;

        protected FileCharacterTextStream () {

            }

        public FileCharacterTextStream(FileStream FileStream) {
            this.Source = FileStream;
            }

        protected virtual int ReadChar() {
            var C1 = Source.ReadByte();
            if (C1 < 0) {
                _EOF = true;
                }
            return C1;
            }


        void Peek() {
            if (Buffer > 0) {
                return;
                }

            var Byte1 = ReadChar();
            if (_EOF) {
                return;
                }

            if (Byte1 >= 0xf0) {
                // 4 byte sequence
                var Byte2 = ReadChar();
                var Byte3 = ReadChar();
                var Byte4 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 15) | ((Byte2 & 0x3f) << 12) |
                    ((Byte3 & 0x1f) << 6) | (Byte4 & 0x3f);
                }
            else if (Byte1 >= 0xe0) {
                // 3 byte sequence
                var Byte2 = ReadChar();
                var Byte3 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 12) | ((Byte2 & 0x3f) << 6) |
                    (Byte3 & 0x1f);
                }
            else if (Byte1 >= 0xc0) {
                // 2 byte sequence
                var Byte2 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 6) | (Byte2 & 0x3f);
                }
            else {
                Buffer = Byte1;
                }

            }


        public override char LookNext() {
            Peek();
            return (char)Buffer;
            }

        public override char GetNext() {
            //Console.Write(LookNext());
            Peek();
            Buffer = -1;
            return (char)Buffer;
            }

        }

    public abstract class Reader {
        protected CharacterStream Input;

        protected char LookNext() {
            return Input.LookNext();
            }

        protected char GetNext() {
            return Input.GetNext();
            }

        protected bool EOF { get { return Input.EOF; } }

        protected void SetReader(TextReader InputIn) {
            Input = new TextCharacterTextStream(InputIn);
            }

        protected void SetReader(string InputIn) {
            Input = new StringCharacterStream(InputIn);
            }

        protected void SetReader(FileStream InputIn) {
            Input = new FileCharacterTextStream(InputIn);
            }

        public Reader(string BufferIn) {
            SetReader(BufferIn);
            }

        public Reader() {
            }



        public Reader(TextReader InputIn) {
            SetReader(InputIn);
            }

        abstract public bool StartObject();
        abstract public void EndObject();
        abstract public bool NextObject();

        abstract public string ReadToken();

        abstract public int ReadInteger32();
        abstract public long ReadInteger64();
        abstract public bool ReadBoolean();
        abstract public byte[] ReadBinary();
        abstract public string ReadString();
        abstract public DateTime ReadDateTime();
        abstract public bool StartArray();
        abstract public bool NextArray();
        }


    public abstract class Writer {

        protected StreamBuffer Output;

        public byte[] GetBytes {
            get { return Output.GetBytes; }
            }

        abstract public void WriteToken(string Tag, int Indent);

        abstract public void WriteInteger32(int Data);
        abstract public void WriteInteger64(long Data);
        abstract public void WriteFloat32(float Data);
        abstract public void WriteFloat64(double Data);
        abstract public void WriteBoolean(bool Data);

        abstract public void WriteString(string Data);
        abstract public void WriteBinary(byte[] Data);
        abstract public void WriteDateTime(DateTime Data);

        // Mark the start, middle and end of array elements
        abstract public void WriteArrayStart();
        abstract public void WriteArraySeparator(ref bool first);
        abstract public void WriteArrayEnd();

        // Mark the start, middle and end of object elements
        abstract public void WriteObjectStart();
        abstract public void WriteObjectSeparator(ref bool first);
        abstract public void WriteObjectEnd();
        }
    }
   