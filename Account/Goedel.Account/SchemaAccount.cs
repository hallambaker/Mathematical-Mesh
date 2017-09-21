
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


namespace Goedel.Account {


	/// <summary>
	///
	/// Mesh/Account protocol schema.
	/// </summary>
	public abstract partial class AccountProtocol : global::Goedel.Protocol.JSONObject {

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
		public override string _Tag { get; } = "AccountProtocol";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"AccountRequest", AccountRequest._Factory},
			{"AccountResponse", AccountResponse._Factory},
			{"AccountData", AccountData._Factory},
			{"AccountDataEntry", AccountDataEntry._Factory},
			{"CreateRequest", CreateRequest._Factory},
			{"CreateResponse", CreateResponse._Factory},
			{"DeleteRequest", DeleteRequest._Factory},
			{"DeleteResponse", DeleteResponse._Factory},
			{"UpdateRequest", UpdateRequest._Factory},
			{"UpdateResponse", UpdateResponse._Factory},
			{"GetRequest", GetRequest._Factory},
			{"GetResponse", GetResponse._Factory}			};

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
    public abstract partial class AccountService : Goedel.Protocol.JPCInterface {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "mmmaccount";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown {
			get => WellKnown;
			}

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_mmmaccount._tcp";

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
		/// Base method for implementing the transaction  Create.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual CreateResponse Create (
                CreateRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  Delete.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual DeleteResponse Delete (
                DeleteRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  Update.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual UpdateResponse Update (
                UpdateRequest Request) {
            return null;
            }

        /// <summary>
		/// Base method for implementing the transaction  Get.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual GetResponse Get (
                GetRequest Request) {
            return null;
            }

        }

    /// <summary>
	/// Client class for AccountService.
    /// </summary>		
    public partial class AccountServiceClient : AccountService {
 		
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
		public AccountServiceClient (JPCRemoteSession JPCRemoteSession) {
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
        public override CreateResponse Create (
                CreateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Create", Request);
            var Response = CreateResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override DeleteResponse Delete (
                DeleteRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Delete", Request);
            var Response = DeleteResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override UpdateResponse Update (
                UpdateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Update", Request);
            var Response = UpdateResponse.FromJSON(ResponseData.JSONReader(), true);

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

		}


    /// <summary>
	/// Client class for AccountService.
    /// </summary>		
    public partial class AccountServiceProvider : Goedel.Protocol.JPCProvider {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public AccountService Service;


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
				case "Create" : {
					var Request = new CreateRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Create (Request);
					break;
					}
				case "Delete" : {
					var Request = new DeleteRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Delete (Request);
					break;
					}
				case "Update" : {
					var Request = new UpdateRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Update (Request);
					break;
					}
				case "Get" : {
					var Request = new GetRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Get (Request);
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
	public partial class AccountRequest : Goedel.Protocol.Request {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AccountRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AccountRequest();
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
        public static new AccountRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountRequest;
				}
		    var Result = new AccountRequest ();
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
	/// A service MAY return either the response message specified
	/// for that transaction or any parent of that message. 
	/// Thus the RecryptResponse message MAY be returned in response 
	/// to any request.
	/// </summary>
	public partial class AccountResponse : Goedel.Protocol.Response {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AccountResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AccountResponse();
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
        public static new AccountResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountResponse;
				}
		    var Result = new AccountResponse ();
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
	/// The data associated with an account
	/// </summary>
	public partial class AccountData : AccountProtocol {
        /// <summary>
        ///The account identifier
        /// </summary>

		public virtual string						AccountId  {get; set;}
        /// <summary>
        ///Date and time that the account identifier was created.
        /// </summary>

		public virtual DateTime?						Created  {get; set;}
        /// <summary>
        ///Account status
        /// </summary>

		public virtual string						Status  {get; set;}
        /// <summary>
        ///Fingerprint of the user's mesh profile
        /// </summary>

		public virtual string						MeshUDF  {get; set;}
        /// <summary>
        ///Mesh Portal identifier
        /// </summary>

		public virtual List<string>				Portal  {get; set;}
        /// <summary>
        ///Service specific data
        /// </summary>

		public virtual List<AccountDataEntry>				Entries  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AccountData";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AccountData();
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
			if (AccountId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountId", 1);
					_Writer.WriteString (AccountId);
				}
			if (Created != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Created", 1);
					_Writer.WriteDateTime (Created);
				}
			if (Status != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Status", 1);
					_Writer.WriteString (Status);
				}
			if (MeshUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MeshUDF", 1);
					_Writer.WriteString (MeshUDF);
				}
			if (Portal != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Portal", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Portal) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
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
        public static new AccountData FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountData;
				}
		    var Result = new AccountData ();
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
				case "AccountId" : {
					AccountId = JSONReader.ReadString ();
					break;
					}
				case "Created" : {
					Created = JSONReader.ReadDateTime ();
					break;
					}
				case "Status" : {
					Status = JSONReader.ReadString ();
					break;
					}
				case "MeshUDF" : {
					MeshUDF = JSONReader.ReadString ();
					break;
					}
				case "Portal" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Portal = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Portal.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <AccountDataEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  AccountDataEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new AccountDataEntry (JSONReader);
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Superclass for all account data entry objects
	/// </summary>
	public partial class AccountDataEntry : AccountProtocol {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "AccountDataEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new AccountDataEntry();
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
        public static new AccountDataEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountDataEntry;
				}
		    var Result = new AccountDataEntry ();
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
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Create a new account
	/// </summary>
	public partial class CreateRequest : AccountRequest {
        /// <summary>
        ///Describes the account to be created
        /// </summary>

		public virtual AccountData						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CreateRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CreateRequest();
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
			((AccountRequest)this).SerializeX(_Writer, false, ref _first);
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					Data.Serialize (_Writer, false);
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
				case "Data" : {
					// An untagged structure
					Data = new AccountData ();
					Data.Deserialize (JSONReader);
 
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
	/// Response to create request
	/// </summary>
	public partial class CreateResponse : AccountResponse {
        /// <summary>
        ///Unique identifier of the account
        /// </summary>

		public virtual string						UDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CreateResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CreateResponse();
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
			((AccountResponse)this).SerializeX(_Writer, false, ref _first);
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
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
				case "UDF" : {
					UDF = JSONReader.ReadString ();
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
	/// Delete an account
	/// </summary>
	public partial class DeleteRequest : AccountRequest {
        /// <summary>
        ///The account to delete
        /// </summary>

		public virtual string						AccountId  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DeleteRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DeleteRequest();
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
			((AccountRequest)this).SerializeX(_Writer, false, ref _first);
			if (AccountId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountId", 1);
					_Writer.WriteString (AccountId);
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
				case "AccountId" : {
					AccountId = JSONReader.ReadString ();
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
	/// Result
	/// </summary>
	public partial class DeleteResponse : AccountResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DeleteResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DeleteResponse();
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
			((AccountResponse)this).SerializeX(_Writer, false, ref _first);
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
	/// Update an account profile
	/// </summary>
	public partial class UpdateRequest : AccountRequest {
        /// <summary>
        ///The account to update
        /// </summary>

		public virtual AccountData						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateRequest();
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
			((AccountRequest)this).SerializeX(_Writer, false, ref _first);
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					Data.Serialize (_Writer, false);
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
        public static new UpdateRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateRequest;
				}
		    var Result = new UpdateRequest ();
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
				case "Data" : {
					// An untagged structure
					Data = new AccountData ();
					Data.Deserialize (JSONReader);
 
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
	/// Result
	/// </summary>
	public partial class UpdateResponse : AccountResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "UpdateResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new UpdateResponse();
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
			((AccountResponse)this).SerializeX(_Writer, false, ref _first);
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
        public static new UpdateResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UpdateResponse;
				}
		    var Result = new UpdateResponse ();
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
	/// Fetches an account profile.
	/// </summary>
	public partial class GetRequest : AccountRequest {
        /// <summary>
        ///The account to fetch
        /// </summary>

		public virtual string						AccountId  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetRequest();
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
			((AccountRequest)this).SerializeX(_Writer, false, ref _first);
			if (AccountId != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountId", 1);
					_Writer.WriteString (AccountId);
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
				case "AccountId" : {
					AccountId = JSONReader.ReadString ();
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
	/// Result
	/// </summary>
	public partial class GetResponse : AccountResponse {
        /// <summary>
        ///Describes the account (if found)
        /// </summary>

		public virtual AccountData						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "GetResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new GetResponse();
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
			((AccountResponse)this).SerializeX(_Writer, false, ref _first);
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					Data.Serialize (_Writer, false);
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
				case "Data" : {
					// An untagged structure
					Data = new AccountData ();
					Data.Deserialize (JSONReader);
 
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

