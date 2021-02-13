using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
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
    /// Client connection class.
    /// </summary>
    public abstract class ConnectionClient : Connection {

        /// <summary>The credential to be presented by the client.</summary>
        PresentationCredential ClientCredential { get; }

        /// <summary>The credential to be presented by the host.</summary>
        PresentationCredential HostCredential { get; set; }

        ///<summary>The client state.</summary> 
        public ClientState ClientState { get; private set; }


        string Protocol { get; }
        string Endpoint { get; }


        KeyPairAdvanced ClientEphemeral { get; set; }
        KeyAgreementResult ClientKeyAgreementResult { get; set; }

        byte[] KeyOut;
        byte[] KeyIn;


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
        /// Serialize an initial request packet for this connection. Note that the initial 
        /// packet contains no information that is private to the client. Only an ephemeral
        /// key is generated and presented.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeInitial(byte[] payload) {
            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) 
                        as KeyPairAdvanced;

            var plaintextWriter = new PacketWriter();
            plaintextWriter.Write(PlaintextPacketType.Initial);

            // Write out the extensions. In this case we only have one client ephemeral being offered:
            plaintextWriter.WriteExtensions(1);
            var algorithm = ClientEphemeral.CryptoAlgorithmId.ToJoseID();
            plaintextWriter.Write(algorithm);
            plaintextWriter.Write(ClientEphemeral.IKeyAdvancedPublic.Encoding);

            ///<summary>Write out the payload.</summary> 
            plaintextWriter.Write(payload);

            return plaintextWriter.Packet;
            }


        /// <summary>
        ///  Serialize a client key exchange request made by a client that knows the host credential
        ///  and has received a recent host ephemeral to challenge its own private key. The payload
        ///  <paramref name="payload"/> if specified is encrypted to both the client and host credentials.
        ///  The client credentials are encrypted to the host credentials but not authenticated to the
        ///  client making the request.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensions">Plaintext extensions, including answer data responding to a 
        /// challenge puzzle presented by the host or another party.</param>
        /// <param name="ciphertextExtensions">Ciphertext extensions, including channel configuration.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientComplete(byte[] payload, 
                    List<PacketExtension> plaintextExtensions = null,
                    List<PacketExtension> ciphertextExtensions = null) {
            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            // Add the client credentials into the Mezanine. 
            var mezanineWriter = new PacketWriterAesGcm();
            mezanineWriter.Write(EncryptedPacketIdentifier.Mezzanine);
            mezanineWriter.WriteExtensions(ClientCredential.GetCredentials);
            mezanineWriter.Encrypt(null, innerWriter, false);

            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.ClientComplete);

            ClientKeyExchange(ClientEphemeral, HostCredential.KeyExchangePublic,
                    out KeyOut, out KeyIn);

            // Write out the host key we are talking to (nb does not disclose the service)
            outerWriter.Write(HostCredential.KeyExchangePublic.KeyIdentifier);

            // No need to write out the ephemeral key algorithm, it is implicit in the key identifier

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            outerWriter.Write(ClientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the set of extensions associated with the packet.
            outerWriter.WriteExtensions(plaintextExtensions);

            // Encrypt the inner packet and write to the outer.
            outerWriter.Encrypt(KeyOut, mezanineWriter);

            return outerWriter.Packet;
            }


        /// <summary>
        ///  Serialize a client key exchange request made by a client that knows the host credential
        ///  but does not have a host ephemeral to challenge its own private key. The payload
        ///  <paramref name="payload"/> if specified is encrypted to the host credential only.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensions">Plaintext extensions, including answer data responding to a 
        /// challenge puzzle presented by the host or another party.</param>
        /// <param name="ciphertextExtensions">Ciphertext extensions, including channel configuration.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientExchange(byte[] payload, 
                    List<PacketExtension> plaintextExtensions=null,
                    List<PacketExtension> ciphertextExtensions = null) {
            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.ClientExchange);

            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            ClientKeyExchange(ClientEphemeral, HostCredential.KeyExchangePublic,
                    out KeyOut, out KeyIn);

            // Write out the host key we are talking to (nb does not disclose the service)
            outerWriter.Write(HostCredential.KeyExchangePublic.KeyIdentifier);

            // No need to write out the ephemeral key algorithm, it is implicit in the key identifier

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            outerWriter.Write(ClientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the set of extensions associated with the packet.
            outerWriter.WriteExtensions(plaintextExtensions);

            // Encrypt the inner packet and write to the outer.
            outerWriter.Encrypt(KeyOut, innerWriter);

            return outerWriter.Packet;
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
