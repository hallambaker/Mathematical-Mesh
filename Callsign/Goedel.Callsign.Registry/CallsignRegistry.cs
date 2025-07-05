
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
//  This file was automatically generated at 7/5/2025 6:58:33 PM
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(CatalogedRegistry), CatalogedRegistry._binding},
	    {typeof(ActivationApplicationRegistry), ActivationApplicationRegistry._binding},
	    {typeof(ApplicationEntryRegistry), ApplicationEntryRegistry._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static CallsignRegistry() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	/// </summary>
public partial class CatalogedRegistry : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("MaximumRequestLength")]
	public virtual int?					MaximumRequestLength  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("MaximumCallsignLength")]
	public virtual int?					MaximumCallsignLength  {get; set;} //

    /// <summary>
    ///The connection allowing control of the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;} //

    /// <summary>
    ///The Mesh profile
    /// </summary>

	[JsonPropertyName("EnvelopedProfileRegistry")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileRegistry  {get; set;} //

    /// <summary>
    ///The activation data for the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("MaximumRequestLength", 
					(IBinding data, int? value) => {(data as CatalogedRegistry).MaximumRequestLength = value;}, 
					(IBinding data) => (data as CatalogedRegistry).MaximumRequestLength ),
		new PropertyInteger32 ("MaximumCallsignLength", 
					(IBinding data, int? value) => {(data as CatalogedRegistry).MaximumCallsignLength = value;}, 
					(IBinding data) => (data as CatalogedRegistry).MaximumCallsignLength ),
		new PropertyStruct ("EnvelopedConnectionAddress", typeof (Enveloped<ConnectionStripped>),
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, 
					(IBinding data) => (data as CatalogedRegistry).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>()),
		new PropertyStruct ("EnvelopedProfileRegistry", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedProfileRegistry = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as CatalogedRegistry).EnvelopedProfileRegistry,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyStruct ("EnvelopedActivationCommon", typeof (Enveloped<ActivationCommon>),
					(IBinding data, object? value) => {(data as CatalogedRegistry).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, 
					(IBinding data) => (data as CatalogedRegistry).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedRegistry> _binding = new (
			new() {
			{ "MaximumRequestLength", _properties [0]},
			{ "MaximumCallsignLength", _properties [1]},
			{ "EnvelopedConnectionAddress", _properties [2]},
			{ "EnvelopedProfileRegistry", _properties [3]},
			{ "EnvelopedActivationCommon", _properties [4]}}, __Tag,
		() => new CatalogedRegistry(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationRegistry : ActivationApplication {
    /// <summary>
    ///Key used to decrypt registry messages.
    /// </summary>

	[JsonPropertyName("AccountEncryption")]
	public virtual KeyData?					AccountEncryption  {get; set;} //

    /// <summary>
    ///Key or capability used to sign the registry log
    /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("AccountEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationRegistry).AccountEncryption = value as KeyData;}, 
					(IBinding data) => (data as ActivationApplicationRegistry).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationRegistry).AdministratorSignature = value as KeyData;}, 
					(IBinding data) => (data as ActivationApplicationRegistry).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationRegistry> _binding = new (
			new() {
			{ "AccountEncryption", _properties [0]},
			{ "AdministratorSignature", _properties [1]}}, __Tag,
		() => new ActivationApplicationRegistry(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryRegistry : ApplicationEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationRegistry>?					EnvelopedActivation  {get; set;} //

    /// <summary>
    ///Signed connection service delegation allowing the device to
    ///access the account.
    /// </summary>

	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationRegistry>),
					(IBinding data, object? value) => {(data as ApplicationEntryRegistry).EnvelopedActivation = value as Enveloped<ActivationApplicationRegistry>;}, 
					(IBinding data) => (data as ApplicationEntryRegistry).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationRegistry>(), ()=>new Enveloped<ActivationApplicationRegistry>()),
		new PropertyStruct ("EnvelopedConnectionService", typeof (Enveloped<ConnectionService>),
					(IBinding data, object? value) => {(data as ApplicationEntryRegistry).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, 
					(IBinding data) => (data as ApplicationEntryRegistry).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryRegistry> _binding = new (
			new() {
			{ "EnvelopedActivation", _properties [0]},
			{ "EnvelopedConnectionService", _properties [1]}}, __Tag,
		() => new ApplicationEntryRegistry(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}



