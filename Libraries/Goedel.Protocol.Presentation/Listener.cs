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
                (byte)PlaintextPacketType.Error => new PacketError(portID, packet),
                (byte)PlaintextPacketType.ClientExchange => new PacketClientExchange(portID, packet),
                (byte)PlaintextPacketType.HostChallenge => new PacketHostChallenge(portID, packet),
                (byte)PlaintextPacketType.HostComplete => new PacketHostExchange(portID, packet),
                (byte)PlaintextPacketType.Rebind => new PacketRebind(portID, packet),

                _ => new PacketUnknown(portID, packet)
                };

            }


        // Need to move this into the connection class.
        public Packet GetPacketData(PortId sourceId, byte[] packet) {

            if (DictionaryPortIdToConnection.TryGetValue(sourceId, out var connection)) {
                var reader = PacketReaderAesGcm.Unwrap(connection, packet);
                return new PacketData(sourceId, reader);
                }
            else {
                return new PacketUnknown(sourceId, packet);

                }
            }


        }


    }
