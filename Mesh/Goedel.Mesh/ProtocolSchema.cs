
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
//  This file was automatically generated at 9/21/2021 12:57:27 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.652
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;


#pragma warning disable IDE1006


using Goedel.Mesh;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;


namespace Goedel.Mesh {


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
				new Dictionary<string, JsonFactoryDelegate> () {

			{"MeshRequest", MeshRequest._Factory},
			{"MeshRequestUser", MeshRequestUser._Factory},
			{"MeshResponse", MeshResponse._Factory},
			{"KeyValue", KeyValue._Factory},
			{"ConstraintsSelect", ConstraintsSelect._Factory},
			{"ConstraintsData", ConstraintsData._Factory},
			{"PolicyAccount", PolicyAccount._Factory},
			{"ContainerStatus", ContainerStatus._Factory},
			{"ContainerUpdate", ContainerUpdate._Factory},
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
			{"DownloadRequest", DownloadRequest._Factory},
			{"DownloadResponse", DownloadResponse._Factory},
			{"TransactRequest", TransactRequest._Factory},
			{"TransactResponse", TransactResponse._Factory},
			{"EntryResponse", EntryResponse._Factory},
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
			{"OperateResponse", OperateResponse._Factory}			};

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
		/// Dispatch object request in specified authentication context.
		/// </summary>			
        /// <param name="session">The client context.</param>
        /// <param name="jsonReader">Reader for data object.</param>
        /// <returns>The response object returned by the corresponding dispatch.</returns>
		public override Goedel.Protocol.JsonObject Dispatch(IJpcSession  session,  
								Goedel.Protocol.JsonReader jsonReader) {

			jsonReader.StartObject ();
			string token = jsonReader.ReadToken ();
			JsonObject response = null;

			switch (token) {
				case "Hello" : {
					var request = new HelloRequest();
					request.Deserialize (jsonReader);
					response = Hello (request, session);
					break;
					}
				case "BindAccount" : {
					var request = new BindRequest();
					request.Deserialize (jsonReader);
					response = BindAccount (request, session);
					break;
					}
				case "UnbindAccount" : {
					var request = new UnbindRequest();
					request.Deserialize (jsonReader);
					response = UnbindAccount (request, session);
					break;
					}
				case "Connect" : {
					var request = new ConnectRequest();
					request.Deserialize (jsonReader);
					response = Connect (request, session);
					break;
					}
				case "Complete" : {
					var request = new CompleteRequest();
					request.Deserialize (jsonReader);
					response = Complete (request, session);
					break;
					}
				case "Status" : {
					var request = new StatusRequest();
					request.Deserialize (jsonReader);
					response = Status (request, session);
					break;
					}
				case "Download" : {
					var request = new DownloadRequest();
					request.Deserialize (jsonReader);
					response = Download (request, session);
					break;
					}
				case "Transact" : {
					var request = new TransactRequest();
					request.Deserialize (jsonReader);
					response = Transact (request, session);
					break;
					}
				case "Post" : {
					var request = new PostRequest();
					request.Deserialize (jsonReader);
					response = Post (request, session);
					break;
					}
				case "Claim" : {
					var request = new ClaimRequest();
					request.Deserialize (jsonReader);
					response = Claim (request, session);
					break;
					}
				case "PollClaim" : {
					var request = new PollClaimRequest();
					request.Deserialize (jsonReader);
					response = PollClaim (request, session);
					break;
					}
				case "Operate" : {
					var request = new OperateRequest();
					request.Deserialize (jsonReader);
					response = Operate (request, session);
					break;
					}
				default : {
					throw new Goedel.Protocol.UnknownOperation ();
					}
				}
			jsonReader.EndObject ();
			return response;
			}

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
		/// Base method for implementing the transaction  Hello.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract MeshHelloResponse Hello (
                HelloRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  BindAccount.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract BindResponse BindAccount (
                BindRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  UnbindAccount.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract UnbindResponse UnbindAccount (
                UnbindRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Connect.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract ConnectResponse Connect (
                ConnectRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Complete.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract CompleteResponse Complete (
                CompleteRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Status.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract StatusResponse Status (
                StatusRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Download.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract DownloadResponse Download (
                DownloadRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Transact.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract TransactResponse Transact (
                TransactRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Post.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract PostResponse Post (
                PostRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Claim.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract ClaimResponse Claim (
                ClaimRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  PollClaim.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract PollClaimResponse PollClaim (
                PollClaimRequest request, IJpcSession session);

        /// <summary>
		/// Base method for implementing the transaction  Operate.
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
    public partial class MeshServiceClient :  Goedel.Protocol.JpcClientInterface {

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


    /*
    /// <summary>
	/// Service class for MeshService.
    /// </summary>		
    public partial class MeshServiceDispatch : Goedel.Protocol.JpcDispatch {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public MeshService Service;


		/// <summary>
		/// Dispatch object request in specified authentication context.
		/// </summary>			
        /// <param name="session">The client context.</param>
        /// <param name="jsonReader">Reader for data object.</param>
        /// <returns>The response object returned by the corresponding dispatch.</returns>
		public override Goedel.Protocol.JsonObject Dispatch(IJpcSession  session,  
								Goedel.Protocol.JsonReader jsonReader) {

			jsonReader.StartObject ();
			string token = jsonReader.ReadToken ();
			JsonObject response = null;

			switch (token) {
				case "Hello" : {
					var request = new HelloRequest();
					request.Deserialize (jsonReader);
					response = Service.Hello (request, session);
					break;
					}
				case "BindAccount" : {
					var request = new BindRequest();
					request.Deserialize (jsonReader);
					response = Service.BindAccount (request, session);
					break;
					}
				case "UnbindAccount" : {
					var request = new UnbindRequest();
					request.Deserialize (jsonReader);
					response = Service.UnbindAccount (request, session);
					break;
					}
				case "Connect" : {
					var request = new ConnectRequest();
					request.Deserialize (jsonReader);
					response = Service.Connect (request, session);
					break;
					}
				case "Complete" : {
					var request = new CompleteRequest();
					request.Deserialize (jsonReader);
					response = Service.Complete (request, session);
					break;
					}
				case "Status" : {
					var request = new StatusRequest();
					request.Deserialize (jsonReader);
					response = Service.Status (request, session);
					break;
					}
				case "Download" : {
					var request = new DownloadRequest();
					request.Deserialize (jsonReader);
					response = Service.Download (request, session);
					break;
					}
				case "Transact" : {
					var request = new TransactRequest();
					request.Deserialize (jsonReader);
					response = Service.Transact (request, session);
					break;
					}
				case "Post" : {
					var request = new PostRequest();
					request.Deserialize (jsonReader);
					response = Service.Post (request, session);
					break;
					}
				case "Claim" : {
					var request = new ClaimRequest();
					request.Deserialize (jsonReader);
					response = Service.Claim (request, session);
					break;
					}
				case "PollClaim" : {
					var request = new PollClaimRequest();
					request.Deserialize (jsonReader);
					response = Service.PollClaim (request, session);
					break;
					}
				case "Operate" : {
					var request = new OperateRequest();
					request.Deserialize (jsonReader);
					response = Service.Operate (request, session);
					break;
					}
				default : {
					throw new Goedel.Protocol.UnknownOperation ();
					}
				}
			jsonReader.EndObject ();
			return response;
			}

		}
		*/




		// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
	public partial class MeshRequest : Goedel.Protocol.Request {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Request)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        ///Device profile of the device making the request.
        /// </summary>

		public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (Account != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Account", 1);
					_writer.WriteString (Account);
				}
			if (EnvelopedProfileDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Account" : {
					Account = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
	public partial class MeshResponse : Goedel.Protocol.Response {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Response)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (Key != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Key", 1);
					_writer.WriteString (Key);
				}
			if (Value != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Value", 1);
					_writer.WriteString (Value);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Key" : {
					Key = jsonReader.ReadString ();
					break;
					}
				case "Value" : {
					Value = jsonReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
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

		public virtual string						Container  {get; set;}
		bool								__IndexMin = false;
		private int						_IndexMin;
        /// <summary>
        ///Only return objects with an index value that is equal to or
        ///higher than the value specified.
        /// </summary>

		public virtual int						IndexMin {
			get => _IndexMin;
			set {_IndexMin = value; __IndexMin = true; }
			}
		bool								__IndexMax = false;
		private int						_IndexMax;
        /// <summary>
        ///Only return objects with an index value that is equal to or
        ///lower than the value specified.
        /// </summary>

		public virtual int						IndexMax {
			get => _IndexMax;
			set {_IndexMax = value; __IndexMax = true; }
			}
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (Container != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Container", 1);
					_writer.WriteString (Container);
				}
			if (__IndexMin){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IndexMin", 1);
					_writer.WriteInteger32 (IndexMin);
				}
			if (__IndexMax){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IndexMax", 1);
					_writer.WriteInteger32 (IndexMax);
				}
			if (NotBefore != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("NotBefore", 1);
					_writer.WriteDateTime (NotBefore);
				}
			if (Before != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Before", 1);
					_writer.WriteDateTime (Before);
				}
			if (PageKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PageKey", 1);
					_writer.WriteString (PageKey);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Container" : {
					Container = jsonReader.ReadString ();
					break;
					}
				case "IndexMin" : {
					IndexMin = jsonReader.ReadInteger32 ();
					break;
					}
				case "IndexMax" : {
					IndexMax = jsonReader.ReadInteger32 ();
					break;
					}
				case "NotBefore" : {
					NotBefore = jsonReader.ReadDateTime ();
					break;
					}
				case "Before" : {
					Before = jsonReader.ReadDateTime ();
					break;
					}
				case "PageKey" : {
					PageKey = jsonReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specifies constraints on the data to be sent.
	/// </summary>
	public partial class ConstraintsData : MeshProtocol {
		bool								__MaxEntries = false;
		private int						_MaxEntries;
        /// <summary>
        ///Maximum number of entries to send.
        /// </summary>

		public virtual int						MaxEntries {
			get => _MaxEntries;
			set {_MaxEntries = value; __MaxEntries = true; }
			}
		bool								__BytesOffset = false;
		private int						_BytesOffset;
        /// <summary>
        ///Specifies an offset to be applied to the payload data before it is sent. 
        ///This allows large payloads to be transferred incrementally.
        /// </summary>

		public virtual int						BytesOffset {
			get => _BytesOffset;
			set {_BytesOffset = value; __BytesOffset = true; }
			}
		bool								__BytesMax = false;
		private int						_BytesMax;
        /// <summary>
        ///Maximum number of payload bytes to send.
        /// </summary>

		public virtual int						BytesMax {
			get => _BytesMax;
			set {_BytesMax = value; __BytesMax = true; }
			}
		bool								__Header = false;
		private bool						_Header;
        /// <summary>
        ///Return the entry header
        /// </summary>

		public virtual bool						Header {
			get => _Header;
			set {_Header = value; __Header = true; }
			}
		bool								__Payload = false;
		private bool						_Payload;
        /// <summary>
        ///Return the entry payload
        /// </summary>

		public virtual bool						Payload {
			get => _Payload;
			set {_Payload = value; __Payload = true; }
			}
		bool								__Trailer = false;
		private bool						_Trailer;
        /// <summary>
        ///Return the entry trailer
        /// </summary>

		public virtual bool						Trailer {
			get => _Trailer;
			set {_Trailer = value; __Trailer = true; }
			}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (__MaxEntries){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MaxEntries", 1);
					_writer.WriteInteger32 (MaxEntries);
				}
			if (__BytesOffset){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("BytesOffset", 1);
					_writer.WriteInteger32 (BytesOffset);
				}
			if (__BytesMax){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("BytesMax", 1);
					_writer.WriteInteger32 (BytesMax);
				}
			if (__Header){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Header", 1);
					_writer.WriteBoolean (Header);
				}
			if (__Payload){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Payload", 1);
					_writer.WriteBoolean (Payload);
				}
			if (__Trailer){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Trailer", 1);
					_writer.WriteBoolean (Trailer);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "MaxEntries" : {
					MaxEntries = jsonReader.ReadInteger32 ();
					break;
					}
				case "BytesOffset" : {
					BytesOffset = jsonReader.ReadInteger32 ();
					break;
					}
				case "BytesMax" : {
					BytesMax = jsonReader.ReadInteger32 ();
					break;
					}
				case "Header" : {
					Header = jsonReader.ReadBoolean ();
					break;
					}
				case "Payload" : {
					Payload = jsonReader.ReadBoolean ();
					break;
					}
				case "Trailer" : {
					Trailer = jsonReader.ReadBoolean ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the account creation policy including constraints on 
	/// account names, whether there is an open account creation policy, etc.
	/// </summary>
	public partial class PolicyAccount : MeshProtocol {
		bool								__Minimum = false;
		private int						_Minimum;
        /// <summary>
        ///Specifies the minimum length of an account name.
        /// </summary>

		public virtual int						Minimum {
			get => _Minimum;
			set {_Minimum = value; __Minimum = true; }
			}
		bool								__Maximum = false;
		private int						_Maximum;
        /// <summary>
        ///Specifies the maximum length of an account name.
        /// </summary>

		public virtual int						Maximum {
			get => _Maximum;
			set {_Maximum = value; __Maximum = true; }
			}
        /// <summary>
        ///A list of characters that the service 
        ///does not accept in account names. The list of characters 
        ///MAY not be exhaustive but SHOULD include any illegal characters
        ///in the proposed account name.
        /// </summary>

		public virtual string						InvalidCharacters  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (__Minimum){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Minimum", 1);
					_writer.WriteInteger32 (Minimum);
				}
			if (__Maximum){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Maximum", 1);
					_writer.WriteInteger32 (Maximum);
				}
			if (InvalidCharacters != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("InvalidCharacters", 1);
					_writer.WriteString (InvalidCharacters);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Minimum" : {
					Minimum = jsonReader.ReadInteger32 ();
					break;
					}
				case "Maximum" : {
					Maximum = jsonReader.ReadInteger32 ();
					break;
					}
				case "InvalidCharacters" : {
					InvalidCharacters = jsonReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ContainerStatus : MeshProtocol {
        /// <summary>
        /// </summary>

		public virtual string						Container  {get; set;}
		bool								__Index = false;
		private int						_Index;
        /// <summary>
        /// </summary>

		public virtual int						Index {
			get => _Index;
			set {_Index = value; __Index = true; }
			}
        /// <summary>
        /// </summary>

		public virtual byte[]						Digest  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ContainerStatus";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new ContainerStatus();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (Container != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Container", 1);
					_writer.WriteString (Container);
				}
			if (__Index){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Index", 1);
					_writer.WriteInteger32 (Index);
				}
			if (Digest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Digest", 1);
					_writer.WriteBinary (Digest);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ContainerStatus FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ContainerStatus;
				}
		    var Result = new ContainerStatus ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Container" : {
					Container = jsonReader.ReadString ();
					break;
					}
				case "Index" : {
					Index = jsonReader.ReadInteger32 ();
					break;
					}
				case "Digest" : {
					Digest = jsonReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ContainerUpdate : ContainerStatus {
        /// <summary>
        ///The entries to be uploaded. 
        /// </summary>

		public virtual List<DareEnvelope>				Envelopes  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ContainerUpdate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new ContainerUpdate();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((ContainerStatus)this).SerializeX(_writer, false, ref _first);
			if (Envelopes != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Envelopes", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Envelopes) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ContainerUpdate FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ContainerUpdate;
				}
		    var Result = new ContainerUpdate ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Envelopes" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Envelopes = new List <DareEnvelope> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareEnvelope ();
						_Item.Deserialize (jsonReader);
						// var _Item = new DareEnvelope (jsonReader);
						Envelopes.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((Goedel.Protocol.HelloResponse)this).SerializeX(_writer, false, ref _first);
			if (ConstraintsUpdate != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ConstraintsUpdate", 1);
					ConstraintsUpdate.Serialize (_writer, false);
				}
			if (ConstraintsPost != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ConstraintsPost", 1);
					ConstraintsPost.Serialize (_writer, false);
				}
			if (PolicyAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PolicyAccount", 1);
					PolicyAccount.Serialize (_writer, false);
				}
			if (EnvelopedProfileService != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileService", 1);
					EnvelopedProfileService.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "ConstraintsUpdate" : {
					// An untagged structure
					ConstraintsUpdate = new ConstraintsData ();
					ConstraintsUpdate.Deserialize (jsonReader);
 
					break;
					}
				case "ConstraintsPost" : {
					// An untagged structure
					ConstraintsPost = new ConstraintsData ();
					ConstraintsPost.Deserialize (jsonReader);
 
					break;
					}
				case "PolicyAccount" : {
					// An untagged structure
					PolicyAccount = new PolicyAccount ();
					PolicyAccount.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedProfileService" : {
					// An untagged structure
					EnvelopedProfileService = new Enveloped<ProfileService> ();
					EnvelopedProfileService.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        ///Data to be prepopulated to the account stores. This MUST include the access 
        ///authorization for the devices to be used to complete the account initialization.
        /// </summary>

		public virtual List<ContainerUpdate>				Updates  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (EnvelopedProfileAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_writer, false);
				}
			if (Updates != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Updates", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Updates) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new Enveloped<ProfileAccount> ();
					EnvelopedProfileAccount.Deserialize (jsonReader);
 
					break;
					}
				case "Updates" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Updates = new List <ContainerUpdate> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ContainerUpdate ();
						_Item.Deserialize (jsonReader);
						// var _Item = new ContainerUpdate (jsonReader);
						Updates.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (Reason != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Reason", 1);
					_writer.WriteString (Reason);
				}
			if (URL != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("URL", 1);
					_writer.WriteString (URL);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Reason" : {
					Reason = jsonReader.ReadString ();
					break;
					}
				case "URL" : {
					URL = jsonReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request creation of a new portal account. The request specifies
	/// the requested account identifier and the Mesh profile to be associated 
	/// with the account.
	/// </summary>
	public partial class UnbindRequest : MeshRequestUser {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequestUser)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a Delete transaction.
	/// </summary>
	public partial class UnbindResponse : MeshResponse {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedRequestConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedRequestConnection", 1);
					EnvelopedRequestConnection.Serialize (_writer, false);
				}
			if (Rights != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Rights", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Rights) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedRequestConnection" : {
					// An untagged structure
					EnvelopedRequestConnection = new Enveloped<RequestConnection> ();
					EnvelopedRequestConnection.Deserialize (jsonReader);
 
					break;
					}
				case "Rights" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Rights = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Rights.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedAcknowledgeConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedAcknowledgeConnection", 1);
					EnvelopedAcknowledgeConnection.Serialize (_writer, false);
				}
			if (EnvelopedProfileAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedAcknowledgeConnection" : {
					// An untagged structure
					EnvelopedAcknowledgeConnection = new Enveloped<AcknowledgeConnection> ();
					EnvelopedAcknowledgeConnection.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new Enveloped<ProfileAccount> ();
					EnvelopedProfileAccount.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((StatusRequest)this).SerializeX(_writer, false, ref _first);
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (ResponseID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ResponseID", 1);
					_writer.WriteString (ResponseID);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "ResponseID" : {
					ResponseID = jsonReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedRespondConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedRespondConnection", 1);
					EnvelopedRespondConnection.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedRespondConnection" : {
					// An untagged structure
					EnvelopedRespondConnection = new Enveloped<RespondConnection> ();
					EnvelopedRespondConnection.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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

		public virtual byte[]						ProfileMasterDigest  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				Catalogs  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				Spools  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequestUser)this).SerializeX(_writer, false, ref _first);
			if (DeviceUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceUDF", 1);
					_writer.WriteString (DeviceUDF);
				}
			if (ProfileMasterDigest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ProfileMasterDigest", 1);
					_writer.WriteBinary (ProfileMasterDigest);
				}
			if (Catalogs != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Catalogs", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Catalogs) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Spools != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Spools", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Spools) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "DeviceUDF" : {
					DeviceUDF = jsonReader.ReadString ();
					break;
					}
				case "ProfileMasterDigest" : {
					ProfileMasterDigest = jsonReader.ReadBinary ();
					break;
					}
				case "Catalogs" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Catalogs = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Catalogs.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Spools" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Spools = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Spools.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class StatusResponse : MeshResponse {
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

		public virtual List<ContainerStatus>				ContainerStatus  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedProfileAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_writer, false);
				}
			if (EnvelopedCatalogedDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedCatalogedDevice", 1);
					EnvelopedCatalogedDevice.Serialize (_writer, false);
				}
			if (ContainerStatus != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContainerStatus", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ContainerStatus) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new Enveloped<ProfileAccount> ();
					EnvelopedProfileAccount.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedCatalogedDevice" : {
					// An untagged structure
					EnvelopedCatalogedDevice = new Enveloped<CatalogedDevice> ();
					EnvelopedCatalogedDevice.Deserialize (jsonReader);
 
					break;
					}
				case "ContainerStatus" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					ContainerStatus = new List <ContainerStatus> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ContainerStatus ();
						_Item.Deserialize (jsonReader);
						// var _Item = new ContainerStatus (jsonReader);
						ContainerStatus.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        ///Specifies constraints to be applied to a search result. These 
        ///allow a client to limit the number of records returned, the quantity
        ///of data returned, the earliest and latest data returned, etc.
        /// </summary>

		public virtual List<ConstraintsSelect>				Select  {get; set;}
        /// <summary>
        ///Specifies the data constraints to be applied to the responses.
        /// </summary>

		public virtual ConstraintsData						ConstraintsPost  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequestUser)this).SerializeX(_writer, false, ref _first);
			if (Select != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Select", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Select) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (ConstraintsPost != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ConstraintsPost", 1);
					ConstraintsPost.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Select" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Select = new List <ConstraintsSelect> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ConstraintsSelect ();
						_Item.Deserialize (jsonReader);
						// var _Item = new ConstraintsSelect (jsonReader);
						Select.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "ConstraintsPost" : {
					// An untagged structure
					ConstraintsPost = new ConstraintsData ();
					ConstraintsPost.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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

		public virtual List<ContainerUpdate>				Updates  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (Updates != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Updates", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Updates) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Updates" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Updates = new List <ContainerUpdate> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ContainerUpdate ();
						_Item.Deserialize (jsonReader);
						// var _Item = new ContainerUpdate (jsonReader);
						Updates.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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

		public virtual List<ContainerUpdate>				Updates  {get; set;}
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequestUser)this).SerializeX(_writer, false, ref _first);
			if (Updates != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Updates", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Updates) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (Accounts != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Accounts", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Accounts) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Outbound != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Outbound", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Outbound) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (Inbound != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Inbound", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Inbound) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (Local != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Local", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Local) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Updates" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Updates = new List <ContainerUpdate> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ContainerUpdate ();
						_Item.Deserialize (jsonReader);
						// var _Item = new ContainerUpdate (jsonReader);
						Updates.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Accounts" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Accounts = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Accounts.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Outbound" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Outbound = new List <Enveloped<Message>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<Message> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<Message> (jsonReader);
						Outbound.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Inbound" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Inbound = new List <Enveloped<Message>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<Message> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<Message> (jsonReader);
						Inbound.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Local" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Local = new List <Enveloped<Message>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<Message> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<Message> (jsonReader);
						Local.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Response to an upload request. 
	/// </summary>
	public partial class TransactResponse : MeshResponse {
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (Entries != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Entries", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (ConstraintsData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ConstraintsData", 1);
					ConstraintsData.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Entries" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Entries = new List <EntryResponse> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  EntryResponse ();
						_Item.Deserialize (jsonReader);
						// var _Item = new EntryResponse (jsonReader);
						Entries.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "ConstraintsData" : {
					// An untagged structure
					ConstraintsData = new ConstraintsData ();
					ConstraintsData.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class EntryResponse : MeshProtocol {
		bool								__IndexRequest = false;
		private int						_IndexRequest;
        /// <summary>
        ///The index value of the entry in the request.
        /// </summary>

		public virtual int						IndexRequest {
			get => _IndexRequest;
			set {_IndexRequest = value; __IndexRequest = true; }
			}
		bool								__IndexContainer = false;
		private int						_IndexContainer;
        /// <summary>
        ///The index value assigned to the entry in the container.
        /// </summary>

		public virtual int						IndexContainer {
			get => _IndexContainer;
			set {_IndexContainer = value; __IndexContainer = true; }
			}
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (__IndexRequest){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IndexRequest", 1);
					_writer.WriteInteger32 (IndexRequest);
				}
			if (__IndexContainer){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IndexContainer", 1);
					_writer.WriteInteger32 (IndexContainer);
				}
			if (Result != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Result", 1);
					_writer.WriteString (Result);
				}
			if (ConstraintsData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ConstraintsData", 1);
					ConstraintsData.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "IndexRequest" : {
					IndexRequest = jsonReader.ReadInteger32 ();
					break;
					}
				case "IndexContainer" : {
					IndexContainer = jsonReader.ReadInteger32 ();
					break;
					}
				case "Result" : {
					Result = jsonReader.ReadString ();
					break;
					}
				case "ConstraintsData" : {
					// An untagged structure
					ConstraintsData = new ConstraintsData ();
					ConstraintsData.Deserialize (jsonReader);
 
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (Accounts != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Accounts", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Accounts) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Messages != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Messages", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Messages) {
					_writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_writer.WriteObjectStart();
                    //_writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    //_writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Accounts" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Accounts = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Accounts.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Messages" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Messages = new List <Enveloped<Message>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<Message> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<Message> (jsonReader);
						Messages.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// 
	/// </summary>
	public partial class PostResponse : TransactResponse {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((TransactResponse)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ClaimRequest : MeshRequest {
        /// <summary>
        ///The claim message
        /// </summary>

		public virtual Enveloped<MessageClaim>						EnvelopedMessageClaim  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedMessageClaim != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedMessageClaim", 1);
					EnvelopedMessageClaim.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedMessageClaim" : {
					// An untagged structure
					EnvelopedMessageClaim = new Enveloped<MessageClaim> ();
					EnvelopedMessageClaim.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ClaimResponse : MeshResponse {
        /// <summary>
        ///The encrypted device profile
        /// </summary>

		public virtual CatalogedPublication						CatalogedPublication  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (CatalogedPublication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("CatalogedPublication", 1);
					CatalogedPublication.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "CatalogedPublication" : {
					// An untagged structure
					CatalogedPublication = new CatalogedPublication ();
					CatalogedPublication.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (PublicationId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PublicationId", 1);
					_writer.WriteString (PublicationId);
				}
			if (TargetAccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("TargetAccountAddress", 1);
					_writer.WriteString (TargetAccountAddress);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "PublicationId" : {
					PublicationId = jsonReader.ReadString ();
					break;
					}
				case "TargetAccountAddress" : {
					TargetAccountAddress = jsonReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class PollClaimResponse : MeshResponse {
        /// <summary>
        ///The claim message
        /// </summary>

		public virtual Enveloped<Message>						EnvelopedMessage  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedMessage != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedMessage", 1);
					EnvelopedMessage.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedMessage" : {
					// An untagged structure
					EnvelopedMessage = new Enveloped<Message> ();
					EnvelopedMessage.Deserialize (jsonReader);
 
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (KeyId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyId", 1);
					_writer.WriteString (KeyId);
				}
			if (KeyCoefficient != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyCoefficient", 1);
					_writer.WriteBinary (KeyCoefficient);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyId" : {
					KeyId = jsonReader.ReadString ();
					break;
					}
				case "KeyCoefficient" : {
					KeyCoefficient = jsonReader.ReadBinary ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicOperation)this).SerializeX(_writer, false, ref _first);
			if (Data != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Data", 1);
					_writer.WriteBinary (Data);
				}
			if (PartialR != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PartialR", 1);
					_writer.WriteBinary (PartialR);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Data" : {
					Data = jsonReader.ReadBinary ();
					break;
					}
				case "PartialR" : {
					PartialR = jsonReader.ReadBinary ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicOperationKeyAgreement : CryptographicOperation {
        /// <summary>
        ///The public key value to perform the agreement on.
        /// </summary>

		public virtual Key						PublicKey  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicOperation)this).SerializeX(_writer, false, ref _first);
			if (PublicKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PublicKey", 1);
					// expand this to a tagged structure
					//PublicKey.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(PublicKey._Tag, 1);
						bool firstinner = true;
						PublicKey.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "PublicKey" : {
					PublicKey = Key.FromJson (jsonReader, true) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicOperationGenerate : CryptographicOperation {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicOperation)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicOperationShare : CryptographicOperation {
		bool								__Threshold = false;
		private int						_Threshold;
        /// <summary>
        /// </summary>

		public virtual int						Threshold {
			get => _Threshold;
			set {_Threshold = value; __Threshold = true; }
			}
		bool								__Shares = false;
		private int						_Shares;
        /// <summary>
        /// </summary>

		public virtual int						Shares {
			get => _Shares;
			set {_Shares = value; __Shares = true; }
			}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicOperation)this).SerializeX(_writer, false, ref _first);
			if (__Threshold){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Threshold", 1);
					_writer.WriteInteger32 (Threshold);
				}
			if (__Shares){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Shares", 1);
					_writer.WriteInteger32 (Shares);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Threshold" : {
					Threshold = jsonReader.ReadInteger32 ();
					break;
					}
				case "Shares" : {
					Shares = jsonReader.ReadInteger32 ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicResult : MeshProtocol {
        /// <summary>
        /// </summary>

		public virtual string						Error  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (Error != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Error", 1);
					_writer.WriteString (Error);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Error" : {
					Error = jsonReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicResultKeyAgreement : CryptographicResult {
        /// <summary>
        /// </summary>

		public virtual KeyAgreement						KeyAgreement  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicResult)this).SerializeX(_writer, false, ref _first);
			if (KeyAgreement != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAgreement", 1);
					// expand this to a tagged structure
					//KeyAgreement.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(KeyAgreement._Tag, 1);
						bool firstinner = true;
						KeyAgreement.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyAgreement" : {
					KeyAgreement = KeyAgreement.FromJson (jsonReader, true) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CryptographicResultShare : CryptographicResult {
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CryptographicResult)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_writer, false, ref _first);
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (Operations != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Operations", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Operations) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "Operations" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Operations = new List <CryptographicOperation> ();
					while (_Going) {
						var _Item = CryptographicOperation.FromJson (jsonReader, true); // a tagged structure
						Operations.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class OperateResponse : MeshResponse {
        /// <summary>
        /// </summary>

		public virtual List<CryptographicResult>				Results  {get; set;}
		
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
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_writer, false, ref _first);
			if (Results != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Results", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Results) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

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

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Results" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Results = new List <CryptographicResult> ();
					while (_Going) {
						var _Item = CryptographicResult.FromJson (jsonReader, true); // a tagged structure
						Results.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

