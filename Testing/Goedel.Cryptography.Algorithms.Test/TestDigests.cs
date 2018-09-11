using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;

namespace Cryptography.Algorithms.Test {
    [TestClass]
    public class TestDigests {


        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {
            InitializeClass();

            var Instance = new TestDigests();
            Instance.TestSHA_FOCUS();
            }


        [ClassInitialize]
        public static void InitializeClass(TestContext context) => InitializeClass();

        public static void InitializeClass() =>
            //CryptographyFramework.Initialize();
            CryptographyWindows.Initialize();

        static string Message1 = "abc";
        static string Message2 = "";
        static string Message3 = "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq";
        static string Message4 = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu";
        static string Message5 = "a";
        static string Message6 = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmno";

        // Some algorithm variations are intentionally omitted from the support library.
        // To enable testing in the future, the corresponding test vectors are specified
        // in the test set with the algorithm ID set to null;
        static CryptoAlgorithmID SHA_1 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_2_224 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_2_256 = CryptoAlgorithmID.SHA_2_256;
        static CryptoAlgorithmID SHA_2_384 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_2_512 = CryptoAlgorithmID.SHA_2_512;
        static CryptoAlgorithmID SHA_2_512T128 = CryptoAlgorithmID.SHA_2_512T128;
        //static CryptoAlgorithmID SHA_3_224 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_3_256 = CryptoAlgorithmID.SHA_3_256;
        //static CryptoAlgorithmID SHA_3_384 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_3_512 = CryptoAlgorithmID.SHA_3_512;
        static CryptoAlgorithmID SHAKE_128 = CryptoAlgorithmID.SHAKE_128;
        static CryptoAlgorithmID SHAKE_256 = CryptoAlgorithmID.SHAKE_256;

        static CryptoAlgorithmID SHA_3_224 = CryptoAlgorithmID.NULL;
        //static CryptoAlgorithmID SHA_3_256 = CryptoAlgorithmID.NULL;
        static CryptoAlgorithmID SHA_3_384 = CryptoAlgorithmID.NULL;
        //static CryptoAlgorithmID SHA_3_512 = CryptoAlgorithmID.NULL;

        List<TestVectorSet> TestVectors_SHA_NIST = new List<TestVectorSet>() {
            new TestVectorSet() {
                MessageString = Message1,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "a9993e36 4706816a ba3e2571 7850c26c 9cd0d89d"),
                    new TestVector (SHA_2_224,     "23097d22 3405d822 8642a477 bda255b3 2aadbce4 bda0b3f7 e36c9da7"),
                    new TestVector (SHA_2_256,     "ba7816bf 8f01cfea 414140de 5dae2223 b00361a3 96177a9c b410ff61 f20015ad"),
                    new TestVector (SHA_2_384,     "cb00753f45a35e8b b5a03d699ac65007 272c32ab0eded163 1a8b605a43ff5bed 8086072ba1e7cc23 58baeca134c825a7"),
                    new TestVector (SHA_2_512,     "ddaf35a193617aba cc417349ae204131 12e6fa4e89a97ea2 0a9eeee64b55d39a 2192992a274fc1a8 36ba3c23a3feebbd 454d4423643ce80e 2a9ac94fa54ca49f"),
                    new TestVector (SHA_2_512T128, "ddaf35a193617aba cc417349ae204131"),
                    new TestVector (SHA_3_224,     "e642824c3f8cf24a d09234ee7d3c766f c9a3a5168d0c94ad 73b46fdf"),
                    new TestVector (SHA_3_256,     "3a985da74fe225b2 045c172d6bd390bd 855f086e3e9d525b 46bfe24511431532"),
                    new TestVector (SHA_3_384,     "ec01498288516fc9 26459f58e2c6ad8d f9b473cb0fc08c25 96da7cf0e49be4b2 98d88cea927ac7f5 39f1edf228376d25"),
                    new TestVector (SHA_3_512,     "b751850b1a57168a 5693cd924b6b096e 08f621827444f70d 884f5d0240d2712e 10e116e9192af3c9 1a7ec57647e39340 57340b4cf408d5a5 6592f8274eec53f0"),
                    new TestVector (SHAKE_128,     "5881092dd818bf5c f8a3ddb793fbcba7 4097d5c526a6d35f 97b83351940f2cc8"),
                    new TestVector (SHAKE_256,     "483366601360a877 1c6863080cc4114d 8db44530f8f1e1ee 4f94ea37e78b5739 d5a15bef186a5386 c75744c0527e1faa 9f8726e462a12a4f eb06bd8801e751e4") },
                },
            new TestVectorSet() {
                MessageString = Message2,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "da39a3ee 5e6b4b0d 3255bfef 95601890 afd80709"),
                    new TestVector (SHA_2_224,     "d14a028c 2a3a2bc9 476102bb 288234c4 15a2b01f 828ea62a c5b3e42f"),
                    new TestVector (SHA_2_256,     "e3b0c442 98fc1c14 9afbf4c8 996fb924 27ae41e4 649b934c a495991b 7852b855"),
                    new TestVector (SHA_2_384,     "38b060a751ac9638 4cd9327eb1b1e36a 21fdb71114be0743 4c0cc7bf63f6e1da 274edebfe76f65fb d51ad2f14898b95b"),
                    new TestVector (SHA_2_512,     "cf83e1357eefb8bd f1542850d66d8007 d620e4050b5715dc 83f4a921d36ce9ce 47d0d13c5d85f2b0 ff8318d2877eec2f 63b931bd47417a81 a538327af927da3e"),
                    new TestVector (SHA_2_512T128, "cf83e1357eefb8bd f1542850d66d8007"),
                    new TestVector (SHA_3_224,     "6b4e03423667dbb7 3b6e15454f0eb1ab d4597f9a1b078e3f 5b5a6bc7"),
                    new TestVector (SHA_3_256,     "a7ffc6f8bf1ed766 51c14756a061d662 f580ff4de43b49fa 82d80a4b80f8434a"),
                    new TestVector (SHA_3_384,     "0c63a75b845e4f7d 01107d852e4c2485 c51a50aaaa94fc61 995e71bbee983a2a c3713831264adb47 fb6bd1e058d5f004"),
                    new TestVector (SHA_3_512,     "a69f73cca23a9ac5 c8b567dc185a756e 97c982164fe25859 e0d1dcc1475c80a6 15b2123af1f5f94c 11e3e9402c3ac558 f500199d95b6d3e3 01758586281dcd26") ,
                    new TestVector (SHAKE_128,     "7f9c2ba4e88f827d 616045507605853e d73b8093f6efbc88 eb1a6eacfa66ef26"),
                    new TestVector (SHAKE_256,     "46b9dd2b0ba88d13 233b3feb743eeb24 3fcd52ea62b81b82 b50c27646ed5762f d75dc4ddd8c0f200 cb05019d67b592f6 fc821c49479ab486 40292eacb3b7c4be") },
                },
            new TestVectorSet() {
                MessageString = Message3,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "84983e44 1c3bd26e baae4aa1 f95129e5 e54670f1"),
                    new TestVector (SHA_2_224,     "75388b16 512776cc 5dba5da1 fd890150 b0c6455c b4f58b19 52522525"),
                    new TestVector (SHA_2_256,     "248d6a61 d20638b8 e5c02693 0c3e6039 a33ce459 64ff2167 f6ecedd4 19db06c1"),
                    new TestVector (SHA_2_384,     "3391fdddfc8dc739 3707a65b1b470939 7cf8b1d162af05ab fe8f450de5f36bc6 b0455a8520bc4e6f 5fe95b1fe3c8452b"),
                    new TestVector (SHA_2_512,     "204a8fc6dda82f0a 0ced7beb8e08a416 57c16ef468b228a8 279be331a703c335 96fd15c13b1b07f9 aa1d3bea57789ca0 31ad85c7a71dd703 54ec631238ca3445"),
                    new TestVector (SHA_2_512T128, "204a8fc6dda82f0a 0ced7beb8e08a416"),
                    new TestVector (SHA_3_224,     "8a24108b154ada21 c9fd5574494479ba 5c7e7ab76ef264ea d0fcce33"),
                    new TestVector (SHA_3_256,     "41c0dba2a9d62408 49100376a8235e2c 82e1b9998a999e21 db32dd97496d3376"),
                    new TestVector (SHA_3_384,     "991c665755eb3a4b 6bbdfb75c78a492e 8c56a22c5c4d7e42 9bfdbc32b9d4ad5a a04a1f076e62fea1 9eef51acd0657c22"),
                    new TestVector (SHA_3_512,     "04a371e84ecfb5b8 b77cb48610fca818 2dd457ce6f326a0f d3d7ec2f1e91636d ee691fbe0c985302 ba1b0d8dc78c0863 46b533b49c030d99 a27daf1139d6e75e") ,
                    new TestVector (SHAKE_128,     "1a96182b50fb8c7e 74e0a707788f55e9 8209b8d91fade8f3 2f8dd5cff7bf21f5"),
                    new TestVector (SHAKE_256,     "4d8c2dd2435a0128 eefbb8c36f6f8713 3a7911e18d979ee1 ae6be5d4fd2e3329 40d8688a4e6a59aa 8060f1f9bc996c05 aca3c696a8b66279 dc672c740bb224ec") },
                },
            new TestVectorSet() {
                MessageString = Message4,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "a49b2446 a02c645b f419f995 b6709125 3a04a259"),
                    new TestVector (SHA_2_224,     "c97ca9a5 59850ce9 7a04a96d ef6d99a9 e0e0e2ab 14e6b8df 265fc0b3"),
                    new TestVector (SHA_2_256,     "cf5b16a7 78af8380 036ce59e 7b049237 0b249b11 e8f07a51 afac4503 7afee9d1"),
                    new TestVector (SHA_2_384,     "09330c33f71147e8 3d192fc782cd1b47 53111b173b3b05d2 2fa08086e3b0f712 fcc7c71a557e2db9 66c3e9fa91746039"),
                    new TestVector (SHA_2_512,     "8e959b75dae313da 8cf4f72814fc143f 8f7779c6eb9f7fa1 7299aeadb6889018 501d289e4900f7e4 331b99dec4b5433a c7d329eeb6dd2654 5e96e55b874be909"),
                    new TestVector (SHA_2_512T128, "8e959b75dae313da 8cf4f72814fc143f"),
                    new TestVector (SHA_3_224,     "543e6868e1666c1a 643630df77367ae5 a62a85070a51c14c bf665cbc"),
                    new TestVector (SHA_3_256,     "916f6061fe879741 ca6469b43971dfdb 28b1a32dc36cb325 4e812be27aad1d18"),
                    new TestVector (SHA_3_384,     "79407d3b5916b59c 3e30b09822974791 c313fb9ecc849e40 6f23592d04f625dc 8c709b98b43b3852 b337216179aa7fc7"),
                    new TestVector (SHA_3_512,     "afebb2ef542e6579 c50cad06d2e578f9 f8dd6881d7dc824d 26360feebf18a4fa 73e3261122948efc fd492e74e82e2189 ed0fb440d187f382 270cb455f21dd185"),
                    new TestVector (SHAKE_128,     "7b6df6ff181173b6 d7898d7ff63fb07b 7c237daf471a5ae5 602adbccef9ccf4b"),
                    new TestVector (SHAKE_256,     "98be04516c04cc73 593fef3ed0352ea9 f6443942d6950e29 a372a681c3deaf45 35423709b0284394 8684e029010badcc 0acd8303fc85fdad 3eabf4f78cae1656")  },
                },
            };
        List<TestVectorSet> TestVectors_SHA_NIST_Long = new List<TestVectorSet>() {
            new TestVectorSet() {
                MessageString = Message5,
                Repeat = 1_000_000,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "34aa973c d4c4daa4 f61eeb2b dbad2731 6534016f"),
                    new TestVector (SHA_2_224,     "20794655 980c91d8 bbb4c1ea 97618a4b f03f4258 1948b2ee 4ee7ad67"),
                    new TestVector (SHA_2_256,     "cdc76e5c 9914fb92 81a1c7e2 84d73e67 f1809a48 a497200e 046d39cc c7112cd0"),
                    new TestVector (SHA_2_384,     "9d0e1809716474cb 086e834e310a4a1c ed149e9c00f24852 7972cec5704c2a5b 07b8b3dc38ecc4eb ae97ddd87f3d8985"),
                    new TestVector (SHA_2_512,     "e718483d0ce76964 4e2e42c7bc15b463 8e1f98b13b204428 5632a803afa973eb de0ff244877ea60a 4cb0432ce577c31b eb009c5c2c49aa2e 4eadb217ad8cc09b"),
                    new TestVector (SHA_2_512T128, "e718483d0ce76964 4e2e42c7bc15b463"),
                    new TestVector (SHA_3_224,     "d69335b93325192e 516a912e6d19a15c b51c6ed5c15243e7 a7fd653c"),
                    new TestVector (SHA_3_256,     "5c8875ae474a3634 ba4fd55ec85bffd6 61f32aca75c6d699 d0cdcb6c115891c1"),
                    new TestVector (SHA_3_384,     "eee9e24d78c18553 37983451df97c8ad 9eedf256c6334f8e 948d252d5e0e7684 7aa0774ddb90a842 190d2c558b4b8340"),
                    new TestVector (SHA_3_512,     "3c3a876da14034ab 60627c077bb98f7e 120a2a5370212dff b3385a18d4f38859 ed311d0a9d5141ce 9cc5c66ee689b266 a8aa18ace8282a0e 0db596c90b0a7b87") },
                },
            new TestVectorSet() {
                MessageString = Message6,
                Repeat = 16_777_216,
                TestVectors = new List<TestVector> () {
                    new TestVector (SHA_1,         "7789f0c9 ef7bfc40 d9331114 3dfbe69e 2017f592"),
                    new TestVector (SHA_2_224,     "b5989713 ca4fe47a 009f8621 980b34e6 d63ed306 3b2a0a2c 867d8a85"),
                    new TestVector (SHA_2_256,     "50e72a0e 26442fe2 552dc393 8ac58658 228c0cbf b1d2ca87 2ae43526 6fcd055e"),
                    new TestVector (SHA_2_384,     "5441235cc0235341 ed806a64fb354742 b5e5c02a3c5cb71b 5f63fb793458d8fd ae599c8cd8884943 c04f11b31b89f023"),
                    new TestVector (SHA_2_512,     "b47c933421ea2db1 49ad6e10fce6c7f9 3d0752380180ffd7 f4629a712134831d 77be6091b819ed35 2c2967a2e2d4fa50 50723c9630691f1a 05a7281dbe6c1086"),
                    new TestVector (SHA_2_512T128, "b47c933421ea2db1 49ad6e10fce6c7f9"),
                    new TestVector (SHA_3_224,     "c6d66e77ae289566 afb2ce39277752d6 da2a3c46010f1e0a 0970ff60"),
                    new TestVector (SHA_3_256,     "ecbbc42cbf296603 acb2c6bc0410ef43 78bafb24b710357f 12df607758b33e2b"),
                    new TestVector (SHA_3_384,     "a04296f4fcaae148 71bb5ad33e28dcf6 9238b04204d9941b 8782e816d014bcb7 540e4af54f30d578 f1a1ca2930847a12"),
                    new TestVector (SHA_3_512,     "235ffd53504ef836 a1342b488f483b39 6eabbfe642cf78ee 0d31feec788b23d0 d18d5c339550dd59 58a500d4b95363da 1b5fa18affc1bab2 292dc63b7d85097c") },
                }
            };

        [TestMethod]
        public void TestSHA_FOCUS () {
            foreach (var TestVectorSet in TestVectors_SHA_NIST) {
                if (TestVectorSet.Repeat == 1) {
                    foreach (var TestVector in TestVectorSet.TestVectors) {
                        if (TestVector.ID == CryptoAlgorithmID.SHAKE_128) {
                            var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                            TestVectorSet.Verify(Provider, TestVector);
                            }
                        }
                    }
                }
            }


        [TestMethod]
        public void TestSHA_ALL () {
            foreach (var TestVectorSet in TestVectors_SHA_NIST) {
                if (TestVectorSet.Repeat == 1) {
                    foreach (var TestVector in TestVectorSet.TestVectors) {
                        if (TestVector.ID != CryptoAlgorithmID.NULL) {
                            var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                            TestVectorSet.Verify(Provider, TestVector);
                            }
                        }
                    }
                }
            }

        [TestMethod]
        public void TestSHA_ALL_Stream () {
            foreach (var TestVectorSet in TestVectors_SHA_NIST) {
                foreach (var TestVector in TestVectorSet.TestVectors) {
                    if (TestVector.ID != CryptoAlgorithmID.NULL) {
                        var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                        TestVectorSet.Verify_Streamed(Provider, TestVector);
                        }
                    }
                }
            }

        [TestMethod]
        public void TestSHA_ALL_Stream_Long () {
            foreach (var TestVectorSet in TestVectors_SHA_NIST_Long) {
                foreach (var TestVector in TestVectorSet.TestVectors) {
                    if (TestVector.ID != CryptoAlgorithmID.NULL) {
                        var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                        TestVectorSet.Verify_Streamed(Provider, TestVector);
                        }
                    }
                }
            }
        }


    public class TestVectorSet {
        public List<TestVector> TestVectors { get; set; }
        public byte[] Message { get; set; }

        public string MessageString { set => Message = value.ToBytes();  }

        public int Repeat { get; set; } = 1;

        public void Verify (CryptoProviderDigest Provider, TestVector TestVector) {

            var Result = Provider.ProcessData(Message);

            UT.Assert.IsTrue(Result.IsEqualTo(TestVector.Digest));
            }


        public void Verify_Streamed (CryptoProviderDigest Provider, TestVector TestVector) {

            var Encoder = Provider.MakeEncoder();
            for (var i = 0; i < Repeat; i++) {
                Encoder.Write(Message);
                }
            Encoder.Complete();
            var Result = Encoder.Integrity;

            UT.Assert.IsTrue(Result.IsEqualTo(TestVector.Digest));
            }

        }


    public class TestVector {
        public CryptoAlgorithmID ID { get; set; }
        public byte[] Digest { get; set; }

        public TestVector (CryptoAlgorithmID CryptoAlgorithmID, String Digest) {
            ID = CryptoAlgorithmID;
            this.Digest = Digest.FromBase16();


            }
        }

    }
