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

        TestCLI testCLI;

        public string TestDir1 = "TestDir1";

        public string TestFile1 = "TestFile1.txt";
        public string TestFile2 => Path.Combine(TestDir1, "TestFile2.txt");
        public string TestFile3 => Path.Combine(TestDir1, "TestFile3.txt");
        public string TestText1 = "This is a test";
        public string TestText2 = "This is a test 2";
        public string TestText3 = "This is a test 3";

        public string DareLogEarl = "EarlLog.dlog";

        public string AliceAccount = "alice@example.com";
        public string BobAccount = "bob@example.com";
        public string GroupAccount = "groupies@example.com";

        public CreateWeb() {

            testCLI = GetTestCLI();

            Directory.CreateDirectory(TestDir1);
            TestFile1.WriteFileNew(TestText1.ToString());
            TestFile2.WriteFileNew(TestText2.ToString());
            TestFile3.WriteFileNew(TestText3.ToString());

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
            KeyNonce = testCLI.Example("key nonce");
            KeyNonce256 = testCLI.Example("key nonce /bits=256");
            KeySecret = testCLI.Example("key secret");
            KeySecret256 = testCLI.Example("key secret /bits=256");
            KeyEarl = testCLI.Example("key earl");
            KeyShare = testCLI.Example("key share");
            Secret1 = (KeyShare[0].Result as ResultKey).Key;
            var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

            KeyRecover = testCLI.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLI.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLI.Example($"key share {Secret1}");

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
            HashUDF2        = testCLI.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3        = testCLI.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (HashUDF3[0].Result as ResultDigest).Digest;
            HashUDF200      = testCLI.Example($"hash udf {TestFile1} /bits=200");
            HashUDFExpect   = testCLI.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            HashDigest      = testCLI.Example($"hash digest {TestFile1}");
            HashDigests     = testCLI.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            MAC1            = testCLI.Example($"hash mac {TestFile1}");
            var key = (MAC1[0].Result as ResultDigest).Key;
            var digest = (MAC1[0].Result as ResultDigest).Digest;

            MAC2            = testCLI.Example($"hash mac {TestFile1} /key={key}");
            MAC3            = testCLI.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
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

            DarePlaintext =         testCLI.Example($"dare encode {TestFile1}");
            DareSymmetric =         testCLI.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            DareSub = testCLI.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            DareMesh =              testCLI.Example($"dare encode {TestFile1} /out={TestFile1}.mesh.dare" +
                        $"/encrypt={BobAccount} /sign={AliceAccount}");

            DareVerifyDigest =      testCLI.Example($"dare verify {TestFile1}.dare");
            DareVerifySigned =      testCLI.Example($"dare verify {TestFile1}.mesh.dare");
            DareVerifySymmetricUnknown =   testCLI.Example($"dare verify {TestFile1}.symmetric.dare");
            DareVerifySymmetric = testCLI.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            DareDecodePlaintext =   testCLI.Example($"dare decode {TestFile1}.dare");
            DareDecodeSymmetric =   testCLI.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            DareDecodePrivate =     testCLI.Example($"dare decode {TestFile1}.mesh.dare");

            DareEarl =              testCLI.Example($"dare earl {TestFile1}");
            DareEARLLog =           testCLI.Example($"dare container create {DareLogEarl} /encrypt={AliceAccount}",
                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            DareEARLLogNew =        testCLI.Example($"dare earl {TestFile1} /new={DareLogEarl}");
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
            }


        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectPending3;

        public void DoCommandsConnect() {
            }
        }
    }
