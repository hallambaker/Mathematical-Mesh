using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Server;
using Goedel.Protocol;
using Goedel.Utilities;

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


        public static bool Direct = false;
        public static JpcConnection JpcConnection;

        /// <summary>
        /// The actual Mesh service. This MAY be accessed through a direct, serialized or 
        /// networked session provider.
        /// </summary>
        //public PublicMeshServiceProvider MeshServiceHost => meshServiceHost ??
        //    new PublicMeshServiceProvider(ServiceName, ServiceDirectory).CacheValue(out meshServiceHost);
        //PublicMeshServiceProvider meshServiceHost;


        // This stuff will all be thrown into the service dispatch.
        public PublicMeshService MeshService => 
            new PublicMeshService (ServiceName, ServiceDirectory).CacheValue(out meshService);
        PublicMeshService meshService;

        public MeshServiceClient GetMeshClient(string accountAddress) {

            //switch (TestEnvironmentCommon.JpcConnection) {
            //    case JpcConnection.Direct: {
            //        JpcSession session = Direct ? new DirectSession(accountAddress) :
            //                    new TestSession(MeshServiceHost,
            //                            accountAddress, meshProtocolMessages);
            //        return new PublicMeshService(MeshServiceHost, session);
            //        }
            //    }

            throw new NYI();
            }


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



    }
