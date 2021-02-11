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



        public Listener (PresentationCredential credential) {
            }


        public virtual ConnectionClient Open(string protocol, string address) {

            throw new NYI();
            }

        public virtual Task<ConnectionHost> Accept(string protocol, string address) {

            throw new NYI();
            }


        public virtual void Process(PortId portId, byte[] packet) =>
            Process(Parse(portId, packet));



        public virtual void Process(Packet packet) {
            }





        public Packet Parse(PortId portID, byte[] packet) {


            packet.AssertNotNull(NYI.Throw);
            (packet.Length > 0).AssertTrue(NYI.Throw);

            return packet[0] switch {
                byte b when ((b & 0b1000_0000) != 0) => GetPacketData(portID, packet),
                (byte)PlaintextPacketType.Initial => new PacketInitial(portID, packet),
                (byte)PlaintextPacketType.ClientExchange => new PacketClientExchange(portID, packet),
                (byte)PlaintextPacketType.HostChallenge => new PacketHostChallenge(portID, packet),
                (byte)PlaintextPacketType.HostExchange => new PacketHostExchange(portID, packet),
                (byte)PlaintextPacketType.Rebind => new PacketRebind(portID, packet),
                (byte)PlaintextPacketType.Error => new PacketError(portID, packet),

                _ => new PacketUnknown(portID, packet)
                };

            }


        public Packet GetPacketData(PortId sourceId, byte[] packet) {

            if (DictionaryPortIdToConnection.TryGetValue(sourceId, out var connection)) {
                var reader = PacketReaderGCM.Unwrap(connection.Key, packet);
                return new PacketData(sourceId, reader);
                }
            else {
                return new PacketUnknown(sourceId, packet);

                }


            }



        }



    //public class ListenerHost : Disposable{

    //    public Dictionary<IPAddress, PortHistory> DictionaryIPAddressToPortHistory = new();
    //    public Dictionary<PortId, PortHistory> DictionaryPortIdToPortHistory = new ();


    //    public Dictionary<IPAddress, byte[]> DictionaryAddressToKey = new();
    //    public Dictionary<PortId, byte[]> DictionaryPortIdToKey = new();
    //    public Dictionary<byte[], ConnectionHost> DictionaryConnectionIdToKey = new();



    //    public Packet Parse(PortId portID, byte[] packet) {
    //        // check inputs
    //        packet.AssertNotNull(NYI.Throw);
    //        (packet.Length > 0).AssertTrue(NYI.Throw);

    //        return packet[0] switch {
    //            byte b when ((b & 0b1000_0000) != 0) =>
    //                    new PacketHostInitial(portID, packet),
    //            (byte)ClientPacketType.Initial =>
    //                    new PacketHostInitial(portID, packet),
    //            (byte)ClientPacketType.ClientExchange =>
    //                    new PacketHostInitial(portID, packet),
    //            //(byte)ClientPacketType.Answer =>
    //            //        new PacketHostInitial(portID, packet),
    //            _ => new PacketHostUnknown(portID, packet)
    //            };
    //        }


    //    static bool acceptToggle;
    //    protected virtual bool Accept(PortId portID) {
    //        portID.Future();

    //        acceptToggle = !acceptToggle;

    //        return acceptToggle;
    //        }


    //    protected virtual Packet ProcessInitial(PortId portID, byte[] data) {
    //        var packet = new PacketHostInitial(portID, data);

    //        if (Accept(portID)) {
    //            return new HostPacketChallenge(packet);
    //            }
    //        else {
    //            return new HostPacketComplete(packet);
    //            }
    //        }

    //    /// <summary>
    //    /// Process a cloaked request packet.
    //    /// </summary>
    //    /// <param name="portID"></param>
    //    /// <param name="data"></param>
    //    /// <returns></returns>
    //    protected virtual Packet ProcessCloaked(PortId portID, byte[] data) {
    //        var packet = new PacketHostCloaked(portID, data);

    //        if (Accept(portID)) {
    //            return new HostPacketChallenge(packet);
    //            }
    //        else {
    //            return new HostPacketComplete(packet);
    //            }
    //        }

    //    protected virtual Packet ProcessAnswer(PortId portID, byte[] data) {
    //        var packet = new PacketHostAnswer(portID, data);

    //        return new HostPacketComplete(packet);
    //        }

    //    protected virtual Packet ProcessPost(PortId portID, byte[] data) {
    //        var packet = new PacketHostPost(portID, data);

    //        return new PacketHostData(packet);
    //        }

    //    }
    //public class PacketHostIn : Packet {

    //    public byte[] Payload { get; set; }
    //    public PortId PortID;
    //    public PacketHostIn(PortId portID) {
    //        PortID = portID;


            
            
    //        }

    //    }


    //public class PacketHostOut: Packet {
    //    }







    //public class PacketHostCloaked : PacketHostIn {

    //    public PacketHostCloaked(PortId portID, byte[] data) : base(portID) {
    //        // parse data

    //        }

    //    }

    //public class PacketHostAnswer : PacketHostIn {

    //    public PacketHostAnswer(PortId portID, byte[] data) : base(portID) {
    //        // parse data

    //        // validate challenge


    //        }
    //    }

    //public class PacketHostPost : PacketHostIn {
        
    //    public PacketHostPost(PortId portID, byte[] data) : base(portID) {
    //        // parse data

    //        // associate to connection


    //        }

    //    }

    //public class PacketHostUnknown : PacketHostIn {

    //    public PacketHostUnknown(PortId portID, byte[] data) : base(portID) {
    //        // parse data

    //        }


    //    }


    //public class HostPacketChallenge : Packet {
    //    public HostPacketChallenge(PacketHostInitial packetHost) {
    //        }

    //    public HostPacketChallenge(PacketHostCloaked packetHost) {
    //        }


    //    }
    //public class HostPacketComplete : Packet {
    //    public HostPacketComplete(PacketHostInitial packetHost) {
    //        }
    //    public HostPacketComplete(PacketHostCloaked packetHost) {
    //        }
    //    public HostPacketComplete(PacketHostAnswer packetHost) {
    //        }
    //    }
    //public class PacketHostData : Packet {

    //    public PacketHostData(PacketHostPost packetHost) {
    //        }

    //    }
    //public class HostPacketAbort : Packet {

    //    }

    }
