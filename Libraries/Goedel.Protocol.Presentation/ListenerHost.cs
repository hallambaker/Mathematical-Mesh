using System;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Protocol.Presentation {

    public record PortID {

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


    public class ConnectionHost : Connection {


        public ListenerHost ListenerHost;

        public byte[] ConnectionId;

        public PacketClient Process(byte[] data) {

            throw new NYI();
            }

        }



    public class ListenerHost : Disposable{

        public Dictionary<IPAddress, PortHistory> DictionaryIPAddressToPortHistory = new();
        public Dictionary<PortID, PortHistory> DictionaryPortIdToPortHistory = new ();


        public Dictionary<IPAddress, byte[]> DictionaryAddressToKey = new();
        public Dictionary<PortID, byte[]> DictionaryPortIdToKey = new();
        public Dictionary<byte[], ConnectionHost> DictionaryConnectionIdToKey = new();


        public PacketHost Process(PortID portID , byte[] data) {

            data.AssertNotNull(NYI.Throw);

            var packetType = (ClientPacketType)(data[0] & (byte)ClientPacketType.Mask);
            return packetType switch {
                ClientPacketType.Initial => ProcessInitial(portID, data),
                ClientPacketType.Cloaked => ProcessCloaked(portID, data),
                ClientPacketType.Answer => ProcessAnswer(portID, data),
                ClientPacketType.Post => ProcessPost(portID, data),
                _ => throw new NYI()
                };


            }

        static bool acceptToggle;
        protected virtual bool Accept(PortID portID) {
            portID.Future();

            acceptToggle = !acceptToggle;

            return acceptToggle;
            }


        protected virtual PacketHost ProcessInitial(PortID portID, byte[] data) {
            var packet = new PacketHostInitial(portID, data);

            if (Accept(portID)) {
                return new HostPacketChallenge(packet);
                }
            else {
                return new HostPacketComplete(packet);
                }
            }

        /// <summary>
        /// Process a cloaked request packet.
        /// </summary>
        /// <param name="portID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual PacketHost ProcessCloaked(PortID portID, byte[] data) {
            var packet = new PacketHostCloaked(portID, data);

            if (Accept(portID)) {
                return new HostPacketChallenge(packet);
                }
            else {
                return new HostPacketComplete(packet);
                }
            }

        protected virtual PacketHost ProcessAnswer(PortID portID, byte[] data) {
            var packet = new PacketHostAnswer(portID, data);

            return new HostPacketComplete(packet);
            }

        protected virtual PacketHost ProcessPost(PortID portID, byte[] data) {
            var packet = new PacketHostPost(portID, data);

            return new PacketHostData(packet);
            }

        }


    public class PacketHost {


        public PacketHost() {

            }


        }
    public class PacketHostIn : PacketHost {
        PortID PortID;
        public PacketHostIn(PortID portID) {
            PortID = portID;
            }


        public static PacketHost Parse(PortID portID, byte[] data) {

            data.AssertNotNull(NYI.Throw);

            var packetType = (ClientPacketType)(data[0] & (byte)ClientPacketType.Mask);
            return packetType switch {

                _ => throw new NYI()
                };



            }
        }


    public class PacketHostOut: PacketHost {
        }
    public class PacketHostInitial : PacketHostIn {

        public PacketHostInitial(PortID portID, byte[] data) :base (portID){
            // parse data

            }


        }


    public class PacketHostCloaked : PacketHostIn {

        public PacketHostCloaked(PortID portID, byte[] data) : base(portID) {
            // parse data

            }

        }

    public class PacketHostAnswer : PacketHostIn {

        public PacketHostAnswer(PortID portID, byte[] data) : base(portID) {
            // parse data

            // validate challenge


            }
        }

    public class PacketHostPost : PacketHostIn {
        byte[] payload;
        public PacketHostPost(PortID portID, byte[] data) : base(portID) {
            // parse data

            // associate to connection


            }

        }

    public class HostPacketChallenge : PacketHost {
        public HostPacketChallenge(PacketHostInitial packetHost) {
            }

        public HostPacketChallenge(PacketHostCloaked packetHost) {
            }


        }
    public class HostPacketComplete : PacketHost {
        public HostPacketComplete(PacketHostInitial packetHost) {
            }
        public HostPacketComplete(PacketHostCloaked packetHost) {
            }
        public HostPacketComplete(PacketHostAnswer packetHost) {
            }
        }
    public class PacketHostData : PacketHost {

        public PacketHostData(PacketHostPost packetHost) {
            }

        }
    public class HostPacketAbort : PacketHost {

        }

    }
