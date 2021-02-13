using Goedel.Utilities;
using Goedel.Cryptography;
using System.Collections.Generic;

namespace Goedel.Protocol.Presentation {
    public class ConnectionHost : Connection {

        ///<summary>The host credentials. There is exactly one set of host 
        ///credentials for a given PortId at a given time. This MAY however
        ///contain multiple keys (e.g. for different algorithms.</summary> 
        public PresentationCredential HostCredential { get; init;  }

        KeyPairAdvanced HostEphemeral { get; set; }
        KeyAgreementResult HostKeyAgreementResult { get; set; }




        /// <summary>
        /// Create a challenge and return it to the recipient together with the host credentials.
        /// </summary>
        /// <param name="payload">Packet payload (if used)</param>
        /// <returns>The packet.</returns>
        public byte[] SerializeChallenge(byte[] payload=null) {
            var plaintextWriter = new PacketWriter();

            // Write the packet tag
            plaintextWriter.Write(PlaintextPacketType.HostChallenge);

            "Need to create at least one ephemeral/challenge here".TaskFunctionality(true);
            "Nonce should be a ticket for the ephemeral.".TaskFunctionality(true);

            // Construct extensions containing a nonce challenge and the host credentials
            var challenge = new PacketExtension() {
                Tag = Constants.ExtensionChallengeNonce,
                Value = Platform.GetRandomBytes(16)
                };
            var extensions = new List<PacketExtension> { challenge };
            extensions.AddRange(HostCredential.GetCredentials);
            plaintextWriter.WriteExtensions(extensions);

            // Write the payload (if specified)
            plaintextWriter.Write(payload);

            return plaintextWriter.Packet;
            }


        /// <summary>
        /// Create a packet to complete mutually authenticated exchange.
        /// </summary>
        /// <param name="payload">Optional payload data to be mutually encrypted.</param>
        /// <returns></returns>
        public byte[] SerializeHostExchange(byte[] payload=null) {
            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, null);


            HostEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            HostKeyAgreementResult = HostEphemeral.Agreement(HostCredential.KeyExchangePublic);
            var keyDerive = HostKeyAgreementResult.KeyDerive;
            Key = keyDerive.Derive(Constants.TagKey, Constants.SizeKeyAesGcm);


            var outerWriter = new PacketWriterAesGcm();
            outerWriter.Write(PlaintextPacketType.HostExchange);

            outerWriter.Write(HostEphemeral.IKeyAdvancedPublic.Encoding);
            outerWriter.WriteExtensions();

            outerWriter.Encrypt(Key, innerWriter);

            return outerWriter.Packet;
            }


        public byte[] SerializeHostComplete(byte[] payload = null) {
            var innerWriter = new PacketWriter();
            Write(innerWriter, payload, null);

            var outerWriter = new PacketWriterAesGcm();
            HostEphemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;



            outerWriter.Write(PlaintextPacketType.HostComplete);

            outerWriter.Encrypt(Key, innerWriter);

            return outerWriter.Packet;
            }

    }

    }
