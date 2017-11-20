using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Goedel.Utilities;

namespace Goedel.Discovery {

    /// <summary>
    /// Buffer class for DNS operations.
    /// </summary>
    public class DNSBuffer {
        /// <summary>The buffer data</summary>
        public byte []      Buffer;
        
        /// <summary>The maximum buffer length</summary>
        public int          MaxLength;
        
        /// <summary>The current buffer length.</summary>
        public int          Length;
        //public int          Pointer;

        /// <summary>
        /// Create buffer with specified initial and maximum size.
        /// </summary>
        /// <param name="Start">Starting buffer size.</param>
        /// <param name="Max">Maximum buffer size.</param>
        public DNSBuffer (int Start, int Max) {
            //Pointer = 0;
            Length = Start;
            MaxLength = Max;
            Buffer = new byte[Length];
            }
        
        /// <summary>
        /// Create buffer from received data buffer and length specification.
        /// </summary>
        /// <param name="data">Input data</param>
        /// <param name="LengthIn">Length of message received.</param>
        public DNSBuffer (byte[] data, int LengthIn) {
            //Pointer = 0;
            Buffer = data;
            Length = LengthIn;
            }

        /// <summary>Default constructor.</summary>
        public DNSBuffer () : this (256, 4096) { }        
        
        }

    /// <summary>Buffer class for DNS operations using a portion of a 
    /// buffer specified by a separate index. This buffer class is used 
    /// to read in records etc. whose length is specified by an external
    /// range with proper buffer overrun checks.</summary>
    public class DNSBufferIndex {

        /// <summary>The underlying buffer.</summary>
        public DNSBuffer           Buffer;

        ASCIIEncoding ASCIIEncoding = new ASCIIEncoding ();

        /// <summary>Return the buffer data window as a byte array.</summary>
        public byte[] Bytes {
            get  {
                byte [] result = new byte[Pointer];
                Array.Copy (Buffer.Buffer, result, Pointer);
                return result;
                }
            }
        /// <summary>Current read/write pointer.</summary>
        public int          Pointer;
        /// <summary>Maximum number of bytes to be buffered.</summary>
        public int          MaxRead;

        /// <summary>
        /// Constructor from existing data set
        /// </summary>
        /// <param name="data">Binary data.</param>
        /// <param name="LengthIn">Number of bytes</param>
        public DNSBufferIndex (byte[] data, int LengthIn) {
            Buffer = new DNSBuffer (data, LengthIn);
            Pointer = 0;
            MaxRead = LengthIn;
            }

        /// <summary>
        /// Constructor from existing data set
        /// </summary>
        /// <param name="Data">Binary data.</param>
        public DNSBufferIndex (byte [] Data) : this (Data, Data.Length) {
            }

        /// <summary>
        /// Constructor from existing data set
        /// </summary>
        /// <param name="BufferIn">Data buffer</param>
        public DNSBufferIndex (DNSBuffer BufferIn) {
            Buffer = BufferIn;
            }

        /// <summary>
        /// Constructor from existing data set
        /// </summary>
        /// <param name="BufferIn">Data buffer</param>
        /// <param name="PointerIn">Starting point of buffer window.</param>
        /// <param name="LengthIn">Length of buffer window.</param>
        public DNSBufferIndex (DNSBuffer BufferIn, int PointerIn, int LengthIn) {
            Buffer = BufferIn;
            Pointer = PointerIn;
            MaxRead = PointerIn + LengthIn;
            //Pointer = Buffer.Pointer;
            }
        /// <summary>Default constructor.</summary>
        public DNSBufferIndex () : this (new DNSBuffer ()) { }



        // Check to see if there is space in the buffer, resize if possible otherwise throw 
        // exception
        void CheckSpaceWrite (int bytes) {
            Assert.False (( Pointer + bytes ) > Buffer.MaxLength , BufferWriteOverflow.Throw);

            if (( Pointer + bytes ) > Buffer.Length) {
                Array.Resize (ref Buffer.Buffer, Buffer.MaxLength);
                }
            }

        void CheckSpaceRead(int bytes) {
            Assert.False(Pointer + bytes > MaxRead, BufferReadOverflow.Throw);
            }


        /// <summary>
        /// Mark and return the current position.
        /// </summary>
        public int Start {
            get {
                _Start = Pointer;
                return _Start;
                }
            }
        int _Start = 0;

        /// <summary>
        /// Returns the space remaining in a buffer of Length bytes begun from the
        /// point last marked with Start.
        /// </summary>
        /// <param name="Length">Length of the buffer</param>
        /// <returns>The remaining bytes.</returns>
        public int Remainder (int Length) => Length - (Pointer - _Start);



        byte Read () {
            byte b = Buffer.Buffer[Pointer++];
            //Buffer.Pointer = Pointer;
            return b;
            }
        void Write (byte b) {
            Buffer.Buffer[Pointer++] = b;
            }

        /// <summary>Write 16 bit integer value</summary>
        /// <param name="data">Data to write</param>
        public void Write (ushort data) {
            WriteInt16 (data);
            }

        /// <summary>Write string value with no length prefix (length specified otherwise)</summary>
        /// <param name="data">Data to write</param>
        public void WriteString(string data) {
            foreach (char c in data) {
                WriteByte ((byte) c);
                }
            }
        /// <summary>Write string value with 8 bit length prefix</summary>
        /// <param name="data">Data to write</param>
        public void WriteString8 (string data) {
            WriteByte ((byte)data.Length);
            WriteString(data);
            }

        /// <summary>Write byte value</summary>
        /// <param name="data">Data to write</param>
        public void WriteByte (byte data) {
            CheckSpaceWrite (1);
            Write (data);
            }

        /// <summary>Write IPv4 Address value</summary>
        /// <param name="data">Data to write</param>
        public void WriteIPv4 (IPAddress data) {
            byte [] bytes = data.GetAddressBytes();
            Assert.True(bytes.Length == 4, InvalidIPv4.Throw);
            WriteData (bytes);
            }

        /// <summary>Write IPv6 value</summary>
        /// <param name="data">Data to write</param>
        public void WriteIPv6 (IPAddress data) {
            byte [] bytes = data.GetAddressBytes();
            Assert.True(bytes.Length == 16, InvalidIPv6.Throw);
            WriteData (bytes);
            }

        /// <summary>Write 16 bit integer value.value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt16 (UInt16 data) {
            CheckSpaceWrite (2);
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }

        /// <summary>Write DNS code value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt16 (DNSTypeCode data) {
            WriteInt16 ((UInt16)data);
            }

        /// <summary>Write DNC Class value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt16 (DNSClass data) {
            WriteInt16 ((UInt16)data);
            }

        /// <summary>Write DNS Flags value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt16 (DNSFlags data) {
            WriteInt16 ((UInt16)data);
            }

        /// <summary>Write int 16 value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt16 (int data) {
            WriteInt16 ((UInt16)data);
            }

        /// <summary>Write int 32 value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt32 (UInt32 data) {
            CheckSpaceWrite (4);
            Write ((byte) ((data & 0xff000000) >> 24));
            Write ((byte) ((data & 0xff0000) >> 16));
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }

        /// <summary>Write int 48 value</summary>
        /// <param name="data">Data to write</param>
        public void WriteInt48 (ulong data) {
            CheckSpaceWrite (6);
            Write ((byte) ((data & 0xff0000000000) >> 40));
            Write ((byte) ((data & 0xff00000000) >> 32));
            Write ((byte) ((data & 0xff000000) >> 24));
            Write ((byte) ((data & 0xff0000) >> 16));
            Write ((byte) ((data & 0xff00) >> 8));
            Write ((byte) (data & 0xff));
            }

        /// <summary>Write int 64 value</summary>
        /// <param name="data">Data to write</param>
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

        /// <summary>Write domain name value</summary>
        /// <param name="Domain">Data to write</param>
        public void WriteDomain(Domain Domain) {
            WriteName (Domain.Name);
            }

        /// <summary>Write Mail address value</summary>
        /// <param name="Data">Data to write</param>
        public void WriteMail(string Data) {
            WriteName (Data);
            }

        /// <summary>Write DNS name value</summary>
        /// <param name="Name">Data to write</param>
        public void WriteName (String Name) {
            int offset = Pointer, label = 0;

            WriteByte (0);
            for (int i=0; i <= Name.Length; i++) {
                char n = i == Name.Length ? '.' : Name[i];
                UInt16 nn = (UInt16)n;
                //Console.WriteLine ("   {0:d3} {1:s}", i, n);
                if (n == '.') {
                    if (label != 0) { //Ignore zero length labels
                        Assert.False(label > 63, LabelTooLong.Throw);
                        Buffer.Buffer[offset] = (byte)label;
                        offset = Pointer;
                        WriteByte(0);
                        label = 0;
                        }
                    }
                else if (n == '-' | n == '_' | (nn >= 65 & nn <= 90) | (nn >= 48 & nn <= 57)) {
                    WriteByte((byte)nn);
                    label++;
                    }
                else if (nn >= 97 & nn <= 122) {
                    WriteByte((byte)(nn - 32));
                    label++;
                    }
                else if (nn > 255) {
                    throw new UnicodeNotSupported();
                    }
                else {
                    throw new IllegalCharacter();
                    }
                }
            }

        /// <summary>Write Tag value</summary>
        /// <param name="Tag">Data to write</param>
        public void WriteTag (String Tag) {
            CheckSpaceWrite (Tag.Length);
            Assert.False(Tag.Length>255, TagTooLong.Throw);
            foreach (char c in Tag) {
                Write ((byte)( c & 0x7f ));
                }
            }

        /// <summary>Write data value with byte length prefix value</summary>
        /// <param name="data">Data to write</param>
        public void WriteL8Data (byte[] data) {
            WriteByte ((byte)data.Length);
            WriteData (data);
            }

        /// <summary>Write value with 2 byte length prefix.</summary>
        /// <param name="data">Data to write</param>                  
        public void WriteL16Data (byte[] data) {
            WriteInt16 ((UInt16)data.Length);
            WriteData (data);
            }

        /// <summary>Write value with no length prefix</summary>
        /// <param name="data">Data to write</param>
        public void WriteData (byte[] data) {
            CheckSpaceWrite (data.Length);
            Array.Copy (data, 0, Buffer.Buffer, Pointer, data.Length);
            Pointer = Pointer + data.Length;
            //Buffer.Pointer = Pointer;
            }

        // Public read methods 

        /// <summary>Read byte value</summary>
        /// <returns>The value read</returns>
        public byte ReadByte () {
            CheckSpaceRead (1);
            return Read ();
            }

        /// <summary>Read byte value</summary>
        /// <param name="data">Data read</param>
        public void ReadByte (out byte data) {
            data = ReadByte ();
            }

        /// <summary>Read 16 bit integer value</summary>
        /// <returns>The value read</returns>
        public UInt16 ReadInt16 () {
            CheckSpaceRead (2);
            // Using bitwise operators for speed
            return (UInt16)( ( Read () << 8 ) | Read () );
            }

        /// <summary>Read 16 bit integer value</summary>
        /// <param name="data">Data read</param>
        public void ReadInt16 (out UInt16 data) {
            data = ReadInt16 ();
            }

        /// <summary>Read DNS Type value</summary>
        /// <param name="data">Data read</param>
        public void ReadInt16 (out DNSTypeCode data) {
            data = (DNSTypeCode)ReadInt16 ();
            }

        /// <summary>Read DNS Class value</summary>
        /// <param name="data">Data read</param>
        public void ReadInt16 (out DNSClass data) {
            data = (DNSClass)ReadInt16 ();
            }

        /// <summary>Read DNS Flags value</summary>
        /// <param name="data">Data read</param>
        public void ReadInt16 (out DNSFlags data) {
            data = (DNSFlags)ReadInt16 ();
            }

        /// <summary>Read 16 bit integer value</summary>
        /// <param name="data">Data read</param>
        public void ReadInt16 (out int data) {
            data = (int)ReadInt16 ();
            }

        /// <summary>Read 32 bit integer value</summary>
        /// <returns>The value read</returns>
        public UInt32 ReadInt32 () {
            CheckSpaceRead (4);
            return (UInt32)( ( Read () << 24 ) | (Read () << 16) | (Read () << 8) | Read () );
            }

        /// <summary>Read 64 bit integer value</summary>
        /// <returns>The value read</returns>
        public UInt64 ReadInt64 () {
            CheckSpaceRead (4);
            return (UInt64)( ( Read () << 56 ) | (Read () << 48) | (Read () << 40) | Read () << 32|
                ( Read () << 24 ) | (Read () << 16) | (Read () << 8) | Read () );
            }

        /// <summary>Read 32 bit integer value</summary>
        /// <param name="data">The value read</param>
        public void ReadInt32 (out UInt32 data) {
            data = ReadInt32 ();
            }

        /// <summary>Read 64 bit integer value</summary>
        /// <param name="data">Data to write</param>
        public void ReadInt64 (out UInt64 data) {
            data = ReadInt64 ();
            }

        /// <summary>Read 64 bit node identifier value</summary>
        /// <param name="data">The value read</param>
        public void ReadNodeID (out UInt64 data) {
            data = ReadInt64 ();
            }

        /// <summary>Read Node identifier value</summary>
        /// <returns>The value read</returns>
        public UInt64 ReadNodeID () {
            ReadInt64 (out var data);
            return data;
            }

        /// <summary>Read Domain name value</summary>
        /// <returns>The value read</returns>
        public Domain ReadDomain() {
            return new Domain (ReadName ());
            }

        /// <summary>Read name value</summary>
        /// <returns>The value read</returns>
        public String ReadName() {
            bool going = true;

            var StringBuilder = new StringBuilder();
            bool First = true;

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
                                if(!First) {
                                    StringBuilder.Append('.');
                                    }
                                First = false;
                                StringBuilder.Append(ASCIIEncoding.GetString(Buffer.Buffer, nPointer + 1, b2));
                                //name = name + ASCIIEncoding.GetString (Buffer.Buffer, nPointer+1, b2) + ".";
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
                    if (!First) {
                        StringBuilder.Append('.');
                        }
                    First = false;
                    StringBuilder.Append(ReadString((int)b0));
                    //name = name + ReadString((int)b0) + ".";
                    //Console.WriteLine("   {0}", name);
                    }
                }
            //Console.WriteLine("Got name {0}", name);
            return StringBuilder.ToString();

            }

        /// <summary>Read tag value</summary>
        /// <returns>The value read</returns>
        public String ReadTag () {
            Byte length = ReadByte();
            return ReadString (length);
            }

        /// <summary>Read string value with 8 bit length prefix</summary>
        /// <returns>The value read</returns>
        public byte[] ReadL8Data () {
            Byte length = ReadByte();
            return ReadData (length);
            }

        /// <summary>Read string value with 16 bit length prefix</summary>
        /// <returns>The value read</returns>
        public byte[] ReadL16Data() {
            UInt16 length = ReadInt16();
            return ReadData (length);
            }

        /// <summary>Read data value with 16 bit length delimeter.</summary>
        /// <param name="data">The value read.</param>
        public void ReadL16Data(out DNSBufferIndex data) {
            UInt16 length = ReadInt16();
            CheckSpaceRead(length);

            data = new DNSBufferIndex(Buffer, Pointer, length);

            Pointer = Pointer + length;
            }

        /// <summary>Read binary data value (remainder of the buffer)</summary>
        /// <returns>The value read</returns>
        public byte[] ReadData () {
            // Read the remainder of the buffer
            return ReadData (MaxRead - Pointer);
            }

        /// <summary>Read remainder of the buffer as binary data value</summary>
        /// <param name="Length">Number of bytes to read</param>
        /// <returns>The value read</returns>
        public byte[] ReadData (int Length) {
            CheckSpaceRead (Length);
            byte[] data = new byte [Length];
            Array.Copy (Buffer.Buffer, Pointer, data, 0, Length);
            Pointer = Pointer + Length;

            return data;
            }

        // Read character string consisting of a single byte length value 
        // followed by a string
        /// <summary>Read value</summary>
        /// <returns>The value read</returns>
        public String ReadString() {
            int length = ReadByte ();
            return ReadString (length);
            }

        /// <summary>Read string value with specified length.</summary>
        /// <param name="length">Number of bytes to read.</param>
        /// <returns>The value read</returns>
        public String ReadString (int length) {
            CheckSpaceRead (length);

            string result = ASCIIEncoding.GetString (Buffer.Buffer, Pointer, length);
            Pointer = Pointer + length;

            return result;
            }

        /// <summary>Read set of strings value</summary>
        /// <param name="Extent">Number of bytes to read.</param>
        /// <returns>Null list, this is a stub</returns>
        /// <remarks>Not yet implemented.</remarks>
        public List<String> ReadStrings(int Extent) {
            List<String> ListString = new List<string> ();
            //int length = ReadByte ();
            while (Pointer < MaxRead) {
                var Text = ReadString();
                ListString.Add(Text);
                }

            return ListString;
            }

        // TBS
        /// <summary>Read IPv4 address value</summary>
        /// <returns>The value read</returns>
        public IPAddress ReadIPv4 () {
            byte [] Address = new byte [4];
            for (int i = 0; i < 4; i++) {
                Address [i] = ReadByte ();
                }
            return new IPAddress (Address) ;
            }

        /// <summary>Read value</summary>
        /// <returns>The value read</returns>
        public IPAddress ReadIPv6 () {
            byte [] Address = new byte [16];
            for (int i = 0; i < 16; i++) {
                Address [i] = ReadByte ();
                }
            return new IPAddress (Address) ;
            }

        /// <summary>Read value</summary>
        /// <returns>The value read</returns>
        /// <remarks>Not yet implemented</remarks>
        public string ReadMail  () {
            return null;
            }

        /// <summary>Read value</summary>
        /// <returns>The value read</returns>
        /// <remarks>Not yet implemented</remarks>
        public string ReadOptionalString  () {
            return null;
            }

        /// <summary>Read 32 bit time value</summary>
        /// <returns>The value read</returns>
        /// <remarks>Not yet implemented</remarks>
        public uint ReadTime32  () {
            return 0;
            }

        /// <summary>Read 48 bit time value</summary>
        /// <returns>The value read</returns>
        /// <remarks>Not yet implemented</remarks>
        public ulong ReadTime48  () {
            return 0;
            }



        //public void Dump () {
        //    for (int i =0; i < Pointer; i++) {
        //        Console.WriteLine ("  {0:x2}  {1:s}", Buffer.Buffer[i], (char)Buffer.Buffer[i]);
        //        }
        //    }

        }

    }
