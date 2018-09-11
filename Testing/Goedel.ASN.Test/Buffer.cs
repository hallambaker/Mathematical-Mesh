using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using Goedel.Utilities;
using Goedel.Test;
using Goedel.ASN;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography;

namespace Goedel.ASN.Test {
    [TestClass]
    public class Buffer {

        // Feature: ASN1. Decode

        [TestMethod]
        public void TestBuffer() {
            var Public = new BigInteger(42);
            var Test = new PKIXPublicKeyDH() {
                Public = Public.ToByteArray()
                };

            for (var i =0; i <66000; i+= 100) {
                Test.Shared = Platform.GetRandomBytes(i);
                var Encode = Test.DER();
                }

            }



        void TestDH (System.Numerics.BigInteger Count) {

            }

        }
    }
