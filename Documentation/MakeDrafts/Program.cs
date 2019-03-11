using System.IO;
using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Test.Core;
using Goedel.Protocol.Debug;
using Goedel.Test;
using Goedel.Cryptography;
using System.Numerics;

// ToDo: Fix the text generator to handle sub/superscripts correctly
// ToDo: Alternative presentation of diagrams in text form
// ToDo: Include schema file as verbatim text
// ToDo: Sort out forward/backwards references
// ToDo: Create a hosted converter working from zip files


namespace ExampleGenerator {
    public partial class CreateExamples {


        string LogPortal = "Portal.jlog";
        string LogMesh = "Mesh.jlog";
        public bool All = false;

        static void Main(string[] args) {
            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize(); // initialize the cryptographic support libraries.

            var Program = new CreateExamples();
            Program.Go();
            }

        public TraceDictionary Traces;

        string OutputPath;
        public void Go () {
            OutputPath = Directory.GetCurrentDirectory();
            TestEnvironment = new TestEnvironmentCommon();

            //// Delete data from previous runs
            MakeClean();
            UDFExamples();
            GenerateKeys();
            GoDareMessage();


            //ExampleGenerator.MeshExamplesUDF(this);
            //ExampleGenerator.MeshExamplesUDFCompressed(this);
            //ExampleGenerator.MeshExamplesUDFCommitment(this);
            //GoContainer();
            //GoDareContainer();

            ////JSONReader.Trace = true;
            //GoContainer();
            //GoReference();
            //GoAdvanced();
            ////GoKeyExchange();
            //GoMesh();

            // Make the documentation
            MakeDocs();
            }

        public TestEnvironmentCommon TestEnvironment;
        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }


        public ResultKey ResultUDFNonce;
        public ResultKey ResultUDFSecret;
        public ResultKey ResultUDFEARL;
        public ResultKey ResultUDFShares;

        public ResultDigest ResultDigestSHA2;
        public ResultDigest ResultDigestSHA3;

        public ResultDigest ResultCommitSHA2;
        public ResultDigest ResultCommitSHA3;

        public Secret UDFSplitSecret;
        public Goedel.Cryptography.KeyShare[] UDFSplitShares;
        public BigInteger[] UDFSplitPolynomial;

        public string TestStringValue = "UDF Content Data";

        public void UDFExamples() {
            // ToDo: need to do full cleanup on the key splitting.
            // ToDo: use the new primes
            // ToDo: also new method of compression


            var testCLI = GetTestCLI();
            ResultUDFNonce = testCLI.Dispatch("key nonce") as ResultKey;

            ResultUDFSecret = testCLI.Dispatch("key share /quorum=2 /shares=3") as ResultKey;
            ResultUDFEARL = testCLI.Dispatch("key earl") as ResultKey;

            var filename = TestStringValue.ToFileUnique();
            ResultDigestSHA2 = testCLI.Dispatch($"hash udf {filename} /alg sha2") as ResultDigest;
            ResultDigestSHA3 = testCLI.Dispatch($"hash udf {filename} /alg sha3") as ResultDigest;
            ResultCommitSHA2 = testCLI.Dispatch($"hash commit {filename} /alg sha2 /key {ResultUDFNonce.Key}") as ResultDigest;

            UDFSplitSecret = new Secret(128);
            UDFSplitShares = UDFSplitSecret.Split(5, 3, out UDFSplitPolynomial);


            Directory.SetCurrentDirectory(OutputPath);


            ExampleGenerator.UDFVariousUDF(this);
            ExampleGenerator.UDFNonce(this);
            ExampleGenerator.UDFEncrypt(this);
            ExampleGenerator.UDFShare(this);
            ExampleGenerator.UDFDigest(this);

            ExampleGenerator.UDFAuthenticator(this);
            ExampleGenerator.UDFDigestURI(this);
            ExampleGenerator.UDFDigestLocator(this);
            ExampleGenerator.UDFDigestEARLRAW(this);
            ExampleGenerator.UDFDigestEARLLocator(this);
            ExampleGenerator.UDFDigestEARL(this);
            ExampleGenerator.UDFsin(this);
            ExampleGenerator.UDFURIEBNF(this);
            ExampleGenerator.UDFTableReservedId(this);
            ExampleGenerator.UDFShamirRecovery(this);

            ExampleGenerator.UDFSplit(this);
            ExampleGenerator.UDFDigestLong(this);
            ExampleGenerator.UDFAuthenticatorLong(this);
            ExampleGenerator.UDFDigestResolution(this);
            ExampleGenerator.UDFEncryptedResolution(this);

            }

        public void MakeClean () {
            var Process = System.Diagnostics.Process.Start("CMD.exe", "/C MakeClean");
            Process.WaitForExit();
            }

        public void MakeDocs () {
            var Process = All ? System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs") :
                System.Diagnostics.Process.Start("CMD.exe", "/C MakeDocs");
            Process.WaitForExit();
            }



        }
    }
