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
//  This file was automatically generated at 20-May-22 5:55:46 PM
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


namespace Goedel.Repository;


	/// <summary>
	///
	/// Callsign Registrar protocol supporting query function.
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class PersistanceProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PersistanceProtocol";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ProfileRepository", ProfileRepository._Factory},
	    {"CatalogedRepository", CatalogedRepository._Factory},
	    {"ActivationApplicationRepository", ActivationApplicationRepository._Factory},
	    {"ApplicationEntryRepository", ApplicationEntryRepository._Factory},
	    {"PersistanceRequest", PersistanceRequest._Factory},
	    {"PersistanceResponse", PersistanceResponse._Factory},
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
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual QueryResponse Query (QueryRequest request) =>
			JpcSession.Post("Query", request) as QueryResponse;


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
    public override QueryResponse Query (QueryRequest request) =>
			Service.Query (request, JpcSession);


		}




	// Transaction Classes
	/// <summary>
	///
	/// Describes a Repository issuer.
	/// </summary>
public partial class ProfileRepository : ProfileAccount {

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
	public new const string __Tag = "ProfileRepository";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileRepository();


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
		((ProfileAccount)this).SerializeX(_writer, false, ref _first);
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
    public static new ProfileRepository FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileRepository;
			}
		var Result = new ProfileRepository ();
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
	/// </summary>
public partial class CatalogedRepository : CatalogedApplication {
        /// <summary>
        ///The connection allowing control of the registry.
        /// </summary>

	public virtual Enveloped<ConnectionStripped>						EnvelopedConnectionAddress  {get; set;}
        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileRepository  {get; set;}
        /// <summary>
        ///The activation data for the registry.
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedConnectionAddress", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionAddress = _a as Enveloped<ConnectionStripped>; },
				() => EnvelopedConnectionAddress,
				"Enveloped<ConnectionStripped>" )} ,
			{ "EnvelopedProfileRepository", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileRepository = _a as Enveloped<ProfileAccount>; },
				() => EnvelopedProfileRepository,
				"Enveloped<ProfileAccount>" )} ,
			{ "EnvelopedActivationCommon", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivationCommon = _a as Enveloped<ActivationCommon>; },
				() => EnvelopedActivationCommon,
				"Enveloped<ActivationCommon>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedConnectionAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionAddress", 1);
				EnvelopedConnectionAddress.Serialize (_writer, false);
			}
		if (EnvelopedProfileRepository != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileRepository", 1);
				EnvelopedProfileRepository.Serialize (_writer, false);
			}
		if (EnvelopedActivationCommon != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivationCommon", 1);
				EnvelopedActivationCommon.Serialize (_writer, false);
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
    public static new CatalogedRepository FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedRepository;
			}
		var Result = new CatalogedRepository ();
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
			case "EnvelopedConnectionAddress" : {
				// An untagged structure
				EnvelopedConnectionAddress = new Enveloped<ConnectionStripped> ();
				EnvelopedConnectionAddress.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedProfileRepository" : {
				// An untagged structure
				EnvelopedProfileRepository = new Enveloped<ProfileAccount> ();
				EnvelopedProfileRepository.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedActivationCommon" : {
				// An untagged structure
				EnvelopedActivationCommon = new Enveloped<ActivationCommon> ();
				EnvelopedActivationCommon.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ActivationApplicationRepository : ActivationApplication {
        /// <summary>
        ///Key used to decrypt registry messages.
        /// </summary>

	public virtual KeyData						AccountEncryption  {get; set;}
        /// <summary>
        ///Key or capability used to sign the registry log
        /// </summary>

	public virtual KeyData						AdministratorSignature  {get; set;}
        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountEncryption", new MetaDataStruct(
				delegate (object _a) {  AccountEncryption = _a as KeyData; },
				() => AccountEncryption,
				"KeyData" )} ,
			{ "AdministratorSignature", new MetaDataStruct(
				delegate (object _a) {  AdministratorSignature = _a as KeyData; },
				() => AdministratorSignature,
				"KeyData" )} ,
			{ "EnvelopedConnectionService", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionService = _a as Enveloped<ConnectionService>; },
				() => EnvelopedConnectionService,
				"Enveloped<ConnectionService>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationApplication)this).SerializeX(_writer, false, ref _first);
		if (AccountEncryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountEncryption", 1);
				AccountEncryption.Serialize (_writer, false);
			}
		if (AdministratorSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AdministratorSignature", 1);
				AdministratorSignature.Serialize (_writer, false);
			}
		if (EnvelopedConnectionService != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionService", 1);
				EnvelopedConnectionService.Serialize (_writer, false);
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
    public static new ActivationApplicationRepository FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationRepository;
			}
		var Result = new ActivationApplicationRepository ();
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
			case "AccountEncryption" : {
				// An untagged structure
				AccountEncryption = new KeyData ();
				AccountEncryption.Deserialize (jsonReader);
 
				break;
				}
			case "AdministratorSignature" : {
				// An untagged structure
				AdministratorSignature = new KeyData ();
				AdministratorSignature.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedConnectionService" : {
				// An untagged structure
				EnvelopedConnectionService = new Enveloped<ConnectionService> ();
				EnvelopedConnectionService.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ApplicationEntryRepository : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationRepository>						EnvelopedActivation  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedActivation", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivation = _a as Enveloped<ActivationApplicationRepository>; },
				() => EnvelopedActivation,
				"Enveloped<ActivationApplicationRepository>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ApplicationEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedActivation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivation", 1);
				EnvelopedActivation.Serialize (_writer, false);
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
    public static new ApplicationEntryRepository FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryRepository;
			}
		var Result = new ApplicationEntryRepository ();
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
			case "EnvelopedActivation" : {
				// An untagged structure
				EnvelopedActivation = new Enveloped<ActivationApplicationRepository> ();
				EnvelopedActivation.Deserialize (jsonReader);
 
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
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class PersistanceRequest : Goedel.Protocol.Request {

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
	public new const string __Tag = "PersistanceRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersistanceRequest();


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
    public static new PersistanceRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PersistanceRequest;
			}
		var Result = new PersistanceRequest ();
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
public partial class PersistanceResponse : Goedel.Protocol.Response {

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
	public new const string __Tag = "PersistanceResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersistanceResponse();


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
    public static new PersistanceResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PersistanceResponse;
			}
		var Result = new PersistanceResponse ();
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
	/// Register connection request. 
	/// </summary>
public partial class QueryRequest : PersistanceRequest {

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
		((PersistanceRequest)this).SerializeX(_writer, false, ref _first);
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
	/// Return the result of a connection request
	/// </summary>
public partial class QueryResponse : PersistanceResponse {

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
		((PersistanceResponse)this).SerializeX(_writer, false, ref _first);
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
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}


