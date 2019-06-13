
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



using Goedel.Cryptography.Jose;


namespace Goedel.Cryptography.Dare {


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
	public abstract partial class Dare : global::Goedel.Protocol.JSONObject {

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
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"DareEnvelopeSequence", DareEnvelopeSequence._Factory},
			{"DareTrailer", DareTrailer._Factory},
			{"DareHeader", DareHeader._Factory},
			{"DareSigner", DareSigner._Factory},
			{"X509Certificate", X509Certificate._Factory},
			{"DareSignature", DareSignature._Factory},
			{"DareRecipient", DareRecipient._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) => 
			Out = JSONReader.ReadTaggedObject(_TagDictionary);

		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// A DARE Message containing Header, EDS and Trailer in JSON object encoding.
	/// Since a DAREMessage is almost invariably presented in JSON sequence or
	/// compact encoding, use of the DAREMessage subclass is preferred.
	/// Although a DARE Message is functionally an object, it is serialized as 
	/// an ordered sequence. This ensures that the message header field will always
	/// precede the body in a serialization, this allowing processing of the header
	/// information to be performed before the entire body has been received.
	/// </summary>
	public partial class DareEnvelopeSequence : Dare {
        /// <summary>
        ///The message header. May specify the key exchange data, pre-signature 
        ///or signature data, cloaked headers and/or encrypted data sequences.
        /// </summary>

		public virtual DareHeader						Header  {get; set;}
        /// <summary>
        ///The message body
        /// </summary>

		public virtual byte[]						Body  {get; set;}
        /// <summary>
        ///The message trailer. If present, this contains the signature.
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
		public static new JSONObject _Factory () => new DareEnvelopeSequence();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			if (Body != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Body", 1);
					_Writer.WriteBinary (Body);
				}
			if (Trailer != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Trailer", 1);
					Trailer.Serialize (_Writer, false);
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
        public static new DareEnvelopeSequence FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareEnvelopeSequence;
				}
		    var Result = new DareEnvelopeSequence ();
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
					Header = new DareHeader ();
					Header.Deserialize (JSONReader);
 
					break;
					}
				case "Body" : {
					Body = JSONReader.ReadBinary ();
					break;
					}
				case "Trailer" : {
					// An untagged structure
					Trailer = new DareTrailer ();
					Trailer.Deserialize (JSONReader);
 
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
	/// A DARE Message Trailer
	/// </summary>
	public partial class DareTrailer : Dare {
        /// <summary>
        ///A list of signatures.
        ///A message trailer MUST NOT contain a signatures field if the header contains 
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
		public static new JSONObject _Factory () => new DareTrailer();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			if (Signatures != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signatures", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signatures) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (SignedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedData", 1);
					_Writer.WriteBinary (SignedData);
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
        public static new DareTrailer FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareTrailer;
				}
		    var Result = new DareTrailer ();
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
				case "signatures" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Signatures = new List <DareSignature> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareSignature ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DareSignature (JSONReader);
						Signatures.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "SignedData" : {
					SignedData = JSONReader.ReadBinary ();
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
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// A DARE Message Header. Since any field that is present in a trailer MAY be 
	/// placed in a header instead, the message header inherits from the trailer.
	/// </summary>
	public partial class DareHeader : DareTrailer {
        /// <summary>
        ///The encryption algorithm as specified in JWE
        /// </summary>

		public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///Digest Algorithm. If specified, tells decoder that the digest algorithm is used to
        ///construct a signature over the message payload.
        /// </summary>

		public virtual string						DigestAlgorithm  {get; set;}
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
        ///Contains signed headers.
        /// </summary>

		public virtual byte[]						Signed  {get; set;}
        /// <summary>
        ///If present in a header or trailer, specifies an encrypted data block 
        ///containing additional header fields whose values override those specified 
        ///in the message and context headers.
        ///When specified in a header, a cloaked field MAY be used to conceal metadata 
        ///(content type, compression) and/or to specify an additional layer of key exchange. 
        ///That applies to both the Message body and to headers specified within the cloaked 
        ///header.
        ///Processing of cloaked data is described in…
        /// </summary>

		public virtual byte[]						Cloaked  {get; set;}
        /// <summary>
        ///The content type field as specified in JWE
        /// </summary>

		public virtual string						ContentType  {get; set;}
        /// <summary>
        ///If present, the Annotations field contains a sequence of Encrypted Data 
        ///Segments encrypted under the message Master Key. The interpretation of these fields 
        ///is application specific.
        /// </summary>

		public virtual List<byte[]>				EDSS  {get; set;}
        /// <summary>
        ///A list of 'presignature'
        /// </summary>

		public virtual List<DareSigner>				Signers  {get; set;}
        /// <summary>
        ///A list of recipient key exchange information blocks.
        /// </summary>

		public virtual List<DareRecipient>				Recipients  {get; set;}
        /// <summary>
        ///Unique object identifier
        /// </summary>

		public virtual string						UniqueID  {get; set;}
        /// <summary>
        ///The original filename under which the data was stored.
        /// </summary>

		public virtual string						Filename  {get; set;}
        /// <summary>
        ///Operation on the header
        /// </summary>

		public virtual string						Event  {get; set;}
        /// <summary>
        ///List of labels that are applied to the payload of the frame.
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
        /// <summary>
        ///List of key/value pairs describing the payload of the frame.
        /// </summary>

		public virtual List<KeyValue>				KeyValues  {get; set;}
		
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
		public static new JSONObject _Factory () => new DareHeader();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			((DareTrailer)this).SerializeX(_Writer, false, ref _first);
			if (EncryptionAlgorithm != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("enc", 1);
					_Writer.WriteString (EncryptionAlgorithm);
				}
			if (DigestAlgorithm != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("dig", 1);
					_Writer.WriteString (DigestAlgorithm);
				}
			if (Salt != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Salt", 1);
					_Writer.WriteBinary (Salt);
				}
			if (Malt != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Malt", 1);
					_Writer.WriteBinary (Malt);
				}
			if (Signed != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Signed", 1);
					_Writer.WriteBinary (Signed);
				}
			if (Cloaked != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("cloaked", 1);
					_Writer.WriteBinary (Cloaked);
				}
			if (ContentType != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("cty", 1);
					_Writer.WriteString (ContentType);
				}
			if (EDSS != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Annotations", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EDSS) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteBinary (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Signers != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signatures", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Signers) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Recipients != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("recipients", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Recipients) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (UniqueID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UniqueID", 1);
					_Writer.WriteString (UniqueID);
				}
			if (Filename != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Filename", 1);
					_Writer.WriteString (Filename);
				}
			if (Event != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Event", 1);
					_Writer.WriteString (Event);
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
                    //_Writer.WriteToken(_index._Tag, 1);
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
        public static new DareHeader FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareHeader;
				}
		    var Result = new DareHeader ();
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
				case "enc" : {
					EncryptionAlgorithm = JSONReader.ReadString ();
					break;
					}
				case "dig" : {
					DigestAlgorithm = JSONReader.ReadString ();
					break;
					}
				case "Salt" : {
					Salt = JSONReader.ReadBinary ();
					break;
					}
				case "Malt" : {
					Malt = JSONReader.ReadBinary ();
					break;
					}
				case "Signed" : {
					Signed = JSONReader.ReadBinary ();
					break;
					}
				case "cloaked" : {
					Cloaked = JSONReader.ReadBinary ();
					break;
					}
				case "cty" : {
					ContentType = JSONReader.ReadString ();
					break;
					}
				case "Annotations" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					EDSS = new List <byte[]> ();
					while (_Going) {
						byte[] _Item = JSONReader.ReadBinary ();
						EDSS.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "signatures" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Signers = new List <DareSigner> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareSigner ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DareSigner (JSONReader);
						Signers.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "recipients" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Recipients = new List <DareRecipient> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DareRecipient ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DareRecipient (JSONReader);
						Recipients.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "UniqueID" : {
					UniqueID = JSONReader.ReadString ();
					break;
					}
				case "Filename" : {
					Filename = JSONReader.ReadString ();
					break;
					}
				case "Event" : {
					Event = JSONReader.ReadString ();
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
	/// The signature value
	/// </summary>
	public partial class DareSigner : Dare {
        /// <summary>
        ///Digest algorithm hint. Specifying the digest algorithm to be applied
        ///to the message body allows the body to be processed in streaming mode.
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
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DareSigner";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new DareSigner();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			if (Dig != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("dig", 1);
					_Writer.WriteString (Dig);
				}
			if (Alg != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("alg", 1);
					_Writer.WriteString (Alg);
				}
			if (KeyIdentifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("kid", 1);
					_Writer.WriteString (KeyIdentifier);
				}
			if (Certificate != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("cert", 1);
					Certificate.Serialize (_Writer, false);
				}
			if (Path != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("path", 1);
					Path.Serialize (_Writer, false);
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
        public static new DareSigner FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareSigner;
				}
		    var Result = new DareSigner ();
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
				case "dig" : {
					Dig = JSONReader.ReadString ();
					break;
					}
				case "alg" : {
					Alg = JSONReader.ReadString ();
					break;
					}
				case "kid" : {
					KeyIdentifier = JSONReader.ReadString ();
					break;
					}
				case "cert" : {
					// An untagged structure
					Certificate = new X509Certificate ();
					Certificate.Deserialize (JSONReader);
 
					break;
					}
				case "path" : {
					// An untagged structure
					Path = new X509Certificate ();
					Path.Deserialize (JSONReader);
 
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
		public static new JSONObject _Factory () => new X509Certificate();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			if (X5u != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5u", 1);
					_Writer.WriteString (X5u);
				}
			if (X5 != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("x5c", 1);
					_Writer.WriteBinary (X5);
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
        public static new X509Certificate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as X509Certificate;
				}
		    var Result = new X509Certificate ();
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
				case "x5u" : {
					X5u = JSONReader.ReadString ();
					break;
					}
				case "x5c" : {
					X5 = JSONReader.ReadBinary ();
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
	public partial class DareSignature : DareSigner {
        /// <summary>
        ///The data description that was signed.
        /// </summary>

		public virtual byte[]						Manifest  {get; set;}
        /// <summary>
        ///The signature value as an Enhanced Data Sequence under the message Master Key.
        /// </summary>

		public virtual byte[]						SignatureValue  {get; set;}
        /// <summary>
        ///The signature witness value used on an encrypted message to demonstrate that 
        ///the signature was authorized by a party with actual knowledge of the encryption 
        ///key used to encrypt the message.
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
		public static new JSONObject _Factory () => new DareSignature();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			((DareSigner)this).SerializeX(_Writer, false, ref _first);
			if (Manifest != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Manifest", 1);
					_Writer.WriteBinary (Manifest);
				}
			if (SignatureValue != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signature", 1);
					_Writer.WriteBinary (SignatureValue);
				}
			if (WitnessValue != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("witness", 1);
					_Writer.WriteBinary (WitnessValue);
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
        public static new DareSignature FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareSignature;
				}
		    var Result = new DareSignature ();
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
				case "Manifest" : {
					Manifest = JSONReader.ReadBinary ();
					break;
					}
				case "signature" : {
					SignatureValue = JSONReader.ReadBinary ();
					break;
					}
				case "witness" : {
					WitnessValue = JSONReader.ReadBinary ();
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
        ///The wrapped master key. The master key is encrypted under the result of the key exchange.
        /// </summary>

		public virtual byte[]						WrappedMasterKey  {get; set;}
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
		public static new JSONObject _Factory () => new DareRecipient();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


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
			if (KeyIdentifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("kid", 1);
					_Writer.WriteString (KeyIdentifier);
				}
			if (KeyWrapDerivation != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("kwd", 1);
					_Writer.WriteString (KeyWrapDerivation);
				}
			if (Epk != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("epk", 1);
					// expand this to a tagged structure
					//Epk.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Epk._Tag, 1);
						bool firstinner = true;
						Epk.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (WrappedMasterKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("wmk", 1);
					_Writer.WriteBinary (WrappedMasterKey);
				}
			if (RecipientKeyData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("rkd", 1);
					_Writer.WriteString (RecipientKeyData);
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
        public static new DareRecipient FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DareRecipient;
				}
		    var Result = new DareRecipient ();
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
				case "kid" : {
					KeyIdentifier = JSONReader.ReadString ();
					break;
					}
				case "kwd" : {
					KeyWrapDerivation = JSONReader.ReadString ();
					break;
					}
				case "epk" : {
					Epk = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "wmk" : {
					WrappedMasterKey = JSONReader.ReadBinary ();
					break;
					}
				case "rkd" : {
					RecipientKeyData = JSONReader.ReadString ();
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

