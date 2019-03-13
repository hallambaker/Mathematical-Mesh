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


    public class CreateWeb {

        static void Main(string[] args) {
            Console.WriteLine("Make Document Set");
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.
            var createWeb = new CreateWeb();
            }

        TestCLI testCLIAlice1;
        TestCLI testCLIAlice2;
        TestCLI testCLIAlice3;
        TestCLI testCLIMallet1;

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
        public string BobAccount = "bob@example.com";
        public string GroupAccount = "groupies@example.com";

        public CreateWeb() {

            testCLIAlice1 = GetTestCLI("Alice First");
            testCLIAlice2 = GetTestCLI("Alice Second");
            testCLIAlice3 = GetTestCLI("Alice Third");
            testCLIMallet1 = GetTestCLI("Mallet One");

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
            DoCommandsConnect();

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


        public void DoCommandsKey () {
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
            HashUDF2        = testCLIAlice1.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3        = testCLIAlice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
            HashUDF200      = testCLIAlice1.Example($"hash udf {TestFile1} /bits=200");
            HashUDFExpect   = testCLIAlice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            HashDigest      = testCLIAlice1.Example($"hash digest {TestFile1}");
            HashDigests     = testCLIAlice1.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            MAC1            = testCLIAlice1.Example($"hash mac {TestFile1}");
            var key = (MAC1[0].Result as ResultDigest).Key;
            var digest = (MAC1[0].Result as ResultDigest).Digest;

            MAC2            = testCLIAlice1.Example($"hash mac {TestFile1} /key={key}");
            MAC3            = testCLIAlice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
                $"hash mac {TestFile1} /key={key} /expect={expect2}");
            }

        public List<ExampleResult> DarePlaintext;
        public List<ExampleResult> DareSymmetric;
        public List<ExampleResult> DareSub;
        public List<ExampleResult> DareMesh;

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

            DarePlaintext =         testCLIAlice1.Example($"dare encode {TestFile1}");
            DareSymmetric =         testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            DareSub = testCLIAlice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            DareMesh =              testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.mesh.dare" +
                        $"/encrypt={BobAccount} /sign={AliceAccount}");

            DareVerifyDigest =      testCLIAlice1.Example($"dare verify {TestFile1}.dare");
            DareVerifySigned =      testCLIAlice1.Example($"dare verify {TestFile1}.mesh.dare");
            DareVerifySymmetricUnknown =   testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare");
            DareVerifySymmetric = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            DareDecodePlaintext =   testCLIAlice1.Example($"dare decode {TestFile1}.dare");
            DareDecodeSymmetric =   testCLIAlice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            DareDecodePrivate =     testCLIAlice1.Example($"dare decode {TestFile1}.mesh.dare");

            DareEarl =              testCLIAlice1.Example($"dare earl {TestFile1}");
            DareEARLLog =           testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceAccount}",
                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            DareEARLLogNew =        testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");
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
            ContainerCreate =               testCLIAlice1.Example($"container create {TestContainer}");
            ContainerCreateEncrypt =        testCLIAlice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupAccount}");
            ContainerArchive =              testCLIAlice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ContainerArchiveEnhance =       testCLIAlice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupAccount} /sign={AliceAccount}");
            ContainerArchiveVerify =        testCLIAlice1.Example($"container verify {TestContainerArchiveEnhance}");
            ContainerArchiveExtractAll =    testCLIAlice1.Example($"container extract {TestContainer} {TestDir2}");
            ContainerArchiveExtractFile =   testCLIAlice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ContainerAppend =               testCLIAlice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ContainerDelete =               testCLIAlice1.Example($"container delete {TestContainer}  {TestFile2}");
            ContainerIndex =                testCLIAlice1.Example($"container index {TestContainer}");
            ContainerArchiveCopy =          testCLIAlice1.Example($"container copy {TestContainer2}");
            ContainerArchiveCopyDecrypt =   testCLIAlice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ContainerArchiveCopyPurge =     testCLIAlice1.Example($"container copy {TestContainer2} /purge");

            }

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
            ProfileMaster =         testCLIAlice1.Example($"profile create {AliceAccount}");
            ProfileDevice =         testCLIAlice1.Example($"profile device /id=\"IoTDevice\"");
            ProfileList =           testCLIAlice1.Example($"profile list");
            ProfileDump =           testCLIAlice1.Example($"profile dump /mesh={AliceAccount}");
            ProfileEscrow =         testCLIAlice1.Example($"profile escrow");
            var share1 = "s1";
            var share2 = "s2";
            ProfileRecover =        testCLIAlice1.Example($"profile recover ${share1} ${share2}");
            ProfileExport =         testCLIAlice1.Example($"profile export {TestExport}");
            ProfileImport =         testCLIAlice2.Example($"profile import {TestExport}"); // do on another device
            ProfileHello =          testCLIAlice1.Example($"profile hello");
            ProfileRegister =       testCLIAlice1.Example($"profile register {AliceAccount2}"); // do on another device
            ProfileSync =           testCLIAlice1.Example($"profile sync");
            }


        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectRequestMallet;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectSync;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectPending3;

        public void DoCommandsConnect() {

            ConnectRequest =        testCLIAlice2.Example($"connect request");
            ConnectPending =        testCLIAlice1.Example($"connect pending");
            var id1 = "id";
            ConnectAccept =         testCLIAlice1.Example($"connect accept {id1}");
            ConnectPending2 =       testCLIAlice1.Example($"connect pending");
            ConnectSync =           testCLIAlice2.Example($"connect sync");
            ConnectRequestMallet =  testCLIMallet1.Example($"connect request");
            var id2 = "id";
            ConnectReject =         testCLIAlice1.Example($"connect reject {id2}");
            ConnectGetPin =         testCLIAlice1.Example($"connect pin");
            var pin = "PIN";
            ConnectPin =            testCLIAlice1.Example($"connect request /pin={pin}");
            ConnectPending3 =       testCLIAlice1.Example($"connect pending");
            }
        }
    }
