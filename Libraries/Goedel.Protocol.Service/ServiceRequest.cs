﻿using System;
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


        protected byte[] Buffer = new byte[MaxRequest];
        protected int Count = 0;



        public bool Refused { get; protected set; } = false;

        #endregion




        /// <summary>
        /// Process the connection, dispatch the request and return the result.
        /// </summary>
        public abstract void Complete();



        protected RequestQuality AbuseCheckIpSource(IPEndPoint iPEndPoint) => RequestQuality.OK;





        /// <summary>
        /// Abort the connection.
        /// </summary>
        /// <param name="requestQuality"></param>
        public abstract void Abort(RequestQuality requestQuality);


        bool PlaintextPayload;


        //int offset;

        JsonObject response;
        IJpcSession session;

        PlaintextPacketType responsePacket;

        Listener Listener => Service.FredListener;

        Packet PacketClient;
        Packet PacketResponse;

        //public int SourceIdSize { get; } = 8;
        ///// <summary>
        ///// Process the initial bytes of the buffer to get the source ID value according to the 
        ///// source ID processing mode specified for the session.
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <returns>The retrieved sourceId and position in the buffer.</returns>
        //public virtual (ulong, int) GetSourceId(byte[] buffer) =>
        //    (buffer.BigEndianInt(SourceIdSize), SourceIdSize);


        protected virtual void ProcessBuffer() {


            var (sourceId, offset) = StreamId.GetSourceId(Buffer);


            SessionResponder sessionResponder=null;

            PlaintextPayload = false;
            sessionResponder = (PlaintextPacketType)sourceId.Value switch {
                PlaintextPacketType.ClientInitial => ProcessClientInitial(),
                PlaintextPacketType.ClientExchange => ProcessClientExchange(),
                PlaintextPacketType.ClientCompleteDeferred => ProcessClientCompleteDeferred(offset),
                PlaintextPacketType.ClientComplete => ProcessClientComplete(),
                _ => ProcessClientData(sourceId)
                };

            if (sessionResponder == null) {
                return; // 
                }

                //case (byte)PlaintextPacketType.ClientInitial: {
                //    ;
                //    break;
                //    }
                //case (byte)PlaintextPacketType.ClientExchange: {
                //    ProcessClientExchange();
                //    break;
                //    }
                //case (byte)PlaintextPacketType.ClientCompleteDeferred: {
                //    sessionResponder = ProcessClientCompleteDeferred();
                //    break;
                //    }
                //case (byte)PlaintextPacketType.ClientComplete: {
                //    ProcessClientComplete();
                //    break;
                //    }
                //default: {
                //    sessionResponder = ProcessClientData(sourceId);
                //    break;
                //    }
                //}

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

                    var challenge = Listener.MakeChallenge(PacketClient, responseBytes);

                    var buffer = new byte[Constants.MinimumPacketSize];

                    var responsePacket = sessionResponder.SerializeHostChallenge1(
                                StreamId.GetClientCompleteDeferred(), PacketClient.SourceId,
                                responseBytes, challenge, buffer);

                    ReturnResponse(responsePacket);


                    break;
                    }
                case PlaintextPacketType.Data: {
                    var responsePacket = sessionResponder.SerializePacketData(
                        responseBytes);
                    ReturnResponse(responsePacket);

                    break;
                    }
                default: {
                    throw new NYI();
                    }

                }

            }




        ///<inheritdoc/>



        //protected byte[] GetTrimmed(byte[] input, int offset, int length) {
        //    var result = new byte[length];

        //    System.Buffer.BlockCopy(input, offset, result, 0, length);
        //    return result;
        //    }



        SessionResponder ProcessClientInitial() {
            PlaintextPayload = true;
            responsePacket = PlaintextPacketType.HostChallenge;
            PacketClient = Listener.ParseClientInitial(Buffer, StreamId.SourceIdMaxSize, Count- StreamId.SourceIdMaxSize);
            return Listener.GetTemporaryResponder(PacketClient); ;
            }
        SessionResponder ProcessClientComplete() {
            responsePacket = PlaintextPacketType.Data;
            throw new NYI();
            }
        SessionResponder ProcessClientData(StreamId SourceId) {

            // identify the source connection


            responsePacket = PlaintextPacketType.Data;

            // map the source id here
            //PacketClient = ParsePacketData(null, Trimmed);
            throw new NYI();

            }

        SessionResponder ProcessClientExchange() {
            throw new NYI();
            }
        SessionResponder ProcessClientCompleteDeferred(int offset) {

            PacketClient = Listener.ParseClientCompleteDeferred(Buffer, offset, Count-offset);
            // verify the challenge here

            if (Listener.VerifyChallenge(PacketClient)) {


                

                responsePacket = PlaintextPacketType.Data;
                return Listener.Accept(PacketClient);
                }
            else {
                responsePacket = PlaintextPacketType.Error;

                return null;
                }


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