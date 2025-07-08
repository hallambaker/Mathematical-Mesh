
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
//  This file was automatically generated at 7/8/2025 6:34:50 PM
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

using Goedel.Mesh;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.ServiceAdmin;


namespace Goedel.Mesh.Management;


	/// <summary>
	///
	/// Web service providing server management interface.
	/// </summary>
public abstract partial class ServiceManagement : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceManagement";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(WsmpRequest), WsmpRequest._binding},
	    {typeof(WsmpResponse), WsmpResponse._binding},
	    {typeof(ServiceConfigRequest), ServiceConfigRequest._binding},
	    {typeof(ServiceConfigResponse), ServiceConfigResponse._binding},
	    {typeof(ServiceStatusRequest), ServiceStatusRequest._binding},
	    {typeof(ServiceStatusResponse), ServiceStatusResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static ServiceManagement() {
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
public abstract partial class ServiceManagementService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "wsmp";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_wmsmp._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, Type>  GetTagDictionary => _TagDictionary;
		
	static Dictionary<string, Type> _TagDictionary = new () {
				{"ServiceConfig", typeof(ServiceConfigRequest)},
				{"ServiceStatus", typeof(ServiceStatusRequest)}
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		"ServiceConfig" => ServiceConfig(request as ServiceConfigRequest, session),
		"ServiceStatus" => ServiceStatus(request as ServiceStatusRequest, session),
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new ServiceManagementServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    /// <summary>
	/// Base method for implementing the transaction ServiceConfig.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract ServiceConfigResponse ServiceConfig (
            ServiceConfigRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction ServiceStatus.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract ServiceStatusResponse ServiceStatus (
            ServiceStatusRequest request, IJpcSession session);

    }

/// <summary>
/// Client class for ServiceManagementService.
/// </summary>		
public partial class ServiceManagementServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "wsmp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_wmsmp._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;

    /// <summary>
	/// Implement the transaction ServiceConfig.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public ServiceConfigResponse ServiceConfig (ServiceConfigRequest request) =>
			ServiceConfigAsync (request).Sync();

    /// <summary>
	/// Implement the transaction ServiceConfig asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<ServiceConfigResponse> ServiceConfigAsync (ServiceConfigRequest request) =>
			await JpcSession.PostAsync("ServiceConfig", request) as ServiceConfigResponse;

    /// <summary>
	/// Implement the transaction ServiceStatus.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public ServiceStatusResponse ServiceStatus (ServiceStatusRequest request) =>
			ServiceStatusAsync (request).Sync();

    /// <summary>
	/// Implement the transaction ServiceStatus asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<ServiceStatusResponse> ServiceStatusAsync (ServiceStatusRequest request) =>
			await JpcSession.PostAsync("ServiceStatus", request) as ServiceStatusResponse;


	}

/// <summary>
/// Direct API class for ServiceManagementService.
/// </summary>		
public partial class ServiceManagementServiceDirect: ServiceManagementServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public ServiceManagementService Service {get; set;}


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<ServiceConfigResponse> ServiceConfigAsync (ServiceConfigRequest request) =>
			Task.FromResult(Service.ServiceConfig (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<ServiceStatusResponse> ServiceStatusAsync (ServiceStatusRequest request) =>
			Task.FromResult(Service.ServiceStatus (request, JpcSession));


		}




	// Transaction Classes

	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
public partial class WsmpRequest : Goedel.Protocol.Request {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<WsmpRequest> _binding = new (
			new() {}, __Tag,
		() => new WsmpRequest(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "WsmpRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new WsmpRequest();

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class WsmpResponse : Goedel.Protocol.Response {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<WsmpResponse> _binding = new (
			new() {}, __Tag,
		() => new WsmpResponse(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "WsmpResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new WsmpResponse();

	}


	/// <summary>
	/// </summary>
public partial class ServiceConfigRequest : WsmpRequest {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceConfigRequest> _binding = new (
			new() {}, __Tag,
		() => new ServiceConfigRequest(), () => [], () => [], WsmpRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceConfigRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceConfigRequest();

	}


	/// <summary>
	/// </summary>
public partial class ServiceConfigResponse : WsmpResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceConfigResponse> _binding = new (
			new() {}, __Tag,
		() => new ServiceConfigResponse(), () => [], () => [], WsmpResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceConfigResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceConfigResponse();

	}


	/// <summary>
	/// </summary>
public partial class ServiceStatusRequest : WsmpRequest {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceStatusRequest> _binding = new (
			new() {}, __Tag,
		() => new ServiceStatusRequest(), () => [], () => [], WsmpRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceStatusRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceStatusRequest();

	}


	/// <summary>
	/// </summary>
public partial class ServiceStatusResponse : WsmpResponse {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Start")]
	public virtual DateTime?					Start  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("End")]
	public virtual DateTime?					End  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Started")]
	public virtual int?					Started  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Completed")]
	public virtual int?					Completed  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Pending")]
	public virtual int?					Pending  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDateTime ("Start", 
					(IBinding data, DateTime? value) => {(data as ServiceStatusResponse).Start = value;}, 
					(IBinding data) => (data as ServiceStatusResponse).Start ),
		new PropertyDateTime ("End", 
					(IBinding data, DateTime? value) => {(data as ServiceStatusResponse).End = value;}, 
					(IBinding data) => (data as ServiceStatusResponse).End ),
		new PropertyInteger32 ("Started", 
					(IBinding data, int? value) => {(data as ServiceStatusResponse).Started = value;}, 
					(IBinding data) => (data as ServiceStatusResponse).Started ),
		new PropertyInteger32 ("Completed", 
					(IBinding data, int? value) => {(data as ServiceStatusResponse).Completed = value;}, 
					(IBinding data) => (data as ServiceStatusResponse).Completed ),
		new PropertyInteger32 ("Pending", 
					(IBinding data, int? value) => {(data as ServiceStatusResponse).Pending = value;}, 
					(IBinding data) => (data as ServiceStatusResponse).Pending )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceStatusResponse> _binding = new (
			new() {
			{ "Start", _properties [0]},
			{ "End", _properties [1]},
			{ "Started", _properties [2]},
			{ "Completed", _properties [3]},
			{ "Pending", _properties [4]}}, __Tag,
		() => new ServiceStatusResponse(), () => [], () => [], WsmpResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ServiceStatusResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceStatusResponse();

	}



