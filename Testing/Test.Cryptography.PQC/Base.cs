using System;

using Goedel.Test;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Xunit;
using Goedel.Cryptography.PQC;
using System.Runtime.Intrinsics.X86;
using Goedel.Cryptography.PQC;
using System.Text.Json;
using System.IO;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestPQC : Disposable {


    public string ACVP_Root => @"C:\Users\hallam\source\repos\mmm\Testing\Test.Cryptography.PQC";
    public  string KemKeyGen => Path.Combine(ACVP_Root, "ML-KEM-keyGen-FIPS203");
    public string KemEncapDecap => Path.Combine(ACVP_Root, "ML-KEM-encapDecap-FIPS203");
    public string DsaKeyGen => Path.Combine(ACVP_Root, "ML-DSA-keyGen-FIPS204");
    public string DsaSign => Path.Combine(ACVP_Root, "ML-DSA-sigGen-FIPS204");
    public string DsaVerify=> Path.Combine(ACVP_Root, "ML-DSA-sigVer-FIPS204");





    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestPQC() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestPQC Test() => new();


    public void ML_DSA_KeyGen() {
        
        var testBinding1 = new TestBinding<KemKeyGenTest>(KemKeyGen);
        var testBinding2 = new TestBinding<KemEncapDecapTest>(KemEncapDecap);
        var testBinding3 = new TestBinding<DsaKeyGenTest>(DsaKeyGen);
        var testBinding4 = new TestBinding<DsaSignTest>(DsaSign);
        var testBinding5 = new TestBinding<DsaVerifyTest>(DsaVerify);


        }




    //[Theory]
    ////[InlineData(512)]
    ////[InlineData(768)]
    //[InlineData(1024)]
    //public void Kyber(int bits, int repeat=1) {
    //    for (var i = 0; i < repeat; i++) {
    //        var random = TestRandom.GetRandom($"-{bits}-{i}");

    //        var seedKey = random.GetBytes(Cryptography.PQC.Kyber.SymBytes, "Keygen");
    //        var seedSession = random.GetBytes(Cryptography.PQC.Kyber.SymBytes, "Session");

    //        var kyber = new Kyber(bits);
    //        var (publicKey, privateKey) = kyber.KeyPair(seedKey);

    //        var encryptor = new KyberPublic(publicKey);
    //        var (ciphertext, sharedSecret) = encryptor.Encrypt(seedSession);

    //        var decryptor = new KyberPrivate(privateKey);
    //        var plaintext = decryptor.Decrypt(ciphertext);

    //        plaintext.TestEqual(sharedSecret);

    //        //Console.WriteLine($"{i}");
    //        }
    //    }


    //[Theory]
    //[InlineData(DilithiumMode.Mode5)]
    //public void Dilithium(DilithiumMode mode, int repeat = 1) {
    //    for (var i = 0; i < repeat; i++) {
    //        var random = TestRandom.GetRandom($"-{mode}-{i}");

    //        var matseed = random.GetBytes(Cryptography.PQC.MLDSA.SeedBytes, "Keygen");
    //        var sm = random.GetBytes(128, "Message");

    //        var (pk, sk) = Cryptography.PQC.MLDSA.GenerateKeypair(mode, matseed);


    //        var privateKey = new DilithiumPrivate(sk);
    //        var signature = privateKey.Sign(sm);

    //        var publicKey = new DilithiumPublic(pk);
    //        var verify = publicKey.Verify(signature, sm);

    //        verify.TestTrue();

    //        sm[0] ^= 0x01;

    //        var fail = publicKey.Verify(signature, sm);
    //        fail.TestFalse();

    //        //Console.WriteLine($"{i}");
    //        }
    //    }

    }



