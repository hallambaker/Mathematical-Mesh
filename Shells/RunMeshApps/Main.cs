using System;
using System.Collections.Generic;
using System.IO;
using Goedel.IO;
using Goedel.Protocol.Debug;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Discovery;
using Goedel.Mesh.Platform.Linux;
using Goedel.Recrypt;
using Goedel.Confirm;

namespace RunMeshApps {
    partial class MakeExamples {

        string OutputAccount = @"Generated/ExamplesAccount.md";
        string OutputRecrypt = @"Generated/ExamplesRecrypt.md";
        string OutputConfirm = @"Generated/ExamplesConfirm.md";

        public static string PortalService = "example.net";
        public static string AppService = "example.com";
        string LogPortal = "Portal.jlog";
        string LogMesh = "Mesh.jlog";
        static bool TestMode = true;

        static void Main (string[] Args) {
            Goedel.IO.Debug.Initialize();

            // Delete all the profiles first
            DirectoryTools.DirectoryDelete("Profiles");

            CryptographyWindows.Initialize(TestMode);
            PlatformFramework.Initialize(TestMode);
            MeshMachineLinux.Initialize(TestMode);
            MeshRecrypt.Initialize();
            MeshConfirm.Initialize();

            var Program = new MakeExamples();
            Program.Run(Args);
            }

        /// <summary>
        /// The main program loop
        /// </summary>
        /// <param name="Args"></param>
        void Run (string[] Args) {
            KeyPair.TestMode = TestMode;

            Directory.CreateDirectory("Generated");

            // Clean previous data
            MakeClean();

            if (Args.Length < 1) { 
                Generate();  // Just run code and return.
                return;
                }

            // Generate the example messages
            Generate();

            // Make the examples part
            using (var Writer = new StreamWriter(OutputAccount)) {
                var ExampleGenerator = new ExampleGenerator() { _Output = Writer };
                ExampleGenerator.MakeExamplesAccount(this);
                }


            // Make the examples part
            using (var Writer = new StreamWriter(OutputConfirm)) {
                var ExampleGenerator = new ExampleGenerator() { _Output = Writer };
                ExampleGenerator.MakeExamplesConfirm(this);
                }


            // Make the examples part
            using (var Writer = new StreamWriter(OutputRecrypt)) {
                var ExampleGenerator = new ExampleGenerator() { _Output = Writer };
                ExampleGenerator.MakeExamplesRecrypt(this);
                }

            // Generate the reference material and the drafts
            MakeDocs();
            }

        public void MakeClean () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeAppsClean");
            Process.WaitForExit();
            }

        public void MakeDocs () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeAppsDocs");
            Process.WaitForExit();
            }


        }
    }
