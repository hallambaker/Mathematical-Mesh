using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Factory method delegate, returns a reader instance for the packet 
    /// <paramref name="packet"/>.
    /// </summary>
    /// <param name="packet">The packet data.</param>
    /// <param name="position">Start position at which reading of the packet should start.</param>
    /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.</param>

    public delegate PacketReader PacketReaderFactoryDelegate(byte[] packet,
                int position = 0,
                int count = -1);

    /// <summary>
    /// Decrypts the ciphertext into the provided destination buffer if the authentication
    /// tag can be validated
    /// </summary>
    /// <param name="key"></param>
    /// <param name="nonce">The nonce associated with this message, which must match the value 
    /// provided during encryption.</param>
    /// <param name="ciphertext">The encrypted content to decrypt.</param>
    /// <param name="tag">The authentication tag produced for this message during encryption.</param>
    /// <param name="plaintext">The byte span to receive the decrypted contents.</param>
    /// <param name="associatedData">Extra data associated with this message, which must match the 
    /// value provided during encryption.</param>
    /// <exception cref="System.ArgumentException">The plaintext parameter and the ciphertext do 
    /// not have the same length. -or- The nonce parameter length is not permitted by 
    /// System.Security.Cryptography.AesGcm.NonceByteSizes.  -or- The tag parameter length is 
    /// not permitted by System.Security.Cryptography.AesGcm.TagByteSizes.</exception>
    /// <exception cref="System.Security.Cryptography.CryptographicException">
    /// The tag value could not be verified, or the decryption operation otherwise failed.</exception>
    public delegate void DecryptDataDelegate(
            byte[] key,
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> ciphertext,
            ReadOnlySpan<byte> tag,
            Span<byte> plaintext,
            ReadOnlySpan<byte> associatedData = default);



    /// <summary>
    /// Presentation packet reader class.
    /// </summary>
    public class PacketReader {
        #region // Properties
        // Performance: Need to revise the interaction between the packet reader and the JsonReader classes.

        ///<summary>Reader position.</summary> 
        public int Position { get; set; } = 0;

        ///<summary>The length of the valid portion of the buffer <see cref="Buffer"/>.</summary> 
        public int Last;

        ///<summary>Buffer from which data is read. This MAY be longer than needed, the lenght to be used
        ///is specified by <see cref="Last"/></summary> 
        public byte[] Packet;

        ///<summary>Factory method returning a reader of the default decryption algorithm and mode.</summary> 
        public static PacketReader Factory(byte[] data,
                int position = 0,
                int count = -1) => new PacketReader(data, position, count);

        ///<summary>The delegate to use to decrypt data.</summary> 
        public DecryptDataDelegate DecryptDataDelegate = DecryptAesGcm;

        #endregion
        #region // Constructors
        /// <summary>
        /// Constructor, returns a reader instance for the packet <paramref name="packet"/>.
        /// </summary>
        /// <param name="packet">The packet data.</param>
        /// <param name="position">Start position at which reading of the packet should start.</param>
        /// <param name="count">Maximum number of bytes to be read from <paramref name="packet"/>.</param>
        public PacketReader(byte[] packet,
                int position = 0,
                int count = -1) {
            Packet = packet;
            Position = position;
            Last = count < 0 ? packet.Length : position + count;
            }
        #endregion
        #region // Methods 
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
            return (int)data;
            }

        /// <summary>
        /// Read a <see cref="ResponderMessageType"/> in a connection packet.
        /// </summary>
        /// <param name="buffer">Buffer to be read from.</param>
        /// <param name="position">Position at which to read.</param>
        /// <returns>The value read.</returns>
        public static ResponderMessageType ReadResponderMessageType(
                    byte[] buffer,
                    ref int position) => (ResponderMessageType)buffer[position++];

        /// <summary>
        /// Read a <see cref="InitiatorMessageType"/> in a connection packet.
        /// </summary>
        /// <param name="buffer">Buffer to be read from.</param>
        /// <param name="position">Position at which to read.</param>
        /// <returns>The value read.</returns>
        public static InitiatorMessageType ReadInitiatorMessageType(
            byte[] buffer,
            ref int position) => (InitiatorMessageType)buffer[position++];

        /// <summary>
        /// Read binary from the stream and return as a span.
        /// </summary>
        /// <returns>A span containing the data that was read.</returns>
        public Span<byte> ReadBinarySpan() {
            var (packetTag, length) = ReadTag();
            (packetTag == PacketTag.Binary).AssertTrue(NYI.Throw);
            return ReadSpan((int)length);
            }

        /// <summary>
        /// Read a UTF8 encoded string from the stream.
        /// </summary>
        /// <returns>The data that was read.</returns>
        public string ReadString() {
            var (packetTag, length) = ReadTag();
            (packetTag == PacketTag.String).AssertTrue(NYI.Throw);
            if (length == 0) {
                return null;
                }
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
            List<PacketExtension> result = null;
            for (var tag = ReadString(); tag != null; tag = ReadString()) {
                result ??= new();
                var value = ReadBinary();
                var extension = new PacketExtension() { Tag = tag, Value = value };
                result.Add(extension);
                }

            return result;
            }


        /// <summary>
        /// Decrypts the ciphertext into the provided destination buffer if the authentication
        /// tag can be validated
        /// </summary>
        /// <param name="key"></param>
        /// <param name="nonce">The nonce associated with this message, which must match the value 
        /// provided during encryption.</param>
        /// <param name="ciphertext">The encrypted content to decrypt.</param>
        /// <param name="tag">The authentication tag produced for this message during encryption.</param>
        /// <param name="plaintext">The byte span to receive the decrypted contents.</param>
        /// <param name="associatedData">Extra data associated with this message, which must match the 
        /// value provided during encryption.</param>
        /// <exception cref="System.ArgumentException">The plaintext parameter and the ciphertext do 
        /// not have the same length. -or- The nonce parameter length is not permitted by 
        /// System.Security.Cryptography.AesGcm.NonceByteSizes.  -or- The tag parameter length is 
        /// not permitted by System.Security.Cryptography.AesGcm.TagByteSizes.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The tag value could not be verified, or the decryption operation otherwise failed.</exception>
        public static void DecryptAesGcm(
                byte[] key,
                ReadOnlySpan<byte> nonce,
                ReadOnlySpan<byte> ciphertext,
                ReadOnlySpan<byte> tag,
                Span<byte> plaintext,
                ReadOnlySpan<byte> associatedData = default) {
            var aes = new AesGcm(key);
            aes.Decrypt(nonce, ciphertext, tag, plaintext, associatedData);

            }


        private Span<byte> GetSpan(long start, long length) {
            Screen.WriteLine($"{start} for {length}");

            return new Span<byte>(Packet, (int)start, (int)length);
            }

        private ReadOnlySpan<byte> GetReadOnlySpan(int start, long length) {
            Screen.WriteLine($"{start} for {length}");
            Position = (int)(start + length);
            return new ReadOnlySpan<byte>(Packet, start, (int)length);
            }


        /// <summary>
        /// Decrypt the remainder of the packet using the primary key <paramref name="key"/> and the 
        /// nonce at the current position in the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="pad">If true the data is padded to consume the remainder of the data.</param>
        /// <returns>A reader for the decrypted data.</returns>
        public virtual PacketReader Decrypt(byte[] key, bool pad = true) {

            Screen.WriteLine($"Decrypt Key {key.ToStringBase16()}");

            Screen.Write("D-Auth: ");
            var authSpan = GetReadOnlySpan(0, Position);

            Screen.Write("D-IV: ");
            var ivSpan = GetReadOnlySpan(Position, Constants.SizeIvAesGcm);



            int length;
            if (pad) {
                length = Last - Position - Constants.SizeTagAesGcm;
                }
            else {
                length = ReadInteger();
                }

            var dataOut = new byte[length];
            var plaintextSpan = new Span<byte>(dataOut, 0, length);

            Screen.Write("D-Cipher: ");
            var ciphertextSpan = GetReadOnlySpan(Position, length);

            Screen.Write("D-Tag: ");
            var tagSpan = GetReadOnlySpan(Position, Constants.SizeTagAesGcm);

            DecryptDataDelegate(key, ivSpan, ciphertextSpan, tagSpan, plaintextSpan, authSpan);

            return new PacketReader(dataOut);
            }

        /// <summary>
        /// Unwrap the packet <paramref name="packet"/> using  the primary key <paramref name="key"/> and 
        /// the nonce at the start of the packet to provide the necessary keying material.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="packet">The data to decrypt</param>
        /// <param name="offset">The starting point of the encrypted portion of the buffer (i.e. start
        /// of the initialization vector)</param>
        /// <param name="last">The last byte in the buffer to read.</param>
        /// <param name="decryptDataDelegate">The decryption delegate.</param>
        /// <returns>A reader for the decrypted data.</returns>
        public static PacketReader Unwrap(byte[] key, byte[] packet, int offset, int last,
            DecryptDataDelegate decryptDataDelegate = null) {

            // Hack: This needs to be rewritten with the tag at the end!

            //Screen.WriteLine($"Decrypt Key {key.ToStringBase16()}");

            //var aes = new AesGcm(key);
            var ivSpan = new ReadOnlySpan<byte>(packet, offset, Constants.SizeIvAesGcm);
            //Screen.WriteLine($"IvSpan {offset}  {ivSpan.Length}");

            var position = offset + ivSpan.Length;



            var length = last - position - Constants.SizeTagAesGcm;
            var ciphertextSpan = new ReadOnlySpan<byte>(packet, position, length);
            //Screen.WriteLine($"Ciphertext {position} {ciphertextSpan.Length}");

            position += length;

            var tagSpan = new ReadOnlySpan<byte>(packet, position, Constants.SizeTagAesGcm);
            //Screen.WriteLine($"TagSpan {position} {tagSpan.Length}");

            var result = new byte[length];

            var plaintextSpan = new Span<byte>(result, 0, length);

            //aes.Decrypt(ivSpan, ciphertextSpan, tagSpan, plaintextSpan);
            decryptDataDelegate ??= DecryptAesGcm;
            decryptDataDelegate(key, ivSpan, ciphertextSpan, tagSpan, plaintextSpan);
            return new PacketReader(result);
            }

        #endregion
        }

    }
