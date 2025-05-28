
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
//  This file was automatically generated at 5/27/2025 4:21:29 PM
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

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Client;


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
public abstract partial class HostCatalogItem : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "HostCatalogItem";

	/*
	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"CatalogedMachine", CatalogedMachine._Factory},
	    {"CatalogedService", CatalogedService._Factory},
	    {"CatalogedStandard", CatalogedStandard._Factory},
	    {"CatalogedPending", CatalogedPending._Factory},
	    {"CatalogedPreconfigured", CatalogedPreconfigured._Factory},
	    {"ShellDispatch", ShellDispatch._Factory},
	    {"ShellAction", ShellAction._Factory}
		};
	*/

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(CatalogedMachine), CatalogedMachine._binding},
	    {typeof(CatalogedService), CatalogedService._binding},
	    {typeof(CatalogedStandard), CatalogedStandard._binding},
	    {typeof(CatalogedPending), CatalogedPending._binding},
	    {typeof(CatalogedPreconfigured), CatalogedPreconfigured._binding},
	    {typeof(ShellDispatch), ShellDispatch._binding},
	    {typeof(ShellAction), ShellAction._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static HostCatalogItem() {
		_Initialize();
		}

    internal static void _Initialize() {
		//AddDictionary(ref _tagDictionary);
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
	/// Describes a current or pending connection to a Mesh
	/// </summary>
public partial class CatalogedMachine : HostCatalogItem {
    /// <summary>
    ///Unique object instance identifier.
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///Local short name for the profile
    /// </summary>

	[JsonPropertyName("Local")]
	public virtual string?					Local  {get; set;} //

    /// <summary>
    ///If true, this is the default for the profile type (master, account)
    /// </summary>

	[JsonPropertyName("Default")]
	public virtual bool?					Default  {get; set;} //

	[JsonPropertyName("ProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAccount?				ProfileAccount  {get; set;} 
    /// <summary>
    ///The cataloged device profile
    /// </summary>

	[JsonPropertyName("CatalogedDevice")]
	public virtual CatalogedDevice?					CatalogedDevice  {get; set;} //

    /// <summary>
    ///The digest of the cataloged device.
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

	[JsonPropertyName("AccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual AccountHostAssignment?				AccountHostAssignment  {get; set;} 

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedMachine).Id = value;}, 
					(IBinding data) => (data as CatalogedMachine).Id ),
		new PropertyString ("Local", 
					(IBinding data, string? value) => {(data as CatalogedMachine).Local = value;}, 
					(IBinding data) => (data as CatalogedMachine).Local ),
		new PropertyBoolean ("Default", 
					(IBinding data, bool? value) => {(data as CatalogedMachine).Default = value;}, 
					(IBinding data) => (data as CatalogedMachine).Default ),
		new PropertyGStruct ("ProfileAccount", /*typeof (ProfileAccount<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedMachine).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;},
					(IBinding data) => (data as CatalogedMachine).EnvelopedProfileAccount,
					/*(IBinding data, object? value) => {(data as CatalogedMachine).ProfileAccount = value as ProfileAccount;},
					(IBinding data) => (data as CatalogedMachine).ProfileAccount,*/
					()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyStruct ("CatalogedDevice", typeof (CatalogedDevice),
					(IBinding data, object? value) => {(data as CatalogedMachine).CatalogedDevice = value as CatalogedDevice;}, 
					(IBinding data) => (data as CatalogedMachine).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice()),
		new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as CatalogedMachine).CatalogedDeviceDigest = value;}, 
					(IBinding data) => (data as CatalogedMachine).CatalogedDeviceDigest ),
		new PropertyGStruct ("AccountHostAssignment", /*typeof (AccountHostAssignment<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedMachine).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;},
					(IBinding data) => (data as CatalogedMachine).EnvelopedAccountHostAssignment,
					/*(IBinding data, object? value) => {(data as CatalogedMachine).AccountHostAssignment = value as AccountHostAssignment;},
					(IBinding data) => (data as CatalogedMachine).AccountHostAssignment,*/
					()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedMachine> _binding = new (
			new() {

			{ "Id", _properties [0]},
			{ "Local", _properties [1]},
			{ "Default", _properties [2]},
			{ "ProfileAccount", _properties [3]},
			{ "CatalogedDevice", _properties [4]},
			{ "CatalogedDeviceDigest", _properties [5]},
			{ "AccountHostAssignment", _properties [6]}
        }, __Tag,() => new CatalogedMachine(), () => new List<CatalogedMachine>(), () => new Dictionary<string,CatalogedMachine>(),null);
	/*
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

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedMachine";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedMachine();

	}


	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedService : CatalogedMachine {
	[JsonPropertyName("ProfileService")]
	public virtual Enveloped<ProfileService>?					EnvelopedProfileService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileService?				ProfileService  {get; set;} 
	[JsonPropertyName("ProfileHost")]
	public virtual Enveloped<ProfileHost>?					EnvelopedProfileHost  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileHost?				ProfileHost  {get; set;} 
	[JsonPropertyName("ActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationCommon?				ActivationCommon  {get; set;} 
	[JsonPropertyName("ActivationHost")]
	public virtual Enveloped<ActivationHost>?					EnvelopedActivationHost  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationHost?				ActivationHost  {get; set;} 
	[JsonPropertyName("ConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionService?				ConnectionService  {get; set;} 
    /// <summary>
    ///Specifies the type of service 
    /// </summary>

	[JsonPropertyName("ServiceIdentifier")]
	public virtual string?					ServiceIdentifier  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyGStruct ("ProfileService", /*typeof (ProfileService<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedProfileService = value as Enveloped<ProfileService>;},
					(IBinding data) => (data as CatalogedService).EnvelopedProfileService,
					/*(IBinding data, object? value) => {(data as CatalogedService).ProfileService = value as ProfileService;},
					(IBinding data) => (data as CatalogedService).ProfileService,*/
					()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>()),
		new PropertyGStruct ("ProfileHost", /*typeof (ProfileHost<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedProfileHost = value as Enveloped<ProfileHost>;},
					(IBinding data) => (data as CatalogedService).EnvelopedProfileHost,
					/*(IBinding data, object? value) => {(data as CatalogedService).ProfileHost = value as ProfileHost;},
					(IBinding data) => (data as CatalogedService).ProfileHost,*/
					()=>new  Enveloped<ProfileHost>(), ()=>new Enveloped<ProfileHost>()),
		new PropertyGStruct ("ActivationCommon", /*typeof (ActivationCommon<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;},
					(IBinding data) => (data as CatalogedService).EnvelopedActivationCommon,
					/*(IBinding data, object? value) => {(data as CatalogedService).ActivationCommon = value as ActivationCommon;},
					(IBinding data) => (data as CatalogedService).ActivationCommon,*/
					()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>()),
		new PropertyGStruct ("ActivationHost", /*typeof (ActivationHost<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedActivationHost = value as Enveloped<ActivationHost>;},
					(IBinding data) => (data as CatalogedService).EnvelopedActivationHost,
					/*(IBinding data, object? value) => {(data as CatalogedService).ActivationHost = value as ActivationHost;},
					(IBinding data) => (data as CatalogedService).ActivationHost,*/
					()=>new  Enveloped<ActivationHost>(), ()=>new Enveloped<ActivationHost>()),
		new PropertyGStruct ("ConnectionService", /*typeof (ConnectionService<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedConnectionService = value as Enveloped<ConnectionService>;},
					(IBinding data) => (data as CatalogedService).EnvelopedConnectionService,
					/*(IBinding data, object? value) => {(data as CatalogedService).ConnectionService = value as ConnectionService;},
					(IBinding data) => (data as CatalogedService).ConnectionService,*/
					()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>()),
		new PropertyString ("ServiceIdentifier", 
					(IBinding data, string? value) => {(data as CatalogedService).ServiceIdentifier = value;}, 
					(IBinding data) => (data as CatalogedService).ServiceIdentifier )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedService> _binding = new (
			new() {

			{ "ProfileService", _properties [0]},
			{ "ProfileHost", _properties [1]},
			{ "ActivationCommon", _properties [2]},
			{ "ActivationHost", _properties [3]},
			{ "ConnectionService", _properties [4]},
			{ "ServiceIdentifier", _properties [5]}
        }, __Tag,() => new CatalogedService(), () => new List<CatalogedService>(), () => new Dictionary<string,CatalogedService>(),CatalogedMachine._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedMachine._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedService();

	}


	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedStandard : CatalogedMachine {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedStandard> _binding = new (
			new() {

        }, __Tag,() => new CatalogedStandard(), () => new List<CatalogedStandard>(), () => new Dictionary<string,CatalogedStandard>(),CatalogedMachine._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedMachine._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedStandard";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedStandard();

	}


	/// <summary>
	///
	/// Describes a pending connection to a Mesh account believed to have been 
	/// created and posted to a service.
	/// </summary>
public partial class CatalogedPending : CatalogedMachine {
    /// <summary>
    ///UDF of the connected device
    /// </summary>

	[JsonPropertyName("DeviceUDF")]
	public virtual string?					DeviceUDF  {get; set;} //

	[JsonPropertyName("ProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileDevice?				ProfileDevice  {get; set;} 
	[JsonPropertyName("AcknowledgeConnection")]
	public virtual Enveloped<AcknowledgeConnection>?					EnvelopedAcknowledgeConnection  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual AcknowledgeConnection?				AcknowledgeConnection  {get; set;} 
    /// <summary>
    ///The account at which the request is pending.
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as CatalogedPending).DeviceUDF = value;}, 
					(IBinding data) => (data as CatalogedPending).DeviceUDF ),
		new PropertyGStruct ("ProfileDevice", /*typeof (ProfileDevice<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedPending).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;},
					(IBinding data) => (data as CatalogedPending).EnvelopedProfileDevice,
					/*(IBinding data, object? value) => {(data as CatalogedPending).ProfileDevice = value as ProfileDevice;},
					(IBinding data) => (data as CatalogedPending).ProfileDevice,*/
					()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>()),
		new PropertyGStruct ("AcknowledgeConnection", /*typeof (AcknowledgeConnection<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedPending).EnvelopedAcknowledgeConnection = value as Enveloped<AcknowledgeConnection>;},
					(IBinding data) => (data as CatalogedPending).EnvelopedAcknowledgeConnection,
					/*(IBinding data, object? value) => {(data as CatalogedPending).AcknowledgeConnection = value as AcknowledgeConnection;},
					(IBinding data) => (data as CatalogedPending).AcknowledgeConnection,*/
					()=>new  Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>()),
		new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedPending).AccountAddress = value;}, 
					(IBinding data) => (data as CatalogedPending).AccountAddress )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedPending> _binding = new (
			new() {

			{ "DeviceUDF", _properties [0]},
			{ "ProfileDevice", _properties [1]},
			{ "AcknowledgeConnection", _properties [2]},
			{ "AccountAddress", _properties [3]}
        }, __Tag,() => new CatalogedPending(), () => new List<CatalogedPending>(), () => new Dictionary<string,CatalogedPending>(),CatalogedMachine._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedMachine._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedPending";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPending();

	}


	/// <summary>
	///
	/// Describes a preconfigured Device Profile bound to a remote 
	/// manufacturer profile.
	/// </summary>
public partial class CatalogedPreconfigured : CatalogedMachine {
	[JsonPropertyName("ProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileDevice?				ProfileDevice  {get; set;} 
	[JsonPropertyName("ConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionService?				ConnectionService  {get; set;} 
	[JsonPropertyName("ConnectionDevice")]
	public virtual Enveloped<ConnectionDevice>?					EnvelopedConnectionDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionDevice?				ConnectionDevice  {get; set;} 
    /// <summary>
    ///The account to which claims will be posted
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    ///The publication identifier
    /// </summary>

	[JsonPropertyName("PublicationId")]
	public virtual string?					PublicationId  {get; set;} //

    /// <summary>
    ///Authenticator key used to authenticate claim to the service.
    /// </summary>

	[JsonPropertyName("ServiceAuthenticator")]
	public virtual string?					ServiceAuthenticator  {get; set;} //

    /// <summary>
    ///Authenticator key used to authenticate claim to the device.
    /// </summary>

	[JsonPropertyName("DeviceAuthenticator")]
	public virtual string?					DeviceAuthenticator  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyGStruct ("ProfileDevice", /*typeof (ProfileDevice<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;},
					(IBinding data) => (data as CatalogedPreconfigured).EnvelopedProfileDevice,
					/*(IBinding data, object? value) => {(data as CatalogedPreconfigured).ProfileDevice = value as ProfileDevice;},
					(IBinding data) => (data as CatalogedPreconfigured).ProfileDevice,*/
					()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>()),
		new PropertyGStruct ("ConnectionService", /*typeof (ConnectionService<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedConnectionService = value as Enveloped<ConnectionService>;},
					(IBinding data) => (data as CatalogedPreconfigured).EnvelopedConnectionService,
					/*(IBinding data, object? value) => {(data as CatalogedPreconfigured).ConnectionService = value as ConnectionService;},
					(IBinding data) => (data as CatalogedPreconfigured).ConnectionService,*/
					()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>()),
		new PropertyGStruct ("ConnectionDevice", /*typeof (ConnectionDevice<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;},
					(IBinding data) => (data as CatalogedPreconfigured).EnvelopedConnectionDevice,
					/*(IBinding data, object? value) => {(data as CatalogedPreconfigured).ConnectionDevice = value as ConnectionDevice;},
					(IBinding data) => (data as CatalogedPreconfigured).ConnectionDevice,*/
					()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>()),
		new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).AccountAddress = value;}, 
					(IBinding data) => (data as CatalogedPreconfigured).AccountAddress ),
		new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).PublicationId = value;}, 
					(IBinding data) => (data as CatalogedPreconfigured).PublicationId ),
		new PropertyString ("ServiceAuthenticator", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).ServiceAuthenticator = value;}, 
					(IBinding data) => (data as CatalogedPreconfigured).ServiceAuthenticator ),
		new PropertyString ("DeviceAuthenticator", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).DeviceAuthenticator = value;}, 
					(IBinding data) => (data as CatalogedPreconfigured).DeviceAuthenticator )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedPreconfigured> _binding = new (
			new() {

			{ "ProfileDevice", _properties [0]},
			{ "ConnectionService", _properties [1]},
			{ "ConnectionDevice", _properties [2]},
			{ "AccountAddress", _properties [3]},
			{ "PublicationId", _properties [4]},
			{ "ServiceAuthenticator", _properties [5]},
			{ "DeviceAuthenticator", _properties [6]}
        }, __Tag,() => new CatalogedPreconfigured(), () => new List<CatalogedPreconfigured>(), () => new Dictionary<string,CatalogedPreconfigured>(),CatalogedMachine._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedMachine._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedPreconfigured";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPreconfigured();

	}


	/// <summary>
	/// </summary>
public partial class ShellDispatch : HostCatalogItem {
    /// <summary>
    ///The protocol to dispatch
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    ///The Icon to display
    /// </summary>

	[JsonPropertyName("Icon")]
	public virtual string?					Icon  {get; set;} //

    /// <summary>
    ///The supported by the protocol
    /// </summary>

	[JsonPropertyName("Actions")]
	public virtual List<ShellAction>?					Actions  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as ShellDispatch).Protocol = value;}, 
					(IBinding data) => (data as ShellDispatch).Protocol ),
		new PropertyString ("Icon", 
					(IBinding data, string? value) => {(data as ShellDispatch).Icon = value;}, 
					(IBinding data) => (data as ShellDispatch).Icon ),
		new PropertyListStruct ("Actions", typeof (ShellAction),
					(IBinding data, object? value) => {(data as ShellDispatch).Actions = value as List<ShellAction>;}, 
					(IBinding data) => (data as ShellDispatch).Actions,
					false, ()=>new  List<ShellAction>(), ()=>new ShellAction())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ShellDispatch> _binding = new (
			new() {

			{ "Protocol", _properties [0]},
			{ "Icon", _properties [1]},
			{ "Actions", _properties [2]}
        }, __Tag,() => new ShellDispatch(), () => new List<ShellDispatch>(), () => new Dictionary<string,ShellDispatch>(),null);
	/*
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

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ShellDispatch";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ShellDispatch();

	}


	/// <summary>
	/// </summary>
public partial class ShellAction : HostCatalogItem {
    /// <summary>
    ///The protocol to dispatch
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///The Icon to display
    /// </summary>

	[JsonPropertyName("Icon")]
	public virtual string?					Icon  {get; set;} //

    /// <summary>
    ///The Action to perform
    /// </summary>

	[JsonPropertyName("Mode")]
	public virtual string?					Mode  {get; set;} //

    /// <summary>
    ///The Action to perform
    /// </summary>

	[JsonPropertyName("Parameter")]
	public virtual string?					Parameter  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as ShellAction).Id = value;}, 
					(IBinding data) => (data as ShellAction).Id ),
		new PropertyString ("Icon", 
					(IBinding data, string? value) => {(data as ShellAction).Icon = value;}, 
					(IBinding data) => (data as ShellAction).Icon ),
		new PropertyString ("Mode", 
					(IBinding data, string? value) => {(data as ShellAction).Mode = value;}, 
					(IBinding data) => (data as ShellAction).Mode ),
		new PropertyString ("Parameter", 
					(IBinding data, string? value) => {(data as ShellAction).Parameter = value;}, 
					(IBinding data) => (data as ShellAction).Parameter )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ShellAction> _binding = new (
			new() {

			{ "Id", _properties [0]},
			{ "Icon", _properties [1]},
			{ "Mode", _properties [2]},
			{ "Parameter", _properties [3]}
        }, __Tag,() => new ShellAction(), () => new List<ShellAction>(), () => new Dictionary<string,ShellAction>(),null);
	/*
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

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ShellAction";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ShellAction();

	}



