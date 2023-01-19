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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;
#pragma warning disable IDE0060
namespace Goedel.XUnit;

public partial class TestContainers {
    static TestContainers() {
        }

    static KeyCollection MakeKeyCollection() {
        var TestEnvironment = new TestEnvironmentCommon();
        //var machineAdmin = new MeshMachineTest(TestEnvironment, "Test");
        return new KeyCollectionTestEnv(TestEnvironment.Path);
        }

    [Fact]
    public void ContainerOnceExchange() =>
        ContainerFixedExchangeTest(DareConstants.PolicyEncryptionOnceTag, true, 10, 2048, 5, 2);

    [Fact]
    public void ContainerIsolatedPolicy() =>
        ContainerFixedExchangeTest(DareConstants.PolicyEncryptionIsolatedTag, true, 10, 2048, 5, 2);

    [Fact]
    public void ContainerSessionPolicy() =>
        ContainerFixedExchangeTest(DareConstants.PolicyEncryptionSessionTag, false, 10, 2048, 5, 2);


    [Theory]
    [InlineData(DareConstants.PolicyEncryptionSessionTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
    [InlineData(DareConstants.PolicyEncryptionSessionTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
    [InlineData(DareConstants.PolicyEncryptionIsolatedTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
    [InlineData(DareConstants.PolicyEncryptionIsolatedTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
    [InlineData(DareConstants.PolicyEncryptionOnceTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X25519)]
    [InlineData(DareConstants.PolicyEncryptionOnceTag, true, 50, 2048, 5, 2, CryptoAlgorithmId.X448)]
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
                KeySecurity.Exportable, keyCollection, keyUses: KeyUses.Encrypt);

        // Create Policy
        var policy = new DarePolicy() {
            Encryption = encryptPolicy,
            EncryptKeys = new List<Cryptography.Jose.Key> {
                    Cryptography.Jose.Key.FactoryPublic (encrypt)
                    },
            Sealed = seal
            };

        var namebase = $"Incremental-{encryptPolicy}-";
        // Exercise Sequence
        TestContainerIncremental(namebase, keyCollection, policy, records, maxSize, reOpen, moveStep);
        }

    static byte[] MakeRecordData(int record, int size) {
        var rand = new Random(record);
        size = rand.Next(1, size);
        var result = new byte[size];
        rand.NextBytes(result);

        Console.WriteLine($"MakeRecordData  {record} {size} => {result} ");


        return result;
        }

    static bool Verify(
                Sequence container,
                DarePolicy darePolicy,
                SequenceIndexEntry frameIndex,
                int record,
                int size,
                IKeyLocate keyCollection) {

        bool encrypt = true;
        bool? keyExchange = null;

        var header = frameIndex.Header;

        switch (darePolicy.Encryption) {
            case DareConstants.PolicyEncryptionOnceTag: {
                    keyExchange = (header.Index == 0);
                    break;
                    }
            case DareConstants.PolicyEncryptionIsolatedTag: {
                    keyExchange = true;
                    break;
                    }

            case DareConstants.PolicyEncryptionNoneTag: {
                    encrypt = false;
                    break;
                    }
            case DareConstants.PolicyEncryptionSessionTag: {
                    keyExchange = null;
                    break;
                    }
            default: {
                    throw new NYI();
                    }
            }

        // Check policy is applied correctly
        (frameIndex.IsEncrypted == encrypt).TestTrue();
        (keyExchange == null || keyExchange == frameIndex.KeyExchange).TestTrue();

        // check the payload
        frameIndex.HasPayload.TestTrue();
        var payload = frameIndex.GetPayload(container, keyCollection);
        var test = MakeRecordData(record, size);
        payload.TestEqual(test);

        // check the encrypted payload isn't the plaintext(!)
        if (frameIndex.IsEncrypted) {
            var body = frameIndex.GetBody(container);
            ArrayUtilities.IsEqualTo(body, test).TestFalse();
            }

        return true;
        }

    static void TestContainerIncremental(
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
        using (var XContainer = Sequence.NewContainer(
                        filename, FileStatus.Overwrite, sequenceType:
                        SequenceType.Merkle,
                        policy: darePolicy)) {
            for (record = 0; record < reOpen; record++) {
                var Test = MakeRecordData(record, maxSize);
                XContainer.Append(Test);
                }
            }

        // Write additional records
        while (record < records) {
            using var XContainer = Sequence.Open(filename, FileStatus.Append, keyCollection);
            for (var i = 0; (record < records) & i < reOpen; i++) {
                var Test = MakeRecordData(record, maxSize);
                XContainer.Append(Test);
                record++;
                }
            }

        using (var XContainer = Sequence.Open(filename, FileStatus.Read,
                        keyLocate: keyCollection)) {
            XContainer.VerifySequence();
            }


        //var Headers = new List<DareHeader>();


        // Read records 
        using (var XContainer = Sequence.Open(filename, FileStatus.Read,
                        keyLocate: keyCollection)) {

            record = 0;
            foreach (var ContainerDataReader in XContainer) {
                Verify(XContainer, darePolicy, ContainerDataReader, record++, maxSize, keyCollection);
                }

            //XContainer.CheckContainer(Headers);
            }

        //Test random access.
        if (moveStep > 0) {
            // Check in forward direction
            using (var XContainer = Sequence.Open(filename, FileStatus.Read, keyCollection)) {
                for (record = moveStep; record < records; record += moveStep) {
                    var ContainerDataReader = XContainer.Frame(record);
                    (ContainerDataReader.Header.SequenceInfo.LIndex == record).TestTrue();
                    }

                }

            // Check in backwards direction
            using (var XContainer = Sequence.Open(filename, FileStatus.Read, keyCollection)) {
                for (record = records; record > 0; record -= moveStep) {
                    var ContainerDataReader = XContainer.Frame(record);
                    (ContainerDataReader.Header.SequenceInfo.LIndex == record).TestTrue();
                    }
                }

            }

        }





    }
