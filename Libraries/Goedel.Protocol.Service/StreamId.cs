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


using Goedel.Cryptography.Standard;

namespace Goedel.Protocol.Service;


/// <summary>
/// Stream identifier.
/// </summary>
public record StreamId {

    ///<summary>The serial number.</summary> 
    public ulong Serial { get; protected set; }


    /// <summary>
    /// Constrructor, returns an instance with serial number value 
    /// <paramref name="serial"/>.
    /// </summary>
    /// <param name="serial"></param>
    public StreamId (ulong serial) => Serial = serial;


    }

/// <summary>
/// 
/// </summary>
public record StreamIdGenerator : StreamId {


    /// <summary>
    /// Return a new generator for <see cref="StreamId"/> instances. If the value
    /// <paramref name="initiator"/> is true, the stream identifier valuies will
    /// always be even. Otherwise, the stream identifier values will be odd. The 
    /// identifiers returned will always be greater than 0.
    /// </summary>
    /// <param name="initiator">If true, the stream identifiers generated will be
    /// for the connection initiator sid, i.e. even. Otherwise, the identifiers
    /// will be odd.</param>
    public StreamIdGenerator(bool initiator) : base ((ulong)(initiator ? 2 : 1)) {
        }

    /// <summary>
    /// Return the next serial number and increment the generator value by 2.
    /// </summary>
    /// <returns>The stream identifier created.</returns>
    public StreamId GetNext() {
        lock (this) {
            var serial = Serial;
            Serial += 2;
            return new StreamId (serial);
            }
        }


    }



/// <summary>
/// Handle for interaction with a particular stream within a connection.
/// </summary>
public class PacketStream {

    ///<summary>The connection under which this stream is established.</summary> 
    public PacketConnection PacketConnection { get; init;}

    ///<summary>The outbound stream, which is always assigned by the local end
    ///of the connection.</summary> 
    public StreamId StreamId { get; init; }



    // NO!!!! The party that created the connection owns stream ids 0..MAXINT/2 and the
    // other side owns MAXINT/2..X


    ///<summary>The inbound message block. Consumers of the stream MAY obtain more
    ///detailed information on the inbound messages by consuming messages 
    ///directly from the buffer rather than as raw bytes returned by
    ///<see cref="ReadBytesAsync"/>.</summary> 
    public BufferBlock<BufferedMessage> MessageBuffer { get; init; }

    /// <summary>
    /// Queue the data <paramref name="data"/> to be sent out on the stream.
    /// </summary>
    /// <param name="data">The data to send</param>
    public async Task Post(byte[] data) {
        var message = new PendingPost(this, data) {
            };
        await PacketConnection.CommitAsync( message);
        }

    /// <summary>
    /// Read bytes from the 
    /// </summary>
    /// <returns></returns>
    public async Task<byte[]> ReadBytesAsync() {
        var message = await MessageBuffer.ReceiveAsync();
        return message.MessageData;
        }



    }
