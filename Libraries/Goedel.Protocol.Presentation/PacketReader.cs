using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {



    public class PacketReader {

        public int Position { get; set; } = 0;
        public byte[] Data;

        public PacketReader(byte[] data) => Data = data;


        byte ReadByte() => Data[Position++];


        int ReadInteger() => throw new NYI();

        byte[] ReadBinary() => throw new NYI();

        string ReadString() => throw new NYI();

        int SkipBinary() => throw new NYI();



        byte[] Decrypt (byte[] iv, byte[]key) => throw new NYI();



        //public static int ModifierToLength(int c) => c & 0x01 switch {
        //    0 => 1,
        //    1 => 2,
        //    _ => throw new NYI(),
        //    };

        //ulong GetInteger(int Code) {
        //    ulong Result = 0;

        //    var Count = ModifierToLength(Code);
        //    for (var i = 0; i < Count; i++) {
        //        var c = ReadByte();
        //        Result = (Result << 8) | c;
        //        }
        //    return Result;
        //    }

        //Token LexerInteger(int Code, bool Positive) {
        //    ResultInt64 = Positive ? (long)GetInteger(Code) : -(long)GetInteger(Code);
        //    return Token.Integer;
        //    }

        //Token LexerString(int Code, bool Terminal) {
        //    var Length = (int)GetInteger(Code);
        //    var Buffer = ByteInput.ReadBinary(Length);
        //    ResultString = Buffer.ToUTF8();
        //    this.Terminal = Terminal;
        //    return Token.String;
        //    }

        }
    }
