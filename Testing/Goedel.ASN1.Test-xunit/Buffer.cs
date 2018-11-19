using System;
using System.Numerics;
using Xunit;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.Test;
using Goedel.ASN;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography;

namespace Goedel.XUnit {

    public class Buffer {
        public static Buffer Test => new Buffer();
        public Buffer() => TestEnvironment.Initialize(true);
        // Feature: ASN1. Decode

        [Fact]
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
