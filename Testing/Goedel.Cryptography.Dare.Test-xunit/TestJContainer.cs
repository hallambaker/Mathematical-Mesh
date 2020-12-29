﻿using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Goedel.XUnit {


    public partial class TestContainers {

        public static TestContainers Test() => new TestContainers();

        [Fact]
        public void ContainerTestList0() => TestContainer($"ContainerList", ContainerType.List, 0);
        [Fact]
        public void ContainerTestList1() => TestContainer($"ContainerList", ContainerType.List, 1);


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


            //TestContainer($"ContainerList", ContainerType.List, 0, policy: CryptoParameters);


            // probably failing because the encrypted payload length is being incorrectly calculated.
            TestContainer($"ContainerList", ContainerType.List, 1, policy: policy);
            TestContainer($"ContainerList", ContainerType.List, 10, policy: policy);
            }

        [Fact]
        public void ContainerTestEncryptedItem() {

            var keyCollection = MakeKeyCollection();
            var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
                KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);
            var recipients = new List<string> { encrypt.KeyIdentifier };


            var CryptoParametersEntry = new CryptoParameters(
                keyCollection, recipients: recipients);

            TestContainer($"ContainerList", ContainerType.List, 0, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
            TestContainer($"ContainerList", ContainerType.List, 1, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
            TestContainer($"ContainerList", ContainerType.List, 10, cryptoParametersEntry: CryptoParametersEntry, keyLocate: keyCollection);
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

            TestContainer($"ContainerList", ContainerType.List, 0, policy: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 1, policy: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 10, policy: CryptoParameters);
            }

        [Fact]
        public void ContainerTestList() {
            TestContainer($"ContainerList", ContainerType.List, 0);
            TestContainer($"ContainerList", ContainerType.List, 1);
            TestContainer($"ContainerList", ContainerType.List, 10);
            }

        [Fact]
        public void ContainerTestDigest() {
            TestContainer($"ContainerDigest", ContainerType.Digest, 0);
            TestContainer($"ContainerDigest", ContainerType.Digest, 1);
            TestContainer($"ContainerDigest", ContainerType.Digest, 10);
            }


        [Fact]
        public void ContainerTestChain() {
            TestContainer($"ContainerChain", ContainerType.Chain, 0);
            TestContainer($"ContainerChain", ContainerType.Chain, 1);
            TestContainer($"ContainerChain", ContainerType.Chain, 10);
            }

        [Fact]
        public void ContainerTestTree() {
            TestContainer($"ContainerTree", ContainerType.Tree, 0);
            TestContainer($"ContainerTree", ContainerType.Tree, 1);
            TestContainer($"ContainerTree", ContainerType.Tree, 10);
            }

        [Fact]
        public void ContainerTestTree1() => TestContainer($"ContainerTree", ContainerType.Tree, 1);

        [Fact]
        public void ContainerTestTree10() => TestContainer($"ContainerTree", ContainerType.Tree, 10);

        [Fact]
        public void ContainerTestMerkleTree() {
            TestContainer($"ContainerMerkle", ContainerType.Merkle, 0);
            TestContainer($"ContainerMerkle", ContainerType.Merkle, 1);
            TestContainer($"ContainerMerkle", ContainerType.Merkle, 10);
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

            TestContainer($"Container-List-{FileName}", ContainerType.List, Records, MaxSize, ReOpen, MoveStep,
                policy, CryptoParametersEntry);
            TestContainer($"Container-Digest-{FileName}", ContainerType.Digest, Records, MaxSize, ReOpen, MoveStep,
                policy, CryptoParametersEntry);
            TestContainer($"Container-Chain-{FileName}", ContainerType.Chain, Records, MaxSize, ReOpen, MoveStep,
            policy, CryptoParametersEntry);
            TestContainer($"Container-Tree-{FileName}", ContainerType.Tree, Records, MaxSize, ReOpen, MoveStep,
                policy, CryptoParametersEntry);
            TestContainer($"Container-MerkleTree-{FileName}", ContainerType.Merkle, Records, MaxSize, ReOpen, MoveStep,
                policy, CryptoParametersEntry);
            }

        static void TestContainer(string fileName, ContainerType containerType,
                    int records = 1, int maxSize = 0, int reOpen = 0, int moveStep = 0,
                    DarePolicy policy = null,
                    CryptoParameters cryptoParametersEntry = null,
                    IKeyLocate keyLocate = null) {

            var keyCollection = keyLocate ?? policy?.KeyLocate;
            //var KeyCollection = policy?.KeyLocate ?? CryptoParametersEntry?.KeyLocate;

            reOpen = reOpen == 0 ? records : reOpen;
            maxSize = maxSize == 0 ? records + 1 : maxSize;

            fileName += $"-{records}";

            int Record;

            // Write initial set of records
            using (var XContainer = Sequence.NewContainer(
                            fileName, FileStatus.Overwrite, containerType: containerType,
                            policy)) {
                for (Record = 0; Record < reOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % maxSize));
                    XContainer.Append(Test, cryptoParameters: cryptoParametersEntry);
                    }
                }

            // Write additional records
            while (Record < records) {
                using var XContainer = Sequence.Open(fileName, FileStatus.Append,
                             policy:policy);
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
                XContainer.VerifyContainer();
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

                XContainer.CheckContainer(Headers);
                }

            // Test random access.
            if (moveStep > 0) {
                // Check in forward direction
                using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                            policy: policy)) {
                    for (Record = moveStep; Record < records; Record += moveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(Record);
                        (ContainerDataReader.Header.SequenceInfo.Index == Record).TestTrue(); ;
                        }

                    }

                // Check in backwards direction
                using (var XContainer = Sequence.Open(fileName, FileStatus.Read,
                            policy: policy)) {
                    for (Record = records; Record > 0; Record -= moveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(Record);
                        (ContainerDataReader.Header.SequenceInfo.Index == Record).TestTrue(); ;
                        }
                    }
                }

            }
        }
    }
