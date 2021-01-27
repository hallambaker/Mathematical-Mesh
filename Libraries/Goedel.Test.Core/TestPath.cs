using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Server;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Test.Core {


    public class Trace {

        public byte[] Request;
        public byte[] Response;
        public Response ResponseObject;
        public Request RequestObject;

        public string XMLRequest => GetRequest();
        public string XMLResponse=> GetResponse();

        public string GetRequest() => RequestText;
        public string GetResponse() => ResponseText;

        public string RequestText;
        public string ResponseText;
        public Trace(byte[] request, byte[] response, JsonObject requestObject) {
            Request = request;
            Response = response;
            RequestText = Request.ToUTF8();
            ResponseText = Response.ToUTF8();
            RequestObject = requestObject as Request;
            ResponseObject = Goedel.Protocol.Response.FromJson(Response.JsonReader(), true);
            }

        }


    /// <summary>
    /// Test environment for one test with one service with one or more devices.
    /// </summary>
    public class TestEnvironmentCommon  {

        //static TestEnvironmentCommon() {
        //    Cryptography.Cryptography.Initialize();
        //    var _ = Goedel.Mesh.Client.ConnectionItem.Initialize;
        //    _ = Goedel.Mesh.MeshProtocol.Initialize;
        //    _ = Goedel.Mesh.MeshItem.Initialize;
        //    _ = Goedel.Mesh.Server.CatalogItem.Initialize;


        //    }


        public string ServiceName = "example.com";
        static string TestPath = "TestPath";
        static string TestRoot;

        public static string CommonData => System.IO.Path.Combine(TestRoot, "CommonData");
        public static string WorkingDirectory => System.IO.Path.Combine(TestRoot, "WorkingDirectory");
        public static string Variable => System.IO.Path.Combine(TestRoot, "Variable");

        public string Path => System.IO.Path.Combine(Variable, Test);
        public string ServiceDirectory => System.IO.Path.Combine(Path, "ServiceDirectory");
        public string Test;


        static bool Direct = false;

        public MeshLocalPortal MeshLocalPortal => meshPortalDirect ??
            (Direct ? new MeshPortalDirect(ServiceName, ServiceDirectory).CacheValue(out meshPortalDirect) :
            new MeshPortalTest(ServiceName, ServiceDirectory).CacheValue(out meshPortalDirect));

        MeshLocalPortal meshPortalDirect = null;


        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="testMode">If true, the application will be initialized in
        /// test/debug mode.</param>

        static TestEnvironmentCommon() {
            TestRoot = Environment.GetEnvironmentVariable(TestPath);
            TestRoot.AssertNotNull(EnvironmentVariableRequired.Throw, TestPath);

            Directory.CreateDirectory(WorkingDirectory);
            Directory.SetCurrentDirectory(WorkingDirectory);
            }

        public TestEnvironmentCommon() {
            Test = Unique.Next();
            Path.DirectoryDelete();
            Directory.CreateDirectory(Path);
            Directory.CreateDirectory(ServiceDirectory);
            }

        public string MachinePath(string machineName) => System.IO.Path.Combine(Path, machineName);


        public static KeyCollection MakeKeyCollection() {
            var testEnvironment = new TestEnvironmentCommon();
            //var machineAdmin = new MeshMachineTest(TestEnvironment, "Test");
            return new KeyCollectionTestEnv(testEnvironment.Path);
            }

        public static DarePolicy MakePolicy(
                CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) =>
            MakePolicy(out _, out _, signId, encryptId);
        public static DarePolicy MakePolicy(
            out KeyPair signKey, out KeyPair encryptKey,
            CryptoAlgorithmId signId = CryptoAlgorithmId.NULL,
            CryptoAlgorithmId encryptId = CryptoAlgorithmId.NULL) {

            encryptKey = null;
            signKey = null;

            var keyCollection = MakeKeyCollection();


            if (encryptId != CryptoAlgorithmId.NULL) {
                encryptKey = KeyPair.Factory(encryptId,
                        KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Encrypt);
                }
            if (signId != CryptoAlgorithmId.NULL) {
                signKey = KeyPair.Factory(encryptId,
                        KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Sign);
                }

            return new DarePolicy(keyCollection, signKey, encryptKey);
            }


        }

    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class MeshPortalTest : MeshLocalPortal {

        public List<Trace> MeshProtocolMessages;


        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="serviceName">DNS service name</param>
        /// <param name="serviceDirectory">File name for the Mesh Store.</param>
        /// <param name="portalStore">File name for the Portal Store.</param>
        public MeshPortalTest(string serviceName = null, string serviceDirectory = null) {
            ServiceName = serviceName ?? ServiceName;
            ServiceDirectory = serviceDirectory ?? ServiceDirectory;
            MeshServiceHost = new PublicMeshServiceProvider(ServiceName, ServiceDirectory);
            MeshServiceHost.Service = new PublicMeshService(MeshServiceHost, null);
            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="accountAddress">The account to get.</param>
        /// <returns>The service instance</returns>
        public override MeshService GetService(string accountAddress) {
            if (accountAddress == null) {
                return null;
                }

            //accountAddress.SplitAccountIDService(out var Service, out var Account);

            var Session = new TestSession(this, MeshServiceHost, accountAddress);
            MeshServiceClient = Session.GetWebClient<MeshServiceClient>();

            return MeshServiceClient;
            }

        }

    public partial class TestSession : LocalRemoteSession {
        MeshPortalTest MeshPortalTest;
        public List<Trace> MeshProtocolMessages => MeshPortalTest.MeshProtocolMessages;

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public TestSession(MeshPortalTest meshPortalTest, JpcProvider host, string accountAddress) : base(host, accountAddress) {


            MeshPortalTest = meshPortalTest;
            Authenticated = true;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject Request) {
            MeshPortalTest.MeshProtocolMessages ??=                 new List<Trace>();
            var requestBytes = data.ToArray();

            var JSONReader = new JsonReader(requestBytes);
            var result = Host.Dispatch(this, JSONReader);
            var responseBytes = result.GetBytes();

            var trace = new Trace(requestBytes, responseBytes, Request) ;

            MeshProtocolMessages.Add(trace);
            return new MemoryStream(responseBytes);
            }

        }
    }
