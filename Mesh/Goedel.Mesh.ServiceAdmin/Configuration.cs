using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Goedel.Protocol.Service;

namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// Service/Host configuration.
/// </summary>
public class Configuration : Disposable {

    ///<summary>Maps configuration entry to configuration.</summary> 
    public Dictionary<string, object> Dictionary = new();



    ///<summary>The host configuration.</summary> 
    public GenericHostConfiguration GenericHostConfiguration { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public MeshServiceConfiguration MeshServiceConfiguration { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    //public CallsignRegistryConfiguration CallsignRegistryConfiguration { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public CallsignResolverConfiguration CallsignResolverConfiguration { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public CarnetServiceConfiguration CarnetServiceConfiguration { get; set; }
    ///<summary>The Mesh service configuration.</summary> 
    public RepositoryServiceConfiguration PersistanceServiceConfiguration { get; set; }

    ///<summary>The Mesh service configuration.</summary> 
    public PresenceServiceConfiguration PresenceServiceConfiguration { get; set; }


    JsonDocument JsonDocument { get;  init; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Configuration() {
        }

    ///<inheritdoc/>
    protected override void Disposing() {
        JsonDocument?.Dispose();
        }

    /// <summary>
    /// Read configuration from a file.
    /// </summary>
    /// <param name="path">The file name.</param>
    /// <returns>The parsed configuration.</returns>
    public static Configuration FromFile(string path) {
        using var stream = path.OpenFileReadShared();

        var config = new Configuration();
        var dom = JsonDocument.Parse(stream);

        var result = new Configuration() {
            JsonDocument = dom
            };

        result.MeshServiceConfiguration = result.Get<MeshServiceConfiguration>(MeshServiceConfiguration.ConfigurationEntry);
        result.GenericHostConfiguration = result.Get<GenericHostConfiguration>(GenericHostConfiguration.ConfigurationEntry);

        return result;
        }

    /// <summary>
    /// Get configuration entry described by <paramref name="configurationEntry"/>.
    /// </summary>
    /// <typeparam name="T">The returned type.</typeparam>
    /// <param name="configurationEntry">The configuration description.</param>
    /// <returns>The parsed configuration.</returns>
    public T Get<T>(ConfigurationEntry configurationEntry) where T : class {
        foreach (var entry in JsonDocument.RootElement.EnumerateObject()) {
            if (entry.Name == configurationEntry.Name) {
                var x = JsonSerializer.Deserialize(entry.Value, configurationEntry.Type);
                return x as T;
                }
            }
        return null;
        }

    /// <summary>
    /// Add a configuration entry to the configuration.
    /// </summary>
    /// <param name="configurationEntry">Configuration entry description.</param>
    /// <param name="entry">The entry.</param>
    public void Add(ConfigurationEntry configurationEntry, object entry) {
        Dictionary.Add(configurationEntry.Name, entry);


        if (configurationEntry.Name == MeshServiceConfiguration.ConfigurationEntry.Name) {
            MeshServiceConfiguration = entry as MeshServiceConfiguration;

            }
        if (configurationEntry.Name == GenericHostConfiguration.ConfigurationEntry.Name) {
            GenericHostConfiguration = entry as GenericHostConfiguration;

            }


        }

    /// <summary>
    /// Write configuration to file.
    /// </summary>
    /// <param name="path">The output filename.</param>
    public void ToFile(string path) {
        using var stream = path.OpenFileNew();

        var jsonOptions = new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            //Converters = {
            //    new JsonStringEnumConverter (JsonNamingPolicy.CamelCase, true)
            //    }
            };

        ////Console.WriteLine(JsonSerializer.Serialize<Dictionary<string, object>>(Dictionary, jsonOptions));
        JsonSerializer.Serialize (stream, Dictionary, jsonOptions);
        }



    }
