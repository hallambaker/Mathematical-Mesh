
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
//  This file was automatically generated at 9/5/2024 2:07:25 AM
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



namespace Goedel.Protocol;


	/// <summary>
	///
	/// Base class for all PROTOGEN messages
	/// </summary>
public abstract partial class BaseMessage : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "BaseMessage";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Request", Request._Factory},
	    {"Response", Response._Factory},
	    {"Version", Version._Factory},
	    {"Encoding", Encoding._Factory},
	    {"HelloRequest", HelloRequest._Factory},
	    {"HelloResponse", HelloResponse._Factory}
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
	/// Base class for all request messages.
	/// </summary>
abstract public partial class Request : BaseMessage {
        /// <summary>
        ///Name of the Service to which the request is directed.
        /// </summary>

	public virtual string?						Service  {get; set;}

        /// <summary>
        ///Optional unique transaction request used to detect replay attacks and 
        ///duplicates.
        /// </summary>

	public virtual byte[]?						ID  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as Request).Service = value;}, (IBinding data) => (data as Request).Service )},
			{ "ID", new PropertyBinary ("ID", 
					(IBinding data, byte[]? value) => {(data as Request).ID = value;}, (IBinding data) => (data as Request).ID )}
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
	public new const string __Tag = "Request";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Request FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Request;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// A service MAY return either the response message specified
	/// for that transaction or any parent of that message. 
	/// Thus the RecryptResponse message MAY be returned in response 
	/// to any request.
	/// </summary>
abstract public partial class Response : BaseMessage {
        /// <summary>
        ///Major status return code. The SMTP/HTTP scheme of 2xx = Success,
        ///3xx = incomplete, 4xx = failure is followed.
        /// </summary>

	public virtual int?						Status  {get; set;}

        /// <summary>
        ///Application level status report giving additional information.
        /// </summary>

	public virtual int?						StatusExtended  {get; set;}

        /// <summary>
        ///Text description of the status return code for debugging 
        ///and log file use.
        /// </summary>

	public virtual string?						StatusDescription  {get; set;}

        /// <summary>
        ///The request to which the response corresponds.
        /// </summary>

	public virtual byte[]?						ID  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Status", new PropertyInteger32 ("Status", 
					(IBinding data, int? value) => {(data as Response).Status = value;}, (IBinding data) => (data as Response).Status )},
			{ "StatusExtended", new PropertyInteger32 ("StatusExtended", 
					(IBinding data, int? value) => {(data as Response).StatusExtended = value;}, (IBinding data) => (data as Response).StatusExtended )},
			{ "StatusDescription", new PropertyString ("StatusDescription", 
					(IBinding data, string? value) => {(data as Response).StatusDescription = value;}, (IBinding data) => (data as Response).StatusDescription )},
			{ "ID", new PropertyBinary ("ID", 
					(IBinding data, byte[]? value) => {(data as Response).ID = value;}, (IBinding data) => (data as Response).ID )}
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
	public new const string __Tag = "Response";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Response FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Response;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Describes a protocol version.
	/// </summary>
public partial class Version : BaseMessage {
        /// <summary>
        ///Major version number of the service protocol. A higher
        /// </summary>

	public virtual int?						Major  {get; set;}

        /// <summary>
        ///Minor version number of the service protocol.
        /// </summary>

	public virtual int?						Minor  {get; set;}

        /// <summary>
        ///Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B)
        ///supported by the service. If no encodings are specified, the
        ///JSON encoding is assumed.
        /// </summary>

	public virtual List<Encoding>?					Encodings  {get; set;}
        /// <summary>
        ///The preferred URI for this service. This MAY be used to effect
        ///a redirect in the case that a service moves.
        /// </summary>

	public virtual List<string>?					URI  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Version(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Major", new PropertyInteger32 ("Major", 
					(IBinding data, int? value) => {(data as Version).Major = value;}, (IBinding data) => (data as Version).Major )},
			{ "Minor", new PropertyInteger32 ("Minor", 
					(IBinding data, int? value) => {(data as Version).Minor = value;}, (IBinding data) => (data as Version).Minor )},
			{ "Encodings", new PropertyListStruct ("Encodings", 
					(IBinding data, object? value) => {(data as Version).Encodings = value as List<Encoding>;}, (IBinding data) => (data as Version).Encodings,
					false, ()=>new  List<Encoding>(), ()=>new Encoding())} ,
			{ "URI", new PropertyListString ("URI", 
					(IBinding data, List<string>? value) => {(data as Version).URI = value;}, (IBinding data) => (data as Version).URI )}
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
	public new const string __Tag = "Version";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Version();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Version FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Version;
			}
		var Result = new Version ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a message content encoding.
	/// </summary>
public partial class Encoding : BaseMessage {
        /// <summary>
        ///The IANA encoding name
        /// </summary>

	public virtual List<string>?					ID  {get; set;}
        /// <summary>
        ///For encodings that employ a named dictionary for tag or data
        ///compression, the name of the dictionary as defined by that 
        ///encoding scheme. 
        /// </summary>

	public virtual List<string>?					Dictionary  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Encoding(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ID", new PropertyListString ("ID", 
					(IBinding data, List<string>? value) => {(data as Encoding).ID = value;}, (IBinding data) => (data as Encoding).ID )},
			{ "Dictionary", new PropertyListString ("Dictionary", 
					(IBinding data, List<string>? value) => {(data as Encoding).Dictionary = value;}, (IBinding data) => (data as Encoding).Dictionary )}
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
	public new const string __Tag = "Encoding";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Encoding();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Encoding FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Encoding;
			}
		var Result = new Encoding ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request service description.
	/// </summary>
public partial class HelloRequest : Request {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new HelloRequest(), Request._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Request._StaticAllProperties);


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
	public new const string __Tag = "HelloRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new HelloRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new HelloRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as HelloRequest;
			}
		var Result = new HelloRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Always reports success. Describes the configuration of the service.
	/// </summary>
public partial class HelloResponse : Response {
        /// <summary>
        ///Enumerates the protocol versions supported
        /// </summary>

	public virtual Version?						Version  {get; set;}

        /// <summary>
        ///Enumerates alternate protocol version(s) supported
        /// </summary>

	public virtual List<Version>?					Alternates  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new HelloResponse(), Response._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Version", new PropertyStruct ("Version", 
					(IBinding data, object? value) => {(data as HelloResponse).Version = value as Version;}, (IBinding data) => (data as HelloResponse).Version,
					false, ()=>new  Version(), ()=>new Version())} ,
			{ "Alternates", new PropertyListStruct ("Alternates", 
					(IBinding data, object? value) => {(data as HelloResponse).Alternates = value as List<Version>;}, (IBinding data) => (data as HelloResponse).Alternates,
					false, ()=>new  List<Version>(), ()=>new Version())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Response._StaticAllProperties);


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
	public new const string __Tag = "HelloResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new HelloResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new HelloResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as HelloResponse;
			}
		var Result = new HelloResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



