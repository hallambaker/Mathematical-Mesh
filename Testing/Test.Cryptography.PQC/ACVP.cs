using Goedel.Cryptography.Jose;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

using Xunit.Sdk;

namespace Goedel.Test;

//#pragma warning disable IDE1006 // Naming Styles



public class TestBinding<T> where T : AcvpTest, new() {
    public static string RegistrationFile => "registration";
    public static string PromptFile => "prompt";
    public static string InternalProjectionFile => "internalProjection";
    public static string ExpectedResultsFile => "expectedResults";
    public static string ValidationFile => "validation";

    public Dictionary<int, T> Tests { get; } = new();

    //public Registration Registration { get; init; }

    public TestFile TestFile { get; init; }


    public TestBinding(string directory) {
        var serializeOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
            };

        // While five files are provided, the information we need is in just one.
        var jsonString = GetText(directory, InternalProjectionFile);
        TestFile = JsonSerializer.Deserialize<TestFile>(jsonString, serializeOptions);

        foreach (var group in TestFile.TestGroups) {
            foreach (var test in group.Tests) {
                var testDescription = new T();
                testDescription.Populate (group, test);
                Tests.Add (testDescription.TestId, testDescription);
                }
            }
        }

    string GetText (string directory, string file) {
        var regFile = Path.Combine(directory, file + ".json");
        return File.ReadAllText(regFile);
        }
    }

public class TestFile {
    public int VsId { get; set; }
    public string? Algorithm { get; set; }
    public string? Mode { get; set; }
    public string? Revision { get; set; }
    public bool IsSample { get; set; }

    public TestGroup[]? TestGroups { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }



public interface IExtensionData {
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }

public class TestGroup : IExtensionData {
    public int tgId { get; set; }
    public string? TestType { get; set; }
    public string? ParameterSet { get; set; }
    public string? Function { get; set; }
    public Test[]? Tests { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    }

public class Test: IExtensionData {
    public int TcId { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }





public abstract class AcvpTest {

    public TestGroup Group { get; set; }
    public Test Test { get; set; }


    public int GroupId => Group.tgId;
    public int TestId => Test.TcId;

    public AcvpTest() {
        }

    public virtual void Populate(TestGroup group, Test test) {
        Group = group;  
        Test = test;
        }


    protected byte[] BindBinary(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var value = jsonElement.GetString();
            var result = value.FromBase16();
            return result;
            }

        return null;
        }


    protected string BindString(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetString();
            return result;
            }

        return null;
        }

    protected bool? BindBool(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetBoolean();
            return result;
            }

        return null;
        }


    }

public class DsaKeyGenTest : AcvpTest { 

    public byte[] Seed { get; set; }

    public byte[] Pk { get; set; }

    public byte[] Sk { get; set; }

    public byte[] Z { get; set; }
    public override void Populate(TestGroup group, Test test) {
        base.Populate(group, test);
        Seed = BindBinary(test, "seed");
        Pk = BindBinary(test, "pk");
        Sk = BindBinary(test, "sk");
        Z = BindBinary(test, "z");
        }

    }
public class DsaSignTest : DsaKeyGenTest {

    public byte[] Message { get; set; }

    public byte[] Signature { get; set; }

    public byte[] Rnd { get; set; }

    public bool? Deterministic { get; set; }


    public override void Populate(TestGroup group, Test test) {
        base.Populate(group, test);
        Message = BindBinary(test, "message");
        Signature = BindBinary(test, "signature");
        Rnd = BindBinary(test, "rnd");
        Deterministic = BindBool(group, "deterministic");
        }

    }

public class DsaVerifyTest : DsaKeyGenTest {
    public byte[] Message { get; set; }

    public byte[] Signature { get; set; }

    public string Reason { get; set; }
    public bool? TestPassed { get; set; }

    public override void Populate(TestGroup group, Test test) {
        base.Populate(group, test);

        Pk = BindBinary(group, "pk");
        Sk = BindBinary(group, "sk");
        Message = BindBinary(test, "message");
        Signature = BindBinary(test, "signature");

        Reason = BindString(test, "reason");
        TestPassed = BindBool(test, "testPassed");
        }

    }




public class KemKeyGenTest : AcvpTest {

    public byte[] Z { get; set; }

    public byte[] D { get; set; }

    public byte[] EK { get; set; }

    public byte[] DK { get; set; }

    public override void Populate(TestGroup group, Test test) {
        base.Populate(group, test);
        Z = BindBinary(test, "z");
        D = BindBinary(test, "d");
        EK = BindBinary(test, "ek");
        DK = BindBinary(test, "dk");
        }

    }

public class KemEncapDecapTest : KemKeyGenTest {
    public byte[] C { get; set; }
    public byte[] M { get; set; }
    public byte[] K { get; set; }
    public string Reason { get; set; }
    public override void Populate(TestGroup group, Test test) {
        base.Populate(group, test);
        C = BindBinary(test, "c");
        M = BindBinary(test, "m");
        Reason = BindString(test, "reason");
        K = BindBinary(test, "k");
        }
    }







public class MessageLength {
    public int min { get; set; }
    public int max { get; set; }
    public int increment { get; set; }
    }
