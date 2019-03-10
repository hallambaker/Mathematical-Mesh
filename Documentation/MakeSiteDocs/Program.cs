using System;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.Protocol.Debug;
using Goedel.Test;
using Goedel.Cryptography;
using System.Numerics;

namespace MakeSiteDocs {




    public class CreateWeb {

        static void Main(string[] args) {
            Console.WriteLine("Make Document Set");
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.
            var createWeb = new CreateWeb();
            }

        TestCLI testCLI;

        public CreateWeb() {
            testCLI = GetTestCLI();

            DoKeyCommands();


            var makeSiteDocs = new MakeSiteDocs();
            makeSiteDocs.WebDocs(this);
            }

        public TestEnvironmentCommon TestEnvironment;
        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }

        public ExampleResult KeyNonce;
        public ExampleResult KeyNonce256;
        public ExampleResult KeySecret;
        public ExampleResult KeySecret256;
        public ExampleResult KeyEarl;

        public ExampleResult KeyShare;
        public ExampleResult KeyRecover;
        public ExampleResult KeyShare2;
        public ExampleResult KeyShare3;


        public void DoKeyCommands () {
            KeyNonce = testCLI.Example("key nonce");
            KeyNonce256 = testCLI.Example("key nonce /bits=256");
            KeySecret = testCLI.Example("key secret");
            KeySecret256 = testCLI.Example("key secret /bits=256");
            KeyEarl = testCLI.Example("key earl");
            KeyShare = testCLI.Example("key share");
            var secret1 = (KeyShare.Result as ResultKey).Key;
            var share1 = (KeyShare.Result as ResultKey).Shares[0];
            var share2 = (KeyShare.Result as ResultKey).Shares[2];

            //KeyRecovery = testCLI.Example($"key recover {share1} {share2}");
            KeyShare2 = testCLI.Example($"key share /quorum=3 /shares=5");
            KeyShare3 = testCLI.Example($"key share {secret1}");

            }

        public ExampleResult FileEarl;


        }
    }
