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
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

using Goedel.Protocol;
using Goedel.Protocol.Presentation;

namespace Goedel.Test.Core {


    /// <summary>
    /// Expanded test session that captures RUD packet traces.
    /// </summary>
    public partial class TestSessionRud : TestSession {

        TestServiceRud TestServiceRud { get; }

        ConnectionInitiatorTest ConnectionInitiatorTest { get; }

        RudStream RudStream { get; }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public TestSessionRud(TestServiceRud testServiceRud, ICredentialPrivate clientCredential,
                    List<Trace> meshProtocolMessages, object machine) :
                        base(testServiceRud.Host, clientCredential, meshProtocolMessages, machine) {
            TestServiceRud = testServiceRud;
            Machine = machine;
            MeshProtocolMessages = meshProtocolMessages;


            ConnectionInitiatorTest = new ConnectionInitiatorTest(clientCredential, null);
            RudStream = new RudStream(null, null, clientCredential, null, ConnectionInitiatorTest);
            }



        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject Request) {
            var requestBytes = data.ToArray();

            var (responseBytes, trace) = TestServiceRud.Dispatch(requestBytes, this);

            MeshProtocolMessages.Add(trace);
            return new MemoryStream(responseBytes);
            }



        }

    public class RudStreamTest : RudStream {


        public RudStreamTest(
                    RudStream parent,
                    string protocol,
                    ICredentialPrivate credentialSelf = null,
                    ICredentialPublic credentialOther = null,
                        RudConnection rudConnection = null,
                    string accountAddress = null) : base(
                parent, protocol, credentialSelf, credentialOther, rudConnection, accountAddress) {
            }

        }


    public class TestServiceRud {


        RudListenerTest RudListenerTest { get; }


        public JpcInterface Host { get; }

        public TestServiceRud(JpcInterface host, ICredentialPrivate hostCredential) {
            Host = host;
            var rudProvider = new List<RudProvider> {
                new RudProvider(new List<Endpoint>(), host)
            };
            RudListenerTest = new RudListenerTest(hostCredential, rudProvider);

            }


        public (byte[], Trace) Dispatch(byte[] requestBytes, TestSessionRud session) =>
                RudListenerTest.Dispatch(requestBytes, session);


            //{
            //var jsonReader = new JsonReader(requestBytes);

        //var result = Host.Dispatch(session, jsonReader);

        //var responseBytes = result.GetBytes();
        //var trace = new Trace(requestBytes, responseBytes, Host);
        //return (responseBytes, trace);
        //}



        }


    }
