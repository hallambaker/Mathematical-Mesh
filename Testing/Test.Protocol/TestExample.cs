
//  Copyright (c) 2016 by .
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
//  
//  
//  This file was automatically generated at 9/6/2024 1:45:05 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Protocol.Test;


	/// <summary>
	///
	/// Classes to be used to test serialization an deserialization.
	/// </summary>
public abstract partial class TestSchema : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TestSchema";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"MultiInstance", MultiInstance._Factory},
	    {"MultiArray", MultiArray._Factory},
	    {"MultiStruct", MultiStruct._Factory}
		};

    [ModuleInitializer]

    internal static void _Initialize() => AddDictionary(ref _tagDictionary);


	/// <summary>
    /// Construct an instance from the specified tagged JsonReader stream.
    /// </summary>
    /// <param name="jsonReader">Input stream</param>
    /// <param name="result">The created object</param>
    public static void Deserialize(JsonReader jsonReader, out JsonObject result) => 
		result = jsonReader.ReadTaggedObject(_TagDictionary);

	}



// Service Dispatch Classes



	// Transaction Classes
	/// <summary>
	///
	/// Contains one instance of each type of field.
	/// </summary>
public partial class MultiInstance : TestSchema {
        /// <summary>
        /// </summary>

	public virtual bool?						FieldBoolean  {get; set;}

        /// <summary>
        /// </summary>

	public virtual int?						FieldInteger  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						FieldDateTime  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						FieldString  {get; set;}

        /// <summary>
        /// </summary>

	public virtual byte[]?						FieldBinary  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MultiInstance(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "FieldBoolean", new PropertyBoolean ("FieldBoolean", 
					(IBinding data, bool? value) => {(data as MultiInstance).FieldBoolean = value;}, (IBinding data) => (data as MultiInstance).FieldBoolean )},
			{ "FieldInteger", new PropertyInteger32 ("FieldInteger", 
					(IBinding data, int? value) => {(data as MultiInstance).FieldInteger = value;}, (IBinding data) => (data as MultiInstance).FieldInteger )},
			{ "FieldDateTime", new PropertyDateTime ("FieldDateTime", 
					(IBinding data, DateTime? value) => {(data as MultiInstance).FieldDateTime = value;}, (IBinding data) => (data as MultiInstance).FieldDateTime )},
			{ "FieldString", new PropertyString ("FieldString", 
					(IBinding data, string? value) => {(data as MultiInstance).FieldString = value;}, (IBinding data) => (data as MultiInstance).FieldString )},
			{ "FieldBinary", new PropertyBinary ("FieldBinary", 
					(IBinding data, byte[]? value) => {(data as MultiInstance).FieldBinary = value;}, (IBinding data) => (data as MultiInstance).FieldBinary )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MultiInstance";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiInstance();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiInstance FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiInstance;
			}
		var Result = new MultiInstance ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MultiArray : MultiInstance {
        /// <summary>
        /// </summary>

	public virtual List<bool>?					ArrayBoolean  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<int>?					ArrayInteger  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DateTime>?					ArrayDateTime  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					ArrayString  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<byte[]>?					ArrayBinary  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MultiArray(), MultiInstance._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ArrayBoolean", new PropertyListBoolean ("ArrayBoolean", 
					(IBinding data, List<bool>? value) => {(data as MultiArray).ArrayBoolean = value;}, (IBinding data) => (data as MultiArray).ArrayBoolean )},
			{ "ArrayInteger", new PropertyListInteger32 ("ArrayInteger", 
					(IBinding data, List<int>? value) => {(data as MultiArray).ArrayInteger = value;}, (IBinding data) => (data as MultiArray).ArrayInteger )},
			{ "ArrayDateTime", new PropertyListDateTime ("ArrayDateTime", 
					(IBinding data, List<DateTime>? value) => {(data as MultiArray).ArrayDateTime = value;}, (IBinding data) => (data as MultiArray).ArrayDateTime )},
			{ "ArrayString", new PropertyListString ("ArrayString", 
					(IBinding data, List<string>? value) => {(data as MultiArray).ArrayString = value;}, (IBinding data) => (data as MultiArray).ArrayString )},
			{ "ArrayBinary", new PropertyListBinary ("ArrayBinary", 
					(IBinding data, List<byte[]>? value) => {(data as MultiArray).ArrayBinary = value;}, (IBinding data) => (data as MultiArray).ArrayBinary )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MultiInstance._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MultiArray";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiArray();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiArray FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiArray;
			}
		var Result = new MultiArray ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MultiStruct : MultiArray {
        /// <summary>
        /// </summary>

	public virtual MultiInstance?						FieldMultiInstance  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<MultiInstance>?					ArrayMultiInstance  {get; set;}
        /// <summary>
        /// </summary>

	public virtual MultiInstance?						TFieldMultiInstance  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<MultiInstance>?					TArrayMultiInstance  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MultiStruct(), MultiArray._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "FieldMultiInstance", new PropertyStruct ("FieldMultiInstance", 
					(IBinding data, object? value) => {(data as MultiStruct).FieldMultiInstance = value as MultiInstance;}, (IBinding data) => (data as MultiStruct).FieldMultiInstance,
					false, ()=>new  MultiInstance(), ()=>new MultiInstance())} ,
			{ "ArrayMultiInstance", new PropertyListStruct ("ArrayMultiInstance", 
					(IBinding data, object? value) => {(data as MultiStruct).ArrayMultiInstance = value as List<MultiInstance>;}, (IBinding data) => (data as MultiStruct).ArrayMultiInstance,
					false, ()=>new  List<MultiInstance>(), ()=>new MultiInstance())} ,
			{ "TFieldMultiInstance", new PropertyStruct ("TFieldMultiInstance", 
					(IBinding data, object? value) => {(data as MultiStruct).TFieldMultiInstance = value as MultiInstance;}, (IBinding data) => (data as MultiStruct).TFieldMultiInstance,
					true)} ,
			{ "TArrayMultiInstance", new PropertyListStruct ("TArrayMultiInstance", 
					(IBinding data, object? value) => {(data as MultiStruct).TArrayMultiInstance = value as List<MultiInstance>;}, (IBinding data) => (data as MultiStruct).TArrayMultiInstance,
					true, ()=>new List<MultiInstance>()
)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MultiArray._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MultiStruct";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MultiStruct();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MultiStruct FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MultiStruct;
			}
		var Result = new MultiStruct ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



