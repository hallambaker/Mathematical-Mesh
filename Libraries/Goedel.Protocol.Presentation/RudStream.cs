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

    /// <summary>
    /// A second detagram structure???
    /// </summary>
    public struct DataGram {

        ///<summary>The data.</summary> 
        public byte[] Data;
        
        ///<summary>If true, this is a final datagram.</summary> 
        public bool IsFinal;
        }

    /// <summary>
    /// Transaction post.
    /// </summary>
    /// <param name="tag">The transaction tag.</param>
    /// <param name="request">The transaction request object.</param>
    /// <returns>The result of performing the transaction.</returns>
    public delegate JsonObject TransactionPostDelegate(string tag, JsonObject request);

    /// <summary>
    /// Receive datagram.
    /// </summary>
    /// <param name="dataGram">Datagram to dispatch.</param>
    public delegate void AsynchronousReceiveDelegate(DataGram dataGram);


    ///<summary>Stream connection states.</summary> 
    public enum StreamState {
        ///<summary>No attempt has been made to begin a connection.</summary> 
        Initial,

        ///<summary>The initiator has contacted the responder and received a challenge back.</summary> 
        Challenged,

        ///<summary>The initiator has established a connection to the service and is 
        ///attempting to create a new stream.</summary> 
        Child,

        ///<summary>The stream is fully connected.</summary> 

        Data


        }


    /// <summary>
    /// An RDP Stream
    /// </summary>
    public class RudStream {
        #region // Properties
        ///<summary>The underlying connection</summary> 
        public virtual RudConnection RudConnection { get; }

        ///<summary>The connection as an initiator</summary> 
        protected ConnectionInitiator ConnectionInitiator => RudConnection as ConnectionInitiator;

        ///<summary>Account name claimed during stream initialization (unverified).</summary> 
        public string Account { get; set; }


        ///<summary>The state of the stream</summary> 
        public StreamState StreamState { get; set; }



        ///<summary>The child streams formed from this stream that MAY be rekeyed under this.</summary> 
        public List<RudStream> ChildStreams;


        ///<summary>The parent stream from which this one was created. If null, this is 
        ///the original stream.</summary> 
        public RudStream RdpStreamParent { get; }

        ///<summary>The protocol to which the stream is bound.</summary> 
        public string Protocol;

        ///<summary>The credential to which the stream is bound</summary> 
        public Credential Credential;

        ///<summary>The local stream Id, this is generated localy and MAY contain hidden structure.</summary> 
        public StreamId LocalStreamId { get; protected set; }

        ///<summary>The stream URI, (may differ from the connection ID</summary> 
        public string Uri;

        ///<summary>The primary stream Id to prepend outbound packets.</summary> 
        public byte[] RemoteStreamId { get; set; }

        ///<summary>The challenge Nonce.</summary> 
        public byte[] ChallengeNonce;

        ///<summary>The challeng proof of work.</summary> 
        public byte[] ChallengePoW;

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
        public RudStream(
                RudStream parent,
                string protocol,
                Credential credential= null,
                RudConnection rdpConnection=null) {
            RdpStreamParent = parent;
            if (parent != null) {
                parent.AddChild(this);
                }
            RudConnection = rdpConnection ?? parent?.RudConnection ;

            Protocol = protocol;

            // only set the URI if we are creating an initiator stream.
            if (RudConnection is ConnectionInitiator initiator) {
                Uri = HttpEndpoint.GetUri(initiator.Domain, protocol, initiator.Instance);
                }

            Credential = credential;
            LocalStreamId = RudConnection.GetStreamId();
            }

        #endregion




        #region // Methods

        /// <summary>
        /// Add one time use stream Id to the store (if needed).
        /// </summary>
        /// <param name="oneTimeId">The one time Id to add.</param>
        public void AddOneTime(byte[] oneTimeId) {

            }

        /// <summary>
        /// Set the encryption options for the stream.
        /// </summary>
        /// <param name="encryptionOptions"></param>
        public void SetOptions(
                    byte[] streamId,
                    byte[] encryptionOptions,
                    byte[] account) {

            Screen.WriteLine($"Stream set Stream Id {streamId.ToStringBase16()}");

            RemoteStreamId = streamId;
            Account = account?.ToUTF8();
            }

        /// <summary>
        /// Post transaction <paramref name="tag"/> with data <paramref name="request"/> to the stream.
        /// and wait for the response.
        /// </summary>
        /// <param name="tag">The transaction identifier.</param>
        /// <param name="request">The transaction body.</param>
        /// <returns>The transaction result.</returns>
        public async Task<JsonObject> PostAsync(
            string tag,
            JsonObject request) {

            // Serialize request
            byte[] span = null;
            if (request != null) {
                span = SerializePayload(tag, request, out var stream);
                }


            Screen.WriteLine($"Client {Protocol} - Post data to {RemoteStreamId?.ToStringBase16()}");
            var packet = await PostWeb(span);

            Screen.WriteLine($"Client {Protocol} - Posted data to {RemoteStreamId?.ToStringBase16()}");



            JsonObject response = null;
            if (packet?.Payload.Length > 0) {
                response = JsonObject.From(packet.Payload);
                }
            return response;
            }

        void InitializeStream(
                     ref List<PacketExtension> extensions) {

            extensions ??= new List<PacketExtension>();
            extensions.Add(LocalStreamId.PacketExtension);

            string streamType = this switch {
                RudStreamClient => Constants.ExtensionTagsStreamClientTag,
                RudStreamService => Constants.ExtensionTagsStreamServiceTag,
                RudStreamSender => Constants.ExtensionTagsStreamSenderTag,
                RudStreamReceiver => Constants.ExtensionTagsStreamReceiverTag,

                _ => null
                };

            extensions.Add(new() {
                Tag = streamType,
                Value = Protocol.ToUTF8()
                }) ;


            if (Credential != null) {
                extensions.Add(new() {
                    Tag = Credential.Tag,
                    Value = Credential.Value
                    });




                }

            }

        /// <summary>
        /// Post the message <paramref name="span"/> with extensions <paramref name="extensions"/>
        /// to the Web stream.
        /// </summary>
        /// <param name="span">The binary payload data.</param>
        /// <param name="extensions">The message extensions.</param>
        /// <returns>The response packet received.</returns>
        public async Task<Packet> PostWeb(byte[] span, List<PacketExtension> extensions = null) {
            //byte[] encoded = null;


            Screen.WriteLine($"Client {Protocol} - State {StreamState} Post data to {RemoteStreamId?.ToStringBase16()}");

            if (RudConnection.Connected) {
                switch (StreamState) {
                    case StreamState.Initial: {
                        return await PostWebChild(span, extensions);
                        }
                    case StreamState.Data: {
                        return await PostWebData(span, extensions);
                        }
                    }

                }
            else {
                switch (StreamState) {
                    case StreamState.Initial: {
                        return await PostWebHello(span, extensions);
                        }
                    case StreamState.Challenged: {
                        return await PostWebComplete(span, extensions);
                        }
                    }
                }



            throw new NYI();
            }


        async Task<Packet> PostWebHello(byte[] span, List<PacketExtension> extensions = null) {
            InitializeStream(ref extensions);

            var encoded = ConnectionInitiator.SerializeInitiatorHello(
                LocalStreamId.GetValue(), span,
                plaintextExtensionsIn: extensions);

            var responsepacketData = await ConnectionInitiator.WebClient.UploadDataTaskAsync(Uri, encoded);
            var (sourceId, position) = StreamId.GetSourceId(responsepacketData);
            Screen.WriteLine($"Client Received Stream ID {sourceId.Value}");

            var code = PacketReader.ReadResponderMessageType(responsepacketData, ref position);

            switch (code) {

                case ResponderMessageType.ResponderChallenge: {
                    StreamState = StreamState.Challenged;
                    var packet = ConnectionInitiator.ParseResponderChallenge(responsepacketData, position);
                    Process(packet);
                    return packet;
                    }

                }
            throw new NYI(); // state change not valid.
            }

        async Task<Packet> PostWebComplete(byte[] span, List<PacketExtension> extensions = null) {
            StreamState = StreamState.Data;
            InitializeStream(ref extensions);
            var encoded = ConnectionInitiator.SerializeInitiatorComplete(
                LocalStreamId.GetValue(), span,
                ciphertextExtensions: extensions);

            var responsepacketData = await ConnectionInitiator.WebClient.UploadDataTaskAsync(Uri, encoded);
            var (sourceId, position) = StreamId.GetSourceId(responsepacketData);
            Screen.WriteLine($"Client Received Stream ID {sourceId.Value}");

            var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);

            Process(packet);
            return packet;
            }


        async Task<Packet> PostWebChild(byte[] span, List<PacketExtension> extensions = null) {
            StreamState = StreamState.Data;
            InitializeStream(ref extensions);
            var encoded = RudConnection.SerializePacketData(destinationStream: RemoteStreamId, payload: span,
                ciphertextExtensions: extensions);

            var responsepacketData = await ConnectionInitiator.WebClient.UploadDataTaskAsync(Uri, encoded);
            var (sourceId, position) = StreamId.GetSourceId(responsepacketData);
            Screen.WriteLine($"Client Received Stream ID {sourceId.Value}");

            var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);
            Process(packet);
            return packet;
            }

        async Task<Packet> PostWebData(byte[] span, List<PacketExtension> extensions = null) {
            StreamState = StreamState.Data;
            var encoded = RudConnection.SerializePacketData(destinationStream: RemoteStreamId, payload: span,
                ciphertextExtensions: extensions);

            var responsepacketData = await ConnectionInitiator.WebClient.UploadDataTaskAsync(Uri, encoded);
            var (sourceId, position) = StreamId.GetSourceId(responsepacketData);
            Screen.WriteLine($"Client Received Stream ID {sourceId.Value}");

            var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);
            Process(packet);
            return packet;
            }



        void Process(PacketData packetData) {
            RemoteStreamId = PacketExtension.GetExtensionByTag(packetData?.CiphertextExtensions,
                    Constants.ExtensionTagsStreamIdTag);


            }

        void Process(PacketResponderChallenge packetResponderChallenge) {
            if (packetResponderChallenge.PlaintextExtensions != null) {
                foreach (var extension in packetResponderChallenge.PlaintextExtensions) {
                    switch (extension.Tag) {
                        case Constants.ExtensionTagsChallengeTag: {
                            ChallengeNonce = extension.Value;
                            break;
                            }
                        case Constants.ExtensionTagsChallengeProofOfWorkTag: {
                            ChallengePoW = extension.Value;
                            break;
                            }
                        }
                    }
                }

            // get the challenge out
            var challenge = PacketExtension.GetExtensionByTag(packetResponderChallenge?.PlaintextExtensions,
                    Constants.ExtensionTagsChallengeTag);

            // get the stream id for the response.
            RemoteStreamId = packetResponderChallenge.SourceId;

            }

        void GetSourceId(PacketData packet) {
            RemoteStreamId = PacketExtension.GetExtensionByTag(packet?.CiphertextExtensions,
                    Constants.ExtensionTagsStreamIdTag);

            }


        private byte[] SerializePayload(string tag, JsonObject request, out MemoryStream stream) {
            stream = new MemoryStream();
            var writer = JsonObject.GetJsonWriter(RudConnection.ObjectEncoding);
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


        private void AddChild(RudStream child) {
            ChildStreams ??= new();
            ChildStreams.Add(child);
            }

        protected void RemoveChild(RudStream child) {
            ChildStreams.Remove(child);
            }


        /// <summary>
        /// Request creation of a transactional stream in the client role.
        /// </summary>
        /// <param name="protocol">The protocol identifier</param>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RudStreamClient MakeStreamClient(string protocol, Credential credential = null) =>
            new RudStreamClient(this, protocol, credential);


        /// <summary>
        /// Request creation of an asynchronous stream in the sender role.
        /// </summary>
        /// <param name="credential">Optional additional credential to be presented.</param>
        /// <returns>The created stream.</returns>
        public RudStreamClient MakeStreamSender(Credential credential = null) => throw new NYI();

        /// <summary>
        /// Request creation of a transactional stream in the server role
        /// </summary>
        /// <param name="transactionPostDelegate">Optional delegate to be called when a request is received.</param>
        /// <returns>The created stream.</returns>
        public RudStreamService MakeStreamService(TransactionPostDelegate transactionPostDelegate = null) => throw new NYI();


        /// <summary>
        /// Request creation of an asynchronous stream in the receiver role.
        /// </summary>
        /// <param name="asynchronousReceiveDelegate">Optional delegate to be called when data is received.</param>
        /// <returns></returns>
        public RudStreamReceiver MakeStreamReceiver(AsynchronousReceiveDelegate asynchronousReceiveDelegate = null) => throw new NYI();

        /// <summary>
        /// Cause queued requests to be flushed.
        /// </summary>
        public void Flush () => throw new NYI();

        //public async Task<RudStream> AsyncReceiveStreamOffer() => throw new NYI();

        #endregion

        }


    }
