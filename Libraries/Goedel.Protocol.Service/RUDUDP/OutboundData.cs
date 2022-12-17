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

//namespace Goedel.Protocol.Service;

///// <summary>
///// Record specifying new data to be sent
///// </summary>
//public record OutboundData {

//    ///<summary></summary> 
//    public List<OutboundItem> OutboundItems { get; } = new();

//    ///<summary></summary> 
//    public bool HasPending => OutboundItems.Count > 0;

//    /// <summary>
//    /// Queue connection request.
//    /// </summary>
//    /// <param name="connectionId">The connection identifier.</param>
//    public void OpenConnection(PacketConnection connectionId) => OutboundItems.Add(
//        new OutboundItemConnection() {
//            ConnectionId = connectionId
//            });

//    /// <summary>
//    ///  Queue acknowledgement request.
//    /// </summary>
//    /// <param name="connectionId">The connection identifier.</param>
//    /// <param name="packetId">The packet being acknowledged.</param>
//    public void Acknowledge(PacketConnection connectionId, uint packetId) => OutboundItems.Add(
//        new OutboundItemAcknowledge() {
//            ConnectionId = connectionId,
//            PacketId = packetId
//            });

//    /// <summary>
//    /// Queue stream creation request.
//    /// </summary>
//    /// <param name="connectionId">The connection identifier.</param>
//    /// <param name="streamId">The stream identifier.</param>
//    public void OpenStream(PacketConnection connectionId, PacketStream streamId) => OutboundItems.Add(
//        new OutboundItemStream() {
//            ConnectionId = connectionId,
//            StreamId = streamId
//            });

//    /// <summary>
//    /// Queue data post request.
//    /// </summary>
//    /// <param name="connectionId">The connection identifier.</param>
//    /// <param name="streamId">The stream identifier.</param>
//    /// <param name="data">The data to post.</param>
//    public void Post(PacketConnection connectionId, PacketStream streamId, byte[] data) => OutboundItems.Add(
//        new OutboundItemPost() {
//            ConnectionId = connectionId,
//            StreamId = streamId,
//            Data = data
//            });


//    }

///// <summary>
///// Base type for outbound data tasks.
///// </summary>
//public abstract record OutboundItem (
//            ) {
//    ///<summary>The connection identifier.</summary> 
//    public PacketConnection ConnectionId { get; init; }
//    }

///// <summary>
///// Queue connection request.
///// </summary>
//public record OutboundItemConnection : OutboundItem {
//    }

///// <summary>
///// Queue acknowledgement request.
///// </summary>
//public record OutboundItemAcknowledge : OutboundItem  {
//    ///<summary>The packet being acknowledged modulo the packet identifier 
//    ///field length.</summary> 
//    public uint PacketId;
//    }

///// <summary>
///// Queue stream creation request.
///// </summary>
//public record OutboundItemStream : OutboundItem {
//    ///<summary>The stream identifier.</summary> 
//    public PacketStream StreamId;
//    }

///// <summary>
///// Queue data post request.
///// </summary>
//public record OutboundItemPost : OutboundItemStream {
//    ///<summary>The data to post.</summary> 
//    public byte[] Data;
//    }