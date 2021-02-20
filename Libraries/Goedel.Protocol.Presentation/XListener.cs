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
    /// Port identifier. Specifies an IP address and port number.
    /// </summary>
    public record PortId {
        ///<summary>The IP address.</summary> 
        public IPAddress IPAddress;

        ///<summary>The port number.</summary> 
        public int Port;
        }

    /// <summary>
    /// Port history. Used to track possible abuse.
    /// </summary>
    public record PortHistory {
        ///<summary>Time at which the last challenge was issued.</summary> 
        public DateTime LastChallenge;

        ///<summary>Number of challenges issued.</summary> 
        public int Challenges;

        ///<summary>Number of refusals made.</summary> 
        public int Refusals;

        /// <summary>
        /// Constructor, initialize the last challenge time to now.
        /// </summary>
        public PortHistory() {
            LastChallenge = DateTime.Now;
            }
        }

    //public delegate byte[] dispatchDelegate(byte[] request, JpcSession jpcSession);


    /*
     * TaskCompletionSource()
     * TaskCompletionSource()
     * TaskCompletionSource()
     * TaskCompletionSource()
     */

    /// <summary>
    /// Listener class, process incoming packets and deliver responses to waiting tasks.
    /// </summary>
    public abstract class XListener : Disposable {

        ///<summary>Dictionary tracking inbound abuse by IP address</summary> 
        public Dictionary<IPAddress, PortHistory> DictionaryIPAddressToHistory = new();

        ///<summary>Dictionary tracking inbound abuse by IP address and port</summary> 
        public Dictionary<PortId, PortHistory> DictionaryPortIdToHistory = new();

        ///<summary>Dictionary used for binding, maps connection Id to connection</summary> 
        public Dictionary<PortId, XConnection> DictionaryPortIdToConnection = new();

        ///<summary>Dictionary used for rebinding, maps connection Id to connection</summary> 
        public Dictionary<byte[], XConnection> DictionaryIdToConnection = new();

        ///<summary>The host credentials. There is exactly one set of host 
        ///credentials for a given PortId at a given time. This MAY however
        ///contain multiple keys (e.g. for different algorithms.</summary> 
        public XPresentationCredential HostCredential { get; set; }


        /// <summary>
        /// Constructor, create a new listener instance with the host credential 
        /// <paramref name="hostCredential"/>.
        /// </summary>
        /// <param name="hostCredential">The host credential.</param>
        public XListener(XPresentationCredential hostCredential) => HostCredential = hostCredential;


        /// <summary>
        /// Attempt to establish a client connection to the host <paramref name="address"/> using
        /// protocol <paramref name="protocol"/>.
        /// </summary>
        /// <param name="protocol">The protocol specifier.</param>
        /// <param name="address">The host address.</param>
        /// <returns>Task which completes when the connection is established.</returns>
        public virtual Task<XConnectionClient> Open(string protocol, string address) {

            throw new NYI();
            }

        /// <summary>
        /// Accept inbound client connection requests on the port directed to the address
        /// <paramref name="address"/> using the protocol <paramref name="protocol"/>/
        /// </summary>
        /// <param name="protocol">The protocol specifier.</param>
        /// <param name="address">The host address.</param>
        /// <returns>Task which completes when the connection request is received.</returns>
        public virtual Task<XConnectionHost> Accept(string protocol, string address) {

            throw new NYI();
            }

        public abstract XConnectionHost ConnectionHostFactory(XPacket packet);










        public virtual XConnectionHost MakeConnection(PortId sourceId, XPacket packet) {
            var connection = MakeConnection(packet);
            DictionaryPortIdToConnection.Add(sourceId, connection);
            return connection;

            }

        public abstract XPresentationCredential GetPresentationCredential(List<PacketExtension> extensions);


        public virtual XConnectionHost MakeConnection(XPacket packet) => ConnectionHostFactory(packet);


        #region // Process
        /// <summary>
        /// Process the data packet <paramref name="packet"/> received from the source
        /// <paramref name="sourceId"/>.
        /// </summary>
        /// <param name="sourceId">The packet source address.</param>
        /// <param name="packet">The packet data.</param>
        public virtual void Process(PortId sourceId, byte[] packet) {
            throw new NYI();
            //packet.AssertNotNull(NYI.Throw);
            //(packet.Length > 0).AssertTrue(NYI.Throw);

            //switch (packet[0]) {
            //    case byte b when ((b & 0b1000_0000) == 0): {
            //        var parsed = ParsePacketData(sourceId, packet);
            //        ProcessPacketData(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.Error: {
            //        var parsed = ParsePacketError(sourceId, packet);
            //        ProcessError(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.Initial: {
            //        var parsed = ParsePacketInitial(sourceId, packet);
            //        ProcessPacketInitial(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.ClientExchange: {
            //        var parsed = ParsePacketClientExchange(sourceId, packet);
            //        ProcessPacketClientExchange(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.ClientComplete: {
            //        var parsed = ParsePacketClientComplete(sourceId, packet);
            //        ProcessPacketClientComplete(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.HostChallenge: {
            //        var parsed = ParsePacketHostChallenge(sourceId, packet);
            //        ProcessPacketHostChallenge(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.HostExchange: {
            //        var parsed = ParsePacketHostExchange(sourceId, packet);
            //        ProcessPacketHostExchange(parsed);
            //        break;
            //        }
            //    case (byte)PlaintextPacketType.HostComplete: {
            //        var parsed = ParsePacketHostComplete(sourceId, packet);
            //        ProcessPacketHostComplete(parsed);
            //        break;
            //        }

            //    default: {
            //        ProcessBad(sourceId, packet);
            //        break;
            //        }
            //    };

            }
        public virtual void ProcessBad(PortId portID, byte[] packet) {
            }

        public virtual void ProcessPacketData(XPacket packet) {
            }


        public virtual void ProcessError(XPacket packet) {
            }

        public virtual void ProcessPacketInitial(XPacket packet) {
            if (packet is not PacketInitial packetInitial) {
                ProcessError(packet);
                }
            else {

                }
            }

        public virtual void ProcessPacketClientExchange(XPacket packet) {
            }

        public virtual void ProcessPacketClientComplete(XPacket packet) {
            }
        public virtual void ProcessPacketHostChallenge(XPacket packet) {
            }
        public virtual void ProcessPacketHostExchange(XPacket packet) {
            }
        public virtual void ProcessPacketHostComplete(XPacket packet) {
            }

        #endregion

        /// <summary>
        /// Parse a packet and retru
        /// </summary>
        /// <param name="sourceId">Identifier of the source from which the packet was received.</param>
        /// <param name="packet">The data packet.</param>
        /// <returns>The parsed packet.</returns>

        public virtual XPacket Parse(PortId sourceId, byte[] packet) {

            packet.AssertNotNull(NYI.Throw);
            (packet.Length > 0).AssertTrue(NYI.Throw);


            switch (packet[0]) {

                case (byte)PlaintextPacketType.ClientInitial: {
                    return new PacketInitial(sourceId, packet);
                    }
                case (byte)PlaintextPacketType.ClientExchange: {
                    return new PacketClientExchange(sourceId, packet);
                    }
                }

            if (DictionaryPortIdToConnection.TryGetValue(sourceId, out var connection)) {
                return connection.Parse(sourceId, packet);
                }
            return new PacketUnknown(sourceId, packet);

            }

 

        }


    }
