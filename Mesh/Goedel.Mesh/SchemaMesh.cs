
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
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;



using Goedel.Cryptography.Jose;


namespace Goedel.Mesh {


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
	public abstract partial class MeshItem : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return _Tag;
			}

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "MeshItem";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"PublicKey", PublicKey._Factory},
			{"SignedData", SignedData._Factory},
			{"EncryptedData", EncryptedData._Factory},
			{"Connection", Connection._Factory},
			{"Entry", Entry._Factory},
			{"SignedProfile", SignedProfile._Factory},
			{"Advice", Advice._Factory},
			{"PortalAdvice", PortalAdvice._Factory},
			{"Profile", Profile._Factory},
			{"SignedDeviceProfile", SignedDeviceProfile._Factory},
			{"DeviceProfile", DeviceProfile._Factory},
			{"DevicePrivateProfile", DevicePrivateProfile._Factory},
			{"SignedMasterProfile", SignedMasterProfile._Factory},
			{"MasterProfile", MasterProfile._Factory},
			{"SignedPersonalProfile", SignedPersonalProfile._Factory},
			{"PersonalProfile", PersonalProfile._Factory},
			{"ApplicationProfileEntry", ApplicationProfileEntry._Factory},
			{"SignedApplicationProfile", SignedApplicationProfile._Factory},
			{"ApplicationProfile", ApplicationProfile._Factory},
			{"ApplicationProfilePrivate", ApplicationProfilePrivate._Factory},
			{"ApplicationDevicePublic", ApplicationDevicePublic._Factory},
			{"ApplicationDevicePrivate", ApplicationDevicePrivate._Factory},
			{"EscrowEntry", EscrowEntry._Factory},
			{"OfflineEscrowEntry", OfflineEscrowEntry._Factory},
			{"OnlineEscrowEntry", OnlineEscrowEntry._Factory},
			{"EscrowedKeySet", EscrowedKeySet._Factory},
			{"ConnectionRequest", ConnectionRequest._Factory},
			{"SignedConnectionRequest", SignedConnectionRequest._Factory},
			{"ConnectionResult", ConnectionResult._Factory},
			{"SignedConnectionResult", SignedConnectionResult._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
			Out = JSONReader.ReadTaggedObject (_TagDictionary);
            }
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
		public override string _Tag { get; } = "PublicKey";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new PublicKey();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
						_Writer.WriteToken(PublicParameters.Tag(), 1);
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
						_Writer.WriteToken(PrivateParameters.Tag(), 1);
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
	///
	/// Container for JOSE signed data and related attributes.
	/// </summary>
	public partial class SignedData : MeshItem {
        /// <summary>
        ///The signed data
        /// </summary>

		public virtual byte[]						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedData";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedData();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
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
        public static new SignedData FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedData;
				}
		    var Result = new SignedData ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Data" : {
					Data = JSONReader.ReadBinary ();
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
	/// Container for JOSE encrypted data and related attributes.
	/// </summary>
	public partial class EncryptedData : MeshItem {
        /// <summary>
        ///The encrypted data
        /// </summary>

		public virtual byte[]						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "EncryptedData";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new EncryptedData();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
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
        public static new EncryptedData FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as EncryptedData;
				}
		    var Result = new EncryptedData ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Data" : {
					Data = JSONReader.ReadBinary ();
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
	/// Describes network connection parameters for an application
	/// </summary>
	public partial class Connection : MeshItem {
        /// <summary>
        ///DNS address of the server
        /// </summary>

		public virtual string						ServiceName  {get; set;}
		bool								__Port = false;
		private int						_Port;
        /// <summary>
        ///TCP/UDP Port number
        /// </summary>

		public virtual int						Port {
			get {return _Port;}
			set {_Port = value; __Port = true; }
			}
        /// <summary>
        ///DNS service prefix as described in [!RFC6335]
        /// </summary>

		public virtual string						Prefix  {get; set;}
        /// <summary>
        ///Describes the security mode to use. Valid choices are Direct/Upgrade/None
        /// </summary>

		public virtual List<string>				Security  {get; set;}
        /// <summary>
        ///Username to present to the service for authentication
        /// </summary>

		public virtual string						UserName  {get; set;}
        /// <summary>
        ///Password to present to the service for authentication
        /// </summary>

		public virtual string						Password  {get; set;}
        /// <summary>
        ///Service connection parameters in URI format
        /// </summary>

		public virtual string						URI  {get; set;}
        /// <summary>
        ///List of the supported/acceptable authentication mechanisms,
        ///preferred mechanism first.
        /// </summary>

		public virtual string						Authentication  {get; set;}
		bool								__TimeOut = false;
		private int						_TimeOut;
        /// <summary>
        ///Service timeout in seconds.
        /// </summary>

		public virtual int						TimeOut {
			get {return _TimeOut;}
			set {_TimeOut = value; __TimeOut = true; }
			}
		bool								__Polling = false;
		private bool						_Polling;
        /// <summary>
        ///If set, the client should poll the specified service intermittently
        ///for updates.
        /// </summary>

		public virtual bool						Polling {
			get {return _Polling;}
			set {_Polling = value; __Polling = true; }
			}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Connection";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Connection();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ServiceName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServiceName", 1);
					_Writer.WriteString (ServiceName);
				}
			if (__Port){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Port", 1);
					_Writer.WriteInteger32 (Port);
				}
			if (Prefix != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Prefix", 1);
					_Writer.WriteString (Prefix);
				}
			if (Security != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Security", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Security) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (UserName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UserName", 1);
					_Writer.WriteString (UserName);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (URI != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("URI", 1);
					_Writer.WriteString (URI);
				}
			if (Authentication != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Authentication", 1);
					_Writer.WriteString (Authentication);
				}
			if (__TimeOut){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("TimeOut", 1);
					_Writer.WriteInteger32 (TimeOut);
				}
			if (__Polling){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Polling", 1);
					_Writer.WriteBoolean (Polling);
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
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ServiceName" : {
					ServiceName = JSONReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = JSONReader.ReadInteger32 ();
					break;
					}
				case "Prefix" : {
					Prefix = JSONReader.ReadString ();
					break;
					}
				case "Security" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Security = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Security.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "UserName" : {
					UserName = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				case "URI" : {
					URI = JSONReader.ReadString ();
					break;
					}
				case "Authentication" : {
					Authentication = JSONReader.ReadString ();
					break;
					}
				case "TimeOut" : {
					TimeOut = JSONReader.ReadInteger32 ();
					break;
					}
				case "Polling" : {
					Polling = JSONReader.ReadBoolean ();
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
	/// Base class for all Mesh Profile objects.
	/// </summary>
	public partial class Entry : MeshItem {
        /// <summary>
        ///Globally unique identifier that remains constant for the lifetime of the 
        ///entry.
        /// </summary>

		public virtual string						Identifier  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Entry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Entry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
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
        public static new Entry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Entry;
				}
		    var Result = new Entry ();
			Result.Deserialize (JSONReader);
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
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Contains a signed profile entry
	/// </summary>
	public partial class SignedProfile : Entry {
        /// <summary>
        ///The signed profile.
        ///Note that each child of SignedProfile requires that the Payload field
        ///of the SignedData object contain an object of a specific type. 
        ///For example, a SignedDeviceProfile object MUST contain a Payload field that
        ///contains a DeviceProfile object.
        /// </summary>

		public virtual JoseWebSignature						SignedData  {get; set;}
        /// <summary>
        ///Additional data that is not authenticated.
        /// </summary>

		public virtual Advice						Unauthenticated  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (SignedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedData", 1);
					SignedData.Serialize (_Writer, false);
				}
			if (Unauthenticated != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Unauthenticated", 1);
					Unauthenticated.Serialize (_Writer, false);
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
        public static new SignedProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedProfile;
				}
		    var Result = new SignedProfile ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedData" : {
					// An untagged structure
					SignedData = new JoseWebSignature ();
					SignedData.Deserialize (JSONReader);
 
					break;
					}
				case "Unauthenticated" : {
					// An untagged structure
					Unauthenticated = new Advice ();
					Unauthenticated.Deserialize (JSONReader);
 
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
	/// Additional data bound to a signed profile that is not authenticated.
	/// </summary>
	public partial class Advice : MeshItem {
        /// <summary>
        ///If specified, the profile was the default profile at the specified 
        ///date and time. The current default for that type of profile is the
        ///profile with the most recent Default timestamp.
        /// </summary>

		public virtual DateTime?						Default  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Advice";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Advice();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Default != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Default", 1);
					_Writer.WriteDateTime (Default);
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
        public static new Advice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Advice;
				}
		    var Result = new Advice ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Default" : {
					Default = JSONReader.ReadDateTime ();
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
	/// Describes the portal(s) at which the profile is registered.
	/// </summary>
	public partial class PortalAdvice : Advice {
        /// <summary>
        ///A portal address at which this profile is registered.
        /// </summary>

		public virtual List<string>				PortalAddress  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "PortalAdvice";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new PortalAdvice();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Advice)this).SerializeX(_Writer, false, ref _first);
			if (PortalAddress != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PortalAddress", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in PortalAddress) {
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
        public static new PortalAdvice FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PortalAdvice;
				}
		    var Result = new PortalAdvice ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "PortalAddress" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					PortalAddress = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						PortalAddress.Add (_Item);
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
	/// Parent class from which all profile types are derived
	/// </summary>
	abstract public partial class Profile : Entry {
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
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Profile";

		/// <summary>
        /// Factory method. Throws exception as this is an abstract class.
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			throw new CannotCreateAbstract();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
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
	/// Contains a signed device profile
	/// </summary>
	public partial class SignedDeviceProfile : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedDeviceProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedDeviceProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedDeviceProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedDeviceProfile;
				}
		    var Result = new SignedDeviceProfile ();
			Result.Deserialize (JSONReader);
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
	/// Describes a mesh device.
	/// </summary>
	public partial class DeviceProfile : Profile {
        /// <summary>
        ///Description of the device
        /// </summary>

		public virtual string						Description  {get; set;}
        /// <summary>
        ///Key used to sign certificates for the DAK and DEK. The fingerprint of
        ///the DSK is the UniqueID of the Device Profile
        /// </summary>

		public virtual PublicKey						DeviceSignatureKey  {get; set;}
        /// <summary>
        ///Key used to authenticate requests made by the device.
        /// </summary>

		public virtual PublicKey						DeviceAuthenticationKey  {get; set;}
        /// <summary>
        ///Key used to pass encrypted data to the device such as a
        ///DeviceUseEntry
        /// </summary>

		public virtual PublicKey						DeviceEncryptiontionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DeviceProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DeviceProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (Description != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Description", 1);
					_Writer.WriteString (Description);
				}
			if (DeviceSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceSignatureKey", 1);
					DeviceSignatureKey.Serialize (_Writer, false);
				}
			if (DeviceAuthenticationKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceAuthenticationKey", 1);
					DeviceAuthenticationKey.Serialize (_Writer, false);
				}
			if (DeviceEncryptiontionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceEncryptiontionKey", 1);
					DeviceEncryptiontionKey.Serialize (_Writer, false);
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
        public static new DeviceProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DeviceProfile;
				}
		    var Result = new DeviceProfile ();
			Result.Deserialize (JSONReader);
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
				case "DeviceSignatureKey" : {
					// An untagged structure
					DeviceSignatureKey = new PublicKey ();
					DeviceSignatureKey.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceAuthenticationKey" : {
					// An untagged structure
					DeviceAuthenticationKey = new PublicKey ();
					DeviceAuthenticationKey.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// An untagged structure
					DeviceEncryptiontionKey = new PublicKey ();
					DeviceEncryptiontionKey.Deserialize (JSONReader);
 
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
	/// Private portion of device encryption profile. 
	/// </summary>
	public partial class DevicePrivateProfile : MeshItem {
        /// <summary>
        ///Private portion of the DeviceSignatureKey
        /// </summary>

		public virtual Key						DeviceSignatureKey  {get; set;}
        /// <summary>
        ///Private portion of the DeviceAuthenticationKey
        /// </summary>

		public virtual Key						DeviceAuthenticationKey  {get; set;}
        /// <summary>
        ///Private portion of the DeviceEncryptiontionKey
        /// </summary>

		public virtual Key						DeviceEncryptiontionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "DevicePrivateProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new DevicePrivateProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (DeviceSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceSignatureKey", 1);
					DeviceSignatureKey.Serialize (_Writer, false);
				}
			if (DeviceAuthenticationKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceAuthenticationKey", 1);
					DeviceAuthenticationKey.Serialize (_Writer, false);
				}
			if (DeviceEncryptiontionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceEncryptiontionKey", 1);
					DeviceEncryptiontionKey.Serialize (_Writer, false);
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
        public static new DevicePrivateProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as DevicePrivateProfile;
				}
		    var Result = new DevicePrivateProfile ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DeviceSignatureKey" : {
					// An untagged structure
					DeviceSignatureKey = new Key ();
					DeviceSignatureKey.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceAuthenticationKey" : {
					// An untagged structure
					DeviceAuthenticationKey = new Key ();
					DeviceAuthenticationKey.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceEncryptiontionKey" : {
					// An untagged structure
					DeviceEncryptiontionKey = new Key ();
					DeviceEncryptiontionKey.Deserialize (JSONReader);
 
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
	/// Contains a signed Personal master profile
	/// </summary>
	public partial class SignedMasterProfile : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedMasterProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedMasterProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedMasterProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedMasterProfile;
				}
		    var Result = new SignedMasterProfile ();
			Result.Deserialize (JSONReader);
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
	/// Describes the long term parameters associated with a personal profile.
	/// </summary>
	public partial class MasterProfile : Profile {
        /// <summary>
        ///The root of trust for the Personal PKI, the public key of the PMSK 
        ///is presented as a self-signed X.509v3 certificate with Certificate 
        ///Signing use enabled. The PMSK is used to sign certificates for the 
        ///PMEK, POSK and PKEK keys.
        /// </summary>

		public virtual PublicKey						MasterSignatureKey  {get; set;}
        /// <summary>
        ///A Personal Profile MAY contain one or more PMEK keys to enable escrow 
        ///of private keys used for stored data. 
        /// </summary>

		public virtual List<PublicKey>				MasterEscrowKeys  {get; set;}
        /// <summary>
        ///A Personal profile contains at least one POSK which is used to sign 
        ///device administration application profiles.
        /// </summary>

		public virtual List<PublicKey>				OnlineSignatureKeys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "MasterProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new MasterProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (MasterSignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterSignatureKey", 1);
					MasterSignatureKey.Serialize (_Writer, false);
				}
			if (MasterEscrowKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MasterEscrowKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MasterEscrowKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (OnlineSignatureKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("OnlineSignatureKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in OnlineSignatureKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
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
        public static new MasterProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MasterProfile;
				}
		    var Result = new MasterProfile ();
			Result.Deserialize (JSONReader);
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
					// An untagged structure
					MasterSignatureKey = new PublicKey ();
					MasterSignatureKey.Deserialize (JSONReader);
 
					break;
					}
				case "MasterEscrowKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MasterEscrowKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						MasterEscrowKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "OnlineSignatureKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					OnlineSignatureKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						OnlineSignatureKeys.Add (_Item);
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
	/// Contains a signed Personal current profile
	/// </summary>
	public partial class SignedPersonalProfile : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedPersonalProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedPersonalProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedPersonalProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedPersonalProfile;
				}
		    var Result = new SignedPersonalProfile ();
			Result.Deserialize (JSONReader);
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
	/// Describes the current applications and devices connected to a 
	/// personal master profile.
	/// </summary>
	public partial class PersonalProfile : Profile {
        /// <summary>
        ///The corresponding master profile. 
        ///The profile MUST be signed by the PMSK.
        /// </summary>

		public virtual SignedMasterProfile						SignedMasterProfile  {get; set;}
        /// <summary>
        ///The set of device profiles connected to the profile.
        ///The profile MUST be signed by the DSK in the profile.
        /// </summary>

		public virtual List<SignedDeviceProfile>				Devices  {get; set;}
        /// <summary>
        ///Application profiles connected to this profile.
        /// </summary>

		public virtual List<ApplicationProfileEntry>				Applications  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "PersonalProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new PersonalProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (SignedMasterProfile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedMasterProfile", 1);
					SignedMasterProfile.Serialize (_Writer, false);
				}
			if (Devices != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Devices", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Devices) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Applications != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Applications", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Applications) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
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
        public static new PersonalProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PersonalProfile;
				}
		    var Result = new PersonalProfile ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignedMasterProfile" : {
					// An untagged structure
					SignedMasterProfile = new SignedMasterProfile ();
					SignedMasterProfile.Deserialize (JSONReader);
 
					break;
					}
				case "Devices" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Devices = new List <SignedDeviceProfile> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  SignedDeviceProfile ();
						_Item.Deserialize (JSONReader);
						// var _Item = new SignedDeviceProfile (JSONReader);
						Devices.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Applications" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Applications = new List <ApplicationProfileEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ApplicationProfileEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new ApplicationProfileEntry (JSONReader);
						Applications.Add (_Item);
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
	/// Personal profile entry describing the privileges of specific devices.
	/// </summary>
	public partial class ApplicationProfileEntry : MeshItem {
        /// <summary>
        ///The unique identifier of the application
        /// </summary>

		public virtual string						Identifier  {get; set;}
        /// <summary>
        ///The application type
        /// </summary>

		public virtual string						Type  {get; set;}
        /// <summary>
        ///Optional friendly name identifying the application.
        /// </summary>

		public virtual string						Friendly  {get; set;}
        /// <summary>
        ///List of devices authorized to sign application profiles
        /// </summary>

		public virtual List<string>				AdminDeviceUDF  {get; set;}
        /// <summary>
        ///List of devices authorized to read private parts of application 
        ///profiles.
        /// </summary>

		public virtual List<string>				DecryptDeviceUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationProfileEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ApplicationProfileEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Identifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Identifier", 1);
					_Writer.WriteString (Identifier);
				}
			if (Type != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Type", 1);
					_Writer.WriteString (Type);
				}
			if (Friendly != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Friendly", 1);
					_Writer.WriteString (Friendly);
				}
			if (AdminDeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AdminDeviceUDF", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AdminDeviceUDF) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (DecryptDeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptDeviceUDF", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DecryptDeviceUDF) {
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
        public static new ApplicationProfileEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationProfileEntry;
				}
		    var Result = new ApplicationProfileEntry ();
			Result.Deserialize (JSONReader);
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
				case "Type" : {
					Type = JSONReader.ReadString ();
					break;
					}
				case "Friendly" : {
					Friendly = JSONReader.ReadString ();
					break;
					}
				case "AdminDeviceUDF" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					AdminDeviceUDF = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						AdminDeviceUDF.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "DecryptDeviceUDF" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DecryptDeviceUDF = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						DecryptDeviceUDF.Add (_Item);
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
	///
	/// Contains a signed device profile
	/// </summary>
	public partial class SignedApplicationProfile : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedApplicationProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedApplicationProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedApplicationProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedApplicationProfile;
				}
		    var Result = new SignedApplicationProfile ();
			Result.Deserialize (JSONReader);
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
	/// Parent class from which all application profiles inherit.
	/// </summary>
	abstract public partial class ApplicationProfile : Profile {
        /// <summary>
        ///Public per device information
        /// </summary>

		public virtual List<ApplicationDevicePublic>				Devices  {get; set;}
        /// <summary>
        ///Encrypted application data	shared between all device
        /// </summary>

		public virtual JoseWebEncryption						SharedPrivate  {get; set;}
        /// <summary>
        ///Encrypted application data	specific to one device
        /// </summary>

		public virtual List<JoseWebEncryption>				DevicePrivate  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationProfile";

		/// <summary>
        /// Factory method. Throws exception as this is an abstract class.
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			throw new CannotCreateAbstract();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Profile)this).SerializeX(_Writer, false, ref _first);
			if (Devices != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Devices", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Devices) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    _Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (SharedPrivate != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SharedPrivate", 1);
					// expand this to a tagged structure
					//SharedPrivate.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(SharedPrivate.Tag(), 1);
						bool firstinner = true;
						SharedPrivate.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (DevicePrivate != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DevicePrivate", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DevicePrivate) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index.Tag(), 1);
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
        public static new ApplicationProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationProfile;
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
				case "Devices" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Devices = new List <ApplicationDevicePublic> ();
					while (_Going) {
						var _Item = ApplicationDevicePublic.FromJSON (JSONReader, true); // a tagged structure
						Devices.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "SharedPrivate" : {
					SharedPrivate = JoseWebEncryption.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "DevicePrivate" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DevicePrivate = new List <JoseWebEncryption> ();
					while (_Going) {
						var _Item = JoseWebEncryption.FromJSON (JSONReader, true); // a tagged structure
						DevicePrivate.Add (_Item);
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
	/// The base class for all private profiles.
	/// </summary>
	public partial class ApplicationProfilePrivate : Entry {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ApplicationProfilePrivate();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
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
        public static new ApplicationProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationProfilePrivate;
				}
		    var Result = new ApplicationProfilePrivate ();
			Result.Deserialize (JSONReader);
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
	/// Describes the public per device data
	/// </summary>
	public partial class ApplicationDevicePublic : Entry {
        /// <summary>
        ///Description of the device for convenience of the user.
        /// </summary>

		public virtual string						DeviceDescription  {get; set;}
        /// <summary>
        ///Fingerprint of device that this key corresponds to.
        /// </summary>

		public virtual string						DeviceUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationDevicePublic";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ApplicationDevicePublic();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (DeviceDescription != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceDescription", 1);
					_Writer.WriteString (DeviceDescription);
				}
			if (DeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceUDF", 1);
					_Writer.WriteString (DeviceUDF);
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
        public static new ApplicationDevicePublic FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationDevicePublic;
				}
		    var Result = new ApplicationDevicePublic ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DeviceDescription" : {
					DeviceDescription = JSONReader.ReadString ();
					break;
					}
				case "DeviceUDF" : {
					DeviceUDF = JSONReader.ReadString ();
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
	/// Describes the private per device data
	/// </summary>
	public partial class ApplicationDevicePrivate : Entry {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationDevicePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ApplicationDevicePrivate();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
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
        public static new ApplicationDevicePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationDevicePrivate;
				}
		    var Result = new ApplicationDevicePrivate ();
			Result.Deserialize (JSONReader);
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
	/// Contains escrowed data
	/// </summary>
	public partial class EscrowEntry : Entry {
        /// <summary>
        ///The encrypted escrow data 
        /// </summary>

		public virtual JoseWebEncryption						EncryptedData  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "EscrowEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new EscrowEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Entry)this).SerializeX(_Writer, false, ref _first);
			if (EncryptedData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptedData", 1);
					EncryptedData.Serialize (_Writer, false);
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
        public static new EscrowEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as EscrowEntry;
				}
		    var Result = new EscrowEntry ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "EncryptedData" : {
					// An untagged structure
					EncryptedData = new JoseWebEncryption ();
					EncryptedData.Deserialize (JSONReader);
 
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
	/// Contains data escrowed using the offline escrow mechanism.
	/// </summary>
	public partial class OfflineEscrowEntry : EscrowEntry {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "OfflineEscrowEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new OfflineEscrowEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((EscrowEntry)this).SerializeX(_Writer, false, ref _first);
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
        public static new OfflineEscrowEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as OfflineEscrowEntry;
				}
		    var Result = new OfflineEscrowEntry ();
			Result.Deserialize (JSONReader);
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
	/// Contains data escrowed using the online escrow mechanism.
	/// </summary>
	public partial class OnlineEscrowEntry : EscrowEntry {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "OnlineEscrowEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new OnlineEscrowEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((EscrowEntry)this).SerializeX(_Writer, false, ref _first);
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
        public static new OnlineEscrowEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as OnlineEscrowEntry;
				}
		    var Result = new OnlineEscrowEntry ();
			Result.Deserialize (JSONReader);
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
	/// A set of escrowed keys. 
	/// </summary>
	public partial class EscrowedKeySet : MeshItem {
        /// <summary>
        ///A Master Signature Key
        /// </summary>

		public virtual Key						MasterSignatureKey  {get; set;}
        /// <summary>
        ///The escrowed keys.
        /// </summary>

		public virtual List<Key>				MasterEscrowKeys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "EscrowedKeySet";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new EscrowedKeySet();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
						_Writer.WriteToken(MasterSignatureKey.Tag(), 1);
						bool firstinner = true;
						MasterSignatureKey.Serialize (_Writer, true, ref firstinner);
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
                    _Writer.WriteToken(_index.Tag(), 1);
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
	///
	/// Describes a connection request.
	/// </summary>
	public partial class ConnectionRequest : MeshItem {
        /// <summary>
        ///UDF of Mesh Profile to which connection is requested.
        /// </summary>

		public virtual string						ParentUDF  {get; set;}
        /// <summary>
        ///The Device profile to be connected
        /// </summary>

		public virtual SignedDeviceProfile						Device  {get; set;}
        /// <summary>
        ///List of device specific application data.
        /// </summary>

		public virtual List<ApplicationDevicePublic>				DeviceData  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ConnectionRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ConnectionRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ParentUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ParentUDF", 1);
					_Writer.WriteString (ParentUDF);
				}
			if (Device != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Device", 1);
					Device.Serialize (_Writer, false);
				}
			if (DeviceData != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceData", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DeviceData) {
					_Writer.WriteArraySeparator (ref _firstarray);
                    _Writer.WriteObjectStart();
                    _Writer.WriteToken(_index.Tag(), 1);
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
        public static new ConnectionRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionRequest;
				}
		    var Result = new ConnectionRequest ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ParentUDF" : {
					ParentUDF = JSONReader.ReadString ();
					break;
					}
				case "Device" : {
					// An untagged structure
					Device = new SignedDeviceProfile ();
					Device.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceData" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DeviceData = new List <ApplicationDevicePublic> ();
					while (_Going) {
						var _Item = ApplicationDevicePublic.FromJSON (JSONReader, true); // a tagged structure
						DeviceData.Add (_Item);
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
	///
	/// Contains a ConnectionRequest signed by the 
	/// corresponding device signature key.
	/// </summary>
	public partial class SignedConnectionRequest : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedConnectionRequest";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedConnectionRequest();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedConnectionRequest FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedConnectionRequest;
				}
		    var Result = new SignedConnectionRequest ();
			Result.Deserialize (JSONReader);
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
	/// Describes the result of a connection request.
	/// </summary>
	public partial class ConnectionResult : ConnectionRequest {
        /// <summary>
        ///The result of the connection request. Valid responses are:
        ///Accepted, Refused, Query.
        /// </summary>

		public virtual string						Result  {get; set;}
        /// <summary>
        ///The updated profile if changed.
        /// </summary>

		public virtual SignedProfile						Profile  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ConnectionResult";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ConnectionResult();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ConnectionRequest)this).SerializeX(_Writer, false, ref _first);
			if (Result != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Result", 1);
					_Writer.WriteString (Result);
				}
			if (Profile != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Profile", 1);
					// expand this to a tagged structure
					//Profile.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(Profile.Tag(), 1);
						bool firstinner = true;
						Profile.Serialize (_Writer, true, ref firstinner);
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
        public static new ConnectionResult FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ConnectionResult;
				}
		    var Result = new ConnectionResult ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Result" : {
					Result = JSONReader.ReadString ();
					break;
					}
				case "Profile" : {
					Profile = SignedProfile.FromJSON (JSONReader, true) ;  // A tagged structure
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
	/// Contains a signed connection result
	/// </summary>
	public partial class SignedConnectionResult : SignedProfile {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "SignedConnectionResult";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new SignedConnectionResult();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
			}

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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((SignedProfile)this).SerializeX(_Writer, false, ref _first);
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
        public static new SignedConnectionResult FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as SignedConnectionResult;
				}
		    var Result = new SignedConnectionResult ();
			Result.Deserialize (JSONReader);
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

