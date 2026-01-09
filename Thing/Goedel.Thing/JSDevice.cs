
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
//  This file was automatically generated at 1/9/2026 3:47:24 PM
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

#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Thing;


	/// <summary>
	/// </summary>
public abstract partial class ThingDevice : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ThingDevice";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsDevice), JsDevice._binding},
	    {typeof(Resource), Resource._binding},
	    {typeof(DeviceCredential), DeviceCredential._binding},
	    {typeof(DeviceImage), DeviceImage._binding},
	    {typeof(Service), Service._binding},
	    {typeof(Physical), Physical._binding},
	    {typeof(Storage), Storage._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static ThingDevice() {
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
	/// Describes a device
	/// </summary>
public partial class JsDevice : ThingDevice {
    /// <summary>
    ///The name of the device
    /// </summary>

	[JsonPropertyName("ModelName")]
	public virtual string?					ModelName  {get; set;} //

    /// <summary>
    ///Short string giving the type of device for naming purposes, e.g. 
    ///'camera'
    /// </summary>

	[JsonPropertyName("NameHint")]
	public virtual string?					NameHint  {get; set;} //

    /// <summary>
    ///The model serial identifier
    /// </summary>

	[JsonPropertyName("ModelSerial")]
	public virtual string?					ModelSerial  {get; set;} //

    /// <summary>
    ///The device serial identifier. 
    /// </summary>

	[JsonPropertyName("DeviceSerial")]
	public virtual string?					DeviceSerial  {get; set;} //

    /// <summary>
    ///Globally unique device identifier
    /// </summary>

	[JsonPropertyName("DeviceIdentifier")]
	public virtual string?					DeviceIdentifier  {get; set;} //

    /// <summary>
    ///Name of the manufacturer
    /// </summary>

	[JsonPropertyName("Manufacturer")]
	public virtual string?					Manufacturer  {get; set;} //

    /// <summary>
    ///Country of Origin as ISO 2 letter country code.
    /// </summary>

	[JsonPropertyName("CountryOfOrigin")]
	public virtual string?					CountryOfOrigin  {get; set;} //

    /// <summary>
    ///Datge of manufacture in UTC.
    /// </summary>

	[JsonPropertyName("Manufactured")]
	public virtual DateTime?					Manufactured  {get; set;} //

    /// <summary>
    ///The set of services the device offers, e.g. SSH access, 
    ///http/https access, etc.
    /// </summary>

	[JsonPropertyName("OfferedServices")]
	public virtual List<Service>?					OfferedServices  {get; set;}
    /// <summary>
    ///The set of services the device consumes, e.g. file storage,
    ///DNS, WebPKI administration
    /// </summary>

	[JsonPropertyName("UsedServices")]
	public virtual List<Service>?					UsedServices  {get; set;}
    /// <summary>
    ///A list of images showing the device in order of relevance. The images need 
    ///not be picttures of the specific device shown but SHOULD be representative.
    /// </summary>

	[JsonPropertyName("Images")]
	public virtual List<DeviceImage>?					Images  {get; set;}
    /// <summary>
    ///List of physical network media supported by the device, e.g.
    ///Ethernet, WiFi, USB-C, etc.
    /// </summary>

	[JsonPropertyName("Physical")]
	public virtual List<Physical>?					Physical  {get; set;}
    /// <summary>
    ///Describes off-device storage requirements
    /// </summary>

	[JsonPropertyName("Storage")]
	public virtual List<Storage>?					Storage  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ModelName", 
					(data, value) => {(data as JsDevice).ModelName = value;}, 
					data => (data as JsDevice).ModelName ),
		new PropertyString ("NameHint", 
					(data, value) => {(data as JsDevice).NameHint = value;}, 
					data => (data as JsDevice).NameHint ),
		new PropertyString ("ModelSerial", 
					(data, value) => {(data as JsDevice).ModelSerial = value;}, 
					data => (data as JsDevice).ModelSerial ),
		new PropertyString ("DeviceSerial", 
					(data, value) => {(data as JsDevice).DeviceSerial = value;}, 
					data => (data as JsDevice).DeviceSerial ),
		new PropertyString ("DeviceIdentifier", 
					(data, value) => {(data as JsDevice).DeviceIdentifier = value;}, 
					data => (data as JsDevice).DeviceIdentifier ),
		new PropertyString ("Manufacturer", 
					(data, value) => {(data as JsDevice).Manufacturer = value;}, 
					data => (data as JsDevice).Manufacturer ),
		new PropertyString ("CountryOfOrigin", 
					(data, value) => {(data as JsDevice).CountryOfOrigin = value;}, 
					data => (data as JsDevice).CountryOfOrigin ),
		new PropertyDateTime ("Manufactured", 
					(data, value) => {(data as JsDevice).Manufactured = value;}, 
					data => (data as JsDevice).Manufactured ),
		new PropertyListStruct ("OfferedServices", typeof (Service),
					(data, value) => {(data as JsDevice).OfferedServices = value as List<Service>;}, 
					data => (data as JsDevice).OfferedServices,
					false, ()=>new  List<Service>(), ()=>new Service()),
		new PropertyListStruct ("UsedServices", typeof (Service),
					(data, value) => {(data as JsDevice).UsedServices = value as List<Service>;}, 
					data => (data as JsDevice).UsedServices,
					false, ()=>new  List<Service>(), ()=>new Service()),
		new PropertyListStruct ("Images", typeof (DeviceImage),
					(data, value) => {(data as JsDevice).Images = value as List<DeviceImage>;}, 
					data => (data as JsDevice).Images,
					false, ()=>new  List<DeviceImage>(), ()=>new DeviceImage()),
		new PropertyListStruct ("Physical", typeof (Physical),
					(data, value) => {(data as JsDevice).Physical = value as List<Physical>;}, 
					data => (data as JsDevice).Physical,
					false, ()=>new  List<Physical>(), ()=>new Physical()),
		new PropertyListStruct ("Storage", typeof (Storage),
					(data, value) => {(data as JsDevice).Storage = value as List<Storage>;}, 
					data => (data as JsDevice).Storage,
					false, ()=>new  List<Storage>(), ()=>new Storage())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsDevice> _binding = new (
			new() {
			{ "ModelName", _properties [0]},
			{ "NameHint", _properties [1]},
			{ "ModelSerial", _properties [2]},
			{ "DeviceSerial", _properties [3]},
			{ "DeviceIdentifier", _properties [4]},
			{ "Manufacturer", _properties [5]},
			{ "CountryOfOrigin", _properties [6]},
			{ "Manufactured", _properties [7]},
			{ "OfferedServices", _properties [8]},
			{ "UsedServices", _properties [9]},
			{ "Images", _properties [10]},
			{ "Physical", _properties [11]},
			{ "Storage", _properties [12]}}, __Tag,
		() => new JsDevice(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsDevice();

	}


	/// <summary>
	/// </summary>
public partial class Resource : ThingDevice {
    /// <summary>
    ///IANA media type for the resource.
    /// </summary>

	[JsonPropertyName("MediaType")]
	public virtual string?					MediaType  {get; set;} //

    /// <summary>
    ///Uri from which the resource can be fetched
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    ///The resource as Base64 encoded binary data.
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("MediaType", 
					(data, value) => {(data as Resource).MediaType = value;}, 
					data => (data as Resource).MediaType ),
		new PropertyString ("Uri", 
					(data, value) => {(data as Resource).Uri = value;}, 
					data => (data as Resource).Uri ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as Resource).Data = value;}, 
					data => (data as Resource).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Resource> _binding = new (
			new() {
			{ "MediaType", _properties [0]},
			{ "Uri", _properties [1]},
			{ "Data", _properties [2]}}, __Tag,
		() => new Resource(), () => [], () => [], null, Generic: false);


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
	/// </summary>
public partial class DeviceCredential : Resource {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceCredential> _binding = new (
			new() {}, __Tag,
		() => new DeviceCredential(), () => [], () => [], Resource._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "credential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceCredential();

	}


	/// <summary>
	/// </summary>
public partial class DeviceImage : Resource {
    /// <summary>
    ///Indication of the side being shown, e.g. 'front', 'left', 'right', 
    ///'rear', 'top', 'bottom'. Sides MAY be combined to indicate isometric views
    ///e.g. 'front-right-top'
    /// </summary>

	[JsonPropertyName("View")]
	public virtual string?					View  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("View", 
					(data, value) => {(data as DeviceImage).View = value;}, 
					data => (data as DeviceImage).View )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceImage> _binding = new (
			new() {
			{ "View", _properties [0]}}, __Tag,
		() => new DeviceImage(), () => [], () => [], Resource._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "image";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceImage();

	}


	/// <summary>
	/// </summary>
public partial class Service : ThingDevice {
    /// <summary>
    ///IANA protocol name
    /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    ///The service provision of this service requires to provide
    /// </summary>

	[JsonPropertyName("Requires")]
	public virtual List<string>?					Requires  {get; set;}
    /// <summary>
    ///Service profiles supported, these MAY be protocol versions or a string
    ///registered to represent a specific set of capabilities.
    /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<string>?					Profiles  {get; set;}
    /// <summary>
    ///The service transports supported, e.g TCP, TLS, UDP, QUIC, HTTP, HTTPS,
    ///COAP.
    /// </summary>

	[JsonPropertyName("Transports")]
	public virtual List<string>?					Transports  {get; set;}
    /// <summary>
    ///List of credentials to be used in conjunction with the service.
    ///Note that credentials supplied by the device manufacturer SHOULD NOT
    ///be used for any purpose other than establishing secure credentials
    ///for production use.
    /// </summary>

	[JsonPropertyName("Credentials")]
	public virtual List<DeviceCredential>?					Credentials  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Name", 
					(data, value) => {(data as Service).Name = value;}, 
					data => (data as Service).Name ),
		new PropertyListString ("Requires", 
					(data, value) => {(data as Service).Requires = value;}, 
					data => (data as Service).Requires ),
		new PropertyListString ("Profiles", 
					(data, value) => {(data as Service).Profiles = value;}, 
					data => (data as Service).Profiles ),
		new PropertyListString ("Transports", 
					(data, value) => {(data as Service).Transports = value;}, 
					data => (data as Service).Transports ),
		new PropertyListStruct ("Credentials", typeof (DeviceCredential),
					(data, value) => {(data as Service).Credentials = value as List<DeviceCredential>;}, 
					data => (data as Service).Credentials,
					false, ()=>new  List<DeviceCredential>(), ()=>new DeviceCredential())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Service> _binding = new (
			new() {
			{ "Name", _properties [0]},
			{ "Requires", _properties [1]},
			{ "Profiles", _properties [2]},
			{ "Transports", _properties [3]},
			{ "Credentials", _properties [4]}}, __Tag,
		() => new Service(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Physical : ThingDevice {
    /// <summary>
    ///The media type name
    /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    ///Identifier used by the device under that protocol, e.g. an EUI-48
    ///or EUI-64 media access control address.
    /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;} //

    /// <summary>
    ///Media profiles supported as specified by the media type.
    /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<string>?					Profiles  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Name", 
					(data, value) => {(data as Physical).Name = value;}, 
					data => (data as Physical).Name ),
		new PropertyString ("Identifier", 
					(data, value) => {(data as Physical).Identifier = value;}, 
					data => (data as Physical).Identifier ),
		new PropertyListString ("Profiles", 
					(data, value) => {(data as Physical).Profiles = value;}, 
					data => (data as Physical).Profiles )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Physical> _binding = new (
			new() {
			{ "Name", _properties [0]},
			{ "Identifier", _properties [1]},
			{ "Profiles", _properties [2]}}, __Tag,
		() => new Physical(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Physical";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Physical();

	}


	/// <summary>
	/// </summary>
public partial class Storage : ThingDevice {
    /// <summary>
    ///The purpose of this storage type
    /// </summary>

	[JsonPropertyName("Purpose")]
	public virtual string?					Purpose  {get; set;} //

    /// <summary>
    ///Typical storage requirement in kilobytes
    /// </summary>

	[JsonPropertyName("TypicalUse")]
	public virtual int?					TypicalUse  {get; set;} //

    /// <summary>
    ///Typical storage requirement in kilobytes
    /// </summary>

	[JsonPropertyName("TypicalAnnual")]
	public virtual int?					TypicalAnnual  {get; set;} //

    /// <summary>
    ///The set of data storage protocols the device can use
    /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<Service>?					Services  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Purpose", 
					(data, value) => {(data as Storage).Purpose = value;}, 
					data => (data as Storage).Purpose ),
		new PropertyInteger32 ("TypicalUse", 
					(data, value) => {(data as Storage).TypicalUse = value;}, 
					data => (data as Storage).TypicalUse ),
		new PropertyInteger32 ("TypicalAnnual", 
					(data, value) => {(data as Storage).TypicalAnnual = value;}, 
					data => (data as Storage).TypicalAnnual ),
		new PropertyListStruct ("Services", typeof (Service),
					(data, value) => {(data as Storage).Services = value as List<Service>;}, 
					data => (data as Storage).Services,
					false, ()=>new  List<Service>(), ()=>new Service())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Storage> _binding = new (
			new() {
			{ "Purpose", _properties [0]},
			{ "TypicalUse", _properties [1]},
			{ "TypicalAnnual", _properties [2]},
			{ "Services", _properties [3]}}, __Tag,
		() => new Storage(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Storage";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Storage();

	}



