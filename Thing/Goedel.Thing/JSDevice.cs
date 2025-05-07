
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
//  This file was automatically generated at 5/7/2025 6:12:43 PM
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
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"JsDevice", JsDevice._Factory},
	    {"Resource", Resource._Factory},
	    {"credential", DeviceCredential._Factory},
	    {"image", DeviceImage._Factory},
	    {"Service", Service._Factory},
	    {"Physical", Physical._Factory},
	    {"Storage", Storage._Factory}
		};


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
	/// Describes a device
	/// </summary>
public partial class JsDevice : ThingDevice {
        /// <summary>
        ///The name of the device
        /// </summary>

	[JsonPropertyName("ModelName")]
	public virtual string?					ModelName  {get; set;}

        /// <summary>
        ///Short string giving the type of device for naming purposes, e.g. 
        ///'camera'
        /// </summary>

	[JsonPropertyName("NameHint")]
	public virtual string?					NameHint  {get; set;}

        /// <summary>
        ///The model serial identifier
        /// </summary>

	[JsonPropertyName("ModelSerial")]
	public virtual string?					ModelSerial  {get; set;}

        /// <summary>
        ///The device serial identifier. 
        /// </summary>

	[JsonPropertyName("DeviceSerial")]
	public virtual string?					DeviceSerial  {get; set;}

        /// <summary>
        ///Globally unique device identifier
        /// </summary>

	[JsonPropertyName("DeviceIdentifier")]
	public virtual string?					DeviceIdentifier  {get; set;}

        /// <summary>
        ///Name of the manufacturer
        /// </summary>

	[JsonPropertyName("Manufacturer")]
	public virtual string?					Manufacturer  {get; set;}

        /// <summary>
        ///Country of Origin as ISO 2 letter country code.
        /// </summary>

	[JsonPropertyName("CountryOfOrigin")]
	public virtual string?					CountryOfOrigin  {get; set;}

        /// <summary>
        ///Datge of manufacture in UTC.
        /// </summary>

	[JsonPropertyName("Manufactured")]
	public virtual DateTime?					Manufactured  {get; set;}

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
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsDevice> _binding = new (
			new() {

			{ "ModelName", new PropertyString ("ModelName", 
					(IBinding data, string? value) => {(data as JsDevice).ModelName = value;}, (IBinding data) => (data as JsDevice).ModelName )},
			{ "NameHint", new PropertyString ("NameHint", 
					(IBinding data, string? value) => {(data as JsDevice).NameHint = value;}, (IBinding data) => (data as JsDevice).NameHint )},
			{ "ModelSerial", new PropertyString ("ModelSerial", 
					(IBinding data, string? value) => {(data as JsDevice).ModelSerial = value;}, (IBinding data) => (data as JsDevice).ModelSerial )},
			{ "DeviceSerial", new PropertyString ("DeviceSerial", 
					(IBinding data, string? value) => {(data as JsDevice).DeviceSerial = value;}, (IBinding data) => (data as JsDevice).DeviceSerial )},
			{ "DeviceIdentifier", new PropertyString ("DeviceIdentifier", 
					(IBinding data, string? value) => {(data as JsDevice).DeviceIdentifier = value;}, (IBinding data) => (data as JsDevice).DeviceIdentifier )},
			{ "Manufacturer", new PropertyString ("Manufacturer", 
					(IBinding data, string? value) => {(data as JsDevice).Manufacturer = value;}, (IBinding data) => (data as JsDevice).Manufacturer )},
			{ "CountryOfOrigin", new PropertyString ("CountryOfOrigin", 
					(IBinding data, string? value) => {(data as JsDevice).CountryOfOrigin = value;}, (IBinding data) => (data as JsDevice).CountryOfOrigin )},
			{ "Manufactured", new PropertyDateTime ("Manufactured", 
					(IBinding data, DateTime? value) => {(data as JsDevice).Manufactured = value;}, (IBinding data) => (data as JsDevice).Manufactured )},
			{ "OfferedServices", new PropertyListStruct ("OfferedServices", typeof (Service),
					(IBinding data, object? value) => {(data as JsDevice).OfferedServices = value as List<Service>;}, (IBinding data) => (data as JsDevice).OfferedServices,
					false, ()=>new  List<Service>(), ()=>new Service())},
			{ "UsedServices", new PropertyListStruct ("UsedServices", typeof (Service),
					(IBinding data, object? value) => {(data as JsDevice).UsedServices = value as List<Service>;}, (IBinding data) => (data as JsDevice).UsedServices,
					false, ()=>new  List<Service>(), ()=>new Service())},
			{ "Images", new PropertyListStruct ("Images", typeof (DeviceImage),
					(IBinding data, object? value) => {(data as JsDevice).Images = value as List<DeviceImage>;}, (IBinding data) => (data as JsDevice).Images,
					false, ()=>new  List<DeviceImage>(), ()=>new DeviceImage())},
			{ "Physical", new PropertyListStruct ("Physical", typeof (Physical),
					(IBinding data, object? value) => {(data as JsDevice).Physical = value as List<Physical>;}, (IBinding data) => (data as JsDevice).Physical,
					false, ()=>new  List<Physical>(), ()=>new Physical())},
			{ "Storage", new PropertyListStruct ("Storage", typeof (Storage),
					(IBinding data, object? value) => {(data as JsDevice).Storage = value as List<Storage>;}, (IBinding data) => (data as JsDevice).Storage,
					false, ()=>new  List<Storage>(), ()=>new Storage())}
        }, __Tag,() => new JsDevice(), () => new List<JsDevice>(), () => new Dictionary<string,JsDevice>(),null);

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
	public new const string __Tag = "JsDevice";

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
public partial class Resource : ThingDevice {
        /// <summary>
        ///IANA media type for the resource.
        /// </summary>

	[JsonPropertyName("MediaType")]
	public virtual string?					MediaType  {get; set;}

        /// <summary>
        ///Uri from which the resource can be fetched
        /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}

        /// <summary>
        ///The resource as Base64 encoded binary data.
        /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Resource> _binding = new (
			new() {

			{ "MediaType", new PropertyString ("MediaType", 
					(IBinding data, string? value) => {(data as Resource).MediaType = value;}, (IBinding data) => (data as Resource).MediaType )},
			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as Resource).Uri = value;}, (IBinding data) => (data as Resource).Uri )},
			{ "Data", new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as Resource).Data = value;}, (IBinding data) => (data as Resource).Data )}
        }, __Tag,() => new Resource(), () => new List<Resource>(), () => new Dictionary<string,Resource>(),null);

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
	/// </summary>
public partial class DeviceCredential : Resource {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceCredential> _binding = new (
			new() {

        }, __Tag,() => new DeviceCredential(), () => new List<DeviceCredential>(), () => new Dictionary<string,DeviceCredential>(),Resource._binding);

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
	public new const string __Tag = "credential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DeviceCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DeviceCredential;
			}
		var Result = new DeviceCredential ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


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
	public virtual string?					View  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceImage> _binding = new (
			new() {

			{ "View", new PropertyString ("View", 
					(IBinding data, string? value) => {(data as DeviceImage).View = value;}, (IBinding data) => (data as DeviceImage).View )}
        }, __Tag,() => new DeviceImage(), () => new List<DeviceImage>(), () => new Dictionary<string,DeviceImage>(),Resource._binding);

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
	public new const string __Tag = "image";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceImage();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DeviceImage FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DeviceImage;
			}
		var Result = new DeviceImage ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Service : ThingDevice {
        /// <summary>
        ///IANA protocol name
        /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;}

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
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Service> _binding = new (
			new() {

			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Service).Name = value;}, (IBinding data) => (data as Service).Name )},
			{ "Requires", new PropertyListString ("Requires", 
					(IBinding data, List<string>? value) => {(data as Service).Requires = value;}, (IBinding data) => (data as Service).Requires )},
			{ "Profiles", new PropertyListString ("Profiles", 
					(IBinding data, List<string>? value) => {(data as Service).Profiles = value;}, (IBinding data) => (data as Service).Profiles )},
			{ "Transports", new PropertyListString ("Transports", 
					(IBinding data, List<string>? value) => {(data as Service).Transports = value;}, (IBinding data) => (data as Service).Transports )},
			{ "Credentials", new PropertyListStruct ("Credentials", typeof (DeviceCredential),
					(IBinding data, object? value) => {(data as Service).Credentials = value as List<DeviceCredential>;}, (IBinding data) => (data as Service).Credentials,
					false, ()=>new  List<DeviceCredential>(), ()=>new DeviceCredential())}
        }, __Tag,() => new Service(), () => new List<Service>(), () => new Dictionary<string,Service>(),null);

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
	/// </summary>
public partial class Physical : ThingDevice {
        /// <summary>
        ///The media type name
        /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;}

        /// <summary>
        ///Identifier used by the device under that protocol, e.g. an EUI-48
        ///or EUI-64 media access control address.
        /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;}

        /// <summary>
        ///Media profiles supported as specified by the media type.
        /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<string>?					Profiles  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Physical> _binding = new (
			new() {

			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Physical).Name = value;}, (IBinding data) => (data as Physical).Name )},
			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as Physical).Identifier = value;}, (IBinding data) => (data as Physical).Identifier )},
			{ "Profiles", new PropertyListString ("Profiles", 
					(IBinding data, List<string>? value) => {(data as Physical).Profiles = value;}, (IBinding data) => (data as Physical).Profiles )}
        }, __Tag,() => new Physical(), () => new List<Physical>(), () => new Dictionary<string,Physical>(),null);

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
	public new const string __Tag = "Physical";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Physical();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Physical FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Physical;
			}
		var Result = new Physical ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class Storage : ThingDevice {
        /// <summary>
        ///The purpose of this storage type
        /// </summary>

	[JsonPropertyName("Purpose")]
	public virtual string?					Purpose  {get; set;}

        /// <summary>
        ///Typical storage requirement in kilobytes
        /// </summary>

	[JsonPropertyName("TypicalUse")]
	public virtual int?					TypicalUse  {get; set;}

        /// <summary>
        ///Typical storage requirement in kilobytes
        /// </summary>

	[JsonPropertyName("TypicalAnnual")]
	public virtual int?					TypicalAnnual  {get; set;}

        /// <summary>
        ///The set of data storage protocols the device can use
        /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<Service>?					Services  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Storage> _binding = new (
			new() {

			{ "Purpose", new PropertyString ("Purpose", 
					(IBinding data, string? value) => {(data as Storage).Purpose = value;}, (IBinding data) => (data as Storage).Purpose )},
			{ "TypicalUse", new PropertyInteger32 ("TypicalUse", 
					(IBinding data, int? value) => {(data as Storage).TypicalUse = value;}, (IBinding data) => (data as Storage).TypicalUse )},
			{ "TypicalAnnual", new PropertyInteger32 ("TypicalAnnual", 
					(IBinding data, int? value) => {(data as Storage).TypicalAnnual = value;}, (IBinding data) => (data as Storage).TypicalAnnual )},
			{ "Services", new PropertyListStruct ("Services", typeof (Service),
					(IBinding data, object? value) => {(data as Storage).Services = value as List<Service>;}, (IBinding data) => (data as Storage).Services,
					false, ()=>new  List<Service>(), ()=>new Service())}
        }, __Tag,() => new Storage(), () => new List<Storage>(), () => new Dictionary<string,Storage>(),null);

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
	public new const string __Tag = "Storage";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Storage();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Storage FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Storage;
			}
		var Result = new Storage ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



