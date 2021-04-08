using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Test.Core;
using Goedel.Utilities;

using System.Numerics;

using Xunit;

namespace Goedel.XUnit {

    public class BufferTests {
        public static BufferTests Test() => new();


        [Fact]
        public void TestBuffer() {
            var Public = new BigInteger(42);
            var Test = new PKIXPublicKeyDH() {
                Public = Public.ToByteArray()
                };

            for (var i = 0; i < 66000; i += 100) {
                Test.Shared = Platform.GetRandomBytes(i);
                var Encode = Test.DER();
                Encode.Keep();
                }

            }



        //void TestDH (System.Numerics.BigInteger Count) {

        //    }

        }
    }
