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

namespace Goedel.XUnit;

public partial class GoedelCryptography {


    static GoedelCryptography() => Goedel.Cryptography.Core.Initialization.Initialized.TestTrue();


    public static GoedelCryptography Test() => new();

    readonly static byte[] NIST_Plaintext =
                    ("6bc1bee22e409f96e93d7e117393172a"
                    + "ae2d8a571e03ac9c9eb76fac45af8e51"
                    + "30c81c46a35ce411e5fbc1191a0a52ef"
                    + "f69f2445df4f9b17ad2b417be66c3710.").FromBase16();
    readonly List<TestVectorAES> testVectors_AES_NIST = new() {
        // TestCase 2:1/2
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128CBCNone,
            Key = "2b7e151628aed2a6abf7158809cf4f3c".FromBase16(),
            IV = "000102030405060708090a0b0c0d0e0f".FromBase16(),
            Plaintext = NIST_Plaintext,
            Ciphertext = ("7649abac8119b246cee98e9b12e9197d"
                    + "5086cb9b507219ee95db113a917678b2"
                    + "73bed6b8e3c1743b7116e69e22229516"
                    + "3ff1caa1681fac09120eca307586e1a7.").FromBase16()
            },
        // TestCase 2:5/6
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256CBCNone,
            Key = "603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4".FromBase16(),
            IV = "000102030405060708090a0b0c0d0e0f".FromBase16(),
            Plaintext = NIST_Plaintext,
            Ciphertext = ("f58c4c04d6e5f1ba779eabfb5f7bfbd6"
                    + "9cfc4e967edb808d679f777bc6702c7d"
                    + "39f23369a9d9bacfa530e26304231461"
                    + "b2eb05e2c39be9fcda6c19078c6a9d1b.").FromBase16()
            },


        // http://csrc.nist.gov/groups/ST/toolkit/BCM/documents/proposedmodes/gcm/gcm-revised-spec.pdf
        // GCM 1
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "00000000000000000000000000000000".FromBase16(),
            IV = "000000000000000000000000".FromBase16(),
            Plaintext = System.Array.Empty<byte>(),
            Ciphertext = System.Array.Empty<byte>(),
            Tag = "58e2fccefa7e3061367f1d57a4e7455a".FromBase16(),
            },
        // GCM 2
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "00000000000000000000000000000000".FromBase16(),
            IV = "000000000000000000000000".FromBase16(),
            Plaintext = "00000000000000000000000000000000".FromBase16(),
            Ciphertext = "0388dace60b6a392f328c2b971b2fe78".FromBase16(),
            Tag = "ab6e47d42cec13bdf53a67b21257bddf".FromBase16(),
            },
        // GCM 3
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbaddecaf888".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b391aafd255").FromBase16(),
            Ciphertext = ("42831ec2217774244b7221b784d0d49c"
                            + "e3aa212f2c02a4e035c17e2329aca12e"
                            + "21d514b25466931c7d8f6a5aac84aa05"
                            + "1ba30b396a0aac973d58e091473f5985").FromBase16(),
            Tag = "4d5c2af327cd64a62cf35abd2ba6fab4".FromBase16(),
            },
        // GCM 4
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbaddecaf888".FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b39").FromBase16(),
            Ciphertext = ("42831ec2217774244b7221b784d0d49c"
                            + "e3aa212f2c02a4e035c17e2329aca12e"
                            + "21d514b25466931c7d8f6a5aac84aa05"
                            + "1ba30b396a0aac973d58e091473f5985").FromBase16(),
            Tag = "5bc94fbc3221a5db94fae95ae7121a47".FromBase16(),
            },
        // GCM 5
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbad".FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b39").FromBase16(),
            Ciphertext = ("61353b4c2806934a777ff51fa22a4755"
                            + "699b2a714fcdc6f83766e5f97b6c7423"
                            + "73806900e49f24b22b097544d4896b42"
                            + "4989b5e1ebac0f07c23f4598").FromBase16(),
            Tag = "3612d2e79e3b0785561be14aaca2fccb".FromBase16(),
            },
        // GCM 6
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES128GCM,
            Key = "feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = ("9313225df88406e555909c5aff5269aa"
                            + "6a7a9538534f7da1e4c303d2a318a728"
                            + "c3c0c95156809539fcf0e2429a6b5254"
                            + "16aedbf5a0de6a57a637b39b").FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b391aafd255").FromBase16(),
            Ciphertext = ("8ce24998625615b603a033aca13fb894"
                            + "be9112a5c3a211a8ba262a3cca7e2ca7"
                            + "01e4a9a4fba43c90ccdcb281d48c7c6f"
                            + "d62875d2aca417034c34aee5").FromBase16(),
            Tag = "619cc5aefffe0bfa462af43c1699d050".FromBase16(),
            },

        // GCM 13
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "0000000000000000000000000000000000000000000000000000000000000000".FromBase16(),
            IV = "000000000000000000000000".FromBase16(),
            Plaintext = System.Array.Empty<byte>(),
            Ciphertext = System.Array.Empty<byte>(),
            Tag = "530f8afbc74536b9a963b4f1c4cb738b".FromBase16(),
            },
        // GCM 14
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "0000000000000000000000000000000000000000000000000000000000000000".FromBase16(),
            IV = "000000000000000000000000".FromBase16(),
            Plaintext = "00000000000000000000000000000000".FromBase16(),
            Ciphertext = "cea7403d4d606b6e074ec5d3baf39d18".FromBase16(),
            Tag = "d0d1c8a799996bf0265b98b5d48ab919".FromBase16(),
            },
        // GCM 15
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "feffe9928665731c6d6a8f9467308308feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbaddecaf888".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b391aafd255").FromBase16(),
            Ciphertext = ("522dc1f099567d07f47f37a32a84427d"
                            + "643a8cdcbfe5c0c97598a2bd2555d1aa"
                            + "8cb08e48590dbb3da7b08b1056828838"
                            + "c5f61e6393ba7a0abcc9f662898015ad").FromBase16(),
            Tag = "b094dac5d93471bdec1a502270e3cc6c".FromBase16(),
            },
        // GCM 16
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "feffe9928665731c6d6a8f9467308308feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbaddecaf888".FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b39").FromBase16(),
            Ciphertext = ("522dc1f099567d07f47f37a32a84427d"
                            + "643a8cdcbfe5c0c97598a2bd2555d1aa"
                            + "8cb08e48590dbb3da7b08b1056828838"
                            + "c5f61e6393ba7a0abcc9f662").FromBase16(),
            Tag = "76fc6ece0f4e1768cddf8853bb2d551b".FromBase16(),
            },
        // GCM 17
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "feffe9928665731c6d6a8f9467308308feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = "cafebabefacedbad".FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b39").FromBase16(),
            Ciphertext = ("c3762df1ca787d32ae47c13bf19844cb"
                            + "af1ae14d0b976afac52ff7d79bba9de0"
                            + "feb582d33934a4f0954cc2363bc73f78"
                            + "62ac430e64abe499f47c9b1f").FromBase16(),
            Tag = "3a337dbf46a792c45e454913fe2ea8f2".FromBase16(),
            },
        // GCM 18
        new TestVectorAES() {
            ID = CryptoAlgorithmId.AES256GCM,
            Key = "feffe9928665731c6d6a8f9467308308feffe9928665731c6d6a8f9467308308".FromBase16(),
            IV = ("9313225df88406e555909c5aff5269aa"
                            + "6a7a9538534f7da1e4c303d2a318a728"
                            + "c3c0c95156809539fcf0e2429a6b5254"
                            + "16aedbf5a0de6a57a637b39b").FromBase16(),
            AAD = "feedfacedeadbeeffeedfacedeadbeefabaddad2".FromBase16(),
            Plaintext = ("d9313225f88406e5a55909c5aff5269a"
                            + "86a7a9531534f7da2e4c303d8a318a72"
                            + "1c3c0c95956809532fcf0e2449a6b525"
                            + "b16aedf5aa0de657ba637b39").FromBase16(),
            Ciphertext = ("5a8def2f0c9e53f1f75d7853659e2a20"
                            + "eeb2b22aafde6419a058ab4f6f746bf4"
                            + "0fc0c3b780f244452da3ebf1c5d82cde"
                            + "a2418997200ef82e44ae7e3f").FromBase16(),
            Tag = "a44a8266ee1c8eb0c8b5d4cf5ae9f19a".FromBase16(),
            }
        };

    [Fact]
    public void TestAES_NIST() {
        foreach (var TestVector in testVectors_AES_NIST) {

            if ((TestVector.ID == CryptoAlgorithmId.AES128CBCNone) |
                    (TestVector.ID == CryptoAlgorithmId.AES256CBCNone)) {
                var Provider = CryptoCatalog.Default.GetEncryption(TestVector.ID);

                TestVector.Verify(Provider);
                //TestVector.Verify_Random(Provider);

                // Feature: Add test for GCM
                }
            }
        }


    [Fact]
    public void TestAES_NIST_Streaming() {
        foreach (var TestVector in testVectors_AES_NIST) {

            if ((TestVector.ID == CryptoAlgorithmId.AES128CBCNone) |
                    (TestVector.ID == CryptoAlgorithmId.AES256CBCNone)) {
                var Provider = CryptoCatalog.Default.GetEncryption(TestVector.ID);

                TestVector.Verify_Streamed(Provider);

                }
            }
        }


    // 2Test: More test vectors, longer tests. 
    // 2Test: Using the output stream to chain encryption.
    }


public class TestVectorAES {
    public CryptoAlgorithmId ID { get; set; }

    public byte[] Key { get; set; }

    public byte[] IV { get; set; }


    public byte[] Plaintext { get; set; }

    public byte[] Ciphertext { get; set; }

    public byte[] Tag { get; set; }

    public byte[] AAD { get; set; }


    /// <summary>Test buffered (non streamed) mode with NIST key, IV.</summary>
    /// <param name="Provider">The Cryptographic provider</param>
    public void Verify(CryptoProviderEncryption Provider) {
        var Encrypted = Provider.Encrypt(Plaintext, Key, IV);
        var Decrypted = Provider.Decrypt(Ciphertext, Key, IV);

        Encrypted.IsEqualTo(Ciphertext).TestTrue();
        Decrypted.IsEqualTo(Plaintext).TestTrue();
        }

    /// <summary>Test buffered (non streamed) mode with randomly generated Key, IV.</summary>
    /// <param name="Provider">The Cryptographic provider</param>
    public void Verify_Streamed(CryptoProviderEncryption Provider) {
        var Encryptor = Provider.MakeEncryptor(Key, IV);
        Encryptor.Write(Plaintext);
        Encryptor.Complete();

        var Decryptor = Provider.MakeDecryptor(Key, IV);
        Decryptor.Write(Ciphertext);
        Decryptor.Complete();


        Encryptor.OutputData.IsEqualTo(Ciphertext).TestTrue();
        Decryptor.OutputData.IsEqualTo(Plaintext).TestTrue();
        }


    }
