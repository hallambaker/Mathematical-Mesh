
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
//  This file was automatically generated at 6/15/2021 6:01:08 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.649
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


using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Callsign.Registry;
using Goedel.Callsign;


namespace Goedel.Callsign.Registrar {


	/// <summary>
	///
	/// Callsign Registrar protocol supporting query function.
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
	public abstract partial class CallsignRegistrar : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CallsignRegistrar";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"QueryRequest", QueryRequest._Factory},
			{"QueryResponse", QueryResponse._Factory}			};

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
		public const string WellKnown = "tbs1";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown => WellKnown;

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_tbs1._tcp";

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
				case "Query" : {
					var request = new QueryRequest();
					request.Deserialize (jsonReader);
					response = Query (request, session);
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
		/// Base method for implementing the transaction  Query.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract QueryResponse Query (
                QueryRequest request, IJpcSession session);

        }

    /// <summary>
	/// Client class for MeshService.
    /// </summary>		
    public partial class MeshServiceClient :  Goedel.Protocol.JpcClientInterface {

	    /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "tbs1";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown => WellKnown;

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_tbs1._tcp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetDiscovery => Discovery;



        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="request">The request object.</param>
		/// <returns>The response object</returns>
        public virtual QueryResponse Query (QueryRequest request) =>
				JpcSession.Post("Query", request) as QueryResponse;


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
        public override QueryResponse Query (QueryRequest request) =>
				Service.Query (request, JpcSession);


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
				case "Query" : {
					var request = new QueryRequest();
					request.Deserialize (jsonReader);
					response = Service.Query (request, session);
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
	/// Request resolution of a profile bound to a callsign or registration identifier. 
	/// </summary>
	public partial class QueryRequest : CallsignRequest {
        /// <summary>
        ///The callsign being requested in canonical form.
        /// </summary>

		public virtual string						CallSign  {get; set;}
        /// <summary>
        ///The registration identifier of a registration in the log.
        /// </summary>

		public virtual string						RegistrationId  {get; set;}
        /// <summary>
        ///The unique identifier of an append only log whose signed Notarization
        ///entry is requested.
        /// </summary>

		public virtual string						LogId  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "QueryRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new QueryRequest();


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
			((CallsignRequest)this).SerializeX(_writer, false, ref _first);
			if (CallSign != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("CallSign", 1);
					_writer.WriteString (CallSign);
				}
			if (RegistrationId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("RegistrationId", 1);
					_writer.WriteString (RegistrationId);
				}
			if (LogId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("LogId", 1);
					_writer.WriteString (LogId);
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
        public static new QueryRequest FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as QueryRequest;
				}
		    var Result = new QueryRequest ();
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
				case "CallSign" : {
					CallSign = jsonReader.ReadString ();
					break;
					}
				case "RegistrationId" : {
					RegistrationId = jsonReader.ReadString ();
					break;
					}
				case "LogId" : {
					LogId = jsonReader.ReadString ();
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
	/// Return the result of a QueryRequest
	/// </summary>
	public partial class QueryResponse : CallsignResponse {
        /// <summary>
        ///The registration specified in the result (if found).	
        /// </summary>

		public virtual Enveloped<Registration>						Result  {get; set;}
        /// <summary>
        ///The latest notarization entry corresponding to the specified log.
        /// </summary>

		public virtual Enveloped<Notarization>						Notarization  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "QueryResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new QueryResponse();


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
			((CallsignResponse)this).SerializeX(_writer, false, ref _first);
			if (Result != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Result", 1);
					Result.Serialize (_writer, false);
				}
			if (Notarization != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Notarization", 1);
					Notarization.Serialize (_writer, false);
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
        public static new QueryResponse FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as QueryResponse;
				}
		    var Result = new QueryResponse ();
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
				case "Result" : {
					// An untagged structure
					Result = new Enveloped<Registration> ();
					Result.Deserialize (jsonReader);
 
					break;
					}
				case "Notarization" : {
					// An untagged structure
					Notarization = new Enveloped<Notarization> ();
					Notarization.Deserialize (jsonReader);
 
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

