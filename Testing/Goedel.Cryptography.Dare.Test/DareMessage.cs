using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Dare;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goedel.Cryptography.Dare.Test {

    public partial class TestDare {


        [MT.TestMethod]
        public void MessagePlaintextJSON () {
            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageJSON(Test1);
            }

        [MT.TestMethod]
        public void MessagePlaintext () {
            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageAtomic(Test1);
            TestMessageFixed(Test1);
            TestMessageVariable(Test1);
            }

        [MT.TestMethod]
        public void MessageEncrypted () {
            var AlicePrivate = new DiffeHellmanPrivate();
            var AliceKeypair = new KeyPairDH(AlicePrivate);
            var AlicePublic = AlicePrivate.DiffeHellmanPublic;
            var AlicePublicKeypair = new KeyPairDH(AlicePublic);

            var EncryptionKeys = new List<KeyPair> { AlicePublicKeypair };

            var Test1 = Platform.GetRandomBytes(1000);
            TestMessageAtomic(Test1, EncryptionKeys: EncryptionKeys);
            TestMessageFixed(Test1, EncryptionKeys: EncryptionKeys);
            TestMessageVariable(Test1, EncryptionKeys: EncryptionKeys);

            TestMessageFixed(Test1, 13, EncryptionKeys: EncryptionKeys);
            TestMessageVariable(Test1, 13, EncryptionKeys: EncryptionKeys);

            TestMessageFixed(Test1, 42, EncryptionKeys: EncryptionKeys);
            TestMessageVariable(Test1, 42, EncryptionKeys: EncryptionKeys);
            }

        [MT.TestMethod]
        public void MessageEncryptedWithData () {
            var AlicePrivate = new DiffeHellmanPrivate();
            var AliceKeypair = new KeyPairDH(AlicePrivate);
            var AlicePublic = AlicePrivate.DiffeHellmanPublic;
            var AlicePublicKeypair = new KeyPairDH(AlicePublic);
            var EncryptionKeys = new List<KeyPair> { AlicePublicKeypair };

            var Test1 = Platform.GetRandomBytes(1000);
            var Test2 = Platform.GetRandomBytes(100);
            var Test3 = Platform.GetRandomBytes(50);
            var DataSequences = new List<byte[]> { Test2, Test3 };
            TestMessageAtomic(Test1, EncryptionKeys:EncryptionKeys, DataSequences: DataSequences);

            }

        void TestMessageJSON (byte[] Plaintext, int Stride = -1,
            List<KeyPair> EncryptionKeys = null,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            var Message = new DAREMessage(Plaintext);

            var MessageBytes = Message.GetJson(false);
            CheckDecodeDirect(MessageBytes, Plaintext, DataSequences, ContentType);

            }


        void TestMessageAtomic (byte[] Plaintext, int Stride = -1,
                    List<KeyPair> EncryptionKeys = null,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {

            var Message = new DAREMessage(Plaintext);

            var MessageBytes = Message.GetJson(false);

            Console.WriteLine(MessageBytes.ToUTF8());
            CheckDecodeDirect(MessageBytes, Plaintext, DataSequences, ContentType);

            var MessageBytesB = Message.GetJsonB(false);
            CheckDecodeDirect(MessageBytesB, Plaintext, DataSequences, ContentType);
            }

        void TestMessageFixed (byte[] Plaintext, int Stride = -1,
                    List<KeyPair> EncryptionKeys = null,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {

            var OutputStream = new MemoryStream();

            var Message = new DAREMessage(OutputStream, EncryptionKeys,
                        ContentLength: Plaintext.LongLength, DataSequences: DataSequences);
            Message.Process(Plaintext, true);
            var MessageBytes = OutputStream.ToArray();

            CheckDecodeDirect(MessageBytes, Plaintext, DataSequences, ContentType);

            }

        void TestMessageVariable (byte[] Plaintext, int Stride = -1,
                    List<KeyPair> EncryptionKeys = null,
                    List<byte[]> DataSequences = null,
                    string ContentType = null) {

            var OutputStream = new MemoryStream();

            var Message = new DAREMessage(OutputStream, EncryptionKeys,
                        DataSequences: DataSequences);
            Message.Process(Plaintext, true);
            var MessageBytes = OutputStream.ToArray();

            CheckDecodeDirect(MessageBytes, Plaintext, DataSequences, ContentType);
            }


        void WriteBody (DAREMessage Message, byte[] Plaintext, int Stride) {
            if (Stride < 0) {
                Message.Process(Plaintext, true);
                return;
                }

            for (long i = 0; i < Plaintext.LongLength; i += Stride) {
                var Length = Plaintext.LongLength - i;
                if (Length > Stride) {
                    Message.Process(Plaintext, false, i, Stride);
                    }
                else {
                    Message.Process(Plaintext, true, i, Length);
                    }
                }
            }

        public static void CheckDecodeDirect (
            byte[] Serialization,
            byte[] Plaintext,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            var Message = DAREMessage.FromJSON(Serialization, false);
            CheckDecodeResult(Message, DataSequences, ContentType);

            Assert.True(Plaintext.IsEqualTo(Message.Body));
            }

        public static void CheckDecodeStreamed (
            byte[] Serialization,
            byte[] Plaintext,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            //var Message = DAREMessage.ReadHeader(Serialization.JSONReader());
            //while (Message.ReadChunk(out var Chunk)) {

            //    }
            throw new NYI();

            }


        public static void CheckDecodeResult (
            DAREMessage Message,
            List<byte[]> DataSequences = null,
            string ContentType = null) {

            Assert.True(ContentType == Message.Header.ContentType);
            if (DataSequences == null) {
                }
            else {
                Assert.True(DataSequences.Count == Message.DataSequences);
                for (var i = 0; i < DataSequences.Count; i++) {
                    Assert.True(DataSequences[i] == Message.DataSequence (i));
                    }
                }
            }

        }
    }

