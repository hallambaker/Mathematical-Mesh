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


        ///<summary>The message status.</summary>
        public MessageStatus MessageStatus;



        /// <summary>
        /// Encode the message using the signature key <paramref name="signingKey"/>.
        /// </summary>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>The enveloped, signed message.</returns>
        public override DareEnvelope Encode(CryptoKey signingKey = null, CryptoKey encryptionKey = null) {

            MessageID ??= UDF.Nonce(); // Add a message ID unless one is already defined.

            var data = this.GetBytes();
            var contentMeta = new ContentMeta() {
                UniqueID = MessageID,
                Created = DateTime.Now,
                ContentType = Constants.IanaTypeMeshMessage,
                MessageType = _Tag
                };

            DareEnvelope = DareEnvelope.Encode(data, contentMeta: contentMeta,
                signingKey: signingKey, encryptionKey: encryptionKey);

            DareEnvelope.Header.EnvelopeID = GetEnvelopeId(MessageID);

            return DareEnvelope;
            }

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="Message"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new Message Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as Message;


        /// <summary>
        /// Compute the EnvelopeID for <paramref name="messageID"/>.
        /// </summary>
        /// <param name="messageID">The message identifier to calculate the envelope 
        /// identifer of</param>
        /// <returns>The envelope identifier.</returns>
        public static string GetEnvelopeId(string messageID) =>
                    UDF.ContentDigestOfUDF(messageID);


        /// <summary>
        /// Sign the profile under <paramref name="SignatureKey"/>.
        /// </summary>
        /// <param name="SignatureKey">The signature key (MUST match the offline key).</param>
        /// <returns>Envelope containing the signed profile. Also updates the property
        /// <see cref="EnvelopedRequestConnection"/></returns>
        public virtual DareEnvelope Sign(CryptoKey SignatureKey) {
            DareEnvelope = DareEnvelope.Encode(this.GetBytes(true), signingKey: SignatureKey);
            return DareEnvelope;
            }



        }

    public partial class MessageComplete {

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

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="MessageComplete"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new MessageComplete Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as MessageComplete;



        }

    public partial class MessagePIN {

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



        ///// <summary>
        ///// Witness value calculated as KDF (Device.UDF + AccountAddress+ClientNonce, pin)
        ///// </summary>
        ///// <param name="pin">The salted one time code</param>
        ///// <param name="accountAddress">The account address of the issuer of the PIN</param>
        ///// <param name="deviceUDF">The data being witnessed.</param>
        ///// <param name="clientNonce">Nonce value to bind to the exchange.</param>
        ///// <returns>The binary witness value.</returns>
        //static byte[] GetPinWitness(
        //            string pin,
        //            string accountAddress,
        //            string deviceUDF,
        //            byte[] clientNonce) => UDF.PinWitness(pin, accountAddress.ToUTF8(),
        //                clientNonce, deviceUDF.ToUTF8());

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

    public partial class AcknowledgeConnection {



        ///<summary>Convenience accessor for the inner <see cref="AcknowledgeConnection"/></summary>
        public RequestConnection MessageConnectionRequest => messageConnectionRequest ??
            RequestConnection.Decode(EnvelopedRequestConnection).CacheValue(out messageConnectionRequest);
        RequestConnection messageConnectionRequest;


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new AcknowledgeConnection Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as AcknowledgeConnection;

        }


    public partial class RequestConnection {

        ///<summary>The signed profile</summary> 
        public EnvelopedRequestConnection EnvelopedRequestConnection { get; protected set; }

        /// <summary>
        /// Sign the profile under <paramref name="SignatureKey"/>.
        /// </summary>
        /// <param name="SignatureKey">The signature key (MUST match the offline key).</param>
        /// <returns>Envelope containing the signed profile. Also updates the property
        /// <see cref="EnvelopedRequestConnection"/></returns>
        public override DareEnvelope Sign(CryptoKey SignatureKey) {
            EnvelopedRequestConnection = EnvelopedRequestConnection.Encode(this, signingKey: SignatureKey);
            DareEnvelope = EnvelopedRequestConnection;
            return DareEnvelope;
            }



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


        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RequestConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new RequestConnection Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as RequestConnection;



        //public void Authenticate (string pin) => throw new NYI();


        /// <summary>
        /// Verified decoding of the enveloped request <paramref name="envelope"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The decoded profile (if signature verification succeeds).</returns>
        public static RequestConnection Verify(DareEnvelope envelope) {
            var result = Decode(envelope) as RequestConnection;

            // ToDo: put the verification code in here.


            return result;
            }




        }

    public partial class RespondConnection {



        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new RespondConnection Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as RespondConnection;

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


    public partial class RequestConfirmation {

        ///<summary>The signed profile</summary> 
        public EnvelopedRequestConfirmation EnvelopedRequestConfirmation { get; protected set; }

        /// <summary>
        /// Sign the profile under <paramref name="SignatureKey"/>.
        /// </summary>
        /// <param name="SignatureKey">The signature key (MUST match the offline key).</param>
        /// <returns>Envelope containing the signed profile. Also updates the property
        /// <see cref="EnvelopedRequestConfirmation"/></returns>
        public override DareEnvelope Sign(CryptoKey SignatureKey) {
            EnvelopedRequestConfirmation = EnvelopedRequestConfirmation.Encode(this, signingKey: SignatureKey);
            DareEnvelope = EnvelopedRequestConfirmation;
            return DareEnvelope;
            }

        }

    }
