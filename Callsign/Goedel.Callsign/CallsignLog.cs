
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
//  This file was automatically generated at 4/2/2024 2:39:40 PM
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
	    {"ProfileResolver", ProfileResolver._Factory},
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
	    {"ProcessResultCallsignRegistration", ProcessResultCallsignRegistration._Factory},
	    {"CatalogedApplicationCallsign", CatalogedApplicationCallsign._Factory},
	    {"ProcessResultCallsign", ProcessResultCallsign._Factory}
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileRegistry(), ProfileAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileAccount._StaticAllProperties);


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
	public new const string __Tag = "ProfileRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileRegistry();


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


	}

	/// <summary>
	///
	/// Describes a callsign resolver.
	/// </summary>
public partial class ProfileResolver : ProfileService {
        /// <summary>
        ///The registry that this resolver resolves.
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileRegistry  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileResolver(), ProfileService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileRegistry", new PropertyStruct ("EnvelopedProfileRegistry", 
					(IBinding data, object? value) => {(data as ProfileResolver).EnvelopedProfileRegistry = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as ProfileResolver).EnvelopedProfileRegistry,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileService._StaticAllProperties);


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
	public new const string __Tag = "ProfileResolver";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileResolver();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileResolver FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileResolver;
			}
		var Result = new ProfileResolver ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
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

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The signed callsign binding
        /// </summary>

	public virtual Enveloped<CallsignBinding>?						Entry  {get; set;}

        /// <summary>
        ///The UTC time instant that the claim was submitted.
        /// </summary>

	public virtual DateTime?						Submitted  {get; set;}

        /// <summary>
        ///Callsign of the registrar that made the registration request
        /// </summary>

	public virtual string?						Registrar  {get; set;}

        /// <summary>
        ///If present, specifies a previous registration with the same identifier.
        /// </summary>

	public virtual string?						PriorId  {get; set;}

        /// <summary>
        ///Reason for creating a registration:
        ///Initial/ Update/ Voluntary/ Administrative/ Revoke
        /// </summary>

	public virtual string?						Reason  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Registration(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Registration).Id = value;}, (IBinding data) => (data as Registration).Id )},
			{ "Entry", new PropertyStruct ("Entry", 
					(IBinding data, object? value) => {(data as Registration).Entry = value as Enveloped<CallsignBinding>;}, (IBinding data) => (data as Registration).Entry,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>())} ,
			{ "Submitted", new PropertyDateTime ("Submitted", 
					(IBinding data, DateTime? value) => {(data as Registration).Submitted = value;}, (IBinding data) => (data as Registration).Submitted )},
			{ "Registrar", new PropertyString ("Registrar", 
					(IBinding data, string? value) => {(data as Registration).Registrar = value;}, (IBinding data) => (data as Registration).Registrar )},
			{ "PriorId", new PropertyString ("PriorId", 
					(IBinding data, string? value) => {(data as Registration).PriorId = value;}, (IBinding data) => (data as Registration).PriorId )},
			{ "Reason", new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as Registration).Reason = value;}, (IBinding data) => (data as Registration).Reason )}
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
	public new const string __Tag = "Registration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Registration();


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


	}

	/// <summary>
	/// </summary>
public partial class CatalogedRegistration : CatalogedEntry {
        /// <summary>
        ///The canonical form of the callsign.
        /// </summary>

	public virtual string?						Canonical  {get; set;}

        /// <summary>
        ///Unique registration identifier
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The registration entry for the item.
        /// </summary>

	public virtual Enveloped<Registration>?						EnvelopedRegistration  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedRegistration(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Canonical", new PropertyString ("Canonical", 
					(IBinding data, string? value) => {(data as CatalogedRegistration).Canonical = value;}, (IBinding data) => (data as CatalogedRegistration).Canonical )},
			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedRegistration).Id = value;}, (IBinding data) => (data as CatalogedRegistration).Id )},
			{ "EnvelopedRegistration", new PropertyStruct ("EnvelopedRegistration", 
					(IBinding data, object? value) => {(data as CatalogedRegistration).EnvelopedRegistration = value as Enveloped<Registration>;}, (IBinding data) => (data as CatalogedRegistration).EnvelopedRegistration,
					false, ()=>new  Enveloped<Registration>(), ()=>new Enveloped<Registration>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedRegistration();


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


	}

	/// <summary>
	/// </summary>
public partial class Page : CallsignEntry {
        /// <summary>
        ///Character page identifier
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///Additional allowed pages.
        /// </summary>

	public virtual List<string>?					Allow  {get; set;}
        /// <summary>
        ///Characters permitted within this code page.
        /// </summary>

	public virtual List<CharacterSpan>?					CharacterSpans  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Page(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Page).Id = value;}, (IBinding data) => (data as Page).Id )},
			{ "Allow", new PropertyListString ("Allow", 
					(IBinding data, List<string>? value) => {(data as Page).Allow = value;}, (IBinding data) => (data as Page).Allow )},
			{ "CharacterSpans", new PropertyListStruct ("CharacterSpans", 
					(IBinding data, object? value) => {(data as Page).CharacterSpans = value as List<CharacterSpan>;}, (IBinding data) => (data as Page).CharacterSpans,
					true, ()=>new List<CharacterSpan>()
)} 
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
	public new const string __Tag = "Page";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Page();


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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CharacterSpan(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "First", new PropertyInteger32 ("First", 
					(IBinding data, int? value) => {(data as CharacterSpan).First = value;}, (IBinding data) => (data as CharacterSpan).First )},
			{ "Last", new PropertyInteger32 ("Last", 
					(IBinding data, int? value) => {(data as CharacterSpan).Last = value;}, (IBinding data) => (data as CharacterSpan).Last )}
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
	public new const string __Tag = "CharacterSpan";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CharacterSpan();


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


	}

	/// <summary>
	///
	/// Canonical character span.
	/// </summary>
public partial class Canonical : CharacterSpan {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Canonical(), CharacterSpan._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "Canonical";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Canonical();


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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MapChar(), CharacterSpan._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Target", new PropertyInteger32 ("Target", 
					(IBinding data, int? value) => {(data as MapChar).Target = value;}, (IBinding data) => (data as MapChar).Target )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "MapChar";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapChar();


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

	public virtual string?						Target  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MapString(), CharacterSpan._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Target", new PropertyString ("Target", 
					(IBinding data, string? value) => {(data as MapString).Target = value;}, (IBinding data) => (data as MapString).Target )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CharacterSpan._StaticAllProperties);


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
	public new const string __Tag = "MapString";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MapString();


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


	}

	/// <summary>
	/// </summary>
public partial class Notarization : CallsignEntry {
        /// <summary>
        ///Enveloped witness value of a specific append only log.
        /// </summary>

	public virtual List<Enveloped<Witness>>?					Entries  {get; set;}
        /// <summary>
        ///Proof path validating the previous notary token that was entered in the
        ///log.
        /// </summary>

	public virtual Proof?						Proof  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Notarization(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Entries", new PropertyListStruct ("Entries", 
					(IBinding data, object? value) => {(data as Notarization).Entries = value as List<Enveloped<Witness>>;}, (IBinding data) => (data as Notarization).Entries,
					false, ()=>new  List<Enveloped<Witness>>(), ()=>new Enveloped<Witness>())} ,
			{ "Proof", new PropertyStruct ("Proof", 
					(IBinding data, object? value) => {(data as Notarization).Proof = value as Proof;}, (IBinding data) => (data as Notarization).Proof,
					false, ()=>new  Proof(), ()=>new Proof())} 
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
	public new const string __Tag = "Notarization";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Notarization();


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


	}

	/// <summary>
	///
	/// Registers a challenge to one or more callsigns that have been registered.
	/// </summary>
public partial class Challenge : Assertion {
        /// <summary>
        ///The callsigns subject to challenge
        /// </summary>

	public virtual List<string>?					Subjects  {get; set;}
        /// <summary>
        ///The basis for the challenge
        /// </summary>

	public virtual List<string>?					Basis  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Challenge(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Subjects", new PropertyListString ("Subjects", 
					(IBinding data, List<string>? value) => {(data as Challenge).Subjects = value;}, (IBinding data) => (data as Challenge).Subjects )},
			{ "Basis", new PropertyListString ("Basis", 
					(IBinding data, List<string>? value) => {(data as Challenge).Basis = value;}, (IBinding data) => (data as Challenge).Basis )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Challenge";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Challenge();


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


	}

	/// <summary>
	///
	/// Connection request message. This message contains the information
	/// </summary>
public partial class CallsignRegistrationRequest : MessageValidated {
        /// <summary>
        ///The enveloped binnding of the callsign to the profile.
        /// </summary>

	public virtual Enveloped<CallsignBinding>?						EnvelopedCallsignBinding  {get; set;}

        /// <summary>
        ///One or more profiles under which the EnvelopedCallsignBinding is 
        ///validlty signed.
        /// </summary>

	public virtual List<Enveloped<Profile>>?					Profiles  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CallsignRegistrationRequest(), MessageValidated._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedCallsignBinding", new PropertyStruct ("EnvelopedCallsignBinding", 
					(IBinding data, object? value) => {(data as CallsignRegistrationRequest).EnvelopedCallsignBinding = value as Enveloped<CallsignBinding>;}, (IBinding data) => (data as CallsignRegistrationRequest).EnvelopedCallsignBinding,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>())} ,
			{ "Profiles", new PropertyListStruct ("Profiles", 
					(IBinding data, object? value) => {(data as CallsignRegistrationRequest).Profiles = value as List<Enveloped<Profile>>;}, (IBinding data) => (data as CallsignRegistrationRequest).Profiles,
					false, ()=>new  List<Enveloped<Profile>>(), ()=>new Enveloped<Profile>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MessageValidated._StaticAllProperties);


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
	public new const string __Tag = "CallsignRegistrationRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationRequest();


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

	public virtual CatalogedRegistration?						CatalogedRegistration  {get; set;}

        /// <summary>
        ///Reason for refusing the registration (if refused)
        /// </summary>

	public virtual string?						Reason  {get; set;}

        /// <summary>
        ///The value specified as the Canonical field in the callsign request if present,
        ///otherwise the value specified in the Display field, otherwise null.
        /// </summary>

	public virtual string?						Callsign  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CallsignRegistrationResponse(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Registered", new PropertyBoolean ("Registered", 
					(IBinding data, bool? value) => {(data as CallsignRegistrationResponse).Registered = value;}, (IBinding data) => (data as CallsignRegistrationResponse).Registered )},
			{ "CatalogedRegistration", new PropertyStruct ("CatalogedRegistration", 
					(IBinding data, object? value) => {(data as CallsignRegistrationResponse).CatalogedRegistration = value as CatalogedRegistration;}, (IBinding data) => (data as CallsignRegistrationResponse).CatalogedRegistration,
					false, ()=>new  CatalogedRegistration(), ()=>new CatalogedRegistration())} ,
			{ "Reason", new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as CallsignRegistrationResponse).Reason = value;}, (IBinding data) => (data as CallsignRegistrationResponse).Reason )},
			{ "Callsign", new PropertyString ("Callsign", 
					(IBinding data, string? value) => {(data as CallsignRegistrationResponse).Callsign = value;}, (IBinding data) => (data as CallsignRegistrationResponse).Callsign )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "CallsignRegistrationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRegistrationResponse();


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


	}

	/// <summary>
	/// </summary>
public partial class ProcessResultCallsignRegistration : ProcessResult {
        /// <summary>
        /// </summary>

	public virtual CallsignRegistrationResponse?						CallsignRegistrationResponse  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProcessResultCallsignRegistration(), ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallsignRegistrationResponse", new PropertyStruct ("CallsignRegistrationResponse", 
					(IBinding data, object? value) => {(data as ProcessResultCallsignRegistration).CallsignRegistrationResponse = value as CallsignRegistrationResponse;}, (IBinding data) => (data as ProcessResultCallsignRegistration).CallsignRegistrationResponse,
					false, ()=>new  CallsignRegistrationResponse(), ()=>new CallsignRegistrationResponse())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProcessResult._StaticAllProperties);


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
	public new const string __Tag = "ProcessResultCallsignRegistration";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultCallsignRegistration();


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


	}

	/// <summary>
	///
	/// Application entry tracking the status of a callsign binding request
	/// </summary>
public partial class CatalogedApplicationCallsign : CatalogedApplication {
        /// <summary>
        ///The registered callsign in canonical form.		
        /// </summary>

	public virtual string?						CallSign  {get; set;}

        /// <summary>
        ///The MessageId of the request message
        /// </summary>

	public virtual string?						RequestId  {get; set;}

        /// <summary>
        ///The callsign binding  
        /// </summary>

	public virtual Enveloped<CallsignBinding>?						EnvelopedCallsignBinding  {get; set;}

        /// <summary>
        ///The resulting catalog entry if accepted or the prior registration otherwise.
        /// </summary>

	public virtual CatalogedRegistration?						CatalogedRegistration  {get; set;}

        /// <summary>
        ///Reason for refusing the registration (if refused)
        /// </summary>

	public virtual string?						Reason  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationCallsign(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallSign", new PropertyString ("CallSign", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).CallSign = value;}, (IBinding data) => (data as CatalogedApplicationCallsign).CallSign )},
			{ "RequestId", new PropertyString ("RequestId", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).RequestId = value;}, (IBinding data) => (data as CatalogedApplicationCallsign).RequestId )},
			{ "EnvelopedCallsignBinding", new PropertyStruct ("EnvelopedCallsignBinding", 
					(IBinding data, object? value) => {(data as CatalogedApplicationCallsign).EnvelopedCallsignBinding = value as Enveloped<CallsignBinding>;}, (IBinding data) => (data as CatalogedApplicationCallsign).EnvelopedCallsignBinding,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>())} ,
			{ "CatalogedRegistration", new PropertyStruct ("CatalogedRegistration", 
					(IBinding data, object? value) => {(data as CatalogedApplicationCallsign).CatalogedRegistration = value as CatalogedRegistration;}, (IBinding data) => (data as CatalogedApplicationCallsign).CatalogedRegistration,
					false, ()=>new  CatalogedRegistration(), ()=>new CatalogedRegistration())} ,
			{ "Reason", new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).Reason = value;}, (IBinding data) => (data as CatalogedApplicationCallsign).Reason )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationCallsign;
			}
		var Result = new CatalogedApplicationCallsign ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ProcessResultCallsign : ProcessResult {
        /// <summary>
        ///The cataloged application
        /// </summary>

	public virtual CatalogedApplicationCallsign?						CatalogedApplicationCallsign  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProcessResultCallsign(), ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedApplicationCallsign", new PropertyStruct ("CatalogedApplicationCallsign", 
					(IBinding data, object? value) => {(data as ProcessResultCallsign).CatalogedApplicationCallsign = value as CatalogedApplicationCallsign;}, (IBinding data) => (data as ProcessResultCallsign).CatalogedApplicationCallsign,
					false, ()=>new  CatalogedApplicationCallsign(), ()=>new CatalogedApplicationCallsign())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProcessResult._StaticAllProperties);


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
	public new const string __Tag = "ProcessResultCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResultCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResultCallsign;
			}
		var Result = new ProcessResultCallsign ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



