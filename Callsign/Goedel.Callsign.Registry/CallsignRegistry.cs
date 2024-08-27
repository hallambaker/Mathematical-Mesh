
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
//  This file was automatically generated at 8/27/2024 1:45:35 PM
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
using Goedel.Mesh;


namespace Goedel.Callsign.Registry;


	/// <summary>
	///
	/// Callsign Registry Protocol providing registry interactions.
	/// </summary>
public abstract partial class CallsignRegistry : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CallsignRegistry";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"CatalogedRegistry", CatalogedRegistry._Factory},
	    {"ActivationApplicationRegistry", ActivationApplicationRegistry._Factory},
	    {"ApplicationEntryRegistry", ApplicationEntryRegistry._Factory}
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
	/// </summary>
public partial class CatalogedRegistry : CatalogedApplication {
        /// <summary>
        /// </summary>

	public virtual int?						MaximumRequestLength  {get; set;}

        /// <summary>
        /// </summary>

	public virtual int?						MaximumCallsignLength  {get; set;}

        /// <summary>
        ///The connection allowing control of the registry.
        /// </summary>

	public virtual Enveloped<ConnectionStripped>?						EnvelopedConnectionAddress  {get; set;}

        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileRegistry  {get; set;}

        /// <summary>
        ///The activation data for the registry.
        /// </summary>

	public virtual Enveloped<ActivationCommon>?						EnvelopedActivationCommon  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedRegistry(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MaximumRequestLength", new PropertyInteger32 ("MaximumRequestLength", 
					(IBinding data, int? value) => {(data as CatalogedRegistry).MaximumRequestLength = value;}, (IBinding data) => (data as CatalogedRegistry).MaximumRequestLength )},
			{ "MaximumCallsignLength", new PropertyInteger32 ("MaximumCallsignLength", 
					(IBinding data, int? value) => {(data as CatalogedRegistry).MaximumCallsignLength = value;}, (IBinding data) => (data as CatalogedRegistry).MaximumCallsignLength )},
			{ "EnvelopedConnectionAddress", new PropertyStruct ("EnvelopedConnectionAddress", 
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, (IBinding data) => (data as CatalogedRegistry).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>())} ,
			{ "EnvelopedProfileRegistry", new PropertyStruct ("EnvelopedProfileRegistry", 
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedProfileRegistry = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedRegistry).EnvelopedProfileRegistry,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", 
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedRegistry).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedRegistry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedRegistry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedRegistry;
			}
		var Result = new CatalogedRegistry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationApplicationRegistry : ActivationApplication {
        /// <summary>
        ///Key used to decrypt registry messages.
        /// </summary>

	public virtual KeyData?						AccountEncryption  {get; set;}

        /// <summary>
        ///Key or capability used to sign the registry log
        /// </summary>

	public virtual KeyData?						AdministratorSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationApplicationRegistry(), ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountEncryption", new PropertyStruct ("AccountEncryption", 
					(IBinding data, object? value) => {(data as ActivationApplicationRegistry).AccountEncryption = value as KeyData;}, (IBinding data) => (data as ActivationApplicationRegistry).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", 
					(IBinding data, object? value) => {(data as ActivationApplicationRegistry).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ActivationApplicationRegistry).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ActivationApplication._StaticAllProperties);


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
	public new const string __Tag = "ActivationApplicationRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationRegistry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationRegistry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationRegistry;
			}
		var Result = new ActivationApplicationRegistry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ApplicationEntryRegistry : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationRegistry>?						EnvelopedActivation  {get; set;}

        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ApplicationEntryRegistry(), ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", 
					(IBinding data, object? value) => {(data as ApplicationEntryRegistry).EnvelopedActivation = value as Enveloped<ActivationApplicationRegistry>;}, (IBinding data) => (data as ApplicationEntryRegistry).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationRegistry>(), ()=>new Enveloped<ActivationApplicationRegistry>())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as ApplicationEntryRegistry).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as ApplicationEntryRegistry).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ApplicationEntry._StaticAllProperties);


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
	public new const string __Tag = "ApplicationEntryRegistry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryRegistry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryRegistry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryRegistry;
			}
		var Result = new ApplicationEntryRegistry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



