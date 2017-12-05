
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


namespace Goedel.Protocol.Exchange {


	/// <summary>
	///
	/// Key Exchange Protocol
	/// </summary>
	public abstract partial class ExchangeMessage : global::Goedel.Protocol.JSONObject {

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
		public override string _Tag { get; } = "ExchangeMessage";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"Algorithms", Algorithms._Factory},
			{"ExchangeRequest", ExchangeRequest._Factory},
			{"ExchangeResponse", ExchangeResponse._Factory}			};

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
    public abstract partial class KeyExchangeService : Goedel.Protocol.JPCInterface {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "jwcexchange";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown => WellKnown;

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_jwcexchange._tcp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetDiscovery => Discovery;

        /// <summary>
        /// The active JPCSession.
        /// </summary>		
		public virtual JPCSession JPCSession {get; set;}


        /// <summary>
		/// Base method for implementing the transaction  Exchange.
        /// </summary>
        /// <param name="Request">The request object to send to the host.</param>
		/// <returns>The response object from the service</returns>
        public virtual ExchangeResponse Exchange (
                ExchangeRequest Request) {
            return null;
            }

        }

    /// <summary>
	/// Client class for KeyExchangeService.
    /// </summary>		
    public partial class KeyExchangeServiceClient : KeyExchangeService {
 		
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
		public KeyExchangeServiceClient (JPCRemoteSession JPCRemoteSession) {
			this.JPCRemoteSession = JPCRemoteSession;
			}


        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="Request">The request object</param>
		/// <returns>The response object</returns>
        public override ExchangeResponse Exchange (
                ExchangeRequest Request) {

            var ResponseData = JPCRemoteSession.Post("Exchange", Request);
            var Response = ExchangeResponse.FromJSON(ResponseData.JSONReader(), true);

            return Response;
            }

		}


    /// <summary>
	/// Client class for KeyExchangeService.
    /// </summary>		
    public partial class KeyExchangeServiceProvider : Goedel.Protocol.JPCProvider {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public KeyExchangeService Service;


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
				case "Exchange" : {
					var Request = new ExchangeRequest();
					Request.Deserialize (JSONReader);
					Response = Service.Exchange (Request);
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
	/// Describes an algorithm suite. Each suite consists of sets of authentication and
	/// encryption algorithms which are mutually compatible. i.e. the counterparty MAY
	/// select any one of the encryption algorithms and use it with any one of the 
	/// authentication algorithms.
	/// </summary>
	public partial class Algorithms : ExchangeMessage {
        /// <summary>
        ///Algorithm identifiers of encryption and authenticated encryption algorithms offered
        /// </summary>

		public virtual List<string>				Encryption  {get; set;}
        /// <summary>
        ///Authentication algorithm offer
        /// </summary>

		public virtual List<string>				Authentication  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Algorithms";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Algorithms();
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
			if (Encryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encryption", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encryption) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Authentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Authentication", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Authentication) {
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
        public static new Algorithms FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Algorithms;
				}
		    var Result = new Algorithms ();
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
				case "Encryption" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Encryption = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Encryption.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Authentication" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Authentication = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Authentication.Add (_Item);
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
	/// Initiate the key exchange request.
	/// </summary>
	public partial class ExchangeRequest : Goedel.Protocol.Request {
        /// <summary>
        ///The client credential (required)
        /// </summary>

		public virtual Key						ClientCredential  {get; set;}
        /// <summary>
        ///Additional key added into the exchange to serve as a nonce (required).
        /// </summary>

		public virtual Key						ClientNonce  {get; set;}
        /// <summary>
        ///Set of message authentication and encryption algorithms offered by the client
        /// </summary>

		public virtual List<Algorithms>				Offer  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ExchangeRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ExchangeRequest();
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
			if (ClientCredential != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ClientCredential", 1);
					// expand this to a tagged structure
					//ClientCredential.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(ClientCredential.Tag(), 1);
						bool firstinner = true;
						ClientCredential.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (ClientNonce != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ClientNonce", 1);
					// expand this to a tagged structure
					//ClientNonce.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(ClientNonce.Tag(), 1);
						bool firstinner = true;
						ClientNonce.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (Offer != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Offer", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Offer) {
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
        public static new ExchangeRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ExchangeRequest;
				}
		    var Result = new ExchangeRequest ();
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
				case "ClientCredential" : {
					ClientCredential = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "ClientNonce" : {
					ClientNonce = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "Offer" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Offer = new List <Algorithms> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Algorithms ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Algorithms (JSONReader);
						Offer.Add (_Item);
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
	/// Returns the server parameters.
	/// </summary>
	public partial class ExchangeResponse : Goedel.Protocol.Response {
        /// <summary>
        ///Opaque session identifier.
        /// </summary>

		public virtual byte[]						Ticket  {get; set;}
        /// <summary>
        ///Opaque witness value used to prove binding to the ticket.
        /// </summary>

		public virtual byte[]						Witness  {get; set;}
        /// <summary>
        ///Optional server credential
        /// </summary>

		public virtual Key						ServerCredential  {get; set;}
        /// <summary>
        ///Additional key added into the exchange to serve as a nonce (required). 
        /// </summary>

		public virtual Key						ServerNonce  {get; set;}
        /// <summary>
        ///Algorithm identifiers of encryption or authenticated encryption algorithm chosen
        /// </summary>

		public virtual List<string>				Encryption  {get; set;}
        /// <summary>
        ///Algorithm identifiers of authentication algorithm chosen
        /// </summary>

		public virtual List<string>				Authentication  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ExchangeResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ExchangeResponse();
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
			if (Ticket != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Ticket", 1);
					_Writer.WriteBinary (Ticket);
				}
			if (Witness != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Witness", 1);
					_Writer.WriteBinary (Witness);
				}
			if (ServerCredential != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServerCredential", 1);
					// expand this to a tagged structure
					//ServerCredential.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(ServerCredential.Tag(), 1);
						bool firstinner = true;
						ServerCredential.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (ServerNonce != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServerNonce", 1);
					// expand this to a tagged structure
					//ServerNonce.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(ServerNonce.Tag(), 1);
						bool firstinner = true;
						ServerNonce.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (Encryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encryption", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encryption) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Authentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Authentication", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Authentication) {
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
        public static new ExchangeResponse FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ExchangeResponse;
				}
		    var Result = new ExchangeResponse ();
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
				case "Ticket" : {
					Ticket = JSONReader.ReadBinary ();
					break;
					}
				case "Witness" : {
					Witness = JSONReader.ReadBinary ();
					break;
					}
				case "ServerCredential" : {
					ServerCredential = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "ServerNonce" : {
					ServerNonce = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "Encryption" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Encryption = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Encryption.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Authentication" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Authentication = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Authentication.Add (_Item);
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

	}

