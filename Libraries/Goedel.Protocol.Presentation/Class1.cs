using System;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Utilities;
namespace Goedel.Protocol.Presentation {

    public class Connection {
        }


    public enum ClientState {
        }

    public class ConnectionClient: Connection {


        public ClientState ClientState { get; private set; }

        public PacketClient Open(byte[] payload) {
            throw new NYI();
            }

        public PacketClient Write(byte[] payload) {
            throw new NYI();
            }


        }






    /// <summary>
    /// The client packet types. Two bits in the first byte of the nonce value are used to specify 
    /// the packet type to the host. The set of packet types is intentionally closed.
    /// </summary>
    public enum ClientPacketType {

        ///<summary>Used to make a plaintext request to establish a new connection to the host.
        ///This MUST used in cases where the client does not have the public key of the host.</summary> 
        Initial = 0b00,

        ///<summary>Used to make an encrypted request to establish a new connection to the host.
        ///This MAY be used in cases where the client has the public key of the host.</summary> 
        Cloaked = 0b01,

        ///<summary>Used to respond to a challenge from the host or service. Challenges are sent
        ///by the host in response to the Initial and Cloaked packets and in cases where a failure occurs
        ///and the Host opts to offer the opportunity to resynchronze. Challenges are sent by the 
        ///service in cases where a handoff is being performed.</summary> 
        Answer = 0b10,

        ///<summary>Used for all packets that are not control packets.</summary> 
        Write = 0b11,

        ///<summary>Mask used to identify the control bits in the first byte of a packet.</summary> 
        Mask = Write


        }





    public class ConnectionHost: Connection {


        public ListenerHost ListenerHost;

        public byte[] ConnectionId;

        public PacketClient Process(byte[] data) {

            throw new NYI();
            }



        public PacketClient Abort() {
            throw new NYI();
            }
        public PacketClient Challenge(byte[] payload) {
            throw new NYI();
            }
        public PacketClient Complete(byte[] payload) {
            throw new NYI();
            }
        public PacketClient Write(byte[] payload) {
            throw new NYI();
            }
        }


    public class PacketClient {

        public ConnectionHost ConnectionHost;



        }
    public class PacketClientInitial : PacketClient {
        }





    public class PacketHost {

        }
    public class HostPacketChallenge {

        }
    public class HostPacketComplete {

        }
    public class HostPacketWrite {

        }
    public class HostPacketAbort {

        }
    }
