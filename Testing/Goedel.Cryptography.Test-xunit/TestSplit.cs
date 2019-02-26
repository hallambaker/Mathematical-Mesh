using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Goedel.Cryptography;
using Goedel.Test;
using Goedel.Utilities;
using System.Numerics;

namespace Goedel.XUnit {
    public class TestSplit {
        public static TestSplit Test() => new TestSplit();
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


        /// <summary>
        /// Check that all the prime values are in fact prime
        /// </summary>
        [Fact]
        public void TestSplitPrimes() {
            for (int i = 32; i < 512; i+=32) {
                
                var exponent = BigInteger.Pow(2, i);
                var prime = Secret.GetPrime(i, out _, out _);
                prime.IsProbablePrime(256).AssertTrue();
                (prime > exponent).AssertTrue();

                //Console.WriteLine($"Check {i} {prime}");
                }

            }

        /// <summary>
        /// Check that all the prime values are in fact prime
        /// </summary>
        [Fact]
        public void TestBigIntconversion() {
            var bigtest1 = (new byte[] { 1, 0, 0, 0 }).BigIntegerBigEndian();
            (bigtest1 == new BigInteger(0x01000000)).AssertTrue();

            bigtest1 = (new byte[] { 0, 0, 0, 1 }).BigIntegerBigEndian();
            (bigtest1 == new BigInteger(0x00000001)).AssertTrue();

            }


        /// <summary>
        /// Check that all the prime values are in fact prime
        /// </summary>
        [Fact]
        public void TestSplit1() {
            var secret = new Secret(32);
            var shares = secret.Split(3, 2);



            }


        }
    }
