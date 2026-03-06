
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
//  This file was automatically generated at 3/6/2026 6:19:54 PM
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
	    {typeof(OperateResponse), OperateResponse._binding},
	    {typeof(PublishEarlRequest), PublishEarlRequest._binding},
	    {typeof(PublishEarlResponse), PublishEarlResponse._binding},
	    {typeof(DeleteEarlRequest), DeleteEarlRequest._binding},
	    {typeof(DeleteEarlResponse), DeleteEarlResponse._binding},
	    {typeof(PublishDnsRequest), PublishDnsRequest._binding},
	    {typeof(DnsUpdate), DnsUpdate._binding},
	    {typeof(PublishDnsResponse), PublishDnsResponse._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static MeshProtocol() {
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
				{"Operate", typeof(OperateRequest)},
				{"PublishEarl", typeof(PublishEarlRequest)},
				{"DeleteEarl", typeof(DeleteEarlRequest)},
				{"PublishDns", typeof(PublishDnsRequest)}
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
		"PublishEarl" => PublishEarl(request as PublishEarlRequest, session),
		"DeleteEarl" => DeleteEarl(request as DeleteEarlRequest, session),
		"PublishDns" => PublishDns(request as PublishDnsRequest, session),
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

    /// <summary>
	/// Base method for implementing the transaction PublishEarl.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract PublishEarlResponse PublishEarl (
            PublishEarlRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction DeleteEarl.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract DeleteEarlResponse DeleteEarl (
            DeleteEarlRequest request, IJpcSession session);

    /// <summary>
	/// Base method for implementing the transaction PublishDns.
    /// </summary>
    /// <param name="request">The request object to send to the host.</param>
	/// <param name="session">The request context.</param>
	/// <returns>The response object from the service</returns>
    public abstract PublishDnsResponse PublishDns (
            PublishDnsRequest request, IJpcSession session);

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

    /// <summary>
	/// Implement the transaction PublishEarl.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public PublishEarlResponse PublishEarl (PublishEarlRequest request) =>
			PublishEarlAsync (request).Sync();

    /// <summary>
	/// Implement the transaction PublishEarl asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<PublishEarlResponse> PublishEarlAsync (PublishEarlRequest request) =>
			await JpcSession.PostAsync("PublishEarl", request) as PublishEarlResponse;

    /// <summary>
	/// Implement the transaction DeleteEarl.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public DeleteEarlResponse DeleteEarl (DeleteEarlRequest request) =>
			DeleteEarlAsync (request).Sync();

    /// <summary>
	/// Implement the transaction DeleteEarl asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<DeleteEarlResponse> DeleteEarlAsync (DeleteEarlRequest request) =>
			await JpcSession.PostAsync("DeleteEarl", request) as DeleteEarlResponse;

    /// <summary>
	/// Implement the transaction PublishDns.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public PublishDnsResponse PublishDns (PublishDnsRequest request) =>
			PublishDnsAsync (request).Sync();

    /// <summary>
	/// Implement the transaction PublishDns asynchronously.
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public virtual async Task<PublishDnsResponse> PublishDnsAsync (PublishDnsRequest request) =>
			await JpcSession.PostAsync("PublishDns", request) as PublishDnsResponse;


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


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<PublishEarlResponse> PublishEarlAsync (PublishEarlRequest request) =>
			Task.FromResult(Service.PublishEarl (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<DeleteEarlResponse> DeleteEarlAsync (DeleteEarlRequest request) =>
			Task.FromResult(Service.DeleteEarl (request, JpcSession));


    /// <summary>
	/// Implement the transaction
    /// </summary>		
    /// <param name="request">The request object.</param>
	/// <returns>The response object</returns>
    public override Task<PublishDnsResponse> PublishDnsAsync (PublishDnsRequest request) =>
			Task.FromResult(Service.PublishDns (request, JpcSession));


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
			new() {}, __Tag,
		() => new MeshRequest(), () => [], () => [], Goedel.Protocol.Request._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileDevice?				ProfileDevice  => EnvelopedProfileDevice.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Account", 
					(data, value) => {(data as MeshRequestUser).Account = value;}, 
					data => (data as MeshRequestUser).Account ),
		new PropertyString ("Capability", 
					(data, value) => {(data as MeshRequestUser).Capability = value;}, 
					data => (data as MeshRequestUser).Capability ),
		new PropertyGStruct ("EnvelopedProfileDevice", typeof (Enveloped),
					(data, value) => {(data as MeshRequestUser).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;},
					data => (data as MeshRequestUser).EnvelopedProfileDevice,
					()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshRequestUser> _binding = new (
			new() {
			{ "Account", _properties [0]},
			{ "Capability", _properties [1]},
			{ "EnvelopedProfileDevice", _properties [2]}}, __Tag,
		() => new MeshRequestUser(), () => [], () => [], MeshRequest._binding, Generic: false);


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
			new() {}, __Tag,
		() => new MeshResponse(), () => [], () => [], Goedel.Protocol.Response._binding, Generic: false);


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
					(data, value) => {(data as KeyValue).Key = value;}, 
					data => (data as KeyValue).Key ),
		new PropertyString ("Value", 
					(data, value) => {(data as KeyValue).Value = value;}, 
					data => (data as KeyValue).Value )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyValue> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Value", _properties [1]}}, __Tag,
		() => new KeyValue(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as ConstraintsSelect).Store = value;}, 
					data => (data as ConstraintsSelect).Store ),
		new PropertyInteger64 ("IndexMin", 
					(data, value) => {(data as ConstraintsSelect).IndexMin = value;}, 
					data => (data as ConstraintsSelect).IndexMin ),
		new PropertyInteger64 ("IndexMax", 
					(data, value) => {(data as ConstraintsSelect).IndexMax = value;}, 
					data => (data as ConstraintsSelect).IndexMax ),
		new PropertyDateTime ("NotBefore", 
					(data, value) => {(data as ConstraintsSelect).NotBefore = value;}, 
					data => (data as ConstraintsSelect).NotBefore ),
		new PropertyDateTime ("Before", 
					(data, value) => {(data as ConstraintsSelect).Before = value;}, 
					data => (data as ConstraintsSelect).Before ),
		new PropertyString ("PageKey", 
					(data, value) => {(data as ConstraintsSelect).PageKey = value;}, 
					data => (data as ConstraintsSelect).PageKey )
		];

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
			{ "PageKey", _properties [5]}}, __Tag,
		() => new ConstraintsSelect(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as ConstraintsData).MaxEntries = value;}, 
					data => (data as ConstraintsData).MaxEntries ),
		new PropertyInteger64 ("BytesOffset", 
					(data, value) => {(data as ConstraintsData).BytesOffset = value;}, 
					data => (data as ConstraintsData).BytesOffset ),
		new PropertyInteger64 ("BytesMax", 
					(data, value) => {(data as ConstraintsData).BytesMax = value;}, 
					data => (data as ConstraintsData).BytesMax ),
		new PropertyBoolean ("Header", 
					(data, value) => {(data as ConstraintsData).Header = value;}, 
					data => (data as ConstraintsData).Header ),
		new PropertyBoolean ("Payload", 
					(data, value) => {(data as ConstraintsData).Payload = value;}, 
					data => (data as ConstraintsData).Payload ),
		new PropertyBoolean ("Trailer", 
					(data, value) => {(data as ConstraintsData).Trailer = value;}, 
					data => (data as ConstraintsData).Trailer )
		];

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
			{ "Trailer", _properties [5]}}, __Tag,
		() => new ConstraintsData(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as PolicyAccount).Minimum = value;}, 
					data => (data as PolicyAccount).Minimum ),
		new PropertyInteger32 ("Maximum", 
					(data, value) => {(data as PolicyAccount).Maximum = value;}, 
					data => (data as PolicyAccount).Maximum ),
		new PropertyString ("InvalidCharacters", 
					(data, value) => {(data as PolicyAccount).InvalidCharacters = value;}, 
					data => (data as PolicyAccount).InvalidCharacters )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PolicyAccount> _binding = new (
			new() {
			{ "Minimum", _properties [0]},
			{ "Maximum", _properties [1]},
			{ "InvalidCharacters", _properties [2]}}, __Tag,
		() => new PolicyAccount(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as StoreStatus).Store = value;}, 
					data => (data as StoreStatus).Store ),
		new PropertyInteger64 ("Index", 
					(data, value) => {(data as StoreStatus).Index = value;}, 
					data => (data as StoreStatus).Index ),
		new PropertyBinary ("Digest", 
					(data, value) => {(data as StoreStatus).Digest = value;}, 
					data => (data as StoreStatus).Digest )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StoreStatus> _binding = new (
			new() {
			{ "Store", _properties [0]},
			{ "Index", _properties [1]},
			{ "Digest", _properties [2]}}, __Tag,
		() => new StoreStatus(), () => [], () => [], null, Generic: false);


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
	public virtual List<Enveloped>?					Envelopes  {get; set;}
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
		new PropertyListStruct ("Envelopes", typeof (Enveloped),
					(data, value) => {(data as StoreUpdate).Envelopes = value as List<Enveloped>;}, 
					data => (data as StoreUpdate).Envelopes,
					false, ()=>new  List<Enveloped>(), ()=>new Enveloped()),
		new PropertyBoolean ("Partial", 
					(data, value) => {(data as StoreUpdate).Partial = value;}, 
					data => (data as StoreUpdate).Partial ),
		new PropertyInteger64 ("FinalIndex", 
					(data, value) => {(data as StoreUpdate).FinalIndex = value;}, 
					data => (data as StoreUpdate).FinalIndex )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<StoreUpdate> _binding = new (
			new() {
			{ "Envelopes", _properties [0]},
			{ "Partial", _properties [1]},
			{ "FinalIndex", _properties [2]}}, __Tag,
		() => new StoreUpdate(), () => [], () => [], StoreStatus._binding, Generic: false);


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
					(data, value) => {(data as MeshHelloRequest).CallsignBinding = value as CallsignBinding;}, 
					data => (data as MeshHelloRequest).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshHelloRequest> _binding = new (
			new() {
			{ "CallsignBinding", _properties [0]}}, __Tag,
		() => new MeshHelloRequest(), () => [], () => [], Goedel.Protocol.HelloRequest._binding, Generic: false);


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

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileService")]
	public virtual Enveloped<ProfileService>?					EnvelopedProfileService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileService?				ProfileService  => EnvelopedProfileService.Decode();
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
					(data, value) => {(data as MeshHelloResponse).ConstraintsUpdate = value as ConstraintsData;}, 
					data => (data as MeshHelloResponse).ConstraintsUpdate,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData()),
		new PropertyStruct ("ConstraintsPost", typeof (ConstraintsData),
					(data, value) => {(data as MeshHelloResponse).ConstraintsPost = value as ConstraintsData;}, 
					data => (data as MeshHelloResponse).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData()),
		new PropertyStruct ("PolicyAccount", typeof (PolicyAccount),
					(data, value) => {(data as MeshHelloResponse).PolicyAccount = value as PolicyAccount;}, 
					data => (data as MeshHelloResponse).PolicyAccount,
					false, ()=>new  PolicyAccount(), ()=>new PolicyAccount()),
		new PropertyGStruct ("EnvelopedProfileService", typeof (Enveloped),
					(data, value) => {(data as MeshHelloResponse).EnvelopedProfileService = value as Enveloped<ProfileService>;},
					data => (data as MeshHelloResponse).EnvelopedProfileService,
					()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>()),
		new PropertyStruct ("CallsignBinding", typeof (CallsignBinding),
					(data, value) => {(data as MeshHelloResponse).CallsignBinding = value as CallsignBinding;}, 
					data => (data as MeshHelloResponse).CallsignBinding,
					false, ()=>new  CallsignBinding(), ()=>new CallsignBinding())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshHelloResponse> _binding = new (
			new() {
			{ "ConstraintsUpdate", _properties [0]},
			{ "ConstraintsPost", _properties [1]},
			{ "PolicyAccount", _properties [2]},
			{ "EnvelopedProfileService", _properties [3]},
			{ "CallsignBinding", _properties [4]}}, __Tag,
		() => new MeshHelloResponse(), () => [], () => [], Goedel.Protocol.HelloResponse._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAccount?				ProfileAccount  => EnvelopedProfileAccount.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedCallsignBinding")]
	public virtual List<Enveloped<CallsignBinding>>?					EnvelopedCallsignBinding  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<CallsignBinding>?				CallsignBinding  => EnvelopedCallsignBinding.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as BindRequest).AccountAddress = value;}, 
					data => (data as BindRequest).AccountAddress ),
		new PropertyGStruct ("EnvelopedProfileAccount", typeof (Enveloped),
					(data, value) => {(data as BindRequest).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;},
					data => (data as BindRequest).EnvelopedProfileAccount,
					()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyListGStruct ("EnvelopedCallsignBinding", typeof (Enveloped),
					(data, value) => {(data as BindRequest).EnvelopedCallsignBinding = value as List<Enveloped<CallsignBinding>>;},
					data => (data as BindRequest).EnvelopedCallsignBinding,
					()=>new  List<Enveloped<CallsignBinding>>(), ()=>new Enveloped<CallsignBinding>(),
					(list,item)=>(list as List<Enveloped<CallsignBinding>>).Add (item as Enveloped<CallsignBinding>)
)
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<BindRequest> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "EnvelopedProfileAccount", _properties [1]},
			{ "EnvelopedCallsignBinding", _properties [2]}}, __Tag,
		() => new BindRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
		new PropertyString ("Reason", 
					(data, value) => {(data as BindResponse).Reason = value;}, 
					data => (data as BindResponse).Reason ),
		new PropertyString ("URL", 
					(data, value) => {(data as BindResponse).URL = value;}, 
					data => (data as BindResponse).URL ),
		new PropertyGStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped),
					(data, value) => {(data as BindResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;},
					data => (data as BindResponse).EnvelopedAccountHostAssignment,
					()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<BindResponse> _binding = new (
			new() {
			{ "Reason", _properties [0]},
			{ "URL", _properties [1]},
			{ "EnvelopedAccountHostAssignment", _properties [2]}}, __Tag,
		() => new BindResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
			new() {}, __Tag,
		() => new UnbindRequest(), () => [], () => [], MeshRequestUser._binding, Generic: false);


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
			new() {}, __Tag,
		() => new UnbindResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedRequestConnection")]
	public virtual Enveloped<RequestConnection>?					EnvelopedRequestConnection  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual RequestConnection?				RequestConnection  => EnvelopedRequestConnection.Decode();
    /// <summary>
    ///List of named access rights.
    /// </summary>

	[JsonPropertyName("Rights")]
	public virtual List<string>?					Rights  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedRequestConnection", typeof (Enveloped),
					(data, value) => {(data as ConnectRequest).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;},
					data => (data as ConnectRequest).EnvelopedRequestConnection,
					()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>()),
		new PropertyListString ("Rights", 
					(data, value) => {(data as ConnectRequest).Rights = value;}, 
					data => (data as ConnectRequest).Rights )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectRequest> _binding = new (
			new() {
			{ "EnvelopedRequestConnection", _properties [0]},
			{ "Rights", _properties [1]}}, __Tag,
		() => new ConnectRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedAcknowledgeConnection")]
	public virtual Enveloped<AcknowledgeConnection>?					EnvelopedAcknowledgeConnection  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual AcknowledgeConnection?				AcknowledgeConnection  => EnvelopedAcknowledgeConnection.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAccount?				ProfileAccount  => EnvelopedProfileAccount.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedAcknowledgeConnection", typeof (Enveloped),
					(data, value) => {(data as ConnectResponse).EnvelopedAcknowledgeConnection = value as Enveloped<AcknowledgeConnection>;},
					data => (data as ConnectResponse).EnvelopedAcknowledgeConnection,
					()=>new  Enveloped<AcknowledgeConnection>(), ()=>new Enveloped<AcknowledgeConnection>()),
		new PropertyGStruct ("EnvelopedProfileAccount", typeof (Enveloped),
					(data, value) => {(data as ConnectResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;},
					data => (data as ConnectResponse).EnvelopedProfileAccount,
					()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectResponse> _binding = new (
			new() {
			{ "EnvelopedAcknowledgeConnection", _properties [0]},
			{ "EnvelopedProfileAccount", _properties [1]}}, __Tag,
		() => new ConnectResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as CompleteRequest).AccountAddress = value;}, 
					data => (data as CompleteRequest).AccountAddress ),
		new PropertyString ("ResponseID", 
					(data, value) => {(data as CompleteRequest).ResponseID = value;}, 
					data => (data as CompleteRequest).ResponseID )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompleteRequest> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "ResponseID", _properties [1]}}, __Tag,
		() => new CompleteRequest(), () => [], () => [], StatusRequest._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedRespondConnection")]
	public virtual Enveloped<RespondConnection>?					EnvelopedRespondConnection  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual RespondConnection?				RespondConnection  => EnvelopedRespondConnection.Decode();
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
		new PropertyGStruct ("EnvelopedRespondConnection", typeof (Enveloped),
					(data, value) => {(data as CompleteResponse).EnvelopedRespondConnection = value as Enveloped<RespondConnection>;},
					data => (data as CompleteResponse).EnvelopedRespondConnection,
					()=>new  Enveloped<RespondConnection>(), ()=>new Enveloped<RespondConnection>()),
		new PropertyGStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped),
					(data, value) => {(data as CompleteResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;},
					data => (data as CompleteResponse).EnvelopedAccountHostAssignment,
					()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompleteResponse> _binding = new (
			new() {
			{ "EnvelopedRespondConnection", _properties [0]},
			{ "EnvelopedAccountHostAssignment", _properties [1]}}, __Tag,
		() => new CompleteResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as StatusRequest).DeviceUDF = value;}, 
					data => (data as StatusRequest).DeviceUDF ),
		new PropertyString ("CatalogedDeviceDigest", 
					(data, value) => {(data as StatusRequest).CatalogedDeviceDigest = value;}, 
					data => (data as StatusRequest).CatalogedDeviceDigest ),
		new PropertyListString ("Catalogs", 
					(data, value) => {(data as StatusRequest).Catalogs = value;}, 
					data => (data as StatusRequest).Catalogs ),
		new PropertyListString ("Spools", 
					(data, value) => {(data as StatusRequest).Spools = value;}, 
					data => (data as StatusRequest).Spools ),
		new PropertyListString ("Services", 
					(data, value) => {(data as StatusRequest).Services = value;}, 
					data => (data as StatusRequest).Services ),
		new PropertyBoolean ("DeviceStatus", 
					(data, value) => {(data as StatusRequest).DeviceStatus = value;}, 
					data => (data as StatusRequest).DeviceStatus )
		];

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
			{ "DeviceStatus", _properties [5]}}, __Tag,
		() => new StatusRequest(), () => [], () => [], MeshRequestUser._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileAccount")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileAccount  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileAccount?				ProfileAccount  => EnvelopedProfileAccount.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual CatalogedDevice?				CatalogedDevice  => EnvelopedCatalogedDevice.Decode();
    /// <summary>
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("StoreStatus")]
	public virtual List<StoreStatus>?					StoreStatus  {get; set;}
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedAccountHostAssignment")]
	public virtual Enveloped<AccountHostAssignment>?					EnvelopedAccountHostAssignment  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual AccountHostAssignment?				AccountHostAssignment  => EnvelopedAccountHostAssignment.Decode();
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
					(data, value) => {(data as StatusResponse).Bitmask = value;}, 
					data => (data as StatusResponse).Bitmask ),
		new PropertyGStruct ("EnvelopedProfileAccount", typeof (Enveloped),
					(data, value) => {(data as StatusResponse).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;},
					data => (data as StatusResponse).EnvelopedProfileAccount,
					()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>()),
		new PropertyGStruct ("EnvelopedCatalogedDevice", typeof (Enveloped),
					(data, value) => {(data as StatusResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;},
					data => (data as StatusResponse).EnvelopedCatalogedDevice,
					()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>()),
		new PropertyString ("CatalogedDeviceDigest", 
					(data, value) => {(data as StatusResponse).CatalogedDeviceDigest = value;}, 
					data => (data as StatusResponse).CatalogedDeviceDigest ),
		new PropertyListStruct ("StoreStatus", typeof (StoreStatus),
					(data, value) => {(data as StatusResponse).StoreStatus = value as List<StoreStatus>;}, 
					data => (data as StatusResponse).StoreStatus,
					false, ()=>new  List<StoreStatus>(), ()=>new StoreStatus()),
		new PropertyGStruct ("EnvelopedAccountHostAssignment", typeof (Enveloped),
					(data, value) => {(data as StatusResponse).EnvelopedAccountHostAssignment = value as Enveloped<AccountHostAssignment>;},
					data => (data as StatusResponse).EnvelopedAccountHostAssignment,
					()=>new  Enveloped<AccountHostAssignment>(), ()=>new Enveloped<AccountHostAssignment>()),
		new PropertyListStruct ("Services", typeof (ServiceAccessToken),
					(data, value) => {(data as StatusResponse).Services = value as List<ServiceAccessToken>;}, 
					data => (data as StatusResponse).Services,
					false, ()=>new  List<ServiceAccessToken>(), ()=>new ServiceAccessToken()),
		new PropertyListStruct ("DeviceStatuses", typeof (DeviceStatus),
					(data, value) => {(data as StatusResponse).DeviceStatuses = value as List<DeviceStatus>;}, 
					data => (data as StatusResponse).DeviceStatuses,
					false, ()=>new  List<DeviceStatus>(), ()=>new DeviceStatus())
		];

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
			{ "DeviceStatuses", _properties [7]}}, __Tag,
		() => new StatusResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as DeviceStatus).Id = value;}, 
					data => (data as DeviceStatus).Id ),
		new PropertyString ("Status", 
					(data, value) => {(data as DeviceStatus).Status = value;}, 
					data => (data as DeviceStatus).Status ),
		new PropertyString ("Comment", 
					(data, value) => {(data as DeviceStatus).Comment = value;}, 
					data => (data as DeviceStatus).Comment ),
		new PropertyDateTime ("LastConnected", 
					(data, value) => {(data as DeviceStatus).LastConnected = value;}, 
					data => (data as DeviceStatus).LastConnected )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceStatus> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Status", _properties [1]},
			{ "Comment", _properties [2]},
			{ "LastConnected", _properties [3]}}, __Tag,
		() => new DeviceStatus(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as DownloadRequest).MaxResults = value;}, 
					data => (data as DownloadRequest).MaxResults ),
		new PropertyString ("DeviceUDF", 
					(data, value) => {(data as DownloadRequest).DeviceUDF = value;}, 
					data => (data as DownloadRequest).DeviceUDF ),
		new PropertyString ("CatalogedDeviceDigest", 
					(data, value) => {(data as DownloadRequest).CatalogedDeviceDigest = value;}, 
					data => (data as DownloadRequest).CatalogedDeviceDigest ),
		new PropertyListStruct ("Select", typeof (ConstraintsSelect),
					(data, value) => {(data as DownloadRequest).Select = value as List<ConstraintsSelect>;}, 
					data => (data as DownloadRequest).Select,
					false, ()=>new  List<ConstraintsSelect>(), ()=>new ConstraintsSelect()),
		new PropertyStruct ("ConstraintsPost", typeof (ConstraintsData),
					(data, value) => {(data as DownloadRequest).ConstraintsPost = value as ConstraintsData;}, 
					data => (data as DownloadRequest).ConstraintsPost,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DownloadRequest> _binding = new (
			new() {
			{ "MaxResults", _properties [0]},
			{ "DeviceUDF", _properties [1]},
			{ "CatalogedDeviceDigest", _properties [2]},
			{ "Select", _properties [3]},
			{ "ConstraintsPost", _properties [4]}}, __Tag,
		() => new DownloadRequest(), () => [], () => [], MeshRequestUser._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual CatalogedDevice?				CatalogedDevice  => EnvelopedCatalogedDevice.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Updates", typeof (StoreUpdate),
					(data, value) => {(data as DownloadResponse).Updates = value as List<StoreUpdate>;}, 
					data => (data as DownloadResponse).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate()),
		new PropertyString ("CatalogedDeviceDigest", 
					(data, value) => {(data as DownloadResponse).CatalogedDeviceDigest = value;}, 
					data => (data as DownloadResponse).CatalogedDeviceDigest ),
		new PropertyGStruct ("EnvelopedCatalogedDevice", typeof (Enveloped),
					(data, value) => {(data as DownloadResponse).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;},
					data => (data as DownloadResponse).EnvelopedCatalogedDevice,
					()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DownloadResponse> _binding = new (
			new() {
			{ "Updates", _properties [0]},
			{ "CatalogedDeviceDigest", _properties [1]},
			{ "EnvelopedCatalogedDevice", _properties [2]}}, __Tag,
		() => new DownloadResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as UploadRequest).DocumentId = value;}, 
					data => (data as UploadRequest).DocumentId ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as UploadRequest).Data = value;}, 
					data => (data as UploadRequest).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<UploadRequest> _binding = new (
			new() {
			{ "DocumentId", _properties [0]},
			{ "Data", _properties [1]}}, __Tag,
		() => new UploadRequest(), () => [], () => [], MeshRequestUser._binding, Generic: false);


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
			new() {}, __Tag,
		() => new UploadResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as GetDataRequest).DocumentId = value;}, 
					data => (data as GetDataRequest).DocumentId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GetDataRequest> _binding = new (
			new() {
			{ "DocumentId", _properties [0]}}, __Tag,
		() => new GetDataRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
					(data, value) => {(data as GetDataResponse).Data = value;}, 
					data => (data as GetDataResponse).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GetDataResponse> _binding = new (
			new() {
			{ "Data", _properties [0]}}, __Tag,
		() => new GetDataResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedOutbound")]
	public virtual List<Enveloped<Message>>?					EnvelopedOutbound  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<Message>?				Outbound  => EnvelopedOutbound.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedInbound")]
	public virtual List<Enveloped<Message>>?					EnvelopedInbound  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<Message>?				Inbound  => EnvelopedInbound.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedLocal")]
	public virtual List<Enveloped<Message>>?					EnvelopedLocal  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<Message>?				Local  => EnvelopedLocal.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Updates", typeof (StoreUpdate),
					(data, value) => {(data as TransactRequest).Updates = value as List<StoreUpdate>;}, 
					data => (data as TransactRequest).Updates,
					false, ()=>new  List<StoreUpdate>(), ()=>new StoreUpdate()),
		new PropertyListString ("Accounts", 
					(data, value) => {(data as TransactRequest).Accounts = value;}, 
					data => (data as TransactRequest).Accounts ),
		new PropertyListGStruct ("EnvelopedOutbound", typeof (Enveloped),
					(data, value) => {(data as TransactRequest).EnvelopedOutbound = value as List<Enveloped<Message>>;},
					data => (data as TransactRequest).EnvelopedOutbound,
					()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>(),
					(list,item)=>(list as List<Enveloped<Message>>).Add (item as Enveloped<Message>)
),
		new PropertyListGStruct ("EnvelopedInbound", typeof (Enveloped),
					(data, value) => {(data as TransactRequest).EnvelopedInbound = value as List<Enveloped<Message>>;},
					data => (data as TransactRequest).EnvelopedInbound,
					()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>(),
					(list,item)=>(list as List<Enveloped<Message>>).Add (item as Enveloped<Message>)
),
		new PropertyListGStruct ("EnvelopedLocal", typeof (Enveloped),
					(data, value) => {(data as TransactRequest).EnvelopedLocal = value as List<Enveloped<Message>>;},
					data => (data as TransactRequest).EnvelopedLocal,
					()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>(),
					(list,item)=>(list as List<Enveloped<Message>>).Add (item as Enveloped<Message>)
)
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TransactRequest> _binding = new (
			new() {
			{ "Updates", _properties [0]},
			{ "Accounts", _properties [1]},
			{ "EnvelopedOutbound", _properties [2]},
			{ "EnvelopedInbound", _properties [3]},
			{ "EnvelopedLocal", _properties [4]}}, __Tag,
		() => new TransactRequest(), () => [], () => [], MeshRequestUser._binding, Generic: false);


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
					(data, value) => {(data as TransactResponse).Bitmask = value;}, 
					data => (data as TransactResponse).Bitmask ),
		new PropertyListStruct ("Entries", typeof (EntryResponse),
					(data, value) => {(data as TransactResponse).Entries = value as List<EntryResponse>;}, 
					data => (data as TransactResponse).Entries,
					false, ()=>new  List<EntryResponse>(), ()=>new EntryResponse()),
		new PropertyStruct ("ConstraintsData", typeof (ConstraintsData),
					(data, value) => {(data as TransactResponse).ConstraintsData = value as ConstraintsData;}, 
					data => (data as TransactResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TransactResponse> _binding = new (
			new() {
			{ "Bitmask", _properties [0]},
			{ "Entries", _properties [1]},
			{ "ConstraintsData", _properties [2]}}, __Tag,
		() => new TransactResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as EntryResponse).IndexRequest = value;}, 
					data => (data as EntryResponse).IndexRequest ),
		new PropertyInteger64 ("IndexContainer", 
					(data, value) => {(data as EntryResponse).IndexContainer = value;}, 
					data => (data as EntryResponse).IndexContainer ),
		new PropertyString ("Result", 
					(data, value) => {(data as EntryResponse).Result = value;}, 
					data => (data as EntryResponse).Result ),
		new PropertyStruct ("ConstraintsData", typeof (ConstraintsData),
					(data, value) => {(data as EntryResponse).ConstraintsData = value as ConstraintsData;}, 
					data => (data as EntryResponse).ConstraintsData,
					false, ()=>new  ConstraintsData(), ()=>new ConstraintsData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EntryResponse> _binding = new (
			new() {
			{ "IndexRequest", _properties [0]},
			{ "IndexContainer", _properties [1]},
			{ "Result", _properties [2]},
			{ "ConstraintsData", _properties [3]}}, __Tag,
		() => new EntryResponse(), () => [], () => [], null, Generic: false);


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
			new() {}, __Tag,
		() => new PublicRequest(), () => [], () => [], DownloadRequest._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedMessages")]
	public virtual List<Enveloped<Message>>?					EnvelopedMessages  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<Message>?				Messages  => EnvelopedMessages.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Accounts", 
					(data, value) => {(data as PostRequest).Accounts = value;}, 
					data => (data as PostRequest).Accounts ),
		new PropertyListGStruct ("EnvelopedMessages", typeof (Enveloped),
					(data, value) => {(data as PostRequest).EnvelopedMessages = value as List<Enveloped<Message>>;},
					data => (data as PostRequest).EnvelopedMessages,
					()=>new  List<Enveloped<Message>>(), ()=>new Enveloped<Message>(),
					(list,item)=>(list as List<Enveloped<Message>>).Add (item as Enveloped<Message>)
)
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PostRequest> _binding = new (
			new() {
			{ "Accounts", _properties [0]},
			{ "EnvelopedMessages", _properties [1]}}, __Tag,
		() => new PostRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
			new() {}, __Tag,
		() => new PostResponse(), () => [], () => [], TransactResponse._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedMessageClaim")]
	public virtual Enveloped<MessageClaim>?					EnvelopedMessageClaim  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual MessageClaim?				MessageClaim  => EnvelopedMessageClaim.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedMessageClaim", typeof (Enveloped),
					(data, value) => {(data as ClaimRequest).EnvelopedMessageClaim = value as Enveloped<MessageClaim>;},
					data => (data as ClaimRequest).EnvelopedMessageClaim,
					()=>new  Enveloped<MessageClaim>(), ()=>new Enveloped<MessageClaim>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClaimRequest> _binding = new (
			new() {
			{ "EnvelopedMessageClaim", _properties [0]}}, __Tag,
		() => new ClaimRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
					(data, value) => {(data as ClaimResponse).CatalogedPublication = value as CatalogedPublication;}, 
					data => (data as ClaimResponse).CatalogedPublication,
					false, ()=>new  CatalogedPublication(), ()=>new CatalogedPublication())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClaimResponse> _binding = new (
			new() {
			{ "CatalogedPublication", _properties [0]}}, __Tag,
		() => new ClaimResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as PollClaimRequest).PublicationId = value;}, 
					data => (data as PollClaimRequest).PublicationId ),
		new PropertyString ("TargetAccountAddress", 
					(data, value) => {(data as PollClaimRequest).TargetAccountAddress = value;}, 
					data => (data as PollClaimRequest).TargetAccountAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PollClaimRequest> _binding = new (
			new() {
			{ "PublicationId", _properties [0]},
			{ "TargetAccountAddress", _properties [1]}}, __Tag,
		() => new PollClaimRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedMessage")]
	public virtual Enveloped<Message>?					EnvelopedMessage  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual Message?				Message  => EnvelopedMessage.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedMessage", typeof (Enveloped),
					(data, value) => {(data as PollClaimResponse).EnvelopedMessage = value as Enveloped<Message>;},
					data => (data as PollClaimResponse).EnvelopedMessage,
					()=>new  Enveloped<Message>(), ()=>new Enveloped<Message>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PollClaimResponse> _binding = new (
			new() {
			{ "EnvelopedMessage", _properties [0]}}, __Tag,
		() => new PollClaimResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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
					(data, value) => {(data as CryptographicOperation).KeyId = value;}, 
					data => (data as CryptographicOperation).KeyId ),
		new PropertyBinary ("KeyCoefficient", 
					(data, value) => {(data as CryptographicOperation).KeyCoefficient = value;}, 
					data => (data as CryptographicOperation).KeyCoefficient )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperation> _binding = new (
			new() {
			{ "KeyId", _properties [0]},
			{ "KeyCoefficient", _properties [1]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as CryptographicOperationSign).Data = value;}, 
					data => (data as CryptographicOperationSign).Data ),
		new PropertyBinary ("PartialR", 
					(data, value) => {(data as CryptographicOperationSign).PartialR = value;}, 
					data => (data as CryptographicOperationSign).PartialR )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationSign> _binding = new (
			new() {
			{ "Data", _properties [0]},
			{ "PartialR", _properties [1]}}, __Tag,
		() => new CryptographicOperationSign(), () => [], () => [], CryptographicOperation._binding, Generic: false);


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
					(data, value) => {(data as CryptographicOperationKeyAgreement).PublicKey = value as Key;}, 
					data => (data as CryptographicOperationKeyAgreement).PublicKey,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationKeyAgreement> _binding = new (
			new() {
			{ "PublicKey", _properties [0]}}, __Tag,
		() => new CryptographicOperationKeyAgreement(), () => [], () => [], CryptographicOperation._binding, Generic: false);


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
			new() {}, __Tag,
		() => new CryptographicOperationGenerate(), () => [], () => [], CryptographicOperation._binding, Generic: false);


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
					(data, value) => {(data as CryptographicOperationShare).Threshold = value;}, 
					data => (data as CryptographicOperationShare).Threshold ),
		new PropertyInteger32 ("Shares", 
					(data, value) => {(data as CryptographicOperationShare).Shares = value;}, 
					data => (data as CryptographicOperationShare).Shares )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicOperationShare> _binding = new (
			new() {
			{ "Threshold", _properties [0]},
			{ "Shares", _properties [1]}}, __Tag,
		() => new CryptographicOperationShare(), () => [], () => [], CryptographicOperation._binding, Generic: false);


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
					(data, value) => {(data as CryptographicResult).Error = value;}, 
					data => (data as CryptographicResult).Error )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicResult> _binding = new (
			new() {
			{ "Error", _properties [0]}}, __Tag,
		() => new CryptographicResult(), () => [], () => [], null, Generic: false);


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
					(data, value) => {(data as CryptographicResultKeyAgreement).KeyAgreement = value as KeyAgreement;}, 
					data => (data as CryptographicResultKeyAgreement).KeyAgreement,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicResultKeyAgreement> _binding = new (
			new() {
			{ "KeyAgreement", _properties [0]}}, __Tag,
		() => new CryptographicResultKeyAgreement(), () => [], () => [], CryptographicResult._binding, Generic: false);


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
			new() {}, __Tag,
		() => new CryptographicResultShare(), () => [], () => [], CryptographicResult._binding, Generic: false);


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
					(data, value) => {(data as OperateRequest).AccountAddress = value;}, 
					data => (data as OperateRequest).AccountAddress ),
		new PropertyListStruct ("Operations", typeof (CryptographicOperation), 
					(data, value) => {(data as OperateRequest).Operations = value as List<CryptographicOperation>;}, 
					data => (data as OperateRequest).Operations,
					true, ()=>new List<CryptographicOperation>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OperateRequest> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "Operations", _properties [1]}}, __Tag,
		() => new OperateRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


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
					(data, value) => {(data as OperateResponse).Results = value as List<CryptographicResult>;}, 
					data => (data as OperateResponse).Results,
					true, ()=>new List<CryptographicResult>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<OperateResponse> _binding = new (
			new() {
			{ "Results", _properties [0]}}, __Tag,
		() => new OperateResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


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


	/// <summary>
	///
	/// Publish an EARL package.
	/// </summary>
public partial class PublishEarlRequest : MeshRequest {
    /// <summary>
    ///The prelocator used to construct the Base64 locator.
    /// </summary>

	[JsonPropertyName("PreLocator")]
	public virtual byte[]?					PreLocator  {get; set;} //

    /// <summary>
    ///The encrypted resource data
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //

    /// <summary>
    ///Time after which the service should cease publishing the resource.
    /// </summary>

	[JsonPropertyName("Expire")]
	public virtual DateTime?					Expire  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("PreLocator", 
					(data, value) => {(data as PublishEarlRequest).PreLocator = value;}, 
					data => (data as PublishEarlRequest).PreLocator ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as PublishEarlRequest).Data = value;}, 
					data => (data as PublishEarlRequest).Data ),
		new PropertyDateTime ("Expire", 
					(data, value) => {(data as PublishEarlRequest).Expire = value;}, 
					data => (data as PublishEarlRequest).Expire )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublishEarlRequest> _binding = new (
			new() {
			{ "PreLocator", _properties [0]},
			{ "Data", _properties [1]},
			{ "Expire", _properties [2]}}, __Tag,
		() => new PublishEarlRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublishEarlRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublishEarlRequest();

	}


	/// <summary>
	///
	/// Result of EARL publication request.
	/// </summary>
public partial class PublishEarlResponse : MeshResponse {
    /// <summary>
    ///A domain from which the data can be retrieved.
    /// </summary>

	[JsonPropertyName("Domain")]
	public virtual string?					Domain  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Domain", 
					(data, value) => {(data as PublishEarlResponse).Domain = value;}, 
					data => (data as PublishEarlResponse).Domain )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublishEarlResponse> _binding = new (
			new() {
			{ "Domain", _properties [0]}}, __Tag,
		() => new PublishEarlResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublishEarlResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublishEarlResponse();

	}


	/// <summary>
	///
	/// Delete an EARL package.
	/// </summary>
public partial class DeleteEarlRequest : MeshRequest {
    /// <summary>
    ///The prelocator used to construct the Base64 locator.
    /// </summary>

	[JsonPropertyName("PreLocator")]
	public virtual byte[]?					PreLocator  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("PreLocator", 
					(data, value) => {(data as DeleteEarlRequest).PreLocator = value;}, 
					data => (data as DeleteEarlRequest).PreLocator )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeleteEarlRequest> _binding = new (
			new() {
			{ "PreLocator", _properties [0]}}, __Tag,
		() => new DeleteEarlRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DeleteEarlRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeleteEarlRequest();

	}


	/// <summary>
	///
	/// Result of attempt to delete an EARL
	/// </summary>
public partial class DeleteEarlResponse : MeshResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeleteEarlResponse> _binding = new (
			new() {}, __Tag,
		() => new DeleteEarlResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DeleteEarlResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeleteEarlResponse();

	}


	/// <summary>
	///
	/// Publish an EARL package.
	/// </summary>
public partial class PublishDnsRequest : MeshRequest {
    /// <summary>
    ///The updates to apply
    /// </summary>

	[JsonPropertyName("Updates")]
	public virtual List<DnsUpdate>?					Updates  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("Updates", typeof (DnsUpdate),
					(data, value) => {(data as PublishDnsRequest).Updates = value as List<DnsUpdate>;}, 
					data => (data as PublishDnsRequest).Updates,
					false, ()=>new  List<DnsUpdate>(), ()=>new DnsUpdate())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublishDnsRequest> _binding = new (
			new() {
			{ "Updates", _properties [0]}}, __Tag,
		() => new PublishDnsRequest(), () => [], () => [], MeshRequest._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublishDnsRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublishDnsRequest();

	}


	/// <summary>
	/// </summary>
public partial class DnsUpdate : MeshProtocol {
    /// <summary>
    /// </summary>

	[JsonPropertyName("IsAdd")]
	public virtual bool?					IsAdd  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("RR")]
	public virtual int?					RR  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Record")]
	public virtual byte[]?					Record  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("IsAdd", 
					(data, value) => {(data as DnsUpdate).IsAdd = value;}, 
					data => (data as DnsUpdate).IsAdd ),
		new PropertyString ("Name", 
					(data, value) => {(data as DnsUpdate).Name = value;}, 
					data => (data as DnsUpdate).Name ),
		new PropertyInteger32 ("RR", 
					(data, value) => {(data as DnsUpdate).RR = value;}, 
					data => (data as DnsUpdate).RR ),
		new PropertyBinary ("Record", 
					(data, value) => {(data as DnsUpdate).Record = value;}, 
					data => (data as DnsUpdate).Record )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DnsUpdate> _binding = new (
			new() {
			{ "IsAdd", _properties [0]},
			{ "Name", _properties [1]},
			{ "RR", _properties [2]},
			{ "Record", _properties [3]}}, __Tag,
		() => new DnsUpdate(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "DnsUpdate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DnsUpdate();

	}


	/// <summary>
	///
	/// Result of EARL publication request.
	/// </summary>
public partial class PublishDnsResponse : MeshResponse {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublishDnsResponse> _binding = new (
			new() {}, __Tag,
		() => new PublishDnsResponse(), () => [], () => [], MeshResponse._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublishDnsResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublishDnsResponse();

	}



