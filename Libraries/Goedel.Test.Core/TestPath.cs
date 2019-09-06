using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh.Server;
using Goedel.Mesh;
using Goedel.Protocol;


namespace Goedel.Test.Core {


    public class Trace {

        public byte[] Request;
        public byte[] Response;


        public string GetRequest() => Request.ToUTF8();
        public string GetResponse() => Response.ToUTF8();
        }


    /// <summary>
    /// Test environment for one test with one service with one or more devices.
    /// </summary>
    public class TestEnvironmentCommon : Initialization {

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

        static bool Flag = false;

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
        public static void Initialize(bool testMode = false) =>
            Initialize(ref Flag, Initialization, testMode);

        static void Initialization(bool testMode = false) {
            IO.Debug.Initialize(); // initialize the debug environment for tracing
            Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.

            TestRoot = Environment.GetEnvironmentVariable(TestPath);
            Assert.NotNull(TestRoot, EnvironmentVariableRequired.Throw, ExceptionData.Box(String: TestPath));

            Directory.CreateDirectory(WorkingDirectory);
            Directory.SetCurrentDirectory(WorkingDirectory);
            }


        public TestEnvironmentCommon() {
            Initialize(true);
            Test = Unique.Next();
            Path.DirectoryDelete();
            Directory.CreateDirectory(Path);
            Directory.CreateDirectory(ServiceDirectory);
            }

        public string MachinePath(string machineName) => System.IO.Path.Combine(Path, machineName);


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
        /// <param name="Account">The account to get.</param>
        /// <param name="Service">The service to get the service from.</param> 
        /// <returns>The service instance</returns>
        public override MeshService GetService(string serviceID) {
            serviceID.SplitAccountIDService(out var Service, out var Account);

            var Session = new TestSession(this, MeshServiceHost, serviceID);
            MeshServiceClient = new MeshServiceClient(Session);
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
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public TestSession(MeshPortalTest meshPortalTest, JPCProvider Host, string serviceID) : base(Host, serviceID) {


            MeshPortalTest = meshPortalTest;
            Authenticated = true;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream Data) {
            MeshPortalTest.MeshProtocolMessages = MeshPortalTest.MeshProtocolMessages ??
                new List<Trace>();
            var requestBytes= Data.GetBuffer();

            var JSONReader = new JSONReader(requestBytes);
            var result = Host.Dispatch(this, JSONReader);
            var responseBytes = result.GetBytes();

            var trace = new Trace {
                Request = requestBytes,
                Response = responseBytes
                };

            MeshProtocolMessages.Add(trace);
            return new MemoryStream(responseBytes);
            }

        }
    }
