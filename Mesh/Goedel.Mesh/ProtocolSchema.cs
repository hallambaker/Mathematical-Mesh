
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
//  This file was automatically generated at 5/27/2025 3:12:45 PM
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

	/*
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
	    {"UploadRequest", UploadRequest._Factory},
	    {"UploadResponse", UploadResponse._Factory},
	    {"GetDataRequest", GetDataRequest._Factory},
	    {"GetDataResponse", GetDataResponse._Factory},
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
	*/

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(MeshRequest), MeshRequest._binding},
	    {typeof(MeshRequestUser), MeshRequestUser._binding},
	    {typeof(MeshResponse), MeshResponse._binding},
	    {typeof(KeyValue), KeyValue._binding},
	    {typeof(ConstraintsSelect), ConstraintsSelect._binding},
	    {typeof(ConstraintsData), ConstraintsData._binding},
	    {typeof(PolicyAccount), PolicyAccount._binding},
	    {typeof(StoreStatus), StoreStatus._binding},
	    {typeof(StoreUpdate), StoreUpdate._binding},
	    {typeof(MeshHelloRequest), MeshHelloRequest._binding},
	    {typeof(MeshHelloResponse), MeshHelloResponse._binding},
	    {typeof(BindRequest), BindRequest._binding},
	    {typeof(BindResponse), BindResponse._binding},
	    {typeof(UnbindRequest), UnbindRequest._binding},
	    {typeof(UnbindResponse), UnbindResponse._binding},
	    {typeof(ConnectRequest), ConnectRequest._binding},
	    {typeof(ConnectResponse), ConnectResponse._binding},
	    {typeof(CompleteRequest), CompleteRequest._binding},
	    {typeof(CompleteResponse), CompleteResponse._binding},
	    {typeof(StatusRequest), StatusRequest._binding},
	    {typeof(StatusResponse), StatusResponse._binding},
	    {typeof(DeviceStatus), DeviceStatus._binding},
	    {typeof(DownloadRequest), DownloadRequest._binding},
	    {typeof(DownloadResponse), DownloadResponse._binding},
	    {typeof(UploadRequest), UploadRequest._binding},
	    {typeof(UploadResponse), UploadResponse._binding},
	    {typeof(GetDataRequest), GetDataRequest._binding},
	    {typeof(GetDataResponse), GetDataResponse._binding},
	    {typeof(TransactRequest), TransactRequest._binding},
	    {typeof(TransactResponse), TransactResponse._binding},
	    {typeof(EntryResponse), EntryResponse._binding},
	    {typeof(PublicRequest), PublicRequest._binding},
	    {typeof(PostRequest), PostRequest._binding},
	    {typeof(PostResponse), PostResponse._binding},
	    {typeof(ClaimRequest), ClaimRequest._binding},
	    {typeof(ClaimResponse), ClaimResponse._binding},
	    {typeof(PollClaimRequest), PollClaimRequest._binding},
	    {typeof(PollClaimResponse), PollClaimResponse._binding},
	    {typeof(CryptographicOperation), CryptographicOperation._binding},
	    {typeof(CryptographicOperationSign), CryptographicOperationSign._binding},
	    {typeof(CryptographicOperationKeyAgreement), CryptographicOperationKeyAgreement._binding},
	    {typeof(CryptographicOperationGenerate), CryptographicOperationGenerate._binding},
	    {typeof(CryptographicOperationShare), CryptographicOperationShare._binding},
	    {typeof(CryptographicResult), CryptographicResult._binding},
	    {typeof(CryptographicResultKeyAgreement), CryptographicResultKeyAgreement._binding},
	    {typeof(CryptographicResultShare), CryptographicResultShare._binding},
	    {typeof(OperateRequest), OperateRequest._binding},
	    {typeof(OperateResponse), OperateResponse._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static MeshProtocol() {
		_Initialize();
		}

    internal static void _Initialize() {
		//AddDictionary(ref _tagDictionary);
		AddDictionary(ref _bindingDictionary);
		}

	/*
	/// <summary>
    /// Construct an instance from the specified tagged JsonReader stream.
    /// </summary>
    /// <param name="jsonReader">Input stream</param>
    /// <param name="result">The created object</param>
    public static void Deserialize(JsonReader jsonReader, out JsonObject result) => 
		result = jsonReader.ReadTaggedObject(_TagDictionary);
	*/

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
	public override Dictionary<string, Type>  GetTagDictionary => _TagDictionary;
		
	static Dictionary<string, Type> _TagDictionary = new () {
				{"Hello", typeof(HelloRequest)},
				{"BindAccount", typeof(BindRequest)},
				{"UnbindAccount", typeof(UnbindRequest)},
				{"Connect", typeof(ConnectRequest)},
				{"Complete", typeof(CompleteRequest)},
				{"Status", typeof(StatusRequest)},
				{"Download", typeof(DownloadRequest)},
				{"Upload", typeof(UploadRequest)},
				{"GetData", typeof(GetDataRequest)},
				{"Transact", typeof(TransactRequest)},
				{"PublicRead", typeof(PublicRequest)},
				{"Post", typeof(PostRequest)},
				{"Claim", typeof(ClaimRequest)},
				{"PollClaim", typeof(PollClaimRequest)},
				{"Operate", typeof(OperateRequest)}
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
		"Upload" => Upload(request as UploadRequest, session),
		"GetData" => GetData(request as GetDataRequest, session),
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
	/// Base method for implementing the transaction Upload.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract UploadResponse Upload (
            UploadRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction GetData.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract GetDataResponse GetData (
            GetDataRequest request, IJpcSession session);

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
	/// Implement the transaction Upload.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public UploadResponse Upload (UploadRequest request) =>
			UploadAsync (request).Sync();

    /// <summary>
	/// Implement the transaction Upload asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<UploadResponse> UploadAsync (UploadRequest request) =>
			await JpcSession.PostAsync("Upload", request) as UploadResponse;

    /// <summary>
	/// Implement the transaction GetData.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public GetDataResponse GetData (GetDataRequest request) =>
			GetDataAsync (request).Sync();

    /// <summary>
	/// Implement the transaction GetData asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<GetDataResponse> GetDataAsync (GetDataRequest request) =>
			await JpcSession.PostAsync("GetData", request) as GetDataResponse;

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
    public override Task<UploadResponse> UploadAsync (UploadRequest request) =>
			Task.FromResult(Service.Upload (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<GetDataResponse> GetDataAsync (GetDataRequest request) =>
			Task.FromResult(Service.GetData (request, JpcSession));


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
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshRequest> _binding = new (
			new() {

        }, __Tag,() => new MeshRequest(), () => new List<MeshRequest>(), () => new Dictionary<string,MeshRequest>(),Goedel.Protocol.Request._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Goedel.Protocol.Request._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("Account")]
	public virtual string?					Account  {get; set;} //

    /// <summary>
    ///The identifier of the capability under which access is claimed.
    /// </summary>

	[JsonPropertyName("Capability")]
	public virtual string?					Capability  {get; set;} //

    /// <summary>
    ///Device profile of the device making the request.
    /// </summary>

	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Account", 
					(IBinding data, string? value) => {(data as MeshRequestUser).Account = value;}, 
					(IBinding data) => (data as MeshRequestUser).Account ),
		new PropertyString ("Capability", 
					(IBinding data, string? value) => {(data as MeshRequestUser).Capability = value;}, 
					(IBinding data) => (data as MeshRequestUser).Capability ),
		new PropertyStruct ("EnvelopedProfileDevice", typeof (Enveloped<ProfileDevice>),
					(IBinding data, object? value) => {(data as MeshRequestUser).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, 
					(IBinding data) => (data as MeshRequestUser).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshRequestUser> _binding = new (
			new() {

			{ "Account", _properties [0]},
			{ "Capability", _properties [1]},
			{ "EnvelopedProfileDevice", _properties [2]}
        }, __Tag,() => new MeshRequestUser(), () => new List<MeshRequestUser>(), () => new Dictionary<string,MeshRequestUser>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class MeshResponse : Goedel.Protocol.Response {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshResponse> _binding = new (
			new() {

        }, __Tag,() => new MeshResponse(), () => new List<MeshResponse>(), () => new Dictionary<string,MeshResponse>(),Goedel.Protocol.Response._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Goedel.Protocol.Response._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    ///The data value to match.
    /// </summary>

	[JsonPropertyName("Value")]
	public virtual string?					Value  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as KeyValue).Key = value;}, 
					(IBinding data) => (data as KeyValue).Key ),
		new PropertyString ("Value", 
					(IBinding data, string? value) => {(data as KeyValue).Value = value;}, 
					(IBinding data) => (data as KeyValue).Value )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyValue> _binding = new (
			new() {

			{ "Key", _properties [0]},
			{ "Value", _properties [1]}
        }, __Tag,() => new KeyValue(), () => new List<KeyValue>(), () => new Dictionary<string,KeyValue>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("Store")]
	public virtual string?					Store  {get; set;} //

    /// <summary>
    ///Only return objects with an index value that is equal to or
    ///higher than the value specified.
    /// </summary>

	[JsonPropertyName("IndexMin")]
	public virtual long?					IndexMin  {get; set;} //

    /// <summary>
    ///Only return objects with an index value that is equal to or
    ///lower than the value specified.
    /// </summary>

	[JsonPropertyName("IndexMax")]
	public virtual long?					IndexMax  {get; set;} //

    /// <summary>
    ///Only data published on or after the specified time instant 
    ///is requested.
    /// </summary>

	[JsonPropertyName("NotBefore")]
	public virtual DateTime?					NotBefore  {get; set;} //

    /// <summary>
    ///Only data published before the specified time instant is
    ///requested. This excludes data published at the specified time instant.
    /// </summary>

	[JsonPropertyName("Before")]
	public virtual DateTime?					Before  {get; set;} //

    /// <summary>
    ///Specifies a page key returned in a previous search operation
    ///in which the number of responses exceeded the specified bounds.
    ///When a page key is specified, all the other search parameters
    ///except for MaxEntries and MaxBytes are ignored and the service
    ///returns the next set of data responding to the earlier query.
    /// </summary>

	[JsonPropertyName("PageKey")]
	public virtual string?					PageKey  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Store", 
					(IBinding data, string? value) => {(data as ConstraintsSelect).Store = value;}, 
					(IBinding data) => (data as ConstraintsSelect).Store ),
		new PropertyInteger64 ("IndexMin", 
					(IBinding data, long? value) => {(data as ConstraintsSelect).IndexMin = value;}, 
					(IBinding data) => (data as ConstraintsSelect).IndexMin ),
		new PropertyInteger64 ("IndexMax", 
					(IBinding data, long? value) => {(data as ConstraintsSelect).IndexMax = value;}, 
					(IBinding data) => (data as ConstraintsSelect).IndexMax ),
		new PropertyDateTime ("NotBefore", 
					(IBinding data, DateTime? value) => {(data as ConstraintsSelect).NotBefore = value;}, 
					(IBinding data) => (data as ConstraintsSelect).NotBefore ),
		new PropertyDateTime ("Before", 
					(IBinding data, DateTime? value) => {(data as ConstraintsSelect).Before = value;}, 
					(IBinding data) => (data as ConstraintsSelect).Before ),
		new PropertyString ("PageKey", 
					(IBinding data, string? value) => {(data as ConstraintsSelect).PageKey = value;}, 
					(IBinding data) => (data as ConstraintsSelect).PageKey )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConstraintsSelect> _binding = new (
			new() {

			{ "Store", _properties [0]},
			{ "IndexMin", _properties [1]},
			{ "IndexMax", _properties [2]},
			{ "NotBefore", _properties [3]},
			{ "Before", _properties [4]},
			{ "PageKey", _properties [5]}
        }, __Tag,() => new ConstraintsSelect(), () => new List<ConstraintsSelect>(), () => new Dictionary<string,ConstraintsSelect>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Specifies constraints on the data to be sent.
	/// </summary>
public partial class ConstraintsData : MeshProtocol {
    /// <summary>
    ///Maximum number of entries to send.
    /// </summary>

	[JsonPropertyName("MaxEntries")]
	public virtual long?					MaxEntries  {get; set;} //

    /// <summary>
    ///Specifies an offset to be applied to the payload data before it is sent. 
    ///This allows large payloads to be transferred incrementally.
    /// </summary>

	[JsonPropertyName("BytesOffset")]
	public virtual long?					BytesOffset  {get; set;} //

    /// <summary>
    ///Maximum number of payload bytes to send.
    /// </summary>

	[JsonPropertyName("BytesMax")]
	public virtual long?					BytesMax  {get; set;} //

    /// <summary>
    ///Return the entry header
    /// </summary>

	[JsonPropertyName("Header")]
	public virtual bool?					Header  {get; set;} //

    /// <summary>
    ///Return the entry payload
    /// </summary>

	[JsonPropertyName("Payload")]
	public virtual bool?					Payload  {get; set;} //

    /// <summary>
    ///Return the entry trailer
    /// </summary>

	[JsonPropertyName("Trailer")]
	public virtual bool?					Trailer  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyInteger64 ("MaxEntries", 
					(IBinding data, long? value) => {(data as ConstraintsData).MaxEntries = value;}, 
					(IBinding data) => (data as ConstraintsData).MaxEntries ),
		new PropertyInteger64 ("BytesOffset", 
					(IBinding data, long? value) => {(data as ConstraintsData).BytesOffset = value;}, 
					(IBinding data) => (data as ConstraintsData).BytesOffset ),
		new PropertyInteger64 ("BytesMax", 
					(IBinding data, long? value) => {(data as ConstraintsData).BytesMax = value;}, 
					(IBinding data) => (data as ConstraintsData).BytesMax ),
		new PropertyBoolean ("Header", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Header = value;}, 
					(IBinding data) => (data as ConstraintsData).Header ),
		new PropertyBoolean ("Payload", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Payload = value;}, 
					(IBinding data) => (data as ConstraintsData).Payload ),
		new PropertyBoolean ("Trailer", 
					(IBinding data, bool? value) => {(data as ConstraintsData).Trailer = value;}, 
					(IBinding data) => (data as ConstraintsData).Trailer )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConstraintsData> _binding = new (
			new() {

			{ "MaxEntries", _properties [0]},
			{ "BytesOffset", _properties [1]},
			{ "BytesMax", _properties [2]},
			{ "Header", _properties [3]},
			{ "Payload", _properties [4]},
			{ "Trailer", _properties [5]}
        }, __Tag,() => new ConstraintsData(), () => new List<ConstraintsData>(), () => new Dictionary<string,ConstraintsData>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("Minimum")]
	public virtual int?					Minimum  {get; set;} //

    /// <summary>
    ///Specifies the maximum length of an account name.
    /// </summary>

	[JsonPropertyName("Maximum")]
	public virtual int?					Maximum  {get; set;} //

    /// <summary>
    ///A list of characters that the service 
    ///does not accept in account names. The list of characters 
    ///MAY not be exhaustive but SHOULD include any illegal characters
    ///in the proposed account name.
    /// </summary>

	[JsonPropertyName("InvalidCharacters")]
	public virtual string?					InvalidCharacters  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyInteger32 ("Minimum", 
					(IBinding data, int? value) => {(data as PolicyAccount).Minimum = value;}, 
					(IBinding data) => (data as PolicyAccount).Minimum ),
		new PropertyInteger32 ("Maximum", 
					(IBinding data, int? value) => {(data as PolicyAccount).Maximum = value;}, 
					(IBinding data) => (data as PolicyAccount).Maximum ),
		new PropertyString ("InvalidCharacters", 
					(IBinding data, string? value) => {(data as PolicyAccount).InvalidCharacters = value;}, 
					(IBinding data) => (data as PolicyAccount).InvalidCharacters )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PolicyAccount> _binding = new (
			new() {

			{ "Minimum", _properties [0]},
			{ "Maximum", _properties [1]},
			{ "InvalidCharacters", _properties [2]}
        }, __Tag,() => new PolicyAccount(), () => new List<PolicyAccount>(), () => new Dictionary<string,PolicyAccount>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class StoreStatus : MeshProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Store")]
	public virtual string?					Store  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Index")]
	public virtual long?					Index  {get; set;} //

    /// <summary>
    ///In a status response, the apex digest value of the store 
    ///whose status is reported.
    /// </summary>

	[JsonPropertyName("Digest")]
	public virtual byte[]?					Digest  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Store", 
					(IBinding data, string? value) => {(data as StoreStatus).Store = value;}, 
					(IBinding data) => (data as StoreStatus).Store ),
		new PropertyInteger64 ("Index", 
					(IBinding data, long? value) => {(data as StoreStatus).Index = value;}, 
					(IBinding data) => (data as StoreStatus).Index ),
		new PropertyBinary ("Digest", 
					(IBinding data, byte[]? value) => {(data as StoreStatus).Digest = value;}, 
					(IBinding data) => (data as StoreStatus).Digest )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StoreStatus> _binding = new (
			new() {

			{ "Store", _properties [0]},
			{ "Index", _properties [1]},
			{ "Digest", _properties [2]}
        }, __Tag,() => new StoreStatus(), () => new List<StoreStatus>(), () => new Dictionary<string,StoreStatus>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class StoreUpdate : StoreStatus {
    /// <summary>
    ///The entries to be uploaded. 
    /// </summary>

	[JsonPropertyName("Envelopes")]
	public virtual List<DareEnvelope>?					Envelopes  {get; set;}
    /// <summary>
    ///If false, the store update does not contain the last index entry
    ///in the store.
    /// </summary>

	[JsonPropertyName("Partial")]
	public virtual bool?					Partial  {get; set;} //

    /// <summary>
    ///If the value Partial is true, this value MUST specify the index
    ///value of the last entry in the store.
    /// </summary>

	[JsonPropertyName("FinalIndex")]
	public virtual long?					FinalIndex  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyListStruct ("Envelopes", typeof (DareEnvelope),
					(IBinding data, object? value) => {(data as StoreUpdate).Envelopes = value as List<DareEnvelope>;}, 
					(IBinding data) => (data as StoreUpdate).Envelopes,
					false, ()=>new  List<DareEnvelope>(), ()=>new DareEnvelope()),
		new PropertyBoolean ("Partial", 
					(IBinding data, bool? value) => {(data as StoreUpdate).Partial = value;}, 
					(IBinding data) => (data as StoreUpdate).Partial ),
		new PropertyInteger64 ("FinalIndex", 
					(IBinding data, long? value) => {(data as StoreUpdate).FinalIndex = value;}, 
					(IBinding data) => (data as StoreUpdate).FinalIndex )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StoreUpdate> _binding = new (
			new() {

			{ "Envelopes", _properties [0]},
			{ "Partial", _properties [1]},
			{ "FinalIndex", _properties [2]}
        }, __Tag,() => new StoreUpdate(), () => new List<StoreUpdate>(), () => new Dictionary<string,StoreUpdate>(),StoreStatus._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(StoreStatus._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class MeshHelloRequest : Goedel.Protocol.HelloRequest {
    /// <summary>
    ///Contains a proposed callsign binding to the account.
    /// </summary>

	[JsonPropertyName("CallsignBinding")]
	public virtual CallsignBinding?					CallsignBinding  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("CallsignBinding", typeof (CallsignBinding),
					(IBinding data, object? value) => {(data as MeshHelloRequest).CallsignBinding = value as CallsignBinding;}, 
					(IBinding data) => (data as MeshHelloRequest).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshHelloRequest> _binding = new (
			new() {

			{ "CallsignBinding", _properties [0]}
        }, __Tag,() => new MeshHelloRequest(), () => new List<MeshHelloRequest>(), () => new Dictionary<string,MeshHelloRequest>(),Goedel.Protocol.HelloRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Goedel.Protocol.HelloRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class MeshHelloResponse : Goedel.Protocol.HelloResponse {
    /// <summary>
    ///Specifies the default data constraints for updates.
    /// </summary>

	[JsonPropertyName("ConstraintsUpdate")]
	public virtual ConstraintsData?					ConstraintsUpdate  {get; set;} //

    /// <summary>
    ///Specifies the default data constraints for message senders.
    /// </summary>

	[JsonPropertyName("ConstraintsPost")]
	public virtual ConstraintsData?					ConstraintsPost  {get; set;} //

    /// <summary>
    ///Specifies the account creation policy
    /// </summary>

	[JsonPropertyName("PolicyAccount")]
	public virtual PolicyAccount?					PolicyAccount  {get; set;} //

	[JsonPropertyName("ProfileService")]
	public virtual Enveloped<ProfileService>?					EnvelopedProfileService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileService?				ProfileService  {get; set;} 
    /// <summary>
    ///If the request specifies a callsign binding, returns a proposed binding for
    ///the requested callsign.
    /// </summary>

	[JsonPropertyName("CallsignBinding")]
	public virtual CallsignBinding?					CallsignBinding  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("ConstraintsUpdate", typeof (ConstraintsData),
					(IBinding data, object? value) => {(data as MeshHelloResponse).ConstraintsUpdate = value as ConstraintsData;}, 
					(IBinding data) => (data as MeshHelloResponse).ConstraintsUpdate,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData()),
		new PropertyStruct ("ConstraintsPost", typeof (ConstraintsData),
					(IBinding data, object? value) => {(data as MeshHelloResponse).ConstraintsPost = value as ConstraintsData;}, 
					(IBinding data) => (data as MeshHelloResponse).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData()),
		new PropertyStruct ("PolicyAccount", typeof (PolicyAccount),
					(IBinding data, object? value) => {(data as MeshHelloResponse).PolicyAccount = value as PolicyAccount;}, 
					(IBinding data) => (data as MeshHelloResponse).PolicyAccount,
					false, ()=>new  PolicyAccount(), ()=>new PolicyAccount()),
		new PropertyGStruct ("ProfileService", /*typeof (ProfileService<>),*/typeof (Enveloped),
					(IBinding data, object? value) => {(data as MeshHelloResponse).EnvelopedProfileService = value as Enveloped<ProfileService>;},
					(IBinding data) => (data as MeshHelloResponse).EnvelopedProfileService,
					/*(IBinding data, object? value) => {(data as MeshHelloResponse).ProfileService = value as ProfileService;},
					(IBinding data) => (data as MeshHelloResponse).ProfileService,*/
					()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>()),
		new PropertyStruct ("CallsignBinding", typeof (CallsignBinding),
					(IBinding data, object? value) => {(data as MeshHelloResponse).CallsignBinding = value as CallsignBinding;}, 
					(IBinding data) => (data as MeshHelloResponse).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshHelloResponse> _binding = new (
			new() {

			{ "ConstraintsUpdate", _properties [0]},
			{ "ConstraintsPost", _properties [1]},
			{ "PolicyAccount", _properties [2]},
			{ "ProfileService", _properties [3]},
			{ "CallsignBinding", _properties [4]}
        }, __Tag,() => new MeshHelloResponse(), () => new List<MeshHelloResponse>(), () => new Dictionary<string,MeshHelloResponse>(),Goedel.Protocol.HelloResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Goedel.Protocol.HelloResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Request binding of an account to a service address.
	/// </summary>
public partial class BindRequest : MeshRequest {
    /// <summary>
    ///The service account to bind to.
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    ///The signed assertion describing the account.
    /// </summary>

	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} //

    /// <summary>
    ///Contains one or more bindings of a callsign to the account.
    /// </summary>

	[JsonPropertyName("EnvelopedCallsignBinding")]
	public virtual List<Enveloped<CallsignBinding>>?					EnvelopedCallsignBinding  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as BindRequest).AccountAddress = value;}, 
					(IBinding data) => (data as BindRequest).AccountAddress ),
		new PropertyStruct ("EnvelopedProfileAccount", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as BindRequest).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as BindRequest).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyListStruct ("EnvelopedCallsignBinding", typeof (Enveloped<CallsignBinding>),
					(IBinding data, object? value) => {(data as BindRequest).EnvelopedCallsignBinding = value as List<Enveloped<CallsignBinding>>;}, 
					(IBinding data) => (data as BindRequest).EnvelopedCallsignBinding,
					false, ()=>new  List<Enveloped<CallsignBinding>>(), ()=>new Enveloped<CallsignBinding>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<BindRequest> _binding = new (
			new() {

			{ "AccountAddress", _properties [0]},
			{ "EnvelopedProfileAccount", _properties [1]},
			{ "EnvelopedCallsignBinding", _properties [2]}
        }, __Tag,() => new BindRequest(), () => new List<BindRequest>(), () => new Dictionary<string,BindRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Reports the success or failure of a Create transaction.
	/// </summary>
public partial class BindResponse : MeshResponse {
    /// <summary>
    ///Text explaining the status of the creation request.
    /// </summary>

	[JsonPropertyName("Reason")]
	public virtual string?					Reason  {get; set;} //

    /// <summary>
    ///A URL to which the user is directed to complete the account creation 
    ///request.
    /// </summary>

	[JsonPropertyName("URL")]
	public virtual string?					URL  {get; set;} //

    /// <summary>
    ///The enveloped assignment describing how the client should
    ///discover the host and encrypt data to it.
    /// </summary>

	[JsonPropertyName("EnvelopedAccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Reason", 
					(IBinding data, string? value) => {(data as BindResponse).Reason = value;}, 
					(IBinding data) => (data as BindResponse).Reason ),
		new PropertyString ("URL", 
					(IBinding data, string? value) => {(data as BindResponse).URL = value;}, 
					(IBinding data) => (data as BindResponse).URL ),
		new PropertyStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped<AccountHostAssignment>),
					(IBinding data, object? value) => {(data as BindResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, 
					(IBinding data) => (data as BindResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<BindResponse> _binding = new (
			new() {

			{ "Reason", _properties [0]},
			{ "URL", _properties [1]},
			{ "EnvelopedAccountHostAssignment", _properties [2]}
        }, __Tag,() => new BindResponse(), () => new List<BindResponse>(), () => new Dictionary<string,BindResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Request creation of a new portal account. The request specifies
	/// the requested account identifier and the Mesh profile to be associated 
	/// with the account.
	/// </summary>
public partial class UnbindRequest : MeshRequestUser {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UnbindRequest> _binding = new (
			new() {

        }, __Tag,() => new UnbindRequest(), () => new List<UnbindRequest>(), () => new Dictionary<string,UnbindRequest>(),MeshRequestUser._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequestUser._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Reports the success or failure of a Delete transaction.
	/// </summary>
public partial class UnbindResponse : MeshResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UnbindResponse> _binding = new (
			new() {

        }, __Tag,() => new UnbindResponse(), () => new List<UnbindResponse>(), () => new Dictionary<string,UnbindResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class ConnectRequest : MeshRequest {
    /// <summary>
    ///The connection request generated by the client 
    /// </summary>

	[JsonPropertyName("EnvelopedRequestConnection")]
	public virtual Enveloped<RequestConnection>?					EnvelopedRequestConnection  {get; set;} //

    /// <summary>
    ///List of named access rights.
    /// </summary>

	[JsonPropertyName("Rights")]
	public virtual List<string>?					Rights  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("EnvelopedRequestConnection", typeof (Enveloped<RequestConnection>),
					(IBinding data, object? value) => {(data as ConnectRequest).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;}, 
					(IBinding data) => (data as ConnectRequest).EnvelopedRequestConnection,
					false, ()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>()),
		new PropertyListString ("Rights", 
					(IBinding data, List<string>? value) => {(data as ConnectRequest).Rights = value;}, 
					(IBinding data) => (data as ConnectRequest).Rights )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectRequest> _binding = new (
			new() {

			{ "EnvelopedRequestConnection", _properties [0]},
			{ "Rights", _properties [1]}
        }, __Tag,() => new ConnectRequest(), () => new List<ConnectRequest>(), () => new Dictionary<string,ConnectRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class ConnectResponse : MeshResponse {
    /// <summary>
    ///The connection request generated by the client
    /// </summary>

	[JsonPropertyName("EnvelopedAcknowledgeConnection")]
	public virtual Enveloped<AcknowledgeConnection>?					EnvelopedAcknowledgeConnection  {get; set;} //

    /// <summary>
    ///The user profile that provides the root of trust for this Mesh
    /// </summary>

	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("EnvelopedAcknowledgeConnection", typeof (Enveloped<AcknowledgeConnection>),
					(IBinding data, object? value) => {(data as ConnectResponse).EnvelopedAcknowledgeConnection = value as Enveloped<AcknowledgeConnection>;}, 
					(IBinding data) => (data as ConnectResponse).EnvelopedAcknowledgeConnection,
					false, ()=>new  Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>()),
		new PropertyStruct ("EnvelopedProfileAccount", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as ConnectResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as ConnectResponse).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectResponse> _binding = new (
			new() {

			{ "EnvelopedAcknowledgeConnection", _properties [0]},
			{ "EnvelopedProfileAccount", _properties [1]}
        }, __Tag,() => new ConnectResponse(), () => new List<ConnectResponse>(), () => new Dictionary<string,ConnectResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CompleteRequest : StatusRequest {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ResponseID")]
	public virtual string?					ResponseID  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CompleteRequest).AccountAddress = value;}, 
					(IBinding data) => (data as CompleteRequest).AccountAddress ),
		new PropertyString ("ResponseID", 
					(IBinding data, string? value) => {(data as CompleteRequest).ResponseID = value;}, 
					(IBinding data) => (data as CompleteRequest).ResponseID )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompleteRequest> _binding = new (
			new() {

			{ "AccountAddress", _properties [0]},
			{ "ResponseID", _properties [1]}
        }, __Tag,() => new CompleteRequest(), () => new List<CompleteRequest>(), () => new Dictionary<string,CompleteRequest>(),StatusRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(StatusRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CompleteResponse : MeshResponse {
    /// <summary>
    ///The signed assertion describing the result of the connect request
    /// </summary>

	[JsonPropertyName("EnvelopedRespondConnection")]
	public virtual Enveloped<RespondConnection>?					EnvelopedRespondConnection  {get; set;} //

    /// <summary>
    ///The enveloped assignment describing how the client should
    ///discover the host and encrypt data to it.
    /// </summary>

	[JsonPropertyName("EnvelopedAccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("EnvelopedRespondConnection", typeof (Enveloped<RespondConnection>),
					(IBinding data, object? value) => {(data as CompleteResponse).EnvelopedRespondConnection = value as Enveloped<RespondConnection>;}, 
					(IBinding data) => (data as CompleteResponse).EnvelopedRespondConnection,
					false, ()=>new  Enveloped<RespondConnection>(), ()=>new Enveloped<RespondConnection>()),
		new PropertyStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped<AccountHostAssignment>),
					(IBinding data, object? value) => {(data as CompleteResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, 
					(IBinding data) => (data as CompleteResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompleteResponse> _binding = new (
			new() {

			{ "EnvelopedRespondConnection", _properties [0]},
			{ "EnvelopedAccountHostAssignment", _properties [1]}
        }, __Tag,() => new CompleteResponse(), () => new List<CompleteResponse>(), () => new Dictionary<string,CompleteResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class StatusRequest : MeshRequestUser {
    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceUDF")]
	public virtual string?					DeviceUDF  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Catalogs")]
	public virtual List<string>?					Catalogs  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("Spools")]
	public virtual List<string>?					Spools  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<string>?					Services  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceStatus")]
	public virtual bool?					DeviceStatus  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as StatusRequest).DeviceUDF = value;}, 
					(IBinding data) => (data as StatusRequest).DeviceUDF ),
		new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as StatusRequest).CatalogedDeviceDigest = value;}, 
					(IBinding data) => (data as StatusRequest).CatalogedDeviceDigest ),
		new PropertyListString ("Catalogs", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Catalogs = value;}, 
					(IBinding data) => (data as StatusRequest).Catalogs ),
		new PropertyListString ("Spools", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Spools = value;}, 
					(IBinding data) => (data as StatusRequest).Spools ),
		new PropertyListString ("Services", 
					(IBinding data, List<string>? value) => {(data as StatusRequest).Services = value;}, 
					(IBinding data) => (data as StatusRequest).Services ),
		new PropertyBoolean ("DeviceStatus", 
					(IBinding data, bool? value) => {(data as StatusRequest).DeviceStatus = value;}, 
					(IBinding data) => (data as StatusRequest).DeviceStatus )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StatusRequest> _binding = new (
			new() {

			{ "DeviceUDF", _properties [0]},
			{ "CatalogedDeviceDigest", _properties [1]},
			{ "Catalogs", _properties [2]},
			{ "Spools", _properties [3]},
			{ "Services", _properties [4]},
			{ "DeviceStatus", _properties [5]}
        }, __Tag,() => new StatusRequest(), () => new List<StatusRequest>(), () => new Dictionary<string,StatusRequest>(),MeshRequestUser._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequestUser._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class StatusResponse : MeshResponse {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Bitmask")]
	public virtual byte[]?					Bitmask  {get; set;} //

    /// <summary>
    ///The account profile providing the root of trust for this account.
    /// </summary>

	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} //

    /// <summary>
    ///The catalog device entry
    /// </summary>

	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("StoreStatus")]
	public virtual List<StoreStatus>?					StoreStatus  {get; set;}
    /// <summary>
    ///The enveloped assignment describing how the client should
    ///discover the host and encrypt data to it.
    /// </summary>

	[JsonPropertyName("EnvelopedAccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} //

    /// <summary>
    ///A series of access tokens for the requested services.
    /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<ServiceAccessToken>?					Services  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceStatuses")]
	public virtual List<DeviceStatus>?					DeviceStatuses  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyBinary ("Bitmask", 
					(IBinding data, byte[]? value) => {(data as StatusResponse).Bitmask = value;}, 
					(IBinding data) => (data as StatusResponse).Bitmask ),
		new PropertyStruct ("EnvelopedProfileAccount", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, 
					(IBinding data) => (data as StatusResponse).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyStruct ("EnvelopedCatalogedDevice", typeof (Enveloped<CatalogedDevice>),
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, 
					(IBinding data) => (data as StatusResponse).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>()),
		new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as StatusResponse).CatalogedDeviceDigest = value;}, 
					(IBinding data) => (data as StatusResponse).CatalogedDeviceDigest ),
		new PropertyListStruct ("StoreStatus", typeof (StoreStatus),
					(IBinding data, object? value) => {(data as StatusResponse).StoreStatus = value as List<StoreStatus>;}, 
					(IBinding data) => (data as StatusResponse).StoreStatus,
					false, ()=>new  List<StoreStatus>(), ()=>new StoreStatus()),
		new PropertyStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped<AccountHostAssignment>),
					(IBinding data, object? value) => {(data as StatusResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;}, 
					(IBinding data) => (data as StatusResponse).EnvelopedAccountHostAssignment,
					false, ()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>()),
		new PropertyListStruct ("Services", typeof (ServiceAccessToken),
					(IBinding data, object? value) => {(data as StatusResponse).Services = value as List<ServiceAccessToken>;}, 
					(IBinding data) => (data as StatusResponse).Services,
					false, ()=>new  List<ServiceAccessToken>(), ()=>new ServiceAccessToken()),
		new PropertyListStruct ("DeviceStatuses", typeof (DeviceStatus),
					(IBinding data, object? value) => {(data as StatusResponse).DeviceStatuses = value as List<DeviceStatus>;}, 
					(IBinding data) => (data as StatusResponse).DeviceStatuses,
					false, ()=>new  List<DeviceStatus>(), ()=>new DeviceStatus())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StatusResponse> _binding = new (
			new() {

			{ "Bitmask", _properties [0]},
			{ "EnvelopedProfileAccount", _properties [1]},
			{ "EnvelopedCatalogedDevice", _properties [2]},
			{ "CatalogedDeviceDigest", _properties [3]},
			{ "StoreStatus", _properties [4]},
			{ "EnvelopedAccountHostAssignment", _properties [5]},
			{ "Services", _properties [6]},
			{ "DeviceStatuses", _properties [7]}
        }, __Tag,() => new StatusResponse(), () => new List<StatusResponse>(), () => new Dictionary<string,StatusResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class DeviceStatus : MeshProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Status")]
	public virtual string?					Status  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Comment")]
	public virtual string?					Comment  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("LastConnected")]
	public virtual DateTime?					LastConnected  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as DeviceStatus).Id = value;}, 
					(IBinding data) => (data as DeviceStatus).Id ),
		new PropertyString ("Status", 
					(IBinding data, string? value) => {(data as DeviceStatus).Status = value;}, 
					(IBinding data) => (data as DeviceStatus).Status ),
		new PropertyString ("Comment", 
					(IBinding data, string? value) => {(data as DeviceStatus).Comment = value;}, 
					(IBinding data) => (data as DeviceStatus).Comment ),
		new PropertyDateTime ("LastConnected", 
					(IBinding data, DateTime? value) => {(data as DeviceStatus).LastConnected = value;}, 
					(IBinding data) => (data as DeviceStatus).LastConnected )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceStatus> _binding = new (
			new() {

			{ "Id", _properties [0]},
			{ "Status", _properties [1]},
			{ "Comment", _properties [2]},
			{ "LastConnected", _properties [3]}
        }, __Tag,() => new DeviceStatus(), () => new List<DeviceStatus>(), () => new Dictionary<string,DeviceStatus>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("MaxResults")]
	public virtual int?					MaxResults  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceUDF")]
	public virtual string?					DeviceUDF  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

    /// <summary>
    ///Specifies constraints to be applied to a search result. These 
    ///allow a client to limit the number of records returned, the quantity
    ///of data returned, the earliest and latest data returned, etc.
    /// </summary>

	[JsonPropertyName("Select")]
	public virtual List<ConstraintsSelect>?					Select  {get; set;}
    /// <summary>
    ///Specifies the data constraints to be applied to the responses.
    /// </summary>

	[JsonPropertyName("ConstraintsPost")]
	public virtual ConstraintsData?					ConstraintsPost  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyInteger32 ("MaxResults", 
					(IBinding data, int? value) => {(data as DownloadRequest).MaxResults = value;}, 
					(IBinding data) => (data as DownloadRequest).MaxResults ),
		new PropertyString ("DeviceUDF", 
					(IBinding data, string? value) => {(data as DownloadRequest).DeviceUDF = value;}, 
					(IBinding data) => (data as DownloadRequest).DeviceUDF ),
		new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as DownloadRequest).CatalogedDeviceDigest = value;}, 
					(IBinding data) => (data as DownloadRequest).CatalogedDeviceDigest ),
		new PropertyListStruct ("Select", typeof (ConstraintsSelect),
					(IBinding data, object? value) => {(data as DownloadRequest).Select = value as List<ConstraintsSelect>;}, 
					(IBinding data) => (data as DownloadRequest).Select,
					false, ()=>new  List<ConstraintsSelect>(), ()=>new ConstraintsSelect()),
		new PropertyStruct ("ConstraintsPost", typeof (ConstraintsData),
					(IBinding data, object? value) => {(data as DownloadRequest).ConstraintsPost = value as ConstraintsData;}, 
					(IBinding data) => (data as DownloadRequest).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DownloadRequest> _binding = new (
			new() {

			{ "MaxResults", _properties [0]},
			{ "DeviceUDF", _properties [1]},
			{ "CatalogedDeviceDigest", _properties [2]},
			{ "Select", _properties [3]},
			{ "ConstraintsPost", _properties [4]}
        }, __Tag,() => new DownloadRequest(), () => new List<DownloadRequest>(), () => new Dictionary<string,DownloadRequest>(),MeshRequestUser._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequestUser._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	[JsonPropertyName("Updates")]
	public virtual List<StoreUpdate>?					Updates  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

    /// <summary>
    ///The catalog device entry. This is only returned if the 
    /// </summary>

	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyListStruct ("Updates", typeof (StoreUpdate),
					(IBinding data, object? value) => {(data as DownloadResponse).Updates = value as List<StoreUpdate>;}, 
					(IBinding data) => (data as DownloadResponse).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate()),
		new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as DownloadResponse).CatalogedDeviceDigest = value;}, 
					(IBinding data) => (data as DownloadResponse).CatalogedDeviceDigest ),
		new PropertyStruct ("EnvelopedCatalogedDevice", typeof (Enveloped<CatalogedDevice>),
					(IBinding data, object? value) => {(data as DownloadResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, 
					(IBinding data) => (data as DownloadResponse).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DownloadResponse> _binding = new (
			new() {

			{ "Updates", _properties [0]},
			{ "CatalogedDeviceDigest", _properties [1]},
			{ "EnvelopedCatalogedDevice", _properties [2]}
        }, __Tag,() => new DownloadResponse(), () => new List<DownloadResponse>(), () => new Dictionary<string,DownloadResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Uploads a data object to be retrievable from the specified account
	/// </summary>
public partial class UploadRequest : MeshRequestUser {
    /// <summary>
    ///The document identifier	
    /// </summary>

	[JsonPropertyName("DocumentId")]
	public virtual string?					DocumentId  {get; set;} //

    /// <summary>
    ///The data to be uploaded
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("DocumentId", 
					(IBinding data, string? value) => {(data as UploadRequest).DocumentId = value;}, 
					(IBinding data) => (data as UploadRequest).DocumentId ),
		new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as UploadRequest).Data = value;}, 
					(IBinding data) => (data as UploadRequest).Data )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UploadRequest> _binding = new (
			new() {

			{ "DocumentId", _properties [0]},
			{ "Data", _properties [1]}
        }, __Tag,() => new UploadRequest(), () => new List<UploadRequest>(), () => new Dictionary<string,UploadRequest>(),MeshRequestUser._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequestUser._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "UploadRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UploadRequest();

	}


	/// <summary>
	///
	/// Reports success or failure of an upload request
	/// </summary>
public partial class UploadResponse : MeshResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UploadResponse> _binding = new (
			new() {

        }, __Tag,() => new UploadResponse(), () => new List<UploadResponse>(), () => new Dictionary<string,UploadResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "UploadResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UploadResponse();

	}


	/// <summary>
	///
	/// Request object with specified identifier
	/// </summary>
public partial class GetDataRequest : MeshRequest {
    /// <summary>
    ///The document identifier	
    /// </summary>

	[JsonPropertyName("DocumentId")]
	public virtual string?					DocumentId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("DocumentId", 
					(IBinding data, string? value) => {(data as GetDataRequest).DocumentId = value;}, 
					(IBinding data) => (data as GetDataRequest).DocumentId )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GetDataRequest> _binding = new (
			new() {

			{ "DocumentId", _properties [0]}
        }, __Tag,() => new GetDataRequest(), () => new List<GetDataRequest>(), () => new Dictionary<string,GetDataRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "GetDataRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new GetDataRequest();

	}


	/// <summary>
	///
	/// Returns a data object uploaded to the specified account.
	/// </summary>
public partial class GetDataResponse : MeshResponse {
    /// <summary>
    ///The data retrieved
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as GetDataResponse).Data = value;}, 
					(IBinding data) => (data as GetDataResponse).Data )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GetDataResponse> _binding = new (
			new() {

			{ "Data", _properties [0]}
        }, __Tag,() => new GetDataResponse(), () => new List<GetDataResponse>(), () => new Dictionary<string,GetDataResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "GetDataResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new GetDataResponse();

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

	[JsonPropertyName("Updates")]
	public virtual List<StoreUpdate>?					Updates  {get; set;}
    /// <summary>
    ///The account(s) to which the request is directed.
    /// </summary>

	[JsonPropertyName("Accounts")]
	public virtual List<string>?					Accounts  {get; set;}
    /// <summary>
    ///The messages to be sent to other accounts  
    /// </summary>

	[JsonPropertyName("Outbound")]
	public virtual List<Enveloped<Message>>?					Outbound  {get; set;}
    /// <summary>
    ///Messages to be appended to the user's inbound spool. this is
    ///typically used to post notifications to the user to mark messages as having been
    ///read or responded to.
    /// </summary>

	[JsonPropertyName("Inbound")]
	public virtual List<Enveloped<Message>>?					Inbound  {get; set;}
    /// <summary>
    ///Messages to be appended to the user's local spool. This is used to allow connecting
    ///devices to collect activation messages before they have connected to the mesh.
    /// </summary>

	[JsonPropertyName("Local")]
	public virtual List<Enveloped<Message>>?					Local  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyListStruct ("Updates", typeof (StoreUpdate),
					(IBinding data, object? value) => {(data as TransactRequest).Updates = value as List<StoreUpdate>;}, 
					(IBinding data) => (data as TransactRequest).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate()),
		new PropertyListString ("Accounts", 
					(IBinding data, List<string>? value) => {(data as TransactRequest).Accounts = value;}, 
					(IBinding data) => (data as TransactRequest).Accounts ),
		new PropertyListStruct ("Outbound", typeof (Enveloped<Message>),
					(IBinding data, object? value) => {(data as TransactRequest).Outbound = value as List<Enveloped<Message>>;}, 
					(IBinding data) => (data as TransactRequest).Outbound,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>()),
		new PropertyListStruct ("Inbound", typeof (Enveloped<Message>),
					(IBinding data, object? value) => {(data as TransactRequest).Inbound = value as List<Enveloped<Message>>;}, 
					(IBinding data) => (data as TransactRequest).Inbound,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>()),
		new PropertyListStruct ("Local", typeof (Enveloped<Message>),
					(IBinding data, object? value) => {(data as TransactRequest).Local = value as List<Enveloped<Message>>;}, 
					(IBinding data) => (data as TransactRequest).Local,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TransactRequest> _binding = new (
			new() {

			{ "Updates", _properties [0]},
			{ "Accounts", _properties [1]},
			{ "Outbound", _properties [2]},
			{ "Inbound", _properties [3]},
			{ "Local", _properties [4]}
        }, __Tag,() => new TransactRequest(), () => new List<TransactRequest>(), () => new Dictionary<string,TransactRequest>(),MeshRequestUser._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequestUser._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Response to an upload request. 
	/// </summary>
public partial class TransactResponse : MeshResponse {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Bitmask")]
	public virtual byte[]?					Bitmask  {get; set;} //

    /// <summary>
    ///The responses to the entries.
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<EntryResponse>?					Entries  {get; set;}
    /// <summary>
    ///If the upload request contains redacted entries, specifies constraints 
    ///that apply to the redacted entries as a group. Thus the total payloads
    ///of all the messages must not exceed the specified value.
    /// </summary>

	[JsonPropertyName("ConstraintsData")]
	public virtual ConstraintsData?					ConstraintsData  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyBinary ("Bitmask", 
					(IBinding data, byte[]? value) => {(data as TransactResponse).Bitmask = value;}, 
					(IBinding data) => (data as TransactResponse).Bitmask ),
		new PropertyListStruct ("Entries", typeof (EntryResponse),
					(IBinding data, object? value) => {(data as TransactResponse).Entries = value as List<EntryResponse>;}, 
					(IBinding data) => (data as TransactResponse).Entries,
					false, ()=>new  List<EntryResponse>(), ()=>new EntryResponse()),
		new PropertyStruct ("ConstraintsData", typeof (ConstraintsData),
					(IBinding data, object? value) => {(data as TransactResponse).ConstraintsData = value as ConstraintsData;}, 
					(IBinding data) => (data as TransactResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TransactResponse> _binding = new (
			new() {

			{ "Bitmask", _properties [0]},
			{ "Entries", _properties [1]},
			{ "ConstraintsData", _properties [2]}
        }, __Tag,() => new TransactResponse(), () => new List<TransactResponse>(), () => new Dictionary<string,TransactResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class EntryResponse : MeshProtocol {
    /// <summary>
    ///The index value of the entry in the request.
    /// </summary>

	[JsonPropertyName("IndexRequest")]
	public virtual long?					IndexRequest  {get; set;} //

    /// <summary>
    ///The index value assigned to the entry in the container.
    /// </summary>

	[JsonPropertyName("IndexContainer")]
	public virtual long?					IndexContainer  {get; set;} //

    /// <summary>
    ///Specifies the result of attempting to add the entry to a catalog
    ///or spool. Valid values for a message are 'Accept', 'Reject'. Valid 
    ///values for an entry are 'Accept', 'Reject' and 'Conflict'.
    /// </summary>

	[JsonPropertyName("Result")]
	public virtual string?					Result  {get; set;} //

    /// <summary>
    ///If the entry was redacted, specifies constraints 
    ///that apply to the redacted entries as a group. Thus the total payloads
    ///of all the messages must not exceed the specified value.	
    /// </summary>

	[JsonPropertyName("ConstraintsData")]
	public virtual ConstraintsData?					ConstraintsData  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyInteger64 ("IndexRequest", 
					(IBinding data, long? value) => {(data as EntryResponse).IndexRequest = value;}, 
					(IBinding data) => (data as EntryResponse).IndexRequest ),
		new PropertyInteger64 ("IndexContainer", 
					(IBinding data, long? value) => {(data as EntryResponse).IndexContainer = value;}, 
					(IBinding data) => (data as EntryResponse).IndexContainer ),
		new PropertyString ("Result", 
					(IBinding data, string? value) => {(data as EntryResponse).Result = value;}, 
					(IBinding data) => (data as EntryResponse).Result ),
		new PropertyStruct ("ConstraintsData", typeof (ConstraintsData),
					(IBinding data, object? value) => {(data as EntryResponse).ConstraintsData = value as ConstraintsData;}, 
					(IBinding data) => (data as EntryResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EntryResponse> _binding = new (
			new() {

			{ "IndexRequest", _properties [0]},
			{ "IndexContainer", _properties [1]},
			{ "Result", _properties [2]},
			{ "ConstraintsData", _properties [3]}
        }, __Tag,() => new EntryResponse(), () => new List<EntryResponse>(), () => new Dictionary<string,EntryResponse>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// Request download from a public store (which may be encrypted).
	/// </summary>
public partial class PublicRequest : DownloadRequest {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicRequest> _binding = new (
			new() {

        }, __Tag,() => new PublicRequest(), () => new List<PublicRequest>(), () => new Dictionary<string,PublicRequest>(),DownloadRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(DownloadRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// 
	/// </summary>
public partial class PostRequest : MeshRequest {
    /// <summary>
    ///The account(s) to which the request is directed.
    /// </summary>

	[JsonPropertyName("Accounts")]
	public virtual List<string>?					Accounts  {get; set;}
    /// <summary>
    ///The messages to be sent to the addresses specified in Accounts. 
    /// </summary>

	[JsonPropertyName("Messages")]
	public virtual List<Enveloped<Message>>?					Messages  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyListString ("Accounts", 
					(IBinding data, List<string>? value) => {(data as PostRequest).Accounts = value;}, 
					(IBinding data) => (data as PostRequest).Accounts ),
		new PropertyListStruct ("Messages", typeof (Enveloped<Message>),
					(IBinding data, object? value) => {(data as PostRequest).Messages = value as List<Enveloped<Message>>;}, 
					(IBinding data) => (data as PostRequest).Messages,
					false, ()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PostRequest> _binding = new (
			new() {

			{ "Accounts", _properties [0]},
			{ "Messages", _properties [1]}
        }, __Tag,() => new PostRequest(), () => new List<PostRequest>(), () => new Dictionary<string,PostRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	///
	/// 
	/// </summary>
public partial class PostResponse : TransactResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PostResponse> _binding = new (
			new() {

        }, __Tag,() => new PostResponse(), () => new List<PostResponse>(), () => new Dictionary<string,PostResponse>(),TransactResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(TransactResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class ClaimRequest : MeshRequest {
    /// <summary>
    ///The claim message
    /// </summary>

	[JsonPropertyName("EnvelopedMessageClaim")]
	public virtual Enveloped<MessageClaim>?					EnvelopedMessageClaim  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("EnvelopedMessageClaim", typeof (Enveloped<MessageClaim>),
					(IBinding data, object? value) => {(data as ClaimRequest).EnvelopedMessageClaim = value as Enveloped<MessageClaim>;}, 
					(IBinding data) => (data as ClaimRequest).EnvelopedMessageClaim,
					false, ()=>new  Enveloped<MessageClaim>(), ()=>new Enveloped<MessageClaim>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClaimRequest> _binding = new (
			new() {

			{ "EnvelopedMessageClaim", _properties [0]}
        }, __Tag,() => new ClaimRequest(), () => new List<ClaimRequest>(), () => new Dictionary<string,ClaimRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class ClaimResponse : MeshResponse {
    /// <summary>
    ///The encrypted device profile
    /// </summary>

	[JsonPropertyName("CatalogedPublication")]
	public virtual CatalogedPublication?					CatalogedPublication  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("CatalogedPublication", typeof (CatalogedPublication),
					(IBinding data, object? value) => {(data as ClaimResponse).CatalogedPublication = value as CatalogedPublication;}, 
					(IBinding data) => (data as ClaimResponse).CatalogedPublication,
					false, ()=>new  CatalogedPublication(), ()=>new CatalogedPublication())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClaimResponse> _binding = new (
			new() {

			{ "CatalogedPublication", _properties [0]}
        }, __Tag,() => new ClaimResponse(), () => new List<ClaimResponse>(), () => new Dictionary<string,ClaimResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class PollClaimRequest : MeshRequest {
    /// <summary>
    ///The envelope identifier formed from the PublicationId.
    /// </summary>

	[JsonPropertyName("PublicationId")]
	public virtual string?					PublicationId  {get; set;} //

    /// <summary>
    ///Account to which the claim is directed
    /// </summary>

	[JsonPropertyName("TargetAccountAddress")]
	public virtual string?					TargetAccountAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as PollClaimRequest).PublicationId = value;}, 
					(IBinding data) => (data as PollClaimRequest).PublicationId ),
		new PropertyString ("TargetAccountAddress", 
					(IBinding data, string? value) => {(data as PollClaimRequest).TargetAccountAddress = value;}, 
					(IBinding data) => (data as PollClaimRequest).TargetAccountAddress )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PollClaimRequest> _binding = new (
			new() {

			{ "PublicationId", _properties [0]},
			{ "TargetAccountAddress", _properties [1]}
        }, __Tag,() => new PollClaimRequest(), () => new List<PollClaimRequest>(), () => new Dictionary<string,PollClaimRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class PollClaimResponse : MeshResponse {
    /// <summary>
    ///The claim message
    /// </summary>

	[JsonPropertyName("EnvelopedMessage")]
	public virtual Enveloped<Message>?					EnvelopedMessage  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("EnvelopedMessage", typeof (Enveloped<Message>),
					(IBinding data, object? value) => {(data as PollClaimResponse).EnvelopedMessage = value as Enveloped<Message>;}, 
					(IBinding data) => (data as PollClaimResponse).EnvelopedMessage,
					false, ()=>new  Enveloped<Message>(), ()=>new Enveloped<Message>())		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PollClaimResponse> _binding = new (
			new() {

			{ "EnvelopedMessage", _properties [0]}
        }, __Tag,() => new PollClaimResponse(), () => new List<PollClaimResponse>(), () => new Dictionary<string,PollClaimResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
abstract public partial class CryptographicOperation : MeshProtocol {
    /// <summary>
    ///The key identifier			
    /// </summary>

	[JsonPropertyName("KeyId")]
	public virtual string?					KeyId  {get; set;} //

    /// <summary>
    ///Lagrange coefficient multiplier to be applied to the private key
    /// </summary>

	[JsonPropertyName("KeyCoefficient")]
	public virtual byte[]?					KeyCoefficient  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("KeyId", 
					(IBinding data, string? value) => {(data as CryptographicOperation).KeyId = value;}, 
					(IBinding data) => (data as CryptographicOperation).KeyId ),
		new PropertyBinary ("KeyCoefficient", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperation).KeyCoefficient = value;}, 
					(IBinding data) => (data as CryptographicOperation).KeyCoefficient )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperation> _binding = new (
			new() {

			{ "KeyId", _properties [0]},
			{ "KeyCoefficient", _properties [1]}
        }, __Tag,null, null, null,null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicOperationSign : CryptographicOperation {
    /// <summary>
    ///The data to sign
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //

    /// <summary>
    ///Contribution to the R offset.
    /// </summary>

	[JsonPropertyName("PartialR")]
	public virtual byte[]?					PartialR  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperationSign).Data = value;}, 
					(IBinding data) => (data as CryptographicOperationSign).Data ),
		new PropertyBinary ("PartialR", 
					(IBinding data, byte[]? value) => {(data as CryptographicOperationSign).PartialR = value;}, 
					(IBinding data) => (data as CryptographicOperationSign).PartialR )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationSign> _binding = new (
			new() {

			{ "Data", _properties [0]},
			{ "PartialR", _properties [1]}
        }, __Tag,() => new CryptographicOperationSign(), () => new List<CryptographicOperationSign>(), () => new Dictionary<string,CryptographicOperationSign>(),CryptographicOperation._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicOperation._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicOperationKeyAgreement : CryptographicOperation {
    /// <summary>
    ///The public key value to perform the agreement on.
    /// </summary>

	[JsonPropertyName("PublicKey")]
	public virtual Key?					PublicKey  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("PublicKey", typeof (Key), 
					(IBinding data, object? value) => {(data as CryptographicOperationKeyAgreement).PublicKey = value as Key;}, 
					(IBinding data) => (data as CryptographicOperationKeyAgreement).PublicKey,
					true) 		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationKeyAgreement> _binding = new (
			new() {

			{ "PublicKey", _properties [0]}
        }, __Tag,() => new CryptographicOperationKeyAgreement(), () => new List<CryptographicOperationKeyAgreement>(), () => new Dictionary<string,CryptographicOperationKeyAgreement>(),CryptographicOperation._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicOperation._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicOperationGenerate : CryptographicOperation {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationGenerate> _binding = new (
			new() {

        }, __Tag,() => new CryptographicOperationGenerate(), () => new List<CryptographicOperationGenerate>(), () => new Dictionary<string,CryptographicOperationGenerate>(),CryptographicOperation._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicOperation._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicOperationShare : CryptographicOperation {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Threshold")]
	public virtual int?					Threshold  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Shares")]
	public virtual int?					Shares  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyInteger32 ("Threshold", 
					(IBinding data, int? value) => {(data as CryptographicOperationShare).Threshold = value;}, 
					(IBinding data) => (data as CryptographicOperationShare).Threshold ),
		new PropertyInteger32 ("Shares", 
					(IBinding data, int? value) => {(data as CryptographicOperationShare).Shares = value;}, 
					(IBinding data) => (data as CryptographicOperationShare).Shares )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationShare> _binding = new (
			new() {

			{ "Threshold", _properties [0]},
			{ "Shares", _properties [1]}
        }, __Tag,() => new CryptographicOperationShare(), () => new List<CryptographicOperationShare>(), () => new Dictionary<string,CryptographicOperationShare>(),CryptographicOperation._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicOperation._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicResult : MeshProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Error")]
	public virtual string?					Error  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("Error", 
					(IBinding data, string? value) => {(data as CryptographicResult).Error = value;}, 
					(IBinding data) => (data as CryptographicResult).Error )		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicResult> _binding = new (
			new() {

			{ "Error", _properties [0]}
        }, __Tag,() => new CryptographicResult(), () => new List<CryptographicResult>(), () => new Dictionary<string,CryptographicResult>(),null);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicResultKeyAgreement : CryptographicResult {
    /// <summary>
    /// </summary>

	[JsonPropertyName("KeyAgreement")]
	public virtual KeyAgreement?					KeyAgreement  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyStruct ("KeyAgreement", typeof (KeyAgreement), 
					(IBinding data, object? value) => {(data as CryptographicResultKeyAgreement).KeyAgreement = value as KeyAgreement;}, 
					(IBinding data) => (data as CryptographicResultKeyAgreement).KeyAgreement,
					true) 		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicResultKeyAgreement> _binding = new (
			new() {

			{ "KeyAgreement", _properties [0]}
        }, __Tag,() => new CryptographicResultKeyAgreement(), () => new List<CryptographicResultKeyAgreement>(), () => new Dictionary<string,CryptographicResultKeyAgreement>(),CryptographicResult._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicResult._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class CryptographicResultShare : CryptographicResult {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicResultShare> _binding = new (
			new() {

        }, __Tag,() => new CryptographicResultShare(), () => new List<CryptographicResultShare>(), () => new Dictionary<string,CryptographicResultShare>(),CryptographicResult._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicResult._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class OperateRequest : MeshRequest {
    /// <summary>
    ///The service account the capability is bound to
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Operations")]
	public virtual List<CryptographicOperation>?					Operations  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as OperateRequest).AccountAddress = value;}, 
					(IBinding data) => (data as OperateRequest).AccountAddress ),
		new PropertyListStruct ("Operations", typeof (CryptographicOperation), 
					(IBinding data, object? value) => {(data as OperateRequest).Operations = value as List<CryptographicOperation>;}, 
					(IBinding data) => (data as OperateRequest).Operations,
					true, ()=>new List<CryptographicOperation>()
) 		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OperateRequest> _binding = new (
			new() {

			{ "AccountAddress", _properties [0]},
			{ "Operations", _properties [1]}
        }, __Tag,() => new OperateRequest(), () => new List<OperateRequest>(), () => new Dictionary<string,OperateRequest>(),MeshRequest._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshRequest._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}


	/// <summary>
	/// </summary>
public partial class OperateResponse : MeshResponse {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Results")]
	public virtual List<CryptographicResult>?					Results  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [

		new PropertyListStruct ("Results", typeof (CryptographicResult), 
					(IBinding data, object? value) => {(data as OperateResponse).Results = value as List<CryptographicResult>;}, 
					(IBinding data) => (data as OperateResponse).Results,
					true, ()=>new List<CryptographicResult>()
) 		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OperateResponse> _binding = new (
			new() {

			{ "Results", _properties [0]}
        }, __Tag,() => new OperateResponse(), () => new List<OperateResponse>(), () => new Dictionary<string,OperateResponse>(),MeshResponse._binding);
	/*
    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MeshResponse._binding, _binding);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;

	*/

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

	}



