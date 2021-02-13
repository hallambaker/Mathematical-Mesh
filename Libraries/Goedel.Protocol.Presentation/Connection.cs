using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {
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
            Write(writer, payload, extensions);

            // encrypt the result and return.
            return writer.Wrap(Key);
            }

        public static void Write(PacketWriter writer, byte[] payload,
                List<PacketExtension> extensions = null) {
            // write the control packet type
            writer.Write(EncryptedPacketIdentifier.Atomic);

            // write any packet options.
            writer.WriteExtensions(extensions);

            // write the payload
            writer.Write(payload);
            }

        KeyAgreementResult ClientKeyAgreementResult;
        KeyAgreementResult HostKeyAgreementResult;


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
            ClientKeyAgreementResult = privateKey.Agreement(keyPublic);

            var keyDerive = ClientKeyAgreementResult.KeyDerive;

            keyClientHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm);
            keyHostClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm);
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


            HostKeyAgreementResult = privateKey.Agreement(publicKey);

            // Concatenate the IKMs from the two key agreements to create the key derrivation function
            var ikm = ClientKeyAgreementResult.IKM.Concatenate(HostKeyAgreementResult.IKM);
            var keyDerive = new KeyDeriveHKDF(ikm);

            // Derrive the keys to be used to encrypt inbound and outbound data
            keyClientHost = keyDerive.Derive(Constants.TagKeyClientHost, Constants.SizeKeyAesGcm);
            keyHostClient = keyDerive.Derive(Constants.TagKeyHostClient, Constants.SizeKeyAesGcm);
            }



        }


    }
