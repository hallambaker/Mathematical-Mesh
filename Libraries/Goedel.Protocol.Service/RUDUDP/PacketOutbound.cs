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


//namespace Goedel.Protocol.Service;

///// <summary>
///// Outbound packet record.Containst write methods.
///// </summary>
//public record PacketOutbound : PacketUDP {

//    ///<summary>The last time this packet was sent.</summary> 
//    public ulong TimeSent { get; private set; }

//    ///<summary>Time at which this packet will be overdue.</summary> 
//    public ulong TimeOverdue { get; private set; }


//    int writeIndex = StartPayload;
//    int lastByte;

//    int Space => lastByte-writeIndex;




//    /// <summary>
//    /// Initialize a new outbound packet.
//    /// </summary>
//    /// <param name="length">The packet length in bytes.</param>
//    public PacketOutbound(int length) {
//        Plaintext = new byte[length];
//        lastByte = length;
//        }


//    static int LengthOf(StreamId streamId) => LengthOf(streamId.Serial);

//    static int LengthOf(ulong integer) {
//        if (integer < 64) {
//            return 1;
//            }
//        if (integer < 16384) {
//            return 2;
//            }
//        if (integer < 1073741824) {
//            return 4;
//            }
//        return 8;
//        }

//    void Write (ulong integer) {
//        if (integer < 64) {
//            Plaintext[writeIndex++] = (byte) integer;
//            return;
//            }
//        if (integer < 16384) {
//            Plaintext[writeIndex++] = (byte)(((integer >>8) & 0x3F) | Integer2);
//            Plaintext[writeIndex++] = (byte)integer;
//            return;
//            }
//        if (integer < 1073741824) {
//            Plaintext[writeIndex++] = (byte)(((integer >> 24) & 0x3F) | Integer4);
//            Plaintext[writeIndex++] = (byte)(integer >> 16);
//            Plaintext[writeIndex++] = (byte)(integer >> 8);
//            Plaintext[writeIndex++] = (byte)integer;
//            return;
//            }
//        Plaintext[writeIndex++] = (byte)(((integer >> 56) & 0x3F) | Integer8);
//        Plaintext[writeIndex++] = (byte)(integer >> 48);
//        Plaintext[writeIndex++] = (byte)(integer >> 40);
//        Plaintext[writeIndex++] = (byte)(integer >> 32);
//        Plaintext[writeIndex++] = (byte)(integer >> 24);
//        Plaintext[writeIndex++] = (byte)(integer >> 16);
//        Plaintext[writeIndex++] = (byte)(integer >> 8);
//        Plaintext[writeIndex++] = (byte)integer;
//    }

//    void Write (PayloadTag payloadTag) => Write((ulong)payloadTag);

//    void Write(StreamId streamId) => Write(streamId.Serial);

//    void Write(byte[] data, int start, int length) {
//        Write((ulong)length);
//        Array.Copy(data, start, Plaintext, writeIndex, length);
//        writeIndex += length;
//        }

//    /// <summary>
//    /// Attempt to write an open stream request to the packet, returning 
//    /// false if there is insufficient space.
//    /// </summary>
//    /// <param name="streamId">The stream to write to.</param>
//    /// <param name="streamName">The stream label.</param>
//    /// <returns>True if the action succeeded.</returns>
//    public bool OpenStream(PendingStream pendingStream) {

//        var streamId = pendingStream.StreamId;
//        var streamName = pendingStream.Label;

//        (streamName.Length < 64).AssertTrue(NYI.Throw);

//        // is there enough space to add the request?
//        if (LengthOpenStream(streamId,streamName) > Space) {
//            return false;
//            }
//        Write(PayloadTag.StreamOpen);
//        Write(streamId);
//        Write(streamName, 0, streamName.Length);

//        return true;
//        }

//    int LengthOpenStream (StreamId streamId, byte[] streamName) =>
//        2 + LengthOf(streamId) + streamName.Length;


//    /// <summary>
//    /// Attempt to post date described by <paramref name="pendingPost"/> and return the 
//    /// number of bytes
//    /// written.
//    /// </summary>
//    /// <param name="pendingPost">Contains the data to post.</param>
//    /// <returns>The number of bytes written. If zero, no bytes were written.</returns>
//    public bool PostData(PendingPost pendingPost) {
//        var streamId = pendingPost.PacketStream.StreamId;
//        var data = pendingPost.Data;
//        var start = pendingPost.Sent;
//        var length = data.Length;

//        var completed = false;

//        PayloadTag payloadTag;

//        // Check to see if there is enough space to be worth sending data.
//        if (Space < 16) {
//            return false;
//            }


//        if (start == 0) {
//            if (1 + length + LengthOf((ulong)length) < Space) {
//                payloadTag = PayloadTag.DataFull;
//                Write(payloadTag);
//                completed = true;
//                }
//            else {
//                payloadTag = PayloadTag.DataStart;
//                Write(payloadTag);
//                length = Space - 3;
//                }
//            }
//        else {
//            payloadTag = PayloadTag.Data;
//            if (3 + length < Space) {
//                completed = true;
//                }
//            else {
//                length = Space - 3;
//                }
//            Write(payloadTag);
//            }

//        Write(streamId);


//        Write(data, start, length);
//        if (!completed) {
//            pendingPost.Sent += length;
//            }
//        return completed;

//        }

//    /// <summary>
//    /// Complete the packet data. This will typically involve padding the end of
//    /// the packet with as many connection tokens as will fit.
//    /// </summary>
//    public void Pad() {
//        Write(PayloadTag.EndOfPayload);
//        }

//    /// <summary>
//    /// Create an encrypted packet using the connection token <paramref name="token"/>.
//    /// </summary>
//    /// <param name="token">The connection token.</param>
//    /// <param name="serial">The packet serial number (long form)</param>
//    /// <param name="expecting">The next packet expected.</param>
//    /// <param name="acknowledge">Acknowledgement vector.</param>
//    /// <param name="encryptor">Encryption provider.</param>
//    /// <returns></returns>
//    public byte[] Encrypt(
//            byte[] token,
//            ulong serial,
//            ulong expecting,
//            ulong acknowledge,
//            ICryptoTransform encryptor) {
//        Array.Copy(token, Plaintext, ConnectionTokenLength);

//        throw new NYI();

//        }

//    }


