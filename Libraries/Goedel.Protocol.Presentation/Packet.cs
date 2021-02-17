using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
using System.Threading.Tasks;


namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// A Parsed Packet.
    /// </summary>
    public class Packet {
        ///<summary>The packet payload.</summary> 
        public byte[] Payload { get; set; }

        ///<summary>The source address and port.</summary> 
        public PortId SourcePortId;

        ///<summary>Options specified in the packet plaintext.</summary> 
        public List<PacketExtension> ExtensionsPlaintext { get; set; }

        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> ExtensionsCiphertext { get; set; }

        ///<summary>The inner data packet type.</summary> 
        public EncryptedPacketIdentifier EncryptedPacketIdentifier { get; set; }



        /// <summary>
        /// Constructor, return packet bound to port <paramref name="portId"/>.
        /// </summary>
        /// <param name="portId">The source address and port.</param>
        public Packet(PortId portId) {
            SourcePortId = portId;
            }




        /// <summary>
        /// Read an inner encrypted data packet from <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">Reader bound to the packet being read</param>
        public void ReadEncrypted(
               PacketReader reader) {

            EncryptedPacketIdentifier = (EncryptedPacketIdentifier)reader.ReadByte();

            switch (EncryptedPacketIdentifier) {
                case EncryptedPacketIdentifier.Atomic: {
                    ExtensionsCiphertext = reader.ReadExtensions();
                    Payload = reader.ReadBinary();
                    return;
                    }
                }

            throw new NYI();
            }


        /// <summary>
        /// Return the extension from the list <paramref name="extensions"/> with the 
        /// tag <paramref name="tag"/> if found, otherwise null.
        /// </summary>
        /// <param name="extensions">List of extensions to search.</param>
        /// <param name="tag">The tag to be matched.</param>
        /// <returns>The value portion of the matching tag.</returns>
        public static byte[] GetExtension(List<PacketExtension> extensions, string tag) {
            if (extensions == null) {
                return null;
                }
            
            foreach (var extension in extensions ) {
                if (extension.Tag == tag) {
                    return extension.Value;
                    }
                }

            return null;
            }


        }

    /// <summary>
    /// Packet options (to be specified).
    /// </summary>
    public record PacketExtension {
        ///<summary>Registered extension tag</summary> 
        public string Tag;
        ///<summary>Extension value</summary> 
        public byte[] Value;
        }


    /// <summary>
    /// Unknown packet type.
    /// </summary>
    public class PacketUnknown : Packet {

        /// <summary>
        /// Constructor, return packet bound to port <paramref name="portId"/> containing data
        /// <paramref name="data"/>.
        /// </summary>
        /// <param name="portId">The source address and port.</param>
        /// <param name="data">The packet data.</param>
        public PacketUnknown(PortId portId, byte[] data) : base(portId)
                => Payload = data;

        }

    /// <summary>
    /// Encrypted and authenticated data packet.
    /// </summary>
    public class PacketData : Packet {



        /// <summary>
        /// Constructor, parse a decrypted data packet received from <paramref name="portId"/>
        /// bound to the reader <paramref name="reader"/>.
        /// </summary>
        /// <param name="portId">The packet source identifier.</param>
        /// <param name="reader">Reader for decrypted packet data.</param>
        public PacketData(PortId portId, PacketReader reader) : base(portId) {
            ReadEncrypted(reader);
            }


        }

    /// <summary>
    /// Error packet, MAY be returned in response to an unexpected request.
    /// </summary>
    public class PacketError : Packet {
        ///<summary>The returned error code.</summary> 
        public ErrorCode ErrorCode { get; }

        ///<summary>The address to which the packet was sent, i.e. the external
        ///port address of the recipient.</summary> 
        public byte[] DestinationAddress { get; }

        /// <summary>
        /// Constructor, parse a plaintext data packet <paramref name="data"/> 
        /// received from <paramref name="portId"/>.
        /// </summary>
        /// <param name="portId">The packet source identifier.</param>
        /// <param name="data">The packet data.</param>
        public PacketError(PortId portId, byte[] data) : base(portId) {

            var reader = new PacketReader(data);
            reader.Position++; // skip the packet identifier byte (already read)

            // Read the error code.
            ErrorCode = (ErrorCode)reader.ReadInteger();

            // Read the destination address. 
            DestinationAddress = reader.ReadBinary();

            // Read any options
            ExtensionsPlaintext = reader.ReadExtensions();

            // Read the payload (if any) 
            Payload = reader.ReadBinary();
            }

        }

    /// <summary>
    /// Initial packet, sent to obtain host information to begin connection establishment
    /// when the host credentials are not known.
    /// </summary>
    public class PacketInitial : Packet {

        /// <summary>
        /// Constructor, parse a plaintext data packet <paramref name="data"/> 
        /// received from <paramref name="portId"/>.
        /// </summary>
        /// <param name="portId">The packet source identifier.</param>
        /// <param name="data">The packet data.</param>
        public PacketInitial(PortId portId, byte[] data) : base(portId) {

            var reader = new PacketReader(data) {
                Position = 1 // skip the packet identifier byte (already read)
                };

            // Read the extensions. These will usually include ephemeral keys for one or more 
            // key exchange algorithmssupported by the client.
            ExtensionsPlaintext = reader.ReadExtensions();

            // Read the payload (if any)
            Payload = reader.ReadBinary();
            }

        }




    /// <summary>
    /// Client exchange packet, establishes a channel encrypted to the host credential alone.
    /// It is not possible to authenticate to the client credential at this point as we do
    /// not have a host challenge.
    /// </summary>
    public class PacketClientExchange : Packet {

        ///<summary>Host key identifier given by the client. Used to allow use of multiple
        ///host keys with different algorithms, etc. etc.</summary> 
        public string HostKeyIdentifier { get; }

        ///<summary>Client ephemeral key in binary form. MUST be compatible with the host 
        ///key algorithm.</summary> 
        public byte[] ClientEphemeral { get; }

        ///<summary>Result of the client side key agreement.</summary> 
        public KeyAgreementResult KeyAgreementResult;

        PacketReader outerReader;

        /// <summary>
        /// Constructor, parse plaintext parts of data packet <paramref name="packet"/> 
        /// received from <paramref name="portId"/>.
        /// </summary>
        /// <param name="portId">The packet source identifier.</param>
        /// <param name="packet">The packet data.</param>
        public PacketClientExchange(PortId portId, byte[] packet) : base(portId) {

            outerReader = new PacketReaderAesGcm(packet) {
                Position = 1 // skip first byte.
                };

            HostKeyIdentifier = outerReader.ReadString();
            ClientEphemeral = outerReader.ReadBinary();

            // Read the extensions. This MAY include a proof of work challenge.
            ExtensionsPlaintext = outerReader.ReadExtensions();
            }

        /// <summary>
        /// Decrypt the inner packet data using the private key <paramref name="privateKeyAgreement"/>
        /// </summary>
        /// <param name="privateKeyAgreement">The decryption key to be used to obtain information
        /// from the encrypted payload.</param>
        public void Decrypt(KeyPairAdvanced privateKeyAgreement) {
            if (KeyAgreementResult != null) {
                return; // payload already decrypted.
                }

            KeyAgreementResult = privateKeyAgreement.Agreement(null);
            var keyDerive = KeyAgreementResult.KeyDerive;
            var key = keyDerive.Derive(Constants.TagKey, Constants.SizeKeyAesGcm);

            var innerReader = outerReader.Decrypt(key);

            ReadEncrypted(innerReader);
            }
        }

    public class PacketClientComplete : Packet {

        public PacketClientComplete(PortId portId) : base(portId) {
            }

        }


    public class PacketHostChallenge : Packet {

        public PacketHostChallenge(PortId portId, byte[] data) : base(portId) {
            }

        }

    public class PacketHostExchange : Packet {

        public PacketHostExchange(PortId portId) : base(portId) {
            }

        }


    public class PacketHostComplete : Packet {

        public PacketHostComplete(PortId portId) : base(portId) {
            }

        }

    public class PacketRebind : Packet {

        public PacketRebind(PortId portId, byte[] data) : base(portId) {
            }

        }



    }
