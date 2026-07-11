using System.Text;
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
    ArrayObject,
    DictionaryObject
    }




public interface ISerializable {
    SerialField[] Fields { get; } 
    }


public interface ISerializableKeyed {
    string? Key { get; }
    }

public record SerialField(
            string Name,
            FieldType FieldType,
            Action<ISerializable, object?> Setter,
            Func<ISerializable, object?> Getter,
            Func<ISerializable>? Factory = null,
            Func<object>? CollectionFactory = null,
            int CborCode = -1
            ) {
    }
public  class Serialization {

    public static SerialField GetField(ISerializable data, string tag) {
        foreach (var field in data.Fields) {
            if (field.Name == tag) {
                return field;
                }
            }
        return null!;

        }

 



    public static void Deserialize( ISerializable 
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
            if (serial != null) {
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
                        if ((serial.Factory is not null) && (serial.CollectionFactory is not null)) {
                            var value = serial.CollectionFactory();
                            DeserializeArrayObject(field.Value, value, serial.Factory);
                            serial.Setter(data, value);
                            }
                        break;
                        }
                    case FieldType.DictionaryObject: {
                        if ((serial.Factory is not null) && (serial.CollectionFactory is not null)) {
                            var value = serial.CollectionFactory();
                            DeserializeDictionaryObject(field.Value, value, serial.Factory);
                            serial.Setter(data, value);
                            }
                        break;
                        }
                    }
                }
            }
        }




    public static string? GetString(JsonNode? node) {
        if (node is not JsonValue value) {
            return null;
            }
        if (value.GetValueKind() != System.Text.Json.JsonValueKind.String) {
            return null;
            }
        return value.ToString();

        }


    public static List<string?>? GetArrayString(JsonNode? node) {
        if (node is not JsonArray array) {
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
        if (node is not JsonValue value) {
            return null;
            }

        value.TryGetValue<bool>(out var result);
        return result;

        }

    public static int? GetInteger(JsonNode? node) {
        if (node is not JsonValue value) {
            return null;
            }

        value.TryGetValue<int>(out var result);
        return result;
        }

    public static void DeserializeArrayObject(
                    JsonNode? node,
                    object list,
                    Func<ISerializable> factory) {
        if (node is not JsonArray array) {
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

    public static void DeserializeDictionaryObject(
                JsonNode? node,
                object list,
                Func<ISerializable> factory) {
        if (node is not JsonArray array ) {
            return;
            }
        foreach (var field in array) {
            var item = factory();
            Deserialize(item, field);

            var ilist = list as System.Collections.IDictionary;
            var key = (item as ISerializableKeyed)?.Key;

            if (key != null) {
                ilist?.Add(key, item);
                }
            }


        return;

        }




    }



//public class Serialization<T> : Serialization where T : ISerializable, new() {

 


//    public static void Serialize(
//                T data,
//                TextWriter stream,
//                int indent = 0) {


//        }


//    public static T? Deserialize(
//            string text) {
//        var tree = JsonNode.Parse(text);
//        if (tree is JsonObject root) {
//            return Deserialize(root);
//            }
//        return default;
//        }


//    public static T Deserialize(
//                JsonObject? node) {
//        var result = new T();
//        if (node is not null) {
//            Deserialize(result, node);
//            }
//        return result;
//        }


//    }


public static class Extensions {


    static void Indent(StringBuilder builder, int indent, ref bool first) {
        if (!first) {
            builder.Append(',');
            }
        first = false;
        if (indent >= 0) {
            builder.Append('\n');
            }
        for (int i = 0; i < indent; i++) {
            builder.Append("  ");
            }
        }

    /// <summary>
    /// Return the next indent value. If <paramref name="indent"/> is less than 0, the value is -1,
    /// otherwise, the value is indent + 1
    /// </summary>
    /// <param name="indent">The current indent level.</param>
    /// <returns>The next indent level.</returns>
    static int NextIndent(int indent) => indent < 0 ? -1 : indent + 1;

    public static string Serialize(this ISerializable data, int indent = 0) {

        var builder = new StringBuilder();

        //Indent(builder, indent, false);
        builder.Append('{');
        indent = NextIndent(indent);

        var first = true;
        foreach (var field in data.Fields) {
            if (field is not null) {
                switch (field.FieldType) {
                    case FieldType.Integer: {
                        if (field?.Getter(data) is int value) {
                            Indent(builder, indent, ref first);
                            builder.Append('"');
                            builder.Append(field.Name);
                            builder.Append("\": ");
                            builder.Append(value);
                            }
                        break;
                        }
                    case FieldType.String: {
                        if (field?.Getter(data) is string value) {
                            Indent(builder, indent, ref first);
                            builder.Append('"');
                            builder.Append(field.Name);
                            builder.Append("\": \"");
                            builder.Append(value);
                            builder.Append('"');
                            }
                        break;
                        }
                    }
                }
            }

        first = true;
        Indent(builder, indent, ref first);
        builder.Append("}\n");

        return builder.ToString();
        }

    }


