//#region // Copyright - MIT License
////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
//#endregion






//using Goedel.Protocol.Presentation;
//using System.Collections.Generic;

//namespace Goedel.Protocol.Service;



///// <summary>
///// Inbound packet record.Containst parse methods.
///// </summary>

//public record PacketInbound : PacketUDP {

//    ///<summary>The received data.</summary> 
//    public UdpReceiveResult UdpReceiveResult { get; }

//    ///<summary>The stream identifier assigned by the receiver endpoint.</summary> 
//    public ConnectionId ConnectionId { get; set; }

//    ///<summary>The first block of the inbound packet decrypted under the common key.</summary> 
//    public byte[] PlaintextPrefix { get; }


//    ///<summary>The truncated serial number.</summary> 
//    public ushort Serial { get; private set; }

//    ///<summary>The truncated expected serial number.</summary> 
//    public ushort Expecting { get; private set; }

//    ///<summary>The acknowledgement field.</summary> 
//    public ushort Acknowledge { get; private set; }

//    ///<summary>The time at which the packet was received.</summary> 
//    public long Received { get; }
//    int readPointer;


//    /// <summary>
//    /// Constructor, returns an instance using data extracted from <paramref name="udpReceiveResult"/>
//    /// with the <see cref="PlaintextPrefix"/> and <see cref="ConnectionId"/> properties initialized 
//    /// from values extracted from the first encryption block, decrypted using 
//    /// <paramref name="decryptor"/>.
//    /// </summary>
//    /// <param name="udpReceiveResult">The UDP packet received.</param>
//    /// <param name="decryptor">The block decryptor.</param>
//    public PacketInbound(
//            UdpReceiveResult udpReceiveResult,
//            ICryptoTransform decryptor
//            ) {
//        UdpReceiveResult = udpReceiveResult;
//        Received = DateTime.Now.Ticks;

//        var connectionTokenLength = decryptor.InputBlockSize;

//        if (udpReceiveResult.Buffer == null ||
//            udpReceiveResult.Buffer.Length < connectionTokenLength) {

//            ConnectionId = ConnectionId.Invalid;
//            PlaintextPrefix = null;
//            return;
//            }

//        if (IsInitialPacket(udpReceiveResult.Buffer, connectionTokenLength)) {
//            ConnectionId = ConnectionId.Initial;
//            }
//        else {
//            // Decrypt the first block to determine the stream identifier.
//            PlaintextPrefix = new byte[decryptor.OutputBlockSize];
//            decryptor.TransformBlock(udpReceiveResult.Buffer, 0, decryptor.InputBlockSize,
//                PlaintextPrefix, 0);

//            ConnectionId = new ConnectionId(PlaintextPrefix);
//            }
//        }

//    static bool IsInitialPacket(byte[] packet, int length) {
//        for (int i = 0; i < length; i++) {
//            if (packet[i] != 0) {
//                return false;
//                }
//            }
//        return true;
//        }

//    byte ReadByte() => Plaintext[readPointer++];

//    ushort ReadInt16() => (ushort) (ReadByte() << 8 | ReadByte());


//    ulong ReadByteLong() => Plaintext[readPointer++];


//    int Space => Plaintext.Length - readPointer;


//    int ReadInt() => (int)ReadLong();
//    ulong ReadLong() {
//        var first = ReadByteLong();
//        var length = first & IntegerMask;
//        var result = (ulong) first & IntegerFirst;


//        var lengthTag = length switch {
//            Integer1 => 1,
//            Integer2 => 2,
//            Integer4 => 4,
//            _ => 8,
//            };
//        (Space >= lengthTag).AssertTrue(NYI.Throw);

//        return length switch {
//            Integer1 => result,
//            Integer2 => result << 8 | ReadByteLong(),
//            Integer4 => result << 24 | ReadByteLong() << 16 | ReadByteLong() << 8 | ReadByteLong(),
//            _ => result << 56 | ReadByteLong() << 48 | ReadByteLong() << 40 | ReadByteLong() << 32 |
//                    ReadByteLong() << 24 | ReadByteLong() << 16 | ReadByteLong() << 8 | ReadByteLong()
//            };
//        }

//    byte[] ReadLabel() {
//        var length = ReadByte();
//        var result = new byte[length];
//        Array.Copy(Plaintext, readPointer, result, 0, length);
//        readPointer += length;

//        return result;
//        }


//    void ReadData(byte[] data, int start, ulong length) {


//        throw new NYI();
//        }


//    StreamId ReadStreamId() => new StreamId(ReadLong());





//    //ulong ReadByte() => Plaintext[readPointer++];
//    public void ParseHeader(ICryptoTransform decryptor) {
//        Plaintext = UdpReceiveResult.Buffer;

//        // The salt contains no information so we simply ignore it.
//        readPointer = OffsetSerial;

//        Serial = ReadInt16();
//        Expecting = ReadInt16();
//        Acknowledge = ReadInt16();

//        }

//    public bool GetChunk(PacketConnection packetConnection) {

//        var tag = ReadLong();

//        switch (tag) {
//            case (ulong)PayloadTag.StreamOpen: {

//                var streamId = ReadStreamId();
//                var label = ReadLabel();
//                packetConnection.Deliver(streamId, label);

//                break;
//                }

//            case (ulong)PayloadTag.DataFull: {


//                var streamId = ReadStreamId();
//                var length = ReadInt();

//                if (packetConnection.TryGetStream(streamId, out var stream)) {
//                    stream.Deliver(Plaintext, readPointer, length);
//                    }
//                else {
//                    packetConnection.Error(PendingItem.PendingInvalidStream);
//                    }
//                readPointer += length;
//                Console.WriteLine("Data full");
//                break;
//                }
//            case (ulong)PayloadTag.DataStart:
//            case (ulong)PayloadTag.DataStartChunked: {
//                var streamId = ReadStreamId();
//                var total = ReadInt();
//                var length = ReadInt();
//                var chunked = tag == (ulong)PayloadTag.DataStartChunked;

//                if (packetConnection.TryGetStream(streamId, out var stream)) {
//                    stream.Start(total, chunked, Plaintext, readPointer, length);
//                    }
//                else {
//                    packetConnection.Error(PendingItem.PendingInvalidStream);
//                    }

//                readPointer += length;

//                break;
//                }

//            case (ulong)PayloadTag.Data:
//            case (ulong)PayloadTag.DataLast: {
//                var streamId = ReadStreamId();
//                var total = ReadInt();
//                var length = ReadInt();
//                var last = tag == (ulong)PayloadTag.DataLast;

//                if (packetConnection.TryGetStream(streamId, out var stream)) {
//                    stream.Data(last, Plaintext, readPointer, length);
//                    }
//                else {
//                    packetConnection.Error(PendingItem.PendingInvalidStream);
//                    }

//                readPointer += length;

//                break;
//                }
//            case (ulong)PayloadTag.DataAbort: {
//                var streamId = ReadStreamId();
//                if (packetConnection.TryGetStream(streamId, out var stream)) {
//                    stream.Abort();
//                    }
//                else {
//                    packetConnection.Error(PendingItem.PendingInvalidStream);
//                    }
//                break;
//                }


//            case (ulong)PayloadTag.ConnectionTokensIssue: {
//                break;
//                }


//            case (ulong)PayloadTag.EndOfPayload: {
//                return false;
//                }

//            default: {
//                break;

//                }
//            }
//        return true;
//        }

//    }

///// <summary>
///// Message data response record. Introducing this structure allows handling of 
///// chunked streams and a means of eventually substituting in the ability to
///// return a reader over the raw packet data so as to avoid repeated copying.
///// </summary>
//public record MessageData {

//    ///<summary>The message data.</summary> 
//    public byte[] Data;

//    ///<summary>If true, this is one of a series of chunks.</summary> 
//    public bool IsChunked;

//    ///<summary>If true, this is the last chunk (always true for non chunked data).</summary> 
//    public bool IsLast;

//    }


/////// <summary>
/////// Buffer used to build an inbound message.
/////// </summary>
////public record BufferedMessage {

////    ///<summary>If true, the complete message has been received.</summary> 
////    public bool IsComplete => Last == MessageData.Length;

////    /// <summary>Index of the last byte sent or received.</summary>
////    public int Last { get; set; } = 0;

////    ///<summary>The consolidated message data.</summary> 
////    public byte[] MessageData;

////    /// <summary>
////    /// Constructor creating a instance to receive an inbound message 
////    /// of <paramref name="length"/> bytes.
////    /// </summary>
////    /// <param name="length">Length of the buffer to reserve in bytes.</param>
////    public BufferedMessage(int length) => MessageData = new byte[length];

////    /// <summary>
////    /// Copnstructor returning an instance to send an outbound message with
////    /// the data <paramref name="data"/>.
////    /// </summary>
////    /// <param name="data">The data to be sent.</param>
////    public BufferedMessage(byte[] data) => MessageData = data;

////    }

////public record MessageToService {

////    public byte[] Data { get; init; }
////    public PacketConnection ConnectionId { get; init; }
////    public PacketStream StreamId { get; init; }

////    }


