using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Nist;

using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestNist : Disposable {

    public string ACVP_Root => @"..\NIST.Test.Vectors";

    public string KemKeyGen => Path.Combine(ACVP_Root, "ML-KEM-keyGen-FIPS203");
    public string KemEncapDecap => Path.Combine(ACVP_Root, "ML-KEM-encapDecap-FIPS203");
    public string DsaKeyGen => Path.Combine(ACVP_Root, "ML-DSA-keyGen-FIPS204");
    public string DsaSign => Path.Combine(ACVP_Root, "ML-DSA-sigGen-FIPS204");
    public string DsaVerify => Path.Combine(ACVP_Root, "ML-DSA-sigVer-FIPS204");


    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestNist() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestNist Test() => new();


    //[Fact]
    //public void TestUdf() {
    //    var data = "This is a common test seed".ToBytes();

    //    var (udfMlDsa44, keyMlDsa44) = UdfSignatureTrial(UdfAlgorithmIdentifier.MLDSA44, 0);
    //    var (udfMlDsa65, keyMlDsa65) = UdfSignatureTrial(UdfAlgorithmIdentifier.MLDSA65, 0);
    //    var (udfMlDsa87, keyMlDsa87) = UdfSignatureTrial(UdfAlgorithmIdentifier.MLDSA87, 0);

    //    var (udfMlKem512, keyMlKem512) = UdfEncryptionTrial(UdfAlgorithmIdentifier.MLKEM512, 0);
    //    var (udfMlKem768, keyMlKem768) = UdfEncryptionTrial(UdfAlgorithmIdentifier.MLKEM768, 0);
    //    var (udfMlKem1024, keyMlKem1024) = UdfEncryptionTrial(UdfAlgorithmIdentifier.MLKEM1024, 0);
    //    }


    //(string, KeyPair) UdfEncryptionTrial(UdfAlgorithmIdentifier id, int count) =>
    //    UdfTrial(id, count);

    //(string, KeyPair) UdfSignatureTrial(UdfAlgorithmIdentifier id, int count) =>
    //    UdfTrial(id, count);









    //(string, KeyPair) UdfTrial(UdfAlgorithmIdentifier id, int count) {
    //    var data = SHAKE256.Process($"This is a common test seed of {id}-{count}".ToBytes(), 256);

    //    var udf = Udf.DerivedKey(id, data);
    //    var keypair = Udf.DeriveKey(udf);


    //    return (udf, keypair);
    //    }
    public static void GetRSA() {




        //var primeGenerator = new PrimeGenerator();
        //var composer = new CrtKeyComposer(primeGenerator);
        //var keypair1 = composer.GenerateKeyPair(2048);


        var keypair1 =  KeyFactoryRsa.Generate(null, null, "fred", 2048);


        var rsaKeyPair = KeyPairRSA.Generate(2048, KeySecurity.Exportable);

        var pkix = rsaKeyPair.PkixPrivateKeyRSA;

        var p = pkix.Prime1.BigIntegerBigEndian();
        var q = pkix.Prime2.BigIntegerBigEndian();
        var m = pkix.Modulus.BigIntegerBigEndian();

        var modulus = p * q;
        var test = modulus - m;

        Console.WriteLine($"Test {test}");


        var key2 = new KeyPairRSA(pkix);

        var key3 = new KeyPairRSA(keypair1);

        Console.WriteLine($"UDFs {rsaKeyPair.UDFValue}");
        Console.WriteLine($"\nUDFs {key2.UDFValue}");
        //var PkixPrivateKeyRsa = rsaKeyPair.PkixPrivateKeyRsa;

        //for (var i = 0; i < 100; i++) {
        //    Console.WriteLine($"Pass {i}");

        //    var keypair1 = composer.GenerateKeyPair(2048);
        //    var keypair2 = composer.GenerateKeyPair(3072);
        //    var keypair3 = composer.GenerateKeyPair(4096);
        //    }
        //var random = new Random800_90();
        //var entropyProvider = new EntropyProvider(random);


        ////var generatorFactory = new PrimeGeneratorFactory();



        //var generator = new AllProbablePrimesWithConditionsGenerator(
        //    entropyProvider, PrimeTestModes.TwoPow100ErrorBound);




        //var params1 = new PrimeGeneratorParameters() {
        //    Modulus = 2048,
        //    PublicE = 65537,
        //    BitLens = [140, 140, 140, 140]
        //    };


        //var primes = generator.GeneratePrimesFips186_5(params1);
        }


    [Fact]
    public void TestKemKeyGen() {

        var testBinding = new AcvpTestBinding<KemKeyGenTest>(KemKeyGen);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }

    [Fact]
    public void TestKemEncapDecap() {


        var testBinding = new AcvpTestBinding<KemEncapDecapTest>(KemEncapDecap);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }


    [Fact]
    public void TestDsaKeyGen() {


        var testBinding = new AcvpTestBinding<DsaKeyGenTest>(DsaKeyGen);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }

    [Fact]
    public void TestDsaSign() {


        var testBinding = new AcvpTestBinding<DsaSignTest>(DsaSign);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }

    [Fact]
    public void TestDsaVerify() {


        var testBinding = new AcvpTestBinding<DsaVerifyTest>(DsaVerify);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



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



