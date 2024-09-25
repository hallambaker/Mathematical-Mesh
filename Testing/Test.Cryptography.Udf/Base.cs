using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Test;

using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;

namespace Goedel.XUnit;

public enum KeyGenTestMode {
    None = 0,
    Sign = 1,
    Encrypt = 2,
    SignEncrypt = 3
    }

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestUdf : Disposable {

    public static TestUdf Test()  => new();


    public static string Goedel_ACVP_Root => Path.Combine(TestEnvironmentBase.CommonData,
                "Goedel.Test.Vectors");

    public static string UdfDirectoryML => Path.Combine(Goedel_ACVP_Root, "Udf.ML");
    public static string UdfDirectoryECC => Path.Combine(Goedel_ACVP_Root, "Udf.ECC");
    public static string UdfDirectoryRSA => Path.Combine(Goedel_ACVP_Root, "Udf.RSA");
    public static string UdfDirectoryECCP => Path.Combine(Goedel_ACVP_Root, "Udf.ECCP");




    public static (UdfAlgorithmIdentifier, KeyGenTestMode)[] AlgIdsML = [
            (UdfAlgorithmIdentifier.MLDSA44, KeyGenTestMode.Sign),
            (UdfAlgorithmIdentifier.MLDSA65, KeyGenTestMode.Sign),
            (UdfAlgorithmIdentifier.MLDSA87, KeyGenTestMode.Sign),
            (UdfAlgorithmIdentifier.MLKEM512, KeyGenTestMode.Encrypt),
            (UdfAlgorithmIdentifier.MLKEM768, KeyGenTestMode.Encrypt),
            (UdfAlgorithmIdentifier.MLKEM1024, KeyGenTestMode.Encrypt),
            ];

    public static (UdfAlgorithmIdentifier, KeyGenTestMode)[] AlgIdsRSA = [
            (UdfAlgorithmIdentifier.RSA2048, KeyGenTestMode.SignEncrypt),
            (UdfAlgorithmIdentifier.RSA3072, KeyGenTestMode.SignEncrypt),
            (UdfAlgorithmIdentifier.RSA4096, KeyGenTestMode.SignEncrypt)
            ];

    public static (UdfAlgorithmIdentifier, KeyGenTestMode)[] AlgIdsECC = [
            (UdfAlgorithmIdentifier.X25519, KeyGenTestMode.Encrypt),
            (UdfAlgorithmIdentifier.X448, KeyGenTestMode.Encrypt),
            (UdfAlgorithmIdentifier.Ed25519, KeyGenTestMode.Sign),
            (UdfAlgorithmIdentifier.Ed448, KeyGenTestMode.Sign)
            ];

    public static (UdfAlgorithmIdentifier, KeyGenTestMode)[] AlgIdsECCP = [
            (UdfAlgorithmIdentifier.P256, KeyGenTestMode.SignEncrypt),
            (UdfAlgorithmIdentifier.P384, KeyGenTestMode.SignEncrypt),
            (UdfAlgorithmIdentifier.P521, KeyGenTestMode.SignEncrypt),
            ];






    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestUdf() {
        }




    [Fact]
    public void TestUdfKeygenML() {

        var testBinding = new AcvpTestBinding<UdfKeyGenTest>(UdfDirectoryML);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }
    [Fact]
    public void TestUdfKeygenECC() {

        var testBinding = new AcvpTestBinding<UdfKeyGenTest>(UdfDirectoryECC);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }

    [Fact(Skip = "Takes a very long time.")]
    public void TestUdfKeygenRSA() {

        var testBinding = new AcvpTestBinding<UdfKeyGenTest>(UdfDirectoryRSA);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }
    [Fact]
    public void TestUdfKeygenECCP() {

        var testBinding = new AcvpTestBinding<UdfKeyGenTest>(UdfDirectoryECCP);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }
    }

public class MakeUdf {


    /// <summary>
    /// Generate a set of test vectors
    /// </summary>
    public static void GenerateTests() {
        //GenerateTests(TestUdf.UdfDirectoryRSA, TestUdf.AlgIdsRSA);
        GenerateTests(TestUdf.UdfDirectoryML, TestUdf.AlgIdsML);
        GenerateTests(TestUdf.UdfDirectoryECC, TestUdf.AlgIdsECC);

        //GenerateTests(TestUdf.UdfDirectoryECCP, TestUdf.AlgIdsECCP);
        }

    private static void GenerateTests(string directory, 
                    (UdfAlgorithmIdentifier, KeyGenTestMode)[] algIds) {


        var keySizes = new int[] { 128, 192, 256 };

        var testsPer = 4;

        var file = new AcvpTestFile() {
            VsId = 1,
            Algorithm = "UDF",
            Mode = "KeyGen"
            };

        var testGroupId = 1;
        var testId = 1;
        foreach (var (algId, mode) in algIds) {
            var group = new AcvpTestGroup() {
                tgId = testGroupId++,
                };
            file.Add(group);

            foreach (var keySize in keySizes) {
                for (var i = 0; i < testsPer; i++) {

                    System.Console.WriteLine($"Test {testId}  {algId}, {keySize}");

                    // Discard hints for the last test
                    var test = new UdfKeyGenTest(testId++, algId, mode, keySize, i!= testsPer-1);
                    group.Add(test.TestData);

                    group.ParameterSet ??= test.KeyAlgorithm;
                    }
                }
            }
        var serializeOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
            };

        var filename = Path.Combine(directory, "internalProjection.json");
        Directory.CreateDirectory(directory);

        using var textStream = filename.OpenFileNew();
        var task = JsonSerializer.SerializeAsync(textStream, file, serializeOptions);
        task.Wait();

        }


    }