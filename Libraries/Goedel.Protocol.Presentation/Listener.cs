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

    public record PortId {

        public IPAddress SourceIPAddress;

        public int SourcePort;
        }

    public record PortHistory {
        public DateTime LastChallenge;
        public int Challenges;
        public int Refusals;

        public PortHistory() {
            LastChallenge = DateTime.Now;
            }
        }

    public delegate byte[] dispatchDelegate(byte[] request, JpcSession jpcSession);


    /*
     * TaskCompletionSource()
     * TaskCompletionSource()
     * TaskCompletionSource()
     * TaskCompletionSource()
     */


    public class Listener : Disposable {

        ///<summary>Dictionary tracking inbound abuse by IP address</summary> 
        public Dictionary<IPAddress, PortHistory> DictionaryIPAddressToHistory = new();

        ///<summary>Dictionary tracking inbound abuse by IP address and port</summary> 
        public Dictionary<PortId, PortHistory> DictionaryPortIdToHistory = new();

        ///<summary>Dictionary used for binding, maps connection Id to connection</summary> 
        public Dictionary<PortId, Connection> DictionaryPortIdToConnection = new();

        ///<summary>Dictionary used for rebinding, maps connection Id to connection</summary> 
        public Dictionary<byte[], Connection> DictionaryIdToConnection = new();

        ///<summary>The host credentials. There is exactly one set of host 
        ///credentials for a given PortId at a given time. This MAY however
        ///contain multiple keys (e.g. for different algorithms.</summary> 
        public PresentationCredential HostCredential { get; set; } 

        public Listener (PresentationCredential credential) {
            }


        public virtual ConnectionClient Open(string protocol, string address) {

            throw new NYI();
            }

        public virtual Task<ConnectionHost> Accept(string protocol, string address) {

            throw new NYI();
            }




        public virtual void Process(PortId portID, byte[] packet) {

            packet.AssertNotNull(NYI.Throw);
            (packet.Length > 0).AssertTrue(NYI.Throw);

            switch (packet[0])  {
                case byte b when ((b & 0b1000_0000) == 0): {
                    var parsed = ParsePacketData(portID, packet);
                    ProcessPacketData(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.Error: {
                    var parsed = ParsePacketError(portID, packet);
                    ProcessError(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.Initial: {
                    var parsed = ParsePacketInitial(portID, packet);
                    ProcessPacketInitial(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.ClientExchange: {
                    var parsed = ParsePacketClientExchange(portID, packet);
                    ProcessPacketClientExchange(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.ClientComplete: {
                    var parsed = ParsePacketClientComplete(portID, packet);
                    ProcessPacketClientComplete(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.HostChallenge: {
                    var parsed = ParsePacketHostChallenge(portID, packet);
                    ProcessPacketHostChallenge(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.HostExchange: {
                    var parsed = ParsePacketHostExchange(portID, packet);
                    ProcessPacketHostExchange(parsed);
                    break;
                    }
                case (byte)PlaintextPacketType.HostComplete: {
                    var parsed = ParsePacketHostComplete(portID, packet);
                    ProcessPacketHostComplete(parsed);
                    break;
                    }

                default: {
                    ProcessBad(portID, packet);
                    break;
                    }
                };

        }
        public virtual void ProcessBad(PortId portID, byte[] packet) {
            }

        public virtual void ProcessPacketData(Packet packet) {
            }


        public virtual void ProcessError(Packet packet) {
            }

        public virtual void ProcessPacketInitial(Packet packet) {
            if (packet is not PacketInitial packetInitial) {
                ProcessError(packet);
                }
            else 
                {
                
                }
            }

        public virtual void ProcessPacketClientExchange(Packet packet) {
            }

        public virtual void ProcessPacketClientComplete(Packet packet) {
            }
        public virtual void ProcessPacketHostChallenge(Packet packet) {
            }
        public virtual void ProcessPacketHostExchange(Packet packet) {
            }
        public virtual void ProcessPacketHostComplete(Packet packet) {
            }


        /// <summary>
        /// Parse a packet and retru
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>

        public virtual Packet Parse(PortId sourceId, byte[] packet) {


            packet.AssertNotNull(NYI.Throw);
            (packet.Length > 0).AssertTrue(NYI.Throw);

            return packet[0] switch {
                byte b when ((b & 0b1000_0000) == 0) => ParsePacketData(sourceId, packet),
                (byte)PlaintextPacketType.Initial => new PacketInitial(sourceId, packet),
                (byte)PlaintextPacketType.Error => new PacketError(sourceId, packet),
                (byte)PlaintextPacketType.ClientExchange => new PacketClientExchange(sourceId, packet),
                (byte)PlaintextPacketType.HostChallenge => new PacketHostChallenge(sourceId, packet),
                (byte)PlaintextPacketType.HostComplete => new PacketHostExchange(sourceId, packet),
                (byte)PlaintextPacketType.Rebind => new PacketRebind(sourceId, packet),

                _ => new PacketUnknown(sourceId, packet)
                };

            }

        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketData(PortId sourceId, byte[] packet) {

            if (DictionaryPortIdToConnection.TryGetValue(sourceId, out var connection)) {
                return connection.ParsePacketData(sourceId, packet);
                }
            else {
                return new PacketUnknown(sourceId, packet);
                }
            }

        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketError(PortId sourceId, byte[] packet) {
            throw new NYI();
            }

        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketInitial(PortId sourceId, byte[] packet) {
            throw new NYI();
            }

        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketClientExchange(PortId sourceId, byte[] packet) {
            throw new NYI();
            }
        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketClientComplete(PortId sourceId, byte[] packet) {
            throw new NYI();
            }

        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketHostChallenge(PortId sourceId, byte[] packet) {
            throw new NYI();
            }
        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketHostExchange(PortId sourceId, byte[] packet) {
            throw new NYI();
            }
        /// <summary>
        /// Parse a packet containing PacketData.
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>
        public virtual Packet ParsePacketHostComplete(PortId sourceId, byte[] packet) {
            throw new NYI();
            }


        }


    }
