
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
//  This file was automatically generated at 9/20/2021 6:22:11 PM
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


using Goedel.Cryptography.Jose;


namespace Goedel.Cryptography.Dare {


	/// <summary>
	///
	/// Classes that describe the DARE Container Format.
	/// </summary>
	public abstract partial class SequenceData : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "SequenceData";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"SequenceInfo", SequenceInfo._Factory},
			{"SequenceIndex", SequenceIndex._Factory},
			{"IndexPosition", IndexPosition._Factory},
			{"KeyValue", KeyValue._Factory}			};

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
	/// Information that describes container information
	/// </summary>
	public partial class SequenceInfo : SequenceData {
        /// <summary>
        ///Specifies the data encoding for the header section of for the following frames.
        ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
        /// </summary>

		public virtual string						DataEncoding  {get; set;}
        /// <summary>
        ///Specifies the container type for the following records.
        ///This value is ONLY valid in Frame 0 which MUST have a header encoded in JSON.
        /// </summary>

		public virtual string						ContainerType  {get; set;}
		bool								__Index = false;
		private int						_Index;
        /// <summary>
        ///The record index within the file. This MUST be unique and 
        ///satisfy any additional requirements determined by the ContainerType.
        /// </summary>

		public virtual int						Index {
			get => _Index;
			set {_Index = value; __Index = true; }
			}
		bool								__IsMeta = false;
		private bool						_IsMeta;
        /// <summary>
        ///If true, the current frame is a meta frame and does not contain a payload.
        ///Note: Meta frames MAY be present in any container. Applications MUST
        ///accept containers that contain meta frames at any position in the file.
        ///Applications MUST NOT interpret a meta frame as a data frame with an enpty payload.
        /// </summary>

		public virtual bool						IsMeta {
			get => _IsMeta;
			set {_IsMeta = value; __IsMeta = true; }
			}
		bool								__Default = false;
		private bool						_Default;
        /// <summary>
        ///If set true in a persistent container, specifies that this record contains
        ///the default object for the container.
        /// </summary>

		public virtual bool						Default {
			get => _Default;
			set {_Default = value; __Default = true; }
			}
		bool								__TreePosition = false;
		private int						_TreePosition;
        /// <summary>
        ///Position of the frame containing the apex of the preceding sub-tree.
        /// </summary>

		public virtual int						TreePosition {
			get => _TreePosition;
			set {_TreePosition = value; __TreePosition = true; }
			}
		bool								__IndexPosition = false;
		private int						_IndexPosition;
        /// <summary>
        ///Specifies the position in the file at which the last index entry is
        ///to be found
        /// </summary>

		public virtual int						IndexPosition {
			get => _IndexPosition;
			set {_IndexPosition = value; __IndexPosition = true; }
			}
		bool								__ExchangePosition = false;
		private int						_ExchangePosition;
        /// <summary>
        ///Specifies the position in the file at which the key exchange data is
        ///to be found
        /// </summary>

		public virtual int						ExchangePosition {
			get => _ExchangePosition;
			set {_ExchangePosition = value; __ExchangePosition = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "SequenceInfo";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new SequenceInfo();


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
			if (DataEncoding != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DataEncoding", 1);
					_writer.WriteString (DataEncoding);
				}
			if (ContainerType != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContainerType", 1);
					_writer.WriteString (ContainerType);
				}
			if (__Index){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Index", 1);
					_writer.WriteInteger32 (Index);
				}
			if (__IsMeta){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IsMeta", 1);
					_writer.WriteBoolean (IsMeta);
				}
			if (__Default){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Default", 1);
					_writer.WriteBoolean (Default);
				}
			if (__TreePosition){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("TreePosition", 1);
					_writer.WriteInteger32 (TreePosition);
				}
			if (__IndexPosition){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IndexPosition", 1);
					_writer.WriteInteger32 (IndexPosition);
				}
			if (__ExchangePosition){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ExchangePosition", 1);
					_writer.WriteInteger32 (ExchangePosition);
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
        public static new SequenceInfo FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as SequenceInfo;
				}
		    var Result = new SequenceInfo ();
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
				case "DataEncoding" : {
					DataEncoding = jsonReader.ReadString ();
					break;
					}
				case "ContainerType" : {
					ContainerType = jsonReader.ReadString ();
					break;
					}
				case "Index" : {
					Index = jsonReader.ReadInteger32 ();
					break;
					}
				case "IsMeta" : {
					IsMeta = jsonReader.ReadBoolean ();
					break;
					}
				case "Default" : {
					Default = jsonReader.ReadBoolean ();
					break;
					}
				case "TreePosition" : {
					TreePosition = jsonReader.ReadInteger32 ();
					break;
					}
				case "IndexPosition" : {
					IndexPosition = jsonReader.ReadInteger32 ();
					break;
					}
				case "ExchangePosition" : {
					ExchangePosition = jsonReader.ReadInteger32 ();
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
	/// A container index
	/// </summary>
	public partial class SequenceIndex : SequenceData {
		bool								__Full = false;
		private bool						_Full;
        /// <summary>
        ///If true, the index is complete and contains position entries for all the 
        ///frames in the file. If absent or false, the index is incremental and only
        ///contains position entries for records added since the last 
        ///frame containing a ContainerIndex.
        /// </summary>

		public virtual bool						Full {
			get => _Full;
			set {_Full = value; __Full = true; }
			}
        /// <summary>
        ///List of container position entries
        /// </summary>

		public virtual List<IndexPosition>				Positions  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "SequenceIndex";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new SequenceIndex();


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
			if (__Full){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Full", 1);
					_writer.WriteBoolean (Full);
				}
			if (Positions != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Positions", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Positions) {
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
        public static new SequenceIndex FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as SequenceIndex;
				}
		    var Result = new SequenceIndex ();
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
				case "Full" : {
					Full = jsonReader.ReadBoolean ();
					break;
					}
				case "Positions" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Positions = new List <IndexPosition> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  IndexPosition ();
						_Item.Deserialize (jsonReader);
						// var _Item = new IndexPosition (jsonReader);
						Positions.Add (_Item);
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
	/// Specifies the position in a file at which a specified record index is found
	/// </summary>
	public partial class IndexPosition : SequenceData {
		bool								__Index = false;
		private int						_Index;
        /// <summary>
        ///The record index within the file.
        /// </summary>

		public virtual int						Index {
			get => _Index;
			set {_Index = value; __Index = true; }
			}
		bool								__Position = false;
		private int						_Position;
        /// <summary>
        ///The record position within the file relative to the index base.
        /// </summary>

		public virtual int						Position {
			get => _Position;
			set {_Position = value; __Position = true; }
			}
        /// <summary>
        ///Unique object identifier
        /// </summary>

		public virtual string						UniqueId  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "IndexPosition";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new IndexPosition();


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
			if (__Index){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Index", 1);
					_writer.WriteInteger32 (Index);
				}
			if (__Position){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Position", 1);
					_writer.WriteInteger32 (Position);
				}
			if (UniqueId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UniqueId", 1);
					_writer.WriteString (UniqueId);
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
        public static new IndexPosition FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as IndexPosition;
				}
		    var Result = new IndexPosition ();
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
				case "Index" : {
					Index = jsonReader.ReadInteger32 ();
					break;
					}
				case "Position" : {
					Position = jsonReader.ReadInteger32 ();
					break;
					}
				case "UniqueId" : {
					UniqueId = jsonReader.ReadString ();
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
	/// Specifies a key/value entry
	/// </summary>
	public partial class KeyValue : SequenceData {
        /// <summary>
        ///The key
        /// </summary>

		public virtual string						Key  {get; set;}
        /// <summary>
        ///The value corresponding to the key
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

	}

