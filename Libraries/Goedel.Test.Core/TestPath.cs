using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh.Server;
using Goedel.Mesh;

namespace Goedel.Test.Core {

    /// <summary>
    /// Test environment for one test with one service with one or more devices.
    /// </summary>
    public class TestEnvironmentCommon : Initialization {

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

        public MeshPortalDirect MeshPortalDirect => meshPortalDirect ??
            new MeshPortalDirect(ServiceName, ServiceDirectory).CacheValue(out meshPortalDirect);
        MeshPortalDirect meshPortalDirect=null;



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
            Test =  Unique.Next();
            Path.DirectoryDelete();
            Directory.CreateDirectory(Path);
            Directory.CreateDirectory(ServiceDirectory);
            }

        public string MachinePath(string machineName) => System.IO.Path.Combine(Path, machineName);


        }

    }
