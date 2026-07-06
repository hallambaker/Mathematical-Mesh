
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
//  This file was automatically generated at 7/6/2026 5:30:21 PM
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
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	///
	/// Placeholder class to allow insertion of application specific properties.
	/// </summary>
public partial class Result : ShellResult {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Result> _binding = new (
			new() {}, __Tag,
		() => new Result(), () => [], () => [], ShellResult._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultAbout : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DirectoryKeys")]
	public virtual string?					DirectoryKeys  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DirectoryMesh")]
	public virtual string?					DirectoryMesh  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AssemblyTitle")]
	public virtual string?					AssemblyTitle  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AssemblyDescription")]
	public virtual string?					AssemblyDescription  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AssemblyCopyright")]
	public virtual string?					AssemblyCopyright  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AssemblyCompany")]
	public virtual string?					AssemblyCompany  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AssemblyVersion")]
	public virtual string?					AssemblyVersion  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Build")]
	public virtual string?					Build  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("DirectoryKeys", 
					(data, value) => {(data as ResultAbout).DirectoryKeys = value;}, 
					data => (data as ResultAbout).DirectoryKeys ),
		new PropertyString ("DirectoryMesh", 
					(data, value) => {(data as ResultAbout).DirectoryMesh = value;}, 
					data => (data as ResultAbout).DirectoryMesh ),
		new PropertyString ("AssemblyTitle", 
					(data, value) => {(data as ResultAbout).AssemblyTitle = value;}, 
					data => (data as ResultAbout).AssemblyTitle ),
		new PropertyString ("AssemblyDescription", 
					(data, value) => {(data as ResultAbout).AssemblyDescription = value;}, 
					data => (data as ResultAbout).AssemblyDescription ),
		new PropertyString ("AssemblyCopyright", 
					(data, value) => {(data as ResultAbout).AssemblyCopyright = value;}, 
					data => (data as ResultAbout).AssemblyCopyright ),
		new PropertyString ("AssemblyCompany", 
					(data, value) => {(data as ResultAbout).AssemblyCompany = value;}, 
					data => (data as ResultAbout).AssemblyCompany ),
		new PropertyString ("AssemblyVersion", 
					(data, value) => {(data as ResultAbout).AssemblyVersion = value;}, 
					data => (data as ResultAbout).AssemblyVersion ),
		new PropertyString ("Build", 
					(data, value) => {(data as ResultAbout).Build = value;}, 
					data => (data as ResultAbout).Build )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAbout> _binding = new (
			new() {
			{ "DirectoryKeys", _properties [0]},
			{ "DirectoryMesh", _properties [1]},
			{ "AssemblyTitle", _properties [2]},
			{ "AssemblyDescription", _properties [3]},
			{ "AssemblyCopyright", _properties [4]},
			{ "AssemblyCompany", _properties [5]},
			{ "AssemblyVersion", _properties [6]},
			{ "Build", _properties [7]}}, __Tag,
		() => new ResultAbout(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultFail : Result {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFail> _binding = new (
			new() {}, __Tag,
		() => new ResultFail(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultHello : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Response")]
	public virtual MeshHelloResponse?					Response  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ServiceAddress", 
					(data, value) => {(data as ResultHello).ServiceAddress = value;}, 
					data => (data as ResultHello).ServiceAddress ),
		new PropertyStruct ("Response", typeof (MeshHelloResponse),
					(data, value) => {(data as ResultHello).Response = value as MeshHelloResponse;}, 
					data => (data as ResultHello).Response,
					false, ()=>new  MeshHelloResponse(), ()=>new MeshHelloResponse())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultHello> _binding = new (
			new() {
			{ "ServiceAddress", _properties [0]},
			{ "Response", _properties [1]}}, __Tag,
		() => new ResultHello(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultSelf : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Contact")]
	public virtual JsContact?					Contact  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Locator")]
	public virtual string?					Locator  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Earl")]
	public virtual string?					Earl  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Contact", typeof (JsContact),
					(data, value) => {(data as ResultSelf).Contact = value as JsContact;}, 
					data => (data as ResultSelf).Contact,
					false, ()=>new  JsContact(), ()=>new JsContact()),
		new PropertyString ("Locator", 
					(data, value) => {(data as ResultSelf).Locator = value;}, 
					data => (data as ResultSelf).Locator ),
		new PropertyString ("Earl", 
					(data, value) => {(data as ResultSelf).Earl = value;}, 
					data => (data as ResultSelf).Earl )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSelf> _binding = new (
			new() {
			{ "Contact", _properties [0]},
			{ "Locator", _properties [1]},
			{ "Earl", _properties [2]}}, __Tag,
		() => new ResultSelf(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultInfo : Result {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultInfo> _binding = new (
			new() {}, __Tag,
		() => new ResultInfo(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultKey : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Shares")]
	public virtual List<string>?					Shares  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as ResultKey).Key = value;}, 
					data => (data as ResultKey).Key ),
		new PropertyString ("Identifier", 
					(data, value) => {(data as ResultKey).Identifier = value;}, 
					data => (data as ResultKey).Identifier ),
		new PropertyListString ("Shares", 
					(data, value) => {(data as ResultKey).Shares = value;}, 
					data => (data as ResultKey).Shares )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultKey> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Identifier", _properties [1]},
			{ "Shares", _properties [2]}}, __Tag,
		() => new ResultKey(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultDigest : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Digest")]
	public virtual string?					Digest  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Verified")]
	public virtual bool?					Verified  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Digest", 
					(data, value) => {(data as ResultDigest).Digest = value;}, 
					data => (data as ResultDigest).Digest ),
		new PropertyString ("Key", 
					(data, value) => {(data as ResultDigest).Key = value;}, 
					data => (data as ResultDigest).Key ),
		new PropertyBoolean ("Verified", 
					(data, value) => {(data as ResultDigest).Verified = value;}, 
					data => (data as ResultDigest).Verified )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDigest> _binding = new (
			new() {
			{ "Digest", _properties [0]},
			{ "Key", _properties [1]},
			{ "Verified", _properties [2]}}, __Tag,
		() => new ResultDigest(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultFile : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("TotalBytes")]
	public virtual long?					TotalBytes  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Verified")]
	public virtual bool?					Verified  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Filename", 
					(data, value) => {(data as ResultFile).Filename = value;}, 
					data => (data as ResultFile).Filename ),
		new PropertyInteger64 ("TotalBytes", 
					(data, value) => {(data as ResultFile).TotalBytes = value;}, 
					data => (data as ResultFile).TotalBytes ),
		new PropertyBoolean ("Verified", 
					(data, value) => {(data as ResultFile).Verified = value;}, 
					data => (data as ResultFile).Verified )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFile> _binding = new (
			new() {
			{ "Filename", _properties [0]},
			{ "TotalBytes", _properties [1]},
			{ "Verified", _properties [2]}}, __Tag,
		() => new ResultFile(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultKeyFile : ResultFile {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Private")]
	public virtual bool?					Private  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Algorithm")]
	public virtual string?					Algorithm  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Format")]
	public virtual string?					Format  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Udf", 
					(data, value) => {(data as ResultKeyFile).Udf = value;}, 
					data => (data as ResultKeyFile).Udf ),
		new PropertyBoolean ("Private", 
					(data, value) => {(data as ResultKeyFile).Private = value;}, 
					data => (data as ResultKeyFile).Private ),
		new PropertyString ("Algorithm", 
					(data, value) => {(data as ResultKeyFile).Algorithm = value;}, 
					data => (data as ResultKeyFile).Algorithm ),
		new PropertyString ("Format", 
					(data, value) => {(data as ResultKeyFile).Format = value;}, 
					data => (data as ResultKeyFile).Format )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultKeyFile> _binding = new (
			new() {
			{ "Udf", _properties [0]},
			{ "Private", _properties [1]},
			{ "Algorithm", _properties [2]},
			{ "Format", _properties [3]}}, __Tag,
		() => new ResultKeyFile(), () => [], () => [], ResultFile._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultListLog : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Count")]
	public virtual int?					Count  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Filename", 
					(data, value) => {(data as ResultListLog).Filename = value;}, 
					data => (data as ResultListLog).Filename ),
		new PropertyInteger32 ("Count", 
					(data, value) => {(data as ResultListLog).Count = value;}, 
					data => (data as ResultListLog).Count )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultListLog> _binding = new (
			new() {
			{ "Filename", _properties [0]},
			{ "Count", _properties [1]}}, __Tag,
		() => new ResultListLog(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultLog : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Count")]
	public virtual int?					Count  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Count", 
					(data, value) => {(data as ResultLog).Count = value;}, 
					data => (data as ResultLog).Count )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultLog> _binding = new (
			new() {
			{ "Count", _properties [0]}}, __Tag,
		() => new ResultLog(), () => [], () => [], Result._binding, Generic: false);


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
	public virtual int?					Frames  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Deleted")]
	public virtual int?					Deleted  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("IndexFrame")]
	public virtual int?					IndexFrame  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Entries", typeof (FileEntry),
					(data, value) => {(data as ResultArchive).Entries = value as List<FileEntry>;}, 
					data => (data as ResultArchive).Entries,
					false, ()=>new  List<FileEntry>(), ()=>new FileEntry()),
		new PropertyInteger32 ("Frames", 
					(data, value) => {(data as ResultArchive).Frames = value;}, 
					data => (data as ResultArchive).Frames ),
		new PropertyInteger32 ("Deleted", 
					(data, value) => {(data as ResultArchive).Deleted = value;}, 
					data => (data as ResultArchive).Deleted ),
		new PropertyInteger32 ("IndexFrame", 
					(data, value) => {(data as ResultArchive).IndexFrame = value;}, 
					data => (data as ResultArchive).IndexFrame )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultArchive> _binding = new (
			new() {
			{ "Entries", _properties [0]},
			{ "Frames", _properties [1]},
			{ "Deleted", _properties [2]},
			{ "IndexFrame", _properties [3]}}, __Tag,
		() => new ResultArchive(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultFileDare : ResultFile {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Envelope")]
	public virtual Enveloped?					Enveloped  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Envelope", typeof (Enveloped),
					(data, value) => {(data as ResultFileDare).Enveloped = value as Enveloped;}, 
					data => (data as ResultFileDare).Enveloped,
					false, ()=>new  Enveloped(), ()=>new Enveloped())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFileDare> _binding = new (
			new() {
			{ "Envelope", _properties [0]}}, __Tag,
		() => new ResultFileDare(), () => [], () => [], ResultFile._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultFileEARL : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Source")]
	public virtual string?					Source  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Wrapper")]
	public virtual string?					Wrapper  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Created")]
	public virtual string?					Created  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("URI")]
	public virtual string?					URI  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("NotPresent")]
	public virtual string?					NotPresent  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Source", 
					(data, value) => {(data as ResultFileEARL).Source = value;}, 
					data => (data as ResultFileEARL).Source ),
		new PropertyString ("Wrapper", 
					(data, value) => {(data as ResultFileEARL).Wrapper = value;}, 
					data => (data as ResultFileEARL).Wrapper ),
		new PropertyString ("Created", 
					(data, value) => {(data as ResultFileEARL).Created = value;}, 
					data => (data as ResultFileEARL).Created ),
		new PropertyString ("URI", 
					(data, value) => {(data as ResultFileEARL).URI = value;}, 
					data => (data as ResultFileEARL).URI ),
		new PropertyString ("NotPresent", 
					(data, value) => {(data as ResultFileEARL).NotPresent = value;}, 
					data => (data as ResultFileEARL).NotPresent )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultFileEARL> _binding = new (
			new() {
			{ "Source", _properties [0]},
			{ "Wrapper", _properties [1]},
			{ "Created", _properties [2]},
			{ "URI", _properties [3]},
			{ "NotPresent", _properties [4]}}, __Tag,
		() => new ResultFileEARL(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultDump : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedEntries")]
	public virtual List<CatalogedEntry>?					CatalogedEntries  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("CatalogedEntries", typeof (CatalogedEntry), 
					(data, value) => {(data as ResultDump).CatalogedEntries = value as List<CatalogedEntry>;}, 
					data => (data as ResultDump).CatalogedEntries,
					true, ()=>new List<CatalogedEntry>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDump> _binding = new (
			new() {
			{ "CatalogedEntries", _properties [0]}}, __Tag,
		() => new ResultDump(), () => [], () => [], Result._binding, Generic: false);


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
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("CatalogedDevices", typeof (CatalogedDevice),
					(data, value) => {(data as ResultList).CatalogedDevices = value as List<CatalogedDevice>;}, 
					data => (data as ResultList).CatalogedDevices,
					false, ()=>new  List<CatalogedDevice>(), ()=>new CatalogedDevice()),
		new PropertyListStruct ("Profiles", typeof (Assertion), 
					(data, value) => {(data as ResultList).Profiles = value as List<Assertion>;}, 
					data => (data as ResultList).Profiles,
					true, ()=>new List<Assertion>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultList> _binding = new (
			new() {
			{ "CatalogedDevices", _properties [0]},
			{ "Profiles", _properties [1]}}, __Tag,
		() => new ResultList(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultAccountConnect : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ProfileDevice")]
	public virtual ProfileDevice?					ProfileDevice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("ProfileDevice", typeof (ProfileDevice),
					(data, value) => {(data as ResultAccountConnect).ProfileDevice = value as ProfileDevice;}, 
					data => (data as ResultAccountConnect).ProfileDevice,
					false, ()=>new  ProfileDevice(), ()=>new ProfileDevice())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAccountConnect> _binding = new (
			new() {
			{ "ProfileDevice", _properties [0]}}, __Tag,
		() => new ResultAccountConnect(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultPublish : ResultCreateDevice {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Uri", 
					(data, value) => {(data as ResultPublish).Uri = value;}, 
					data => (data as ResultPublish).Uri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPublish> _binding = new (
			new() {
			{ "Uri", _properties [0]}}, __Tag,
		() => new ResultPublish(), () => [], () => [], ResultCreateDevice._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultPublishDevice : ResultCreateDevice {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FileName")]
	public virtual string?					FileName  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DevicePreconfigurationPublic")]
	public virtual DevicePreconfigurationPublic?					DevicePreconfigurationPublic  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DevicePreconfigurationPrivate")]
	public virtual DevicePreconfigurationPrivate?					DevicePreconfigurationPrivate  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Uri", 
					(data, value) => {(data as ResultPublishDevice).Uri = value;}, 
					data => (data as ResultPublishDevice).Uri ),
		new PropertyString ("FileName", 
					(data, value) => {(data as ResultPublishDevice).FileName = value;}, 
					data => (data as ResultPublishDevice).FileName ),
		new PropertyStruct ("DevicePreconfigurationPublic", typeof (DevicePreconfigurationPublic),
					(data, value) => {(data as ResultPublishDevice).DevicePreconfigurationPublic = value as DevicePreconfigurationPublic;}, 
					data => (data as ResultPublishDevice).DevicePreconfigurationPublic,
					false, ()=>new  DevicePreconfigurationPublic(), ()=>new DevicePreconfigurationPublic()),
		new PropertyStruct ("DevicePreconfigurationPrivate", typeof (DevicePreconfigurationPrivate),
					(data, value) => {(data as ResultPublishDevice).DevicePreconfigurationPrivate = value as DevicePreconfigurationPrivate;}, 
					data => (data as ResultPublishDevice).DevicePreconfigurationPrivate,
					false, ()=>new  DevicePreconfigurationPrivate(), ()=>new DevicePreconfigurationPrivate())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPublishDevice> _binding = new (
			new() {
			{ "Uri", _properties [0]},
			{ "FileName", _properties [1]},
			{ "DevicePreconfigurationPublic", _properties [2]},
			{ "DevicePreconfigurationPrivate", _properties [3]}}, __Tag,
		() => new ResultPublishDevice(), () => [], () => [], ResultCreateDevice._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCreateDevice : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Default")]
	public virtual bool?					Default  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceUDF")]
	public virtual string?					DeviceUDF  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDevice")]
	public virtual CatalogedDevice?					CatalogedDevice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Default", 
					(data, value) => {(data as ResultCreateDevice).Default = value;}, 
					data => (data as ResultCreateDevice).Default ),
		new PropertyString ("DeviceUDF", 
					(data, value) => {(data as ResultCreateDevice).DeviceUDF = value;}, 
					data => (data as ResultCreateDevice).DeviceUDF ),
		new PropertyStruct ("CatalogedDevice", typeof (CatalogedDevice),
					(data, value) => {(data as ResultCreateDevice).CatalogedDevice = value as CatalogedDevice;}, 
					data => (data as ResultCreateDevice).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreateDevice> _binding = new (
			new() {
			{ "Default", _properties [0]},
			{ "DeviceUDF", _properties [1]},
			{ "CatalogedDevice", _properties [2]}}, __Tag,
		() => new ResultCreateDevice(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCreatePersonal : ResultCreateAccount {
    /// <summary>
    /// </summary>

	[JsonPropertyName("MeshUDF")]
	public virtual string?					MeshUDF  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("MeshUDF", 
					(data, value) => {(data as ResultCreatePersonal).MeshUDF = value;}, 
					data => (data as ResultCreatePersonal).MeshUDF )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreatePersonal> _binding = new (
			new() {
			{ "MeshUDF", _properties [0]}}, __Tag,
		() => new ResultCreatePersonal(), () => [], () => [], ResultCreateAccount._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCreateAccount : ResultCreateDevice {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ProfileAccount")]
	public virtual ProfileAccount?					ProfileAccount  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ActivationAccount")]
	public virtual ActivationAccount?					ActivationAccount  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("ProfileAccount", typeof (ProfileAccount),
					(data, value) => {(data as ResultCreateAccount).ProfileAccount = value as ProfileAccount;}, 
					data => (data as ResultCreateAccount).ProfileAccount,
					false, ()=>new  ProfileAccount(), ()=>new ProfileAccount()),
		new PropertyStruct ("ActivationAccount", typeof (ActivationAccount),
					(data, value) => {(data as ResultCreateAccount).ActivationAccount = value as ActivationAccount;}, 
					data => (data as ResultCreateAccount).ActivationAccount,
					false, ()=>new  ActivationAccount(), ()=>new ActivationAccount())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCreateAccount> _binding = new (
			new() {
			{ "ProfileAccount", _properties [0]},
			{ "ActivationAccount", _properties [1]}}, __Tag,
		() => new ResultCreateAccount(), () => [], () => [], ResultCreateDevice._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultDeleteAccount : ResultCreateDevice {
    /// <summary>
    /// </summary>

	[JsonPropertyName("UDF")]
	public virtual string?					UDF  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("UDF", 
					(data, value) => {(data as ResultDeleteAccount).UDF = value;}, 
					data => (data as ResultDeleteAccount).UDF )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultDeleteAccount> _binding = new (
			new() {
			{ "UDF", _properties [0]}}, __Tag,
		() => new ResultDeleteAccount(), () => [], () => [], ResultCreateDevice._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultRegisterService : ResultCreateAccount {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as ResultRegisterService).AccountAddress = value;}, 
					data => (data as ResultRegisterService).AccountAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultRegisterService> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]}}, __Tag,
		() => new ResultRegisterService(), () => [], () => [], ResultCreateAccount._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultRecover : ResultCreatePersonal {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultRecover> _binding = new (
			new() {}, __Tag,
		() => new ResultRecover(), () => [], () => [], ResultCreatePersonal._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultStatus : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("StatusResponse")]
	public virtual StatusResponse?					StatusResponse  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("StatusResponse", typeof (StatusResponse),
					(data, value) => {(data as ResultStatus).StatusResponse = value as StatusResponse;}, 
					data => (data as ResultStatus).StatusResponse,
					false, ()=>new  StatusResponse(), ()=>new StatusResponse())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultStatus> _binding = new (
			new() {
			{ "StatusResponse", _properties [0]}}, __Tag,
		() => new ResultStatus(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultSync : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Fetched")]
	public virtual long?					Fetched  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ProcessedResults")]
	public virtual int?					ProcessedResults  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ProcessResults")]
	public virtual List<ProcessResult>?					ProcessResults  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger64 ("Fetched", 
					(data, value) => {(data as ResultSync).Fetched = value;}, 
					data => (data as ResultSync).Fetched ),
		new PropertyInteger32 ("ProcessedResults", 
					(data, value) => {(data as ResultSync).ProcessedResults = value;}, 
					data => (data as ResultSync).ProcessedResults ),
		new PropertyListStruct ("ProcessResults", typeof (ProcessResult), 
					(data, value) => {(data as ResultSync).ProcessResults = value as List<ProcessResult>;}, 
					data => (data as ResultSync).ProcessResults,
					true, ()=>new List<ProcessResult>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSync> _binding = new (
			new() {
			{ "Fetched", _properties [0]},
			{ "ProcessedResults", _properties [1]},
			{ "ProcessResults", _properties [2]}}, __Tag,
		() => new ResultSync(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultEscrow : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Shares")]
	public virtual List<string>?					Shares  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Service", 
					(data, value) => {(data as ResultEscrow).Service = value;}, 
					data => (data as ResultEscrow).Service ),
		new PropertyListString ("Shares", 
					(data, value) => {(data as ResultEscrow).Shares = value;}, 
					data => (data as ResultEscrow).Shares )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEscrow> _binding = new (
			new() {
			{ "Service", _properties [0]},
			{ "Shares", _properties [1]}}, __Tag,
		() => new ResultEscrow(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultMachine : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedMachines")]
	public virtual List<CatalogedMachine>?					CatalogedMachines  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("CatalogedMachines", typeof (CatalogedMachine),
					(data, value) => {(data as ResultMachine).CatalogedMachines = value as List<CatalogedMachine>;}, 
					data => (data as ResultMachine).CatalogedMachines,
					false, ()=>new  List<CatalogedMachine>(), ()=>new CatalogedMachine())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultMachine> _binding = new (
			new() {
			{ "CatalogedMachines", _properties [0]}}, __Tag,
		() => new ResultMachine(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultPIN : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("MessagePIN")]
	public virtual MessagePin?					MessagePIN  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("MessagePIN", typeof (MessagePin),
					(data, value) => {(data as ResultPIN).MessagePIN = value as MessagePin;}, 
					data => (data as ResultPIN).MessagePIN,
					false, ()=>new  MessagePin(), ()=>new MessagePin()),
		new PropertyString ("Uri", 
					(data, value) => {(data as ResultPIN).Uri = value;}, 
					data => (data as ResultPIN).Uri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPIN> _binding = new (
			new() {
			{ "MessagePIN", _properties [0]},
			{ "Uri", _properties [1]}}, __Tag,
		() => new ResultPIN(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultSequence : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual LogEntry?					Entries  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Entries", typeof (LogEntry),
					(data, value) => {(data as ResultSequence).Entries = value as LogEntry;}, 
					data => (data as ResultSequence).Entries,
					false, ()=>new  LogEntry(), ()=>new LogEntry())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSequence> _binding = new (
			new() {
			{ "Entries", _properties [0]}}, __Tag,
		() => new ResultSequence(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class LogEntry : MeshmanShellResult {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Digest")]
	public virtual byte[]?					Digest  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Recorded")]
	public virtual DateTime?					Recorded  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Encrypted")]
	public virtual bool?					Encrypted  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Signed")]
	public virtual bool?					Signed  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("KeyExchange")]
	public virtual bool?					KeyExchange  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as LogEntry).Key = value;}, 
					data => (data as LogEntry).Key ),
		new PropertyInteger32 ("Length", 
					(data, value) => {(data as LogEntry).Length = value;}, 
					data => (data as LogEntry).Length ),
		new PropertyBinary ("Digest", 
					(data, value) => {(data as LogEntry).Digest = value;}, 
					data => (data as LogEntry).Digest ),
		new PropertyDateTime ("Recorded", 
					(data, value) => {(data as LogEntry).Recorded = value;}, 
					data => (data as LogEntry).Recorded ),
		new PropertyBoolean ("Encrypted", 
					(data, value) => {(data as LogEntry).Encrypted = value;}, 
					data => (data as LogEntry).Encrypted ),
		new PropertyBoolean ("Signed", 
					(data, value) => {(data as LogEntry).Signed = value;}, 
					data => (data as LogEntry).Signed ),
		new PropertyBoolean ("KeyExchange", 
					(data, value) => {(data as LogEntry).KeyExchange = value;}, 
					data => (data as LogEntry).KeyExchange )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<LogEntry> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Length", _properties [1]},
			{ "Digest", _properties [2]},
			{ "Recorded", _properties [3]},
			{ "Encrypted", _properties [4]},
			{ "Signed", _properties [5]},
			{ "KeyExchange", _properties [6]}}, __Tag,
		() => new LogEntry(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultEntry : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogEntry")]
	public virtual CatalogedEntry?					CatalogEntry  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CatalogEntry", typeof (CatalogedEntry), 
					(data, value) => {(data as ResultEntry).CatalogEntry = value as CatalogedEntry;}, 
					data => (data as ResultEntry).CatalogEntry,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEntry> _binding = new (
			new() {
			{ "CatalogEntry", _properties [0]}}, __Tag,
		() => new ResultEntry(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultEntrySent : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogEntry")]
	public virtual CatalogedEntry?					CatalogEntry  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CatalogEntry", typeof (CatalogedEntry), 
					(data, value) => {(data as ResultEntrySent).CatalogEntry = value as CatalogedEntry;}, 
					data => (data as ResultEntrySent).CatalogEntry,
					true) ,
		new PropertyStruct ("Message", typeof (Message),
					(data, value) => {(data as ResultEntrySent).Message = value as Message;}, 
					data => (data as ResultEntrySent).Message,
					false, ()=>new  Message(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultEntrySent> _binding = new (
			new() {
			{ "CatalogEntry", _properties [0]},
			{ "Message", _properties [1]}}, __Tag,
		() => new ResultEntrySent(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultMail : ResultEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultMail> _binding = new (
			new() {}, __Tag,
		() => new ResultMail(), () => [], () => [], ResultEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultSSH : ResultEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSSH> _binding = new (
			new() {}, __Tag,
		() => new ResultSSH(), () => [], () => [], ResultEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultGroupCreate : ResultEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultGroupCreate> _binding = new (
			new() {}, __Tag,
		() => new ResultGroupCreate(), () => [], () => [], ResultEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultSent : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Message", typeof (Message),
					(data, value) => {(data as ResultSent).Message = value as Message;}, 
					data => (data as ResultSent).Message,
					false, ()=>new  Message(), ()=>new Message()),
		new PropertyString ("Status", 
					(data, value) => {(data as ResultSent).Status = value;}, 
					data => (data as ResultSent).Status )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultSent> _binding = new (
			new() {
			{ "Message", _properties [0]},
			{ "Status", _properties [1]}}, __Tag,
		() => new ResultSent(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultPending : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Messages")]
	public virtual List<Message>?					Messages  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Messages", typeof (Message),
					(data, value) => {(data as ResultPending).Messages = value as List<Message>;}, 
					data => (data as ResultPending).Messages,
					false, ()=>new  List<Message>(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultPending> _binding = new (
			new() {
			{ "Messages", _properties [0]}}, __Tag,
		() => new ResultPending(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultAuthorize : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Messages")]
	public virtual List<ProcessResult>?					Messages  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Messages", typeof (ProcessResult), 
					(data, value) => {(data as ResultAuthorize).Messages = value as List<ProcessResult>;}, 
					data => (data as ResultAuthorize).Messages,
					true, ()=>new List<ProcessResult>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultAuthorize> _binding = new (
			new() {
			{ "Messages", _properties [0]}}, __Tag,
		() => new ResultAuthorize(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultProcess : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ProcessResult")]
	public virtual Message?					ProcessResult  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("ProcessResult", typeof (Message),
					(data, value) => {(data as ResultProcess).ProcessResult = value as Message;}, 
					data => (data as ResultProcess).ProcessResult,
					false, ()=>new  Message(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultProcess> _binding = new (
			new() {
			{ "ProcessResult", _properties [0]}}, __Tag,
		() => new ResultProcess(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultConnect : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Profile")]
	public virtual Profile?					Profile  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedMachine")]
	public virtual CatalogedMachine?					CatalogedMachine  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ActivationAccount")]
	public virtual ActivationAccount?					ActivationAccount  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ActivationCommon")]
	public virtual ActivationCommon?					ActivationCommon  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("RequestConnection")]
	public virtual RequestConnection?					RequestConnection  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AcknowledgeConnection")]
	public virtual AcknowledgeConnection?					AcknowledgeConnection  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("RespondConnection")]
	public virtual RespondConnection?					RespondConnection  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Profile", typeof (Profile), 
					(data, value) => {(data as ResultConnect).Profile = value as Profile;}, 
					data => (data as ResultConnect).Profile,
					true) ,
		new PropertyStruct ("CatalogedMachine", typeof (CatalogedMachine),
					(data, value) => {(data as ResultConnect).CatalogedMachine = value as CatalogedMachine;}, 
					data => (data as ResultConnect).CatalogedMachine,
					false, ()=>new  CatalogedMachine(), ()=>new CatalogedMachine()),
		new PropertyStruct ("ActivationAccount", typeof (ActivationAccount),
					(data, value) => {(data as ResultConnect).ActivationAccount = value as ActivationAccount;}, 
					data => (data as ResultConnect).ActivationAccount,
					false, ()=>new  ActivationAccount(), ()=>new ActivationAccount()),
		new PropertyStruct ("ActivationCommon", typeof (ActivationCommon),
					(data, value) => {(data as ResultConnect).ActivationCommon = value as ActivationCommon;}, 
					data => (data as ResultConnect).ActivationCommon,
					false, ()=>new  ActivationCommon(), ()=>new ActivationCommon()),
		new PropertyStruct ("RequestConnection", typeof (RequestConnection),
					(data, value) => {(data as ResultConnect).RequestConnection = value as RequestConnection;}, 
					data => (data as ResultConnect).RequestConnection,
					false, ()=>new  RequestConnection(), ()=>new RequestConnection()),
		new PropertyStruct ("AcknowledgeConnection", typeof (AcknowledgeConnection),
					(data, value) => {(data as ResultConnect).AcknowledgeConnection = value as AcknowledgeConnection;}, 
					data => (data as ResultConnect).AcknowledgeConnection,
					false, ()=>new  AcknowledgeConnection(), ()=>new AcknowledgeConnection()),
		new PropertyStruct ("RespondConnection", typeof (RespondConnection),
					(data, value) => {(data as ResultConnect).RespondConnection = value as RespondConnection;}, 
					data => (data as ResultConnect).RespondConnection,
					false, ()=>new  RespondConnection(), ()=>new RespondConnection())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultConnect> _binding = new (
			new() {
			{ "Profile", _properties [0]},
			{ "CatalogedMachine", _properties [1]},
			{ "ActivationAccount", _properties [2]},
			{ "ActivationCommon", _properties [3]},
			{ "RequestConnection", _properties [4]},
			{ "AcknowledgeConnection", _properties [5]},
			{ "RespondConnection", _properties [6]}}, __Tag,
		() => new ResultConnect(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultTransactionRequest : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Identifier", 
					(data, value) => {(data as ResultTransactionRequest).Identifier = value;}, 
					data => (data as ResultTransactionRequest).Identifier )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultTransactionRequest> _binding = new (
			new() {
			{ "Identifier", _properties [0]}}, __Tag,
		() => new ResultTransactionRequest(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultReceived : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Status", 
					(data, value) => {(data as ResultReceived).Status = value;}, 
					data => (data as ResultReceived).Status ),
		new PropertyStruct ("Message", typeof (Message),
					(data, value) => {(data as ResultReceived).Message = value as Message;}, 
					data => (data as ResultReceived).Message,
					false, ()=>new  Message(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultReceived> _binding = new (
			new() {
			{ "Status", _properties [0]},
			{ "Message", _properties [1]}}, __Tag,
		() => new ResultReceived(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultApplication : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Application")]
	public virtual CatalogedApplication?					Application  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Application", typeof (CatalogedApplication), 
					(data, value) => {(data as ResultApplication).Application = value as CatalogedApplication;}, 
					data => (data as ResultApplication).Application,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultApplication> _binding = new (
			new() {
			{ "Application", _properties [0]}}, __Tag,
		() => new ResultApplication(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultApplicationList : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Applications")]
	public virtual List<CatalogedApplication>?					Applications  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Applications", typeof (CatalogedApplication), 
					(data, value) => {(data as ResultApplicationList).Applications = value as List<CatalogedApplication>;}, 
					data => (data as ResultApplicationList).Applications,
					true, ()=>new List<CatalogedApplication>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultApplicationList> _binding = new (
			new() {
			{ "Applications", _properties [0]}}, __Tag,
		() => new ResultApplicationList(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCallsign : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CallsignApplication")]
	public virtual CatalogedApplicationCallsign?					CallsignApplication  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CallsignApplication", typeof (CatalogedApplicationCallsign),
					(data, value) => {(data as ResultCallsign).CallsignApplication = value as CatalogedApplicationCallsign;}, 
					data => (data as ResultCallsign).CallsignApplication,
					false, ()=>new  CatalogedApplicationCallsign(), ()=>new CatalogedApplicationCallsign()),
		new PropertyStruct ("Message", typeof (Message),
					(data, value) => {(data as ResultCallsign).Message = value as Message;}, 
					data => (data as ResultCallsign).Message,
					false, ()=>new  Message(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsign> _binding = new (
			new() {
			{ "CallsignApplication", _properties [0]},
			{ "Message", _properties [1]}}, __Tag,
		() => new ResultCallsign(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCallsignResolution : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CallsignRegistration")]
	public virtual Registration?					CallsignRegistration  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Message")]
	public virtual Message?					Message  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CallsignRegistration", typeof (Registration),
					(data, value) => {(data as ResultCallsignResolution).CallsignRegistration = value as Registration;}, 
					data => (data as ResultCallsignResolution).CallsignRegistration,
					false, ()=>new  Registration(), ()=>new Registration()),
		new PropertyStruct ("Message", typeof (Message),
					(data, value) => {(data as ResultCallsignResolution).Message = value as Message;}, 
					data => (data as ResultCallsignResolution).Message,
					false, ()=>new  Message(), ()=>new Message())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsignResolution> _binding = new (
			new() {
			{ "CallsignRegistration", _properties [0]},
			{ "Message", _properties [1]}}, __Tag,
		() => new ResultCallsignResolution(), () => [], () => [], Result._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResultCallsignList : Result {
    /// <summary>
    /// </summary>

	[JsonPropertyName("CallsignApplication")]
	public virtual IEnumerable<CatalogedApplicationCallsign>				CallsignApplication  {get; set;} 

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("CallsignApplication", typeof (CatalogedApplicationCallsign),
					(data, value) => {(data as ResultCallsignList).CallsignApplication = value as List<CatalogedApplicationCallsign>;}, 
					data => (data as ResultCallsignList).CallsignApplication,
					false, ()=>new  List<CatalogedApplicationCallsign>(), ()=>new CatalogedApplicationCallsign())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultCallsignList> _binding = new (
			new() {
			{ "CallsignApplication", _properties [0]}}, __Tag,
		() => new ResultCallsignList(), () => [], () => [], Result._binding, Generic: false);


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

	}



