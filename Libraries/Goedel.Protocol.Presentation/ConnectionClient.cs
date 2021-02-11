using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Client side connection state.
    /// </summary>
    public enum ClientState {
        ///<summary>Initial state, sending either Initial or Cloaked.</summary> 
        Initial,
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

        ///<summary>The shared session key.</summary> 
        public byte[] Key { get; set; }


        /// <summary>
        /// Serialize a data packet.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        public byte[] SerializeData(byte[] payload, List<PacketExtension> extensions=null) {

            using var writer = new PacketWriterAesGcm();

            // write the control packet type
            writer.Write(EncryptedPacketIdentifier.Atomic);

            // write any packet options.
            writer.WriteOptions(extensions);

            // write the payload
            writer.Write(payload);

            // encrypt the result and return.
            return writer.Wrap(Key);
            }

        }

    /// <summary>
    /// Client connection class.
    /// </summary>
    public abstract class ConnectionClient : Connection {

        /// <summary>The credential to be presented by the client.</summary>
        PresentationCredential ClientCredential { get; }

        /// <summary>The credential to be presented by the host.</summary>
        PresentationCredential HostCredential { get; set; }

        ///<summary>The client state.</summary> 
        public ClientState ClientState { get; private set; }

        PacketClientChallenge packetClientChallenge { get; set; }

        string Protocol { get; }
        string Endpoint { get; }





        PortId PortID;

        /// <summary>
        /// Constructor, establish a client connection for the service 
        /// <paramref name="protocol"/> at address <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="protocol">The service protocol.</param>
        /// <param name="endpoint">The service address.</param>
        /// <param name="portID">The port identifier.</param>
        /// <param name="clientCredential">The client credential.</param>
        /// <param name="hostCredential">The host credential (if known).</param>
        public ConnectionClient(string protocol,
                            string endpoint,
                            PortId portID,
                            PresentationCredential clientCredential,
                            PresentationCredential hostCredential=null) {
            ClientState = ClientState.Initial;
            ClientCredential = clientCredential;
            HostCredential = hostCredential;
            Protocol = protocol;
            Endpoint = endpoint;
            PortID = portID;
            }

        /// <summary>
        /// Establish a connection to the identified host. 
        /// </summary>
        /// <param name="jsonObject">The record to be sent.</param>
        /// <returns>The record returned.</returns>
        public virtual async Task<JsonObject> Open(JsonObject jsonObject=null) {

            var data = jsonObject.GetJsonB(true);
            var response = Write(data);
            await response;

            var reader = new JsonBcdReader(response.Result.Data);
            return JsonObject.FromJson(reader, true);
            }

        /// <summary>
        /// Write the record <paramref name="jsonObject"/> to the connection. 
        /// </summary>
        /// <param name="jsonObject">The record to be sent.</param>
        /// <returns>The record returned.</returns>

        public virtual async Task<JsonObject> Write(JsonObject jsonObject) {

            var data = jsonObject.GetJsonB(true);
            var response = Write(data);
            await response;

            var reader = new JsonBcdReader(response.Result.Data);
            return JsonObject.FromJson(reader, true);
            }

        /// <summary>
        /// Write the payload data <paramref name="data"/> to the connection.
        /// </summary>
        /// <param name="data">The data to write.</param>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public virtual async Task<PacketClientIn> Write(byte[] data, bool plaintext = false) {
            byte[] requestPacket = ClientState switch {
                ClientState.Initial => HostCredential == null ?
                    SerializeInitial(data) : SerializeClientExchange(data),
                ClientState.Challenge => SerializeClientExchange(data),
                ClientState.Write => SerializeData(data),
                _ => throw new InvalidClientState()
                };

            var response = PostPacket(requestPacket);
            await response;
            return response.Result;
            }


        /// <summary>
        /// Post a packet to the interface.
        /// </summary>
        /// <param name="data">The packet to post.</param>
        /// <returns>Response packet.</returns>
        public abstract Task<PacketClientIn> PostPacket(byte[] data) ;


        /// <summary>
        /// Serialize an initial request packet for this connection;
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeInitial(byte[] payload) {
            this.Future(); // prevent spurious error.

            var writer = new PacketWriter();

            // Hack: should add in options here.
            writer.Write(PlaintextPacketType.Initial);
            writer.Write(payload);

            return writer.Packet;
            }


        PacketWriter WritePayload(byte[] payload) {
            var writer = new PacketWriter();

            return writer;
            }

        KeyPairAdvanced ClientEphemeral { get; set; }
        KeyAgreementResult KeyAgreementResult { get; set; }

        /// <summary>
        ///  Serialize a client credential request packet with payload <paramref name="payload"/>.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="answerData">Answer data responding to a challenge puzzle presented by 
        /// the host or another party.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientExchange(byte[] payload, byte[] answerData=null) {
            var plaintextWriter = WritePayload(payload);

            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            KeyAgreementResult = ClientEphemeral.Agreement(HostCredential.KeyExchangePublic);
            var keyDerive = KeyAgreementResult.KeyDerive;
            var key = keyDerive.Derive(Constants.TagKey, Constants.SizeKeyAesGcm);

            


            // Write out the host key we are talking to (nb does not disclose the service)
            plaintextWriter.Write(HostCredential.KeyExchangePublic.KeyIdentifier);

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            plaintextWriter.Write(ClientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the challenge response data (if specified).
            plaintextWriter.Write(answerData);

            // Write out the set of options associated with the packet.
            plaintextWriter.WriteOptions();

            // write the encrypted packet
            var writer = new PacketWriterAesGcm();
            writer.Write(PlaintextPacketType.ClientExchange);
            writer.Encrypt(key, plaintextWriter);

            return writer.Packet;
            }



        }










    public class PacketClientIn  {

        public virtual byte[] Data { get; }


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
