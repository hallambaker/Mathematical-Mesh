using System;
using System.IO;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.IO;
using Goedel.Protocol.Debug;
using Goedel.Test;
using Goedel.Cryptography;
using System.Numerics;
using System.Collections.Generic;

namespace MakeSiteDocs {

    // ToDo: Implement the File EARL


    public partial class Examples {

        static void Main(string[] args) {
            Console.WriteLine("Make Document Set");
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.
            var createWeb = new Examples();
            }

        TestCLI testCLIAlice1;
        TestCLI testCLIAlice2;
        TestCLI testCLIAlice3;
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

        public string AliceAccount = "alice@example.com";
        public string AliceAccount2 = "alice@example.net";
        public string AliceAccount2Outbound = "smtp:submit.example.net:587";
        public string AliceAccount2Inbound = "imap4:imap.example.net:993";
        public string BobAccount = "bob@example.com";
        public string CarolAccount = "carol@example.com";
        public string DougAccount = "doug@example.com";
        public string MalletAccount = "mallet@example.com";
        public string GroupAccount = "groupies@example.com";

        public string AliceContactFile = "alice-contact.json";
        public string CarolContactFile = "carol-contact.json"; 
        public string DougAccountUDF = "UDF://example.com/ERRROR"; // ToDo: calculate Doug UDF

        public string AliceDevice1 = "Alice";
        public string AliceDevice2 = "Alice";
        public string AliceDevice3 = "Alice";

        string OutputPath;

        public Examples() {
            OutputPath = Directory.GetCurrentDirectory();
            TestEnvironment = new TestEnvironmentCommon();

            testCLIAlice1 = GetTestCLI("Alice");
            testCLIAlice2 = GetTestCLI("Alice2");
            testCLIAlice3 = GetTestCLI("Alice3");
            testCLIBob1 = GetTestCLI("Bob");
            testCLIMallet1 = GetTestCLI("Mallet");

            Directory.CreateDirectory(TestDir1);
            TestFile1.WriteFileNew(TestText1.ToString());
            TestFile2.WriteFileNew(TestText2.ToString());
            TestFile3.WriteFileNew(TestText3.ToString());
            TestFile4.WriteFileNew(TestText4.ToString());
            TestFile5.WriteFileNew(TestText5.ToString());

            DoCommandsKey();
            DoCommandsHash();
            DoCommandsDare();
            DoCommandsContainer();

            DoCommandsProfile();

            DoCommandsMessage();
            DoCommandsGroup();

            DoCommandsBookmark();
            DoCommandsCalendar();
            DoCommandsNetwork();
            DoCommandsPassword();
            DoCommandsSSH();

            // Connect is last because we have to do the connection examples
            DoCommandsConnect();


            Directory.SetCurrentDirectory(OutputPath);
            var makeSiteDocs = new MakeSiteDocs();
            makeSiteDocs.WebDocs(this);
            }

        public TestEnvironmentCommon TestEnvironment;
        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }

        public List<ExampleResult> KeyNonce;
        public List<ExampleResult> KeyNonce256;
        public List<ExampleResult> KeySecret;
        public List<ExampleResult> KeySecret256;
        public List<ExampleResult> KeyEarl;

        public List<ExampleResult> KeyShare;
        public List<ExampleResult> KeyRecover;
        public List<ExampleResult> KeyShare2;
        public List<ExampleResult> KeyShare3;


        public string Secret1;

        #region // Crypto commands
        public void DoCommandsKey() {
            KeyNonce = testCLIAlice1.Example("key nonce");
            KeyNonce256 = testCLIAlice1.Example("key nonce /bits=256");
            KeySecret = testCLIAlice1.Example("key secret");
            KeySecret256 = testCLIAlice1.Example("key secret /bits=256");
            KeyEarl = testCLIAlice1.Example("key earl");
            KeyShare = testCLIAlice1.Example("key share");
            Secret1 = (KeyShare[0].Result as ResultKey).Key;
            var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

            KeyRecover = testCLIAlice1.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLIAlice1.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLIAlice1.Example($"key share {Secret1}");

            }

        public List<ExampleResult> HashUDF2;
        public List<ExampleResult> HashUDF3;
        public List<ExampleResult> HashUDF200; // Wrong precision, implement /bits
        public List<ExampleResult> HashUDFExpect; // implement /expect
        public List<ExampleResult> HashDigest;
        public List<ExampleResult> HashDigests;
        public List<ExampleResult> MAC1;  // return the key
        public List<ExampleResult> MAC2;  // implement key option
        public List<ExampleResult> MAC3;  // implement expect option

        public void DoCommandsHash() {
            HashUDF2 = testCLIAlice1.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3 = testCLIAlice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
            HashUDF200 = testCLIAlice1.Example($"hash udf {TestFile1} /bits=200");
            HashUDFExpect = testCLIAlice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            HashDigest = testCLIAlice1.Example($"hash digest {TestFile1}");
            HashDigests = testCLIAlice1.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            MAC1 = testCLIAlice1.Example($"hash mac {TestFile1}");
            var key = (MAC1[0].Result as ResultDigest).Key;
            var digest = (MAC1[0].Result as ResultDigest).Digest;

            MAC2 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key}");
            MAC3 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
                $"hash mac {TestFile1} /key={key} /expect={expect2}");
            }

        public List<ExampleResult> DarePlaintext;
        public List<ExampleResult> DareSymmetric;
        public List<ExampleResult> DareSub;
        public List<ExampleResult> DareMesh;
        public List<ExampleResult> GroupEncrypt;

        public List<ExampleResult> DareVerifyDigest;
        public List<ExampleResult> DareVerifySigned;
        public List<ExampleResult> DareVerifySymmetric;
        public List<ExampleResult> DareVerifySymmetricUnknown;

        public List<ExampleResult> DareDecodePlaintext;
        public List<ExampleResult> DareDecodeSymmetric;
        public List<ExampleResult> DareDecodePrivate;

        public List<ExampleResult> DareEarl;
        public List<ExampleResult> DareEARLLog;
        public List<ExampleResult> DareEARLLogNew;
        public void DoCommandsDare() {

            DarePlaintext = testCLIAlice1.Example($"dare encode {TestFile1}");
            DareSymmetric = testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            DareSub = testCLIAlice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            DareMesh = testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.mesh.dare" +
                        $"/encrypt={BobAccount} /sign={AliceAccount}");

            DareVerifyDigest = testCLIAlice1.Example($"dare verify {TestFile1}.dare");
            DareVerifySigned = testCLIAlice1.Example($"dare verify {TestFile1}.mesh.dare");
            DareVerifySymmetricUnknown = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare");
            DareVerifySymmetric = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            DareDecodePlaintext = testCLIAlice1.Example($"dare decode {TestFile1}.dare");
            DareDecodeSymmetric = testCLIAlice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            DareDecodePrivate = testCLIAlice1.Example($"dare decode {TestFile1}.mesh.dare");

            DareEarl = testCLIAlice1.Example($"dare earl {TestFile1}");
            DareEARLLog = testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceAccount}",
                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            DareEARLLogNew = testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");
            }

        public List<ExampleResult> ContainerCreate;
        public List<ExampleResult> ContainerCreateEncrypt;
        public List<ExampleResult> ContainerArchive;
        public List<ExampleResult> ContainerArchiveEnhance;
        public List<ExampleResult> ContainerArchiveVerify;
        public List<ExampleResult> ContainerArchiveExtractAll;
        public List<ExampleResult> ContainerArchiveExtractFile;

        public List<ExampleResult> ContainerAppend;
        public List<ExampleResult> ContainerDelete;
        public List<ExampleResult> ContainerIndex;
        public List<ExampleResult> ContainerArchiveCopy;
        public List<ExampleResult> ContainerArchiveCopyDecrypt;
        public List<ExampleResult> ContainerArchiveCopyPurge;

        public void DoCommandsContainer() {
            ContainerCreate = testCLIAlice1.Example($"container create {TestContainer}");
            ContainerCreateEncrypt = testCLIAlice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupAccount}");
            ContainerArchive = testCLIAlice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ContainerArchiveEnhance = testCLIAlice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupAccount} /sign={AliceAccount}");
            ContainerArchiveVerify = testCLIAlice1.Example($"container verify {TestContainerArchiveEnhance}");
            ContainerArchiveExtractAll = testCLIAlice1.Example($"container extract {TestContainer} {TestDir2}");
            ContainerArchiveExtractFile = testCLIAlice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ContainerAppend = testCLIAlice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ContainerDelete = testCLIAlice1.Example($"container delete {TestContainer}  {TestFile2}");
            ContainerIndex = testCLIAlice1.Example($"container index {TestContainer}");
            ContainerArchiveCopy = testCLIAlice1.Example($"container copy {TestContainer2}");
            ContainerArchiveCopyDecrypt = testCLIAlice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ContainerArchiveCopyPurge = testCLIAlice1.Example($"container copy {TestContainer2} /purge");

            }
        #endregion
        #region // Mesh commands
        public List<ExampleResult> ProfileMaster;
        public List<ExampleResult> ProfileDevice;
        public List<ExampleResult> ProfileList;
        public List<ExampleResult> ProfileDump;
        public List<ExampleResult> ProfileEscrow;

        public List<ExampleResult> ProfileRecover;
        public List<ExampleResult> ProfileExport;
        public List<ExampleResult> ProfileImport;
        public List<ExampleResult> ProfileHello;
        public List<ExampleResult> ProfileRegister;

        public List<ExampleResult> ProfileSync;

        public void DoCommandsProfile() {
            ProfileHello = testCLIAlice1.Example($"profile hello {AliceAccount}");
            ProfileMaster = testCLIAlice1.Example($"profile create  {AliceAccount}");
            ProfileSync = testCLIAlice1.Example($"profile sync");

            ProfileList = testCLIAlice1.Example($"profile list");
            ProfileDump = testCLIAlice1.Example($"profile get /mesh={AliceAccount}");
            ProfileEscrow = testCLIAlice1.Example($"profile escrow");


            //var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
            //var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];

            //ProfileRecover = testCLIAlice1.Example($"profile recover ${share1} ${share2} /verify");
            ProfileExport = testCLIAlice1.Example($"profile export {TestExport}");
            ProfileImport = testCLIAlice2.Example($"profile import {TestExport}"); // do on another device

            ProfileRegister = testCLIAlice1.Example($"profile register {AliceAccount2}"); // do on another device

            }


        public List<ExampleResult> DeviceRequest;
        public List<ExampleResult> ConnectRequestMallet;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectSync;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectPending3;

        public List<ExampleResult> ConnectEarlPrep;
        public List<ExampleResult> ConnectEarl;
        public List<ExampleResult> ConnectList;
        public List<ExampleResult> ConnectDelete;

        public List<ExampleResult> DeviceCreate;
        public string DeviceCreateUDF;

        public void DoCommandsConnect() {

            DeviceRequest = testCLIAlice2.Example($"device request {AliceAccount}");
            ConnectPending = testCLIAlice1.Example($"device pending");
            

            //var resultPending = (ConnectPending[0].Result as ResultPending);
            //var id1 = resultPending.Messages[0].MessageID;
            //var id2 = resultPending.Messages[1].MessageID;

            //ConnectAccept = testCLIAlice1.Example($"device accept {id1}");
            //ConnectRequestMallet = testCLIMallet1.Example($"device request");
            //ConnectSync = testCLIAlice2.Example($"profile sync");

            //ConnectReject = testCLIAlice1.Example($"device reject {id2}");

            //ConnectList = testCLIAlice1.Example($"device list");
            //ConnectDelete = testCLIAlice1.Example($"device delete {id1}",
            //    $"device list");

            ConnectGetPin = testCLIAlice1.Example($"device pin");
            var pin = "PIN";
            ConnectPin = testCLIAlice2.Example($"device request /pin={pin}");
            ConnectPending3 = testCLIAlice1.Example($"device pending");

            DeviceCreate = testCLIAlice1.Example($"device create /id=\"IoTDevice\"");


            ConnectEarlPrep = testCLIAlice1.Example($"device create /ocr");
            var resultEarl = (ConnectEarlPrep[0].Result as ResultDeviceCreate);
            DeviceCreateUDF = $"udf://{EARLService}/{resultEarl.Key}";

            ConnectEarl = testCLIAlice1.Example($"device earl{DeviceCreateUDF}");
            }


        public string BobPurchase = "Purchase equipment for $6,000?";

        public List<ExampleResult> ContactRequest;
        public List<ExampleResult> ContactPending;
        public List<ExampleResult> ContactAccept;
        public List<ExampleResult> ContactCatalog;
        public List<ExampleResult> ContactGetResponse;
        public List<ExampleResult> ContactReject;
        public List<ExampleResult> ContactBlock;

        public List<ExampleResult> ConfirmRequest;
        public List<ExampleResult> ConfirmPending;
        public List<ExampleResult> ConfirmAccept;
        public List<ExampleResult> ConfirmGetAccept;
        public List<ExampleResult> ConfirmReject;
        public List<ExampleResult> ConfirmGetReject;
        public List<ExampleResult> ConfirmMallet;

        public void DoCommandsMessage() {

            ContactRequest =        testCLIBob1.Example($"message contact {AliceAccount}");
            ContactPending =        testCLIAlice1.Example($"message pending");
            //var resultPending = (ConnectPending[0].Result as ResultPending);
            //var id1 = resultPending.Messages[0].MessageID;
            //var id2 = resultPending.Messages[1].MessageID;

            //ContactAccept =         testCLIAlice1.Example($"message accept {id1}");

            //ContactCatalog =        testCLIAlice1.Example($"contact list");
            //ContactGetResponse =    testCLIBob1.Example($"message status {id1}");
            //ContactReject =         testCLIAlice1.Example($"message reject {id2}");
            //ContactBlock =          testCLIAlice1.Example($"message block {MalletAccount}");

            //ConfirmRequest =        testCLIBob1.Example($"message confirm {AliceAccount} \"{BobPurchase}\"");
            //ConfirmPending =        testCLIAlice1.Example($"message pending");
            //var confirmPending = (ConfirmPending[0].Result as ResultPending);
            //id1 = confirmPending.Messages[0].MessageID;
            //id2 = confirmPending.Messages[1].MessageID;

            //ConfirmAccept =         testCLIAlice1.Example($"message accept {id1}");
            //ConfirmGetAccept =      testCLIBob1.Example($"message status {id1}");
            //ConfirmReject =         testCLIAlice1.Example($"message reject {id2}");
            //ConfirmGetReject =      testCLIBob1.Example($"message status {id2}");
            //ConfirmMallet =         testCLIMallet1.Example($"message confirm {AliceAccount} \"{BobPurchase}\"");
            }

        public List<ExampleResult> ContactAdd;
        public List<ExampleResult> ContactAddSelf;
        public List<ExampleResult> ContactGet;
        public List<ExampleResult> ContactList;
        public List<ExampleResult> ContactList2;
        public List<ExampleResult> ContactDelete;
        public List<ExampleResult> ContactAuth;

        public void DoCommandsContact() {
            ContactAdd = testCLIAlice1.Example($"contact add {CarolContactFile}");
            ContactAddSelf = testCLIAlice1.Example($"contact add {AliceContactFile}");
            ContactGet = testCLIAlice1.Example($"contact get {CarolAccount}");
            ContactList = testCLIAlice1.Example($"contact list");
            ContactDelete = testCLIAlice1.Example($"contact delete {CarolAccount}");
            ContactAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /contact");
            ContactList2 = testCLIAlice2.Example($"contact list");
            }

        public List<ExampleResult> GroupCreate;
        public List<ExampleResult> GroupDecryptAlice;
        public List<ExampleResult> GroupAdd;
        public List<ExampleResult> GroupDecryptBob2;
        public List<ExampleResult> GroupList1;
        public List<ExampleResult> GroupDelete;
        public List<ExampleResult> GroupDecryptBob3;
        public List<ExampleResult> GroupList2;

        public void DoCommandsGroup() {
            GroupCreate =           testCLIAlice1.Example($"group create {GroupAccount}");
            GroupEncrypt = testCLIBob1.Example(
                        $"dare encode{TestFile1} /out={TestFile1Group} /encrypt={GroupAccount}",
                        $"dare decode  {TestFile1Group}");
            GroupDecryptAlice =     testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupAdd =              testCLIAlice1.Example($"group add {GroupAccount} {BobAccount}");
            GroupDecryptBob2 =      testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupList1 =            testCLIAlice1.Example($"group list {GroupAccount}");
            GroupDelete =           testCLIAlice1.Example($"group delete {GroupAccount} {BobAccount}");
            GroupDecryptBob3 =      testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupList2 =            testCLIAlice1.Example($"group list {GroupAccount}");

            }
        #endregion
        #region // Application commands

        public List<ExampleResult> PasswordAdd;
        public List<ExampleResult> PasswordGet;
        public List<ExampleResult> PasswordList;
        public List<ExampleResult> PasswordUpdate;
        public List<ExampleResult> PasswordDelete;
        public List<ExampleResult> PasswordAuth;

        public string PasswordAccount1 = "alice1";
        public string PasswordValue1 = "password";
        public string PasswordValue1a = "newpassword";
        public string PasswordSite = "ftp.example.com";
        public string PasswordAccount2 = "alice@example.com";
        public string PasswordValue2 = "newpassword";
        public string PasswordSite2 = "www.example.com";
        public void DoCommandsPassword() {
            PasswordAdd = testCLIAlice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
                $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}");
            PasswordGet = testCLIAlice1.Example($"password get {PasswordSite}");
            PasswordList = testCLIAlice1.Example($"password list");
            PasswordUpdate = testCLIAlice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1a}");
            PasswordDelete = testCLIAlice1.Example($"password delete {PasswordSite2}");
            PasswordAuth = testCLIAlice1.Example($"device auth /password {AliceDevice2}");
            }

        public List<ExampleResult> BookmarkAdd;
        public List<ExampleResult> BookmarkGet;
        public List<ExampleResult> BookmarkList;
        public List<ExampleResult> BookmarkDelete;
        public List<ExampleResult> BookmarkAuth;
        public List<ExampleResult> BookmarkList2;

        public string BookmarkPath1 = "Folder1/1";
        public string BookmarkURI1 = "http://example.com/";
        public string BookmarkTitle1 = "Example Dot Com";

        public string BookmarkPath2 = "Folder1/2";
        public string BookmarkURI2 = "http://example.net/Bananas";
        public string BookmarkTitle2 = "Banana Site";

        public string BookmarkPath3 = "Folder1/1a";
        public string BookmarkURI3 = "http://example.com/Fred";
        public string BookmarkTitle3 = "The Fred Space";

        public void DoCommandsBookmark() {
            BookmarkAdd = testCLIAlice1.Example($"bookmark add {BookmarkPath1} {BookmarkURI1} \"{BookmarkTitle1}\"",
                $"bookmark add {BookmarkPath2} {BookmarkURI2} \"{BookmarkTitle2}\"",
                $"bookmark add {BookmarkPath3} {BookmarkURI3} \"{BookmarkTitle3}\"");
            BookmarkGet = testCLIAlice1.Example($"bookmark get {BookmarkPath2}");
            BookmarkList = testCLIAlice1.Example($"bookmark list");
            BookmarkDelete = testCLIAlice1.Example($"bookmark delete BookmarkPath2");
            BookmarkAuth = testCLIAlice1.Example($"device auth /bookmark {AliceDevice2}");
            BookmarkList2 = testCLIAlice2.Example($"bookmark list");
            }

        public List<ExampleResult> CalendarAdd;
        public List<ExampleResult> CalendarGet;
        public List<ExampleResult> CalendarList;
        public List<ExampleResult> CalendarDelete;
        public List<ExampleResult> CalendarAuth;


        public string CalendarFile1 = "CalendarEntry1.json";
        public string CalendarFile2 = "CalendarEntry2.json";
        public string CalendarID1 = "CalID1";
        public string CalendarID2 = "CalID2";

        public void DoCommandsCalendar() {
            CalendarAdd = testCLIAlice1.Example($"calendar add {CalendarFile1} {CalendarID1}",
                $"calendar add {CalendarFile2} {CalendarID2}");
            CalendarGet = testCLIAlice1.Example($"calendar get {CalendarID1}");
            CalendarList = testCLIAlice1.Example($"calendar list");
            
            CalendarDelete = testCLIAlice1.Example($"calendar delete {CalendarID1}",
                $"calendar list");
            CalendarAuth = testCLIAlice1.Example($"device auth /calendar {AliceDevice2}");
            }

        public List<ExampleResult> NetworkAdd;
        public List<ExampleResult> NetworkGet;
        public List<ExampleResult> NetworkList;
        
        public List<ExampleResult> NetworkDelete;
        public List<ExampleResult> NetworkAuth;

        public string NetworkFile1 = "NetworkEntry1.json";
        public string NetworkFile2 = "NetworkEntry2.json";
        public string NetworkID1 = "NetID1";
        public string NetworkID2 = "NetID2";

        public void DoCommandsNetwork() {
            NetworkAdd = testCLIAlice1.Example($"network add {NetworkFile1} {NetworkID1}",
                $"network add {NetworkFile2} {NetworkID2}");
            NetworkGet = testCLIAlice1.Example($"network get {NetworkID2}");
            NetworkList = testCLIAlice1.Example($"network list");
            
            NetworkDelete = testCLIAlice1.Example($"network delete {NetworkID2}",
                $"network list");
            NetworkAuth = testCLIAlice1.Example($"device auth /network {AliceDevice2}");
            }

        public List<ExampleResult> SSHCreate;
        public List<ExampleResult> SSHPrivate;
        public List<ExampleResult> SSHPublic;
        public List<ExampleResult> SSHMergeClients;
        public List<ExampleResult> SSHMergeHosts;
        public List<ExampleResult> SSHAddClient;
        public List<ExampleResult> SSHShowClient;
        public List<ExampleResult> SSHAddHost;
        public List<ExampleResult> SSHShowKnown;
        public List<ExampleResult> SSHAuthDev;
        public List<ExampleResult> SSHAuthProof;

        public string SSHFilePublic = "ssh-key.public";
        public string SSHFilePrivate = "ssh-key.public";
        public string SSHFileKnownHosts = "ssh-key.public";
        public string SSHFileAuthKeys = "ssh-key.public";

        public void DoCommandsSSH() {
            SSHCreate = testCLIAlice1.Example($"ssh create");
            SSHPrivate = testCLIAlice1.Example($"ssh private {SSHFilePrivate}");
            SSHPublic = testCLIAlice1.Example($"ssh public {SSHFilePublic}");
            SSHMergeClients = testCLIAlice1.Example($"ssh merge client");
            SSHMergeHosts = testCLIAlice1.Example($"ssh merge host");
            SSHAddClient = testCLIAlice1.Example($"ssh add client");
            SSHShowClient = testCLIAlice1.Example($"ssh show client");
            SSHAddHost = testCLIAlice1.Example($"ssh add host");
            SSHShowKnown = testCLIAlice1.Example($"ssh show host");

            SSHAuthDev = testCLIAlice1.Example($"device auth /ssh {AliceDevice2}");
            SSHAuthProof = testCLIAlice1.Example($"ssh show host");
            }




        public List<ExampleResult> MailAdd;
        public List<ExampleResult> MailAddExplicit;
        public List<ExampleResult> MailUpdate;

        public List<ExampleResult> MailUpdateOpenPGP;
        public List<ExampleResult> MailOpenPGPPrivate;
        public List<ExampleResult> MailOpenPGPPublic;

        public List<ExampleResult> MailUpdateSMIME;
        public List<ExampleResult> MailSMIMECA;
        public List<ExampleResult> MailSMIMEPrivate;
        public List<ExampleResult> MailSMIMEPublic;
        public List<ExampleResult> MailSMIMEPrivate2;

        public List<ExampleResult> MailAuth;
        public string SMIMECA = "ca.example.net";
        public string MailPGPPublicKey = "pgp.public";
        public string MailPGPPrivateKey = "pgp.private";
        public string MailSMIMEPublicKey = "smime.public";
        public string MailSMIMEPrivateKey = "smime.private";

        public void DoCommandsMail() {
            MailAdd = testCLIAlice1.Example($"mail add {AliceAccount}");
            MailAddExplicit = testCLIAlice1.Example($"mail add {AliceAccount2} /inbound={AliceAccount2Inbound} /outbound={AliceAccount2Outbound}");
            MailUpdate = testCLIAlice1.Example($"mail update {AliceAccount2}");

            MailUpdateOpenPGP = testCLIAlice1.Example($"mail update  {AliceAccount} /openpgp");
            MailOpenPGPPrivate = testCLIAlice1.Example($"mail openpgp private {AliceAccount} {MailPGPPrivateKey}");
            MailOpenPGPPublic = testCLIAlice1.Example($"mail openpgp public {AliceAccount} {MailPGPPublicKey}");

            MailUpdateSMIME = testCLIAlice1.Example($"mail {AliceAccount} /smime");
            MailSMIMECA = testCLIAlice1.Example($"mail {AliceAccount} /ca={SMIMECA}");
            MailSMIMEPrivate = testCLIAlice1.Example($"mail smime private {AliceAccount} {MailSMIMEPrivateKey}");
            MailSMIMEPublic = testCLIAlice1.Example($"mail smime public {AliceAccount} {MailSMIMEPublicKey}");

            MailAuth = testCLIAlice1.Example($"device auth /mail {AliceDevice2}");
            MailSMIMEPrivate2 = testCLIAlice2.Example($"mail smime private {AliceAccount} {MailSMIMEPrivateKey}");
            }




        #endregion
        }
    }
