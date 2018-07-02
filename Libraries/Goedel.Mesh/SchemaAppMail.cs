
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
	/// Classes that describe Mail applications.
	/// </summary>
	public abstract partial class MeshMail : global::Goedel.Protocol.JSONObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MeshMail";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"MailProfile", MailProfile._Factory},
			{"MailDevicePublic", MailDevicePublic._Factory},
			{"MailProfilePrivate", MailProfilePrivate._Factory},
			{"MailDevicePrivate", MailDevicePrivate._Factory}			};

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
	/// Public profile describes mail receipt policy. Private describes
	/// Sending policy
	/// </summary>
	public partial class MailProfile : ApplicationProfile {
        /// <summary>
        ///The current OpenPGP encryption key
        /// </summary>

		public virtual PublicKey						EncryptionPGP  {get; set;}
        /// <summary>
        ///The current S/MIME encryption key
        /// </summary>

		public virtual PublicKey						EncryptionSMIME  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MailProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MailProfile();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (EncryptionPGP != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionPGP", 1);
					EncryptionPGP.Serialize (_Writer, false);
				}
			if (EncryptionSMIME != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionSMIME", 1);
					EncryptionSMIME.Serialize (_Writer, false);
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
        public static new MailProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MailProfile;
				}
		    var Result = new MailProfile ();
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
				case "EncryptionPGP" : {
					// An untagged structure
					EncryptionPGP = new PublicKey ();
					EncryptionPGP.Deserialize (JSONReader);
 
					break;
					}
				case "EncryptionSMIME" : {
					// An untagged structure
					EncryptionSMIME = new PublicKey ();
					EncryptionSMIME.Deserialize (JSONReader);
 
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
	/// Contains public device description
	/// </summary>
	public partial class MailDevicePublic : ApplicationDevicePublic {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MailDevicePublic";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MailDevicePublic();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationDevicePublic)this).SerializeX(_Writer, false, ref _first);
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
        public static new MailDevicePublic FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MailDevicePublic;
				}
		    var Result = new MailDevicePublic ();
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
	/// Describes a mail account configuration
	/// Private profile contains connection settings for the inbound and
	/// outbound mail server(s) and cryptographic private keys. Public
	/// profile may contain security policy information for the sender.
	/// </summary>
	public partial class MailProfilePrivate : ApplicationProfilePrivate {
        /// <summary>
        ///The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>

		public virtual string						EmailAddress  {get; set;}
        /// <summary>
        ///The RFC822 Reply toEmail address. [e.g. "alice@example.com"]
        ///When set, allows a sender to tell the receiver that replies to
        ///this account should be directed to this address.
        /// </summary>

		public virtual string						ReplyToAddress  {get; set;}
        /// <summary>
        ///The Display Name. [e.g. "Alice Example"]
        /// </summary>

		public virtual string						DisplayName  {get; set;}
        /// <summary>
        ///The Account Name for display to the app user [e.g. "Work Account"]
        /// </summary>

		public virtual string						AccountName  {get; set;}
        /// <summary>
        ///The Inbound Mail Connection(s). This is typically IMAP4 or POP3
        ///If multiple connections are specified, the order in the sequence
        ///indicates the preference order.
        /// </summary>

		public virtual List<Connection>				Inbound  {get; set;}
        /// <summary>
        ///The Outbound Mail Connection(s). This is typically SMTP/SUBMIT
        ///If multiple connections are specified, the order in the sequence
        ///indicates the preference order.
        /// </summary>

		public virtual List<Connection>				Outbound  {get; set;}
        /// <summary>
        ///The public keypair(s) for signing and decrypting email.
        ///If multiple public keys are specified, the order indicates preference.
        /// </summary>

		public virtual List<PublicKey>				Sign  {get; set;}
        /// <summary>
        ///The public keypairs for encrypting and decrypting email.
        ///If multiple public keys are specified, the order indicates preference.	
        /// </summary>

		public virtual List<PublicKey>				Encrypt  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MailProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MailProfilePrivate();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
			if (EmailAddress != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EmailAddress", 1);
					_Writer.WriteString (EmailAddress);
				}
			if (ReplyToAddress != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ReplyToAddress", 1);
					_Writer.WriteString (ReplyToAddress);
				}
			if (DisplayName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DisplayName", 1);
					_Writer.WriteString (DisplayName);
				}
			if (AccountName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountName", 1);
					_Writer.WriteString (AccountName);
				}
			if (Inbound != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Inbound", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Inbound) {
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

			if (Outbound != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Outbound", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Outbound) {
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

			if (Sign != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sign", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sign) {
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

			if (Encrypt != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Encrypt", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Encrypt) {
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
        public static new MailProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MailProfilePrivate;
				}
		    var Result = new MailProfilePrivate ();
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
				case "EmailAddress" : {
					EmailAddress = JSONReader.ReadString ();
					break;
					}
				case "ReplyToAddress" : {
					ReplyToAddress = JSONReader.ReadString ();
					break;
					}
				case "DisplayName" : {
					DisplayName = JSONReader.ReadString ();
					break;
					}
				case "AccountName" : {
					AccountName = JSONReader.ReadString ();
					break;
					}
				case "Inbound" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Inbound = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Connection ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Connection (JSONReader);
						Inbound.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Outbound" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Outbound = new List <Connection> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Connection ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Connection (JSONReader);
						Outbound.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Sign" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Sign = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						Sign.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Encrypt" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Encrypt = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						Encrypt.Add (_Item);
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
	/// Private data specific to the device
	/// </summary>
	public partial class MailDevicePrivate : ApplicationDevicePrivate {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MailDevicePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MailDevicePrivate();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationDevicePrivate)this).SerializeX(_Writer, false, ref _first);
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
        public static new MailDevicePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MailDevicePrivate;
				}
		    var Result = new MailDevicePrivate ();
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

