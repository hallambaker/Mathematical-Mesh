
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
//  This file was automatically generated at 3/7/2026 5:43:47 PM
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

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Server;


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
public abstract partial class CatalogItem : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CatalogItem";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(AccountEntry), AccountEntry._binding},
	    {typeof(AccountUser), AccountUser._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static CatalogItem() {
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
	/// Represents a Mesh Account.
	/// </summary>
abstract public partial class AccountEntry : CatalogedEntry {
    /// <summary>
    ///Subdirectory containing the catalogs and spools for the account.
    /// </summary>

	[JsonPropertyName("Directory")]
	public virtual string?					Directory  {get; set;} //

    /// <summary>
    ///The fingerprint of the profile
    /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;} //

    /// <summary>
    ///The quota assigned to this user in KB
    /// </summary>

	[JsonPropertyName("Quota")]
	public virtual int?					Quota  {get; set;} //

    /// <summary>
    ///The profile status. Valid values are "Pending", "Connected", "Blocked"
    /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;} //

    /// <summary>
    ///Account address in user@domain format
    /// </summary>

	[JsonPropertyName("LocalAddress")]
	public virtual string?					LocalAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Directory", 
					(data, value) => {(data as AccountEntry).Directory = value;}, 
					data => (data as AccountEntry).Directory ),
		new PropertyString ("ProfileUdf", 
					(data, value) => {(data as AccountEntry).ProfileUdf = value;}, 
					data => (data as AccountEntry).ProfileUdf ),
		new PropertyInteger32 ("Quota", 
					(data, value) => {(data as AccountEntry).Quota = value;}, 
					data => (data as AccountEntry).Quota ),
		new PropertyString ("Status", 
					(data, value) => {(data as AccountEntry).Status = value;}, 
					data => (data as AccountEntry).Status ),
		new PropertyString ("LocalAddress", 
					(data, value) => {(data as AccountEntry).LocalAddress = value;}, 
					data => (data as AccountEntry).LocalAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccountEntry> _binding = new (
			new() {
			{ "Directory", _properties [0]},
			{ "ProfileUdf", _properties [1]},
			{ "Quota", _properties [2]},
			{ "Status", _properties [3]},
			{ "LocalAddress", _properties [4]}}, __Tag,
		null, () => [], () => [], CatalogedEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "AccountEntry";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();

	}


	/// <summary>
	///
	/// Represents a Mesh Account
	/// </summary>
public partial class AccountUser : AccountEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileUser")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileUser  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAccount?				ProfileUser  => EnvelopedProfileUser.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedAccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual AccountHostAssignment?				AccountHostAssignment  => EnvelopedAccountHostAssignment.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedProfileUser", typeof (Enveloped),
					(data, value) => {(data as AccountUser).EnvelopedProfileUser = value as Enveloped<ProfileAccount>;},
					data => (data as AccountUser).EnvelopedProfileUser,
					()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyGStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped),
					(data, value) => {(data as AccountUser).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;},
					data => (data as AccountUser).EnvelopedAccountHostAssignment,
					()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccountUser> _binding = new (
			new() {
			{ "EnvelopedProfileUser", _properties [0]},
			{ "EnvelopedAccountHostAssignment", _properties [1]}}, __Tag,
		() => new AccountUser(), () => [], () => [], AccountEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "AccountUser";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AccountUser();

	}



