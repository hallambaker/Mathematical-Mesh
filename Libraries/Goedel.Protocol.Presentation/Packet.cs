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
        public List<PacketExtension> OptionsPlaintext { get; set; }

        ///<summary>Options specified in the packet ciphertext.</summary> 
        public List<PacketExtension> OptionsCiphertext;


        /// <summary>
        /// Constructor, return packet bound to port <paramref name="portId"/>.
        /// </summary>
        /// <param name="portId">The source address and port.</param>
        public Packet(PortId portId) {
            SourcePortId = portId;
            }

        public void CiphertextExtensions(PacketReader reader) {
            var count = reader.ReadByte();
            if (count == 0) {
                return;
                }
            OptionsCiphertext ??= new List<PacketExtension>();
            for (var i = 0; i < count; i++) {
                var tag = reader.ReadString();
                var value = reader.ReadBinary();
                var extension = new PacketExtension() { Tag = tag, Value = value };
                OptionsCiphertext.Add(extension);
                }
            }


        }

    /// <summary>
    /// Packet options (to be specified).
    /// </summary>
    public record PacketExtension {
        public string Tag;
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
        public PacketUnknown(PortId portId, byte[] data) : base(portId)
                => Payload = data;

        }

    /// <summary>
    /// Encrypted and authenticated data packet.
    /// </summary>
    public class PacketData : Packet {

        ///<summary>The inner data packet type.</summary> 
        public EncryptedPacketIdentifier EncryptedPacketIdentifier { get; set; }

        /// <summary>
        /// Constructor, parse a decryupted data packet received from <paramref name="portId"/>
        /// bound to the reader <paramref name="reader"/>.
        /// </summary>
        /// <param name="portId">The packet source identifier.</param>
        /// <param name="reader">Reader for decrypted packet data.</param>
        public PacketData(PortId portId, PacketReader reader) : base(portId) {

            EncryptedPacketIdentifier = (EncryptedPacketIdentifier) reader.ReadByte();

            switch (EncryptedPacketIdentifier) {
                case EncryptedPacketIdentifier.Atomic: {
                    CiphertextExtensions(reader);
                    Payload = reader.ReadBinary();
                    break;
                    }
                }
            }


        }

    /// <summary>
    /// Error packet, MAY be returned in response to an unexpected request.
    /// </summary>
    public class PacketError : Packet {

        public ErrorCode ErrorCode;
        ///<summary>The address to which the packet was sent, i.e. the external
        ///port address of the recipient.</summary> 
        public byte[] DestinationAddress;

        public PacketError(PortId portId, PacketReader reader) : base(portId) {
            // Read the error code.
            ErrorCode = (ErrorCode)reader.ReadByte();

            // Read the destination address. 
            DestinationAddress = reader.ReadBinary();

            }

        }

    public class PacketInitial : Packet {

        public PacketInitial(PortId portId, byte[] data) : base(portId) {
            }

        }

    public class PacketClientExchange : Packet {

        public PacketClientExchange(PortId portId, byte[] data) : base(portId) {
            }

        }

    public class PacketHostChallenge : Packet {

        public PacketHostChallenge(PortId portId, byte[] data) : base(portId) {
            }

        }

    public class PacketHostExchange : Packet {

        public PacketHostExchange(PortId portId, byte[] data) : base(portId) {
            }

        }

    public class PacketRebind : Packet {

        public PacketRebind(PortId portId, byte[] data) : base(portId) {
            }

        }



    }
