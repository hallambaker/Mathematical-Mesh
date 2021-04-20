using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Service {

    /// <summary>
    /// Describe the result of request source analysis.
    /// </summary>
    public enum RequestQuality {
        ///<summary>The request comes from an acceptable (non blocked source).</summary> 
        OK,
        ///<summary>The request is not acceptable respond giving (Reason TBS)</summary> 
        Reason,
        ///<summary>The request is not acceptable and should be ignored without response.</summary> 
        Abort
        }

    /// <summary>
    /// Base class for connection handlers
    /// </summary>
    public abstract class ServiceRequest {
        #region // Properties

        ///<summary>The maximum request size</summary> 
        public const int MaxRequest = 0x10000;

        ///<summary>The object encoding to use.</summary> 
        public ObjectEncoding ObjectEncoding { get; set; } = ObjectEncoding.JSON_B;


        ///<summary>Specifies a resouce that is under contention, e.g. an account or the 
        ///account catalog. This allows requests for the same resource to be queued for
        ///dispatch after the blocking requests have completed.</summary> 
        public string Resource { get; protected set; } = null;

        ///<summary></summary> 
        public int Slot;

        ///<summary></summary> 
        public Service Service;

        ///<summary>The buffer to receive the input request.</summary> 
        protected byte[] Buffer = new byte[MaxRequest];

        ///<summary>Number of bytes read into the input buffer.</summary> 
        protected int Count = 0;


        ///<summary>If true, the request was refused.</summary> 
        public bool Refused { get; protected set; } = false;

        #endregion




        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public abstract void Complete();


        /// <summary>
        /// Determine  quality of request received from <paramref name="iPEndPoint"/>
        /// </summary>
        /// <param name="iPEndPoint">The request origin.</param>
        /// <returns>The quality of the request.</returns>
        protected RequestQuality AbuseCheckIpSource(IPEndPoint iPEndPoint) => RequestQuality.OK;


        /// <summary>
        /// Abort the connection.
        /// </summary>
        /// <param name="requestQuality"></param>
        public abstract void Abort(RequestQuality requestQuality);

        //int offset;

        JsonObject response;
        IJpcSession session;

        ResponderMessageType responsePacket;

        Listener Listener => Service.Listener;

        Packet packetClient;

        /// <summary>
        /// Process the buffer containing inbound data.
        /// </summary>
        protected virtual void ProcessBuffer() {


            var (sourceId, offset) = StreamId.GetSourceId(Buffer);
            ConnectionResponder sessionResponder=null;

            sessionResponder = (InitiatorMessageType)sourceId.Value switch {
                InitiatorMessageType.InitiatorHello => ProcessClientInitial(),
                InitiatorMessageType.InitiatorExchange => ProcessClientCompleteDeferred(offset),
                _ => ProcessClientData(sourceId, offset)
                };

            if (sessionResponder == null) {
                return; // 
                }


            var memoryStream = new MemoryStream(packetClient.Payload);
            var reader = new JsonBcdReader(memoryStream);

            byte[] responseBytes = null;
            if (packetClient?.Payload.Length > 0) {
                var provider = Service.GetProvider(null, 0, null);

                provider.AssertNotNull(NYI.Throw);

                try {
                    response = provider.JpcInterface.Dispatch(session, reader);
                    }
                catch {
                    // here make error response wrapper

                    }

                responseBytes = response.GetBytes(true, ObjectEncoding);
                }

            switch (responsePacket) {
                case ResponderMessageType.ResponderChallenge: {

                    var challenge = Listener.MakeChallenge(packetClient, responseBytes);

                    var buffer = new byte[Constants.MinimumPacketSize];

                    var responsePacket = sessionResponder.SerializeResponderChallenge(
                                StreamId.GetClientCompleteDeferred(), packetClient.SourceId,
                                responseBytes, challenge, buffer);

                    ReturnResponse(responsePacket);


                    break;
                    }
                case ResponderMessageType.Data: {
                    List<PacketExtension> packetExtensions=null;
                    if (sessionResponder.ReturnStreamId != null) {
                        var returnExtension = new PacketExtension() {
                            Tag = Constants.ExtensionTagsStreamIdTag, Value = sessionResponder.ReturnStreamId
                            };
                        packetExtensions = new List<PacketExtension> { returnExtension };
                        }

                    var responsePacket = sessionResponder.SerializePacketData(responseBytes, packetExtensions);
                    ReturnResponse(responsePacket);

                    break;
                    }
                default: {
                    throw new NYI();
                    }

                }

            }




        ConnectionResponder ProcessClientInitial() {
            responsePacket = ResponderMessageType.ResponderChallenge;
            packetClient = Listener.ParseInitiatorHello(Buffer, Constants.SizeReservedInitialStreamId, 
                Count- Constants.SizeReservedInitialStreamId);
            return Listener.GetTemporaryResponder(packetClient); ;
            }
        ConnectionResponder ProcessClientComplete() {
            responsePacket = ResponderMessageType.Data;
            throw new NYI();
            }
        ConnectionResponder ProcessClientData(StreamId SourceId, int offset) {

            // identify the source connection


            responsePacket = ResponderMessageType.Data;

            if (Listener.DictionarySessionsInbound.TryGetValue(SourceId, out var responder)) {
                packetClient = responder.ParsePacketData(Buffer, offset, Count);
                return responder;
                }


            // map the source id here
            //PacketClient = ParsePacketData(null, Trimmed);
            throw new NYI();

            }

        ConnectionResponder ProcessClientExchange() {
            throw new NYI();
            }
        ConnectionResponder ProcessClientCompleteDeferred(int offset) {

            packetClient = Listener.ParseInitiatorComplete(Buffer, offset, Count-offset);
            // verify the challenge here

            if (Listener.VerifyChallenge(packetClient)) {


                

                responsePacket = ResponderMessageType.Data;
                return Listener.Accept(packetClient);
                }
            else {
                responsePacket = ResponderMessageType.Error;

                return null;
                }


            }



        /// <summary>
        /// Return a response containing the payload <paramref name="payload"/>
        /// </summary>
        /// <param name="payload">The payload data to return.</param>
        protected abstract void ReturnResponse(byte[] payload);


        }


    /// <summary>
    /// Connection handler for HTTP request
    /// </summary>
    public class ServiceRequestHttp : ServiceRequest {
        HttpListenerContext ListenerContext { get; }






        /// <summary>
        /// Constructor returning an instance to process the request 
        /// specified by <paramref name="listenerContext"/>.
        /// </summary>
        /// <param name="service">The service to process the request.</param>
        /// <param name="listenerContext">The HTTP request context.</param>
        public ServiceRequestHttp(Service service, HttpListenerContext listenerContext) {

            Service = service;
            ListenerContext = listenerContext;

            // Filter out abusive requests.
            var abuse = AbuseCheckIpSource(listenerContext.Request.RemoteEndPoint);
            if (abuse != RequestQuality.OK) {
                Abort(abuse);
                return;
                }

            }

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            Service.Monitor.StartDispatch(Slot);

            var request = ListenerContext.Request;

            // get the provider here - if null - abort
            var provider = Service.GetProvider(
                    request.ServiceName, request.LocalEndPoint.Port, request.RawUrl);

            provider.AssertNotNull(NYI.Throw);

            request.InputStream.AssertNotNull(NYI.Throw);

            // Read the input stream until either it is closed or 64KB have been read

            var read = 1;
            while (Count < MaxRequest & read > 0) {
                read = request.InputStream.Read(Buffer, Count, MaxRequest - Count);
                Count += read;
                }
            (Count < MaxRequest).AssertTrue(NYI.Throw);


            ProcessBuffer();



            }


        ///<inheritdoc/>
        protected override void ReturnResponse(byte[] chunk) {
            var response = ListenerContext.Response;


            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.KeepAlive = true;
            response.OutputStream.Write(chunk);


            response.Close();

            Service.Monitor.EndDispatch(Slot);
            }



        ///<inheritdoc/>
        public override void Abort(RequestQuality requestQuality) {
            Refused = true;
            if (requestQuality == RequestQuality.Abort) {
                ListenerContext.Response.Abort();
                return;
                }
            ListenerContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            ListenerContext.Response.StatusDescription = "Not at all OK";
            ListenerContext.Response.KeepAlive = true;
            ListenerContext.Response.Close();
            }


        }

    /// <summary>
    /// Connection handler for UDP request
    /// </summary>
    public class ServiceRequestUdp : ServiceRequest {


        /// <summary>
        /// Constructor, process the request contained in <paramref name="result"/>.
        /// </summary>
        /// <param name="result">The UDP receive result</param>
        public ServiceRequestUdp(UdpReceiveResult result) => Buffer = result.Buffer;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public override void Complete() {
            }

        ///<inheritdoc/>
        public override void Abort(RequestQuality requestQuality) {
            // Do nothing, just drop the connection.
            }

        ///<inheritdoc/>
        protected override void ReturnResponse(byte[] chunk) {
            throw new NYI();
            }
        }






    }
