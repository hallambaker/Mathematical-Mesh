
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
//  This file was automatically generated at 1/7/2026 2:23:03 PM
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

#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries

using Goedel.Mesh;


namespace Goedel.XUnit;


	/// <summary>
	///
	/// Classes that represent data written to the portal log.
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

	    {typeof(TestEntry), TestEntry._binding},
	    {typeof(TestItem), TestItem._binding},
	    {typeof(MessageTest), MessageTest._binding},
	    {typeof(CatalogEntryTest), CatalogEntryTest._binding}
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
	///
	/// An entry in the test log
	/// </summary>
abstract public partial class TestEntry : TestSchema {
    /// <summary>
    ///Time the pending item was created.
    /// </summary>

	[JsonPropertyName("Created")]
	public virtual DateTime?					Created  {get; set;} //

    /// <summary>
    ///Time the pending item was last modified.
    /// </summary>

	[JsonPropertyName("Modified")]
	public virtual DateTime?					Modified  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDateTime ("Created", 
					(data, value) => {(data as TestEntry).Created = value;}, 
					data => (data as TestEntry).Created ),
		new PropertyDateTime ("Modified", 
					(data, value) => {(data as TestEntry).Modified = value;}, 
					data => (data as TestEntry).Modified )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TestEntry> _binding = new (
			new() {
			{ "Created", _properties [0]},
			{ "Modified", _properties [1]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TestEntry";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();

	}


	/// <summary>
	///
	/// Test account...
	/// </summary>
public partial class TestItem : TestEntry {
    /// <summary>
    ///Some binary data
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //

    /// <summary>
    ///Assigned account identifier, e.g. 'alice@example.com'. Account names are 
    ///not case sensitive.
    /// </summary>

	[JsonPropertyName("AccountID")]
	public virtual string?					AccountID  {get; set;} //

    /// <summary>
    ///Fingerprint of associated user profile
    /// </summary>

	[JsonPropertyName("UserProfileUDF")]
	public virtual string?					UserProfileUDF  {get; set;} //

    /// <summary>
    ///Status of the account, valid values are 'Open', 'Closed',
    ///'Suspended'
    /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Data", 
					(data, value) => {(data as TestItem).Data = value;}, 
					data => (data as TestItem).Data ),
		new PropertyString ("AccountID", 
					(data, value) => {(data as TestItem).AccountID = value;}, 
					data => (data as TestItem).AccountID ),
		new PropertyString ("UserProfileUDF", 
					(data, value) => {(data as TestItem).UserProfileUDF = value;}, 
					data => (data as TestItem).UserProfileUDF ),
		new PropertyString ("Status", 
					(data, value) => {(data as TestItem).Status = value;}, 
					data => (data as TestItem).Status )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TestItem> _binding = new (
			new() {
			{ "Data", _properties [0]},
			{ "AccountID", _properties [1]},
			{ "UserProfileUDF", _properties [2]},
			{ "Status", _properties [3]}}, __Tag,
		() => new TestItem(), () => [], () => [], TestEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TestItem";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TestItem();

	}


	/// <summary>
	///
	/// Test message consiting of a chunk of data with a unique identifier deterministically
	/// Generated from the parameters Seed, Serial, Version and Length
	/// </summary>
public partial class MessageTest : Goedel.Mesh.Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("UniqueId")]
	public virtual string?					UniqueId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("VersionId")]
	public virtual string?					VersionId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Seed")]
	public virtual string?					Seed  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Serial")]
	public virtual int?					Serial  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Version")]
	public virtual int?					Version  {get; set;} //

    /// <summary>
    ///If specified, the entry was generated with random length setting.
    /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("UniqueId", 
					(data, value) => {(data as MessageTest).UniqueId = value;}, 
					data => (data as MessageTest).UniqueId ),
		new PropertyString ("VersionId", 
					(data, value) => {(data as MessageTest).VersionId = value;}, 
					data => (data as MessageTest).VersionId ),
		new PropertyString ("Seed", 
					(data, value) => {(data as MessageTest).Seed = value;}, 
					data => (data as MessageTest).Seed ),
		new PropertyInteger32 ("Serial", 
					(data, value) => {(data as MessageTest).Serial = value;}, 
					data => (data as MessageTest).Serial ),
		new PropertyInteger32 ("Version", 
					(data, value) => {(data as MessageTest).Version = value;}, 
					data => (data as MessageTest).Version ),
		new PropertyInteger32 ("Length", 
					(data, value) => {(data as MessageTest).Length = value;}, 
					data => (data as MessageTest).Length ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as MessageTest).Data = value;}, 
					data => (data as MessageTest).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageTest> _binding = new (
			new() {
			{ "UniqueId", _properties [0]},
			{ "VersionId", _properties [1]},
			{ "Seed", _properties [2]},
			{ "Serial", _properties [3]},
			{ "Version", _properties [4]},
			{ "Length", _properties [5]},
			{ "Data", _properties [6]}}, __Tag,
		() => new MessageTest(), () => [], () => [], Goedel.Mesh.Message._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MessageTest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageTest();

	}


	/// <summary>
	///
	/// Test message consiting of a chunk of data with a unique identifier deterministically
	/// Generated from the parameters Seed, Serial, Version and Length
	/// </summary>
public partial class CatalogEntryTest : Goedel.Mesh.CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("UniqueId")]
	public virtual string?					UniqueId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("VersionId")]
	public virtual string?					VersionId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Seed")]
	public virtual string?					Seed  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Serial")]
	public virtual int?					Serial  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Version")]
	public virtual int?					Version  {get; set;} //

    /// <summary>
    ///If specified, the 
    /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("UniqueId", 
					(data, value) => {(data as CatalogEntryTest).UniqueId = value;}, 
					data => (data as CatalogEntryTest).UniqueId ),
		new PropertyString ("VersionId", 
					(data, value) => {(data as CatalogEntryTest).VersionId = value;}, 
					data => (data as CatalogEntryTest).VersionId ),
		new PropertyString ("Seed", 
					(data, value) => {(data as CatalogEntryTest).Seed = value;}, 
					data => (data as CatalogEntryTest).Seed ),
		new PropertyInteger32 ("Serial", 
					(data, value) => {(data as CatalogEntryTest).Serial = value;}, 
					data => (data as CatalogEntryTest).Serial ),
		new PropertyInteger32 ("Version", 
					(data, value) => {(data as CatalogEntryTest).Version = value;}, 
					data => (data as CatalogEntryTest).Version ),
		new PropertyInteger32 ("Length", 
					(data, value) => {(data as CatalogEntryTest).Length = value;}, 
					data => (data as CatalogEntryTest).Length ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as CatalogEntryTest).Data = value;}, 
					data => (data as CatalogEntryTest).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogEntryTest> _binding = new (
			new() {
			{ "UniqueId", _properties [0]},
			{ "VersionId", _properties [1]},
			{ "Seed", _properties [2]},
			{ "Serial", _properties [3]},
			{ "Version", _properties [4]},
			{ "Length", _properties [5]},
			{ "Data", _properties [6]}}, __Tag,
		() => new CatalogEntryTest(), () => [], () => [], Goedel.Mesh.CatalogedEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogEntryTest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogEntryTest();

	}



