using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goedel.Protocol {

    partial class JSONBCD {
        public const byte Length8 = 0x00;
        public const byte Length16 = 0x01;
        public const byte Length32 = 0x02;
        public const byte Length64 = 0x03;
        public const byte LengthBig = 0x05;

        public const byte StringTerm = 0x80;
        public const byte StringChunk = 0x84;
        public const byte DataTerm = 0x88;
        public const byte DataChunk = 0x8A;

        public const byte PositiveInteger = 0xA0;
        public const byte NegativeInteger = 0xA8;

        public const byte True = 0xB0;
        public const byte False = 0xB1;
        public const byte Null = 0xB2;

        public const byte TagCode = 0xC0;
        public const byte TagDefinition = 0xC4;
        public const byte TagCodeDefinition = 0xC8;
        public const byte TagDictionaryDefinition = 0xCC;

        public const byte DictionaryHash = 0xD0;

        public const byte BinaryFloat16 = 0x90;
        public const byte BinaryFloat32 = 0x91;
        public const byte BinaryFloat64 = 0x92;
        public const byte BinaryFloat128 = 0x94;
        public const byte Intel80 = 0x95;
        public const byte DecimalFloat32 = 0x96;
        public const byte DecimalFloat64 = 0x97;
        public const byte DecimalFloat128 = 0x98;
        }


    public class JSONBWriter : JSONWriter {

        public override string ToString() {
            return Output.GetUTF8;
            }


        public JSONBWriter() {
            this.Output = new StreamBuffer ();
            }

        public JSONBWriter(StreamBuffer Output) {
            this.Output = Output;
            }

        public JSONBWriter(bool Wrap) {
            this.Output = new StreamBuffer ();
            }

        // Write out a Tag-Length value using the shortest possible production
        protected void WriteTag(byte Code, long Length) {
            if (Length < 0x100) {
                Output.Write((byte)(Code + JSONBCD.Length8));
                Output.Write((byte)(Length & 0xff));
                }
            else if (Length < 0x100) {
                Output.Write((byte)(Code + JSONBCD.Length16));
                Output.Write((byte)((Length>>8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            else if (Length < 0x100) {
                Output.Write((byte)(Code + JSONBCD.Length32));
                Output.Write((byte)((Length >> 24) & 0xff));
                Output.Write((byte)((Length >> 16) & 0xff));
                Output.Write((byte)((Length >> 8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            else if (Length < 0x100) {
                Output.Write((byte)(Code + JSONBCD.Length64));
                Output.Write((byte)((Length >> 56) & 0xff));
                Output.Write((byte)((Length >> 48) & 0xff));
                Output.Write((byte)((Length >> 40) & 0xff));
                Output.Write((byte)((Length >> 32) & 0xff));
                Output.Write((byte)((Length >> 24) & 0xff));
                Output.Write((byte)((Length >> 16) & 0xff));
                Output.Write((byte)((Length >> 8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            }

        protected void WriteInteger(long Data) {
            if (Data >= 0) {
                WriteTag(JSONBCD.PositiveInteger, Data);
                }
            else {
                WriteTag(JSONBCD.NegativeInteger, -Data);
                }
            }

        public override void WriteToken(string Tag, int IndentIn) {
            WriteString(Tag);
            }

        public override void WriteInteger32(int Data) {
            WriteInteger(Data);
            }
        public override void WriteInteger64(long Data) {
            WriteInteger(Data);
            }

        // These have not yet been implemented in binary
        public override void WriteFloat32(float Data) {
            Output.Write(Data.ToString());
            }
        public override void WriteFloat64(double Data) {
            Output.Write(Data.ToString());
            }

        public override void WriteBoolean(bool Data) {
            if (Data) {
                Output.Write(JSONBCD.True);
                }
            else {
                Output.Write(JSONBCD.False);
                }
            }

        public override void WriteString(string Data) {
            WriteTag(JSONBCD.StringTerm, Data.Length);
            Output.Write(Data);
            }

        public override void WriteBinary(byte[] Data) {
            WriteTag(JSONBCD.DataTerm, Data.Length);
            Output.Write(Data);
            }

        public override void WriteDateTime(DateTime Data) {
            Output.Write("\"");
            Output.Write(Data);
            Output.Write("\"");
            }

        // Mark the start, middle and end of array elements
        public override void WriteArrayStart() {
            Output.Write("[");
            }
        public override void WriteArraySeparator(ref bool first) {
            }
        public override void WriteArrayEnd() {
            Output.Write("]");
            }

        // Mark the start, middle and end of object elements
        public override void WriteObjectStart() {
            Output.Write("{");
            }
        public override void WriteObjectSeparator(ref bool first) {
            }

        public override void WriteObjectEnd() {
            Output.Write("}");
            }
        }
    }
