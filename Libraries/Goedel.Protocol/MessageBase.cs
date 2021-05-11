
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
//  This file was automatically generated at 5/11/2021 1:05:35 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.615
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




namespace Goedel.Protocol {


	/// <summary>
	///
	/// Base class for all PROTOGEN messages
	/// </summary>
	public abstract partial class Message : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Message";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"Request", Request._Factory},
			{"Response", Response._Factory},
			{"Version", Version._Factory},
			{"Encoding", Encoding._Factory},
			{"HelloRequest", HelloRequest._Factory},
			{"HelloResponse", HelloResponse._Factory}			};

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



		// Transaction Classes
	/// <summary>
	///
	/// Base class for all request messages.
	/// </summary>
	abstract public partial class Request : Message {
        /// <summary>
        ///Name of the Service to which the request is directed.
        /// </summary>

		public virtual string						Service  {get; set;}
        /// <summary>
        ///Optional unique transaction request used to detect replay attacks and 
        ///duplicates.
        /// </summary>

		public virtual byte[]						ID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Request";

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
			if (Service != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Service", 1);
					_writer.WriteString (Service);
				}
			if (ID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ID", 1);
					_writer.WriteBinary (ID);
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
        public static new Request FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Request;
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
				case "Service" : {
					Service = jsonReader.ReadString ();
					break;
					}
				case "ID" : {
					ID = jsonReader.ReadBinary ();
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
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// A service MAY return either the response message specified
	/// for that transaction or any parent of that message. 
	/// Thus the RecryptResponse message MAY be returned in response 
	/// to any request.
	/// </summary>
	abstract public partial class Response : Message {
		bool								__Status = false;
		private int						_Status;
        /// <summary>
        ///Major status return code. The SMTP/HTTP scheme of 2xx = Success,
        ///3xx = incomplete, 4xx = failure is followed.
        /// </summary>

		public virtual int						Status {
			get => _Status;
			set {_Status = value; __Status = true; }
			}
		bool								__StatusExtended = false;
		private int						_StatusExtended;
        /// <summary>
        ///Application level status report giving additional information.
        /// </summary>

		public virtual int						StatusExtended {
			get => _StatusExtended;
			set {_StatusExtended = value; __StatusExtended = true; }
			}
        /// <summary>
        ///Text description of the status return code for debugging 
        ///and log file use.
        /// </summary>

		public virtual string						StatusDescription  {get; set;}
        /// <summary>
        ///The request to which the response corresponds.
        /// </summary>

		public virtual byte[]						ID  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Response";

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
			if (__Status){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Status", 1);
					_writer.WriteInteger32 (Status);
				}
			if (__StatusExtended){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("StatusExtended", 1);
					_writer.WriteInteger32 (StatusExtended);
				}
			if (StatusDescription != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("StatusDescription", 1);
					_writer.WriteString (StatusDescription);
				}
			if (ID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ID", 1);
					_writer.WriteBinary (ID);
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
        public static new Response FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Response;
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
				case "Status" : {
					Status = jsonReader.ReadInteger32 ();
					break;
					}
				case "StatusExtended" : {
					StatusExtended = jsonReader.ReadInteger32 ();
					break;
					}
				case "StatusDescription" : {
					StatusDescription = jsonReader.ReadString ();
					break;
					}
				case "ID" : {
					ID = jsonReader.ReadBinary ();
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
	/// Describes a protocol version.
	/// </summary>
	public partial class Version : Message {
		bool								__Major = false;
		private int						_Major;
        /// <summary>
        ///Major version number of the service protocol. A higher
        /// </summary>

		public virtual int						Major {
			get => _Major;
			set {_Major = value; __Major = true; }
			}
		bool								__Minor = false;
		private int						_Minor;
        /// <summary>
        ///Minor version number of the service protocol.
        /// </summary>

		public virtual int						Minor {
			get => _Minor;
			set {_Minor = value; __Minor = true; }
			}
        /// <summary>
        ///Enumerates alternative encodings (e.g. ASN.1, XML, JSON-B)
        ///supported by the service. If no encodings are specified, the
        ///JSON encoding is assumed.
        /// </summary>

		public virtual List<Encoding>				Encodings  {get; set;}
        /// <summary>
        ///The preferred URI for this service. This MAY be used to effect
        ///a redirect in the case that a service moves.
        /// </summary>

		public virtual List<string>				URI  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Version";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new Version();


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
			if (__Major){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Major", 1);
					_writer.WriteInteger32 (Major);
				}
			if (__Minor){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Minor", 1);
					_writer.WriteInteger32 (Minor);
				}
			if (Encodings != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Encodings", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encodings) {
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

			if (URI != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("URI", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in URI) {
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
        public static new Version FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Version;
				}
		    var Result = new Version ();
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
				case "Major" : {
					Major = jsonReader.ReadInteger32 ();
					break;
					}
				case "Minor" : {
					Minor = jsonReader.ReadInteger32 ();
					break;
					}
				case "Encodings" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Encodings = new List <Encoding> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Encoding ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Encoding (jsonReader);
						Encodings.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "URI" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					URI = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						URI.Add (_Item);
						_Going = jsonReader.NextArray ();
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
	/// Describes a message content encoding.
	/// </summary>
	public partial class Encoding : Message {
        /// <summary>
        ///The IANA encoding name
        /// </summary>

		public virtual List<string>				ID  {get; set;}
        /// <summary>
        ///For encodings that employ a named dictionary for tag or data
        ///compression, the name of the dictionary as defined by that 
        ///encoding scheme. 
        /// </summary>

		public virtual List<string>				Dictionary  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Encoding";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new Encoding();


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
			if (ID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ID", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ID) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Dictionary != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Dictionary", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Dictionary) {
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
        public static new Encoding FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Encoding;
				}
		    var Result = new Encoding ();
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
				case "ID" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					ID = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						ID.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Dictionary" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Dictionary = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Dictionary.Add (_Item);
						_Going = jsonReader.NextArray ();
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
	/// Request service description.
	/// </summary>
	public partial class HelloRequest : Request {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "HelloRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new HelloRequest();


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
			((Request)this).SerializeX(_writer, false, ref _first);
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
        public static new HelloRequest FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as HelloRequest;
				}
		    var Result = new HelloRequest ();
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
	/// Always reports success. Describes the configuration of the service.
	/// </summary>
	public partial class HelloResponse : Response {
        /// <summary>
        ///Enumerates the protocol versions supported
        /// </summary>

		public virtual Version						Version  {get; set;}
        /// <summary>
        ///Enumerates alternate protocol version(s) supported
        /// </summary>

		public virtual List<Version>				Alternates  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "HelloResponse";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new HelloResponse();


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
			((Response)this).SerializeX(_writer, false, ref _first);
			if (Version != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Version", 1);
					Version.Serialize (_writer, false);
				}
			if (Alternates != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Alternates", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Alternates) {
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
        public static new HelloResponse FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as HelloResponse;
				}
		    var Result = new HelloResponse ();
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
				case "Version" : {
					// An untagged structure
					Version = new Version ();
					Version.Deserialize (jsonReader);
 
					break;
					}
				case "Alternates" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Alternates = new List <Version> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Version ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Version (jsonReader);
						Alternates.Add (_Item);
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

