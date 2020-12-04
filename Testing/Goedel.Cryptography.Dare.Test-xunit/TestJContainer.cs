using Goedel.Cryptography;
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

        static string AccountAlice = "alice@example.com";

        static List<string> Signers = new List<string> { AccountAlice };
        static List<string> Recipients = new List<string> { AccountAlice };

        public TestContainers() => TestEnvironmentCommon.Initialize(true);
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

            var CryptoParameters = new DarePolicy(keyCollection, recipients: recipients);


            //TestContainer($"ContainerList", ContainerType.List, 0, policy: CryptoParameters);


            // probably failing because the encrypted payload length is being incorrectly calculated.
            TestContainer($"ContainerList", ContainerType.List, 1, policy: CryptoParameters);
            TestContainer($"ContainerList", ContainerType.List, 10, policy: CryptoParameters);
            }

        [Fact]
        public void ContainerTestEncryptedItem() {
            var CryptoParametersEntry = new CryptoParameters(
                        recipients: Recipients);

            TestContainer($"ContainerList", ContainerType.List, 0, CryptoParametersEntry: CryptoParametersEntry);
            TestContainer($"ContainerList", ContainerType.List, 1, CryptoParametersEntry: CryptoParametersEntry);
            TestContainer($"ContainerList", ContainerType.List, 10, CryptoParametersEntry: CryptoParametersEntry);
            }

        [Fact]
        public void ContainerTestSigned() {
            var CryptoParameters = new DarePolicy(
                        new CryptoParameters(signers: Signers));

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
        public void ContainerTestEncryptedMulti() {

            var CryptoParameters = new DarePolicy(
                    new CryptoParameters(recipients: Recipients));

            var Records = 0;
            TestContainerMulti($"-Encrypted-{Records}", Records, policy: CryptoParameters);
            Records = 1;
            TestContainerMulti($"-Encrypted-{Records}", Records, policy: CryptoParameters);
            Records = 10;
            TestContainerMulti($"-Encrypted-{Records}", Records, policy: CryptoParameters);
            }

        [Fact]
        public void ContainerTestEncryptedEntryMulti() {

            var CryptoParameters = new CryptoParametersTest(
                    recipients: Recipients);

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
                    recipients: Recipients, signers: Signers);

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
            TestContainerMulti($"-{Records}-{ReOpen}-{MoveStep}",
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

        void TestContainer(string FileName, ContainerType ContainerType,
                    int Records = 1, int MaxSize = 0, int ReOpen = 0, int MoveStep = 0,
                    DarePolicy policy = null,
                    CryptoParameters CryptoParametersEntry = null) {

            var keyCollection = policy?.KeyLocate;
            //var KeyCollection = policy?.KeyLocate ?? CryptoParametersEntry?.KeyLocate;

            ReOpen = ReOpen == 0 ? Records : ReOpen;
            MaxSize = MaxSize == 0 ? Records + 1 : MaxSize;

            FileName += $"-{Records}";

            int Record;

            // Write initial set of records
            using (var XContainer = Container.NewContainer(
                            FileName, FileStatus.Overwrite, containerType: ContainerType,
                            policy)) {
                for (Record = 0; Record < ReOpen; Record++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test);
                    }
                }

            // Write additional records
            while (Record < Records) {
                using var XContainer = Container.Open(FileName, FileStatus.Append,
                             policy:policy);
                for (var i = 0; (Record < Records) & i < ReOpen; i++) {
                    var Test = MakeConstant("Test ", ((Record + 1) % MaxSize));
                    XContainer.Append(Test);
                    Record++;
                    }
                }

            var Headers = new List<DareHeader>();
            using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            policy: policy,
                            keyLocate: keyCollection)) {
                XContainer.VerifyContainer();
                }

            // Read records 
            using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            policy: policy,
                            keyLocate: keyCollection)) {

                Record = 0;
                foreach (var ContainerDataReader in XContainer) {
                    if (Record > 0) {
                        var Test = MakeConstant("Test ", ((Record) % MaxSize));

                        Headers.Add(ContainerDataReader.Header);
                        var FrameData = ContainerDataReader.GetBody(XContainer);

                        (FrameData.IsEqualTo(Test)).TestTrue();
                        }
                    }

                XContainer.CheckContainer(Headers);
                }

            // Test random access.
            if (MoveStep > 0) {
                // Check in forward direction
                using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            policy: policy)) {
                    for (Record = MoveStep; Record < Records; Record += MoveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(Record);
                        (ContainerDataReader.Header.ContainerInfo.Index == Record).TestTrue(); ;
                        }

                    }

                // Check in backwards direction
                using (var XContainer = Container.Open(FileName, FileStatus.Read,
                            policy: policy)) {
                    for (Record = Records; Record > 0; Record -= MoveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(Record);
                        (ContainerDataReader.Header.ContainerInfo.Index == Record).TestTrue(); ;
                        }
                    }
                }

            }
        }
    }
