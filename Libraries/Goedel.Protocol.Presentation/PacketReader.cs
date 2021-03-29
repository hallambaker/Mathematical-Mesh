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


        public int Last;

        ///<summary>Buffer from which data is read.</summary> 
        public byte[] Packet;

        ///<summary>Factory method returning a reader of the default decryption algorithm and mode.</summary> 
        public static PacketReader Factory(byte[] data) => new PacketReaderAesGcm(data);

        /// <summary>
        /// Constructor, returns a reader instance for the packet <paramref name="packet"/>.
        /// </summary>
        /// <param name="packet">The packet data.</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.</param>
        public PacketReader(byte[] packet, 
                int position=0,
                int count = -1) {
            Packet = packet;
            Position = position;
            Last = count < 0 ? packet.Length : position + count;
            }

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
        /// Read binary from the stream and return as a span.
        /// </summary>
        /// <returns>A span containing the data that was read.</returns>
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
            return ReadSpan((int)length).ToArray().ToUTF8();
            }

        /// <summary>
        /// Read binary from the stream and return as a byte array.
        /// </summary>
        /// <returns>A byte array containing the data that was read.</returns>
        public byte[] ReadBinary() => ReadBinarySpan().ToArray();


        /// <summary>
        /// Read a list of extensions.
        /// </summary>
        /// <returns>>The list of extensions read.</returns>
        public List<PacketExtension> ReadExtensions() {
            var (etag, count) = ReadTag();
            if (count == 0) {
                return null;
                }
            var result = new List<PacketExtension>();
            for (var i = 0; i < count; i++) {
                var tag = ReadString();
                var value = ReadBinary();
                var extension = new PacketExtension() { Tag = tag, Value = value };
                result.Add(extension);
                }

            return result;
            }


        /// <summary>
        /// Decrypt the remainder of the packet using the primary key <paramref name="ikm"/> and the 
        /// nonce at the current position in the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="pad">If true the data is padded to consume the remainder of the data.</param>
        /// <returns>A reader for the decrypted data.</returns>
        public virtual PacketReader Decrypt(byte[] ikm, bool pad = true) => throw new NYI();


        /// <summary>
        /// Unwrap the packet <paramref name="packet"/> using  the primary key <paramref name="ikm"/> and 
        /// the nonce at the start of the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="ikm">The primary key.</param>
        /// <param name="packet">The data to decrypt</param>
        /// <returns>A reader for the decrypted data.</returns>
        public static PacketReader Unwrap(byte[] ikm, byte[] packet) => PacketReaderAesGcm.Unwrap(ikm, packet);

        }

    /// <summary>
    /// Packet reader using AES in GCM mode for decryption.
    /// </summary>
    public class PacketReaderAesGcm : PacketReader {

        ///<summary>Initialization vector size in bytes. Currently fixed at 12 bytes.</summary> 
        public virtual int SizeIv => 12;

        ///<summary>Tag size in bytes. Currently fixed at 16 bytes.</summary> 
        public virtual int SizeTag => 16;

        ///<inheritdoc/>
        public PacketReaderAesGcm(byte[] packet, 
                int position=0,
                int count = -1) : base(packet, position, count) { }

        ///<inheritdoc/>
        public override PacketReader Decrypt(byte[] key, bool pad = true) {

            //Screen.WriteLine($"Decrypt Key {key.ToStringBase16()}");

            var aes = new AesGcm(key);

            var ivSpan = new ReadOnlySpan<byte>(Packet, Position, Constants.SizeIvAesGcm);
            Position += Constants.SizeIvAesGcm;

            var authSpan = new Span<byte>(Packet, 0, Position);
            //Screen.WriteLine($"AuthSpan {0}  {Position}");

            var tagSpan = new Span<byte>(Packet, Position, Constants.SizeTagAesGcm);
            //Screen.WriteLine($"TagSpan {Position}  {Constants.SizeTagAesGcm}");

            Position += Constants.SizeTagAesGcm;

            var length = pad ? Packet.Length - Position : Position;
            var dataOut = new byte[length];

            var ciphertextSpan = new ReadOnlySpan<byte>(Packet, Position, length);
            var plaintextSpan = new Span<byte>(dataOut, 0, length);

            //Screen.WriteLine($"Spans plaintext: {0} ciphertext {Position} length {length}");
            aes.Decrypt(ivSpan, ciphertextSpan, tagSpan, plaintextSpan, authSpan);

            return new PacketReaderAesGcm(dataOut);
            }

        /// <summary>
        /// Unwrap the packet <paramref name="packet"/> using  the primary key <paramref name="key"/> and 
        /// the nonce at the start of the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="packet">The data to decrypt</param>
        /// <returns>A reader for the decrypted data.</returns>
        public static new PacketReader Unwrap(byte[] key, byte[] packet, int offset) {

            // Hack: This needs to be rewritten with the tag at the end!

            Screen.WriteLine($"Decrypt Key {key.ToStringBase16()}");

            var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(packet, offset, Constants.SizeIvAesGcm);
            var position = offset + ivSpan.Length;

            Screen.WriteLine($"IvSpan {0}  {ivSpan.Length}");

            var tagSpan = new ReadOnlySpan<byte>(packet, position, Constants.SizeTagAesGcm);
            Screen.WriteLine($"position {position} {tagSpan.Length}");

            position += tagSpan.Length;

            var length = packet.Length - position;
            var result = new byte[length];
            var ciphertextSpan = new ReadOnlySpan<byte>(packet, position, length);

            Screen.WriteLine($"Ciphertext {position} {length}");

            var plaintextSpan = new Span<byte>(result, 0, length);

            aes.Decrypt(ivSpan, ciphertextSpan, tagSpan, plaintextSpan);

            return new PacketReader(result);
            }


        }

    }
