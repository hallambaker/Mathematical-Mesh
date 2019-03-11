using System;
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

        public string TestFile1 = "TestFile1.txt";
        public string TestText1 = "This is a test";

        public CreateWeb() {



            testCLI = GetTestCLI();

            TestFile1.WriteFileNew(TestText1.ToString());

            DoKeyCommands();
            DoHashCommands();

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





        public void DoKeyCommands () {
            KeyNonce = testCLI.Example("key nonce");
            KeyNonce256 = testCLI.Example("key nonce /bits=256");
            KeySecret = testCLI.Example("key secret");
            KeySecret256 = testCLI.Example("key secret /bits=256");
            KeyEarl = testCLI.Example("key earl");
            KeyShare = testCLI.Example("key share");
            var secret1 = (KeyShare[0].Result as ResultKey).Key;
            var share1 = (KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (KeyShare[0].Result as ResultKey).Shares[2];

            KeyRecover = testCLI.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLI.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLI.Example($"key share {secret1}");

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

        public void DoHashCommands() {
            HashUDF2        = testCLI.Example($"hash udf {TestFile1}");
            var expect2 = (HashUDF2[0].Result as ResultDigest).Digest;
            HashUDF3        = testCLI.Example($"hash udf {TestFile1} /alg=sha3 /cty=application/binary");
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

        public List<ExampleResult> DareEarl;

        public void DoDareCommands() {
            }

        public void DoContainerCommands() {
            }

        


        }
    }
