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
            var connectionHost = listenerHost.GetConnectionHost(clientInitialPacket);
            var hostExchangeData = connectionHost.SerializeHostExchange(payload2);


            // Client: Complete 
            var hostExchangePacket = connectionClient.ParseHostExchange(portID, hostExchangeData);
            hostExchangePacket.Payload.TestEqual(payload2);
            var clientCompleteData = connectionClient.SerializeClientComplete(payload3);


            //// Host: send data
            var clientCompletePacket = connectionHost.ParseClientComplete(portID, clientCompleteData);
            connectionHost.CompleteClientComplete(clientCompletePacket);
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

            //// Host: Get initial, respond challenge
            var clientInitialPacket = Listener.ParseClientInitial(portID, clientInitialData);
            clientInitialPacket.Payload.TestEqual(payload1);
            var hostChallengeData = listenerHost.SerializeChallenge(clientInitialPacket, payload2);

            // Respond to the challenge.
            var hostChallengePacket = connectionClient.ParseHostChallenge1(portID, hostChallengeData);
            hostChallengePacket.Payload.TestEqual(payload2);
            var ClientCompleteData = connectionClient.SerializeClientCompleteDeferred(payload3);

            // Host: Complete the exchange
            var clientCompletePacket = Listener.ParseClientCompleteDeferred(portID, ClientCompleteData);
            var connectionHost = listenerHost.GetConnectionHost(clientCompletePacket);
            //connectionHost.CompleteClientCompleteDeferred(clientCompletePacket);
            clientCompletePacket.Payload.TestEqual(payload3);

            }


        [Fact]
        public void ClientImmediateTest() {
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
            using var connectionClient = new TestConnectionClient(clientCredential) {
                CredentialOther = hostCredential
                };


            //// Client: Initial message
            var clientInitialData = connectionClient.SerializeClientExchange(payload1);

            //// Host: Get initial, respond host exchange.
            var clientExchangePacket = Listener.ParseClientExchange(portID, clientInitialData);

            var connectionHost = listenerHost.GetConnectionHost(clientExchangePacket);

            //connectionHost.CompleteClientExchange(clientExchangePacket);
            clientExchangePacket.Payload.TestEqual(payload1);
            var hostCompleteData = connectionHost.SerializeHostComplete(payload2);

            // Client: complete the process
            var hostCompletePacket = connectionClient.ParseHostComplete(portID, hostCompleteData);
            hostCompletePacket.Payload.TestEqual(payload2);
            }


        [Fact]
        public void ClientDeferredTest() {
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
            using var connectionClient = new TestConnectionClient(clientCredential) {
                CredentialOther = hostCredential
                };


            //// Client: Initial message
            var clientInitialData = connectionClient.SerializeClientExchange(payload1);

            //// Host: Get initial, respond host exchange.
            var clientExchangePacket = Listener.ParseClientExchange(portID, clientInitialData);
            clientExchangePacket.Payload.TestNull(); // Didn't complete so payload is lost

            var hostChallengeData = listenerHost.SerializeChallenge(clientExchangePacket, payload2);

            // Respond to the challenge.
            var hostChallengePacket = connectionClient.ParseHostChallenge2(portID, hostChallengeData);
            hostChallengePacket.Payload.TestEqual(payload2);
            var ClientCompleteData = connectionClient.SerializeClientCompleteDeferred(payload3);

            // Host: Complete the exchange
            var clientCompletePacket = Listener.ParseClientCompleteDeferred(portID, ClientCompleteData);
            var connectionHost = listenerHost.GetConnectionHost(clientCompletePacket);
            clientCompletePacket.Payload.TestEqual(payload3);
            }




        }
    }
