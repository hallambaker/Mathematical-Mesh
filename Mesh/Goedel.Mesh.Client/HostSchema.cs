
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
//  This file was automatically generated at 07-Feb-23 12:23:03 AM
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


namespace Goedel.Mesh.Client;


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
public abstract partial class HostCatalogItem : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "HostCatalogItem";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"CatalogedMachine", CatalogedMachine._Factory},
	    {"CatalogedService", CatalogedService._Factory},
	    {"CatalogedStandard", CatalogedStandard._Factory},
	    {"CatalogedPending", CatalogedPending._Factory},
	    {"CatalogedPreconfigured", CatalogedPreconfigured._Factory}
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
	/// Describes a current or pending connection to a Mesh
	/// </summary>
public partial class CatalogedMachine : HostCatalogItem {
        /// <summary>
        ///Unique object instance identifier.
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///Local short name for the profile
        /// </summary>

	public virtual string						Local  {get; set;}
        /// <summary>
        ///If true, this is the default for the profile type (master, account)
        /// </summary>

	public virtual bool?						Default  {get; set;}
        /// <summary>
        ///The master profile that provides the root of trust for this Mesh
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///The cataloged device profile
        /// </summary>

	public virtual CatalogedDevice						CatalogedDevice  {get; set;}
        /// <summary>
        ///The digest of the cataloged device.
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>						EnvelopedAccountHostAssignment  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Local" : {
				if (value is TokenValueString vvalue) {
					Local = vvalue.Value;
					}
				break;
				}
			case "Default" : {
				if (value is TokenValueBoolean vvalue) {
					Default = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileAccount = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "CatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedDevice = vvalue.Value as CatalogedDevice;
					}
				break;
				}
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Local" : {
				return new TokenValueString (Local);
				}
			case "Default" : {
				return new TokenValueBoolean (Default);
				}
			case "EnvelopedProfileAccount" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileAccount);
				}
			case "CatalogedDevice" : {
				return new TokenValueStruct<CatalogedDevice> (CatalogedDevice);
				}
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
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

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Local", new Property (typeof(TokenValueString), false)} ,
			{ "Default", new Property (typeof(TokenValueBoolean), false)} ,
			{ "EnvelopedProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "CatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedDevice(), ()=>new CatalogedDevice(), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedAccountHostAssignment", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>(), false)} 
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
	public new const string __Tag = "CatalogedMachine";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedMachine();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedMachine FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedMachine;
			}
		var Result = new CatalogedMachine ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedService : CatalogedMachine {
        /// <summary>
        ///The service profile
        /// </summary>

	public virtual Enveloped<ProfileService>						EnvelopedProfileService  {get; set;}
        /// <summary>
        ///The host profile
        /// </summary>

	public virtual Enveloped<ProfileHost>						EnvelopedProfileHost  {get; set;}
        /// <summary>
        ///The activation record for the service client (if used)
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}
        /// <summary>
        ///The activation record for this host
        /// </summary>

	public virtual Enveloped<ActivationHost>						EnvelopedActivationHost  {get; set;}
        /// <summary>
        ///The connection of the host to the service
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}
        /// <summary>
        ///Specifies the type of service 
        /// </summary>

	public virtual string						ServiceIdentifier  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedProfileService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileService = vvalue.Value as Enveloped<ProfileService>;
					}
				break;
				}
			case "EnvelopedProfileHost" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileHost = vvalue.Value as Enveloped<ProfileHost>;
					}
				break;
				}
			case "EnvelopedActivationCommon" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationCommon = vvalue.Value as Enveloped<ActivationCommon>;
					}
				break;
				}
			case "EnvelopedActivationHost" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationHost = vvalue.Value as Enveloped<ActivationHost>;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
					}
				break;
				}
			case "ServiceIdentifier" : {
				if (value is TokenValueString vvalue) {
					ServiceIdentifier = vvalue.Value;
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
			case "EnvelopedProfileService" : {
				return new TokenValueStruct<Enveloped<ProfileService>> (EnvelopedProfileService);
				}
			case "EnvelopedProfileHost" : {
				return new TokenValueStruct<Enveloped<ProfileHost>> (EnvelopedProfileHost);
				}
			case "EnvelopedActivationCommon" : {
				return new TokenValueStruct<Enveloped<ActivationCommon>> (EnvelopedActivationCommon);
				}
			case "EnvelopedActivationHost" : {
				return new TokenValueStruct<Enveloped<ActivationHost>> (EnvelopedActivationHost);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}
			case "ServiceIdentifier" : {
				return new TokenValueString (ServiceIdentifier);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>(), false)} ,
			{ "EnvelopedProfileHost", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileHost>(), ()=>new Enveloped<ProfileHost>(), false)} ,
			{ "EnvelopedActivationCommon", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>(), false)} ,
			{ "EnvelopedActivationHost", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationHost>(), ()=>new Enveloped<ActivationHost>(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} ,
			{ "ServiceIdentifier", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedService;
			}
		var Result = new CatalogedService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
public partial class CatalogedStandard : CatalogedMachine {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

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

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedStandard";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedStandard();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedStandard FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedStandard;
			}
		var Result = new CatalogedStandard ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a pending connection to a Mesh account believed to have been 
	/// created and posted to a service.
	/// </summary>
public partial class CatalogedPending : CatalogedMachine {
        /// <summary>
        ///UDF of the connected device
        /// </summary>

	public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

	public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The response returned by the service when the registration was requested.
        /// </summary>

	public virtual Enveloped<AcknowledgeConnection>						EnvelopedAcknowledgeConnection  {get; set;}
        /// <summary>
        ///The account at which the request is pending.
        /// </summary>

	public virtual string						AccountAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DeviceUDF" : {
				if (value is TokenValueString vvalue) {
					DeviceUDF = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileDevice = vvalue.Value as Enveloped<ProfileDevice>;
					}
				break;
				}
			case "EnvelopedAcknowledgeConnection" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedAcknowledgeConnection = vvalue.Value as Enveloped<AcknowledgeConnection>;
					}
				break;
				}
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
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
			case "DeviceUDF" : {
				return new TokenValueString (DeviceUDF);
				}
			case "EnvelopedProfileDevice" : {
				return new TokenValueStruct<Enveloped<ProfileDevice>> (EnvelopedProfileDevice);
				}
			case "EnvelopedAcknowledgeConnection" : {
				return new TokenValueStruct<Enveloped<AcknowledgeConnection>> (EnvelopedAcknowledgeConnection);
				}
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceUDF", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>(), false)} ,
			{ "EnvelopedAcknowledgeConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>(), false)} ,
			{ "AccountAddress", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedPending";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPending();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedPending FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedPending;
			}
		var Result = new CatalogedPending ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a preconfigured Device Profile bound to a remote 
	/// manufacturer profile.
	/// </summary>
public partial class CatalogedPreconfigured : CatalogedMachine {
        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

	public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The device connection used to authenticate to the service.
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}
        /// <summary>
        ///The device connection used to authenticate to the service.
        /// </summary>

	public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionDevice  {get; set;}
        /// <summary>
        ///The account to which claims will be posted
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///The publication identifier
        /// </summary>

	public virtual string						PublicationId  {get; set;}
        /// <summary>
        ///Authenticator key used to authenticate claim to the service.
        /// </summary>

	public virtual string						ServiceAuthenticator  {get; set;}
        /// <summary>
        ///Authenticator key used to authenticate claim to the device.	
        /// </summary>

	public virtual string						DeviceAuthenticator  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileDevice = vvalue.Value as Enveloped<ProfileDevice>;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
					}
				break;
				}
			case "EnvelopedConnectionDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionDevice = vvalue.Value as Enveloped<ConnectionDevice>;
					}
				break;
				}
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "PublicationId" : {
				if (value is TokenValueString vvalue) {
					PublicationId = vvalue.Value;
					}
				break;
				}
			case "ServiceAuthenticator" : {
				if (value is TokenValueString vvalue) {
					ServiceAuthenticator = vvalue.Value;
					}
				break;
				}
			case "DeviceAuthenticator" : {
				if (value is TokenValueString vvalue) {
					DeviceAuthenticator = vvalue.Value;
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
			case "EnvelopedProfileDevice" : {
				return new TokenValueStruct<Enveloped<ProfileDevice>> (EnvelopedProfileDevice);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}
			case "EnvelopedConnectionDevice" : {
				return new TokenValueStruct<Enveloped<ConnectionDevice>> (EnvelopedConnectionDevice);
				}
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "PublicationId" : {
				return new TokenValueString (PublicationId);
				}
			case "ServiceAuthenticator" : {
				return new TokenValueString (ServiceAuthenticator);
				}
			case "DeviceAuthenticator" : {
				return new TokenValueString (DeviceAuthenticator);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} ,
			{ "EnvelopedConnectionDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>(), false)} ,
			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "PublicationId", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceAuthenticator", new Property (typeof(TokenValueString), false)} ,
			{ "DeviceAuthenticator", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedMachine._StaticAllProperties);


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
	public new const string __Tag = "CatalogedPreconfigured";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPreconfigured();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedPreconfigured FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedPreconfigured;
			}
		var Result = new CatalogedPreconfigured ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



