using System.Text.Json.Nodes;
using System.Xml.Serialization;

namespace Goedel.Serialization;

/// <summary>
/// The Form entry types
/// </summary>
public enum FieldType {
    Boolean,
    ArrayBoolean,
    Integer,
    ArrayInteger,
    String,
    ArrayString,
    Object,
    ArrayObject
    }




public interface ISerializable {
    SerialField[] Fields { get; } 
    }

public record SerialField(
            string Name,
            FieldType FieldType,
            Action<ISerializable, object?> Setter,
            Func<ISerializable, object?>? Getter=null,
            Func<ISerializable>? Factory = null,
            Func<object>? ListFactory = null,
            int CborCode = -1
            ) {
    }
public class Serialization {

    public static SerialField GetField(ISerializable data, string tag) {
        foreach (var field in data.Fields) {
            if (field.Name == tag) {
                return field;
                }
            }
        return null!;

        }
    public static void Deserialize(ISerializable 
            data,
            JsonNode? node) {

        if (node is JsonObject jsonObject) {
            Deserialize(data, jsonObject);
            }
        }
    public static void Deserialize(ISerializable data,
            JsonObject node) {

        foreach (var field in node) {
            var serial = GetField(data, field.Key);

            switch (serial.FieldType) {
                case FieldType.String: {
                    var value = GetString(field.Value);
                    serial.Setter(data, value);
                    break;
                    }
                case FieldType.ArrayString: {
                    var value = GetArrayString(field.Value);
                    serial.Setter(data, value);
                    break;
                    }
                case FieldType.Boolean: {
                    var value = GetBoolean(field.Value);
                    serial.Setter(data, value);
                    break;
                    }
                case FieldType.Integer: {
                    var value = GetInteger(field.Value);
                    serial.Setter(data, value);
                    break;
                    }
                case FieldType.Object: {
                    if (serial.Factory is not null) {
                        var value = serial.Factory();
                        Deserialize(value, field.Value);
                        serial.Setter(data, value);
                        }
                    break;
                    }
                case FieldType.ArrayObject: {
                    if ((serial.Factory is not null) && (serial.ListFactory is not null)) {
                        var value = serial.ListFactory();
                        DeserializeArrayObject(field.Value, value, serial.Factory);
                        serial.Setter(data, value);
                        }
                    break;
                    }
                }
            }
        }




    public static string? GetString(JsonNode? node) {
        if (!(node is JsonValue value)) {
            return null;
            }
        if (value.GetValueKind() != System.Text.Json.JsonValueKind.String) {
            return null;
            }
        return value.ToString();

        }


    public static List<string?>? GetArrayString(JsonNode? node) {
        if (!(node is JsonArray array)) {
            return null;
            }
        var result = new List<string?>();

        foreach (var field in array) {
            var value = GetString(field);
            result.Add(value);
            }
        return result;

        }





    public static bool? GetBoolean(JsonNode? node) {
        if (!(node is JsonValue value)) {
            return null;
            }

        value.TryGetValue<bool>(out var result);
        return result;

        }

    public static int? GetInteger(JsonNode? node) {
        if (!(node is JsonValue value)) {
            return null;
            }

        value.TryGetValue<int>(out var result);
        return result;
        }

    public static void DeserializeArrayObject(
                    JsonNode? node,
                    object list,
                    Func<ISerializable> factory) {
        if (!(node is JsonArray array)) {
            return;
            }
        foreach (var field in array) {
            var item = factory();
            Deserialize(item, field);

            var ilist = list as System.Collections.IList;
            ilist?.Add(item);

            }


        return;

        }

    }



public class Serialization<T> : Serialization where T : ISerializable, new() {




    public static void Serialize(
                T data,
                TextWriter stream,
                int indent = 0) {


        }


    public static T? Deserialize(
            string text) {
        var tree = JsonNode.Parse(text);
        if (tree is JsonObject root) {
            return Deserialize(root);
            }
        return default;
        }


    public static T Deserialize(
                JsonObject? node) {
        var result = new T();
        Deserialize(result, node);
        return result;
        }





    }



