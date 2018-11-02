using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Xunit;

namespace Goedel.Cryptography.Dare.Test {

    public partial class TestDare {
        public static TestDare Test() => new TestDare();
        public TestDare() => TestEnvironment.Initialize(true);

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
                        Recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);

            TestMessageAtomic(Test1, CryptoParameters);
            }


        [Fact]
        public void MessageDigestAtomic() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients,
                        DigestID: CryptoAlgorithmID.SHA_2_512);

            var Test1 = Platform.GetRandomBytes(100);

            TestMessageAtomic(Test1, CryptoParameters);
            }

        [Fact]
        public void MessageSignAtomic() {
            var Recipients = new List<string> { "Alice@example.com" };
            var Signers = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients,
                        Signers: Signers);

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
                        Recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);


            TestMessageFixed(Test1, CryptoParameters);
            TestMessageFixed(Test1, CryptoParameters, 13);
            TestMessageFixed(Test1, CryptoParameters, 42);
            }

        [Fact]
        public void MessageEncryptedVariable() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients);

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
                        Recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);

            TestMessageAtomic(Test1, CryptoParameters);
            TestMessageFixed(Test1, CryptoParameters);
            TestMessageVariable(Test1, CryptoParameters);
            }

        [Fact]
        public void MessageEncrypted () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients);

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
        public void MessageEncryptedWithData () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        Recipients: Recipients);

            var Test1 = Platform.GetRandomBytes(1000);
            var Test2 = Platform.GetRandomBytes(100);
            var Test3 = Platform.GetRandomBytes(50);
            var DataSequences = new List<byte[]> { Test2, Test3 };
            TestMessageAtomic(Test1, CryptoParameters, DataSequences: DataSequences);

            }

        void TestMessageJSON (byte[] Plaintext,
                CryptoParameters CryptoParameters = null,
                int Stride = -1,
                List<byte[]> DataSequences = null,
                string ContentType = null) {

            CryptoParameters = CryptoParameters ?? CryptoParametersNull;
            var Message = new DareMessage(CryptoParameters, Plaintext);

            var MessageBytes = Message.GetJson(false);
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);

            }


        void TestMessageAtomic(byte[] Plaintext,
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {

            CryptoParameters = CryptoParameters ?? CryptoParametersNull;

            var Message = new DareMessage(CryptoParameters, Plaintext, DataSequences: DataSequences);

            var MessageBytes = Message.GetJson(false);

            Console.WriteLine(MessageBytes.ToUTF8());
            CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);

            var MessageBytesB = Message.GetJsonB(false);
            CheckDecodeDirect(CryptoParameters, MessageBytesB, Plaintext, DataSequences, ContentType);
            }


        void TestMessageFixed(byte[] Plaintext,
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {
            CryptoParameters = CryptoParameters ?? CryptoParametersNull;

            using (var InputStream = new MemoryStream(Plaintext)) {

                using (var OutputStream = new MemoryStream()) {
                    DareMessage.Encode(CryptoParameters, InputStream, OutputStream,
                        Plaintext.Length, ContentType, DataSequences: DataSequences);

                    var MessageBytes = OutputStream.ToArray();
                    CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);
                    }
                }
            }

        void TestMessageVariable(byte[] Plaintext, 
                    CryptoParameters CryptoParameters = null,
                    int Stride = -1,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {
            CryptoParameters = CryptoParameters ?? CryptoParametersNull;
            using (var InputStream = new MemoryStream(Plaintext)) {

                using (var OutputStream = new MemoryStream()) {
                    DareMessage.Encode(CryptoParameters, InputStream, OutputStream,
                        ContentType:ContentType, DataSequences: DataSequences);

                    var MessageBytes = OutputStream.ToArray();
                    CheckDecodeDirect(CryptoParameters, MessageBytes, Plaintext, DataSequences, ContentType);
                    }
                }
            }



        static void CheckDecodeDirect(
            CryptoParameters CryptoParameters,
            byte[] Serialization,
            byte[] Plaintext,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            var Message = DareMessage.FromJSON(Serialization, false, 
                    Decrypt: CryptoParameters.Encrypt, KeyCollection: CryptoParameters.KeyCollection );
            CheckDecodeResult(Message, DataSequences, ContentType);

            Utilities.Assert.True(Plaintext.IsEqualTo(Message.Body));
            }


        static void CheckDecodeResult (
            DareMessage Message,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            Utilities.Assert.True(ContentType == Message.Header.ContentType);
            if (DataSequences == null) {
                }
            else {
                Utilities.Assert.True(DataSequences.Count == Message.DataSequences);
                for (var i = 0; i < DataSequences.Count; i++) {
                    var MEDSS = Message.DataSequence(i);
                    Utilities.Assert.True(DataSequences[i].IsEqualTo(MEDSS));
                    }
                }
            }

        }
    }

