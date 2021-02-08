using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {

    public class Connection : Disposable {
        }


    public enum ClientState {


        Start,

        Challenge,

        Write,

        Abort

        }





    public class ConnectionClient : Connection {
        public KeyPair ServicePublic { get; }

        public ClientState ClientState { get; private set; }

        PacketClientChallenge packetClientChallenge;
        PresentationCredential PresentationCredential;


        public ConnectionClient(PresentationCredential presentationCredential ,PortID portID, KeyPair servicePublic=null) {
            ServicePublic = servicePublic;
            ClientState = ClientState.Start;
            PresentationCredential = presentationCredential;
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

            if (ServicePublic == null) {

                packet = new PacketClientInitial(payload);

                }
            else {
                packet = new PacketClientCloaked(PresentationCredential, payload);

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
        Mask = Post


        }



    public abstract class PresentationCredential {
        protected abstract KeyPair ClientKeySignPrivate { get; }

        protected abstract KeyPair ClientKeyExchangePrivate { get; }

        public abstract KeyPair ClientKeySignPublic { get; }

        public abstract KeyPair clientKeyExchangePublic { get; }

        }


    public class PacketClient {
        }
    public class PacketClientOut : PacketClient {
        public virtual byte[] GetData() => throw new NYI();

        }
    public class PacketClientInitial : PacketClientOut {

        byte[] Payload { get; }

        public PacketClientInitial(byte[] payload) {
            Payload = payload;
            }

        public override byte[] GetData() {

            var buffer = new MemoryStream(Constants.MinimumPacketSize);
            buffer.WriteByte((byte)ClientPacketType.Initial);

            var writer = new JSONBWriter(buffer);
            writer.WriteBinary(Payload);

            if (buffer.Position < Constants.MinimumPacketSize) {
                buffer.Write(Constants.ZeroArray, 0, Constants.MinimumPacketSize - buffer.Position);
                }

            return buffer.ToArray();
            }
        }

    public class PacketClientCloaked : PacketClientOut {
        KeyPair clientEphemeral;

        public PacketClientCloaked(PresentationCredential presentationCredential,
                            byte[] payload) {

            clientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device);


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
