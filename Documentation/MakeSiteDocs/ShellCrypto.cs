using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExampleGenerator {

    public class ShellKey {
        public List<ExampleResult> KeyNonce;
        public List<ExampleResult> KeyNonce256;
        public List<ExampleResult> KeySecret;
        public List<ExampleResult> KeySecret256;
        public List<ExampleResult> KeyEarl;

        public List<ExampleResult> KeyShare;
        public List<ExampleResult> KeyRecover;
        public List<ExampleResult> KeyShare2;
        public List<ExampleResult> KeyShare3;
        }

    public class ShellHash {
        public List<ExampleResult> HashUDF2;
        public List<ExampleResult> HashUDF3;
        public List<ExampleResult> HashUDF200; // Wrong precision, implement /bits
        public List<ExampleResult> HashUDFExpect; // implement /expect
        public List<ExampleResult> HashDigest;
        public List<ExampleResult> HashDigests;
        public List<ExampleResult> MAC1;  // return the key
        public List<ExampleResult> MAC2;  // implement key option
        public List<ExampleResult> MAC3;  // implement expect option
        }

    public class ShellDare {
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
        }

    public class ShellSequence {
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
        }

    public partial class CreateExamples {
        #region // Tests - shell

        ShellKey ShellKey = new ShellKey();
        ShellHash ShellHash = new ShellHash();
        ShellDare ShellDare = new ShellDare();
        ShellSequence ShellSequence = new ShellSequence();

        public string Secret1;


        public void DoCommandsKey() {
            ShellKey.KeyNonce = testCLIAlice1.Example("key nonce");
            ShellKey.KeyNonce256 = testCLIAlice1.Example("key nonce /bits=256");
            ShellKey.KeySecret = testCLIAlice1.Example("key secret");
            ShellKey.KeySecret256 = testCLIAlice1.Example("key secret /bits=256");
            ShellKey.KeyEarl = testCLIAlice1.Example("key earl");
            ShellKey.KeyShare = testCLIAlice1.Example("key share");
            Secret1 = (ShellKey.KeyShare[0].Result as ResultKey).Key;
            var share1 = (ShellKey.KeyShare[0].Result as ResultKey).Shares[0];
            var share2 = (ShellKey.KeyShare[0].Result as ResultKey).Shares[2];

            ShellKey.KeyRecover = testCLIAlice1.Example($"key recover {share1} {share2}");
            ShellKey.KeyShare2 = testCLIAlice1.Example($"key share /quorum=3 /shares=5");
            ShellKey.KeyShare3 = testCLIAlice1.Example($"key share {Secret1}");

            }

        public void DoCommandsHash() {
            ShellHash.HashUDF2 = testCLIAlice1.Example($"hash udf {TestFile1}");
            var expect2 = (ShellHash.HashUDF2[0].Result as ResultDigest).Digest;
            ShellHash.HashUDF3 = testCLIAlice1.Example($"hash udf {TestFile1} /cty=application/binary",
                                              $"hash udf {TestFile1} /alg=sha3");
            var expect3 = (ShellHash.HashUDF3[0].Result as ResultDigest).Digest;
            ShellHash.HashUDF200 = testCLIAlice1.Example($"hash udf {TestFile1} /bits=200");
            ShellHash.HashUDFExpect = testCLIAlice1.Example($"hash udf {TestFile1} /expect={expect2}",
                                              $"hash udf {TestFile1} /expect={expect3}");
            ShellHash.HashDigest = testCLIAlice1.Example($"hash digest {TestFile1}");
            ShellHash.HashDigests = testCLIAlice1.Example($"hash digest {TestFile1} /alg=sha256",
                                              // $"hash digest {TestFile1} /alg=sha128",
                                              $"hash digest {TestFile1} /alg=sha3256",
                                              $"hash digest {TestFile1} /alg=sha3");
            ShellHash.MAC1 = testCLIAlice1.Example($"hash mac {TestFile1}");
            var key = (ShellHash.MAC1[0].Result as ResultDigest).Key;
            var digest = (ShellHash.MAC1[0].Result as ResultDigest).Digest;

            ShellHash.MAC2 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key}");
            ShellHash.MAC3 = testCLIAlice1.Example($"hash mac {TestFile1} /key={key} /expect={digest}",
                $"hash mac {TestFile1} /key={key} /expect={expect2}");
            }

        public void DoCommandsDare() {

            ShellDare.DarePlaintext = testCLIAlice1.Example($"dare encode {TestFile1}");
            ShellDare.DareSymmetric = testCLIAlice1.Example($"dare encode {TestFile1} /out={TestFile1}.symmetric.dare " +
                        $"/key={Secret1}");
            ShellDare.DareSub = testCLIAlice1.Example($"dare encode {TestDir1} /encrypt={Secret1}");
            ShellDare.DareMesh = testCLIAlice1.Example($"dare encode {TestFile1} {TestFile1}.mesh.dare" +
                        $"/encrypt={BobService} /sign={AliceService1}");

            ShellDare.DareVerifyDigest = testCLIAlice1.Example($"dare verify {TestFile1}.dare");
            ShellDare.DareVerifySigned = testCLIAlice1.Example($"dare verify {TestFile1}.mesh.dare");
            ShellDare.DareVerifySymmetricUnknown = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare");
            ShellDare.DareVerifySymmetric = testCLIAlice1.Example($"dare verify {TestFile1}.symmetric.dare /encrypt={Secret1}");

            ShellDare.DareDecodePlaintext = testCLIAlice1.Example($"dare decode {TestFile1}.dare");
            ShellDare.DareDecodeSymmetric = testCLIAlice1.Example($"dare decode {TestFile1}.symmetric.dare /encrypt={Secret1}");
            ShellDare.DareDecodePrivate = testCLIAlice1.Example($"dare decode {TestFile1}.mesh.dare");

            //            DareEarl = testCLIAlice1.Example($"dare earl {TestFile1} {EARLDomain}");
            //            DareEARLLog = testCLIAlice1.Example($"dare container create {DareLogEarl} /encrypt={AliceService1}",
            //                                                    $"dare earl {TestFile1} /log={DareLogEarl}");
            //            DareEARLLogNew = testCLIAlice1.Example($"dare earl {TestFile1} /new={DareLogEarl}");
            }



        public void DoCommandsContainer() {
            ShellSequence.ContainerCreate = testCLIAlice1.Example($"container create {TestContainer}");
            ShellSequence.ContainerCreateEncrypt = testCLIAlice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupService}");
            ShellSequence.ContainerArchive = testCLIAlice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ShellSequence.ContainerArchiveEnhance = testCLIAlice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupService} /sign={AliceService1}");
            ShellSequence.ContainerArchiveVerify = testCLIAlice1.Example($"container verify {TestContainerArchiveEnhance}");
            ShellSequence.ContainerArchiveExtractAll = testCLIAlice1.Example($"container extract {TestContainer} {TestDir2}");
            ShellSequence.ContainerArchiveExtractFile = testCLIAlice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ShellSequence.ContainerAppend = testCLIAlice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ShellSequence.ContainerDelete = testCLIAlice1.Example($"container delete {TestContainer}  {TestFile2}");
            ShellSequence.ContainerIndex = testCLIAlice1.Example($"container index {TestContainer}");
            ShellSequence.ContainerArchiveCopy = testCLIAlice1.Example($"container copy {TestContainer2}");
            ShellSequence.ContainerArchiveCopyDecrypt = testCLIAlice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ShellSequence.ContainerArchiveCopyPurge = testCLIAlice1.Example($"container copy {TestContainer2} /purge");

            }

        #endregion
        }
    }
