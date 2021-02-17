using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
namespace Goedel.XUnit {
    public partial class GoedelProtocolService {




        //[Fact]
        //public void TestParseClient() {

        //    var portID = new PortId();
        //    var clientCredential = new PresentationCredentialTest();
        //    var hostCredential = new PresentationCredentialTest();
        //    var protocol = "mmm";
        //    var endpoint = "example.com";


        //    using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Immediate);
        //    using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest,
        //                    portID, protocol, endpoint);



        //    var test1 = new byte[100];

        //    // create packet
        //    var packetOut = connectionClient.SerializeInitial(test1);


        //    var packetInitial = listenerHostTest.Parse(portID, packetOut);



        //    //// parse packet
        //    //var parsed = PacketHostIn.Parse(portID, packet.Data);

        //    //// verify result
        //    //(parsed as PacketHostInitial).TestNotNull();



        //    //// create packet
        //    //var packetCloaked = new PacketClientCloaked(
        //    //        clientCredential, hostCredential, protocol, endpoint, test1);

        //    }



        //[Fact]
        //public void TestParseHost() {

        //    // create packet




        //    // parse packet

        //    // verify result


        //    }


        //[Fact]
        //public void TestConnectionImmediate () {

        //    var portID = new PortId();

        //    var clientCredential = new PresentationCredentialTest();
        //    var hostCredential = new PresentationCredentialTest();

        //    var test1 = new byte[100];
        //    var test2 = new byte[100];
        //    var test3 = new byte[100];
        //    // Create host

        //    using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Immediate);

        //    // using client connection
        //    using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest, 
        //                    portID, null);

        //    var resp1 = connectionClient.Write(test1);
        //    //(resp1 as PacketClientComplete).TestNotNull();

        //    var resp2 = connectionClient.Write(test2);
        //    //(resp2 as PacketClientData).TestNotNull();

        //    var resp3 = connectionClient.Write(test3);
        //    //(resp3 as PacketClientData).TestNotNull();
        //    }

        //[Fact]
        //public void TestConnectionDeferred() {
        //    var portID = new PortId();
        //    var clientCredential = new PresentationCredentialTest();
        //    var hostCredential = new PresentationCredentialTest();

        //    var test1 = new byte[100];
        //    var test2 = new byte[100];
        //    var test3 = new byte[100];
        //    // Create host

        //    using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Deferred);

        //    // using client connection
        //    using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest, portID, null);

        //    var resp1 = connectionClient.Write(test1);
        //    //(resp1 as PacketClientChallenge).TestNotNull();

        //    var resp2 = connectionClient.Write(test2);
        //    //(resp2 as PacketClientComplete).TestNotNull();

        //    var resp3 = connectionClient.Write(test3);
        //    //(resp3 as PacketClientData).TestNotNull();

        //    }


        //[Fact]
        //public void TestConnectionRefused() {
        //    var portID = new PortId();
        //    var clientCredential = new PresentationCredentialTest();
        //    var hostCredential = new PresentationCredentialTest();

        //    var test1 = new byte[100];
        //    var test2 = new byte[100];
        //    var test3 = new byte[100];
        //    // Create host

        //    using var listenerHostTest = new ListenerHostTest(hostCredential, ListenerMode.Refused);

        //    // using client connection
        //    using var connectionClient = new ConnectionClientTest(clientCredential, listenerHostTest, portID, null);

        //    // These are wrong as we should throw an exception.
        //    var resp1 = connectionClient.Write(test1);
        //    //(resp1 as PacketClientAbort).TestNotNull();

        //    var resp2 = connectionClient.Write(test2);
        //    //(resp2 as PacketClientAbort).TestNotNull();

        //    var resp3 = connectionClient.Write(test3);
        //    //(resp3 as PacketClientAbort).TestNotNull();
        //    }
        //}
        }

    public class PresentationCredentialTest : PresentationCredential {

        public override KeyPairAdvanced KeySignPrivate { get; }

        public override KeyPairAdvanced KeyExchangePrivate { get; }

        public override KeyPairAdvanced KeySignPublic { get; }

        public override KeyPairAdvanced KeyExchangePublic { get; }

        public override List<PacketExtension> GetCredentials {
            get {
                var credential = new PacketExtension() {
                    Tag = "C-" + KeyExchangePublic.CryptoAlgorithmId.ToJoseID(),
                    Value = KeyExchangePublic.IKeyAdvancedPublic.Encoding
                    };
                return new List<PacketExtension> { credential };
                }
            }

        public PresentationCredentialTest(KeyPair clientKeySign = null, KeyPair clientKeyExchange = null) {

            clientKeySign ??= KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Device);
            clientKeyExchange ??= KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device);


            KeySignPublic = clientKeySign.KeyPairPublic() as KeyPairAdvanced;
            KeyExchangePublic = clientKeyExchange.KeyPairPublic() as KeyPairAdvanced;

            KeySignPrivate = clientKeySign as KeyPairAdvanced;
            KeyExchangePrivate = clientKeyExchange as KeyPairAdvanced;
            }



        public override void WriteClientCredential(JsonWriter jsonWriter) {
            // Do nothing for now!

            }

        public override void WriteCredential(PacketWriter writer) => throw new NotImplementedException();
        public override KeyPairAdvanced MatchPublic(string keyIdentifier) {
            if (keyIdentifier == KeyExchangePublic.KeyIdentifier) {
                return KeyExchangePublic;
                }
            throw new NYI();
            }
        }


    public enum ListenerMode {
        Immediate,
        Deferred,
        Refused
        }

    public class ListenerHostTest : Listener {
        ListenerMode ListenerMode { get; }
        public PresentationCredentialTest HostCredential { get; }
        public ListenerHostTest(PresentationCredentialTest hostCredential,
                    ListenerMode listenerMode = ListenerMode.Immediate) : base(hostCredential) {
            HostCredential = hostCredential;
            ListenerMode = listenerMode;
            }


        public override PresentationCredential GetPresentationCredential(List<PacketExtension> extensions) {

            foreach (var extension in extensions) {
                if (extension.Tag == "C-X448") {

                    return new PresentationCredentialTest(null,
                        new KeyPairX448(extension.Value, KeySecurity.Public));
                    }
                }
            throw new NYI();
            }

        public override ConnectionHost ConnectionHostFactory(Packet packet) =>
                    new ConnectionHost(this) {
                        ClientPacket = packet
                        };

        }

    public class ConnectionClientTest : ConnectionClient {


        PresentationCredentialTest PresentationCredentialTest;
        public ConnectionClientTest(

                    PresentationCredentialTest presentationCredentialTest,
                    ListenerHostTest listenerHost,
                    PortId portID,
                    string protocol = "mmm",
                    string endpoint = "example.com") :
                    base(listenerHost, protocol, endpoint,
                        portID, presentationCredentialTest, listenerHost.HostCredential) {
            PresentationCredentialTest = presentationCredentialTest;
            }

        }

    }
