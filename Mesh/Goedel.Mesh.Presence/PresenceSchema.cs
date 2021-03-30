
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
//  This file was automatically generated at 3/30/2021 5:33:18 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.594
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


namespace Goedel.Mesh.Presence {


	/// <summary>
	///
	/// The Mesh Presence Protocol
	/// </summary>
	public abstract partial class PresenceProtocol : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "PresenceProtocol";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"AnnounceDeviceRequest", AnnounceDeviceRequest._Factory},
			{"AnnounceDeviceResponse", AnnounceDeviceResponse._Factory}			};

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
    public abstract partial class MeshPresence : Goedel.Protocol.JpcInterface {
		
        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "mmmp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown => WellKnown;

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_mmmp._tcp";

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
				case "AnnounceDevice" : {
					var request = new AnnounceDeviceRequest();
					request.Deserialize (jsonReader);
					response = AnnounceDevice (request, session);
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
				new MeshPresenceDirect () {
						JpcSession = jpcSession,
						Service = this
						};


        /// <summary>
		/// Base method for implementing the transaction  AnnounceDevice.
        /// </summary>
        /// <param name="request">The request object to send to the host.</param>
		/// <param name="session">The request context.</param>
		/// <returns>The response object from the service</returns>
        public abstract AnnounceDeviceResponse AnnounceDevice (
                AnnounceDeviceRequest request, IJpcSession session);

        }

    /// <summary>
	/// Client class for MeshPresence.
    /// </summary>		
    public partial class MeshPresenceClient :  Goedel.Protocol.JpcClientInterface {

	    /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string WellKnown = "mmmp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetWellKnown => WellKnown;

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public const string Discovery = "_mmmp._tcp";

        /// <summary>
        /// Well Known service identifier.
        /// </summary>
		public override string GetDiscovery => Discovery;



        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="request">The request object.</param>
		/// <returns>The response object</returns>
        public virtual AnnounceDeviceResponse AnnounceDevice (AnnounceDeviceRequest request) =>
				JpcSession.Post("AnnounceDevice", request) as AnnounceDeviceResponse;


		}

    /// <summary>
	/// Direct API class for MeshPresence.
    /// </summary>		
    public partial class MeshPresenceDirect: MeshPresenceClient {
 		
		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public MeshPresence Service {get; set;}


        /// <summary>
		/// Implement the transaction
        /// </summary>		
        /// <param name="request">The request object.</param>
		/// <returns>The response object</returns>
        public override AnnounceDeviceResponse AnnounceDevice (AnnounceDeviceRequest request) =>
				Service.AnnounceDevice (request, JpcSession);


		}


    /*
    /// <summary>
	/// Service class for MeshPresence.
    /// </summary>		
    public partial class MeshPresenceDispatch : Goedel.Protocol.JpcDispatch {

		/// <summary>
		/// Interface object to dispatch requests to.
		/// </summary>	
		public MeshPresence Service;


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
				case "AnnounceDevice" : {
					var request = new AnnounceDeviceRequest();
					request.Deserialize (jsonReader);
					response = Service.AnnounceDevice (request, session);
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
	/// Announce the device to the presence service
	/// </summary>
	public partial class AnnounceDeviceRequest : MeshRequest {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "AnnounceDeviceRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new AnnounceDeviceRequest();


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
        public static new AnnounceDeviceRequest FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as AnnounceDeviceRequest;
				}
		    var Result = new AnnounceDeviceRequest ();
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
	/// Reports the result of the presence request
	/// </summary>
	public partial class AnnounceDeviceResponse : MeshResponse {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "AnnounceDeviceResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new AnnounceDeviceResponse();


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
        public static new AnnounceDeviceResponse FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as AnnounceDeviceResponse;
				}
		    var Result = new AnnounceDeviceResponse ();
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

	}

