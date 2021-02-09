using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
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



        public PacketHost Parse(PortID portID, byte[] packet) {
            // check inputs
            packet.AssertNotNull(NYI.Throw);
            (packet.Length > 0).AssertTrue(NYI.Throw);

            return packet[0] switch {
                byte b when ((b & 0b1000_0000) != 0) =>
                        new PacketHostInitial(portID, packet),
                (byte)ClientPacketType.Initial =>
                        new PacketHostInitial(portID, packet),
                (byte)ClientPacketType.Cloaked =>
                        new PacketHostInitial(portID, packet),
                (byte)ClientPacketType.Answer =>
                        new PacketHostInitial(portID, packet),
                _ => new PacketHostUnknown(portID, packet)
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

        public byte[] Payload { get; set; }
        public PortID PortID;
        public PacketHostIn(PortID portID) {
            PortID = portID;


            
            
            }

        }


    public class PacketHostOut: PacketHost {
        }




    public class PacketHostInitial : PacketHostIn {

        public PacketHostInitial(PortID portID, byte[] data) :base (portID){

            var buffer = new MemoryStream(data);
            buffer.Position++; // ignore the first byte.
            var reader = new JsonBcdReader(buffer);

            // Read the data
            Payload= reader.ReadBinary();

            // ignore the padding.
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
        
        public PacketHostPost(PortID portID, byte[] data) : base(portID) {
            // parse data

            // associate to connection


            }

        }

    public class PacketHostUnknown : PacketHostIn {

        public PacketHostUnknown(PortID portID, byte[] data) : base(portID) {
            // parse data

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
