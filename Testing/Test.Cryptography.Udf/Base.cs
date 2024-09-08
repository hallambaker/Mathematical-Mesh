using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Test;

using System.Security.Cryptography;
using System.Text.Json;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestUdf : Disposable {


    public static string Goedel_ACVP_Root => Path.Combine(TestEnvironmentBase.CommonData,
                "Goedel.Test.Vectors");

    public static string UdfDirectoryML => Path.Combine(Goedel_ACVP_Root, "Udf.ML");
    public static string UdfDirectoryECC => Path.Combine(Goedel_ACVP_Root, "Udf.ECC");
    public static string UdfDirectoryRSA => Path.Combine(Goedel_ACVP_Root, "Udf.RSA"); 
    public static string UdfDirectoryECCP => Path.Combine(Goedel_ACVP_Root, "Udf.ECCP");

    public static UdfAlgorithmIdentifier[]  AlgIdsML = [
            UdfAlgorithmIdentifier.MLDSA44,
            UdfAlgorithmIdentifier.MLDSA65,
            UdfAlgorithmIdentifier.MLDSA87,
            UdfAlgorithmIdentifier.MLKEM512,
            UdfAlgorithmIdentifier.MLKEM768,
            UdfAlgorithmIdentifier.MLKEM1024,
            ];

    public static UdfAlgorithmIdentifier[] AlgIdsRSA = [
            UdfAlgorithmIdentifier.RSA2048,
            UdfAlgorithmIdentifier.RSA3072,
            UdfAlgorithmIdentifier.RSA4096,
            ];

    public static UdfAlgorithmIdentifier[] AlgIdsECC = [
            UdfAlgorithmIdentifier.X25519,
            UdfAlgorithmIdentifier.X448,
            UdfAlgorithmIdentifier.Ed25519,
            UdfAlgorithmIdentifier.Ed448
            ];

    public static UdfAlgorithmIdentifier[] AlgIdsECCP = [
            UdfAlgorithmIdentifier.P256,
            UdfAlgorithmIdentifier.P384,
            UdfAlgorithmIdentifier.P521,
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


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestUdf Test() => new();

    public static void GenerateTests() {
        GenerateTests(UdfDirectoryRSA, AlgIdsRSA);
        GenerateTests(UdfDirectoryML, AlgIdsML);
        GenerateTests(UdfDirectoryECC, AlgIdsECC);

        GenerateTests(UdfDirectoryECCP, AlgIdsECCP);
        }

    private static void GenerateTests(string directory, UdfAlgorithmIdentifier[] algIds) {


        var keySizes = new int[] { 128, 192, 256 };

        var testsPer = 4;

        var file = new AcvpTestFile() {
            VsId = 1,
            Algorithm = "UDF",
            Mode = "KeyGen"
            };

        var testGroupId = 1;
        var testId = 1;
        foreach (var algId in algIds) {
            var group = new AcvpTestGroup() {
                tgId = testGroupId++,
                };
            file.Add(group);

            foreach (var keySize in keySizes) {
                for (var i = 0; i < testsPer; i++) {

                    System.Console.WriteLine($"Test {testId}  {algId}, {keySize}");

                    var test = new UdfKeyGenTest(testId++, algId, keySize);
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