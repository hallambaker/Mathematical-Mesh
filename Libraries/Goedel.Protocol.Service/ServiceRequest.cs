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


    public enum RequestQuality {
        
        OK,
        Reason,
        Abort
        }

    /// <summary>
    /// Base class for connection handlers
    /// </summary>
    public abstract class ServiceRequest {

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


        protected byte[] Buffer = new byte[MaxRequest];
        protected int Count = 0;



        public bool Refused { get; protected set; } = false;

        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public abstract void Complete();



        protected RequestQuality AbuseCheckIpSource(IPEndPoint iPEndPoint) => RequestQuality.OK;



        long GetSourceId() {

            throw new NYI();
            }


        /// <summary>
        /// Abort the connection.
        /// </summary>
        /// <param name="requestQuality"></param>
        public abstract void Abort(RequestQuality requestQuality);


        bool PlaintextPayload;


        //int offset;

        JsonObject request;
        JsonObject response;
        IJpcSession session;

        PlaintextPacketType responsePacket;

        byte[] Trimmed;

        Listener Listener => Service.FredListener;

        Packet PacketClient;
        Packet PacketResponse;

        public int SourceIdSize { get; } = 8;
        /// <summary>
        /// Process the initial bytes of the buffer to get the source ID value according to the 
        /// source ID processing mode specified for the session.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>The retrieved sourceId and position in the buffer.</returns>
        public virtual (ulong, int) GetSourceId(byte[] buffer) =>
            (buffer.BigEndianInt(SourceIdSize), SourceIdSize);


        protected virtual void ProcessBuffer() {


            var (sourceId, offset) = GetSourceId(Buffer);


            Trimmed = GetTrimmed(Buffer, offset, Count- offset);


            PlaintextPayload = false;
            switch (sourceId) {
                case (byte)PlaintextPacketType.ClientInitial: {
                    ProcessClientInitial();
                    break;
                    }
                case (byte)PlaintextPacketType.ClientExchange: {
                    ProcessClientExchange();
                    break;
                    }
                case (byte)PlaintextPacketType.ClientCompleteDeferred: {
                    ProcessClientCompleteDeferred();
                    break;
                    }
                case (byte)PlaintextPacketType.ClientComplete: {
                    ProcessClientComplete();
                    break;
                    }
                default: {
                    ProcessClientData(sourceId);
                    break;
                    }
                }

            var memoryStream = new MemoryStream(PacketClient.Payload);
            var reader = new JsonBcdReader(memoryStream);

            byte[] responseBytes = null;
            if (PacketClient?.Payload.Length > 0) {
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
                case PlaintextPacketType.HostChallenge: {
                    var tempResponder = Listener.Challenge(PacketClient, responseBytes);
                    var responsePacket = tempResponder.SerializeHostChallenge1(responseBytes);
                    ReturnResponse(responsePacket);


                    break;
                    }



                }

            }




        ///<inheritdoc/>



        protected byte[] GetTrimmed(byte[] input, int offset, int length) {
            var result = new byte[length];

            System.Buffer.BlockCopy(input, offset, result, 0, length);
            return result;
            }



        void ProcessClientInitial() {
            PlaintextPayload = true;
            responsePacket = PlaintextPacketType.HostChallenge;
            PacketClient = Listener.ParseClientInitial(null, Trimmed);
            }
        void ProcessClientComplete() {
            responsePacket = PlaintextPacketType.Data;

            }
        void ProcessClientData(ulong SourceId) {

            responsePacket = PlaintextPacketType.Data;
            }

        void ProcessClientExchange() {
            throw new NYI();
            }
        void ProcessClientCompleteDeferred() {
            throw new NYI();
            }


        void ProcessDispatch() {
            }



        protected abstract void ReturnResponse(byte[] chunk);


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

            response.OutputStream.Write(chunk);
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.KeepAlive = true;
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
        byte[] Buffer { get; }

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
