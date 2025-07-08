
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
//  This file was automatically generated at 7/8/2025 6:34:00 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26100.0
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

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Contacts;


	/// <summary>
	/// </summary>
public abstract partial class JmapBaseSchema : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JmapBaseSchema";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JmapBase), JmapBase._binding},
	    {typeof(Relation), Relation._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static JmapBaseSchema() {
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
public partial class JmapBase : JmapBaseSchema {
    /// <summary>
    /// This specifies the type that this object represents. The allowed value 
    /// differs by object type and is defined in Sections 2.1, 2.2, and 2.3.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    ///This is a globally unique identifier used to associate objects representing
    ///the same item. Updates to the document describing the same item MUST have the 
    ///same UID.
    /// </summary>

	[JsonPropertyName("uid")]
	public virtual string?					Uid  {get; set;} //

    /// <summary>
    ///An identifier for the product that last updated the JSCalendar 
    ///object. This should be set whenever the data in the object is modified 
    ///(i.e., whenever the updated property is set).
    /// </summary>

	[JsonPropertyName("prodId")]
	public virtual string?					ProdId  {get; set;} //

    /// <summary>
    ///The date and time this object was initially created.
    /// </summary>

	[JsonPropertyName("created")]
	public virtual DateTime?					Created  {get; set;} //

    /// <summary>
    ///The date and time this object was last modified.
    /// </summary>

	[JsonPropertyName("updated")]
	public virtual DateTime?					Updated  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as JmapBase).Type = value;}, 
					(IBinding data) => (data as JmapBase).Type ),
		new PropertyString ("uid", 
					(IBinding data, string? value) => {(data as JmapBase).Uid = value;}, 
					(IBinding data) => (data as JmapBase).Uid ),
		new PropertyString ("prodId", 
					(IBinding data, string? value) => {(data as JmapBase).ProdId = value;}, 
					(IBinding data) => (data as JmapBase).ProdId ),
		new PropertyDateTime ("created", 
					(IBinding data, DateTime? value) => {(data as JmapBase).Created = value;}, 
					(IBinding data) => (data as JmapBase).Created ),
		new PropertyDateTime ("updated", 
					(IBinding data, DateTime? value) => {(data as JmapBase).Updated = value;}, 
					(IBinding data) => (data as JmapBase).Updated )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JmapBase> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "uid", _properties [1]},
			{ "prodId", _properties [2]},
			{ "created", _properties [3]},
			{ "updated", _properties [4]}}, __Tag,
		() => new JmapBase(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JmapBase";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JmapBase();

	}


	/// <summary>
	/// </summary>
public partial class Relation : JmapBaseSchema {
    /// <summary>
    /// The relationships, each one MUST have the value true.
    /// </summary>

	[JsonPropertyName("relationships")]
	public virtual Dictionary<string,bool>?					Relationships  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDictionaryBoolean ("relationships", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Relation).Relationships = value;}, 
					(IBinding data) => (data as Relation).Relationships )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Relation> _binding = new (
			new() {
			{ "relationships", _properties [0]}}, __Tag,
		() => new Relation(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Relation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Relation();

	}



