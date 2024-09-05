
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
//  This file was automatically generated at 9/5/2024 2:07:27 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
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

    [ModuleInitializer]

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
	/// Describes a current or pending connection to a Mesh
	/// </summary>
public partial class CatalogedMachine : HostCatalogItem {
        /// <summary>
        ///Unique object instance identifier.
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///Local short name for the profile
        /// </summary>

	public virtual string?						Local  {get; set;}

        /// <summary>
        ///If true, this is the default for the profile type (master, account)
        /// </summary>

	public virtual bool?						Default  {get; set;}

        /// <summary>
        ///The master profile that provides the root of trust for this Mesh
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileAccount  {get; set;}

        /// <summary>
        ///The cataloged device profile
        /// </summary>

	public virtual CatalogedDevice?						CatalogedDevice  {get; set;}

        /// <summary>
        ///The digest of the cataloged device.
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}

        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>?						EnvelopedAccountHostAssignment  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedMachine(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedMachine).Id = value;}, (IBinding data) => (data as CatalogedMachine).Id )},
			{ "Local", new PropertyString ("Local", 
					(IBinding data, string? value) => {(data as CatalogedMachine).Local = value;}, (IBinding data) => (data as CatalogedMachine).Local )},
			{ "Default", new PropertyBoolean ("Default", 
					(IBinding data, bool? value) => {(data as CatalogedMachine).Default = value;}, (IBinding data) => (data as CatalogedMachine).Default )},
			{ "EnvelopedProfileAccount", new PropertyStruct ("EnvelopedProfileAccount", 
					(IBinding data, object? value) => {(data as CatalogedMachine).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedMachine).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "CatalogedDevice", new PropertyStruct ("CatalogedDevice", 
					(IBinding data, object? value) => {(data as CatalogedMachine).CatalogedDevice = value as CatalogedDevice;}, (IBinding data) => (data as CatalogedMachine).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())} ,
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as CatalogedMachine).CatalogedDeviceDigest = value;}, (IBinding data) => (data as CatalogedMachine).CatalogedDeviceDigest )},
			{ "EnvelopedAccountHostAssignment", new PropertyStruct ("EnvelopedAccountHostAssignment", 
					(IBinding data, object? value) => {(data as CatalogedMachine).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, (IBinding data) => (data as CatalogedMachine).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())} 
        };

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
	public new const string __Tag = "CatalogedMachine";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedMachine();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedMachine FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedMachine;
			}
		var Result = new CatalogedMachine ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedService : CatalogedMachine {
        /// <summary>
        ///The service profile
        /// </summary>

	public virtual Enveloped<ProfileService>?						EnvelopedProfileService  {get; set;}

        /// <summary>
        ///The host profile
        /// </summary>

	public virtual Enveloped<ProfileHost>?						EnvelopedProfileHost  {get; set;}

        /// <summary>
        ///The activation record for the service client (if used)
        /// </summary>

	public virtual Enveloped<ActivationCommon>?						EnvelopedActivationCommon  {get; set;}

        /// <summary>
        ///The activation record for this host
        /// </summary>

	public virtual Enveloped<ActivationHost>?						EnvelopedActivationHost  {get; set;}

        /// <summary>
        ///The connection of the host to the service
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///Specifies the type of service 
        /// </summary>

	public virtual string?						ServiceIdentifier  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedService(), CatalogedMachine._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileService", new PropertyStruct ("EnvelopedProfileService", 
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedProfileService = value as Enveloped<ProfileService>;}, (IBinding data) => (data as CatalogedService).EnvelopedProfileService,
					false, ()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>())} ,
			{ "EnvelopedProfileHost", new PropertyStruct ("EnvelopedProfileHost", 
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedProfileHost = value as Enveloped<ProfileHost>;}, (IBinding data) => (data as CatalogedService).EnvelopedProfileHost,
					false, ()=>new  Enveloped<ProfileHost>(), ()=>new Enveloped<ProfileHost>())} ,
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", 
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedService).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())} ,
			{ "EnvelopedActivationHost", new PropertyStruct ("EnvelopedActivationHost", 
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedActivationHost = value as Enveloped<ActivationHost>;}, (IBinding data) => (data as CatalogedService).EnvelopedActivationHost,
					false, ()=>new  Enveloped<ActivationHost>(), ()=>new Enveloped<ActivationHost>())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as CatalogedService).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as CatalogedService).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} ,
			{ "ServiceIdentifier", new PropertyString ("ServiceIdentifier", 
					(IBinding data, string? value) => {(data as CatalogedService).ServiceIdentifier = value;}, (IBinding data) => (data as CatalogedService).ServiceIdentifier )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedService;
			}
		var Result = new CatalogedService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedStandard : CatalogedMachine {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedStandard(), CatalogedMachine._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedStandard";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedStandard();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedStandard FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedStandard;
			}
		var Result = new CatalogedStandard ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


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

	public virtual string?						DeviceUDF  {get; set;}

        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

	public virtual Enveloped<ProfileDevice>?						EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///The response returned by the service when the registration was requested.
        /// </summary>

	public virtual Enveloped<AcknowledgeConnection>?						EnvelopedAcknowledgeConnection  {get; set;}

        /// <summary>
        ///The account at which the request is pending.
        /// </summary>

	public virtual string?						AccountAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedPending(), CatalogedMachine._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceUDF", new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as CatalogedPending).DeviceUDF = value;}, (IBinding data) => (data as CatalogedPending).DeviceUDF )},
			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", 
					(IBinding data, object? value) => {(data as CatalogedPending).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as CatalogedPending).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())} ,
			{ "EnvelopedAcknowledgeConnection", new PropertyStruct ("EnvelopedAcknowledgeConnection", 
					(IBinding data, object? value) => {(data as CatalogedPending).EnvelopedAcknowledgeConnection = value as Enveloped<AcknowledgeConnection>;}, (IBinding data) => (data as CatalogedPending).EnvelopedAcknowledgeConnection,
					false, ()=>new  Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>())} ,
			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedPending).AccountAddress = value;}, (IBinding data) => (data as CatalogedPending).AccountAddress )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedPending";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPending();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedPending FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedPending;
			}
		var Result = new CatalogedPending ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a preconfigured Device Profile bound to a remote 
	/// manufacturer profile.
	/// </summary>
public partial class CatalogedPreconfigured : CatalogedMachine {
        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

	public virtual Enveloped<ProfileDevice>?						EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///The device connection used to authenticate to the service.
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///The device connection used to authenticate to the service.
        /// </summary>

	public virtual Enveloped<ConnectionDevice>?						EnvelopedConnectionDevice  {get; set;}

        /// <summary>
        ///The account to which claims will be posted
        /// </summary>

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        ///The publication identifier
        /// </summary>

	public virtual string?						PublicationId  {get; set;}

        /// <summary>
        ///Authenticator key used to authenticate claim to the service.
        /// </summary>

	public virtual string?						ServiceAuthenticator  {get; set;}

        /// <summary>
        ///Authenticator key used to authenticate claim to the device.
        /// </summary>

	public virtual string?						DeviceAuthenticator  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedPreconfigured(), CatalogedMachine._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", 
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as CatalogedPreconfigured).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as CatalogedPreconfigured).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} ,
			{ "EnvelopedConnectionDevice", new PropertyStruct ("EnvelopedConnectionDevice", 
					(IBinding data, object? value) => {(data as CatalogedPreconfigured).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;}, (IBinding data) => (data as CatalogedPreconfigured).EnvelopedConnectionDevice,
					false, ()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>())} ,
			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).AccountAddress = value;}, (IBinding data) => (data as CatalogedPreconfigured).AccountAddress )},
			{ "PublicationId", new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).PublicationId = value;}, (IBinding data) => (data as CatalogedPreconfigured).PublicationId )},
			{ "ServiceAuthenticator", new PropertyString ("ServiceAuthenticator", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).ServiceAuthenticator = value;}, (IBinding data) => (data as CatalogedPreconfigured).ServiceAuthenticator )},
			{ "DeviceAuthenticator", new PropertyString ("DeviceAuthenticator", 
					(IBinding data, string? value) => {(data as CatalogedPreconfigured).DeviceAuthenticator = value;}, (IBinding data) => (data as CatalogedPreconfigured).DeviceAuthenticator )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedPreconfigured";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPreconfigured();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedPreconfigured FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedPreconfigured;
			}
		var Result = new CatalogedPreconfigured ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ShellDispatch : HostCatalogItem {
        /// <summary>
        ///The protocol to dispatch
        /// </summary>

	public virtual string?						Protocol  {get; set;}

        /// <summary>
        ///The Icon to display
        /// </summary>

	public virtual string?						Icon  {get; set;}

        /// <summary>
        ///The supported by the protocol
        /// </summary>

	public virtual List<ShellAction>?					Actions  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ShellDispatch(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as ShellDispatch).Protocol = value;}, (IBinding data) => (data as ShellDispatch).Protocol )},
			{ "Icon", new PropertyString ("Icon", 
					(IBinding data, string? value) => {(data as ShellDispatch).Icon = value;}, (IBinding data) => (data as ShellDispatch).Icon )},
			{ "Actions", new PropertyListStruct ("Actions", 
					(IBinding data, object? value) => {(data as ShellDispatch).Actions = value as List<ShellAction>;}, (IBinding data) => (data as ShellDispatch).Actions,
					false, ()=>new  List<ShellAction>(), ()=>new ShellAction())} 
        };

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
	public new const string __Tag = "ShellDispatch";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ShellDispatch();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ShellDispatch FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ShellDispatch;
			}
		var Result = new ShellDispatch ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ShellAction : HostCatalogItem {
        /// <summary>
        ///The protocol to dispatch
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The Icon to display
        /// </summary>

	public virtual string?						Icon  {get; set;}

        /// <summary>
        ///The Action to perform
        /// </summary>

	public virtual string?						Mode  {get; set;}

        /// <summary>
        ///The Action to perform
        /// </summary>

	public virtual string?						Parameter  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ShellAction(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as ShellAction).Id = value;}, (IBinding data) => (data as ShellAction).Id )},
			{ "Icon", new PropertyString ("Icon", 
					(IBinding data, string? value) => {(data as ShellAction).Icon = value;}, (IBinding data) => (data as ShellAction).Icon )},
			{ "Mode", new PropertyString ("Mode", 
					(IBinding data, string? value) => {(data as ShellAction).Mode = value;}, (IBinding data) => (data as ShellAction).Mode )},
			{ "Parameter", new PropertyString ("Parameter", 
					(IBinding data, string? value) => {(data as ShellAction).Parameter = value;}, (IBinding data) => (data as ShellAction).Parameter )}
        };

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
	public new const string __Tag = "ShellAction";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ShellAction();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ShellAction FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ShellAction;
			}
		var Result = new ShellAction ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



