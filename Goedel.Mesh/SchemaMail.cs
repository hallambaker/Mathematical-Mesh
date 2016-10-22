
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
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return "MeshMail";
			}

        /// <summary>
        /// Default constructor.
        /// </summary>
		public MeshMail () {
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
		public MeshMail (JSONReader JSONReader) {
			Deserialize (JSONReader);
			_Initialize () ;
			}

        /// <summary>
        /// Construct an instance from a JSON encoded string.
        /// </summary>
        /// <param name="_String">Input string</param>
		public MeshMail (string _String) {
			Deserialize (_String);
			_Initialize () ;
			}

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
	
			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                Out = null;
                return;
                }

			string token = JSONReader.ReadToken ();
			Out = null;

			switch (token) {

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}


				case "MailProfilePrivate" : {
					var Result = new MailProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					throw new Exception ("Not supported");
					}
				}	
			JSONReader.EndObject ();
            }
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

		public virtual PublicKey						EncryptionPGP {
			get {return _EncryptionPGP;}			
			set {_EncryptionPGP = value;}
			}
		PublicKey						_EncryptionPGP ;
        /// <summary>
        ///The current S/MIME encryption key
        /// </summary>

		public virtual PublicKey						EncryptionSMIME {
			get {return _EncryptionSMIME;}			
			set {_EncryptionSMIME = value;}
			}
		PublicKey						_EncryptionSMIME ;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MailProfile";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MailProfile () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public MailProfile (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public MailProfile (string _String) {
			Deserialize (_String);
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
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfile From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfile From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfile (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "MailProfile" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfile FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "MailProfile" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfile FromTagged (string _Input) {
			//MailProfile _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <returns>The created object.</returns>		
        public static new MailProfile  FromTagged (JSONReader JSONReader) {
			MailProfile Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "MailProfile" : {
					var Result = new MailProfile ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
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
					EncryptionPGP = new PublicKey (JSONReader);
 
					break;
					}
				case "EncryptionSMIME" : {
					// An untagged structure
					EncryptionSMIME = new PublicKey (JSONReader);
 
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
	/// Describes a mail account configuration
	/// Private profile contains connection settings for the inbound and
	/// outbound mail server(s) and cryptographic private keys. Public
	/// profile may contain security policy information for the sender.
	/// </summary>
	public partial class MailProfilePrivate : MeshMail {
        /// <summary>
        ///The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>

		public virtual string						EmailAddress {
			get {return _EmailAddress;}			
			set {_EmailAddress = value;}
			}
		string						_EmailAddress ;
        /// <summary>
        ///The RFC822 Reply toEmail address. [e.g. "alice@example.com"]
        ///When set, allows a sender to tell the receiver that replies to
        ///this account should be directed to this address.
        /// </summary>

		public virtual string						ReplyToAddress {
			get {return _ReplyToAddress;}			
			set {_ReplyToAddress = value;}
			}
		string						_ReplyToAddress ;
        /// <summary>
        ///The Display Name. [e.g. "Alice Example"]
        /// </summary>

		public virtual string						DisplayName {
			get {return _DisplayName;}			
			set {_DisplayName = value;}
			}
		string						_DisplayName ;
        /// <summary>
        ///The Account Name for display to the app user [e.g. "Work Account"]
        /// </summary>

		public virtual string						AccountName {
			get {return _AccountName;}			
			set {_AccountName = value;}
			}
		string						_AccountName ;
        /// <summary>
        ///The Inbound Mail Connection(s). This is typically IMAP4 or POP3
        ///If multiple connections are specified, the order in the sequence
        ///indicates the preference order.
        /// </summary>

		public virtual List<Connection>				Inbound {
			get {return _Inbound;}			
			set {_Inbound = value;}
			}
		List<Connection>				_Inbound;
        /// <summary>
        ///The Outbound Mail Connection(s). This is typically SMTP/SUBMIT
        ///If multiple connections are specified, the order in the sequence
        ///indicates the preference order.
        /// </summary>

		public virtual List<Connection>				Outbound {
			get {return _Outbound;}			
			set {_Outbound = value;}
			}
		List<Connection>				_Outbound;
        /// <summary>
        ///The public keypair(s) for signing and decrypting email.
        ///If multiple public keys are specified, the order indicates preference.
        /// </summary>

		public virtual List<PublicKey>				Sign {
			get {return _Sign;}			
			set {_Sign = value;}
			}
		List<PublicKey>				_Sign;
        /// <summary>
        ///The public keypairs for encrypting and decrypting email.
        ///If multiple public keys are specified, the order indicates preference.	
        /// </summary>

		public virtual List<PublicKey>				Encrypt {
			get {return _Encrypt;}			
			set {_Encrypt = value;}
			}
		List<PublicKey>				_Encrypt;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag () {
			return "MailProfilePrivate";
			}

        /// <summary>
        /// Default Constructor
        /// </summary>
		public MailProfilePrivate () {
			_Initialize ();
			}
        /// <summary>
		/// Initialize class from JSONReader stream.
        /// </summary>		
        /// <param name="JSONReader">Input stream</param>	
		public MailProfilePrivate (JSONReader JSONReader) {
			Deserialize (JSONReader);
			}

        /// <summary> 
		/// Initialize class from a JSON encoded class.
        /// </summary>		
        /// <param name="_String">Input string</param>
		public MailProfilePrivate (string _String) {
			Deserialize (_String);
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
                    //_Writer.WriteToken(_index.Tag(), 1);
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
                    //_Writer.WriteToken(_index.Tag(), 1);
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
                    //_Writer.WriteToken(_index.Tag(), 1);
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
		/// Create a new instance from untagged byte input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfilePrivate From (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return From (_Input);
			}

        /// <summary>
		/// Create a new instance from untagged string input.
		/// i.e. {... data ... }
        /// </summary>	
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfilePrivate From (string _Input) {
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return new MailProfilePrivate (JSONReader);
			}

        /// <summary>
		/// Create a new instance from tagged byte input.
		/// i.e. { "MailProfilePrivate" : {... data ... } }
        /// </summary>	
        /// <param name="_Data">The input data.</param>
        /// <returns>The created object.</returns>				
		public static new MailProfilePrivate FromTagged (byte[] _Data) {
			var _Input = System.Text.Encoding.UTF8.GetString(_Data);
			return FromTagged (_Input);
			}

        /// <summary>
        /// Create a new instance from tagged string input.
		/// i.e. { "MailProfilePrivate" : {... data ... } }
        /// </summary>
        /// <param name="_Input">The input data.</param>
        /// <returns>The created object.</returns>		
		public static new MailProfilePrivate FromTagged (string _Input) {
			//MailProfilePrivate _Result;
			//Deserialize (_Input, out _Result);
			StringReader _Reader = new StringReader (_Input);
            JSONReader JSONReader = new JSONReader (_Reader);
			return FromTagged (JSONReader) ;
			}


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <returns>The created object.</returns>		
        public static new MailProfilePrivate  FromTagged (JSONReader JSONReader) {
			MailProfilePrivate Out = null;

			JSONReader.StartObject ();
            if (JSONReader.EOR) {
                return null;
                }

			string token = JSONReader.ReadToken ();

			switch (token) {

				case "MailProfilePrivate" : {
					var Result = new MailProfilePrivate ();
					Result.Deserialize (JSONReader);
					Out = Result;
					break;
					}

				default : {
					//Ignore the unknown data
                    //throw new Exception ("Not supported");
                    break;
					}
				}
			JSONReader.EndObject ();

			return Out;
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
						var _Item = new Connection (JSONReader);
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
						var _Item = new Connection (JSONReader);
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
						var _Item = new PublicKey (JSONReader);
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
						var _Item = new PublicKey (JSONReader);
						Encrypt.Add (_Item);
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

	}

