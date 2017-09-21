
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
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;



using Goedel.Cryptography.Jose;
using Goedel.Mesh;


namespace Goedel.Recrypt {


	/// <summary>
	///
	/// Mesh/Recrypt Protocol Schema
	/// Mesh/Recrypt group administration protocol
	/// </summary>
	public abstract partial class RecryptProtocol : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return _Tag;
			}

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "RecryptProtocol";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"RecryptRequest", RecryptRequest._Factory},
			{"RecryptResponse", RecryptResponse._Factory},
			{"CreateGroupRequest", CreateGroupRequest._Factory},
			{"CreateGroupResponse", CreateGroupResponse._Factory},
			{"UpdateGroupRequest", UpdateGroupRequest._Factory},
			{"UpdateGroupResponse", UpdateGroupResponse._Factory},
			{"GetGroupRequest", GetGroupRequest._Factory},
			{"GetGroupResponse", GetGroupResponse._Factory},
			{"AddMemberRequest", AddMemberRequest._Factory},
			{"AddMemberResponse", AddMemberResponse._Factory},
			{"UpdateMemberRequest", UpdateMemberRequest._Factory},
			{"UpdateMemberResponse", UpdateMemberResponse._Factory},
			{"GetKeyRequest", GetKeyRequest._Factory},
			{"GetKeyResponse", GetKeyResponse._Factory},
			{"RecryptDataRequest", RecryptDataRequest._Factory},
			{"RecryptDataResponse", RecryptDataResponse._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
			Out = JSONReader.ReadTaggedObject (_TagDictionary);
            }
		}



		// Service Dispatch Classes


    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class RecryptService : Goedel.Protocol.JPCInterface {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "recrypt";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown {
			get => WellKnown;
			}

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_recrypt._tcp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetDiscovery {
			get => Discovery;
			}

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
                HelloRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  CreateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual CreateGroupResponse CreateGroup (
                CreateGroupRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  UpdateGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual UpdateGroupResponse UpdateGroup (
                UpdateGroupRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  GetGroup.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual GetGroupResponse GetGroup (
                GetGroupRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  AddMember.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual AddMemberResponse AddMember (
                AddMemberRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  UpdateMember.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual UpdateMemberResponse UpdateMember (
                UpdateMemberRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  GetKey.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual GetKeyResponse GetKey (
                GetKeyRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  RecryptData.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual RecryptDataResponse RecryptData (
                RecryptDataRequest Request) {
            return null;
            }

        }

    /// <summary>
	/// Client class for RecryptService.
    /// </summary>		
    public partial class RecryptServiceClient : RecryptService {
 		
		JPCRemoteSession JPCRemoteSession;
        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public override JPCSession JPCSession {
			get {return JPCRemoteSession;}
			set {JPCRemoteSession = value as JPCRemoteSession; }
			}


        /// <summary>
		/// Create a client connection to the specified service.
        /// </summary>	
        /// <param name="JPCRemoteSession">The remote session to connect to</param>
		public RecryptServiceClient (JPCRemoteSession JPCRemoteSession) {
			this.JPCRemoteSession = JPCRemoteSession;
			}


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
        public override CreateGroupResponse CreateGroup (
                CreateGroupRequest Request) {

            var ResponseData = JPCRemoteSession.Post("CreateGroup", Request);
            var Response = CreateGroupResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override UpdateGroupResponse UpdateGroup (
                UpdateGroupRequest Request) {

            var ResponseData = JPCRemoteSession.Post("UpdateGroup", Request);
            var Response = UpdateGroupResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override GetGroupResponse GetGroup (
                GetGroupRequest Request) {

            var ResponseData = JPCRemoteSession.Post("GetGroup", Request);
            var Response = GetGroupResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override AddMemberResponse AddMember (
                AddMemberRequest Request) {

            var ResponseData = JPCRemoteSession.Post("AddMember", Request);
            var Response = AddMemberResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override UpdateMemberResponse UpdateMember (
                UpdateMemberRequest Request) {

            var ResponseData = JPCRemoteSession.Post("UpdateMember", Request);
            var Response = UpdateMemberResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override GetKeyResponse GetKey (
                GetKeyRequest Request) {

            var ResponseData = JPCRemoteSession.Post("GetKey", Request);
            var Response = GetKeyResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override RecryptDataResponse RecryptData (
                RecryptDataRequest Request) {

            var ResponseData = JPCRemoteSession.Post("RecryptData", Request);
            var Response = RecryptDataResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

		}


    /// <summary>
	/// Client class for RecryptService.
    /// </summary>		
    public partial class RecryptServiceProvider : Goedel.Protocol.JPCProvider {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public RecryptService Service;


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
				case "CreateGroup" : {
					var Request = new CreateGroupRequest();
					Request.Deserialize (JSONReader);
					Response = Service.CreateGroup (Request);
					break;
					}
				case "UpdateGroup" : {
					var Request = new UpdateGroupRequest();
					Request.Deserialize (JSONReader);
					Response = Service.UpdateGroup (Request);
					break;
					}
				case "GetGroup" : {
					var Request = new GetGroupRequest();
					Request.Deserialize (JSONReader);
					Response = Service.GetGroup (Request);
					break;
					}
				case "AddMember" : {
					var Request = new AddMemberRequest();
					Request.Deserialize (JSONReader);
					Response = Service.AddMember (Request);
					break;
					}
				case "UpdateMember" : {
					var Request = new UpdateMemberRequest();
					Request.Deserialize (JSONReader);
					Response = Service.UpdateMember (Request);
					break;
					}
				case "GetKey" : {
					var Request = new GetKeyRequest();
					Request.Deserialize (JSONReader);
					Response = Service.GetKey (Request);
					break;
					}
				case "RecryptData" : {
					var Request = new RecryptDataRequest();
					Request.Deserialize (JSONReader);
					Response = Service.RecryptData (Request);
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
	public partial class RecryptRequest : Goedel.Protocol.Request {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "RecryptRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new RecryptRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
        public static new RecryptRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptRequest;
				}
		    var Result = new RecryptRequest ();
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
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
	public partial class RecryptResponse : Goedel.Protocol.Response {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "RecryptResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new RecryptResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
        public static new RecryptResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptResponse;
				}
		    var Result = new RecryptResponse ();
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
	/// Request creation of a recryption group. The only
	/// request parameter describes the group to be created.
	/// </summary>
	public partial class CreateGroupRequest : RecryptRequest {
        /// <summary>
        ///The Recryption Group to create	
        /// </summary>

		public virtual RecryptionGroup						RecryptionGroup  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CreateGroupRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CreateGroupRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (RecryptionGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionGroup", 1);
					RecryptionGroup.Serialize (_Writer, false);
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
        public static new CreateGroupRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CreateGroupRequest;
				}
		    var Result = new CreateGroupRequest ();
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
				case "RecryptionGroup" : {
					// An untagged structure
					RecryptionGroup = new RecryptionGroup ();
					RecryptionGroup.Deserialize (JSONReader);
 
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
	/// Reports the success or failure of a CreateGroup request. The
	/// operation either succeeds or fails, there are no returned
	/// parameters
	/// </summary>
	public partial class CreateGroupResponse : RecryptResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CreateGroupResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CreateGroupResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
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
        public static new CreateGroupResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CreateGroupResponse;
				}
		    var Result = new CreateGroupResponse ();
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
	/// Request an update to a recryption group. 
	/// Note that the update 
	/// process is currently limited to 'strike and replace'. This is 
	/// likely to become cumbersome if groups with very large numbers 
	/// of entries are being maintained. It is likely that a future 
	/// version of the protocol will support update requests that
	/// implement commonly occurring tasks such as updates to 
	/// add a new encryption key, etc.
	/// </summary>
	public partial class UpdateGroupRequest : RecryptRequest {
        /// <summary>
        ///The Recryption Group to create	
        /// </summary>

		public virtual RecryptionGroup						RecryptionGroup  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateGroupRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateGroupRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (RecryptionGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionGroup", 1);
					RecryptionGroup.Serialize (_Writer, false);
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
        public static new UpdateGroupRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateGroupRequest;
				}
		    var Result = new UpdateGroupRequest ();
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
				case "RecryptionGroup" : {
					// An untagged structure
					RecryptionGroup = new RecryptionGroup ();
					RecryptionGroup.Deserialize (JSONReader);
 
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
	/// Reports the success or failure of a UpdateGroup request. The
	/// operation either succeeds or fails, there are no returned
	/// parameters
	/// </summary>
	public partial class UpdateGroupResponse : RecryptResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateGroupResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateGroupResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
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
        public static new UpdateGroupResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateGroupResponse;
				}
		    var Result = new UpdateGroupResponse ();
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
	/// Obtain recryption group data
	/// </summary>
	public partial class GetGroupRequest : RecryptRequest {
        /// <summary>
        ///The UDF fingerprint of the recryption group to add the member to.
        /// </summary>

		public virtual string						GroupID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetGroupRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetGroupRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (GroupID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("GroupID", 1);
					_Writer.WriteString (GroupID);
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
        public static new GetGroupRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetGroupRequest;
				}
		    var Result = new GetGroupRequest ();
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
				case "GroupID" : {
					GroupID = JSONReader.ReadString ();
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
	/// Obtain recryption group response.
	/// </summary>
	public partial class GetGroupResponse : RecryptResponse {
        /// <summary>
        ///The Recryption Group to create	
        /// </summary>

		public virtual RecryptionGroup						RecryptionGroup  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetGroupResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetGroupResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
			if (RecryptionGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionGroup", 1);
					RecryptionGroup.Serialize (_Writer, false);
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
        public static new GetGroupResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetGroupResponse;
				}
		    var Result = new GetGroupResponse ();
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
				case "RecryptionGroup" : {
					// An untagged structure
					RecryptionGroup = new RecryptionGroup ();
					RecryptionGroup.Deserialize (JSONReader);
 
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
	/// Add a member to a recryption group (not currently used)
	/// </summary>
	public partial class AddMemberRequest : RecryptRequest {
        /// <summary>
        ///The UDF fingerprint of the recryption group to add the member to.
        /// </summary>

		public virtual string						RecryptionGroup  {get; set;}
        /// <summary>
        ///Describes the member(s) to add
        /// </summary>

		public virtual List<MemberEntry>				MemberEntry  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AddMemberRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AddMemberRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (RecryptionGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionGroup", 1);
					_Writer.WriteString (RecryptionGroup);
				}
			if (MemberEntry != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MemberEntry", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MemberEntry) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
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
        public static new AddMemberRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AddMemberRequest;
				}
		    var Result = new AddMemberRequest ();
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
				case "RecryptionGroup" : {
					RecryptionGroup = JSONReader.ReadString ();
					break;
					}
				case "MemberEntry" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MemberEntry = new List <MemberEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  MemberEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new MemberEntry (JSONReader);
						MemberEntry.Add (_Item);
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
	/// Reports the success or failure of a AddMember request. The
	/// operation either succeeds or fails, there are no returned
	/// parameters
	/// </summary>
	public partial class AddMemberResponse : RecryptResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AddMemberResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AddMemberResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
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
        public static new AddMemberResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AddMemberResponse;
				}
		    var Result = new AddMemberResponse ();
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
	/// Update a recryption group member entry (not currently used)
	/// </summary>
	public partial class UpdateMemberRequest : RecryptRequest {
        /// <summary>
        ///The UDF fingerprint of the recryption group in which the member entries is to be updated
        /// </summary>

		public virtual string						RecryptionGroup  {get; set;}
        /// <summary>
        ///Describes the member(s) to add
        /// </summary>

		public virtual List<MemberEntry>				MemberEntry  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateMemberRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateMemberRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (RecryptionGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionGroup", 1);
					_Writer.WriteString (RecryptionGroup);
				}
			if (MemberEntry != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MemberEntry", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MemberEntry) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
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
        public static new UpdateMemberRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateMemberRequest;
				}
		    var Result = new UpdateMemberRequest ();
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
				case "RecryptionGroup" : {
					RecryptionGroup = JSONReader.ReadString ();
					break;
					}
				case "MemberEntry" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MemberEntry = new List <MemberEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  MemberEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new MemberEntry (JSONReader);
						MemberEntry.Add (_Item);
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
	/// Reports the success or failure of a UpdateMember request. The
	/// operation either succeeds or fails, there are no returned
	/// parameters
	/// </summary>
	public partial class UpdateMemberResponse : RecryptResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateMemberResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateMemberResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
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
        public static new UpdateMemberResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateMemberResponse;
				}
		    var Result = new UpdateMemberResponse ();
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
	/// Request the current recryption key for the specified recryption group.
	/// NB: At present the group key is NOT authenticated and thus a MITM can
	/// perform a key substituition attack. This will be fixed in the next 
	/// release.
	/// </summary>
	public partial class GetKeyRequest : RecryptRequest {
        /// <summary>
        ///The recryption group for which the key data is requested.
        /// </summary>

		public virtual string						GroupID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetKeyRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetKeyRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (GroupID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("GroupID", 1);
					_Writer.WriteString (GroupID);
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
        public static new GetKeyRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetKeyRequest;
				}
		    var Result = new GetKeyRequest ();
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
				case "GroupID" : {
					GroupID = JSONReader.ReadString ();
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
	/// Response to get key request.
	/// </summary>
	public partial class GetKeyResponse : RecryptResponse {
        /// <summary>
        ///The signed key entry
        /// </summary>

		public virtual JoseWebSignature						SignedKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetKeyResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetKeyResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
			if (SignedKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedKey", 1);
					SignedKey.Serialize (_Writer, false);
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
        public static new GetKeyResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as GetKeyResponse;
				}
		    var Result = new GetKeyResponse ();
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
				case "SignedKey" : {
					// An untagged structure
					SignedKey = new JoseWebSignature ();
					SignedKey.Deserialize (JSONReader);
 
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
	/// Request that the service provide a recryption result for the specified
	/// encrypted data and return it encrypted under the user's public key.
	/// </summary>
	public partial class RecryptDataRequest : RecryptRequest {
        /// <summary>
        ///The member Mesh profile UDF
        /// </summary>

		public virtual string						MemberUDF  {get; set;}
        /// <summary>
        ///The member key fingerprint
        /// </summary>

		public virtual string						MemberKeyUDF  {get; set;}
        /// <summary>
        ///The key identifier of the group key to which the data is encrypted
        /// </summary>

		public virtual string						GroupKeyID  {get; set;}
        /// <summary>
        ///The ephemeral key 
        /// </summary>

		public virtual Key						EphemeralKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "RecryptDataRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new RecryptDataRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptRequest)this).SerializeX(_Writer, false, ref _first);
			if (MemberUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MemberUDF", 1);
					_Writer.WriteString (MemberUDF);
				}
			if (MemberKeyUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MemberKeyUDF", 1);
					_Writer.WriteString (MemberKeyUDF);
				}
			if (GroupKeyID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("GroupKeyID", 1);
					_Writer.WriteString (GroupKeyID);
				}
			if (EphemeralKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EphemeralKey", 1);
					// expand this to a tagged structure
					//EphemeralKey.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(EphemeralKey.Tag(), 1);
						bool firstinner = true;
						EphemeralKey.Serialize (_Writer, true, ref firstinner);
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
        public static new RecryptDataRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptDataRequest;
				}
		    var Result = new RecryptDataRequest ();
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
				case "MemberUDF" : {
					MemberUDF = JSONReader.ReadString ();
					break;
					}
				case "MemberKeyUDF" : {
					MemberKeyUDF = JSONReader.ReadString ();
					break;
					}
				case "GroupKeyID" : {
					GroupKeyID = JSONReader.ReadString ();
					break;
					}
				case "EphemeralKey" : {
					EphemeralKey = Key.FromJSON (JSONReader, true) ;  // A tagged structure
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
	/// Result of recryption request.
	/// </summary>
	public partial class RecryptDataResponse : RecryptResponse {
        /// <summary>
        ///The partial decryption information to use to complete the key agreement
        /// </summary>

		public virtual byte[]						Partial  {get; set;}
        /// <summary>
        ///The partial decryption information to use to complete the key agreement encrypted
        ///under the user's key.
        /// </summary>

		public virtual JoseWebEncryption						EncryptedPartial  {get; set;}
        /// <summary>
        ///The decryption key to use to complete the decryption encrypted
        ///under the user's key.
        /// </summary>

		public virtual JoseWebEncryption						DecryptionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "RecryptDataResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new RecryptDataResponse();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			((RecryptResponse)this).SerializeX(_Writer, false, ref _first);
			if (Partial != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Partial", 1);
					_Writer.WriteBinary (Partial);
				}
			if (EncryptedPartial != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedPartial", 1);
					EncryptedPartial.Serialize (_Writer, false);
				}
			if (DecryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptionKey", 1);
					DecryptionKey.Serialize (_Writer, false);
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
        public static new RecryptDataResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptDataResponse;
				}
		    var Result = new RecryptDataResponse ();
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
				case "Partial" : {
					Partial = JSONReader.ReadBinary ();
					break;
					}
				case "EncryptedPartial" : {
					// An untagged structure
					EncryptedPartial = new JoseWebEncryption ();
					EncryptedPartial.Deserialize (JSONReader);
 
					break;
					}
				case "DecryptionKey" : {
					// An untagged structure
					DecryptionKey = new JoseWebEncryption ();
					DecryptionKey.Deserialize (JSONReader);
 
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

