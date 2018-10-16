using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Goedel.Utilities;


namespace Goedel.Test.Core {
    public class TestEnvironment : Initialization {

        static string TestPath = "TestPath";
        static string TestRoot;

        public string Path => System.IO.Path.Combine(TestRoot, Test);
        public string Test;

        static bool Flag = false;

        /// <summary>
        /// Perform initialization of the Goedel.Cryptography portable class
        /// with delegates to the .NET framework methods.
        /// </summary>
        /// <param name="TestMode">If true, the application will be initialized in
        /// test/debug mode.</param>
        public static void Initialize(bool TestMode = false) =>
            Initialize(ref Flag, Initialization, TestMode);

        static void Initialization(bool TestMode = false) {
            IO.Debug.Initialize(); // initialize the debug environment for tracing
            Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.

            TestRoot = Environment.GetEnvironmentVariable(TestPath);
            Assert.NotNull(TestRoot, EnvironmentVariableRequired.Throw, ExceptionData.Box(String: TestPath));

            Directory.CreateDirectory(TestRoot);
            Directory.SetCurrentDirectory(TestRoot);
            }


        public TestEnvironment() {
            Initialize(true);
            Test =  Unique.Next();
            }




        }


    public class MachineEnvironment {
        TestEnvironment TestEnvironment;
        public string Name;

        public string Path => System.IO.Path.Combine(TestEnvironment.Path, Name);

        public MachineEnvironment(string name = "Test") : this(new TestEnvironment(), name) { }


        public MachineEnvironment(TestEnvironment testEnvironment, string name="Test") {
            TestEnvironment = testEnvironment;
            Name = name;
            Directory.CreateDirectory(Path);
            }

        }

    }
