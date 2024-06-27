
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
//  This file was automatically generated at 6/27/2024 1:56:26 PM
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
	/// Implement the transaction Hello.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public MeshHelloResponse Hello (HelloRequest request) =>
			HelloAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Hello asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<MeshHelloResponse> HelloAsync (HelloRequest request) =>
			await JpcSession.PostAsync("Hello", request) as MeshHelloResponse;

    /// <summary>
	/// Implement the transaction BindAccount.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public BindResponse BindAccount (BindRequest request) =>
			BindAccountAsync (request).Sync();

    /// <summary>
	/// Implement the transaction BindAccount asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<BindResponse> BindAccountAsync (BindRequest request) =>
			await JpcSession.PostAsync("BindAccount", request) as BindResponse;

    /// <summary>
	/// Implement the transaction UnbindAccount.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public UnbindResponse UnbindAccount (UnbindRequest request) =>
			UnbindAccountAsync (request).Sync();

    /// <summary>
	/// Implement the transaction UnbindAccount asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<UnbindResponse> UnbindAccountAsync (UnbindRequest request) =>
			await JpcSession.PostAsync("UnbindAccount", request) as UnbindResponse;

    /// <summary>
	/// Implement the transaction Connect.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public ConnectResponse Connect (ConnectRequest request) =>
			ConnectAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Connect asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<ConnectResponse> ConnectAsync (ConnectRequest request) =>
			await JpcSession.PostAsync("Connect", request) as ConnectResponse;

    /// <summary>
	/// Implement the transaction Complete.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public CompleteResponse Complete (CompleteRequest request) =>
			CompleteAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Complete asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<CompleteResponse> CompleteAsync (CompleteRequest request) =>
			await JpcSession.PostAsync("Complete", request) as CompleteResponse;

    /// <summary>
	/// Implement the transaction Status.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public StatusResponse Status (StatusRequest request) =>
			StatusAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Status asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<StatusResponse> StatusAsync (StatusRequest request) =>
			await JpcSession.PostAsync("Status", request) as StatusResponse;

    /// <summary>
	/// Implement the transaction Download.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public DownloadResponse Download (DownloadRequest request) =>
			DownloadAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Download asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<DownloadResponse> DownloadAsync (DownloadRequest request) =>
			await JpcSession.PostAsync("Download", request) as DownloadResponse;

    /// <summary>
	/// Implement the transaction Transact.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public TransactResponse Transact (TransactRequest request) =>
			TransactAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Transact asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<TransactResponse> TransactAsync (TransactRequest request) =>
			await JpcSession.PostAsync("Transact", request) as TransactResponse;

    /// <summary>
	/// Implement the transaction PublicRead.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public DownloadResponse PublicRead (PublicRequest request) =>
			PublicReadAsync (request).Sync();

    /// <summary>
	/// Implement the transaction PublicRead asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<DownloadResponse> PublicReadAsync (PublicRequest request) =>
			await JpcSession.PostAsync("PublicRead", request) as DownloadResponse;

    /// <summary>
	/// Implement the transaction Post.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public PostResponse Post (PostRequest request) =>
			PostAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Post asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<PostResponse> PostAsync (PostRequest request) =>
			await JpcSession.PostAsync("Post", request) as PostResponse;

    /// <summary>
	/// Implement the transaction Claim.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public ClaimResponse Claim (ClaimRequest request) =>
			ClaimAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Claim asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<ClaimResponse> ClaimAsync (ClaimRequest request) =>
			await JpcSession.PostAsync("Claim", request) as ClaimResponse;

    /// <summary>
	/// Implement the transaction PollClaim.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public PollClaimResponse PollClaim (PollClaimRequest request) =>
			PollClaimAsync (request).Sync();

    /// <summary>
	/// Implement the transaction PollClaim asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<PollClaimResponse> PollClaimAsync (PollClaimRequest request) =>
			await JpcSession.PostAsync("PollClaim", request) as PollClaimResponse;

    /// <summary>
	/// Implement the transaction Operate.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public OperateResponse Operate (OperateRequest request) =>
			OperateAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Operate asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<OperateResponse> OperateAsync (OperateRequest request) =>
			await JpcSession.PostAsync("Operate", request) as OperateResponse;


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
    public override Task<MeshHelloResponse> HelloAsync (HelloRequest request) =>
			Task.FromResult(Service.Hello (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<BindResponse> BindAccountAsync (BindRequest request) =>
			Task.FromResult(Service.BindAccount (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<UnbindResponse> UnbindAccountAsync (UnbindRequest request) =>
			Task.FromResult(Service.UnbindAccount (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<ConnectResponse> ConnectAsync (ConnectRequest request) =>
			Task.FromResult(Service.Connect (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<CompleteResponse> CompleteAsync (CompleteRequest request) =>
			Task.FromResult(Service.Complete (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<StatusResponse> StatusAsync (StatusRequest request) =>
			Task.FromResult(Service.Status (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<DownloadResponse> DownloadAsync (DownloadRequest request) =>
			Task.FromResult(Service.Download (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<TransactResponse> TransactAsync (TransactRequest request) =>
			Task.FromResult(Service.Transact (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<DownloadResponse> PublicReadAsync (PublicRequest request) =>
			Task.FromResult(Service.PublicRead (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<PostResponse> PostAsync (PostRequest request) =>
			Task.FromResult(Service.Post (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<ClaimResponse> ClaimAsync (ClaimRequest request) =>
			Task.FromResult(Service.Claim (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<PollClaimResponse> PollClaimAsync (PollClaimRequest request) =>
			Task.FromResult(Service.PollClaim (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<OperateResponse> OperateAsync (OperateRequest request) =>
			Task.FromResult(Service.Operate (request, JpcSession));


		}




	// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
public partial class MeshRequest : Goedel.Protocol.Request {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MeshRequest(), Goedel.Protocol.Request._binding);

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

	public virtual string?						Account  {get; set;}

        /// <summary>
        ///The identifier of the capability under which access is claimed.
        /// </summary>

	public virtual string?						Capability  {get; set;}

        /// <summary>
        ///Device profile of the device making the request.
        /// </summary>

	public virtual Enveloped<ProfileDevice>?						EnvelopedProfileDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MeshRequestUser(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new PropertyString ("Account", 
					(IBinding data, string? value) => {(data as MeshRequestUser).Account = value;}, (IBinding data) => (data as MeshRequestUser).Account )},
			{ "Capability", new PropertyString ("Capability", 
					(IBinding data, string? value) => {(data as MeshRequestUser).Capability = value;}, (IBinding data) => (data as MeshRequestUser).Capability )},
			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", 
					(IBinding data, object? value) => {(data as MeshRequestUser).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as MeshRequestUser).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MeshResponse(), Goedel.Protocol.Response._binding);

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

	public virtual string?						Key  {get; set;}

        /// <summary>
        ///The data value to match.
        /// </summary>

	public virtual string?						Value  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyValue(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as KeyValue).Key = value;}, (IBinding data) => (data as KeyValue).Key )},
			{ "Value", new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as KeyValue).Value = value;}, (IBinding data) => (data as KeyValue).Value )}
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

	public virtual string?						Store  {get; set;}

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

	public virtual string?						PageKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConstraintsSelect(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Store", new PropertyString ("Store", 
					(IBinding data, string? value) => {(data as ConstraintsSelect).Store = value;}, (IBinding data) => (data as ConstraintsSelect).Store )},
			{ "IndexMin", new PropertyInteger64 ("IndexMin", 
					(IBinding data, long? value) => {(data as ConstraintsSelect).IndexMin = value;}, (IBinding data) => (data as ConstraintsSelect).IndexMin )},
			{ "IndexMax", new PropertyInteger64 ("IndexMax", 
					(IBinding data, long? value) => {(data as ConstraintsSelect).IndexMax = value;}, (IBinding data) => (data as ConstraintsSelect).IndexMax )},
			{ "NotBefore", new PropertyDateTime ("NotBefore", 
					(IBinding data, DateTime? value) => {(data as ConstraintsSelect).NotBefore = value;}, (IBinding data) => (data as ConstraintsSelect).NotBefore )},
			{ "Before", new PropertyDateTime ("Before", 
					(IBinding data, DateTime? value) => {(data as ConstraintsSelect).Before = value;}, (IBinding data) => (data as ConstraintsSelect).Before )},
			{ "PageKey", new PropertyString ("PageKey", 
					(IBinding data, string? value) => {(data as ConstraintsSelect).PageKey = value;}, (IBinding data) => (data as ConstraintsSelect).PageKey )}
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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConstraintsData(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MaxEntries", new PropertyInteger64 ("MaxEntries", 
					(IBinding data, long? value) => {(data as ConstraintsData).MaxEntries = value;}, (IBinding data) => (data as ConstraintsData).MaxEntries )},
			{ "BytesOffset", new PropertyInteger64 ("BytesOffset", 
					(IBinding data, long? value) => {(data as ConstraintsData).BytesOffset = value;}, (IBinding data) => (data as ConstraintsData).BytesOffset )},
			{ "BytesMax", new PropertyInteger64 ("BytesMax", 
					(IBinding data, long? value) => {(data as ConstraintsData).BytesMax = value;}, (IBinding data) => (data as ConstraintsData).BytesMax )},
			{ "Header", new PropertyBoolean ("Header", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Header = value;}, (IBinding data) => (data as ConstraintsData).Header )},
			{ "Payload", new PropertyBoolean ("Payload", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Payload = value;}, (IBinding data) => (data as ConstraintsData).Payload )},
			{ "Trailer", new PropertyBoolean ("Trailer", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Trailer = value;}, (IBinding data) => (data as ConstraintsData).Trailer )}
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

	public virtual string?						InvalidCharacters  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PolicyAccount(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Minimum", new PropertyInteger32 ("Minimum", 
					(IBinding data, int? value) => {(data as PolicyAccount).Minimum = value;}, (IBinding data) => (data as PolicyAccount).Minimum )},
			{ "Maximum", new PropertyInteger32 ("Maximum", 
					(IBinding data, int? value) => {(data as PolicyAccount).Maximum = value;}, (IBinding data) => (data as PolicyAccount).Maximum )},
			{ "InvalidCharacters", new PropertyString ("InvalidCharacters", 
					(IBinding data, string? value) => {(data as PolicyAccount).InvalidCharacters = value;}, (IBinding data) => (data as PolicyAccount).InvalidCharacters )}
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

	public virtual string?						Store  {get; set;}

        /// <summary>
        /// </summary>

	public virtual long?						Index  {get; set;}

        /// <summary>
        ///In a status response, the apex digest value of the store 
        ///whose status is reported.
        /// </summary>

	public virtual byte[]?						Digest  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new StoreStatus(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Store", new PropertyString ("Store", 
					(IBinding data, string? value) => {(data as StoreStatus).Store = value;}, (IBinding data) => (data as StoreStatus).Store )},
			{ "Index", new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as StoreStatus).Index = value;}, (IBinding data) => (data as StoreStatus).Index )},
			{ "Digest", new PropertyBinary ("Digest", 
					(IBinding data, byte[]? value) => {(data as StoreStatus).Digest = value;}, (IBinding data) => (data as StoreStatus).Digest )}
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

	public virtual List<DareEnvelope>?					Envelopes  {get; set;}
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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new StoreUpdate(), StoreStatus._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Envelopes", new PropertyListStruct ("Envelopes", 
					(IBinding data, object? value) => {(data as StoreUpdate).Envelopes = value as List<DareEnvelope>;}, (IBinding data) => (data as StoreUpdate).Envelopes,
					false, ()=>new  List<DareEnvelope>(), ()=>new DareEnvelope())} ,
			{ "Partial", new PropertyBoolean ("Partial", 
					(IBinding data, bool? value) => {(data as StoreUpdate).Partial = value;}, (IBinding data) => (data as StoreUpdate).Partial )},
			{ "FinalIndex", new PropertyInteger64 ("FinalIndex", 
					(IBinding data, long? value) => {(data as StoreUpdate).FinalIndex = value;}, (IBinding data) => (data as StoreUpdate).FinalIndex )}
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

	public virtual CallsignBinding?						CallsignBinding  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MeshHelloRequest(), Goedel.Protocol.HelloRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CallsignBinding", new PropertyStruct ("CallsignBinding", 
					(IBinding data, object? value) => {(data as MeshHelloRequest).CallsignBinding = value as CallsignBinding;}, (IBinding data) => (data as MeshHelloRequest).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())} 
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

	public virtual ConstraintsData?						ConstraintsUpdate  {get; set;}

        /// <summary>
        ///Specifies the default data constraints for message senders.
        /// </summary>

	public virtual ConstraintsData?						ConstraintsPost  {get; set;}

        /// <summary>
        ///Specifies the account creation policy
        /// </summary>

	public virtual PolicyAccount?						PolicyAccount  {get; set;}

        /// <summary>
        ///The enveloped master profile of the service.
        /// </summary>

	public virtual Enveloped<ProfileService>?						EnvelopedProfileService  {get; set;}

        /// <summary>
        ///If the request specifies a callsign binding, returns a proposed binding for
        ///the requested callsign.
        /// </summary>

	public virtual CallsignBinding?						CallsignBinding  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MeshHelloResponse(), Goedel.Protocol.HelloResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ConstraintsUpdate", new PropertyStruct ("ConstraintsUpdate", 
					(IBinding data, object? value) => {(data as MeshHelloResponse).ConstraintsUpdate = value as ConstraintsData;}, (IBinding data) => (data as MeshHelloResponse).ConstraintsUpdate,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())} ,
			{ "ConstraintsPost", new PropertyStruct ("ConstraintsPost", 
					(IBinding data, object? value) => {(data as MeshHelloResponse).ConstraintsPost = value as ConstraintsData;}, (IBinding data) => (data as MeshHelloResponse).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())} ,
			{ "PolicyAccount", new PropertyStruct ("PolicyAccount", 
					(IBinding data, object? value) => {(data as MeshHelloResponse).PolicyAccount = value as PolicyAccount;}, (IBinding data) => (data as MeshHelloResponse).PolicyAccount,
					false, ()=>new  PolicyAccount(), ()=>new PolicyAccount())} ,
			{ "EnvelopedProfileService", new PropertyStruct ("EnvelopedProfileService", 
					(IBinding data, object? value) => {(data as MeshHelloResponse).EnvelopedProfileService = value as Enveloped<ProfileService>;}, (IBinding data) => (data as MeshHelloResponse).EnvelopedProfileService,
					false, ()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>())} ,
			{ "CallsignBinding", new PropertyStruct ("CallsignBinding", 
					(IBinding data, object? value) => {(data as MeshHelloResponse).CallsignBinding = value as CallsignBinding;}, (IBinding data) => (data as MeshHelloResponse).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())} 
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

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        ///The signed assertion describing the account.
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileAccount  {get; set;}

        /// <summary>
        ///Contains one or more bindings of a callsign to the account.
        /// </summary>

	public virtual List<Enveloped<CallsignBinding>>?					EnvelopedCallsignBinding  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new BindRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as BindRequest).AccountAddress = value;}, (IBinding data) => (data as BindRequest).AccountAddress )},
			{ "EnvelopedProfileAccount", new PropertyStruct ("EnvelopedProfileAccount", 
					(IBinding data, object? value) => {(data as BindRequest).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as BindRequest).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "EnvelopedCallsignBinding", new PropertyListStruct ("EnvelopedCallsignBinding", 
					(IBinding data, object? value) => {(data as BindRequest).EnvelopedCallsignBinding = value as List<Enveloped<CallsignBinding>>;}, (IBinding data) => (data as BindRequest).EnvelopedCallsignBinding,
					false, ()=>new  List<Enveloped<CallsignBinding>>(), ()=>new Enveloped<CallsignBinding>())} 
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

	public virtual string?						Reason  {get; set;}

        /// <summary>
        ///A URL to which the user is directed to complete the account creation 
        ///request.
        /// </summary>

	public virtual string?						URL  {get; set;}

        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>?						EnvelopedAccountHostAssignment  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new BindResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Reason", new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as BindResponse).Reason = value;}, (IBinding data) => (data as BindResponse).Reason )},
			{ "URL", new PropertyString ("URL", 
					(IBinding data, string? value) => {(data as BindResponse).URL = value;}, (IBinding data) => (data as BindResponse).URL )},
			{ "EnvelopedAccountHostAssignment", new PropertyStruct ("EnvelopedAccountHostAssignment", 
					(IBinding data, object? value) => {(data as BindResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, (IBinding data) => (data as BindResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new UnbindRequest(), MeshRequestUser._binding);

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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new UnbindResponse(), MeshResponse._binding);

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

	public virtual Enveloped<RequestConnection>?						EnvelopedRequestConnection  {get; set;}

        /// <summary>
        ///List of named access rights.
        /// </summary>

	public virtual List<string>?					Rights  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedRequestConnection", new PropertyStruct ("EnvelopedRequestConnection", 
					(IBinding data, object? value) => {(data as ConnectRequest).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;}, (IBinding data) => (data as ConnectRequest).EnvelopedRequestConnection,
					false, ()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>())} ,
			{ "Rights", new PropertyListString ("Rights", 
					(IBinding data, List<string>? value) => {(data as ConnectRequest).Rights = value;}, (IBinding data) => (data as ConnectRequest).Rights )}
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

	public virtual Enveloped<AcknowledgeConnection>?						EnvelopedAcknowledgeConnection  {get; set;}

        /// <summary>
        ///The user profile that provides the root of trust for this Mesh
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileAccount  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedAcknowledgeConnection", new PropertyStruct ("EnvelopedAcknowledgeConnection", 
					(IBinding data, object? value) => {(data as ConnectResponse).EnvelopedAcknowledgeConnection = value as Enveloped<AcknowledgeConnection>;}, (IBinding data) => (data as ConnectResponse).EnvelopedAcknowledgeConnection,
					false, ()=>new  Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>())} ,
			{ "EnvelopedProfileAccount", new PropertyStruct ("EnvelopedProfileAccount", 
					(IBinding data, object? value) => {(data as ConnectResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as ConnectResponse).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} 
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

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ResponseID  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CompleteRequest(), StatusRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CompleteRequest).AccountAddress = value;}, (IBinding data) => (data as CompleteRequest).AccountAddress )},
			{ "ResponseID", new PropertyString ("ResponseID", 
					(IBinding data, string? value) => {(data as CompleteRequest).ResponseID = value;}, (IBinding data) => (data as CompleteRequest).ResponseID )}
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

	public virtual Enveloped<RespondConnection>?						EnvelopedRespondConnection  {get; set;}

        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>?						EnvelopedAccountHostAssignment  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CompleteResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedRespondConnection", new PropertyStruct ("EnvelopedRespondConnection", 
					(IBinding data, object? value) => {(data as CompleteResponse).EnvelopedRespondConnection = value as Enveloped<RespondConnection>;}, (IBinding data) => (data as CompleteResponse).EnvelopedRespondConnection,
					false, ()=>new  Enveloped<RespondConnection>(), ()=>new Enveloped<RespondConnection>())} ,
			{ "EnvelopedAccountHostAssignment", new PropertyStruct ("EnvelopedAccountHostAssignment", 
					(IBinding data, object? value) => {(data as CompleteResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, (IBinding data) => (data as CompleteResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())} 
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

	public virtual string?						DeviceUDF  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					Catalogs  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					Spools  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					Services  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						DeviceStatus  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new StatusRequest(), MeshRequestUser._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceUDF", new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as StatusRequest).DeviceUDF = value;}, (IBinding data) => (data as StatusRequest).DeviceUDF )},
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as StatusRequest).CatalogedDeviceDigest = value;}, (IBinding data) => (data as StatusRequest).CatalogedDeviceDigest )},
			{ "Catalogs", new PropertyListString ("Catalogs", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Catalogs = value;}, (IBinding data) => (data as StatusRequest).Catalogs )},
			{ "Spools", new PropertyListString ("Spools", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Spools = value;}, (IBinding data) => (data as StatusRequest).Spools )},
			{ "Services", new PropertyListString ("Services", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Services = value;}, (IBinding data) => (data as StatusRequest).Services )},
			{ "DeviceStatus", new PropertyBoolean ("DeviceStatus", 
					(IBinding data, bool? value) => {(data as StatusRequest).DeviceStatus = value;}, (IBinding data) => (data as StatusRequest).DeviceStatus )}
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

	public virtual byte[]?						Bitmask  {get; set;}

        /// <summary>
        ///The account profile providing the root of trust for this account.
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileAccount  {get; set;}

        /// <summary>
        ///The catalog device entry
        /// </summary>

	public virtual Enveloped<CatalogedDevice>?						EnvelopedCatalogedDevice  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<StoreStatus>?					StoreStatus  {get; set;}
        /// <summary>
        ///The enveloped assignment describing how the client should
        ///discover the host and encrypt data to it.
        /// </summary>

	public virtual Enveloped<AccountHostAssignment>?						EnvelopedAccountHostAssignment  {get; set;}

        /// <summary>
        ///A series of access tokens for the requested services.
        /// </summary>

	public virtual List<ServiceAccessToken>?					Services  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DeviceStatus>?					DeviceStatuses  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new StatusResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Bitmask", new PropertyBinary ("Bitmask", 
					(IBinding data, byte[]? value) => {(data as StatusResponse).Bitmask = value;}, (IBinding data) => (data as StatusResponse).Bitmask )},
			{ "EnvelopedProfileAccount", new PropertyStruct ("EnvelopedProfileAccount", 
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as StatusResponse).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "EnvelopedCatalogedDevice", new PropertyStruct ("EnvelopedCatalogedDevice", 
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, (IBinding data) => (data as StatusResponse).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())} ,
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as StatusResponse).CatalogedDeviceDigest = value;}, (IBinding data) => (data as StatusResponse).CatalogedDeviceDigest )},
			{ "StoreStatus", new PropertyListStruct ("StoreStatus", 
					(IBinding data, object? value) => {(data as StatusResponse).StoreStatus = value as List<StoreStatus>;}, (IBinding data) => (data as StatusResponse).StoreStatus,
					false, ()=>new  List<StoreStatus>(), ()=>new StoreStatus())} ,
			{ "EnvelopedAccountHostAssignment", new PropertyStruct ("EnvelopedAccountHostAssignment", 
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, (IBinding data) => (data as StatusResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())} ,
			{ "Services", new PropertyListStruct ("Services", 
					(IBinding data, object? value) => {(data as StatusResponse).Services = value as List<ServiceAccessToken>;}, (IBinding data) => (data as StatusResponse).Services,
					false, ()=>new  List<ServiceAccessToken>(), ()=>new ServiceAccessToken())} ,
			{ "DeviceStatuses", new PropertyListStruct ("DeviceStatuses", 
					(IBinding data, object? value) => {(data as StatusResponse).DeviceStatuses = value as List<DeviceStatus>;}, (IBinding data) => (data as StatusResponse).DeviceStatuses,
					false, ()=>new  List<DeviceStatus>(), ()=>new DeviceStatus())} 
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

	public virtual string?						Id  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Status  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Comment  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						LastConnected  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DeviceStatus(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as DeviceStatus).Id = value;}, (IBinding data) => (data as DeviceStatus).Id )},
			{ "Status", new PropertyString ("Status", 
					(IBinding data, string? value) => {(data as DeviceStatus).Status = value;}, (IBinding data) => (data as DeviceStatus).Status )},
			{ "Comment", new PropertyString ("Comment", 
					(IBinding data, string? value) => {(data as DeviceStatus).Comment = value;}, (IBinding data) => (data as DeviceStatus).Comment )},
			{ "LastConnected", new PropertyDateTime ("LastConnected", 
					(IBinding data, DateTime? value) => {(data as DeviceStatus).LastConnected = value;}, (IBinding data) => (data as DeviceStatus).LastConnected )}
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

	public virtual string?						DeviceUDF  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}

        /// <summary>
        ///Specifies constraints to be applied to a search result. These 
        ///allow a client to limit the number of records returned, the quantity
        ///of data returned, the earliest and latest data returned, etc.
        /// </summary>

	public virtual List<ConstraintsSelect>?					Select  {get; set;}
        /// <summary>
        ///Specifies the data constraints to be applied to the responses.
        /// </summary>

	public virtual ConstraintsData?						ConstraintsPost  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DownloadRequest(), MeshRequestUser._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MaxResults", new PropertyInteger32 ("MaxResults", 
					(IBinding data, int? value) => {(data as DownloadRequest).MaxResults = value;}, (IBinding data) => (data as DownloadRequest).MaxResults )},
			{ "DeviceUDF", new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as DownloadRequest).DeviceUDF = value;}, (IBinding data) => (data as DownloadRequest).DeviceUDF )},
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as DownloadRequest).CatalogedDeviceDigest = value;}, (IBinding data) => (data as DownloadRequest).CatalogedDeviceDigest )},
			{ "Select", new PropertyListStruct ("Select", 
					(IBinding data, object? value) => {(data as DownloadRequest).Select = value as List<ConstraintsSelect>;}, (IBinding data) => (data as DownloadRequest).Select,
					false, ()=>new  List<ConstraintsSelect>(), ()=>new ConstraintsSelect())} ,
			{ "ConstraintsPost", new PropertyStruct ("ConstraintsPost", 
					(IBinding data, object? value) => {(data as DownloadRequest).ConstraintsPost = value as ConstraintsData;}, (IBinding data) => (data as DownloadRequest).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())} 
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

	public virtual List<StoreUpdate>?					Updates  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}

        /// <summary>
        ///The catalog device entry. This is only returned if the 
        /// </summary>

	public virtual Enveloped<CatalogedDevice>?						EnvelopedCatalogedDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DownloadResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updates", new PropertyListStruct ("Updates", 
					(IBinding data, object? value) => {(data as DownloadResponse).Updates = value as List<StoreUpdate>;}, (IBinding data) => (data as DownloadResponse).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate())} ,
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as DownloadResponse).CatalogedDeviceDigest = value;}, (IBinding data) => (data as DownloadResponse).CatalogedDeviceDigest )},
			{ "EnvelopedCatalogedDevice", new PropertyStruct ("EnvelopedCatalogedDevice", 
					(IBinding data, object? value) => {(data as DownloadResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, (IBinding data) => (data as DownloadResponse).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())} 
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

	public virtual List<StoreUpdate>?					Updates  {get; set;}
        /// <summary>
        ///The account(s) to which the request is directed.
        /// </summary>

	public virtual List<string>?					Accounts  {get; set;}
        /// <summary>
        ///The messages to be sent to other accounts  
        /// </summary>

	public virtual List<Enveloped<Message>>?					Outbound  {get; set;}
        /// <summary>
        ///Messages to be appended to the user's inbound spool. this is
        ///typically used to post notifications to the user to mark messages as having been
        ///read or responded to.
        /// </summary>

	public virtual List<Enveloped<Message>>?					Inbound  {get; set;}
        /// <summary>
        ///Messages to be appended to the user's local spool. This is used to allow connecting
        ///devices to collect activation messages before they have connected to the mesh.
        /// </summary>

	public virtual List<Enveloped<Message>>?					Local  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new TransactRequest(), MeshRequestUser._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updates", new PropertyListStruct ("Updates", 
					(IBinding data, object? value) => {(data as TransactRequest).Updates = value as List<StoreUpdate>;}, (IBinding data) => (data as TransactRequest).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate())} ,
			{ "Accounts", new PropertyListString ("Accounts", 
					(IBinding data, List<string>? value) => {(data as TransactRequest).Accounts = value;}, (IBinding data) => (data as TransactRequest).Accounts )},
			{ "Outbound", new PropertyListStruct ("Outbound", 
					(IBinding data, object? value) => {(data as TransactRequest).Outbound = value as List<Enveloped<Message>>;}, (IBinding data) => (data as TransactRequest).Outbound,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())} ,
			{ "Inbound", new PropertyListStruct ("Inbound", 
					(IBinding data, object? value) => {(data as TransactRequest).Inbound = value as List<Enveloped<Message>>;}, (IBinding data) => (data as TransactRequest).Inbound,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())} ,
			{ "Local", new PropertyListStruct ("Local", 
					(IBinding data, object? value) => {(data as TransactRequest).Local = value as List<Enveloped<Message>>;}, (IBinding data) => (data as TransactRequest).Local,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())} 
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

	public virtual byte[]?						Bitmask  {get; set;}

        /// <summary>
        ///The responses to the entries.
        /// </summary>

	public virtual List<EntryResponse>?					Entries  {get; set;}
        /// <summary>
        ///If the upload request contains redacted entries, specifies constraints 
        ///that apply to the redacted entries as a group. Thus the total payloads
        ///of all the messages must not exceed the specified value.
        /// </summary>

	public virtual ConstraintsData?						ConstraintsData  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new TransactResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Bitmask", new PropertyBinary ("Bitmask", 
					(IBinding data, byte[]? value) => {(data as TransactResponse).Bitmask = value;}, (IBinding data) => (data as TransactResponse).Bitmask )},
			{ "Entries", new PropertyListStruct ("Entries", 
					(IBinding data, object? value) => {(data as TransactResponse).Entries = value as List<EntryResponse>;}, (IBinding data) => (data as TransactResponse).Entries,
					false, ()=>new  List<EntryResponse>(), ()=>new EntryResponse())} ,
			{ "ConstraintsData", new PropertyStruct ("ConstraintsData", 
					(IBinding data, object? value) => {(data as TransactResponse).ConstraintsData = value as ConstraintsData;}, (IBinding data) => (data as TransactResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())} 
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

	public virtual string?						Result  {get; set;}

        /// <summary>
        ///If the entry was redacted, specifies constraints 
        ///that apply to the redacted entries as a group. Thus the total payloads
        ///of all the messages must not exceed the specified value.	
        /// </summary>

	public virtual ConstraintsData?						ConstraintsData  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new EntryResponse(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "IndexRequest", new PropertyInteger64 ("IndexRequest", 
					(IBinding data, long? value) => {(data as EntryResponse).IndexRequest = value;}, (IBinding data) => (data as EntryResponse).IndexRequest )},
			{ "IndexContainer", new PropertyInteger64 ("IndexContainer", 
					(IBinding data, long? value) => {(data as EntryResponse).IndexContainer = value;}, (IBinding data) => (data as EntryResponse).IndexContainer )},
			{ "Result", new PropertyString ("Result", 
					(IBinding data, string? value) => {(data as EntryResponse).Result = value;}, (IBinding data) => (data as EntryResponse).Result )},
			{ "ConstraintsData", new PropertyStruct ("ConstraintsData", 
					(IBinding data, object? value) => {(data as EntryResponse).ConstraintsData = value as ConstraintsData;}, (IBinding data) => (data as EntryResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PublicRequest(), DownloadRequest._binding);

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

	public virtual List<string>?					Accounts  {get; set;}
        /// <summary>
        ///The messages to be sent to the addresses specified in Accounts. 
        /// </summary>

	public virtual List<Enveloped<Message>>?					Messages  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PostRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Accounts", new PropertyListString ("Accounts", 
					(IBinding data, List<string>? value) => {(data as PostRequest).Accounts = value;}, (IBinding data) => (data as PostRequest).Accounts )},
			{ "Messages", new PropertyListStruct ("Messages", 
					(IBinding data, object? value) => {(data as PostRequest).Messages = value as List<Enveloped<Message>>;}, (IBinding data) => (data as PostRequest).Messages,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PostResponse(), TransactResponse._binding);

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

	public virtual Enveloped<MessageClaim>?						EnvelopedMessageClaim  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ClaimRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedMessageClaim", new PropertyStruct ("EnvelopedMessageClaim", 
					(IBinding data, object? value) => {(data as ClaimRequest).EnvelopedMessageClaim = value as Enveloped<MessageClaim>;}, (IBinding data) => (data as ClaimRequest).EnvelopedMessageClaim,
					false, ()=>new  Enveloped<MessageClaim>(), ()=>new Enveloped<MessageClaim>())} 
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

	public virtual CatalogedPublication?						CatalogedPublication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ClaimResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CatalogedPublication", new PropertyStruct ("CatalogedPublication", 
					(IBinding data, object? value) => {(data as ClaimResponse).CatalogedPublication = value as CatalogedPublication;}, (IBinding data) => (data as ClaimResponse).CatalogedPublication,
					false, ()=>new  CatalogedPublication(), ()=>new CatalogedPublication())} 
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

	public virtual string?						PublicationId  {get; set;}

        /// <summary>
        ///Account to which the claim is directed
        /// </summary>

	public virtual string?						TargetAccountAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PollClaimRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicationId", new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as PollClaimRequest).PublicationId = value;}, (IBinding data) => (data as PollClaimRequest).PublicationId )},
			{ "TargetAccountAddress", new PropertyString ("TargetAccountAddress", 
					(IBinding data, string? value) => {(data as PollClaimRequest).TargetAccountAddress = value;}, (IBinding data) => (data as PollClaimRequest).TargetAccountAddress )}
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

	public virtual Enveloped<Message>?						EnvelopedMessage  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PollClaimResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedMessage", new PropertyStruct ("EnvelopedMessage", 
					(IBinding data, object? value) => {(data as PollClaimResponse).EnvelopedMessage = value as Enveloped<Message>;}, (IBinding data) => (data as PollClaimResponse).EnvelopedMessage,
					false, ()=>new  Enveloped<Message>(), ()=>new Enveloped<Message>())} 
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

	public virtual string?						KeyId  {get; set;}

        /// <summary>
        ///Lagrange coefficient multiplier to be applied to the private key
        /// </summary>

	public virtual byte[]?						KeyCoefficient  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyId", new PropertyString ("KeyId", 
					(IBinding data, string? value) => {(data as CryptographicOperation).KeyId = value;}, (IBinding data) => (data as CryptographicOperation).KeyId )},
			{ "KeyCoefficient", new PropertyBinary ("KeyCoefficient", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperation).KeyCoefficient = value;}, (IBinding data) => (data as CryptographicOperation).KeyCoefficient )}
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

	public virtual byte[]?						Data  {get; set;}

        /// <summary>
        ///Contribution to the R offset.
        /// </summary>

	public virtual byte[]?						PartialR  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicOperationSign(), CryptographicOperation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Data", new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperationSign).Data = value;}, (IBinding data) => (data as CryptographicOperationSign).Data )},
			{ "PartialR", new PropertyBinary ("PartialR", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperationSign).PartialR = value;}, (IBinding data) => (data as CryptographicOperationSign).PartialR )}
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

	public virtual Key?						PublicKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicOperationKeyAgreement(), CryptographicOperation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicKey", new PropertyStruct ("PublicKey", 
					(IBinding data, object? value) => {(data as CryptographicOperationKeyAgreement).PublicKey = value as Key;}, (IBinding data) => (data as CryptographicOperationKeyAgreement).PublicKey,
					true)} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicOperationGenerate(), CryptographicOperation._binding);

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



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicOperationShare(), CryptographicOperation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Threshold", new PropertyInteger32 ("Threshold", 
					(IBinding data, int? value) => {(data as CryptographicOperationShare).Threshold = value;}, (IBinding data) => (data as CryptographicOperationShare).Threshold )},
			{ "Shares", new PropertyInteger32 ("Shares", 
					(IBinding data, int? value) => {(data as CryptographicOperationShare).Shares = value;}, (IBinding data) => (data as CryptographicOperationShare).Shares )}
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

	public virtual string?						Error  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicResult(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Error", new PropertyString ("Error", 
					(IBinding data, string? value) => {(data as CryptographicResult).Error = value;}, (IBinding data) => (data as CryptographicResult).Error )}
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

	public virtual KeyAgreement?						KeyAgreement  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicResultKeyAgreement(), CryptographicResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyAgreement", new PropertyStruct ("KeyAgreement", 
					(IBinding data, object? value) => {(data as CryptographicResultKeyAgreement).KeyAgreement = value as KeyAgreement;}, (IBinding data) => (data as CryptographicResultKeyAgreement).KeyAgreement,
					true)} 
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CryptographicResultShare(), CryptographicResult._binding);

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

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<CryptographicOperation>?					Operations  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new OperateRequest(), MeshRequest._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as OperateRequest).AccountAddress = value;}, (IBinding data) => (data as OperateRequest).AccountAddress )},
			{ "Operations", new PropertyListStruct ("Operations", 
					(IBinding data, object? value) => {(data as OperateRequest).Operations = value as List<CryptographicOperation>;}, (IBinding data) => (data as OperateRequest).Operations,
					true, ()=>new List<CryptographicOperation>()
)} 
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

	public virtual List<CryptographicResult>?					Results  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new OperateResponse(), MeshResponse._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Results", new PropertyListStruct ("Results", 
					(IBinding data, object? value) => {(data as OperateResponse).Results = value as List<CryptographicResult>;}, (IBinding data) => (data as OperateResponse).Results,
					true, ()=>new List<CryptographicResult>()
)} 
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



