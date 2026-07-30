
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
//  This file was automatically generated at 7/26/2026 2:40:12 PM
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

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;


namespace Goedel.Presence;


	/// <summary>
	///
	/// Callsign Registrar protocol supporting query function.
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class PresenceProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceProtocol";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(PresenceFromClient), PresenceFromClient._binding},
	    {typeof(PresenceConnectRequest), PresenceConnectRequest._binding},
	    {typeof(PresenceHeartbeat), PresenceHeartbeat._binding},
	    {typeof(PresenceEndpointRequest), PresenceEndpointRequest._binding},
	    {typeof(PresenceAcknowledge), PresenceAcknowledge._binding},
	    {typeof(PresenceResolveRequest), PresenceResolveRequest._binding},
	    {typeof(PresenceFromService), PresenceFromService._binding},
	    {typeof(PresenceConnectResponse), PresenceConnectResponse._binding},
	    {typeof(PresenceErrorInvalidSerial), PresenceErrorInvalidSerial._binding},
	    {typeof(PresenceStatus), PresenceStatus._binding},
	    {typeof(PresenceEndpointResponse), PresenceEndpointResponse._binding},
	    {typeof(PresenceNotify), PresenceNotify._binding},
	    {typeof(PresenceResolveResponse), PresenceResolveResponse._binding},
	    {typeof(SessionRequest), SessionRequest._binding},
	    {typeof(SessionResponse), SessionResponse._binding},
	    {typeof(SessionEndpoint), SessionEndpoint._binding},
	    {typeof(UdpEndpoint), UdpEndpoint._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static PresenceProtocol() {
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
public abstract partial class PresenceService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "mmmpresence";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_mmmpresence._tcp";

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
			new PresenceServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    }

/// <summary>
/// Client class for PresenceService.
/// </summary>		
public partial class PresenceServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "mmmpresence";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_mmmpresence._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;


	}

/// <summary>
/// Direct API class for PresenceService.
/// </summary>		
public partial class PresenceServiceDirect: PresenceServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public PresenceService Service {get; set;}


		}




	// Transaction Classes

	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class PresenceFromClient : Goedel.Protocol.Request {
    /// <summary>
    ///Monotonically increasing counter used to prevent replay
    ///attacks on client request.
    /// </summary>

	[JsonPropertyName("Serial")]
	public virtual int?					Serial  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Acknowledge")]
	public virtual int?					Acknowledge  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Serial", 
					(data, value) => {(data as PresenceFromClient).Serial = value;}, 
					data => (data as PresenceFromClient).Serial ),
		new PropertyInteger32 ("Acknowledge", 
					(data, value) => {(data as PresenceFromClient).Acknowledge = value;}, 
					data => (data as PresenceFromClient).Acknowledge )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceFromClient> _binding = new (
			new() {
			{ "Serial", _properties [0]},
			{ "Acknowledge", _properties [1]}}, __Tag,
		() => new PresenceFromClient(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceFromClient";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceFromClient();

	}


	/// <summary>
	///
	/// Register connection request. 
	/// </summary>
public partial class PresenceConnectRequest : PresenceFromClient {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceConnectRequest> _binding = new (
			new() {}, __Tag,
		() => new PresenceConnectRequest(), () => [], () => [], PresenceFromClient._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceConnectRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceConnectRequest();

	}


	/// <summary>
	/// </summary>
public partial class PresenceHeartbeat : PresenceFromClient {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceHeartbeat> _binding = new (
			new() {}, __Tag,
		() => new PresenceHeartbeat(), () => [], () => [], PresenceFromClient._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceHeartbeat";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceHeartbeat();

	}


	/// <summary>
	/// </summary>
public partial class PresenceEndpointRequest : PresenceFromClient {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceEndpointRequest> _binding = new (
			new() {}, __Tag,
		() => new PresenceEndpointRequest(), () => [], () => [], PresenceFromClient._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceEndpointRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceEndpointRequest();

	}


	/// <summary>
	/// </summary>
public partial class PresenceAcknowledge : PresenceFromClient {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceAcknowledge> _binding = new (
			new() {}, __Tag,
		() => new PresenceAcknowledge(), () => [], () => [], PresenceFromClient._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceAcknowledge";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceAcknowledge();

	}


	/// <summary>
	/// </summary>
public partial class PresenceResolveRequest : PresenceFromClient {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DnsRequest")]
	public virtual byte[]?					DnsRequest  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("DnsRequest", 
					(data, value) => {(data as PresenceResolveRequest).DnsRequest = value;}, 
					data => (data as PresenceResolveRequest).DnsRequest )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceResolveRequest> _binding = new (
			new() {
			{ "DnsRequest", _properties [0]}}, __Tag,
		() => new PresenceResolveRequest(), () => [], () => [], PresenceFromClient._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceResolveRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceResolveRequest();

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class PresenceFromService : Goedel.Protocol.Response {
    /// <summary>
    /// </summary>

	[JsonPropertyName("EndPoint")]
	public virtual UdpEndpoint?					EndPoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Now")]
	public virtual DateTime?					Now  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Acknowledge")]
	public virtual int?					Acknowledge  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EndPoint", typeof (UdpEndpoint),
					(data, value) => {(data as PresenceFromService).EndPoint = value as UdpEndpoint;}, 
					data => (data as PresenceFromService).EndPoint,
					false, ()=>new  UdpEndpoint(), ()=>new UdpEndpoint()),
		new PropertyDateTime ("Now", 
					(data, value) => {(data as PresenceFromService).Now = value;}, 
					data => (data as PresenceFromService).Now ),
		new PropertyInteger32 ("Acknowledge", 
					(data, value) => {(data as PresenceFromService).Acknowledge = value;}, 
					data => (data as PresenceFromService).Acknowledge )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceFromService> _binding = new (
			new() {
			{ "EndPoint", _properties [0]},
			{ "Now", _properties [1]},
			{ "Acknowledge", _properties [2]}}, __Tag,
		() => new PresenceFromService(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceFromService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceFromService();

	}


	/// <summary>
	///
	/// Return the result of a connection request
	/// </summary>
public partial class PresenceConnectResponse : PresenceFromService {
    /// <summary>
    ///The time after which the presence service will start to 
    ///assume the device has disconnected in milliseconds.
    /// </summary>

	[JsonPropertyName("ConnectionTimeout")]
	public virtual int?					ConnectionTimeout  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("ConnectionTimeout", 
					(data, value) => {(data as PresenceConnectResponse).ConnectionTimeout = value;}, 
					data => (data as PresenceConnectResponse).ConnectionTimeout )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceConnectResponse> _binding = new (
			new() {
			{ "ConnectionTimeout", _properties [0]}}, __Tag,
		() => new PresenceConnectResponse(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceConnectResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceConnectResponse();

	}


	/// <summary>
	/// </summary>
public partial class PresenceErrorInvalidSerial : PresenceFromService {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Serial")]
	public virtual int?					Serial  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Serial", 
					(data, value) => {(data as PresenceErrorInvalidSerial).Serial = value;}, 
					data => (data as PresenceErrorInvalidSerial).Serial )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceErrorInvalidSerial> _binding = new (
			new() {
			{ "Serial", _properties [0]}}, __Tag,
		() => new PresenceErrorInvalidSerial(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceErrorInvalidSerial";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceErrorInvalidSerial();

	}


	/// <summary>
	/// </summary>
public partial class PresenceStatus : PresenceFromService {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceStatus> _binding = new (
			new() {}, __Tag,
		() => new PresenceStatus(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceStatus();

	}


	/// <summary>
	/// </summary>
public partial class PresenceEndpointResponse : PresenceFromService {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceEndpointResponse> _binding = new (
			new() {}, __Tag,
		() => new PresenceEndpointResponse(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceEndpointResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceEndpointResponse();

	}


	/// <summary>
	/// </summary>
public partial class PresenceNotify : PresenceFromService {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Bitmask")]
	public virtual byte[]?					Bitmask  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Serial")]
	public virtual int?					Serial  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Bitmask", 
					(data, value) => {(data as PresenceNotify).Bitmask = value;}, 
					data => (data as PresenceNotify).Bitmask ),
		new PropertyInteger32 ("Serial", 
					(data, value) => {(data as PresenceNotify).Serial = value;}, 
					data => (data as PresenceNotify).Serial )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceNotify> _binding = new (
			new() {
			{ "Bitmask", _properties [0]},
			{ "Serial", _properties [1]}}, __Tag,
		() => new PresenceNotify(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceNotify";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceNotify();

	}


	/// <summary>
	/// </summary>
public partial class PresenceResolveResponse : PresenceFromService {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DnsResponse")]
	public virtual byte[]?					DnsResponse  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("DnsResponse", 
					(data, value) => {(data as PresenceResolveResponse).DnsResponse = value;}, 
					data => (data as PresenceResolveResponse).DnsResponse )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PresenceResolveResponse> _binding = new (
			new() {
			{ "DnsResponse", _properties [0]}}, __Tag,
		() => new PresenceResolveResponse(), () => [], () => [], PresenceFromService._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceResolveResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceResolveResponse();

	}


	/// <summary>
	/// </summary>
public partial class SessionRequest : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Options")]
	public virtual List<string>?					Options  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("Inbound")]
	public virtual UdpEndpoint?					Inbound  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Protocol", 
					(data, value) => {(data as SessionRequest).Protocol = value;}, 
					data => (data as SessionRequest).Protocol ),
		new PropertyListString ("Options", 
					(data, value) => {(data as SessionRequest).Options = value;}, 
					data => (data as SessionRequest).Options ),
		new PropertyStruct ("Inbound", typeof (UdpEndpoint),
					(data, value) => {(data as SessionRequest).Inbound = value as UdpEndpoint;}, 
					data => (data as SessionRequest).Inbound,
					false, ()=>new  UdpEndpoint(), ()=>new UdpEndpoint()),
		new PropertyDateTime ("Expires", 
					(data, value) => {(data as SessionRequest).Expires = value;}, 
					data => (data as SessionRequest).Expires )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SessionRequest> _binding = new (
			new() {
			{ "Protocol", _properties [0]},
			{ "Options", _properties [1]},
			{ "Inbound", _properties [2]},
			{ "Expires", _properties [3]}}, __Tag,
		() => new SessionRequest(), () => [], () => [], Message._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionRequest();

	}


	/// <summary>
	/// </summary>
public partial class SessionResponse : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Accept")]
	public virtual bool?					Accept  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Options")]
	public virtual List<string>?					Options  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("Inbound")]
	public virtual UdpEndpoint?					Inbound  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Accept", 
					(data, value) => {(data as SessionResponse).Accept = value;}, 
					data => (data as SessionResponse).Accept ),
		new PropertyString ("Protocol", 
					(data, value) => {(data as SessionResponse).Protocol = value;}, 
					data => (data as SessionResponse).Protocol ),
		new PropertyListString ("Options", 
					(data, value) => {(data as SessionResponse).Options = value;}, 
					data => (data as SessionResponse).Options ),
		new PropertyStruct ("Inbound", typeof (UdpEndpoint),
					(data, value) => {(data as SessionResponse).Inbound = value as UdpEndpoint;}, 
					data => (data as SessionResponse).Inbound,
					false, ()=>new  UdpEndpoint(), ()=>new UdpEndpoint())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SessionResponse> _binding = new (
			new() {
			{ "Accept", _properties [0]},
			{ "Protocol", _properties [1]},
			{ "Options", _properties [2]},
			{ "Inbound", _properties [3]}}, __Tag,
		() => new SessionResponse(), () => [], () => [], Message._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionResponse();

	}


	/// <summary>
	/// </summary>
public partial class SessionEndpoint : PresenceProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("IpAddress")]
	public virtual byte[]?					IpAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Port")]
	public virtual int?					Port  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Options")]
	public virtual List<string>?					Options  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("IpAddress", 
					(data, value) => {(data as SessionEndpoint).IpAddress = value;}, 
					data => (data as SessionEndpoint).IpAddress ),
		new PropertyInteger32 ("Port", 
					(data, value) => {(data as SessionEndpoint).Port = value;}, 
					data => (data as SessionEndpoint).Port ),
		new PropertyString ("Protocol", 
					(data, value) => {(data as SessionEndpoint).Protocol = value;}, 
					data => (data as SessionEndpoint).Protocol ),
		new PropertyListString ("Options", 
					(data, value) => {(data as SessionEndpoint).Options = value;}, 
					data => (data as SessionEndpoint).Options )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<SessionEndpoint> _binding = new (
			new() {
			{ "IpAddress", _properties [0]},
			{ "Port", _properties [1]},
			{ "Protocol", _properties [2]},
			{ "Options", _properties [3]}}, __Tag,
		() => new SessionEndpoint(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionEndpoint";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionEndpoint();

	}


	/// <summary>
	/// </summary>
public partial class UdpEndpoint : PresenceProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("IpAddress")]
	public virtual byte[]?					IpAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Port")]
	public virtual int?					Port  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("IpAddress", 
					(data, value) => {(data as UdpEndpoint).IpAddress = value;}, 
					data => (data as UdpEndpoint).IpAddress ),
		new PropertyInteger32 ("Port", 
					(data, value) => {(data as UdpEndpoint).Port = value;}, 
					data => (data as UdpEndpoint).Port )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UdpEndpoint> _binding = new (
			new() {
			{ "IpAddress", _properties [0]},
			{ "Port", _properties [1]}}, __Tag,
		() => new UdpEndpoint(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "UdpEndpoint";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UdpEndpoint();

	}



