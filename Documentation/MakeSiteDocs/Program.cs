﻿using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Mesh.Shell;

using System;
using System.Collections.Generic;
using System.IO;

#pragma warning disable IDE0059

namespace ExampleGenerator {


    public partial class CreateExamples  {

        public bool GitHub = true;
        public string Preformat => GitHub ? "````" : "~~~~";



        static void Main() {
            Screen.WriteLine("Make Document Set");
            var createWeb = new CreateExamples();
            createWeb.Examples();
            }

        public virtual TestCLI Alice1 { get; protected set; }
        public virtual TestCLI Alice2 { get; protected set; }
        public virtual TestCLI Alice3 { get; protected set; }
        public virtual TestCLI Alice4 { get; protected set; }
        public virtual TestCLI Bob1 { get; protected set; }
        public virtual TestCLI Mallet1 { get; protected set; }
        public virtual TestCLI Console1 { get; protected set; }
        public virtual TestCLI Maker1 { get; protected set; }

        public virtual string Secret1 { get; set; }

        #region // Should probably suppress these...
        public List<ExampleResult> ProfileCreateAlice;
        public List<ExampleResult> ProfileAliceDelete;
        public List<ExampleResult> ProfileAliceRecover;
        public List<ExampleResult> ProfileCreateBob;


        public List<ExampleResult> ProfileList;
        public List<ExampleResult> ProfileDump;

        public List<ExampleResult> ProfileExport;
        public List<ExampleResult> ProfileImport;
        public List<ExampleResult> ProfileHello;

        public ResultCreatePersonal AliceProfiles;
        public ResultHello ResultHello;
        #endregion


        public Dictionary<string, string> ToDoList = new Dictionary<string, string>();

        public const string TestDir1 = "TestDir1";
        public const string TestDir2 = "TestOut";
        public const string TestFile1 = "TestFile1.txt";
        public const string TestFile2 = "TestFile2.txt";
        public const string TestFile3 = "TestFile3.txt";
        public static string TestFile4 => Path.Combine(TestDir1, "TestFile4.txt");
        public static string TestFile5 => Path.Combine(TestDir1, "TestFile5.txt");
        
        public const string TestText1 = "This is a test 1";
        public const string TestText2 = "This is a test 2";
        public const string TestText3 = "This is a test 3";
        public const string TestText4 = "This is a test 4";
        public const string TestText5 = "This is a test 5";

        public const string EARLService = "example.com";

        public const string TestFile1Group = "TestFile1-group.dare";



        public const string TestExport = "profile.dare";


        public const string DareLogEarl = "EarlLog.dlog";

        public const string MeshServiceProvider1 = "example.com";
        public const string MeshServiceProvider2 = "example.net";


        public static string AliceAccount => "alice@" + MeshServiceProvider1;
        public static string AliceAccountNew => "alice@" + MeshServiceProvider2;


        public const string BobAccount = "bob@example.com";
        public const string MeshServiceProvider = "example.com";
        public const string ConsoleAccount = "console@example.com";
        public const string MakerAccount = "maker@example.com";
        public const string CarolAccount = "carol@example.com";
        public const string DougAccount = "doug@example.com";
        public const string MalletAccount = "mallet@example.com";
        public const string GroupAccount = "groupw@example.com";

        public const string PollService = "devices@example.com";


        public const string AliceContactFile = "alice-contact.json";
        public const string CarolContactFile = "carol-contact.json";
        public const string DougAccountUDF = "UDF://example.com/ERRROR"; // ToDo: calculate Doug UDF

        public const string AliceDevice1 = "Alice";
        public const string AliceDevice2 = "Alice2";
        public const string AliceDevice3 = "Alice3";
        public const string AliceDevice4 = "Alice4";
        public const string AliceDevice5 = "Alice5";

        string outputPath;


        public LayerAccount Account;
        public LayerConnect Connect;
        public LayerApps Apps;
        public LayerService Service;
        public LayerContact Contact;
        public LayerConfirm Confirm;
        public LayerGroup Group;
        public LayerNYI NYI;

        public void Examples() {

            outputPath = Directory.GetCurrentDirectory();
            TestEnvironment = new TestEnvironmentCommon();

            PlatformCrypto();


            Directory.CreateDirectory(TestDir1);
            TestFile1.WriteFileNew(TestFile1Text.ToString());
            TestFile2.WriteFileNew(TestText2.ToString());
            TestFile3.WriteFileNew(TestText3.ToString());
            TestFile4.WriteFileNew(TestText4.ToString());
            TestFile5.WriteFileNew(TestText5.ToString());
            //var t2 = Directory.GetCurrentDirectory();

            GitHub = true;

            PlatformUDF();
            PlatformCrypto();

            Service = new LayerService(this);
            Account = new LayerAccount(this);
            Connect = new LayerConnect(this);
            Apps = new LayerApps(this);
            Contact = new LayerContact(this);
            Confirm = new LayerConfirm(this);
            Group = new LayerGroup(this);
            NYI = new LayerNYI(this);


            PerformAll();


            LayerAccount();

            // Dare uses the keys from the contacts catalog.
            PlatformDare();




            Directory.SetCurrentDirectory(outputPath);
            var CreateExamples = new CreateExamples();
            WebDocs(this);

            Directory.SetCurrentDirectory("..\\Outputs\\Documents");
            GitHub = false;


            // Call the generators to create output.
            MakeUDFExamples(this);
            MakeArchitectureExamples(this);
            MakeDareExamples(this);
            MakeSchemaExamples(this);
            MakeProtocolExamples(this);
            MakeCryptographyExamples(this);




            Console.WriteLine($"*****");
            Console.WriteLine($"Missing {CountMissing} of which {CountObsolete} obsolete");

            MakeDocs();
            }

        public bool All = true;



        public static void MakeClean() {
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


        public static List<T> Concat<T>(params List<T>[] lists) {
            var result = new List<T>();

            foreach (var list in lists) {
                if (list != null) {
                    foreach (var entry in list) {
                        result.Add(entry);
                        }
                    }
                }

            return result;
            }


        #endregion
        }
    }
