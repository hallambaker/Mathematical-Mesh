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

using Xunit;
namespace Goedel.XUnit {
    public partial class GoedelProtocolService {




        [Fact]
        public void TestParseClient () {

            var portID = new PortID();
            var presentationCredential = new PresentationCredentialTest();


            var hostKeyExchange = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device);

            var test1 = new byte[100];

            // create packet
            var packet = new PacketClientInitial(test1);

            // parse packet
            var parsed = PacketHostIn.Parse(portID, packet.GetData());


            // verify result
            (parsed as PacketHostInitial).TestNotNull();


            }



        [Fact]
        public void TestParseHost() {

            // create packet




            // parse packet

            // verify result


            }


        [Fact]
        public void TestConnectionImmediate () {

            var portID = new PortID();

            var presentationCredential = new PresentationCredentialTest();

            var test1 = new byte[100];
            var test2 = new byte[100];
            var test3 = new byte[100];
            // Create host

            using var listenerHostTest = new ListenerHostTest(ListenerMode.Immediate);

            // using client connection
            using var connectionClient = new ConnectionClientTest(presentationCredential, listenerHostTest, 
                            portID, null);

            var resp1 = connectionClient.Write(test1);
            (resp1 as PacketClientComplete).TestNotNull();
            
            var resp2 = connectionClient.Write(test2);
            (resp2 as PacketClientData).TestNotNull();

            var resp3 = connectionClient.Write(test3);
            (resp3 as PacketClientData).TestNotNull();
            }

        [Fact]
        public void TestConnectionDeferred() {
            var portID = new PortID();
            var presentationCredential = new PresentationCredentialTest();

            var test1 = new byte[100];
            var test2 = new byte[100];
            var test3 = new byte[100];
            // Create host

            using var listenerHostTest = new ListenerHostTest(ListenerMode.Deferred);

            // using client connection
            using var connectionClient = new ConnectionClientTest(presentationCredential, listenerHostTest, portID, null);

            var resp1 = connectionClient.Write(test1);
            (resp1 as PacketClientChallenge).TestNotNull();

            var resp2 = connectionClient.Write(test2);
            (resp2 as PacketClientComplete).TestNotNull();

            var resp3 = connectionClient.Write(test3);
            (resp3 as PacketClientData).TestNotNull();

            }


        [Fact]
        public void TestConnectionRefused() {
            var portID = new PortID();
            var presentationCredential = new PresentationCredentialTest();

            var test1 = new byte[100];
            var test2 = new byte[100];
            var test3 = new byte[100];
            // Create host

            using var listenerHostTest = new ListenerHostTest(ListenerMode.Refused);

            // using client connection
            using var connectionClient = new ConnectionClientTest(presentationCredential, listenerHostTest, portID, null);

            // These are wrong as we should throw an exception.
            var resp1 = connectionClient.Write(test1);
            (resp1 as PacketClientAbort).TestNotNull();

            var resp2 = connectionClient.Write(test2);
            (resp2 as PacketClientAbort).TestNotNull();

            var resp3 = connectionClient.Write(test3);
            (resp3 as PacketClientAbort).TestNotNull();
            }
        }


    public class PresentationCredentialTest : PresentationCredential {

        protected override KeyPair ClientKeySignPrivate { get; }

        protected override KeyPair ClientKeyExchangePrivate { get; }

        public override KeyPair ClientKeySignPublic { get; }

        public override KeyPair clientKeyExchangePublic { get; }


        public PresentationCredentialTest(KeyPair clientKeySign=null, KeyPair clientKeyExchange = null) {

            clientKeySign ??= KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Device);
            clientKeyExchange ??= KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device);


            ClientKeySignPublic = clientKeySign.KeyPairPublic();
            ClientKeySignPublic = clientKeyExchange.KeyPairPublic();

            ClientKeySignPrivate = clientKeySign;
            ClientKeyExchangePrivate = clientKeyExchange;
            }

        }


    public enum ListenerMode {
        Immediate,
        Deferred,
        Refused
        }

    public class ListenerHostTest : ListenerHost {
        ListenerMode ListenerMode { get; }

        public ListenerHostTest(ListenerMode listenerMode) {
            ListenerMode = listenerMode;
            }


        }

    public class ConnectionClientTest : ConnectionClient {
        PresentationCredentialTest PresentationCredentialTest;
        public ConnectionClientTest(PresentationCredentialTest presentationCredentialTest,
                    ListenerHostTest listenerHost, PortID portID, KeyPair servicePublic = null) :
                    base(presentationCredentialTest, portID, servicePublic) {
            PresentationCredentialTest = presentationCredentialTest;
            }

        public virtual PacketClient Post(PacketClientOut packetClientOut) {
            throw new NYI();
            }
        }

    }
