#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion






using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Service;



// Outbound packet.
public record PacketOutbound {


    ///<summary>The connection token size (16 bytes)</summary> 
    public const int ConnectionTokenSize = 16;

    ///<summary>Byte offset for the salt field (2 bytes)</summary> 
    public const int OffsetSalt = ConnectionTokenSize;

    ///<summary>Byte offset for the truncated serial field (2 bytes)</summary> 
    public const int OffsetSerial = OffsetSalt + 2;

    ///<summary>Byte offset for the expecting field (2 bytes)</summary> 
    public const int OffsetExpecting = OffsetSerial + 2;

    ///<summary>Byte offset for the acknowledgements field (2 bytes)</summary> 
    public const int OffsetAcknowledge = OffsetExpecting + 2;

    ///<summary>Byte offset for the reserved field (2 bytes)</summary> 
    public const int StartPayload = OffsetAcknowledge + 2;






    int writeIndex = StartPayload;
    int lastByte;

    int Space => lastByte-writeIndex;


    ///<summary>The packet plaintext data. This is retained in case the 
    ///packet needs to be resent.</summary> 
    public byte[] Plaintext { get; set; }

    /// <summary>
    /// Initialize a new outbound packet.
    /// </summary>
    /// <param name="length">The packet length in bytes.</param>
    public PacketOutbound(int length) {
        Plaintext = new byte[length];
        lastByte = length;
        }


    static int LengthOf(StreamId streamId) => LengthOf(streamId.Serial);

    static int LengthOf(ulong integer) {
        if (integer < 64) {
            return 1;
            }
        if (integer < 16384) {
            return 2;
            }
        if (integer < 1073741824) {
            return 4;
            }
        return 8;
        }

    void Write (ulong integer) {
        if (integer < 64) {
            Plaintext[writeIndex++] = (byte) integer;
            return;
            }
        if (integer < 16384) {
            Plaintext[writeIndex++] = (byte)(((integer >>8) & 0x3F) | 0x40);
            Plaintext[writeIndex++] = (byte)integer;
            return;
            }
        if (integer < 1073741824) {
            Plaintext[writeIndex++] = (byte)(((integer >> 24) & 0x3F) | 0x80);
            Plaintext[writeIndex++] = (byte)(integer >> 16);
            Plaintext[writeIndex++] = (byte)(integer >> 8);
            Plaintext[writeIndex++] = (byte)integer;
            return;
            }
        Plaintext[writeIndex++] = (byte)(((integer >> 56) & 0x3F) | 0xB0);
        Plaintext[writeIndex++] = (byte)(integer >> 48);
        Plaintext[writeIndex++] = (byte)(integer >> 40);
        Plaintext[writeIndex++] = (byte)(integer >> 32);
        Plaintext[writeIndex++] = (byte)(integer >> 24);
        Plaintext[writeIndex++] = (byte)(integer >> 16);
        Plaintext[writeIndex++] = (byte)(integer >> 8);
        Plaintext[writeIndex++] = (byte)integer;
    }

    void Write (PayloadTag payloadTag) => Write((ulong)payloadTag);

    void Write(StreamId streamId) => Write(streamId.Serial);

    void Write(byte[] data, int start, int length) {
        Write((ulong)length);
        Array.Copy(data, start, Plaintext, writeIndex, length);
        writeIndex += length;
        }

    /// <summary>
    /// Attempt to write an open stream request to the packet, returning 
    /// false if there is insufficient space.
    /// </summary>
    /// <param name="streamId">The stream to write to.</param>
    /// <param name="streamName">The stream label.</param>
    /// <returns>True if the action succeeded.</returns>
    public bool OpenStream(PendingStream pendingStream) {

        var streamId = pendingStream.StreamId;
        var streamName = pendingStream.Label;

        (streamName.Length < 64).AssertTrue(NYI.Throw);

        // is there enough space to add the request?
        if (LengthOpenStream(streamId,streamName) > Space) {
            return false;
            }
        Write(PayloadTag.StreamOpen);
        Write(streamId);
        Write(streamName, 0, streamName.Length);

        return true;
        }

    int LengthOpenStream (StreamId streamId, byte[] streamName) =>
        2 + LengthOf(streamId) + streamName.Length;


    /// <summary>
    /// Attempt to post <paramref name="length"/> bytes from <paramref name="data"/> 
    /// starting at byte <paramref name="start"/> and return the number of bytes
    /// written.
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="data"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    /// <returns>The number of bytes written. If zero, no bytes were written.</returns>
    public bool PostData(PendingPost pendingPost) {
        var streamId = pendingPost.PacketStream.StreamId;
        var data = pendingPost.Data;
        var start = pendingPost.Sent;
        var length = data.Length;

        var completed = false;

        PayloadTag payloadTag;

        // Check to see if there is enough space to be worth sending data.
        if (Space < 16) {
            return false;
            }

        if (start == 0) {
            if (1 + length + LengthOf((ulong)length) < Space) {
                payloadTag = PayloadTag.DataFull;
                completed = true;
                }
            else {
                payloadTag = PayloadTag.DataStart;
                length = Space - 3;

                }
            }
        else {
            payloadTag = PayloadTag.Data;
            if (3 + length < Space) {
                completed = true;
                }
            else {
                length = Space - 3;
                }
            }

        Write(payloadTag);
        Write(data, start, length);
        if (!completed) {
            pendingPost.Sent += length;
            }
        return completed;

        }



    public byte[] Encrypt(
            byte[] token,
            ulong serial,
            ulong expecting,
            ulong acknowledge,
            ICryptoTransform encryptor) {
        Array.Copy(token, Plaintext, ConnectionTokenSize);

        throw new NYI();

        }
    
    }




/// <summary>
/// The inbound packet data.
/// <para>
/// The inbound packet is constructed as follows:
/// </para>
/// <para>
/// Salt: 16 bytes. The salt value is used as an input to the
/// KDF to determine the decryption ke and to identify the
/// originator to the receiver. In this implementation, the 
/// salt is created by encrypting the 8 byte stream identifier
/// and an 8 byte nonce.
/// </para>
/// <para>
/// The rest of the packet is encrypted.
/// </para>
/// <para>
/// Sequence Counter: 
/// </para>
/// <para>
/// Outbound Pending: Hint telling the receiver how many more packets
/// are currently queued to be sent. It this value reaches zero, the
/// sender MUST stop sending packets until an acknowledgement is 
/// received.
/// </para>
/// <para>
/// Expecting: The sequence identifier of the earliest packet that
/// has not (yet) been received.
/// </para>
/// <para>
/// Acknowledgements: A sequence of 0-15 bytes reporting receipt of 
/// packets sent after the packet [Expecting], 1=received.
/// </para>
/// <para>
/// Chunk Identifiers: A sequence of 0-15 StreamID/Length specifiers.
/// </para>
/// <para>
/// Chunks
/// </para>
/// </summary>
public record InboundPacket {

    ///<summary>The received data.</summary> 
    public UdpReceiveResult UdpReceiveResult { get; }

    ///<summary>The stream identifier assigned by the receiver endpoint.</summary> 
    public ConnectionId ConnectionId { get; set; }

    ///<summary>The first block of the inbound packet decrypted under the common key.</summary> 
    public byte[] PlaintextPrefix { get; }

    ///<summary></summary> 
    public bool IsInitial => ConnectionId.IsInitial;

    /// <summary>
    /// Constructor, returns an instance using data extracted from <paramref name="udpReceiveResult"/>
    /// with the <see cref="PlaintextPrefix"/> and <see cref="ConnectionId"/> properties initialized 
    /// from values extracted from the first encryption block, decrypted using 
    /// <paramref name="decryptor"/>.
    /// </summary>
    /// <param name="udpReceiveResult">The UDP packet received.</param>
    /// <param name="decryptor">The block decryptor.</param>
    public InboundPacket(
            UdpReceiveResult udpReceiveResult,
            ICryptoTransform decryptor
            ) {

        var connectionTokenLength = decryptor.InputBlockSize;

        if (udpReceiveResult.Buffer == null ||
            udpReceiveResult.Buffer.Length < connectionTokenLength) {

            ConnectionId = ConnectionId.Invalid;
            PlaintextPrefix = null;
            return;
            }

        if (IsInitialPacket(udpReceiveResult.Buffer, connectionTokenLength)) {
            ConnectionId = ConnectionId.Initial;
            }
        else {
            // Decrypt the first block to determine the stream identifier.
            PlaintextPrefix = new byte[decryptor.OutputBlockSize];
            decryptor.TransformBlock(udpReceiveResult.Buffer, 0, decryptor.InputBlockSize,
                PlaintextPrefix, 0);

            ConnectionId = new ConnectionId(PlaintextPrefix);
            }
        }

    static bool IsInitialPacket(byte[] packet, int length) {
        for (int i = 0; i < length; i++) {
            if (packet[i] != 0) {
                return false;
                }
            }
        return true;
        }


    }


/// <summary>
/// Buffer used to build an inbound message.
/// </summary>
public record BufferedMessage {

    ///<summary>If true, the complete message has been received.</summary> 
    public bool IsComplete => Last == MessageData.Length;

    /// <summary>Index of the last byte sent or received.</summary>
    public int Last { get; set; } = 0;

    ///<summary>The consolidated message data.</summary> 
    public byte[] MessageData;

    /// <summary>
    /// Constructor creating a instance to receive an inbound message 
    /// of <paramref name="length"/> bytes.
    /// </summary>
    /// <param name="length">Length of the buffer to reserve in bytes.</param>
    public BufferedMessage(int length) => MessageData = new byte[length];

    /// <summary>
    /// Copnstructor returning an instance to send an outbound message with
    /// the data <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The data to be sent.</param>
    public BufferedMessage(byte[] data) => MessageData = data;

    }

public record MessageToService {

    public byte[] Data { get; init; }
    public PacketConnection ConnectionId { get; init; }
    public PacketStream StreamId { get; init; }

    }


