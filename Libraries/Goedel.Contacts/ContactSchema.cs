
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
//  This file was automatically generated at 7/13/2025 3:45:31 PM
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsContact), JsContact._binding},
	    {typeof(Resource), Resource._binding},
	    {typeof(Name), Name._binding},
	    {typeof(NameComponent), NameComponent._binding},
	    {typeof(NickName), NickName._binding},
	    {typeof(Organization), Organization._binding},
	    {typeof(OrgUnit), OrgUnit._binding},
	    {typeof(SpeakToAs), SpeakToAs._binding},
	    {typeof(Pronouns), Pronouns._binding},
	    {typeof(Title), Title._binding},
	    {typeof(EmailAddress), EmailAddress._binding},
	    {typeof(OnlineService), OnlineService._binding},
	    {typeof(Phone), Phone._binding},
	    {typeof(LanguagePref), LanguagePref._binding},
	    {typeof(Calendar), Calendar._binding},
	    {typeof(SchedulingAddress), SchedulingAddress._binding},
	    {typeof(Address), Address._binding},
	    {typeof(AddressComponent), AddressComponent._binding},
	    {typeof(CryptoKey), CryptoKey._binding},
	    {typeof(ContactDirectory), ContactDirectory._binding},
	    {typeof(ResourceLink), ResourceLink._binding},
	    {typeof(Media), Media._binding},
	    {typeof(Anniversary), Anniversary._binding},
	    {typeof(TimeStamp), TimeStamp._binding},
	    {typeof(Note), Note._binding},
	    {typeof(Author), Author._binding},
	    {typeof(PersonalInfo), PersonalInfo._binding},
	    {typeof(Update), Update._binding},
	    {typeof(JsonWebKeySet), JsonWebKeySet._binding},
	    {typeof(ServiceGroup), ServiceGroup._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Contacts() {
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
	///  Metadata, see section 2.1
	/// </summary>
public partial class JsContact : JmapBase {
    /// <summary>
    /// The JSContact version of this Card. If specified, value MUST be '1.0'
    /// </summary>

	[JsonPropertyName("version")]
	public virtual string?					Version  {get; set;} //

    /// <summary>
    /// The kind of the entity the Card represents.
    /// individual: a single person
    /// group: a group of people or entities
    /// org: an organization
    /// location: a named location
    /// device: a device such as an appliance, a computer, or a network element
    /// application: a software application
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// The language tag, as defined in [RFC5646], that best describes the language 
    /// used for text in the Card, optionally including additional information such 
    /// as the script. Note that values MAY be localized in the localizations 
    /// property.
    /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					Language  {get; set;} //

    /// <summary>
    /// The set of Cards that are members of this group Card. Each key in the set is 
    /// the uid property value of the member, and each boolean value MUST be "true".
    /// If this property is set, then the value of the kind property MUST be "group"
    /// </summary>

	[JsonPropertyName("members")]
	public virtual Dictionary<string,string>?					Members  {get; set;} //

    /// <summary>
    /// The name of the entity represented by the Card. This can be any type of name, 
    /// e.g., it can, but need not, be the legal name of a person.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual Name?					Name  {get; set;} //

    /// <summary>
    /// Alternative names.
    /// </summary>

	[JsonPropertyName("altNames")]
	public virtual Dictionary<string,Name>?					AltNames  {get; set;} //

    /// <summary>
    /// The nicknames of the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("nickNames")]
	public virtual Dictionary<string,NickName>?					NickNames  {get; set;} //

    /// <summary>
    /// The company or organization names and units associated with the Card.
    /// </summary>

	[JsonPropertyName("organizations")]
	public virtual Dictionary<string,Organization>?					Organizations  {get; set;} //

    /// <summary>
    /// The information that directs how to address, speak to, or refer to the
    /// entity that is represented by the Card.
    /// </summary>

	[JsonPropertyName("speakToAs")]
	public virtual SpeakToAs?					SpeakToAs  {get; set;} //

    /// <summary>
    /// The job titles or functional positions of the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("titles")]
	public virtual Dictionary<string,Title>?					Titles  {get; set;} //

    /// <summary>
    ///This relates the object to other objects. This is represented as 
    ///a map of the UIDs of the related objects to information about the relation.
    /// </summary>

	[JsonPropertyName("relatedTo")]
	public virtual Dictionary<string,Relation>?					RelatedTo  {get; set;} //

    /// <summary>
    /// The email addresses in which to contact the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("emails")]
	public virtual Dictionary<string,EmailAddress>?					Emails  {get; set;} //

    /// <summary>
    /// The online services that are associated with the entity represented by the Card.
    /// This can be messaging services, social media profiles, and other.
    /// </summary>

	[JsonPropertyName("onlineServices")]
	public virtual Dictionary<string,OnlineService>?					OnlineServices  {get; set;} //

    /// <summary>
    /// The phone numbers by which to contact the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("phones")]
	public virtual Dictionary<string,Phone>?					Phones  {get; set;} //

    /// <summary>
    /// The preferred languages for contacting the entity associated with the Card.
    /// </summary>

	[JsonPropertyName("preferredLanguages")]
	public virtual Dictionary<string,LanguagePref>?					PreferredLanguages  {get; set;} //

    /// <summary>
    /// The calendaring resources of the entity represented by the Card, such as 
    /// to look up free-busy information.
    /// </summary>

	[JsonPropertyName("calendars")]
	public virtual Dictionary<string,Calendar>?					Calendars  {get; set;} //

    /// <summary>
    /// The scheduling addresses by which the entity may receive calendar  
    /// scheduling invitations.
    /// </summary>

	[JsonPropertyName("schedulingAddresses")]
	public virtual Dictionary<string,SchedulingAddress>?					SchedulingAddresses  {get; set;} //

    /// <summary>
    /// The addresses of the entity represented by the Card, such as postal addresses 
    /// or geographic locations.
    /// </summary>

	[JsonPropertyName("addresses")]
	public virtual Dictionary<string,Address>?					Addresses  {get; set;} //

    /// <summary>
    /// The cryptographic resources such as public keys and certificates associated 
    /// with the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("cryptoKeys")]
	public virtual Dictionary<string,CryptoKey>?					CryptoKeys  {get; set;} //

    /// <summary>
    /// The directories containing information about the entity represented  
    /// by the Card.
    /// </summary>

	[JsonPropertyName("directories")]
	public virtual Dictionary<string,ContactDirectory>?					Directories  {get; set;} //

    /// <summary>
    /// The links to resources that do not fit any of the other  
    /// use-case-specific resource properties.
    /// </summary>

	[JsonPropertyName("links")]
	public virtual Dictionary<string,ResourceLink>?					Links  {get; set;} //

    /// <summary>
    /// The media resources such as photographs, avatars, or sounds that 
    ///  are associated 
    /// with the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("media")]
	public virtual Dictionary<string,Media>?					Media  {get; set;} //

    /// <summary>
    /// The property values localized to languages other than the main language 
    /// (Section 2.1.5) of the Card. Localizations provide language-specific alternatives 
    /// for existing property values and SHOULD NOT add new properties. The keys in 
    /// the localizations property value are language tags [RFC5646]; the values 
    /// are of type PatchObject and localize the Card in that language tag. The paths 
    /// in the PatchObject are relative to the Card that includes the localizations
    /// property. A patch MUST NOT target the localizations property.
    /// </summary>

	[JsonPropertyName("localizations")]
	public virtual Dictionary<string,JsContact>?					Localizations  {get; set;} //

    /// <summary>
    /// The memorable dates and events for the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("anniversaries")]
	public virtual Dictionary<string,Anniversary>?					Anniversaries  {get; set;} //

    /// <summary>
    /// The set of free-text keywords, also known as tags.
    /// </summary>

	[JsonPropertyName("keywords")]
	public virtual Dictionary<string,bool>?					Keywords  {get; set;} //

    /// <summary>
    /// The free-text notes that are associated with the Card.
    /// </summary>

	[JsonPropertyName("notes")]
	public virtual Dictionary<string,Note>?					Notes  {get; set;} //

    /// <summary>
    /// The personal information of the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("personalInfo")]
	public virtual Dictionary<string,PersonalInfo>?					PersonalInfo  {get; set;} //

    /// <summary>
    ///Specifies mechanisms for obtaining updates to the card.
    /// </summary>

	[JsonPropertyName("updates")]
	public virtual Dictionary<string,Update>?					Updates  {get; set;} //

    /// <summary>
    ///Specifies groups of related email addresses and online services.
    /// </summary>

	[JsonPropertyName("serviceGroups")]
	public virtual Dictionary<string,ServiceGroup>?					ServiceGroups  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("version", 
					(IBinding data, string? value) => {(data as JsContact).Version = value;}, 
					(IBinding data) => (data as JsContact).Version ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as JsContact).Kind = value;}, 
					(IBinding data) => (data as JsContact).Kind ),
		new PropertyString ("language", 
					(IBinding data, string? value) => {(data as JsContact).Language = value;}, 
					(IBinding data) => (data as JsContact).Language ),
		new PropertyDictionaryString ("members", 
					(IBinding data, Dictionary<string,string>? value) => {(data as JsContact).Members = value;}, 
					(IBinding data) => (data as JsContact).Members ),
		new PropertyStruct ("name", typeof (Name),
					(IBinding data, object? value) => {(data as JsContact).Name = value as Name;}, 
					(IBinding data) => (data as JsContact).Name,
					false, ()=>new  Name(), ()=>new Name()),
		new PropertyDictionaryStruct ("altNames", typeof (Name),
					(IBinding data, object? value) => {(data as JsContact).AltNames = value as Dictionary<string,Name>;}, 
					(IBinding data) => (data as JsContact).AltNames,
					false, ()=>new  Dictionary<string,Name>(), ()=>new Name(),
					(IBinding data) => (data as JsContact).AltNames.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Name>).Add (key as string,value as Name);}),
		new PropertyDictionaryStruct ("nickNames", typeof (NickName),
					(IBinding data, object? value) => {(data as JsContact).NickNames = value as Dictionary<string,NickName>;}, 
					(IBinding data) => (data as JsContact).NickNames,
					false, ()=>new  Dictionary<string,NickName>(), ()=>new NickName(),
					(IBinding data) => (data as JsContact).NickNames.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,NickName>).Add (key as string,value as NickName);}),
		new PropertyDictionaryStruct ("organizations", typeof (Organization),
					(IBinding data, object? value) => {(data as JsContact).Organizations = value as Dictionary<string,Organization>;}, 
					(IBinding data) => (data as JsContact).Organizations,
					false, ()=>new  Dictionary<string,Organization>(), ()=>new Organization(),
					(IBinding data) => (data as JsContact).Organizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Organization>).Add (key as string,value as Organization);}),
		new PropertyStruct ("speakToAs", typeof (SpeakToAs),
					(IBinding data, object? value) => {(data as JsContact).SpeakToAs = value as SpeakToAs;}, 
					(IBinding data) => (data as JsContact).SpeakToAs,
					false, ()=>new  SpeakToAs(), ()=>new SpeakToAs()),
		new PropertyDictionaryStruct ("titles", typeof (Title),
					(IBinding data, object? value) => {(data as JsContact).Titles = value as Dictionary<string,Title>;}, 
					(IBinding data) => (data as JsContact).Titles,
					false, ()=>new  Dictionary<string,Title>(), ()=>new Title(),
					(IBinding data) => (data as JsContact).Titles.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Title>).Add (key as string,value as Title);}),
		new PropertyDictionaryStruct ("relatedTo", typeof (Relation),
					(IBinding data, object? value) => {(data as JsContact).RelatedTo = value as Dictionary<string,Relation>;}, 
					(IBinding data) => (data as JsContact).RelatedTo,
					false, ()=>new  Dictionary<string,Relation>(), ()=>new Relation(),
					(IBinding data) => (data as JsContact).RelatedTo.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Relation>).Add (key as string,value as Relation);}),
		new PropertyDictionaryStruct ("emails", typeof (EmailAddress),
					(IBinding data, object? value) => {(data as JsContact).Emails = value as Dictionary<string,EmailAddress>;}, 
					(IBinding data) => (data as JsContact).Emails,
					false, ()=>new  Dictionary<string,EmailAddress>(), ()=>new EmailAddress(),
					(IBinding data) => (data as JsContact).Emails.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,EmailAddress>).Add (key as string,value as EmailAddress);}),
		new PropertyDictionaryStruct ("onlineServices", typeof (OnlineService),
					(IBinding data, object? value) => {(data as JsContact).OnlineServices = value as Dictionary<string,OnlineService>;}, 
					(IBinding data) => (data as JsContact).OnlineServices,
					false, ()=>new  Dictionary<string,OnlineService>(), ()=>new OnlineService(),
					(IBinding data) => (data as JsContact).OnlineServices.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,OnlineService>).Add (key as string,value as OnlineService);}),
		new PropertyDictionaryStruct ("phones", typeof (Phone),
					(IBinding data, object? value) => {(data as JsContact).Phones = value as Dictionary<string,Phone>;}, 
					(IBinding data) => (data as JsContact).Phones,
					false, ()=>new  Dictionary<string,Phone>(), ()=>new Phone(),
					(IBinding data) => (data as JsContact).Phones.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Phone>).Add (key as string,value as Phone);}),
		new PropertyDictionaryStruct ("preferredLanguages", typeof (LanguagePref),
					(IBinding data, object? value) => {(data as JsContact).PreferredLanguages = value as Dictionary<string,LanguagePref>;}, 
					(IBinding data) => (data as JsContact).PreferredLanguages,
					false, ()=>new  Dictionary<string,LanguagePref>(), ()=>new LanguagePref(),
					(IBinding data) => (data as JsContact).PreferredLanguages.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,LanguagePref>).Add (key as string,value as LanguagePref);}),
		new PropertyDictionaryStruct ("calendars", typeof (Calendar),
					(IBinding data, object? value) => {(data as JsContact).Calendars = value as Dictionary<string,Calendar>;}, 
					(IBinding data) => (data as JsContact).Calendars,
					false, ()=>new  Dictionary<string,Calendar>(), ()=>new Calendar(),
					(IBinding data) => (data as JsContact).Calendars.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Calendar>).Add (key as string,value as Calendar);}),
		new PropertyDictionaryStruct ("schedulingAddresses", typeof (SchedulingAddress),
					(IBinding data, object? value) => {(data as JsContact).SchedulingAddresses = value as Dictionary<string,SchedulingAddress>;}, 
					(IBinding data) => (data as JsContact).SchedulingAddresses,
					false, ()=>new  Dictionary<string,SchedulingAddress>(), ()=>new SchedulingAddress(),
					(IBinding data) => (data as JsContact).SchedulingAddresses.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,SchedulingAddress>).Add (key as string,value as SchedulingAddress);}),
		new PropertyDictionaryStruct ("addresses", typeof (Address),
					(IBinding data, object? value) => {(data as JsContact).Addresses = value as Dictionary<string,Address>;}, 
					(IBinding data) => (data as JsContact).Addresses,
					false, ()=>new  Dictionary<string,Address>(), ()=>new Address(),
					(IBinding data) => (data as JsContact).Addresses.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Address>).Add (key as string,value as Address);}),
		new PropertyDictionaryStruct ("cryptoKeys", typeof (CryptoKey),
					(IBinding data, object? value) => {(data as JsContact).CryptoKeys = value as Dictionary<string,CryptoKey>;}, 
					(IBinding data) => (data as JsContact).CryptoKeys,
					false, ()=>new  Dictionary<string,CryptoKey>(), ()=>new CryptoKey(),
					(IBinding data) => (data as JsContact).CryptoKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,CryptoKey>).Add (key as string,value as CryptoKey);}),
		new PropertyDictionaryStruct ("directories", typeof (ContactDirectory),
					(IBinding data, object? value) => {(data as JsContact).Directories = value as Dictionary<string,ContactDirectory>;}, 
					(IBinding data) => (data as JsContact).Directories,
					false, ()=>new  Dictionary<string,ContactDirectory>(), ()=>new ContactDirectory(),
					(IBinding data) => (data as JsContact).Directories.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,ContactDirectory>).Add (key as string,value as ContactDirectory);}),
		new PropertyDictionaryStruct ("links", typeof (ResourceLink),
					(IBinding data, object? value) => {(data as JsContact).Links = value as Dictionary<string,ResourceLink>;}, 
					(IBinding data) => (data as JsContact).Links,
					false, ()=>new  Dictionary<string,ResourceLink>(), ()=>new ResourceLink(),
					(IBinding data) => (data as JsContact).Links.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,ResourceLink>).Add (key as string,value as ResourceLink);}),
		new PropertyDictionaryStruct ("media", typeof (Media),
					(IBinding data, object? value) => {(data as JsContact).Media = value as Dictionary<string,Media>;}, 
					(IBinding data) => (data as JsContact).Media,
					false, ()=>new  Dictionary<string,Media>(), ()=>new Media(),
					(IBinding data) => (data as JsContact).Media.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Media>).Add (key as string,value as Media);}),
		new PropertyDictionaryStruct ("localizations", typeof (JsContact),
					(IBinding data, object? value) => {(data as JsContact).Localizations = value as Dictionary<string,JsContact>;}, 
					(IBinding data) => (data as JsContact).Localizations,
					false, ()=>new  Dictionary<string,JsContact>(), ()=>new JsContact(),
					(IBinding data) => (data as JsContact).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsContact>).Add (key as string,value as JsContact);}),
		new PropertyDictionaryStruct ("anniversaries", typeof (Anniversary),
					(IBinding data, object? value) => {(data as JsContact).Anniversaries = value as Dictionary<string,Anniversary>;}, 
					(IBinding data) => (data as JsContact).Anniversaries,
					false, ()=>new  Dictionary<string,Anniversary>(), ()=>new Anniversary(),
					(IBinding data) => (data as JsContact).Anniversaries.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Anniversary>).Add (key as string,value as Anniversary);}),
		new PropertyDictionaryBoolean ("keywords", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as JsContact).Keywords = value;}, 
					(IBinding data) => (data as JsContact).Keywords ),
		new PropertyDictionaryStruct ("notes", typeof (Note),
					(IBinding data, object? value) => {(data as JsContact).Notes = value as Dictionary<string,Note>;}, 
					(IBinding data) => (data as JsContact).Notes,
					false, ()=>new  Dictionary<string,Note>(), ()=>new Note(),
					(IBinding data) => (data as JsContact).Notes.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Note>).Add (key as string,value as Note);}),
		new PropertyDictionaryStruct ("personalInfo", typeof (PersonalInfo),
					(IBinding data, object? value) => {(data as JsContact).PersonalInfo = value as Dictionary<string,PersonalInfo>;}, 
					(IBinding data) => (data as JsContact).PersonalInfo,
					false, ()=>new  Dictionary<string,PersonalInfo>(), ()=>new PersonalInfo(),
					(IBinding data) => (data as JsContact).PersonalInfo.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,PersonalInfo>).Add (key as string,value as PersonalInfo);}),
		new PropertyDictionaryStruct ("updates", typeof (Update),
					(IBinding data, object? value) => {(data as JsContact).Updates = value as Dictionary<string,Update>;}, 
					(IBinding data) => (data as JsContact).Updates,
					false, ()=>new  Dictionary<string,Update>(), ()=>new Update(),
					(IBinding data) => (data as JsContact).Updates.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Update>).Add (key as string,value as Update);}),
		new PropertyDictionaryStruct ("serviceGroups", typeof (ServiceGroup),
					(IBinding data, object? value) => {(data as JsContact).ServiceGroups = value as Dictionary<string,ServiceGroup>;}, 
					(IBinding data) => (data as JsContact).ServiceGroups,
					false, ()=>new  Dictionary<string,ServiceGroup>(), ()=>new ServiceGroup(),
					(IBinding data) => (data as JsContact).ServiceGroups.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,ServiceGroup>).Add (key as string,value as ServiceGroup);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsContact> _binding = new (
			new() {
			{ "version", _properties [0]},
			{ "kind", _properties [1]},
			{ "language", _properties [2]},
			{ "members", _properties [3]},
			{ "name", _properties [4]},
			{ "altNames", _properties [5]},
			{ "nickNames", _properties [6]},
			{ "organizations", _properties [7]},
			{ "speakToAs", _properties [8]},
			{ "titles", _properties [9]},
			{ "relatedTo", _properties [10]},
			{ "emails", _properties [11]},
			{ "onlineServices", _properties [12]},
			{ "phones", _properties [13]},
			{ "preferredLanguages", _properties [14]},
			{ "calendars", _properties [15]},
			{ "schedulingAddresses", _properties [16]},
			{ "addresses", _properties [17]},
			{ "cryptoKeys", _properties [18]},
			{ "directories", _properties [19]},
			{ "links", _properties [20]},
			{ "media", _properties [21]},
			{ "localizations", _properties [22]},
			{ "anniversaries", _properties [23]},
			{ "keywords", _properties [24]},
			{ "notes", _properties [25]},
			{ "personalInfo", _properties [26]},
			{ "updates", _properties [27]},
			{ "serviceGroups", _properties [28]}}, __Tag,
		() => new JsContact(), () => [], () => [], JmapBase._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Resource : Contacts {
    /// <summary>
    /// The JSContact type of the object. The value MUST NOT be "Resource"; 
    /// instead, the value MUST be the name of a concrete resource type
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The kind of the resource. The allowed values are defined in the 
    /// property definition that makes use of the Resource type. Some 
    /// property definitions may change this property from being optional to mandatory.
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// 
    /// </summary>

	[JsonPropertyName("uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// The media type [RFC2046] of the resource identified by the uri property value.
    /// </summary>

	[JsonPropertyName("mediaType")]
	public virtual string?					MediaType  {get; set;} //

    /// <summary>
    /// The contexts in which to use this resource. 
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the resource in relation to other resources.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// A custom label for the value. 
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Resource).Type = value;}, 
					(IBinding data) => (data as Resource).Type ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Resource).Kind = value;}, 
					(IBinding data) => (data as Resource).Kind ),
		new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as Resource).Uri = value;}, 
					(IBinding data) => (data as Resource).Uri ),
		new PropertyString ("mediaType", 
					(IBinding data, string? value) => {(data as Resource).MediaType = value;}, 
					(IBinding data) => (data as Resource).MediaType ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Resource).Contexts = value;}, 
					(IBinding data) => (data as Resource).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Resource).Pref = value;}, 
					(IBinding data) => (data as Resource).Pref ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as Resource).Label = value;}, 
					(IBinding data) => (data as Resource).Label )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Resource> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "kind", _properties [1]},
			{ "uri", _properties [2]},
			{ "mediaType", _properties [3]},
			{ "contexts", _properties [4]},
			{ "pref", _properties [5]},
			{ "label", _properties [6]}}, __Tag,
		() => new Resource(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	/// A Name object
	/// </summary>
public partial class Name : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The components (Section 2.2.1.2) making up this name. The components property 
    /// MUST be set if the full property is not set; otherwise, it SHOULD be set. 
    /// The component list MUST have at least one entry having a different kind 
    /// property value than "separator".
    /// </summary>

	[JsonPropertyName("components")]
	public virtual List<NameComponent>?					Components  {get; set;}
    /// <summary>
    /// The indicator if the name components in the components property are ordered.
    /// </summary>

	[JsonPropertyName("isOrdered")]
	public virtual bool?					IsOrdered  {get; set;} //

    /// <summary>
    /// The default separator to insert between name component values when 
    /// concatenating all name component values to a single String. Also see 
    /// the definition of the kind property value "separator" for the 
    /// NameComponent (Section 2.2.1.2) object. The defaultSeparator property 
    /// MUST NOT be set if the Name isOrdered property value is "false" or 
    /// if the components property is not set.
    /// </summary>

	[JsonPropertyName("defaultSeparator")]
	public virtual string?					DefaultSeparator  {get; set;} //

    /// <summary>
    /// The full name representation of the Name. The full property MUST be set 
    /// if the components property is not set.
    /// </summary>

	[JsonPropertyName("full")]
	public virtual string?					Full  {get; set;} //

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

	[JsonPropertyName("sortAs")]
	public virtual string?					SortAs  {get; set;} //

    /// <summary>
    /// The script used in the value of the NameComponent phonetic property.
    /// </summary>

	[JsonPropertyName("phoneticScript")]
	public virtual string?					PhoneticScript  {get; set;} //

    /// <summary>
    /// The phonetic system used in the NameComponent phonetic property.
    /// </summary>

	[JsonPropertyName("phoneticSystem")]
	public virtual string?					PhoneticSystem  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Name).Type = value;}, 
					(IBinding data) => (data as Name).Type ),
		new PropertyListStruct ("components", typeof (NameComponent),
					(IBinding data, object? value) => {(data as Name).Components = value as List<NameComponent>;}, 
					(IBinding data) => (data as Name).Components,
					false, ()=>new  List<NameComponent>(), ()=>new NameComponent()),
		new PropertyBoolean ("isOrdered", 
					(IBinding data, bool? value) => {(data as Name).IsOrdered = value;}, 
					(IBinding data) => (data as Name).IsOrdered ),
		new PropertyString ("defaultSeparator", 
					(IBinding data, string? value) => {(data as Name).DefaultSeparator = value;}, 
					(IBinding data) => (data as Name).DefaultSeparator ),
		new PropertyString ("full", 
					(IBinding data, string? value) => {(data as Name).Full = value;}, 
					(IBinding data) => (data as Name).Full ),
		new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as Name).SortAs = value;}, 
					(IBinding data) => (data as Name).SortAs ),
		new PropertyString ("phoneticScript", 
					(IBinding data, string? value) => {(data as Name).PhoneticScript = value;}, 
					(IBinding data) => (data as Name).PhoneticScript ),
		new PropertyString ("phoneticSystem", 
					(IBinding data, string? value) => {(data as Name).PhoneticSystem = value;}, 
					(IBinding data) => (data as Name).PhoneticSystem )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Name> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "components", _properties [1]},
			{ "isOrdered", _properties [2]},
			{ "defaultSeparator", _properties [3]},
			{ "full", _properties [4]},
			{ "sortAs", _properties [5]},
			{ "phoneticScript", _properties [6]},
			{ "phoneticSystem", _properties [7]}}, __Tag,
		() => new Name(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	/// A NameComponent object
	/// </summary>
public partial class NameComponent : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// 
    /// </summary>

	[JsonPropertyName("value")]
	public virtual string?					Value  {get; set;} //

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

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("phonetic")]
	public virtual string?					Phonetic  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as NameComponent).Type = value;}, 
					(IBinding data) => (data as NameComponent).Type ),
		new PropertyString ("value", 
					(IBinding data, string? value) => {(data as NameComponent).Value = value;}, 
					(IBinding data) => (data as NameComponent).Value ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as NameComponent).Kind = value;}, 
					(IBinding data) => (data as NameComponent).Kind ),
		new PropertyString ("phonetic", 
					(IBinding data, string? value) => {(data as NameComponent).Phonetic = value;}, 
					(IBinding data) => (data as NameComponent).Phonetic )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NameComponent> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "value", _properties [1]},
			{ "kind", _properties [2]},
			{ "phonetic", _properties [3]}}, __Tag,
		() => new NameComponent(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class NickName : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The nickname.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// The contexts in which to use the nickname.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the nickname in relation to other nicknames. 
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as NickName).Type = value;}, 
					(IBinding data) => (data as NickName).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as NickName).Name = value;}, 
					(IBinding data) => (data as NickName).Name ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as NickName).Contexts = value;}, 
					(IBinding data) => (data as NickName).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as NickName).Pref = value;}, 
					(IBinding data) => (data as NickName).Pref )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NickName> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "contexts", _properties [2]},
			{ "pref", _properties [3]}}, __Tag,
		() => new NickName(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Organization : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The name of the organization.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// A list of organizational units, ordered as descending by hierarchy 
    /// (e.g., a geographic or functional division sorts before a department 
    /// within that division). If set, the list MUST contain at least one entry.
    /// </summary>

	[JsonPropertyName("units")]
	public virtual List<OrgUnit>?					Units  {get; set;}
    /// <summary>
    /// The value to lexicographically sort the organization in relation to 
    /// other organizations when compared by name. The value defines the 
    /// verbatim string value to compare. In absence of this property, 
    /// the name property value MAY be used for comparison.
    /// </summary>

	[JsonPropertyName("sortAs")]
	public virtual string?					SortAs  {get; set;} //

    /// <summary>
    /// The contexts in which association with the organization applies. For 
    /// example, membership in a choir may only apply in a private context.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Organization).Type = value;}, 
					(IBinding data) => (data as Organization).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Organization).Name = value;}, 
					(IBinding data) => (data as Organization).Name ),
		new PropertyListStruct ("units", typeof (OrgUnit),
					(IBinding data, object? value) => {(data as Organization).Units = value as List<OrgUnit>;}, 
					(IBinding data) => (data as Organization).Units,
					false, ()=>new  List<OrgUnit>(), ()=>new OrgUnit()),
		new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as Organization).SortAs = value;}, 
					(IBinding data) => (data as Organization).SortAs ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Organization).Contexts = value;}, 
					(IBinding data) => (data as Organization).Contexts )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Organization> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "units", _properties [2]},
			{ "sortAs", _properties [3]},
			{ "contexts", _properties [4]}}, __Tag,
		() => new Organization(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class OrgUnit : Contacts {
    /// <summary>
    /// The name of the organizational unit.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// The value to lexicographically sort the organizational unit in relation 
    /// to other organizational units of the same level when compared by name. 
    /// The level is defined by the array index of the organizational unit in 
    /// the units property of the Organization object. The property value 
    /// defines the verbatim string value to compare. In absence of this 
    /// property, the name property value MAY be used for comparison.
    /// </summary>

	[JsonPropertyName("sortAs")]
	public virtual string?					SortAs  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as OrgUnit).Name = value;}, 
					(IBinding data) => (data as OrgUnit).Name ),
		new PropertyString ("sortAs", 
					(IBinding data, string? value) => {(data as OrgUnit).SortAs = value;}, 
					(IBinding data) => (data as OrgUnit).SortAs )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OrgUnit> _binding = new (
			new() {
			{ "name", _properties [0]},
			{ "sortAs", _properties [1]}}, __Tag,
		() => new OrgUnit(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class SpeakToAs : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The grammatical gender to use in salutations and other grammatical 
    /// constructs. For example, the German language distinguishes by grammatical
    /// gender in salutations such as "Sehr geehrte" (feminine) and "Sehr geehrter"
    /// (masculine)
    /// </summary>

	[JsonPropertyName("grammaticalGender")]
	public virtual string?					GrammaticalGender  {get; set;} //

    /// <summary>
    /// The pronouns that the contact chooses to use for themselves.
    /// </summary>

	[JsonPropertyName("pronouns")]
	public virtual Dictionary<string,Pronouns>?					Pronouns  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as SpeakToAs).Type = value;}, 
					(IBinding data) => (data as SpeakToAs).Type ),
		new PropertyString ("grammaticalGender", 
					(IBinding data, string? value) => {(data as SpeakToAs).GrammaticalGender = value;}, 
					(IBinding data) => (data as SpeakToAs).GrammaticalGender ),
		new PropertyDictionaryStruct ("pronouns", typeof (Pronouns),
					(IBinding data, object? value) => {(data as SpeakToAs).Pronouns = value as Dictionary<string,Pronouns>;}, 
					(IBinding data) => (data as SpeakToAs).Pronouns,
					false, ()=>new  Dictionary<string,Pronouns>(), ()=>new Pronouns(),
					(IBinding data) => (data as SpeakToAs).Pronouns.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Pronouns>).Add (key as string,value as Pronouns);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SpeakToAs> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "grammaticalGender", _properties [1]},
			{ "pronouns", _properties [2]}}, __Tag,
		() => new SpeakToAs(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Pronouns : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The pronouns. Any value or form is allowed. Examples in English include "she/her"
    /// and "they/them/theirs". The value MAY be overridden in the localizations 
    /// property.
    /// </summary>

	[JsonPropertyName("pronouns")]
	public virtual string?					Values  {get; set;} //

    /// <summary>
    /// The contexts in which to use the pronouns.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the pronouns in relation to other pronouns in the same context.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Pronouns).Type = value;}, 
					(IBinding data) => (data as Pronouns).Type ),
		new PropertyString ("pronouns", 
					(IBinding data, string? value) => {(data as Pronouns).Values = value;}, 
					(IBinding data) => (data as Pronouns).Values ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Pronouns).Contexts = value;}, 
					(IBinding data) => (data as Pronouns).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Pronouns).Pref = value;}, 
					(IBinding data) => (data as Pronouns).Pref )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Pronouns> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "pronouns", _properties [1]},
			{ "contexts", _properties [2]},
			{ "pref", _properties [3]}}, __Tag,
		() => new Pronouns(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Title : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The title or role name of the entity represented by the Card.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// The organizational or situational kind of the title. Some organizations and 
    /// individuals distinguish between titles as organizational positions and roles
    /// as more temporary assignments such as in project management.
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// 
    /// </summary>

	[JsonPropertyName("organizationId")]
	public virtual string?					OrganizationId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Title).Type = value;}, 
					(IBinding data) => (data as Title).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Title).Name = value;}, 
					(IBinding data) => (data as Title).Name ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Title).Kind = value;}, 
					(IBinding data) => (data as Title).Kind ),
		new PropertyString ("organizationId", 
					(IBinding data, string? value) => {(data as Title).OrganizationId = value;}, 
					(IBinding data) => (data as Title).OrganizationId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Title> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "kind", _properties [2]},
			{ "organizationId", _properties [3]}}, __Tag,
		() => new Title(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class EmailAddress : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The email address. This MUST be an addr-spec value as defined in Section 3.4.1 of [RFC5322].
    /// </summary>

	[JsonPropertyName("address")]
	public virtual string?					Address  {get; set;} //

    /// <summary>
    /// The contexts in which to use this email address. Also see Section 1.5.1.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the email address in relation to other email addresses. Also 
    /// see Section 1.5.3.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// A custom label for the value. 
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //

    /// <summary>
    /// The identifiers of the set of cryptographic keys to be used to 
    /// authenticate the updated contact information and their use.
    /// </summary>

	[JsonPropertyName("cryptoKeyIds")]
	public virtual Dictionary<string,string>?					CryptoKeyIds  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as EmailAddress).Type = value;}, 
					(IBinding data) => (data as EmailAddress).Type ),
		new PropertyString ("address", 
					(IBinding data, string? value) => {(data as EmailAddress).Address = value;}, 
					(IBinding data) => (data as EmailAddress).Address ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as EmailAddress).Contexts = value;}, 
					(IBinding data) => (data as EmailAddress).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as EmailAddress).Pref = value;}, 
					(IBinding data) => (data as EmailAddress).Pref ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as EmailAddress).Label = value;}, 
					(IBinding data) => (data as EmailAddress).Label ),
		new PropertyDictionaryString ("cryptoKeyIds", 
					(IBinding data, Dictionary<string,string>? value) => {(data as EmailAddress).CryptoKeyIds = value;}, 
					(IBinding data) => (data as EmailAddress).CryptoKeyIds )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EmailAddress> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "address", _properties [1]},
			{ "contexts", _properties [2]},
			{ "pref", _properties [3]},
			{ "label", _properties [4]},
			{ "cryptoKeyIds", _properties [5]}}, __Tag,
		() => new EmailAddress(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class OnlineService : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The name of the online service or protocol. The name MAY be capitalized the 
    /// same as on the service's website, app, or publishing material, but names MUST 
    /// be considered equal if they match case-insensitively. Examples are "GitHub", 
    /// "kakao", and "Mastodon"
    /// </summary>

	[JsonPropertyName("service")]
	public virtual string?					Service  {get; set;} //

    /// <summary>
    /// The identifier for the entity represented by the Card at the online service. 
    /// This MUST be a URI as defined in Section 3 of [RFC3986].
    /// </summary>

	[JsonPropertyName("uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// The name the entity represented by the Card at the online service. Any 
    /// free-text value is allowed. The service property SHOULD be set.
    /// </summary>

	[JsonPropertyName("user")]
	public virtual string?					User  {get; set;} //

    /// <summary>
    /// The contexts in which to use the service.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the service in relation to other services.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// A custom label for the value. 
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //

    /// <summary>
    /// The identifiers of the set of cryptographic keys to be used to 
    /// authenticate the updated contact information and their use.
    /// </summary>

	[JsonPropertyName("cryptoKeyIds")]
	public virtual Dictionary<string,string>?					CryptoKeyIds  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as OnlineService).Type = value;}, 
					(IBinding data) => (data as OnlineService).Type ),
		new PropertyString ("service", 
					(IBinding data, string? value) => {(data as OnlineService).Service = value;}, 
					(IBinding data) => (data as OnlineService).Service ),
		new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as OnlineService).Uri = value;}, 
					(IBinding data) => (data as OnlineService).Uri ),
		new PropertyString ("user", 
					(IBinding data, string? value) => {(data as OnlineService).User = value;}, 
					(IBinding data) => (data as OnlineService).User ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as OnlineService).Contexts = value;}, 
					(IBinding data) => (data as OnlineService).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as OnlineService).Pref = value;}, 
					(IBinding data) => (data as OnlineService).Pref ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as OnlineService).Label = value;}, 
					(IBinding data) => (data as OnlineService).Label ),
		new PropertyDictionaryString ("cryptoKeyIds", 
					(IBinding data, Dictionary<string,string>? value) => {(data as OnlineService).CryptoKeyIds = value;}, 
					(IBinding data) => (data as OnlineService).CryptoKeyIds )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OnlineService> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "service", _properties [1]},
			{ "uri", _properties [2]},
			{ "user", _properties [3]},
			{ "contexts", _properties [4]},
			{ "pref", _properties [5]},
			{ "label", _properties [6]},
			{ "cryptoKeyIds", _properties [7]}}, __Tag,
		() => new OnlineService(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Phone : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The phone number as either a URI or free text. Typical URI schemes are 
    /// "tel" [RFC3966] or "sip" [RFC3261], but any URI scheme is allowed.
    /// </summary>

	[JsonPropertyName("number")]
	public virtual string?					Number  {get; set;} //

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

	[JsonPropertyName("features")]
	public virtual Dictionary<string,bool>?					Features  {get; set;} //

    /// <summary>
    /// The contexts in which to use the number. 
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the number in relation to other numbers.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// A custom label for the value.
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Phone).Type = value;}, 
					(IBinding data) => (data as Phone).Type ),
		new PropertyString ("number", 
					(IBinding data, string? value) => {(data as Phone).Number = value;}, 
					(IBinding data) => (data as Phone).Number ),
		new PropertyDictionaryBoolean ("features", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Phone).Features = value;}, 
					(IBinding data) => (data as Phone).Features ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Phone).Contexts = value;}, 
					(IBinding data) => (data as Phone).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Phone).Pref = value;}, 
					(IBinding data) => (data as Phone).Pref ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as Phone).Label = value;}, 
					(IBinding data) => (data as Phone).Label )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Phone> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "number", _properties [1]},
			{ "features", _properties [2]},
			{ "contexts", _properties [3]},
			{ "pref", _properties [4]},
			{ "label", _properties [5]}}, __Tag,
		() => new Phone(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class LanguagePref : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The preferred language. This MUST be a language tag as defined in [RFC5646] .
    /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					Language  {get; set;} //

    /// <summary>
    /// The contexts in which to use the language.
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The preference of the language in relation to other languages of the same contexts. 
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as LanguagePref).Type = value;}, 
					(IBinding data) => (data as LanguagePref).Type ),
		new PropertyString ("language", 
					(IBinding data, string? value) => {(data as LanguagePref).Language = value;}, 
					(IBinding data) => (data as LanguagePref).Language ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as LanguagePref).Contexts = value;}, 
					(IBinding data) => (data as LanguagePref).Contexts ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as LanguagePref).Pref = value;}, 
					(IBinding data) => (data as LanguagePref).Pref )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<LanguagePref> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "language", _properties [1]},
			{ "contexts", _properties [2]},
			{ "pref", _properties [3]}}, __Tag,
		() => new LanguagePref(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The calendaring resources of the entity represented by the Card, such as 
	///  to look up free-busy information.
	/// </summary>
public partial class Calendar : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Calendar> _binding = new (
			new() {}, __Tag,
		() => new Calendar(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The scheduling addresses by which the entity may receive calendar scheduling invitations.
	/// </summary>
public partial class SchedulingAddress : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The address to use for calendar scheduling with the contact. This MUST 
    /// be a URI as defined in Section 3 of [RFC3986].
    /// </summary>

	[JsonPropertyName("uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// The contexts in which to use the scheduling address. 
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual List<Boolean>?					Contexts  {get; set;}
    /// <summary>
    /// The preference of the scheduling address in relation to other scheduling addresses.
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// A custom label for the scheduling address. 
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Type = value;}, 
					(IBinding data) => (data as SchedulingAddress).Type ),
		new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Uri = value;}, 
					(IBinding data) => (data as SchedulingAddress).Uri ),
		new PropertyListStruct ("contexts", typeof (Boolean),
					(IBinding data, object? value) => {(data as SchedulingAddress).Contexts = value as List<Boolean>;}, 
					(IBinding data) => (data as SchedulingAddress).Contexts,
					false, ()=>new  List<Boolean>(), ()=>new Boolean()),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as SchedulingAddress).Pref = value;}, 
					(IBinding data) => (data as SchedulingAddress).Pref ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as SchedulingAddress).Label = value;}, 
					(IBinding data) => (data as SchedulingAddress).Label )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SchedulingAddress> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "uri", _properties [1]},
			{ "contexts", _properties [2]},
			{ "pref", _properties [3]},
			{ "label", _properties [4]}}, __Tag,
		() => new SchedulingAddress(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The addresses of the entity represented by the Card, such as postal 
	///  addresses or geographic locations.
	/// </summary>
public partial class Address : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The components (Section 2.5.1.2) that make up the address. The component 
    /// list MUST have at least one entry that has a kind property value other 
    /// than "separator".
    /// </summary>

	[JsonPropertyName("components")]
	public virtual List<AddressComponent>?					Components  {get; set;}
    /// <summary>
    /// The indicator if the address components in the components property are ordered.
    /// </summary>

	[JsonPropertyName("isOrdered")]
	public virtual string?					IsOrdered  {get; set;} //

    /// <summary>
    /// The Alpha-2 country code [ISO.3166-1].
    /// </summary>

	[JsonPropertyName("countryCode")]
	public virtual string?					CountryCode  {get; set;} //

    /// <summary>
    /// A "geo:" URI [RFC5870] for the address.
    /// </summary>

	[JsonPropertyName("coordinates")]
	public virtual string?					Coordinates  {get; set;} //

    /// <summary>
    /// The time zone in which the address is located. This MUST be a time zone 
    /// name registered in the IANA Time Zone Database [IANA-TZ].
    /// </summary>

	[JsonPropertyName("timeZone")]
	public virtual string?					TimeZone  {get; set;} //

    /// <summary>
    /// The contexts in which to use this address. 
    /// </summary>

	[JsonPropertyName("contexts")]
	public virtual Dictionary<string,bool>?					Contexts  {get; set;} //

    /// <summary>
    /// The full address, including street, region, or country. The purpose of 
    /// this property is to define an address, even if the individual address 
    /// components are not known.
    /// </summary>

	[JsonPropertyName("full")]
	public virtual string?					Full  {get; set;} //

    /// <summary>
    /// The default separator to insert between address component values when 
    /// concatenating all address component values to a single String. Also see 
    /// the definition of the kind property value "separator" for the AddressComponent
    /// (Section 2.5.1.2) object. The defaultSeparator property MUST NOT be set 
    /// if the Address isOrdered property value is "false" or if the components 
    /// property is not set.
    /// </summary>

	[JsonPropertyName("defaultSeparator")]
	public virtual string?					DefaultSeparator  {get; set;} //

    /// <summary>
    /// The preference of the address in relation to other addresses. 
    /// </summary>

	[JsonPropertyName("pref")]
	public virtual int?					Pref  {get; set;} //

    /// <summary>
    /// The script used in the value of the AddressComponent phonetic property.
    /// </summary>

	[JsonPropertyName("phoneticScript")]
	public virtual string?					PhoneticScript  {get; set;} //

    /// <summary>
    /// The phonetic system used in the AddressComponent phonetic property.
    /// </summary>

	[JsonPropertyName("phoneticSystem")]
	public virtual string?					PhoneticSystem  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Address).Type = value;}, 
					(IBinding data) => (data as Address).Type ),
		new PropertyListStruct ("components", typeof (AddressComponent),
					(IBinding data, object? value) => {(data as Address).Components = value as List<AddressComponent>;}, 
					(IBinding data) => (data as Address).Components,
					false, ()=>new  List<AddressComponent>(), ()=>new AddressComponent()),
		new PropertyString ("isOrdered", 
					(IBinding data, string? value) => {(data as Address).IsOrdered = value;}, 
					(IBinding data) => (data as Address).IsOrdered ),
		new PropertyString ("countryCode", 
					(IBinding data, string? value) => {(data as Address).CountryCode = value;}, 
					(IBinding data) => (data as Address).CountryCode ),
		new PropertyString ("coordinates", 
					(IBinding data, string? value) => {(data as Address).Coordinates = value;}, 
					(IBinding data) => (data as Address).Coordinates ),
		new PropertyString ("timeZone", 
					(IBinding data, string? value) => {(data as Address).TimeZone = value;}, 
					(IBinding data) => (data as Address).TimeZone ),
		new PropertyDictionaryBoolean ("contexts", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Address).Contexts = value;}, 
					(IBinding data) => (data as Address).Contexts ),
		new PropertyString ("full", 
					(IBinding data, string? value) => {(data as Address).Full = value;}, 
					(IBinding data) => (data as Address).Full ),
		new PropertyString ("defaultSeparator", 
					(IBinding data, string? value) => {(data as Address).DefaultSeparator = value;}, 
					(IBinding data) => (data as Address).DefaultSeparator ),
		new PropertyInteger32 ("pref", 
					(IBinding data, int? value) => {(data as Address).Pref = value;}, 
					(IBinding data) => (data as Address).Pref ),
		new PropertyString ("phoneticScript", 
					(IBinding data, string? value) => {(data as Address).PhoneticScript = value;}, 
					(IBinding data) => (data as Address).PhoneticScript ),
		new PropertyString ("phoneticSystem", 
					(IBinding data, string? value) => {(data as Address).PhoneticSystem = value;}, 
					(IBinding data) => (data as Address).PhoneticSystem )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Address> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "components", _properties [1]},
			{ "isOrdered", _properties [2]},
			{ "countryCode", _properties [3]},
			{ "coordinates", _properties [4]},
			{ "timeZone", _properties [5]},
			{ "contexts", _properties [6]},
			{ "full", _properties [7]},
			{ "defaultSeparator", _properties [8]},
			{ "pref", _properties [9]},
			{ "phoneticScript", _properties [10]},
			{ "phoneticSystem", _properties [11]}}, __Tag,
		() => new Address(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class AddressComponent : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The value of the address component.
    /// </summary>

	[JsonPropertyName("value")]
	public virtual string?					Value  {get; set;} //

    /// <summary>
    /// The kind of the address component. 
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// The pronunciation of the name component. If this property is set, then 
    /// at least one of the Address object phoneticSystem or phoneticScript 
    /// properties MUST be set. 
    /// </summary>

	[JsonPropertyName("phonetic")]
	public virtual string?					Phonetic  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as AddressComponent).Type = value;}, 
					(IBinding data) => (data as AddressComponent).Type ),
		new PropertyString ("value", 
					(IBinding data, string? value) => {(data as AddressComponent).Value = value;}, 
					(IBinding data) => (data as AddressComponent).Value ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as AddressComponent).Kind = value;}, 
					(IBinding data) => (data as AddressComponent).Kind ),
		new PropertyString ("phonetic", 
					(IBinding data, string? value) => {(data as AddressComponent).Phonetic = value;}, 
					(IBinding data) => (data as AddressComponent).Phonetic )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AddressComponent> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "value", _properties [1]},
			{ "kind", _properties [2]},
			{ "phonetic", _properties [3]}}, __Tag,
		() => new AddressComponent(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	/// The cryptographic resources such as public keys and certificates associated 
	///  with the entity represented by the Card.
	/// </summary>
public partial class CryptoKey : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptoKey> _binding = new (
			new() {}, __Tag,
		() => new CryptoKey(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


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

	[JsonPropertyName("listAs")]
	public virtual int?					ListAs  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("listAs", 
					(IBinding data, int? value) => {(data as ContactDirectory).ListAs = value;}, 
					(IBinding data) => (data as ContactDirectory).ListAs )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ContactDirectory> _binding = new (
			new() {
			{ "listAs", _properties [0]}}, __Tag,
		() => new ContactDirectory(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The links to resources that do not fit any of the other use-case-specific resource properties.
	/// </summary>
public partial class ResourceLink : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResourceLink> _binding = new (
			new() {}, __Tag,
		() => new ResourceLink(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The media resources such as photographs, avatars, or sounds that are associated 
	///  with the entity represented by the Card.
	/// </summary>
public partial class Media : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Media> _binding = new (
			new() {}, __Tag,
		() => new Media(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The memorable dates and events for the entity represented by the Card.
	/// </summary>
public partial class Anniversary : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The kind of anniversary.
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// Timestamp (mandatory; defaultType: PartialDate).
    /// The date of the anniversary in the Gregorian calendar. This MUST be 
    /// either a whole or partial calendar date or a complete UTC timestamp 
    /// (see the definition of the Timestamp and PartialDate object types below).
    /// </summary>

	[JsonPropertyName("date")]
	public virtual TimeStamp?					Date  {get; set;} //

    /// <summary>
    /// An address associated with this anniversary, e.g., the place of birth or death.
    /// </summary>

	[JsonPropertyName("place")]
	public virtual Address?					Place  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Anniversary).Type = value;}, 
					(IBinding data) => (data as Anniversary).Type ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Anniversary).Kind = value;}, 
					(IBinding data) => (data as Anniversary).Kind ),
		new PropertyStruct ("date", typeof (TimeStamp),
					(IBinding data, object? value) => {(data as Anniversary).Date = value as TimeStamp;}, 
					(IBinding data) => (data as Anniversary).Date,
					false, ()=>new  TimeStamp(), ()=>new TimeStamp()),
		new PropertyStruct ("place", typeof (Address),
					(IBinding data, object? value) => {(data as Anniversary).Place = value as Address;}, 
					(IBinding data) => (data as Anniversary).Place,
					false, ()=>new  Address(), ()=>new Address())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Anniversary> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "kind", _properties [1]},
			{ "date", _properties [2]},
			{ "place", _properties [3]}}, __Tag,
		() => new Anniversary(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class TimeStamp : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The calendar year.
    /// </summary>

	[JsonPropertyName("year")]
	public virtual int?					Year  {get; set;} //

    /// <summary>
    /// The calendar month, represented as the integers 1 &lt;= month &lt;= 12. If 
    /// this property is set, then either the year or the day property MUST be set.
    /// </summary>

	[JsonPropertyName("month")]
	public virtual int?					Month  {get; set;} //

    /// <summary>
    /// The calendar month day, represented as the integers 1 &lt;= day &lt;= 31, 
    /// depending on the validity within the month and year. If this property 
    /// is set, then the month property MUST be set.
    /// </summary>

	[JsonPropertyName("day")]
	public virtual int?					Day  {get; set;} //

    /// <summary>
    /// The calendar system in which this date occurs, in lowercase. This 
    /// MUST be either a calendar system name registered as a Common Locale 
    /// Data Repository (CLDR) [RFC7529] or a vendor-specific value. The year,
    /// month, and day still MUST be represented in the Gregorian calendar. 
    /// Note that the year property might be required to convert the date 
    /// between the Gregorian calendar and the respective calendar system.
    /// </summary>

	[JsonPropertyName("calendarScale")]
	public virtual string?					CalendarScale  {get; set;} //

    /// <summary>
    /// The point in time in UTC time.
    /// </summary>

	[JsonPropertyName("utc")]
	public virtual string?					Utc  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as TimeStamp).Type = value;}, 
					(IBinding data) => (data as TimeStamp).Type ),
		new PropertyInteger32 ("year", 
					(IBinding data, int? value) => {(data as TimeStamp).Year = value;}, 
					(IBinding data) => (data as TimeStamp).Year ),
		new PropertyInteger32 ("month", 
					(IBinding data, int? value) => {(data as TimeStamp).Month = value;}, 
					(IBinding data) => (data as TimeStamp).Month ),
		new PropertyInteger32 ("day", 
					(IBinding data, int? value) => {(data as TimeStamp).Day = value;}, 
					(IBinding data) => (data as TimeStamp).Day ),
		new PropertyString ("calendarScale", 
					(IBinding data, string? value) => {(data as TimeStamp).CalendarScale = value;}, 
					(IBinding data) => (data as TimeStamp).CalendarScale ),
		new PropertyString ("utc", 
					(IBinding data, string? value) => {(data as TimeStamp).Utc = value;}, 
					(IBinding data) => (data as TimeStamp).Utc )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TimeStamp> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "year", _properties [1]},
			{ "month", _properties [2]},
			{ "day", _properties [3]},
			{ "calendarScale", _properties [4]},
			{ "utc", _properties [5]}}, __Tag,
		() => new TimeStamp(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  A free-text note that is associated with the Card.
	/// </summary>
public partial class Note : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The free-text value of this note.
    /// </summary>

	[JsonPropertyName("Note")]
	public virtual string?					Value  {get; set;} //

    /// <summary>
    /// The date and time when this note was created.
    /// </summary>

	[JsonPropertyName("created")]
	public virtual string?					Created  {get; set;} //

    /// <summary>
    /// The author of this note.
    /// </summary>

	[JsonPropertyName("author")]
	public virtual Author?					Author  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as Note).Type = value;}, 
					(IBinding data) => (data as Note).Type ),
		new PropertyString ("Note", 
					(IBinding data, string? value) => {(data as Note).Value = value;}, 
					(IBinding data) => (data as Note).Value ),
		new PropertyString ("created", 
					(IBinding data, string? value) => {(data as Note).Created = value;}, 
					(IBinding data) => (data as Note).Created ),
		new PropertyStruct ("author", typeof (Author),
					(IBinding data, object? value) => {(data as Note).Author = value as Author;}, 
					(IBinding data) => (data as Note).Author,
					false, ()=>new  Author(), ()=>new Author())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Note> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "Note", _properties [1]},
			{ "created", _properties [2]},
			{ "author", _properties [3]}}, __Tag,
		() => new Note(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	///
	///  The author of a note.
	/// </summary>
public partial class Author : Contacts {
    /// <summary>
    /// The JSContact type of the object. The value MUST be "Author", if set.
    /// </summary>

	[JsonPropertyName("type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The name of this author.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// The URI value that identifies the author.
    /// </summary>

	[JsonPropertyName("uri")]
	public virtual string?					Uri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("type", 
					(IBinding data, string? value) => {(data as Author).Type = value;}, 
					(IBinding data) => (data as Author).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Author).Name = value;}, 
					(IBinding data) => (data as Author).Name ),
		new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as Author).Uri = value;}, 
					(IBinding data) => (data as Author).Uri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Author> _binding = new (
			new() {
			{ "type", _properties [0]},
			{ "name", _properties [1]},
			{ "uri", _properties [2]}}, __Tag,
		() => new Author(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	///  The personal information of the entity represented by the Card.
	/// </summary>
public partial class PersonalInfo : Contacts {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The kind of personal information
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// The actual information
    /// </summary>

	[JsonPropertyName("value")]
	public virtual string?					Value  {get; set;} //

    /// <summary>
    /// The level of expertise or engagement in hobby or interest. 
    /// </summary>

	[JsonPropertyName("level")]
	public virtual string?					Level  {get; set;} //

    /// <summary>
    /// The position of the personal information in the list of all PersonalInfo
    /// objects that have the same kind property value in the Card. If set, the 
    /// listAs value MUST be higher than zero. Multiple personal information entries
    /// MAY have the same listAs property value or none. Sorting such same-valued 
    /// entries is implementation-specific.
    /// </summary>

	[JsonPropertyName("listAs")]
	public virtual int?					ListAs  {get; set;} //

    /// <summary>
    /// A custom label. 
    /// </summary>

	[JsonPropertyName("label")]
	public virtual string?					Label  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(IBinding data, string? value) => {(data as PersonalInfo).Type = value;}, 
					(IBinding data) => (data as PersonalInfo).Type ),
		new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as PersonalInfo).Kind = value;}, 
					(IBinding data) => (data as PersonalInfo).Kind ),
		new PropertyString ("value", 
					(IBinding data, string? value) => {(data as PersonalInfo).Value = value;}, 
					(IBinding data) => (data as PersonalInfo).Value ),
		new PropertyString ("level", 
					(IBinding data, string? value) => {(data as PersonalInfo).Level = value;}, 
					(IBinding data) => (data as PersonalInfo).Level ),
		new PropertyInteger32 ("listAs", 
					(IBinding data, int? value) => {(data as PersonalInfo).ListAs = value;}, 
					(IBinding data) => (data as PersonalInfo).ListAs ),
		new PropertyString ("label", 
					(IBinding data, string? value) => {(data as PersonalInfo).Label = value;}, 
					(IBinding data) => (data as PersonalInfo).Label )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PersonalInfo> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "kind", _properties [1]},
			{ "value", _properties [2]},
			{ "level", _properties [3]},
			{ "listAs", _properties [4]},
			{ "label", _properties [5]}}, __Tag,
		() => new PersonalInfo(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Update : Resource {
    /// <summary>
    /// The IANA update protocol identifier
    /// </summary>

	[JsonPropertyName("protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// The identifiers of the set of cryptographic keys to be used to 
    /// authenticate the updated contact information and their use.
    /// </summary>

	[JsonPropertyName("keys")]
	public virtual Dictionary<string,string>?					Keys  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("protocol", 
					(IBinding data, string? value) => {(data as Update).Protocol = value;}, 
					(IBinding data) => (data as Update).Protocol ),
		new PropertyDictionaryString ("keys", 
					(IBinding data, Dictionary<string,string>? value) => {(data as Update).Keys = value;}, 
					(IBinding data) => (data as Update).Keys )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Update> _binding = new (
			new() {
			{ "protocol", _properties [0]},
			{ "keys", _properties [1]}}, __Tag,
		() => new Update(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Update";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Update();

	}


	/// <summary>
	/// </summary>
public partial class JsonWebKeySet : CryptoKey {
    /// <summary>
    ///Binary credential data (NB, may be moved to JWK.)
    /// </summary>

	[JsonPropertyName("data")]
	public virtual byte[]?					Data  {get; set;} //

    /// <summary>
    ///A Json Web Key Set.
    /// </summary>

	[JsonPropertyName("jsonWebKeys")]
	public virtual List<JWK>?					JsonWebKeys  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("data", 
					(IBinding data, byte[]? value) => {(data as JsonWebKeySet).Data = value;}, 
					(IBinding data) => (data as JsonWebKeySet).Data ),
		new PropertyListStruct ("jsonWebKeys", typeof (JWK),
					(IBinding data, object? value) => {(data as JsonWebKeySet).JsonWebKeys = value as List<JWK>;}, 
					(IBinding data) => (data as JsonWebKeySet).JsonWebKeys,
					false, ()=>new  List<JWK>(), ()=>new JWK())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsonWebKeySet> _binding = new (
			new() {
			{ "data", _properties [0]},
			{ "jsonWebKeys", _properties [1]}}, __Tag,
		() => new JsonWebKeySet(), () => [], () => [], CryptoKey._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsonWebKeySet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsonWebKeySet();

	}


	/// <summary>
	/// </summary>
public partial class ServiceGroup : Resource {
    /// <summary>
    ///The identifiers of the service group members. The boolean value corresponding
    ///to each MUST be true.
    /// </summary>

	[JsonPropertyName("members")]
	public virtual Dictionary<string,bool>?					Members  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDictionaryBoolean ("members", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as ServiceGroup).Members = value;}, 
					(IBinding data) => (data as ServiceGroup).Members )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceGroup> _binding = new (
			new() {
			{ "members", _properties [0]}}, __Tag,
		() => new ServiceGroup(), () => [], () => [], Resource._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceGroup();

	}



