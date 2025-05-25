
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
//  This file was automatically generated at 5/25/2025 12:14:14 AM
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
public abstract partial class Devices : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Devices";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Device", JsDevice._Factory},
	    {"Network", Network._Factory},
	    {"Maintenance", Maintenance._Factory},
	    {"Supplier", Supplier._Factory},
	    {"RelatedItem", RelatedItem._Factory},
	    {"Component", Component._Factory},
	    {"Dimensions", Dimensions._Factory}
		};


	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsDevice), JsDevice._binding},
	    {typeof(Network), Network._binding},
	    {typeof(Maintenance), Maintenance._binding},
	    {typeof(Supplier), Supplier._binding},
	    {typeof(RelatedItem), RelatedItem._binding},
	    {typeof(Component), Component._binding},
	    {typeof(Dimensions), Dimensions._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Devices() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _tagDictionary);
		AddDictionary(ref _bindingDictionary);
		}

	/*
	/// <summary>
    /// Construct an instance from the specified tagged JsonReader stream.
    /// </summary>
    /// <param name="jsonReader">Input stream</param>
    /// <param name="result">The created object</param>
    public static void Deserialize(JsonReader jsonReader, out JsonObject result) => 
		result = jsonReader.ReadTaggedObject(_TagDictionary);
	*/

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	///
	///  Metadata, 
	/// </summary>
public partial class JsDevice : JmapBase {
        /// <summary>
        ///The JSDevice version of this description. The value MUST be one 
        ///of the IANA-registered JSDevice Version values for the version property. 
        /// </summary>

	[JsonPropertyName("version")]
	public virtual string?					Version  {get; set;}

        /// <summary>
        /// The kind of the entity described
        /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// The language tag, as defined in [RFC5646], that best describes the language 
        /// used for text in the description, optionally including additional information such 
        /// as the script. Note that values MAY be localized in the localizations 
        /// property.
        /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					Language  {get; set;}

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
	public virtual Dictionary<string,JsDevice>?					Localizations  {get; set;}

        /// <summary>
        /// A URI that uniquely identifies the device.
        /// </summary>

	[JsonPropertyName("deviceId")]
	public virtual string?					DeviceId  {get; set;}

        /// <summary>
        /// A URI that uniquely identifies the device model.
        /// </summary>

	[JsonPropertyName("modelId")]
	public virtual string?					ModelId  {get; set;}

        /// <summary>
        /// Human readable model name.
        /// </summary>

	[JsonPropertyName("modelName")]
	public virtual string?					ModelName  {get; set;}

        /// <summary>
        /// Device manufacturer name.
        /// </summary>

	[JsonPropertyName("manufacturer")]
	public virtual string?					Manufacturer  {get; set;}

        /// <summary>
        /// Date of manufacture.
        /// </summary>

	[JsonPropertyName("dateManufacture")]
	public virtual DateTime?					DateManufacture  {get; set;}

        /// <summary>
        /// Date at which support for the device is scheduled to end.
        /// </summary>

	[JsonPropertyName("endSupport")]
	public virtual DateTime?					EndSupport  {get; set;}

        /// <summary>
        /// Date at which it is advised the device be taken out of service.
        /// </summary>

	[JsonPropertyName("endLife")]
	public virtual DateTime?					EndLife  {get; set;}

        /// <summary>
        ///The physical components making up the device and their dimensions.
        /// </summary>

	[JsonPropertyName("components")]
	public virtual Dictionary<string,Component>?					Components  {get; set;}

        /// <summary>
        /// Photographs and schematics of the device or model.
        /// </summary>

	[JsonPropertyName("images")]
	public virtual List<Media>?					Images  {get; set;}
        /// <summary>
        /// Manuals describing the device.
        /// </summary>

	[JsonPropertyName("documentation")]
	public virtual List<Media>?					Documentation  {get; set;}
        /// <summary>
        /// Suppliers for the device and related accessories.
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}
        /// <summary>
        /// List of maintenance events associated with the device.
        /// </summary>

	[JsonPropertyName("maintenance")]
	public virtual Dictionary<string,Maintenance>?					Maintenance  {get; set;}

        /// <summary>
        /// Accessories, parts and consumables related to the device. 
        ///For example, ink cartridges, parts likely to wear etc.
        /// </summary>

	[JsonPropertyName("relatedItems")]
	public virtual Dictionary<string,RelatedItem>?					RelatedItems  {get; set;}

        /// <summary>
        /// The network protocol connections supported.
        /// </summary>

	[JsonPropertyName("network")]
	public virtual Dictionary<string,Network>?					Network  {get; set;}

        /// <summary>
        /// The cryptographic resources such as public keys and certificates associated 
        /// with the device
        /// The CryptoKey object is defined in JSContact and JSContact Cryptographic Extensions.
        /// </summary>

	[JsonPropertyName("cryptoKeys")]
	public virtual Dictionary<string,CryptoKey>?					CryptoKeys  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsDevice> _binding = new (
			new() {

			{ "version", new PropertyString ("version", 
					(IBinding data, string? value) => {(data as JsDevice).Version = value;}, (IBinding data) => (data as JsDevice).Version )},
			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as JsDevice).Kind = value;}, (IBinding data) => (data as JsDevice).Kind )},
			{ "language", new PropertyString ("language", 
					(IBinding data, string? value) => {(data as JsDevice).Language = value;}, (IBinding data) => (data as JsDevice).Language )},
			{ "localizations", new PropertyDictionaryStruct ("localizations", typeof (JsDevice),
					(IBinding data, object? value) => {(data as JsDevice).Localizations = value as Dictionary<string,JsDevice>;}, (IBinding data) => (data as JsDevice).Localizations,
					false, ()=>new  Dictionary<string,JsDevice>(), ()=>new JsDevice(),
					(IBinding data) => (data as JsDevice).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsDevice>).Add (key as string,value as JsDevice);})},
			{ "deviceId", new PropertyString ("deviceId", 
					(IBinding data, string? value) => {(data as JsDevice).DeviceId = value;}, (IBinding data) => (data as JsDevice).DeviceId )},
			{ "modelId", new PropertyString ("modelId", 
					(IBinding data, string? value) => {(data as JsDevice).ModelId = value;}, (IBinding data) => (data as JsDevice).ModelId )},
			{ "modelName", new PropertyString ("modelName", 
					(IBinding data, string? value) => {(data as JsDevice).ModelName = value;}, (IBinding data) => (data as JsDevice).ModelName )},
			{ "manufacturer", new PropertyString ("manufacturer", 
					(IBinding data, string? value) => {(data as JsDevice).Manufacturer = value;}, (IBinding data) => (data as JsDevice).Manufacturer )},
			{ "dateManufacture", new PropertyDateTime ("dateManufacture", 
					(IBinding data, DateTime? value) => {(data as JsDevice).DateManufacture = value;}, (IBinding data) => (data as JsDevice).DateManufacture )},
			{ "endSupport", new PropertyDateTime ("endSupport", 
					(IBinding data, DateTime? value) => {(data as JsDevice).EndSupport = value;}, (IBinding data) => (data as JsDevice).EndSupport )},
			{ "endLife", new PropertyDateTime ("endLife", 
					(IBinding data, DateTime? value) => {(data as JsDevice).EndLife = value;}, (IBinding data) => (data as JsDevice).EndLife )},
			{ "components", new PropertyDictionaryStruct ("components", typeof (Component),
					(IBinding data, object? value) => {(data as JsDevice).Components = value as Dictionary<string,Component>;}, (IBinding data) => (data as JsDevice).Components,
					false, ()=>new  Dictionary<string,Component>(), ()=>new Component(),
					(IBinding data) => (data as JsDevice).Components.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Component>).Add (key as string,value as Component);})},
			{ "images", new PropertyListStruct ("images", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Images = value as List<Media>;}, (IBinding data) => (data as JsDevice).Images,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "documentation", new PropertyListStruct ("documentation", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Documentation = value as List<Media>;}, (IBinding data) => (data as JsDevice).Documentation,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as JsDevice).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as JsDevice).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())},
			{ "maintenance", new PropertyDictionaryStruct ("maintenance", typeof (Maintenance),
					(IBinding data, object? value) => {(data as JsDevice).Maintenance = value as Dictionary<string,Maintenance>;}, (IBinding data) => (data as JsDevice).Maintenance,
					false, ()=>new  Dictionary<string,Maintenance>(), ()=>new Maintenance(),
					(IBinding data) => (data as JsDevice).Maintenance.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Maintenance>).Add (key as string,value as Maintenance);})},
			{ "relatedItems", new PropertyDictionaryStruct ("relatedItems", typeof (RelatedItem),
					(IBinding data, object? value) => {(data as JsDevice).RelatedItems = value as Dictionary<string,RelatedItem>;}, (IBinding data) => (data as JsDevice).RelatedItems,
					false, ()=>new  Dictionary<string,RelatedItem>(), ()=>new RelatedItem(),
					(IBinding data) => (data as JsDevice).RelatedItems.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,RelatedItem>).Add (key as string,value as RelatedItem);})},
			{ "network", new PropertyDictionaryStruct ("network", typeof (Network),
					(IBinding data, object? value) => {(data as JsDevice).Network = value as Dictionary<string,Network>;}, (IBinding data) => (data as JsDevice).Network,
					false, ()=>new  Dictionary<string,Network>(), ()=>new Network(),
					(IBinding data) => (data as JsDevice).Network.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Network>).Add (key as string,value as Network);})},
			{ "cryptoKeys", new PropertyDictionaryStruct ("cryptoKeys", typeof (CryptoKey),
					(IBinding data, object? value) => {(data as JsDevice).CryptoKeys = value as Dictionary<string,CryptoKey>;}, (IBinding data) => (data as JsDevice).CryptoKeys,
					false, ()=>new  Dictionary<string,CryptoKey>(), ()=>new CryptoKey(),
					(IBinding data) => (data as JsDevice).CryptoKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,CryptoKey>).Add (key as string,value as CryptoKey);})}
        }, __Tag,() => new JsDevice(), () => new List<JsDevice>(), () => new Dictionary<string,JsDevice>(),JmapBase._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(JmapBase._binding, _binding);


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
	public new const string __Tag = "Device";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsDevice();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JsDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JsDevice;
			}
		var Result = new JsDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	/// </summary>
public partial class Network : Devices {
        /// <summary>
        /// The network connection kind
        /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        ///The Internet Protocol Address(es)
        /// </summary>

	[JsonPropertyName("address")]
	public virtual List<string>?					Address  {get; set;}
        /// <summary>
        ///The IANA protocol identifier
        /// </summary>

	[JsonPropertyName("identifier")]
	public virtual string?					Identifier  {get; set;}

        /// <summary>
        ///The default IP ports.
        /// </summary>

	[JsonPropertyName("ports")]
	public virtual List<int>?					Ports  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("endpoints")]
	public virtual List<string>?					Endpoints  {get; set;}
        /// <summary>
        /// The identifiers of the set of device keys that MAY be used in combination
        /// with this protocol
        /// </summary>

	[JsonPropertyName("keys")]
	public virtual Dictionary<string,string>?					Keys  {get; set;}

        /// <summary>
        ///Permission identifiers used to assign access rights to control of the
        ///device.
        /// </summary>

	[JsonPropertyName("permissions")]
	public virtual List<string>?					Permissions  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Network> _binding = new (
			new() {

			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Network).Kind = value;}, (IBinding data) => (data as Network).Kind )},
			{ "address", new PropertyListString ("address", 
					(IBinding data, List<string>? value) => {(data as Network).Address = value;}, (IBinding data) => (data as Network).Address )},
			{ "identifier", new PropertyString ("identifier", 
					(IBinding data, string? value) => {(data as Network).Identifier = value;}, (IBinding data) => (data as Network).Identifier )},
			{ "ports", new PropertyListInteger32 ("ports", 
					(IBinding data, List<int>? value) => {(data as Network).Ports = value;}, (IBinding data) => (data as Network).Ports )},
			{ "endpoints", new PropertyListString ("endpoints", 
					(IBinding data, List<string>? value) => {(data as Network).Endpoints = value;}, (IBinding data) => (data as Network).Endpoints )},
			{ "keys", new PropertyDictionaryString ("keys", 
					(IBinding data, Dictionary<string,string>? value) => {(data as Network).Keys = value;}, (IBinding data) => (data as Network).Keys )},
			{ "permissions", new PropertyListString ("permissions", 
					(IBinding data, List<string>? value) => {(data as Network).Permissions = value;}, (IBinding data) => (data as Network).Permissions )}
        }, __Tag,() => new Network(), () => new List<Network>(), () => new Dictionary<string,Network>(),null);

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
	public new const string __Tag = "Network";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Network();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Network FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Network;
			}
		var Result = new Network ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	///
	///  Maintenance events associated with the device.
	/// </summary>
public partial class Maintenance : Resource {
        /// <summary>
        /// If true (default), the maintenance event recurs as specified by the
        ///days, months and years properties. If false, the maintenance event 
        /// is a one-time operation occurring the specified interval after installation.
        /// </summary>

	[JsonPropertyName("recurring")]
	public virtual bool?					Recurring  {get; set;}

        /// <summary>
        /// Interval days.
        /// </summary>

	[JsonPropertyName("days")]
	public virtual int?					Days  {get; set;}

        /// <summary>
        /// Interval months. If specified, the days property is ignored.
        /// </summary>

	[JsonPropertyName("months")]
	public virtual int?					Months  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Maintenance> _binding = new (
			new() {

			{ "recurring", new PropertyBoolean ("recurring", 
					(IBinding data, bool? value) => {(data as Maintenance).Recurring = value;}, (IBinding data) => (data as Maintenance).Recurring )},
			{ "days", new PropertyInteger32 ("days", 
					(IBinding data, int? value) => {(data as Maintenance).Days = value;}, (IBinding data) => (data as Maintenance).Days )},
			{ "months", new PropertyInteger32 ("months", 
					(IBinding data, int? value) => {(data as Maintenance).Months = value;}, (IBinding data) => (data as Maintenance).Months )}
        }, __Tag,() => new Maintenance(), () => new List<Maintenance>(), () => new Dictionary<string,Maintenance>(),Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Resource._binding, _binding);


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
	public new const string __Tag = "Maintenance";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Maintenance();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Maintenance FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Maintenance;
			}
		var Result = new Maintenance ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	///
	///  Suppliers for devices and accessories related to the device.
	/// </summary>
public partial class Supplier : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Supplier> _binding = new (
			new() {

        }, __Tag,() => new Supplier(), () => new List<Supplier>(), () => new Dictionary<string,Supplier>(),Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Resource._binding, _binding);


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
	public new const string __Tag = "Supplier";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Supplier();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Supplier FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Supplier;
			}
		var Result = new Supplier ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	///
	///  A related accessory, consumable or part
	/// </summary>
public partial class RelatedItem : Resource {
        /// <summary>
        ///A list of URIs specifying model identifiers. These MAY include
        ///related variations of the same item. For example, different 
        ///sizes of the same color ink.
        /// </summary>

	[JsonPropertyName("modelId")]
	public virtual List<string>?					ModelId  {get; set;}
        /// <summary>
        ///A list of URIs linking to suppliers for the consumable.
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RelatedItem> _binding = new (
			new() {

			{ "modelId", new PropertyListString ("modelId", 
					(IBinding data, List<string>? value) => {(data as RelatedItem).ModelId = value;}, (IBinding data) => (data as RelatedItem).ModelId )},
			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as RelatedItem).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as RelatedItem).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())}
        }, __Tag,() => new RelatedItem(), () => new List<RelatedItem>(), () => new Dictionary<string,RelatedItem>(),Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Resource._binding, _binding);


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
	public new const string __Tag = "RelatedItem";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RelatedItem();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RelatedItem FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RelatedItem;
			}
		var Result = new RelatedItem ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	///
	///  The physical properties of the component parts of the device.
	/// The Width, Depth and Height values are given relative to its usual 
	/// orientation
	/// </summary>
public partial class Component : Resource {
        /// <summary>
        ///The dimension specifications
        /// </summary>

	[JsonPropertyName("dimensions")]
	public virtual Dictionary<string,Dimensions>?					Dimensions  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Component> _binding = new (
			new() {

			{ "dimensions", new PropertyDictionaryStruct ("dimensions", typeof (Dimensions),
					(IBinding data, object? value) => {(data as Component).Dimensions = value as Dictionary<string,Dimensions>;}, (IBinding data) => (data as Component).Dimensions,
					false, ()=>new  Dictionary<string,Dimensions>(), ()=>new Dimensions(),
					(IBinding data) => (data as Component).Dimensions.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Dimensions>).Add (key as string,value as Dimensions);})}
        }, __Tag,() => new Component(), () => new List<Component>(), () => new Dictionary<string,Component>(),Resource._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Resource._binding, _binding);


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
	public new const string __Tag = "Component";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Component();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Component FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Component;
			}
		var Result = new Component ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}


	/// <summary>
	///
	/// The physical properties of the component parts of the device.
	/// The Width, Depth and Height values are given relative to its typical orientation.
	/// All values are in SI units
	/// </summary>
public partial class Dimensions : Devices {
        /// <summary>
        ///The type of dimensions specified, 'typical', 'maximum', 'shipping'
        /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        ///The weight of the component in kilograms
        /// </summary>

	[JsonPropertyName("weight")]
	public virtual double?					Weight  {get; set;}

        /// <summary>
        ///The width of the component in meters
        /// </summary>

	[JsonPropertyName("width")]
	public virtual double?					Width  {get; set;}

        /// <summary>
        ///The depth of the component in meters
        /// </summary>

	[JsonPropertyName("depth")]
	public virtual double?					Depth  {get; set;}

        /// <summary>
        ///The height of the component in meters
        /// </summary>

	[JsonPropertyName("height")]
	public virtual double?					Height  {get; set;}

        /// <summary>
        ///The minimum temperature for the device
        /// </summary>

	[JsonPropertyName("temperatureMin")]
	public virtual double?					TemperatureMin  {get; set;}

        /// <summary>
        ///The maximum temperature for the device
        /// </summary>

	[JsonPropertyName("temperatureMax")]
	public virtual double?					TemperatureMax  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Dimensions> _binding = new (
			new() {

			{ "kind", new PropertyString ("kind", 
					(IBinding data, string? value) => {(data as Dimensions).Kind = value;}, (IBinding data) => (data as Dimensions).Kind )},
			{ "weight", new PropertyReal64 ("weight", 
					(IBinding data, double? value) => {(data as Dimensions).Weight = value;}, (IBinding data) => (data as Dimensions).Weight )},
			{ "width", new PropertyReal64 ("width", 
					(IBinding data, double? value) => {(data as Dimensions).Width = value;}, (IBinding data) => (data as Dimensions).Width )},
			{ "depth", new PropertyReal64 ("depth", 
					(IBinding data, double? value) => {(data as Dimensions).Depth = value;}, (IBinding data) => (data as Dimensions).Depth )},
			{ "height", new PropertyReal64 ("height", 
					(IBinding data, double? value) => {(data as Dimensions).Height = value;}, (IBinding data) => (data as Dimensions).Height )},
			{ "temperatureMin", new PropertyReal64 ("temperatureMin", 
					(IBinding data, double? value) => {(data as Dimensions).TemperatureMin = value;}, (IBinding data) => (data as Dimensions).TemperatureMin )},
			{ "temperatureMax", new PropertyReal64 ("temperatureMax", 
					(IBinding data, double? value) => {(data as Dimensions).TemperatureMax = value;}, (IBinding data) => (data as Dimensions).TemperatureMax )}
        }, __Tag,() => new Dimensions(), () => new List<Dimensions>(), () => new Dictionary<string,Dimensions>(),null);

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
	public new const string __Tag = "Dimensions";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Dimensions();


    /* 
    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Dimensions FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Dimensions;
			}
		var Result = new Dimensions ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}
	*/

	}



