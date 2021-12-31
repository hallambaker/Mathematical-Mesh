
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
//  This file was automatically generated at 31-Dec-21 1:24:23 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.774
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Cryptography.Jose;


	/// <summary>
	///
	/// Support classes for JSON Object Signing and Encryption
	/// </summary>
public abstract partial class Jose : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Jose";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"JoseWebSignature", JoseWebSignature._Factory},
	    {"JoseWebEncryption", JoseWebEncryption._Factory},
	    {"Signed", Signed._Factory},
	    {"Encrypted", Encrypted._Factory},
	    {"KeyCore", KeyCore._Factory},
	    {"Header", Header._Factory},
	    {"Signature", Signature._Factory},
	    {"KeyContainer", KeyContainer._Factory},
	    {"Key", Key._Factory},
	    {"Recipient", Recipient._Factory},
	    {"PublicKeyRSA", PublicKeyRSA._Factory},
	    {"PrivateKeyRSA", PrivateKeyRSA._Factory},
	    {"PublicKeyDH", PublicKeyDH._Factory},
	    {"PrivateKeyDH", PrivateKeyDH._Factory},
	    {"PublicKeyECDH", PublicKeyECDH._Factory},
	    {"PrivateKeyECDH", PrivateKeyECDH._Factory},
	    {"PrivateKeyUDF", PrivateKeyUDF._Factory},
	    {"KeyAgreement", KeyAgreement._Factory},
	    {"KeyAgreementDH", KeyAgreementDH._Factory},
	    {"KeyAgreementECDH", KeyAgreementECDH._Factory}
		};

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
	/// A signed JOSE data object. The data contents are all binary encoded to 
	/// enable direct authentication of the contents.
	/// </summary>
public partial class JoseWebSignature : Jose {
        /// <summary>
        ///Data not protected by the signature
        /// </summary>

	public virtual Header						Unprotected  {get; set;}
        /// <summary>
        ///The signed data
        /// </summary>

	public virtual byte[]						Payload  {get; set;}
        /// <summary>
        ///The signature value
        /// </summary>

	public virtual List<Signature>				Signatures  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JoseWebSignature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JoseWebSignature();


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
		if (Unprotected != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("unprotected", 1);
				Unprotected.Serialize (_writer, false);
			}
		if (Payload != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("payload", 1);
				_writer.WriteBinary (Payload);
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
    public static new JoseWebSignature FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JoseWebSignature;
			}
		var Result = new JoseWebSignature ();
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
			case "unprotected" : {
				// An untagged structure
				Unprotected = new Header ();
				Unprotected.Deserialize (jsonReader);
 
				break;
				}
			case "payload" : {
				Payload = jsonReader.ReadBinary ();
				break;
				}
			case "signatures" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Signatures = new List <Signature> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Signature ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Signature (jsonReader);
					Signatures.Add (_Item);
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
	/// A signed JOSE data object. The encrypted data contents are all binary encoded.
	/// </summary>
public partial class JoseWebEncryption : JoseWebSignature {
        /// <summary>
        ///Data protected by the signature
        /// </summary>

	public virtual byte[]						Protected  {get; set;}
        /// <summary>
        ///The initialization vector for the bulk cipher.
        /// </summary>

	public virtual byte[]						IV  {get; set;}
        /// <summary>
        ///Per recipient decryption data.
        /// </summary>

	public virtual List<Recipient>				Recipients  {get; set;}
        /// <summary>
        ///The decryption data for use by this recipient.
        /// </summary>

	public virtual byte[]						EncryptedKey  {get; set;}
        /// <summary>
        ///Additional data that is included in the authentication scope but not the encryption
        /// </summary>

	public virtual byte[]						AdditionalAuthenticatedData  {get; set;}
        /// <summary>
        ///The encrypted data
        /// </summary>

	public virtual byte[]						CipherText  {get; set;}
        /// <summary>
        ///Authentication tag
        /// </summary>

	public virtual byte[]						JTag  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JoseWebEncryption";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JoseWebEncryption();


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
		((JoseWebSignature)this).SerializeX(_writer, false, ref _first);
		if (Protected != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("protected", 1);
				_writer.WriteBinary (Protected);
			}
		if (IV != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("iv", 1);
				_writer.WriteBinary (IV);
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

		if (EncryptedKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("encrypted_key", 1);
				_writer.WriteBinary (EncryptedKey);
			}
		if (AdditionalAuthenticatedData != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("aad", 1);
				_writer.WriteBinary (AdditionalAuthenticatedData);
			}
		if (CipherText != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ciphertext", 1);
				_writer.WriteBinary (CipherText);
			}
		if (JTag != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("tag", 1);
				_writer.WriteBinary (JTag);
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
    public static new JoseWebEncryption FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JoseWebEncryption;
			}
		var Result = new JoseWebEncryption ();
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
			case "protected" : {
				Protected = jsonReader.ReadBinary ();
				break;
				}
			case "iv" : {
				IV = jsonReader.ReadBinary ();
				break;
				}
			case "recipients" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Recipients = new List <Recipient> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Recipient ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Recipient (jsonReader);
					Recipients.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "encrypted_key" : {
				EncryptedKey = jsonReader.ReadBinary ();
				break;
				}
			case "aad" : {
				AdditionalAuthenticatedData = jsonReader.ReadBinary ();
				break;
				}
			case "ciphertext" : {
				CipherText = jsonReader.ReadBinary ();
				break;
				}
			case "tag" : {
				JTag = jsonReader.ReadBinary ();
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
	/// Compact representation for signed data
	/// </summary>
public partial class Signed : Jose {
        /// <summary>
        ///Data protected by the signature
        /// </summary>

	public virtual byte[]						Protected  {get; set;}
        /// <summary>
        ///The authenticated data
        /// </summary>

	public virtual byte[]						Payload  {get; set;}
        /// <summary>
        ///The signature data
        /// </summary>

	public virtual byte[]						Signature  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Signed";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Signed();


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
		if (Protected != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("protected", 1);
				_writer.WriteBinary (Protected);
			}
		if (Payload != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("payload", 1);
				_writer.WriteBinary (Payload);
			}
		if (Signature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("signature", 1);
				_writer.WriteBinary (Signature);
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
    public static new Signed FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Signed;
			}
		var Result = new Signed ();
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
			case "protected" : {
				Protected = jsonReader.ReadBinary ();
				break;
				}
			case "payload" : {
				Payload = jsonReader.ReadBinary ();
				break;
				}
			case "signature" : {
				Signature = jsonReader.ReadBinary ();
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
	/// Compact representation for encrypted data
	/// </summary>
public partial class Encrypted : Jose {
        /// <summary>
        ///Header
        /// </summary>

	public virtual Header						Header  {get; set;}
        /// <summary>
        ///The initialization vector for the cipher
        /// </summary>

	public virtual byte[]						IV  {get; set;}
        /// <summary>
        ///The encrypted data 
        /// </summary>

	public virtual byte[]						CipherText  {get; set;}
        /// <summary>
        ///The signature data
        /// </summary>

	public virtual byte[]						Signature  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Encrypted";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Encrypted();


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
			_writer.WriteToken ("header", 1);
				Header.Serialize (_writer, false);
			}
		if (IV != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("iv", 1);
				_writer.WriteBinary (IV);
			}
		if (CipherText != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ciphertext", 1);
				_writer.WriteBinary (CipherText);
			}
		if (Signature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("signature", 1);
				_writer.WriteBinary (Signature);
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
    public static new Encrypted FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Encrypted;
			}
		var Result = new Encrypted ();
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
			case "header" : {
				// An untagged structure
				Header = new Header ();
				Header.Deserialize (jsonReader);
 
				break;
				}
			case "iv" : {
				IV = jsonReader.ReadBinary ();
				break;
				}
			case "ciphertext" : {
				CipherText = jsonReader.ReadBinary ();
				break;
				}
			case "signature" : {
				Signature = jsonReader.ReadBinary ();
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
	/// Describe a cryptographic key
	/// </summary>
public partial class KeyCore : Jose {
        /// <summary>
        ///Bulk encryption algorithm for content
        /// </summary>

	public virtual string						Enc  {get; set;}
        /// <summary>
        ///Digest algorithm hint
        /// </summary>

	public virtual string						Dig  {get; set;}
        /// <summary>
        ///Key exchange algorithm
        /// </summary>

	public virtual string						Alg  {get; set;}
        /// <summary>
        ///Key identifier. If a UDF fingerprint is used to identify the 
        ///key it is placed in this field.
        /// </summary>

	public virtual string						Kid  {get; set;}
        /// <summary>
        ///URL identifying an X.509 public key certificate
        /// </summary>

	public virtual string						X5u  {get; set;}
        /// <summary>
        ///An X.509 public key certificate
        /// </summary>

	public virtual byte[]						X5c  {get; set;}
        /// <summary>
        ///SHA-1 fingerprint of X.509 certificate
        /// </summary>

	public virtual byte[]						X5t  {get; set;}
        /// <summary>
        ///SHA-2-256 fingerprint of X.509 certificate
        /// </summary>

	public virtual byte[]						X5tS256  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyCore";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyCore();


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
		if (Enc != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("enc", 1);
				_writer.WriteString (Enc);
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
		if (Kid != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("kid", 1);
				_writer.WriteString (Kid);
			}
		if (X5u != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("x5u", 1);
				_writer.WriteString (X5u);
			}
		if (X5c != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("x5c", 1);
				_writer.WriteBinary (X5c);
			}
		if (X5t != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("x5t", 1);
				_writer.WriteBinary (X5t);
			}
		if (X5tS256 != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("x5t#S256", 1);
				_writer.WriteBinary (X5tS256);
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
    public static new KeyCore FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyCore;
			}
		var Result = new KeyCore ();
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
				Enc = jsonReader.ReadString ();
				break;
				}
			case "dig" : {
				Dig = jsonReader.ReadString ();
				break;
				}
			case "alg" : {
				Alg = jsonReader.ReadString ();
				break;
				}
			case "kid" : {
				Kid = jsonReader.ReadString ();
				break;
				}
			case "x5u" : {
				X5u = jsonReader.ReadString ();
				break;
				}
			case "x5c" : {
				X5c = jsonReader.ReadBinary ();
				break;
				}
			case "x5t" : {
				X5t = jsonReader.ReadBinary ();
				break;
				}
			case "x5t#S256" : {
				X5tS256 = jsonReader.ReadBinary ();
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
	/// A JOSE Header.
	/// </summary>
public partial class Header : KeyCore {
        /// <summary>
        ///JWK Set URL
        /// </summary>

	public virtual string						Jku  {get; set;}
        /// <summary>
        ///The key parameters
        /// </summary>

	public virtual Key						Jwk  {get; set;}
        /// <summary>
        ///The key parameters of the ephemeral key
        /// </summary>

	public virtual Key						Epk  {get; set;}
        /// <summary>
        ///Another IANA content type parameter
        /// </summary>

	public virtual string						Typ  {get; set;}
        /// <summary>
        ///Content type parameter
        /// </summary>

	public virtual string						Cty  {get; set;}
        /// <summary>
        ///List of header parameters that a recipient MUST understand to interpret
        ///the authentication portion of the JOSE object.
        /// </summary>

	public virtual List<string>				Crit  {get; set;}
        /// <summary>
        ///The digest value
        /// </summary>

	public virtual byte[]						Val  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Header";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Header();


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
		((KeyCore)this).SerializeX(_writer, false, ref _first);
		if (Jku != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("jku", 1);
				_writer.WriteString (Jku);
			}
		if (Jwk != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("jwk", 1);
				// expand this to a tagged structure
				//Jwk.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Jwk._Tag, 1);
					bool firstinner = true;
					Jwk.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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
		if (Typ != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("typ", 1);
				_writer.WriteString (Typ);
			}
		if (Cty != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("cty", 1);
				_writer.WriteString (Cty);
			}
		if (Crit != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("crit", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Crit) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Val != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("val", 1);
				_writer.WriteBinary (Val);
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
    public static new Header FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Header;
			}
		var Result = new Header ();
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
			case "jku" : {
				Jku = jsonReader.ReadString ();
				break;
				}
			case "jwk" : {
				Jwk = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "epk" : {
				Epk = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "typ" : {
				Typ = jsonReader.ReadString ();
				break;
				}
			case "cty" : {
				Cty = jsonReader.ReadString ();
				break;
				}
			case "crit" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Crit = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Crit.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "val" : {
				Val = jsonReader.ReadBinary ();
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
	/// The signature value
	/// </summary>
public partial class Signature : Jose {
        /// <summary>
        ///The signature header
        /// </summary>

	public virtual Header						Header  {get; set;}
        /// <summary>
        ///Data protected by the signature
        /// </summary>

	public virtual byte[]						Protected  {get; set;}
        /// <summary>
        ///The signature value
        /// </summary>

	public virtual byte[]						SignatureValue  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Signature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Signature();


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
			_writer.WriteToken ("header", 1);
				Header.Serialize (_writer, false);
			}
		if (Protected != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("protected", 1);
				_writer.WriteBinary (Protected);
			}
		if (SignatureValue != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("signature", 1);
				_writer.WriteBinary (SignatureValue);
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
    public static new Signature FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Signature;
			}
		var Result = new Signature ();
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
			case "header" : {
				// An untagged structure
				Header = new Header ();
				Header.Deserialize (jsonReader);
 
				break;
				}
			case "protected" : {
				Protected = jsonReader.ReadBinary ();
				break;
				}
			case "signature" : {
				SignatureValue = jsonReader.ReadBinary ();
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
	/// A wrapper object for storing key data.
	/// </summary>
public partial class KeyContainer : Jose {
	bool								__Exportable = false;
	private bool						_Exportable;
        /// <summary>
        ///If false a handler library MUST NOT permit the private key to be exported.
        /// </summary>

	public virtual bool						Exportable {
		get => _Exportable;
		set {_Exportable = value; __Exportable = true; }
		}
        /// <summary>
        ///The key data.
        /// </summary>

	public virtual byte[]						KeyCore  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyContainer";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyContainer();


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
		if (__Exportable){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Exportable", 1);
				_writer.WriteBoolean (Exportable);
			}
		if (KeyCore != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("KeyCore", 1);
				_writer.WriteBinary (KeyCore);
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
    public static new KeyContainer FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyContainer;
			}
		var Result = new KeyContainer ();
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
			case "Exportable" : {
				Exportable = jsonReader.ReadBoolean ();
				break;
				}
			case "KeyCore" : {
				KeyCore = jsonReader.ReadBinary ();
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
	/// A JOSE key. All fields map onto the equivalent fields defined in
	/// RFC 7517
	/// </summary>
public partial class Key : KeyCore {
	bool								__Exportable = false;
	private bool						_Exportable;
        /// <summary>
        ///If true, a stored key may be exported from the machine on 
        ///which it is stored.
        /// </summary>

	public virtual bool						Exportable {
		get => _Exportable;
		set {_Exportable = value; __Exportable = true; }
		}
        /// <summary>
        ///Key type
        /// </summary>

	public virtual string						Kty  {get; set;}
        /// <summary>
        ///Public Key use
        /// </summary>

	public virtual string						Use  {get; set;}
        /// <summary>
        ///Key operations
        /// </summary>

	public virtual string						Key_ops  {get; set;}
        /// <summary>
        ///Symmetric key value.
        /// </summary>

	public virtual byte[]						K  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Key";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Key();


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
		((KeyCore)this).SerializeX(_writer, false, ref _first);
		if (__Exportable){
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Exportable", 1);
				_writer.WriteBoolean (Exportable);
			}
		if (Kty != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("kty", 1);
				_writer.WriteString (Kty);
			}
		if (Use != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("use", 1);
				_writer.WriteString (Use);
			}
		if (Key_ops != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("key_ops", 1);
				_writer.WriteString (Key_ops);
			}
		if (K != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("k", 1);
				_writer.WriteBinary (K);
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
    public static new Key FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Key;
			}
		var Result = new Key ();
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
			case "Exportable" : {
				Exportable = jsonReader.ReadBoolean ();
				break;
				}
			case "kty" : {
				Kty = jsonReader.ReadString ();
				break;
				}
			case "use" : {
				Use = jsonReader.ReadString ();
				break;
				}
			case "key_ops" : {
				Key_ops = jsonReader.ReadString ();
				break;
				}
			case "k" : {
				K = jsonReader.ReadBinary ();
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
	/// Recipient information
	/// </summary>
public partial class Recipient : Jose {
        /// <summary>
        ///Specify the recipient and per recipient data
        /// </summary>

	public virtual Header						Header  {get; set;}
        /// <summary>
        ///The decryption data for use by this recipient.
        /// </summary>

	public virtual byte[]						EncryptedKey  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Recipient";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Recipient();


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
		if (EncryptedKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("encrypted_key", 1);
				_writer.WriteBinary (EncryptedKey);
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
    public static new Recipient FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Recipient;
			}
		var Result = new Recipient ();
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
				Header = new Header ();
				Header.Deserialize (jsonReader);
 
				break;
				}
			case "encrypted_key" : {
				EncryptedKey = jsonReader.ReadBinary ();
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
	/// An RSA Public key
	/// </summary>
public partial class PublicKeyRSA : Key {
        /// <summary>
        ///The public modulus
        /// </summary>

	public virtual byte[]						N  {get; set;}
        /// <summary>
        ///The public exponent
        /// </summary>

	public virtual byte[]						E  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublicKeyRSA";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicKeyRSA();


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
		((Key)this).SerializeX(_writer, false, ref _first);
		if (N != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("n", 1);
				_writer.WriteBinary (N);
			}
		if (E != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("e", 1);
				_writer.WriteBinary (E);
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
    public static new PublicKeyRSA FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PublicKeyRSA;
			}
		var Result = new PublicKeyRSA ();
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
			case "n" : {
				N = jsonReader.ReadBinary ();
				break;
				}
			case "e" : {
				E = jsonReader.ReadBinary ();
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
	/// RSA private key parameters
	/// </summary>
public partial class PrivateKeyRSA : PublicKeyRSA {
        /// <summary>
        ///The parameter d
        /// </summary>

	public virtual byte[]						D  {get; set;}
        /// <summary>
        ///The parameter p
        /// </summary>

	public virtual byte[]						P  {get; set;}
        /// <summary>
        ///The parameter q
        /// </summary>

	public virtual byte[]						Q  {get; set;}
        /// <summary>
        ///The parameter dp
        /// </summary>

	public virtual byte[]						DP  {get; set;}
        /// <summary>
        ///The parameter dq
        /// </summary>

	public virtual byte[]						DQ  {get; set;}
        /// <summary>
        ///The parameter QInverse
        /// </summary>

	public virtual byte[]						QI  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PrivateKeyRSA";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PrivateKeyRSA();


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
		((PublicKeyRSA)this).SerializeX(_writer, false, ref _first);
		if (D != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("d", 1);
				_writer.WriteBinary (D);
			}
		if (P != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("p", 1);
				_writer.WriteBinary (P);
			}
		if (Q != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("q", 1);
				_writer.WriteBinary (Q);
			}
		if (DP != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("dp", 1);
				_writer.WriteBinary (DP);
			}
		if (DQ != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("dq", 1);
				_writer.WriteBinary (DQ);
			}
		if (QI != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("qi", 1);
				_writer.WriteBinary (QI);
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
    public static new PrivateKeyRSA FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PrivateKeyRSA;
			}
		var Result = new PrivateKeyRSA ();
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
			case "d" : {
				D = jsonReader.ReadBinary ();
				break;
				}
			case "p" : {
				P = jsonReader.ReadBinary ();
				break;
				}
			case "q" : {
				Q = jsonReader.ReadBinary ();
				break;
				}
			case "dp" : {
				DP = jsonReader.ReadBinary ();
				break;
				}
			case "dq" : {
				DQ = jsonReader.ReadBinary ();
				break;
				}
			case "qi" : {
				QI = jsonReader.ReadBinary ();
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
	/// A Diffie Helllman Public key
	/// </summary>
public partial class PublicKeyDH : Key {
        /// <summary>
        ///The fingerprint of the domain
        /// </summary>

	public virtual byte[]						Domain  {get; set;}
        /// <summary>
        ///The public key
        /// </summary>

	public virtual byte[]						Public  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublicKeyDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicKeyDH();


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
		((Key)this).SerializeX(_writer, false, ref _first);
		if (Domain != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Domain", 1);
				_writer.WriteBinary (Domain);
			}
		if (Public != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Public", 1);
				_writer.WriteBinary (Public);
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
    public static new PublicKeyDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PublicKeyDH;
			}
		var Result = new PublicKeyDH ();
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
			case "Domain" : {
				Domain = jsonReader.ReadBinary ();
				break;
				}
			case "Public" : {
				Public = jsonReader.ReadBinary ();
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
	/// Diffie Helllman private key parameters
	/// </summary>
public partial class PrivateKeyDH : PublicKeyDH {
        /// <summary>
        ///The private key.
        /// </summary>

	public virtual byte[]						Private  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PrivateKeyDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PrivateKeyDH();


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
		((PublicKeyDH)this).SerializeX(_writer, false, ref _first);
		if (Private != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Private", 1);
				_writer.WriteBinary (Private);
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
    public static new PrivateKeyDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PrivateKeyDH;
			}
		var Result = new PrivateKeyDH ();
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
			case "Private" : {
				Private = jsonReader.ReadBinary ();
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
	/// An Elliptic Curve Diffie Hellman public key
	/// </summary>
public partial class PublicKeyECDH : Key {
        /// <summary>
        ///The curve specifier (X25519, Ed25519, X448, Ed448), etc.
        /// </summary>

	public virtual string						Curve  {get; set;}
        /// <summary>
        ///The public key
        /// </summary>

	public virtual byte[]						Public  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublicKeyECDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicKeyECDH();


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
		((Key)this).SerializeX(_writer, false, ref _first);
		if (Curve != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("crv", 1);
				_writer.WriteString (Curve);
			}
		if (Public != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Public", 1);
				_writer.WriteBinary (Public);
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
    public static new PublicKeyECDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PublicKeyECDH;
			}
		var Result = new PublicKeyECDH ();
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
			case "crv" : {
				Curve = jsonReader.ReadString ();
				break;
				}
			case "Public" : {
				Public = jsonReader.ReadBinary ();
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
	/// Diffie Helllman private key parameters
	/// </summary>
public partial class PrivateKeyECDH : PublicKeyECDH {
        /// <summary>
        ///The private key
        /// </summary>

	public virtual byte[]						Private  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PrivateKeyECDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PrivateKeyECDH();


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
		((PublicKeyECDH)this).SerializeX(_writer, false, ref _first);
		if (Private != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Private", 1);
				_writer.WriteBinary (Private);
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
    public static new PrivateKeyECDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PrivateKeyECDH;
			}
		var Result = new PrivateKeyECDH ();
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
			case "Private" : {
				Private = jsonReader.ReadBinary ();
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
	/// A UDF Key
	/// </summary>
public partial class PrivateKeyUDF : Key {
        /// <summary>
        ///The private value
        /// </summary>

	public virtual string						PrivateValue  {get; set;}
        /// <summary>
        ///The UDF key identifier
        /// </summary>

	public virtual string						KeyType  {get; set;}
        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string						AlgorithmEncrypt  {get; set;}
        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string						AlgorithmSign  {get; set;}
        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string						AlgorithmAuthenticate  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PrivateKeyUDF";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PrivateKeyUDF();


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
		((Key)this).SerializeX(_writer, false, ref _first);
		if (PrivateValue != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PrivateValue", 1);
				_writer.WriteString (PrivateValue);
			}
		if (KeyType != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("KeyType", 1);
				_writer.WriteString (KeyType);
			}
		if (AlgorithmEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AlgorithmEncrypt", 1);
				_writer.WriteString (AlgorithmEncrypt);
			}
		if (AlgorithmSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AlgorithmSign", 1);
				_writer.WriteString (AlgorithmSign);
			}
		if (AlgorithmAuthenticate != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AlgorithmAuthenticate", 1);
				_writer.WriteString (AlgorithmAuthenticate);
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
    public static new PrivateKeyUDF FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PrivateKeyUDF;
			}
		var Result = new PrivateKeyUDF ();
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
			case "PrivateValue" : {
				PrivateValue = jsonReader.ReadString ();
				break;
				}
			case "KeyType" : {
				KeyType = jsonReader.ReadString ();
				break;
				}
			case "AlgorithmEncrypt" : {
				AlgorithmEncrypt = jsonReader.ReadString ();
				break;
				}
			case "AlgorithmSign" : {
				AlgorithmSign = jsonReader.ReadString ();
				break;
				}
			case "AlgorithmAuthenticate" : {
				AlgorithmAuthenticate = jsonReader.ReadString ();
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
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreement : Jose {
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyAgreement";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyAgreement();


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
    public static new KeyAgreement FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyAgreement;
			}
		var Result = new KeyAgreement ();
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
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	///
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreementDH : KeyAgreement {
        /// <summary>
        ///The result
        /// </summary>

	public virtual byte[]						Result  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyAgreementDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyAgreementDH();


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
		((KeyAgreement)this).SerializeX(_writer, false, ref _first);
		if (Result != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Result", 1);
				_writer.WriteBinary (Result);
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
    public static new KeyAgreementDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyAgreementDH;
			}
		var Result = new KeyAgreementDH ();
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
				Result = jsonReader.ReadBinary ();
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
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreementECDH : KeyAgreement {
        /// <summary>
        ///The curve name
        /// </summary>

	public virtual string						Curve  {get; set;}
        /// <summary>
        ///The result
        /// </summary>

	public virtual byte[]						Result  {get; set;}
		
	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "KeyAgreementECDH";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyAgreementECDH();


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
		((KeyAgreement)this).SerializeX(_writer, false, ref _first);
		if (Curve != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Curve", 1);
				_writer.WriteString (Curve);
			}
		if (Result != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Result", 1);
				_writer.WriteBinary (Result);
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
    public static new KeyAgreementECDH FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyAgreementECDH;
			}
		var Result = new KeyAgreementECDH ();
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
			case "Curve" : {
				Curve = jsonReader.ReadString ();
				break;
				}
			case "Result" : {
				Result = jsonReader.ReadBinary ();
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



