
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
//  This file was automatically generated at 2/24/2021 12:20:46 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.566
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
				new Dictionary<string, JsonFactoryDelegate> () {

			{"KeyData", KeyData._Factory},
			{"CompositePrivate", CompositePrivate._Factory},
			{"Assertion", Assertion._Factory},
			{"Condition", Condition._Factory},
			{"Connection", Connection._Factory},
			{"Activation", Activation._Factory},
			{"ActivationEntry", ActivationEntry._Factory},
			{"Profile", Profile._Factory},
			{"ProfileDevice", ProfileDevice._Factory},
			{"ProfileAccount", ProfileAccount._Factory},
			{"ProfileUser", ProfileUser._Factory},
			{"ProfileGroup", ProfileGroup._Factory},
			{"ProfileService", ProfileService._Factory},
			{"ProfileHost", ProfileHost._Factory},
			{"ConnectionDevice", ConnectionDevice._Factory},
			{"ConnectionApplication", ConnectionApplication._Factory},
			{"ConnectionGroup", ConnectionGroup._Factory},
			{"ConnectionService", ConnectionService._Factory},
			{"ConnectionHost", ConnectionHost._Factory},
			{"ActivationDevice", ActivationDevice._Factory},
			{"ActivationAccount", ActivationAccount._Factory},
			{"ActivationApplication", ActivationApplication._Factory},
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
			{"CatalogedDevice", CatalogedDevice._Factory},
			{"CatalogedPublication", CatalogedPublication._Factory},
			{"CatalogedCredential", CatalogedCredential._Factory},
			{"CatalogedNetwork", CatalogedNetwork._Factory},
			{"CatalogedContact", CatalogedContact._Factory},
			{"CatalogedAccess", CatalogedAccess._Factory},
			{"CryptographicCapability", CryptographicCapability._Factory},
			{"CapabilityDecrypt", CapabilityDecrypt._Factory},
			{"CapabilityDecryptPartial", CapabilityDecryptPartial._Factory},
			{"CapabilityDecryptServiced", CapabilityDecryptServiced._Factory},
			{"CapabilitySign", CapabilitySign._Factory},
			{"CapabilityKeyGenerate", CapabilityKeyGenerate._Factory},
			{"CapabilityFairExchange", CapabilityFairExchange._Factory},
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
			{"MessageError", MessageError._Factory},
			{"MessageComplete", MessageComplete._Factory},
			{"MessagePinValidated", MessagePinValidated._Factory},
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
			{"ProcessResult", ProcessResult._Factory}			};

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
	/// </summary>
	public partial class Connection : Assertion {
        /// <summary>
        ///UDF of the connection target.
        /// </summary>

		public virtual string						SubjectUdf  {get; set;}
        /// <summary>
        ///UDF of the connection source.
        /// </summary>

		public virtual string						AuthorityUdf  {get; set;}
		
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
			if (SubjectUdf != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SubjectUdf", 1);
					_writer.WriteString (SubjectUdf);
				}
			if (AuthorityUdf != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AuthorityUdf", 1);
					_writer.WriteString (AuthorityUdf);
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
				case "SubjectUdf" : {
					SubjectUdf = jsonReader.ReadString ();
					break;
					}
				case "AuthorityUdf" : {
					AuthorityUdf = jsonReader.ReadString ();
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
        ///Secret seed used to derive keys that are not explicitly specified.
        /// </summary>

		public virtual string						ActivationKey  {get; set;}
        /// <summary>
        ///Activation of named resources.
        /// </summary>

		public virtual List<ActivationEntry>				Entries  {get; set;}
		
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
        ///any circumstance.
        /// </summary>

		public virtual KeyData						ProfileSignature  {get; set;}
		
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
        ///Description of the device
        /// </summary>

		public virtual string						Description  {get; set;}
        /// <summary>
        ///Base key contribution for encryption keys. 
        ///Also used to decrypt activation data sent to the device
        ///during connection to an account.
        /// </summary>

		public virtual KeyData						BaseEncryption  {get; set;}
        /// <summary>
        ///Base key contribution for authentication keys. 
        ///Also used to authenticate the device
        ///during connection to an account.
        /// </summary>

		public virtual KeyData						BaseAuthentication  {get; set;}
        /// <summary>
        ///Base key contribution for signature keys. 
        /// </summary>

		public virtual KeyData						BaseSignature  {get; set;}
		
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
			if (Description != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Description", 1);
					_writer.WriteString (Description);
				}
			if (BaseEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("BaseEncryption", 1);
					BaseEncryption.Serialize (_writer, false);
				}
			if (BaseAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("BaseAuthentication", 1);
					BaseAuthentication.Serialize (_writer, false);
				}
			if (BaseSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("BaseSignature", 1);
					BaseSignature.Serialize (_writer, false);
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
				case "Description" : {
					Description = jsonReader.ReadString ();
					break;
					}
				case "BaseEncryption" : {
					// An untagged structure
					BaseEncryption = new KeyData ();
					BaseEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "BaseAuthentication" : {
					// An untagged structure
					BaseAuthentication = new KeyData ();
					BaseAuthentication.Deserialize (jsonReader);
 
					break;
					}
				case "BaseSignature" : {
					// An untagged structure
					BaseSignature = new KeyData ();
					BaseSignature.Deserialize (jsonReader);
 
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
        ///Key currently used to encrypt data under this profile
        /// </summary>

		public virtual KeyData						AccountEncryption  {get; set;}
        /// <summary>
        ///Key used to sign connection assertions to the account.
        /// </summary>

		public virtual KeyData						AdministratorSignature  {get; set;}
		
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
        ///Key used to authenticate requests made under this user account.
        /// </summary>

		public virtual KeyData						AccountAuthentication  {get; set;}
        /// <summary>
        ///Key used to sign data under the account.
        /// </summary>

		public virtual KeyData						AccountSignature  {get; set;}
		
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
			if (AccountAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAuthentication", 1);
					AccountAuthentication.Serialize (_writer, false);
				}
			if (AccountSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountSignature", 1);
					AccountSignature.Serialize (_writer, false);
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
				case "AccountAuthentication" : {
					// An untagged structure
					AccountAuthentication = new KeyData ();
					AccountAuthentication.Deserialize (jsonReader);
 
					break;
					}
				case "AccountSignature" : {
					// An untagged structure
					AccountSignature = new KeyData ();
					AccountSignature.Deserialize (jsonReader);
 
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
	/// </summary>
	public partial class ProfileHost : Profile {
        /// <summary>
        ///Key used to authenticate service connections.
        /// </summary>

		public virtual KeyData						KeyAuthentication  {get; set;}
        /// <summary>
        ///Key used to pass encrypted data to the device such as a
        /// </summary>

		public virtual KeyData						KeyEncryption  {get; set;}
		
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
	///
	/// Connection assertion used to authenticate service requests made
	/// by a device.
	/// </summary>
	public partial class ConnectionDevice : Connection {
        /// <summary>
        ///The account address
        /// </summary>

		public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

		public virtual KeyData						DeviceSignature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

		public virtual KeyData						DeviceEncryption  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

		public virtual KeyData						DeviceAuthentication  {get; set;}
		
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
			((Connection)this).SerializeX(_writer, false, ref _first);
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (DeviceSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceSignature", 1);
					DeviceSignature.Serialize (_writer, false);
				}
			if (DeviceEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceEncryption", 1);
					DeviceEncryption.Serialize (_writer, false);
				}
			if (DeviceAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceAuthentication", 1);
					DeviceAuthentication.Serialize (_writer, false);
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
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "DeviceSignature" : {
					// An untagged structure
					DeviceSignature = new KeyData ();
					DeviceSignature.Deserialize (jsonReader);
 
					break;
					}
				case "DeviceEncryption" : {
					// An untagged structure
					DeviceEncryption = new KeyData ();
					DeviceEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "DeviceAuthentication" : {
					// An untagged structure
					DeviceAuthentication = new KeyData ();
					DeviceAuthentication.Deserialize (jsonReader);
 
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
	public partial class ActivationDevice : Activation {
        /// <summary>
        ///The UDF of the account
        /// </summary>

		public virtual string						AccountUdf  {get; set;}
		
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
		public static new JsonObject _Factory () => new ActivationDevice();


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
        public static new ActivationDevice FromJson (JsonReader jsonReader, bool tagged=true) {
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
	/// </summary>
	public partial class ActivationAccount : Activation {
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

		public virtual KeyData						AccountEncryption  {get; set;}
        /// <summary>
        ///Grant access to ProfileUser account authentication key
        /// </summary>

		public virtual KeyData						AccountAuthentication  {get; set;}
        /// <summary>
        ///Grant access to ProfileUser account signature key
        /// </summary>

		public virtual KeyData						AccountSignature  {get; set;}
		
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
			if (AccountEncryption != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountEncryption", 1);
					AccountEncryption.Serialize (_writer, false);
				}
			if (AccountAuthentication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAuthentication", 1);
					AccountAuthentication.Serialize (_writer, false);
				}
			if (AccountSignature != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountSignature", 1);
					AccountSignature.Serialize (_writer, false);
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
				case "AccountEncryption" : {
					// An untagged structure
					AccountEncryption = new KeyData ();
					AccountEncryption.Deserialize (jsonReader);
 
					break;
					}
				case "AccountAuthentication" : {
					// An untagged structure
					AccountAuthentication = new KeyData ();
					AccountAuthentication.Deserialize (jsonReader);
 
					break;
					}
				case "AccountSignature" : {
					// An untagged structure
					AccountSignature = new KeyData ();
					AccountSignature.Deserialize (jsonReader);
 
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
		public static new JsonObject _Factory () => new Task();


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
        public static new Task FromJson (JsonReader jsonReader, bool tagged=true) {
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
        ///The Mesh profile
        /// </summary>

		public virtual Enveloped<ProfileAccount>						EnvelopedProfileUser  {get; set;}
        /// <summary>
        ///The device profile
        /// </summary>

		public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The public assertion demonstrating connection of the Device to the Mesh
        /// </summary>

		public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionUser  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

		public virtual Enveloped<ActivationDevice>						EnvelopedActivationDevice  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

		public virtual Enveloped<ActivationAccount>						EnvelopedActivationAccount  {get; set;}
        /// <summary>
        ///Application activations granted to the device.
        /// </summary>

		public virtual List<Enveloped<ActivationApplication>>				EnvelopedActivationApplication  {get; set;}
		
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
			if (EnvelopedConnectionUser != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnectionUser", 1);
					EnvelopedConnectionUser.Serialize (_writer, false);
				}
			if (EnvelopedActivationDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedActivationDevice", 1);
					EnvelopedActivationDevice.Serialize (_writer, false);
				}
			if (EnvelopedActivationAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedActivationAccount", 1);
					EnvelopedActivationAccount.Serialize (_writer, false);
				}
			if (EnvelopedActivationApplication != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedActivationApplication", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EnvelopedActivationApplication) {
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
				case "EnvelopedConnectionUser" : {
					// An untagged structure
					EnvelopedConnectionUser = new Enveloped<ConnectionDevice> ();
					EnvelopedConnectionUser.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationDevice" : {
					// An untagged structure
					EnvelopedActivationDevice = new Enveloped<ActivationDevice> ();
					EnvelopedActivationDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationAccount" : {
					// An untagged structure
					EnvelopedActivationAccount = new Enveloped<ActivationAccount> ();
					EnvelopedActivationAccount.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationApplication" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					EnvelopedActivationApplication = new List <Enveloped<ActivationApplication>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<ActivationApplication> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<ActivationApplication> (jsonReader);
						EnvelopedActivationApplication.Add (_Item);
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
			if (__Self){
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

		public virtual CryptographicCapability						Capability  {get; set;}
		
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
					Capability = CryptographicCapability.FromJson (jsonReader, true) ;  // A tagged structure
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
        ///The identifier of the capability. If this is a user capability, MUST match the
        ///KeyData identifier. If this is a serviced capability, MUST match the value of
        ///ServiceId on the corresponding service capability.
        /// </summary>

		public virtual string						Id  {get; set;}
        /// <summary>
        ///The key that enables the capability
        /// </summary>

		public virtual KeyData						KeyData  {get; set;}
        /// <summary>
        ///One or more enveloped key shares.
        /// </summary>

		public virtual List<Enveloped<KeyData>>				EnvelopedKeyShares  {get; set;}
        /// <summary>
        ///The identifier of the resource that is controlled using the key.
        /// </summary>

		public virtual string						SubjectId  {get; set;}
        /// <summary>
        ///The address of the resource that is controlled using the key.
        /// </summary>

		public virtual string						SubjectAddress  {get; set;}
		
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
			if (Id != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Id", 1);
					_writer.WriteString (Id);
				}
			if (KeyData != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("KeyData", 1);
					KeyData.Serialize (_writer, false);
				}
			if (EnvelopedKeyShares != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedKeyShares", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EnvelopedKeyShares) {
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

			if (SubjectId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SubjectId", 1);
					_writer.WriteString (SubjectId);
				}
			if (SubjectAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("SubjectAddress", 1);
					_writer.WriteString (SubjectAddress);
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
				case "Id" : {
					Id = jsonReader.ReadString ();
					break;
					}
				case "KeyData" : {
					// An untagged structure
					KeyData = new KeyData ();
					KeyData.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedKeyShares" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					EnvelopedKeyShares = new List <Enveloped<KeyData>> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Enveloped<KeyData> ();
						_Item.Deserialize (jsonReader);
						// var _Item = new Enveloped<KeyData> (jsonReader);
						EnvelopedKeyShares.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "SubjectId" : {
					SubjectId = jsonReader.ReadString ();
					break;
					}
				case "SubjectAddress" : {
					SubjectAddress = jsonReader.ReadString ();
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
	/// The corresponding key is a decryption key
	/// </summary>
	public partial class CapabilityDecrypt : CryptographicCapability {
		
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
	///
	/// The corresponding key is an encryption key
	/// </summary>
	public partial class CapabilityDecryptServiced : CapabilityDecrypt {
        /// <summary>
        ///UDF of trust root under which request to use a serviced capability must be 
        ///authorized. [Only present for a serviced capability]
        /// </summary>

		public virtual string						AuthenticationId  {get; set;}
		
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

		public virtual Enveloped<Task>						EnvelopedTask  {get; set;}
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
					EnvelopedTask = new Enveloped<Task> ();
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
		public static new JsonObject _Factory () => new CatalogedApplication();


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
        public static new CatalogedApplication FromJson (JsonReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
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

		public virtual string						ContactAddress  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						MemberCapabilityId  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						ServiceCapabilityId  {get; set;}
		
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
        ///The Mesh profile
        /// </summary>

		public virtual Enveloped<ProfileAccount>						EnvelopedProfileGroup  {get; set;}
        /// <summary>
        ///The activation of the device within the Mesh account
        /// </summary>

		public virtual Enveloped<ActivationAccount>						EnvelopedActivationAccount  {get; set;}
		
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
			if (EnvelopedProfileGroup != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileGroup", 1);
					EnvelopedProfileGroup.Serialize (_writer, false);
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
				case "EnvelopedProfileGroup" : {
					// An untagged structure
					EnvelopedProfileGroup = new Enveloped<ProfileAccount> ();
					EnvelopedProfileGroup.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedActivationAccount" : {
					// An untagged structure
					EnvelopedActivationAccount = new Enveloped<ActivationAccount> ();
					EnvelopedActivationAccount.Deserialize (jsonReader);
 
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
		public static new JsonObject _Factory () => new CatalogedApplicationSSH();


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
        public static new CatalogedApplicationSSH FromJson (JsonReader jsonReader, bool tagged=true) {
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
	///
	/// A data structure that is passed 
	/// </summary>
	public partial class DevicePreconfiguration : MeshItem {
        /// <summary>
        ///The device profile
        /// </summary>

		public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The device connection
        /// </summary>

		public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionDevice  {get; set;}
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
		public static new JsonObject _Factory () => new DevicePreconfiguration();


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
			if (EnvelopedConnectionDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnectionDevice", 1);
					EnvelopedConnectionDevice.Serialize (_writer, false);
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
        public static new DevicePreconfiguration FromJson (JsonReader jsonReader, bool tagged=true) {
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
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedConnectionDevice" : {
					// An untagged structure
					EnvelopedConnectionDevice = new Enveloped<ConnectionDevice> ();
					EnvelopedConnectionDevice.Deserialize (jsonReader);
 
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
	public partial class MessagePinValidated : Message {
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
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MessagePinValidated";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new MessagePinValidated();


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
        public static new MessagePinValidated FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as MessagePinValidated;
				}
		    var Result = new MessagePinValidated ();
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

		public virtual string						SaltedPin  {get; set;}
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
			if (__Automatic){
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
	public partial class RequestConnection : MessagePinValidated {
        /// <summary>
        ///
        /// </summary>

		public virtual string						AccountAddress  {get; set;}
		
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
			((MessagePinValidated)this).SerializeX(_writer, false, ref _first);
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
	public partial class MessageContact : MessagePinValidated {
		bool								__Reply = false;
		private bool						_Reply;
        /// <summary>
        ///If true, requests that the recipient return their own contact information
        ///in reply.
        /// </summary>

		public virtual bool						Reply {
			get => _Reply;
			set {_Reply = value; __Reply = true; }
			}
        /// <summary>
        ///Optional explanation of the reason for the request.
        /// </summary>

		public virtual string						Subject  {get; set;}
        /// <summary>
        ///One time authentication code supplied to a recipient to allow authentication
        ///of the response.
        /// </summary>

		public virtual string						PIN  {get; set;}
		
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
			((MessagePinValidated)this).SerializeX(_writer, false, ref _first);
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
		bool								__Success = false;
		private bool						_Success;
        /// <summary>
        /// </summary>

		public virtual bool						Success {
			get => _Success;
			set {_Success = value; __Success = true; }
			}
        /// <summary>
        ///The error report code.
        /// </summary>

		public virtual string						ErrorReport  {get; set;}
		
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
			if (__Success){
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

	}

