using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {

    public partial class TestDare {
        public static TestDare Test() => new TestDare();
        public TestDare() => TestEnvironmentCommon.Initialize(true);

        static CryptoParameters CryptoParametersNull = new CryptoParametersTest();


         [Fact]
        public void MessagePlaintextJSON() {
            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageJSON(Test1);
            }


        [Fact]
        public void MessagePlaintext() {
            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageAtomic(Test1);
            TestMessageFixed(Test1);
            TestMessageVariable(Test1);
            }

        [Fact]
        public void MessageEncryptedAtomic() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);

            TestMessageAtomic(Test1, CryptoParameters);
            }


        [Fact]
        public void MessageDigestAtomic() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients,
                        digestID: CryptoAlgorithmId.SHA_2_512);

            var Test1 = Platform.GetRandomBytes(100);

            TestMessageAtomic(Test1, CryptoParameters);
            }

        [Fact]
        public void MessageSignAtomic() {
            var Recipients = new List<string> { "Alice@example.com" };
            var Signers = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients,
                        signers: Signers);

            var Test1 = Platform.GetRandomBytes(100);

            TestMessageAtomic(Test1, CryptoParameters);
            }


        [Fact]
        //[MT.ExpectedException(typeof(NoAvailableDecryptionKey))]
        public void MessageEncryptedAtomicFail() =>
            Xunit.Assert.Throws<NoAvailableDecryptionKey>(() => {
                var CryptoParameters = new CryptoParametersTest();
                CryptoParameters.AddEncrypt("Alice@example.com", false);

                var Test1 = Platform.GetRandomBytes(1000);
                TestMessageAtomic(Test1, CryptoParameters);
            });

        [Fact]
        public void MessageEncryptedFixed() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);


            TestMessageFixed(Test1, CryptoParameters);
            TestMessageFixed(Test1, CryptoParameters, 13);
            TestMessageFixed(Test1, CryptoParameters, 42);
            }

        [Fact]
        public void MessageEncryptedVariable() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageVariable(Test1, CryptoParameters);
            TestMessageVariable(Test1, CryptoParameters, 13);
            TestMessageVariable(Test1, CryptoParameters, 42);
            }


        [Fact]
        public void MessageCryptoParameters() {
            var CryptoParameters = new CryptoParametersTest();

            var Test1 = Platform.GetRandomBytes(1000);

            TestMessageAtomic(Test1, CryptoParameters);
            }

        [Fact]
        public void MessageEncryptedCryptoParameters() {
            var Recipients = new List<string> { "Alice@example.com" };

            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);

            TestMessageAtomic(Test1, CryptoParameters);
            TestMessageFixed(Test1, CryptoParameters);
            TestMessageVariable(Test1, CryptoParameters);
            }

        [Fact]
        public void MessageEncrypted() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageAtomic(Test1, CryptoParameters);
            TestMessageFixed(Test1, CryptoParameters);
            TestMessageVariable(Test1, CryptoParameters);

            TestMessageFixed(Test1, CryptoParameters, 13);
            TestMessageVariable(Test1, CryptoParameters, 13);

            TestMessageFixed(Test1, CryptoParameters, 42);
            TestMessageVariable(Test1, CryptoParameters, 42);
            }

        [Fact]
        public void MessageEncryptedWithData() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);
            var Test2 = Platform.GetRandomBytes(100);
            var Test3 = Platform.GetRandomBytes(50);
            var DataSequences = new List<byte[]> { Test2, Test3 };
            TestMessageAtomic(Test1, CryptoParameters, DataSequences: DataSequences);

            }

        void TestMessageJSON(byte[] Plaintext,
                CryptoParameters CryptoParameters = null,
                int Stride = -1,
                List<byte[]> DataSequences = null,
                string ContentType = null) {

            CryptoParameters ??= CryptoParametersNull;
            var Message = new DareEnvelope(CryptoParameters, Plaintext);

            var MessageBytes = Message.GetJson(false);
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);

            }


        void TestMessageAtomic(byte[] Plaintext,
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {

            CryptoParameters ??= CryptoParametersNull;

            var Message = new DareEnvelope(CryptoParameters, Plaintext, dataSequences: DataSequences);

            var MessageBytes = Message.GetJson(false);

            //Console.WriteLine(MessageBytes.ToUTF8());
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);

            var MessageBytesB = Message.GetJsonB(false);
            CheckDecodeDirect(CryptoParameters, MessageBytesB, Plaintext, DataSequences, ContentType);
            }


        void TestMessageFixed(byte[] Plaintext,
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string contentType = null) {
            CryptoParameters ??= CryptoParametersNull;
            var contentInfo = new ContentMeta() { ContentType = contentType };
            using var InputStream = new MemoryStream(Plaintext);
            using var OutputStream = new MemoryStream();
            DareEnvelope.Encode(CryptoParameters, InputStream, OutputStream,
Plaintext.Length, contentInfo, dataSequences: DataSequences);

            var MessageBytes = OutputStream.ToArray();
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, contentType);
            }

        void TestMessageVariable(byte[] Plaintext,
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string contentType = null) {
            CryptoParameters ??= CryptoParametersNull;
            var contentInfo = new ContentMeta() { ContentType = contentType };
            using var InputStream = new MemoryStream(Plaintext);
            using var OutputStream = new MemoryStream();
            DareEnvelope.Encode(CryptoParameters, InputStream, OutputStream,
contentMeta: contentInfo, dataSequences: DataSequences);

            var MessageBytes = OutputStream.ToArray();
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, contentType);
            }



        static void CheckDecodeDirect(
            CryptoParameters CryptoParameters,
            byte[] Serialization,
            byte[] Plaintext,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            var Message = DareEnvelope.FromJSON(Serialization, false,
                    decrypt: CryptoParameters.Encrypt, keyCollection: CryptoParameters.KeyLocate);
            CheckDecodeResult(Message, DataSequences, ContentType);

            Plaintext.IsEqualTo(Message.Body).TestTrue();
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
            DareEnvelope Message,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            (ContentType == Message.Header.ContentType).TestTrue(); ;
            if (DataSequences == null) {
                }
            else {
                (DataSequences.Count == Message.DataSequences).TestTrue(); ;
                for (var i = 0; i < DataSequences.Count; i++) {
                    var MEDSS = Message.DataSequence(i);
                    (DataSequences[i].IsEqualTo(MEDSS)).TestTrue(); ;
                    }
                }
            }

        }
    }

