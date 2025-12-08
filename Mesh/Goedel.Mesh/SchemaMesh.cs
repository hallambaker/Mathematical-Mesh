
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
//  This file was automatically generated at 12/8/2025 12:16:49 PM
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
	    {typeof(CryptoKeyIndex), CryptoKeyIndex._binding},
	    {typeof(MeshContact), MeshContact._binding},
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
		AddDictionary(ref _bindingDictionary);
		}

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
	public virtual string?					Udf  {get; set;} //

    /// <summary>
    ///List of X.509 Certificates
    /// </summary>

	[JsonPropertyName("X509Certificate")]
	public virtual byte[]?					X509Certificate  {get; set;} //

    /// <summary>
    ///X.509 Certificate chain.
    /// </summary>

	[JsonPropertyName("X509Chain")]
	public virtual List<byte[]>?					X509Chain  {get; set;}
    /// <summary>
    ///X.509 Certificate Signing Request.
    /// </summary>

	[JsonPropertyName("X509CSR")]
	public virtual byte[]?					X509CSR  {get; set;} //

    /// <summary>
    ///If present specifies a time instant that use of the private key
    ///is not valid before.
    /// </summary>

	[JsonPropertyName("NotBefore")]
	public virtual DateTime?					NotBefore  {get; set;} //

    /// <summary>
    ///If present specifies a time instant that use of the private key
    ///is not valid on or after.
    /// </summary>

	[JsonPropertyName("NotOnOrAfter")]
	public virtual DateTime?					NotOnOrAfter  {get; set;} //

    /// <summary>
    ///The public key parameters as defined in the JOSE specification.
    /// </summary>

	[JsonPropertyName("PublicParameters")]
	public virtual Key?					PublicParameters  {get; set;} //

    /// <summary>
    ///The private key parameters as defined in the JOSE specification.
    /// </summary>

	[JsonPropertyName("PrivateParameters")]
	public virtual Key?					PrivateParameters  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Udf", 
					(data, value) => {(data as KeyData).Udf = value;}, 
					data => (data as KeyData).Udf ),
		new PropertyBinary ("X509Certificate", 
					(data, value) => {(data as KeyData).X509Certificate = value;}, 
					data => (data as KeyData).X509Certificate ),
		new PropertyListBinary ("X509Chain", 
					(data, value) => {(data as KeyData).X509Chain = value;}, 
					data => (data as KeyData).X509Chain ),
		new PropertyBinary ("X509CSR", 
					(data, value) => {(data as KeyData).X509CSR = value;}, 
					data => (data as KeyData).X509CSR ),
		new PropertyDateTime ("NotBefore", 
					(data, value) => {(data as KeyData).NotBefore = value;}, 
					data => (data as KeyData).NotBefore ),
		new PropertyDateTime ("NotOnOrAfter", 
					(data, value) => {(data as KeyData).NotOnOrAfter = value;}, 
					data => (data as KeyData).NotOnOrAfter ),
		new PropertyStruct ("PublicParameters", typeof (Key), 
					(data, value) => {(data as KeyData).PublicParameters = value as Key;}, 
					data => (data as KeyData).PublicParameters,
					true) ,
		new PropertyStruct ("PrivateParameters", typeof (Key), 
					(data, value) => {(data as KeyData).PrivateParameters = value as Key;}, 
					data => (data as KeyData).PrivateParameters,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyData> _binding = new (
			new() {
			{ "Udf", _properties [0]},
			{ "X509Certificate", _properties [1]},
			{ "X509Chain", _properties [2]},
			{ "X509CSR", _properties [3]},
			{ "NotBefore", _properties [4]},
			{ "NotOnOrAfter", _properties [5]},
			{ "PublicParameters", _properties [6]},
			{ "PrivateParameters", _properties [7]}}, __Tag,
		() => new KeyData(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class KeyShare : Key {
    /// <summary>
    ///The public key parameters of the primary key.
    /// </summary>

	[JsonPropertyName("PublicPrimary")]
	public virtual Key?					PublicPrimary  {get; set;} //

    /// <summary>
    ///The private key parameters of the share as defined in the JOSE specification.		
    /// </summary>

	[JsonPropertyName("Share")]
	public virtual Key?					Share  {get; set;} //

    /// <summary>
    ///The identifier used to claim the capability from the service.[Only present for
    ///a partial key.]
    /// </summary>

	[JsonPropertyName("ServiceId")]
	public virtual string?					ServiceId  {get; set;} //

    /// <summary>
    ///The service account that supports a serviced capability. [Only present for
    ///a partial key.]	
    /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("PublicPrimary", typeof (Key), 
					(data, value) => {(data as KeyShare).PublicPrimary = value as Key;}, 
					data => (data as KeyShare).PublicPrimary,
					true) ,
		new PropertyStruct ("Share", typeof (Key), 
					(data, value) => {(data as KeyShare).Share = value as Key;}, 
					data => (data as KeyShare).Share,
					true) ,
		new PropertyString ("ServiceId", 
					(data, value) => {(data as KeyShare).ServiceId = value;}, 
					data => (data as KeyShare).ServiceId ),
		new PropertyString ("ServiceAddress", 
					(data, value) => {(data as KeyShare).ServiceAddress = value;}, 
					data => (data as KeyShare).ServiceAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<KeyShare> _binding = new (
			new() {
			{ "PublicPrimary", _properties [0]},
			{ "Share", _properties [1]},
			{ "ServiceId", _properties [2]},
			{ "ServiceAddress", _properties [3]}}, __Tag,
		() => new KeyShare(), () => [], () => [], Key._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CompositePrivate : Key {
    /// <summary>
    ///UDF fingerprint of the bound device key (if used).
    /// </summary>

	[JsonPropertyName("DeviceKeyUdf")]
	public virtual string?					DeviceKeyUdf  {get; set;} //

    /// <summary>
    ///Private parameters of additive key
    /// </summary>

	[JsonPropertyName("PrivateSalt")]
	public virtual Key?					PrivateSalt  {get; set;} //

    /// <summary>
    ///Private parameters of serviced share
    /// </summary>

	[JsonPropertyName("ServiceShare")]
	public virtual Key?					ServiceShare  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("DeviceKeyUdf", 
					(data, value) => {(data as CompositePrivate).DeviceKeyUdf = value;}, 
					data => (data as CompositePrivate).DeviceKeyUdf ),
		new PropertyStruct ("PrivateSalt", typeof (Key), 
					(data, value) => {(data as CompositePrivate).PrivateSalt = value as Key;}, 
					data => (data as CompositePrivate).PrivateSalt,
					true) ,
		new PropertyStruct ("ServiceShare", typeof (Key), 
					(data, value) => {(data as CompositePrivate).ServiceShare = value as Key;}, 
					data => (data as CompositePrivate).ServiceShare,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CompositePrivate> _binding = new (
			new() {
			{ "DeviceKeyUdf", _properties [0]},
			{ "PrivateSalt", _properties [1]},
			{ "ServiceShare", _properties [2]}}, __Tag,
		() => new CompositePrivate(), () => [], () => [], Key._binding, Generic: false);


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
	public virtual DateTime?					Updated  {get; set;} //

    /// <summary>
    ///A Uniform Notary Token providing evidence that a signature
    ///was performed after the notary token was created.
    /// </summary>

	[JsonPropertyName("NotaryToken")]
	public virtual string?					NotaryToken  {get; set;} //

    /// <summary>
    ///Conditional clause(s) that MAY be verified to evaluate the validity of the
    ///assertion. At present no condition classes are specified.
    /// </summary>

	[JsonPropertyName("Conditions")]
	public virtual Condition?					Conditions  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Names", 
					(data, value) => {(data as Assertion).Names = value;}, 
					data => (data as Assertion).Names ),
		new PropertyDateTime ("Updated", 
					(data, value) => {(data as Assertion).Updated = value;}, 
					data => (data as Assertion).Updated ),
		new PropertyString ("NotaryToken", 
					(data, value) => {(data as Assertion).NotaryToken = value;}, 
					data => (data as Assertion).NotaryToken ),
		new PropertyStruct ("Conditions", typeof (Condition), 
					(data, value) => {(data as Assertion).Conditions = value as Condition;}, 
					data => (data as Assertion).Conditions,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Assertion> _binding = new (
			new() {
			{ "Names", _properties [0]},
			{ "Updated", _properties [1]},
			{ "NotaryToken", _properties [2]},
			{ "Conditions", _properties [3]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Parent class from which all condition classes are derived.
	/// </summary>
abstract public partial class Condition : MeshItem {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Condition> _binding = new (
			new() {}, __Tag,
		null, () => [], () => [], null, Generic: false);


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
	public virtual string?					ActivationKey  {get; set;} //

    /// <summary>
    ///Activation of named account resource activations. These are separate from
    ///Application activations which are 
    /// </summary>

	[JsonPropertyName("Entries")]
	public virtual List<ActivationEntry>?					Entries  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ActivationKey", 
					(data, value) => {(data as Activation).ActivationKey = value;}, 
					data => (data as Activation).ActivationKey ),
		new PropertyListStruct ("Entries", typeof (ActivationEntry),
					(data, value) => {(data as Activation).Entries = value as List<ActivationEntry>;}, 
					data => (data as Activation).Entries,
					false, ()=>new  List<ActivationEntry>(), ()=>new ActivationEntry())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Activation> _binding = new (
			new() {
			{ "ActivationKey", _properties [0]},
			{ "Entries", _properties [1]}}, __Tag,
		() => new Activation(), () => [], () => [], Assertion._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationEntry : MeshItem {
    /// <summary>
    ///Name of the activated resource
    /// </summary>

	[JsonPropertyName("Resource")]
	public virtual string?					Resource  {get; set;} //

    /// <summary>
    ///The activation key or key share
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual KeyData?					Key  {get; set;} //

    /// <summary>
    ///The identifier used to claim the capability from the service.[Only present for
    ///a partial capability.]
    /// </summary>

	[JsonPropertyName("ServiceId")]
	public virtual string?					ServiceId  {get; set;} //

    /// <summary>
    ///The service account that supports a serviced capability. [Only present for
    ///a partial capability.]
    /// </summary>

	[JsonPropertyName("ServiceAddress")]
	public virtual string?					ServiceAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Resource", 
					(data, value) => {(data as ActivationEntry).Resource = value;}, 
					data => (data as ActivationEntry).Resource ),
		new PropertyStruct ("Key", typeof (KeyData),
					(data, value) => {(data as ActivationEntry).Key = value as KeyData;}, 
					data => (data as ActivationEntry).Key,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyString ("ServiceId", 
					(data, value) => {(data as ActivationEntry).ServiceId = value;}, 
					data => (data as ActivationEntry).ServiceId ),
		new PropertyString ("ServiceAddress", 
					(data, value) => {(data as ActivationEntry).ServiceAddress = value;}, 
					data => (data as ActivationEntry).ServiceAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationEntry> _binding = new (
			new() {
			{ "Resource", _properties [0]},
			{ "Key", _properties [1]},
			{ "ServiceId", _properties [2]},
			{ "ServiceAddress", _properties [3]}}, __Tag,
		() => new ActivationEntry(), () => [], () => [], null, Generic: false);


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
	public virtual string?					Description  {get; set;} //

    /// <summary>
    ///A list of binary UDF fingerprints of accepted root signature keys for the profile.
    ///The profile finderprint is calculated over the concatenation of the
    ///fingerprint URIs.
    /// </summary>

	[JsonPropertyName("RootUdfs")]
	public virtual List<byte[]>?					RootUdfs  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Description", 
					(data, value) => {(data as Profile).Description = value;}, 
					data => (data as Profile).Description ),
		new PropertyListBinary ("RootUdfs", 
					(data, value) => {(data as Profile).RootUdfs = value;}, 
					data => (data as Profile).RootUdfs )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Profile> _binding = new (
			new() {
			{ "Description", _properties [0]},
			{ "RootUdfs", _properties [1]}}, __Tag,
		null, () => [], () => [], Assertion._binding, Generic: false);


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
	public virtual KeyData?					Encryption  {get; set;} //

    /// <summary>
    ///Base key contribution for signature keys. 
    /// </summary>

	[JsonPropertyName("Signature")]
	public virtual KeyData?					Signature  {get; set;} //

    /// <summary>
    ///Base key contribution for authentication keys. 
    ///Also used to authenticate the device
    ///during connection to an account.
    /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Encryption", typeof (KeyData),
					(data, value) => {(data as ProfileDevice).Encryption = value as KeyData;}, 
					data => (data as ProfileDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Signature", typeof (KeyData),
					(data, value) => {(data as ProfileDevice).Signature = value as KeyData;}, 
					data => (data as ProfileDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Authentication", typeof (KeyData),
					(data, value) => {(data as ProfileDevice).Authentication = value as KeyData;}, 
					data => (data as ProfileDevice).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileDevice> _binding = new (
			new() {
			{ "Encryption", _properties [0]},
			{ "Signature", _properties [1]},
			{ "Authentication", _properties [2]}}, __Tag,
		() => new ProfileDevice(), () => [], () => [], Profile._binding, Generic: false);


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
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    ///The canonical DNS handle for the account (e.g. @alice.alt).
    /// </summary>

	[JsonPropertyName("AccountHandle")]
	public virtual string?					AccountHandle  {get; set;} //

    /// <summary>
    ///The fingerprint of the service profile to which the account is
    ///currently bound.
    /// </summary>

	[JsonPropertyName("ServiceUdf")]
	public virtual string?					ServiceUdf  {get; set;} //

    /// <summary>
    ///Escrow key associated with the account.
    /// </summary>

	[JsonPropertyName("EscrowEncryption")]
	public virtual KeyData?					EscrowEncryption  {get; set;} //

    /// <summary>
    ///Key used to sign connection assertions to the account.
    /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;} //

    /// <summary>
    ///Key currently used to encrypt data under this profile
    /// </summary>

	[JsonPropertyName("CommonEncryption")]
	public virtual KeyData?					CommonEncryption  {get; set;} //

    /// <summary>
    ///Key used to authenticate requests made under this user account.
    ///This key SHOULD NOT be provisioned to any device except for the
    ///purpose of enabling account recovery.
    /// </summary>

	[JsonPropertyName("CommonAuthentication")]
	public virtual KeyData?					CommonAuthentication  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as ProfileAccount).AccountAddress = value;}, 
					data => (data as ProfileAccount).AccountAddress ),
		new PropertyString ("AccountHandle", 
					(data, value) => {(data as ProfileAccount).AccountHandle = value;}, 
					data => (data as ProfileAccount).AccountHandle ),
		new PropertyString ("ServiceUdf", 
					(data, value) => {(data as ProfileAccount).ServiceUdf = value;}, 
					data => (data as ProfileAccount).ServiceUdf ),
		new PropertyStruct ("EscrowEncryption", typeof (KeyData),
					(data, value) => {(data as ProfileAccount).EscrowEncryption = value as KeyData;}, 
					data => (data as ProfileAccount).EscrowEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(data, value) => {(data as ProfileAccount).AdministratorSignature = value as KeyData;}, 
					data => (data as ProfileAccount).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("CommonEncryption", typeof (KeyData),
					(data, value) => {(data as ProfileAccount).CommonEncryption = value as KeyData;}, 
					data => (data as ProfileAccount).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("CommonAuthentication", typeof (KeyData),
					(data, value) => {(data as ProfileAccount).CommonAuthentication = value as KeyData;}, 
					data => (data as ProfileAccount).CommonAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileAccount> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "AccountHandle", _properties [1]},
			{ "ServiceUdf", _properties [2]},
			{ "EscrowEncryption", _properties [3]},
			{ "AdministratorSignature", _properties [4]},
			{ "CommonEncryption", _properties [5]},
			{ "CommonAuthentication", _properties [6]}}, __Tag,
		() => new ProfileAccount(), () => [], () => [], Profile._binding, Generic: false);


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
	public virtual KeyData?					CommonSignature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("CommonSignature", typeof (KeyData),
					(data, value) => {(data as ProfileUser).CommonSignature = value as KeyData;}, 
					data => (data as ProfileUser).CommonSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileUser> _binding = new (
			new() {
			{ "CommonSignature", _properties [0]}}, __Tag,
		() => new ProfileUser(), () => [], () => [], ProfileAccount._binding, Generic: false);


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
	public virtual byte[]?					Cover  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Cover", 
					(data, value) => {(data as ProfileGroup).Cover = value;}, 
					data => (data as ProfileGroup).Cover )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileGroup> _binding = new (
			new() {
			{ "Cover", _properties [0]}}, __Tag,
		() => new ProfileGroup(), () => [], () => [], ProfileAccount._binding, Generic: false);


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
	public virtual KeyData?					ServiceAuthentication  {get; set;} //

    /// <summary>
    ///Key used to encrypt data under this profile
    /// </summary>

	[JsonPropertyName("ServiceEncryption")]
	public virtual KeyData?					ServiceEncryption  {get; set;} //

    /// <summary>
    ///Key used to sign data under the account.
    /// </summary>

	[JsonPropertyName("ServiceSignature")]
	public virtual KeyData?					ServiceSignature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("ServiceAuthentication", typeof (KeyData),
					(data, value) => {(data as ProfileService).ServiceAuthentication = value as KeyData;}, 
					data => (data as ProfileService).ServiceAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("ServiceEncryption", typeof (KeyData),
					(data, value) => {(data as ProfileService).ServiceEncryption = value as KeyData;}, 
					data => (data as ProfileService).ServiceEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("ServiceSignature", typeof (KeyData),
					(data, value) => {(data as ProfileService).ServiceSignature = value as KeyData;}, 
					data => (data as ProfileService).ServiceSignature,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileService> _binding = new (
			new() {
			{ "ServiceAuthentication", _properties [0]},
			{ "ServiceEncryption", _properties [1]},
			{ "ServiceSignature", _properties [2]}}, __Tag,
		() => new ProfileService(), () => [], () => [], Profile._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Profile of a Mesh Service
	/// </summary>
public partial class ProfileMeshService : ProfileService {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileMeshService> _binding = new (
			new() {}, __Tag,
		() => new ProfileMeshService(), () => [], () => [], ProfileService._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Profile of a Mesh Host providing one or more Mesh Services.
	/// </summary>
public partial class ProfileHost : ProfileDevice {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProfileHost> _binding = new (
			new() {}, __Tag,
		() => new ProfileHost(), () => [], () => [], ProfileDevice._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Connection : Assertion {
    /// <summary>
    ///UDF of the connection target.
    /// </summary>

	[JsonPropertyName("Subject")]
	public virtual string?					Subject  {get; set;} //

    /// <summary>
    ///UDF of the connection source.
    /// </summary>

	[JsonPropertyName("Authority")]
	public virtual string?					Authority  {get; set;} //

    /// <summary>
    ///The authentication key for use of the device under the profile
    /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Subject", 
					(data, value) => {(data as Connection).Subject = value;}, 
					data => (data as Connection).Subject ),
		new PropertyString ("Authority", 
					(data, value) => {(data as Connection).Authority = value;}, 
					data => (data as Connection).Authority ),
		new PropertyStruct ("Authentication", typeof (KeyData),
					(data, value) => {(data as Connection).Authentication = value as KeyData;}, 
					data => (data as Connection).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Connection> _binding = new (
			new() {
			{ "Subject", _properties [0]},
			{ "Authority", _properties [1]},
			{ "Authentication", _properties [2]}}, __Tag,
		() => new Connection(), () => [], () => [], Assertion._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CallsignBinding : Assertion {
    /// <summary>
    ///The canonical form of the callsign.
    /// </summary>

	[JsonPropertyName("Canonical")]
	public virtual string?					Canonical  {get; set;} //

    /// <summary>
    ///The display form of the callsign. This MAY include characters such as whitespace,
    ///trademark signifiers, etc. that are omitted of trranslated in the canonical form.
    /// </summary>

	[JsonPropertyName("Display")]
	public virtual string?					Display  {get; set;} //

    /// <summary>
    ///Specifies the page to which the Description"CharacterPageLatin"
    /// </summary>

	[JsonPropertyName("CharacterPage")]
	public virtual string?					CharacterPage  {get; set;} //

    /// <summary>
    ///The profile to which the name is bound.
    /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;} //

    /// <summary>
    ///The profile to which the name has been transfered.
    /// </summary>

	[JsonPropertyName("TransferUdf")]
	public virtual string?					TransferUdf  {get; set;} //

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
	public virtual string?					ServiceAddress  {get; set;} //

    /// <summary>
    ///Key currently used to encrypt data under this profile
    /// </summary>

	[JsonPropertyName("CommonEncryption")]
	public virtual KeyData?					CommonEncryption  {get; set;} //

    /// <summary>
    ///Self signed certificate signing certificate to be used as a root of
    ///trust for PKIX certificates under this callsign.
    /// </summary>

	[JsonPropertyName("PkixRoot")]
	public virtual byte[]?					PkixRoot  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Canonical", 
					(data, value) => {(data as CallsignBinding).Canonical = value;}, 
					data => (data as CallsignBinding).Canonical ),
		new PropertyString ("Display", 
					(data, value) => {(data as CallsignBinding).Display = value;}, 
					data => (data as CallsignBinding).Display ),
		new PropertyString ("CharacterPage", 
					(data, value) => {(data as CallsignBinding).CharacterPage = value;}, 
					data => (data as CallsignBinding).CharacterPage ),
		new PropertyString ("ProfileUdf", 
					(data, value) => {(data as CallsignBinding).ProfileUdf = value;}, 
					data => (data as CallsignBinding).ProfileUdf ),
		new PropertyString ("TransferUdf", 
					(data, value) => {(data as CallsignBinding).TransferUdf = value;}, 
					data => (data as CallsignBinding).TransferUdf ),
		new PropertyListStruct ("Services", typeof (NamedService),
					(data, value) => {(data as CallsignBinding).Services = value as List<NamedService>;}, 
					data => (data as CallsignBinding).Services,
					false, ()=>new  List<NamedService>(), ()=>new NamedService()),
		new PropertyString ("ServiceAddress", 
					(data, value) => {(data as CallsignBinding).ServiceAddress = value;}, 
					data => (data as CallsignBinding).ServiceAddress ),
		new PropertyStruct ("CommonEncryption", typeof (KeyData),
					(data, value) => {(data as CallsignBinding).CommonEncryption = value as KeyData;}, 
					data => (data as CallsignBinding).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyBinary ("PkixRoot", 
					(data, value) => {(data as CallsignBinding).PkixRoot = value;}, 
					data => (data as CallsignBinding).PkixRoot )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CallsignBinding> _binding = new (
			new() {
			{ "Canonical", _properties [0]},
			{ "Display", _properties [1]},
			{ "CharacterPage", _properties [2]},
			{ "ProfileUdf", _properties [3]},
			{ "TransferUdf", _properties [4]},
			{ "Services", _properties [5]},
			{ "ServiceAddress", _properties [6]},
			{ "CommonEncryption", _properties [7]},
			{ "PkixRoot", _properties [8]}}, __Tag,
		() => new CallsignBinding(), () => [], () => [], Assertion._binding, Generic: false);


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
	public virtual string?					Callsign  {get; set;} //

    /// <summary>
    ///The profile to which the accreditation applies.
    /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;} //

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
	public virtual DateTime?					Issued  {get; set;} //

    /// <summary>
    ///The time the assertion is due to expire
    /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;} //

    /// <summary>
    ///The issuing policy under which the validation was performed.
    /// </summary>

	[JsonPropertyName("Policy")]
	public virtual string?					Policy  {get; set;} //

    /// <summary>
    ///The issuing practices under which the validation was performed.
    /// </summary>

	[JsonPropertyName("Practice")]
	public virtual string?					Practice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Callsign", 
					(data, value) => {(data as Accreditation).Callsign = value;}, 
					data => (data as Accreditation).Callsign ),
		new PropertyString ("ProfileUdf", 
					(data, value) => {(data as Accreditation).ProfileUdf = value;}, 
					data => (data as Accreditation).ProfileUdf ),
		new PropertyListString ("SubjectNames", 
					(data, value) => {(data as Accreditation).SubjectNames = value;}, 
					data => (data as Accreditation).SubjectNames ),
		new PropertyListString ("SubjectLogos", 
					(data, value) => {(data as Accreditation).SubjectLogos = value;}, 
					data => (data as Accreditation).SubjectLogos ),
		new PropertyDateTime ("Issued", 
					(data, value) => {(data as Accreditation).Issued = value;}, 
					data => (data as Accreditation).Issued ),
		new PropertyDateTime ("Expires", 
					(data, value) => {(data as Accreditation).Expires = value;}, 
					data => (data as Accreditation).Expires ),
		new PropertyString ("Policy", 
					(data, value) => {(data as Accreditation).Policy = value;}, 
					data => (data as Accreditation).Policy ),
		new PropertyString ("Practice", 
					(data, value) => {(data as Accreditation).Practice = value;}, 
					data => (data as Accreditation).Practice )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Accreditation> _binding = new (
			new() {
			{ "Callsign", _properties [0]},
			{ "ProfileUdf", _properties [1]},
			{ "SubjectNames", _properties [2]},
			{ "SubjectLogos", _properties [3]},
			{ "Issued", _properties [4]},
			{ "Expires", _properties [5]},
			{ "Policy", _properties [6]},
			{ "Practice", _properties [7]}}, __Tag,
		() => new Accreditation(), () => [], () => [], Assertion._binding, Generic: false);


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
	public virtual string?					Account  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Account", 
					(data, value) => {(data as ConnectionStripped).Account = value;}, 
					data => (data as ConnectionStripped).Account )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionStripped> _binding = new (
			new() {
			{ "Account", _properties [0]}}, __Tag,
		() => new ConnectionStripped(), () => [], () => [], Connection._binding, Generic: false);


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
	public virtual string?					ProfileUdf  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ProfileUdf", 
					(data, value) => {(data as ConnectionService).ProfileUdf = value;}, 
					data => (data as ConnectionService).ProfileUdf )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionService> _binding = new (
			new() {
			{ "ProfileUdf", _properties [0]}}, __Tag,
		() => new ConnectionService(), () => [], () => [], Connection._binding, Generic: false);


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
	public virtual KeyData?					Signature  {get; set;} //

    /// <summary>
    ///The encryption key for use of the device under the profile
    /// </summary>

	[JsonPropertyName("Encryption")]
	public virtual KeyData?					Encryption  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Roles", 
					(data, value) => {(data as ConnectionDevice).Roles = value;}, 
					data => (data as ConnectionDevice).Roles ),
		new PropertyStruct ("Signature", typeof (KeyData),
					(data, value) => {(data as ConnectionDevice).Signature = value as KeyData;}, 
					data => (data as ConnectionDevice).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Encryption", typeof (KeyData),
					(data, value) => {(data as ConnectionDevice).Encryption = value as KeyData;}, 
					data => (data as ConnectionDevice).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionDevice> _binding = new (
			new() {
			{ "Roles", _properties [0]},
			{ "Signature", _properties [1]},
			{ "Encryption", _properties [2]}}, __Tag,
		() => new ConnectionDevice(), () => [], () => [], ConnectionService._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Connection assertion stating that a particular device is 
	/// </summary>
public partial class ConnectionApplication : Connection {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionApplication> _binding = new (
			new() {}, __Tag,
		() => new ConnectionApplication(), () => [], () => [], Connection._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Describes the connection of a member to a group.
	/// </summary>
public partial class ConnectionGroup : Connection {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionGroup> _binding = new (
			new() {}, __Tag,
		() => new ConnectionGroup(), () => [], () => [], Connection._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class AccountHostAssignment : Assertion {
    /// <summary>
    ///The account being bound
    /// </summary>

	[JsonPropertyName("AccountAddess")]
	public virtual string?					AccountAddess  {get; set;} //

    /// <summary>
    ///Host address in Callsign, DNS or IP format in order of preference.
    /// </summary>

	[JsonPropertyName("HostAddresses")]
	public virtual List<string>?					HostAddresses  {get; set;}
    /// <summary>
    ///Encryption key to be used to encrypt data for the service to use.
    /// </summary>

	[JsonPropertyName("AccessEncrypt")]
	public virtual KeyData?					AccessEncrypt  {get; set;} //

    /// <summary>
    ///Profile of the callsign registry used by the service.
    /// </summary>

	[JsonPropertyName("CallsignServiceProfile")]
	public virtual ProfileAccount?					CallsignServiceProfile  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileService")]
	public virtual Enveloped<ProfileService>?					EnvelopedProfileService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileService?				ProfileService  => EnvelopedProfileService.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddess", 
					(data, value) => {(data as AccountHostAssignment).AccountAddess = value;}, 
					data => (data as AccountHostAssignment).AccountAddess ),
		new PropertyListString ("HostAddresses", 
					(data, value) => {(data as AccountHostAssignment).HostAddresses = value;}, 
					data => (data as AccountHostAssignment).HostAddresses ),
		new PropertyStruct ("AccessEncrypt", typeof (KeyData),
					(data, value) => {(data as AccountHostAssignment).AccessEncrypt = value as KeyData;}, 
					data => (data as AccountHostAssignment).AccessEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("CallsignServiceProfile", typeof (ProfileAccount),
					(data, value) => {(data as AccountHostAssignment).CallsignServiceProfile = value as ProfileAccount;}, 
					data => (data as AccountHostAssignment).CallsignServiceProfile,
					false, ()=>new  ProfileAccount(), ()=>new ProfileAccount()),
		new PropertyGStruct ("EnvelopedProfileService", typeof (Enveloped),
					(data, value) => {(data as AccountHostAssignment).EnvelopedProfileService = value as Enveloped<ProfileService>;},
					data => (data as AccountHostAssignment).EnvelopedProfileService,
					()=>new  Enveloped<ProfileService>(), ()=>new Enveloped<ProfileService>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccountHostAssignment> _binding = new (
			new() {
			{ "AccountAddess", _properties [0]},
			{ "HostAddresses", _properties [1]},
			{ "AccessEncrypt", _properties [2]},
			{ "CallsignServiceProfile", _properties [3]},
			{ "EnvelopedProfileService", _properties [4]}}, __Tag,
		() => new AccountHostAssignment(), () => [], () => [], Assertion._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ConnectionHost : Connection {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ConnectionHost> _binding = new (
			new() {}, __Tag,
		() => new ConnectionHost(), () => [], () => [], Connection._binding, Generic: false);


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
	public virtual string?					AccountUdf  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountUdf", 
					(data, value) => {(data as ActivationAccount).AccountUdf = value;}, 
					data => (data as ActivationAccount).AccountUdf )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationAccount> _binding = new (
			new() {
			{ "AccountUdf", _properties [0]}}, __Tag,
		() => new ActivationAccount(), () => [], () => [], Activation._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Contains activation data for device specific keys used in the context of a 
	/// Mesh host
	/// </summary>
public partial class ActivationHost : ActivationAccount {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationHost> _binding = new (
			new() {}, __Tag,
		() => new ActivationHost(), () => [], () => [], ActivationAccount._binding, Generic: false);


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
	public virtual KeyData?					AdministratorSignature  {get; set;} //

    /// <summary>
    ///Grant access to ProfileUser account encryption key
    /// </summary>

	[JsonPropertyName("Encryption")]
	public virtual KeyData?					Encryption  {get; set;} //

    /// <summary>
    ///Grant access to ProfileUser account authentication key
    /// </summary>

	[JsonPropertyName("Authentication")]
	public virtual KeyData?					Authentication  {get; set;} //

    /// <summary>
    ///Grant access to ProfileUser account signature key
    /// </summary>

	[JsonPropertyName("Signature")]
	public virtual KeyData?					Signature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("ProfileSignatures", typeof (KeyData),
					(data, value) => {(data as ActivationCommon).ProfileSignatures = value as List<KeyData>;}, 
					data => (data as ActivationCommon).ProfileSignatures,
					false, ()=>new  List<KeyData>(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(data, value) => {(data as ActivationCommon).AdministratorSignature = value as KeyData;}, 
					data => (data as ActivationCommon).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Encryption", typeof (KeyData),
					(data, value) => {(data as ActivationCommon).Encryption = value as KeyData;}, 
					data => (data as ActivationCommon).Encryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Authentication", typeof (KeyData),
					(data, value) => {(data as ActivationCommon).Authentication = value as KeyData;}, 
					data => (data as ActivationCommon).Authentication,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Signature", typeof (KeyData),
					(data, value) => {(data as ActivationCommon).Signature = value as KeyData;}, 
					data => (data as ActivationCommon).Signature,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationCommon> _binding = new (
			new() {
			{ "ProfileSignatures", _properties [0]},
			{ "AdministratorSignature", _properties [1]},
			{ "Encryption", _properties [2]},
			{ "Authentication", _properties [3]},
			{ "Signature", _properties [4]}}, __Tag,
		() => new ActivationCommon(), () => [], () => [], Activation._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplication : Activation {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplication> _binding = new (
			new() {}, __Tag,
		() => new ActivationApplication(), () => [], () => [], Activation._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationSsh : ActivationApplication {
    /// <summary>
    ///The SSH client key.
    /// </summary>

	[JsonPropertyName("ClientKey")]
	public virtual KeyData?					ClientKey  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("ClientKey", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationSsh).ClientKey = value as KeyData;}, 
					data => (data as ActivationApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationSsh> _binding = new (
			new() {
			{ "ClientKey", _properties [0]}}, __Tag,
		() => new ActivationApplicationSsh(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationMail : ActivationApplication {
    /// <summary>
    ///The S/Mime signature key
    /// </summary>

	[JsonPropertyName("SmimeSign")]
	public virtual KeyData?					SmimeSign  {get; set;} //

    /// <summary>
    ///The S/Mime encryption key
    /// </summary>

	[JsonPropertyName("SmimeEncrypt")]
	public virtual KeyData?					SmimeEncrypt  {get; set;} //

    /// <summary>
    ///The OpenPGP signature key
    /// </summary>

	[JsonPropertyName("OpenpgpSign")]
	public virtual KeyData?					OpenpgpSign  {get; set;} //

    /// <summary>
    ///The OpenPGP encryption key
    /// </summary>

	[JsonPropertyName("OpenpgpEncrypt")]
	public virtual KeyData?					OpenpgpEncrypt  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("SmimeSign", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationMail).SmimeSign = value as KeyData;}, 
					data => (data as ActivationApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("SmimeEncrypt", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationMail).SmimeEncrypt = value as KeyData;}, 
					data => (data as ActivationApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("OpenpgpSign", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationMail).OpenpgpSign = value as KeyData;}, 
					data => (data as ActivationApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("OpenpgpEncrypt", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationMail).OpenpgpEncrypt = value as KeyData;}, 
					data => (data as ActivationApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationMail> _binding = new (
			new() {
			{ "SmimeSign", _properties [0]},
			{ "SmimeEncrypt", _properties [1]},
			{ "OpenpgpSign", _properties [2]},
			{ "OpenpgpEncrypt", _properties [3]}}, __Tag,
		() => new ActivationApplicationMail(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationGroup : ActivationApplication {
    /// <summary>
    ///Key or capability allowing account encryption keys to be created 
    ///for new members.
    /// </summary>

	[JsonPropertyName("AccountEncryption")]
	public virtual KeyData?					AccountEncryption  {get; set;} //

    /// <summary>
    ///Key or capability allowing account updates, connection assertions
    ///etc to be signed.
    /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;} //

    /// <summary>
    ///Key or capability allowing administration of the group.
    /// </summary>

	[JsonPropertyName("AccountAuthentication")]
	public virtual KeyData?					AccountAuthentication  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionService?				ConnectionService  => EnvelopedConnectionService.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("AccountEncryption", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationGroup).AccountEncryption = value as KeyData;}, 
					data => (data as ActivationApplicationGroup).AccountEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationGroup).AdministratorSignature = value as KeyData;}, 
					data => (data as ActivationApplicationGroup).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AccountAuthentication", typeof (KeyData),
					(data, value) => {(data as ActivationApplicationGroup).AccountAuthentication = value as KeyData;}, 
					data => (data as ActivationApplicationGroup).AccountAuthentication,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyGStruct ("EnvelopedConnectionService", typeof (Enveloped),
					(data, value) => {(data as ActivationApplicationGroup).EnvelopedConnectionService = value as Enveloped<ConnectionService>;},
					data => (data as ActivationApplicationGroup).EnvelopedConnectionService,
					()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationGroup> _binding = new (
			new() {
			{ "AccountEncryption", _properties [0]},
			{ "AdministratorSignature", _properties [1]},
			{ "AccountAuthentication", _properties [2]},
			{ "EnvelopedConnectionService", _properties [3]}}, __Tag,
		() => new ActivationApplicationGroup(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationDeveloper : ActivationApplication {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationDeveloper> _binding = new (
			new() {}, __Tag,
		() => new ActivationApplicationDeveloper(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ActivationApplicationCredential : ActivationApplication {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ActivationApplicationCredential> _binding = new (
			new() {}, __Tag,
		() => new ActivationApplicationCredential(), () => [], () => [], ActivationApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
abstract public partial class ApplicationEntry : MeshItem {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Identifier")]
	public virtual string?					Identifier  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Identifier", 
					(data, value) => {(data as ApplicationEntry).Identifier = value;}, 
					data => (data as ApplicationEntry).Identifier )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntry> _binding = new (
			new() {
			{ "Identifier", _properties [0]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntrySsh : ApplicationEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationSsh")]
	public virtual Enveloped<ActivationApplicationSsh>?					EnvelopedActivationSsh  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationApplicationSsh?				ActivationSsh  => EnvelopedActivationSsh.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedActivationSsh", typeof (Enveloped),
					(data, value) => {(data as ApplicationEntrySsh).EnvelopedActivationSsh = value as Enveloped<ActivationApplicationSsh>;},
					data => (data as ApplicationEntrySsh).EnvelopedActivationSsh,
					()=>new  Enveloped<ActivationApplicationSsh>(), ()=>new Enveloped<ActivationApplicationSsh>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntrySsh> _binding = new (
			new() {
			{ "EnvelopedActivationSsh", _properties [0]}}, __Tag,
		() => new ApplicationEntrySsh(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryGroup : ApplicationEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationGroup")]
	public virtual Enveloped<ActivationApplicationGroup>?					EnvelopedActivationGroup  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationApplicationGroup?				ActivationGroup  => EnvelopedActivationGroup.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedActivationGroup", typeof (Enveloped),
					(data, value) => {(data as ApplicationEntryGroup).EnvelopedActivationGroup = value as Enveloped<ActivationApplicationGroup>;},
					data => (data as ApplicationEntryGroup).EnvelopedActivationGroup,
					()=>new  Enveloped<ActivationApplicationGroup>(), ()=>new Enveloped<ActivationApplicationGroup>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryGroup> _binding = new (
			new() {
			{ "EnvelopedActivationGroup", _properties [0]}}, __Tag,
		() => new ApplicationEntryGroup(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryMail : ApplicationEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationMail")]
	public virtual Enveloped<ActivationApplicationMail>?					EnvelopedActivationMail  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationApplicationMail?				ActivationMail  => EnvelopedActivationMail.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedActivationMail", typeof (Enveloped),
					(data, value) => {(data as ApplicationEntryMail).EnvelopedActivationMail = value as Enveloped<ActivationApplicationMail>;},
					data => (data as ApplicationEntryMail).EnvelopedActivationMail,
					()=>new  Enveloped<ActivationApplicationMail>(), ()=>new Enveloped<ActivationApplicationMail>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryMail> _binding = new (
			new() {
			{ "EnvelopedActivationMail", _properties [0]}}, __Tag,
		() => new ApplicationEntryMail(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryDeveloper : ApplicationEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationDeveloper")]
	public virtual Enveloped<ActivationApplicationDeveloper>?					EnvelopedActivationDeveloper  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationApplicationDeveloper?				ActivationDeveloper  => EnvelopedActivationDeveloper.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedActivationDeveloper", typeof (Enveloped),
					(data, value) => {(data as ApplicationEntryDeveloper).EnvelopedActivationDeveloper = value as Enveloped<ActivationApplicationDeveloper>;},
					data => (data as ApplicationEntryDeveloper).EnvelopedActivationDeveloper,
					()=>new  Enveloped<ActivationApplicationDeveloper>(), ()=>new Enveloped<ActivationApplicationDeveloper>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryDeveloper> _binding = new (
			new() {
			{ "EnvelopedActivationDeveloper", _properties [0]}}, __Tag,
		() => new ApplicationEntryDeveloper(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ApplicationEntryCredential : ApplicationEntry {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationCredential")]
	public virtual Enveloped<ActivationApplicationCredential>?					EnvelopedActivationCredential  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationApplicationCredential?				ActivationCredential  => EnvelopedActivationCredential.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedActivationCredential", typeof (Enveloped),
					(data, value) => {(data as ApplicationEntryCredential).EnvelopedActivationCredential = value as Enveloped<ActivationApplicationCredential>;},
					data => (data as ApplicationEntryCredential).EnvelopedActivationCredential,
					()=>new  Enveloped<ActivationApplicationCredential>(), ()=>new Enveloped<ActivationApplicationCredential>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ApplicationEntryCredential> _binding = new (
			new() {
			{ "EnvelopedActivationCredential", _properties [0]}}, __Tag,
		() => new ApplicationEntryCredential(), () => [], () => [], ApplicationEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Bookmark : MeshItem {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Role")]
	public virtual List<string>?					Role  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Uri", 
					(data, value) => {(data as Bookmark).Uri = value;}, 
					data => (data as Bookmark).Uri ),
		new PropertyString ("Title", 
					(data, value) => {(data as Bookmark).Title = value;}, 
					data => (data as Bookmark).Title ),
		new PropertyListString ("Role", 
					(data, value) => {(data as Bookmark).Role = value;}, 
					data => (data as Bookmark).Role )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Bookmark> _binding = new (
			new() {
			{ "Uri", _properties [0]},
			{ "Title", _properties [1]},
			{ "Role", _properties [2]}}, __Tag,
		() => new Bookmark(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Reference : MeshItem {
    /// <summary>
    ///The received message to which this is a response
    /// </summary>

	[JsonPropertyName("MessageId")]
	public virtual string?					MessageId  {get; set;} //

    /// <summary>
    ///Message that was generated in response to the original (optional).
    /// </summary>

	[JsonPropertyName("ResponseId")]
	public virtual string?					ResponseId  {get; set;} //

    /// <summary>
    ///The relationship type. This can be Read, Unread, Accept, Reject.
    /// </summary>

	[JsonPropertyName("Relationship")]
	public virtual string?					Relationship  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("MessageId", 
					(data, value) => {(data as Reference).MessageId = value;}, 
					data => (data as Reference).MessageId ),
		new PropertyString ("ResponseId", 
					(data, value) => {(data as Reference).ResponseId = value;}, 
					data => (data as Reference).ResponseId ),
		new PropertyString ("Relationship", 
					(data, value) => {(data as Reference).Relationship = value;}, 
					data => (data as Reference).Relationship )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Reference> _binding = new (
			new() {
			{ "MessageId", _properties [0]},
			{ "ResponseId", _properties [1]},
			{ "Relationship", _properties [2]}}, __Tag,
		() => new Reference(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class Engagement : MeshItem {
    /// <summary>
    ///Unique key.
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Start")]
	public virtual DateTime?					Start  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Finish")]
	public virtual DateTime?					Finish  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("StartTravel")]
	public virtual string?					StartTravel  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("FinishTravel")]
	public virtual string?					FinishTravel  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("TimeZone")]
	public virtual string?					TimeZone  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Description")]
	public virtual string?					Description  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Location")]
	public virtual string?					Location  {get; set;} //

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
	public virtual string?					Repeat  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Busy")]
	public virtual bool?					Busy  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as Engagement).Key = value;}, 
					data => (data as Engagement).Key ),
		new PropertyDateTime ("Start", 
					(data, value) => {(data as Engagement).Start = value;}, 
					data => (data as Engagement).Start ),
		new PropertyDateTime ("Finish", 
					(data, value) => {(data as Engagement).Finish = value;}, 
					data => (data as Engagement).Finish ),
		new PropertyString ("StartTravel", 
					(data, value) => {(data as Engagement).StartTravel = value;}, 
					data => (data as Engagement).StartTravel ),
		new PropertyString ("FinishTravel", 
					(data, value) => {(data as Engagement).FinishTravel = value;}, 
					data => (data as Engagement).FinishTravel ),
		new PropertyString ("TimeZone", 
					(data, value) => {(data as Engagement).TimeZone = value;}, 
					data => (data as Engagement).TimeZone ),
		new PropertyString ("Title", 
					(data, value) => {(data as Engagement).Title = value;}, 
					data => (data as Engagement).Title ),
		new PropertyString ("Description", 
					(data, value) => {(data as Engagement).Description = value;}, 
					data => (data as Engagement).Description ),
		new PropertyString ("Location", 
					(data, value) => {(data as Engagement).Location = value;}, 
					data => (data as Engagement).Location ),
		new PropertyListString ("Trigger", 
					(data, value) => {(data as Engagement).Trigger = value;}, 
					data => (data as Engagement).Trigger ),
		new PropertyListString ("Conference", 
					(data, value) => {(data as Engagement).Conference = value;}, 
					data => (data as Engagement).Conference ),
		new PropertyString ("Repeat", 
					(data, value) => {(data as Engagement).Repeat = value;}, 
					data => (data as Engagement).Repeat ),
		new PropertyBoolean ("Busy", 
					(data, value) => {(data as Engagement).Busy = value;}, 
					data => (data as Engagement).Busy )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Engagement> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Start", _properties [1]},
			{ "Finish", _properties [2]},
			{ "StartTravel", _properties [3]},
			{ "FinishTravel", _properties [4]},
			{ "TimeZone", _properties [5]},
			{ "Title", _properties [6]},
			{ "Description", _properties [7]},
			{ "Location", _properties [8]},
			{ "Trigger", _properties [9]},
			{ "Conference", _properties [10]},
			{ "Repeat", _properties [11]},
			{ "Busy", _properties [12]}}, __Tag,
		() => new Engagement(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class WorkTask : Engagement {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Dependency")]
	public virtual List<string>?					Dependency  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Dependency", 
					(data, value) => {(data as WorkTask).Dependency = value;}, 
					data => (data as WorkTask).Dependency )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<WorkTask> _binding = new (
			new() {
			{ "Dependency", _properties [0]}}, __Tag,
		() => new WorkTask(), () => [], () => [], Engagement._binding, Generic: false);


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
	public virtual string?					Uid  {get; set;} //

    /// <summary>
    ///User specified identifier.
    /// </summary>

	[JsonPropertyName("LocalName")]
	public virtual string?					LocalName  {get; set;} //

    /// <summary>
    ///The set of labels describing the entry
    /// </summary>

	[JsonPropertyName("Path")]
	public virtual string?					Path  {get; set;} //

    /// <summary>
    ///Description
    /// </summary>

	[JsonPropertyName("Description")]
	public virtual string?					Description  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Uid", 
					(data, value) => {(data as CatalogedEntry).Uid = value;}, 
					data => (data as CatalogedEntry).Uid ),
		new PropertyString ("LocalName", 
					(data, value) => {(data as CatalogedEntry).LocalName = value;}, 
					data => (data as CatalogedEntry).LocalName ),
		new PropertyString ("Path", 
					(data, value) => {(data as CatalogedEntry).Path = value;}, 
					data => (data as CatalogedEntry).Path ),
		new PropertyString ("Description", 
					(data, value) => {(data as CatalogedEntry).Description = value;}, 
					data => (data as CatalogedEntry).Description )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedEntry> _binding = new (
			new() {
			{ "Uid", _properties [0]},
			{ "LocalName", _properties [1]},
			{ "Path", _properties [2]},
			{ "Description", _properties [3]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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
	public virtual DateTime?					Updated  {get; set;} //

    /// <summary>
    ///UDF of the signature key of the device in the Mesh
    /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;} //

    /// <summary>
    ///Device Platform
    /// </summary>

	[JsonPropertyName("Platform")]
	public virtual string?					Platform  {get; set;} //

    /// <summary>
    ///UDF of the offline signature key of the device
    /// </summary>

	[JsonPropertyName("DeviceUdf")]
	public virtual string?					DeviceUdf  {get; set;} //

    /// <summary>
    ///UDF of the account online signature key
    /// </summary>

	[JsonPropertyName("SignatureUdf")]
	public virtual string?					SignatureUdf  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileUser")]
	public virtual Enveloped<ProfileUser>?					EnvelopedProfileUser  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileUser?				ProfileUser  => EnvelopedProfileUser.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileDevice?				ProfileDevice  => EnvelopedProfileDevice.Decode();
    /// <summary>
    ///Description of the device
    /// </summary>

	[JsonPropertyName("DeviceDescription")]
	public virtual DeviceDescription?					DeviceDescription  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionService?				ConnectionService  => EnvelopedConnectionService.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionDevice")]
	public virtual Enveloped<ConnectionDevice>?					EnvelopedConnectionDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionDevice?				ConnectionDevice  => EnvelopedConnectionDevice.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationAccount")]
	public virtual Enveloped<ActivationAccount>?					EnvelopedActivationAccount  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationAccount?				ActivationAccount  => EnvelopedActivationAccount.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationCommon?				ActivationCommon  => EnvelopedActivationCommon.Decode();
    /// <summary>
    ///Application activations granted to the device.
    /// </summary>

	[JsonPropertyName("ApplicationEntries")]
	public virtual List<ApplicationEntry>?					ApplicationEntries  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDateTime ("Updated", 
					(data, value) => {(data as CatalogedDevice).Updated = value;}, 
					data => (data as CatalogedDevice).Updated ),
		new PropertyString ("Udf", 
					(data, value) => {(data as CatalogedDevice).Udf = value;}, 
					data => (data as CatalogedDevice).Udf ),
		new PropertyString ("Platform", 
					(data, value) => {(data as CatalogedDevice).Platform = value;}, 
					data => (data as CatalogedDevice).Platform ),
		new PropertyString ("DeviceUdf", 
					(data, value) => {(data as CatalogedDevice).DeviceUdf = value;}, 
					data => (data as CatalogedDevice).DeviceUdf ),
		new PropertyString ("SignatureUdf", 
					(data, value) => {(data as CatalogedDevice).SignatureUdf = value;}, 
					data => (data as CatalogedDevice).SignatureUdf ),
		new PropertyGStruct ("EnvelopedProfileUser", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedProfileUser = value as Enveloped<ProfileUser>;},
					data => (data as CatalogedDevice).EnvelopedProfileUser,
					()=>new  Enveloped<ProfileUser>(), ()=>new Enveloped<ProfileUser>()),
		new PropertyGStruct ("EnvelopedProfileDevice", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;},
					data => (data as CatalogedDevice).EnvelopedProfileDevice,
					()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>()),
		new PropertyStruct ("DeviceDescription", typeof (DeviceDescription),
					(data, value) => {(data as CatalogedDevice).DeviceDescription = value as DeviceDescription;}, 
					data => (data as CatalogedDevice).DeviceDescription,
					false, ()=>new  DeviceDescription(), ()=>new DeviceDescription()),
		new PropertyGStruct ("EnvelopedConnectionService", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedConnectionService = value as Enveloped<ConnectionService>;},
					data => (data as CatalogedDevice).EnvelopedConnectionService,
					()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>()),
		new PropertyGStruct ("EnvelopedConnectionDevice", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;},
					data => (data as CatalogedDevice).EnvelopedConnectionDevice,
					()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>()),
		new PropertyGStruct ("EnvelopedActivationAccount", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedActivationAccount = value as Enveloped<ActivationAccount>;},
					data => (data as CatalogedDevice).EnvelopedActivationAccount,
					()=>new  Enveloped<ActivationAccount>(), ()=>new Enveloped<ActivationAccount>()),
		new PropertyGStruct ("EnvelopedActivationCommon", typeof (Enveloped),
					(data, value) => {(data as CatalogedDevice).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;},
					data => (data as CatalogedDevice).EnvelopedActivationCommon,
					()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>()),
		new PropertyListStruct ("ApplicationEntries", typeof (ApplicationEntry), 
					(data, value) => {(data as CatalogedDevice).ApplicationEntries = value as List<ApplicationEntry>;}, 
					data => (data as CatalogedDevice).ApplicationEntries,
					true, ()=>new List<ApplicationEntry>()
) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedDevice> _binding = new (
			new() {
			{ "Updated", _properties [0]},
			{ "Udf", _properties [1]},
			{ "Platform", _properties [2]},
			{ "DeviceUdf", _properties [3]},
			{ "SignatureUdf", _properties [4]},
			{ "EnvelopedProfileUser", _properties [5]},
			{ "EnvelopedProfileDevice", _properties [6]},
			{ "DeviceDescription", _properties [7]},
			{ "EnvelopedConnectionService", _properties [8]},
			{ "EnvelopedConnectionDevice", _properties [9]},
			{ "EnvelopedActivationAccount", _properties [10]},
			{ "EnvelopedActivationCommon", _properties [11]},
			{ "ApplicationEntries", _properties [12]}}, __Tag,
		() => new CatalogedDevice(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DeviceDescription : MeshItem {
    /// <summary>
    ///The device form factor, valid values are Desktop, Phone, Tablet, TV, Watch
    /// </summary>

	[JsonPropertyName("Idiom")]
	public virtual string?					Idiom  {get; set;} //

    /// <summary>
    ///Manufacturer name
    /// </summary>

	[JsonPropertyName("Manufacturer")]
	public virtual string?					Manufacturer  {get; set;} //

    /// <summary>
    ///Manufacturer defined model
    /// </summary>

	[JsonPropertyName("Model")]
	public virtual string?					Model  {get; set;} //

    /// <summary>
    ///Name of the device as specified by the user
    /// </summary>

	[JsonPropertyName("Name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    ///The device platform or operating system: Android / iOS / macOS / Tizen / watchOS / Windows
    /// </summary>

	[JsonPropertyName("Platform")]
	public virtual string?					Platform  {get; set;} //

    /// <summary>
    ///Platform version in format Major.Minor.Build.Revision
    /// </summary>

	[JsonPropertyName("Version")]
	public virtual string?					Version  {get; set;} //

    /// <summary>
    ///EARL specifying an image of the device.
    /// </summary>

	[JsonPropertyName("ImageLocator")]
	public virtual string?					ImageLocator  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Idiom", 
					(data, value) => {(data as DeviceDescription).Idiom = value;}, 
					data => (data as DeviceDescription).Idiom ),
		new PropertyString ("Manufacturer", 
					(data, value) => {(data as DeviceDescription).Manufacturer = value;}, 
					data => (data as DeviceDescription).Manufacturer ),
		new PropertyString ("Model", 
					(data, value) => {(data as DeviceDescription).Model = value;}, 
					data => (data as DeviceDescription).Model ),
		new PropertyString ("Name", 
					(data, value) => {(data as DeviceDescription).Name = value;}, 
					data => (data as DeviceDescription).Name ),
		new PropertyString ("Platform", 
					(data, value) => {(data as DeviceDescription).Platform = value;}, 
					data => (data as DeviceDescription).Platform ),
		new PropertyString ("Version", 
					(data, value) => {(data as DeviceDescription).Version = value;}, 
					data => (data as DeviceDescription).Version ),
		new PropertyString ("ImageLocator", 
					(data, value) => {(data as DeviceDescription).ImageLocator = value;}, 
					data => (data as DeviceDescription).ImageLocator )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DeviceDescription> _binding = new (
			new() {
			{ "Idiom", _properties [0]},
			{ "Manufacturer", _properties [1]},
			{ "Model", _properties [2]},
			{ "Name", _properties [3]},
			{ "Platform", _properties [4]},
			{ "Version", _properties [5]},
			{ "ImageLocator", _properties [6]}}, __Tag,
		() => new DeviceDescription(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Cataloged Signature
	/// </summary>
public partial class CatalogedSignature : CatalogedEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedSignature> _binding = new (
			new() {}, __Tag,
		() => new CatalogedSignature(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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
	public virtual string?					Udf  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Filename")]
	public virtual string?					Filename  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Version")]
	public virtual string?					Version  {get; set;} //

    /// <summary>
    ///Locator to be used to retrieve the data.
    /// </summary>

	[JsonPropertyName("URI")]
	public virtual string?					URI  {get; set;} //

    /// <summary>
    ///IANA content type of the encoded content.
    /// </summary>

	[JsonPropertyName("ContentType")]
	public virtual string?					ContentType  {get; set;} //

    /// <summary>
    ///Content encoding, typically DARE envelope.
    /// </summary>

	[JsonPropertyName("Encoding")]
	public virtual string?					Encoding  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Created")]
	public virtual DateTime?					Created  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Updated")]
	public virtual DateTime?					Updated  {get; set;} //

    /// <summary>
    ///Encoded document length in bytes.
    /// </summary>

	[JsonPropertyName("Length")]
	public virtual int?					Length  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Udf", 
					(data, value) => {(data as CatalogedDocument).Udf = value;}, 
					data => (data as CatalogedDocument).Udf ),
		new PropertyString ("Filename", 
					(data, value) => {(data as CatalogedDocument).Filename = value;}, 
					data => (data as CatalogedDocument).Filename ),
		new PropertyString ("Title", 
					(data, value) => {(data as CatalogedDocument).Title = value;}, 
					data => (data as CatalogedDocument).Title ),
		new PropertyString ("Version", 
					(data, value) => {(data as CatalogedDocument).Version = value;}, 
					data => (data as CatalogedDocument).Version ),
		new PropertyString ("URI", 
					(data, value) => {(data as CatalogedDocument).URI = value;}, 
					data => (data as CatalogedDocument).URI ),
		new PropertyString ("ContentType", 
					(data, value) => {(data as CatalogedDocument).ContentType = value;}, 
					data => (data as CatalogedDocument).ContentType ),
		new PropertyString ("Encoding", 
					(data, value) => {(data as CatalogedDocument).Encoding = value;}, 
					data => (data as CatalogedDocument).Encoding ),
		new PropertyDateTime ("Created", 
					(data, value) => {(data as CatalogedDocument).Created = value;}, 
					data => (data as CatalogedDocument).Created ),
		new PropertyDateTime ("Updated", 
					(data, value) => {(data as CatalogedDocument).Updated = value;}, 
					data => (data as CatalogedDocument).Updated ),
		new PropertyInteger32 ("Length", 
					(data, value) => {(data as CatalogedDocument).Length = value;}, 
					data => (data as CatalogedDocument).Length )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedDocument> _binding = new (
			new() {
			{ "Udf", _properties [0]},
			{ "Filename", _properties [1]},
			{ "Title", _properties [2]},
			{ "Version", _properties [3]},
			{ "URI", _properties [4]},
			{ "ContentType", _properties [5]},
			{ "Encoding", _properties [6]},
			{ "Created", _properties [7]},
			{ "Updated", _properties [8]},
			{ "Length", _properties [9]}}, __Tag,
		() => new CatalogedDocument(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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
	public virtual string?					Id  {get; set;} //

    /// <summary>
    ///The witness key value to use to request access to the record.	
    /// </summary>

	[JsonPropertyName("Authenticator")]
	public virtual string?					Authenticator  {get; set;} //

    /// <summary>
    ///Dare Envelope containing the entry data. The data type is specified
    ///by the envelope metadata.
    /// </summary>

	[JsonPropertyName("EnvelopedData")]
	public virtual Enveloped?					EnvelopedData  {get; set;} //

    /// <summary>
    ///Epiration time (inclusive)
    /// </summary>

	[JsonPropertyName("NotOnOrAfter")]
	public virtual DateTime?					NotOnOrAfter  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(data, value) => {(data as CatalogedPublication).Id = value;}, 
					data => (data as CatalogedPublication).Id ),
		new PropertyString ("Authenticator", 
					(data, value) => {(data as CatalogedPublication).Authenticator = value;}, 
					data => (data as CatalogedPublication).Authenticator ),
		new PropertyStruct ("EnvelopedData", typeof (Enveloped),
					(data, value) => {(data as CatalogedPublication).EnvelopedData = value as Enveloped;}, 
					data => (data as CatalogedPublication).EnvelopedData,
					false, ()=>new  Enveloped(), ()=>new Enveloped()),
		new PropertyDateTime ("NotOnOrAfter", 
					(data, value) => {(data as CatalogedPublication).NotOnOrAfter = value;}, 
					data => (data as CatalogedPublication).NotOnOrAfter )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedPublication> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Authenticator", _properties [1]},
			{ "EnvelopedData", _properties [2]},
			{ "NotOnOrAfter", _properties [3]}}, __Tag,
		() => new CatalogedPublication(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedCredential : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Username")]
	public virtual string?					Username  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Password")]
	public virtual string?					Password  {get; set;} //

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
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Protocol", 
					(data, value) => {(data as CatalogedCredential).Protocol = value;}, 
					data => (data as CatalogedCredential).Protocol ),
		new PropertyString ("Service", 
					(data, value) => {(data as CatalogedCredential).Service = value;}, 
					data => (data as CatalogedCredential).Service ),
		new PropertyString ("Username", 
					(data, value) => {(data as CatalogedCredential).Username = value;}, 
					data => (data as CatalogedCredential).Username ),
		new PropertyString ("Password", 
					(data, value) => {(data as CatalogedCredential).Password = value;}, 
					data => (data as CatalogedCredential).Password ),
		new PropertyListStruct ("ClientAuthentication", typeof (KeyData),
					(data, value) => {(data as CatalogedCredential).ClientAuthentication = value as List<KeyData>;}, 
					data => (data as CatalogedCredential).ClientAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData()),
		new PropertyListStruct ("HostAuthentication", typeof (KeyData),
					(data, value) => {(data as CatalogedCredential).HostAuthentication = value as List<KeyData>;}, 
					data => (data as CatalogedCredential).HostAuthentication,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedCredential> _binding = new (
			new() {
			{ "Protocol", _properties [0]},
			{ "Service", _properties [1]},
			{ "Username", _properties [2]},
			{ "Password", _properties [3]},
			{ "ClientAuthentication", _properties [4]},
			{ "HostAuthentication", _properties [5]}}, __Tag,
		() => new CatalogedCredential(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedNetwork : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Service")]
	public virtual string?					Service  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Username")]
	public virtual string?					Username  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Password")]
	public virtual string?					Password  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Protocol", 
					(data, value) => {(data as CatalogedNetwork).Protocol = value;}, 
					data => (data as CatalogedNetwork).Protocol ),
		new PropertyString ("Service", 
					(data, value) => {(data as CatalogedNetwork).Service = value;}, 
					data => (data as CatalogedNetwork).Service ),
		new PropertyString ("Username", 
					(data, value) => {(data as CatalogedNetwork).Username = value;}, 
					data => (data as CatalogedNetwork).Username ),
		new PropertyString ("Password", 
					(data, value) => {(data as CatalogedNetwork).Password = value;}, 
					data => (data as CatalogedNetwork).Password )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedNetwork> _binding = new (
			new() {
			{ "Protocol", _properties [0]},
			{ "Service", _properties [1]},
			{ "Username", _properties [2]},
			{ "Password", _properties [3]}}, __Tag,
		() => new CatalogedNetwork(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedContact : CatalogedEntry {
    /// <summary>
    ///Unique key. 
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

    /// <summary>
    ///If true, this catalog entry is for the user who created the catalog.
    /// </summary>

	[JsonPropertyName("Self")]
	public virtual bool?					Self  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedJsContact")]
	public virtual Enveloped<JsContact>?					EnvelopedJsContact  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual JsContact?				JsContact  => EnvelopedJsContact.Decode();
    /// <summary>
    ///Mesh profiles
    /// </summary>

	[JsonPropertyName("VerifiedContacts")]
	public virtual List<MeshContact>?					VerifiedContacts  {get; set;}
    /// <summary>
    ///Private key shares
    /// </summary>

	[JsonPropertyName("KeyShares")]
	public virtual List<CryptoKeyIndex>?					KeyShares  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Key", 
					(data, value) => {(data as CatalogedContact).Key = value;}, 
					data => (data as CatalogedContact).Key ),
		new PropertyBoolean ("Self", 
					(data, value) => {(data as CatalogedContact).Self = value;}, 
					data => (data as CatalogedContact).Self ),
		new PropertyGStruct ("EnvelopedJsContact", typeof (Enveloped),
					(data, value) => {(data as CatalogedContact).EnvelopedJsContact = value as Enveloped<JsContact>;},
					data => (data as CatalogedContact).EnvelopedJsContact,
					()=>new  Enveloped<JsContact>(), ()=>new Enveloped<JsContact>()),
		new PropertyListStruct ("VerifiedContacts", typeof (MeshContact),
					(data, value) => {(data as CatalogedContact).VerifiedContacts = value as List<MeshContact>;}, 
					data => (data as CatalogedContact).VerifiedContacts,
					false, ()=>new  List<MeshContact>(), ()=>new MeshContact()),
		new PropertyListStruct ("KeyShares", typeof (CryptoKeyIndex),
					(data, value) => {(data as CatalogedContact).KeyShares = value as List<CryptoKeyIndex>;}, 
					data => (data as CatalogedContact).KeyShares,
					false, ()=>new  List<CryptoKeyIndex>(), ()=>new CryptoKeyIndex())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedContact> _binding = new (
			new() {
			{ "Key", _properties [0]},
			{ "Self", _properties [1]},
			{ "EnvelopedJsContact", _properties [2]},
			{ "VerifiedContacts", _properties [3]},
			{ "KeyShares", _properties [4]}}, __Tag,
		() => new CatalogedContact(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CryptoKeyIndex : MeshItem {
    /// <summary>
    ///The public key id
    /// </summary>

	[JsonPropertyName("AccountId")]
	public virtual string?					AccountId  {get; set;} //

    /// <summary>
    ///The public key id
    /// </summary>

	[JsonPropertyName("PublicKeyId")]
	public virtual string?					PublicKeyId  {get; set;} //

    /// <summary>
    ///The key share id
    /// </summary>

	[JsonPropertyName("KeyShareId")]
	public virtual string?					KeyShareId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountId", 
					(data, value) => {(data as CryptoKeyIndex).AccountId = value;}, 
					data => (data as CryptoKeyIndex).AccountId ),
		new PropertyString ("PublicKeyId", 
					(data, value) => {(data as CryptoKeyIndex).PublicKeyId = value;}, 
					data => (data as CryptoKeyIndex).PublicKeyId ),
		new PropertyString ("KeyShareId", 
					(data, value) => {(data as CryptoKeyIndex).KeyShareId = value;}, 
					data => (data as CryptoKeyIndex).KeyShareId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptoKeyIndex> _binding = new (
			new() {
			{ "AccountId", _properties [0]},
			{ "PublicKeyId", _properties [1]},
			{ "KeyShareId", _properties [2]}}, __Tag,
		() => new CryptoKeyIndex(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "CryptoKeyIndex";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CryptoKeyIndex();

	}


	/// <summary>
	/// </summary>
public partial class MeshContact : MeshItem {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Verification")]
	public virtual string?					Verification  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DirectAddress")]
	public virtual string?					DirectAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddresses")]
	public virtual List<string>?					AccountAddresses  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ProfileUdf")]
	public virtual string?					ProfileUdf  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ProfileType")]
	public virtual string?					ProfileType  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("CommonEncryption")]
	public virtual KeyData?					CommonEncryption  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AdministratorSignature")]
	public virtual KeyData?					AdministratorSignature  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Profile")]
	public virtual ProfileAccount?					Profile  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Verification", 
					(data, value) => {(data as MeshContact).Verification = value;}, 
					data => (data as MeshContact).Verification ),
		new PropertyString ("DirectAddress", 
					(data, value) => {(data as MeshContact).DirectAddress = value;}, 
					data => (data as MeshContact).DirectAddress ),
		new PropertyListString ("AccountAddresses", 
					(data, value) => {(data as MeshContact).AccountAddresses = value;}, 
					data => (data as MeshContact).AccountAddresses ),
		new PropertyString ("ProfileUdf", 
					(data, value) => {(data as MeshContact).ProfileUdf = value;}, 
					data => (data as MeshContact).ProfileUdf ),
		new PropertyString ("ProfileType", 
					(data, value) => {(data as MeshContact).ProfileType = value;}, 
					data => (data as MeshContact).ProfileType ),
		new PropertyStruct ("CommonEncryption", typeof (KeyData),
					(data, value) => {(data as MeshContact).CommonEncryption = value as KeyData;}, 
					data => (data as MeshContact).CommonEncryption,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("AdministratorSignature", typeof (KeyData),
					(data, value) => {(data as MeshContact).AdministratorSignature = value as KeyData;}, 
					data => (data as MeshContact).AdministratorSignature,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("Profile", typeof (ProfileAccount), 
					(data, value) => {(data as MeshContact).Profile = value as ProfileAccount;}, 
					data => (data as MeshContact).Profile,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MeshContact> _binding = new (
			new() {
			{ "Verification", _properties [0]},
			{ "DirectAddress", _properties [1]},
			{ "AccountAddresses", _properties [2]},
			{ "ProfileUdf", _properties [3]},
			{ "ProfileType", _properties [4]},
			{ "CommonEncryption", _properties [5]},
			{ "AdministratorSignature", _properties [6]},
			{ "Profile", _properties [7]}}, __Tag,
		() => new MeshContact(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "MeshContact";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new MeshContact();

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
	public virtual Capability?					Capability  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("Capability", typeof (Capability), 
					(data, value) => {(data as CatalogedAccess).Capability = value as Capability;}, 
					data => (data as CatalogedAccess).Capability,
					true) 
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedAccess> _binding = new (
			new() {
			{ "Capability", _properties [0]}}, __Tag,
		() => new CatalogedAccess(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Active")]
	public virtual bool?					Active  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Issued")]
	public virtual int?					Issued  {get; set;} //

    /// <summary>
    ///The authentication mode: Device, Account, PIN
    /// </summary>

	[JsonPropertyName("Mode")]
	public virtual string?					Mode  {get; set;} //

    /// <summary>
    ///Identifies the authentication credential. For a device, this is the authentication key identifier, 
    ///for an account, the profile identifier, for a PIN, the locator value of the PIN.
    /// </summary>

	[JsonPropertyName("Udf")]
	public virtual string?					Udf  {get; set;} //

    /// <summary>
    ///The verification value used to perform proof of knowledge of the secret.
    /// </summary>

	[JsonPropertyName("Witness")]
	public virtual string?					Witness  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Id", 
					(data, value) => {(data as Capability).Id = value;}, 
					data => (data as Capability).Id ),
		new PropertyBoolean ("Active", 
					(data, value) => {(data as Capability).Active = value;}, 
					data => (data as Capability).Active ),
		new PropertyInteger32 ("Issued", 
					(data, value) => {(data as Capability).Issued = value;}, 
					data => (data as Capability).Issued ),
		new PropertyString ("Mode", 
					(data, value) => {(data as Capability).Mode = value;}, 
					data => (data as Capability).Mode ),
		new PropertyString ("Udf", 
					(data, value) => {(data as Capability).Udf = value;}, 
					data => (data as Capability).Udf ),
		new PropertyString ("Witness", 
					(data, value) => {(data as Capability).Witness = value;}, 
					data => (data as Capability).Witness )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Capability> _binding = new (
			new() {
			{ "Id", _properties [0]},
			{ "Active", _properties [1]},
			{ "Issued", _properties [2]},
			{ "Mode", _properties [3]},
			{ "Udf", _properties [4]},
			{ "Witness", _properties [5]}}, __Tag,
		null, () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class NullCapability : Capability {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NullCapability> _binding = new (
			new() {}, __Tag,
		() => new NullCapability(), () => [], () => [], Capability._binding, Generic: false);


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
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedCatalogedDevice")]
	public virtual Enveloped<CatalogedDevice>?					EnvelopedCatalogedDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual CatalogedDevice?				CatalogedDevice  => EnvelopedCatalogedDevice.Decode();
    /// <summary>
    ///Digest value used to signal updates to envelope		
    /// </summary>

	[JsonPropertyName("CatalogedDeviceDigest")]
	public virtual string?					CatalogedDeviceDigest  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("Rights", 
					(data, value) => {(data as AccessCapability).Rights = value;}, 
					data => (data as AccessCapability).Rights ),
		new PropertyGStruct ("EnvelopedCatalogedDevice", typeof (Enveloped),
					(data, value) => {(data as AccessCapability).EnvelopedCatalogedDevice = value as Enveloped<CatalogedDevice>;},
					data => (data as AccessCapability).EnvelopedCatalogedDevice,
					()=>new  Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>()),
		new PropertyString ("CatalogedDeviceDigest", 
					(data, value) => {(data as AccessCapability).CatalogedDeviceDigest = value;}, 
					data => (data as AccessCapability).CatalogedDeviceDigest )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AccessCapability> _binding = new (
			new() {
			{ "Rights", _properties [0]},
			{ "EnvelopedCatalogedDevice", _properties [1]},
			{ "CatalogedDeviceDigest", _properties [2]}}, __Tag,
		() => new AccessCapability(), () => [], () => [], Capability._binding, Generic: false);


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
	public virtual string?					Identifier  {get; set;} //

    /// <summary>
    ///Document digest, this allows a status/claim request to 
    ///request an update to be returned only if the document
    ///has changed.
    /// </summary>

	[JsonPropertyName("Digest")]
	public virtual string?					Digest  {get; set;} //

    /// <summary>
    ///The published document.
    /// </summary>

	[JsonPropertyName("Data")]
	public virtual byte[]?					Data  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Identifier", 
					(data, value) => {(data as PublicationCapability).Identifier = value;}, 
					data => (data as PublicationCapability).Identifier ),
		new PropertyString ("Digest", 
					(data, value) => {(data as PublicationCapability).Digest = value;}, 
					data => (data as PublicationCapability).Digest ),
		new PropertyBinary ("Data", 
					(data, value) => {(data as PublicationCapability).Data = value;}, 
					data => (data as PublicationCapability).Data )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PublicationCapability> _binding = new (
			new() {
			{ "Identifier", _properties [0]},
			{ "Digest", _properties [1]},
			{ "Data", _properties [2]}}, __Tag,
		() => new PublicationCapability(), () => [], () => [], Capability._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
abstract public partial class CryptographicCapability : Capability {
    /// <summary>
    ///The key that enables the capability
    /// </summary>

	[JsonPropertyName("KeyData")]
	public virtual KeyData?					KeyData  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("GranteeAccount")]
	public virtual string?					GranteeAccount  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("GranteeUdf")]
	public virtual string?					GranteeUdf  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedKeyShare")]
	public virtual Enveloped<KeyData>?					EnvelopedKeyShare  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual KeyData?				KeyShare  => EnvelopedKeyShare.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("KeyData", typeof (KeyData),
					(data, value) => {(data as CryptographicCapability).KeyData = value as KeyData;}, 
					data => (data as CryptographicCapability).KeyData,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyString ("GranteeAccount", 
					(data, value) => {(data as CryptographicCapability).GranteeAccount = value;}, 
					data => (data as CryptographicCapability).GranteeAccount ),
		new PropertyString ("GranteeUdf", 
					(data, value) => {(data as CryptographicCapability).GranteeUdf = value;}, 
					data => (data as CryptographicCapability).GranteeUdf ),
		new PropertyGStruct ("EnvelopedKeyShare", typeof (Enveloped),
					(data, value) => {(data as CryptographicCapability).EnvelopedKeyShare = value as Enveloped<KeyData>;},
					data => (data as CryptographicCapability).EnvelopedKeyShare,
					()=>new  Enveloped<KeyData>(), ()=>new Enveloped<KeyData>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CryptographicCapability> _binding = new (
			new() {
			{ "KeyData", _properties [0]},
			{ "GranteeAccount", _properties [1]},
			{ "GranteeUdf", _properties [2]},
			{ "EnvelopedKeyShare", _properties [3]}}, __Tag,
		null, () => [], () => [], Capability._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The corresponding key is a decryption key
	/// </summary>
public partial class CapabilityDecrypt : CryptographicCapability {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityDecrypt> _binding = new (
			new() {}, __Tag,
		() => new CapabilityDecrypt(), () => [], () => [], CryptographicCapability._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The corresponding key is an encryption key
	/// </summary>
public partial class CapabilityDecryptPartial : CapabilityDecrypt {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityDecryptPartial> _binding = new (
			new() {}, __Tag,
		() => new CapabilityDecryptPartial(), () => [], () => [], CapabilityDecrypt._binding, Generic: false);


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
	public virtual string?					AuthenticationId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AuthenticationId", 
					(data, value) => {(data as CapabilityDecryptServiced).AuthenticationId = value;}, 
					data => (data as CapabilityDecryptServiced).AuthenticationId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityDecryptServiced> _binding = new (
			new() {
			{ "AuthenticationId", _properties [0]}}, __Tag,
		() => new CapabilityDecryptServiced(), () => [], () => [], CapabilityDecrypt._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The corresponding key is an administration key
	/// </summary>
public partial class CapabilitySign : CryptographicCapability {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilitySign> _binding = new (
			new() {}, __Tag,
		() => new CapabilitySign(), () => [], () => [], CryptographicCapability._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The corresponding key is a key that may be used to generate key shares.
	/// </summary>
public partial class CapabilityKeyGenerate : CryptographicCapability {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityKeyGenerate> _binding = new (
			new() {}, __Tag,
		() => new CapabilityKeyGenerate(), () => [], () => [], CryptographicCapability._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The corresponding key is a decryption key to be used in accordance 
	/// with the Micali Fair Electronic Exchange with Invisible Trusted Parties
	/// protocol.
	/// </summary>
public partial class CapabilityFairExchange : CryptographicCapability {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CapabilityFairExchange> _binding = new (
			new() {}, __Tag,
		() => new CapabilityFairExchange(), () => [], () => [], CryptographicCapability._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class NamedService : MeshItem {
    /// <summary>
    ///The IANA service name (e.g. dns)
    /// </summary>

	[JsonPropertyName("Prefix")]
	public virtual string?					Prefix  {get; set;} //

    /// <summary>
    ///Optional name mapping, (e.g. alice@example.com -> alice.mesh)
    /// </summary>

	[JsonPropertyName("Mapping")]
	public virtual string?					Mapping  {get; set;} //

    /// <summary>
    ///The service endpoints. This MAY be specified as a callsign (@alice),
    ///a DNS address (example.com), an IP address (10.0.0.1) or a fully
    ///qualified URI.
    /// </summary>

	[JsonPropertyName("Endpoints")]
	public virtual List<string>?					Endpoints  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Prefix", 
					(data, value) => {(data as NamedService).Prefix = value;}, 
					data => (data as NamedService).Prefix ),
		new PropertyString ("Mapping", 
					(data, value) => {(data as NamedService).Mapping = value;}, 
					data => (data as NamedService).Mapping ),
		new PropertyListString ("Endpoints", 
					(data, value) => {(data as NamedService).Endpoints = value;}, 
					data => (data as NamedService).Endpoints )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NamedService> _binding = new (
			new() {
			{ "Prefix", _properties [0]},
			{ "Mapping", _properties [1]},
			{ "Endpoints", _properties [2]}}, __Tag,
		() => new NamedService(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ServiceAccessToken : NamedService {
    /// <summary>
    ///Session initiation token
    /// </summary>

	[JsonPropertyName("Token")]
	public virtual byte[]?					Token  {get; set;} //

    /// <summary>
    ///Session shared secret
    /// </summary>

	[JsonPropertyName("SharedSecret")]
	public virtual byte[]?					SharedSecret  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBinary ("Token", 
					(data, value) => {(data as ServiceAccessToken).Token = value;}, 
					data => (data as ServiceAccessToken).Token ),
		new PropertyBinary ("SharedSecret", 
					(data, value) => {(data as ServiceAccessToken).SharedSecret = value;}, 
					data => (data as ServiceAccessToken).SharedSecret )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ServiceAccessToken> _binding = new (
			new() {
			{ "Token", _properties [0]},
			{ "SharedSecret", _properties [1]}}, __Tag,
		() => new ServiceAccessToken(), () => [], () => [], NamedService._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedBookmark : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;} //

    /// <summary>
    ///User comments on bookmark entry
    /// </summary>

	[JsonPropertyName("Comments")]
	public virtual List<string>?					Comments  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Uri", 
					(data, value) => {(data as CatalogedBookmark).Uri = value;}, 
					data => (data as CatalogedBookmark).Uri ),
		new PropertyString ("Title", 
					(data, value) => {(data as CatalogedBookmark).Title = value;}, 
					data => (data as CatalogedBookmark).Title ),
		new PropertyListString ("Comments", 
					(data, value) => {(data as CatalogedBookmark).Comments = value;}, 
					data => (data as CatalogedBookmark).Comments )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedBookmark> _binding = new (
			new() {
			{ "Uri", _properties [0]},
			{ "Title", _properties [1]},
			{ "Comments", _properties [2]}}, __Tag,
		() => new CatalogedBookmark(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedTask : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Title")]
	public virtual string?					Title  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedTask")]
	public virtual Enveloped<Engagement>?					EnvelopedTask  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual Engagement?				Task  => EnvelopedTask.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Title", 
					(data, value) => {(data as CatalogedTask).Title = value;}, 
					data => (data as CatalogedTask).Title ),
		new PropertyGStruct ("EnvelopedTask", typeof (Enveloped),
					(data, value) => {(data as CatalogedTask).EnvelopedTask = value as Enveloped<Engagement>;},
					data => (data as CatalogedTask).EnvelopedTask,
					()=>new  Enveloped<Engagement>(), ()=>new Enveloped<Engagement>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedTask> _binding = new (
			new() {
			{ "Title", _properties [0]},
			{ "EnvelopedTask", _properties [1]}}, __Tag,
		() => new CatalogedTask(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
abstract public partial class CatalogedApplication : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Default")]
	public virtual int?					Default  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Key")]
	public virtual string?					Key  {get; set;} //

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
	public virtual List<Enveloped>?					EnvelopedCapabilities  {get; set;}
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedEscrow")]
	public virtual List<Enveloped<KeyData>>?					EnvelopedEscrow  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual List<KeyData>?				Escrow  => EnvelopedEscrow.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("Default", 
					(data, value) => {(data as CatalogedApplication).Default = value;}, 
					data => (data as CatalogedApplication).Default ),
		new PropertyString ("Key", 
					(data, value) => {(data as CatalogedApplication).Key = value;}, 
					data => (data as CatalogedApplication).Key ),
		new PropertyListString ("Grant", 
					(data, value) => {(data as CatalogedApplication).Grant = value;}, 
					data => (data as CatalogedApplication).Grant ),
		new PropertyListString ("Deny", 
					(data, value) => {(data as CatalogedApplication).Deny = value;}, 
					data => (data as CatalogedApplication).Deny ),
		new PropertyListStruct ("EnvelopedCapabilities", typeof (Enveloped),
					(data, value) => {(data as CatalogedApplication).EnvelopedCapabilities = value as List<Enveloped>;}, 
					data => (data as CatalogedApplication).EnvelopedCapabilities,
					false, ()=>new  List<Enveloped>(), ()=>new Enveloped()),
		new PropertyListGStruct ("EnvelopedEscrow", typeof (Enveloped),
					(data, value) => {(data as CatalogedApplication).EnvelopedEscrow = value as List<Enveloped<KeyData>>;},
					data => (data as CatalogedApplication).EnvelopedEscrow,
					()=>new  List<Enveloped<KeyData>>(), ()=>new Enveloped<KeyData>(),
					(list,item)=>(list as List<Enveloped<KeyData>>).Add (item as Enveloped<KeyData>)
)
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplication> _binding = new (
			new() {
			{ "Default", _properties [0]},
			{ "Key", _properties [1]},
			{ "Grant", _properties [2]},
			{ "Deny", _properties [3]},
			{ "EnvelopedCapabilities", _properties [4]},
			{ "EnvelopedEscrow", _properties [5]}}, __Tag,
		null, () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedMember : CatalogedEntry {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ContactAddress")]
	public virtual string?					ContactAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("MemberCapabilityId")]
	public virtual string?					MemberCapabilityId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ServiceCapabilityId")]
	public virtual string?					ServiceCapabilityId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ContactAddress", 
					(data, value) => {(data as CatalogedMember).ContactAddress = value;}, 
					data => (data as CatalogedMember).ContactAddress ),
		new PropertyString ("MemberCapabilityId", 
					(data, value) => {(data as CatalogedMember).MemberCapabilityId = value;}, 
					data => (data as CatalogedMember).MemberCapabilityId ),
		new PropertyString ("ServiceCapabilityId", 
					(data, value) => {(data as CatalogedMember).ServiceCapabilityId = value;}, 
					data => (data as CatalogedMember).ServiceCapabilityId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedMember> _binding = new (
			new() {
			{ "ContactAddress", _properties [0]},
			{ "MemberCapabilityId", _properties [1]},
			{ "ServiceCapabilityId", _properties [2]}}, __Tag,
		() => new CatalogedMember(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedGroup : CatalogedApplication {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionAddress")]
	public virtual Enveloped<ConnectionStripped>?					EnvelopedConnectionAddress  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionStripped?				ConnectionAddress  => EnvelopedConnectionAddress.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileGroup")]
	public virtual Enveloped<ProfileGroup>?					EnvelopedProfileGroup  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileGroup?				ProfileGroup  => EnvelopedProfileGroup.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedActivationCommon")]
	public virtual Enveloped<ActivationCommon>?					EnvelopedActivationCommon  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ActivationCommon?				ActivationCommon  => EnvelopedActivationCommon.Decode();

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedConnectionAddress", typeof (Enveloped),
					(data, value) => {(data as CatalogedGroup).EnvelopedConnectionAddress = value as Enveloped<ConnectionStripped>;},
					data => (data as CatalogedGroup).EnvelopedConnectionAddress,
					()=>new  Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>()),
		new PropertyGStruct ("EnvelopedProfileGroup", typeof (Enveloped),
					(data, value) => {(data as CatalogedGroup).EnvelopedProfileGroup = value as Enveloped<ProfileGroup>;},
					data => (data as CatalogedGroup).EnvelopedProfileGroup,
					()=>new  Enveloped<ProfileGroup>(), ()=>new Enveloped<ProfileGroup>()),
		new PropertyGStruct ("EnvelopedActivationCommon", typeof (Enveloped),
					(data, value) => {(data as CatalogedGroup).EnvelopedActivationCommon = value as Enveloped<ActivationCommon>;},
					data => (data as CatalogedGroup).EnvelopedActivationCommon,
					()=>new  Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedGroup> _binding = new (
			new() {
			{ "EnvelopedConnectionAddress", _properties [0]},
			{ "EnvelopedProfileGroup", _properties [1]},
			{ "EnvelopedActivationCommon", _properties [2]}}, __Tag,
		() => new CatalogedGroup(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedFeed : CatalogedBookmark {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Protocol", 
					(data, value) => {(data as CatalogedFeed).Protocol = value;}, 
					data => (data as CatalogedFeed).Protocol )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedFeed> _binding = new (
			new() {
			{ "Protocol", _properties [0]}}, __Tag,
		() => new CatalogedFeed(), () => [], () => [], CatalogedBookmark._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationMail : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("InboundConnect")]
	public virtual string?					InboundConnect  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("OutboundConnect")]
	public virtual string?					OutboundConnect  {get; set;} //

    /// <summary>
    ///The S/Mime signature key
    /// </summary>

	[JsonPropertyName("SmimeSign")]
	public virtual KeyData?					SmimeSign  {get; set;} //

    /// <summary>
    ///The S/Mime encryption key
    /// </summary>

	[JsonPropertyName("SmimeEncrypt")]
	public virtual KeyData?					SmimeEncrypt  {get; set;} //

    /// <summary>
    ///The OpenPGP signature key
    /// </summary>

	[JsonPropertyName("OpenpgpSign")]
	public virtual KeyData?					OpenpgpSign  {get; set;} //

    /// <summary>
    ///The OpenPGP encryption key
    /// </summary>

	[JsonPropertyName("OpenpgpEncrypt")]
	public virtual KeyData?					OpenpgpEncrypt  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as CatalogedApplicationMail).AccountAddress = value;}, 
					data => (data as CatalogedApplicationMail).AccountAddress ),
		new PropertyString ("InboundConnect", 
					(data, value) => {(data as CatalogedApplicationMail).InboundConnect = value;}, 
					data => (data as CatalogedApplicationMail).InboundConnect ),
		new PropertyString ("OutboundConnect", 
					(data, value) => {(data as CatalogedApplicationMail).OutboundConnect = value;}, 
					data => (data as CatalogedApplicationMail).OutboundConnect ),
		new PropertyStruct ("SmimeSign", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationMail).SmimeSign = value as KeyData;}, 
					data => (data as CatalogedApplicationMail).SmimeSign,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("SmimeEncrypt", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationMail).SmimeEncrypt = value as KeyData;}, 
					data => (data as CatalogedApplicationMail).SmimeEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("OpenpgpSign", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationMail).OpenpgpSign = value as KeyData;}, 
					data => (data as CatalogedApplicationMail).OpenpgpSign,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyStruct ("OpenpgpEncrypt", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationMail).OpenpgpEncrypt = value as KeyData;}, 
					data => (data as CatalogedApplicationMail).OpenpgpEncrypt,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationMail> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "InboundConnect", _properties [1]},
			{ "OutboundConnect", _properties [2]},
			{ "SmimeSign", _properties [3]},
			{ "SmimeEncrypt", _properties [4]},
			{ "OpenpgpSign", _properties [5]},
			{ "OpenpgpEncrypt", _properties [6]}}, __Tag,
		() => new CatalogedApplicationMail(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationSsh : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    ///The Client authentication key
    /// </summary>

	[JsonPropertyName("ClientKey")]
	public virtual KeyData?					ClientKey  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as CatalogedApplicationSsh).AccountAddress = value;}, 
					data => (data as CatalogedApplicationSsh).AccountAddress ),
		new PropertyStruct ("ClientKey", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationSsh).ClientKey = value as KeyData;}, 
					data => (data as CatalogedApplicationSsh).ClientKey,
					false, ()=>new  KeyData(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationSsh> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "ClientKey", _properties [1]}}, __Tag,
		() => new CatalogedApplicationSsh(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationCredential : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Kind")]
	public virtual string?					Kind  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Contexts")]
	public virtual List<string>?					Contexts  {get; set;}
    /// <summary>
    ///The primary key, i.e. the OpenPGP public key or PKIX root certificate
    /// </summary>

	[JsonPropertyName("Primary")]
	public virtual KeyData?					Primary  {get; set;} //

    /// <summary>
    ///Secondary keys, i.e. OpenPGP sub keys or PKIX intermediate or end
    ///entity certificates.
    /// </summary>

	[JsonPropertyName("Secondary")]
	public virtual List<KeyData>?					Secondary  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as CatalogedApplicationCredential).AccountAddress = value;}, 
					data => (data as CatalogedApplicationCredential).AccountAddress ),
		new PropertyString ("Kind", 
					(data, value) => {(data as CatalogedApplicationCredential).Kind = value;}, 
					data => (data as CatalogedApplicationCredential).Kind ),
		new PropertyListString ("Contexts", 
					(data, value) => {(data as CatalogedApplicationCredential).Contexts = value;}, 
					data => (data as CatalogedApplicationCredential).Contexts ),
		new PropertyStruct ("Primary", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationCredential).Primary = value as KeyData;}, 
					data => (data as CatalogedApplicationCredential).Primary,
					false, ()=>new  KeyData(), ()=>new KeyData()),
		new PropertyListStruct ("Secondary", typeof (KeyData),
					(data, value) => {(data as CatalogedApplicationCredential).Secondary = value as List<KeyData>;}, 
					data => (data as CatalogedApplicationCredential).Secondary,
					false, ()=>new  List<KeyData>(), ()=>new KeyData())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationCredential> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "Kind", _properties [1]},
			{ "Contexts", _properties [2]},
			{ "Primary", _properties [3]},
			{ "Secondary", _properties [4]}}, __Tag,
		() => new CatalogedApplicationCredential(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationService : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Address")]
	public virtual string?					Address  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("AdministrationAddress")]
	public virtual string?					AdministrationAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Protocol")]
	public virtual string?					Protocol  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as CatalogedApplicationService).AccountAddress = value;}, 
					data => (data as CatalogedApplicationService).AccountAddress ),
		new PropertyString ("Address", 
					(data, value) => {(data as CatalogedApplicationService).Address = value;}, 
					data => (data as CatalogedApplicationService).Address ),
		new PropertyString ("AdministrationAddress", 
					(data, value) => {(data as CatalogedApplicationService).AdministrationAddress = value;}, 
					data => (data as CatalogedApplicationService).AdministrationAddress ),
		new PropertyString ("Protocol", 
					(data, value) => {(data as CatalogedApplicationService).Protocol = value;}, 
					data => (data as CatalogedApplicationService).Protocol )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationService> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "Address", _properties [1]},
			{ "AdministrationAddress", _properties [2]},
			{ "Protocol", _properties [3]}}, __Tag,
		() => new CatalogedApplicationService(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedApplicationDeveloper : CatalogedApplication {
    /// <summary>
    /// </summary>

	[JsonPropertyName("AccountAddress")]
	public virtual string?					AccountAddress  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Kind")]
	public virtual string?					Kind  {get; set;} //

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
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as CatalogedApplicationDeveloper).AccountAddress = value;}, 
					data => (data as CatalogedApplicationDeveloper).AccountAddress ),
		new PropertyString ("Kind", 
					(data, value) => {(data as CatalogedApplicationDeveloper).Kind = value;}, 
					data => (data as CatalogedApplicationDeveloper).Kind ),
		new PropertyListString ("Contexts", 
					(data, value) => {(data as CatalogedApplicationDeveloper).Contexts = value;}, 
					data => (data as CatalogedApplicationDeveloper).Contexts ),
		new PropertyListString ("Ssh", 
					(data, value) => {(data as CatalogedApplicationDeveloper).Ssh = value;}, 
					data => (data as CatalogedApplicationDeveloper).Ssh ),
		new PropertyListString ("Commit", 
					(data, value) => {(data as CatalogedApplicationDeveloper).Commit = value;}, 
					data => (data as CatalogedApplicationDeveloper).Commit ),
		new PropertyListString ("Code", 
					(data, value) => {(data as CatalogedApplicationDeveloper).Code = value;}, 
					data => (data as CatalogedApplicationDeveloper).Code )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedApplicationDeveloper> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]},
			{ "Kind", _properties [1]},
			{ "Contexts", _properties [2]},
			{ "Ssh", _properties [3]},
			{ "Commit", _properties [4]},
			{ "Code", _properties [5]}}, __Tag,
		() => new CatalogedApplicationDeveloper(), () => [], () => [], CatalogedApplication._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageInvoice : Message {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageInvoice> _binding = new (
			new() {}, __Tag,
		() => new MessageInvoice(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedReceipt : CatalogedEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedReceipt> _binding = new (
			new() {}, __Tag,
		() => new CatalogedReceipt(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class CatalogedTicket : CatalogedEntry {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<CatalogedTicket> _binding = new (
			new() {}, __Tag,
		() => new CatalogedTicket(), () => [], () => [], CatalogedEntry._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DevicePreconfigurationPublic : MeshItem {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileDevice")]
	public virtual Enveloped<ProfileDevice>?					EnvelopedProfileDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileDevice?				ProfileDevice  => EnvelopedProfileDevice.Decode();
    /// <summary>
    ///A list of URIs specifying hailing transports that may be used to
    ///initiate a connection to the device. This allows a device to 
    ///specify that it can be reached by WiFi transport to a particular 
    ///private SSID, or by Bluetooth, IR etc. etc.
    /// </summary>

	[JsonPropertyName("Hailing")]
	public virtual List<string>?					Hailing  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedProfileDevice", typeof (Enveloped),
					(data, value) => {(data as DevicePreconfigurationPublic).EnvelopedProfileDevice = value as Enveloped<ProfileDevice>;},
					data => (data as DevicePreconfigurationPublic).EnvelopedProfileDevice,
					()=>new  Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>()),
		new PropertyListString ("Hailing", 
					(data, value) => {(data as DevicePreconfigurationPublic).Hailing = value;}, 
					data => (data as DevicePreconfigurationPublic).Hailing )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DevicePreconfigurationPublic> _binding = new (
			new() {
			{ "EnvelopedProfileDevice", _properties [0]},
			{ "Hailing", _properties [1]}}, __Tag,
		() => new DevicePreconfigurationPublic(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// A data structure that is passed 
	/// </summary>
public partial class DevicePreconfigurationPrivate : DevicePreconfigurationPublic {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionDevice")]
	public virtual Enveloped<ConnectionDevice>?					EnvelopedConnectionDevice  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionDevice?				ConnectionDevice  => EnvelopedConnectionDevice.Decode();
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedConnectionService")]
	public virtual Enveloped<ConnectionService>?					EnvelopedConnectionService  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ConnectionService?				ConnectionService  => EnvelopedConnectionService.Decode();
    /// <summary>
    ///The device private key
    /// </summary>

	[JsonPropertyName("PrivateKey")]
	public virtual Key?					PrivateKey  {get; set;} //

    /// <summary>
    ///The connection URI. This would normally be printed on the device as a 
    ///QR code.
    /// </summary>

	[JsonPropertyName("ConnectUri")]
	public virtual string?					ConnectUri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedConnectionDevice", typeof (Enveloped),
					(data, value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice = value as Enveloped<ConnectionDevice>;},
					data => (data as DevicePreconfigurationPrivate).EnvelopedConnectionDevice,
					()=>new  Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>()),
		new PropertyGStruct ("EnvelopedConnectionService", typeof (Enveloped),
					(data, value) => {(data as DevicePreconfigurationPrivate).EnvelopedConnectionService = value as Enveloped<ConnectionService>;},
					data => (data as DevicePreconfigurationPrivate).EnvelopedConnectionService,
					()=>new  Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>()),
		new PropertyStruct ("PrivateKey", typeof (Key), 
					(data, value) => {(data as DevicePreconfigurationPrivate).PrivateKey = value as Key;}, 
					data => (data as DevicePreconfigurationPrivate).PrivateKey,
					true) ,
		new PropertyString ("ConnectUri", 
					(data, value) => {(data as DevicePreconfigurationPrivate).ConnectUri = value;}, 
					data => (data as DevicePreconfigurationPrivate).ConnectUri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DevicePreconfigurationPrivate> _binding = new (
			new() {
			{ "EnvelopedConnectionDevice", _properties [0]},
			{ "EnvelopedConnectionService", _properties [1]},
			{ "PrivateKey", _properties [2]},
			{ "ConnectUri", _properties [3]}}, __Tag,
		() => new DevicePreconfigurationPrivate(), () => [], () => [], DevicePreconfigurationPublic._binding, Generic: false);


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
	public virtual string?					MessageId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Sender")]
	public virtual string?					Sender  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Recipient")]
	public virtual string?					Recipient  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("MessageId", 
					(data, value) => {(data as Message).MessageId = value;}, 
					data => (data as Message).MessageId ),
		new PropertyString ("Sender", 
					(data, value) => {(data as Message).Sender = value;}, 
					data => (data as Message).Sender ),
		new PropertyString ("Recipient", 
					(data, value) => {(data as Message).Recipient = value;}, 
					data => (data as Message).Recipient )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Message> _binding = new (
			new() {
			{ "MessageId", _properties [0]},
			{ "Sender", _properties [1]},
			{ "Recipient", _properties [2]}}, __Tag,
		() => new Message(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageError : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("ErrorCode")]
	public virtual string?					ErrorCode  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("ErrorCode", 
					(data, value) => {(data as MessageError).ErrorCode = value;}, 
					data => (data as MessageError).ErrorCode )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageError> _binding = new (
			new() {
			{ "ErrorCode", _properties [0]}}, __Tag,
		() => new MessageError(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageComplete : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("References")]
	public virtual List<Reference>?					References  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("References", typeof (Reference),
					(data, value) => {(data as MessageComplete).References = value as List<Reference>;}, 
					data => (data as MessageComplete).References,
					false, ()=>new  List<Reference>(), ()=>new Reference())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageComplete> _binding = new (
			new() {
			{ "References", _properties [0]}}, __Tag,
		() => new MessageComplete(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageValidated : Message {
    /// <summary>
    ///Enveloped data that is authenticated by means of the PIN
    /// </summary>

	[JsonPropertyName("AuthenticatedData")]
	public virtual Enveloped?					AuthenticatedData  {get; set;} //

    /// <summary>
    ///Nonce provided by the client to validate the PIN
    /// </summary>

	[JsonPropertyName("ClientNonce")]
	public virtual byte[]?					ClientNonce  {get; set;} //

    /// <summary>
    ///Pin identifier value calculated from the PIN code, action and account address.
    /// </summary>

	[JsonPropertyName("PinId")]
	public virtual string?					PinId  {get; set;} //

    /// <summary>
    ///Witness value calculated as KDF (Device.Udf + AccountAddress, ClientNonce)
    /// </summary>

	[JsonPropertyName("PinWitness")]
	public virtual byte[]?					PinWitness  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("AuthenticatedData", typeof (Enveloped),
					(data, value) => {(data as MessageValidated).AuthenticatedData = value as Enveloped;}, 
					data => (data as MessageValidated).AuthenticatedData,
					false, ()=>new  Enveloped(), ()=>new Enveloped()),
		new PropertyBinary ("ClientNonce", 
					(data, value) => {(data as MessageValidated).ClientNonce = value;}, 
					data => (data as MessageValidated).ClientNonce ),
		new PropertyString ("PinId", 
					(data, value) => {(data as MessageValidated).PinId = value;}, 
					data => (data as MessageValidated).PinId ),
		new PropertyBinary ("PinWitness", 
					(data, value) => {(data as MessageValidated).PinWitness = value;}, 
					data => (data as MessageValidated).PinWitness )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageValidated> _binding = new (
			new() {
			{ "AuthenticatedData", _properties [0]},
			{ "ClientNonce", _properties [1]},
			{ "PinId", _properties [2]},
			{ "PinWitness", _properties [3]}}, __Tag,
		() => new MessageValidated(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessagePin : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Account")]
	public virtual string?					Account  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;} //

    /// <summary>
    ///If true, authentication against the PIN code is sufficient to complete
    ///the associated action without further authorization.
    /// </summary>

	[JsonPropertyName("Automatic")]
	public virtual bool?					Automatic  {get; set;} //

    /// <summary>
    ///PIN code bound to the specified action.
    /// </summary>

	[JsonPropertyName("SaltedPin")]
	public virtual string?					SaltedPin  {get; set;} //

    /// <summary>
    ///The action to which this PIN code is bound.
    /// </summary>

	[JsonPropertyName("Action")]
	public virtual string?					Action  {get; set;} //

    /// <summary>
    ///The set of rights bound to the PIN grant.
    /// </summary>

	[JsonPropertyName("Roles")]
	public virtual List<string>?					Roles  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Account", 
					(data, value) => {(data as MessagePin).Account = value;}, 
					data => (data as MessagePin).Account ),
		new PropertyDateTime ("Expires", 
					(data, value) => {(data as MessagePin).Expires = value;}, 
					data => (data as MessagePin).Expires ),
		new PropertyBoolean ("Automatic", 
					(data, value) => {(data as MessagePin).Automatic = value;}, 
					data => (data as MessagePin).Automatic ),
		new PropertyString ("SaltedPin", 
					(data, value) => {(data as MessagePin).SaltedPin = value;}, 
					data => (data as MessagePin).SaltedPin ),
		new PropertyString ("Action", 
					(data, value) => {(data as MessagePin).Action = value;}, 
					data => (data as MessagePin).Action ),
		new PropertyListString ("Roles", 
					(data, value) => {(data as MessagePin).Roles = value;}, 
					data => (data as MessagePin).Roles )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessagePin> _binding = new (
			new() {
			{ "Account", _properties [0]},
			{ "Expires", _properties [1]},
			{ "Automatic", _properties [2]},
			{ "SaltedPin", _properties [3]},
			{ "Action", _properties [4]},
			{ "Roles", _properties [5]}}, __Tag,
		() => new MessagePin(), () => [], () => [], Message._binding, Generic: false);


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
	public virtual string?					AccountAddress  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("AccountAddress", 
					(data, value) => {(data as RequestConnection).AccountAddress = value;}, 
					data => (data as RequestConnection).AccountAddress )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RequestConnection> _binding = new (
			new() {
			{ "AccountAddress", _properties [0]}}, __Tag,
		() => new RequestConnection(), () => [], () => [], MessageValidated._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Connection request message generated by a service on receipt of a valid
	/// MessageConnectionRequestClient
	/// </summary>
public partial class AcknowledgeConnection : Message {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedRequestConnection")]
	public virtual Enveloped<RequestConnection>?					EnvelopedRequestConnection  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual RequestConnection?				RequestConnection  => EnvelopedRequestConnection.Decode();
    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("ServerNonce")]
	public virtual byte[]?					ServerNonce  {get; set;} //

    /// <summary>
    ///
    /// </summary>

	[JsonPropertyName("Witness")]
	public virtual string?					Witness  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedRequestConnection", typeof (Enveloped),
					(data, value) => {(data as AcknowledgeConnection).EnvelopedRequestConnection = value as Enveloped<RequestConnection>;},
					data => (data as AcknowledgeConnection).EnvelopedRequestConnection,
					()=>new  Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>()),
		new PropertyBinary ("ServerNonce", 
					(data, value) => {(data as AcknowledgeConnection).ServerNonce = value;}, 
					data => (data as AcknowledgeConnection).ServerNonce ),
		new PropertyString ("Witness", 
					(data, value) => {(data as AcknowledgeConnection).Witness = value;}, 
					data => (data as AcknowledgeConnection).Witness )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AcknowledgeConnection> _binding = new (
			new() {
			{ "EnvelopedRequestConnection", _properties [0]},
			{ "ServerNonce", _properties [1]},
			{ "Witness", _properties [2]}}, __Tag,
		() => new AcknowledgeConnection(), () => [], () => [], Message._binding, Generic: false);


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
	public virtual string?					Result  {get; set;} //

	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedProfileUser")]
	public virtual Enveloped<ProfileUser>?					EnvelopedProfileUser  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual ProfileUser?				ProfileUser  => EnvelopedProfileUser.Decode();
    /// <summary>
    ///The device information. MUST be present if the value of Result is
    ///"Accept". MUST be absent or null otherwise.
    /// </summary>

	[JsonPropertyName("CatalogedDevice")]
	public virtual CatalogedDevice?					CatalogedDevice  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Result", 
					(data, value) => {(data as RespondConnection).Result = value;}, 
					data => (data as RespondConnection).Result ),
		new PropertyGStruct ("EnvelopedProfileUser", typeof (Enveloped),
					(data, value) => {(data as RespondConnection).EnvelopedProfileUser = value as Enveloped<ProfileUser>;},
					data => (data as RespondConnection).EnvelopedProfileUser,
					()=>new  Enveloped<ProfileUser>(), ()=>new Enveloped<ProfileUser>()),
		new PropertyStruct ("CatalogedDevice", typeof (CatalogedDevice),
					(data, value) => {(data as RespondConnection).CatalogedDevice = value as CatalogedDevice;}, 
					data => (data as RespondConnection).CatalogedDevice,
					false, ()=>new  CatalogedDevice(), ()=>new CatalogedDevice())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RespondConnection> _binding = new (
			new() {
			{ "Result", _properties [0]},
			{ "EnvelopedProfileUser", _properties [1]},
			{ "CatalogedDevice", _properties [2]}}, __Tag,
		() => new RespondConnection(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageContact : MessageValidated {
    /// <summary>
    ///If true, requests that the recipient return their own contact information
    ///in reply.
    /// </summary>

	[JsonPropertyName("Reply")]
	public virtual bool?					Reply  {get; set;} //

    /// <summary>
    ///Optional explanation of the reason for the request.
    /// </summary>

	[JsonPropertyName("Subject")]
	public virtual string?					Subject  {get; set;} //

    /// <summary>
    ///One time authentication code supplied to a recipient to allow authentication
    ///of the response.
    /// </summary>

	[JsonPropertyName("PIN")]
	public virtual string?					PIN  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Reply", 
					(data, value) => {(data as MessageContact).Reply = value;}, 
					data => (data as MessageContact).Reply ),
		new PropertyString ("Subject", 
					(data, value) => {(data as MessageContact).Subject = value;}, 
					data => (data as MessageContact).Subject ),
		new PropertyString ("PIN", 
					(data, value) => {(data as MessageContact).PIN = value;}, 
					data => (data as MessageContact).PIN )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageContact> _binding = new (
			new() {
			{ "Reply", _properties [0]},
			{ "Subject", _properties [1]},
			{ "PIN", _properties [2]}}, __Tag,
		() => new MessageContact(), () => [], () => [], MessageValidated._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class GroupInvitation : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;} //

    /// <summary>
    ///The contact data.
    /// </summary>

	[JsonPropertyName("Contact")]
	public virtual JsContact?					Contact  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Text", 
					(data, value) => {(data as GroupInvitation).Text = value;}, 
					data => (data as GroupInvitation).Text ),
		new PropertyStruct ("Contact", typeof (JsContact),
					(data, value) => {(data as GroupInvitation).Contact = value as JsContact;}, 
					data => (data as GroupInvitation).Contact,
					false, ()=>new  JsContact(), ()=>new JsContact())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<GroupInvitation> _binding = new (
			new() {
			{ "Text", _properties [0]},
			{ "Contact", _properties [1]}}, __Tag,
		() => new GroupInvitation(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageMail : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Text", 
					(data, value) => {(data as MessageMail).Text = value;}, 
					data => (data as MessageMail).Text )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageMail> _binding = new (
			new() {
			{ "Text", _properties [0]}}, __Tag,
		() => new MessageMail(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class RequestConfirmation : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Text")]
	public virtual string?					Text  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("Text", 
					(data, value) => {(data as RequestConfirmation).Text = value;}, 
					data => (data as RequestConfirmation).Text )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RequestConfirmation> _binding = new (
			new() {
			{ "Text", _properties [0]}}, __Tag,
		() => new RequestConfirmation(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ResponseConfirmation : Message {
	/// <summary>
	/// Wrapped property
    /// </summary>
	[JsonPropertyName("EnvelopedRequest")]
	public virtual Enveloped<RequestConfirmation>?					EnvelopedRequest  {get; set;} 

	/// <summary>
	/// Wrapped property
    /// </summary>
	public virtual RequestConfirmation?				Request  => EnvelopedRequest.Decode();
    /// <summary>
    /// </summary>

	[JsonPropertyName("Accept")]
	public virtual bool?					Accept  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyGStruct ("EnvelopedRequest", typeof (Enveloped),
					(data, value) => {(data as ResponseConfirmation).EnvelopedRequest = value as Enveloped<RequestConfirmation>;},
					data => (data as ResponseConfirmation).EnvelopedRequest,
					()=>new  Enveloped<RequestConfirmation>(), ()=>new Enveloped<RequestConfirmation>()),
		new PropertyBoolean ("Accept", 
					(data, value) => {(data as ResponseConfirmation).Accept = value;}, 
					data => (data as ResponseConfirmation).Accept )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResponseConfirmation> _binding = new (
			new() {
			{ "EnvelopedRequest", _properties [0]},
			{ "Accept", _properties [1]}}, __Tag,
		() => new ResponseConfirmation(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class RequestTask : Message {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RequestTask> _binding = new (
			new() {}, __Tag,
		() => new RequestTask(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class MessageClaim : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("PublicationId")]
	public virtual string?					PublicationId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("ServiceAuthenticate")]
	public virtual string?					ServiceAuthenticate  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("DeviceAuthenticate")]
	public virtual string?					DeviceAuthenticate  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("Expires")]
	public virtual DateTime?					Expires  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("PublicationId", 
					(data, value) => {(data as MessageClaim).PublicationId = value;}, 
					data => (data as MessageClaim).PublicationId ),
		new PropertyString ("ServiceAuthenticate", 
					(data, value) => {(data as MessageClaim).ServiceAuthenticate = value;}, 
					data => (data as MessageClaim).ServiceAuthenticate ),
		new PropertyString ("DeviceAuthenticate", 
					(data, value) => {(data as MessageClaim).DeviceAuthenticate = value;}, 
					data => (data as MessageClaim).DeviceAuthenticate ),
		new PropertyDateTime ("Expires", 
					(data, value) => {(data as MessageClaim).Expires = value;}, 
					data => (data as MessageClaim).Expires )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<MessageClaim> _binding = new (
			new() {
			{ "PublicationId", _properties [0]},
			{ "ServiceAuthenticate", _properties [1]},
			{ "DeviceAuthenticate", _properties [2]},
			{ "Expires", _properties [3]}}, __Tag,
		() => new MessageClaim(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// Report result of message processing.	
	/// </summary>
public partial class ProcessResult : Message {
    /// <summary>
    /// </summary>

	[JsonPropertyName("Success")]
	public virtual bool?					Success  {get; set;} //

    /// <summary>
    ///The error report code.
    /// </summary>

	[JsonPropertyName("ErrorReport")]
	public virtual string?					ErrorReport  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyBoolean ("Success", 
					(data, value) => {(data as ProcessResult).Success = value;}, 
					data => (data as ProcessResult).Success ),
		new PropertyString ("ErrorReport", 
					(data, value) => {(data as ProcessResult).ErrorReport = value;}, 
					data => (data as ProcessResult).ErrorReport )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResult> _binding = new (
			new() {
			{ "Success", _properties [0]},
			{ "ErrorReport", _properties [1]}}, __Tag,
		() => new ProcessResult(), () => [], () => [], Message._binding, Generic: false);


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

	}


	/// <summary>
	///
	/// The message type is not supported.
	/// </summary>
public partial class ProcessResultNotSupported : ProcessResult {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResultNotSupported> _binding = new (
			new() {}, __Tag,
		() => new ProcessResultNotSupported(), () => [], () => [], ProcessResult._binding, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ProcessResultNotFound : ProcessResult {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ProcessResultNotFound> _binding = new (
			new() {}, __Tag,
		() => new ProcessResultNotFound(), () => [], () => [], ProcessResult._binding, Generic: false);


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

	}



