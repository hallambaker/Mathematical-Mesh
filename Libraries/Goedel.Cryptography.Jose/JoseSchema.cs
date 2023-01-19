
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
//  This file was automatically generated at 18-Jan-23 1:56:08 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1015
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
using Goedel.Utilities;

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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "unprotected" : {
				if (value is TokenValueStructObject vvalue) {
					Unprotected = vvalue.Value as Header;
					}
				break;
				}
			case "payload" : {
				if (value is TokenValueBinary vvalue) {
					Payload = vvalue.Value;
					}
				break;
				}
			case "signatures" : {
				if (value is TokenValueListStructObject vvalue) {
					Signatures = vvalue.Value as List<Signature>;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "unprotected" : {
				return new TokenValueStruct<Header> (Unprotected);
				}
			case "payload" : {
				return new TokenValueBinary (Payload);
				}
			case "signatures" : {
				return new TokenValueListStruct<Signature> (Signatures);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "unprotected", new Property ( typeof(TokenValueStruct), false,
					()=>new Header(), ()=>new Header(), false)} ,
			{ "payload", new Property (typeof(TokenValueBinary), false)} ,
			{ "signatures", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Signature>(), ()=>new Signature(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "protected" : {
				if (value is TokenValueBinary vvalue) {
					Protected = vvalue.Value;
					}
				break;
				}
			case "iv" : {
				if (value is TokenValueBinary vvalue) {
					IV = vvalue.Value;
					}
				break;
				}
			case "recipients" : {
				if (value is TokenValueListStructObject vvalue) {
					Recipients = vvalue.Value as List<Recipient>;
					}
				break;
				}
			case "encrypted_key" : {
				if (value is TokenValueBinary vvalue) {
					EncryptedKey = vvalue.Value;
					}
				break;
				}
			case "aad" : {
				if (value is TokenValueBinary vvalue) {
					AdditionalAuthenticatedData = vvalue.Value;
					}
				break;
				}
			case "ciphertext" : {
				if (value is TokenValueBinary vvalue) {
					CipherText = vvalue.Value;
					}
				break;
				}
			case "tag" : {
				if (value is TokenValueBinary vvalue) {
					JTag = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "protected" : {
				return new TokenValueBinary (Protected);
				}
			case "iv" : {
				return new TokenValueBinary (IV);
				}
			case "recipients" : {
				return new TokenValueListStruct<Recipient> (Recipients);
				}
			case "encrypted_key" : {
				return new TokenValueBinary (EncryptedKey);
				}
			case "aad" : {
				return new TokenValueBinary (AdditionalAuthenticatedData);
				}
			case "ciphertext" : {
				return new TokenValueBinary (CipherText);
				}
			case "tag" : {
				return new TokenValueBinary (JTag);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "protected", new Property (typeof(TokenValueBinary), false)} ,
			{ "iv", new Property (typeof(TokenValueBinary), false)} ,
			{ "recipients", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Recipient>(), ()=>new Recipient(), false)} ,
			{ "encrypted_key", new Property (typeof(TokenValueBinary), false)} ,
			{ "aad", new Property (typeof(TokenValueBinary), false)} ,
			{ "ciphertext", new Property (typeof(TokenValueBinary), false)} ,
			{ "tag", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, JoseWebSignature._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "protected" : {
				if (value is TokenValueBinary vvalue) {
					Protected = vvalue.Value;
					}
				break;
				}
			case "payload" : {
				if (value is TokenValueBinary vvalue) {
					Payload = vvalue.Value;
					}
				break;
				}
			case "signature" : {
				if (value is TokenValueBinary vvalue) {
					Signature = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "protected" : {
				return new TokenValueBinary (Protected);
				}
			case "payload" : {
				return new TokenValueBinary (Payload);
				}
			case "signature" : {
				return new TokenValueBinary (Signature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "protected", new Property (typeof(TokenValueBinary), false)} ,
			{ "payload", new Property (typeof(TokenValueBinary), false)} ,
			{ "signature", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "header" : {
				if (value is TokenValueStructObject vvalue) {
					Header = vvalue.Value as Header;
					}
				break;
				}
			case "iv" : {
				if (value is TokenValueBinary vvalue) {
					IV = vvalue.Value;
					}
				break;
				}
			case "ciphertext" : {
				if (value is TokenValueBinary vvalue) {
					CipherText = vvalue.Value;
					}
				break;
				}
			case "signature" : {
				if (value is TokenValueBinary vvalue) {
					Signature = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "header" : {
				return new TokenValueStruct<Header> (Header);
				}
			case "iv" : {
				return new TokenValueBinary (IV);
				}
			case "ciphertext" : {
				return new TokenValueBinary (CipherText);
				}
			case "signature" : {
				return new TokenValueBinary (Signature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "header", new Property ( typeof(TokenValueStruct), false,
					()=>new Header(), ()=>new Header(), false)} ,
			{ "iv", new Property (typeof(TokenValueBinary), false)} ,
			{ "ciphertext", new Property (typeof(TokenValueBinary), false)} ,
			{ "signature", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "enc" : {
				if (value is TokenValueString vvalue) {
					Enc = vvalue.Value;
					}
				break;
				}
			case "dig" : {
				if (value is TokenValueString vvalue) {
					Dig = vvalue.Value;
					}
				break;
				}
			case "alg" : {
				if (value is TokenValueString vvalue) {
					Alg = vvalue.Value;
					}
				break;
				}
			case "kid" : {
				if (value is TokenValueString vvalue) {
					Kid = vvalue.Value;
					}
				break;
				}
			case "x5u" : {
				if (value is TokenValueString vvalue) {
					X5u = vvalue.Value;
					}
				break;
				}
			case "x5c" : {
				if (value is TokenValueBinary vvalue) {
					X5c = vvalue.Value;
					}
				break;
				}
			case "x5t" : {
				if (value is TokenValueBinary vvalue) {
					X5t = vvalue.Value;
					}
				break;
				}
			case "x5t#S256" : {
				if (value is TokenValueBinary vvalue) {
					X5tS256 = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "enc" : {
				return new TokenValueString (Enc);
				}
			case "dig" : {
				return new TokenValueString (Dig);
				}
			case "alg" : {
				return new TokenValueString (Alg);
				}
			case "kid" : {
				return new TokenValueString (Kid);
				}
			case "x5u" : {
				return new TokenValueString (X5u);
				}
			case "x5c" : {
				return new TokenValueBinary (X5c);
				}
			case "x5t" : {
				return new TokenValueBinary (X5t);
				}
			case "x5t#S256" : {
				return new TokenValueBinary (X5tS256);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "enc", new Property (typeof(TokenValueString), false)} ,
			{ "dig", new Property (typeof(TokenValueString), false)} ,
			{ "alg", new Property (typeof(TokenValueString), false)} ,
			{ "kid", new Property (typeof(TokenValueString), false)} ,
			{ "x5u", new Property (typeof(TokenValueString), false)} ,
			{ "x5c", new Property (typeof(TokenValueBinary), false)} ,
			{ "x5t", new Property (typeof(TokenValueBinary), false)} ,
			{ "x5t#S256", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "jku" : {
				if (value is TokenValueString vvalue) {
					Jku = vvalue.Value;
					}
				break;
				}
			case "jwk" : {
				if (value is TokenValueStructObject vvalue) {
					Jwk = vvalue.Value as Key;
					}
				break;
				}
			case "epk" : {
				if (value is TokenValueStructObject vvalue) {
					Epk = vvalue.Value as Key;
					}
				break;
				}
			case "typ" : {
				if (value is TokenValueString vvalue) {
					Typ = vvalue.Value;
					}
				break;
				}
			case "cty" : {
				if (value is TokenValueString vvalue) {
					Cty = vvalue.Value;
					}
				break;
				}
			case "crit" : {
				if (value is TokenValueListString vvalue) {
					Crit = vvalue.Value;
					}
				break;
				}
			case "val" : {
				if (value is TokenValueBinary vvalue) {
					Val = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "jku" : {
				return new TokenValueString (Jku);
				}
			case "jwk" : {
				return new TokenValueStruct<Key> (Jwk);
				}
			case "epk" : {
				return new TokenValueStruct<Key> (Epk);
				}
			case "typ" : {
				return new TokenValueString (Typ);
				}
			case "cty" : {
				return new TokenValueString (Cty);
				}
			case "crit" : {
				return new TokenValueListString (Crit);
				}
			case "val" : {
				return new TokenValueBinary (Val);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "jku", new Property (typeof(TokenValueString), false)} ,
			{ "jwk", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "epk", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "typ", new Property (typeof(TokenValueString), false)} ,
			{ "cty", new Property (typeof(TokenValueString), false)} ,
			{ "crit", new Property (typeof(TokenValueListString), true)} ,
			{ "val", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, KeyCore._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "header" : {
				if (value is TokenValueStructObject vvalue) {
					Header = vvalue.Value as Header;
					}
				break;
				}
			case "protected" : {
				if (value is TokenValueBinary vvalue) {
					Protected = vvalue.Value;
					}
				break;
				}
			case "signature" : {
				if (value is TokenValueBinary vvalue) {
					SignatureValue = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "header" : {
				return new TokenValueStruct<Header> (Header);
				}
			case "protected" : {
				return new TokenValueBinary (Protected);
				}
			case "signature" : {
				return new TokenValueBinary (SignatureValue);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "header", new Property ( typeof(TokenValueStruct), false,
					()=>new Header(), ()=>new Header(), false)} ,
			{ "protected", new Property (typeof(TokenValueBinary), false)} ,
			{ "signature", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	///
	/// A wrapper object for storing key data.
	/// </summary>
public partial class KeyContainer : Jose {
        /// <summary>
        ///If false a handler library MUST NOT permit the private key to be exported.
        /// </summary>

	public virtual bool?						Exportable  {get; set;}
        /// <summary>
        ///The key data.
        /// </summary>

	public virtual byte[]						KeyCore  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Exportable" : {
				if (value is TokenValueBoolean vvalue) {
					Exportable = vvalue.Value;
					}
				break;
				}
			case "KeyCore" : {
				if (value is TokenValueBinary vvalue) {
					KeyCore = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Exportable" : {
				return new TokenValueBoolean (Exportable);
				}
			case "KeyCore" : {
				return new TokenValueBinary (KeyCore);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Exportable", new Property (typeof(TokenValueBoolean), false)} ,
			{ "KeyCore", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	///
	/// A JOSE key. All fields map onto the equivalent fields defined in
	/// RFC 7517
	/// </summary>
public partial class Key : KeyCore {
        /// <summary>
        ///If true, a stored key may be exported from the machine on 
        ///which it is stored.
        /// </summary>

	public virtual bool?						Exportable  {get; set;}
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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Exportable" : {
				if (value is TokenValueBoolean vvalue) {
					Exportable = vvalue.Value;
					}
				break;
				}
			case "kty" : {
				if (value is TokenValueString vvalue) {
					Kty = vvalue.Value;
					}
				break;
				}
			case "use" : {
				if (value is TokenValueString vvalue) {
					Use = vvalue.Value;
					}
				break;
				}
			case "key_ops" : {
				if (value is TokenValueString vvalue) {
					Key_ops = vvalue.Value;
					}
				break;
				}
			case "k" : {
				if (value is TokenValueBinary vvalue) {
					K = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Exportable" : {
				return new TokenValueBoolean (Exportable);
				}
			case "kty" : {
				return new TokenValueString (Kty);
				}
			case "use" : {
				return new TokenValueString (Use);
				}
			case "key_ops" : {
				return new TokenValueString (Key_ops);
				}
			case "k" : {
				return new TokenValueBinary (K);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Exportable", new Property (typeof(TokenValueBoolean), false)} ,
			{ "kty", new Property (typeof(TokenValueString), false)} ,
			{ "use", new Property (typeof(TokenValueString), false)} ,
			{ "key_ops", new Property (typeof(TokenValueString), false)} ,
			{ "k", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, KeyCore._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Header" : {
				if (value is TokenValueStructObject vvalue) {
					Header = vvalue.Value as Header;
					}
				break;
				}
			case "encrypted_key" : {
				if (value is TokenValueBinary vvalue) {
					EncryptedKey = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Header" : {
				return new TokenValueStruct<Header> (Header);
				}
			case "encrypted_key" : {
				return new TokenValueBinary (EncryptedKey);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Header", new Property ( typeof(TokenValueStruct), false,
					()=>new Header(), ()=>new Header(), false)} ,
			{ "encrypted_key", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "n" : {
				if (value is TokenValueBinary vvalue) {
					N = vvalue.Value;
					}
				break;
				}
			case "e" : {
				if (value is TokenValueBinary vvalue) {
					E = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "n" : {
				return new TokenValueBinary (N);
				}
			case "e" : {
				return new TokenValueBinary (E);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "n", new Property (typeof(TokenValueBinary), false)} ,
			{ "e", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Key._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "d" : {
				if (value is TokenValueBinary vvalue) {
					D = vvalue.Value;
					}
				break;
				}
			case "p" : {
				if (value is TokenValueBinary vvalue) {
					P = vvalue.Value;
					}
				break;
				}
			case "q" : {
				if (value is TokenValueBinary vvalue) {
					Q = vvalue.Value;
					}
				break;
				}
			case "dp" : {
				if (value is TokenValueBinary vvalue) {
					DP = vvalue.Value;
					}
				break;
				}
			case "dq" : {
				if (value is TokenValueBinary vvalue) {
					DQ = vvalue.Value;
					}
				break;
				}
			case "qi" : {
				if (value is TokenValueBinary vvalue) {
					QI = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "d" : {
				return new TokenValueBinary (D);
				}
			case "p" : {
				return new TokenValueBinary (P);
				}
			case "q" : {
				return new TokenValueBinary (Q);
				}
			case "dp" : {
				return new TokenValueBinary (DP);
				}
			case "dq" : {
				return new TokenValueBinary (DQ);
				}
			case "qi" : {
				return new TokenValueBinary (QI);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "d", new Property (typeof(TokenValueBinary), false)} ,
			{ "p", new Property (typeof(TokenValueBinary), false)} ,
			{ "q", new Property (typeof(TokenValueBinary), false)} ,
			{ "dp", new Property (typeof(TokenValueBinary), false)} ,
			{ "dq", new Property (typeof(TokenValueBinary), false)} ,
			{ "qi", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PublicKeyRSA._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Domain" : {
				if (value is TokenValueBinary vvalue) {
					Domain = vvalue.Value;
					}
				break;
				}
			case "Public" : {
				if (value is TokenValueBinary vvalue) {
					Public = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Domain" : {
				return new TokenValueBinary (Domain);
				}
			case "Public" : {
				return new TokenValueBinary (Public);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Domain", new Property (typeof(TokenValueBinary), false)} ,
			{ "Public", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Key._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Private" : {
				if (value is TokenValueBinary vvalue) {
					Private = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Private" : {
				return new TokenValueBinary (Private);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Private", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PublicKeyDH._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "crv" : {
				if (value is TokenValueString vvalue) {
					Curve = vvalue.Value;
					}
				break;
				}
			case "Public" : {
				if (value is TokenValueBinary vvalue) {
					Public = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "crv" : {
				return new TokenValueString (Curve);
				}
			case "Public" : {
				return new TokenValueBinary (Public);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "crv", new Property (typeof(TokenValueString), false)} ,
			{ "Public", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Key._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Private" : {
				if (value is TokenValueBinary vvalue) {
					Private = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Private" : {
				return new TokenValueBinary (Private);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Private", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PublicKeyECDH._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PrivateValue" : {
				if (value is TokenValueString vvalue) {
					PrivateValue = vvalue.Value;
					}
				break;
				}
			case "KeyType" : {
				if (value is TokenValueString vvalue) {
					KeyType = vvalue.Value;
					}
				break;
				}
			case "AlgorithmEncrypt" : {
				if (value is TokenValueString vvalue) {
					AlgorithmEncrypt = vvalue.Value;
					}
				break;
				}
			case "AlgorithmSign" : {
				if (value is TokenValueString vvalue) {
					AlgorithmSign = vvalue.Value;
					}
				break;
				}
			case "AlgorithmAuthenticate" : {
				if (value is TokenValueString vvalue) {
					AlgorithmAuthenticate = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "PrivateValue" : {
				return new TokenValueString (PrivateValue);
				}
			case "KeyType" : {
				return new TokenValueString (KeyType);
				}
			case "AlgorithmEncrypt" : {
				return new TokenValueString (AlgorithmEncrypt);
				}
			case "AlgorithmSign" : {
				return new TokenValueString (AlgorithmSign);
				}
			case "AlgorithmAuthenticate" : {
				return new TokenValueString (AlgorithmAuthenticate);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PrivateValue", new Property (typeof(TokenValueString), false)} ,
			{ "KeyType", new Property (typeof(TokenValueString), false)} ,
			{ "AlgorithmEncrypt", new Property (typeof(TokenValueString), false)} ,
			{ "AlgorithmSign", new Property (typeof(TokenValueString), false)} ,
			{ "AlgorithmAuthenticate", new Property (typeof(TokenValueString), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Key._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}

	/// <summary>
	///
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreement : Jose {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Result" : {
				if (value is TokenValueBinary vvalue) {
					Result = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Result" : {
				return new TokenValueBinary (Result);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, KeyAgreement._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Curve" : {
				if (value is TokenValueString vvalue) {
					Curve = vvalue.Value;
					}
				break;
				}
			case "Result" : {
				if (value is TokenValueBinary vvalue) {
					Result = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Curve" : {
				return new TokenValueString (Curve);
				}
			case "Result" : {
				return new TokenValueBinary (Result);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Curve", new Property (typeof(TokenValueString), false)} ,
			{ "Result", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, KeyAgreement._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



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


	}



