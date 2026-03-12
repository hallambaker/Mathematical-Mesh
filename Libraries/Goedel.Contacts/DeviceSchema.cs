
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
//  This file was automatically generated at 3/12/2026 2:25:03 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
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

#pragma warning disable IDE0079 // Don't warn about unnecessary suppressions
#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
#pragma warning disable IDE1006 // Ignore naming rule violations
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsDevice), JsDevice._binding},
	    {typeof(Network), Network._binding},
	    {typeof(NetworkPhysical), NetworkPhysical._binding},
	    {typeof(NetworkEthernet), NetworkEthernet._binding},
	    {typeof(NetworkWiFi), NetworkWiFi._binding},
	    {typeof(Maintenance), Maintenance._binding},
	    {typeof(Supplier), Supplier._binding},
	    {typeof(RelatedItem), RelatedItem._binding},
	    {typeof(Component), Component._binding},
	    {typeof(Dimensions), Dimensions._binding},
	    {typeof(JsProvision), JsProvision._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Devices() {
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
	///  Metadata, 
	/// </summary>
public partial class JsDevice : JmapBase {
    /// <summary>
    ///The JSDevice version of this description. The value MUST be one 
    ///of the IANA-registered JSDevice Version values for the version property. 
    /// </summary>

	[JsonPropertyName("version")]
	public virtual string?					Version  {get; set;} //

    /// <summary>
    /// The kind of the entity described
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// The language tag, as defined in [RFC5646], that best describes the language 
    /// used for text in the description, optionally including additional information such 
    /// as the script. Note that values MAY be localized in the localizations 
    /// property.
    /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					Language  {get; set;} //

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
	public virtual Dictionary<string,JsDevice>?					Localizations  {get; set;} //

    /// <summary>
    /// A URI that uniquely identifies the device.
    /// </summary>

	[JsonPropertyName("deviceId")]
	public virtual string?					DeviceId  {get; set;} //

    /// <summary>
    /// A URI that uniquely identifies the device model.
    /// </summary>

	[JsonPropertyName("modelId")]
	public virtual string?					ModelId  {get; set;} //

    /// <summary>
    /// Human readable model name.
    /// </summary>

	[JsonPropertyName("modelName")]
	public virtual string?					ModelName  {get; set;} //

    /// <summary>
    /// Device manufacturer name.
    /// </summary>

	[JsonPropertyName("manufacturer")]
	public virtual string?					Manufacturer  {get; set;} //

    /// <summary>
    /// Date of manufacture.
    /// </summary>

	[JsonPropertyName("dateManufacture")]
	public virtual DateTime?					DateManufacture  {get; set;} //

    /// <summary>
    /// Date at which support for the device is scheduled to end.
    /// </summary>

	[JsonPropertyName("endSupport")]
	public virtual DateTime?					EndSupport  {get; set;} //

    /// <summary>
    /// Date at which it is advised the device be taken out of service.
    /// </summary>

	[JsonPropertyName("endLife")]
	public virtual DateTime?					EndLife  {get; set;} //

    /// <summary>
    ///The physical components making up the device and their dimensions.
    /// </summary>

	[JsonPropertyName("components")]
	public virtual Dictionary<string,Component>?					Components  {get; set;} //

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
	public virtual Dictionary<string,Maintenance>?					Maintenance  {get; set;} //

    /// <summary>
    /// Accessories, parts and consumables related to the device. 
    ///For example, ink cartridges, parts likely to wear etc.
    /// </summary>

	[JsonPropertyName("relatedItems")]
	public virtual Dictionary<string,RelatedItem>?					RelatedItems  {get; set;} //

    /// <summary>
    /// The network services supported.
    /// </summary>

	[JsonPropertyName("services")]
	public virtual Dictionary<string,Network>?					Services  {get; set;} //

    /// <summary>
    /// The physical network connections supported.
    /// </summary>

	[JsonPropertyName("network")]
	public virtual Dictionary<string,NetworkPhysical>?					Network  {get; set;} //

    /// <summary>
    /// The cryptographic resources such as public keys and certificates associated 
    /// with the device
    /// The CryptoKey object is defined in JSContact and JSContact Cryptographic Extensions.
    /// </summary>

	[JsonPropertyName("cryptoKeys")]
	public virtual Dictionary<string,CryptoKey>?					CryptoKeys  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("version", 
					(data, value) => {(data as JsDevice).Version = value;}, 
					data => (data as JsDevice).Version ),
		new PropertyString ("kind", 
					(data, value) => {(data as JsDevice).Kind = value;}, 
					data => (data as JsDevice).Kind ),
		new PropertyString ("language", 
					(data, value) => {(data as JsDevice).Language = value;}, 
					data => (data as JsDevice).Language ),
		new PropertyDictionaryStruct ("localizations", typeof (JsDevice),
					(data, value) => {(data as JsDevice).Localizations = value as Dictionary<string,JsDevice>;}, 
					data => (data as JsDevice).Localizations,
					false, ()=>new  Dictionary<string,JsDevice>(), ()=>new JsDevice(),
					data => (data as JsDevice).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsDevice>).Add (key as string,value as JsDevice);}),
		new PropertyString ("deviceId", 
					(data, value) => {(data as JsDevice).DeviceId = value;}, 
					data => (data as JsDevice).DeviceId ),
		new PropertyString ("modelId", 
					(data, value) => {(data as JsDevice).ModelId = value;}, 
					data => (data as JsDevice).ModelId ),
		new PropertyString ("modelName", 
					(data, value) => {(data as JsDevice).ModelName = value;}, 
					data => (data as JsDevice).ModelName ),
		new PropertyString ("manufacturer", 
					(data, value) => {(data as JsDevice).Manufacturer = value;}, 
					data => (data as JsDevice).Manufacturer ),
		new PropertyDateTime ("dateManufacture", 
					(data, value) => {(data as JsDevice).DateManufacture = value;}, 
					data => (data as JsDevice).DateManufacture ),
		new PropertyDateTime ("endSupport", 
					(data, value) => {(data as JsDevice).EndSupport = value;}, 
					data => (data as JsDevice).EndSupport ),
		new PropertyDateTime ("endLife", 
					(data, value) => {(data as JsDevice).EndLife = value;}, 
					data => (data as JsDevice).EndLife ),
		new PropertyDictionaryStruct ("components", typeof (Component),
					(data, value) => {(data as JsDevice).Components = value as Dictionary<string,Component>;}, 
					data => (data as JsDevice).Components,
					false, ()=>new  Dictionary<string,Component>(), ()=>new Component(),
					data => (data as JsDevice).Components.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Component>).Add (key as string,value as Component);}),
		new PropertyListStruct ("images", typeof (Media),
					(data, value) => {(data as JsDevice).Images = value as List<Media>;}, 
					data => (data as JsDevice).Images,
					false, ()=>new  List<Media>(), ()=>new Media()),
		new PropertyListStruct ("documentation", typeof (Media),
					(data, value) => {(data as JsDevice).Documentation = value as List<Media>;}, 
					data => (data as JsDevice).Documentation,
					false, ()=>new  List<Media>(), ()=>new Media()),
		new PropertyListStruct ("suppliers", typeof (Supplier),
					(data, value) => {(data as JsDevice).Suppliers = value as List<Supplier>;}, 
					data => (data as JsDevice).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier()),
		new PropertyDictionaryStruct ("maintenance", typeof (Maintenance),
					(data, value) => {(data as JsDevice).Maintenance = value as Dictionary<string,Maintenance>;}, 
					data => (data as JsDevice).Maintenance,
					false, ()=>new  Dictionary<string,Maintenance>(), ()=>new Maintenance(),
					data => (data as JsDevice).Maintenance.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Maintenance>).Add (key as string,value as Maintenance);}),
		new PropertyDictionaryStruct ("relatedItems", typeof (RelatedItem),
					(data, value) => {(data as JsDevice).RelatedItems = value as Dictionary<string,RelatedItem>;}, 
					data => (data as JsDevice).RelatedItems,
					false, ()=>new  Dictionary<string,RelatedItem>(), ()=>new RelatedItem(),
					data => (data as JsDevice).RelatedItems.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,RelatedItem>).Add (key as string,value as RelatedItem);}),
		new PropertyDictionaryStruct ("services", typeof (Network),
					(data, value) => {(data as JsDevice).Services = value as Dictionary<string,Network>;}, 
					data => (data as JsDevice).Services,
					false, ()=>new  Dictionary<string,Network>(), ()=>new Network(),
					data => (data as JsDevice).Services.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Network>).Add (key as string,value as Network);}),
		new PropertyDictionaryStruct ("network", typeof (NetworkPhysical),
					(data, value) => {(data as JsDevice).Network = value as Dictionary<string,NetworkPhysical>;}, 
					data => (data as JsDevice).Network,
					false, ()=>new  Dictionary<string,NetworkPhysical>(), ()=>new NetworkPhysical(),
					data => (data as JsDevice).Network.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,NetworkPhysical>).Add (key as string,value as NetworkPhysical);}),
		new PropertyDictionaryStruct ("cryptoKeys", typeof (CryptoKey),
					(data, value) => {(data as JsDevice).CryptoKeys = value as Dictionary<string,CryptoKey>;}, 
					data => (data as JsDevice).CryptoKeys,
					false, ()=>new  Dictionary<string,CryptoKey>(), ()=>new CryptoKey(),
					data => (data as JsDevice).CryptoKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,CryptoKey>).Add (key as string,value as CryptoKey);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsDevice> _binding = new (
			new() {
			{ "version", _properties [0]},
			{ "kind", _properties [1]},
			{ "language", _properties [2]},
			{ "localizations", _properties [3]},
			{ "deviceId", _properties [4]},
			{ "modelId", _properties [5]},
			{ "modelName", _properties [6]},
			{ "manufacturer", _properties [7]},
			{ "dateManufacture", _properties [8]},
			{ "endSupport", _properties [9]},
			{ "endLife", _properties [10]},
			{ "components", _properties [11]},
			{ "images", _properties [12]},
			{ "documentation", _properties [13]},
			{ "suppliers", _properties [14]},
			{ "maintenance", _properties [15]},
			{ "relatedItems", _properties [16]},
			{ "services", _properties [17]},
			{ "network", _properties [18]},
			{ "cryptoKeys", _properties [19]}}, __Tag,
		() => new JsDevice(), () => [], () => [], JmapBase._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Network : Devices {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// The network connection kind
    /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    ///The Internet Protocol Address(es)
    /// </summary>

	[JsonPropertyName("address")]
	public virtual List<string>?					Address  {get; set;}
    /// <summary>
    ///The IANA protocol identifier
    /// </summary>

	[JsonPropertyName("identifier")]
	public virtual string?					Identifier  {get; set;} //

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
	public virtual Dictionary<string,string>?					Keys  {get; set;} //

    /// <summary>
    ///Permission identifiers used to assign access rights to control of the
    ///device.
    /// </summary>

	[JsonPropertyName("permissions")]
	public virtual List<string>?					Permissions  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("@type", 
					(data, value) => {(data as Network).Type = value;}, 
					data => (data as Network).Type ),
		new PropertyString ("kind", 
					(data, value) => {(data as Network).Kind = value;}, 
					data => (data as Network).Kind ),
		new PropertyListString ("address", 
					(data, value) => {(data as Network).Address = value;}, 
					data => (data as Network).Address ),
		new PropertyString ("identifier", 
					(data, value) => {(data as Network).Identifier = value;}, 
					data => (data as Network).Identifier ),
		new PropertyListInteger32 ("ports", 
					(data, value) => {(data as Network).Ports = value;}, 
					data => (data as Network).Ports ),
		new PropertyListString ("endpoints", 
					(data, value) => {(data as Network).Endpoints = value;}, 
					data => (data as Network).Endpoints ),
		new PropertyDictionaryString ("keys", 
					(data, value) => {(data as Network).Keys = value;}, 
					data => (data as Network).Keys ),
		new PropertyListString ("permissions", 
					(data, value) => {(data as Network).Permissions = value;}, 
					data => (data as Network).Permissions )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Network> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "kind", _properties [1]},
			{ "address", _properties [2]},
			{ "identifier", _properties [3]},
			{ "ports", _properties [4]},
			{ "endpoints", _properties [5]},
			{ "keys", _properties [6]},
			{ "permissions", _properties [7]}}, __Tag,
		() => new Network(), () => [], () => [], null, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "network";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Network();

	}


	/// <summary>
	/// </summary>
public partial class NetworkPhysical : Network {
    /// <summary>
    /// </summary>

	[JsonPropertyName("eUI")]
	public virtual string?					EUI  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("speed")]
	public virtual string?					Speed  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("eUI", 
					(data, value) => {(data as NetworkPhysical).EUI = value;}, 
					data => (data as NetworkPhysical).EUI ),
		new PropertyString ("speed", 
					(data, value) => {(data as NetworkPhysical).Speed = value;}, 
					data => (data as NetworkPhysical).Speed )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkPhysical> _binding = new (
			new() {
			{ "eUI", _properties [0]},
			{ "speed", _properties [1]}}, __Tag,
		() => new NetworkPhysical(), () => [], () => [], Network._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "network";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkPhysical();

	}


	/// <summary>
	/// </summary>
public partial class NetworkEthernet : NetworkPhysical {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkEthernet> _binding = new (
			new() {}, __Tag,
		() => new NetworkEthernet(), () => [], () => [], NetworkPhysical._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "networkEthernet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkEthernet();

	}


	/// <summary>
	/// </summary>
public partial class NetworkWiFi : NetworkPhysical {
    /// <summary>
    /// </summary>

	[JsonPropertyName("sSID")]
	public virtual string?					SSID  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("username")]
	public virtual string?					Username  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("password")]
	public virtual string?					Password  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("sSID", 
					(data, value) => {(data as NetworkWiFi).SSID = value;}, 
					data => (data as NetworkWiFi).SSID ),
		new PropertyString ("username", 
					(data, value) => {(data as NetworkWiFi).Username = value;}, 
					data => (data as NetworkWiFi).Username ),
		new PropertyString ("password", 
					(data, value) => {(data as NetworkWiFi).Password = value;}, 
					data => (data as NetworkWiFi).Password )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkWiFi> _binding = new (
			new() {
			{ "sSID", _properties [0]},
			{ "username", _properties [1]},
			{ "password", _properties [2]}}, __Tag,
		() => new NetworkWiFi(), () => [], () => [], NetworkPhysical._binding, 
		TypeTag:"@type" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "networkWiFi";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkWiFi();

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
	public virtual bool?					Recurring  {get; set;} //

    /// <summary>
    /// Interval days.
    /// </summary>

	[JsonPropertyName("days")]
	public virtual int?					Days  {get; set;} //

    /// <summary>
    /// Interval months. If specified, the days property is ignored.
    /// </summary>

	[JsonPropertyName("months")]
	public virtual int?					Months  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("recurring", 
					(data, value) => {(data as Maintenance).Recurring = value;}, 
					data => (data as Maintenance).Recurring ),
		new PropertyInteger32 ("days", 
					(data, value) => {(data as Maintenance).Days = value;}, 
					data => (data as Maintenance).Days ),
		new PropertyInteger32 ("months", 
					(data, value) => {(data as Maintenance).Months = value;}, 
					data => (data as Maintenance).Months )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Maintenance> _binding = new (
			new() {
			{ "recurring", _properties [0]},
			{ "days", _properties [1]},
			{ "months", _properties [2]}}, __Tag,
		() => new Maintenance(), () => [], () => [], Resource._binding, Generic: false);


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

	}


	/// <summary>
	///
	///  Suppliers for devices and accessories related to the device.
	/// </summary>
public partial class Supplier : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Supplier> _binding = new (
			new() {}, __Tag,
		() => new Supplier(), () => [], () => [], Resource._binding, Generic: false);


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
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("modelId", 
					(data, value) => {(data as RelatedItem).ModelId = value;}, 
					data => (data as RelatedItem).ModelId ),
		new PropertyListStruct ("suppliers", typeof (Supplier),
					(data, value) => {(data as RelatedItem).Suppliers = value as List<Supplier>;}, 
					data => (data as RelatedItem).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RelatedItem> _binding = new (
			new() {
			{ "modelId", _properties [0]},
			{ "suppliers", _properties [1]}}, __Tag,
		() => new RelatedItem(), () => [], () => [], Resource._binding, Generic: false);


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
	public virtual Dictionary<string,Dimensions>?					Dimensions  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDictionaryStruct ("dimensions", typeof (Dimensions),
					(data, value) => {(data as Component).Dimensions = value as Dictionary<string,Dimensions>;}, 
					data => (data as Component).Dimensions,
					false, ()=>new  Dictionary<string,Dimensions>(), ()=>new Dimensions(),
					data => (data as Component).Dimensions.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Dimensions>).Add (key as string,value as Dimensions);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Component> _binding = new (
			new() {
			{ "dimensions", _properties [0]}}, __Tag,
		() => new Component(), () => [], () => [], Resource._binding, Generic: false);


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
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    ///The weight of the component in kilograms
    /// </summary>

	[JsonPropertyName("weight")]
	public virtual double?					Weight  {get; set;} //

    /// <summary>
    ///The width of the component in meters
    /// </summary>

	[JsonPropertyName("width")]
	public virtual double?					Width  {get; set;} //

    /// <summary>
    ///The depth of the component in meters
    /// </summary>

	[JsonPropertyName("depth")]
	public virtual double?					Depth  {get; set;} //

    /// <summary>
    ///The height of the component in meters
    /// </summary>

	[JsonPropertyName("height")]
	public virtual double?					Height  {get; set;} //

    /// <summary>
    ///The minimum temperature for the device
    /// </summary>

	[JsonPropertyName("temperatureMin")]
	public virtual double?					TemperatureMin  {get; set;} //

    /// <summary>
    ///The maximum temperature for the device
    /// </summary>

	[JsonPropertyName("temperatureMax")]
	public virtual double?					TemperatureMax  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("kind", 
					(data, value) => {(data as Dimensions).Kind = value;}, 
					data => (data as Dimensions).Kind ),
		new PropertyReal64 ("weight", 
					(data, value) => {(data as Dimensions).Weight = value;}, 
					data => (data as Dimensions).Weight ),
		new PropertyReal64 ("width", 
					(data, value) => {(data as Dimensions).Width = value;}, 
					data => (data as Dimensions).Width ),
		new PropertyReal64 ("depth", 
					(data, value) => {(data as Dimensions).Depth = value;}, 
					data => (data as Dimensions).Depth ),
		new PropertyReal64 ("height", 
					(data, value) => {(data as Dimensions).Height = value;}, 
					data => (data as Dimensions).Height ),
		new PropertyReal64 ("temperatureMin", 
					(data, value) => {(data as Dimensions).TemperatureMin = value;}, 
					data => (data as Dimensions).TemperatureMin ),
		new PropertyReal64 ("temperatureMax", 
					(data, value) => {(data as Dimensions).TemperatureMax = value;}, 
					data => (data as Dimensions).TemperatureMax )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Dimensions> _binding = new (
			new() {
			{ "kind", _properties [0]},
			{ "weight", _properties [1]},
			{ "width", _properties [2]},
			{ "depth", _properties [3]},
			{ "height", _properties [4]},
			{ "temperatureMin", _properties [5]},
			{ "temperatureMax", _properties [6]}}, __Tag,
		() => new Dimensions(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Configuration file used to initialize a device. It is simply a JSDevice configuration 
	/// with an additional seed.
	/// </summary>
public partial class JsProvision : Devices {
    /// <summary>
    ///The device description. This contains all the information the device
    ///requires that isn't private.
    /// </summary>

	[JsonPropertyName("jsDevice")]
	public virtual JsDevice?					JsDevice  {get; set;} //

    /// <summary>
    ///The device private key seed.
    /// </summary>

	[JsonPropertyName("privateKeys")]
	public virtual Dictionary<string,CryptoKey>?					PrivateKeys  {get; set;} //

    /// <summary>
    ///Public EARL value that can be sent to the device owner in advance of the device
    ///itself being available, thus enabling the owner to configure network infrastructure
    ///to pre-authorize onboarding.
    /// </summary>

	[JsonPropertyName("deviceNotPresentEarl")]
	public virtual string?					DeviceNotPresentEarl  {get; set;} //

    /// <summary>
    ///Private EARL value providing proof of holdership of the physical device itself.
    ///This would typically be printed on the device or its packaging as a QR code.
    /// </summary>

	[JsonPropertyName("devicePresentEarl")]
	public virtual string?					DevicePresentEarl  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("jsDevice", typeof (JsDevice),
					(data, value) => {(data as JsProvision).JsDevice = value as JsDevice;}, 
					data => (data as JsProvision).JsDevice,
					false, ()=>new  JsDevice(), ()=>new JsDevice()),
		new PropertyDictionaryStruct ("privateKeys", typeof (CryptoKey),
					(data, value) => {(data as JsProvision).PrivateKeys = value as Dictionary<string,CryptoKey>;}, 
					data => (data as JsProvision).PrivateKeys,
					false, ()=>new  Dictionary<string,CryptoKey>(), ()=>new CryptoKey(),
					data => (data as JsProvision).PrivateKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,CryptoKey>).Add (key as string,value as CryptoKey);}),
		new PropertyString ("deviceNotPresentEarl", 
					(data, value) => {(data as JsProvision).DeviceNotPresentEarl = value;}, 
					data => (data as JsProvision).DeviceNotPresentEarl ),
		new PropertyString ("devicePresentEarl", 
					(data, value) => {(data as JsProvision).DevicePresentEarl = value;}, 
					data => (data as JsProvision).DevicePresentEarl )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsProvision> _binding = new (
			new() {
			{ "jsDevice", _properties [0]},
			{ "privateKeys", _properties [1]},
			{ "deviceNotPresentEarl", _properties [2]},
			{ "devicePresentEarl", _properties [3]}}, __Tag,
		() => new JsProvision(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsProvision";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsProvision();

	}



