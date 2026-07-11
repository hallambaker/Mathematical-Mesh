
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
//  This file was automatically generated at 7/11/2026 2:07:20 PM
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(Request), Request._binding},
	    {typeof(Response), Response._binding},
	    {typeof(Version), Version._binding},
	    {typeof(Encoding), Encoding._binding},
	    {typeof(HelloRequest), HelloRequest._binding},
	    {typeof(HelloResponse), HelloResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static BaseMessage() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

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

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;} //

    /// <summary>
    ///Optional unique transaction request used to detect replay attacks and 
    ///duplicates.
    /// </summary>

	[JsonPropertyName("ID")]
	public virtual byte[]?					ID  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Service", 
					(data, value) => {(data as Request).Service = value;}, 
					data => (data as Request).Service ),
		new PropertyBinary ("ID", 
					(data, value) => {(data as Request).ID = value;}, 
					data => (data as Request).ID )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Request> _binding = new (
			new() {
			{ "Service", _properties [0]},
			{ "ID", _properties [1]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("Status")]
	public virtual int?					Status  {get; set;} //

    /// <summary>
    ///Application level status report giving additional information.
    /// </summary>

	[JsonPropertyName("StatusExtended")]
	public virtual int?					StatusExtended  {get; set;} //

    /// <summary>
    ///Text description of the status return code for debugging 
    ///and log file use.
    /// </summary>

	[JsonPropertyName("StatusDescription")]
	public virtual string?					StatusDescription  {get; set;} //

    /// <summary>
    ///The request to which the response corresponds.
    /// </summary>

	[JsonPropertyName("ID")]
	public virtual byte[]?					ID  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Status", 
					(data, value) => {(data as Response).Status = value;}, 
					data => (data as Response).Status ),
		new PropertyInteger32 ("StatusExtended", 
					(data, value) => {(data as Response).StatusExtended = value;}, 
					data => (data as Response).StatusExtended ),
		new PropertyString ("StatusDescription", 
					(data, value) => {(data as Response).StatusDescription = value;}, 
					data => (data as Response).StatusDescription ),
		new PropertyBinary ("ID", 
					(data, value) => {(data as Response).ID = value;}, 
					data => (data as Response).ID )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Response> _binding = new (
			new() {
			{ "Status", _properties [0]},
			{ "StatusExtended", _properties [1]},
			{ "StatusDescription", _properties [2]},
			{ "ID", _properties [3]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Describes a protocol version.
	/// </summary>
public partial class Version : BaseMessage {
    /// <summary>
    ///Major version number of the service protocol. A higher
    /// </summary>

	[JsonPropertyName("Major")]
	public virtual int?					Major  {get; set;} //

    /// <summary>
    ///Minor version number of the service protocol.
    /// </summary>

	[JsonPropertyName("Minor")]
	public virtual int?					Minor  {get; set;} //

    /// <summary>
    ///Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B)
    ///supported by the service. If no encodings are specified, the
    ///JSON encoding is assumed.
    /// </summary>

	[JsonPropertyName("Encodings")]
	public virtual List<Encoding>?					Encodings  {get; set;}
    /// <summary>
    ///The preferred URI for this service. This MAY be used to effect
    ///a redirect in the case that a service moves.
    /// </summary>

	[JsonPropertyName("URI")]
	public virtual List<string>?					URI  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Major", 
					(data, value) => {(data as Version).Major = value;}, 
					data => (data as Version).Major ),
		new PropertyInteger32 ("Minor", 
					(data, value) => {(data as Version).Minor = value;}, 
					data => (data as Version).Minor ),
		new PropertyListStruct ("Encodings", typeof (Encoding),
					(data, value) => {(data as Version).Encodings = value as List<Encoding>;}, 
					data => (data as Version).Encodings,
					false, ()=>new  List<Encoding>(), ()=>new Encoding()),
		new PropertyListString ("URI", 
					(data, value) => {(data as Version).URI = value;}, 
					data => (data as Version).URI )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Version> _binding = new (
			new() {
			{ "Major", _properties [0]},
			{ "Minor", _properties [1]},
			{ "Encodings", _properties [2]},
			{ "URI", _properties [3]}}, __Tag,
		() => new Version(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Describes a message content encoding.
	/// </summary>
public partial class Encoding : BaseMessage {
    /// <summary>
    ///The IANA encoding name
    /// </summary>

	[JsonPropertyName("ID")]
	public virtual List<string>?					ID  {get; set;}
    /// <summary>
    ///For encodings that employ a named dictionary for tag or data
    ///compression, the name of the dictionary as defined by that 
    ///encoding scheme. 
    /// </summary>

	[JsonPropertyName("Dictionary")]
	public virtual List<string>?					Dictionary  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("ID", 
					(data, value) => {(data as Encoding).ID = value;}, 
					data => (data as Encoding).ID ),
		new PropertyListString ("Dictionary", 
					(data, value) => {(data as Encoding).Dictionary = value;}, 
					data => (data as Encoding).Dictionary )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Encoding> _binding = new (
			new() {
			{ "ID", _properties [0]},
			{ "Dictionary", _properties [1]}}, __Tag,
		() => new Encoding(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Request service description.
	/// </summary>
public partial class HelloRequest : Request {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<HelloRequest> _binding = new (
			new() {}, __Tag,
		() => new HelloRequest(), () => [], () => [], Request._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Always reports success. Describes the configuration of the service.
	/// </summary>
public partial class HelloResponse : Response {
    /// <summary>
    ///Enumerates the protocol versions supported
    /// </summary>

	[JsonPropertyName("Version")]
	public virtual Version?					Version  {get; set;} //

    /// <summary>
    ///Enumerates alternate protocol version(s) supported
    /// </summary>

	[JsonPropertyName("Alternates")]
	public virtual List<Version>?					Alternates  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Version", typeof (Version),
					(data, value) => {(data as HelloResponse).Version = value as Version;}, 
					data => (data as HelloResponse).Version,
					false, ()=>new  Version(), ()=>new Version()),
		new PropertyListStruct ("Alternates", typeof (Version),
					(data, value) => {(data as HelloResponse).Alternates = value as List<Version>;}, 
					data => (data as HelloResponse).Alternates,
					false, ()=>new  List<Version>(), ()=>new Version())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<HelloResponse> _binding = new (
			new() {
			{ "Version", _properties [0]},
			{ "Alternates", _properties [1]}}, __Tag,
		() => new HelloResponse(), () => [], () => [], Response._binding, Generic: false);


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

	}



