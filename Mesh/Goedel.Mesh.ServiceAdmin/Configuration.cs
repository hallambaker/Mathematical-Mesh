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

public class Configuration {

    public Dictionary<string, object> Dictionary = new();

    public static Configuration FromFile(string path) {
        using var stream = path.OpenFileReadShared();


        var config = new Configuration();
        using var dom = JsonDocument.Parse(stream);

        //var element = dom.RootElement.

        foreach (var entry in dom.RootElement.EnumerateObject()) {

            switch (entry.Name) {

                case "MeshService": {
                        var meshHostConfiguration = JsonSerializer.Deserialize(entry.Value, typeof(MeshHostConfiguration));
                        break;
                        }
                case "Host": {
                        var genericHostConfiguration = JsonSerializer.Deserialize(entry.Value, typeof(GenericHostConfiguration));
                        break;
                        }
                }


            }


        //var meshHostConfiguration = JsonSerializer.Deserialize(dom, typeof(GenericHostConfiguration));

        throw new NotImplementedException();
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
