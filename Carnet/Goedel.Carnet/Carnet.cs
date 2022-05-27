
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
//  This file was automatically generated at 27-May-22 7:23:29 PM
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


namespace Goedel.Carnet;


	/// <summary>
	///
	/// Carnet Ledger Protocol maintaining a record of carnet accounts.
	/// </summary>
public abstract partial class CarnetProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CarnetProtocol";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ProfileCarnet", ProfileCarnet._Factory},
	    {"CatalogedCarnet", CatalogedCarnet._Factory},
	    {"CarnetRequest", CarnetRequest._Factory},
	    {"CarnetResponse", CarnetResponse._Factory}
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
public abstract partial class CarnetService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "carnet";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_carnet._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, JsonFactoryDelegate>  GetTagDictionary() => _TagDictionary;
		
	static Dictionary<string, JsonFactoryDelegate> _TagDictionary = new () {
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
	public const string WellKnown = "carnet";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_carnet._tcp";

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
	/// Describes a carnet issuer.
	/// </summary>
public partial class ProfileCarnet : ProfileService {

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
	public new const string __Tag = "ProfileCarnet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileCarnet();


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
		((ProfileService)this).SerializeX(_writer, false, ref _first);
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
    public static new ProfileCarnet FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileCarnet;
			}
		var Result = new ProfileCarnet ();
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
public partial class CatalogedCarnet : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string						Key  {get; set;}
        /// <summary>
        ///The connection allowing control of the registry.
        /// </summary>

	public virtual Enveloped<ConnectionStripped>						EnvelopedConnectionAddress  {get; set;}
        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileCarnet>						EnvelopedProfileCarnet  {get; set;}
        /// <summary>
        ///The activation data for the registry.
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Key", new MetaDataString(
				delegate (string _a) {  Key = _a; },
				() => Key) } ,
			{ "EnvelopedConnectionAddress", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionAddress = _a as Enveloped<ConnectionStripped>; },
				() => EnvelopedConnectionAddress,
				"Enveloped<ConnectionStripped>" )} ,
			{ "EnvelopedProfileCarnet", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileCarnet = _a as Enveloped<ProfileCarnet>; },
				() => EnvelopedProfileCarnet,
				"Enveloped<ProfileCarnet>" )} ,
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
	public new const string __Tag = "CatalogedCarnet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedCarnet();


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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (EnvelopedConnectionAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionAddress", 1);
				EnvelopedConnectionAddress.Serialize (_writer, false);
			}
		if (EnvelopedProfileCarnet != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileCarnet", 1);
				EnvelopedProfileCarnet.Serialize (_writer, false);
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
    public static new CatalogedCarnet FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedCarnet;
			}
		var Result = new CatalogedCarnet ();
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
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedConnectionAddress" : {
				// An untagged structure
				EnvelopedConnectionAddress = new Enveloped<ConnectionStripped> ();
				EnvelopedConnectionAddress.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedProfileCarnet" : {
				// An untagged structure
				EnvelopedProfileCarnet = new Enveloped<ProfileCarnet> ();
				EnvelopedProfileCarnet.Deserialize (jsonReader);
 
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
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class CarnetRequest : Goedel.Protocol.Request {

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
	public new const string __Tag = "CarnetRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CarnetRequest();


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
    public static new CarnetRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CarnetRequest;
			}
		var Result = new CarnetRequest ();
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
public partial class CarnetResponse : Goedel.Protocol.Response {

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
	public new const string __Tag = "CarnetResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CarnetResponse();


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
    public static new CarnetResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CarnetResponse;
			}
		var Result = new CarnetResponse ();
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



