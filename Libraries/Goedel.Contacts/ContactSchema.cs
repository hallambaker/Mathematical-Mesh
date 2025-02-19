
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
//  This file was automatically generated at 2/19/2025 6:44:13 PM
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
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Contacts;


	/// <summary>
	/// </summary>
public abstract partial class Contacts : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Contacts";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Card", JsContact._Factory},
	    {"Relation", Relation._Factory},
	    {"Resource", Resource._Factory},
	    {"Name", Name._Factory},
	    {"NameComponent", NameComponent._Factory},
	    {"NickName", NickName._Factory},
	    {"Organization", Organization._Factory},
	    {"OrgUnit", OrgUnit._Factory},
	    {"SpeakToAs", SpeakToAs._Factory},
	    {"Pronouns", Pronouns._Factory},
	    {"Title", Title._Factory},
	    {"EmailAddress", EmailAddress._Factory},
	    {"OnlineService", OnlineService._Factory},
	    {"Phone", Phone._Factory},
	    {"LanguagePref", LanguagePref._Factory},
	    {"Calendar", Calendar._Factory},
	    {"SchedulingAddress", SchedulingAddress._Factory},
	    {"Address", Address._Factory},
	    {"AddressComponent", AddressComponent._Factory},
	    {"CryptoKey", CryptoKey._Factory},
	    {"Directory", ContactDirectory._Factory},
	    {"ResourceLink", ResourceLink._Factory},
	    {"Media", Media._Factory},
	    {"PatchObject", PatchObject._Factory},
	    {"Anniversary", Anniversary._Factory},
	    {"TimeStamp", TimeStamp._Factory},
	    {"Note", Note._Factory},
	    {"Author", Author._Factory},
	    {"PersonalInfo", PersonalInfo._Factory}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Contacts() {
		_Initialize();
		}

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
	///  Metadata, see section 2.1
	/// </summary>
public partial class JsContact : JmapBase {
        /// <summary>
        /// The JSContact version of this Card. If specified, value MUST be '1.0'
        /// </summary>

	public virtual string?					Version  {get; set;}

        /// <summary>
        /// The kind of the entity the Card represents.
        /// individual: a single person
        /// group: a group of people or entities
        /// org: an organization
        /// location: a named location
        /// device: a device such as an appliance, a computer, or a network element
        /// application: a software application
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// The language tag, as defined in [RFC5646], that best describes the language 
        /// used for text in the Card, optionally including additional information such 
        /// as the script. Note that values MAY be localized in the localizations 
        /// property.
        /// </summary>

	public virtual string?					Language  {get; set;}

        /// <summary>
        /// The set of Cards that are members of this group Card. Each key in the set is 
        /// the uid property value of the member, and each boolean value MUST be "true".
        /// If this property is set, then the value of the kind property MUST be "group"
        /// </summary>

	public virtual Dictionary<string,string>?					Members  {get; set;}

        /// <summary>
        /// The name of the entity represented by the Card. This can be any type of name, 
        /// e.g., it can, but need not, be the legal name of a person.
        /// </summary>

	public virtual Name?					Name  {get; set;}

        /// <summary>
        /// The nicknames of the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,NickName>?					NickNames  {get; set;}

        /// <summary>
        /// The company or organization names and units associated with the Card.
        /// </summary>

	public virtual Dictionary<string,Organization>?					Organizations  {get; set;}

        /// <summary>
        /// The information that directs how to address, speak to, or refer to the
        /// entity that is represented by the Card.
        /// </summary>

	public virtual SpeakToAs?					SpeakToAs  {get; set;}

        /// <summary>
        /// The job titles or functional positions of the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,Title>?					Titles  {get; set;}

        /// <summary>
        /// The email addresses in which to contact the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,EmailAddress>?					Emails  {get; set;}

        /// <summary>
        /// The online services that are associated with the entity represented by the Card.
        /// This can be messaging services, social media profiles, and other.
        /// </summary>

	public virtual Dictionary<string,OnlineService>?					OnlineServices  {get; set;}

        /// <summary>
        /// The phone numbers by which to contact the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,Phone>?					Phones  {get; set;}

        /// <summary>
        /// The preferred languages for contacting the entity associated with the Card.
        /// </summary>

	public virtual Dictionary<string,LanguagePref>?					PreferredLanguages  {get; set;}

        /// <summary>
        /// The calendaring resources of the entity represented by the Card, such as 
        /// to look up free-busy information.
        /// </summary>

	public virtual Dictionary<string,Calendar>?					Calendars  {get; set;}

        /// <summary>
        /// The scheduling addresses by which the entity may receive calendar  
        /// scheduling invitations.
        /// </summary>

	public virtual Dictionary<string,SchedulingAddress>?					SchedulingAddresses  {get; set;}

        /// <summary>
        /// The addresses of the entity represented by the Card, such as postal addresses 
        /// or geographic locations.
        /// </summary>

	public virtual Dictionary<string,Address>?					Addresses  {get; set;}

        /// <summary>
        /// The cryptographic resources such as public keys and certificates associated 
        /// with the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,CryptoKey>?					CryptoKeys  {get; set;}

        /// <summary>
        /// The directories containing information about the entity represented  
        /// by the Card.
        /// </summary>

	public virtual Dictionary<string,ContactDirectory>?					Directories  {get; set;}

        /// <summary>
        /// The links to resources that do not fit any of the other  
        /// use-case-specific resource properties.
        /// </summary>

	public virtual Dictionary<string,ResourceLink>?					Links  {get; set;}

        /// <summary>
        /// The media resources such as photographs, avatars, or sounds that 
        ///  are associated 
        /// with the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,Media>?					Media  {get; set;}

        /// <summary>
        /// The property values localized to languages other than the main language 
        /// (Section 2.1.5) of the Card. Localizations provide language-specific alternatives 
        /// for existing property values and SHOULD NOT add new properties. The keys in 
        /// the localizations property value are language tags [RFC5646]; the values 
        /// are of type PatchObject and localize the Card in that language tag. The paths 
        /// in the PatchObject are relative to the Card that includes the localizations
        /// property. A patch MUST NOT target the localizations property.
        /// </summary>

	public virtual Dictionary<string,PatchObject>?					Localizations  {get; set;}

        /// <summary>
        /// The memorable dates and events for the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,Anniversary>?					Anniversaries  {get; set;}

        /// <summary>
        /// The set of free-text keywords, also known as tags.
        /// </summary>

	public virtual Dictionary<string,bool>?					Keywords  {get; set;}

        /// <summary>
        /// The free-text notes that are associated with the Card.
        /// </summary>

	public virtual Dictionary<string,Note>?					Notes  {get; set;}

        /// <summary>
        /// The personal information of the entity represented by the Card.
        /// </summary>

	public virtual Dictionary<string,PersonalInfo>?					PersonalInfo  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "version", new PropertyString ("version", 
					(IBinding data, string? value) => {(data as JsContact).Version = value;}, (IBinding data) => (data as JsContact).Version )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as JsContact).Kind = value;}, (IBinding data) => (data as JsContact).Kind )},
			{ "language", new PropertyString ("language", 
					(IBinding data, string? value) => {(data as JsContact).Language = value;}, (IBinding data) => (data as JsContact).Language )},
			{ "members", new PropertyDictionaryString ("members", 
					(IBinding data, Dictionary<string,string>? value) => {(data as JsContact).Members = value;}, (IBinding data) => (data as JsContact).Members )},
			{ "name", new PropertyStruct ("name", 
					(IBinding data, object? value) => {(data as JsContact).Name = value as Name;}, (IBinding data) => (data as JsContact).Name,
					false, ()=>new  Name(), ()=>new Name())},
			{ "nickNames", new PropertyDictionaryStruct ("nickNames", 
					(IBinding data, object? value) => {(data as JsContact).NickNames = value as Dictionary<string,NickName>;}, (IBinding data) => (data as JsContact).NickNames,
					false, ()=>new  Dictionary<string,NickName>(), ()=>new NickName(),
					(IBinding data) => (data as JsContact).NickNames.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,NickName>).Add (key as string,value as NickName);})},
			{ "organizations", new PropertyDictionaryStruct ("organizations", 
					(IBinding data, object? value) => {(data as JsContact).Organizations = value as Dictionary<string,Organization>;}, (IBinding data) => (data as JsContact).Organizations,
					false, ()=>new  Dictionary<string,Organization>(), ()=>new Organization(),
					(IBinding data) => (data as JsContact).Organizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Organization>).Add (key as string,value as Organization);})},
			{ "speakToAs", new PropertyStruct ("speakToAs", 
					(IBinding data, object? value) => {(data as JsContact).SpeakToAs = value as SpeakToAs;}, (IBinding data) => (data as JsContact).SpeakToAs,
					false, ()=>new  SpeakToAs(), ()=>new SpeakToAs())},
			{ "titles", new PropertyDictionaryStruct ("titles", 
					(IBinding data, object? value) => {(data as JsContact).Titles = value as Dictionary<string,Title>;}, (IBinding data) => (data as JsContact).Titles,
					false, ()=>new  Dictionary<string,Title>(), ()=>new Title(),
					(IBinding data) => (data as JsContact).Titles.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Title>).Add (key as string,value as Title);})},
			{ "emails", new PropertyDictionaryStruct ("emails", 
					(IBinding data, object? value) => {(data as JsContact).Emails = value as Dictionary<string,EmailAddress>;}, (IBinding data) => (data as JsContact).Emails,
					false, ()=>new  Dictionary<string,EmailAddress>(), ()=>new EmailAddress(),
					(IBinding data) => (data as JsContact).Emails.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,EmailAddress>).Add (key as string,value as EmailAddress);})},
			{ "onlineServices", new PropertyDictionaryStruct ("onlineServices", 
					(IBinding data, object? value) => {(data as JsContact).OnlineServices = value as Dictionary<string,OnlineService>;}, (IBinding data) => (data as JsContact).OnlineServices,
					false, ()=>new  Dictionary<string,OnlineService>(), ()=>new OnlineService(),
					(IBinding data) => (data as JsContact).OnlineServices.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,OnlineService>).Add (key as string,value as OnlineService);})},
			{ "phones", new PropertyDictionaryStruct ("phones", 
					(IBinding data, object? value) => {(data as JsContact).Phones = value as Dictionary<string,Phone>;}, (IBinding data) => (data as JsContact).Phones,
					false, ()=>new  Dictionary<string,Phone>(), ()=>new Phone(),
					(IBinding data) => (data as JsContact).Phones.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Phone>).Add (key as string,value as Phone);})},
			{ "preferredLanguages", new PropertyDictionaryStruct ("preferredLanguages", 
					(IBinding data, object? value) => {(data as JsContact).PreferredLanguages = value as Dictionary<string,LanguagePref>;}, (IBinding data) => (data as JsContact).PreferredLanguages,
					false, ()=>new  Dictionary<string,LanguagePref>(), ()=>new LanguagePref(),
					(IBinding data) => (data as JsContact).PreferredLanguages.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,LanguagePref>).Add (key as string,value as LanguagePref);})},
			{ "calendars", new PropertyDictionaryStruct ("calendars", 
					(IBinding data, object? value) => {(data as JsContact).Calendars = value as Dictionary<string,Calendar>;}, (IBinding data) => (data as JsContact).Calendars,
					false, ()=>new  Dictionary<string,Calendar>(), ()=>new Calendar(),
					(IBinding data) => (data as JsContact).Calendars.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Calendar>).Add (key as string,value as Calendar);})},
			{ "schedulingAddresses", new PropertyDictionaryStruct ("schedulingAddresses", 
					(IBinding data, object? value) => {(data as JsContact).SchedulingAddresses = value as Dictionary<string,SchedulingAddress>;}, (IBinding data) => (data as JsContact).SchedulingAddresses,
					false, ()=>new  Dictionary<string,SchedulingAddress>(), ()=>new SchedulingAddress(),
					(IBinding data) => (data as JsContact).SchedulingAddresses.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,SchedulingAddress>).Add (key as string,value as SchedulingAddress);})},
			{ "addresses", new PropertyDictionaryStruct ("addresses", 
					(IBinding data, object? value) => {(data as JsContact).Addresses = value as Dictionary<string,Address>;}, (IBinding data) => (data as JsContact).Addresses,
					false, ()=>new  Dictionary<string,Address>(), ()=>new Address(),
					(IBinding data) => (data as JsContact).Addresses.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Address>).Add (key as string,value as Address);})},
			{ "cryptoKeys", new PropertyDictionaryStruct ("cryptoKeys", 
					(IBinding data, object? value) => {(data as JsContact).CryptoKeys = value as Dictionary<string,CryptoKey>;}, (IBinding data) => (data as JsContact).CryptoKeys,
					false, ()=>new  Dictionary<string,CryptoKey>(), ()=>new CryptoKey(),
					(IBinding data) => (data as JsContact).CryptoKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,CryptoKey>).Add (key as string,value as CryptoKey);})},
			{ "directories", new PropertyDictionaryStruct ("directories", 
					(IBinding data, object? value) => {(data as JsContact).Directories = value as Dictionary<string,ContactDirectory>;}, (IBinding data) => (data as JsContact).Directories,
					false, ()=>new  Dictionary<string,ContactDirectory>(), ()=>new ContactDirectory(),
					(IBinding data) => (data as JsContact).Directories.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,ContactDirectory>).Add (key as string,value as ContactDirectory);})},
			{ "links", new PropertyDictionaryStruct ("links", 
					(IBinding data, object? value) => {(data as JsContact).Links = value as Dictionary<string,ResourceLink>;}, (IBinding data) => (data as JsContact).Links,
					false, ()=>new  Dictionary<string,ResourceLink>(), ()=>new ResourceLink(),
					(IBinding data) => (data as JsContact).Links.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,ResourceLink>).Add (key as string,value as ResourceLink);})},
			{ "media", new PropertyDictionaryStruct ("media", 
					(IBinding data, object? value) => {(data as JsContact).Media = value as Dictionary<string,Media>;}, (IBinding data) => (data as JsContact).Media,
					false, ()=>new  Dictionary<string,Media>(), ()=>new Media(),
					(IBinding data) => (data as JsContact).Media.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Media>).Add (key as string,value as Media);})},
			{ "localizations", new PropertyDictionaryStruct ("localizations", 
					(IBinding data, object? value) => {(data as JsContact).Localizations = value as Dictionary<string,PatchObject>;}, (IBinding data) => (data as JsContact).Localizations,
					false, ()=>new  Dictionary<string,PatchObject>(), ()=>new PatchObject(),
					(IBinding data) => (data as JsContact).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,PatchObject>).Add (key as string,value as PatchObject);})},
			{ "anniversaries", new PropertyDictionaryStruct ("anniversaries", 
					(IBinding data, object? value) => {(data as JsContact).Anniversaries = value as Dictionary<string,Anniversary>;}, (IBinding data) => (data as JsContact).Anniversaries,
					false, ()=>new  Dictionary<string,Anniversary>(), ()=>new Anniversary(),
					(IBinding data) => (data as JsContact).Anniversaries.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Anniversary>).Add (key as string,value as Anniversary);})},
			{ "keywords", new PropertyDictionaryBoolean ("keywords", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as JsContact).Keywords = value;}, (IBinding data) => (data as JsContact).Keywords )},
			{ "notes", new PropertyDictionaryStruct ("notes", 
					(IBinding data, object? value) => {(data as JsContact).Notes = value as Dictionary<string,Note>;}, (IBinding data) => (data as JsContact).Notes,
					false, ()=>new  Dictionary<string,Note>(), ()=>new Note(),
					(IBinding data) => (data as JsContact).Notes.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Note>).Add (key as string,value as Note);})},
			{ "personalInfo", new PropertyDictionaryStruct ("personalInfo", 
					(IBinding data, object? value) => {(data as JsContact).PersonalInfo = value as Dictionary<string,PersonalInfo>;}, (IBinding data) => (data as JsContact).PersonalInfo,
					false, ()=>new  Dictionary<string,PersonalInfo>(), ()=>new PersonalInfo(),
					(IBinding data) => (data as JsContact).PersonalInfo.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,PersonalInfo>).Add (key as string,value as PersonalInfo);})}
        }, __Tag,() => new JsContact(), JmapBase._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, JmapBase._StaticAllProperties);


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
	public new const string __Tag = "Card";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsContact();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JsContact FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JsContact;
			}
		var Result = new JsContact ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Relation : Contacts {
        /// <summary>
        /// The relationships, each one MUST have the value true.
        /// </summary>

	public virtual Dictionary<string,bool>?					Relationships  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "relationships", new PropertyDictionaryBoolean ("relationships", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Relation).Relationships = value;}, (IBinding data) => (data as Relation).Relationships )}
        }, __Tag,() => new Relation(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Relation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Relation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Relation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Relation;
			}
		var Result = new Relation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Resource : Contacts {
        /// <summary>
        /// The JSContact type of the object. The value MUST NOT be "Resource"; 
        /// instead, the value MUST be the name of a concrete resource type
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The kind of the resource. The allowed values are defined in the 
        /// property definition that makes use of the Resource type. Some 
        /// property definitions may change this property from being optional to mandatory.
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// The media type [RFC2046] of the resource identified by the uri property value.
        /// </summary>

	public virtual string?					MediaType  {get; set;}

        /// <summary>
        /// The contexts in which to use this resource. 
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the resource in relation to other resources.
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// A custom label for the value. 
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Resource).Type = value;}, (IBinding data) => (data as Resource).Type )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Resource).Kind = value;}, (IBinding data) => (data as Resource).Kind )},
			{ "uri", new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as Resource).Uri = value;}, (IBinding data) => (data as Resource).Uri )},
			{ "mediaType", new PropertyString ("mediaType", 
					(IBinding data, string? value) => {(data as Resource).MediaType = value;}, (IBinding data) => (data as Resource).MediaType )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Resource).Contexts = value;}, (IBinding data) => (data as Resource).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Resource).Pref = value;}, (IBinding data) => (data as Resource).Pref )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as Resource).Label = value;}, (IBinding data) => (data as Resource).Label )}
        }, __Tag,() => new Resource(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Resource";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Resource();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Resource FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Resource;
			}
		var Result = new Resource ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	/// A Name object
	/// </summary>
public partial class Name : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The components (Section 2.2.1.2) making up this name. The components property 
        /// MUST be set if the full property is not set; otherwise, it SHOULD be set. 
        /// The component list MUST have at least one entry having a different kind 
        /// property value than "separator".
        /// </summary>

	public virtual List<NameComponent>?					Components  {get; set;}
        /// <summary>
        /// The indicator if the name components in the components property are ordered.
        /// </summary>

	public virtual bool?					IsOrdered  {get; set;}

        /// <summary>
        /// The default separator to insert between name component values when 
        /// concatenating all name component values to a single String. Also see 
        /// the definition of the kind property value "separator" for the 
        /// NameComponent (Section 2.2.1.2) object. The defaultSeparator property 
        /// MUST NOT be set if the Name isOrdered property value is "false" or 
        /// if the components property is not set.
        /// </summary>

	public virtual string?					DefaultSeparator  {get; set;}

        /// <summary>
        /// The full name representation of the Name. The full property MUST be set 
        /// if the components property is not set.
        /// </summary>

	public virtual string?					Full  {get; set;}

        /// <summary>
        /// The value to lexicographically sort the name in relation to other names 
        /// when compared by a name component type. The keys in the map define the 
        /// name component type. The values define the verbatim string to compare 
        /// when sorting by the name component type. Absence of a key indicates that 
        /// the name component type SHOULD NOT be considered during sort. Sorting by 
        /// that missing name component type, or if the sortAs property is not set, 
        /// is implementation-specific. The sortAs property MUST NOT be set if the 
        /// components property is not set.
        /// </summary>

	public virtual string?					SortAs  {get; set;}

        /// <summary>
        /// The script used in the value of the NameComponent phonetic property.
        /// </summary>

	public virtual string?					PhoneticScript  {get; set;}

        /// <summary>
        /// The phonetic system used in the NameComponent phonetic property.
        /// </summary>

	public virtual string?					PhoneticSystem  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Name).Type = value;}, (IBinding data) => (data as Name).Type )},
			{ "components", new PropertyListStruct ("components", 
					(IBinding data, object? value) => {(data as Name).Components = value as List<NameComponent>;}, (IBinding data) => (data as Name).Components,
					false, ()=>new  List<NameComponent>(), ()=>new NameComponent())},
			{ "isOrdered", new PropertyBoolean ("isOrdered", 
					(IBinding data, bool? value) => {(data as Name).IsOrdered = value;}, (IBinding data) => (data as Name).IsOrdered )},
			{ "defaultSeparator", new PropertyString ("defaultSeparator", 
					(IBinding data, string? value) => {(data as Name).DefaultSeparator = value;}, (IBinding data) => (data as Name).DefaultSeparator )},
			{ "full", new PropertyString ("full", 
					(IBinding data, string? value) => {(data as Name).Full = value;}, (IBinding data) => (data as Name).Full )},
			{ "sortAs", new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as Name).SortAs = value;}, (IBinding data) => (data as Name).SortAs )},
			{ "phoneticScript", new PropertyString ("phoneticScript", 
					(IBinding data, string? value) => {(data as Name).PhoneticScript = value;}, (IBinding data) => (data as Name).PhoneticScript )},
			{ "phoneticSystem", new PropertyString ("phoneticSystem", 
					(IBinding data, string? value) => {(data as Name).PhoneticSystem = value;}, (IBinding data) => (data as Name).PhoneticSystem )}
        }, __Tag,() => new Name(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Name";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Name();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Name FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Name;
			}
		var Result = new Name ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	/// A NameComponent object
	/// </summary>
public partial class NameComponent : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?					Value  {get; set;}

        /// <summary>
        /// title: an honorific title or prefix, e.g., "Mr.", "Ms.", or "Dr.".
        /// given: a given name, also known as "first name" or "personal name".
        /// given2: a name that appears between the given and surname such as a middle name or patronymic name.
        /// surname: a surname, also known as "last name" or "family name".
        /// surname2: a secondary surname (used in some cultures), also known as "maternal surname".
        /// credential: a credential, also known as "accreditation qualifier" or "honorific suffix", e.g., "B.A.", "Esq.".
        /// generation: a generation marker or qualifier, e.g., "Jr." or "III".
        /// separator: a formatting separator between two ordered name non-separator components. 
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?					Phonetic  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as NameComponent).Type = value;}, (IBinding data) => (data as NameComponent).Type )},
			{ "value", new PropertyString ("value", 
					(IBinding data, string? value) => {(data as NameComponent).Value = value;}, (IBinding data) => (data as NameComponent).Value )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as NameComponent).Kind = value;}, (IBinding data) => (data as NameComponent).Kind )},
			{ "phonetic", new PropertyString ("phonetic", 
					(IBinding data, string? value) => {(data as NameComponent).Phonetic = value;}, (IBinding data) => (data as NameComponent).Phonetic )}
        }, __Tag,() => new NameComponent(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "NameComponent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NameComponent();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NameComponent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NameComponent;
			}
		var Result = new NameComponent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class NickName : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The nickname.
        /// </summary>

	public virtual string?					Name  {get; set;}

        /// <summary>
        /// The contexts in which to use the nickname.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the nickname in relation to other nicknames. 
        /// </summary>

	public virtual int?					Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as NickName).Type = value;}, (IBinding data) => (data as NickName).Type )},
			{ "name", new PropertyString ("name", 
					(IBinding data, string? value) => {(data as NickName).Name = value;}, (IBinding data) => (data as NickName).Name )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as NickName).Contexts = value;}, (IBinding data) => (data as NickName).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as NickName).Pref = value;}, (IBinding data) => (data as NickName).Pref )}
        }, __Tag,() => new NickName(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "NickName";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NickName();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NickName FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NickName;
			}
		var Result = new NickName ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Organization : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The name of the organization.
        /// </summary>

	public virtual string?					Name  {get; set;}

        /// <summary>
        /// A list of organizational units, ordered as descending by hierarchy 
        /// (e.g., a geographic or functional division sorts before a department 
        /// within that division). If set, the list MUST contain at least one entry.
        /// </summary>

	public virtual List<OrgUnit>?					Units  {get; set;}
        /// <summary>
        /// The value to lexicographically sort the organization in relation to 
        /// other organizations when compared by name. The value defines the 
        /// verbatim string value to compare. In absence of this property, 
        /// the name property value MAY be used for comparison.
        /// </summary>

	public virtual string?					SortAs  {get; set;}

        /// <summary>
        /// The contexts in which association with the organization applies. For 
        /// example, membership in a choir may only apply in a private context.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Organization).Type = value;}, (IBinding data) => (data as Organization).Type )},
			{ "name", new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Organization).Name = value;}, (IBinding data) => (data as Organization).Name )},
			{ "units", new PropertyListStruct ("units", 
					(IBinding data, object? value) => {(data as Organization).Units = value as List<OrgUnit>;}, (IBinding data) => (data as Organization).Units,
					false, ()=>new  List<OrgUnit>(), ()=>new OrgUnit())},
			{ "sortAs", new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as Organization).SortAs = value;}, (IBinding data) => (data as Organization).SortAs )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Organization).Contexts = value;}, (IBinding data) => (data as Organization).Contexts )}
        }, __Tag,() => new Organization(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Organization";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Organization();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Organization FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Organization;
			}
		var Result = new Organization ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class OrgUnit : Contacts {
        /// <summary>
        /// The name of the organizational unit.
        /// </summary>

	public virtual string?					Name  {get; set;}

        /// <summary>
        /// The value to lexicographically sort the organizational unit in relation 
        /// to other organizational units of the same level when compared by name. 
        /// The level is defined by the array index of the organizational unit in 
        /// the units property of the Organization object. The property value 
        /// defines the verbatim string value to compare. In absence of this 
        /// property, the name property value MAY be used for comparison.
        /// </summary>

	public virtual string?					SortAs  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "name", new PropertyString ("name", 
					(IBinding data, string? value) => {(data as OrgUnit).Name = value;}, (IBinding data) => (data as OrgUnit).Name )},
			{ "sortAs", new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as OrgUnit).SortAs = value;}, (IBinding data) => (data as OrgUnit).SortAs )}
        }, __Tag,() => new OrgUnit(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "OrgUnit";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OrgUnit();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new OrgUnit FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as OrgUnit;
			}
		var Result = new OrgUnit ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class SpeakToAs : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The grammatical gender to use in salutations and other grammatical 
        /// constructs. For example, the German language distinguishes by grammatical
        /// gender in salutations such as "Sehr geehrte" (feminine) and "Sehr geehrter"
        /// (masculine)
        /// </summary>

	public virtual string?					GrammaticalGender  {get; set;}

        /// <summary>
        /// The pronouns that the contact chooses to use for themselves.
        /// </summary>

	public virtual Dictionary<string,Pronouns>?					Pronouns  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as SpeakToAs).Type = value;}, (IBinding data) => (data as SpeakToAs).Type )},
			{ "grammaticalGender", new PropertyString ("grammaticalGender", 
					(IBinding data, string? value) => {(data as SpeakToAs).GrammaticalGender = value;}, (IBinding data) => (data as SpeakToAs).GrammaticalGender )},
			{ "pronouns", new PropertyDictionaryStruct ("pronouns", 
					(IBinding data, object? value) => {(data as SpeakToAs).Pronouns = value as Dictionary<string,Pronouns>;}, (IBinding data) => (data as SpeakToAs).Pronouns,
					false, ()=>new  Dictionary<string,Pronouns>(), ()=>new Pronouns(),
					(IBinding data) => (data as SpeakToAs).Pronouns.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Pronouns>).Add (key as string,value as Pronouns);})}
        }, __Tag,() => new SpeakToAs(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "SpeakToAs";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SpeakToAs();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SpeakToAs FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SpeakToAs;
			}
		var Result = new SpeakToAs ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Pronouns : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The pronouns. Any value or form is allowed. Examples in English include "she/her"
        /// and "they/them/theirs". The value MAY be overridden in the localizations 
        /// property.
        /// </summary>

	public virtual string?					Values  {get; set;}

        /// <summary>
        /// The contexts in which to use the pronouns.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the pronouns in relation to other pronouns in the same context.
        /// </summary>

	public virtual int?					Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Pronouns).Type = value;}, (IBinding data) => (data as Pronouns).Type )},
			{ "pronouns", new PropertyString ("pronouns", 
					(IBinding data, string? value) => {(data as Pronouns).Values = value;}, (IBinding data) => (data as Pronouns).Values )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Pronouns).Contexts = value;}, (IBinding data) => (data as Pronouns).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Pronouns).Pref = value;}, (IBinding data) => (data as Pronouns).Pref )}
        }, __Tag,() => new Pronouns(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Pronouns";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Pronouns();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Pronouns FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Pronouns;
			}
		var Result = new Pronouns ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Title : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The title or role name of the entity represented by the Card.
        /// </summary>

	public virtual string?					Name  {get; set;}

        /// <summary>
        /// The organizational or situational kind of the title. Some organizations and 
        /// individuals distinguish between titles as organizational positions and roles
        /// as more temporary assignments such as in project management.
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?					OrganizationId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Title).Type = value;}, (IBinding data) => (data as Title).Type )},
			{ "name", new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Title).Name = value;}, (IBinding data) => (data as Title).Name )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Title).Kind = value;}, (IBinding data) => (data as Title).Kind )},
			{ "organizationId", new PropertyString ("organizationId", 
					(IBinding data, string? value) => {(data as Title).OrganizationId = value;}, (IBinding data) => (data as Title).OrganizationId )}
        }, __Tag,() => new Title(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Title";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Title();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Title FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Title;
			}
		var Result = new Title ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class EmailAddress : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The email address. This MUST be an addr-spec value as defined in Section 3.4.1 of [RFC5322].
        /// </summary>

	public virtual string?					Address  {get; set;}

        /// <summary>
        /// The contexts in which to use this email address. Also see Section 1.5.1.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the email address in relation to other email addresses. Also 
        /// see Section 1.5.3.
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// A custom label for the value. 
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as EmailAddress).Type = value;}, (IBinding data) => (data as EmailAddress).Type )},
			{ "address", new PropertyString ("address", 
					(IBinding data, string? value) => {(data as EmailAddress).Address = value;}, (IBinding data) => (data as EmailAddress).Address )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as EmailAddress).Contexts = value;}, (IBinding data) => (data as EmailAddress).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as EmailAddress).Pref = value;}, (IBinding data) => (data as EmailAddress).Pref )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as EmailAddress).Label = value;}, (IBinding data) => (data as EmailAddress).Label )}
        }, __Tag,() => new EmailAddress(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "EmailAddress";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EmailAddress();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new EmailAddress FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as EmailAddress;
			}
		var Result = new EmailAddress ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class OnlineService : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The name of the online service or protocol. The name MAY be capitalized the 
        /// same as on the service's website, app, or publishing material, but names MUST 
        /// be considered equal if they match case-insensitively. Examples are "GitHub", 
        /// "kakao", and "Mastodon"
        /// </summary>

	public virtual string?					Service  {get; set;}

        /// <summary>
        /// The identifier for the entity represented by the Card at the online service. 
        /// This MUST be a URI as defined in Section 3 of [RFC3986].
        /// </summary>

	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// The name the entity represented by the Card at the online service. Any 
        /// free-text value is allowed. The service property SHOULD be set.
        /// </summary>

	public virtual string?					User  {get; set;}

        /// <summary>
        /// The contexts in which to use the service.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the service in relation to other services.
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// A custom label for the value. 
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as OnlineService).Type = value;}, (IBinding data) => (data as OnlineService).Type )},
			{ "service", new PropertyString ("service", 
					(IBinding data, string? value) => {(data as OnlineService).Service = value;}, (IBinding data) => (data as OnlineService).Service )},
			{ "uri", new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as OnlineService).Uri = value;}, (IBinding data) => (data as OnlineService).Uri )},
			{ "user", new PropertyString ("user", 
					(IBinding data, string? value) => {(data as OnlineService).User = value;}, (IBinding data) => (data as OnlineService).User )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as OnlineService).Contexts = value;}, (IBinding data) => (data as OnlineService).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as OnlineService).Pref = value;}, (IBinding data) => (data as OnlineService).Pref )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as OnlineService).Label = value;}, (IBinding data) => (data as OnlineService).Label )}
        }, __Tag,() => new OnlineService(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "OnlineService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OnlineService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new OnlineService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as OnlineService;
			}
		var Result = new OnlineService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Phone : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The phone number as either a URI or free text. Typical URI schemes are 
        /// "tel" [RFC3966] or "sip" [RFC3261], but any URI scheme is allowed.
        /// </summary>

	public virtual string?					Number  {get; set;}

        /// <summary>
        /// The set of contact features that the phone number may be used for. The set is 
        /// represented as an object, with each key being a method type. The boolean value 
        /// MUST be "true". The enumerated method type values are:
        ///
        /// mobile: this number is for a mobile phone.
        /// voice: this number supports calling by voice.
        /// text: this number supports text messages (SMS).
        /// video: this number supports video conferencing.
        /// main-number: this number is a main phone number such as the number of the front desk 
        ///   at a company, as opposed to a direct-dial number of an individual employee.
        /// textphone: this number is for a device for people with hearing or speech difficulties.
        /// fax: this number supports sending faxes.
        /// pager: this number is for a pager or beeper.
        /// </summary>

	public virtual Dictionary<string,bool>?					Features  {get; set;}

        /// <summary>
        /// The contexts in which to use the number. 
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the number in relation to other numbers.
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// A custom label for the value.
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Phone).Type = value;}, (IBinding data) => (data as Phone).Type )},
			{ "number", new PropertyString ("number", 
					(IBinding data, string? value) => {(data as Phone).Number = value;}, (IBinding data) => (data as Phone).Number )},
			{ "features", new PropertyDictionaryBoolean ("features", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Phone).Features = value;}, (IBinding data) => (data as Phone).Features )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Phone).Contexts = value;}, (IBinding data) => (data as Phone).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Phone).Pref = value;}, (IBinding data) => (data as Phone).Pref )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as Phone).Label = value;}, (IBinding data) => (data as Phone).Label )}
        }, __Tag,() => new Phone(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Phone";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Phone();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Phone FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Phone;
			}
		var Result = new Phone ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class LanguagePref : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The preferred language. This MUST be a language tag as defined in [RFC5646] .
        /// </summary>

	public virtual string?					Language  {get; set;}

        /// <summary>
        /// The contexts in which to use the language.
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The preference of the language in relation to other languages of the same contexts. 
        /// </summary>

	public virtual int?					Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as LanguagePref).Type = value;}, (IBinding data) => (data as LanguagePref).Type )},
			{ "language", new PropertyString ("language", 
					(IBinding data, string? value) => {(data as LanguagePref).Language = value;}, (IBinding data) => (data as LanguagePref).Language )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as LanguagePref).Contexts = value;}, (IBinding data) => (data as LanguagePref).Contexts )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as LanguagePref).Pref = value;}, (IBinding data) => (data as LanguagePref).Pref )}
        }, __Tag,() => new LanguagePref(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "LanguagePref";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new LanguagePref();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new LanguagePref FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as LanguagePref;
			}
		var Result = new LanguagePref ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The calendaring resources of the entity represented by the Card, such as 
	///  to look up free-busy information.
	/// </summary>
public partial class Calendar : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Calendar(), Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Resource._StaticAllProperties);


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
	public new const string __Tag = "Calendar";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Calendar();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Calendar FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Calendar;
			}
		var Result = new Calendar ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The scheduling addresses by which the entity may receive calendar scheduling invitations.
	/// </summary>
public partial class SchedulingAddress : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The address to use for calendar scheduling with the contact. This MUST 
        /// be a URI as defined in Section 3 of [RFC3986].
        /// </summary>

	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// The contexts in which to use the scheduling address. 
        /// </summary>

	public virtual List<Boolean>?					Contexts  {get; set;}
        /// <summary>
        /// The preference of the scheduling address in relation to other scheduling addresses.
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// A custom label for the scheduling address. 
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Type = value;}, (IBinding data) => (data as SchedulingAddress).Type )},
			{ "uri", new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Uri = value;}, (IBinding data) => (data as SchedulingAddress).Uri )},
			{ "contexts", new PropertyListStruct ("contexts", 
					(IBinding data, object? value) => {(data as SchedulingAddress).Contexts = value as List<Boolean>;}, (IBinding data) => (data as SchedulingAddress).Contexts,
					false, ()=>new  List<Boolean>(), ()=>new Boolean())},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as SchedulingAddress).Pref = value;}, (IBinding data) => (data as SchedulingAddress).Pref )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Label = value;}, (IBinding data) => (data as SchedulingAddress).Label )}
        }, __Tag,() => new SchedulingAddress(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "SchedulingAddress";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SchedulingAddress();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SchedulingAddress FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SchedulingAddress;
			}
		var Result = new SchedulingAddress ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The addresses of the entity represented by the Card, such as postal 
	///  addresses or geographic locations.
	/// </summary>
public partial class Address : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The components (Section 2.5.1.2) that make up the address. The component 
        /// list MUST have at least one entry that has a kind property value other 
        /// than "separator".
        /// </summary>

	public virtual List<AddressComponent>?					Components  {get; set;}
        /// <summary>
        /// The indicator if the address components in the components property are ordered.
        /// </summary>

	public virtual string?					IsOrdered  {get; set;}

        /// <summary>
        /// The Alpha-2 country code [ISO.3166-1].
        /// </summary>

	public virtual string?					CountryCode  {get; set;}

        /// <summary>
        /// A "geo:" URI [RFC5870] for the address.
        /// </summary>

	public virtual string?					Coordinates  {get; set;}

        /// <summary>
        /// The time zone in which the address is located. This MUST be a time zone 
        /// name registered in the IANA Time Zone Database [IANA-TZ].
        /// </summary>

	public virtual string?					TimeZone  {get; set;}

        /// <summary>
        /// The contexts in which to use this address. 
        /// </summary>

	public virtual Dictionary<string,bool>?					Contexts  {get; set;}

        /// <summary>
        /// The full address, including street, region, or country. The purpose of 
        /// this property is to define an address, even if the individual address 
        /// components are not known.
        /// </summary>

	public virtual string?					Full  {get; set;}

        /// <summary>
        /// The default separator to insert between address component values when 
        /// concatenating all address component values to a single String. Also see 
        /// the definition of the kind property value "separator" for the AddressComponent
        /// (Section 2.5.1.2) object. The defaultSeparator property MUST NOT be set 
        /// if the Address isOrdered property value is "false" or if the components 
        /// property is not set.
        /// </summary>

	public virtual string?					DefaultSeparator  {get; set;}

        /// <summary>
        /// The preference of the address in relation to other addresses. 
        /// </summary>

	public virtual int?					Pref  {get; set;}

        /// <summary>
        /// The script used in the value of the AddressComponent phonetic property.
        /// </summary>

	public virtual string?					PhoneticScript  {get; set;}

        /// <summary>
        /// The phonetic system used in the AddressComponent phonetic property.
        /// </summary>

	public virtual string?					PhoneticSystem  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Address).Type = value;}, (IBinding data) => (data as Address).Type )},
			{ "components", new PropertyListStruct ("components", 
					(IBinding data, object? value) => {(data as Address).Components = value as List<AddressComponent>;}, (IBinding data) => (data as Address).Components,
					false, ()=>new  List<AddressComponent>(), ()=>new AddressComponent())},
			{ "isOrdered", new PropertyString ("isOrdered", 
					(IBinding data, string? value) => {(data as Address).IsOrdered = value;}, (IBinding data) => (data as Address).IsOrdered )},
			{ "countryCode", new PropertyString ("countryCode", 
					(IBinding data, string? value) => {(data as Address).CountryCode = value;}, (IBinding data) => (data as Address).CountryCode )},
			{ "coordinates", new PropertyString ("coordinates", 
					(IBinding data, string? value) => {(data as Address).Coordinates = value;}, (IBinding data) => (data as Address).Coordinates )},
			{ "timeZone", new PropertyString ("timeZone", 
					(IBinding data, string? value) => {(data as Address).TimeZone = value;}, (IBinding data) => (data as Address).TimeZone )},
			{ "contexts", new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Address).Contexts = value;}, (IBinding data) => (data as Address).Contexts )},
			{ "full", new PropertyString ("full", 
					(IBinding data, string? value) => {(data as Address).Full = value;}, (IBinding data) => (data as Address).Full )},
			{ "defaultSeparator", new PropertyString ("defaultSeparator", 
					(IBinding data, string? value) => {(data as Address).DefaultSeparator = value;}, (IBinding data) => (data as Address).DefaultSeparator )},
			{ "pref", new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Address).Pref = value;}, (IBinding data) => (data as Address).Pref )},
			{ "phoneticScript", new PropertyString ("phoneticScript", 
					(IBinding data, string? value) => {(data as Address).PhoneticScript = value;}, (IBinding data) => (data as Address).PhoneticScript )},
			{ "phoneticSystem", new PropertyString ("phoneticSystem", 
					(IBinding data, string? value) => {(data as Address).PhoneticSystem = value;}, (IBinding data) => (data as Address).PhoneticSystem )}
        }, __Tag,() => new Address(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Address";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Address();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Address FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Address;
			}
		var Result = new Address ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class AddressComponent : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The value of the address component.
        /// </summary>

	public virtual string?					Value  {get; set;}

        /// <summary>
        /// The kind of the address component. 
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// The pronunciation of the name component. If this property is set, then 
        /// at least one of the Address object phoneticSystem or phoneticScript 
        /// properties MUST be set. 
        /// </summary>

	public virtual string?					Phonetic  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as AddressComponent).Type = value;}, (IBinding data) => (data as AddressComponent).Type )},
			{ "value", new PropertyString ("value", 
					(IBinding data, string? value) => {(data as AddressComponent).Value = value;}, (IBinding data) => (data as AddressComponent).Value )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as AddressComponent).Kind = value;}, (IBinding data) => (data as AddressComponent).Kind )},
			{ "phonetic", new PropertyString ("phonetic", 
					(IBinding data, string? value) => {(data as AddressComponent).Phonetic = value;}, (IBinding data) => (data as AddressComponent).Phonetic )}
        }, __Tag,() => new AddressComponent(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AddressComponent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AddressComponent();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AddressComponent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AddressComponent;
			}
		var Result = new AddressComponent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	/// The cryptographic resources such as public keys and certificates associated 
	///  with the entity represented by the Card.
	/// </summary>
public partial class CryptoKey : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new CryptoKey(), Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Resource._StaticAllProperties);


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
	public new const string __Tag = "CryptoKey";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptoKey();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptoKey FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptoKey;
			}
		var Result = new CryptoKey ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The directories containing information about the entity represented by the Card.
	///  The position of the directory resource in the list of all Directory objects 
	///  having the same kind property value in the Card. If set, the listAs value 
	///  MUST be higher than zero. Multiple directory resources MAY have the same 
	///  listAs property value or none. Sorting such same-valued entries is 
	///  implementation-specific.
	/// </summary>
public partial class ContactDirectory : Resource {
        /// <summary>
        /// </summary>

	public virtual int?					ListAs  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "listAs", new PropertyInteger32 ("listAs", 
					(IBinding data, int? value) => {(data as ContactDirectory).ListAs = value;}, (IBinding data) => (data as ContactDirectory).ListAs )}
        }, __Tag,() => new ContactDirectory(), Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Resource._StaticAllProperties);


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
	public new const string __Tag = "Directory";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContactDirectory();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContactDirectory FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContactDirectory;
			}
		var Result = new ContactDirectory ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The links to resources that do not fit any of the other use-case-specific resource properties.
	/// </summary>
public partial class ResourceLink : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new ResourceLink(), Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Resource._StaticAllProperties);


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
	public new const string __Tag = "ResourceLink";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResourceLink();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResourceLink FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResourceLink;
			}
		var Result = new ResourceLink ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The media resources such as photographs, avatars, or sounds that are associated 
	///  with the entity represented by the Card.
	/// </summary>
public partial class Media : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Media(), Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Resource._StaticAllProperties);


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
	public new const string __Tag = "Media";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Media();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Media FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Media;
			}
		var Result = new Media ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  A ContactCard used to overwrite parts of a contact card.
	/// </summary>
public partial class PatchObject : JmapBase {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new PatchObject(), JmapBase._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, JmapBase._StaticAllProperties);


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
	public new const string __Tag = "PatchObject";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PatchObject();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PatchObject FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PatchObject;
			}
		var Result = new PatchObject ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The memorable dates and events for the entity represented by the Card.
	/// </summary>
public partial class Anniversary : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The kind of anniversary.
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// Timestamp (mandatory; defaultType: PartialDate).
        /// The date of the anniversary in the Gregorian calendar. This MUST be 
        /// either a whole or partial calendar date or a complete UTC timestamp 
        /// (see the definition of the Timestamp and PartialDate object types below).
        /// </summary>

	public virtual TimeStamp?					Date  {get; set;}

        /// <summary>
        /// An address associated with this anniversary, e.g., the place of birth or death.
        /// </summary>

	public virtual Address?					Place  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Anniversary).Type = value;}, (IBinding data) => (data as Anniversary).Type )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Anniversary).Kind = value;}, (IBinding data) => (data as Anniversary).Kind )},
			{ "date", new PropertyStruct ("date", 
					(IBinding data, object? value) => {(data as Anniversary).Date = value as TimeStamp;}, (IBinding data) => (data as Anniversary).Date,
					false, ()=>new  TimeStamp(), ()=>new TimeStamp())},
			{ "place", new PropertyStruct ("place", 
					(IBinding data, object? value) => {(data as Anniversary).Place = value as Address;}, (IBinding data) => (data as Anniversary).Place,
					false, ()=>new  Address(), ()=>new Address())}
        }, __Tag,() => new Anniversary(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Anniversary";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Anniversary();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Anniversary FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Anniversary;
			}
		var Result = new Anniversary ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class TimeStamp : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The calendar year.
        /// </summary>

	public virtual int?					Year  {get; set;}

        /// <summary>
        /// The calendar month, represented as the integers 1 &lt;= month &lt;= 12. If 
        /// this property is set, then either the year or the day property MUST be set.
        /// </summary>

	public virtual int?					Month  {get; set;}

        /// <summary>
        /// The calendar month day, represented as the integers 1 &lt;= day &lt;= 31, 
        /// depending on the validity within the month and year. If this property 
        /// is set, then the month property MUST be set.
        /// </summary>

	public virtual int?					Day  {get; set;}

        /// <summary>
        /// The calendar system in which this date occurs, in lowercase. This 
        /// MUST be either a calendar system name registered as a Common Locale 
        /// Data Repository (CLDR) [RFC7529] or a vendor-specific value. The year,
        /// month, and day still MUST be represented in the Gregorian calendar. 
        /// Note that the year property might be required to convert the date 
        /// between the Gregorian calendar and the respective calendar system.
        /// </summary>

	public virtual string?					CalendarScale  {get; set;}

        /// <summary>
        /// The point in time in UTC time.
        /// </summary>

	public virtual string?					Utc  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as TimeStamp).Type = value;}, (IBinding data) => (data as TimeStamp).Type )},
			{ "year", new PropertyInteger32 ("year", 
					(IBinding data, int? value) => {(data as TimeStamp).Year = value;}, (IBinding data) => (data as TimeStamp).Year )},
			{ "month", new PropertyInteger32 ("month", 
					(IBinding data, int? value) => {(data as TimeStamp).Month = value;}, (IBinding data) => (data as TimeStamp).Month )},
			{ "day", new PropertyInteger32 ("day", 
					(IBinding data, int? value) => {(data as TimeStamp).Day = value;}, (IBinding data) => (data as TimeStamp).Day )},
			{ "calendarScale", new PropertyString ("calendarScale", 
					(IBinding data, string? value) => {(data as TimeStamp).CalendarScale = value;}, (IBinding data) => (data as TimeStamp).CalendarScale )},
			{ "utc", new PropertyString ("utc", 
					(IBinding data, string? value) => {(data as TimeStamp).Utc = value;}, (IBinding data) => (data as TimeStamp).Utc )}
        }, __Tag,() => new TimeStamp(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "TimeStamp";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TimeStamp();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TimeStamp FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TimeStamp;
			}
		var Result = new TimeStamp ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  A free-text note that is associated with the Card.
	/// </summary>
public partial class Note : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The free-text value of this note.
        /// </summary>

	public virtual string?					Value  {get; set;}

        /// <summary>
        /// The date and time when this note was created.
        /// </summary>

	public virtual string?					Created  {get; set;}

        /// <summary>
        /// The author of this note.
        /// </summary>

	public virtual Author?					Author  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Note).Type = value;}, (IBinding data) => (data as Note).Type )},
			{ "Note", new PropertyString ("Note", 
					(IBinding data, string? value) => {(data as Note).Value = value;}, (IBinding data) => (data as Note).Value )},
			{ "created", new PropertyString ("created", 
					(IBinding data, string? value) => {(data as Note).Created = value;}, (IBinding data) => (data as Note).Created )},
			{ "author", new PropertyStruct ("author", 
					(IBinding data, object? value) => {(data as Note).Author = value as Author;}, (IBinding data) => (data as Note).Author,
					false, ()=>new  Author(), ()=>new Author())}
        }, __Tag,() => new Note(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Note";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Note();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Note FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Note;
			}
		var Result = new Note ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The author of a note.
	/// </summary>
public partial class Author : Contacts {
        /// <summary>
        /// The JSContact type of the object. The value MUST be "Author", if set.
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The name of this author.
        /// </summary>

	public virtual string?					Name  {get; set;}

        /// <summary>
        /// The URI value that identifies the author.
        /// </summary>

	public virtual string?					Uri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "type", new PropertyString ("type", 
					(IBinding data, string? value) => {(data as Author).Type = value;}, (IBinding data) => (data as Author).Type )},
			{ "name", new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Author).Name = value;}, (IBinding data) => (data as Author).Name )},
			{ "uri", new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as Author).Uri = value;}, (IBinding data) => (data as Author).Uri )}
        }, __Tag,() => new Author(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "Author";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Author();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Author FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Author;
			}
		var Result = new Author ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  The personal information of the entity represented by the Card.
	/// </summary>
public partial class PersonalInfo : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?					Type  {get; set;}

        /// <summary>
        /// The kind of personal information
        /// </summary>

	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// The actual information
        /// </summary>

	public virtual string?					Value  {get; set;}

        /// <summary>
        /// The level of expertise or engagement in hobby or interest. 
        /// </summary>

	public virtual string?					Level  {get; set;}

        /// <summary>
        /// The position of the personal information in the list of all PersonalInfo
        /// objects that have the same kind property value in the Card. If set, the 
        /// listAs value MUST be higher than zero. Multiple personal information entries
        /// MAY have the same listAs property value or none. Sorting such same-valued 
        /// entries is implementation-specific.
        /// </summary>

	public virtual int?					ListAs  {get; set;}

        /// <summary>
        /// A custom label. 
        /// </summary>

	public virtual string?					Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as PersonalInfo).Type = value;}, (IBinding data) => (data as PersonalInfo).Type )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as PersonalInfo).Kind = value;}, (IBinding data) => (data as PersonalInfo).Kind )},
			{ "value", new PropertyString ("value", 
					(IBinding data, string? value) => {(data as PersonalInfo).Value = value;}, (IBinding data) => (data as PersonalInfo).Value )},
			{ "level", new PropertyString ("level", 
					(IBinding data, string? value) => {(data as PersonalInfo).Level = value;}, (IBinding data) => (data as PersonalInfo).Level )},
			{ "listAs", new PropertyInteger32 ("listAs", 
					(IBinding data, int? value) => {(data as PersonalInfo).ListAs = value;}, (IBinding data) => (data as PersonalInfo).ListAs )},
			{ "label", new PropertyString ("label", 
					(IBinding data, string? value) => {(data as PersonalInfo).Label = value;}, (IBinding data) => (data as PersonalInfo).Label )}
        }, __Tag,() => new PersonalInfo(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "PersonalInfo";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersonalInfo();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PersonalInfo FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PersonalInfo;
			}
		var Result = new PersonalInfo ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



