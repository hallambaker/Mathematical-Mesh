
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
//  This file was automatically generated at 11-Oct-22 12:53:03 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1015
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
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
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"AccountEntry", AccountEntry._Factory},
	    {"AccountUser", AccountUser._Factory}
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
	/// Represents a Mesh Account.
	/// </summary>
abstract public partial class AccountEntry : CatalogItem {
        /// <summary>
        ///Subdirectory containing the catalogs and spools for the account.
        /// </summary>

	public virtual string						Directory  {get; set;}
        /// <summary>
        ///The fingerprint of the profile
        /// </summary>

	public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///The quota assigned to this user in KB
        /// </summary>

	public virtual int?						Quota  {get; set;}
        /// <summary>
        ///The profile status. Valid values are "Pending", "Connected", "Blocked"
        /// </summary>

	public virtual string						Status  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Directory" : {
				if (value is TokenValueString vvalue) {
					Directory = vvalue.Value;
					}
				break;
				}
			case "ProfileUdf" : {
				if (value is TokenValueString vvalue) {
					ProfileUdf = vvalue.Value;
					}
				break;
				}
			case "Quota" : {
				if (value is TokenValueInteger32 vvalue) {
					Quota = vvalue.Value;
					}
				break;
				}
			case "Status" : {
				if (value is TokenValueString vvalue) {
					Status = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Directory" : {
				return new TokenValueString (Directory);
				}
			case "ProfileUdf" : {
				return new TokenValueString (ProfileUdf);
				}
			case "Quota" : {
				return new TokenValueInteger32 (Quota);
				}
			case "Status" : {
				return new TokenValueString (Status);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Directory", new Property (typeof(TokenValueString), false)} ,
			{ "ProfileUdf", new Property (typeof(TokenValueString), false)} ,
			{ "Quota", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Status", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "AccountEntry";

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
    public static new AccountEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AccountEntry;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Represents a Mesh Account
	/// </summary>
public partial class AccountUser : AccountEntry {
        /// <summary>
        ///The signed assertion describing the account.
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileUser  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>						EnvelopedAccountHostAssignment  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedProfileUser" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileUser = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedAccountHostAssignment" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedAccountHostAssignment = vvalue.Value as Enveloped<AccountHostAssignment>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "EnvelopedProfileUser" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileUser);
				}
			case "EnvelopedAccountHostAssignment" : {
				return new TokenValueStruct<Enveloped<AccountHostAssignment>> (EnvelopedAccountHostAssignment);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileUser", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedAccountHostAssignment", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, AccountEntry._StaticAllProperties);


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
	public new const string __Tag = "AccountUser";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AccountUser();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AccountUser FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AccountUser;
			}
		var Result = new AccountUser ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



