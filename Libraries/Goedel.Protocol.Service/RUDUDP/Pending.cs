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
///// Manage a list of pending requests to a connection.
///// </summary>
///// <param name="PacketConnection">The connection the requests are to be queued to.</param>
///// <param name="Priority">The priority of the request set, higher values 
///// indicate higher priority.</param>
//public record Pending(
//            PacketConnection PacketConnection,
//            int Priority = 0) {

//    ///<summary>List of pending items.</summary> 
//    List<PendingItem> PendingItems { get; } = new();

//    /// <summary>
//    /// Assign a ne stream identifier and queue a request to use that identifier.
//    /// </summary>
//    /// <param name="serviceId">Optional </param>
//    /// <returns></returns>
//    public PacketStream OpenOutboundStreamPending(
//                string? serviceId = null) {
//        var streamId = PacketConnection.StreamIdGenerator.GetNext();
//        var label = (serviceId ?? "").ToUTF8();

//        var packetStream = new PacketStream() {
//            PacketConnection = PacketConnection,
//            StreamId = streamId,
//            };
//        PendingItems.Add(new PendingStream(streamId, label, packetStream));
//        return packetStream;
//        }

//    /// <summary>
//    /// Post the data packet <paramref name="data"/> to the stream
//    /// <paramref name="stream"/>.
//    /// </summary>
//    /// <param name="stream">The stream to post to.</param>
//    /// <param name="data">The data to post.</param>
//    public void Post(PacketStream stream, byte[] data) {
//        PendingItems.Add(new PendingPost(stream, data));
//        }

//    /// <summary>
//    /// Commit the list of requests to the connection.
//    /// </summary>
//    public async Task CommitAsync() => await PacketConnection.CommitAsync(PendingItems);
//    }

///// <summary>
///// Base record for pending outbound items.
///// </summary>
//public record PendingItem {
//    public readonly static PendingInvalidStream PendingInvalidStream = new PendingInvalidStream();
//    }

///// <summary>
///// Payload marking the end of the payload data section.
///// </summary>
//public record PendingEnd : PendingItem {

//    public readonly static PendingEnd Empty = new PendingEnd();
//    }

///// <summary>
///// Unknown / unsupported payload.
///// </summary>
//public record PendingUnknown : PendingItem {

//    public readonly static PendingUnknown Empty = new PendingUnknown();

//    }

///// <summary>
///// Unknown / unsupported payload.
///// </summary>
//public record PendingInvalidStream : PendingItem {

//    }



///// <summary>
///// Pending stream assignment request.
///// </summary>
///// <param name="StreamId">The stream identifier to assign.</param>
///// <param name="PacketStream">The handle for the stream.</param>
///// <param name="Label">The stream label, (must be less than 64 bytes)</param>
//public record PendingStream(
//            StreamId StreamId,
//            byte[] Label,
//            PacketStream PacketStream) : PendingItem {

//    }

///// <summary>
///// Pending data post assignment.
///// </summary>
///// <param name="PacketStream">The stream to post to.</param>
///// <param name="Data">The data to post.</param>
//public record PendingPost(
//            PacketStream PacketStream,
//            byte[] Data) : PendingItem {

//    ///<summary>The message index to send.</summary> 
//    public int Sent = 0;

//    }