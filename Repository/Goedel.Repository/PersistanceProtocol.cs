
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
//  This file was automatically generated at 7/8/2025 6:34:22 PM
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


namespace Goedel.Repository;


	/// <summary>
	///
	/// Provides a repository service permitting 
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class RepositoryProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "RepositoryProtocol";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(ProfileRepository), ProfileRepository._binding},
	    {typeof(CatalogedRepository), CatalogedRepository._binding},
	    {typeof(ActivationApplicationRepository), ActivationApplicationRepository._binding},
	    {typeof(ApplicationEntryRepository), ApplicationEntryRepository._binding},
	    {typeof(PersistanceRequest), PersistanceRequest._binding},
	    {typeof(PersistanceResponse), PersistanceResponse._binding},
	    {typeof(QueryRequest), QueryRequest._binding},
	    {typeof(QueryResponse), QueryResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static RepositoryProtocol() {
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
public abstract partial class RepositoryService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "repository";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_repository._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, Type>  GetTagDictionary => _TagDictionary;
		
	static Dictionary<string, Type> _TagDictionary = new () {
				{"Query", typeof(QueryRequest)}
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		"Query" => Query(request as QueryRequest, session),
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new RepositoryServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    /// <summary>
	/// Base method for implementing the transaction Query.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract QueryResponse Query (
            QueryRequest request, IJpcSession session);

    }

/// <summary>
/// Client class for RepositoryService.
/// </summary>		
public partial class RepositoryServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "repository";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_repository._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;

    /// <summary>
	/// Implement the transaction Query.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public QueryResponse Query (QueryRequest request) =>
			QueryAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Query asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<QueryResponse> QueryAsync (QueryRequest request) =>
			await JpcSession.PostAsync("Query", request) as QueryResponse;


	}

/// <summary>
/// Direct API class for RepositoryService.
/// </summary>		
public partial class RepositoryServiceDirect: RepositoryServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public RepositoryService Service {get; set;}


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<QueryResponse> QueryAsync (QueryRequest request) =>
			Task.FromResult(Service.Query (request, JpcSession));


		}




	// Transaction Classes

	/// <summary>
	///
	/// Describes a Repository issuer.
	/// </summary>
public partial class ProfileRepository : ProfileAccount {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileRepository> _binding = new (
			new() {}, __Tag,
		() => new ProfileRepository(), () => [], () => [], ProfileAccount._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ProfileRepository";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileRepository();

	}


	/// <summary>
	/// </summary>
public partial class CatalogedRepository : CatalogedApplication {
    /// <summary>
    ///The connection allowing control of the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;} //

    /// <summary>
    ///The Mesh profile
    /// </summary>

	[JsonPropertyName("EnvelopedProfileRepository")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileRepository  {get; set;} //

    /// <summary>
    ///The activation data for the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EnvelopedConnectionAddress", typeof (Enveloped<ConnectionStripped>),
					(IBinding data, object? value) => {(data as CatalogedRepository).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, 
					(IBinding data) => (data as CatalogedRepository).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>()),
		new PropertyStruct ("EnvelopedProfileRepository", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as CatalogedRepository).EnvelopedProfileRepository = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as CatalogedRepository).EnvelopedProfileRepository,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyStruct ("EnvelopedActivationCommon", typeof (Enveloped<ActivationCommon>),
					(IBinding data, object? value) => {(data as CatalogedRepository).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, 
					(IBinding data) => (data as CatalogedRepository).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedRepository> _binding = new (
			new() {
			{ "EnvelopedConnectionAddress", _properties [0]},
			{ "EnvelopedProfileRepository", _properties [1]},
			{ "EnvelopedActivationCommon", _properties [2]}}, __Tag,
		() => new CatalogedRepository(), () => [], () => [], CatalogedApplication._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogedRepository";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedRepository();

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationRepository : ActivationApplication {
    /// <summary>
    ///Key used to decrypt registry messages.
    /// </summary>

	[JsonPropertyName("AccountEncryption")]
	public virtual KeyData?					AccountEncryption  {get; set;} //

    /// <summary>
    ///Key or capability used to sign the registry log
    /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;} //

    /// <summary>
    ///Signed connection service delegation allowing the device to
    ///access the account.
    /// </summary>

	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("AccountEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationRepository).AccountEncryption = value as KeyData;}, 
					(IBinding data) => (data as ActivationApplicationRepository).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationRepository).AdministratorSignature = value as KeyData;}, 
					(IBinding data) => (data as ActivationApplicationRepository).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("EnvelopedConnectionService", typeof (Enveloped<ConnectionService>),
					(IBinding data, object? value) => {(data as ActivationApplicationRepository).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, 
					(IBinding data) => (data as ActivationApplicationRepository).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationRepository> _binding = new (
			new() {
			{ "AccountEncryption", _properties [0]},
			{ "AdministratorSignature", _properties [1]},
			{ "EnvelopedConnectionService", _properties [2]}}, __Tag,
		() => new ActivationApplicationRepository(), () => [], () => [], ActivationApplication._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ActivationApplicationRepository";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationRepository();

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryRepository : ApplicationEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationRepository>?					EnvelopedActivation  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationRepository>),
					(IBinding data, object? value) => {(data as ApplicationEntryRepository).EnvelopedActivation = value as Enveloped<ActivationApplicationRepository>;}, 
					(IBinding data) => (data as ApplicationEntryRepository).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationRepository>(), ()=>new Enveloped<ActivationApplicationRepository>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryRepository> _binding = new (
			new() {
			{ "EnvelopedActivation", _properties [0]}}, __Tag,
		() => new ApplicationEntryRepository(), () => [], () => [], ApplicationEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "ApplicationEntryRepository";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryRepository();

	}


	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class PersistanceRequest : Goedel.Protocol.Request {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PersistanceRequest> _binding = new (
			new() {}, __Tag,
		() => new PersistanceRequest(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PersistanceRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersistanceRequest();

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class PersistanceResponse : Goedel.Protocol.Response {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PersistanceResponse> _binding = new (
			new() {}, __Tag,
		() => new PersistanceResponse(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PersistanceResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersistanceResponse();

	}


	/// <summary>
	///
	/// Register connection request. 
	/// </summary>
public partial class QueryRequest : PersistanceRequest {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<QueryRequest> _binding = new (
			new() {}, __Tag,
		() => new QueryRequest(), () => [], () => [], PersistanceRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "QueryRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new QueryRequest();

	}


	/// <summary>
	///
	/// Return the result of a connection request
	/// </summary>
public partial class QueryResponse : PersistanceResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<QueryResponse> _binding = new (
			new() {}, __Tag,
		() => new QueryResponse(), () => [], () => [], PersistanceResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "QueryResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new QueryResponse();

	}



