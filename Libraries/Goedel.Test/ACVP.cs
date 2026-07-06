namespace Goedel.Test;


/// <summary>
/// ACVP test data read from a file 'InternalProjectionFile.json' in JSON format.
/// </summary>
/// <typeparam name="T">The type of the test specific data.</typeparam>
public class AcvpTestBinding<T> where T : AcvpTest, new() {

    /// <summary>The projection file</summary>
    public static string InternalProjectionFile => "internalProjection";

    /// <summary>Dictionary maping test number to test</summary>
    public Dictionary<int, T> Tests { get; } = [];

    /// <summary>The test file.</summary>
    public AcvpTestFile TestFile { get; init; }

    readonly JsonSerializerOptions serializeOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
            };

    /// <summary>Constructor, produce an instance.</summary>
    /// <param name="directory">The test directory</param>
    public AcvpTestBinding(string directory) {


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

    /// <summary>Get test text.</summary>
    /// <param name="directory">Directory</param>
    /// <param name="file">File</param>
    /// <returns>The text.</returns>
    public string GetText(string directory, string file) {
        var regFile = Path.Combine(directory, file + ".json");
        return File.ReadAllText(regFile);
        }
    }

/// <summary>
/// Interface allowing access to extension data property.
/// </summary>
public interface IExtensionData {

    /// <summary>Extension data dictionary</summary>
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
    public List<AcvpTestGroup>? TestGroups { get; set; }


    ///<summary>Additional data.</summary> 
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    /// <summary>Add <paramref name="group"/></summary>
    /// <param name="group">The test group to add.</param>
    public void Add(AcvpTestGroup? group) {
        if (group is null) {
            return;
            }

        TestGroups ??= [];
        TestGroups.Add(group);
        }
    }




/// <summary>
/// Group root element, contains a series of tests
/// </summary>
public class AcvpTestGroup : IExtensionData {

    ///<summary>Slot to allow group data to be cached for use.</summary> 
    public object CachedData { get; set; }

    ///<summary>The test group identifier.</summary> 
    public int TgId { get; set; }

    ///<summary>The test type.</summary> 
    public string? TestType { get; set; }

    ///<summary>The parameter set being tested.</summary> 
    public string? ParameterSet { get; set; }

    ///<summary>The function being tested.</summary> 
    public string? Function { get; set; }

    ///<summary>The tests.</summary> 
    public List<AcvpTestItem>? Tests { get; set; }

    ///<summary>Additional data.</summary> 
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    /// <summary>Add <paramref name="item"/></summary>
    /// <param name="item">The test item to add.</param>
    public void Add(AcvpTestItem? item) {
        if (item is null) {
            return;
            }

        Tests ??= [];
        Tests.Add(item);
        }

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
/// binding data from <see cref="IExtensionData"/> to local properties in
/// <see cref="Populate(AcvpTestGroup, AcvpTestItem)"/>and
/// implementing a <see cref="Test"/> method.
/// </summary>
public abstract class AcvpTest {

    ///<summary>The test group data.</summary> 
    public AcvpTestGroup GroupData { get; set; }

    ///<summary>The test data.</summary> 
    public AcvpTestItem TestData { get; set; }


    ///<summary>The group identifier.</summary> 
    public int GroupId => GroupData.TgId;

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
    /// <see cref="IExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The result of decoding the field as hexadecimal data.</returns>
    protected static byte[] BindBinary(IExtensionData test, string key) {
        if (test.ExtensionData is null) {
            return null;
            }

        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var value = jsonElement.GetString();
            var result = value.FromBase16();
            return result;
            }

        return null;
        }

    /// <summary>
    /// Convenience method binding data from the field named  <paramref name="key"/>  in
    /// <see cref="IExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The string data.</returns>
    protected static string BindString(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetString();
            return result;
            }

        return null;
        }

    /// <summary>
    /// Convenience method binding data from the field named  <paramref name="key"/>  in
    /// <see cref="IExtensionData"/> of <paramref name="test"/> 
    /// </summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <returns>The boolean data.</returns>
    protected static bool? BindBool(IExtensionData test, string key) {
        if (test.ExtensionData.TryGetValue(key, out var jsonElement)) {
            var result = jsonElement.GetBoolean();
            return result;
            }

        return null;
        }


    /// <summary>Dind data from the field named  <paramref name="key"/> in 
    /// <paramref name="data"/> to <paramref name="test"/>.</summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <param name="data">The data</param>
    protected static void Bind(IExtensionData test, string key, string? data) {
        if (data is null) {
            return;
            }

        var element = JsonSerializer.SerializeToElement(data);
        test.ExtensionData ??= [];
        test.ExtensionData.Add(key, element);
        }

    /// <summary>Dind data from the field named  <paramref name="key"/> in 
    /// <paramref name="data"/> to <paramref name="test"/>.</summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <param name="data">The data</param>
    protected static void Bind(IExtensionData test, string key, byte[]? data) {
        if (data is null) {
            return;
            }

        var hexData = data.ToStringBase16();
        var element = JsonSerializer.SerializeToElement(hexData);
        test.ExtensionData ??= [];
        test.ExtensionData.Add(key, element);
        }

    /// <summary>Dind data from the field named  <paramref name="key"/> in 
    /// <paramref name="data"/> to <paramref name="test"/>.</summary>
    /// <param name="test">The test or group data to search.</param>
    /// <param name="key">The key to locate</param>
    /// <param name="data">The data</param>
    protected static void Bind(IExtensionData test, string key, bool? data) {
        if (data is null) {
            return;
            }

        var element = JsonSerializer.SerializeToElement(data);
        test.ExtensionData ??= [];
        test.ExtensionData.Add(key, element);
        }


    }
