namespace Goedel.Test;


/// <summary>
/// ACVP test data read from a file 'InternalProjectionFile.json' in JSON format.
/// </summary>
/// <typeparam name="T">The type of the test specific data.</typeparam>
public class AcvpTestBinding<T> where T : AcvpTest, new() {
    public static string RegistrationFile => "registration";
    public static string PromptFile => "prompt";
    public static string InternalProjectionFile => "internalProjection";
    public static string ExpectedResultsFile => "expectedResults";
    public static string ValidationFile => "validation";

    public Dictionary<int, T> Tests { get; } = new();

    //public Registration Registration { get; init; }

    public AcvpTestFile TestFile { get; init; }


    public AcvpTestBinding(string directory) {
        var serializeOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
            };

        // While five files are provided, the information we need is in just one.
        var jsonString = GetText(directory, InternalProjectionFile);
        TestFile = JsonSerializer.Deserialize<AcvpTestFile>(jsonString, serializeOptions);

        foreach (var group in TestFile.TestGroups) {
            foreach (var test in group.Tests) {
                var testDescription = new T();
                testDescription.Populate(group, test);
                Tests.Add(testDescription.TestId, testDescription);
                }
            }
        }

    string GetText(string directory, string file) {
        var regFile = Path.Combine(directory, file + ".json");
        return File.ReadAllText(regFile);
        }
    }

/// <summary>
/// Interface allowing access to extension data property.
/// </summary>
public interface IExtensionData {
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }


/// <summary>
/// Test file deserialization root element.
/// </summary>
public class AcvpTestFile : IExtensionData {

    ///<summary>The numeric version number</summary> 
    public int VsId { get; set; }

    ///<summary>The algorithm name</summary> 
    public string? Algorithm { get; set; }

    ///<summary>The test mode.</summary> 
    public string? Mode { get; set; }

    ///<summary>The revision of the test subject</summary> 
    public string? Revision { get; set; }

    ///<summary>If true is sample data.</summary> 
    public bool? IsSample { get; set; }

    ///<summary>The test groups.</summary> 
    public AcvpTestGroup[]? TestGroups { get; set; }

    [JsonExtensionData]
    ///<summary>Additional data.</summary> 
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }




/// <summary>
/// Group root element, contains a series of tests
/// </summary>
public class AcvpTestGroup : IExtensionData {

    ///<summary>Slot to allow group data to be cached for use.</summary> 
    public object CachedData { get; set; }

    ///<summary>The test group identifier.</summary> 
    public int tgId { get; set; }

    ///<summary>The test type.</summary> 
    public string? TestType { get; set; }

    ///<summary>The parameter set being tested.</summary> 
    public string? ParameterSet { get; set; }

    ///<summary>The function being tested.</summary> 
    public string? Function { get; set; }

    ///<summary>The tests.</summary> 
    public AcvpTestItem[]? Tests { get; set; }

    [JsonExtensionData]
    ///<summary>Additional data.</summary> 
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    }

/// <summary>
/// Test item deserialization element.
/// </summary>
public class AcvpTestItem : IExtensionData {

    ///<summary>Test identifier.</summary> 
    public int TcId { get; set; }

    ///<summary>Additional data.</summary> 
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
    }

/// <summary>
/// The test item, this should be implemented for each specific test type, 
/// binding data from <see cref="ExtensionData"/> to local properties in
/// <see cref="Populate(AcvpTestGroup, AcvpTestItem)"/>and
/// implementing a <see cref="Test"/> method.
/// </summary>
public abstract class AcvpTest {

    ///<summary>The test group data.</summary> 
    public AcvpTestGroup GroupData { get; set; }

    ///<summary>The test data.</summary> 
    public AcvpTestItem TestData { get; set; }


    ///<summary>The group identifier.</summary> 
    public int GroupId => GroupData.tgId;

    ///<summary>The test identifier.</summary> 
    public int TestId => TestData.TcId;

    /// <summary>
    /// Is called during deserialization to bind data from the test specific fields
    /// to local properties.
    /// </summary>
    /// <param name="group">The test group read by the deserializer.</param>
    /// <param name="test">The test item read by the deserializer.</param>
    public virtual void Populate(AcvpTestGroup group, AcvpTestItem test) {
        GroupData = group;
        TestData = test;
        }

    /// <summary>
    /// Test method, is called to perform the test.
    /// </summary>
    public abstract void Test();

    /// <summary>
    /// Convenience method binding data from the field named  <paramref name="key"/>  in
    /// <see cref="ExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The result of decoding the field as hexadecimal data.</returns>
    protected byte[] BindBinary(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var value = jsonElement.GetString();
            var result = value.FromBase16();
            return result;
            }

        return null;
        }

    /// <summary>
    /// Convenience method binding data from the field named  <paramref name="key"/>  in
    /// <see cref="ExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The string data.</returns>
    protected string BindString(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetString();
            return result;
            }

        return null;
        }

    /// <summary>
    /// Convenience method binding data from the field named  <paramref name="key"/>  in
    /// <see cref="ExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The boolean data.</returns>
    protected bool? BindBool(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetBoolean();
            return result;
            }

        return null;
        }


    }
