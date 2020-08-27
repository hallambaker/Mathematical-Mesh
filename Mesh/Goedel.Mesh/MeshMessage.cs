using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

namespace Goedel.Mesh {



    public partial class Reference {

        ///<summary>Returns the envelope ID corresponding to the MessageID</summary>
        public string EnvelopeID => Message.GetEnvelopeId(MessageID);

        ///<summary>Accessor for the <see cref="Relationship"/> property
        ///as a <see cref="MessageStatus"/> property.</summary>
        public MessageStatus MessageStatus {
            get => Relationship switch
                {
                    "Open" => MessageStatus.Open,
                    "Closed" => MessageStatus.Closed,
                    "Read" => MessageStatus.Read,
                    "Unread" => MessageStatus.Unread,
                    _ => MessageStatus.None
                    };
            set => Relationship = value switch
                {
                    MessageStatus.Open => "Open",
                    MessageStatus.Closed => "Closed",
                    MessageStatus.Read => "Read",
                    MessageStatus.Unread => "Unread",
                    _ => "Unknown"
                    };
            }

        }

    public partial class Message {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<Message> EnvelopedMessage =>
            envelopedMessage ?? new Enveloped<Message>(DareEnvelope).
                    CacheValue(out envelopedMessage);
        Enveloped<Message> envelopedMessage;

        ///<summary>The message status.</summary>
        public MessageStatus MessageStatus;

        public override string EnvelopeID => GetEnvelopeId(MessageID);

        /// <summary>
        /// Encode the message using the signature key <paramref name="signingKey"/>.
        /// </summary>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The enveloped, signed message.</returns>
        public override DareEnvelope Envelope(CryptoKey signingKey = null, CryptoKey encryptionKey = null) {

            MessageID ??= UDF.Nonce(); // Add a message ID unless one is already defined.
            return base.Envelope(signingKey, encryptionKey);


            //var data = this.GetBytes();
            //var contentMeta = new ContentMeta() {
            //    UniqueID = MessageID,
            //    Created = DateTime.Now,
            //    ContentType = Constants.IanaTypeMeshMessage,
            //    MessageType = _Tag
            //    };

            //DareEnvelope = DareEnvelope.Encode(data, contentMeta: contentMeta,
            //    signingKey: signingKey, encryptionKey: encryptionKey);

            //DareEnvelope.Header.EnvelopeID = GetEnvelopeId(MessageID);

            //return DareEnvelope;
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


        /// <summary>
        /// Compute the EnvelopeID for <paramref name="messageID"/>.
        /// </summary>
        /// <param name="messageID">The message identifier to calculate the envelope 
        /// identifer of</param>
        /// <returns>The envelope identifier.</returns>
        public static string GetEnvelopeId(string messageID) =>
                    UDF.ContentDigestOfUDF(messageID);

        }
    public partial class MessageError {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<MessageError> EnvelopedMessageError =>
            envelopedMessageError ?? new Enveloped<MessageError>(DareEnvelope).
                    CacheValue(out envelopedMessageError);
        Enveloped<MessageError> envelopedMessageError;

        }
    public partial class MessageComplete {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<MessageComplete> EnvelopedMessageComplete =>
            envelopedMessageComplete ?? new Enveloped<MessageComplete>(DareEnvelope).
                    CacheValue(out envelopedMessageComplete);
        Enveloped<MessageComplete> envelopedMessageComplete;

        ///<summary>Constant for the response Accept.</summary>
        public const string Accept = "Accept";

        ///<summary>Constant for the response Reject.</summary>
        public const string Reject = "Reject";

        ///<summary>Constant for the response Read.</summary>
        public const string Read = "Read";

        ///<summary>Constant for the response Unread.</summary>
        public const string Unread = "Unread";

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
                MessageID = messageID,
                Relationship = relationship,
                ResponseID = responseID
                };
            References = new List<Reference>() { reference };

            }

        }
    public partial class MessagePinValidated {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<MessagePinValidated> EnvelopedMessagePinValidated =>
            envelopedMessagePinValidated ?? new Enveloped<MessagePinValidated>(DareEnvelope).
                    CacheValue(out envelopedMessagePinValidated);
        Enveloped<MessagePinValidated> envelopedMessagePinValidated;
        }
    public partial class MessagePIN {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<MessagePIN> EnvelopedMessagePIN =>
            envelopedMessagePIN ?? new Enveloped<MessagePIN>(DareEnvelope).
                    CacheValue(out envelopedMessagePIN);
        Enveloped<MessagePIN> envelopedMessagePIN;


        ///<summary>The unbound PIN code.</summary>
        public string PIN { get; }
        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public MessagePIN() {
            }

        /// <summary>
        /// Construct a <see cref="MessagePIN"/> instance for the PIN value
        /// <paramref name="pin"/> and account address <paramref name="accountAddress"/>
        /// with optional expiry value <paramref name="expires"/>.
        /// </summary>
        /// <param name="pin">The PIN value.</param>
        /// <param name="expires">The expiry time.</param>
        /// <param name="action">The purpose for which the pin is registered.</param>
        /// <param name="accountAddress">The account address the PIN is issued for.</param>
        /// <param name="automatic">If true, the actions authenticated with the PIN should be
        /// automatically authorized.</param>
        public MessagePIN(string pin, bool automatic, DateTime? expires, string accountAddress, string action) {
            Account = accountAddress;
            Automatic = automatic;
            Expires = expires;
            PIN = pin;
            SaltedPIN = SaltPIN(pin, action);
            Action = action;
            MessageID = GetPinUDF(SaltedPIN, accountAddress);

            Console.WriteLine($"Created Pin: {Account} / {SaltedPIN} => {MessageID}");
            }


        /// <summary>
        /// Salt the pin code <paramref name="pin"/> to bind it to the action 
        /// <paramref name="action"/>.
        /// </summary>
        /// <param name="pin">The pin code presented to the user.</param>
        /// <param name="action">The action to which the pin code is bound.</param>
        /// <returns>UDF presentation of the salted PIN.</returns>
        public static string SaltPIN(string pin, string action) =>
            UDF.SymmetricKeyMac(action.ToUTF8(), pin);


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
                    MessagePIN messagePin,
                    string accountAddress,
                    DareEnvelope envelope,
                    byte[] nonce,
                    byte[] witness) {

            if (messagePin == null) {
                return ProcessingResult.PinInvalid;
                }
            if ((messagePin.MessageStatus & MessageStatus.Closed) == MessageStatus.Closed) {
                return ProcessingResult.PinUsed;
                }
            if (messagePin.Expires != null && messagePin.Expires < DateTime.Now) {
                return ProcessingResult.PinExpired;
                }
            var pinWitness = MessagePIN.GetPinWitness(
                        messagePin.SaltedPIN,
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
        public string GetURI() => MeshUri.ConnectUri(Account, PIN);

        /// <summary>
        /// PIN code identifier 
        /// </summary>
        /// <param name="pin">The salted one time code</param>
        /// <param name="accountAddress">The account address of the issuer of the PIN</param>
        /// <returns>The PIN Code identifier.</returns>
        public static string GetPinUDF(
                    string pin,
                    string accountAddress) {
            var result = UDF.PinWitnessString(pin, accountAddress.ToUTF8());

            Console.WriteLine($"{pin} + {accountAddress}  -> PinUDF = {result}");

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
            var digest = envelope.Trailer.PayloadDigest;
            return UDF.PinWitness(pin, accountAddress.ToUTF8(), clientNonce, digest);
            }
        }
    public partial class RequestConnection {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<RequestConnection> EnvelopedRequestConnection =>
            envelopedRequestConnection ?? new Enveloped<RequestConnection>(DareEnvelope).
                    CacheValue(out envelopedRequestConnection);
        Enveloped<RequestConnection> envelopedRequestConnection;

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
                var saltedPin = MessagePIN.SaltPIN(pin, Constants.MessagePINActionDevice);

                PinUDF = MessagePIN.GetPinUDF(saltedPin, accountAddress);
                PinWitness = MessagePIN.GetPinWitness(
                        saltedPin, accountAddress, profileDevice.DareEnvelope, ClientNonce);
                }
            }



        /// <summary>
        /// Verify that the witness value is correct for the specified <paramref name="pin"/> and
        /// values of Device UDF and Account Address.
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public bool Verify(string pin) => throw new NYI();

        ///<summary>Convenience accessor for the inner <see cref="ProfileDevice"/></summary>
        public ProfileDevice ProfileDevice => profileDevice ??
            ProfileDevice.Decode(AuthenticatedData).CacheValue(out profileDevice);
        ProfileDevice profileDevice;

        }
    public partial class AcknowledgeConnection {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<AcknowledgeConnection> EnvelopedAcknowledgeConnection =>
            envelopedAcknowledgeConnection ?? new Enveloped<AcknowledgeConnection>(DareEnvelope).
                    CacheValue(out envelopedAcknowledgeConnection);
        Enveloped<AcknowledgeConnection> envelopedAcknowledgeConnection;

        ///<summary>Convenience accessor for the inner <see cref="AcknowledgeConnection"/></summary>
        public RequestConnection MessageConnectionRequest =>
                    EnvelopedRequestConnection.Decode(KeyCollection);

        }
    public partial class RespondConnection {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<RespondConnection> EnvelopedRespondConnection =>
            envelopedRespondConnection ?? new Enveloped<RespondConnection>(DareEnvelope).
                    CacheValue(out envelopedRespondConnection);
        Enveloped<RespondConnection> envelopedRespondConnection;


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
    public partial class RequestContact {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<RequestContact> EnvelopedRequestContact =>
            envelopedRequestContact ?? new Enveloped<RequestContact>(DareEnvelope).
                    CacheValue(out envelopedRequestContact);
        Enveloped<RequestContact> envelopedRequestContact;
        }
    public partial class ReplyContact {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ReplyContact> EnvelopedReplyContact =>
            envelopedReplyContact ?? new Enveloped<ReplyContact>(DareEnvelope).
                    CacheValue(out envelopedReplyContact);
        Enveloped<ReplyContact> envelopedReplyContact;
        }
    public partial class GroupInvitation {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<GroupInvitation> EnvelopedGroupInvitation =>
            envelopedGroupInvitation ?? new Enveloped<GroupInvitation>(DareEnvelope).
                    CacheValue(out envelopedGroupInvitation);
        Enveloped<GroupInvitation> envelopedGroupInvitation;
        }
    public partial class RequestConfirmation {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<RequestConfirmation> EnvelopedRequestConfirmation =>
            envelopedRequestConfirmation ?? new Enveloped<RequestConfirmation>(DareEnvelope).
                    CacheValue(out envelopedRequestConfirmation);
        Enveloped<RequestConfirmation> envelopedRequestConfirmation;

        }
    public partial class ResponseConfirmation {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ResponseConfirmation> EnvelopedResponseConfirmation =>
            envelopedResponseConfirmation ?? new Enveloped<ResponseConfirmation>(DareEnvelope).
                    CacheValue(out envelopedResponseConfirmation);
        Enveloped<ResponseConfirmation> envelopedResponseConfirmation;
        }
    public partial class RequestTask {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<RequestTask> EnvelopedRequestTask =>
            envelopedRequestTask ?? new Enveloped<RequestTask>(DareEnvelope).
                    CacheValue(out envelopedRequestTask);
        Enveloped<RequestTask> envelopedRequestTask;
        }
    public partial class ProcessResult {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProcessResult> EnvelopedProcessResult =>
            envelopedProcessResult ?? new Enveloped<ProcessResult>(DareEnvelope).
                    CacheValue(out envelopedProcessResult);
        Enveloped<ProcessResult> envelopedProcessResult;
        }
    }
