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


namespace Goedel.Protocol.Presentation;

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
    ///<inheritdoc cref="ICredential"/>
    public ICredential Credential => CredentialOther;

    ///<summary>The underlying connection</summary> 
    public virtual RudConnection RudConnection { get; }

    ///<summary>The connection as an initiator</summary> 
    protected ConnectionInitiator ConnectionInitiator => RudConnection as ConnectionInitiator;


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
    public ICredentialPrivate CredentialSelf;

    ///<summary>The credential to which the stream is bound</summary> 
    public ICredentialPublic CredentialOther;


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


    ///<summary>The account address</summary> 
    public string AccountAddress { get; }



    #endregion
    #region // Constructors

    /// <summary>
    /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
    /// protocol <paramref name="protocol"/> according to the stream role.
    /// </summary>
    /// <param name="parent">The parent stream</param>
    /// <param name="protocol">The stream protocol</param>
    /// <param name="credentialSelf">Optional additional credential for self.</param>
    /// <param name="credentialOther">Optional additional credential for other.</param>
    /// <param name="rudConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>
    /// <param name="accountAddress">The account address claimed.</param>
    public RudStream(
            RudStream parent,
            string protocol,
            ICredentialPrivate credentialSelf = null,
            ICredentialPublic credentialOther = null,
                RudConnection rudConnection = null,
            string accountAddress = null) {

        //(credentialSelf?.AuthenticationPublic.PublicOnly != true).AssertTrue(NYI.Throw);
        accountAddress.Future();

        RdpStreamParent = parent;
        if (parent != null) {
            parent.AddChild(this);
            }
        RudConnection = rudConnection ?? parent?.RudConnection;

        Protocol = protocol;

        // only set the URI if we are creating an initiator stream.
        if (RudConnection is ConnectionInitiator initiator) {

            var serviceDescription = DnsClient.ResolveService(initiator.Domain, protocol, port:15099);
            Uri = serviceDescription.GetUri(initiator.Instance);
            //Uri = HttpEndpoint.GetUri(initiator.Domain, 15099, protocol, initiator.Instance);

            //Screen.WriteLine($"Client URI = {Uri}");
            }
        //AccountAddress = throw new NYI();
        CredentialSelf = credentialSelf;
        CredentialOther = credentialOther ?? rudConnection?.CredentialOther ?? parent?.CredentialOther;
        LocalStreamId = RudConnection.GetStreamId();

        //VerifiedAccount = new VerifiedAccount(credentialOther, AccountAddress);

        }

    #endregion




    #region // Methods

    /// <summary>
    /// Set the encryption options for the stream.
    /// </summary>
    /// <param name="encryptionOptions"></param>
    /// <param name="streamId">The stream id</param>
    public void SetOptions(
                byte[] streamId,
                byte[] encryptionOptions) {
        encryptionOptions.Future();
        RemoteStreamId = streamId;
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

        var span = PrePost(tag, request);

        var spantxt = span.ToUTF8();
        /*
         * { "Hello": {}}
         */
        //Screen.WriteLine($"Client {Protocol} - Post data to {RemoteStreamId?.ToStringBase16()}");
        var packet = await PostWeb(span);

        //Screen.WriteLine($"Client {Protocol} - Posted data to {RemoteStreamId?.ToStringBase16()}");
        if (packet is PacketResponderChallenge &&
                    (packet.Payload == null | packet?.Payload.Length == 0)) {
            // if we got a challenge and no payload, represent the request here.
            packet = await PostWeb(span);
            }

        return PostPost(packet);
        }

    /// <summary>
    /// Convert the request for operation <paramref name="tag"/> with parameters
    /// <paramref name="request"/> to a byte array.
    /// </summary>
    /// <param name="tag">The operation identifier.</param>
    /// <param name="request">The request parameters.</param>
    /// <returns>The binary data.</returns>
    public byte[] PrePost(string tag, JsonObject request) {
        // Serialize request
        byte[] span = null;
        if (request != null) {
            span = SerializePayload(tag, request, out var _);
            }

        return span;
        }

    /// <summary>
    /// Recover the response object from the reply <paramref name="packet"/>.
    /// </summary>
    /// <param name="packet">Packet containing a response object.</param>
    /// <returns>The response object.</returns>
    public static JsonObject PostPost(Packet packet) {
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
            RudStreamClient => PresentationConstants.ExtensionTagsStreamClientTag,
            RudStreamService => PresentationConstants.ExtensionTagsStreamServiceTag,
            RudStreamSender => PresentationConstants.ExtensionTagsStreamSenderTag,
            RudStreamReceiver => PresentationConstants.ExtensionTagsStreamReceiverTag,

            _ => null
            };

        extensions.Add(new() {
            Tag = streamType,
            Value = Protocol.ToUTF8()
            });


        CredentialSelf?.AddCredentials(extensions);

        //if (CredentialSelf != null) {
        //    extensions.Add(new() {
        //        Tag = CredentialSelf.Tag,
        //        Elements = CredentialSelf.Elements
        //        });
        //    }

        if (AccountAddress != null) {
            extensions.Add(new() {
                Tag = PresentationConstants.ExtensionTagsClaimIdTag,
                Value = AccountAddress.ToUTF8()
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


        //Screen.WriteLine($"Client {Protocol} - State {StreamState} Post data to {RemoteStreamId?.ToStringBase16()}");

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

        //Screen.WriteLine($"URI: {Uri}");
        //Uri = "http://voodoo:15099/.well-known/mmm/";

        var responsepacketData = await Uri.UploadDataTaskAsync(encoded);
        var (_, position) = StreamId.GetSourceId(responsepacketData);
        //Screen.WriteLine($"Client Received Stream ID {sourceId.Elements}");

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

        ConnectionInitiator.RudStreamInitial = this;

        StreamState = StreamState.Data;
        InitializeStream(ref extensions);
        var encoded = ConnectionInitiator.SerializeInitiatorComplete(
            LocalStreamId.GetValue(), span,
            ciphertextExtensions: extensions);


        //Screen.WriteLine($"Complete");
        var responsepacketData = await Uri.UploadDataTaskAsync(encoded);
        var (_, position) = StreamId.GetSourceId(responsepacketData);
        //Screen.WriteLine($"Client Received Stream ID {sourceId.Elements}");

        var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);

        Process(packet);
        return packet;
        }


    async Task<Packet> PostWebChild(byte[] span, List<PacketExtension> extensions = null) {
        StreamState = StreamState.Data;
        InitializeStream(ref extensions);

        var remoteStreamIdInitial = RdpStreamParent?.RemoteStreamId ?? ConnectionInitiator?.RudStreamInitial.RemoteStreamId;
        remoteStreamIdInitial.AssertNotNull(NYI.Throw);

        var encoded = RudConnection.SerializePacketData(destinationStream: remoteStreamIdInitial, payload: span,
            ciphertextExtensions: extensions);

        //Screen.WriteLine($"Child");

        var responsepacketData = await Uri.UploadDataTaskAsync(encoded);
        var (_, position) = StreamId.GetSourceId(responsepacketData);
        //Screen.WriteLine($"Client Received Stream ID {sourceId.Elements}");

        var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);
        Process(packet);
        return packet;
        }

    async Task<Packet> PostWebData(byte[] span, List<PacketExtension> extensions = null) {
        StreamState = StreamState.Data;
        var encoded = RudConnection.SerializePacketData(destinationStream: RemoteStreamId, payload: span,
            ciphertextExtensions: extensions);

        //Screen.WriteLine($"Data");
        var responsepacketData = await Uri.UploadDataTaskAsync(encoded);
        var (_, position) = StreamId.GetSourceId(responsepacketData);
        //Screen.WriteLine($"Client Received Stream ID {sourceId.Elements}");

        var packet = RudConnection.ParsePacketData(responsepacketData, position, responsepacketData.Length);
        Process(packet);
        return packet;
        }



    void Process(PacketData packetData) => RemoteStreamId ??= PacketExtension.GetExtensionByTag(packetData?.CiphertextExtensions,
                PresentationConstants.ExtensionTagsStreamIdTag);

    void Process(PacketResponderChallenge packetResponderChallenge) {
        if (packetResponderChallenge.PlaintextExtensions != null) {
            foreach (var extension in packetResponderChallenge.PlaintextExtensions) {
                switch (extension.Tag) {
                    case PresentationConstants.ExtensionTagsChallengeTag: {
                            ChallengeNonce = extension.Value;
                            break;
                            }
                    case PresentationConstants.ExtensionTagsChallengeProofOfWorkTag: {
                            ChallengePoW = extension.Value;
                            break;
                            }
                        //case Constants.ExtensionTagsMeshConnectionTag: {

                        //    break;
                        //}
                    }
                }
            }
        ConnectionInitiator.CredentialOther = ConnectionInitiator.CredentialSelf.GetCredentials(
                    packetResponderChallenge.PlaintextExtensions);
        // get the challenge out
        //var challenge = PacketExtension.GetExtensionByTag(packetResponderChallenge?.PlaintextExtensions,
        //        Constants.ExtensionTagsChallengeTag);

        // get the stream id for the response.
        RemoteStreamId = packetResponderChallenge.SourceId;

        }

    //void GetSourceId(PacketData packet) {
    //    RemoteStreamId = PacketExtension.GetExtensionByTag(packet?.CiphertextExtensions,
    //            Constants.ExtensionTagsStreamIdTag);

    //    }


    private byte[] SerializePayload(string tag, JsonObject request, out MemoryStream stream) {
        stream = new MemoryStream();
        var writer = JsonObject.GetJsonWriter(RudConnection.ObjectEncoding, stream);
        writer.WriteObjectStart();

        writer.WriteToken(tag, 0);
        request.Serialize(writer, false);

        writer.WriteObjectEnd();


        //Screen.WriteLine($"Payload: { stream.ToArray().ToUTF8()}");
        // avoid the copy by using a Span.
        return stream.ToArray();
        }

    private void AddChild(RudStream child) {
        ChildStreams ??= new();
        ChildStreams.Add(child);
        }

    /// <summary>
    /// Remove a child stream.
    /// </summary>
    /// <param name="child">The child to drop.</param>
    protected void RemoveChild(RudStream child) => _ = ChildStreams.Remove(child);


    /// <summary>
    /// Request creation of a transactional stream in the client role.
    /// </summary>
    /// <param name="protocol">The protocol identifier</param>
    /// <param name="credentialSelf">Optional additional credential to be presented.</param>
    /// <returns>The created stream.</returns>
    public RudStreamClient MakeStreamClient(string protocol, ICredentialPrivate credentialSelf = null) =>
        new(this, protocol, credentialSelf);


    /// <summary>
    /// Request creation of an asynchronous stream in the sender role.
    /// </summary>
    /// <param name="credential">Optional additional credential to be presented.</param>
    /// <returns>The created stream.</returns>
    public RudStreamClient MakeStreamSender(ICredentialPrivate credential = null) => throw new NYI(this, credential);

    /// <summary>
    /// Request creation of a transactional stream in the server role
    /// </summary>
    /// <param name="transactionPostDelegate">Optional delegate to be called when a request is received.</param>
    /// <returns>The created stream.</returns>
    public RudStreamService MakeStreamService(TransactionPostDelegate transactionPostDelegate = null) => throw new NYI(this, transactionPostDelegate);


    /// <summary>
    /// Request creation of an asynchronous stream in the receiver role.
    /// </summary>
    /// <param name="asynchronousReceiveDelegate">Optional delegate to be called when data is received.</param>
    /// <returns></returns>
    public RudStreamReceiver MakeStreamReceiver(AsynchronousReceiveDelegate asynchronousReceiveDelegate = null) => throw new NYI(this, asynchronousReceiveDelegate);

    /// <summary>
    /// Cause queued requests to be flushed.
    /// </summary>
    public void Flush() => throw new NYI(this);

    //public async Task<RudStream> AsyncReceiveStreamOffer() => throw new NYI();



    #endregion

    }
