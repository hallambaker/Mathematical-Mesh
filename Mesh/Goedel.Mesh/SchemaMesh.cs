
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
//  This file was automatically generated at 5/8/2024 4:32:04 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1131
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22631.0
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

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh;


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
public abstract partial class MeshItem : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshItem";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"KeyData", KeyData._Factory},
	    {"KeyShare", KeyShare._Factory},
	    {"CompositePrivate", CompositePrivate._Factory},
	    {"Assertion", Assertion._Factory},
	    {"Condition", Condition._Factory},
	    {"Activation", Activation._Factory},
	    {"ActivationEntry", ActivationEntry._Factory},
	    {"Profile", Profile._Factory},
	    {"ProfileDevice", ProfileDevice._Factory},
	    {"ProfileAccount", ProfileAccount._Factory},
	    {"ProfileUser", ProfileUser._Factory},
	    {"ProfileGroup", ProfileGroup._Factory},
	    {"ProfileService", ProfileService._Factory},
	    {"ProfileMeshService", ProfileMeshService._Factory},
	    {"ProfileHost", ProfileHost._Factory},
	    {"Connection", Connection._Factory},
	    {"CallsignBinding", CallsignBinding._Factory},
	    {"Accreditation", Accreditation._Factory},
	    {"ConnectionStripped", ConnectionStripped._Factory},
	    {"ConnectionService", ConnectionService._Factory},
	    {"ConnectionDevice", ConnectionDevice._Factory},
	    {"ConnectionApplication", ConnectionApplication._Factory},
	    {"ConnectionGroup", ConnectionGroup._Factory},
	    {"AccountHostAssignment", AccountHostAssignment._Factory},
	    {"ConnectionHost", ConnectionHost._Factory},
	    {"ActivationAccount", ActivationAccount._Factory},
	    {"ActivationHost", ActivationHost._Factory},
	    {"ActivationCommon", ActivationCommon._Factory},
	    {"ActivationApplication", ActivationApplication._Factory},
	    {"ActivationApplicationSsh", ActivationApplicationSsh._Factory},
	    {"ActivationApplicationMail", ActivationApplicationMail._Factory},
	    {"ActivationApplicationGroup", ActivationApplicationGroup._Factory},
	    {"ApplicationEntry", ApplicationEntry._Factory},
	    {"ApplicationEntrySsh", ApplicationEntrySsh._Factory},
	    {"ApplicationEntryGroup", ApplicationEntryGroup._Factory},
	    {"ApplicationEntryMail", ApplicationEntryMail._Factory},
	    {"Contact", Contact._Factory},
	    {"Anchor", Anchor._Factory},
	    {"TaggedSource", TaggedSource._Factory},
	    {"ContactGroup", ContactGroup._Factory},
	    {"ContactPerson", ContactPerson._Factory},
	    {"ContactOrganization", ContactOrganization._Factory},
	    {"OrganizationName", OrganizationName._Factory},
	    {"PersonName", PersonName._Factory},
	    {"NetworkAddress", NetworkAddress._Factory},
	    {"NetworkCredential", NetworkCredential._Factory},
	    {"NetworkProfile", NetworkProfile._Factory},
	    {"NetworkCapability", NetworkCapability._Factory},
	    {"NetworkProtocol", NetworkProtocol._Factory},
	    {"Role", Role._Factory},
	    {"Location", Location._Factory},
	    {"Bookmark", Bookmark._Factory},
	    {"Reference", Reference._Factory},
	    {"Engagement", Engagement._Factory},
	    {"CatalogedEntry", CatalogedEntry._Factory},
	    {"CatalogedDevice", CatalogedDevice._Factory},
	    {"DeviceDescription", DeviceDescription._Factory},
	    {"CatalogedSignature", CatalogedSignature._Factory},
	    {"CatalogedDocument", CatalogedDocument._Factory},
	    {"CatalogedPublication", CatalogedPublication._Factory},
	    {"CatalogedCredential", CatalogedCredential._Factory},
	    {"CatalogedNetwork", CatalogedNetwork._Factory},
	    {"CatalogedContact", CatalogedContact._Factory},
	    {"CatalogedAccess", CatalogedAccess._Factory},
	    {"Capability", Capability._Factory},
	    {"NullCapability", NullCapability._Factory},
	    {"AccessCapability", AccessCapability._Factory},
	    {"PublicationCapability", PublicationCapability._Factory},
	    {"CryptographicCapability", CryptographicCapability._Factory},
	    {"CapabilityDecrypt", CapabilityDecrypt._Factory},
	    {"CapabilityDecryptPartial", CapabilityDecryptPartial._Factory},
	    {"CapabilityDecryptServiced", CapabilityDecryptServiced._Factory},
	    {"CapabilitySign", CapabilitySign._Factory},
	    {"CapabilityKeyGenerate", CapabilityKeyGenerate._Factory},
	    {"CapabilityFairExchange", CapabilityFairExchange._Factory},
	    {"NamedService", NamedService._Factory},
	    {"ServiceAccessToken", ServiceAccessToken._Factory},
	    {"CatalogedBookmark", CatalogedBookmark._Factory},
	    {"CatalogedTask", CatalogedTask._Factory},
	    {"CatalogedApplication", CatalogedApplication._Factory},
	    {"CatalogedMember", CatalogedMember._Factory},
	    {"CatalogedGroup", CatalogedGroup._Factory},
	    {"CatalogedFeed", CatalogedFeed._Factory},
	    {"CatalogedApplicationMail", CatalogedApplicationMail._Factory},
	    {"CatalogedApplicationPkix", CatalogedApplicationPkix._Factory},
	    {"CatalogedApplicationOpenPgp", CatalogedApplicationOpenPgp._Factory},
	    {"CatalogedApplicationSsh", CatalogedApplicationSsh._Factory},
	    {"CatalogedApplicationGit", CatalogedApplicationGit._Factory},
	    {"CatalogedApplicationDeveloper", CatalogedApplicationDeveloper._Factory},
	    {"MessageInvoice", MessageInvoice._Factory},
	    {"CatalogedReceipt", CatalogedReceipt._Factory},
	    {"CatalogedTicket", CatalogedTicket._Factory},
	    {"DevicePreconfigurationPublic", DevicePreconfigurationPublic._Factory},
	    {"DevicePreconfigurationPrivate", DevicePreconfigurationPrivate._Factory},
	    {"Message", Message._Factory},
	    {"MessageError", MessageError._Factory},
	    {"MessageComplete", MessageComplete._Factory},
	    {"MessageValidated", MessageValidated._Factory},
	    {"MessagePin", MessagePin._Factory},
	    {"RequestConnection", RequestConnection._Factory},
	    {"AcknowledgeConnection", AcknowledgeConnection._Factory},
	    {"RespondConnection", RespondConnection._Factory},
	    {"MessageContact", MessageContact._Factory},
	    {"GroupInvitation", GroupInvitation._Factory},
	    {"MessageMail", MessageMail._Factory},
	    {"RequestConfirmation", RequestConfirmation._Factory},
	    {"ResponseConfirmation", ResponseConfirmation._Factory},
	    {"RequestTask", RequestTask._Factory},
	    {"MessageClaim", MessageClaim._Factory},
	    {"ProcessResult", ProcessResult._Factory},
	    {"ProcessResultNotSupported", ProcessResultNotSupported._Factory},
	    {"ProcessResultNotFound", ProcessResultNotFound._Factory}
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
	/// The KeyData class is used to describe public key pairs and 
	/// trust assertions associated with a public key.
	/// </summary>
public partial class KeyData : MeshItem {
        /// <summary>
        ///UDF fingerprint of the public key parameters
        /// </summary>

	public virtual string?						Udf  {get; set;}

        /// <summary>
        ///List of X.509 Certificates
        /// </summary>

	public virtual byte[]?						X509Certificate  {get; set;}

        /// <summary>
        ///X.509 Certificate chain.
        /// </summary>

	public virtual List<byte[]>?					X509Chain  {get; set;}
        /// <summary>
        ///X.509 Certificate Signing Request.
        /// </summary>

	public virtual byte[]?						X509CSR  {get; set;}

        /// <summary>
        ///If present specifies a time instant that use of the private key
        ///is not valid before.
        /// </summary>

	public virtual DateTime?						NotBefore  {get; set;}

        /// <summary>
        ///If present specifies a time instant that use of the private key
        ///is not valid on or after.
        /// </summary>

	public virtual DateTime?						NotOnOrAfter  {get; set;}

        /// <summary>
        ///The public key parameters as defined in the JOSE specification.
        /// </summary>

	public virtual Key?						PublicParameters  {get; set;}

        /// <summary>
        ///The private key parameters as defined in the JOSE specification.
        /// </summary>

	public virtual Key?						PrivateParameters  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyData(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as KeyData).Udf = value;}, (IBinding data) => (data as KeyData).Udf )},
			{ "X509Certificate", new PropertyBinary ("X509Certificate", 
					(IBinding data, byte[]? value) => {(data as KeyData).X509Certificate = value;}, (IBinding data) => (data as KeyData).X509Certificate )},
			{ "X509Chain", new PropertyListBinary ("X509Chain", 
					(IBinding data, List<byte[]>? value) => {(data as KeyData).X509Chain = value;}, (IBinding data) => (data as KeyData).X509Chain )},
			{ "X509CSR", new PropertyBinary ("X509CSR", 
					(IBinding data, byte[]? value) => {(data as KeyData).X509CSR = value;}, (IBinding data) => (data as KeyData).X509CSR )},
			{ "NotBefore", new PropertyDateTime ("NotBefore", 
					(IBinding data, DateTime? value) => {(data as KeyData).NotBefore = value;}, (IBinding data) => (data as KeyData).NotBefore )},
			{ "NotOnOrAfter", new PropertyDateTime ("NotOnOrAfter", 
					(IBinding data, DateTime? value) => {(data as KeyData).NotOnOrAfter = value;}, (IBinding data) => (data as KeyData).NotOnOrAfter )},
			{ "PublicParameters", new PropertyStruct ("PublicParameters", 
					(IBinding data, object? value) => {(data as KeyData).PublicParameters = value as Key;}, (IBinding data) => (data as KeyData).PublicParameters,
					true)} ,
			{ "PrivateParameters", new PropertyStruct ("PrivateParameters", 
					(IBinding data, object? value) => {(data as KeyData).PrivateParameters = value as Key;}, (IBinding data) => (data as KeyData).PrivateParameters,
					true)} 
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
	public new const string __Tag = "KeyData";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyData();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new KeyData FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyData;
			}
		var Result = new KeyData ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class KeyShare : Key {
        /// <summary>
        ///The public key parameters of the primary key.
        /// </summary>

	public virtual Key?						PublicPrimary  {get; set;}

        /// <summary>
        ///The private key parameters of the share as defined in the JOSE specification.		
        /// </summary>

	public virtual Key?						Share  {get; set;}

        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial key.]
        /// </summary>

	public virtual string?						ServiceId  {get; set;}

        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial key.]	
        /// </summary>

	public virtual string?						ServiceAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new KeyShare(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicPrimary", new PropertyStruct ("PublicPrimary", 
					(IBinding data, object? value) => {(data as KeyShare).PublicPrimary = value as Key;}, (IBinding data) => (data as KeyShare).PublicPrimary,
					true)} ,
			{ "Share", new PropertyStruct ("Share", 
					(IBinding data, object? value) => {(data as KeyShare).Share = value as Key;}, (IBinding data) => (data as KeyShare).Share,
					true)} ,
			{ "ServiceId", new PropertyString ("ServiceId", 
					(IBinding data, string? value) => {(data as KeyShare).ServiceId = value;}, (IBinding data) => (data as KeyShare).ServiceId )},
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as KeyShare).ServiceAddress = value;}, (IBinding data) => (data as KeyShare).ServiceAddress )}
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
	public new const string __Tag = "KeyShare";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new KeyShare();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new KeyShare FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as KeyShare;
			}
		var Result = new KeyShare ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CompositePrivate : Key {
        /// <summary>
        ///UDF fingerprint of the bound device key (if used).
        /// </summary>

	public virtual string?						DeviceKeyUdf  {get; set;}

        /// <summary>
        ///Private parameters of additive key
        /// </summary>

	public virtual Key?						PrivateSalt  {get; set;}

        /// <summary>
        ///Private parameters of serviced share
        /// </summary>

	public virtual Key?						ServiceShare  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CompositePrivate(), Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceKeyUdf", new PropertyString ("DeviceKeyUdf", 
					(IBinding data, string? value) => {(data as CompositePrivate).DeviceKeyUdf = value;}, (IBinding data) => (data as CompositePrivate).DeviceKeyUdf )},
			{ "PrivateSalt", new PropertyStruct ("PrivateSalt", 
					(IBinding data, object? value) => {(data as CompositePrivate).PrivateSalt = value as Key;}, (IBinding data) => (data as CompositePrivate).PrivateSalt,
					true)} ,
			{ "ServiceShare", new PropertyStruct ("ServiceShare", 
					(IBinding data, object? value) => {(data as CompositePrivate).ServiceShare = value as Key;}, (IBinding data) => (data as CompositePrivate).ServiceShare,
					true)} 
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
	public new const string __Tag = "CompositePrivate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CompositePrivate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CompositePrivate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CompositePrivate;
			}
		var Result = new CompositePrivate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Parent class from which all assertion classes are derived
	/// </summary>
abstract public partial class Assertion : MeshItem {
        /// <summary>
        ///Fingerprints of index terms for profile retrieval. The use of the fingerprint
        ///of the name rather than the name itself is a precaution against enumeration
        ///attacks and other forms of abuse.
        /// </summary>

	public virtual List<string>?					Names  {get; set;}
        /// <summary>
        ///The time instant the profile was last modified.
        /// </summary>

	public virtual DateTime?						Updated  {get; set;}

        /// <summary>
        ///A Uniform Notary Token providing evidence that a signature
        ///was performed after the notary token was created.
        /// </summary>

	public virtual string?						NotaryToken  {get; set;}

        /// <summary>
        ///Conditional clause(s) that MAY be verified to evaluate the validity of the
        ///assertion. At present no condition classes are specified.
        /// </summary>

	public virtual Condition?						Conditions  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Names", new PropertyListString ("Names", 
					(IBinding data, List<string>? value) => {(data as Assertion).Names = value;}, (IBinding data) => (data as Assertion).Names )},
			{ "Updated", new PropertyDateTime ("Updated", 
					(IBinding data, DateTime? value) => {(data as Assertion).Updated = value;}, (IBinding data) => (data as Assertion).Updated )},
			{ "NotaryToken", new PropertyString ("NotaryToken", 
					(IBinding data, string? value) => {(data as Assertion).NotaryToken = value;}, (IBinding data) => (data as Assertion).NotaryToken )},
			{ "Conditions", new PropertyStruct ("Conditions", 
					(IBinding data, object? value) => {(data as Assertion).Conditions = value as Condition;}, (IBinding data) => (data as Assertion).Conditions,
					true)} 
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
	public new const string __Tag = "Assertion";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Assertion FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Assertion;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Parent class from which all condition classes are derived.
	/// </summary>
abstract public partial class Condition : MeshItem {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

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
	public new const string __Tag = "Condition";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Condition FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Condition;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Contains the private activation information for a Mesh application running on
	/// a specific device
	/// </summary>
public partial class Activation : Assertion {
        /// <summary>
        ///Secret seed used to derive keys that are not explicitly specified.
        /// </summary>

	public virtual string?						ActivationKey  {get; set;}

        /// <summary>
        ///Activation of named account resource activations. These are separate from
        ///Application activations which are 
        /// </summary>

	public virtual List<ActivationEntry>?					Entries  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Activation(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ActivationKey", new PropertyString ("ActivationKey", 
					(IBinding data, string? value) => {(data as Activation).ActivationKey = value;}, (IBinding data) => (data as Activation).ActivationKey )},
			{ "Entries", new PropertyListStruct ("Entries", 
					(IBinding data, object? value) => {(data as Activation).Entries = value as List<ActivationEntry>;}, (IBinding data) => (data as Activation).Entries,
					false, ()=>new  List<ActivationEntry>(), ()=>new ActivationEntry())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Activation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Activation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Activation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Activation;
			}
		var Result = new Activation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationEntry : MeshItem {
        /// <summary>
        ///Name of the activated resource
        /// </summary>

	public virtual string?						Resource  {get; set;}

        /// <summary>
        ///The activation key or key share
        /// </summary>

	public virtual KeyData?						Key  {get; set;}

        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial capability.]
        /// </summary>

	public virtual string?						ServiceId  {get; set;}

        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial capability.]
        /// </summary>

	public virtual string?						ServiceAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationEntry(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Resource", new PropertyString ("Resource", 
					(IBinding data, string? value) => {(data as ActivationEntry).Resource = value;}, (IBinding data) => (data as ActivationEntry).Resource )},
			{ "Key", new PropertyStruct ("Key", 
					(IBinding data, object? value) => {(data as ActivationEntry).Key = value as KeyData;}, (IBinding data) => (data as ActivationEntry).Key,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "ServiceId", new PropertyString ("ServiceId", 
					(IBinding data, string? value) => {(data as ActivationEntry).ServiceId = value;}, (IBinding data) => (data as ActivationEntry).ServiceId )},
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as ActivationEntry).ServiceAddress = value;}, (IBinding data) => (data as ActivationEntry).ServiceAddress )}
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
	public new const string __Tag = "ActivationEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationEntry();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationEntry;
			}
		var Result = new ActivationEntry ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Parent class from which all profile classes are derived
	/// </summary>
abstract public partial class Profile : Assertion {
        /// <summary>
        ///Description of the profile
        /// </summary>

	public virtual string?						Description  {get; set;}

        /// <summary>
        ///The permanent signature key used to sign the profile itself. The UDF of
        ///the key is used as the permanent object identifier of the profile. Thus,
        ///by definition, the KeySignature value of a Profile does not change under
        ///any circumstance.
        /// </summary>

	public virtual KeyData?						ProfileSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Description", new PropertyString ("Description", 
					(IBinding data, string? value) => {(data as Profile).Description = value;}, (IBinding data) => (data as Profile).Description )},
			{ "ProfileSignature", new PropertyStruct ("ProfileSignature", 
					(IBinding data, object? value) => {(data as Profile).ProfileSignature = value as KeyData;}, (IBinding data) => (data as Profile).ProfileSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Profile";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Profile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Profile;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Describes a mesh device.
	/// </summary>
public partial class ProfileDevice : Profile {
        /// <summary>
        ///Base key contribution for encryption keys. 
        ///Also used to decrypt activation data sent to the device
        ///during connection to an account.
        /// </summary>

	public virtual KeyData?						Encryption  {get; set;}

        /// <summary>
        ///Base key contribution for signature keys. 
        /// </summary>

	public virtual KeyData?						Signature  {get; set;}

        /// <summary>
        ///Base key contribution for authentication keys. 
        ///Also used to authenticate the device
        ///during connection to an account.
        /// </summary>

	public virtual KeyData?						Authentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileDevice(), Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Encryption", new PropertyStruct ("Encryption", 
					(IBinding data, object? value) => {(data as ProfileDevice).Encryption = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Signature", new PropertyStruct ("Signature", 
					(IBinding data, object? value) => {(data as ProfileDevice).Signature = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Authentication", new PropertyStruct ("Authentication", 
					(IBinding data, object? value) => {(data as ProfileDevice).Authentication = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Profile._StaticAllProperties);


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
	public new const string __Tag = "ProfileDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileDevice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileDevice;
			}
		var Result = new ProfileDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for the account profiles ProfileUser and ProfileGroup.
	/// These subclasses may be merged at some future date.
	/// </summary>
public partial class ProfileAccount : Profile {
        /// <summary>
        ///The account address. This is either a DNS service address 
        ///(e.g. alice@example.com) or a Mesh Name (@alice).
        /// </summary>

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        ///The fingerprint of the service profile to which the account is
        ///currently bound.
        /// </summary>

	public virtual string?						ServiceUdf  {get; set;}

        /// <summary>
        ///Escrow key associated with the account.
        /// </summary>

	public virtual KeyData?						EscrowEncryption  {get; set;}

        /// <summary>
        ///Key used to sign connection assertions to the account.
        /// </summary>

	public virtual KeyData?						AdministratorSignature  {get; set;}

        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	public virtual KeyData?						CommonEncryption  {get; set;}

        /// <summary>
        ///Key used to authenticate requests made under this user account.
        ///This key SHOULD NOT be provisioned to any device except for the
        ///purpose of enabling account recovery.
        /// </summary>

	public virtual KeyData?						CommonAuthentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileAccount(), Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as ProfileAccount).AccountAddress = value;}, (IBinding data) => (data as ProfileAccount).AccountAddress )},
			{ "ServiceUdf", new PropertyString ("ServiceUdf", 
					(IBinding data, string? value) => {(data as ProfileAccount).ServiceUdf = value;}, (IBinding data) => (data as ProfileAccount).ServiceUdf )},
			{ "EscrowEncryption", new PropertyStruct ("EscrowEncryption", 
					(IBinding data, object? value) => {(data as ProfileAccount).EscrowEncryption = value as KeyData;}, (IBinding data) => (data as ProfileAccount).EscrowEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", 
					(IBinding data, object? value) => {(data as ProfileAccount).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ProfileAccount).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "CommonEncryption", new PropertyStruct ("CommonEncryption", 
					(IBinding data, object? value) => {(data as ProfileAccount).CommonEncryption = value as KeyData;}, (IBinding data) => (data as ProfileAccount).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "CommonAuthentication", new PropertyStruct ("CommonAuthentication", 
					(IBinding data, object? value) => {(data as ProfileAccount).CommonAuthentication = value as KeyData;}, (IBinding data) => (data as ProfileAccount).CommonAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Profile._StaticAllProperties);


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
	public new const string __Tag = "ProfileAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileAccount();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileAccount;
			}
		var Result = new ProfileAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Account assertion. This is signed by the service hosting the account.
	/// </summary>
public partial class ProfileUser : ProfileAccount {
        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

	public virtual KeyData?						CommonSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileUser(), ProfileAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonSignature", new PropertyStruct ("CommonSignature", 
					(IBinding data, object? value) => {(data as ProfileUser).CommonSignature = value as KeyData;}, (IBinding data) => (data as ProfileUser).CommonSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileAccount._StaticAllProperties);


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
	public new const string __Tag = "ProfileUser";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileUser();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileUser FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileUser;
			}
		var Result = new ProfileUser ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes a group. Note that while a group is created by one person who
	/// becomes its first administrator, control of the group may pass to other
	/// administrators over time.
	/// </summary>
public partial class ProfileGroup : ProfileAccount {
        /// <summary>
        ///HTML document containing cover text to be presented if a document 
        ///encrypted under the group key cannot be decrypted.
        /// </summary>

	public virtual byte[]?						Cover  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileGroup(), ProfileAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Cover", new PropertyBinary ("Cover", 
					(IBinding data, byte[]? value) => {(data as ProfileGroup).Cover = value;}, (IBinding data) => (data as ProfileGroup).Cover )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileAccount._StaticAllProperties);


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
	public new const string __Tag = "ProfileGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileGroup;
			}
		var Result = new ProfileGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Profile of a Mesh Service
	/// </summary>
public partial class ProfileService : Profile {
        /// <summary>
        ///Key used to authenticate service connections.
        /// </summary>

	public virtual KeyData?						ServiceAuthentication  {get; set;}

        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

	public virtual KeyData?						ServiceEncryption  {get; set;}

        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

	public virtual KeyData?						ServiceSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileService(), Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ServiceAuthentication", new PropertyStruct ("ServiceAuthentication", 
					(IBinding data, object? value) => {(data as ProfileService).ServiceAuthentication = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "ServiceEncryption", new PropertyStruct ("ServiceEncryption", 
					(IBinding data, object? value) => {(data as ProfileService).ServiceEncryption = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "ServiceSignature", new PropertyStruct ("ServiceSignature", 
					(IBinding data, object? value) => {(data as ProfileService).ServiceSignature = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Profile._StaticAllProperties);


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
	public new const string __Tag = "ProfileService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileService;
			}
		var Result = new ProfileService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Profile of a Mesh Service
	/// </summary>
public partial class ProfileMeshService : ProfileService {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileMeshService(), ProfileService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileService._StaticAllProperties);


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
	public new const string __Tag = "ProfileMeshService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileMeshService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileMeshService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileMeshService;
			}
		var Result = new ProfileMeshService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Profile of a Mesh Host providing one or more Mesh Services.
	/// </summary>
public partial class ProfileHost : ProfileDevice {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProfileHost(), ProfileDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProfileDevice._StaticAllProperties);


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
	public new const string __Tag = "ProfileHost";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProfileHost();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProfileHost FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProfileHost;
			}
		var Result = new ProfileHost ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Connection : Assertion {
        /// <summary>
        ///UDF of the connection target.
        /// </summary>

	public virtual string?						Subject  {get; set;}

        /// <summary>
        ///UDF of the connection source.
        /// </summary>

	public virtual string?						Authority  {get; set;}

        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

	public virtual KeyData?						Authentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Connection(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Subject", new PropertyString ("Subject", 
					(IBinding data, string? value) => {(data as Connection).Subject = value;}, (IBinding data) => (data as Connection).Subject )},
			{ "Authority", new PropertyString ("Authority", 
					(IBinding data, string? value) => {(data as Connection).Authority = value;}, (IBinding data) => (data as Connection).Authority )},
			{ "Authentication", new PropertyStruct ("Authentication", 
					(IBinding data, object? value) => {(data as Connection).Authentication = value as KeyData;}, (IBinding data) => (data as Connection).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Connection";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Connection();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Connection FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Connection;
			}
		var Result = new Connection ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CallsignBinding : Assertion {
        /// <summary>
        ///The canonical form of the callsign.
        /// </summary>

	public virtual string?						Canonical  {get; set;}

        /// <summary>
        ///The display form of the callsign. This MAY include characters such as whitespace,
        ///trademark signifiers, etc. that are omitted of trranslated in the canonical form.
        /// </summary>

	public virtual string?						Display  {get; set;}

        /// <summary>
        ///Specifies the page to which the Description"CharacterPageLatin"
        /// </summary>

	public virtual string?						CharacterPage  {get; set;}

        /// <summary>
        ///The profile to which the name is bound.
        /// </summary>

	public virtual string?						ProfileUdf  {get; set;}

        /// <summary>
        ///The profile to which the name has been transfered.
        /// </summary>

	public virtual string?						TransferUdf  {get; set;}

        /// <summary>
        ///List of named services. If multiple service providers are specified for a given 
        ///service, these are listed in order of priority, most preferred first.
        /// </summary>

	public virtual List<NamedService>?					Services  {get; set;}
        /// <summary>
        ///The Mesh service address. 
        /// </summary>

	public virtual string?						ServiceAddress  {get; set;}

        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	public virtual KeyData?						CommonEncryption  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CallsignBinding(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Canonical", new PropertyString ("Canonical", 
					(IBinding data, string? value) => {(data as CallsignBinding).Canonical = value;}, (IBinding data) => (data as CallsignBinding).Canonical )},
			{ "Display", new PropertyString ("Display", 
					(IBinding data, string? value) => {(data as CallsignBinding).Display = value;}, (IBinding data) => (data as CallsignBinding).Display )},
			{ "CharacterPage", new PropertyString ("CharacterPage", 
					(IBinding data, string? value) => {(data as CallsignBinding).CharacterPage = value;}, (IBinding data) => (data as CallsignBinding).CharacterPage )},
			{ "ProfileUdf", new PropertyString ("ProfileUdf", 
					(IBinding data, string? value) => {(data as CallsignBinding).ProfileUdf = value;}, (IBinding data) => (data as CallsignBinding).ProfileUdf )},
			{ "TransferUdf", new PropertyString ("TransferUdf", 
					(IBinding data, string? value) => {(data as CallsignBinding).TransferUdf = value;}, (IBinding data) => (data as CallsignBinding).TransferUdf )},
			{ "Services", new PropertyListStruct ("Services", 
					(IBinding data, object? value) => {(data as CallsignBinding).Services = value as List<NamedService>;}, (IBinding data) => (data as CallsignBinding).Services,
					false, ()=>new  List<NamedService>(), ()=>new NamedService())} ,
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as CallsignBinding).ServiceAddress = value;}, (IBinding data) => (data as CallsignBinding).ServiceAddress )},
			{ "CommonEncryption", new PropertyStruct ("CommonEncryption", 
					(IBinding data, object? value) => {(data as CallsignBinding).CommonEncryption = value as KeyData;}, (IBinding data) => (data as CallsignBinding).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "CallsignBinding";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CallsignBinding();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CallsignBinding FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CallsignBinding;
			}
		var Result = new CallsignBinding ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Registration of a trusted third party accreditation of a callsign/profile binding.
	/// </summary>
public partial class Accreditation : Assertion {
        /// <summary>
        ///The callsign to which the accreditation applies
        /// </summary>

	public virtual string?						Callsign  {get; set;}

        /// <summary>
        ///The profile to which the accreditation applies.
        /// </summary>

	public virtual string?						ProfileUdf  {get; set;}

        /// <summary>
        ///The validated names of the subject
        /// </summary>

	public virtual List<string>?					SubjectNames  {get; set;}
        /// <summary>
        ///Mesh strong URIs from which a validated logo belonging to the 
        ///subject MAY be retreived and validated.
        /// </summary>

	public virtual List<string>?					SubjectLogos  {get; set;}
        /// <summary>
        ///The time the assertion was issued.
        /// </summary>

	public virtual DateTime?						Issued  {get; set;}

        /// <summary>
        ///The time the assertion is due to expire
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}

        /// <summary>
        ///The issuing policy under which the validation was performed.
        /// </summary>

	public virtual string?						Policy  {get; set;}

        /// <summary>
        ///The issuing practices under which the validation was performed.
        /// </summary>

	public virtual string?						Practice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Accreditation(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Callsign", new PropertyString ("Callsign", 
					(IBinding data, string? value) => {(data as Accreditation).Callsign = value;}, (IBinding data) => (data as Accreditation).Callsign )},
			{ "ProfileUdf", new PropertyString ("ProfileUdf", 
					(IBinding data, string? value) => {(data as Accreditation).ProfileUdf = value;}, (IBinding data) => (data as Accreditation).ProfileUdf )},
			{ "SubjectNames", new PropertyListString ("SubjectNames", 
					(IBinding data, List<string>? value) => {(data as Accreditation).SubjectNames = value;}, (IBinding data) => (data as Accreditation).SubjectNames )},
			{ "SubjectLogos", new PropertyListString ("SubjectLogos", 
					(IBinding data, List<string>? value) => {(data as Accreditation).SubjectLogos = value;}, (IBinding data) => (data as Accreditation).SubjectLogos )},
			{ "Issued", new PropertyDateTime ("Issued", 
					(IBinding data, DateTime? value) => {(data as Accreditation).Issued = value;}, (IBinding data) => (data as Accreditation).Issued )},
			{ "Expires", new PropertyDateTime ("Expires", 
					(IBinding data, DateTime? value) => {(data as Accreditation).Expires = value;}, (IBinding data) => (data as Accreditation).Expires )},
			{ "Policy", new PropertyString ("Policy", 
					(IBinding data, string? value) => {(data as Accreditation).Policy = value;}, (IBinding data) => (data as Accreditation).Policy )},
			{ "Practice", new PropertyString ("Practice", 
					(IBinding data, string? value) => {(data as Accreditation).Practice = value;}, (IBinding data) => (data as Accreditation).Practice )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Accreditation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Accreditation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Accreditation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Accreditation;
			}
		var Result = new Accreditation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Asserts that a profile is connected to an account address.
	/// Stripped down connection assertion
	/// </summary>
public partial class ConnectionStripped : Connection {
        /// <summary>
        ///To be removed
        /// </summary>

	public virtual string?						Account  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionStripped(), Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new PropertyString ("Account", 
					(IBinding data, string? value) => {(data as ConnectionStripped).Account = value;}, (IBinding data) => (data as ConnectionStripped).Account )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Connection._StaticAllProperties);


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
	public new const string __Tag = "ConnectionStripped";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionStripped();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionStripped FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionStripped;
			}
		var Result = new ConnectionStripped ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Asserts that a device is connected to an account profile
	/// </summary>
public partial class ConnectionService : Connection {
        /// <summary>
        ///The account address
        /// </summary>

	public virtual string?						ProfileUdf  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionService(), Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileUdf", new PropertyString ("ProfileUdf", 
					(IBinding data, string? value) => {(data as ConnectionService).ProfileUdf = value;}, (IBinding data) => (data as ConnectionService).ProfileUdf )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Connection._StaticAllProperties);


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
	public new const string __Tag = "ConnectionService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionService;
			}
		var Result = new ConnectionService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Asserts that a device is connected to an account profile
	/// </summary>
public partial class ConnectionDevice : ConnectionService {
        /// <summary>
        /// </summary>

	public virtual List<string>?					Roles  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

	public virtual KeyData?						Signature  {get; set;}

        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

	public virtual KeyData?						Encryption  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionDevice(), ConnectionService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Roles", new PropertyListString ("Roles", 
					(IBinding data, List<string>? value) => {(data as ConnectionDevice).Roles = value;}, (IBinding data) => (data as ConnectionDevice).Roles )},
			{ "Signature", new PropertyStruct ("Signature", 
					(IBinding data, object? value) => {(data as ConnectionDevice).Signature = value as KeyData;}, (IBinding data) => (data as ConnectionDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Encryption", new PropertyStruct ("Encryption", 
					(IBinding data, object? value) => {(data as ConnectionDevice).Encryption = value as KeyData;}, (IBinding data) => (data as ConnectionDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ConnectionService._StaticAllProperties);


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
	public new const string __Tag = "ConnectionDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionDevice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionDevice;
			}
		var Result = new ConnectionDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Connection assertion stating that a particular device is 
	/// </summary>
public partial class ConnectionApplication : Connection {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionApplication(), Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Connection._StaticAllProperties);


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
	public new const string __Tag = "ConnectionApplication";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionApplication();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionApplication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionApplication;
			}
		var Result = new ConnectionApplication ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Describes the connection of a member to a group.
	/// </summary>
public partial class ConnectionGroup : Connection {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionGroup(), Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Connection._StaticAllProperties);


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
	public new const string __Tag = "ConnectionGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionGroup;
			}
		var Result = new ConnectionGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class AccountHostAssignment : Assertion {
        /// <summary>
        ///The account being bound
        /// </summary>

	public virtual string?						AccountAddess  {get; set;}

        /// <summary>
        ///Host address in Callsign, DNS or IP format in order of preference.
        /// </summary>

	public virtual List<string>?					HostAddresses  {get; set;}
        /// <summary>
        ///Encryption key to be used to encrypt data for the service to use.
        /// </summary>

	public virtual KeyData?						AccessEncrypt  {get; set;}

        /// <summary>
        ///Profile of the callsign registry used by the service.
        /// </summary>

	public virtual ProfileAccount?						CallsignServiceProfile  {get; set;}

        /// <summary>
        ///Profile of the service.
        /// </summary>

	public virtual Enveloped<ProfileService>?						EnvelopedProfileService  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new AccountHostAssignment(), Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddess", new PropertyString ("AccountAddess", 
					(IBinding data, string? value) => {(data as AccountHostAssignment).AccountAddess = value;}, (IBinding data) => (data as AccountHostAssignment).AccountAddess )},
			{ "HostAddresses", new PropertyListString ("HostAddresses", 
					(IBinding data, List<string>? value) => {(data as AccountHostAssignment).HostAddresses = value;}, (IBinding data) => (data as AccountHostAssignment).HostAddresses )},
			{ "AccessEncrypt", new PropertyStruct ("AccessEncrypt", 
					(IBinding data, object? value) => {(data as AccountHostAssignment).AccessEncrypt = value as KeyData;}, (IBinding data) => (data as AccountHostAssignment).AccessEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "CallsignServiceProfile", new PropertyStruct ("CallsignServiceProfile", 
					(IBinding data, object? value) => {(data as AccountHostAssignment).CallsignServiceProfile = value as ProfileAccount;}, (IBinding data) => (data as AccountHostAssignment).CallsignServiceProfile,
					false, ()=>new  ProfileAccount(), ()=>new ProfileAccount())} ,
			{ "EnvelopedProfileService", new PropertyStruct ("EnvelopedProfileService", 
					(IBinding data, object? value) => {(data as AccountHostAssignment).EnvelopedProfileService = value as Enveloped<ProfileService>;}, (IBinding data) => (data as AccountHostAssignment).EnvelopedProfileService,
					false, ()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "AccountHostAssignment";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AccountHostAssignment();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AccountHostAssignment FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AccountHostAssignment;
			}
		var Result = new AccountHostAssignment ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ConnectionHost : Connection {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ConnectionHost(), Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Connection._StaticAllProperties);


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
	public new const string __Tag = "ConnectionHost";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ConnectionHost();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ConnectionHost FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ConnectionHost;
			}
		var Result = new ConnectionHost ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Contains activation data for device specific keys used in the context of a 
	/// Mesh account.
	/// </summary>
public partial class ActivationAccount : Activation {
        /// <summary>
        ///The UDF of the account
        /// </summary>

	public virtual string?						AccountUdf  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationAccount(), Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountUdf", new PropertyString ("AccountUdf", 
					(IBinding data, string? value) => {(data as ActivationAccount).AccountUdf = value;}, (IBinding data) => (data as ActivationAccount).AccountUdf )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Activation._StaticAllProperties);


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
	public new const string __Tag = "ActivationAccount";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationAccount();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationAccount FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationAccount;
			}
		var Result = new ActivationAccount ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Contains activation data for device specific keys used in the context of a 
	/// Mesh host
	/// </summary>
public partial class ActivationHost : ActivationAccount {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationHost(), ActivationAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ActivationAccount._StaticAllProperties);


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
	public new const string __Tag = "ActivationHost";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationHost();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationHost FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationHost;
			}
		var Result = new ActivationHost ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationCommon : Activation {
        /// <summary>
        ///Grant access to profile online signing key used to sign updates
        ///to the profile.
        /// </summary>

	public virtual KeyData?						ProfileSignature  {get; set;}

        /// <summary>
        ///Grant access to Profile administration key used to make changes to
        ///administrator catalogs.
        /// </summary>

	public virtual KeyData?						AdministratorSignature  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account encryption key
        /// </summary>

	public virtual KeyData?						Encryption  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account authentication key
        /// </summary>

	public virtual KeyData?						Authentication  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account signature key
        /// </summary>

	public virtual KeyData?						Signature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationCommon(), Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileSignature", new PropertyStruct ("ProfileSignature", 
					(IBinding data, object? value) => {(data as ActivationCommon).ProfileSignature = value as KeyData;}, (IBinding data) => (data as ActivationCommon).ProfileSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", 
					(IBinding data, object? value) => {(data as ActivationCommon).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ActivationCommon).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Encryption", new PropertyStruct ("Encryption", 
					(IBinding data, object? value) => {(data as ActivationCommon).Encryption = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Authentication", new PropertyStruct ("Authentication", 
					(IBinding data, object? value) => {(data as ActivationCommon).Authentication = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "Signature", new PropertyStruct ("Signature", 
					(IBinding data, object? value) => {(data as ActivationCommon).Signature = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Activation._StaticAllProperties);


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
	public new const string __Tag = "ActivationCommon";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationCommon();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationCommon FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationCommon;
			}
		var Result = new ActivationCommon ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationApplication : Activation {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationApplication(), Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Activation._StaticAllProperties);


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
	public new const string __Tag = "ActivationApplication";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplication();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplication;
			}
		var Result = new ActivationApplication ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationApplicationSsh : ActivationApplication {
        /// <summary>
        ///The SSH client key.
        /// </summary>

	public virtual KeyData?						ClientKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationApplicationSsh(), ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ClientKey", new PropertyStruct ("ClientKey", 
					(IBinding data, object? value) => {(data as ActivationApplicationSsh).ClientKey = value as KeyData;}, (IBinding data) => (data as ActivationApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ActivationApplication._StaticAllProperties);


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
	public new const string __Tag = "ActivationApplicationSsh";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationSsh();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationSsh FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationSsh;
			}
		var Result = new ActivationApplicationSsh ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationApplicationMail : ActivationApplication {
        /// <summary>
        ///The S/Mime signature key
        /// </summary>

	public virtual KeyData?						SmimeSign  {get; set;}

        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData?						SmimeEncrypt  {get; set;}

        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	public virtual KeyData?						OpenpgpSign  {get; set;}

        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	public virtual KeyData?						OpenpgpEncrypt  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationApplicationMail(), ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "SmimeSign", new PropertyStruct ("SmimeSign", 
					(IBinding data, object? value) => {(data as ActivationApplicationMail).SmimeSign = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "SmimeEncrypt", new PropertyStruct ("SmimeEncrypt", 
					(IBinding data, object? value) => {(data as ActivationApplicationMail).SmimeEncrypt = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "OpenpgpSign", new PropertyStruct ("OpenpgpSign", 
					(IBinding data, object? value) => {(data as ActivationApplicationMail).OpenpgpSign = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "OpenpgpEncrypt", new PropertyStruct ("OpenpgpEncrypt", 
					(IBinding data, object? value) => {(data as ActivationApplicationMail).OpenpgpEncrypt = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ActivationApplication._StaticAllProperties);


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
	public new const string __Tag = "ActivationApplicationMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationMail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationMail;
			}
		var Result = new ActivationApplicationMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ActivationApplicationGroup : ActivationApplication {
        /// <summary>
        ///Key or capability allowing account encryption keys to be created 
        ///for new members.
        /// </summary>

	public virtual KeyData?						AccountEncryption  {get; set;}

        /// <summary>
        ///Key or capability allowing account updates, connection assertions
        ///etc to be signed.
        /// </summary>

	public virtual KeyData?						AdministratorSignature  {get; set;}

        /// <summary>
        ///Key or capability allowing administration of the group.
        /// </summary>

	public virtual KeyData?						AccountAuthentication  {get; set;}

        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ActivationApplicationGroup(), ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountEncryption", new PropertyStruct ("AccountEncryption", 
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AccountEncryption = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", 
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "AccountAuthentication", new PropertyStruct ("AccountAuthentication", 
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AccountAuthentication = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AccountAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as ActivationApplicationGroup).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ActivationApplication._StaticAllProperties);


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
	public new const string __Tag = "ActivationApplicationGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationGroup;
			}
		var Result = new ActivationApplicationGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class ApplicationEntry : MeshItem {
        /// <summary>
        /// </summary>

	public virtual string?						Identifier  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as ApplicationEntry).Identifier = value;}, (IBinding data) => (data as ApplicationEntry).Identifier )}
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
	public new const string __Tag = "ApplicationEntry";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntry;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	/// </summary>
public partial class ApplicationEntrySsh : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationSsh>?						EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ApplicationEntrySsh(), ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", 
					(IBinding data, object? value) => {(data as ApplicationEntrySsh).EnvelopedActivation = value as Enveloped<ActivationApplicationSsh>;}, (IBinding data) => (data as ApplicationEntrySsh).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationSsh>(), ()=>new Enveloped<ActivationApplicationSsh>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ApplicationEntry._StaticAllProperties);


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
	public new const string __Tag = "ApplicationEntrySsh";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntrySsh();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntrySsh FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntrySsh;
			}
		var Result = new ApplicationEntrySsh ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ApplicationEntryGroup : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationGroup>?						EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ApplicationEntryGroup(), ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", 
					(IBinding data, object? value) => {(data as ApplicationEntryGroup).EnvelopedActivation = value as Enveloped<ActivationApplicationGroup>;}, (IBinding data) => (data as ApplicationEntryGroup).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationGroup>(), ()=>new Enveloped<ActivationApplicationGroup>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ApplicationEntry._StaticAllProperties);


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
	public new const string __Tag = "ApplicationEntryGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryGroup;
			}
		var Result = new ApplicationEntryGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ApplicationEntryMail : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationMail>?						EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ApplicationEntryMail(), ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", 
					(IBinding data, object? value) => {(data as ApplicationEntryMail).EnvelopedActivation = value as Enveloped<ActivationApplicationMail>;}, (IBinding data) => (data as ApplicationEntryMail).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationMail>(), ()=>new Enveloped<ActivationApplicationMail>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ApplicationEntry._StaticAllProperties);


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
	public new const string __Tag = "ApplicationEntryMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryMail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryMail;
			}
		var Result = new ApplicationEntryMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for contact entries.
	/// </summary>
abstract public partial class Contact : Assertion {
        /// <summary>
        ///The globally unique contact identifier.
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The local name.
        /// </summary>

	public virtual string?						Local  {get; set;}

        /// <summary>
        ///Mesh fingerprints associated with the contact.
        /// </summary>

	public virtual List<Anchor>?					Anchors  {get; set;}
        /// <summary>
        ///Network address entries
        /// </summary>

	public virtual List<NetworkAddress>?					NetworkAddresses  {get; set;}
        /// <summary>
        ///The physical locations the contact is associated with.
        /// </summary>

	public virtual List<Location>?					Locations  {get; set;}
        /// <summary>
        ///The roles of the contact
        /// </summary>

	public virtual List<Role>?					Roles  {get; set;}
        /// <summary>
        ///The Web sites and other online presences of the contact
        /// </summary>

	public virtual List<Bookmark>?					Bookmark  {get; set;}
        /// <summary>
        ///Source(s) from which this contact was constructed.
        /// </summary>

	public virtual List<TaggedSource>?					Sources  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Contact).Id = value;}, (IBinding data) => (data as Contact).Id )},
			{ "Local", new PropertyString ("Local", 
					(IBinding data, string? value) => {(data as Contact).Local = value;}, (IBinding data) => (data as Contact).Local )},
			{ "Anchors", new PropertyListStruct ("Anchors", 
					(IBinding data, object? value) => {(data as Contact).Anchors = value as List<Anchor>;}, (IBinding data) => (data as Contact).Anchors,
					false, ()=>new  List<Anchor>(), ()=>new Anchor())} ,
			{ "NetworkAddresses", new PropertyListStruct ("NetworkAddresses", 
					(IBinding data, object? value) => {(data as Contact).NetworkAddresses = value as List<NetworkAddress>;}, (IBinding data) => (data as Contact).NetworkAddresses,
					true, ()=>new List<NetworkAddress>()
)} ,
			{ "Locations", new PropertyListStruct ("Locations", 
					(IBinding data, object? value) => {(data as Contact).Locations = value as List<Location>;}, (IBinding data) => (data as Contact).Locations,
					false, ()=>new  List<Location>(), ()=>new Location())} ,
			{ "Roles", new PropertyListStruct ("Roles", 
					(IBinding data, object? value) => {(data as Contact).Roles = value as List<Role>;}, (IBinding data) => (data as Contact).Roles,
					false, ()=>new  List<Role>(), ()=>new Role())} ,
			{ "Bookmark", new PropertyListStruct ("Bookmark", 
					(IBinding data, object? value) => {(data as Contact).Bookmark = value as List<Bookmark>;}, (IBinding data) => (data as Contact).Bookmark,
					false, ()=>new  List<Bookmark>(), ()=>new Bookmark())} ,
			{ "Sources", new PropertyListStruct ("Sources", 
					(IBinding data, object? value) => {(data as Contact).Sources = value as List<TaggedSource>;}, (IBinding data) => (data as Contact).Sources,
					false, ()=>new  List<TaggedSource>(), ()=>new TaggedSource())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Assertion._StaticAllProperties);


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
	public new const string __Tag = "Contact";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Contact FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Contact;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Trust anchor
	/// </summary>
public partial class Anchor : MeshItem {
        /// <summary>
        ///The trust anchor.
        /// </summary>

	public virtual string?						Udf  {get; set;}

        /// <summary>
        ///The means of validation.
        /// </summary>

	public virtual string?						Validation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Anchor(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as Anchor).Udf = value;}, (IBinding data) => (data as Anchor).Udf )},
			{ "Validation", new PropertyString ("Validation", 
					(IBinding data, string? value) => {(data as Anchor).Validation = value;}, (IBinding data) => (data as Anchor).Validation )}
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
	public new const string __Tag = "Anchor";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Anchor();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Anchor FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Anchor;
			}
		var Result = new Anchor ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Source from which contact information was obtained.
	/// </summary>
public partial class TaggedSource : MeshItem {
        /// <summary>
        ///Short name for the contact information.
        /// </summary>

	public virtual string?						LocalName  {get; set;}

        /// <summary>
        ///The means of validation.		
        /// </summary>

	public virtual string?						Validation  {get; set;}

        /// <summary>
        ///The contact data in binary form.
        /// </summary>

	public virtual byte[]?						BinarySource  {get; set;}

        /// <summary>
        ///The contact data in enveloped form. If present, the BinarySource property
        ///is ignored.
        /// </summary>

	public virtual Enveloped<Contact>?						EnvelopedSource  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new TaggedSource(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "LocalName", new PropertyString ("LocalName", 
					(IBinding data, string? value) => {(data as TaggedSource).LocalName = value;}, (IBinding data) => (data as TaggedSource).LocalName )},
			{ "Validation", new PropertyString ("Validation", 
					(IBinding data, string? value) => {(data as TaggedSource).Validation = value;}, (IBinding data) => (data as TaggedSource).Validation )},
			{ "BinarySource", new PropertyBinary ("BinarySource", 
					(IBinding data, byte[]? value) => {(data as TaggedSource).BinarySource = value;}, (IBinding data) => (data as TaggedSource).BinarySource )},
			{ "EnvelopedSource", new PropertyStruct ("EnvelopedSource", 
					(IBinding data, object? value) => {(data as TaggedSource).EnvelopedSource = value as Enveloped<Contact>;}, (IBinding data) => (data as TaggedSource).EnvelopedSource,
					false, ()=>new  Enveloped<Contact>(), ()=>new Enveloped<Contact>())} 
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
	public new const string __Tag = "TaggedSource";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TaggedSource();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new TaggedSource FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as TaggedSource;
			}
		var Result = new TaggedSource ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Contact for a group, including encryption groups.
	/// </summary>
public partial class ContactGroup : Contact {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ContactGroup(), Contact._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Contact._StaticAllProperties);


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
	public new const string __Tag = "ContactGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContactGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContactGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContactGroup;
			}
		var Result = new ContactGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class ContactPerson : Contact {
        /// <summary>
        ///List of person names in order of preference
        /// </summary>

	public virtual List<PersonName>?					CommonNames  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ContactPerson(), Contact._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonNames", new PropertyListStruct ("CommonNames", 
					(IBinding data, object? value) => {(data as ContactPerson).CommonNames = value as List<PersonName>;}, (IBinding data) => (data as ContactPerson).CommonNames,
					false, ()=>new  List<PersonName>(), ()=>new PersonName())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Contact._StaticAllProperties);


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
	public new const string __Tag = "ContactPerson";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContactPerson();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContactPerson FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContactPerson;
			}
		var Result = new ContactPerson ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 		
	/// </summary>
public partial class ContactOrganization : Contact {
        /// <summary>
        ///List of person names in order of preference
        /// </summary>

	public virtual List<OrganizationName>?					CommonNames  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ContactOrganization(), Contact._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonNames", new PropertyListStruct ("CommonNames", 
					(IBinding data, object? value) => {(data as ContactOrganization).CommonNames = value as List<OrganizationName>;}, (IBinding data) => (data as ContactOrganization).CommonNames,
					false, ()=>new  List<OrganizationName>(), ()=>new OrganizationName())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Contact._StaticAllProperties);


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
	public new const string __Tag = "ContactOrganization";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ContactOrganization();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ContactOrganization FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ContactOrganization;
			}
		var Result = new ContactOrganization ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The name of an organization
	/// </summary>
public partial class OrganizationName : MeshItem {
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

	public virtual bool?						Inactive  {get; set;}

        /// <summary>
        ///The registered name.
        /// </summary>

	public virtual string?						RegisteredName  {get; set;}

        /// <summary>
        ///Names that the organization uses including trading names
        ///and doing business as names.
        /// </summary>

	public virtual string?						DBA  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new OrganizationName(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new PropertyBoolean ("Inactive", 
					(IBinding data, bool? value) => {(data as OrganizationName).Inactive = value;}, (IBinding data) => (data as OrganizationName).Inactive )},
			{ "RegisteredName", new PropertyString ("RegisteredName", 
					(IBinding data, string? value) => {(data as OrganizationName).RegisteredName = value;}, (IBinding data) => (data as OrganizationName).RegisteredName )},
			{ "DBA", new PropertyString ("DBA", 
					(IBinding data, string? value) => {(data as OrganizationName).DBA = value;}, (IBinding data) => (data as OrganizationName).DBA )}
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
	public new const string __Tag = "OrganizationName";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new OrganizationName();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new OrganizationName FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as OrganizationName;
			}
		var Result = new OrganizationName ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The name of a natural person
	/// </summary>
public partial class PersonName : MeshItem {
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

	public virtual bool?						Inactive  {get; set;}

        /// <summary>
        ///The preferred presentation of the full name.
        /// </summary>

	public virtual string?						FullName  {get; set;}

        /// <summary>
        ///Honorific or title, E.g. Sir, Lord, Dr., Mr.
        /// </summary>

	public virtual string?						Prefix  {get; set;}

        /// <summary>
        ///First name.
        /// </summary>

	public virtual string?						First  {get; set;}

        /// <summary>
        ///Middle names or initials.
        /// </summary>

	public virtual List<string>?					Middle  {get; set;}
        /// <summary>
        ///Last name.
        /// </summary>

	public virtual string?						Last  {get; set;}

        /// <summary>
        ///Nominal suffix, e.g. Jr., III, etc.
        /// </summary>

	public virtual string?						Suffix  {get; set;}

        /// <summary>
        ///Post nominal letters (if used).
        /// </summary>

	public virtual string?						PostNominal  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PersonName(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new PropertyBoolean ("Inactive", 
					(IBinding data, bool? value) => {(data as PersonName).Inactive = value;}, (IBinding data) => (data as PersonName).Inactive )},
			{ "FullName", new PropertyString ("FullName", 
					(IBinding data, string? value) => {(data as PersonName).FullName = value;}, (IBinding data) => (data as PersonName).FullName )},
			{ "Prefix", new PropertyString ("Prefix", 
					(IBinding data, string? value) => {(data as PersonName).Prefix = value;}, (IBinding data) => (data as PersonName).Prefix )},
			{ "First", new PropertyString ("First", 
					(IBinding data, string? value) => {(data as PersonName).First = value;}, (IBinding data) => (data as PersonName).First )},
			{ "Middle", new PropertyListString ("Middle", 
					(IBinding data, List<string>? value) => {(data as PersonName).Middle = value;}, (IBinding data) => (data as PersonName).Middle )},
			{ "Last", new PropertyString ("Last", 
					(IBinding data, string? value) => {(data as PersonName).Last = value;}, (IBinding data) => (data as PersonName).Last )},
			{ "Suffix", new PropertyString ("Suffix", 
					(IBinding data, string? value) => {(data as PersonName).Suffix = value;}, (IBinding data) => (data as PersonName).Suffix )},
			{ "PostNominal", new PropertyString ("PostNominal", 
					(IBinding data, string? value) => {(data as PersonName).PostNominal = value;}, (IBinding data) => (data as PersonName).PostNominal )}
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
	public new const string __Tag = "PersonName";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PersonName();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PersonName FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PersonName;
			}
		var Result = new PersonName ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Provides all means of contacting the individual according to a
	/// particular network address
	/// </summary>
public partial class NetworkAddress : MeshItem {
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

	public virtual bool?						Inactive  {get; set;}

        /// <summary>
        ///The network address, e.g. alice@example.com
        /// </summary>

	public virtual string?						Address  {get; set;}

        /// <summary>
        ///The IANA protocol|identifier of the network protocols by which 
        ///the contact may be reached using the specified Address. 
        /// </summary>

	public virtual string?						Protocol  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NetworkAddress(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new PropertyBoolean ("Inactive", 
					(IBinding data, bool? value) => {(data as NetworkAddress).Inactive = value;}, (IBinding data) => (data as NetworkAddress).Inactive )},
			{ "Address", new PropertyString ("Address", 
					(IBinding data, string? value) => {(data as NetworkAddress).Address = value;}, (IBinding data) => (data as NetworkAddress).Address )},
			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as NetworkAddress).Protocol = value;}, (IBinding data) => (data as NetworkAddress).Protocol )}
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
	public new const string __Tag = "NetworkAddress";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkAddress();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NetworkAddress FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NetworkAddress;
			}
		var Result = new NetworkAddress ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class NetworkCredential : NetworkAddress {
        /// <summary>
        ///The IANA credential type
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        ///The credential
        /// </summary>

	public virtual byte[]?						Credential  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NetworkCredential(), NetworkAddress._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Type", new PropertyString ("Type", 
					(IBinding data, string? value) => {(data as NetworkCredential).Type = value;}, (IBinding data) => (data as NetworkCredential).Type )},
			{ "Credential", new PropertyBinary ("Credential", 
					(IBinding data, byte[]? value) => {(data as NetworkCredential).Credential = value;}, (IBinding data) => (data as NetworkCredential).Credential )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, NetworkAddress._StaticAllProperties);


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
	public new const string __Tag = "NetworkCredential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NetworkCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NetworkCredential;
			}
		var Result = new NetworkCredential ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class NetworkProfile : NetworkAddress {
        /// <summary>
        ///The account profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileAccount  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NetworkProfile(), NetworkAddress._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileAccount", new PropertyStruct ("EnvelopedProfileAccount", 
					(IBinding data, object? value) => {(data as NetworkProfile).EnvelopedProfileAccount = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as NetworkProfile).EnvelopedProfileAccount,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, NetworkAddress._StaticAllProperties);


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
	public new const string __Tag = "NetworkProfile";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkProfile();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NetworkProfile FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NetworkProfile;
			}
		var Result = new NetworkProfile ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class NetworkCapability : NetworkProfile {
        /// <summary>
        ///Cryptographic capabilities that may be claimed from this address
        /// </summary>

	public virtual List<CryptographicCapability>?					Capabilities  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NetworkCapability(), NetworkProfile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Capabilities", new PropertyListStruct ("Capabilities", 
					(IBinding data, object? value) => {(data as NetworkCapability).Capabilities = value as List<CryptographicCapability>;}, (IBinding data) => (data as NetworkCapability).Capabilities,
					true, ()=>new List<CryptographicCapability>()
)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, NetworkProfile._StaticAllProperties);


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
	public new const string __Tag = "NetworkCapability";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkCapability();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NetworkCapability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NetworkCapability;
			}
		var Result = new NetworkCapability ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class NetworkProtocol : MeshItem {
        /// <summary>
        ///The IANA protocol|identifier of the network protocols by which 
        ///the contact may be reached using the specified Address. 
        /// </summary>

	public virtual string?						Protocol  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NetworkProtocol(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as NetworkProtocol).Protocol = value;}, (IBinding data) => (data as NetworkProtocol).Protocol )}
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
	public new const string __Tag = "NetworkProtocol";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NetworkProtocol();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NetworkProtocol FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NetworkProtocol;
			}
		var Result = new NetworkProtocol ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Role : MeshItem {
        /// <summary>
        ///The organization at which the role is held
        /// </summary>

	public virtual string?						OrganizationName  {get; set;}

        /// <summary>
        ///The titles held with respect to that organization.
        /// </summary>

	public virtual List<string>?					Titles  {get; set;}
        /// <summary>
        ///Postal or physical addresses associated with the role.
        /// </summary>

	public virtual List<Location>?					Locations  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Role(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "OrganizationName", new PropertyString ("OrganizationName", 
					(IBinding data, string? value) => {(data as Role).OrganizationName = value;}, (IBinding data) => (data as Role).OrganizationName )},
			{ "Titles", new PropertyListString ("Titles", 
					(IBinding data, List<string>? value) => {(data as Role).Titles = value;}, (IBinding data) => (data as Role).Titles )},
			{ "Locations", new PropertyListStruct ("Locations", 
					(IBinding data, object? value) => {(data as Role).Locations = value as List<Location>;}, (IBinding data) => (data as Role).Locations,
					false, ()=>new  List<Location>(), ()=>new Location())} 
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
	public new const string __Tag = "Role";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Role();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Role FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Role;
			}
		var Result = new Role ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Location : MeshItem {
        /// <summary>
        /// </summary>

	public virtual string?						Appartment  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Street  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						District  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Locality  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						County  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Postcode  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Country  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Location(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Appartment", new PropertyString ("Appartment", 
					(IBinding data, string? value) => {(data as Location).Appartment = value;}, (IBinding data) => (data as Location).Appartment )},
			{ "Street", new PropertyString ("Street", 
					(IBinding data, string? value) => {(data as Location).Street = value;}, (IBinding data) => (data as Location).Street )},
			{ "District", new PropertyString ("District", 
					(IBinding data, string? value) => {(data as Location).District = value;}, (IBinding data) => (data as Location).District )},
			{ "Locality", new PropertyString ("Locality", 
					(IBinding data, string? value) => {(data as Location).Locality = value;}, (IBinding data) => (data as Location).Locality )},
			{ "County", new PropertyString ("County", 
					(IBinding data, string? value) => {(data as Location).County = value;}, (IBinding data) => (data as Location).County )},
			{ "Postcode", new PropertyString ("Postcode", 
					(IBinding data, string? value) => {(data as Location).Postcode = value;}, (IBinding data) => (data as Location).Postcode )},
			{ "Country", new PropertyString ("Country", 
					(IBinding data, string? value) => {(data as Location).Country = value;}, (IBinding data) => (data as Location).Country )}
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
	public new const string __Tag = "Location";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Location();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Location FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Location;
			}
		var Result = new Location ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Bookmark : MeshItem {
        /// <summary>
        /// </summary>

	public virtual string?						Uri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Title  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					Role  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Bookmark(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as Bookmark).Uri = value;}, (IBinding data) => (data as Bookmark).Uri )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as Bookmark).Title = value;}, (IBinding data) => (data as Bookmark).Title )},
			{ "Role", new PropertyListString ("Role", 
					(IBinding data, List<string>? value) => {(data as Bookmark).Role = value;}, (IBinding data) => (data as Bookmark).Role )}
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
	public new const string __Tag = "Bookmark";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Bookmark();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Bookmark FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Bookmark;
			}
		var Result = new Bookmark ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Reference : MeshItem {
        /// <summary>
        ///The received message to which this is a response
        /// </summary>

	public virtual string?						MessageId  {get; set;}

        /// <summary>
        ///Message that was generated in response to the original (optional).
        /// </summary>

	public virtual string?						ResponseId  {get; set;}

        /// <summary>
        ///The relationship type. This can be Read, Unread, Accept, Reject.
        /// </summary>

	public virtual string?						Relationship  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Reference(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MessageId", new PropertyString ("MessageId", 
					(IBinding data, string? value) => {(data as Reference).MessageId = value;}, (IBinding data) => (data as Reference).MessageId )},
			{ "ResponseId", new PropertyString ("ResponseId", 
					(IBinding data, string? value) => {(data as Reference).ResponseId = value;}, (IBinding data) => (data as Reference).ResponseId )},
			{ "Relationship", new PropertyString ("Relationship", 
					(IBinding data, string? value) => {(data as Reference).Relationship = value;}, (IBinding data) => (data as Reference).Relationship )}
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
	public new const string __Tag = "Reference";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Reference();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Reference FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Reference;
			}
		var Result = new Reference ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Engagement : MeshItem {
        /// <summary>
        ///Unique key.
        /// </summary>

	public virtual string?						Key  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Start  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Finish  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						StartTravel  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						FinishTravel  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						TimeZone  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Title  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Description  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Location  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					Trigger  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					Conference  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						Repeat  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						Busy  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Engagement(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as Engagement).Key = value;}, (IBinding data) => (data as Engagement).Key )},
			{ "Start", new PropertyDateTime ("Start", 
					(IBinding data, DateTime? value) => {(data as Engagement).Start = value;}, (IBinding data) => (data as Engagement).Start )},
			{ "Finish", new PropertyDateTime ("Finish", 
					(IBinding data, DateTime? value) => {(data as Engagement).Finish = value;}, (IBinding data) => (data as Engagement).Finish )},
			{ "StartTravel", new PropertyString ("StartTravel", 
					(IBinding data, string? value) => {(data as Engagement).StartTravel = value;}, (IBinding data) => (data as Engagement).StartTravel )},
			{ "FinishTravel", new PropertyString ("FinishTravel", 
					(IBinding data, string? value) => {(data as Engagement).FinishTravel = value;}, (IBinding data) => (data as Engagement).FinishTravel )},
			{ "TimeZone", new PropertyString ("TimeZone", 
					(IBinding data, string? value) => {(data as Engagement).TimeZone = value;}, (IBinding data) => (data as Engagement).TimeZone )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as Engagement).Title = value;}, (IBinding data) => (data as Engagement).Title )},
			{ "Description", new PropertyString ("Description", 
					(IBinding data, string? value) => {(data as Engagement).Description = value;}, (IBinding data) => (data as Engagement).Description )},
			{ "Location", new PropertyString ("Location", 
					(IBinding data, string? value) => {(data as Engagement).Location = value;}, (IBinding data) => (data as Engagement).Location )},
			{ "Trigger", new PropertyListString ("Trigger", 
					(IBinding data, List<string>? value) => {(data as Engagement).Trigger = value;}, (IBinding data) => (data as Engagement).Trigger )},
			{ "Conference", new PropertyListString ("Conference", 
					(IBinding data, List<string>? value) => {(data as Engagement).Conference = value;}, (IBinding data) => (data as Engagement).Conference )},
			{ "Repeat", new PropertyString ("Repeat", 
					(IBinding data, string? value) => {(data as Engagement).Repeat = value;}, (IBinding data) => (data as Engagement).Repeat )},
			{ "Busy", new PropertyBoolean ("Busy", 
					(IBinding data, bool? value) => {(data as Engagement).Busy = value;}, (IBinding data) => (data as Engagement).Busy )}
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
	public new const string __Tag = "Engagement";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Engagement();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Engagement FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Engagement;
			}
		var Result = new Engagement ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for cataloged Mesh data.
	/// </summary>
abstract public partial class CatalogedEntry : MeshItem {
        /// <summary>
        ///Globaly unique identifier
        /// </summary>

	public virtual string?						Uid  {get; set;}

        /// <summary>
        ///User specified identifier.
        /// </summary>

	public virtual string?						LocalName  {get; set;}

        /// <summary>
        ///The set of labels describing the entry
        /// </summary>

	public virtual string?						Path  {get; set;}

        /// <summary>
        ///Description
        /// </summary>

	public virtual string?						Description  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uid", new PropertyString ("Uid", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Uid = value;}, (IBinding data) => (data as CatalogedEntry).Uid )},
			{ "LocalName", new PropertyString ("LocalName", 
					(IBinding data, string? value) => {(data as CatalogedEntry).LocalName = value;}, (IBinding data) => (data as CatalogedEntry).LocalName )},
			{ "Path", new PropertyString ("Path", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Path = value;}, (IBinding data) => (data as CatalogedEntry).Path )},
			{ "Description", new PropertyString ("Description", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Description = value;}, (IBinding data) => (data as CatalogedEntry).Description )}
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
	public new const string __Tag = "CatalogedEntry";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedEntry FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedEntry;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// Public device entry, indexed under the device ID Hello
	/// </summary>
public partial class CatalogedDevice : CatalogedEntry {
        /// <summary>
        ///Timestamp, allows 
        /// </summary>

	public virtual DateTime?						Updated  {get; set;}

        /// <summary>
        ///UDF of the signature key of the device in the Mesh
        /// </summary>

	public virtual string?						Udf  {get; set;}

        /// <summary>
        ///Device Platform
        /// </summary>

	public virtual string?						Platform  {get; set;}

        /// <summary>
        ///UDF of the offline signature key of the device
        /// </summary>

	public virtual string?						DeviceUdf  {get; set;}

        /// <summary>
        ///UDF of the account online signature key
        /// </summary>

	public virtual string?						SignatureUdf  {get; set;}

        /// <summary>
        ///The Mesh profile. Why is this still here? This is not 
        ///specific to the device.
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileUser  {get; set;}

        /// <summary>
        ///The device profile
        /// </summary>

	public virtual Enveloped<ProfileDevice>?						EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///Description of the device
        /// </summary>

	public virtual DeviceDescription?						DeviceDescription  {get; set;}

        /// <summary>
        ///Slim version of ConnectionDevice used by the presentation layer
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///The public assertion demonstrating connection of the Device to the Mesh
        /// </summary>

	public virtual Enveloped<ConnectionDevice>?						EnvelopedConnectionDevice  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationAccount>?						EnvelopedActivationAccount  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationCommon>?						EnvelopedActivationCommon  {get; set;}

        /// <summary>
        ///Application activations granted to the device.
        /// </summary>

	public virtual List<ApplicationEntry>?					ApplicationEntries  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedDevice(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updated", new PropertyDateTime ("Updated", 
					(IBinding data, DateTime? value) => {(data as CatalogedDevice).Updated = value;}, (IBinding data) => (data as CatalogedDevice).Updated )},
			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as CatalogedDevice).Udf = value;}, (IBinding data) => (data as CatalogedDevice).Udf )},
			{ "Platform", new PropertyString ("Platform", 
					(IBinding data, string? value) => {(data as CatalogedDevice).Platform = value;}, (IBinding data) => (data as CatalogedDevice).Platform )},
			{ "DeviceUdf", new PropertyString ("DeviceUdf", 
					(IBinding data, string? value) => {(data as CatalogedDevice).DeviceUdf = value;}, (IBinding data) => (data as CatalogedDevice).DeviceUdf )},
			{ "SignatureUdf", new PropertyString ("SignatureUdf", 
					(IBinding data, string? value) => {(data as CatalogedDevice).SignatureUdf = value;}, (IBinding data) => (data as CatalogedDevice).SignatureUdf )},
			{ "EnvelopedProfileUser", new PropertyStruct ("EnvelopedProfileUser", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedProfileUser = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedProfileUser,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())} ,
			{ "DeviceDescription", new PropertyStruct ("DeviceDescription", 
					(IBinding data, object? value) => {(data as CatalogedDevice).DeviceDescription = value as DeviceDescription;}, (IBinding data) => (data as CatalogedDevice).DeviceDescription,
					false, ()=>new  DeviceDescription(), ()=>new DeviceDescription())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} ,
			{ "EnvelopedConnectionDevice", new PropertyStruct ("EnvelopedConnectionDevice", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedConnectionDevice,
					false, ()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>())} ,
			{ "EnvelopedActivationAccount", new PropertyStruct ("EnvelopedActivationAccount", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedActivationAccount = value as Enveloped<ActivationAccount>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedActivationAccount,
					false, ()=>new  Enveloped<ActivationAccount>(), ()=>new Enveloped<ActivationAccount>())} ,
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", 
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())} ,
			{ "ApplicationEntries", new PropertyListStruct ("ApplicationEntries", 
					(IBinding data, object? value) => {(data as CatalogedDevice).ApplicationEntries = value as List<ApplicationEntry>;}, (IBinding data) => (data as CatalogedDevice).ApplicationEntries,
					true, ()=>new List<ApplicationEntry>()
)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedDevice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedDevice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedDevice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedDevice;
			}
		var Result = new CatalogedDevice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DeviceDescription : MeshItem {
        /// <summary>
        ///The device form factor, valid values are Desktop, Phone, Tablet, TV, Watch
        /// </summary>

	public virtual string?						Idiom  {get; set;}

        /// <summary>
        ///Manufacturer name
        /// </summary>

	public virtual string?						Manufacturer  {get; set;}

        /// <summary>
        ///Manufacturer defined model
        /// </summary>

	public virtual string?						Model  {get; set;}

        /// <summary>
        ///Name of the device as specified by the user
        /// </summary>

	public virtual string?						Name  {get; set;}

        /// <summary>
        ///The device platform or operating system: Android / iOS / macOS / Tizen / watchOS / Windows
        /// </summary>

	public virtual string?						Platform  {get; set;}

        /// <summary>
        ///Platform version in format Major.Minor.Build.Revision
        /// </summary>

	public virtual string?						Version  {get; set;}

        /// <summary>
        ///EARL specifying an image of the device.
        /// </summary>

	public virtual string?						ImageLocator  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DeviceDescription(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Idiom", new PropertyString ("Idiom", 
					(IBinding data, string? value) => {(data as DeviceDescription).Idiom = value;}, (IBinding data) => (data as DeviceDescription).Idiom )},
			{ "Manufacturer", new PropertyString ("Manufacturer", 
					(IBinding data, string? value) => {(data as DeviceDescription).Manufacturer = value;}, (IBinding data) => (data as DeviceDescription).Manufacturer )},
			{ "Model", new PropertyString ("Model", 
					(IBinding data, string? value) => {(data as DeviceDescription).Model = value;}, (IBinding data) => (data as DeviceDescription).Model )},
			{ "Name", new PropertyString ("Name", 
					(IBinding data, string? value) => {(data as DeviceDescription).Name = value;}, (IBinding data) => (data as DeviceDescription).Name )},
			{ "Platform", new PropertyString ("Platform", 
					(IBinding data, string? value) => {(data as DeviceDescription).Platform = value;}, (IBinding data) => (data as DeviceDescription).Platform )},
			{ "Version", new PropertyString ("Version", 
					(IBinding data, string? value) => {(data as DeviceDescription).Version = value;}, (IBinding data) => (data as DeviceDescription).Version )},
			{ "ImageLocator", new PropertyString ("ImageLocator", 
					(IBinding data, string? value) => {(data as DeviceDescription).ImageLocator = value;}, (IBinding data) => (data as DeviceDescription).ImageLocator )}
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
	public new const string __Tag = "DeviceDescription";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DeviceDescription();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DeviceDescription FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DeviceDescription;
			}
		var Result = new DeviceDescription ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Cataloged Signature
	/// </summary>
public partial class CatalogedSignature : CatalogedEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedSignature(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedSignature";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedSignature();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedSignature FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedSignature;
			}
		var Result = new CatalogedSignature ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A document stored on a service somewhere.
	/// </summary>
public partial class CatalogedDocument : CatalogedEntry {
        /// <summary>
        ///Document fingerprint.
        /// </summary>

	public virtual string?						Udf  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Filename  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Title  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Version  {get; set;}

        /// <summary>
        ///Locator to be used to retrieve the data.
        /// </summary>

	public virtual string?						URI  {get; set;}

        /// <summary>
        ///IANA content type of the encoded content.
        /// </summary>

	public virtual string?						ContentType  {get; set;}

        /// <summary>
        ///Content encoding, typically DARE envelope.
        /// </summary>

	public virtual string?						Encoding  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Created  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Updated  {get; set;}

        /// <summary>
        ///Encoded document length in bytes.
        /// </summary>

	public virtual int?						Length  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedDocument(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as CatalogedDocument).Udf = value;}, (IBinding data) => (data as CatalogedDocument).Udf )},
			{ "Filename", new PropertyString ("Filename", 
					(IBinding data, string? value) => {(data as CatalogedDocument).Filename = value;}, (IBinding data) => (data as CatalogedDocument).Filename )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as CatalogedDocument).Title = value;}, (IBinding data) => (data as CatalogedDocument).Title )},
			{ "Version", new PropertyString ("Version", 
					(IBinding data, string? value) => {(data as CatalogedDocument).Version = value;}, (IBinding data) => (data as CatalogedDocument).Version )},
			{ "URI", new PropertyString ("URI", 
					(IBinding data, string? value) => {(data as CatalogedDocument).URI = value;}, (IBinding data) => (data as CatalogedDocument).URI )},
			{ "ContentType", new PropertyString ("ContentType", 
					(IBinding data, string? value) => {(data as CatalogedDocument).ContentType = value;}, (IBinding data) => (data as CatalogedDocument).ContentType )},
			{ "Encoding", new PropertyString ("Encoding", 
					(IBinding data, string? value) => {(data as CatalogedDocument).Encoding = value;}, (IBinding data) => (data as CatalogedDocument).Encoding )},
			{ "Created", new PropertyDateTime ("Created", 
					(IBinding data, DateTime? value) => {(data as CatalogedDocument).Created = value;}, (IBinding data) => (data as CatalogedDocument).Created )},
			{ "Updated", new PropertyDateTime ("Updated", 
					(IBinding data, DateTime? value) => {(data as CatalogedDocument).Updated = value;}, (IBinding data) => (data as CatalogedDocument).Updated )},
			{ "Length", new PropertyInteger32 ("Length", 
					(IBinding data, int? value) => {(data as CatalogedDocument).Length = value;}, (IBinding data) => (data as CatalogedDocument).Length )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedDocument";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedDocument();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedDocument FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedDocument;
			}
		var Result = new CatalogedDocument ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A publication.
	/// </summary>
public partial class CatalogedPublication : CatalogedEntry {
        /// <summary>
        ///Unique identifier code
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        ///The witness key value to use to request access to the record.	
        /// </summary>

	public virtual string?						Authenticator  {get; set;}

        /// <summary>
        ///Dare Envelope containing the entry data. The data type is specified
        ///by the envelope metadata.
        /// </summary>

	public virtual DareEnvelope?						EnvelopedData  {get; set;}

        /// <summary>
        ///Epiration time (inclusive)
        /// </summary>

	public virtual DateTime?						NotOnOrAfter  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedPublication(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedPublication).Id = value;}, (IBinding data) => (data as CatalogedPublication).Id )},
			{ "Authenticator", new PropertyString ("Authenticator", 
					(IBinding data, string? value) => {(data as CatalogedPublication).Authenticator = value;}, (IBinding data) => (data as CatalogedPublication).Authenticator )},
			{ "EnvelopedData", new PropertyStruct ("EnvelopedData", 
					(IBinding data, object? value) => {(data as CatalogedPublication).EnvelopedData = value as DareEnvelope;}, (IBinding data) => (data as CatalogedPublication).EnvelopedData,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())} ,
			{ "NotOnOrAfter", new PropertyDateTime ("NotOnOrAfter", 
					(IBinding data, DateTime? value) => {(data as CatalogedPublication).NotOnOrAfter = value;}, (IBinding data) => (data as CatalogedPublication).NotOnOrAfter )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedPublication";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedPublication();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedPublication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedPublication;
			}
		var Result = new CatalogedPublication ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedCredential : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string?						Protocol  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Service  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Username  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Password  {get; set;}

        /// <summary>
        ///Specifies the client identification key
        /// </summary>

	public virtual List<KeyData>?					ClientAuthentication  {get; set;}
        /// <summary>
        ///Means of authenticating the host key
        /// </summary>

	public virtual List<KeyData>?					HostAuthentication  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedCredential(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Protocol = value;}, (IBinding data) => (data as CatalogedCredential).Protocol )},
			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Service = value;}, (IBinding data) => (data as CatalogedCredential).Service )},
			{ "Username", new PropertyString ("Username", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Username = value;}, (IBinding data) => (data as CatalogedCredential).Username )},
			{ "Password", new PropertyString ("Password", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Password = value;}, (IBinding data) => (data as CatalogedCredential).Password )},
			{ "ClientAuthentication", new PropertyListStruct ("ClientAuthentication", 
					(IBinding data, object? value) => {(data as CatalogedCredential).ClientAuthentication = value as List<KeyData>;}, (IBinding data) => (data as CatalogedCredential).ClientAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())} ,
			{ "HostAuthentication", new PropertyListStruct ("HostAuthentication", 
					(IBinding data, object? value) => {(data as CatalogedCredential).HostAuthentication = value as List<KeyData>;}, (IBinding data) => (data as CatalogedCredential).HostAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedCredential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedCredential;
			}
		var Result = new CatalogedCredential ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedNetwork : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string?						Protocol  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Service  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Username  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Password  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedNetwork(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Protocol = value;}, (IBinding data) => (data as CatalogedNetwork).Protocol )},
			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Service = value;}, (IBinding data) => (data as CatalogedNetwork).Service )},
			{ "Username", new PropertyString ("Username", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Username = value;}, (IBinding data) => (data as CatalogedNetwork).Username )},
			{ "Password", new PropertyString ("Password", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Password = value;}, (IBinding data) => (data as CatalogedNetwork).Password )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedNetwork";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedNetwork();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedNetwork FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedNetwork;
			}
		var Result = new CatalogedNetwork ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedContact : CatalogedEntry {
        /// <summary>
        ///Unique key. 
        /// </summary>

	public virtual string?						Key  {get; set;}

        /// <summary>
        ///If true, this catalog entry is for the user who created the catalog.
        /// </summary>

	public virtual bool?						Self  {get; set;}

        /// <summary>
        ///The contact information as edited by the catalog owner.
        /// </summary>

	public virtual Contact?						Contact  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedContact(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as CatalogedContact).Key = value;}, (IBinding data) => (data as CatalogedContact).Key )},
			{ "Self", new PropertyBoolean ("Self", 
					(IBinding data, bool? value) => {(data as CatalogedContact).Self = value;}, (IBinding data) => (data as CatalogedContact).Self )},
			{ "Contact", new PropertyStruct ("Contact", 
					(IBinding data, object? value) => {(data as CatalogedContact).Contact = value as Contact;}, (IBinding data) => (data as CatalogedContact).Contact,
					true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedContact";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedContact();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedContact FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedContact;
			}
		var Result = new CatalogedContact ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class CatalogedAccess : CatalogedEntry {
        /// <summary>
        ///The cataloged capability.
        /// </summary>

	public virtual Capability?						Capability  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedAccess(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Capability", new PropertyStruct ("Capability", 
					(IBinding data, object? value) => {(data as CatalogedAccess).Capability = value as Capability;}, (IBinding data) => (data as CatalogedAccess).Capability,
					true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedAccess";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedAccess();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedAccess FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedAccess;
			}
		var Result = new CatalogedAccess ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class Capability : MeshItem {
        /// <summary>
        ///The identifier of the capability. If this is a cryptographic capability,
        ///this is the KeyIdentifier of the primary key that was shared. If
        ///this is an access capability, this is the KeyIdentifier of the authentication
        ///key being authorized for access.
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						Active  {get; set;}

        /// <summary>
        /// </summary>

	public virtual int?						Issued  {get; set;}

        /// <summary>
        ///The authentication mode: Device, Account, PIN
        /// </summary>

	public virtual string?						Mode  {get; set;}

        /// <summary>
        ///Identifies the authentication credential. For a device, this is the authentication key identifier, 
        ///for an account, the profile identifier, for a PIN, the locator value of the PIN.
        /// </summary>

	public virtual string?						Udf  {get; set;}

        /// <summary>
        ///The verification value used to perform proof of knowledge of the secret.
        /// </summary>

	public virtual string?						Witness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as Capability).Id = value;}, (IBinding data) => (data as Capability).Id )},
			{ "Active", new PropertyBoolean ("Active", 
					(IBinding data, bool? value) => {(data as Capability).Active = value;}, (IBinding data) => (data as Capability).Active )},
			{ "Issued", new PropertyInteger32 ("Issued", 
					(IBinding data, int? value) => {(data as Capability).Issued = value;}, (IBinding data) => (data as Capability).Issued )},
			{ "Mode", new PropertyString ("Mode", 
					(IBinding data, string? value) => {(data as Capability).Mode = value;}, (IBinding data) => (data as Capability).Mode )},
			{ "Udf", new PropertyString ("Udf", 
					(IBinding data, string? value) => {(data as Capability).Udf = value;}, (IBinding data) => (data as Capability).Udf )},
			{ "Witness", new PropertyString ("Witness", 
					(IBinding data, string? value) => {(data as Capability).Witness = value;}, (IBinding data) => (data as Capability).Witness )}
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
	public new const string __Tag = "Capability";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Capability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Capability;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	/// </summary>
public partial class NullCapability : Capability {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NullCapability(), Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Capability._StaticAllProperties);


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
	public new const string __Tag = "NullCapability";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NullCapability();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NullCapability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NullCapability;
			}
		var Result = new NullCapability ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class AccessCapability : Capability {
        /// <summary>
        ///Access rights associated with the key
        /// </summary>

	public virtual List<string>?					Rights  {get; set;}
        /// <summary>
        ///
        /// </summary>

	public virtual Enveloped<CatalogedDevice>?						EnvelopedCatalogedDevice  {get; set;}

        /// <summary>
        ///Digest value used to signal updates to envelope		
        /// </summary>

	public virtual string?						CatalogedDeviceDigest  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new AccessCapability(), Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Rights", new PropertyListString ("Rights", 
					(IBinding data, List<string>? value) => {(data as AccessCapability).Rights = value;}, (IBinding data) => (data as AccessCapability).Rights )},
			{ "EnvelopedCatalogedDevice", new PropertyStruct ("EnvelopedCatalogedDevice", 
					(IBinding data, object? value) => {(data as AccessCapability).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, (IBinding data) => (data as AccessCapability).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())} ,
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as AccessCapability).CatalogedDeviceDigest = value;}, (IBinding data) => (data as AccessCapability).CatalogedDeviceDigest )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Capability._StaticAllProperties);


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
	public new const string __Tag = "AccessCapability";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AccessCapability();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AccessCapability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AccessCapability;
			}
		var Result = new AccessCapability ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// 
	/// </summary>
public partial class PublicationCapability : Capability {
        /// <summary>
        ///Selector allowing a specific document to be requested.
        /// </summary>

	public virtual string?						Identifier  {get; set;}

        /// <summary>
        ///Document digest, this allows a status/claim request to 
        ///request an update to be returned only if the document
        ///has changed.
        /// </summary>

	public virtual string?						Digest  {get; set;}

        /// <summary>
        ///The published document.
        /// </summary>

	public virtual byte[]?						Data  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new PublicationCapability(), Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as PublicationCapability).Identifier = value;}, (IBinding data) => (data as PublicationCapability).Identifier )},
			{ "Digest", new PropertyString ("Digest", 
					(IBinding data, string? value) => {(data as PublicationCapability).Digest = value;}, (IBinding data) => (data as PublicationCapability).Digest )},
			{ "Data", new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as PublicationCapability).Data = value;}, (IBinding data) => (data as PublicationCapability).Data )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Capability._StaticAllProperties);


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
	public new const string __Tag = "PublicationCapability";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PublicationCapability();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PublicationCapability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PublicationCapability;
			}
		var Result = new PublicationCapability ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class CryptographicCapability : Capability {
        /// <summary>
        ///The key that enables the capability
        /// </summary>

	public virtual KeyData?						KeyData  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						GranteeAccount  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						GranteeUdf  {get; set;}

        /// <summary>
        ///One or more enveloped key shares.
        /// </summary>

	public virtual Enveloped<KeyData>?						EnvelopedKeyShare  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyData", new PropertyStruct ("KeyData", 
					(IBinding data, object? value) => {(data as CryptographicCapability).KeyData = value as KeyData;}, (IBinding data) => (data as CryptographicCapability).KeyData,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "GranteeAccount", new PropertyString ("GranteeAccount", 
					(IBinding data, string? value) => {(data as CryptographicCapability).GranteeAccount = value;}, (IBinding data) => (data as CryptographicCapability).GranteeAccount )},
			{ "GranteeUdf", new PropertyString ("GranteeUdf", 
					(IBinding data, string? value) => {(data as CryptographicCapability).GranteeUdf = value;}, (IBinding data) => (data as CryptographicCapability).GranteeUdf )},
			{ "EnvelopedKeyShare", new PropertyStruct ("EnvelopedKeyShare", 
					(IBinding data, object? value) => {(data as CryptographicCapability).EnvelopedKeyShare = value as Enveloped<KeyData>;}, (IBinding data) => (data as CryptographicCapability).EnvelopedKeyShare,
					false, ()=>new  Enveloped<KeyData>(), ()=>new Enveloped<KeyData>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Capability._StaticAllProperties);


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
	public new const string __Tag = "CryptographicCapability";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CryptographicCapability FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CryptographicCapability;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	///
	/// The corresponding key is a decryption key
	/// </summary>
public partial class CapabilityDecrypt : CryptographicCapability {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilityDecrypt(), CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicCapability._StaticAllProperties);


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
	public new const string __Tag = "CapabilityDecrypt";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilityDecrypt();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilityDecrypt FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilityDecrypt;
			}
		var Result = new CapabilityDecrypt ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The corresponding key is an encryption key
	/// </summary>
public partial class CapabilityDecryptPartial : CapabilityDecrypt {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilityDecryptPartial(), CapabilityDecrypt._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CapabilityDecrypt._StaticAllProperties);


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
	public new const string __Tag = "CapabilityDecryptPartial";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilityDecryptPartial();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilityDecryptPartial FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilityDecryptPartial;
			}
		var Result = new CapabilityDecryptPartial ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The corresponding key is an encryption key
	/// </summary>
public partial class CapabilityDecryptServiced : CapabilityDecrypt {
        /// <summary>
        ///UDF of trust root under which request to use a serviced capability must be 
        ///authorized. [Only present for a serviced capability]
        /// </summary>

	public virtual string?						AuthenticationId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilityDecryptServiced(), CapabilityDecrypt._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AuthenticationId", new PropertyString ("AuthenticationId", 
					(IBinding data, string? value) => {(data as CapabilityDecryptServiced).AuthenticationId = value;}, (IBinding data) => (data as CapabilityDecryptServiced).AuthenticationId )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CapabilityDecrypt._StaticAllProperties);


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
	public new const string __Tag = "CapabilityDecryptServiced";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilityDecryptServiced();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilityDecryptServiced FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilityDecryptServiced;
			}
		var Result = new CapabilityDecryptServiced ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The corresponding key is an administration key
	/// </summary>
public partial class CapabilitySign : CryptographicCapability {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilitySign(), CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicCapability._StaticAllProperties);


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
	public new const string __Tag = "CapabilitySign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilitySign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilitySign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilitySign;
			}
		var Result = new CapabilitySign ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The corresponding key is a key that may be used to generate key shares.
	/// </summary>
public partial class CapabilityKeyGenerate : CryptographicCapability {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilityKeyGenerate(), CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicCapability._StaticAllProperties);


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
	public new const string __Tag = "CapabilityKeyGenerate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilityKeyGenerate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilityKeyGenerate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilityKeyGenerate;
			}
		var Result = new CapabilityKeyGenerate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The corresponding key is a decryption key to be used in accordance 
	/// with the Micali Fair Electronic Exchange with Invisible Trusted Parties
	/// protocol.
	/// </summary>
public partial class CapabilityFairExchange : CryptographicCapability {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CapabilityFairExchange(), CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CryptographicCapability._StaticAllProperties);


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
	public new const string __Tag = "CapabilityFairExchange";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CapabilityFairExchange();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CapabilityFairExchange FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CapabilityFairExchange;
			}
		var Result = new CapabilityFairExchange ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class NamedService : MeshItem {
        /// <summary>
        ///The IANA service name (e.g. dns)
        /// </summary>

	public virtual string?						Prefix  {get; set;}

        /// <summary>
        ///Optional name mapping, (e.g. alice@example.com -> alice.mesh)
        /// </summary>

	public virtual string?						Mapping  {get; set;}

        /// <summary>
        ///The service endpoints. This MAY be specified as a callsign (@alice),
        ///a DNS address (example.com), an IP address (10.0.0.1) or a fully
        ///qualified URI.
        /// </summary>

	public virtual List<string>?					Endpoints  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new NamedService(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Prefix", new PropertyString ("Prefix", 
					(IBinding data, string? value) => {(data as NamedService).Prefix = value;}, (IBinding data) => (data as NamedService).Prefix )},
			{ "Mapping", new PropertyString ("Mapping", 
					(IBinding data, string? value) => {(data as NamedService).Mapping = value;}, (IBinding data) => (data as NamedService).Mapping )},
			{ "Endpoints", new PropertyListString ("Endpoints", 
					(IBinding data, List<string>? value) => {(data as NamedService).Endpoints = value;}, (IBinding data) => (data as NamedService).Endpoints )}
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
	public new const string __Tag = "NamedService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NamedService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new NamedService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as NamedService;
			}
		var Result = new NamedService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ServiceAccessToken : NamedService {
        /// <summary>
        ///Session initiation token
        /// </summary>

	public virtual byte[]?						Token  {get; set;}

        /// <summary>
        ///Session shared secret
        /// </summary>

	public virtual byte[]?						SharedSecret  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ServiceAccessToken(), NamedService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Token", new PropertyBinary ("Token", 
					(IBinding data, byte[]? value) => {(data as ServiceAccessToken).Token = value;}, (IBinding data) => (data as ServiceAccessToken).Token )},
			{ "SharedSecret", new PropertyBinary ("SharedSecret", 
					(IBinding data, byte[]? value) => {(data as ServiceAccessToken).SharedSecret = value;}, (IBinding data) => (data as ServiceAccessToken).SharedSecret )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, NamedService._StaticAllProperties);


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
	public new const string __Tag = "ServiceAccessToken";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ServiceAccessToken();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ServiceAccessToken FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ServiceAccessToken;
			}
		var Result = new ServiceAccessToken ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedBookmark : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string?						Uri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Title  {get; set;}

        /// <summary>
        ///User comments on bookmark entry
        /// </summary>

	public virtual List<string>?					Comments  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedBookmark(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as CatalogedBookmark).Uri = value;}, (IBinding data) => (data as CatalogedBookmark).Uri )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as CatalogedBookmark).Title = value;}, (IBinding data) => (data as CatalogedBookmark).Title )},
			{ "Comments", new PropertyListString ("Comments", 
					(IBinding data, List<string>? value) => {(data as CatalogedBookmark).Comments = value;}, (IBinding data) => (data as CatalogedBookmark).Comments )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedBookmark";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedBookmark();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedBookmark FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedBookmark;
			}
		var Result = new CatalogedBookmark ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedTask : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<Engagement>?						EnvelopedTask  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Title  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedTask(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedTask", new PropertyStruct ("EnvelopedTask", 
					(IBinding data, object? value) => {(data as CatalogedTask).EnvelopedTask = value as Enveloped<Engagement>;}, (IBinding data) => (data as CatalogedTask).EnvelopedTask,
					false, ()=>new  Enveloped<Engagement>(), ()=>new Enveloped<Engagement>())} ,
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as CatalogedTask).Title = value;}, (IBinding data) => (data as CatalogedTask).Title )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedTask";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedTask();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedTask FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedTask;
			}
		var Result = new CatalogedTask ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class CatalogedApplication : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual int?						Default  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Key  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					Grant  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					Deny  {get; set;}
        /// <summary>
        ///Enveloped keys for use with Application
        /// </summary>

	public virtual List<DareEnvelope>?					EnvelopedCapabilities  {get; set;}
        /// <summary>
        ///Escrow entries for the application.
        /// </summary>

	public virtual List<Enveloped<KeyData>>?					EnvelopedEscrow  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,null, CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Default", new PropertyInteger32 ("Default", 
					(IBinding data, int? value) => {(data as CatalogedApplication).Default = value;}, (IBinding data) => (data as CatalogedApplication).Default )},
			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as CatalogedApplication).Key = value;}, (IBinding data) => (data as CatalogedApplication).Key )},
			{ "Grant", new PropertyListString ("Grant", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplication).Grant = value;}, (IBinding data) => (data as CatalogedApplication).Grant )},
			{ "Deny", new PropertyListString ("Deny", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplication).Deny = value;}, (IBinding data) => (data as CatalogedApplication).Deny )},
			{ "EnvelopedCapabilities", new PropertyListStruct ("EnvelopedCapabilities", 
					(IBinding data, object? value) => {(data as CatalogedApplication).EnvelopedCapabilities = value as List<DareEnvelope>;}, (IBinding data) => (data as CatalogedApplication).EnvelopedCapabilities,
					false, ()=>new  List<DareEnvelope>(), ()=>new DareEnvelope())} ,
			{ "EnvelopedEscrow", new PropertyListStruct ("EnvelopedEscrow", 
					(IBinding data, object? value) => {(data as CatalogedApplication).EnvelopedEscrow = value as List<Enveloped<KeyData>>;}, (IBinding data) => (data as CatalogedApplication).EnvelopedEscrow,
					false, ()=>new  List<Enveloped<KeyData>>(), ()=>new Enveloped<KeyData>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplication";

	/// <summary>
    /// Factory method. Throws exception as this is an abstract class.
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => throw new CannotCreateAbstract();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplication FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplication;
			}
		throw new CannotCreateAbstract();
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedMember : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string?						ContactAddress  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						MemberCapabilityId  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ServiceCapabilityId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedMember(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ContactAddress", new PropertyString ("ContactAddress", 
					(IBinding data, string? value) => {(data as CatalogedMember).ContactAddress = value;}, (IBinding data) => (data as CatalogedMember).ContactAddress )},
			{ "MemberCapabilityId", new PropertyString ("MemberCapabilityId", 
					(IBinding data, string? value) => {(data as CatalogedMember).MemberCapabilityId = value;}, (IBinding data) => (data as CatalogedMember).MemberCapabilityId )},
			{ "ServiceCapabilityId", new PropertyString ("ServiceCapabilityId", 
					(IBinding data, string? value) => {(data as CatalogedMember).ServiceCapabilityId = value;}, (IBinding data) => (data as CatalogedMember).ServiceCapabilityId )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedMember";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedMember();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedMember FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedMember;
			}
		var Result = new CatalogedMember ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedGroup : CatalogedApplication {
        /// <summary>
        ///The connection allowing control of the group.
        /// </summary>

	public virtual Enveloped<ConnectionStripped>?						EnvelopedConnectionAddress  {get; set;}

        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>?						EnvelopedProfileGroup  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationCommon>?						EnvelopedActivationCommon  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedGroup(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedConnectionAddress", new PropertyStruct ("EnvelopedConnectionAddress", 
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>())} ,
			{ "EnvelopedProfileGroup", new PropertyStruct ("EnvelopedProfileGroup", 
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedProfileGroup = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedProfileGroup,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())} ,
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", 
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedGroup();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedGroup FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedGroup;
			}
		var Result = new CatalogedGroup ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedFeed : CatalogedBookmark {
        /// <summary>
        /// </summary>

	public virtual string?						Protocol  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedFeed(), CatalogedBookmark._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedFeed).Protocol = value;}, (IBinding data) => (data as CatalogedFeed).Protocol )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedBookmark._StaticAllProperties);


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
	public new const string __Tag = "CatalogedFeed";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedFeed();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedFeed FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedFeed;
			}
		var Result = new CatalogedFeed ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationMail : CatalogedApplication {
        /// <summary>
        /// </summary>

	public virtual string?						AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						InboundConnect  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						OutboundConnect  {get; set;}

        /// <summary>
        ///The S/Mime signature key
        /// </summary>

	public virtual KeyData?						SmimeSign  {get; set;}

        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData?						SmimeEncrypt  {get; set;}

        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	public virtual KeyData?						OpenpgpSign  {get; set;}

        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	public virtual KeyData?						OpenpgpEncrypt  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationMail(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationMail).AccountAddress )},
			{ "InboundConnect", new PropertyString ("InboundConnect", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).InboundConnect = value;}, (IBinding data) => (data as CatalogedApplicationMail).InboundConnect )},
			{ "OutboundConnect", new PropertyString ("OutboundConnect", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).OutboundConnect = value;}, (IBinding data) => (data as CatalogedApplicationMail).OutboundConnect )},
			{ "SmimeSign", new PropertyStruct ("SmimeSign", 
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).SmimeSign = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "SmimeEncrypt", new PropertyStruct ("SmimeEncrypt", 
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).SmimeEncrypt = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "OpenpgpSign", new PropertyStruct ("OpenpgpSign", 
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).OpenpgpSign = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData())} ,
			{ "OpenpgpEncrypt", new PropertyStruct ("OpenpgpEncrypt", 
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).OpenpgpEncrypt = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationMail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationMail;
			}
		var Result = new CatalogedApplicationMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationPkix : CatalogedApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationPkix(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationPkix";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationPkix();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationPkix FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationPkix;
			}
		var Result = new CatalogedApplicationPkix ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationOpenPgp : CatalogedApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationOpenPgp(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationOpenPgp";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationOpenPgp();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationOpenPgp FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationOpenPgp;
			}
		var Result = new CatalogedApplicationOpenPgp ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationSsh : CatalogedApplication {
        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData?						ClientKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationSsh(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ClientKey", new PropertyStruct ("ClientKey", 
					(IBinding data, object? value) => {(data as CatalogedApplicationSsh).ClientKey = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationSsh";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationSsh();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationSsh FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationSsh;
			}
		var Result = new CatalogedApplicationSsh ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationGit : CatalogedApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationGit(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationGit";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationGit();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationGit FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationGit;
			}
		var Result = new CatalogedApplicationGit ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedApplicationDeveloper : CatalogedApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedApplicationDeveloper(), CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedApplication._StaticAllProperties);


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
	public new const string __Tag = "CatalogedApplicationDeveloper";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationDeveloper();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationDeveloper FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationDeveloper;
			}
		var Result = new CatalogedApplicationDeveloper ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageInvoice : Message {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageInvoice(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageInvoice";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageInvoice();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageInvoice FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageInvoice;
			}
		var Result = new MessageInvoice ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedReceipt : CatalogedEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedReceipt(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedReceipt";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedReceipt();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedReceipt FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedReceipt;
			}
		var Result = new CatalogedReceipt ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedTicket : CatalogedEntry {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new CatalogedTicket(), CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, CatalogedEntry._StaticAllProperties);


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
	public new const string __Tag = "CatalogedTicket";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedTicket();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedTicket FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedTicket;
			}
		var Result = new CatalogedTicket ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DevicePreconfigurationPublic : MeshItem {
        /// <summary>
        ///The device profile
        /// </summary>

	public virtual Enveloped<ProfileDevice>?						EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///A list of URIs specifying hailing transports that may be used to
        ///initiate a connection to the device. This allows a device to 
        ///specify that it can be reached by WiFi transport to a particular 
        ///private SSID, or by Bluetooth, IR etc. etc.
        /// </summary>

	public virtual List<string>?					Hailing  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DevicePreconfigurationPublic(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", 
					(IBinding data, object? value) => {(data as DevicePreconfigurationPublic).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as DevicePreconfigurationPublic).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())} ,
			{ "Hailing", new PropertyListString ("Hailing", 
					(IBinding data, List<string>? value) => {(data as DevicePreconfigurationPublic).Hailing = value;}, (IBinding data) => (data as DevicePreconfigurationPublic).Hailing )}
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
	public new const string __Tag = "DevicePreconfigurationPublic";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DevicePreconfigurationPublic();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DevicePreconfigurationPublic FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DevicePreconfigurationPublic;
			}
		var Result = new DevicePreconfigurationPublic ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// A data structure that is passed 
	/// </summary>
public partial class DevicePreconfigurationPrivate : DevicePreconfigurationPublic {
        /// <summary>
        ///The device connection
        /// </summary>

	public virtual Enveloped<ConnectionDevice>?						EnvelopedConnectionDevice  {get; set;}

        /// <summary>
        ///The device connection
        /// </summary>

	public virtual Enveloped<ConnectionService>?						EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///The device private key
        /// </summary>

	public virtual Key?						PrivateKey  {get; set;}

        /// <summary>
        ///The connection URI. This would normally be printed on the device as a 
        ///QR code.
        /// </summary>

	public virtual string?						ConnectUri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new DevicePreconfigurationPrivate(), DevicePreconfigurationPublic._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedConnectionDevice", new PropertyStruct ("EnvelopedConnectionDevice", 
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;}, (IBinding data) => (data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice,
					false, ()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>())} ,
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", 
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as DevicePreconfigurationPrivate).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())} ,
			{ "PrivateKey", new PropertyStruct ("PrivateKey", 
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).PrivateKey = value as Key;}, (IBinding data) => (data as DevicePreconfigurationPrivate).PrivateKey,
					true)} ,
			{ "ConnectUri", new PropertyString ("ConnectUri", 
					(IBinding data, string? value) => {(data as DevicePreconfigurationPrivate).ConnectUri = value;}, (IBinding data) => (data as DevicePreconfigurationPrivate).ConnectUri )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, DevicePreconfigurationPublic._StaticAllProperties);


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
	public new const string __Tag = "DevicePreconfigurationPrivate";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DevicePreconfigurationPrivate();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DevicePreconfigurationPrivate FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DevicePreconfigurationPrivate;
			}
		var Result = new DevicePreconfigurationPrivate ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class Message : MeshItem {
        /// <summary>
        ///Unique per-message ID. When encapsulating a Mesh Message in a DARE envelope,
        ///the envelope EnvelopeID field MUST be a UDF fingerprint of the MessageId
        ///value. 
        /// </summary>

	public virtual string?						MessageId  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Sender  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Recipient  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new Message(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MessageId", new PropertyString ("MessageId", 
					(IBinding data, string? value) => {(data as Message).MessageId = value;}, (IBinding data) => (data as Message).MessageId )},
			{ "Sender", new PropertyString ("Sender", 
					(IBinding data, string? value) => {(data as Message).Sender = value;}, (IBinding data) => (data as Message).Sender )},
			{ "Recipient", new PropertyString ("Recipient", 
					(IBinding data, string? value) => {(data as Message).Recipient = value;}, (IBinding data) => (data as Message).Recipient )}
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
	public new const string __Tag = "Message";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Message();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new Message FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as Message;
			}
		var Result = new Message ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageError : Message {
        /// <summary>
        /// </summary>

	public virtual string?						ErrorCode  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageError(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ErrorCode", new PropertyString ("ErrorCode", 
					(IBinding data, string? value) => {(data as MessageError).ErrorCode = value;}, (IBinding data) => (data as MessageError).ErrorCode )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageError";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageError();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageError FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageError;
			}
		var Result = new MessageError ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageComplete : Message {
        /// <summary>
        /// </summary>

	public virtual List<Reference>?					References  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageComplete(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "References", new PropertyListStruct ("References", 
					(IBinding data, object? value) => {(data as MessageComplete).References = value as List<Reference>;}, (IBinding data) => (data as MessageComplete).References,
					false, ()=>new  List<Reference>(), ()=>new Reference())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageComplete";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageComplete();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageComplete FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageComplete;
			}
		var Result = new MessageComplete ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageValidated : Message {
        /// <summary>
        ///Enveloped data that is authenticated by means of the PIN
        /// </summary>

	public virtual DareEnvelope?						AuthenticatedData  {get; set;}

        /// <summary>
        ///Nonce provided by the client to validate the PIN
        /// </summary>

	public virtual byte[]?						ClientNonce  {get; set;}

        /// <summary>
        ///Pin identifier value calculated from the PIN code, action and account address.
        /// </summary>

	public virtual string?						PinId  {get; set;}

        /// <summary>
        ///Witness value calculated as KDF (Device.Udf + AccountAddress, ClientNonce)
        /// </summary>

	public virtual byte[]?						PinWitness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageValidated(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AuthenticatedData", new PropertyStruct ("AuthenticatedData", 
					(IBinding data, object? value) => {(data as MessageValidated).AuthenticatedData = value as DareEnvelope;}, (IBinding data) => (data as MessageValidated).AuthenticatedData,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())} ,
			{ "ClientNonce", new PropertyBinary ("ClientNonce", 
					(IBinding data, byte[]? value) => {(data as MessageValidated).ClientNonce = value;}, (IBinding data) => (data as MessageValidated).ClientNonce )},
			{ "PinId", new PropertyString ("PinId", 
					(IBinding data, string? value) => {(data as MessageValidated).PinId = value;}, (IBinding data) => (data as MessageValidated).PinId )},
			{ "PinWitness", new PropertyBinary ("PinWitness", 
					(IBinding data, byte[]? value) => {(data as MessageValidated).PinWitness = value;}, (IBinding data) => (data as MessageValidated).PinWitness )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageValidated";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageValidated();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageValidated FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageValidated;
			}
		var Result = new MessageValidated ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessagePin : Message {
        /// <summary>
        /// </summary>

	public virtual string?						Account  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}

        /// <summary>
        ///If true, authentication against the PIN code is sufficient to complete
        ///the associated action without further authorization.
        /// </summary>

	public virtual bool?						Automatic  {get; set;}

        /// <summary>
        ///PIN code bound to the specified action.
        /// </summary>

	public virtual string?						SaltedPin  {get; set;}

        /// <summary>
        ///The action to which this PIN code is bound.
        /// </summary>

	public virtual string?						Action  {get; set;}

        /// <summary>
        ///The set of rights bound to the PIN grant.
        /// </summary>

	public virtual List<string>?					Roles  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessagePin(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new PropertyString ("Account", 
					(IBinding data, string? value) => {(data as MessagePin).Account = value;}, (IBinding data) => (data as MessagePin).Account )},
			{ "Expires", new PropertyDateTime ("Expires", 
					(IBinding data, DateTime? value) => {(data as MessagePin).Expires = value;}, (IBinding data) => (data as MessagePin).Expires )},
			{ "Automatic", new PropertyBoolean ("Automatic", 
					(IBinding data, bool? value) => {(data as MessagePin).Automatic = value;}, (IBinding data) => (data as MessagePin).Automatic )},
			{ "SaltedPin", new PropertyString ("SaltedPin", 
					(IBinding data, string? value) => {(data as MessagePin).SaltedPin = value;}, (IBinding data) => (data as MessagePin).SaltedPin )},
			{ "Action", new PropertyString ("Action", 
					(IBinding data, string? value) => {(data as MessagePin).Action = value;}, (IBinding data) => (data as MessagePin).Action )},
			{ "Roles", new PropertyListString ("Roles", 
					(IBinding data, List<string>? value) => {(data as MessagePin).Roles = value;}, (IBinding data) => (data as MessagePin).Roles )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessagePin";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessagePin();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessagePin FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessagePin;
			}
		var Result = new MessagePin ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Connection request message. This message contains the information
	/// </summary>
public partial class RequestConnection : MessageValidated {
        /// <summary>
        ///
        /// </summary>

	public virtual string?						AccountAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new RequestConnection(), MessageValidated._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as RequestConnection).AccountAddress = value;}, (IBinding data) => (data as RequestConnection).AccountAddress )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MessageValidated._StaticAllProperties);


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
	public new const string __Tag = "RequestConnection";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RequestConnection();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RequestConnection FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RequestConnection;
			}
		var Result = new RequestConnection ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Connection request message generated by a service on receipt of a valid
	/// MessageConnectionRequestClient
	/// </summary>
public partial class AcknowledgeConnection : Message {
        /// <summary>
        ///The client connection request.
        /// </summary>

	public virtual Enveloped<RequestConnection>?						EnvelopedRequestConnection  {get; set;}

        /// <summary>
        ///
        /// </summary>

	public virtual byte[]?						ServerNonce  {get; set;}

        /// <summary>
        ///
        /// </summary>

	public virtual string?						Witness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new AcknowledgeConnection(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedRequestConnection", new PropertyStruct ("EnvelopedRequestConnection", 
					(IBinding data, object? value) => {(data as AcknowledgeConnection).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;}, (IBinding data) => (data as AcknowledgeConnection).EnvelopedRequestConnection,
					false, ()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>())} ,
			{ "ServerNonce", new PropertyBinary ("ServerNonce", 
					(IBinding data, byte[]? value) => {(data as AcknowledgeConnection).ServerNonce = value;}, (IBinding data) => (data as AcknowledgeConnection).ServerNonce )},
			{ "Witness", new PropertyString ("Witness", 
					(IBinding data, string? value) => {(data as AcknowledgeConnection).Witness = value;}, (IBinding data) => (data as AcknowledgeConnection).Witness )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "AcknowledgeConnection";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AcknowledgeConnection();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AcknowledgeConnection FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AcknowledgeConnection;
			}
		var Result = new AcknowledgeConnection ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Respond to RequestConnection message to grant or refuse the connection
	/// request.
	/// </summary>
public partial class RespondConnection : Message {
        /// <summary>
        ///The response to the request. One of "Accept", "Reject" or "Pending".
        /// </summary>

	public virtual string?						Result  {get; set;}

        /// <summary>
        ///The device information. MUST be present if the value of Result is
        ///"Accept". MUST be absent or null otherwise.
        /// </summary>

	public virtual CatalogedDevice?						CatalogedDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new RespondConnection(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new PropertyString ("Result", 
					(IBinding data, string? value) => {(data as RespondConnection).Result = value;}, (IBinding data) => (data as RespondConnection).Result )},
			{ "CatalogedDevice", new PropertyStruct ("CatalogedDevice", 
					(IBinding data, object? value) => {(data as RespondConnection).CatalogedDevice = value as CatalogedDevice;}, (IBinding data) => (data as RespondConnection).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "RespondConnection";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RespondConnection();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RespondConnection FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RespondConnection;
			}
		var Result = new RespondConnection ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageContact : MessageValidated {
        /// <summary>
        ///If true, requests that the recipient return their own contact information
        ///in reply.
        /// </summary>

	public virtual bool?						Reply  {get; set;}

        /// <summary>
        ///Optional explanation of the reason for the request.
        /// </summary>

	public virtual string?						Subject  {get; set;}

        /// <summary>
        ///One time authentication code supplied to a recipient to allow authentication
        ///of the response.
        /// </summary>

	public virtual string?						PIN  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageContact(), MessageValidated._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Reply", new PropertyBoolean ("Reply", 
					(IBinding data, bool? value) => {(data as MessageContact).Reply = value;}, (IBinding data) => (data as MessageContact).Reply )},
			{ "Subject", new PropertyString ("Subject", 
					(IBinding data, string? value) => {(data as MessageContact).Subject = value;}, (IBinding data) => (data as MessageContact).Subject )},
			{ "PIN", new PropertyString ("PIN", 
					(IBinding data, string? value) => {(data as MessageContact).PIN = value;}, (IBinding data) => (data as MessageContact).PIN )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, MessageValidated._StaticAllProperties);


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
	public new const string __Tag = "MessageContact";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageContact();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageContact FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageContact;
			}
		var Result = new MessageContact ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class GroupInvitation : Message {
        /// <summary>
        /// </summary>

	public virtual string?						Text  {get; set;}

        /// <summary>
        ///The contact data.
        /// </summary>

	public virtual Contact?						Contact  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new GroupInvitation(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as GroupInvitation).Text = value;}, (IBinding data) => (data as GroupInvitation).Text )},
			{ "Contact", new PropertyStruct ("Contact", 
					(IBinding data, object? value) => {(data as GroupInvitation).Contact = value as Contact;}, (IBinding data) => (data as GroupInvitation).Contact,
					true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "GroupInvitation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new GroupInvitation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new GroupInvitation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as GroupInvitation;
			}
		var Result = new GroupInvitation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageMail : Message {
        /// <summary>
        /// </summary>

	public virtual string?						Text  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageMail(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as MessageMail).Text = value;}, (IBinding data) => (data as MessageMail).Text )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageMail";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageMail();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageMail FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageMail;
			}
		var Result = new MessageMail ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class RequestConfirmation : Message {
        /// <summary>
        /// </summary>

	public virtual string?						Text  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new RequestConfirmation(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as RequestConfirmation).Text = value;}, (IBinding data) => (data as RequestConfirmation).Text )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "RequestConfirmation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RequestConfirmation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RequestConfirmation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RequestConfirmation;
			}
		var Result = new RequestConfirmation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ResponseConfirmation : Message {
        /// <summary>
        /// </summary>

	public virtual Enveloped<RequestConfirmation>?						Request  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						Accept  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ResponseConfirmation(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Request", new PropertyStruct ("Request", 
					(IBinding data, object? value) => {(data as ResponseConfirmation).Request = value as Enveloped<RequestConfirmation>;}, (IBinding data) => (data as ResponseConfirmation).Request,
					false, ()=>new  Enveloped<RequestConfirmation>(), ()=>new Enveloped<RequestConfirmation>())} ,
			{ "Accept", new PropertyBoolean ("Accept", 
					(IBinding data, bool? value) => {(data as ResponseConfirmation).Accept = value;}, (IBinding data) => (data as ResponseConfirmation).Accept )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "ResponseConfirmation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResponseConfirmation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResponseConfirmation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResponseConfirmation;
			}
		var Result = new ResponseConfirmation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class RequestTask : Message {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new RequestTask(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "RequestTask";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RequestTask();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RequestTask FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RequestTask;
			}
		var Result = new RequestTask ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageClaim : Message {
        /// <summary>
        /// </summary>

	public virtual string?						PublicationId  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ServiceAuthenticate  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						DeviceAuthenticate  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new MessageClaim(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicationId", new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as MessageClaim).PublicationId = value;}, (IBinding data) => (data as MessageClaim).PublicationId )},
			{ "ServiceAuthenticate", new PropertyString ("ServiceAuthenticate", 
					(IBinding data, string? value) => {(data as MessageClaim).ServiceAuthenticate = value;}, (IBinding data) => (data as MessageClaim).ServiceAuthenticate )},
			{ "DeviceAuthenticate", new PropertyString ("DeviceAuthenticate", 
					(IBinding data, string? value) => {(data as MessageClaim).DeviceAuthenticate = value;}, (IBinding data) => (data as MessageClaim).DeviceAuthenticate )},
			{ "Expires", new PropertyDateTime ("Expires", 
					(IBinding data, DateTime? value) => {(data as MessageClaim).Expires = value;}, (IBinding data) => (data as MessageClaim).Expires )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "MessageClaim";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MessageClaim();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new MessageClaim FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as MessageClaim;
			}
		var Result = new MessageClaim ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Report result of message processing.	
	/// </summary>
public partial class ProcessResult : Message {
        /// <summary>
        /// </summary>

	public virtual bool?						Success  {get; set;}

        /// <summary>
        ///The error report code.
        /// </summary>

	public virtual string?						ErrorReport  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProcessResult(), Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Success", new PropertyBoolean ("Success", 
					(IBinding data, bool? value) => {(data as ProcessResult).Success = value;}, (IBinding data) => (data as ProcessResult).Success )},
			{ "ErrorReport", new PropertyString ("ErrorReport", 
					(IBinding data, string? value) => {(data as ProcessResult).ErrorReport = value;}, (IBinding data) => (data as ProcessResult).ErrorReport )}
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


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
	public new const string __Tag = "ProcessResult";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResult();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResult FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResult;
			}
		var Result = new ProcessResult ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// The message type is not supported.
	/// </summary>
public partial class ProcessResultNotSupported : ProcessResult {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProcessResultNotSupported(), ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProcessResult._StaticAllProperties);


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
	public new const string __Tag = "ProcessResultNotSupported";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultNotSupported();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResultNotSupported FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResultNotSupported;
			}
		var Result = new ProcessResultNotSupported ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ProcessResultNotFound : ProcessResult {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			_StaticProperties, __Tag,() => new ProcessResultNotFound(), ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, ProcessResult._StaticAllProperties);


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
	public new const string __Tag = "ProcessResultNotFound";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ProcessResultNotFound();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ProcessResultNotFound FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ProcessResultNotFound;
			}
		var Result = new ProcessResultNotFound ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



