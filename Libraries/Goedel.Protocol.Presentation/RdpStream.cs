//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Utilities;

using System.Collections.Generic;
//using Goedel.Protocol.Service;
using System.IO;
using System.Threading.Tasks;


namespace Goedel.Protocol.Presentation {


    public struct DataGram {
        public byte[] Data;
        public bool IsFinal;
        }


    public delegate JsonObject TransactionPostDelegate(string tag, JsonObject request);

    public delegate void AsynchronousReceiveDelegate(DataGram dataGram);




    /// <summary>
    /// An RDP Stream
    /// </summary>
    public class RdpStream {
        #region // Properties
        ///<summary>The underlying connection</summary> 
        public virtual RdpConnection RdpConnection { get; }

        ///<summary>The child streams formed from this stream that MAY be rekeyed under this.</summary> 
        public List<RdpStream> ChildStreams;



        public RdpStream RdpStreamParent { get; }


        public bool Connected { get; private set; } = false;

        public string Protocol;

        public Credential Credential;

        ///<summary>The local stream Id, this is generated localy and MAY contain hidden structure.</summary> 
        public StreamId LocalStreamId { get; protected set; }


        byte[] RemoteStreamId;


        #endregion
        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> according to the stream role.
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rdpConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>
        public RdpStream(
                RdpStream parent,
                string protocol,
                Credential credential= null,
                RdpConnection rdpConnection=null) {
            Protocol = protocol;

            if (parent != null) {
                parent.AddChild(this);
                }

            RdpStreamParent = parent;
            RdpConnection = rdpConnection ?? parent.RdpConnection;
            Credential = credential;
            LocalStreamId = RdpConnection.GetStreamId();
            }

        #endregion




        #region // Methods


        public JsonObject Post(
            string tag,
            JsonObject request) {

            // Serialize request
            byte[] span = null;
            if (request != null) {
                span = SerializePayload(tag, request, out var stream);
                }

            var packet = Post(span);

            JsonObject response = null;
            if (packet?.Payload.Length > 0) {
                response = JsonObject.From(packet.Payload);
                }
            return response;
            }

        public Packet Post(byte[] span, List<PacketExtension> ciphertextExtensions = null) {
            byte[] encoded;
            if (Connected) {
                //var (buffer, offset) =  InitializeBuffer(span.Length);
                encoded = RdpConnection.SerializePacketData(span);

                }
            else {
                var buffer = new byte[Constants.MinimumPacketSize];

                ciphertextExtensions ??= new List<PacketExtension>();
                ciphertextExtensions.Add(LocalStreamId.PacketExtension);
                encoded = RdpConnection.SerializeClientCompleteDeferred(
                    LocalStreamId.GetValue(), RdpConnection.PacketChallenge.SourceId, span,
                    ciphertextExtensions: ciphertextExtensions, buffer: buffer);
                Connected = true;
                }


            // Transact
            var result = RdpConnection.Transact(encoded);
            result.Wait();
            var responsepacketData = result.Result;

            // Parse the response
            var (sourceId, offset2) = StreamId.GetSourceId(responsepacketData);

            var packet = RdpConnection.ParsePacketData(responsepacketData, offset2, responsepacketData.Length);
            if (!Connected) {
                GetSourceId(packet as PacketData);
                }

            return packet;
            }

        void GetSourceId(PacketData packet) {
            RemoteStreamId = PacketExtension.GetExtensionByTag(packet?.CiphertextExtensions,
                    Constants.StreamId);
            Connected = true;

            }


        private byte[] SerializePayload(string tag, JsonObject request, out MemoryStream stream) {
            stream = new MemoryStream();
            var writer = JsonObject.GetJsonWriter(RdpConnection.ObjectEncoding);
            writer.WriteObjectStart();

            bool first = true;
            request.Serialize(writer, true, ref first);
            writer.WriteToken(tag, 0);
            writer.WriteObjectEnd();

            // avoid the copy by using a Span.
            return stream.ToArray();
            }


        /// <summary>
        /// Perform a forward secrecy operation on the stream. If <paramref name="recurse"/> is
        /// true, the child streams will be marked to perform a rekey operation.
        /// </summary>
        /// <param name="recurse"></param>
        public void ForwardSecrecy(bool recurse) => throw new NYI();


        private void AddChild(RdpStream child) {
            ChildStreams.Add(child);
            }

        protected void RemoveChild(RdpStream child) {
            ChildStreams.Remove(child);
            }


        /// <summary>
        /// Request creation of a transactional stream in the client role.
        /// </summary>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamClient MakeStreamClient(Credential credential=null) => throw new NYI();


        /// <summary>
        /// Request creation of an asynchronous stream in the sender role.
        /// </summary>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamClient MakeStreamSender(Credential credential = null) => throw new NYI();

        /// <summary>
        /// Request creation of a transactional stream in the server role
        /// </summary>
        /// <param name="transactionPostDelegate">Optional delegate to be called when a request is received.</param>
        /// <returns>The created stream.</returns>
        public RdpStreamService MakeStreamService(TransactionPostDelegate transactionPostDelegate = null) => throw new NYI();


        /// <summary>
        /// Request creation of an asynchronous stream in the receiver role.
        /// </summary>
        /// <param name="asynchronousReceiveDelegate">Optional delegate to be called when data is received.</param>
        /// <returns></returns>
        public RdpStreamReceiver MakeStreamReceiver(AsynchronousReceiveDelegate asynchronousReceiveDelegate = null) => throw new NYI();

        /// <summary>
        /// Cause queued requests to be flushed.
        /// </summary>
        public void Flush () => throw new NYI();

        public async Task<RdpStream> AsyncReceiveStreamOffer() => throw new NYI();

        #endregion

        }


    /// <summary>
    /// The client side of an RDP transactional stream.
    /// </summary>
    public class RdpStreamClient : RdpStream, IJpcSession {
        #region // Properties



        #endregion
        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> 
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rdpConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

        public RdpStreamClient(
                RdpStream parent,
                string protocol,
                Credential credential,
                RdpConnection rdpConnection = null) : base(parent, protocol, credential, rdpConnection) {



            }

        #endregion
        #region // Methods
        public VerifiedAccount VerifiedAccount => throw new System.NotImplementedException();

        public JsonObject Post(string tag, JsonObject request) => throw new System.NotImplementedException();


        public async Task<JsonObject> PostAsync(string tag, JsonObject request) => throw new System.NotImplementedException();
        #endregion
        }


    public class RdpStreamService : RdpStream {
        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> 
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rdpConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

        public RdpStreamService(
                RdpStream parent,
                string protocol,
                Credential credential,
                RdpConnection rdpConnection = null) : base(parent, protocol, credential, rdpConnection) {



            }
        #endregion


        #region // Methods
        public async Task<DataGram> AsyncRequestDatagram() => throw new NYI();

        public async Task<JsonObject> AsyncRequestObject() => throw new NYI();


        public void Respond (DataGram dataGram) => throw new NYI();


        public void Respond(JsonObject jsonObject) => throw new NYI();
        #endregion
        }



    public class RdpStreamSender: RdpStream {
        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> 
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rdpConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

        public RdpStreamSender(
                RdpStream parent,
                string protocol,
                Credential credential,
                RdpConnection rdpConnection = null) : base(parent, protocol, credential, rdpConnection) {



            }
        #endregion


        #region // Methods
        public async Task<DataGram> AsyncControlDatagram() => throw new NYI();

        public async void Send(DataGram dataGram) {

            }
        #endregion

        }


    public class RdpStreamReceiver: RdpStream {
        #region // Constructors

        /// <summary>
        /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
        /// protocol <paramref name="protocol"/> 
        /// </summary>
        /// <param name="parent">The parent stream</param>
        /// <param name="protocol">The stream protocol</param>
        /// <param name="credential">Optional additional credential.</param>
        /// <param name="rdpConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

        public RdpStreamReceiver(
                RdpStream parent,
                string protocol,
                Credential credential,
                RdpConnection rdpConnection = null) : base(parent, protocol, credential, rdpConnection) {



            }
        #endregion


        #region // Methods
        public async Task<DataGram> AsyncReceive() => throw new NYI();

        public async void SendControlDatagram(DataGram dataGram) {

            }
        #endregion

        }


    }
