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
            var clientCredential = new TestCredential();
            var hostCredential = new TestCredential();

            var payload1 = MakePayload();
            var payload2 = MakePayload();
            var payload3 = MakePayload();
            var payload4 = MakePayload();
            var payload5 = MakePayload();

            using var listenerHost = new TestListener(hostCredential);

            // using client connection
            using var connectionClient = new TestConnectionClient(clientCredential);


            //// Client: Initial message
            var clientInitialData = connectionClient.SerializeClientInitial(payload1);

            //// Host: Get initial, respond host exchange.
            var clientInitialPacket = Listener.ParseClientInitial(portID, clientInitialData) ;
            clientInitialPacket.Payload.TestEqual(payload1);
            var connectionHost = new TestConnectionHost(listenerHost, clientInitialPacket);
            var hostExchangeData = connectionHost.SerializeHostExchange(payload2);


            // Client: Complete 
            var hostExchangePacket = connectionClient.ParseHostExchange(portID, hostExchangeData);
            hostExchangePacket.Payload.TestEqual(payload2);
            var clientCompleteData = connectionClient.SerializeClientComplete(payload3);


            //// Host: send data
            var clientCompletePacket = connectionHost.ParseClientComplete(portID, clientCompleteData);
            clientCompletePacket.Payload.TestEqual(payload3);
            //var hostData = connectionHost.SerializePacketData(payload4);
            

            //// Client: receive data 
            //var hostDataPacket = connectionClient.ParsePacketData(portID, hostData);
            //var clientData = connectionClient.SerializePacketData(payload5);
            //hostDataPacket.Payload.TestEqual(payload4);

            //// Host: back atcha
            //var clientDataPacket = connectionHost.ParsePacketData(portID, hostData);
            //clientDataPacket.Payload.TestEqual(payload5);

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
