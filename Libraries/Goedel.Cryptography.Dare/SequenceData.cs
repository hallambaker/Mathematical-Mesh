
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
//  This file was automatically generated at 1/30/2024 12:26:31 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22621.0
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
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"SequenceInfo", SequenceInfo._Factory},
	    {"SequenceIndex", SequenceIndex._Factory},
	    {"IndexPosition", IndexPosition._Factory},
	    {"KeyValue", KeyValue._Factory},
	    {"ProofChain", ProofChain._Factory}
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
	/// Information that describes the relationship of the envelope to its
	/// enclosing sequence.
	/// </summary>
public partial class SequenceInfo : SequenceData {
        /// <summary>
        ///Specifies the data encoding for the header section of for the following frames.
        ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
        /// </summary>

	public virtual string?						DataEncoding  {get; set;}

        /// <summary>
        ///Specifies the container type for the following records.
        ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
        /// </summary>

	public virtual string?						ContainerType  {get; set;}

        /// <summary>
        ///The record index within the file. This MUST be unique and 
        ///satisfy any additional requirements determined by the ContainerType.
        /// </summary>

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///If true, the current frame is a meta frame and does not contain a payload.
        ///Note: Meta frames MAY be present in any container. Applications MUST
        ///accept containers that contain meta frames at any position in the file.
        ///Applications MUST NOT interpret a meta frame as a data frame with an enpty payload.
        /// </summary>

	public virtual bool?						IsMeta  {get; set;}

        /// <summary>
        ///If set true in a persistent container, specifies that this record contains
        ///the default object for the container.
        /// </summary>

	public virtual bool?						Default  {get; set;}

        /// <summary>
        ///Position of the frame containing the apex of the preceding sub-tree.
        /// </summary>

	public virtual long?						TreePosition  {get; set;}

        /// <summary>
        ///Specifies the position in the file at which the last index entry is
        ///to be found
        /// </summary>

	public virtual long?						IndexPosition  {get; set;}

        /// <summary>
        ///Specifies the position in the file at which the key exchange data is
        ///to be found
        /// </summary>

	public virtual long?						ExchangePosition  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new SequenceInfo(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DataEncoding", new PropertyString ("DataEncoding", 
					(IBinding data, string? value) => {(data as SequenceInfo).DataEncoding = value;}, (IBinding data) => (data as SequenceInfo).DataEncoding )},
			{ "ContainerType", new PropertyString ("ContainerType", 
					(IBinding data, string? value) => {(data as SequenceInfo).ContainerType = value;}, (IBinding data) => (data as SequenceInfo).ContainerType )},
			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as SequenceInfo).Index = value;}, (IBinding data) => (data as SequenceInfo).Index )},
			{ "IsMeta", new PropertyBoolean ("IsMeta", 
					(IBinding data, bool? value) => {(data as SequenceInfo).IsMeta = value;}, (IBinding data) => (data as SequenceInfo).IsMeta )},
			{ "Default", new PropertyBoolean ("Default", 
					(IBinding data, bool? value) => {(data as SequenceInfo).Default = value;}, (IBinding data) => (data as SequenceInfo).Default )},
			{ "TreePosition", new PropertyInteger64 ("TreePosition", 
					(IBinding data, long? value) => {(data as SequenceInfo).TreePosition = value;}, (IBinding data) => (data as SequenceInfo).TreePosition )},
			{ "IndexPosition", new PropertyInteger64 ("IndexPosition", 
					(IBinding data, long? value) => {(data as SequenceInfo).IndexPosition = value;}, (IBinding data) => (data as SequenceInfo).IndexPosition )},
			{ "ExchangePosition", new PropertyInteger64 ("ExchangePosition", 
					(IBinding data, long? value) => {(data as SequenceInfo).ExchangePosition = value;}, (IBinding data) => (data as SequenceInfo).ExchangePosition )}
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
	public new const string __Tag = "SequenceInfo";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SequenceInfo();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SequenceInfo FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SequenceInfo;
			}
		var Result = new SequenceInfo ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


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

	public virtual bool?						Full  {get; set;}

        /// <summary>
        ///List of container position entries
        /// </summary>

	public virtual List<IndexPosition>?					Positions  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new SequenceIndex(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Full", new PropertyBoolean ("Full", 
					(IBinding data, bool? value) => {(data as SequenceIndex).Full = value;}, (IBinding data) => (data as SequenceIndex).Full )},
			{ "Positions", new PropertyListStruct ("Positions", 
					(IBinding data, object? value) => {(data as SequenceIndex).Positions = value as List<IndexPosition>;}, (IBinding data) => (data as SequenceIndex).Positions,
					false, ()=>new  List<IndexPosition>(), ()=>new IndexPosition())} 
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
	public new const string __Tag = "SequenceIndex";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SequenceIndex();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SequenceIndex FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SequenceIndex;
			}
		var Result = new SequenceIndex ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies the position in a file at which a specified record index is found
	/// </summary>
public partial class IndexPosition : SequenceData {
        /// <summary>
        ///The record index within the file.
        /// </summary>

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///The record position within the file relative to the index base.
        /// </summary>

	public virtual long?						Position  {get; set;}

        /// <summary>
        ///Unique object identifier
        /// </summary>

	public virtual string?						UniqueId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new IndexPosition(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as IndexPosition).Index = value;}, (IBinding data) => (data as IndexPosition).Index )},
			{ "Position", new PropertyInteger64 ("Position", 
					(IBinding data, long? value) => {(data as IndexPosition).Position = value;}, (IBinding data) => (data as IndexPosition).Position )},
			{ "UniqueId", new PropertyString ("UniqueId", 
					(IBinding data, string? value) => {(data as IndexPosition).UniqueId = value;}, (IBinding data) => (data as IndexPosition).UniqueId )}
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
	public new const string __Tag = "IndexPosition";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new IndexPosition();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new IndexPosition FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as IndexPosition;
			}
		var Result = new IndexPosition ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies a key/value entry
	/// </summary>
public partial class KeyValue : SequenceData {
        /// <summary>
        ///The key
        /// </summary>

	public virtual string?						Key  {get; set;}

        /// <summary>
        ///The value corresponding to the key
        /// </summary>

	public virtual string?						Value  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyValue(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as KeyValue).Key = value;}, (IBinding data) => (data as KeyValue).Key )},
			{ "Value", new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as KeyValue).Value = value;}, (IBinding data) => (data as KeyValue).Value )}
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
	public new const string __Tag = "KeyValue";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyValue();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new KeyValue FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyValue;
			}
		var Result = new KeyValue ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies a signature 
	/// </summary>
public partial class ProofChain : SequenceData {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProofChain(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

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
	public new const string __Tag = "ProofChain";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProofChain();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProofChain FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProofChain;
			}
		var Result = new ProofChain ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



