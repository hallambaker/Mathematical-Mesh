using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
namespace Goedel.XUnit {
    public partial class GoedelProtocolService {


        [Fact]
        public void InitialImmediateTest() {
            var portID = new PortId();
            var clientCredential = new PresentationCredentialTest();
            var hostCredential = new PresentationCredentialTest();

            var payload1 = MakePayload(100);
            var payload2 = MakePayload(100);
            var payload3 = MakePayload(100);
            var payload4 = MakePayload(100);
            var payload5 = MakePayload(100);

            using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Refused);

            // using client connection
            using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest, portID, null);

            
            // Client: Initial message
            var clientInitialData = connectionClient.SerializeInitial(payload1);

            // Host: Get initial, respond host exchange.
            var clientInitialPacket = listenerHostTest.Parse(portID, clientInitialData) as PacketInitial;
            var connectionHost = listenerHostTest.MakeConnection(clientInitialPacket);
            var hostExchangeData = connectionHost.SerializeHostExchange(payload2);
            // need to extract the ephemeral here!!

            // Client: Complete 
            var hostExchangePacket = connectionClient.ParsePacketHostExchange(portID, hostExchangeData);
            var clientCompleteData = connectionClient.SerializeClientComplete(payload3);

            // Host: send data
            var clientCompletePacket = listenerHostTest.ParsePacketClientComplete(portID, hostExchangeData);
            var hostData = connectionHost.SerializePacketData(payload4);

            // Client: receive data 
            var hostDataPacket = connectionClient.ParsePacketData(portID, hostData);
            var clientData = connectionClient.SerializePacketData(payload5);
            hostDataPacket.Payload.TestEqual(payload4);

            // Host: back atcha
            var clientDataPacket = connectionHost.ParsePacketData(portID, hostData);
            clientDataPacket.Payload.TestEqual(payload5);

            }


        [Fact]
        public void InitialDeferredTest() {

            }


        [Fact]
        public void ClientImmediateTest() {

            }


        [Fact]
        public void ClientDeferredTest() {

            }




        }
    }
