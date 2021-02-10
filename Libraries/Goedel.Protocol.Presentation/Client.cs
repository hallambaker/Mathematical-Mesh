using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Client side connection state.
    /// </summary>
    public enum ClientState {
        ///<summary>Initial state, sending either Initial or Cloaked.</summary> 
        Start,
        ///<summary>Host challenge received, sending answer.</summary> 
        Challenge,
        ///<summary>Connection established, sending packets.</summary> 
        Write,
        ///<summary>Connection terminated, cannot be used further.</summary> 
        Abort
        }



    /// <summary>
    /// Base class for connections
    /// </summary>
    public class Connection : Disposable {
        }

    /// <summary>
    /// Client connection class.
    /// </summary>
    public class ConnectionClient : Connection {

        /// <summary>The credential to be presented by the client.</summary>
        PresentationCredential ClientCredential { get; }

        /// <summary>The credential to be presented by the host.</summary>
        PresentationCredential HostCredential { get; set; }

        ///<summary>The client state.</summary> 
        public ClientState ClientState { get; private set; }

        PacketClientChallenge packetClientChallenge { get; set; }

        string Protocol { get; }
        string Endpoint { get; }

        PortID PortID;

        /// <summary>
        /// Constructor, establish a client connection for the service 
        /// <paramref name="protocol"/> at address <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="protocol">The service protocol.</param>
        /// <param name="endpoint">The service address.</param>
        /// <param name="portID">The port identifier.</param>
        /// <param name="clientCredential">The client credential.</param>
        /// <param name="hostCredential">The host credential (if known).</param>
        /// <param name="payload">The payload to be sent in the initial packet.</param>
        public ConnectionClient(string protocol,
                            string endpoint,
                            PortID portID,
                            PresentationCredential clientCredential,
                            PresentationCredential hostCredential=null,
                            byte[] payload=null) {
            ClientState = ClientState.Start;
            ClientCredential = clientCredential;
            HostCredential = hostCredential;
            Protocol = protocol;
            Endpoint = endpoint;
            PortID = portID;
            }


        public virtual PacketClient Post(PacketClientOut packetClientOut) {
            throw new NYI();
            }



        public PacketClient Write(byte[] payload) {

            switch (ClientState) {
                case ClientState.Start: {
                    var response = Open(payload);
                    switch (response) {
                        case PacketClientChallenge challenge: {
                            packetClientChallenge = challenge;
                            ClientState = ClientState.Challenge;
                            break;
                            }
                        case PacketClientComplete: {
                            ClientState = ClientState.Write;
                            break;
                            }
                        case PacketClientData:
                        case PacketClientAbort: {
                            ClientState = ClientState.Abort;
                            break;
                            }
                        }
                    return response;
                    }
                case ClientState.Challenge: {
                    break;
                    }
                case ClientState.Write: {
                    break;
                    }
                case ClientState.Abort: {
                    // Can't send data, connection is closed.
                    throw new NYI();
                    }


                }

            throw new NYI();
            }


        public PacketClient Open(byte[] payload) {
            PacketClientOut packet;

            if (HostCredential == null) {

                packet = new PacketClientInitial(payload);

                }
            else {
                packet = new PacketClientCloaked(ClientCredential, HostCredential, 
                    Protocol, Endpoint, payload);

                }

            var result = Post(packet);

            switch (result) {

                case PacketClientChallenge challenge: return Answer(challenge, payload);

                case PacketClientData:

                case PacketClientComplete: return result;


                case PacketClientAbort: {

                    // set to inactive

                    return result;
                    }
                }



            throw new NYI();
            }

        public PacketClient Answer(PacketClientChallenge challenge, byte[] payload) {
            throw new NYI();
            }


        public PacketClient Post(byte[] payload) {
            throw new NYI();
            }



        /// <summary>
        /// Serialize an initial request packet for this connection;
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeInitial(byte[] payload) {

            var buffer = new MemoryStream(Constants.MinimumPacketSize);
            buffer.WriteByte((byte)ClientPacketType.Initial);

            var writer = new JSONBWriter(buffer);
            writer.WriteBinary(payload);

            if (buffer.Position < Constants.MinimumPacketSize) {
                buffer.Write(Constants.ZeroArray, 0, Constants.MinimumPacketSize - buffer.Position);
                }

            return buffer.ToArray();
            }


        KeyPairAdvanced ClientEphemeral { get; set; }
        KeyAgreementResult KeyAgreementResult { get; set; }
        public byte[] SerializeCloaked(byte[] payload) {
            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            KeyAgreementResult = ClientEphemeral.Agreement(HostCredential.KeyExchangePublic);
            return SerializeExchange(payload);
            }

        public byte[] SerializeAnswer(byte[] payload, byte[] answerData) {
            return SerializeExchange(payload, answerData);
            }



        public byte[] SerializeData(byte[] payload) {

            using var buffer = new MemoryStream(Constants.MinimumPacketSize);

            // Create the nonce value, set the top bit and write out to the buffer.
            var nonce = Platform.GetRandomBytes(16);
            nonce[0] |= 0b1000_0000;
            buffer.Write(nonce);

            // skip over the authentication tag length


            var encryptedLength = Constants.MinimumPacketSize - buffer.Position;

            using var plaintextBuffer = new MemoryStream((int)encryptedLength);
            using var plaintextWriter = new JSONBWriter(plaintextBuffer);

            // write the connection ticket specified by the service.

            // write out the client stream number

            // write out the packet serial number

            // write out the payload
            plaintextWriter.WriteBinary(payload);

            // pad the remainder of the packet


            // get the key


            // encrypt


            buffer.Write(plaintextBuffer.ToArray()); // Hack, not encrypting yet

            throw new NYI();
            }



        protected byte[] SerializeExchange(
                byte[] payload,
                byte[] Answer = null) {

            using var buffer = new MemoryStream(Constants.MinimumPacketSize);


            if (Answer == null) {
                buffer.WriteByte((byte)ClientPacketType.Cloaked);
                }
            else {
                buffer.WriteByte((byte)ClientPacketType.Answer);
                }

            using var writer = new JSONBWriter(buffer);

            // Write out the nonce
            writer.WriteBinary(Platform.GetRandomBytes(16));

            // Mark the position in the stream and reserve space for the signature.
            var signaturePoint = buffer.Position;
            writer.WriteBinary(Constants.ZeroArray, 0, ClientCredential.KeySignPublic.LengthSignature);

            // If this is an answer, write out the 
            if (Answer != null) {
                writer.WriteBinary(Answer);
                }

            // Write out the host key we are talking to (nb does not disclose the service)
            writer.WriteString(HostCredential.KeyExchangePublic.KeyIdentifier);

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            writer.WriteBinary(ClientEphemeral.IKeyAdvancedPublic.Encoding);

            var blockSize = 16; // hack: make this the symmetric cipher length...
            var encryptedLength = blockSize *
                ((Constants.MinimumPacketSize - buffer.Position + blockSize - 1) / blockSize);

            using var plaintextBuffer = new MemoryStream((int)encryptedLength);
            using var plaintextWriter = new JSONBWriter(plaintextBuffer);
            // now write out the encrypted stuff

            // The client credential
            ClientCredential.WriteClientCredential(plaintextWriter);
            plaintextWriter.WriteString(Protocol);
            plaintextWriter.WriteString(Endpoint);
            plaintextWriter.WriteBinary(payload);

            // padd the remainder of the plaintext buffer with zeros
            plaintextBuffer.Write(Constants.ZeroArray, 0, encryptedLength - plaintextBuffer.Position);

            // now encrypt the plaintextwriter data
            // hack: not encrypting yet

            // now add the ciphertext to the buffer
            buffer.Write(plaintextBuffer.ToArray());

            return buffer.ToArray();
            }



        }






    /// <summary>
    /// The client packet types. Two bits in the first byte of the nonce value are used to specify 
    /// the packet type to the host. The set of packet types is intentionally closed.
    /// </summary>
    public enum ClientPacketType {

        ///<summary>Used to make a plaintext request to establish a new connection to the host.
        ///This MUST used in cases where the client does not have the public key of the host.</summary> 
        Initial = 0b00,

        ///<summary>Used to make an encrypted request to establish a new connection to the host.
        ///This MAY be used in cases where the client has the public key of the host.</summary> 
        Cloaked = 0b01,

        ///<summary>Used to respond to a challenge from the host or service. Challenges are sent
        ///by the host in response to the Initial and Cloaked packets and in cases where a failure occurs
        ///and the Host opts to offer the opportunity to resynchronze. Challenges are sent by the 
        ///service in cases where a handoff is being performed.</summary> 
        Answer = 0b10,

        ///<summary>Used for all packets that are not control packets.</summary> 
        Post = 0b11,

        ///<summary>Mask used to identify the control bits in the first byte of a packet.</summary> 
        Mask = Post,

        ///<summary>Mask used to identify the control bits in the first byte of a packet.</summary> 
        MaskRest = 0xff ^ Post
        }


    public class PacketClient {
        }
    public class PacketClientOut : PacketClient {
        public virtual byte[] Data => throw new NYI();

        protected static byte[] GetData(
                PresentationCredential clientCredential,
                PresentationCredential hostCredential,
                string protocol,
                string endpoint,
                KeyPairAdvanced clientEphemeral,
                KeyAgreementResult keyAgreementResult,
                byte[] payload,
                byte[] Answer = null){

            using var buffer = new MemoryStream(Constants.MinimumPacketSize);


            if (Answer == null) {
                buffer.WriteByte((byte)ClientPacketType.Cloaked);
                }
            else {
                buffer.WriteByte((byte)ClientPacketType.Answer);
                }

            using var writer = new JSONBWriter(buffer);

            // Write out the nonce
            writer.WriteBinary(Platform.GetRandomBytes(16));

            // Mark the position in the stream and reserve space for the signature.
            var signaturePoint = buffer.Position;
            writer.WriteBinary(Constants.ZeroArray, 0, clientCredential.KeySignPublic.LengthSignature);

            // If this is an answer, write out the 
            if (Answer != null) {
                writer.WriteBinary(Answer);
                }

            // Write out the host key we are talking to (nb does not disclose the service)
            writer.WriteString(hostCredential.KeyExchangePublic.KeyIdentifier);

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            writer.WriteBinary(clientEphemeral.IKeyAdvancedPublic.Encoding);

            var blockSize = 16; // hack: make this the symmetric cipher length...
            var encryptedLength = blockSize *
                ((Constants.MinimumPacketSize - buffer.Position + blockSize - 1) / blockSize);

            using var plaintextBuffer = new MemoryStream((int)encryptedLength);
            using var plaintextWriter = new JSONBWriter(plaintextBuffer);
            // now write out the encrypted stuff

            // The client credential
            clientCredential.WriteClientCredential(plaintextWriter);
            plaintextWriter.WriteString(protocol);
            plaintextWriter.WriteString(endpoint);
            plaintextWriter.WriteBinary(payload);

            // padd the remainder of the plaintext buffer with zeros
            plaintextBuffer.Write(Constants.ZeroArray, 0, encryptedLength - plaintextBuffer.Position);

            // now encrypt the plaintextwriter data
            // hack: not encrypting yet

            // now add the ciphertext to the buffer
            buffer.Write(plaintextBuffer.ToArray());

            return buffer.ToArray();
            }


        }

    /// <summary>
    /// Initial packet. This contains only the packet type identifier and the plaintext payload.
    /// Since neither the request, nor the response packet can be encrypted, the payload is
    /// typically limited to a Hello request for the protocol version and host capabilities.
    /// </summary>
    public class PacketClientInitial : PacketClientOut {

        public override byte[] Data { get; }

        public PacketClientInitial(byte[] payload)  {



            var buffer = new MemoryStream(Constants.MinimumPacketSize);
            buffer.WriteByte((byte)ClientPacketType.Initial);

            var writer = new JSONBWriter(buffer);
            writer.WriteBinary(payload);

            if (buffer.Position < Constants.MinimumPacketSize) {
                buffer.Write(Constants.ZeroArray, 0, Constants.MinimumPacketSize - buffer.Position);
                }

            Data = buffer.ToArray();
            }
        }

    public class PacketClientCloaked : PacketClientOut {
        public KeyPairAdvanced ClientEphemeral { get; }
        public KeyAgreementResult KeyAgreementResult { get; }

        public override byte[] Data { get; }

        public PacketClientCloaked(
                            PresentationCredential clientCredential,
                            PresentationCredential hostCredential,
                            string protocol,
                            string endpoint,
                            byte[] payload) : base() {

            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            KeyAgreementResult = ClientEphemeral.Agreement(hostCredential.KeyExchangePublic);

            Data = GetData(
                                clientCredential, hostCredential, protocol, endpoint,
                                ClientEphemeral,
                                KeyAgreementResult,
                                payload);
            }




        }

    public class PacketClientAnswer : PacketClientOut {
        //public KeyPairAdvanced clientEphemeral { get; }
        //public KeyAgreementResult keyAgreementResult { get; }

        public override byte[] Data { get; }

        public PacketClientAnswer(
                            PresentationCredential clientCredential,
                            PresentationCredential hostCredential,
                            string protocol,
                            string endpoint,
                            PacketClientCloaked packetClientCloaked,
                            byte[] payload) {
            Data = GetData(
                                clientCredential, hostCredential, protocol, endpoint,
                                packetClientCloaked.ClientEphemeral,
                                packetClientCloaked.KeyAgreementResult,
                                payload);
            }


        public PacketClientAnswer(
                    PresentationCredential clientCredential,
                    PresentationCredential hostCredential,
                    string protocol,
                    string endpoint,
                    byte[] payload) {
            var clientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            var keyAgreementResult = clientEphemeral.Agreement(hostCredential.KeyExchangePublic);
            Data = GetData(
                    clientCredential, hostCredential, protocol, endpoint,
                    clientEphemeral,
                    keyAgreementResult,
                    payload);
            }


        public class PacketClientData : PacketClientOut {


            public PacketClientData() {

                }

            }


        }




    public class PacketClientIn : PacketClient {




        }

    public class PacketClientChallenge : PacketClientIn {
        }
    public class PacketClientComplete : PacketClientIn {
        }
    public class PacketClientData : PacketClientIn {
        }
    public class PacketClientAbort : PacketClientIn {
        }


    }
