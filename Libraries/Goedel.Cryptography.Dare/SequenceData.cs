
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
//  This file was automatically generated at 1/7/2026 2:22:35 PM
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

using Goedel.Cryptography.Jose;


namespace Goedel.Cryptography.Dare;


	/// <summary>
	///
	/// Classes that describe the DARE Sequence Format.
	/// </summary>
public abstract partial class SequenceData : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SequenceData";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(SequenceInfo), SequenceInfo._binding},
	    {typeof(SequenceIndex), SequenceIndex._binding},
	    {typeof(IndexPosition), IndexPosition._binding},
	    {typeof(KeyValue), KeyValue._binding},
	    {typeof(ProofChain), ProofChain._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static SequenceData() {
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
	/// Information that describes the relationship of the envelope to its
	/// enclosing sequence.
	/// </summary>
public partial class SequenceInfo : SequenceData {
    /// <summary>
    ///Specifies the data encoding for the header section of for the following frames.
    ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
    /// </summary>

	[JsonPropertyName("DataEncoding")]
	public virtual string?					DataEncoding  {get; set;} //

    /// <summary>
    ///Specifies the container type for the following records.
    ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
    /// </summary>

	[JsonPropertyName("ContainerType")]
	public virtual string?					ContainerType  {get; set;} //

    /// <summary>
    ///The record index within the file. This MUST be unique and 
    ///satisfy any additional requirements determined by the ContainerType.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///If true, the current frame is a meta frame and does not contain a payload.
    ///Note: Meta frames MAY be present in any container. Applications MUST
    ///accept containers that contain meta frames at any position in the file.
    ///Applications MUST NOT interpret a meta frame as a data frame with an enpty payload.
    /// </summary>

	[JsonPropertyName("IsMeta")]
	public virtual bool?					IsMeta  {get; set;} //

    /// <summary>
    ///If set true in a persistent container, specifies that this record contains
    ///the default object for the container.
    /// </summary>

	[JsonPropertyName("Default")]
	public virtual bool?					Default  {get; set;} //

    /// <summary>
    ///Position of the frame containing the apex of the preceding sub-tree.
    /// </summary>

	[JsonPropertyName("TreePosition")]
	public virtual long?					TreePosition  {get; set;} //

    /// <summary>
    ///Specifies the position in the file at which the last index entry is
    ///to be found
    /// </summary>

	[JsonPropertyName("IndexPosition")]
	public virtual long?					IndexPosition  {get; set;} //

    /// <summary>
    ///Specifies the position in the file at which the key exchange data is
    ///to be found
    /// </summary>

	[JsonPropertyName("ExchangePosition")]
	public virtual long?					ExchangePosition  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("DataEncoding", 
					(data, value) => {(data as SequenceInfo).DataEncoding = value;}, 
					data => (data as SequenceInfo).DataEncoding ),
		new PropertyString ("ContainerType", 
					(data, value) => {(data as SequenceInfo).ContainerType = value;}, 
					data => (data as SequenceInfo).ContainerType ),
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as SequenceInfo).Index = value;}, 
					data => (data as SequenceInfo).Index ),
		new PropertyBoolean ("IsMeta", 
					(data, value) => {(data as SequenceInfo).IsMeta = value;}, 
					data => (data as SequenceInfo).IsMeta ),
		new PropertyBoolean ("Default", 
					(data, value) => {(data as SequenceInfo).Default = value;}, 
					data => (data as SequenceInfo).Default ),
		new PropertyInteger64 ("TreePosition", 
					(data, value) => {(data as SequenceInfo).TreePosition = value;}, 
					data => (data as SequenceInfo).TreePosition ),
		new PropertyInteger64 ("IndexPosition", 
					(data, value) => {(data as SequenceInfo).IndexPosition = value;}, 
					data => (data as SequenceInfo).IndexPosition ),
		new PropertyInteger64 ("ExchangePosition", 
					(data, value) => {(data as SequenceInfo).ExchangePosition = value;}, 
					data => (data as SequenceInfo).ExchangePosition )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SequenceInfo> _binding = new (
			new() {
			{ "DataEncoding", _properties [0]},
			{ "ContainerType", _properties [1]},
			{ "Index", _properties [2]},
			{ "IsMeta", _properties [3]},
			{ "Default", _properties [4]},
			{ "TreePosition", _properties [5]},
			{ "IndexPosition", _properties [6]},
			{ "ExchangePosition", _properties [7]}}, __Tag,
		() => new SequenceInfo(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SequenceInfo";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SequenceInfo();

	}


	/// <summary>
	///
	/// A record providing an index to the sequence.
	/// </summary>
public partial class SequenceIndex : SequenceData {
    /// <summary>
    ///If true, the index is complete and contains position entries for all the 
    ///frames in the file. If absent or false, the index is incremental and only
    ///contains position entries for records added since the last 
    ///frame containing a ContainerIndex.
    /// </summary>

	[JsonPropertyName("Full")]
	public virtual bool?					Full  {get; set;} //

    /// <summary>
    ///List of container position entries
    /// </summary>

	[JsonPropertyName("Positions")]
	public virtual List<IndexPosition>?					Positions  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Full", 
					(data, value) => {(data as SequenceIndex).Full = value;}, 
					data => (data as SequenceIndex).Full ),
		new PropertyListStruct ("Positions", typeof (IndexPosition),
					(data, value) => {(data as SequenceIndex).Positions = value as List<IndexPosition>;}, 
					data => (data as SequenceIndex).Positions,
					false, ()=>new  List<IndexPosition>(), ()=>new IndexPosition())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SequenceIndex> _binding = new (
			new() {
			{ "Full", _properties [0]},
			{ "Positions", _properties [1]}}, __Tag,
		() => new SequenceIndex(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SequenceIndex";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SequenceIndex();

	}


	/// <summary>
	///
	/// Specifies the position in a file at which a specified record index is found
	/// </summary>
public partial class IndexPosition : SequenceData {
    /// <summary>
    ///The record index within the file.
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///The record position within the file relative to the index base.
    /// </summary>

	[JsonPropertyName("Position")]
	public virtual long?					Position  {get; set;} //

    /// <summary>
    ///Unique object identifier
    /// </summary>

	[JsonPropertyName("UniqueId")]
	public virtual string?					UniqueId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as IndexPosition).Index = value;}, 
					data => (data as IndexPosition).Index ),
		new PropertyInteger64 ("Position", 
					(data, value) => {(data as IndexPosition).Position = value;}, 
					data => (data as IndexPosition).Position ),
		new PropertyString ("UniqueId", 
					(data, value) => {(data as IndexPosition).UniqueId = value;}, 
					data => (data as IndexPosition).UniqueId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<IndexPosition> _binding = new (
			new() {
			{ "Index", _properties [0]},
			{ "Position", _properties [1]},
			{ "UniqueId", _properties [2]}}, __Tag,
		() => new IndexPosition(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "IndexPosition";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new IndexPosition();

	}


	/// <summary>
	///
	/// Specifies a key/value entry
	/// </summary>
public partial class KeyValue : SequenceData {
    /// <summary>
    ///The key
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    ///The value corresponding to the key
    /// </summary>

	[JsonPropertyName("Value")]
	public virtual string?					Value  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as KeyValue).Key = value;}, 
					data => (data as KeyValue).Key ),
		new PropertyString ("Value", 
					(data, value) => {(data as KeyValue).Value = value;}, 
					data => (data as KeyValue).Value )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyValue> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Value", _properties [1]}}, __Tag,
		() => new KeyValue(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyValue";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyValue();

	}


	/// <summary>
	///
	/// Specifies a signature 
	/// </summary>
public partial class ProofChain : SequenceData {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProofChain> _binding = new (
			new() {}, __Tag,
		() => new ProofChain(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProofChain";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProofChain();

	}



