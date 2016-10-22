using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;

namespace Goedel.Cryptography.KeyFile {

    public class DataBuffer {
        uint Length = 0;
        uint Pointer = 0;

        uint Remain { get { return (uint)(Data.Length - Pointer); } }

        public byte[] Data;

        public DataBuffer() {
            }

        public DataBuffer(byte[] Data) {
            this.Data = Data;
            }

        public void Size(byte[] Data) {
            Length += (uint) (4 + Data.Length);
            }

        public void Size(string Data) {
            Length += (uint)(4 + Data.CountUTF8());
            }

        public void Allocate() {
            Data = new byte[Length];
            }

        public void EncodeLength (uint Length) {
            Data[Pointer++] = (byte)((Length >> 24) & 0xff);
            Data[Pointer++] = (byte)((Length >> 16) & 0xff);
            Data[Pointer++] = (byte)((Length >> 8) & 0xff);
            Data[Pointer++] = (byte)(Length & 0xff);
            }

        public void Encode(byte[] Input) {
            EncodeLength((uint)Input.Length);
            Array.Copy(Input, 0, Data, (int)Pointer, Input.Length);
            Pointer += (uint)(Input.Length);
            }

        public void Encode(string Text) {
            var Size = (uint)Text.CountUTF8();
            EncodeLength(Size);
            Text.ToUTF8(Data, (int) Pointer);
            Pointer += Size;
            }

        public uint DecodeLength () {
            Assert.False(Remain < 4, UnexpectedEnd.Throw);

            var Byte0 = Data[Pointer++];
            var Byte1 = Data[Pointer++];
            var Byte2 = Data[Pointer++];
            var Byte3 = Data[Pointer++];

            // Length encoding is bigendian
            uint Result = (uint) ((Byte0 << 24) | Byte1 << 16 | Byte2 << 8 | Byte3);

            return Result;
            }

        public void Decode(out byte[] Result) {
            var Bytes = DecodeLength();
            Result = new byte[Bytes];

            Array.Copy(Data, Pointer, Result, 0, Bytes);
            Pointer += Bytes;
            }

        public void Decode(out string Result) {
            var StringBuilder = new StringBuilder();
            var Bytes = DecodeLength();

            for (var i = 0; i< Bytes; i++) {
                var Byte = Data[Pointer++];
                StringBuilder.Append((char)Byte);
                }

            Result = StringBuilder.ToString();
            }
        }

    public abstract class SSHData {
        public abstract string Tag { get; }

        public static SSHData Decode(byte[] Data) {
            string Tag2;

            var DataBuffer = new DataBuffer(Data);
            DataBuffer.Decode(out Tag2);

            if (Tag2 == SSH_RSA.TagID) {
                return new SSH_RSA(DataBuffer);
                }

            if (Tag2 == SSH_DSS.TagID) {
                return new SSH_RSA(DataBuffer);
                }

            return null;
            }


        public abstract byte[] Encode();
        }

    public class SSH_RSA : SSHData {
        public override string Tag { get { return "ssh-rsa"; } }
        public static string TagID { get { return "ssh-rsa"; } }

        public byte[] Exponent;
        public byte[] Modulus;

        public override byte[] Encode() {
            var DataBuffer = new DataBuffer();

            DataBuffer.Size(Tag);
            DataBuffer.Size(Exponent);
            DataBuffer.Size(Modulus);

            DataBuffer.Allocate();

            DataBuffer.Encode(Tag);
            DataBuffer.Encode(Exponent);
            DataBuffer.Encode(Modulus);

            return DataBuffer.Data;
            }

        public SSH_RSA(DataBuffer DataBuffer) {
            DataBuffer.Decode(out Exponent);
            DataBuffer.Decode(out Modulus);
            }

        }


    public class SSH_DSS : SSHData {
        public override string Tag { get { return "ssh-dss"; } }
        public static string TagID { get { return "ssh-dss"; } }

        public byte[] P;
        public byte[] Q;
        public byte[] G;
        public byte[] Y;

        public override byte[] Encode() {
            var DataBuffer = new DataBuffer();

            DataBuffer.Size(Tag);
            DataBuffer.Size(P);
            DataBuffer.Size(Q);
            DataBuffer.Size(G);
            DataBuffer.Size(Y);

            DataBuffer.Allocate();

            DataBuffer.Encode(Tag);
            DataBuffer.Encode(P);
            DataBuffer.Encode(Q);
            DataBuffer.Encode(G);
            DataBuffer.Encode(Y);

            return DataBuffer.Data;
            }

        public SSH_DSS(DataBuffer DataBuffer) {
            DataBuffer.Decode(out P);
            DataBuffer.Decode(out Q);
            DataBuffer.Decode(out G);
            DataBuffer.Decode(out Y);
            }

        }
    }
