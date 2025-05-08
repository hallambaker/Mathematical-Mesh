
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
//  This file was automatically generated at 5/8/2025 12:19:32 AM
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
using Goedel.Protocol.Service;


namespace Goedel.Mesh.Shell.Host;


	/// <summary>
	///
	/// Classes to be used to test serialization an deserialization.
	/// </summary>
public abstract partial class MeshhostShellResult : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshhostShellResult";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"Result", Result._Factory},
	    {"ResultAbout", ResultAbout._Factory},
	    {"ResultStartService", ResultStartService._Factory}
		};


	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(Result), Result._binding},
	    {typeof(ResultAbout), ResultAbout._binding},
	    {typeof(ResultStartService), ResultStartService._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static MeshhostShellResult() {
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
public partial class ResultStartService : Result {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResultStartService> _binding = new (
			new() {

        }, __Tag,() => new ResultStartService(), () => new List<ResultStartService>(), () => new Dictionary<string,ResultStartService>(),Result._binding);

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
	public new const string __Tag = "ResultStartService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResultStartService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResultStartService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResultStartService;
			}
		var Result = new ResultStartService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



