
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
//  This file was automatically generated at 03-May-22 7:47:40 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.877
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

	    {"Callsign", Callsign._Factory},
	    {"Registration", Registration._Factory},
	    {"Page", Page._Factory},
	    {"CharacterSpan", CharacterSpan._Factory},
	    {"Canonical", Canonical._Factory},
	    {"MapChar", MapChar._Factory},
	    {"MapString", MapString._Factory},
	    {"Notarization", Notarization._Factory},
	    {"ProfileDns", ProfileDns._Factory},
	    {"SecurityPolicy", SecurityPolicy._Factory},
	    {"Accreditation", Accreditation._Factory},
	    {"Challenge", Challenge._Factory}
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
	/// A callsign entry
	/// </summary>
public partial class Callsign : CallsignEntry {
        /// <summary>
        ///The callsign identifier in canonical form used for query.
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The callsign identifier in the prefered presentation form.
        /// </summary>

	public virtual string						Presentation  {get; set;}
        /// <summary>
        ///The UDF of the holder's root of trust
        /// </summary>

	public virtual string						Holder  {get; set;}
        /// <summary>
        ///This callsign is an alias for another registered callsign.
        /// </summary>

	public virtual string						Alias  {get; set;}
        /// <summary>
        ///The callsign or DNS address of the service provider
        /// </summary>

	public virtual string						Service  {get; set;}
        /// <summary>
        ///Address(es) of a DNS service that resolves the authoritative domain 
        ///'id.mesh'.
        /// </summary>

	public virtual List<string>				Dns  {get; set;}
        /// <summary>
        ///The Mesh Account profile to which the callsign belongs.
        /// </summary>

	public virtual ProfileAccount						Account  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Callsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Callsign();


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
		if (Presentation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Presentation", 1);
				_writer.WriteString (Presentation);
			}
		if (Holder != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Holder", 1);
				_writer.WriteString (Holder);
			}
		if (Alias != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Alias", 1);
				_writer.WriteString (Alias);
			}
		if (Service != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Service", 1);
				_writer.WriteString (Service);
			}
		if (Dns != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Dns", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Dns) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Account != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Account", 1);
				Account.Serialize (_writer, false);
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
    public static new Callsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Callsign;
			}
		var Result = new Callsign ();
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
			case "Presentation" : {
				Presentation = jsonReader.ReadString ();
				break;
				}
			case "Holder" : {
				Holder = jsonReader.ReadString ();
				break;
				}
			case "Alias" : {
				Alias = jsonReader.ReadString ();
				break;
				}
			case "Service" : {
				Service = jsonReader.ReadString ();
				break;
				}
			case "Dns" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Dns = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Dns.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Account" : {
				// An untagged structure
				Account = new ProfileAccount ();
				Account.Deserialize (jsonReader);
 
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
	/// A callsign or Notarization registration
	/// </summary>
public partial class Registration : CallsignEntry {
        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///Envelope containing the item that has been registered.
        /// </summary>

	public virtual Enveloped<CallsignEntry>						Entry  {get; set;}
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
				Entry = new Enveloped<CallsignEntry> ();
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
	bool								__First = false;
	private int						_First;
        /// <summary>
        ///The first character in the range (inclusive)
        /// </summary>

	public virtual int						First {
		get => _First;
		set {_First = value; __First = true; }
		}
	bool								__Last = false;
	private int						_Last;
        /// <summary>
        ///The last character in the range (inclusive), if ommitted or
        ///equal to zero, this is the same as Last.
        /// </summary>

	public virtual int						Last {
		get => _Last;
		set {_Last = value; __Last = true; }
		}
		
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
		if (__First){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("First", 1);
				_writer.WriteInteger32 (First);
			}
		if (__Last){
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
	bool								__Target = false;
	private int						_Target;
        /// <summary>
        ///The character that First is mapped to.
        /// </summary>

	public virtual int						Target {
		get => _Target;
		set {_Target = value; __Target = true; }
		}
		
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
		if (__Target){
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
	/// 
	/// </summary>
public partial class ProfileDns : Profile {
        /// <summary>
        ///Specify TLS policies for use in the zone.
        /// </summary>

	public virtual List<SecurityPolicy>				SecurityPolicies  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProfileDns";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileDns();


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
		((Profile)this).SerializeX(_writer, false, ref _first);
		if (SecurityPolicies != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SecurityPolicies", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in SecurityPolicies) {
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
    public static new ProfileDns FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileDns;
			}
		var Result = new ProfileDns ();
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
			case "SecurityPolicies" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				SecurityPolicies = new List <SecurityPolicy> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  SecurityPolicy ();
					_Item.Deserialize (jsonReader);
					// var _Item = new SecurityPolicy (jsonReader);
					SecurityPolicies.Add (_Item);
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
	/// </summary>
public partial class SecurityPolicy : CallsignEntry {
        /// <summary>
        ///The DNS zone(s) to which this policy applies.
        /// </summary>

	public virtual List<string>				CName  {get; set;}
        /// <summary>
        ///IANA protocol name, e.g. SMTP, SUBMIT, HTTP, HTTPS, etc.		
        /// </summary>

	public virtual List<string>				Protocol  {get; set;}
        /// <summary>
        ///Enhancements that are supported for the specified protocol. 
        ///Allowed values include none/ tls1.2/ tls1.3/ http3/ dnssec
        /// </summary>

	public virtual List<string>				Enhancements  {get; set;}
	bool								__Require = false;
	private bool						_Require;
        /// <summary>
        ///If true, clients MUST use one of the supported enhancements.		
        /// </summary>

	public virtual bool						Require {
		get => _Require;
		set {_Require = value; __Require = true; }
		}
        /// <summary>
        ///Keys specifying roots of trust for the specified protocol(s).
        /// </summary>

	public virtual List<KeyData>				Roots  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SecurityPolicy";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SecurityPolicy();


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
		if (CName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CName", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CName) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Protocol != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Protocol", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Protocol) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Enhancements != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Enhancements", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Enhancements) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (__Require){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Require", 1);
				_writer.WriteBoolean (Require);
			}
		if (Roots != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Roots", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Roots) {
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
    public static new SecurityPolicy FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SecurityPolicy;
			}
		var Result = new SecurityPolicy ();
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
			case "CName" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CName = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					CName.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Protocol" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Protocol = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Protocol.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Enhancements" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Enhancements = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Enhancements.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Require" : {
				Require = jsonReader.ReadBoolean ();
				break;
				}
			case "Roots" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Roots = new List <KeyData> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  KeyData ();
					_Item.Deserialize (jsonReader);
					// var _Item = new KeyData (jsonReader);
					Roots.Add (_Item);
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
	///
	/// Registration of a trusted third party accreditation
	/// </summary>
public partial class Accreditation : Assertion {
        /// <summary>
        ///The callsigns to which the accreditation applies
        /// </summary>

	public virtual string						Callsign  {get; set;}
        /// <summary>
        ///The validated names of the subject
        /// </summary>

	public virtual List<string>				SubjectNames  {get; set;}
        /// <summary>
        ///Mesh strong URIs from which a validated logo belonging to the 
        ///subject MAY be retreived and validated.
        /// </summary>

	public virtual List<string>				SubjectLogos  {get; set;}
        /// <summary>
        ///The time the assertion was issued.
        /// </summary>

	public virtual DateTime?						Issued  {get; set;}
        /// <summary>
        ///The time the assertion is due to expire
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}
        /// <summary>
        ///The issuing policy under which the validation was performed.
        /// </summary>

	public virtual string						Policy  {get; set;}
        /// <summary>
        ///The issuing practices under which the validation was performed.
        /// </summary>

	public virtual string						Practice  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Accreditation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Accreditation();


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
		if (Callsign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Callsign", 1);
				_writer.WriteString (Callsign);
			}
		if (SubjectNames != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SubjectNames", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in SubjectNames) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (SubjectLogos != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SubjectLogos", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in SubjectLogos) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Issued != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Issued", 1);
				_writer.WriteDateTime (Issued);
			}
		if (Expires != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Expires", 1);
				_writer.WriteDateTime (Expires);
			}
		if (Policy != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Policy", 1);
				_writer.WriteString (Policy);
			}
		if (Practice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Practice", 1);
				_writer.WriteString (Practice);
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
    public static new Accreditation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Accreditation;
			}
		var Result = new Accreditation ();
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
			case "Callsign" : {
				Callsign = jsonReader.ReadString ();
				break;
				}
			case "SubjectNames" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				SubjectNames = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					SubjectNames.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "SubjectLogos" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				SubjectLogos = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					SubjectLogos.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Issued" : {
				Issued = jsonReader.ReadDateTime ();
				break;
				}
			case "Expires" : {
				Expires = jsonReader.ReadDateTime ();
				break;
				}
			case "Policy" : {
				Policy = jsonReader.ReadString ();
				break;
				}
			case "Practice" : {
				Practice = jsonReader.ReadString ();
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



