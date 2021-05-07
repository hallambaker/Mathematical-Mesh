using System;
using System.Collections.Generic;
using System.IO;
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
    /// Factory method delegate for <see cref="PacketWriter"/>
    /// </summary>
    /// <param name="packetSize">The number of bytes in the packet to be created.</param>
    /// <param name="buffer">Buffer provided by caller</param>
    /// <param name="position">Offset within packet at which first byte is to be written.</param>
    /// <returns>The created instance.</returns>
    public delegate PacketWriter PacketWriterFactoryDelegate(
                    PacketWriter parent=null);


    /// <summary>
    /// Base class for packet writers.
    /// </summary>
    public class PacketWriter : Disposable {
        #region // Properties
        ///<summary>Position of the writer within the packet.</summary> 
        public long Position => MemoryStream.Position;

        ///<summary>The Packet data</summary> 
        public byte[] Packet => MemoryStream.ToArray();


        public MemoryStream MemoryStream { get; }

        /////<summary>Size of the largest encrypted block that can be inserted into
        /////the writer.</summary> 
        //public virtual int RemainingSpace => Packet.Length - Position;

        #endregion
        #region // Constructors
        /// <summary>
        /// Constructor, create a packet writer with a packet size of 
        /// <paramref name="packetSize"/>.
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        public PacketWriter( PacketWriter parent = null) {
            MemoryStream = new MemoryStream(Constants.MinimumPacketSize);

            //Packet = new byte[parent?.RemainingSpace ?? 1200];
            //Position = 0;
            }



        /// <summary>
        /// Factory method returning instance of <see cref="PacketWriterAesGcm"/>
        /// </summary>
        /// <param name="packetSize">The number of bytes in the packet to be created.</param>
        /// <param name="buffer">Buffer provided by caller</param>
        /// <param name="position">Offset within packet at which first byte is to be written.</param>
        /// <returns>The created instance.</returns>
        public static PacketWriter Factory(
                    PacketWriter parent = null) => new PacketWriter(parent);


        #endregion
        #region // Methods 
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
        /// Write InitiatorMessageType as a byte to the packet
        /// </summary>
        /// <param name="b"></param>
        public virtual void Write(InitiatorMessageType b) => MemoryStream.WriteByte((byte)b);
            //Packet[Position++] = (byte)b;

        /// <summary>
        /// Write ResponderMessageType as a byte to the packet
        /// </summary>
        /// <param name="b"></param>
        public virtual void Write(ResponderMessageType b) => MemoryStream.WriteByte((byte)b); 
            //Packet[Position++] = (byte)b;


        /// <summary>
        /// Write a byte to the packet
        /// </summary>
        /// <param name="b"></param>
        void Write(byte b) => MemoryStream.WriteByte((byte)b);
            //Packet[Position++] = b;

        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production.
        /// </summary>
        /// <param name="tag">Base code.</param>
        /// <param name="data">Length of data to follow.</param>
        void WriteTag(PacketTag tag, long data) {

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
            MemoryStream.Write(data, offset, count);

            //Buffer.BlockCopy(data, offset, Packet, Position, count);
            //Position += data.Length;
            }


        /// <summary>
        /// Write out the destination stream Id.
        /// </summary>
        /// <param name="data"></param>
        public virtual void WriteStreamId(byte[] data) {
            data ??= Constants.StreamIdClientInitial;
            // We could just increment Position, but the buffer might not be clean on entry.
            // This is the safest approach.
            MemoryStream.Write(data, 0, data.Length);


            //Buffer.BlockCopy(data, 0, Packet, Position, data.Length);
            //Position += data.Length;
            }

        //public void Write(byte data) {
        //    Packet[Position] = data;
        //    Position++;
        //    }

        /// <summary>
        ///Write the positive integer <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public virtual void Write(int data) => WriteTag((byte)PacketTag.Integer, data);

        /// <summary>
        /// Write the binary data <paramref name="data"/> to the packet.
        /// </summary>
        /// <param name="data">The data to write</param>
        public virtual void Write(byte[] data) {
            if (data == null) {
                WriteTag(PacketTag.Binary, 0);
                }
            else {
                Write(PacketTag.Binary, data, 0, data.Length);
                }
            }


        /// <summary>
        ///Write the string <paramref name="data"/> to the packet
        /// </summary>
        /// <param name="data">The data to write</param>
        public virtual void Write(string data) {
            var buffer = data.ToUTF8();
            Write(PacketTag.String, buffer, 0, buffer.Length);
            }


        /// <summary>
        /// Write the list of extensions <paramref name="extensions"/> to the packet.
        /// </summary>
        /// <param name="extensions">The extensions to write.</param>
        public virtual void WriteExtensions(List<PacketExtension> extensions=null) {

            if (extensions != null) {
                //WriteTag(PacketTag.Extensions, 0);
                //return;


                //WriteTag(PacketTag.Extensions, extensions.Count);


                foreach (var option in extensions) {
                    Write(option.Tag);
                    Write(option.Value);
                    }
                }
            Write("");
            }


        private Span<byte> GetSpan(long start, long length) {
            Screen.WriteLine($"{start} for {length}");
            
            return new Span<byte>(MemoryStream.GetBuffer(), (int)start, (int)length);
            }

        private ReadOnlySpan<byte> GetReadOnlySpan(long start, long length) {
            Screen.WriteLine($"{start} for {length}");
            return new ReadOnlySpan<byte>(MemoryStream.GetBuffer(), (int)start, (int)length);
            }
        ///<inheritdoc/>
        public virtual void Encrypt(byte[] key, PacketWriter writerIn, bool pad=true) {
            Screen.WriteLine($"Encrypt Key {key.ToStringBase16()}");
            var aes = new AesGcm(key);

            Screen.Write("Auth: ");
            var authSpan = GetSpan(0, MemoryStream.Position);

            var iv = Platform.GetRandomBytes(Constants.SizeIvAesGcm);
            MemoryStream.Write(iv, 0, iv.Length);

            Screen.Write("IV: ");
            var ivSpan = GetReadOnlySpan(MemoryStream.Position- Constants.SizeIvAesGcm, Constants.SizeIvAesGcm);


            long lengthCiphertext;
            if (pad) {
                lengthCiphertext = (int)writerIn.MemoryStream.Position;
                var unpaddedLength = MemoryStream.Position + lengthCiphertext + Constants.SizeTagAesGcm;


                var padBytes = unpaddedLength < Constants.MinimumPacketSize ?
                     Constants.MinimumPacketSize - unpaddedLength : 0;


                lengthCiphertext += padBytes;

                writerIn.MemoryStream.SetLength(lengthCiphertext);
                writerIn.MemoryStream.Position = lengthCiphertext;

                }
            else {
                lengthCiphertext = (int)writerIn.MemoryStream.Position;
                Write((int)lengthCiphertext);
                }

            var totalLength = MemoryStream.Position + lengthCiphertext + Constants.SizeTagAesGcm;
            MemoryStream.SetLength(totalLength);


            Screen.Write("cipher: ");
            var ciphertextSpan = GetSpan(MemoryStream.Position, lengthCiphertext);


            Screen.Write("Plaintext: ");
            var plaintextSpan = writerIn.GetReadOnlySpan(0, lengthCiphertext);

            Screen.Write("Tag: ");
            var TagSpan = GetSpan(MemoryStream.Position + lengthCiphertext, Constants.SizeTagAesGcm);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, TagSpan, authSpan);
            MemoryStream.Position = totalLength;
            }

        ///<inheritdoc/>
        public virtual byte[] Wrap(byte[] streamId, byte[] key) {

            //Constants.Derive(ikm, out var nonce, out var iv, out var key);
            //Screen.WriteLine($"Encrypt Key {key.ToStringBase16()}");

            var resultLength = streamId.Length + Constants.SizeIvAesGcm + 
                    MemoryStream.Position + Constants.SizeTagAesGcm;

            var result = new byte[resultLength];

            // Copy the nonce.
            // NB, it is the responsibility of the caller to set the top bit to ensure the
            // packet is correctly identified as a data packet.

            Buffer.BlockCopy(streamId, 0, result, 0, streamId.Length);
            var count = streamId.Length;


            var aes = new AesGcm(key);

            var iv = Platform.GetRandomBytes(Constants.SizeIvAesGcm);
            var ivSpan = new ReadOnlySpan<byte>(iv);

            Buffer.BlockCopy(iv, 0, result, count, iv.Length);
            //Screen.WriteLine($"IvSpan {count}  {ivSpan.Length}");

            count += iv.Length;
            

            var length = result.Length - count - Constants.SizeTagAesGcm;
            var ciphertextSpan = new Span<byte>(result, count, length);
            //Screen.WriteLine($"Ciphertext {count} {length}");

            count += length;
            

            var tagSpan = new Span<byte>(result, count, Constants.SizeTagAesGcm);
            //Screen.WriteLine($"TagSpan {count} {tagSpan.Length}");

            var plaintextSpan = GetReadOnlySpan(0, MemoryStream.Position);
                //new ReadOnlySpan<byte>(Packet, 0, length);

            aes.Encrypt(ivSpan, plaintextSpan, ciphertextSpan, tagSpan);

            return result;
            }
        #endregion
        }
    }
