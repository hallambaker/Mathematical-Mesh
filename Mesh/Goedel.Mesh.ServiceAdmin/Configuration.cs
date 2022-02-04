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


public class MeshServiceConfiguration : GenericServiceConfiguration {

    public static readonly ConfigurationEntry ConfigurationEntry =
        new("MeshService", typeof(MeshServiceConfiguration),
            MeshService.Discovery, MeshService.WellKnown);

    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    public List<string> Administrators { get; set; } = new List<string>();

    public string? HostPath { get; set; } = null;

    }


public class Configuration : Disposable {

    public Dictionary<string, object> Dictionary = new();


    public MeshServiceConfiguration MeshServiceConfiguration { get; set; }

    public GenericHostConfiguration GenericHostConfiguration { get; set; }

    JsonDocument JsonDocument { get;  init; }






    public Configuration() {
        }

    protected override void Dispose(bool disposing) {
        JsonDocument?.Dispose();
        }

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


    public T Get<T>(ConfigurationEntry configurationEntry) where T : class {
        foreach (var entry in JsonDocument.RootElement.EnumerateObject()) {
            if (entry.Name == configurationEntry.Name) {
                var x = JsonSerializer.Deserialize(entry.Value, configurationEntry.Type);


                return x as T;
                }
            }
        return null;
        }


    public void Add(ConfigurationEntry configurationEntry, object entry) {
        Dictionary.Add(configurationEntry.Name, entry);
        }


    public void ToFile(string path) {
        using var stream = path.OpenFileNew();

        var jsonOptions = new JsonSerializerOptions() {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

        Console.WriteLine(JsonSerializer.Serialize<Dictionary<string, object>>(Dictionary, jsonOptions));


        JsonSerializer.Serialize (stream, Dictionary, jsonOptions);




        }



    }
