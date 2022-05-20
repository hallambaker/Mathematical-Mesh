
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
//  This file was automatically generated at 20-May-22 5:55:46 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.971
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

using Goedel.Cryptography.Dare;
using Goedel.Mesh;


namespace Goedel.Callsign;


	/// <summary>
	///
	/// Entries that may appear in the Callsign registry log. Three types of entry 
	/// are currently defined: Entries relating to registration and transfer of callsigns,
	/// Entries relating to descriptions of callsign character pages and entries relating
	/// to cross notarization of the log by third parties.
	/// </summary>
public abstract partial class CallsignEntry : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignEntry";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ProfileRegistry", ProfileRegistry._Factory},
	    {"Registration", Registration._Factory},
	    {"CatalogedRegistration", CatalogedRegistration._Factory},
	    {"Page", Page._Factory},
	    {"CharacterSpan", CharacterSpan._Factory},
	    {"Canonical", Canonical._Factory},
	    {"MapChar", MapChar._Factory},
	    {"MapString", MapString._Factory},
	    {"Notarization", Notarization._Factory},
	    {"Challenge", Challenge._Factory},
	    {"CallsignRegistrationRequest", CallsignRegistrationRequest._Factory},
	    {"CallsignRegistrationResponse", CallsignRegistrationResponse._Factory},
	    {"ProcessResultCallsignRegistration", ProcessResultCallsignRegistration._Factory}
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
	/// Describes a callsign registry.
	/// </summary>
public partial class ProfileRegistry : ProfileAccount {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProfileRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileRegistry();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ProfileAccount)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileRegistry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileRegistry;
			}
		var Result = new ProfileRegistry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// A callsign or Notarization registration
	/// </summary>
public partial class Registration : CallsignEntry {
        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The signed callsign binding
        /// </summary>

	public virtual Enveloped<CallsignBinding>						Entry  {get; set;}
        /// <summary>
        ///The UTC time instant that the claim was submitted.
        /// </summary>

	public virtual DateTime?						Submitted  {get; set;}
        /// <summary>
        ///Callsign of the registrar that made the registration request
        /// </summary>

	public virtual string						Registrar  {get; set;}
        /// <summary>
        ///If present, specifies a previous registration with the same identifier.
        /// </summary>

	public virtual string						PriorId  {get; set;}
        /// <summary>
        ///Reason for creating a registration:
        ///Initial/ Update/ Voluntary/ Administrative/ Revoke
        /// </summary>

	public virtual string						Reason  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "Entry", new MetaDataStruct(
				delegate (object _a) {  Entry = _a as Enveloped<CallsignBinding>; },
				() => Entry,
				"Enveloped<CallsignBinding>" )} ,
			{ "Submitted", new MetaDataDateTime(
				delegate (DateTime? _a) {  Submitted = _a; },
				() => Submitted) } ,
			{ "Registrar", new MetaDataString(
				delegate (string _a) {  Registrar = _a; },
				() => Registrar) } ,
			{ "PriorId", new MetaDataString(
				delegate (string _a) {  PriorId = _a; },
				() => PriorId) } ,
			{ "Reason", new MetaDataString(
				delegate (string _a) {  Reason = _a; },
				() => Reason) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Registration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Registration();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (Entry != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Entry", 1);
				Entry.Serialize (_writer, false);
			}
		if (Submitted != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Submitted", 1);
				_writer.WriteDateTime (Submitted);
			}
		if (Registrar != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Registrar", 1);
				_writer.WriteString (Registrar);
			}
		if (PriorId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PriorId", 1);
				_writer.WriteString (PriorId);
			}
		if (Reason != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Reason", 1);
				_writer.WriteString (Reason);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Registration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Registration;
			}
		var Result = new Registration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "Entry" : {
				// An untagged structure
				Entry = new Enveloped<CallsignBinding> ();
				Entry.Deserialize (jsonReader);
 
				break;
				}
			case "Submitted" : {
				Submitted = jsonReader.ReadDateTime ();
				break;
				}
			case "Registrar" : {
				Registrar = jsonReader.ReadString ();
				break;
				}
			case "PriorId" : {
				PriorId = jsonReader.ReadString ();
				break;
				}
			case "Reason" : {
				Reason = jsonReader.ReadString ();
				break;
				}
			default : {
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedRegistration : CatalogedEntry {
        /// <summary>
        ///The canonical form of the callsign.
        /// </summary>

	public virtual string						Canonical  {get; set;}
        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The registration entry for the item.
        /// </summary>

	public virtual Enveloped<Registration>						EnvelopedRegistration  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Canonical", new MetaDataString(
				delegate (string _a) {  Canonical = _a; },
				() => Canonical) } ,
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "EnvelopedRegistration", new MetaDataStruct(
				delegate (object _a) {  EnvelopedRegistration = _a as Enveloped<Registration>; },
				() => EnvelopedRegistration,
				"Enveloped<Registration>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedRegistration();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Canonical != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Canonical", 1);
				_writer.WriteString (Canonical);
			}
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (EnvelopedRegistration != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedRegistration", 1);
				EnvelopedRegistration.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedRegistration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedRegistration;
			}
		var Result = new CatalogedRegistration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Canonical" : {
				Canonical = jsonReader.ReadString ();
				break;
				}
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedRegistration" : {
				// An untagged structure
				EnvelopedRegistration = new Enveloped<Registration> ();
				EnvelopedRegistration.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class Page : CallsignEntry {
        /// <summary>
        ///Character page identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///Additional allowed pages.
        /// </summary>

	public virtual List<string>				Allow  {get; set;}
        /// <summary>
        ///Characters permitted within this code page.
        /// </summary>

	public virtual List<CharacterSpan>				CharacterSpans  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "Allow", new MetaDataListString(
				delegate (List<string> _a) {  Allow = _a; },
				() => Allow) } ,
			{ "CharacterSpans", new MetaDataListStruct(
				delegate (object _a) {  CharacterSpans = _a as List<CharacterSpan>; },
				() => CharacterSpans,
				"CharacterSpan", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Page";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Page();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (Allow != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Allow", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Allow) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (CharacterSpans != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CharacterSpans", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CharacterSpans) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Page FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Page;
			}
		var Result = new Page ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "Allow" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Allow = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Allow.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "CharacterSpans" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CharacterSpans = new List <CharacterSpan> ();
				while (_Going) {
					var _Item = CharacterSpan.FromJson (jsonReader, true); // a tagged structure
					CharacterSpans.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class CharacterSpan : CallsignEntry {
        /// <summary>
        ///The first character in the range (inclusive)
        /// </summary>

	public virtual int?						First  {get; set;}
        /// <summary>
        ///The last character in the range (inclusive), if ommitted or
        ///equal to zero, this is the same as Last.
        /// </summary>

	public virtual int?						Last  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "First", new MetaDataInteger32(
				delegate (int? _a) {  First = _a; },
				() => First) } ,
			{ "Last", new MetaDataInteger32(
				delegate (int? _a) {  Last = _a; },
				() => Last) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CharacterSpan";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CharacterSpan();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (First != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("First", 1);
				_writer.WriteInteger32 (First);
			}
		if (Last != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Last", 1);
				_writer.WriteInteger32 (Last);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CharacterSpan FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CharacterSpan;
			}
		var Result = new CharacterSpan ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "First" : {
				First = jsonReader.ReadInteger32 ();
				break;
				}
			case "Last" : {
				Last = jsonReader.ReadInteger32 ();
				break;
				}
			default : {
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Canonical character span.
	/// </summary>
public partial class Canonical : CharacterSpan {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Canonical";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Canonical();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((CharacterSpan)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Canonical FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Canonical;
			}
		var Result = new Canonical ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Specifies a variant mapping the range of characters First..First+n to
	/// a range of characters Target..Target+n. Where n = Last - First+1
	/// </summary>
public partial class MapChar : CharacterSpan {
        /// <summary>
        ///The character that First is mapped to.
        /// </summary>

	public virtual int?						Target  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Target", new MetaDataInteger32(
				delegate (int? _a) {  Target = _a; },
				() => Target) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MapChar";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapChar();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((CharacterSpan)this).SerializeX(_writer, false, ref _first);
		if (Target != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Target", 1);
				_writer.WriteInteger32 (Target);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MapChar FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MapChar;
			}
		var Result = new MapChar ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Target" : {
				Target = jsonReader.ReadInteger32 ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Specifies a mapping of non canonical characters in the range specified by 
	/// First..Last to the string Target.
	/// </summary>
public partial class MapString : CharacterSpan {
        /// <summary>
        ///Specifies a character string that the Source character(s) are mapped to.
        ///If count is greater than 1, all the characters map to the same string.
        /// </summary>

	public virtual string						Target  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Target", new MetaDataString(
				delegate (string _a) {  Target = _a; },
				() => Target) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MapString";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapString();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((CharacterSpan)this).SerializeX(_writer, false, ref _first);
		if (Target != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Target", 1);
				_writer.WriteString (Target);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MapString FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MapString;
			}
		var Result = new MapString ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Target" : {
				Target = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class Notarization : CallsignEntry {
        /// <summary>
        ///Enveloped witness value of a specific append only log.
        /// </summary>

	public virtual List<Enveloped<Witness>>				Entries  {get; set;}
        /// <summary>
        ///Proof path validating the previous notary token that was entered in the
        ///log.
        /// </summary>

	public virtual Proof						Proof  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Entries", new MetaDataListStruct(
				delegate (object _a) {  Entries = _a as List<Enveloped<Witness>>; },
				() => Entries,
				"Enveloped<Witness>" )} ,
			{ "Proof", new MetaDataStruct(
				delegate (object _a) {  Proof = _a as Proof; },
				() => Proof,
				"Proof" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Notarization";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Notarization();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		if (Entries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Entries", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Entries) {
				_writer.WriteArraySeparator (ref _firstarray);
				// This is an untagged structure. Cannot inherit.
                //_writer.WriteObjectStart();
                //_writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                //_writer.WriteObjectEnd();
				}
			_writer.WriteArrayEnd ();
			}

		if (Proof != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Proof", 1);
				Proof.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Notarization FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Notarization;
			}
		var Result = new Notarization ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Entries" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Entries = new List <Enveloped<Witness>> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Enveloped<Witness> ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Enveloped<Witness> (jsonReader);
					Entries.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Proof" : {
				// An untagged structure
				Proof = new Proof ();
				Proof.Deserialize (jsonReader);
 
				break;
				}
			default : {
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Registers a challenge to one or more callsigns that have been registered.
	/// </summary>
public partial class Challenge : Assertion {
        /// <summary>
        ///The callsigns subject to challenge
        /// </summary>

	public virtual List<string>				Subjects  {get; set;}
        /// <summary>
        ///The basis for the challenge
        /// </summary>

	public virtual List<string>				Basis  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Subjects", new MetaDataListString(
				delegate (List<string> _a) {  Subjects = _a; },
				() => Subjects) } ,
			{ "Basis", new MetaDataListString(
				delegate (List<string> _a) {  Basis = _a; },
				() => Basis) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Challenge";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Challenge();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Subjects != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Subjects", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Subjects) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Basis != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Basis", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Basis) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Challenge FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Challenge;
			}
		var Result = new Challenge ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Subjects" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Subjects = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Subjects.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Basis" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Basis = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Basis.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Connection request message. This message contains the information
	/// </summary>
public partial class CallsignRegistrationRequest : MessageValidated {
        /// <summary>
        ///The enveloped binnding of the callsign to the profile.	
        /// </summary>

	public virtual Enveloped<CallsignBinding>						EnvelopedCallsignBinding  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedCallsignBinding", new MetaDataStruct(
				delegate (object _a) {  EnvelopedCallsignBinding = _a as Enveloped<CallsignBinding>; },
				() => EnvelopedCallsignBinding,
				"Enveloped<CallsignBinding>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignRegistrationRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationRequest();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((MessageValidated)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedCallsignBinding != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedCallsignBinding", 1);
				EnvelopedCallsignBinding.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignRegistrationRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignRegistrationRequest;
			}
		var Result = new CallsignRegistrationRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedCallsignBinding" : {
				// An untagged structure
				EnvelopedCallsignBinding = new Enveloped<CallsignBinding> ();
				EnvelopedCallsignBinding.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class CallsignRegistrationResponse : Message {
        /// <summary>
        ///True if and only if a new registration was created.
        /// </summary>

	public virtual bool?						Registered  {get; set;}
        /// <summary>
        ///The resulting catalog entry if accepted or the prior registration otherwise.
        /// </summary>

	public virtual CatalogedRegistration						CatalogedRegistration  {get; set;}
        /// <summary>
        ///Reason for refusing the registration.
        /// </summary>

	public virtual string						Reason  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Registered", new MetaDataBoolean(
				delegate (bool? _a) {  Registered = _a; },
				() => Registered) } ,
			{ "CatalogedRegistration", new MetaDataStruct(
				delegate (object _a) {  CatalogedRegistration = _a as CatalogedRegistration; },
				() => CatalogedRegistration,
				"CatalogedRegistration" )} ,
			{ "Reason", new MetaDataString(
				delegate (string _a) {  Reason = _a; },
				() => Reason) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignRegistrationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationResponse();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Registered != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Registered", 1);
				_writer.WriteBoolean (Registered);
			}
		if (CatalogedRegistration != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedRegistration", 1);
				CatalogedRegistration.Serialize (_writer, false);
			}
		if (Reason != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Reason", 1);
				_writer.WriteString (Reason);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignRegistrationResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignRegistrationResponse;
			}
		var Result = new CallsignRegistrationResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Registered" : {
				Registered = jsonReader.ReadBoolean ();
				break;
				}
			case "CatalogedRegistration" : {
				// An untagged structure
				CatalogedRegistration = new CatalogedRegistration ();
				CatalogedRegistration.Deserialize (jsonReader);
 
				break;
				}
			case "Reason" : {
				Reason = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class ProcessResultCallsignRegistration : ProcessResult {
        /// <summary>
        /// </summary>

	public virtual CallsignRegistrationResponse						CallsignRegistrationResponse  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "CallsignRegistrationResponse", new MetaDataStruct(
				delegate (object _a) {  CallsignRegistrationResponse = _a as CallsignRegistrationResponse; },
				() => CallsignRegistrationResponse,
				"CallsignRegistrationResponse" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProcessResultCallsignRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultCallsignRegistration();


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ProcessResult)this).SerializeX(_writer, false, ref _first);
		if (CallsignRegistrationResponse != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CallsignRegistrationResponse", 1);
				CallsignRegistrationResponse.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResultCallsignRegistration FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResultCallsignRegistration;
			}
		var Result = new ProcessResultCallsignRegistration ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CallsignRegistrationResponse" : {
				// An untagged structure
				CallsignRegistrationResponse = new CallsignRegistrationResponse ();
				CallsignRegistrationResponse.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}



