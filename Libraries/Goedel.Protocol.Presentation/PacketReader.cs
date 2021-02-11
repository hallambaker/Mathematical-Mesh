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
    /// Presentation packet reader class.
    /// </summary>
    public class PacketReader {

        // Performance: Need to revise the interaction between the packet reader and the JsonReader classes.

        ///<summary>Reader position.</summary> 
        public int Position { get; set; } = 0;

        ///<summary>Buffer from which data is read.</summary> 
        public byte[] Packet;

        ///<summary>Factory method returning a reader of the default decryption algorithm and mode.</summary> 
        public static PacketReader Factory(byte[] data) => new PacketReaderGCM(data);

        /// <summary>
        /// Constructor, returns a reader instance for the packet <paramref name="packet"/>.
        /// </summary>
        /// <param name="packet">The packet data.</param>
        public PacketReader(byte[] packet) => Packet = packet;

        /// <summary>
        /// Read the next byte in the packet.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte() => Packet[Position++];

        /// <summary>
        /// Return a Span containing the next <paramref name="length"/> bytes.
        /// </summary>
        /// <param name="length">The number of bytes to return.</param>
        /// <returns>The span.</returns>
        public Span<byte> ReadSpan(int length) {
            var result = new Span<byte>(Packet, Position, length);
            Position += length;
            return result;
            }

        /// <summary>
        /// Read a tag/length specifier from the stream.
        /// </summary>
        /// <returns>The tagged data.</returns>
        public (PacketTag, long) ReadTag() {
            var tag = ReadByte();
            var length = tag & 0b0000_0011;
            var packetTag = (PacketTag)(tag & 0b1111_1100);

            var data = length switch {
                0 => ReadByte(),
                1 => (ReadByte() << 8) | ReadByte(),
                2 => (ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte(),
                3 => (ReadByte() << 56) | (ReadByte() << 48) | (ReadByte() << 40) | (ReadByte() << 32) |
                        (ReadByte() << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte(),
                _ => throw new NYI()
                };
            return (packetTag, data);
            }

        /// <summary>
        /// Read an integer from the stream.
        /// </summary>
        /// <returns>The data that was read.</returns>
        public int ReadInteger() {
            var (packetTag, data) = ReadTag();
            (packetTag == PacketTag.Integer).AssertTrue(NYI.Throw);
            return (int) data;
            }

        /// <summary>
        /// Read a binary from the stream.
        /// </summary>
        /// <returns>A span describing the data that was read.</returns>
        public Span<byte> ReadBinarySpan() {
            var (packetTag, length) = ReadTag();
            (packetTag == PacketTag.Binary).AssertTrue(NYI.Throw);
            return ReadSpan((int) length);
            }

        /// <summary>
        /// Read a UTF8 encoded string from the stream.
        /// </summary>
        /// <returns>The data that was read.</returns>
        public string ReadString() {
            var (packetTag, length) = ReadTag();
            (packetTag == PacketTag.String).AssertTrue(NYI.Throw);
            return ReadSpan((int)length).ToString();
            }


        public byte[] ReadBinary() => ReadBinarySpan().ToArray();

        /// <summary>
        /// Decrypt the remainder of the packet using the primary key <paramref name="ikm"/> and the 
        /// nonce at the current position in the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <returns>A reader for the decrypted data.</returns>
        public virtual PacketReader Decrypt(byte[] ikm) => throw new NYI();


        /// <summary>
        /// Unwrap the packet <paramref name="packet"/> using  the primary key <paramref name="ikm"/> and 
        /// the nonce at the start of the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="packet">The data to decrypt</param>
        /// <returns>A reader for the decrypted data.</returns>
        public static PacketReader Unwrap(byte[] ikm, byte[] packet) => PacketReaderGCM.Unwrap(ikm, packet);

        }

    /// <summary>
    /// Packet reader using AES in GCM mode for decryption.
    /// </summary>
    public class PacketReaderGCM : PacketReader {

        ///<summary>Initialization vector size in bytes. Currently fixed at 12 bytes.</summary> 
        public virtual int SizeIv => 12;

        ///<summary>Tag size in bytes. Currently fixed at 16 bytes.</summary> 
        public virtual int SizeTag => 16;

        /// <summary>
        /// Constructor, returns a reader instance for the packet <paramref name="packet"/>.
        /// </summary>
        /// <param name="packet">The packet data.</param>
        public PacketReaderGCM(byte[] packet) : base(packet) { }

        /// <summary>
        /// Decrypt the remainder of the packet using the primary key <paramref name="key"/> and the 
        /// nonce at the current position in the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <returns>A reader for the decrypted data.</returns>
        public override PacketReader Decrypt(byte[] key) {

            var iv = new byte[Constants.SizeIvAesGcm];
            Buffer.BlockCopy(Packet, Position, iv, 0, iv.Length);
            Position += iv.Length;

            //Constants.Derive2(ikm, nonce, out var iv, out var key);

            var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            var authSpan = new Span<byte>(Packet, 0, Position);
            var TagSpan = new Span<byte>(Packet, Position, SizeIv);
            Position += SizeIv;

            var length = Packet.Length - Position;
            var dataOut = new byte[length];

            var ciphertextSpan = new Span<byte>(Packet, Position, length);
            var plaintextSpan = new ReadOnlySpan<byte>(dataOut, 0, length);

            aes.Decrypt(ivSpan, plaintextSpan, ciphertextSpan, TagSpan, authSpan);

            return new PacketReader(dataOut);
            }

        /// <summary>
        /// Unwrap the packet <paramref name="packet"/> using  the primary key <paramref name="key"/> and 
        /// the nonce at the start of the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="packet">The data to decrypt</param>
        /// <returns>A reader for the decrypted data.</returns>
        public static new PacketReader Unwrap(byte[] key, byte[] packet) {
            var iv = new byte[Constants.SizeNonceAesGcm];
            Buffer.BlockCopy(packet, 0, iv, 0, Constants.SizeIvAesGcm);
            var position = Constants.SizeNonceAesGcm;

            //Constants.Derive2(ikm, nonce, out var iv, out var key);

            var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            var tagSpan = new ReadOnlySpan<byte>(packet, position, Constants.SizeIvAesGcm);
            position += Constants.SizeIvAesGcm;

            var length = packet.Length - position;
            var result = new byte[length];
            var ciphertextSpan = new ReadOnlySpan<byte>(packet, position, length);
            var plaintextSpan = new Span<byte>(result, 0, length);

            aes.Decrypt(ivSpan, ciphertextSpan, tagSpan, plaintextSpan);

            return new PacketReader(result);
            }


        }

    }
