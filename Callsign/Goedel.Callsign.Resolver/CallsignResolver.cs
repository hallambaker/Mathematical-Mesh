﻿
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
//  This file was automatically generated at 27-May-22 12:53:11 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.971
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
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
using Goedel.Callsign.Registry;
using Goedel.Callsign;


namespace Goedel.Callsign.Resolver;


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
	    {"QueryResponse", QueryResponse._Factory}
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
				{"Query", QueryRequest._Factory}
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
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual QueryResponse Query (QueryRequest request) =>
			JpcSession.Post("Query", request) as QueryResponse;


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
    public override QueryResponse Query (QueryRequest request) =>
			Service.Query (request, JpcSession);


		}




	// Transaction Classes
	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class ResolverRequest : Goedel.Protocol.Request {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Goedel.Protocol.Request)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class ResolverResponse : Goedel.Protocol.Response {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((Goedel.Protocol.Response)this).SerializeX(_writer, false, ref _first);
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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

	public virtual string						CallSign  {get; set;}
        /// <summary>
        ///The registration identifier of a registration in the log.
        /// </summary>

	public virtual string						RegistrationId  {get; set;}
        /// <summary>
        ///The unique identifier of an append only log whose signed Notarization
        ///entry is requested.
        /// </summary>

	public virtual string						LogId  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "CallSign", new MetaDataString(
				delegate (string _a) {  CallSign = _a; },
				() => CallSign) } ,
			{ "RegistrationId", new MetaDataString(
				delegate (string _a) {  RegistrationId = _a; },
				() => RegistrationId) } ,
			{ "LogId", new MetaDataString(
				delegate (string _a) {  LogId = _a; },
				() => LogId) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResolverRequest)this).SerializeX(_writer, false, ref _first);
		if (CallSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CallSign", 1);
				_writer.WriteString (CallSign);
			}
		if (RegistrationId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("RegistrationId", 1);
				_writer.WriteString (RegistrationId);
			}
		if (LogId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("LogId", 1);
				_writer.WriteString (LogId);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CallSign" : {
				CallSign = jsonReader.ReadString ();
				break;
				}
			case "RegistrationId" : {
				RegistrationId = jsonReader.ReadString ();
				break;
				}
			case "LogId" : {
				LogId = jsonReader.ReadString ();
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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

	public virtual Enveloped<Registration>						Result  {get; set;}
        /// <summary>
        ///The latest notarization entry corresponding to the specified log.
        /// </summary>

	public virtual Enveloped<Notarization>						Notarization  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Result", new MetaDataStruct(
				delegate (object _a) {  Result = _a as Enveloped<Registration>; },
				() => Result,
				"Enveloped<Registration>" )} ,
			{ "Notarization", new MetaDataStruct(
				delegate (object _a) {  Notarization = _a as Enveloped<Notarization>; },
				() => Notarization,
				"Enveloped<Notarization>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
    /// Serialize this object to the specified output stream.
    /// </summary>
    /// <param name="writer">Output stream</param>
    /// <param name="wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="first">If true, item is the first entry in a list.</param>
	public override void Serialize (Writer writer, bool wrap, ref bool first) =>
		SerializeX (writer, wrap, ref first);


    /// <summary>
    /// Serialize this object to the specified output stream.
    /// Unlike the Serlialize() method, this method is not inherited from the
    /// parent class allowing a specific version of the method to be called.
    /// </summary>
    /// <param name="_writer">Output stream</param>
    /// <param name="_wrap">If true, output is wrapped with object
    /// start and end sequences '{ ... }'.</param>
    /// <param name="_first">If true, item is the first entry in a list.</param>
	public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
		PreEncode();
		if (_wrap) {
			_writer.WriteObjectStart ();
			}
		((ResolverResponse)this).SerializeX(_writer, false, ref _first);
		if (Result != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Result", 1);
				Result.Serialize (_writer, false);
			}
		if (Notarization != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Notarization", 1);
				Notarization.Serialize (_writer, false);
			}
		if (_wrap) {
			_writer.WriteObjectEnd ();
			}
		}

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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Result" : {
				// An untagged structure
				Result = new Enveloped<Registration> ();
				Result.Deserialize (jsonReader);
 
				break;
				}
			case "Notarization" : {
				// An untagged structure
				Notarization = new Enveloped<Notarization> ();
				Notarization.Deserialize (jsonReader);
 
				break;
				}
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}



