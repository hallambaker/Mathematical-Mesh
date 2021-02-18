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

            var payload1 = MakePayload();
            var payload2 = MakePayload();
            var payload3 = MakePayload();
            var payload4 = MakePayload();
            var payload5 = MakePayload();

            using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Refused);

            // using client connection
            using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest, portID, null);

            
            // Client: Initial message
            var clientInitialData = connectionClient.SerializeClientInitial(payload1);

            // Host: Get initial, respond host exchange.
            var clientInitialPacket = listenerHostTest.Parse(portID, clientInitialData) as PacketInitial;
            var connectionHost = listenerHostTest.MakeConnection(clientInitialPacket);
            var hostExchangeData = connectionHost.SerializeHostExchange(payload2);
            clientInitialPacket.Payload.TestEqual(payload1);

            // Client: Complete 
            var hostExchangePacket = connectionClient.ParsePacketHostExchange(portID, hostExchangeData);
            var clientCompleteData = connectionClient.SerializeClientComplete(payload3);
            hostExchangePacket.Payload.TestEqual(payload2);

            // Host: send data
            var clientCompletePacket = connectionHost.ParsePacketClientComplete(portID, clientCompleteData);
            var hostData = connectionHost.SerializePacketData(payload4);
            clientCompletePacket.Payload.TestEqual(payload3);

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
