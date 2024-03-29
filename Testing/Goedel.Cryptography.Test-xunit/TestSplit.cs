﻿#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Numerics;

using Goedel.Cryptography;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

public class TestSplit {
    public static TestSplit Test() => new();




    [Theory]
    [InlineData(32)]
    [InlineData(32, "00000000")]
    [InlineData(32, "00000001")]
    [InlineData(32, "10000000")]
    [InlineData(32, "FFFFFFFF")]
    [InlineData(64)]
    [InlineData(128)]
    [InlineData(256)]
    [InlineData(512)]
    public void TestKey(int bits, string hexData = null) {
        var data = hexData == null ? CryptoCatalog.GetBits(bits) : hexData.FromBase16();

        var secret = new SharedSecret(data);
        var udf = secret.UDFKey;

        var secret2 = new SharedSecret(secret.Key);
        secret2.UDFKey.TestEqual(udf);

        }

    [Theory]
    [InlineData(32)]
    [InlineData(32, "00000000")]
    [InlineData(32, "00000001")]
    [InlineData(32, "10000000")]
    [InlineData(32, "FFFFFFFF")]
    [InlineData(64)]
    [InlineData(128)]
    [InlineData(256)]
    [InlineData(512)]
    public void TestKeyShare(int bits, string hexData = null) {
        var data = hexData == null ? CryptoCatalog.GetBits(bits) : hexData.FromBase16();
        var index = 1;

        var keyShare = new KeyShareSymmetric(index, data);
        data.TestEqual(keyShare.Data);
        (keyShare.Value >= 0).TestTrue();

        var udf = keyShare.UDFKey;
        var keyShare2 = new KeyShareSymmetric(udf);

        keyShare2.Key.TestEqual(keyShare.Key);
        keyShare2.UDFKey.TestEqual(udf);
        keyShare2.Value.TestEqual(keyShare.Value);

        var keyShare3 = new KeyShareSymmetric(index, keyShare.Value, data.Length);
        keyShare3.Key.TestEqual(keyShare.Key);
        keyShare3.UDFKey.TestEqual(udf);
        keyShare3.Value.TestEqual(keyShare.Value);
        }



    [Theory]
    [InlineData(1, 1)]
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

        var secret = new SharedSecret(128);
        var shares = secret.Split(N, K);

        var partshares = shares.Shuffle(K);
        var resecret = new SharedSecret(partshares);

        Xunit.Assert.True(secret.Key.IsEqualTo(resecret.Key));
        }


    /// <summary>
    /// Check that all the prime values are in fact prime
    /// </summary>
    [Fact]
    public void TestSplitPrimes() {
        for (int i = 32; i < 512; i += 32) {

            var exponent = BigInteger.Pow(2, i);
            var prime = SharedSecret.GetPrime(i, out _, out _);
            prime.IsProbablePrime(256).TestTrue();
            (prime > exponent).TestTrue();

            //Console.WriteLine($"Check {i} {prime}");
            }

        }

    /// <summary>
    /// Check that all the prime values are in fact prime
    /// </summary>
    [Fact]
    public void TestBigIntconversion() {
        var bigtest1 = (new byte[] { 1, 0, 0, 0 }).BigIntegerBigEndian();
        (bigtest1 == new BigInteger(0x01000000)).TestTrue();

        bigtest1 = (new byte[] { 0, 0, 0, 1 }).BigIntegerBigEndian();
        (bigtest1 == new BigInteger(0x00000001)).TestTrue();

        }


    }
