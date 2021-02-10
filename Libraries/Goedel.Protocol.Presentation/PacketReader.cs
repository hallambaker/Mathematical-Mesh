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

        public static PacketReader Factory(byte[] data) => new PacketReaderGCM(data);


        public PacketReader(byte[] data) => Data = data;



        public byte ReadByte() => Data[Position++];


        public (PacketTag, long) ReadTag {
            var 

            }



        int ReadInteger() => throw new NYI();

        byte[] ReadBinary() => throw new NYI();

        string ReadString() => throw new NYI();

        int SkipBinary() => throw new NYI();



        public virtual PacketReader Decrypt (byte[] iv, byte[]key) => throw new NYI();


        public virtual PacketReader Unwrap (byte[] iv, byte[] key) => throw new NYI();


        }

    public class PacketReaderGCM : PacketReader {

        public PacketReaderGCM(byte[] data) : base(data) { }


        public override PacketReader Decrypt(byte[] iv, byte[] key) => throw new NYI();


        public override PacketReader Unwrap(byte[] iv, byte[] key) => throw new NYI();


        }

    }
