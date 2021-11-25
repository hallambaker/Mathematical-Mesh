#region // Copyright - MIT License
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

using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

public partial class TestGoedelCryptography {


    public static TestGoedelCryptography Test() => new();


    // http://csrc.nist.gov/groups/ST/toolkit/documents/Examples/SHA_All.pdf
    // https://www.di-mgt.com.au/sha_testvectors.html
    List<TestVectorSHA> TestVectors_SHA_NIST = new() {

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_1_DEPRECATED,
            Message = "abc",
            Digest = ("A9993E36 4706816A BA3E2571 7850C26C 9CD0D89D").FromBase16(),
            },

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_1_DEPRECATED,
            Message = "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq",
            Digest = ("84983E44 1C3BD26E BAAE4AA1 F95129E5 E54670F1").FromBase16(),
            },



        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_256,
            Message = "abc",
            Digest = ("BA7816BF 8F01CFEA 414140DE 5DAE2223" +
                        "B00361A3 96177A9C B410FF61 F20015AD").FromBase16(),
            },

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_256,
            Message = "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq",
            Digest = ("248D6A61 D20638B8 E5C02693 0C3E6039" +
                        "A33CE459 64FF2167 F6ECEDD4 19DB06C1").FromBase16(),
            },


        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_512,
            Message = "abc",
            Digest = ("DDAF35A1 93617ABA CC417349 AE204131"
                + "12E6FA4E 89A97EA2 0A9EEEE6 4B55D39A 2192992A 274FC1A8"
                + "36BA3C23 A3FEEBBD 454D4423 643CE80E 2A9AC94F A54CA49F").FromBase16(),
            },

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_512,
            Message = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhi" +
                        "jklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu",
            Digest = ("8E959B75 DAE313DA 8CF4F728 14FC143F"
                + "8F7779C6 EB9F7FA1 7299AEAD B6889018 501D289E 4900F7E4"
                + "331B99DE C4B5433A C7D329EE B6DD2654 5E96E55B 874BE909").FromBase16(),
            },

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_512T128,
            Message = "abc",
            Digest = ("DDAF35A1 93617ABA CC417349 AE204131").FromBase16(),
            },

        new TestVectorSHA() {
            ID = CryptoAlgorithmId.SHA_2_512T128,
            Message = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhi" +
                        "jklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu",
            Digest = ("8E959B75 DAE313DA 8CF4F728 14FC143F").FromBase16(),
            }
        };

    [Fact]
    public void TestSHA_NIST() {
        foreach (var TestVector in TestVectors_SHA_NIST) {
            var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
            TestVector.Verify(Provider);
            }
        }

    [Fact]
    public void TestSHA_NIST_Streamed() {

        foreach (var TestVector in TestVectors_SHA_NIST) {
            var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
            TestVector.Verify_Streamed(Provider);
            }
        }

    }


public class TestVectorSHA {
    public CryptoAlgorithmId ID { get; set; }

    public string Message { get; set; }

    public byte[] Digest { get; set; }

    public void Verify(CryptoProviderDigest Provider) {

        var Result = Provider.ProcessData(Message.ToBytes());

        Result.TestEqual(Digest);
        }


    public void Verify_Streamed(CryptoProviderDigest Provider) {

        var Encoder = Provider.MakeEncoder();
        Encoder.Write(Message.ToBytes());
        Encoder.Complete();
        var Result = Encoder.Integrity;

        Result.TestEqual(Digest);
        }

    }
