
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
//  This file was automatically generated at 12/7/2025 1:05:48 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0028 // Don't warn collection initialization can be simplified.
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JoseWebSignature), JoseWebSignature._binding},
	    {typeof(JoseWebEncryption), JoseWebEncryption._binding},
	    {typeof(JWKS), JWKS._binding},
	    {typeof(JWK), JWK._binding},
	    {typeof(JwkEllipticCurve), JwkEllipticCurve._binding},
	    {typeof(JwkRsa), JwkRsa._binding},
	    {typeof(JwkRsaPrivate), JwkRsaPrivate._binding},
	    {typeof(JwkUdfSeed), JwkUdfSeed._binding},
	    {typeof(JwkOctet), JwkOctet._binding},
	    {typeof(JwkOctetKeyPairs), JwkOctetKeyPairs._binding},
	    {typeof(JwtHeader), JwtHeader._binding},
	    {typeof(Signed), Signed._binding},
	    {typeof(Encrypted), Encrypted._binding},
	    {typeof(JsonWebKeys), JsonWebKeys._binding},
	    {typeof(KeyCore), KeyCore._binding},
	    {typeof(Header), Header._binding},
	    {typeof(Signature), Signature._binding},
	    {typeof(KeyContainer), KeyContainer._binding},
	    {typeof(Key), Key._binding},
	    {typeof(Recipient), Recipient._binding},
	    {typeof(PublicKeyRSA), PublicKeyRSA._binding},
	    {typeof(PrivateKeyRSA), PrivateKeyRSA._binding},
	    {typeof(PublicKeyDH), PublicKeyDH._binding},
	    {typeof(PrivateKeyDH), PrivateKeyDH._binding},
	    {typeof(PublicKeyECDH), PublicKeyECDH._binding},
	    {typeof(PrivateKeyECDH), PrivateKeyECDH._binding},
	    {typeof(PrivateKeyUDF), PrivateKeyUDF._binding},
	    {typeof(KeyAgreement), KeyAgreement._binding},
	    {typeof(KeyAgreementDH), KeyAgreementDH._binding},
	    {typeof(KeyAgreementECDH), KeyAgreementECDH._binding},
	    {typeof(PublicKeyBinary), PublicKeyBinary._binding},
	    {typeof(PrivateKeyBinary), PrivateKeyBinary._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Jose() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

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

	[JsonPropertyName("unprotected")]
	public virtual Header?					Unprotected  {get; set;} //

    /// <summary>
    ///The signed data
    /// </summary>

	[JsonPropertyName("payload")]
	public virtual byte[]?					Payload  {get; set;} //

    /// <summary>
    ///The signature value
    /// </summary>

	[JsonPropertyName("signatures")]
	public virtual List<Signature>?					Signatures  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("unprotected", typeof (Header),
					(data, value) => {(data as JoseWebSignature).Unprotected = value as Header;}, 
					data => (data as JoseWebSignature).Unprotected,
					false, ()=>new  Header(), ()=>new Header()),
		new PropertyBinary ("payload", 
					(data, value) => {(data as JoseWebSignature).Payload = value;}, 
					data => (data as JoseWebSignature).Payload ),
		new PropertyListStruct ("signatures", typeof (Signature),
					(data, value) => {(data as JoseWebSignature).Signatures = value as List<Signature>;}, 
					data => (data as JoseWebSignature).Signatures,
					false, ()=>new  List<Signature>(), ()=>new Signature())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JoseWebSignature> _binding = new (
			new() {
			{ "unprotected", _properties [0]},
			{ "payload", _properties [1]},
			{ "signatures", _properties [2]}}, __Tag,
		() => new JoseWebSignature(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// A signed JOSE data object. The encrypted data contents are all binary encoded.
	/// </summary>
public partial class JoseWebEncryption : JoseWebSignature {
    /// <summary>
    ///Data protected by the signature
    /// </summary>

	[JsonPropertyName("protected")]
	public virtual byte[]?					Protected  {get; set;} //

    /// <summary>
    ///The initialization vector for the bulk cipher.
    /// </summary>

	[JsonPropertyName("iv")]
	public virtual byte[]?					IV  {get; set;} //

    /// <summary>
    ///Per recipient decryption data.
    /// </summary>

	[JsonPropertyName("recipients")]
	public virtual List<Recipient>?					Recipients  {get; set;}
    /// <summary>
    ///The decryption data for use by this recipient.
    /// </summary>

	[JsonPropertyName("encrypted_key")]
	public virtual byte[]?					EncryptedKey  {get; set;} //

    /// <summary>
    ///Additional data that is included in the authentication scope but not the encryption
    /// </summary>

	[JsonPropertyName("aad")]
	public virtual byte[]?					AdditionalAuthenticatedData  {get; set;} //

    /// <summary>
    ///The encrypted data
    /// </summary>

	[JsonPropertyName("ciphertext")]
	public virtual byte[]?					CipherText  {get; set;} //

    /// <summary>
    ///Authentication tag
    /// </summary>

	[JsonPropertyName("tag")]
	public virtual byte[]?					JTag  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("protected", 
					(data, value) => {(data as JoseWebEncryption).Protected = value;}, 
					data => (data as JoseWebEncryption).Protected ),
		new PropertyBinary ("iv", 
					(data, value) => {(data as JoseWebEncryption).IV = value;}, 
					data => (data as JoseWebEncryption).IV ),
		new PropertyListStruct ("recipients", typeof (Recipient),
					(data, value) => {(data as JoseWebEncryption).Recipients = value as List<Recipient>;}, 
					data => (data as JoseWebEncryption).Recipients,
					false, ()=>new  List<Recipient>(), ()=>new Recipient()),
		new PropertyBinary ("encrypted_key", 
					(data, value) => {(data as JoseWebEncryption).EncryptedKey = value;}, 
					data => (data as JoseWebEncryption).EncryptedKey ),
		new PropertyBinary ("aad", 
					(data, value) => {(data as JoseWebEncryption).AdditionalAuthenticatedData = value;}, 
					data => (data as JoseWebEncryption).AdditionalAuthenticatedData ),
		new PropertyBinary ("ciphertext", 
					(data, value) => {(data as JoseWebEncryption).CipherText = value;}, 
					data => (data as JoseWebEncryption).CipherText ),
		new PropertyBinary ("tag", 
					(data, value) => {(data as JoseWebEncryption).JTag = value;}, 
					data => (data as JoseWebEncryption).JTag )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JoseWebEncryption> _binding = new (
			new() {
			{ "protected", _properties [0]},
			{ "iv", _properties [1]},
			{ "recipients", _properties [2]},
			{ "encrypted_key", _properties [3]},
			{ "aad", _properties [4]},
			{ "ciphertext", _properties [5]},
			{ "tag", _properties [6]}}, __Tag,
		() => new JoseWebEncryption(), () => [], () => [], JoseWebSignature._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class JWKS : Jose {
    /// <summary>
    /// </summary>

	[JsonPropertyName("keys")]
	public virtual List<JWK>?					Keys  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("keys", typeof (JWK),
					(data, value) => {(data as JWKS).Keys = value as List<JWK>;}, 
					data => (data as JWKS).Keys,
					false, ()=>new  List<JWK>(), ()=>new JWK())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JWKS> _binding = new (
			new() {
			{ "keys", _properties [0]}}, __Tag,
		() => new JWKS(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JWKS";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JWKS();

	}


	/// <summary>
	/// </summary>
public partial class JWK : Jose {
    /// <summary>
    /// </summary>

	[JsonPropertyName("kty")]
	public virtual string?					KeyType  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("use")]
	public virtual string?					Use  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("key_ops")]
	public virtual string?					KeyOps  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("alg")]
	public virtual string?					Alg  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("kid")]
	public virtual string?					Kid  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("x5u")]
	public virtual byte[]?					X5u  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("x5t")]
	public virtual byte[]?					X5T  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("x5t#S256")]
	public virtual byte[]?					X5T256  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStringTag ("kty", 
					(data, value) => {(data as JWK).KeyType = value;}, 
					data => (data as JWK).KeyType ),
		new PropertyString ("use", 
					(data, value) => {(data as JWK).Use = value;}, 
					data => (data as JWK).Use ),
		new PropertyString ("key_ops", 
					(data, value) => {(data as JWK).KeyOps = value;}, 
					data => (data as JWK).KeyOps ),
		new PropertyString ("alg", 
					(data, value) => {(data as JWK).Alg = value;}, 
					data => (data as JWK).Alg ),
		new PropertyString ("kid", 
					(data, value) => {(data as JWK).Kid = value;}, 
					data => (data as JWK).Kid ),
		new PropertyBinary ("x5u", 
					(data, value) => {(data as JWK).X5u = value;}, 
					data => (data as JWK).X5u ),
		new PropertyBinary ("x5t", 
					(data, value) => {(data as JWK).X5T = value;}, 
					data => (data as JWK).X5T ),
		new PropertyBinary ("x5t#S256", 
					(data, value) => {(data as JWK).X5T256 = value;}, 
					data => (data as JWK).X5T256 )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JWK> _binding = new (
			new() {
			{ "kty", _properties [0]},
			{ "use", _properties [1]},
			{ "key_ops", _properties [2]},
			{ "alg", _properties [3]},
			{ "kid", _properties [4]},
			{ "x5u", _properties [5]},
			{ "x5t", _properties [6]},
			{ "x5t#S256", _properties [7]}}, __Tag,
		() => new JWK(), () => [], () => [], null, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JWK";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JWK();

	}


	/// <summary>
	/// </summary>
public partial class JwkEllipticCurve : JWK {
    /// <summary>
    ///The "crv" (curve) parameter identifies the cryptographic curve used
    ///with the key
    /// </summary>

	[JsonPropertyName("crv")]
	public virtual string?					Curve  {get; set;} //

    /// <summary>
    ///The "x" (x coordinate) parameter contains the x coordinate for the
    ///Elliptic Curve point.
    /// </summary>

	[JsonPropertyName("x")]
	public virtual string?					X  {get; set;} //

    /// <summary>
    ///The "y" (y coordinate) parameter contains the y coordinate for the
    ///Elliptic Curve point.
    /// </summary>

	[JsonPropertyName("y")]
	public virtual string?					Y  {get; set;} //

    /// <summary>
    ///The "d" (ECC private key) parameter contains the Elliptic Curve
    ///private key value.
    /// </summary>

	[JsonPropertyName("d")]
	public virtual string?					D  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("crv", 
					(data, value) => {(data as JwkEllipticCurve).Curve = value;}, 
					data => (data as JwkEllipticCurve).Curve ),
		new PropertyString ("x", 
					(data, value) => {(data as JwkEllipticCurve).X = value;}, 
					data => (data as JwkEllipticCurve).X ),
		new PropertyString ("y", 
					(data, value) => {(data as JwkEllipticCurve).Y = value;}, 
					data => (data as JwkEllipticCurve).Y ),
		new PropertyString ("d", 
					(data, value) => {(data as JwkEllipticCurve).D = value;}, 
					data => (data as JwkEllipticCurve).D )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkEllipticCurve> _binding = new (
			new() {
			{ "crv", _properties [0]},
			{ "x", _properties [1]},
			{ "y", _properties [2]},
			{ "d", _properties [3]}}, __Tag,
		() => new JwkEllipticCurve(), () => [], () => [], JWK._binding, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "EC";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkEllipticCurve();

	}


	/// <summary>
	/// </summary>
public partial class JwkRsa : JWK {
    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("n")]
	public virtual string?					N  {get; set;} //

    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("e")]
	public virtual string?					E  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("n", 
					(data, value) => {(data as JwkRsa).N = value;}, 
					data => (data as JwkRsa).N ),
		new PropertyString ("e", 
					(data, value) => {(data as JwkRsa).E = value;}, 
					data => (data as JwkRsa).E )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkRsa> _binding = new (
			new() {
			{ "n", _properties [0]},
			{ "e", _properties [1]}}, __Tag,
		() => new JwkRsa(), () => [], () => [], JWK._binding, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "RSA";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkRsa();

	}


	/// <summary>
	/// </summary>
public partial class JwkRsaPrivate : PublicKeyRSA {
    /// <summary>
    ///The parameter d
    /// </summary>

	[JsonPropertyName("d")]
	public virtual byte[]?					D  {get; set;} //

    /// <summary>
    ///The parameter p
    /// </summary>

	[JsonPropertyName("p")]
	public virtual byte[]?					P  {get; set;} //

    /// <summary>
    ///The parameter q
    /// </summary>

	[JsonPropertyName("q")]
	public virtual byte[]?					Q  {get; set;} //

    /// <summary>
    ///The parameter dp
    /// </summary>

	[JsonPropertyName("dp")]
	public virtual byte[]?					DP  {get; set;} //

    /// <summary>
    ///The parameter dq
    /// </summary>

	[JsonPropertyName("dq")]
	public virtual byte[]?					DQ  {get; set;} //

    /// <summary>
    ///The parameter QInverse
    /// </summary>

	[JsonPropertyName("qi")]
	public virtual byte[]?					QI  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("d", 
					(data, value) => {(data as JwkRsaPrivate).D = value;}, 
					data => (data as JwkRsaPrivate).D ),
		new PropertyBinary ("p", 
					(data, value) => {(data as JwkRsaPrivate).P = value;}, 
					data => (data as JwkRsaPrivate).P ),
		new PropertyBinary ("q", 
					(data, value) => {(data as JwkRsaPrivate).Q = value;}, 
					data => (data as JwkRsaPrivate).Q ),
		new PropertyBinary ("dp", 
					(data, value) => {(data as JwkRsaPrivate).DP = value;}, 
					data => (data as JwkRsaPrivate).DP ),
		new PropertyBinary ("dq", 
					(data, value) => {(data as JwkRsaPrivate).DQ = value;}, 
					data => (data as JwkRsaPrivate).DQ ),
		new PropertyBinary ("qi", 
					(data, value) => {(data as JwkRsaPrivate).QI = value;}, 
					data => (data as JwkRsaPrivate).QI )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkRsaPrivate> _binding = new (
			new() {
			{ "d", _properties [0]},
			{ "p", _properties [1]},
			{ "q", _properties [2]},
			{ "dp", _properties [3]},
			{ "dq", _properties [4]},
			{ "qi", _properties [5]}}, __Tag,
		() => new JwkRsaPrivate(), () => [], () => [], PublicKeyRSA._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JwkRsaPrivate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkRsaPrivate();

	}


	/// <summary>
	/// </summary>
public partial class JwkUdfSeed : JWK {
    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("seed")]
	public virtual string?					Seed  {get; set;} //

    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("roots")]
	public virtual List<string>?					Roots  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("seed", 
					(data, value) => {(data as JwkUdfSeed).Seed = value;}, 
					data => (data as JwkUdfSeed).Seed ),
		new PropertyListString ("roots", 
					(data, value) => {(data as JwkUdfSeed).Roots = value;}, 
					data => (data as JwkUdfSeed).Roots )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkUdfSeed> _binding = new (
			new() {
			{ "seed", _properties [0]},
			{ "roots", _properties [1]}}, __Tag,
		() => new JwkUdfSeed(), () => [], () => [], JWK._binding, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "UDFS";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkUdfSeed();

	}


	/// <summary>
	/// </summary>
public partial class JwkOctet : JWK {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkOctet> _binding = new (
			new() {}, __Tag,
		() => new JwkOctet(), () => [], () => [], JWK._binding, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "oct";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkOctet();

	}


	/// <summary>
	/// </summary>
public partial class JwkOctetKeyPairs : JWK {
    /// <summary>
    ///MUST be present and contain the subtype of the key 
    ///(from the "JSON Web Elliptic Curve" registry)
    /// </summary>

	[JsonPropertyName("crv")]
	public virtual string?					Curve  {get; set;} //

    /// <summary>
    ///MUST be present and contain the public key
    ///encoded using the base64url [RFC4648] encoding.
    /// </summary>

	[JsonPropertyName("x")]
	public virtual string?					X  {get; set;} //

    /// <summary>
    ///MUST be present for private keys and contain the
    ///private key encoded using the base64url encoding.  This parameter
    ///MUST NOT be present for public keys.
    /// </summary>

	[JsonPropertyName("d")]
	public virtual string?					D  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("crv", 
					(data, value) => {(data as JwkOctetKeyPairs).Curve = value;}, 
					data => (data as JwkOctetKeyPairs).Curve ),
		new PropertyString ("x", 
					(data, value) => {(data as JwkOctetKeyPairs).X = value;}, 
					data => (data as JwkOctetKeyPairs).X ),
		new PropertyString ("d", 
					(data, value) => {(data as JwkOctetKeyPairs).D = value;}, 
					data => (data as JwkOctetKeyPairs).D )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwkOctetKeyPairs> _binding = new (
			new() {
			{ "crv", _properties [0]},
			{ "x", _properties [1]},
			{ "d", _properties [2]}}, __Tag,
		() => new JwkOctetKeyPairs(), () => [], () => [], JWK._binding, 
		TypeTag:"kty" , Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "OKP";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwkOctetKeyPairs();

	}


	/// <summary>
	/// </summary>
public partial class JwtHeader : Jose {
    /// <summary>
    ///Another IANA content type parameter
    /// </summary>

	[JsonPropertyName("typ")]
	public virtual string?					Typ  {get; set;} //

    /// <summary>
    ///Key exchange algorithm
    /// </summary>

	[JsonPropertyName("alg")]
	public virtual string?					Alg  {get; set;} //

    /// <summary>
    ///JSON Web Key	
    /// </summary>

	[JsonPropertyName("jwk")]
	public virtual JWK?					Jwk  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("typ", 
					(data, value) => {(data as JwtHeader).Typ = value;}, 
					data => (data as JwtHeader).Typ ),
		new PropertyString ("alg", 
					(data, value) => {(data as JwtHeader).Alg = value;}, 
					data => (data as JwtHeader).Alg ),
		new PropertyStruct ("jwk", typeof (JWK),
					(data, value) => {(data as JwtHeader).Jwk = value as JWK;}, 
					data => (data as JwtHeader).Jwk,
					false, ()=>new  JWK(), ()=>new JWK())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwtHeader> _binding = new (
			new() {
			{ "typ", _properties [0]},
			{ "alg", _properties [1]},
			{ "jwk", _properties [2]}}, __Tag,
		() => new JwtHeader(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JwtHeader";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwtHeader();

	}


	/// <summary>
	///
	/// Compact representation for signed data
	/// </summary>
public partial class Signed : Jose {
    /// <summary>
    ///Data protected by the signature
    /// </summary>

	[JsonPropertyName("protected")]
	public virtual byte[]?					Protected  {get; set;} //

    /// <summary>
    ///The authenticated data
    /// </summary>

	[JsonPropertyName("payload")]
	public virtual byte[]?					Payload  {get; set;} //

    /// <summary>
    ///The signature data
    /// </summary>

	[JsonPropertyName("signature")]
	public virtual byte[]?					Signature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("protected", 
					(data, value) => {(data as Signed).Protected = value;}, 
					data => (data as Signed).Protected ),
		new PropertyBinary ("payload", 
					(data, value) => {(data as Signed).Payload = value;}, 
					data => (data as Signed).Payload ),
		new PropertyBinary ("signature", 
					(data, value) => {(data as Signed).Signature = value;}, 
					data => (data as Signed).Signature )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Signed> _binding = new (
			new() {
			{ "protected", _properties [0]},
			{ "payload", _properties [1]},
			{ "signature", _properties [2]}}, __Tag,
		() => new Signed(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Compact representation for encrypted data
	/// </summary>
public partial class Encrypted : Jose {
    /// <summary>
    ///Header
    /// </summary>

	[JsonPropertyName("header")]
	public virtual Header?					Header  {get; set;} //

    /// <summary>
    ///The initialization vector for the cipher
    /// </summary>

	[JsonPropertyName("iv")]
	public virtual byte[]?					IV  {get; set;} //

    /// <summary>
    ///The encrypted data 
    /// </summary>

	[JsonPropertyName("ciphertext")]
	public virtual byte[]?					CipherText  {get; set;} //

    /// <summary>
    ///The signature data
    /// </summary>

	[JsonPropertyName("signature")]
	public virtual byte[]?					Signature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("header", typeof (Header),
					(data, value) => {(data as Encrypted).Header = value as Header;}, 
					data => (data as Encrypted).Header,
					false, ()=>new  Header(), ()=>new Header()),
		new PropertyBinary ("iv", 
					(data, value) => {(data as Encrypted).IV = value;}, 
					data => (data as Encrypted).IV ),
		new PropertyBinary ("ciphertext", 
					(data, value) => {(data as Encrypted).CipherText = value;}, 
					data => (data as Encrypted).CipherText ),
		new PropertyBinary ("signature", 
					(data, value) => {(data as Encrypted).Signature = value;}, 
					data => (data as Encrypted).Signature )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Encrypted> _binding = new (
			new() {
			{ "header", _properties [0]},
			{ "iv", _properties [1]},
			{ "ciphertext", _properties [2]},
			{ "signature", _properties [3]}}, __Tag,
		() => new Encrypted(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class JsonWebKeys : Jose {
    /// <summary>
    /// </summary>

	[JsonPropertyName("keys")]
	public virtual List<KeyCore>?					Keys  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("keys", typeof (KeyCore),
					(data, value) => {(data as JsonWebKeys).Keys = value as List<KeyCore>;}, 
					data => (data as JsonWebKeys).Keys,
					false, ()=>new  List<KeyCore>(), ()=>new KeyCore())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsonWebKeys> _binding = new (
			new() {
			{ "keys", _properties [0]}}, __Tag,
		() => new JsonWebKeys(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsonWebKeys";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsonWebKeys();

	}


	/// <summary>
	///
	/// Describe a cryptographic key
	/// </summary>
public partial class KeyCore : Jose {
    /// <summary>
    ///Bulk encryption algorithm for content
    /// </summary>

	[JsonPropertyName("enc")]
	public virtual string?					Enc  {get; set;} //

    /// <summary>
    ///Digest algorithm hint
    /// </summary>

	[JsonPropertyName("dig")]
	public virtual string?					Dig  {get; set;} //

    /// <summary>
    ///Key exchange algorithm
    /// </summary>

	[JsonPropertyName("alg")]
	public virtual string?					Alg  {get; set;} //

    /// <summary>
    ///Key identifier. If a UDF fingerprint is used to identify the 
    ///key it is placed in this field.
    /// </summary>

	[JsonPropertyName("kid")]
	public virtual string?					Kid  {get; set;} //

    /// <summary>
    ///URL identifying an X.509 public key certificate
    /// </summary>

	[JsonPropertyName("x5u")]
	public virtual string?					X5u  {get; set;} //

    /// <summary>
    ///An X.509 public key certificate
    /// </summary>

	[JsonPropertyName("x5c")]
	public virtual byte[]?					X5c  {get; set;} //

    /// <summary>
    ///SHA-1 fingerprint of X.509 certificate
    /// </summary>

	[JsonPropertyName("x5t")]
	public virtual byte[]?					X5t  {get; set;} //

    /// <summary>
    ///SHA-2-256 fingerprint of X.509 certificate
    /// </summary>

	[JsonPropertyName("x5t#S256")]
	public virtual byte[]?					X5tS256  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("enc", 
					(data, value) => {(data as KeyCore).Enc = value;}, 
					data => (data as KeyCore).Enc ),
		new PropertyString ("dig", 
					(data, value) => {(data as KeyCore).Dig = value;}, 
					data => (data as KeyCore).Dig ),
		new PropertyString ("alg", 
					(data, value) => {(data as KeyCore).Alg = value;}, 
					data => (data as KeyCore).Alg ),
		new PropertyString ("kid", 
					(data, value) => {(data as KeyCore).Kid = value;}, 
					data => (data as KeyCore).Kid ),
		new PropertyString ("x5u", 
					(data, value) => {(data as KeyCore).X5u = value;}, 
					data => (data as KeyCore).X5u ),
		new PropertyBinary ("x5c", 
					(data, value) => {(data as KeyCore).X5c = value;}, 
					data => (data as KeyCore).X5c ),
		new PropertyBinary ("x5t", 
					(data, value) => {(data as KeyCore).X5t = value;}, 
					data => (data as KeyCore).X5t ),
		new PropertyBinary ("x5t#S256", 
					(data, value) => {(data as KeyCore).X5tS256 = value;}, 
					data => (data as KeyCore).X5tS256 )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyCore> _binding = new (
			new() {
			{ "enc", _properties [0]},
			{ "dig", _properties [1]},
			{ "alg", _properties [2]},
			{ "kid", _properties [3]},
			{ "x5u", _properties [4]},
			{ "x5c", _properties [5]},
			{ "x5t", _properties [6]},
			{ "x5t#S256", _properties [7]}}, __Tag,
		() => new KeyCore(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// A JOSE Header.
	/// </summary>
public partial class Header : KeyCore {
    /// <summary>
    ///JWK Set URL
    /// </summary>

	[JsonPropertyName("jku")]
	public virtual string?					Jku  {get; set;} //

    /// <summary>
    ///The key parameters
    /// </summary>

	[JsonPropertyName("jwk")]
	public virtual Key?					Jwk  {get; set;} //

    /// <summary>
    ///The key parameters of the ephemeral key
    /// </summary>

	[JsonPropertyName("epk")]
	public virtual Key?					Epk  {get; set;} //

    /// <summary>
    ///Binary cryptographic exchange parameters
    /// </summary>

	[JsonPropertyName("ek")]
	public virtual byte[]?					Ek  {get; set;} //

    /// <summary>
    ///Another IANA content type parameter
    /// </summary>

	[JsonPropertyName("typ")]
	public virtual string?					Typ  {get; set;} //

    /// <summary>
    ///Content type parameter
    /// </summary>

	[JsonPropertyName("cty")]
	public virtual string?					Cty  {get; set;} //

    /// <summary>
    ///List of header parameters that a recipient MUST understand to interpret
    ///the authentication portion of the JOSE object.
    /// </summary>

	[JsonPropertyName("crit")]
	public virtual List<string>?					Crit  {get; set;}
    /// <summary>
    ///The digest value
    /// </summary>

	[JsonPropertyName("val")]
	public virtual byte[]?					Val  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("jku", 
					(data, value) => {(data as Header).Jku = value;}, 
					data => (data as Header).Jku ),
		new PropertyStruct ("jwk", typeof (Key), 
					(data, value) => {(data as Header).Jwk = value as Key;}, 
					data => (data as Header).Jwk,
					true) ,
		new PropertyStruct ("epk", typeof (Key), 
					(data, value) => {(data as Header).Epk = value as Key;}, 
					data => (data as Header).Epk,
					true) ,
		new PropertyBinary ("ek", 
					(data, value) => {(data as Header).Ek = value;}, 
					data => (data as Header).Ek ),
		new PropertyString ("typ", 
					(data, value) => {(data as Header).Typ = value;}, 
					data => (data as Header).Typ ),
		new PropertyString ("cty", 
					(data, value) => {(data as Header).Cty = value;}, 
					data => (data as Header).Cty ),
		new PropertyListString ("crit", 
					(data, value) => {(data as Header).Crit = value;}, 
					data => (data as Header).Crit ),
		new PropertyBinary ("val", 
					(data, value) => {(data as Header).Val = value;}, 
					data => (data as Header).Val )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Header> _binding = new (
			new() {
			{ "jku", _properties [0]},
			{ "jwk", _properties [1]},
			{ "epk", _properties [2]},
			{ "ek", _properties [3]},
			{ "typ", _properties [4]},
			{ "cty", _properties [5]},
			{ "crit", _properties [6]},
			{ "val", _properties [7]}}, __Tag,
		() => new Header(), () => [], () => [], KeyCore._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The signature value
	/// </summary>
public partial class Signature : Jose {
    /// <summary>
    ///The signature header
    /// </summary>

	[JsonPropertyName("header")]
	public virtual Header?					Header  {get; set;} //

    /// <summary>
    ///Data protected by the signature
    /// </summary>

	[JsonPropertyName("protected")]
	public virtual byte[]?					Protected  {get; set;} //

    /// <summary>
    ///The signature value
    /// </summary>

	[JsonPropertyName("signature")]
	public virtual byte[]?					SignatureValue  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("header", typeof (Header),
					(data, value) => {(data as Signature).Header = value as Header;}, 
					data => (data as Signature).Header,
					false, ()=>new  Header(), ()=>new Header()),
		new PropertyBinary ("protected", 
					(data, value) => {(data as Signature).Protected = value;}, 
					data => (data as Signature).Protected ),
		new PropertyBinary ("signature", 
					(data, value) => {(data as Signature).SignatureValue = value;}, 
					data => (data as Signature).SignatureValue )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Signature> _binding = new (
			new() {
			{ "header", _properties [0]},
			{ "protected", _properties [1]},
			{ "signature", _properties [2]}}, __Tag,
		() => new Signature(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// A wrapper object for storing key data.
	/// </summary>
public partial class KeyContainer : Jose {
    /// <summary>
    ///If false a handler library MUST NOT permit the private key to be exported.
    /// </summary>

	[JsonPropertyName("Exportable")]
	public virtual bool?					Exportable  {get; set;} //

    /// <summary>
    ///The key data.
    /// </summary>

	[JsonPropertyName("KeyCore")]
	public virtual byte[]?					KeyCore  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Exportable", 
					(data, value) => {(data as KeyContainer).Exportable = value;}, 
					data => (data as KeyContainer).Exportable ),
		new PropertyBinary ("KeyCore", 
					(data, value) => {(data as KeyContainer).KeyCore = value;}, 
					data => (data as KeyContainer).KeyCore )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyContainer> _binding = new (
			new() {
			{ "Exportable", _properties [0]},
			{ "KeyCore", _properties [1]}}, __Tag,
		() => new KeyContainer(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("Exportable")]
	public virtual bool?					Exportable  {get; set;} //

    /// <summary>
    ///Key type
    /// </summary>

	[JsonPropertyName("kty")]
	public virtual string?					Kty  {get; set;} //

    /// <summary>
    ///Public Key use
    /// </summary>

	[JsonPropertyName("use")]
	public virtual string?					Use  {get; set;} //

    /// <summary>
    ///Key operations
    /// </summary>

	[JsonPropertyName("key_ops")]
	public virtual List<string>?					Key_ops  {get; set;}
    /// <summary>
    ///Symmetric key value.
    /// </summary>

	[JsonPropertyName("k")]
	public virtual byte[]?					K  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Exportable", 
					(data, value) => {(data as Key).Exportable = value;}, 
					data => (data as Key).Exportable ),
		new PropertyString ("kty", 
					(data, value) => {(data as Key).Kty = value;}, 
					data => (data as Key).Kty ),
		new PropertyString ("use", 
					(data, value) => {(data as Key).Use = value;}, 
					data => (data as Key).Use ),
		new PropertyListString ("key_ops", 
					(data, value) => {(data as Key).Key_ops = value;}, 
					data => (data as Key).Key_ops ),
		new PropertyBinary ("k", 
					(data, value) => {(data as Key).K = value;}, 
					data => (data as Key).K )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Key> _binding = new (
			new() {
			{ "Exportable", _properties [0]},
			{ "kty", _properties [1]},
			{ "use", _properties [2]},
			{ "key_ops", _properties [3]},
			{ "k", _properties [4]}}, __Tag,
		() => new Key(), () => [], () => [], KeyCore._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Recipient information
	/// </summary>
public partial class Recipient : Jose {
    /// <summary>
    ///Specify the recipient and per recipient data
    /// </summary>

	[JsonPropertyName("Header")]
	public virtual Header?					Header  {get; set;} //

    /// <summary>
    ///The decryption data for use by this recipient.
    /// </summary>

	[JsonPropertyName("encrypted_key")]
	public virtual byte[]?					EncryptedKey  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Header", typeof (Header),
					(data, value) => {(data as Recipient).Header = value as Header;}, 
					data => (data as Recipient).Header,
					false, ()=>new  Header(), ()=>new Header()),
		new PropertyBinary ("encrypted_key", 
					(data, value) => {(data as Recipient).EncryptedKey = value;}, 
					data => (data as Recipient).EncryptedKey )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Recipient> _binding = new (
			new() {
			{ "Header", _properties [0]},
			{ "encrypted_key", _properties [1]}}, __Tag,
		() => new Recipient(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// An RSA Public key
	/// </summary>
public partial class PublicKeyRSA : Key {
    /// <summary>
    ///The public modulus
    /// </summary>

	[JsonPropertyName("n")]
	public virtual byte[]?					N  {get; set;} //

    /// <summary>
    ///The public exponent
    /// </summary>

	[JsonPropertyName("e")]
	public virtual byte[]?					E  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("n", 
					(data, value) => {(data as PublicKeyRSA).N = value;}, 
					data => (data as PublicKeyRSA).N ),
		new PropertyBinary ("e", 
					(data, value) => {(data as PublicKeyRSA).E = value;}, 
					data => (data as PublicKeyRSA).E )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicKeyRSA> _binding = new (
			new() {
			{ "n", _properties [0]},
			{ "e", _properties [1]}}, __Tag,
		() => new PublicKeyRSA(), () => [], () => [], Key._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// RSA private key parameters
	/// </summary>
public partial class PrivateKeyRSA : PublicKeyRSA {
    /// <summary>
    ///The parameter d
    /// </summary>

	[JsonPropertyName("d")]
	public virtual byte[]?					D  {get; set;} //

    /// <summary>
    ///The parameter p
    /// </summary>

	[JsonPropertyName("p")]
	public virtual byte[]?					P  {get; set;} //

    /// <summary>
    ///The parameter q
    /// </summary>

	[JsonPropertyName("q")]
	public virtual byte[]?					Q  {get; set;} //

    /// <summary>
    ///The parameter dp
    /// </summary>

	[JsonPropertyName("dp")]
	public virtual byte[]?					DP  {get; set;} //

    /// <summary>
    ///The parameter dq
    /// </summary>

	[JsonPropertyName("dq")]
	public virtual byte[]?					DQ  {get; set;} //

    /// <summary>
    ///The parameter QInverse
    /// </summary>

	[JsonPropertyName("qi")]
	public virtual byte[]?					QI  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("d", 
					(data, value) => {(data as PrivateKeyRSA).D = value;}, 
					data => (data as PrivateKeyRSA).D ),
		new PropertyBinary ("p", 
					(data, value) => {(data as PrivateKeyRSA).P = value;}, 
					data => (data as PrivateKeyRSA).P ),
		new PropertyBinary ("q", 
					(data, value) => {(data as PrivateKeyRSA).Q = value;}, 
					data => (data as PrivateKeyRSA).Q ),
		new PropertyBinary ("dp", 
					(data, value) => {(data as PrivateKeyRSA).DP = value;}, 
					data => (data as PrivateKeyRSA).DP ),
		new PropertyBinary ("dq", 
					(data, value) => {(data as PrivateKeyRSA).DQ = value;}, 
					data => (data as PrivateKeyRSA).DQ ),
		new PropertyBinary ("qi", 
					(data, value) => {(data as PrivateKeyRSA).QI = value;}, 
					data => (data as PrivateKeyRSA).QI )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PrivateKeyRSA> _binding = new (
			new() {
			{ "d", _properties [0]},
			{ "p", _properties [1]},
			{ "q", _properties [2]},
			{ "dp", _properties [3]},
			{ "dq", _properties [4]},
			{ "qi", _properties [5]}}, __Tag,
		() => new PrivateKeyRSA(), () => [], () => [], PublicKeyRSA._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// A Diffie Helllman Public key
	/// </summary>
public partial class PublicKeyDH : Key {
    /// <summary>
    ///The fingerprint of the domain
    /// </summary>

	[JsonPropertyName("Domain")]
	public virtual byte[]?					Domain  {get; set;} //

    /// <summary>
    ///The public key
    /// </summary>

	[JsonPropertyName("Public")]
	public virtual byte[]?					Public  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Domain", 
					(data, value) => {(data as PublicKeyDH).Domain = value;}, 
					data => (data as PublicKeyDH).Domain ),
		new PropertyBinary ("Public", 
					(data, value) => {(data as PublicKeyDH).Public = value;}, 
					data => (data as PublicKeyDH).Public )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicKeyDH> _binding = new (
			new() {
			{ "Domain", _properties [0]},
			{ "Public", _properties [1]}}, __Tag,
		() => new PublicKeyDH(), () => [], () => [], Key._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Diffie Helllman private key parameters
	/// </summary>
public partial class PrivateKeyDH : PublicKeyDH {
    /// <summary>
    ///The private key.
    /// </summary>

	[JsonPropertyName("Private")]
	public virtual byte[]?					Private  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Private", 
					(data, value) => {(data as PrivateKeyDH).Private = value;}, 
					data => (data as PrivateKeyDH).Private )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PrivateKeyDH> _binding = new (
			new() {
			{ "Private", _properties [0]}}, __Tag,
		() => new PrivateKeyDH(), () => [], () => [], PublicKeyDH._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// An Elliptic Curve Diffie Hellman public key
	/// </summary>
public partial class PublicKeyECDH : Key {
    /// <summary>
    ///The curve specifier (X25519, Ed25519, X448, Ed448), etc.
    /// </summary>

	[JsonPropertyName("crv")]
	public virtual string?					Curve  {get; set;} //

    /// <summary>
    ///The public key
    /// </summary>

	[JsonPropertyName("Public")]
	public virtual byte[]?					Public  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("crv", 
					(data, value) => {(data as PublicKeyECDH).Curve = value;}, 
					data => (data as PublicKeyECDH).Curve ),
		new PropertyBinary ("Public", 
					(data, value) => {(data as PublicKeyECDH).Public = value;}, 
					data => (data as PublicKeyECDH).Public )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicKeyECDH> _binding = new (
			new() {
			{ "crv", _properties [0]},
			{ "Public", _properties [1]}}, __Tag,
		() => new PublicKeyECDH(), () => [], () => [], Key._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Diffie Helllman private key parameters
	/// </summary>
public partial class PrivateKeyECDH : PublicKeyECDH {
    /// <summary>
    ///The private key
    /// </summary>

	[JsonPropertyName("Private")]
	public virtual byte[]?					Private  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Private", 
					(data, value) => {(data as PrivateKeyECDH).Private = value;}, 
					data => (data as PrivateKeyECDH).Private )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PrivateKeyECDH> _binding = new (
			new() {
			{ "Private", _properties [0]}}, __Tag,
		() => new PrivateKeyECDH(), () => [], () => [], PublicKeyECDH._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// A UDF Key
	/// </summary>
public partial class PrivateKeyUDF : Key {
    /// <summary>
    ///The private value
    /// </summary>

	[JsonPropertyName("PrivateValue")]
	public virtual string?					PrivateValue  {get; set;} //

    /// <summary>
    ///The UDF key identifier
    /// </summary>

	[JsonPropertyName("KeyType")]
	public virtual string?					KeyType  {get; set;} //

    /// <summary>
    ///List of algorithms used to derrive root signature keys.
    /// </summary>

	[JsonPropertyName("RootSignAlgorithms")]
	public virtual List<string>?					RootSignAlgorithms  {get; set;}
    /// <summary>
    ///The algorithm used to derrive the encryption key
    /// </summary>

	[JsonPropertyName("AlgorithmEncrypt")]
	public virtual string?					AlgorithmEncrypt  {get; set;} //

    /// <summary>
    ///The algorithm used to derrive the signature key
    /// </summary>

	[JsonPropertyName("AlgorithmSign")]
	public virtual string?					AlgorithmSign  {get; set;} //

    /// <summary>
    ///The algorithm used to derrive the authentication key
    /// </summary>

	[JsonPropertyName("AlgorithmAuthenticate")]
	public virtual string?					AlgorithmAuthenticate  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("PrivateValue", 
					(data, value) => {(data as PrivateKeyUDF).PrivateValue = value;}, 
					data => (data as PrivateKeyUDF).PrivateValue ),
		new PropertyString ("KeyType", 
					(data, value) => {(data as PrivateKeyUDF).KeyType = value;}, 
					data => (data as PrivateKeyUDF).KeyType ),
		new PropertyListString ("RootSignAlgorithms", 
					(data, value) => {(data as PrivateKeyUDF).RootSignAlgorithms = value;}, 
					data => (data as PrivateKeyUDF).RootSignAlgorithms ),
		new PropertyString ("AlgorithmEncrypt", 
					(data, value) => {(data as PrivateKeyUDF).AlgorithmEncrypt = value;}, 
					data => (data as PrivateKeyUDF).AlgorithmEncrypt ),
		new PropertyString ("AlgorithmSign", 
					(data, value) => {(data as PrivateKeyUDF).AlgorithmSign = value;}, 
					data => (data as PrivateKeyUDF).AlgorithmSign ),
		new PropertyString ("AlgorithmAuthenticate", 
					(data, value) => {(data as PrivateKeyUDF).AlgorithmAuthenticate = value;}, 
					data => (data as PrivateKeyUDF).AlgorithmAuthenticate )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PrivateKeyUDF> _binding = new (
			new() {
			{ "PrivateValue", _properties [0]},
			{ "KeyType", _properties [1]},
			{ "RootSignAlgorithms", _properties [2]},
			{ "AlgorithmEncrypt", _properties [3]},
			{ "AlgorithmSign", _properties [4]},
			{ "AlgorithmAuthenticate", _properties [5]}}, __Tag,
		() => new PrivateKeyUDF(), () => [], () => [], Key._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreement : Jose {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyAgreement> _binding = new (
			new() {}, __Tag,
		() => new KeyAgreement(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreementDH : KeyAgreement {
    /// <summary>
    ///The result
    /// </summary>

	[JsonPropertyName("Result")]
	public virtual byte[]?					Result  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Result", 
					(data, value) => {(data as KeyAgreementDH).Result = value;}, 
					data => (data as KeyAgreementDH).Result )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyAgreementDH> _binding = new (
			new() {
			{ "Result", _properties [0]}}, __Tag,
		() => new KeyAgreementDH(), () => [], () => [], KeyAgreement._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Result of applying a key agreement.
	/// </summary>
public partial class KeyAgreementECDH : KeyAgreement {
    /// <summary>
    ///The curve name
    /// </summary>

	[JsonPropertyName("Curve")]
	public virtual string?					Curve  {get; set;} //

    /// <summary>
    ///The result
    /// </summary>

	[JsonPropertyName("Result")]
	public virtual byte[]?					Result  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Curve", 
					(data, value) => {(data as KeyAgreementECDH).Curve = value;}, 
					data => (data as KeyAgreementECDH).Curve ),
		new PropertyBinary ("Result", 
					(data, value) => {(data as KeyAgreementECDH).Result = value;}, 
					data => (data as KeyAgreementECDH).Result )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyAgreementECDH> _binding = new (
			new() {
			{ "Curve", _properties [0]},
			{ "Result", _properties [1]}}, __Tag,
		() => new KeyAgreementECDH(), () => [], () => [], KeyAgreement._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// A public key represented as a binary blob whose type is specified
	/// by Kty.
	/// </summary>
public partial class PublicKeyBinary : Key {
    /// <summary>
    ///The public key value
    /// </summary>

	[JsonPropertyName("Public")]
	public virtual byte[]?					Public  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Public", 
					(data, value) => {(data as PublicKeyBinary).Public = value;}, 
					data => (data as PublicKeyBinary).Public )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicKeyBinary> _binding = new (
			new() {
			{ "Public", _properties [0]}}, __Tag,
		() => new PublicKeyBinary(), () => [], () => [], Key._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PublicKeyBinary";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicKeyBinary();

	}


	/// <summary>
	///
	/// A private key represented as a binary blob whose type is specified
	/// by Kty.
	/// </summary>
public partial class PrivateKeyBinary : Key {
    /// <summary>
    ///The private key value
    /// </summary>

	[JsonPropertyName("Public")]
	public virtual byte[]?					Public  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Public", 
					(data, value) => {(data as PrivateKeyBinary).Public = value;}, 
					data => (data as PrivateKeyBinary).Public )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PrivateKeyBinary> _binding = new (
			new() {
			{ "Public", _properties [0]}}, __Tag,
		() => new PrivateKeyBinary(), () => [], () => [], Key._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PrivateKeyBinary";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PrivateKeyBinary();

	}



