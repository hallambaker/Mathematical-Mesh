
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
//  This file was automatically generated at 7/15/2025 6:07:58 PM
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



namespace Goedel.Device;


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
public abstract partial class DeviceData : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DeviceData";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(DeviceConnect), DeviceConnect._binding},
	    {typeof(NetworkConnect), NetworkConnect._binding},
	    {typeof(NetworkConnectEthernet), NetworkConnectEthernet._binding},
	    {typeof(NetworkConnectWiFi), NetworkConnectWiFi._binding},
	    {typeof(OnboardingService), OnboardingService._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static DeviceData() {
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
	/// A device connection description providing a device with instructions to allow
	/// it to complete the onboarding process.
	/// </summary>
public partial class DeviceConnect : DeviceData {
    /// <summary>
    ///The network connections supported.
    /// </summary>

	[JsonPropertyName("Networks")]
	public virtual List<NetworkConnect>?					Networks  {get; set;}
    /// <summary>
    ///Onboarding services that MAY be used to complete the 
    /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<OnboardingService>?					Services  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Networks", typeof (NetworkConnect), 
					(IBinding data, object? value) => {(data as DeviceConnect).Networks = value as List<NetworkConnect>;}, 
					(IBinding data) => (data as DeviceConnect).Networks,
					true, ()=>new List<NetworkConnect>()
) ,
		new PropertyListStruct ("Services", typeof (OnboardingService), 
					(IBinding data, object? value) => {(data as DeviceConnect).Services = value as List<OnboardingService>;}, 
					(IBinding data) => (data as DeviceConnect).Services,
					true, ()=>new List<OnboardingService>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceConnect> _binding = new (
			new() {
			{ "Networks", _properties [0]},
			{ "Services", _properties [1]}}, __Tag,
		() => new DeviceConnect(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DeviceConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceConnect();

	}


	/// <summary>
	///
	/// 
	/// </summary>
public partial class NetworkConnect : DeviceData {
    /// <summary>
    ///Connection profiles supported by the network connection
    /// </summary>

	[JsonPropertyName("Profiles")]
	public virtual List<string>?					Profiles  {get; set;}
    /// <summary>
    ///Identifiers of the onboarding services that MAY be reached through
    ///the network connection. If null or empty, the network connection supports
    ///ALL the listed network connections.
    /// </summary>

	[JsonPropertyName("ServiceIds")]
	public virtual string?					ServiceIds  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Profiles", 
					(IBinding data, List<string>? value) => {(data as NetworkConnect).Profiles = value;}, 
					(IBinding data) => (data as NetworkConnect).Profiles ),
		new PropertyString ("ServiceIds", 
					(IBinding data, string? value) => {(data as NetworkConnect).ServiceIds = value;}, 
					(IBinding data) => (data as NetworkConnect).ServiceIds )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkConnect> _binding = new (
			new() {
			{ "Profiles", _properties [0]},
			{ "ServiceIds", _properties [1]}}, __Tag,
		() => new NetworkConnect(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "NetworkConnect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkConnect();

	}


	/// <summary>
	///
	/// 
	/// </summary>
public partial class NetworkConnectEthernet : NetworkConnect {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkConnectEthernet> _binding = new (
			new() {}, __Tag,
		() => new NetworkConnectEthernet(), () => [], () => [], NetworkConnect._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "NetworkConnectEthernet";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkConnectEthernet();

	}


	/// <summary>
	///
	/// 
	/// </summary>
public partial class NetworkConnectWiFi : NetworkConnect {
    /// <summary>
    ///The SSID of the network to connect to. While SSIDs are usually encoded as UTF8, 
    ///the specifications actually specify a 0-32 octet binary field.
    /// </summary>

	[JsonPropertyName("SSID")]
	public virtual byte[]?					SSID  {get; set;} //

    /// <summary>
    ///Password to be used to connect to the SSID. Note that since this is
    ///sensitive data, DeviceConnect profiles containing password data MUST NOT
    ///be passed plaintext.
    /// </summary>

	[JsonPropertyName("Password")]
	public virtual string?					Password  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("SSID", 
					(IBinding data, byte[]? value) => {(data as NetworkConnectWiFi).SSID = value;}, 
					(IBinding data) => (data as NetworkConnectWiFi).SSID ),
		new PropertyString ("Password", 
					(IBinding data, string? value) => {(data as NetworkConnectWiFi).Password = value;}, 
					(IBinding data) => (data as NetworkConnectWiFi).Password )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NetworkConnectWiFi> _binding = new (
			new() {
			{ "SSID", _properties [0]},
			{ "Password", _properties [1]}}, __Tag,
		() => new NetworkConnectWiFi(), () => [], () => [], NetworkConnect._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "NetworkConnectWiFi";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkConnectWiFi();

	}


	/// <summary>
	///
	/// An onboarding service that MAY be reached through one or more local
	/// network connections.
	/// </summary>
public partial class OnboardingService : DeviceData {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Endpoint")]
	public virtual string?					Endpoint  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as OnboardingService).Id = value;}, 
					(IBinding data) => (data as OnboardingService).Id ),
		new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as OnboardingService).Protocol = value;}, 
					(IBinding data) => (data as OnboardingService).Protocol ),
		new PropertyString ("Endpoint", 
					(IBinding data, string? value) => {(data as OnboardingService).Endpoint = value;}, 
					(IBinding data) => (data as OnboardingService).Endpoint )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OnboardingService> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Protocol", _properties [1]},
			{ "Endpoint", _properties [2]}}, __Tag,
		() => new OnboardingService(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "OnboardingService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OnboardingService();

	}



