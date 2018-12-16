using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Test.Core;

namespace Goedel.XUnit {


    public partial class TestContainers {

        static List<string> Signers = new List<string> { "Alice@example.com" };
        static List<string> Recipients = new List<string> { "Alice@example.com" };

        public TestContainers() => TestEnvironment.Initialize(true);
        public static TestContainers Test => new TestContainers();

        [Fact]
        public void ContainerTestEncrypted() {
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients);

            TestContainer($"ContainerList", ContainerType.List, 0, CryptoParameters: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 1, CryptoParameters: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 10, CryptoParameters: CryptoParameters);
            }

        [Fact]
        public void ContainerTestEncryptedItem() {
            var CryptoParametersEntry = new CryptoParametersTest(
                        Recipients: Recipients);

            TestContainer($"ContainerList", ContainerType.List, 0, CryptoParametersEntry: CryptoParametersEntry);
            TestContainer($"ContainerList", ContainerType.List, 1, CryptoParametersEntry: CryptoParametersEntry);
            TestContainer($"ContainerList", ContainerType.List, 10, CryptoParametersEntry: CryptoParametersEntry);
            }

        [Fact]
        public void ContainerTestSigned() {
            var CryptoParameters = new CryptoParametersTest(
                        Signers: Signers);

            TestContainer($"ContainerList", ContainerType.List, 0, CryptoParameters: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 1, CryptoParameters: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 10, CryptoParameters: CryptoParameters);
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
        public void ContainerTestMerkleTree() {
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 0);
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 1);
            TestContainer($"ContainerMerkle", ContainerType.MerkleTree, 10);
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
        public void ContainerTestEncryptedMulti() {
            
            var CryptoParameters = new CryptoParametersTest(
                    Recipients: Recipients);

            var Records = 0;
            TestContainerMulti($"-Encrypted-{Records}", Records, CryptoParameters: CryptoParameters);
            Records = 1;
            TestContainerMulti($"-Encrypted-{Records}", Records, CryptoParameters: CryptoParameters);
            Records = 10;
            TestContainerMulti($"-Encrypted-{Records}", Records, CryptoParameters: CryptoParameters);
            }

        [Fact]
        public void ContainerTestEncryptedEntryMulti() {

            var CryptoParameters = new CryptoParametersTest(
                    Recipients: Recipients);

            var Records = 0;
            TestContainerMulti($"-Encrypted-item-{Records}", Records, CryptoParametersEntry: CryptoParameters);
            Records = 1;
            TestContainerMulti($"-Encrypted-item-{Records}", Records, CryptoParametersEntry: CryptoParameters);
            Records = 10;
            TestContainerMulti($"-Encrypted-item-{Records}", Records, CryptoParametersEntry: CryptoParameters);

            }

        [Fact]
        public void ContainerTestEncryptedSignedMulti() {
            var CryptoParameters = new CryptoParametersTest(
                    Recipients: Recipients, Signers: Signers);

            var Records = 0;
            TestContainerMulti($"-Encrypted-Signed-{Records}", Records, CryptoParametersEntry: CryptoParameters);
            Records = 1;
            TestContainerMulti($"-Encrypted-Signed-{Records}", Records, CryptoParametersEntry: CryptoParameters);
            Records = 10;
            TestContainerMulti($"-Encrypted-Signed-{Records}", Records, CryptoParametersEntry: CryptoParameters);
            }


        [Fact]
        public void ContainerTest500() {
            var Records = 100;
            var ReOpen = 13;
            var MoveStep = 27;
            TestContainerMulti ($"-{Records}-{ReOpen}-{MoveStep}",
                Records, ReOpen: ReOpen, MoveStep: MoveStep);
            }


        byte[] MakeConstant(string Text, int Repeat) {

            var Builder = new StringBuilder();
            for (var i = 0; i < Repeat; i++) {
                Builder.Append(Text);
                }

            return Builder.ToString().ToBytes();

            }

        void TestContainerMulti(string FileName,
            int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0,
            CryptoParameters CryptoParameters = null,
            CryptoParameters CryptoParametersEntry = null) {

            TestContainer($"Container-List-{FileName}", ContainerType.List, Records, MaxSize, ReOpen, MoveStep,
                CryptoParameters, CryptoParametersEntry);
            TestContainer($"Container-Digest-{FileName}", ContainerType.Digest, Records, MaxSize, ReOpen, MoveStep,
                CryptoParameters, CryptoParametersEntry);
            TestContainer($"Container-Chain-{FileName}", ContainerType.Chain, Records, MaxSize, ReOpen, MoveStep,
            CryptoParameters, CryptoParametersEntry);
            TestContainer($"Container-Tree-{FileName}", ContainerType.Tree, Records, MaxSize, ReOpen, MoveStep,
                CryptoParameters, CryptoParametersEntry);
            TestContainer($"Container-MerkleTree-{FileName}", ContainerType.MerkleTree, Records, MaxSize, ReOpen, MoveStep,
                CryptoParameters, CryptoParametersEntry);
            }

        void TestContainer(string FileName, ContainerType ContainerType,
                    int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0, 
                    CryptoParameters CryptoParameters = null,
                    CryptoParameters CryptoParametersEntry = null) {
            CryptoParameters = CryptoParameters ?? new CryptoParameters();

            var KeyCollection = CryptoParameters?.KeyCollection ?? CryptoParametersEntry?.KeyCollection;

            ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

            FileName = FileName + $"-{Records}";

            int Record;

            // Write initial set of records
            using (var XContainer = Container.NewContainer(
                            FileName, FileStatus.Overwrite, containerType: ContainerType,
                            cryptoParameters: CryptoParameters)) {
                for (Record = 0; Record < ReOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test, cryptoParameters: CryptoParametersEntry);
                    }
                }

            // Write additional records
            while (Record < Records) {
                using (var XContainer = Container.Open(FileName, FileStatus.Append,
                            cryptoParameters: CryptoParameters)) {
                    for (var i = 0; (Record < Records) & i < ReOpen; i++) {
                        var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                        XContainer.Append(Test, cryptoParameters: CryptoParametersEntry);
                        Record++;
                        }
                    }
                }

            var Headers = new List<ContainerHeader>();
            using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            cryptoParameters: CryptoParameters,
                            keyCollection: KeyCollection)) {
                XContainer.VerifyContainer();
                }

            // Read records 
            using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            cryptoParameters: CryptoParameters,
                            keyCollection: KeyCollection)) {

                Record = 0;
                foreach (var ContainerDataReader in XContainer) {
                    if (Record > 0) {
                        var Test = MakeConstant("Test ", ((Record) % MaxSize));

                        Headers.Add(ContainerDataReader.Header);
                        var FrameData = ContainerDataReader.ToArray();

                        Utilities.Assert.True(FrameData.IsEqualTo(Test));
                        }
                    }

                XContainer.CheckContainer(Headers);
                }

            // Test random access.
            if (MoveStep > 0) {
                // Check in forward direction
                using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            cryptoParameters: CryptoParameters)) {
                    for (Record = MoveStep; Record < Records; Record+= MoveStep) {
                        var ContainerDataReader = XContainer.GetFrameDataReader(Record);
                        Utilities.Assert.True(ContainerDataReader.Header.Index == Record);
                        }

                    }

                // Check in backwards direction
                using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            cryptoParameters: CryptoParameters)) {
                    for (Record = Records; Record > 0; Record -= MoveStep) {
                        var ContainerDataReader = XContainer.GetFrameDataReader(Record);
                        Utilities.Assert.True(ContainerDataReader.Header.Index == Record);
                        }
                    }
                }

            }
        }
    }
