
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
#pragma warning disable IDE1006


using Goedel.Cryptography.Jose;


namespace Goedel.Cryptography.Dare {


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
	public abstract partial class Dare : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Dare";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"DareEnvelopeSequence", DareEnvelopeSequence._Factory},
			{"DareTrailer", DareTrailer._Factory},
			{"DareHeader", DareHeader._Factory},
			{"ContentMeta", ContentMeta._Factory},
			{"DareSignature", DareSignature._Factory},
			{"X509Certificate", X509Certificate._Factory},
			{"DareRecipient", DareRecipient._Factory},
			{"DarePolicy", DarePolicy._Factory}			};

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
	/// A DARE envelope containing Header, EDS and Trailer in JSON object encoding.
	/// Since a DAREMessage is almost invariably presented in JSON sequence or
	/// compact encoding, use of the DAREMessage subclass is preferred.
	/// Although a DARE envelope is functionally an object, it is serialized as 
	/// an ordered sequence. This ensures that the envelope header field will always
	/// precede the body in a serialization, this allowing processing of the header
	/// information to be performed before the entire body has been received.
	/// </summary>
	public partial class DareEnvelopeSequence : Dare {
        /// <summary>
        ///The envelope header. May specify the key exchange data, pre-signature 
        ///or signature data, cloaked headers and/or encrypted data sequences.
        /// </summary>

		public virtual DareHeader						Header  {get; set;}
        /// <summary>
        ///The envelope body
        /// </summary>

		public virtual byte[]						Body  {get; set;}
        /// <summary>
        ///The envelope trailer. If present, this contains the signature.
        /// </summary>

		public virtual DareTrailer						Trailer  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareEnvelopeSequence";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DareEnvelopeSequence();


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
			if (Header != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Header", 1);
					Header.Serialize (_writer, false);
				}
			if (Body != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Body", 1);
					_writer.WriteBinary (Body);
				}
			if (Trailer != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Trailer", 1);
					Trailer.Serialize (_writer, false);
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
        public static new DareEnvelopeSequence FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DareEnvelopeSequence;
				}
		    var Result = new DareEnvelopeSequence ();
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
				case "Header" : {
					// An untagged structure
					Header = new DareHeader ();
					Header.Deserialize (jsonReader);
 
					break;
					}
				case "Body" : {
					Body = jsonReader.ReadBinary ();
					break;
					}
				case "Trailer" : {
					// An untagged structure
					Trailer = new DareTrailer ();
					Trailer.Deserialize (jsonReader);
 
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
	/// A DARE envelope Trailer
	/// </summary>
	public partial class DareTrailer : Dare {
        /// <summary>
        ///A list of signatures.
        ///A envelope trailer MUST NOT contain a signatures field if the header contains 
        ///a signatures field.
        /// </summary>

		public virtual List<DareSignature>				Signatures  {get; set;}
        /// <summary>
        ///Contains a DAREHeader object 
        /// </summary>

		public virtual byte[]						SignedData  {get; set;}
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
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareTrailer";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DareTrailer();


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
			if (Signatures != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("signatures", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signatures) {
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

			if (SignedData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SignedData", 1);
					_writer.WriteBinary (SignedData);
				}
			if (PayloadDigest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PayloadDigest", 1);
					_writer.WriteBinary (PayloadDigest);
				}
			if (ChainDigest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ChainDigest", 1);
					_writer.WriteBinary (ChainDigest);
				}
			if (TreeDigest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("TreeDigest", 1);
					_writer.WriteBinary (TreeDigest);
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
        public static new DareTrailer FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DareTrailer;
				}
		    var Result = new DareTrailer ();
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
				case "signatures" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Signatures = new List <DareSignature> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareSignature ();
						_Item.Deserialize (jsonReader);
						// var _Item = new DareSignature (jsonReader);
						Signatures.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "SignedData" : {
					SignedData = jsonReader.ReadBinary ();
					break;
					}
				case "PayloadDigest" : {
					PayloadDigest = jsonReader.ReadBinary ();
					break;
					}
				case "ChainDigest" : {
					ChainDigest = jsonReader.ReadBinary ();
					break;
					}
				case "TreeDigest" : {
					TreeDigest = jsonReader.ReadBinary ();
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
	/// A DARE Envelope Header. Since any field that is present in a trailer MAY be 
	/// placed in a header instead, the envelope header inherits from the trailer.
	/// </summary>
	public partial class DareHeader : DareTrailer {
        /// <summary>
        ///Unique identifier
        /// </summary>

		public virtual string						EnvelopeID  {get; set;}
        /// <summary>
        ///The encryption algorithm as specified in JWE
        /// </summary>

		public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
        ///construct a signature over the envelope payload.
        /// </summary>

		public virtual string						DigestAlgorithm  {get; set;}
        /// <summary>
        ///Base seed identifier.
        /// </summary>

		public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///Salt value used to derrive cryptographic parameters for the content data.
        /// </summary>

		public virtual byte[]						Salt  {get; set;}
        /// <summary>
        ///Hash of the Salt value used to derrive cryptographic parameters for the content data.
        ///This field SHOULD NOT be present if the Salt field is present. It is used to
        ///allow the salt value to be erased (thus rendering the payload content irrecoverable)
        ///without affecting the ability to calculate the payload digest value.
        /// </summary>

		public virtual byte[]						Malt  {get; set;}
        /// <summary>
        ///If present in a header or trailer, specifies an encrypted data block 
        ///containing additional header fields whose values override those specified 
        ///in the envelope and context headers.
        ///When specified in a header, a cloaked field MAY be used to conceal metadata 
        ///(content type, compression) and/or to specify an additional layer of key exchange. 
        ///That applies to both the envelope body and to headers specified within the cloaked 
        ///header.
        ///Processing of cloaked data is described in…
        /// </summary>

		public virtual byte[]						Cloaked  {get; set;}
        /// <summary>
        ///If present, the Annotations field contains a sequence of Encrypted Data 
        ///Segments encrypted under the envelope base seed. The interpretation of these fields 
        ///is application specific.
        /// </summary>

		public virtual List<byte[]>				EDSS  {get; set;}
        /// <summary>
        ///A list of 'presignature'
        /// </summary>

		public virtual List<DareSignature>				Signers  {get; set;}
        /// <summary>
        ///A list of recipient key exchange information blocks.
        /// </summary>

		public virtual List<DareRecipient>				Recipients  {get; set;}
        /// <summary>
        ///A DARE security policy governing future additions to the container.
        /// </summary>

		public virtual DarePolicy						Policy  {get; set;}
        /// <summary>
        ///If present contains a JSON encoded ContentInfo structure which specifies
        ///plaintext content metadata and forms one of the inputs to the envelope digest value.
        /// </summary>

		public virtual byte[]						ContentMetaData  {get; set;}
        /// <summary>
        ///Information that describes container information
        /// </summary>

		public virtual ContainerInfo						ContainerInfo  {get; set;}
        /// <summary>
        ///An index of records in the current container up to but not including
        ///this one.
        /// </summary>

		public virtual ContainerIndex						ContainerIndex  {get; set;}
        /// <summary>
        ///Date on which the envelope was received.
        /// </summary>

		public virtual DateTime?						Received  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareHeader";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DareHeader();


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
			((DareTrailer)this).SerializeX(_writer, false, ref _first);
			if (EnvelopeID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopeID", 1);
					_writer.WriteString (EnvelopeID);
				}
			if (EncryptionAlgorithm != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("enc", 1);
					_writer.WriteString (EncryptionAlgorithm);
				}
			if (DigestAlgorithm != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("dig", 1);
					_writer.WriteString (DigestAlgorithm);
				}
			if (KeyIdentifier != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("kid", 1);
					_writer.WriteString (KeyIdentifier);
				}
			if (Salt != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Salt", 1);
					_writer.WriteBinary (Salt);
				}
			if (Malt != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Malt", 1);
					_writer.WriteBinary (Malt);
				}
			if (Cloaked != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("cloaked", 1);
					_writer.WriteBinary (Cloaked);
				}
			if (EDSS != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("annotations", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EDSS) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteBinary (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Signers != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("signatures", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signers) {
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

			if (Recipients != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("recipients", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Recipients) {
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

			if (Policy != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("policy", 1);
					Policy.Serialize (_writer, false);
				}
			if (ContentMetaData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContentMetaData", 1);
					_writer.WriteBinary (ContentMetaData);
				}
			if (ContainerInfo != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContainerInfo", 1);
					ContainerInfo.Serialize (_writer, false);
				}
			if (ContainerIndex != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContainerIndex", 1);
					ContainerIndex.Serialize (_writer, false);
				}
			if (Received != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Received", 1);
					_writer.WriteDateTime (Received);
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
        public static new DareHeader FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DareHeader;
				}
		    var Result = new DareHeader ();
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
				case "EnvelopeID" : {
					EnvelopeID = jsonReader.ReadString ();
					break;
					}
				case "enc" : {
					EncryptionAlgorithm = jsonReader.ReadString ();
					break;
					}
				case "dig" : {
					DigestAlgorithm = jsonReader.ReadString ();
					break;
					}
				case "kid" : {
					KeyIdentifier = jsonReader.ReadString ();
					break;
					}
				case "Salt" : {
					Salt = jsonReader.ReadBinary ();
					break;
					}
				case "Malt" : {
					Malt = jsonReader.ReadBinary ();
					break;
					}
				case "cloaked" : {
					Cloaked = jsonReader.ReadBinary ();
					break;
					}
				case "annotations" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					EDSS = new List <byte[]> ();
					while (_Going) {
						byte[] _Item = jsonReader.ReadBinary ();
						EDSS.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "signatures" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Signers = new List <DareSignature> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareSignature ();
						_Item.Deserialize (jsonReader);
						// var _Item = new DareSignature (jsonReader);
						Signers.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "recipients" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Recipients = new List <DareRecipient> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareRecipient ();
						_Item.Deserialize (jsonReader);
						// var _Item = new DareRecipient (jsonReader);
						Recipients.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "policy" : {
					// An untagged structure
					Policy = new DarePolicy ();
					Policy.Deserialize (jsonReader);
 
					break;
					}
				case "ContentMetaData" : {
					ContentMetaData = jsonReader.ReadBinary ();
					break;
					}
				case "ContainerInfo" : {
					// An untagged structure
					ContainerInfo = new ContainerInfo ();
					ContainerInfo.Deserialize (jsonReader);
 
					break;
					}
				case "ContainerIndex" : {
					// An untagged structure
					ContainerIndex = new ContainerIndex ();
					ContainerIndex.Deserialize (jsonReader);
 
					break;
					}
				case "Received" : {
					Received = jsonReader.ReadDateTime ();
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
	/// </summary>
	public partial class ContentMeta : Dare {
        /// <summary>
        ///Unique object identifier
        /// </summary>

		public virtual string						UniqueID  {get; set;}
        /// <summary>
        ///List of labels that are applied to the payload of the frame.
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
        /// <summary>
        ///List of key/value pairs describing the payload of the frame.
        /// </summary>

		public virtual List<KeyValue>				KeyValues  {get; set;}
        /// <summary>
        ///The mesh message type
        /// </summary>

		public virtual string						MessageType  {get; set;}
        /// <summary>
        ///The content type field as specified in JWE
        /// </summary>

		public virtual string						ContentType  {get; set;}
        /// <summary>
        ///List of filename paths for the payload of the frame.
        /// </summary>

		public virtual List<string>				Paths  {get; set;}
        /// <summary>
        ///The original filename under which the data was stored.
        /// </summary>

		public virtual string						Filename  {get; set;}
        /// <summary>
        ///Operation on the header
        /// </summary>

		public virtual string						Event  {get; set;}
        /// <summary>
        ///Initial creation date.
        /// </summary>

		public virtual DateTime?						Created  {get; set;}
        /// <summary>
        ///Date of last modification.
        /// </summary>

		public virtual DateTime?						Modified  {get; set;}
        /// <summary>
        ///Date at which the associated transaction will expire
        /// </summary>

		public virtual DateTime?						Expire  {get; set;}
		bool								__First = false;
		private int						_First;
        /// <summary>
        ///Frame number of the first object instance value.
        /// </summary>

		public virtual int						First {
			get => _First;
			set {_First = value; __First = true; }
			}
		bool								__Previous = false;
		private int						_Previous;
        /// <summary>
        ///Frame number of the immediately prior object instance value	
        /// </summary>

		public virtual int						Previous {
			get => _Previous;
			set {_Previous = value; __Previous = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ContentMeta";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new ContentMeta();


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
			if (UniqueID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UniqueID", 1);
					_writer.WriteString (UniqueID);
				}
			if (Labels != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Labels", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Labels) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (KeyValues != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyValues", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeyValues) {
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

			if (MessageType != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MessageType", 1);
					_writer.WriteString (MessageType);
				}
			if (ContentType != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("cty", 1);
					_writer.WriteString (ContentType);
				}
			if (Paths != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Paths", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Paths) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Filename != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Filename", 1);
					_writer.WriteString (Filename);
				}
			if (Event != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Event", 1);
					_writer.WriteString (Event);
				}
			if (Created != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Created", 1);
					_writer.WriteDateTime (Created);
				}
			if (Modified != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Modified", 1);
					_writer.WriteDateTime (Modified);
				}
			if (Expire != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Expire", 1);
					_writer.WriteDateTime (Expire);
				}
			if (__First){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("First", 1);
					_writer.WriteInteger32 (First);
				}
			if (__Previous){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Previous", 1);
					_writer.WriteInteger32 (Previous);
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
        public static new ContentMeta FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ContentMeta;
				}
		    var Result = new ContentMeta ();
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
				case "UniqueID" : {
					UniqueID = jsonReader.ReadString ();
					break;
					}
				case "Labels" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Labels = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Labels.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "KeyValues" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					KeyValues = new List <KeyValue> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  KeyValue ();
						_Item.Deserialize (jsonReader);
						// var _Item = new KeyValue (jsonReader);
						KeyValues.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "MessageType" : {
					MessageType = jsonReader.ReadString ();
					break;
					}
				case "cty" : {
					ContentType = jsonReader.ReadString ();
					break;
					}
				case "Paths" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Paths = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Paths.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Filename" : {
					Filename = jsonReader.ReadString ();
					break;
					}
				case "Event" : {
					Event = jsonReader.ReadString ();
					break;
					}
				case "Created" : {
					Created = jsonReader.ReadDateTime ();
					break;
					}
				case "Modified" : {
					Modified = jsonReader.ReadDateTime ();
					break;
					}
				case "Expire" : {
					Expire = jsonReader.ReadDateTime ();
					break;
					}
				case "First" : {
					First = jsonReader.ReadInteger32 ();
					break;
					}
				case "Previous" : {
					Previous = jsonReader.ReadInteger32 ();
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
	/// The signature value
	/// </summary>
	public partial class DareSignature : Dare {
        /// <summary>
        ///Digest algorithm hint. Specifying the digest algorithm to be applied
        ///to the envelope body allows the body to be processed in streaming mode.
        /// </summary>

		public virtual string						Dig  {get; set;}
        /// <summary>
        ///Key exchange algorithm
        /// </summary>

		public virtual string						Alg  {get; set;}
        /// <summary>
        ///Key identifier of the signature key.
        /// </summary>

		public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///PKIX certificate of signer.
        /// </summary>

		public virtual X509Certificate						Certificate  {get; set;}
        /// <summary>
        ///PKIX certificates that establish a trust path for the signer.
        /// </summary>

		public virtual X509Certificate						Path  {get; set;}
        /// <summary>
        ///The data description that was signed.
        /// </summary>

		public virtual byte[]						Manifest  {get; set;}
        /// <summary>
        ///The signature value as an Enhanced Data Sequence under the envelope base seed.
        /// </summary>

		public virtual byte[]						SignatureValue  {get; set;}
        /// <summary>
        ///The signature witness value used on an encrypted envelope to demonstrate that 
        ///the signature was authorized by a party with actual knowledge of the encryption 
        ///key used to encrypt the envelope.
        /// </summary>

		public virtual byte[]						WitnessValue  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareSignature";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DareSignature();


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
			if (Dig != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("dig", 1);
					_writer.WriteString (Dig);
				}
			if (Alg != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("alg", 1);
					_writer.WriteString (Alg);
				}
			if (KeyIdentifier != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("kid", 1);
					_writer.WriteString (KeyIdentifier);
				}
			if (Certificate != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("cert", 1);
					Certificate.Serialize (_writer, false);
				}
			if (Path != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("path", 1);
					Path.Serialize (_writer, false);
				}
			if (Manifest != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Manifest", 1);
					_writer.WriteBinary (Manifest);
				}
			if (SignatureValue != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("signature", 1);
					_writer.WriteBinary (SignatureValue);
				}
			if (WitnessValue != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("witness", 1);
					_writer.WriteBinary (WitnessValue);
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
        public static new DareSignature FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DareSignature;
				}
		    var Result = new DareSignature ();
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
				case "dig" : {
					Dig = jsonReader.ReadString ();
					break;
					}
				case "alg" : {
					Alg = jsonReader.ReadString ();
					break;
					}
				case "kid" : {
					KeyIdentifier = jsonReader.ReadString ();
					break;
					}
				case "cert" : {
					// An untagged structure
					Certificate = new X509Certificate ();
					Certificate.Deserialize (jsonReader);
 
					break;
					}
				case "path" : {
					// An untagged structure
					Path = new X509Certificate ();
					Path.Deserialize (jsonReader);
 
					break;
					}
				case "Manifest" : {
					Manifest = jsonReader.ReadBinary ();
					break;
					}
				case "signature" : {
					SignatureValue = jsonReader.ReadBinary ();
					break;
					}
				case "witness" : {
					WitnessValue = jsonReader.ReadBinary ();
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
	public partial class X509Certificate : Dare {
        /// <summary>
        ///URL identifying an X.509 public key certificate
        /// </summary>

		public virtual string						X5u  {get; set;}
        /// <summary>
        ///An X.509 public key certificate
        /// </summary>

		public virtual byte[]						X5  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "X509Certificate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new X509Certificate();


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
			if (X5u != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("x5u", 1);
					_writer.WriteString (X5u);
				}
			if (X5 != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("x5c", 1);
					_writer.WriteBinary (X5);
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
        public static new X509Certificate FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as X509Certificate;
				}
		    var Result = new X509Certificate ();
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
				case "x5u" : {
					X5u = jsonReader.ReadString ();
					break;
					}
				case "x5c" : {
					X5 = jsonReader.ReadBinary ();
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
	/// Recipient information
	/// </summary>
	public partial class DareRecipient : Dare {
        /// <summary>
        ///Key identifier for the encryption key.
        ///The Key identifier MUST be either a UDF fingerprint of a key or a Group Key Identifier
        /// </summary>

		public virtual string						KeyIdentifier  {get; set;}
        /// <summary>
        ///The key wrapping and derivation algorithms.
        /// </summary>

		public virtual string						KeyWrapDerivation  {get; set;}
        /// <summary>
        ///The key parameters of the ephemeral key as specified in JWE
        /// </summary>

		public virtual Key						Epk  {get; set;}
        /// <summary>
        ///The wrapped base seed. The base seed is encrypted under the result of the key exchange.
        /// </summary>

		public virtual byte[]						WrappedBaseSeed  {get; set;}
        /// <summary>
        ///The per-recipient key exchange data.
        /// </summary>

		public virtual string						RecipientKeyData  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareRecipient";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DareRecipient();


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
			if (KeyIdentifier != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("kid", 1);
					_writer.WriteString (KeyIdentifier);
				}
			if (KeyWrapDerivation != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("kwd", 1);
					_writer.WriteString (KeyWrapDerivation);
				}
			if (Epk != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("epk", 1);
					// expand this to a tagged structure
					//Epk.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(Epk._Tag, 1);
						bool firstinner = true;
						Epk.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (WrappedBaseSeed != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("wmk", 1);
					_writer.WriteBinary (WrappedBaseSeed);
				}
			if (RecipientKeyData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("rkd", 1);
					_writer.WriteString (RecipientKeyData);
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
        public static new DareRecipient FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DareRecipient;
				}
		    var Result = new DareRecipient ();
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
				case "kid" : {
					KeyIdentifier = jsonReader.ReadString ();
					break;
					}
				case "kwd" : {
					KeyWrapDerivation = jsonReader.ReadString ();
					break;
					}
				case "epk" : {
					Epk = Key.FromJson (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "wmk" : {
					WrappedBaseSeed = jsonReader.ReadBinary ();
					break;
					}
				case "rkd" : {
					RecipientKeyData = jsonReader.ReadString ();
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
	public partial class DarePolicy : Dare {
        /// <summary>
        ///The encryption algorithm to be used to compute the payload.
        /// </summary>

		public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///The digest algorithm to be used to compute the payload digest.
        /// </summary>

		public virtual string						DigestAlgorithm  {get; set;}
        /// <summary>
        ///The encryption policy specifier, determines how often a key exchange is required.
        ///'Single': All entries are encrypted under the key exchange specified in the 
        ///entry specifying this policy.
        ///'Isolated': All entries are encrypted under a separate key exchange.
        ///'All': All entries are encrypted.
        ///'None': No entries are encrypted.
        ///Default value is 'None' if EncryptKeys is null, and 'All' otherwise.
        /// </summary>

		public virtual string						Encryption  {get; set;}
        /// <summary>
        ///The signature policy
        ///'None': No entries are signed.
        ///'Final': The final entry is signed.
        ///'Isolated': All entries are independently signed.
        ///'Any': Entries may be signed.
        ///Default value is 'None' if SignKeys is null, and 'Any' otherwise.
        /// </summary>

		public virtual string						Signature  {get; set;}
        /// <summary>
        ///The public parameters of keys used for encryption
        /// </summary>

		public virtual List<Key>				EncryptKeys  {get; set;}
        /// <summary>
        ///The public parameters of keys to which entries MUST be encrypted.
        /// </summary>

		public virtual List<Key>				SignKeys  {get; set;}
		bool								__Sealed = false;
		private bool						_Sealed;
        /// <summary>
        ///If true the policy is immutable and cannot be changed by a subsequent policy override.
        /// </summary>

		public virtual bool						Sealed {
			get => _Sealed;
			set {_Sealed = value; __Sealed = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DarePolicy";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new DarePolicy();


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
			if (EncryptionAlgorithm != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("enc", 1);
					_writer.WriteString (EncryptionAlgorithm);
				}
			if (DigestAlgorithm != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("dig", 1);
					_writer.WriteString (DigestAlgorithm);
				}
			if (Encryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Encryption", 1);
					_writer.WriteString (Encryption);
				}
			if (Signature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Signature", 1);
					_writer.WriteString (Signature);
				}
			if (EncryptKeys != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EncryptKeys", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EncryptKeys) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (SignKeys != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SignKeys", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in SignKeys) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (__Sealed){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Sealed", 1);
					_writer.WriteBoolean (Sealed);
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
        public static new DarePolicy FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DarePolicy;
				}
		    var Result = new DarePolicy ();
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
				case "enc" : {
					EncryptionAlgorithm = jsonReader.ReadString ();
					break;
					}
				case "dig" : {
					DigestAlgorithm = jsonReader.ReadString ();
					break;
					}
				case "Encryption" : {
					Encryption = jsonReader.ReadString ();
					break;
					}
				case "Signature" : {
					Signature = jsonReader.ReadString ();
					break;
					}
				case "EncryptKeys" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					EncryptKeys = new List <Key> ();
					while (_Going) {
						var _Item = Key.FromJson (jsonReader, true); // a tagged structure
						EncryptKeys.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "SignKeys" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					SignKeys = new List <Key> ();
					while (_Going) {
						var _Item = Key.FromJson (jsonReader, true); // a tagged structure
						SignKeys.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Sealed" : {
					Sealed = jsonReader.ReadBoolean ();
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

