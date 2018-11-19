using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Goedel.Cryptography;
using Goedel.Test;
using Goedel.Utilities;
using System.Collections;

namespace Goedel.XUnit {
    public class TestSplit {

        public TestSplit() => CryptographyCommon.Initialize();


        [Theory]
        [InlineData (1,1)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(6, 2)]
        [InlineData(7, 2)]
        [InlineData(8, 2)]
        [InlineData(9, 2)]
        [InlineData(10, 2)]
        [InlineData(11, 2)]
        [InlineData(12, 2)]
        [InlineData(13, 2)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        public void TestShares(int N, int K) {

            var secret = new Secret(128);
            var shares = secret.Split(N, K);

            var partshares = shares.Shuffle(K);
            var resecret = new Secret(partshares);

            Xunit.Assert.True(secret.Key.IsEqualTo(resecret.Key));
            }



        }
    }
