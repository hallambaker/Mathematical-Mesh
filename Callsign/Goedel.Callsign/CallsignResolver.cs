
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
//  This file was automatically generated at 5/12/2024 3:59:51 PM
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
using Goedel.Callsign;


namespace Goedel.Callsign;


	/// <summary>
	///
	/// Callsign Registrar protocol supporting query function.
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class CallsignResolver : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignResolver";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ResolverRequest", ResolverRequest._Factory},
	    {"ResolverResponse", ResolverResponse._Factory},
	    {"QueryRequest", QueryRequest._Factory},
	    {"QueryResponse", QueryResponse._Factory},
	    {"SyncRequest", SyncRequest._Factory},
	    {"SyncResponse", SyncResponse._Factory}
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


/// <summary>
/// The new base class for the client and service side APIs.
/// </summary>		
public abstract partial class ResolverService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "callsignreg";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_callsignreg._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, JsonFactoryDelegate>  GetTagDictionary() => _TagDictionary;
		
	static Dictionary<string, JsonFactoryDelegate> _TagDictionary = new () {
				{"Query", QueryRequest._Factory},
				{"Sync", SyncRequest._Factory}
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		"Query" => Query(request as QueryRequest, session),
		"Sync" => Sync(request as SyncRequest, session),
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new ResolverServiceDirect () {
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

    /// <summary>
	/// Base method for implementing the transaction Sync.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract SyncResponse Sync (
            SyncRequest request, IJpcSession session);

    }

/// <summary>
/// Client class for ResolverService.
/// </summary>		
public partial class ResolverServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "callsignreg";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_callsignreg._tcp";

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

    /// <summary>
	/// Implement the transaction Sync.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public SyncResponse Sync (SyncRequest request) =>
			SyncAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Sync asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<SyncResponse> SyncAsync (SyncRequest request) =>
			await JpcSession.PostAsync("Sync", request) as SyncResponse;


	}

/// <summary>
/// Direct API class for ResolverService.
/// </summary>		
public partial class ResolverServiceDirect: ResolverServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public ResolverService Service {get; set;}


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<QueryResponse> QueryAsync (QueryRequest request) =>
			Task.FromResult(Service.Query (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<SyncResponse> SyncAsync (SyncRequest request) =>
			Task.FromResult(Service.Sync (request, JpcSession));


		}




	// Transaction Classes
	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class ResolverRequest : Goedel.Protocol.Request {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ResolverRequest(), Goedel.Protocol.Request._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.Request._StaticAllProperties);


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
	public new const string __Tag = "ResolverRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResolverRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResolverRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResolverRequest;
			}
		var Result = new ResolverRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class ResolverResponse : Goedel.Protocol.Response {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ResolverResponse(), Goedel.Protocol.Response._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.Response._StaticAllProperties);


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
	public new const string __Tag = "ResolverResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResolverResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResolverResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResolverResponse;
			}
		var Result = new ResolverResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request resolution of a profile bound to a callsign or registration identifier. 
	/// </summary>
public partial class QueryRequest : ResolverRequest {
        /// <summary>
        ///The callsign being requested in canonical form.
        /// </summary>

	public virtual string?						CallSign  {get; set;}

        /// <summary>
        ///The registration identifier of a registration in the log.
        /// </summary>

	public virtual string?						RegistrationId  {get; set;}

        /// <summary>
        ///The unique identifier of an append only log whose signed Notarization
        ///entry is requested.
        /// </summary>

	public virtual string?						LogId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new QueryRequest(), ResolverRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallSign", new PropertyString ("CallSign", 
					(IBinding data, string? value) => {(data as QueryRequest).CallSign = value;}, (IBinding data) => (data as QueryRequest).CallSign )},
			{ "RegistrationId", new PropertyString ("RegistrationId", 
					(IBinding data, string? value) => {(data as QueryRequest).RegistrationId = value;}, (IBinding data) => (data as QueryRequest).RegistrationId )},
			{ "LogId", new PropertyString ("LogId", 
					(IBinding data, string? value) => {(data as QueryRequest).LogId = value;}, (IBinding data) => (data as QueryRequest).LogId )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResolverRequest._StaticAllProperties);


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
	public new const string __Tag = "QueryRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new QueryRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new QueryRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as QueryRequest;
			}
		var Result = new QueryRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Return the result of a QueryRequest
	/// </summary>
public partial class QueryResponse : ResolverResponse {
        /// <summary>
        ///The registration specified in the result (if found).	
        /// </summary>

	public virtual Enveloped<Registration>?						Result  {get; set;}

        /// <summary>
        ///The latest notarization entry corresponding to the specified log.
        /// </summary>

	public virtual Enveloped<Notarization>?						Notarization  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new QueryResponse(), ResolverResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new PropertyStruct ("Result", 
					(IBinding data, object? value) => {(data as QueryResponse).Result = value as Enveloped<Registration>;}, (IBinding data) => (data as QueryResponse).Result,
					false, ()=>new  Enveloped<Registration>(), ()=>new Enveloped<Registration>())} ,
			{ "Notarization", new PropertyStruct ("Notarization", 
					(IBinding data, object? value) => {(data as QueryResponse).Notarization = value as Enveloped<Notarization>;}, (IBinding data) => (data as QueryResponse).Notarization,
					false, ()=>new  Enveloped<Notarization>(), ()=>new Enveloped<Notarization>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResolverResponse._StaticAllProperties);


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
	public new const string __Tag = "QueryResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new QueryResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new QueryResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as QueryResponse;
			}
		var Result = new QueryResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class SyncRequest : ResolverRequest {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new SyncRequest(), ResolverRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResolverRequest._StaticAllProperties);


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
	public new const string __Tag = "SyncRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SyncRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SyncRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SyncRequest;
			}
		var Result = new SyncRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class SyncResponse : ResolverResponse {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new SyncResponse(), ResolverResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ResolverResponse._StaticAllProperties);


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
	public new const string __Tag = "SyncResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SyncResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SyncResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SyncResponse;
			}
		var Result = new SyncResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



