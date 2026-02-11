
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
//  This file was automatically generated at 2/5/2026 4:12:57 PM
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

#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(ProfileCarnet), ProfileCarnet._binding},
	    {typeof(CatalogedCarnet), CatalogedCarnet._binding},
	    {typeof(CarnetRequest), CarnetRequest._binding},
	    {typeof(CarnetResponse), CarnetResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static CarnetProtocol() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

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
	public override Dictionary<string, Type>  GetTagDictionary => _TagDictionary;
		
	static Dictionary<string, Type> _TagDictionary = new () {
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

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileCarnet> _binding = new (
			new() {}, __Tag,
		() => new ProfileCarnet(), () => [], () => [], ProfileService._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedCarnet : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    ///The connection allowing control of the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;} //

    /// <summary>
    ///The Mesh profile
    /// </summary>

	[JsonPropertyName("EnvelopedProfileCarnet")]
	public virtual Enveloped<ProfileCarnet>?					EnvelopedProfileCarnet  {get; set;} //

    /// <summary>
    ///The activation data for the registry.
    /// </summary>

	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as CatalogedCarnet).Key = value;}, 
					data => (data as CatalogedCarnet).Key ),
		new PropertyStruct ("EnvelopedConnectionAddress", typeof (Enveloped<ConnectionStripped>),
					(data, value) => {(data as CatalogedCarnet).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, 
					data => (data as CatalogedCarnet).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>()),
		new PropertyStruct ("EnvelopedProfileCarnet", typeof (Enveloped<ProfileCarnet>),
					(data, value) => {(data as CatalogedCarnet).EnvelopedProfileCarnet = value as Enveloped<ProfileCarnet>;}, 
					data => (data as CatalogedCarnet).EnvelopedProfileCarnet,
					false, ()=>new  Enveloped<ProfileCarnet>(), ()=>new Enveloped<ProfileCarnet>()),
		new PropertyStruct ("EnvelopedActivationCommon", typeof (Enveloped<ActivationCommon>),
					(data, value) => {(data as CatalogedCarnet).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, 
					data => (data as CatalogedCarnet).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedCarnet> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "EnvelopedConnectionAddress", _properties [1]},
			{ "EnvelopedProfileCarnet", _properties [2]},
			{ "EnvelopedActivationCommon", _properties [3]}}, __Tag,
		() => new CatalogedCarnet(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class CarnetRequest : Goedel.Protocol.Request {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CarnetRequest> _binding = new (
			new() {}, __Tag,
		() => new CarnetRequest(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class CarnetResponse : Goedel.Protocol.Response {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CarnetResponse> _binding = new (
			new() {}, __Tag,
		() => new CarnetResponse(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


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

	}



