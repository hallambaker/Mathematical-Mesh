using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Jose;
using Goedel.IO;

using System.Security.Cryptography;
using System.Text.Json;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestUdf : Disposable {


    public string Goedel_ACVP_Root => @"..\Goedel.Test.Vectors";

    public string UdfDirectory => Path.Combine(Goedel_ACVP_Root, "Udf");





    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestUdf() {
        }




    [Fact]
    public void TestUdfKeygen() {

        var testBinding = new AcvpTestBinding<UdfKeyGenTest>(UdfDirectory);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }



    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestUdf Test() => new();

    public void GenerateTests() {

        var algIds = new UdfAlgorithmIdentifier[] {

            //UdfAlgorithmIdentifier.P256,
            //UdfAlgorithmIdentifier.P384,
            //UdfAlgorithmIdentifier.P521,
            UdfAlgorithmIdentifier.RSA2048,
            UdfAlgorithmIdentifier.RSA3072,
            UdfAlgorithmIdentifier.RSA4096,
            //UdfAlgorithmIdentifier.MLDSA44,
            //UdfAlgorithmIdentifier.MLDSA65,
            //UdfAlgorithmIdentifier.MLDSA87,
            //UdfAlgorithmIdentifier.MLKEM512,
            //UdfAlgorithmIdentifier.MLKEM768,
            //UdfAlgorithmIdentifier.MLKEM1024,
            //UdfAlgorithmIdentifier.X25519,
            //UdfAlgorithmIdentifier.X448,
            //UdfAlgorithmIdentifier.Ed25519,
            //UdfAlgorithmIdentifier.Ed448

            };

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

        var filename = Path.Combine(UdfDirectory, "internalProjection.json");
        using var textStream = filename.OpenFileNew();
        var task = JsonSerializer.SerializeAsync(textStream, file, serializeOptions);
        task.Wait();

        }


    }