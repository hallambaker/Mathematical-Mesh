using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Mesh.Test;
using System.Collections.Generic;
using System.IO;
using System;

using Xunit;

#pragma warning disable IDE0060
#pragma warning disable IDE0051

namespace Goedel.XUnit {

    public partial class TestDare {
        public static TestDare Test() => new();

        static CryptoParameters CryptoParametersNull = new CryptoParametersTest();

        //static string AccountAlice = "alice@example.com";

        //static List<string> Signers = new List<string> { AccountAlice };
        //static List<string> Recipients = new List<string> { AccountAlice };
        //static KeyPair encryptAlice = KeyPair.Factory(CryptoAlgorithmId.X448,
        //        KeySecurity.Session, keyCollection, keyUses: KeyUses.Encrypt);

        [Fact]
        public void EnvelopePlaintextJSON() {
            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeJSON(test1);
            }


        [Fact]
        public void EnvelopePlaintext() {
            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeAtomic(test1);
            TestEnvelopeFixed(test1);
            TestEnvelopeVariable(test1);
            }

        [Fact]
        public void EnvelopePlaintextAtomic() {
            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeAtomic(test1);
            }

        [Fact]
        public void EnvelopePlaintextFixed() {
            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeFixed(test1);
            }

        [Fact]
        public void EnvelopePlaintextVariable() {
            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeVariable(test1);
            }

        static KeyCollection MakeKeyCollection() {
            var testEnvironment = new TestEnvironmentCommon();
            //var machineAdmin = new MeshMachineTest(TestEnvironment, "Test");
            return new KeyCollectionTestEnv(testEnvironment.Path);
            }
        static List<string> MakeRecipients(IKeyLocate keyLocate) {
            var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
                    KeySecurity.Session, keyLocate, keyUses: KeyUses.Encrypt);

            return new List<string> { encrypt.KeyIdentifier };
            }

        static List<string> MakeSigners(IKeyLocate keyLocate) {
            var sign = KeyPair.Factory(CryptoAlgorithmId.Ed448,
                    KeySecurity.Session, keyLocate, keyUses: KeyUses.Sign);

            return new List<string> { sign.KeyIdentifier };
            }

        [Fact]
        public void EnvelopeEncryptedAtomic() {
            // Setup
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);


            var CryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);

            TestEnvelopeAtomic(test1, CryptoParameters);
            }





        [Fact]
        public void EnvelopeDigestAtomic() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var CryptoParameters = new CryptoParametersTest(
                        recipients: recipients,
                        digestID: CryptoAlgorithmId.SHA_2_512);

            var test1 = Platform.GetRandomBytes(100);

            TestEnvelopeAtomic(test1, CryptoParameters);

            TestCorruptedAtomic(test1, CryptoParameters);


            }

        [Fact]
        public void EnvelopeDigestAtomicCorrupted() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var CryptoParameters = new CryptoParametersTest(
                        recipients: recipients,
                        digestID: CryptoAlgorithmId.SHA_2_512);

            var test1 = Platform.GetRandomBytes(100);
            TestCorruptedAtomic(test1, CryptoParameters);
            }


        [Fact]
        public void EnvelopeSignAtomic() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var signers = MakeSigners(keyCollection);
            var CryptoParameters = new CryptoParametersTest(
                        recipients: recipients,
                        signers: signers);

            var test1 = Platform.GetRandomBytes(100);

            TestEnvelopeAtomic(test1, CryptoParameters);
            }


        [Fact]
        //[MT.ExpectedException(typeof(NoAvailableDecryptionKey))]
        public void EnvelopeEncryptedAtomicFail() =>


            Xunit.Assert.Throws<NoAvailableDecryptionKey>(() => {
                var encrypt = KeyPair.Factory(CryptoAlgorithmId.X448,
                        KeySecurity.Session, null, keyUses: KeyUses.Encrypt);

                var cryptoParameters = new CryptoParametersTest();
                cryptoParameters.AddEncrypt(encrypt.KeyIdentifier, false);

                var test1 = Platform.GetRandomBytes(1000);
                TestEnvelopeAtomic(test1, cryptoParameters);
            });

        [Fact]
        public void EnvelopeEncryptedFixed() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);


            TestEnvelopeFixed(test1, cryptoParameters);
            TestEnvelopeFixed(test1, cryptoParameters, 13);
            TestEnvelopeFixed(test1, cryptoParameters, 42);
            }

        [Fact]
        public void EnvelopeEncryptedVariable() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeVariable(test1, cryptoParameters);
            TestEnvelopeVariable(test1, cryptoParameters, 13);
            TestEnvelopeVariable(test1, cryptoParameters, 42);
            }


        [Fact]
        public void EnvelopeCryptoParameters() {
            var cryptoParameters = new CryptoParametersTest();

            var test1 = Platform.GetRandomBytes(1000);

            TestEnvelopeAtomic(test1, cryptoParameters);
            }

        [Fact]
        public void EnvelopeEncryptedCryptoParameters() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);

            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);

            TestEnvelopeAtomic(test1, cryptoParameters);
            TestEnvelopeFixed(test1, cryptoParameters);
            TestEnvelopeVariable(test1, cryptoParameters);
            }

        [Fact]
        public void EnvelopeEncrypted() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);
            TestEnvelopeAtomic(test1, cryptoParameters);
            TestEnvelopeFixed(test1, cryptoParameters);
            TestEnvelopeVariable(test1, cryptoParameters);

            TestEnvelopeFixed(test1, cryptoParameters, 13);
            TestEnvelopeVariable(test1, cryptoParameters, 13);

            TestEnvelopeFixed(test1, cryptoParameters, 42);
            TestEnvelopeVariable(test1, cryptoParameters, 42);
            }

        [Fact]
        public void EnvelopeEncryptedWithData() {
            var keyCollection = MakeKeyCollection();
            var recipients = MakeRecipients(keyCollection);
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var test1 = Platform.GetRandomBytes(1000);
            var test2 = Platform.GetRandomBytes(100);
            var test3 = Platform.GetRandomBytes(50);
            var dataSequences = new List<byte[]> { test2, test3 };
            TestEnvelopeAtomic(test1, cryptoParameters, dataSequences: dataSequences);

            }

        static void TestEnvelopeJSON(byte[] Plaintext,
                CryptoParameters cryptoParameters = null,
                int stride = -1,
                List<byte[]> dataSequences = null,
                string contentType = null) {

            cryptoParameters ??= CryptoParametersNull;
            var envelope = new DareEnvelope(cryptoParameters, Plaintext);

            var envelopeBytes = envelope.GetJson(false);
            CheckDecodeDirect(cryptoParameters, envelopeBytes, Plaintext, dataSequences, contentType);

            }

        static void TestEnvelopeAtomic(byte[] plaintext,
                    CryptoParameters cryptoParameters = null,
                    int stride = -1,
                    List<byte[]> dataSequences = null,
                    string contentType = null) {

            cryptoParameters ??= CryptoParametersNull;

            var envelope = new DareEnvelope(cryptoParameters, plaintext, dataSequences: dataSequences);

            var envelopeBytes = envelope.GetJson(false);

            Console.WriteLine(envelopeBytes.ToUTF8());
            CheckDecodeDirect(cryptoParameters, envelopeBytes, plaintext, dataSequences, contentType);

            var EnvelopeBytesB = envelope.GetJsonB(false);
            CheckDecodeDirect(cryptoParameters, EnvelopeBytesB, plaintext, dataSequences, contentType);
            }

        static void TestCorruptedAtomic(byte[] Plaintext,
            CryptoParameters cryptoParameters = null,
            int stride = -1,
            List<byte[]> dataSequences = null,
            string contentType = null) {

            cryptoParameters ??= CryptoParametersNull;

            var envelope = new DareEnvelope(cryptoParameters, Plaintext, dataSequences: dataSequences);

            envelope.Corrupt();

            var envelopeBytes = envelope.GetJson(false);

            //Console.WriteLine(EnvelopeBytes.ToUTF8());
            CheckDecodeCorrupted(cryptoParameters, envelopeBytes, Plaintext, dataSequences, contentType);

            var EnvelopeBytesB = envelope.GetJsonB(false);
            CheckDecodeCorrupted(cryptoParameters, EnvelopeBytesB, Plaintext, dataSequences, contentType);
            }

        static void TestEnvelopeFixed(byte[] Plaintext,
                    CryptoParameters cryptoParameters = null,
                    int stride = -1,
                    List<byte[]> dataSequences = null,
                    string contentType = null) {
            cryptoParameters ??= CryptoParametersNull;
            var contentInfo = new ContentMeta() { ContentType = contentType };
            using var InputStream = new MemoryStream(Plaintext);
            using var OutputStream = new MemoryStream();
            DareEnvelope.Encode(cryptoParameters, InputStream, OutputStream,
                    Plaintext.Length, contentInfo, dataSequences: dataSequences);

            var EnvelopeBytes = OutputStream.ToArray();
            CheckDecodeDirect(cryptoParameters, EnvelopeBytes, Plaintext, dataSequences, contentType);
            }

        static void TestEnvelopeVariable(byte[] plaintext,
                    CryptoParameters cryptoParameters = null,
                    int stride = -1,
                    List<byte[]> dataSequences = null,
                    string contentType = null) {
            cryptoParameters ??= CryptoParametersNull;
            var contentInfo = new ContentMeta() { ContentType = contentType };
            using var inputStream = new MemoryStream(plaintext);
            using var outputStream = new MemoryStream();
            DareEnvelope.Encode(cryptoParameters, inputStream, outputStream,
                        contentMeta: contentInfo, dataSequences: dataSequences);

            var envelopeBytes = outputStream.ToArray();
            CheckDecodeDirect(cryptoParameters, envelopeBytes, plaintext, dataSequences, contentType);
            }



        static void CheckDecodeDirect(
            CryptoParameters cryptoParameters,
            byte[] serialization,
            byte[] plaintext,
            List<byte[]> dataSequences = null,
            string contentType = null) {

            var envelope = DareEnvelope.FromJSON(serialization, false,
                    decrypt: cryptoParameters.Encrypt, keyCollection: cryptoParameters.KeyLocate);
            CheckDecodeResult(envelope, dataSequences, contentType);

            plaintext.IsEqualTo(envelope.Body).TestTrue();
            }

        static void CheckDecodeCorrupted(
                CryptoParameters cryptoParameters,
                byte[] serialization,
                byte[] plaintext,
                List<byte[]> dataSequences = null,
                string contentType = null) {

            var Envelope = DareEnvelope.FromJSON(serialization, false,
                    decrypt: cryptoParameters.Encrypt, keyCollection: cryptoParameters.KeyLocate);
            CheckDecodeResult(Envelope, dataSequences, contentType);

            //Plaintext.IsEqualTo(Envelope.Body).TestTrue();
            }


        static void CheckDecode(
                    DareEnvelope envelope,
                    byte[] plaintext,
                    IKeyLocate keyCollection
                    ) {

            var cryptoStack = envelope.Header.GetCryptoStack(keyCollection);
            byte[] decrypt;


            using var input = new MemoryStream(envelope.Body);
            using var output = new MemoryStream();
            var decoder = cryptoStack.GetDecoder(input, out var plaintextStream);
            plaintextStream.CopyTo(output);
            decrypt = output.ToArray();
            decrypt.IsEqualTo(plaintext).TestTrue();

            }



        static void CheckDecodeResult(
            DareEnvelope envelope,
            List<byte[]> dataSequences = null,
            string contentType = null) {

            (contentType == envelope.Header.ContentType).TestTrue(); ;
            if (dataSequences == null) {
                }
            else {
                (dataSequences.Count == envelope.DataSequences).TestTrue(); ;
                for (var i = 0; i < dataSequences.Count; i++) {
                    var MEDSS = envelope.DataSequence(i);
                    (dataSequences[i].IsEqualTo(MEDSS)).TestTrue(); ;
                    }
                }
            }

        }
    }

