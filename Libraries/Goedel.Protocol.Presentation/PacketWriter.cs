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

    /// <summary>
    /// Packet tag types
    /// </summary>
    public enum PacketTag {
        ///<summary>Integer field</summary> 
        Integer =0x00,
        ///<summary>String field</summary> 
        String = 0x10,
        ///<summary>Binary field</summary> 
        Binary = 0x20,
        ///<summary>List of extensions follow</summary> 
        Extensions = 0x30,
        }

    /// <summary>
    /// Base class for packet writers.
    /// </summary>
    public class PacketWriter : Disposable {

        ///<summary>Position of the writer within the packet.</summary> 
        public int Position { get; set; } = 0;
        ///<summary>The Packet data</summary> 
        public byte[] Packet;

        ///<summary>Size of the largest encrypted block that can be inserted into
        ///the writer.</summary> 
        public virtual int RemainingSpace => Packet.Length - Position;

        ///<summary>Factory method, returns a packet writer for the default encryption algorithm.</summary> 
        public static PacketWriter Factory(int packetSize = 1200) => new PacketWriterAesGcm(packetSize);

        /// <summary>
        /// Constructor, create a packet writer with a packet size of 
        /// <paramref name="packetSize"/>.
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        public PacketWriter(int packetSize=1200) => Packet = new byte[packetSize];

        /// <summary>
        /// Return the number of bytes taken to specify tag/length production of length
        /// <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The data item to size.</param>
        /// <returns>Number of bytes required for the encoding.</returns>
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
        void Write(byte b) => Packet[Position++] = b;

        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production.
        /// </summary>
        /// <param name="tag">Base code.</param>
        /// <param name="data">Length of data to follow.</param>
        public void WriteTag(PacketTag tag, long data) {

            // Hack: replace with more limited approach.
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
            Buffer.BlockCopy(data, offset, Packet, Position, count);
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
        public void Write(byte[] data) {
            if (data == null) {
                WriteTag(PacketTag.Binary, 0);
                }
            else {
                Write(PacketTag.Binary, data, 0, data.Length);
                }
            }


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
            Write(PacketTag.String, buffer, 0, buffer.Length);
            }


        /// <summary>
        ///Write the positive EncryptedPacketIdentifier <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public void Write(EncryptedPacketIdentifier data)
                    => Write((byte)data);

        /// <summary>
        ///Write the positive EncryptedPacketIdentifier <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public void Write(PlaintextPacketType data)
                    => Write((byte)data);

        /// <summary>
        /// Write the list of extensions <paramref name="extensions"/> to the packet.
        /// </summary>
        /// <param name="extensions">The extensions to write.</param>
        public void WriteExtensions(List<PacketExtension> extensions=null) {

            if (extensions == null) {
                WriteTag(PacketTag.Extensions, 0);
                return;
                }

            WriteTag(PacketTag.Extensions, extensions.Count);


            foreach (var option in extensions) {
                Write(option.Tag);
                Write(option.Value);
                }

            }


        /// <summary>
        /// Skip forward to reserve space for a data item of <paramref name="length"/>
        /// bytes.
        /// </summary>
        /// <param name="length">Length of the data item to reserve space for.</param>
        public void SkipBinary(int length) => Position += LengthLength(length);

        /// <summary>
        /// Fill out the remainder of the packet by using the value <paramref name="ikm"/>
        /// and a generated nonce to encrypt the data specified in <paramref name="packet"/>
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="packet">The plaintext data</param>
        /// <param name="pad">If true, fill the entire remainder of the packet.</param>
        public virtual void Encrypt(byte[] ikm, PacketWriter packet, bool pad = true) => throw new NYI();


        /// <summary>
        /// Wrap a data packet payload to create an encrypted data packet.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <returns>The wrapped data packet.</returns>
        public virtual byte[] Wrap(byte[] ikm) => throw new NYI();


        }

    /// <summary>
    /// Encrypting packet writer.
    /// </summary>
    public class PacketWriterAesGcm : PacketWriter {

        ///<summary>Size of the largest encrypted block that can be inserted into
        ///the writer.</summary> 
        public override int RemainingSpace => Packet.Length - Position 
                    - Constants.SizeIvAesGcm - Constants.SizeTagAesGcm;

        /// <summary>
        /// Constructor, create a packet writer with a packet size of 
        /// <paramref name="packetSize"/>.
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        public PacketWriterAesGcm(int packetSize = 1200) : base(packetSize) { }

        /// <summary>
        /// Fill out the remainder of the packet by using the value <paramref name="key"/>
        /// and a generated nonce to encrypt the data specified in <paramref name="writerIn"/>
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="writerIn">The plaintext data</param>
        /// <param name="pad">If true, pad packet to fill remaining space.</param>
        public override void Encrypt(byte[] key, PacketWriter writerIn, bool pad=true) {
            Screen.WriteLine($"Encrypt Key {key.ToStringBase16()}");
            var aes = new AesGcm(key);

            var iv = Platform.GetRandomBytes(Constants.SizeIvAesGcm);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            Buffer.BlockCopy(iv, 0, Packet, Position, iv.Length);
            Position+= iv.Length;

            // Set up the authentication span so it covers the start of the 
            // packet up to the tag.
            var authSpan = new Span<byte>(Packet, 0, Position);

            var TagSpan = new Span<byte>(Packet, Position, Constants.SizeTagAesGcm);
            Position += Constants.SizeTagAesGcm;

            var length = pad ? Packet.Length - Position : Position;
            var ciphertextSpan = new Span<byte>(Packet, Position, length);
            var plaintextSpan = new ReadOnlySpan<byte>(writerIn.Packet, 0, length);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, TagSpan, authSpan);
            Position += length;
            }

        /// <summary>
        /// Wrap a data packet payload to create an encrypted data packet.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <returns>The wrapped data packet.</returns>
        public override byte[] Wrap(byte[] key) {

            //Constants.Derive(ikm, out var nonce, out var iv, out var key);

            var result = new byte[Packet.Length];

            // Copy the nonce.
            // NB, it is the responsibility of the caller to set the top bit to ensure the
            // packet is correctly identified as a data packet.


            var aes = new AesGcm(key);

            var iv = Platform.GetRandomBytes(Constants.SizeIvAesGcm);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            var count = iv.Length;


            var tagSpan = new Span<byte>(result, count, Constants.SizeIvAesGcm);
            count += Constants.SizeIvAesGcm;

            var length = result.Length - count;

            var ciphertextSpan = new Span<byte>(result, count, length);
            var plaintextSpan = new ReadOnlySpan<byte>(Packet, 0, length);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, tagSpan);

            return result;
            }








        }
    }
