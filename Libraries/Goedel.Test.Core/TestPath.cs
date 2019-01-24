using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh.Protocol.Server;
using Goedel.Mesh;

namespace Goedel.Test.Core {
    public class TestEnvironment : Initialization {

        static string TestPath = "TestPath";
        static string TestRoot;

        public static string CommonData => System.IO.Path.Combine(TestRoot, "CommonData");
        public static string WorkingDirectory => System.IO.Path.Combine(TestRoot, "WorkingDirectory");

        public string Path => System.IO.Path.Combine(TestRoot, Test);
        public string Test;

        static bool Flag = false;

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


        public TestEnvironment() {
            Initialize(true);
            Test =  Unique.Next();
            Path.DirectoryDelete();
            Directory.CreateDirectory(Path);
            }




        }


    public class TestMachineEnvironment {

        public string ServiceName = "example.com";
        public MeshPortalDirect MeshPortalDirect => meshPortalDirect ??
            new MeshPortalDirect(ServiceName, ServiceDirectory).CacheValue(out meshPortalDirect);
        MeshPortalDirect meshPortalDirect = null;

        TestEnvironment TestEnvironment;
        public string Name;

        public string Path => System.IO.Path.Combine(TestEnvironment.Path, Name);
        //public string WorkingDirectory => System.IO.Path.Combine(Path, "WorkingDirectory");

        public string ServiceDirectory => System.IO.Path.Combine(Path, "ServiceDirectory");

        public TestMachineEnvironment(string name = "Test",
            MeshPortalDirect meshPortalDirect = null) : 
            this(new TestEnvironment(), meshPortalDirect, name) { }


        public TestMachineEnvironment(TestEnvironment testEnvironment,
            MeshPortalDirect meshPortalDirect=null, string name = "Test") {
            this.meshPortalDirect = meshPortalDirect;
            TestEnvironment = testEnvironment;
            Name = name;
            Directory.CreateDirectory(ServiceDirectory);

            }

        }

    }
