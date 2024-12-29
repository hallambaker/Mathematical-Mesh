using Goedel.Discovery;

using System.Text.Json.Serialization;
using System.Text.Json;

namespace Goedel.Protocol.Service;


/// <summary>
/// Service configuration
/// </summary>
public interface IServiceConfiguration {
    ///<summary>Maps configuration entry to configuration.</summary> 
    public Dictionary<string, object> Dictionary { get; }

    ///<summary>The host configuration.</summary> 
    public GenericHostConfiguration GenericHost { get; set; }

    /// <summary>
    /// Add a configuration entry to the configuration.
    /// </summary>
    /// <param name="entry">The entry.</param>
    /// 
    public void Add(IConfigurationEntry entry);

    /// <summary>
    /// Write configuration to file.
    /// </summary>
    /// <param name="path">The output filename.</param>
    public void ToFile(string path) {
        using var stream = path.OpenFileNew();

        var jsonOptions = new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        JsonSerializer.Serialize(stream, Dictionary, jsonOptions);
        }
    }

