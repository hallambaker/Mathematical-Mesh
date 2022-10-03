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






namespace Goedel.Protocol.Service;

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


