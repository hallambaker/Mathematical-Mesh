using System;
using System.IO;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using System.Linq;
using Goedel.Cryptography;
using System.Numerics;
using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class CreateExamples {

        static void Main() {
            Console.WriteLine("Make Document Set");
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.
            var createWeb = new CreateExamples();
            createWeb.Examples();
            }

        TestCLI testCLIAlice1, testCLIAlice2, testCLIAlice3, testCLIAlice4;
        TestCLI testCLIBob1;
        TestCLI testCLIMallet1;

        public Dictionary<string, string> ToDoList = new Dictionary<string, string>();

        public string TestDir1 = "TestDir1";
        public string TestDir2 = "TestOut";
        public string TestFile1 = "TestFile1.txt";
        public string TestFile2 = "TestFile2.txt";
        public string TestFile3 = "TestFile3.txt";
        public string TestFile4 => Path.Combine(TestDir1, "TestFile4.txt");
        public string TestFile5 => Path.Combine(TestDir1, "TestFile5.txt");
        public string TestText1 = "This is a test";
        public string TestText2 = "This is a test 2";
        public string TestText3 = "This is a test 3";
        public string TestText4 = "This is a test 4";
        public string TestText5 = "This is a test 5";

        public string EARLService = "example.com";

        public string TestFile1Group = "TestFile1-group.dare";

        public string TestContainer = "Container.dcon";
        public string TestContainerEncrypt = "ContainerEncrypt.dcon";
        public string TestContainerArchive = "ContainerArchive.dcon";
        public string TestContainerArchiveEnhance = "ContainerArchiveEncrypt.dcon";

        public string TestContainer2 = "Container2.dcon";
        public string TestContainerEncrypt2 = "ContainerEncrypt2.dcon";
        public string TestContainerArchive2 = "ContainerArchive2.dcon";
        public string TestContainerArchiveEnhance2 = "ContainerArchiveEncrypt2.dcon";

        public string TestExport = "profile.dare";


        public string DareLogEarl = "EarlLog.dlog";

        public string AliceAccount1 = "personal";
        public string AliceAccount2 = "business";
        public string AliceService1 = "alice@example.com";
        public string AliceService2 = "alice@example.net";

        public string AliceAccount2Outbound = "smtp:submit.example.net:587";
        public string AliceAccount2Inbound = "imap4:imap.example.net:993";

        public string BobAccount = "personal";
        public string BobService = "bob@example.com";
        public string CarolService = "carol@example.com";
        public string DougService = "doug@example.com";
        public string MalletService = "mallet@example.com";
        public string GroupService = "groupw@example.com";
        public string PollService = "devices@example.com";

        public string AliceContactFile = "alice-contact.json";
        public string CarolContactFile = "carol-contact.json"; 
        public string DougAccountUDF = "UDF://example.com/ERRROR"; // ToDo: calculate Doug UDF

        public string AliceDevice1 = "Alice";
        public string AliceDevice2 = "Alice2";
        public string AliceDevice3 = "Alice3";
        public string AliceDevice4 = "Alice4";
        public string AliceDevice5 = "Alice5";

        string outputPath;

        public void Examples() {
            outputPath = Directory.GetCurrentDirectory();
            TestEnvironment = new TestEnvironmentCommon();
            //var t= Directory.GetCurrentDirectory();

            testCLIAlice1 = GetTestCLI(AliceDevice1);
            testCLIAlice2 = GetTestCLI(AliceDevice2);
            testCLIAlice3 = GetTestCLI(AliceDevice3);
            testCLIAlice4 = GetTestCLI(AliceDevice4);
            testCLIBob1 = GetTestCLI("Bob");
            testCLIMallet1 = GetTestCLI("Mallet");

            Directory.CreateDirectory(TestDir1);
            TestFile1.WriteFileNew(TestText1.ToString());
            TestFile2.WriteFileNew(TestText2.ToString());
            TestFile3.WriteFileNew(TestText3.ToString());
            TestFile4.WriteFileNew(TestText4.ToString());
            TestFile5.WriteFileNew(TestText5.ToString());
            //var t2 = Directory.GetCurrentDirectory();

            GitHub = true;

            PlatformUDF();
            PlatformCrypto();
            PlatformDare();

            LayerDevice();
            LayerAccount();
            LayerService();
            LayerMessage();

            Directory.SetCurrentDirectory(outputPath);
            var CreateExamples = new CreateExamples();
            CreateExamples.WebDocs(this);

            Directory.SetCurrentDirectory("../Release/Documents");

            GitHub = false;


            MakeUDFExamples(this);

            MakeArchitectureExamples(this);


            MakeDareExamples(this);
            MakeSchemaExamples(this);
            MakeProtocolExamples(this);
            MakeCryptographyExamples(this);

            MakeDocs();

            }

        public bool All = true;


        public void MakeClean() {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeClean");
            Process.WaitForExit();
            }

        public void MakeDocs() {
            var Process = All ? System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs") :
                System.Diagnostics.Process.Start("CMD.exe", "/C MakeOneDoc");
            Process.WaitForExit();
            }





        public TestEnvironmentCommon TestEnvironment;
        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }


        #region // Mesh commands

        public string AliceProfileUDF => // (ProfileAliceRegister[0].Result as ResultMasterCreate)?.MeshUDF ?? 
            "uuuu-uuuu-uuuu".Task("Fix the register command");

        #endregion
        #region // Application commands


        List<T> Concat<T>(params List<T>[] lists) {
            var result = new List<T>();

            foreach (var list in lists) {
                foreach (var entry in list) {
                    result.Add(entry);
                    }
                }

            return result;
            }


        #endregion
        }
    }
