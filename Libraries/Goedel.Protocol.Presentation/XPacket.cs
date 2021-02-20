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
    public class XPacket {
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
        /// Constructor, return packet bound to port <paramref name="sourceId"/>.
        /// </summary>
        /// <param name="sourceId">The source address and port.</param>
        public XPacket(PortId sourceId) => SourcePortId = sourceId;




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
    public class PacketUnknown : XPacket {

        /// <summary>
        /// Constructor, return packet bound to port <paramref name="sourceId"/> containing data
        /// <paramref name="data"/>.
        /// </summary>
        /// <param name="sourceId">The source address and port.</param>
        /// <param name="data">The packet data.</param>
        public PacketUnknown(PortId sourceId, byte[] data) : base(sourceId)
                => Payload = data;

        }

    /// <summary>
    /// Encrypted and authenticated data packet.
    /// </summary>
    public class PacketData : XPacket {
        /// <summary>
        /// Constructor, parse a decrypted data packet received from <paramref name="sourceId"/>
        /// bound to the reader <paramref name="reader"/>.
        /// </summary>
        /// <param name="sourceId">The packet source identifier.</param>
        /// <param name="reader">Reader for decrypted packet data.</param>
        public PacketData(PortId sourceId, PacketReader reader) : base(sourceId) => ReadEncrypted(reader);


        }

    /// <summary>
    /// Error packet, MAY be returned in response to an unexpected request.
    /// </summary>
    public class PacketError : XPacket {
        ///<summary>The returned error code.</summary> 
        public ErrorCode ErrorCode { get; }

        ///<summary>The address to which the packet was sent, i.e. the external
        ///port address of the recipient.</summary> 
        public byte[] DestinationAddress { get; }

        /// <summary>
        /// Constructor, parse a plaintext data packet <paramref name="data"/> 
        /// received from <paramref name="sourceId"/>.
        /// </summary>
        /// <param name="sourceId">The packet source identifier.</param>
        /// <param name="data">The packet data.</param>
        public PacketError(PortId sourceId, byte[] data) : base(sourceId) {

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
    public class PacketInitial : XPacket {

        /// <summary>
        /// Constructor, parse a plaintext data packet <paramref name="data"/> 
        /// received from <paramref name="sourceId"/>.
        /// </summary>
        /// <param name="sourceId">The packet source identifier.</param>
        /// <param name="data">The packet data.</param>
        public PacketInitial(PortId sourceId, byte[] data) : base(sourceId) {

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
    public class PacketClientExchange : XPacket {

        byte[] ClientEphemeral { get; set; }

        KeyPairAdvanced HostKey { get; set; }

        public PacketReader OuterReader { get; init; }

        public XPresentationCredential HostCredential { get; set; }
        /// <summary>
        /// Constructor, for data packet
        /// received from <paramref name="sourceId"/>.
        /// </summary>
        /// <param name="sourceId">The packet source identifier.</param>
        public PacketClientExchange(PortId sourceId, byte[] packet) : base(sourceId) {


            OuterReader = new PacketReaderAesGcm(packet) { Position = 1 };
            var keyIdentifier = OuterReader.ReadString();
            var ephemeral = OuterReader.ReadBinary();
            var ExtensionsPlaintext = OuterReader.ReadExtensions();

            (ClientEphemeral, HostKey) = HostCredential.MatchEphemeral(ExtensionsPlaintext);

            }






        }

    public class PacketClientComplete : XPacket {

        public PacketClientComplete(PortId sourceId) : base(sourceId) {
            }

        }

    public class PacketClientCompleteDeferred : XPacket {

        public PacketClientCompleteDeferred(PortId sourceId) : base(sourceId) {
            }

        }
    public class PacketHostChallenge : XPacket {

        public PacketHostChallenge(PortId sourceId) : base(sourceId) {
            }

        }

    public class PacketHostExchange : XPacket {

        public PacketHostExchange(PortId sourceId) : base(sourceId) {
            }

        }


    public class PacketHostComplete : XPacket {

        public PacketHostComplete(PortId sourceId) : base(sourceId) {
            }

        }

    public class PacketRebind : XPacket {

        public PacketRebind(PortId portId) : base(portId) {
            }

        }



    }
