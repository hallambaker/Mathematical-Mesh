using Goedel.Utilities;
using Goedel.Cryptography;
using System.Collections.Generic;
using Goedel.Cryptography.Jose;

namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Host (i.e. responder) end of a listener connection.
    /// </summary>
    public class ConnectionHost : Connection {



        ///<summary>The client credential</summary> 
        public PresentationCredential ClientCredential { get; set; }


        KeyPairAdvanced HostEphemeral { get; set; }
        KeyAgreementResult HostKeyAgreementResult { get; set; }


        public Packet ClientPacket { get; init; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="listener">Listgener to which this connection is bound.</param>
        public ConnectionHost(Listener listener) : base(listener) { }



        /// <summary>
        /// Create a challenge and return it to the recipient together with the host credentials.
        /// The payload is always sent enclair. Thus this packet format MUST NOT be used for 
        /// messages other than regular client 
        /// </summary>
        /// <param name="payload">Packet payload (if used)</param>
        /// <param name="plaintextExtensions">Extensions to be presented in the plaintext segment.</param>
        /// <returns>The packet.</returns>
        public byte[] SerializeChallenge(byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null) {
            var plaintextWriter = new PacketWriter();

            // Write the packet tag
            plaintextWriter.Write(PlaintextPacketType.HostChallenge);

            HostEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;

            "Need to create at least one ephemeral/challenge here".TaskFunctionality(true);
            "Nonce should be a ticket for the ephemeral.".TaskFunctionality(true);

            // Construct extensions containing a nonce challenge and the host credentials
            var challenge = new PacketExtension() {
                Tag = Constants.ExtensionChallengeNonce,
                Value = Platform.GetRandomBytes(16)
                };
            var ephemeral = new PacketExtension() {
                Tag = HostEphemeral.CryptoAlgorithmId.ToJoseID(),
                Value = HostEphemeral.IKeyAdvancedPublic.Encoding
                };
            var extensions = new List<PacketExtension> { challenge, ephemeral };
            extensions.AddRange(HostCredential.GetCredentials);
            if (plaintextExtensions != null) {
                extensions.AddRange(plaintextExtensions);
                }
            plaintextWriter.WriteExtensions(extensions);

            // Write the payload (if specified)
            plaintextWriter.Write(payload);

            return plaintextWriter.Packet;
            }


        /// <summary>
        /// Create a packet to begin a mutually authenticated exchange.
        /// </summary>
        /// <param name="payload">Optional payload data to be mutually encrypted.</param>
        /// <param name="plaintextExtensions">Extensions to be presented in the plaintext segment.</param>
        /// <param name="ciphertextExtensions">Extensions to be presented in the ciphertext segment.</param>
        /// <returns></returns>
        public byte[] SerializeHostExchange(
                    byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null,
                    List<PacketExtension> ciphertextExtensions = null) {

            // Identify the keys and ephemerals to be used in the exchange
            var (clientEphemeral, hostPrivate) = HostCredential.MatchEphemeral(
                    ClientPacket.ExtensionsPlaintext);
            HostEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;

            // Compile the extensions.
            var ephemeral = new PacketExtension() {
                Tag = HostEphemeral.CryptoAlgorithmId.ToJoseID(),
                Value = HostEphemeral.IKeyAdvancedPublic.Encoding
                };
            var pExtensions = new List<PacketExtension> { ephemeral };
            pExtensions.AddRange(HostCredential.GetCredentials);

            if (plaintextExtensions != null) {
                pExtensions.AddRange(plaintextExtensions);
                }

            // Perform the key exchanges
            ClientKeyExchange(hostPrivate, clientEphemeral, out ClientKeyIn, out ClientKeyOut);

            // Create the inner packet
            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            // create the outer packet.
            var outerWriter = new PacketWriterAesGcm();

            outerWriter.Write(PlaintextPacketType.HostExchange);
            outerWriter.Write(hostPrivate.KeyIdentifier);
            outerWriter.WriteExtensions(pExtensions);

            outerWriter.Encrypt(ClientKeyOut, innerWriter);

            return outerWriter.Packet;
            }

        /// <summary>
        /// Create a packet to complete mutually authenticated exchange.
        /// </summary>
        /// <param name="clientEphemeral">The client ephemeral key (public)</param>
        /// <param name="payload">Optional payload data to be mutually encrypted.</param>
        /// <param name="plaintextExtensions">Extensions to be presented in the plaintext segment.</param>
        /// <param name="ciphertextExtensions">Extensions to be presented in the ciphertext segment.</param>
        /// <returns></returns>
        public byte[] SerializeHostComplete(
                    byte[] clientEphemeral,
                    byte[] payload = null,
                    List<PacketExtension> plaintextExtensions = null,
                    List<PacketExtension> ciphertextExtensions = null) {

            ClientKeyExchange(HostCredential.KeyExchangePrivate, clientEphemeral,
                    out ClientKeyIn, out ClientKeyOut);
            MutualKeyExchange(HostEphemeral, ClientCredential.KeyExchangePublic,
                out MutualKeyIn, out MutualKeyOut);

            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, ciphertextExtensions);

            var outerWriter = new PacketWriterAesGcm();
            HostEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;

            outerWriter.Write(PlaintextPacketType.HostComplete);

            outerWriter.Encrypt(MutualKeyOut, innerWriter);

            return outerWriter.Packet;
            }

        public override Packet Parse(PortId sourceId, byte[] packet) {
            return packet[0] switch {
                byte b when ((b & 0b1000_0000) == 0) => ParsePacketData(sourceId, packet),
                (byte)PlaintextPacketType.ClientExchange => ParsePacketClientExchange(sourceId, packet),
                (byte)PlaintextPacketType.ClientComplete => ParsePacketClientComplete(sourceId, packet),



                _ => new PacketUnknown(sourceId, packet)
                };

            }


        public PacketClientExchange ParsePacketClientExchange(PortId sourceId, byte[] packet) {
            throw new NYI();
            }


        public PacketClientComplete ParsePacketClientComplete(PortId sourceId, byte[] packet) {
            throw new NYI();
            }

        }

    }
