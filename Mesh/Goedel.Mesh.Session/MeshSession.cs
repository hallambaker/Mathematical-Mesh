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
using Goedel.Protocol.Service;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Mesh.Session {

    /// <summary>
    /// This class contains some material that should move to Goedel.Protocol.Presentation
    /// and some that should go to Goedel.Mesh. 
    /// </summary>
    public class MeshSession : SessionInitiator, IJpcSession {

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

        public MeshSession(Credential clientCredential, string domain,
                    string protocol, string instance = null,
                    PresentationType presentationTypes = PresentationType.All) {

            Domain = domain;
            Protocol = protocol;
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
                LocalStreamId.GetValue(), StreamId.ClientInitial, 
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

            



            //switch (sourceId.Value) {
            //    case (byte)PlaintextPacketType.HostChallenge: {
            //        PacketChallenge  = ProcessChallenge(responseData, offset);
            //        break;
            //        }

            //    case (byte)PlaintextPacketType.HostComplete: {
            //        // This can't happen at the moment as we don't have a credential to send out.
                    
            //        throw new NYI();
            //        //break;
            //        }

            //    }


            //var packet = Parse



            var response = PacketChallenge ?.Payload == null || PacketChallenge .Payload.Length == 0 ? null :
                            ParsePayload(PacketChallenge .Payload);

            return response;
            }




        /////<inheritdoc/>
        //public override void AddEphemerals(byte[] destinationId, List<PacketExtension> extensions) =>
        //            CredentialSelf.AddEphemerals( extensions, ref ephemeralsOffered);

        /////<inheritdoc/>
        //public override void MutualKeyExchange(string keyId) {

        //    // reconstitute the ephemeral from the stream id.

        //    var (privateEphemeral, publickey) = ClientCredential.SelectKey(ephemeralsOffered, keyId);
        //    MutualKeyExchange(privateEphemeral, publickey);
        //    }

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
                var (buffer, offset) =  InitializeBuffer(span.Length);
                encoded = SerializePacketData(span, buffer: buffer, position: offset);

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

            // check the sourceId is for us here???

            var packet = ParsePacketData(responsepacketData, offset2);
            if (!Connected) {
                GetSourceId();
                }

            JsonObject response = null;
            if (packet?.Payload.Length > 0) {
                response = JsonObject.From(packet.Payload);
                }
            return response;
            }


        void GetSourceId() {

            // need to scan the encrypted attributes to get the source Id.

            Connected = true;
            throw new NYI();
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
        #endregion
        }
    }
