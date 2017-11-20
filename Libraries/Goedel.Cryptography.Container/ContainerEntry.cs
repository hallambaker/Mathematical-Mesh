
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


namespace Goedel.Cryptography.Container {


	/// <summary>
	///
	/// Classes that describe Mail applications.
	/// </summary>
	public abstract partial class ContainerData : global::Goedel.Protocol.JSONObject {

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
		public override string _Tag { get; } = "ContainerData";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"ContainerFrame", ContainerFrame._Factory},
			{"ContainerHeader", ContainerHeader._Factory},
			{"ContainerIndex", ContainerIndex._Factory},
			{"IndexPosition", IndexPosition._Factory},
			{"KeyValue", KeyValue._Factory},
			{"IndexMeta", IndexMeta._Factory}			};

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



		// Transaction Classes
	/// <summary>
	///
	/// Describes a container frame
	/// </summary>
	public partial class ContainerFrame : ContainerData {
        /// <summary>
        ///The frame header
        /// </summary>

		public virtual ContainerHeader						Header  {get; set;}
        /// <summary>
        ///The frame payload
        /// </summary>

		public virtual byte[]						Payload  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContainerFrame";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContainerFrame();
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
			if (Header != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Header", 1);
					Header.Serialize (_Writer, false);
				}
			if (Payload != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Payload", 1);
					_Writer.WriteBinary (Payload);
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
        public static new ContainerFrame FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContainerFrame;
				}
		    var Result = new ContainerFrame ();
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
				case "Header" : {
					// An untagged structure
					Header = new ContainerHeader ();
					Header.Deserialize (JSONReader);
 
					break;
					}
				case "Payload" : {
					Payload = JSONReader.ReadBinary ();
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
	/// Describes a container header
	/// </summary>
	public partial class ContainerHeader : ContainerData {
		bool								__Index = false;
		private int						_Index;
        /// <summary>
        ///The record index within the file. This MUST be unique and 
        ///satisfy any additional requirements determined by the ContainerType.
        /// </summary>

		public virtual int						Index {
			get {return _Index;}
			set {_Index = value; __Index = true; }
			}
        /// <summary>
        ///Specifies the container type for the following records.
        /// </summary>

		public virtual string						ContainerType  {get; set;}
		bool								__IsMeta = false;
		private bool						_IsMeta;
        /// <summary>
        ///If true, the current frame is a meta frame and does not contain a payload.
        ///Note: Meta frames MAY be present in any container. Applications MUST
        ///accept containers that contain meta frames at any position in the file.
        ///Applications MUST NOT interpret a meta frame as a data frame with an enpty payload.
        /// </summary>

		public virtual bool						IsMeta {
			get {return _IsMeta;}
			set {_IsMeta = value; __IsMeta = true; }
			}
		bool								__TreePosition = false;
		private int						_TreePosition;
        /// <summary>
        ///Position of the frame containing the apex of the preceding sub-tree.
        /// </summary>

		public virtual int						TreePosition {
			get {return _TreePosition;}
			set {_TreePosition = value; __TreePosition = true; }
			}
		bool								__IndexPosition = false;
		private int						_IndexPosition;
        /// <summary>
        ///Specifies the position in the file at which the last index entry is
        ///to be found
        /// </summary>

		public virtual int						IndexPosition {
			get {return _IndexPosition;}
			set {_IndexPosition = value; __IndexPosition = true; }
			}
		bool								__ExchangePosition = false;
		private int						_ExchangePosition;
        /// <summary>
        ///Specifies the position in the file at which the key exchange data is
        ///to be found
        /// </summary>

		public virtual int						ExchangePosition {
			get {return _ExchangePosition;}
			set {_ExchangePosition = value; __ExchangePosition = true; }
			}
        /// <summary>
        ///An index of records in the current container up to but not including
        ///this one.
        /// </summary>

		public virtual ContainerIndex						ContainerIndex  {get; set;}
        /// <summary>
        ///If present, contains the digest of the Payload.
        /// </summary>

		public virtual byte[]						PayloadDigest  {get; set;}
        /// <summary>
        ///If present, contains the digest of the PayloadDigest values of this
        ///frame and the frame immediately preceding.
        /// </summary>

		public virtual byte[]						ChainDigest  {get; set;}
        /// <summary>
        ///If present, contains the Binary Merkle Tree digest value.
        /// </summary>

		public virtual byte[]						TreeDigest  {get; set;}
        /// <summary>
        ///Content type parameter
        /// </summary>

		public virtual string						ContentType  {get; set;}
        /// <summary>
        ///List of filename paths for the payload of the frame.
        /// </summary>

		public virtual List<string>				Paths  {get; set;}
        /// <summary>
        ///List of labels that are applied to the payload of the frame.
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
        /// <summary>
        ///List of key/value pairs describing the payload of the frame.
        /// </summary>

		public virtual List<KeyValue>				KeyValues  {get; set;}
        /// <summary>
        ///Session key encrypted under a key exchange specified in the Recipients 
        ///list of this frame (if present) or the frame at the position specified by
        ///exchange position (if present) or the first frame.
        /// </summary>

		public virtual byte[]						EncryptedKey  {get; set;}
        /// <summary>
        ///Per signer signature data
        /// </summary>

		public virtual List<Signature>				Signatures  {get; set;}
        /// <summary>
        ///Per recipient key exchange data.
        /// </summary>

		public virtual List<Recipient>				Recipients  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContainerHeader";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContainerHeader();
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
			if (__Index){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Index", 1);
					_Writer.WriteInteger32 (Index);
				}
			if (ContainerType != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ContainerType", 1);
					_Writer.WriteString (ContainerType);
				}
			if (__IsMeta){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("IsMeta", 1);
					_Writer.WriteBoolean (IsMeta);
				}
			if (__TreePosition){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TreePosition", 1);
					_Writer.WriteInteger32 (TreePosition);
				}
			if (__IndexPosition){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("IndexPosition", 1);
					_Writer.WriteInteger32 (IndexPosition);
				}
			if (__ExchangePosition){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ExchangePosition", 1);
					_Writer.WriteInteger32 (ExchangePosition);
				}
			if (ContainerIndex != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ContainerIndex", 1);
					ContainerIndex.Serialize (_Writer, false);
				}
			if (PayloadDigest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PayloadDigest", 1);
					_Writer.WriteBinary (PayloadDigest);
				}
			if (ChainDigest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ChainDigest", 1);
					_Writer.WriteBinary (ChainDigest);
				}
			if (TreeDigest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TreeDigest", 1);
					_Writer.WriteBinary (TreeDigest);
				}
			if (ContentType != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ContentType", 1);
					_Writer.WriteString (ContentType);
				}
			if (Paths != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Paths", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Paths) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Labels != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Labels", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Labels) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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

			if (EncryptedKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedKey", 1);
					_Writer.WriteBinary (EncryptedKey);
				}
			if (Signatures != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Signatures", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signatures) {
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

			if (Recipients != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Recipients", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Recipients) {
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
        public static new ContainerHeader FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContainerHeader;
				}
		    var Result = new ContainerHeader ();
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
				case "Index" : {
					Index = JSONReader.ReadInteger32 ();
					break;
					}
				case "ContainerType" : {
					ContainerType = JSONReader.ReadString ();
					break;
					}
				case "IsMeta" : {
					IsMeta = JSONReader.ReadBoolean ();
					break;
					}
				case "TreePosition" : {
					TreePosition = JSONReader.ReadInteger32 ();
					break;
					}
				case "IndexPosition" : {
					IndexPosition = JSONReader.ReadInteger32 ();
					break;
					}
				case "ExchangePosition" : {
					ExchangePosition = JSONReader.ReadInteger32 ();
					break;
					}
				case "ContainerIndex" : {
					// An untagged structure
					ContainerIndex = new ContainerIndex ();
					ContainerIndex.Deserialize (JSONReader);
 
					break;
					}
				case "PayloadDigest" : {
					PayloadDigest = JSONReader.ReadBinary ();
					break;
					}
				case "ChainDigest" : {
					ChainDigest = JSONReader.ReadBinary ();
					break;
					}
				case "TreeDigest" : {
					TreeDigest = JSONReader.ReadBinary ();
					break;
					}
				case "ContentType" : {
					ContentType = JSONReader.ReadString ();
					break;
					}
				case "Paths" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Paths = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Paths.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Labels" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Labels = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Labels.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
				case "EncryptedKey" : {
					EncryptedKey = JSONReader.ReadBinary ();
					break;
					}
				case "Signatures" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Signatures = new List <Signature> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Signature ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Signature (JSONReader);
						Signatures.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Recipients" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Recipients = new List <Recipient> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Recipient ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Recipient (JSONReader);
						Recipients.Add (_Item);
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
	/// A container index
	/// </summary>
	public partial class ContainerIndex : ContainerData {
		bool								__Full = false;
		private bool						_Full;
        /// <summary>
        ///If true, the index is complete and contains position entries for all the 
        ///frames in the file. If absent or false, the index is incremental and only
        ///contains position entries for records added since the last 
        ///frame containing a ContainerIndex.
        /// </summary>

		public virtual bool						Full {
			get {return _Full;}
			set {_Full = value; __Full = true; }
			}
        /// <summary>
        ///List of container position entries
        /// </summary>

		public virtual List<IndexPosition>				Positions  {get; set;}
        /// <summary>
        ///List of container position entries
        /// </summary>

		public virtual List<IndexMeta>				Metas  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContainerIndex";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContainerIndex();
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
			if (__Full){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Full", 1);
					_Writer.WriteBoolean (Full);
				}
			if (Positions != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Positions", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Positions) {
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

			if (Metas != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Metas", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Metas) {
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
        public static new ContainerIndex FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContainerIndex;
				}
		    var Result = new ContainerIndex ();
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
				case "Full" : {
					Full = JSONReader.ReadBoolean ();
					break;
					}
				case "Positions" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Positions = new List <IndexPosition> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  IndexPosition ();
						_Item.Deserialize (JSONReader);
						// var _Item = new IndexPosition (JSONReader);
						Positions.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Metas" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Metas = new List <IndexMeta> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  IndexMeta ();
						_Item.Deserialize (JSONReader);
						// var _Item = new IndexMeta (JSONReader);
						Metas.Add (_Item);
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
	/// Specifies the position in a file at which a specified record index is found
	/// </summary>
	public partial class IndexPosition : ContainerData {
		bool								__Index = false;
		private int						_Index;
        /// <summary>
        ///The record index within the file.
        /// </summary>

		public virtual int						Index {
			get {return _Index;}
			set {_Index = value; __Index = true; }
			}
		bool								__Position = false;
		private int						_Position;
        /// <summary>
        ///The record position within the file relative to the index base.
        /// </summary>

		public virtual int						Position {
			get {return _Position;}
			set {_Position = value; __Position = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "IndexPosition";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new IndexPosition();
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
			if (__Index){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Index", 1);
					_Writer.WriteInteger32 (Index);
				}
			if (__Position){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Position", 1);
					_Writer.WriteInteger32 (Position);
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
        public static new IndexPosition FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as IndexPosition;
				}
		    var Result = new IndexPosition ();
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
				case "Index" : {
					Index = JSONReader.ReadInteger32 ();
					break;
					}
				case "Position" : {
					Position = JSONReader.ReadInteger32 ();
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
	public partial class KeyValue : ContainerData {
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
		public override string _Tag { get; } = "KeyValue";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new KeyValue();
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
	/// Specifies the list of index entries at which a record with the specified metadata occurrs.
	/// </summary>
	public partial class IndexMeta : ContainerData {
        /// <summary>
        ///List of record indicies within the file where frames matching the specified 
        ///criteria are found.
        /// </summary>

		public virtual List<int>				Index  {get; set;}
        /// <summary>
        ///Content type parameter
        /// </summary>

		public virtual string						ContentType  {get; set;}
        /// <summary>
        ///List of filename paths for the current frame.
        /// </summary>

		public virtual List<string>				Paths  {get; set;}
        /// <summary>
        ///List of labels that are applied to the current frame.
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "IndexMeta";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new IndexMeta();
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
			if (Index != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Index", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Index) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteInteger32 (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (ContentType != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ContentType", 1);
					_Writer.WriteString (ContentType);
				}
			if (Paths != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Paths", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Paths) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Labels != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Labels", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Labels) {
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
        public static new IndexMeta FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as IndexMeta;
				}
		    var Result = new IndexMeta ();
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
				case "Index" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Index = new List <int> ();
					while (_Going) {
						int _Item = JSONReader.ReadInteger32 ();
						Index.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "ContentType" : {
					ContentType = JSONReader.ReadString ();
					break;
					}
				case "Paths" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Paths = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Paths.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Labels" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Labels = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Labels.Add (_Item);
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

	}

