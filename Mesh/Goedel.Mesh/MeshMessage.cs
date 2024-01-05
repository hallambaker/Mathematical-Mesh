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


namespace Goedel.Mesh;



public partial class Reference {

    ///<summary>Returns the envelope ID corresponding to the MessageID</summary>
    public override string EnvelopeId => Message.GetEnvelopeId(MessageId);

    ///<summary>Accessor for the <see cref="Relationship"/> property
    ///as a <see cref="MessageStatus"/> property.</summary>
    public StateSpoolMessage MessageStatus {
        get => Relationship.ToStateSpoolMessage();
        set => Relationship = value.ToLabel();
        }


    }

public partial class Message {

    ///<summary>The primary key is <see cref="MessageId"/></summary> 
    public override string _PrimaryKey => MessageId;

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<Message> EnvelopedMessage =>
        new(DareEnvelope);

    ///<summary>The message status.</summary>
    public StateSpoolMessage MessageStatus;



    ///<inheritdoc/>
    public override DareEnvelope Envelope(
                CryptoKey signingKey = null,
                CryptoKey encryptionKey = null,
                ObjectEncoding objectEncoding = ObjectEncoding.JSON) {

        MessageId ??= Udf.Nonce(); // Add a message ID unless one is already defined.
        return base.Envelope(signingKey, encryptionKey, objectEncoding);
        }

    /// <summary>
    /// Decode <paramref name="envelope"/> and return the inner <see cref="Message"/>
    /// </summary>
    /// <param name="envelope">The envelope to decode.</param>
    /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
    /// <returns>The decoded profile.</returns>
    public static new Message Decode(DareEnvelope envelope,
                IKeyCollection keyCollection = null) =>
                    MeshItem.Decode(envelope, keyCollection) as Message;



    ///<inheritdoc/>
    public override string EnvelopeId => GetEnvelopeId(MessageId);


    /// <summary>
    /// Return the identifier for a response to this message.
    /// </summary>
    /// <returns>The response identifier.</returns>
    public string GetResponseId() => GetResponseId(MessageId);


    /// <summary>
    /// Return the identifier for a response to the message <paramref name="messageId"/>.
    /// </summary>
    /// <param name="messageId">The message the response ID is requested for.</param>
    /// <returns>The response ID.</returns>
    public static string GetResponseId(string messageId) =>
        MakeID(messageId, MeshConstants.IanaTypeMeshResponseId);

    /// <summary>
    /// Compute the EnvelopeID for <paramref name="messageID"/>.
    /// </summary>
    /// <param name="messageID">The message identifier to calculate the envelope 
    /// identifer of</param>
    /// <returns>The envelope identifier.</returns>
    public static string GetEnvelopeId(string messageID) =>
                MakeID(messageID, MeshConstants.IanaTypeMeshEnvelopeId);


    static string MakeID(string udf, string content) {
        var (code, bds) = Udf.Parse(udf);
        return code switch {
            UdfTypeIdentifier.Digest_SHA_3_512 => Udf.ContentDigestOfDataString(
                bds, content, cryptoAlgorithmId: CryptoAlgorithmId.SHA_3_512),
            _ => Udf.ContentDigestOfDataString(
            bds, content, cryptoAlgorithmId: CryptoAlgorithmId.SHA_2_512),
            };
        }



    }
public partial class MessageError {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessageError> EnvelopedMessageError =>
        new(DareEnvelope);

    }
public partial class MessageComplete {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessageComplete> EnvelopedMessageComplete =>
        new(DareEnvelope);


    /// <summary>
    /// Constructor for use by deserializers.
    /// </summary>
    public MessageComplete() { }


    /// <summary>
    /// Constructor for a completion message.
    /// </summary>
    /// <param name="messageID">The message the completion message completes.</param>
    /// <param name="relationship">Relationship to the message.</param>
    /// <param name="responseID">The response code.</param>
    public MessageComplete(
                string messageID, string relationship, string responseID = null) {
        var reference = new Reference() {
            MessageId = messageID,
            Relationship = relationship,
            ResponseId = responseID
            };
        References = new List<Reference>() { reference };

        }

    }
public partial class MessageValidated {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessageValidated> EnvelopedMessagePinValidated =>
        new(DareEnvelope);

    ///<summary>The authorized action.</summary> 
    public virtual string Action { get; }

    /// <summary>
    /// Create authentication data using the pin value <paramref name="pin"/>/
    /// </summary>
    /// <param name="pin">The pin value.</param>
    public void Authenticate(
                string pin) {
        if (pin == null) {
            return;
            }

        var saltedPin = MessagePin.SaltPIN(pin, Action);

        ClientNonce = CryptoCatalog.GetBits(128);
        PinWitness = MessagePin.GetPinWitness(saltedPin, Recipient, AuthenticatedData, ClientNonce);
        PinId = MessagePin.GetPinId(saltedPin, Recipient);
        }

    /// <summary>
    /// Verify authentication data using the pin data in <paramref name="messagePin"/>, 
    /// binding to the account <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="messagePin">The pin data to use for validation.</param>
    /// <param name="accountAddress">The account address to which the validation data is bound.</param>
    /// <returns>The result of the verification operation.</returns>
    public ProcessingResult ValidatePin(
            MessagePin messagePin,
            string accountAddress) {

        if (messagePin == null) {
            return ProcessingResult.PinInvalid;
            }
        if (!messagePin.MessageStatus.IsOpen()) {
            return ProcessingResult.PinUsed;
            }
        if (messagePin.Expires != null && messagePin.Expires < System.DateTime.Now) {
            return ProcessingResult.PinExpired;
            }
        var pinWitness = MessagePin.GetPinWitness(
                    messagePin.SaltedPin,
                    accountAddress,
                    AuthenticatedData,
                    ClientNonce);
        if (!pinWitness.IsEqualTo(PinWitness)) {
            return ProcessingResult.PinInvalid;
            }

        return ProcessingResult.Success;
        }


    }
public partial class MessagePin {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessagePin> EnvelopedMessagePIN =>
        new(DareEnvelope);


    ///<summary>The unbound PIN code.</summary>
    public string Pin { get; }
    /// <summary>
    /// Default constructor used for deserialization.
    /// </summary>
    public MessagePin() {
        }

    /// <summary>
    /// Construct a <see cref="MessagePin"/> instance for the PIN value
    /// <paramref name="pin"/> and account address <paramref name="accountAddress"/>
    /// with optional expiry value <paramref name="expires"/>.
    /// </summary>
    /// <param name="pin">The PIN value.</param>
    /// <param name="expires">The expiry time.</param>
    /// <param name="action">The purpose for which the pin is registered.</param>
    /// <param name="accountAddress">The account address the PIN is issued for.</param>
    /// <param name="automatic">If true, the actions authenticated with the PIN should be
    /// automatically authorized.</param>
    public MessagePin(string pin, bool automatic, System.DateTime? expires, string accountAddress, string action) {
        Account = accountAddress;
        Automatic = automatic;
        Expires = expires;
        Pin = pin;
        SaltedPin = SaltPIN(pin, action);
        Action = action;
        MessageId = GetPinId(SaltedPin, accountAddress);

        //Screen.WriteLine($"Created Pin: {Account} / {SaltedPin} => {MessageId}");
        }


    /// <summary>
    /// Salt the pin code <paramref name="pin"/> to bind it to the action 
    /// <paramref name="action"/>.
    /// </summary>
    /// <param name="pin">The pin code presented to the user.</param>
    /// <param name="action">The action to which the pin code is bound.</param>
    /// <returns>UDF presentation of the salted PIN.</returns>
    public static string SaltPIN(string pin, string action) => Udf.SymmetricKeyMac(action.ToUTF8(), pin);


    /// <summary>
    /// Validate a message request against a pin value;
    /// </summary>
    /// <param name="messagePin">The message describing the PIN</param>
    /// <param name="accountAddress">Account to which the PIN is bound.</param>
    /// <param name="envelope">The envelope to authenticate.</param>
    /// <param name="nonce">Client nonce value.</param>
    /// <param name="witness">The witness value being tested.</param>
    /// <returns></returns>
    public static ProcessingResult ValidatePin(
                MessagePin messagePin,
                string accountAddress,
                DareEnvelope envelope,
                byte[] nonce,
                byte[] witness) {

        if (messagePin == null) {
            return ProcessingResult.PinInvalid;
            }
        if (!messagePin.MessageStatus.IsOpen()) {
            return ProcessingResult.PinUsed;
            }
        if (messagePin.Expires != null && messagePin.Expires < System.DateTime.Now) {
            return ProcessingResult.PinExpired;
            }
        var pinWitness = MessagePin.GetPinWitness(
                    messagePin.SaltedPin,
                    accountAddress,
                    envelope,
                    nonce);
        if (!pinWitness.IsEqualTo(witness)) {
            return ProcessingResult.PinInvalid;
            }

        return ProcessingResult.Success;
        }


    /// <summary>
    /// Get the 
    /// </summary>
    /// <returns></returns>
    public string GetURI() => MeshUri.ConnectUriDevice(Account, Pin);

    /// <summary>
    /// PIN code identifier 
    /// </summary>
    /// <param name="pin">The salted one time code</param>
    /// <param name="accountAddress">The account address of the issuer of the PIN</param>
    /// <returns>The PIN Code identifier.</returns>
    public static string GetPinId(
                string pin,
                string accountAddress) {
        var result = Udf.SymmetricKeyMac(accountAddress.CannonicalAccountAddressUtf8(), pin);

        //ScreenConsole.WriteLine($"{pin} + {accountAddress}  -> PinUDF = {result}");

        return result;
        }

    /// <summary>
    /// Witness value calculated as KDF (envelope + AccountAddress+ClientNonce, pin)
    /// </summary>
    /// <param name="pin">The salted one time code</param>
    /// <param name="accountAddress">The account address of the issuer of the PIN</param>
    /// <param name="envelope">The enveloped data to be witnessed.</param>
    /// <param name="clientNonce">Nonce value to bind to the exchange.</param>
    /// <returns>The binary witness value.</returns>
    public static byte[] GetPinWitness(
                string pin,
                string accountAddress,
                DareEnvelope envelope,
                byte[] clientNonce) {

        //Screen.WriteLine($"PIN Witness {pin} on {accountAddress}");

        //Screen.WriteLine($"clientNonce {clientNonce.ToStringBase16FormatHex()}");
        var digest = envelope.Trailer.PayloadDigest;

        //Screen.WriteLine($"clientNonce {digest.ToStringBase16FormatHex()}");
        return Udf.PinWitness(pin, accountAddress.CannonicalAccountAddressUtf8(), clientNonce, digest);
        }
    }
public partial class RequestConnection {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<RequestConnection> EnvelopedRequestConnection =>
        new(DareEnvelope);

    ///<summary>The action for pin code validation.</summary> 
    public override string Action => MeshConstants.MessagePINActionDevice;

    /// <summary>
    /// Default constructor used for deserialization.
    /// </summary>
    public RequestConnection() {
        }

    /// <summary>
    /// Constructor for a <see cref="RequestConnection"/> instance for connecting the
    /// device <paramref name="profileDevice"/> to the account
    /// <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="profileDevice">Profile of the device requesting connection.</param>
    /// <param name="accountAddress">The account through which the device is requesting 
    /// a connection.</param>
    /// <param name="pin">Optional PIN value</param>
    /// <param name="clientNonce">Optional client nonce (if null, a nonce will be
    /// generated.</param>
    public RequestConnection(
            ProfileDevice profileDevice,
        string accountAddress,
        string pin = null,
        byte[] clientNonce = null) {
        AccountAddress = accountAddress;
        AuthenticatedData = profileDevice.DareEnvelope;
        ClientNonce = clientNonce ?? CryptoCatalog.GetBits(128);

        if (pin != null) {
            var saltedPin = MessagePin.SaltPIN(pin, MeshConstants.MessagePINActionDevice);
            PinId = MessagePin.GetPinId(saltedPin, accountAddress);
            PinWitness = MessagePin.GetPinWitness(
                    saltedPin, accountAddress, profileDevice.DareEnvelope, ClientNonce);
            }
        }


    ///<summary>Convenience accessor for the inner <see cref="ProfileDevice"/></summary>
    public ProfileDevice ProfileDevice => profileDevice ??
        ProfileDevice.Decode(AuthenticatedData).CacheValue(out profileDevice);
    ProfileDevice profileDevice;

    }
public partial class AcknowledgeConnection {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<AcknowledgeConnection> GetEnvelopedAcknowledgeConnection() =>
        new(DareEnvelope);

    ///<summary>Convenience accessor for the inner <see cref="AcknowledgeConnection"/></summary>
    public RequestConnection MessageConnectionRequest =>
                EnvelopedRequestConnection.Decode(KeyCollection);

    }
public partial class RespondConnection {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<RespondConnection> EnvelopedRespondConnection => new(DareEnvelope);


    /// <summary>
    /// Validate the RespondConnection message in the context of <paramref name="profileDevice"/>
    /// and <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="profileDevice">The profile device.</param>
    /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
    public void Validate(ProfileDevice profileDevice, IKeyLocate keyCollection) {
        profileDevice.Future();
        keyCollection ??= this.KeyCollection;
        keyCollection.Future();

        // Validate the chain for the device to master

        // Profile Master is self Signed
        // Device Profile connection is valid under Profile Master
        // Device Activation for master is valid


        // Foreach Account 
        //  // Validate the chain for the device to account

        //  // Profile Account is self Signed
        //  // Account connection is valid under Profile Master
        //  // Device Account connection is valid under Profile Account
        //  // Device Activation for Account is valid

        }

    }
public partial class MessageContact {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<MessageContact> EnvelopedRequestContact =>
        new(DareEnvelope);

    ///<summary>The action for pin code validation.</summary> 
    public override string Action => MeshConstants.MessagePINActionContact;

    }

public partial class GroupInvitation {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<GroupInvitation> GetEnvelopedGroupInvitation() => new(DareEnvelope);
    }
public partial class RequestConfirmation {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<RequestConfirmation> GetEnvelopedRequestConfirmation() =>
        new(DareEnvelope);

    }
public partial class ResponseConfirmation {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ResponseConfirmation> GetEnvelopedResponseConfirmation() => new(DareEnvelope);
    }
public partial class RequestTask {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<RequestTask> GetEnvelopedRequestTask() =>
        new(DareEnvelope);
    }
public partial class ProcessResult {
    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ProcessResult> GetEnvelopedProcessResult() => new(DareEnvelope);
    }
