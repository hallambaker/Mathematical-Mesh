
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


namespace Goedel.Cryptography.Dare {


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
	public abstract partial class Dare : global::Goedel.Protocol.JSONObject {

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
		public override string _Tag { get; } = "Dare";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"DARETrailer", DARETrailer._Factory},
			{"DAREHeader", DAREHeader._Factory},
			{"DARESigner", DARESigner._Factory},
			{"X509Certificate", X509Certificate._Factory},
			{"DARESignature", DARESignature._Factory},
			{"DARERecipient", DARERecipient._Factory}			};

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
	/// A DARE Message Trailer
	/// </summary>
	public partial class DARETrailer : Dare {
        /// <summary>
        ///A list of signatures.
        ///A message trailer MUST NOT contain a signatures field if the header contains 
        ///a signatures field.
        /// </summary>

		public virtual List<DARESignature>				Signatures  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DARETrailer";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DARETrailer();
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
			if (Signatures != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signatures", 1);
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
        public static new DARETrailer FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DARETrailer;
				}
		    var Result = new DARETrailer ();
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
					Signatures = new List <DARESignature> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DARESignature ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DARESignature (JSONReader);
						Signatures.Add (_Item);
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
	/// A DARE Message Header. Since any field that is present in a trailer MAY be 
	/// placed in a header instead, the message header inherits from the trailer.
	/// </summary>
	public partial class DAREHeader : DARETrailer {
        /// <summary>
        ///The encryption algorithm as specified in JWE
        /// </summary>

		public virtual string						EncryptionAlgorithm  {get; set;}
        /// <summary>
        ///Message Authentication Code algorithm
        /// </summary>

		public virtual string						AuthenticationAlgorithm  {get; set;}
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
        ///If present, the Encrypted Data Segments field contains a sequence of Encrypted Data 
        ///Segments encrypted under the message Master Key. The interpretation of these fields 
        ///is application specific.
        /// </summary>

		public virtual List<byte[]>				EDSS  {get; set;}
        /// <summary>
        ///A list of 'presignature'
        /// </summary>

		public virtual List<DARESigner>				Signers  {get; set;}
        /// <summary>
        ///A list of recipient key exchange information blocks.
        /// </summary>

		public virtual List<DARERecipient>				Recipients  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DAREHeader";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DAREHeader();
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
			((DARETrailer)this).SerializeX(_Writer, false, ref _first);
			if (EncryptionAlgorithm != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("enc", 1);
					_Writer.WriteString (EncryptionAlgorithm);
				}
			if (AuthenticationAlgorithm != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("mac", 1);
					_Writer.WriteString (AuthenticationAlgorithm);
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
				_Writer.WriteToken ("edss", 1);
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
                    //_Writer.WriteToken(_index.Tag(), 1);
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
        public static new DAREHeader FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DAREHeader;
				}
		    var Result = new DAREHeader ();
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
				case "mac" : {
					AuthenticationAlgorithm = JSONReader.ReadString ();
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
				case "edss" : {
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
					Signers = new List <DARESigner> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DARESigner ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DARESigner (JSONReader);
						Signers.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "recipients" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Recipients = new List <DARERecipient> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  DARERecipient ();
						_Item.Deserialize (JSONReader);
						// var _Item = new DARERecipient (JSONReader);
						Recipients.Add (_Item);
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
	public partial class DARESigner : Dare {
        /// <summary>
        ///Digest algorithm hint
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
		public override string _Tag { get; } = "DARESigner";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DARESigner();
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
        public static new DARESigner FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DARESigner;
				}
		    var Result = new DARESigner ();
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
		public override string _Tag { get; } = "X509Certificate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new X509Certificate();
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
	public partial class DARESignature : DARESigner {
        /// <summary>
        ///The signature value as an Enhanced Data Sequence under the message Master Key.
        /// </summary>

		public virtual byte[]						SignatureValue  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DARESignature";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DARESignature();
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
			((DARESigner)this).SerializeX(_Writer, false, ref _first);
			if (SignatureValue != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("signature", 1);
					_Writer.WriteBinary (SignatureValue);
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
        public static new DARESignature FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DARESignature;
				}
		    var Result = new DARESignature ();
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
				case "signature" : {
					SignatureValue = JSONReader.ReadBinary ();
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
	public partial class DARERecipient : Dare {
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

		public virtual string						WrappedMasterKey  {get; set;}
        /// <summary>
        ///The per-recipient key exchange data.
        /// </summary>

		public virtual string						RecipientKeyData  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DARERecipient";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DARERecipient();
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
						_Writer.WriteToken(Epk.Tag(), 1);
						bool firstinner = true;
						Epk.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (WrappedMasterKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("wmk", 1);
					_Writer.WriteString (WrappedMasterKey);
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
        public static new DARERecipient FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DARERecipient;
				}
		    var Result = new DARERecipient ();
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
					WrappedMasterKey = JSONReader.ReadString ();
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

