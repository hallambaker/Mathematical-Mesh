
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

			{"PublicKey", PublicKey._Factory},
			{"KeyComposite", KeyComposite._Factory},
			{"KeyOverlay", KeyOverlay._Factory},
			{"EscrowedKeySet", EscrowedKeySet._Factory},
			{"DeviceRecryptionKey", DeviceRecryptionKey._Factory},
			{"Assertion", Assertion._Factory},
			{"Condition", Condition._Factory},
			{"Profile", Profile._Factory},
			{"ProfileMesh", ProfileMesh._Factory},
			{"ProfileDevice", ProfileDevice._Factory},
			{"ProfileService", ProfileService._Factory},
			{"ProfileAccount", ProfileAccount._Factory},
			{"ProfileGroup", ProfileGroup._Factory},
			{"ProfileHost", ProfileHost._Factory},
			{"Connection", Connection._Factory},
			{"Permission", Permission._Factory},
			{"ConnectionDevice", ConnectionDevice._Factory},
			{"ConnectionAccount", ConnectionAccount._Factory},
			{"ConnectionService", ConnectionService._Factory},
			{"ConnectionHost", ConnectionHost._Factory},
			{"ConnectionApplication", ConnectionApplication._Factory},
			{"Activation", Activation._Factory},
			{"ActivationDevice", ActivationDevice._Factory},
			{"ActivationAccount", ActivationAccount._Factory},
			{"Contact", Contact._Factory},
			{"Role", Role._Factory},
			{"Address", Address._Factory},
			{"Location", Location._Factory},
			{"Reference", Reference._Factory},
			{"Task", Task._Factory},
			{"CatalogedEntry", CatalogedEntry._Factory},
			{"CatalogedDevice", CatalogedDevice._Factory},
			{"AccountEntry", AccountEntry._Factory},
			{"CatalogedCredential", CatalogedCredential._Factory},
			{"CatalogedNetwork", CatalogedNetwork._Factory},
			{"CatalogedContact", CatalogedContact._Factory},
			{"CatalogedContactRecryption", CatalogedContactRecryption._Factory},
			{"CatalogedBookmark", CatalogedBookmark._Factory},
			{"CatalogedTask", CatalogedTask._Factory},
			{"CatalogedApplication", CatalogedApplication._Factory},
			{"CatalogedMember", CatalogedMember._Factory},
			{"CatalogedGroup", CatalogedGroup._Factory},
			{"CatalogedApplicationSSH", CatalogedApplicationSSH._Factory},
			{"CatalogedApplicationMail", CatalogedApplicationMail._Factory},
			{"CatalogedApplicationNetwork", CatalogedApplicationNetwork._Factory},
			{"Message", Message._Factory},
			{"MessageComplete", MessageComplete._Factory},
			{"MessagePIN", MessagePIN._Factory},
			{"RequestConnection", RequestConnection._Factory},
			{"AcknowledgeConnection", AcknowledgeConnection._Factory},
			{"RequestContact", RequestContact._Factory},
			{"RequestConfirmation", RequestConfirmation._Factory},
			{"ResponseConfirmation", ResponseConfirmation._Factory},
			{"RequestTask", RequestTask._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) => 
			Out = JSONReader.ReadTaggedObject(_TagDictionary);

		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// The PublicKey class is used to describe public key pairs and 
	/// trust assertions associated with a public key.
	/// </summary>
	public partial class PublicKey : MeshItem {
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
		public new const string __Tag = "PublicKey";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new PublicKey();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (X509Certificate != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509Certificate", 1);
					_Writer.WriteBinary (X509Certificate);
				}
			if (X509Chain != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509Chain", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in X509Chain) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteBinary (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (X509CSR != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("X509CSR", 1);
					_Writer.WriteBinary (X509CSR);
				}
			if (PublicParameters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PublicParameters", 1);
					// expand this to a tagged structure
					//PublicParameters.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(PublicParameters._Tag, 1);
						bool firstinner = true;
						PublicParameters.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (PrivateParameters != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PrivateParameters", 1);
					// expand this to a tagged structure
					//PrivateParameters.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(PrivateParameters._Tag, 1);
						bool firstinner = true;
						PrivateParameters.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new PublicKey FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PublicKey;
				}
		    var Result = new PublicKey ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "X509Certificate" : {
					X509Certificate = JSONReader.ReadBinary ();
					break;
					}
				case "X509Chain" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					X509Chain = new List <byte[]> ();
					while (_Going) {
						byte[] _Item = JSONReader.ReadBinary ();
						X509Chain.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "X509CSR" : {
					X509CSR = JSONReader.ReadBinary ();
					break;
					}
				case "PublicParameters" : {
					PublicParameters = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "PrivateParameters" : {
					PrivateParameters = Key.FromJSON (JSONReader, true) ;  // A tagged structure
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Public != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Public", 1);
					// expand this to a tagged structure
					//Public.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Public._Tag, 1);
						bool firstinner = true;
						Public.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (Part != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Part", 1);
					// expand this to a tagged structure
					//Part.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Part._Tag, 1);
						bool firstinner = true;
						Part.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (Service != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Service", 1);
					_Writer.WriteString (Service);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new KeyComposite FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as KeyComposite;
				}
		    var Result = new KeyComposite ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Public" : {
					Public = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "Part" : {
					Part = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "Service" : {
					Service = JSONReader.ReadString ();
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
	public partial class KeyOverlay : MeshItem {
        /// <summary>
        ///Fingerprint of the resulting composite key (to allow verification)
        /// </summary>

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///Fingerprint specifying the base key
        /// </summary>

		public virtual string						BaseUDF  {get; set;}
        /// <summary>
        ///The overlay key contribution.
        /// </summary>

		public virtual Key						Overlay  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "KeyOverlay";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new KeyOverlay();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (BaseUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("BaseUDF", 1);
					_Writer.WriteString (BaseUDF);
				}
			if (Overlay != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Overlay", 1);
					// expand this to a tagged structure
					//Overlay.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Overlay._Tag, 1);
						bool firstinner = true;
						Overlay.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new KeyOverlay FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as KeyOverlay;
				}
		    var Result = new KeyOverlay ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "BaseUDF" : {
					BaseUDF = JSONReader.ReadString ();
					break;
					}
				case "Overlay" : {
					Overlay = Key.FromJSON (JSONReader, true) ;  // A tagged structure
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (MasterSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterSignatureKey", 1);
					// expand this to a tagged structure
					//MasterSignatureKey.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(MasterSignatureKey._Tag, 1);
						bool firstinner = true;
						MasterSignatureKey.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (MasterEncryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterEncryptionKey", 1);
					// expand this to a tagged structure
					//MasterEncryptionKey.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(MasterEncryptionKey._Tag, 1);
						bool firstinner = true;
						MasterEncryptionKey.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (MasterEscrowKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterEscrowKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MasterEscrowKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new EscrowedKeySet FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as EscrowedKeySet;
				}
		    var Result = new EscrowedKeySet ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "MasterSignatureKey" : {
					MasterSignatureKey = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "MasterEncryptionKey" : {
					MasterEncryptionKey = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "MasterEscrowKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MasterEscrowKeys = new List <Key> ();
					while (_Going) {
						var _Item = Key.FromJSON (JSONReader, true); // a tagged structure
						MasterEscrowKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
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
	public partial class DeviceRecryptionKey : MeshItem {
        /// <summary>
        ///The fingerprint of the encryption key
        /// </summary>

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///The recryption key
        /// </summary>

		public virtual PublicKey						RecryptionKey  {get; set;}
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (RecryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionKey", 1);
					RecryptionKey.Serialize (_Writer, false);
				}
			if (EnvelopedRecryptionKeyDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedRecryptionKeyDevice", 1);
					EnvelopedRecryptionKeyDevice.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new DeviceRecryptionKey FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DeviceRecryptionKey;
				}
		    var Result = new DeviceRecryptionKey ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "RecryptionKey" : {
					// An untagged structure
					RecryptionKey = new PublicKey ();
					RecryptionKey.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedRecryptionKeyDevice" : {
					// An untagged structure
					EnvelopedRecryptionKeyDevice = new DareEnvelope ();
					EnvelopedRecryptionKeyDevice.Deserialize (JSONReader);
 
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Names != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Names", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Names) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Updated != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Updated", 1);
					_Writer.WriteDateTime (Updated);
				}
			if (NotaryToken != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NotaryToken", 1);
					_Writer.WriteString (NotaryToken);
				}
			if (Conditions != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Conditions", 1);
					// expand this to a tagged structure
					//Conditions.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Conditions._Tag, 1);
						bool firstinner = true;
						Conditions.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Assertion FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Assertion;
				}
			throw new CannotCreateAbstract();
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Names" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Names = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Names.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Updated" : {
					Updated = JSONReader.ReadDateTime ();
					break;
					}
				case "NotaryToken" : {
					NotaryToken = JSONReader.ReadString ();
					break;
					}
				case "Conditions" : {
					Conditions = Condition.FromJSON (JSONReader, true) ;  // A tagged structure
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Condition FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Condition;
				}
			throw new CannotCreateAbstract();
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
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

		public virtual PublicKey						KeyOfflineSignature  {get; set;}
        /// <summary>
        ///A Personal profile contains at least one OSK which is used to sign 
        ///device administration application profiles.
        /// </summary>

		public virtual List<PublicKey>				KeysOnlineSignature  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Assertion)this).SerializeX(_Writer, false, ref _first);
			if (KeyOfflineSignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyOfflineSignature", 1);
					KeyOfflineSignature.Serialize (_Writer, false);
				}
			if (KeysOnlineSignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeysOnlineSignature", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeysOnlineSignature) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Profile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Profile;
				}
			throw new CannotCreateAbstract();
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyOfflineSignature" : {
					// An untagged structure
					KeyOfflineSignature = new PublicKey ();
					KeyOfflineSignature.Deserialize (JSONReader);
 
					break;
					}
				case "KeysOnlineSignature" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					KeysOnlineSignature = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						KeysOnlineSignature.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual List<PublicKey>				KeysMasterEscrow  {get; set;}
        /// <summary>
        ///Key used to pass encrypted data to the device such as a
        ///DeviceUseEntry
        /// </summary>

		public virtual PublicKey						KeyEncryption  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (KeysMasterEscrow != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeysMasterEscrow", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in KeysMasterEscrow) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileMesh FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileMesh;
				}
		    var Result = new ProfileMesh ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeysMasterEscrow" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					KeysMasterEscrow = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						KeysMasterEscrow.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new PublicKey ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual PublicKey						KeyEncryption  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made by the device.
        /// </summary>

		public virtual PublicKey						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (Description != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Description", 1);
					_Writer.WriteString (Description);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileDevice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileDevice;
				}
		    var Result = new ProfileDevice ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Description" : {
					Description = JSONReader.ReadString ();
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new PublicKey ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new PublicKey ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual PublicKey						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileService FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileService;
				}
		    var Result = new ProfileService ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new PublicKey ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual List<string>				ServiceIDs  {get; set;}
        /// <summary>
        ///Master profile of the account being registered.
        /// </summary>

		public virtual string						MeshProfileUDF  {get; set;}
        /// <summary>
        ///Key used to encrypt data under this profile
        /// </summary>

		public virtual PublicKey						KeyEncryption  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (ServiceIDs != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServiceIDs", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ServiceIDs) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (MeshProfileUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MeshProfileUDF", 1);
					_Writer.WriteString (MeshProfileUDF);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileAccount FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileAccount;
				}
		    var Result = new ProfileAccount ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ServiceIDs" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					ServiceIDs = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						ServiceIDs.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "MeshProfileUDF" : {
					MeshProfileUDF = JSONReader.ReadString ();
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new PublicKey ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileGroup FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileGroup;
				}
		    var Result = new ProfileGroup ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual PublicKey						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ProfileHost FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ProfileHost;
				}
		    var Result = new ProfileHost ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new PublicKey ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Assertion)this).SerializeX(_Writer, false, ref _first);
			if (SubjectUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SubjectUDF", 1);
					_Writer.WriteString (SubjectUDF);
				}
			if (AuthorityUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AuthorityUDF", 1);
					_Writer.WriteString (AuthorityUDF);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Connection FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Connection;
				}
		    var Result = new Connection ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SubjectUDF" : {
					SubjectUDF = JSONReader.ReadString ();
					break;
					}
				case "AuthorityUDF" : {
					AuthorityUDF = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Name != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Name", 1);
					_Writer.WriteString (Name);
				}
			if (Role != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Role", 1);
					_Writer.WriteString (Role);
				}
			if (Capabilities != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Capabilities", 1);
					Capabilities.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Permission FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Permission;
				}
		    var Result = new Permission ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Name" : {
					Name = JSONReader.ReadString ();
					break;
					}
				case "Role" : {
					Role = JSONReader.ReadString ();
					break;
					}
				case "Capabilities" : {
					// An untagged structure
					Capabilities = new DareEnvelope ();
					Capabilities.Deserialize (JSONReader);
 
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
	public partial class ConnectionDevice : Connection {
        /// <summary>
        ///List of the permissions that the device has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeySignature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeyEncryption  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Connection)this).SerializeX(_Writer, false, ref _first);
			if (Permissions != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Permissions", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (KeySignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_Writer, false);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectionDevice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionDevice;
				}
		    var Result = new ConnectionDevice ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Permission (JSONReader);
						Permissions.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new PublicKey ();
					KeySignature.Deserialize (JSONReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new PublicKey ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new PublicKey ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        ///List of the permissions that the device has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The signature key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeySignature  {get; set;}
        /// <summary>
        ///The encryption key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeyEncryption  {get; set;}
        /// <summary>
        ///The authentication key for use of the device under the profile
        /// </summary>

		public virtual PublicKey						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Connection)this).SerializeX(_Writer, false, ref _first);
			if (Permissions != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Permissions", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (KeySignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_Writer, false);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectionAccount FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionAccount;
				}
		    var Result = new ConnectionAccount ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Permission (JSONReader);
						Permissions.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new PublicKey ();
					KeySignature.Deserialize (JSONReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new PublicKey ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new PublicKey ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Connection)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectionService FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionService;
				}
		    var Result = new ConnectionService ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Connection)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectionHost FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionHost;
				}
		    var Result = new ConnectionHost ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Connection)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ConnectionApplication FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionApplication;
				}
		    var Result = new ConnectionApplication ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Assertion)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Activation FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Activation;
				}
		    var Result = new Activation ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class ActivationDevice : Assertion {
        /// <summary>
        ///The signed AssertionDeviceConnection.
        /// </summary>

		public virtual DareEnvelope						EnvelopedAssertionDeviceConnection  {get; set;}
        /// <summary>
        ///List of application and account activation data. Keys, etc.
        /// </summary>

		public virtual List<Activation>				Activations  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account signature key from the
        ///device signature key 
        /// </summary>

		public virtual KeyOverlay						KeySignature  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account encryption key from the
        ///device encryption key 
        /// </summary>

		public virtual KeyOverlay						KeyEncryption  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account authentication key from the
        ///device authentication key 
        /// </summary>

		public virtual KeyOverlay						KeyAuthentication  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Assertion)this).SerializeX(_Writer, false, ref _first);
			if (EnvelopedAssertionDeviceConnection != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedAssertionDeviceConnection", 1);
					EnvelopedAssertionDeviceConnection.Serialize (_Writer, false);
				}
			if (Activations != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Activations", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Activations) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (KeySignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_Writer, false);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ActivationDevice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ActivationDevice;
				}
		    var Result = new ActivationDevice ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EnvelopedAssertionDeviceConnection" : {
					// An untagged structure
					EnvelopedAssertionDeviceConnection = new DareEnvelope ();
					EnvelopedAssertionDeviceConnection.Deserialize (JSONReader);
 
					break;
					}
				case "Activations" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Activations = new List <Activation> ();
					while (_Going) {
						var _Item = Activation.FromJSON (JSONReader, true); // a tagged structure
						Activations.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new KeyOverlay ();
					KeySignature.Deserialize (JSONReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyOverlay ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyOverlay ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        ///The key contribution for the decryption key for the device. NB this is 
        ///NOT an overlay on the device signature key, it is an overlay on the 
        ///corresponding recryption key.
        /// </summary>

		public virtual KeyComposite						KeyGroup  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account encryption key from the
        ///device encryption key 		
        /// </summary>

		public virtual KeyOverlay						KeyEncryption  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account authentication key from the
        ///device authentication key 		
        /// </summary>

		public virtual KeyOverlay						KeyAuthentication  {get; set;}
        /// <summary>
        ///The key overlay used to generate the account signature key from the
        ///device signature key 
        /// </summary>

		public virtual KeyOverlay						KeySignature  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Activation)this).SerializeX(_Writer, false, ref _first);
			if (AccountUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountUDF", 1);
					_Writer.WriteString (AccountUDF);
				}
			if (KeyGroup != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyGroup", 1);
					KeyGroup.Serialize (_Writer, false);
				}
			if (KeyEncryption != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyEncryption", 1);
					KeyEncryption.Serialize (_Writer, false);
				}
			if (KeyAuthentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeyAuthentication", 1);
					KeyAuthentication.Serialize (_Writer, false);
				}
			if (KeySignature != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("KeySignature", 1);
					KeySignature.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ActivationAccount FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ActivationAccount;
				}
		    var Result = new ActivationAccount ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AccountUDF" : {
					AccountUDF = JSONReader.ReadString ();
					break;
					}
				case "KeyGroup" : {
					// An untagged structure
					KeyGroup = new KeyComposite ();
					KeyGroup.Deserialize (JSONReader);
 
					break;
					}
				case "KeyEncryption" : {
					// An untagged structure
					KeyEncryption = new KeyOverlay ();
					KeyEncryption.Deserialize (JSONReader);
 
					break;
					}
				case "KeyAuthentication" : {
					// An untagged structure
					KeyAuthentication = new KeyOverlay ();
					KeyAuthentication.Deserialize (JSONReader);
 
					break;
					}
				case "KeySignature" : {
					// An untagged structure
					KeySignature = new KeyOverlay ();
					KeySignature.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class Contact : Assertion {
        /// <summary>
        /// </summary>

		public virtual string						Identifier  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						FullName  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Title  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						First  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Middle  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Last  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Suffix  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<ProfileAccount>				AssertionAccounts  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<Address>				Addresses  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<Location>				Locations  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<Role>				Roles  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Contact";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new Contact();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Assertion)this).SerializeX(_Writer, false, ref _first);
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
				}
			if (FullName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("FullName", 1);
					_Writer.WriteString (FullName);
				}
			if (Title != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Title", 1);
					_Writer.WriteString (Title);
				}
			if (First != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("First", 1);
					_Writer.WriteString (First);
				}
			if (Middle != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Middle", 1);
					_Writer.WriteString (Middle);
				}
			if (Last != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Last", 1);
					_Writer.WriteString (Last);
				}
			if (Suffix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Suffix", 1);
					_Writer.WriteString (Suffix);
				}
			if (Labels != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Labels", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Labels) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (AssertionAccounts != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AssertionAccounts", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AssertionAccounts) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Addresses != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Addresses", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Addresses) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Locations != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Locations", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Locations) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Roles != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Roles", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Roles) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Contact FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Contact;
				}
		    var Result = new Contact ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Identifier" : {
					Identifier = JSONReader.ReadString ();
					break;
					}
				case "FullName" : {
					FullName = JSONReader.ReadString ();
					break;
					}
				case "Title" : {
					Title = JSONReader.ReadString ();
					break;
					}
				case "First" : {
					First = JSONReader.ReadString ();
					break;
					}
				case "Middle" : {
					Middle = JSONReader.ReadString ();
					break;
					}
				case "Last" : {
					Last = JSONReader.ReadString ();
					break;
					}
				case "Suffix" : {
					Suffix = JSONReader.ReadString ();
					break;
					}
				case "Labels" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Labels = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Labels.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "AssertionAccounts" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					AssertionAccounts = new List <ProfileAccount> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ProfileAccount ();
						_Item.Deserialize (JSONReader);
						// var _Item = new ProfileAccount (JSONReader);
						AssertionAccounts.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Addresses" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Addresses = new List <Address> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Address ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Address (JSONReader);
						Addresses.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Locations" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Locations = new List <Location> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Location ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Location (JSONReader);
						Locations.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Roles" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Roles = new List <Role> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Role ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Role (JSONReader);
						Roles.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// </summary>

		public virtual string						CompanyName  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<Address>				Addresses  {get; set;}
        /// <summary>
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (CompanyName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CompanyName", 1);
					_Writer.WriteString (CompanyName);
				}
			if (Addresses != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Addresses", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Addresses) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Locations != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Locations", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Locations) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Role FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Role;
				}
		    var Result = new Role ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "CompanyName" : {
					CompanyName = JSONReader.ReadString ();
					break;
					}
				case "Addresses" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Addresses = new List <Address> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Address ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Address (JSONReader);
						Addresses.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Locations" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Locations = new List <Location> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Location ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Location (JSONReader);
						Locations.Add (_Item);
						_Going = JSONReader.NextArray ();
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
	public partial class Address : MeshItem {
        /// <summary>
        /// </summary>

		public virtual string						URI  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				Labels  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Address";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new Address();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
					_Writer.WriteString (URI);
				}
			if (Labels != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Labels", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Labels) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Address FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Address;
				}
		    var Result = new Address ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "URI" : {
					URI = JSONReader.ReadString ();
					break;
					}
				case "Labels" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Labels = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Labels.Add (_Item);
						_Going = JSONReader.NextArray ();
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Appartment != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Appartment", 1);
					_Writer.WriteString (Appartment);
				}
			if (Street != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Street", 1);
					_Writer.WriteString (Street);
				}
			if (District != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("District", 1);
					_Writer.WriteString (District);
				}
			if (Locality != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Locality", 1);
					_Writer.WriteString (Locality);
				}
			if (County != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("County", 1);
					_Writer.WriteString (County);
				}
			if (Postcode != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Postcode", 1);
					_Writer.WriteString (Postcode);
				}
			if (Country != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Country", 1);
					_Writer.WriteString (Country);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Location FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Location;
				}
		    var Result = new Location ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Appartment" : {
					Appartment = JSONReader.ReadString ();
					break;
					}
				case "Street" : {
					Street = JSONReader.ReadString ();
					break;
					}
				case "District" : {
					District = JSONReader.ReadString ();
					break;
					}
				case "Locality" : {
					Locality = JSONReader.ReadString ();
					break;
					}
				case "County" : {
					County = JSONReader.ReadString ();
					break;
					}
				case "Postcode" : {
					Postcode = JSONReader.ReadString ();
					break;
					}
				case "Country" : {
					Country = JSONReader.ReadString ();
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (MessageID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MessageID", 1);
					_Writer.WriteString (MessageID);
				}
			if (ResponseID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ResponseID", 1);
					_Writer.WriteString (ResponseID);
				}
			if (Relationship != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Relationship", 1);
					_Writer.WriteString (Relationship);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Reference FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Reference;
				}
		    var Result = new Reference ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "MessageID" : {
					MessageID = JSONReader.ReadString ();
					break;
					}
				case "ResponseID" : {
					ResponseID = JSONReader.ReadString ();
					break;
					}
				case "Relationship" : {
					Relationship = JSONReader.ReadString ();
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (Start != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Start", 1);
					_Writer.WriteDateTime (Start);
				}
			if (Finish != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Finish", 1);
					_Writer.WriteDateTime (Finish);
				}
			if (StartTravel != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("StartTravel", 1);
					_Writer.WriteString (StartTravel);
				}
			if (FinishTravel != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("FinishTravel", 1);
					_Writer.WriteString (FinishTravel);
				}
			if (TimeZone != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TimeZone", 1);
					_Writer.WriteString (TimeZone);
				}
			if (Title != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Title", 1);
					_Writer.WriteString (Title);
				}
			if (Description != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Description", 1);
					_Writer.WriteString (Description);
				}
			if (Location != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Location", 1);
					_Writer.WriteString (Location);
				}
			if (Trigger != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Trigger", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Trigger) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Conference != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Conference", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Conference) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Repeat != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Repeat", 1);
					_Writer.WriteString (Repeat);
				}
			if (__Busy){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Busy", 1);
					_Writer.WriteBoolean (Busy);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Task FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Task;
				}
		    var Result = new Task ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Start" : {
					Start = JSONReader.ReadDateTime ();
					break;
					}
				case "Finish" : {
					Finish = JSONReader.ReadDateTime ();
					break;
					}
				case "StartTravel" : {
					StartTravel = JSONReader.ReadString ();
					break;
					}
				case "FinishTravel" : {
					FinishTravel = JSONReader.ReadString ();
					break;
					}
				case "TimeZone" : {
					TimeZone = JSONReader.ReadString ();
					break;
					}
				case "Title" : {
					Title = JSONReader.ReadString ();
					break;
					}
				case "Description" : {
					Description = JSONReader.ReadString ();
					break;
					}
				case "Location" : {
					Location = JSONReader.ReadString ();
					break;
					}
				case "Trigger" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Trigger = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Trigger.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Conference" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Conference = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Conference.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Repeat" : {
					Repeat = JSONReader.ReadString ();
					break;
					}
				case "Busy" : {
					Busy = JSONReader.ReadBoolean ();
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedEntry;
				}
		    var Result = new CatalogedEntry ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (DeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceUDF", 1);
					_Writer.WriteString (DeviceUDF);
				}
			if (EnvelopedProfileDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_Writer, false);
				}
			if (EnvelopedConnectionDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedConnectionDevice", 1);
					EnvelopedConnectionDevice.Serialize (_Writer, false);
				}
			if (EnvelopedActivationDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedActivationDevice", 1);
					EnvelopedActivationDevice.Serialize (_Writer, false);
				}
			if (Accounts != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Accounts", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Accounts) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedDevice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedDevice;
				}
		    var Result = new CatalogedDevice ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "DeviceUDF" : {
					DeviceUDF = JSONReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedConnectionDevice" : {
					// An untagged structure
					EnvelopedConnectionDevice = new DareEnvelope ();
					EnvelopedConnectionDevice.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedActivationDevice" : {
					// An untagged structure
					EnvelopedActivationDevice = new DareEnvelope ();
					EnvelopedActivationDevice.Deserialize (JSONReader);
 
					break;
					}
				case "Accounts" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Accounts = new List <AccountEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  AccountEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new AccountEntry (JSONReader);
						Accounts.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (AccountUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountUDF", 1);
					_Writer.WriteString (AccountUDF);
				}
			if (EnvelopedProfileAccount != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_Writer, false);
				}
			if (EnvelopedConnectionAccount != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedConnectionAccount", 1);
					EnvelopedConnectionAccount.Serialize (_Writer, false);
				}
			if (EnvelopedActivationAccount != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedActivationAccount", 1);
					EnvelopedActivationAccount.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new AccountEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountEntry;
				}
		    var Result = new AccountEntry ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AccountUDF" : {
					AccountUDF = JSONReader.ReadString ();
					break;
					}
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new DareEnvelope ();
					EnvelopedProfileAccount.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedConnectionAccount" : {
					// An untagged structure
					EnvelopedConnectionAccount = new DareEnvelope ();
					EnvelopedConnectionAccount.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedActivationAccount" : {
					// An untagged structure
					EnvelopedActivationAccount = new DareEnvelope ();
					EnvelopedActivationAccount.Deserialize (JSONReader);
 
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (Protocol != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Protocol", 1);
					_Writer.WriteString (Protocol);
				}
			if (Service != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Service", 1);
					_Writer.WriteString (Service);
				}
			if (Username != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Username", 1);
					_Writer.WriteString (Username);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedCredential FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedCredential;
				}
		    var Result = new CatalogedCredential ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Protocol" : {
					Protocol = JSONReader.ReadString ();
					break;
					}
				case "Service" : {
					Service = JSONReader.ReadString ();
					break;
					}
				case "Username" : {
					Username = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (Protocol != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Protocol", 1);
					_Writer.WriteString (Protocol);
				}
			if (Service != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Service", 1);
					_Writer.WriteString (Service);
				}
			if (Username != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Username", 1);
					_Writer.WriteString (Username);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedNetwork FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedNetwork;
				}
		    var Result = new CatalogedNetwork ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Protocol" : {
					Protocol = JSONReader.ReadString ();
					break;
					}
				case "Service" : {
					Service = JSONReader.ReadString ();
					break;
					}
				case "Username" : {
					Username = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	/// </summary>
	public partial class CatalogedContact : CatalogedEntry {
		bool								__Self = false;
		private bool						_Self;
        /// <summary>
        ///If true, this catalog entry is for the user who created the catalog. To be
        ///valid, such an entry MUST be signed by an administration key for the Mesh
        ///profile containing the account to which the catalog belongs.
        /// </summary>

		public virtual bool						Self {
			get => _Self;
			set {_Self = value; __Self = true; }
			}
        /// <summary>
        ///Unique key. 
        /// </summary>

		public virtual string						Key  {get; set;}
        /// <summary>
        ///List of the permissions that the contact has been granted.
        /// </summary>

		public virtual List<Permission>				Permissions  {get; set;}
        /// <summary>
        ///The (signed) contact data.
        /// </summary>

		public virtual DareEnvelope						EnvelopedContact  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (__Self){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Self", 1);
					_Writer.WriteBoolean (Self);
				}
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (Permissions != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Permissions", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Permissions) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (EnvelopedContact != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedContact", 1);
					EnvelopedContact.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedContact FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedContact;
				}
		    var Result = new CatalogedContact ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Self" : {
					Self = JSONReader.ReadBoolean ();
					break;
					}
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				case "Permissions" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Permissions = new List <Permission> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Permission ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Permission (JSONReader);
						Permissions.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "EnvelopedContact" : {
					// An untagged structure
					EnvelopedContact = new DareEnvelope ();
					EnvelopedContact.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedContact)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedContactRecryption FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedContactRecryption;
				}
		    var Result = new CatalogedContactRecryption ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (Uri != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Uri", 1);
					_Writer.WriteString (Uri);
				}
			if (Title != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Title", 1);
					_Writer.WriteString (Title);
				}
			if (Path != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Path", 1);
					_Writer.WriteString (Path);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedBookmark FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedBookmark;
				}
		    var Result = new CatalogedBookmark ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Uri" : {
					Uri = JSONReader.ReadString ();
					break;
					}
				case "Title" : {
					Title = JSONReader.ReadString ();
					break;
					}
				case "Path" : {
					Path = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (EnvelopedTask != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedTask", 1);
					EnvelopedTask.Serialize (_Writer, false);
				}
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedTask FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedTask;
				}
		    var Result = new CatalogedTask ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EnvelopedTask" : {
					// An untagged structure
					EnvelopedTask = new DareEnvelope ();
					EnvelopedTask.Deserialize (JSONReader);
 
					break;
					}
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (Key != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Key", 1);
					_Writer.WriteString (Key);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedApplication FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplication;
				}
		    var Result = new CatalogedApplication ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Key" : {
					Key = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedEntry)this).SerializeX(_Writer, false, ref _first);
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedMember FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedMember;
				}
		    var Result = new CatalogedMember ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedApplication)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedGroup FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedGroup;
				}
		    var Result = new CatalogedGroup ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedApplication)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedApplicationSSH FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplicationSSH;
				}
		    var Result = new CatalogedApplicationSSH ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedApplication)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedApplicationMail FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplicationMail;
				}
		    var Result = new CatalogedApplicationMail ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogedApplication)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedApplicationNetwork FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedApplicationNetwork;
				}
		    var Result = new CatalogedApplicationNetwork ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (MessageID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MessageID", 1);
					_Writer.WriteString (MessageID);
				}
			if (Sender != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sender", 1);
					_Writer.WriteString (Sender);
				}
			if (Recipient != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Recipient", 1);
					_Writer.WriteString (Recipient);
				}
			if (References != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("References", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in References) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new Message FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Message;
				}
		    var Result = new Message ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "MessageID" : {
					MessageID = JSONReader.ReadString ();
					break;
					}
				case "Sender" : {
					Sender = JSONReader.ReadString ();
					break;
					}
				case "Recipient" : {
					Recipient = JSONReader.ReadString ();
					break;
					}
				case "References" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					References = new List <Reference> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Reference ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Reference (JSONReader);
						References.Add (_Item);
						_Going = JSONReader.NextArray ();
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MessageComplete FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MessageComplete;
				}
		    var Result = new MessageComplete ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <summary>
        /// </summary>

		public virtual string						PIN  {get; set;}
		
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (Expires != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Expires", 1);
					_Writer.WriteDateTime (Expires);
				}
			if (PIN != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PIN", 1);
					_Writer.WriteString (PIN);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new MessagePIN FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MessagePIN;
				}
		    var Result = new MessagePIN ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "Expires" : {
					Expires = JSONReader.ReadDateTime ();
					break;
					}
				case "PIN" : {
					PIN = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual string						ServiceID  {get; set;}
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (ServiceID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServiceID", 1);
					_Writer.WriteString (ServiceID);
				}
			if (EnvelopedProfileDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_Writer, false);
				}
			if (ClientNonce != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ClientNonce", 1);
					_Writer.WriteBinary (ClientNonce);
				}
			if (PinUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PinUDF", 1);
					_Writer.WriteString (PinUDF);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new RequestConnection FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RequestConnection;
				}
		    var Result = new RequestConnection ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ServiceID" : {
					ServiceID = JSONReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (JSONReader);
 
					break;
					}
				case "ClientNonce" : {
					ClientNonce = JSONReader.ReadBinary ();
					break;
					}
				case "PinUDF" : {
					PinUDF = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (EnvelopedRequestConnection != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedRequestConnection", 1);
					EnvelopedRequestConnection.Serialize (_Writer, false);
				}
			if (ServerNonce != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServerNonce", 1);
					_Writer.WriteBinary (ServerNonce);
				}
			if (Witness != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Witness", 1);
					_Writer.WriteString (Witness);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new AcknowledgeConnection FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as AcknowledgeConnection;
				}
		    var Result = new AcknowledgeConnection ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EnvelopedRequestConnection" : {
					// An untagged structure
					EnvelopedRequestConnection = new DareEnvelope ();
					EnvelopedRequestConnection.Deserialize (JSONReader);
 
					break;
					}
				case "ServerNonce" : {
					ServerNonce = JSONReader.ReadBinary ();
					break;
					}
				case "Witness" : {
					Witness = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (__Reply){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Reply", 1);
					_Writer.WriteBoolean (Reply);
				}
			if (Self != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Self", 1);
					Self.Serialize (_Writer, false);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new RequestContact FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RequestContact;
				}
		    var Result = new RequestContact ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Reply" : {
					Reply = JSONReader.ReadBoolean ();
					break;
					}
				case "Self" : {
					// An untagged structure
					Self = new DareEnvelope ();
					Self.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (Text != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Text", 1);
					_Writer.WriteString (Text);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new RequestConfirmation FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RequestConfirmation;
				}
		    var Result = new RequestConfirmation ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Text" : {
					Text = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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

		public virtual string						ResponseID  {get; set;}
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (ResponseID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ResponseID", 1);
					_Writer.WriteString (ResponseID);
				}
			if (__Accept){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Accept", 1);
					_Writer.WriteBoolean (Accept);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new ResponseConfirmation FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ResponseConfirmation;
				}
		    var Result = new ResponseConfirmation ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ResponseID" : {
					ResponseID = JSONReader.ReadString ();
					break;
					}
				case "Accept" : {
					Accept = JSONReader.ReadBoolean ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
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
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Message)this).SerializeX(_Writer, false, ref _first);
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new RequestTask FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RequestTask;
				}
		    var Result = new RequestTask ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

