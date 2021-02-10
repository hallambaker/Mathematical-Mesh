using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;
namespace Goedel.Protocol.Presentation {

    public enum PacketTag {
        Integer =0,
        String = 1,
        Binary = 2,
        Ipv4 = 3,
        Ipv6 = 4,
        Port = 5,
        Extensions = 6,
        Tag = 7,

        }

    public class PacketWriter {

        public int Position { get; set; } = 0;
        public byte[] Data;

        public const int SizeNonce = 16;
        public const int SizeIv = 12;
        public const int SizeTag = 16;
        public const int SizeKey= 32;

        public readonly static byte[] TagIv = "IV".ToUTF8();
        public readonly static byte[] TagKey = "Key".ToUTF8();
        public static PacketWriter Factory(int packetSize = 1200) => new PacketWriterGCM(packetSize);

        public PacketWriter(int packetSize=1200) => Data = new byte[packetSize];


        public static int LengthLength(long data) {
            if (data < 0x100) {
                return 2;
                }
            else if (data < 0x10000) {
                return 3;
                }
            else if (data < 0x100000000) {
                return 5;
                }
            else {
                return 9;
                }
            }



        /// <summary>
        /// Write a byte to the packet
        /// </summary>
        /// <param name="b"></param>
        void Write(byte b) => Data[Position++] = b;

        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production
        /// to <paramref name="Output"/>.
        /// </summary>
        /// <param name="Output">The output stream to write to.</param>
        /// <param name="tag">Base code.</param>
        /// <param name="data">Length of data to follow.</param>
        public void WriteTag(PacketTag tag, long data) {
            if (data < 0x100) {
                Write((byte)(tag + JSONBCD.Length8));
                Write((byte)(data & 0xff));
                }
            else if (data < 0x10000) {
                Write((byte)(tag + JSONBCD.Length16));
                Write((byte)((data >> 8) & 0xff));
                Write((byte)(data & 0xff));
                }
            else if (data < 0x100000000) {
                Write((byte)(tag + JSONBCD.Length32));
                Write((byte)((data >> 24) & 0xff));
                Write((byte)((data >> 16) & 0xff));
                Write((byte)((data >> 8) & 0xff));
                Write((byte)(data & 0xff));
                }
            else {
                Write((byte)(tag + JSONBCD.Length64));
                Write((byte)((data >> 56) & 0xff));
                Write((byte)((data >> 48) & 0xff));
                Write((byte)((data >> 40) & 0xff));
                Write((byte)((data >> 32) & 0xff));
                Write((byte)((data >> 24) & 0xff));
                Write((byte)((data >> 16) & 0xff));
                Write((byte)((data >> 8) & 0xff));
                Write((byte)(data & 0xff));
                }
            }

        void Write(PacketTag code, byte[] data, int offset, int count) {
            WriteTag(code, data.Length);
            Buffer.BlockCopy(data, offset, Data, Position, count);
            Position += data.Length;
            }



        /// <summary>
        ///Write the positive integer <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public void Write(int data) => WriteTag((byte)PacketTag.Integer, data);

        /// <summary>
        /// Write the binary data <paramref name="data"/> to the packet.
        /// </summary>
        /// <param name="data">The data to write</param>
        public void Write(byte[] data) =>
                Write(PacketTag.Binary, data, 0, data.Length);

        /// <summary>
        ///  Write the binary data  <paramref name="data"/> to the packet beginning
        ///  at position <paramref name="offset"/> for <paramref name="count"/> bytes.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void Write(byte[] data, int offset, int count) =>
                Write(PacketTag.Binary, data, offset, count);

        /// <summary>
        ///Write the string <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public void Write(string data) {
            var buffer = data.ToUTF8();
            Write(PacketTag.Binary, buffer, 0, buffer.Length);
            }

        /// <summary>
        /// Skip forward to reserve space for a data item of <paramref name="length"/>
        /// bytes.
        /// </summary>
        /// <param name="length">Length of the data item to reserve space for.</param>
        public void SkipBinary(int length) => Position += LengthLength(length);

        /// <summary>
        /// Fill out the remainder of the packet with data from <paramref name="data"/> encrypted
        /// under <paramref name="iv"/>, <paramref name="key"/>. This form of encryption is used
        /// to append encrypted payloads to control packets.
        /// </summary>
        /// <param name="iv">The encryption initialization vector</param>
        /// <param name="key">The encryption key</param>
        /// <param name="data">The plaintext data</param>
        public virtual void Encrypt(byte[] iv, byte[] key, PacketWriter data) => throw new NYI();


        /// <summary>
        /// Wrap the packet 
        /// </summary>
        /// <param name="nonce"></param>
        /// <param name="iv"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual byte[] Wrap(byte[] nonce, byte[] iv, byte[] key) => throw new NYI();

        public static void Derive(byte[] ikm, out byte[] nonce, out byte[]iv, out byte[] key) {
            nonce = Platform.GetRandomBytes(SizeNonce);
            nonce[0] |= 0b1000_0000;

            Derive2(ikm, nonce, out iv, out key);


            }

        public static void Derive2(byte[] ikm, byte[] nonce, out byte[] iv, out byte[] key) {
            var keyDerive = new KeyDeriveHKDF(ikm, nonce);
            iv = keyDerive.Derive(TagIv, SizeIv);
            key = keyDerive.Derive(TagKey, SizeKey);
            }
        }


    public class PacketWriterGCM : PacketWriter {

        public PacketWriterGCM(int packetSize = 1200) : base(packetSize) { }

        public override void Encrypt(byte[] iv, byte[] key, PacketWriter data) {

            // to do - make everything in the packet that is not encrypted data,
            // authenticated data.

            var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            var TagSpan = new Span<byte>(Data, Position, SizeIv);
            Position += SizeIv;

            var length = Data.Length - Position;
            var ciphertextSpan = new Span<byte>(Data, Position, length);
            var plaintextSpan = new ReadOnlySpan<byte>(data.Data, 0, length);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, TagSpan);
            Position += length;
            }
        
        
        public byte[] Wrap(byte[] ikm) {

            Derive(ikm, out var nonce, out var iv, out var key);

            var result = new byte[Data.Length];

            // Copy the nonce.
            // NB, it is the responsibility of the caller to set the top bit to ensure the
            // packet is correctly identified as a data packet.
            Buffer.BlockCopy(nonce, 0, result, 0, nonce.Length);
            var count = nonce.Length;

            var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            var tagSpan = new Span<byte>(result, count, SizeIv);
            count += SizeIv;

            var length = result.Length - count;

            var ciphertextSpan = new Span<byte>(result, count, length);
            var plaintextSpan = new ReadOnlySpan<byte>(Data, 0, length);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, tagSpan);

            return result;
            }








        }
    }
