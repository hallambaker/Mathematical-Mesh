
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
//  This file was automatically generated at 14-Jun-23 12:25:56 PM
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

using Goedel.Mesh;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;


namespace Goedel.Mesh;


	/// <summary>
	///
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class MeshProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshProtocol";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"MeshRequest", MeshRequest._Factory},
	    {"MeshRequestUser", MeshRequestUser._Factory},
	    {"MeshResponse", MeshResponse._Factory},
	    {"KeyValue", KeyValue._Factory},
	    {"ConstraintsSelect", ConstraintsSelect._Factory},
	    {"ConstraintsData", ConstraintsData._Factory},
	    {"PolicyAccount", PolicyAccount._Factory},
	    {"StoreStatus", StoreStatus._Factory},
	    {"StoreUpdate", StoreUpdate._Factory},
	    {"MeshHelloRequest", MeshHelloRequest._Factory},
	    {"MeshHelloResponse", MeshHelloResponse._Factory},
	    {"BindRequest", BindRequest._Factory},
	    {"BindResponse", BindResponse._Factory},
	    {"UnbindRequest", UnbindRequest._Factory},
	    {"UnbindResponse", UnbindResponse._Factory},
	    {"ConnectRequest", ConnectRequest._Factory},
	    {"ConnectResponse", ConnectResponse._Factory},
	    {"CompleteRequest", CompleteRequest._Factory},
	    {"CompleteResponse", CompleteResponse._Factory},
	    {"StatusRequest", StatusRequest._Factory},
	    {"StatusResponse", StatusResponse._Factory},
	    {"DeviceStatus", DeviceStatus._Factory},
	    {"DownloadRequest", DownloadRequest._Factory},
	    {"DownloadResponse", DownloadResponse._Factory},
	    {"TransactRequest", TransactRequest._Factory},
	    {"TransactResponse", TransactResponse._Factory},
	    {"EntryResponse", EntryResponse._Factory},
	    {"PublicRequest", PublicRequest._Factory},
	    {"PostRequest", PostRequest._Factory},
	    {"PostResponse", PostResponse._Factory},
	    {"ClaimRequest", ClaimRequest._Factory},
	    {"ClaimResponse", ClaimResponse._Factory},
	    {"PollClaimRequest", PollClaimRequest._Factory},
	    {"PollClaimResponse", PollClaimResponse._Factory},
	    {"CryptographicOperation", CryptographicOperation._Factory},
	    {"CryptographicOperationSign", CryptographicOperationSign._Factory},
	    {"CryptographicOperationKeyAgreement", CryptographicOperationKeyAgreement._Factory},
	    {"CryptographicOperationGenerate", CryptographicOperationGenerate._Factory},
	    {"CryptographicOperationShare", CryptographicOperationShare._Factory},
	    {"CryptographicResult", CryptographicResult._Factory},
	    {"CryptographicResultKeyAgreement", CryptographicResultKeyAgreement._Factory},
	    {"CryptographicResultShare", CryptographicResultShare._Factory},
	    {"OperateRequest", OperateRequest._Factory},
	    {"OperateResponse", OperateResponse._Factory}
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
public abstract partial class MeshService : Goedel.Protocol.JpcInterface {
		
    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "mmm";

	///<inheritdoc/>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_mmm._tcp";

	///<inheritdoc/>
	public override string GetDiscovery => Discovery;

	///<inheritdoc/>
	public override Dictionary<string, JsonFactoryDelegate>  GetTagDictionary() => _TagDictionary;
		
	static Dictionary<string, JsonFactoryDelegate> _TagDictionary = new () {
				{"Hello", HelloRequest._Factory},
				{"BindAccount", BindRequest._Factory},
				{"UnbindAccount", UnbindRequest._Factory},
				{"Connect", ConnectRequest._Factory},
				{"Complete", CompleteRequest._Factory},
				{"Status", StatusRequest._Factory},
				{"Download", DownloadRequest._Factory},
				{"Transact", TransactRequest._Factory},
				{"PublicRead", PublicRequest._Factory},
				{"Post", PostRequest._Factory},
				{"Claim", ClaimRequest._Factory},
				{"PollClaim", PollClaimRequest._Factory},
				{"Operate", OperateRequest._Factory}
		};

    ///<inheritdoc/>
	public override Goedel.Protocol.JsonObject Dispatch(
			string token,
			Goedel.Protocol.JsonObject request,
			IJpcSession session) => token switch {
		"Hello" => Hello(request as HelloRequest, session),
		"BindAccount" => BindAccount(request as BindRequest, session),
		"UnbindAccount" => UnbindAccount(request as UnbindRequest, session),
		"Connect" => Connect(request as ConnectRequest, session),
		"Complete" => Complete(request as CompleteRequest, session),
		"Status" => Status(request as StatusRequest, session),
		"Download" => Download(request as DownloadRequest, session),
		"Transact" => Transact(request as TransactRequest, session),
		"PublicRead" => PublicRead(request as PublicRequest, session),
		"Post" => Post(request as PostRequest, session),
		"Claim" => Claim(request as ClaimRequest, session),
		"PollClaim" => PollClaim(request as PollClaimRequest, session),
		"Operate" => Operate(request as OperateRequest, session),
		_ => throw new Goedel.Protocol.UnknownOperation(),
        };





    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
	public override Goedel.Protocol.JpcClientInterface GetDirect (IJpcSession jpcSession) =>
			new MeshServiceDirect () {
					JpcSession = jpcSession,
					Service = this
					};


    /// <summary>
	/// Base method for implementing the transaction Hello.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract MeshHelloResponse Hello (
            HelloRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction BindAccount.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract BindResponse BindAccount (
            BindRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction UnbindAccount.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract UnbindResponse UnbindAccount (
            UnbindRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Connect.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract ConnectResponse Connect (
            ConnectRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Complete.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract CompleteResponse Complete (
            CompleteRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Status.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract StatusResponse Status (
            StatusRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Download.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract DownloadResponse Download (
            DownloadRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Transact.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract TransactResponse Transact (
            TransactRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction PublicRead.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract DownloadResponse PublicRead (
            PublicRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Post.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract PostResponse Post (
            PostRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Claim.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract ClaimResponse Claim (
            ClaimRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction PollClaim.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract PollClaimResponse PollClaim (
            PollClaimRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction Operate.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract OperateResponse Operate (
            OperateRequest request, IJpcSession session);

    }

/// <summary>
/// Client class for MeshService.
/// </summary>		
public partial class MeshServiceClient : Goedel.Protocol.JpcClientInterface {

	/// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string WellKnown = "mmm";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetWellKnown => WellKnown;

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public const string Discovery = "_mmm._tcp";

    /// <summary>
    /// Well Known service identifier.
    /// </summary>
	public override string GetDiscovery => Discovery;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual MeshHelloResponse Hello (HelloRequest request) =>
			JpcSession.Post("Hello", request) as MeshHelloResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual BindResponse BindAccount (BindRequest request) =>
			JpcSession.Post("BindAccount", request) as BindResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual UnbindResponse UnbindAccount (UnbindRequest request) =>
			JpcSession.Post("UnbindAccount", request) as UnbindResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual ConnectResponse Connect (ConnectRequest request) =>
			JpcSession.Post("Connect", request) as ConnectResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual CompleteResponse Complete (CompleteRequest request) =>
			JpcSession.Post("Complete", request) as CompleteResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual StatusResponse Status (StatusRequest request) =>
			JpcSession.Post("Status", request) as StatusResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual DownloadResponse Download (DownloadRequest request) =>
			JpcSession.Post("Download", request) as DownloadResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual TransactResponse Transact (TransactRequest request) =>
			JpcSession.Post("Transact", request) as TransactResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual DownloadResponse PublicRead (PublicRequest request) =>
			JpcSession.Post("PublicRead", request) as DownloadResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual PostResponse Post (PostRequest request) =>
			JpcSession.Post("Post", request) as PostResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual ClaimResponse Claim (ClaimRequest request) =>
			JpcSession.Post("Claim", request) as ClaimResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual PollClaimResponse PollClaim (PollClaimRequest request) =>
			JpcSession.Post("PollClaim", request) as PollClaimResponse;

    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual OperateResponse Operate (OperateRequest request) =>
			JpcSession.Post("Operate", request) as OperateResponse;


	}

/// <summary>
/// Direct API class for MeshService.
/// </summary>		
public partial class MeshServiceDirect: MeshServiceClient {
 		
	/// <summary>
	/// Interface object to dispatch requests to.
	/// </summary>	
	public MeshService Service {get; set;}


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override MeshHelloResponse Hello (HelloRequest request) =>
			Service.Hello (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override BindResponse BindAccount (BindRequest request) =>
			Service.BindAccount (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override UnbindResponse UnbindAccount (UnbindRequest request) =>
			Service.UnbindAccount (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override ConnectResponse Connect (ConnectRequest request) =>
			Service.Connect (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override CompleteResponse Complete (CompleteRequest request) =>
			Service.Complete (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override StatusResponse Status (StatusRequest request) =>
			Service.Status (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override DownloadResponse Download (DownloadRequest request) =>
			Service.Download (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override TransactResponse Transact (TransactRequest request) =>
			Service.Transact (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override DownloadResponse PublicRead (PublicRequest request) =>
			Service.PublicRead (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override PostResponse Post (PostRequest request) =>
			Service.Post (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override ClaimResponse Claim (ClaimRequest request) =>
			Service.Claim (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override PollClaimResponse PollClaim (PollClaimRequest request) =>
			Service.PollClaim (request, JpcSession);


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override OperateResponse Operate (OperateRequest request) =>
			Service.Operate (request, JpcSession);


		}




	// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
public partial class MeshRequest : Goedel.Protocol.Request {


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
	public new const string __Tag = "MeshRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MeshRequest;
			}
		var Result = new MeshRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for all request messages made by a user.
	/// </summary>
public partial class MeshRequestUser : MeshRequest {
        /// <summary>
        ///The fully qualified account name (including DNS address) to which the
        ///request is directed.
        /// </summary>

	public virtual string						Account  {get; set;}
        /// <summary>
        ///The identifier of the capability under which access is claimed.
        /// </summary>

	public virtual string						Capability  {get; set;}
        /// <summary>
        ///Device profile of the device making the request.
        /// </summary>

	public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Account" : {
				if (value is TokenValueString vvalue) {
					Account = vvalue.Value;
					}
				break;
				}
			case "Capability" : {
				if (value is TokenValueString vvalue) {
					Capability = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileDevice = vvalue.Value as Enveloped<ProfileDevice>;
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
			case "Account" : {
				return new TokenValueString (Account);
				}
			case "Capability" : {
				return new TokenValueString (Capability);
				}
			case "EnvelopedProfileDevice" : {
				return new TokenValueStruct<Enveloped<ProfileDevice>> (EnvelopedProfileDevice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new Property (typeof(TokenValueString), false)} ,
			{ "Capability", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "MeshRequestUser";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshRequestUser();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshRequestUser FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MeshRequestUser;
			}
		var Result = new MeshRequestUser ();
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
public partial class MeshResponse : Goedel.Protocol.Response {


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
	public new const string __Tag = "MeshResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MeshResponse;
			}
		var Result = new MeshResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a Key/Value structure used to make queries
	/// for records matching one or more selection criteria.
	/// </summary>
public partial class KeyValue : MeshProtocol {
        /// <summary>
        ///The data retrieval key.
        /// </summary>

	public virtual string						Key  {get; set;}
        /// <summary>
        ///The data value to match.
        /// </summary>

	public virtual string						Value  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Value" : {
				if (value is TokenValueString vvalue) {
					Value = vvalue.Value;
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
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Value" : {
				return new TokenValueString (Value);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Value", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "KeyValue";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyValue();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new KeyValue FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyValue;
			}
		var Result = new KeyValue ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies constraints to be applied to a search result. These 
	/// allow a client to limit the number of records returned, the quantity
	/// of data returned, the earliest and latest data returned, etc.
	/// </summary>
public partial class ConstraintsSelect : MeshProtocol {
        /// <summary>
        ///The container to be searched.
        /// </summary>

	public virtual string						Store  {get; set;}
        /// <summary>
        ///Only return objects with an index value that is equal to or
        ///higher than the value specified.
        /// </summary>

	public virtual long?						IndexMin  {get; set;}
        /// <summary>
        ///Only return objects with an index value that is equal to or
        ///lower than the value specified.
        /// </summary>

	public virtual long?						IndexMax  {get; set;}
        /// <summary>
        ///Only data published on or after the specified time instant 
        ///is requested.
        /// </summary>

	public virtual DateTime?						NotBefore  {get; set;}
        /// <summary>
        ///Only data published before the specified time instant is
        ///requested. This excludes data published at the specified time instant.
        /// </summary>

	public virtual DateTime?						Before  {get; set;}
        /// <summary>
        ///Specifies a page key returned in a previous search operation
        ///in which the number of responses exceeded the specified bounds.
        ///When a page key is specified, all the other search parameters
        ///except for MaxEntries and MaxBytes are ignored and the service
        ///returns the next set of data responding to the earlier query.
        /// </summary>

	public virtual string						PageKey  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Store" : {
				if (value is TokenValueString vvalue) {
					Store = vvalue.Value;
					}
				break;
				}
			case "IndexMin" : {
				if (value is TokenValueInteger64 vvalue) {
					IndexMin = vvalue.Value;
					}
				break;
				}
			case "IndexMax" : {
				if (value is TokenValueInteger64 vvalue) {
					IndexMax = vvalue.Value;
					}
				break;
				}
			case "NotBefore" : {
				if (value is TokenValueDateTime vvalue) {
					NotBefore = vvalue.Value;
					}
				break;
				}
			case "Before" : {
				if (value is TokenValueDateTime vvalue) {
					Before = vvalue.Value;
					}
				break;
				}
			case "PageKey" : {
				if (value is TokenValueString vvalue) {
					PageKey = vvalue.Value;
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
			case "Store" : {
				return new TokenValueString (Store);
				}
			case "IndexMin" : {
				return new TokenValueInteger64 (IndexMin);
				}
			case "IndexMax" : {
				return new TokenValueInteger64 (IndexMax);
				}
			case "NotBefore" : {
				return new TokenValueDateTime (NotBefore);
				}
			case "Before" : {
				return new TokenValueDateTime (Before);
				}
			case "PageKey" : {
				return new TokenValueString (PageKey);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Store", new Property (typeof(TokenValueString), false)} ,
			{ "IndexMin", new Property (typeof(TokenValueInteger64), false)} ,
			{ "IndexMax", new Property (typeof(TokenValueInteger64), false)} ,
			{ "NotBefore", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Before", new Property (typeof(TokenValueDateTime), false)} ,
			{ "PageKey", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "ConstraintsSelect";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConstraintsSelect();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConstraintsSelect FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConstraintsSelect;
			}
		var Result = new ConstraintsSelect ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Specifies constraints on the data to be sent.
	/// </summary>
public partial class ConstraintsData : MeshProtocol {
        /// <summary>
        ///Maximum number of entries to send.
        /// </summary>

	public virtual long?						MaxEntries  {get; set;}
        /// <summary>
        ///Specifies an offset to be applied to the payload data before it is sent. 
        ///This allows large payloads to be transferred incrementally.
        /// </summary>

	public virtual long?						BytesOffset  {get; set;}
        /// <summary>
        ///Maximum number of payload bytes to send.
        /// </summary>

	public virtual long?						BytesMax  {get; set;}
        /// <summary>
        ///Return the entry header
        /// </summary>

	public virtual bool?						Header  {get; set;}
        /// <summary>
        ///Return the entry payload
        /// </summary>

	public virtual bool?						Payload  {get; set;}
        /// <summary>
        ///Return the entry trailer
        /// </summary>

	public virtual bool?						Trailer  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MaxEntries" : {
				if (value is TokenValueInteger64 vvalue) {
					MaxEntries = vvalue.Value;
					}
				break;
				}
			case "BytesOffset" : {
				if (value is TokenValueInteger64 vvalue) {
					BytesOffset = vvalue.Value;
					}
				break;
				}
			case "BytesMax" : {
				if (value is TokenValueInteger64 vvalue) {
					BytesMax = vvalue.Value;
					}
				break;
				}
			case "Header" : {
				if (value is TokenValueBoolean vvalue) {
					Header = vvalue.Value;
					}
				break;
				}
			case "Payload" : {
				if (value is TokenValueBoolean vvalue) {
					Payload = vvalue.Value;
					}
				break;
				}
			case "Trailer" : {
				if (value is TokenValueBoolean vvalue) {
					Trailer = vvalue.Value;
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
			case "MaxEntries" : {
				return new TokenValueInteger64 (MaxEntries);
				}
			case "BytesOffset" : {
				return new TokenValueInteger64 (BytesOffset);
				}
			case "BytesMax" : {
				return new TokenValueInteger64 (BytesMax);
				}
			case "Header" : {
				return new TokenValueBoolean (Header);
				}
			case "Payload" : {
				return new TokenValueBoolean (Payload);
				}
			case "Trailer" : {
				return new TokenValueBoolean (Trailer);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MaxEntries", new Property (typeof(TokenValueInteger64), false)} ,
			{ "BytesOffset", new Property (typeof(TokenValueInteger64), false)} ,
			{ "BytesMax", new Property (typeof(TokenValueInteger64), false)} ,
			{ "Header", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Payload", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Trailer", new Property (typeof(TokenValueBoolean), false)} 
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
	public new const string __Tag = "ConstraintsData";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConstraintsData();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConstraintsData FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConstraintsData;
			}
		var Result = new ConstraintsData ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes the account creation policy including constraints on 
	/// account names, whether there is an open account creation policy, etc.
	/// </summary>
public partial class PolicyAccount : MeshProtocol {
        /// <summary>
        ///Specifies the minimum length of an account name.
        /// </summary>

	public virtual int?						Minimum  {get; set;}
        /// <summary>
        ///Specifies the maximum length of an account name.
        /// </summary>

	public virtual int?						Maximum  {get; set;}
        /// <summary>
        ///A list of characters that the service 
        ///does not accept in account names. The list of characters 
        ///MAY not be exhaustive but SHOULD include any illegal characters
        ///in the proposed account name.
        /// </summary>

	public virtual string						InvalidCharacters  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Minimum" : {
				if (value is TokenValueInteger32 vvalue) {
					Minimum = vvalue.Value;
					}
				break;
				}
			case "Maximum" : {
				if (value is TokenValueInteger32 vvalue) {
					Maximum = vvalue.Value;
					}
				break;
				}
			case "InvalidCharacters" : {
				if (value is TokenValueString vvalue) {
					InvalidCharacters = vvalue.Value;
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
			case "Minimum" : {
				return new TokenValueInteger32 (Minimum);
				}
			case "Maximum" : {
				return new TokenValueInteger32 (Maximum);
				}
			case "InvalidCharacters" : {
				return new TokenValueString (InvalidCharacters);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Minimum", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Maximum", new Property (typeof(TokenValueInteger32), false)} ,
			{ "InvalidCharacters", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "PolicyAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PolicyAccount();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PolicyAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PolicyAccount;
			}
		var Result = new PolicyAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class StoreStatus : MeshProtocol {
        /// <summary>
        /// </summary>

	public virtual string						Store  {get; set;}
        /// <summary>
        /// </summary>

	public virtual long?						Index  {get; set;}
        /// <summary>
        ///In a status response, the apex digest value of the store 
        ///whose status is reported.
        /// </summary>

	public virtual byte[]						Digest  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Store" : {
				if (value is TokenValueString vvalue) {
					Store = vvalue.Value;
					}
				break;
				}
			case "Index" : {
				if (value is TokenValueInteger64 vvalue) {
					Index = vvalue.Value;
					}
				break;
				}
			case "Digest" : {
				if (value is TokenValueBinary vvalue) {
					Digest = vvalue.Value;
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
			case "Store" : {
				return new TokenValueString (Store);
				}
			case "Index" : {
				return new TokenValueInteger64 (Index);
				}
			case "Digest" : {
				return new TokenValueBinary (Digest);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Store", new Property (typeof(TokenValueString), false)} ,
			{ "Index", new Property (typeof(TokenValueInteger64), false)} ,
			{ "Digest", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "StoreStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new StoreStatus();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new StoreStatus FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as StoreStatus;
			}
		var Result = new StoreStatus ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class StoreUpdate : StoreStatus {
        /// <summary>
        ///The entries to be uploaded. 
        /// </summary>

	public virtual List<DareEnvelope>				Envelopes  {get; set;}
        /// <summary>
        ///If false, the store update does not contain the last index entry
        ///in the store.
        /// </summary>

	public virtual bool?						Partial  {get; set;}
        /// <summary>
        ///If the value Partial is true, this value MUST specify the index
        ///value of the last entry in the store.
        /// </summary>

	public virtual long?						FinalIndex  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Envelopes" : {
				if (value is TokenValueListStructObject vvalue) {
					Envelopes = vvalue.Value as List<DareEnvelope>;
					}
				break;
				}
			case "Partial" : {
				if (value is TokenValueBoolean vvalue) {
					Partial = vvalue.Value;
					}
				break;
				}
			case "FinalIndex" : {
				if (value is TokenValueInteger64 vvalue) {
					FinalIndex = vvalue.Value;
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
			case "Envelopes" : {
				return new TokenValueListStruct<DareEnvelope> (Envelopes);
				}
			case "Partial" : {
				return new TokenValueBoolean (Partial);
				}
			case "FinalIndex" : {
				return new TokenValueInteger64 (FinalIndex);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Envelopes", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DareEnvelope>(), ()=>new DareEnvelope(), false)} ,
			{ "Partial", new Property (typeof(TokenValueBoolean), false)} ,
			{ "FinalIndex", new Property (typeof(TokenValueInteger64), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, StoreStatus._StaticAllProperties);


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
	public new const string __Tag = "StoreUpdate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new StoreUpdate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new StoreUpdate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as StoreUpdate;
			}
		var Result = new StoreUpdate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MeshHelloRequest : Goedel.Protocol.HelloRequest {
        /// <summary>
        ///Contains a proposed callsign binding to the account.
        /// </summary>

	public virtual CallsignBinding						CallsignBinding  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CallsignBinding" : {
				if (value is TokenValueStructObject vvalue) {
					CallsignBinding = vvalue.Value as CallsignBinding;
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
			case "CallsignBinding" : {
				return new TokenValueStruct<CallsignBinding> (CallsignBinding);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallsignBinding", new Property ( typeof(TokenValueStruct), false,
					()=>new CallsignBinding(), ()=>new CallsignBinding(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.HelloRequest._StaticAllProperties);


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
	public new const string __Tag = "MeshHelloRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshHelloRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshHelloRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MeshHelloRequest;
			}
		var Result = new MeshHelloRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MeshHelloResponse : Goedel.Protocol.HelloResponse {
        /// <summary>
        ///Specifies the default data constraints for updates.
        /// </summary>

	public virtual ConstraintsData						ConstraintsUpdate  {get; set;}
        /// <summary>
        ///Specifies the default data constraints for message senders.
        /// </summary>

	public virtual ConstraintsData						ConstraintsPost  {get; set;}
        /// <summary>
        ///Specifies the account creation policy
        /// </summary>

	public virtual PolicyAccount						PolicyAccount  {get; set;}
        /// <summary>
        ///The enveloped master profile of the service.
        /// </summary>

	public virtual Enveloped<ProfileService>						EnvelopedProfileService  {get; set;}
        /// <summary>
        ///If the request specifies a callsign binding, returns a proposed binding for
        ///the requested callsign.
        /// </summary>

	public virtual CallsignBinding						CallsignBinding  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ConstraintsUpdate" : {
				if (value is TokenValueStructObject vvalue) {
					ConstraintsUpdate = vvalue.Value as ConstraintsData;
					}
				break;
				}
			case "ConstraintsPost" : {
				if (value is TokenValueStructObject vvalue) {
					ConstraintsPost = vvalue.Value as ConstraintsData;
					}
				break;
				}
			case "PolicyAccount" : {
				if (value is TokenValueStructObject vvalue) {
					PolicyAccount = vvalue.Value as PolicyAccount;
					}
				break;
				}
			case "EnvelopedProfileService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileService = vvalue.Value as Enveloped<ProfileService>;
					}
				break;
				}
			case "CallsignBinding" : {
				if (value is TokenValueStructObject vvalue) {
					CallsignBinding = vvalue.Value as CallsignBinding;
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
			case "ConstraintsUpdate" : {
				return new TokenValueStruct<ConstraintsData> (ConstraintsUpdate);
				}
			case "ConstraintsPost" : {
				return new TokenValueStruct<ConstraintsData> (ConstraintsPost);
				}
			case "PolicyAccount" : {
				return new TokenValueStruct<PolicyAccount> (PolicyAccount);
				}
			case "EnvelopedProfileService" : {
				return new TokenValueStruct<Enveloped<ProfileService>> (EnvelopedProfileService);
				}
			case "CallsignBinding" : {
				return new TokenValueStruct<CallsignBinding> (CallsignBinding);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ConstraintsUpdate", new Property ( typeof(TokenValueStruct), false,
					()=>new ConstraintsData(), ()=>new ConstraintsData(), false)} ,
			{ "ConstraintsPost", new Property ( typeof(TokenValueStruct), false,
					()=>new ConstraintsData(), ()=>new ConstraintsData(), false)} ,
			{ "PolicyAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new PolicyAccount(), ()=>new PolicyAccount(), false)} ,
			{ "EnvelopedProfileService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>(), false)} ,
			{ "CallsignBinding", new Property ( typeof(TokenValueStruct), false,
					()=>new CallsignBinding(), ()=>new CallsignBinding(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.HelloResponse._StaticAllProperties);


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
	public new const string __Tag = "MeshHelloResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshHelloResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MeshHelloResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MeshHelloResponse;
			}
		var Result = new MeshHelloResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request binding of an account to a service address.
	/// </summary>
public partial class BindRequest : MeshRequest {
        /// <summary>
        ///The service account to bind to.
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///The signed assertion describing the account.
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///Contains one or more bindings of a callsign to the account.
        /// </summary>

	public virtual List<Enveloped<CallsignBinding>>				EnvelopedCallsignBinding  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileAccount = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedCallsignBinding" : {
				if (value is TokenValueListStructObject vvalue) {
					EnvelopedCallsignBinding = vvalue.Value as List<Enveloped<CallsignBinding>>;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "EnvelopedProfileAccount" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileAccount);
				}
			case "EnvelopedCallsignBinding" : {
				return new TokenValueListStruct<Enveloped<CallsignBinding>> (EnvelopedCallsignBinding);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedCallsignBinding", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<CallsignBinding>>(), ()=>new Enveloped<CallsignBinding>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "BindRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new BindRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new BindRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as BindRequest;
			}
		var Result = new BindRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Reports the success or failure of a Create transaction.
	/// </summary>
public partial class BindResponse : MeshResponse {
        /// <summary>
        ///Text explaining the status of the creation request.
        /// </summary>

	public virtual string						Reason  {get; set;}
        /// <summary>
        ///A URL to which the user is directed to complete the account creation 
        ///request.
        /// </summary>

	public virtual string						URL  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>						EnvelopedAccountHostAssignment  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Reason" : {
				if (value is TokenValueString vvalue) {
					Reason = vvalue.Value;
					}
				break;
				}
			case "URL" : {
				if (value is TokenValueString vvalue) {
					URL = vvalue.Value;
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
			case "Reason" : {
				return new TokenValueString (Reason);
				}
			case "URL" : {
				return new TokenValueString (URL);
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

			{ "Reason", new Property (typeof(TokenValueString), false)} ,
			{ "URL", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedAccountHostAssignment", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "BindResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new BindResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new BindResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as BindResponse;
			}
		var Result = new BindResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request creation of a new portal account. The request specifies
	/// the requested account identifier and the Mesh profile to be associated 
	/// with the account.
	/// </summary>
public partial class UnbindRequest : MeshRequestUser {


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
			Combine(_StaticProperties, MeshRequestUser._StaticAllProperties);


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
	public new const string __Tag = "UnbindRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UnbindRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new UnbindRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as UnbindRequest;
			}
		var Result = new UnbindRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Reports the success or failure of a Delete transaction.
	/// </summary>
public partial class UnbindResponse : MeshResponse {


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
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "UnbindResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UnbindResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new UnbindResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as UnbindResponse;
			}
		var Result = new UnbindResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ConnectRequest : MeshRequest {
        /// <summary>
        ///The connection request generated by the client 
        /// </summary>

	public virtual Enveloped<RequestConnection>						EnvelopedRequestConnection  {get; set;}
        /// <summary>
        ///List of named access rights.
        /// </summary>

	public virtual List<string>				Rights  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedRequestConnection" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedRequestConnection = vvalue.Value as Enveloped<RequestConnection>;
					}
				break;
				}
			case "Rights" : {
				if (value is TokenValueListString vvalue) {
					Rights = vvalue.Value;
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
			case "EnvelopedRequestConnection" : {
				return new TokenValueStruct<Enveloped<RequestConnection>> (EnvelopedRequestConnection);
				}
			case "Rights" : {
				return new TokenValueListString (Rights);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedRequestConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>(), false)} ,
			{ "Rights", new Property (typeof(TokenValueListString), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "ConnectRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectRequest;
			}
		var Result = new ConnectRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ConnectResponse : MeshResponse {
        /// <summary>
        ///The connection request generated by the client
        /// </summary>

	public virtual Enveloped<AcknowledgeConnection>						EnvelopedAcknowledgeConnection  {get; set;}
        /// <summary>
        ///The user profile that provides the root of trust for this Mesh
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedAcknowledgeConnection" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedAcknowledgeConnection = vvalue.Value as Enveloped<AcknowledgeConnection>;
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileAccount = vvalue.Value as Enveloped<ProfileAccount>;
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
			case "EnvelopedAcknowledgeConnection" : {
				return new TokenValueStruct<Enveloped<AcknowledgeConnection>> (EnvelopedAcknowledgeConnection);
				}
			case "EnvelopedProfileAccount" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileAccount);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedAcknowledgeConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>(), false)} ,
			{ "EnvelopedProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "ConnectResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectResponse;
			}
		var Result = new ConnectResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CompleteRequest : StatusRequest {
        /// <summary>
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						ResponseID  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "ResponseID" : {
				if (value is TokenValueString vvalue) {
					ResponseID = vvalue.Value;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "ResponseID" : {
				return new TokenValueString (ResponseID);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "ResponseID", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, StatusRequest._StaticAllProperties);


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
	public new const string __Tag = "CompleteRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CompleteRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CompleteRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CompleteRequest;
			}
		var Result = new CompleteRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CompleteResponse : MeshResponse {
        /// <summary>
        ///The signed assertion describing the result of the connect request
        /// </summary>

	public virtual Enveloped<RespondConnection>						EnvelopedRespondConnection  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>						EnvelopedAccountHostAssignment  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedRespondConnection" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedRespondConnection = vvalue.Value as Enveloped<RespondConnection>;
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
			case "EnvelopedRespondConnection" : {
				return new TokenValueStruct<Enveloped<RespondConnection>> (EnvelopedRespondConnection);
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

			{ "EnvelopedRespondConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<RespondConnection>(), ()=>new Enveloped<RespondConnection>(), false)} ,
			{ "EnvelopedAccountHostAssignment", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "CompleteResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CompleteResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CompleteResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CompleteResponse;
			}
		var Result = new CompleteResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class StatusRequest : MeshRequestUser {
        /// <summary>
        /// </summary>

	public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Catalogs  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Spools  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Services  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						DeviceStatus  {get; set;}


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
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
					}
				break;
				}
			case "Catalogs" : {
				if (value is TokenValueListString vvalue) {
					Catalogs = vvalue.Value;
					}
				break;
				}
			case "Spools" : {
				if (value is TokenValueListString vvalue) {
					Spools = vvalue.Value;
					}
				break;
				}
			case "Services" : {
				if (value is TokenValueListString vvalue) {
					Services = vvalue.Value;
					}
				break;
				}
			case "DeviceStatus" : {
				if (value is TokenValueBoolean vvalue) {
					DeviceStatus = vvalue.Value;
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
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
				}
			case "Catalogs" : {
				return new TokenValueListString (Catalogs);
				}
			case "Spools" : {
				return new TokenValueListString (Spools);
				}
			case "Services" : {
				return new TokenValueListString (Services);
				}
			case "DeviceStatus" : {
				return new TokenValueBoolean (DeviceStatus);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceUDF", new Property (typeof(TokenValueString), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} ,
			{ "Catalogs", new Property (typeof(TokenValueListString), true)} ,
			{ "Spools", new Property (typeof(TokenValueListString), true)} ,
			{ "Services", new Property (typeof(TokenValueListString), true)} ,
			{ "DeviceStatus", new Property (typeof(TokenValueBoolean), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequestUser._StaticAllProperties);


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
	public new const string __Tag = "StatusRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new StatusRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new StatusRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as StatusRequest;
			}
		var Result = new StatusRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class StatusResponse : MeshResponse {
        /// <summary>
        /// </summary>

	public virtual byte[]						Bitmask  {get; set;}
        /// <summary>
        ///The account profile providing the root of trust for this account.
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///The catalog device entry
        /// </summary>

	public virtual Enveloped<CatalogedDevice>						EnvelopedCatalogedDevice  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<StoreStatus>				StoreStatus  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>						EnvelopedAccountHostAssignment  {get; set;}
        /// <summary>
        ///A series of access tokens for the requested services.
        /// </summary>

	public virtual List<ServiceAccessToken>				Services  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DeviceStatus>				DeviceStatuses  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Bitmask" : {
				if (value is TokenValueBinary vvalue) {
					Bitmask = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileAccount = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedCatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCatalogedDevice = vvalue.Value as Enveloped<CatalogedDevice>;
					}
				break;
				}
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
					}
				break;
				}
			case "StoreStatus" : {
				if (value is TokenValueListStructObject vvalue) {
					StoreStatus = vvalue.Value as List<StoreStatus>;
					}
				break;
				}
			case "EnvelopedAccountHostAssignment" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedAccountHostAssignment = vvalue.Value as Enveloped<AccountHostAssignment>;
					}
				break;
				}
			case "Services" : {
				if (value is TokenValueListStructObject vvalue) {
					Services = vvalue.Value as List<ServiceAccessToken>;
					}
				break;
				}
			case "DeviceStatuses" : {
				if (value is TokenValueListStructObject vvalue) {
					DeviceStatuses = vvalue.Value as List<DeviceStatus>;
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
			case "Bitmask" : {
				return new TokenValueBinary (Bitmask);
				}
			case "EnvelopedProfileAccount" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileAccount);
				}
			case "EnvelopedCatalogedDevice" : {
				return new TokenValueStruct<Enveloped<CatalogedDevice>> (EnvelopedCatalogedDevice);
				}
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
				}
			case "StoreStatus" : {
				return new TokenValueListStruct<StoreStatus> (StoreStatus);
				}
			case "EnvelopedAccountHostAssignment" : {
				return new TokenValueStruct<Enveloped<AccountHostAssignment>> (EnvelopedAccountHostAssignment);
				}
			case "Services" : {
				return new TokenValueListStruct<ServiceAccessToken> (Services);
				}
			case "DeviceStatuses" : {
				return new TokenValueListStruct<DeviceStatus> (DeviceStatuses);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Bitmask", new Property (typeof(TokenValueBinary), false)} ,
			{ "EnvelopedProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedCatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>(), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} ,
			{ "StoreStatus", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<StoreStatus>(), ()=>new StoreStatus(), false)} ,
			{ "EnvelopedAccountHostAssignment", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>(), false)} ,
			{ "Services", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ServiceAccessToken>(), ()=>new ServiceAccessToken(), false)} ,
			{ "DeviceStatuses", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DeviceStatus>(), ()=>new DeviceStatus(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "StatusResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new StatusResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new StatusResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as StatusResponse;
			}
		var Result = new StatusResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DeviceStatus : MeshProtocol {
        /// <summary>
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Status  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Comment  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						LastConnected  {get; set;}


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
			case "Status" : {
				if (value is TokenValueString vvalue) {
					Status = vvalue.Value;
					}
				break;
				}
			case "Comment" : {
				if (value is TokenValueString vvalue) {
					Comment = vvalue.Value;
					}
				break;
				}
			case "LastConnected" : {
				if (value is TokenValueDateTime vvalue) {
					LastConnected = vvalue.Value;
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
			case "Status" : {
				return new TokenValueString (Status);
				}
			case "Comment" : {
				return new TokenValueString (Comment);
				}
			case "LastConnected" : {
				return new TokenValueDateTime (LastConnected);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Status", new Property (typeof(TokenValueString), false)} ,
			{ "Comment", new Property (typeof(TokenValueString), false)} ,
			{ "LastConnected", new Property (typeof(TokenValueDateTime), false)} 
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
	public new const string __Tag = "DeviceStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceStatus();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DeviceStatus FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DeviceStatus;
			}
		var Result = new DeviceStatus ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request objects from the specified container(s).
	/// A client MAY request only objects matching specified search criteria
	/// be returned and MAY request that only specific fields or parts of the 
	/// payload be returned.
	/// </summary>
public partial class DownloadRequest : MeshRequestUser {
        /// <summary>
        ///The maximum number of results to be returned.
        /// </summary>

	public virtual int?						MaxResults  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}
        /// <summary>
        ///Specifies constraints to be applied to a search result. These 
        ///allow a client to limit the number of records returned, the quantity
        ///of data returned, the earliest and latest data returned, etc.
        /// </summary>

	public virtual List<ConstraintsSelect>				Select  {get; set;}
        /// <summary>
        ///Specifies the data constraints to be applied to the responses.
        /// </summary>

	public virtual ConstraintsData						ConstraintsPost  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MaxResults" : {
				if (value is TokenValueInteger32 vvalue) {
					MaxResults = vvalue.Value;
					}
				break;
				}
			case "DeviceUDF" : {
				if (value is TokenValueString vvalue) {
					DeviceUDF = vvalue.Value;
					}
				break;
				}
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
					}
				break;
				}
			case "Select" : {
				if (value is TokenValueListStructObject vvalue) {
					Select = vvalue.Value as List<ConstraintsSelect>;
					}
				break;
				}
			case "ConstraintsPost" : {
				if (value is TokenValueStructObject vvalue) {
					ConstraintsPost = vvalue.Value as ConstraintsData;
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
			case "MaxResults" : {
				return new TokenValueInteger32 (MaxResults);
				}
			case "DeviceUDF" : {
				return new TokenValueString (DeviceUDF);
				}
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
				}
			case "Select" : {
				return new TokenValueListStruct<ConstraintsSelect> (Select);
				}
			case "ConstraintsPost" : {
				return new TokenValueStruct<ConstraintsData> (ConstraintsPost);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MaxResults", new Property (typeof(TokenValueInteger32), false)} ,
			{ "DeviceUDF", new Property (typeof(TokenValueString), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} ,
			{ "Select", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ConstraintsSelect>(), ()=>new ConstraintsSelect(), false)} ,
			{ "ConstraintsPost", new Property ( typeof(TokenValueStruct), false,
					()=>new ConstraintsData(), ()=>new ConstraintsData(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequestUser._StaticAllProperties);


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
	public new const string __Tag = "DownloadRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DownloadRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DownloadRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DownloadRequest;
			}
		var Result = new DownloadRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Return the set of objects requested.
	/// Services SHOULD NOT return a response that is disproportionately large
	/// relative to the speed of the network connection without a clear indication
	/// from the client that it is relevant. A service MAY limit the number of 
	/// objects returned. A service MAY limit the scope of each response. 
	/// </summary>
public partial class DownloadResponse : MeshResponse {
        /// <summary>
        ///The updated data
        /// </summary>

	public virtual List<StoreUpdate>				Updates  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}
        /// <summary>
        ///The catalog device entry. This is only returned if the 
        /// </summary>

	public virtual Enveloped<CatalogedDevice>						EnvelopedCatalogedDevice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Updates" : {
				if (value is TokenValueListStructObject vvalue) {
					Updates = vvalue.Value as List<StoreUpdate>;
					}
				break;
				}
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
					}
				break;
				}
			case "EnvelopedCatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCatalogedDevice = vvalue.Value as Enveloped<CatalogedDevice>;
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
			case "Updates" : {
				return new TokenValueListStruct<StoreUpdate> (Updates);
				}
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
				}
			case "EnvelopedCatalogedDevice" : {
				return new TokenValueStruct<Enveloped<CatalogedDevice>> (EnvelopedCatalogedDevice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updates", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<StoreUpdate>(), ()=>new StoreUpdate(), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedCatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "DownloadResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DownloadResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DownloadResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DownloadResponse;
			}
		var Result = new DownloadResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Upload entries to a container. This request is only valid if it is issued
	/// by the owner of the account
	/// </summary>
public partial class TransactRequest : MeshRequestUser {
        /// <summary>
        ///The data to be updated
        /// </summary>

	public virtual List<StoreUpdate>				Updates  {get; set;}
        /// <summary>
        ///The account(s) to which the request is directed.
        /// </summary>

	public virtual List<string>				Accounts  {get; set;}
        /// <summary>
        ///The messages to be sent to other accounts  
        /// </summary>

	public virtual List<Enveloped<Message>>				Outbound  {get; set;}
        /// <summary>
        ///Messages to be appended to the user's inbound spool. this is
        ///typically used to post notifications to the user to mark messages as having been
        ///read or responded to.
        /// </summary>

	public virtual List<Enveloped<Message>>				Inbound  {get; set;}
        /// <summary>
        ///Messages to be appended to the user's local spool. This is used to allow connecting
        ///devices to collect activation messages before they have connected to the mesh.
        /// </summary>

	public virtual List<Enveloped<Message>>				Local  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Updates" : {
				if (value is TokenValueListStructObject vvalue) {
					Updates = vvalue.Value as List<StoreUpdate>;
					}
				break;
				}
			case "Accounts" : {
				if (value is TokenValueListString vvalue) {
					Accounts = vvalue.Value;
					}
				break;
				}
			case "Outbound" : {
				if (value is TokenValueListStructObject vvalue) {
					Outbound = vvalue.Value as List<Enveloped<Message>>;
					}
				break;
				}
			case "Inbound" : {
				if (value is TokenValueListStructObject vvalue) {
					Inbound = vvalue.Value as List<Enveloped<Message>>;
					}
				break;
				}
			case "Local" : {
				if (value is TokenValueListStructObject vvalue) {
					Local = vvalue.Value as List<Enveloped<Message>>;
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
			case "Updates" : {
				return new TokenValueListStruct<StoreUpdate> (Updates);
				}
			case "Accounts" : {
				return new TokenValueListString (Accounts);
				}
			case "Outbound" : {
				return new TokenValueListStruct<Enveloped<Message>> (Outbound);
				}
			case "Inbound" : {
				return new TokenValueListStruct<Enveloped<Message>> (Inbound);
				}
			case "Local" : {
				return new TokenValueListStruct<Enveloped<Message>> (Local);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updates", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<StoreUpdate>(), ()=>new StoreUpdate(), false)} ,
			{ "Accounts", new Property (typeof(TokenValueListString), true)} ,
			{ "Outbound", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<Message>>(), ()=>new Enveloped<Message>(), false)} ,
			{ "Inbound", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<Message>>(), ()=>new Enveloped<Message>(), false)} ,
			{ "Local", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<Message>>(), ()=>new Enveloped<Message>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequestUser._StaticAllProperties);


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
	public new const string __Tag = "TransactRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TransactRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TransactRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TransactRequest;
			}
		var Result = new TransactRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Response to an upload request. 
	/// </summary>
public partial class TransactResponse : MeshResponse {
        /// <summary>
        /// </summary>

	public virtual byte[]						Bitmask  {get; set;}
        /// <summary>
        ///The responses to the entries.
        /// </summary>

	public virtual List<EntryResponse>				Entries  {get; set;}
        /// <summary>
        ///If the upload request contains redacted entries, specifies constraints 
        ///that apply to the redacted entries as a group. Thus the total payloads
        ///of all the messages must not exceed the specified value.
        /// </summary>

	public virtual ConstraintsData						ConstraintsData  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Bitmask" : {
				if (value is TokenValueBinary vvalue) {
					Bitmask = vvalue.Value;
					}
				break;
				}
			case "Entries" : {
				if (value is TokenValueListStructObject vvalue) {
					Entries = vvalue.Value as List<EntryResponse>;
					}
				break;
				}
			case "ConstraintsData" : {
				if (value is TokenValueStructObject vvalue) {
					ConstraintsData = vvalue.Value as ConstraintsData;
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
			case "Bitmask" : {
				return new TokenValueBinary (Bitmask);
				}
			case "Entries" : {
				return new TokenValueListStruct<EntryResponse> (Entries);
				}
			case "ConstraintsData" : {
				return new TokenValueStruct<ConstraintsData> (ConstraintsData);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Bitmask", new Property (typeof(TokenValueBinary), false)} ,
			{ "Entries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<EntryResponse>(), ()=>new EntryResponse(), false)} ,
			{ "ConstraintsData", new Property ( typeof(TokenValueStruct), false,
					()=>new ConstraintsData(), ()=>new ConstraintsData(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "TransactResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TransactResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TransactResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TransactResponse;
			}
		var Result = new TransactResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class EntryResponse : MeshProtocol {
        /// <summary>
        ///The index value of the entry in the request.
        /// </summary>

	public virtual long?						IndexRequest  {get; set;}
        /// <summary>
        ///The index value assigned to the entry in the container.
        /// </summary>

	public virtual long?						IndexContainer  {get; set;}
        /// <summary>
        ///Specifies the result of attempting to add the entry to a catalog
        ///or spool. Valid values for a message are 'Accept', 'Reject'. Valid 
        ///values for an entry are 'Accept', 'Reject' and 'Conflict'.
        /// </summary>

	public virtual string						Result  {get; set;}
        /// <summary>
        ///If the entry was redacted, specifies constraints 
        ///that apply to the redacted entries as a group. Thus the total payloads
        ///of all the messages must not exceed the specified value.	
        /// </summary>

	public virtual ConstraintsData						ConstraintsData  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "IndexRequest" : {
				if (value is TokenValueInteger64 vvalue) {
					IndexRequest = vvalue.Value;
					}
				break;
				}
			case "IndexContainer" : {
				if (value is TokenValueInteger64 vvalue) {
					IndexContainer = vvalue.Value;
					}
				break;
				}
			case "Result" : {
				if (value is TokenValueString vvalue) {
					Result = vvalue.Value;
					}
				break;
				}
			case "ConstraintsData" : {
				if (value is TokenValueStructObject vvalue) {
					ConstraintsData = vvalue.Value as ConstraintsData;
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
			case "IndexRequest" : {
				return new TokenValueInteger64 (IndexRequest);
				}
			case "IndexContainer" : {
				return new TokenValueInteger64 (IndexContainer);
				}
			case "Result" : {
				return new TokenValueString (Result);
				}
			case "ConstraintsData" : {
				return new TokenValueStruct<ConstraintsData> (ConstraintsData);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "IndexRequest", new Property (typeof(TokenValueInteger64), false)} ,
			{ "IndexContainer", new Property (typeof(TokenValueInteger64), false)} ,
			{ "Result", new Property (typeof(TokenValueString), false)} ,
			{ "ConstraintsData", new Property ( typeof(TokenValueStruct), false,
					()=>new ConstraintsData(), ()=>new ConstraintsData(), false)} 
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
	public new const string __Tag = "EntryResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EntryResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new EntryResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as EntryResponse;
			}
		var Result = new EntryResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Request download from a public store (which may be encrypted).
	/// </summary>
public partial class PublicRequest : DownloadRequest {


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
			Combine(_StaticProperties, DownloadRequest._StaticAllProperties);


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
	public new const string __Tag = "PublicRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PublicRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PublicRequest;
			}
		var Result = new PublicRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class PostRequest : MeshRequest {
        /// <summary>
        ///The account(s) to which the request is directed.
        /// </summary>

	public virtual List<string>				Accounts  {get; set;}
        /// <summary>
        ///The messages to be sent to the addresses specified in Accounts. 
        /// </summary>

	public virtual List<Enveloped<Message>>				Messages  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Accounts" : {
				if (value is TokenValueListString vvalue) {
					Accounts = vvalue.Value;
					}
				break;
				}
			case "Messages" : {
				if (value is TokenValueListStructObject vvalue) {
					Messages = vvalue.Value as List<Enveloped<Message>>;
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
			case "Accounts" : {
				return new TokenValueListString (Accounts);
				}
			case "Messages" : {
				return new TokenValueListStruct<Enveloped<Message>> (Messages);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Accounts", new Property (typeof(TokenValueListString), true)} ,
			{ "Messages", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<Message>>(), ()=>new Enveloped<Message>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "PostRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PostRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PostRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PostRequest;
			}
		var Result = new PostRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class PostResponse : TransactResponse {


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
			Combine(_StaticProperties, TransactResponse._StaticAllProperties);


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
	public new const string __Tag = "PostResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PostResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PostResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PostResponse;
			}
		var Result = new PostResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ClaimRequest : MeshRequest {
        /// <summary>
        ///The claim message
        /// </summary>

	public virtual Enveloped<MessageClaim>						EnvelopedMessageClaim  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedMessageClaim" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedMessageClaim = vvalue.Value as Enveloped<MessageClaim>;
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
			case "EnvelopedMessageClaim" : {
				return new TokenValueStruct<Enveloped<MessageClaim>> (EnvelopedMessageClaim);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedMessageClaim", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<MessageClaim>(), ()=>new Enveloped<MessageClaim>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "ClaimRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ClaimRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ClaimRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ClaimRequest;
			}
		var Result = new ClaimRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ClaimResponse : MeshResponse {
        /// <summary>
        ///The encrypted device profile
        /// </summary>

	public virtual CatalogedPublication						CatalogedPublication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CatalogedPublication" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedPublication = vvalue.Value as CatalogedPublication;
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
			case "CatalogedPublication" : {
				return new TokenValueStruct<CatalogedPublication> (CatalogedPublication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedPublication", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedPublication(), ()=>new CatalogedPublication(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "ClaimResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ClaimResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ClaimResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ClaimResponse;
			}
		var Result = new ClaimResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PollClaimRequest : MeshRequest {
        /// <summary>
        ///The envelope identifier formed from the PublicationId.
        /// </summary>

	public virtual string						PublicationId  {get; set;}
        /// <summary>
        ///Account to which the claim is directed
        /// </summary>

	public virtual string						TargetAccountAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PublicationId" : {
				if (value is TokenValueString vvalue) {
					PublicationId = vvalue.Value;
					}
				break;
				}
			case "TargetAccountAddress" : {
				if (value is TokenValueString vvalue) {
					TargetAccountAddress = vvalue.Value;
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
			case "PublicationId" : {
				return new TokenValueString (PublicationId);
				}
			case "TargetAccountAddress" : {
				return new TokenValueString (TargetAccountAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicationId", new Property (typeof(TokenValueString), false)} ,
			{ "TargetAccountAddress", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "PollClaimRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PollClaimRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PollClaimRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PollClaimRequest;
			}
		var Result = new PollClaimRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PollClaimResponse : MeshResponse {
        /// <summary>
        ///The claim message
        /// </summary>

	public virtual Enveloped<Message>						EnvelopedMessage  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedMessage" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedMessage = vvalue.Value as Enveloped<Message>;
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
			case "EnvelopedMessage" : {
				return new TokenValueStruct<Enveloped<Message>> (EnvelopedMessage);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedMessage", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Message>(), ()=>new Enveloped<Message>(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "PollClaimResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PollClaimResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PollClaimResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PollClaimResponse;
			}
		var Result = new PollClaimResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class CryptographicOperation : MeshProtocol {
        /// <summary>
        ///The key identifier			
        /// </summary>

	public virtual string						KeyId  {get; set;}
        /// <summary>
        ///Lagrange coefficient multiplier to be applied to the private key
        /// </summary>

	public virtual byte[]						KeyCoefficient  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "KeyId" : {
				if (value is TokenValueString vvalue) {
					KeyId = vvalue.Value;
					}
				break;
				}
			case "KeyCoefficient" : {
				if (value is TokenValueBinary vvalue) {
					KeyCoefficient = vvalue.Value;
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
			case "KeyId" : {
				return new TokenValueString (KeyId);
				}
			case "KeyCoefficient" : {
				return new TokenValueBinary (KeyCoefficient);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyId", new Property (typeof(TokenValueString), false)} ,
			{ "KeyCoefficient", new Property (typeof(TokenValueBinary), false)} 
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
	public new const string __Tag = "CryptographicOperation";

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
    public static new CryptographicOperation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicOperation;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicOperationSign : CryptographicOperation {
        /// <summary>
        ///The data to sign
        /// </summary>

	public virtual byte[]						Data  {get; set;}
        /// <summary>
        ///Contribution to the R offset.
        /// </summary>

	public virtual byte[]						PartialR  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Data" : {
				if (value is TokenValueBinary vvalue) {
					Data = vvalue.Value;
					}
				break;
				}
			case "PartialR" : {
				if (value is TokenValueBinary vvalue) {
					PartialR = vvalue.Value;
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
			case "Data" : {
				return new TokenValueBinary (Data);
				}
			case "PartialR" : {
				return new TokenValueBinary (PartialR);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Data", new Property (typeof(TokenValueBinary), false)} ,
			{ "PartialR", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicOperation._StaticAllProperties);


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
	public new const string __Tag = "CryptographicOperationSign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicOperationSign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicOperationSign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicOperationSign;
			}
		var Result = new CryptographicOperationSign ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicOperationKeyAgreement : CryptographicOperation {
        /// <summary>
        ///The public key value to perform the agreement on.
        /// </summary>

	public virtual Key						PublicKey  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PublicKey" : {
				if (value is TokenValueStructObject vvalue) {
					PublicKey = vvalue.Value as Key;
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
			case "PublicKey" : {
				return new TokenValueStruct<Key> (PublicKey);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicKey", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicOperation._StaticAllProperties);


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
	public new const string __Tag = "CryptographicOperationKeyAgreement";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicOperationKeyAgreement();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicOperationKeyAgreement FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicOperationKeyAgreement;
			}
		var Result = new CryptographicOperationKeyAgreement ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicOperationGenerate : CryptographicOperation {


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
			Combine(_StaticProperties, CryptographicOperation._StaticAllProperties);


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
	public new const string __Tag = "CryptographicOperationGenerate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicOperationGenerate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicOperationGenerate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicOperationGenerate;
			}
		var Result = new CryptographicOperationGenerate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicOperationShare : CryptographicOperation {
        /// <summary>
        /// </summary>

	public virtual int?						Threshold  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Shares  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Threshold" : {
				if (value is TokenValueInteger32 vvalue) {
					Threshold = vvalue.Value;
					}
				break;
				}
			case "Shares" : {
				if (value is TokenValueInteger32 vvalue) {
					Shares = vvalue.Value;
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
			case "Threshold" : {
				return new TokenValueInteger32 (Threshold);
				}
			case "Shares" : {
				return new TokenValueInteger32 (Shares);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Threshold", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Shares", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicOperation._StaticAllProperties);


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
	public new const string __Tag = "CryptographicOperationShare";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicOperationShare();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicOperationShare FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicOperationShare;
			}
		var Result = new CryptographicOperationShare ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicResult : MeshProtocol {
        /// <summary>
        /// </summary>

	public virtual string						Error  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Error" : {
				if (value is TokenValueString vvalue) {
					Error = vvalue.Value;
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
			case "Error" : {
				return new TokenValueString (Error);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Error", new Property (typeof(TokenValueString), false)} 
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
	public new const string __Tag = "CryptographicResult";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicResult();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicResult FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicResult;
			}
		var Result = new CryptographicResult ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicResultKeyAgreement : CryptographicResult {
        /// <summary>
        /// </summary>

	public virtual KeyAgreement						KeyAgreement  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "KeyAgreement" : {
				if (value is TokenValueStructObject vvalue) {
					KeyAgreement = vvalue.Value as KeyAgreement;
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
			case "KeyAgreement" : {
				return new TokenValueStruct<KeyAgreement> (KeyAgreement);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyAgreement", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicResult._StaticAllProperties);


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
	public new const string __Tag = "CryptographicResultKeyAgreement";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicResultKeyAgreement();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicResultKeyAgreement FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicResultKeyAgreement;
			}
		var Result = new CryptographicResultKeyAgreement ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CryptographicResultShare : CryptographicResult {


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
			Combine(_StaticProperties, CryptographicResult._StaticAllProperties);


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
	public new const string __Tag = "CryptographicResultShare";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptographicResultShare();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicResultShare FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicResultShare;
			}
		var Result = new CryptographicResultShare ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class OperateRequest : MeshRequest {
        /// <summary>
        ///The service account the capability is bound to
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<CryptographicOperation>				Operations  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "Operations" : {
				if (value is TokenValueListStructObject vvalue) {
					Operations = vvalue.Value as List<CryptographicOperation>;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "Operations" : {
				return new TokenValueListStruct<CryptographicOperation> (Operations);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "Operations", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CryptographicOperation>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshRequest._StaticAllProperties);


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
	public new const string __Tag = "OperateRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OperateRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new OperateRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as OperateRequest;
			}
		var Result = new OperateRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class OperateResponse : MeshResponse {
        /// <summary>
        /// </summary>

	public virtual List<CryptographicResult>				Results  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Results" : {
				if (value is TokenValueListStructObject vvalue) {
					Results = vvalue.Value as List<CryptographicResult>;
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
			case "Results" : {
				return new TokenValueListStruct<CryptographicResult> (Results);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Results", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CryptographicResult>(), null, true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MeshResponse._StaticAllProperties);


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
	public new const string __Tag = "OperateResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OperateResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new OperateResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as OperateResponse;
			}
		var Result = new OperateResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



