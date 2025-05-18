
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
//  This file was automatically generated at 5/18/2025 6:29:53 PM
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
using Goedel.Mesh.Client;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Shell;


	/// <summary>
	///
	/// Classes to be used to test serialization an deserialization.
	/// </summary>
public abstract partial class MeshmanShellResult : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshmanShellResult";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Result", Result._Factory},
	    {"ResultAbout", ResultAbout._Factory},
	    {"ResultFail", ResultFail._Factory},
	    {"ResultHello", ResultHello._Factory},
	    {"ResultSelf", ResultSelf._Factory},
	    {"ResultInfo", ResultInfo._Factory},
	    {"ResultKey", ResultKey._Factory},
	    {"ResultDigest", ResultDigest._Factory},
	    {"ResultFile", ResultFile._Factory},
	    {"ResultKeyFile", ResultKeyFile._Factory},
	    {"ResultListLog", ResultListLog._Factory},
	    {"ResultLog", ResultLog._Factory},
	    {"ResultArchive", ResultArchive._Factory},
	    {"ResultFileDare", ResultFileDare._Factory},
	    {"ResultFileEARL", ResultFileEARL._Factory},
	    {"ResultDump", ResultDump._Factory},
	    {"ResultList", ResultList._Factory},
	    {"ResultAccountConnect", ResultAccountConnect._Factory},
	    {"ResultPublish", ResultPublish._Factory},
	    {"ResultPublishDevice", ResultPublishDevice._Factory},
	    {"ResultCreateDevice", ResultCreateDevice._Factory},
	    {"ResultCreatePersonal", ResultCreatePersonal._Factory},
	    {"ResultCreateAccount", ResultCreateAccount._Factory},
	    {"ResultDeleteAccount", ResultDeleteAccount._Factory},
	    {"ResultRegisterService", ResultRegisterService._Factory},
	    {"ResultRecover", ResultRecover._Factory},
	    {"ResultStatus", ResultStatus._Factory},
	    {"ResultSync", ResultSync._Factory},
	    {"ResultEscrow", ResultEscrow._Factory},
	    {"ResultMachine", ResultMachine._Factory},
	    {"ResultPIN", ResultPIN._Factory},
	    {"ResultSequence", ResultSequence._Factory},
	    {"LogEntry", LogEntry._Factory},
	    {"ResultEntry", ResultEntry._Factory},
	    {"ResultEntrySent", ResultEntrySent._Factory},
	    {"ResultMail", ResultMail._Factory},
	    {"ResultSSH", ResultSSH._Factory},
	    {"ResultGroupCreate", ResultGroupCreate._Factory},
	    {"ResultSent", ResultSent._Factory},
	    {"ResultPending", ResultPending._Factory},
	    {"ResultAuthorize", ResultAuthorize._Factory},
	    {"ResultProcess", ResultProcess._Factory},
	    {"ResultConnect", ResultConnect._Factory},
	    {"ResultTransactionRequest", ResultTransactionRequest._Factory},
	    {"ResultReceived", ResultReceived._Factory},
	    {"ResultApplication", ResultApplication._Factory},
	    {"ResultApplicationList", ResultApplicationList._Factory},
	    {"ResultCallsign", ResultCallsign._Factory},
	    {"ResultCallsignResolution", ResultCallsignResolution._Factory},
	    {"ResultCallsignList", ResultCallsignList._Factory}
		};


	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(Result), Result._binding},
	    {typeof(ResultAbout), ResultAbout._binding},
	    {typeof(ResultFail), ResultFail._binding},
	    {typeof(ResultHello), ResultHello._binding},
	    {typeof(ResultSelf), ResultSelf._binding},
	    {typeof(ResultInfo), ResultInfo._binding},
	    {typeof(ResultKey), ResultKey._binding},
	    {typeof(ResultDigest), ResultDigest._binding},
	    {typeof(ResultFile), ResultFile._binding},
	    {typeof(ResultKeyFile), ResultKeyFile._binding},
	    {typeof(ResultListLog), ResultListLog._binding},
	    {typeof(ResultLog), ResultLog._binding},
	    {typeof(ResultArchive), ResultArchive._binding},
	    {typeof(ResultFileDare), ResultFileDare._binding},
	    {typeof(ResultFileEARL), ResultFileEARL._binding},
	    {typeof(ResultDump), ResultDump._binding},
	    {typeof(ResultList), ResultList._binding},
	    {typeof(ResultAccountConnect), ResultAccountConnect._binding},
	    {typeof(ResultPublish), ResultPublish._binding},
	    {typeof(ResultPublishDevice), ResultPublishDevice._binding},
	    {typeof(ResultCreateDevice), ResultCreateDevice._binding},
	    {typeof(ResultCreatePersonal), ResultCreatePersonal._binding},
	    {typeof(ResultCreateAccount), ResultCreateAccount._binding},
	    {typeof(ResultDeleteAccount), ResultDeleteAccount._binding},
	    {typeof(ResultRegisterService), ResultRegisterService._binding},
	    {typeof(ResultRecover), ResultRecover._binding},
	    {typeof(ResultStatus), ResultStatus._binding},
	    {typeof(ResultSync), ResultSync._binding},
	    {typeof(ResultEscrow), ResultEscrow._binding},
	    {typeof(ResultMachine), ResultMachine._binding},
	    {typeof(ResultPIN), ResultPIN._binding},
	    {typeof(ResultSequence), ResultSequence._binding},
	    {typeof(LogEntry), LogEntry._binding},
	    {typeof(ResultEntry), ResultEntry._binding},
	    {typeof(ResultEntrySent), ResultEntrySent._binding},
	    {typeof(ResultMail), ResultMail._binding},
	    {typeof(ResultSSH), ResultSSH._binding},
	    {typeof(ResultGroupCreate), ResultGroupCreate._binding},
	    {typeof(ResultSent), ResultSent._binding},
	    {typeof(ResultPending), ResultPending._binding},
	    {typeof(ResultAuthorize), ResultAuthorize._binding},
	    {typeof(ResultProcess), ResultProcess._binding},
	    {typeof(ResultConnect), ResultConnect._binding},
	    {typeof(ResultTransactionRequest), ResultTransactionRequest._binding},
	    {typeof(ResultReceived), ResultReceived._binding},
	    {typeof(ResultApplication), ResultApplication._binding},
	    {typeof(ResultApplicationList), ResultApplicationList._binding},
	    {typeof(ResultCallsign), ResultCallsign._binding},
	    {typeof(ResultCallsignResolution), ResultCallsignResolution._binding},
	    {typeof(ResultCallsignList), ResultCallsignList._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static MeshmanShellResult() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _tagDictionary);
		AddDictionary(ref _bindingDictionary);
		}


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
	/// Placeholder class to allow insertion of application specific properties.
	/// </summary>
public partial class Result : ShellResult {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Result> _binding = new (
			new() {

        }, __Tag,() => new Result(), () => new List<Result>(), () => new Dictionary<string,Result>(),ShellResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ShellResult._binding, _binding);


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
	public new const string __Tag = "Result";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Result();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Result FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Result;
			}
		var Result = new Result ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultAbout : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("DirectoryKeys")]
	public virtual string?					DirectoryKeys  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("DirectoryMesh")]
	public virtual string?					DirectoryMesh  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AssemblyTitle")]
	public virtual string?					AssemblyTitle  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AssemblyDescription")]
	public virtual string?					AssemblyDescription  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AssemblyCopyright")]
	public virtual string?					AssemblyCopyright  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AssemblyCompany")]
	public virtual string?					AssemblyCompany  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AssemblyVersion")]
	public virtual string?					AssemblyVersion  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Build")]
	public virtual string?					Build  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAbout> _binding = new (
			new() {

			{ "DirectoryKeys", new PropertyString ("DirectoryKeys", 
					(IBinding data, string? value) => {(data as ResultAbout).DirectoryKeys = value;}, (IBinding data) => (data as ResultAbout).DirectoryKeys )},
			{ "DirectoryMesh", new PropertyString ("DirectoryMesh", 
					(IBinding data, string? value) => {(data as ResultAbout).DirectoryMesh = value;}, (IBinding data) => (data as ResultAbout).DirectoryMesh )},
			{ "AssemblyTitle", new PropertyString ("AssemblyTitle", 
					(IBinding data, string? value) => {(data as ResultAbout).AssemblyTitle = value;}, (IBinding data) => (data as ResultAbout).AssemblyTitle )},
			{ "AssemblyDescription", new PropertyString ("AssemblyDescription", 
					(IBinding data, string? value) => {(data as ResultAbout).AssemblyDescription = value;}, (IBinding data) => (data as ResultAbout).AssemblyDescription )},
			{ "AssemblyCopyright", new PropertyString ("AssemblyCopyright", 
					(IBinding data, string? value) => {(data as ResultAbout).AssemblyCopyright = value;}, (IBinding data) => (data as ResultAbout).AssemblyCopyright )},
			{ "AssemblyCompany", new PropertyString ("AssemblyCompany", 
					(IBinding data, string? value) => {(data as ResultAbout).AssemblyCompany = value;}, (IBinding data) => (data as ResultAbout).AssemblyCompany )},
			{ "AssemblyVersion", new PropertyString ("AssemblyVersion", 
					(IBinding data, string? value) => {(data as ResultAbout).AssemblyVersion = value;}, (IBinding data) => (data as ResultAbout).AssemblyVersion )},
			{ "Build", new PropertyString ("Build", 
					(IBinding data, string? value) => {(data as ResultAbout).Build = value;}, (IBinding data) => (data as ResultAbout).Build )}
        }, __Tag,() => new ResultAbout(), () => new List<ResultAbout>(), () => new Dictionary<string,ResultAbout>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultAbout";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAbout();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAbout FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAbout;
			}
		var Result = new ResultAbout ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultFail : Result {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFail> _binding = new (
			new() {

        }, __Tag,() => new ResultFail(), () => new List<ResultFail>(), () => new Dictionary<string,ResultFail>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultFail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFail;
			}
		var Result = new ResultFail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultHello : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Response")]
	public virtual MeshHelloResponse?					Response  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultHello> _binding = new (
			new() {

			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as ResultHello).ServiceAddress = value;}, (IBinding data) => (data as ResultHello).ServiceAddress )},
			{ "Response", new PropertyStruct ("Response", typeof (MeshHelloResponse),
					(IBinding data, object? value) => {(data as ResultHello).Response = value as MeshHelloResponse;}, (IBinding data) => (data as ResultHello).Response,
					false, ()=>new  MeshHelloResponse(), ()=>new MeshHelloResponse())}
        }, __Tag,() => new ResultHello(), () => new List<ResultHello>(), () => new Dictionary<string,ResultHello>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultHello";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultHello();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultHello FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultHello;
			}
		var Result = new ResultHello ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultSelf : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Contact")]
	public virtual JsContact?					Contact  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Locator")]
	public virtual string?					Locator  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Earl")]
	public virtual string?					Earl  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSelf> _binding = new (
			new() {

			{ "Contact", new PropertyStruct ("Contact", typeof (JsContact),
					(IBinding data, object? value) => {(data as ResultSelf).Contact = value as JsContact;}, (IBinding data) => (data as ResultSelf).Contact,
					false, ()=>new  JsContact(), ()=>new JsContact())},
			{ "Locator", new PropertyString ("Locator", 
					(IBinding data, string? value) => {(data as ResultSelf).Locator = value;}, (IBinding data) => (data as ResultSelf).Locator )},
			{ "Earl", new PropertyString ("Earl", 
					(IBinding data, string? value) => {(data as ResultSelf).Earl = value;}, (IBinding data) => (data as ResultSelf).Earl )}
        }, __Tag,() => new ResultSelf(), () => new List<ResultSelf>(), () => new Dictionary<string,ResultSelf>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultSelf";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSelf();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSelf FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSelf;
			}
		var Result = new ResultSelf ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultInfo : Result {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultInfo> _binding = new (
			new() {

        }, __Tag,() => new ResultInfo(), () => new List<ResultInfo>(), () => new Dictionary<string,ResultInfo>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultInfo";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultInfo();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultInfo FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultInfo;
			}
		var Result = new ResultInfo ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultKey : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Shares")]
	public virtual List<string>?					Shares  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultKey> _binding = new (
			new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as ResultKey).Key = value;}, (IBinding data) => (data as ResultKey).Key )},
			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as ResultKey).Identifier = value;}, (IBinding data) => (data as ResultKey).Identifier )},
			{ "Shares", new PropertyListString ("Shares", 
					(IBinding data, List<string>? value) => {(data as ResultKey).Shares = value;}, (IBinding data) => (data as ResultKey).Shares )}
        }, __Tag,() => new ResultKey(), () => new List<ResultKey>(), () => new Dictionary<string,ResultKey>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultKey";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultKey();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultKey FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultKey;
			}
		var Result = new ResultKey ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultDigest : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Digest")]
	public virtual string?					Digest  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Verified")]
	public virtual bool?					Verified  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDigest> _binding = new (
			new() {

			{ "Digest", new PropertyString ("Digest", 
					(IBinding data, string? value) => {(data as ResultDigest).Digest = value;}, (IBinding data) => (data as ResultDigest).Digest )},
			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as ResultDigest).Key = value;}, (IBinding data) => (data as ResultDigest).Key )},
			{ "Verified", new PropertyBoolean ("Verified", 
					(IBinding data, bool? value) => {(data as ResultDigest).Verified = value;}, (IBinding data) => (data as ResultDigest).Verified )}
        }, __Tag,() => new ResultDigest(), () => new List<ResultDigest>(), () => new Dictionary<string,ResultDigest>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultDigest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDigest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDigest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDigest;
			}
		var Result = new ResultDigest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultFile : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("TotalBytes")]
	public virtual int?					TotalBytes  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Verified")]
	public virtual bool?					Verified  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFile> _binding = new (
			new() {

			{ "Filename", new PropertyString ("Filename", 
					(IBinding data, string? value) => {(data as ResultFile).Filename = value;}, (IBinding data) => (data as ResultFile).Filename )},
			{ "TotalBytes", new PropertyInteger32 ("TotalBytes", 
					(IBinding data, int? value) => {(data as ResultFile).TotalBytes = value;}, (IBinding data) => (data as ResultFile).TotalBytes )},
			{ "Verified", new PropertyBoolean ("Verified", 
					(IBinding data, bool? value) => {(data as ResultFile).Verified = value;}, (IBinding data) => (data as ResultFile).Verified )}
        }, __Tag,() => new ResultFile(), () => new List<ResultFile>(), () => new Dictionary<string,ResultFile>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultFile";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFile();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFile;
			}
		var Result = new ResultFile ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultKeyFile : ResultFile {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Private")]
	public virtual bool?					Private  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Algorithm")]
	public virtual string?					Algorithm  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Format")]
	public virtual string?					Format  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultKeyFile> _binding = new (
			new() {

			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as ResultKeyFile).Udf = value;}, (IBinding data) => (data as ResultKeyFile).Udf )},
			{ "Private", new PropertyBoolean ("Private", 
					(IBinding data, bool? value) => {(data as ResultKeyFile).Private = value;}, (IBinding data) => (data as ResultKeyFile).Private )},
			{ "Algorithm", new PropertyString ("Algorithm", 
					(IBinding data, string? value) => {(data as ResultKeyFile).Algorithm = value;}, (IBinding data) => (data as ResultKeyFile).Algorithm )},
			{ "Format", new PropertyString ("Format", 
					(IBinding data, string? value) => {(data as ResultKeyFile).Format = value;}, (IBinding data) => (data as ResultKeyFile).Format )}
        }, __Tag,() => new ResultKeyFile(), () => new List<ResultKeyFile>(), () => new Dictionary<string,ResultKeyFile>(),ResultFile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultFile._binding, _binding);


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
	public new const string __Tag = "ResultKeyFile";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultKeyFile();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultKeyFile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultKeyFile;
			}
		var Result = new ResultKeyFile ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultListLog : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Count")]
	public virtual int?					Count  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultListLog> _binding = new (
			new() {

			{ "Filename", new PropertyString ("Filename", 
					(IBinding data, string? value) => {(data as ResultListLog).Filename = value;}, (IBinding data) => (data as ResultListLog).Filename )},
			{ "Count", new PropertyInteger32 ("Count", 
					(IBinding data, int? value) => {(data as ResultListLog).Count = value;}, (IBinding data) => (data as ResultListLog).Count )}
        }, __Tag,() => new ResultListLog(), () => new List<ResultListLog>(), () => new Dictionary<string,ResultListLog>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultListLog";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultListLog();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultListLog FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultListLog;
			}
		var Result = new ResultListLog ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultLog : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Count")]
	public virtual int?					Count  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultLog> _binding = new (
			new() {

			{ "Count", new PropertyInteger32 ("Count", 
					(IBinding data, int? value) => {(data as ResultLog).Count = value;}, (IBinding data) => (data as ResultLog).Count )}
        }, __Tag,() => new ResultLog(), () => new List<ResultLog>(), () => new Dictionary<string,ResultLog>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultLog";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultLog();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultLog FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultLog;
			}
		var Result = new ResultLog ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultArchive : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<FileEntry>?					Entries  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("Frames")]
	public virtual int?					Frames  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Deleted")]
	public virtual int?					Deleted  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("IndexFrame")]
	public virtual int?					IndexFrame  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultArchive> _binding = new (
			new() {

			{ "Entries", new PropertyListStruct ("Entries", typeof (FileEntry),
					(IBinding data, object? value) => {(data as ResultArchive).Entries = value as List<FileEntry>;}, (IBinding data) => (data as ResultArchive).Entries,
					false, ()=>new  List<FileEntry>(), ()=>new FileEntry())},
			{ "Frames", new PropertyInteger32 ("Frames", 
					(IBinding data, int? value) => {(data as ResultArchive).Frames = value;}, (IBinding data) => (data as ResultArchive).Frames )},
			{ "Deleted", new PropertyInteger32 ("Deleted", 
					(IBinding data, int? value) => {(data as ResultArchive).Deleted = value;}, (IBinding data) => (data as ResultArchive).Deleted )},
			{ "IndexFrame", new PropertyInteger32 ("IndexFrame", 
					(IBinding data, int? value) => {(data as ResultArchive).IndexFrame = value;}, (IBinding data) => (data as ResultArchive).IndexFrame )}
        }, __Tag,() => new ResultArchive(), () => new List<ResultArchive>(), () => new Dictionary<string,ResultArchive>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultArchive";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultArchive();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultArchive FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultArchive;
			}
		var Result = new ResultArchive ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultFileDare : ResultFile {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Envelope")]
	public virtual DareEnvelope?					Envelope  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFileDare> _binding = new (
			new() {

			{ "Envelope", new PropertyStruct ("Envelope", typeof (DareEnvelope),
					(IBinding data, object? value) => {(data as ResultFileDare).Envelope = value as DareEnvelope;}, (IBinding data) => (data as ResultFileDare).Envelope,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())}
        }, __Tag,() => new ResultFileDare(), () => new List<ResultFileDare>(), () => new Dictionary<string,ResultFileDare>(),ResultFile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultFile._binding, _binding);


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
	public new const string __Tag = "ResultFileDare";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFileDare();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFileDare FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFileDare;
			}
		var Result = new ResultFileDare ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultFileEARL : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Source")]
	public virtual string?					Source  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Created")]
	public virtual string?					Created  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("URI")]
	public virtual string?					URI  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFileEARL> _binding = new (
			new() {

			{ "Source", new PropertyString ("Source", 
					(IBinding data, string? value) => {(data as ResultFileEARL).Source = value;}, (IBinding data) => (data as ResultFileEARL).Source )},
			{ "Created", new PropertyString ("Created", 
					(IBinding data, string? value) => {(data as ResultFileEARL).Created = value;}, (IBinding data) => (data as ResultFileEARL).Created )},
			{ "URI", new PropertyString ("URI", 
					(IBinding data, string? value) => {(data as ResultFileEARL).URI = value;}, (IBinding data) => (data as ResultFileEARL).URI )}
        }, __Tag,() => new ResultFileEARL(), () => new List<ResultFileEARL>(), () => new Dictionary<string,ResultFileEARL>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultFileEARL";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultFileEARL();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultFileEARL FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultFileEARL;
			}
		var Result = new ResultFileEARL ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultDump : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogedEntries")]
	public virtual List<CatalogedEntry>?					CatalogedEntries  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDump> _binding = new (
			new() {

			{ "CatalogedEntries", new PropertyListStruct ("CatalogedEntries", typeof (CatalogedEntry), 
					(IBinding data, object? value) => {(data as ResultDump).CatalogedEntries = value as List<CatalogedEntry>;}, (IBinding data) => (data as ResultDump).CatalogedEntries,
					true, ()=>new List<CatalogedEntry>()
)} 
        }, __Tag,() => new ResultDump(), () => new List<ResultDump>(), () => new Dictionary<string,ResultDump>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultDump";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDump();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDump FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDump;
			}
		var Result = new ResultDump ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultList : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogedDevices")]
	public virtual List<CatalogedDevice>?					CatalogedDevices  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<Assertion>?					Profiles  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultList> _binding = new (
			new() {

			{ "CatalogedDevices", new PropertyListStruct ("CatalogedDevices", typeof (CatalogedDevice),
					(IBinding data, object? value) => {(data as ResultList).CatalogedDevices = value as List<CatalogedDevice>;}, (IBinding data) => (data as ResultList).CatalogedDevices,
					false, ()=>new  List<CatalogedDevice>(), ()=>new CatalogedDevice())},
			{ "Profiles", new PropertyListStruct ("Profiles", typeof (Assertion), 
					(IBinding data, object? value) => {(data as ResultList).Profiles = value as List<Assertion>;}, (IBinding data) => (data as ResultList).Profiles,
					true, ()=>new List<Assertion>()
)} 
        }, __Tag,() => new ResultList(), () => new List<ResultList>(), () => new Dictionary<string,ResultList>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultList";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultList();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultList FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultList;
			}
		var Result = new ResultList ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultAccountConnect : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("ProfileDevice")]
	public virtual ProfileDevice?					ProfileDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAccountConnect> _binding = new (
			new() {

			{ "ProfileDevice", new PropertyStruct ("ProfileDevice", typeof (ProfileDevice),
					(IBinding data, object? value) => {(data as ResultAccountConnect).ProfileDevice = value as ProfileDevice;}, (IBinding data) => (data as ResultAccountConnect).ProfileDevice,
					false, ()=>new  ProfileDevice(), ()=>new ProfileDevice())}
        }, __Tag,() => new ResultAccountConnect(), () => new List<ResultAccountConnect>(), () => new Dictionary<string,ResultAccountConnect>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultAccountConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAccountConnect();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAccountConnect FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAccountConnect;
			}
		var Result = new ResultAccountConnect ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultPublish : ResultCreateDevice {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPublish> _binding = new (
			new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as ResultPublish).Uri = value;}, (IBinding data) => (data as ResultPublish).Uri )}
        }, __Tag,() => new ResultPublish(), () => new List<ResultPublish>(), () => new Dictionary<string,ResultPublish>(),ResultCreateDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateDevice._binding, _binding);


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
	public new const string __Tag = "ResultPublish";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPublish();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPublish FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPublish;
			}
		var Result = new ResultPublish ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultPublishDevice : ResultCreateDevice {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("FileName")]
	public virtual string?					FileName  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("DevicePreconfigurationPublic")]
	public virtual DevicePreconfigurationPublic?					DevicePreconfigurationPublic  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("DevicePreconfigurationPrivate")]
	public virtual DevicePreconfigurationPrivate?					DevicePreconfigurationPrivate  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPublishDevice> _binding = new (
			new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as ResultPublishDevice).Uri = value;}, (IBinding data) => (data as ResultPublishDevice).Uri )},
			{ "FileName", new PropertyString ("FileName", 
					(IBinding data, string? value) => {(data as ResultPublishDevice).FileName = value;}, (IBinding data) => (data as ResultPublishDevice).FileName )},
			{ "DevicePreconfigurationPublic", new PropertyStruct ("DevicePreconfigurationPublic", typeof (DevicePreconfigurationPublic),
					(IBinding data, object? value) => {(data as ResultPublishDevice).DevicePreconfigurationPublic = value as DevicePreconfigurationPublic;}, (IBinding data) => (data as ResultPublishDevice).DevicePreconfigurationPublic,
					false, ()=>new  DevicePreconfigurationPublic(), ()=>new DevicePreconfigurationPublic())},
			{ "DevicePreconfigurationPrivate", new PropertyStruct ("DevicePreconfigurationPrivate", typeof (DevicePreconfigurationPrivate),
					(IBinding data, object? value) => {(data as ResultPublishDevice).DevicePreconfigurationPrivate = value as DevicePreconfigurationPrivate;}, (IBinding data) => (data as ResultPublishDevice).DevicePreconfigurationPrivate,
					false, ()=>new  DevicePreconfigurationPrivate(), ()=>new DevicePreconfigurationPrivate())}
        }, __Tag,() => new ResultPublishDevice(), () => new List<ResultPublishDevice>(), () => new Dictionary<string,ResultPublishDevice>(),ResultCreateDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateDevice._binding, _binding);


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
	public new const string __Tag = "ResultPublishDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPublishDevice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPublishDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPublishDevice;
			}
		var Result = new ResultPublishDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCreateDevice : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Default")]
	public virtual bool?					Default  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("DeviceUDF")]
	public virtual string?					DeviceUDF  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogedDevice")]
	public virtual CatalogedDevice?					CatalogedDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreateDevice> _binding = new (
			new() {

			{ "Default", new PropertyBoolean ("Default", 
					(IBinding data, bool? value) => {(data as ResultCreateDevice).Default = value;}, (IBinding data) => (data as ResultCreateDevice).Default )},
			{ "DeviceUDF", new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as ResultCreateDevice).DeviceUDF = value;}, (IBinding data) => (data as ResultCreateDevice).DeviceUDF )},
			{ "CatalogedDevice", new PropertyStruct ("CatalogedDevice", typeof (CatalogedDevice),
					(IBinding data, object? value) => {(data as ResultCreateDevice).CatalogedDevice = value as CatalogedDevice;}, (IBinding data) => (data as ResultCreateDevice).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())}
        }, __Tag,() => new ResultCreateDevice(), () => new List<ResultCreateDevice>(), () => new Dictionary<string,ResultCreateDevice>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultCreateDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreateDevice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreateDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreateDevice;
			}
		var Result = new ResultCreateDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCreatePersonal : ResultCreateAccount {
        /// <summary>
        /// </summary>

	[JsonPropertyName("MeshUDF")]
	public virtual string?					MeshUDF  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreatePersonal> _binding = new (
			new() {

			{ "MeshUDF", new PropertyString ("MeshUDF", 
					(IBinding data, string? value) => {(data as ResultCreatePersonal).MeshUDF = value;}, (IBinding data) => (data as ResultCreatePersonal).MeshUDF )}
        }, __Tag,() => new ResultCreatePersonal(), () => new List<ResultCreatePersonal>(), () => new Dictionary<string,ResultCreatePersonal>(),ResultCreateAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateAccount._binding, _binding);


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
	public new const string __Tag = "ResultCreatePersonal";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreatePersonal();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreatePersonal FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreatePersonal;
			}
		var Result = new ResultCreatePersonal ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCreateAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	[JsonPropertyName("ProfileAccount")]
	public virtual ProfileAccount?					ProfileAccount  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ActivationAccount")]
	public virtual ActivationAccount?					ActivationAccount  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreateAccount> _binding = new (
			new() {

			{ "ProfileAccount", new PropertyStruct ("ProfileAccount", typeof (ProfileAccount),
					(IBinding data, object? value) => {(data as ResultCreateAccount).ProfileAccount = value as ProfileAccount;}, (IBinding data) => (data as ResultCreateAccount).ProfileAccount,
					false, ()=>new  ProfileAccount(), ()=>new ProfileAccount())},
			{ "ActivationAccount", new PropertyStruct ("ActivationAccount", typeof (ActivationAccount),
					(IBinding data, object? value) => {(data as ResultCreateAccount).ActivationAccount = value as ActivationAccount;}, (IBinding data) => (data as ResultCreateAccount).ActivationAccount,
					false, ()=>new  ActivationAccount(), ()=>new ActivationAccount())}
        }, __Tag,() => new ResultCreateAccount(), () => new List<ResultCreateAccount>(), () => new Dictionary<string,ResultCreateAccount>(),ResultCreateDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateDevice._binding, _binding);


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
	public new const string __Tag = "ResultCreateAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCreateAccount();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCreateAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCreateAccount;
			}
		var Result = new ResultCreateAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultDeleteAccount : ResultCreateDevice {
        /// <summary>
        /// </summary>

	[JsonPropertyName("UDF")]
	public virtual string?					UDF  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDeleteAccount> _binding = new (
			new() {

			{ "UDF", new PropertyString ("UDF", 
					(IBinding data, string? value) => {(data as ResultDeleteAccount).UDF = value;}, (IBinding data) => (data as ResultDeleteAccount).UDF )}
        }, __Tag,() => new ResultDeleteAccount(), () => new List<ResultDeleteAccount>(), () => new Dictionary<string,ResultDeleteAccount>(),ResultCreateDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateDevice._binding, _binding);


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
	public new const string __Tag = "ResultDeleteAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultDeleteAccount();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultDeleteAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultDeleteAccount;
			}
		var Result = new ResultDeleteAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultRegisterService : ResultCreateAccount {
        /// <summary>
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultRegisterService> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as ResultRegisterService).AccountAddress = value;}, (IBinding data) => (data as ResultRegisterService).AccountAddress )}
        }, __Tag,() => new ResultRegisterService(), () => new List<ResultRegisterService>(), () => new Dictionary<string,ResultRegisterService>(),ResultCreateAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreateAccount._binding, _binding);


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
	public new const string __Tag = "ResultRegisterService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultRegisterService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultRegisterService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultRegisterService;
			}
		var Result = new ResultRegisterService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultRecover : ResultCreatePersonal {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultRecover> _binding = new (
			new() {

        }, __Tag,() => new ResultRecover(), () => new List<ResultRecover>(), () => new Dictionary<string,ResultRecover>(),ResultCreatePersonal._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultCreatePersonal._binding, _binding);


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
	public new const string __Tag = "ResultRecover";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultRecover();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultRecover FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultRecover;
			}
		var Result = new ResultRecover ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultStatus : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("StatusResponse")]
	public virtual StatusResponse?					StatusResponse  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultStatus> _binding = new (
			new() {

			{ "StatusResponse", new PropertyStruct ("StatusResponse", typeof (StatusResponse),
					(IBinding data, object? value) => {(data as ResultStatus).StatusResponse = value as StatusResponse;}, (IBinding data) => (data as ResultStatus).StatusResponse,
					false, ()=>new  StatusResponse(), ()=>new StatusResponse())}
        }, __Tag,() => new ResultStatus(), () => new List<ResultStatus>(), () => new Dictionary<string,ResultStatus>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultStatus();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultStatus FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultStatus;
			}
		var Result = new ResultStatus ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultSync : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Fetched")]
	public virtual long?					Fetched  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ProcessedResults")]
	public virtual int?					ProcessedResults  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ProcessResults")]
	public virtual List<ProcessResult>?					ProcessResults  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSync> _binding = new (
			new() {

			{ "Fetched", new PropertyInteger64 ("Fetched", 
					(IBinding data, long? value) => {(data as ResultSync).Fetched = value;}, (IBinding data) => (data as ResultSync).Fetched )},
			{ "ProcessedResults", new PropertyInteger32 ("ProcessedResults", 
					(IBinding data, int? value) => {(data as ResultSync).ProcessedResults = value;}, (IBinding data) => (data as ResultSync).ProcessedResults )},
			{ "ProcessResults", new PropertyListStruct ("ProcessResults", typeof (ProcessResult), 
					(IBinding data, object? value) => {(data as ResultSync).ProcessResults = value as List<ProcessResult>;}, (IBinding data) => (data as ResultSync).ProcessResults,
					true, ()=>new List<ProcessResult>()
)} 
        }, __Tag,() => new ResultSync(), () => new List<ResultSync>(), () => new Dictionary<string,ResultSync>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultSync";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSync();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSync FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSync;
			}
		var Result = new ResultSync ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultEscrow : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Shares")]
	public virtual List<string>?					Shares  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEscrow> _binding = new (
			new() {

			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as ResultEscrow).Service = value;}, (IBinding data) => (data as ResultEscrow).Service )},
			{ "Shares", new PropertyListString ("Shares", 
					(IBinding data, List<string>? value) => {(data as ResultEscrow).Shares = value;}, (IBinding data) => (data as ResultEscrow).Shares )}
        }, __Tag,() => new ResultEscrow(), () => new List<ResultEscrow>(), () => new Dictionary<string,ResultEscrow>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultEscrow";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEscrow();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEscrow FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEscrow;
			}
		var Result = new ResultEscrow ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultMachine : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogedMachines")]
	public virtual List<CatalogedMachine>?					CatalogedMachines  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultMachine> _binding = new (
			new() {

			{ "CatalogedMachines", new PropertyListStruct ("CatalogedMachines", typeof (CatalogedMachine),
					(IBinding data, object? value) => {(data as ResultMachine).CatalogedMachines = value as List<CatalogedMachine>;}, (IBinding data) => (data as ResultMachine).CatalogedMachines,
					false, ()=>new  List<CatalogedMachine>(), ()=>new CatalogedMachine())}
        }, __Tag,() => new ResultMachine(), () => new List<ResultMachine>(), () => new Dictionary<string,ResultMachine>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultMachine";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultMachine();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultMachine FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultMachine;
			}
		var Result = new ResultMachine ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultPIN : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("MessagePIN")]
	public virtual MessagePin?					MessagePIN  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPIN> _binding = new (
			new() {

			{ "MessagePIN", new PropertyStruct ("MessagePIN", typeof (MessagePin),
					(IBinding data, object? value) => {(data as ResultPIN).MessagePIN = value as MessagePin;}, (IBinding data) => (data as ResultPIN).MessagePIN,
					false, ()=>new  MessagePin(), ()=>new MessagePin())},
			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as ResultPIN).Uri = value;}, (IBinding data) => (data as ResultPIN).Uri )}
        }, __Tag,() => new ResultPIN(), () => new List<ResultPIN>(), () => new Dictionary<string,ResultPIN>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultPIN";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPIN();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPIN FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPIN;
			}
		var Result = new ResultPIN ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultSequence : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Entries")]
	public virtual LogEntry?					Entries  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSequence> _binding = new (
			new() {

			{ "Entries", new PropertyStruct ("Entries", typeof (LogEntry),
					(IBinding data, object? value) => {(data as ResultSequence).Entries = value as LogEntry;}, (IBinding data) => (data as ResultSequence).Entries,
					false, ()=>new  LogEntry(), ()=>new LogEntry())}
        }, __Tag,() => new ResultSequence(), () => new List<ResultSequence>(), () => new Dictionary<string,ResultSequence>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultSequence";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSequence();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSequence FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSequence;
			}
		var Result = new ResultSequence ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class LogEntry : MeshmanShellResult {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Digest")]
	public virtual byte[]?					Digest  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Recorded")]
	public virtual DateTime?					Recorded  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Encrypted")]
	public virtual bool?					Encrypted  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Signed")]
	public virtual bool?					Signed  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("KeyExchange")]
	public virtual bool?					KeyExchange  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<LogEntry> _binding = new (
			new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as LogEntry).Key = value;}, (IBinding data) => (data as LogEntry).Key )},
			{ "Length", new PropertyInteger32 ("Length", 
					(IBinding data, int? value) => {(data as LogEntry).Length = value;}, (IBinding data) => (data as LogEntry).Length )},
			{ "Digest", new PropertyBinary ("Digest", 
					(IBinding data, byte[]? value) => {(data as LogEntry).Digest = value;}, (IBinding data) => (data as LogEntry).Digest )},
			{ "Recorded", new PropertyDateTime ("Recorded", 
					(IBinding data, DateTime? value) => {(data as LogEntry).Recorded = value;}, (IBinding data) => (data as LogEntry).Recorded )},
			{ "Encrypted", new PropertyBoolean ("Encrypted", 
					(IBinding data, bool? value) => {(data as LogEntry).Encrypted = value;}, (IBinding data) => (data as LogEntry).Encrypted )},
			{ "Signed", new PropertyBoolean ("Signed", 
					(IBinding data, bool? value) => {(data as LogEntry).Signed = value;}, (IBinding data) => (data as LogEntry).Signed )},
			{ "KeyExchange", new PropertyBoolean ("KeyExchange", 
					(IBinding data, bool? value) => {(data as LogEntry).KeyExchange = value;}, (IBinding data) => (data as LogEntry).KeyExchange )}
        }, __Tag,() => new LogEntry(), () => new List<LogEntry>(), () => new Dictionary<string,LogEntry>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "LogEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new LogEntry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new LogEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as LogEntry;
			}
		var Result = new LogEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultEntry : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogEntry")]
	public virtual CatalogedEntry?					CatalogEntry  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEntry> _binding = new (
			new() {

			{ "CatalogEntry", new PropertyStruct ("CatalogEntry", typeof (CatalogedEntry), 
					(IBinding data, object? value) => {(data as ResultEntry).CatalogEntry = value as CatalogedEntry;}, (IBinding data) => (data as ResultEntry).CatalogEntry,
					true)} 
        }, __Tag,() => new ResultEntry(), () => new List<ResultEntry>(), () => new Dictionary<string,ResultEntry>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEntry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEntry;
			}
		var Result = new ResultEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultEntrySent : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogEntry")]
	public virtual CatalogedEntry?					CatalogEntry  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEntrySent> _binding = new (
			new() {

			{ "CatalogEntry", new PropertyStruct ("CatalogEntry", typeof (CatalogedEntry), 
					(IBinding data, object? value) => {(data as ResultEntrySent).CatalogEntry = value as CatalogedEntry;}, (IBinding data) => (data as ResultEntrySent).CatalogEntry,
					true)} ,
			{ "Message", new PropertyStruct ("Message", typeof (Message),
					(IBinding data, object? value) => {(data as ResultEntrySent).Message = value as Message;}, (IBinding data) => (data as ResultEntrySent).Message,
					false, ()=>new  Message(), ()=>new Message())}
        }, __Tag,() => new ResultEntrySent(), () => new List<ResultEntrySent>(), () => new Dictionary<string,ResultEntrySent>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultEntrySent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultEntrySent();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultEntrySent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultEntrySent;
			}
		var Result = new ResultEntrySent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultMail : ResultEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultMail> _binding = new (
			new() {

        }, __Tag,() => new ResultMail(), () => new List<ResultMail>(), () => new Dictionary<string,ResultMail>(),ResultEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultEntry._binding, _binding);


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
	public new const string __Tag = "ResultMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultMail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultMail;
			}
		var Result = new ResultMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultSSH : ResultEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSSH> _binding = new (
			new() {

        }, __Tag,() => new ResultSSH(), () => new List<ResultSSH>(), () => new Dictionary<string,ResultSSH>(),ResultEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultEntry._binding, _binding);


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
	public new const string __Tag = "ResultSSH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSSH();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSSH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSSH;
			}
		var Result = new ResultSSH ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultGroupCreate : ResultEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultGroupCreate> _binding = new (
			new() {

        }, __Tag,() => new ResultGroupCreate(), () => new List<ResultGroupCreate>(), () => new Dictionary<string,ResultGroupCreate>(),ResultEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ResultEntry._binding, _binding);


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
	public new const string __Tag = "ResultGroupCreate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultGroupCreate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultGroupCreate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultGroupCreate;
			}
		var Result = new ResultGroupCreate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultSent : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSent> _binding = new (
			new() {

			{ "Message", new PropertyStruct ("Message", typeof (Message),
					(IBinding data, object? value) => {(data as ResultSent).Message = value as Message;}, (IBinding data) => (data as ResultSent).Message,
					false, ()=>new  Message(), ()=>new Message())},
			{ "Status", new PropertyString ("Status", 
					(IBinding data, string? value) => {(data as ResultSent).Status = value;}, (IBinding data) => (data as ResultSent).Status )}
        }, __Tag,() => new ResultSent(), () => new List<ResultSent>(), () => new Dictionary<string,ResultSent>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultSent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultSent();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultSent FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultSent;
			}
		var Result = new ResultSent ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultPending : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Messages")]
	public virtual List<Message>?					Messages  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPending> _binding = new (
			new() {

			{ "Messages", new PropertyListStruct ("Messages", typeof (Message),
					(IBinding data, object? value) => {(data as ResultPending).Messages = value as List<Message>;}, (IBinding data) => (data as ResultPending).Messages,
					false, ()=>new  List<Message>(), ()=>new Message())}
        }, __Tag,() => new ResultPending(), () => new List<ResultPending>(), () => new Dictionary<string,ResultPending>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultPending";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultPending();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultPending FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultPending;
			}
		var Result = new ResultPending ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultAuthorize : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Messages")]
	public virtual List<ProcessResult>?					Messages  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAuthorize> _binding = new (
			new() {

			{ "Messages", new PropertyListStruct ("Messages", typeof (ProcessResult), 
					(IBinding data, object? value) => {(data as ResultAuthorize).Messages = value as List<ProcessResult>;}, (IBinding data) => (data as ResultAuthorize).Messages,
					true, ()=>new List<ProcessResult>()
)} 
        }, __Tag,() => new ResultAuthorize(), () => new List<ResultAuthorize>(), () => new Dictionary<string,ResultAuthorize>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultAuthorize";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultAuthorize();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultAuthorize FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultAuthorize;
			}
		var Result = new ResultAuthorize ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultProcess : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("ProcessResult")]
	public virtual Message?					ProcessResult  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultProcess> _binding = new (
			new() {

			{ "ProcessResult", new PropertyStruct ("ProcessResult", typeof (Message),
					(IBinding data, object? value) => {(data as ResultProcess).ProcessResult = value as Message;}, (IBinding data) => (data as ResultProcess).ProcessResult,
					false, ()=>new  Message(), ()=>new Message())}
        }, __Tag,() => new ResultProcess(), () => new List<ResultProcess>(), () => new Dictionary<string,ResultProcess>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultProcess";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultProcess();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultProcess FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultProcess;
			}
		var Result = new ResultProcess ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultConnect : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Profile")]
	public virtual Profile?					Profile  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("CatalogedMachine")]
	public virtual CatalogedMachine?					CatalogedMachine  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ActivationAccount")]
	public virtual ActivationAccount?					ActivationAccount  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ActivationCommon")]
	public virtual ActivationCommon?					ActivationCommon  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("RequestConnection")]
	public virtual RequestConnection?					RequestConnection  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AcknowledgeConnection")]
	public virtual AcknowledgeConnection?					AcknowledgeConnection  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("RespondConnection")]
	public virtual RespondConnection?					RespondConnection  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultConnect> _binding = new (
			new() {

			{ "Profile", new PropertyStruct ("Profile", typeof (Profile), 
					(IBinding data, object? value) => {(data as ResultConnect).Profile = value as Profile;}, (IBinding data) => (data as ResultConnect).Profile,
					true)} ,
			{ "CatalogedMachine", new PropertyStruct ("CatalogedMachine", typeof (CatalogedMachine),
					(IBinding data, object? value) => {(data as ResultConnect).CatalogedMachine = value as CatalogedMachine;}, (IBinding data) => (data as ResultConnect).CatalogedMachine,
					false, ()=>new  CatalogedMachine(), ()=>new CatalogedMachine())},
			{ "ActivationAccount", new PropertyStruct ("ActivationAccount", typeof (ActivationAccount),
					(IBinding data, object? value) => {(data as ResultConnect).ActivationAccount = value as ActivationAccount;}, (IBinding data) => (data as ResultConnect).ActivationAccount,
					false, ()=>new  ActivationAccount(), ()=>new ActivationAccount())},
			{ "ActivationCommon", new PropertyStruct ("ActivationCommon", typeof (ActivationCommon),
					(IBinding data, object? value) => {(data as ResultConnect).ActivationCommon = value as ActivationCommon;}, (IBinding data) => (data as ResultConnect).ActivationCommon,
					false, ()=>new  ActivationCommon(), ()=>new ActivationCommon())},
			{ "RequestConnection", new PropertyStruct ("RequestConnection", typeof (RequestConnection),
					(IBinding data, object? value) => {(data as ResultConnect).RequestConnection = value as RequestConnection;}, (IBinding data) => (data as ResultConnect).RequestConnection,
					false, ()=>new  RequestConnection(), ()=>new RequestConnection())},
			{ "AcknowledgeConnection", new PropertyStruct ("AcknowledgeConnection", typeof (AcknowledgeConnection),
					(IBinding data, object? value) => {(data as ResultConnect).AcknowledgeConnection = value as AcknowledgeConnection;}, (IBinding data) => (data as ResultConnect).AcknowledgeConnection,
					false, ()=>new  AcknowledgeConnection(), ()=>new AcknowledgeConnection())},
			{ "RespondConnection", new PropertyStruct ("RespondConnection", typeof (RespondConnection),
					(IBinding data, object? value) => {(data as ResultConnect).RespondConnection = value as RespondConnection;}, (IBinding data) => (data as ResultConnect).RespondConnection,
					false, ()=>new  RespondConnection(), ()=>new RespondConnection())}
        }, __Tag,() => new ResultConnect(), () => new List<ResultConnect>(), () => new Dictionary<string,ResultConnect>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultConnect();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultConnect FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultConnect;
			}
		var Result = new ResultConnect ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultTransactionRequest : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultTransactionRequest> _binding = new (
			new() {

			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as ResultTransactionRequest).Identifier = value;}, (IBinding data) => (data as ResultTransactionRequest).Identifier )}
        }, __Tag,() => new ResultTransactionRequest(), () => new List<ResultTransactionRequest>(), () => new Dictionary<string,ResultTransactionRequest>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultTransactionRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultTransactionRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultTransactionRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultTransactionRequest;
			}
		var Result = new ResultTransactionRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultReceived : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultReceived> _binding = new (
			new() {

			{ "Status", new PropertyString ("Status", 
					(IBinding data, string? value) => {(data as ResultReceived).Status = value;}, (IBinding data) => (data as ResultReceived).Status )},
			{ "Message", new PropertyStruct ("Message", typeof (Message),
					(IBinding data, object? value) => {(data as ResultReceived).Message = value as Message;}, (IBinding data) => (data as ResultReceived).Message,
					false, ()=>new  Message(), ()=>new Message())}
        }, __Tag,() => new ResultReceived(), () => new List<ResultReceived>(), () => new Dictionary<string,ResultReceived>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultReceived";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultReceived();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultReceived FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultReceived;
			}
		var Result = new ResultReceived ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultApplication : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Application")]
	public virtual CatalogedApplication?					Application  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultApplication> _binding = new (
			new() {

			{ "Application", new PropertyStruct ("Application", typeof (CatalogedApplication), 
					(IBinding data, object? value) => {(data as ResultApplication).Application = value as CatalogedApplication;}, (IBinding data) => (data as ResultApplication).Application,
					true)} 
        }, __Tag,() => new ResultApplication(), () => new List<ResultApplication>(), () => new Dictionary<string,ResultApplication>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultApplication";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultApplication();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultApplication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultApplication;
			}
		var Result = new ResultApplication ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultApplicationList : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Applications")]
	public virtual List<CatalogedApplication>?					Applications  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultApplicationList> _binding = new (
			new() {

			{ "Applications", new PropertyListStruct ("Applications", typeof (CatalogedApplication), 
					(IBinding data, object? value) => {(data as ResultApplicationList).Applications = value as List<CatalogedApplication>;}, (IBinding data) => (data as ResultApplicationList).Applications,
					true, ()=>new List<CatalogedApplication>()
)} 
        }, __Tag,() => new ResultApplicationList(), () => new List<ResultApplicationList>(), () => new Dictionary<string,ResultApplicationList>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultApplicationList";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultApplicationList();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultApplicationList FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultApplicationList;
			}
		var Result = new ResultApplicationList ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCallsign : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CallsignApplication")]
	public virtual CatalogedApplicationCallsign?					CallsignApplication  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsign> _binding = new (
			new() {

			{ "CallsignApplication", new PropertyStruct ("CallsignApplication", typeof (CatalogedApplicationCallsign),
					(IBinding data, object? value) => {(data as ResultCallsign).CallsignApplication = value as CatalogedApplicationCallsign;}, (IBinding data) => (data as ResultCallsign).CallsignApplication,
					false, ()=>new  CatalogedApplicationCallsign(), ()=>new CatalogedApplicationCallsign())},
			{ "Message", new PropertyStruct ("Message", typeof (Message),
					(IBinding data, object? value) => {(data as ResultCallsign).Message = value as Message;}, (IBinding data) => (data as ResultCallsign).Message,
					false, ()=>new  Message(), ()=>new Message())}
        }, __Tag,() => new ResultCallsign(), () => new List<ResultCallsign>(), () => new Dictionary<string,ResultCallsign>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCallsign;
			}
		var Result = new ResultCallsign ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCallsignResolution : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CallsignRegistration")]
	public virtual Registration?					CallsignRegistration  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsignResolution> _binding = new (
			new() {

			{ "CallsignRegistration", new PropertyStruct ("CallsignRegistration", typeof (Registration),
					(IBinding data, object? value) => {(data as ResultCallsignResolution).CallsignRegistration = value as Registration;}, (IBinding data) => (data as ResultCallsignResolution).CallsignRegistration,
					false, ()=>new  Registration(), ()=>new Registration())},
			{ "Message", new PropertyStruct ("Message", typeof (Message),
					(IBinding data, object? value) => {(data as ResultCallsignResolution).Message = value as Message;}, (IBinding data) => (data as ResultCallsignResolution).Message,
					false, ()=>new  Message(), ()=>new Message())}
        }, __Tag,() => new ResultCallsignResolution(), () => new List<ResultCallsignResolution>(), () => new Dictionary<string,ResultCallsignResolution>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultCallsignResolution";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCallsignResolution();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCallsignResolution FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCallsignResolution;
			}
		var Result = new ResultCallsignResolution ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ResultCallsignList : Result {
        /// <summary>
        /// </summary>

	[JsonPropertyName("CallsignApplication")]
	public virtual IEnumerable<CatalogedApplicationCallsign>				CallsignApplication  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsignList> _binding = new (
			new() {

			{ "CallsignApplication", new PropertyListStruct ("CallsignApplication", typeof (CatalogedApplicationCallsign),
					(IBinding data, object? value) => {(data as ResultCallsignList).CallsignApplication = value as List<CatalogedApplicationCallsign>;}, (IBinding data) => (data as ResultCallsignList).CallsignApplication,
					false, ()=>new  List<CatalogedApplicationCallsign>(), ()=>new CatalogedApplicationCallsign())}
        }, __Tag,() => new ResultCallsignList(), () => new List<ResultCallsignList>(), () => new Dictionary<string,ResultCallsignList>(),Result._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Result._binding, _binding);


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
	public new const string __Tag = "ResultCallsignList";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultCallsignList();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultCallsignList FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultCallsignList;
			}
		var Result = new ResultCallsignList ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



