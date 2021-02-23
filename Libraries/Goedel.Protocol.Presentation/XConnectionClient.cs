using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;

using Goedel.Utilities;

namespace Goedel.Protocol.Presentation {



    /// <summary>
    /// Client connection class.
    /// </summary>
    public abstract class XConnectionClient : XConnection {

        /// <summary>The credential to be presented by the client.</summary>
        XPresentationCredential ClientCredential { get; }

        /// <summary>The credential to be presented by the host.</summary>
        XPresentationCredential HostCredential { get; set; }

        ///<summary>The client state.</summary> 
        public ClientState ClientState { get; private set; }


        string Protocol { get; }
        string Endpoint { get; }


        KeyPairAdvanced ClientEphemeral { get; set; }

        byte[] HostEphemeral { get; set; }
        KeyPairAdvanced ClientKey { get; set; }

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
        public XConnectionClient(
                    XListener listener,
                    string protocol,
                    string endpoint,
                    PortId portID,
                    XPresentationCredential clientCredential,
                    XPresentationCredential hostCredential=null) : base(listener){
            Listener = listener;
            ClientState = ClientState.Initial;
            ClientCredential = clientCredential;
            HostCredential = hostCredential;
            Protocol = protocol;
            Endpoint = endpoint;
            PortID = portID;
            }

        ///// <summary>
        ///// Establish a connection to the identified host. 
        ///// </summary>
        ///// <param name="jsonObject">The record to be sent.</param>
        ///// <returns>The record returned.</returns>
        //public virtual async Task<JsonObject> Open(JsonObject jsonObject=null) {

        //    var data = jsonObject.GetJsonB(true);
        //    var response = Write(data);
        //    await response;

        //    var reader = new JsonBcdReader(response.Result.Data);
        //    return JsonObject.FromJson(reader, true);
        //    }

        ///// <summary>
        ///// Write the record <paramref name="jsonObject"/> to the connection. 
        ///// </summary>
        ///// <param name="jsonObject">The record to be sent.</param>
        ///// <returns>The record returned.</returns>

        //public virtual async Task<JsonObject> Write(JsonObject jsonObject) {

        //    var data = jsonObject.GetJsonB(true);
        //    var response = Write(data);
        //    await response;

        //    var reader = new JsonBcdReader(response.Result.Data);
        //    return JsonObject.FromJson(reader, true);
        //    }

        ///// <summary>
        ///// Write the payload data <paramref name="data"/> to the connection.
        ///// </summary>
        ///// <param name="data">The data to write.</param>
        ///// <param name="plaintext"></param>
        ///// <returns></returns>
        //public virtual async Task<Packet> Write(byte[] data, bool plaintext = false) {
        //    byte[] requestPacket = ClientState switch {
        //        ClientState.Initial => HostCredential == null ?
        //            SerializeInitial(data) : SerializeClientExchange(data),
        //        ClientState.Challenge => SerializeClientExchange(data),
        //        ClientState.Write => SerializePacketData(data),
        //        _ => throw new InvalidClientState()
        //        };

        //    var response = PostPacket(requestPacket);
        //    await response;
        //    return response.Result;
        //    }


        ///// <summary>
        ///// Post a packet to the interface.
        ///// </summary>
        ///// <param name="data">The packet to post.</param>
        ///// <returns>Response packet.</returns>
        //public abstract Task<Packet> PostPacket(byte[] data) ;


        /// <summary>
        /// Serialize an initial request packet for this connection. Note that the initial 
        /// packet contains no information that is private to the client. Only an ephemeral
        /// key is generated and presented.
        /// </summary>
        /// <param name="payload">The payload data.</param>
        /// <param name="plaintextExtensions">Extensions to be presented in the plaintext segment.</param>
        /// <returns>The serialized data.</returns>
        public byte[] SerializeClientInitial(byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null) {
            ClientEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) 
                        as KeyPairAdvanced;

            // Compile the extensions. In this case we only have one client ephemeral being offered:
            plaintextExtensions ??= new();

            var ephemeral = new PacketExtension() {
                Tag = ClientEphemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ClientEphemeral.IKeyAdvancedPublic.Encoding
                };
            plaintextExtensions.Add(ephemeral);

            var plaintextWriter = new PacketWriter();
            plaintextWriter.Write(PlaintextPacketType.ClientInitial);
            plaintextWriter.WriteExtensions(plaintextExtensions);

            ///<summary>Write out the payload.</summary> 
            plaintextWriter.Write(payload);

            return plaintextWriter.Packet;
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
        public byte[] SerializeClientExchange(byte[] payload = null, 
                    List<PacketExtension> plaintextExtensions=null,
                    List<PacketExtension> ciphertextExtensions = null) {

            HostCredential.AssertNotNull(NYI.Throw); // we must know the host credential

            // select a host key and create a compatible ephemeral.
            var (clientEphemeral, hostPublic) = HostCredential.GetEphemeral();
            ClientKeyExchange(clientEphemeral, hostPublic, out ClientKeyOut, out ClientKeyIn);

            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.ClientExchange);

            // Write out the host key we are talking to (nb does not disclose the service)
            outerWriter.Write(HostCredential.KeyExchangePublic.KeyIdentifier);

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            outerWriter.Write(clientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the set of extensions associated with the packet.
            outerWriter.WriteExtensions(plaintextExtensions);

            // Encrypt the inner packet and write to the outer.
            outerWriter.Encrypt(ClientKeyOut, innerWriter);

            return outerWriter.Packet;
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
        public byte[] SerializeClientComplete(
                    byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null,
                    List<PacketExtension> ciphertextExtensions = null) {

            HostCredential.AssertNotNull(NYI.Throw); // we must know the host credential

            // select a host key and create a compatible ephemeral.
            var (hostEphemeral, hostPublic) = HostCredential.GetEphemeral();


            // the client exchange has already been performed, complete the 
            //MutualKeyExchange (clientEphemeral, hostPublic,  out MutualKeyOut, out MutualKeyIn);

            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            // Add the client credentials into the Mezanine. 
            var mezanineWriter = new PacketWriterAesGcm();
            mezanineWriter.Write(EncryptedPacketIdentifier.Mezzanine);
            mezanineWriter.Write(ClientCredential.KeyExchangePrivate.KeyIdentifier);
            //mezanineWriter.Write();


            mezanineWriter.WriteExtensions(ClientCredential.GetCredentials);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter, false);

            // Create the outer wrapper.
            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.ClientComplete);


            // Write out the host key we are talking to (nb does not disclose the service)
            outerWriter.Write(hostPublic.KeyIdentifier);

            //// Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            //outerWriter.Write(clientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the set of extensions associated with the packet.
            outerWriter.WriteExtensions(plaintextExtensions);

            // Encrypt the inner packet and write to the outer.
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            return outerWriter.Packet;
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
        public byte[] SerializeClientCompleteDeferred(
                    byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null,
                    List<PacketExtension> ciphertextExtensions = null) {

            HostCredential.AssertNotNull(NYI.Throw); // we must know the host credential

            // select a host key and create a compatible ephemeral.
            var (hostEphemeral, hostPublic) = HostCredential.GetEphemeral();


            // the client exchange has already been performed, complete the 
            //MutualKeyExchange(clientEphemeral, hostPublic, out MutualKeyOut, out MutualKeyIn);

            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            // Add the client credentials into the Mezanine. 
            var mezanineWriter = new PacketWriterAesGcm();
            mezanineWriter.Write(EncryptedPacketIdentifier.Mezzanine);
            mezanineWriter.Write(ClientCredential.KeyExchangePrivate.KeyIdentifier);
            //mezanineWriter.Write();


            mezanineWriter.WriteExtensions(ClientCredential.GetCredentials);
            mezanineWriter.Encrypt(MutualKeyOut, innerWriter, false);

            // Create the outer wrapper.
            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.ClientComplete);


            // Write out the host key we are talking to (nb does not disclose the service)
            outerWriter.Write(hostPublic.KeyIdentifier);

            // Write out the ephemeral public key encoding, the key algorithm is implicit in the key id
            //outerWriter.Write(clientEphemeral.IKeyAdvancedPublic.Encoding);

            // Write out the set of extensions associated with the packet.
            outerWriter.WriteExtensions(plaintextExtensions);

            // Encrypt the inner packet and write to the outer.
            outerWriter.Encrypt(ClientKeyOut, mezanineWriter);

            return outerWriter.Packet;
            }


        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from the source <paramref name="sourceId"/>
        /// and return the parsed packet data.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data.</param>
        /// <returns>The parsed packet.</returns>
        public override XPacket Parse(PortId sourceId, byte[] packet) {
            return packet[0] switch {
                byte b when ((b & 0b1000_0000) == 0) => ParsePacketData(sourceId, packet),
                (byte)PlaintextPacketType.HostExchange => ParsePacketHostExchange(sourceId, packet),
                (byte)PlaintextPacketType.HostComplete => ParsePacketHostComplete(sourceId, packet),

                _ => new PacketUnknown(sourceId, packet)
                };

            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from the source <paramref name="sourceId"/>
        /// as a packet of type <see cref="PacketHostExchange"/>and return the parsed packet data.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data.</param>
        /// <returns>The parsed packet.</returns>
        public PacketHostExchange ParsePacketHostExchange(PortId sourceId, byte[] packet) {

            var outerReader = new PacketReaderAesGcm(packet) { Position = 1 };

            var keyIdentifier = outerReader.ReadString();
            var extensions = outerReader.ReadExtensions();

            (HostEphemeral, ClientKey) = ClientCredential.MatchEphemeral(extensions);

            HostCredential = Listener.GetPresentationCredential(extensions);
            var hostPublic = HostCredential.MatchPublic(keyIdentifier);

            ClientKeyExchange(ClientEphemeral, hostPublic, out ClientKeyOut, out ClientKeyIn);

            var innerReader = outerReader.Decrypt(ClientKeyIn);
            var result = new PacketHostExchange(sourceId) {
                ExtensionsPlaintext = extensions
                };
            result.ReadEncrypted(innerReader);



            return result;

            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from the source <paramref name="sourceId"/>
        /// as a packet of type <see cref="PacketHostComplete"/>and return the parsed packet data.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data.</param>
        /// <returns>The parsed packet.</returns>
        public PacketHostComplete ParsePacketHostComplete(PortId sourceId, byte[] packet) {
            var outerReader = new PacketReaderAesGcm(packet) { Position = 1 };
            var keyIdentifier = outerReader.ReadString();
            var ephemeral = outerReader.ReadBinary();
            var extensions = outerReader.ReadExtensions();

            " set up MutualKeyIn, MutualKeyOut".TaskFunctionality(true);

            var innerReader = outerReader.Decrypt(MutualKeyIn);

            // Read the inner encrypted packet.
            var result = new PacketHostComplete(sourceId) {
                ExtensionsPlaintext = extensions
                };
            result.ReadEncrypted(innerReader);

            return result;
            }


        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from the source <paramref name="sourceId"/>
        /// as a packet of type <see cref="PacketHostExchange"/>and return the parsed packet data.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data.</param>
        /// <returns>The parsed packet.</returns>
        public PacketHostChallenge ParsePacketHostChallenge(PortId sourceId, byte[] packet) {

            var result = new PacketHostChallenge(sourceId) {
                //ExtensionsPlaintext = extensions
                };
            //result.ReadEncrypted(innerReader);

            return result;


            }


        }


    }
