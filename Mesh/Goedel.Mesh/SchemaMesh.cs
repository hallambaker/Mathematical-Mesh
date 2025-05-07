
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
//  This file was automatically generated at 5/7/2025 1:23:12 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26100.0
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
	    {"ActivationApplicationDeveloper", ActivationApplicationDeveloper._Factory},
	    {"ActivationApplicationCredential", ActivationApplicationCredential._Factory},
	    {"ApplicationEntry", ApplicationEntry._Factory},
	    {"ApplicationEntrySsh", ApplicationEntrySsh._Factory},
	    {"ApplicationEntryGroup", ApplicationEntryGroup._Factory},
	    {"ApplicationEntryMail", ApplicationEntryMail._Factory},
	    {"ApplicationEntryDeveloper", ApplicationEntryDeveloper._Factory},
	    {"ApplicationEntryCredential", ApplicationEntryCredential._Factory},
	    {"Bookmark", Bookmark._Factory},
	    {"Reference", Reference._Factory},
	    {"Engagement", Engagement._Factory},
	    {"WorkTask", WorkTask._Factory},
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
	    {"CatalogedApplicationSsh", CatalogedApplicationSsh._Factory},
	    {"CatalogedApplicationCredential", CatalogedApplicationCredential._Factory},
	    {"CatalogedApplicationService", CatalogedApplicationService._Factory},
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


	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(KeyData), KeyData._binding},
	    {typeof(KeyShare), KeyShare._binding},
	    {typeof(CompositePrivate), CompositePrivate._binding},
	    {typeof(Assertion), Assertion._binding},
	    {typeof(Condition), Condition._binding},
	    {typeof(Activation), Activation._binding},
	    {typeof(ActivationEntry), ActivationEntry._binding},
	    {typeof(Profile), Profile._binding},
	    {typeof(ProfileDevice), ProfileDevice._binding},
	    {typeof(ProfileAccount), ProfileAccount._binding},
	    {typeof(ProfileUser), ProfileUser._binding},
	    {typeof(ProfileGroup), ProfileGroup._binding},
	    {typeof(ProfileService), ProfileService._binding},
	    {typeof(ProfileMeshService), ProfileMeshService._binding},
	    {typeof(ProfileHost), ProfileHost._binding},
	    {typeof(Connection), Connection._binding},
	    {typeof(CallsignBinding), CallsignBinding._binding},
	    {typeof(Accreditation), Accreditation._binding},
	    {typeof(ConnectionStripped), ConnectionStripped._binding},
	    {typeof(ConnectionService), ConnectionService._binding},
	    {typeof(ConnectionDevice), ConnectionDevice._binding},
	    {typeof(ConnectionApplication), ConnectionApplication._binding},
	    {typeof(ConnectionGroup), ConnectionGroup._binding},
	    {typeof(AccountHostAssignment), AccountHostAssignment._binding},
	    {typeof(ConnectionHost), ConnectionHost._binding},
	    {typeof(ActivationAccount), ActivationAccount._binding},
	    {typeof(ActivationHost), ActivationHost._binding},
	    {typeof(ActivationCommon), ActivationCommon._binding},
	    {typeof(ActivationApplication), ActivationApplication._binding},
	    {typeof(ActivationApplicationSsh), ActivationApplicationSsh._binding},
	    {typeof(ActivationApplicationMail), ActivationApplicationMail._binding},
	    {typeof(ActivationApplicationGroup), ActivationApplicationGroup._binding},
	    {typeof(ActivationApplicationDeveloper), ActivationApplicationDeveloper._binding},
	    {typeof(ActivationApplicationCredential), ActivationApplicationCredential._binding},
	    {typeof(ApplicationEntry), ApplicationEntry._binding},
	    {typeof(ApplicationEntrySsh), ApplicationEntrySsh._binding},
	    {typeof(ApplicationEntryGroup), ApplicationEntryGroup._binding},
	    {typeof(ApplicationEntryMail), ApplicationEntryMail._binding},
	    {typeof(ApplicationEntryDeveloper), ApplicationEntryDeveloper._binding},
	    {typeof(ApplicationEntryCredential), ApplicationEntryCredential._binding},
	    {typeof(Bookmark), Bookmark._binding},
	    {typeof(Reference), Reference._binding},
	    {typeof(Engagement), Engagement._binding},
	    {typeof(WorkTask), WorkTask._binding},
	    {typeof(CatalogedEntry), CatalogedEntry._binding},
	    {typeof(CatalogedDevice), CatalogedDevice._binding},
	    {typeof(DeviceDescription), DeviceDescription._binding},
	    {typeof(CatalogedSignature), CatalogedSignature._binding},
	    {typeof(CatalogedDocument), CatalogedDocument._binding},
	    {typeof(CatalogedPublication), CatalogedPublication._binding},
	    {typeof(CatalogedCredential), CatalogedCredential._binding},
	    {typeof(CatalogedNetwork), CatalogedNetwork._binding},
	    {typeof(CatalogedContact), CatalogedContact._binding},
	    {typeof(CatalogedAccess), CatalogedAccess._binding},
	    {typeof(Capability), Capability._binding},
	    {typeof(NullCapability), NullCapability._binding},
	    {typeof(AccessCapability), AccessCapability._binding},
	    {typeof(PublicationCapability), PublicationCapability._binding},
	    {typeof(CryptographicCapability), CryptographicCapability._binding},
	    {typeof(CapabilityDecrypt), CapabilityDecrypt._binding},
	    {typeof(CapabilityDecryptPartial), CapabilityDecryptPartial._binding},
	    {typeof(CapabilityDecryptServiced), CapabilityDecryptServiced._binding},
	    {typeof(CapabilitySign), CapabilitySign._binding},
	    {typeof(CapabilityKeyGenerate), CapabilityKeyGenerate._binding},
	    {typeof(CapabilityFairExchange), CapabilityFairExchange._binding},
	    {typeof(NamedService), NamedService._binding},
	    {typeof(ServiceAccessToken), ServiceAccessToken._binding},
	    {typeof(CatalogedBookmark), CatalogedBookmark._binding},
	    {typeof(CatalogedTask), CatalogedTask._binding},
	    {typeof(CatalogedApplication), CatalogedApplication._binding},
	    {typeof(CatalogedMember), CatalogedMember._binding},
	    {typeof(CatalogedGroup), CatalogedGroup._binding},
	    {typeof(CatalogedFeed), CatalogedFeed._binding},
	    {typeof(CatalogedApplicationMail), CatalogedApplicationMail._binding},
	    {typeof(CatalogedApplicationSsh), CatalogedApplicationSsh._binding},
	    {typeof(CatalogedApplicationCredential), CatalogedApplicationCredential._binding},
	    {typeof(CatalogedApplicationService), CatalogedApplicationService._binding},
	    {typeof(CatalogedApplicationDeveloper), CatalogedApplicationDeveloper._binding},
	    {typeof(MessageInvoice), MessageInvoice._binding},
	    {typeof(CatalogedReceipt), CatalogedReceipt._binding},
	    {typeof(CatalogedTicket), CatalogedTicket._binding},
	    {typeof(DevicePreconfigurationPublic), DevicePreconfigurationPublic._binding},
	    {typeof(DevicePreconfigurationPrivate), DevicePreconfigurationPrivate._binding},
	    {typeof(Message), Message._binding},
	    {typeof(MessageError), MessageError._binding},
	    {typeof(MessageComplete), MessageComplete._binding},
	    {typeof(MessageValidated), MessageValidated._binding},
	    {typeof(MessagePin), MessagePin._binding},
	    {typeof(RequestConnection), RequestConnection._binding},
	    {typeof(AcknowledgeConnection), AcknowledgeConnection._binding},
	    {typeof(RespondConnection), RespondConnection._binding},
	    {typeof(MessageContact), MessageContact._binding},
	    {typeof(GroupInvitation), GroupInvitation._binding},
	    {typeof(MessageMail), MessageMail._binding},
	    {typeof(RequestConfirmation), RequestConfirmation._binding},
	    {typeof(ResponseConfirmation), ResponseConfirmation._binding},
	    {typeof(RequestTask), RequestTask._binding},
	    {typeof(MessageClaim), MessageClaim._binding},
	    {typeof(ProcessResult), ProcessResult._binding},
	    {typeof(ProcessResultNotSupported), ProcessResultNotSupported._binding},
	    {typeof(ProcessResultNotFound), ProcessResultNotFound._binding}
		};



	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static MeshItem() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _tagDictionary);
		AddDictionary(ref _bindingDictionary);
		}


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

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;}

        /// <summary>
        ///List of X.509 Certificates
        /// </summary>

	[JsonPropertyName("X509Certificate")]
	public virtual byte[]?					X509Certificate  {get; set;}

        /// <summary>
        ///X.509 Certificate chain.
        /// </summary>

	[JsonPropertyName("X509Chain")]
	public virtual List<byte[]>?					X509Chain  {get; set;}
        /// <summary>
        ///X.509 Certificate Signing Request.
        /// </summary>

	[JsonPropertyName("X509CSR")]
	public virtual byte[]?					X509CSR  {get; set;}

        /// <summary>
        ///If present specifies a time instant that use of the private key
        ///is not valid before.
        /// </summary>

	[JsonPropertyName("NotBefore")]
	public virtual DateTime?					NotBefore  {get; set;}

        /// <summary>
        ///If present specifies a time instant that use of the private key
        ///is not valid on or after.
        /// </summary>

	[JsonPropertyName("NotOnOrAfter")]
	public virtual DateTime?					NotOnOrAfter  {get; set;}

        /// <summary>
        ///The public key parameters as defined in the JOSE specification.
        /// </summary>

	[JsonPropertyName("PublicParameters")]
	public virtual Key?					PublicParameters  {get; set;}

        /// <summary>
        ///The private key parameters as defined in the JOSE specification.
        /// </summary>

	[JsonPropertyName("PrivateParameters")]
	public virtual Key?					PrivateParameters  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyData> _binding = new (
			new() {

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
			{ "PublicParameters", new PropertyStruct ("PublicParameters", typeof (Key), 
					(IBinding data, object? value) => {(data as KeyData).PublicParameters = value as Key;}, (IBinding data) => (data as KeyData).PublicParameters,
					true)} ,
			{ "PrivateParameters", new PropertyStruct ("PrivateParameters", typeof (Key), 
					(IBinding data, object? value) => {(data as KeyData).PrivateParameters = value as Key;}, (IBinding data) => (data as KeyData).PrivateParameters,
					true)} 
        }, __Tag,() => new KeyData(), () => new List<KeyData>(), () => new Dictionary<string,KeyData>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("PublicPrimary")]
	public virtual Key?					PublicPrimary  {get; set;}

        /// <summary>
        ///The private key parameters of the share as defined in the JOSE specification.		
        /// </summary>

	[JsonPropertyName("Share")]
	public virtual Key?					Share  {get; set;}

        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial key.]
        /// </summary>

	[JsonPropertyName("ServiceId")]
	public virtual string?					ServiceId  {get; set;}

        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial key.]	
        /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyShare> _binding = new (
			new() {

			{ "PublicPrimary", new PropertyStruct ("PublicPrimary", typeof (Key), 
					(IBinding data, object? value) => {(data as KeyShare).PublicPrimary = value as Key;}, (IBinding data) => (data as KeyShare).PublicPrimary,
					true)} ,
			{ "Share", new PropertyStruct ("Share", typeof (Key), 
					(IBinding data, object? value) => {(data as KeyShare).Share = value as Key;}, (IBinding data) => (data as KeyShare).Share,
					true)} ,
			{ "ServiceId", new PropertyString ("ServiceId", 
					(IBinding data, string? value) => {(data as KeyShare).ServiceId = value;}, (IBinding data) => (data as KeyShare).ServiceId )},
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as KeyShare).ServiceAddress = value;}, (IBinding data) => (data as KeyShare).ServiceAddress )}
        }, __Tag,() => new KeyShare(), () => new List<KeyShare>(), () => new Dictionary<string,KeyShare>(),Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Key._binding, _binding);


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

	[JsonPropertyName("DeviceKeyUdf")]
	public virtual string?					DeviceKeyUdf  {get; set;}

        /// <summary>
        ///Private parameters of additive key
        /// </summary>

	[JsonPropertyName("PrivateSalt")]
	public virtual Key?					PrivateSalt  {get; set;}

        /// <summary>
        ///Private parameters of serviced share
        /// </summary>

	[JsonPropertyName("ServiceShare")]
	public virtual Key?					ServiceShare  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompositePrivate> _binding = new (
			new() {

			{ "DeviceKeyUdf", new PropertyString ("DeviceKeyUdf", 
					(IBinding data, string? value) => {(data as CompositePrivate).DeviceKeyUdf = value;}, (IBinding data) => (data as CompositePrivate).DeviceKeyUdf )},
			{ "PrivateSalt", new PropertyStruct ("PrivateSalt", typeof (Key), 
					(IBinding data, object? value) => {(data as CompositePrivate).PrivateSalt = value as Key;}, (IBinding data) => (data as CompositePrivate).PrivateSalt,
					true)} ,
			{ "ServiceShare", new PropertyStruct ("ServiceShare", typeof (Key), 
					(IBinding data, object? value) => {(data as CompositePrivate).ServiceShare = value as Key;}, (IBinding data) => (data as CompositePrivate).ServiceShare,
					true)} 
        }, __Tag,() => new CompositePrivate(), () => new List<CompositePrivate>(), () => new Dictionary<string,CompositePrivate>(),Key._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Key._binding, _binding);


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

	[JsonPropertyName("Names")]
	public virtual List<string>?					Names  {get; set;}
        /// <summary>
        ///The time instant the profile was last modified.
        /// </summary>

	[JsonPropertyName("Updated")]
	public virtual DateTime?					Updated  {get; set;}

        /// <summary>
        ///A Uniform Notary Token providing evidence that a signature
        ///was performed after the notary token was created.
        /// </summary>

	[JsonPropertyName("NotaryToken")]
	public virtual string?					NotaryToken  {get; set;}

        /// <summary>
        ///Conditional clause(s) that MAY be verified to evaluate the validity of the
        ///assertion. At present no condition classes are specified.
        /// </summary>

	[JsonPropertyName("Conditions")]
	public virtual Condition?					Conditions  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Assertion> _binding = new (
			new() {

			{ "Names", new PropertyListString ("Names", 
					(IBinding data, List<string>? value) => {(data as Assertion).Names = value;}, (IBinding data) => (data as Assertion).Names )},
			{ "Updated", new PropertyDateTime ("Updated", 
					(IBinding data, DateTime? value) => {(data as Assertion).Updated = value;}, (IBinding data) => (data as Assertion).Updated )},
			{ "NotaryToken", new PropertyString ("NotaryToken", 
					(IBinding data, string? value) => {(data as Assertion).NotaryToken = value;}, (IBinding data) => (data as Assertion).NotaryToken )},
			{ "Conditions", new PropertyStruct ("Conditions", typeof (Condition), 
					(IBinding data, object? value) => {(data as Assertion).Conditions = value as Condition;}, (IBinding data) => (data as Assertion).Conditions,
					true)} 
        }, __Tag,null, null, null,null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public static readonly new Binding<Condition> _binding = new (
			new() {

        }, __Tag,null, null, null,null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("ActivationKey")]
	public virtual string?					ActivationKey  {get; set;}

        /// <summary>
        ///Activation of named account resource activations. These are separate from
        ///Application activations which are 
        /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<ActivationEntry>?					Entries  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Activation> _binding = new (
			new() {

			{ "ActivationKey", new PropertyString ("ActivationKey", 
					(IBinding data, string? value) => {(data as Activation).ActivationKey = value;}, (IBinding data) => (data as Activation).ActivationKey )},
			{ "Entries", new PropertyListStruct ("Entries", typeof (ActivationEntry),
					(IBinding data, object? value) => {(data as Activation).Entries = value as List<ActivationEntry>;}, (IBinding data) => (data as Activation).Entries,
					false, ()=>new  List<ActivationEntry>(), ()=>new ActivationEntry())}
        }, __Tag,() => new Activation(), () => new List<Activation>(), () => new Dictionary<string,Activation>(),Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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

	[JsonPropertyName("Resource")]
	public virtual string?					Resource  {get; set;}

        /// <summary>
        ///The activation key or key share
        /// </summary>

	[JsonPropertyName("Key")]
	public virtual KeyData?					Key  {get; set;}

        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial capability.]
        /// </summary>

	[JsonPropertyName("ServiceId")]
	public virtual string?					ServiceId  {get; set;}

        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial capability.]
        /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationEntry> _binding = new (
			new() {

			{ "Resource", new PropertyString ("Resource", 
					(IBinding data, string? value) => {(data as ActivationEntry).Resource = value;}, (IBinding data) => (data as ActivationEntry).Resource )},
			{ "Key", new PropertyStruct ("Key", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationEntry).Key = value as KeyData;}, (IBinding data) => (data as ActivationEntry).Key,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "ServiceId", new PropertyString ("ServiceId", 
					(IBinding data, string? value) => {(data as ActivationEntry).ServiceId = value;}, (IBinding data) => (data as ActivationEntry).ServiceId )},
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as ActivationEntry).ServiceAddress = value;}, (IBinding data) => (data as ActivationEntry).ServiceAddress )}
        }, __Tag,() => new ActivationEntry(), () => new List<ActivationEntry>(), () => new Dictionary<string,ActivationEntry>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("Description")]
	public virtual string?					Description  {get; set;}

        /// <summary>
        ///A list of binary UDF fingerprints of accepted root signature keys for the profile.
        ///The profile finderprint is calculated over the concatenation of the
        ///fingerprint URIs.
        /// </summary>

	[JsonPropertyName("RootUdfs")]
	public virtual List<byte[]>?					RootUdfs  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Profile> _binding = new (
			new() {

			{ "Description", new PropertyString ("Description", 
					(IBinding data, string? value) => {(data as Profile).Description = value;}, (IBinding data) => (data as Profile).Description )},
			{ "RootUdfs", new PropertyListBinary ("RootUdfs", 
					(IBinding data, List<byte[]>? value) => {(data as Profile).RootUdfs = value;}, (IBinding data) => (data as Profile).RootUdfs )}
        }, __Tag,null, null, null,Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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

	[JsonPropertyName("Encryption")]
	public virtual KeyData?					Encryption  {get; set;}

        /// <summary>
        ///Base key contribution for signature keys. 
        /// </summary>

	[JsonPropertyName("Signature")]
	public virtual KeyData?					Signature  {get; set;}

        /// <summary>
        ///Base key contribution for authentication keys. 
        ///Also used to authenticate the device
        ///during connection to an account.
        /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileDevice> _binding = new (
			new() {

			{ "Encryption", new PropertyStruct ("Encryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileDevice).Encryption = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Signature", new PropertyStruct ("Signature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileDevice).Signature = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Authentication", new PropertyStruct ("Authentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileDevice).Authentication = value as KeyData;}, (IBinding data) => (data as ProfileDevice).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ProfileDevice(), () => new List<ProfileDevice>(), () => new Dictionary<string,ProfileDevice>(),Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Profile._binding, _binding);


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
        ///The account address. This is an account service address 
        ///(e.g. alice@example.com).
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        ///The canonical DNS handle for the account (e.g. @alice.alt).
        /// </summary>

	[JsonPropertyName("AccountHandle")]
	public virtual string?					AccountHandle  {get; set;}

        /// <summary>
        ///The fingerprint of the service profile to which the account is
        ///currently bound.
        /// </summary>

	[JsonPropertyName("ServiceUdf")]
	public virtual string?					ServiceUdf  {get; set;}

        /// <summary>
        ///Escrow key associated with the account.
        /// </summary>

	[JsonPropertyName("EscrowEncryption")]
	public virtual KeyData?					EscrowEncryption  {get; set;}

        /// <summary>
        ///Key used to sign connection assertions to the account.
        /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;}

        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	[JsonPropertyName("CommonEncryption")]
	public virtual KeyData?					CommonEncryption  {get; set;}

        /// <summary>
        ///Key used to authenticate requests made under this user account.
        ///This key SHOULD NOT be provisioned to any device except for the
        ///purpose of enabling account recovery.
        /// </summary>

	[JsonPropertyName("CommonAuthentication")]
	public virtual KeyData?					CommonAuthentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileAccount> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as ProfileAccount).AccountAddress = value;}, (IBinding data) => (data as ProfileAccount).AccountAddress )},
			{ "AccountHandle", new PropertyString ("AccountHandle", 
					(IBinding data, string? value) => {(data as ProfileAccount).AccountHandle = value;}, (IBinding data) => (data as ProfileAccount).AccountHandle )},
			{ "ServiceUdf", new PropertyString ("ServiceUdf", 
					(IBinding data, string? value) => {(data as ProfileAccount).ServiceUdf = value;}, (IBinding data) => (data as ProfileAccount).ServiceUdf )},
			{ "EscrowEncryption", new PropertyStruct ("EscrowEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileAccount).EscrowEncryption = value as KeyData;}, (IBinding data) => (data as ProfileAccount).EscrowEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileAccount).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ProfileAccount).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "CommonEncryption", new PropertyStruct ("CommonEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileAccount).CommonEncryption = value as KeyData;}, (IBinding data) => (data as ProfileAccount).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "CommonAuthentication", new PropertyStruct ("CommonAuthentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileAccount).CommonAuthentication = value as KeyData;}, (IBinding data) => (data as ProfileAccount).CommonAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ProfileAccount(), () => new List<ProfileAccount>(), () => new Dictionary<string,ProfileAccount>(),Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Profile._binding, _binding);


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

	[JsonPropertyName("CommonSignature")]
	public virtual KeyData?					CommonSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileUser> _binding = new (
			new() {

			{ "CommonSignature", new PropertyStruct ("CommonSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileUser).CommonSignature = value as KeyData;}, (IBinding data) => (data as ProfileUser).CommonSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ProfileUser(), () => new List<ProfileUser>(), () => new Dictionary<string,ProfileUser>(),ProfileAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProfileAccount._binding, _binding);


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

	[JsonPropertyName("Cover")]
	public virtual byte[]?					Cover  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileGroup> _binding = new (
			new() {

			{ "Cover", new PropertyBinary ("Cover", 
					(IBinding data, byte[]? value) => {(data as ProfileGroup).Cover = value;}, (IBinding data) => (data as ProfileGroup).Cover )}
        }, __Tag,() => new ProfileGroup(), () => new List<ProfileGroup>(), () => new Dictionary<string,ProfileGroup>(),ProfileAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProfileAccount._binding, _binding);


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

	[JsonPropertyName("ServiceAuthentication")]
	public virtual KeyData?					ServiceAuthentication  {get; set;}

        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

	[JsonPropertyName("ServiceEncryption")]
	public virtual KeyData?					ServiceEncryption  {get; set;}

        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

	[JsonPropertyName("ServiceSignature")]
	public virtual KeyData?					ServiceSignature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileService> _binding = new (
			new() {

			{ "ServiceAuthentication", new PropertyStruct ("ServiceAuthentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileService).ServiceAuthentication = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "ServiceEncryption", new PropertyStruct ("ServiceEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileService).ServiceEncryption = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "ServiceSignature", new PropertyStruct ("ServiceSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ProfileService).ServiceSignature = value as KeyData;}, (IBinding data) => (data as ProfileService).ServiceSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ProfileService(), () => new List<ProfileService>(), () => new Dictionary<string,ProfileService>(),Profile._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Profile._binding, _binding);


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
	public static readonly new Binding<ProfileMeshService> _binding = new (
			new() {

        }, __Tag,() => new ProfileMeshService(), () => new List<ProfileMeshService>(), () => new Dictionary<string,ProfileMeshService>(),ProfileService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProfileService._binding, _binding);


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
	public static readonly new Binding<ProfileHost> _binding = new (
			new() {

        }, __Tag,() => new ProfileHost(), () => new List<ProfileHost>(), () => new Dictionary<string,ProfileHost>(),ProfileDevice._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProfileDevice._binding, _binding);


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

	[JsonPropertyName("Subject")]
	public virtual string?					Subject  {get; set;}

        /// <summary>
        ///UDF of the connection source.
        /// </summary>

	[JsonPropertyName("Authority")]
	public virtual string?					Authority  {get; set;}

        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Connection> _binding = new (
			new() {

			{ "Subject", new PropertyString ("Subject", 
					(IBinding data, string? value) => {(data as Connection).Subject = value;}, (IBinding data) => (data as Connection).Subject )},
			{ "Authority", new PropertyString ("Authority", 
					(IBinding data, string? value) => {(data as Connection).Authority = value;}, (IBinding data) => (data as Connection).Authority )},
			{ "Authentication", new PropertyStruct ("Authentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as Connection).Authentication = value as KeyData;}, (IBinding data) => (data as Connection).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new Connection(), () => new List<Connection>(), () => new Dictionary<string,Connection>(),Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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

	[JsonPropertyName("Canonical")]
	public virtual string?					Canonical  {get; set;}

        /// <summary>
        ///The display form of the callsign. This MAY include characters such as whitespace,
        ///trademark signifiers, etc. that are omitted of trranslated in the canonical form.
        /// </summary>

	[JsonPropertyName("Display")]
	public virtual string?					Display  {get; set;}

        /// <summary>
        ///Specifies the page to which the Description"CharacterPageLatin"
        /// </summary>

	[JsonPropertyName("CharacterPage")]
	public virtual string?					CharacterPage  {get; set;}

        /// <summary>
        ///The profile to which the name is bound.
        /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;}

        /// <summary>
        ///The profile to which the name has been transfered.
        /// </summary>

	[JsonPropertyName("TransferUdf")]
	public virtual string?					TransferUdf  {get; set;}

        /// <summary>
        ///List of named services. If multiple service providers are specified for a given 
        ///service, these are listed in order of priority, most preferred first.
        /// </summary>

	[JsonPropertyName("Services")]
	public virtual List<NamedService>?					Services  {get; set;}
        /// <summary>
        ///The Mesh service address. 
        /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;}

        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	[JsonPropertyName("CommonEncryption")]
	public virtual KeyData?					CommonEncryption  {get; set;}

        /// <summary>
        ///Self signed certificate signing certificate to be used as a root of
        ///trust for PKIX certificates under this callsign.
        /// </summary>

	[JsonPropertyName("PkixRoot")]
	public virtual byte[]?					PkixRoot  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CallsignBinding> _binding = new (
			new() {

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
			{ "Services", new PropertyListStruct ("Services", typeof (NamedService),
					(IBinding data, object? value) => {(data as CallsignBinding).Services = value as List<NamedService>;}, (IBinding data) => (data as CallsignBinding).Services,
					false, ()=>new  List<NamedService>(), ()=>new NamedService())},
			{ "ServiceAddress", new PropertyString ("ServiceAddress", 
					(IBinding data, string? value) => {(data as CallsignBinding).ServiceAddress = value;}, (IBinding data) => (data as CallsignBinding).ServiceAddress )},
			{ "CommonEncryption", new PropertyStruct ("CommonEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as CallsignBinding).CommonEncryption = value as KeyData;}, (IBinding data) => (data as CallsignBinding).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "PkixRoot", new PropertyBinary ("PkixRoot", 
					(IBinding data, byte[]? value) => {(data as CallsignBinding).PkixRoot = value;}, (IBinding data) => (data as CallsignBinding).PkixRoot )}
        }, __Tag,() => new CallsignBinding(), () => new List<CallsignBinding>(), () => new Dictionary<string,CallsignBinding>(),Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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

	[JsonPropertyName("Callsign")]
	public virtual string?					Callsign  {get; set;}

        /// <summary>
        ///The profile to which the accreditation applies.
        /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;}

        /// <summary>
        ///The validated names of the subject
        /// </summary>

	[JsonPropertyName("SubjectNames")]
	public virtual List<string>?					SubjectNames  {get; set;}
        /// <summary>
        ///Mesh strong URIs from which a validated logo belonging to the 
        ///subject MAY be retreived and validated.
        /// </summary>

	[JsonPropertyName("SubjectLogos")]
	public virtual List<string>?					SubjectLogos  {get; set;}
        /// <summary>
        ///The time the assertion was issued.
        /// </summary>

	[JsonPropertyName("Issued")]
	public virtual DateTime?					Issued  {get; set;}

        /// <summary>
        ///The time the assertion is due to expire
        /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;}

        /// <summary>
        ///The issuing policy under which the validation was performed.
        /// </summary>

	[JsonPropertyName("Policy")]
	public virtual string?					Policy  {get; set;}

        /// <summary>
        ///The issuing practices under which the validation was performed.
        /// </summary>

	[JsonPropertyName("Practice")]
	public virtual string?					Practice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Accreditation> _binding = new (
			new() {

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
        }, __Tag,() => new Accreditation(), () => new List<Accreditation>(), () => new Dictionary<string,Accreditation>(),Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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

	[JsonPropertyName("Account")]
	public virtual string?					Account  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionStripped> _binding = new (
			new() {

			{ "Account", new PropertyString ("Account", 
					(IBinding data, string? value) => {(data as ConnectionStripped).Account = value;}, (IBinding data) => (data as ConnectionStripped).Account )}
        }, __Tag,() => new ConnectionStripped(), () => new List<ConnectionStripped>(), () => new Dictionary<string,ConnectionStripped>(),Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Connection._binding, _binding);


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

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionService> _binding = new (
			new() {

			{ "ProfileUdf", new PropertyString ("ProfileUdf", 
					(IBinding data, string? value) => {(data as ConnectionService).ProfileUdf = value;}, (IBinding data) => (data as ConnectionService).ProfileUdf )}
        }, __Tag,() => new ConnectionService(), () => new List<ConnectionService>(), () => new Dictionary<string,ConnectionService>(),Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Connection._binding, _binding);


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

	[JsonPropertyName("Roles")]
	public virtual List<string>?					Roles  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

	[JsonPropertyName("Signature")]
	public virtual KeyData?					Signature  {get; set;}

        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

	[JsonPropertyName("Encryption")]
	public virtual KeyData?					Encryption  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionDevice> _binding = new (
			new() {

			{ "Roles", new PropertyListString ("Roles", 
					(IBinding data, List<string>? value) => {(data as ConnectionDevice).Roles = value;}, (IBinding data) => (data as ConnectionDevice).Roles )},
			{ "Signature", new PropertyStruct ("Signature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ConnectionDevice).Signature = value as KeyData;}, (IBinding data) => (data as ConnectionDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Encryption", new PropertyStruct ("Encryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ConnectionDevice).Encryption = value as KeyData;}, (IBinding data) => (data as ConnectionDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ConnectionDevice(), () => new List<ConnectionDevice>(), () => new Dictionary<string,ConnectionDevice>(),ConnectionService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ConnectionService._binding, _binding);


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
	public static readonly new Binding<ConnectionApplication> _binding = new (
			new() {

        }, __Tag,() => new ConnectionApplication(), () => new List<ConnectionApplication>(), () => new Dictionary<string,ConnectionApplication>(),Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Connection._binding, _binding);


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
	public static readonly new Binding<ConnectionGroup> _binding = new (
			new() {

        }, __Tag,() => new ConnectionGroup(), () => new List<ConnectionGroup>(), () => new Dictionary<string,ConnectionGroup>(),Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Connection._binding, _binding);


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

	[JsonPropertyName("AccountAddess")]
	public virtual string?					AccountAddess  {get; set;}

        /// <summary>
        ///Host address in Callsign, DNS or IP format in order of preference.
        /// </summary>

	[JsonPropertyName("HostAddresses")]
	public virtual List<string>?					HostAddresses  {get; set;}
        /// <summary>
        ///Encryption key to be used to encrypt data for the service to use.
        /// </summary>

	[JsonPropertyName("AccessEncrypt")]
	public virtual KeyData?					AccessEncrypt  {get; set;}

        /// <summary>
        ///Profile of the callsign registry used by the service.
        /// </summary>

	[JsonPropertyName("CallsignServiceProfile")]
	public virtual ProfileAccount?					CallsignServiceProfile  {get; set;}

        /// <summary>
        ///Profile of the service.
        /// </summary>

	[JsonPropertyName("EnvelopedProfileService")]
	public virtual Enveloped<ProfileService>?					EnvelopedProfileService  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccountHostAssignment> _binding = new (
			new() {

			{ "AccountAddess", new PropertyString ("AccountAddess", 
					(IBinding data, string? value) => {(data as AccountHostAssignment).AccountAddess = value;}, (IBinding data) => (data as AccountHostAssignment).AccountAddess )},
			{ "HostAddresses", new PropertyListString ("HostAddresses", 
					(IBinding data, List<string>? value) => {(data as AccountHostAssignment).HostAddresses = value;}, (IBinding data) => (data as AccountHostAssignment).HostAddresses )},
			{ "AccessEncrypt", new PropertyStruct ("AccessEncrypt", typeof (KeyData),
					(IBinding data, object? value) => {(data as AccountHostAssignment).AccessEncrypt = value as KeyData;}, (IBinding data) => (data as AccountHostAssignment).AccessEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "CallsignServiceProfile", new PropertyStruct ("CallsignServiceProfile", typeof (ProfileAccount),
					(IBinding data, object? value) => {(data as AccountHostAssignment).CallsignServiceProfile = value as ProfileAccount;}, (IBinding data) => (data as AccountHostAssignment).CallsignServiceProfile,
					false, ()=>new  ProfileAccount(), ()=>new ProfileAccount())},
			{ "EnvelopedProfileService", new PropertyStruct ("EnvelopedProfileService", typeof (Enveloped<ProfileService>),
					(IBinding data, object? value) => {(data as AccountHostAssignment).EnvelopedProfileService = value as Enveloped<ProfileService>;}, (IBinding data) => (data as AccountHostAssignment).EnvelopedProfileService,
					false, ()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>())}
        }, __Tag,() => new AccountHostAssignment(), () => new List<AccountHostAssignment>(), () => new Dictionary<string,AccountHostAssignment>(),Assertion._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Assertion._binding, _binding);


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
	public static readonly new Binding<ConnectionHost> _binding = new (
			new() {

        }, __Tag,() => new ConnectionHost(), () => new List<ConnectionHost>(), () => new Dictionary<string,ConnectionHost>(),Connection._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Connection._binding, _binding);


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

	[JsonPropertyName("AccountUdf")]
	public virtual string?					AccountUdf  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationAccount> _binding = new (
			new() {

			{ "AccountUdf", new PropertyString ("AccountUdf", 
					(IBinding data, string? value) => {(data as ActivationAccount).AccountUdf = value;}, (IBinding data) => (data as ActivationAccount).AccountUdf )}
        }, __Tag,() => new ActivationAccount(), () => new List<ActivationAccount>(), () => new Dictionary<string,ActivationAccount>(),Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Activation._binding, _binding);


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
	public static readonly new Binding<ActivationHost> _binding = new (
			new() {

        }, __Tag,() => new ActivationHost(), () => new List<ActivationHost>(), () => new Dictionary<string,ActivationHost>(),ActivationAccount._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationAccount._binding, _binding);


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

	[JsonPropertyName("ProfileSignatures")]
	public virtual List<KeyData>?					ProfileSignatures  {get; set;}
        /// <summary>
        ///Grant access to Profile administration key used to make changes to
        ///administrator catalogs.
        /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account encryption key
        /// </summary>

	[JsonPropertyName("Encryption")]
	public virtual KeyData?					Encryption  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account authentication key
        /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;}

        /// <summary>
        ///Grant access to ProfileUser account signature key
        /// </summary>

	[JsonPropertyName("Signature")]
	public virtual KeyData?					Signature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationCommon> _binding = new (
			new() {

			{ "ProfileSignatures", new PropertyListStruct ("ProfileSignatures", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationCommon).ProfileSignatures = value as List<KeyData>;}, (IBinding data) => (data as ActivationCommon).ProfileSignatures,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())},
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationCommon).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ActivationCommon).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Encryption", new PropertyStruct ("Encryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationCommon).Encryption = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Authentication", new PropertyStruct ("Authentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationCommon).Authentication = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Signature", new PropertyStruct ("Signature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationCommon).Signature = value as KeyData;}, (IBinding data) => (data as ActivationCommon).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ActivationCommon(), () => new List<ActivationCommon>(), () => new Dictionary<string,ActivationCommon>(),Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Activation._binding, _binding);


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
	public static readonly new Binding<ActivationApplication> _binding = new (
			new() {

        }, __Tag,() => new ActivationApplication(), () => new List<ActivationApplication>(), () => new Dictionary<string,ActivationApplication>(),Activation._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Activation._binding, _binding);


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

	[JsonPropertyName("ClientKey")]
	public virtual KeyData?					ClientKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationSsh> _binding = new (
			new() {

			{ "ClientKey", new PropertyStruct ("ClientKey", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationSsh).ClientKey = value as KeyData;}, (IBinding data) => (data as ActivationApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ActivationApplicationSsh(), () => new List<ActivationApplicationSsh>(), () => new Dictionary<string,ActivationApplicationSsh>(),ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationApplication._binding, _binding);


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

	[JsonPropertyName("SmimeSign")]
	public virtual KeyData?					SmimeSign  {get; set;}

        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	[JsonPropertyName("SmimeEncrypt")]
	public virtual KeyData?					SmimeEncrypt  {get; set;}

        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	[JsonPropertyName("OpenpgpSign")]
	public virtual KeyData?					OpenpgpSign  {get; set;}

        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	[JsonPropertyName("OpenpgpEncrypt")]
	public virtual KeyData?					OpenpgpEncrypt  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationMail> _binding = new (
			new() {

			{ "SmimeSign", new PropertyStruct ("SmimeSign", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationMail).SmimeSign = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "SmimeEncrypt", new PropertyStruct ("SmimeEncrypt", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationMail).SmimeEncrypt = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "OpenpgpSign", new PropertyStruct ("OpenpgpSign", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationMail).OpenpgpSign = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "OpenpgpEncrypt", new PropertyStruct ("OpenpgpEncrypt", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationMail).OpenpgpEncrypt = value as KeyData;}, (IBinding data) => (data as ActivationApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new ActivationApplicationMail(), () => new List<ActivationApplicationMail>(), () => new Dictionary<string,ActivationApplicationMail>(),ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationApplication._binding, _binding);


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

	[JsonPropertyName("AccountEncryption")]
	public virtual KeyData?					AccountEncryption  {get; set;}

        /// <summary>
        ///Key or capability allowing account updates, connection assertions
        ///etc to be signed.
        /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;}

        /// <summary>
        ///Key or capability allowing administration of the group.
        /// </summary>

	[JsonPropertyName("AccountAuthentication")]
	public virtual KeyData?					AccountAuthentication  {get; set;}

        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationGroup> _binding = new (
			new() {

			{ "AccountEncryption", new PropertyStruct ("AccountEncryption", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AccountEncryption = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "AdministratorSignature", new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AdministratorSignature = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "AccountAuthentication", new PropertyStruct ("AccountAuthentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).AccountAuthentication = value as KeyData;}, (IBinding data) => (data as ActivationApplicationGroup).AccountAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", typeof (Enveloped<ConnectionService>),
					(IBinding data, object? value) => {(data as ActivationApplicationGroup).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as ActivationApplicationGroup).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())}
        }, __Tag,() => new ActivationApplicationGroup(), () => new List<ActivationApplicationGroup>(), () => new Dictionary<string,ActivationApplicationGroup>(),ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationApplication._binding, _binding);


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
public partial class ActivationApplicationDeveloper : ActivationApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationDeveloper> _binding = new (
			new() {

        }, __Tag,() => new ActivationApplicationDeveloper(), () => new List<ActivationApplicationDeveloper>(), () => new Dictionary<string,ActivationApplicationDeveloper>(),ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationApplication._binding, _binding);


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
	public new const string __Tag = "ActivationApplicationDeveloper";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationDeveloper();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationDeveloper FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationDeveloper;
			}
		var Result = new ActivationApplicationDeveloper ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationCredential : ActivationApplication {


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationCredential> _binding = new (
			new() {

        }, __Tag,() => new ActivationApplicationCredential(), () => new List<ActivationApplicationCredential>(), () => new Dictionary<string,ActivationApplicationCredential>(),ActivationApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ActivationApplication._binding, _binding);


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
	public new const string __Tag = "ActivationApplicationCredential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationCredential;
			}
		var Result = new ActivationApplicationCredential ();
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

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntry> _binding = new (
			new() {

			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as ApplicationEntry).Identifier = value;}, (IBinding data) => (data as ApplicationEntry).Identifier )}
        }, __Tag,null, null, null,null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationSsh>?					EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntrySsh> _binding = new (
			new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationSsh>),
					(IBinding data, object? value) => {(data as ApplicationEntrySsh).EnvelopedActivation = value as Enveloped<ActivationApplicationSsh>;}, (IBinding data) => (data as ApplicationEntrySsh).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationSsh>(), ()=>new Enveloped<ActivationApplicationSsh>())}
        }, __Tag,() => new ApplicationEntrySsh(), () => new List<ApplicationEntrySsh>(), () => new Dictionary<string,ApplicationEntrySsh>(),ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ApplicationEntry._binding, _binding);


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

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationGroup>?					EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryGroup> _binding = new (
			new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationGroup>),
					(IBinding data, object? value) => {(data as ApplicationEntryGroup).EnvelopedActivation = value as Enveloped<ActivationApplicationGroup>;}, (IBinding data) => (data as ApplicationEntryGroup).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationGroup>(), ()=>new Enveloped<ActivationApplicationGroup>())}
        }, __Tag,() => new ApplicationEntryGroup(), () => new List<ApplicationEntryGroup>(), () => new Dictionary<string,ApplicationEntryGroup>(),ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ApplicationEntry._binding, _binding);


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

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationMail>?					EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryMail> _binding = new (
			new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationMail>),
					(IBinding data, object? value) => {(data as ApplicationEntryMail).EnvelopedActivation = value as Enveloped<ActivationApplicationMail>;}, (IBinding data) => (data as ApplicationEntryMail).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationMail>(), ()=>new Enveloped<ActivationApplicationMail>())}
        }, __Tag,() => new ApplicationEntryMail(), () => new List<ApplicationEntryMail>(), () => new Dictionary<string,ApplicationEntryMail>(),ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ApplicationEntry._binding, _binding);


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
	/// </summary>
public partial class ApplicationEntryDeveloper : ApplicationEntry {
        /// <summary>
        /// </summary>

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationDeveloper>?					EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryDeveloper> _binding = new (
			new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationDeveloper>),
					(IBinding data, object? value) => {(data as ApplicationEntryDeveloper).EnvelopedActivation = value as Enveloped<ActivationApplicationDeveloper>;}, (IBinding data) => (data as ApplicationEntryDeveloper).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationDeveloper>(), ()=>new Enveloped<ActivationApplicationDeveloper>())}
        }, __Tag,() => new ApplicationEntryDeveloper(), () => new List<ApplicationEntryDeveloper>(), () => new Dictionary<string,ApplicationEntryDeveloper>(),ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ApplicationEntry._binding, _binding);


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
	public new const string __Tag = "ApplicationEntryDeveloper";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryDeveloper();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryDeveloper FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryDeveloper;
			}
		var Result = new ApplicationEntryDeveloper ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryCredential : ApplicationEntry {
        /// <summary>
        /// </summary>

	[JsonPropertyName("EnvelopedActivation")]
	public virtual Enveloped<ActivationApplicationCredential>?					EnvelopedActivation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryCredential> _binding = new (
			new() {

			{ "EnvelopedActivation", new PropertyStruct ("EnvelopedActivation", typeof (Enveloped<ActivationApplicationCredential>),
					(IBinding data, object? value) => {(data as ApplicationEntryCredential).EnvelopedActivation = value as Enveloped<ActivationApplicationCredential>;}, (IBinding data) => (data as ApplicationEntryCredential).EnvelopedActivation,
					false, ()=>new  Enveloped<ActivationApplicationCredential>(), ()=>new Enveloped<ActivationApplicationCredential>())}
        }, __Tag,() => new ApplicationEntryCredential(), () => new List<ApplicationEntryCredential>(), () => new Dictionary<string,ApplicationEntryCredential>(),ApplicationEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ApplicationEntry._binding, _binding);


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
	public new const string __Tag = "ApplicationEntryCredential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryCredential;
			}
		var Result = new ApplicationEntryCredential ();
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

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Role")]
	public virtual List<string>?					Role  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Bookmark> _binding = new (
			new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as Bookmark).Uri = value;}, (IBinding data) => (data as Bookmark).Uri )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as Bookmark).Title = value;}, (IBinding data) => (data as Bookmark).Title )},
			{ "Role", new PropertyListString ("Role", 
					(IBinding data, List<string>? value) => {(data as Bookmark).Role = value;}, (IBinding data) => (data as Bookmark).Role )}
        }, __Tag,() => new Bookmark(), () => new List<Bookmark>(), () => new Dictionary<string,Bookmark>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("MessageId")]
	public virtual string?					MessageId  {get; set;}

        /// <summary>
        ///Message that was generated in response to the original (optional).
        /// </summary>

	[JsonPropertyName("ResponseId")]
	public virtual string?					ResponseId  {get; set;}

        /// <summary>
        ///The relationship type. This can be Read, Unread, Accept, Reject.
        /// </summary>

	[JsonPropertyName("Relationship")]
	public virtual string?					Relationship  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Reference> _binding = new (
			new() {

			{ "MessageId", new PropertyString ("MessageId", 
					(IBinding data, string? value) => {(data as Reference).MessageId = value;}, (IBinding data) => (data as Reference).MessageId )},
			{ "ResponseId", new PropertyString ("ResponseId", 
					(IBinding data, string? value) => {(data as Reference).ResponseId = value;}, (IBinding data) => (data as Reference).ResponseId )},
			{ "Relationship", new PropertyString ("Relationship", 
					(IBinding data, string? value) => {(data as Reference).Relationship = value;}, (IBinding data) => (data as Reference).Relationship )}
        }, __Tag,() => new Reference(), () => new List<Reference>(), () => new Dictionary<string,Reference>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Start")]
	public virtual DateTime?					Start  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Finish")]
	public virtual DateTime?					Finish  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("StartTravel")]
	public virtual string?					StartTravel  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("FinishTravel")]
	public virtual string?					FinishTravel  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("TimeZone")]
	public virtual string?					TimeZone  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Description")]
	public virtual string?					Description  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Location")]
	public virtual string?					Location  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Trigger")]
	public virtual List<string>?					Trigger  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("Conference")]
	public virtual List<string>?					Conference  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("Repeat")]
	public virtual string?					Repeat  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Busy")]
	public virtual bool?					Busy  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Engagement> _binding = new (
			new() {

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
        }, __Tag,() => new Engagement(), () => new List<Engagement>(), () => new Dictionary<string,Engagement>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	/// </summary>
public partial class WorkTask : Engagement {
        /// <summary>
        /// </summary>

	[JsonPropertyName("Dependency")]
	public virtual List<string>?					Dependency  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<WorkTask> _binding = new (
			new() {

			{ "Dependency", new PropertyListString ("Dependency", 
					(IBinding data, List<string>? value) => {(data as WorkTask).Dependency = value;}, (IBinding data) => (data as WorkTask).Dependency )}
        }, __Tag,() => new WorkTask(), () => new List<WorkTask>(), () => new Dictionary<string,WorkTask>(),Engagement._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Engagement._binding, _binding);


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
	public new const string __Tag = "WorkTask";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new WorkTask();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new WorkTask FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as WorkTask;
			}
		var Result = new WorkTask ();
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

	[JsonPropertyName("Uid")]
	public virtual string?					Uid  {get; set;}

        /// <summary>
        ///User specified identifier.
        /// </summary>

	[JsonPropertyName("LocalName")]
	public virtual string?					LocalName  {get; set;}

        /// <summary>
        ///The set of labels describing the entry
        /// </summary>

	[JsonPropertyName("Path")]
	public virtual string?					Path  {get; set;}

        /// <summary>
        ///Description
        /// </summary>

	[JsonPropertyName("Description")]
	public virtual string?					Description  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedEntry> _binding = new (
			new() {

			{ "Uid", new PropertyString ("Uid", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Uid = value;}, (IBinding data) => (data as CatalogedEntry).Uid )},
			{ "LocalName", new PropertyString ("LocalName", 
					(IBinding data, string? value) => {(data as CatalogedEntry).LocalName = value;}, (IBinding data) => (data as CatalogedEntry).LocalName )},
			{ "Path", new PropertyString ("Path", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Path = value;}, (IBinding data) => (data as CatalogedEntry).Path )},
			{ "Description", new PropertyString ("Description", 
					(IBinding data, string? value) => {(data as CatalogedEntry).Description = value;}, (IBinding data) => (data as CatalogedEntry).Description )}
        }, __Tag,null, null, null,null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("Updated")]
	public virtual DateTime?					Updated  {get; set;}

        /// <summary>
        ///UDF of the signature key of the device in the Mesh
        /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;}

        /// <summary>
        ///Device Platform
        /// </summary>

	[JsonPropertyName("Platform")]
	public virtual string?					Platform  {get; set;}

        /// <summary>
        ///UDF of the offline signature key of the device
        /// </summary>

	[JsonPropertyName("DeviceUdf")]
	public virtual string?					DeviceUdf  {get; set;}

        /// <summary>
        ///UDF of the account online signature key
        /// </summary>

	[JsonPropertyName("SignatureUdf")]
	public virtual string?					SignatureUdf  {get; set;}

        /// <summary>
        ///The Mesh profile. Why is this still here? This is not 
        ///specific to the device.
        /// </summary>

	[JsonPropertyName("EnvelopedProfileUser")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileUser  {get; set;}

        /// <summary>
        ///The device profile
        /// </summary>

	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///Description of the device
        /// </summary>

	[JsonPropertyName("DeviceDescription")]
	public virtual DeviceDescription?					DeviceDescription  {get; set;}

        /// <summary>
        ///Slim version of ConnectionDevice used by the presentation layer
        /// </summary>

	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///The public assertion demonstrating connection of the Device to the Mesh
        /// </summary>

	[JsonPropertyName("EnvelopedConnectionDevice")]
	public virtual Enveloped<ConnectionDevice>?					EnvelopedConnectionDevice  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	[JsonPropertyName("EnvelopedActivationAccount")]
	public virtual Enveloped<ActivationAccount>?					EnvelopedActivationAccount  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;}

        /// <summary>
        ///Application activations granted to the device.
        /// </summary>

	[JsonPropertyName("ApplicationEntries")]
	public virtual List<ApplicationEntry>?					ApplicationEntries  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedDevice> _binding = new (
			new() {

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
			{ "EnvelopedProfileUser", new PropertyStruct ("EnvelopedProfileUser", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedProfileUser = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedProfileUser,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())},
			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", typeof (Enveloped<ProfileDevice>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())},
			{ "DeviceDescription", new PropertyStruct ("DeviceDescription", typeof (DeviceDescription),
					(IBinding data, object? value) => {(data as CatalogedDevice).DeviceDescription = value as DeviceDescription;}, (IBinding data) => (data as CatalogedDevice).DeviceDescription,
					false, ()=>new  DeviceDescription(), ()=>new DeviceDescription())},
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", typeof (Enveloped<ConnectionService>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())},
			{ "EnvelopedConnectionDevice", new PropertyStruct ("EnvelopedConnectionDevice", typeof (Enveloped<ConnectionDevice>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedConnectionDevice,
					false, ()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>())},
			{ "EnvelopedActivationAccount", new PropertyStruct ("EnvelopedActivationAccount", typeof (Enveloped<ActivationAccount>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedActivationAccount = value as Enveloped<ActivationAccount>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedActivationAccount,
					false, ()=>new  Enveloped<ActivationAccount>(), ()=>new Enveloped<ActivationAccount>())},
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", typeof (Enveloped<ActivationCommon>),
					(IBinding data, object? value) => {(data as CatalogedDevice).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedDevice).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())},
			{ "ApplicationEntries", new PropertyListStruct ("ApplicationEntries", typeof (ApplicationEntry), 
					(IBinding data, object? value) => {(data as CatalogedDevice).ApplicationEntries = value as List<ApplicationEntry>;}, (IBinding data) => (data as CatalogedDevice).ApplicationEntries,
					true, ()=>new List<ApplicationEntry>()
)} 
        }, __Tag,() => new CatalogedDevice(), () => new List<CatalogedDevice>(), () => new Dictionary<string,CatalogedDevice>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Idiom")]
	public virtual string?					Idiom  {get; set;}

        /// <summary>
        ///Manufacturer name
        /// </summary>

	[JsonPropertyName("Manufacturer")]
	public virtual string?					Manufacturer  {get; set;}

        /// <summary>
        ///Manufacturer defined model
        /// </summary>

	[JsonPropertyName("Model")]
	public virtual string?					Model  {get; set;}

        /// <summary>
        ///Name of the device as specified by the user
        /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;}

        /// <summary>
        ///The device platform or operating system: Android / iOS / macOS / Tizen / watchOS / Windows
        /// </summary>

	[JsonPropertyName("Platform")]
	public virtual string?					Platform  {get; set;}

        /// <summary>
        ///Platform version in format Major.Minor.Build.Revision
        /// </summary>

	[JsonPropertyName("Version")]
	public virtual string?					Version  {get; set;}

        /// <summary>
        ///EARL specifying an image of the device.
        /// </summary>

	[JsonPropertyName("ImageLocator")]
	public virtual string?					ImageLocator  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceDescription> _binding = new (
			new() {

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
        }, __Tag,() => new DeviceDescription(), () => new List<DeviceDescription>(), () => new Dictionary<string,DeviceDescription>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public static readonly new Binding<CatalogedSignature> _binding = new (
			new() {

        }, __Tag,() => new CatalogedSignature(), () => new List<CatalogedSignature>(), () => new Dictionary<string,CatalogedSignature>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Version")]
	public virtual string?					Version  {get; set;}

        /// <summary>
        ///Locator to be used to retrieve the data.
        /// </summary>

	[JsonPropertyName("URI")]
	public virtual string?					URI  {get; set;}

        /// <summary>
        ///IANA content type of the encoded content.
        /// </summary>

	[JsonPropertyName("ContentType")]
	public virtual string?					ContentType  {get; set;}

        /// <summary>
        ///Content encoding, typically DARE envelope.
        /// </summary>

	[JsonPropertyName("Encoding")]
	public virtual string?					Encoding  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Created")]
	public virtual DateTime?					Created  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Updated")]
	public virtual DateTime?					Updated  {get; set;}

        /// <summary>
        ///Encoded document length in bytes.
        /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedDocument> _binding = new (
			new() {

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
        }, __Tag,() => new CatalogedDocument(), () => new List<CatalogedDocument>(), () => new Dictionary<string,CatalogedDocument>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;}

        /// <summary>
        ///The witness key value to use to request access to the record.	
        /// </summary>

	[JsonPropertyName("Authenticator")]
	public virtual string?					Authenticator  {get; set;}

        /// <summary>
        ///Dare Envelope containing the entry data. The data type is specified
        ///by the envelope metadata.
        /// </summary>

	[JsonPropertyName("EnvelopedData")]
	public virtual DareEnvelope?					EnvelopedData  {get; set;}

        /// <summary>
        ///Epiration time (inclusive)
        /// </summary>

	[JsonPropertyName("NotOnOrAfter")]
	public virtual DateTime?					NotOnOrAfter  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedPublication> _binding = new (
			new() {

			{ "Id", new PropertyString ("Id", 
					(IBinding data, string? value) => {(data as CatalogedPublication).Id = value;}, (IBinding data) => (data as CatalogedPublication).Id )},
			{ "Authenticator", new PropertyString ("Authenticator", 
					(IBinding data, string? value) => {(data as CatalogedPublication).Authenticator = value;}, (IBinding data) => (data as CatalogedPublication).Authenticator )},
			{ "EnvelopedData", new PropertyStruct ("EnvelopedData", typeof (DareEnvelope),
					(IBinding data, object? value) => {(data as CatalogedPublication).EnvelopedData = value as DareEnvelope;}, (IBinding data) => (data as CatalogedPublication).EnvelopedData,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())},
			{ "NotOnOrAfter", new PropertyDateTime ("NotOnOrAfter", 
					(IBinding data, DateTime? value) => {(data as CatalogedPublication).NotOnOrAfter = value;}, (IBinding data) => (data as CatalogedPublication).NotOnOrAfter )}
        }, __Tag,() => new CatalogedPublication(), () => new List<CatalogedPublication>(), () => new Dictionary<string,CatalogedPublication>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Username")]
	public virtual string?					Username  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Password")]
	public virtual string?					Password  {get; set;}

        /// <summary>
        ///Specifies the client identification key
        /// </summary>

	[JsonPropertyName("ClientAuthentication")]
	public virtual List<KeyData>?					ClientAuthentication  {get; set;}
        /// <summary>
        ///Means of authenticating the host key
        /// </summary>

	[JsonPropertyName("HostAuthentication")]
	public virtual List<KeyData>?					HostAuthentication  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedCredential> _binding = new (
			new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Protocol = value;}, (IBinding data) => (data as CatalogedCredential).Protocol )},
			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Service = value;}, (IBinding data) => (data as CatalogedCredential).Service )},
			{ "Username", new PropertyString ("Username", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Username = value;}, (IBinding data) => (data as CatalogedCredential).Username )},
			{ "Password", new PropertyString ("Password", 
					(IBinding data, string? value) => {(data as CatalogedCredential).Password = value;}, (IBinding data) => (data as CatalogedCredential).Password )},
			{ "ClientAuthentication", new PropertyListStruct ("ClientAuthentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedCredential).ClientAuthentication = value as List<KeyData>;}, (IBinding data) => (data as CatalogedCredential).ClientAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())},
			{ "HostAuthentication", new PropertyListStruct ("HostAuthentication", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedCredential).HostAuthentication = value as List<KeyData>;}, (IBinding data) => (data as CatalogedCredential).HostAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())}
        }, __Tag,() => new CatalogedCredential(), () => new List<CatalogedCredential>(), () => new Dictionary<string,CatalogedCredential>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Username")]
	public virtual string?					Username  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Password")]
	public virtual string?					Password  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedNetwork> _binding = new (
			new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Protocol = value;}, (IBinding data) => (data as CatalogedNetwork).Protocol )},
			{ "Service", new PropertyString ("Service", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Service = value;}, (IBinding data) => (data as CatalogedNetwork).Service )},
			{ "Username", new PropertyString ("Username", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Username = value;}, (IBinding data) => (data as CatalogedNetwork).Username )},
			{ "Password", new PropertyString ("Password", 
					(IBinding data, string? value) => {(data as CatalogedNetwork).Password = value;}, (IBinding data) => (data as CatalogedNetwork).Password )}
        }, __Tag,() => new CatalogedNetwork(), () => new List<CatalogedNetwork>(), () => new Dictionary<string,CatalogedNetwork>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        ///If true, this catalog entry is for the user who created the catalog.
        /// </summary>

	[JsonPropertyName("Self")]
	public virtual bool?					Self  {get; set;}

        /// <summary>
        ///The contact information as edited by the catalog owner.
        /// </summary>

	[JsonPropertyName("Contact")]
	public virtual JsContact?					Contact  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedContact> _binding = new (
			new() {

			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as CatalogedContact).Key = value;}, (IBinding data) => (data as CatalogedContact).Key )},
			{ "Self", new PropertyBoolean ("Self", 
					(IBinding data, bool? value) => {(data as CatalogedContact).Self = value;}, (IBinding data) => (data as CatalogedContact).Self )},
			{ "Contact", new PropertyStruct ("Contact", typeof (JsContact),
					(IBinding data, object? value) => {(data as CatalogedContact).Contact = value as JsContact;}, (IBinding data) => (data as CatalogedContact).Contact,
					false, ()=>new  JsContact(), ()=>new JsContact())}
        }, __Tag,() => new CatalogedContact(), () => new List<CatalogedContact>(), () => new Dictionary<string,CatalogedContact>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Capability")]
	public virtual Capability?					Capability  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedAccess> _binding = new (
			new() {

			{ "Capability", new PropertyStruct ("Capability", typeof (Capability), 
					(IBinding data, object? value) => {(data as CatalogedAccess).Capability = value as Capability;}, (IBinding data) => (data as CatalogedAccess).Capability,
					true)} 
        }, __Tag,() => new CatalogedAccess(), () => new List<CatalogedAccess>(), () => new Dictionary<string,CatalogedAccess>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Id")]
	public virtual string?					Id  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Active")]
	public virtual bool?					Active  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Issued")]
	public virtual int?					Issued  {get; set;}

        /// <summary>
        ///The authentication mode: Device, Account, PIN
        /// </summary>

	[JsonPropertyName("Mode")]
	public virtual string?					Mode  {get; set;}

        /// <summary>
        ///Identifies the authentication credential. For a device, this is the authentication key identifier, 
        ///for an account, the profile identifier, for a PIN, the locator value of the PIN.
        /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;}

        /// <summary>
        ///The verification value used to perform proof of knowledge of the secret.
        /// </summary>

	[JsonPropertyName("Witness")]
	public virtual string?					Witness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Capability> _binding = new (
			new() {

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
        }, __Tag,null, null, null,null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public static readonly new Binding<NullCapability> _binding = new (
			new() {

        }, __Tag,() => new NullCapability(), () => new List<NullCapability>(), () => new Dictionary<string,NullCapability>(),Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Capability._binding, _binding);


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

	[JsonPropertyName("Rights")]
	public virtual List<string>?					Rights  {get; set;}
        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;}

        /// <summary>
        ///Digest value used to signal updates to envelope		
        /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccessCapability> _binding = new (
			new() {

			{ "Rights", new PropertyListString ("Rights", 
					(IBinding data, List<string>? value) => {(data as AccessCapability).Rights = value;}, (IBinding data) => (data as AccessCapability).Rights )},
			{ "EnvelopedCatalogedDevice", new PropertyStruct ("EnvelopedCatalogedDevice", typeof (Enveloped<CatalogedDevice>),
					(IBinding data, object? value) => {(data as AccessCapability).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;}, (IBinding data) => (data as AccessCapability).EnvelopedCatalogedDevice,
					false, ()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>())},
			{ "CatalogedDeviceDigest", new PropertyString ("CatalogedDeviceDigest", 
					(IBinding data, string? value) => {(data as AccessCapability).CatalogedDeviceDigest = value;}, (IBinding data) => (data as AccessCapability).CatalogedDeviceDigest )}
        }, __Tag,() => new AccessCapability(), () => new List<AccessCapability>(), () => new Dictionary<string,AccessCapability>(),Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Capability._binding, _binding);


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

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;}

        /// <summary>
        ///Document digest, this allows a status/claim request to 
        ///request an update to be returned only if the document
        ///has changed.
        /// </summary>

	[JsonPropertyName("Digest")]
	public virtual string?					Digest  {get; set;}

        /// <summary>
        ///The published document.
        /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicationCapability> _binding = new (
			new() {

			{ "Identifier", new PropertyString ("Identifier", 
					(IBinding data, string? value) => {(data as PublicationCapability).Identifier = value;}, (IBinding data) => (data as PublicationCapability).Identifier )},
			{ "Digest", new PropertyString ("Digest", 
					(IBinding data, string? value) => {(data as PublicationCapability).Digest = value;}, (IBinding data) => (data as PublicationCapability).Digest )},
			{ "Data", new PropertyBinary ("Data", 
					(IBinding data, byte[]? value) => {(data as PublicationCapability).Data = value;}, (IBinding data) => (data as PublicationCapability).Data )}
        }, __Tag,() => new PublicationCapability(), () => new List<PublicationCapability>(), () => new Dictionary<string,PublicationCapability>(),Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Capability._binding, _binding);


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

	[JsonPropertyName("KeyData")]
	public virtual KeyData?					KeyData  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("GranteeAccount")]
	public virtual string?					GranteeAccount  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("GranteeUdf")]
	public virtual string?					GranteeUdf  {get; set;}

        /// <summary>
        ///One or more enveloped key shares.
        /// </summary>

	[JsonPropertyName("EnvelopedKeyShare")]
	public virtual Enveloped<KeyData>?					EnvelopedKeyShare  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicCapability> _binding = new (
			new() {

			{ "KeyData", new PropertyStruct ("KeyData", typeof (KeyData),
					(IBinding data, object? value) => {(data as CryptographicCapability).KeyData = value as KeyData;}, (IBinding data) => (data as CryptographicCapability).KeyData,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "GranteeAccount", new PropertyString ("GranteeAccount", 
					(IBinding data, string? value) => {(data as CryptographicCapability).GranteeAccount = value;}, (IBinding data) => (data as CryptographicCapability).GranteeAccount )},
			{ "GranteeUdf", new PropertyString ("GranteeUdf", 
					(IBinding data, string? value) => {(data as CryptographicCapability).GranteeUdf = value;}, (IBinding data) => (data as CryptographicCapability).GranteeUdf )},
			{ "EnvelopedKeyShare", new PropertyStruct ("EnvelopedKeyShare", typeof (Enveloped<KeyData>),
					(IBinding data, object? value) => {(data as CryptographicCapability).EnvelopedKeyShare = value as Enveloped<KeyData>;}, (IBinding data) => (data as CryptographicCapability).EnvelopedKeyShare,
					false, ()=>new  Enveloped<KeyData>(), ()=>new Enveloped<KeyData>())}
        }, __Tag,null, null, null,Capability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Capability._binding, _binding);


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
	public static readonly new Binding<CapabilityDecrypt> _binding = new (
			new() {

        }, __Tag,() => new CapabilityDecrypt(), () => new List<CapabilityDecrypt>(), () => new Dictionary<string,CapabilityDecrypt>(),CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicCapability._binding, _binding);


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
	public static readonly new Binding<CapabilityDecryptPartial> _binding = new (
			new() {

        }, __Tag,() => new CapabilityDecryptPartial(), () => new List<CapabilityDecryptPartial>(), () => new Dictionary<string,CapabilityDecryptPartial>(),CapabilityDecrypt._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CapabilityDecrypt._binding, _binding);


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

	[JsonPropertyName("AuthenticationId")]
	public virtual string?					AuthenticationId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityDecryptServiced> _binding = new (
			new() {

			{ "AuthenticationId", new PropertyString ("AuthenticationId", 
					(IBinding data, string? value) => {(data as CapabilityDecryptServiced).AuthenticationId = value;}, (IBinding data) => (data as CapabilityDecryptServiced).AuthenticationId )}
        }, __Tag,() => new CapabilityDecryptServiced(), () => new List<CapabilityDecryptServiced>(), () => new Dictionary<string,CapabilityDecryptServiced>(),CapabilityDecrypt._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CapabilityDecrypt._binding, _binding);


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
	public static readonly new Binding<CapabilitySign> _binding = new (
			new() {

        }, __Tag,() => new CapabilitySign(), () => new List<CapabilitySign>(), () => new Dictionary<string,CapabilitySign>(),CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicCapability._binding, _binding);


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
	public static readonly new Binding<CapabilityKeyGenerate> _binding = new (
			new() {

        }, __Tag,() => new CapabilityKeyGenerate(), () => new List<CapabilityKeyGenerate>(), () => new Dictionary<string,CapabilityKeyGenerate>(),CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicCapability._binding, _binding);


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
	public static readonly new Binding<CapabilityFairExchange> _binding = new (
			new() {

        }, __Tag,() => new CapabilityFairExchange(), () => new List<CapabilityFairExchange>(), () => new Dictionary<string,CapabilityFairExchange>(),CryptographicCapability._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CryptographicCapability._binding, _binding);


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

	[JsonPropertyName("Prefix")]
	public virtual string?					Prefix  {get; set;}

        /// <summary>
        ///Optional name mapping, (e.g. alice@example.com -> alice.mesh)
        /// </summary>

	[JsonPropertyName("Mapping")]
	public virtual string?					Mapping  {get; set;}

        /// <summary>
        ///The service endpoints. This MAY be specified as a callsign (@alice),
        ///a DNS address (example.com), an IP address (10.0.0.1) or a fully
        ///qualified URI.
        /// </summary>

	[JsonPropertyName("Endpoints")]
	public virtual List<string>?					Endpoints  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NamedService> _binding = new (
			new() {

			{ "Prefix", new PropertyString ("Prefix", 
					(IBinding data, string? value) => {(data as NamedService).Prefix = value;}, (IBinding data) => (data as NamedService).Prefix )},
			{ "Mapping", new PropertyString ("Mapping", 
					(IBinding data, string? value) => {(data as NamedService).Mapping = value;}, (IBinding data) => (data as NamedService).Mapping )},
			{ "Endpoints", new PropertyListString ("Endpoints", 
					(IBinding data, List<string>? value) => {(data as NamedService).Endpoints = value;}, (IBinding data) => (data as NamedService).Endpoints )}
        }, __Tag,() => new NamedService(), () => new List<NamedService>(), () => new Dictionary<string,NamedService>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("Token")]
	public virtual byte[]?					Token  {get; set;}

        /// <summary>
        ///Session shared secret
        /// </summary>

	[JsonPropertyName("SharedSecret")]
	public virtual byte[]?					SharedSecret  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceAccessToken> _binding = new (
			new() {

			{ "Token", new PropertyBinary ("Token", 
					(IBinding data, byte[]? value) => {(data as ServiceAccessToken).Token = value;}, (IBinding data) => (data as ServiceAccessToken).Token )},
			{ "SharedSecret", new PropertyBinary ("SharedSecret", 
					(IBinding data, byte[]? value) => {(data as ServiceAccessToken).SharedSecret = value;}, (IBinding data) => (data as ServiceAccessToken).SharedSecret )}
        }, __Tag,() => new ServiceAccessToken(), () => new List<ServiceAccessToken>(), () => new Dictionary<string,ServiceAccessToken>(),NamedService._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(NamedService._binding, _binding);


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

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;}

        /// <summary>
        ///User comments on bookmark entry
        /// </summary>

	[JsonPropertyName("Comments")]
	public virtual List<string>?					Comments  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedBookmark> _binding = new (
			new() {

			{ "Uri", new PropertyString ("Uri", 
					(IBinding data, string? value) => {(data as CatalogedBookmark).Uri = value;}, (IBinding data) => (data as CatalogedBookmark).Uri )},
			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as CatalogedBookmark).Title = value;}, (IBinding data) => (data as CatalogedBookmark).Title )},
			{ "Comments", new PropertyListString ("Comments", 
					(IBinding data, List<string>? value) => {(data as CatalogedBookmark).Comments = value;}, (IBinding data) => (data as CatalogedBookmark).Comments )}
        }, __Tag,() => new CatalogedBookmark(), () => new List<CatalogedBookmark>(), () => new Dictionary<string,CatalogedBookmark>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("EnvelopedTask")]
	public virtual Enveloped<Engagement>?					EnvelopedTask  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedTask> _binding = new (
			new() {

			{ "Title", new PropertyString ("Title", 
					(IBinding data, string? value) => {(data as CatalogedTask).Title = value;}, (IBinding data) => (data as CatalogedTask).Title )},
			{ "EnvelopedTask", new PropertyStruct ("EnvelopedTask", typeof (Enveloped<Engagement>),
					(IBinding data, object? value) => {(data as CatalogedTask).EnvelopedTask = value as Enveloped<Engagement>;}, (IBinding data) => (data as CatalogedTask).EnvelopedTask,
					false, ()=>new  Enveloped<Engagement>(), ()=>new Enveloped<Engagement>())}
        }, __Tag,() => new CatalogedTask(), () => new List<CatalogedTask>(), () => new Dictionary<string,CatalogedTask>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("Default")]
	public virtual int?					Default  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Grant")]
	public virtual List<string>?					Grant  {get; set;}
        /// <summary>
        /// </summary>

	[JsonPropertyName("Deny")]
	public virtual List<string>?					Deny  {get; set;}
        /// <summary>
        ///Enveloped keys for use with Application
        /// </summary>

	[JsonPropertyName("EnvelopedCapabilities")]
	public virtual List<DareEnvelope>?					EnvelopedCapabilities  {get; set;}
        /// <summary>
        ///Escrow entries for the application.
        /// </summary>

	[JsonPropertyName("EnvelopedEscrow")]
	public virtual List<Enveloped<KeyData>>?					EnvelopedEscrow  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplication> _binding = new (
			new() {

			{ "Default", new PropertyInteger32 ("Default", 
					(IBinding data, int? value) => {(data as CatalogedApplication).Default = value;}, (IBinding data) => (data as CatalogedApplication).Default )},
			{ "Key", new PropertyString ("Key", 
					(IBinding data, string? value) => {(data as CatalogedApplication).Key = value;}, (IBinding data) => (data as CatalogedApplication).Key )},
			{ "Grant", new PropertyListString ("Grant", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplication).Grant = value;}, (IBinding data) => (data as CatalogedApplication).Grant )},
			{ "Deny", new PropertyListString ("Deny", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplication).Deny = value;}, (IBinding data) => (data as CatalogedApplication).Deny )},
			{ "EnvelopedCapabilities", new PropertyListStruct ("EnvelopedCapabilities", typeof (DareEnvelope),
					(IBinding data, object? value) => {(data as CatalogedApplication).EnvelopedCapabilities = value as List<DareEnvelope>;}, (IBinding data) => (data as CatalogedApplication).EnvelopedCapabilities,
					false, ()=>new  List<DareEnvelope>(), ()=>new DareEnvelope())},
			{ "EnvelopedEscrow", new PropertyListStruct ("EnvelopedEscrow", typeof (Enveloped<KeyData>),
					(IBinding data, object? value) => {(data as CatalogedApplication).EnvelopedEscrow = value as List<Enveloped<KeyData>>;}, (IBinding data) => (data as CatalogedApplication).EnvelopedEscrow,
					false, ()=>new  List<Enveloped<KeyData>>(), ()=>new Enveloped<KeyData>())}
        }, __Tag,null, null, null,CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("ContactAddress")]
	public virtual string?					ContactAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("MemberCapabilityId")]
	public virtual string?					MemberCapabilityId  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ServiceCapabilityId")]
	public virtual string?					ServiceCapabilityId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedMember> _binding = new (
			new() {

			{ "ContactAddress", new PropertyString ("ContactAddress", 
					(IBinding data, string? value) => {(data as CatalogedMember).ContactAddress = value;}, (IBinding data) => (data as CatalogedMember).ContactAddress )},
			{ "MemberCapabilityId", new PropertyString ("MemberCapabilityId", 
					(IBinding data, string? value) => {(data as CatalogedMember).MemberCapabilityId = value;}, (IBinding data) => (data as CatalogedMember).MemberCapabilityId )},
			{ "ServiceCapabilityId", new PropertyString ("ServiceCapabilityId", 
					(IBinding data, string? value) => {(data as CatalogedMember).ServiceCapabilityId = value;}, (IBinding data) => (data as CatalogedMember).ServiceCapabilityId )}
        }, __Tag,() => new CatalogedMember(), () => new List<CatalogedMember>(), () => new Dictionary<string,CatalogedMember>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;}

        /// <summary>
        ///The Mesh profile
        /// </summary>

	[JsonPropertyName("EnvelopedProfileGroup")]
	public virtual Enveloped<ProfileAccount>?					EnvelopedProfileGroup  {get; set;}

        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedGroup> _binding = new (
			new() {

			{ "EnvelopedConnectionAddress", new PropertyStruct ("EnvelopedConnectionAddress", typeof (Enveloped<ConnectionStripped>),
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedConnectionAddress,
					false, ()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>())},
			{ "EnvelopedProfileGroup", new PropertyStruct ("EnvelopedProfileGroup", typeof (Enveloped<ProfileAccount>),
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedProfileGroup = value as Enveloped<ProfileAccount>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedProfileGroup,
					false, ()=>new  Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>())},
			{ "EnvelopedActivationCommon", new PropertyStruct ("EnvelopedActivationCommon", typeof (Enveloped<ActivationCommon>),
					(IBinding data, object? value) => {(data as CatalogedGroup).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;}, (IBinding data) => (data as CatalogedGroup).EnvelopedActivationCommon,
					false, ()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())}
        }, __Tag,() => new CatalogedGroup(), () => new List<CatalogedGroup>(), () => new Dictionary<string,CatalogedGroup>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedFeed> _binding = new (
			new() {

			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedFeed).Protocol = value;}, (IBinding data) => (data as CatalogedFeed).Protocol )}
        }, __Tag,() => new CatalogedFeed(), () => new List<CatalogedFeed>(), () => new Dictionary<string,CatalogedFeed>(),CatalogedBookmark._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedBookmark._binding, _binding);


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

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("InboundConnect")]
	public virtual string?					InboundConnect  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("OutboundConnect")]
	public virtual string?					OutboundConnect  {get; set;}

        /// <summary>
        ///The S/Mime signature key
        /// </summary>

	[JsonPropertyName("SmimeSign")]
	public virtual KeyData?					SmimeSign  {get; set;}

        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	[JsonPropertyName("SmimeEncrypt")]
	public virtual KeyData?					SmimeEncrypt  {get; set;}

        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	[JsonPropertyName("OpenpgpSign")]
	public virtual KeyData?					OpenpgpSign  {get; set;}

        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	[JsonPropertyName("OpenpgpEncrypt")]
	public virtual KeyData?					OpenpgpEncrypt  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationMail> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationMail).AccountAddress )},
			{ "InboundConnect", new PropertyString ("InboundConnect", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).InboundConnect = value;}, (IBinding data) => (data as CatalogedApplicationMail).InboundConnect )},
			{ "OutboundConnect", new PropertyString ("OutboundConnect", 
					(IBinding data, string? value) => {(data as CatalogedApplicationMail).OutboundConnect = value;}, (IBinding data) => (data as CatalogedApplicationMail).OutboundConnect )},
			{ "SmimeSign", new PropertyStruct ("SmimeSign", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).SmimeSign = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "SmimeEncrypt", new PropertyStruct ("SmimeEncrypt", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).SmimeEncrypt = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "OpenpgpSign", new PropertyStruct ("OpenpgpSign", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).OpenpgpSign = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "OpenpgpEncrypt", new PropertyStruct ("OpenpgpEncrypt", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationMail).OpenpgpEncrypt = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new CatalogedApplicationMail(), () => new List<CatalogedApplicationMail>(), () => new Dictionary<string,CatalogedApplicationMail>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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
public partial class CatalogedApplicationSsh : CatalogedApplication {
        /// <summary>
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        ///The Client authentication key
        /// </summary>

	[JsonPropertyName("ClientKey")]
	public virtual KeyData?					ClientKey  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationSsh> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationSsh).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationSsh).AccountAddress )},
			{ "ClientKey", new PropertyStruct ("ClientKey", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationSsh).ClientKey = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())}
        }, __Tag,() => new CatalogedApplicationSsh(), () => new List<CatalogedApplicationSsh>(), () => new Dictionary<string,CatalogedApplicationSsh>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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
public partial class CatalogedApplicationCredential : CatalogedApplication {
        /// <summary>
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Contexts")]
	public virtual List<string>?					Contexts  {get; set;}
        /// <summary>
        ///The primary key, i.e. the OpenPGP public key or PKIX root certificate
        /// </summary>

	[JsonPropertyName("Primary")]
	public virtual KeyData?					Primary  {get; set;}

        /// <summary>
        ///Secondary keys, i.e. OpenPGP sub keys or PKIX intermediate or end
        ///entity certificates.
        /// </summary>

	[JsonPropertyName("Secondary")]
	public virtual List<KeyData>?					Secondary  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationCredential> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCredential).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationCredential).AccountAddress )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as CatalogedApplicationCredential).Kind = value;}, (IBinding data) => (data as CatalogedApplicationCredential).Kind )},
			{ "Contexts", new PropertyListString ("Contexts", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplicationCredential).Contexts = value;}, (IBinding data) => (data as CatalogedApplicationCredential).Contexts )},
			{ "Primary", new PropertyStruct ("Primary", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationCredential).Primary = value as KeyData;}, (IBinding data) => (data as CatalogedApplicationCredential).Primary,
					false, ()=>new  KeyData(), ()=>new KeyData())},
			{ "Secondary", new PropertyListStruct ("Secondary", typeof (KeyData),
					(IBinding data, object? value) => {(data as CatalogedApplicationCredential).Secondary = value as List<KeyData>;}, (IBinding data) => (data as CatalogedApplicationCredential).Secondary,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())}
        }, __Tag,() => new CatalogedApplicationCredential(), () => new List<CatalogedApplicationCredential>(), () => new Dictionary<string,CatalogedApplicationCredential>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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
	public new const string __Tag = "CatalogedApplicationCredential";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationCredential();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationCredential FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationCredential;
			}
		var Result = new CatalogedApplicationCredential ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationService : CatalogedApplication {
        /// <summary>
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Address")]
	public virtual string?					Address  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("AdministrationAddress")]
	public virtual string?					AdministrationAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationService> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationService).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationService).AccountAddress )},
			{ "Address", new PropertyString ("Address", 
					(IBinding data, string? value) => {(data as CatalogedApplicationService).Address = value;}, (IBinding data) => (data as CatalogedApplicationService).Address )},
			{ "AdministrationAddress", new PropertyString ("AdministrationAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationService).AdministrationAddress = value;}, (IBinding data) => (data as CatalogedApplicationService).AdministrationAddress )},
			{ "Protocol", new PropertyString ("Protocol", 
					(IBinding data, string? value) => {(data as CatalogedApplicationService).Protocol = value;}, (IBinding data) => (data as CatalogedApplicationService).Protocol )}
        }, __Tag,() => new CatalogedApplicationService(), () => new List<CatalogedApplicationService>(), () => new Dictionary<string,CatalogedApplicationService>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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
	public new const string __Tag = "CatalogedApplicationService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationService;
			}
		var Result = new CatalogedApplicationService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationDeveloper : CatalogedApplication {
        /// <summary>
        /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Kind")]
	public virtual string?					Kind  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Contexts")]
	public virtual List<string>?					Contexts  {get; set;}
        /// <summary>
        /// Unique identifier of the SSH keys used to authenticate to remote repositories 
        /// under this persona
        /// </summary>

	[JsonPropertyName("Ssh")]
	public virtual List<string>?					Ssh  {get; set;}
        /// <summary>
        /// Unique identifier of the OpenPGP keys to sign repository commits
        /// under this persona
        /// </summary>

	[JsonPropertyName("Commit")]
	public virtual List<string>?					Commit  {get; set;}
        /// <summary>
        /// Unique identifier of the PKIX keys to sign code
        /// under this persona
        /// </summary>

	[JsonPropertyName("Code")]
	public virtual List<string>?					Code  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationDeveloper> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as CatalogedApplicationDeveloper).AccountAddress = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).AccountAddress )},
			{ "Kind", new PropertyString ("Kind", 
					(IBinding data, string? value) => {(data as CatalogedApplicationDeveloper).Kind = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).Kind )},
			{ "Contexts", new PropertyListString ("Contexts", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplicationDeveloper).Contexts = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).Contexts )},
			{ "Ssh", new PropertyListString ("Ssh", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplicationDeveloper).Ssh = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).Ssh )},
			{ "Commit", new PropertyListString ("Commit", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplicationDeveloper).Commit = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).Commit )},
			{ "Code", new PropertyListString ("Code", 
					(IBinding data, List<string>? value) => {(data as CatalogedApplicationDeveloper).Code = value;}, (IBinding data) => (data as CatalogedApplicationDeveloper).Code )}
        }, __Tag,() => new CatalogedApplicationDeveloper(), () => new List<CatalogedApplicationDeveloper>(), () => new Dictionary<string,CatalogedApplicationDeveloper>(),CatalogedApplication._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedApplication._binding, _binding);


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
	public static readonly new Binding<MessageInvoice> _binding = new (
			new() {

        }, __Tag,() => new MessageInvoice(), () => new List<MessageInvoice>(), () => new Dictionary<string,MessageInvoice>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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
	public static readonly new Binding<CatalogedReceipt> _binding = new (
			new() {

        }, __Tag,() => new CatalogedReceipt(), () => new List<CatalogedReceipt>(), () => new Dictionary<string,CatalogedReceipt>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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
	public static readonly new Binding<CatalogedTicket> _binding = new (
			new() {

        }, __Tag,() => new CatalogedTicket(), () => new List<CatalogedTicket>(), () => new Dictionary<string,CatalogedTicket>(),CatalogedEntry._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(CatalogedEntry._binding, _binding);


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

	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;}

        /// <summary>
        ///A list of URIs specifying hailing transports that may be used to
        ///initiate a connection to the device. This allows a device to 
        ///specify that it can be reached by WiFi transport to a particular 
        ///private SSID, or by Bluetooth, IR etc. etc.
        /// </summary>

	[JsonPropertyName("Hailing")]
	public virtual List<string>?					Hailing  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DevicePreconfigurationPublic> _binding = new (
			new() {

			{ "EnvelopedProfileDevice", new PropertyStruct ("EnvelopedProfileDevice", typeof (Enveloped<ProfileDevice>),
					(IBinding data, object? value) => {(data as DevicePreconfigurationPublic).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;}, (IBinding data) => (data as DevicePreconfigurationPublic).EnvelopedProfileDevice,
					false, ()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>())},
			{ "Hailing", new PropertyListString ("Hailing", 
					(IBinding data, List<string>? value) => {(data as DevicePreconfigurationPublic).Hailing = value;}, (IBinding data) => (data as DevicePreconfigurationPublic).Hailing )}
        }, __Tag,() => new DevicePreconfigurationPublic(), () => new List<DevicePreconfigurationPublic>(), () => new Dictionary<string,DevicePreconfigurationPublic>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("EnvelopedConnectionDevice")]
	public virtual Enveloped<ConnectionDevice>?					EnvelopedConnectionDevice  {get; set;}

        /// <summary>
        ///The device connection
        /// </summary>

	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;}

        /// <summary>
        ///The device private key
        /// </summary>

	[JsonPropertyName("PrivateKey")]
	public virtual Key?					PrivateKey  {get; set;}

        /// <summary>
        ///The connection URI. This would normally be printed on the device as a 
        ///QR code.
        /// </summary>

	[JsonPropertyName("ConnectUri")]
	public virtual string?					ConnectUri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DevicePreconfigurationPrivate> _binding = new (
			new() {

			{ "EnvelopedConnectionDevice", new PropertyStruct ("EnvelopedConnectionDevice", typeof (Enveloped<ConnectionDevice>),
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;}, (IBinding data) => (data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice,
					false, ()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>())},
			{ "EnvelopedConnectionService", new PropertyStruct ("EnvelopedConnectionService", typeof (Enveloped<ConnectionService>),
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionService = value as Enveloped<ConnectionService>;}, (IBinding data) => (data as DevicePreconfigurationPrivate).EnvelopedConnectionService,
					false, ()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())},
			{ "PrivateKey", new PropertyStruct ("PrivateKey", typeof (Key), 
					(IBinding data, object? value) => {(data as DevicePreconfigurationPrivate).PrivateKey = value as Key;}, (IBinding data) => (data as DevicePreconfigurationPrivate).PrivateKey,
					true)} ,
			{ "ConnectUri", new PropertyString ("ConnectUri", 
					(IBinding data, string? value) => {(data as DevicePreconfigurationPrivate).ConnectUri = value;}, (IBinding data) => (data as DevicePreconfigurationPrivate).ConnectUri )}
        }, __Tag,() => new DevicePreconfigurationPrivate(), () => new List<DevicePreconfigurationPrivate>(), () => new Dictionary<string,DevicePreconfigurationPrivate>(),DevicePreconfigurationPublic._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(DevicePreconfigurationPublic._binding, _binding);


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

	[JsonPropertyName("MessageId")]
	public virtual string?					MessageId  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Sender")]
	public virtual string?					Sender  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Recipient")]
	public virtual string?					Recipient  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Message> _binding = new (
			new() {

			{ "MessageId", new PropertyString ("MessageId", 
					(IBinding data, string? value) => {(data as Message).MessageId = value;}, (IBinding data) => (data as Message).MessageId )},
			{ "Sender", new PropertyString ("Sender", 
					(IBinding data, string? value) => {(data as Message).Sender = value;}, (IBinding data) => (data as Message).Sender )},
			{ "Recipient", new PropertyString ("Recipient", 
					(IBinding data, string? value) => {(data as Message).Recipient = value;}, (IBinding data) => (data as Message).Recipient )}
        }, __Tag,() => new Message(), () => new List<Message>(), () => new Dictionary<string,Message>(),null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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

	[JsonPropertyName("ErrorCode")]
	public virtual string?					ErrorCode  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageError> _binding = new (
			new() {

			{ "ErrorCode", new PropertyString ("ErrorCode", 
					(IBinding data, string? value) => {(data as MessageError).ErrorCode = value;}, (IBinding data) => (data as MessageError).ErrorCode )}
        }, __Tag,() => new MessageError(), () => new List<MessageError>(), () => new Dictionary<string,MessageError>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("References")]
	public virtual List<Reference>?					References  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageComplete> _binding = new (
			new() {

			{ "References", new PropertyListStruct ("References", typeof (Reference),
					(IBinding data, object? value) => {(data as MessageComplete).References = value as List<Reference>;}, (IBinding data) => (data as MessageComplete).References,
					false, ()=>new  List<Reference>(), ()=>new Reference())}
        }, __Tag,() => new MessageComplete(), () => new List<MessageComplete>(), () => new Dictionary<string,MessageComplete>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("AuthenticatedData")]
	public virtual DareEnvelope?					AuthenticatedData  {get; set;}

        /// <summary>
        ///Nonce provided by the client to validate the PIN
        /// </summary>

	[JsonPropertyName("ClientNonce")]
	public virtual byte[]?					ClientNonce  {get; set;}

        /// <summary>
        ///Pin identifier value calculated from the PIN code, action and account address.
        /// </summary>

	[JsonPropertyName("PinId")]
	public virtual string?					PinId  {get; set;}

        /// <summary>
        ///Witness value calculated as KDF (Device.Udf + AccountAddress, ClientNonce)
        /// </summary>

	[JsonPropertyName("PinWitness")]
	public virtual byte[]?					PinWitness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageValidated> _binding = new (
			new() {

			{ "AuthenticatedData", new PropertyStruct ("AuthenticatedData", typeof (DareEnvelope),
					(IBinding data, object? value) => {(data as MessageValidated).AuthenticatedData = value as DareEnvelope;}, (IBinding data) => (data as MessageValidated).AuthenticatedData,
					false, ()=>new  DareEnvelope(), ()=>new DareEnvelope())},
			{ "ClientNonce", new PropertyBinary ("ClientNonce", 
					(IBinding data, byte[]? value) => {(data as MessageValidated).ClientNonce = value;}, (IBinding data) => (data as MessageValidated).ClientNonce )},
			{ "PinId", new PropertyString ("PinId", 
					(IBinding data, string? value) => {(data as MessageValidated).PinId = value;}, (IBinding data) => (data as MessageValidated).PinId )},
			{ "PinWitness", new PropertyBinary ("PinWitness", 
					(IBinding data, byte[]? value) => {(data as MessageValidated).PinWitness = value;}, (IBinding data) => (data as MessageValidated).PinWitness )}
        }, __Tag,() => new MessageValidated(), () => new List<MessageValidated>(), () => new Dictionary<string,MessageValidated>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Account")]
	public virtual string?					Account  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;}

        /// <summary>
        ///If true, authentication against the PIN code is sufficient to complete
        ///the associated action without further authorization.
        /// </summary>

	[JsonPropertyName("Automatic")]
	public virtual bool?					Automatic  {get; set;}

        /// <summary>
        ///PIN code bound to the specified action.
        /// </summary>

	[JsonPropertyName("SaltedPin")]
	public virtual string?					SaltedPin  {get; set;}

        /// <summary>
        ///The action to which this PIN code is bound.
        /// </summary>

	[JsonPropertyName("Action")]
	public virtual string?					Action  {get; set;}

        /// <summary>
        ///The set of rights bound to the PIN grant.
        /// </summary>

	[JsonPropertyName("Roles")]
	public virtual List<string>?					Roles  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessagePin> _binding = new (
			new() {

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
        }, __Tag,() => new MessagePin(), () => new List<MessagePin>(), () => new Dictionary<string,MessagePin>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RequestConnection> _binding = new (
			new() {

			{ "AccountAddress", new PropertyString ("AccountAddress", 
					(IBinding data, string? value) => {(data as RequestConnection).AccountAddress = value;}, (IBinding data) => (data as RequestConnection).AccountAddress )}
        }, __Tag,() => new RequestConnection(), () => new List<RequestConnection>(), () => new Dictionary<string,RequestConnection>(),MessageValidated._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MessageValidated._binding, _binding);


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

	[JsonPropertyName("EnvelopedRequestConnection")]
	public virtual Enveloped<RequestConnection>?					EnvelopedRequestConnection  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("ServerNonce")]
	public virtual byte[]?					ServerNonce  {get; set;}

        /// <summary>
        ///
        /// </summary>

	[JsonPropertyName("Witness")]
	public virtual string?					Witness  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AcknowledgeConnection> _binding = new (
			new() {

			{ "EnvelopedRequestConnection", new PropertyStruct ("EnvelopedRequestConnection", typeof (Enveloped<RequestConnection>),
					(IBinding data, object? value) => {(data as AcknowledgeConnection).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;}, (IBinding data) => (data as AcknowledgeConnection).EnvelopedRequestConnection,
					false, ()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>())},
			{ "ServerNonce", new PropertyBinary ("ServerNonce", 
					(IBinding data, byte[]? value) => {(data as AcknowledgeConnection).ServerNonce = value;}, (IBinding data) => (data as AcknowledgeConnection).ServerNonce )},
			{ "Witness", new PropertyString ("Witness", 
					(IBinding data, string? value) => {(data as AcknowledgeConnection).Witness = value;}, (IBinding data) => (data as AcknowledgeConnection).Witness )}
        }, __Tag,() => new AcknowledgeConnection(), () => new List<AcknowledgeConnection>(), () => new Dictionary<string,AcknowledgeConnection>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Result")]
	public virtual string?					Result  {get; set;}

        /// <summary>
        ///The device information. MUST be present if the value of Result is
        ///"Accept". MUST be absent or null otherwise.
        /// </summary>

	[JsonPropertyName("CatalogedDevice")]
	public virtual CatalogedDevice?					CatalogedDevice  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RespondConnection> _binding = new (
			new() {

			{ "Result", new PropertyString ("Result", 
					(IBinding data, string? value) => {(data as RespondConnection).Result = value;}, (IBinding data) => (data as RespondConnection).Result )},
			{ "CatalogedDevice", new PropertyStruct ("CatalogedDevice", typeof (CatalogedDevice),
					(IBinding data, object? value) => {(data as RespondConnection).CatalogedDevice = value as CatalogedDevice;}, (IBinding data) => (data as RespondConnection).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())}
        }, __Tag,() => new RespondConnection(), () => new List<RespondConnection>(), () => new Dictionary<string,RespondConnection>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Reply")]
	public virtual bool?					Reply  {get; set;}

        /// <summary>
        ///Optional explanation of the reason for the request.
        /// </summary>

	[JsonPropertyName("Subject")]
	public virtual string?					Subject  {get; set;}

        /// <summary>
        ///One time authentication code supplied to a recipient to allow authentication
        ///of the response.
        /// </summary>

	[JsonPropertyName("PIN")]
	public virtual string?					PIN  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageContact> _binding = new (
			new() {

			{ "Reply", new PropertyBoolean ("Reply", 
					(IBinding data, bool? value) => {(data as MessageContact).Reply = value;}, (IBinding data) => (data as MessageContact).Reply )},
			{ "Subject", new PropertyString ("Subject", 
					(IBinding data, string? value) => {(data as MessageContact).Subject = value;}, (IBinding data) => (data as MessageContact).Subject )},
			{ "PIN", new PropertyString ("PIN", 
					(IBinding data, string? value) => {(data as MessageContact).PIN = value;}, (IBinding data) => (data as MessageContact).PIN )}
        }, __Tag,() => new MessageContact(), () => new List<MessageContact>(), () => new Dictionary<string,MessageContact>(),MessageValidated._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(MessageValidated._binding, _binding);


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

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;}

        /// <summary>
        ///The contact data.
        /// </summary>

	[JsonPropertyName("Contact")]
	public virtual JsContact?					Contact  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GroupInvitation> _binding = new (
			new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as GroupInvitation).Text = value;}, (IBinding data) => (data as GroupInvitation).Text )},
			{ "Contact", new PropertyStruct ("Contact", typeof (JsContact),
					(IBinding data, object? value) => {(data as GroupInvitation).Contact = value as JsContact;}, (IBinding data) => (data as GroupInvitation).Contact,
					false, ()=>new  JsContact(), ()=>new JsContact())}
        }, __Tag,() => new GroupInvitation(), () => new List<GroupInvitation>(), () => new Dictionary<string,GroupInvitation>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageMail> _binding = new (
			new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as MessageMail).Text = value;}, (IBinding data) => (data as MessageMail).Text )}
        }, __Tag,() => new MessageMail(), () => new List<MessageMail>(), () => new Dictionary<string,MessageMail>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RequestConfirmation> _binding = new (
			new() {

			{ "Text", new PropertyString ("Text", 
					(IBinding data, string? value) => {(data as RequestConfirmation).Text = value;}, (IBinding data) => (data as RequestConfirmation).Text )}
        }, __Tag,() => new RequestConfirmation(), () => new List<RequestConfirmation>(), () => new Dictionary<string,RequestConfirmation>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Request")]
	public virtual Enveloped<RequestConfirmation>?					Request  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Accept")]
	public virtual bool?					Accept  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResponseConfirmation> _binding = new (
			new() {

			{ "Request", new PropertyStruct ("Request", typeof (Enveloped<RequestConfirmation>),
					(IBinding data, object? value) => {(data as ResponseConfirmation).Request = value as Enveloped<RequestConfirmation>;}, (IBinding data) => (data as ResponseConfirmation).Request,
					false, ()=>new  Enveloped<RequestConfirmation>(), ()=>new Enveloped<RequestConfirmation>())},
			{ "Accept", new PropertyBoolean ("Accept", 
					(IBinding data, bool? value) => {(data as ResponseConfirmation).Accept = value;}, (IBinding data) => (data as ResponseConfirmation).Accept )}
        }, __Tag,() => new ResponseConfirmation(), () => new List<ResponseConfirmation>(), () => new Dictionary<string,ResponseConfirmation>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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
	public static readonly new Binding<RequestTask> _binding = new (
			new() {

        }, __Tag,() => new RequestTask(), () => new List<RequestTask>(), () => new Dictionary<string,RequestTask>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("PublicationId")]
	public virtual string?					PublicationId  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("ServiceAuthenticate")]
	public virtual string?					ServiceAuthenticate  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("DeviceAuthenticate")]
	public virtual string?					DeviceAuthenticate  {get; set;}

        /// <summary>
        /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageClaim> _binding = new (
			new() {

			{ "PublicationId", new PropertyString ("PublicationId", 
					(IBinding data, string? value) => {(data as MessageClaim).PublicationId = value;}, (IBinding data) => (data as MessageClaim).PublicationId )},
			{ "ServiceAuthenticate", new PropertyString ("ServiceAuthenticate", 
					(IBinding data, string? value) => {(data as MessageClaim).ServiceAuthenticate = value;}, (IBinding data) => (data as MessageClaim).ServiceAuthenticate )},
			{ "DeviceAuthenticate", new PropertyString ("DeviceAuthenticate", 
					(IBinding data, string? value) => {(data as MessageClaim).DeviceAuthenticate = value;}, (IBinding data) => (data as MessageClaim).DeviceAuthenticate )},
			{ "Expires", new PropertyDateTime ("Expires", 
					(IBinding data, DateTime? value) => {(data as MessageClaim).Expires = value;}, (IBinding data) => (data as MessageClaim).Expires )}
        }, __Tag,() => new MessageClaim(), () => new List<MessageClaim>(), () => new Dictionary<string,MessageClaim>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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

	[JsonPropertyName("Success")]
	public virtual bool?					Success  {get; set;}

        /// <summary>
        ///The error report code.
        /// </summary>

	[JsonPropertyName("ErrorReport")]
	public virtual string?					ErrorReport  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResult> _binding = new (
			new() {

			{ "Success", new PropertyBoolean ("Success", 
					(IBinding data, bool? value) => {(data as ProcessResult).Success = value;}, (IBinding data) => (data as ProcessResult).Success )},
			{ "ErrorReport", new PropertyString ("ErrorReport", 
					(IBinding data, string? value) => {(data as ProcessResult).ErrorReport = value;}, (IBinding data) => (data as ProcessResult).ErrorReport )}
        }, __Tag,() => new ProcessResult(), () => new List<ProcessResult>(), () => new Dictionary<string,ProcessResult>(),Message._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(Message._binding, _binding);


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
	public static readonly new Binding<ProcessResultNotSupported> _binding = new (
			new() {

        }, __Tag,() => new ProcessResultNotSupported(), () => new List<ProcessResultNotSupported>(), () => new Dictionary<string,ProcessResultNotSupported>(),ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProcessResult._binding, _binding);


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
	public static readonly new Binding<ProcessResultNotFound> _binding = new (
			new() {

        }, __Tag,() => new ProcessResultNotFound(), () => new List<ProcessResultNotFound>(), () => new Dictionary<string,ProcessResultNotFound>(),ProcessResult._binding);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(ProcessResult._binding, _binding);


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



