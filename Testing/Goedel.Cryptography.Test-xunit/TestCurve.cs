using System.Numerics;
using System.Collections.Generic;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Xunit;
namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {


        public class SignatureTest {
            public byte[] SecretKey;
            public byte[] PublicKey;
            public byte[] Message;
            public byte[] Signature;

            public static SignatureTest[] Tests448 = new SignatureTest[] {
                new SignatureTest () {
                    SecretKey = ("6c82a562cb808d10d632be89c8513ebf" +
                                "6c929f34ddfa8c9f63c9960ef6e348a3" +
                                "528c8a3fcc2f044e39a3fc5b94492f8f"+
                                "032e7549a20098f95b").FromBase16(),
                    PublicKey = ("5fd7449b59b461fd2ce787ec616ad46a"+
                                "1da1342485a70e1f8a0ea75d80e96778"+
                                "edf124769b46c7061bd6783df1e50f6c"+
                                "d1fa1abeafe8256180").FromBase16(),
                    Message = "".FromBase16(),
                    Signature = ("e5564300c360ac729086e2cc806e828a" + 
                                "84877f1eb8e5d974d873e06522490155" +
                                "5fb8821590a33bacc61e39701cf9b46b" +
                                "d25bf5f0595bbe24655141438e7a100b"+
                                "533a37f6bbe457251f023c0d88f976ae"+
                                "2dfb504a843e34d2074fd823d41a591f"+
                                "2b233f034f628281f2fd7a22ddd47d78"+
                                "28c59bd0a21bfd3980ff0d2028d4b18a"+
                                "9df63e006c5d1c2d345b925d8dc00b41"+
                                "04852db99ac5c7cdda8530a113a0f4db"+
                                "b61149f05a7363268c71d95808ff2e65"+
                                "2600").FromBase16()
                    }


                };

            /// <summary>
            /// Test from RFC80...
            /// Should read in file from http://ed25519.cr.yp.to/python/sign.input
            /// </summary>
            public static SignatureTest[] Tests25519 = new SignatureTest[] {
                new SignatureTest () {
                    SecretKey = ("9d61b19deffd5a60ba844af492ec2cc4" +
                                "4449c5697b326919703bac031cae7f60").FromBase16(),
                    PublicKey = ("d75a980182b10ab7d54bfed3c964073a"+
                                "0ee172f3daa62325af021a68f707511a").FromBase16(),
                    Message = "".FromBase16(),
                    Signature = ("e5564300c360ac729086e2cc806e828a" +
                                "84877f1eb8e5d974d873e06522490155" +
                                "5fb8821590a33bacc61e39701cf9b46b" +
                                "d25bf5f0595bbe24655141438e7a100b").FromBase16()
                    }


                };



            }




        [Fact]
        public void TestEd25519x() => TestEd25519(SignatureTest.Tests25519[0]);

        [Fact]
        public void TestEd448x() => TestEd448(SignatureTest.Tests448[0]);

        void TestEd25519 (SignatureTest Test) {

            var Private = new CurveEdwards25519Private(Test.SecretKey);
            var Public = Private.PublicKey;

            Public.Encoding.AssertEqual(Test.PublicKey);

            }

        void TestEd448(SignatureTest Test) {

            var Private = new CurveEdwards448Private(Test.SecretKey);
            var Public = Private.Public;

            Public.Encoding.AssertEqual(Test.PublicKey);

            }


        }
    }
