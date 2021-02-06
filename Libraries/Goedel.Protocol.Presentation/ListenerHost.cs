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


    public class ListenerHost {

        public Dictionary<IPAddress, PortHistory> DictionaryIPAddressToPortHistory = new();
        public Dictionary<PortID, PortHistory> DictionaryPortIdToPortHistory = new ();


        public Dictionary<IPAddress, byte[]> DictionaryAddressToKey = new();
        public Dictionary<PortID, byte[]> DictionaryPortIdToKey = new();
        public Dictionary<byte[], ConnectionHost> DictionaryConnectionIdToKey = new();


        public PacketHost Process(byte[] data) {

            data.AssertNotNull(NYI.Throw);

            var packetType = (ClientPacketType)(data[0] & (byte)ClientPacketType.Mask);
            return packetType switch {
                ClientPacketType.Initial => ProcessInitial(data),
                ClientPacketType.Cloaked => ProcessCloaked(data),
                ClientPacketType.Answer => ProcessAnswer(data),
                ClientPacketType.Write => ProcessWrite(data),
                _ => throw new NYI()
                };


            }

        protected virtual PacketHostInitial ProcessInitial(byte[] data) {

            var packet = new PacketHostInitial(data);
            throw new NYI();
            }

        PacketHostCloaked ProcessCloaked(byte[] data) {
            throw new NYI();
            }

        PacketHostAnswer ProcessAnswer(byte[] data) {
            throw new NYI();
            }

        PacketHostWrite ProcessWrite(byte[] data) {
            throw new NYI();
            }
        }

    public class PacketHostInitial : PacketHost {

        public PacketHostInitial(byte[] data) {

            /*
            Client ephemeral algorithm
            Client ephemeral key  {CE, ce}
            Account Profile
            Device Connection
            Payload (plaintext)

             */

            }

        public virtual HostPacketChallenge Challenge(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketComplete Complete(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketAbort Abort(byte[] data) {
            throw new NYI();
            }


        }


    public class PacketHostCloaked : PacketHost {
        public virtual HostPacketChallenge Challenge(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketComplete Complete(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketAbort Abort(byte[] data) {
            throw new NYI();
            }

        }

    public class PacketHostAnswer : PacketHost {

        public virtual HostPacketWrite Write(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketAbort Abort(byte[] data) {
            throw new NYI();
            }
        }

    public class PacketHostWrite : PacketHost {

        public virtual HostPacketWrite Write(byte[] data) {
            throw new NYI();
            }
        public virtual HostPacketAbort Abort(byte[] data) {
            throw new NYI();
            }

        }


    }
