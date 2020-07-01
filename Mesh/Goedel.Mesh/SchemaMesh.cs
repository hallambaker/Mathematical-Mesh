﻿
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
//  #% var InheritsOverride = "override"; // "virtual"

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;
#pragma warning disable IDE1006


using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh {


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
	public abstract partial class MeshItem : global::Goedel.Protocol.JSONObject {

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
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"KeyData", KeyData._Factory},
			{"KeyComposite", KeyComposite._Factory},
			{"DeviceRecryptionKey", DeviceRecryptionKey._Factory},
			{"EscrowedKeySet", EscrowedKeySet._Factory},
			{"Assertion", Assertion._Factory},
			{"Condition", Condition._Factory},
			{"Profile", Profile._Factory},
			{"Connection", Connection._Factory},
			{"Activation", Activation._Factory},
			{"Permission", Permission._Factory},
			{"ProfileMesh", ProfileMesh._Factory},
			{"ProfileDevice", ProfileDevice._Factory},
			{"ActivationDevice", ActivationDevice._Factory},
			{"ConnectionDevice", ConnectionDevice._Factory},
			{"CatalogedDevice", CatalogedDevice._Factory},
			{"CatalogedPublication", CatalogedPublication._Factory},
			{"ProfileAccount", ProfileAccount._Factory},
			{"ActivationAccount", ActivationAccount._Factory},
			{"ConnectionAccount", ConnectionAccount._Factory},
			{"AccountEntry", AccountEntry._Factory},
			{"ConnectionApplication", ConnectionApplication._Factory},
			{"ProfileGroup", ProfileGroup._Factory},
			{"ActivationGroup", ActivationGroup._Factory},
			{"ConnectionGroup", ConnectionGroup._Factory},
			{"ProfileService", ProfileService._Factory},
			{"ConnectionService", ConnectionService._Factory},
			{"ProfileHost", ProfileHost._Factory},
			{"ConnectionHost", ConnectionHost._Factory},
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
			{"Task", Task._Factory},
			{"CatalogedEntry", CatalogedEntry._Factory},
			{"CatalogedCredential", CatalogedCredential._Factory},
			{"CatalogedNetwork", CatalogedNetwork._Factory},
			{"CatalogedContact", CatalogedContact._Factory},
			{"CatalogedContactRecryption", CatalogedContactRecryption._Factory},
			{"CatalogedCapability", CatalogedCapability._Factory},
			{"CryptographicCapability", CryptographicCapability._Factory},
			{"CapabilityDecryption", CapabilityDecryption._Factory},
			{"CapabilityVerification", CapabilityVerification._Factory},
			{"CapabilityAuthentication", CapabilityAuthentication._Factory},
			{"CapabilityAdministrator", CapabilityAdministrator._Factory},
			{"CapabilityThresholdDecrypt", CapabilityThresholdDecrypt._Factory},
			{"CapabilityThresholdSign", CapabilityThresholdSign._Factory},
			{"CapabilityThresholdMicali", CapabilityThresholdMicali._Factory},
			{"CatalogedBookmark", CatalogedBookmark._Factory},
			{"CatalogedTask", CatalogedTask._Factory},
			{"CatalogedApplication", CatalogedApplication._Factory},
			{"CatalogedMember", CatalogedMember._Factory},
			{"CatalogedGroup", CatalogedGroup._Factory},
			{"CatalogedApplicationSSH", CatalogedApplicationSSH._Factory},
			{"CatalogedApplicationMail", CatalogedApplicationMail._Factory},
			{"CatalogedApplicationNetwork", CatalogedApplicationNetwork._Factory},
			{"DevicePreconfiguration", DevicePreconfiguration._Factory},
			{"Message", Message._Factory},
			{"MessageComplete", MessageComplete._Factory},
			{"MessagePIN", MessagePIN._Factory},
			{"RequestConnection", RequestConnection._Factory},
			{"AcknowledgeConnection", AcknowledgeConnection._Factory},
			{"RespondConnection", RespondConnection._Factory},
			{"RequestContact", RequestContact._Factory},
			{"ReplyContact", ReplyContact._Factory},
			{"GroupInvitation", GroupInvitation._Factory},
			{"RequestConfirmation", RequestConfirmation._Factory},
			{"ResponseConfirmation", ResponseConfirmation._Factory},
			{"RequestTask", RequestTask._Factory},
			{"MessageClaim", MessageClaim._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="jsonReader">Input stream</param>
        /// <param name="result">The created object</param>
        public static void Deserialize(JSONReader jsonReader, out JSONObject result) => 
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
        ///UDF fingerprint of the public key parameters/
        /// </summary>

		public virtual string						UDF  {get; set;}
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
		public static new JSONObject _Factory () => new KeyData();


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
			if (UDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UDF", 1);
					_writer.WriteString (UDF);
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
        public static new KeyData FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "UDF" : {
					UDF = jsonReader.ReadString ();
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
					PublicParameters = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "PrivateParameters" : {
					PrivateParameters = Key.FromJSON (jsonReader, true) ;  // A tagged structure
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
	public partial class KeyComposite : MeshItem {
        /// <summary>
        ///The composite key
        /// </summary>

		public virtual Key						Public  {get; set;}
        /// <summary>
        ///The overlay key contribution.
        /// </summary>

		public virtual Key						Part  {get; set;}
        /// <summary>
        ///Service holding the additional contribution
        /// </summary>

		public virtual string						Service  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "KeyComposite";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new KeyComposite();


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
			if (Public != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Public", 1);
					// expand this to a tagged structure
					//Public.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(Public._Tag, 1);
						bool firstinner = true;
						Public.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (Part != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Part", 1);
					// expand this to a tagged structure
					//Part.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(Part._Tag, 1);
						bool firstinner = true;
						Part.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (Service != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Service", 1);
					_writer.WriteString (Service);
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
        public static new KeyComposite FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as KeyComposite;
				}
		    var Result = new KeyComposite ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Public" : {
					Public = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "Part" : {
					Part = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "Service" : {
					Service = jsonReader.ReadString ();
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
	public partial class DeviceRecryptionKey : MeshItem {
        /// <summary>
        ///The fingerprint of the encryption key
        /// </summary>

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///The User's Mesh contact information
        /// </summary>

		public virtual Contact						Contact  {get; set;}
        /// <summary>
        ///The recryption key
        /// </summary>

		public virtual KeyData						RecryptionKey  {get; set;}
        /// <summary>
        ///The decryption key encrypted under the user's device key.	
        /// </summary>

		public virtual DareEnvelope						EnvelopedRecryptionKeyDevice  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DeviceRecryptionKey";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new DeviceRecryptionKey();


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
			if (UDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UDF", 1);
					_writer.WriteString (UDF);
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
			if (RecryptionKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("RecryptionKey", 1);
					RecryptionKey.Serialize (_writer, false);
				}
			if (EnvelopedRecryptionKeyDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedRecryptionKeyDevice", 1);
					EnvelopedRecryptionKeyDevice.Serialize (_writer, false);
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
        public static new DeviceRecryptionKey FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DeviceRecryptionKey;
				}
		    var Result = new DeviceRecryptionKey ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "UDF" : {
					UDF = jsonReader.ReadString ();
					break;
					}
				case "Contact" : {
					Contact = Contact.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "RecryptionKey" : {
					// An untagged structure
					RecryptionKey = new KeyData ();
					RecryptionKey.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedRecryptionKeyDevice" : {
					// An untagged structure
					EnvelopedRecryptionKeyDevice = new DareEnvelope ();
					EnvelopedRecryptionKeyDevice.Deserialize (jsonReader);
 
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
	/// A set of escrowed keys. 
	/// </summary>
	public partial class EscrowedKeySet : MeshItem {
        /// <summary>
        ///A Master Signature Key
        /// </summary>

		public virtual Key						MasterSignatureKey  {get; set;}
        /// <summary>
        ///The Master Encryption Key
        /// </summary>

		public virtual Key						MasterEncryptionKey  {get; set;}
        /// <summary>
        ///The escrowed master escrow keys.
        /// </summary>

		public virtual List<Key>				MasterEscrowKeys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "EscrowedKeySet";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new EscrowedKeySet();


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
			if (MasterSignatureKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MasterSignatureKey", 1);
					// expand this to a tagged structure
					//MasterSignatureKey.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(MasterSignatureKey._Tag, 1);
						bool firstinner = true;
						MasterSignatureKey.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (MasterEncryptionKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MasterEncryptionKey", 1);
					// expand this to a tagged structure
					//MasterEncryptionKey.Serialize (_writer, false);
					{
						_writer.WriteObjectStart();
						_writer.WriteToken(MasterEncryptionKey._Tag, 1);
						bool firstinner = true;
						MasterEncryptionKey.Serialize (_writer, true, ref firstinner);
						_writer.WriteObjectEnd();
						}
				}
			if (MasterEscrowKeys != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MasterEscrowKeys", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MasterEscrowKeys) {
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
        public static new EscrowedKeySet FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as EscrowedKeySet;
				}
		    var Result = new EscrowedKeySet ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "MasterSignatureKey" : {
					MasterSignatureKey = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "MasterEncryptionKey" : {
					MasterEncryptionKey = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "MasterEscrowKeys" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					MasterEscrowKeys = new List <Key> ();
					while (_Going) {
						var _Item = Key.FromJSON (jsonReader, true); // a tagged structure
						MasterEscrowKeys.Add (_Item);
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
		public static new JSONObject _Factory () => throw new CannotCreateAbstract();


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
        public static new Assertion FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
					Conditions = Condition.FromJSON (jsonReader, true) ;  // A tagged structure
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
		public static new JSONObject _Factory () => throw new CannotCreateAbstract();


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
        public static new Condition FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// Parent class from which all profile classes are derived
	/// </summary>
	abstract public partial class Profile : Assertion {
        /// <summary>
        ///The permanent signature key used to sign the profile itself. The UDF of
        ///the key is used as the permanent object identifier of the profile. Thus,
        ///by definition, the KeySignature value of a Profile does not change under
        ///any circumstance. The only case in which a 
        /// </summary>

		public virtual KeyData						KeyOfflineSignature  {get; set;}
        /// <summary>
        ///A Personal profile contains at least one OSK which is used to sign 
        ///device administration application profiles.
        /// </summary>

		public virtual List<KeyData>				KeysOnlineSignature  {get; set;}
		
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
		public static new JSONObject _Factory () => throw new CannotCreateAbstract();


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
			if (KeyOfflineSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyOfflineSignature", 1);
					KeyOfflineSignature.Serialize (_writer, false);
				}
			if (KeysOnlineSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeysOnlineSignature", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeysOnlineSignature) {
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
        public static new Profile FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyOfflineSignature" : {
					// An untagged structure
					KeyOfflineSignature = new KeyData ();
					KeyOfflineSignature.Deserialize (jsonReader);
 
					break;
					}
				case "KeysOnlineSignature" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					KeysOnlineSignature = new List <KeyData> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  KeyData ();
						_Item.Deserialize (jsonReader);
						// var _Item = new KeyData (jsonReader);
						KeysOnlineSignature.Add (_Item);
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
	public partial class Connection : Assertion {
        /// <summary>
        ///UDF of the connection target.
        /// </summary>

		public virtual string						SubjectUDF  {get; set;}
        /// <summary>
        ///UDF of the connection source.
        /// </summary>

		public virtual string						AuthorityUDF  {get; set;}
		
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
		public static new JSONObject _Factory () => new Connection();


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
			if (SubjectUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SubjectUDF", 1);
					_writer.WriteString (SubjectUDF);
				}
			if (AuthorityUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AuthorityUDF", 1);
					_writer.WriteString (AuthorityUDF);
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
        public static new Connection FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "SubjectUDF" : {
					SubjectUDF = jsonReader.ReadString ();
					break;
					}
				case "AuthorityUDF" : {
					AuthorityUDF = jsonReader.ReadString ();
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
	/// Contains the private activation information for a Mesh application running on
	/// a specific device
	/// </summary>
	public partial class Activation : Assertion {
        /// <summary>
        ///The signed AssertionDeviceConnection.
        /// </summary>

		public virtual DareEnvelope						EnvelopedConnection  {get; set;}
        /// <summary>
        ///The master secret from which all the key contributions are derrived.
        /// </summary>

		public virtual string						ActivationKey  {get; set;}
		
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
		public static new JSONObject _Factory () => new Activation();


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
			if (EnvelopedConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnection", 1);
					EnvelopedConnection.Serialize (_writer, false);
				}
			if (ActivationKey != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ActivationKey", 1);
					_writer.WriteString (ActivationKey);
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
        public static new Activation FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedConnection" : {
					// An untagged structure
					EnvelopedConnection = new DareEnvelope ();
					EnvelopedConnection.Deserialize (jsonReader);
 
					break;
					}
				case "ActivationKey" : {
					ActivationKey = jsonReader.ReadString ();
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
	public partial class Permission : MeshItem {
        /// <summary>
        /// </summary>

		public virtual string						Name  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Role  {get; set;}
        /// <summary>
        ///Keys or key contributions enabling the operation to be performed
        /// </summary>

		public virtual DareEnvelope						Capabilities  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Permission";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new Permission();


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
			if (Name != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Name", 1);
					_writer.WriteString (Name);
				}
			if (Role != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Role", 1);
					_writer.WriteString (Role);
				}
			if (Capabilities != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Capabilities", 1);
					Capabilities.Serialize (_writer, false);
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
        public static new Permission FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Permission;
				}
		    var Result = new Permission ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Name" : {
					Name = jsonReader.ReadString ();
					break;
					}
				case "Role" : {
					Role = jsonReader.ReadString ();
					break;
					}
				case "Capabilities" : {
					// An untagged structure
					Capabilities = new DareEnvelope ();
					Capabilities.Deserialize (jsonReader);
 
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
	/// Describes the long term parameters associated with a personal profile.
	/// </summary>
	public partial class ProfileMesh : Profile {
        /// <summary>
        ///A Personal Profile MAY contain one or more PMEK keys to enable escrow 
        ///of private keys used for stored data. 
        /// </summary>

		public virtual List<KeyData>				KeysMasterEscrow  {get; set;}
        /// <summary>
        ///Key used to pass encrypted data to the device such as a
        ///DeviceUseEntry
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ProfileMesh";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ProfileMesh();


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
			if (KeysMasterEscrow != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeysMasterEscrow", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeysMasterEscrow) {
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

			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
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
        public static new ProfileMesh FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileMesh;
				}
		    var Result = new ProfileMesh ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeysMasterEscrow" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					KeysMasterEscrow = new List <KeyData> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  KeyData ();
						_Item.Deserialize (jsonReader);
						// var _Item = new KeyData (jsonReader);
						KeysMasterEscrow.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
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
        ///Description of the device
        /// </summary>

		public virtual string						Description  {get; set;}
        /// <summary>
        ///Key used to pass encrypted data to the device such as a
        ///DeviceUseEntry
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made by the device.
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
		
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
		public static new JSONObject _Factory () => new ProfileDevice();


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
			if (Description != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Description", 1);
					_writer.WriteString (Description);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
				}
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
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
        public static new ProfileDevice FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Description" : {
					Description = jsonReader.ReadString ();
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
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
	public partial class ActivationDevice : Activation {
        /// <summary>
        ///List of application and account activation data. Keys, etc.
        /// </summary>

		public virtual List<Activation>				Activations  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ActivationDevice";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ActivationDevice();


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
			if (Activations != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Activations", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Activations) {
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
        public static new ActivationDevice FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ActivationDevice;
				}
		    var Result = new ActivationDevice ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Activations" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Activations = new List <Activation> ();
					while (_Going) {
						var _Item = Activation.FromJSON (jsonReader, true); // a tagged structure
						Activations.Add (_Item);
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
	public partial class ConnectionDevice : Connection {
        /// <summary>
        ///List of the permissions that the device has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeySignature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
		
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
		public static new JSONObject _Factory () => new ConnectionDevice();


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
			if (Permissions != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Permissions", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
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

			if (KeySignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_writer, false);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
				}
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
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
        public static new ConnectionDevice FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Permission (jsonReader);
						Permissions.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new KeyData ();
					KeySignature.Deserialize (jsonReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
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
	/// Public device entry, indexed under the device ID
	/// </summary>
	public partial class CatalogedDevice : CatalogedEntry {
        /// <summary>
        ///UDF of the signature key of the device in the Mesh
        /// </summary>

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///The Mesh profile
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileMesh  {get; set;}
        /// <summary>
        ///UDF of the signature key of the device
        /// </summary>

		public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        ///The device profile
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The public assertion demonstrating connection of the Device to the Mesh
        /// </summary>

		public virtual DareEnvelope						EnvelopedConnectionDevice  {get; set;}
        /// <summary>
        ///The activations of the device within the Mesh
        /// </summary>

		public virtual DareEnvelope						EnvelopedActivationDevice  {get; set;}
        /// <summary>
        ///The accounts that this device is connected to
        /// </summary>

		public virtual List<AccountEntry>				Accounts  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedDevice();


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
			if (UDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UDF", 1);
					_writer.WriteString (UDF);
				}
			if (EnvelopedProfileMesh != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileMesh", 1);
					EnvelopedProfileMesh.Serialize (_writer, false);
				}
			if (DeviceUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceUDF", 1);
					_writer.WriteString (DeviceUDF);
				}
			if (EnvelopedProfileDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_writer, false);
				}
			if (EnvelopedConnectionDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnectionDevice", 1);
					EnvelopedConnectionDevice.Serialize (_writer, false);
				}
			if (EnvelopedActivationDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedActivationDevice", 1);
					EnvelopedActivationDevice.Serialize (_writer, false);
				}
			if (Accounts != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Accounts", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Accounts) {
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
        public static new CatalogedDevice FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "UDF" : {
					UDF = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileMesh" : {
					// An untagged structure
					EnvelopedProfileMesh = new DareEnvelope ();
					EnvelopedProfileMesh.Deserialize (jsonReader);
 
					break;
					}
				case "DeviceUDF" : {
					DeviceUDF = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedConnectionDevice" : {
					// An untagged structure
					EnvelopedConnectionDevice = new DareEnvelope ();
					EnvelopedConnectionDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationDevice" : {
					// An untagged structure
					EnvelopedActivationDevice = new DareEnvelope ();
					EnvelopedActivationDevice.Deserialize (jsonReader);
 
					break;
					}
				case "Accounts" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Accounts = new List <AccountEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  AccountEntry ();
						_Item.Deserialize (jsonReader);
						// var _Item = new AccountEntry (jsonReader);
						Accounts.Add (_Item);
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

		public virtual string						ID  {get; set;}
        /// <summary>
        ///The witness key value to use to request access to the record.	
        /// </summary>

		public virtual string						Authenticator  {get; set;}
        /// <summary>
        ///Dare Envelope containing the entry data
        /// </summary>

		public virtual DareEnvelope						EnvelopedData  {get; set;}
        /// <summary>
        ///Epiration time (inclusive)
        /// </summary>

		public virtual DateTime?						NotOnOrAfter  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedPublication();


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
			if (ID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ID", 1);
					_writer.WriteString (ID);
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
        public static new CatalogedPublication FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "ID" : {
					ID = jsonReader.ReadString ();
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
	///
	/// Account assertion. This is signed by the service hosting the account.
	/// </summary>
	public partial class ProfileAccount : Profile {
        /// <summary>
        ///Service address(es).
        /// </summary>

		public virtual List<string>				AccountAddresses  {get; set;}
        /// <summary>
        ///Master profile of the account being registered.
        /// </summary>

		public virtual string						MeshProfileUDF  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made by the device.
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
        /// <summary>
        ///The service profile
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileService  {get; set;}
		
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
		public static new JSONObject _Factory () => new ProfileAccount();


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
			if (AccountAddresses != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddresses", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AccountAddresses) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (MeshProfileUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MeshProfileUDF", 1);
					_writer.WriteString (MeshProfileUDF);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
				}
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
				}
			if (EnvelopedProfileService != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileService", 1);
					EnvelopedProfileService.Serialize (_writer, false);
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
        public static new ProfileAccount FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddresses" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					AccountAddresses = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						AccountAddresses.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "MeshProfileUDF" : {
					MeshProfileUDF = jsonReader.ReadString ();
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedProfileService" : {
					// An untagged structure
					EnvelopedProfileService = new DareEnvelope ();
					EnvelopedProfileService.Deserialize (jsonReader);
 
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
	public partial class ActivationAccount : Activation {
        /// <summary>
        ///The UDF of the account
        /// </summary>

		public virtual string						AccountUDF  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						KeyAccountEncryption  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						KeyAccountSignature  {get; set;}
		
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
		public static new JSONObject _Factory () => new ActivationAccount();


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
			if (AccountUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountUDF", 1);
					_writer.WriteString (AccountUDF);
				}
			if (KeyAccountEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAccountEncryption", 1);
					KeyAccountEncryption.Serialize (_writer, false);
				}
			if (KeyAccountSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAccountSignature", 1);
					KeyAccountSignature.Serialize (_writer, false);
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
        public static new ActivationAccount FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountUDF" : {
					AccountUDF = jsonReader.ReadString ();
					break;
					}
				case "KeyAccountEncryption" : {
					// An untagged structure
					KeyAccountEncryption = new KeyData ();
					KeyAccountEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "KeyAccountSignature" : {
					// An untagged structure
					KeyAccountSignature = new KeyData ();
					KeyAccountSignature.Deserialize (jsonReader);
 
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
	public partial class ConnectionAccount : Connection {
        /// <summary>
        ///The list of service identifiers.
        /// </summary>

		public virtual List<string>				AccountAddresses  {get; set;}
        /// <summary>
        ///List of the permissions that the device has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeySignature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConnectionAccount";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ConnectionAccount();


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
			if (AccountAddresses != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddresses", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AccountAddresses) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Permissions != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Permissions", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
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

			if (KeySignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_writer, false);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
				}
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
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
        public static new ConnectionAccount FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionAccount;
				}
		    var Result = new ConnectionAccount ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddresses" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					AccountAddresses = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						AccountAddresses.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Permission (jsonReader);
						Permissions.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new KeyData ();
					KeySignature.Deserialize (jsonReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
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
	/// Contains the Account information for an account with a CatalogedDevice.
	/// </summary>
	public partial class AccountEntry : MeshItem {
        /// <summary>
        ///UDF of the account profile
        /// </summary>

		public virtual string						AccountUDF  {get; set;}
        /// <summary>
        ///The account profile
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///The connection of this device to the account
        /// </summary>

		public virtual DareEnvelope						EnvelopedConnectionAccount  {get; set;}
        /// <summary>
        ///The activation data for this device to the account	
        /// </summary>

		public virtual DareEnvelope						EnvelopedActivationAccount  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "AccountEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new AccountEntry();


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
			if (AccountUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountUDF", 1);
					_writer.WriteString (AccountUDF);
				}
			if (EnvelopedProfileAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_writer, false);
				}
			if (EnvelopedConnectionAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnectionAccount", 1);
					EnvelopedConnectionAccount.Serialize (_writer, false);
				}
			if (EnvelopedActivationAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedActivationAccount", 1);
					EnvelopedActivationAccount.Serialize (_writer, false);
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
        public static new AccountEntry FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountEntry;
				}
		    var Result = new AccountEntry ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountUDF" : {
					AccountUDF = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new DareEnvelope ();
					EnvelopedProfileAccount.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedConnectionAccount" : {
					// An untagged structure
					EnvelopedConnectionAccount = new DareEnvelope ();
					EnvelopedConnectionAccount.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationAccount" : {
					// An untagged structure
					EnvelopedActivationAccount = new DareEnvelope ();
					EnvelopedActivationAccount.Deserialize (jsonReader);
 
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
	public partial class ConnectionApplication : Connection {
		
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
		public static new JSONObject _Factory () => new ConnectionApplication();


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
        public static new ConnectionApplication FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// Describes a group. Note that while a group is created by one person who
	/// becomes its first administrator, control of the group may pass to other
	/// administrators over time.
	/// </summary>
	public partial class ProfileGroup : Profile {
        /// <summary>
        ///Service address(es).
        /// </summary>

		public virtual List<string>				AccountAddresses  {get; set;}
        /// <summary>
        ///Key currently used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
		
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
		public static new JSONObject _Factory () => new ProfileGroup();


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
			if (AccountAddresses != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddresses", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AccountAddresses) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
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
        public static new ProfileGroup FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddresses" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					AccountAddresses = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						AccountAddresses.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
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
	public partial class ActivationGroup : Activation {
        /// <summary>
        ///The UDF of the group
        /// </summary>

		public virtual string						GroupUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ActivationGroup";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ActivationGroup();


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
			if (GroupUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("GroupUDF", 1);
					_writer.WriteString (GroupUDF);
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
        public static new ActivationGroup FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ActivationGroup;
				}
		    var Result = new ActivationGroup ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "GroupUDF" : {
					GroupUDF = jsonReader.ReadString ();
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
	/// Describes the connection of a member to a group.
	/// </summary>
	public partial class ConnectionGroup : Connection {
        /// <summary>
        ///The decryption key for the user within the group
        /// </summary>

		public virtual KeyComposite						KeyEncryption  {get; set;}
		
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
		public static new JSONObject _Factory () => new ConnectionGroup();


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
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
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
        public static new ConnectionGroup FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyComposite ();
					KeyEncryption.Deserialize (jsonReader);
 
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
	/// Profile of a Mesh Service
	/// </summary>
	public partial class ProfileService : Profile {
        /// <summary>
        ///Key used to authenticate service connections.
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
		
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
		public static new JSONObject _Factory () => new ProfileService();


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
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
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
        public static new ProfileService FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
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
	public partial class ConnectionService : Connection {
		
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
		public static new JSONObject _Factory () => new ConnectionService();


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
        public static new ConnectionService FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class ProfileHost : Profile {
        /// <summary>
        ///Key used to authenticate service connections.
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
		
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
		public static new JSONObject _Factory () => new ProfileHost();


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
			if (KeyAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_writer, false);
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
        public static new ProfileHost FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyData ();
					KeyAuthentication.Deserialize (jsonReader);
 
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
		public static new JSONObject _Factory () => new ConnectionHost();


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
        public static new ConnectionHost FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// Base class for contact entries.
	/// </summary>
	abstract public partial class Contact : Assertion {
        /// <summary>
        ///The globally unique contact identifier.
        /// </summary>

		public virtual string						Id  {get; set;}
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
		public static new JSONObject _Factory () => throw new CannotCreateAbstract();


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
        public static new Contact FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Id" : {
					Id = jsonReader.ReadString ();
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

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///The means of validation.
        /// </summary>

		public virtual string						Validation  {get; set;}
		
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
		public static new JSONObject _Factory () => new Anchor();


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
			if (UDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UDF", 1);
					_writer.WriteString (UDF);
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
        public static new Anchor FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "UDF" : {
					UDF = jsonReader.ReadString ();
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

		public virtual DareEnvelope						EnvelopedSource  {get; set;}
		
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
		public static new JSONObject _Factory () => new TaggedSource();


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
        public static new TaggedSource FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
					EnvelopedSource = new DareEnvelope ();
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
		public static new JSONObject _Factory () => new ContactGroup();


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
        public static new ContactGroup FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new ContactPerson();


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
        public static new ContactPerson FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new ContactOrganization();


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
        public static new ContactOrganization FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		bool								__Inactive = false;
		private bool						_Inactive;
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

		public virtual bool						Inactive {
			get => _Inactive;
			set {_Inactive = value; __Inactive = true; }
			}
        /// <summary>
        ///The registered name.
        /// </summary>

		public virtual string						RegisteredName  {get; set;}
        /// <summary>
        ///Names that the organization uses including trading names
        ///and doing business as names.
        /// </summary>

		public virtual string						DBA  {get; set;}
		
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
		public static new JSONObject _Factory () => new OrganizationName();


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
			if (__Inactive){
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
        public static new OrganizationName FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		bool								__Inactive = false;
		private bool						_Inactive;
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

		public virtual bool						Inactive {
			get => _Inactive;
			set {_Inactive = value; __Inactive = true; }
			}
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
		public static new JSONObject _Factory () => new PersonName();


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
			if (__Inactive){
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
        public static new PersonName FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		bool								__Inactive = false;
		private bool						_Inactive;
        /// <summary>
        ///If true, the name is not in current use.
        /// </summary>

		public virtual bool						Inactive {
			get => _Inactive;
			set {_Inactive = value; __Inactive = true; }
			}
        /// <summary>
        ///The network address, e.g. alice@example.com
        /// </summary>

		public virtual string						Address  {get; set;}
        /// <summary>
        ///The capabilities bound to this address.
        /// </summary>

		public virtual List<string>				NetworkCapability  {get; set;}
        /// <summary>
        ///Optional enveloped profile for the Address
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileAccount  {get; set;}
        /// <summary>
        ///Public keys associated with the network address
        /// </summary>

		public virtual List<NetworkProtocol>				Protocols  {get; set;}
		
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
		public static new JSONObject _Factory () => new NetworkAddress();


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
			if (__Inactive){
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
        public static new NetworkAddress FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
					EnvelopedProfileAccount = new DareEnvelope ();
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
		public static new JSONObject _Factory () => new NetworkProtocol();


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
        public static new NetworkProtocol FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
						var _Item = CryptographicCapability.FromJSON (jsonReader, true); // a tagged structure
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
		public static new JSONObject _Factory () => new Role();


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
        public static new Role FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new Location();


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
        public static new Location FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new Bookmark();


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
        public static new Bookmark FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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

		public virtual string						MessageID  {get; set;}
        /// <summary>
        ///Message that was generated in response to the original (optional).
        /// </summary>

		public virtual string						ResponseID  {get; set;}
        /// <summary>
        ///The relationship type. This can be Read, Unread, Accept, Reject.
        /// </summary>

		public virtual string						Relationship  {get; set;}
		
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
		public static new JSONObject _Factory () => new Reference();


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
			if (MessageID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MessageID", 1);
					_writer.WriteString (MessageID);
				}
			if (ResponseID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ResponseID", 1);
					_writer.WriteString (ResponseID);
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
        public static new Reference FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "MessageID" : {
					MessageID = jsonReader.ReadString ();
					break;
					}
				case "ResponseID" : {
					ResponseID = jsonReader.ReadString ();
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
	public partial class Task : MeshItem {
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
		bool								__Busy = false;
		private bool						_Busy;
        /// <summary>
        /// </summary>

		public virtual bool						Busy {
			get => _Busy;
			set {_Busy = value; __Busy = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Task";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new Task();


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
			if (__Busy){
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
        public static new Task FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Task;
				}
		    var Result = new Task ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class CatalogedEntry : MeshItem {
        /// <summary>
        ///The set of labels describing the entry
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedEntry();


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
        public static new CatalogedEntry FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedEntry;
				}
		    var Result = new CatalogedEntry ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
				default : {
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
		public static new JSONObject _Factory () => new CatalogedCredential();


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
        public static new CatalogedCredential FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new CatalogedNetwork();


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
        public static new CatalogedNetwork FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		bool								__Self = false;
		private bool						_Self;
        /// <summary>
        ///If true, this catalog entry is for the user who created the catalog.
        /// </summary>

		public virtual bool						Self {
			get => _Self;
			set {_Self = value; __Self = true; }
			}
        /// <summary>
        ///List of the permissions that the contact has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The contact information as edited by the catalog owner.
        /// </summary>

		public virtual Contact						Contact  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedContact();


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
			if (__Self){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Self", 1);
					_writer.WriteBoolean (Self);
				}
			if (Permissions != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Permissions", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
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
        public static new CatalogedContact FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Key" : {
					Key = jsonReader.ReadString ();
					break;
					}
				case "Self" : {
					Self = jsonReader.ReadBoolean ();
					break;
					}
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Permission (jsonReader);
						Permissions.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Contact" : {
					Contact = Contact.FromJSON (jsonReader, true) ;  // A tagged structure
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
	public partial class CatalogedContactRecryption : CatalogedContact {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedContactRecryption";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedContactRecryption();


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
			((CatalogedContact)this).SerializeX(_writer, false, ref _first);
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
        public static new CatalogedContactRecryption FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedContactRecryption;
				}
		    var Result = new CatalogedContactRecryption ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class CatalogedCapability : CatalogedEntry {
        /// <summary>
        ///Fingerprint of a cryptographic key that is presented to claim 
        ///the specified capability.
        /// </summary>

		public virtual string						SubjectId  {get; set;}
        /// <summary>
        ///
        /// </summary>

		public virtual List<string>				Permissions  {get; set;}
        /// <summary>
        ///Cryptographic keys representing capabilities.
        /// </summary>

		public virtual List<CryptographicCapability>				Keys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedCapability";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedCapability();


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
			if (SubjectId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SubjectId", 1);
					_writer.WriteString (SubjectId);
				}
			if (Permissions != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Permissions", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Keys != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Keys", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Keys) {
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
        public static new CatalogedCapability FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedCapability;
				}
		    var Result = new CatalogedCapability ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "SubjectId" : {
					SubjectId = jsonReader.ReadString ();
					break;
					}
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Permissions = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Permissions.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Keys" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Keys = new List <CryptographicCapability> ();
					while (_Going) {
						var _Item = CryptographicCapability.FromJSON (jsonReader, true); // a tagged structure
						Keys.Add (_Item);
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
	abstract public partial class CryptographicCapability : MeshItem {
        /// <summary>
        ///Key identifier in URI form (mmm://service/udf
        /// </summary>

		public virtual string						Id  {get; set;}
        /// <summary>
        ///The role for which the key is authorized
        /// </summary>

		public virtual string						Role  {get; set;}
        /// <summary>
        ///The key that enables the capability
        /// </summary>

		public virtual KeyData						KeySignature  {get; set;}
        /// <summary>
        ///The key that enables the capability
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
        /// <summary>
        ///Enveloped key data
        /// </summary>

		public virtual DareEnvelope						EnvelopedKeyData  {get; set;}
		
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
		public static new JSONObject _Factory () => throw new CannotCreateAbstract();


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
			if (Role != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Role", 1);
					_writer.WriteString (Role);
				}
			if (KeySignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_writer, false);
				}
			if (KeyEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_writer, false);
				}
			if (EnvelopedKeyData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedKeyData", 1);
					EnvelopedKeyData.Serialize (_writer, false);
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
        public static new CryptographicCapability FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Id" : {
					Id = jsonReader.ReadString ();
					break;
					}
				case "Role" : {
					Role = jsonReader.ReadString ();
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new KeyData ();
					KeySignature.Deserialize (jsonReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyData ();
					KeyEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedKeyData" : {
					// An untagged structure
					EnvelopedKeyData = new DareEnvelope ();
					EnvelopedKeyData.Deserialize (jsonReader);
 
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
	/// The corresponding key is an encryption key
	/// </summary>
	public partial class CapabilityDecryption : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityDecryption";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityDecryption();


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
        public static new CapabilityDecryption FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityDecryption;
				}
		    var Result = new CapabilityDecryption ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// The corresponding key is a signature verification key
	/// </summary>
	public partial class CapabilityVerification : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityVerification";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityVerification();


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
        public static new CapabilityVerification FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityVerification;
				}
		    var Result = new CapabilityVerification ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// The corresponding key is a key which may be used to authenticate the party
	/// </summary>
	public partial class CapabilityAuthentication : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityAuthentication";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityAuthentication();


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
        public static new CapabilityAuthentication FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityAuthentication;
				}
		    var Result = new CapabilityAuthentication ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// The corresponding key is an administration key
	/// </summary>
	public partial class CapabilityAdministrator : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityAdministrator";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityAdministrator();


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
        public static new CapabilityAdministrator FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityAdministrator;
				}
		    var Result = new CapabilityAdministrator ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// The corresponding key is a threshold decryption key.
	/// </summary>
	public partial class CapabilityThresholdDecrypt : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityThresholdDecrypt";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityThresholdDecrypt();


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
        public static new CapabilityThresholdDecrypt FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityThresholdDecrypt;
				}
		    var Result = new CapabilityThresholdDecrypt ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// The corresponding key is a threshold signature key.
	/// </summary>
	public partial class CapabilityThresholdSign : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityThresholdSign";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityThresholdSign();


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
        public static new CapabilityThresholdSign FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityThresholdSign;
				}
		    var Result = new CapabilityThresholdSign ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// with the Fair Electronic Exchange with Invisible Trusted Parties
	/// protocol.
	/// </summary>
	public partial class CapabilityThresholdMicali : CryptographicCapability {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CapabilityThresholdMicali";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CapabilityThresholdMicali();


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
        public static new CapabilityThresholdMicali FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CapabilityThresholdMicali;
				}
		    var Result = new CapabilityThresholdMicali ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class CatalogedBookmark : CatalogedEntry {
        /// <summary>
        /// </summary>

		public virtual string						Uri  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Title  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Path  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedBookmark();


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
			if (Path != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Path", 1);
					_writer.WriteString (Path);
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
        public static new CatalogedBookmark FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Uri" : {
					Uri = jsonReader.ReadString ();
					break;
					}
				case "Title" : {
					Title = jsonReader.ReadString ();
					break;
					}
				case "Path" : {
					Path = jsonReader.ReadString ();
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

		public virtual DareEnvelope						EnvelopedTask  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Title  {get; set;}
        /// <summary>
        ///Unique key.
        /// </summary>

		public virtual string						Key  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedTask();


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
        public static new CatalogedTask FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedTask" : {
					// An untagged structure
					EnvelopedTask = new DareEnvelope ();
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
	public partial class CatalogedApplication : CatalogedEntry {
        /// <summary>
        /// </summary>

		public virtual string						Key  {get; set;}
        /// <summary>
        ///Enveloped keys for use with Application
        /// </summary>

		public virtual List<DareEnvelope>				EnvelopedCapabilities  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedApplication";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedApplication();


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
        public static new CatalogedApplication FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplication;
				}
		    var Result = new CatalogedApplication ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Key" : {
					Key = jsonReader.ReadString ();
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

		public virtual string						UDF  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						ContactAddress  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedMember();


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
			if (UDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("UDF", 1);
					_writer.WriteString (UDF);
				}
			if (ContactAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ContactAddress", 1);
					_writer.WriteString (ContactAddress);
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
        public static new CatalogedMember FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "UDF" : {
					UDF = jsonReader.ReadString ();
					break;
					}
				case "ContactAddress" : {
					ContactAddress = jsonReader.ReadString ();
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
        /// </summary>

		public virtual ProfileGroup						Profile  {get; set;}
		
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
		public static new JSONObject _Factory () => new CatalogedGroup();


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
			if (Profile != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Profile", 1);
					Profile.Serialize (_writer, false);
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
        public static new CatalogedGroup FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Profile" : {
					// An untagged structure
					Profile = new ProfileGroup ();
					Profile.Deserialize (jsonReader);
 
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
	public partial class CatalogedApplicationSSH : CatalogedApplication {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedApplicationSSH";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedApplicationSSH();


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
        public static new CatalogedApplicationSSH FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplicationSSH;
				}
		    var Result = new CatalogedApplicationSSH ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class CatalogedApplicationMail : CatalogedApplication {
		
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
		public static new JSONObject _Factory () => new CatalogedApplicationMail();


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
        public static new CatalogedApplicationMail FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class CatalogedApplicationNetwork : CatalogedApplication {
		
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
		public static new JSONObject _Factory () => new CatalogedApplicationNetwork();


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
        public static new CatalogedApplicationNetwork FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	/// A data structure that is passed 
	/// </summary>
	public partial class DevicePreconfiguration : MeshItem {
        /// <summary>
        ///The device profile
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The device private key
        /// </summary>

		public virtual Key						PrivateKey  {get; set;}
        /// <summary>
        ///The connection URI. This would normally be printed on the device as a 
        ///QR code.
        /// </summary>

		public virtual string						ConnectUri  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "DevicePreconfiguration";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new DevicePreconfiguration();


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
        public static new DevicePreconfiguration FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as DevicePreconfiguration;
				}
		    var Result = new DevicePreconfiguration ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "PrivateKey" : {
					PrivateKey = Key.FromJSON (jsonReader, true) ;  // A tagged structure
					break;
					}
				case "ConnectUri" : {
					ConnectUri = jsonReader.ReadString ();
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
	public partial class Message : MeshItem {
        /// <summary>
        ///Unique per-message ID. When encapsulating a Mesh Message in a DARE envelope,
        ///the envelope EnvelopeID field MUST be a UDF fingerprint of the MessageID
        ///value. 
        /// </summary>

		public virtual string						MessageID  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Sender  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Recipient  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<Reference>				References  {get; set;}
		
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
		public static new JSONObject _Factory () => new Message();


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
			if (MessageID != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("MessageID", 1);
					_writer.WriteString (MessageID);
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
        public static new Message FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "MessageID" : {
					MessageID = jsonReader.ReadString ();
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
		public static new JSONObject _Factory () => new MessageComplete();


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
        public static new MessageComplete FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class MessagePIN : Message {
        /// <summary>
        /// </summary>

		public virtual string						Account  {get; set;}
        /// <summary>
        /// </summary>

		public virtual DateTime?						Expires  {get; set;}
		bool								__Automatic = false;
		private bool						_Automatic;
        /// <summary>
        ///If true, authentication against the PIN code is sufficient to complete
        ///the associated action without further authorization.
        /// </summary>

		public virtual bool						Automatic {
			get => _Automatic;
			set {_Automatic = value; __Automatic = true; }
			}
        /// <summary>
        ///PIN code bound to the specified action.
        /// </summary>

		public virtual string						SaltedPIN  {get; set;}
        /// <summary>
        ///The action to which this PIN code is bound.
        /// </summary>

		public virtual string						Action  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MessagePIN";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MessagePIN();


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
			if (__Automatic){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Automatic", 1);
					_writer.WriteBoolean (Automatic);
				}
			if (SaltedPIN != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SaltedPIN", 1);
					_writer.WriteString (SaltedPIN);
				}
			if (Action != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Action", 1);
					_writer.WriteString (Action);
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
        public static new MessagePIN FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as MessagePIN;
				}
		    var Result = new MessagePIN ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
				case "SaltedPIN" : {
					SaltedPIN = jsonReader.ReadString ();
					break;
					}
				case "Action" : {
					Action = jsonReader.ReadString ();
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
	public partial class RequestConnection : Message {
        /// <summary>
        ///
        /// </summary>

		public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///Device profile of the device making the request.
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///
        /// </summary>

		public virtual byte[]						ClientNonce  {get; set;}
        /// <summary>
        ///Fingerprint of the PIN value used to authenticate the request.
        /// </summary>

		public virtual string						PinUDF  {get; set;}
        /// <summary>
        ///Witness value calculated as KDF (Device.UDF + AccountAddress, ClientNonce)
        /// </summary>

		public virtual byte[]						PinWitness  {get; set;}
		
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
		public static new JSONObject _Factory () => new RequestConnection();


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
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (EnvelopedProfileDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_writer, false);
				}
			if (ClientNonce != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ClientNonce", 1);
					_writer.WriteBinary (ClientNonce);
				}
			if (PinUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PinUDF", 1);
					_writer.WriteString (PinUDF);
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
        public static new RequestConnection FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "ClientNonce" : {
					ClientNonce = jsonReader.ReadBinary ();
					break;
					}
				case "PinUDF" : {
					PinUDF = jsonReader.ReadString ();
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
	///
	/// Connection request message generated by a service on receipt of a valid
	/// MessageConnectionRequestClient
	/// </summary>
	public partial class AcknowledgeConnection : Message {
        /// <summary>
        ///The client connection request.
        /// </summary>

		public virtual DareEnvelope						EnvelopedRequestConnection  {get; set;}
        /// <summary>
        ///
        /// </summary>

		public virtual byte[]						ServerNonce  {get; set;}
        /// <summary>
        ///
        /// </summary>

		public virtual string						Witness  {get; set;}
		
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
		public static new JSONObject _Factory () => new AcknowledgeConnection();


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
        public static new AcknowledgeConnection FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedRequestConnection" : {
					// An untagged structure
					EnvelopedRequestConnection = new DareEnvelope ();
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
		public static new JSONObject _Factory () => new RespondConnection();


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
        public static new RespondConnection FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
	public partial class RequestContact : Message {
		bool								__Reply = false;
		private bool						_Reply;
        /// <summary>
        /// </summary>

		public virtual bool						Reply {
			get => _Reply;
			set {_Reply = value; __Reply = true; }
			}
        /// <summary>
        /// </summary>

		public virtual string						Subject  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						PinUDF  {get; set;}
        /// <summary>
        ///One time authentication code.
        /// </summary>

		public virtual string						PIN  {get; set;}
        /// <summary>
        ///The contact data.
        /// </summary>

		public virtual DareEnvelope						Self  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RequestContact";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RequestContact();


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
			if (__Reply){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Reply", 1);
					_writer.WriteBoolean (Reply);
				}
			if (Subject != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Subject", 1);
					_writer.WriteString (Subject);
				}
			if (PinUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PinUDF", 1);
					_writer.WriteString (PinUDF);
				}
			if (PIN != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PIN", 1);
					_writer.WriteString (PIN);
				}
			if (Self != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Self", 1);
					Self.Serialize (_writer, false);
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
        public static new RequestContact FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as RequestContact;
				}
		    var Result = new RequestContact ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Reply" : {
					Reply = jsonReader.ReadBoolean ();
					break;
					}
				case "Subject" : {
					Subject = jsonReader.ReadString ();
					break;
					}
				case "PinUDF" : {
					PinUDF = jsonReader.ReadString ();
					break;
					}
				case "PIN" : {
					PIN = jsonReader.ReadString ();
					break;
					}
				case "Self" : {
					// An untagged structure
					Self = new DareEnvelope ();
					Self.Deserialize (jsonReader);
 
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
	public partial class ReplyContact : RequestContact {
        /// <summary>
        /// </summary>

		public virtual byte[]						Nonce  {get; set;}
        /// <summary>
        ///Witness value over contact that was presented.
        /// </summary>

		public virtual byte[]						Witness  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ReplyContact";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new ReplyContact();


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
			((RequestContact)this).SerializeX(_writer, false, ref _first);
			if (Nonce != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Nonce", 1);
					_writer.WriteBinary (Nonce);
				}
			if (Witness != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Witness", 1);
					_writer.WriteBinary (Witness);
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
        public static new ReplyContact FromJSON (JSONReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ReplyContact;
				}
		    var Result = new ReplyContact ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Nonce" : {
					Nonce = jsonReader.ReadBinary ();
					break;
					}
				case "Witness" : {
					Witness = jsonReader.ReadBinary ();
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
        /// </summary>

		public virtual DareEnvelope						EncryptedGroupConnection  {get; set;}
		
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
		public static new JSONObject _Factory () => new GroupInvitation();


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
			if (EncryptedGroupConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EncryptedGroupConnection", 1);
					EncryptedGroupConnection.Serialize (_writer, false);
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
        public static new GroupInvitation FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Text" : {
					Text = jsonReader.ReadString ();
					break;
					}
				case "EncryptedGroupConnection" : {
					// An untagged structure
					EncryptedGroupConnection = new DareEnvelope ();
					EncryptedGroupConnection.Deserialize (jsonReader);
 
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
		public static new JSONObject _Factory () => new RequestConfirmation();


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
        public static new RequestConfirmation FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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

		public virtual DareEnvelope						Request  {get; set;}
		bool								__Accept = false;
		private bool						_Accept;
        /// <summary>
        /// </summary>

		public virtual bool						Accept {
			get => _Accept;
			set {_Accept = value; __Accept = true; }
			}
		
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
		public static new JSONObject _Factory () => new ResponseConfirmation();


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
			if (__Accept){
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
        public static new ResponseConfirmation FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
			switch (tag) {
				case "Request" : {
					// An untagged structure
					Request = new DareEnvelope ();
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
		public static new JSONObject _Factory () => new RequestTask();


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
        public static new RequestTask FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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
		public static new JSONObject _Factory () => new MessageClaim();


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
        public static new MessageClaim FromJSON (JSONReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JSONReader jsonReader, string tag) {
			
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

	}

