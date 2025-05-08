#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Cryptography.Nist;

using System.Text.Json;

namespace Goedel.Protocol;

/// <summary>
/// Untyped binding specification. The untyped binding provides the necessary factory,
/// sequence addition and key/value pair extraction functions for serialization and
/// deserialization.
/// </summary>
/// <param name="Properties">Dictionary mapping the property tag to the field specification.</param>
/// <param name="Tag">JSON tag for this object.</param>
/// <param name="Parent">Parent the object inherits from.</param>
/// <param name="TypeTag">Specifies the property name for the property specifying the type.</param>
public abstract record Binding(
            Dictionary<string, Property> Properties,
            string Tag,
            Binding Parent = null,
            string? TypeTag = null
            ) {

    ///<summary>Dictionary mapping child type tags to type definitions.</summary> 
    public Dictionary<string, Binding> TypeDictionary = [];

    ///<summary>Factory returning a new object.</summary> 
    public abstract Func<object> Factory { get; }

    ///<summary>Factory returning a new list of objects.</summary> 
    public abstract Func<object> ListFactory { get; }

    ///<summary>Factory returning a new Dictionary object.</summary> 
    public abstract Func<object> DictionaryFactory { get; }

    ///<summary>Action adding an element to a list of the bound type.</summary> 
    public abstract Action<object, object> ListAdd { get; }

    ///<summary>Action adding a key/value pair to a dictionary of the bound type.</summary> 
    public abstract Action<object, string, object> DictionaryAdd { get; }

    ///<summary>Return the key of a key/value pair.</summary> 
    public abstract Func<object, string> GetKey { get; }

    ///<summary>Return the value of a key/value pair.</summary> 
    public abstract Func<object, object> GetValue { get; }

    ///<summary>Dictionary binding sub classes to binding descriptions</summary> 
    public Dictionary<string, Binding>? ChildClasses = null;

    ///<summary>Dictionary binding all properties to binding descriptions</summary> 
    public Dictionary<string, Property> AllProperties = null;

    ///<summary>Dictionary binding all properties to binding descriptions</summary> 
    public Dictionary<string, Property> FullProperties => AllProperties ?? Properties;


    /// <summary>
    /// Parse the JSON element <paramref name="element"/> returning a JsonObject
    /// of the type specified by <paramref name="binding"/>.
    /// </summary>

    /// <param name="element">The document to parse.</param>
    /// <param name="binding">The type binding describing the object class.</param>
    /// <param name="collectUparsed">If true, collect up unknown elements in the 
    /// returned instance.</param>
    /// <returns>The parsed object.</returns>
    public static JsonObject Parse(
                JsonElementObject element,
                Binding binding,
                bool collectUparsed = false) {

        JsonObject? template = null;
        if (binding.TypeTag == null) {
            template = (JsonObject)binding.Factory();
            }
        else {
            if (element.TryGetProperty(binding.TypeTag, out var typeField)) {
                if (typeField is JsonElementString jsonElement) {
                    if (binding.TypeDictionary.TryGetValue(jsonElement.Value, out var subBinding)) {
                        template = (JsonObject)subBinding.Factory();
                        }
                    }
                }
            else {
                template = (JsonObject)binding.Factory();
                }
            }

        foreach (var property in element.Properties) {
            var collect = collectUparsed;
            if (template._AllProperties.TryGetValue(property.Key, out var propertyValue)) {
                collect &= MapProperty(template, property.Value, propertyValue);
                }
            if (collect) {
                template.UnparsedProperties ??= [];
                //template.UnparsedProperties.Add(property.Key, property.Value);
                }
            }

        return template;
        }



    static JsonObject ParseTagged(
                JsonElementObject element,
                Binding binding,
                bool collectUparsed = false)
        {
        (element.Properties.Count == 1).AssertTrue(NYI.Throw);
        foreach (var member in element.Properties) {
            if (binding.TypeDictionary.TryGetValue(member.Key, out var subBinding)) {


                if (member.Value is JsonElementObject child) {
                    return Parse(child, subBinding, collectUparsed);
                    }
                }
            return null;
            }
        return null;
        }

    /// <summary>
    /// Map the JSON element <paramref name="element"/> onto the object <paramref name="target"/>
    /// under the property description <paramref name="specifier"/>.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="element"></param>
    /// <param name="specifier"></param>
    /// <returns>True if successful, otherwise false.</returns>
    public static bool MapProperty(
                JsonObject target,
                JsonElement2 element,
                Property specifier) {

        switch (specifier) {
            #region // Boolean
            case PropertyBoolean subProperty: {
                if (element is JsonElementBoolean jsonElement) {
                    subProperty.Set(target, jsonElement.Value);
                    return true;
                    }
                return false;
                }
            case PropertyListBoolean subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<bool>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementBoolean jsonElement) {
                            array.Add(jsonElement.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryBoolean subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, bool>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementBoolean jsonElement) {
                            array.Add(member.Key, jsonElement.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // String

            case PropertyString subProperty: {
                if (element is JsonElementString jsonElement) {
                    subProperty.Set(target, jsonElement.Value);
                    return true;
                    }
                return false;
                }
            case PropertyListString subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<string>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementString jsonElement) {
                            array.Add(jsonElement.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryString subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, string>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementString jsonElement) {
                            array.Add(member.Key, jsonElement.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Int32
            case PropertyInteger32 subProperty: {
                if (element is JsonElementNumber jsonElement) {
                    subProperty.Set(target, jsonElement.GetInt32());
                    return true;
                    }
                return false;
                }
            case PropertyListInteger32 subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<int>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementNumber jsonElement) {
                            array.Add(jsonElement.GetInt32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryInteger32 subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, int>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementNumber jsonElement) {
                            array.Add(member.Key, jsonElement.GetInt32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Int64
            case PropertyInteger64 subProperty: {
                if (element is JsonElementNumber jsonElement) {
                    subProperty.Set(target, jsonElement.GetInt64());
                    return true;
                    }
                return false;
                }
            case PropertyListInteger64 subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<long>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementNumber jsonElement) {
                            array.Add(jsonElement.GetInt64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryInteger64 subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, long>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementNumber jsonElement) {
                            array.Add(member.Key, jsonElement.GetInt64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Real32
            case PropertyReal32 subProperty: {
                if (element is JsonElementNumber jsonElement) {
                    subProperty.Set(target, jsonElement.GetReal32());
                    return true;
                    }
                return false;
                }
            case PropertyListReal32 subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<float>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementNumber jsonElement) {
                            array.Add(jsonElement.GetReal32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryReal32 subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, float>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementNumber jsonElement) {
                            array.Add(member.Key, jsonElement.GetReal32());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Real64
            case PropertyReal64 subProperty: {
                if (element is JsonElementNumber jsonElement) {
                    subProperty.Set(target, jsonElement.GetReal64());
                    return true;
                    }
                return false;
                }
            case PropertyListReal64 subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<double>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementNumber jsonElement) {
                            array.Add(jsonElement.GetReal64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryReal64 subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, double>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementNumber jsonElement) {
                            array.Add(member.Key, jsonElement.GetReal64());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // DateTime
            case PropertyDateTime subProperty: {
                if (element is JsonElementDateTime jsonElement) {
                    subProperty.Set(target, jsonElement.Value);
                    return true;
                    }
                else if (element is JsonElementString jsonElementString) {
                    subProperty.Set(target, jsonElementString.GetDateTime());
                    }
                return false;
                }
            case PropertyListDateTime subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<DateTime>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementDateTime jsonElement) {
                            array.Add(jsonElement.Value);
                            }
                        else if (member is JsonElementString jsonElementString) {
                            array.Add(jsonElementString.GetDateTime());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryDateTime subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, DateTime>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementDateTime jsonElement) {
                            array.Add(member.Key, jsonElement.Value);
                            }
                        else if (member.Value is JsonElementString jsonElementString) {
                            array.Add(member.Key, jsonElementString.GetDateTime());
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Binary
            case PropertyBinary subProperty: {
                if (element is JsonElementString jsonElement) {
                    subProperty.Set(target, jsonElement.GetBinary());
                    return true;
                    }
                else if (element is JsonElementBinary jsonElementString) {
                    subProperty.Set(target, jsonElementString.Value);
                    return true;
                    }
                return false;
                }
            case PropertyListBinary subProperty: {
                if (element is JsonElementArray jsonArray) {
                    var collected = true;
                    var array = new List<byte[]>();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementString jsonElement) {
                            array.Add(jsonElement.GetBinary());
                            }
                        else if (member is JsonElementBinary jsonElementString) {
                            array.Add(jsonElementString.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryBinary subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    var collected = true;
                    var array = new Dictionary<string, byte[]>();
                    subProperty.Set(target, array);


                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementString jsonElement) {
                            array.Add(member.Key, jsonElement.GetBinary());
                            }
                        else if (member.Value is JsonElementBinary jsonElementString) {
                            array.Add(member.Key, jsonElementString.Value);
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            #region // Struct
            case PropertyStruct subProperty: {
                if (element is JsonElementObject jsonElement) {
                    if (!JsonObject.BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    if (subProperty.Tagged) {
                        var item = ParseTagged(jsonElement, binding);
                        subProperty.Set(target, item);
                        }
                    else {
                        var item = Parse(jsonElement, binding);
                        subProperty.Set(target, item);
                        }
                    }
                return false;
                }
            case PropertyListStruct subProperty: {
                if (element is JsonElementArray jsonArray) {
                    if (!JsonObject.BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    var collected = true;
                    var array = binding.ListFactory();
                    subProperty.Set(target, array);

                    foreach (var member in jsonArray.Items) {
                        if (member is JsonElementObject jsonElement) {

                            if (subProperty.Tagged) {
                                var item = ParseTagged(jsonElement, binding);
                                binding.ListAdd(array, item);
                                }
                            else {
                                var item = Parse(jsonElement, binding);
                                binding.ListAdd(array, item);
                                }
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            case PropertyDictionaryStruct subProperty: {
                if (element is JsonElementObject jsonDictionary) {
                    if (!JsonObject.BindingDictionary.TryGetValue(subProperty.Type, out var binding)) {
                        return false;
                        }
                    var collected = true;
                    var array = binding.DictionaryFactory();
                    subProperty.Set(target, array);


                    foreach (var member in jsonDictionary.Properties) {
                        if (member.Value is JsonElementObject jsonElement) {
                            if (subProperty.Tagged) {
                                var item = ParseTagged(jsonElement, binding);
                                binding.DictionaryAdd(array, member.Key, item);
                                }
                            else {
                                var item = Parse(jsonElement, binding);
                                binding.DictionaryAdd(array, member.Key, item);
                                }
                            }
                        else {
                            collected = false;
                            }
                        }
                    return collected;
                    }
                return false;
                }
            #endregion
            }

        return false;

        }


    }

/// <summary>
/// Binding specification.
/// </summary>
/// <param name="Properties">Dictionary mapping the property tag to the field specification.</param>
/// <param name="Tag">JSON tag for this object.</param>
/// <param name="Parent">Parent the object inherits from.</param>
/// <param name="OFactory">Object instance factory.</param>
/// <param name="LFactory">List instance factory.</param>
/// <param name="DFactory">Dictionary instance factory type.</param>
/// <param name="TypeTag">The type tag used to distinguish objects of this type.</param>
public record Binding<T>(
            Dictionary<string, Property> Properties,
            string Tag,
            Func<T> OFactory,
            Func<List<T>> LFactory,
            Func<Dictionary<string, T>> DFactory,
            Binding Parent = null,
            string? TypeTag = null
            ) : Binding(Properties, Tag, Parent, TypeTag) where T : class {

    ///<inheritdoc/>
    public override Func<object> Factory => () => OFactory();

    ///<inheritdoc/>
    public override Func<object> ListFactory => () => LFactory();

    ///<inheritdoc/>
    public override Func<object> DictionaryFactory => () => DFactory();

    ///<inheritdoc/>
    public override Func<object, string> GetKey =>
             (object pair) => {
                 var keyValue = (KeyValuePair<string, T>)pair;
                 return keyValue.Key;
             };

    ///<inheritdoc/>
    public override Func<object, object> GetValue =>
            (object pair) => {
                var keyValue = (KeyValuePair<string, T>)pair;
                return keyValue.Value;
            };

    ///<inheritdoc/>
    public override Action<object, object> ListAdd =>
            (object llist, object item) => {
                var list = llist as List<T>;
                list?.Add(item as T);
            };

    ///<inheritdoc/>
    public override Action<object, string, object> DictionaryAdd =>
            (object ldict, string key, object value) => {
                var list = ldict as Dictionary<string, T>;
                list?.Add(key, value as T);
            };
    }