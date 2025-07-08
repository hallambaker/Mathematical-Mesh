
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
//  This file was automatically generated at 7/8/2025 6:34:22 PM
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(ProfileRegistry), ProfileRegistry._binding},
	    {typeof(ProfileResolver), ProfileResolver._binding},
	    {typeof(Registration), Registration._binding},
	    {typeof(CatalogedRegistration), CatalogedRegistration._binding},
	    {typeof(Page), Page._binding},
	    {typeof(CharacterSpan), CharacterSpan._binding},
	    {typeof(Canonical), Canonical._binding},
	    {typeof(MapChar), MapChar._binding},
	    {typeof(MapString), MapString._binding},
	    {typeof(Notarization), Notarization._binding},
	    {typeof(Challenge), Challenge._binding},
	    {typeof(CallsignRegistrationRequest), CallsignRegistrationRequest._binding},
	    {typeof(CallsignRegistrationResponse), CallsignRegistrationResponse._binding},
	    {typeof(ProcessResultCallsignRegistration), ProcessResultCallsignRegistration._binding},
	    {typeof(CatalogedApplicationCallsign), CatalogedApplicationCallsign._binding},
	    {typeof(ProcessResultCallsign), ProcessResultCallsign._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static CallsignEntry() {
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
	/// Describes a callsign registry.
	/// </summary>
public partial class ProfileRegistry : ProfileAccount {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileRegistry> _binding = new (
			new() {}, __Tag,
		() => new ProfileRegistry(), () => [], () => [], ProfileAccount._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Describes a callsign resolver.
	/// </summary>
public partial class ProfileResolver : ProfileService {
    /// <summary>
    ///The registry that this resolver resolves.
    /// </summary>

	[JsonPropertyName("EnvelopedProfileRegistry")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileRegistry  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EnvelopedProfileRegistry", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as ProfileResolver).EnvelopedProfileRegistry = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as ProfileResolver).EnvelopedProfileRegistry,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileResolver> _binding = new (
			new() {
			{ "EnvelopedProfileRegistry", _properties [0]}}, __Tag,
		() => new ProfileResolver(), () => [], () => [], ProfileService._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// A callsign or Notarization registration
	/// </summary>
public partial class Registration : CallsignEntry {
    /// <summary>
    ///Unique registration identifier
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///The signed callsign binding
    /// </summary>

	[JsonPropertyName("Entry")]
	public virtual Enveloped<CallsignBinding>?					Entry  {get; set;} //

    /// <summary>
    ///The UTC time instant that the claim was submitted.
    /// </summary>

	[JsonPropertyName("Submitted")]
	public virtual DateTime?					Submitted  {get; set;} //

    /// <summary>
    ///Callsign of the registrar that made the registration request
    /// </summary>

	[JsonPropertyName("Registrar")]
	public virtual string?					Registrar  {get; set;} //

    /// <summary>
    ///If present, specifies a previous registration with the same identifier.
    /// </summary>

	[JsonPropertyName("PriorId")]
	public virtual string?					PriorId  {get; set;} //

    /// <summary>
    ///Reason for creating a registration:
    ///Initial/ Update/ Voluntary/ Administrative/ Revoke
    /// </summary>

	[JsonPropertyName("Reason")]
	public virtual string?					Reason  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Registration).Id = value;}, 
					(IBinding data) => (data as Registration).Id ),
		new PropertyStruct ("Entry", typeof (Enveloped<CallsignBinding>),
					(IBinding data, object? value) => {(data as Registration).Entry = value as Enveloped<CallsignBinding>;}, 
					(IBinding data) => (data as Registration).Entry,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>()),
		new PropertyDateTime ("Submitted", 
					(IBinding data, DateTime? value) => {(data as Registration).Submitted = value;}, 
					(IBinding data) => (data as Registration).Submitted ),
		new PropertyString ("Registrar", 
					(IBinding data, string? value) => {(data as Registration).Registrar = value;}, 
					(IBinding data) => (data as Registration).Registrar ),
		new PropertyString ("PriorId", 
					(IBinding data, string? value) => {(data as Registration).PriorId = value;}, 
					(IBinding data) => (data as Registration).PriorId ),
		new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as Registration).Reason = value;}, 
					(IBinding data) => (data as Registration).Reason )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Registration> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Entry", _properties [1]},
			{ "Submitted", _properties [2]},
			{ "Registrar", _properties [3]},
			{ "PriorId", _properties [4]},
			{ "Reason", _properties [5]}}, __Tag,
		() => new Registration(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedRegistration : CatalogedEntry {
    /// <summary>
    ///The canonical form of the callsign.
    /// </summary>

	[JsonPropertyName("Canonical")]
	public virtual string?					Canonical  {get; set;} //

    /// <summary>
    ///Unique registration identifier
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///The registration entry for the item.
    /// </summary>

	[JsonPropertyName("EnvelopedRegistration")]
	public virtual Enveloped<Registration>?					EnvelopedRegistration  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Canonical", 
					(IBinding data, string? value) => {(data as CatalogedRegistration).Canonical = value;}, 
					(IBinding data) => (data as CatalogedRegistration).Canonical ),
		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedRegistration).Id = value;}, 
					(IBinding data) => (data as CatalogedRegistration).Id ),
		new PropertyStruct ("EnvelopedRegistration", typeof (Enveloped<Registration>),
					(IBinding data, object? value) => {(data as CatalogedRegistration).EnvelopedRegistration = value as Enveloped<Registration>;}, 
					(IBinding data) => (data as CatalogedRegistration).EnvelopedRegistration,
					false, ()=>new  Enveloped<Registration>(), ()=>new Enveloped<Registration>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedRegistration> _binding = new (
			new() {
			{ "Canonical", _properties [0]},
			{ "Id", _properties [1]},
			{ "EnvelopedRegistration", _properties [2]}}, __Tag,
		() => new CatalogedRegistration(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Page : CallsignEntry {
    /// <summary>
    ///Character page identifier
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///Additional allowed pages.
    /// </summary>

	[JsonPropertyName("Allow")]
	public virtual List<string>?					Allow  {get; set;}
    /// <summary>
    ///Characters permitted within this code page.
    /// </summary>

	[JsonPropertyName("CharacterSpans")]
	public virtual List<CharacterSpan>?					CharacterSpans  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Page).Id = value;}, 
					(IBinding data) => (data as Page).Id ),
		new PropertyListString ("Allow", 
					(IBinding data, List<string>? value) => {(data as Page).Allow = value;}, 
					(IBinding data) => (data as Page).Allow ),
		new PropertyListStruct ("CharacterSpans", typeof (CharacterSpan), 
					(IBinding data, object? value) => {(data as Page).CharacterSpans = value as List<CharacterSpan>;}, 
					(IBinding data) => (data as Page).CharacterSpans,
					true, ()=>new List<CharacterSpan>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Page> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Allow", _properties [1]},
			{ "CharacterSpans", _properties [2]}}, __Tag,
		() => new Page(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CharacterSpan : CallsignEntry {
    /// <summary>
    ///The first character in the range (inclusive)
    /// </summary>

	[JsonPropertyName("First")]
	public virtual int?					First  {get; set;} //

    /// <summary>
    ///The last character in the range (inclusive), if ommitted or
    ///equal to zero, this is the same as Last.
    /// </summary>

	[JsonPropertyName("Last")]
	public virtual int?					Last  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("First", 
					(IBinding data, int? value) => {(data as CharacterSpan).First = value;}, 
					(IBinding data) => (data as CharacterSpan).First ),
		new PropertyInteger32 ("Last", 
					(IBinding data, int? value) => {(data as CharacterSpan).Last = value;}, 
					(IBinding data) => (data as CharacterSpan).Last )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CharacterSpan> _binding = new (
			new() {
			{ "First", _properties [0]},
			{ "Last", _properties [1]}}, __Tag,
		() => new CharacterSpan(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Canonical character span.
	/// </summary>
public partial class Canonical : CharacterSpan {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Canonical> _binding = new (
			new() {}, __Tag,
		() => new Canonical(), () => [], () => [], CharacterSpan._binding, Generic: false);


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

	[JsonPropertyName("Target")]
	public virtual int?					Target  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Target", 
					(IBinding data, int? value) => {(data as MapChar).Target = value;}, 
					(IBinding data) => (data as MapChar).Target )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MapChar> _binding = new (
			new() {
			{ "Target", _properties [0]}}, __Tag,
		() => new MapChar(), () => [], () => [], CharacterSpan._binding, Generic: false);


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

	[JsonPropertyName("Target")]
	public virtual string?					Target  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Target", 
					(IBinding data, string? value) => {(data as MapString).Target = value;}, 
					(IBinding data) => (data as MapString).Target )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MapString> _binding = new (
			new() {
			{ "Target", _properties [0]}}, __Tag,
		() => new MapString(), () => [], () => [], CharacterSpan._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Notarization : CallsignEntry {
    /// <summary>
    ///Enveloped witness value of a specific append only log.
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<Enveloped<Witness>>?					Entries  {get; set;}
    /// <summary>
    ///Proof path validating the previous notary token that was entered in the
    ///log.
    /// </summary>

	[JsonPropertyName("Proof")]
	public virtual Proof?					Proof  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Entries", typeof (Enveloped<Witness>),
					(IBinding data, object? value) => {(data as Notarization).Entries = value as List<Enveloped<Witness>>;}, 
					(IBinding data) => (data as Notarization).Entries,
					false, ()=>new  List<Enveloped<Witness>>(), ()=>new Enveloped<Witness>()),
		new PropertyStruct ("Proof", typeof (Proof),
					(IBinding data, object? value) => {(data as Notarization).Proof = value as Proof;}, 
					(IBinding data) => (data as Notarization).Proof,
					false, ()=>new  Proof(), ()=>new Proof())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Notarization> _binding = new (
			new() {
			{ "Entries", _properties [0]},
			{ "Proof", _properties [1]}}, __Tag,
		() => new Notarization(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Registers a challenge to one or more callsigns that have been registered.
	/// </summary>
public partial class Challenge : Assertion {
    /// <summary>
    ///The callsigns subject to challenge
    /// </summary>

	[JsonPropertyName("Subjects")]
	public virtual List<string>?					Subjects  {get; set;}
    /// <summary>
    ///The basis for the challenge
    /// </summary>

	[JsonPropertyName("Basis")]
	public virtual List<string>?					Basis  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Subjects", 
					(IBinding data, List<string>? value) => {(data as Challenge).Subjects = value;}, 
					(IBinding data) => (data as Challenge).Subjects ),
		new PropertyListString ("Basis", 
					(IBinding data, List<string>? value) => {(data as Challenge).Basis = value;}, 
					(IBinding data) => (data as Challenge).Basis )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Challenge> _binding = new (
			new() {
			{ "Subjects", _properties [0]},
			{ "Basis", _properties [1]}}, __Tag,
		() => new Challenge(), () => [], () => [], Assertion._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Connection request message. This message contains the information
	/// </summary>
public partial class CallsignRegistrationRequest : MessageValidated {
    /// <summary>
    ///The enveloped binnding of the callsign to the profile.
    /// </summary>

	[JsonPropertyName("EnvelopedCallsignBinding")]
	public virtual Enveloped<CallsignBinding>?					EnvelopedCallsignBinding  {get; set;} //

    /// <summary>
    ///One or more profiles under which the EnvelopedCallsignBinding is 
    ///validlty signed.
    /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<Enveloped<Profile>>?					Profiles  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EnvelopedCallsignBinding", typeof (Enveloped<CallsignBinding>),
					(IBinding data, object? value) => {(data as CallsignRegistrationRequest).EnvelopedCallsignBinding = value as Enveloped<CallsignBinding>;}, 
					(IBinding data) => (data as CallsignRegistrationRequest).EnvelopedCallsignBinding,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>()),
		new PropertyListStruct ("Profiles", typeof (Enveloped<Profile>),
					(IBinding data, object? value) => {(data as CallsignRegistrationRequest).Profiles = value as List<Enveloped<Profile>>;}, 
					(IBinding data) => (data as CallsignRegistrationRequest).Profiles,
					false, ()=>new  List<Enveloped<Profile>>(), ()=>new Enveloped<Profile>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CallsignRegistrationRequest> _binding = new (
			new() {
			{ "EnvelopedCallsignBinding", _properties [0]},
			{ "Profiles", _properties [1]}}, __Tag,
		() => new CallsignRegistrationRequest(), () => [], () => [], MessageValidated._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CallsignRegistrationResponse : Message {
    /// <summary>
    ///True if and only if a new registration was created.
    /// </summary>

	[JsonPropertyName("Registered")]
	public virtual bool?					Registered  {get; set;} //

    /// <summary>
    ///The resulting catalog entry if accepted or the prior registration otherwise.
    /// </summary>

	[JsonPropertyName("CatalogedRegistration")]
	public virtual CatalogedRegistration?					CatalogedRegistration  {get; set;} //

    /// <summary>
    ///Reason for refusing the registration (if refused)
    /// </summary>

	[JsonPropertyName("Reason")]
	public virtual string?					Reason  {get; set;} //

    /// <summary>
    ///The value specified as the Canonical field in the callsign request if present,
    ///otherwise the value specified in the Display field, otherwise null.
    /// </summary>

	[JsonPropertyName("Callsign")]
	public virtual string?					Callsign  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Registered", 
					(IBinding data, bool? value) => {(data as CallsignRegistrationResponse).Registered = value;}, 
					(IBinding data) => (data as CallsignRegistrationResponse).Registered ),
		new PropertyStruct ("CatalogedRegistration", typeof (CatalogedRegistration),
					(IBinding data, object? value) => {(data as CallsignRegistrationResponse).CatalogedRegistration = value as CatalogedRegistration;}, 
					(IBinding data) => (data as CallsignRegistrationResponse).CatalogedRegistration,
					false, ()=>new  CatalogedRegistration(), ()=>new CatalogedRegistration()),
		new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as CallsignRegistrationResponse).Reason = value;}, 
					(IBinding data) => (data as CallsignRegistrationResponse).Reason ),
		new PropertyString ("Callsign", 
					(IBinding data, string? value) => {(data as CallsignRegistrationResponse).Callsign = value;}, 
					(IBinding data) => (data as CallsignRegistrationResponse).Callsign )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CallsignRegistrationResponse> _binding = new (
			new() {
			{ "Registered", _properties [0]},
			{ "CatalogedRegistration", _properties [1]},
			{ "Reason", _properties [2]},
			{ "Callsign", _properties [3]}}, __Tag,
		() => new CallsignRegistrationResponse(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ProcessResultCallsignRegistration : ProcessResult {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CallsignRegistrationResponse")]
	public virtual CallsignRegistrationResponse?					CallsignRegistrationResponse  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CallsignRegistrationResponse", typeof (CallsignRegistrationResponse),
					(IBinding data, object? value) => {(data as ProcessResultCallsignRegistration).CallsignRegistrationResponse = value as CallsignRegistrationResponse;}, 
					(IBinding data) => (data as ProcessResultCallsignRegistration).CallsignRegistrationResponse,
					false, ()=>new  CallsignRegistrationResponse(), ()=>new CallsignRegistrationResponse())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResultCallsignRegistration> _binding = new (
			new() {
			{ "CallsignRegistrationResponse", _properties [0]}}, __Tag,
		() => new ProcessResultCallsignRegistration(), () => [], () => [], ProcessResult._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Application entry tracking the status of a callsign binding request
	/// </summary>
public partial class CatalogedApplicationCallsign : CatalogedApplication {
    /// <summary>
    ///The registered callsign in canonical form.		
    /// </summary>

	[JsonPropertyName("CallSign")]
	public virtual string?					CallSign  {get; set;} //

    /// <summary>
    ///The MessageId of the request message
    /// </summary>

	[JsonPropertyName("RequestId")]
	public virtual string?					RequestId  {get; set;} //

    /// <summary>
    ///The callsign binding  
    /// </summary>

	[JsonPropertyName("EnvelopedCallsignBinding")]
	public virtual Enveloped<CallsignBinding>?					EnvelopedCallsignBinding  {get; set;} //

    /// <summary>
    ///The resulting catalog entry if accepted or the prior registration otherwise.
    /// </summary>

	[JsonPropertyName("CatalogedRegistration")]
	public virtual CatalogedRegistration?					CatalogedRegistration  {get; set;} //

    /// <summary>
    ///Reason for refusing the registration (if refused)
    /// </summary>

	[JsonPropertyName("Reason")]
	public virtual string?					Reason  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("CallSign", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).CallSign = value;}, 
					(IBinding data) => (data as CatalogedApplicationCallsign).CallSign ),
		new PropertyString ("RequestId", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).RequestId = value;}, 
					(IBinding data) => (data as CatalogedApplicationCallsign).RequestId ),
		new PropertyStruct ("EnvelopedCallsignBinding", typeof (Enveloped<CallsignBinding>),
					(IBinding data, object? value) => {(data as CatalogedApplicationCallsign).EnvelopedCallsignBinding = value as Enveloped<CallsignBinding>;}, 
					(IBinding data) => (data as CatalogedApplicationCallsign).EnvelopedCallsignBinding,
					false, ()=>new  Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>()),
		new PropertyStruct ("CatalogedRegistration", typeof (CatalogedRegistration),
					(IBinding data, object? value) => {(data as CatalogedApplicationCallsign).CatalogedRegistration = value as CatalogedRegistration;}, 
					(IBinding data) => (data as CatalogedApplicationCallsign).CatalogedRegistration,
					false, ()=>new  CatalogedRegistration(), ()=>new CatalogedRegistration()),
		new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCallsign).Reason = value;}, 
					(IBinding data) => (data as CatalogedApplicationCallsign).Reason )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationCallsign> _binding = new (
			new() {
			{ "CallSign", _properties [0]},
			{ "RequestId", _properties [1]},
			{ "EnvelopedCallsignBinding", _properties [2]},
			{ "CatalogedRegistration", _properties [3]},
			{ "Reason", _properties [4]}}, __Tag,
		() => new CatalogedApplicationCallsign(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ProcessResultCallsign : ProcessResult {
    /// <summary>
    ///The cataloged application
    /// </summary>

	[JsonPropertyName("CatalogedApplicationCallsign")]
	public virtual CatalogedApplicationCallsign?					CatalogedApplicationCallsign  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CatalogedApplicationCallsign", typeof (CatalogedApplicationCallsign),
					(IBinding data, object? value) => {(data as ProcessResultCallsign).CatalogedApplicationCallsign = value as CatalogedApplicationCallsign;}, 
					(IBinding data) => (data as ProcessResultCallsign).CatalogedApplicationCallsign,
					false, ()=>new  CatalogedApplicationCallsign(), ()=>new CatalogedApplicationCallsign())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResultCallsign> _binding = new (
			new() {
			{ "CatalogedApplicationCallsign", _properties [0]}}, __Tag,
		() => new ProcessResultCallsign(), () => [], () => [], ProcessResult._binding, Generic: false);


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

	}



