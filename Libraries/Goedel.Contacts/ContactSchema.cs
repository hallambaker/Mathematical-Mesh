
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
//  This file was automatically generated at 2/12/2025 7:14:17 PM
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
	    {"TaggedBoolean", TaggedBoolean._Factory},
	    {"Name", Name._Factory},
	    {"NameComponent", NameComponent._Factory},
	    {"NickName", NickName._Factory},
	    {"Organization", Organization._Factory},
	    {"SpeakToAs", SpeakToAs._Factory},
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
	    {"Note", Note._Factory},
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
	/// Metadata, see section 2.1
	/// </summary>
public partial class ContactCard : Contacts {
        /// <summary>
        /// If specified, value MUST be 'card'
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// If specified, value MUST be '1.0'
        /// </summary>

	public virtual string?						Version  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Uid  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Created  {get; set;}

        /// <summary>
        /// individual: a single person
        /// group: a group of people or entities
        /// org: an organization
        /// location: a named location
        /// device: a device such as an appliance, a computer, or a network element
        /// application: a software application
        /// </summary>

	public virtual string?						Kind  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Language  {get; set;}

        /// <summary>
        ///Uses some funky formatting, see 2.1.6. members
        ///[ "member1", "member2"] is encoded as
        ///{ "member1" : true, "member2" : true }
        /// </summary>

	public virtual List<string>?					Members  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						ProdId  {get; set;}

        /// <summary>
        /// acquaintance agent child co-resident co-worker colleague 
        /// contact crush date emergency friend kin me met muse
        /// neighbor parent sibling spouse sweetheart
        /// </summary>

	public virtual List<TaggedBoolean>?					RelatedTo  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						Updated  {get; set;}

        /// <summary>
        /// </summary>

	public virtual Name?						Name  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<NickName>?					NickNames  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Organization>?					Organizations  {get; set;}
        /// <summary>
        /// </summary>

	public virtual SpeakToAs?						SpeakToAs  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<Title>?					Titles  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<EmailAddress>?					Emails  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<OnlineService>?					OnlineServices  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Phone>?					Phones  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<LanguagePref>?					PreferredLanguages  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Calendar>?					Calendars  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<SchedulingAddress>?					SchedulingAddresses  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Address>?					Addresses  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<CryptoKey>?					CryptoKeys  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Directory>?					Directories  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Link>?					Links  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Media>?					Media  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<PatchObject>?					Localizations  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Anniversary>?					Anniversaries  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<TaggedBoolean>?					Keywords  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<Note>?					Notes  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<PersonalInfo>?					PersonalInfo  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as ContactCard).Type = value;}, (IBinding data) => (data as ContactCard).Type )},
			{ "Version", new PropertyString ("Version", 
					(IBinding data, string? value) => {(data as ContactCard).Version = value;}, (IBinding data) => (data as ContactCard).Version )},
			{ "Uid", new PropertyString ("Uid", 
					(IBinding data, string? value) => {(data as ContactCard).Uid = value;}, (IBinding data) => (data as ContactCard).Uid )},
			{ "Created", new PropertyString ("Created", 
					(IBinding data, string? value) => {(data as ContactCard).Created = value;}, (IBinding data) => (data as ContactCard).Created )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as ContactCard).Kind = value;}, (IBinding data) => (data as ContactCard).Kind )},
			{ "Language", new PropertyString ("Language", 
					(IBinding data, string? value) => {(data as ContactCard).Language = value;}, (IBinding data) => (data as ContactCard).Language )},
			{ "Members", new PropertyListString ("Members", 
					(IBinding data, List<string>? value) => {(data as ContactCard).Members = value;}, (IBinding data) => (data as ContactCard).Members )},
			{ "ProdId", new PropertyString ("ProdId", 
					(IBinding data, string? value) => {(data as ContactCard).ProdId = value;}, (IBinding data) => (data as ContactCard).ProdId )},
			{ "RelatedTo", new PropertyListStruct ("RelatedTo", 
					(IBinding data, object? value) => {(data as ContactCard).RelatedTo = value as List<TaggedBoolean>;}, (IBinding data) => (data as ContactCard).RelatedTo,
					false, ()=>new  List<TaggedBoolean>(), ()=>new TaggedBoolean())} ,
			{ "Updated", new PropertyString ("Updated", 
					(IBinding data, string? value) => {(data as ContactCard).Updated = value;}, (IBinding data) => (data as ContactCard).Updated )},
			{ "Name", new PropertyStruct ("Name", 
					(IBinding data, object? value) => {(data as ContactCard).Name = value as Name;}, (IBinding data) => (data as ContactCard).Name,
					false, ()=>new  Name(), ()=>new Name())} ,
			{ "NickNames", new PropertyListStruct ("NickNames", 
					(IBinding data, object? value) => {(data as ContactCard).NickNames = value as List<NickName>;}, (IBinding data) => (data as ContactCard).NickNames,
					false, ()=>new  List<NickName>(), ()=>new NickName())} ,
			{ "Organizations", new PropertyListStruct ("Organizations", 
					(IBinding data, object? value) => {(data as ContactCard).Organizations = value as List<Organization>;}, (IBinding data) => (data as ContactCard).Organizations,
					false, ()=>new  List<Organization>(), ()=>new Organization())} ,
			{ "SpeakToAs", new PropertyStruct ("SpeakToAs", 
					(IBinding data, object? value) => {(data as ContactCard).SpeakToAs = value as SpeakToAs;}, (IBinding data) => (data as ContactCard).SpeakToAs,
					false, ()=>new  SpeakToAs(), ()=>new SpeakToAs())} ,
			{ "Titles", new PropertyListStruct ("Titles", 
					(IBinding data, object? value) => {(data as ContactCard).Titles = value as List<Title>;}, (IBinding data) => (data as ContactCard).Titles,
					false, ()=>new  List<Title>(), ()=>new Title())} ,
			{ "Emails", new PropertyListStruct ("Emails", 
					(IBinding data, object? value) => {(data as ContactCard).Emails = value as List<EmailAddress>;}, (IBinding data) => (data as ContactCard).Emails,
					false, ()=>new  List<EmailAddress>(), ()=>new EmailAddress())} ,
			{ "OnlineServices", new PropertyListStruct ("OnlineServices", 
					(IBinding data, object? value) => {(data as ContactCard).OnlineServices = value as List<OnlineService>;}, (IBinding data) => (data as ContactCard).OnlineServices,
					false, ()=>new  List<OnlineService>(), ()=>new OnlineService())} ,
			{ "Phones", new PropertyListStruct ("Phones", 
					(IBinding data, object? value) => {(data as ContactCard).Phones = value as List<Phone>;}, (IBinding data) => (data as ContactCard).Phones,
					false, ()=>new  List<Phone>(), ()=>new Phone())} ,
			{ "PreferredLanguages", new PropertyListStruct ("PreferredLanguages", 
					(IBinding data, object? value) => {(data as ContactCard).PreferredLanguages = value as List<LanguagePref>;}, (IBinding data) => (data as ContactCard).PreferredLanguages,
					false, ()=>new  List<LanguagePref>(), ()=>new LanguagePref())} ,
			{ "Calendars", new PropertyListStruct ("Calendars", 
					(IBinding data, object? value) => {(data as ContactCard).Calendars = value as List<Calendar>;}, (IBinding data) => (data as ContactCard).Calendars,
					false, ()=>new  List<Calendar>(), ()=>new Calendar())} ,
			{ "SchedulingAddresses", new PropertyListStruct ("SchedulingAddresses", 
					(IBinding data, object? value) => {(data as ContactCard).SchedulingAddresses = value as List<SchedulingAddress>;}, (IBinding data) => (data as ContactCard).SchedulingAddresses,
					false, ()=>new  List<SchedulingAddress>(), ()=>new SchedulingAddress())} ,
			{ "Addresses", new PropertyListStruct ("Addresses", 
					(IBinding data, object? value) => {(data as ContactCard).Addresses = value as List<Address>;}, (IBinding data) => (data as ContactCard).Addresses,
					false, ()=>new  List<Address>(), ()=>new Address())} ,
			{ "CryptoKeys", new PropertyListStruct ("CryptoKeys", 
					(IBinding data, object? value) => {(data as ContactCard).CryptoKeys = value as List<CryptoKey>;}, (IBinding data) => (data as ContactCard).CryptoKeys,
					false, ()=>new  List<CryptoKey>(), ()=>new CryptoKey())} ,
			{ "Directories", new PropertyListStruct ("Directories", 
					(IBinding data, object? value) => {(data as ContactCard).Directories = value as List<Directory>;}, (IBinding data) => (data as ContactCard).Directories,
					false, ()=>new  List<Directory>(), ()=>new Directory())} ,
			{ "Links", new PropertyListStruct ("Links", 
					(IBinding data, object? value) => {(data as ContactCard).Links = value as List<Link>;}, (IBinding data) => (data as ContactCard).Links,
					false, ()=>new  List<Link>(), ()=>new Link())} ,
			{ "Media", new PropertyListStruct ("Media", 
					(IBinding data, object? value) => {(data as ContactCard).Media = value as List<Media>;}, (IBinding data) => (data as ContactCard).Media,
					false, ()=>new  List<Media>(), ()=>new Media())} ,
			{ "Localizations", new PropertyListStruct ("Localizations", 
					(IBinding data, object? value) => {(data as ContactCard).Localizations = value as List<PatchObject>;}, (IBinding data) => (data as ContactCard).Localizations,
					false, ()=>new  List<PatchObject>(), ()=>new PatchObject())} ,
			{ "Anniversaries", new PropertyListStruct ("Anniversaries", 
					(IBinding data, object? value) => {(data as ContactCard).Anniversaries = value as List<Anniversary>;}, (IBinding data) => (data as ContactCard).Anniversaries,
					false, ()=>new  List<Anniversary>(), ()=>new Anniversary())} ,
			{ "Keywords", new PropertyListStruct ("Keywords", 
					(IBinding data, object? value) => {(data as ContactCard).Keywords = value as List<TaggedBoolean>;}, (IBinding data) => (data as ContactCard).Keywords,
					false, ()=>new  List<TaggedBoolean>(), ()=>new TaggedBoolean())} ,
			{ "Notes", new PropertyListStruct ("Notes", 
					(IBinding data, object? value) => {(data as ContactCard).Notes = value as List<Note>;}, (IBinding data) => (data as ContactCard).Notes,
					false, ()=>new  List<Note>(), ()=>new Note())} ,
			{ "PersonalInfo", new PropertyListStruct ("PersonalInfo", 
					(IBinding data, object? value) => {(data as ContactCard).PersonalInfo = value as List<PersonalInfo>;}, (IBinding data) => (data as ContactCard).PersonalInfo,
					false, ()=>new  List<PersonalInfo>(), ()=>new PersonalInfo())} 
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
public partial class TaggedBoolean : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?						Tag  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						Value  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Tag", new PropertyString ("Tag", 
					(IBinding data, string? value) => {(data as TaggedBoolean).Tag = value;}, (IBinding data) => (data as TaggedBoolean).Tag )},
			{ "Value", new PropertyBoolean ("Value", 
					(IBinding data, bool? value) => {(data as TaggedBoolean).Value = value;}, (IBinding data) => (data as TaggedBoolean).Value )}
        }, __Tag,() => new TaggedBoolean(), null);

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
	public new const string __Tag = "TaggedBoolean";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TaggedBoolean();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TaggedBoolean FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TaggedBoolean;
			}
		var Result = new TaggedBoolean ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Name : Contacts {
        /// <summary>
        /// </summary>

	public virtual List<NameComponent>?					Components  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						IsOrdered  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						DefaultSeparator  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Full  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						SortAs  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						PhoneticScript  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						PhoneticSystem  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Components", new PropertyListStruct ("Components", 
					(IBinding data, object? value) => {(data as Name).Components = value as List<NameComponent>;}, (IBinding data) => (data as Name).Components,
					false, ()=>new  List<NameComponent>(), ()=>new NameComponent())} ,
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
	/// As specified in 2.2.1.2. NameComponent
	/// </summary>
public partial class NameComponent : Contacts {
        /// <summary>
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
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

	public virtual string?						Tag  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Name  {get; set;}

        /// <summary>
        /// </summary>

	public virtual TaggedBoolean?						Contexts  {get; set;}

        /// <summary>
        /// </summary>

	public virtual int?						Pref  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "Tag", new PropertyString ("Tag", 
					(IBinding data, string? value) => {(data as NickName).Tag = value;}, (IBinding data) => (data as NickName).Tag )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as NickName).Name = value;}, (IBinding data) => (data as NickName).Name )},
			{ "Contexts", new PropertyStruct ("Contexts", 
					(IBinding data, object? value) => {(data as NickName).Contexts = value as TaggedBoolean;}, (IBinding data) => (data as NickName).Contexts,
					false, ()=>new  TaggedBoolean(), ()=>new TaggedBoolean())} ,
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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@type", new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Organization).Type = value;}, (IBinding data) => (data as Organization).Type )}
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
public partial class SpeakToAs : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
public partial class Title : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class Calendar : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Calendar(), null);

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
	/// </summary>
public partial class SchedulingAddress : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class Address : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class AddressComponent : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class CryptoKey : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new CryptoKey(), null);

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
	/// </summary>
public partial class Directory : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Directory(), null);

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
	/// </summary>
public partial class Link : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Link(), null);

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
	/// </summary>
public partial class Media : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new Media(), null);

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
	/// </summary>
public partial class PatchObject : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

        }, __Tag,() => new PatchObject(), null);

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
	/// </summary>
public partial class Anniversary : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class Note : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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
	/// </summary>
public partial class PersonalInfo : Contacts {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

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



