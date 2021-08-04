#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

//using Goedel.Protocol;
//using Goedel.Test.Core;
//using Goedel.Test;
//using Goedel.Utilities;
//using Goedel.Protocol.Presentation;
//using Goedel.Cryptography;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Goedel.Mesh.Test;
//using System.Threading;
//using System.Threading.Tasks;

//using Xunit;
//namespace Goedel.XUnit {
//    public partial class TestPresentationGeneric {





//        [Fact]
//        public void InitialImmediateTest() {
//            var portID = new PortId();
//            var clientCredential = GetInitiatorCredential();
//            var hostCredential = GetResponderCredential();

//            var payload1 = MakePayload();
//            var payload2 = MakePayload();
//            var payload3 = MakePayload();


//            using var listenerHost = new TestListener(hostCredential);

//            // using client connection
//            using var connectionClient = new TestConnectionClient(clientCredential);


//            //// Client: Initial message
//            var clientInitialData = connectionClient.SerializeClientInitial(payload1);

//            //// Host: Get initial, respond host exchange.
//            var clientInitialPacket = Listener.ParseClientInitial(clientInitialData) ;
//            clientInitialPacket.Payload.TestEqual(payload1);

//            var connectionHost = listenerHost.GetConnectionHost(clientInitialPacket);
//            var hostExchangeData = connectionHost.SerializeHostExchange(payload2);


//            // Client: Complete 
//            var hostExchangePacket = connectionClient.ParseHostExchange(hostExchangeData);
//            hostExchangePacket.Payload.TestEqual(payload2);
//            var clientCompleteData = connectionClient.SerializeClientComplete(payload3);


//            //// Host: send data
//            var clientCompletePacket = Listener.ParseClientComplete(clientCompleteData);
//            connectionHost.CompleteClientComplete(clientCompletePacket);
//            clientCompletePacket.Payload.TestEqual(payload3);

//            TestPacketData(connectionClient, connectionHost);

//            }



//        [Fact]
//        public void InitialDeferredTest() {
//            var portID = new PortId();
//            var clientCredential = GetInitiatorCredential();
//            var hostCredential = GetResponderCredential();

//            var payload1 = MakePayload();
//            var payload2 = MakePayload();
//            var payload3 = MakePayload();
//            var payload4 = MakePayload();
//            var payload5 = MakePayload();

//            using var listenerHost = new TestListener(hostCredential);

//            // using client connection
//            using var connectionClient = new TestConnectionClient(clientCredential);


//            //// Client: Initial message
//            var clientInitialData = connectionClient.SerializeClientInitial(payload1);

//            //// Host: Get initial, respond challenge
//            var clientInitialPacket = Listener.ParseClientInitial(clientInitialData);
//            clientInitialPacket.Payload.TestEqual(payload1);
//            var hostChallengeData = listenerHost.SerializeChallenge(clientInitialPacket, payload2);

//            // Respond to the challenge.
//            var hostChallengePacket = connectionClient.ParseHostChallenge1(hostChallengeData);
//            hostChallengePacket.Payload.TestEqual(payload2);
//            var ClientCompleteData = connectionClient.SerializeClientCompleteDeferred(payload3);

//            // Host: Complete the exchange
//            var clientCompletePacket = Listener.ParseClientCompleteDeferred(ClientCompleteData);
//            var connectionHost = listenerHost.GetConnectionHost(clientCompletePacket);
//            //connectionHost.CompleteClientCompleteDeferred(clientCompletePacket);
//            clientCompletePacket.Payload.TestEqual(payload3);


//            TestPacketData(connectionClient, connectionHost, false);
//            TestPacketData(connectionClient, connectionHost);

//            }


//        [Fact]
//        public void ClientImmediateTest() {
//            var portID = new PortId();
//            var clientCredential = GetInitiatorCredential();
//            var hostCredential = GetResponderCredential();

//            var payload1 = MakePayload();
//            var payload2 = MakePayload();
//            var payload3 = MakePayload();
//            var payload4 = MakePayload();
//            var payload5 = MakePayload();

//            using var listenerHost = new TestListener(hostCredential);

//            // using client connection
//            using var connectionClient = new TestConnectionClient(clientCredential) {
//                CredentialOther = hostCredential
//                };


//            //// Client: Initial message
//            var clientInitialData = connectionClient.SerializeClientExchange(payload1);

//            //// Host: Get initial, respond host exchange.
//            var clientExchangePacket = Listener.ParseClientExchange(clientInitialData);

//            var connectionHost = listenerHost.GetConnectionHost(clientExchangePacket);

//            //connectionHost.CompleteClientExchange(clientExchangePacket);
//            clientExchangePacket.Payload.TestEqual(payload1);
//            var hostCompleteData = connectionHost.SerializeHostComplete(payload2);

//            // Client: complete the process
//            var hostCompletePacket = connectionClient.ParseHostComplete(hostCompleteData);
//            hostCompletePacket.Payload.TestEqual(payload2);

//            TestPacketData(connectionClient, connectionHost);
//            }


//        [Fact]
//        public void ClientDeferredTest() {
//            var portID = new PortId();
//            var clientCredential = GetInitiatorCredential();
//            var hostCredential = GetResponderCredential();

//            var payload1 = MakePayload();
//            var payload2 = MakePayload();
//            var payload3 = MakePayload();
//            var payload4 = MakePayload();
//            var payload5 = MakePayload();

//            using var listenerHost = new TestListener(hostCredential);

//            // using client connection
//            using var connectionClient = new TestConnectionClient(clientCredential) {
//                CredentialOther = hostCredential
//                };


//            //// Client: Initial message
//            var clientInitialData = connectionClient.SerializeClientExchange(payload1);

//            //// Host: Get initial, respond host exchange.
//            var clientExchangePacket = Listener.ParseClientExchange(clientInitialData);
//            clientExchangePacket.Payload.TestNull(); // Didn't complete so payload is lost

//            var hostChallengeData = listenerHost.SerializeChallenge(clientExchangePacket, payload2);

//            // Respond to the challenge.
//            var hostChallengePacket = connectionClient.ParseHostChallenge2(hostChallengeData);
//            hostChallengePacket.Payload.TestEqual(payload2);
//            var ClientCompleteData = connectionClient.SerializeClientCompleteDeferred(payload3);

//            // Host: Complete the exchange
//            var clientCompletePacket = Listener.ParseClientCompleteDeferred(ClientCompleteData);
//            var connectionHost = listenerHost.GetConnectionHost(clientCompletePacket);
//            clientCompletePacket.Payload.TestEqual(payload3);

//            TestPacketData(connectionClient, connectionHost);
//            }

//        /// <summary>
//        /// Complete the test by sending and returning the client data.
//        /// </summary>
//        /// <param name="connectionClient"></param>
//        /// <param name="connectionHost"></param>
//        /// <param name="hostStart"></param>
//        void TestPacketData(
//                        SessionInitiator connectionClient,
//                        SessionResponder connectionHost,
//                        bool hostStart = true) {

//            var payload4 = MakePayload();
//            var payload5 = MakePayload();

//            if (hostStart) {
//                var hostData = connectionHost.SerializePacketData(payload4);
//                // Client: receive data 
//                var hostDataPacket = connectionClient.ParsePacketData(hostData, 0);
//                hostDataPacket.Payload.TestEqual(payload4);
//                }

//            var clientData = connectionClient.SerializePacketData(payload5);

//            // Host: back atcha
//            var clientDataPacket = connectionHost.ParsePacketData(clientData, 0);
//            clientDataPacket.Payload.TestEqual(payload5);


//            }



//        }
//    }
