using System.Collections.Generic;
using System.IO;

using Goedel.Protocol;


namespace Goedel.Test.Core {

    ///// <summary>
    ///// Test credential used to create a test session.
    ///// </summary>
    //public class JpcCredentialTest : JpcCredential {
    //    public JpcInterface Host;

    //    public List<Trace> MeshProtocolMessages { get; }

    //    public JpcCredentialTest(JpcInterface host, string accountAddress, List<Trace> meshProtocolMessages) :
    //        base(accountAddress) {
    //        MeshProtocolMessages = meshProtocolMessages;
    //        }


    //    }


    /// <summary>
    /// Test session, a specialization of the serialized class in which the
    /// request and response messages are captured.
    /// </summary>
    public partial class TestSession : JpcSessionSerialized {

        //public static JpcSession JpcSessionFactory(JpcCredential jpcCredential) =>
        //        new TestSession(jpcCredential as JpcCredentialTest);




        public List<Trace> MeshProtocolMessages;

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public TestSession(JpcInterface host, ICredential credential, List<Trace> meshProtocolMessages) : base(host, credential) {
            MeshProtocolMessages = meshProtocolMessages;
            }

        //public TestSession(JpcCredentialTest jpcCredentialTest) : this(
        //                jpcCredentialTest.Host, 
        //                jpcCredentialTest.AccountAddress, 
        //                jpcCredentialTest.MeshProtocolMessages) {
        //    }


        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject Request) {
            var requestBytes = data.ToArray();

            var JSONReader = new JsonReader(requestBytes);
            var result = Host.Dispatch(this, JSONReader);
            var responseBytes = result.GetBytes();

            var trace = new Trace(requestBytes, responseBytes, Request);

            MeshProtocolMessages.Add(trace);
            return new MemoryStream(responseBytes);
            }

        }
    }
