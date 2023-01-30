
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
//  This file was automatically generated at 30-Jan-23 6:12:52 PM
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
	    {"ActivationApplicationCallsign", ActivationApplicationCallsign._Factory},
	    {"ApplicationEntry", ApplicationEntry._Factory},
	    {"ApplicationEntrySsh", ApplicationEntrySsh._Factory},
	    {"ApplicationEntryGroup", ApplicationEntryGroup._Factory},
	    {"ApplicationEntryMail", ApplicationEntryMail._Factory},
	    {"ApplicationEntryCallsign", ApplicationEntryCallsign._Factory},
	    {"Contact", Contact._Factory},
	    {"Anchor", Anchor._Factory},
	    {"TaggedSource", TaggedSource._Factory},
	    {"ContactGroup", ContactGroup._Factory},
	    {"ContactPerson", ContactPerson._Factory},
	    {"ContactOrganization", ContactOrganization._Factory},
	    {"OrganizationName", OrganizationName._Factory},
	    {"PersonName", PersonName._Factory},
	    {"NetworkAddress", NetworkAddress._Factory},
	    {"NetworkProtocol", NetworkProtocol._Factory},
	    {"Role", Role._Factory},
	    {"Location", Location._Factory},
	    {"Bookmark", Bookmark._Factory},
	    {"Reference", Reference._Factory},
	    {"Engagement", Engagement._Factory},
	    {"CatalogedEntry", CatalogedEntry._Factory},
	    {"CatalogedDevice", CatalogedDevice._Factory},
	    {"CatalogedPublication", CatalogedPublication._Factory},
	    {"CatalogedCredential", CatalogedCredential._Factory},
	    {"CatalogedApplicationSsh", CatalogedApplicationSsh._Factory},
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
	    {"CatalogedCallsign", CatalogedCallsign._Factory},
	    {"NamedService", NamedService._Factory},
	    {"ServiceAccessToken", ServiceAccessToken._Factory},
	    {"CatalogedBookmark", CatalogedBookmark._Factory},
	    {"CatalogedTask", CatalogedTask._Factory},
	    {"CatalogedApplication", CatalogedApplication._Factory},
	    {"CatalogedMember", CatalogedMember._Factory},
	    {"CatalogedGroup", CatalogedGroup._Factory},
	    {"CatalogedApplicationMail", CatalogedApplicationMail._Factory},
	    {"CatalogedApplicationNetwork", CatalogedApplicationNetwork._Factory},
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
	    {"RequestConfirmation", RequestConfirmation._Factory},
	    {"ResponseConfirmation", ResponseConfirmation._Factory},
	    {"RequestTask", RequestTask._Factory},
	    {"MessageClaim", MessageClaim._Factory},
	    {"ProcessResult", ProcessResult._Factory}
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

	public virtual string						Udf  {get; set;}
        /// <summary>
        ///List of X.509 Certificates
        /// </summary>

	public virtual byte[]						X509Certificate  {get; set;}
        /// <summary>
        ///X.509 Certificate chain.
        /// </summary>

	public virtual List<byte[]>				X509Chain  {get; set;}
        /// <summary>
        ///X.509 Certificate Signing Request.
        /// </summary>

	public virtual byte[]						X509CSR  {get; set;}
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

	public virtual Key						PublicParameters  {get; set;}
        /// <summary>
        ///The private key parameters as defined in the JOSE specification.
        /// </summary>

	public virtual Key						PrivateParameters  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Udf" : {
				if (value is TokenValueString vvalue) {
					Udf = vvalue.Value;
					}
				break;
				}
			case "X509Certificate" : {
				if (value is TokenValueBinary vvalue) {
					X509Certificate = vvalue.Value;
					}
				break;
				}
			case "X509Chain" : {
				if (value is TokenValueListBinary vvalue) {
					X509Chain = vvalue.Value;
					}
				break;
				}
			case "X509CSR" : {
				if (value is TokenValueBinary vvalue) {
					X509CSR = vvalue.Value;
					}
				break;
				}
			case "NotBefore" : {
				if (value is TokenValueDateTime vvalue) {
					NotBefore = vvalue.Value;
					}
				break;
				}
			case "NotOnOrAfter" : {
				if (value is TokenValueDateTime vvalue) {
					NotOnOrAfter = vvalue.Value;
					}
				break;
				}
			case "PublicParameters" : {
				if (value is TokenValueStructObject vvalue) {
					PublicParameters = vvalue.Value as Key;
					}
				break;
				}
			case "PrivateParameters" : {
				if (value is TokenValueStructObject vvalue) {
					PrivateParameters = vvalue.Value as Key;
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
			case "Udf" : {
				return new TokenValueString (Udf);
				}
			case "X509Certificate" : {
				return new TokenValueBinary (X509Certificate);
				}
			case "X509Chain" : {
				return new TokenValueListBinary (X509Chain);
				}
			case "X509CSR" : {
				return new TokenValueBinary (X509CSR);
				}
			case "NotBefore" : {
				return new TokenValueDateTime (NotBefore);
				}
			case "NotOnOrAfter" : {
				return new TokenValueDateTime (NotOnOrAfter);
				}
			case "PublicParameters" : {
				return new TokenValueStruct<Key> (PublicParameters);
				}
			case "PrivateParameters" : {
				return new TokenValueStruct<Key> (PrivateParameters);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new Property (typeof(TokenValueString), false)} ,
			{ "X509Certificate", new Property (typeof(TokenValueBinary), false)} ,
			{ "X509Chain", new Property (typeof(TokenValueListBinary), true)} ,
			{ "X509CSR", new Property (typeof(TokenValueBinary), false)} ,
			{ "NotBefore", new Property (typeof(TokenValueDateTime), false)} ,
			{ "NotOnOrAfter", new Property (typeof(TokenValueDateTime), false)} ,
			{ "PublicParameters", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "PrivateParameters", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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

	public virtual Key						PublicPrimary  {get; set;}
        /// <summary>
        ///The private key parameters of the share as defined in the JOSE specification.		
        /// </summary>

	public virtual Key						Share  {get; set;}
        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial key.]
        /// </summary>

	public virtual string						ServiceId  {get; set;}
        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial key.]	
        /// </summary>

	public virtual string						ServiceAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PublicPrimary" : {
				if (value is TokenValueStructObject vvalue) {
					PublicPrimary = vvalue.Value as Key;
					}
				break;
				}
			case "Share" : {
				if (value is TokenValueStructObject vvalue) {
					Share = vvalue.Value as Key;
					}
				break;
				}
			case "ServiceId" : {
				if (value is TokenValueString vvalue) {
					ServiceId = vvalue.Value;
					}
				break;
				}
			case "ServiceAddress" : {
				if (value is TokenValueString vvalue) {
					ServiceAddress = vvalue.Value;
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
			case "PublicPrimary" : {
				return new TokenValueStruct<Key> (PublicPrimary);
				}
			case "Share" : {
				return new TokenValueStruct<Key> (Share);
				}
			case "ServiceId" : {
				return new TokenValueString (ServiceId);
				}
			case "ServiceAddress" : {
				return new TokenValueString (ServiceAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicPrimary", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "Share", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "ServiceId", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceAddress", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						DeviceKeyUdf  {get; set;}
        /// <summary>
        ///Private parameters of additive key
        /// </summary>

	public virtual Key						PrivateSalt  {get; set;}
        /// <summary>
        ///Private parameters of serviced share
        /// </summary>

	public virtual Key						ServiceShare  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DeviceKeyUdf" : {
				if (value is TokenValueString vvalue) {
					DeviceKeyUdf = vvalue.Value;
					}
				break;
				}
			case "PrivateSalt" : {
				if (value is TokenValueStructObject vvalue) {
					PrivateSalt = vvalue.Value as Key;
					}
				break;
				}
			case "ServiceShare" : {
				if (value is TokenValueStructObject vvalue) {
					ServiceShare = vvalue.Value as Key;
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
			case "DeviceKeyUdf" : {
				return new TokenValueString (DeviceKeyUdf);
				}
			case "PrivateSalt" : {
				return new TokenValueStruct<Key> (PrivateSalt);
				}
			case "ServiceShare" : {
				return new TokenValueStruct<Key> (ServiceShare);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DeviceKeyUdf", new Property (typeof(TokenValueString), false)} ,
			{ "PrivateSalt", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "ServiceShare", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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

	public virtual List<string>				Names  {get; set;}
        /// <summary>
        ///The time instant the profile was last modified.
        /// </summary>

	public virtual DateTime?						Updated  {get; set;}
        /// <summary>
        ///A Uniform Notary Token providing evidence that a signature
        ///was performed after the notary token was created.
        /// </summary>

	public virtual string						NotaryToken  {get; set;}
        /// <summary>
        ///Conditional clause(s) that MAY be verified to evaluate the validity of the
        ///assertion. At present no condition classes are specified.
        /// </summary>

	public virtual Condition						Conditions  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Names" : {
				if (value is TokenValueListString vvalue) {
					Names = vvalue.Value;
					}
				break;
				}
			case "Updated" : {
				if (value is TokenValueDateTime vvalue) {
					Updated = vvalue.Value;
					}
				break;
				}
			case "NotaryToken" : {
				if (value is TokenValueString vvalue) {
					NotaryToken = vvalue.Value;
					}
				break;
				}
			case "Conditions" : {
				if (value is TokenValueStructObject vvalue) {
					Conditions = vvalue.Value as Condition;
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
			case "Names" : {
				return new TokenValueListString (Names);
				}
			case "Updated" : {
				return new TokenValueDateTime (Updated);
				}
			case "NotaryToken" : {
				return new TokenValueString (NotaryToken);
				}
			case "Conditions" : {
				return new TokenValueStruct<Condition> (Conditions);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Names", new Property (typeof(TokenValueListString), true)} ,
			{ "Updated", new Property (typeof(TokenValueDateTime), false)} ,
			{ "NotaryToken", new Property (typeof(TokenValueString), false)} ,
			{ "Conditions", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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

	public virtual string						ActivationKey  {get; set;}
        /// <summary>
        ///Activation of named account resource activations. These are separate from
        ///Application activations which are 
        /// </summary>

	public virtual List<ActivationEntry>				Entries  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ActivationKey" : {
				if (value is TokenValueString vvalue) {
					ActivationKey = vvalue.Value;
					}
				break;
				}
			case "Entries" : {
				if (value is TokenValueListStructObject vvalue) {
					Entries = vvalue.Value as List<ActivationEntry>;
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
			case "ActivationKey" : {
				return new TokenValueString (ActivationKey);
				}
			case "Entries" : {
				return new TokenValueListStruct<ActivationEntry> (Entries);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ActivationKey", new Property (typeof(TokenValueString), false)} ,
			{ "Entries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ActivationEntry>(), ()=>new ActivationEntry(), false)} 
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

	public virtual string						Resource  {get; set;}
        /// <summary>
        ///The activation key or key share
        /// </summary>

	public virtual KeyData						Key  {get; set;}
        /// <summary>
        ///The identifier used to claim the capability from the service.[Only present for
        ///a partial capability.]
        /// </summary>

	public virtual string						ServiceId  {get; set;}
        /// <summary>
        ///The service account that supports a serviced capability. [Only present for
        ///a partial capability.]
        /// </summary>

	public virtual string						ServiceAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Resource" : {
				if (value is TokenValueString vvalue) {
					Resource = vvalue.Value;
					}
				break;
				}
			case "Key" : {
				if (value is TokenValueStructObject vvalue) {
					Key = vvalue.Value as KeyData;
					}
				break;
				}
			case "ServiceId" : {
				if (value is TokenValueString vvalue) {
					ServiceId = vvalue.Value;
					}
				break;
				}
			case "ServiceAddress" : {
				if (value is TokenValueString vvalue) {
					ServiceAddress = vvalue.Value;
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
			case "Resource" : {
				return new TokenValueString (Resource);
				}
			case "Key" : {
				return new TokenValueStruct<KeyData> (Key);
				}
			case "ServiceId" : {
				return new TokenValueString (ServiceId);
				}
			case "ServiceAddress" : {
				return new TokenValueString (ServiceAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Resource", new Property (typeof(TokenValueString), false)} ,
			{ "Key", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "ServiceId", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceAddress", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Description  {get; set;}
        /// <summary>
        ///The permanent signature key used to sign the profile itself. The UDF of
        ///the key is used as the permanent object identifier of the profile. Thus,
        ///by definition, the KeySignature value of a Profile does not change under
        ///any circumstance.
        /// </summary>

	public virtual KeyData						ProfileSignature  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Description" : {
				if (value is TokenValueString vvalue) {
					Description = vvalue.Value;
					}
				break;
				}
			case "ProfileSignature" : {
				if (value is TokenValueStructObject vvalue) {
					ProfileSignature = vvalue.Value as KeyData;
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
			case "Description" : {
				return new TokenValueString (Description);
				}
			case "ProfileSignature" : {
				return new TokenValueStruct<KeyData> (ProfileSignature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Description", new Property (typeof(TokenValueString), false)} ,
			{ "ProfileSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual KeyData						Encryption  {get; set;}
        /// <summary>
        ///Base key contribution for signature keys. 
        /// </summary>

	public virtual KeyData						Signature  {get; set;}
        /// <summary>
        ///Base key contribution for authentication keys. 
        ///Also used to authenticate the device
        ///during connection to an account.
        /// </summary>

	public virtual KeyData						Authentication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Encryption" : {
				if (value is TokenValueStructObject vvalue) {
					Encryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "Signature" : {
				if (value is TokenValueStructObject vvalue) {
					Signature = vvalue.Value as KeyData;
					}
				break;
				}
			case "Authentication" : {
				if (value is TokenValueStructObject vvalue) {
					Authentication = vvalue.Value as KeyData;
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
			case "Encryption" : {
				return new TokenValueStruct<KeyData> (Encryption);
				}
			case "Signature" : {
				return new TokenValueStruct<KeyData> (Signature);
				}
			case "Authentication" : {
				return new TokenValueStruct<KeyData> (Authentication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Encryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Signature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Authentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///The fingerprint of the service profile to which the account is
        ///currently bound.
        /// </summary>

	public virtual string						ServiceUdf  {get; set;}
        /// <summary>
        ///Escrow key associated with the account.
        /// </summary>

	public virtual KeyData						EscrowEncryption  {get; set;}
        /// <summary>
        ///Key used to sign connection assertions to the account.
        /// </summary>

	public virtual KeyData						AdministratorSignature  {get; set;}
        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

	public virtual KeyData						CommonEncryption  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made under this user account.
        ///This key SHOULD NOT be provisioned to any device except for the
        ///purpose of enabling account recovery.
        /// </summary>

	public virtual KeyData						CommonAuthentication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "ServiceUdf" : {
				if (value is TokenValueString vvalue) {
					ServiceUdf = vvalue.Value;
					}
				break;
				}
			case "EscrowEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					EscrowEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "AdministratorSignature" : {
				if (value is TokenValueStructObject vvalue) {
					AdministratorSignature = vvalue.Value as KeyData;
					}
				break;
				}
			case "CommonEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					CommonEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "CommonAuthentication" : {
				if (value is TokenValueStructObject vvalue) {
					CommonAuthentication = vvalue.Value as KeyData;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "ServiceUdf" : {
				return new TokenValueString (ServiceUdf);
				}
			case "EscrowEncryption" : {
				return new TokenValueStruct<KeyData> (EscrowEncryption);
				}
			case "AdministratorSignature" : {
				return new TokenValueStruct<KeyData> (AdministratorSignature);
				}
			case "CommonEncryption" : {
				return new TokenValueStruct<KeyData> (CommonEncryption);
				}
			case "CommonAuthentication" : {
				return new TokenValueStruct<KeyData> (CommonAuthentication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceUdf", new Property (typeof(TokenValueString), false)} ,
			{ "EscrowEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "AdministratorSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "CommonEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "CommonAuthentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual KeyData						CommonSignature  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CommonSignature" : {
				if (value is TokenValueStructObject vvalue) {
					CommonSignature = vvalue.Value as KeyData;
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
			case "CommonSignature" : {
				return new TokenValueStruct<KeyData> (CommonSignature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual byte[]						Cover  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Cover" : {
				if (value is TokenValueBinary vvalue) {
					Cover = vvalue.Value;
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
			case "Cover" : {
				return new TokenValueBinary (Cover);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Cover", new Property (typeof(TokenValueBinary), false)} 
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

	public virtual KeyData						ServiceAuthentication  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

	public virtual KeyData						ServiceEncryption  {get; set;}
        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

	public virtual KeyData						ServiceSignature  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ServiceAuthentication" : {
				if (value is TokenValueStructObject vvalue) {
					ServiceAuthentication = vvalue.Value as KeyData;
					}
				break;
				}
			case "ServiceEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					ServiceEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "ServiceSignature" : {
				if (value is TokenValueStructObject vvalue) {
					ServiceSignature = vvalue.Value as KeyData;
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
			case "ServiceAuthentication" : {
				return new TokenValueStruct<KeyData> (ServiceAuthentication);
				}
			case "ServiceEncryption" : {
				return new TokenValueStruct<KeyData> (ServiceEncryption);
				}
			case "ServiceSignature" : {
				return new TokenValueStruct<KeyData> (ServiceSignature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ServiceAuthentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "ServiceEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "ServiceSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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
	/// Profile of a Mesh Host providing one or more Mesh Services.
	/// </summary>
public partial class ProfileHost : ProfileDevice {


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

	public virtual string						Subject  {get; set;}
        /// <summary>
        ///UDF of the connection source.
        /// </summary>

	public virtual string						Authority  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

	public virtual KeyData						Authentication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Subject" : {
				if (value is TokenValueString vvalue) {
					Subject = vvalue.Value;
					}
				break;
				}
			case "Authority" : {
				if (value is TokenValueString vvalue) {
					Authority = vvalue.Value;
					}
				break;
				}
			case "Authentication" : {
				if (value is TokenValueStructObject vvalue) {
					Authentication = vvalue.Value as KeyData;
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
			case "Subject" : {
				return new TokenValueString (Subject);
				}
			case "Authority" : {
				return new TokenValueString (Authority);
				}
			case "Authentication" : {
				return new TokenValueStruct<KeyData> (Authentication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Subject", new Property (typeof(TokenValueString), false)} ,
			{ "Authority", new Property (typeof(TokenValueString), false)} ,
			{ "Authentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual string						Canonical  {get; set;}
        /// <summary>
        ///The display form of the callsign. This MAY include characters such as whitespace,
        ///trademark signifiers, etc. that are omitted of trranslated in the canonical form.
        /// </summary>

	public virtual string						Display  {get; set;}
        /// <summary>
        ///The profile to which the name is bound.
        /// </summary>

	public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///List of named services. If multiple service providers are specified for a given 
        ///service, these are listed in order of priority, most preferred first.
        /// </summary>

	public virtual List<NamedService>				Services  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Canonical" : {
				if (value is TokenValueString vvalue) {
					Canonical = vvalue.Value;
					}
				break;
				}
			case "Display" : {
				if (value is TokenValueString vvalue) {
					Display = vvalue.Value;
					}
				break;
				}
			case "ProfileUdf" : {
				if (value is TokenValueString vvalue) {
					ProfileUdf = vvalue.Value;
					}
				break;
				}
			case "Services" : {
				if (value is TokenValueListStructObject vvalue) {
					Services = vvalue.Value as List<NamedService>;
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
			case "Canonical" : {
				return new TokenValueString (Canonical);
				}
			case "Display" : {
				return new TokenValueString (Display);
				}
			case "ProfileUdf" : {
				return new TokenValueString (ProfileUdf);
				}
			case "Services" : {
				return new TokenValueListStruct<NamedService> (Services);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Canonical", new Property (typeof(TokenValueString), false)} ,
			{ "Display", new Property (typeof(TokenValueString), false)} ,
			{ "ProfileUdf", new Property (typeof(TokenValueString), false)} ,
			{ "Services", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<NamedService>(), ()=>new NamedService(), false)} 
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

	public virtual string						Callsign  {get; set;}
        /// <summary>
        ///The profile to which the accreditation applies.
        /// </summary>

	public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///The validated names of the subject
        /// </summary>

	public virtual List<string>				SubjectNames  {get; set;}
        /// <summary>
        ///Mesh strong URIs from which a validated logo belonging to the 
        ///subject MAY be retreived and validated.
        /// </summary>

	public virtual List<string>				SubjectLogos  {get; set;}
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

	public virtual string						Policy  {get; set;}
        /// <summary>
        ///The issuing practices under which the validation was performed.
        /// </summary>

	public virtual string						Practice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Callsign" : {
				if (value is TokenValueString vvalue) {
					Callsign = vvalue.Value;
					}
				break;
				}
			case "ProfileUdf" : {
				if (value is TokenValueString vvalue) {
					ProfileUdf = vvalue.Value;
					}
				break;
				}
			case "SubjectNames" : {
				if (value is TokenValueListString vvalue) {
					SubjectNames = vvalue.Value;
					}
				break;
				}
			case "SubjectLogos" : {
				if (value is TokenValueListString vvalue) {
					SubjectLogos = vvalue.Value;
					}
				break;
				}
			case "Issued" : {
				if (value is TokenValueDateTime vvalue) {
					Issued = vvalue.Value;
					}
				break;
				}
			case "Expires" : {
				if (value is TokenValueDateTime vvalue) {
					Expires = vvalue.Value;
					}
				break;
				}
			case "Policy" : {
				if (value is TokenValueString vvalue) {
					Policy = vvalue.Value;
					}
				break;
				}
			case "Practice" : {
				if (value is TokenValueString vvalue) {
					Practice = vvalue.Value;
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
			case "Callsign" : {
				return new TokenValueString (Callsign);
				}
			case "ProfileUdf" : {
				return new TokenValueString (ProfileUdf);
				}
			case "SubjectNames" : {
				return new TokenValueListString (SubjectNames);
				}
			case "SubjectLogos" : {
				return new TokenValueListString (SubjectLogos);
				}
			case "Issued" : {
				return new TokenValueDateTime (Issued);
				}
			case "Expires" : {
				return new TokenValueDateTime (Expires);
				}
			case "Policy" : {
				return new TokenValueString (Policy);
				}
			case "Practice" : {
				return new TokenValueString (Practice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Callsign", new Property (typeof(TokenValueString), false)} ,
			{ "ProfileUdf", new Property (typeof(TokenValueString), false)} ,
			{ "SubjectNames", new Property (typeof(TokenValueListString), true)} ,
			{ "SubjectLogos", new Property (typeof(TokenValueListString), true)} ,
			{ "Issued", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Expires", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Policy", new Property (typeof(TokenValueString), false)} ,
			{ "Practice", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Account  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Account" : {
				if (value is TokenValueString vvalue) {
					Account = vvalue.Value;
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
			case "Account" : {
				return new TokenValueString (Account);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///The account callsign
        /// </summary>

	public virtual CatalogedCallsign						Callsign  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ProfileUdf" : {
				if (value is TokenValueString vvalue) {
					ProfileUdf = vvalue.Value;
					}
				break;
				}
			case "Callsign" : {
				if (value is TokenValueStructObject vvalue) {
					Callsign = vvalue.Value as CatalogedCallsign;
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
			case "ProfileUdf" : {
				return new TokenValueString (ProfileUdf);
				}
			case "Callsign" : {
				return new TokenValueStruct<CatalogedCallsign> (Callsign);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileUdf", new Property (typeof(TokenValueString), false)} ,
			{ "Callsign", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedCallsign(), ()=>new CatalogedCallsign(), false)} 
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

	public virtual List<string>				Roles  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

	public virtual KeyData						Signature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

	public virtual KeyData						Encryption  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Roles" : {
				if (value is TokenValueListString vvalue) {
					Roles = vvalue.Value;
					}
				break;
				}
			case "Signature" : {
				if (value is TokenValueStructObject vvalue) {
					Signature = vvalue.Value as KeyData;
					}
				break;
				}
			case "Encryption" : {
				if (value is TokenValueStructObject vvalue) {
					Encryption = vvalue.Value as KeyData;
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
			case "Roles" : {
				return new TokenValueListString (Roles);
				}
			case "Signature" : {
				return new TokenValueStruct<KeyData> (Signature);
				}
			case "Encryption" : {
				return new TokenValueStruct<KeyData> (Encryption);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Roles", new Property (typeof(TokenValueListString), true)} ,
			{ "Signature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Encryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual string						AccountAddess  {get; set;}
        /// <summary>
        ///Host address in Callsign, DNS or IP format in order of preference.
        /// </summary>

	public virtual List<string>				HostAddresses  {get; set;}
        /// <summary>
        ///Encryption key to be used to encrypt data for the service to use.
        /// </summary>

	public virtual KeyData						AccessEncrypt  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddess" : {
				if (value is TokenValueString vvalue) {
					AccountAddess = vvalue.Value;
					}
				break;
				}
			case "HostAddresses" : {
				if (value is TokenValueListString vvalue) {
					HostAddresses = vvalue.Value;
					}
				break;
				}
			case "AccessEncrypt" : {
				if (value is TokenValueStructObject vvalue) {
					AccessEncrypt = vvalue.Value as KeyData;
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
			case "AccountAddess" : {
				return new TokenValueString (AccountAddess);
				}
			case "HostAddresses" : {
				return new TokenValueListString (HostAddresses);
				}
			case "AccessEncrypt" : {
				return new TokenValueStruct<KeyData> (AccessEncrypt);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddess", new Property (typeof(TokenValueString), false)} ,
			{ "HostAddresses", new Property (typeof(TokenValueListString), true)} ,
			{ "AccessEncrypt", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual string						AccountUdf  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountUdf" : {
				if (value is TokenValueString vvalue) {
					AccountUdf = vvalue.Value;
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
			case "AccountUdf" : {
				return new TokenValueString (AccountUdf);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountUdf", new Property (typeof(TokenValueString), false)} 
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

	public virtual KeyData						ProfileSignature  {get; set;}
        /// <summary>
        ///Grant access to Profile administration key used to make changes to
        ///administrator catalogs.
        /// </summary>

	public virtual KeyData						AdministratorSignature  {get; set;}
        /// <summary>
        ///Grant access to ProfileUser account encryption key
        /// </summary>

	public virtual KeyData						Encryption  {get; set;}
        /// <summary>
        ///Grant access to ProfileUser account authentication key
        /// </summary>

	public virtual KeyData						Authentication  {get; set;}
        /// <summary>
        ///Grant access to ProfileUser account signature key
        /// </summary>

	public virtual KeyData						Signature  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ProfileSignature" : {
				if (value is TokenValueStructObject vvalue) {
					ProfileSignature = vvalue.Value as KeyData;
					}
				break;
				}
			case "AdministratorSignature" : {
				if (value is TokenValueStructObject vvalue) {
					AdministratorSignature = vvalue.Value as KeyData;
					}
				break;
				}
			case "Encryption" : {
				if (value is TokenValueStructObject vvalue) {
					Encryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "Authentication" : {
				if (value is TokenValueStructObject vvalue) {
					Authentication = vvalue.Value as KeyData;
					}
				break;
				}
			case "Signature" : {
				if (value is TokenValueStructObject vvalue) {
					Signature = vvalue.Value as KeyData;
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
			case "ProfileSignature" : {
				return new TokenValueStruct<KeyData> (ProfileSignature);
				}
			case "AdministratorSignature" : {
				return new TokenValueStruct<KeyData> (AdministratorSignature);
				}
			case "Encryption" : {
				return new TokenValueStruct<KeyData> (Encryption);
				}
			case "Authentication" : {
				return new TokenValueStruct<KeyData> (Authentication);
				}
			case "Signature" : {
				return new TokenValueStruct<KeyData> (Signature);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ProfileSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "AdministratorSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Encryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Authentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "Signature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual KeyData						ClientKey  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ClientKey" : {
				if (value is TokenValueStructObject vvalue) {
					ClientKey = vvalue.Value as KeyData;
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
			case "ClientKey" : {
				return new TokenValueStruct<KeyData> (ClientKey);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ClientKey", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual KeyData						SmimeSign  {get; set;}
        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData						SmimeEncrypt  {get; set;}
        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	public virtual KeyData						OpenpgpSign  {get; set;}
        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	public virtual KeyData						OpenpgpEncrypt  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "SmimeSign" : {
				if (value is TokenValueStructObject vvalue) {
					SmimeSign = vvalue.Value as KeyData;
					}
				break;
				}
			case "SmimeEncrypt" : {
				if (value is TokenValueStructObject vvalue) {
					SmimeEncrypt = vvalue.Value as KeyData;
					}
				break;
				}
			case "OpenpgpSign" : {
				if (value is TokenValueStructObject vvalue) {
					OpenpgpSign = vvalue.Value as KeyData;
					}
				break;
				}
			case "OpenpgpEncrypt" : {
				if (value is TokenValueStructObject vvalue) {
					OpenpgpEncrypt = vvalue.Value as KeyData;
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
			case "SmimeSign" : {
				return new TokenValueStruct<KeyData> (SmimeSign);
				}
			case "SmimeEncrypt" : {
				return new TokenValueStruct<KeyData> (SmimeEncrypt);
				}
			case "OpenpgpSign" : {
				return new TokenValueStruct<KeyData> (OpenpgpSign);
				}
			case "OpenpgpEncrypt" : {
				return new TokenValueStruct<KeyData> (OpenpgpEncrypt);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "SmimeSign", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "SmimeEncrypt", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "OpenpgpSign", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "OpenpgpEncrypt", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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

	public virtual KeyData						AccountEncryption  {get; set;}
        /// <summary>
        ///Key or capability allowing account updates, connection assertions
        ///etc to be signed.
        /// </summary>

	public virtual KeyData						AdministratorSignature  {get; set;}
        /// <summary>
        ///Key or capability allowing administration of the group.
        /// </summary>

	public virtual KeyData						AccountAuthentication  {get; set;}
        /// <summary>
        ///Signed connection service delegation allowing the device to
        ///access the account.
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountEncryption" : {
				if (value is TokenValueStructObject vvalue) {
					AccountEncryption = vvalue.Value as KeyData;
					}
				break;
				}
			case "AdministratorSignature" : {
				if (value is TokenValueStructObject vvalue) {
					AdministratorSignature = vvalue.Value as KeyData;
					}
				break;
				}
			case "AccountAuthentication" : {
				if (value is TokenValueStructObject vvalue) {
					AccountAuthentication = vvalue.Value as KeyData;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
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
			case "AccountEncryption" : {
				return new TokenValueStruct<KeyData> (AccountEncryption);
				}
			case "AdministratorSignature" : {
				return new TokenValueStruct<KeyData> (AdministratorSignature);
				}
			case "AccountAuthentication" : {
				return new TokenValueStruct<KeyData> (AccountAuthentication);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountEncryption", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "AdministratorSignature", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "AccountAuthentication", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} 
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
public partial class ActivationApplicationCallsign : ActivationApplication {


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
	public new const string __Tag = "ActivationApplicationCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ActivationApplicationCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ActivationApplicationCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ActivationApplicationCallsign;
			}
		var Result = new ActivationApplicationCallsign ();
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

	public virtual string						Identifier  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Identifier" : {
				if (value is TokenValueString vvalue) {
					Identifier = vvalue.Value;
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
			case "Identifier" : {
				return new TokenValueString (Identifier);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Identifier", new Property (typeof(TokenValueString), false)} 
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

	public virtual Enveloped<ActivationApplicationSsh>						EnvelopedActivation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedActivation" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivation = vvalue.Value as Enveloped<ActivationApplicationSsh>;
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
			case "EnvelopedActivation" : {
				return new TokenValueStruct<Enveloped<ActivationApplicationSsh>> (EnvelopedActivation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationApplicationSsh>(), ()=>new Enveloped<ActivationApplicationSsh>(), false)} 
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

	public virtual Enveloped<ActivationApplicationGroup>						EnvelopedActivation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedActivation" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivation = vvalue.Value as Enveloped<ActivationApplicationGroup>;
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
			case "EnvelopedActivation" : {
				return new TokenValueStruct<Enveloped<ActivationApplicationGroup>> (EnvelopedActivation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationApplicationGroup>(), ()=>new Enveloped<ActivationApplicationGroup>(), false)} 
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

	public virtual Enveloped<ActivationApplicationMail>						EnvelopedActivation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedActivation" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivation = vvalue.Value as Enveloped<ActivationApplicationMail>;
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
			case "EnvelopedActivation" : {
				return new TokenValueStruct<Enveloped<ActivationApplicationMail>> (EnvelopedActivation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationApplicationMail>(), ()=>new Enveloped<ActivationApplicationMail>(), false)} 
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
	/// </summary>
public partial class ApplicationEntryCallsign : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationCallsign>						EnvelopedActivation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedActivation" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivation = vvalue.Value as Enveloped<ActivationApplicationCallsign>;
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
			case "EnvelopedActivation" : {
				return new TokenValueStruct<Enveloped<ActivationApplicationCallsign>> (EnvelopedActivation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedActivation", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationApplicationCallsign>(), ()=>new Enveloped<ActivationApplicationCallsign>(), false)} 
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
	public new const string __Tag = "ApplicationEntryCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ApplicationEntryCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ApplicationEntryCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ApplicationEntryCallsign;
			}
		var Result = new ApplicationEntryCallsign ();
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

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The local name.
        /// </summary>

	public virtual string						Local  {get; set;}
        /// <summary>
        ///Mesh fingerprints associated with the contact.
        /// </summary>

	public virtual List<Anchor>				Anchors  {get; set;}
        /// <summary>
        ///Network address entries
        /// </summary>

	public virtual List<NetworkAddress>				NetworkAddresses  {get; set;}
        /// <summary>
        ///The physical locations the contact is associated with.
        /// </summary>

	public virtual List<Location>				Locations  {get; set;}
        /// <summary>
        ///The roles of the contact
        /// </summary>

	public virtual List<Role>				Roles  {get; set;}
        /// <summary>
        ///The Web sites and other online presences of the contact
        /// </summary>

	public virtual List<Bookmark>				Bookmark  {get; set;}
        /// <summary>
        ///Source(s) from which this contact was constructed.
        /// </summary>

	public virtual List<TaggedSource>				Sources  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Local" : {
				if (value is TokenValueString vvalue) {
					Local = vvalue.Value;
					}
				break;
				}
			case "Anchors" : {
				if (value is TokenValueListStructObject vvalue) {
					Anchors = vvalue.Value as List<Anchor>;
					}
				break;
				}
			case "NetworkAddresses" : {
				if (value is TokenValueListStructObject vvalue) {
					NetworkAddresses = vvalue.Value as List<NetworkAddress>;
					}
				break;
				}
			case "Locations" : {
				if (value is TokenValueListStructObject vvalue) {
					Locations = vvalue.Value as List<Location>;
					}
				break;
				}
			case "Roles" : {
				if (value is TokenValueListStructObject vvalue) {
					Roles = vvalue.Value as List<Role>;
					}
				break;
				}
			case "Bookmark" : {
				if (value is TokenValueListStructObject vvalue) {
					Bookmark = vvalue.Value as List<Bookmark>;
					}
				break;
				}
			case "Sources" : {
				if (value is TokenValueListStructObject vvalue) {
					Sources = vvalue.Value as List<TaggedSource>;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Local" : {
				return new TokenValueString (Local);
				}
			case "Anchors" : {
				return new TokenValueListStruct<Anchor> (Anchors);
				}
			case "NetworkAddresses" : {
				return new TokenValueListStruct<NetworkAddress> (NetworkAddresses);
				}
			case "Locations" : {
				return new TokenValueListStruct<Location> (Locations);
				}
			case "Roles" : {
				return new TokenValueListStruct<Role> (Roles);
				}
			case "Bookmark" : {
				return new TokenValueListStruct<Bookmark> (Bookmark);
				}
			case "Sources" : {
				return new TokenValueListStruct<TaggedSource> (Sources);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Local", new Property (typeof(TokenValueString), false)} ,
			{ "Anchors", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Anchor>(), ()=>new Anchor(), false)} ,
			{ "NetworkAddresses", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<NetworkAddress>(), ()=>new NetworkAddress(), false)} ,
			{ "Locations", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Location>(), ()=>new Location(), false)} ,
			{ "Roles", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Role>(), ()=>new Role(), false)} ,
			{ "Bookmark", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Bookmark>(), ()=>new Bookmark(), false)} ,
			{ "Sources", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<TaggedSource>(), ()=>new TaggedSource(), false)} 
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

	public virtual string						Udf  {get; set;}
        /// <summary>
        ///The means of validation.
        /// </summary>

	public virtual string						Validation  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Udf" : {
				if (value is TokenValueString vvalue) {
					Udf = vvalue.Value;
					}
				break;
				}
			case "Validation" : {
				if (value is TokenValueString vvalue) {
					Validation = vvalue.Value;
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
			case "Udf" : {
				return new TokenValueString (Udf);
				}
			case "Validation" : {
				return new TokenValueString (Validation);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Udf", new Property (typeof(TokenValueString), false)} ,
			{ "Validation", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						LocalName  {get; set;}
        /// <summary>
        ///The means of validation.		
        /// </summary>

	public virtual string						Validation  {get; set;}
        /// <summary>
        ///The contact data in binary form.
        /// </summary>

	public virtual byte[]						BinarySource  {get; set;}
        /// <summary>
        ///The contact data in enveloped form. If present, the BinarySource property
        ///is ignored.
        /// </summary>

	public virtual Enveloped<Contact>						EnvelopedSource  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "LocalName" : {
				if (value is TokenValueString vvalue) {
					LocalName = vvalue.Value;
					}
				break;
				}
			case "Validation" : {
				if (value is TokenValueString vvalue) {
					Validation = vvalue.Value;
					}
				break;
				}
			case "BinarySource" : {
				if (value is TokenValueBinary vvalue) {
					BinarySource = vvalue.Value;
					}
				break;
				}
			case "EnvelopedSource" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedSource = vvalue.Value as Enveloped<Contact>;
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
			case "LocalName" : {
				return new TokenValueString (LocalName);
				}
			case "Validation" : {
				return new TokenValueString (Validation);
				}
			case "BinarySource" : {
				return new TokenValueBinary (BinarySource);
				}
			case "EnvelopedSource" : {
				return new TokenValueStruct<Enveloped<Contact>> (EnvelopedSource);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "LocalName", new Property (typeof(TokenValueString), false)} ,
			{ "Validation", new Property (typeof(TokenValueString), false)} ,
			{ "BinarySource", new Property (typeof(TokenValueBinary), false)} ,
			{ "EnvelopedSource", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Contact>(), ()=>new Enveloped<Contact>(), false)} 
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

	public virtual List<PersonName>				CommonNames  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CommonNames" : {
				if (value is TokenValueListStructObject vvalue) {
					CommonNames = vvalue.Value as List<PersonName>;
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
			case "CommonNames" : {
				return new TokenValueListStruct<PersonName> (CommonNames);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonNames", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<PersonName>(), ()=>new PersonName(), false)} 
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

	public virtual List<OrganizationName>				CommonNames  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "CommonNames" : {
				if (value is TokenValueListStructObject vvalue) {
					CommonNames = vvalue.Value as List<OrganizationName>;
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
			case "CommonNames" : {
				return new TokenValueListStruct<OrganizationName> (CommonNames);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "CommonNames", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<OrganizationName>(), ()=>new OrganizationName(), false)} 
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

	public virtual string						RegisteredName  {get; set;}
        /// <summary>
        ///Names that the organization uses including trading names
        ///and doing business as names.
        /// </summary>

	public virtual string						DBA  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Inactive" : {
				if (value is TokenValueBoolean vvalue) {
					Inactive = vvalue.Value;
					}
				break;
				}
			case "RegisteredName" : {
				if (value is TokenValueString vvalue) {
					RegisteredName = vvalue.Value;
					}
				break;
				}
			case "DBA" : {
				if (value is TokenValueString vvalue) {
					DBA = vvalue.Value;
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
			case "Inactive" : {
				return new TokenValueBoolean (Inactive);
				}
			case "RegisteredName" : {
				return new TokenValueString (RegisteredName);
				}
			case "DBA" : {
				return new TokenValueString (DBA);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new Property (typeof(TokenValueBoolean), false)} ,
			{ "RegisteredName", new Property (typeof(TokenValueString), false)} ,
			{ "DBA", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						FullName  {get; set;}
        /// <summary>
        ///Honorific or title, E.g. Sir, Lord, Dr., Mr.
        /// </summary>

	public virtual string						Prefix  {get; set;}
        /// <summary>
        ///First name.
        /// </summary>

	public virtual string						First  {get; set;}
        /// <summary>
        ///Middle names or initials.
        /// </summary>

	public virtual List<string>				Middle  {get; set;}
        /// <summary>
        ///Last name.
        /// </summary>

	public virtual string						Last  {get; set;}
        /// <summary>
        ///Nominal suffix, e.g. Jr., III, etc.
        /// </summary>

	public virtual string						Suffix  {get; set;}
        /// <summary>
        ///Post nominal letters (if used).
        /// </summary>

	public virtual string						PostNominal  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Inactive" : {
				if (value is TokenValueBoolean vvalue) {
					Inactive = vvalue.Value;
					}
				break;
				}
			case "FullName" : {
				if (value is TokenValueString vvalue) {
					FullName = vvalue.Value;
					}
				break;
				}
			case "Prefix" : {
				if (value is TokenValueString vvalue) {
					Prefix = vvalue.Value;
					}
				break;
				}
			case "First" : {
				if (value is TokenValueString vvalue) {
					First = vvalue.Value;
					}
				break;
				}
			case "Middle" : {
				if (value is TokenValueListString vvalue) {
					Middle = vvalue.Value;
					}
				break;
				}
			case "Last" : {
				if (value is TokenValueString vvalue) {
					Last = vvalue.Value;
					}
				break;
				}
			case "Suffix" : {
				if (value is TokenValueString vvalue) {
					Suffix = vvalue.Value;
					}
				break;
				}
			case "PostNominal" : {
				if (value is TokenValueString vvalue) {
					PostNominal = vvalue.Value;
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
			case "Inactive" : {
				return new TokenValueBoolean (Inactive);
				}
			case "FullName" : {
				return new TokenValueString (FullName);
				}
			case "Prefix" : {
				return new TokenValueString (Prefix);
				}
			case "First" : {
				return new TokenValueString (First);
				}
			case "Middle" : {
				return new TokenValueListString (Middle);
				}
			case "Last" : {
				return new TokenValueString (Last);
				}
			case "Suffix" : {
				return new TokenValueString (Suffix);
				}
			case "PostNominal" : {
				return new TokenValueString (PostNominal);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new Property (typeof(TokenValueBoolean), false)} ,
			{ "FullName", new Property (typeof(TokenValueString), false)} ,
			{ "Prefix", new Property (typeof(TokenValueString), false)} ,
			{ "First", new Property (typeof(TokenValueString), false)} ,
			{ "Middle", new Property (typeof(TokenValueListString), true)} ,
			{ "Last", new Property (typeof(TokenValueString), false)} ,
			{ "Suffix", new Property (typeof(TokenValueString), false)} ,
			{ "PostNominal", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Address  {get; set;}
        /// <summary>
        ///The capabilities bound to this address.
        /// </summary>

	public virtual List<string>				NetworkCapability  {get; set;}
        /// <summary>
        ///The account profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///Public keys associated with the network address
        /// </summary>

	public virtual List<NetworkProtocol>				Protocols  {get; set;}
        /// <summary>
        ///Cryptographic capabilities that may be claimed from this address
        /// </summary>

	public virtual List<CryptographicCapability>				Capabilities  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Inactive" : {
				if (value is TokenValueBoolean vvalue) {
					Inactive = vvalue.Value;
					}
				break;
				}
			case "Address" : {
				if (value is TokenValueString vvalue) {
					Address = vvalue.Value;
					}
				break;
				}
			case "NetworkCapability" : {
				if (value is TokenValueListString vvalue) {
					NetworkCapability = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileAccount = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "Protocols" : {
				if (value is TokenValueListStructObject vvalue) {
					Protocols = vvalue.Value as List<NetworkProtocol>;
					}
				break;
				}
			case "Capabilities" : {
				if (value is TokenValueListStructObject vvalue) {
					Capabilities = vvalue.Value as List<CryptographicCapability>;
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
			case "Inactive" : {
				return new TokenValueBoolean (Inactive);
				}
			case "Address" : {
				return new TokenValueString (Address);
				}
			case "NetworkCapability" : {
				return new TokenValueListString (NetworkCapability);
				}
			case "EnvelopedProfileAccount" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileAccount);
				}
			case "Protocols" : {
				return new TokenValueListStruct<NetworkProtocol> (Protocols);
				}
			case "Capabilities" : {
				return new TokenValueListStruct<CryptographicCapability> (Capabilities);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Inactive", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Address", new Property (typeof(TokenValueString), false)} ,
			{ "NetworkCapability", new Property (typeof(TokenValueListString), true)} ,
			{ "EnvelopedProfileAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "Protocols", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<NetworkProtocol>(), ()=>new NetworkProtocol(), false)} ,
			{ "Capabilities", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CryptographicCapability>(), null, true)} 
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
public partial class NetworkProtocol : MeshItem {
        /// <summary>
        ///The IANA protocol|identifier of the network protocols by which 
        ///the contact may be reached using the specified Address. 
        /// </summary>

	public virtual string						Protocol  {get; set;}
        /// <summary>
        ///Cryptographic keys representing capabilities.
        /// </summary>

	public virtual List<CryptographicCapability>				Capabilities  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Capabilities" : {
				if (value is TokenValueListStructObject vvalue) {
					Capabilities = vvalue.Value as List<CryptographicCapability>;
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
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Capabilities" : {
				return new TokenValueListStruct<CryptographicCapability> (Capabilities);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Capabilities", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<CryptographicCapability>(), null, true)} 
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

	public virtual string						OrganizationName  {get; set;}
        /// <summary>
        ///The titles held with respect to that organization.
        /// </summary>

	public virtual List<string>				Titles  {get; set;}
        /// <summary>
        ///Postal or physical addresses associated with the role.
        /// </summary>

	public virtual List<Location>				Locations  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "OrganizationName" : {
				if (value is TokenValueString vvalue) {
					OrganizationName = vvalue.Value;
					}
				break;
				}
			case "Titles" : {
				if (value is TokenValueListString vvalue) {
					Titles = vvalue.Value;
					}
				break;
				}
			case "Locations" : {
				if (value is TokenValueListStructObject vvalue) {
					Locations = vvalue.Value as List<Location>;
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
			case "OrganizationName" : {
				return new TokenValueString (OrganizationName);
				}
			case "Titles" : {
				return new TokenValueListString (Titles);
				}
			case "Locations" : {
				return new TokenValueListStruct<Location> (Locations);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "OrganizationName", new Property (typeof(TokenValueString), false)} ,
			{ "Titles", new Property (typeof(TokenValueListString), true)} ,
			{ "Locations", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Location>(), ()=>new Location(), false)} 
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

	public virtual string						Appartment  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Street  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						District  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Locality  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						County  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Postcode  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Country  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Appartment" : {
				if (value is TokenValueString vvalue) {
					Appartment = vvalue.Value;
					}
				break;
				}
			case "Street" : {
				if (value is TokenValueString vvalue) {
					Street = vvalue.Value;
					}
				break;
				}
			case "District" : {
				if (value is TokenValueString vvalue) {
					District = vvalue.Value;
					}
				break;
				}
			case "Locality" : {
				if (value is TokenValueString vvalue) {
					Locality = vvalue.Value;
					}
				break;
				}
			case "County" : {
				if (value is TokenValueString vvalue) {
					County = vvalue.Value;
					}
				break;
				}
			case "Postcode" : {
				if (value is TokenValueString vvalue) {
					Postcode = vvalue.Value;
					}
				break;
				}
			case "Country" : {
				if (value is TokenValueString vvalue) {
					Country = vvalue.Value;
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
			case "Appartment" : {
				return new TokenValueString (Appartment);
				}
			case "Street" : {
				return new TokenValueString (Street);
				}
			case "District" : {
				return new TokenValueString (District);
				}
			case "Locality" : {
				return new TokenValueString (Locality);
				}
			case "County" : {
				return new TokenValueString (County);
				}
			case "Postcode" : {
				return new TokenValueString (Postcode);
				}
			case "Country" : {
				return new TokenValueString (Country);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Appartment", new Property (typeof(TokenValueString), false)} ,
			{ "Street", new Property (typeof(TokenValueString), false)} ,
			{ "District", new Property (typeof(TokenValueString), false)} ,
			{ "Locality", new Property (typeof(TokenValueString), false)} ,
			{ "County", new Property (typeof(TokenValueString), false)} ,
			{ "Postcode", new Property (typeof(TokenValueString), false)} ,
			{ "Country", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Uri  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Title  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Role  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Uri" : {
				if (value is TokenValueString vvalue) {
					Uri = vvalue.Value;
					}
				break;
				}
			case "Title" : {
				if (value is TokenValueString vvalue) {
					Title = vvalue.Value;
					}
				break;
				}
			case "Role" : {
				if (value is TokenValueListString vvalue) {
					Role = vvalue.Value;
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
			case "Uri" : {
				return new TokenValueString (Uri);
				}
			case "Title" : {
				return new TokenValueString (Title);
				}
			case "Role" : {
				return new TokenValueListString (Role);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new Property (typeof(TokenValueString), false)} ,
			{ "Title", new Property (typeof(TokenValueString), false)} ,
			{ "Role", new Property (typeof(TokenValueListString), true)} 
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

	public virtual string						MessageId  {get; set;}
        /// <summary>
        ///Message that was generated in response to the original (optional).
        /// </summary>

	public virtual string						ResponseId  {get; set;}
        /// <summary>
        ///The relationship type. This can be Read, Unread, Accept, Reject.
        /// </summary>

	public virtual string						Relationship  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MessageId" : {
				if (value is TokenValueString vvalue) {
					MessageId = vvalue.Value;
					}
				break;
				}
			case "ResponseId" : {
				if (value is TokenValueString vvalue) {
					ResponseId = vvalue.Value;
					}
				break;
				}
			case "Relationship" : {
				if (value is TokenValueString vvalue) {
					Relationship = vvalue.Value;
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
			case "MessageId" : {
				return new TokenValueString (MessageId);
				}
			case "ResponseId" : {
				return new TokenValueString (ResponseId);
				}
			case "Relationship" : {
				return new TokenValueString (Relationship);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MessageId", new Property (typeof(TokenValueString), false)} ,
			{ "ResponseId", new Property (typeof(TokenValueString), false)} ,
			{ "Relationship", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Key  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Start  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Finish  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						StartTravel  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						FinishTravel  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						TimeZone  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Title  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Description  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Location  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Trigger  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Conference  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Repeat  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Busy  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Start" : {
				if (value is TokenValueDateTime vvalue) {
					Start = vvalue.Value;
					}
				break;
				}
			case "Finish" : {
				if (value is TokenValueDateTime vvalue) {
					Finish = vvalue.Value;
					}
				break;
				}
			case "StartTravel" : {
				if (value is TokenValueString vvalue) {
					StartTravel = vvalue.Value;
					}
				break;
				}
			case "FinishTravel" : {
				if (value is TokenValueString vvalue) {
					FinishTravel = vvalue.Value;
					}
				break;
				}
			case "TimeZone" : {
				if (value is TokenValueString vvalue) {
					TimeZone = vvalue.Value;
					}
				break;
				}
			case "Title" : {
				if (value is TokenValueString vvalue) {
					Title = vvalue.Value;
					}
				break;
				}
			case "Description" : {
				if (value is TokenValueString vvalue) {
					Description = vvalue.Value;
					}
				break;
				}
			case "Location" : {
				if (value is TokenValueString vvalue) {
					Location = vvalue.Value;
					}
				break;
				}
			case "Trigger" : {
				if (value is TokenValueListString vvalue) {
					Trigger = vvalue.Value;
					}
				break;
				}
			case "Conference" : {
				if (value is TokenValueListString vvalue) {
					Conference = vvalue.Value;
					}
				break;
				}
			case "Repeat" : {
				if (value is TokenValueString vvalue) {
					Repeat = vvalue.Value;
					}
				break;
				}
			case "Busy" : {
				if (value is TokenValueBoolean vvalue) {
					Busy = vvalue.Value;
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
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Start" : {
				return new TokenValueDateTime (Start);
				}
			case "Finish" : {
				return new TokenValueDateTime (Finish);
				}
			case "StartTravel" : {
				return new TokenValueString (StartTravel);
				}
			case "FinishTravel" : {
				return new TokenValueString (FinishTravel);
				}
			case "TimeZone" : {
				return new TokenValueString (TimeZone);
				}
			case "Title" : {
				return new TokenValueString (Title);
				}
			case "Description" : {
				return new TokenValueString (Description);
				}
			case "Location" : {
				return new TokenValueString (Location);
				}
			case "Trigger" : {
				return new TokenValueListString (Trigger);
				}
			case "Conference" : {
				return new TokenValueListString (Conference);
				}
			case "Repeat" : {
				return new TokenValueString (Repeat);
				}
			case "Busy" : {
				return new TokenValueBoolean (Busy);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Start", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Finish", new Property (typeof(TokenValueDateTime), false)} ,
			{ "StartTravel", new Property (typeof(TokenValueString), false)} ,
			{ "FinishTravel", new Property (typeof(TokenValueString), false)} ,
			{ "TimeZone", new Property (typeof(TokenValueString), false)} ,
			{ "Title", new Property (typeof(TokenValueString), false)} ,
			{ "Description", new Property (typeof(TokenValueString), false)} ,
			{ "Location", new Property (typeof(TokenValueString), false)} ,
			{ "Trigger", new Property (typeof(TokenValueListString), true)} ,
			{ "Conference", new Property (typeof(TokenValueListString), true)} ,
			{ "Repeat", new Property (typeof(TokenValueString), false)} ,
			{ "Busy", new Property (typeof(TokenValueBoolean), false)} 
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
        ///The set of labels describing the entry
        /// </summary>

	public virtual List<string>				Labels  {get; set;}
        /// <summary>
        ///User specified identifier.
        /// </summary>

	public virtual string						LocalName  {get; set;}
        /// <summary>
        ///Globaly unique identifier
        /// </summary>

	public virtual string						Uid  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Labels" : {
				if (value is TokenValueListString vvalue) {
					Labels = vvalue.Value;
					}
				break;
				}
			case "LocalName" : {
				if (value is TokenValueString vvalue) {
					LocalName = vvalue.Value;
					}
				break;
				}
			case "Uid" : {
				if (value is TokenValueString vvalue) {
					Uid = vvalue.Value;
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
			case "Labels" : {
				return new TokenValueListString (Labels);
				}
			case "LocalName" : {
				return new TokenValueString (LocalName);
				}
			case "Uid" : {
				return new TokenValueString (Uid);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Labels", new Property (typeof(TokenValueListString), true)} ,
			{ "LocalName", new Property (typeof(TokenValueString), false)} ,
			{ "Uid", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Udf  {get; set;}
        /// <summary>
        ///UDF of the offline signature key of the device
        /// </summary>

	public virtual string						DeviceUdf  {get; set;}
        /// <summary>
        ///UDF of the account online signature key
        /// </summary>

	public virtual string						SignatureUdf  {get; set;}
        /// <summary>
        ///The Mesh profile. Why is this still here? This is not 
        ///specific to the device.
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileUser  {get; set;}
        /// <summary>
        ///The device profile
        /// </summary>

	public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///Slim version of ConnectionDevice used by the presentation layer
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}
        /// <summary>
        ///The public assertion demonstrating connection of the Device to the Mesh
        /// </summary>

	public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionDevice  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationAccount>						EnvelopedActivationAccount  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}
        /// <summary>
        ///Application activations granted to the device.
        /// </summary>

	public virtual List<ApplicationEntry>				ApplicationEntries  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Updated" : {
				if (value is TokenValueDateTime vvalue) {
					Updated = vvalue.Value;
					}
				break;
				}
			case "Udf" : {
				if (value is TokenValueString vvalue) {
					Udf = vvalue.Value;
					}
				break;
				}
			case "DeviceUdf" : {
				if (value is TokenValueString vvalue) {
					DeviceUdf = vvalue.Value;
					}
				break;
				}
			case "SignatureUdf" : {
				if (value is TokenValueString vvalue) {
					SignatureUdf = vvalue.Value;
					}
				break;
				}
			case "EnvelopedProfileUser" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileUser = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileDevice = vvalue.Value as Enveloped<ProfileDevice>;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
					}
				break;
				}
			case "EnvelopedConnectionDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionDevice = vvalue.Value as Enveloped<ConnectionDevice>;
					}
				break;
				}
			case "EnvelopedActivationAccount" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationAccount = vvalue.Value as Enveloped<ActivationAccount>;
					}
				break;
				}
			case "EnvelopedActivationCommon" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationCommon = vvalue.Value as Enveloped<ActivationCommon>;
					}
				break;
				}
			case "ApplicationEntries" : {
				if (value is TokenValueListStructObject vvalue) {
					ApplicationEntries = vvalue.Value as List<ApplicationEntry>;
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
			case "Updated" : {
				return new TokenValueDateTime (Updated);
				}
			case "Udf" : {
				return new TokenValueString (Udf);
				}
			case "DeviceUdf" : {
				return new TokenValueString (DeviceUdf);
				}
			case "SignatureUdf" : {
				return new TokenValueString (SignatureUdf);
				}
			case "EnvelopedProfileUser" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileUser);
				}
			case "EnvelopedProfileDevice" : {
				return new TokenValueStruct<Enveloped<ProfileDevice>> (EnvelopedProfileDevice);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}
			case "EnvelopedConnectionDevice" : {
				return new TokenValueStruct<Enveloped<ConnectionDevice>> (EnvelopedConnectionDevice);
				}
			case "EnvelopedActivationAccount" : {
				return new TokenValueStruct<Enveloped<ActivationAccount>> (EnvelopedActivationAccount);
				}
			case "EnvelopedActivationCommon" : {
				return new TokenValueStruct<Enveloped<ActivationCommon>> (EnvelopedActivationCommon);
				}
			case "ApplicationEntries" : {
				return new TokenValueListStruct<ApplicationEntry> (ApplicationEntries);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Updated", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Udf", new Property (typeof(TokenValueString), false)} ,
			{ "DeviceUdf", new Property (typeof(TokenValueString), false)} ,
			{ "SignatureUdf", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedProfileUser", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} ,
			{ "EnvelopedConnectionDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>(), false)} ,
			{ "EnvelopedActivationAccount", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationAccount>(), ()=>new Enveloped<ActivationAccount>(), false)} ,
			{ "EnvelopedActivationCommon", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>(), false)} ,
			{ "ApplicationEntries", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<ApplicationEntry>(), null, true)} 
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
	///
	/// A publication.
	/// </summary>
public partial class CatalogedPublication : CatalogedEntry {
        /// <summary>
        ///Unique identifier code
        /// </summary>

	public virtual string						Id  {get; set;}
        /// <summary>
        ///The witness key value to use to request access to the record.	
        /// </summary>

	public virtual string						Authenticator  {get; set;}
        /// <summary>
        ///Dare Envelope containing the entry data. The data type is specified
        ///by the envelope metadata.
        /// </summary>

	public virtual DareEnvelope						EnvelopedData  {get; set;}
        /// <summary>
        ///Epiration time (inclusive)
        /// </summary>

	public virtual DateTime?						NotOnOrAfter  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Authenticator" : {
				if (value is TokenValueString vvalue) {
					Authenticator = vvalue.Value;
					}
				break;
				}
			case "EnvelopedData" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedData = vvalue.Value as DareEnvelope;
					}
				break;
				}
			case "NotOnOrAfter" : {
				if (value is TokenValueDateTime vvalue) {
					NotOnOrAfter = vvalue.Value;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Authenticator" : {
				return new TokenValueString (Authenticator);
				}
			case "EnvelopedData" : {
				return new TokenValueStruct<DareEnvelope> (EnvelopedData);
				}
			case "NotOnOrAfter" : {
				return new TokenValueDateTime (NotOnOrAfter);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Authenticator", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedData", new Property ( typeof(TokenValueStruct), false,
					()=>new DareEnvelope(), ()=>new DareEnvelope(), false)} ,
			{ "NotOnOrAfter", new Property (typeof(TokenValueDateTime), false)} 
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

	public virtual string						Protocol  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Service  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Username  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Password  {get; set;}
        /// <summary>
        ///Specifies the client identification key
        /// </summary>

	public virtual List<KeyData>				ClientAuthentication  {get; set;}
        /// <summary>
        ///Means of authenticating the host key
        /// </summary>

	public virtual List<KeyData>				HostAuthentication  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Service" : {
				if (value is TokenValueString vvalue) {
					Service = vvalue.Value;
					}
				break;
				}
			case "Username" : {
				if (value is TokenValueString vvalue) {
					Username = vvalue.Value;
					}
				break;
				}
			case "Password" : {
				if (value is TokenValueString vvalue) {
					Password = vvalue.Value;
					}
				break;
				}
			case "ClientAuthentication" : {
				if (value is TokenValueListStructObject vvalue) {
					ClientAuthentication = vvalue.Value as List<KeyData>;
					}
				break;
				}
			case "HostAuthentication" : {
				if (value is TokenValueListStructObject vvalue) {
					HostAuthentication = vvalue.Value as List<KeyData>;
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
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Service" : {
				return new TokenValueString (Service);
				}
			case "Username" : {
				return new TokenValueString (Username);
				}
			case "Password" : {
				return new TokenValueString (Password);
				}
			case "ClientAuthentication" : {
				return new TokenValueListStruct<KeyData> (ClientAuthentication);
				}
			case "HostAuthentication" : {
				return new TokenValueListStruct<KeyData> (HostAuthentication);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Service", new Property (typeof(TokenValueString), false)} ,
			{ "Username", new Property (typeof(TokenValueString), false)} ,
			{ "Password", new Property (typeof(TokenValueString), false)} ,
			{ "ClientAuthentication", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<KeyData>(), ()=>new KeyData(), false)} ,
			{ "HostAuthentication", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<KeyData>(), ()=>new KeyData(), false)} 
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
public partial class CatalogedApplicationSsh : CatalogedApplication {
        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData						ClientKey  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ClientKey" : {
				if (value is TokenValueStructObject vvalue) {
					ClientKey = vvalue.Value as KeyData;
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
			case "ClientKey" : {
				return new TokenValueStruct<KeyData> (ClientKey);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ClientKey", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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
public partial class CatalogedNetwork : CatalogedEntry {
        /// <summary>
        /// </summary>

	public virtual string						Protocol  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Service  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Username  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Password  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Service" : {
				if (value is TokenValueString vvalue) {
					Service = vvalue.Value;
					}
				break;
				}
			case "Username" : {
				if (value is TokenValueString vvalue) {
					Username = vvalue.Value;
					}
				break;
				}
			case "Password" : {
				if (value is TokenValueString vvalue) {
					Password = vvalue.Value;
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
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Service" : {
				return new TokenValueString (Service);
				}
			case "Username" : {
				return new TokenValueString (Username);
				}
			case "Password" : {
				return new TokenValueString (Password);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Service", new Property (typeof(TokenValueString), false)} ,
			{ "Username", new Property (typeof(TokenValueString), false)} ,
			{ "Password", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Key  {get; set;}
        /// <summary>
        ///If true, this catalog entry is for the user who created the catalog.
        /// </summary>

	public virtual bool?						Self  {get; set;}
        /// <summary>
        ///The contact information as edited by the catalog owner.
        /// </summary>

	public virtual Contact						Contact  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Self" : {
				if (value is TokenValueBoolean vvalue) {
					Self = vvalue.Value;
					}
				break;
				}
			case "Contact" : {
				if (value is TokenValueStructObject vvalue) {
					Contact = vvalue.Value as Contact;
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
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Self" : {
				return new TokenValueBoolean (Self);
				}
			case "Contact" : {
				return new TokenValueStruct<Contact> (Contact);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Self", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Contact", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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

	public virtual Capability						Capability  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Capability" : {
				if (value is TokenValueStructObject vvalue) {
					Capability = vvalue.Value as Capability;
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
			case "Capability" : {
				return new TokenValueStruct<Capability> (Capability);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Capability", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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

	public virtual string						Id  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Active  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Issued  {get; set;}
        /// <summary>
        ///The authentication mode: Device, Account, PIN
        /// </summary>

	public virtual string						Mode  {get; set;}
        /// <summary>
        ///Identifies the authentication credential. For a device, this is the authentication key identifier, 
        ///for an account, the profile identifier, for a PIN, the locator value of the PIN.
        /// </summary>

	public virtual string						Udf  {get; set;}
        /// <summary>
        ///The verification value used to perform proof of knowledge of the secret.
        /// </summary>

	public virtual string						Witness  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Id" : {
				if (value is TokenValueString vvalue) {
					Id = vvalue.Value;
					}
				break;
				}
			case "Active" : {
				if (value is TokenValueBoolean vvalue) {
					Active = vvalue.Value;
					}
				break;
				}
			case "Issued" : {
				if (value is TokenValueInteger32 vvalue) {
					Issued = vvalue.Value;
					}
				break;
				}
			case "Mode" : {
				if (value is TokenValueString vvalue) {
					Mode = vvalue.Value;
					}
				break;
				}
			case "Udf" : {
				if (value is TokenValueString vvalue) {
					Udf = vvalue.Value;
					}
				break;
				}
			case "Witness" : {
				if (value is TokenValueString vvalue) {
					Witness = vvalue.Value;
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
			case "Id" : {
				return new TokenValueString (Id);
				}
			case "Active" : {
				return new TokenValueBoolean (Active);
				}
			case "Issued" : {
				return new TokenValueInteger32 (Issued);
				}
			case "Mode" : {
				return new TokenValueString (Mode);
				}
			case "Udf" : {
				return new TokenValueString (Udf);
				}
			case "Witness" : {
				return new TokenValueString (Witness);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Id", new Property (typeof(TokenValueString), false)} ,
			{ "Active", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Issued", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Mode", new Property (typeof(TokenValueString), false)} ,
			{ "Udf", new Property (typeof(TokenValueString), false)} ,
			{ "Witness", new Property (typeof(TokenValueString), false)} 
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

	public virtual List<string>				Rights  {get; set;}
        /// <summary>
        ///
        /// </summary>

	public virtual Enveloped<CatalogedDevice>						EnvelopedCatalogedDevice  {get; set;}
        /// <summary>
        ///Digest value used to signal updates to envelope		
        /// </summary>

	public virtual string						CatalogedDeviceDigest  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Rights" : {
				if (value is TokenValueListString vvalue) {
					Rights = vvalue.Value;
					}
				break;
				}
			case "EnvelopedCatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCatalogedDevice = vvalue.Value as Enveloped<CatalogedDevice>;
					}
				break;
				}
			case "CatalogedDeviceDigest" : {
				if (value is TokenValueString vvalue) {
					CatalogedDeviceDigest = vvalue.Value;
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
			case "Rights" : {
				return new TokenValueListString (Rights);
				}
			case "EnvelopedCatalogedDevice" : {
				return new TokenValueStruct<Enveloped<CatalogedDevice>> (EnvelopedCatalogedDevice);
				}
			case "CatalogedDeviceDigest" : {
				return new TokenValueString (CatalogedDeviceDigest);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Rights", new Property (typeof(TokenValueListString), true)} ,
			{ "EnvelopedCatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CatalogedDevice>(), ()=>new Enveloped<CatalogedDevice>(), false)} ,
			{ "CatalogedDeviceDigest", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Identifier  {get; set;}
        /// <summary>
        ///Document digest, this allows a status/claim request to 
        ///request an update to be returned only if the document
        ///has changed.
        /// </summary>

	public virtual string						Digest  {get; set;}
        /// <summary>
        ///The published document.
        /// </summary>

	public virtual byte[]						Data  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Identifier" : {
				if (value is TokenValueString vvalue) {
					Identifier = vvalue.Value;
					}
				break;
				}
			case "Digest" : {
				if (value is TokenValueString vvalue) {
					Digest = vvalue.Value;
					}
				break;
				}
			case "Data" : {
				if (value is TokenValueBinary vvalue) {
					Data = vvalue.Value;
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
			case "Identifier" : {
				return new TokenValueString (Identifier);
				}
			case "Digest" : {
				return new TokenValueString (Digest);
				}
			case "Data" : {
				return new TokenValueBinary (Data);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Identifier", new Property (typeof(TokenValueString), false)} ,
			{ "Digest", new Property (typeof(TokenValueString), false)} ,
			{ "Data", new Property (typeof(TokenValueBinary), false)} 
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

	public virtual KeyData						KeyData  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						GranteeAccount  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						GranteeUdf  {get; set;}
        /// <summary>
        ///One or more enveloped key shares.
        /// </summary>

	public virtual Enveloped<KeyData>						EnvelopedKeyShare  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "KeyData" : {
				if (value is TokenValueStructObject vvalue) {
					KeyData = vvalue.Value as KeyData;
					}
				break;
				}
			case "GranteeAccount" : {
				if (value is TokenValueString vvalue) {
					GranteeAccount = vvalue.Value;
					}
				break;
				}
			case "GranteeUdf" : {
				if (value is TokenValueString vvalue) {
					GranteeUdf = vvalue.Value;
					}
				break;
				}
			case "EnvelopedKeyShare" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedKeyShare = vvalue.Value as Enveloped<KeyData>;
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
			case "KeyData" : {
				return new TokenValueStruct<KeyData> (KeyData);
				}
			case "GranteeAccount" : {
				return new TokenValueString (GranteeAccount);
				}
			case "GranteeUdf" : {
				return new TokenValueString (GranteeUdf);
				}
			case "EnvelopedKeyShare" : {
				return new TokenValueStruct<Enveloped<KeyData>> (EnvelopedKeyShare);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "KeyData", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "GranteeAccount", new Property (typeof(TokenValueString), false)} ,
			{ "GranteeUdf", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedKeyShare", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<KeyData>(), ()=>new Enveloped<KeyData>(), false)} 
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

	public virtual string						AuthenticationId  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AuthenticationId" : {
				if (value is TokenValueString vvalue) {
					AuthenticationId = vvalue.Value;
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
			case "AuthenticationId" : {
				return new TokenValueString (AuthenticationId);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AuthenticationId", new Property (typeof(TokenValueString), false)} 
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
public partial class CatalogedCallsign : CatalogedApplication {
        /// <summary>
        ///Fast lookup for the canonical form of the callsign.
        /// </summary>

	public virtual string						Canonical  {get; set;}
        /// <summary>
        ///Fast lookup for the profile to which the name is bound.		
        /// </summary>

	public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///The enveloped binnding of the callsign to the profile.		
        /// </summary>

	public virtual Enveloped<CallsignBinding>						EnvelopedCallsignBinding  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Canonical" : {
				if (value is TokenValueString vvalue) {
					Canonical = vvalue.Value;
					}
				break;
				}
			case "ProfileUdf" : {
				if (value is TokenValueString vvalue) {
					ProfileUdf = vvalue.Value;
					}
				break;
				}
			case "EnvelopedCallsignBinding" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedCallsignBinding = vvalue.Value as Enveloped<CallsignBinding>;
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
			case "Canonical" : {
				return new TokenValueString (Canonical);
				}
			case "ProfileUdf" : {
				return new TokenValueString (ProfileUdf);
				}
			case "EnvelopedCallsignBinding" : {
				return new TokenValueStruct<Enveloped<CallsignBinding>> (EnvelopedCallsignBinding);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Canonical", new Property (typeof(TokenValueString), false)} ,
			{ "ProfileUdf", new Property (typeof(TokenValueString), false)} ,
			{ "EnvelopedCallsignBinding", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<CallsignBinding>(), ()=>new Enveloped<CallsignBinding>(), false)} 
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
	public new const string __Tag = "CatalogedCallsign";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedCallsign();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedCallsign FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedCallsign;
			}
		var Result = new CatalogedCallsign ();
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

	public virtual string						Prefix  {get; set;}
        /// <summary>
        ///Optional name mapping, (e.g. alice@example.com -> alice.mesh)
        /// </summary>

	public virtual string						Mapping  {get; set;}
        /// <summary>
        ///The service endpoints. This MAY be specified as a callsign (@alice),
        ///a DNS address (example.com), an IP address (10.0.0.1) or a fully
        ///qualified URI.
        /// </summary>

	public virtual List<string>				Endpoints  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Prefix" : {
				if (value is TokenValueString vvalue) {
					Prefix = vvalue.Value;
					}
				break;
				}
			case "Mapping" : {
				if (value is TokenValueString vvalue) {
					Mapping = vvalue.Value;
					}
				break;
				}
			case "Endpoints" : {
				if (value is TokenValueListString vvalue) {
					Endpoints = vvalue.Value;
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
			case "Prefix" : {
				return new TokenValueString (Prefix);
				}
			case "Mapping" : {
				return new TokenValueString (Mapping);
				}
			case "Endpoints" : {
				return new TokenValueListString (Endpoints);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Prefix", new Property (typeof(TokenValueString), false)} ,
			{ "Mapping", new Property (typeof(TokenValueString), false)} ,
			{ "Endpoints", new Property (typeof(TokenValueListString), true)} 
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

	public virtual byte[]						Token  {get; set;}
        /// <summary>
        ///Session shared secret
        /// </summary>

	public virtual byte[]						SharedSecret  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Token" : {
				if (value is TokenValueBinary vvalue) {
					Token = vvalue.Value;
					}
				break;
				}
			case "SharedSecret" : {
				if (value is TokenValueBinary vvalue) {
					SharedSecret = vvalue.Value;
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
			case "Token" : {
				return new TokenValueBinary (Token);
				}
			case "SharedSecret" : {
				return new TokenValueBinary (SharedSecret);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Token", new Property (typeof(TokenValueBinary), false)} ,
			{ "SharedSecret", new Property (typeof(TokenValueBinary), false)} 
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

	public virtual string						Uri  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Title  {get; set;}
        /// <summary>
        ///User comments on bookmark entry
        /// </summary>

	public virtual List<string>				Comments  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Uri" : {
				if (value is TokenValueString vvalue) {
					Uri = vvalue.Value;
					}
				break;
				}
			case "Title" : {
				if (value is TokenValueString vvalue) {
					Title = vvalue.Value;
					}
				break;
				}
			case "Comments" : {
				if (value is TokenValueListString vvalue) {
					Comments = vvalue.Value;
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
			case "Uri" : {
				return new TokenValueString (Uri);
				}
			case "Title" : {
				return new TokenValueString (Title);
				}
			case "Comments" : {
				return new TokenValueListString (Comments);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Uri", new Property (typeof(TokenValueString), false)} ,
			{ "Title", new Property (typeof(TokenValueString), false)} ,
			{ "Comments", new Property (typeof(TokenValueListString), true)} 
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

	public virtual Enveloped<Engagement>						EnvelopedTask  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Title  {get; set;}
        /// <summary>
        ///Unique key.
        /// </summary>

	public virtual string						Key  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedTask" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedTask = vvalue.Value as Enveloped<Engagement>;
					}
				break;
				}
			case "Title" : {
				if (value is TokenValueString vvalue) {
					Title = vvalue.Value;
					}
				break;
				}
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
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
			case "EnvelopedTask" : {
				return new TokenValueStruct<Enveloped<Engagement>> (EnvelopedTask);
				}
			case "Title" : {
				return new TokenValueString (Title);
				}
			case "Key" : {
				return new TokenValueString (Key);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedTask", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<Engagement>(), ()=>new Enveloped<Engagement>(), false)} ,
			{ "Title", new Property (typeof(TokenValueString), false)} ,
			{ "Key", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Key  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Grant  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Deny  {get; set;}
        /// <summary>
        ///Enveloped keys for use with Application
        /// </summary>

	public virtual List<DareEnvelope>				EnvelopedCapabilities  {get; set;}
        /// <summary>
        ///Escrow entries for the application.
        /// </summary>

	public virtual List<Enveloped<KeyData>>				EnvelopedEscrow  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Default" : {
				if (value is TokenValueInteger32 vvalue) {
					Default = vvalue.Value;
					}
				break;
				}
			case "Key" : {
				if (value is TokenValueString vvalue) {
					Key = vvalue.Value;
					}
				break;
				}
			case "Grant" : {
				if (value is TokenValueListString vvalue) {
					Grant = vvalue.Value;
					}
				break;
				}
			case "Deny" : {
				if (value is TokenValueListString vvalue) {
					Deny = vvalue.Value;
					}
				break;
				}
			case "EnvelopedCapabilities" : {
				if (value is TokenValueListStructObject vvalue) {
					EnvelopedCapabilities = vvalue.Value as List<DareEnvelope>;
					}
				break;
				}
			case "EnvelopedEscrow" : {
				if (value is TokenValueListStructObject vvalue) {
					EnvelopedEscrow = vvalue.Value as List<Enveloped<KeyData>>;
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
			case "Default" : {
				return new TokenValueInteger32 (Default);
				}
			case "Key" : {
				return new TokenValueString (Key);
				}
			case "Grant" : {
				return new TokenValueListString (Grant);
				}
			case "Deny" : {
				return new TokenValueListString (Deny);
				}
			case "EnvelopedCapabilities" : {
				return new TokenValueListStruct<DareEnvelope> (EnvelopedCapabilities);
				}
			case "EnvelopedEscrow" : {
				return new TokenValueListStruct<Enveloped<KeyData>> (EnvelopedEscrow);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Default", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Key", new Property (typeof(TokenValueString), false)} ,
			{ "Grant", new Property (typeof(TokenValueListString), true)} ,
			{ "Deny", new Property (typeof(TokenValueListString), true)} ,
			{ "EnvelopedCapabilities", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<DareEnvelope>(), ()=>new DareEnvelope(), false)} ,
			{ "EnvelopedEscrow", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Enveloped<KeyData>>(), ()=>new Enveloped<KeyData>(), false)} 
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

	public virtual string						ContactAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						MemberCapabilityId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						ServiceCapabilityId  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ContactAddress" : {
				if (value is TokenValueString vvalue) {
					ContactAddress = vvalue.Value;
					}
				break;
				}
			case "MemberCapabilityId" : {
				if (value is TokenValueString vvalue) {
					MemberCapabilityId = vvalue.Value;
					}
				break;
				}
			case "ServiceCapabilityId" : {
				if (value is TokenValueString vvalue) {
					ServiceCapabilityId = vvalue.Value;
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
			case "ContactAddress" : {
				return new TokenValueString (ContactAddress);
				}
			case "MemberCapabilityId" : {
				return new TokenValueString (MemberCapabilityId);
				}
			case "ServiceCapabilityId" : {
				return new TokenValueString (ServiceCapabilityId);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ContactAddress", new Property (typeof(TokenValueString), false)} ,
			{ "MemberCapabilityId", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceCapabilityId", new Property (typeof(TokenValueString), false)} 
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

	public virtual Enveloped<ConnectionStripped>						EnvelopedConnectionAddress  {get; set;}
        /// <summary>
        ///The Mesh profile
        /// </summary>

	public virtual Enveloped<ProfileAccount>						EnvelopedProfileGroup  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

	public virtual Enveloped<ActivationCommon>						EnvelopedActivationCommon  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedConnectionAddress" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionAddress = vvalue.Value as Enveloped<ConnectionStripped>;
					}
				break;
				}
			case "EnvelopedProfileGroup" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileGroup = vvalue.Value as Enveloped<ProfileAccount>;
					}
				break;
				}
			case "EnvelopedActivationCommon" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedActivationCommon = vvalue.Value as Enveloped<ActivationCommon>;
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
			case "EnvelopedConnectionAddress" : {
				return new TokenValueStruct<Enveloped<ConnectionStripped>> (EnvelopedConnectionAddress);
				}
			case "EnvelopedProfileGroup" : {
				return new TokenValueStruct<Enveloped<ProfileAccount>> (EnvelopedProfileGroup);
				}
			case "EnvelopedActivationCommon" : {
				return new TokenValueStruct<Enveloped<ActivationCommon>> (EnvelopedActivationCommon);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedConnectionAddress", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionStripped>(), ()=>new Enveloped<ConnectionStripped>(), false)} ,
			{ "EnvelopedProfileGroup", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileAccount>(), ()=>new Enveloped<ProfileAccount>(), false)} ,
			{ "EnvelopedActivationCommon", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ActivationCommon>(), ()=>new Enveloped<ActivationCommon>(), false)} 
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
public partial class CatalogedApplicationMail : CatalogedApplication {
        /// <summary>
        /// </summary>

	public virtual string						AccountAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						InboundConnect  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						OutboundConnect  {get; set;}
        /// <summary>
        ///The S/Mime signature key
        /// </summary>

	public virtual KeyData						SmimeSign  {get; set;}
        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData						SmimeEncrypt  {get; set;}
        /// <summary>
        ///The OpenPGP signature key
        /// </summary>

	public virtual KeyData						OpenpgpSign  {get; set;}
        /// <summary>
        ///The OpenPGP encryption key
        /// </summary>

	public virtual KeyData						OpenpgpEncrypt  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
					}
				break;
				}
			case "InboundConnect" : {
				if (value is TokenValueString vvalue) {
					InboundConnect = vvalue.Value;
					}
				break;
				}
			case "OutboundConnect" : {
				if (value is TokenValueString vvalue) {
					OutboundConnect = vvalue.Value;
					}
				break;
				}
			case "SmimeSign" : {
				if (value is TokenValueStructObject vvalue) {
					SmimeSign = vvalue.Value as KeyData;
					}
				break;
				}
			case "SmimeEncrypt" : {
				if (value is TokenValueStructObject vvalue) {
					SmimeEncrypt = vvalue.Value as KeyData;
					}
				break;
				}
			case "OpenpgpSign" : {
				if (value is TokenValueStructObject vvalue) {
					OpenpgpSign = vvalue.Value as KeyData;
					}
				break;
				}
			case "OpenpgpEncrypt" : {
				if (value is TokenValueStructObject vvalue) {
					OpenpgpEncrypt = vvalue.Value as KeyData;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}
			case "InboundConnect" : {
				return new TokenValueString (InboundConnect);
				}
			case "OutboundConnect" : {
				return new TokenValueString (OutboundConnect);
				}
			case "SmimeSign" : {
				return new TokenValueStruct<KeyData> (SmimeSign);
				}
			case "SmimeEncrypt" : {
				return new TokenValueStruct<KeyData> (SmimeEncrypt);
				}
			case "OpenpgpSign" : {
				return new TokenValueStruct<KeyData> (OpenpgpSign);
				}
			case "OpenpgpEncrypt" : {
				return new TokenValueStruct<KeyData> (OpenpgpEncrypt);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} ,
			{ "InboundConnect", new Property (typeof(TokenValueString), false)} ,
			{ "OutboundConnect", new Property (typeof(TokenValueString), false)} ,
			{ "SmimeSign", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "SmimeEncrypt", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "OpenpgpSign", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} ,
			{ "OpenpgpEncrypt", new Property ( typeof(TokenValueStruct), false,
					()=>new KeyData(), ()=>new KeyData(), false)} 
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
public partial class CatalogedApplicationNetwork : CatalogedApplication {


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
	public new const string __Tag = "CatalogedApplicationNetwork";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new CatalogedApplicationNetwork();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new CatalogedApplicationNetwork FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as CatalogedApplicationNetwork;
			}
		var Result = new CatalogedApplicationNetwork ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageInvoice : Message {


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

	public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///A list of URIs specifying hailing transports that may be used to
        ///initiate a connection to the device. This allows a device to 
        ///specify that it can be reached by WiFi transport to a particular 
        ///private SSID, or by Bluetooth, IR etc. etc.
        /// </summary>

	public virtual List<string>				Hailing  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedProfileDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedProfileDevice = vvalue.Value as Enveloped<ProfileDevice>;
					}
				break;
				}
			case "Hailing" : {
				if (value is TokenValueListString vvalue) {
					Hailing = vvalue.Value;
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
			case "EnvelopedProfileDevice" : {
				return new TokenValueStruct<Enveloped<ProfileDevice>> (EnvelopedProfileDevice);
				}
			case "Hailing" : {
				return new TokenValueListString (Hailing);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedProfileDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ProfileDevice>(), ()=>new Enveloped<ProfileDevice>(), false)} ,
			{ "Hailing", new Property (typeof(TokenValueListString), true)} 
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

	public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionDevice  {get; set;}
        /// <summary>
        ///The device connection
        /// </summary>

	public virtual Enveloped<ConnectionService>						EnvelopedConnectionService  {get; set;}
        /// <summary>
        ///The device private key
        /// </summary>

	public virtual Key						PrivateKey  {get; set;}
        /// <summary>
        ///The connection URI. This would normally be printed on the device as a 
        ///QR code.
        /// </summary>

	public virtual string						ConnectUri  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedConnectionDevice" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionDevice = vvalue.Value as Enveloped<ConnectionDevice>;
					}
				break;
				}
			case "EnvelopedConnectionService" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedConnectionService = vvalue.Value as Enveloped<ConnectionService>;
					}
				break;
				}
			case "PrivateKey" : {
				if (value is TokenValueStructObject vvalue) {
					PrivateKey = vvalue.Value as Key;
					}
				break;
				}
			case "ConnectUri" : {
				if (value is TokenValueString vvalue) {
					ConnectUri = vvalue.Value;
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
			case "EnvelopedConnectionDevice" : {
				return new TokenValueStruct<Enveloped<ConnectionDevice>> (EnvelopedConnectionDevice);
				}
			case "EnvelopedConnectionService" : {
				return new TokenValueStruct<Enveloped<ConnectionService>> (EnvelopedConnectionService);
				}
			case "PrivateKey" : {
				return new TokenValueStruct<Key> (PrivateKey);
				}
			case "ConnectUri" : {
				return new TokenValueString (ConnectUri);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedConnectionDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionDevice>(), ()=>new Enveloped<ConnectionDevice>(), false)} ,
			{ "EnvelopedConnectionService", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<ConnectionService>(), ()=>new Enveloped<ConnectionService>(), false)} ,
			{ "PrivateKey", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} ,
			{ "ConnectUri", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						MessageId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Sender  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Recipient  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "MessageId" : {
				if (value is TokenValueString vvalue) {
					MessageId = vvalue.Value;
					}
				break;
				}
			case "Sender" : {
				if (value is TokenValueString vvalue) {
					Sender = vvalue.Value;
					}
				break;
				}
			case "Recipient" : {
				if (value is TokenValueString vvalue) {
					Recipient = vvalue.Value;
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
			case "MessageId" : {
				return new TokenValueString (MessageId);
				}
			case "Sender" : {
				return new TokenValueString (Sender);
				}
			case "Recipient" : {
				return new TokenValueString (Recipient);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "MessageId", new Property (typeof(TokenValueString), false)} ,
			{ "Sender", new Property (typeof(TokenValueString), false)} ,
			{ "Recipient", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						ErrorCode  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ErrorCode" : {
				if (value is TokenValueString vvalue) {
					ErrorCode = vvalue.Value;
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
			case "ErrorCode" : {
				return new TokenValueString (ErrorCode);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ErrorCode", new Property (typeof(TokenValueString), false)} 
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

	public virtual List<Reference>				References  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "References" : {
				if (value is TokenValueListStructObject vvalue) {
					References = vvalue.Value as List<Reference>;
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
			case "References" : {
				return new TokenValueListStruct<Reference> (References);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "References", new Property ( typeof(TokenValueListStruct), true,
					()=>new List<Reference>(), ()=>new Reference(), false)} 
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

	public virtual DareEnvelope						AuthenticatedData  {get; set;}
        /// <summary>
        ///Nonce provided by the client to validate the PIN
        /// </summary>

	public virtual byte[]						ClientNonce  {get; set;}
        /// <summary>
        ///Pin identifier value calculated from the PIN code, action and account address.
        /// </summary>

	public virtual string						PinId  {get; set;}
        /// <summary>
        ///Witness value calculated as KDF (Device.Udf + AccountAddress, ClientNonce)
        /// </summary>

	public virtual byte[]						PinWitness  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AuthenticatedData" : {
				if (value is TokenValueStructObject vvalue) {
					AuthenticatedData = vvalue.Value as DareEnvelope;
					}
				break;
				}
			case "ClientNonce" : {
				if (value is TokenValueBinary vvalue) {
					ClientNonce = vvalue.Value;
					}
				break;
				}
			case "PinId" : {
				if (value is TokenValueString vvalue) {
					PinId = vvalue.Value;
					}
				break;
				}
			case "PinWitness" : {
				if (value is TokenValueBinary vvalue) {
					PinWitness = vvalue.Value;
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
			case "AuthenticatedData" : {
				return new TokenValueStruct<DareEnvelope> (AuthenticatedData);
				}
			case "ClientNonce" : {
				return new TokenValueBinary (ClientNonce);
				}
			case "PinId" : {
				return new TokenValueString (PinId);
				}
			case "PinWitness" : {
				return new TokenValueBinary (PinWitness);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AuthenticatedData", new Property ( typeof(TokenValueStruct), false,
					()=>new DareEnvelope(), ()=>new DareEnvelope(), false)} ,
			{ "ClientNonce", new Property (typeof(TokenValueBinary), false)} ,
			{ "PinId", new Property (typeof(TokenValueString), false)} ,
			{ "PinWitness", new Property (typeof(TokenValueBinary), false)} 
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

	public virtual string						Account  {get; set;}
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

	public virtual string						SaltedPin  {get; set;}
        /// <summary>
        ///The action to which this PIN code is bound.
        /// </summary>

	public virtual string						Action  {get; set;}
        /// <summary>
        ///The set of rights bound to the PIN grant.
        /// </summary>

	public virtual List<string>				Roles  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Account" : {
				if (value is TokenValueString vvalue) {
					Account = vvalue.Value;
					}
				break;
				}
			case "Expires" : {
				if (value is TokenValueDateTime vvalue) {
					Expires = vvalue.Value;
					}
				break;
				}
			case "Automatic" : {
				if (value is TokenValueBoolean vvalue) {
					Automatic = vvalue.Value;
					}
				break;
				}
			case "SaltedPin" : {
				if (value is TokenValueString vvalue) {
					SaltedPin = vvalue.Value;
					}
				break;
				}
			case "Action" : {
				if (value is TokenValueString vvalue) {
					Action = vvalue.Value;
					}
				break;
				}
			case "Roles" : {
				if (value is TokenValueListString vvalue) {
					Roles = vvalue.Value;
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
			case "Account" : {
				return new TokenValueString (Account);
				}
			case "Expires" : {
				return new TokenValueDateTime (Expires);
				}
			case "Automatic" : {
				return new TokenValueBoolean (Automatic);
				}
			case "SaltedPin" : {
				return new TokenValueString (SaltedPin);
				}
			case "Action" : {
				return new TokenValueString (Action);
				}
			case "Roles" : {
				return new TokenValueListString (Roles);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Account", new Property (typeof(TokenValueString), false)} ,
			{ "Expires", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Automatic", new Property (typeof(TokenValueBoolean), false)} ,
			{ "SaltedPin", new Property (typeof(TokenValueString), false)} ,
			{ "Action", new Property (typeof(TokenValueString), false)} ,
			{ "Roles", new Property (typeof(TokenValueListString), true)} 
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

	public virtual string						AccountAddress  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "AccountAddress" : {
				if (value is TokenValueString vvalue) {
					AccountAddress = vvalue.Value;
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
			case "AccountAddress" : {
				return new TokenValueString (AccountAddress);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "AccountAddress", new Property (typeof(TokenValueString), false)} 
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

	public virtual Enveloped<RequestConnection>						EnvelopedRequestConnection  {get; set;}
        /// <summary>
        ///
        /// </summary>

	public virtual byte[]						ServerNonce  {get; set;}
        /// <summary>
        ///
        /// </summary>

	public virtual string						Witness  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EnvelopedRequestConnection" : {
				if (value is TokenValueStructObject vvalue) {
					EnvelopedRequestConnection = vvalue.Value as Enveloped<RequestConnection>;
					}
				break;
				}
			case "ServerNonce" : {
				if (value is TokenValueBinary vvalue) {
					ServerNonce = vvalue.Value;
					}
				break;
				}
			case "Witness" : {
				if (value is TokenValueString vvalue) {
					Witness = vvalue.Value;
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
			case "EnvelopedRequestConnection" : {
				return new TokenValueStruct<Enveloped<RequestConnection>> (EnvelopedRequestConnection);
				}
			case "ServerNonce" : {
				return new TokenValueBinary (ServerNonce);
				}
			case "Witness" : {
				return new TokenValueString (Witness);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EnvelopedRequestConnection", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<RequestConnection>(), ()=>new Enveloped<RequestConnection>(), false)} ,
			{ "ServerNonce", new Property (typeof(TokenValueBinary), false)} ,
			{ "Witness", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Result  {get; set;}
        /// <summary>
        ///The device information. MUST be present if the value of Result is
        ///"Accept". MUST be absent or null otherwise.
        /// </summary>

	public virtual CatalogedDevice						CatalogedDevice  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Result" : {
				if (value is TokenValueString vvalue) {
					Result = vvalue.Value;
					}
				break;
				}
			case "CatalogedDevice" : {
				if (value is TokenValueStructObject vvalue) {
					CatalogedDevice = vvalue.Value as CatalogedDevice;
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
				return new TokenValueString (Result);
				}
			case "CatalogedDevice" : {
				return new TokenValueStruct<CatalogedDevice> (CatalogedDevice);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Result", new Property (typeof(TokenValueString), false)} ,
			{ "CatalogedDevice", new Property ( typeof(TokenValueStruct), false,
					()=>new CatalogedDevice(), ()=>new CatalogedDevice(), false)} 
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

	public virtual string						Subject  {get; set;}
        /// <summary>
        ///One time authentication code supplied to a recipient to allow authentication
        ///of the response.
        /// </summary>

	public virtual string						PIN  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Reply" : {
				if (value is TokenValueBoolean vvalue) {
					Reply = vvalue.Value;
					}
				break;
				}
			case "Subject" : {
				if (value is TokenValueString vvalue) {
					Subject = vvalue.Value;
					}
				break;
				}
			case "PIN" : {
				if (value is TokenValueString vvalue) {
					PIN = vvalue.Value;
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
			case "Reply" : {
				return new TokenValueBoolean (Reply);
				}
			case "Subject" : {
				return new TokenValueString (Subject);
				}
			case "PIN" : {
				return new TokenValueString (PIN);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Reply", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Subject", new Property (typeof(TokenValueString), false)} ,
			{ "PIN", new Property (typeof(TokenValueString), false)} 
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

	public virtual string						Text  {get; set;}
        /// <summary>
        ///The contact data.
        /// </summary>

	public virtual Contact						Contact  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Text" : {
				if (value is TokenValueString vvalue) {
					Text = vvalue.Value;
					}
				break;
				}
			case "Contact" : {
				if (value is TokenValueStructObject vvalue) {
					Contact = vvalue.Value as Contact;
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
			case "Text" : {
				return new TokenValueString (Text);
				}
			case "Contact" : {
				return new TokenValueStruct<Contact> (Contact);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Text", new Property (typeof(TokenValueString), false)} ,
			{ "Contact", new Property ( typeof(TokenValueStruct), false,
					null, null, true)} 
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
public partial class RequestConfirmation : Message {
        /// <summary>
        /// </summary>

	public virtual string						Text  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Text" : {
				if (value is TokenValueString vvalue) {
					Text = vvalue.Value;
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
			case "Text" : {
				return new TokenValueString (Text);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Text", new Property (typeof(TokenValueString), false)} 
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

	public virtual Enveloped<RequestConfirmation>						Request  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Accept  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Request" : {
				if (value is TokenValueStructObject vvalue) {
					Request = vvalue.Value as Enveloped<RequestConfirmation>;
					}
				break;
				}
			case "Accept" : {
				if (value is TokenValueBoolean vvalue) {
					Accept = vvalue.Value;
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
			case "Request" : {
				return new TokenValueStruct<Enveloped<RequestConfirmation>> (Request);
				}
			case "Accept" : {
				return new TokenValueBoolean (Accept);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Request", new Property ( typeof(TokenValueStruct), false,
					()=>new Enveloped<RequestConfirmation>(), ()=>new Enveloped<RequestConfirmation>(), false)} ,
			{ "Accept", new Property (typeof(TokenValueBoolean), false)} 
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

	public virtual string						PublicationId  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						ServiceAuthenticate  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						DeviceAuthenticate  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "PublicationId" : {
				if (value is TokenValueString vvalue) {
					PublicationId = vvalue.Value;
					}
				break;
				}
			case "ServiceAuthenticate" : {
				if (value is TokenValueString vvalue) {
					ServiceAuthenticate = vvalue.Value;
					}
				break;
				}
			case "DeviceAuthenticate" : {
				if (value is TokenValueString vvalue) {
					DeviceAuthenticate = vvalue.Value;
					}
				break;
				}
			case "Expires" : {
				if (value is TokenValueDateTime vvalue) {
					Expires = vvalue.Value;
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
			case "PublicationId" : {
				return new TokenValueString (PublicationId);
				}
			case "ServiceAuthenticate" : {
				return new TokenValueString (ServiceAuthenticate);
				}
			case "DeviceAuthenticate" : {
				return new TokenValueString (DeviceAuthenticate);
				}
			case "Expires" : {
				return new TokenValueDateTime (Expires);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "PublicationId", new Property (typeof(TokenValueString), false)} ,
			{ "ServiceAuthenticate", new Property (typeof(TokenValueString), false)} ,
			{ "DeviceAuthenticate", new Property (typeof(TokenValueString), false)} ,
			{ "Expires", new Property (typeof(TokenValueDateTime), false)} 
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
	/// For future use, allows logging of operations and results	
	/// </summary>
public partial class ProcessResult : Message {
        /// <summary>
        /// </summary>

	public virtual bool?						Success  {get; set;}
        /// <summary>
        ///The error report code.
        /// </summary>

	public virtual string						ErrorReport  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Success" : {
				if (value is TokenValueBoolean vvalue) {
					Success = vvalue.Value;
					}
				break;
				}
			case "ErrorReport" : {
				if (value is TokenValueString vvalue) {
					ErrorReport = vvalue.Value;
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
			case "Success" : {
				return new TokenValueBoolean (Success);
				}
			case "ErrorReport" : {
				return new TokenValueString (ErrorReport);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Success", new Property (typeof(TokenValueBoolean), false)} ,
			{ "ErrorReport", new Property (typeof(TokenValueString), false)} 
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



