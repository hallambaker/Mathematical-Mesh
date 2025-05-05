
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
//  This file was automatically generated at 5/4/2025 5:41:08 PM
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
	    {"Network", Network._Factory},
	    {"Service", Service._Factory},
	    {"Maintenance", Maintenance._Factory},
	    {"MaintenanceEvent", MaintenanceEvent._Factory},
	    {"Consumable", Consumable._Factory},
	    {"Accessory", Accessory._Factory},
	    {"Supplier", Supplier._Factory}
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
	    {typeof(Network), Network._binding},
	    {typeof(Service), Service._binding},
	    {typeof(Maintenance), Maintenance._binding},
	    {typeof(MaintenanceEvent), MaintenanceEvent._binding},
	    {typeof(Consumable), Consumable._binding},
	    {typeof(Accessory), Accessory._binding},
	    {typeof(Supplier), Supplier._binding}
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
        /// The kind of the entity the Card represents.
        /// individual: a single person
        /// group: a group of people or entities
        /// org: an organization
        /// location: a named location
        /// device: a device such as an appliance, a computer, or a network element
        /// application: a software application
        /// </summary>

	[JsonPropertyName("kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// The language tag, as defined in [RFC5646], that best describes the language 
        /// used for text in the Card, optionally including additional information such 
        /// as the script. Note that values MAY be localized in the localizations 
        /// property.
        /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					Language  {get; set;}

        /// <summary>
        /// The set of Cards that are members of this group Card. Each key in the set is 
        /// the uid property value of the member, and each boolean value MUST be "true".
        /// If this property is set, then the value of the kind property MUST be "group"
        /// </summary>

	[JsonPropertyName("members")]
	public virtual Dictionary<string,string>?					Members  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("deviceId")]
	public virtual string?					DeviceId  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("modelId")]
	public virtual string?					ModelId  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("modelName")]
	public virtual string?					ModelName  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("manufacturer")]
	public virtual string?					Manufacturer  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("dateManufacture")]
	public virtual DateTime?					DateManufacture  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("images")]
	public virtual List<Media>?					Images  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("manuals")]
	public virtual List<Media>?					Manuals  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("guides")]
	public virtual List<Media>?					Guides  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("bootstraps")]
	public virtual List<Bootstrap>?					Bootstraps  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("provisioning")]
	public virtual List<Provisioning>?					Provisioning  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("services")]
	public virtual List<Service>?					Services  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("maintenance")]
	public virtual List<Maintenance>?					Maintenance  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("consumables")]
	public virtual List<Consumable>?					Consumables  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("accessories")]
	public virtual List<Accessory>?					Accessories  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}
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
	public virtual Dictionary<string,PatchObject>?					Localizations  {get; set;}

        /// <summary>
        /// The cryptographic resources such as public keys and certificates associated 
        /// with the entity represented by the Card.
        /// </summary>

	[JsonPropertyName("jwks")]
	public virtual Dictionary<string,Jwks>?					JsonWebKeys  {get; set;}



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
			{ "members", new PropertyDictionaryString ("members", 
					(IBinding data, Dictionary<string,string>? value) => {(data as JsDevice).Members = value;}, (IBinding data) => (data as JsDevice).Members )},
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
			{ "images", new PropertyListStruct ("images", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Images = value as List<Media>;}, (IBinding data) => (data as JsDevice).Images,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "manuals", new PropertyListStruct ("manuals", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Manuals = value as List<Media>;}, (IBinding data) => (data as JsDevice).Manuals,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "guides", new PropertyListStruct ("guides", typeof (Media),
					(IBinding data, object? value) => {(data as JsDevice).Guides = value as List<Media>;}, (IBinding data) => (data as JsDevice).Guides,
					false, ()=>new  List<Media>(), ()=>new Media())},
			{ "bootstraps", new PropertyListStruct ("bootstraps", typeof (Bootstrap),
					(IBinding data, object? value) => {(data as JsDevice).Bootstraps = value as List<Bootstrap>;}, (IBinding data) => (data as JsDevice).Bootstraps,
					false, ()=>new  List<Bootstrap>(), ()=>new Bootstrap())},
			{ "provisioning", new PropertyListStruct ("provisioning", typeof (Provisioning),
					(IBinding data, object? value) => {(data as JsDevice).Provisioning = value as List<Provisioning>;}, (IBinding data) => (data as JsDevice).Provisioning,
					false, ()=>new  List<Provisioning>(), ()=>new Provisioning())},
			{ "services", new PropertyListStruct ("services", typeof (Service),
					(IBinding data, object? value) => {(data as JsDevice).Services = value as List<Service>;}, (IBinding data) => (data as JsDevice).Services,
					false, ()=>new  List<Service>(), ()=>new Service())},
			{ "maintenance", new PropertyListStruct ("maintenance", typeof (Maintenance),
					(IBinding data, object? value) => {(data as JsDevice).Maintenance = value as List<Maintenance>;}, (IBinding data) => (data as JsDevice).Maintenance,
					false, ()=>new  List<Maintenance>(), ()=>new Maintenance())},
			{ "consumables", new PropertyListStruct ("consumables", typeof (Consumable),
					(IBinding data, object? value) => {(data as JsDevice).Consumables = value as List<Consumable>;}, (IBinding data) => (data as JsDevice).Consumables,
					false, ()=>new  List<Consumable>(), ()=>new Consumable())},
			{ "accessories", new PropertyListStruct ("accessories", typeof (Accessory),
					(IBinding data, object? value) => {(data as JsDevice).Accessories = value as List<Accessory>;}, (IBinding data) => (data as JsDevice).Accessories,
					false, ()=>new  List<Accessory>(), ()=>new Accessory())},
			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as JsDevice).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as JsDevice).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())},
			{ "localizations", new PropertyDictionaryStruct ("localizations", typeof (PatchObject),
					(IBinding data, object? value) => {(data as JsDevice).Localizations = value as Dictionary<string,PatchObject>;}, (IBinding data) => (data as JsDevice).Localizations,
					false, ()=>new  Dictionary<string,PatchObject>(), ()=>new PatchObject(),
					(IBinding data) => (data as JsDevice).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,PatchObject>).Add (key as string,value as PatchObject);})},
			{ "jwks", new PropertyDictionaryStruct ("jwks", typeof (Jwks),
					(IBinding data, object? value) => {(data as JsDevice).JsonWebKeys = value as Dictionary<string,Jwks>;}, (IBinding data) => (data as JsDevice).JsonWebKeys,
					false, ()=>new  Dictionary<string,Jwks>(), ()=>new Jwks(),
					(IBinding data) => (data as JsDevice).JsonWebKeys.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Jwks>).Add (key as string,value as Jwks);})}
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
	///  
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
	///  
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
	///  
	/// </summary>
public partial class Network : Protocol {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Network> _binding = new (
			new() {

        }, __Tag,() => new Network(), () => new List<Network>(), () => new Dictionary<string,Network>(),Protocol._binding);

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
	public new const string __Tag = "Network";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Network();


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


	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class Service : Protocol {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Service> _binding = new (
			new() {

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
	/// </summary>
public partial class Maintenance : Devices {
        /// <summary>
        /// List of maintenance events associated with the device.
        /// </summary>

	[JsonPropertyName("events")]
	public virtual List<MaintenanceEvent>?					Events  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Maintenance> _binding = new (
			new() {

			{ "events", new PropertyListStruct ("events", typeof (MaintenanceEvent),
					(IBinding data, object? value) => {(data as Maintenance).Events = value as List<MaintenanceEvent>;}, (IBinding data) => (data as Maintenance).Events,
					false, ()=>new  List<MaintenanceEvent>(), ()=>new MaintenanceEvent())}
        }, __Tag,() => new Maintenance(), () => new List<Maintenance>(), () => new Dictionary<string,Maintenance>(),null);

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
	///  
	/// </summary>
public partial class MaintenanceEvent : Resource {
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("recurring")]
	public virtual bool?					Recurring  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("days")]
	public virtual int?					Days  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("months")]
	public virtual int?					Months  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("years")]
	public virtual int?					Years  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("endSupport")]
	public virtual DateTime?					EndSupport  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("endLife")]
	public virtual DateTime?					EndLife  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MaintenanceEvent> _binding = new (
			new() {

			{ "recurring", new PropertyBoolean ("recurring", 
					(IBinding data, bool? value) => {(data as MaintenanceEvent).Recurring = value;}, (IBinding data) => (data as MaintenanceEvent).Recurring )},
			{ "days", new PropertyInteger32 ("days", 
					(IBinding data, int? value) => {(data as MaintenanceEvent).Days = value;}, (IBinding data) => (data as MaintenanceEvent).Days )},
			{ "months", new PropertyInteger32 ("months", 
					(IBinding data, int? value) => {(data as MaintenanceEvent).Months = value;}, (IBinding data) => (data as MaintenanceEvent).Months )},
			{ "years", new PropertyInteger32 ("years", 
					(IBinding data, int? value) => {(data as MaintenanceEvent).Years = value;}, (IBinding data) => (data as MaintenanceEvent).Years )},
			{ "endSupport", new PropertyDateTime ("endSupport", 
					(IBinding data, DateTime? value) => {(data as MaintenanceEvent).EndSupport = value;}, (IBinding data) => (data as MaintenanceEvent).EndSupport )},
			{ "endLife", new PropertyDateTime ("endLife", 
					(IBinding data, DateTime? value) => {(data as MaintenanceEvent).EndLife = value;}, (IBinding data) => (data as MaintenanceEvent).EndLife )}
        }, __Tag,() => new MaintenanceEvent(), () => new List<MaintenanceEvent>(), () => new Dictionary<string,MaintenanceEvent>(),Resource._binding);

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
	public new const string __Tag = "MaintenanceEvent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MaintenanceEvent();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MaintenanceEvent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MaintenanceEvent;
			}
		var Result = new MaintenanceEvent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	///
	///  
	/// </summary>
public partial class Consumable : Resource {
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Consumable> _binding = new (
			new() {

			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as Consumable).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as Consumable).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())}
        }, __Tag,() => new Consumable(), () => new List<Consumable>(), () => new Dictionary<string,Consumable>(),Resource._binding);

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
	///  
	/// </summary>
public partial class Accessory : Resource {
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("suppliers")]
	public virtual List<Supplier>?					Suppliers  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Accessory> _binding = new (
			new() {

			{ "suppliers", new PropertyListStruct ("suppliers", typeof (Supplier),
					(IBinding data, object? value) => {(data as Accessory).Suppliers = value as List<Supplier>;}, (IBinding data) => (data as Accessory).Suppliers,
					false, ()=>new  List<Supplier>(), ()=>new Supplier())}
        }, __Tag,() => new Accessory(), () => new List<Accessory>(), () => new Dictionary<string,Accessory>(),Resource._binding);

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


	/// <summary>
	///
	///  
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



