using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Base class for connections
    /// </summary>
    public abstract class Connection : Disposable {

        ///<summary>Key for encrypting outgoing packets under the key established 
        ///to the host credential alone</summary> 
        protected byte[] ClientKeyOut;

        ///<summary>Key for decrypting incomming packets under the key established 
        ///to the host credential alone</summary> 
        protected byte[] ClientKeyIn;

        ///<summary>Key for encrypting outgoing packets under the key established 
        ///to the host and client credentials,</summary> 
        protected byte[] MutualKeyOut;

        ///<summary>Key for decrypting incomming packets under the key established 
        ///to the host and client credentials,</summary> 
        protected byte[] MutualKeyIn;


        ///<summary>The host credentials. There is exactly one set of host 
        ///credentials for a given PortId at a given time. This MAY however
        ///contain multiple keys (e.g. for different algorithms.</summary> 
        public PresentationCredential ListenerCredential => Listener.HostCredential;

        ///<summary>The listener to which this connection is bound.</summary> 
        protected Listener Listener { get;  init; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="listener">Listgener to which this connection is bound.</param>
        public Connection(Listener listener) => Listener = listener;


        /// <summary>
        /// Serialize ane mutually encrypt a data packet.
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        public byte[] SerializePacketData(byte[] payload, List<PacketExtension> extensions=null) {

            using var writer = new PacketWriterAesGcm();
            Write(writer, payload, extensions);

            // encrypt the result and return.
            return writer.Wrap(MutualKeyOut);
            }


        /// <summary>
        /// Deserialize a mutually encrypted data packet.
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="packet"></param>
        /// <returns></returns>
        public PacketData ParsePacketData(PortId sourceId, byte[] packet) {
            var reader = PacketReaderAesGcm.Unwrap(MutualKeyIn, packet);
            return new PacketData(sourceId, reader);

            }



        /// <summary>
        /// Write the payload <paramref name="payload"/> with extensions <paramref name="extensions"/>
        /// to the writer <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">Packet writer to which the data is to be written.</param>
        /// <param name="payload">The payload data.</param>
        /// <param name="extensions">Extensions (if used).</param>
        public static void Write(PacketWriter writer, byte[] payload,
                List<PacketExtension> extensions = null) {
            // write the control packet type
            writer.Write(EncryptedPacketIdentifier.Atomic);

            // write any packet options.
            writer.WriteExtensions(extensions);

            // write the payload
            writer.Write(payload);
            }





        KeyAgreementResult clientKeyAgreementResult;

        /// <summary>
        /// Perform a key exchange to the host credential only. This is performed by the client during
        /// connection establishment.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="publicKeyData">The public key in wire format.</param>
        /// <param name="keyClientHost">Session key used to encrypt/authenticate messages from the client
        /// to the host.</param>
        /// <param name="keyHostClient">Session key used to encrypt/authenticate messages from the host
        /// to the client.</param>
        public void ClientKeyExchange(
                        KeyPairAdvanced privateKey, 
                        byte[] publicKeyData,
                        out byte[] keyClientHost,
                        out byte[] keyHostClient) => ClientKeyExchange (
                            privateKey, new KeyPairX448(publicKeyData, KeySecurity.Public),
                            out keyClientHost, out keyHostClient);

        /// <summary>
        /// Perform a key exchange to the host credential only. This is performed by the client during
        /// connection establishment.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="keyPublic">The public key.</param>
        /// <param name="keyClientHost">Session key used to encrypt/authenticate messages from the client
        /// to the host.</param>
        /// <param name="keyHostClient">Session key used to encrypt/authenticate messages from the host
        /// to the client.</param>
        public void ClientKeyExchange(
                        KeyPairAdvanced privateKey,
                        KeyPairAdvanced keyPublic,
                        out byte[] keyClientHost,
                        out byte[] keyHostClient) {
            clientKeyAgreementResult = privateKey.Agreement(keyPublic);

            var keyDerive = clientKeyAgreementResult.KeyDerive;

            keyClientHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm*8);
            keyHostClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm*8);
            }


        /// <summary>
        /// Perform a key exchange to the host and client credentials. This is performed during
        /// connection establishment after both sides have obtained an ephemeral to validate their
        /// keys against.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="publicKeyData">The public key in wire format.</param>
        /// <param name="keyClientHost">Session key used to encrypt/authenticate messages from the client
        /// to the host.</param>
        /// <param name="keyHostClient">Session key used to encrypt/authenticate messages from the host
        /// to the client.</param>
        public void MutualKeyExchange(
                KeyPairAdvanced privateKey,
                byte[] publicKeyData,
                out byte[] keyClientHost,
                out byte[] keyHostClient) => MutualKeyExchange(
                            privateKey, new KeyPairX448(publicKeyData, KeySecurity.Public),
                            out keyClientHost, out keyHostClient);

        /// <summary>
        /// Perform a key exchange to the host and client credentials. This is performed during
        /// connection establishment after both sides have obtained an ephemeral to validate their
        /// keys against.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="publicKey">The public key in wire format.</param>
        /// <param name="keyClientHost">Session key used to encrypt/authenticate messages from the client
        /// to the host.</param>
        /// <param name="keyHostClient">Session key used to encrypt/authenticate messages from the host
        /// to the client.</param>
        public void MutualKeyExchange(
                KeyPairAdvanced privateKey,
                KeyPairAdvanced publicKey,
                out byte[] keyClientHost,
                out byte[] keyHostClient) {


            var hostKeyAgreementResult = privateKey.Agreement(publicKey);

            // Concatenate the IKMs from the two key agreements to create the key derrivation function
            var ikm = clientKeyAgreementResult.IKM.Concatenate(hostKeyAgreementResult.IKM);
            var keyDerive = new KeyDeriveHKDF(ikm);

            // Derrive the keys to be used to encrypt inbound and outbound data
            keyClientHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm * 8);
            keyHostClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm * 8);
            }

        /// <summary>
        /// Parse the packet <paramref name="packet"/> received from the source <paramref name="sourceId"/>
        /// and return the parsed packet data.
        /// </summary>
        /// <param name="sourceId">The packet source.</param>
        /// <param name="packet">The packet data.</param>
        /// <returns>The parsed packet.</returns>
        public abstract Packet Parse(PortId sourceId, byte[] packet);


        }


    }
