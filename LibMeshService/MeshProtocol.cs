
//  Test
//  
//  This file was automatically generated at 11/5/2015 12:20:26 AM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  ProtoGen version 1.0.0.0
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : Copyright ©  2011
//  
//  Build Platform: Win32NT 6.2.9200.0
//  
//  
//  Copyright (c) 2014 by .
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
//  //Header

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;




using Goedel.Mesh;
using Goedel.Persistence;


namespace Goedel.Mesh {


    /// <summary>
    /// 
    /// </summary>
	public abstract partial class MeshProtocol : Goedel.Protocol.JSONObject {

        /// <summary>
        /// 
        /// </summary>
		public override string Tag () {
			return "MeshProtocol";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshProtocol () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
		public MeshProtocol (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
		public MeshProtocol (string _String) {
			Deserialize (_String);
			_Initialize () ;
			}



		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "MeshRequest" : {
					var Result = new MeshRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "MeshResponse" : {
					var Result = new MeshResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Version" : {
					var Result = new Version ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "Encoding" : {
					var Result = new Encoding ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ValidateRequest" : {
					var Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ValidateResponse" : {
					var Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PublishRequest" : {
					var Result = new PublishRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "PublishResponse" : {
					var Result = new PublishResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "GetRequest" : {
					var Result = new GetRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "KeyValue" : {
					var Result = new KeyValue ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "GetResponse" : {
					var Result = new GetResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "GetRecordsResponse" : {
					var Result = new GetRecordsResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "TransferRequest" : {
					var Result = new TransferRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "TransferResponse" : {
					var Result = new TransferResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "StatusRequest" : {
					var Result = new StatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "StatusResponse" : {
					var Result = new StatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectStartRequest" : {
					var Result = new ConnectStartRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectStartResponse" : {
					var Result = new ConnectStartResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectStatusRequest" : {
					var Result = new ConnectStatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectStatusResponse" : {
					var Result = new ConnectStatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectPendingRequest" : {
					var Result = new ConnectPendingRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectPendingResponse" : {
					var Result = new ConnectPendingResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectCompleteRequest" : {
					var Result = new ConnectCompleteRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "ConnectCompleteResponse" : {
					var Result = new ConnectCompleteResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}

			
			JSONReader.EndObject ();
            }


		}



		// Service Dispatch Classes



    /// <summary>
	/// The new base class for the client and service side APIs.
    /// </summary>		
    public abstract partial class MeshService : Goedel.Protocol.JPCService {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "MeshService";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown {
			get {return WellKnown;}
			}

		JPCSession _JPCSession;

        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public virtual JPCSession JPCSession {
			get {return _JPCSession;}
			set {_JPCSession = value;}
			}


        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual HelloResponse Hello (
                HelloRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual ValidateResponse ValidateAccount (
                ValidateRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual CreateResponse CreateAccount (
                CreateRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual PublishResponse Publish (
                PublishRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual GetResponse Get (
                GetRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual GetRecordsResponse GetRecords (
                GetRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual TransferResponse Transfer (
                TransferRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual StatusResponse Status (
                StatusRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual ConnectStartResponse ConnectStart (
                ConnectStartRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual ConnectStatusResponse ConnectStatus (
                ConnectStatusRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual ConnectPendingResponse ConnectPending (
                ConnectPendingRequest Request) {
            return null;
            }

        /// <summary>
		/// Base class for implementing the transaction.
        /// </summary>		
        public virtual ConnectCompleteResponse ConnectComplete (
                ConnectCompleteRequest Request) {
            return null;
            }

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
			get {return JPCRemoteSession;}
			set {JPCRemoteSession = value as JPCRemoteSession; }
			}


        /// <summary>
		/// Create a client connection to the specified service.
        /// </summary>	
		public MeshServiceClient (JPCRemoteSession JPCRemoteSession) {
			this.JPCRemoteSession = JPCRemoteSession;
			}


        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override HelloResponse Hello (
                HelloRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Hello", Request);
            var Response = HelloResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override ValidateResponse ValidateAccount (
                ValidateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ValidateAccount", Request);
            var Response = ValidateResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override CreateResponse CreateAccount (
                CreateRequest Request) {

            var ResponseData = JPCRemoteSession.Post("CreateAccount", Request);
            var Response = CreateResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override PublishResponse Publish (
                PublishRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Publish", Request);
            var Response = PublishResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override GetResponse Get (
                GetRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Get", Request);
            var Response = GetResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override GetRecordsResponse GetRecords (
                GetRequest Request) {

            var ResponseData = JPCRemoteSession.Post("GetRecords", Request);
            var Response = GetRecordsResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override TransferResponse Transfer (
                TransferRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Transfer", Request);
            var Response = TransferResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override StatusResponse Status (
                StatusRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Status", Request);
            var Response = StatusResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override ConnectStartResponse ConnectStart (
                ConnectStartRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectStart", Request);
            var Response = ConnectStartResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override ConnectStatusResponse ConnectStatus (
                ConnectStatusRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectStatus", Request);
            var Response = ConnectStatusResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override ConnectPendingResponse ConnectPending (
                ConnectPendingRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectPending", Request);
            var Response = ConnectPendingResponse.FromTagged(ResponseData);

            return null;
            }

        /// <summary>
		/// Implement the transaction
        /// </summary>		
        public override ConnectCompleteResponse ConnectComplete (
                ConnectCompleteRequest Request) {

            var ResponseData = JPCRemoteSession.Post("ConnectComplete", Request);
            var Response = ConnectCompleteResponse.FromTagged(ResponseData);

            return null;
            }

		}


    /// <summary>
	/// Client class for MeshService.
    /// </summary>		
    public partial class MeshServiceHost : Goedel.Protocol.JPCHost {

		/// <summary>
		/// Dispatch object for service.
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
					var Request = new HelloRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.Hello (Request);
					break;
					}
				case "ValidateAccount" : {
					var Request = new ValidateRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.ValidateAccount (Request);
					break;
					}
				case "CreateAccount" : {
					var Request = new CreateRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.CreateAccount (Request);
					break;
					}
				case "Publish" : {
					var Request = new PublishRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.Publish (Request);
					break;
					}
				case "Get" : {
					var Request = new GetRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.Get (Request);
					break;
					}
				case "GetRecords" : {
					var Request = new GetRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.GetRecords (Request);
					break;
					}
				case "Transfer" : {
					var Request = new TransferRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.Transfer (Request);
					break;
					}
				case "Status" : {
					var Request = new StatusRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.Status (Request);
					break;
					}
				case "ConnectStart" : {
					var Request = new ConnectStartRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectStart (Request);
					break;
					}
				case "ConnectStatus" : {
					var Request = new ConnectStatusRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectStatus (Request);
					break;
					}
				case "ConnectPending" : {
					var Request = new ConnectPendingRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectPending (Request);
					break;
					}
				case "ConnectComplete" : {
					var Request = new ConnectCompleteRequest ();
					Request.Deserialize (JSONReader);
					Response = Service.ConnectComplete (Request);
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
	/// </summary>
	public partial class MeshRequest : Goedel.Protocol.Request {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MeshRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MeshRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public MeshRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public MeshRequest (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new MeshRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MeshRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MeshRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new MeshRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MeshRequest FromTagged (string _Input) {
			MeshRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out MeshRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out MeshRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "MeshRequest" : {
					var Result = new MeshRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateRequest" : {
					var Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PublishRequest" : {
					var Result = new PublishRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "GetRequest" : {
					var Result = new GetRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TransferRequest" : {
					var Result = new TransferRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "StatusRequest" : {
					var Result = new StatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectStartRequest" : {
					var Result = new ConnectStartRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectStartResponse" : {
					var Result = new ConnectStartResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectStatusRequest" : {
					var Result = new ConnectStatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectStatusResponse" : {
					var Result = new ConnectStatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectPendingRequest" : {
					var Result = new ConnectPendingRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectPendingResponse" : {
					var Result = new ConnectPendingResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectCompleteRequest" : {
					var Result = new ConnectCompleteRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ConnectCompleteResponse" : {
					var Result = new ConnectCompleteResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// </summary>
	public partial class MeshResponse : Goedel.Protocol.Response {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MeshResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MeshResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public MeshResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public MeshResponse (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new MeshResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MeshResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MeshResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new MeshResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new MeshResponse FromTagged (string _Input) {
			MeshResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out MeshResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out MeshResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "MeshResponse" : {
					var Result = new MeshResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "ValidateResponse" : {
					var Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "PublishResponse" : {
					var Result = new PublishResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "GetResponse" : {
					var Result = new GetResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "GetRecordsResponse" : {
					var Result = new GetRecordsResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "TransferResponse" : {
					var Result = new TransferResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				case "StatusResponse" : {
					var Result = new StatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class HelloRequest : MeshRequest {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "HelloRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public HelloRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public HelloRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public HelloRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new HelloRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new HelloRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new HelloRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new HelloRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new HelloRequest FromTagged (string _Input) {
			HelloRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out HelloRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out HelloRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "HelloRequest" : {
					var Result = new HelloRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// </summary>
	public partial class HelloResponse : MeshResponse {
        /// <summary>
        /// 
        /// </summary>
		public Version						Version;
		/// <summary>
        /// 
        /// </summary>
		public List<Version>				Alternates;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "HelloResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public HelloResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public HelloResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public HelloResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (Version != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Version", 1);
					Version.Serialize (_Writer, false);
				}
			if (Alternates != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Alternates", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Alternates) {
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
        /// </summary>		
		public static new HelloResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new HelloResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new HelloResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new HelloResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new HelloResponse FromTagged (string _Input) {
			HelloResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out HelloResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out HelloResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "HelloResponse" : {
					var Result = new HelloResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Version" : {
					// Field does not have 
					Version = new Version (JSONReader);
					//Version.Deserialize(JSONReader, out Version) ;
					break;
					}
				case "Alternates" : {
					bool _Going = JSONReader.StartArray ();
					Alternates = new List <Version> ();
					while (_Going) {
						var _Item = new Version (JSONReader);
						//Version _Item;
                        //Version.Deserialize(JSONReader, out _Item);

						Alternates.Add (_Item);
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
	/// </summary>
	public partial class Version : MeshProtocol {
		bool								__Major = false;
		private int						_Major;
        /// <summary>
        /// 
        /// </summary>
		public int						Major {
			get {return _Major;}
			set {_Major = value; __Major = true; }
			}
		bool								__Minor = false;
		private int						_Minor;
        /// <summary>
        /// 
        /// </summary>
		public int						Minor {
			get {return _Minor;}
			set {_Minor = value; __Minor = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public List<Encoding>				Encodings;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				URI;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Version";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Version () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Version (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (__Major){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Major", 1);
					_Writer.WriteInteger32 (Major);
				}
			if (__Minor){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Minor", 1);
					_Writer.WriteInteger32 (Minor);
				}
			if (Encodings != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encodings", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encodings) {
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

			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in URI) {
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
        /// </summary>		
		public static new Version From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Version From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Version (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Version FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Version FromTagged (string _Input) {
			Version _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Version Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Version Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Version" : {
					var Result = new Version ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Major" : {
					Major = JSONReader.ReadInteger32 ();
					break;
					}
				case "Minor" : {
					Minor = JSONReader.ReadInteger32 ();
					break;
					}
				case "Encodings" : {
					bool _Going = JSONReader.StartArray ();
					Encodings = new List <Encoding> ();
					while (_Going) {
						var _Item = new Encoding (JSONReader);
						//Encoding _Item;
                        //Encoding.Deserialize(JSONReader, out _Item);

						Encodings.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "URI" : {
					bool _Going = JSONReader.StartArray ();
					URI = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						URI.Add (_Item);
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
	/// </summary>
	public partial class Encoding : MeshProtocol {
		/// <summary>
        /// 
        /// </summary>
		public List<string>				ID;
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Dictionary;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "Encoding";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public Encoding () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public Encoding (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
			if (ID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ID", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ID) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Dictionary != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Dictionary", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Dictionary) {
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
        /// </summary>		
		public static new Encoding From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Encoding From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new Encoding (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new Encoding FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new Encoding FromTagged (string _Input) {
			Encoding _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out Encoding Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out Encoding Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "Encoding" : {
					var Result = new Encoding ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ID" : {
					bool _Going = JSONReader.StartArray ();
					ID = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						ID.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "Dictionary" : {
					bool _Going = JSONReader.StartArray ();
					Dictionary = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Dictionary.Add (_Item);
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class ValidateRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						Account;
		bool								__Reserve = false;
		private bool						_Reserve;
        /// <summary>
        /// 
        /// </summary>
		public bool						Reserve {
			get {return _Reserve;}
			set {_Reserve = value; __Reserve = true; }
			}
		/// <summary>
        /// 
        /// </summary>
		public List<string>				Language;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ValidateRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ValidateRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ValidateRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ValidateRequest (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ValidateRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ValidateRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateRequest FromTagged (string _Input) {
			ValidateRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ValidateRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ValidateRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ValidateRequest" : {
					var Result = new ValidateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// </summary>
	public partial class ValidateResponse : MeshResponse {
		bool								__Valid = false;
		private bool						_Valid;
        /// <summary>
        /// 
        /// </summary>
		public bool						Valid {
			get {return _Valid;}
			set {_Valid = value; __Valid = true; }
			}
		bool								__Minimum = false;
		private int						_Minimum;
        /// <summary>
        /// 
        /// </summary>
		public int						Minimum {
			get {return _Minimum;}
			set {_Minimum = value; __Minimum = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public string						InvalidCharacters;
        /// <summary>
        /// 
        /// </summary>
		public string						Reason;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ValidateResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ValidateResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ValidateResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ValidateResponse (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ValidateResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ValidateResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ValidateResponse FromTagged (string _Input) {
			ValidateResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ValidateResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ValidateResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ValidateResponse" : {
					var Result = new ValidateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class CreateRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						Account;
        /// <summary>
        /// 
        /// </summary>
		public SignedProfile						Profile;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "CreateRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public CreateRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public CreateRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public CreateRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (Profile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Profile", 1);
					Profile.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new CreateRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new CreateRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new CreateRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new CreateRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new CreateRequest FromTagged (string _Input) {
			CreateRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out CreateRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out CreateRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "CreateRequest" : {
					var Result = new CreateRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "Profile" : {
					// Field does not have 
					Profile = new SignedProfile (JSONReader);
					//SignedProfile.Deserialize(JSONReader, out Profile) ;
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
	/// </summary>
	public partial class CreateResponse : MeshResponse {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "CreateResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public CreateResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public CreateResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public CreateResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new CreateResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new CreateResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new CreateResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new CreateResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new CreateResponse FromTagged (string _Input) {
			CreateResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out CreateResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out CreateResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "CreateResponse" : {
					var Result = new CreateResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class PublishRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public Entry						Entry;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PublishRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PublishRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public PublishRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public PublishRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (Entry != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entry", 1);
					Entry.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PublishRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublishRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PublishRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PublishRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublishRequest FromTagged (string _Input) {
			PublishRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PublishRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PublishRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PublishRequest" : {
					var Result = new PublishRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entry" : {
					// Field does not have 
					Entry = new Entry (JSONReader);
					//Entry.Deserialize(JSONReader, out Entry) ;
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
	/// </summary>
	public partial class PublishResponse : MeshResponse {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "PublishResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public PublishResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public PublishResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public PublishResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new PublishResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublishResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new PublishResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new PublishResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new PublishResponse FromTagged (string _Input) {
			PublishResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out PublishResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out PublishResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "PublishResponse" : {
					var Result = new PublishResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class GetRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						Identifier;
        /// <summary>
        /// 
        /// </summary>
		public string						Account;
		/// <summary>
        /// 
        /// </summary>
		public List<KeyValue>				KeyValues;
		bool								__NotBefore = false;
		private DateTime						_NotBefore;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						NotBefore {
			get {return _NotBefore;}
			set {_NotBefore = value; __NotBefore = true; }
			}
		bool								__NotOnOrAfter = false;
		private DateTime						_NotOnOrAfter;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						NotOnOrAfter {
			get {return _NotOnOrAfter;}
			set {_NotOnOrAfter = value; __NotOnOrAfter = true; }
			}
		bool								__Multiple = false;
		private bool						_Multiple;
        /// <summary>
        /// 
        /// </summary>
		public bool						Multiple {
			get {return _Multiple;}
			set {_Multiple = value; __Multiple = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "GetRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public GetRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public GetRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public GetRequest (string _String) {
			Deserialize (_String);
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
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (__NotBefore){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotBefore", 1);
					_Writer.WriteDateTime (NotBefore);
				}
			if (__NotOnOrAfter){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotOnOrAfter", 1);
					_Writer.WriteDateTime (NotOnOrAfter);
				}
			if (__Multiple){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Multiple", 1);
					_Writer.WriteBoolean (Multiple);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new GetRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new GetRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new GetRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetRequest FromTagged (string _Input) {
			GetRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out GetRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out GetRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "GetRequest" : {
					var Result = new GetRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
					bool _Going = JSONReader.StartArray ();
					KeyValues = new List <KeyValue> ();
					while (_Going) {
						var _Item = new KeyValue (JSONReader);
						//KeyValue _Item;
                        //KeyValue.Deserialize(JSONReader, out _Item);

						KeyValues.Add (_Item);
						_Going = JSONReader.NextArray ();
						}

					break;
					}
				case "NotBefore" : {
					NotBefore = JSONReader.ReadDateTime ();
					break;
					}
				case "NotOnOrAfter" : {
					NotOnOrAfter = JSONReader.ReadDateTime ();
					break;
					}
				case "Multiple" : {
					Multiple = JSONReader.ReadBoolean ();
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
	/// </summary>
	public partial class KeyValue : MeshProtocol {
        /// <summary>
        /// 
        /// </summary>
		public string						Key;
        /// <summary>
        /// 
        /// </summary>
		public string						Value;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "KeyValue";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public KeyValue () {
			_Initialize ();
			}
        /// <summary>
        /// </summary>		
		public KeyValue (JSONReader JSONReader) {
			Deserialize (JSONReader);
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
        /// </summary>		
		public static new KeyValue From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new KeyValue From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new KeyValue (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new KeyValue FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new KeyValue FromTagged (string _Input) {
			KeyValue _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out KeyValue Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out KeyValue Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "KeyValue" : {
					var Result = new KeyValue ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// </summary>
	public partial class GetResponse : MeshResponse {
		/// <summary>
        /// 
        /// </summary>
		public List<Entry>				Entries;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "GetResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public GetResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public GetResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public GetResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
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
        /// </summary>		
		public static new GetResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new GetResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new GetResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetResponse FromTagged (string _Input) {
			GetResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out GetResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out GetResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "GetResponse" : {
					var Result = new GetResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					bool _Going = JSONReader.StartArray ();
					Entries = new List <Entry> ();
					while (_Going) {
						var _Item = new Entry (JSONReader);
						//Entry _Item;
                        //Entry.Deserialize(JSONReader, out _Item);

						Entries.Add (_Item);
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
	/// </summary>
	public partial class GetRecordsResponse : MeshResponse {
		/// <summary>
        /// 
        /// </summary>
		public List<DataItem>				DataItems;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "GetRecordsResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public GetRecordsResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public GetRecordsResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public GetRecordsResponse (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new GetRecordsResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetRecordsResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new GetRecordsResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new GetRecordsResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new GetRecordsResponse FromTagged (string _Input) {
			GetRecordsResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out GetRecordsResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out GetRecordsResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "GetRecordsResponse" : {
					var Result = new GetRecordsResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DataItems" : {
					bool _Going = JSONReader.StartArray ();
					DataItems = new List <DataItem> ();
					while (_Going) {
						var _Item = new DataItem (JSONReader);
						//DataItem _Item;
                        //DataItem.Deserialize(JSONReader, out _Item);

						DataItems.Add (_Item);
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class TransferRequest : MeshRequest {
		bool								__NotBefore = false;
		private DateTime						_NotBefore;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						NotBefore {
			get {return _NotBefore;}
			set {_NotBefore = value; __NotBefore = true; }
			}
		bool								__Until = false;
		private DateTime						_Until;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						Until {
			get {return _Until;}
			set {_Until = value; __Until = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public string						After;
		bool								__MaxEntries = false;
		private int						_MaxEntries;
        /// <summary>
        /// 
        /// </summary>
		public int						MaxEntries {
			get {return _MaxEntries;}
			set {_MaxEntries = value; __MaxEntries = true; }
			}
		bool								__MaxBytes = false;
		private int						_MaxBytes;
        /// <summary>
        /// 
        /// </summary>
		public int						MaxBytes {
			get {return _MaxBytes;}
			set {_MaxBytes = value; __MaxBytes = true; }
			}

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "TransferRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public TransferRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public TransferRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public TransferRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (__NotBefore){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotBefore", 1);
					_Writer.WriteDateTime (NotBefore);
				}
			if (__Until){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Until", 1);
					_Writer.WriteDateTime (Until);
				}
			if (After != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("After", 1);
					_Writer.WriteString (After);
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
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new TransferRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new TransferRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new TransferRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new TransferRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new TransferRequest FromTagged (string _Input) {
			TransferRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out TransferRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out TransferRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "TransferRequest" : {
					var Result = new TransferRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "NotBefore" : {
					NotBefore = JSONReader.ReadDateTime ();
					break;
					}
				case "Until" : {
					Until = JSONReader.ReadDateTime ();
					break;
					}
				case "After" : {
					After = JSONReader.ReadString ();
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
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class TransferResponse : MeshResponse {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "TransferResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public TransferResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public TransferResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public TransferResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new TransferResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new TransferResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new TransferResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new TransferResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new TransferResponse FromTagged (string _Input) {
			TransferResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out TransferResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out TransferResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "TransferResponse" : {
					var Result = new TransferResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	/// </summary>
	public partial class StatusRequest : MeshRequest {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "StatusRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public StatusRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public StatusRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public StatusRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new StatusRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new StatusRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new StatusRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new StatusRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new StatusRequest FromTagged (string _Input) {
			StatusRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out StatusRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out StatusRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "StatusRequest" : {
					var Result = new StatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// </summary>
	public partial class StatusResponse : MeshResponse {
		bool								__LastWriteTime = false;
		private DateTime						_LastWriteTime;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						LastWriteTime {
			get {return _LastWriteTime;}
			set {_LastWriteTime = value; __LastWriteTime = true; }
			}
		bool								__LastCheckpointTime = false;
		private DateTime						_LastCheckpointTime;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						LastCheckpointTime {
			get {return _LastCheckpointTime;}
			set {_LastCheckpointTime = value; __LastCheckpointTime = true; }
			}
		bool								__NextCheckpointTime = false;
		private DateTime						_NextCheckpointTime;
        /// <summary>
        /// 
        /// </summary>
		public DateTime						NextCheckpointTime {
			get {return _NextCheckpointTime;}
			set {_NextCheckpointTime = value; __NextCheckpointTime = true; }
			}
        /// <summary>
        /// 
        /// </summary>
		public string						CheckpointValue;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "StatusResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public StatusResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public StatusResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public StatusResponse (string _String) {
			Deserialize (_String);
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
			((MeshResponse)this).SerializeX(_Writer, false, ref _first);
			if (__LastWriteTime){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastWriteTime", 1);
					_Writer.WriteDateTime (LastWriteTime);
				}
			if (__LastCheckpointTime){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("LastCheckpointTime", 1);
					_Writer.WriteDateTime (LastCheckpointTime);
				}
			if (__NextCheckpointTime){
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
        /// </summary>		
		public static new StatusResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new StatusResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new StatusResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new StatusResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new StatusResponse FromTagged (string _Input) {
			StatusResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out StatusResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out StatusResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "StatusResponse" : {
					var Result = new StatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
// Not using separate transaction classes any more
//% MakeClass (Transaction.Id, Transaction.Entries);
//		}
//
	/// <summary>
	///
	/// 
	/// </summary>
	public partial class ConnectStartRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public SignedConnectionRequest						SignedRequest;
        /// <summary>
        /// 
        /// </summary>
		public string						AccountID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectStartRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectStartRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectStartRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectStartRequest (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ConnectStartRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectStartRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartRequest FromTagged (string _Input) {
			ConnectStartRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectStartRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectStartRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectStartRequest" : {
					var Result = new ConnectStartRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedRequest" : {
					// Field does not have 
					SignedRequest = new SignedConnectionRequest (JSONReader);
					//SignedConnectionRequest.Deserialize(JSONReader, out SignedRequest) ;
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
	/// 
	/// </summary>
	public partial class ConnectStartResponse : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						SignedConnectionResult;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectStartResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectStartResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectStartResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectStartResponse (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (SignedConnectionResult != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedConnectionResult", 1);
					_Writer.WriteString (SignedConnectionResult);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new ConnectStartResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectStartResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStartResponse FromTagged (string _Input) {
			ConnectStartResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectStartResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectStartResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectStartResponse" : {
					var Result = new ConnectStartResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedConnectionResult" : {
					SignedConnectionResult = JSONReader.ReadString ();
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
	/// 
	/// </summary>
	public partial class ConnectStatusRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						AccountID;
        /// <summary>
        /// 
        /// </summary>
		public string						DeviceID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectStatusRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectStatusRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectStatusRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectStatusRequest (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ConnectStatusRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectStatusRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusRequest FromTagged (string _Input) {
			ConnectStatusRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectStatusRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectStatusRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectStatusRequest" : {
					var Result = new ConnectStatusRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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
	/// 
	/// </summary>
	public partial class ConnectStatusResponse : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public SignedConnectionResult						Result;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectStatusResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectStatusResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectStatusResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectStatusResponse (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ConnectStatusResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectStatusResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectStatusResponse FromTagged (string _Input) {
			ConnectStatusResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectStatusResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectStatusResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectStatusResponse" : {
					var Result = new ConnectStatusResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					// Field does not have 
					Result = new SignedConnectionResult (JSONReader);
					//SignedConnectionResult.Deserialize(JSONReader, out Result) ;
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
	/// 
	/// </summary>
	public partial class ConnectPendingRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public string						AccountID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectPendingRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectPendingRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectPendingRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectPendingRequest (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
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
        /// </summary>		
		public static new ConnectPendingRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectPendingRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingRequest FromTagged (string _Input) {
			ConnectPendingRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectPendingRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectPendingRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectPendingRequest" : {
					var Result = new ConnectPendingRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
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
	/// 
	/// </summary>
	public partial class ConnectPendingResponse : MeshRequest {
		/// <summary>
        /// 
        /// </summary>
		public List<SignedConnectionRequest>				Pending;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectPendingResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectPendingResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectPendingResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectPendingResponse (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ConnectPendingResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectPendingResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectPendingResponse FromTagged (string _Input) {
			ConnectPendingResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectPendingResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectPendingResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectPendingResponse" : {
					var Result = new ConnectPendingResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Pending" : {
					bool _Going = JSONReader.StartArray ();
					Pending = new List <SignedConnectionRequest> ();
					while (_Going) {
						var _Item = new SignedConnectionRequest (JSONReader);
						//SignedConnectionRequest _Item;
                        //SignedConnectionRequest.Deserialize(JSONReader, out _Item);

						Pending.Add (_Item);
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
	/// 
	/// </summary>
	public partial class ConnectCompleteRequest : MeshRequest {
        /// <summary>
        /// 
        /// </summary>
		public SignedConnectionResult						Result;
        /// <summary>
        /// 
        /// </summary>
		public string						AccountID;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectCompleteRequest";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectCompleteRequest () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectCompleteRequest (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectCompleteRequest (string _String) {
			Deserialize (_String);
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
        /// </summary>		
		public static new ConnectCompleteRequest From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteRequest From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectCompleteRequest (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteRequest FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteRequest FromTagged (string _Input) {
			ConnectCompleteRequest _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectCompleteRequest Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectCompleteRequest Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectCompleteRequest" : {
					var Result = new ConnectCompleteRequest ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					// Field does not have 
					Result = new SignedConnectionResult (JSONReader);
					//SignedConnectionResult.Deserialize(JSONReader, out Result) ;
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
	/// 
	/// </summary>
	public partial class ConnectCompleteResponse : MeshRequest {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "ConnectCompleteResponse";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public ConnectCompleteResponse () {
			_Initialize ();
			}

        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
		public ConnectCompleteResponse (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary>
		/// Initialize class from a JSON encoded class.
        /// </summary>		
		public ConnectCompleteResponse (string _String) {
			Deserialize (_String);
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
			((MeshRequest)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}



        /// <summary>
        /// </summary>		
		public static new ConnectCompleteResponse From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteResponse From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new ConnectCompleteResponse (JSONReader);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteResponse FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// </summary>		
		public static new ConnectCompleteResponse FromTagged (string _Input) {
			ConnectCompleteResponse _Result;
			Deserialize (_Input, out _Result);
			return _Result;
			}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Input"></param>
        /// <param name="Out"></param>
        public static void Deserialize(string _Input, out ConnectCompleteResponse Out) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);

			Deserialize (JSONReader, out Out);
			}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Out"></param>
        public static void Deserialize(JSONReader JSONReader, out ConnectCompleteResponse Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "ConnectCompleteResponse" : {
					var Result = new ConnectCompleteResponse ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			// should we check for EOF here?
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
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

	}

