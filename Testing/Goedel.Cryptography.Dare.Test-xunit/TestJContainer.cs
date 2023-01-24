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
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;
namespace Goedel.XUnit;




public enum ModeEnhance {
    
    ///<summary>No signature/encryption</summary> 
    None,

    ///<summary>Signature/Key Agreement at the individual record level. Each record
    ///individually enhanced.</summary> 
    Record,

    ///<summary>Signature/Key Agreement at the sequence level, decrypting or verifying
    ///once authenticates, decrypts entire file.</summary> 
    Sequence,

    ///<summary>Signature/Key Agreement of multiple records but not the entire 
    ///sequence in one operation.</summary> 
    Sparse
    }

public enum Corruption {
    None,

    Data,

    Public,

    Private,

    Signature,

    Order,
    }



public partial class TestContainers {

    public static TestContainers Test() => new();

    [Fact]
    public void ContainerTestList0() => TestContainer($"ContainerList", SequenceType.List, 0);
    [Fact]
    public void ContainerTestList1() => TestContainer($"ContainerList", SequenceType.List, 1);

    [Theory]
    [InlineData(SequenceType.List, 0)]
    [InlineData(SequenceType.List, 1)]
    [InlineData(SequenceType.List, 50)]
    [InlineData(SequenceType.List, 50, 2000)]
    [InlineData(SequenceType.Digest, 0)]
    [InlineData(SequenceType.Digest, 1)]
    [InlineData(SequenceType.Digest, 50)]
    [InlineData(SequenceType.Digest, 50, 2000)]

    public void TestSequence(SequenceType containerType,
        int records = 1, int maxSize = 0, int reOpen = 0, int moveStep = 0) {

        var filename = TestName.Get(containerType, records, maxSize, reOpen, moveStep);
        TestContainer(filename, containerType, records, maxSize, reOpen, moveStep);
        }

    [Theory]
    [InlineData(SequenceType.List)]
    [InlineData(SequenceType.List, 5)]
    [InlineData(SequenceType.List, 100)]
    [InlineData(SequenceType.List, 10,  5000)]
    [InlineData(SequenceType.Digest, 1000)]
    [InlineData(SequenceType.Digest, 10, 5000)]
    [InlineData(SequenceType.Chain, 1000) ]
    [InlineData(SequenceType.Chain, 10,  5000)]

    [InlineData(SequenceType.Tree, 1000)]
    [InlineData(SequenceType.Tree, 10, 5000)]

    [InlineData(SequenceType.Merkle, 1000)]
    [InlineData(SequenceType.Merkle, 10, 5000)]

    //[InlineData(SequenceType.List, 1, false)]
    //[InlineData(SequenceType.List, 5, false)]
    //[InlineData(SequenceType.List, 100, false)]
    //[InlineData(SequenceType.Digest, 1000, false)]
    //[InlineData(SequenceType.List, 10, false, 5000)]
    //[InlineData(SequenceType.Digest, 10, false, 5000)]



    public void TestAppend(SequenceType containerType,
        int records = 1, int size = 100, bool atomic = true) {

        var filename = TestName.Get(containerType, records, atomic, size);
        var entries = new List<SequenceIndexEntry>();

        int i, j = 0;
        //Create container

        //var payload = TestName.GetTestBytes(filename, size, j++);

        using (var sequence = Sequence.NewContainer(filename, FileStatus.Overwrite, containerType)) {
            for (i = 0; i < records; i++) {
                var header = new DareHeader() {
                    };

                var payload = TestName.GetTestBytes(filename, size, i);
                var entry = sequence.Append(payload);

                //if (atomic) {
                //    var entry = sequence.Append(payload);
                //    entries.Add(entry);
                //    }
                //else {
                //    var entry = sequence.Append(payload);

                //    entries.Add(entry);
                //    }
                }
            }



        using (var stream = filename.OpenFileRead()) {
            foreach (var entry in entries) {
                var payload = TestName.GetTestBytes(filename, size, j++);
                Validate(stream, entry, payload);
                }
            }

        //(i == j).TestTrue();


        if (containerType == SequenceType.Chain) {
            CheckChain(entries);
            }

        }


    static void Validate(FileStream stream, SequenceIndexEntry entry, byte[] data) {

        // check frame boundaries
        (entry.FramePosition < entry.DataPosition).TestTrue();
        (entry.FrameLength > entry.DataLength).TestTrue();

        // check data boundaries
        (entry.DataLength == data.Length).TestTrue();

        // check data segment
        stream.Position = entry.DataPosition;
        for (var i = 0; i < entry.DataLength; i++) {
            var b = stream.ReadByte();
            (data[i] == b).TestTrue();
            }

        // No, cannot use a switch here.
        if (entry.Sequence.GetType() == typeof(SequenceChain) |
            entry.Sequence.GetType() == typeof(SequenceDigest) |
            entry.Sequence.GetType() == typeof(SequenceMerkleTree)) {
            ValidateDigest(entry, data);
            }
        }

    static void ValidateDigest(SequenceIndexEntry entry, byte[] data) {
        var payloadDigest = entry.PayloadDigest;
        payloadDigest.TestNotNull();


        var digestAlgorithm = entry.Header.DigestAlgorithm;
        var digestAlgorithmId = digestAlgorithm.FromJoseIDDigest();

        var hashAlgorithm = digestAlgorithmId.CreateDigest();


        var digest = hashAlgorithm.ComputeHash(data);

        digest.TestEqual(payloadDigest);

        }

    static void CheckChain(List<SequenceIndexEntry> entries) {
        if (entries.Count == 0) {
            return;
            }

        byte[] lastDigest = null;

        var digestAlgorithm = entries[0].Header.DigestAlgorithm;
        var digestAlgorithmId = digestAlgorithm.FromJoseIDDigest();
        var hashAlgorithm = digestAlgorithmId.CreateDigest();

        foreach (var entry in entries) {
            var payloadDigest = entry.PayloadDigest;
            var chainDigest = entry.ChainDigest;
            chainDigest.TestNotNull();

            var buffer = Add(hashAlgorithm.HashSize,lastDigest, payloadDigest);
            var digest = hashAlgorithm.ComputeHash(buffer);

            digest.TestEqual(chainDigest);
            }
        }


    static byte[] Add(int size, byte[] first, byte[] second) {
        var length = size / 8;

        var result = new byte[length *2];

        if (first is not null) {
            (first.Length == length).TestTrue();
            Array.Copy(first, result, length);
            }
        if (second is not null) {
            (second.Length == length).TestTrue();
            Array.Copy(second, 0, result, length, length);
            }

        return result;
        }


    [Fact]
    public void ContainerTestEncrypted() {

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


        //TestContainer($"SequenceList", ContainerType.List, 0, policy: CryptoParameters);


        // probably failing because the encrypted payload length is being incorrectly calculated.
        TestContainer($"ContainerList", SequenceType.List, 1, policy: policy);
        TestContainer($"ContainerList", SequenceType.List, 10, policy: policy);
        }

    [Fact]
    public void ContainerTestEncryptedItem() {

        var keyCollection = MakeKeyCollection();
        var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
            KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);
        var recipients = new List<string> { encrypt.KeyIdentifier };


        var CryptoParametersEntry = new CryptoParameters(
            keyCollection, recipients: recipients);

        TestContainer($"ContainerList", SequenceType.List, 0, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        TestContainer($"ContainerList", SequenceType.List, 1, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        TestContainer($"ContainerList", SequenceType.List, 10, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
        }

    [Fact]
    public void ContainerTestSigned() {

        // Setup
        var keyCollection = MakeKeyCollection();

        // Generate key(s)
        var sign = KeyPair.Factory(CryptoAlgorithmId.Ed448,
                KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);
        var signers = new List<string> { sign.KeyIdentifier };

        var CryptoParameters = new DarePolicy(
                    keyCollection,
                    signers: signers);

        TestContainer($"ContainerList", SequenceType.List, 0, policy: CryptoParameters);
        TestContainer($"ContainerList", SequenceType.List, 1, policy: CryptoParameters);
        TestContainer($"ContainerList", SequenceType.List, 10, policy: CryptoParameters);
        }

    [Fact]
    public void ContainerTestList() {
        TestContainer($"ContainerList", SequenceType.List, 0);
        TestContainer($"ContainerList", SequenceType.List, 1);
        TestContainer($"ContainerList", SequenceType.List, 10);
        }

    [Fact]
    public void ContainerTestDigest() {
        TestContainer($"ContainerDigest", SequenceType.Digest, 0);
        TestContainer($"ContainerDigest", SequenceType.Digest, 1);
        TestContainer($"ContainerDigest", SequenceType.Digest, 10);
        }


    [Fact]
    public void ContainerTestChain() {
        TestContainer($"ContainerChain", SequenceType.Chain, 0);
        TestContainer($"ContainerChain", SequenceType.Chain, 1);
        TestContainer($"ContainerChain", SequenceType.Chain, 10);
        }

    [Fact]
    public void ContainerTestTree() {
        TestContainer($"ContainerTree", SequenceType.Tree, 0);
        TestContainer($"ContainerTree", SequenceType.Tree, 1);
        TestContainer($"ContainerTree", SequenceType.Tree, 10);
        }

    [Fact]
    public void ContainerTestTree1() => TestContainer($"ContainerTree", SequenceType.Tree, 1);

    [Fact]
    public void ContainerTestTree10() => TestContainer($"ContainerTree", SequenceType.Tree, 10);

    [Fact]
    public void ContainerTestMerkleTree() {
        TestContainer($"ContainerMerkle", SequenceType.Merkle, 0);
        TestContainer($"ContainerMerkle", SequenceType.Merkle, 1);
        TestContainer($"ContainerMerkle", SequenceType.Merkle, 10);
        }


    [Fact]
    public void ContainerTest0() {
        var Records = 0;
        TestContainerMulti($"-{Records}", Records);
        }

    [Fact]
    public void ContainerTest1() {
        var Records = 1;
        TestContainerMulti($"-{Records}", Records);
        }

    [Fact]
    public void ContainerTest10() {
        var Records = 10;
        TestContainerMulti($"-{Records}", Records);
        }



    [Fact]
    public void ContainerTest500() {
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

        TestContainer($"Container-List-{FileName}", SequenceType.List, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        TestContainer($"Container-Digest-{FileName}", SequenceType.Digest, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        TestContainer($"Container-Chain-{FileName}", SequenceType.Chain, Records, MaxSize, ReOpen, MoveStep,
        policy, CryptoParametersEntry);
        TestContainer($"Container-Tree-{FileName}", SequenceType.Tree, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        TestContainer($"Container-MerkleTree-{FileName}", SequenceType.Merkle, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
        }






    public static void TestContainer(string fileName, SequenceType containerType,
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
        using (var XContainer = Sequence.NewContainer(
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
