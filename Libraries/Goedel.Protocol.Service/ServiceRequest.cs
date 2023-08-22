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

using System.Net;
using System.Net.Sockets;

using Goedel.Protocol.Presentation;

namespace Goedel.Protocol.Service;

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
    public const int MaxRequest = 0x1000000;

    ///<summary>The object encoding to use.</summary> 
    public ObjectEncoding ObjectEncoding { get; set; } = ObjectEncoding.JSON_B;


    ///<summary>Specifies a resouce that is under contention, e.g. an account or the 
    ///account catalog. This allows requests for the same resource to be queued for
    ///dispatch after the blocking requests have completed.</summary> 
    public string Resource { get; protected set; } = null;

    ///<summary></summary> 
    public int Slot;

    ///<summary></summary> 
    public RudService Service;

    ///<summary>The buffer to receive the input request.</summary> 
    protected byte[] Buffer = new byte[MaxRequest];

    ///<summary>Number of bytes read into the input buffer.</summary> 
    protected int Count = 0;


    ///<summary>If true, the request was refused.</summary> 
    public bool Refused { get; protected set; } = false;

    #endregion

    #region // Methods 


    /// <summary>
    /// Process the connection, dispatch the request and return the result.
    /// </summary>
    public abstract void Complete();


    /// <summary>
    /// Determine  quality of request received from <paramref name="iPEndPoint"/>
    /// </summary>
    /// <param name="iPEndPoint">The request origin.</param>
    /// <returns>The quality of the request.</returns>
    protected RequestQuality AbuseCheckIpSource(IPEndPoint iPEndPoint) {
        iPEndPoint.Future();
        this.Future();
        return RequestQuality.OK;
        }


    /// <summary>
    /// Abort the connection.
    /// </summary>
    /// <param name="requestQuality"></param>
    public abstract void Abort(RequestQuality requestQuality);

    JsonObject response;
    //IJpcSession session;

    ResponderMessageType responsePacket;

    Listener Listener => Service.Listener;

    Packet packetClient;

    /// <summary>
    /// Process the buffer containing inbound data.
    /// </summary>
    protected virtual void ProcessBuffer() {
        var (sourceId, offset) = Presentation.StreamId.GetSourceId(Buffer);

        //Screen.WriteLine($"Received Request {sourceId.Elements}");

        RudStream stream = null;

        if (sourceId.Value == 0) {
            offset = Goedel.Protocol.Presentation.PresentationConstants.SizeReservedInitialStreamId;
            var messageType = PacketReader.ReadInitiatorMessageType(Buffer, ref offset);

            switch (messageType) {
                case InitiatorMessageType.InitiatorHello: {
                        stream = ProcessClientInitial(offset);
                        break;
                        }
                case InitiatorMessageType.InitiatorComplete: {
                        stream = ProcessClientComplete(offset);
                        break;
                        }
                }

            }
        else {
            stream = ProcessClientData(sourceId, offset);
            }




        if (stream?.RudConnection is not ConnectionResponder sessionResponder) {
            return; // 
            }


        var memoryStream = new MemoryStream(packetClient.Payload);
        var reader = new JsonBcdReader(memoryStream);

        byte[] responseBytes = null;
        if ((stream is RudStreamService rudStreamService) && (packetClient?.Payload.Length > 0)) {

            //Screen.WriteLine($"Begin dispatch");

            try {
                response = rudStreamService.JpcInterface.Dispatch(rudStreamService, reader);
                if (response == null) {
                    }
                }
            catch {
                // here make error response wrapper

                }
            //Screen.WriteLine($"End dispatch");


            responseBytes = response.GetBytes(true, ObjectEncoding);
            }

        // UGH: this should be switched out to use stream.StreamState !!!!
        switch (responsePacket) {
            case ResponderMessageType.ResponderChallenge: {

                    var challenge = Listener.MakeChallenge(packetClient, responseBytes);

                    //var buffer = new byte[Constants.MinimumPacketSize];

                    var responsePacket = sessionResponder.SerializeResponderChallenge(
                                Presentation.StreamId.GetClientCompleteDeferred(), packetClient.SourceId,
                                responseBytes, challenge);

                    ReturnResponse(responsePacket);


                    break;
                    }
            case ResponderMessageType.Data: {
                    List<PacketExtension> packetExtensions = null;

                    if (stream.StreamState != StreamState.Data) {
                        var returnExtension = new PacketExtension() {
                            Tag = Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsStreamIdTag,
                            Value = stream.RemoteStreamId
                            };
                        packetExtensions = new List<PacketExtension> { returnExtension };


                        stream.StreamState = StreamState.Data;
                        }


                    var responsePacket1 = sessionResponder.SerializePacketData(
                        stream.RemoteStreamId, payload: responseBytes, ciphertextExtensions: packetExtensions);
                    ReturnResponse(responsePacket1);

                    break;
                    }
            default: {
                    throw new NYI();
                    }

            }

        }




    RudStream ProcessClientInitial(int offset) {
        responsePacket = ResponderMessageType.ResponderChallenge;
        packetClient = Listener.ParseInitiatorHello(Buffer, offset,
            Count - offset);

        foreach (var extension in packetClient.PlaintextExtensions) {
            Console.WriteLine($"Hello {extension.Tag} length {extension.Value.Length}");

            }


        return Listener.GetTemporaryResponder(packetClient); ;
        }

    RudStream ProcessClientData(Presentation.StreamId SourceId, int offset) {


        //Screen.WriteLine($"Try to match inbound stream {SourceId.Elements}");

        responsePacket = ResponderMessageType.Data;

        // Is the stream unknown?
        if (!Listener.DictionaryStreamsInbound.TryGetValue(SourceId, out var stream)) {
            // NYI: Need better handling of unknown steams, return error message?
            throw new NYI();
            }


        var responder = stream.RudConnection;

        var packet = responder.ParsePacketData(Buffer, offset, Count);
        packetClient = packet;
        // check to see if there is a sub-stream to be created.

        if (packet.CiphertextExtensions != null) {
            var streamChild = Listener.AcceptStream(packet.CiphertextExtensions, parentStream: stream);
            if (streamChild != null) {
                return streamChild;
                }
            }

        if (packet.CiphertextExtensions != null) {
            foreach (var extension in packet.CiphertextExtensions) {
                switch (extension.Tag) {
                    case Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsRollTag: {

                            break;
                            }
                    case Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsCloseStreamTag: {

                            break;
                            }
                    case Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsCloseConnectionTag: {

                            break;
                            }
                    }

                }
            }
        return stream;
        }

    RudStream ProcessClientComplete(int offset) {

        packetClient = Listener.ParseInitiatorComplete(Buffer, offset, Count - offset);
        // verify the challenge here

        if (Listener.VerifyChallenge(packetClient)) {




            responsePacket = ResponderMessageType.Data;
            return Listener.AcceptConnection(packetClient);
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

    #endregion
    }


/// <summary>
/// Connection handler for HTTP request
/// </summary>
public class ServiceRequestHttp : ServiceRequest {
    #region // Properties
    HttpListenerContext ListenerContext { get; }

    #endregion
    #region // Constructors




    /// <summary>
    /// Constructor returning an instance to process the request 
    /// specified by <paramref name="listenerContext"/>.
    /// </summary>
    /// <param name="service">The service to process the request.</param>
    /// <param name="listenerContext">The HTTP request context.</param>
    public ServiceRequestHttp(RudService service, HttpListenerContext listenerContext) {

        Service = service;
        ListenerContext = listenerContext;

        // Filter out abusive requests.
        var abuse = AbuseCheckIpSource(listenerContext.Request.RemoteEndPoint);
        if (abuse != RequestQuality.OK) {
            Abort(abuse);
            return;
            }

        }
    #endregion
    #region // Methods 
    /// <summary>
    /// Process the connection, dispatch the request and return the result.
    /// </summary>
    public override void Complete() {
        try {
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
        catch (Exception ex) {
            Console.WriteLine($" Unhandled error {ex.ToString()}");


            Service?.Monitor?.Logger.UnhandledException(ex);
            }


        }


    ///<inheritdoc/>
    protected override void ReturnResponse(byte[] chunk) {
        var response = ListenerContext.Response;
        Console.WriteLine($"About to send Reply");
        response.StatusCode = (int)HttpStatusCode.OK;
        response.StatusDescription = "OK";
        response.KeepAlive = true;
        response.OutputStream.Write(chunk);


        response.Close();
        Console.WriteLine($"Reply complete");
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

    #endregion
    }

/// <summary>
/// Connection handler for UDP request
/// </summary>
public class ServiceRequestUdp : ServiceRequest {

    #region // Constructors
    /// <summary>
    /// Constructor, process the request contained in <paramref name="result"/>.
    /// </summary>
    /// <param name="result">The UDP receive result</param>
    public ServiceRequestUdp(UdpReceiveResult result) => Buffer = result.Buffer;
    #endregion
    #region // Methods 
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
    protected override void ReturnResponse(byte[] chunk) => throw new NYI();

    #endregion
    }
