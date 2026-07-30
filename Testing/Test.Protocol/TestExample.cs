
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
//  This file was automatically generated at 7/26/2026 2:40:21 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0079 // Don't warn about unnecessary suppressions
#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
#pragma warning disable IDE1006 // Ignore naming rule violations
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(StoreUpdate), StoreUpdate._binding},
	    {typeof(TestEnveloped), TestEnveloped._binding},
	    {typeof(MultiInstance), MultiInstance._binding},
	    {typeof(MultiArray), MultiArray._binding},
	    {typeof(DictArray), DictArray._binding},
	    {typeof(MultiStruct), MultiStruct._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static TestSchema() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	/// </summary>
public partial class StoreUpdate : TestSchema {
    /// <summary>
    /// </summary>

	[JsonPropertyName("SomeString")]
	public virtual string?					SomeString  {get; set;} //

    /// <summary>
    ///The entries to be uploaded. 
    /// </summary>

	[JsonPropertyName("AnEnvelope")]
	public virtual Enveloped?					AnEnvelope  {get; set;} //

    /// <summary>
    ///The entries to be uploaded. 
    /// </summary>

	[JsonPropertyName("Envelopes")]
	public virtual List<Enveloped>?					Envelopes  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("SomeString", 
					(data, value) => {(data as StoreUpdate).SomeString = value;}, 
					data => (data as StoreUpdate).SomeString ),
		new PropertyStruct ("AnEnvelope", typeof (Enveloped),
					(data, value) => {(data as StoreUpdate).AnEnvelope = value as Enveloped;}, 
					data => (data as StoreUpdate).AnEnvelope,
					false, ()=>new  Enveloped(), ()=>new Enveloped()),
		new PropertyListStruct ("Envelopes", typeof (Enveloped),
					(data, value) => {(data as StoreUpdate).Envelopes = value as List<Enveloped>;}, 
					data => (data as StoreUpdate).Envelopes,
					false, ()=>new  List<Enveloped>(), ()=>new Enveloped())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StoreUpdate> _binding = new (
			new() {
			{ "SomeString", _properties [0]},
			{ "AnEnvelope", _properties [1]},
			{ "Envelopes", _properties [2]}}, __Tag,
		() => new StoreUpdate(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "StoreUpdate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new StoreUpdate();

	}


	/// <summary>
	///
	/// Base for generic envelope
	/// </summary>
public partial class TestEnveloped : TestSchema {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Header")]
	public virtual string?					Header  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Body")]
	public virtual string?					Body  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Trailer")]
	public virtual string?					Trailer  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Header", 
					(data, value) => {(data as TestEnveloped).Header = value;}, 
					data => (data as TestEnveloped).Header ),
		new PropertyString ("Body", 
					(data, value) => {(data as TestEnveloped).Body = value;}, 
					data => (data as TestEnveloped).Body ),
		new PropertyString ("Trailer", 
					(data, value) => {(data as TestEnveloped).Trailer = value;}, 
					data => (data as TestEnveloped).Trailer )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TestEnveloped> _binding = new (
			new() {
			{ "Header", _properties [0]},
			{ "Body", _properties [1]},
			{ "Trailer", _properties [2]}}, __Tag,
		() => new TestEnveloped(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TestEnveloped";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TestEnveloped();

	}


	/// <summary>
	///
	/// Contains one instance of each type of field.
	/// </summary>
public partial class MultiInstance : TestSchema {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("TestEnvelopedGeneric")]
	public virtual TestEnveloped<MultiInstance>?					TestEnvelopedGeneric  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual MultiInstance?				Generic  => TestEnvelopedGeneric.Decode();
    /// <summary>
    /// </summary>

	[JsonPropertyName("Type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldBoolean")]
	public virtual bool?					FieldBoolean  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldInteger")]
	public virtual int?					FieldInteger  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldFloat")]
	public virtual double?					FieldFloat  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldDateTime")]
	public virtual DateTime?					FieldDateTime  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldString")]
	public virtual string?					FieldString  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldBinary")]
	public virtual byte[]?					FieldBinary  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("TestEnvelopedGeneric", typeof (TestEnveloped),
					(data, value) => {(data as MultiInstance).TestEnvelopedGeneric = value as TestEnveloped<MultiInstance>;},
					data => (data as MultiInstance).TestEnvelopedGeneric,
					()=>new  TestEnveloped<MultiInstance>(), ()=>new TestEnveloped<MultiInstance>()),
		new PropertyStringTag ("Type", 
					(data, value) => {(data as MultiInstance).Type = value;}, 
					data => (data as MultiInstance).Type ),
		new PropertyBoolean ("FieldBoolean", 
					(data, value) => {(data as MultiInstance).FieldBoolean = value;}, 
					data => (data as MultiInstance).FieldBoolean ),
		new PropertyInteger32 ("FieldInteger", 
					(data, value) => {(data as MultiInstance).FieldInteger = value;}, 
					data => (data as MultiInstance).FieldInteger ),
		new PropertyReal64 ("FieldFloat", 
					(data, value) => {(data as MultiInstance).FieldFloat = value;}, 
					data => (data as MultiInstance).FieldFloat ),
		new PropertyDateTime ("FieldDateTime", 
					(data, value) => {(data as MultiInstance).FieldDateTime = value;}, 
					data => (data as MultiInstance).FieldDateTime ),
		new PropertyString ("FieldString", 
					(data, value) => {(data as MultiInstance).FieldString = value;}, 
					data => (data as MultiInstance).FieldString ),
		new PropertyBinary ("FieldBinary", 
					(data, value) => {(data as MultiInstance).FieldBinary = value;}, 
					data => (data as MultiInstance).FieldBinary )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MultiInstance> _binding = new (
			new() {
			{ "TestEnvelopedGeneric", _properties [0]},
			{ "Type", _properties [1]},
			{ "FieldBoolean", _properties [2]},
			{ "FieldInteger", _properties [3]},
			{ "FieldFloat", _properties [4]},
			{ "FieldDateTime", _properties [5]},
			{ "FieldString", _properties [6]},
			{ "FieldBinary", _properties [7]}}, __Tag,
		() => new MultiInstance(), () => [], () => [], null, 
		TypeTag:"Type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MultiArray : MultiInstance {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayBoolean")]
	public virtual List<bool>?					ArrayBoolean  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayInteger")]
	public virtual List<int>?					ArrayInteger  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayFloat")]
	public virtual List<double>?					ArrayFloat  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayDateTime")]
	public virtual List<DateTime>?					ArrayDateTime  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayString")]
	public virtual List<string>?					ArrayString  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayBinary")]
	public virtual List<byte[]>?					ArrayBinary  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListBoolean ("ArrayBoolean", 
					(data, value) => {(data as MultiArray).ArrayBoolean = value;}, 
					data => (data as MultiArray).ArrayBoolean ),
		new PropertyListInteger32 ("ArrayInteger", 
					(data, value) => {(data as MultiArray).ArrayInteger = value;}, 
					data => (data as MultiArray).ArrayInteger ),
		new PropertyListReal64 ("ArrayFloat", 
					(data, value) => {(data as MultiArray).ArrayFloat = value;}, 
					data => (data as MultiArray).ArrayFloat ),
		new PropertyListDateTime ("ArrayDateTime", 
					(data, value) => {(data as MultiArray).ArrayDateTime = value;}, 
					data => (data as MultiArray).ArrayDateTime ),
		new PropertyListString ("ArrayString", 
					(data, value) => {(data as MultiArray).ArrayString = value;}, 
					data => (data as MultiArray).ArrayString ),
		new PropertyListBinary ("ArrayBinary", 
					(data, value) => {(data as MultiArray).ArrayBinary = value;}, 
					data => (data as MultiArray).ArrayBinary )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MultiArray> _binding = new (
			new() {
			{ "ArrayBoolean", _properties [0]},
			{ "ArrayInteger", _properties [1]},
			{ "ArrayFloat", _properties [2]},
			{ "ArrayDateTime", _properties [3]},
			{ "ArrayString", _properties [4]},
			{ "ArrayBinary", _properties [5]}}, __Tag,
		() => new MultiArray(), () => [], () => [], MultiInstance._binding, 
		TypeTag:"Type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DictArray : MultiArray {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DictBoolean")]
	public virtual Dictionary<string,bool>?					DictBoolean  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DictInteger")]
	public virtual Dictionary<string,int>?					DictInteger  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DictFloat")]
	public virtual Dictionary<string,double>?					DictFloat  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DictDateTime")]
	public virtual Dictionary<string,DateTime>?					DictDateTime  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DictString")]
	public virtual Dictionary<string,string>?					DictString  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DictBinary")]
	public virtual Dictionary<string,byte[]>?					DictBinary  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDictionaryBoolean ("DictBoolean", 
					(data, value) => {(data as DictArray).DictBoolean = value;}, 
					data => (data as DictArray).DictBoolean ),
		new PropertyDictionaryInteger32 ("DictInteger", 
					(data, value) => {(data as DictArray).DictInteger = value;}, 
					data => (data as DictArray).DictInteger ),
		new PropertyDictionaryReal64 ("DictFloat", 
					(data, value) => {(data as DictArray).DictFloat = value;}, 
					data => (data as DictArray).DictFloat ),
		new PropertyDictionaryDateTime ("DictDateTime", 
					(data, value) => {(data as DictArray).DictDateTime = value;}, 
					data => (data as DictArray).DictDateTime ),
		new PropertyDictionaryString ("DictString", 
					(data, value) => {(data as DictArray).DictString = value;}, 
					data => (data as DictArray).DictString ),
		new PropertyDictionaryBinary ("DictBinary", 
					(data, value) => {(data as DictArray).DictBinary = value;}, 
					data => (data as DictArray).DictBinary )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DictArray> _binding = new (
			new() {
			{ "DictBoolean", _properties [0]},
			{ "DictInteger", _properties [1]},
			{ "DictFloat", _properties [2]},
			{ "DictDateTime", _properties [3]},
			{ "DictString", _properties [4]},
			{ "DictBinary", _properties [5]}}, __Tag,
		() => new DictArray(), () => [], () => [], MultiArray._binding, 
		TypeTag:"Type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DictArray";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DictArray();

	}


	/// <summary>
	/// </summary>
public partial class MultiStruct : MultiArray {
    /// <summary>
    /// </summary>

	[JsonPropertyName("FieldMultiInstance")]
	public virtual MultiInstance?					FieldMultiInstance  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ArrayMultiInstance")]
	public virtual List<MultiInstance>?					ArrayMultiInstance  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("TFieldMultiInstance")]
	public virtual MultiInstance?					TFieldMultiInstance  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("TArrayMultiInstance")]
	public virtual List<MultiInstance>?					TArrayMultiInstance  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("FieldMultiInstance", typeof (MultiInstance),
					(data, value) => {(data as MultiStruct).FieldMultiInstance = value as MultiInstance;}, 
					data => (data as MultiStruct).FieldMultiInstance,
					false, ()=>new  MultiInstance(), ()=>new MultiInstance()),
		new PropertyListStruct ("ArrayMultiInstance", typeof (MultiInstance),
					(data, value) => {(data as MultiStruct).ArrayMultiInstance = value as List<MultiInstance>;}, 
					data => (data as MultiStruct).ArrayMultiInstance,
					false, ()=>new  List<MultiInstance>(), ()=>new MultiInstance()),
		new PropertyStruct ("TFieldMultiInstance", typeof (MultiInstance), 
					(data, value) => {(data as MultiStruct).TFieldMultiInstance = value as MultiInstance;}, 
					data => (data as MultiStruct).TFieldMultiInstance,
					true) ,
		new PropertyListStruct ("TArrayMultiInstance", typeof (MultiInstance), 
					(data, value) => {(data as MultiStruct).TArrayMultiInstance = value as List<MultiInstance>;}, 
					data => (data as MultiStruct).TArrayMultiInstance,
					true, ()=>new List<MultiInstance>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MultiStruct> _binding = new (
			new() {
			{ "FieldMultiInstance", _properties [0]},
			{ "ArrayMultiInstance", _properties [1]},
			{ "TFieldMultiInstance", _properties [2]},
			{ "TArrayMultiInstance", _properties [3]}}, __Tag,
		() => new MultiStruct(), () => [], () => [], MultiArray._binding, 
		TypeTag:"Type" , Generic: false);


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

	}



