#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.IO;

using Goedel.Cryptography.Core;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;

#pragma warning disable IDE0059

namespace ExampleGenerator;

// Bug: Messages are not being marked as read as they should (ConnectPINDynamicQR)
// Bug: store status does not have apex digest as it should


// ToDo: Example - Escrow and recovery (implement)
// ToDo: Example - Delete account at service (implement)
// ToDo: Documentation - Include EARLs in Architecture guide
// ToDo: Functionality - Add KMAC to key derrivation schemes. 
// ToDo: Constant MeshConstantsIdentifierDerrivation

// ToDo: Documentation Schema rewrite 6.5
// ToDo: Documentation Schema write 9.3
// ToDo: Documentation Schema Appendix A: Example Container Organization(not normative)


// ToDo: Documentation Protocol 3. Mesh Protocols link to RUD 
// ToDo: Documentation Protocol 6.2.1. Bind User Account wrong message!
// ToDo: Documentation Protocol 6.2.2. Bind Group Account  wrong message!

// ToDo: Documentation Protocol 6.2.3. Unbind Account
// ToDo: Documentation Protocol 6.3.2. Download - change to Transact!!!
// ToDo: Documentation Protocol 6.5. Publication
// ToDo: Documentation Protocol 6.6.1. Generate Key Shares
// ToDo: Documentation Protocol 6.6.2. Key Agreement
// ToDo: Documentation Protocol 6.6.3. Sign
// ToDo: Documentation Protocol 7.2. Completion Interaction
// ToDo: Documentation Protocol Section 8 needs work



// Design: Is there a need to return the Profile Host in the account?
// Design: Should the access catalog he encrypted under a different key?

public partial class CreateExamples {

    public bool GitHub = true;
    public string Preformat => GitHub ? "````" : "~~~~";

    static CreateExamples() => Initialization.Initialized.AssertTrue(Goedel.Utilities.NYI.Throw);

    static void Main() {
        Screen.WriteInfo("Make Document Set");
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


    public Dictionary<string, string> ToDoList = new();

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

    string deviceId;
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

        TestConnectDisconnect("");
        EscrowAndRecover();


        Directory.SetCurrentDirectory(outputPath);
        var CreateExamples = new CreateExamples();

        //Console.WriteLine($"***** WebDocs");
        //WebDocs(this);

        Directory.SetCurrentDirectory("..\\Outputs\\Documents");
        GitHub = false;


        //// Call the generators to create output.
        ///
        Console.WriteLine($"***** Architecture");
        MakeArchitectureExamples(this);
        Console.WriteLine($"***** UDF");
        MakeUDFExamples(this);
        Console.WriteLine($"***** DARE");
        MakeDareExamples(this);
        Console.WriteLine($"***** Schema");
        MakeSchemaExamples(this);
        Console.WriteLine($"***** Protocol");
        MakeProtocolExamples(this);
        Console.WriteLine($"***** Presentation");
        MakePresentationExamples(this);
        Console.WriteLine($"***** Cryptography");
        MakeCryptographyExamples(this);




        Console.WriteLine($"*****");
        Console.WriteLine($"Missing {CountMissing} of which {CountObsolete} obsolete");

        MakeDocs();
        }

    //public bool All = true;

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


    public string Unfinished(string example = null) {
        this.Future();
        return $">>>> Unfinished {example}\n\n" ?? "TBS";
        }

    public TestEnvironmentCommon TestEnvironment;
    public TestCLI GetTestCLI(string MachineName = null) {
        var testShell = new TestShell(TestEnvironment, MachineName);
        return new TestCLI(testShell);
        }


    #region // Mesh commands

    public string AliceProfileUDF => AliceProfileAccount?.Udf;

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
