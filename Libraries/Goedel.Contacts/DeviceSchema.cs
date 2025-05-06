
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
//  This file was automatically generated at 5/6/2025 12:30:58 AM
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
	    {"Protocol", Protocol._Factory},
	    {"Bootstrap", Bootstrap._Factory},
	    {"Provisioning", Provisioning._Factory},
	    {"Service", Service._Factory},
	    {"Maintenance", Maintenance._Factory},
	    {"Supplier", Supplier._Factory},
	    {"RelatedItem", RelatedItem._Factory},
	    {"Consumable", Consumable._Factory},
	    {"Accessory", Accessory._Factory}
		};


	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsDevice), JsDevice._binding},
	    {typeof(Protocol), Protocol._binding},
	    {typeof(Bootstrap), Bootstrap._binding},
	    {typeof(Provisioning), Provisioning._binding},
	    {typeof(Service), Service._binding},
	    {typeof(Maintenance), Maintenance._binding},
	    {typeof(Supplier), Supplier._binding},
	    {typeof(RelatedItem), RelatedItem._binding},
	    {typeof(Consumable), Consumable._binding},
	    {typeof(Accessory), Accessory._binding}
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
        /// Photographs and schematics of the device or model.
        /// </summary>

	[JsonPropertyName("images")]
	public virtual List<Media>?					Images  {get; set;}
        /// <summary>
        /// Manuals describing the device.
        /// </summary>

	[JsonPropertyName("manuals")]
	public virtual List<Media>?					Manuals  {get; set;}
        /// <summary>
        /// List of maintenance events associated with the device.
        /// </summary>

	[JsonPropertyName("maintenance")]
	public virtual List<Maintenance>?					Maintenance  {get; set;}
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
        /// Consumables related to the device. For example, ink cartridges, parts
        /// likely to wear etc.
        /// </summary>

	[JsonPropertyName("consumables")]
	public virtual List<Consumable>?					Consumables  {get; set;}
        /// <summary>
        /// Accessories related to the device. For example paper handlers.
        /// </summary>

	[JsonPropertyName("accessories")]
	public virtual List<Accessory>?					Accessories  {get; set;}
        /// <summary>
        /// Suppliers for the device and related accessories.
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}
        /// <summary>
        /// Bootstrap protocols supported.
        /// </summary>

	[JsonPropertyName("bootstraps")]
	public virtual List<Bootstrap>?					Bootstraps  {get; set;}
        /// <summary>
        /// Provisioning protocols supported for acquisition of DNS names, IP addresses,
        /// etc.
        /// </summary>

	[JsonPropertyName("provisioning")]
	public virtual List<Provisioning>?					Provisioning  {get; set;}
        /// <summary>
        /// Services supported by the device.
        /// </summary>

	[JsonPropertyName("services")]
	public virtual List<Service>?					Services  {get; set;}
        /// <summary>
        /// The cryptographic resources such as public keys and certificates associated 
        /// with the device
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
			{ "localizations", new PropertyDictionaryStruct ("localizations", typeof (JsDevice),
					(IBinding data, object? value) => {(data as JsDevice).Localizations = value as Dictionary<string,JsDevice>;}, (IBinding data) => (data as JsDevice).Localizations,
					false, ()=>new  Dictionary<string,JsDevice>(), ()=>new JsDevice(),
					(IBinding data) => (data as JsDevice).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsDevice>).Add (key as string,value as JsDevice);})},
			{ "images", new PropertyListStruct ("images", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Images = value as List<Media>;}, (IBinding data) => (data as JsDevice).Images,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "manuals", new PropertyListStruct ("manuals", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Manuals = value as List<Media>;}, (IBinding data) => (data as JsDevice).Manuals,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "maintenance", new PropertyListStruct ("maintenance", typeof (Maintenance),
					(IBinding data, object? value) => {(data as JsDevice).Maintenance = value as List<Maintenance>;}, (IBinding data) => (data as JsDevice).Maintenance,
					false, ()=>new  List<Maintenance>(), ()=>new Maintenance())},
			{ "endSupport", new PropertyDateTime ("endSupport", 
					(IBinding data, DateTime? value) => {(data as JsDevice).EndSupport = value;}, (IBinding data) => (data as JsDevice).EndSupport )},
			{ "endLife", new PropertyDateTime ("endLife", 
					(IBinding data, DateTime? value) => {(data as JsDevice).EndLife = value;}, (IBinding data) => (data as JsDevice).EndLife )},
			{ "consumables", new PropertyListStruct ("consumables", typeof (Consumable),
					(IBinding data, object? value) => {(data as JsDevice).Consumables = value as List<Consumable>;}, (IBinding data) => (data as JsDevice).Consumables,
					false, ()=>new  List<Consumable>(), ()=>new Consumable())},
			{ "accessories", new PropertyListStruct ("accessories", typeof (Accessory),
					(IBinding data, object? value) => {(data as JsDevice).Accessories = value as List<Accessory>;}, (IBinding data) => (data as JsDevice).Accessories,
					false, ()=>new  List<Accessory>(), ()=>new Accessory())},
			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as JsDevice).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as JsDevice).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())},
			{ "bootstraps", new PropertyListStruct ("bootstraps", typeof (Bootstrap),
					(IBinding data, object? value) => {(data as JsDevice).Bootstraps = value as List<Bootstrap>;}, (IBinding data) => (data as JsDevice).Bootstraps,
					false, ()=>new  List<Bootstrap>(), ()=>new Bootstrap())},
			{ "provisioning", new PropertyListStruct ("provisioning", typeof (Provisioning),
					(IBinding data, object? value) => {(data as JsDevice).Provisioning = value as List<Provisioning>;}, (IBinding data) => (data as JsDevice).Provisioning,
					false, ()=>new  List<Provisioning>(), ()=>new Provisioning())},
			{ "services", new PropertyListStruct ("services", typeof (Service),
					(IBinding data, object? value) => {(data as JsDevice).Services = value as List<Service>;}, (IBinding data) => (data as JsDevice).Services,
					false, ()=>new  List<Service>(), ()=>new Service())},
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


	}


	/// <summary>
	/// </summary>
public partial class Protocol : Devices {
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
        /// </summary>

	[JsonPropertyName("port")]
	public virtual int?					Port  {get; set;}

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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Protocol> _binding = new (
			new() {

			{ "address", new PropertyListString ("address", 
					(IBinding data, List<string>? value) => {(data as Protocol).Address = value;}, (IBinding data) => (data as Protocol).Address )},
			{ "identifier", new PropertyString ("identifier", 
					(IBinding data, string? value) => {(data as Protocol).Identifier = value;}, (IBinding data) => (data as Protocol).Identifier )},
			{ "port", new PropertyInteger32 ("port", 
					(IBinding data, int? value) => {(data as Protocol).Port = value;}, (IBinding data) => (data as Protocol).Port )},
			{ "endpoints", new PropertyListString ("endpoints", 
					(IBinding data, List<string>? value) => {(data as Protocol).Endpoints = value;}, (IBinding data) => (data as Protocol).Endpoints )},
			{ "keys", new PropertyDictionaryString ("keys", 
					(IBinding data, Dictionary<string,string>? value) => {(data as Protocol).Keys = value;}, (IBinding data) => (data as Protocol).Keys )}
        }, __Tag,() => new Protocol(), () => new List<Protocol>(), () => new Dictionary<string,Protocol>(),null);

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
	public new const string __Tag = "Protocol";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Protocol();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Protocol FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Protocol;
			}
		var Result = new Protocol ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  Bootstrap protocol configuration that MAY be used to provide initial
	///  network capabilities to the device.
	/// </summary>
public partial class Bootstrap : Protocol {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Bootstrap> _binding = new (
			new() {

        }, __Tag,() => new Bootstrap(), () => new List<Bootstrap>(), () => new Dictionary<string,Bootstrap>(),Protocol._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Protocol._binding, _binding);


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
	public new const string __Tag = "Bootstrap";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Bootstrap();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Bootstrap FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Bootstrap;
			}
		var Result = new Bootstrap ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  Provisioning protocol configuration that MAY be used to provision necessary
	/// network identifiers (e.g. Internet Addresses, DNS names, etc.)
	/// </summary>
public partial class Provisioning : Protocol {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Provisioning> _binding = new (
			new() {

        }, __Tag,() => new Provisioning(), () => new List<Provisioning>(), () => new Dictionary<string,Provisioning>(),Protocol._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Protocol._binding, _binding);


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
	public new const string __Tag = "Provisioning";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Provisioning();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Provisioning FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Provisioning;
			}
		var Result = new Provisioning ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  Service protocols supported by the device, e.g. 
	/// </summary>
public partial class Service : Protocol {
        /// <summary>
        /// </summary>

	[JsonPropertyName("permissions")]
	public virtual List<string>?					Permissions  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Service> _binding = new (
			new() {

			{ "permissions", new PropertyListString ("permissions", 
					(IBinding data, List<string>? value) => {(data as Service).Permissions = value;}, (IBinding data) => (data as Service).Permissions )}
        }, __Tag,() => new Service(), () => new List<Service>(), () => new Dictionary<string,Service>(),Protocol._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Protocol._binding, _binding);


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
	public new const string __Tag = "Service";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Service();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Service FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Service;
			}
		var Result = new Service ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  Maintenance events associated with the device.
	/// </summary>
public partial class Maintenance : Resource {
        /// <summary>
        /// If true (default), the mainenance event recurs as specified by the
        ///days, months and years properties. If false, the maintenance event 
        /// is a one-time operation occuring the specified interval after installation.
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


	}


	/// <summary>
	///
	///  A consumable compatible with the device.
	/// </summary>
public partial class Consumable : RelatedItem {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Consumable> _binding = new (
			new() {

        }, __Tag,() => new Consumable(), () => new List<Consumable>(), () => new Dictionary<string,Consumable>(),RelatedItem._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(RelatedItem._binding, _binding);


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
	public new const string __Tag = "Consumable";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Consumable();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Consumable FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Consumable;
			}
		var Result = new Consumable ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  An accessory compatible with the device.
	/// </summary>
public partial class Accessory : RelatedItem {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Accessory> _binding = new (
			new() {

        }, __Tag,() => new Accessory(), () => new List<Accessory>(), () => new Dictionary<string,Accessory>(),RelatedItem._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(RelatedItem._binding, _binding);


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
	public new const string __Tag = "Accessory";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Accessory();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Accessory FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Accessory;
			}
		var Result = new Accessory ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



