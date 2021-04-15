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

using Goedel.Protocol;
//using Goedel.Protocol.Service;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {



    /// <summary>
    /// This class contains some material that should move to Goedel.Protocol.Presentation
    /// and some that should go to Goedel.Mesh. 
    /// </summary>
    public class RdpConnection : SessionInitiator, IJpcSession {

        #region // Properties

        public VerifiedAccount VerifiedAccount { get; }

        public string Domain { get; }
        public string Protocol { get; }
        public string Instance { get; }

        public bool Connected { get; private set; } = false;

        public ObjectEncoding ObjectEncoding { get; set; } = ObjectEncoding.JSON;

        public string Uri { get; }

        public Packet PacketChallenge;

        WebClient WebClient { get; set; }


        ///<inheritdoc/>
        protected override void Disposing() => WebClient?.Dispose();

        #endregion
        #region // Constructors

        public RdpConnection(Credential clientCredential, string domain,
                    string instance = null, PresentationType presentationTypes = PresentationType.All,
                    string protocol = null) {

            Domain = domain;
            Protocol = protocol ?? Constants.ProtocolIdRud;
            Instance = instance;
            CredentialSelf = clientCredential;

            LocalStreamId = StreamId.GetStreamId();

            Uri = HttpEndpoint.GetUri(Domain, Protocol, Instance);

            WebClient = new WebClient();

            }


        #endregion
        #region // Implement Inteface IJpcSession

        public JsonObject Initialize(
                string tag,
                JsonObject request,
                Credential credential=null) {


            byte[] span = null;
            if (request != null) {
                span = SerializePayload(tag, request, out var stream);
                }

            var plaintextExtensions = new List<PacketExtension> {
                    LocalStreamId.PacketExtension };

            //var (buffer, position) = MakeTagKeyExchange(PlaintextPacketType.ClientInitial);
            var buffer = new byte[Constants.MinimumPacketSize];
            var encoded = SerializeClientInitial(
                LocalStreamId.GetValue(), Constants.StreamIdClientInitial, 
                span, plaintextExtensions, buffer, 0);


            //Screen.WriteLine($"Wait on URI {Uri}");

            var result = Transact(encoded);
            result.Wait();

            var responseData = result.Result;

            // strip off and save the session  Id here.

            var (sourceId, offset) = StreamId.GetSourceId(responseData);
            LocalStreamId = sourceId;

            // here get the next byte and dispatch on it.

            var messageType = responseData[offset++];
            switch (messageType) {
                case Constants.TagHostChallenge1: {
                    PacketChallenge = ParseHostChallenge1(responseData, offset);
                    break;
                    }
                case Constants.TagHostChallenge2: {
                    PacketChallenge = ParseHostChallenge2(responseData, offset);
                    break;
                    }
                case Constants.TagHostComplete: {
                    PacketChallenge = ParseHostComplete(responseData, offset);
                    break;
                    }
                case Constants.TagHostExchange: {
                    PacketChallenge = ParseHostExchange(responseData, offset);
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }


            PacketChallenge.Dump();


            var response = PacketChallenge ?.Payload == null || PacketChallenge .Payload.Length == 0 ? null :
                            ParsePayload(PacketChallenge .Payload);

            return response;
            }

        public Packet ProcessChallenge(byte[] packet, int offset) {

            // vary according to the challenge sent out...

            PacketChallenge = ParseHostChallenge1(packet, offset);
            return PacketChallenge;
            }



        ///<inheritdoc/>
        public JsonObject Post(
                string tag,
                JsonObject request) {

            // Serialize request
            byte[] span = null;
            if (request != null) {
                span = SerializePayload(tag, request, out var stream);
                }

            byte[] encoded;
            if (Connected) {
                //var (buffer, offset) =  InitializeBuffer(span.Length);
                encoded = SerializePacketData(span);

                }
            else {
                var buffer = new byte[Constants.MinimumPacketSize];

                var ciphertextExtensions = new List<PacketExtension> {
                    LocalStreamId.PacketExtension };
                encoded = SerializeClientCompleteDeferred(
                    LocalStreamId.GetValue(), PacketChallenge.SourceId,span,
                    ciphertextExtensions: ciphertextExtensions, buffer: buffer);
                }


            // Transact
            var result = Transact(encoded);
            result.Wait();
            var responsepacketData = result.Result;

            // Parse the response
            var (sourceId, offset2) = StreamId.GetSourceId(responsepacketData);

            var packet = ParsePacketData(responsepacketData, offset2, responsepacketData.Length);
            if (!Connected) {
                GetSourceId(packet as PacketData);
                }

            JsonObject response = null;
            if (packet?.Payload.Length > 0) {
                response = JsonObject.From(packet.Payload);
                }
            return response;
            }


        void GetSourceId(PacketData packet) {
            RemoteStreamId = PacketExtension.GetExtensionByTag(packet?.CiphertextExtensions,
                    Constants.StreamId);
            // need to scan the encrypted attributes to get the source Id.

            Connected = true;

            }

        private byte[] SerializePayload(string tag, JsonObject request, out MemoryStream stream) {
            stream = new MemoryStream();
            var writer = JsonObject.GetJsonWriter(ObjectEncoding);
            writer.WriteObjectStart();

            bool first = true;
            request.Serialize(writer, true, ref first);
            writer.WriteToken(tag, 0);
            writer.WriteObjectEnd();

            // avoid the copy by using a Span.
            return stream.ToArray();
            }

        private JsonObject ParsePayload(byte[] responseData) {
            using var reader = new JsonBcdReader(responseData);
            return JsonObject.FromJson(reader, true);
            }



        #endregion
        #region // Override Methods

        public Task<byte[]> Transact(byte[] payload) =>
                    WebClient.UploadDataTaskAsync(Uri, payload);

        #endregion
        #region // Methods


        /// <summary>
        /// Return a client bound to the connection via the relevant protocol
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetClient<T>() where T : JpcClientInterface, new() => new() {
            JpcSession = this
            };


        #endregion
        }
    }
