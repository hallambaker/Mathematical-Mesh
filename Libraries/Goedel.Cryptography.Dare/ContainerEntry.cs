
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
//  This file was automatically generated at 19-Aug-22 3:51:30 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1015
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
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
	    {"KeyValue", KeyValue._Factory}
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

	public virtual string						DataEncoding  {get; set;}
        /// <summary>
        ///Specifies the container type for the following records.
        ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
        /// </summary>

	public virtual string						ContainerType  {get; set;}
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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DataEncoding" : {
				if (value is TokenValueString vvalue) {
					DataEncoding = vvalue.Value;
					}
				break;
				}
			case "ContainerType" : {
				if (value is TokenValueString vvalue) {
					ContainerType = vvalue.Value;
					}
				break;
				}
			case "Index" : {
				if (value is TokenValueInteger64 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "IsMeta" : {
				if (value is TokenValueBoolean vvalue) {
					IsMeta = vvalue.Value;
					}
				break;
				}
			case "Default" : {
				if (value is TokenValueBoolean vvalue) {
					Default = vvalue.Value;
					}
				break;
				}
			case "TreePosition" : {
				if (value is TokenValueInteger64 vvalue) {
					TreePosition = vvalue.Value;
					}
				break;
				}
			case "IndexPosition" : {
				if (value is TokenValueInteger64 vvalue) {
					IndexPosition = vvalue.Value;
					}
				break;
				}
			case "ExchangePosition" : {
				if (value is TokenValueInteger64 vvalue) {
					ExchangePosition = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "DataEncoding" : {
				return new TokenValueString (DataEncoding);
				}
			case "ContainerType" : {
				return new TokenValueString (ContainerType);
				}
			case "Index" : {
				return new TokenValueInteger64 (Index);
				}
			case "IsMeta" : {
				return new TokenValueBoolean (IsMeta);
				}
			case "Default" : {
				return new TokenValueBoolean (Default);
				}
			case "TreePosition" : {
				return new TokenValueInteger64 (TreePosition);
				}
			case "IndexPosition" : {
				return new TokenValueInteger64 (IndexPosition);
				}
			case "ExchangePosition" : {
				return new TokenValueInteger64 (ExchangePosition);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DataEncoding", new Property (typeof(TokenValueString), false)} ,
			{ "ContainerType", new Property (typeof(TokenValueString), false)} ,
			{ "Index", new Property (typeof(TokenValueInteger64), false)} ,
			{ "IsMeta", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Default", new Property (typeof(TokenValueBoolean), false)} ,
			{ "TreePosition", new Property (typeof(TokenValueInteger64), false)} ,
			{ "IndexPosition", new Property (typeof(TokenValueInteger64), false)} ,
			{ "ExchangePosition", new Property (typeof(TokenValueInteger64), false)} 
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

	public virtual List<IndexPosition>				Positions  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Full" : {
				if (value is TokenValueBoolean vvalue) {
					Full = vvalue.Value;
					}
				break;
				}
			case "Positions" : {
				if (value is TokenValueListStructObject vvalue) {
					Positions = vvalue.Value as List<IndexPosition>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Full" : {
				return new TokenValueBoolean (Full);
				}
			case "Positions" : {
				return new TokenValueListStruct<IndexPosition> (Positions);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Full", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Positions", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<IndexPosition>(), ()=>new IndexPosition(), false)} 
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

	public virtual string						UniqueId  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Index" : {
				if (value is TokenValueInteger64 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "Position" : {
				if (value is TokenValueInteger64 vvalue) {
					Position = vvalue.Value;
					}
				break;
				}
			case "UniqueId" : {
				if (value is TokenValueString vvalue) {
					UniqueId = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Index" : {
				return new TokenValueInteger64 (Index);
				}
			case "Position" : {
				return new TokenValueInteger64 (Position);
				}
			case "UniqueId" : {
				return new TokenValueString (UniqueId);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Index", new Property (typeof(TokenValueInteger64), false)} ,
			{ "Position", new Property (typeof(TokenValueInteger64), false)} ,
			{ "UniqueId", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Key  {get; set;}
        /// <summary>
        ///The value corresponding to the key
        /// </summary>

	public virtual string						Value  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Value" : {
				if (value is TokenValueString vvalue) {
					Value = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Value" : {
				return new TokenValueString (Value);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Value", new Property (typeof(TokenValueString), false)} 
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



