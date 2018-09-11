
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
//  #% var InheritsOverride = "override"; // "virtual"

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;



using Goedel.Mesh;
using Goedel.Persistence;


namespace Goedel.Mesh.Portal {


	/// <summary>
	///
	/// Communication between the user and the portal.
	/// </summary>
	public abstract partial class MeshProtocol : global::Goedel.Protocol.JSONObject {

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
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"MeshRequest", MeshRequest._Factory},
			{"MeshResponse", MeshResponse._Factory},
			{"KeyValue", KeyValue._Factory},
			{"SearchConstraints", SearchConstraints._Factory},
			{"ValidateRequest", ValidateRequest._Factory},
			{"ValidateResponse", ValidateResponse._Factory},
			{"CreateRequest", CreateRequest._Factory},
			{"CreateResponse", CreateResponse._Factory},
			{"DeleteRequest", DeleteRequest._Factory},
			{"DeleteResponse", DeleteResponse._Factory},
			{"GetRequest", GetRequest._Factory},
			{"GetResponse", GetResponse._Factory},
			{"PublishRequest", PublishRequest._Factory},
			{"PublishResponse", PublishResponse._Factory},
			{"StatusRequest", StatusRequest._Factory},
			{"StatusResponse", StatusResponse._Factory},
			{"ConnectStartRequest", ConnectStartRequest._Factory},
			{"ConnectStartResponse", ConnectStartResponse._Factory},
			{"ConnectStatusRequest", ConnectStatusRequest._Factory},
			{"ConnectStatusResponse", ConnectStatusResponse._Factory},
			{"ConnectPendingRequest", ConnectPendingRequest._Factory},
			{"ConnectPendingResponse", ConnectPendingResponse._Factory},
			{"ConnectCompleteRequest", ConnectCompleteRequest._Factory},
			{"ConnectCompleteResponse", ConnectCompleteResponse._Factory},
			{"TransferRequest", TransferRequest._Factory},
			{"TransferResponse", TransferResponse._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) => 
			Out = JSONReader.ReadTaggedObject(_TagDictionary);

		}



		// Service Dispatch Classes


    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class MeshService : Goedel.Protocol.JPCInterface {
		
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
        /// The active JPCSession.
        /// </summary>		
		public virtual JPCSession JPCSession {get; set;}


        /// <summary>
		/// Base method for implementing the transaction  Hello.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual HelloResponse Hello (
                HelloRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  ValidateAccount.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ValidateResponse ValidateAccount (
                ValidateRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  CreateAccount.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual CreateResponse CreateAccount (
                CreateRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  DeleteAccount.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual DeleteResponse DeleteAccount (
                DeleteRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  Get.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual GetResponse Get (
                GetRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  Publish.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual PublishResponse Publish (
                PublishRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  Status.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual StatusResponse Status (
                StatusRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  ConnectStart.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ConnectStartResponse ConnectStart (
                ConnectStartRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  ConnectStatus.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ConnectStatusResponse ConnectStatus (
                ConnectStatusRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  ConnectPending.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ConnectPendingResponse ConnectPending (
                ConnectPendingRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  ConnectComplete.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ConnectCompleteResponse ConnectComplete (
                ConnectCompleteRequest Request) => null;

        /// <summary>
		/// Base method for implementing the transaction  Transfer.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual TransferResponse Transfer (
                TransferRequest Request) => null;

        }

    /// <summary>
	/// Client class for MeshService.
    /// </summary>		
    public partial class MeshServiceClient : MeshService {
 		
		JPCRemoteSession JPCRemoteSession;
        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public override JPCSession JPCSession {
			get => JPCRemoteSession;
			set => JPCRemoteSession = value as JPCRemoteSession; 
			}


        /// <summary>
		/// Create a client connection to the specified service.
        /// </summary>	
        /// <param name="JPCRemoteSession">The remote session to connect to</param>
		public MeshServiceClient (JPCRemoteSession JPCRemoteSession) =>
			this.JPCRemoteSession = JPCRemoteSession;



        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override HelloResponse Hello (
                HelloRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Hello", Request);
            var Response = HelloResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ValidateResponse ValidateAccount (
                ValidateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ValidateAccount", Request);
            var Response = ValidateResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override CreateResponse CreateAccount (
                CreateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("CreateAccount", Request);
            var Response = CreateResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override DeleteResponse DeleteAccount (
                DeleteRequest Request) {

            var ResponseData = JPCRemoteSession.Post("DeleteAccount", Request);
            var Response = DeleteResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override GetResponse Get (
                GetRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Get", Request);
            var Response = GetResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override PublishResponse Publish (
                PublishRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Publish", Request);
            var Response = PublishResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override StatusResponse Status (
                StatusRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Status", Request);
            var Response = StatusResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ConnectStartResponse ConnectStart (
                ConnectStartRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectStart", Request);
            var Response = ConnectStartResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ConnectStatusResponse ConnectStatus (
                ConnectStatusRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectStatus", Request);
            var Response = ConnectStatusResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ConnectPendingResponse ConnectPending (
                ConnectPendingRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectPending", Request);
            var Response = ConnectPendingResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ConnectCompleteResponse ConnectComplete (
                ConnectCompleteRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectComplete", Request);
            var Response = ConnectCompleteResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override TransferResponse Transfer (
                TransferRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Transfer", Request);
            var Response = TransferResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

		}


    /// <summary>
	/// Client class for MeshService.
    /// </summary>		
    public partial class MeshServiceProvider : Goedel.Protocol.JPCProvider {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public MeshService Service;


		/// <summary>
		/// Dispatch object request in specified authentication context.
		/// </summary>			
        /// <param name="Session">The client context.</param>
        /// <param name="JSONReader">Reader for data object.</param>
        /// <returns>The response object returned by the corresponding dispatch.</returns>
		public override Goedel.Protocol.JSONObject Dispatch(JPCSession  Session,  
								Goedel.Protocol.JSONReader JSONReader) {

			JSONReader.StartObject ();
			string token = JSONReader.ReadToken ();
			JSONObject Response = null;

			switch (token) {
				case "Hello" : {
					var Request = new HelloRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Hello (Request);
					break;
					}
				case "ValidateAccount" : {
					var Request = new ValidateRequest();
					Request.Deserialize (JSONReader);
					Response = Service.ValidateAccount (Request);
					break;
					}
				case "CreateAccount" : {
					var Request = new CreateRequest();
					Request.Deserialize (JSONReader);
					Response = Service.CreateAccount (Request);
					break;
					}
				case "DeleteAccount" : {
					var Request = new DeleteRequest();
					Request.Deserialize (JSONReader);
					Response = Service.DeleteAccount (Request);
					break;
					}
				case "Get" : {
					var Request = new GetRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Get (Request);
					break;
					}
				case "Publish" : {
					var Request = new PublishRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Publish (Request);
					break;
					}
				case "Status" : {
					var Request = new StatusRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Status (Request);
					break;
					}
				case "ConnectStart" : {
					var Request = new ConnectStartRequest();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectStart (Request);
					break;
					}
				case "ConnectStatus" : {
					var Request = new ConnectStatusRequest();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectStatus (Request);
					break;
					}
				case "ConnectPending" : {
					var Request = new ConnectPendingRequest();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectPending (Request);
					break;
					}
				case "ConnectComplete" : {
					var Request = new ConnectCompleteRequest();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectComplete (Request);
					break;
					}
				case "Transfer" : {
					var Request = new TransferRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Transfer (Request);
					break;
					}
				default : {
					throw new Goedel.Protocol.UnknownOperation ();
					}
				}
			JSONReader.EndObject ();
			return Response;
			}

		}





		// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
	public partial class MeshRequest : Goedel.Protocol.Request {
        /// <summary>
        ///Name of the Mesh Portal Service to which the request 
        ///is directed.
        /// </summary>

		public virtual string						Portal  {get; set;}
		
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
		public static new JSONObject _Factory () => new MeshRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Request)this).SerializeX(_Writer, false, ref _first);
			if (Portal != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Portal", 1);
					_Writer.WriteString (Portal);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MeshRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MeshRequest;
				}
		    var Result = new MeshRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Portal" : {
					Portal = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
		public static new JSONObject _Factory () => new MeshResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Goedel.Protocol.Response)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MeshResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MeshResponse;
				}
		    var Result = new MeshResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
		public static new JSONObject _Factory () => new KeyValue();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (Value != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Value", 1);
					_Writer.WriteString (Value);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new KeyValue FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as KeyValue;
				}
		    var Result = new KeyValue ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Value" : {
					Value = JSONReader.ReadString ();
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
	public partial class SearchConstraints : MeshProtocol {
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
		bool								__MaxEntries = false;
		private int						_MaxEntries;
        /// <summary>
        ///Maximum number of data entries to return.
        /// </summary>

		public virtual int						MaxEntries {
			get => _MaxEntries;
			set {_MaxEntries = value; __MaxEntries = true; }
			}
		bool								__MaxBytes = false;
		private int						_MaxBytes;
        /// <summary>
        ///Maximum number of data bytes to return.
        /// </summary>

		public virtual int						MaxBytes {
			get => _MaxBytes;
			set {_MaxBytes = value; __MaxBytes = true; }
			}
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
		public new const string __Tag = "SearchConstraints";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new SearchConstraints();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (NotBefore != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotBefore", 1);
					_Writer.WriteDateTime (NotBefore);
				}
			if (Before != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Before", 1);
					_Writer.WriteDateTime (Before);
				}
			if (__MaxEntries){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MaxEntries", 1);
					_Writer.WriteInteger32 (MaxEntries);
				}
			if (__MaxBytes){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MaxBytes", 1);
					_Writer.WriteInteger32 (MaxBytes);
				}
			if (PageKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PageKey", 1);
					_Writer.WriteString (PageKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new SearchConstraints FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SearchConstraints;
				}
		    var Result = new SearchConstraints ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "NotBefore" : {
					NotBefore = JSONReader.ReadDateTime ();
					break;
					}
				case "Before" : {
					Before = JSONReader.ReadDateTime ();
					break;
					}
				case "MaxEntries" : {
					MaxEntries = JSONReader.ReadInteger32 ();
					break;
					}
				case "MaxBytes" : {
					MaxBytes = JSONReader.ReadInteger32 ();
					break;
					}
				case "PageKey" : {
					PageKey = JSONReader.ReadString ();
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
	/// Describes the proposed account properties. Currently, these are limited
	/// to the account name but could be extended in future versions of the protocol.
	/// </summary>
	public partial class ValidateRequest : MeshRequest {
        /// <summary>
        ///Account name requested
        /// </summary>

		public virtual string						Account  {get; set;}
		bool								__Reserve = false;
		private bool						_Reserve;
        /// <summary>
        ///If true, request a reservation for the specified account name.
        ///Note that the service is not obliged to honor reservation 
        ///requests.
        /// </summary>

		public virtual bool						Reserve {
			get => _Reserve;
			set {_Reserve = value; __Reserve = true; }
			}
        /// <summary>
        ///List of ISO language codes in order of preference. For creating
        ///explanatory text.
        /// </summary>

		public virtual List<string>				Language  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ValidateRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ValidateRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (__Reserve){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Reserve", 1);
					_Writer.WriteBoolean (Reserve);
				}
			if (Language != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Language", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Language) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ValidateRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ValidateRequest;
				}
		    var Result = new ValidateRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "Reserve" : {
					Reserve = JSONReader.ReadBoolean ();
					break;
					}
				case "Language" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Language = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Language.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// States whether the proposed account properties are acceptable and
	/// (optional) returns an indication of what properties are valid.
	/// Note that receiving a 'Valid' responseto a Validate Request does
	/// not guarantee creation of the account. In addition to the possibility 
	/// that the account namecould be requested by another user between the 
	/// Validate and Create transactions, a portal service MAY perform more 
	/// stringent validation criteria when an account is actually being 
	/// created. For example, checking with the authoritative list of
	/// current accounts rather than a cached copy.
	/// </summary>
	public partial class ValidateResponse : MeshResponse {
		bool								__Valid = false;
		private bool						_Valid;
        /// <summary>
        ///If true, the specified account identifier is acceptable. If false,
        ///the account identifier is rejected.
        /// </summary>

		public virtual bool						Valid {
			get => _Valid;
			set {_Valid = value; __Valid = true; }
			}
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
        ///Text explaining the reason an account name was rejected.
        /// </summary>

		public virtual string						Reason  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ValidateResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ValidateResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (__Valid){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Valid", 1);
					_Writer.WriteBoolean (Valid);
				}
			if (__Minimum){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Minimum", 1);
					_Writer.WriteInteger32 (Minimum);
				}
			if (__Maximum){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Maximum", 1);
					_Writer.WriteInteger32 (Maximum);
				}
			if (InvalidCharacters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("InvalidCharacters", 1);
					_Writer.WriteString (InvalidCharacters);
				}
			if (Reason != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Reason", 1);
					_Writer.WriteString (Reason);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ValidateResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ValidateResponse;
				}
		    var Result = new ValidateResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Valid" : {
					Valid = JSONReader.ReadBoolean ();
					break;
					}
				case "Minimum" : {
					Minimum = JSONReader.ReadInteger32 ();
					break;
					}
				case "Maximum" : {
					Maximum = JSONReader.ReadInteger32 ();
					break;
					}
				case "InvalidCharacters" : {
					InvalidCharacters = JSONReader.ReadString ();
					break;
					}
				case "Reason" : {
					Reason = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
	public partial class CreateRequest : MeshRequest {
        /// <summary>
        ///Account identifier requested.
        /// </summary>

		public virtual string						Account  {get; set;}
        /// <summary>
        ///User profile of account to be created. The profile MUST specify the 
        ///account being created as an account.
        /// </summary>

		public virtual SignedProfile						Profile  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CreateRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CreateRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (Profile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Profile", 1);
					// expand this to a tagged structure
					//Profile.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Profile._Tag, 1);
						bool firstinner = true;
						Profile.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CreateRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CreateRequest;
				}
		    var Result = new CreateRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "Profile" : {
					Profile = SignedProfile.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
	public partial class CreateResponse : MeshResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CreateResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CreateResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CreateResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CreateResponse;
				}
		    var Result = new CreateResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request deletion of a new portal account. The request specifies
	/// the requested account identifier.
	/// </summary>
	public partial class DeleteRequest : MeshRequest {
        /// <summary>
        ///Account identifier to be deleted.
        /// </summary>

		public virtual string						Account  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DeleteRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new DeleteRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new DeleteRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DeleteRequest;
				}
		    var Result = new DeleteRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
	public partial class DeleteResponse : MeshResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DeleteResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new DeleteResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new DeleteResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DeleteResponse;
				}
		    var Result = new DeleteResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes the Portal or Mesh data to be retreived.
	/// </summary>
	public partial class GetRequest : MeshRequest {
        /// <summary>
        ///Lookup by profile ID
        /// </summary>

		public virtual string						Identifier  {get; set;}
        /// <summary>
        ///Lookup by Account ID
        /// </summary>

		public virtual string						Account  {get; set;}
        /// <summary>
        ///List of KeyValue pairs specifying the conditions to be met
        /// </summary>

		public virtual List<KeyValue>				KeyValues  {get; set;}
        /// <summary>
        ///Constrain the search to a specific time interval and/or 
        ///limit the number and/or total size of data records returned.
        /// </summary>

		public virtual SearchConstraints						SearchConstraints  {get; set;}
		bool								__Multiple = false;
		private bool						_Multiple;
        /// <summary>
        ///If true return multiple responses if available
        /// </summary>

		public virtual bool						Multiple {
			get => _Multiple;
			set {_Multiple = value; __Multiple = true; }
			}
		bool								__Full = false;
		private bool						_Full;
        /// <summary>
        ///If true, the client requests that the full Mesh data record 
        ///be returned containing both the Mesh entry itself and the 
        ///Mesh metadata that allows the date and time of the 
        ///publication of the Mesh entry to be verified.
        /// </summary>

		public virtual bool						Full {
			get => _Full;
			set {_Full = value; __Full = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "GetRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new GetRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
				}
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (KeyValues != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyValues", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeyValues) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (SearchConstraints != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SearchConstraints", 1);
					SearchConstraints.Serialize (_Writer, false);
				}
			if (__Multiple){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Multiple", 1);
					_Writer.WriteBoolean (Multiple);
				}
			if (__Full){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Full", 1);
					_Writer.WriteBoolean (Full);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new GetRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetRequest;
				}
		    var Result = new GetRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					Identifier = JSONReader.ReadString ();
					break;
					}
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "KeyValues" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					KeyValues = new List <KeyValue> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  KeyValue ();
						_Item.Deserialize (JSONReader);
						// var _Item = new KeyValue (JSONReader);
						KeyValues.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "SearchConstraints" : {
					// An untagged structure
					SearchConstraints = new SearchConstraints ();
					SearchConstraints.Deserialize (JSONReader);
 
					break;
					}
				case "Multiple" : {
					Multiple = JSONReader.ReadBoolean ();
					break;
					}
				case "Full" : {
					Full = JSONReader.ReadBoolean ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a Get transaction. If a Mesh entry
	/// matching the specified profile is found, containsthe list of entries
	/// matching the request.
	/// </summary>
	public partial class GetResponse : MeshResponse {
        /// <summary>
        ///List of entries matching the request.
        /// </summary>

		public virtual List<Entry>				Entries  {get; set;}
        /// <summary>
        ///List of mesh data records matching the request.
        /// </summary>

		public virtual List<DataItem>				DataItems  {get; set;}
        /// <summary>
        ///If non-null, indicates that the number and/or size of the data records
        ///returned exceeds either the SearchConstraints specified in the
        ///request or internal server limits.
        /// </summary>

		public virtual string						PageKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "GetResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new GetResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (DataItems != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DataItems", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DataItems) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (PageKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PageKey", 1);
					_Writer.WriteString (PageKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new GetResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetResponse;
				}
		    var Result = new GetResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <Entry> ();
					while (_Going) {
						var _Item = Entry.FromJSON (JSONReader, true); // a tagged structure
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "DataItems" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DataItems = new List <DataItem> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DataItem ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DataItem (JSONReader);
						DataItems.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "PageKey" : {
					PageKey = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Requests publication of the specified Mesh entry.
	/// </summary>
	public partial class PublishRequest : MeshRequest {
        /// <summary>
        ///Signed profile to be published.
        /// </summary>

		public virtual Entry						Entry  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "PublishRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new PublishRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Entry != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entry", 1);
					// expand this to a tagged structure
					//Entry.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Entry._Tag, 1);
						bool firstinner = true;
						Entry.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new PublishRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PublishRequest;
				}
		    var Result = new PublishRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entry" : {
					Entry = Entry.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a Publish transaction.
	/// </summary>
	public partial class PublishResponse : MeshResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "PublishResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new PublishResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new PublishResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PublishResponse;
				}
		    var Result = new PublishResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Initiates a status transaction.
	/// </summary>
	public partial class StatusRequest : MeshRequest {
		
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
		public static new JSONObject _Factory () => new StatusRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new StatusRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as StatusRequest;
				}
		    var Result = new StatusRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a Status transaction.
	/// </summary>
	public partial class StatusResponse : MeshResponse {
        /// <summary>
        ///Time that the last write update was made to the Mesh
        /// </summary>

		public virtual DateTime?						LastWriteTime  {get; set;}
        /// <summary>
        ///Time that the last Mesh checkpoint was calculated.
        /// </summary>

		public virtual DateTime?						LastCheckpointTime  {get; set;}
        /// <summary>
        ///Time at which the next Mesh checkpoint should be calculated.
        /// </summary>

		public virtual DateTime?						NextCheckpointTime  {get; set;}
        /// <summary>
        ///Last checkpoint value.
        /// </summary>

		public virtual string						CheckpointValue  {get; set;}
		
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
		public static new JSONObject _Factory () => new StatusResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (LastWriteTime != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastWriteTime", 1);
					_Writer.WriteDateTime (LastWriteTime);
				}
			if (LastCheckpointTime != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastCheckpointTime", 1);
					_Writer.WriteDateTime (LastCheckpointTime);
				}
			if (NextCheckpointTime != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NextCheckpointTime", 1);
					_Writer.WriteDateTime (NextCheckpointTime);
				}
			if (CheckpointValue != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CheckpointValue", 1);
					_Writer.WriteString (CheckpointValue);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new StatusResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as StatusResponse;
				}
		    var Result = new StatusResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "LastWriteTime" : {
					LastWriteTime = JSONReader.ReadDateTime ();
					break;
					}
				case "LastCheckpointTime" : {
					LastCheckpointTime = JSONReader.ReadDateTime ();
					break;
					}
				case "NextCheckpointTime" : {
					NextCheckpointTime = JSONReader.ReadDateTime ();
					break;
					}
				case "CheckpointValue" : {
					CheckpointValue = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Initial device connection request.
	/// </summary>
	public partial class ConnectStartRequest : MeshRequest {
        /// <summary>
        ///Device connection request signed by thesignature key of the 
        ///device requesting connection.
        /// </summary>

		public virtual SignedConnectionRequest						SignedRequest  {get; set;}
        /// <summary>
        ///Account identifier of account to which the device is requesting
        ///connection.
        /// </summary>

		public virtual string						AccountID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectStartRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectStartRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (SignedRequest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedRequest", 1);
					SignedRequest.Serialize (_Writer, false);
				}
			if (AccountID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountID", 1);
					_Writer.WriteString (AccountID);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectStartRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectStartRequest;
				}
		    var Result = new ConnectStartRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedRequest" : {
					// An untagged structure
					SignedRequest = new SignedConnectionRequest ();
					SignedRequest.Deserialize (JSONReader);
 
					break;
					}
				case "AccountID" : {
					AccountID = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a ConnectStart transaction.
	/// </summary>
	public partial class ConnectStartResponse : MeshRequest {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectStartResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectStartResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectStartResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectStartResponse;
				}
		    var Result = new ConnectStartResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request status information for a pending request posted
	/// previously.
	/// </summary>
	public partial class ConnectStatusRequest : MeshRequest {
        /// <summary>
        ///Account identifier for which pending connection information
        ///is requested.
        /// </summary>

		public virtual string						AccountID  {get; set;}
        /// <summary>
        ///Device identifier of device requesting status information.
        /// </summary>

		public virtual string						DeviceID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectStatusRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectStatusRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (AccountID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountID", 1);
					_Writer.WriteString (AccountID);
				}
			if (DeviceID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceID", 1);
					_Writer.WriteString (DeviceID);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectStatusRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectStatusRequest;
				}
		    var Result = new ConnectStatusRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AccountID" : {
					AccountID = JSONReader.ReadString ();
					break;
					}
				case "DeviceID" : {
					DeviceID = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a ConnectStatus transaction.
	/// </summary>
	public partial class ConnectStatusResponse : MeshRequest {
        /// <summary>
        ///The signed ConnectionResult object.
        /// </summary>

		public virtual SignedConnectionResult						Result  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectStatusResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectStatusResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Result != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Result", 1);
					Result.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectStatusResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectStatusResponse;
				}
		    var Result = new ConnectStatusResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					// An untagged structure
					Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Specify the criteria for pending requests.
	/// </summary>
	public partial class ConnectPendingRequest : MeshRequest {
        /// <summary>
        ///The account identifier of the account for which
        ///pending connection requests are requested.
        /// </summary>

		public virtual string						AccountID  {get; set;}
        /// <summary>
        ///Constrain the search to a specific time interval and/or 
        ///limit the number and/or total size of data records returned.
        /// </summary>

		public virtual SearchConstraints						SearchConstraints  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectPendingRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectPendingRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (AccountID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountID", 1);
					_Writer.WriteString (AccountID);
				}
			if (SearchConstraints != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SearchConstraints", 1);
					SearchConstraints.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectPendingRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectPendingRequest;
				}
		    var Result = new ConnectPendingRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AccountID" : {
					AccountID = JSONReader.ReadString ();
					break;
					}
				case "SearchConstraints" : {
					// An untagged structure
					SearchConstraints = new SearchConstraints ();
					SearchConstraints.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a ConnectPending transaction.
	/// </summary>
	public partial class ConnectPendingResponse : MeshRequest {
        /// <summary>
        ///A list of pending requests satisfying the criteria set out
        ///in the request.
        /// </summary>

		public virtual List<SignedConnectionRequest>				Pending  {get; set;}
        /// <summary>
        ///If non-null, indicates that the number and/or size of the data records
        ///returned exceeds either the SearchConstraints specified in the
        ///request or internal server limits.
        /// </summary>

		public virtual string						PageKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectPendingResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectPendingResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Pending != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Pending", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Pending) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (PageKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PageKey", 1);
					_Writer.WriteString (PageKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectPendingResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectPendingResponse;
				}
		    var Result = new ConnectPendingResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Pending" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Pending = new List <SignedConnectionRequest> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  SignedConnectionRequest ();
						_Item.Deserialize (JSONReader);
						// var _Item = new SignedConnectionRequest (JSONReader);
						Pending.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "PageKey" : {
					PageKey = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a ConnectComplete transaction.
	/// </summary>
	public partial class ConnectCompleteRequest : MeshRequest {
        /// <summary>
        ///The connection result to be posted to the portal. The result MUST
        ///be signed by a valid administration key for the Mesh profile.
        /// </summary>

		public virtual SignedConnectionResult						Result  {get; set;}
        /// <summary>
        ///The account identifier to which the connection result is
        ///posted.
        /// </summary>

		public virtual string						AccountID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectCompleteRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectCompleteRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Result != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Result", 1);
					Result.Serialize (_Writer, false);
				}
			if (AccountID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountID", 1);
					_Writer.WriteString (AccountID);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectCompleteRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectCompleteRequest;
				}
		    var Result = new ConnectCompleteRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					// An untagged structure
					Result = new SignedConnectionResult ();
					Result.Deserialize (JSONReader);
 
					break;
					}
				case "AccountID" : {
					AccountID = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a ConnectComplete transaction.
	/// </summary>
	public partial class ConnectCompleteResponse : MeshRequest {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectCompleteResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectCompleteResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectCompleteResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectCompleteResponse;
				}
		    var Result = new ConnectCompleteResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Request a bulk transfer of the log between the specified transaction
	/// identifiers. Requires appropriate authorization
	/// </summary>
	public partial class TransferRequest : MeshRequest {
        /// <summary>
        ///Constrain the search to a specific time interval and/or 
        ///limit the number and/or total size of data records returned.
        /// </summary>

		public virtual SearchConstraints						SearchConstraints  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "TransferRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new TransferRequest();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (SearchConstraints != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SearchConstraints", 1);
					SearchConstraints.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new TransferRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as TransferRequest;
				}
		    var Result = new TransferRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SearchConstraints" : {
					// An untagged structure
					SearchConstraints = new SearchConstraints ();
					SearchConstraints.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Reports the success or failure of a Transfer transaction.
	/// If successful, contains the list of Mesh records to be transferred.
	/// </summary>
	public partial class TransferResponse : MeshResponse {
        /// <summary>
        ///List of mesh data records matching the request.
        /// </summary>

		public virtual List<DataItem>				DataItems  {get; set;}
        /// <summary>
        ///If non-null, indicates that the number and/or size of the data records
        ///returned exceeds either the SearchConstraints specified in the
        ///request or internal server limits.
        /// </summary>

		public virtual string						PageKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "TransferResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new TransferResponse();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (DataItems != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DataItems", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DataItems) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (PageKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PageKey", 1);
					_Writer.WriteString (PageKey);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new TransferResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as TransferResponse;
				}
		    var Result = new TransferResponse ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DataItems" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DataItems = new List <DataItem> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DataItem ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DataItem (JSONReader);
						DataItems.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "PageKey" : {
					PageKey = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

