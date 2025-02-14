
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
//  This file was automatically generated at 2/13/2025 3:59:14 PM
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

	    {"ContactCard", ContactCard._Factory},
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
	    {"Directory", Directory._Factory},
	    {"Link", Link._Factory},
	    {"Media", Media._Factory},
	    {"PatchObject", PatchObject._Factory},
	    {"Anniversary", Anniversary._Factory},
	    {"TimeStamp", TimeStamp._Factory},
	    {"Note", Note._Factory},
	    {"Author", Author._Factory},
	    {"PersonalInfo", PersonalInfo._Factory}
		};

    // [ModuleInitializer]
	
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
public partial class ContactCard : Contacts {
        /// <summary>
        /// The JSContact type of the Card object. If specified, value MUST be 'card'
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The JSContact version of this Card. If specified, value MUST be '1.0'
        /// </summary>

	public virtual string?						Version  {get; set;}

        /// <summary>
        /// The date and time when the Card was created.
        /// </summary>

	public virtual DateTime?						Created  {get; set;}

        /// <summary>
        /// The kind of the entity the Card represents.
        /// individual: a single person
        /// group: a group of people or entities
        /// org: an organization
        /// location: a named location
        /// device: a device such as an appliance, a computer, or a network element
        /// application: a software application
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// The language tag, as defined in [RFC5646], that best describes the language 
        /// used for text in the Card, optionally including additional information such 
        /// as the script. Note that values MAY be localized in the localizations 
        /// property.
        /// </summary>

	public virtual string?						Language  {get; set;}

        /// <summary>
        /// The set of Cards that are members of this group Card. Each key in the set is 
        /// the uid property value of the member, and each boolean value MUST be "true".
        /// If this property is set, then the value of the kind property MUST be "group"
        /// </summary>

	public virtual string?						Members  {get; set;}

        /// <summary>
        /// The identifier for the product that created the Card. If set, the value MUST 
        /// be at least one character long.
        /// </summary>

	public virtual string?						ProdId  {get; set;}

        /// <summary>
        /// acquaintance agent child co-resident co-worker colleague 
        /// contact crush date emergency friend kin me met muse
        /// neighbor parent sibling spouse sweetheart
        /// </summary>

	public virtual Relation?						RelatedTo  {get; set;}

        /// <summary>
        /// An identifier that associates the object as the same across different systems, 
        /// address books, and views. The value SHOULD be a URN [RFC8141], but for 
        /// compatibility with [RFC6350], it MAY also be a URI [RFC3986] or free-text value.
        /// </summary>

	public virtual string?						Uid  {get; set;}

        /// <summary>
        ///The date and time when the data in the Card was last modified.
        /// </summary>

	public virtual string?						Updated  {get; set;}

        /// <summary>
        /// The name of the entity represented by the Card. This can be any type of name, 
        /// e.g., it can, but need not, be the legal name of a person.
        /// </summary>

	public virtual Name?						Name  {get; set;}

        /// <summary>
        /// The nicknames of the entity represented by the Card.
        /// </summary>

	public virtual NickName?						NickNames  {get; set;}

        /// <summary>
        /// The company or organization names and units associated with the Card.
        /// </summary>

	public virtual Organization?						Organizations  {get; set;}

        /// <summary>
        /// The information that directs how to address, speak to, or refer to the
        /// entity that is represented by the Card.
        /// </summary>

	public virtual SpeakToAs?						SpeakToAs  {get; set;}

        /// <summary>
        /// The job titles or functional positions of the entity represented by the Card.
        /// </summary>

	public virtual Title?						Titles  {get; set;}

        /// <summary>
        /// The email addresses in which to contact the entity represented by the Card.
        /// </summary>

	public virtual EmailAddress?						Emails  {get; set;}

        /// <summary>
        /// The online services that are associated with the entity represented by the Card.
        /// This can be messaging services, social media profiles, and other.
        /// </summary>

	public virtual OnlineService?						OnlineServices  {get; set;}

        /// <summary>
        /// The phone numbers by which to contact the entity represented by the Card.
        /// </summary>

	public virtual Phone?						Phones  {get; set;}

        /// <summary>
        /// The preferred languages for contacting the entity associated with the Card.
        /// </summary>

	public virtual LanguagePref?						PreferredLanguages  {get; set;}

        /// <summary>
        /// The calendaring resources of the entity represented by the Card, such as 
        /// to look up free-busy information.
        /// </summary>

	public virtual Calendar?						Calendars  {get; set;}

        /// <summary>
        /// The scheduling addresses by which the entity may receive calendar scheduling invitations.
        /// </summary>

	public virtual SchedulingAddress?						SchedulingAddresses  {get; set;}

        /// <summary>
        /// The addresses of the entity represented by the Card, such as postal addresses 
        /// or geographic locations.
        /// </summary>

	public virtual Address?						Addresses  {get; set;}

        /// <summary>
        ///The cryptographic resources such as public keys and certificates associated 
        /// with the entity represented by the Card.
        /// </summary>

	public virtual CryptoKey?						CryptoKeys  {get; set;}

        /// <summary>
        /// The directories containing information about the entity represented by the Card.
        /// </summary>

	public virtual Directory?						Directories  {get; set;}

        /// <summary>
        /// The links to resources that do not fit any of the other use-case-specific resource properties.
        /// </summary>

	public virtual Link?						Links  {get; set;}

        /// <summary>
        /// The media resources such as photographs, avatars, or sounds that are associated 
        /// with the entity represented by the Card.
        /// </summary>

	public virtual Media?						Media  {get; set;}

        /// <summary>
        /// The property values localized to languages other than the main language 
        /// (Section 2.1.5) of the Card. Localizations provide language-specific alternatives 
        /// for existing property values and SHOULD NOT add new properties. The keys in 
        /// the localizations property value are language tags [RFC5646]; the values 
        /// are of type PatchObject and localize the Card in that language tag. The paths 
        /// in the PatchObject are relative to the Card that includes the localizations
        /// property. A patch MUST NOT target the localizations property.
        /// </summary>

	public virtual PatchObject?						Localizations  {get; set;}

        /// <summary>
        /// The memorable dates and events for the entity represented by the Card.
        /// </summary>

	public virtual Anniversary?						Anniversaries  {get; set;}

        /// <summary>
        /// The set of free-text keywords, also known as tags.
        /// </summary>

	public virtual TaggedBoolean?						Keywords  {get; set;}

        /// <summary>
        /// The free-text notes that are associated with the Card.
        /// </summary>

	public virtual Note?						Notes  {get; set;}

        /// <summary>
        /// The personal information of the entity represented by the Card.
        /// </summary>

	public virtual PersonalInfo?						PersonalInfo  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as ContactCard).Type = value;}, (IBinding data) => (data as ContactCard).Type )},
			{ "Version", new PropertyString ("Version", 
					(IBinding data, string? value) => {(data as ContactCard).Version = value;}, (IBinding data) => (data as ContactCard).Version )},
			{ "Created", new PropertyDateTime ("Created", 
					(IBinding data, DateTime? value) => {(data as ContactCard).Created = value;}, (IBinding data) => (data as ContactCard).Created )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as ContactCard).Kind = value;}, (IBinding data) => (data as ContactCard).Kind )},
			{ "Language", new PropertyString ("Language", 
					(IBinding data, string? value) => {(data as ContactCard).Language = value;}, (IBinding data) => (data as ContactCard).Language )},
			{ "Members", new PropertyListString ("Members", 
					(IBinding data, string? value) => {(data as ContactCard).Members = value;}, (IBinding data) => (data as ContactCard).Members )},
			{ "ProdId", new PropertyString ("ProdId", 
					(IBinding data, string? value) => {(data as ContactCard).ProdId = value;}, (IBinding data) => (data as ContactCard).ProdId )},
			{ "RelatedTo", new PropertyListStruct ("RelatedTo", 
					(IBinding data, object? value) => {(data as ContactCard).RelatedTo = value as Relation?;}, (IBinding data) => (data as ContactCard).RelatedTo,
					false, ()=>new  Relation?(), ()=>new Relation())} ,
			{ "Uid", new PropertyString ("Uid", 
					(IBinding data, string? value) => {(data as ContactCard).Uid = value;}, (IBinding data) => (data as ContactCard).Uid )},
			{ "Updated", new PropertyString ("Updated", 
					(IBinding data, string? value) => {(data as ContactCard).Updated = value;}, (IBinding data) => (data as ContactCard).Updated )},
			{ "Name", new PropertyStruct ("Name", 
					(IBinding data, object? value) => {(data as ContactCard).Name = value as Name?;}, (IBinding data) => (data as ContactCard).Name,
					false, ()=>new  Name?(), ()=>new Name())} ,
			{ "NickNames", new PropertyListStruct ("NickNames", 
					(IBinding data, object? value) => {(data as ContactCard).NickNames = value as NickName?;}, (IBinding data) => (data as ContactCard).NickNames,
					false, ()=>new  NickName?(), ()=>new NickName())} ,
			{ "Organizations", new PropertyListStruct ("Organizations", 
					(IBinding data, object? value) => {(data as ContactCard).Organizations = value as Organization?;}, (IBinding data) => (data as ContactCard).Organizations,
					false, ()=>new  Organization?(), ()=>new Organization())} ,
			{ "SpeakToAs", new PropertyStruct ("SpeakToAs", 
					(IBinding data, object? value) => {(data as ContactCard).SpeakToAs = value as SpeakToAs?;}, (IBinding data) => (data as ContactCard).SpeakToAs,
					false, ()=>new  SpeakToAs?(), ()=>new SpeakToAs())} ,
			{ "Titles", new PropertyListStruct ("Titles", 
					(IBinding data, object? value) => {(data as ContactCard).Titles = value as Title?;}, (IBinding data) => (data as ContactCard).Titles,
					false, ()=>new  Title?(), ()=>new Title())} ,
			{ "Emails", new PropertyListStruct ("Emails", 
					(IBinding data, object? value) => {(data as ContactCard).Emails = value as EmailAddress?;}, (IBinding data) => (data as ContactCard).Emails,
					false, ()=>new  EmailAddress?(), ()=>new EmailAddress())} ,
			{ "OnlineServices", new PropertyListStruct ("OnlineServices", 
					(IBinding data, object? value) => {(data as ContactCard).OnlineServices = value as OnlineService?;}, (IBinding data) => (data as ContactCard).OnlineServices,
					false, ()=>new  OnlineService?(), ()=>new OnlineService())} ,
			{ "Phones", new PropertyListStruct ("Phones", 
					(IBinding data, object? value) => {(data as ContactCard).Phones = value as Phone?;}, (IBinding data) => (data as ContactCard).Phones,
					false, ()=>new  Phone?(), ()=>new Phone())} ,
			{ "PreferredLanguages", new PropertyListStruct ("PreferredLanguages", 
					(IBinding data, object? value) => {(data as ContactCard).PreferredLanguages = value as LanguagePref?;}, (IBinding data) => (data as ContactCard).PreferredLanguages,
					false, ()=>new  LanguagePref?(), ()=>new LanguagePref())} ,
			{ "Calendars", new PropertyListStruct ("Calendars", 
					(IBinding data, object? value) => {(data as ContactCard).Calendars = value as Calendar?;}, (IBinding data) => (data as ContactCard).Calendars,
					false, ()=>new  Calendar?(), ()=>new Calendar())} ,
			{ "SchedulingAddresses", new PropertyListStruct ("SchedulingAddresses", 
					(IBinding data, object? value) => {(data as ContactCard).SchedulingAddresses = value as SchedulingAddress?;}, (IBinding data) => (data as ContactCard).SchedulingAddresses,
					false, ()=>new  SchedulingAddress?(), ()=>new SchedulingAddress())} ,
			{ "Addresses", new PropertyListStruct ("Addresses", 
					(IBinding data, object? value) => {(data as ContactCard).Addresses = value as Address?;}, (IBinding data) => (data as ContactCard).Addresses,
					false, ()=>new  Address?(), ()=>new Address())} ,
			{ "CryptoKeys", new PropertyListStruct ("CryptoKeys", 
					(IBinding data, object? value) => {(data as ContactCard).CryptoKeys = value as CryptoKey?;}, (IBinding data) => (data as ContactCard).CryptoKeys,
					false, ()=>new  CryptoKey?(), ()=>new CryptoKey())} ,
			{ "Directories", new PropertyListStruct ("Directories", 
					(IBinding data, object? value) => {(data as ContactCard).Directories = value as Directory?;}, (IBinding data) => (data as ContactCard).Directories,
					false, ()=>new  Directory?(), ()=>new Directory())} ,
			{ "Links", new PropertyListStruct ("Links", 
					(IBinding data, object? value) => {(data as ContactCard).Links = value as Link?;}, (IBinding data) => (data as ContactCard).Links,
					false, ()=>new  Link?(), ()=>new Link())} ,
			{ "Media", new PropertyListStruct ("Media", 
					(IBinding data, object? value) => {(data as ContactCard).Media = value as Media?;}, (IBinding data) => (data as ContactCard).Media,
					false, ()=>new  Media?(), ()=>new Media())} ,
			{ "Localizations", new PropertyListStruct ("Localizations", 
					(IBinding data, object? value) => {(data as ContactCard).Localizations = value as PatchObject?;}, (IBinding data) => (data as ContactCard).Localizations,
					false, ()=>new  PatchObject?(), ()=>new PatchObject())} ,
			{ "Anniversaries", new PropertyListStruct ("Anniversaries", 
					(IBinding data, object? value) => {(data as ContactCard).Anniversaries = value as Anniversary?;}, (IBinding data) => (data as ContactCard).Anniversaries,
					false, ()=>new  Anniversary?(), ()=>new Anniversary())} ,
			{ "Keywords", new PropertyListStruct ("Keywords", 
					(IBinding data, object? value) => {(data as ContactCard).Keywords = value as TaggedBoolean?;}, (IBinding data) => (data as ContactCard).Keywords,
					false, ()=>new  TaggedBoolean?(), ()=>new TaggedBoolean())} ,
			{ "Notes", new PropertyListStruct ("Notes", 
					(IBinding data, object? value) => {(data as ContactCard).Notes = value as Note?;}, (IBinding data) => (data as ContactCard).Notes,
					false, ()=>new  Note?(), ()=>new Note())} ,
			{ "PersonalInfo", new PropertyListStruct ("PersonalInfo", 
					(IBinding data, object? value) => {(data as ContactCard).PersonalInfo = value as PersonalInfo?;}, (IBinding data) => (data as ContactCard).PersonalInfo,
					false, ()=>new  PersonalInfo?(), ()=>new PersonalInfo())} 
        }, __Tag,() => new ContactCard(), null);

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
	public new const string __Tag = "ContactCard";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContactCard();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContactCard FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContactCard;
			}
		var Result = new ContactCard ();
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

	public virtual bool?						Relationships  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Relationships", new PropertyListBoolean ("Relationships", 
					(IBinding data, bool? value) => {(data as Relation).Relationships = value;}, (IBinding data) => (data as Relation).Relationships )}
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
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?						Uri  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Resource).Type = value;}, (IBinding data) => (data as Resource).Type )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as Resource).Kind = value;}, (IBinding data) => (data as Resource).Kind )},
			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as Resource).Uri = value;}, (IBinding data) => (data as Resource).Uri )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as Resource).Contexts = value;}, (IBinding data) => (data as Resource).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as Resource).Pref = value;}, (IBinding data) => (data as Resource).Pref )},
			{ "Label", new PropertyString ("Label", 
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

	public virtual string?						Type  {get; set;}

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

	public virtual bool?						IsOrdered  {get; set;}

        /// <summary>
        /// The default separator to insert between name component values when 
        /// concatenating all name component values to a single String. Also see 
        /// the definition of the kind property value "separator" for the 
        /// NameComponent (Section 2.2.1.2) object. The defaultSeparator property 
        /// MUST NOT be set if the Name isOrdered property value is "false" or 
        /// if the components property is not set.
        /// </summary>

	public virtual string?						DefaultSeparator  {get; set;}

        /// <summary>
        /// The full name representation of the Name. The full property MUST be set 
        /// if the components property is not set.
        /// </summary>

	public virtual string?						Full  {get; set;}

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

	public virtual string?						SortAs  {get; set;}

        /// <summary>
        /// The script used in the value of the NameComponent phonetic property.
        /// </summary>

	public virtual string?						PhoneticScript  {get; set;}

        /// <summary>
        /// The phonetic system used in the NameComponent phonetic property.
        /// </summary>

	public virtual string?						PhoneticSystem  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Name).Type = value;}, (IBinding data) => (data as Name).Type )},
			{ "Components", new PropertyListStruct ("Components", 
					(IBinding data, object? value) => {(data as Name).Components = value as List<NameComponent>?;}, (IBinding data) => (data as Name).Components,
					false, ()=>new  List<NameComponent>?(), ()=>new NameComponent())} ,
			{ "IsOrdered", new PropertyBoolean ("IsOrdered", 
					(IBinding data, bool? value) => {(data as Name).IsOrdered = value;}, (IBinding data) => (data as Name).IsOrdered )},
			{ "DefaultSeparator", new PropertyString ("DefaultSeparator", 
					(IBinding data, string? value) => {(data as Name).DefaultSeparator = value;}, (IBinding data) => (data as Name).DefaultSeparator )},
			{ "Full", new PropertyString ("Full", 
					(IBinding data, string? value) => {(data as Name).Full = value;}, (IBinding data) => (data as Name).Full )},
			{ "SortAs", new PropertyString ("SortAs", 
					(IBinding data, string? value) => {(data as Name).SortAs = value;}, (IBinding data) => (data as Name).SortAs )},
			{ "PhoneticScript", new PropertyString ("PhoneticScript", 
					(IBinding data, string? value) => {(data as Name).PhoneticScript = value;}, (IBinding data) => (data as Name).PhoneticScript )},
			{ "PhoneticSystem", new PropertyString ("PhoneticSystem", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?						Value  {get; set;}

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

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Phonetic  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as NameComponent).Type = value;}, (IBinding data) => (data as NameComponent).Type )},
			{ "Value", new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as NameComponent).Value = value;}, (IBinding data) => (data as NameComponent).Value )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as NameComponent).Kind = value;}, (IBinding data) => (data as NameComponent).Kind )},
			{ "Phonetic", new PropertyString ("Phonetic", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The nickname.
        /// </summary>

	public virtual string?						Name  {get; set;}

        /// <summary>
        /// The contexts in which to use the nickname.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the nickname in relation to other nicknames. 
        /// </summary>

	public virtual int?						Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as NickName).Type = value;}, (IBinding data) => (data as NickName).Type )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as NickName).Name = value;}, (IBinding data) => (data as NickName).Name )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as NickName).Contexts = value;}, (IBinding data) => (data as NickName).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The name of the organization.
        /// </summary>

	public virtual string?						Name  {get; set;}

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

	public virtual string?						SortAs  {get; set;}

        /// <summary>
        /// The contexts in which association with the organization applies. For 
        /// example, membership in a choir may only apply in a private context.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Organization).Type = value;}, (IBinding data) => (data as Organization).Type )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Organization).Name = value;}, (IBinding data) => (data as Organization).Name )},
			{ "Units", new PropertyListStruct ("Units", 
					(IBinding data, object? value) => {(data as Organization).Units = value as List<OrgUnit>?;}, (IBinding data) => (data as Organization).Units,
					false, ()=>new  List<OrgUnit>?(), ()=>new OrgUnit())} ,
			{ "SortAs", new PropertyString ("SortAs", 
					(IBinding data, string? value) => {(data as Organization).SortAs = value;}, (IBinding data) => (data as Organization).SortAs )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as Organization).Contexts = value;}, (IBinding data) => (data as Organization).Contexts )}
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

	public virtual string?						Name  {get; set;}

        /// <summary>
        /// The value to lexicographically sort the organizational unit in relation 
        /// to other organizational units of the same level when compared by name. 
        /// The level is defined by the array index of the organizational unit in 
        /// the units property of the Organization object. The property value 
        /// defines the verbatim string value to compare. In absence of this 
        /// property, the name property value MAY be used for comparison.
        /// </summary>

	public virtual string?						SortAs  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as OrgUnit).Name = value;}, (IBinding data) => (data as OrgUnit).Name )},
			{ "SortAs", new PropertyString ("SortAs", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The grammatical gender to use in salutations and other grammatical 
        /// constructs. For example, the German language distinguishes by grammatical
        /// gender in salutations such as "Sehr geehrte" (feminine) and "Sehr geehrter"
        /// (masculine)
        /// </summary>

	public virtual string?						grammaticalGender  {get; set;}

        /// <summary>
        /// The pronouns that the contact chooses to use for themselves.
        /// </summary>

	public virtual Pronouns?						Pronouns  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as SpeakToAs).Type = value;}, (IBinding data) => (data as SpeakToAs).Type )},
			{ "grammaticalGender", new PropertyString ("grammaticalGender", 
					(IBinding data, string? value) => {(data as SpeakToAs).grammaticalGender = value;}, (IBinding data) => (data as SpeakToAs).grammaticalGender )},
			{ "Pronouns", new PropertyListStruct ("Pronouns", 
					(IBinding data, object? value) => {(data as SpeakToAs).Pronouns = value as Pronouns?;}, (IBinding data) => (data as SpeakToAs).Pronouns,
					false, ()=>new  Pronouns?(), ()=>new Pronouns())} 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The pronouns. Any value or form is allowed. Examples in English include "she/her"
        /// and "they/them/theirs". The value MAY be overridden in the localizations 
        /// property.
        /// </summary>

	public virtual string?						Pronouns  {get; set;}

        /// <summary>
        /// The contexts in which to use the pronouns.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the pronouns in relation to other pronouns in the same context.
        /// </summary>

	public virtual int?						Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Pronouns).Type = value;}, (IBinding data) => (data as Pronouns).Type )},
			{ "Pronouns", new PropertyString ("Pronouns", 
					(IBinding data, string? value) => {(data as Pronouns).Pronouns = value;}, (IBinding data) => (data as Pronouns).Pronouns )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as Pronouns).Contexts = value;}, (IBinding data) => (data as Pronouns).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The title or role name of the entity represented by the Card.
        /// </summary>

	public virtual string?						Name  {get; set;}

        /// <summary>
        /// The organizational or situational kind of the title. Some organizations and 
        /// individuals distinguish between titles as organizational positions and roles
        /// as more temporary assignments such as in project management.
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// 
        /// </summary>

	public virtual string?						OrganizationId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Title).Type = value;}, (IBinding data) => (data as Title).Type )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Title).Name = value;}, (IBinding data) => (data as Title).Name )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as Title).Kind = value;}, (IBinding data) => (data as Title).Kind )},
			{ "OrganizationId", new PropertyString ("OrganizationId", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The email address. This MUST be an addr-spec value as defined in Section 3.4.1 of [RFC5322].
        /// </summary>

	public virtual string?						Address  {get; set;}

        /// <summary>
        /// The contexts in which to use this email address. Also see Section 1.5.1.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the email address in relation to other email addresses. Also 
        /// see Section 1.5.3.
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// A custom label for the value. 
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as EmailAddress).Type = value;}, (IBinding data) => (data as EmailAddress).Type )},
			{ "Address", new PropertyString ("Address", 
					(IBinding data, string? value) => {(data as EmailAddress).Address = value;}, (IBinding data) => (data as EmailAddress).Address )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as EmailAddress).Contexts = value;}, (IBinding data) => (data as EmailAddress).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as EmailAddress).Pref = value;}, (IBinding data) => (data as EmailAddress).Pref )},
			{ "Label", new PropertyString ("Label", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The name of the online service or protocol. The name MAY be capitalized the 
        /// same as on the service's website, app, or publishing material, but names MUST 
        /// be considered equal if they match case-insensitively. Examples are "GitHub", 
        /// "kakao", and "Mastodon"
        /// </summary>

	public virtual string?						Service  {get; set;}

        /// <summary>
        /// he identifier for the entity represented by the Card at the online service. 
        /// This MUST be a URI as defined in Section 3 of [RFC3986].
        /// </summary>

	public virtual string?						Uri  {get; set;}

        /// <summary>
        /// The name the entity represented by the Card at the online service. Any 
        /// free-text value is allowed. The service property SHOULD be set.
        /// </summary>

	public virtual string?						User  {get; set;}

        /// <summary>
        /// The contexts in which to use the service.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the service in relation to other services.
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// A custom label for the value. 
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as OnlineService).Type = value;}, (IBinding data) => (data as OnlineService).Type )},
			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as OnlineService).Service = value;}, (IBinding data) => (data as OnlineService).Service )},
			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as OnlineService).Uri = value;}, (IBinding data) => (data as OnlineService).Uri )},
			{ "User", new PropertyString ("User", 
					(IBinding data, string? value) => {(data as OnlineService).User = value;}, (IBinding data) => (data as OnlineService).User )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as OnlineService).Contexts = value;}, (IBinding data) => (data as OnlineService).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as OnlineService).Pref = value;}, (IBinding data) => (data as OnlineService).Pref )},
			{ "Label", new PropertyString ("Label", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The phone number as either a URI or free text. Typical URI schemes are 
        /// "tel" [RFC3966] or "sip" [RFC3261], but any URI scheme is allowed.
        /// </summary>

	public virtual string?						Number  {get; set;}

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

	public virtual bool?						Features  {get; set;}

        /// <summary>
        /// The contexts in which to use the number. 
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the number in relation to other numbers.
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// A custom label for the value.
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Phone).Type = value;}, (IBinding data) => (data as Phone).Type )},
			{ "Number", new PropertyString ("Number", 
					(IBinding data, string? value) => {(data as Phone).Number = value;}, (IBinding data) => (data as Phone).Number )},
			{ "Features", new PropertyListBoolean ("Features", 
					(IBinding data, bool? value) => {(data as Phone).Features = value;}, (IBinding data) => (data as Phone).Features )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as Phone).Contexts = value;}, (IBinding data) => (data as Phone).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as Phone).Pref = value;}, (IBinding data) => (data as Phone).Pref )},
			{ "Label", new PropertyString ("Label", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The preferred language. This MUST be a language tag as defined in [RFC5646] .
        /// </summary>

	public virtual string?						Language  {get; set;}

        /// <summary>
        /// The contexts in which to use the language.
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The preference of the language in relation to other languages of the same contexts. 
        /// </summary>

	public virtual int?						Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as LanguagePref).Type = value;}, (IBinding data) => (data as LanguagePref).Type )},
			{ "Language", new PropertyString ("Language", 
					(IBinding data, string? value) => {(data as LanguagePref).Language = value;}, (IBinding data) => (data as LanguagePref).Language )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as LanguagePref).Contexts = value;}, (IBinding data) => (data as LanguagePref).Contexts )},
			{ "Pref", new PropertyInteger32 ("Pref", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The address to use for calendar scheduling with the contact. This MUST 
        /// be a URI as defined in Section 3 of [RFC3986].
        /// </summary>

	public virtual string?						Uri  {get; set;}

        /// <summary>
        /// The contexts in which to use the scheduling address. 
        /// </summary>

	public virtual List<TaggedBoolean>?					Contexts  {get; set;}
        /// <summary>
        /// The preference of the scheduling address in relation to other scheduling addresses.
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// A custom label for the scheduling address. 
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Type = value;}, (IBinding data) => (data as SchedulingAddress).Type )},
			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Uri = value;}, (IBinding data) => (data as SchedulingAddress).Uri )},
			{ "Contexts", new PropertyListStruct ("Contexts", 
					(IBinding data, object? value) => {(data as SchedulingAddress).Contexts = value as List<TaggedBoolean>?;}, (IBinding data) => (data as SchedulingAddress).Contexts,
					false, ()=>new  List<TaggedBoolean>?(), ()=>new TaggedBoolean())} ,
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as SchedulingAddress).Pref = value;}, (IBinding data) => (data as SchedulingAddress).Pref )},
			{ "Label", new PropertyString ("Label", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The components (Section 2.5.1.2) that make up the address. The component 
        /// list MUST have at least one entry that has a kind property value other 
        /// than "separator".
        /// </summary>

	public virtual List<AddressComponent>?					Components  {get; set;}
        /// <summary>
        /// The indicator if the address components in the components property are ordered.
        /// </summary>

	public virtual string?						IsOrdered  {get; set;}

        /// <summary>
        /// The Alpha-2 country code [ISO.3166-1].
        /// </summary>

	public virtual string?						CountryCode  {get; set;}

        /// <summary>
        /// A "geo:" URI [RFC5870] for the address.
        /// </summary>

	public virtual string?						Coordinates  {get; set;}

        /// <summary>
        /// The time zone in which the address is located. This MUST be a time zone 
        /// name registered in the IANA Time Zone Database [IANA-TZ].
        /// </summary>

	public virtual string?						TimeZone  {get; set;}

        /// <summary>
        /// The contexts in which to use this address. 
        /// </summary>

	public virtual bool?						Contexts  {get; set;}

        /// <summary>
        /// The full address, including street, region, or country. The purpose of 
        /// this property is to define an address, even if the individual address 
        /// components are not known.
        /// </summary>

	public virtual string?						Full  {get; set;}

        /// <summary>
        /// The default separator to insert between address component values when 
        /// concatenating all address component values to a single String. Also see 
        /// the definition of the kind property value "separator" for the AddressComponent
        /// (Section 2.5.1.2) object. The defaultSeparator property MUST NOT be set 
        /// if the Address isOrdered property value is "false" or if the components 
        /// property is not set.
        /// </summary>

	public virtual string?						DefaultSeparator  {get; set;}

        /// <summary>
        /// The preference of the address in relation to other addresses. 
        /// </summary>

	public virtual int?						Pref  {get; set;}

        /// <summary>
        /// The script used in the value of the AddressComponent phonetic property.
        /// </summary>

	public virtual string?						PhoneticScript  {get; set;}

        /// <summary>
        /// The phonetic system used in the AddressComponent phonetic property.
        /// </summary>

	public virtual string?						PhoneticSystem  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Address).Type = value;}, (IBinding data) => (data as Address).Type )},
			{ "Components", new PropertyListStruct ("Components", 
					(IBinding data, object? value) => {(data as Address).Components = value as List<AddressComponent>?;}, (IBinding data) => (data as Address).Components,
					false, ()=>new  List<AddressComponent>?(), ()=>new AddressComponent())} ,
			{ "IsOrdered", new PropertyString ("IsOrdered", 
					(IBinding data, string? value) => {(data as Address).IsOrdered = value;}, (IBinding data) => (data as Address).IsOrdered )},
			{ "CountryCode", new PropertyString ("CountryCode", 
					(IBinding data, string? value) => {(data as Address).CountryCode = value;}, (IBinding data) => (data as Address).CountryCode )},
			{ "Coordinates", new PropertyString ("Coordinates", 
					(IBinding data, string? value) => {(data as Address).Coordinates = value;}, (IBinding data) => (data as Address).Coordinates )},
			{ "TimeZone", new PropertyString ("TimeZone", 
					(IBinding data, string? value) => {(data as Address).TimeZone = value;}, (IBinding data) => (data as Address).TimeZone )},
			{ "Contexts", new PropertyListBoolean ("Contexts", 
					(IBinding data, bool? value) => {(data as Address).Contexts = value;}, (IBinding data) => (data as Address).Contexts )},
			{ "Full", new PropertyString ("Full", 
					(IBinding data, string? value) => {(data as Address).Full = value;}, (IBinding data) => (data as Address).Full )},
			{ "DefaultSeparator", new PropertyString ("DefaultSeparator", 
					(IBinding data, string? value) => {(data as Address).DefaultSeparator = value;}, (IBinding data) => (data as Address).DefaultSeparator )},
			{ "Pref", new PropertyInteger32 ("Pref", 
					(IBinding data, int? value) => {(data as Address).Pref = value;}, (IBinding data) => (data as Address).Pref )},
			{ "PhoneticScript", new PropertyString ("PhoneticScript", 
					(IBinding data, string? value) => {(data as Address).PhoneticScript = value;}, (IBinding data) => (data as Address).PhoneticScript )},
			{ "PhoneticSystem", new PropertyString ("PhoneticSystem", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The value of the address component.
        /// </summary>

	public virtual string?						Value  {get; set;}

        /// <summary>
        /// The kind of the address component. 
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// The pronunciation of the name component. If this property is set, then 
        /// at least one of the Address object phoneticSystem or phoneticScript 
        /// properties MUST be set. 
        /// </summary>

	public virtual string?						Phonetic  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as AddressComponent).Type = value;}, (IBinding data) => (data as AddressComponent).Type )},
			{ "Value", new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as AddressComponent).Value = value;}, (IBinding data) => (data as AddressComponent).Value )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as AddressComponent).Kind = value;}, (IBinding data) => (data as AddressComponent).Kind )},
			{ "Phonetic", new PropertyString ("Phonetic", 
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
public partial class Directory : Resource {
        /// <summary>
        /// </summary>

	public virtual int?						ListAs  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "ListAs", new PropertyInteger32 ("ListAs", 
					(IBinding data, int? value) => {(data as Directory).ListAs = value;}, (IBinding data) => (data as Directory).ListAs )}
        }, __Tag,() => new Directory(), Resource._binding);

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
	public static new JsonObject _Factory () => new Directory();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Directory FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Directory;
			}
		var Result = new Directory ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	///  The links to resources that do not fit any of the other use-case-specific resource properties.
	/// </summary>
public partial class Link : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Link(), Resource._binding);

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
	public new const string __Tag = "Link";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Link();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Link FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Link;
			}
		var Result = new Link ();
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
public partial class PatchObject : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new PatchObject(), Resource._binding);

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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The kind of anniversary.
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// Timestamp (mandatory; defaultType: PartialDate).
        /// The date of the anniversary in the Gregorian calendar. This MUST be 
        /// either a whole or partial calendar date or a complete UTC timestamp 
        /// (see the definition of the Timestamp and PartialDate object types below).
        /// </summary>

	public virtual TimeStamp?						Date  {get; set;}

        /// <summary>
        /// An address associated with this anniversary, e.g., the place of birth or death.
        /// </summary>

	public virtual Address?						Place  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Anniversary).Type = value;}, (IBinding data) => (data as Anniversary).Type )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as Anniversary).Kind = value;}, (IBinding data) => (data as Anniversary).Kind )},
			{ "Date", new PropertyStruct ("Date", 
					(IBinding data, object? value) => {(data as Anniversary).Date = value as TimeStamp?;}, (IBinding data) => (data as Anniversary).Date,
					false, ()=>new  TimeStamp?(), ()=>new TimeStamp())} ,
			{ "Place", new PropertyStruct ("Place", 
					(IBinding data, object? value) => {(data as Anniversary).Place = value as Address?;}, (IBinding data) => (data as Anniversary).Place,
					false, ()=>new  Address?(), ()=>new Address())} 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The calendar year.
        /// </summary>

	public virtual int?						Year  {get; set;}

        /// <summary>
        /// The calendar month, represented as the integers 1 <= month <= 12. If 
        /// this property is set, then either the year or the day property MUST be set.
        /// </summary>

	public virtual int?						Month  {get; set;}

        /// <summary>
        /// The calendar month day, represented as the integers 1 <= day <= 31, 
        /// depending on the validity within the month and year. If this property 
        /// is set, then the month property MUST be set.
        /// </summary>

	public virtual int?						Day  {get; set;}

        /// <summary>
        /// The calendar system in which this date occurs, in lowercase. This 
        /// MUST be either a calendar system name registered as a Common Locale 
        /// Data Repository (CLDR) [RFC7529] or a vendor-specific value. The year,
        /// month, and day still MUST be represented in the Gregorian calendar. 
        /// Note that the year property might be required to convert the date 
        /// between the Gregorian calendar and the respective calendar system.
        /// </summary>

	public virtual string?						CalendarScale  {get; set;}

        /// <summary>
        /// The point in time in UTC time.
        /// </summary>

	public virtual string?						Utc  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as TimeStamp).Type = value;}, (IBinding data) => (data as TimeStamp).Type )},
			{ "Year", new PropertyInteger32 ("Year", 
					(IBinding data, int? value) => {(data as TimeStamp).Year = value;}, (IBinding data) => (data as TimeStamp).Year )},
			{ "Month", new PropertyInteger32 ("Month", 
					(IBinding data, int? value) => {(data as TimeStamp).Month = value;}, (IBinding data) => (data as TimeStamp).Month )},
			{ "Day", new PropertyInteger32 ("Day", 
					(IBinding data, int? value) => {(data as TimeStamp).Day = value;}, (IBinding data) => (data as TimeStamp).Day )},
			{ "CalendarScale", new PropertyString ("CalendarScale", 
					(IBinding data, string? value) => {(data as TimeStamp).CalendarScale = value;}, (IBinding data) => (data as TimeStamp).CalendarScale )},
			{ "Utc", new PropertyString ("Utc", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The free-text value of this note.
        /// </summary>

	public virtual string?						Note  {get; set;}

        /// <summary>
        /// The date and time when this note was created.
        /// </summary>

	public virtual string?						Created  {get; set;}

        /// <summary>
        /// The author of this note.
        /// </summary>

	public virtual Author?						Author  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Note).Type = value;}, (IBinding data) => (data as Note).Type )},
			{ "Note", new PropertyString ("Note", 
					(IBinding data, string? value) => {(data as Note).Note = value;}, (IBinding data) => (data as Note).Note )},
			{ "Created", new PropertyString ("Created", 
					(IBinding data, string? value) => {(data as Note).Created = value;}, (IBinding data) => (data as Note).Created )},
			{ "Author", new PropertyStruct ("Author", 
					(IBinding data, object? value) => {(data as Note).Author = value as Author?;}, (IBinding data) => (data as Note).Author,
					false, ()=>new  Author?(), ()=>new Author())} 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The name of this author.
        /// </summary>

	public virtual string?						Name  {get; set;}

        /// <summary>
        /// The URI value that identifies the author.
        /// </summary>

	public virtual string?						Uri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Type", new PropertyString ("Type", 
					(IBinding data, string? value) => {(data as Author).Type = value;}, (IBinding data) => (data as Author).Type )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Author).Name = value;}, (IBinding data) => (data as Author).Name )},
			{ "Uri", new PropertyString ("Uri", 
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

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// The kind of personal information
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// The actual information
        /// </summary>

	public virtual string?						Value  {get; set;}

        /// <summary>
        /// The level of expertise or engagement in hobby or interest. 
        /// </summary>

	public virtual string?						Level  {get; set;}

        /// <summary>
        /// The position of the personal information in the list of all PersonalInfo
        /// objects that have the same kind property value in the Card. If set, the 
        /// listAs value MUST be higher than zero. Multiple personal information entries
        /// MAY have the same listAs property value or none. Sorting such same-valued 
        /// entries is implementation-specific.
        /// </summary>

	public virtual int?						ListAs  {get; set;}

        /// <summary>
        /// A custom label. 
        /// </summary>

	public virtual string?						Label  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as PersonalInfo).Type = value;}, (IBinding data) => (data as PersonalInfo).Type )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as PersonalInfo).Kind = value;}, (IBinding data) => (data as PersonalInfo).Kind )},
			{ "Value", new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as PersonalInfo).Value = value;}, (IBinding data) => (data as PersonalInfo).Value )},
			{ "Level", new PropertyString ("Level", 
					(IBinding data, string? value) => {(data as PersonalInfo).Level = value;}, (IBinding data) => (data as PersonalInfo).Level )},
			{ "ListAs", new PropertyInteger32 ("ListAs", 
					(IBinding data, int? value) => {(data as PersonalInfo).ListAs = value;}, (IBinding data) => (data as PersonalInfo).ListAs )},
			{ "Label", new PropertyString ("Label", 
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



