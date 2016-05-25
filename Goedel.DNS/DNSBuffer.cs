using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Goedel.DNS {
    public class DNSBuffer {
        public byte []      Buffer;
        public int          MaxLength;
        public int          Length;
        //public int          Pointer;

        public DNSBuffer (int Start, int Max) {
            //Pointer = 0;
            Length = Start;
            MaxLength = Max;
            Buffer = new byte[Length];
            }
        public DNSBuffer (byte[] data, int LengthIn) {
            //Pointer = 0;
            Buffer = data;
            Length = LengthIn;
            }
        public DNSBuffer () : this (256, 4096) { }        
        
        }

    public class DNSBufferIndex {
        public DNSBuffer           Buffer;

        ASCIIEncoding ASCIIEncoding = new ASCIIEncoding ();

        public byte[] Bytes {
            get  {
                byte [] result = new byte[Pointer];
                Array.Copy (Buffer.Buffer, result, Pointer);
                return result;
                }
            }
        public int          Pointer;
        public int          MaxRead;

        public DNSBufferIndex (byte[] data, int LengthIn) {
            Buffer = new DNSBuffer (data, LengthIn);
            Pointer = 0;
            MaxRead = LengthIn;
            }

        public DNSBufferIndex (byte [] Data) : this (Data, Data.Length) {
            }

        public DNSBufferIndex (DNSBuffer BufferIn) {
            Buffer = BufferIn;
            }

        public DNSBufferIndex (DNSBuffer BufferIn, int PointerIn, int LengthIn) {
            Buffer = BufferIn;
            Pointer = PointerIn;
            MaxRead = PointerIn + LengthIn;
            //Pointer = Buffer.Pointer;
            }
        public DNSBufferIndex () : this (new DNSBuffer ()) { }



        // Check to see if there is space in the buffer, resize if possible
        // Throw exception if not.
        void CheckSpaceWrite (int bytes) {
            if (( Pointer + bytes ) > Buffer.MaxLength) 
                    throw new TBSException ("Buffer Overflow");
            if (( Pointer + bytes ) > Buffer.Length) {
                Array.Resize (ref Buffer.Buffer, Buffer.MaxLength);
                }
            }

        void CheckSpaceRead(int bytes) {
            if (Pointer + bytes > MaxRead) {
                throw new TBSException("Read Truncated");
                }
            }


        byte Read () {
            byte b = Buffer.Buffer[Pointer++];
            //Buffer.Pointer = Pointer;
            return b;
            }
        void Write (byte b) {
            Buffer.Buffer[Pointer++] = b;
            }
        public void Write (ushort data) {
            WriteInt16 (data);
            }

        public void WriteString(string data) {
            foreach (char c in data) {
                WriteByte ((byte) c);
                }
            }
        public void WriteString8 (string data) {
            WriteByte ((byte)data.Length);
            WriteString(data);
            }

        public void WriteByte (byte data) {
            CheckSpaceWrite (1);
            Write (data);
            }

        public void WriteIPv4 (IPAddress data) {
            byte [] bytes = data.GetAddressBytes();
            if (bytes.Length != 4) throw new Exception ("Not a valid IPv4 Address");
            WriteData (bytes);
            }

        public void WriteIPv6 (IPAddress data) {
            byte [] bytes = data.GetAddressBytes();
            if (bytes.Length != 16) throw new Exception ("Not a valid IPv6 Address");
            WriteData (bytes);
            }

        public void WriteInt16 (UInt16 data) {
            CheckSpaceWrite (2);
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }
        public void WriteInt16 (DNSTypeCode data) {
            WriteInt16 ((UInt16)data);
            }
        public void WriteInt16 (DNSClass data) {
            WriteInt16 ((UInt16)data);
            }
        public void WriteInt16 (DNSFlags data) {
            WriteInt16 ((UInt16)data);
            }
        public void WriteInt16 (int data) {
            WriteInt16 ((UInt16)data);
            }
        public void WriteInt32 (UInt32 data) {
            CheckSpaceWrite (4);
            Write ((byte) ((data & 0xff000000) >> 24));
            Write ((byte) ((data & 0xff0000) >> 16));
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }
        public void WriteInt48 (ulong data) {
            CheckSpaceWrite (6);
            Write ((byte) ((data & 0xff0000000000) >> 40));
            Write ((byte) ((data & 0xff00000000) >> 32));
            Write ((byte) ((data & 0xff000000) >> 24));
            Write ((byte) ((data & 0xff0000) >> 16));
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }
        public void WriteInt64 (ulong data) {
            CheckSpaceWrite (8);
            Write ((byte) ((data & 0xff00000000000000) >> 56));
            Write ((byte) ((data & 0xff000000000000) >> 48));
            Write ((byte) ((data & 0xff0000000000) >> 40));
            Write ((byte) ((data & 0xff00000000) >> 32));
            Write ((byte) ((data & 0xff000000) >> 24));
            Write ((byte) ((data & 0xff0000) >> 16));
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }
        public void WriteDomain(Domain Domain) {
            WriteName (Domain.Name);
            }
        public void WriteMail(string Data) {
            WriteName (Data);
            }
        public void WriteName (String Name) {
            int offset = Pointer, label = 0;

            WriteByte (0);
            for (int i=0; i <= Name.Length; i++) {
                char n = i == Name.Length ? '.' : Name[i];
                UInt16 nn = (UInt16)n;
                //Console.WriteLine ("   {0:d3} {1:s}", i, n);
                if (n == '.') {
                    if (label != 0) { //Ignore zero length labels
                        if (label > 63) throw new TBSException ("Label too long");
                        Buffer.Buffer[offset] = (byte)label;
                        offset = Pointer;
                        WriteByte (0);
                        label = 0;
                        }
                    }
                else if (n == '-' | n == '_' | ( nn >= 65 & nn <= 90 ) | ( nn >= 48 & nn <= 57 )) {
                    WriteByte ((byte)nn);
                    label++;
                    }
                else if (nn >= 97 & nn <= 122) {
                    WriteByte ((byte)( nn - 32 ));
                    label++;
                    }
                else if (nn > 255) {
                    throw new TBSException ("Unicode Not Supported Yet");
                    }
                else throw new TBSException ("Illegal character");
                }
            }
        public void WriteTag (String Tag) {
            CheckSpaceWrite (Tag.Length);
            if (Tag.Length>255) throw new TBSException ("Tag Too Long");
            foreach (char c in Tag) {
                Write ((byte)( c & 0x7f ));
                }
            }
        public void WriteL8Data (byte[] data) {
            WriteByte ((byte)data.Length);
            WriteData (data);
            }
                          
        public void WriteL16Data (byte[] data) {
            WriteInt16 ((UInt16)data.Length);
            WriteData (data);
            }

        public void WriteData (byte[] data) {
            CheckSpaceWrite (data.Length);
            Array.Copy (data, 0, Buffer.Buffer, Pointer, data.Length);
            Pointer = Pointer + data.Length;
            //Buffer.Pointer = Pointer;
            }

        // Public read methods 
        public byte ReadByte () {
            CheckSpaceRead (1);
            return Read ();
            }
        public void ReadByte (out byte data) {
            data = ReadByte ();
            }
        public UInt16 ReadInt16 () {
            CheckSpaceRead (2);
            // Using bitwise operators for speed
            return (UInt16)( ( Read () << 8 ) | Read () );
            }
        public void ReadInt16 (out UInt16 data) {
            data = ReadInt16 ();
            }

        public void ReadInt16 (out DNSTypeCode data) {
            data = (DNSTypeCode)ReadInt16 ();
            }
        public void ReadInt16 (out DNSClass data) {
            data = (DNSClass)ReadInt16 ();
            }
        public void ReadInt16 (out DNSFlags data) {
            data = (DNSFlags)ReadInt16 ();
            }
        public void ReadInt16 (out int data) {
            data = (int)ReadInt16 ();
            }

        public UInt32 ReadInt32 () {
            CheckSpaceRead (4);
            return (UInt32)( ( Read () << 24 ) | (Read () << 16) | (Read () << 8) | Read () );
            }
        public UInt64 ReadInt64 () {
            CheckSpaceRead (4);
            return (UInt64)( ( Read () << 56 ) | (Read () << 48) | (Read () << 40) | Read () << 32|
                ( Read () << 24 ) | (Read () << 16) | (Read () << 8) | Read () );
            }
        public void ReadInt32 (out UInt32 data) {
            data = ReadInt32 ();
            }

        public void ReadInt64 (out UInt64 data) {
            data = ReadInt64 ();
            }
        public void ReadNodeID (out UInt64 data) {
            data = ReadInt64 ();
            }
        public UInt64 ReadNodeID () {
            ulong data;
            ReadInt64 (out data);
            return data;
            }
        public Domain ReadDomain() {
            return new Domain (ReadName ());
            }


        public String ReadName() {
            bool going = true;
            String name = "";

            while (going) {
                byte b0 = ReadByte();
                if (b0 == 0) {
                    going = false;
                    }
                else if (b0 > 63) {
                    byte b1 = ReadByte();
                    int nPointer = b1 + 256 * (b0 & 0x3f);
                    //Console.WriteLine("Pointer {0}", nPointer);

                    while (going) {
                        if (nPointer < Pointer) {       // Only follow a pointer to a PRIOR occurrence
                            byte b2 = Buffer.Buffer[nPointer];

                            if (b2 == 0) {
                                going = false;
                                }
                            else if (b2 > 63) {
                                going = false;
                                // do not support recursive compression
                                }
                            else {
                                name = name + ASCIIEncoding.GetString (Buffer.Buffer, nPointer+1, b2) + ".";
                                //Console.WriteLine("   [{0}]", name);
                                nPointer = nPointer + b2 + 1;
                                }
                            }
                        else {
                            going = false;
                            }
                        }

                    }
                else {
                    name = name + ReadString((int)b0) + ".";
                    //Console.WriteLine("   {0}", name);
                    }
                }
            //Console.WriteLine("Got name {0}", name);
            return name;

            }
        public String ReadTag () {
            Byte length = ReadByte();
            return ReadString (length);
            }
        public byte[] ReadL8Data () {
            Byte length = ReadByte();
            return ReadData (length);
            }
        public byte[] ReadL16Data() {
            UInt16 length = ReadInt16();
            return ReadData (length);
            }
        public void ReadL16Data (out DNSBufferIndex data) {
            UInt16 length = ReadInt16 ();
            CheckSpaceRead (length);

            data = new DNSBufferIndex(Buffer, Pointer, length);

            Pointer = Pointer + length;
            }
        public byte[] ReadData () {
            // Read the remainder of the buffer
            return ReadData (MaxRead - Pointer);
            }
        public byte[] ReadData (int Length) {
            CheckSpaceRead (Length);
            byte[] data = new byte [Length];
            Array.Copy (Buffer.Buffer, Pointer, data, 0, Length);
            Pointer = Pointer + Length;

            return data;
            }

        // Read character string consisting of a single byte length value 
        // followed by a string
        public String ReadString() {
            int length = ReadByte ();
            return ReadString (length);
            }

        public String ReadString (int length) {
            CheckSpaceRead (length);

            string result = ASCIIEncoding.GetString (Buffer.Buffer, Pointer, length);
            Pointer = Pointer + length;

            return result;
            }

        // TBS
        public List<String> ReadStrings(int Extent) {
            List<String> ListString = new List<string> ();
            //int length = ReadByte ();
            return ListString;
            }

        // TBS

        public IPAddress ReadIPv4 () {
            byte [] Address = new byte [4];
            for (int i = 0; i < 4; i++) {
                Address [i] = ReadByte ();
                }
            return new IPAddress (Address) ;
            }
        public IPAddress ReadIPv6 () {
            byte [] Address = new byte [16];
            for (int i = 0; i < 16; i++) {
                Address [i] = ReadByte ();
                }
            return new IPAddress (Address) ;
            }
        public string ReadMail  () {
            return null;
            }
        public string ReadOptionalString  () {
            return null;
            }

        public uint ReadTime32  () {
            return 0;
            }
        public ulong ReadTime48  () {
            return 0;
            }



        public void Dump () {
            for (int i =0; i < Pointer; i++) {
                Console.WriteLine ("  {0:x2}  {1:s}", Buffer.Buffer[i], (char)Buffer.Buffer[i]);
                }
            }

        }

    }
