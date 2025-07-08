
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
//  This file was automatically generated at 7/8/2025 3:29:10 PM
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


namespace Goedel.Anything;


	/// <summary>
	///
	/// Anything device naming and provisioning
	/// </summary>
public abstract partial class AnythingProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "AnythingProtocol";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(ProfileAnything), ProfileAnything._binding},
	    {typeof(CatalogedIdentity), CatalogedIdentity._binding},
	    {typeof(Identity), Identity._binding},
	    {typeof(DnsIdentity), DnsIdentity._binding},
	    {typeof(LocalIdentity), LocalIdentity._binding},
	    {typeof(CallsignIdentity), CallsignIdentity._binding},
	    {typeof(CatalogedThing), CatalogedThing._binding},
	    {typeof(CatalogedAnything), CatalogedAnything._binding},
	    {typeof(AnythingRequest), AnythingRequest._binding},
	    {typeof(AnythingResponse), AnythingResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static AnythingProtocol() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes


/// <summary>
/// The new base class for the client and service side APIs.
/// </summary>		
public abstract partial class CarnetService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "anything";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_anything._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, Type>  GetTagDictionary => _TagDictionary;
		
	static Dictionary<string, Type> _TagDictionary = new () {
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new CarnetServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    }

/// <summary>
/// Client class for CarnetService.
/// </summary>		
public partial class CarnetServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "anything";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_anything._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;


	}

/// <summary>
/// Direct API class for CarnetService.
/// </summary>		
public partial class CarnetServiceDirect: CarnetServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public CarnetService Service {get; set;}


		}




	// Transaction Classes

	/// <summary>
	///
	/// Describes a anything service provider
	/// </summary>
public partial class ProfileAnything : ProfileService {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileAnything> _binding = new (
			new() {}, __Tag,
		() => new ProfileAnything(), () => [], () => [], ProfileService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProfileAnything";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileAnything();

	}


	/// <summary>
	/// </summary>
public partial class CatalogedIdentity : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Identities")]
	public virtual List<Identity>?					Identities  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("Certificates")]
	public virtual List<byte[]>?					Certificates  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Identities", typeof (Identity), 
					(IBinding data, object? value) => {(data as CatalogedIdentity).Identities = value as List<Identity>;}, 
					(IBinding data) => (data as CatalogedIdentity).Identities,
					true, ()=>new List<Identity>()
) ,
		new PropertyListBinary ("Certificates", 
					(IBinding data, List<byte[]>? value) => {(data as CatalogedIdentity).Certificates = value;}, 
					(IBinding data) => (data as CatalogedIdentity).Certificates )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedIdentity> _binding = new (
			new() {
			{ "Identities", _properties [0]},
			{ "Certificates", _properties [1]}}, __Tag,
		() => new CatalogedIdentity(), () => [], () => [], CatalogedEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedIdentity";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedIdentity();

	}


	/// <summary>
	/// </summary>
abstract public partial class Identity : AnythingProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as Identity).Name = value;}, 
					(IBinding data) => (data as Identity).Name )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Identity> _binding = new (
			new() {
			{ "Name", _properties [0]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Identity";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();

	}


	/// <summary>
	/// </summary>
public partial class DnsIdentity : Identity {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DnsIdentity> _binding = new (
			new() {}, __Tag,
		() => new DnsIdentity(), () => [], () => [], Identity._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DnsIdentity";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DnsIdentity();

	}


	/// <summary>
	/// </summary>
public partial class LocalIdentity : Identity {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<LocalIdentity> _binding = new (
			new() {}, __Tag,
		() => new LocalIdentity(), () => [], () => [], Identity._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "LocalIdentity";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new LocalIdentity();

	}


	/// <summary>
	/// </summary>
public partial class CallsignIdentity : Identity {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CallsignIdentity> _binding = new (
			new() {}, __Tag,
		() => new CallsignIdentity(), () => [], () => [], Identity._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignIdentity";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignIdentity();

	}


	/// <summary>
	/// </summary>
public partial class CatalogedThing : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DnsPrefix")]
	public virtual string?					DnsPrefix  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("InternalIp")]
	public virtual List<string>?					InternalIp  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ExternalIp")]
	public virtual List<string>?					ExternalIp  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("DnsPrefix", 
					(IBinding data, string? value) => {(data as CatalogedThing).DnsPrefix = value;}, 
					(IBinding data) => (data as CatalogedThing).DnsPrefix ),
		new PropertyListString ("InternalIp", 
					(IBinding data, List<string>? value) => {(data as CatalogedThing).InternalIp = value;}, 
					(IBinding data) => (data as CatalogedThing).InternalIp ),
		new PropertyListString ("ExternalIp", 
					(IBinding data, List<string>? value) => {(data as CatalogedThing).ExternalIp = value;}, 
					(IBinding data) => (data as CatalogedThing).ExternalIp )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedThing> _binding = new (
			new() {
			{ "DnsPrefix", _properties [0]},
			{ "InternalIp", _properties [1]},
			{ "ExternalIp", _properties [2]}}, __Tag,
		() => new CatalogedThing(), () => [], () => [], CatalogedEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedThing";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedThing();

	}


	/// <summary>
	/// </summary>
public partial class CatalogedAnything : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionStripped?				ConnectionAddress  => EnvelopedConnectionAddress.Decode();
	[JsonPropertyName("EnvelopedProfileCarnet")]
	public virtual Enveloped<ProfileAnything>?					EnvelopedProfileCarnet  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAnything?				ProfileCarnet  => EnvelopedProfileCarnet.Decode();
	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationCommon?				ActivationCommon  => EnvelopedActivationCommon.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as CatalogedAnything).Key = value;}, 
					(IBinding data) => (data as CatalogedAnything).Key ),
		new PropertyGStruct ("EnvelopedConnectionAddress", /*typeof (ConnectionStripped<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedAnything).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;},
					(IBinding data) => (data as CatalogedAnything).EnvelopedConnectionAddress,
					/*(IBinding data, object? value) => {(data as CatalogedAnything).ConnectionAddress = value as ConnectionStripped;},
					(IBinding data) => (data as CatalogedAnything).ConnectionAddress,*/
					()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>()),
		new PropertyGStruct ("EnvelopedProfileCarnet", /*typeof (ProfileAnything<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedAnything).EnvelopedProfileCarnet = value as Enveloped<ProfileAnything>;},
					(IBinding data) => (data as CatalogedAnything).EnvelopedProfileCarnet,
					/*(IBinding data, object? value) => {(data as CatalogedAnything).ProfileCarnet = value as ProfileAnything;},
					(IBinding data) => (data as CatalogedAnything).ProfileCarnet,*/
					()=>new  Enveloped<ProfileAnything>(), ()=>new Enveloped<ProfileAnything>()),
		new PropertyGStruct ("EnvelopedActivationCommon", /*typeof (ActivationCommon<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as CatalogedAnything).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;},
					(IBinding data) => (data as CatalogedAnything).EnvelopedActivationCommon,
					/*(IBinding data, object? value) => {(data as CatalogedAnything).ActivationCommon = value as ActivationCommon;},
					(IBinding data) => (data as CatalogedAnything).ActivationCommon,*/
					()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedAnything> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "EnvelopedConnectionAddress", _properties [1]},
			{ "EnvelopedProfileCarnet", _properties [2]},
			{ "EnvelopedActivationCommon", _properties [3]}}, __Tag,
		() => new CatalogedAnything(), () => [], () => [], CatalogedEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedAnything";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedAnything();

	}


	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class AnythingRequest : Goedel.Protocol.Request {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AnythingRequest> _binding = new (
			new() {}, __Tag,
		() => new AnythingRequest(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "AnythingRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AnythingRequest();

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class AnythingResponse : Goedel.Protocol.Response {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AnythingResponse> _binding = new (
			new() {}, __Tag,
		() => new AnythingResponse(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "AnythingResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AnythingResponse();

	}



