using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

using Xunit;

namespace Goedel.XUnit {
    public partial class TestContainers {
        static TestContainers() {
            TestEnvironmentCommon.Initialize();
            Mesh.Mesh.Initialize();
            }


        KeyCollection MakeKeyCollection() {
            var TestEnvironment = new TestEnvironmentCommon();
            //var machineAdmin = new MeshMachineTest(TestEnvironment, "Test");
            return new KeyCollectionTestEnv(TestEnvironment.Path);
            }

        [Fact]
        public void ContainerFixedExchange() =>
            ContainerFixedExchangeTest("Single", true, 10, 2048, 5, 2);

        [Fact]
        public void ContainerFixedPolicy() =>
            ContainerFixedExchangeTest("Isolated", true, 10, 2048, 5, 2);

        [Fact]
        public void ContainerMultiplePolicy() =>
            ContainerFixedExchangeTest("All", false, 10, 2048, 5, 2);


        [Theory]
        [InlineData("Single", true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
        [InlineData("Single", true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
        [InlineData("Isolated", true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
        [InlineData("Isolated", true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
        [InlineData("All", true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
        [InlineData("All", true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
        public void ContainerFixedExchangeTest(
                string encryptPolicy,
                bool seal,
                int records = 1, int maxSize = 0,
                int reOpen = 0, int moveStep = 0,
                CryptoAlgorithmId cryptoAlgorithmId = CryptoAlgorithmId.X448) {
            // Setup
            var keyCollection = MakeKeyCollection();

            // Generate key(s)
            var encrypt = KeyPair.Factory(cryptoAlgorithmId,
                    KeySecurity.Ephemeral, keyCollection, keyUses: KeyUses.Encrypt);

            // Create Policy
            var policy = new DarePolicy() {
                Encryption = encryptPolicy,
                EncryptKeys = new List<Cryptography.Jose.Key> {
                    Cryptography.Jose.Key.FactoryPublic (encrypt)
                    },
                Sealed = seal
                };

            var namebase = $"Incremental-{encryptPolicy}-";
            // Exercise Container
            TestContainerIncremental(namebase, keyCollection, policy, records, maxSize, reOpen, moveStep);
            }

        byte[] MakeRecordData(int record, int size) {
            var rand = new Random(record);
            size = rand.Next(1,size);
            var result = new byte[size];
            rand.NextBytes(result);

            return result;
            }

        bool Verify(
                    DarePolicy darePolicy, 
                    ContainerFrameIndex frameIndex, 
                    int record, 
                    int size,
                    IKeyLocate keyCollection) {

            bool encrypt = true;
            bool? keyExchange = null;

            switch (darePolicy.Encryption) {
                case "Single": {
                    keyExchange = (record == 0);
                    break;
                    }
                case "Isolated": {
                    keyExchange = true;
                    break;
                    }

                case "None": {
                    encrypt = false;
                    break;
                    }
                case "All": {
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }

            // Check policy is applied correctly
            (frameIndex.IsEncrypted==encrypt).TestTrue();
            (keyExchange== null || keyExchange == frameIndex.KeyExchange).TestTrue();

            // check the payload
            frameIndex.HasPayload.TestTrue();
            var payload = frameIndex.GetPayload(keyCollection);
            var test = MakeRecordData(record, size);
            payload.TestEqual(test);

            // check the encrypted payload isn't the plaintext(!)
            if (frameIndex.IsEncrypted) {
                var body = frameIndex.GetBody(null);
                ArrayUtilities.IsEqualTo(body, test).TestFalse();
                }

            return true;
            }


        void TestContainerIncremental(
                string namebase,
                    IKeyLocate keyCollection,
                DarePolicy darePolicy = null,
                int records = 1, int maxSize = 0,
                int reOpen = 0, int moveStep = 0) {

            reOpen = reOpen == 0 ? records : reOpen;
            maxSize = maxSize == 0 ? records + 1 : maxSize;

            var filename = $"namebase-{records}-{maxSize}-{reOpen}-{moveStep}";
            int record;

            // Write initial set of records
            using (var XContainer = Container.NewContainer(
                            filename, FileStatus.Overwrite, containerType:
                            ContainerType.Merkle,
                            policy: darePolicy)) {
                for (record = 0; record < reOpen; record++) {
                    var Test = MakeRecordData(record, maxSize);
                    XContainer.Append(Test);
                    }
                }

            // Write additional records
            while (record < records) {
                using var XContainer = Container.Open(filename, FileStatus.Append);
                for (var i = 0; (record < records) & i < reOpen; i++) {
                    var Test = MakeRecordData(record, maxSize);
                    XContainer.Append(Test);
                    record++;
                    }
                }

            using (var XContainer = Container.Open(filename, FileStatus.Read,
                            keyLocate: keyCollection)) {
                XContainer.VerifyContainer();
                }


            //var Headers = new List<DareHeader>();


            // Read records 
            using (var XContainer = Container.Open(filename, FileStatus.Read,
                            keyLocate: keyCollection)) {

                record = 0;
                foreach (var ContainerDataReader in XContainer) {
                    Verify(darePolicy, ContainerDataReader, record, maxSize, keyCollection);
                    }

                //XContainer.CheckContainer(Headers);
                }

            //Test random access.
            if (moveStep > 0) {
                // Check in forward direction
                using (var XContainer = Container.Open(filename, FileStatus.Read)) {
                    for (record = moveStep; record < records; record += moveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(record);
                        (ContainerDataReader.Header.ContainerInfo.Index == record).TestTrue();
                        }

                    }

                // Check in backwards direction
                using (var XContainer = Container.Open(filename, FileStatus.Read)) {
                    for (record = records; record > 0; record -= moveStep) {
                        var ContainerDataReader = XContainer.GetContainerFrameIndex(record);
                        (ContainerDataReader.Header.ContainerInfo.Index == record).TestTrue();
                        }
                    }

                }

            }





        }
    }
