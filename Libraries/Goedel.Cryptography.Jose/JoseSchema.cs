
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
//  This file was automatically generated at 10/25/2023 6:25:50 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22621.0
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

	public virtual Header?						Unprotected  {get; set;}

        /// <summary>
        ///The signed data
        /// </summary>

	public virtual byte[]?						Payload  {get; set;}

        /// <summary>
        ///The signature value
        /// </summary>

	public virtual List<Signature>?					Signatures  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new JoseWebSignature(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "unprotected", new PropertyStruct ("unprotected", 
					(IBinding data, object? value) => {(data as JoseWebSignature).Unprotected = value as Header;}, (IBinding data) => (data as JoseWebSignature).Unprotected,
					false, ()=>new  Header(), ()=>new Header())} ,
			{ "payload", new PropertyBinary ("payload", 
					(IBinding data, byte[]? value) => {(data as JoseWebSignature).Payload = value;}, (IBinding data) => (data as JoseWebSignature).Payload )},
			{ "signatures", new PropertyListStruct ("signatures", 
					(IBinding data, object? value) => {(data as JoseWebSignature).Signatures = value as List<Signature>;}, (IBinding data) => (data as JoseWebSignature).Signatures,
					false, ()=>new  List<Signature>(), ()=>new Signature())} 
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

	public virtual byte[]?						Protected  {get; set;}

        /// <summary>
        ///The initialization vector for the bulk cipher.
        /// </summary>

	public virtual byte[]?						IV  {get; set;}

        /// <summary>
        ///Per recipient decryption data.
        /// </summary>

	public virtual List<Recipient>?					Recipients  {get; set;}
        /// <summary>
        ///The decryption data for use by this recipient.
        /// </summary>

	public virtual byte[]?						EncryptedKey  {get; set;}

        /// <summary>
        ///Additional data that is included in the authentication scope but not the encryption
        /// </summary>

	public virtual byte[]?						AdditionalAuthenticatedData  {get; set;}

        /// <summary>
        ///The encrypted data
        /// </summary>

	public virtual byte[]?						CipherText  {get; set;}

        /// <summary>
        ///Authentication tag
        /// </summary>

	public virtual byte[]?						JTag  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new JoseWebEncryption(), JoseWebSignature._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "protected", new PropertyBinary ("protected", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).Protected = value;}, (IBinding data) => (data as JoseWebEncryption).Protected )},
			{ "iv", new PropertyBinary ("iv", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).IV = value;}, (IBinding data) => (data as JoseWebEncryption).IV )},
			{ "recipients", new PropertyListStruct ("recipients", 
					(IBinding data, object? value) => {(data as JoseWebEncryption).Recipients = value as List<Recipient>;}, (IBinding data) => (data as JoseWebEncryption).Recipients,
					false, ()=>new  List<Recipient>(), ()=>new Recipient())} ,
			{ "encrypted_key", new PropertyBinary ("encrypted_key", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).EncryptedKey = value;}, (IBinding data) => (data as JoseWebEncryption).EncryptedKey )},
			{ "aad", new PropertyBinary ("aad", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).AdditionalAuthenticatedData = value;}, (IBinding data) => (data as JoseWebEncryption).AdditionalAuthenticatedData )},
			{ "ciphertext", new PropertyBinary ("ciphertext", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).CipherText = value;}, (IBinding data) => (data as JoseWebEncryption).CipherText )},
			{ "tag", new PropertyBinary ("tag", 
					(IBinding data, byte[]? value) => {(data as JoseWebEncryption).JTag = value;}, (IBinding data) => (data as JoseWebEncryption).JTag )}
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

	public virtual byte[]?						Protected  {get; set;}

        /// <summary>
        ///The authenticated data
        /// </summary>

	public virtual byte[]?						Payload  {get; set;}

        /// <summary>
        ///The signature data
        /// </summary>

	public virtual byte[]?						Signature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Signed(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "protected", new PropertyBinary ("protected", 
					(IBinding data, byte[]? value) => {(data as Signed).Protected = value;}, (IBinding data) => (data as Signed).Protected )},
			{ "payload", new PropertyBinary ("payload", 
					(IBinding data, byte[]? value) => {(data as Signed).Payload = value;}, (IBinding data) => (data as Signed).Payload )},
			{ "signature", new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as Signed).Signature = value;}, (IBinding data) => (data as Signed).Signature )}
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

	public virtual Header?						Header  {get; set;}

        /// <summary>
        ///The initialization vector for the cipher
        /// </summary>

	public virtual byte[]?						IV  {get; set;}

        /// <summary>
        ///The encrypted data 
        /// </summary>

	public virtual byte[]?						CipherText  {get; set;}

        /// <summary>
        ///The signature data
        /// </summary>

	public virtual byte[]?						Signature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Encrypted(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "header", new PropertyStruct ("header", 
					(IBinding data, object? value) => {(data as Encrypted).Header = value as Header;}, (IBinding data) => (data as Encrypted).Header,
					false, ()=>new  Header(), ()=>new Header())} ,
			{ "iv", new PropertyBinary ("iv", 
					(IBinding data, byte[]? value) => {(data as Encrypted).IV = value;}, (IBinding data) => (data as Encrypted).IV )},
			{ "ciphertext", new PropertyBinary ("ciphertext", 
					(IBinding data, byte[]? value) => {(data as Encrypted).CipherText = value;}, (IBinding data) => (data as Encrypted).CipherText )},
			{ "signature", new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as Encrypted).Signature = value;}, (IBinding data) => (data as Encrypted).Signature )}
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

	public virtual string?						Enc  {get; set;}

        /// <summary>
        ///Digest algorithm hint
        /// </summary>

	public virtual string?						Dig  {get; set;}

        /// <summary>
        ///Key exchange algorithm
        /// </summary>

	public virtual string?						Alg  {get; set;}

        /// <summary>
        ///Key identifier. If a UDF fingerprint is used to identify the 
        ///key it is placed in this field.
        /// </summary>

	public virtual string?						Kid  {get; set;}

        /// <summary>
        ///URL identifying an X.509 public key certificate
        /// </summary>

	public virtual string?						X5u  {get; set;}

        /// <summary>
        ///An X.509 public key certificate
        /// </summary>

	public virtual byte[]?						X5c  {get; set;}

        /// <summary>
        ///SHA-1 fingerprint of X.509 certificate
        /// </summary>

	public virtual byte[]?						X5t  {get; set;}

        /// <summary>
        ///SHA-2-256 fingerprint of X.509 certificate
        /// </summary>

	public virtual byte[]?						X5tS256  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyCore(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "enc", new PropertyString ("enc", 
					(IBinding data, string? value) => {(data as KeyCore).Enc = value;}, (IBinding data) => (data as KeyCore).Enc )},
			{ "dig", new PropertyString ("dig", 
					(IBinding data, string? value) => {(data as KeyCore).Dig = value;}, (IBinding data) => (data as KeyCore).Dig )},
			{ "alg", new PropertyString ("alg", 
					(IBinding data, string? value) => {(data as KeyCore).Alg = value;}, (IBinding data) => (data as KeyCore).Alg )},
			{ "kid", new PropertyString ("kid", 
					(IBinding data, string? value) => {(data as KeyCore).Kid = value;}, (IBinding data) => (data as KeyCore).Kid )},
			{ "x5u", new PropertyString ("x5u", 
					(IBinding data, string? value) => {(data as KeyCore).X5u = value;}, (IBinding data) => (data as KeyCore).X5u )},
			{ "x5c", new PropertyBinary ("x5c", 
					(IBinding data, byte[]? value) => {(data as KeyCore).X5c = value;}, (IBinding data) => (data as KeyCore).X5c )},
			{ "x5t", new PropertyBinary ("x5t", 
					(IBinding data, byte[]? value) => {(data as KeyCore).X5t = value;}, (IBinding data) => (data as KeyCore).X5t )},
			{ "x5t#S256", new PropertyBinary ("x5t#S256", 
					(IBinding data, byte[]? value) => {(data as KeyCore).X5tS256 = value;}, (IBinding data) => (data as KeyCore).X5tS256 )}
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

	public virtual string?						Jku  {get; set;}

        /// <summary>
        ///The key parameters
        /// </summary>

	public virtual Key?						Jwk  {get; set;}

        /// <summary>
        ///The key parameters of the ephemeral key
        /// </summary>

	public virtual Key?						Epk  {get; set;}

        /// <summary>
        ///Another IANA content type parameter
        /// </summary>

	public virtual string?						Typ  {get; set;}

        /// <summary>
        ///Content type parameter
        /// </summary>

	public virtual string?						Cty  {get; set;}

        /// <summary>
        ///List of header parameters that a recipient MUST understand to interpret
        ///the authentication portion of the JOSE object.
        /// </summary>

	public virtual List<string>?					Crit  {get; set;}
        /// <summary>
        ///The digest value
        /// </summary>

	public virtual byte[]?						Val  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Header(), KeyCore._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "jku", new PropertyString ("jku", 
					(IBinding data, string? value) => {(data as Header).Jku = value;}, (IBinding data) => (data as Header).Jku )},
			{ "jwk", new PropertyStruct ("jwk", 
					(IBinding data, object? value) => {(data as Header).Jwk = value as Key;}, (IBinding data) => (data as Header).Jwk,
					true)} ,
			{ "epk", new PropertyStruct ("epk", 
					(IBinding data, object? value) => {(data as Header).Epk = value as Key;}, (IBinding data) => (data as Header).Epk,
					true)} ,
			{ "typ", new PropertyString ("typ", 
					(IBinding data, string? value) => {(data as Header).Typ = value;}, (IBinding data) => (data as Header).Typ )},
			{ "cty", new PropertyString ("cty", 
					(IBinding data, string? value) => {(data as Header).Cty = value;}, (IBinding data) => (data as Header).Cty )},
			{ "crit", new PropertyListString ("crit", 
					(IBinding data, List<string>? value) => {(data as Header).Crit = value;}, (IBinding data) => (data as Header).Crit )},
			{ "val", new PropertyBinary ("val", 
					(IBinding data, byte[]? value) => {(data as Header).Val = value;}, (IBinding data) => (data as Header).Val )}
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

	public virtual Header?						Header  {get; set;}

        /// <summary>
        ///Data protected by the signature
        /// </summary>

	public virtual byte[]?						Protected  {get; set;}

        /// <summary>
        ///The signature value
        /// </summary>

	public virtual byte[]?						SignatureValue  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Signature(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "header", new PropertyStruct ("header", 
					(IBinding data, object? value) => {(data as Signature).Header = value as Header;}, (IBinding data) => (data as Signature).Header,
					false, ()=>new  Header(), ()=>new Header())} ,
			{ "protected", new PropertyBinary ("protected", 
					(IBinding data, byte[]? value) => {(data as Signature).Protected = value;}, (IBinding data) => (data as Signature).Protected )},
			{ "signature", new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as Signature).SignatureValue = value;}, (IBinding data) => (data as Signature).SignatureValue )}
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

	public virtual byte[]?						KeyCore  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyContainer(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Exportable", new PropertyBoolean ("Exportable", 
					(IBinding data, bool? value) => {(data as KeyContainer).Exportable = value;}, (IBinding data) => (data as KeyContainer).Exportable )},
			{ "KeyCore", new PropertyBinary ("KeyCore", 
					(IBinding data, byte[]? value) => {(data as KeyContainer).KeyCore = value;}, (IBinding data) => (data as KeyContainer).KeyCore )}
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

	public virtual string?						Kty  {get; set;}

        /// <summary>
        ///Public Key use
        /// </summary>

	public virtual string?						Use  {get; set;}

        /// <summary>
        ///Key operations
        /// </summary>

	public virtual string?						Key_ops  {get; set;}

        /// <summary>
        ///Symmetric key value.
        /// </summary>

	public virtual byte[]?						K  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Key(), KeyCore._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Exportable", new PropertyBoolean ("Exportable", 
					(IBinding data, bool? value) => {(data as Key).Exportable = value;}, (IBinding data) => (data as Key).Exportable )},
			{ "kty", new PropertyString ("kty", 
					(IBinding data, string? value) => {(data as Key).Kty = value;}, (IBinding data) => (data as Key).Kty )},
			{ "use", new PropertyString ("use", 
					(IBinding data, string? value) => {(data as Key).Use = value;}, (IBinding data) => (data as Key).Use )},
			{ "key_ops", new PropertyString ("key_ops", 
					(IBinding data, string? value) => {(data as Key).Key_ops = value;}, (IBinding data) => (data as Key).Key_ops )},
			{ "k", new PropertyBinary ("k", 
					(IBinding data, byte[]? value) => {(data as Key).K = value;}, (IBinding data) => (data as Key).K )}
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

	public virtual Header?						Header  {get; set;}

        /// <summary>
        ///The decryption data for use by this recipient.
        /// </summary>

	public virtual byte[]?						EncryptedKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Recipient(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Header", new PropertyStruct ("Header", 
					(IBinding data, object? value) => {(data as Recipient).Header = value as Header;}, (IBinding data) => (data as Recipient).Header,
					false, ()=>new  Header(), ()=>new Header())} ,
			{ "encrypted_key", new PropertyBinary ("encrypted_key", 
					(IBinding data, byte[]? value) => {(data as Recipient).EncryptedKey = value;}, (IBinding data) => (data as Recipient).EncryptedKey )}
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

	public virtual byte[]?						N  {get; set;}

        /// <summary>
        ///The public exponent
        /// </summary>

	public virtual byte[]?						E  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PublicKeyRSA(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "n", new PropertyBinary ("n", 
					(IBinding data, byte[]? value) => {(data as PublicKeyRSA).N = value;}, (IBinding data) => (data as PublicKeyRSA).N )},
			{ "e", new PropertyBinary ("e", 
					(IBinding data, byte[]? value) => {(data as PublicKeyRSA).E = value;}, (IBinding data) => (data as PublicKeyRSA).E )}
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

	public virtual byte[]?						D  {get; set;}

        /// <summary>
        ///The parameter p
        /// </summary>

	public virtual byte[]?						P  {get; set;}

        /// <summary>
        ///The parameter q
        /// </summary>

	public virtual byte[]?						Q  {get; set;}

        /// <summary>
        ///The parameter dp
        /// </summary>

	public virtual byte[]?						DP  {get; set;}

        /// <summary>
        ///The parameter dq
        /// </summary>

	public virtual byte[]?						DQ  {get; set;}

        /// <summary>
        ///The parameter QInverse
        /// </summary>

	public virtual byte[]?						QI  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PrivateKeyRSA(), PublicKeyRSA._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "d", new PropertyBinary ("d", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).D = value;}, (IBinding data) => (data as PrivateKeyRSA).D )},
			{ "p", new PropertyBinary ("p", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).P = value;}, (IBinding data) => (data as PrivateKeyRSA).P )},
			{ "q", new PropertyBinary ("q", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).Q = value;}, (IBinding data) => (data as PrivateKeyRSA).Q )},
			{ "dp", new PropertyBinary ("dp", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).DP = value;}, (IBinding data) => (data as PrivateKeyRSA).DP )},
			{ "dq", new PropertyBinary ("dq", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).DQ = value;}, (IBinding data) => (data as PrivateKeyRSA).DQ )},
			{ "qi", new PropertyBinary ("qi", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyRSA).QI = value;}, (IBinding data) => (data as PrivateKeyRSA).QI )}
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

	public virtual byte[]?						Domain  {get; set;}

        /// <summary>
        ///The public key
        /// </summary>

	public virtual byte[]?						Public  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PublicKeyDH(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Domain", new PropertyBinary ("Domain", 
					(IBinding data, byte[]? value) => {(data as PublicKeyDH).Domain = value;}, (IBinding data) => (data as PublicKeyDH).Domain )},
			{ "Public", new PropertyBinary ("Public", 
					(IBinding data, byte[]? value) => {(data as PublicKeyDH).Public = value;}, (IBinding data) => (data as PublicKeyDH).Public )}
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

	public virtual byte[]?						Private  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PrivateKeyDH(), PublicKeyDH._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Private", new PropertyBinary ("Private", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyDH).Private = value;}, (IBinding data) => (data as PrivateKeyDH).Private )}
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

	public virtual string?						Curve  {get; set;}

        /// <summary>
        ///The public key
        /// </summary>

	public virtual byte[]?						Public  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PublicKeyECDH(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "crv", new PropertyString ("crv", 
					(IBinding data, string? value) => {(data as PublicKeyECDH).Curve = value;}, (IBinding data) => (data as PublicKeyECDH).Curve )},
			{ "Public", new PropertyBinary ("Public", 
					(IBinding data, byte[]? value) => {(data as PublicKeyECDH).Public = value;}, (IBinding data) => (data as PublicKeyECDH).Public )}
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

	public virtual byte[]?						Private  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PrivateKeyECDH(), PublicKeyECDH._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Private", new PropertyBinary ("Private", 
					(IBinding data, byte[]? value) => {(data as PrivateKeyECDH).Private = value;}, (IBinding data) => (data as PrivateKeyECDH).Private )}
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

	public virtual string?						PrivateValue  {get; set;}

        /// <summary>
        ///The UDF key identifier
        /// </summary>

	public virtual string?						KeyType  {get; set;}

        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string?						AlgorithmEncrypt  {get; set;}

        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string?						AlgorithmSign  {get; set;}

        /// <summary>
        ///The algorithm used to derrive the encryption key
        /// </summary>

	public virtual string?						AlgorithmAuthenticate  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PrivateKeyUDF(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PrivateValue", new PropertyString ("PrivateValue", 
					(IBinding data, string? value) => {(data as PrivateKeyUDF).PrivateValue = value;}, (IBinding data) => (data as PrivateKeyUDF).PrivateValue )},
			{ "KeyType", new PropertyString ("KeyType", 
					(IBinding data, string? value) => {(data as PrivateKeyUDF).KeyType = value;}, (IBinding data) => (data as PrivateKeyUDF).KeyType )},
			{ "AlgorithmEncrypt", new PropertyString ("AlgorithmEncrypt", 
					(IBinding data, string? value) => {(data as PrivateKeyUDF).AlgorithmEncrypt = value;}, (IBinding data) => (data as PrivateKeyUDF).AlgorithmEncrypt )},
			{ "AlgorithmSign", new PropertyString ("AlgorithmSign", 
					(IBinding data, string? value) => {(data as PrivateKeyUDF).AlgorithmSign = value;}, (IBinding data) => (data as PrivateKeyUDF).AlgorithmSign )},
			{ "AlgorithmAuthenticate", new PropertyString ("AlgorithmAuthenticate", 
					(IBinding data, string? value) => {(data as PrivateKeyUDF).AlgorithmAuthenticate = value;}, (IBinding data) => (data as PrivateKeyUDF).AlgorithmAuthenticate )}
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


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyAgreement(), null);

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

	public virtual byte[]?						Result  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyAgreementDH(), KeyAgreement._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new PropertyBinary ("Result", 
					(IBinding data, byte[]? value) => {(data as KeyAgreementDH).Result = value;}, (IBinding data) => (data as KeyAgreementDH).Result )}
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

	public virtual string?						Curve  {get; set;}

        /// <summary>
        ///The result
        /// </summary>

	public virtual byte[]?						Result  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyAgreementECDH(), KeyAgreement._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Curve", new PropertyString ("Curve", 
					(IBinding data, string? value) => {(data as KeyAgreementECDH).Curve = value;}, (IBinding data) => (data as KeyAgreementECDH).Curve )},
			{ "Result", new PropertyBinary ("Result", 
					(IBinding data, byte[]? value) => {(data as KeyAgreementECDH).Result = value;}, (IBinding data) => (data as KeyAgreementECDH).Result )}
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



