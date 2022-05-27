
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
//  This file was automatically generated at 27-May-22 7:23:20 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.971
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Udf", new MetaDataString(
				delegate (string _a) {  Udf = _a; },
				() => Udf) } ,
			{ "X509Certificate", new MetaDataBinary(
				delegate (byte[] _a) {  X509Certificate = _a; },
				() => X509Certificate) } ,
			{ "X509Chain", new MetaDataListBinary(
				delegate (List<byte[]> _a) {  X509Chain = _a; },
				() => X509Chain) } ,
			{ "X509CSR", new MetaDataBinary(
				delegate (byte[] _a) {  X509CSR = _a; },
				() => X509CSR) } ,
			{ "NotBefore", new MetaDataDateTime(
				delegate (DateTime? _a) {  NotBefore = _a; },
				() => NotBefore) } ,
			{ "NotOnOrAfter", new MetaDataDateTime(
				delegate (DateTime? _a) {  NotOnOrAfter = _a; },
				() => NotOnOrAfter) } ,
			{ "PublicParameters", new MetaDataStruct(
				delegate (object _a) {  PublicParameters = _a as Key; },
				() => PublicParameters,
				"Key", true)},
			{ "PrivateParameters", new MetaDataStruct(
				delegate (object _a) {  PrivateParameters = _a as Key; },
				() => PrivateParameters,
				"Key", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Udf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Udf", 1);
				_writer.WriteString (Udf);
			}
		if (X509Certificate != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("X509Certificate", 1);
				_writer.WriteBinary (X509Certificate);
			}
		if (X509Chain != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("X509Chain", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in X509Chain) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteBinary (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (X509CSR != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("X509CSR", 1);
				_writer.WriteBinary (X509CSR);
			}
		if (NotBefore != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NotBefore", 1);
				_writer.WriteDateTime (NotBefore);
			}
		if (NotOnOrAfter != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NotOnOrAfter", 1);
				_writer.WriteDateTime (NotOnOrAfter);
			}
		if (PublicParameters != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PublicParameters", 1);
				// expand this to a tagged structure
				//PublicParameters.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(PublicParameters._Tag, 1);
					bool firstinner = true;
					PublicParameters.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (PrivateParameters != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PrivateParameters", 1);
				// expand this to a tagged structure
				//PrivateParameters.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(PrivateParameters._Tag, 1);
					bool firstinner = true;
					PrivateParameters.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Udf" : {
				Udf = jsonReader.ReadString ();
				break;
				}
			case "X509Certificate" : {
				X509Certificate = jsonReader.ReadBinary ();
				break;
				}
			case "X509Chain" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				X509Chain = new List <byte[]> ();
				while (_Going) {
					byte[] _Item = jsonReader.ReadBinary ();
					X509Chain.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "X509CSR" : {
				X509CSR = jsonReader.ReadBinary ();
				break;
				}
			case "NotBefore" : {
				NotBefore = jsonReader.ReadDateTime ();
				break;
				}
			case "NotOnOrAfter" : {
				NotOnOrAfter = jsonReader.ReadDateTime ();
				break;
				}
			case "PublicParameters" : {
				PublicParameters = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "PrivateParameters" : {
				PrivateParameters = Key.FromJson (jsonReader, true) ;  // A tagged structure
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "PublicPrimary", new MetaDataStruct(
				delegate (object _a) {  PublicPrimary = _a as Key; },
				() => PublicPrimary,
				"Key", true)},
			{ "Share", new MetaDataStruct(
				delegate (object _a) {  Share = _a as Key; },
				() => Share,
				"Key", true)},
			{ "ServiceId", new MetaDataString(
				delegate (string _a) {  ServiceId = _a; },
				() => ServiceId) } ,
			{ "ServiceAddress", new MetaDataString(
				delegate (string _a) {  ServiceAddress = _a; },
				() => ServiceAddress) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (PublicPrimary != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PublicPrimary", 1);
				// expand this to a tagged structure
				//PublicPrimary.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(PublicPrimary._Tag, 1);
					bool firstinner = true;
					PublicPrimary.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (Share != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Share", 1);
				// expand this to a tagged structure
				//Share.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Share._Tag, 1);
					bool firstinner = true;
					Share.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (ServiceId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceId", 1);
				_writer.WriteString (ServiceId);
			}
		if (ServiceAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceAddress", 1);
				_writer.WriteString (ServiceAddress);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "PublicPrimary" : {
				PublicPrimary = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "Share" : {
				Share = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "ServiceId" : {
				ServiceId = jsonReader.ReadString ();
				break;
				}
			case "ServiceAddress" : {
				ServiceAddress = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "DeviceKeyUdf", new MetaDataString(
				delegate (string _a) {  DeviceKeyUdf = _a; },
				() => DeviceKeyUdf) } ,
			{ "PrivateSalt", new MetaDataStruct(
				delegate (object _a) {  PrivateSalt = _a as Key; },
				() => PrivateSalt,
				"Key", true)},
			{ "ServiceShare", new MetaDataStruct(
				delegate (object _a) {  ServiceShare = _a as Key; },
				() => ServiceShare,
				"Key", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (DeviceKeyUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DeviceKeyUdf", 1);
				_writer.WriteString (DeviceKeyUdf);
			}
		if (PrivateSalt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PrivateSalt", 1);
				// expand this to a tagged structure
				//PrivateSalt.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(PrivateSalt._Tag, 1);
					bool firstinner = true;
					PrivateSalt.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (ServiceShare != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceShare", 1);
				// expand this to a tagged structure
				//ServiceShare.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(ServiceShare._Tag, 1);
					bool firstinner = true;
					ServiceShare.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "DeviceKeyUdf" : {
				DeviceKeyUdf = jsonReader.ReadString ();
				break;
				}
			case "PrivateSalt" : {
				PrivateSalt = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "ServiceShare" : {
				ServiceShare = Key.FromJson (jsonReader, true) ;  // A tagged structure
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Names", new MetaDataListString(
				delegate (List<string> _a) {  Names = _a; },
				() => Names) } ,
			{ "Updated", new MetaDataDateTime(
				delegate (DateTime? _a) {  Updated = _a; },
				() => Updated) } ,
			{ "NotaryToken", new MetaDataString(
				delegate (string _a) {  NotaryToken = _a; },
				() => NotaryToken) } ,
			{ "Conditions", new MetaDataStruct(
				delegate (object _a) {  Conditions = _a as Condition; },
				() => Conditions,
				"Condition", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Names != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Names", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Names) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Updated != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Updated", 1);
				_writer.WriteDateTime (Updated);
			}
		if (NotaryToken != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NotaryToken", 1);
				_writer.WriteString (NotaryToken);
			}
		if (Conditions != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Conditions", 1);
				// expand this to a tagged structure
				//Conditions.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Conditions._Tag, 1);
					bool firstinner = true;
					Conditions.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Names" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Names = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Names.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Updated" : {
				Updated = jsonReader.ReadDateTime ();
				break;
				}
			case "NotaryToken" : {
				NotaryToken = jsonReader.ReadString ();
				break;
				}
			case "Conditions" : {
				Conditions = Condition.FromJson (jsonReader, true) ;  // A tagged structure
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
	/// Parent class from which all condition classes are derived.
	/// </summary>
abstract public partial class Condition : MeshItem {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ActivationKey", new MetaDataString(
				delegate (string _a) {  ActivationKey = _a; },
				() => ActivationKey) } ,
			{ "Entries", new MetaDataListStruct(
				delegate (object _a) {  Entries = _a as List<ActivationEntry>; },
				() => Entries,
				"ActivationEntry" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (ActivationKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ActivationKey", 1);
				_writer.WriteString (ActivationKey);
			}
		if (Entries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Entries", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Entries) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ActivationKey" : {
				ActivationKey = jsonReader.ReadString ();
				break;
				}
			case "Entries" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Entries = new List <ActivationEntry> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  ActivationEntry ();
					_Item.Deserialize (jsonReader);
					// var _Item = new ActivationEntry (jsonReader);
					Entries.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Resource", new MetaDataString(
				delegate (string _a) {  Resource = _a; },
				() => Resource) } ,
			{ "Key", new MetaDataStruct(
				delegate (object _a) {  Key = _a as KeyData; },
				() => Key,
				"KeyData" )} ,
			{ "ServiceId", new MetaDataString(
				delegate (string _a) {  ServiceId = _a; },
				() => ServiceId) } ,
			{ "ServiceAddress", new MetaDataString(
				delegate (string _a) {  ServiceAddress = _a; },
				() => ServiceAddress) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Resource != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Resource", 1);
				_writer.WriteString (Resource);
			}
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				Key.Serialize (_writer, false);
			}
		if (ServiceId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceId", 1);
				_writer.WriteString (ServiceId);
			}
		if (ServiceAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceAddress", 1);
				_writer.WriteString (ServiceAddress);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Resource" : {
				Resource = jsonReader.ReadString ();
				break;
				}
			case "Key" : {
				// An untagged structure
				Key = new KeyData ();
				Key.Deserialize (jsonReader);
 
				break;
				}
			case "ServiceId" : {
				ServiceId = jsonReader.ReadString ();
				break;
				}
			case "ServiceAddress" : {
				ServiceAddress = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Description", new MetaDataString(
				delegate (string _a) {  Description = _a; },
				() => Description) } ,
			{ "ProfileSignature", new MetaDataStruct(
				delegate (object _a) {  ProfileSignature = _a as KeyData; },
				() => ProfileSignature,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Description != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Description", 1);
				_writer.WriteString (Description);
			}
		if (ProfileSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileSignature", 1);
				ProfileSignature.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Description" : {
				Description = jsonReader.ReadString ();
				break;
				}
			case "ProfileSignature" : {
				// An untagged structure
				ProfileSignature = new KeyData ();
				ProfileSignature.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Encryption", new MetaDataStruct(
				delegate (object _a) {  Encryption = _a as KeyData; },
				() => Encryption,
				"KeyData" )} ,
			{ "Signature", new MetaDataStruct(
				delegate (object _a) {  Signature = _a as KeyData; },
				() => Signature,
				"KeyData" )} ,
			{ "Authentication", new MetaDataStruct(
				delegate (object _a) {  Authentication = _a as KeyData; },
				() => Authentication,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Profile)this).SerializeX(_writer, false, ref _first);
		if (Encryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Encryption", 1);
				Encryption.Serialize (_writer, false);
			}
		if (Signature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Signature", 1);
				Signature.Serialize (_writer, false);
			}
		if (Authentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Authentication", 1);
				Authentication.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Encryption" : {
				// An untagged structure
				Encryption = new KeyData ();
				Encryption.Deserialize (jsonReader);
 
				break;
				}
			case "Signature" : {
				// An untagged structure
				Signature = new KeyData ();
				Signature.Deserialize (jsonReader);
 
				break;
				}
			case "Authentication" : {
				// An untagged structure
				Authentication = new KeyData ();
				Authentication.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountAddress", new MetaDataString(
				delegate (string _a) {  AccountAddress = _a; },
				() => AccountAddress) } ,
			{ "ServiceUdf", new MetaDataString(
				delegate (string _a) {  ServiceUdf = _a; },
				() => ServiceUdf) } ,
			{ "EscrowEncryption", new MetaDataStruct(
				delegate (object _a) {  EscrowEncryption = _a as KeyData; },
				() => EscrowEncryption,
				"KeyData" )} ,
			{ "AdministratorSignature", new MetaDataStruct(
				delegate (object _a) {  AdministratorSignature = _a as KeyData; },
				() => AdministratorSignature,
				"KeyData" )} ,
			{ "CommonEncryption", new MetaDataStruct(
				delegate (object _a) {  CommonEncryption = _a as KeyData; },
				() => CommonEncryption,
				"KeyData" )} ,
			{ "CommonAuthentication", new MetaDataStruct(
				delegate (object _a) {  CommonAuthentication = _a as KeyData; },
				() => CommonAuthentication,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Profile)this).SerializeX(_writer, false, ref _first);
		if (AccountAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAddress", 1);
				_writer.WriteString (AccountAddress);
			}
		if (ServiceUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceUdf", 1);
				_writer.WriteString (ServiceUdf);
			}
		if (EscrowEncryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EscrowEncryption", 1);
				EscrowEncryption.Serialize (_writer, false);
			}
		if (AdministratorSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AdministratorSignature", 1);
				AdministratorSignature.Serialize (_writer, false);
			}
		if (CommonEncryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CommonEncryption", 1);
				CommonEncryption.Serialize (_writer, false);
			}
		if (CommonAuthentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CommonAuthentication", 1);
				CommonAuthentication.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountAddress" : {
				AccountAddress = jsonReader.ReadString ();
				break;
				}
			case "ServiceUdf" : {
				ServiceUdf = jsonReader.ReadString ();
				break;
				}
			case "EscrowEncryption" : {
				// An untagged structure
				EscrowEncryption = new KeyData ();
				EscrowEncryption.Deserialize (jsonReader);
 
				break;
				}
			case "AdministratorSignature" : {
				// An untagged structure
				AdministratorSignature = new KeyData ();
				AdministratorSignature.Deserialize (jsonReader);
 
				break;
				}
			case "CommonEncryption" : {
				// An untagged structure
				CommonEncryption = new KeyData ();
				CommonEncryption.Deserialize (jsonReader);
 
				break;
				}
			case "CommonAuthentication" : {
				// An untagged structure
				CommonAuthentication = new KeyData ();
				CommonAuthentication.Deserialize (jsonReader);
 
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
	/// Account assertion. This is signed by the service hosting the account.
	/// </summary>
public partial class ProfileUser : ProfileAccount {
        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

	public virtual KeyData						CommonSignature  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "CommonSignature", new MetaDataStruct(
				delegate (object _a) {  CommonSignature = _a as KeyData; },
				() => CommonSignature,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ProfileAccount)this).SerializeX(_writer, false, ref _first);
		if (CommonSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CommonSignature", 1);
				CommonSignature.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CommonSignature" : {
				// An untagged structure
				CommonSignature = new KeyData ();
				CommonSignature.Deserialize (jsonReader);
 
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
	/// Describes a group. Note that while a group is created by one person who
	/// becomes its first administrator, control of the group may pass to other
	/// administrators over time.
	/// </summary>
public partial class ProfileGroup : ProfileAccount {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ProfileAccount)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ServiceAuthentication", new MetaDataStruct(
				delegate (object _a) {  ServiceAuthentication = _a as KeyData; },
				() => ServiceAuthentication,
				"KeyData" )} ,
			{ "ServiceEncryption", new MetaDataStruct(
				delegate (object _a) {  ServiceEncryption = _a as KeyData; },
				() => ServiceEncryption,
				"KeyData" )} ,
			{ "ServiceSignature", new MetaDataStruct(
				delegate (object _a) {  ServiceSignature = _a as KeyData; },
				() => ServiceSignature,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Profile)this).SerializeX(_writer, false, ref _first);
		if (ServiceAuthentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceAuthentication", 1);
				ServiceAuthentication.Serialize (_writer, false);
			}
		if (ServiceEncryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceEncryption", 1);
				ServiceEncryption.Serialize (_writer, false);
			}
		if (ServiceSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceSignature", 1);
				ServiceSignature.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ServiceAuthentication" : {
				// An untagged structure
				ServiceAuthentication = new KeyData ();
				ServiceAuthentication.Deserialize (jsonReader);
 
				break;
				}
			case "ServiceEncryption" : {
				// An untagged structure
				ServiceEncryption = new KeyData ();
				ServiceEncryption.Deserialize (jsonReader);
 
				break;
				}
			case "ServiceSignature" : {
				// An untagged structure
				ServiceSignature = new KeyData ();
				ServiceSignature.Deserialize (jsonReader);
 
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
	/// Profile of a Mesh Host providing one or more Mesh Services.
	/// </summary>
public partial class ProfileHost : ProfileDevice {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ProfileDevice)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Subject", new MetaDataString(
				delegate (string _a) {  Subject = _a; },
				() => Subject) } ,
			{ "Authority", new MetaDataString(
				delegate (string _a) {  Authority = _a; },
				() => Authority) } ,
			{ "Authentication", new MetaDataStruct(
				delegate (object _a) {  Authentication = _a as KeyData; },
				() => Authentication,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Subject != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Subject", 1);
				_writer.WriteString (Subject);
			}
		if (Authority != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Authority", 1);
				_writer.WriteString (Authority);
			}
		if (Authentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Authentication", 1);
				Authentication.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Subject" : {
				Subject = jsonReader.ReadString ();
				break;
				}
			case "Authority" : {
				Authority = jsonReader.ReadString ();
				break;
				}
			case "Authentication" : {
				// An untagged structure
				Authentication = new KeyData ();
				Authentication.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Canonical", new MetaDataString(
				delegate (string _a) {  Canonical = _a; },
				() => Canonical) } ,
			{ "Display", new MetaDataString(
				delegate (string _a) {  Display = _a; },
				() => Display) } ,
			{ "ProfileUdf", new MetaDataString(
				delegate (string _a) {  ProfileUdf = _a; },
				() => ProfileUdf) } ,
			{ "Services", new MetaDataListStruct(
				delegate (object _a) {  Services = _a as List<NamedService>; },
				() => Services,
				"NamedService" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Canonical != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Canonical", 1);
				_writer.WriteString (Canonical);
			}
		if (Display != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Display", 1);
				_writer.WriteString (Display);
			}
		if (ProfileUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileUdf", 1);
				_writer.WriteString (ProfileUdf);
			}
		if (Services != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Services", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Services) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Canonical" : {
				Canonical = jsonReader.ReadString ();
				break;
				}
			case "Display" : {
				Display = jsonReader.ReadString ();
				break;
				}
			case "ProfileUdf" : {
				ProfileUdf = jsonReader.ReadString ();
				break;
				}
			case "Services" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Services = new List <NamedService> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  NamedService ();
					_Item.Deserialize (jsonReader);
					// var _Item = new NamedService (jsonReader);
					Services.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Callsign", new MetaDataString(
				delegate (string _a) {  Callsign = _a; },
				() => Callsign) } ,
			{ "ProfileUdf", new MetaDataString(
				delegate (string _a) {  ProfileUdf = _a; },
				() => ProfileUdf) } ,
			{ "SubjectNames", new MetaDataListString(
				delegate (List<string> _a) {  SubjectNames = _a; },
				() => SubjectNames) } ,
			{ "SubjectLogos", new MetaDataListString(
				delegate (List<string> _a) {  SubjectLogos = _a; },
				() => SubjectLogos) } ,
			{ "Issued", new MetaDataDateTime(
				delegate (DateTime? _a) {  Issued = _a; },
				() => Issued) } ,
			{ "Expires", new MetaDataDateTime(
				delegate (DateTime? _a) {  Expires = _a; },
				() => Expires) } ,
			{ "Policy", new MetaDataString(
				delegate (string _a) {  Policy = _a; },
				() => Policy) } ,
			{ "Practice", new MetaDataString(
				delegate (string _a) {  Practice = _a; },
				() => Practice) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Callsign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Callsign", 1);
				_writer.WriteString (Callsign);
			}
		if (ProfileUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileUdf", 1);
				_writer.WriteString (ProfileUdf);
			}
		if (SubjectNames != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SubjectNames", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in SubjectNames) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (SubjectLogos != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SubjectLogos", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in SubjectLogos) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Issued != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Issued", 1);
				_writer.WriteDateTime (Issued);
			}
		if (Expires != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Expires", 1);
				_writer.WriteDateTime (Expires);
			}
		if (Policy != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Policy", 1);
				_writer.WriteString (Policy);
			}
		if (Practice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Practice", 1);
				_writer.WriteString (Practice);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Callsign" : {
				Callsign = jsonReader.ReadString ();
				break;
				}
			case "ProfileUdf" : {
				ProfileUdf = jsonReader.ReadString ();
				break;
				}
			case "SubjectNames" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				SubjectNames = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					SubjectNames.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "SubjectLogos" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				SubjectLogos = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					SubjectLogos.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Issued" : {
				Issued = jsonReader.ReadDateTime ();
				break;
				}
			case "Expires" : {
				Expires = jsonReader.ReadDateTime ();
				break;
				}
			case "Policy" : {
				Policy = jsonReader.ReadString ();
				break;
				}
			case "Practice" : {
				Practice = jsonReader.ReadString ();
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
	/// Asserts that a profile is connected to an account address.
	/// Stripped down connection assertion
	/// </summary>
public partial class ConnectionStripped : Connection {
        /// <summary>
        ///To be removed
        /// </summary>

	public virtual string						Account  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Account", new MetaDataString(
				delegate (string _a) {  Account = _a; },
				() => Account) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Connection)this).SerializeX(_writer, false, ref _first);
		if (Account != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Account", 1);
				_writer.WriteString (Account);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Account" : {
				Account = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ProfileUdf", new MetaDataString(
				delegate (string _a) {  ProfileUdf = _a; },
				() => ProfileUdf) } ,
			{ "Callsign", new MetaDataStruct(
				delegate (object _a) {  Callsign = _a as CatalogedCallsign; },
				() => Callsign,
				"CatalogedCallsign" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Connection)this).SerializeX(_writer, false, ref _first);
		if (ProfileUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileUdf", 1);
				_writer.WriteString (ProfileUdf);
			}
		if (Callsign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Callsign", 1);
				Callsign.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ProfileUdf" : {
				ProfileUdf = jsonReader.ReadString ();
				break;
				}
			case "Callsign" : {
				// An untagged structure
				Callsign = new CatalogedCallsign ();
				Callsign.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Roles", new MetaDataListString(
				delegate (List<string> _a) {  Roles = _a; },
				() => Roles) } ,
			{ "Signature", new MetaDataStruct(
				delegate (object _a) {  Signature = _a as KeyData; },
				() => Signature,
				"KeyData" )} ,
			{ "Encryption", new MetaDataStruct(
				delegate (object _a) {  Encryption = _a as KeyData; },
				() => Encryption,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ConnectionService)this).SerializeX(_writer, false, ref _first);
		if (Roles != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Roles", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Roles) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Signature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Signature", 1);
				Signature.Serialize (_writer, false);
			}
		if (Encryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Encryption", 1);
				Encryption.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Roles" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Roles = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Roles.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Signature" : {
				// An untagged structure
				Signature = new KeyData ();
				Signature.Deserialize (jsonReader);
 
				break;
				}
			case "Encryption" : {
				// An untagged structure
				Encryption = new KeyData ();
				Encryption.Deserialize (jsonReader);
 
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
	/// Connection assertion stating that a particular device is 
	/// </summary>
public partial class ConnectionApplication : Connection {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Connection)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// Describes the connection of a member to a group.
	/// </summary>
public partial class ConnectionGroup : Connection {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Connection)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountAddess", new MetaDataString(
				delegate (string _a) {  AccountAddess = _a; },
				() => AccountAddess) } ,
			{ "HostAddresses", new MetaDataListString(
				delegate (List<string> _a) {  HostAddresses = _a; },
				() => HostAddresses) } ,
			{ "AccessEncrypt", new MetaDataStruct(
				delegate (object _a) {  AccessEncrypt = _a as KeyData; },
				() => AccessEncrypt,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (AccountAddess != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAddess", 1);
				_writer.WriteString (AccountAddess);
			}
		if (HostAddresses != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("HostAddresses", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in HostAddresses) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (AccessEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccessEncrypt", 1);
				AccessEncrypt.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountAddess" : {
				AccountAddess = jsonReader.ReadString ();
				break;
				}
			case "HostAddresses" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				HostAddresses = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					HostAddresses.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "AccessEncrypt" : {
				// An untagged structure
				AccessEncrypt = new KeyData ();
				AccessEncrypt.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ConnectionHost : Connection {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Connection)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// Contains activation data for device specific keys used in the context of a 
	/// Mesh account.
	/// </summary>
public partial class ActivationAccount : Activation {
        /// <summary>
        ///The UDF of the account
        /// </summary>

	public virtual string						AccountUdf  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountUdf", new MetaDataString(
				delegate (string _a) {  AccountUdf = _a; },
				() => AccountUdf) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Activation)this).SerializeX(_writer, false, ref _first);
		if (AccountUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountUdf", 1);
				_writer.WriteString (AccountUdf);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountUdf" : {
				AccountUdf = jsonReader.ReadString ();
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
	/// Contains activation data for device specific keys used in the context of a 
	/// Mesh host
	/// </summary>
public partial class ActivationHost : ActivationAccount {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationAccount)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ProfileSignature", new MetaDataStruct(
				delegate (object _a) {  ProfileSignature = _a as KeyData; },
				() => ProfileSignature,
				"KeyData" )} ,
			{ "AdministratorSignature", new MetaDataStruct(
				delegate (object _a) {  AdministratorSignature = _a as KeyData; },
				() => AdministratorSignature,
				"KeyData" )} ,
			{ "Encryption", new MetaDataStruct(
				delegate (object _a) {  Encryption = _a as KeyData; },
				() => Encryption,
				"KeyData" )} ,
			{ "Authentication", new MetaDataStruct(
				delegate (object _a) {  Authentication = _a as KeyData; },
				() => Authentication,
				"KeyData" )} ,
			{ "Signature", new MetaDataStruct(
				delegate (object _a) {  Signature = _a as KeyData; },
				() => Signature,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Activation)this).SerializeX(_writer, false, ref _first);
		if (ProfileSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileSignature", 1);
				ProfileSignature.Serialize (_writer, false);
			}
		if (AdministratorSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AdministratorSignature", 1);
				AdministratorSignature.Serialize (_writer, false);
			}
		if (Encryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Encryption", 1);
				Encryption.Serialize (_writer, false);
			}
		if (Authentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Authentication", 1);
				Authentication.Serialize (_writer, false);
			}
		if (Signature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Signature", 1);
				Signature.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ProfileSignature" : {
				// An untagged structure
				ProfileSignature = new KeyData ();
				ProfileSignature.Deserialize (jsonReader);
 
				break;
				}
			case "AdministratorSignature" : {
				// An untagged structure
				AdministratorSignature = new KeyData ();
				AdministratorSignature.Deserialize (jsonReader);
 
				break;
				}
			case "Encryption" : {
				// An untagged structure
				Encryption = new KeyData ();
				Encryption.Deserialize (jsonReader);
 
				break;
				}
			case "Authentication" : {
				// An untagged structure
				Authentication = new KeyData ();
				Authentication.Deserialize (jsonReader);
 
				break;
				}
			case "Signature" : {
				// An untagged structure
				Signature = new KeyData ();
				Signature.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ActivationApplication : Activation {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Activation)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ClientKey", new MetaDataStruct(
				delegate (object _a) {  ClientKey = _a as KeyData; },
				() => ClientKey,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationApplication)this).SerializeX(_writer, false, ref _first);
		if (ClientKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ClientKey", 1);
				ClientKey.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ClientKey" : {
				// An untagged structure
				ClientKey = new KeyData ();
				ClientKey.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "SmimeSign", new MetaDataStruct(
				delegate (object _a) {  SmimeSign = _a as KeyData; },
				() => SmimeSign,
				"KeyData" )} ,
			{ "SmimeEncrypt", new MetaDataStruct(
				delegate (object _a) {  SmimeEncrypt = _a as KeyData; },
				() => SmimeEncrypt,
				"KeyData" )} ,
			{ "OpenpgpSign", new MetaDataStruct(
				delegate (object _a) {  OpenpgpSign = _a as KeyData; },
				() => OpenpgpSign,
				"KeyData" )} ,
			{ "OpenpgpEncrypt", new MetaDataStruct(
				delegate (object _a) {  OpenpgpEncrypt = _a as KeyData; },
				() => OpenpgpEncrypt,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationApplication)this).SerializeX(_writer, false, ref _first);
		if (SmimeSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SmimeSign", 1);
				SmimeSign.Serialize (_writer, false);
			}
		if (SmimeEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SmimeEncrypt", 1);
				SmimeEncrypt.Serialize (_writer, false);
			}
		if (OpenpgpSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OpenpgpSign", 1);
				OpenpgpSign.Serialize (_writer, false);
			}
		if (OpenpgpEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OpenpgpEncrypt", 1);
				OpenpgpEncrypt.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "SmimeSign" : {
				// An untagged structure
				SmimeSign = new KeyData ();
				SmimeSign.Deserialize (jsonReader);
 
				break;
				}
			case "SmimeEncrypt" : {
				// An untagged structure
				SmimeEncrypt = new KeyData ();
				SmimeEncrypt.Deserialize (jsonReader);
 
				break;
				}
			case "OpenpgpSign" : {
				// An untagged structure
				OpenpgpSign = new KeyData ();
				OpenpgpSign.Deserialize (jsonReader);
 
				break;
				}
			case "OpenpgpEncrypt" : {
				// An untagged structure
				OpenpgpEncrypt = new KeyData ();
				OpenpgpEncrypt.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountEncryption", new MetaDataStruct(
				delegate (object _a) {  AccountEncryption = _a as KeyData; },
				() => AccountEncryption,
				"KeyData" )} ,
			{ "AdministratorSignature", new MetaDataStruct(
				delegate (object _a) {  AdministratorSignature = _a as KeyData; },
				() => AdministratorSignature,
				"KeyData" )} ,
			{ "AccountAuthentication", new MetaDataStruct(
				delegate (object _a) {  AccountAuthentication = _a as KeyData; },
				() => AccountAuthentication,
				"KeyData" )} ,
			{ "EnvelopedConnectionService", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionService = _a as Enveloped<ConnectionService>; },
				() => EnvelopedConnectionService,
				"Enveloped<ConnectionService>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationApplication)this).SerializeX(_writer, false, ref _first);
		if (AccountEncryption != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountEncryption", 1);
				AccountEncryption.Serialize (_writer, false);
			}
		if (AdministratorSignature != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AdministratorSignature", 1);
				AdministratorSignature.Serialize (_writer, false);
			}
		if (AccountAuthentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAuthentication", 1);
				AccountAuthentication.Serialize (_writer, false);
			}
		if (EnvelopedConnectionService != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionService", 1);
				EnvelopedConnectionService.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountEncryption" : {
				// An untagged structure
				AccountEncryption = new KeyData ();
				AccountEncryption.Deserialize (jsonReader);
 
				break;
				}
			case "AdministratorSignature" : {
				// An untagged structure
				AdministratorSignature = new KeyData ();
				AdministratorSignature.Deserialize (jsonReader);
 
				break;
				}
			case "AccountAuthentication" : {
				// An untagged structure
				AccountAuthentication = new KeyData ();
				AccountAuthentication.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedConnectionService" : {
				// An untagged structure
				EnvelopedConnectionService = new Enveloped<ConnectionService> ();
				EnvelopedConnectionService.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ActivationApplicationCallsign : ActivationApplication {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ActivationApplication)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
abstract public partial class ApplicationEntry : MeshItem {
        /// <summary>
        /// </summary>

	public virtual string						Identifier  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Identifier", new MetaDataString(
				delegate (string _a) {  Identifier = _a; },
				() => Identifier) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Identifier != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Identifier", 1);
				_writer.WriteString (Identifier);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Identifier" : {
				Identifier = jsonReader.ReadString ();
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
public partial class ApplicationEntrySsh : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationSsh>						EnvelopedActivation  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedActivation", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivation = _a as Enveloped<ActivationApplicationSsh>; },
				() => EnvelopedActivation,
				"Enveloped<ActivationApplicationSsh>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ApplicationEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedActivation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivation", 1);
				EnvelopedActivation.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedActivation" : {
				// An untagged structure
				EnvelopedActivation = new Enveloped<ActivationApplicationSsh> ();
				EnvelopedActivation.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ApplicationEntryGroup : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationGroup>						EnvelopedActivation  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedActivation", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivation = _a as Enveloped<ActivationApplicationGroup>; },
				() => EnvelopedActivation,
				"Enveloped<ActivationApplicationGroup>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ApplicationEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedActivation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivation", 1);
				EnvelopedActivation.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedActivation" : {
				// An untagged structure
				EnvelopedActivation = new Enveloped<ActivationApplicationGroup> ();
				EnvelopedActivation.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ApplicationEntryMail : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationMail>						EnvelopedActivation  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedActivation", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivation = _a as Enveloped<ActivationApplicationMail>; },
				() => EnvelopedActivation,
				"Enveloped<ActivationApplicationMail>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ApplicationEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedActivation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivation", 1);
				EnvelopedActivation.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedActivation" : {
				// An untagged structure
				EnvelopedActivation = new Enveloped<ActivationApplicationMail> ();
				EnvelopedActivation.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class ApplicationEntryCallsign : ApplicationEntry {
        /// <summary>
        /// </summary>

	public virtual Enveloped<ActivationApplicationCallsign>						EnvelopedActivation  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedActivation", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivation = _a as Enveloped<ActivationApplicationCallsign>; },
				() => EnvelopedActivation,
				"Enveloped<ActivationApplicationCallsign>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((ApplicationEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedActivation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivation", 1);
				EnvelopedActivation.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedActivation" : {
				// An untagged structure
				EnvelopedActivation = new Enveloped<ActivationApplicationCallsign> ();
				EnvelopedActivation.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "Local", new MetaDataString(
				delegate (string _a) {  Local = _a; },
				() => Local) } ,
			{ "Anchors", new MetaDataListStruct(
				delegate (object _a) {  Anchors = _a as List<Anchor>; },
				() => Anchors,
				"Anchor" )} ,
			{ "NetworkAddresses", new MetaDataListStruct(
				delegate (object _a) {  NetworkAddresses = _a as List<NetworkAddress>; },
				() => NetworkAddresses,
				"NetworkAddress" )} ,
			{ "Locations", new MetaDataListStruct(
				delegate (object _a) {  Locations = _a as List<Location>; },
				() => Locations,
				"Location" )} ,
			{ "Roles", new MetaDataListStruct(
				delegate (object _a) {  Roles = _a as List<Role>; },
				() => Roles,
				"Role" )} ,
			{ "Bookmark", new MetaDataListStruct(
				delegate (object _a) {  Bookmark = _a as List<Bookmark>; },
				() => Bookmark,
				"Bookmark" )} ,
			{ "Sources", new MetaDataListStruct(
				delegate (object _a) {  Sources = _a as List<TaggedSource>; },
				() => Sources,
				"TaggedSource" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Assertion)this).SerializeX(_writer, false, ref _first);
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (Local != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Local", 1);
				_writer.WriteString (Local);
			}
		if (Anchors != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Anchors", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Anchors) {
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

		if (NetworkAddresses != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NetworkAddresses", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in NetworkAddresses) {
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

		if (Locations != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Locations", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Locations) {
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

		if (Roles != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Roles", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Roles) {
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

		if (Bookmark != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Bookmark", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Bookmark) {
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

		if (Sources != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Sources", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Sources) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "Local" : {
				Local = jsonReader.ReadString ();
				break;
				}
			case "Anchors" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Anchors = new List <Anchor> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Anchor ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Anchor (jsonReader);
					Anchors.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "NetworkAddresses" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				NetworkAddresses = new List <NetworkAddress> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  NetworkAddress ();
					_Item.Deserialize (jsonReader);
					// var _Item = new NetworkAddress (jsonReader);
					NetworkAddresses.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Locations" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Locations = new List <Location> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Location ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Location (jsonReader);
					Locations.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Roles" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Roles = new List <Role> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Role ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Role (jsonReader);
					Roles.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Bookmark" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Bookmark = new List <Bookmark> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Bookmark ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Bookmark (jsonReader);
					Bookmark.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Sources" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Sources = new List <TaggedSource> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  TaggedSource ();
					_Item.Deserialize (jsonReader);
					// var _Item = new TaggedSource (jsonReader);
					Sources.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Udf", new MetaDataString(
				delegate (string _a) {  Udf = _a; },
				() => Udf) } ,
			{ "Validation", new MetaDataString(
				delegate (string _a) {  Validation = _a; },
				() => Validation) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Udf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Udf", 1);
				_writer.WriteString (Udf);
			}
		if (Validation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Validation", 1);
				_writer.WriteString (Validation);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Udf" : {
				Udf = jsonReader.ReadString ();
				break;
				}
			case "Validation" : {
				Validation = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "LocalName", new MetaDataString(
				delegate (string _a) {  LocalName = _a; },
				() => LocalName) } ,
			{ "Validation", new MetaDataString(
				delegate (string _a) {  Validation = _a; },
				() => Validation) } ,
			{ "BinarySource", new MetaDataBinary(
				delegate (byte[] _a) {  BinarySource = _a; },
				() => BinarySource) } ,
			{ "EnvelopedSource", new MetaDataStruct(
				delegate (object _a) {  EnvelopedSource = _a as Enveloped<Contact>; },
				() => EnvelopedSource,
				"Enveloped<Contact>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (LocalName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("LocalName", 1);
				_writer.WriteString (LocalName);
			}
		if (Validation != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Validation", 1);
				_writer.WriteString (Validation);
			}
		if (BinarySource != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("BinarySource", 1);
				_writer.WriteBinary (BinarySource);
			}
		if (EnvelopedSource != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedSource", 1);
				EnvelopedSource.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "LocalName" : {
				LocalName = jsonReader.ReadString ();
				break;
				}
			case "Validation" : {
				Validation = jsonReader.ReadString ();
				break;
				}
			case "BinarySource" : {
				BinarySource = jsonReader.ReadBinary ();
				break;
				}
			case "EnvelopedSource" : {
				// An untagged structure
				EnvelopedSource = new Enveloped<Contact> ();
				EnvelopedSource.Deserialize (jsonReader);
 
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
	/// Contact for a group, including encryption groups.
	/// </summary>
public partial class ContactGroup : Contact {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Contact)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// 
	/// </summary>
public partial class ContactPerson : Contact {
        /// <summary>
        ///List of person names in order of preference
        /// </summary>

	public virtual List<PersonName>				CommonNames  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "CommonNames", new MetaDataListStruct(
				delegate (object _a) {  CommonNames = _a as List<PersonName>; },
				() => CommonNames,
				"PersonName" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Contact)this).SerializeX(_writer, false, ref _first);
		if (CommonNames != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CommonNames", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CommonNames) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CommonNames" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CommonNames = new List <PersonName> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  PersonName ();
					_Item.Deserialize (jsonReader);
					// var _Item = new PersonName (jsonReader);
					CommonNames.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
	/// 		
	/// </summary>
public partial class ContactOrganization : Contact {
        /// <summary>
        ///List of person names in order of preference
        /// </summary>

	public virtual List<OrganizationName>				CommonNames  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "CommonNames", new MetaDataListStruct(
				delegate (object _a) {  CommonNames = _a as List<OrganizationName>; },
				() => CommonNames,
				"OrganizationName" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Contact)this).SerializeX(_writer, false, ref _first);
		if (CommonNames != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CommonNames", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in CommonNames) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "CommonNames" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				CommonNames = new List <OrganizationName> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  OrganizationName ();
					_Item.Deserialize (jsonReader);
					// var _Item = new OrganizationName (jsonReader);
					CommonNames.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Inactive", new MetaDataBoolean(
				delegate (bool? _a) {  Inactive = _a; },
				() => Inactive) } ,
			{ "RegisteredName", new MetaDataString(
				delegate (string _a) {  RegisteredName = _a; },
				() => RegisteredName) } ,
			{ "DBA", new MetaDataString(
				delegate (string _a) {  DBA = _a; },
				() => DBA) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Inactive != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Inactive", 1);
				_writer.WriteBoolean (Inactive);
			}
		if (RegisteredName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("RegisteredName", 1);
				_writer.WriteString (RegisteredName);
			}
		if (DBA != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DBA", 1);
				_writer.WriteString (DBA);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Inactive" : {
				Inactive = jsonReader.ReadBoolean ();
				break;
				}
			case "RegisteredName" : {
				RegisteredName = jsonReader.ReadString ();
				break;
				}
			case "DBA" : {
				DBA = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Inactive", new MetaDataBoolean(
				delegate (bool? _a) {  Inactive = _a; },
				() => Inactive) } ,
			{ "FullName", new MetaDataString(
				delegate (string _a) {  FullName = _a; },
				() => FullName) } ,
			{ "Prefix", new MetaDataString(
				delegate (string _a) {  Prefix = _a; },
				() => Prefix) } ,
			{ "First", new MetaDataString(
				delegate (string _a) {  First = _a; },
				() => First) } ,
			{ "Middle", new MetaDataListString(
				delegate (List<string> _a) {  Middle = _a; },
				() => Middle) } ,
			{ "Last", new MetaDataString(
				delegate (string _a) {  Last = _a; },
				() => Last) } ,
			{ "Suffix", new MetaDataString(
				delegate (string _a) {  Suffix = _a; },
				() => Suffix) } ,
			{ "PostNominal", new MetaDataString(
				delegate (string _a) {  PostNominal = _a; },
				() => PostNominal) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Inactive != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Inactive", 1);
				_writer.WriteBoolean (Inactive);
			}
		if (FullName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("FullName", 1);
				_writer.WriteString (FullName);
			}
		if (Prefix != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Prefix", 1);
				_writer.WriteString (Prefix);
			}
		if (First != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("First", 1);
				_writer.WriteString (First);
			}
		if (Middle != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Middle", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Middle) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Last != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Last", 1);
				_writer.WriteString (Last);
			}
		if (Suffix != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Suffix", 1);
				_writer.WriteString (Suffix);
			}
		if (PostNominal != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PostNominal", 1);
				_writer.WriteString (PostNominal);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Inactive" : {
				Inactive = jsonReader.ReadBoolean ();
				break;
				}
			case "FullName" : {
				FullName = jsonReader.ReadString ();
				break;
				}
			case "Prefix" : {
				Prefix = jsonReader.ReadString ();
				break;
				}
			case "First" : {
				First = jsonReader.ReadString ();
				break;
				}
			case "Middle" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Middle = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Middle.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Last" : {
				Last = jsonReader.ReadString ();
				break;
				}
			case "Suffix" : {
				Suffix = jsonReader.ReadString ();
				break;
				}
			case "PostNominal" : {
				PostNominal = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Inactive", new MetaDataBoolean(
				delegate (bool? _a) {  Inactive = _a; },
				() => Inactive) } ,
			{ "Address", new MetaDataString(
				delegate (string _a) {  Address = _a; },
				() => Address) } ,
			{ "NetworkCapability", new MetaDataListString(
				delegate (List<string> _a) {  NetworkCapability = _a; },
				() => NetworkCapability) } ,
			{ "EnvelopedProfileAccount", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileAccount = _a as Enveloped<ProfileAccount>; },
				() => EnvelopedProfileAccount,
				"Enveloped<ProfileAccount>" )} ,
			{ "Protocols", new MetaDataListStruct(
				delegate (object _a) {  Protocols = _a as List<NetworkProtocol>; },
				() => Protocols,
				"NetworkProtocol" )} ,
			{ "Capabilities", new MetaDataListStruct(
				delegate (object _a) {  Capabilities = _a as List<CryptographicCapability>; },
				() => Capabilities,
				"CryptographicCapability", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Inactive != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Inactive", 1);
				_writer.WriteBoolean (Inactive);
			}
		if (Address != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Address", 1);
				_writer.WriteString (Address);
			}
		if (NetworkCapability != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NetworkCapability", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in NetworkCapability) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (EnvelopedProfileAccount != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileAccount", 1);
				EnvelopedProfileAccount.Serialize (_writer, false);
			}
		if (Protocols != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Protocols", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Protocols) {
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

		if (Capabilities != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Capabilities", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Capabilities) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Inactive" : {
				Inactive = jsonReader.ReadBoolean ();
				break;
				}
			case "Address" : {
				Address = jsonReader.ReadString ();
				break;
				}
			case "NetworkCapability" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				NetworkCapability = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					NetworkCapability.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "EnvelopedProfileAccount" : {
				// An untagged structure
				EnvelopedProfileAccount = new Enveloped<ProfileAccount> ();
				EnvelopedProfileAccount.Deserialize (jsonReader);
 
				break;
				}
			case "Protocols" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Protocols = new List <NetworkProtocol> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  NetworkProtocol ();
					_Item.Deserialize (jsonReader);
					// var _Item = new NetworkProtocol (jsonReader);
					Protocols.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Capabilities" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Capabilities = new List <CryptographicCapability> ();
				while (_Going) {
					var _Item = CryptographicCapability.FromJson (jsonReader, true); // a tagged structure
					Capabilities.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Protocol", new MetaDataString(
				delegate (string _a) {  Protocol = _a; },
				() => Protocol) } ,
			{ "Capabilities", new MetaDataListStruct(
				delegate (object _a) {  Capabilities = _a as List<CryptographicCapability>; },
				() => Capabilities,
				"CryptographicCapability", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Protocol != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Protocol", 1);
				_writer.WriteString (Protocol);
			}
		if (Capabilities != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Capabilities", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Capabilities) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Protocol" : {
				Protocol = jsonReader.ReadString ();
				break;
				}
			case "Capabilities" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Capabilities = new List <CryptographicCapability> ();
				while (_Going) {
					var _Item = CryptographicCapability.FromJson (jsonReader, true); // a tagged structure
					Capabilities.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "OrganizationName", new MetaDataString(
				delegate (string _a) {  OrganizationName = _a; },
				() => OrganizationName) } ,
			{ "Titles", new MetaDataListString(
				delegate (List<string> _a) {  Titles = _a; },
				() => Titles) } ,
			{ "Locations", new MetaDataListStruct(
				delegate (object _a) {  Locations = _a as List<Location>; },
				() => Locations,
				"Location" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (OrganizationName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OrganizationName", 1);
				_writer.WriteString (OrganizationName);
			}
		if (Titles != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Titles", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Titles) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Locations != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Locations", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Locations) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "OrganizationName" : {
				OrganizationName = jsonReader.ReadString ();
				break;
				}
			case "Titles" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Titles = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Titles.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Locations" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Locations = new List <Location> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Location ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Location (jsonReader);
					Locations.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Appartment", new MetaDataString(
				delegate (string _a) {  Appartment = _a; },
				() => Appartment) } ,
			{ "Street", new MetaDataString(
				delegate (string _a) {  Street = _a; },
				() => Street) } ,
			{ "District", new MetaDataString(
				delegate (string _a) {  District = _a; },
				() => District) } ,
			{ "Locality", new MetaDataString(
				delegate (string _a) {  Locality = _a; },
				() => Locality) } ,
			{ "County", new MetaDataString(
				delegate (string _a) {  County = _a; },
				() => County) } ,
			{ "Postcode", new MetaDataString(
				delegate (string _a) {  Postcode = _a; },
				() => Postcode) } ,
			{ "Country", new MetaDataString(
				delegate (string _a) {  Country = _a; },
				() => Country) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Appartment != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Appartment", 1);
				_writer.WriteString (Appartment);
			}
		if (Street != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Street", 1);
				_writer.WriteString (Street);
			}
		if (District != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("District", 1);
				_writer.WriteString (District);
			}
		if (Locality != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Locality", 1);
				_writer.WriteString (Locality);
			}
		if (County != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("County", 1);
				_writer.WriteString (County);
			}
		if (Postcode != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Postcode", 1);
				_writer.WriteString (Postcode);
			}
		if (Country != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Country", 1);
				_writer.WriteString (Country);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Appartment" : {
				Appartment = jsonReader.ReadString ();
				break;
				}
			case "Street" : {
				Street = jsonReader.ReadString ();
				break;
				}
			case "District" : {
				District = jsonReader.ReadString ();
				break;
				}
			case "Locality" : {
				Locality = jsonReader.ReadString ();
				break;
				}
			case "County" : {
				County = jsonReader.ReadString ();
				break;
				}
			case "Postcode" : {
				Postcode = jsonReader.ReadString ();
				break;
				}
			case "Country" : {
				Country = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Uri", new MetaDataString(
				delegate (string _a) {  Uri = _a; },
				() => Uri) } ,
			{ "Title", new MetaDataString(
				delegate (string _a) {  Title = _a; },
				() => Title) } ,
			{ "Role", new MetaDataListString(
				delegate (List<string> _a) {  Role = _a; },
				() => Role) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Uri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uri", 1);
				_writer.WriteString (Uri);
			}
		if (Title != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Title", 1);
				_writer.WriteString (Title);
			}
		if (Role != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Role", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Role) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Uri" : {
				Uri = jsonReader.ReadString ();
				break;
				}
			case "Title" : {
				Title = jsonReader.ReadString ();
				break;
				}
			case "Role" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Role = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Role.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "MessageId", new MetaDataString(
				delegate (string _a) {  MessageId = _a; },
				() => MessageId) } ,
			{ "ResponseId", new MetaDataString(
				delegate (string _a) {  ResponseId = _a; },
				() => ResponseId) } ,
			{ "Relationship", new MetaDataString(
				delegate (string _a) {  Relationship = _a; },
				() => Relationship) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (MessageId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("MessageId", 1);
				_writer.WriteString (MessageId);
			}
		if (ResponseId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ResponseId", 1);
				_writer.WriteString (ResponseId);
			}
		if (Relationship != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Relationship", 1);
				_writer.WriteString (Relationship);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "MessageId" : {
				MessageId = jsonReader.ReadString ();
				break;
				}
			case "ResponseId" : {
				ResponseId = jsonReader.ReadString ();
				break;
				}
			case "Relationship" : {
				Relationship = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Key", new MetaDataString(
				delegate (string _a) {  Key = _a; },
				() => Key) } ,
			{ "Start", new MetaDataDateTime(
				delegate (DateTime? _a) {  Start = _a; },
				() => Start) } ,
			{ "Finish", new MetaDataDateTime(
				delegate (DateTime? _a) {  Finish = _a; },
				() => Finish) } ,
			{ "StartTravel", new MetaDataString(
				delegate (string _a) {  StartTravel = _a; },
				() => StartTravel) } ,
			{ "FinishTravel", new MetaDataString(
				delegate (string _a) {  FinishTravel = _a; },
				() => FinishTravel) } ,
			{ "TimeZone", new MetaDataString(
				delegate (string _a) {  TimeZone = _a; },
				() => TimeZone) } ,
			{ "Title", new MetaDataString(
				delegate (string _a) {  Title = _a; },
				() => Title) } ,
			{ "Description", new MetaDataString(
				delegate (string _a) {  Description = _a; },
				() => Description) } ,
			{ "Location", new MetaDataString(
				delegate (string _a) {  Location = _a; },
				() => Location) } ,
			{ "Trigger", new MetaDataListString(
				delegate (List<string> _a) {  Trigger = _a; },
				() => Trigger) } ,
			{ "Conference", new MetaDataListString(
				delegate (List<string> _a) {  Conference = _a; },
				() => Conference) } ,
			{ "Repeat", new MetaDataString(
				delegate (string _a) {  Repeat = _a; },
				() => Repeat) } ,
			{ "Busy", new MetaDataBoolean(
				delegate (bool? _a) {  Busy = _a; },
				() => Busy) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (Start != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Start", 1);
				_writer.WriteDateTime (Start);
			}
		if (Finish != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Finish", 1);
				_writer.WriteDateTime (Finish);
			}
		if (StartTravel != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("StartTravel", 1);
				_writer.WriteString (StartTravel);
			}
		if (FinishTravel != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("FinishTravel", 1);
				_writer.WriteString (FinishTravel);
			}
		if (TimeZone != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("TimeZone", 1);
				_writer.WriteString (TimeZone);
			}
		if (Title != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Title", 1);
				_writer.WriteString (Title);
			}
		if (Description != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Description", 1);
				_writer.WriteString (Description);
			}
		if (Location != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Location", 1);
				_writer.WriteString (Location);
			}
		if (Trigger != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Trigger", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Trigger) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Conference != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Conference", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Conference) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Repeat != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Repeat", 1);
				_writer.WriteString (Repeat);
			}
		if (Busy != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Busy", 1);
				_writer.WriteBoolean (Busy);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Start" : {
				Start = jsonReader.ReadDateTime ();
				break;
				}
			case "Finish" : {
				Finish = jsonReader.ReadDateTime ();
				break;
				}
			case "StartTravel" : {
				StartTravel = jsonReader.ReadString ();
				break;
				}
			case "FinishTravel" : {
				FinishTravel = jsonReader.ReadString ();
				break;
				}
			case "TimeZone" : {
				TimeZone = jsonReader.ReadString ();
				break;
				}
			case "Title" : {
				Title = jsonReader.ReadString ();
				break;
				}
			case "Description" : {
				Description = jsonReader.ReadString ();
				break;
				}
			case "Location" : {
				Location = jsonReader.ReadString ();
				break;
				}
			case "Trigger" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Trigger = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Trigger.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Conference" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Conference = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Conference.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Repeat" : {
				Repeat = jsonReader.ReadString ();
				break;
				}
			case "Busy" : {
				Busy = jsonReader.ReadBoolean ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Labels", new MetaDataListString(
				delegate (List<string> _a) {  Labels = _a; },
				() => Labels) } ,
			{ "LocalName", new MetaDataString(
				delegate (string _a) {  LocalName = _a; },
				() => LocalName) } ,
			{ "Uid", new MetaDataString(
				delegate (string _a) {  Uid = _a; },
				() => Uid) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Labels != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Labels", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Labels) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (LocalName != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("LocalName", 1);
				_writer.WriteString (LocalName);
			}
		if (Uid != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uid", 1);
				_writer.WriteString (Uid);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Labels" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Labels = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Labels.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "LocalName" : {
				LocalName = jsonReader.ReadString ();
				break;
				}
			case "Uid" : {
				Uid = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Updated", new MetaDataDateTime(
				delegate (DateTime? _a) {  Updated = _a; },
				() => Updated) } ,
			{ "Udf", new MetaDataString(
				delegate (string _a) {  Udf = _a; },
				() => Udf) } ,
			{ "DeviceUdf", new MetaDataString(
				delegate (string _a) {  DeviceUdf = _a; },
				() => DeviceUdf) } ,
			{ "SignatureUdf", new MetaDataString(
				delegate (string _a) {  SignatureUdf = _a; },
				() => SignatureUdf) } ,
			{ "EnvelopedProfileUser", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileUser = _a as Enveloped<ProfileAccount>; },
				() => EnvelopedProfileUser,
				"Enveloped<ProfileAccount>" )} ,
			{ "EnvelopedProfileDevice", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileDevice = _a as Enveloped<ProfileDevice>; },
				() => EnvelopedProfileDevice,
				"Enveloped<ProfileDevice>" )} ,
			{ "EnvelopedConnectionService", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionService = _a as Enveloped<ConnectionService>; },
				() => EnvelopedConnectionService,
				"Enveloped<ConnectionService>" )} ,
			{ "EnvelopedConnectionDevice", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionDevice = _a as Enveloped<ConnectionDevice>; },
				() => EnvelopedConnectionDevice,
				"Enveloped<ConnectionDevice>" )} ,
			{ "EnvelopedActivationAccount", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivationAccount = _a as Enveloped<ActivationAccount>; },
				() => EnvelopedActivationAccount,
				"Enveloped<ActivationAccount>" )} ,
			{ "EnvelopedActivationCommon", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivationCommon = _a as Enveloped<ActivationCommon>; },
				() => EnvelopedActivationCommon,
				"Enveloped<ActivationCommon>" )} ,
			{ "ApplicationEntries", new MetaDataListStruct(
				delegate (object _a) {  ApplicationEntries = _a as List<ApplicationEntry>; },
				() => ApplicationEntries,
				"ApplicationEntry", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Updated != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Updated", 1);
				_writer.WriteDateTime (Updated);
			}
		if (Udf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Udf", 1);
				_writer.WriteString (Udf);
			}
		if (DeviceUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DeviceUdf", 1);
				_writer.WriteString (DeviceUdf);
			}
		if (SignatureUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SignatureUdf", 1);
				_writer.WriteString (SignatureUdf);
			}
		if (EnvelopedProfileUser != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileUser", 1);
				EnvelopedProfileUser.Serialize (_writer, false);
			}
		if (EnvelopedProfileDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileDevice", 1);
				EnvelopedProfileDevice.Serialize (_writer, false);
			}
		if (EnvelopedConnectionService != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionService", 1);
				EnvelopedConnectionService.Serialize (_writer, false);
			}
		if (EnvelopedConnectionDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionDevice", 1);
				EnvelopedConnectionDevice.Serialize (_writer, false);
			}
		if (EnvelopedActivationAccount != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivationAccount", 1);
				EnvelopedActivationAccount.Serialize (_writer, false);
			}
		if (EnvelopedActivationCommon != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivationCommon", 1);
				EnvelopedActivationCommon.Serialize (_writer, false);
			}
		if (ApplicationEntries != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ApplicationEntries", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in ApplicationEntries) {
				_writer.WriteArraySeparator (ref _firstarray);
                _writer.WriteObjectStart();
                _writer.WriteToken(_index._Tag, 1);
				bool firstinner = true;
				_index.Serialize (_writer, true, ref firstinner);
                _writer.WriteObjectEnd();
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Updated" : {
				Updated = jsonReader.ReadDateTime ();
				break;
				}
			case "Udf" : {
				Udf = jsonReader.ReadString ();
				break;
				}
			case "DeviceUdf" : {
				DeviceUdf = jsonReader.ReadString ();
				break;
				}
			case "SignatureUdf" : {
				SignatureUdf = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedProfileUser" : {
				// An untagged structure
				EnvelopedProfileUser = new Enveloped<ProfileAccount> ();
				EnvelopedProfileUser.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedProfileDevice" : {
				// An untagged structure
				EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
				EnvelopedProfileDevice.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedConnectionService" : {
				// An untagged structure
				EnvelopedConnectionService = new Enveloped<ConnectionService> ();
				EnvelopedConnectionService.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedConnectionDevice" : {
				// An untagged structure
				EnvelopedConnectionDevice = new Enveloped<ConnectionDevice> ();
				EnvelopedConnectionDevice.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedActivationAccount" : {
				// An untagged structure
				EnvelopedActivationAccount = new Enveloped<ActivationAccount> ();
				EnvelopedActivationAccount.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedActivationCommon" : {
				// An untagged structure
				EnvelopedActivationCommon = new Enveloped<ActivationCommon> ();
				EnvelopedActivationCommon.Deserialize (jsonReader);
 
				break;
				}
			case "ApplicationEntries" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				ApplicationEntries = new List <ApplicationEntry> ();
				while (_Going) {
					var _Item = ApplicationEntry.FromJson (jsonReader, true); // a tagged structure
					ApplicationEntries.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "Authenticator", new MetaDataString(
				delegate (string _a) {  Authenticator = _a; },
				() => Authenticator) } ,
			{ "EnvelopedData", new MetaDataStruct(
				delegate (object _a) {  EnvelopedData = _a as DareEnvelope; },
				() => EnvelopedData,
				"DareEnvelope" )} ,
			{ "NotOnOrAfter", new MetaDataDateTime(
				delegate (DateTime? _a) {  NotOnOrAfter = _a; },
				() => NotOnOrAfter) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (Authenticator != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Authenticator", 1);
				_writer.WriteString (Authenticator);
			}
		if (EnvelopedData != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedData", 1);
				EnvelopedData.Serialize (_writer, false);
			}
		if (NotOnOrAfter != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("NotOnOrAfter", 1);
				_writer.WriteDateTime (NotOnOrAfter);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "Authenticator" : {
				Authenticator = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedData" : {
				// An untagged structure
				EnvelopedData = new DareEnvelope ();
				EnvelopedData.Deserialize (jsonReader);
 
				break;
				}
			case "NotOnOrAfter" : {
				NotOnOrAfter = jsonReader.ReadDateTime ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Protocol", new MetaDataString(
				delegate (string _a) {  Protocol = _a; },
				() => Protocol) } ,
			{ "Service", new MetaDataString(
				delegate (string _a) {  Service = _a; },
				() => Service) } ,
			{ "Username", new MetaDataString(
				delegate (string _a) {  Username = _a; },
				() => Username) } ,
			{ "Password", new MetaDataString(
				delegate (string _a) {  Password = _a; },
				() => Password) } ,
			{ "ClientAuthentication", new MetaDataListStruct(
				delegate (object _a) {  ClientAuthentication = _a as List<KeyData>; },
				() => ClientAuthentication,
				"KeyData" )} ,
			{ "HostAuthentication", new MetaDataListStruct(
				delegate (object _a) {  HostAuthentication = _a as List<KeyData>; },
				() => HostAuthentication,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Protocol != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Protocol", 1);
				_writer.WriteString (Protocol);
			}
		if (Service != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Service", 1);
				_writer.WriteString (Service);
			}
		if (Username != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Username", 1);
				_writer.WriteString (Username);
			}
		if (Password != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Password", 1);
				_writer.WriteString (Password);
			}
		if (ClientAuthentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ClientAuthentication", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in ClientAuthentication) {
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

		if (HostAuthentication != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("HostAuthentication", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in HostAuthentication) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Protocol" : {
				Protocol = jsonReader.ReadString ();
				break;
				}
			case "Service" : {
				Service = jsonReader.ReadString ();
				break;
				}
			case "Username" : {
				Username = jsonReader.ReadString ();
				break;
				}
			case "Password" : {
				Password = jsonReader.ReadString ();
				break;
				}
			case "ClientAuthentication" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				ClientAuthentication = new List <KeyData> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  KeyData ();
					_Item.Deserialize (jsonReader);
					// var _Item = new KeyData (jsonReader);
					ClientAuthentication.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "HostAuthentication" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				HostAuthentication = new List <KeyData> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  KeyData ();
					_Item.Deserialize (jsonReader);
					// var _Item = new KeyData (jsonReader);
					HostAuthentication.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
	/// </summary>
public partial class CatalogedApplicationSsh : CatalogedApplication {
        /// <summary>
        ///The S/Mime encryption key
        /// </summary>

	public virtual KeyData						ClientKey  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ClientKey", new MetaDataStruct(
				delegate (object _a) {  ClientKey = _a as KeyData; },
				() => ClientKey,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
		if (ClientKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ClientKey", 1);
				ClientKey.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ClientKey" : {
				// An untagged structure
				ClientKey = new KeyData ();
				ClientKey.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Protocol", new MetaDataString(
				delegate (string _a) {  Protocol = _a; },
				() => Protocol) } ,
			{ "Service", new MetaDataString(
				delegate (string _a) {  Service = _a; },
				() => Service) } ,
			{ "Username", new MetaDataString(
				delegate (string _a) {  Username = _a; },
				() => Username) } ,
			{ "Password", new MetaDataString(
				delegate (string _a) {  Password = _a; },
				() => Password) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Protocol != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Protocol", 1);
				_writer.WriteString (Protocol);
			}
		if (Service != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Service", 1);
				_writer.WriteString (Service);
			}
		if (Username != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Username", 1);
				_writer.WriteString (Username);
			}
		if (Password != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Password", 1);
				_writer.WriteString (Password);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Protocol" : {
				Protocol = jsonReader.ReadString ();
				break;
				}
			case "Service" : {
				Service = jsonReader.ReadString ();
				break;
				}
			case "Username" : {
				Username = jsonReader.ReadString ();
				break;
				}
			case "Password" : {
				Password = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Key", new MetaDataString(
				delegate (string _a) {  Key = _a; },
				() => Key) } ,
			{ "Self", new MetaDataBoolean(
				delegate (bool? _a) {  Self = _a; },
				() => Self) } ,
			{ "Contact", new MetaDataStruct(
				delegate (object _a) {  Contact = _a as Contact; },
				() => Contact,
				"Contact", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (Self != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Self", 1);
				_writer.WriteBoolean (Self);
			}
		if (Contact != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Contact", 1);
				// expand this to a tagged structure
				//Contact.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Contact._Tag, 1);
					bool firstinner = true;
					Contact.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Self" : {
				Self = jsonReader.ReadBoolean ();
				break;
				}
			case "Contact" : {
				Contact = Contact.FromJson (jsonReader, true) ;  // A tagged structure
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
	/// 
	/// </summary>
public partial class CatalogedAccess : CatalogedEntry {
        /// <summary>
        ///The cataloged capability.
        /// </summary>

	public virtual Capability						Capability  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Capability", new MetaDataStruct(
				delegate (object _a) {  Capability = _a as Capability; },
				() => Capability,
				"Capability", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Capability != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Capability", 1);
				// expand this to a tagged structure
				//Capability.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Capability._Tag, 1);
					bool firstinner = true;
					Capability.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Capability" : {
				Capability = Capability.FromJson (jsonReader, true) ;  // A tagged structure
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Id", new MetaDataString(
				delegate (string _a) {  Id = _a; },
				() => Id) } ,
			{ "Active", new MetaDataBoolean(
				delegate (bool? _a) {  Active = _a; },
				() => Active) } ,
			{ "Issued", new MetaDataInteger32(
				delegate (int? _a) {  Issued = _a; },
				() => Issued) } ,
			{ "Mode", new MetaDataString(
				delegate (string _a) {  Mode = _a; },
				() => Mode) } ,
			{ "Udf", new MetaDataString(
				delegate (string _a) {  Udf = _a; },
				() => Udf) } ,
			{ "Witness", new MetaDataString(
				delegate (string _a) {  Witness = _a; },
				() => Witness) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Id != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Id", 1);
				_writer.WriteString (Id);
			}
		if (Active != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Active", 1);
				_writer.WriteBoolean (Active);
			}
		if (Issued != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Issued", 1);
				_writer.WriteInteger32 (Issued);
			}
		if (Mode != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Mode", 1);
				_writer.WriteString (Mode);
			}
		if (Udf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Udf", 1);
				_writer.WriteString (Udf);
			}
		if (Witness != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Witness", 1);
				_writer.WriteString (Witness);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Id" : {
				Id = jsonReader.ReadString ();
				break;
				}
			case "Active" : {
				Active = jsonReader.ReadBoolean ();
				break;
				}
			case "Issued" : {
				Issued = jsonReader.ReadInteger32 ();
				break;
				}
			case "Mode" : {
				Mode = jsonReader.ReadString ();
				break;
				}
			case "Udf" : {
				Udf = jsonReader.ReadString ();
				break;
				}
			case "Witness" : {
				Witness = jsonReader.ReadString ();
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
public partial class NullCapability : Capability {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Capability)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Rights", new MetaDataListString(
				delegate (List<string> _a) {  Rights = _a; },
				() => Rights) } ,
			{ "EnvelopedCatalogedDevice", new MetaDataStruct(
				delegate (object _a) {  EnvelopedCatalogedDevice = _a as Enveloped<CatalogedDevice>; },
				() => EnvelopedCatalogedDevice,
				"Enveloped<CatalogedDevice>" )} ,
			{ "CatalogedDeviceDigest", new MetaDataString(
				delegate (string _a) {  CatalogedDeviceDigest = _a; },
				() => CatalogedDeviceDigest) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Capability)this).SerializeX(_writer, false, ref _first);
		if (Rights != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Rights", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Rights) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (EnvelopedCatalogedDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedCatalogedDevice", 1);
				EnvelopedCatalogedDevice.Serialize (_writer, false);
			}
		if (CatalogedDeviceDigest != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedDeviceDigest", 1);
				_writer.WriteString (CatalogedDeviceDigest);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Rights" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Rights = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Rights.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "EnvelopedCatalogedDevice" : {
				// An untagged structure
				EnvelopedCatalogedDevice = new Enveloped<CatalogedDevice> ();
				EnvelopedCatalogedDevice.Deserialize (jsonReader);
 
				break;
				}
			case "CatalogedDeviceDigest" : {
				CatalogedDeviceDigest = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Identifier", new MetaDataString(
				delegate (string _a) {  Identifier = _a; },
				() => Identifier) } ,
			{ "Digest", new MetaDataString(
				delegate (string _a) {  Digest = _a; },
				() => Digest) } ,
			{ "Data", new MetaDataBinary(
				delegate (byte[] _a) {  Data = _a; },
				() => Data) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Capability)this).SerializeX(_writer, false, ref _first);
		if (Identifier != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Identifier", 1);
				_writer.WriteString (Identifier);
			}
		if (Digest != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Digest", 1);
				_writer.WriteString (Digest);
			}
		if (Data != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Data", 1);
				_writer.WriteBinary (Data);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Identifier" : {
				Identifier = jsonReader.ReadString ();
				break;
				}
			case "Digest" : {
				Digest = jsonReader.ReadString ();
				break;
				}
			case "Data" : {
				Data = jsonReader.ReadBinary ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "KeyData", new MetaDataStruct(
				delegate (object _a) {  KeyData = _a as KeyData; },
				() => KeyData,
				"KeyData" )} ,
			{ "GranteeAccount", new MetaDataString(
				delegate (string _a) {  GranteeAccount = _a; },
				() => GranteeAccount) } ,
			{ "GranteeUdf", new MetaDataString(
				delegate (string _a) {  GranteeUdf = _a; },
				() => GranteeUdf) } ,
			{ "EnvelopedKeyShare", new MetaDataStruct(
				delegate (object _a) {  EnvelopedKeyShare = _a as Enveloped<KeyData>; },
				() => EnvelopedKeyShare,
				"Enveloped<KeyData>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Capability)this).SerializeX(_writer, false, ref _first);
		if (KeyData != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("KeyData", 1);
				KeyData.Serialize (_writer, false);
			}
		if (GranteeAccount != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("GranteeAccount", 1);
				_writer.WriteString (GranteeAccount);
			}
		if (GranteeUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("GranteeUdf", 1);
				_writer.WriteString (GranteeUdf);
			}
		if (EnvelopedKeyShare != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedKeyShare", 1);
				EnvelopedKeyShare.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "KeyData" : {
				// An untagged structure
				KeyData = new KeyData ();
				KeyData.Deserialize (jsonReader);
 
				break;
				}
			case "GranteeAccount" : {
				GranteeAccount = jsonReader.ReadString ();
				break;
				}
			case "GranteeUdf" : {
				GranteeUdf = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedKeyShare" : {
				// An untagged structure
				EnvelopedKeyShare = new Enveloped<KeyData> ();
				EnvelopedKeyShare.Deserialize (jsonReader);
 
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
	/// The corresponding key is a decryption key
	/// </summary>
public partial class CapabilityDecrypt : CryptographicCapability {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CryptographicCapability)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// The corresponding key is an encryption key
	/// </summary>
public partial class CapabilityDecryptPartial : CapabilityDecrypt {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CapabilityDecrypt)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// The corresponding key is an encryption key
	/// </summary>
public partial class CapabilityDecryptServiced : CapabilityDecrypt {
        /// <summary>
        ///UDF of trust root under which request to use a serviced capability must be 
        ///authorized. [Only present for a serviced capability]
        /// </summary>

	public virtual string						AuthenticationId  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AuthenticationId", new MetaDataString(
				delegate (string _a) {  AuthenticationId = _a; },
				() => AuthenticationId) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CapabilityDecrypt)this).SerializeX(_writer, false, ref _first);
		if (AuthenticationId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AuthenticationId", 1);
				_writer.WriteString (AuthenticationId);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AuthenticationId" : {
				AuthenticationId = jsonReader.ReadString ();
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
	/// The corresponding key is an administration key
	/// </summary>
public partial class CapabilitySign : CryptographicCapability {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CryptographicCapability)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// The corresponding key is a key that may be used to generate key shares.
	/// </summary>
public partial class CapabilityKeyGenerate : CryptographicCapability {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CryptographicCapability)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
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
	/// The corresponding key is a decryption key to be used in accordance 
	/// with the Micali Fair Electronic Exchange with Invisible Trusted Parties
	/// protocol.
	/// </summary>
public partial class CapabilityFairExchange : CryptographicCapability {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CryptographicCapability)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Canonical", new MetaDataString(
				delegate (string _a) {  Canonical = _a; },
				() => Canonical) } ,
			{ "ProfileUdf", new MetaDataString(
				delegate (string _a) {  ProfileUdf = _a; },
				() => ProfileUdf) } ,
			{ "EnvelopedCallsignBinding", new MetaDataStruct(
				delegate (object _a) {  EnvelopedCallsignBinding = _a as Enveloped<CallsignBinding>; },
				() => EnvelopedCallsignBinding,
				"Enveloped<CallsignBinding>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
		if (Canonical != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Canonical", 1);
				_writer.WriteString (Canonical);
			}
		if (ProfileUdf != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ProfileUdf", 1);
				_writer.WriteString (ProfileUdf);
			}
		if (EnvelopedCallsignBinding != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedCallsignBinding", 1);
				EnvelopedCallsignBinding.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Canonical" : {
				Canonical = jsonReader.ReadString ();
				break;
				}
			case "ProfileUdf" : {
				ProfileUdf = jsonReader.ReadString ();
				break;
				}
			case "EnvelopedCallsignBinding" : {
				// An untagged structure
				EnvelopedCallsignBinding = new Enveloped<CallsignBinding> ();
				EnvelopedCallsignBinding.Deserialize (jsonReader);
 
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
        ///The service endpoint. This MAY be specified as a callsign (@alice),
        ///a DNS address (example.com), an IP address (10.0.0.1) or a fully
        ///qualified URI.
        /// </summary>

	public virtual List<string>				Endpoint  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Prefix", new MetaDataString(
				delegate (string _a) {  Prefix = _a; },
				() => Prefix) } ,
			{ "Mapping", new MetaDataString(
				delegate (string _a) {  Mapping = _a; },
				() => Mapping) } ,
			{ "Endpoint", new MetaDataListString(
				delegate (List<string> _a) {  Endpoint = _a; },
				() => Endpoint) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (Prefix != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Prefix", 1);
				_writer.WriteString (Prefix);
			}
		if (Mapping != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Mapping", 1);
				_writer.WriteString (Mapping);
			}
		if (Endpoint != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Endpoint", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Endpoint) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Prefix" : {
				Prefix = jsonReader.ReadString ();
				break;
				}
			case "Mapping" : {
				Mapping = jsonReader.ReadString ();
				break;
				}
			case "Endpoint" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Endpoint = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Endpoint.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Uri", new MetaDataString(
				delegate (string _a) {  Uri = _a; },
				() => Uri) } ,
			{ "Title", new MetaDataString(
				delegate (string _a) {  Title = _a; },
				() => Title) } ,
			{ "Comments", new MetaDataListString(
				delegate (List<string> _a) {  Comments = _a; },
				() => Comments) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Uri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Uri", 1);
				_writer.WriteString (Uri);
			}
		if (Title != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Title", 1);
				_writer.WriteString (Title);
			}
		if (Comments != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Comments", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Comments) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Uri" : {
				Uri = jsonReader.ReadString ();
				break;
				}
			case "Title" : {
				Title = jsonReader.ReadString ();
				break;
				}
			case "Comments" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Comments = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Comments.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedTask", new MetaDataStruct(
				delegate (object _a) {  EnvelopedTask = _a as Enveloped<Engagement>; },
				() => EnvelopedTask,
				"Enveloped<Engagement>" )} ,
			{ "Title", new MetaDataString(
				delegate (string _a) {  Title = _a; },
				() => Title) } ,
			{ "Key", new MetaDataString(
				delegate (string _a) {  Key = _a; },
				() => Key) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedTask != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedTask", 1);
				EnvelopedTask.Serialize (_writer, false);
			}
		if (Title != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Title", 1);
				_writer.WriteString (Title);
			}
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedTask" : {
				// An untagged structure
				EnvelopedTask = new Enveloped<Engagement> ();
				EnvelopedTask.Deserialize (jsonReader);
 
				break;
				}
			case "Title" : {
				Title = jsonReader.ReadString ();
				break;
				}
			case "Key" : {
				Key = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Default", new MetaDataInteger32(
				delegate (int? _a) {  Default = _a; },
				() => Default) } ,
			{ "Key", new MetaDataString(
				delegate (string _a) {  Key = _a; },
				() => Key) } ,
			{ "Grant", new MetaDataListString(
				delegate (List<string> _a) {  Grant = _a; },
				() => Grant) } ,
			{ "Deny", new MetaDataListString(
				delegate (List<string> _a) {  Deny = _a; },
				() => Deny) } ,
			{ "EnvelopedCapabilities", new MetaDataListStruct(
				delegate (object _a) {  EnvelopedCapabilities = _a as List<DareEnvelope>; },
				() => EnvelopedCapabilities,
				"DareEnvelope" )} ,
			{ "EnvelopedEscrow", new MetaDataListStruct(
				delegate (object _a) {  EnvelopedEscrow = _a as List<Enveloped<KeyData>>; },
				() => EnvelopedEscrow,
				"Enveloped<KeyData>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (Default != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Default", 1);
				_writer.WriteInteger32 (Default);
			}
		if (Key != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Key", 1);
				_writer.WriteString (Key);
			}
		if (Grant != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Grant", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Grant) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (Deny != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Deny", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Deny) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
				}
			_writer.WriteArrayEnd ();
			}

		if (EnvelopedCapabilities != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedCapabilities", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in EnvelopedCapabilities) {
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

		if (EnvelopedEscrow != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedEscrow", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in EnvelopedEscrow) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Default" : {
				Default = jsonReader.ReadInteger32 ();
				break;
				}
			case "Key" : {
				Key = jsonReader.ReadString ();
				break;
				}
			case "Grant" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Grant = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Grant.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "Deny" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Deny = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Deny.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "EnvelopedCapabilities" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				EnvelopedCapabilities = new List <DareEnvelope> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  DareEnvelope ();
					_Item.Deserialize (jsonReader);
					// var _Item = new DareEnvelope (jsonReader);
					EnvelopedCapabilities.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
				break;
				}
			case "EnvelopedEscrow" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				EnvelopedEscrow = new List <Enveloped<KeyData>> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Enveloped<KeyData> ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Enveloped<KeyData> (jsonReader);
					EnvelopedEscrow.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ContactAddress", new MetaDataString(
				delegate (string _a) {  ContactAddress = _a; },
				() => ContactAddress) } ,
			{ "MemberCapabilityId", new MetaDataString(
				delegate (string _a) {  MemberCapabilityId = _a; },
				() => MemberCapabilityId) } ,
			{ "ServiceCapabilityId", new MetaDataString(
				delegate (string _a) {  ServiceCapabilityId = _a; },
				() => ServiceCapabilityId) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
		if (ContactAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ContactAddress", 1);
				_writer.WriteString (ContactAddress);
			}
		if (MemberCapabilityId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("MemberCapabilityId", 1);
				_writer.WriteString (MemberCapabilityId);
			}
		if (ServiceCapabilityId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceCapabilityId", 1);
				_writer.WriteString (ServiceCapabilityId);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ContactAddress" : {
				ContactAddress = jsonReader.ReadString ();
				break;
				}
			case "MemberCapabilityId" : {
				MemberCapabilityId = jsonReader.ReadString ();
				break;
				}
			case "ServiceCapabilityId" : {
				ServiceCapabilityId = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedConnectionAddress", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionAddress = _a as Enveloped<ConnectionStripped>; },
				() => EnvelopedConnectionAddress,
				"Enveloped<ConnectionStripped>" )} ,
			{ "EnvelopedProfileGroup", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileGroup = _a as Enveloped<ProfileAccount>; },
				() => EnvelopedProfileGroup,
				"Enveloped<ProfileAccount>" )} ,
			{ "EnvelopedActivationCommon", new MetaDataStruct(
				delegate (object _a) {  EnvelopedActivationCommon = _a as Enveloped<ActivationCommon>; },
				() => EnvelopedActivationCommon,
				"Enveloped<ActivationCommon>" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedConnectionAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionAddress", 1);
				EnvelopedConnectionAddress.Serialize (_writer, false);
			}
		if (EnvelopedProfileGroup != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileGroup", 1);
				EnvelopedProfileGroup.Serialize (_writer, false);
			}
		if (EnvelopedActivationCommon != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedActivationCommon", 1);
				EnvelopedActivationCommon.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedConnectionAddress" : {
				// An untagged structure
				EnvelopedConnectionAddress = new Enveloped<ConnectionStripped> ();
				EnvelopedConnectionAddress.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedProfileGroup" : {
				// An untagged structure
				EnvelopedProfileGroup = new Enveloped<ProfileAccount> ();
				EnvelopedProfileGroup.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedActivationCommon" : {
				// An untagged structure
				EnvelopedActivationCommon = new Enveloped<ActivationCommon> ();
				EnvelopedActivationCommon.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountAddress", new MetaDataString(
				delegate (string _a) {  AccountAddress = _a; },
				() => AccountAddress) } ,
			{ "InboundConnect", new MetaDataString(
				delegate (string _a) {  InboundConnect = _a; },
				() => InboundConnect) } ,
			{ "OutboundConnect", new MetaDataString(
				delegate (string _a) {  OutboundConnect = _a; },
				() => OutboundConnect) } ,
			{ "SmimeSign", new MetaDataStruct(
				delegate (object _a) {  SmimeSign = _a as KeyData; },
				() => SmimeSign,
				"KeyData" )} ,
			{ "SmimeEncrypt", new MetaDataStruct(
				delegate (object _a) {  SmimeEncrypt = _a as KeyData; },
				() => SmimeEncrypt,
				"KeyData" )} ,
			{ "OpenpgpSign", new MetaDataStruct(
				delegate (object _a) {  OpenpgpSign = _a as KeyData; },
				() => OpenpgpSign,
				"KeyData" )} ,
			{ "OpenpgpEncrypt", new MetaDataStruct(
				delegate (object _a) {  OpenpgpEncrypt = _a as KeyData; },
				() => OpenpgpEncrypt,
				"KeyData" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
		if (AccountAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAddress", 1);
				_writer.WriteString (AccountAddress);
			}
		if (InboundConnect != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("InboundConnect", 1);
				_writer.WriteString (InboundConnect);
			}
		if (OutboundConnect != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OutboundConnect", 1);
				_writer.WriteString (OutboundConnect);
			}
		if (SmimeSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SmimeSign", 1);
				SmimeSign.Serialize (_writer, false);
			}
		if (SmimeEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SmimeEncrypt", 1);
				SmimeEncrypt.Serialize (_writer, false);
			}
		if (OpenpgpSign != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OpenpgpSign", 1);
				OpenpgpSign.Serialize (_writer, false);
			}
		if (OpenpgpEncrypt != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("OpenpgpEncrypt", 1);
				OpenpgpEncrypt.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountAddress" : {
				AccountAddress = jsonReader.ReadString ();
				break;
				}
			case "InboundConnect" : {
				InboundConnect = jsonReader.ReadString ();
				break;
				}
			case "OutboundConnect" : {
				OutboundConnect = jsonReader.ReadString ();
				break;
				}
			case "SmimeSign" : {
				// An untagged structure
				SmimeSign = new KeyData ();
				SmimeSign.Deserialize (jsonReader);
 
				break;
				}
			case "SmimeEncrypt" : {
				// An untagged structure
				SmimeEncrypt = new KeyData ();
				SmimeEncrypt.Deserialize (jsonReader);
 
				break;
				}
			case "OpenpgpSign" : {
				// An untagged structure
				OpenpgpSign = new KeyData ();
				OpenpgpSign.Deserialize (jsonReader);
 
				break;
				}
			case "OpenpgpEncrypt" : {
				// An untagged structure
				OpenpgpEncrypt = new KeyData ();
				OpenpgpEncrypt.Deserialize (jsonReader);
 
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
	/// </summary>
public partial class CatalogedApplicationNetwork : CatalogedApplication {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedApplication)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class MessageInvoice : Message {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedReceipt : CatalogedEntry {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
		}


	}

	/// <summary>
	/// </summary>
public partial class CatalogedTicket : CatalogedEntry {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((CatalogedEntry)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedProfileDevice", new MetaDataStruct(
				delegate (object _a) {  EnvelopedProfileDevice = _a as Enveloped<ProfileDevice>; },
				() => EnvelopedProfileDevice,
				"Enveloped<ProfileDevice>" )} ,
			{ "Hailing", new MetaDataListString(
				delegate (List<string> _a) {  Hailing = _a; },
				() => Hailing) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (EnvelopedProfileDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedProfileDevice", 1);
				EnvelopedProfileDevice.Serialize (_writer, false);
			}
		if (Hailing != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Hailing", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Hailing) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedProfileDevice" : {
				// An untagged structure
				EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
				EnvelopedProfileDevice.Deserialize (jsonReader);
 
				break;
				}
			case "Hailing" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Hailing = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Hailing.Add (_Item);
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedConnectionDevice", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionDevice = _a as Enveloped<ConnectionDevice>; },
				() => EnvelopedConnectionDevice,
				"Enveloped<ConnectionDevice>" )} ,
			{ "EnvelopedConnectionService", new MetaDataStruct(
				delegate (object _a) {  EnvelopedConnectionService = _a as Enveloped<ConnectionService>; },
				() => EnvelopedConnectionService,
				"Enveloped<ConnectionService>" )} ,
			{ "PrivateKey", new MetaDataStruct(
				delegate (object _a) {  PrivateKey = _a as Key; },
				() => PrivateKey,
				"Key", true)},
			{ "ConnectUri", new MetaDataString(
				delegate (string _a) {  ConnectUri = _a; },
				() => ConnectUri) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((DevicePreconfigurationPublic)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedConnectionDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionDevice", 1);
				EnvelopedConnectionDevice.Serialize (_writer, false);
			}
		if (EnvelopedConnectionService != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedConnectionService", 1);
				EnvelopedConnectionService.Serialize (_writer, false);
			}
		if (PrivateKey != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PrivateKey", 1);
				// expand this to a tagged structure
				//PrivateKey.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(PrivateKey._Tag, 1);
					bool firstinner = true;
					PrivateKey.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
			}
		if (ConnectUri != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ConnectUri", 1);
				_writer.WriteString (ConnectUri);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedConnectionDevice" : {
				// An untagged structure
				EnvelopedConnectionDevice = new Enveloped<ConnectionDevice> ();
				EnvelopedConnectionDevice.Deserialize (jsonReader);
 
				break;
				}
			case "EnvelopedConnectionService" : {
				// An untagged structure
				EnvelopedConnectionService = new Enveloped<ConnectionService> ();
				EnvelopedConnectionService.Deserialize (jsonReader);
 
				break;
				}
			case "PrivateKey" : {
				PrivateKey = Key.FromJson (jsonReader, true) ;  // A tagged structure
				break;
				}
			case "ConnectUri" : {
				ConnectUri = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "MessageId", new MetaDataString(
				delegate (string _a) {  MessageId = _a; },
				() => MessageId) } ,
			{ "Sender", new MetaDataString(
				delegate (string _a) {  Sender = _a; },
				() => Sender) } ,
			{ "Recipient", new MetaDataString(
				delegate (string _a) {  Recipient = _a; },
				() => Recipient) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		if (MessageId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("MessageId", 1);
				_writer.WriteString (MessageId);
			}
		if (Sender != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Sender", 1);
				_writer.WriteString (Sender);
			}
		if (Recipient != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Recipient", 1);
				_writer.WriteString (Recipient);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "MessageId" : {
				MessageId = jsonReader.ReadString ();
				break;
				}
			case "Sender" : {
				Sender = jsonReader.ReadString ();
				break;
				}
			case "Recipient" : {
				Recipient = jsonReader.ReadString ();
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
public partial class MessageError : Message {
        /// <summary>
        /// </summary>

	public virtual string						ErrorCode  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "ErrorCode", new MetaDataString(
				delegate (string _a) {  ErrorCode = _a; },
				() => ErrorCode) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (ErrorCode != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ErrorCode", 1);
				_writer.WriteString (ErrorCode);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "ErrorCode" : {
				ErrorCode = jsonReader.ReadString ();
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
	/// </summary>
public partial class MessageComplete : Message {
        /// <summary>
        /// </summary>

	public virtual List<Reference>				References  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "References", new MetaDataListStruct(
				delegate (object _a) {  References = _a as List<Reference>; },
				() => References,
				"Reference" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (References != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("References", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in References) {
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "References" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				References = new List <Reference> ();
				while (_Going) {
					// an untagged structure.
					var _Item = new  Reference ();
					_Item.Deserialize (jsonReader);
					// var _Item = new Reference (jsonReader);
					References.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AuthenticatedData", new MetaDataStruct(
				delegate (object _a) {  AuthenticatedData = _a as DareEnvelope; },
				() => AuthenticatedData,
				"DareEnvelope" )} ,
			{ "ClientNonce", new MetaDataBinary(
				delegate (byte[] _a) {  ClientNonce = _a; },
				() => ClientNonce) } ,
			{ "PinId", new MetaDataString(
				delegate (string _a) {  PinId = _a; },
				() => PinId) } ,
			{ "PinWitness", new MetaDataBinary(
				delegate (byte[] _a) {  PinWitness = _a; },
				() => PinWitness) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (AuthenticatedData != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AuthenticatedData", 1);
				AuthenticatedData.Serialize (_writer, false);
			}
		if (ClientNonce != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ClientNonce", 1);
				_writer.WriteBinary (ClientNonce);
			}
		if (PinId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PinId", 1);
				_writer.WriteString (PinId);
			}
		if (PinWitness != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PinWitness", 1);
				_writer.WriteBinary (PinWitness);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AuthenticatedData" : {
				// An untagged structure
				AuthenticatedData = new DareEnvelope ();
				AuthenticatedData.Deserialize (jsonReader);
 
				break;
				}
			case "ClientNonce" : {
				ClientNonce = jsonReader.ReadBinary ();
				break;
				}
			case "PinId" : {
				PinId = jsonReader.ReadString ();
				break;
				}
			case "PinWitness" : {
				PinWitness = jsonReader.ReadBinary ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Account", new MetaDataString(
				delegate (string _a) {  Account = _a; },
				() => Account) } ,
			{ "Expires", new MetaDataDateTime(
				delegate (DateTime? _a) {  Expires = _a; },
				() => Expires) } ,
			{ "Automatic", new MetaDataBoolean(
				delegate (bool? _a) {  Automatic = _a; },
				() => Automatic) } ,
			{ "SaltedPin", new MetaDataString(
				delegate (string _a) {  SaltedPin = _a; },
				() => SaltedPin) } ,
			{ "Action", new MetaDataString(
				delegate (string _a) {  Action = _a; },
				() => Action) } ,
			{ "Roles", new MetaDataListString(
				delegate (List<string> _a) {  Roles = _a; },
				() => Roles) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Account != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Account", 1);
				_writer.WriteString (Account);
			}
		if (Expires != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Expires", 1);
				_writer.WriteDateTime (Expires);
			}
		if (Automatic != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Automatic", 1);
				_writer.WriteBoolean (Automatic);
			}
		if (SaltedPin != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("SaltedPin", 1);
				_writer.WriteString (SaltedPin);
			}
		if (Action != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Action", 1);
				_writer.WriteString (Action);
			}
		if (Roles != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Roles", 1);
			_writer.WriteArrayStart ();
			bool _firstarray = true;
			foreach (var _index in Roles) {
				_writer.WriteArraySeparator (ref _firstarray);
				_writer.WriteString (_index);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Account" : {
				Account = jsonReader.ReadString ();
				break;
				}
			case "Expires" : {
				Expires = jsonReader.ReadDateTime ();
				break;
				}
			case "Automatic" : {
				Automatic = jsonReader.ReadBoolean ();
				break;
				}
			case "SaltedPin" : {
				SaltedPin = jsonReader.ReadString ();
				break;
				}
			case "Action" : {
				Action = jsonReader.ReadString ();
				break;
				}
			case "Roles" : {
				// Have a sequence of values
				bool _Going = jsonReader.StartArray ();
				Roles = new List <string> ();
				while (_Going) {
					string _Item = jsonReader.ReadString ();
					Roles.Add (_Item);
					_Going = jsonReader.NextArray ();
					}
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
	/// Connection request message. This message contains the information
	/// </summary>
public partial class RequestConnection : MessageValidated {
        /// <summary>
        ///
        /// </summary>

	public virtual string						AccountAddress  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "AccountAddress", new MetaDataString(
				delegate (string _a) {  AccountAddress = _a; },
				() => AccountAddress) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((MessageValidated)this).SerializeX(_writer, false, ref _first);
		if (AccountAddress != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("AccountAddress", 1);
				_writer.WriteString (AccountAddress);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "AccountAddress" : {
				AccountAddress = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "EnvelopedRequestConnection", new MetaDataStruct(
				delegate (object _a) {  EnvelopedRequestConnection = _a as Enveloped<RequestConnection>; },
				() => EnvelopedRequestConnection,
				"Enveloped<RequestConnection>" )} ,
			{ "ServerNonce", new MetaDataBinary(
				delegate (byte[] _a) {  ServerNonce = _a; },
				() => ServerNonce) } ,
			{ "Witness", new MetaDataString(
				delegate (string _a) {  Witness = _a; },
				() => Witness) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (EnvelopedRequestConnection != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("EnvelopedRequestConnection", 1);
				EnvelopedRequestConnection.Serialize (_writer, false);
			}
		if (ServerNonce != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServerNonce", 1);
				_writer.WriteBinary (ServerNonce);
			}
		if (Witness != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Witness", 1);
				_writer.WriteString (Witness);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "EnvelopedRequestConnection" : {
				// An untagged structure
				EnvelopedRequestConnection = new Enveloped<RequestConnection> ();
				EnvelopedRequestConnection.Deserialize (jsonReader);
 
				break;
				}
			case "ServerNonce" : {
				ServerNonce = jsonReader.ReadBinary ();
				break;
				}
			case "Witness" : {
				Witness = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Result", new MetaDataString(
				delegate (string _a) {  Result = _a; },
				() => Result) } ,
			{ "CatalogedDevice", new MetaDataStruct(
				delegate (object _a) {  CatalogedDevice = _a as CatalogedDevice; },
				() => CatalogedDevice,
				"CatalogedDevice" )} 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Result != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Result", 1);
				_writer.WriteString (Result);
			}
		if (CatalogedDevice != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("CatalogedDevice", 1);
				CatalogedDevice.Serialize (_writer, false);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Result" : {
				Result = jsonReader.ReadString ();
				break;
				}
			case "CatalogedDevice" : {
				// An untagged structure
				CatalogedDevice = new CatalogedDevice ();
				CatalogedDevice.Deserialize (jsonReader);
 
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Reply", new MetaDataBoolean(
				delegate (bool? _a) {  Reply = _a; },
				() => Reply) } ,
			{ "Subject", new MetaDataString(
				delegate (string _a) {  Subject = _a; },
				() => Subject) } ,
			{ "PIN", new MetaDataString(
				delegate (string _a) {  PIN = _a; },
				() => PIN) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((MessageValidated)this).SerializeX(_writer, false, ref _first);
		if (Reply != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Reply", 1);
				_writer.WriteBoolean (Reply);
			}
		if (Subject != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Subject", 1);
				_writer.WriteString (Subject);
			}
		if (PIN != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PIN", 1);
				_writer.WriteString (PIN);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Reply" : {
				Reply = jsonReader.ReadBoolean ();
				break;
				}
			case "Subject" : {
				Subject = jsonReader.ReadString ();
				break;
				}
			case "PIN" : {
				PIN = jsonReader.ReadString ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Text", new MetaDataString(
				delegate (string _a) {  Text = _a; },
				() => Text) } ,
			{ "Contact", new MetaDataStruct(
				delegate (object _a) {  Contact = _a as Contact; },
				() => Contact,
				"Contact", true)}
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Text != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Text", 1);
				_writer.WriteString (Text);
			}
		if (Contact != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Contact", 1);
				// expand this to a tagged structure
				//Contact.Serialize (_writer, false);
				{
					_writer.WriteObjectStart();
					_writer.WriteToken(Contact._Tag, 1);
					bool firstinner = true;
					Contact.Serialize (_writer, true, ref firstinner);
					_writer.WriteObjectEnd();
					}
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Text" : {
				Text = jsonReader.ReadString ();
				break;
				}
			case "Contact" : {
				Contact = Contact.FromJson (jsonReader, true) ;  // A tagged structure
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
	/// </summary>
public partial class RequestConfirmation : Message {
        /// <summary>
        /// </summary>

	public virtual string						Text  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Text", new MetaDataString(
				delegate (string _a) {  Text = _a; },
				() => Text) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Text != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Text", 1);
				_writer.WriteString (Text);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Text" : {
				Text = jsonReader.ReadString ();
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
	/// </summary>
public partial class ResponseConfirmation : Message {
        /// <summary>
        /// </summary>

	public virtual Enveloped<RequestConfirmation>						Request  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						Accept  {get; set;}

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Request", new MetaDataStruct(
				delegate (object _a) {  Request = _a as Enveloped<RequestConfirmation>; },
				() => Request,
				"Enveloped<RequestConfirmation>" )} ,
			{ "Accept", new MetaDataBoolean(
				delegate (bool? _a) {  Accept = _a; },
				() => Accept) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Request != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Request", 1);
				Request.Serialize (_writer, false);
			}
		if (Accept != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Accept", 1);
				_writer.WriteBoolean (Accept);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Request" : {
				// An untagged structure
				Request = new Enveloped<RequestConfirmation> ();
				Request.Deserialize (jsonReader);
 
				break;
				}
			case "Accept" : {
				Accept = jsonReader.ReadBoolean ();
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
	/// </summary>
public partial class RequestTask : Message {

    ///<inheritdoc/>
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			default : {
				base.DeserializeToken(jsonReader, tag);
				break;
				}
			}
		// check up that all the required elements are present
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "PublicationId", new MetaDataString(
				delegate (string _a) {  PublicationId = _a; },
				() => PublicationId) } ,
			{ "ServiceAuthenticate", new MetaDataString(
				delegate (string _a) {  ServiceAuthenticate = _a; },
				() => ServiceAuthenticate) } ,
			{ "DeviceAuthenticate", new MetaDataString(
				delegate (string _a) {  DeviceAuthenticate = _a; },
				() => DeviceAuthenticate) } ,
			{ "Expires", new MetaDataDateTime(
				delegate (DateTime? _a) {  Expires = _a; },
				() => Expires) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (PublicationId != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("PublicationId", 1);
				_writer.WriteString (PublicationId);
			}
		if (ServiceAuthenticate != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ServiceAuthenticate", 1);
				_writer.WriteString (ServiceAuthenticate);
			}
		if (DeviceAuthenticate != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("DeviceAuthenticate", 1);
				_writer.WriteString (DeviceAuthenticate);
			}
		if (Expires != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Expires", 1);
				_writer.WriteDateTime (Expires);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "PublicationId" : {
				PublicationId = jsonReader.ReadString ();
				break;
				}
			case "ServiceAuthenticate" : {
				ServiceAuthenticate = jsonReader.ReadString ();
				break;
				}
			case "DeviceAuthenticate" : {
				DeviceAuthenticate = jsonReader.ReadString ();
				break;
				}
			case "Expires" : {
				Expires = jsonReader.ReadDateTime ();
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
    public override Dictionary<string, MetaData> _MetaDataParent => base._MetaData;

    ///<inheritdoc/>
	public override Dictionary<string, MetaData> _MetaData => 
		_metaData ??  new Dictionary<string, MetaData> () {
			{ "Success", new MetaDataBoolean(
				delegate (bool? _a) {  Success = _a; },
				() => Success) } ,
			{ "ErrorReport", new MetaDataString(
				delegate (string _a) {  ErrorReport = _a; },
				() => ErrorReport) } 
		}.CacheValue(out _metaData);
	Dictionary<string, MetaData> _metaData;
		
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
		((Message)this).SerializeX(_writer, false, ref _first);
		if (Success != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("Success", 1);
				_writer.WriteBoolean (Success);
			}
		if (ErrorReport != null) {
			_writer.WriteObjectSeparator (ref _first);
			_writer.WriteToken ("ErrorReport", 1);
				_writer.WriteString (ErrorReport);
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

    /// <summary>
    /// Having read a tag, process the corresponding value data.
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
    /// <param name="tag">The tag</param>
	public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
		switch (tag) {
			case "Success" : {
				Success = jsonReader.ReadBoolean ();
				break;
				}
			case "ErrorReport" : {
				ErrorReport = jsonReader.ReadString ();
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



