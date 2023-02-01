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
using System.Drawing;
using System.IO;
using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Discovery;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;
namespace Goedel.XUnit;





public partial class TestSequences {

    public static TestSequences Test() => new();





    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.Digest)]
    [InlineData(SequenceType.Chain)]
    [InlineData(SequenceType.Tree)]
    [InlineData(SequenceType.Merkle)]
    public void TestBasicMulti(SequenceType sequenceType) {

        //var sequences = new List<SequenceType> {
        //    SequenceType.List, SequenceType.Digest, SequenceType.Chain, SequenceType.Tree, SequenceType.Merkle};
        var basicParams = new List<TestBasicParams> {
            new TestBasicParams (0),
            new TestBasicParams (1), 
            new TestBasicParams (10),
            new TestBasicParams (1000),
            new TestBasicParams (40, 5000, true, 10, 5),
            };

        foreach (var basicParam in basicParams) {

            TestBasic(sequenceType, basicParam.Records, basicParam.Size, basicParam.Randomsize,
                basicParam.RandomChecks, basicParam.AdditionalChunks);
            }
        }





    /// <summary>
    /// Basic testing of the ability to write to the various sequence types and read back.
    /// </summary>
    /// <param name="sequenceType">Exercise all the sequence types</param>
    /// <param name="records">Number of records</param>
    /// <param name="size"></param>
    /// <param name="randomsize"></param>
    /// <param name="randomChecks"></param>

    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.Digest)]
    [InlineData(SequenceType.Chain)]
    [InlineData(SequenceType.Tree)]
    [InlineData(SequenceType.Merkle, 40, 5000, true, 10, 5)]

    public void TestBasic(SequenceType sequenceType,
        int records = 1, int size = 100, bool randomsize = true,
        int randomChecks = 0,
                int additionalChunks = 0) {

        var seed = DeterministicSeed.Create(sequenceType, records, size, randomsize, randomChecks, additionalChunks);
        var context = new TestContext(seed);
        var sequence = new TestSequence(context, sequenceType, records, size, randomsize, additionalChunks);

        sequence.ValidatePayload();

        for (var i = 0; i < randomChecks; i++) {
            var frame = 1+ seed.GetRandomInt(sequence.Records, i, "randomAccess");
            sequence.RandomCheck(frame);
            }

        if (sequence.SequenceType == SequenceType.Chain) {
            sequence.CheckChain();
            }
        if (sequence.SequenceType == SequenceType.Tree) {
            sequence.CheckTree();
            }
        if (sequence.SequenceType == SequenceType.Merkle) {
            sequence.CheckMerkle();
            }

        }

    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.Digest)]
    [InlineData(SequenceType.Chain)]
    [InlineData(SequenceType.Tree)]
    [InlineData(SequenceType.Merkle)]
    public void TestEncrypt(SequenceType sequenceType,
            ModeEnhance encrypt = ModeEnhance.Record, 
            ModeCorruption corruption = ModeCorruption.None, 
            int records = 50,
            int size = 5000,
            bool randomsize = true,
            int randomChecks = 10) {

        var seed = DeterministicSeed.Create(sequenceType, records, size, randomsize,
                    randomChecks, encrypt, corruption);
        var TestContext = new TestContext(seed, encrypt: encrypt);
        var sequence = new TestSequence(TestContext, sequenceType, records, size, randomsize);

        sequence.ValidateCiphertext(); // Check we did encrypt!
        sequence.ValidatePlaintext(); // Check we can decrypt

        if (corruption == ModeCorruption.Data) {
            sequence.CheckDecryptCorruptData(randomChecks);
            }
        if (corruption == ModeCorruption.Key) {
            sequence.CheckDecryptCorruptKey(randomChecks);
            }
        }


    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.Digest)]
    [InlineData(SequenceType.Chain)]
    [InlineData(SequenceType.Tree)]
    [InlineData(SequenceType.Merkle)]
    public void TestSign(SequenceType sequenceType,
        ModeEnhance sign = ModeEnhance.Record,
        ModeCorruption corruption = ModeCorruption.None,
        int records = 50,
        int size = 5000,
        bool randomsize = true,
        int randomChecks = 10) {

        var seed = DeterministicSeed.Create(sequenceType, records, size, randomsize,
                    randomChecks, sign, corruption);
        var TestContext = new TestContext(seed, sign: sign);
        var sequence = new TestSequence(TestContext, sequenceType, records, size, randomsize,
                    checkSignatures: true);

        sequence.ValidateCiphertext(); // Check we did encrypt!
        sequence.ValidatePlaintext(); // Check we can decrypt
        sequence.ValidateSignature(); // Check the signatures


        if (corruption == ModeCorruption.Data) {
            sequence.CheckSignCorruptData(randomChecks);
            }
        if (corruption == ModeCorruption.SignKey) {
            sequence.CheckSignCorruptKey(randomChecks);
            }

        }



    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.Digest)]
    [InlineData(SequenceType.Chain)]
    [InlineData(SequenceType.Tree)]
    [InlineData(SequenceType.Merkle)]
    public void TestSignEncrypt(SequenceType sequenceType,
                ModeEnhance sign = ModeEnhance.Record,
                ModeEnhance encrypt = ModeEnhance.Record,
                ModeCorruption corruption = ModeCorruption.None,
                int records = 50,
                int size = 5000,
                bool randomsize = true,
                int randomChecks = 10) {

        var seed = DeterministicSeed.Create(sequenceType, records, size, randomsize,
                    randomChecks, sign, corruption);
        var TestContext = new TestContext(seed, sign: sign, encrypt: encrypt);
        var sequence = new TestSequence(TestContext, sequenceType, records, size, randomsize,
                    checkSignatures: true);

        sequence.ValidateCiphertext(); // Check we did encrypt!
        sequence.ValidatePlaintext(); // Check we can decrypt


        if (corruption == ModeCorruption.Data) {
            sequence.CheckDecryptCorruptData(randomChecks);
            sequence.CheckSignCorruptData(randomChecks);
            }
        if (corruption == ModeCorruption.Key) {
            sequence.CheckDecryptCorruptKey(randomChecks);
            }
        if (corruption == ModeCorruption.SignKey) {
            sequence.CheckSignCorruptKey(randomChecks);
            }


        }


    [Theory]
    [InlineData(ModeEnhance.Sequence, ModeEnhance.Sequence)]
    [InlineData(ModeEnhance.Sparse, ModeEnhance.Sequence)]
    [InlineData(ModeEnhance.Sequence, ModeEnhance.Sparse)]
    [InlineData(ModeEnhance.Sparse, ModeEnhance.Sparse)]
    public void TestSparse(
                ModeEnhance sign = ModeEnhance.Record,
                ModeEnhance encrypt = ModeEnhance.Record,
                ModeCorruption corruption = ModeCorruption.Data,
                int records = 50,
                int size = 5000,
                bool randomsize = true,
                int randomChecks = 10,
                int additionalChunks = 1) {

        var seed = DeterministicSeed.Create(sign, encrypt, corruption, records, size, randomsize,
                    randomChecks, additionalChunks);
        var TestContext = new TestContext(seed, sign: sign, encrypt: encrypt, corruption: corruption);
        var sequence = new TestSequence(TestContext, SequenceType.Merkle, records, size, randomsize,
            additionalChunks,  checkSignatures: true);

        sequence.ValidateCiphertext(); // Check we did encrypt!
        sequence.ValidatePlaintext(); // Check we can decrypt

        if (corruption == ModeCorruption.Data) {
            sequence.CheckDecryptCorruptData(randomChecks);
            sequence.CheckSignCorruptData(randomChecks);
            }
        if (corruption == ModeCorruption.Key) {
            sequence.CheckDecryptCorruptKey(randomChecks);
            sequence.CheckSignCorruptKey(randomChecks);
            }

        }


    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData(ModeEnhance.Sequence, ModeEnhance.Sequence)]
    [InlineData(ModeEnhance.Sparse, ModeEnhance.Sequence)]
    [InlineData(ModeEnhance.Sequence, ModeEnhance.Sparse)]
    [InlineData(ModeEnhance.Sparse, ModeEnhance.Sparse)]
    public void TestProof(
                ModeEnhance sign = ModeEnhance.Record,
                ModeEnhance encrypt = ModeEnhance.Record,
                ModeCorruption corruption = ModeCorruption.None,
                int records = 50,
                int size = 5000,
                bool randomsize = true,
                int proofChecks = 10,
                int additionalChunks = 1) {

        var seed = DeterministicSeed.Create(sign, encrypt, corruption, records, size, randomsize,
                    proofChecks, additionalChunks);
        var TestContext = new TestContext(seed, sign: sign, encrypt: encrypt);
        var sequence = new TestSequence(TestContext, SequenceType.Merkle, records, size, randomsize,
            additionalChunks, checkSignatures: true);

        sequence.CheckProofs(proofChecks);
        }




    [Fact]
    public void ZContainerTestEncrypted() {

        // cre
        //var testEnvironmentCommon = new TestEnvironmentCommon();
        //var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, "Alice");
        //var contextAccountAlice_1_a = machineAdminAlice.MeshHost.CreateMesh(AccountAlice, "personal");

        // Setup
        var keyCollection = MakeKeyCollection();

        // Generate key(s)
        var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
                KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);

        var recipients = new List<string> { encrypt.KeyIdentifier };

        var policy = new DarePolicy(keyCollection, recipients: recipients);


        //ZTestContainer($"SequenceList", ContainerType.List, 0, policy: CryptoParameters);


        // probably failing because the encrypted payload length is being incorrectly calculated.
        ZTestContainer($"ContainerList", SequenceType.List, 1, policy: policy);
        ZTestContainer($"ContainerList", SequenceType.List, 10, policy: policy);
        }

    [Fact]
    public void ZContainerTestEncryptedItem() {

        var keyCollection = MakeKeyCollection();
        var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
            KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);
        var recipients = new List<string> { encrypt.KeyIdentifier };


        var CryptoParametersEntry = new CryptoParameters(
            keyCollection, recipients: recipients);

        ZTestContainer($"ContainerList", SequenceType.List, 0, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        ZTestContainer($"ContainerList", SequenceType.List, 1, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        ZTestContainer($"ContainerList", SequenceType.List, 10, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        }

    [Fact]
    public void ZContainerTestSigned() {

        // Setup
        var keyCollection = MakeKeyCollection();

        // Generate key(s)
        var sign = KeyPair.Factory(CryptoAlgorithmId.Ed448,
                KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);
        var signers = new List<string> { sign.KeyIdentifier };

        var CryptoParameters = new DarePolicy(
                    keyCollection,
                    signers: signers);

        ZTestContainer($"ContainerList", SequenceType.List, 0, policy: CryptoParameters);
        ZTestContainer($"ContainerList", SequenceType.List, 1, policy: CryptoParameters);
        ZTestContainer($"ContainerList", SequenceType.List, 10, policy: CryptoParameters);
        }

    [Fact]
    public void ZContainerTestList() {
        ZTestContainer($"ContainerList", SequenceType.List, 0);
        ZTestContainer($"ContainerList", SequenceType.List, 1);
        ZTestContainer($"ContainerList", SequenceType.List, 10);
        }

    [Fact]
    public void ZContainerTestDigest() {
        ZTestContainer($"ContainerDigest", SequenceType.Digest, 0);
        ZTestContainer($"ContainerDigest", SequenceType.Digest, 1);
        ZTestContainer($"ContainerDigest", SequenceType.Digest, 10);
        }


    [Fact]
    public void ZContainerTestChain() {
        ZTestContainer($"ContainerChain", SequenceType.Chain, 0);
        ZTestContainer($"ContainerChain", SequenceType.Chain, 1);
        ZTestContainer($"ContainerChain", SequenceType.Chain, 10);
        }

    [Fact]
    public void ZContainerTestTree() {
        ZTestContainer($"ContainerTree", SequenceType.Tree, 0);
        ZTestContainer($"ContainerTree", SequenceType.Tree, 1);
        ZTestContainer($"ContainerTree", SequenceType.Tree, 10);
        }

    [Fact]
    public void ZContainerTestTree1() => ZTestContainer($"ContainerTree", SequenceType.Tree, 1);

    [Fact]
    public void ZContainerTestTree10() => ZTestContainer($"ContainerTree", SequenceType.Tree, 10);

    [Fact]
    public void ZContainerTestMerkleTree() {
        ZTestContainer($"ContainerMerkle", SequenceType.Merkle, 0);
        ZTestContainer($"ContainerMerkle", SequenceType.Merkle, 1);
        ZTestContainer($"ContainerMerkle", SequenceType.Merkle, 10);
        }


    [Fact]
    public void ZContainerTest0() {
        var Records = 0;
        TestContainerMulti($"-{Records}", Records);
        }

    [Fact]
    public void ZContainerTest1() {
        var Records = 1;
        TestContainerMulti($"-{Records}", Records);
        }

    [Fact]
    public void ZContainerTest10() {
        var Records = 10;
        TestContainerMulti($"-{Records}", Records);
        }



    [Fact]
    public void ZContainerTest500() {
        var Records = 100;
        var ReOpen = 13;
        var MoveStep = 27;
        TestContainerMulti($"-{Records}-{ReOpen}-{MoveStep}",
            Records, ReOpen: ReOpen, MoveStep: MoveStep);
        }

    static byte[] MakeConstant(string Text, int Repeat) {

        var Builder = new StringBuilder();
        for (var i = 0; i < Repeat; i++) {
            Builder.Append(Text);
            }

        return Builder.ToString().ToBytes();

        }


    static void TestContainerMulti(string FileName,
        int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0,
        DarePolicy policy = null,
        CryptoParameters CryptoParametersEntry = null) {

        ZTestContainer($"Container-List-{FileName}", SequenceType.List, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        ZTestContainer($"Container-Digest-{FileName}", SequenceType.Digest, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        ZTestContainer($"Container-Chain-{FileName}", SequenceType.Chain, Records, MaxSize, ReOpen, MoveStep,
        policy, CryptoParametersEntry);
        ZTestContainer($"Container-Tree-{FileName}", SequenceType.Tree, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        ZTestContainer($"Container-MerkleTree-{FileName}", SequenceType.Merkle, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        }



    [Theory]
    [InlineData(SequenceType.List, 0)]
    [InlineData(SequenceType.List, 1)]
    [InlineData(SequenceType.List, 50)]
    [InlineData(SequenceType.List, 50, 2000)]
    [InlineData(SequenceType.Digest, 0)]
    [InlineData(SequenceType.Digest, 1)]
    [InlineData(SequenceType.Digest, 50)]
    [InlineData(SequenceType.Digest, 50, 2000)]
    [InlineData(SequenceType.Chain, 50, 2000)]
    [InlineData(SequenceType.Tree, 50, 2000)]
    [InlineData(SequenceType.Merkle, 50, 2000)]
    public void ZTestSequence(SequenceType containerType,
    int records = 1, int maxSize = 0, int reOpen = 0, int moveStep = 0) {

        var filename = DeterministicSeed.GetUnique(containerType, records, maxSize, reOpen, moveStep);
        ZTestContainer(filename, containerType, records, maxSize, reOpen, moveStep);
        }



    [Fact]
    public void ZContainerTestList0() => ZTestContainer($"ContainerList", SequenceType.List, 0);
    [Fact]
    public void ZContainerTestList1() => ZTestContainer($"ContainerList", SequenceType.List, 1);


    static void ZTestContainer(string fileName, SequenceType containerType,
                int records = 1, int maxSize = 0, int reOpen = 0, int moveStep = 0,
                DarePolicy policy = null,
                CryptoParameters cryptoParametersEntry = null,
                IKeyLocate keyLocate = null) {

        var keyCollection = keyLocate ?? policy?.KeyLocation;
        //var KeyCollection = policy?.KeyLocate ?? CryptoParametersEntry?.KeyLocate;

        reOpen = reOpen == 0 ? records : reOpen;
        maxSize = maxSize == 0 ? records + 1 : maxSize;

        fileName += $"-{records}";

        int Record;

        // Write initial set of records
        using (var XContainer = Sequence.NewSequence(
                        fileName, FileStatus.Overwrite, sequenceType: containerType,
                        policy)) {
            for (Record = 0; Record < reOpen; Record++) {
                var Test = MakeConstant("Test ", ((Record + 1) % maxSize));
                XContainer.Append(Test, cryptoParameters: cryptoParametersEntry);
                }
            }

        // Write additional records
        while (Record < records) {
            using var XContainer = Sequence.Open(fileName, FileStatus.Append,
                         policy: policy);
            for (var i = 0; (Record < records) & i < reOpen; i++) {
                var Test = MakeConstant("Test ", ((Record + 1) % maxSize));
                XContainer.Append(Test);
                Record++;
                }
            }

        var Headers = new List<DareHeader>();
        using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                        policy: policy,
                        keyLocate: keyCollection)) {
            XContainer.VerifySequence();
            }

        // Read records 
        using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                        policy: policy,
                        keyLocate: keyCollection)) {

            Record = 0;
            foreach (var ContainerDataReader in XContainer) {
                if (Record > 0) {
                    var Test = MakeConstant("Test ", ((Record) % maxSize));

                    Headers.Add(ContainerDataReader.Header);
                    var FrameData = ContainerDataReader.GetBody(XContainer);

                    (FrameData.IsEqualTo(Test)).TestTrue();
                    }
                }

            XContainer.CheckSequence(Headers);
            }

        // Test random access.
        if (moveStep > 0) {
            // Check in forward direction
            using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                        policy: policy)) {
                for (Record = moveStep; Record < records; Record += moveStep) {
                    var ContainerDataReader = XContainer.Frame(Record);
                    (ContainerDataReader.Header.SequenceInfo.LIndex == Record).TestTrue(); ;
                    }

                }

            // Check in backwards direction
            using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                        policy: policy)) {
                for (Record = records; Record > 0; Record -= moveStep) {
                    var ContainerDataReader = XContainer.Frame(Record);
                    (ContainerDataReader.Header.SequenceInfo.LIndex == Record).TestTrue(); ;
                    }
                }
            }

        }
    }
