
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
//  This file was automatically generated at 18-Jan-23 7:29:14 PM
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
using Goedel.Callsign;
using Goedel.Mesh;


namespace Goedel.Callsign.Registry;


	/// <summary>
	///
	/// Callsign Registry Protocol providing registry interactions.
	/// Protocol interactions supported by the Mesh Service.
	/// 
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
	    {"ApplicationEntryRegistry", ApplicationEntryRegistry._Factory},
	    {"CallsignRequest", CallsignRequest._Factory},
	    {"CallsignResponse", CallsignResponse._Factory},
	    {"RegisterRequest", RegisterRequest._Factory},
	    {"RegisterResponse", RegisterResponse._Factory},
	    {"NotarizeRequest", NotarizeRequest._Factory},
	    {"NotarizeResponse", NotarizeResponse._Factory}
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


/// <summary>
/// The new base class for the client and service side APIs.
/// </summary>		
public abstract partial class RegistryService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "callsignreg";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_callsignreg._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, JsonFactoryDelegate>  GetTagDictionary() => _TagDictionary;
		
	static Dictionary<string, JsonFactoryDelegate> _TagDictionary = new () {
				{"Register", RegisterRequest._Factory},
				{"Notarize", NotarizeRequest._Factory}
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		"Register" => Register(request as RegisterRequest, session),
		"Notarize" => Notarize(request as NotarizeRequest, session),
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new RegistryServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    /// <summary>
	/// Base method for implementing the transaction Register.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract RegisterResponse Register (
            RegisterRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Notarize.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract NotarizeResponse Notarize (
            NotarizeRequest request, IJpcSession session);

    }

/// <summary>
/// Client class for RegistryService.
/// </summary>		
public partial class RegistryServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "callsignreg";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_callsignreg._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual RegisterResponse Register (RegisterRequest request) =>
			JpcSession.Post("Register", request) as RegisterResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual NotarizeResponse Notarize (NotarizeRequest request) =>
			JpcSession.Post("Notarize", request) as NotarizeResponse;


	}

/// <summary>
/// Direct API class for RegistryService.
/// </summary>		
public partial class RegistryServiceDirect: RegistryServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public RegistryService Service {get; set;}


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override RegisterResponse Register (RegisterRequest request) =>
			Service.Register (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override NotarizeResponse Notarize (NotarizeRequest request) =>
			Service.Notarize (request, JpcSession);


		}




	// Transaction Classes
	/// <summary>
	/// </summary>
public partial class CatalogedRegistry : CatalogedApplication {
        /// <summary>
        ///The connection allowing control of the registry.
        /// </summary>

	public virtual Enveloped<ConnectionStripped>						EnvelopedConnectionAddress  {get; set;}
        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileRegistry  {get; set;}
        /// <summary>
        ///The activation data for the registry.
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedConnectionAddress" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionAddress = vvalue.Value as Enveloped<ConnectionStripped>;
					}
				break;
				}
			case "EnvelopedProfileRegistry" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileRegistry = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedActivationCommon" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationCommon = vvalue.Value as Enveloped<ActivationCommon>;
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
			case "EnvelopedConnectionAddress" : {
				return new TokenValueStruct<Enveloped<ConnectionStripped>> (EnvelopedConnectionAddress);
				}
			case "EnvelopedProfileRegistry" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileRegistry);
				}
			case "EnvelopedActivationCommon" : {
				return new TokenValueStruct<Enveloped<ActivationCommon>> (EnvelopedActivationCommon);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedConnectionAddress", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>(), false)} ,
			{ "EnvelopedProfileRegistry", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedActivationCommon", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>(), false)} 
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

	public virtual KeyData						AccountEncryption  {get; set;}
        /// <summary>
        ///Key or capability used to sign the registry log
        /// </summary>

	public virtual KeyData						AdministratorSignature  {get; set;}
        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					AccountEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "AdministratorSignature" : {
				if (value is TokenValueStructObject vvalue) {
					AdministratorSignature = vvalue.Value as KeyData;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
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
			case "AccountEncryption" : {
				return new TokenValueStruct<KeyData> (AccountEncryption);
				}
			case "AdministratorSignature" : {
				return new TokenValueStruct<KeyData> (AdministratorSignature);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "AdministratorSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} 
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

	public virtual Enveloped<ActivationApplicationRegistry>						EnvelopedActivation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedActivation" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivation = vvalue.Value as Enveloped<ActivationApplicationRegistry>;
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
			case "EnvelopedActivation" : {
				return new TokenValueStruct<Enveloped<ActivationApplicationRegistry>> (EnvelopedActivation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationApplicationRegistry>(), ()=>new Enveloped<ActivationApplicationRegistry>(), false)} 
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

	/// <summary>
	///
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class CallsignRequest : Goedel.Protocol.Request {


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
			Combine(_StaticProperties, Goedel.Protocol.Request._StaticAllProperties);


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
	public new const string __Tag = "CallsignRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignRequest;
			}
		var Result = new CallsignRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class CallsignResponse : Goedel.Protocol.Response {


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
			Combine(_StaticProperties, Goedel.Protocol.Response._StaticAllProperties);


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
	public new const string __Tag = "CallsignResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignResponse;
			}
		var Result = new CallsignResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request registration of a callsign.
	/// </summary>
public partial class RegisterRequest : CallsignRequest {
        /// <summary>
        ///If present, specifies a previous registration with the same identifier.
        /// </summary>

	public virtual string						PriorId  {get; set;}
        /// <summary>
        ///Reason for creating a registration:
        ///Initial/ Update/ Voluntary/ Administrative/ Revoke
        /// </summary>

	public virtual string						Reason  {get; set;}
        /// <summary>
        ///The callsign request signed by the party to which the callsign is to
        ///be granted.
        /// </summary>

	public virtual Enveloped<CallsignBinding>						EnvelopedCallsign  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PriorId" : {
				if (value is TokenValueString vvalue) {
					PriorId = vvalue.Value;
					}
				break;
				}
			case "Reason" : {
				if (value is TokenValueString vvalue) {
					Reason = vvalue.Value;
					}
				break;
				}
			case "EnvelopedCallsign" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCallsign = vvalue.Value as Enveloped<CallsignBinding>;
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
			case "PriorId" : {
				return new TokenValueString (PriorId);
				}
			case "Reason" : {
				return new TokenValueString (Reason);
				}
			case "EnvelopedCallsign" : {
				return new TokenValueStruct<Enveloped<CallsignBinding>> (EnvelopedCallsign);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PriorId", new Property (typeof(TokenValueString), false)} ,
			{ "Reason", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedCallsign", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CallsignRequest._StaticAllProperties);


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
	public new const string __Tag = "RegisterRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RegisterRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RegisterRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RegisterRequest;
			}
		var Result = new RegisterRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Reports the success or failure of a registration.
	/// </summary>
public partial class RegisterResponse : CallsignResponse {
        /// <summary>
        ///The registration (if created).
        /// </summary>

	public virtual Enveloped<Registration>						Result  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Result" : {
				if (value is TokenValueStructObject vvalue) {
					Result = vvalue.Value as Enveloped<Registration>;
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
			case "Result" : {
				return new TokenValueStruct<Enveloped<Registration>> (Result);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Registration>(), ()=>new Enveloped<Registration>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CallsignResponse._StaticAllProperties);


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
	public new const string __Tag = "RegisterResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RegisterResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RegisterResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RegisterResponse;
			}
		var Result = new RegisterResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request registration of a callsign.
	/// </summary>
public partial class NotarizeRequest : CallsignRequest {
        /// <summary>
        ///The notary token to be included.
        /// </summary>

	public virtual Enveloped<Witness>						Witness  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Witness" : {
				if (value is TokenValueStructObject vvalue) {
					Witness = vvalue.Value as Enveloped<Witness>;
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
			case "Witness" : {
				return new TokenValueStruct<Enveloped<Witness>> (Witness);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Witness", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Witness>(), ()=>new Enveloped<Witness>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CallsignRequest._StaticAllProperties);


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
	public new const string __Tag = "NotarizeRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NotarizeRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NotarizeRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NotarizeRequest;
			}
		var Result = new NotarizeRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Reports the success or failure of a registration.
	/// </summary>
public partial class NotarizeResponse : CallsignResponse {
        /// <summary>
        ///The most recent witness value created by the service.
        /// </summary>

	public virtual Enveloped<Witness>						Witness  {get; set;}
        /// <summary>
        ///A notarization entry that includes the witness value specified in the request.
        /// </summary>

	public virtual Enveloped<Notarization>						Notarization  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Witness" : {
				if (value is TokenValueStructObject vvalue) {
					Witness = vvalue.Value as Enveloped<Witness>;
					}
				break;
				}
			case "Notarization" : {
				if (value is TokenValueStructObject vvalue) {
					Notarization = vvalue.Value as Enveloped<Notarization>;
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
			case "Witness" : {
				return new TokenValueStruct<Enveloped<Witness>> (Witness);
				}
			case "Notarization" : {
				return new TokenValueStruct<Enveloped<Notarization>> (Notarization);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Witness", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Witness>(), ()=>new Enveloped<Witness>(), false)} ,
			{ "Notarization", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Notarization>(), ()=>new Enveloped<Notarization>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CallsignResponse._StaticAllProperties);


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
	public new const string __Tag = "NotarizeResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NotarizeResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NotarizeResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NotarizeResponse;
			}
		var Result = new NotarizeResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



